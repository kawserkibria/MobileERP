using Dutility;
using JA.Accounts.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace JA.Accounts.Dal
{
    public class JSales
    {
        //private string connstring = Utility.SQLConnstringWcf();
        //private string connstring = Utility.SQLConnstring();
        private string connstring;
        private string strSQL = "";

        public string mSaveCustomerLedger(string strDeComID,string vsstrBranchID,string vsstrLedgerName, string vstrParent, string strPriceLevel, string strLedgerAddDate, string vstrEMail, 
                                        string vstrFax, string vstrAddress1, string vstrAddress2, string vstrcity, string vstrCountry, 
                                        string vstrContractPer, string vstrPostal, string vstrPhone, string vstrComments, string vstrCurrency,
                                        string strBillWise, string strInactive, string strCostCenter, string strDrcr, double dblopnBalance,
                                        string strcostcenterGrid, string strBranchGrid, string strBillwiseGrid,
                                        double dblCreditLimit, double dblCreditPeriod, string strFinancialForm,string strResignDate,
                                        int intCommission,string strTerritorycode,string strTerritoryName,string strClass,int intBkash,
                                        string strCloseDate,string strPFLedger,string strHLLedger)
        {
            long lngGroupType = 0, lngLedgerGroup = 0, lngMultiply = 0, lngLedgerLevel = 0, lngCostCenter = 0, lngGrLevel = 0, lngCashFlowType = 0, lngManuFacType = 0, lngLedgerStatus = 0, lngbillWise = 0, lngPayroll = 0;
            string strSQL,strMerze, strPrimary = "", strGrOneDown = "", strLedgerName = "", strParent, strEMail, strFax, strVectorDrCr = "";
            double dblOpeningBalance = 0;

            bool blnInsert = false;

            strLedgerName = vsstrLedgerName;
            if (strTerritorycode != "")
            {
                strMerze = strTerritorycode + "-" + strLedgerName + "-" + strTerritoryName;
            }
            else if (strTerritoryName != "")
            {
                strMerze = strLedgerName + "-" + strTerritoryName;
            }
            else
            {
                strMerze = strLedgerName;
            }
            strParent = vstrParent;
            strEMail = vstrEMail;
            strFax = vstrFax;
            if (strBillWise == "Yes")
            {
                lngbillWise = 2;
            }

            if (strInactive == "Yes")
            {
                lngLedgerStatus = 1;
            }
            else if (strInactive == "Close")
            {
                lngLedgerStatus = 2;
            }
            else
            {
                lngLedgerStatus = 0;
            }
            if (strCostCenter == "Yes")
            {
                lngCostCenter = 2;
            }

            else if (strCostCenter == "No")
            {
                lngCostCenter = 1;
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
                    strGrOneDown = (dr["GR_ONE_DOWN"].ToString());
                    lngLedgerLevel = long.Parse(dr["GR_LEVEL"].ToString())+1;
                    lngCashFlowType = long.Parse(dr["GR_CASH_FLOW_TYPE"].ToString());
                    lngManuFacType = long.Parse(dr["GR_MANUFAC_GROUP"].ToString());
                }

                dr.Close();

                if (lngLedgerGroup == 0)
                {
                    lngLedgerGroup = (long)Utility.GR_GROUP_TYPE.grOTHER_LEDGER;
                }

                strSQL = "INSERT INTO ACC_LEDGER(";
                if (vsstrBranchID != "")
                {
                    strSQL = strSQL + "BRANCH_ID,";
                }
                strSQL=strSQL +" LEDGER_NAME,LEDGER_NAME_MERZE,";
                strSQL = strSQL + "LEDGER_CASH_FLOW_TYPE,LEDGER_PARENT_GROUP,LEDGER_PRIMARY_GROUP,LEDGER_ONE_DOWN, ";
                strSQL = strSQL + "LEDGER_OPENING_BALANCE,LEDGER_CLOSING_BALANCE,";
                strSQL = strSQL + "LEDGER_CREDIT_LIMIT,LEDGER_CREDIT_PERIOD,";
                strSQL = strSQL + "LEDGER_ADDRESS1,LEDGER_ADDRESS2,LEDGER_CITY,";
                strSQL = strSQL + "LEDGER_COUNTRY,LEDGER_CONTACT, LEDGER_POSTAL,";
                strSQL = strSQL + "LEDGER_PHONE,LEDGER_FAX,LEDGER_EMAIL,";
                strSQL = strSQL + "LEDGER_COMMENTS,LEDGER_BILL_WISE,LEDGER_STATUS,";

                strSQL = strSQL + "LEDGER_LEVEL,LEDGER_GROUP,LEDGER_PRIMARY_TYPE,LEDGER_VECTOR,LEDGER_CURRENCY_SYMBOL";
                strSQL = strSQL + ",LEDGER_ADD_DATE";
                if (strPriceLevel != "")
                {
                    strSQL = strSQL + ",LEDGER_PRICE_LABEL";
                }
                if (strResignDate != "")
                {
                    strSQL = strSQL + ",LEDGER_RESIGN_DATE";
                }
               
                strSQL = strSQL + ",LEDGER_COMMISSION";

                if (strTerritorycode != "")
                {
                    strSQL = strSQL + ",TERITORRY_CODE";
                }
                if (strTerritoryName != "")
                {
                    strSQL = strSQL + ",TERRITORRY_NAME";
                }
                if (strClass != "")
                {
                    strSQL = strSQL + ",LEDGER_CLASS";
                }
                strSQL = strSQL + ",BKASH_STATUS";
                strSQL = strSQL + ",CLOSE_DATE";
                strSQL = strSQL + ",PF_LEDGER_NAME";
                strSQL = strSQL + ",HL_LEDGER_NAME";
                strSQL = strSQL + ") ";
                strSQL = strSQL + "VALUES(";
                if (vsstrBranchID != "")
                {
                    strSQL = strSQL + "'" + vsstrBranchID + "', ";
                }
                strSQL = strSQL + "'" + strLedgerName + "'," + "'" + strMerze.Replace("'","''") +"'," + lngCashFlowType + ",'" + strParent + "','" + strPrimary + "', ";
                strSQL = strSQL + "'" + strGrOneDown + "', " + dblOpeningBalance + "," + dblOpeningBalance + ", ";
                strSQL = strSQL + " " + dblCreditLimit + "," + dblCreditPeriod + ", ";
                strSQL = strSQL + "'" + vstrAddress1 + "','" + vstrAddress2 + "',";
                strSQL = strSQL + "'" + vstrcity + "','" + vstrCountry + "',";
                strSQL = strSQL + "'" + vstrContractPer + "', ";
                strSQL = strSQL + "'" + vstrPostal + "',";
                strSQL = strSQL + "'" + vstrPhone + "', ";
                strSQL = strSQL + "'" + strFax + "','" + strEMail + "', ";
                strSQL = strSQL + "'" + vstrComments + "',";
                strSQL = strSQL + " " + lngbillWise + ", ";

                strSQL = strSQL + " " + lngLedgerStatus + ", ";
                strSQL = strSQL + " " + lngLedgerLevel + ", ";
                strSQL = strSQL + " " + lngLedgerGroup + ", ";
                strSQL = strSQL + " " + lngGroupType + ", ";
                strSQL = strSQL + " " + lngCostCenter + ",";
                strSQL = strSQL + "'" + vstrCurrency + "'";
                if (strLedgerAddDate == "")
                {
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(DateTime.Today.ToString("dd/MM/yyyy")) + "";
                }
                else
                {
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(strLedgerAddDate) + "";
                }
                if (strPriceLevel != "")
                {
                    strSQL = strSQL + ",'" + strPriceLevel + "' ";
                }
                if (strResignDate != "")
                {
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(strResignDate) + "";
                }
                strSQL = strSQL + "," + intCommission + " ";
                if (strTerritorycode != "")
                {
                    strSQL = strSQL + ",'" + strTerritorycode.Replace("'","''") + "' ";
                }
                if (strTerritoryName != "")
                {
                    strSQL = strSQL + ",'" + strTerritoryName + "'";
                }

                if (strClass != "")
                {
                    strSQL = strSQL + ",'" + strClass + "'";
                }
                strSQL = strSQL + "," + intBkash + " ";
                if (strCloseDate != "")
                {
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(strCloseDate) + "";
                }
                else
                {
                    strSQL = strSQL + ",null";
                }
                if (strPFLedger != "")
                {
                    strSQL = strSQL + ",'" + strPFLedger.Replace("'", "''") + "' ";
                }
                else
                {
                    strSQL = strSQL + ",null";
                }
                if (strHLLedger != "")
                {
                    strSQL = strSQL + ",'" + strHLLedger.Replace("'", "''") + "' ";
                }
                else
                {
                    strSQL = strSQL + ",null";
                }
            
              
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

                        //lngGroupLavel = (long)dr1["GR_LEVEL"];
                        lngGrLevel = long.Parse(dr1["GR_LEVEL"].ToString()) + 1;
                    }
                    else
                    {
                        blnInsert = true;
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
                if (strDrcr.ToUpper() == "DR")
                {
                    strSQL = strSQL + "GR_OPENING_DEBIT = GR_OPENING_DEBIT + " + dblOpeningBalance + ", ";
                    strSQL = strSQL + "GR_CLOSING_DEBIT = GR_CLOSING_DEBIT + " + dblOpeningBalance + " ";
                }
                if (strDrcr.ToUpper() == "CR")
                {
                    strSQL = strSQL + "GR_OPENING_CREDIT = GR_OPENING_CREDIT + " + dblOpeningBalance + ", ";
                    strSQL = strSQL + "GR_CLOSING_CREDIT = GR_CLOSING_CREDIT + " + dblOpeningBalance + " ";
                }
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strLedgerName + "' ";
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
                            strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID,strBranchName.Replace("'", "''")) + "', ";
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
                            strSQL = strSQL + "'" + strLedgerName + Utility.gstrGetBranchID(strDeComID,strBranchName.Replace("'", "''")) + "' ,";
                            strSQL = strSQL + "'" + Utility.gstrGetBranchID(strDeComID,strBranchName.Replace("'", "''")) + "',";
                            strSQL = strSQL + "'" + strLedgerName + "',";
                            strSQL = strSQL + " " + dblBranchAmount * lngMultiply + " ";
                            strSQL = strSQL + ")";

                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }

                //*************************************Bill Wise***************************************
                if (lngbillWise == 1)
                {
                    string strBranchID;
                    double dblAmount = 0;
                    long lngloop = 1;
                    string[] words = strBillwiseGrid.Split('~');
                    foreach (string bill in words)
                    {
                        string[] ooBill = bill.Split(',');

                        if (ooBill[0] != "")
                        {

                            dblAmount = Convert.ToDouble(ooBill[4]);
                            if (ooBill[5].ToString().ToUpper() == "DR")
                            {
                                dblAmount = dblAmount * -1;
                            }
                            else
                            {
                                dblAmount = dblAmount * 1;
                            }

                            strBranchID = Utility.gstrGetBranchID(strDeComID,ooBill[0].ToString());

                            strSQL = "INSERT INTO ACC_BILL_WISE(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,AGAINST_VOUCHER_NO,";
                            strSQL = strSQL + "COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
                            strSQL = strSQL + "BILL_WISE_POSITION,BILL_WISE_PREV_NEW,";
                            strSQL = strSQL + "LEDGER_NAME,BILL_WISE_AMOUNT,BILL_WISE_TOBY,";
                            strSQL = strSQL + "OPENING_DATE,BILL_WISE_DUE_DATE,BILL_WISE_IS_OPEN";
                            strSQL = strSQL + ") VALUES (";
                            strSQL = strSQL + "'" + strBranchID + "', ";
                            strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + strBranchID + ooBill[2] + " ',";
                            strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + strBranchID + ooBill[2] + " ',";
                            strSQL = strSQL + "'" + strBranchID + ooBill[3] + "',";//    'AGAINST_VOUCHER_NO
                            strSQL = strSQL + "0 ,";//                    ' COMP_VOUCHER_TYPE
                            strSQL = strSQL + "" + Utility.cvtSQLDateString(ooBill[1]) + ",";
                            strSQL = strSQL + "" + lngloop + " ,";
                            strSQL = strSQL + "0 ,";
                            strSQL = strSQL + "'" + vsstrLedgerName + "', ";
                            strSQL = strSQL + "" + dblAmount + ",";
                            strSQL = strSQL + "'" + ooBill[5] + "',";
                            if (ooBill[1] != "")
                            {
                                strSQL = strSQL + "" + Utility.cvtSQLDateString(ooBill[1]) + ",";
                                strSQL = strSQL + "" + Utility.cvtSQLDateString(ooBill[3]) + ",";
                            }
                            else
                            {
                                strSQL = strSQL + "'" + Utility.cvtSQLDateString(strFinancialForm) + "',";
                                strSQL = strSQL + "'" + Utility.cvtSQLDateString(strFinancialForm) + "',";
                            }
                            strSQL = strSQL + "1";
                            strSQL = strSQL + ")";

                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            lngloop += 1;
                        }
                    }
                }
                else
                {

                    if (dblOpeningBalance != 0)
                    {
                        if (Utility.gblnBranch)
                        {
                            long lngLedgerSerial;
                            string strBranchID = "";
                            lngLedgerSerial = Utility.mlngGetLedgerSerial(strDeComID, vsstrLedgerName);

                            string strDRCR = "";
                            double dblBranchAmount = 0;
                            string[] words = strBranchGrid.Split('~');
                            foreach (string branch in words)
                            {
                                string[] ooBranch = branch.Split(',');

                                if (ooBranch[0] != "")
                                {
                                    strBranchID = Utility.gstrGetBranchID(strDeComID, ooBranch[0].ToString());
                                    dblBranchAmount = Convert.ToDouble(ooBranch[1]);
                                    dblBranchAmount = dblBranchAmount * lngMultiply;
                                    if (dblBranchAmount < 0)
                                    {
                                        strDRCR = "Dr";
                                    }
                                    else
                                    {
                                        strDRCR = "Cr";
                                    }

                                    strSQL = "INSERT INTO ACC_BILL_WISE(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,AGAINST_VOUCHER_NO,";
                                    strSQL = strSQL + "COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
                                    strSQL = strSQL + "BILL_WISE_POSITION,BILL_WISE_PREV_NEW,";
                                    strSQL = strSQL + "LEDGER_NAME,BILL_WISE_AMOUNT,BILL_WISE_TOBY,";
                                    strSQL = strSQL + "BILL_WISE_IS_OPEN";
                                    strSQL = strSQL + ") VALUES (";
                                    strSQL = strSQL + "'" + strBranchID + "', ";
                                    strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + Utility.gstrBranchID + lngLedgerSerial.ToString() + " ',";
                                    strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + Utility.gstrBranchID + lngLedgerSerial.ToString() + " ',";
                                    strSQL = strSQL + "'" + strBranchID + lngLedgerSerial.ToString() + "',";//   'AGAINST_VOUCHER_NO
                                    strSQL = strSQL + "0 ,";//                    ' COMP_VOUCHER_TYPE
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(Utility.mGetCompanyCreateDate(strDeComID)) + ",";
                                    strSQL = strSQL + "1,";
                                    strSQL = strSQL + "0 ,";
                                    strSQL = strSQL + "'" + vsstrLedgerName + "', ";
                                    strSQL = strSQL + "" + dblBranchAmount + ",";
                                    strSQL = strSQL + "'" + strDRCR + "',";
                                    strSQL = strSQL + "1";
                                    strSQL = strSQL + ") ";


                                }
                            }

                            //mInsertBillWiseNoBranch strLedgerName, lngMultiply;
                        }
                        else
                        {
                            string strBranchID;
                            double dblAmount = 0;
                            long lngloop = 1;
                            string[] words = strBillwiseGrid.Split('~');
                            foreach (string bill in words)
                            {
                                string[] ooBill = bill.Split(',');

                                if (ooBill[0] != "")
                                {

                                    dblAmount = Convert.ToDouble(ooBill[4]);
                                    if (ooBill[5].ToString().ToUpper() == "DR")
                                    {
                                        dblAmount = dblAmount * -1;
                                    }
                                    else
                                    {
                                        dblAmount = dblAmount * 1;
                                    }

                                    strBranchID = Utility.gstrGetBranchID(strDeComID,ooBill[0].ToString());

                                    strSQL = "INSERT INTO ACC_BILL_WISE(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,AGAINST_VOUCHER_NO,";
                                    strSQL = strSQL + "COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
                                    strSQL = strSQL + "BILL_WISE_POSITION,BILL_WISE_PREV_NEW,";
                                    strSQL = strSQL + "LEDGER_NAME,BILL_WISE_AMOUNT,BILL_WISE_TOBY,";
                                    strSQL = strSQL + "OPENING_DATE,BILL_WISE_DUE_DATE,BILL_WISE_IS_OPEN";
                                    strSQL = strSQL + ") VALUES (";
                                    strSQL = strSQL + "'" + strBranchID + "', ";
                                    strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + strBranchID + ooBill[2] + " ',";
                                    strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + strBranchID + ooBill[2] + " ',";
                                    strSQL = strSQL + "'" + strBranchID + ooBill[1] + "',";//    'AGAINST_VOUCHER_NO
                                    strSQL = strSQL + "0 ,";//                    ' COMP_VOUCHER_TYPE
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(ooBill[2]) + ",";
                                    strSQL = strSQL + "" + lngloop + " ,";
                                    strSQL = strSQL + "0 ,";
                                    strSQL = strSQL + "'" + vsstrLedgerName + "', ";
                                    strSQL = strSQL + "" + dblAmount + ",";
                                    strSQL = strSQL + "'" + ooBill[5] + "',";
                                    if (ooBill[1] != "")
                                    {
                                        strSQL = strSQL + "" + Utility.cvtSQLDateString(ooBill[1]) + ",";
                                        strSQL = strSQL + "" + Utility.cvtSQLDateString(ooBill[3]) + ",";
                                    }
                                    else
                                    {
                                        strSQL = strSQL + "'" + Utility.gstrFinicialYearFrom + "',";
                                        strSQL = strSQL + "'" + Utility.gstrFinicialYearFrom + "',";
                                    }
                                    strSQL = strSQL + "1";
                                    strSQL = strSQL + ")";

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    lngloop += 1;
                                }
                            }

                        }
                    }

                }
                //*************************************Bill Wise


                cmdInsert.Transaction.Commit();
                return "1";
            }

        }


        public string mUpDateCustomerLedger(string strDeComID, string mstrOldLedger, string vstrBranchID, long mlngLedgerSerial, string vsstrLedgerName, string vstrParent, string strPriceLevel, 
                                            string strLedgerAddDate, string vstrEMail, string vstrFax, string vstrAddress1,string vstrAddress2, string vstrcity, 
                                            string vstrCountry, string vstrContractPer, string vstrPostal, string vstrPhone, string vstrComments, string vstrCurrency,
                                            string strBillWise, string strInactive, string strCostCenter, string strDrcr, double dblopnBalance,
                                            string strcostcenterGrid, string strBranchGrid, string strBillwiseGrid,
                                            double dblCreditLimit,
                                            double dblCreditPeriod, string strFinancialForm, string strResignDate, int intCommission, string strTerritorycode,
                                            string strTerritoryName, string strClass, int intBkash, string strCloseDate, string strPFLedger, string strHLLedger)
        {
            long lngGroupType = 0, lngLedgerGroup = 0, lngMultiply = 0, lngLedgerLevel = 0, lngCostCenter = 0, lngGrLevel = 0, lngCashFlowType = 0, lngManuFacType = 0, lngLedgerStatus = 0, lngbillWise = 0, lngPayroll = 0;
            string strSQL,strMerze, strPrimary = "", strGrOneDown = "", strLedgerName = "", strParent, strEMail, strFax, strVectorDrCr = "";
            double dblOpeningBalance = 0, dblOldOpening = 0;

            bool blnInsert = false;


            strLedgerName = vsstrLedgerName;
            if (strTerritorycode != "")
            {
                strMerze = strTerritorycode + "-" + strLedgerName + "-" + strTerritoryName;
            }
            else if (strTerritoryName != "")
            {
                strMerze = strLedgerName + "-" + strTerritoryName;
            }
            else
            {
                strMerze = strLedgerName;
            }
            strParent = vstrParent;
            strEMail = vstrEMail;
            strFax = vstrFax;
            if (strBillWise == "Yes")
            {
                lngbillWise = 2;
            }

            if (strInactive == "Yes")
            {
                lngLedgerStatus = 1;
            }
            else if (strInactive == "Close")
            {
                lngLedgerStatus = 2;
            }
            else
            {
                lngLedgerStatus = 0;
            }
            if (strCostCenter == "Yes")
            {
                lngCostCenter = 2;
            }

            else if (strCostCenter == "No")
            {
                lngCostCenter = 1;
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
                    strGrOneDown = (dr["GR_ONE_DOWN"].ToString());
                    lngLedgerLevel = long.Parse(dr["GR_LEVEL"].ToString())+1;
                    lngCashFlowType = long.Parse(dr["GR_CASH_FLOW_TYPE"].ToString());
                    lngManuFacType = long.Parse(dr["GR_MANUFAC_GROUP"].ToString());
                }

                dr.Close();

                strSQL = "SELECT LEDGER_OPENING_BALANCE FROM ACC_LEDGER WHERE LEDGER_NAME = '" + mstrOldLedger + "'";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblOldOpening = Convert.ToDouble(dr["LEDGER_OPENING_BALANCE"]);
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

                if (lngLedgerGroup == 0)
                {
                    lngLedgerGroup = (long)Utility.GR_GROUP_TYPE.grOTHER_LEDGER;

                }
                strSQL = "DELETE FROM ACC_BILL_WISE WHERE LEDGER_NAME = '" + mstrOldLedger + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_TYPE = 0 ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "DELETE FROM ACC_LEDGER_TO_GROUP WHERE LEDGER_NAME = '" + mstrOldLedger + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM ACC_STOCK_IN_HAND WHERE LEDGER_NAME = '" + mstrOldLedger + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM ACC_BRANCH_LEDGER_OPENING WHERE LEDGER_NAME = '" + mstrOldLedger + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE ACC_LEDGER ";
                strSQL = strSQL + "SET ";

                strSQL = strSQL + "LEDGER_NAME_MERZE = '" + strMerze.Replace("'","''") + "',";
                if (vstrBranchID != "")
                {
                    strSQL = strSQL + "BRANCH_ID = '" + vstrBranchID + "',";
                }
                strSQL = strSQL + "LEDGER_PRIMARY_GROUP = '" + strPrimary + "',";
                strSQL = strSQL + "LEDGER_PARENT_GROUP = '" + strParent + "',";
                strSQL = strSQL + "LEDGER_CASH_FLOW_TYPE = " + lngCashFlowType + ", ";
                strSQL = strSQL + "LEDGER_CURRENCY_SYMBOL = '" + vstrCurrency + "', ";
                strSQL = strSQL + "LEDGER_CREDIT_LIMIT = " + dblCreditLimit + ", ";
                strSQL = strSQL + "LEDGER_CREDIT_PERIOD = " + dblCreditPeriod + ", ";
                strSQL = strSQL + "LEDGER_OPENING_BALANCE = " + dblOpeningBalance + ", ";
                strSQL = strSQL + "LEDGER_CLOSING_BALANCE = LEDGER_CLOSING_BALANCE +" + (dblOpeningBalance - dblOldOpening) + ", ";
                strSQL = strSQL + "LEDGER_ADDRESS1 = '" + vstrAddress1 + "', ";
                strSQL = strSQL + "LEDGER_ADDRESS2 = '" + vstrAddress2 + "', ";
                strSQL = strSQL + "LEDGER_CITY = '" + vstrcity + "', ";
                strSQL = strSQL + "LEDGER_COUNTRY = '" + vstrCountry + "', ";
                strSQL = strSQL + "LEDGER_CONTACT = '" + vstrContractPer + "', ";
                strSQL = strSQL + "LEDGER_POSTAL = '" + vstrPostal + "', ";
                strSQL = strSQL + "LEDGER_PHONE = '" + vstrPhone + "', ";
                strSQL = strSQL + "LEDGER_FAX = '" + vstrFax + "', ";
                strSQL = strSQL + "LEDGER_EMAIL = '" + vstrEMail + "', ";
                strSQL = strSQL + "LEDGER_COMMENTS = '" + vstrComments + "', ";
                strSQL = strSQL + "LEDGER_BILL_WISE = " + lngbillWise + ", ";
                strSQL = strSQL + "LEDGER_NAME = '" + vsstrLedgerName + "', ";
                strSQL = strSQL + "LEDGER_STATUS = " + lngLedgerStatus + ",";
                strSQL = strSQL + "LEDGER_LEVEL = " + lngLedgerLevel + ",";
                strSQL = strSQL + "LEDGER_VECTOR = " + lngCostCenter + " ";
                if (strLedgerAddDate == "")
                {
                    strSQL = strSQL + ",LEDGER_ADD_DATE= " + Utility.cvtSQLDateString(DateTime.Today.ToString("dd/MM/yyyy")) + "";
                }

                else
                {
                    strSQL = strSQL + ",LEDGER_ADD_DATE= " + Utility.cvtSQLDateString(strLedgerAddDate) + " ";
                }

                if (strPriceLevel != "")
                {
                    strSQL = strSQL + ",LEDGER_PRICE_LABEL = '" + strPriceLevel + "' ";
                }
                if (strResignDate != "")
                {
                    strSQL = strSQL + ",LEDGER_RESIGN_DATE = " + Utility.cvtSQLDateString(strResignDate) + "";
                }
                strSQL = strSQL + ",LEDGER_COMMISSION = " + intCommission + " ";

                if (strTerritorycode != "")
                {
                    strSQL = strSQL + ",TERITORRY_CODE = '" + strTerritorycode.Replace("'","''")  + "'";
                }
                if (strTerritoryName != "")
                {
                    strSQL = strSQL + ",TERRITORRY_NAME = '" + strTerritoryName + "'";
                }

                strSQL = strSQL + ",LEDGER_CLASS = '" + strClass + "'";
                strSQL = strSQL + ",BKASH_STATUS = " + intBkash  + " ";

                if (strCloseDate != "")
                {
                    strSQL = strSQL + ",CLOSE_DATE = " + Utility.cvtSQLDateString(strCloseDate) + " ";
                }
                else
                {
                    strSQL = strSQL + ",CLOSE_DATE = Null ";
                }

                if (strPFLedger != "")
                {
                    strSQL = strSQL + ",PF_LEDGER_NAME= '" + strPFLedger.Replace("'", "''") + "'";
                }
                else
                {
                    strSQL = strSQL + ",PF_LEDGER_NAME = Null ";
                }

                if (strHLLedger != "")
                {
                    strSQL = strSQL + ",HL_LEDGER_NAME= '" + strHLLedger.Replace("'", "''") + "'";
                }
                else
                {
                    strSQL = strSQL + ",HL_LEDGER_NAME = Null ";
                }
             
             

                strSQL = strSQL + "WHERE LEDGER_SERIAL = " + mlngLedgerSerial + " ";

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
                        //lngGroupLavel = (long)dr1["GR_LEVEL"];
                        lngGrLevel = long.Parse(dr1["GR_LEVEL"].ToString())+1;
                    }
                    else
                    {
                        blnInsert = true;
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
                if (strDrcr.ToUpper() == "DR")
                {
                    strSQL = strSQL + "GR_OPENING_DEBIT = GR_OPENING_DEBIT + " + dblOpeningBalance + ", ";
                    strSQL = strSQL + "GR_CLOSING_DEBIT = GR_CLOSING_DEBIT + " + dblOpeningBalance + " ";
                }
                if (strDrcr.ToUpper() == "CR")
                {
                    strSQL = strSQL + "GR_OPENING_CREDIT = GR_OPENING_CREDIT + " + dblOpeningBalance + ", ";
                    strSQL = strSQL + "GR_CLOSING_CREDIT = GR_CLOSING_CREDIT + " + dblOpeningBalance + " ";
                }
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + strLedgerName + "' ";
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

                if (lngbillWise == 1)
                {
                    string strBranchID;
                    //strFinancialForm = Utility.gdteFinancialYearFrom;
                    double dblAmount = 0;
                    long lngloop = 1;
                    string[] words = strBillwiseGrid.Split('~');
                    foreach (string bill in words)
                    {
                        string[] ooBill = bill.Split(',');

                        if (ooBill[0] != "")
                        {

                            dblAmount = Convert.ToDouble(ooBill[4]);
                            if (ooBill[5].ToString().ToUpper() == "DR")
                            {
                                dblAmount = dblAmount * -1;
                            }
                            else
                            {
                                dblAmount = dblAmount * 1;
                            }

                            strBranchID = Utility.gstrGetBranchID(strDeComID, ooBill[0].ToString());

                            strSQL = "INSERT INTO ACC_BILL_WISE(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,AGAINST_VOUCHER_NO,";
                            strSQL = strSQL + "COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
                            strSQL = strSQL + "BILL_WISE_POSITION,BILL_WISE_PREV_NEW,";
                            strSQL = strSQL + "LEDGER_NAME,BILL_WISE_AMOUNT,BILL_WISE_TOBY,";
                            strSQL = strSQL + "OPENING_DATE,BILL_WISE_DUE_DATE,BILL_WISE_IS_OPEN";
                            strSQL = strSQL + ") VALUES (";
                            strSQL = strSQL + "'" + strBranchID + "', ";
                            strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + strBranchID + ooBill[2] + " ',";
                            strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + strBranchID + ooBill[2] + " ',";
                            strSQL = strSQL + "'" + strBranchID + ooBill[3] + "',";//    'AGAINST_VOUCHER_NO
                            strSQL = strSQL + "0 ,";//                    ' COMP_VOUCHER_TYPE
                            strSQL = strSQL + "" + Utility.cvtSQLDateString(ooBill[1]) + ",";
                            strSQL = strSQL + "" + lngloop + " ,";
                            strSQL = strSQL + "0 ,";
                            strSQL = strSQL + "'" + vsstrLedgerName + "', ";
                            strSQL = strSQL + "" + dblAmount + ",";
                            strSQL = strSQL + "'" + ooBill[5] + "',";
                            if (ooBill[1] != "")
                            {
                                strSQL = strSQL + "" + Utility.cvtSQLDateString(ooBill[1]) + ",";
                                strSQL = strSQL + "" + Utility.cvtSQLDateString(ooBill[3]) + ",";
                            }
                            else
                            {
                                strSQL = strSQL + "'" + Utility.cvtSQLDateString(strFinancialForm) + "',";
                                strSQL = strSQL + "'" + Utility.cvtSQLDateString(strFinancialForm) + "',";
                            }
                            strSQL = strSQL + "1";
                            strSQL = strSQL + ")";

                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            lngloop += 1;
                        }
                    }
                }
                else
                {

                    if (dblOpeningBalance != 0)
                    {
                        if (Utility.gblnBranch)
                        {
                            long lngLedgerSerial;
                            string strBranchID = "";
                            lngLedgerSerial = Utility.mlngGetLedgerSerial(strDeComID, vsstrLedgerName);

                            string strDRCR = "";
                            double dblBranchAmount = 0;
                            string[] words = strBranchGrid.Split('~');
                            foreach (string branch in words)
                            {
                                string[] ooBranch = branch.Split(',');

                                if (ooBranch[0] != "")
                                {
                                    strBranchID = Utility.gstrGetBranchID(strDeComID, ooBranch[0].ToString());
                                    dblBranchAmount = Convert.ToDouble(ooBranch[1]);
                                    dblBranchAmount = dblBranchAmount * lngMultiply;
                                    if (dblBranchAmount < 0)
                                    {
                                        strDRCR = "Dr";
                                    }
                                    else
                                    {
                                        strDRCR = "Cr";
                                    }

                                    strSQL = "INSERT INTO ACC_BILL_WISE(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,AGAINST_VOUCHER_NO,";
                                    strSQL = strSQL + "COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
                                    strSQL = strSQL + "BILL_WISE_POSITION,BILL_WISE_PREV_NEW,";
                                    strSQL = strSQL + "LEDGER_NAME,BILL_WISE_AMOUNT,BILL_WISE_TOBY,";
                                    strSQL = strSQL + "BILL_WISE_IS_OPEN";
                                    strSQL = strSQL + ") VALUES (";
                                    strSQL = strSQL + "'" + strBranchID + "', ";
                                    strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + Utility.gstrBranchID + lngLedgerSerial.ToString() + " ',";
                                    strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + Utility.gstrBranchID + lngLedgerSerial.ToString() + " ',";
                                    strSQL = strSQL + "'" + strBranchID + lngLedgerSerial.ToString() + "',";//   'AGAINST_VOUCHER_NO
                                    strSQL = strSQL + "0 ,";//                    ' COMP_VOUCHER_TYPE
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(Utility.mGetCompanyCreateDate(strDeComID)) + ",";
                                    strSQL = strSQL + "1,";
                                    strSQL = strSQL + "0 ,";
                                    strSQL = strSQL + "'" + vsstrLedgerName + "', ";
                                    strSQL = strSQL + "" + dblBranchAmount + ",";
                                    strSQL = strSQL + "'" + strDRCR + "',";
                                    strSQL = strSQL + "1";
                                    strSQL = strSQL + ") ";


                                }
                            }

                            //mInsertBillWiseNoBranch strLedgerName, lngMultiply;
                        }
                        else
                        {
                            string strBranchID;
                            double dblAmount = 0;
                            long lngloop = 1;
                            string[] words = strBillwiseGrid.Split('~');
                            foreach (string bill in words)
                            {
                                string[] ooBill = bill.Split(',');

                                if (ooBill[0] != "")
                                {

                                    dblAmount = Convert.ToDouble(ooBill[4]);
                                    if (ooBill[5].ToString().ToUpper() == "DR")
                                    {
                                        dblAmount = dblAmount * -1;
                                    }
                                    else
                                    {
                                        dblAmount = dblAmount * 1;
                                    }

                                    strBranchID = Utility.gstrGetBranchID(strDeComID, ooBill[0].ToString());

                                    strSQL = "INSERT INTO ACC_BILL_WISE(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,AGAINST_VOUCHER_NO,";
                                    strSQL = strSQL + "COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
                                    strSQL = strSQL + "BILL_WISE_POSITION,BILL_WISE_PREV_NEW,";
                                    strSQL = strSQL + "LEDGER_NAME,BILL_WISE_AMOUNT,BILL_WISE_TOBY,";
                                    strSQL = strSQL + "OPENING_DATE,BILL_WISE_DUE_DATE,BILL_WISE_IS_OPEN";
                                    strSQL = strSQL + ") VALUES (";
                                    strSQL = strSQL + "'" + strBranchID + "', ";
                                    strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + strBranchID + ooBill[2] + " ',";
                                    strSQL = strSQL + "'" + Utility.vtOPENING_BILLWISE_STR + strBranchID + ooBill[2] + " ',";
                                    strSQL = strSQL + "'" + strBranchID + ooBill[1] + "',";//    'AGAINST_VOUCHER_NO
                                    strSQL = strSQL + "0 ,";//                    ' COMP_VOUCHER_TYPE
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(ooBill[1]) + ",";
                                    strSQL = strSQL + "" + lngloop + " ,";
                                    strSQL = strSQL + "0 ,";
                                    strSQL = strSQL + "'" + vsstrLedgerName + "', ";
                                    strSQL = strSQL + "" + dblAmount + ",";
                                    strSQL = strSQL + "'" + ooBill[5] + "',";
                                    if (ooBill[1] != "")
                                    {
                                        strSQL = strSQL + "" + Utility.cvtSQLDateString(ooBill[1]) + ",";
                                        strSQL = strSQL + "" + Utility.cvtSQLDateString(ooBill[3]) + ",";
                                    }
                                    else
                                    {
                                        strSQL = strSQL + "'" + Utility.gstrFinicialYearFrom + "',";
                                        strSQL = strSQL + "'" + Utility.gstrFinicialYearFrom + "',";
                                    }
                                    strSQL = strSQL + "1";
                                    strSQL = strSQL + ")";

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    lngloop += 1;
                                }
                            }

                        }
                    }

                }

                strSQL = "UPDATE ACC_LEDGER SET LEDGER_REP_NAME='" + strLedgerName.Replace("'","''") + "' ";
                strSQL = strSQL + ", TERRITORRY_NAME = '" + strTerritoryName + "' ";
                strSQL = strSQL + "WHERE LEDGER_REP_NAME ='" + mstrOldLedger.Replace("'", "''") + "' ";
                //strSQL = strSQL + "AND LEDGER_GROUP=204";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "UPDATE INV_SALESREPSENTIVE SET MRR_NO='" + strLedgerName.Replace("'", "''") + "' ";
                strSQL = strSQL + "WHERE MRR_NO = '" + mstrOldLedger.Replace("'", "''") + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "UPDATE ACC_VOUCHER SET VOUCHER_REVERSE_LEDGER='" + strLedgerName.Replace("'", "''") + "' ";
                strSQL = strSQL + "WHERE VOUCHER_REVERSE_LEDGER = '" + mstrOldLedger.Replace("'", "''") + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "UPDATE ACC_VOUCHER SET REVERSE_LEDGER1='" + strLedgerName.Replace("'", "''") + "' ";
                strSQL = strSQL + "WHERE REVERSE_LEDGER1 = '" + mstrOldLedger.Replace("'", "''") + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "UPDATE USER_ONLILE_SECURITY SET COR_MOBILE_NO='" + vstrPhone.Replace("'", "''") + "' ";
                strSQL = strSQL + ",LEDGER_NAME = '" + strLedgerName.Replace("'", "''") + "' ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + mstrOldLedger.Replace("'", "''") + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Transaction.Commit();
                return "1";
            }

        }

        #region SampleClass

        public string mInsertSampleClass(string strDeComID, string vstrClassName, string strItems)
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
                    SqlDataReader dr;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    string[] words1 = strItems.Split('~');
                    foreach (string strSalesOrder in words1)
                    {
                        string[] ooCost1 = strSalesOrder.Split(',');
                        if (ooCost1[0] != "")
                        {
                            strSQL = "INSERT INTO SALES_SAMP_CLASS";
                            strSQL = strSQL + "(CLASS_NAME,ITEM_ID,QTY";
                            strSQL = strSQL + ") VALUES (";
                            strSQL = strSQL + "'" + vstrClassName + "','" + ooCost1[0] + "','" + ooCost1[1] + "'";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                    cmdInsert.Transaction.Commit();
                    return "1";
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
        //public List<ClassSetup> mSampleClassList()
        //{
        //    string strSQL;
        //    SqlDataReader drGetGroup;
        //    List<ClassSetup> oogrp = new List<ClassSetup>();
        //    strSQL = "select Class_Name,Item_ID,Qty from dbo.SALES_SAMP_CLASS;";
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();

        //        SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
        //        drGetGroup = cmd.ExecuteReader();
        //        while (drGetGroup.Read())
        //        {
        //            ClassSetup ogrp = new ClassSetup();
        //            ogrp.Qty = Convert.ToDouble(drGetGroup["Qty"].ToString());
        //            ogrp.ClassName = drGetGroup["Class_Name"].ToString();
        //            ogrp.ItemName = drGetGroup["Item_ID"].ToString();
        //            oogrp.Add(ogrp);
        //        }
        //        drGetGroup.Close();
        //        gcnMain.Dispose();
        //        return oogrp;

        //    }
        //}
        #endregion

        #region Transport
        public string mInsertTransport(string strDeComID, string vstrTransName)
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
                    SqlDataReader dr;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "INSERT INTO SALES_TRANSPORT";
                    strSQL = strSQL + "(NAME";
                    strSQL = strSQL + ") VALUES (";
                    strSQL = strSQL + "'" + vstrTransName + "'";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    return "1";
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

        //public List<TransAndDest> mTransportList()
        //{
        //    string strSQL;
        //    SqlDataReader drGetGroup;
        //    List<TransAndDest> oogrp = new List<TransAndDest>();
        //    strSQL = "select Name from dbo.SALES_TRANSPORT;";
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();

        //        SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
        //        drGetGroup = cmd.ExecuteReader();
        //        while (drGetGroup.Read())
        //        {
        //            TransAndDest ogrp = new TransAndDest();
        //            ogrp.Name = drGetGroup["Name"].ToString();
        //            oogrp.Add(ogrp);
        //        }
        //        drGetGroup.Close();
        //        gcnMain.Dispose();
        //        return oogrp;

        //    }
        //}
        #endregion

        public string mInsertDestination(string strDeComID, string vstrDestName)
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
                    SqlDataReader dr;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "INSERT INTO sales_destination";
                    strSQL = strSQL + "(NAME";
                    strSQL = strSQL + ") VALUES (";
                    strSQL = strSQL + "'" + vstrDestName + "'";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    return "1";
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
        //public List<TransAndDest> mDestinationList()
        //{
        //    string strSQL;
        //    SqlDataReader drGetGroup;
        //    List<TransAndDest> oogrp = new List<TransAndDest>();
        //    strSQL = "select Name from dbo.sales_destination;";
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();

        //        SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
        //        drGetGroup = cmd.ExecuteReader();
        //        while (drGetGroup.Read())
        //        {
        //            TransAndDest ogrp = new TransAndDest();
        //            ogrp.Name = drGetGroup["Name"].ToString();
        //            oogrp.Add(ogrp);
        //        }
        //        drGetGroup.Close();
        //        gcnMain.Dispose();
        //        return oogrp;

        //    }
        //}



    }
}
