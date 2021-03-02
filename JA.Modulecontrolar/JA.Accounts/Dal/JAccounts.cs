using Dutility;
using JA.Accounts.Model;
using JA.CommonInsert;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace JA.Accounts.Dal
{
    public class JAccounts
    {

        private string strSQL = "";
        //private string dd = Utility.SQLcomID();
        //private string connstring = Utility.SQLConnstring();
        private string connstring = "";
        #region "GetCompID"
        public string gOpenComID(string strID)
        {
            Utility.Modules.Clear();
            Utility.ModuleAdd(strID);
            return strID;
        }
        #endregion
        #region "Ledger Opening"
        public double mGetLedgerOpening(string strDeComID,string strFdate, string strTDate, string vstrLedgerName, string strBranchID)
        {
            string strSQL = null;
            double dblBackYearOpening = 0, dblOPening = 0, dblYearOpening = 0;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand();

                SqlCommand cmdInsert = new SqlCommand();


                if (strBranchID != "")
                {
                    strSQL = "SELECT LEDGER_OPENING_BALANCE AS OPENING FROM ACC_LEDGER ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                }
                else
                {
                    strSQL = "SELECT BRANCH_LEDGER_OPENING_BALANCE AS OPENING FROM ACC_BRANCH_LEDGER_OPENING ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName.Replace("'", "''") + "' ";
                    strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                }

                cmdInsert.CommandText = strSQL;
                cmdInsert.Connection = gcnMain;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblOPening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + "INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE >= ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + "";
                strSQL = strSQL + " AND  ";
                strSQL = strSQL + " COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFdate) + " ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                cmdInsert.Connection = gcnMain;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + " INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE < ";
                strSQL = strSQL + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + " ";
                strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrASSET + " OR ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrLIABILITY + " ) ";

                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                cmdInsert.Connection = gcnMain;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblBackYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();


                dblOPening = dblYearOpening + dblBackYearOpening + dblOPening;

                //if (dblOPening < 0)
                //{
                //    dblOpeningDr = dblOPening;
                //}
                //else
                //{
                //    dblOpeningCr = dblOPening;
                //}

                return dblOPening;

            }


        }
        public double mGetLedgerClosing(string strDeComID, string strFdate, string strTDate, string vstrLedgerName, string strBranchID)
        {
            string strSQL = null;
            double dblBackYearOpening = 0, dblOPening = 0, dblYearOpening = 0,
                                       dblTotalCredit = 0, dblTotalDebit = 0, dblclosing = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand();

                SqlCommand cmdInsert = new SqlCommand();


                if (strBranchID != "")
                {
                    strSQL = "SELECT LEDGER_OPENING_BALANCE AS OPENING FROM ACC_LEDGER ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                }
                else
                {
                    strSQL = "SELECT BRANCH_LEDGER_OPENING_BALANCE AS OPENING FROM ACC_BRANCH_LEDGER_OPENING ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName.Replace("'", "''") + "' ";
                    strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                }

                cmdInsert.CommandText = strSQL;
                cmdInsert.Connection = gcnMain;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblOPening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + "INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE >= ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + "";
                strSQL = strSQL + " AND  ";
                strSQL = strSQL + " COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFdate) + " ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                cmdInsert.Connection = gcnMain;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + " INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE < ";
                strSQL = strSQL + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + " ";
                strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrASSET + " OR ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrLIABILITY + " ) ";

                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                cmdInsert.Connection = gcnMain;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblBackYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();


                dblOPening = dblYearOpening + dblBackYearOpening + dblOPening;

                //if (dblOPening < 0)
                //{
                //    dblOpeningDr = dblOPening;
                //}
                //else
                //{
                //    dblOpeningCr = dblOPening;
                //}

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT),0) AS TOTAL_CREDIT,";
                strSQL = strSQL + "ISNULL(SUM(VOUCHER_DEBIT_AMOUNT),0) AS TOTAL_DEBIT ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strTDate) + ") ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                cmdInsert.Connection = gcnMain;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblTotalCredit = Convert.ToDouble(dr["TOTAL_CREDIT"].ToString());
                    dblTotalDebit = Convert.ToDouble(dr["TOTAL_DEBIT"].ToString());
                }
                dr.Close();


                dblclosing = dblOPening + (dblTotalCredit - dblTotalDebit);

                //if (dblclosing > 0)
                //{
                //    dblClosingDebit = dblclosing;
                //}
                //else
                //{
                //    dblClosingCredit = dblclosing;
                //}

                return dblclosing;

            }


        }
        public double mGetGroupClosing(string strDeComID, string strFdate, string strTDate, string vstrGroupName, string strBranchID)
        {
            string strSQL = null;
            double dblBackYearOpening = 0, dblOPening = 0, dblYearOpening = 0,
                                       dblTotalCredit = 0, dblTotalDebit = 0, dblclosing = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;


                strSQL = "SELECT ISNULL(SUM(GR_OPENING_CREDIT + GR_OPENING_DEBIT),0) AS OPENING ";
                strSQL = strSQL + "FROM ACC_LEDGERGROUP ";
                strSQL = strSQL + "WHERE GR_PARENT = '" + vstrGroupName + "' ";
                strSQL = strSQL + "AND GR_GROUP <> 401 ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblOPening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();
                //'Opening for Ledger

                strSQL =  "SELECT ISNULL(SUM(LEDGER_OPENING_BALANCE),0) OPENING ";
                strSQL = strSQL + "FROM ACC_LEDGER ";
                strSQL = strSQL + "WHERE LEDGER_PARENT_GROUP = '" + vstrGroupName + "' ";
                strSQL = strSQL + "AND LEDGER_GROUP <> 401 ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblOPening = dblOPening + Convert.ToDouble(dr["OPENING"].ToString());
                }

                dr.Close();


                strSQL = "SELECT ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT- ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) OPENING ";
                strSQL = strSQL + " FROM ACC_LEDGERGROUP INNER JOIN ";
                strSQL = strSQL + "ACC_LEDGER ON dbo.ACC_LEDGERGROUP.GR_NAME = ACC_LEDGER.LEDGER_PARENT_GROUP INNER JOIN ";
                strSQL = strSQL + "ACC_VOUCHER ON dbo.ACC_LEDGER.LEDGER_NAME = ACC_VOUCHER.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGERGROUP.GR_NAME = '" + vstrGroupName.Replace("'", "''") + "' ";
                strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE >= ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + "";
                strSQL = strSQL + " AND  ";
                strSQL = strSQL + " ACC_VOUCHER.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFdate) + " ";
                if (strBranchID != "" && strBranchID != "All")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT- ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) OPENING ";
                strSQL = strSQL + " FROM ACC_LEDGERGROUP INNER JOIN ";
                strSQL = strSQL + "ACC_LEDGER ON dbo.ACC_LEDGERGROUP.GR_NAME = ACC_LEDGER.LEDGER_PARENT_GROUP INNER JOIN ";
                strSQL = strSQL + "ACC_VOUCHER ON dbo.ACC_LEDGER.LEDGER_NAME = ACC_VOUCHER.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGERGROUP.GR_NAME = '" + vstrGroupName.Replace("'", "''") + "' ";
                strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE < ";
                strSQL = strSQL + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + " ";
                strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrASSET + " OR ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrLIABILITY + " ) ";

                if (strBranchID != "" && strBranchID != "All")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblBackYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();


                dblOPening = dblYearOpening + dblBackYearOpening + dblOPening;

                strSQL = "SELECT ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT),0)AS DEBIT_TOTAL,ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AS CREDIT_TOTAL ";
                strSQL = strSQL + "FROM ACC_VOUCHER LEFT OUTER JOIN ";
                strSQL = strSQL + "ACC_LEDGER_GROUP_QRY ON ACC_VOUCHER.LEDGER_NAME = ACC_LEDGER_GROUP_QRY.LEDGER_NAME ";
                strSQL = strSQL + "WHERE (COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " AND ";
                strSQL = strSQL + Utility.cvtSQLDateString(strTDate) + ") ";
                strSQL = strSQL + "AND GR_PARENT = '" + vstrGroupName + "' ";
                if (strBranchID != "" && strBranchID != "All")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblTotalCredit = Convert.ToDouble(dr["CREDIT_TOTAL"].ToString());
                    dblTotalDebit = Convert.ToDouble(dr["DEBIT_TOTAL"].ToString());
                }
                dr.Close();


                strSQL = "SELECT ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT),0) AS TOTAL_DEBIT ,";
                strSQL = strSQL + "ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AS TOTAL_CREDIT ";
                strSQL = strSQL + " FROM ACC_LEDGERGROUP INNER JOIN ";
                strSQL = strSQL + "ACC_LEDGER ON dbo.ACC_LEDGERGROUP.GR_NAME = ACC_LEDGER.LEDGER_PARENT_GROUP INNER JOIN ";
                strSQL = strSQL + "ACC_VOUCHER ON dbo.ACC_LEDGER.LEDGER_NAME = ACC_VOUCHER.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGERGROUP.GR_NAME = '" + vstrGroupName.Replace("'", "''") + "' ";
                strSQL = strSQL + "AND (ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strTDate) + ") ";
                if (strBranchID != "" && strBranchID != "All")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblTotalCredit = dblTotalCredit +Convert.ToDouble(dr["TOTAL_CREDIT"].ToString());
                    dblTotalDebit =dblTotalDebit+ Convert.ToDouble(dr["TOTAL_DEBIT"].ToString());
                }
                dr.Close();

                dblclosing = dblOPening + (dblTotalCredit - dblTotalDebit);

                return dblclosing;

            }


        }

        #endregion
        #region "Teritorry"
        public string mInsertTeritorry(string strDeComID, string strCode, string strName)
        {

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
                    strSQL = "INSERT INTO ACC_TERITORRY (";
                    strSQL = strSQL + "TERITORRY_CODE,TERITORRY_NAME";
                    strSQL = strSQL + ") ";
                    strSQL = strSQL + "VALUES (";
                    strSQL = strSQL + "'" + strCode + "',";
                    strSQL = strSQL + "'" + strName + "'";
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

        public string mUpdateTeritorry(string strDeComID, string strCode, string strName)
        {

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

                    strSQL = "UPDATE ACC_TERITORRY SET ";
                    //strSQL = strSQL + "TERITORRY_CODE='" + strCode + "'";
                    strSQL = strSQL + "TERITORRY_NAME='" + strName + "'";
                    strSQL = strSQL + "WHERE TERITORRY_CODE='" + strCode + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE ACC_LEDGER SET TERRITORRY_NAME='" + strName + "' ";
                    strSQL = strSQL + "WHERE TERITORRY_CODE='" + strCode + "' ";
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

        public string DeletetTeritorry(string strDeComID, string strTeritorryCode)
        {

            string strresponse = "";
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

                    strSQL = "DELETE FROM ACC_TERITORRY WHERE TERITORRY_CODE = '" + strTeritorryCode + "'";

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
        public List<Teritorry> mFillTeritorrySI(string strDeComID, string strCode)
        {

            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<Teritorry> ooVector = new List<Teritorry>();

            strSQL = "SELECT l.TERITORRY_CODE,l.TERRITORRY_NAME,l.LEDGER_NAME from ACC_TERITORRY t,ACC_LEDGER l where t.TERITORRY_CODE=l.TERITORRY_CODE ";
            strSQL = strSQL + "and l.LEDGER_STATUS=0 ";
            strSQL = strSQL + "and l.LEDGER_GROUP = " + (int)Utility.GR_GROUP_TYPE.grCUSTOMER + " ";
            if (strCode != "")
            {
                strSQL = strSQL + "WHERE l.TERITORRY_CODE='" + strCode + "' ";
            }
            strSQL = strSQL + "ORDER BY l.TERITORRY_CODE ";

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
                    Teritorry ovector = new Teritorry();
                    ovector.strTeritorrycode = dr["TERITORRY_CODE"].ToString() + "~" + dr["TERRITORRY_NAME"].ToString() + "~" + dr["LEDGER_NAME"].ToString();
                    // ovector.strTeritorryName = dr["TERITORRY_NAME"].ToString();
                    ooVector.Add(ovector);
                }
                return ooVector;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<Teritorry> mFillTeritorry(string strDeComID, string strCode)
        {

            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<Teritorry> ooVector = new List<Teritorry>();
            strSQL = "SELECT TERITORRY_CODE,TERITORRY_NAME FROM ACC_TERITORRY ";
            if (strCode != "")
            {
                strSQL = strSQL + "WHERE TERITORRY_CODE='" + strCode + "' ";
            }
            strSQL = strSQL + "ORDER BY TERITORRY_CODE ";

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
                    Teritorry ovector = new Teritorry();
                    ovector.strTeritorrycode = dr["TERITORRY_CODE"].ToString();
                    ovector.strTeritorryName = dr["TERITORRY_NAME"].ToString();
                    ovector.strTeritorryMerze = dr["TERITORRY_CODE"].ToString() + dr["TERITORRY_NAME"].ToString();
                    ooVector.Add(ovector);
                }
                return ooVector;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }

        #endregion
        #region "Groups"
        public List<AccountsLedger> gLoadLegderPrivilegesRight(string strDeComID, string strUserName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> oogrp = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
           
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "SELECT LEDGER_NAME FROM USER_PRIVILEGES_LEDGER ";
                strSQL = strSQL + " WHERE USER_LOGIN_NAME='" + strUserName + "' ";
                strSQL = strSQL + "ORDER BY LEDGER_NAME";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<AccountdGroup> mFillGroupSales(string strDeComID, int mlngLedgerAs)
        {
            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader drGetGroup;
            List<AccountdGroup> oogrp = new List<AccountdGroup>();

            strSQL = "SELECT GR_NAME,GR_PRIMARY_TYPE FROM ACC_LEDGERGROUP ";
            strSQL += " WHERE GR_GROUP = " + mlngLedgerAs + " ";
            strSQL += " AND GR_LEVEL = 5 ";
            strSQL += "ORDER BY GR_NAME ASC";

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
                    AccountdGroup ogrp = new AccountdGroup();
                    ogrp.GroupName = drGetGroup["GR_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<AccountdGroup> mFillGroup(string strDeComID, int mlngLedgerAs)
        {
            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader drGetGroup;
            List<AccountdGroup> oogrp = new List<AccountdGroup>();

            strSQL = "SELECT GR_NAME,GR_PRIMARY_TYPE FROM ACC_LEDGERGROUP ";
            if (mlngLedgerAs > 0)
            {
                strSQL += " WHERE GR_GROUP = " + mlngLedgerAs + " ";
            }
            else
            {
                strSQL += " WHERE GR_GROUP not in(202,203,204)";
            }
            strSQL += "ORDER BY GR_NAME ASC";

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
                    AccountdGroup ogrp = new AccountdGroup();
                    ogrp.GroupName = drGetGroup["GR_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public List<AccountdGroup> mFillSecurityGroup(string strDeComID)
        {
            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader drGetGroup;
            List<AccountdGroup> oogrp = new List<AccountdGroup>();

            strSQL = "SELECT ACC_LEDGERGROUP.GR_NAME ";
            strSQL = strSQL + "FROM  ACC_LEDGERGROUP INNER JOIN ";
            strSQL = strSQL + " ACC_LEDGER ON ACC_LEDGERGROUP.GR_NAME = ACC_LEDGER.LEDGER_PARENT_GROUP ";
            strSQL = strSQL + "GROUP BY ACC_LEDGERGROUP.GR_NAME ";
            strSQL += "ORDER BY ACC_LEDGERGROUP.GR_NAME ASC";

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
                    AccountdGroup ogrp = new AccountdGroup();
                    ogrp.GroupName = drGetGroup["GR_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<AccountdGroup> GetAccountsGroup(string strDeComID)
        {
            SqlDataReader rdr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountdGroup> ooAccGrop = new List<AccountdGroup>();
            strSQL = "SELECT GR_NAME,GR_PRIMARY_TYPE FROM ACC_LEDGERGROUP ";
            strSQL = strSQL + "WHERE GR_GROUP NOT IN (203,202) ";
            strSQL = strSQL + " ORDER BY GR_NAME ";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                    if (rdr["GR_NAME"].ToString() != "")
                    {
                        ogrp.GroupName = rdr["GR_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.GroupName = "";
                    }

                    ooAccGrop.Add(ogrp);
                }
                rdr.Close();
                return ooAccGrop;
            }

        }
        public List<AccountdGroup> GetAccountsTreeview(string strDeComID)
        {
            SqlDataReader rdr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountdGroup> ooAccGrop = new List<AccountdGroup>();
            strSQL = "SELECT GR_NAME,GR_PARENT FROM ACC_LEDGERGROUP ORDER BY GR_LEVEL,GR_SERIAL ";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                    if (rdr["GR_NAME"].ToString() != "")
                    {
                        ogrp.GroupName = rdr["GR_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.GroupName = "";
                    }
                    if (rdr["GR_PARENT"].ToString() != "")
                    {
                        ogrp.ParentName = rdr["GR_PARENT"].ToString();
                    }
                    else
                    {
                        ogrp.ParentName = "";
                    }

                    ooAccGrop.Add(ogrp);
                }
                rdr.Close();
                return ooAccGrop;
            }

        }
        public List<AccountdGroup> GetAccountsTreeviewCR(string strDeComID)
        {
            SqlDataReader rdr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountdGroup> ooAccGrop = new List<AccountdGroup>();
            strSQL = "SELECT GR_NAME,GR_PARENT FROM ACC_LEDGERGROUP ";
            strSQL = strSQL + "WHERE GR_GROUP  =203 ";
            strSQL = strSQL + "AND  GR_DEFAULT_GROUP  <> 1 ";
            strSQL = strSQL + "ORDER BY GR_LEVEL,GR_SERIAL ";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                    if (rdr["GR_NAME"].ToString() != "")
                    {
                        ogrp.GroupName = rdr["GR_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.GroupName = "";
                    }
                    if (rdr["GR_PARENT"].ToString() != "")
                    {
                        ogrp.ParentName = rdr["GR_PARENT"].ToString();
                    }
                    else
                    {
                        ogrp.ParentName = "";
                    }

                    ooAccGrop.Add(ogrp);
                }
                rdr.Close();
                return ooAccGrop;
            }

        }
        public List<AccountdGroup> GetAccountsTreeviewDR(string strDeComID)
        {
            SqlDataReader rdr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountdGroup> ooAccGrop = new List<AccountdGroup>();
            strSQL = "SELECT GR_NAME,GR_PARENT FROM ACC_LEDGERGROUP ";
            strSQL = strSQL + "WHERE GR_GROUP  =202 ";
            strSQL = strSQL + "AND  GR_DEFAULT_GROUP  <> 1 ";
            strSQL = strSQL + "ORDER BY GR_LEVEL,GR_SERIAL ";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                    if (rdr["GR_NAME"].ToString() != "")
                    {
                        ogrp.GroupName = rdr["GR_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.GroupName = "";
                    }
                    if (rdr["GR_PARENT"].ToString() != "")
                    {
                        ogrp.ParentName = rdr["GR_PARENT"].ToString();
                    }
                    else
                    {
                        ogrp.ParentName = "";
                    }

                    ooAccGrop.Add(ogrp);
                }
                rdr.Close();
                return ooAccGrop;
            }

        }
        public List<AccountdGroup> GetDsmRsm_level4(string strDeComID)
        {
            SqlDataReader rdr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountdGroup> ooAccGrop = new List<AccountdGroup>();
            strSQL = "SELECT GR_NAME,GR_PARENT FROM ACC_LEDGERGROUP ";
            strSQL = strSQL + "WHERE GR_GROUP  =202 ";
            strSQL = strSQL + "AND  GR_DEFAULT_GROUP  <> 1 and GR_LEVEL =4 ";
            strSQL = strSQL + "ORDER BY GR_LEVEL,GR_SERIAL ";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                    if (rdr["GR_NAME"].ToString() != "")
                    {
                        ogrp.GroupName = rdr["GR_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.GroupName = "";
                    }
                    if (rdr["GR_PARENT"].ToString() != "")
                    {
                        ogrp.ParentName = rdr["GR_PARENT"].ToString();
                    }
                    else
                    {
                        ogrp.ParentName = "";
                    }

                    ooAccGrop.Add(ogrp);
                }
                rdr.Close();
                return ooAccGrop;
            }

        }
        public string GetPFLegder(string strComId,string strLedgerName)
        {
            string strSQL = "", strString = "";
            SqlDataReader rdr;
            connstring = Utility.SQLConnstringComSwitch(strComId);
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                strSQL = "select s.PF_LEDGER_NAME from ACC_LEDGER s ";
                strSQL = strSQL + "WHERE s.LEDGER_NAME='" + strLedgerName + "' ";
                strSQL = strSQL + "AND s.PF_LEDGER_NAME IS NOT NULL ";
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                   
                    if (rdr["PF_LEDGER_NAME"].ToString() != "")
                    {
                       strString= rdr["PF_LEDGER_NAME"].ToString();
                    }
                    else
                    {
                        strString= "";
                    }
                }
                rdr.Close();
                return strString;
            }
        }
        public string GetHLLegder(string strComId, string strLedgerName)
        {
            string strSQL = "", strString = "";
            SqlDataReader rdr;
            connstring = Utility.SQLConnstringComSwitch(strComId);
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                strSQL = "select s.HL_LEDGER_NAME from ACC_LEDGER s ";
                strSQL = strSQL + "WHERE s.LEDGER_NAME='" + strLedgerName + "' ";
                strSQL = strSQL + "AND s.HL_LEDGER_NAME IS NOT NULL ";
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    if (rdr["HL_LEDGER_NAME"].ToString() != "")
                    {
                        strString = rdr["HL_LEDGER_NAME"].ToString();
                    }
                    else
                    {
                        strString = "";
                    }
                }
                rdr.Close();
                return strString;
            }
        }
        public List<AccountsLedger> GetCustomerLedger(string strDeComID)
        {
            SqlDataReader rdr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooAccGrop = new List<AccountsLedger>();
            //strSQL = "SELECT DISTINCT  (l.TERITORRY_CODE  + '-' + s.MRR_NO + '-' + l.TERRITORRY_NAME) AS grname, s.MRR_NO  from INV_SALESREPSENTIVE s,ACC_LEDGER l where l.LEDGER_NAME =s.LEDGER_NAME   ";
            strSQL = "SELECT LEDGER_NAME,LEDGER_NAME_MERZE   from ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_GROUP=202 ";
            strSQL = strSQL + "AND (LEDGER_STATUS =0 or HALT_MPO =1) ";
            strSQL = strSQL + "AND (PF_LEDGER_NAME IS NOT NULL or HL_LEDGER_NAME IS NOT NULL) ";
            strSQL = strSQL + "ORDER BY LEDGER_NAME_MERZE ";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AccountsLedger ogrp = new AccountsLedger();
                    if (rdr["LEDGER_NAME_MERZE"].ToString() != "")
                    {
                        ogrp.strParentGroup = rdr["LEDGER_NAME_MERZE"].ToString();
                    }
                    ogrp.strRepName = rdr["LEDGER_NAME"].ToString();
                    ooAccGrop.Add(ogrp);
                }
                rdr.Close();
                return ooAccGrop;
            }

        }
        public List<AccountsLedger> GetSalesLedgerTree(string strDeComID)
        {
            SqlDataReader rdr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooAccGrop = new List<AccountsLedger>();
            //strSQL = "SELECT DISTINCT  (l.TERITORRY_CODE  + '-' + s.MRR_NO + '-' + l.TERRITORRY_NAME) AS grname, s.MRR_NO  from INV_SALESREPSENTIVE s,ACC_LEDGER l where l.LEDGER_NAME =s.LEDGER_NAME   ";
            strSQL = "SELECT LEDGER_NAME,LEDGER_NAME_MERZE   from ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_GROUP=202 ";
            strSQL = strSQL + "ORDER BY LEDGER_NAME_MERZE ";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AccountsLedger ogrp = new AccountsLedger();
                    if (rdr["LEDGER_NAME_MERZE"].ToString() != "")
                    {
                        ogrp.strParentGroup = rdr["LEDGER_NAME_MERZE"].ToString();
                    }
                    ogrp.strRepName = rdr["LEDGER_NAME"].ToString();
                    ooAccGrop.Add(ogrp);
                }
                rdr.Close();
                return ooAccGrop;
            }

        }
        public List<AccountsLedger> GetSalesLedgerTreefromCustomer(string strDeComID, string strLedgerName)
        {
            SqlDataReader rdr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooAccGrop = new List<AccountsLedger>();
            //strSQL = "select ( l.LEDGER_CODE + '-' + s.LEDGER_NAME + '-' + l.HOMOEO_HALL )  as LEDGER_NAME from INV_SALESREPSENTIVE s,ACC_LEDGER l where s.LEDGER_NAME=l.LEDGER_NAME ";
            //strSQL = strSQL + "AND s.MRR_NO='" + strLedgerName + "' ";

            strSQL = "select l.LEDGER_NAME_MERZE   from INV_SALESREPSENTIVE s,ACC_LEDGER l where s.LEDGER_NAME=l.LEDGER_NAME ";
            strSQL = strSQL + "AND s.MRR_NO='" + strLedgerName + "' ";
          
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AccountsLedger ogrp = new AccountsLedger();
                    if (rdr["LEDGER_NAME_MERZE"].ToString() != "")
                    {
                        ogrp.strLedgerName = rdr["LEDGER_NAME_MERZE"].ToString();
                    }

                    ooAccGrop.Add(ogrp);
                }
                rdr.Close();
                return ooAccGrop;
            }

        }
       
      
        public List<AccountsLedger> mFillLedgerNew(string strDeComID, long vlngGroup)
        {

            SqlDataReader dr;
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooAccLed = new List<AccountsLedger>();
            if (vlngGroup == 2)
            {
                strSQL = "SELECT GR_NAME as LEDGER_NAME,'' LEDGER_NAME_MERZE FROM ACC_LEDGERGROUP ORDER BY GR_NAME";
            }
            else
            {
                strSQL = "SELECT LEDGER_NAME,LEDGER_NAME_MERZE FROM ACC_LEDGER ";
                strSQL = strSQL + "WHERE LEDGER_GROUP = " + vlngGroup + " ";
                strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
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
                    AccountsLedger oaccLed = new AccountsLedger();
                    oaccLed.strLedgerName = dr["LEDGER_NAME"].ToString();
                    if (dr["LEDGER_NAME_MERZE"].ToString() != "")
                    {
                        oaccLed.strmerzeString = dr["LEDGER_NAME_MERZE"].ToString();
                    }
                    else
                    {
                        oaccLed.strmerzeString = "";
                    }
                    ooAccLed.Add(oaccLed);
                }
                dr.Close();
                return ooAccLed;
            }

        }
        public List<AccountsLedger> mFillLedgerStatus(string strDeComID, long vlngGroup, int intStatus)
        {

            SqlDataReader dr;
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooAccLed = new List<AccountsLedger>();

            strSQL = "SELECT LEDGER_NAME,LEDGER_NAME_MERZE FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_GROUP = " + vlngGroup + " ";
            strSQL = strSQL + "AND LEDGER_STATUS = " + intStatus + " ";

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
                    AccountsLedger oaccLed = new AccountsLedger();
                    oaccLed.strLedgerName = dr["LEDGER_NAME"].ToString();
                    if (dr["LEDGER_NAME_MERZE"].ToString() != "")
                    {
                        oaccLed.strmerzeString = dr["LEDGER_NAME_MERZE"].ToString();
                    }
                    else
                    {
                        oaccLed.strmerzeString = "";
                    }
                    ooAccLed.Add(oaccLed);
                }
                dr.Close();
                return ooAccLed;
            }

        }
        public List<AccountsLedger> mFillPFLedger(string strDeComID, long vlngGroup)
        {

            SqlDataReader dr;
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooAccLed = new List<AccountsLedger>();

            strSQL = "SELECT LEDGER_NAME,LEDGER_NAME_MERZE FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_GROUP = " + vlngGroup + " ";
            strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
            strSQL = strSQL + "AND LEDGER_NAME like '%PF%' ";

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
                    AccountsLedger oaccLed = new AccountsLedger();
                    oaccLed.strLedgerName = dr["LEDGER_NAME"].ToString();
                    if (dr["LEDGER_NAME_MERZE"].ToString() != "")
                    {
                        oaccLed.strmerzeString = dr["LEDGER_NAME_MERZE"].ToString();
                    }
                    else
                    {
                        oaccLed.strmerzeString = "";
                    }
                    ooAccLed.Add(oaccLed);
                }
                dr.Close();
                return ooAccLed;
            }

        }
        public List<AccountsLedger> mFillHLLedger(string strDeComID, long vlngGroup, int intStatus)
        {

            SqlDataReader dr;
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooAccLed = new List<AccountsLedger>();

            strSQL = "SELECT LEDGER_NAME,LEDGER_NAME_MERZE FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_GROUP = " + vlngGroup + " ";
            strSQL = strSQL + "AND LEDGER_STATUS = " + intStatus + " ";
            strSQL = strSQL + "AND LEDGER_NAME like 'HL%' ";

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
                    AccountsLedger oaccLed = new AccountsLedger();
                    oaccLed.strLedgerName = dr["LEDGER_NAME"].ToString();
                    if (dr["LEDGER_NAME_MERZE"].ToString() != "")
                    {
                        oaccLed.strmerzeString = dr["LEDGER_NAME_MERZE"].ToString();
                    }
                    else
                    {
                        oaccLed.strmerzeString = "";
                    }
                    ooAccLed.Add(oaccLed);
                }
                dr.Close();
                return ooAccLed;
            }

        }
        public List<AccountsLedger> mLedgerAdditemMr(string strDeComID, string vstrRoot,int intstatus)
        {

            SqlDataReader dr;
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooAccLed = new List<AccountsLedger>();

            if (vstrRoot != "" && vstrRoot != "1")
            {
                strSQL = "SELECT LEDGER_NAME,LEDGER_NAME_MERZE FROM ACC_LEDGER ";
                strSQL = strSQL + "WHERE LEDGER_PARENT_GROUP = '" + vstrRoot.Replace("'", "''") + "' ";
                if (intstatus == 3)
                {
                    strSQL = strSQL + "AND LEDGER_STATUS in(0,1)";
                }
                else
                {
                    strSQL = strSQL + "AND LEDGER_STATUS = " + intstatus + " ";
                }
                strSQL = strSQL + " ORDER by LEDGER_NAME_MERZE ";
            }
            else if (vstrRoot == "1")
            {
                strSQL = "SELECT LEDGER_NAME,LEDGER_NAME_MERZE FROM ACC_LEDGER ";
                strSQL = strSQL + "WHERE LEDGER_STATUS = 0 ";
                strSQL = strSQL + "AND LEDGER_GROUP > 101 ";
                strSQL = strSQL + " ORDER by LEDGER_NAME_MERZE ";
            }

            else
            {
                strSQL = "SELECT LEDGER_NAME,LEDGER_NAME_MERZE FROM ACC_LEDGER ";
                strSQL = strSQL + "WHERE LEDGER_STATUS = 0 ";
                strSQL = strSQL + " ORDER by LEDGER_NAME_MERZE ";
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
                    AccountsLedger oaccLed = new AccountsLedger();
                    oaccLed.strmerzeString  = dr["LEDGER_NAME_MERZE"].ToString();
                    oaccLed.strLedgerName = dr["LEDGER_NAME"].ToString();
                    ooAccLed.Add(oaccLed);
                }
                dr.Close();
                return ooAccLed;
            }

        }
        public List<AccountsLedger> mLedgerSecurity(string strDeComID, string vstrRoot,string vstrUserName)
        {

            SqlDataReader dr;
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooAccLed = new List<AccountsLedger>();


            strSQL = "SELECT LEDGER_NAME,LEDGER_NAME_MERZE FROM ACC_LEDGER ";
            if (vstrRoot != "All")
            {
                strSQL = strSQL + "WHERE LEDGER_PARENT_GROUP = '" + vstrRoot.Replace("'", "''") + "' ";
                strSQL = strSQL + "AND LEDGER_GROUP not in (204)";
                strSQL = strSQL + "and LEDGER_NAME not in(select LEDGER_NAME from USER_PRIVILEGES_LEDGER WHERE USER_LOGIN_NAME='" + vstrUserName + "') ";
            }
            else
            {
                strSQL = strSQL + "WHERE LEDGER_NAME not in(select LEDGER_NAME from USER_PRIVILEGES_LEDGER WHERE USER_LOGIN_NAME='" + vstrUserName + "') ";
                strSQL = strSQL + "AND LEDGER_GROUP not in (204) ";
            }

            strSQL = strSQL + " ORDER by LEDGER_NAME_MERZE ";

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
                    AccountsLedger oaccLed = new AccountsLedger();
                    oaccLed.strmerzeString = dr["LEDGER_NAME_MERZE"].ToString();
                    oaccLed.strLedgerName = dr["LEDGER_NAME"].ToString();
                    ooAccLed.Add(oaccLed);
                }
                dr.Close();
                return ooAccLed;
            }

        }

        public List<AccountsLedger> mLedgerAdditem(string strDeComID, string vstrRoot,int intstatus)
        {

            SqlDataReader dr;
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooAccLed = new List<AccountsLedger>();

            if (vstrRoot != "")
            {
                strSQL = "SELECT LEDGER_NAME_MERZE as LEDGER_NAME  FROM ACC_LEDGER ";
                strSQL = strSQL + "WHERE LEDGER_PARENT_GROUP = '" + vstrRoot.Replace("'", "''") + "' ";
                strSQL = strSQL + "AND LEDGER_STATUS =" + intstatus + " ";
            }
            else
            {
                strSQL = "SELECT LEDGER_NAME_MERZE as LEDGER_NAME FROM ACC_LEDGER ";
                strSQL = strSQL + "AND LEDGER_STATUS =" + intstatus + " ";
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
                    AccountsLedger oaccLed = new AccountsLedger();
                    oaccLed.strLedgerName = dr["LEDGER_NAME"].ToString();
                    ooAccLed.Add(oaccLed);
                }
                dr.Close();
                return ooAccLed;
            }

        }
        public short InsertGroup(string strDeComID, string strGroupName, string strUnder, string strCashflowType, string strAccountType,
                                    string strMobileNo,string strContactNo,int intPosition)
        {
            long lngGroup = 0, lngGroupLavel = 0, lngType = 0, lngCashFlowType = 0, mlngAccounTtype = 0, lngManuFacType = 0;
            string strGroup, strPrimary, strParent, strOneDown, strSQL;
            Boolean blnInsert = false;
            SqlDataReader dr;

            
            strGroup = strGroupName.Trim().Replace("'", "''");
            if (strCashflowType == "Operating Activities")
            {
                lngCashFlowType = 1;
            }
            else if (strCashflowType == "Investing Activities")
            {
                lngCashFlowType = 2;
            }
            else if (strCashflowType == "Financing Activities")
            {
                lngCashFlowType = 3;
            }
            else
            {
                lngCashFlowType = 4;
            }
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

                strParent = strUnder.Replace("'", "''");
                strSQL = "SELECT GR_PRIMARY,GR_GROUP,GR_LEVEL,GR_PRIMARY,GR_PRIMARY_TYPE,";
                strSQL = strSQL + "GR_ONE_DOWN,GR_CASH_FLOW_TYPE,GR_MANUFAC_GROUP FROM ACC_LEDGERGROUP ";
                strSQL = strSQL + "WHERE GR_NAME = '" + strParent + "' ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    lngGroup = long.Parse(dr["GR_GROUP"].ToString());
                    lngGroupLavel = long.Parse(dr["GR_LEVEL"].ToString()) + 1;
                    lngCashFlowType = long.Parse(dr["GR_CASH_FLOW_TYPE"].ToString());
                    lngManuFacType = long.Parse(dr["GR_MANUFAC_GROUP"].ToString());
                    mlngAccounTtype = long.Parse(dr["GR_PRIMARY_TYPE"].ToString());
                    strPrimary = dr["GR_PRIMARY"].ToString().Replace("'", "''");
                    if (dr["GR_PRIMARY"].ToString() == strParent)
                    {
                        strOneDown = strGroup;
                    }
                    else
                    {
                        //strOneDown = strUnder;
                        strOneDown = dr["GR_ONE_DOWN"].ToString().Replace("'", "''");
                    }
                }
                else
                {
                    lngGroup = 0;
                    lngGroupLavel = 0;
                    lngCashFlowType = 0;
                    lngManuFacType = 0;
                    strOneDown = string.Empty;
                    strPrimary = string.Empty;

                }
                dr.Close();
                if (strParent.ToUpper().ToString() == "PRIMARY")
                {
                    strParent = strAccountType;
                    strPrimary = strGroup;
                    lngGroupLavel = (long)Utility.GROUP_TYPE.gtMAIN_GROUP;
                    strOneDown = strGroup;
                }

                if (lngGroup ==0)
                {
                    lngGroup = (long)Utility.GR_GROUP_TYPE.grOTHER_LEDGER;
                }

                if (lngGroup == (long)Utility.GR_GROUP_TYPE.grCash)
                {
                    lngCashFlowType = 0;
                }
                else if (lngGroup == (long)Utility.GR_GROUP_TYPE.grBANKACCOUNTS)
                {
                    lngCashFlowType = 0;
                }

                strSQL = "INSERT INTO ACC_LEDGERGROUP";
                strSQL = strSQL + "(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,";
                strSQL = strSQL + "GR_GROUP,GR_PRIMARY_TYPE,GR_CASH_FLOW_TYPE,GR_MANUFAC_GROUP ";
                strSQL = strSQL + ",GR_MOBILE_NO";
                strSQL = strSQL + ",GR_CONTACT_NO";
                strSQL =strSQL + ",GR_PARENT_POSITION ";
                strSQL = strSQL + ")";
                strSQL = strSQL + "VALUES(";
                strSQL = strSQL + "'" + strGroup + "','" + strParent + "','" + strOneDown + "',";
                strSQL = strSQL + "'" + strPrimary + "'," + lngGroupLavel + "," + lngGroup + "," + mlngAccounTtype + ",";
                strSQL = strSQL + lngCashFlowType + "," + lngManuFacType + "";
                if (strMobileNo != "")
                {
                    strSQL = strSQL + ",'" + strMobileNo.Trim().Replace("'", "''") + "' ";
                }
                else
                {
                    strSQL = strSQL + ",Null";
                }
                if (strContactNo != "")
                {
                    strSQL = strSQL + ",'" + strContactNo.Trim().Replace("'", "''") + "' ";
                }
                else
                {
                    strSQL = strSQL + ",Null";
                }
                strSQL = strSQL + "," + intPosition +  " )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                do
                {
                    if (lngGroupLavel == 1)
                    {
                        blnInsert = true;
                    }
                    strSQL = "SELECT GR_PARENT,GR_LEVEL FROM ACC_LEDGERGROUP ";
                    strSQL = strSQL + "WHERE GR_NAME ='" + strGroup + "' ";
                    SqlDataReader dr1;
                    cmdInsert.CommandText = strSQL;
                    dr1 = cmdInsert.ExecuteReader();
                    if (dr1.Read())
                    {
                        strParent = dr1["GR_PARENT"].ToString().Replace("'", "''");
                        //lngGroupLavel = (long)dr1["GR_LEVEL"];
                        lngGroupLavel = long.Parse(dr1["GR_LEVEL"].ToString());
                    }
                    dr1.Close();
                    if (blnInsert == false)
                    {
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES(";
                        strSQL = strSQL + "'" + strParent + "','" + strGroup + "'";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        if (strAccountType != "")
                        {
                            lngType = 1;
                            blnInsert = true;
                        }

                        strGroup = strParent;
                    }
                }

                while (blnInsert = false);

                cmdInsert.Transaction.Commit();
                return 1;
            }


        }
        public short mUpdateGroup(string strDeComID, long mlngGroupSerial, string strGroupName, string strUnder, string strCashflowType,
                                    string strAccountType, string strMobileNo, string strConatctNo, int intPosition)
        {
            Boolean blnUnderChange;
            long lngGroupLevel = 0, lngType, lngGroup, lngCashFlowType, lngDefaultGroup, lngOldLevel, lngNewLevel, lngManuFacType, lngAffectGP, lngSequences;
            double dblOpeningDebit, dblOpeningCredit;
            string strSQL, strOldLedgerUnder, strOneDown = "", strParent, strOldParent, strNewParent, strPrimary, strOldLedgerGroup, strOldLedgerGroup1;
            Boolean blnInsert = false;
            int mlngAccounTtype = 0;

            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {

                strGroupName = strGroupName.Trim().Replace("'", "''");
                strParent = strUnder.Trim().Replace("'", "''");
                strNewParent = strParent;
                strPrimary = Utility.GetEndGroup(strDeComID,strParent);
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();


                strSQL = "SELECT GR_NAME,GR_PARENT,GR_GROUP,GR_DEFAULT_GROUP,GR_OPENING_DEBIT,GR_LEVEL,GR_MANUFAC_GROUP,GR_OPENING_CREDIT FROM ACC_LEDGERGROUP ";
                strSQL = strSQL + "WHERE GR_SERIAL = " + mlngGroupSerial + " ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strOldLedgerGroup = dr["GR_NAME"].ToString().Replace("'", "''");
                    strOldLedgerGroup1 = strOldLedgerGroup;
                    strOldLedgerUnder = dr["GR_PARENT"].ToString();
                    lngGroup = long.Parse(dr["GR_GROUP"].ToString());
                    lngDefaultGroup = long.Parse(dr["GR_DEFAULT_GROUP"].ToString());

                    dblOpeningDebit = double.Parse(dr["GR_OPENING_DEBIT"].ToString());
                    dblOpeningCredit = double.Parse(dr["GR_OPENING_CREDIT"].ToString());
                    lngOldLevel = long.Parse(dr["GR_LEVEL"].ToString());
                }
                else
                {
                    strOldLedgerGroup = string.Empty;
                    strOldLedgerGroup1 = string.Empty;
                    strOldLedgerUnder = string.Empty;
                    lngGroup = 0;
                    lngDefaultGroup = 0;
                    dblOpeningDebit = 0;
                    dblOpeningCredit = 0;
                    lngOldLevel = 0;
                }
                dr.Close();

                do
                {
                    if (lngOldLevel == 1)
                    {
                        blnInsert = true;
                    }
                    else
                    {
                        blnInsert = false;
                    }
                    strSQL = "SELECT GR_PARENT,GR_LEVEL FROM ACC_LEDGERGROUP ";
                    strSQL = strSQL + "WHERE GR_NAME ='" + strOldLedgerGroup + "' ";
                    SqlDataReader dr1;
                    SqlCommand cmd1 = new SqlCommand(strSQL, gcnMain);
                    dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        strOldParent = dr1["GR_PARENT"].ToString().Replace("'", "''");
                        //lngGroupLavel = (long)dr1["GR_LEVEL"];
                        lngOldLevel = long.Parse(dr1["GR_LEVEL"].ToString());
                    }
                    else
                    {
                        strOldParent = string.Empty;
                        lngOldLevel = 0;
                    }
                    dr1.Close();
                    if (blnInsert == false)
                    {

                        strSQL = "UPDATE ACC_LEDGERGROUP SET GR_OPENING_DEBIT =  GR_OPENING_DEBIT - " + dblOpeningDebit + ",";
                        strSQL = strSQL + "GR_OPENING_CREDIT =  GR_OPENING_CREDIT - " + dblOpeningCredit + " ";
                        strSQL = strSQL + "WHERE GR_NAME = '" + strOldParent + "'";
                        SqlCommand cmd2 = new SqlCommand(strSQL, gcnMain);
                        cmd2.ExecuteNonQuery();
                        strOldLedgerGroup = strOldParent;
                        blnInsert = true;

                    }
                }

                while (blnInsert == false);
                blnInsert = false;
                if (strOldLedgerUnder.Trim() != strUnder.Trim())
                {
                    blnUnderChange = true;
                }
                else
                {
                    blnUnderChange = false;
                }
                if (strCashflowType == "Operating Activities")
                {
                    lngCashFlowType = 1;
                }
                else if (strCashflowType == "Investing Activities")
                {
                    lngCashFlowType = 2;
                }
                else if (strCashflowType == "Financing Activities")
                {
                    lngCashFlowType = 3;
                }
                else
                {
                    lngCashFlowType = 4;
                }
                strSQL = "SELECT GR_PRIMARY,GR_GROUP,GR_LEVEL,GR_PRIMARY_TYPE,GR_ONE_DOWN,GR_CASH_FLOW_TYPE,GR_MANUFAC_GROUP FROM ACC_LEDGERGROUP ";
                strSQL = strSQL + "WHERE GR_NAME = '" + strParent + "' ";
                SqlCommand cmd3 = new SqlCommand(strSQL, gcnMain);
                dr = cmd3.ExecuteReader();
                if (dr.Read())
                {
                    if (lngDefaultGroup == 0)
                    {
                        lngGroup = long.Parse(dr["GR_GROUP"].ToString());
                    }
                    if (lngGroup == 0)
                    {
                        lngGroup = (long)(Utility.GR_GROUP_TYPE.grOTHER_LEDGER);
                    }
                    lngGroupLevel = long.Parse(dr["GR_LEVEL"].ToString()) + 1;
                    lngCashFlowType = int.Parse(dr["GR_CASH_FLOW_TYPE"].ToString());
                    mlngAccounTtype = int.Parse(dr["GR_PRIMARY_TYPE"].ToString());
                    lngManuFacType = int.Parse(dr["GR_MANUFAC_GROUP"].ToString());
                    //strPrimary = dr["GR_PRIMARY"].ToString().Replace("'", "''");

                    if (dr["GR_PRIMARY"].ToString() == strParent)
                    {
                        strOneDown = strGroupName;
                    }
                    else
                    {
                        strOneDown = dr["GR_ONE_DOWN"].ToString().Replace("'", "''");
                    }
                }
                dr.Close();
                if (strParent.ToUpper() == "PRIMARY")
                {
                    strParent = strAccountType;
                    if (strAccountType.Trim().ToUpper() == "ASSETS")
                    {
                        mlngAccounTtype = 1;
                    }
                    else if (strAccountType.Trim().ToUpper() == "LIABILITIES")
                    {
                        mlngAccounTtype = 2;
                    }
                    else if (strAccountType.Trim().ToUpper() == "INCOME")
                    {
                        mlngAccounTtype = 3;
                    }
                    else if (strAccountType.Trim().ToUpper() == "EXPENSES")
                    {
                        mlngAccounTtype = 4;
                    }
                }

                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                //strPrimary = strGroupName;
                // lngGroupLevel = (long)(Utility.GROUP_TYPE.gtMAIN_GROUP);
                //strOneDown = strGroupName;
                strSQL = "DELETE FROM ACC_GROUP_TO_LEDGER WHERE GR_NAME = '" + strOldLedgerGroup + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                lngNewLevel = lngGroupLevel;
                strSQL = "UPDATE ACC_LEDGERGROUP SET GR_NAME = '" + strGroupName + "', ";
                strSQL = strSQL + "GR_PARENT = '" + strParent + "',";
                //if (lngGroupLevel == 1)
                //{
                //    strSQL = strSQL + "GR_SEQUENCES = " + lngSequences + ",";
                //}
                strSQL = strSQL + "GR_PRIMARY = '" + strPrimary + "',";
                strSQL = strSQL + "GR_ONE_DOWN = '" + strOneDown + "', ";
                strSQL = strSQL + "GR_PRIMARY_TYPE = " + mlngAccounTtype + ",";
                strSQL = strSQL + "GR_LEVEL = " + lngGroupLevel + ",";
                strSQL = strSQL + "GR_CASH_FLOW_TYPE = " + lngCashFlowType + ", ";
                // strSQL = strSQL + "GR_MANUFAC_GROUP = " + lngManuFacType + ", ";
                // strSQL = strSQL + "GR_AFFECT_GP = " + lngAffectGP + ",";
                strSQL = strSQL + "GR_GROUP = " + lngGroup + " ";
                strSQL = strSQL + ",GR_MOBILE_NO ='" + strMobileNo.Trim().Replace("'", "''") + "' ";
                strSQL = strSQL + ",GR_CONTACT_NO ='" + strConatctNo.Trim().Replace("'", "''") + "' ";
                strSQL = strSQL + ",GR_PARENT_POSITION =" + intPosition + " ";
                strSQL = strSQL + "WHERE GR_SERIAL = " + mlngGroupSerial + " ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE ACC_LEDGERGROUP SET GR_PARENT = '" + strGroupName + "' ";
                strSQL = strSQL + "WHERE GR_PARENT = '" + strOldLedgerGroup1 + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "UPDATE ACC_LEDGERGROUP SET GR_ONE_DOWN = '" + strGroupName + "' ";
                strSQL = strSQL + "WHERE GR_ONE_DOWN = '" + strOldLedgerGroup1 + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "UPDATE ACC_LEDGERGROUP SET GR_PRIMARY = '" + strGroupName + "' ";
                strSQL = strSQL + "WHERE GR_PRIMARY = '" + strOldLedgerGroup1 + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE USER_ONLILE_SECURITY SET COR_MOBILE_NO = '" + strMobileNo.Trim().Replace("'", "''") + "' ";
                strSQL = strSQL + ",GR_NAME = '" + strGroupName + "' ";
                strSQL = strSQL + "WHERE GR_NAME = '" + strOldLedgerGroup + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "UPDATE ACC_LEDGER SET LEDGER_PRIMARY_GROUP = '" + strGroupName + "' ";
                strSQL = strSQL + "WHERE LEDGER_PRIMARY_GROUP = '" + strOldLedgerGroup1 + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "UPDATE ACC_LEDGER SET LEDGER_PARENT_GROUP = '" + strGroupName + "' ";
                strSQL = strSQL + "WHERE LEDGER_PARENT_GROUP = '" + strOldLedgerGroup1 + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "UPDATE ACC_LEDGER SET LEDGER_ONE_DOWN = '" + strGroupName + "' ";
                strSQL = strSQL + "WHERE LEDGER_ONE_DOWN = '" + strOldLedgerGroup1 + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                //strSQL = "UPDATE S_ACC_LEDGER SET LEDGER_MANUFAC_GROUP = " + lngManuFacType + " ";
                //strSQL = strSQL + "WHERE LEDGER_PARENT_GROUP = '" + strGroupName + "' ";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE ACC_LEDGERGROUP SET GR_CASH_FLOW_TYPE = " + lngCashFlowType + " ";
                strSQL = strSQL + "WHERE GR_PARENT = '" + strGroupName + "' ";
                strSQL = strSQL + "AND GR_CASH_FLOW_TYPE <> 4 ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE ACC_LEDGERGROUP SET GR_PRIMARY = '" + strPrimary + "' ";
                strSQL = strSQL + "WHERE GR_PARENT = '" + strGroupName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE ACC_LEDGER SET LEDGER_CASH_FLOW_TYPE = " + lngCashFlowType + " ";
                strSQL = strSQL + "WHERE LEDGER_PARENT_GROUP = '" + strGroupName + "' ";
                strSQL = strSQL + "AND LEDGER_CASH_FLOW_TYPE <> 4 ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE ACC_LEDGER SET LEDGER_PRIMARY_GROUP = '" + strPrimary + "' ";
                strSQL = strSQL + "WHERE LEDGER_PARENT_GROUP = '" + strGroupName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES(";
                strSQL = strSQL + "'" + strParent + "','" + strGroupName + "'";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //If blnUnderChange Then
                lngGroupLevel = lngGroupLevel + 1;
                //grUpdateNextLevel strGroupName, lngGroupLevel, lngGroup, strPrimary, lngCashFlowType, mlngAccounTtype;


                do
                {
                    if (lngNewLevel == 1)
                    {
                        blnInsert = true;
                    }
                    strSQL = "SELECT GR_PARENT,GR_LEVEL FROM ACC_LEDGERGROUP ";
                    strSQL = strSQL + "WHERE GR_NAME ='" + strGroupName + "' ";
                    SqlDataReader dr1;
                    cmdInsert.CommandText = strSQL;
                    dr1 = cmdInsert.ExecuteReader();
                    if (dr1.Read())
                    {
                        strNewParent = dr1["GR_PARENT"].ToString().Replace("'", "''");
                        //lngGroupLavel = (long)dr1["GR_LEVEL"];
                        lngNewLevel = long.Parse(dr1["GR_LEVEL"].ToString());
                    }
                    else
                    {
                        strNewParent = string.Empty;
                        lngNewLevel = 0;
                    }
                    dr1.Close();
                    if (blnInsert == false)
                    {

                        strSQL = "UPDATE ACC_LEDGERGROUP SET GR_OPENING_DEBIT =  GR_OPENING_DEBIT + " + dblOpeningDebit + ",";
                        strSQL = strSQL + "GR_OPENING_CREDIT =  GR_OPENING_CREDIT + " + dblOpeningCredit + " ";
                        strSQL = strSQL + "WHERE GR_NAME = '" + strNewParent + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strOldLedgerGroup = strOldParent;
                        lngNewLevel = 1;
                    }
                }

                while (blnInsert == false);
                cmdInsert.Transaction.Commit();
                //gcnMain.Close();
                cmdInsert.Dispose();
                gcnMain.Dispose();


                return 1;
            }
        }
        public string DeleteGroup(string strDeComID, long mlngGroupSerial)
        {
            long lngDefaultGroup, lngSerialfNo;
            string strSQL, strGroupName = string.Empty, strResponse = "";
            SqlDataReader rsget;
            lngSerialfNo = mlngGroupSerial;
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

                    strSQL = "SELECT GR_NAME, GR_PARENT, GR_PRIMARY,GR_DEFAULT_GROUP FROM ACC_LEDGERGROUP ";
                    strSQL = strSQL + " WHERE GR_SERIAL = " + lngSerialfNo + " ";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    rsget = cmd.ExecuteReader();
                    if (rsget.Read())
                    {
                        strGroupName = rsget["GR_NAME"].ToString();
                        lngDefaultGroup = long.Parse(rsget["GR_DEFAULT_GROUP"].ToString());
                        if (lngDefaultGroup > 0)
                        {
                            strResponse = ("Default group Can't Delete");
                            return strResponse;
                        }
                    }
                    rsget.Close();
                    strGroupName = strGroupName.Replace("'", "''");
                    strSQL = "SELECT GR_PARENT FROM ACC_LEDGERGROUP WHERE GR_PARENT = '" + strGroupName + "' ";
                    SqlCommand cmd1 = new SqlCommand(strSQL, gcnMain);
                    rsget = cmd1.ExecuteReader();
                    if (rsget.Read())
                    {
                        strResponse = ("There are Group under this group");
                        return strResponse;
                    }
                    else
                    {
                        strResponse = ("Delete Successfull..");

                    }

                    rsget.Close();
                    strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER WHERE LEDGER_PARENT_GROUP = '" + strGroupName + "' ";
                    strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
                    SqlCommand cmd2 = new SqlCommand(strSQL, gcnMain);
                    rsget = cmd2.ExecuteReader();
                    if (rsget.Read())
                    {
                        strResponse = ("There are Ledger under this group");
                        return strResponse;
                    }
                    rsget.Close();

                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    strSQL = "DELETE FROM ACC_GROUP_TO_LEDGER ";
                    strSQL = strSQL + "WHERE GR_NAME = '" + strGroupName + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_LEDGERGROUP ";
                    strSQL = strSQL + "WHERE GR_NAME = '" + strGroupName + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //strSQL = "DELETE FROM USER_PRIVILEGES_COLOR ";
                    //strSQL = strSQL + "WHERE GR_NAME = '" + strGroupName + "'";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    cmdInsert.Dispose();
                    return "1";
                }
                catch (Exception ex)
                {
                    strResponse = ex.ToString();
                    return strResponse;
                }




            }

               
            
           
           

        }
        public List<AccountdGroup> GetGroupList(string strDeComID, long mlngGroupAs, bool vblngAccessControl, string vstrUserName)
        {

            SqlDataReader dr;

            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountdGroup> ooAccGrop = new List<AccountdGroup>();

            if (vblngAccessControl == true)
            {
                strSQL = "SELECT G.GR_SERIAL,G.GR_NAME,G.GR_PARENT,G.GR_DEFAULT_NAME,G.GR_LEVEL,";
                strSQL = strSQL + "G.GR_OPENING_DEBIT,G.GR_OPENING_CREDIT,G.GR_PRIMARY_TYPE,G.GR_CASH_FLOW_TYPE,GR.GR_MOBILE_NO,GR.GR_CONTACT_NO,GR.GR_PARENT_POSITION ";
                strSQL = strSQL + "FROM ACC_LEDGERGROUP G,USER_PRIVILEGES_COLOR C WHERE G.GR_NAME =C.LEDGER_GROUP_NAME ";
                if ((mlngGroupAs == (long)Utility.GR_GROUP_TYPE.grCUSTOMER) || (mlngGroupAs == (long)Utility.GR_GROUP_TYPE.grSUPPLIER))
                {
                    strSQL = strSQL + " AND G.GR_GROUP = " + mlngGroupAs + " ";
                }
                else
                {
                    strSQL = strSQL + " AND G.GR_GROUP not in (202,203)";
                }
                strSQL = strSQL + "AND C.USER_LOGIN_NAME ='" + vstrUserName + "' ";
            }
            else
            {
                strSQL = "SELECT GR_SERIAL,GR_NAME,GR_PARENT,GR_DEFAULT_NAME,GR_LEVEL,";
                strSQL = strSQL + "GR_OPENING_DEBIT,GR_OPENING_CREDIT,GR_PRIMARY_TYPE,GR_CASH_FLOW_TYPE,GR_MOBILE_NO,GR_CONTACT_NO,GR_PARENT_POSITION FROM ACC_LEDGERGROUP ";
                if ((mlngGroupAs == (long)Utility.GR_GROUP_TYPE.grCUSTOMER) || (mlngGroupAs == (long)Utility.GR_GROUP_TYPE.grSUPPLIER))
                {
                    strSQL = strSQL + " WHERE GR_GROUP = " + mlngGroupAs + " ";
                }
                else
                {
                    strSQL = strSQL + " WHERE GR_GROUP not in (202,203)";
                }
                strSQL = strSQL + "ORDER BY GR_NAME ASC ";
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
                    AccountdGroup ogrp = new AccountdGroup();

                    ogrp.lngSlNo = Convert.ToInt64(dr["GR_SERIAL"].ToString());
                    ogrp.intPrimaryType = Convert.ToInt32(dr["GR_PRIMARY_TYPE"].ToString());
                    ogrp.intCashFlowType = Convert.ToInt32(dr["GR_CASH_FLOW_TYPE"].ToString());
                    ogrp.GroupName = dr["GR_NAME"].ToString();
                    ogrp.ParentName = dr["GR_PARENT"].ToString();

                    ogrp.strDefaultGroup = dr["GR_DEFAULT_NAME"].ToString();
                    ogrp.ParentName = dr["GR_PARENT"].ToString();

                    ogrp.dblopeningDr = Math.Abs(Utility.Val(dr["GR_OPENING_DEBIT"].ToString()));
                    ogrp.dblopeningCr = Math.Abs(Utility.Val(dr["GR_OPENING_CREDIT"].ToString()));
                    ogrp.lngGrLevel = Convert.ToInt64(dr["GR_LEVEL"].ToString());
                    if (dr["GR_MOBILE_NO"].ToString() != "")
                    {
                        ogrp.strMobileNo = dr["GR_MOBILE_NO"].ToString();
                    }
                    else
                    {
                        ogrp.strMobileNo = "";
                    }
                    if (dr["GR_CONTACT_NO"].ToString() != "")
                    {
                        ogrp.strContactNo = dr["GR_CONTACT_NO"].ToString();
                    }
                    else
                    {
                        ogrp.strContactNo ="";
                    }
                    if (dr["GR_PARENT_POSITION"].ToString() != "")
                    {
                        ogrp.intMode = Convert.ToInt32(dr["GR_PARENT_POSITION"].ToString());
                    }
                    else
                    {
                        ogrp.intMode = 9999;
                    }

                    ooAccGrop.Add(ogrp);
                }
                dr.Close();
                return ooAccGrop;
            }
        }
        #endregion
        #region "Cost Category"
        public string mInsertTempVector(string strDeComID, string strstring)
        {

            string strresponse = "";
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

                    if (strstring != "")
                    {
                        string[] words = strstring.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split(',');
                            if (oAssets[0] != "")
                            {

                                if (strresponse == "")
                                {
                                    strSQL = "DELETE FROM ACC_VECTOR_TEMP ";
                                    strSQL += " WHERE LEDGER_NAME='" + oAssets[0].ToString() + "' ";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    strresponse = "1";
                                }

                                strSQL = "INSERT INTO ACC_VECTOR_TEMP (";
                                strSQL = strSQL + "LEDGER_NAME,COST_CATEGORY, ";
                                strSQL = strSQL + "COST_CENTER,AMOUNT ";
                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES (";
                                strSQL = strSQL + "'" + oAssets[0].ToString() + "' ,";
                                strSQL = strSQL + "'" + oAssets[1].ToString() + "',";
                                strSQL = strSQL + "'" + oAssets[2].ToString() + "',";
                                strSQL = strSQL + " " + oAssets[3].ToString() + " ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                            }

                        }

                    }



                    cmdInsert.Transaction.Commit();

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
        public string mInsertCostCategory(string strDeComID, string strCostCategory)
        {

            string strresponse = "";
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

                    strSQL = "INSERT INTO VECTOR_CATEGORY(VECTOR_CATEGORY_NAME) VALUES(";
                    strSQL = strSQL + "'" + strCostCategory.Trim().Replace("'", "''") + "') ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    strresponse = "Insert Successfully...";
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
        public string DeleteCostCategory(string strDeComID, string strCostCategory)
        {

            string strresponse = "";
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

                    strSQL = "DELETE FROM VECTOR_CATEGORY WHERE VECTOR_CATEGORY_NAME = '" + strCostCategory.Replace("'", "''") + "'";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    strresponse = "Delete Successfull";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return "Sorry ! Related Data Found, Cann't Delete...";
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        public string mUpdateCostCategory(string strDeComID, string stroldCostCategory, string strNewCostCategory)
        {

            string strresponse = "";
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


                    SqlCommand cmdUpdate = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdUpdate.Connection = gcnMain;
                    cmdUpdate.Transaction = myTrans;

                    strSQL = "UPDATE VECTOR_CATEGORY SET VECTOR_CATEGORY_NAME = '" + strNewCostCategory.Trim().Replace("'", "''") + "' ";
                    strSQL = strSQL + "WHERE VECTOR_CATEGORY_NAME = '" + stroldCostCategory.Trim().Replace("'", "''") + "'";
                    cmdUpdate.CommandText = strSQL;
                    cmdUpdate.ExecuteNonQuery();

                    strSQL = "UPDATE VECTOR_TRANSACTION SET VCATEGORY_NAME = '" + strNewCostCategory.Trim().Replace("'", "''") + "' ";
                    strSQL = strSQL + "WHERE VCATEGORY_NAME = '" + stroldCostCategory.Trim().Replace("'", "''") + "' ";
                    cmdUpdate.ExecuteNonQuery();

                    strSQL = "UPDATE VECTOR_MASTER_CHILD SET VECTOR_CATEGORY_NAME = '" + strNewCostCategory.Trim().Replace("'", "''") + "' ";
                    strSQL = strSQL + "WHERE VECTOR_CATEGORY_NAME = '" + stroldCostCategory.Trim().Replace("'", "''") + "' ";
                    cmdUpdate.ExecuteNonQuery();

                    cmdUpdate.Transaction.Commit();
                    strresponse = "Update Successfully...";
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


        public List<VectorCategory> mFillVectorCategory(string strDeComID)
        {

            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<VectorCategory> ooVector = new List<VectorCategory>();
            strSQL = "SELECT VECTOR_CATEGORY_SERIAL,VECTOR_CATEGORY_NAME FROM VECTOR_CATEGORY ORDER BY VECTOR_CATEGORY_NAME ";

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
                    VectorCategory ovector = new VectorCategory();
                    ovector.lngSlNo = Convert.ToInt64(dr["VECTOR_CATEGORY_SERIAL"].ToString());
                    ovector.strVectorcategory = dr["VECTOR_CATEGORY_NAME"].ToString();
                    ooVector.Add(ovector);
                }
                return ooVector;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }

        public List<VectorCategory> mFillLedgerNameVector(string strDeComID)
        {

            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<VectorCategory> ooVector = new List<VectorCategory>();
            strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER WHERE LEDGER_VECTOR = 2 AND LEDGER_STATUS = 0 ORDER BY LEDGER_NAME ";

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
                    VectorCategory ovector = new VectorCategory();
                    //ovector.lngSlNo = Convert.ToInt64(dr["VECTOR_CATEGORY_SERIAL"].ToString());
                    ovector.strVectorcategory = dr["LEDGER_NAME"].ToString();
                    ooVector.Add(ovector);
                }
                return ooVector;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }


        #endregion
        #region "Currency"
        public List<AccountsLedger> mFillCurrencyList(string strDeComID)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooAccLedger = new List<AccountsLedger>();
            strSQL = "SELECT CURRENCY_SYMBOL FROM ACC_CURRENCY";

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
                    AccountsLedger oLedg = new AccountsLedger();
                    oLedg.strCurrency = dr["CURRENCY_SYMBOL"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                return ooAccLedger;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        #endregion
        #region "DisplayOpening"
        public string mDisplayOpening(string strDeComID)
        {
            string strDifference, strDebit = "0", strCredit = "0";
            double dblDifference, dblStockOpen = 0, mdblDebit = 0, mdblCredit = 0;
            SqlDataReader drGetGroup;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "SELECT ISNULL(SUM(STOCKITEM_OPENING_VALUE),0)*-1 AS OPN FROM INV_STOCKITEM ";
                SqlCommand cmdopn = new SqlCommand(strSQL, gcnMain);

                drGetGroup = cmdopn.ExecuteReader();
                if (drGetGroup.Read())
                {
                    dblStockOpen = Convert.ToDouble(drGetGroup["OPN"].ToString());

                }
                else
                {
                    dblStockOpen = 0;
                }
                drGetGroup.Close();

                //dblStockOpen = -168594427.74 ;

                if (Utility.glngIntegrateInventory == 1)
                {
                    dblStockOpen = 0;
                }
                //*************************Debit
                strSQL = "SELECT ISNULL(SUM(LEDGER_OPENING_BALANCE),0) AS TOTAL_DEBIT FROM ACC_LEDGER ";
                strSQL = strSQL + "WHERE LEDGER_OPENING_BALANCE < 0 ";
                if (Utility.glngIntegrateInventory == 2)
                {
                    strSQL = strSQL + "AND LEDGER_GROUP <> 401 ";
                }
                SqlCommand cmddebit = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmddebit.ExecuteReader();
                if (drGetGroup.Read())
                {
                    mdblDebit = Math.Abs(Convert.ToDouble(drGetGroup["TOTAL_DEBIT"].ToString()));
                }
                if (dblStockOpen < 0)
                {
                    mdblDebit = (mdblDebit +dblStockOpen);
                }
                else
                {
                    mdblDebit = mdblDebit + 0; ;

                }
                drGetGroup.Dispose();
                if (mdblDebit != 0)
                {
                    strDebit = mdblDebit.ToString() + " Dr";
                }
                else
                {
                    strDebit = 0 + " Dr";
                }
                //*************************Credit
                strSQL = "SELECT ISNULL(SUM(LEDGER_OPENING_BALANCE),0) AS TOTAL_CREDIT FROM ACC_LEDGER ";
                strSQL = strSQL + "WHERE LEDGER_OPENING_BALANCE > 0 ";
                if (Utility.glngIntegrateInventory == 2)
                {
                    strSQL = strSQL + "AND LEDGER_GROUP <> 401 ";
                }
                SqlCommand cmdCredit = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmdCredit.ExecuteReader();
                if (drGetGroup.Read())
                {
                    mdblCredit = Math.Abs(Convert.ToDouble(drGetGroup["TOTAL_CREDIT"].ToString()));
                }
                if (dblStockOpen > 0)
                {
                    mdblCredit = mdblCredit + dblStockOpen*-1;
                }
                else
                {
                    mdblCredit = mdblCredit + 0; ;

                }

               
                drGetGroup.Dispose();
                if (mdblCredit != 0)
                {
                    strCredit = mdblCredit.ToString() + " Cr";
                }
                else
                {
                    strCredit = 0 + " Cr";
                }
                gcnMain.Dispose();

            }

            //dblDifference = Utility.Format((mdblCredit - mdblDebit), "##########0.00");
            dblDifference = Math.Round((mdblCredit - mdblDebit), 2);
            if (dblDifference < 0)
            {
                strDifference = Math.Abs(dblDifference).ToString() + " Dr";
            }
            else if (dblDifference > 0)
            {
                strDifference = Math.Abs(dblDifference).ToString() + " Cr";
            }
            else
            {
                strDifference = "0";
            }

            return strDebit + "~" + strCredit + "~" + strDifference;

        }

        #endregion
        #region  "Cost Center"
        public List<VectorCategory> mFillCostCenter(string strDeComID)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<VectorCategory> ooCategory = new List<VectorCategory>();
            strSQL = "SELECT VMASTER_NAME,VECTOR_CATEGORY_NAME FROM VECTOR_MASTER";

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
                    VectorCategory oCat = new VectorCategory();
                    oCat.strVectorcategory = dr["VECTOR_CATEGORY_NAME"].ToString();
                    oCat.strCostCenter = dr["VMASTER_NAME"].ToString();
                    ooCategory.Add(oCat);
                }
                return ooCategory;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public string mInsertCostCenter(string strDeComID, string strCostCenter, string strCostCategory)
        {

            string strresponse = "";
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

                    strSQL = "INSERT INTO VECTOR_MASTER(VMASTER_NAME,VECTOR_CATEGORY_NAME) VALUES(";
                    strSQL = strSQL + "'" + strCostCenter.Trim().Replace("'", "''") + "'";
                    strSQL = strSQL + ",'" + strCostCategory.Trim().Replace("'", "''") + "') ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    strresponse = "Insert Successfully...";
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
        public string DeleteCostCenter(string strDeComID, string strCostCenter)
        {

            string strresponse = "";
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

                    strSQL = "DELETE FROM VECTOR_MASTER  WHERE VMASTER_NAME = '" + strCostCenter.Replace("'", "''") + "'";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    strresponse = "Delete Successfull";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return "Sorry! Related Data is already Exists..";
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        public string mUpdateCostCenter(string strDeComID, string stroldCostCenter, string strCostCenter, string strCostCategory)
        {

            string strresponse = "";
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


                    SqlCommand cmdUpdate = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdUpdate.Connection = gcnMain;
                    cmdUpdate.Transaction = myTrans;

                    strSQL = "UPDATE VECTOR_MASTER SET VMASTER_NAME = '" + strCostCenter.Trim().Replace("'", "''") + "' ";
                    strSQL = strSQL + ",VECTOR_CATEGORY_NAME='" + strCostCategory.Trim().Replace("'", "''") + "' ";
                    strSQL = strSQL + "WHERE VMASTER_NAME = '" + stroldCostCenter.Trim().Replace("'", "''") + "'";
                    cmdUpdate.CommandText = strSQL;
                    cmdUpdate.ExecuteNonQuery();


                    cmdUpdate.Transaction.Commit();
                    strresponse = "Update Successfully...";
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
        #region "VectorMaster"
        public List<VectorCategory> mFillVectorMaster(string strDeComID, string vstrVectorCategory)
        {
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<VectorCategory> ooCategory = new List<VectorCategory>();
            strSQL = "SELECT VMASTER_NAME FROM VECTOR_MASTER ";
            strSQL = strSQL + "WHERE VECTOR_CATEGORY_NAME = '" + vstrVectorCategory + "' ";


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
                    VectorCategory oCat = new VectorCategory();
                    oCat.strCostCenter = dr["VMASTER_NAME"].ToString();
                    ooCategory.Add(oCat);
                }
                return ooCategory;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        #endregion
        #region "BranchList"
        public List<BranchConfig> mFillBranch(string strDeComID, bool vblngAccessControl, string vstrUserName)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<BranchConfig> ooBranch = new List<BranchConfig>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            if (vblngAccessControl)
            {
                
                    strSQL = "SELECT BRANCH_ID,BRANCH_NAME FROM USER_PRIVILEGES_BRANCH_VIEW ";
                    strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + vstrUserName + "' ";
                    strSQL = strSQL + "AND BRANCH_ACTIVE = 0 ";
            }
            else
            {
                strSQL = "SELECT BRANCH_ID,BRANCH_NAME FROM ACC_BRANCH WHERE BRANCH_ACTIVE = 0 ";
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
                    BranchConfig oBra = new BranchConfig();
                    oBra.BranchID = dr["BRANCH_ID"].ToString();
                    oBra.BranchName = dr["BRANCH_NAME"].ToString();
                    ooBranch.Add(oBra);
                }
                return ooBranch;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<BranchConfig> mFillBranchAllNew(string strDeComID, bool vblngAccessControl, string vstrUserName)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<BranchConfig> ooBranch = new List<BranchConfig>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            if (vblngAccessControl)
            {

                strSQL = "SELECT BRANCH_ID,BRANCH_NAME FROM USER_PRIVILEGES_BRANCH_VIEW ";
                strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + vstrUserName + "' ";
                strSQL = strSQL + "AND BRANCH_ACTIVE = 0 ";
            }
            else
            {
                strSQL = "SELECT BRANCH_ID,BRANCH_NAME FROM ACC_BRANCH WHERE BRANCH_ACTIVE = 0 ";
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
                    BranchConfig oBra = new BranchConfig();
                    oBra.BranchID = dr["BRANCH_ID"].ToString();
                    oBra.BranchName = dr["BRANCH_NAME"].ToString();
                    ooBranch.Add(oBra);
                }
                return ooBranch;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        #endregion
        #region "Ledger"


        public string mSaveLedger(string strDeComID, string vsstrLedgerName, string vstrParent, string vstrEMail, string vstrFax, string vstrAddress1,
                            string vstrAddress2, string vstrcity, string vstrPostal, string vstrPhone, string vstrComments, string vstrCurrency,
                            string strInvEffectStock, string strInactive, string strCostCenter, string strDrcr, double dblopnBalance,
                            string strcostcenterGrid, string strBranchGrid,
                            double dblFixedPurhaseAmount, string strEffectoveForm, long lngReducingBal,
                            double dblAssetsLife, double dblDepRate, double dblAccDep, double dblWrittendownvalue,
                            double dblSalvageValue, double lngAssetPercent, string strAssetsGrid, string strAssetsGridAccu,string strPFAmount)
        {
            long lngGroupType = 0, lngLedgerGroup = 0, lngMultiply = 0, lngLedgerLevel = 0, lngVector = 0, lngGrLevel = 0, lngCashFlowType = 0, lngManuFacType = 0, lngLedgerStatus = 0, lngInventoryAffect = 0, lngPayroll = 0;
            string strSQL, strPrimary = "", strReportGroup = "", strLedgerName = "", strParent, strEMail, strFax, strVectorDrCr = "";
            double dblOpeningBalance = 0;

            bool blnInsert = false;


            strLedgerName = vsstrLedgerName;

            strParent = vstrParent;
            strEMail = vstrEMail;
            strFax = vstrFax;
            if (strInvEffectStock == "Yes")
            {
                lngInventoryAffect = 2;
            }

            if (strInactive == "Yes")
            {
                lngLedgerStatus = 1;
            }
            else
            {
                lngLedgerStatus = 0;
            }
            if (strCostCenter == "Yes")
            {
                lngVector = 2;
            }

            else if (strCostCenter == "No")
            {
                lngVector = 1;
            }
            if (strDrcr.ToUpper() == "DR")
            {
                lngMultiply = -1;
            }
            else if (strDrcr.ToUpper() == "CR")
            {
                lngMultiply = 1;
            }

            if (dblopnBalance == 0)
            {
                dblOpeningBalance = 0;
            }
            else
            {
                dblOpeningBalance = dblopnBalance * lngMultiply;
            }
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                SqlDataReader dr;
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

                strSQL = "SELECT GR_PRIMARY,GR_GROUP,GR_LEVEL,GR_ONE_DOWN,GR_PRIMARY_TYPE,";
                strSQL += "GR_CASH_FLOW_TYPE,GR_MANUFAC_GROUP FROM ACC_LEDGERGROUP WHERE GR_NAME = '" + strParent + "' ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    strPrimary = dr["GR_PRIMARY"].ToString();
                    lngLedgerGroup = long.Parse(dr["GR_GROUP"].ToString());
                    lngGroupType = long.Parse(dr["GR_PRIMARY_TYPE"].ToString());
                    strReportGroup = (dr["GR_ONE_DOWN"].ToString());
                    lngLedgerLevel = long.Parse(dr["GR_LEVEL"].ToString())+1;
                    lngCashFlowType = long.Parse(dr["GR_CASH_FLOW_TYPE"].ToString());
                    lngManuFacType = long.Parse(dr["GR_MANUFAC_GROUP"].ToString());

                    if (strPrimary == strReportGroup)
                    {
                        strReportGroup = strLedgerName;
                    }

                }

                dr.Close();

                if (lngLedgerGroup == 0)
                {
                    lngLedgerGroup = (long)Utility.GR_GROUP_TYPE.grOTHER_LEDGER;
                }

                strSQL = "INSERT INTO ACC_LEDGER(";
                strSQL = strSQL + "LEDGER_NAME,LEDGER_NAME_MERZE,LEDGER_INVENTORY_AFFECT, LEDGER_CASH_FLOW_TYPE,LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "LEDGER_PRIMARY_GROUP,LEDGER_ONE_DOWN,LEDGER_OPENING_BALANCE,";
                strSQL = strSQL + "LEDGER_ADDRESS1,LEDGER_ADDRESS2,LEDGER_CITY,LEDGER_POSTAL, ";
                strSQL = strSQL + "LEDGER_PHONE,LEDGER_FAX,LEDGER_EMAIL,";
                strSQL = strSQL + "LEDGER_COMMENTS,LEDGER_PAYROLL,";
                strSQL = strSQL + "LEDGER_CLOSING_BALANCE,LEDGER_GROUP,LEDGER_LEVEL,LEDGER_PRIMARY_TYPE,";
                strSQL = strSQL + "LEDGER_VECTOR,LEDGER_MANUFAC_GROUP,";
                strSQL = strSQL + "LEDGER_CURRENCY_SYMBOL,LEDGER_STATUS,PF_AMOUNT) ";
                strSQL = strSQL + "VALUES(";
                strSQL = strSQL + "'" + strLedgerName + "',";
                strSQL = strSQL + "'" + strLedgerName + "',";
                strSQL = strSQL + " " + lngInventoryAffect + ",";
                strSQL = strSQL + "" + lngCashFlowType + ",";
                strSQL = strSQL + "'" + strParent + "','" + strPrimary + "', ";
                strSQL = strSQL + "'" + strReportGroup + "', ";
                strSQL = strSQL + "" + dblOpeningBalance + ",";
                strSQL = strSQL + "'" + vstrAddress1.TrimStart().Replace("'", "''") + "', ";
                strSQL = strSQL + "'" + vstrAddress2.TrimStart().Replace("'", "''") + "', ";
                strSQL = strSQL + "'" + vstrcity.TrimStart().Replace("'", "''") + "', ";
                strSQL = strSQL + "'" + vstrPostal.TrimStart().Replace("'", "''") + "', ";
                strSQL = strSQL + "'" + vstrPhone.TrimStart().Replace("'", "''") + "', ";
                strSQL = strSQL + "'" + strFax + "', ";
                strSQL = strSQL + "'" + strEMail + "', ";
                strSQL = strSQL + "'" + vstrComments.TrimStart().Replace("'", "''") + "',";
                strSQL = strSQL + "" + lngPayroll + ",";
                strSQL = strSQL + "" + dblOpeningBalance + ",";
                strSQL = strSQL + " " + lngLedgerGroup + ", ";
                strSQL = strSQL + " " + lngLedgerLevel + ", ";
                strSQL = strSQL + " " + lngGroupType + ", ";
                strSQL = strSQL + " " + lngVector + ",";
                strSQL = strSQL + " " + lngManuFacType + ",";
                strSQL = strSQL + "'" + vstrCurrency.TrimStart() + "',";
                strSQL = strSQL + " " + lngLedgerStatus + ",";
                strSQL = strSQL + " " + Utility.Val(strPFAmount) + " ";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES(";
                strSQL = strSQL + "'" + strParent + "','" + strLedgerName + "'";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                do
                {


                    strSQL = "SELECT GR_PARENT,GR_LEVEL FROM ACC_LEDGERGROUP ";
                    strSQL = strSQL + "WHERE GR_NAME ='" + strParent + "' ";
                    SqlDataReader dr1;
                    cmdInsert.CommandText = strSQL;
                    dr1 = cmdInsert.ExecuteReader();
                    if (dr1.Read())
                    {
                        strParent = dr1["GR_PARENT"].ToString().Replace("'", "''");
                        lngGrLevel = long.Parse(dr1["GR_LEVEL"].ToString());
                    }

                    dr1.Close();
                    if (lngGrLevel == 1)
                    {
                        blnInsert = true;
                    }

                    if (blnInsert == false)
                    {

                        strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) ";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + strParent + "','" + strLedgerName + "'";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                while (blnInsert == false);
                dr.Close();
                
                strSQL = "UPDATE ACC_LEDGER_GROUP_QRY ";
                strSQL = strSQL + "SET ";
                if (dblOpeningBalance <= 0)
                {
                    strSQL = strSQL + "GR_OPENING_DEBIT = GR_OPENING_DEBIT + " + dblOpeningBalance + ", ";
                    strSQL = strSQL + "GR_CLOSING_DEBIT = GR_CLOSING_DEBIT + " + dblOpeningBalance + " ";
                }
                if (dblOpeningBalance > 0)
                {
                    strSQL = strSQL + "GR_OPENING_CREDIT = GR_OPENING_CREDIT + " + dblOpeningBalance + ", ";
                    strSQL = strSQL + "GR_CLOSING_CREDIT = GR_CLOSING_CREDIT + " + dblOpeningBalance + " ";
                }
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strLedgerName + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();



                if (dblOpeningBalance != 0)
                {
                    string strBranchName, strCostCategory, strCostCenterNew;
                    double dblCostCenterAmount = 0;
                    string[] words = strcostcenterGrid.Split('~');
                    foreach (string costcenter in words)
                    {
                        string[] ooCost = costcenter.Split(',');
                        if (ooCost[0] != "")
                        {
                            strBranchName = ooCost[0].ToString();
                            strCostCategory = ooCost[1].ToString();
                            strCostCenterNew = ooCost[2].ToString();
                            dblCostCenterAmount = Convert.ToDouble(ooCost[3]);
                            strSQL = "INSERT INTO VECTOR_MASTER_CHILD ";
                            strSQL = strSQL + "(VMASTER_NAME,VECTOR_CATEGORY_NAME,VCHILD_OPENING_BALANCE,BRANCH_ID,MASTER_LEDGER_NAME,VECTOR_TO_BY ";
                            strSQL = strSQL + ")VALUES( ";
                            strSQL = strSQL + "'" + strCostCenterNew + "', ";
                            strSQL = strSQL + "'" + strCostCategory + "', ";
                            if (strDrcr == "Dr")
                            {
                                strVectorDrCr = "Dr";
                                strSQL = strSQL + "" + dblCostCenterAmount * -1 + ", ";
                            }

                            else
                            {
                                strVectorDrCr = "Cr";
                                strSQL = strSQL + "" + dblCostCenterAmount + ", ";
                            }
                            strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID, strBranchName.Replace("'", "''")) + "', ";
                            strSQL = strSQL + "'" + strLedgerName + "', ";
                            strSQL = strSQL + "'" + strVectorDrCr + "' ";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                    }
                }

                if (dblOpeningBalance != 0)
                {
                    string strBranchName;
                    double dblBranchAmount = 0;
                    string[] words = strBranchGrid.Split('~');
                    foreach (string branch in words)
                    {
                        string[] ooBranch = branch.Split(',');

                        if (ooBranch[0] != "")
                        {
                            strBranchName = ooBranch[0].ToString();
                            dblBranchAmount = Convert.ToDouble(ooBranch[1]);
                            strSQL = "INSERT INTO ACC_BRANCH_LEDGER_OPENING (";
                            strSQL = strSQL + "BRANCH_LEDGER_KEY,BRANCH_ID, ";
                            strSQL = strSQL + "LEDGER_NAME,BRANCH_LEDGER_OPENING_BALANCE ";
                            strSQL = strSQL + ") ";
                            strSQL = strSQL + "VALUES (";
                            strSQL = strSQL + "'" + strLedgerName + Utility.gstrGetBranchID(strDeComID, strBranchName.Replace("'", "''")) + "' ,";
                            strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID, strBranchName.Replace("'", "''")) + "',";
                            strSQL = strSQL + "'" + strLedgerName + "',";
                            strSQL = strSQL + " " + dblBranchAmount * lngMultiply + " ";
                            strSQL = strSQL + ")";

                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                    }

                }

                if (lngLedgerGroup == (long)Utility.GR_GROUP_TYPE.grFIXED_ASSET)
                {
                    if (dblFixedPurhaseAmount != 0)
                    {

                        strSQL = "INSERT INTO ACC_FIXED_ASSETS(";
                        strSQL = strSQL + "LEDGER_NAME,ASSET_PURCHASE_COST,ASSET_DEP_EFF_DATE,";
                        strSQL = strSQL + "ASSET_DEP_METHOD,ASSET_LIFE,ASSET_DEP_RATE,ASSET_ACCU_DEP,";
                        strSQL = strSQL + "ASSET_WRITTEN_VALUE,ASSET_SALVAGE_VALUE,ASSET_PERCENT)";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + strLedgerName + "',";
                        strSQL = strSQL + "" + dblFixedPurhaseAmount + ",";
                        strSQL = strSQL + " Convert (DateTime  ,'" + strEffectoveForm + "', 103) ,";
                        strSQL = strSQL + "" + lngReducingBal + ",";
                        strSQL = strSQL + "" + dblAssetsLife + ",";
                        strSQL = strSQL + "" + dblDepRate + ",";
                        strSQL = strSQL + "" + dblAccDep + ",";
                        strSQL = strSQL + "" + dblWrittendownvalue + ",";
                        strSQL = strSQL + "" + dblSalvageValue + ",";
                        strSQL = strSQL + "" + lngAssetPercent + "";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    if (dblFixedPurhaseAmount != 0)
                    {
                        string strBranchName;
                        double dblAssetsAmount = 0;
                        string[] words = strAssetsGrid.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split(',');
                            if (oAssets[0] != "")
                            {
                                strBranchName = oAssets[0].ToString();
                                dblAssetsAmount = Convert.ToDouble(oAssets[1]);
                                strSQL = "INSERT INTO ACC_FIXED_ASSET_PURCHASE_AMOUNT (";
                                strSQL = strSQL + "BRANCH_LEDGER_KEY,BRANCH_ID,";
                                strSQL = strSQL + "LEDGER_NAME,BRANCH_PURCHASE_AMOUNT ";
                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES (";
                                strSQL = strSQL + "'" + strLedgerName + Utility.gstrGetBranchID(strDeComID, strBranchName) + "' ,";
                                strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID, strBranchName) + "',";
                                strSQL = strSQL + "'" + strLedgerName + "',";
                                strSQL = strSQL + " " + dblAssetsAmount + " ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }

                    }

                    if (dblAccDep != 0)
                    {
                        string strBranchName;
                        double dblAssetsAmount = 0;
                        string[] words = strAssetsGridAccu.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split(',');
                            if (oAssets[0] != "")
                            {
                                strBranchName = oAssets[0].ToString();
                                dblAssetsAmount = Convert.ToDouble(oAssets[1]);
                                strSQL = "INSERT INTO ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION (";
                                strSQL = strSQL + "BRANCH_LEDGER_KEY,BRANCH_ID, ";
                                strSQL = strSQL + "LEDGER_NAME,BRANCH_ACCUMULATED_DEPRECIATION ";
                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES (";
                                strSQL = strSQL + "'" + strLedgerName + Utility.gstrGetBranchID(strDeComID, strBranchName) + "' ,";
                                strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID, strBranchName) + "',";
                                strSQL = strSQL + "'" + strLedgerName + "',";
                                strSQL = strSQL + " " + dblAssetsAmount + " ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }

                        }

                    }
                    if (lngLedgerGroup == (long)Utility.GR_GROUP_TYPE.grCUSTOMER || lngLedgerGroup == (long)Utility.GR_GROUP_TYPE.grCUSTOMER)
                    {
                        long lngLedgerSerial;
                        double dblAmount;
                        string strBranchId;

                        lngLedgerSerial = Utility.mlngGetLedgerSerial(strDeComID, strLedgerName);
                        dblAmount = dblOpeningBalance;
                        if (strDrcr.ToUpper() == "DR")
                        {
                            dblAmount = dblAmount * -1;
                        }
                        strBranchId = Utility.gstrBranchID;
                        strSQL = "INSERT INTO ACC_BILL_WISE(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,AGAINST_VOUCHER_NO,";
                        strSQL = strSQL + "COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
                        strSQL = strSQL + "BILL_WISE_POSITION,BILL_WISE_PREV_NEW,";
                        strSQL = strSQL + "LEDGER_NAME,BILL_WISE_AMOUNT,BILL_WISE_TOBY,";
                        strSQL = strSQL + "BILL_WISE_IS_OPEN";
                        strSQL = strSQL + ") VALUES (";
                        strSQL = strSQL + "'" + strBranchId + "', ";
                        strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + strBranchId + lngLedgerSerial.ToString() + " ',";
                        strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + strBranchId + lngLedgerSerial.ToString() + " ',";
                        strSQL = strSQL + "'" + strBranchId + lngLedgerSerial.ToString() + "',";//   'AGAINST_VOUCHER_NO
                        strSQL = strSQL + "0 ,";//                                ' COMP_VOUCHER_TYPE
                        //strSQL = strSQL + "" + cvtSQLDate(DateAdd("d", -1, gdteFinicialYearFrom)) + ","
                        strSQL = strSQL + "" + Utility.cvtSQLDate(Convert.ToDateTime(Utility.gdteFinancialYearFrom).AddDays(-1)) + ",";
                        strSQL = strSQL + "1,";
                        strSQL = strSQL + "0 ,";
                        strSQL = strSQL + "'" + strLedgerName + "', ";
                        strSQL = strSQL + "" + dblAmount + ",";
                        strSQL = strSQL + "'" + strDrcr + "',";
                        strSQL = strSQL + "1";
                        strSQL = strSQL + ") ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                }

                cmdInsert.Transaction.Commit();
                gcnMain.Close();
                dr.Close();
                return "1";
            }

        }

        public string mUpdateLedger(string strDeComID, string strOldLedger, long mlngLedgerSerial, string vsstrLedgerName, string vstrParent, string vstrEMail, string vstrFax, string vstrAddress1,
                                string vstrAddress2, string vstrcity, string vstrPostal, string vstrPhone, string vstrComments, string vstrCurrency,
                                string strInvEffectStock, string strInactive, string strCostCenter, string strDrcr, double dblopnBalance,
                                string strcostcenterGrid, string strBranchGrid,
                                double dblFixedPurhaseAmount, string strEffectoveForm, long lngReducingBal,
                                double dblAssetsLife, double dblDepRate, double dblAccDep, double dblWrittendownvalue,
                                double dblSalvageValue, double lngAssetPercent, string strAssetsGrid, string strAssetsGridAccu,string strPFAmount)
        {
            long lngGroupType = 0, lngLedgerGroup = 0, lngMultiply = 0, lngLedgerLevel = 0, lngVector = 0, lngGrLevel = 0,
                lngCashFlowType = 0, lngManuFacType = 0, lngLedgerStatus = 0, lngInventoryAffect = 0, lngPayroll = 0, lngStatus = 0;
            string strSQL, strPrimary = "", strReportGroup = "", strLedgerName = "", strParent, strEMail, strFax, strVectorDrCr = "";
            double dblOpeningBalance = 0, dblOldOpening = 0, dblClosingBalance = 0, dblOpn=0, dblCls=0;

            bool blnInsert = false;


            strLedgerName = vsstrLedgerName;

            strParent = vstrParent;
            strEMail = vstrEMail;
            strFax = vstrFax;
            if (strInvEffectStock == "Yes")
            {
                lngInventoryAffect = 2;
            }

            if (strInactive == "Yes")
            {
                lngLedgerStatus = 1;
            }
            else
            {
                lngLedgerStatus = 0;
            }
            if (strCostCenter == "Yes")
            {
                lngVector = 2;
            }

            else if (strCostCenter == "No")
            {
                lngVector = 1;
            }
            if (strDrcr.ToUpper() == "DR")
            {
                lngMultiply = -1;
            }
            else if (strDrcr.ToUpper() == "CR")
            {
                lngMultiply = 1;
            }

            if (dblopnBalance == 0)
            {
                dblOpeningBalance = 0;
            }
            else
            {
                dblOpeningBalance = dblopnBalance * lngMultiply;
            }
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                SqlDataReader dr;
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                gcnMain.Close();
                gcnMain.Open();
                SqlTransaction myTrans;
                SqlCommand cmdInsert = new SqlCommand();
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "SELECT GR_PRIMARY,GR_GROUP,GR_LEVEL,GR_ONE_DOWN,GR_PRIMARY_TYPE,";
                strSQL += "GR_CASH_FLOW_TYPE,GR_MANUFAC_GROUP FROM ACC_LEDGERGROUP WHERE GR_NAME = '" + strParent + "' ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    strPrimary = dr["GR_PRIMARY"].ToString();
                    lngLedgerGroup = long.Parse(dr["GR_GROUP"].ToString());
                    lngGroupType = long.Parse(dr["GR_PRIMARY_TYPE"].ToString());
                    strReportGroup = (dr["GR_ONE_DOWN"].ToString());
                    lngLedgerLevel = long.Parse(dr["GR_LEVEL"].ToString())+1;
                    lngCashFlowType = long.Parse(dr["GR_CASH_FLOW_TYPE"].ToString());
                    lngManuFacType = long.Parse(dr["GR_MANUFAC_GROUP"].ToString());

                    if (strPrimary == strReportGroup)
                    {
                        strReportGroup = strLedgerName;
                    }
                }

                dr.Close();

                strSQL = "SELECT LEDGER_OPENING_BALANCE,LEDGER_CLOSING_BALANCE FROM ACC_LEDGER ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strOldLedger + "'";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblOldOpening = Convert.ToDouble(dr["LEDGER_OPENING_BALANCE"]);
                    dblClosingBalance = Convert.ToDouble(dr["LEDGER_CLOSING_BALANCE"]);
                }

                dr.Close();


                strSQL = "UPDATE ACC_LEDGER_GROUP_QRY ";
                strSQL = strSQL + "SET ";
                if (dblOldOpening <= 0)
                {
                    strSQL = strSQL + "GR_OPENING_DEBIT = GR_OPENING_DEBIT - " + dblOldOpening + ", ";
                    strSQL = strSQL + "GR_CLOSING_DEBIT = GR_CLOSING_DEBIT - " + dblOldOpening + " ";
                }
                if (dblOldOpening > 0)
                {
                    strSQL = strSQL + "GR_OPENING_CREDIT = GR_OPENING_CREDIT - " + dblOldOpening + ", ";
                    strSQL = strSQL + "GR_CLOSING_CREDIT = GR_CLOSING_CREDIT - " + dblOldOpening + " ";
                }
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strLedgerName + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "DELETE FROM ACC_BILL_WISE WHERE LEDGER_NAME = '" + strOldLedger + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_TYPE = 0 ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "DELETE FROM ACC_LEDGER_TO_GROUP WHERE LEDGER_NAME = '" + strOldLedger + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM ACC_STOCK_IN_HAND WHERE LEDGER_NAME = '" + strOldLedger + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM ACC_BRANCH_LEDGER_OPENING WHERE LEDGER_NAME = '" + strOldLedger + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                if (lngLedgerGroup == 0)
                {
                    lngLedgerGroup = (long)Utility.GR_GROUP_TYPE.grOTHER_LEDGER;
                }


                strSQL = "UPDATE ACC_LEDGER ";
                strSQL = strSQL + "SET LEDGER_NAME = '" + strLedgerName + "',";
                strSQL = strSQL + "LEDGER_NAME_MERZE = '" + strLedgerName + "',";
                strSQL = strSQL + "LEDGER_PARENT_GROUP = '" + strParent + "',";
                strSQL = strSQL + "LEDGER_INVENTORY_AFFECT = " + lngInventoryAffect + ",";
                strSQL = strSQL + "LEDGER_PRIMARY_GROUP = '" + strPrimary + "',";
                strSQL = strSQL + "LEDGER_ONE_DOWN = '" + strReportGroup + "',";
                strSQL = strSQL + "LEDGER_OPENING_BALANCE = " + dblOpeningBalance + ", ";
                strSQL = strSQL + "LEDGER_ADDRESS1 = '" + vstrAddress1 + "', ";
                strSQL = strSQL + "LEDGER_ADDRESS2 = '" + vstrAddress2 + "', ";
                strSQL = strSQL + "LEDGER_CITY = '" + vstrcity + "', ";
                strSQL = strSQL + "LEDGER_CURRENCY_SYMBOL = '" + vstrCurrency + "', ";
                strSQL = strSQL + "LEDGER_POSTAL = '" + vstrPostal + "', ";
                strSQL = strSQL + "LEDGER_PHONE = '" + vstrPhone + "', ";
                strSQL = strSQL + "LEDGER_FAX = '" + vstrFax + "', ";
                strSQL = strSQL + "LEDGER_EMAIL = '" + vstrEMail + "', ";
                strSQL = strSQL + "LEDGER_COMMENTS = '" + vstrComments + "', ";
                strSQL = strSQL + "LEDGER_PAYROLL = " + lngPayroll + ",";
                strSQL = strSQL + "LEDGER_GROUP = " + lngLedgerGroup + ",";
                strSQL = strSQL + "LEDGER_LEVEL = " + lngLedgerLevel + ",";
                strSQL = strSQL + "LEDGER_STATUS = " + lngLedgerStatus + ",";
                strSQL = strSQL + "LEDGER_VECTOR = " + lngVector + ",";
                strSQL = strSQL + "LEDGER_MANUFAC_GROUP = " + lngManuFacType + ",";
                strSQL = strSQL + "LEDGER_PRIMARY_TYPE = " + lngGroupType + ",";
                strSQL = strSQL + "PF_AMOUNT =" + Utility.Val(strPFAmount) + ",";
                strSQL = strSQL + "LEDGER_CLOSING_BALANCE = " + ((dblClosingBalance + dblOpeningBalance) - dblOldOpening) + " ";
                strSQL = strSQL + "WHERE LEDGER_SERIAL = " + mlngLedgerSerial + " ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                string strUpdate = Utility.gInsertUpdateLog(strDeComID, strOldLedger, dblOldOpening, strLedgerName, dblOpeningBalance, "ACC_LEDGER", "LEDGER_NAME");


                strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES(";
                strSQL = strSQL + "'" + strParent + "','" + strLedgerName + "'";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                dr.Close();
                do
                {
                    strSQL = "SELECT GR_PARENT,GR_LEVEL FROM ACC_LEDGERGROUP ";
                    strSQL = strSQL + "WHERE GR_NAME ='" + strParent + "' ";
                    SqlDataReader dr1;
                    cmdInsert.CommandText = strSQL;
                    dr1 = cmdInsert.ExecuteReader();
                    if (dr1.Read())
                    {
                        strParent = dr1["GR_PARENT"].ToString().Replace("'", "''");
                        lngGrLevel = long.Parse(dr1["GR_LEVEL"].ToString());
                    }

                    dr1.Close();
                    if (lngGrLevel == 1)
                    {
                        blnInsert = true;
                    }
                    if (lngGrLevel == 0)
                    {
                        blnInsert = true;
                    }
                    if (blnInsert == false)
                    {

                        strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) ";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + strParent + "','" + strLedgerName + "'";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                while (blnInsert == false);

                strSQL = "UPDATE ACC_VOUCHER SET VOUCHER_REVERSE_LEDGER = '" + strLedgerName + "' ";
                strSQL = strSQL + "WHERE VOUCHER_REVERSE_LEDGER = '" + strOldLedger + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "UPDATE ACC_LEDGER_GROUP_QRY ";
                strSQL = strSQL + "SET ";
                if (dblOpeningBalance <= 0)
                {
                    strSQL = strSQL + "GR_OPENING_DEBIT = GR_OPENING_DEBIT + " + dblOpeningBalance + ", ";
                    strSQL = strSQL + "GR_CLOSING_DEBIT = GR_CLOSING_DEBIT + " + dblOpeningBalance + " ";
                }
                if (dblOpeningBalance > 0)
                {
                    strSQL = strSQL + "GR_OPENING_CREDIT = GR_OPENING_CREDIT + " + dblOpeningBalance + ", ";
                    strSQL = strSQL + "GR_CLOSING_CREDIT = GR_CLOSING_CREDIT + " + dblOpeningBalance + " ";
                }
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strLedgerName + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();



                strSQL = "DELETE FROM VECTOR_MASTER_CHILD WHERE MASTER_LEDGER_NAME = '" + strOldLedger + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                if (dblOpeningBalance != 0)
                {
                    string strBranchName, strCostCategory, strCostCenterNew;
                    double dblCostCenterAmount = 0;
                    string[] words = strcostcenterGrid.Split('~');
                    foreach (string costcenter in words)
                    {
                        string[] ooCost = costcenter.Split(',');
                        if (ooCost[0] != "")
                        {
                            strBranchName = ooCost[0].ToString();
                            strCostCategory = ooCost[1].ToString();
                            strCostCenterNew = ooCost[2].ToString();
                            dblCostCenterAmount = Convert.ToDouble(ooCost[3]);
                            strSQL = "INSERT INTO VECTOR_MASTER_CHILD ";
                            strSQL = strSQL + "(VMASTER_NAME,VECTOR_CATEGORY_NAME,VCHILD_OPENING_BALANCE,BRANCH_ID,MASTER_LEDGER_NAME,VECTOR_TO_BY ";
                            strSQL = strSQL + ")VALUES( ";
                            strSQL = strSQL + "'" + strCostCenterNew + "', ";
                            strSQL = strSQL + "'" + strCostCategory + "', ";
                            if (strDrcr == "Dr")
                            {
                                strVectorDrCr = "Dr";
                                strSQL = strSQL + "" + dblCostCenterAmount * -1 + ", ";
                            }

                            else
                            {
                                strVectorDrCr = "Cr";
                                strSQL = strSQL + "" + dblCostCenterAmount + ", ";
                            }
                            strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID, strBranchName.Replace("'", "''")) + "', ";
                            strSQL = strSQL + "'" + strLedgerName + "', ";
                            strSQL = strSQL + "'" + strVectorDrCr + "' ";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                    }
                }

                if (dblOpeningBalance != 0)
                {
                    strSQL = "DELETE FROM ACC_BRANCH_LEDGER_OPENING WHERE LEDGER_NAME = '" + strOldLedger + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    string strBranchName;
                    double dblBranchAmount = 0;
                    string[] words = strBranchGrid.Split('~');
                    foreach (string branch in words)
                    {
                        string[] ooBranch = branch.Split(',');

                        if (ooBranch[0] != "")
                        {
                            strBranchName = ooBranch[0].ToString();
                            dblBranchAmount = Convert.ToDouble(ooBranch[1]);
                            strSQL = "INSERT INTO ACC_BRANCH_LEDGER_OPENING (";
                            strSQL = strSQL + "BRANCH_LEDGER_KEY,BRANCH_ID, ";
                            strSQL = strSQL + "LEDGER_NAME,BRANCH_LEDGER_OPENING_BALANCE ";
                            strSQL = strSQL + ") ";
                            strSQL = strSQL + "VALUES (";
                            strSQL = strSQL + "'" + strLedgerName + Utility.gstrGetBranchID(strDeComID, strBranchName.Replace("'", "''")) + "' ,";
                            strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID, strBranchName.Replace("'", "''")) + "',";
                            strSQL = strSQL + "'" + strLedgerName + "',";
                            strSQL = strSQL + " " + dblBranchAmount * lngMultiply + " ";
                            strSQL = strSQL + ")";

                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                    }

                }

                if (lngLedgerGroup == (long)Utility.GR_GROUP_TYPE.grFIXED_ASSET)
                {
                    if (dblFixedPurhaseAmount != 0)
                    {
                        strSQL = "DELETE FROM ACC_FIXED_ASSETS WHERE LEDGER_NAME = '" + strOldLedger + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_FIXED_ASSETS(";
                        strSQL = strSQL + "LEDGER_NAME,ASSET_PURCHASE_COST,ASSET_DEP_EFF_DATE,";
                        strSQL = strSQL + "ASSET_DEP_METHOD,ASSET_LIFE,ASSET_DEP_RATE,ASSET_ACCU_DEP,";
                        strSQL = strSQL + "ASSET_WRITTEN_VALUE,ASSET_SALVAGE_VALUE,ASSET_PERCENT)";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + strLedgerName + "',";
                        strSQL = strSQL + "" + dblFixedPurhaseAmount + ",";
                        strSQL = strSQL + " Convert (DateTime  ,'" + strEffectoveForm + "', 103) ,";
                        strSQL = strSQL + "" + lngReducingBal + ",";
                        strSQL = strSQL + "" + dblAssetsLife + ",";
                        strSQL = strSQL + "" + dblDepRate + ",";
                        strSQL = strSQL + "" + dblAccDep + ",";
                        strSQL = strSQL + "" + dblWrittendownvalue + ",";
                        strSQL = strSQL + "" + dblSalvageValue + ",";
                        strSQL = strSQL + "" + lngAssetPercent + "";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    if (dblFixedPurhaseAmount != 0)
                    {
                        strSQL = "DELETE FROM ACC_FIXED_ASSET_PURCHASE_AMOUNT WHERE LEDGER_NAME = '" + strOldLedger + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        string strBranchName;
                        double dblAssetsAmount = 0;
                        string[] words = strAssetsGrid.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split(',');
                            if (oAssets[0] != "")
                            {
                                strBranchName = oAssets[0].ToString();
                                dblAssetsAmount = Convert.ToDouble(oAssets[1]);
                                strSQL = "INSERT INTO ACC_FIXED_ASSET_PURCHASE_AMOUNT (";
                                strSQL = strSQL + "BRANCH_LEDGER_KEY,BRANCH_ID,";
                                strSQL = strSQL + "LEDGER_NAME,BRANCH_PURCHASE_AMOUNT ";
                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES (";
                                strSQL = strSQL + "'" + strLedgerName + Utility.gstrGetBranchID(strDeComID, strBranchName) + "' ,";
                                strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID, strBranchName) + "',";
                                strSQL = strSQL + "'" + strLedgerName + "',";
                                strSQL = strSQL + " " + dblAssetsAmount + " ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }

                    }

                    if (dblAccDep != 0)
                    {
                        strSQL = "DELETE FROM ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION WHERE LEDGER_NAME = '" + strOldLedger + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        string strBranchName;
                        double dblAssetsAmount = 0;
                        string[] words = strAssetsGridAccu.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split(',');
                            if (oAssets[0] != "")
                            {
                                strBranchName = oAssets[0].ToString();
                                dblAssetsAmount = Convert.ToDouble(oAssets[1]);
                                strSQL = "INSERT INTO ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION (";
                                strSQL = strSQL + "BRANCH_LEDGER_KEY,BRANCH_ID, ";
                                strSQL = strSQL + "LEDGER_NAME,BRANCH_ACCUMULATED_DEPRECIATION ";
                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES (";
                                strSQL = strSQL + "'" + strLedgerName + Utility.gstrGetBranchID(strDeComID, strBranchName) + "' ,";
                                strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID, strBranchName) + "',";
                                strSQL = strSQL + "'" + strLedgerName + "',";
                                strSQL = strSQL + " " + dblAssetsAmount + " ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }

                        }

                    }
                    if (lngLedgerGroup == (long)Utility.GR_GROUP_TYPE.grCUSTOMER || lngLedgerGroup == (long)Utility.GR_GROUP_TYPE.grCUSTOMER)
                    {
                        long lngLedgerSerial;
                        double dblAmount;
                        string strBranchId;

                        lngLedgerSerial = Utility.mlngGetLedgerSerial(strDeComID, strLedgerName);
                        dblAmount = dblOpeningBalance;
                        if (strDrcr.ToUpper() == "DR")
                        {
                            dblAmount = dblAmount * -1;
                        }
                        strBranchId = Utility.gstrBranchID;
                        strSQL = "INSERT INTO ACC_BILL_WISE(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,AGAINST_VOUCHER_NO,";
                        strSQL = strSQL + "COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
                        strSQL = strSQL + "BILL_WISE_POSITION,BILL_WISE_PREV_NEW,";
                        strSQL = strSQL + "LEDGER_NAME,BILL_WISE_AMOUNT,BILL_WISE_TOBY,";
                        strSQL = strSQL + "BILL_WISE_IS_OPEN";
                        strSQL = strSQL + ") VALUES (";
                        strSQL = strSQL + "'" + strBranchId + "', ";
                        strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + strBranchId + lngLedgerSerial.ToString() + " ',";
                        strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + strBranchId + lngLedgerSerial.ToString() + " ',";
                        strSQL = strSQL + "'" + strBranchId + lngLedgerSerial.ToString() + "',";//   'AGAINST_VOUCHER_NO
                        strSQL = strSQL + "0 ,";//                                ' COMP_VOUCHER_TYPE
                        //strSQL = strSQL + "" + cvtSQLDate(DateAdd("d", -1, gdteFinicialYearFrom)) + ","
                        strSQL = strSQL + "" + Utility.cvtSQLDate(Convert.ToDateTime(Utility.gdteFinancialYearFrom).AddDays(-1)) + ",";
                        strSQL = strSQL + "1,";
                        strSQL = strSQL + "0 ,";
                        strSQL = strSQL + "'" + strLedgerName + "', ";
                        strSQL = strSQL + "" + dblAmount + ",";
                        strSQL = strSQL + "'" + strDrcr + "',";
                        strSQL = strSQL + "1";
                        strSQL = strSQL + ") ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                }
                strSQL = "UPDATE ACC_BRANCH SET BRANCH_NAME = '" + strLedgerName + "' ";
                strSQL = strSQL + "WHERE BRANCH_ID = '" + Utility.gstrGetBranchID(strDeComID, strOldLedger) + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                if (lngLedgerGroup == (long)Utility.GR_GROUP_TYPE.grSALES_REP)
                {
                    strSQL = "UPDATE ACC_COMPANY_VOUCHER SET SALES_REP = '" + strLedgerName + "' ";
                    strSQL = strSQL + "WHERE SALES_REP = '" + strOldLedger + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET ";
                strSQL = strSQL + "COMP_VOUCHER_PARTY_NAME='" + strLedgerName + "' ";
                strSQL = strSQL + ",COMP_VOUCHER_ADDRESS1='" + vstrAddress1 + "' ";
                strSQL = strSQL + ",COMP_VOUCHER_ADDRESS2='" + vstrAddress2 + "' ";
                strSQL = strSQL + ",COMP_VOUCHER_CITY='" + vstrcity + "' ";
                strSQL = strSQL + " WHERE LEDGER_NAME='" + strLedgerName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                dr.Close();
                cmdInsert.Transaction.Commit();
                gcnMain.Close();
                return "1";
            }

        }


        public List<AccountsLedger> mFillLedger(string strDeComID, int vIntGroup, string vstrPrefix, string vstrPrefix1, string vstruserName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> ooLed = new List<AccountsLedger>();

            //strSQL = "SELECT (case when LEDGER_CODE IS NULL THEN TERITORRY_CODE ELSE LEDGER_CODE END) as TERITORRY_CODE ,";
            //strSQL =strSQL + "(case when HOMOEO_HALL IS NULL THEN TERRITORRY_NAME  ELSE HOMOEO_HALL END) as TERRITORRY_NAME ,LEDGER_NAME   from ACC_LEDGER ";
            strSQL = "SELECT TERITORRY_CODE,TERRITORRY_NAME,LEDGER_NAME,LEDGER_NAME_MERZE FROM ACC_LEDGER";
            if (vIntGroup == (int)(Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER))
            {
                if (vstrPrefix1 == "Dr")
                {
                    strSQL = strSQL + " WHERE LEDGER_GROUP > 101 ";
                }
                else
                {
                    strSQL = strSQL + " WHERE LEDGER_GROUP <= 101 ";
                }
                strSQL = strSQL + " AND LEDGER_STATUS=0";
            }
            else if (vIntGroup == (int)(Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER))
            {
                if (vstrPrefix1 == "Cr")
                {
                    
                    //strSQL = strSQL + " WHERE LEDGER_GROUP > 101 ";
                    strSQL = strSQL + " WHERE LEDGER_GROUP = 202 ";
                }
                else
                {
                    strSQL = strSQL + " WHERE LEDGER_GROUP <= 101 ";
                }

            }
            else if (vIntGroup == (int)(Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER))
            {
                if (vstrPrefix1 == "Cr")
                {
                    strSQL = strSQL + " WHERE LEDGER_GROUP <= 101 ";
                }
                else
                {
                    strSQL = strSQL + " WHERE LEDGER_GROUP <= 101 ";
                }
                strSQL = strSQL + " AND LEDGER_STATUS=0";
            }
            else if (vIntGroup == (int)(Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER))
            {
                strSQL = strSQL + " WHERE LEDGER_GROUP >= 100 ";
            }
            else
            {
                strSQL = strSQL + " WHERE LEDGER_GROUP >= 100 ";
                strSQL = strSQL + " AND LEDGER_STATUS=0";
            }
           
            strSQL = strSQL + " AND LEDGER_GROUP <> " + (int)Utility.GR_GROUP_TYPE.grSALES_REP + " ";
            strSQL = strSQL + "and LEDGER_NAME in (SELECT  LEDGER_NAME FROM  USER_PRIVILEGES_LEDGER WHERE USER_LOGIN_NAME='" + vstruserName + "')";
            strSQL = strSQL + " ORDER BY TERITORRY_CODE,LEDGER_NAME ";
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
                    AccountsLedger ogrp = new AccountsLedger();
                    if (drGetGroup["TERITORRY_CODE"] != "")
                    {
                        ogrp.strTeritorryCode = drGetGroup["TERITORRY_CODE"].ToString();
                        ogrp.strTeritoryyName=drGetGroup["TERRITORRY_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strTeritorryCode = "";
                        ogrp.strTeritoryyName="";
                    }
                    //ogrp.strTeritoryyName = drGetGroup["TERRITORRY_NAME"].ToString();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    //ogrp.strmerzeString = drGetGroup["TERITORRY_CODE"].ToString() + drGetGroup["TERRITORRY_NAME"].ToString() + drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strmerzeString = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        public List<AccountsLedger> mFillLedgerListNew(string strDeComID, int mintLedgerGroup, int intStatus, string strMySQL, int intlaodType)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> ooLed = new List<AccountsLedger>();
            if (strMySQL == "")
            {
                if (mintLedgerGroup == (int)Utility.GR_GROUP_TYPE.grCUSTOMER)
                {
                    strSQL = "SELECT LEDGER_SERIAL,TERITORRY_CODE AS code,TERRITORRY_NAME, LEDGER_NAME_MERZE,LEDGER_NAME,LEDGER_PARENT_GROUP,LEDGER_DEFAULT,";
                    strSQL = strSQL + "LEDGER_OPENING_BALANCE FROM ACC_LEDGER ";
                }
                else if (mintLedgerGroup == (int)Utility.GR_GROUP_TYPE.grSUPPLIER)
                {
                    strSQL = "SELECT LEDGER_SERIAL,LEDGER_CODE AS code,HOMOEO_HALL as TERRITORRY_NAME,LEDGER_NAME_MERZE, LEDGER_NAME,LEDGER_PARENT_GROUP,LEDGER_DEFAULT,";
                    strSQL = strSQL + "LEDGER_OPENING_BALANCE FROM ACC_LEDGER  ";
                }
                else
                {
                    strSQL = "SELECT LEDGER_SERIAL,LEDGER_CODE AS code,TERRITORRY_NAME, LEDGER_NAME_MERZE , LEDGER_NAME,LEDGER_PARENT_GROUP,LEDGER_DEFAULT,";
                    strSQL = strSQL + "LEDGER_OPENING_BALANCE FROM ACC_LEDGER ";

                }
                strSQL = strSQL + "WHERE LEDGER_STATUS = " + intStatus + " ";
                if (mintLedgerGroup > 0)
                {
                    if (mintLedgerGroup == 4)
                    {
                        strSQL = strSQL + "AND LEDGER_PRIMARY_TYPE = 4 ";
                    }
                    else
                    {
                        if (mintLedgerGroup != 206)
                        {
                            strSQL = strSQL + "AND LEDGER_GROUP = " + mintLedgerGroup + " ";
                        }
                    }
                }
                else
                {
                    if (mintLedgerGroup != 206)
                    {
                        strSQL = strSQL + "AND LEDGER_GROUP not in (202,203,204)";
                    }
                }
                strSQL = strSQL + "ORDER BY LEDGER_NAME_MERZE ASC ";
            }
            else
            {
                strSQL = strMySQL;
                intStatus = intlaodType;
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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.lngSlno = Convert.ToInt64(drGetGroup["LEDGER_SERIAL"].ToString());
                    if (drGetGroup["code"].ToString() != "")
                    {
                        ogrp.strTeritorryCode = drGetGroup["code"].ToString();
                    }
                    else
                    {
                        ogrp.strTeritorryCode = "";
                    }
                    if (drGetGroup["TERRITORRY_NAME"].ToString() != "")
                    {
                        ogrp.strTeritoryyName = drGetGroup["TERRITORRY_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strTeritoryyName = "";
                    }

                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strmerzeString = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ogrp.intDefaultGroup = Convert.ToInt16(drGetGroup["LEDGER_DEFAULT"].ToString());
                    ogrp.strParentGroup = drGetGroup["LEDGER_PARENT_GROUP"].ToString();
                    ogrp.dblOpnBalance = Convert.ToDouble(drGetGroup["LEDGER_OPENING_BALANCE"].ToString());
                    //ogrp.strmerzeString = drGetGroup["code"].ToString() + drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strPreserveSQL = strSQL;
                    ogrp.intStatus = intStatus;
                    //ogrp.dblMpoPercentage = Convert.ToDouble(drGetGroup["PERCENTAGE"].ToString());
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        public List<AccountsVoucher> mFillLedgerListMpoPercen(string strDeComID, string strLedgerName, string strMPOName)
        {
            string strSQL;
            
            SqlDataReader drGetGroup;
            List<AccountsVoucher> ooLed = new List<AccountsVoucher>();
            strSQL = "SELECT PERCENTAGES,SAL_AMOUNT,EFFECTIVE_DATE FROM MPO_COMMISSION_PERCENTAGE ";
            strSQL = strSQL + "WHERE COMMISSION_LEDGER = '" + strLedgerName + "' ";
            strSQL = strSQL + "AND LEDGER_NAME = '" + strMPOName + "' ";
            //strSQL = strSQL + " ORDER By TERITORRY_CODE ASC ";
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
                if (drGetGroup.Read())
                {
                    AccountsVoucher ogrp = new AccountsVoucher();
                    ogrp.dblDebitAmount  = Convert.ToDouble(drGetGroup["PERCENTAGES"].ToString());
                    ogrp.dblCreditAmount = Convert.ToDouble(drGetGroup["SAL_AMOUNT"].ToString());
                    if (drGetGroup["EFFECTIVE_DATE"].ToString() != "")
                    {
                        ogrp.strDueDate = Convert.ToDateTime(drGetGroup["EFFECTIVE_DATE"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        ogrp.strDueDate = "";
                    }
                    ooLed.Add(ogrp);
                }
                if (!drGetGroup.HasRows)
                {
                    AccountsVoucher ogrp = new AccountsVoucher();
                    ogrp.dblDebitAmount = 0;
                    ogrp.dblDebitAmount = 0;
                    ogrp.strDueDate = "";
                    ooLed.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        public List<AccountsLedger> mFillLedgerListTARGET(string strDeComID, string strBranchID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> ooLed = new List<AccountsLedger>();

            strSQL = "SELECT  LEDGER_NAME_MERZE , LEDGER_NAME ";
            strSQL = strSQL + "FROM ACC_LEDGER WHERE LEDGER_STATUS =0 AND BRANCH_ID='" + strBranchID + "' ";
            strSQL = strSQL + "ORDER BY LEDGER_NAME_MERZE ASC ";
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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strmerzeString = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }

        public List<AccountsLedger> mFillLedgerList(string strDeComID, int mintLedgerGroup)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> ooLed = new List<AccountsLedger>();

            if (mintLedgerGroup == (int)Utility.GR_GROUP_TYPE.grCUSTOMER)
            {
                strSQL = "SELECT LEDGER_SERIAL,TERITORRY_CODE AS code,TERRITORRY_NAME, LEDGER_NAME_MERZE,LEDGER_NAME,LEDGER_PARENT_GROUP,LEDGER_DEFAULT,";
                strSQL = strSQL + "LEDGER_OPENING_BALANCE FROM ACC_LEDGER ";
            }
            else if (mintLedgerGroup == (int)Utility.GR_GROUP_TYPE.grSUPPLIER)
            {
                strSQL = "SELECT LEDGER_SERIAL,LEDGER_CODE AS code,HOMOEO_HALL as TERRITORRY_NAME,LEDGER_NAME_MERZE, LEDGER_NAME,LEDGER_PARENT_GROUP,LEDGER_DEFAULT,";
                strSQL = strSQL + "LEDGER_OPENING_BALANCE FROM ACC_LEDGER ";
            }
            else
            {
                strSQL = "SELECT LEDGER_SERIAL,LEDGER_CODE AS code,TERRITORRY_NAME, LEDGER_NAME_MERZE , LEDGER_NAME,LEDGER_PARENT_GROUP,LEDGER_DEFAULT,";
                strSQL = strSQL + "LEDGER_OPENING_BALANCE FROM ACC_LEDGER ";
               
            }
           
            if (mintLedgerGroup > 0)
            {
                if (mintLedgerGroup == 4)
                {
                    strSQL = strSQL + "WHERE LEDGER_PRIMARY_TYPE = 4 ";
                }
                else
                {
                    if (mintLedgerGroup != 206)
                    {
                        strSQL = strSQL + "WHERE LEDGER_GROUP = " + mintLedgerGroup + " ";
                    }
                }
            }
            else
            {
                if (mintLedgerGroup != 206)
                {
                    strSQL = strSQL + "WHERE LEDGER_GROUP not in (202,203,204)";
                }
            }
            if (mintLedgerGroup == (int)Utility.GR_GROUP_TYPE.grCUSTOMER)
            {
                strSQL = strSQL + "ORDER BY TERITORRY_CODE ASC ";
            }
            else
            {
                strSQL = strSQL + "ORDER BY LEDGER_NAME ASC ";
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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.lngSlno = Convert.ToInt64(drGetGroup["LEDGER_SERIAL"].ToString());
                    if (drGetGroup["code"].ToString() != "")
                    {
                        ogrp.strTeritorryCode = drGetGroup["code"].ToString();
                    }
                    else
                    {
                        ogrp.strTeritorryCode = "";
                    }
                    if (drGetGroup["TERRITORRY_NAME"].ToString() != "")
                    {
                        ogrp.strTeritoryyName = drGetGroup["TERRITORRY_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strTeritoryyName = "";
                    }

                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strmerzeString = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ogrp.intDefaultGroup = Convert.ToInt16(drGetGroup["LEDGER_DEFAULT"].ToString());
                    ogrp.strParentGroup = drGetGroup["LEDGER_PARENT_GROUP"].ToString();
                    ogrp.dblOpnBalance = Convert.ToDouble(drGetGroup["LEDGER_OPENING_BALANCE"].ToString());
                    //ogrp.strmerzeString = drGetGroup["code"].ToString() + drGetGroup["LEDGER_NAME"].ToString();

                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }

        public List<AccountsLedger> mDisplayLedgerList(string strDeComID, long vlngLedgerSerial)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooLed = new List<AccountsLedger>();

            strSQL = "SELECT * FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_SERIAL = " + vlngLedgerSerial + " ";

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                if (drGetGroup.Read())
                {
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strOldLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strUder = drGetGroup["LEDGER_PARENT_GROUP"].ToString();
                    ogrp.intLedgerPrimaryType = Convert.ToInt16(drGetGroup["LEDGER_PRIMARY_TYPE"].ToString());
                    ogrp.dblOpnBalance = Convert.ToDouble(drGetGroup["LEDGER_OPENING_BALANCE"].ToString());
                    ogrp.lngLedgerGroup = Convert.ToInt64(drGetGroup["LEDGER_GROUP"].ToString());
                    ogrp.intCostCenter = Convert.ToInt16(drGetGroup["LEDGER_VECTOR"].ToString());
                    if (drGetGroup["LEDGER_ADDRESS1"].ToString() != "")
                    {
                        ogrp.strAddress = drGetGroup["LEDGER_ADDRESS1"].ToString();
                    }
                    else
                    {
                        ogrp.strAddress = "";
                    }
                    if (drGetGroup["PF_LEDGER_NAME"].ToString() != "")
                    {
                        ogrp.strPFLedger = drGetGroup["PF_LEDGER_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strPFLedger = "";
                    }
                    if (drGetGroup["HL_LEDGER_NAME"].ToString() != "")
                    {
                        ogrp.strHLLedgerName = drGetGroup["HL_LEDGER_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strHLLedgerName = "";
                    }

                    ogrp.dblPFAmount = Utility.Val(drGetGroup["PF_AMOUNT"].ToString());
                    ogrp.strCurrency = drGetGroup["LEDGER_CURRENCY_SYMBOL"].ToString();
                    if (drGetGroup["LEDGER_ADDRESS2"].ToString() != "")
                    {
                        ogrp.strAddress2 = drGetGroup["LEDGER_ADDRESS2"].ToString();
                    }
                    else
                    {
                        ogrp.strAddress2 = "";
                    }
                    if (drGetGroup["LEDGER_CITY"].ToString() != "")
                    {
                        ogrp.strCity = drGetGroup["LEDGER_CITY"].ToString();
                    }
                    else
                    {
                        ogrp.strCity = "";
                    }
                    if (drGetGroup["LEDGER_POSTAL"].ToString() != "")
                    {
                        ogrp.strPostalCode = drGetGroup["LEDGER_POSTAL"].ToString();
                    }
                    else
                    {
                        ogrp.strPostalCode = "";
                    }
                    if (drGetGroup["LEDGER_PHONE"].ToString() != "")
                    {
                        ogrp.strPhone = drGetGroup["LEDGER_PHONE"].ToString();
                    }
                    else
                    {
                        ogrp.strPhone = "";
                    }
                    if (drGetGroup["LEDGER_FAX"].ToString() != "")
                    {
                        ogrp.strFax = drGetGroup["LEDGER_FAX"].ToString();
                    }
                    else
                    {
                        ogrp.strFax = "";
                    }
                    if (drGetGroup["LEDGER_EMAIL"].ToString() != "")
                    {
                        ogrp.strEmail = drGetGroup["LEDGER_EMAIL"].ToString();
                    }
                    else
                    {
                        ogrp.strEmail = "";
                    }

                    if (drGetGroup["TERITORRY_CODE"].ToString() != "")
                    {
                        ogrp.strTeritorryCode = drGetGroup["TERITORRY_CODE"].ToString();
                    }
                    else
                    {
                        ogrp.strTeritorryCode = "";
                    }

                    if (drGetGroup["TERRITORRY_NAME"].ToString() != "")
                    {
                        ogrp.strTerritoryName = drGetGroup["TERRITORRY_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strTerritoryName = "";
                    }
                    if (drGetGroup["CLOSE_DATE"].ToString() != "")
                    {
                        ogrp.strcloseDate = Convert.ToDateTime(drGetGroup["CLOSE_DATE"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        ogrp.strcloseDate = "";
                    }

                    ogrp.intBillwise = Convert.ToInt32(drGetGroup["LEDGER_BILL_WISE"].ToString());
                    ogrp.intInventoryEffect = Convert.ToInt32(drGetGroup["LEDGER_INVENTORY_AFFECT"].ToString());
                    ogrp.intStatus = Convert.ToInt32(drGetGroup["LEDGER_STATUS"].ToString());

                    if (drGetGroup["LEDGER_COMMENTS"].ToString() != "")
                    {
                        ogrp.strCommnents = drGetGroup["LEDGER_COMMENTS"].ToString();
                    }
                    else
                    {
                        ogrp.strCommnents = "";
                    }
                    if (drGetGroup["LEDGER_CREDIT_LIMIT"].ToString() != "")
                    {
                        ogrp.strCreditLimit = drGetGroup["LEDGER_CREDIT_LIMIT"].ToString();
                    }
                    else
                    {
                        ogrp.strCreditLimit = "";
                    }

                    if (drGetGroup["LEDGER_CREDIT_PERIOD"].ToString() != "")
                    {
                        ogrp.dblPeriod = Convert.ToDouble(drGetGroup["LEDGER_CREDIT_PERIOD"].ToString());
                    }
                    else
                    {
                        ogrp.dblPeriod = 0;
                    }
                    if (drGetGroup["LEDGER_CONTACT"].ToString() != "")
                    {
                        ogrp.strCantactPerson = drGetGroup["LEDGER_CONTACT"].ToString();
                    }
                    else
                    {
                        ogrp.strCantactPerson = "";
                    }
                    ogrp.lngCommType = Convert.ToInt64(drGetGroup["LEDGER_REP_COMMISSION_TYPE"].ToString());

                    if (drGetGroup["LEDGER_RESIGN_DATE"].ToString() != "")
                    {
                        ogrp.strResinDate = Convert.ToDateTime(drGetGroup["LEDGER_RESIGN_DATE"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        ogrp.strResinDate = "";
                    }

                    if (Convert.ToInt16(drGetGroup["LEDGER_COMMISSION"]) != 1)
                    {
                        ogrp.strCommission = "No";
                    }
                    else
                    {
                        ogrp.strCommission = "Yes";
                    }

                    if (drGetGroup["LEDGER_REP_NAME"].ToString() != "")
                    {
                        ogrp.strRepName = drGetGroup["LEDGER_REP_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strRepName = "";
                    }
                    if (drGetGroup["LEDGER_CLASS"].ToString() != "")
                    {
                        ogrp.strClass = drGetGroup["LEDGER_CLASS"].ToString();
                    }
                    else
                    {
                        ogrp.strClass = "";
                    }

                    if (drGetGroup["LEDGER_ADD_DATE"].ToString() != "")
                    {
                        ogrp.strCreditDate = Convert.ToDateTime(drGetGroup["LEDGER_ADD_DATE"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        ogrp.strCreditDate = "";
                    }

                    if (drGetGroup["LEDGER_CODE"].ToString() != "")
                    {
                        ogrp.strLedgerCode = drGetGroup["LEDGER_CODE"].ToString();
                    }
                    else
                    {
                        ogrp.strLedgerCode = "";
                    }
                    ogrp.dbltargetAmount = Convert.ToDouble(drGetGroup["LEDGER_TARGET"].ToString());

                    if (drGetGroup["HOMOEO_HALL"].ToString() != "")
                    {
                        ogrp.strhomoeohall = drGetGroup["HOMOEO_HALL"].ToString();
                    }
                    else
                    {
                        ogrp.strhomoeohall = "";
                    }
                    if (drGetGroup["BRANCH_ID"].ToString() != "")
                    {
                        ogrp.strBranchID = drGetGroup["BRANCH_ID"].ToString();
                    }
                    else
                    {
                        ogrp.strBranchID = "";
                    }
                    ogrp.intStatus = Convert.ToInt32(drGetGroup["LEDGER_STATUS"].ToString());
                    ogrp.intBkash = Convert.ToInt32(drGetGroup["BKASH_STATUS"].ToString());
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }

        public List<VectorCategory> mDisplayVectorCategory(string strDeComID, string strOldLedgerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<VectorCategory> ooLed = new List<VectorCategory>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM VECTOR_MASTER_CHILD WHERE MASTER_LEDGER_NAME  ";
            strSQL += "='" + strOldLedgerName + "' ";

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
                    VectorCategory ogrp = new VectorCategory();

                    ogrp.strBranchId = drGetGroup["BRANCH_ID"].ToString();
                    ogrp.strVectorcategory = drGetGroup["VECTOR_CATEGORY_NAME"].ToString();
                    ogrp.strCostCenter = drGetGroup["VMASTER_NAME"].ToString();
                    ogrp.dblAmount = Convert.ToDouble(drGetGroup["VCHILD_OPENING_BALANCE"].ToString());
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        public List<BranchConfig> mDisplayBranchOpening(string strDeComID, string strOldLedgerName, string strBranchID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<BranchConfig> ooLed = new List<BranchConfig>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM ACC_BRANCH_LEDGER_OPENING WHERE LEDGER_NAME  ";
            strSQL += "='" + strOldLedgerName + "' ";
            if (strBranchID !="")
            {
                strSQL = strSQL + "AND BRANCH_ID='" + strBranchID + "' ";
            }
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
                    BranchConfig ogrp = new BranchConfig();

                    ogrp.BranchID = drGetGroup["BRANCH_ID"].ToString();
                    ogrp.dblbranchOpening = Convert.ToDouble(drGetGroup["BRANCH_LEDGER_OPENING_BALANCE"].ToString());
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }

        public List<AccBillwise> mLoadBillWise(string strDeComID, string strOldLedgerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccBillwise> ooLed = new List<AccBillwise>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT BRANCH_ID,COMP_VOUCHER_DATE,SUBSTRING(COMP_REF_NO,7,30)COMP_REF_NO,OPENING_DATE,BILL_WISE_AMOUNT,BILL_WISE_TOBY FROM ACC_BILL_WISE WHERE LEDGER_NAME ";
            strSQL += "='" + strOldLedgerName + "' ";

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
                    AccBillwise ogrp = new AccBillwise();

                    BranchConfig obr = new BranchConfig();
                    obr.BranchID = drGetGroup["BRANCH_ID"].ToString();
                    ogrp.Branch = obr;
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["COMP_VOUCHER_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.strRefNo = drGetGroup["COMP_REF_NO"].ToString();
                    if (drGetGroup["OPENING_DATE"].ToString() != "")
                    {
                        ogrp.strDueDate = Convert.ToDateTime(drGetGroup["OPENING_DATE"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        ogrp.strDueDate = "";
                    }
                    ogrp.dblAmount = Convert.ToDouble(drGetGroup["BILL_WISE_AMOUNT"].ToString());
                    if (drGetGroup["BILL_WISE_TOBY"].ToString() == "DR")
                    {
                        ogrp.dblAmount = Convert.ToDouble(drGetGroup["BILL_WISE_AMOUNT"].ToString());
                    }
                    ogrp.strDrCr = drGetGroup["BILL_WISE_TOBY"].ToString();
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }

        public List<FixedAssets> mDisplayFixedAssest(string strDeComID, string strOldLedgerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<FixedAssets> ooLed = new List<FixedAssets>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM ACC_FIXED_ASSETS WHERE LEDGER_NAME  ";
            strSQL += "='" + strOldLedgerName + "' ";

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
                    FixedAssets ogrp = new FixedAssets();
                    //ogrp.BranchID = drGetGroup["BRANCH_ID"].ToString();
                    ogrp.dblPurchaseAmount = Convert.ToDouble(drGetGroup["ASSET_PURCHASE_COST"].ToString());
                    ogrp.strEffectiveDate = Convert.ToDateTime(drGetGroup["ASSET_DEP_EFF_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.dblDepRate = Convert.ToDouble(drGetGroup["ASSET_DEP_RATE"].ToString());
                    ogrp.dblAssetsLife = Convert.ToDouble(drGetGroup["ASSET_LIFE"].ToString());
                    ogrp.dblAccumulatedDep = Convert.ToDouble(drGetGroup["ASSET_ACCU_DEP"].ToString());
                    ogrp.dblWrittendownValue = Convert.ToDouble(drGetGroup["ASSET_WRITTEN_VALUE"].ToString());
                    ogrp.dblSalvageValue = Convert.ToDouble(drGetGroup["ASSET_SALVAGE_VALUE"].ToString());
                    if (Convert.ToInt32(drGetGroup["ASSET_DEP_METHOD"])==2)
                    {
                        ogrp.strDepMethod = "Straight Line";
                    }
                    else
                    {
                        ogrp.strDepMethod = "Reducing Balance";
                    }
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }

        public List<FixedAssets> mDisplayFixedAssestAccOpening(string strDeComID, string strOldLedgerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<FixedAssets> ooLed = new List<FixedAssets>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION WHERE LEDGER_NAME  ";
            strSQL += "='" + strOldLedgerName + "' ";

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
                    FixedAssets ogrp = new FixedAssets();
                    ogrp.strBranchID = drGetGroup["BRANCH_ID"].ToString();
                    ogrp.dblAccumulatedDep = Convert.ToDouble(drGetGroup["BRANCH_ACCUMULATED_DEPRECIATION"].ToString());

                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        public List<FixedAssets> mDisplayFixedAssestOpening(string strDeComID, string strOldLedgerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<FixedAssets> ooLed = new List<FixedAssets>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM ACC_FIXED_ASSET_PURCHASE_AMOUNT WHERE LEDGER_NAME  ";
            strSQL += "='" + strOldLedgerName + "' ";

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
                    FixedAssets ogrp = new FixedAssets();
                    ogrp.strBranchID = drGetGroup["BRANCH_ID"].ToString();
                    ogrp.dblAccumulatedDep = Convert.ToDouble(drGetGroup["BRANCH_PURCHASE_AMOUNT"].ToString());

                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        public string DeleteLedger(string strDeComID, long mlngGroupSerial)
        {
            long lngSerialfNo, lngDefaultLedger;
            double dblOldOpening=0;
            string strSQL, strResponse = "", strLedgerName = "", strReportGroup="";
            SqlDataReader rsget;
            lngSerialfNo = mlngGroupSerial;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                strSQL = "SELECT LEDGER_NAME,LEDGER_PARENT_GROUP, LEDGER_PRIMARY_GROUP,LEDGER_OPENING_BALANCE,LEDGER_CLOSING_BALANCE,LEDGER_DEFAULT ";
                strSQL = strSQL + "FROM ACC_LEDGER WHERE LEDGER_SERIAL = " + mlngGroupSerial + " ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                rsget = cmd.ExecuteReader();
                if (rsget.Read())
                {
                    strLedgerName = rsget["LEDGER_NAME"].ToString();
                    strReportGroup = rsget["LEDGER_PARENT_GROUP"].ToString();
                    //dblLedgeropnBalance = Utility.Val(rsget["LEDGER_OPENING_BALANCE"].ToString());
                    //dblLedgerClsBalance = Utility.Val(rsget["LEDGER_CLOSING_BALANCE"].ToString());
                    dblOldOpening = Utility.Val(rsget["LEDGER_OPENING_BALANCE"].ToString());
                    lngDefaultLedger = Convert.ToInt64(rsget["LEDGER_DEFAULT"].ToString());
                    if (lngDefaultLedger > 0)
                    {
                        strResponse = "Default Ledger Can't Delete";
                        return strResponse;
                    }
                }
                rsget.Close();
                strLedgerName = strLedgerName.Replace("'", "''");
                strSQL = "SELECT * FROM ACC_VOUCHER WHERE LEDGER_NAME = '" + strLedgerName + "' ";
                SqlCommand cmd1 = new SqlCommand(strSQL, gcnMain);
                rsget = cmd1.ExecuteReader();
                if (rsget.Read())
                {
                    strResponse = ("Related Data exists");
                    return strResponse;
                }
                rsget.Close();

                strSQL = "SELECT SALES_REP FROM ACC_COMPANY_VOUCHER where SALES_REP = '" + strLedgerName + "' ";
                SqlCommand cmd2 = new SqlCommand(strSQL, gcnMain);
                rsget = cmd2.ExecuteReader();
                if (rsget.Read())
                {
                    strResponse = ("Related Data exists");
                    return strResponse;
                }
                rsget.Close();
                strSQL = "SELECT * FROM ACC_FIXED_ASSETS  where LEDGER_NAME  = '" + strLedgerName + "' ";
                SqlCommand cmd3 = new SqlCommand(strSQL, gcnMain);
                rsget = cmd3.ExecuteReader();
                if (rsget.Read())
                {
                    strResponse = ("First Delete Fixed Asset configuration");
                    return strResponse;
                }
                rsget.Close();

                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                //if (dblLedgeropnBalance < 0)
                //{
                //    strSQL = "SELECT ISNULL(sum(LEDGER_OPENING_BALANCE),0) OPN,isnull(sum(LEDGER_CLOSING_BALANCE),0) CLS from ACC_LEDGER ";
                //    strSQL = strSQL + "where LEDGER_OPENING_BALANCE < 0 AND LEDGER_PARENT_GROUP= '" + strReportGroup + "'";
                //}
                //else
                //{
                //    strSQL = "SELECT ISNULL(sum(LEDGER_OPENING_BALANCE),0) OPN,isnull(sum(LEDGER_CLOSING_BALANCE),0) CLS from ACC_LEDGER ";
                //    strSQL = strSQL + "where LEDGER_OPENING_BALANCE > 0 AND LEDGER_PARENT_GROUP= '" + strReportGroup + "'";
                //}

                ////strSQL = "SELECT isnull(OPN,0) OPN, isnull(CLS,0) CLS FROM ACC_LEDGERGROUP_QRY1 WHERE GR_NAME= '" + strReportGroup + "'";
                //cmdInsert.CommandText = strSQL;
                //rsget = cmdInsert.ExecuteReader();
                //if (rsget.Read())
                //{
                //    dblOpn = Utility.Val(rsget["OPN"].ToString()) - dblLedgeropnBalance;
                //    dblCls = Utility.Val(rsget["CLS"].ToString()) - dblLedgerClsBalance;
                //}

                //rsget.Close();

                //List<AccountsLedger> oaccLedger = new List<AccountsLedger>();
                //strSQL = "SELECT GR_NAME FROM ACC_LEDGER_TO_GROUP WHERE LEDGER_NAME = '" + strLedgerName + "'";
                //cmdInsert.CommandText = strSQL;
                //rsget = cmdInsert.ExecuteReader();
                //while (rsget.Read())
                //{
                //    AccountsLedger oacc = new AccountsLedger();
                //    oacc.strParentGroup = rsget["GR_NAME"].ToString() + "~";
                //    oaccLedger.Add(oacc);
                //    //if (dblLedgeropnBalance < 0)
                //    //{
                //    //    lngStatus = Utility.glngAddGroupOpeninDebit(rsget["GR_NAME"].ToString().Replace("'", "''"), dblOpn, dblCls);
                //    //}
                //    //else
                //    //{
                //    //    lngStatus = Utility.glngAddGroupOpeninCredit(rsget["GR_NAME"].ToString().Replace("'", "''"), dblOpn, dblCls);
                //    //}
                //}
                //rsget.Close();

                //if (oaccLedger.Count>0)
                //{
                //    foreach(AccountsLedger objAcc in oaccLedger)
                //    {
                //        strSQL = "UPDATE ACC_LEDGERGROUP SET ";
                //        if (dblLedgeropnBalance < 0)
                //        {
                //            strSQL = strSQL + "GR_OPENING_DEBIT = GR_OPENING_DEBIT - " + dblLedgeropnBalance + " ";
                //            strSQL = strSQL + ",GR_CLOSING_DEBIT = GR_CLOSING_DEBIT - " + dblLedgeropnBalance + " ";
                //        }
                //        else
                //        {
                //            strSQL = strSQL + "GR_OPENING_CREDIT = GR_OPENING_CREDIT - " + dblLedgeropnBalance + " ";
                //            strSQL = strSQL + ",GR_CLOSING_CREDIT = GR_CLOSING_CREDIT - " + dblLedgeropnBalance + " ";
                //        }

                //        strSQL = strSQL + "WHERE GR_NAME = '" + objAcc.strParentGroup + "'";
                //        //strSQL = "SELECT GR_OPENING_DEBIT,GR_CLOSING_DEBIT FROM ACC_LEDGERGROUP WHERE LEDGER_NAME = '" + strLedgerName + "'";
                //        cmdInsert.CommandText = strSQL;
                //        cmdInsert.ExecuteNonQuery();
                //        //if (rsget.Read())
                //        //{
                //        //    rsget.Close();
                //        //    strSQL ="update GR_OPENING_DEBIT="
                //        //}
                //    }
                //}
                strSQL = "UPDATE ACC_LEDGER_GROUP_QRY ";
                strSQL = strSQL + "SET ";
                if (dblOldOpening <= 0)
                {
                    strSQL = strSQL + "GR_OPENING_DEBIT = GR_OPENING_DEBIT - " + dblOldOpening + ", ";
                    strSQL = strSQL + "GR_CLOSING_DEBIT = GR_CLOSING_DEBIT - " + dblOldOpening + " ";
                }
                if (dblOldOpening > 0)
                {
                    strSQL = strSQL + "GR_OPENING_CREDIT = GR_OPENING_CREDIT - " + dblOldOpening + ", ";
                    strSQL = strSQL + "GR_CLOSING_CREDIT = GR_CLOSING_CREDIT - " + dblOldOpening + " ";
                }
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strLedgerName + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "DELETE FROM ACC_BRANCH_LEDGER_OPENING ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strLedgerName + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM ACC_STOCK_IN_HAND WHERE LEDGER_NAME ='" + strLedgerName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Delete Different from Ledger
                strSQL = "DELETE FROM ACC_LEDGER_TO_GROUP ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strLedgerName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM VECTOR_MASTER_CHILD ";
                strSQL = strSQL + "WHERE MASTER_LEDGER_NAME = '" + strLedgerName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM ACC_BILL_WISE ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strLedgerName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM INV_SALESREPSENTIVE ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strLedgerName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM USER_ONLILE_SECURITY ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strLedgerName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM ACC_LEDGER ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strLedgerName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                

                
                cmdInsert.Transaction.Commit();
                cmdInsert.Dispose();
                strResponse = "Deleted....";

            }

            return strResponse;


        }

        #endregion
        #region "Insert Compnay Voucher"

        public string gInsertCompanyVoucherNew(string strDeComID, string vstrRefNumber,
                                            long vlngVoucherType,
                                            string vdteDate,
                                            string vstrMonthID,
                                            string vdteDueDate,
                                            string vstrLedgerName,
                                            double vdblAmount,
                                            double vdblNetAmount,
                                            double vdblAddAmount,
                                            double vdblLessAmount,
                                            long vlngAgstType,
                                            string vstrNarrations,
                                            string vstrBranchID,
                                            long vlngIsMultiCurrency = 0,
                                            string vstrAgnstRefNo = "",
                                            string vstrSalesRep = "",
                                            string vstrDelivery = "",
                                            string vstrPayment = "",
                                            string vstrSupport = "",
                                            string vstrValidaty = "",
                                            string vstrOtherTerms = "",
                                            int intSpJounal = 0)
        {

            string strSQL;
            strSQL = "INSERT INTO ACC_COMPANY_VOUCHER";
            strSQL = strSQL + "(BRANCH_ID,COMP_REF_NO,COMP_VOUCHER_MONTH_ID,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,COMP_VOUCHER_DUE_DATE,";
            strSQL = strSQL + "LEDGER_NAME,COMP_VOUCHER_AMOUNT,COMP_VOUCHER_NET_AMOUNT,";
            strSQL = strSQL + "COMP_VOUCHER_ADD_AMOUNT,COMP_VOUCHER_LESS_AMOUNT,";
            strSQL = strSQL + "COMP_AGAINST_REF,COMP_VOUCHER_FC";
            if (vstrNarrations != "")
            {
                strSQL = strSQL + ",COMP_VOUCHER_NARRATION ";
            }
            if (vstrAgnstRefNo != "")
            {
                strSQL = strSQL + ",AGNST_COMP_REF_NO,COMP_VOUCHER_IS_AUTO ";
            }
            if (vstrSalesRep != "")
            {
                strSQL = strSQL + ",SALES_REP ";
            }
            if (vstrDelivery != "")
            {
                strSQL = strSQL + ",COMP_DELIVERY ";
            }
            if (vstrPayment != "")
            {
                strSQL = strSQL + ",COMP_TERM_OF_PAYMENTS ";
            }
            if (vstrSupport != "")
            {
                strSQL = strSQL + ",COMP_SUPPORT ";
            }
            if (vstrValidaty != "")
            {
                strSQL = strSQL + ",COMP_VALIDITY_DATE ";
            }
            if (vstrOtherTerms != "")
            {
                strSQL = strSQL + ",COMP_OTHERS ";
            }
            strSQL = strSQL + ",SP_JOURNAL ";
            strSQL = strSQL + ") ";
            strSQL = strSQL + "VALUES(";
            strSQL = strSQL + "'" + vstrBranchID + "',";
            strSQL = strSQL + "'" + vstrRefNumber.Trim() + "',";
            strSQL = strSQL + "'" + vstrMonthID + "',";
            strSQL = strSQL + " " + vlngVoucherType + ",";
            //strSQL = strSQL + "Convert (DateTime  ,'" + vdteDate + "', 103) ,";
            strSQL = strSQL + " " + Utility.cvtSQLDateString(vdteDate) + ",";
            //strSQL = strSQL + "Convert (DateTime  ,'" + vdteDate + "', 103) ,";
            strSQL = strSQL + " " + Utility.cvtSQLDateString(vdteDate) + ",";
            strSQL = strSQL + "'" + vstrLedgerName + "',";
            strSQL = strSQL + " " + vdblAmount + ",";
            strSQL = strSQL + " " + vdblNetAmount + ",";
            strSQL = strSQL + " " + vdblAddAmount + ",";
            strSQL = strSQL + " " + vdblLessAmount + ",";
            strSQL = strSQL + " " + vlngAgstType + ",";
            strSQL = strSQL + " " + vlngIsMultiCurrency + "";
            if (vstrNarrations != "")
            {
                strSQL = strSQL + ",'" + vstrNarrations + "'";
            }
            if (vstrAgnstRefNo != "")
            {
                strSQL = strSQL + ",'" + vstrAgnstRefNo + "'";
                strSQL = strSQL + ",1";
            }
            if (vstrSalesRep != "")
            {
                strSQL = strSQL + ",'" + vstrSalesRep + "' ";
            }
            if (vstrDelivery != "")
            {
                strSQL = strSQL + ",'" + vstrDelivery + "' ";
            }
            if (vstrPayment != "")
            {
                strSQL = strSQL + ",'" + vstrPayment + "' ";
            }
            if (vstrSupport != "")
            {
                strSQL = strSQL + ",'" + vstrSupport + "' ";
            }
            if (vstrValidaty != "")
            {
                //strSQL = strSQL + ",Convert (DateTime  ,'" + vstrValidaty + "', 103) ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(vstrValidaty) + ",";
            }
            if (vstrOtherTerms != "")
            {
                strSQL = strSQL + ",'" + vstrOtherTerms + "' ";
            }
            strSQL = strSQL + "," + intSpJounal + " ";
            strSQL = strSQL + ")";

            return strSQL;



        }



        public string gInsertCompanyVoucher(string strDeComID, string vstrRefNumber,
                                            long vlngVoucherType,
                                            string vdteDate,
                                            string vstrMonthID,
                                            string vdteDueDate,
                                            string vstrLedgerName,
                                            double vdblAmount,
                                            double vdblNetAmount,
                                            double vdblAddAmount,
                                            double vdblLessAmount,
                                            long vlngAgstType,
                                            string vstrNarrations,
                                            string vstrBranchID,
                                            long vlngIsMultiCurrency = 0,
                                            string vstrAgnstRefNo = "",
                                            string vstrSalesRep = "",
                                            string vstrDelivery = "",
                                            string vstrPayment = "",
                                            string vstrSupport = "",
                                            string vstrValidaty = "",
                                            string vstrOtherTerms = "",
                                            int intSpJounal=0)
        {

            string strSQL, strResponse = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();


                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;

                strSQL = "INSERT INTO ACC_COMPANY_VOUCHER";
                strSQL = strSQL + "(BRANCH_ID,COMP_REF_NO,COMP_VOUCHER_MONTH_ID,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,COMP_VOUCHER_DUE_DATE,";
                strSQL = strSQL + "LEDGER_NAME,COMP_VOUCHER_AMOUNT,COMP_VOUCHER_NET_AMOUNT,";
                strSQL = strSQL + "COMP_VOUCHER_ADD_AMOUNT,COMP_VOUCHER_LESS_AMOUNT,";
                strSQL = strSQL + "COMP_AGAINST_REF,COMP_VOUCHER_FC";
                if (vstrNarrations != "")
                {
                    strSQL = strSQL + ",COMP_VOUCHER_NARRATION ";
                }
                if (vstrAgnstRefNo != "")
                {
                    strSQL = strSQL + ",AGNST_COMP_REF_NO,COMP_VOUCHER_IS_AUTO ";
                }
                if (vstrSalesRep != "")
                {
                    strSQL = strSQL + ",SALES_REP ";
                }
                if (vstrDelivery != "")
                {
                    strSQL = strSQL + ",COMP_DELIVERY ";
                }
                if (vstrPayment != "")
                {
                    strSQL = strSQL + ",COMP_TERM_OF_PAYMENTS ";
                }
                if (vstrSupport != "")
                {
                    strSQL = strSQL + ",COMP_SUPPORT ";
                }
                if (vstrValidaty != "")
                {
                    strSQL = strSQL + ",COMP_VALIDITY_DATE ";
                }
                if (vstrOtherTerms != "")
                {
                    strSQL = strSQL + ",COMP_OTHERS ";
                }
                strSQL = strSQL + ",SP_JOURNAL ";
                strSQL = strSQL + ") ";
                strSQL = strSQL + "VALUES(";
                strSQL = strSQL + "'" + vstrBranchID + "',";
                strSQL = strSQL + "'" + vstrRefNumber.Trim() + "',";
                strSQL = strSQL + "'" + vstrMonthID + "',";
                strSQL = strSQL + " " + vlngVoucherType + ",";
                //strSQL = strSQL + "Convert (DateTime  ,'" + vdteDate + "', 103) ,";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(vdteDate) + ",";
                //strSQL = strSQL + "Convert (DateTime  ,'" + vdteDate + "', 103) ,";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(vdteDate) + ",";
                strSQL = strSQL + "'" + vstrLedgerName + "',";
                strSQL = strSQL + " " + vdblAmount + ",";
                strSQL = strSQL + " " + vdblNetAmount + ",";
                strSQL = strSQL + " " + vdblAddAmount + ",";
                strSQL = strSQL + " " + vdblLessAmount + ",";
                strSQL = strSQL + " " + vlngAgstType + ",";
                strSQL = strSQL + " " + vlngIsMultiCurrency + "";
                if (vstrNarrations != "")
                {
                    strSQL = strSQL + ",'" + vstrNarrations + "'";
                }
                if (vstrAgnstRefNo != "")
                {
                    strSQL = strSQL + ",'" + vstrAgnstRefNo + "'";
                    strSQL = strSQL + ",1";
                }
                if (vstrSalesRep != "")
                {
                    strSQL = strSQL + ",'" + vstrSalesRep + "' ";
                }
                if (vstrDelivery != "")
                {
                    strSQL = strSQL + ",'" + vstrDelivery + "' ";
                }
                if (vstrPayment != "")
                {
                    strSQL = strSQL + ",'" + vstrPayment + "' ";
                }
                if (vstrSupport != "")
                {
                    strSQL = strSQL + ",'" + vstrSupport + "' ";
                }
                if (vstrValidaty != "")
                {
                    //strSQL = strSQL + ",Convert (DateTime  ,'" + vstrValidaty + "', 103) ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(vstrValidaty) + ",";
                }
                if (vstrOtherTerms != "")
                {
                    strSQL = strSQL + ",'" + vstrOtherTerms + "' ";
                }
                strSQL = strSQL + "," + intSpJounal + " ";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                try
                {
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Dispose();
                }

                catch (Exception ex)
                {
                    strResponse = ex.ToString();
                }
            }
            return strResponse;



        }
        #endregion
        #region "Insert Voucher"
        public string SaveVoucher(string strDeComID, string strVoucherGrid, string vstrDrcr, string vstrRefNumber, long vlngVoucherType, string vdteDate, string vstrMonthID, string vdteDueDate, string vstrLedgerName,
                                                string vstrReverseLedgerName, int intvoucherPosition, long lngCashFlow, string vstrVoyageNo, double vdblAmount, double vdblNetAmount,
                                                double vdblAddAmount, double vdblLessAmount, double vdblDebitAmount, double vdblCreditAmount, double dblFCCurrencyDebit, double dblFCCurrencyCredit,
                                                string mstrFCsymbol, double mdblCurrRate, long vlngAgstType, string vstrSingleNarration, string vstrNarratirons, string vstrBranchID,
                                                string DgCostCenter, string DGBillWise, bool blngNumMethod, long vlngIsMultiCurrency = 0,
                                                string vstrChecuqNo = "", string vstrChequedate = "", string vstrDrawnon = "", string vstrAgnstRefNo = "", string vstrSalesRep = "", string vstrDelivery = "",
                                                string vstrPayment = "", string vstrSupport = "", string vstrValidaty = "", string vstrOtherTerms = "",int SpJounal=0,
                                                string strDginvEffect = "", string strGrdTemPlate = "", string strGrdTemPlateJV="",int intLoanTransfer=0)
        {

            string strSQL = "", strBillWiseRef = "",strLoanTo="";
            short lnglType = 1;
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
                    string i = gInsertCompanyVoucherNew(strDeComID, vstrRefNumber, vlngVoucherType, vdteDate, vstrMonthID, vdteDueDate, vstrLedgerName, vdblAmount, vdblNetAmount,
                                                    vdblAddAmount, vdblLessAmount, vlngAgstType, vstrNarratirons, vstrBranchID, vlngIsMultiCurrency, vstrAgnstRefNo,
                                                    vstrSalesRep, vstrDelivery, vstrPayment, vstrSupport, vstrValidaty, vstrOtherTerms, SpJounal);
                    cmdInsert.CommandText = i;
                    cmdInsert.ExecuteNonQuery();
                    if (strVoucherGrid != "")
                    {
                        string[] words = strVoucherGrid.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                
                                strBillWiseRef = vstrRefNumber + intvoucherPosition.ToString("0000");
                                strSQL = "INSERT INTO ACC_VOUCHER";
                                strSQL = strSQL + "(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,COMP_VOUCHER_TYPE,";
                                strSQL = strSQL + "COMP_VOUCHER_DATE,COMP_VOUCHER_POSITION,LEDGER_NAME,";
                                if (oAssets[9] != "")
                                {
                                    strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER,";
                                }
                                if (oAssets[10] != "")
                                {
                                    strSQL = strSQL + "VOUCHER_CHEQUE_DATE,";
                                }
                                if (oAssets[11] != "")
                                {
                                    strSQL = strSQL + "VOUCHER_CHEQUE_DRAWN_ON,";
                                }
                                //if (Utility.glngIsMaintainBatch == 1)
                                //{
                                //    if (vstrVoyageNo != Utility.gcEND_OF_LIST)
                                //    {
                                //        strSQL = strSQL + "INV_LOG_NO,";
                                //    }
                                //}
                                strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,VOUCHER_CASHFLOW ";
                                if (mdblCurrRate != 0)
                                {
                                    strSQL = strSQL + ",VOUCHER_FC_DEBIT_AMOUNT,VOUCHER_FC_CREDIT_AMOUNT, ";
                                    strSQL = strSQL + "VOUCHER_CURRENCY_SYMBOL,FC_CONVERSION_RATE";
                                }
                                else
                                {
                                    strSQL = strSQL + ",VOUCHER_CURRENCY_SYMBOL";
                                }

                                if (vstrSingleNarration != "")
                                {
                                    strSQL = strSQL + ",VOUCHER_NARRATION";
                                }
                                strSQL = strSQL + ",AGNST_COMP_REF_NO,TRANSFER_TYPE ";
                                strSQL = strSQL + ") VALUES(";
                                strSQL = strSQL + "'" + vstrBranchID + "',";
                                strSQL = strSQL + "'" + strBillWiseRef + "','" + vstrRefNumber + "',";
                                strSQL = strSQL + " " + vlngVoucherType + "," + Utility.cvtSQLDateString(vdteDate) + ",";
                                strSQL = strSQL + " " + intvoucherPosition + ",'" + oAssets[1] + "',";
                              
                                if (oAssets[9] != "")
                                {
                                    strSQL = strSQL + "'" + oAssets[9] + "',";
                                }
                                if (oAssets[10] != "")
                                {
                                    strSQL = strSQL + " " + Utility.cvtSQLDateString(oAssets[10]) + ",";
                                }
                                if (oAssets[11] != "")
                                {
                                    strSQL = strSQL + "'" + oAssets[11] + "',";
                                }
                                //if (Utility.glngIsMaintainBatch == 1)
                                //{
                                //    if (vstrVoyageNo != Utility.gcEND_OF_LIST)
                                //    {
                                //        strSQL = strSQL + "'" + vstrVoyageNo + "',";
                                //    }
                                //}
                                strSQL = strSQL + " " + oAssets[5] + "," + oAssets[6] + ",";
                                strSQL = strSQL + "'" + oAssets[0] + "' ";
                                strSQL = strSQL + ",'" + oAssets[2] + "'," + oAssets[3] + " ";
                                if (mdblCurrRate != 0)
                                {
                                    strSQL = strSQL + "," + dblFCCurrencyDebit + "," + dblFCCurrencyCredit + ",";
                                    strSQL = strSQL + "'" + mstrFCsymbol + "'," + mdblCurrRate + " ";
                                }
                                else
                                {
                                    strSQL = strSQL + ",'" + Utility.gstrBaseCurrency + "' ";
                                }
                                if (vstrSingleNarration != "")
                                {
                                    strSQL = strSQL + ",'" + oAssets[6] + "' ";
                                }
                                strSQL = strSQL + ",'" + oAssets[12] + "' ";
                                strSQL = strSQL + "," + intLoanTransfer;
                                strSQL = strSQL + ")";

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                               if (intvoucherPosition ==2)
                               {
                                   strLoanTo = oAssets[1];
                               }
                                intvoucherPosition += 1;

                            }
                        }
                    }

                    if (intLoanTransfer == 3)
                    {
                        strSQL = "UPDATE ACC_PAYMENT_SCHEDULE SET ";
                        strSQL = strSQL + "LEDGER_NAME='" + vstrLedgerName.Replace("'", "''") + "' ";
                        strSQL = strSQL + ",FROM_LEDGER_NAME='" + strLoanTo.Replace("'", "''") + "' ";
                        strSQL = strSQL + ",TRANSFER_TYPE='T' ";
                        strSQL = strSQL + ",NARRATION ='" + vstrRefNumber + "' ";
                        strSQL = strSQL + "WHERE LEDGER_NAME ='" + strLoanTo.Replace("'", "''") + "' ";
                        strSQL = strSQL + "AND TO_BY ='Dr' and INSTALL_STATUS =0 and TRANSFER_TYPE='N' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    if (DgCostCenter != "")
                    {
                        string[] words = DgCostCenter.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                strSQL = Voucher.mInsertVector(vstrRefNumber, oAssets[1].ToString(), oAssets[2].ToString(), vdteDate, oAssets[0].ToString(),
                                                             oAssets[4].ToString(), lnglType, lnglType, 1, vstrBranchID, Utility.Val(oAssets[3].ToString()), 0, "", vlngVoucherType);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lnglType += 1;
                            }
                        }
                    }

                    if (DGBillWise != "")
                    {
                        int intbillpos = 1;
                        string strAgstRefNo = "";
                        string[] words = DGBillWise.Split('~');
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('|');
                            if (ooCost[0] != "")
                            {
                                strAgstRefNo = vstrBranchID + ooCost[2].ToString();
                                strSQL = Voucher.gInsertBillWise(vstrBranchID, vstrRefNumber, vdteDate, vlngVoucherType, ooCost[0].ToString(), intbillpos, ooCost[1].ToString(),
                                                                    Utility.Val(ooCost[4].ToString()), ooCost[5].ToString(), strAgstRefNo, intbillpos);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                intbillpos += 1;
                            }
                        }
                    }
                    if (strDginvEffect !="")
                    {
                        strSQL = Voucher.gInsertmaster(vstrRefNumber, vstrBranchID, vlngVoucherType, vdteDate, vdblNetAmount,
                                                    vstrNarratirons, "", 0, "", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        string strBillKey = "";
                        long lngloop = 1;
                        string[] words = strDginvEffect.Split('~');
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('|');
                            if (ooCost[0] != "")
                            {
                                strBillKey = vstrRefNumber + lngloop.ToString().PadLeft(4, '0');
                                strSQL = Voucher.mInsertTranOutward(strBillKey, lngloop, vstrRefNumber, ooCost[1].ToString(), vlngVoucherType,
                                                                                 vdteDate, Utility.Val(ooCost[2].ToString()), Utility.Val(ooCost[4].ToString()),ooCost[0].ToString(), Utility.Val(ooCost[5].ToString()), "O",
                                                                                 vstrBranchID, "", "", ooCost[3].ToString(), ooCost[3].ToString(), "");

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lngloop += 1;
                            }
                        }
                       
                    }

                    if (strGrdTemPlate !="")
                    {
                        string[] words = strGrdTemPlate.Split('~');
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('|');
                            if (ooCost[0] != "")
                            {

                                strSQL = "INSERT INTO ACC_PAYMENT_SCHEDULE(COMP_REF_NO ,LEDGER_NAME,TEMPLATE_NAME,INSTALLMET_NAME,DUE_DATE,MONTHLY_AMOUNT,TO_BY)";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + vstrRefNumber + "'";
                                strSQL = strSQL + ",'" + ooCost[0] + "'";
                                strSQL = strSQL + ",'" + ooCost[1] + "'";
                                strSQL = strSQL + ",'" + ooCost[2].Replace("'", "''") + "'";
                                strSQL = strSQL + "," + Utility.cvtSQLDateString(ooCost[3].ToString()) + "";
                                strSQL = strSQL + "," + Utility.Val(ooCost[4]) + " ";
                                strSQL = strSQL + ",'Dr' ";
                                strSQL = strSQL + ") ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                               
                            }
                        }
                    }
                    if (strGrdTemPlateJV != "")
                    {
                        string[] words = strGrdTemPlateJV.Split('~');
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('|');
                            if (ooCost[0] != "")
                            {

                                strSQL = "INSERT INTO ACC_PAYMENT_SCHEDULE(COMP_REF_NO ,LEDGER_NAME,TEMPLATE_NAME,INSTALLMET_NAME,DUE_DATE,RECEIVE_DATE,RECEIVED_AMOUNT,MONTHLY_AMOUNT,FINE_AMOUNT,TO_BY)";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + vstrRefNumber + "'";
                                strSQL = strSQL + ",'" + ooCost[0].Replace("'", "''") + "'";
                                strSQL = strSQL + ",'" + ooCost[1].Replace("'", "''") + "'";
                                strSQL = strSQL + ",'" + ooCost[2].Replace("'", "''") + "'";
                                strSQL = strSQL + "," + Utility.cvtSQLDateString(ooCost[3].ToString()) + "";
                                strSQL = strSQL + "," + Utility.cvtSQLDateString(ooCost[4].ToString()) + "";
                                strSQL = strSQL + "," + Utility.Val(ooCost[5]) *-1 + " ";
                                strSQL = strSQL + "," + Utility.Val(ooCost[5]) * -1 + " ";
                                strSQL = strSQL + "," + Utility.Val(ooCost[6]) + " ";
                                strSQL = strSQL + ",'Cr' ";
                                strSQL = strSQL + ") ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                strSQL = "UPDATE ACC_PAYMENT_SCHEDULE SET INSTALL_STATUS=1 ";
                                strSQL = strSQL + " WHERE LEDGER_NAME='" + ooCost[0].Replace("'", "''") + "'";
                                strSQL = strSQL + " AND TEMPLATE_NAME='" + ooCost[1].Replace("'", "''") + "'";
                                strSQL = strSQL + " AND INSTALLMET_NAME='" + ooCost[2].Replace("'", "''") + "'";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }

                 


                    if (blngNumMethod)
                    {
                        strSQL = Voucher.gIncreaseVoucher((int)vlngVoucherType);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    cmdInsert.Transaction.Commit();
                    cmdInsert.Dispose();
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }
        public List<AccountsVoucher> mGetRefNo(string strDeComID, int mintVType, string mdteVFromDate, string mdteVToDate,int intSP)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsVoucher> ooAccLedger = new List<AccountsVoucher>();
            SqlCommand cmdInsert = new SqlCommand();

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                cmdInsert.Connection = gcnMain;
                strSQL = "SELECT COMP_REF_NO FROM ACC_COMPANY_VOUCHER ";
                strSQL = strSQL + " WHERE COMP_VOUCHER_TYPE = " + mintVType + " ";
                strSQL = strSQL + " AND SP_JOURNAL = " + intSP + " ";
                if (mdteVFromDate != "")
                {
                    strSQL = strSQL + "AND COMP_VOUCHER_DATE BETWEEN ";
                    strSQL = strSQL + Utility.cvtSQLDateString(mdteVFromDate) + " ";
                    strSQL = strSQL + "AND ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(mdteVToDate) + " ";
                }
                strSQL = strSQL + "ORDER by COMP_REF_NO";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AccountsVoucher oLedg = new AccountsVoucher();
                    oLedg.strVoucherNo = dr["COMP_REF_NO"].ToString();
                    oLedg.strOrderNo = Utility.Mid(dr["COMP_REF_NO"].ToString(), 6, dr["COMP_REF_NO"].ToString().Length - 6);
                    ooAccLedger.Add(oLedg);
                }
                return ooAccLedger;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }
        }


        //public List<AccountsVoucher> mOpenTable(string strDeComID, int mintVType, string strFind, string strExpression, string mdteVFromDate = "", string mdteVToDate = "", int intSPJ = 0,string strmySql="")
        //{
        //    string strSQL = null;
        //    SqlDataReader dr;
        //    List<AccountsVoucher> ooAccLedger = new List<AccountsVoucher>();
        //    SqlCommand cmdInsert = new SqlCommand();
        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();

        //        cmdInsert.Connection = gcnMain;
        //        if (strmySql == "")
        //        {
        //            if (mintVType == 1)
        //            {

        //                //strSQL = "SELECT ACC_VOUCHER.COMP_REF_NO ,ACC_VOUCHER.COMP_VOUCHER_TYPE,ACC_VOUCHER.COMP_VOUCHER_DATE,ACC_LEDGER.LEDGER_NAME_MERZE ,ACC_LEDGER.LEDGER_NAME  ,";
        //                //strSQL = strSQL + "ACC_VOUCHER.VOUCHER_REVERSE_LEDGER,  ACC_BRANCH.BRANCH_NAME, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT, ";
        //                //strSQL = strSQL + " ACC_LEDGER.LEDGER_NAME_MERZE  ";
        //                //strSQL = strSQL + " FROM ACC_VOUCHER,ACC_BRANCH,ACC_LEDGER,ACC_COMPANY_VOUCHER  WHERE ACC_COMPANY_VOUCHER.COMP_REF_NO =ACC_VOUCHER.COMP_REF_NO AND ACC_LEDGER.LEDGER_NAME =ACC_COMPANY_VOUCHER.LEDGER_NAME  AND ";
        //                //strSQL = strSQL + " ACC_BRANCH.BRANCH_ID =ACC_VOUCHER.BRANCH_ID  AND ACC_VOUCHER.VOUCHER_TOBY ='Cr' ";
        //                //strSQL = strSQL + " AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = " + mintVType + " ";
        //                //strSQL = strSQL + " AND ACC_COMPANY_VOUCHER.SP_JOURNAL= " + intSPJ + " ";
        //                //strSQL = strSQL + " AND ACC_COMPANY_VOUCHER.SAMPLE_STATUS=0 ";
        //                strSQL = "SELECT COMP_REF_NO,REF_NO,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
        //                strSQL = strSQL + "LEDGER_NAME , BRANCH_NAME, COMP_VOUCHER_AMOUNT, COMP_VOUCHER_NET_AMOUNT,LEDGER_CODE,LEDGER_NAME_MERZE, '' VOUCHER_REVERSE_LEDGER ";
        //                strSQL = strSQL + "From ACC_COMPANY_VOUCHER_BRANCH_VIEW ";
        //                strSQL = strSQL + "WHERE COMP_VOUCHER_TYPE = " + mintVType + " ";
        //                strSQL = strSQL + " AND SP_JOURNAL= " + intSPJ + " ";
        //                strSQL = strSQL + " AND SAMPLE_STATUS=0 ";

        //                if (strFind == "Voucher Number")
        //                {
        //                    strSQL = strSQL + "AND COMP_REF_NO like '%" + strExpression + "%'";
        //                }
        //                else if (strFind == "Voucher Date")
        //                {
        //                    strSQL = strSQL + "AND COMP_VOUCHER_DATE BETWEEN ";
        //                    strSQL = strSQL + Utility.cvtSQLDateString(mdteVFromDate) + " ";
        //                    strSQL = strSQL + "AND ";
        //                    strSQL = strSQL + " " + Utility.cvtSQLDateString(mdteVToDate) + " ";
        //                }
        //                else if (strFind == "Ledger Name")
        //                {
        //                    strSQL = strSQL + "AND LEDGER_NAME = '" + strExpression + "'";
        //                }
        //                else if (strFind == "Branch Name")
        //                {
        //                    strSQL = strSQL + "AND BRANCH_NAME =  '" + Utility.gstrGetBranchName(strDeComID, strExpression) + "'";
        //                }
        //                else if (strFind == "Amount")
        //                {
        //                    if (strExpression != "")
        //                    {
        //                        strSQL = strSQL + "AND COMP_VOUCHER_NET_AMOUNT like '%" + strExpression + "%'";
        //                    }
        //                }
        //                else if (strFind == "Narrations")
        //                {
        //                    strSQL = strSQL + "AND COMP_VOUCHER_NARRATION = '" + strExpression + "'";
        //                }
        //                else
        //                {
        //                    strSQL = strSQL + "AND COMP_VOUCHER_DATE BETWEEN ";
        //                    strSQL = strSQL + Utility.cvtSQLDateString(mdteVFromDate) + " ";
        //                    strSQL = strSQL + "AND ";
        //                    strSQL = strSQL + " " + Utility.cvtSQLDateString(mdteVToDate) + " ";
        //                }

        //                //strSQL = strSQL + " ORDER By ACC_VOUCHER.COMP_REF_NO,ACC_LEDGER.TERITORRY_CODE,ACC_LEDGER.LEDGER_CODE,ACC_LEDGER.LEDGER_NAME  ";
        //                strSQL = strSQL + " ORDER By REF_NO,TERITORRY_CODE,LEDGER_CODE,LEDGER_NAME  ";
        //            }
        //            else
        //            {
        //                strSQL = "SELECT COMP_REF_NO,REF_NO,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
        //                strSQL = strSQL + "LEDGER_NAME , BRANCH_NAME, COMP_VOUCHER_AMOUNT, COMP_VOUCHER_NET_AMOUNT,LEDGER_CODE,LEDGER_NAME_MERZE,'' VOUCHER_REVERSE_LEDGER ";
        //                strSQL = strSQL + "From ACC_COMPANY_VOUCHER_BRANCH_VIEW ";
        //                strSQL = strSQL + "WHERE COMP_VOUCHER_TYPE = " + mintVType + " ";
        //                strSQL = strSQL + " AND SP_JOURNAL= " + intSPJ + " ";
        //                strSQL = strSQL + " AND SAMPLE_STATUS=0 ";
        //                if (strFind == "Voucher Number")
        //                {
        //                    strSQL = strSQL + "AND COMP_REF_NO like '%" + strExpression + "%'";
        //                }
        //                else if (strFind == "Voucher Date")
        //                {
        //                    strSQL = strSQL + "AND COMP_VOUCHER_DATE BETWEEN ";
        //                    strSQL = strSQL + Utility.cvtSQLDateString(mdteVFromDate) + " ";
        //                    strSQL = strSQL + "AND ";
        //                    strSQL = strSQL + " " + Utility.cvtSQLDateString(mdteVToDate) + " ";
        //                }
        //                else if (strFind == "Ledger Name")
        //                {
        //                    strSQL = strSQL + "AND LEDGER_NAME = '" + strExpression + "'";
        //                }
        //                else if (strFind == "Branch Name")
        //                {
        //                    strSQL = strSQL + "AND BRANCH_NAME =  '" + Utility.gstrGetBranchName(strDeComID, strExpression) + "'";
        //                }
        //                else if (strFind == "Amount")
        //                {
        //                    if (strExpression != "")
        //                    {
        //                        strSQL = strSQL + "AND COMP_VOUCHER_NET_AMOUNT like '%" + strExpression + "%'";
        //                    }
        //                }
        //                else if (strFind == "Narrations")
        //                {
        //                    strSQL = strSQL + "AND COMP_VOUCHER_NARRATION = '" + strExpression + "'";
        //                }
        //                else
        //                {
        //                    strSQL = strSQL + "AND COMP_VOUCHER_DATE BETWEEN ";
        //                    strSQL = strSQL + Utility.cvtSQLDateString(mdteVFromDate) + " ";
        //                    strSQL = strSQL + "AND ";
        //                    strSQL = strSQL + " " + Utility.cvtSQLDateString(mdteVToDate) + " ";
        //                }

        //                strSQL = strSQL + " ORDER By REF_NO,TERITORRY_CODE,LEDGER_CODE,LEDGER_NAME  ";
        //            }
        //        }
        //        else
        //        {
        //            strSQL = strmySql;
        //        }

        //        SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
        //        dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            AccountsVoucher oLedg = new AccountsVoucher();
        //            oLedg.strVoucherNo = dr["COMP_REF_NO"].ToString();
        //            oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
        //            oLedg.strBranchName = dr["BRANCH_NAME"].ToString();
        //            oLedg.strTranDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd/MM/yyyy");
        //            oLedg.dblAmount = Convert.ToDouble(dr["COMP_VOUCHER_NET_AMOUNT"].ToString());
        //            if (mintVType == 1)
        //            {
        //                oLedg.strReverseLegder = Utility.gGetRVReverseLedger(strDeComID, oLedg.strVoucherNo);
        //            }
        //            else
        //            {
        //                if (dr["VOUCHER_REVERSE_LEDGER"].ToString() != "")
        //                {
        //                    oLedg.strReverseLegder = dr["VOUCHER_REVERSE_LEDGER"].ToString();
        //                }
        //                else
        //                {
        //                    oLedg.strReverseLegder = "";
        //                }
        //            }
        //            oLedg.strMerzeName = dr["LEDGER_NAME_MERZE"].ToString();
        //            oLedg.strPreserveSQL = strSQL;
        //            ooAccLedger.Add(oLedg);
        //        }
        //        return ooAccLedger;
        //        dr.Close();
        //        gcnMain.Close();
        //        gcnMain.Dispose();
        //    }

        //}
        public List<AccountsVoucher> mFillBranch(string strDeComID, string vstrVoucherRefNumber, long mlngVoucherAs)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<AccountsVoucher> ooAcms = new List<AccountsVoucher>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            if (Utility.gblngApproved == false)
            {
                strSQL = "SELECT COMP_REF_NO,COMP_VOUCHER_DATE,BRANCH_ID,";
                strSQL = strSQL + "LEDGER_NAME,COMP_VOUCHER_NARRATION FROM ACC_COMPANY_VOUCHER ";
                strSQL = strSQL + "WHERE COMP_REF_NO = '" + vstrVoucherRefNumber + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_TYPE = " + mlngVoucherAs + " ";
            }

            else
            {
                strSQL = "SELECT COMP_REF_NO,COMP_VOUCHER_DATE,BRANCH_ID,";
                strSQL = strSQL + "LEDGER_NAME,COMP_VOUCHER_NARRATION FROM SMA_ACC_COMPANY_VOUCHER_APPR ";
                strSQL = strSQL + "WHERE COMP_REF_NO = '" + vstrVoucherRefNumber + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_TYPE = " + mlngVoucherAs + " ";
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
                    AccountsVoucher oBra = new AccountsVoucher();
                    oBra.strVoucherNo = vstrVoucherRefNumber;
                    oBra.strTranDate = dr["COMP_VOUCHER_DATE"].ToString();
                    oBra.strBranchID = dr["BRANCH_ID"].ToString();
                    oBra.strNarration = dr["COMP_VOUCHER_NARRATION"].ToString();
                    ooAcms.Add(oBra);
                }
                return ooAcms;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<AccountsVoucher> DisplayCompVoucherList(string strDeComID, string vstrVoucherRefNumber, long mlngVoucherAs)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<AccountsVoucher> ooAcms = new List<AccountsVoucher>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
           

            strSQL = "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE,ACC_COMPANY_VOUCHER.BRANCH_ID,ACC_COMPANY_VOUCHER.COMP_VOUCHER_MONTH_ID,ACC_LEDGER.LEDGER_NAME LEDGER_NAME1,ACC_LEDGER.LEDGER_NAME_MERZE LEDGER_NAME,ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION ,";
            strSQL = strSQL + "ACC_COMPANY_VOUCHER.SALES_REP,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DUE_DATE,ACC_COMPANY_VOUCHER.COMP_VOUCHER_FC,";
            strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_DELIVERY,ACC_COMPANY_VOUCHER.COMP_TERM_OF_PAYMENTS,ACC_COMPANY_VOUCHER.COMP_SUPPORT,ACC_COMPANY_VOUCHER.COMP_VALIDITY_DATE,ACC_COMPANY_VOUCHER.COMP_OTHERS,ACC_COMPANY_VOUCHER.ORDER_NO,";
            strSQL = strSQL + "ACC_COMPANY_VOUCHER.ORDER_DATE,ACC_COMPANY_VOUCHER.PREPARED_BY,ACC_COMPANY_VOUCHER.PREPARED_DATE,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DESTINATION,ACC_COMPANY_VOUCHER.TRANSPORT_NAME,ACC_COMPANY_VOUCHER.CRT_QTY,ACC_COMPANY_VOUCHER.BOX_QTY,";
            strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_AMOUNT,ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT,ACC_COMPANY_VOUCHER.COMP_VOUCHER_PROCESS_AMOUNT,ACC_COMPANY_VOUCHER.COMP_VOUCHER_ADD_AMOUNT,ACC_COMPANY_VOUCHER.COMP_VOUCHER_LESS_AMOUNT,";
            strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_ROUND_OFF_AMOUNT,ACC_COMPANY_VOUCHER.AGNST_COMP_REF_NO,APPROVED_BY,APPROVED_DATE,APPS_CHANGE FROM ACC_COMPANY_VOUCHER,ACC_LEDGER ";
            strSQL = strSQL + "WHERE ACC_LEDGER.LEDGER_NAME =ACC_COMPANY_VOUCHER.LEDGER_NAME  ";
            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_REF_NO = '" + vstrVoucherRefNumber + "' ";
            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = " + mlngVoucherAs + " ";

         
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
                    AccountsVoucher oBra = new AccountsVoucher();
                    oBra.strVoucherNo = vstrVoucherRefNumber;
                    oBra.strTranDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd/MM/yyyy");
                    oBra.strMerzeName = dr["LEDGER_NAME"].ToString();
                    oBra.strLedgerName = dr["LEDGER_NAME1"].ToString();
                    oBra.strLedgerNameNew = dr["LEDGER_NAME1"].ToString();
                    //oBra.strDueDate = Convert.ToDateTime(dr["COMP_VOUCHER_DUE_DATE"]).ToString("dd/MM/yyyy");
                    oBra.strBranchID = dr["BRANCH_ID"].ToString();
                    oBra.strNarration = dr["COMP_VOUCHER_NARRATION"].ToString();
                    if (dr["SALES_REP"].ToString() != "")
                    {
                        oBra.strSalesRepresentive = dr["SALES_REP"].ToString();
                    }
                    else
                    {
                        oBra.strSalesRepresentive = "";
                    }
                    oBra.strDueDate = Convert.ToDateTime(dr["COMP_VOUCHER_DUE_DATE"]).ToString("dd/MM/yyyy");
                    if (dr["COMP_VOUCHER_FC"].ToString() != "")
                    {
                        oBra.strComVoucherFc = dr["COMP_VOUCHER_FC"].ToString();
                    }
                    if (dr["COMP_DELIVERY"].ToString() != "")
                    {
                        oBra.strDelivery = dr["COMP_DELIVERY"].ToString();
                    }
                    if (dr["COMP_TERM_OF_PAYMENTS"].ToString() != "")
                    {
                        oBra.strtermofPayment = dr["COMP_TERM_OF_PAYMENTS"].ToString();
                    }
                    if (dr["COMP_SUPPORT"].ToString() != "")
                    {
                        oBra.strSupport = dr["COMP_SUPPORT"].ToString();
                    }
                    if (dr["COMP_VALIDITY_DATE"].ToString() != "")
                    {
                        oBra.strValidityDate = Convert.ToDateTime(dr["COMP_VALIDITY_DATE"]).ToString("dd/MM/yyyy");
                    }
                    if (dr["COMP_OTHERS"].ToString() != "")
                    {
                        oBra.strOthers = dr["COMP_OTHERS"].ToString();
                    }
                    if (dr["COMP_VOUCHER_NARRATION"].ToString() != "")
                    {
                        oBra.strNarration = dr["COMP_VOUCHER_NARRATION"].ToString();
                    }

                    if (dr["ORDER_NO"].ToString() != "")
                    {
                        oBra.strOrderNo = dr["ORDER_NO"].ToString();
                    }
                    else
                    {
                        oBra.strOrderNo = "";
                    }
                    if (dr["ORDER_DATE"].ToString() != "")
                    {
                        oBra.strOrderDate = Convert.ToDateTime(dr["ORDER_DATE"]).ToString("dd/MM/yyyy");
                    }
                    if (dr["PREPARED_BY"].ToString() != "")
                    {
                        oBra.strPreparedby = dr["PREPARED_BY"].ToString();
                    }
                    else
                    {
                        oBra.strPreparedby = "";
                    }
                    if (dr["PREPARED_DATE"].ToString() != "")
                    {
                        oBra.strPreparedDate = Convert.ToDateTime(dr["PREPARED_DATE"]).ToString("dd/MM/yyyy");
                    }

                    if (dr["COMP_VOUCHER_DESTINATION"].ToString() != "")
                    {
                        oBra.strDesignation = dr["COMP_VOUCHER_DESTINATION"].ToString();
                    }
                    else
                    {
                        oBra.strDesignation = "";
                    }
                    if (dr["TRANSPORT_NAME"].ToString() != "")
                    {
                        oBra.strtransport = dr["TRANSPORT_NAME"].ToString();
                    }
                    else
                    {
                        oBra.strtransport = "";
                    }
                    if (dr["COMP_VOUCHER_MONTH_ID"].ToString() != "")
                    {
                        oBra.strMonthID = dr["COMP_VOUCHER_MONTH_ID"].ToString();
                    }
                    else
                    {
                        oBra.strMonthID = "";
                    }
                    if (dr["AGNST_COMP_REF_NO"].ToString() != "")
                    {
                        oBra.strAgnstRefNo = dr["AGNST_COMP_REF_NO"].ToString();
                    }
                    else
                    {
                        oBra.strAgnstRefNo = "";
                    }
                    if (dr["APPROVED_BY"].ToString() != "")
                    {
                        oBra.strApprovedby = dr["APPROVED_BY"].ToString();
                    }
                    else
                    {
                        oBra.strApprovedby = "";
                    }
                    if (dr["APPROVED_DATE"].ToString() != "")
                    {
                        oBra.strApproveddate = Convert.ToDateTime(dr["APPROVED_DATE"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        oBra.strApproveddate = "";
                    }

                    oBra.dblCrtQnty = Convert.ToDouble(dr["CRT_QTY"].ToString());
                    oBra.dblBoxQnty = Convert.ToDouble(dr["BOX_QTY"].ToString());

                    oBra.dblAmount = Convert.ToDouble(dr["COMP_VOUCHER_AMOUNT"].ToString());
                    oBra.dblNetAmount = Convert.ToDouble(dr["COMP_VOUCHER_NET_AMOUNT"].ToString());
                    oBra.dblProcessAmount = Convert.ToDouble(dr["COMP_VOUCHER_PROCESS_AMOUNT"].ToString());
                    oBra.dblAddAmount = Convert.ToDouble(dr["COMP_VOUCHER_ADD_AMOUNT"].ToString());
                    oBra.dblLessAmount = Convert.ToDouble(dr["COMP_VOUCHER_LESS_AMOUNT"].ToString());
                    oBra.intChangeType = Convert.ToInt32(dr["APPS_CHANGE"].ToString());
                    oBra.dblRoundOff = Convert.ToDouble(dr["COMP_ROUND_OFF_AMOUNT"].ToString());
                    ooAcms.Add(oBra);
                }
                return ooAcms;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<AccountsVoucher> DisplayVoucherList(string strDeComID, string vstrVoucherRefNumber, long mlngVoucherAs, int intSP)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsVoucher> ooAcms = new List<AccountsVoucher>();
            if (Utility.gblngApproved == false)
            {

                strSQL = "SELECT ACC_LEDGER.LEDGER_NAME_MERZE,ACC_LEDGER.LEDGER_NAME ,ACC_VOUCHER.VOUCHER_TOBY,ACC_VOUCHER.VOUCHER_NARRATION,ACC_VOUCHER.VOUCHER_CHEQUE_NUMBER,ACC_VOUCHER.VOUCHER_CHEQUE_DATE,ACC_VOUCHER.VOUCHER_CHEQUE_DRAWN_ON,";
                strSQL = strSQL + "ACC_VOUCHER.INV_LOG_NO,ACC_VOUCHER.AGNST_COMP_REF_NO,ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT,ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT,ACC_VOUCHER.COMP_VOUCHER_POSITION ";
                strSQL = strSQL + ",ACC_VOUCHER.TRANSFER_TYPE FROM ACC_VOUCHER,ACC_LEDGER WHERE ACC_LEDGER.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_VOUCHER.COMP_REF_NO = '" + vstrVoucherRefNumber + "' ";
                strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE = " + mlngVoucherAs + " ";

                if (intSP > 0)
                {
                    strSQL = strSQL + " AND ACC_VOUCHER.VOUCHER_TOBY='Dr' ";
                }
                if (mlngVoucherAs == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER || mlngVoucherAs == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER)
                {
                    strSQL = strSQL + "ORDER BY ACC_VOUCHER.VOUCHER_TOBY DESC,ACC_VOUCHER.COMP_VOUCHER_POSITION ";
                }
                else
                {
                    strSQL = strSQL + "ORDER BY ACC_VOUCHER.VOUCHER_TOBY ASC,ACC_VOUCHER.COMP_VOUCHER_POSITION ";
                }
            }
            else
            {
                strSQL = "SELECT ACC_LEDGER.LEDGER_NAME_MERZE,ACC_LEDGER.LEDGER_NAME,ACC_VOUCHER.VOUCHER_TOBY,ACC_VOUCHER.VOUCHER_NARRATION,ACC_VOUCHER.VOUCHER_CHEQUE_NUMBER,ACC_VOUCHER.VOUCHER_CHEQUE_DATE,ACC_VOUCHER.VOUCHER_CHEQUE_DRAWN_ON,";
                strSQL = strSQL + "ACC_VOUCHER.INV_LOG_NO,ACC_VOUCHER.AGNST_COMP_REF_NO,ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT,ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT,ACC_VOUCHER.COMP_VOUCHER_POSITION ";
                strSQL = strSQL + ",ACC_VOUCHER.TRANSFER_TYPE FROM ACC_VOUCHER,ACC_LEDGER WHERE ACC_LEDGER.LEDGER_NAME =ACC_VOUCHER.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_VOUCHER.COMP_REF_NO = '" + vstrVoucherRefNumber + "' ";
                strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_TYPE = " + mlngVoucherAs + " ";
                strSQL = strSQL + " AND ACC_VOUCHER.VOUCHER_TOBY='Dr' ";
                if (mlngVoucherAs == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER || mlngVoucherAs == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER)
                {
                    strSQL = strSQL + "ORDER BY ACC_VOUCHER.VOUCHER_TOBY DESC,ACC_VOUCHER.COMP_VOUCHER_POSITION ";
                }
                else
                {
                    strSQL = strSQL + "ORDER BY ACC_VOUCHER.VOUCHER_TOBY ASC,ACC_VOUCHER.COMP_VOUCHER_POSITION ";
                }
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
                    AccountsVoucher oBra = new AccountsVoucher();

                    oBra.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oBra.strMerzeName = dr["LEDGER_NAME_MERZE"].ToString();
                    oBra.strToby = dr["VOUCHER_TOBY"].ToString();
                    if (dr["VOUCHER_NARRATION"].ToString() != "")
                    {
                        oBra.strNarration = dr["VOUCHER_NARRATION"].ToString();
                    }
                    if (dr["VOUCHER_CHEQUE_NUMBER"].ToString() != "")
                    {
                        oBra.strChequeNo = dr["VOUCHER_CHEQUE_NUMBER"].ToString();
                    }
                    if (dr["VOUCHER_CHEQUE_DATE"].ToString() != "")
                    {
                        oBra.strChequeDate = Convert.ToDateTime(dr["VOUCHER_CHEQUE_DATE"]).ToString("dd/MM/yyyy");
                    }
                    if (dr["VOUCHER_CHEQUE_DRAWN_ON"].ToString() != "")
                    {
                        oBra.strDrawnOn = dr["VOUCHER_CHEQUE_DRAWN_ON"].ToString();
                    }
                    if (dr["INV_LOG_NO"].ToString() != "")
                    {
                        oBra.strBatch = dr["INV_LOG_NO"].ToString();
                    }
                    if (dr["AGNST_COMP_REF_NO"].ToString() != "")
                    {
                        oBra.strAgnstRefNo = dr["AGNST_COMP_REF_NO"].ToString();
                    }
                    else
                    {
                        oBra.strAgnstRefNo = "";
                    }
                    oBra.dblDebitAmount = Convert.ToDouble(dr["VOUCHER_DEBIT_AMOUNT"].ToString());
                    oBra.dblCreditAmount = Convert.ToDouble(dr["VOUCHER_CREDIT_AMOUNT"].ToString());
                    oBra.intvoucherPos = Convert.ToInt32(dr["COMP_VOUCHER_POSITION"].ToString());
                    oBra.intTrasnsfer = Convert.ToInt32(dr["TRANSFER_TYPE"].ToString());
                    ooAcms.Add(oBra);
                }
                return ooAcms;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<AccBillwise> DisplayBillWise(string strDeComID, string vstrVoucherRefNumber)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccBillwise> ooAcms = new List<AccBillwise>();
            if (Utility.gblngApproved)
            {
                strSQL = "SELECT * FROM ACC_BILL_TRAN_APPR ";
                strSQL = strSQL + "WHERE COMP_REF_NO = '" + vstrVoucherRefNumber + "' ";
            }
            else
            {
                strSQL = "SELECT * FROM ACC_BILL_TRAN WHERE COMP_REF_NO = '" + vstrVoucherRefNumber + "' ";
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
                    AccBillwise oBra = new AccBillwise();
                    oBra.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                    oBra.strGodownsName = dr["GODOWNS_NAME"].ToString();
                    if (dr["BILL_PER"].ToString() != "")
                    {
                        oBra.strPer = dr["BILL_PER"].ToString();
                    }
                    else
                    {
                        oBra.strPer = dr["BILL_UOM"].ToString();
                    }

                    oBra.dblAmount = Convert.ToDouble(dr["BILL_NET_AMOUNT"].ToString());
                    oBra.dblQnty = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());

                    if (dr["INV_LOG_NO"].ToString() != "")
                    {
                        oBra.strBatchNo = dr["INV_LOG_NO"].ToString();
                    }
                    else
                    {
                        oBra.strBatchNo = "";
                    }

                    if (Utility.gblnMultipleCurrency)
                    {
                        if (Convert.ToInt16(dr["FC_CONVERSION_RATE"]) != 0)
                        {
                            oBra.mdblCurrRate = Convert.ToDouble(dr["FC_CONVERSION_RATE"]);
                            oBra.mstrFCsymbol = dr["VOUCHER_CURRENCY_SYMBOL"].ToString();
                            oBra.dblRate = Convert.ToDouble(dr["BILL_RATE"]);
                        }
                        else if (oBra.mdblCurrRate != 0)
                        {
                            oBra.dblRate = Convert.ToDouble(dr["BILL_RATE"]);
                        }
                        else
                        {
                            oBra.dblRate = Convert.ToDouble(dr["BILL_RATE"]);
                        }
                    }
                    else
                    {

                        oBra.dblRate = Convert.ToDouble(dr["BILL_RATE"]);
                    }


                    ooAcms.Add(oBra);
                }
                return ooAcms;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<AccBillwise> DisplayCommonInvoice(string strDeComID, string vstrVoucherRefNumber)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccBillwise> ooAcms = new List<AccBillwise>();
            strSQL = "SELECT BILL_TRAN_KEY,STOCKITEM_NAME,STOCKITEM_DESCRIPTION,GODOWNS_NAME,BILL_QUANTITY,BILL_QUANTITY_BONUS,";
            strSQL = strSQL + "BILL_UOM,BILL_RATE,BILL_PER,BILL_AMOUNT,BILL_ADD_LESS,";
            strSQL = strSQL + "BILL_NET_AMOUNT,INV_LOG_NO,BILL_QUANTITY_BONUS,VOUCHER_FC_AMOUNT,VOUCHER_CURRENCY_SYMBOL,STOCKGROUP_NAME,AGNST_COMP_REF_NO,AGNST_COMP_REF_NO1,SHORT_QTY,G_COMM_PER FROM ACC_BILL_TRAN ";
            strSQL = strSQL + " WHERE COMP_REF_NO = '" + vstrVoucherRefNumber + "' ";
            strSQL = strSQL + "ORDER BY BILL_TRAN_KEY";
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
                    AccBillwise oBra = new AccBillwise();
                    oBra.strBillKey = dr["BILL_TRAN_KEY"].ToString();
                    oBra.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                    if (dr["STOCKITEM_DESCRIPTION"].ToString() != "")
                    {
                        oBra.strDescription = dr["STOCKITEM_DESCRIPTION"].ToString();
                    }
                    else
                    {
                        oBra.strDescription = dr["STOCKITEM_DESCRIPTION"].ToString();
                    }

                    oBra.strGodownsName = dr["GODOWNS_NAME"].ToString();
                    if (dr["BILL_ADD_LESS"].ToString() != "")
                    {
                        oBra.strBillAddless = dr["BILL_ADD_LESS"].ToString();
                    }
                    else
                    {
                        oBra.strBillAddless = "";
                    }


                    if (dr["BILL_PER"].ToString() != "")
                    {
                        oBra.strPer = dr["BILL_PER"].ToString();
                    }
                    else
                    {
                        oBra.strPer = dr["BILL_UOM"].ToString();
                    }
                    oBra.dblAmount = Convert.ToDouble(dr["BILL_AMOUNT"].ToString());
                    oBra.dblBillNetAmount = Convert.ToDouble(dr["BILL_NET_AMOUNT"].ToString());
                    oBra.dblQnty = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());
                    oBra.dblRate = Convert.ToDouble(dr["BILL_RATE"].ToString());
                    oBra.dblBonusQnty = Convert.ToDouble(dr["BILL_QUANTITY_BONUS"].ToString());
                    if (dr["INV_LOG_NO"].ToString() != "")
                    {
                        oBra.strBatchNo = dr["INV_LOG_NO"].ToString();
                    }
                    else
                    {
                        oBra.strBatchNo = "";
                    }
                    if (dr["STOCKGROUP_NAME"].ToString() != "")
                    {
                        oBra.strStockGroupName = dr["STOCKGROUP_NAME"].ToString();
                    }
                    else
                    {
                        oBra.strStockGroupName = "";
                    }
                    if (dr["AGNST_COMP_REF_NO"].ToString() != "")
                    {
                        oBra.strAgnstVoucherRefNo = dr["AGNST_COMP_REF_NO"].ToString();
                    }
                    else
                    {
                        oBra.strAgnstVoucherRefNo = "";
                    }

                    if (dr["AGNST_COMP_REF_NO1"].ToString() != "")
                    {
                        oBra.strAgnstVoucherRefNo1 = dr["AGNST_COMP_REF_NO1"].ToString();
                    }
                    else
                    {
                        oBra.strAgnstVoucherRefNo1 = "";
                    }
                    
                    if (dr["AGNST_COMP_REF_NO1"].ToString() != "")
                    {
                        oBra.strSubgroup = dr["AGNST_COMP_REF_NO1"].ToString();
                    }
                    else
                    {
                        oBra.strSubgroup = "";
                    }
                    oBra.dblShortQty = Convert.ToDouble(dr["SHORT_QTY"].ToString());
                    oBra.dblComm = Convert.ToDouble(dr["G_COMM_PER"].ToString());
                    ooAcms.Add(oBra);
                }
                return ooAcms;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public string GetRefNamefromtype(string strDeComID, string strRefPre)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT COMP_VOUCHER_TYPE FROM ACC_BILL_TRAN ";
            strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefPre + "'";
            //strSQL = strSQL + "AND COMP_VOUCHER_TYPE <> " + mlngVType + " ";
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
                    return gobjVoucherName.VoucherName.GetVoucherName(Convert.ToInt64(dr["COMP_VOUCHER_TYPE"].ToString()));
                }
                else
                {
                    return "";
                }


                gcnMain.Close();
                gcnMain.Dispose();
                dr.Close();
            }

        }

        public string GetRefBillKey(string strDeComID, string strRefPre)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT BILL_TRAN_KEY FROM ACC_BILL_TRAN ";
            strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefPre + "'";
            //strSQL = strSQL + "AND COMP_VOUCHER_TYPE <> " + mlngVType + " ";
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
                    return dr["BILL_TRAN_KEY"].ToString();
                }
                else
                {
                    return "";
                }
                gcnMain.Close();
                gcnMain.Dispose();
                dr.Close();
            }

        }
        public string GetRefBillDate(string strDeComID, string strRefPre,int intRef)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            if (intRef == 0)
            {
                strSQL = "SELECT COMP_VOUCHER_DATE FROM ACC_COMPANY_VOUCHER  ";
                strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefPre + "'";
            }
            else
            {
                strSQL = "SELECT INSERT_DATE COMP_VOUCHER_DATE FROM ACC_SAMPLE_CLASS_TRAN  ";
                strSQL = strSQL + "WHERE SAMPLE_CLASS = '" + Utility.Mid(strRefPre,6,strRefPre.Length-6) + "'";
            }
            //strSQL = strSQL + "AND COMP_VOUCHER_TYPE <> " + mlngVType + " ";
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
                    return Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    return "";
                }
                gcnMain.Close();
                gcnMain.Dispose();
                dr.Close();
            }

        }
        public List<AccBillwise> DisplaycommonInvoiceOrder(string strDeComID, string vstrBillKey, int mlngVType)
        {
            string strSQL = null;
            int intcheck = 0;
            SqlDataReader dr;
            List<AccBillwise> ooAcms = new List<AccBillwise>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "SELECT VOUCHER_JOIN_FOREIGN_REF FROM ACC_VOUCHER_JOIN_CLASS ";
                strSQL = strSQL + "WHERE VOUCHER_JOIN_PRIMARY_REF = '" + vstrBillKey + "' ";
                SqlCommand cmd1 = new SqlCommand(strSQL, gcnMain);
                dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    intcheck = 1;
                }
                dr.Close();
                cmd1.Dispose();
                if (intcheck == 0)
                {
                    strSQL = "SELECT VOUCHER_JOIN_FOREIGN_REF FROM ACC_VOUCHER_JOIN ";
                    strSQL = strSQL + "WHERE VOUCHER_JOIN_PRIMARY_REF = '" + vstrBillKey + "' ";
                }
                else
                {
                    strSQL = "SELECT CLASS_NAME VOUCHER_JOIN_FOREIGN_REF FROM ACC_VOUCHER_JOIN_CLASS ";
                    strSQL = strSQL + "WHERE VOUCHER_JOIN_PRIMARY_REF = '" + vstrBillKey + "' ";
                }
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AccBillwise oBra = new AccBillwise();
                    // oBra.strBillKey = GetRefBillKey(dr["VOUCHER_JOIN_FOREIGN_REF"].ToString());
                    oBra.strBillKey = dr["VOUCHER_JOIN_FOREIGN_REF"].ToString();
                    oBra.strRefNo = dr["VOUCHER_JOIN_FOREIGN_REF"].ToString();
                    oBra.strDate = GetRefBillDate(strDeComID, dr["VOUCHER_JOIN_FOREIGN_REF"].ToString(), intcheck);
                    oBra.strRefType = GetRefNamefromtype(strDeComID,dr["VOUCHER_JOIN_FOREIGN_REF"].ToString());
                    ooAcms.Add(oBra);
                }

                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
                return ooAcms;
            }

        }
        public List<AccBillwise> DisplaycommonInvoiceAddless(string strDeComID, string vstrSalesSerial)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<AccBillwise> ooAcms = new List<AccBillwise>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT COMP_REF_NO,LEDGER_NAME,VOUCHER_ADD_LESS_SIGN,VOUCHER_CREDIT_AMOUNT,";
            strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_REF_KEY FROM ACC_VOUCHER ";
            strSQL = strSQL + "WHERE (COMP_VOUCHER_POSITION <> 1 AND COMP_VOUCHER_POSITION <> 2 ";
            //'strSQL = strSQL + "AND COMP_VOUCHER_POSITION <> 3 AND COMP_VOUCHER_POSITION <> 4 "
            strSQL = strSQL + ") ";
            if (vstrSalesSerial != "")
            {
                strSQL = strSQL + "AND (COMP_REF_NO = '" + vstrSalesSerial.Trim() + "') ";
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
                    AccBillwise oBra = new AccBillwise();
                    oBra.strRefNo = dr["COMP_REF_NO"].ToString();
                    oBra.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oBra.strAddlessSign = dr["VOUCHER_ADD_LESS_SIGN"].ToString();
                    if (dr["VOUCHER_ADD_LESS_SIGN"].ToString() != "")
                    {
                        if (Utility.Left(dr["VOUCHER_ADD_LESS_SIGN"].ToString(), 1) == "-")
                        {
                            if (Utility.Val(dr["VOUCHER_CREDIT_AMOUNT"].ToString()) != 0)
                            {
                                oBra.dblCreditAmount = -1 * Utility.Val(dr["VOUCHER_CREDIT_AMOUNT"].ToString());
                            }
                            if (Utility.Val(dr["VOUCHER_DEBIT_AMOUNT"].ToString()) != 0)
                            {
                                oBra.dblCreditAmount = -1 * Utility.Val(dr["VOUCHER_DEBIT_AMOUNT"].ToString());
                            }
                        }
                        else
                        {

                            if (Utility.Val(dr["VOUCHER_CREDIT_AMOUNT"].ToString()) != 0)
                            {
                                oBra.dblCreditAmount = Utility.Val(dr["VOUCHER_CREDIT_AMOUNT"].ToString());
                            }
                            if (Utility.Val(dr["VOUCHER_DEBIT_AMOUNT"].ToString()) != 0)
                            {
                                oBra.dblCreditAmount = Utility.Val(dr["VOUCHER_DEBIT_AMOUNT"].ToString());
                            }
                        }
                    }
                    ooAcms.Add(oBra);
                }

                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
                return ooAcms;
            }

        }
        public List<AccBillwise> DisplaycommonInvoiceAddlessDateWise(string strDeComID, string strfDate, string strtDate, string strLedgerName,int intvtype)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<AccBillwise> ooAcms = new List<AccBillwise>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT COMP_REF_NO,LEDGER_NAME,VOUCHER_ADD_LESS_SIGN,VOUCHER_CREDIT_AMOUNT,";
            strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_REF_KEY FROM ACC_VOUCHER ";
            strSQL = strSQL + "WHERE (COMP_VOUCHER_POSITION <> 1 AND COMP_VOUCHER_POSITION <> 2 ";
            //'strSQL = strSQL + "AND COMP_VOUCHER_POSITION <> 3 AND COMP_VOUCHER_POSITION <> 4 "
            strSQL = strSQL + ") ";
            strSQL = strSQL + "AND COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strfDate) + " ";
            strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strtDate) + " ";
            strSQL = strSQL + "AND COMP_VOUCHER_TYPE = " + intvtype  +" ";
            if (strLedgerName != "")
            {
                strSQL = strSQL + "AND LEDGER_NAME = '" + strLedgerName + "' ";
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
                    AccBillwise oBra = new AccBillwise();
                    oBra.strRefNo = dr["COMP_REF_NO"].ToString();
                    oBra.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oBra.strAddlessSign = dr["VOUCHER_ADD_LESS_SIGN"].ToString();
                    if (dr["VOUCHER_ADD_LESS_SIGN"].ToString() != "")
                    {
                        if (Utility.Left(dr["VOUCHER_ADD_LESS_SIGN"].ToString(), 1) == "-")
                        {
                            if (Utility.Val(dr["VOUCHER_CREDIT_AMOUNT"].ToString()) != 0)
                            {
                                oBra.dblCreditAmount = -1 * Utility.Val(dr["VOUCHER_CREDIT_AMOUNT"].ToString());
                            }
                            if (Utility.Val(dr["VOUCHER_DEBIT_AMOUNT"].ToString()) != 0)
                            {
                                oBra.dblCreditAmount = -1 * Utility.Val(dr["VOUCHER_DEBIT_AMOUNT"].ToString());
                            }
                        }
                        else
                        {

                            if (Utility.Val(dr["VOUCHER_CREDIT_AMOUNT"].ToString()) != 0)
                            {
                                oBra.dblCreditAmount = Utility.Val(dr["VOUCHER_CREDIT_AMOUNT"].ToString());
                            }
                            if (Utility.Val(dr["VOUCHER_DEBIT_AMOUNT"].ToString()) != 0)
                            {
                                oBra.dblCreditAmount = Utility.Val(dr["VOUCHER_DEBIT_AMOUNT"].ToString());
                            }
                        }
                    }
                    ooAcms.Add(oBra);
                }
                if (!dr.HasRows)
                {
                    AccBillwise oBra = new AccBillwise();
                    oBra.strRefNo = "";
                    oBra.strLedgerName = "";
                    oBra.strAddlessSign = "";
                    oBra.dblCreditAmount = 0;
                    ooAcms.Add(oBra);
                }

                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
                return ooAcms;
            }

        }

        public List<AccBillwise> DisplaycommonInvoiceBill(string strDeComID, string vstrSalesSerial)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<AccBillwise> ooAcms = new List<AccBillwise>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_NAME,BILL_WISE_PREV_NEW,AGAINST_VOUCHER_NO,BILL_WISE_DUE_DATE,";
            strSQL = strSQL + "BILL_WISE_TOBY,BILL_WISE_AMOUNT,COMISSION,INTEREST FROM ACC_BILL_WISE ";
            strSQL = strSQL + "WHERE COMP_REF_NO = '" + vstrSalesSerial + "' ";
            strSQL = strSQL + "ORDER BY VOUCHER_REF_KEY ASC ";
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
                    AccBillwise oBra = new AccBillwise();
                    oBra.strLedgerName = dr["LEDGER_NAME"].ToString();
                    int intle = dr["AGAINST_VOUCHER_NO"].ToString().Length;
                    oBra.strBillPrevNew = Utility.gstrGetRefName(Convert.ToInt32(dr["BILL_WISE_PREV_NEW"]));
                    oBra.strAgnstVoucherRefNo = dr["AGAINST_VOUCHER_NO"].ToString();
                    oBra.strDueDate = Convert.ToDateTime(dr["BILL_WISE_DUE_DATE"]).ToString("dd/MM/yyyy");
                    //if (Utility.Val(dr["BILL_WISE_AMOUNT"].ToString()) != 0)
                    //{
                    oBra.dblAmount = Utility.Val(dr["BILL_WISE_AMOUNT"].ToString());
                    //}

                    //if (dr["BILL_WISE_TOBY"].ToString()=="Dr")
                    //{
                    //    oBra.dblBillNetAmount = Utility.Val(dr["BILL_WISE_AMOUNT"].ToString()) *-1;
                    //}
                    //else
                    //{
                    //    oBra.dblBillNetAmount = Utility.Val(dr["BILL_WISE_AMOUNT"].ToString());
                    //}
                    oBra.strDrCr = dr["BILL_WISE_TOBY"].ToString();
                    oBra.dblComm = Utility.Val(dr["COMISSION"].ToString());
                    oBra.dblInt = Utility.Val(dr["INTEREST"].ToString());
                    ooAcms.Add(oBra);
                }

                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
                return ooAcms;
            }

        }

        public List<AccountsLedger> DisplaycommonInvoiceVoucher(string strDeComID, string vstrSalesSerial)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<AccountsLedger> ooAcms = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_NAME FROM ACC_VOUCHER ";
            strSQL = strSQL + "WHERE COMP_REF_NO = '" + vstrSalesSerial + "' ";
            strSQL = strSQL + "AND COMP_VOUCHER_POSITION = 2 ";
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
                    AccountsLedger oBra = new AccountsLedger();
                    oBra.strLedgerName = dr["LEDGER_NAME"].ToString();
                    ooAcms.Add(oBra);
                }
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
                return ooAcms;
            }

        }
        public List<AccountsLedger> DisplayAccountsTemplate(string strDeComID, string vstrSalesSerial)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<AccountsLedger> ooAcms = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT TEMPLATE_NAME,DUE_DATE,RECEIVE_DATE,INSTALLMET_NAME,MONTHLY_AMOUNT,FINE_AMOUNT FROM ACC_PAYMENT_SCHEDULE ";
            strSQL = strSQL + "WHERE COMP_REF_NO = '" + vstrSalesSerial + "' ";
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
                    AccountsLedger oBra = new AccountsLedger();
                    oBra.strmerzeString = dr["TEMPLATE_NAME"].ToString();
                    oBra.strLedgerName = dr["INSTALLMET_NAME"].ToString();
                    oBra.strCreditDate = Convert.ToDateTime(dr["DUE_DATE"]).ToString("dd-MM-yyyy");
                    if (dr["RECEIVE_DATE"].ToString() != "")
                    {
                        oBra.strcloseDate = Convert.ToDateTime(dr["RECEIVE_DATE"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        oBra.strcloseDate = "";
                    }
                    oBra.dblToAmt = Math.Abs(Convert.ToDouble(dr["MONTHLY_AMOUNT"].ToString()));
                    oBra.dblFromAmt = Math.Abs(Convert.ToDouble(dr["FINE_AMOUNT"].ToString()));
                    ooAcms.Add(oBra);
                }
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
                return ooAcms;
            }

        }
        public List<VectorCategory> DisplayVectorList(string strDeComID, string vstrVoucherRefNumber)
        {
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            List<VectorCategory> ooAcms = new List<VectorCategory>();

            if (Utility.gblngApproved == false)
            {
                strSQL = "SELECT * FROM VECTOR_TRANSACTION ";
                strSQL = strSQL + "WHERE COMP_REF_NO = '" + vstrVoucherRefNumber + "' ";
            }

            else
            {
                strSQL = "SELECT * FROM VECTOR_TRANSACTION ";
                strSQL = strSQL + "WHERE COMP_REF_NO = '" + vstrVoucherRefNumber + "' ";
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
                    VectorCategory oBra = new VectorCategory();
                    oBra.strVectorcategory = dr["VCATEGORY_NAME"].ToString();
                    oBra.strCostCenter = dr["VMASTER_NAME"].ToString();
                    oBra.dblAmount = Convert.ToDouble(dr["VT_TRAN_AMOUNT"].ToString());
                    if (Utility.Val(dr["VT_TRAN_AMOUNT"].ToString()) < 0)
                    {
                        oBra.strDrcr = "Dr";
                    }
                    else
                    {
                        oBra.strDrcr = "Cr";
                    }
                    AccountsLedger oo = new AccountsLedger();
                    oo.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oBra.accountsLedger = oo;
                    ooAcms.Add(oBra);
                }
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
                return ooAcms;
            }

        }

        #endregion
        #region "Update Voucher"
        public string UpdateVoucher(string strDeComID,string strVoucherGrid, string vstrDrcr, string vstrRefNumber, long vlngVoucherType, string vdteDate, string vstrMonthID, string vdteDueDate, string vstrLedgerName,
                                            string vstrReverseLedgerName, int intvoucherPosition, long lngCashFlow, string vstrVoyageNo, double vdblAmount, double vdblNetAmount,
                                            double vdblAddAmount, double vdblLessAmount, double vdblDebitAmount, double vdblCreditAmount, double dblFCCurrencyDebit, double dblFCCurrencyCredit,
                                            string mstrFCsymbol, double mdblCurrRate, long vlngAgstType, string vstrSingleNarration, string vstrNarrations, string vstrBranchID,
                                            string DgCostCenter, string DGBillWise, long vlngIsMultiCurrency = 0,
                                            string vstrChecuqNo = "", string vstrChequedate = "", string vstrDrawnon = "", string vstrAgnstRefNo = "", string vstrSalesRep = "", string vstrDelivery = "",
                                            string vstrPayment = "", string vstrSupport = "", string vstrValidaty = "", string vstrOtherTerms = "", string strDginvEffect = "",
                                            string strGrdTemPlate = "", string strGrdTemPlateJV = "", int intLoanTransfer = 0)
        {

            string strSQL = "", strBillWiseRef = "", strRefNoFromReader = "", strLoanTo="";
            short lnglType = 1;
            
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

                    strBillWiseRef = vstrRefNumber + intvoucherPosition.ToString("0000");
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    SqlDataReader dr;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    strSQL = "UPDATE ACC_COMPANY_VOUCHER SET ";
                    strSQL = strSQL + "BRANCH_ID = '" + vstrBranchID + "', ";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE = " + vlngVoucherType + ",";
                    strSQL = strSQL + "COMP_VOUCHER_DATE = " + Utility.cvtSQLDateString(vdteDate) + ",";
                    strSQL = strSQL + "COMP_VOUCHER_MONTH_ID = '" + vstrMonthID + "',";
                    strSQL = strSQL + "LEDGER_NAME= '" + vstrLedgerName + "',";
                    strSQL = strSQL + "COMP_VOUCHER_AMOUNT = " + vdblNetAmount + ", ";
                    strSQL = strSQL + "COMP_VOUCHER_NET_AMOUNT = " + vdblNetAmount + ", ";
                    strSQL = strSQL + "COMP_VOUCHER_NARRATION = '" + vstrNarrations + "',";
                    strSQL = strSQL + "UPDATE_DATE = " + Utility.cvtSQLDateString(DateTime.Now.ToString("dd/MM/yyyy"));

                    strSQL = strSQL + " WHERE COMP_REF_NO = '" + vstrRefNumber + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "SELECT VOUCHER_REF_KEY,LEDGER_NAME,VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,VOUCHER_TOBY FROM ACC_VOUCHER WHERE COMP_REF_NO = '" + vstrRefNumber + "'";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["VOUCHER_REF_KEY"].ToString() + "~" + strRefNoFromReader;
                    }

                    dr.Dispose();
                    if (strRefNoFromReader != "")
                    {
                        strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                        string[] words = strRefNoFromReader.Split('~');
                        foreach (string name in words)
                        {
                            if (name.ToString() != "")
                            {
                                strSQL = "DELETE FROM ACC_VOUCHER WHERE VOUCHER_REF_KEY = '" + name.ToString() + "'";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }

                    strRefNoFromReader = "";
                    strSQL = "DELETE FROM VECTOR_TRANSACTION WHERE COMP_REF_NO = '" + vstrRefNumber + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO = '" + vstrRefNumber + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO = '" + vstrRefNumber + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_PAYMENT_SCHEDULE WHERE COMP_REF_NO = '" + vstrRefNumber + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "SELECT VOUCHER_REF_KEY FROM ACC_BILL_WISE WHERE COMP_REF_NO = '" + vstrRefNumber + "'";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["VOUCHER_REF_KEY"].ToString() + "~" + strRefNoFromReader;
                    }
                    dr.Close();
                    if (strRefNoFromReader != "")
                    {
                        strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                        string[] words1 = strRefNoFromReader.Split('~');
                        foreach (string name in words1)
                        {
                            if (name.ToString() != "")
                            {
                                strSQL = "DELETE FROM ACC_BILL_WISE WHERE VOUCHER_REF_KEY = '" + name.ToString() + "'";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }
                    dr.Close();
                    strRefNoFromReader = "";

                    if (strVoucherGrid != "")
                    {
                        string[] words = strVoucherGrid.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split('|');

                            if (oAssets[0] != "")
                            {
                                
                                strBillWiseRef = vstrRefNumber + intvoucherPosition.ToString("0000");
                                strSQL = "INSERT INTO ACC_VOUCHER";
                                strSQL = strSQL + "(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,COMP_VOUCHER_TYPE,";
                                strSQL = strSQL + "COMP_VOUCHER_DATE,COMP_VOUCHER_POSITION,LEDGER_NAME,";
                                if (oAssets[9] != "")
                                {
                                    strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER,";
                                }
                                if (oAssets[10] != "")
                                {
                                    strSQL = strSQL + "VOUCHER_CHEQUE_DATE,";
                                }
                                if (oAssets[11] != "")
                                {
                                    strSQL = strSQL + "VOUCHER_CHEQUE_DRAWN_ON,";
                                }
                                strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                                strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,VOUCHER_CASHFLOW ";
                                if (mdblCurrRate != 0)
                                {
                                    strSQL = strSQL + ",VOUCHER_FC_DEBIT_AMOUNT,VOUCHER_FC_CREDIT_AMOUNT, ";
                                    strSQL = strSQL + "VOUCHER_CURRENCY_SYMBOL,FC_CONVERSION_RATE";
                                }
                                else
                                {
                                    strSQL = strSQL + ",VOUCHER_CURRENCY_SYMBOL";
                                }

                                if (vstrSingleNarration != "")
                                {
                                    strSQL = strSQL + ",VOUCHER_NARRATION";
                                }
                                strSQL = strSQL + ",AGNST_COMP_REF_NO,TRANSFER_TYPE ";
                                strSQL = strSQL + ") VALUES(";
                                strSQL = strSQL + "'" + vstrBranchID + "',";
                                strSQL = strSQL + "'" + strBillWiseRef + "','" + vstrRefNumber + "',";
                                strSQL = strSQL + " " + vlngVoucherType + "," + Utility.cvtSQLDateString(vdteDate) + ",";
                                strSQL = strSQL + " " + intvoucherPosition + ",'" + oAssets[1] + "',";
                                if (oAssets[9] != "")
                                {
                                    strSQL = strSQL + "'" + oAssets[9] + "',";
                                }
                                if (oAssets[10] != "")
                                {
                                    strSQL = strSQL + " " + Utility.cvtSQLDateString(oAssets[10]) + ",";
                                }
                                if (oAssets[11] != "")
                                {
                                    strSQL = strSQL + "'" + oAssets[11] + "',";
                                }
                            
                                strSQL = strSQL + " " + oAssets[5] + "," + oAssets[6] + ",";
                                strSQL = strSQL + "'" + oAssets[0] + "' ";
                                strSQL = strSQL + ",'" + oAssets[2] + "'," + oAssets[3] + " ";
                                if (mdblCurrRate != 0)
                                {
                                    strSQL = strSQL + "," + dblFCCurrencyDebit + "," + dblFCCurrencyCredit + ",";
                                    strSQL = strSQL + "'" + mstrFCsymbol + "'," + mdblCurrRate + " ";
                                }
                                else
                                {
                                    strSQL = strSQL + ",'" + Utility.gstrBaseCurrency + "' ";
                                }
                                if (vstrSingleNarration != "")
                                {
                                    strSQL = strSQL + ",'" + oAssets[6] + "' ";
                                }
                                strSQL = strSQL + ",'" + oAssets[12] + "' ";
                                strSQL = strSQL + "," + intLoanTransfer;
                                strSQL = strSQL + ")";

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                if (intvoucherPosition==2)
                                {
                                    strLoanTo = oAssets[1];
                                }

                                intvoucherPosition += 1;
                               
                               

                            }
                        }
                    }
                    if (intLoanTransfer == 3)
                    {
                        strSQL = "UPDATE ACC_PAYMENT_SCHEDULE SET ";
                        strSQL = strSQL + "LEDGER_NAME=FROM_LEDGER_NAME";
                        strSQL = strSQL + ",FROM_LEDGER_NAME='Null' ";
                        strSQL = strSQL + ",NARRATION='Null' ";
                        strSQL = strSQL + ",transfer_type='N' ";
                        strSQL = strSQL + ",INSTALL_STATUS=0 ";
                        strSQL = strSQL + "WHERE NARRATION = '" + vstrRefNumber + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "UPDATE ACC_PAYMENT_SCHEDULE SET ";
                        strSQL = strSQL + "LEDGER_NAME='" + vstrLedgerName.Replace("'", "''") + "' ";
                        strSQL = strSQL + ",FROM_LEDGER_NAME='" + strLoanTo.Replace("'", "''") + "' ";
                        strSQL = strSQL + ",TRANSFER_TYPE='T' ";
                        strSQL = strSQL + ",NARRATION ='" + vstrRefNumber + "' ";
                        strSQL = strSQL + "WHERE LEDGER_NAME ='" + strLoanTo.Replace("'", "''") + "' ";
                        strSQL = strSQL + "AND TO_BY ='Dr' and INSTALL_STATUS =0 and TRANSFER_TYPE='N' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    if (DgCostCenter != "")
                    {
                        string[] words = DgCostCenter.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                strSQL = Voucher.mInsertVector(vstrRefNumber, oAssets[1].ToString(), oAssets[2].ToString(), vdteDate, oAssets[0].ToString(),
                                                             oAssets[4].ToString(), lnglType, lnglType, 1, vstrBranchID, Utility.Val(oAssets[3].ToString()), 0, "", vlngVoucherType);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lnglType += 1;
                            }
                        }
                    }

                    if (DGBillWise != "")
                    {
                        int intbillpos = 1;
                        string strAgstRefNo = "";
                        string[] words = DGBillWise.Split('~');
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('|');
                            if (ooCost[0] != "")
                            {
                                strAgstRefNo = vstrBranchID + ooCost[2].ToString();
                                strSQL = Voucher.gInsertBillWise(vstrBranchID, vstrRefNumber, vdteDate, vlngVoucherType, ooCost[0].ToString(), intbillpos, ooCost[1].ToString(),
                                                                    Utility.Val(ooCost[4].ToString()), ooCost[5].ToString(), strAgstRefNo, intbillpos);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                intbillpos += 1;
                            }
                        }
                    }
                    if (strDginvEffect != "")
                    {
                        strSQL = Voucher.gInsertmaster(vstrRefNumber, vstrBranchID, vlngVoucherType, vdteDate, vdblNetAmount,
                                                    vstrNarrations, "", 0, "", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        string strBillKey = "";
                        long lngloop = 1;
                        string[] words = strDginvEffect.Split('~');
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('|');
                            if (ooCost[0] != "")
                            {
                                strBillKey = vstrRefNumber + lngloop.ToString().PadLeft(4, '0');
                                strSQL = Voucher.mInsertTranOutward(strBillKey, lngloop, vstrRefNumber, ooCost[1].ToString(), vlngVoucherType,
                                                                                 vdteDate, Utility.Val(ooCost[2].ToString()), Utility.Val(ooCost[4].ToString()), ooCost[0].ToString(), Utility.Val(ooCost[5].ToString()), "O",
                                                                                 vstrBranchID, "", "", ooCost[3].ToString(), ooCost[3].ToString(), "");

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lngloop += 1;
                            }
                        }

                    }
                    if (strGrdTemPlate != "")
                    {
                        string[] words = strGrdTemPlate.Split('~');
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('|');
                            if (ooCost[0] != "")
                            {

                                strSQL = "INSERT INTO ACC_PAYMENT_SCHEDULE(COMP_REF_NO ,LEDGER_NAME,TEMPLATE_NAME,INSTALLMET_NAME,DUE_DATE,MONTHLY_AMOUNT,TO_BY)";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + vstrRefNumber + "'";
                                strSQL = strSQL + ",'" + ooCost[0] + "'";
                                strSQL = strSQL + ",'" + ooCost[1] + "'";
                                strSQL = strSQL + ",'" + ooCost[2].Replace("'", "''") + "'";
                                strSQL = strSQL + "," + Utility.cvtSQLDateString(ooCost[3].ToString()) + "";
                                strSQL = strSQL + "," + Utility.Val(ooCost[4]) + " ";
                                strSQL = strSQL + ",'Dr' ";
                                strSQL = strSQL + ") ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                            }
                        }
                    }
                    if (strGrdTemPlateJV != "")
                    {
                        string[] words = strGrdTemPlateJV.Split('~');
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('|');
                            if (ooCost[0] != "")
                            {

                                strSQL = "INSERT INTO ACC_PAYMENT_SCHEDULE(COMP_REF_NO ,LEDGER_NAME,TEMPLATE_NAME,INSTALLMET_NAME,DUE_DATE,RECEIVE_DATE,RECEIVED_AMOUNT,MONTHLY_AMOUNT,FINE_AMOUNT,TO_BY)";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + vstrRefNumber + "'";
                                strSQL = strSQL + ",'" + ooCost[0].Replace("'", "''") + "'";
                                strSQL = strSQL + ",'" + ooCost[1].Replace("'", "''") + "'";
                                strSQL = strSQL + ",'" + ooCost[2].Replace("'", "''") + "'";
                                strSQL = strSQL + "," + Utility.cvtSQLDateString(ooCost[3].ToString()) + "";
                                strSQL = strSQL + "," + Utility.cvtSQLDateString(ooCost[4].ToString()) + "";
                                strSQL = strSQL + "," + Utility.Val(ooCost[5]) * -1 + " ";
                                strSQL = strSQL + "," + Utility.Val(ooCost[5]) * -1 + " ";
                                strSQL = strSQL + "," + Utility.Val(ooCost[6]) + " ";
                                strSQL = strSQL + ",'Cr' ";
                                strSQL = strSQL + ") ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                strSQL = "UPDATE ACC_PAYMENT_SCHEDULE SET INSTALL_STATUS=1 ";
                                strSQL = strSQL + " WHERE LEDGER_NAME='" + ooCost[0].Replace("'", "''") + "'";
                                strSQL = strSQL + " AND TEMPLATE_NAME='" + ooCost[1].Replace("'", "''") + "'";
                                strSQL = strSQL + " AND INSTALLMET_NAME='" + ooCost[2].Replace("'", "''") + "'";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }
                    cmdInsert.Transaction.Commit();
                    cmdInsert.Dispose();
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }

            }
        }
        #endregion
        #region "Branch"
        public string mSaveBranchInfo(string strDeComID,string vstrBranchName, string vstrAddress1, string vstrAddress2, string vstrCountry, string vstrPhone,
                                        string vstrFax, string vstrEmail, string vstrComment, string vstrDefaultBranch, string vstInactive, 
                                        string vstrGodown)
        {

            string strresponse, strSQL, strbranchID = "", strBranchNameLedger = "", strBranchName = "", strAddress1 = "", strAddress2 = "", strCountry,
                strComment, strLedgerParent = "", strLedgerPrimary = "", strLedgerOneDown = "", strBranchLedger = "",  strledgerName = "";
            long lngDefaultBranch = 0, lngBranchActive = 0;

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

                    strbranchID = Utility.mstrGetLastBranch(strDeComID);
                    strBranchName = vstrBranchName.Trim().Replace("'", "''");
                    strAddress1 = vstrAddress1.Trim().Replace("'", "''");
                    strAddress2 = vstrAddress2.Trim().Replace("'", "''");
                    strCountry = vstrCountry.Trim().Replace("'", "''");
                    strComment = vstrComment.Trim().Replace("'", "''");
                    if (vstrDefaultBranch.ToUpper() == "YES")
                    {
                        lngDefaultBranch = 1;
                    }
                    if (vstInactive.ToUpper() == "YES")
                    {
                        lngBranchActive = 1;
                    }
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT BRANCH_NAME FROM ACC_BRANCH WHERE BRANCH_TYPE = 1 ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();

                    if (dr.Read())
                    {
                        strBranchNameLedger = dr["BRANCH_NAME"].ToString();
                    }
                    dr.Close();
                    strSQL = "SELECT LEDGER_PARENT_GROUP,LEDGER_PRIMARY_GROUP,LEDGER_ONE_DOWN FROM ACC_LEDGER WHERE LEDGER_NAME  = '" + strBranchNameLedger + "' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        strLedgerParent = dr["LEDGER_PARENT_GROUP"].ToString();
                        strLedgerPrimary = dr["LEDGER_PRIMARY_GROUP"].ToString();
                        strLedgerOneDown = dr["LEDGER_ONE_DOWN"].ToString();
                    }
                    else
                    {
                        dr.Close();
                        strSQL = "SELECT LEDGER_PARENT_GROUP,LEDGER_PRIMARY_GROUP,LEDGER_ONE_DOWN FROM ACC_LEDGER ";
                        strSQL = strSQL + "WHERE LEDGER_DEFAULT  = 1 ";
                        strSQL = strSQL + "AND LEDGER_GROUP = 217 ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            strLedgerParent = dr["LEDGER_PARENT_GROUP"].ToString();
                            strLedgerPrimary = dr["LEDGER_PRIMARY_GROUP"].ToString();
                            strLedgerOneDown = dr["LEDGER_ONE_DOWN"].ToString();
                        }
                    }

                    dr.Close();
                    strSQL = "INSERT INTO ACC_BRANCH(";
                    strSQL = strSQL + "BRANCH_ID,BRANCH_NAME,BRANCH_INT_NAME,BRANCH_ADD1,BRANCH_NAME_DEFAULT,";
                    if (vstrAddress2 != "")
                    {
                        strSQL = strSQL + "BRANCH_ADD2 , ";
                    }
                    if (vstrCountry != "")
                    {
                        strSQL = strSQL + "BRANCH_COUNTRY , ";
                    }
                    strSQL = strSQL + "BRANCH_PHONE,";
                    if (vstrFax != "")
                    {
                        strSQL = strSQL + "BRANCH_FAX , ";
                    }
                    strSQL = strSQL + "BRANCH_STATUS,BRANCH_FLAG,BRANCH_ACTIVE,BRANCH_COMMENTS)";
                    strSQL = strSQL + " VALUES(";
                    strSQL = strSQL + "'" + strbranchID + "',";
                    strSQL = strSQL + "'" + strBranchName + "',";
                    strSQL = strSQL + "'" + Utility.gstrRemoveSpaceAndUCase(strBranchName) + "',";
                    strSQL = strSQL + "'" + strAddress1 + "',";
                    strSQL = strSQL + "'" + strBranchName + "',";
                    if (vstrAddress2 != "")
                    {
                        strSQL = strSQL + "'" + strAddress2 + "',";
                    }
                    if (vstrCountry != "")
                    {
                        strSQL = strSQL + "'" + strCountry + "',"; ;
                    }
                    if (vstrPhone != "")
                    {
                        strSQL = strSQL + "NULL,";
                    }
                    else
                    {
                        strSQL = strSQL + "'" + vstrPhone.TrimStart().Replace("'", "''") + "',";
                    }
                    if (vstrFax != "")
                    {
                        strSQL = strSQL + "'" + vstrFax.TrimStart().Replace("'", "''") + "',";
                    }
                    strSQL = strSQL + "'A'," + lngDefaultBranch + "," + lngBranchActive + ",";
                    if (vstrComment != "")
                    {
                        strSQL = strSQL + "NULL";
                    }
                    else
                    {
                        strSQL = strSQL + "'" + strComment + "'";
                    }
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'***LEDGER BRANCH
                    strBranchLedger = strBranchName;
                    // 'strBranchLedger = strBranchName
                    strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER WHERE LEDGER_NAME_DEFAULT  = '" + strBranchLedger + "' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (!dr.Read())
                    {
                        dr.Close();
                        strSQL = "INSERT INTO ACC_LEDGER(LEDGER_NAME,LEDGER_NAME_MERZE,LEDGER_PARENT_GROUP,LEDGER_PRIMARY_GROUP,LEDGER_ONE_DOWN,LEDGER_OPENING_BALANCE,LEDGER_CLOSING_BALANCE,";
                        strSQL = strSQL + "LEDGER_GROUP,LEDGER_LEVEL,LEDGER_PRIMARY_TYPE,LEDGER_DEFAULT,LEDGER_CURRENCY_SYMBOL) ";
                        strSQL = strSQL + "VALUES('" + strBranchLedger + "','" + strBranchLedger + "','" + strLedgerParent + "','" + strLedgerPrimary + "', '" + strLedgerOneDown + "  ',  0, 0, " + (long)(Utility.GR_GROUP_TYPE.grBRANCH_ACCOUNT) + ",  3,  2,1,'" + Utility.gstrBaseCurrency.TrimStart() + "')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('" + strLedgerParent + "','" + strBranchLedger + "')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('" + strLedgerPrimary + "','" + strBranchLedger + "')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        //'Insert Godowns
                        strSQL = "INSERT INTO INV_GODOWNS(BRANCH_ID,GODOWNS_NAME,GODOWNS_PARENT_GROUP,GODOWNS_DEFAULT) ";
                        strSQL = strSQL + "VALUES('" + strbranchID + "','" + vstrGodown.Replace("'", "''") + "',";
                        strSQL = strSQL + "'Primary" + "',1)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO INV_STOCKITEM_CLOSING(STOCKITEM_NAME,GODOWNS_NAME) ";
                        strSQL = strSQL + "SELECT STOCKITEM_NAME ,'" + vstrGodown + "' FROM INV_STOCKITEM_CLOSING ";
                        strSQL = strSQL + " where GODOWNS_NAME ='Main Location' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    dr.Close();
                    strSQL = "SELECT LEDGER_NAME FROM ACC_BRANCH_LEDGER_OPENING WHERE LEDGER_NAME  = '" + strledgerName.Replace("'", "''") +"' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (!dr.Read())
                    {
                        //strledgerName = dr["LEDGER_NAME"].ToString();
                        dr.Close();
                        strSQL = "INSERT INTO ACC_BRANCH_LEDGER_OPENING(BRANCH_LEDGER_KEY,BRANCH_ID,LEDGER_NAME) ";
                        strSQL = strSQL + "VALUES (";
                        strSQL = strSQL + "'" + strBranchLedger.Replace("'", "''") + strbranchID + "',";
                        strSQL = strSQL + "'" + strbranchID + "',";
                        strSQL = strSQL + "'" + strBranchLedger.Replace("'", "''") + "')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    dr.Close();
                    //                strSQL = "SELECT STOCKITEM_NAME FROM INV_STOCKITEM "
                    //If gobjEnhance.SearchRecord(strSQL, rsGet, adLockReadOnly, gcnMain) Then
                    //    Do While Not rsGet.EOF
                    //        strSQL = "INSERT INTO INV_STOCKITEM_CLOSING(STOCKITEM_NAME,GODOWNS_NAME "
                    //        strSQL = strSQL & ")VALUES('" & Replace(rsGet![STOCKITEM_NAME], "'", "''") & "',"
                    //        strSQL = strSQL & "'" & Replace(uctxtGodown.Text, "'", "''") & "')"
                    //        gcnMain.Execute strSQL
                    //        rsGet.MoveNext
                    //    Loop
                    //End If

                    //strSQL = "SELECT USER_LOGIN_NAME FROM USER_CONFIG WHERE USER_LEBEL=1"
                    //If gobjEnhance.SearchRecord(strSQL, rsGet, adLockReadOnly, gcnMain) Then
                    //    Do While Not rsGet.EOF
                    //        strUserName = rsGet![USER_LOGIN_NAME]
                    //        strSQL = "INSERT INTO USER_PRIVILEGES_BRANCH(USER_LOGIN_KEY,USER_LOGIN_NAME,BRANCH_ID)"
                    //        strSQL = strSQL & "VALUES("
                    //        strSQL = strSQL & "'" & uctxtBranchID.Text & strUserName & "',"
                    //        strSQL = strSQL & "'" & strUserName & "',"
                    //        strSQL = strSQL & "'" & uctxtBranchID.Text & "')"
                    //        gcnMain.Execute strSQL
                    //        rsGet.MoveNext
                    //    Loop
                    //End If



                    cmdInsert.Transaction.Commit();
                    strresponse = "Insert Successfully...";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return "Sorry! Location Name is already Exists..";
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }


        public List<BranchConfig> mFillGetBranch(string strDeComID)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<BranchConfig> ooCategory = new List<BranchConfig>();
            strSQL = "SELECT * FROM ACC_BRANCH ORDER BY BRANCH_NAME";

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
                    BranchConfig oCat = new BranchConfig();
                    oCat.BranchID = dr["BRANCH_ID"].ToString();
                    oCat.BranchName = dr["BRANCH_NAME"].ToString();
                    if (dr["BRANCH_ADD1"].ToString() != "")
                    {
                        oCat.BranchAddress1 = dr["BRANCH_ADD1"].ToString();
                    }
                    else
                    {
                        oCat.BranchAddress1 = "";
                    }
                    if (dr["BRANCH_ADD2"].ToString() != "")
                    {
                        oCat.BranchAddress2 = dr["BRANCH_ADD2"].ToString();
                    }
                    else
                    {
                        oCat.BranchAddress2 = "";
                    }
                    if (dr["BRANCH_COUNTRY"].ToString() != "")
                    {
                        oCat.Country = dr["BRANCH_COUNTRY"].ToString();
                    }
                    else
                    {
                        oCat.Country = "Bangladesh";
                    }
                    if (dr["BRANCH_PHONE"].ToString() != "")
                    {
                        oCat.Phone = dr["BRANCH_PHONE"].ToString();
                    }
                    else
                    {
                        oCat.Phone = "";
                    }
                    if (dr["BRANCH_FAX"].ToString() != "")
                    {
                        oCat.Fax = dr["BRANCH_FAX"].ToString();
                    }
                    else
                    {
                        oCat.Fax = "";
                    }
                    if (dr["BRANCH_ACTIVE"].ToString() == "0")
                    {
                        oCat.Status = "NO";
                    }
                    else
                    {
                        oCat.Status = "Yes";
                    }





                    ooCategory.Add(oCat);
                }
                return ooCategory;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }


        public string mUpdateBranchInfo(string strDeComID,string vstrBranchID, string vstrBranchName, string vstrAddress1, string vstrAddress2, string vstrCountry, string vstrPhone,
                                  string vstrFax, string vstrEmail, string vstrComment, string vstrDefaultBranch, string vstInactive, string vstrGodown)
        {

            string strresponse, strSQL, strBranchNameLedger = "", strBranchName = "", strAddress1 = "", strAddress2 = "", strCountry,
                strComment, strLedgerParent = "", strLedgerPrimary = "", strTempBranch = "", strLedgerOneDown = "", strBranchLedger = "",  strledgerName = "";
            long lngBranchActive = 0, lngDefaultBranch=0;

            strTempBranch = vstrBranchName;
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

                    //strbranchID = Utility.mstrGetLastBranch();
                    strBranchName = vstrBranchName.Trim().Replace("'", "''");
                    strAddress1 = vstrAddress1.Trim().Replace("'", "''");
                    strAddress2 = vstrAddress2.Trim().Replace("'", "''");
                    strCountry = vstrCountry.Trim().Replace("'", "''");
                    strComment = vstrComment.Trim().Replace("'", "''");
                    if (vstrDefaultBranch.ToUpper() == "YES")
                    {
                        lngDefaultBranch = 1;
                    }
                    else
                    {
                        lngDefaultBranch = 0;
                    }
                    if (vstInactive.ToUpper() == "YES")
                    {
                        lngBranchActive = 1;
                    }
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT BRANCH_NAME FROM ACC_BRANCH WHERE BRANCH_ID = '" + vstrBranchID + "' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();

                    if (dr.Read())
                    {
                        strTempBranch = dr["BRANCH_NAME"].ToString();
                    }
                    dr.Close();

                    strSQL = "SELECT BRANCH_TYPE FROM ACC_BRANCH WHERE BRANCH_ID = '" + vstrBranchID + "' AND BRANCH_TYPE = 1 ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();

                    if (dr.Read())
                    {

                        return "Sorry! This is Default Branch of the Company, Can't Update";
                    }
                    dr.Close();
                    strSQL = "SELECT BRANCH_NAME FROM ACC_BRANCH WHERE BRANCH_TYPE = 1 ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();

                    if (dr.Read())
                    {
                        strBranchNameLedger = dr["BRANCH_NAME"].ToString();
                    }
                    dr.Close();
                    strSQL = "SELECT LEDGER_PARENT_GROUP,LEDGER_PRIMARY_GROUP,LEDGER_ONE_DOWN FROM ACC_LEDGER WHERE LEDGER_NAME  = '" + strBranchNameLedger + "' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        strLedgerParent = dr["LEDGER_PARENT_GROUP"].ToString();
                        strLedgerPrimary = dr["LEDGER_PRIMARY_GROUP"].ToString();
                        strLedgerOneDown = dr["LEDGER_ONE_DOWN"].ToString();
                    }
                    else
                    {
                        dr.Close();
                        strSQL = "SELECT LEDGER_PARENT_GROUP,LEDGER_PRIMARY_GROUP,LEDGER_ONE_DOWN FROM ACC_LEDGER ";
                        strSQL = strSQL + "WHERE LEDGER_DEFAULT  = 1 ";
                        strSQL = strSQL + "AND LEDGER_GROUP = 217 ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            strLedgerParent = dr["LEDGER_PARENT_GROUP"].ToString();
                            strLedgerPrimary = dr["LEDGER_PRIMARY_GROUP"].ToString();
                            strLedgerOneDown = dr["LEDGER_ONE_DOWN"].ToString();
                        }
                    }

                    dr.Close();


                    strSQL = "UPDATE ACC_BRANCH SET ";
                    strSQL = strSQL + "BRANCH_NAME = '" + strBranchName + "',";
                    strSQL = strSQL + "BRANCH_INT_NAME = '" + Utility.gstrRemoveSpaceAndUCase(strBranchName) + "',";
                    strSQL = strSQL + "BRANCH_ADD1 = '" + strAddress1 + "',";
                    strSQL = strSQL + "BRANCH_ACTIVE = " + lngBranchActive + ",";
                    if (vstrBranchName == "")
                    {
                        strSQL = strSQL + "BRANCH_ADD2 = NULL,";
                    }
                    else
                    {
                        strSQL = strSQL + "BRANCH_ADD2 = '" + strAddress2 + "',";
                    }
                    if (vstrCountry != "")
                    {
                        strSQL = strSQL + "BRANCH_COUNTRY = '" + strCountry + "',";
                    }
                    if (vstrPhone != "")
                    {
                        strSQL = strSQL + "BRANCH_PHONE = '" + vstrPhone.Replace("'", "''") + "',";
                    }
                    if (vstrFax != "")
                    {
                        strSQL = strSQL + "BRANCH_FAX = '" + vstrFax.Replace("'", "''") + "',";
                    }
                    strSQL = strSQL + "BRANCH_STATUS = 'A' ";
                    if (vstrComment == "")
                    {
                        strSQL = strSQL + ",BRANCH_COMMENTS = NULL ";
                    }
                    else
                    {
                        strSQL = strSQL + ",BRANCH_COMMENTS = '" + strComment + "' ";
                    }
                    strSQL = strSQL + "WHERE BRANCH_ID = '" + vstrBranchID + "' ";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM ACC_BRANCH_LEDGER_OPENING WHERE BRANCH_ID = '" + vstrBranchID + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_LEDGER_TO_GROUP WHERE LEDGER_NAME = '" + strTempBranch + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_LEDGER WHERE LEDGER_NAME = '" + strTempBranch + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    
                    //'***LEDGER BRANCH
                    strBranchLedger = strBranchName;
                    // 'strBranchLedger = strBranchName

                    strSQL = "INSERT INTO ACC_LEDGER(LEDGER_NAME,LEDGER_NAME_MERZE,LEDGER_PARENT_GROUP,LEDGER_PRIMARY_GROUP,LEDGER_ONE_DOWN,LEDGER_OPENING_BALANCE,LEDGER_CLOSING_BALANCE,";
                    strSQL = strSQL + "LEDGER_GROUP,LEDGER_LEVEL,LEDGER_PRIMARY_TYPE,LEDGER_DEFAULT,LEDGER_CURRENCY_SYMBOL) ";
                    strSQL = strSQL + "VALUES('" + strBranchLedger + "','" + strBranchLedger + "','" + strLedgerParent + "','" + strLedgerPrimary + "', '" + strLedgerOneDown + "  ',  0, 0, " + (long)(Utility.GR_GROUP_TYPE.grBRANCH_ACCOUNT) + ",  3,  2,1,'" + Utility.gstrBaseCurrency.TrimStart() + "')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('" + strLedgerParent + "','" + strBranchLedger + "')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('" + strLedgerPrimary + "','" + strBranchLedger + "')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //'Insert Godowns
                    //strSQL = "INSERT INTO INV_GODOWNS(BRANCH_ID,GODOWNS_NAME,GODOWNS_PARENT_GROUP,GODOWNS_DEFAULT) ";
                    //strSQL = strSQL + "VALUES('" + strbranchID + "','" + vstrGodown.Replace("'", "''") + "',";
                    //strSQL = strSQL + "'Primary" + "',1)";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();
                    strSQL = "SELECT LEDGER_NAME FROM ACC_BRANCH_LEDGER_OPENING WHERE LEDGER_NAME  = '" + strledgerName.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (!dr.Read())
                    {
                        //strledgerName = dr["LEDGER_NAME"].ToString();
                        dr.Close();
                        strSQL = "INSERT INTO ACC_BRANCH_LEDGER_OPENING(BRANCH_LEDGER_KEY,BRANCH_ID,LEDGER_NAME) ";
                        strSQL = strSQL + "VALUES (";
                        strSQL = strSQL + "'" + strBranchLedger.Replace("'", "''") + vstrBranchID + "',";
                        strSQL = strSQL + "'" + vstrBranchID + "',";
                        strSQL = strSQL + "'" + strBranchLedger.Replace("'", "''") + "')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    dr.Close();
                    //                strSQL = "SELECT STOCKITEM_NAME FROM INV_STOCKITEM "
                    //If gobjEnhance.SearchRecord(strSQL, rsGet, adLockReadOnly, gcnMain) Then
                    //    Do While Not rsGet.EOF
                    //        strSQL = "INSERT INTO INV_STOCKITEM_CLOSING(STOCKITEM_NAME,GODOWNS_NAME "
                    //        strSQL = strSQL + ")VALUES('" + Replace(rsGet![STOCKITEM_NAME], "'", "''") + "',"
                    //        strSQL = strSQL + "'" + Replace(uctxtGodown.Text, "'", "''") + "')"
                    //        gcnMain.Execute strSQL
                    //        rsGet.MoveNext
                    //    Loop
                    //End If

                    //strSQL = "SELECT USER_LOGIN_NAME FROM USER_CONFIG WHERE USER_LEBEL=1"
                    //If gobjEnhance.SearchRecord(strSQL, rsGet, adLockReadOnly, gcnMain) Then
                    //    Do While Not rsGet.EOF
                    //        strUserName = rsGet![USER_LOGIN_NAME]
                    //        strSQL = "INSERT INTO USER_PRIVILEGES_BRANCH(USER_LOGIN_KEY,USER_LOGIN_NAME,BRANCH_ID)"
                    //        strSQL = strSQL + "VALUES("
                    //        strSQL = strSQL + "'" + uctxtBranchID.Text + strUserName + "',"
                    //        strSQL = strSQL + "'" + strUserName + "',"
                    //        strSQL = strSQL + "'" + uctxtBranchID.Text + "')"
                    //        gcnMain.Execute strSQL
                    //        rsGet.MoveNext
                    //    Loop
                    //End If
                    //strSQL = "SELECT BRANCH_ID FROM INV_GODOWNS WHERE GODOWNS_NAME  = '" + vstrBranchName.Replace("'", "''") + "' ";
                    //cmdInsert.CommandText = strSQL;
                    //dr = cmdInsert.ExecuteReader();
                    //if (!dr.Read())
                    //{
                    //    dr.Close();
                        strSQL = "UPDATE INV_GODOWNS SET ";
                        strSQL = strSQL + "GODOWNS_NAME = '" + vstrBranchName.Replace("'", "''") + "' ";
                        strSQL = strSQL + "WHERE BRANCH_ID = '" + vstrBranchID + "' ";
                        strSQL = strSQL + "AND GODOWNS_DEFAULT=1";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    //}
                    dr.Close();
                    cmdInsert.Transaction.Commit();
                    strresponse = "Update Successfully...";
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


        public string mDeleteBranchInfo(string strDeComID,string vstrBranchID, string vstrLedgerName)
        {
            string strresponse, strSQL, strParent = "", strPrimary = "", strTempBranch = "";

            long lngDefaultLedger = 0;

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
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT LEDGER_NAME,LEDGER_PARENT_GROUP, LEDGER_PRIMARY_GROUP,LEDGER_OPENING_BALANCE,LEDGER_CLOSING_BALANCE,LEDGER_DEFAULT ";
                    strSQL = strSQL + "FROM ACC_LEDGER WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();

                    if (dr.Read())
                    {
                        lngDefaultLedger = Convert.ToInt64(dr["LEDGER_DEFAULT"].ToString());
                        strParent = dr["LEDGER_PARENT_GROUP"].ToString();
                        strPrimary = dr["LEDGER_PRIMARY_GROUP"].ToString();
                        strTempBranch = dr["LEDGER_NAME"].ToString();
                    }
                    dr.Close();
                    strSQL = "SELECT  SUM(STOCKITEM_CLOSING_BALANCE) ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING WHERE GODOWNS_NAME = '" + vstrLedgerName + "' ";
                    strSQL = strSQL + " HAVING SUM(STOCKITEM_CLOSING_BALANCE) > 0 ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();

                    if (dr.Read())
                    {
                        return "Transaction found Cannot Delete";
                    }
                    dr.Close();

                    strSQL = "SELECT * FROM ACC_VOUCHER WHERE LEDGER_NAME='" + vstrLedgerName + "'";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();

                    if (dr.Read())
                    {

                        return "Related Data exists";
                    }
                    dr.Close();

                    strSQL = "DELETE FROM INV_STOCKITEM_CLOSING WHERE GODOWNS_NAME = '" + strTempBranch + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_LEDGER_TO_GROUP WHERE LEDGER_NAME = '" + strTempBranch + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                   
                    strSQL = "DELETE FROM ACC_BRANCH_LEDGER_OPENING WHERE LEDGER_NAME = '" + strTempBranch + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM INV_GODOWNS WHERE BRANCH_ID = '" + vstrBranchID + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM ACC_LEDGER WHERE LEDGER_NAME = '" + strTempBranch + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_BRANCH WHERE BRANCH_ID  = '" + vstrBranchID + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    strresponse = "Delete Successfully...";
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
        #region"Fixed Assets"
        public string mSaveFixedAssets(string strDeComID,string vsstrLedgerName,
                            double dblFixedPurhaseAmount, string strEffectoveForm, long lngReducingBal,
                            double dblAssetsLife, double dblDepRate, double dblAccDep, double dblWrittendownvalue,
                            double dblSalvageValue, double lngAssetPercent, string strAssetsGrid,string strDGAccBra)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                SqlDataReader dr;
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

                strSQL = "DELETE FROM ACC_FIXED_ASSET_PURCHASE_AMOUNT WHERE LEDGER_NAME='" + vsstrLedgerName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION WHERE LEDGER_NAME='" + vsstrLedgerName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM ACC_FIXED_ASSETS WHERE LEDGER_NAME='" + vsstrLedgerName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO ACC_FIXED_ASSETS(";
                strSQL = strSQL + "LEDGER_NAME,ASSET_PURCHASE_COST,ASSET_DEP_EFF_DATE,";
                strSQL = strSQL + "ASSET_DEP_METHOD,ASSET_LIFE,ASSET_DEP_RATE,ASSET_ACCU_DEP,";
                strSQL = strSQL + "ASSET_WRITTEN_VALUE,ASSET_SALVAGE_VALUE,ASSET_PERCENT)";
                strSQL = strSQL + "VALUES(";
                strSQL = strSQL + "'" + vsstrLedgerName + "',";
                strSQL = strSQL + "" + dblFixedPurhaseAmount + ",";
                strSQL = strSQL + "" + Utility.cvtSQLDateString(strEffectoveForm) + ",";
                strSQL = strSQL + "" + lngReducingBal + ",";
                strSQL = strSQL + "" + dblAssetsLife + ",";
                strSQL = strSQL + "" + dblDepRate + ",";
                strSQL = strSQL + "" + dblAccDep + ",";
                strSQL = strSQL + "" + dblWrittendownvalue + ",";
                strSQL = strSQL + "" + dblSalvageValue + ",";
                strSQL = strSQL + "" + lngAssetPercent + "";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                if (dblFixedPurhaseAmount != 0)
                {
                    string strBranchName;
                    double dblAssetsAmount = 0;
                    string[] words = strAssetsGrid.Split('~');
                    foreach (string ooassets in words)
                    {
                        string[] oAssets = ooassets.Split(',');
                        if (oAssets[0] != "")
                        {
                            strBranchName = oAssets[0].ToString();
                            dblAssetsAmount = Convert.ToDouble(oAssets[1]);
                            strSQL = "INSERT INTO ACC_FIXED_ASSET_PURCHASE_AMOUNT (";
                            strSQL = strSQL + "BRANCH_LEDGER_KEY,BRANCH_ID,";
                            strSQL = strSQL + "LEDGER_NAME,BRANCH_PURCHASE_AMOUNT ";
                            strSQL = strSQL + ") ";
                            strSQL = strSQL + "VALUES (";
                            strSQL = strSQL + "'" + vsstrLedgerName + Utility.gstrGetBranchID(strDeComID, strBranchName) + "' ,";
                            strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID, strBranchName) + "',";
                            strSQL = strSQL + "'" + vsstrLedgerName + "',";
                            strSQL = strSQL + " " + dblAssetsAmount + " ";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                    }

                    words = strDGAccBra.Split('~');
                    foreach (string ooassets in words)
                    {
                        string[] oAssets = ooassets.Split(',');
                        if (oAssets[0] != "")
                        {
                            strBranchName = oAssets[0].ToString();
                            dblAssetsAmount = Convert.ToDouble(oAssets[1]);
                            strSQL = "INSERT INTO ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION (";
                            strSQL = strSQL + "BRANCH_LEDGER_KEY,BRANCH_ID, ";
                            strSQL = strSQL + "LEDGER_NAME,BRANCH_ACCUMULATED_DEPRECIATION ";
                            strSQL = strSQL + ") ";
                            strSQL = strSQL + "VALUES (";
                            strSQL = strSQL + "'" + vsstrLedgerName + Utility.gstrGetBranchID(strDeComID, strBranchName) + "' ,";
                            strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID, strBranchName) + "',";
                            strSQL = strSQL + "'" + vsstrLedgerName + "',";
                            strSQL = strSQL + " " + dblAssetsAmount + " ";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                    }

                }

                cmdInsert.Transaction.Commit();
                return "Inserted...";
            }

        }

        public string mUpdateFixedAssets(string strDeComID,long mlngAssetSerial, string mstrOldLedger, string vsstrLedgerName,
                                 double dblFixedPurhaseAmount, string strEffectoveForm, long lngReducingBal,
                                 double dblAssetsLife, double dblDepRate, double dblAccDep, double dblWrittendownvalue,
                                 double dblSalvageValue, double lngAssetPercent, string strAssetsGrid, string strDGAccBra)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                SqlDataReader dr;
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


                strSQL = "UPDATE ACC_FIXED_ASSETS SET ";
                strSQL = strSQL + "LEDGER_NAME = '" + vsstrLedgerName + "',";
                strSQL = strSQL + "ASSET_PURCHASE_COST = " + dblFixedPurhaseAmount + ",";
                strSQL = strSQL + "ASSET_DEP_EFF_DATE = " + Utility.cvtSQLDateString(strEffectoveForm) + ",";
                strSQL = strSQL + "ASSET_DEP_METHOD = " + lngReducingBal + ",";
                strSQL = strSQL + "ASSET_LIFE = " + dblAssetsLife + ",";
                strSQL = strSQL + "ASSET_DEP_RATE = " + dblDepRate + ",";
                strSQL = strSQL + "ASSET_ACCU_DEP = " + dblAccDep + ",";
                strSQL = strSQL + "ASSET_SALVAGE_VALUE = " + dblWrittendownvalue + ",";
                strSQL = strSQL + "ASSET_WRITTEN_VALUE = " + dblSalvageValue + ",";
                strSQL = strSQL + "ASSET_PERCENT = " + lngAssetPercent + " ";
                strSQL = strSQL + "WHERE ASSET_SERIAL = " + mlngAssetSerial + " ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "DELETE FROM ACC_FIXED_ASSET_PURCHASE_AMOUNT WHERE LEDGER_NAME = '" + mstrOldLedger + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                if (dblFixedPurhaseAmount != 0)
                {
                    string strBranchName;
                    double dblAssetsAmount = 0;
                    string[] words = strAssetsGrid.Split('~');
                    foreach (string ooassets in words)
                    {
                        string[] oAssets = ooassets.Split(',');
                        if (oAssets[0] != "")
                        {
                            strBranchName = oAssets[0].ToString();
                            dblAssetsAmount = Convert.ToDouble(oAssets[1]);
                            strSQL = "INSERT INTO ACC_FIXED_ASSET_PURCHASE_AMOUNT (";
                            strSQL = strSQL + "BRANCH_LEDGER_KEY,BRANCH_ID,";
                            strSQL = strSQL + "LEDGER_NAME,BRANCH_PURCHASE_AMOUNT ";
                            strSQL = strSQL + ") ";
                            strSQL = strSQL + "VALUES (";
                            strSQL = strSQL + "'" + vsstrLedgerName + Utility.gstrGetBranchID(strDeComID, strBranchName) + "' ,";
                            strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID, strBranchName) + "',";
                            strSQL = strSQL + "'" + vsstrLedgerName + "',";
                            strSQL = strSQL + " " + dblAssetsAmount + " ";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                    strSQL = "DELETE FROM ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION WHERE LEDGER_NAME = '" + mstrOldLedger + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    words = strDGAccBra.Split('~');
                    foreach (string ooassets in words)
                    {
                        string[] oAssets = ooassets.Split(',');
                        if (oAssets[0] != "")
                        {
                            strBranchName = oAssets[0].ToString();
                            dblAssetsAmount = Convert.ToDouble(oAssets[1]);
                            strSQL = "INSERT INTO ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION (";
                            strSQL = strSQL + "BRANCH_LEDGER_KEY,BRANCH_ID, ";
                            strSQL = strSQL + "LEDGER_NAME,BRANCH_ACCUMULATED_DEPRECIATION ";
                            strSQL = strSQL + ") ";
                            strSQL = strSQL + "VALUES (";
                            strSQL = strSQL + "'" + vsstrLedgerName + Utility.gstrGetBranchID(strDeComID, strBranchName) + "' ,";
                            strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID, strBranchName) + "',";
                            strSQL = strSQL + "'" + vsstrLedgerName + "',";
                            strSQL = strSQL + " " + dblAssetsAmount + " ";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                    }

                }

                cmdInsert.Transaction.Commit();
                return "Updated...";
            }

        }

        public List<FixedAssets> mAssetList(string strDeComID)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<FixedAssets> ooAccLedger = new List<FixedAssets>();
            strSQL = "SELECT * FROM ACC_FIXED_ASSETS ";
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
                    FixedAssets oLedg = new FixedAssets();
                    oLedg.lngSerialNo = Convert.ToInt64(dr["ASSET_SERIAL"].ToString());
                    oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
                    if (dr["ASSET_DEP_METHOD"].ToString() == "1")
                    {
                        oLedg.strDepMethod = "Reducing Balance";
                    }
                    else
                    {
                        oLedg.strDepMethod = "Straight Line";
                    }
                    oLedg.dblPurchaseAmount = Convert.ToDouble(dr["ASSET_PURCHASE_COST"].ToString());

                    ooAccLedger.Add(oLedg);
                }
                return ooAccLedger;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }

        public string mDeleteFixedAssets(string strDeComID,long mlngAssetSerial, string mstrOldLedger)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                SqlDataReader dr;
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

                strSQL = "DELETE FROM ACC_FIXED_ASSET_PURCHASE_AMOUNT WHERE LEDGER_NAME = '" + mstrOldLedger + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "DELETE FROM ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION WHERE LEDGER_NAME = '" + mstrOldLedger + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM ACC_FIXED_ASSETS WHERE ASSET_SERIAL = '" + mlngAssetSerial + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();
                return "1";
            }

        }

        //public List<FixedAssets> mAssetList()
        //{
        //    string strSQL = null;
        //    SqlDataReader dr;
        //    List<FixedAssets> ooAccLedger = new List<FixedAssets>();
        //    strSQL = "SELECT * FROM ACC_FIXED_ASSETS ";
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();
        //        SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
        //        dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            FixedAssets oLedg = new FixedAssets();
        //            oLedg.lngSerialNo = Convert.ToInt64(dr["ASSET_SERIAL"].ToString());
        //            oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
        //            if (dr["ASSET_DEP_METHOD"].ToString() == "1")
        //            {
        //                oLedg.strDepMethod = "Reducing Balance";
        //            }
        //            else
        //            {
        //                oLedg.strDepMethod = "Straight Line";
        //            }
        //            oLedg.dblPurchaseAmount = Convert.ToDouble(dr["ASSET_PURCHASE_COST"].ToString());

        //            ooAccLedger.Add(oLedg);
        //        }
        //        return ooAccLedger;
        //        dr.Close();
        //        gcnMain.Close();
        //        gcnMain.Dispose();
        //    }

        //}
        //public List<FixedAssets> mDisplayAssetListLedger(string strDeComID, string  mstrLedgerName)
        //{
        //    string strSQL = null;
        //    SqlDataReader dr;
        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);
        //    List<FixedAssets> ooAccLedger = new List<FixedAssets>();
        //    strSQL = strSQL + "SELECT * FROM ACC_FIXED_ASSETS ";
        //    strSQL = strSQL + "WHERE LEDGER_NAME = '" + mstrLedgerName + "' ";
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();
        //        SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
        //        dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            FixedAssets oLedg = new FixedAssets();
        //            oLedg.lngSerialNo = Convert.ToInt64(dr["ASSET_SERIAL"].ToString());
        //            oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
        //            oLedg.dblPurchaseAmount = Convert.ToDouble(dr["ASSET_PURCHASE_COST"].ToString());
        //            oLedg.strEffectiveDate = Convert.ToDateTime(dr["ASSET_DEP_EFF_DATE"]).ToString("dd/MM/yyyy");
        //            if (dr["ASSET_DEP_METHOD"].ToString() == "1")
        //            {
        //                oLedg.strDepMethod = "Reducing Balance";
        //            }
        //            else
        //            {
        //                oLedg.strDepMethod = "Straight Line";
        //            }
        //            oLedg.dblAssetsLife = Convert.ToDouble(dr["ASSET_LIFE"].ToString());
        //            oLedg.dblDepRate = Convert.ToDouble(dr["ASSET_DEP_RATE"].ToString());
        //            oLedg.dblAccumulatedDep = Convert.ToDouble(dr["ASSET_ACCU_DEP"].ToString());
        //            oLedg.dblWrittendownValue = Convert.ToDouble(dr["ASSET_WRITTEN_VALUE"].ToString());
        //            oLedg.dblSalvageValue = Convert.ToDouble(dr["ASSET_SALVAGE_VALUE"].ToString());


        //            ooAccLedger.Add(oLedg);
        //        }
        //        return ooAccLedger;
        //        dr.Close();
        //        gcnMain.Close();
        //        gcnMain.Dispose();
        //    }

        //}
        public List<FixedAssets> mDisplayAssetList(string strDeComID,long mlngAssetSerial)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<FixedAssets> ooAccLedger = new List<FixedAssets>();
            strSQL = strSQL + "SELECT * FROM ACC_FIXED_ASSETS ";
            strSQL = strSQL + "WHERE ASSET_SERIAL = " + mlngAssetSerial + " ";
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
                    FixedAssets oLedg = new FixedAssets();
                    oLedg.lngSerialNo = Convert.ToInt64(dr["ASSET_SERIAL"].ToString());
                    oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oLedg.dblPurchaseAmount = Convert.ToDouble(dr["ASSET_PURCHASE_COST"].ToString());
                    oLedg.strEffectiveDate = Convert.ToDateTime(dr["ASSET_DEP_EFF_DATE"]).ToString("dd/MM/yyyy");
                    if (dr["ASSET_DEP_METHOD"].ToString() == "1")
                    {
                        oLedg.strDepMethod = "Reducing Balance";
                    }
                    else
                    {
                        oLedg.strDepMethod = "Straight Line";
                    }
                    oLedg.dblAssetsLife = Convert.ToDouble(dr["ASSET_LIFE"].ToString());
                    oLedg.dblDepRate = Convert.ToDouble(dr["ASSET_DEP_RATE"].ToString());
                    oLedg.dblAccumulatedDep = Convert.ToDouble(dr["ASSET_ACCU_DEP"].ToString());
                    oLedg.dblWrittendownValue = Convert.ToDouble(dr["ASSET_WRITTEN_VALUE"].ToString());
                    oLedg.dblSalvageValue = Convert.ToDouble(dr["ASSET_SALVAGE_VALUE"].ToString());


                    ooAccLedger.Add(oLedg);
                }
                return ooAccLedger;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }

        public List<FixedAssets> mDisplayFixedBranchList(string strDeComID,string mstrLedgerName)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<FixedAssets> ooAccLedger = new List<FixedAssets>();
            strSQL = strSQL + "SELECT * FROM ACC_FIXED_ASSET_PURCHASE_AMOUNT ";
            strSQL = strSQL + "WHERE LEDGER_NAME = '" + mstrLedgerName + "' ";
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
                    FixedAssets oLedg = new FixedAssets();

                    oLedg.strBranchID = dr["BRANCH_ID"].ToString();
                    oLedg.dblPurchaseAmount = Convert.ToDouble(dr["BRANCH_PURCHASE_AMOUNT"].ToString());

                    ooAccLedger.Add(oLedg);
                }
                return ooAccLedger;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }


        public string mInsertAssetsAdjustment(string strDeComID,string vstrRefNo, string mstrPrimaryKey, string vstrDate, string vstrBranchName, string vstrLedgerName, double dblAmount)
        {

            string strBranchId = "";
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


                    strSQL = "DELETE FROM ACC_FIXED_ASSET_ADJUSTMENT_DEP ";
                    strSQL = strSQL + "WHERE ADJUSTMENT_REF_NO = '" + mstrPrimaryKey + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strBranchId = Utility.gstrGetBranchID(strDeComID, vstrBranchName);

                    strSQL = "INSERT INTO ACC_FIXED_ASSET_ADJUSTMENT_DEP(ADJUSTMENT_REF_NO,BRANCH_ID,LEDGER_NAME,";
                    strSQL = strSQL + "ADJUSTMENT_DATE,ADJUSTMENT_AMOUNT) ";
                    strSQL = strSQL + "VALUES('" + strBranchId + vstrRefNo + "','" + strBranchId + "','" + vstrLedgerName + "'," + Utility.cvtSQLDateString(vstrDate) + ",";
                    strSQL = strSQL + dblAmount + ") ";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    //strresponse = "Insert Successfully...";
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
        public string mDeleteAssetsAdjustment(string strDeComID,string mstrPrimaryKey)
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


                    strSQL = "DELETE FROM ACC_FIXED_ASSET_ADJUSTMENT_DEP ";
                    strSQL = strSQL + "WHERE ADJUSTMENT_REF_NO = '" + mstrPrimaryKey + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    //strresponse = "Insert Successfully...";
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
        public List<FixedAssets> mGetFixedAssetsAdjustment(string strDeComID)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<FixedAssets> ooCategory = new List<FixedAssets>();
            strSQL = "SELECT * FROM ACC_FIXED_ASSET_ADJUSTMENT_DEP ";

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
                    FixedAssets oCat = new FixedAssets();
                    oCat.strRefNo = dr["ADJUSTMENT_REF_NO"].ToString();
                    oCat.strEffectiveDate = Convert.ToDateTime(dr["ADJUSTMENT_DATE"]).ToString("dd/MM/yyyy");
                    oCat.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oCat.strBranchID = dr["BRANCH_ID"].ToString();
                    oCat.dblPurchaseAmount = Convert.ToDouble(dr["ADJUSTMENT_AMOUNT"].ToString());
                    ooCategory.Add(oCat);
                }
                return ooCategory;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }

        #endregion
        #region "Previous Refno"
        public List<AccBillwise> gFillPreRefNoNew2(string strDeComID, string vstrPartyName,
                         long vlngVType, string vstrDate, string vstrBranchID, string vstrGodown, string strvstrRefNo, int intstatus)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccBillwise> oogrp = new List<AccBillwise>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT DISTINCT ACC_COMPANY_VOUCHER.COMP_REF_NO,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE ";
            strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER,ACC_BILL_TRAN where ACC_COMPANY_VOUCHER.COMP_REF_NO =ACC_BILL_TRAN.COMP_REF_NO ";
            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_STATUS = " + intstatus + "";

            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.LEDGER_NAME = '" + vstrPartyName + "' ";
            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = " + vlngVType + " ";
            if (vlngVType == (int)Utility.VOUCHER_TYPE.vtSALES_ORDER)
            {
                strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.APP_STATUS = 2 ";
            }
            if (strvstrRefNo != "")
            {
                strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE like '%" + strvstrRefNo + "%' ";
            }

            if (vstrBranchID != "")
            {
                strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.BRANCH_ID = '" + vstrBranchID + "' ";
                strSQL = strSQL + "AND ACC_BILL_TRAN.GODOWNS_NAME = '" + vstrGodown + "' ";
            }
            strSQL = strSQL + "group by ACC_COMPANY_VOUCHER.COMP_REF_NO,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE ";
            strSQL = strSQL + "Order by ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE DESC,ACC_COMPANY_VOUCHER.COMP_REF_NO ";
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
                    AccBillwise ogrp = new AccBillwise();
                    ogrp.strBillKey = drGetGroup["COMP_REF_NO"].ToString();
                    ogrp.strRefNo = drGetGroup["COMP_REF_NO"].ToString();
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["COMP_VOUCHER_DATE"]).ToString("dd/MM/yyyy");
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<AccBillwise> gFillPreRefNo(string strDeComID,string vstrPartyName,
                         long vlngVType, string vstrDate, string vstrBranchID, string vstrGodown, string strvstrRefNo,int intstatus)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccBillwise> oogrp = new List<AccBillwise>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT DISTINCT ACC_COMPANY_VOUCHER.COMP_REF_NO,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE ";
            strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER,ACC_BILL_TRAN where ACC_COMPANY_VOUCHER.COMP_REF_NO =ACC_BILL_TRAN.COMP_REF_NO ";
            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_STATUS = " + intstatus + "";
          
            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.LEDGER_NAME = '" + vstrPartyName + "' ";
            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = " + vlngVType + " ";
            if (vlngVType==(int)Utility.VOUCHER_TYPE.vtSALES_ORDER)
            {
                strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.APP_STATUS = 1 ";
            }
            if (strvstrRefNo != "")
            {
                strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE like '%" + strvstrRefNo + "%' ";
            }

            if (vstrBranchID != "")
            {
                strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.BRANCH_ID = '" + vstrBranchID + "' ";
                strSQL = strSQL + "AND ACC_BILL_TRAN.GODOWNS_NAME = '" + vstrGodown + "' ";
            }
            strSQL = strSQL + "group by ACC_COMPANY_VOUCHER.COMP_REF_NO,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE ";
            strSQL = strSQL + "Order by ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE DESC,ACC_COMPANY_VOUCHER.COMP_REF_NO ";
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
                    AccBillwise ogrp = new AccBillwise();
                    ogrp.strBillKey = drGetGroup["COMP_REF_NO"].ToString();
                    ogrp.strRefNo = drGetGroup["COMP_REF_NO"].ToString();
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["COMP_VOUCHER_DATE"]).ToString("dd/MM/yyyy");
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<AccBillwise> gFillPreRefNoNew(string strDeComID, string vstrPartyName,
                         long vlngVType, string vstrDate, string vstrBranchID, string vstrGodown, string strvstrRefNo, int intstatus,string strTDate)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccBillwise> oogrp = new List<AccBillwise>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT DISTINCT ACC_COMPANY_VOUCHER.COMP_REF_NO,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE ";
            strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER,ACC_BILL_TRAN where ACC_COMPANY_VOUCHER.COMP_REF_NO =ACC_BILL_TRAN.COMP_REF_NO ";
            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_STATUS = " + intstatus + "";
            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE between " + Utility.cvtSQLDateString(vstrDate) + " ";
            strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + " ";
            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.LEDGER_NAME = '" + vstrPartyName + "' ";
            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = " + vlngVType + " ";
            if (vlngVType == (int)Utility.VOUCHER_TYPE.vtSALES_ORDER)
            {
                strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.APP_STATUS = 1 ";
            }
            if (strvstrRefNo != "")
            {
                strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE like '%" + strvstrRefNo + "%' ";
            }

            if (vstrBranchID != "")
            {
                strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.BRANCH_ID = '" + vstrBranchID + "' ";
                strSQL = strSQL + "AND ACC_BILL_TRAN.GODOWNS_NAME = '" + vstrGodown + "' ";
            }
            strSQL = strSQL + "group by ACC_COMPANY_VOUCHER.COMP_REF_NO,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE ";
            strSQL = strSQL + "Order by ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE DESC,ACC_COMPANY_VOUCHER.COMP_REF_NO ";
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
                    AccBillwise ogrp = new AccBillwise();
                    ogrp.strBillKey = drGetGroup["COMP_REF_NO"].ToString();
                    ogrp.strRefNo = drGetGroup["COMP_REF_NO"].ToString();
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["COMP_VOUCHER_DATE"]).ToString("dd/MM/yyyy");
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        #endregion
        #region "PreSampleclass"
        public List<AccBillwise> gFillPreSampleClass(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccBillwise> oogrp = new List<AccBillwise>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT SAMPLE_CLASS,INSERT_DATE FROM ACC_SAMPLE_CLASS_MASTER ORDER BY SAMPLE_CLASS";

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
                    AccBillwise ogrp = new AccBillwise();
                    ogrp.strBillKey = drGetGroup["SAMPLE_CLASS"].ToString();
                    ogrp.strRefNo = drGetGroup["SAMPLE_CLASS"].ToString();
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["INSERT_DATE"]).ToString("dd/MM/yyyy");
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        #endregion
        #region "User"
        public string mInsertUser(string strDeComID,string vstrLogInName, string vstrFullName, string vstrDepatrtment, string vstrDesignation,
                                       string vstrPassword, string vstrUserLevel, string vstrAccessLevel, string vstrComments, byte[] vImage)
        {

            string strMessage = "", strPassword = "";
            long lngUserLebel = 0;
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

                    if (vstrUserLevel == "Administrator")
                    {
                        lngUserLebel = 1;
                    }
                    else if (vstrUserLevel == "User")
                    {
                        lngUserLebel = 2;
                    }
                    else if (vstrUserLevel == "Report Viewer")
                    {
                        lngUserLebel = 3;
                    }
                    else
                    {
                        strMessage = "Invalid Access Lebel";
                        return strMessage;
                    }
                    vstrLogInName = vstrLogInName.Replace("'", "''");
                    vstrFullName = vstrFullName.Replace("'", "''");
                    vstrDepatrtment = vstrDepatrtment.Replace("'", "''");
                    vstrDesignation = vstrDesignation.Replace("'", "''");
                    vstrComments = vstrComments.Replace("'", "''");

                    strPassword = Utility.Encrypt(vstrPassword, vstrLogInName).ToString();


                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    cmdInsert.CommandText = "InsertUserConfig";
                    cmdInsert.CommandType = CommandType.StoredProcedure;
                    cmdInsert.Parameters.Add("@loginName", SqlDbType.VarChar).Value = vstrLogInName;
                    cmdInsert.Parameters.Add("@fullName", SqlDbType.VarChar).Value = vstrFullName;
                    cmdInsert.Parameters.Add("@pass", SqlDbType.VarChar).Value = vstrPassword;
                    cmdInsert.Parameters.Add("@intUserLevel", SqlDbType.Int).Value = lngUserLebel;
                    cmdInsert.Parameters.Add("@userlevel", SqlDbType.Char).Value = Utility.Left(vstrAccessLevel, 1);
                    cmdInsert.Parameters.Add("@commmets", SqlDbType.VarChar).Value = vstrComments;
                    cmdInsert.Parameters.Add("@img", SqlDbType.Image).Value = vImage;
                    cmdInsert.Parameters.Add("@Department", SqlDbType.VarChar).Value = vstrDepatrtment;
                    cmdInsert.Parameters.Add("@Designation", SqlDbType.VarChar).Value = vstrDesignation;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();

                    return "Insert Successfully";
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

        public string mUpdateInsertUser(string strDeComID,string vstrmstrPk, string vstrLogInName, string vstrFullName, string vstrDepatrtment, string vstrDesignation,
                                            string vstrPassword, string vstrUserLevel, string vstrAccessLevel, string vstrComments, byte[] vImage)
        {

            string strMessage = "", strPassword = "";
            long lngUserLebel = 0;
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

                    if (vstrUserLevel == "Administrator")
                    {
                        lngUserLebel = 1;
                    }
                    else if (vstrUserLevel == "User")
                    {
                        lngUserLebel = 2;
                    }
                    else if (vstrUserLevel == "Report Viewer")
                    {
                        lngUserLebel = 3;
                    }
                    else
                    {
                        strMessage = "Invalid Access Lebel";
                        return strMessage;
                    }
                    vstrLogInName = vstrLogInName.Replace("'", "''");
                    vstrFullName = vstrFullName.Replace("'", "''");
                    vstrDepatrtment = vstrDepatrtment.Replace("'", "''");
                    vstrDesignation = vstrDesignation.Replace("'", "''");
                    vstrComments = vstrComments.Replace("'", "''");

                    strPassword = Utility.Encrypt(vstrPassword, vstrLogInName).ToString();
                    int intLevel = 0;
                    SqlDataReader dr;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;



                    strSQL = "SELECT USER_LEBEL  FROM USER_CONFIG ";
                    strSQL = strSQL + " WHERE USER_LOGIN_NAME = '" + vstrLogInName + "' ";
                    //strSQL = strSQL + " AND USER_LOGIN_NAME= '" + strUserName + "' ";
                    //strSQL = strSQL + " group by USER_LOGIN_SERIAL ORDER BY USER_LOGIN_SERIAL ASC";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        intLevel = Convert.ToInt32(dr["USER_LEBEL"]);
                    }
                    dr.Close();
                    if (intLevel != lngUserLebel)
                    {
                        if (intLevel == 1)
                        {
                            strSQL = "SELECT count(USER_LOGIN_SERIAL) as cnt FROM USER_CONFIG ";
                            strSQL = strSQL + " WHERE USER_LOGIN_NAME <> 'DeepLaid'";
                            strSQL = strSQL + " AND USER_LEBEL = 1 ";
                            //strSQL = strSQL + " AND USER_LOGIN_NAME= '" + strUserName + "' ";
                            //strSQL = strSQL + " group by USER_LOGIN_SERIAL ORDER BY USER_LOGIN_SERIAL ASC";
                            cmdInsert.CommandText = strSQL;
                            dr = cmdInsert.ExecuteReader();
                            if (dr.Read())
                            {
                                if (Convert.ToInt32(dr["cnt"]) == 1)
                                {
                                    return "You Can't Update this, Only One User Should be Admin";
                                }
                            }
                        }
                    }

                    dr.Close();

                    cmdInsert.CommandText = "UpdateUserConfig";
                    cmdInsert.CommandType = CommandType.StoredProcedure;
                    cmdInsert.Parameters.Add("@mstrKey", SqlDbType.VarChar).Value = vstrmstrPk;
                    cmdInsert.Parameters.Add("@loginName", SqlDbType.VarChar).Value = vstrLogInName;
                    cmdInsert.Parameters.Add("@fullName", SqlDbType.VarChar).Value = vstrFullName;
                    cmdInsert.Parameters.Add("@pass", SqlDbType.VarChar).Value = strPassword;
                    cmdInsert.Parameters.Add("@intUserLevel", SqlDbType.Int).Value = lngUserLebel;
                    cmdInsert.Parameters.Add("@userlevel", SqlDbType.Char).Value = Utility.Left(vstrAccessLevel, 1);
                    cmdInsert.Parameters.Add("@commmets", SqlDbType.VarChar).Value = vstrComments;
                    cmdInsert.Parameters.Add("@img", SqlDbType.Image).Value = vImage;
                    cmdInsert.Parameters.Add("@Department", SqlDbType.VarChar).Value = vstrDepatrtment;
                    cmdInsert.Parameters.Add("@Designation", SqlDbType.VarChar).Value = vstrDesignation;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();

                    return "Update Successfully";
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
        public string mDeleteUserControl(string strDeComID, long lngslNo,string strUserName)
        {
            string strSQL;

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
                    int intLevel = 0;
                    SqlDataReader dr;
                    SqlCommand cmdDelete = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdDelete.Connection = gcnMain;
                    cmdDelete.Transaction = myTrans;
                    strSQL = "SELECT USER_LEBEL  FROM USER_CONFIG ";
                    strSQL = strSQL + " WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                    //strSQL = strSQL + " AND USER_LOGIN_NAME= '" + strUserName + "' ";
                    //strSQL = strSQL + " group by USER_LOGIN_SERIAL ORDER BY USER_LOGIN_SERIAL ASC";
                    cmdDelete.CommandText = strSQL;
                    dr = cmdDelete.ExecuteReader();
                    if (dr.Read())
                    {
                        intLevel = Convert.ToInt32(dr["USER_LEBEL"]);
                    }
                    dr.Close();
                    if (intLevel == 1)
                    {
                        strSQL = "SELECT count(USER_LOGIN_SERIAL) as cnt FROM USER_CONFIG ";
                        strSQL = strSQL + " WHERE USER_LOGIN_NAME <> 'DeepLaid'";
                        strSQL = strSQL + " AND USER_LEBEL = 1 ";
                        //strSQL = strSQL + " AND USER_LOGIN_NAME= '" + strUserName + "' ";
                        //strSQL = strSQL + " group by USER_LOGIN_SERIAL ORDER BY USER_LOGIN_SERIAL ASC";
                        cmdDelete.CommandText = strSQL;
                        dr = cmdDelete.ExecuteReader();
                        if (dr.Read())
                        {
                            if (Convert.ToInt32(dr["cnt"]) == 1)
                            {
                                return "You Can't Delete Last Administrator";
                            }
                        }
                    }
                    dr.Close();

                    strSQL = "DELETE FROM USER_PRIVILEGES_CHILD WHERE USER_LOGIN_NAME= '" + strUserName + "' ";
                    cmdDelete.Connection = gcnMain;
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    strSQL = "DELETE FROM USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME= '" + strUserName + "' ";
                    cmdDelete.Connection = gcnMain;
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    strSQL = "DELETE FROM USER_PRIVILEGES_BRANCH WHERE USER_LOGIN_NAME= '" + strUserName + "' ";
                    cmdDelete.Connection = gcnMain;
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    strSQL = "DELETE FROM USER_PRIVILEGES_LOCATION WHERE USER_LOGIN_NAME= '" + strUserName + "' ";
                    cmdDelete.Connection = gcnMain;
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    strSQL = "DELETE FROM USER_PRIVILEGES_MAIN WHERE USER_LOGIN_NAME= '" + strUserName + "' ";
                    cmdDelete.Connection = gcnMain;
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    strSQL = "DELETE FROM USER_CONFIG WHERE USER_LOGIN_SERIAL= " + lngslNo + " ";
                    cmdDelete.Connection = gcnMain;
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    cmdDelete.Transaction.Commit();
                    return "Delete Successfully..";
                }
                catch (Exception ex)
                {
                    return "Transaction Found Cannot Delete";
                }
                finally
                {
                    gcnMain.Close();

                }

            }


        }
        public List<UserAccess> mGetUserAccessData(string strDeComID,string strLogInName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<UserAccess> oogrp = new List<UserAccess>();
            strSQL = "SELECT IMAGE,USER_LOGIN_SERIAL,USER_LOGIN_NAME,USER_FULL_NAME,USER_PASS,USER_LEBEL,USER_STATUS,DEPARTMENT,DESIGNATION, USER_COMMENTS FROM USER_CONFIG ";
            if (strLogInName != "")
            {
                strSQL = strSQL + "WHERE USER_LOGIN_NAME='" + strLogInName + "' ";
            }
            else
            {
                strSQL = strSQL + "WHERE USER_LOGIN_NAME <> '" + "DeepLaid" + "' ";
                //strSQL = strSQL + "AND USER_LOGIN_NAME <> '" + "DeepLaidNew" + "' ";
            }


            strSQL = strSQL + "ORDER BY USER_LOGIN_SERIAL ";
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
                    try
                    {

                        UserAccess ogrp = new UserAccess();
                        ogrp.lngSlNo = Convert.ToInt64(drGetGroup["USER_LOGIN_SERIAL"].ToString());
                        ogrp.LogInName = drGetGroup["USER_LOGIN_NAME"].ToString();
                        ogrp.FullName = drGetGroup["USER_FULL_NAME"].ToString();
                        ogrp.strPassWord = drGetGroup["USER_PASS"].ToString();
                        ogrp.intAccessLevel = Convert.ToInt32(drGetGroup["USER_LEBEL"].ToString());
                        ogrp.strStatus = drGetGroup["USER_STATUS"].ToString();
                        ogrp.Department = drGetGroup["DEPARTMENT"].ToString();
                        ogrp.Designation = drGetGroup["DESIGNATION"].ToString();
                        ogrp.commnets = drGetGroup["USER_COMMENTS"].ToString();
                        //ogrp.commnets = drGetGroup["USER_COMMENTS"].ToString();
                        ogrp.strIamge = drGetGroup["IMAGE"].ToByteArray();
                        long bufLength = drGetGroup.GetBytes(0, 0, null, 0, 0);
                        // Now allocate a buffer big enough to receive the bits...
                        ogrp.strIamge = new byte[bufLength];
                        // Get all bytes from the reader
                        drGetGroup.GetBytes(0, 0, ogrp.strIamge, 0, (int)bufLength);

                        oogrp.Add(ogrp);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        #region "Test Purpose Image"
        //public byte[] GetImage(string strLogInName)
        //{
        //    byte[] result = null;

        //    string query = @"Select IMAGE From USER_CONFIG WHERE USER_LOGIN_NAME ='" + strLogInName + "' ";

        //    using (SqlConnection conn = new SqlConnection(connstring))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                using (DataTable dt = new DataTable())
        //                {
        //                    dt.Load(dr);
        //                    if (dt.Rows.Count > 0)
        //                    {
        //                        DataRow row = dt.Rows[0];
        //                        if (row["IMAGE"] != DBNull.Value)
        //                        {
        //                            try
        //                            {
        //                                result = (byte[])row["IMAGE"];
        //                            }
        //                            catch { }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}
        //public string sevetest(byte[] img)
        //{
        //   // byte[] result = null;

        //    //string query = @"Select IMAGE From USER_CONFIG WHERE USER_LOGIN_NAME ='" + strLogInName + "' ";

        //    using (SqlConnection conn = new SqlConnection(connstring))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("SaveImage", conn))
        //        {
        //            //SqlCommand cmd = new SqlCommand("SaveImage", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@img", SqlDbType.Image).Value = img;
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    return "1";
        //}
        //public byte[] ReadImage(long ID)
        //{
        //     byte[] result = null;

        //    //string query = @"Select IMAGE From USER_CONFIG WHERE USER_LOGIN_NAME ='" + strLogInName + "' ";

        //    using (SqlConnection conn = new SqlConnection(connstring))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("ReadImage", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@imgId", SqlDbType.Int).Value = ID;
        //            SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();

        //            adp.Fill(dt);
        //            if (dt.Rows.Count > 0)
        //            {
        //                result= (byte[])dt.Rows[0]["ImageData"];
        //            }

        //            return result;

        //        }

        //    }
        //}
        #endregion




        #endregion
        #region "Voucher Types"
        public List<VoucherTypes> mLaodVoucherTypes(string strDeComID,long mlngmoduletype, long lngVtypeValue)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<VoucherTypes> ooAccLedger = new List<VoucherTypes>();
            strSQL = "SELECT * FROM ACC_VOUCHER_TYPE ";
            if (lngVtypeValue == 0)
            {
                if (mlngmoduletype == (long)Utility.MODULE_TYPE.mtSALES)
                {
                    strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE IN ( 15, 16,12, 17,13,18) ";
                }
                if (mlngmoduletype == (long)Utility.MODULE_TYPE.mtPURCHASE)
                {
                    strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE IN (33, 32 ) ";
                }
                if (mlngmoduletype == (long)Utility.MODULE_TYPE.mtSTOCK)
                {
                    strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE IN (23, 25, 21, 22,50,40,24,26,27,29,51,55) ";
                }
                if (mlngmoduletype == (long)Utility.MODULE_TYPE.mtACCOUNT)
                {

                    strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE IN (1, 2, 3, 4,8) ";
                }
                if (mlngmoduletype == (long)Utility.MODULE_TYPE.mtLC)
                {
                    strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE IN (53, 56, 51, 52, 54, 55) ";
                }
                if (mlngmoduletype == (long)Utility.MODULE_TYPE.mtHW)
                {

                    strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE IN (41, 42, 43, 44) ";
                }
            }
            else
            {
                strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE =" + lngVtypeValue + " ";
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
                    VoucherTypes oLedg = new VoucherTypes();
                    oLedg.lngSlNo = Convert.ToInt64(dr["VOUCHER_TYPE_VALUE"].ToString());
                    oLedg.voucherName = dr["VOUCHER_TYPE_NAME"].ToString();
                    oLedg.StartingNo = Convert.ToInt64(dr["VOUCHER_TYPE_BEGINING_NUMBER"]);
                    oLedg.noWidth = Convert.ToInt64(dr["VOUCHER_TYPE_NUMERIC_WIDTH"].ToString());
                    if (dr["VOUCHER_TYPE_PREFIX"].ToString() != "")
                    {
                        oLedg.Prefix = dr["VOUCHER_TYPE_PREFIX"].ToString();
                    }
                    if (dr["VOUCHER_TYPE_SUFFIX"].ToString() != "")
                    {
                        oLedg.Suffix = dr["VOUCHER_TYPE_SUFFIX"].ToString();
                    }
                    oLedg.TotalVoucher = Convert.ToInt64(dr["VOUCHER_TYPE_TOTAL_VOUCHER"].ToString());
                    oLedg.PrintSaving = Convert.ToInt64(dr["VOUCHER_TYPE_PRINTAFTERSAVE"].ToString());
                    if (Convert.ToInt64(dr["VOUCHER_TYPE_NUMBERING_METHOD"].ToString()) == 0)
                    {
                        oLedg.voucherNoMethod = "Automatic";
                    }
                    else
                    {
                        oLedg.voucherNoMethod = "Manual";
                    }
                    oLedg.intBkash = Convert.ToInt32(dr["VOUCHER_TYPE_AUTO_MR_NO"].ToString());

                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
                return ooAccLedger;

            }

        }

        public string mUpdteVoucherTypes(string strDeComID, long lngMtype, long mIntVoucherType, long lngNumericWidth, string vstrPrefix,
                                            string strNoMethod, string vstrSuffix, bool blngCheckVoucher, string vstrVoucherName, long lngStartNo,
                                            string strPrintYesOrNo, int intEffectBkash)
        {
            long lngVchMethod, lngTotalVoucher = 0, lngPrintYesOrNo, lngLength = 0;
            string strPrefix, strNumber;
            SqlDataReader dr;
            if (strNoMethod == "Automatic")
            {
                lngVchMethod = 0;
            }
            else
            {
                lngVchMethod = 1;
            }
            if (strPrintYesOrNo == "Yes")
            {
                lngPrintYesOrNo = 2;
            }
            else if (strPrintYesOrNo == "Preview")
            {
                lngPrintYesOrNo = 1;
            }
            else
            {
                lngPrintYesOrNo = 0;
            }
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
                if (lngVchMethod == 0)
                {
                    strPrefix = gobjVoucherName.VoucherName.GetVoucherString(mIntVoucherType) + "____" + vstrPrefix;
                    strNumber = strPrefix + lngNumericWidth.ToString() + vstrSuffix;
                    lngLength = strPrefix.Length + 1;
                    if (lngMtype == (long)Utility.MODULE_TYPE.mtSTOCK)
                    {
                        if (mIntVoucherType == 55)
                        {
                            strSQL = "SELECT substring(INV_REF_NO ,10,30 ) AS SL ";
                            // strSQL = "SELECT count (INV_REF_NO ) AS SL ";
                            strSQL = strSQL + "FROM INV_MASTER ";
                            strSQL = strSQL + "WHERE INV_VOUCHER_TYPE = 23 ";

                            strSQL = strSQL + " AND INV_REF_NO IN (SELECT INV_REF_NO FROM INV_TRAN WHERE INV_INOUT_FLAG='I') ";
                            strSQL = strSQL + " AND INV_REF_NO LIKE 'TI%' ";

                            strSQL = strSQL + " ORDER by substring(INV_REF_NO,10,30 ) desc ";
                        }
                        else
                        {
                            strSQL = "SELECT substring(INV_REF_NO ,10,30 ) AS SL ";
                            // strSQL = "SELECT count (INV_REF_NO ) AS SL ";
                            strSQL = strSQL + "FROM INV_MASTER ";
                            strSQL = strSQL + "WHERE INV_VOUCHER_TYPE = " + mIntVoucherType + " ";
                            if (mIntVoucherType == 23)
                            {
                                strSQL = strSQL + " AND INV_REF_NO IN (SELECT INV_REF_NO FROM INV_TRAN WHERE INV_INOUT_FLAG='O') ";
                            }
                            strSQL = strSQL + " ORDER by substring(INV_REF_NO,10,30 ) desc ";
                            //strSQL = strSQL + "AND INV_REF_NO LIKE '" + strNumber.Replace("'", "''") + "'";
                            //strSQL = "SELECT  substring(COMP_REF_NO,10,30 ) AS SL FROM ACC_COMPANY_VOUCHER WHERE COMP_VOUCHER_TYPE =  " + mIntVoucherType + "ORDER by substring(COMP_REF_NO,10,30 ) desc ";
                        }
                    }
                    else if (lngMtype == (long)Utility.MODULE_TYPE.mtHW)
                    {
                        strSQL = "SELECT ISNULL(MAX(SUBSTRING(CUS_REF_NO," + lngLength + "," + lngNumericWidth + ")),0) AS SL ";
                        strSQL = strSQL + "FROM SMA_HW_CUS_RECEIVED_MAS ";
                        strSQL = strSQL + "WHERE COMP_VOUCHER_TYPE = " + mIntVoucherType + " ";
                        //strSQL = strSQL + "AND COMP_REF_NO LIKE '" + strNumber.Replace("'", "''") + "'";
                    }
                    else if (lngMtype == (long)Utility.MODULE_TYPE.mtACCOUNT)
                    {
                        if (Utility.gblngApproved)
                        {
                            //strSQL = "SELECT ISNULL(MAX(SUBSTRING(COMP_REF_NO," + lngLength + "," + lngNumericWidth + ")),0) AS SL ";
                            strSQL = "SELECT count (COMP_REF_NO ) AS SL ";
                            strSQL = strSQL + "FROM SMA_ACC_COMPANY_VOUCHER_APPR ";
                            strSQL = strSQL + "WHERE COMP_VOUCHER_TYPE = " + mIntVoucherType + " ";
                            //strSQL = strSQL + "AND COMP_REF_NO LIKE '" + strNumber.Replace("'", "''") + "'";
                        }
                        else
                        {
                            //strSQL = "SELECT ISNULL(MAX(SUBSTRING(COMP_REF_NO," + lngLength + "," + lngNumericWidth + ")),0) AS SL ";
                            //strSQL = "SELECT count (COMP_REF_NO ) AS SL ";
                            //strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER ";
                            //strSQL = strSQL + "WHERE COMP_VOUCHER_TYPE = " + mIntVoucherType + " ";
                            //strSQL = strSQL + "AND COMP_REF_NO LIKE '" + strNumber.Replace("'", "''") + "'";
                            strSQL = "SELECT  substring(COMP_REF_NO,10,30 ) AS SL FROM ACC_COMPANY_VOUCHER WHERE COMP_VOUCHER_TYPE =  " + mIntVoucherType + "ORDER by substring(COMP_REF_NO,10,30 ) desc ";
                        }
                    }
                    else
                    {
                        //strSQL = "SELECT ISNULL(MAX(SUBSTRING(COMP_REF_NO," + lngLength + "," + lngNumericWidth + ")),0) AS SL ";
                        //strSQL = "SELECT count (COMP_REF_NO ) AS SL ";
                        //strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER ";
                        //strSQL = strSQL + "WHERE COMP_VOUCHER_TYPE = " + mIntVoucherType + " ";
                        //strSQL = strSQL + "AND COMP_REF_NO LIKE '" + strNumber.Replace("'", "''") + "'";
                        strSQL = "SELECT  substring(COMP_REF_NO,10,30 ) AS SL FROM ACC_COMPANY_VOUCHER WHERE COMP_VOUCHER_TYPE =  " + mIntVoucherType + "ORDER by substring(COMP_REF_NO,10,30 ) desc ";
                    }
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        lngTotalVoucher = Convert.ToInt64(Utility.Val(dr["SL"].ToString()));
                    }
                    dr.Close();
                }

                strSQL = "UPDATE ACC_VOUCHER_TYPE SET ";
                strSQL = strSQL + "VOUCHER_TYPE_NAME = '" + vstrVoucherName.Replace("'", "''") + "', ";
                strSQL = strSQL + "VOUCHER_TYPE_NUMBERING_METHOD = " + lngVchMethod + ", ";
                strSQL = strSQL + "VOUCHER_TYPE_BEGINING_NUMBER =" + lngStartNo + ", ";
                strSQL = strSQL + "VOUCHER_TYPE_NUMERIC_WIDTH = " + lngNumericWidth + ", ";
                strSQL = strSQL + "VOUCHER_TYPE_PREFIX = '" + vstrPrefix + "', ";
                strSQL = strSQL + "VOUCHER_TYPE_SUFFIX = '" + vstrSuffix + "', ";
                strSQL = strSQL + "VOUCHER_TYPE_PRINTAFTERSAVE=  " + lngPrintYesOrNo + ",";
                strSQL = strSQL + "VOUCHER_TYPE_AUTO_MR_NO = " + intEffectBkash + " ";
                if (blngCheckVoucher == true && lngVchMethod == 0)
                {
                    strSQL = strSQL + ",VOUCHER_TYPE_TOTAL_VOUCHER = " + lngTotalVoucher + " ";
                }

                strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + mIntVoucherType + " ";
                //strSQL = strSQL + " and VOUCHER_TYPE_NAME = '" + Replace(uctxtTypeOfVoucher.Text, "'", "''") + "'";

                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Transaction.Commit();
            }

            return "1";
        }

        #endregion
        #region "GerConfig"
        public List<VoucherTypes> mGetConfig(string strDeComID,long vintVoucherType)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<VoucherTypes> oogrp = new List<VoucherTypes>();
            strSQL = "SELECT VOUCHER_TYPE_NAME,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_NUMBERING_METHOD,";
            strSQL = strSQL + "VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_TOTAL_VOUCHER,";
            strSQL = strSQL + "VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PRINTAFTERSAVE  ";
            strSQL = strSQL + ",VOUCHER_TYPE_AUTO_CHEQUE,VOUCHER_TYPE_AUTO_MR_NO ";
            strSQL = strSQL + ",VOUCHER_CHEQUE_BANK,VOUCHER_CHEQUE_BOOK ";
            strSQL = strSQL + ",VOUCHER_AUTO_MR_BANK,VOUCHER_AUTO_MR_BOOK ";
            strSQL = strSQL + "FROM ACC_VOUCHER_TYPE ";
            strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + vintVoucherType + " ";
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
                    VoucherTypes ogrp = new VoucherTypes();
                    ogrp.intVoucherNoMethod = Convert.ToInt32(drGetGroup["VOUCHER_TYPE_NUMBERING_METHOD"].ToString());
                    ogrp.PrintSaving = Convert.ToInt32(drGetGroup["VOUCHER_TYPE_PRINTAFTERSAVE"].ToString());
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }
        #endregion
        #region "OpentableQuo"
        public List<AccountsVoucher> mOpentableQuo(string strDeComID,int intVtype, string strFDate, string strTdate, string strRefNo)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<AccountsVoucher> ooAcms = new List<AccountsVoucher>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM ACC_QUOTATION_MASTER ";
            if (strFDate != "")
            {
                strSQL = strSQL + "WHERE QUOTE_DATE between ";
                strSQL = strSQL + Utility.cvtSQLDateString(strFDate) + " ";
                strSQL = strSQL + "AND ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strTdate) + " ";
            }
            if (strRefNo != "")
            {
                strSQL = strSQL + "WHERE QUOTE_REF_NO = '" + strRefNo + "' ";
            }
            strSQL = strSQL + " ORDER BY QUOTE_DATE ";

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
                    AccountsVoucher oBra = new AccountsVoucher();
                    oBra.strVoucherNo = dr["QUOTE_REF_NO"].ToString();
                    oBra.strTranDate = Convert.ToDateTime(dr["QUOTE_DATE"]).ToString("dd/MM/yyyy");
                    oBra.strLedgerName = dr["PARTY_NAME"].ToString();
                    oBra.dblAmount = Convert.ToDouble(dr["QUOTE_AMOUNT"].ToString());

                    ooAcms.Add(oBra);
                }
                return ooAcms;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        #endregion
        #region "DisplayQuotation Vouycher"
        public List<AccountsVoucher> DisplayQuotationVoucherList(string strDeComID,string vstrSalesSerial, long mlngVoucherAs)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<AccountsVoucher> ooAcms = new List<AccountsVoucher>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM ACC_QUOTATION_MASTER ";
            strSQL = strSQL + "WHERE QUOTE_REF_NO = '" + vstrSalesSerial + "' ";
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
                    AccountsVoucher oBra = new AccountsVoucher();
                    oBra.strVoucherNo = dr["QUOTE_REF_NO"].ToString();
                    oBra.strTranDate = Convert.ToDateTime(dr["QUOTE_DATE"]).ToString("dd/MM/yyyy");
                    oBra.strLedgerName = dr["PARTY_NAME"].ToString();

                    if (dr["ATTENTION"].ToString() != "")
                    {
                        oBra.strAttention = dr["ATTENTION"].ToString();
                    }

                    if (dr["DESIGNATION"].ToString() != "")
                    {
                        oBra.strDesignation = dr["DESIGNATION"].ToString();
                    }

                    if (dr["QUOTE_ADDRESS1"].ToString() != "")
                    {
                        oBra.strAddress = dr["QUOTE_ADDRESS1"].ToString();
                    }

                    if (dr["QUOTE_DELIVERY"].ToString() != "")
                    {
                        oBra.strDelivery = dr["QUOTE_DELIVERY"].ToString();
                    }
                    if (dr["QUOTE_TERM_OF_PAYMENTS"].ToString() != "")
                    {
                        oBra.strtermofPayment = dr["QUOTE_TERM_OF_PAYMENTS"].ToString();
                    }
                    if (dr["QUOTE_SUPPORT"].ToString() != "")
                    {
                        oBra.strSupport = dr["QUOTE_SUPPORT"].ToString();
                    }
                    //if (dr["COMP_VALIDITY_DATE"].ToString() != "")
                    //{
                    //    oBra.strValidityDate = dr["COMP_VALIDITY_DATE"].ToString();
                    //}
                    //if (dr["COMP_OTHERS"].ToString() != "")
                    //{
                    //    oBra.strOthers = dr["COMP_OTHERS"].ToString();
                    //}
                    //if (dr["COMP_VOUCHER_NARRATION"].ToString() != "")
                    //{
                    //    oBra.strNarration = dr["COMP_VOUCHER_NARRATION"].ToString();
                    //}
                    if (dr["QUOTE_AMOUNT"].ToString() != "")
                    {
                        oBra.dblAmount = Convert.ToDouble(dr["QUOTE_AMOUNT"].ToString());
                    }
                    ooAcms.Add(oBra);
                }
                return ooAcms;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<AccBillwise> DisplayQuotationVoucherTranList(string strDeComID,string vstrSalesSerial, long mlngVoucherAs)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<AccBillwise> ooAcms = new List<AccBillwise>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM ACC_QUOTATION_TRAN ";
            strSQL = strSQL + "WHERE QUOTE_REF_NO = '" + vstrSalesSerial + "' ";
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
                    AccBillwise oBra = new AccBillwise();

                    if (dr["STOCKITEM_NAME"].ToString() != "")
                    {
                        oBra.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                    }

                    if (dr["QUOTE_QUANTITY"].ToString() != "")
                    {
                        oBra.dblQnty = Utility.Val(dr["QUOTE_QUANTITY"].ToString());
                    }

                    if (dr["QUOTE_UOM"].ToString() != "")
                    {
                        oBra.strPer = dr["QUOTE_UOM"].ToString();
                    }

                    if (dr["QUOTE_RATE"].ToString() != "")
                    {
                        oBra.dblRate = Utility.Val(dr["QUOTE_RATE"].ToString());
                    }
                    if (dr["QUOTE_PER"].ToString() != "")
                    {
                        oBra.strPer = dr["QUOTE_PER"].ToString();
                    }
                    if (dr["QUOTE_AMOUNT"].ToString() != "")
                    {
                        oBra.dblAmount = Utility.Val(dr["QUOTE_AMOUNT"].ToString());
                    }


                    ooAcms.Add(oBra);
                }
                return ooAcms;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        #endregion
        #region "Security"
        public List<UserAccess> mFillUsername(string strDeComID)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<UserAccess> ooBranch = new List<UserAccess>();
            strSQL = "SELECT USER_LOGIN_NAME FROM USER_CONFIG ";
            strSQL = strSQL + "WHERE USER_STATUS='A' ";

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
                    UserAccess oBra = new UserAccess();
                    //oBra.BranchID = dr["BRANCH_ID"].ToString();
                    oBra.LogInName = dr["USER_LOGIN_NAME"].ToString();
                    ooBranch.Add(oBra);
                }
                return ooBranch;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }




        #endregion
        #region DashBoard

        public List<AccountsLedger> mGetVoucherAmont(string strDeComID, string strFdate, string strTDate, string strCurrentYear, string strBranchId)
        {
            string strSQL = null;
            double dblAmount = 0;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsLedger> ooAccLedger = new List<AccountsLedger>();

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                strSQL = "SELECT ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT-ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT),0) AS TOTAL_DEBIT ,COUNT(ACC_VOUCHER.COMP_REF_NO)  FROM ACC_VOUCHER,ACC_LEDGER WHERE ACC_LEDGER.LEDGER_NAME=ACC_VOUCHER.LEDGER_NAME  ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_GROUP=211";
                strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE between " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + " ";
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if  (dr.Read())
                {
                    dblAmount = Convert.ToDouble(dr["TOTAL_DEBIT"].ToString());
                }
                dr.Close();
                strSQL = "SELECT (CASE WHEN SUM(COMP_VOUCHER_NET_AMOUNT) > 0 THEN SUM(COMP_VOUCHER_NET_AMOUNT) ELSE 0 END) AS  CVoucherNetAmunt , COUNT(COMP_REF_NO) AS NoOfInvoice ";
                strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER ";
                //strSQL = strSQL + "WHERE (YEAR(COMP_VOUCHER_DATE) = '" + strCurrentYear + "' ) ";
                strSQL = strSQL + "WHERE COMP_VOUCHER_DATE between " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + " ";
                if (strBranchId != "")
                {
                    if (strBranchId != "All")
                    {
                        strSQL = strSQL + " AND BRANCH_ID ='" + strBranchId + "' ";
                    }
                }


                strSQL = strSQL + " AND COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    AccountsLedger oLedg = new AccountsLedger();
                    oLedg.dblVoucherTAmount =dblAmount ;
                    oLedg.dblNoVoucher = Convert.ToDouble(dr["NoOfInvoice"].ToString());
                    ooAccLedger.Add(oLedg);
                }
                return ooAccLedger;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }


        public List<AccountsLedger> mGetVoucherTodaySalesAmont(string strDeComID,string strFdate, string strBranchId)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<AccountsLedger> ooAccLedger = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT (CASE WHEN SUM(COMP_VOUCHER_NET_AMOUNT) > 0 THEN SUM(COMP_VOUCHER_NET_AMOUNT) ELSE 0 END) AS CVoucherNetAmunt , COUNT(COMP_REF_NO) AS NoOfInvoice ";
            strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER ";
            strSQL = strSQL + "WHERE(COMP_VOUCHER_DATE =(" + Utility.cvtSQLDateString(strFdate) + ") ) ";
            if (strBranchId != "")
            {
                if (strBranchId != "All")
                {
                    strSQL = strSQL + " AND BRANCH_ID ='" + strBranchId + "'  ";
                }
            }

            strSQL = strSQL + " AND COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";

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
                    AccountsLedger oLedg = new AccountsLedger();
                    oLedg.dblVoucherTAmountToday = Convert.ToDouble(dr["CVoucherNetAmunt"].ToString());
                    oLedg.dblNoVoucherToday = Convert.ToDouble(dr["NoOfInvoice"].ToString());
                    ooAccLedger.Add(oLedg);
                }
                return ooAccLedger;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }
        }

        public List<AccountsLedger> mGetVoucherDateRangeWiseSalesAmont(string strDeComID,string strFdate, string strTDate, string strBranchId)
        {
            string strSQL = null;
          
            SqlDataReader dr;
           
            List<AccountsLedger> ooAccLedger = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
         

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand();
                  double dblAmount = 0;
                cmd.Connection = gcnMain;
                strSQL = "SELECT ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT-ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT),0) AS TOTAL_DEBIT ,COUNT(ACC_VOUCHER.COMP_REF_NO)  FROM ACC_VOUCHER,ACC_LEDGER WHERE ACC_LEDGER.LEDGER_NAME=ACC_VOUCHER.LEDGER_NAME  ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_GROUP=211";
                strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE between " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + " ";
                if (strBranchId != "")
                {
                    if (strBranchId != "All")
                    {
                        strSQL = strSQL + " AND ACC_VOUCHER.BRANCH_ID ='" + strBranchId + "'  ";
                    }
                }
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblAmount = Convert.ToDouble(dr["TOTAL_DEBIT"].ToString());
                }
                dr.Close();
                strSQL = "SELECT (CASE WHEN isnull(SUM(COMP_VOUCHER_NET_AMOUNT),0) > 0 THEN isnull(SUM(COMP_VOUCHER_NET_AMOUNT),0) ELSE 0 END) AS  CVoucherNetAmunt ";
                strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER ";
                strSQL = strSQL + "WHERE(COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                if (strBranchId != "")
                {
                    if (strBranchId != "All")
                    {
                        strSQL = strSQL + " AND BRANCH_ID ='" + strBranchId + "'  ";
                    }
                }

                strSQL = strSQL + " AND COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AccountsLedger oLedg = new AccountsLedger();
                    //oLedg.dblVoucherTAmountToday = dblAmount
                    oLedg.dblVoucherTAmountToday = Convert.ToDouble(dr["CVoucherNetAmunt"].ToString());

                    ooAccLedger.Add(oLedg);
                }
                return ooAccLedger;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<AccountsLedger> mGetVoucherDateRangeWiseRecevedAmont(string strDeComID,string strFdate, string strTDate, string strBranchId)
        {
            string strSQL = null;
            SqlDataReader dr;
            double dblHLPFTotal = 0;
            List<AccountsLedger> ooAccLedger = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
           
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                strSQL = "SELECT isnull(sum(c.COMP_VOUCHER_NET_AMOUNT),0) as total ";
                strSQL = strSQL + " from ACC_COMPANY_VOUCHER c where";
                strSQL = strSQL + "  c.COMP_VOUCHER_TYPE = 3 AND  c.AUTOJV=1 ";
                strSQL = strSQL + "  and c.SP_JOURNAL =0 ";
                strSQL = strSQL + "  and c.COMP_VOUCHER_DATE between " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "  and  " + Utility.cvtSQLDateString(strTDate) + " ";
                if (strBranchId != "")
                {
                    if (strBranchId != "All")
                    {
                        strSQL = strSQL + " AND c.BRANCH_ID ='" + strBranchId + "'  ";
                    }
                }
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblHLPFTotal = Convert.ToDouble(dr["total"]);
                }
                dr.Close();
                strSQL = "SELECT (CASE WHEN SUM(COMP_VOUCHER_NET_AMOUNT) > 0 THEN SUM(COMP_VOUCHER_NET_AMOUNT) ELSE 0 END) AS  CVoucherNetAmunt ";
                strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER ";
                strSQL = strSQL + "WHERE(COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                if (strBranchId != "")
                {
                    if (strBranchId != "All")
                    {
                        strSQL = strSQL + " AND BRANCH_ID ='" + strBranchId + "'  ";
                    }
                }

                strSQL = strSQL + " AND COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " ";

                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    AccountsLedger oLedg = new AccountsLedger();
                    oLedg.dblVoucherRecevedTAmount = Convert.ToDouble(dr["CVoucherNetAmunt"].ToString()) - dblHLPFTotal;

                    ooAccLedger.Add(oLedg);
                }
                return ooAccLedger;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }
        }
        #endregion
        #region Ledger list
        public List<AccountsLedger> mDisplayLedgerConfig(string strDeComID,string masterKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> oogrp = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT CONFIGL_KEY, AMOUNT_FORM, AMOUNT_TO, EFFECTIVE_DATE, CONFIG_PERCENTAGES ";
            strSQL = strSQL + "FROM ACC_EXPENSE_CONFIG_TRAN ";
            strSQL = strSQL + "where CONFIGL_KEY='" + masterKey + "' ";
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
                    AccountsLedger ogrp = new AccountsLedger();


                    ogrp.dblFromAmt = Utility.Val(drGetGroup["AMOUNT_FORM"].ToString());
                    ogrp.dblToAmt = Utility.Val(drGetGroup["AMOUNT_TO"].ToString());
                    ogrp.dblConfigPer = Utility.Val(drGetGroup["CONFIG_PERCENTAGES"].ToString());


                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<AccountsLedger> mDisplayLedgerPercen(string strDeComID,string strLedgerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> oogrp = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
           
           strSQL ="SELECT t.AMOUNT_FORM,t.AMOUNT_TO,t.CONFIG_PERCENTAGES,m.LEDGER_NAME from ACC_EXPENSE_CONFIG_MASTER m,ACC_EXPENSE_CONFIG_TRAN t where m.CONFIGL_KEY=t.CONFIGL_KEY ";
           strSQL = strSQL + " AND m.LEDGER_NAME ='" + strLedgerName + "' ";
           strSQL = strSQL + " order by m.EFFECTIVE_DATE desc ";

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                if (drGetGroup.Read())
                {
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.dblFromAmt = Convert.ToDouble(drGetGroup["AMOUNT_FORM"]);
                    ogrp.dblToAmt = Convert.ToDouble(drGetGroup["AMOUNT_TO"]);
                    ogrp.dblConfigPer = Convert.ToDouble(drGetGroup["CONFIG_PERCENTAGES"]);

                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public List<AccountsLedger> mDisplayLedgerlistt(string strDeComID,int mintLedgerGroup)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> oogrp = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT  CONFIGL_KEY, LEDGER_NAME, EFFECTIVE_DATE, VOUCHER_TYPE FROM ACC_EXPENSE_CONFIG_MASTER ";
            if (mintLedgerGroup!=203)
            {
                strSQL = strSQL + " WHERE PER_STATUS =0 ";
            }
            strSQL = strSQL + "ORDER BY POSITION,LEDGER_NAME ASC ";

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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strConfigkey = drGetGroup["CONFIGL_KEY"].ToString();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strEfectDate = Convert.ToDateTime(drGetGroup["EFFECTIVE_DATE"]).ToString("dd/MM/yyyy");

                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public List<AccountsLedger> mDisplayDraftLedger(string strDeComID, string strMonthID, string strLedgerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> oogrp = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            //strSQL = "SELECT MPO_COMM_MAN_PARENT_CHILD.HEAD_NAME from MPO_COMM_MAN_PARENT,MPO_COMM_MAN_PARENT_CHILD ";
            //strSQL=strSQL +" WHERE MPO_COMM_MAN_PARENT.COMM_MANUAL_KEY=MPO_COMM_MAN_PARENT_CHILD.COMM_MANUAL_KEY AND MPO_COMM_MAN_PARENT_CHILD.AMOUNT > 0 ";
            //strSQL = strSQL + " AND MPO_COMM_MAN_PARENT_CHILD.LEDGER_NAME ='" + strLedgerName.Replace("'", "''") + "' ";
            //strSQL = strSQL + " AND MPO_COMM_MAN_PARENT.MONTH_ID ='" + strMonthID + "' ";
            //strSQL = strSQL + "ORDER BY MPO_COMM_MAN_PARENT_CHILD.HEAD_NAME ASC ";

            strSQL = "SELECT distinct HEAD_NAME  from MPO_COMM_MAN_PARENT,MPO_COMM_MAN_PARENT_CHILD  WHERE MPO_COMM_MAN_PARENT.COMM_MANUAL_KEY =MPO_COMM_MAN_PARENT_CHILD.COMM_MANUAL_KEY  ";
            strSQL = strSQL + "AND MPO_COMM_MAN_PARENT_CHILD.AMOUNT <> 0 ";
            strSQL = strSQL + " AND MPO_COMM_MAN_PARENT_CHILD.LEDGER_NAME ='" + strLedgerName.Replace("'", "''") + "' ";
            strSQL = strSQL + " AND MPO_COMM_MAN_PARENT.MONTH_ID ='" + strMonthID + "' ";
            strSQL = strSQL + "union all ";
            strSQL = strSQL + "SELECT distinct COMMISSION_LEDGER  FROM MPO_COMMISSION_PERCENTAGE WHERE LEDGER_NAME ='" + strLedgerName.Replace("'", "''") + "'  and PERCENTAGES >0 ";
            strSQL = strSQL + "union all ";
            strSQL = strSQL + "SELECT 'Salary By Voucher' COMMISSION_LEDGER ";


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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strLedgerName = drGetGroup["HEAD_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertExpenseLedger(string strDeComID,string strConfiglKey, string strledgerName, string strEffectiveDate, long vlngVoucherType, string strGrid)
        {

            string strSQL;
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

                    strSQL = "INSERT INTO ACC_EXPENSE_CONFIG_MASTER";
                    strSQL = strSQL + "(CONFIGL_KEY, LEDGER_NAME, EFFECTIVE_DATE, VOUCHER_TYPE) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + strConfiglKey.Replace("'", "''") + "'";
                    strSQL = strSQL + ",'" + strledgerName.Replace("'", "''") + "'";
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(strEffectiveDate) + "";
                    strSQL = strSQL + "," + 5555 + "";
                    //strSQL = strSQL + " " + vlngVoucherType + "," + Utility.cvtSQLDateString(strEffectiveDate) + ",";

                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();




                    if (strGrid != "")
                    {

                        string[] words = strGrid.Split('~');
                        foreach (string costcenter in words)
                        {
                            string[] ooCost = costcenter.Split(',');
                            if (ooCost[0] != "")
                            {

                                strSQL = "INSERT INTO  ACC_EXPENSE_CONFIG_TRAN";
                                strSQL = strSQL + "(CONFIGL_KEY, AMOUNT_FORM, AMOUNT_TO, EFFECTIVE_DATE, CONFIG_PERCENTAGES";
                                strSQL = strSQL + ")VALUES( ";
                                strSQL = strSQL + "'" + strConfiglKey.Replace("'", "''") + "'";
                                strSQL = strSQL + "," + Utility.Val(ooCost[0]) + "";
                                strSQL = strSQL + "," + Utility.Val(ooCost[1]) + "";
                                strSQL = strSQL + "," + Utility.cvtSQLDateString(strEffectiveDate) + "";
                                strSQL = strSQL + ",'" + ooCost[2] + "'";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }

                        }
                    }

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string DeleteLedgerConfig(string strDeComID,string mstrConfiglkey)
        {


            string strresponse, strSQL;

            //long lngDefaultLedger = 0;
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
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;


                    strSQL = "DELETE FROM ACC_EXPENSE_CONFIG_TRAN ";
                    strSQL = strSQL + "WHERE CONFIGL_KEY = '" + mstrConfiglkey + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_EXPENSE_CONFIG_MASTER ";
                    strSQL = strSQL + "WHERE CONFIGL_KEY = '" + mstrConfiglkey + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    strresponse = "Delete Successfully...";
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
        #region "MonthTarget"
        public List<AccountdGroup> mDisplayMonthTarget(string strDeComID,string strFromDate, string strToDate,string strPartyname)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountdGroup> oogrp = new List<AccountdGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT MONTH_ID TARGET_ACHIEVE_MONTH_ID,COLL_TARGET_COLL_AMT TARGET_ACHIEVE_AMOUNT,COLL_TARGET_FROM_DATE,COLL_TARGET_TO_DATE ";
            strSQL = strSQL + "FROM SALES_COLL_TARGET_TRAN ";
            strSQL = strSQL + "WHERE(COLL_TARGET_FROM_DATE >= " + Utility.cvtSQLDateString(strFromDate) + ") AND (COLL_TARGET_TO_DATE <= " + Utility.cvtSQLDateString(strToDate) + ")";
            strSQL = strSQL + " AND LEDGER_NAME='" + strPartyname + "' ";
            strSQL = strSQL + " ORDER by COLL_TARGET_DETAIL_SERIAL ";
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
                    AccountdGroup ogrp = new AccountdGroup();
                    ogrp.strMonthID = drGetGroup["TARGET_ACHIEVE_MONTH_ID"].ToString();
                    ogrp.dblAmount = Convert.ToDouble(drGetGroup["TARGET_ACHIEVE_AMOUNT"].ToString());
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        #endregion
        #region "MonthSetup"
        public string mSaveMonthConfig(string strDeComID,string strMonthID, string vstrfromDate, string vstrtodate, string vstrStatus)
        {

            int intStatus = 0;
            string strresponse = "";
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
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    if (vstrStatus == "Inactive")
                    {
                        intStatus = 1;
                    }
                    else
                    {
                        intStatus = 0;
                    }

                    strSQL = "INSERT INTO ACC_MONTH_SETUP(";
                    strSQL = strSQL + "MONTH_ID,FROM_DATE,TO_DATE,MONTH_STATUS";
                    strSQL = strSQL + ")";
                    strSQL = strSQL + " VALUES(";
                    strSQL = strSQL + "'" + strMonthID + "'";
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(vstrfromDate) + "";
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(vstrtodate) + "";
                    strSQL = strSQL + "," + intStatus + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();



                    cmdInsert.Transaction.Commit();
                    strresponse = "1";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return "Sorry! Month ID is already Exists..";
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        public string mUpdateMonthConfig(string strDeComID,string stroldMonthID, string strMonthID, string vstrfromDate, string vstrtodate, string vstrStatus)
        {

            int intStatus = 0;
            string strresponse = "";
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
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    if (vstrStatus == "Inactive")
                    {
                        intStatus = 1;
                    }
                    else
                    {
                        intStatus = 0;
                    }
                    strSQL = "UPDATE ACC_MONTH_SETUP set  ";
                    strSQL = strSQL + "MONTH_ID= '" + strMonthID + "',";
                    strSQL = strSQL + "FROM_DATE= " + Utility.cvtSQLDateString(vstrfromDate) + ",";
                    strSQL = strSQL + "TO_DATE= " + Utility.cvtSQLDateString(vstrtodate) + ",";
                    strSQL = strSQL + "MONTH_STATUS= " + intStatus + " ";
                    strSQL = strSQL + "WHERE MONTH_ID='" + stroldMonthID + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();



                    cmdInsert.Transaction.Commit();
                    strresponse = "1";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return "Sorry! Month ID is already Exists..";
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        public List<AccountdGroup> mDisplayMonthsetupList(string strDeComID,string strMonthId)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountdGroup> oogrp = new List<AccountdGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "select MONTH_ID,FROM_DATE,TO_DATE,MONTH_STATUS from ACC_MONTH_SETUP  ";
                if (strMonthId != "")
                {
                    strSQL = strSQL + " WHERE  MONTH_STATUS=0 ";
                }
                strSQL = strSQL + "ORDER BY MONTH_ID ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                    ogrp.strMonthID = drGetGroup["MONTH_ID"].ToString();
                    ogrp.strFromdate = Convert.ToDateTime(drGetGroup["FROM_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.strTodate = Convert.ToDateTime(drGetGroup["TO_DATE"]).ToString("dd-MM-yyyy");
                    if (Convert.ToInt32(drGetGroup["MONTH_STATUS"]) == 1)
                    {
                        ogrp.strStstus = "Inactive";
                    }
                    else
                    {
                        ogrp.strStstus = "Active";
                    }

                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<AccountdGroup> mGetDateFromMonthID(string strDeComID, string strMonthId)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountdGroup> oogrp = new List<AccountdGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "select FROM_DATE,TO_DATE,MONTH_STATUS from ACC_MONTH_SETUP  ";
                if (strMonthId != "")
                {
                    strSQL = strSQL + " WHERE  MONTH_ID='" + strMonthId + "' ";
                }
                strSQL = strSQL + "ORDER BY MONTH_ID ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                  
                    ogrp.strFromdate = Convert.ToDateTime(drGetGroup["FROM_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.strTodate = Convert.ToDateTime(drGetGroup["TO_DATE"]).ToString("dd-MM-yyyy");

                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mDeleteMonthList(string strDeComID,string strMonthID)
        {
            string strSQL, strReponse = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmdInsert = new SqlCommand();
                SqlDataReader dr;
                SqlTransaction myTrans;

                try
                {
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    strSQL = "select MONTH_ID  from ACC_MONTH_SETUP  ";
                    strSQL = strSQL + "WHERE MONTH_ID='" + strMonthID + "' ";
                    strSQL = strSQL + "AND MONTH_STATUS=0";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        strReponse = "Active Month Cannot be Delete";
                        return strReponse;
                    }
                    dr.Close();

                    strSQL = "DELETE from ACC_MONTH_SETUP  ";
                    strSQL = strSQL + "WHERE MONTH_ID='" + strMonthID + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    return "1";

                    dr.Close();
                    gcnMain.Dispose();
                }
                catch (Exception EX)
                {
                    return "Target found for this month,So you Cannot Delete";
                }
                finally
                {

                    gcnMain.Dispose();
                }


            }
        }

        #endregion
        #region "User Form Config"

        public string mSaveFormConfig(string strDeComID,string strformKey, string strNormalName, int intModuletype, int intModeType, int intStatus)
        {

         
            string strresponse = "";
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
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;


                    strSQL = "INSERT INTO USER_FORM_CONFIG(";
                    strSQL = strSQL + "FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE,FORM_STATUS";
                    strSQL = strSQL + ")";
                    strSQL = strSQL + " VALUES(";
                    strSQL = strSQL + "'" + strformKey + "'";
                    strSQL = strSQL + ",'" + strNormalName + "'";
                    strSQL = strSQL + "," + intModuletype + " ";
                    strSQL = strSQL + "," + intModeType + "";
                    strSQL = strSQL + "," + intStatus + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();



                    cmdInsert.Transaction.Commit();
                    strresponse = "1";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return "Cannot Insert Duplicate Name";
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        public string mUpdateFormConfig(string strDeComID,long lngslNo,string strformKey, string strNormalName, int intModuletype, int intModeType,int intStatus)
        {

         
            string strresponse = "";
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
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "UPDATE USER_FORM_CONFIG set  ";
                    strSQL = strSQL + "FORM_KEY= '" + strformKey + "',";
                    strSQL = strSQL + "FORM_NAME= '" + strNormalName + "',";
                    strSQL = strSQL + "MODULE_TYPE= " + intModuletype + ",";
                    strSQL = strSQL + "MODE_TYPE= " + intModeType + ",";
                    strSQL = strSQL + "FORM_STATUS= " + intStatus + " ";
                    strSQL = strSQL + "WHERE SL_NO=" + lngslNo + " ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();



                    cmdInsert.Transaction.Commit();
                    strresponse = "1";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return "Cannot Insert Duplicate Name";
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        public List<AccountdGroup> mDisplayFormList(string strDeComID,int intModule)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountdGroup> oogrp = new List<AccountdGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "select SL_NO,FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE,FORM_STATUS  from USER_FORM_CONFIG  ";
                if (intModule >0 )
                {
                    strSQL = strSQL + "WHERE MODULE_TYPE= " + intModule + " ";
                    strSQL = strSQL + "and FORM_STATUS= 0 ";
                }
                strSQL = strSQL + "ORDER BY SL_NO ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                    ogrp.lngSlNo =Convert.ToInt64(drGetGroup["SL_NO"]);
                    ogrp.strKey = drGetGroup["FORM_KEY"].ToString();
                    ogrp.strFormName  = drGetGroup["FORM_NAME"].ToString();
                    ogrp.intModule  = Convert.ToInt32(drGetGroup["MODULE_TYPE"]);
                    ogrp.intMode = Convert.ToInt32(drGetGroup["MODE_TYPE"]);
                    ogrp.intStatus = Convert.ToInt32(drGetGroup["FORM_STATUS"]);
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        

        #endregion
        #region "User Privileges"
        public List<UserAccess> mDisplayPrivilegesMain(string strDeComID,string strLogInKey,int intPriModule)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<UserAccess> oogrp = new List<UserAccess>();
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "SELECT PRI_TYPE FROM USER_PRIVILEGES_MAIN ";
                strSQL = strSQL + " WHERE USER_LOGIN_KEY ='" + strLogInKey + "' ";
                strSQL = strSQL + " AND PRI_MODULE =" + intPriModule + " ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    UserAccess ogrp = new UserAccess();
                    ogrp.intAccessLevel = Convert.ToInt32(drGetGroup["PRI_TYPE"]);
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<UserAccess> mDisplayPrivilegesChild(string strDeComID,string  strLogInKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<UserAccess> oogrp = new List<UserAccess>();
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL="SELECT PRI_ADD , PRI_EDIT , PRI_DELETE FROM USER_PRIVILEGES_CHILD ";
                strSQL = strSQL + " WHERE USER_LOGIN_KEY ='" + strLogInKey + "' ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    UserAccess ogrp = new UserAccess();
                    ogrp.intAdd = Convert.ToInt32(drGetGroup["PRI_ADD"]);
                    ogrp.intEdit = Convert.ToInt32(drGetGroup["PRI_EDIT"]);
                    ogrp.intDelete = Convert.ToInt32(drGetGroup["PRI_DELETE"]);
                    ogrp.intAccessLevel = ogrp.intAdd + ogrp.intEdit + ogrp.intDelete;
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertPrivileges(string strDeComID, string strUserName, int intPriModule, int lngAccess, string strstring, string strString1, string strSelection)
        {


            string strresponse = "", strBranchID = "";
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

                    string strLoginKey = strUserName + intPriModule;

                    SqlCommand cmdInsert = new SqlCommand();
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT USER_LOGIN_KEY FROM USER_PRIVILEGES_MAIN ";
                    strSQL = strSQL + "WHERE USER_LOGIN_KEY = '" + strLoginKey + "' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        dr.Close();
                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) ";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + strLoginKey + "',";
                        strSQL = strSQL + "'" + strUserName + "',";
                        strSQL = strSQL + intPriModule + ",";
                        strSQL = strSQL + lngAccess + "";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    else
                    {
                        dr.Close();
                        strSQL = "UPDATE USER_PRIVILEGES_MAIN SET PRI_TYPE = " + lngAccess + " ";
                        strSQL = strSQL + "WHERE USER_LOGIN_KEY = '" + strLoginKey + "' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    dr.Close();
                    string strLogInKey, StrLogINName;
                    int intAccessLevel, intAdd, intedit, indelete;

                    if (strstring != "")
                    {
                        string[] words = strstring.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                               
                                StrLogINName = oAssets[0];
                                strLogInKey = oAssets[1];
                                intAccessLevel = Convert.ToInt16(oAssets[2]);
                                intAdd = Convert.ToInt16(oAssets[3]);
                                intedit = Convert.ToInt16(oAssets[4]);
                                indelete = Convert.ToInt16(oAssets[5]);
                                if (strLogInKey == "admin23")
                                {
                                    string k = "";
                                }


                                strSQL = "SELECT USER_LOGIN_KEY FROM USER_PRIVILEGES_CHILD ";
                                strSQL = strSQL + "WHERE USER_LOGIN_KEY = '" + strLogInKey + "' ";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (!dr.HasRows)
                                {
                                    dr.Close();
                                    strSQL = "INSERT INTO USER_PRIVILEGES_CHILD(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_COMPONENT,PRI_ADD,PRI_EDIT,PRI_DELETE,MODULE_TYPE) ";
                                    strSQL = strSQL + "VALUES(";
                                    strSQL = strSQL + "'" + strLogInKey + "',";
                                    strSQL = strSQL + "'" + StrLogINName + "',";
                                    strSQL = strSQL + intAccessLevel + ",";
                                    strSQL = strSQL + intAdd + ",";
                                    strSQL = strSQL + intedit + ",";
                                    strSQL = strSQL + indelete + ",";
                                    strSQL = strSQL + intPriModule + "";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                else
                                {
                                    dr.Close();
                                    strSQL = "UPDATE USER_PRIVILEGES_CHILD SET ";
                                    strSQL = strSQL + "PRI_COMPONENT= " + intAccessLevel + ",";
                                    strSQL = strSQL + "PRI_ADD= " + intAdd + ",";
                                    strSQL = strSQL + "PRI_EDIT= " + intedit + ",";
                                    strSQL = strSQL + "PRI_DELETE= " + indelete + ",";
                                    strSQL = strSQL + "MODULE_TYPE= " + intPriModule + " ";
                                    strSQL = strSQL + "WHERE USER_LOGIN_KEY = '" + strLogInKey + "' ";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                        }
                        dr.Close();
                    }

                    if (strSelection == "B")
                    {
                        strSQL = "SELECT USER_LOGIN_KEY FROM USER_PRIVILEGES_BRANCH ";
                        strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Close();
                            strSQL = "DELETE FROM USER_PRIVILEGES_BRANCH ";
                            strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        dr.Close();
                        string[] words = strString1.Split('~');
                        foreach (string ooassets in words)
                        {
                            if (ooassets.ToString() != "")
                            {
                                strBranchID = Utility.gstrGetBranchID(strDeComID, ooassets.ToString());
                                StrLogINName = strUserName;
                                strLogInKey = strUserName + strBranchID;
                                strSQL = "INSERT INTO USER_PRIVILEGES_BRANCH(USER_LOGIN_KEY,USER_LOGIN_NAME,BRANCH_ID) ";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + strLogInKey + "',";
                                strSQL = strSQL + "'" + StrLogINName + "',";
                                strSQL = strSQL + "'" + strBranchID.Replace("'", "''") + "' ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }

                    else if (strSelection == "S")
                    {
                        strSQL = "SELECT USER_LOGIN_NAME FROM USER_PRIVILEGES_STOCKGROUP ";
                        strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Close();
                            strSQL = "DELETE FROM USER_PRIVILEGES_STOCKGROUP ";
                            strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        dr.Close();
                        string[] words = strString1.Split('~');
                        foreach (string ooassets in words)
                        {
                            if (ooassets.ToString() != "")
                            {
                                strBranchID = ooassets.ToString();
                                StrLogINName = strUserName;

                                strSQL = "INSERT INTO USER_PRIVILEGES_STOCKGROUP(USER_LOGIN_NAME,STOCKGROUP_NAME) ";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + StrLogINName + "',";
                                strSQL = strSQL + "'" + strBranchID.Replace("'", "''") + "' ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }
                    else if (strSelection == "L")
                    {
                        strSQL = "SELECT USER_LOGIN_NAME FROM USER_PRIVILEGES_LOCATION ";
                        strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Close();
                            strSQL = "DELETE FROM USER_PRIVILEGES_LOCATION ";
                            strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        dr.Close();
                        string[] words = strString1.Split('~');
                        foreach (string ooassets in words)
                        {
                            if (ooassets.ToString() != "")
                            {
                                strBranchID = ooassets.ToString();
                                StrLogINName = strUserName;
                                strSQL = "INSERT INTO USER_PRIVILEGES_LOCATION(USER_LOGIN_NAME,GODOWNS_NAME) ";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + StrLogINName + "',";
                                strSQL = strSQL + "'" + strBranchID.Replace("'", "''") + "' ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }
                    else if (strSelection == "M")
                    {

                        strSQL = "SELECT USER_LOGIN_NAME FROM USER_PRIVILEGES_COLOR ";
                        strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Close();
                            strSQL = "DELETE FROM USER_PRIVILEGES_COLOR ";
                            strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        dr.Close();
                        string[] words = strString1.Split('~');
                        foreach (string ooassets in words)
                        {
                            if (ooassets.ToString() != "")
                            {
                                strBranchID = ooassets.ToString();
                                StrLogINName = strUserName;
                                strSQL = "INSERT INTO USER_PRIVILEGES_COLOR(USER_LOGIN_NAME,LEDGER_GROUP_NAME) ";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + StrLogINName + "',";
                                strSQL = strSQL + "'" + strBranchID.Replace("'", "''") + "' ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }
                    else if (strSelection == "G")
                    {

                        strSQL = "SELECT USER_LOGIN_NAME FROM USER_PRIVILEGES_LEDGER ";
                        strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Close();
                            strSQL = "DELETE FROM USER_PRIVILEGES_LEDGER ";
                            strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        dr.Close();
                        string[] words = strString1.Split('~');
                        foreach (string ooassets in words)
                        {
                            if (ooassets.ToString() != "")
                            {
                                strBranchID = ooassets.ToString();
                                StrLogINName = strUserName;
                                strSQL = "INSERT INTO USER_PRIVILEGES_LEDGER(USER_LOGIN_NAME,LEDGER_NAME) ";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + StrLogINName + "',";
                                strSQL = strSQL + "'" + strBranchID.Replace("'","''") + "' ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }

                    dr.Close();

                    cmdInsert.Transaction.Commit();
                    strresponse = "1";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return "Cannot Insert Duplicate Name";
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }

        public string mInsertPrivilegesNew(string strDeComID, string strUserName, int intPriModule, int lngAccess, string strstring, int intmode)
        {


            string strresponse = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader dr;
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();

                    string strLoginKey = strUserName + intPriModule;

                    SqlCommand cmdInsert = new SqlCommand();

                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    if (intmode == 0)
                    {
                        strSQL = "SELECT USER_LOGIN_KEY FROM USER_PRIVILEGES_MAIN ";
                        strSQL = strSQL + "WHERE USER_LOGIN_KEY = '" + strLoginKey + "' ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (!dr.HasRows)
                        {
                            dr.Close();
                            strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) ";
                            strSQL = strSQL + "VALUES(";
                            strSQL = strSQL + "'" + strLoginKey + "',";
                            strSQL = strSQL + "'" + strUserName + "',";
                            strSQL = strSQL + intPriModule + ",";
                            strSQL = strSQL + lngAccess + "";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        else
                        {
                            dr.Close();
                            strSQL = "UPDATE USER_PRIVILEGES_MAIN SET PRI_TYPE = " + lngAccess + " ";
                            strSQL = strSQL + "WHERE USER_LOGIN_KEY = '" + strLoginKey + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        dr.Close();

                        strSQL = "SELECT USER_LOGIN_NAME FROM USER_PRIVILEGES_LEDGER ";
                        strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Close();
                            strSQL = "DELETE FROM USER_PRIVILEGES_LEDGER ";
                            strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + strUserName + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        dr.Close();
                    }

                    string StrLogINName;


                    if (strstring != "")
                    {

                        StrLogINName = strUserName;
                        strSQL = "INSERT INTO USER_PRIVILEGES_LEDGER(USER_LOGIN_NAME,LEDGER_NAME) ";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + StrLogINName + "',";
                        strSQL = strSQL + "'" + strstring.Replace("'", "''") + "' ";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    cmdInsert.Transaction.Commit();
                    strresponse = "1";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return "Cannot Insert Duplicate Name";
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        public List<BranchConfig> mFillBranchUserRight(string strDeComID,string strUser)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<BranchConfig> ooBranch = new List<BranchConfig>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT b.BRANCH_ID,b.BRANCH_NAME  from USER_PRIVILEGES_BRANCH u,ACC_BRANCH b where b.BRANCH_ID =u.BRANCH_ID ";
            strSQL = strSQL + " AND u.USER_LOGIN_NAME='" + strUser + "' ";
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
                    BranchConfig oBra = new BranchConfig();
                    oBra.BranchID = dr["BRANCH_ID"].ToString();
                    oBra.BranchName = dr["BRANCH_NAME"].ToString();
                    ooBranch.Add(oBra);
                }
                return ooBranch;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<BranchConfig> mFillBranchUserPrivileges(string strDeComID,string strUserName)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<BranchConfig> ooBranch = new List<BranchConfig>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT BRANCH_ID,BRANCH_NAME FROM ACC_BRANCH WHERE BRANCH_ACTIVE = 0 ";
            strSQL = strSQL + "and BRANCH_ID not in(select BRANCH_ID from USER_PRIVILEGES_BRANCH WHERE USER_LOGIN_NAME='" + strUserName +"') ";

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
                    BranchConfig oBra = new BranchConfig();
                    oBra.BranchID = dr["BRANCH_ID"].ToString();
                    oBra.BranchName = dr["BRANCH_NAME"].ToString();
                    ooBranch.Add(oBra);
                }
                return ooBranch;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public List<AccountdGroup> GetDsmRsm_level4_userPrivileges(string strDeComID, string strUserName)
        {
            SqlDataReader rdr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountdGroup> ooAccGrop = new List<AccountdGroup>();
            strSQL="SELECT GR_NAME FROM ACC_LEDGERGROUP ";
            strSQL=strSQL +" WHERE GR_GROUP  =202 ";
            strSQL = strSQL + " AND  GR_DEFAULT_GROUP  <> 1 and GR_LEVEL =4 and GR_NAME not in (select LEDGER_GROUP_NAME  from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + strUserName + "')";
            strSQL = strSQL + "ORDER BY GR_LEVEL,GR_SERIAL ";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                    if (rdr["GR_NAME"].ToString() != "")
                    {
                        ogrp.GroupName = rdr["GR_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.GroupName = "";
                    }
                  

                    ooAccGrop.Add(ogrp);
                }
                rdr.Close();
                return ooAccGrop;
            }

        }
        public List<AccountdGroup> GetDsmRsm_level4_userPrivilegesRight(string strDeComID,string strUserName)
        {
            SqlDataReader rdr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountdGroup> ooAccGrop = new List<AccountdGroup>();
            strSQL = strSQL + "SELECT LEDGER_GROUP_NAME  from USER_PRIVILEGES_COLOR ";
            strSQL = strSQL + " WHERE USER_LOGIN_NAME='" + strUserName + "' ";
            strSQL = strSQL + "ORDER BY LEDGER_GROUP_NAME ";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                    if (rdr["LEDGER_GROUP_NAME"].ToString() != "")
                    {
                        ogrp.GroupName = rdr["LEDGER_GROUP_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.GroupName = "";
                    }


                    ooAccGrop.Add(ogrp);
                }
                rdr.Close();
                return ooAccGrop;
            }

        }
        #endregion
        #region "Backupath"
        public List<BackupPath> mGetBackupPath(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<BackupPath> oogrp = new List<BackupPath>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT COMPANY_ID,COMPANY_NAME, BACKUP_TARGET,ISNULL(BACKUP_CLIENT,' ') AS CLIENT FROM ACC_COMPANY ";

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                if (drGetGroup.Read())
                {
                    BackupPath ogrp = new BackupPath();
                    ogrp.strPath1 = drGetGroup["BACKUP_TARGET"].ToString();
                    ogrp.strPath2 = drGetGroup["CLIENT"].ToString();
                    ogrp.strComID = drGetGroup["COMPANY_ID"].ToString();
                    ogrp.strComName = drGetGroup["COMPANY_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        #endregion
        #region "Report Heading"
        public List<AccVoucherHeader> mFilVoucherPrintingShow(string strDeComID,int intVoucherTypeValue)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccVoucherHeader> ooAccVoucherHeader = new List<AccVoucherHeader>();
            strSQL = "SELECT  VOUCHER_CONFIG_NO, VOUCHER_HEADER1, VOUCHER_HEADER2, VOUCHER_HEADER3, VOUCHER_HEADER4, VOUCHER_HEADER5, VOUCHER_TYPE_VALUE, PRINT_MINIMIZE ";
            strSQL = strSQL + "FROM ACC_VOUCHER_CONFIG ";
            strSQL = strSQL + "WHERE (VOUCHER_TYPE_VALUE = " + intVoucherTypeValue + ") ";

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
                    AccVoucherHeader oLedg = new AccVoucherHeader();
                    oLedg.strVoucherHeader1 = dr["VOUCHER_HEADER1"].ToString();
                    oLedg.strVoucherHeader2 = dr["VOUCHER_HEADER2"].ToString();
                    oLedg.strVoucherHeader3 = dr["VOUCHER_HEADER3"].ToString();
                    oLedg.strVoucherHeader4 = dr["VOUCHER_HEADER4"].ToString();
                    oLedg.strVoucherHeader5 = dr["VOUCHER_HEADER5"].ToString();
                    oLedg.dblMinimize = Convert.ToDouble(dr["PRINT_MINIMIZE"].ToString());
                    ooAccVoucherHeader.Add(oLedg);
                }
                return ooAccVoucherHeader;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }

        }
        public string mSaveVoucherPrinting(string strDeComID,string vstrVoucherHeader1, string vstrVoucherHeader2, string vstrVoucherHeader3, 
                                                string vstrVoucherHeader4, string vstrVoucherHeader5, int intVoucherTypeValue, 
                                                   int intVoucherMinimize)
        {

            string strSQL;
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

                    strSQL = "DELETE FROM ACC_VOUCHER_CONFIG ";
                    strSQL = strSQL + " WHERE VOUCHER_TYPE_VALUE = " + intVoucherTypeValue + " ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO ACC_VOUCHER_CONFIG ";
                    strSQL = strSQL + "(VOUCHER_HEADER1, VOUCHER_HEADER2, VOUCHER_HEADER3, VOUCHER_HEADER4, VOUCHER_HEADER5, VOUCHER_TYPE_VALUE, PRINT_MINIMIZE) ";
                    strSQL = strSQL + "VALUES ('" + vstrVoucherHeader1 + "', '" + vstrVoucherHeader2 + "', '" + vstrVoucherHeader3 + "', '" + vstrVoucherHeader4 + "', '" + vstrVoucherHeader5 + "', " + intVoucherTypeValue + "," + intVoucherMinimize + ") ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        #endregion
        #region "Change Password"
        public string mChangePasswod(string strDeComID, string strUserName, string strNewPassword)
        {

            string strSQL;
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


                    strSQL = "UPDATE USER_CONFIG SET USER_PASS='" + strNewPassword + "' ";
                    strSQL = strSQL + "WHERE USER_LOGIN_NAME='" + strUserName + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        #endregion
        #region "Budget"
        public string mSaveBudget(string strDeComID, string strKey, string strDG)
        {


            string strresponse,strKeyRef = "", strLedgerName = "", strBranchId = "", strBranchName = "", strFromDate = "", strTodate = "";
            double dblAmount = 0;
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
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                   

                    strSQL = "INSERT INTO ACC_BUDGET_MASTER(BUDGET_KEY)";
                    strSQL = strSQL + " VALUES('" + strKey + "')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (strDG != "")
                    {

                        string[] words = strDG.Split('~');
                        foreach (string strDGBudget in words)
                        {
                            string[] ooCost = strDGBudget.Split(',');
                            if (ooCost[0] != "")
                            {
                                strKeyRef = ooCost[0].ToString();
                                strLedgerName = ooCost[1].ToString();
                                strBranchId = ooCost[2].ToString();
                                strBranchName = ooCost[3].ToString();
                                strFromDate = ooCost[4].ToString();
                                strTodate = ooCost[5].ToString();
                                dblAmount = Utility.Val(ooCost[6].ToString());
                                strSQL = " INSERT INTO ACC_BUDGET_DETAIL(BUDGET_KEY,BUDGET_KEY_REF,LEDGER_NAME,BRANCH_ID,BRANCH_NAME, ";
                                strSQL = strSQL + "BUDGET_FROM_DATE,BUDGET_TO_DATE,BUDGET_AMOUNT) ";
                                strSQL = strSQL + "VALUES('" + strKey + "',";
                                strSQL = strSQL + "'" + strKeyRef + "',";
                                strSQL = strSQL + "'" + strLedgerName + "',";
                                strSQL = strSQL + "'" + strBranchId + "',";
                                strSQL = strSQL + "'" + strBranchName + "',";
                                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFromDate) + ",";
                                strSQL = strSQL + " " + Utility.cvtSQLDateString(strTodate) + ",";
                                strSQL = strSQL + " " + dblAmount + " ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }

                    cmdInsert.Transaction.Commit();
                    strresponse = "1";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return  ex.ToString() ;
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        public string mUpdateBudget(string strDeComID,string strOldKey, string strKey, string strDG)
        {


            string strresponse,strKeyRef = "", strLedgerName = "", strBranchId = "", strBranchName = "", strFromDate = "", strTodate = "";
            double dblAmount = 0;
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
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "DELETE FROM ACC_BUDGET_DETAIL where BUDGET_KEY ='" + strOldKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_BUDGET_MASTER where BUDGET_KEY ='" + strOldKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO ACC_BUDGET_MASTER(BUDGET_KEY)";
                    strSQL = strSQL + " VALUES('" + strKey + "')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (strDG != "")
                    {

                        string[] words = strDG.Split('~');
                        foreach (string strDGBudget in words)
                        {
                            string[] ooCost = strDGBudget.Split(',');
                            if (ooCost[0] != "")
                            {
                                strKeyRef = ooCost[0].ToString();
                                strLedgerName = ooCost[1].ToString();
                                strBranchId = ooCost[2].ToString();
                                strBranchName = ooCost[3].ToString();
                                strFromDate = ooCost[4].ToString();
                                strTodate = ooCost[5].ToString();
                                dblAmount = Utility.Val(ooCost[6].ToString());
                                strSQL = " INSERT INTO ACC_BUDGET_DETAIL(BUDGET_KEY,BUDGET_KEY_REF,LEDGER_NAME,BRANCH_ID,BRANCH_NAME, ";
                                strSQL = strSQL + "BUDGET_FROM_DATE,BUDGET_TO_DATE,BUDGET_AMOUNT) ";
                                strSQL = strSQL + "VALUES('" + strKey + "',";
                                strSQL = strSQL + "'" + strKeyRef + "',";
                                strSQL = strSQL + "'" + strLedgerName + "',";
                                strSQL = strSQL + "'" + strBranchId + "',";
                                strSQL = strSQL + "'" + strBranchName + "',";
                                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFromDate) + ",";
                                strSQL = strSQL + " " + Utility.cvtSQLDateString(strTodate) + ",";
                                strSQL = strSQL + " " + dblAmount + " ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }



                    cmdInsert.Transaction.Commit();
                    strresponse = "1";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return ex.ToString();
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        public List<AccountdGroup> mLoadBudgetList(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountdGroup> oogrp = new List<AccountdGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "select BUDGET_KEY from ACC_BUDGET_MASTER  ";
                strSQL = strSQL + "ORDER BY BUDGET_KEY ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                    ogrp.GroupName = drGetGroup["BUDGET_KEY"].ToString();
                    
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<AccountdGroup> mDisplayBudgetList(string strDeComID, string vstrBudget)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountdGroup> oogrp = new List<AccountdGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "SELECT * FROM ACC_BUDGET_DETAIL  ";
                strSQL = strSQL + "WHERE BUDGET_KEY = '" + vstrBudget.Replace("'", "''") + "' ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                    ogrp.strDefaultGroup = drGetGroup["BUDGET_KEY"].ToString();
                    ogrp.GroupName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMonthID  = drGetGroup["BRANCH_ID"].ToString();

                    ogrp.strFromdate = Convert.ToDateTime(drGetGroup["BUDGET_FROM_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.strTodate = Convert.ToDateTime(drGetGroup["BUDGET_TO_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.dblAmount = Convert.ToDouble(drGetGroup["BUDGET_AMOUNT"].ToString());
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mDeletBudgetList(string strDeComID, string strOldKey)
        {
            string strSQL, strReponse = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmdInsert = new SqlCommand();
                SqlDataReader dr;
                SqlTransaction myTrans;

                try
                {
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    strSQL = "DELETE FROM ACC_BUDGET_DETAIL where BUDGET_KEY ='" + strOldKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_BUDGET_MASTER where BUDGET_KEY ='" + strOldKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    return "1";

                    dr.Close();
                    gcnMain.Dispose();
                }
                catch (Exception EX)
                {
                    return "Target found for this month,So you Cannot Delete";
                }
                finally
                {

                    gcnMain.Dispose();
                }


            }
        }
        #endregion
        #region "GetChequerefnoNew"
        public List<AccountsVoucher> mGetChequeRefNo(string strDeComID, int mintVType, string mdteVFromDate, string mdteVToDate, int intSP)
        {
            string strSQL = null;
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountsVoucher> ooAccLedger = new List<AccountsVoucher>();
            SqlCommand cmdInsert = new SqlCommand();

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                cmdInsert.Connection = gcnMain;
                strSQL = "select  ACC_VOUCHER.COMP_REF_NO from ACC_VOUCHER,ACC_COMPANY_VOUCHER  ";
                strSQL = strSQL + "where ACC_COMPANY_VOUCHER.COMP_REF_NO= ACC_VOUCHER.COMP_REF_NO and ACC_VOUCHER.VOUCHER_CHEQUE_NUMBER is  not null ";
                strSQL = strSQL + " and ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = " + mintVType + " ";
                strSQL = strSQL + " AND ACC_COMPANY_VOUCHER.SP_JOURNAL = " + intSP + " ";
                if (mdteVFromDate != "")
                {
                    strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE BETWEEN ";
                    strSQL = strSQL + Utility.cvtSQLDateString(mdteVFromDate) + " ";
                    strSQL = strSQL + "AND ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(mdteVToDate) + " ";
                }
                strSQL = strSQL + "ORDER by ACC_COMPANY_VOUCHER.COMP_REF_NO ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AccountsVoucher oLedg = new AccountsVoucher();
                    oLedg.strVoucherNo = dr["COMP_REF_NO"].ToString();
                    oLedg.strOrderNo = Utility.Mid(dr["COMP_REF_NO"].ToString(), 6, dr["COMP_REF_NO"].ToString().Length - 6);
                    ooAccLedger.Add(oLedg);
                }
                return ooAccLedger;
                dr.Close();
                gcnMain.Close();
                gcnMain.Dispose();
            }
        }

        #endregion
        #region "AddDoctorReceiptVc"
        public string SaveReceiptVoucherCustomer(string strDeComID, string vstrDrcr, string vstrRefNumber, long vlngVoucherType, string vdteDate, string vstrMonthID, string vdteDueDate, string vstrLedgerName,
                                               string vstrReverseLedgerName, int intvoucherPosition, double vdblNetAmount, string strChecqNo, string strChekdate, string strDawnon,
                                               double vdblDebitAmount, double vdblCreditAmount, string vstrNarratirons, string vstrBranchID, string DgCostCenter, bool blngNumMethod, int intSP)
        {

            string strSQL = "", strBillWiseRef = "";
            short lnglType = 1;
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
                    string i = gInsertCompanyVoucherNew(strDeComID, vstrRefNumber, vlngVoucherType, vdteDate, vstrMonthID, vdteDueDate, vstrLedgerName, vdblNetAmount, vdblNetAmount,
                                                    0, 0, 0, vstrNarratirons, vstrBranchID, 0, "",
                                                    "", "", "", "", "", "",intSP);
                    cmdInsert.CommandText = i;
                    cmdInsert.ExecuteNonQuery();

                    strBillWiseRef = vstrRefNumber + intvoucherPosition.ToString("0000");
                    strSQL = "INSERT INTO ACC_VOUCHER";
                    strSQL = strSQL + "(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,COMP_VOUCHER_TYPE,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE,COMP_VOUCHER_POSITION,LEDGER_NAME,";
                    if (strChecqNo != "")
                    {
                        strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER,";
                    }
                    if (strChekdate != "")
                    {
                        strSQL = strSQL + "VOUCHER_CHEQUE_DATE,";
                    }
                    if (strDawnon != "")
                    {
                        strSQL = strSQL + "VOUCHER_CHEQUE_DRAWN_ON,";
                    }
                    strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                    strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,VOUCHER_CASHFLOW ";
                    strSQL = strSQL + ") VALUES(";
                    strSQL = strSQL + "'" + vstrBranchID + "',";
                    strSQL = strSQL + "'" + strBillWiseRef + "','" + vstrRefNumber + "',";
                    strSQL = strSQL + " " + vlngVoucherType + "," + Utility.cvtSQLDateString(vdteDate) + ",";
                    strSQL = strSQL + " " + intvoucherPosition + ",'" + vstrLedgerName + "',";

                    if (strChecqNo != "")
                    {
                        strSQL = strSQL + "'" + strChecqNo + "',";
                    }
                    if (strChekdate != "")
                    {
                        strSQL = strSQL + " " + Utility.cvtSQLDateString(strChekdate) + ",";
                    }
                    if (strDawnon != "")
                    {
                        strSQL = strSQL + "'" + strDawnon + "',";
                    }
                    strSQL = strSQL + " " + vdblDebitAmount + "," + 0 + ",";
                    strSQL = strSQL + "'Cr' ";
                    strSQL = strSQL + ",'" + vstrReverseLedgerName + "'," + 1 + " ";
                    strSQL = strSQL + ")";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    intvoucherPosition += 1;
                    strBillWiseRef = vstrRefNumber + intvoucherPosition.ToString("0000");
                    strSQL = "INSERT INTO ACC_VOUCHER";
                    strSQL = strSQL + "(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,COMP_VOUCHER_TYPE,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE,COMP_VOUCHER_POSITION,LEDGER_NAME,";
                    if (strChecqNo != "")
                    {
                        strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER,";
                    }
                    if (strChekdate != "")
                    {
                        strSQL = strSQL + "VOUCHER_CHEQUE_DATE,";
                    }
                    if (strDawnon != "")
                    {
                        strSQL = strSQL + "VOUCHER_CHEQUE_DRAWN_ON,";
                    }
                    strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                    strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,VOUCHER_CASHFLOW ";
                    strSQL = strSQL + ") VALUES(";
                    strSQL = strSQL + "'" + vstrBranchID + "',";
                    strSQL = strSQL + "'" + strBillWiseRef + "','" + vstrRefNumber + "',";
                    strSQL = strSQL + " " + vlngVoucherType + "," + Utility.cvtSQLDateString(vdteDate) + ",";
                    strSQL = strSQL + " " + intvoucherPosition + ",'" + vstrReverseLedgerName + "',";

                    if (strChecqNo != "")
                    {
                        strSQL = strSQL + "'" + strChecqNo + "',";
                    }
                    if (strChekdate != "")
                    {
                        strSQL = strSQL + " " + Utility.cvtSQLDateString(strChekdate) + ",";
                    }
                    if (strDawnon != "")
                    {
                        strSQL = strSQL + "'" + strDawnon + "',";
                    }
                    strSQL = strSQL + " " + 0 + "," + vdblCreditAmount + ",";
                    strSQL = strSQL + "'Dr' ";
                    strSQL = strSQL + ",'" + vstrLedgerName + "'," + 0 + " ";
                    strSQL = strSQL + ")";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    intvoucherPosition += 1;

                    if (DgCostCenter != "")
                    {
                        string[] words = DgCostCenter.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                strSQL = Voucher.mInsertVector(vstrRefNumber,"", "", vdteDate, oAssets[1].ToString(),
                                                             oAssets[0].ToString(), lnglType, lnglType, 1, vstrBranchID, Utility.Val(oAssets[2].ToString()), 0, "", vlngVoucherType);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lnglType += 1;
                            }
                        }
                    }

                    if (blngNumMethod)
                    {
                        strSQL = Voucher.gIncreaseVoucher((int)vlngVoucherType);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    cmdInsert.Transaction.Commit();
                    cmdInsert.Dispose();
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        public string UpdateReceiptVoucherCustomer(string strDeComID, string vstrDrcr, string vstrRefNumber, long vlngVoucherType, string vdteDate, string vstrMonthID, string vdteDueDate, string vstrLedgerName,
                                             string vstrReverseLedgerName, int intvoucherPosition, double vdblNetAmount, string strChecqNo, string strChekdate, string strDawnon,
                                             double vdblDebitAmount, double vdblCreditAmount, string vstrNarratirons, string vstrBranchID, string DgCostCenter, bool blngNumMethod,int intSP)
        {

            string strSQL = "", strBillWiseRef = "";
            short lnglType = 1;
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
                    string i = gInsertCompanyVoucherNew(strDeComID, vstrRefNumber, vlngVoucherType, vdteDate, vstrMonthID, vdteDueDate, vstrLedgerName, vdblNetAmount, vdblNetAmount,
                                                    0, 0, 0, vstrNarratirons, vstrBranchID, 0, "",
                                                    "", "", "", "", "", "", intSP);


                    strSQL = "UPDATE ACC_COMPANY_VOUCHER SET ";
                    strSQL = strSQL + "BRANCH_ID = '" + vstrBranchID + "', ";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE = " + vlngVoucherType + ",";
                    strSQL = strSQL + "COMP_VOUCHER_DATE = " + Utility.cvtSQLDateString(vdteDate) + ",";
                    strSQL = strSQL + "COMP_VOUCHER_MONTH_ID = '" + vstrMonthID + "',";
                    strSQL = strSQL + "LEDGER_NAME= '" + vstrLedgerName + "',";
                    strSQL = strSQL + "COMP_VOUCHER_AMOUNT = " + vdblNetAmount + ", ";
                    strSQL = strSQL + "COMP_VOUCHER_NET_AMOUNT = " + vdblNetAmount + ", ";
                    strSQL = strSQL + "COMP_VOUCHER_NARRATION = '" + vstrNarratirons + "',";
                    strSQL = strSQL + "UPDATE_DATE = " + Utility.cvtSQLDateString(DateTime.Now.ToString("dd/MM/yyyy"));
                    strSQL = strSQL + " WHERE COMP_REF_NO = '" + vstrRefNumber + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM ACC_VOUCHER WHERE COMP_REF_NO='" + vstrRefNumber + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM VECTOR_TRANSACTION WHERE COMP_REF_NO='" + vstrRefNumber + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strBillWiseRef = vstrRefNumber + intvoucherPosition.ToString("0000");
                    strSQL = "INSERT INTO ACC_VOUCHER";
                    strSQL = strSQL + "(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,COMP_VOUCHER_TYPE,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE,COMP_VOUCHER_POSITION,LEDGER_NAME,";
                    if (strChecqNo != "")
                    {
                        strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER,";
                    }
                    if (strChekdate != "")
                    {
                        strSQL = strSQL + "VOUCHER_CHEQUE_DATE,";
                    }
                    if (strDawnon != "")
                    {
                        strSQL = strSQL + "VOUCHER_CHEQUE_DRAWN_ON,";
                    }
                    strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                    strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,VOUCHER_CASHFLOW ";
                    strSQL = strSQL + ") VALUES(";
                    strSQL = strSQL + "'" + vstrBranchID + "',";
                    strSQL = strSQL + "'" + strBillWiseRef + "','" + vstrRefNumber + "',";
                    strSQL = strSQL + " " + vlngVoucherType + "," + Utility.cvtSQLDateString(vdteDate) + ",";
                    strSQL = strSQL + " " + intvoucherPosition + ",'" + vstrLedgerName + "',";

                    if (strChecqNo != "")
                    {
                        strSQL = strSQL + "'" + strChecqNo + "',";
                    }
                    if (strChekdate != "")
                    {
                        strSQL = strSQL + " " + Utility.cvtSQLDateString(strChekdate) + ",";
                    }
                    if (strDawnon != "")
                    {
                        strSQL = strSQL + "'" + strDawnon + "',";
                    }
                    strSQL = strSQL + " " + vdblDebitAmount + "," + 0 + ",";
                    strSQL = strSQL + "'Cr' ";
                    strSQL = strSQL + ",'" + vstrReverseLedgerName + "'," + 1 + " ";
                    strSQL = strSQL + ")";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    intvoucherPosition += 1;
                    strBillWiseRef = vstrRefNumber + intvoucherPosition.ToString("0000");
                    strSQL = "INSERT INTO ACC_VOUCHER";
                    strSQL = strSQL + "(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,COMP_VOUCHER_TYPE,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE,COMP_VOUCHER_POSITION,LEDGER_NAME,";
                    if (strChecqNo != "")
                    {
                        strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER,";
                    }
                    if (strChekdate != "")
                    {
                        strSQL = strSQL + "VOUCHER_CHEQUE_DATE,";
                    }
                    if (strDawnon != "")
                    {
                        strSQL = strSQL + "VOUCHER_CHEQUE_DRAWN_ON,";
                    }
                    strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                    strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER,VOUCHER_CASHFLOW ";
                    strSQL = strSQL + ") VALUES(";
                    strSQL = strSQL + "'" + vstrBranchID + "',";
                    strSQL = strSQL + "'" + strBillWiseRef + "','" + vstrRefNumber + "',";
                    strSQL = strSQL + " " + vlngVoucherType + "," + Utility.cvtSQLDateString(vdteDate) + ",";
                    strSQL = strSQL + " " + intvoucherPosition + ",'" + vstrReverseLedgerName + "',";

                    if (strChecqNo != "")
                    {
                        strSQL = strSQL + "'" + strChecqNo + "',";
                    }
                    if (strChekdate != "")
                    {
                        strSQL = strSQL + " " + Utility.cvtSQLDateString(strChekdate) + ",";
                    }
                    if (strDawnon != "")
                    {
                        strSQL = strSQL + "'" + strDawnon + "',";
                    }
                    strSQL = strSQL + " " + 0 + "," + vdblCreditAmount + ",";
                    strSQL = strSQL + "'Dr' ";
                    strSQL = strSQL + ",'" + vstrLedgerName + "'," + 0 + " ";
                    strSQL = strSQL + ")";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    intvoucherPosition += 1;

                    if (DgCostCenter != "")
                    {
                        string[] words = DgCostCenter.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                strSQL = Voucher.mInsertVector(vstrRefNumber, "", "", vdteDate, oAssets[1].ToString(),
                                                             oAssets[0].ToString(), lnglType, lnglType, 1, vstrBranchID, Utility.Val(oAssets[2].ToString()), 0, "", vlngVoucherType);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lnglType += 1;
                            }
                        }
                    }

                   
                    cmdInsert.Transaction.Commit();
                    cmdInsert.Dispose();
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }



        #endregion
        #region "onlile SecurityInsert"
        public List<UserAccess> mFillOnlineSecurity(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<UserAccess> oogrp = new List<UserAccess>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT USER_ID SL_NO,USER_ID,PASSWORD,STATUS,COR_MOBILE_NO,LEDGER_NAME,SECURITY_CODE,COR_MOBILE_NO  from USER_ONLILE_SECURITY order by SL_NO";
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
                    UserAccess ogrp = new UserAccess();
                    ogrp.lngSlNo = Convert.ToInt32(drGetGroup["SL_NO"]);
                    ogrp.LogInName = drGetGroup["USER_ID"].ToString();
                    ogrp.strPassWord = drGetGroup["PASSWORD"].ToString();
                    if (drGetGroup["COR_MOBILE_NO"].ToString() != "")
                    {
                        ogrp.MobileNo = drGetGroup["COR_MOBILE_NO"].ToString();
                    }
                    else
                    {
                        ogrp.MobileNo = "";
                    }
                    if (drGetGroup["LEDGER_NAME"].ToString() != "")
                    {
                        ogrp.LedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.LedgerName = "";
                    }
                    if (drGetGroup["SECURITY_CODE"].ToString() != "")
                    {
                        ogrp.SecurityCode = drGetGroup["SECURITY_CODE"].ToString();
                    }
                    else
                    {
                        ogrp.SecurityCode = "";
                    }
                    ogrp.intAccessLevel = Convert.ToInt16(drGetGroup["STATUS"].ToString());
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mUpdateOnLineSecurty(string strDeComID, long lngslNo, string strUserId, string password, int intaccesslevel, string securityCode)
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

                strSQL = "UPDATE USER_ONLILE_SECURITY SET ";
                strSQL = strSQL + " PASSWORD ='" + password + "' ";
                strSQL = strSQL + ",SECURITY_CODE ='" + securityCode.Replace("'","''") + "' ";
                strSQL = strSQL + ",STATUS =" + intaccesslevel + " ";
                strSQL = strSQL + " WHERE USER_ID=" + lngslNo + " ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                cmd.ExecuteNonQuery();
                gcnMain.Close();
                cmd.Dispose();
                return "1";

            }
        }
        public string mUpdateOnLineApprove(string strDeComID, string strRefNo,int intstatus,string strUserName)
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

                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET APP_STATUS =" + intstatus + " ";
                strSQL = strSQL + ",APPROVED_BY ='" + strUserName + "' ";
                strSQL = strSQL + " WHERE COMP_REF_NO='" + strRefNo + "' ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                cmd.ExecuteNonQuery();
                gcnMain.Close();
                cmd.Dispose();
                return "1";

            }
        }
        #endregion
        #region "bank Ledger"
        public List<AccountsLedger> mGetBankLedger(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> oogrp = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER WHERE LEDGER_GROUP =100 ";
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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strLedgerName  = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        #endregion
        #region "Bank Reconcilation"
        public List<AccountsVoucher> mDisplayBankReconcilation(string strDeComID,string strLedgerName,string strfDate,string strTDate)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsVoucher> oogrp = new List<AccountsVoucher>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT v.VOUCHER_REF_KEY,v.VOUCHER_REVERSE_LEDGER, V.COMP_REF_NO,V.COMP_VOUCHER_DATE,V.COMP_VOUCHER_TYPE,V.VOUCHER_CHEQUE_NUMBER,V.VOUCHER_CHEQUE_DATE,V.VOUCHER_TOBY,V.VOUCHER_DEBIT_AMOUNT,V.VOUCHER_CREDIT_AMOUNT  ";
            strSQL = strSQL + ",VOUCHER_BANK_DATE,BANK_CHARGE_PER,BANK_CHARGE_AMOUNT,BANK_RECON_STATUS FROM  ACC_LEDGER_VOUCHER V WHERE LEDGER_NAME ='" + strLedgerName.Trim().Replace("'", "''") + "' ";
            strSQL = strSQL + " AND V.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strfDate) + " ";
            strSQL = strSQL + " AND  " + Utility.cvtSQLDateString(strTDate) + " ";
            strSQL = strSQL + "order by V.COMP_VOUCHER_DATE ";
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
                    AccountsVoucher ogrp = new AccountsVoucher();
                    ogrp.strMerzeName = drGetGroup["VOUCHER_REF_KEY"].ToString();
                    ogrp.strVoucherNo = drGetGroup["COMP_REF_NO"].ToString();
                    ogrp.strLedgerName = drGetGroup["VOUCHER_REVERSE_LEDGER"].ToString();
                    ogrp.strTranDate = Convert.ToDateTime(drGetGroup["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.intvoucherPos = Convert.ToInt32(drGetGroup["COMP_VOUCHER_TYPE"].ToString());
                    if (drGetGroup["VOUCHER_CHEQUE_NUMBER"].ToString() != "")
                    {
                        ogrp.strChequeNo = drGetGroup["VOUCHER_CHEQUE_NUMBER"].ToString();
                    }
                    else
                    {
                        ogrp.strChequeNo = "";
                    }
                    if (drGetGroup["VOUCHER_CHEQUE_DATE"].ToString() != "")
                    {
                        ogrp.strChequeDate = Convert.ToDateTime(drGetGroup["VOUCHER_CHEQUE_DATE"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        ogrp.strChequeDate = "";
                    }
                    ogrp.strToby = drGetGroup["VOUCHER_TOBY"].ToString();
                    ogrp.dblDebitAmount = Convert.ToDouble(drGetGroup["VOUCHER_DEBIT_AMOUNT"].ToString());
                    ogrp.dblCreditAmount  = Convert.ToDouble(drGetGroup["VOUCHER_CREDIT_AMOUNT"].ToString());
                    if (drGetGroup["VOUCHER_BANK_DATE"].ToString() != "")
                    {
                        ogrp.strBankdate = Convert.ToDateTime(drGetGroup["VOUCHER_BANK_DATE"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        ogrp.strBankdate  = "";
                    }
                    if (drGetGroup["BANK_CHARGE_PER"].ToString() != "")
                    {
                        ogrp.strBankPer = drGetGroup["BANK_CHARGE_PER"].ToString();
                    }
                    else
                    {
                        ogrp.strBankPer = "0";
                    }
                    ogrp.dblBankChargeAmnt = Convert.ToDouble(drGetGroup["BANK_CHARGE_AMOUNT"].ToString());
                    ogrp.strStatus = drGetGroup["BANK_RECON_STATUS"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mUpdateBankReconcilation(string strDeComID, string strRefKey, string strRefNo, string strBankDate, string strBankPer, double dblBankAmount)
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

                strSQL = "SELECT BANK_RECON_STATUS FROM ACC_VOUCHER ";
                strSQL = strSQL + "WHERE VOUCHER_REF_KEY='" + strRefKey + "' ";
                strSQL = strSQL + "AND BANK_RECON_STATUS='Y'";
                cmdInsert.CommandText = strSQL;
                DR = cmdInsert.ExecuteReader();
                if (DR.Read())
                {
                    DR.Close();
                    return "Already Locked You Cannot Update";
                }
                DR.Close();
                strSQL = "UPDATE ACC_VOUCHER SET VOUCHER_BANK_DATE=" + Utility.cvtSQLDateString(strBankDate) + " ";
                strSQL = strSQL + ",BANK_CHARGE_PER='" + strBankPer.Trim() + "' ";
                strSQL = strSQL + ",BANK_CHARGE_AMOUNT=" + Math.Abs(dblBankAmount) + " ";
                strSQL = strSQL + ",BANK_RECON_STATUS='Y'";
                strSQL = strSQL + "WHERE VOUCHER_REF_KEY='" + strRefKey + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Transaction.Commit();

                gcnMain.Dispose();
                DR.Close();
                return "1";

            }
        }
        #endregion
        #region "MPO Percentage"
        public string mInsertMpoPercentage(string strDeComID, string strLedgerName,string strMPOName,  double dblPercentage, double dblAmount,string strEffectiveDate, int intDel,int  intStatus)
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
                    strSQL = "DELETE FROM MPO_COMMISSION_PERCENTAGE ";
                    strSQL = strSQL + " WHERE ";
                    strSQL = strSQL + " COMMISSION_LEDGER ='" + strLedgerName.Replace("'", "''") + "' ";
                    strSQL = strSQL + " AND ACTIVE =" + intStatus + " ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                else
                {
                    strSQL = "INSERT INTO MPO_COMMISSION_PERCENTAGE(COMMISSION_LEDGER,LEDGER_NAME,PERCENTAGES,SAL_AMOUNT,EFFECTIVE_DATE,ACTIVE)";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + strLedgerName.Replace("'", "''") + "' ";
                    strSQL = strSQL + ",'" + strMPOName.Replace("'", "''") + "' ";
                    strSQL = strSQL + "," + dblPercentage + " ";
                    strSQL = strSQL + "," + dblAmount + " ";
                    if (strEffectiveDate !="")
                    {
                        strSQL = strSQL + "," + Utility.cvtSQLDateString(strEffectiveDate) + " ";
                    }
                    else
                    {
                        strSQL = strSQL + ",null";
                    }
                    strSQL = strSQL + "," + intStatus + " ";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE ACC_EXPENSE_CONFIG_MASTER SET PER_STATUS=1 ";
                    strSQL = strSQL + " WHERE LEDGER_NAME ='" + strLedgerName.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                cmdInsert.Transaction.Commit();
                gcnMain.Dispose();
                return "1";

            }
        }
        public string mInsertMpoManual(string strDeComID, string strKey,string strMonthID,string strBranchID, string strLedgerName,string strHeadName, double dblAmount, int intDel,int intCols,int intRow)
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
                    strSQL = "DELETE FROM MPO_COMM_MAN_PARENT_CHILD ";
                    strSQL = strSQL + " WHERE ";
                    strSQL = strSQL + " COMM_MANUAL_KEY ='" + strKey.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM MPO_COMM_MAN_PARENT ";
                    strSQL = strSQL + " WHERE ";
                    strSQL = strSQL + " COMM_MANUAL_KEY ='" + strKey.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO MPO_COMM_MAN_PARENT(COMM_MANUAL_KEY,MONTH_ID,BRANCH_ID)";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + strKey.Replace("'", "''") + "' ";
                    strSQL = strSQL + ",'" + strMonthID.Replace("'", "''") + "' ";
                    strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                }
                else
                {
                    strSQL = "INSERT INTO MPO_COMM_MAN_PARENT_CHILD(COMM_MANUAL_KEY,LEDGER_NAME,HEAD_NAME,AMOUNT,COLS,ROWPOS)";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + strKey.Replace("'", "''") + "' ";
                    strSQL = strSQL + ",'" + strLedgerName.Replace("'", "''") + "' ";
                    strSQL = strSQL + ",'" + strHeadName.Replace("'", "''") + "' ";
                    strSQL = strSQL + "," + dblAmount + " ";
                    strSQL = strSQL + "," + intCols + " ";
                    strSQL = strSQL + "," + intRow + " ";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                cmdInsert.Transaction.Commit();
                gcnMain.Dispose();
                return "1";

            }
        }
        public List<AccountsLedger> mFillManualBill(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> ooLed = new List<AccountsLedger>();

            //strSQL = "SELECT COMM_MANUAL_KEY,LEDGER_NAME,MONTH_ID,BRANCH_ID ";
            //strSQL = strSQL + "FROM MPO_COMM_MAN_PARENT ";
            //strSQL = strSQL + "ORDER BY LEDGER_NAME ASC ";
            strSQL = "SELECT COMM_MANUAL_KEY,MONTH_ID,MPO_COMM_MAN_PARENT.BRANCH_ID  ";
            strSQL = strSQL + " FROM MPO_COMM_MAN_PARENT ";
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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strConfigkey = drGetGroup["COMM_MANUAL_KEY"].ToString();
                    //ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    //ogrp.strmerzeString = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ogrp.strEfectDate = drGetGroup["MONTH_ID"].ToString();
                    ogrp.strBranchID = drGetGroup["BRANCH_ID"].ToString();

                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        public List<AccountsLedger> mFillDisplayBill(string strDeComID,string strKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> ooLed = new List<AccountsLedger>();

            strSQL = "SELECT COMM_MANUAL_KEY,LEDGER_NAME,AMOUNT,COLS,ROWPOS,HEAD_NAME  ";
            strSQL = strSQL + "FROM MPO_COMM_MAN_PARENT_CHILD ";
            strSQL = strSQL + "WHERE COMM_MANUAL_KEY ='" + strKey + "' ";
            strSQL = strSQL + "ORDER BY ROWPOS,LEDGER_NAME ASC ";
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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strConfigkey = drGetGroup["COMM_MANUAL_KEY"].ToString();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.dblToAmt  = Convert.ToDouble( drGetGroup["AMOUNT"].ToString());
                    ogrp.intCol = Convert.ToInt32(drGetGroup["COLS"].ToString());
                    ogrp.intRow = Convert.ToInt32(drGetGroup["ROWPOS"].ToString());

                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        public string DeleteManualMpoCmm(string strDeComID, string mstrConfiglkey)
        {


            string strresponse, strSQL;

            //long lngDefaultLedger = 0;
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
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;


                    strSQL = "DELETE FROM MPO_COMM_MAN_PARENT_CHILD ";
                    strSQL = strSQL + " WHERE ";
                    strSQL = strSQL + " COMM_MANUAL_KEY ='" + mstrConfiglkey.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM MPO_COMM_MAN_PARENT ";
                    strSQL = strSQL + " WHERE ";
                    strSQL = strSQL + " COMM_MANUAL_KEY ='" + mstrConfiglkey.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    strresponse = "Delete Successfully...";
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
        public double mFillDisplayManualBill(string strDeComID, string strmonth, string strMpo, string strLedger)
        {
            string strSQL;
            double dblAmnt = 0;
            SqlDataReader drGetGroup;
            //List<AccountsLedger> ooLed = new List<AccountsLedger>();

            strSQL = "SELECT MPO_COMM_MAN_PARENT_CHILD.LEDGER_NAME,MPO_COMM_MAN_PARENT_CHILD.AMOUNT FROM MPO_COMM_MAN_PARENT,MPO_COMM_MAN_PARENT_CHILD WHERE MPO_COMM_MAN_PARENT.COMM_MANUAL_KEY=MPO_COMM_MAN_PARENT_CHILD.COMM_MANUAL_KEY  ";
            strSQL = strSQL + "AND MPO_COMM_MAN_PARENT.MONTH_ID ='" + strmonth + "' ";
            strSQL = strSQL + "AND MPO_COMM_MAN_PARENT_CHILD.LEDGER_NAME ='" + strMpo + "' ";
            strSQL = strSQL + "AND MPO_COMM_MAN_PARENT_CHILD.HEAD_NAME ='" + strLedger + "' ";
            strSQL = strSQL + "ORDER BY LEDGER_NAME ASC ";
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
                if (drGetGroup.Read())
                {
                    //AccountsLedger ogrp = new AccountsLedger();
                    //ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    dblAmnt = Convert.ToDouble(drGetGroup["AMOUNT"].ToString());

                    //ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return dblAmnt;

            }
        }
        #endregion
        #region "Delete Template"
        public string DeleteTemplate(string strDeComID, string mstrConfiglkey)
        {


            string strresponse, strSQL;

            //long lngDefaultLedger = 0;
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
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;


                    strSQL = "DELETE FROM ACC_LOAN_TEMPLATE_CHILD ";
                    strSQL = strSQL + " WHERE ";
                    strSQL = strSQL + " TEMPLATE_NAME ='" + mstrConfiglkey.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_LOAN_TEMPLATE_MASTER ";
                    strSQL = strSQL + " WHERE ";
                    strSQL = strSQL + " TEMPLATE_NAME ='" + mstrConfiglkey.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    strresponse = "Delete Successfully...";
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
        #region "Loan"
        public string mSaveLoanMaster(string strDeComID, string strOldTemplateName,string strTemplateName, 
                                             double dblTotalAmount, long lngNoOfInstall, string strInstallmentName,
                                             double dblMonthly, int intDel)
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

                try
                {
                    SqlDataReader DR;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    if (intDel == 1)
                    {
                        strSQL = "DELETE FROM ACC_LOAN_TEMPLATE_CHILD ";
                        strSQL = strSQL + " WHERE ";
                        strSQL = strSQL + " TEMPLATE_NAME ='" + strOldTemplateName.Replace("'", "''") + "' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "DELETE FROM ACC_LOAN_TEMPLATE_MASTER ";
                        strSQL = strSQL + " WHERE ";
                        strSQL = strSQL + " TEMPLATE_NAME ='" + strOldTemplateName.Replace("'", "''") + "' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_LOAN_TEMPLATE_MASTER(TEMPLATE_NAME,INSTALLMENT_AMOUNT,NO_OF_INSTALLMENT,MONTHLY_AMOUNT)";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + strTemplateName.Replace("'", "''") + "' ";
                        strSQL = strSQL + "," + dblTotalAmount + " ";
                        strSQL = strSQL + "," + lngNoOfInstall + " ";
                        strSQL = strSQL + "," + dblMonthly + " ";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    else
                    {
                        strSQL = "INSERT INTO ACC_LOAN_TEMPLATE_CHILD(TEMPLATE_NAME,INSTALLMET_NAME,MONTHLY_AMOUNT)";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + strTemplateName.Replace("'", "''") + "' ";
                        strSQL = strSQL + ",'" + strInstallmentName.Replace("'", "''") + "' ";
                        strSQL = strSQL + "," + dblMonthly + " ";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    cmdInsert.Transaction.Commit();
                    gcnMain.Dispose();
                    return "1";
                }
                catch (Exception ex)
                {
                    return "Cannot Insert Duplicate Value";
                }

            }
        }

        public List<AccountsLedger> mFillLoanList(string strDeComID)
        {
            string strSQL;
          
            SqlDataReader drGetGroup;
            List<AccountsLedger> ooLed = new List<AccountsLedger>();

            strSQL = "SELECT TEMPLATE_NAME,INSTALLMENT_AMOUNT,NO_OF_INSTALLMENT,MONTHLY_AMOUNT FROM ACC_LOAN_TEMPLATE_MASTER ";
            strSQL = strSQL + "ORDER BY TEMPLATE_NAME ASC ";
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
                while  (drGetGroup.Read())
                {
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strLedgerName = drGetGroup["TEMPLATE_NAME"].ToString();
                    ogrp.dblNoVoucher = Convert.ToDouble(drGetGroup["NO_OF_INSTALLMENT"].ToString());
                    ogrp.dblToAmt = Convert.ToDouble(drGetGroup["INSTALLMENT_AMOUNT"].ToString());
                    ogrp.dblFromAmt = Convert.ToDouble(drGetGroup["MONTHLY_AMOUNT"].ToString());
                    ooLed.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }

        }


        public List<AccountsLedger> mDisplayLoanList(string strDeComID, string strTemplateName)
        {
            string strSQL;
          
            SqlDataReader drGetGroup;
            List<AccountsLedger> ooLed = new List<AccountsLedger>();

            strSQL = "select ACC_LOAN_TEMPLATE_MASTER.TEMPLATE_NAME,ACC_LOAN_TEMPLATE_MASTER.INSTALLMENT_AMOUNT,ACC_LOAN_TEMPLATE_MASTER.MONTHLY_AMOUNT as MONTHLY,ACC_LOAN_TEMPLATE_MASTER.NO_OF_INSTALLMENT,ACC_LOAN_TEMPLATE_CHILD.INSTALLMET_NAME,ACC_LOAN_TEMPLATE_CHILD.MONTHLY_AMOUNT  ";
            strSQL = strSQL + "FROM ACC_LOAN_TEMPLATE_MASTER,ACC_LOAN_TEMPLATE_CHILD where ACC_LOAN_TEMPLATE_MASTER.TEMPLATE_NAME =ACC_LOAN_TEMPLATE_CHILD.TEMPLATE_NAME ";
            strSQL = strSQL + "AND  ACC_LOAN_TEMPLATE_MASTER.TEMPLATE_NAME='" + strTemplateName.Replace("'", "''") + "' ";
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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strLedgerName = drGetGroup["TEMPLATE_NAME"].ToString();
                    ogrp.dblNoVoucher = Convert.ToDouble(drGetGroup["NO_OF_INSTALLMENT"].ToString());
                    ogrp.dbltargetAmount = Convert.ToDouble(drGetGroup["INSTALLMENT_AMOUNT"].ToString());
                    ogrp.strmerzeString = drGetGroup["INSTALLMET_NAME"].ToString();
                    ogrp.dblToAmt = Convert.ToDouble(drGetGroup["MONTHLY_AMOUNT"].ToString());
                    ogrp.dbltargetAmount = Convert.ToDouble(drGetGroup["MONTHLY"].ToString());
                    ooLed.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        public List<AccountsLedger> mGetInstallmentNo(string strDeComID,string strLegdername,string strInstallment)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> ooLed = new List<AccountsLedger>();
            strSQL = "SELECT TEMPLATE_NAME,INSTALLMET_NAME,DUE_DATE,MONTHLY_AMOUNT from ACC_PAYMENT_SCHEDULE ";
            strSQL = strSQL + "WHERE LEDGER_NAME='" + strLegdername + "'";
            strSQL = strSQL + "AND INSTALL_STATUS=0 ";
            if (strInstallment !="")
            {
                strSQL = strSQL + "AND INSTALLMET_NAME='" + strInstallment + "' ";
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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strmerzeString = drGetGroup["TEMPLATE_NAME"].ToString();
                    ogrp.strLedgerName = drGetGroup["INSTALLMET_NAME"].ToString();
                    ogrp.strCreditDate = Convert.ToDateTime(drGetGroup["DUE_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.dblToAmt = Convert.ToDouble(drGetGroup["MONTHLY_AMOUNT"].ToString());
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }

        #endregion
        #region "HondLoan"
        public string mSaveLoanTransfer(string strDeComID, string strFromTransfer, string strToTransfer,string strNarration)
                                            
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

                try
                {
                 
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    strSQL = "UPDATE ACC_PAYMENT_SCHEDULE SET ";
                    strSQL = "LEDGER_NAME='" + strToTransfer.Replace("'", "''") + "' ";
                    strSQL = ",LEDGER_FORM_NAME='" + strFromTransfer.Replace("'", "''") + "' ";
                    strSQL = ",NARRATION='" + strNarration.Replace("'", "''") + "' ";
                    strSQL = ",TRANSFER_TYPE='T' ";
                    strSQL = strSQL + "WHERE LEDGER_NAME ='" + strFromTransfer.Replace("'", "''") + "' ";
                    strSQL = strSQL + "AND TO_BY ='Dr' and INSTALL_STATUS =0 and TRANSFER_TYPE='N' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Dispose();
                    return "1";
                }
                catch (Exception ex)
                {
                    return "Cannot Insert Duplicate Value";
                }

            }
        }
        public string mDeleteTransfer(string strDeComID, string strFromTransfer)
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

                try
                {

                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    strSQL = "UPDATE ACC_PAYMENT_SCHEDULE SET ";
                    strSQL = "LEDGER_NAME='" + strFromTransfer.Replace("'", "''") + "' ";
                    strSQL = ",LEDGER_FORM_NAME='Null' ";
                    strSQL = ",NARRATION='Null' ";
                    strSQL = ",transfer_type='T' ";
                    strSQL = strSQL + "WHERE LEDGER_NAME ='" + strFromTransfer.Replace("'", "''") + "' ";
                    strSQL = strSQL + "AND TO_BY ='Dr' and INSTALL_STATUS =0 and TRANSFER_TYPE='N' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Dispose();
                    return "1";
                }
                catch (Exception ex)
                {
                    return "Cannot Insert Duplicate Value";
                }

            }
        }
        public List<AccountsLedger> mFillTransferList(string strDeComID)
        {
            string strSQL;

            SqlDataReader drGetGroup;
            List<AccountsLedger> ooLed = new List<AccountsLedger>();

            strSQL = "SELECT DISTINCT LEDGER_NAME,FROM_LEDGER_NAME FROM ACC_PAYMENT_SCHEDULE ";
            strSQL = strSQL + "WHERE TRANSFER_TYPE='T' ";
            strSQL = strSQL + "ORDER BY LEDGER_NAME ASC ";
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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strmerzeString = drGetGroup["FROM_LEDGER_NAME"].ToString();
                    ooLed.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }

        }

        public List<AccountdGroup> GetHondaLoanGroupList(string strDeComID, long mlngGroupAs, bool vblngAccessControl, string vstrUserName, int intMode)
        {

            SqlDataReader dr;
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<AccountdGroup> ooAccGrop = new List<AccountdGroup>();
            if (intMode == 1)
            {
                if (vblngAccessControl == true)
                {
                    strSQL = "select GR_NAME as GR_NAME FROM ACC_LEDGERGROUP  WHERE GR_GROUP = 205 and ";
                    strSQL = strSQL + "GR_PARENT='Advance for Motorcycle'";
                    strSQL = strSQL + "union all ";
                    strSQL = strSQL + "select Distinct GR_PARENT as ddd FROM ACC_LEDGERGROUP  WHERE GR_GROUP = 205 and  GR_ONE_DOWN='Advance Deposit & Prepayment' and GR_LEVEL=4 ";
                }
                else
                {
                    strSQL = "select GR_NAME as GR_NAME FROM ACC_LEDGERGROUP  WHERE GR_GROUP = 205 and ";
                    strSQL = strSQL + "GR_PARENT='Advance for Motorcycle' ";
                    strSQL = strSQL + "union all ";
                    strSQL = strSQL + "select Distinct GR_PARENT as ddd FROM ACC_LEDGERGROUP  WHERE GR_GROUP = 205 and  GR_ONE_DOWN='Advance Deposit & Prepayment' and GR_LEVEL=4 ";
                }
            }
            else
            {
                strSQL = "select LEDGER_NAME_MERZE from ACC_LEDGER  where  LEDGER_GROUP=205 and ";
                strSQL = strSQL + "LEDGER_PARENT_GROUP IN('Advance For Motorcycle-MPO','Advance For Motorcycle-Manager')order by LEDGER_NAME_MERZE ";
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
                    AccountdGroup ogrp = new AccountdGroup();
                    if (intMode == 1)
                    {
                        ogrp.GroupName = dr["GR_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.GroupName = dr["LEDGER_NAME_MERZE"].ToString();
                    }

                    ooAccGrop.Add(ogrp);
                }
                dr.Close();
                return ooAccGrop;
            }
        }
        #endregion
        #region "ReportLedger"
        public List<AccountsLedger> mFillLedgerSelection(string strDeComID, long lngGroup, string strMode, string stString)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountsLedger> oogrp = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT ACC_LEDGER.LEDGER_NAME  from ACC_LEDGER_Z_D_A,ACC_LEDGER where  ACC_LEDGER.LEDGER_NAME=ACC_LEDGER_Z_D_A.LEDGER_NAME ";
            strSQL = strSQL + "AND ACC_LEDGER.LEDGER_GROUP = " + lngGroup + " ";
            strSQL = strSQL + "AND ACC_LEDGER.LEDGER_STATUS = 0 ";
            if (strMode == "Z")
            {
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE IN(" + stString + ")";
            }
            else if (strMode == "D")
            {
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION IN(" + stString + ")";
            }
            else if (strMode == "A")
            {
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA IN(" + stString + ")";
            }
            else if (strMode == "M")
            {
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE IN(" + stString + ")";
            }
            strSQL = strSQL + "ORDER BY ACC_LEDGER.LEDGER_NAME";
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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        #endregion
        #region "Projection"
        public List<AccountsLedger> mFillLedgerSelectionProjection(string strDeComID, long lngGroup, string strMode, string stString, string struserName)
        {
            string strSQL="";
            SqlDataReader drGetGroup;
            List<AccountsLedger> oogrp = new List<AccountsLedger>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

           
            if (strMode == "Z")
            {
                strSQL = "SELECT DISTINCT ACC_LEDGER_Z_D_A.ZONE LEDGER_NAME  from ACC_LEDGER_Z_D_A,ACC_LEDGER where  ACC_LEDGER.LEDGER_NAME=ACC_LEDGER_Z_D_A.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_GROUP = " + lngGroup + " ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + struserName + "') ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE IN(" + stString + ")";
                strSQL = strSQL + "ORDER BY ACC_LEDGER_Z_D_A.ZONE";
            }
            else if (strMode == "D")
            {
                strSQL = "SELECT DISTINCT ACC_LEDGER_Z_D_A.DIVISION LEDGER_NAME from ACC_LEDGER_Z_D_A,ACC_LEDGER where  ACC_LEDGER.LEDGER_NAME=ACC_LEDGER_Z_D_A.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_GROUP = " + lngGroup + " ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + struserName + "') ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION IN(" + stString + ")";
                strSQL = strSQL + "ORDER BY ACC_LEDGER_Z_D_A.DIVISION";
            }
            else if (strMode == "K")
            {
                strSQL = "SELECT ACC_LEDGER_Z_D_A.LEDGER_NAME from ACC_LEDGER_Z_D_A,ACC_LEDGER where  ACC_LEDGER.LEDGER_NAME=ACC_LEDGER_Z_D_A.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_GROUP = " + lngGroup + " ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + struserName + "') ";
                strSQL = strSQL + "AND (ACC_LEDGER_Z_D_A.AREA IN(" + stString + ")";
                strSQL = strSQL + "or ACC_LEDGER_Z_D_A.DIVISION IN(" + stString + ")";
                strSQL = strSQL + "or ACC_LEDGER_Z_D_A.ZONE IN(" + stString + "))";

                strSQL = strSQL + "ORDER BY ACC_LEDGER_Z_D_A.LEDGER_NAME";

            }
            else if (strMode == "A")
            {
                strSQL = "SELECT DISTINCT ACC_LEDGER_Z_D_A.AREA LEDGER_NAME from ACC_LEDGER_Z_D_A,ACC_LEDGER where  ACC_LEDGER.LEDGER_NAME=ACC_LEDGER_Z_D_A.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_GROUP = " + lngGroup + " ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + struserName + "') ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.AREA IN(" + stString + ")";
                strSQL = strSQL + "ORDER BY ACC_LEDGER_Z_D_A.AREA";
              
            }
            else if (strMode == "M")
            {
                strSQL = "SELECT ACC_LEDGER_Z_D_A.LEDGER_NAME  from ACC_LEDGER_Z_D_A,ACC_LEDGER where  ACC_LEDGER.LEDGER_NAME=ACC_LEDGER_Z_D_A.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_GROUP = " + lngGroup + " ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + struserName + "') ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE IN(" + stString + ")";
                strSQL = strSQL + "ORDER BY ACC_LEDGER_Z_D_A.LEDGER_NAME";
              
            }
            else
            {
                strSQL = "SELECT ACC_LEDGER_Z_D_A.LEDGER_NAME  from ACC_LEDGER_Z_D_A,ACC_LEDGER where  ACC_LEDGER.LEDGER_NAME=ACC_LEDGER_Z_D_A.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_GROUP = " + lngGroup + " ";
                strSQL = strSQL + "AND ACC_LEDGER.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION in( select LEDGER_GROUP_NAME from USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME ='" + struserName + "') ";
                //strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE IN(" + stString + ")";
                strSQL = strSQL + "ORDER BY ACC_LEDGER_Z_D_A.LEDGER_NAME";
            }
           
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
                    AccountsLedger ogrp = new AccountsLedger();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        #endregion
        #region "GraceMonthSetup"
        public string mSaveGraceMonthConfig(string strDeComID, string strMonthID, string vstrfromDate, string vstrtodate,string vstrGfromDate, string vstrGtodate, string vstrStatus)
        {

            int intStatus = 0;
            string strresponse = "";
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
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    if (vstrStatus == "Inactive")
                    {
                        intStatus = 1;
                    }
                    else
                    {
                        intStatus = 0;
                    }

                    strSQL = "INSERT INTO ACC_COLL_MONTH_SETUP(";
                    strSQL = strSQL + "MONTH_ID,FROM_DATE,TO_DATE,GRACE_FROM_DATE,GRACE_TO_DATE,MONTH_STATUS";
                    strSQL = strSQL + ")";
                    strSQL = strSQL + " VALUES(";
                    strSQL = strSQL + "'" + strMonthID + "'";
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(vstrfromDate) + "";
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(vstrtodate) + "";
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(vstrGfromDate) + "";
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(vstrGtodate) + "";
                    strSQL = strSQL + "," + intStatus + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();



                    cmdInsert.Transaction.Commit();
                    strresponse = "1";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return "Sorry! Month ID is already Exists..";
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        public string mUpdateGraceMonthConfig(string strDeComID, string stroldMonthID, string strMonthID, string vstrfromDate, string vstrtodate,string vstrGfromDate, string vstrGtodate, string vstrStatus)
        {

            int intStatus = 0;
            string strresponse = "";
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
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    if (vstrStatus == "Inactive")
                    {
                        intStatus = 1;
                    }
                    else
                    {
                        intStatus = 0;
                    }
                    strSQL = "UPDATE ACC_COLL_MONTH_SETUP set  ";
                    strSQL = strSQL + "MONTH_ID= '" + strMonthID + "',";
                    strSQL = strSQL + "FROM_DATE= " + Utility.cvtSQLDateString(vstrfromDate) + ",";
                    strSQL = strSQL + "TO_DATE= " + Utility.cvtSQLDateString(vstrtodate) + ",";
                    strSQL = strSQL + "GRACE_FROM_DATE= " + Utility.cvtSQLDateString(vstrGfromDate) + ",";
                    strSQL = strSQL + "GRACE_TO_DATE= " + Utility.cvtSQLDateString(vstrGtodate) + ",";
                    strSQL = strSQL + "MONTH_STATUS= " + intStatus + " ";
                    strSQL = strSQL + "WHERE MONTH_ID='" + stroldMonthID + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();



                    cmdInsert.Transaction.Commit();
                    strresponse = "1";
                    return strresponse;
                }

                catch (SqlException ex)
                {
                    return "Sorry! Month ID is already Exists..";
                }
                finally
                {
                    gcnMain.Dispose();

                }
            }
        }
        public List<AccountdGroup> mDisplayGraceMonthsetupList(string strDeComID, string strMonthId)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountdGroup> oogrp = new List<AccountdGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "SELECT MONTH_ID,FROM_DATE,TO_DATE,MONTH_STATUS,GRACE_FROM_DATE,GRACE_TO_DATE from ACC_COLL_MONTH_SETUP  ";
                if (strMonthId != "")
                {
                    strSQL = strSQL + " WHERE  MONTH_STATUS=0 ";
                }
                strSQL = strSQL + "ORDER BY MONTH_ID ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();
                    ogrp.strMonthID = drGetGroup["MONTH_ID"].ToString();
                    ogrp.strFromdate = Convert.ToDateTime(drGetGroup["FROM_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.strTodate = Convert.ToDateTime(drGetGroup["TO_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.strGFromDate = Convert.ToDateTime(drGetGroup["GRACE_FROM_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.strGTodate = Convert.ToDateTime(drGetGroup["GRACE_TO_DATE"]).ToString("dd-MM-yyyy");
                    if (Convert.ToInt32(drGetGroup["MONTH_STATUS"]) == 1)
                    {
                        ogrp.strStstus = "Inactive";
                    }
                    else
                    {
                        ogrp.strStstus = "Active";
                    }

                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<AccountdGroup> mGetGraceDateFromMonthID(string strDeComID, string strMonthId)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<AccountdGroup> oogrp = new List<AccountdGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "select FROM_DATE,TO_DATE,GRACE_FROM_DATE,GRACE_TO_DATE,MONTH_STATUS from ACC_COLL_MONTH_SETUP  ";
                if (strMonthId != "")
                {
                    strSQL = strSQL + " WHERE  MONTH_ID='" + strMonthId + "' ";
                }
                strSQL = strSQL + "ORDER BY MONTH_ID ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    AccountdGroup ogrp = new AccountdGroup();

                    ogrp.strFromdate = Convert.ToDateTime(drGetGroup["FROM_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.strTodate = Convert.ToDateTime(drGetGroup["TO_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.strGFromDate = Convert.ToDateTime(drGetGroup["GRACE_FROM_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.strGTodate = Convert.ToDateTime(drGetGroup["GRACE_TO_DATE"]).ToString("dd-MM-yyyy");
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mDeleteGraceMonthList(string strDeComID, string strMonthID)
        {
            string strSQL, strReponse = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmdInsert = new SqlCommand();
                SqlDataReader dr;
                SqlTransaction myTrans;

                try
                {
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    strSQL = "select MONTH_ID  from ACC_COLL_MONTH_SETUP  ";
                    strSQL = strSQL + "WHERE MONTH_ID='" + strMonthID + "' ";
                    strSQL = strSQL + "AND MONTH_STATUS=0";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        strReponse = "Active Month Cannot be Delete";
                        return strReponse;
                    }
                    dr.Close();

                    strSQL = "DELETE from ACC_COLL_MONTH_SETUP  ";
                    strSQL = strSQL + "WHERE MONTH_ID='" + strMonthID + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    return "1";

                    dr.Close();
                    gcnMain.Dispose();
                }
                catch (Exception EX)
                {
                    return "Collection found for this month,So you Cannot Delete";
                }
                finally
                {

                    gcnMain.Dispose();
                }


            }
        }

        #endregion
    }
}
