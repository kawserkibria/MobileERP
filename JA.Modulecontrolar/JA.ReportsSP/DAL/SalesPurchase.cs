using Dutility;
using JA.ReportsSP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace JA.ReportsSP.DAL
{
    public class SalesPurchase
    {
        private string connstring;
        //= Utility.SQLConnstring();
        private string strSQL = "";
        public string gOpenComID(string strID)
        {
            Utility.Modules.Clear();
            Utility.ModuleAdd(strID);
            return strID;
        }

        #region "DisplayItemGroup"



        public List<RSalesPurchase> mDisplayItemGroup(string strDeComID, string vstrItemGroup, string vstrDate, string vstrTDate, int intMode)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<RSalesPurchase> oogrp = new List<RSalesPurchase>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            //level=1,Item=2,Group=3

            strSQL = "SELECT * FROM INV_SALES_PRICE INNER JOIN ";
            strSQL = strSQL + "INV_STOCKITEM ON INV_SALES_PRICE.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
            strSQL = strSQL + "INV_STOCKGROUP ON INV_STOCKITEM.STOCKGROUP_NAME = INV_STOCKGROUP.STOCKGROUP_NAME ";

            if (intMode == 1)
            {
                strSQL = strSQL + "WHERE  PRICE_LEVEL_NAME='" + vstrItemGroup + "' ";
                strSQL = strSQL + "and (INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE = " + Utility.cvtSQLDateString(vstrDate) + ")  AND (INV_SALES_PRICE.MODULE_STATUS = 0) ";
                strSQL = strSQL + "ORDER BY INV_SALES_PRICE.STOCKITEM_NAME, INV_SALES_PRICE.SALES_PRICE_SERIAL ";
            }
            if (intMode == 2)
            {
                strSQL = strSQL + "WHERE  INV_SALES_PRICE.STOCKITEM_NAME ='" + vstrItemGroup + "' ";
                strSQL = strSQL + "and(INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE BETWEEN " + Utility.cvtSQLDateString(vstrDate) + " AND " + Utility.cvtSQLDateString(vstrTDate) + ") AND (INV_SALES_PRICE.MODULE_STATUS = 0) ";
                strSQL = strSQL + "ORDER BY INV_SALES_PRICE.STOCKITEM_NAME, INV_SALES_PRICE.SALES_PRICE_SERIAL ";
            }

            if (intMode == 3)
            {
                strSQL = strSQL + "WHERE  (INV_STOCKGROUP.STOCKGROUP_PRIMARY = '" + vstrItemGroup + "') ";
                strSQL = strSQL + "and(INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE BETWEEN " + Utility.cvtSQLDateString(vstrDate) + " AND " + Utility.cvtSQLDateString(vstrTDate) + ") AND (INV_SALES_PRICE.MODULE_STATUS = 0)  ";
                strSQL = strSQL + "ORDER BY INV_SALES_PRICE.STOCKITEM_NAME,INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE, INV_SALES_PRICE.SALES_PRICE_SERIAL ";
            }
            if (intMode == 4)
            {
                strSQL = strSQL + "WHERE  INV_STOCKITEM.STOCKGROUP_NAME ='" + vstrItemGroup + "' ";
                strSQL = strSQL + "and(INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE BETWEEN " + Utility.cvtSQLDateString(vstrDate) + " AND " + Utility.cvtSQLDateString(vstrTDate) + ") AND (INV_SALES_PRICE.MODULE_STATUS = 0) ";
                strSQL = strSQL + "ORDER BY INV_SALES_PRICE.STOCKITEM_NAME, INV_SALES_PRICE.SALES_PRICE_SERIAL ";
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

                    RSalesPurchase ogrp = new RSalesPurchase();
                    ogrp.dblFROM_QTY = Convert.ToDouble(drGetGroup["FROM_QTY"].ToString());
                    ogrp.dblTO_QTY = Convert.ToDouble(drGetGroup["TO_QTY"].ToString());
                    ogrp.strRate = Convert.ToDouble(drGetGroup["SALES_PRICE_AMOUNT"].ToString());
                    ogrp.strDiscountAmount = Convert.ToDouble(drGetGroup["PERCENT_DISCOUNT"].ToString());
                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.strStockGroupPrimary = drGetGroup["PRICE_LEVEL_NAME"].ToString();
                    ogrp.strEffDate = Convert.ToDateTime(drGetGroup["SALES_PRICE_EFFECTIVE_DATE"]).ToString("dd-MM-yyyy");
                    ogrp.strStockGroupName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    ogrp.strLedgerGroupParent = drGetGroup["STOCKGROUP_PARENT"].ToString();
                    if (drGetGroup["PERCENT_DISCOUNT"].ToString() != "")
                    {
                        ogrp.strDiscountAmount = Convert.ToDouble(drGetGroup["PERCENT_DISCOUNT"].ToString());
                    }
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        #endregion
        #region MpoList
        public List<RSalesPurchase> mGetMpoListNew(string strDeComID, string strFdate, string strTDate, string strBranchId, string strStrtring, int intmode)
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
                //1=Group,3=gropParent,2=primary
                if (strStrtring != null)
                {
                    if (Utility.Left(strStrtring, 1).ToUpper() == "D" || Utility.Left(strStrtring, 1).ToUpper() == "R" || Utility.Left(strStrtring, 1).ToUpper() == "F" || Utility.Left(strStrtring, 1).ToUpper() == "A") 
                    {
                        intmode = 2;
                    }
                    else if (strStrtring.Contains("Zone") == true)
                    {
                        intmode = 4;
                    }
                    else if (strStrtring == "Sundry Debtors")
                    {
                        intmode = 0;
                    }
                    else
                    {
                        intmode = 4;
                    }
                }

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();
                strSQL = "SELECT v.GR_PARENT AS zone, v.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area, l.LEDGER_NAME, (ISNULL(l.LEDGER_PHONE, '') + ',' + ISNULL(l.LEDGER_CONTACT, '')) AS mobile, l.TERITORRY_CODE, l.TERRITORRY_NAME, ";
                strSQL = strSQL + "(CASE WHEN l.TERITORRY_CODE <> '' THEN 1 END) AS CT, l.LEDGER_CLASS ";
                strSQL = strSQL + "FROM ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER L  where l.LEDGER_PARENT_GROUP =v.GR_NAME ";
                strSQL = strSQL + "AND  (l.BRANCH_ID = '" + strBranchId + "') AND (l.INSERT_DATE BETWEEN  (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ") ) ";
                if (intmode == 1)
                {
                    strSQL = strSQL + "AND (l.LEDGER_PARENT_GROUP = '" + strStrtring + "') ";
                }
                else if (intmode == 2)
                {
                    strSQL = strSQL + "AND (v.GR_NAME  = '" + strStrtring + "') ";
                }
                else if (intmode == 3)
                {
                    strSQL = strSQL + "AND (l.LEDGER_NAME   = '" + strStrtring + "') ";
                }
                else if (intmode == 4)
                {

                    strSQL = strSQL + "AND (v.GR_PARENT = '" + strStrtring + "') ";
                }
                strSQL = strSQL + "ORDER BY v.GR_PARENT,v.GR_NAME,l.LEDGER_PARENT_GROUP,l.TERITORRY_CODE ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strLedgerGroupParent = dr["zone"].ToString();
                    oLedg.strLedgerGroupPrimary = dr["Division"].ToString();
                    oLedg.strGroupAMFM = dr["area"].ToString();
                    oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oLedg.strPhoneNumber = dr["mobile"].ToString();
                    oLedg.strTerritory = dr["TERRITORRY_NAME"].ToString();
                    oLedg.strTerritoryCode = dr["TERITORRY_CODE"].ToString();
                    oLedg.strPowerClass = dr["LEDGER_CLASS"].ToString();
                    if (dr["CT"].ToString() != "")
                    {
                        oLedg.intRCount = Convert.ToDouble(dr["CT"].ToString());
                    }
                    else
                    {
                        oLedg.intRCount = 0;
                    }
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strLedgerGroupParent = "";
                    oLedg.strLedgerGroupPrimary = "";
                    oLedg.strGroupAMFM = "";
                    oLedg.strLedgerName = "";
                    oLedg.strPhoneNumber = "";
                    oLedg.strTerritory = "";
                    oLedg.strTerritoryCode = "";
                    oLedg.strPowerClass = "";
                    oLedg.intRCount = 0;
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }

        #endregion
        #region ItemwiseSales

        public List<RSalesPurchase> mGetItemWiseSales(string strDeComID, string strFdate, string strTdate, string strItemName, int intItemGroup)
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();

                strSQL = "SELECT STOCKITEM_NAME, STOCKGROUP_NAME, STOCKITEM_BASEUNITS, SALES_PRICE_AMOUNT, SALES_PRICE_EFFECTIVE_DATE, FROM_QTY, TO_QTY, PRICE_LEVEL_NAME, PERCENT_DISCOUNT ";
                strSQL = strSQL + "FROM  INV_SALES_PRICE_RPT AS INV_SALES_PRICE_RPT ";
                strSQL = strSQL + "WHERE (SALES_PRICE_EFFECTIVE_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTdate) + ")) ";

                if (intItemGroup == 1)
                {
                    strSQL = strSQL + "AND (STOCKITEM_NAME = '" + strItemName + "')";
                }
                if (intItemGroup == 2)
                {
                    strSQL = strSQL + "AND (STOCKGROUP_NAME = '" + strItemName + "')";
                }
                strSQL = strSQL + "ORDER BY PRICE_LEVEL_NAME, STOCKGROUP_NAME, STOCKITEM_NAME ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    RSalesPurchase oLedg = new RSalesPurchase();

                    oLedg.strPriceLevel = dr["PRICE_LEVEL_NAME"].ToString();
                    oLedg.strBILL_UOM = dr["STOCKITEM_BASEUNITS"].ToString();
                    oLedg.dblFROM_QTY = Convert.ToDouble(dr["FROM_QTY"].ToString());
                    oLedg.dblTO_QTY = Convert.ToDouble(dr["TO_QTY"].ToString());
                    oLedg.strItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.strEffDate = dr["SALES_PRICE_EFFECTIVE_DATE"].ToString();
                    oLedg.strDiscountAmount = Convert.ToDouble(dr["PERCENT_DISCOUNT"].ToString());
                    oLedg.strRate = Convert.ToDouble(dr["SALES_PRICE_AMOUNT"].ToString());

                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region SalesStatement


        public List<RSalesPurchase> mGetSalesStatement(string strDeComID, string strFdate, string strTDate, string strBranchId, string strString, int intmode, 
                                                        bool blngAccessControl, string strUserName, double dblValue, string strValOption, string strReportOption,int intStatus)
        {
            //1=intmode
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();

                if (strReportOption != "")
                {
                    if (strReportOption == "MPO")
                    {
                        strSQL = "SELECT  G.ZONE,G.DIVISION ,G.AREA,G.TERITORRY_CODE,G.TERRITORRY_NAME,G.LEDGER_NAME_MERZE,  isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) AS Bill_amount ";
                    }
                    else if (strReportOption == "AM")
                    {
                        strSQL = "SELECT  G.ZONE,G.DIVISION ,G.AREA,  isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) AS Bill_amount ";
                    }
                    else if (strReportOption == "DSM")
                    {
                        strSQL = "SELECT  G.ZONE,G.DIVISION , isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) AS Bill_amount ";
                    }
                    else if (strReportOption == "ZONE")
                    {
                        strSQL = "SELECT  G.ZONE,  isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) AS Bill_amount ";
                    }
                    else
                    {
                        strSQL = "SELECT  G.ZONE,G.DIVISION ,G.AREA,G.TERITORRY_CODE,G.TERRITORRY_NAME,G.LEDGER_NAME_MERZE,  isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) AS Bill_amount ";
                    }

                    strSQL = strSQL + " FROM ACC_LEDGER_Z_D_A G ,ACC_VOUCHER v,ACC_LEDGER L ";
                    strSQL = strSQL + "WHERE L.LEDGER_NAME =G.LEDGER_NAME AND V.LEDGER_NAME =L.LEDGER_NAME  ";
                    strSQL = strSQL + "AND (V.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                    strSQL = strSQL + "AND V.COMP_VOUCHER_TYPE=16 AND L.BRANCH_ID ='" + strBranchId + "' ";
                    if (intStatus >0 )
                    {
                        if (intStatus == 1)
                        {
                            strSQL = strSQL + " AND G.LEDGER_STATUS in (1,2) ";
                        }
                        else
                        {
                            strSQL = strSQL + " AND G.LEDGER_STATUS in (0,1,2) ";
                        }
                    }
                    else if (intStatus == 0)
                    {
                        strSQL = strSQL + " AND G.LEDGER_STATUS in (0) ";
                    }
                    if (strReportOption == "MPO")
                    {
                        if (blngAccessControl == true)
                        {
                            strSQL = strSQL + " AND  G.Division in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + strUserName + "')";
                        }
                        strSQL = strSQL + "group by   G.ZONE,G.DIVISION,G.AREA,G.TERITORRY_CODE,G.TERRITORRY_NAME,G.LEDGER_NAME_MERZE ";
                        if (dblValue != 0)
                        {
                            if (strValOption == "<")
                            {
                                strSQL = strSQL + "Having   isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) < " + dblValue + " ";
                            }
                            else
                            {
                                strSQL = strSQL + "Having   isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) > " + dblValue + " ";
                            }
                        }
                       
                        strSQL = strSQL + "order by G.TERITORRY_CODE,G.TERRITORRY_NAME,G.LEDGER_NAME_MERZE ";
                    }
                    else if (strReportOption == "AM")
                    {
                        if (blngAccessControl == true)
                        {
                            strSQL = strSQL + " AND  G.Division in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + strUserName + "')";
                        }
                        strSQL = strSQL + "group by   G.ZONE,G.DIVISION,G.AREA ";
                        if (dblValue != 0)
                        {
                            if (strValOption == "<")
                            {
                                strSQL = strSQL + "Having   isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) < " + dblValue + " ";
                            }
                            else
                            {
                                strSQL = strSQL + "Having   isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) > " + dblValue + " ";
                            }
                        }
                     
                        strSQL = strSQL + "order by  G.ZONE,G.DIVISION ,G.AREA ";
                    }
                    else if (strReportOption == "DSM")
                    {
                        if (blngAccessControl == true)
                        {
                            strSQL = strSQL + " AND  G.Division in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + strUserName + "')";
                        }
                        strSQL = strSQL + "group by   G.ZONE,G.DIVISION ";
                        if (dblValue != 0)
                        {
                            if (strValOption == "<")
                            {
                                strSQL = strSQL + "Having   isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) < " + dblValue + " ";
                            }
                            else
                            {
                                strSQL = strSQL + "Having   isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) > " + dblValue + " ";
                            }
                        }
                        strSQL = strSQL + "order by  G.ZONE,G.DIVISION ";
                    }
                    else if (strReportOption == "ZONE")
                    {
                        if (blngAccessControl == true)
                        {
                            strSQL = strSQL + " AND  G.Division in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + strUserName + "')";
                        }
                        strSQL = strSQL + "group by   G.ZONE ";
                        if (dblValue != 0)
                        {
                            if (strValOption == "<")
                            {
                                strSQL = strSQL + "Having   isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) < " + dblValue + " ";
                            }
                            else
                            {
                                strSQL = strSQL + "Having  isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) > " + dblValue + " ";
                            }
                        }
                       
                        strSQL = strSQL + "order by  G.ZONE ";
                    }
                    else
                    {
                        if (blngAccessControl == true)
                        {
                            strSQL = strSQL + " AND  G.Division in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + strUserName + "')";
                        }
                        strSQL = strSQL + "group by   G.ZONE,G.DIVISION,G.AREA,G.TERITORRY_CODE,G.TERRITORRY_NAME,G.LEDGER_NAME_MERZE ";
                        if (dblValue != 0)
                        {
                            if (strValOption == "<")
                            {
                                strSQL = strSQL + "Having  isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) < " + dblValue + " ";
                            }
                            else
                            {
                                strSQL = strSQL + "Having   isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) > " + dblValue + " ";
                            }
                        }
                       
                        strSQL = strSQL + "order by  G.ZONE,G.DIVISION ,G.AREA,G.TERITORRY_CODE,G.TERRITORRY_NAME,G.LEDGER_NAME_MERZE ";
                    }
                }
                else
                {
                    //strSQL = "SELECT  G.ZONE,G.DIVISION ,G.AREA,G.TERITORRY_CODE,G.TERRITORRY_NAME,G.LEDGER_NAME_MERZE,  SUM(V.COMP_VOUCHER_NET_AMOUNT) AS Bill_amount ";
                    //strSQL = strSQL + "FROM   ACC_COMPANY_VOUCHER V, ACC_LEDGER_Z_D_A G ";
                    //strSQL = strSQL + "WHERE(COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                    //strSQL = strSQL + "AND (V.COMP_VOUCHER_TYPE = 16) and V.LEDGER_NAME= G.LEDGER_NAME  AND (V.COMP_VOUCHER_TYPE = 16) and  v.BRANCH_ID='" + strBranchId + "' ";
                    strSQL = strSQL + "SELECT  ZDA.ZONE , ZDA.DIVISION , ZDA.AREA  ,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE,isnull(SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) Bill_amount ";
                    strSQL = strSQL + " FROM ACC_LEDGER_Z_D_A ZDA ,ACC_VOUCHER v,ACC_LEDGER L ";
                    strSQL = strSQL + "WHERE L.LEDGER_NAME =ZDA.LEDGER_NAME AND V.LEDGER_NAME =L.LEDGER_NAME  ";
                    strSQL = strSQL + "AND (V.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                    strSQL = strSQL + "AND V.COMP_VOUCHER_TYPE=16 AND L.BRANCH_ID ='" + strBranchId + "' ";


                    if (intStatus > 0)
                    {
                        if (intStatus == 1)
                        {
                            strSQL = strSQL + " AND ZDA.LEDGER_STATUS in (1,2) ";
                        }
                        else
                        {
                            strSQL = strSQL + " AND ZDA.LEDGER_STATUS in (0,1,2) ";
                        }
                    }
                    else if (intStatus == 0)
                    {
                        strSQL = strSQL + " AND ZDA.LEDGER_STATUS in (0) ";
                    }
                    if (blngAccessControl == true)
                    {
                        strSQL = strSQL + " AND  ZDA.Division in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + strUserName + "')";
                    }
                    //strSQL = strSQL + "group by   G.ZONE,G.DIVISION,G.AREA,G.TERITORRY_CODE,G.TERRITORRY_NAME,G.LEDGER_NAME_MERZE ";
                    strSQL = strSQL + " GROUP BY ZDA.ZONE, ZDA.DIVISION , ZDA.AREA ,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE ";
                    if (dblValue != 0)
                    {
                        if (strValOption == "<")
                        {
                            strSQL = strSQL + "Having   SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT) < " + dblValue + " ";
                        }
                        else
                        {
                            strSQL = strSQL + "Having  SUM(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT) > " + dblValue + " ";
                        }
                    }

                    strSQL = strSQL + "order by  ZDA.ZONE, ZDA.DIVISION , ZDA.AREA ,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE ";

                }
            
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    if (strReportOption == "MPO")
                    {
                        oLedg.strLedgerCode = dr["TERITORRY_CODE"].ToString();
                        oLedg.strLedgerName = dr["LEDGER_NAME_MERZE"].ToString();
                        oLedg.strTerritory = dr["TERRITORRY_NAME"].ToString();
                        oLedg.dblBillAmount = Convert.ToDouble(dr["Bill_amount"].ToString());
                        oLedg.strLedgerGroupParent = dr["ZONE"].ToString();
                        oLedg.strLedgerGroupPrimary = dr["DIVISION"].ToString();
                        oLedg.strGroupAMFM = dr["AREA"].ToString();
                    }
                    else if (strReportOption == "AM")
                    {
                        oLedg.dblBillAmount = Convert.ToDouble(dr["Bill_amount"].ToString());
                        oLedg.strLedgerGroupParent = dr["ZONE"].ToString();
                        oLedg.strLedgerGroupPrimary = dr["DIVISION"].ToString();
                        oLedg.strGroupAMFM = dr["AREA"].ToString();
                    }
                    else if (strReportOption == "DSM")
                    {

                        oLedg.dblBillAmount = Convert.ToDouble(dr["Bill_amount"].ToString());
                        oLedg.strLedgerGroupParent = dr["ZONE"].ToString();
                        oLedg.strLedgerGroupPrimary = dr["DIVISION"].ToString();

                    }
                    else if (strReportOption == "ZONE")
                    {
                        oLedg.dblBillAmount = Convert.ToDouble(dr["Bill_amount"].ToString());
                        oLedg.strLedgerGroupParent = dr["ZONE"].ToString();

                    }
                    else
                    {

                        oLedg.strLedgerCode = dr["TERITORRY_CODE"].ToString();
                        oLedg.strLedgerName = dr["LEDGER_NAME_MERZE"].ToString();
                        oLedg.strTerritory = dr["TERRITORRY_NAME"].ToString();
                        oLedg.dblBillAmount = Convert.ToDouble(dr["Bill_amount"].ToString());
                        oLedg.strLedgerGroupParent = dr["ZONE"].ToString();
                        oLedg.strLedgerGroupPrimary = dr["DIVISION"].ToString();
                        oLedg.strGroupAMFM = dr["AREA"].ToString();

                    }

                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }

        public List<RSalesPurchase> mGetSalesStatementIndividual(string strDeComID, string strFdate, string strTDate, string strBranchId, string strLedgername)
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();
                strSQL = "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT, ACC_COMPANY_VOUCHER.ORDER_NO, ";
                strSQL = strSQL + " ACC_BRANCH.BRANCH_NAME, ACC_LEDGER.TERITORRY_CODE, ACC_LEDGER.TERRITORRY_NAME, ACC_COMPANY_VOUCHER.LEDGER_NAME, ISNULL(Customer.LEDGER_CODE, '') AS LEDGER_CODE,  ISNULL(ACC_COMPANY_VOUCHER.SALES_REP, '') + '-' + isnull(Customer.HOMOEO_HALL,'') + '-' + ISNULL(Customer.LEDGER_ADDRESS1, '') + ' ' + ISNULL(Customer.LEDGER_ADDRESS2, '') AS Customeradddress, ";
                strSQL = strSQL + "ACC_COMPANY_VOUCHER.PREPARED_DATE FROM ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER INNER JOIN ";
                strSQL = strSQL + "ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID INNER JOIN ";
                strSQL = strSQL + "ACC_LEDGER ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME AND ACC_BRANCH.BRANCH_ID = ACC_LEDGER.BRANCH_ID LEFT OUTER JOIN ";
                strSQL = strSQL + "(SELECT LEDGER_CODE, LEDGER_NAME, LEDGER_ADDRESS1, LEDGER_ADDRESS2 ,HOMOEO_HALL ";
                strSQL = strSQL + "FROM  ACC_LEDGER AS ACC_LEDGER_1 ";
                strSQL = strSQL + "WHERE (LEDGER_GROUP = '204')) AS Customer ON ACC_COMPANY_VOUCHER.SALES_REP = Customer.LEDGER_NAME ";
                strSQL = strSQL + "WHERE (ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + "))";
                strSQL = strSQL + "AND (ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = 16)  ";
                if (strBranchId != "")
                {
                    strSQL = strSQL + "AND(ACC_COMPANY_VOUCHER.BRANCH_ID = '" + strBranchId + "') ";
                }
                if (strLedgername != "")
                {
                    strSQL = strSQL + "AND (ACC_COMPANY_VOUCHER.LEDGER_NAME = '" + strLedgername + "') ";
                }
                strSQL = strSQL + "ORDER BY ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strRefNo = dr["COMP_REF_NO"].ToString();
                    oLedg.strInvDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    oLedg.strOrderNo = dr["ORDER_NO"].ToString();
                    oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oLedg.strTerritoryCode = dr["TERITORRY_CODE"].ToString();
                    oLedg.strTerritory = dr["TERRITORRY_NAME"].ToString();
                    oLedg.strAddress1 = dr["Customeradddress"].ToString();
                    oLedg.strStockGroupName = dr["LEDGER_CODE"].ToString();
                    oLedg.dblBillAmount = Convert.ToDouble(dr["COMP_VOUCHER_NET_AMOUNT"].ToString());
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }

        #endregion
        #region Product Sales
        //public List<RSalesPurchase> mGetProductsales(string strDeComID, string strFdate, string strTDate, string strBranchId, string Strsting,
        //                                            string Strsting2, string strSelction, int intmode, bool blngAccessControl, string strUserName)
        //{
        //    ///intmode  STOCKITEM = 4, COMP_REF_NO=3 , SalesReport=5
        //    string strSQL = null;
        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();
        //        SqlDataReader dr;

        //        List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();
        //        strSQL = "SELECT ";

        //        if (intmode <= 4)
        //        {
        //            strSQL = strSQL + "Ledger.LEDGER_NAME_MERZE,Ledger.zone, Ledger.Division, Ledger.area, Ledger.TERRITORRY_NAME, Ledger.LEDGER_NAME, Ledger.TERITORRY_CODE, ACC_BILL_TRAN.STOCKGROUP_NAME, ACC_BILL_TRAN.STOCKITEM_NAME, ";
        //            strSQL = strSQL + "ACC_BILL_TRAN.BILL_UOM, ACC_BILL_TRAN.BILL_PER, SUM(ACC_BILL_TRAN.BILL_QUANTITY) AS BillQty, SUM(ACC_BILL_TRAN.BILL_QUANTITY_BONUS) AS BillBonusQty, SUM(ACC_BILL_TRAN.BILL_AMOUNT) ";
        //            strSQL = strSQL + "AS BillAmount, INV_STOCKITEM.STOCKCATEGORY_NAME ";
        //            strSQL = strSQL + "FROM  ACC_BILL_TRAN INNER JOIN ";
        //            strSQL = strSQL + "ACC_COMPANY_VOUCHER ON ACC_BILL_TRAN.COMP_REF_NO = ACC_COMPANY_VOUCHER.COMP_REF_NO AND ACC_BILL_TRAN.COMP_VOUCHER_TYPE = ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE AND ";
        //            strSQL = strSQL + "ACC_BILL_TRAN.BRANCH_ID = ACC_COMPANY_VOUCHER.BRANCH_ID INNER JOIN ";
        //            strSQL = strSQL + "(SELECT  g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area, l.LEDGER_NAME, l.TERITORRY_CODE, l.TERRITORRY_NAME,l.LEDGER_NAME_MERZE ";
        //            strSQL = strSQL + "FROM  ACC_LEDGERGROUP AS g INNER JOIN ";
        //            strSQL = strSQL + "ACC_LEDGERGROUP_CATEGORY_VIEW AS v ON g.GR_NAME = v.GR_PARENT INNER JOIN ";
        //            strSQL = strSQL + "ACC_LEDGER AS l ON v.GR_NAME = l.LEDGER_PARENT_GROUP ";
        //            strSQL = strSQL + "WHERE (l.BRANCH_ID = '" + strBranchId + "')) AS Ledger ON ACC_COMPANY_VOUCHER.LEDGER_NAME = Ledger.LEDGER_NAME INNER JOIN ";
        //            strSQL = strSQL + "INV_STOCKITEM ON ACC_BILL_TRAN.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME ";

        //            if (Strsting2 != "")
        //            {
        //                if (intmode == 4)
        //                {
        //                    strSQL = strSQL + "AND ACC_BILL_TRAN.STOCKITEM_NAME IN (" + Strsting2 + ") ";
        //                }
        //                else
        //                {
        //                    strSQL = strSQL + "AND ACC_BILL_TRAN.COMP_REF_NO IN (" + Strsting2 + ") ";
        //                }
        //            }
        //            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.PREPARED_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")  ";
        //            if (strSelction != null)
        //            {
        //                strSQL = strSQL + "AND Ledger.LEDGER_NAME = '" + strSelction + "' ";
        //            }
        //            if (blngAccessControl == true)
        //            {
        //                strSQL = strSQL + " AND  Division in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + strUserName + "')";
        //            }

        //            strSQL = strSQL + " AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE =16 ";
        //            strSQL = strSQL + "GROUP BY Ledger.zone, Ledger.Division, Ledger.area,Ledger.LEDGER_NAME_MERZE, Ledger.TERRITORRY_NAME, Ledger.LEDGER_NAME, Ledger.TERITORRY_CODE, ACC_BILL_TRAN.STOCKGROUP_NAME, ACC_BILL_TRAN.STOCKITEM_NAME, ";
        //            strSQL = strSQL + "ACC_BILL_TRAN.BILL_UOM, ACC_BILL_TRAN.BILL_PER, INV_STOCKITEM.STOCKCATEGORY_NAME ";
        //            //strSQL = strSQL + "order by Ledger.TERITORRY_CODE,Ledger.zone, Ledger.Division, Ledger.area ";
        //            strSQL = strSQL + "order by Ledger.TERITORRY_CODE ";

        //            SqlCommand cmdInsert = new SqlCommand();
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.Connection = gcnMain;
        //            dr = cmdInsert.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                RSalesPurchase oLedg = new RSalesPurchase();
        //                oLedg.strLedgerGroupParent = dr["zone"].ToString();
        //                oLedg.strLedgerGroupPrimary = dr["Division"].ToString();
        //                oLedg.strLedgerGroupParent = dr["zone"].ToString();
        //                oLedg.strGroupAMFM = dr["area"].ToString();
        //                oLedg.strLedgerGroupPrimary = dr["Division"].ToString();
        //                oLedg.strLedgerGroupParent = dr["zone"].ToString();
        //                oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
        //                oLedg.strTerritoryCode = dr["TERITORRY_CODE"].ToString();
        //                oLedg.strTerritory = dr["TERRITORRY_NAME"].ToString();
        //                oLedg.strGroupAMFM = dr["area"].ToString();
        //                oLedg.strLedgerGroupPrimary = dr["Division"].ToString();
        //                oLedg.strLedgerGroupParent = dr["zone"].ToString();
        //                oLedg.strItemName = dr["STOCKITEM_NAME"].ToString();
        //                oLedg.strStockGroupName = dr["STOCKGROUP_NAME"].ToString();
        //                oLedg.dblBilQty = Convert.ToDouble(dr["BillQty"].ToString());
        //                oLedg.dblFROM_QTY = Convert.ToDouble(dr["BillBonusQty"].ToString());
        //                oLedg.strBILL_Per = dr["STOCKCATEGORY_NAME"].ToString();
        //                oLedg.dblBillAmount = Convert.ToDouble(dr["BillAmount"].ToString());
        //                oLedg.strLedgerNameMerze = dr["LEDGER_NAME_MERZE"].ToString();
                        
        //                ooAccLedger.Add(oLedg);

        //            }
        //            if (!dr.HasRows)
        //            {
        //                RSalesPurchase oLedg = new RSalesPurchase();
        //                oLedg.strLedgerGroupParent = "";
        //                oLedg.strLedgerGroupPrimary = "";
        //                oLedg.strLedgerGroupParent = "";
        //                oLedg.strGroupAMFM = "";
        //                oLedg.strLedgerGroupPrimary = "";
        //                oLedg.strLedgerGroupParent = "";
        //                oLedg.strLedgerName = "";
        //                oLedg.strTerritoryCode = "";
        //                oLedg.strTerritory = "";
        //                oLedg.strGroupAMFM = "";
        //                oLedg.strLedgerGroupPrimary = "";
        //                oLedg.strLedgerGroupParent = "";
        //                oLedg.strItemName = "";
        //                oLedg.strStockGroupName = "";
        //                oLedg.dblBilQty = 0;
        //                oLedg.dblBonusQty = 0;
        //                oLedg.strBILL_Per = "";
        //                oLedg.dblBillAmount = 0;
        //                ooAccLedger.Add(oLedg);
        //            }
        //            dr.Close();
        //            gcnMain.Close();
        //            return ooAccLedger;
        //        }

        //        if (intmode == 5)
        //        {
        //            strSQL = "SELECT C.COMP_REF_NO  FROM ACC_COMPANY_VOUCHER C ";
        //            strSQL = strSQL + "WHERE (C.LEDGER_NAME = '" + strSelction + "') and  c.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
        //            strSQL = strSQL + "AND c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")  ";
        //        }
        //        SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
        //        dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            RSalesPurchase oLedg = new RSalesPurchase();
        //            {
        //                oLedg.strRefNo = dr["COMP_REF_NO"].ToString();
        //                ooAccLedger.Add(oLedg);
        //            }
        //        }
        //        dr.Close();
        //        gcnMain.Close();
        //        cmd.Dispose();
        //        return ooAccLedger;
        //    }
        //}
        #endregion
        #region "Sales Challan"
        public List<RSalesPurchase> mGetSalesChalan(string strDeComID, string strFdate, string strTDate, string strBranchId, string strString, int intmode)
        {

            string strSQL = null, strAgstRefNo;

            strAgstRefNo = Utility.mGetAgstRefNo(strDeComID, "");
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();

                strSQL = "SELECT DISTINCT ";
                strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_REF_NO, ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DESPATCH_THRU, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DESTINATION, ";
                strSQL = strSQL + "(CASE WHEN ACC_COMPANY_VOUCHER.COMP_VOUCHER_TERM_OF_PAYMENTS IS NULL THEN 0 ELSE ACC_COMPANY_VOUCHER.COMP_VOUCHER_TERM_OF_PAYMENTS END) ";
                strSQL = strSQL + "AS COMP_VOUCHER_TERM_OF_PAYMENTS, ACC_COMPANY_VOUCHER.COMP_VOUCHER_PROCESS_AMOUNT, ACC_COMPANY_VOUCHER.CRT_QTY, ACC_COMPANY_VOUCHER.BOX_QTY, ";
                strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DUE_DATE, ACC_COMPANY_VOUCHER.COMP_OTHERS, ACC_COMPANY_VOUCHER.TRANSPORT_NAME, ";
                strSQL = strSQL + "ACC_LEDGER.LEDGER_NAME_MERZE as Ledger_Name, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE AS ChalanDate, AGST_REF_NO_VIEW.VOUCHER_JOIN_FOREIGN_REF, AGST_REF_NO_VIEW.COMP_VOUCHER_DATE,ACC_BRANCH.BRANCH_NAME ";
                strSQL = strSQL + "FROM  ACC_LEDGER INNER JOIN ";
                strSQL = strSQL + "ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER ON ACC_LEDGER.LEDGER_NAME = ACC_COMPANY_VOUCHER.LEDGER_NAME INNER JOIN ";
                strSQL = strSQL + "ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID LEFT OUTER JOIN ";
                strSQL = strSQL + "AGST_REF_NO_VIEW ON ACC_COMPANY_VOUCHER.COMP_REF_NO = AGST_REF_NO_VIEW.VOUCHER_JOIN_PRIMARY_REF ";
                strSQL = strSQL + "WHERE (ACC_COMPANY_VOUCHER.BRANCH_ID = '" + strBranchId + "') AND (ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = 15) AND (ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                if (strString != "")
                {
                    strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_NAME = '" + strString + "')";
                }
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strLedgerName = dr["Ledger_Name"].ToString();
                    oLedg.strCheNo = dr["COMP_REF_NO"].ToString();
                    oLedg.strRefNo = dr["VOUCHER_JOIN_FOREIGN_REF"].ToString();
                    if (dr["COMP_VOUCHER_DATE"].ToString() != "")
                    {
                        oLedg.strvouchearDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        oLedg.strvouchearDate = "";
                    }
                    oLedg.strAddress1 = dr["TRANSPORT_NAME"].ToString();
                    oLedg.strAddress2 = dr["COMP_VOUCHER_DESTINATION"].ToString();
                    if (dr["COMP_VOUCHER_DATE"].ToString() != "")
                    {
                        oLedg.strTDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        oLedg.strTDate = "";
                    }
                    oLedg.dblDiscountAmount = Convert.ToDouble(dr["COMP_VOUCHER_TERM_OF_PAYMENTS"].ToString());
                    oLedg.dblSalQty1 = Convert.ToDouble(dr["COMP_VOUCHER_PROCESS_AMOUNT"].ToString());
                    oLedg.dblSalQty2 = Convert.ToDouble(dr["CRT_QTY"].ToString());
                    oLedg.dblSalQty3 = Convert.ToDouble(dr["BOX_QTY"].ToString());
                    oLedg.strEmail = dr["COMP_VOUCHER_NARRATION"].ToString();
                    oLedg.strVDate = Convert.ToDateTime(dr["COMP_VOUCHER_DUE_DATE"]).ToString("dd-MM-yyyy");
                    oLedg.strBranchName = "Branch Name :" + dr["BRANCH_NAME"].ToString();
                    oLedg.StrSing = dr["COMP_OTHERS"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strLedgerName = "";
                    oLedg.strCheNo = "";
                    oLedg.strRefNo = "";
                    oLedg.strvouchearDate = "";
                    oLedg.strAddress1 = "";
                    oLedg.strAddress2 = "";
                    oLedg.strTDate = "";
                    oLedg.dblDiscountAmount = 0;
                    oLedg.dblSalQty1 = 0;
                    oLedg.dblSalQty2 = 0;
                    oLedg.dblSalQty3 = 0;
                    oLedg.strEmail = "";
                    oLedg.strVDate = "";
                    oLedg.strBranchName = "";
                    oLedg.StrSing = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }

        #endregion
        #region  Chalan Pending.
        public List<RSalesPurchase> mGetChalanPending(string strDeComID, string strFdate, string strTDate, string strString, int intmode)
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
                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();
                strSQL = "SELECT  ACC_COMPANY_VOUCHER.COMP_REF_NO, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ISNULL(ACC_LEDGER.TERITORRY_CODE, '') + '-' + ISNULL(ACC_COMPANY_VOUCHER.LEDGER_NAME, '') ";
                strSQL = strSQL + "+ '-' + ISNULL(ACC_LEDGER.TERRITORRY_NAME, '') AS LEDGER_NAME ";
                strSQL = strSQL + "FROM  ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER INNER JOIN ";
                strSQL = strSQL + "ACC_LEDGER ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE (ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) AND (ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = 16) AND ";
                strSQL = strSQL + "(ACC_COMPANY_VOUCHER.COMP_VOUCHER_STATUS = 0) ";
                if (strString != "")
                {
                    strSQL = strSQL + "AND (ACC_COMPANY_VOUCHER.LEDGER_NAME = '" + strString + "') ";
                }
                strSQL = strSQL + "ORDER BY LEDGER_NAME, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oLedg.strRefNo = dr["COMP_REF_NO"].ToString();
                    oLedg.strvouchearDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strLedgerName = "";
                    oLedg.strCheNo = "";
                    oLedg.strvouchearDate = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }

        #endregion
        #region Product Short Summary
        public List<RProductSales> mGetProductShortSummary(string strDeComID, string strFdate, string strTDate)
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

                List<RProductSales> ooAccLedger = new List<RProductSales>();
                strSQL = "SELECT  ACC_BILL_TRAN.BILL_RATE, ACC_BILL_TRAN.SHORT_QTY, INV_STOCKITEM.STOCKGROUP_NAME, INV_SALES_ITEM_PRICE_VIEW.SALES_PRICE_AMOUNT ";
                strSQL = strSQL + "FROM  ACC_BILL_TRAN AS ACC_BILL_TRAN INNER JOIN ";
                strSQL = strSQL + "INV_STOCKITEM AS INV_STOCKITEM ON ACC_BILL_TRAN.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
                strSQL = strSQL + "INV_SALES_ITEM_PRICE_VIEW AS INV_SALES_ITEM_PRICE_VIEW ON INV_STOCKITEM.STOCKITEM_NAME = INV_SALES_ITEM_PRICE_VIEW.STOCKITEM_NAME ";
                strSQL = strSQL + "WHERE (ACC_BILL_TRAN.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) AND (ACC_BILL_TRAN.SHORT_QTY <> 0) AND ";
                strSQL = strSQL + "(ACC_BILL_TRAN.COMP_VOUCHER_TYPE = 16) ";
                strSQL = strSQL + "ORDER BY INV_STOCKITEM.STOCKGROUP_NAME ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RProductSales oLedg = new RProductSales();

                    oLedg.strStockGroupName = dr["STOCKGROUP_NAME"].ToString();
                    oLedg.DblShortValue = Convert.ToDouble(dr["SALES_PRICE_AMOUNT"].ToString());
                    oLedg.DblBillRate = Convert.ToDouble(dr["BILL_RATE"].ToString());
                    oLedg.DblShortQty = Convert.ToDouble(dr["SHORT_QTY"].ToString());
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RProductSales oLedg = new RProductSales();

                    oLedg.strStockGroupName = "";
                    oLedg.DblShortValue = 0;
                    oLedg.DblBillRate = 0;
                    oLedg.DblShortQty = 0;
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region "ProductShortDetails"
        public List<RProductSales> mGetProductShortDetails(string strDeComID, string strFdate, string strTDate, string strStockGroupName, int intmode)
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

                List<RProductSales> ooAccLedger = new List<RProductSales>();


                strSQL = "SELECT ACC_BILL_TRAN.STOCKITEM_NAME, ACC_BILL_TRAN.SHORT_QTY, SUBSTRING(ACC_COMPANY_VOUCHER.COMP_REF_NO, 7, 30) AS COMP_REF_NO , ACC_COMPANY_VOUCHER.LEDGER_NAME, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ";
                strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_NAME  , ACC_LEDGER.LEDGER_NAME_MERZE ";
                strSQL = strSQL + "FROM INV_STOCKITEM AS INV_STOCKITEM INNER JOIN ";
                strSQL = strSQL + "ACC_BILL_TRAN AS ACC_BILL_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = ACC_BILL_TRAN.STOCKITEM_NAME INNER JOIN ";
                strSQL = strSQL + "ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER ON ACC_BILL_TRAN.COMP_REF_NO = ACC_COMPANY_VOUCHER.COMP_REF_NO INNER JOIN ";
                strSQL = strSQL + "INV_STOCKGROUP ON INV_STOCKITEM.STOCKGROUP_NAME = INV_STOCKGROUP.STOCKGROUP_NAME   INNER JOIN  ACC_LEDGER ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE (ACC_BILL_TRAN.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) AND (ACC_BILL_TRAN.COMP_VOUCHER_TYPE = 16) AND ";
                strSQL = strSQL + "(ACC_BILL_TRAN.SHORT_QTY <> 0) ";
                if (strStockGroupName != null)
                {
                    if (intmode == 1)
                    {
                        strSQL = strSQL + "AND (INV_STOCKITEM.STOCKGROUP_NAME = '" + strStockGroupName + "') ";
                    }
                    else
                    {
                        strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_NAME= '" + strStockGroupName + "') ";

                    }
                }


                strSQL = strSQL + "ORDER BY INV_STOCKITEM.STOCKGROUP_NAME, ACC_BILL_TRAN.STOCKITEM_NAME, INV_STOCKITEM.STOCKITEM_ALIAS ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    RProductSales oLedg = new RProductSales();

                    oLedg.strStockGroupName = dr["STOCKGROUP_NAME"].ToString();
                    oLedg.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.DblShortQty = Convert.ToDouble(dr["SHORT_QTY"].ToString());
                    oLedg.strLedgername = dr["LEDGER_NAME_MERZE"].ToString();
                    oLedg.strRefNo = dr["COMP_REF_NO"].ToString();
                    oLedg.strVoucheDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");


                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region Sales Target statement
        public List<RProductSales> mGetSalesTargetStatement(string strDeComID, string strFdate, string strTDate, string strBranchId, string strLedgername)
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
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                strSQL = "ALTER VIEW TARGET_DETAIL_2_VIEW1 AS ";
                strSQL = strSQL + " SELECT ACC_COMPANY_VOUCHER.LEDGER_NAME,INV_STOCKITEM.STOCKGROUP_NAME, ACC_BILL_TRAN.STOCKITEM_NAME,";
                strSQL = strSQL + "INV_STOCKITEM.STOCKCATEGORY_NAME, SUM(ACC_BILL_TRAN.BILL_QUANTITY)  AS BILL_QUANTITY,SUM(BILL_QUANTITY_BONUS) AS BONUS ";
                strSQL = strSQL + "FROM INV_STOCKITEM INNER JOIN ACC_BILL_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = ACC_BILL_TRAN.STOCKITEM_NAME INNER JOIN ";
                strSQL = strSQL + "ACC_COMPANY_VOUCHER ON ACC_BILL_TRAN.COMP_REF_NO = ACC_COMPANY_VOUCHER.COMP_REF_NO  ";
                strSQL = strSQL + "WHERE ACC_BILL_TRAN.COMP_VOUCHER_DATE BETWEEN ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + " AND ";
                strSQL = strSQL + Utility.cvtSQLDateString(strTDate);
                strSQL = strSQL + "AND ACC_BILL_TRAN.COMP_VOUCHER_TYPE = 16  ";
                strSQL = strSQL + "GROUP BY ACC_COMPANY_VOUCHER.LEDGER_NAME,INV_STOCKITEM.STOCKGROUP_NAME, INV_STOCKITEM.STOCKCATEGORY_NAME,";
                strSQL = strSQL + "ACC_BILL_TRAN.STOCKITEM_NAME";
                cmd.CommandText = strSQL;
                cmd.ExecuteNonQuery();

                List<RProductSales> ooAccLedger = new List<RProductSales>();

                strSQL = "SELECT  TARGET_DETAIL_2_VIEW.STOCK_GROUP_NAME, TARGET_DETAIL_2_VIEW.STOCKITEM_NAME, TARGET_DETAIL_2_VIEW.STOCKCATEGORY_NAME, TARGET_DETAIL_2_VIEW.TARGET_QTY, ";
                strSQL = strSQL + "TARGET_DETAIL_3_VIEW1.BILL_QUANTITY, TARGET_DETAIL_3_VIEW1.BONUS, TARGET_DETAIL_4_VIEW1.BILL_QUANTITY_P, TARGET_DETAIL_4_VIEW1.BONUS_P, tb1.zone, tb1.Division, tb1.area, ";
                strSQL = strSQL + "ISNULL(tb1.TERITORRY_CODE, '') + '-' + ISNULL(tb1.LEDGER_NAME, '') + '-' + ISNULL(tb1.TERRITORRY_NAME, '') AS Ledger_Name ";
                strSQL = strSQL + "FROM  TARGET_DETAIL_2_VIEW AS TARGET_DETAIL_2_VIEW INNER JOIN ";
                strSQL = strSQL + "ACC_LEDGER AS ACC_LEDGER ON TARGET_DETAIL_2_VIEW.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME INNER JOIN ";
                strSQL = strSQL + "(SELECT  g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area, l.LEDGER_NAME, l.TERITORRY_CODE, l.TERRITORRY_NAME ";
                strSQL = strSQL + "FROM ACC_LEDGERGROUP AS g INNER JOIN ";
                strSQL = strSQL + "ACC_LEDGERGROUP_CATEGORY_VIEW AS v ON g.GR_NAME = v.GR_PARENT INNER JOIN ";
                strSQL = strSQL + "ACC_LEDGER AS l ON v.GR_NAME = l.LEDGER_PARENT_GROUP) AS tb1 ON ACC_LEDGER.LEDGER_NAME = tb1.LEDGER_NAME LEFT OUTER JOIN ";
                strSQL = strSQL + "TARGET_DETAIL_4_VIEW1 AS TARGET_DETAIL_4_VIEW1 ON TARGET_DETAIL_2_VIEW.LEDGER_NAME = TARGET_DETAIL_4_VIEW1.LEDGER_NAME AND ";
                strSQL = strSQL + "TARGET_DETAIL_2_VIEW.STOCK_GROUP_NAME = TARGET_DETAIL_4_VIEW1.STOCKGROUP_NAME AND ";
                strSQL = strSQL + "TARGET_DETAIL_2_VIEW.STOCKCATEGORY_NAME = TARGET_DETAIL_4_VIEW1.STOCKCATEGORY_NAME LEFT OUTER JOIN ";
                strSQL = strSQL + "TARGET_DETAIL_3_VIEW1 AS TARGET_DETAIL_3_VIEW1 ON TARGET_DETAIL_2_VIEW.LEDGER_NAME = TARGET_DETAIL_3_VIEW1.LEDGER_NAME AND ";
                strSQL = strSQL + "TARGET_DETAIL_2_VIEW.STOCK_GROUP_NAME = TARGET_DETAIL_3_VIEW1.STOCKGROUP_NAME AND TARGET_DETAIL_2_VIEW.STOCKITEM_NAME = TARGET_DETAIL_3_VIEW1.STOCKITEM_NAME ";
                strSQL = strSQL + "WHERE (TARGET_DETAIL_2_VIEW.TARGET_QTY > 0) AND (TARGET_DETAIL_2_VIEW.TARGET_QTY <> 0) ";
                if (strLedgername != "")
                {
                    strSQL = strSQL + "AND (TARGET_DETAIL_2_VIEW.LEDGER_NAME = '" + strLedgername + "') ";
                }
                strSQL = strSQL + "ORDER BY TARGET_DETAIL_2_VIEW.LEDGER_NAME, TARGET_DETAIL_2_VIEW.STOCK_GROUP_NAME, TARGET_DETAIL_2_VIEW.STOCKITEM_NAME ";
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strLedgerGroupPrimary = dr["zone"].ToString();
                    oLedg.strLedgerGroupParent = dr["Division"].ToString();
                    oLedg.strLedgerGroupName = dr["area"].ToString();
                    oLedg.strLedgername = dr["Ledger_Name"].ToString();
                    oLedg.strStockGroupName = dr["STOCK_GROUP_NAME"].ToString();
                    oLedg.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.strStockCategoryName = dr["STOCKCATEGORY_NAME"].ToString();
                    oLedg.DblBillQty = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());
                    oLedg.DblBillP = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());
                    oLedg.DblBillQtyBonus = Convert.ToDouble(dr["BONUS"].ToString());
                    oLedg.DblBonusP = Convert.ToDouble(dr["BILL_QUANTITY_P"].ToString());
                    oLedg.DblShortQty = Convert.ToDouble(dr["BONUS_P"].ToString());
                    oLedg.intTargetQty = Convert.ToDouble(dr["TARGET_QTY"].ToString());
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strLedgerGroupPrimary = "";
                    oLedg.strLedgerGroupParent = "";
                    oLedg.strLedgerGroupName = "";
                    oLedg.strLedgername = "";
                    oLedg.strStockGroupName = "";
                    oLedg.strStockItemName = "";
                    oLedg.strStockCategoryName = "";
                    oLedg.DblBillQty = 0;
                    oLedg.DblBillP = 0;
                    oLedg.DblBillQtyBonus = 0;
                    oLedg.DblBonusP = 0;
                    oLedg.DblShortQty = 0;
                    oLedg.intTargetQty = 0;
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region Sales  statement Indvidual
        public List<RProductSales> mGetSalesStatementIndividuall(string strDeComID, string strFdate, string strTDate, string strLedgername)
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

                List<RProductSales> ooAccLedger = new List<RProductSales>();

                strSQL = "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT, ACC_COMPANY_VOUCHER.ORDER_NO, ";
                strSQL = strSQL + "ACC_LEDGER.LEDGER_NAME, ACC_LEDGER.LEDGER_ADDRESS1, ACC_LEDGER.LEDGER_ADDRESS2, ACC_LEDGER.LEDGER_CITY, USER_PRIVILEGES_BRANCH_VIEW.BRANCH_NAME ";
                strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER INNER JOIN ";
                strSQL = strSQL + "USER_PRIVILEGES_BRANCH_VIEW AS USER_PRIVILEGES_BRANCH_VIEW ON ACC_COMPANY_VOUCHER.BRANCH_ID = USER_PRIVILEGES_BRANCH_VIEW.BRANCH_ID INNER JOIN ";
                strSQL = strSQL + "ACC_LEDGER AS ACC_LEDGER ON ACC_COMPANY_VOUCHER.SALES_REP = ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE(ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) AND (USER_PRIVILEGES_BRANCH_VIEW.USER_LOGIN_NAME = 'admin') AND ";
                strSQL = strSQL + "(ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = 16) AND (ACC_COMPANY_VOUCHER.LEDGER_NAME = '" + strLedgername + "') ";
                strSQL = strSQL + "ORDER BY ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, USER_PRIVILEGES_BRANCH_VIEW.BRANCH_NAME ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    RProductSales oLedg = new RProductSales();


                    oLedg.strRefNo = dr["COMP_REF_NO"].ToString();
                    oLedg.strVoucheDate = dr["COMP_VOUCHER_DATE"].ToString();
                    oLedg.strOrderNo = dr["ORDER_NO"].ToString();
                    oLedg.strLedgername = dr["LEDGER_NAME"].ToString();
                    oLedg.strAddress1 = dr["LEDGER_ADDRESS1"].ToString();
                    oLedg.strAddress2 = dr["LEDGER_ADDRESS2"].ToString();
                    oLedg.strLederCity = dr["LEDGER_CITY"].ToString();
                    oLedg.strBranchName = dr["BRANCH_NAME"].ToString();
                    oLedg.DblVNetAmt = Convert.ToDouble(dr["COMP_VOUCHER_NET_AMOUNT"].ToString());
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region Product Wise analysis
        public List<RSalesPurchase> mGetParty_Wise_ItemwiseSumm_All_Indivi_PurInv(string strDeComID, string strFDate, string strTDate, string strLedgername)
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();

                strSQL = "SELECT COMP_VOUCHER_DATE, COMP_REF_NO, LEDGER_NAME, STOCKITEM_NAME, BILL_UOM, BILL_QUANTITY, BILL_RATE, BILL_NET_AMOUNT, VOUCHER_CURRENCY_SYMBOL ";
                strSQL = strSQL + "FROM ACC_COMP_BILL_TRAN_QRY AS ACC_COMP_BILL_TRAN_QRY ";
                strSQL = strSQL + "WHERE (COMP_VOUCHER_DATE BETWEEN CONVERT(datetime, '08-10-2017', 103) AND CONVERT(datetime, '08-10-2018', 103)) AND (COMP_VOUCHER_TYPE = 33) ";
                if (strLedgername != "")
                {
                    strSQL = strSQL + "AND (LEDGER_NAME IN ('001-Jalal Uddin-Natore Sadar')) ";
                }

                strSQL = strSQL + "ORDER BY LEDGER_NAME, STOCKITEM_NAME, COMP_VOUCHER_DATE ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strvouchearDate = dr["COMP_VOUCHER_DATE"].ToString();
                    oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oLedg.strItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.dblBilQty = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());
                    oLedg.strRate = Convert.ToDouble(dr["BILL_RATE"].ToString());
                    oLedg.dblBillAmount = Convert.ToDouble(dr["BILL_NET_AMOUNT"].ToString());
                    //oLedg.strItemName = dr["VOUCHER_CURRENCY_SYMBOL"].ToString();


                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }

        #endregion
        #region Price List
        public List<RSalesPurchase> mGetPricelistReport(string strDeComID, string strStockItemName)
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();
                strSQL = "SELECT STOCKITEM_NAME, STOCKGROUP_NAME, STOCKITEM_PRIMARY_GROUP, SALES_PRICE_AMOUNT, SALES_PRICE_EFFECTIVE_DATE ";
                strSQL = strSQL + "FROM INV_SALES_PRICE_RPT AS INV_SALES_PRICE_RPT ";
                if (strStockItemName != "")
                {
                    strSQL = strSQL + "WHERE (STOCKITEM_NAME = 'ff') ";
                }
                strSQL = strSQL + "ORDER BY STOCKGROUP_NAME, STOCKITEM_NAME ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.strStockGroupName = dr["STOCKGROUP_NAME"].ToString();
                    oLedg.strStockGroupPrimary = dr["STOCKITEM_PRIMARY_GROUP"].ToString();
                    oLedg.dblBillAmount = Convert.ToDouble(dr["SALES_PRICE_AMOUNT"].ToString());
                    oLedg.strEffDate = dr["SALES_PRICE_EFFECTIVE_DATE"].ToString();

                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }

        #endregion
        #region Payables
        public List<RSalesPurchase> mGetPayablesReport(string strDeComID, string strFDate, string strTDate, string strLedgername)
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();

                strSQL = "SELECT SALES_BILLWISE_QRY.REF_NO, SALES_BILLWISE_QRY.COMP_VOUCHER_TYPE, SALES_BILLWISE_QRY.COMP_VOUCHER_DATE, SALES_BILLWISE_QRY.LEDGER_NAME, SALES_BILLWISE_QRY.BILL_WISE_AMOUNT, ";
                strSQL = strSQL + "SALES_BILLWISE_QRY.LEDGER_PARENT_GROUP, SALES_BILLWISE_QRY.AGAINST_VOUCHER_NO, SALES_BILLWISE_QRY.BILL_WISE_DUE_DATE, ACC_BRANCH.BRANCH_NAME ";
                strSQL = strSQL + "FROM SALES_BILLWISE_QRY AS SALES_BILLWISE_QRY INNER JOIN ";
                strSQL = strSQL + "ACC_BRANCH AS ACC_BRANCH ON SALES_BILLWISE_QRY.BRANCH_ID = ACC_BRANCH.BRANCH_ID ";
                strSQL = strSQL + "WHERE(SALES_BILLWISE_QRY.COMP_VOUCHER_DATE <= CONVERT(datetime, '31-10-2018', 103)) ";
                if (strLedgername != "")
                {
                    strSQL = strSQL + "AND (SALES_BILLWISE_QRY.LEDGER_NAME = '008-Humayan Kabir-Ullahpara')  ";
                }
                strSQL = strSQL + " AND(SALES_BILLWISE_QRY.LEDGER_GROUP = 203) ";
                strSQL = strSQL + "ORDER BY SALES_BILLWISE_QRY.LEDGER_PARENT_GROUP, SALES_BILLWISE_QRY.LEDGER_NAME, SALES_BILLWISE_QRY.AGAINST_VOUCHER_NO, SALES_BILLWISE_QRY.BILL_WISE_DUE_DATE, ";
                strSQL = strSQL + "SALES_BILLWISE_QRY.COMP_VOUCHER_TYPE DESC ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strRefNo = dr["REF_NO"].ToString();
                    oLedg.dblVtype = Convert.ToDouble(dr["COMP_VOUCHER_TYPE"].ToString());
                    oLedg.strVDate = dr["COMP_VOUCHER_DATE"].ToString();
                    oLedg.strRefNo = dr["LEDGER_NAME"].ToString();
                    oLedg.dblBillAmount = Convert.ToDouble(dr["BILL_WISE_AMOUNT"].ToString());
                    oLedg.strLedgerGroupParent = dr["LEDGER_PARENT_GROUP"].ToString();
                    oLedg.strvouchearNo = dr["AGAINST_VOUCHER_NO"].ToString();
                    oLedg.dblBillAmount = Convert.ToDouble(dr["BILL_NET_AMOUNT"].ToString());
                    oLedg.strDueDate = dr["BILL_WISE_DUE_DATE"].ToString();
                    oLedg.strBranchName = dr["BRANCH_NAME"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }

        #endregion
        #region Target Sales Statement Yearly
        public List<RSalesPurchase> mGetTargetSalesStatementYearly(string strDeComID, string strBranchId, string strString)
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();
                strSQL = "SELECT  STOCKGROUP_NAME, STOCKCATEGORY_NAME, STOCKITEM_NAME, TAR_QTY_1, SAL_QTY_1, TAR_QTY_2, SAL_QTY_2, TAR_QTY_3, SAL_QTY_3, TAR_QTY_4, SAL_QTY_4, TAR_QTY_5, SAL_QTY_5, TAR_QTY_6, ";
                strSQL = strSQL + "SAL_QTY_6, TAR_QTY_7, SAL_QTY_7, TAR_QTY_8, SAL_QTY_8, TAR_QTY_9, SAL_QTY_9, TAR_QTY_10, SAL_QTY_10, TAR_QTY_11, SAL_QTY_11, TAR_QTY_12, SAL_QTY_12 ";
                strSQL = strSQL + "FROM  SAL_TARGET_STATEMENT_YEARLY_VIEW AS SAL_TARGET_STATEMENT_YEARLY_VIEW ";
                strSQL = strSQL + "ORDER BY STOCKGROUP_NAME, STOCKITEM_NAME ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strStockGroupName = dr["STOCKGROUP_NAME"].ToString();
                    oLedg.strStockGroupPrimary = dr["STOCKCATEGORY_NAME"].ToString();
                    oLedg.strItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.dblTarQty1 = Convert.ToDouble(dr["TAR_QTY_1"].ToString());
                    oLedg.dblSalQty1 = Convert.ToDouble(dr["SAL_QTY_1"].ToString());
                    oLedg.dblTarQty2 = Convert.ToDouble(dr["TAR_QTY_2"].ToString());
                    oLedg.dblSalQty2 = Convert.ToDouble(dr["SAL_QTY_2"].ToString());
                    oLedg.dblTarQty3 = Convert.ToDouble(dr["TAR_QTY_3"].ToString());
                    oLedg.dblSalQty3 = Convert.ToDouble(dr["SAL_QTY_3"].ToString());
                    oLedg.dblTarQty4 = Convert.ToDouble(dr["TAR_QTY_4"].ToString());
                    oLedg.dblSalQty4 = Convert.ToDouble(dr["SAL_QTY_4"].ToString());
                    oLedg.dblTarQty5 = Convert.ToDouble(dr["TAR_QTY_5"].ToString());
                    oLedg.dblSalQty5 = Convert.ToDouble(dr["SAL_QTY_5"].ToString());
                    oLedg.dblTarQty6 = Convert.ToDouble(dr["TAR_QTY_6"].ToString());
                    oLedg.dblSalQty6 = Convert.ToDouble(dr["SAL_QTY_6"].ToString());
                    oLedg.dblTarQty7 = Convert.ToDouble(dr["TAR_QTY_7"].ToString());
                    oLedg.dblSalQty7 = Convert.ToDouble(dr["SAL_QTY_7"].ToString());
                    oLedg.dblTarQty8 = Convert.ToDouble(dr["TAR_QTY_8"].ToString());
                    oLedg.dblSalQty8 = Convert.ToDouble(dr["SAL_QTY_8"].ToString());
                    oLedg.dblTarQty9 = Convert.ToDouble(dr["TAR_QTY_9"].ToString());
                    oLedg.dblSalQty9 = Convert.ToDouble(dr["SAL_QTY_9"].ToString());
                    oLedg.dblTarQty10 = Convert.ToDouble(dr["TAR_QTY_10"].ToString());
                    oLedg.dblSalQty10 = Convert.ToDouble(dr["SAL_QTY_10"].ToString());
                    oLedg.dblTarQty11 = Convert.ToDouble(dr["TAR_QTY_11"].ToString());
                    oLedg.dblSalQty11 = Convert.ToDouble(dr["SAL_QTY_11"].ToString());
                    oLedg.dblTarQty12 = Convert.ToDouble(dr["TAR_QTY_12"].ToString());
                    oLedg.dblSalQty12 = Convert.ToDouble(dr["SAL_QTY_12"].ToString());

                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strStockGroupName = "";
                    oLedg.strStockGroupPrimary = "";
                    oLedg.strItemName = "";
                    oLedg.dblTarQty1 = 0;
                    oLedg.dblSalQty1 = 0;
                    oLedg.dblTarQty2 = 0;
                    oLedg.dblSalQty2 = 0;
                    oLedg.dblTarQty3 = 0;
                    oLedg.dblSalQty3 = 0;
                    oLedg.dblTarQty4 = 0;
                    oLedg.dblSalQty4 = 0;
                    oLedg.dblTarQty5 = 0;
                    oLedg.dblSalQty5 = 0;
                    oLedg.dblTarQty6 = 0;
                    oLedg.dblSalQty6 = 0;
                    oLedg.dblTarQty7 = 0;
                    oLedg.dblSalQty7 = 0;
                    oLedg.dblTarQty8 = 0;
                    oLedg.dblSalQty8 = 0;
                    oLedg.dblTarQty9 = 0;
                    oLedg.dblSalQty9 = 0;
                    oLedg.dblTarQty10 = 0;
                    oLedg.dblSalQty10 = 0;
                    oLedg.dblTarQty11 = 0;
                    oLedg.dblSalQty11 = 0;
                    oLedg.dblTarQty12 = 0;
                    oLedg.dblSalQty12 = 0;

                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }

        #endregion
        #region Party Wise Sales Statement
        public List<RProductSales> mGetLedgerlistnew(string strDeComID, string strBranchId, string strSelction, int intMode)
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

                List<RProductSales> ooAccLedger = new List<RProductSales>();

                if (strSelction == "Purchase")
                {
                    if (intMode == 1)
                    {
                        strSQL = "SELECT LEDGER_NAME FROM  ACC_LEDGER WHERE (LEDGER_GROUP = 203)ORDER BY LEDGER_NAME ";
                    }
                    if (intMode == 3)
                    {
                        strSQL = "SELECT STOCKITEM_NAME as LEDGER_NAME FROM INV_STOCKITEM WHERE (STOCKITEM_PRIMARY_GROUP <> 'Finished Goods') ORDER BY STOCKITEM_NAME";
                    }

                }
                else
                {
                    if (intMode == 2)
                    {
                        strSQL = "SELECT l.LEDGER_NAME_MERZE AS LEDGER_NAME ";
                        strSQL = strSQL + "FROM ACC_LEDGERGROUP AS g INNER JOIN ";
                        strSQL = strSQL + "ACC_LEDGERGROUP_CATEGORY_VIEW AS v ON g.GR_NAME = v.GR_PARENT INNER JOIN ";
                        strSQL = strSQL + "ACC_LEDGER AS l ON v.GR_NAME = l.LEDGER_PARENT_GROUP ";
                        strSQL = strSQL + " WHERE l.LEDGER_NAME  not like 'X%' and len(TERITORRY_CODE ) >=3 ";
                        strSQL = strSQL + "ORDER BY LEDGER_NAME ";
                    }
                    if (intMode == 4)
                    {
                        //strSQL = "SELECT STOCKITEM_NAME as LEDGER_NAME FROM INV_STOCKITEM  ORDER BY STOCKITEM_NAME";
                        strSQL = "SELECT INV_STOCKITEM.STOCKITEM_NAME as LEDGER_NAME FROM INV_STOCKITEM INNER JOIN ";
                        strSQL = strSQL + "INV_STOCKGROUP ON INV_STOCKITEM.STOCKGROUP_NAME = INV_STOCKGROUP.STOCKGROUP_NAME ";
                        strSQL = strSQL + "WHERE (INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE = 3) ";
                        strSQL = strSQL + "ORDER BY INV_STOCKITEM.STOCKITEM_NAME ";
                    }

                }

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strLedgername = dr["LEDGER_NAME"].ToString();
                    ooAccLedger.Add(oLedg);
                }

                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }

        public List<RProductSales> mGetPartyWiseProductsales2(string strDeComID, string strFdate, string strTDate, string strString, string strString2, string strSelction, string strSelction2)
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

                if (strSelction == "Purchase")
                {
                    strSQL = "SELECT LEDGER_NAME FROM  ACC_LEDGER WHERE (LEDGER_GROUP = 203)ORDER BY LEDGER_NAME ";
                }

                List<RProductSales> ooAccLedger = new List<RProductSales>();
                strSQL = "SELECT  ACC_COMP_BILL_TRAN_QRY.COMP_VOUCHER_DATE, ACC_COMP_BILL_TRAN_QRY.COMP_REF_NO, ACC_COMP_BILL_TRAN_QRY.BILL_UOM, ACC_COMP_BILL_TRAN_QRY.BILL_QUANTITY, ";
                strSQL = strSQL + "ACC_COMP_BILL_TRAN_QRY.BILL_RATE, ACC_COMP_BILL_TRAN_QRY.BILL_NET_AMOUNT, ACC_COMP_BILL_TRAN_QRY.VOUCHER_CURRENCY_SYMBOL, INV_STOCKITEM.STOCKITEM_NAME, ";
                strSQL = strSQL + "INV_STOCKITEM.STOCKGROUP_NAME, ";
                if (strString2 == "Purchase")
                {
                    strSQL = strSQL + "ACC_COMP_BILL_TRAN_QRY.LEDGER_NAME ";
                }
                else
                {
                    strSQL = strSQL + "ISNULL(ACC_LEDGER.TERITORRY_CODE, '') + '-' + ISNULL(ACC_COMP_BILL_TRAN_QRY.LEDGER_NAME, '') + '-' + ISNULL(ACC_LEDGER.TERRITORRY_NAME, '') AS LEDGER_NAME ";
                }
                strSQL = strSQL + "FROM ACC_COMP_BILL_TRAN_QRY AS ACC_COMP_BILL_TRAN_QRY INNER JOIN ";
                strSQL = strSQL + "INV_STOCKITEM AS INV_STOCKITEM ON ACC_COMP_BILL_TRAN_QRY.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
                strSQL = strSQL + "ACC_LEDGER ON ACC_COMP_BILL_TRAN_QRY.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE (ACC_COMP_BILL_TRAN_QRY.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) AND (ACC_COMP_BILL_TRAN_QRY.COMP_VOUCHER_TYPE = " + strSelction + ") ";
                if (strString2 != "")
                {
                    if (strString != "")
                    {
                        if (strString2 == "Purchase")
                        {
                            strSQL = strSQL + "AND  ACC_COMP_BILL_TRAN_QRY.LEDGER_NAME IN (" + strString + ") ";
                            strSQL = strSQL + "AND (ACC_COMP_BILL_TRAN_QRY.STOCKITEM_NAME IN (" + strSelction2 + ")) ";
                        }
                        if (strString2 == "Sales")
                        {
                            strSQL = strSQL + "AND ((ISNULL(ACC_LEDGER.TERITORRY_CODE, '') + '-' + ISNULL(ACC_COMP_BILL_TRAN_QRY.LEDGER_NAME, '') + '-' + ISNULL(ACC_LEDGER.TERRITORRY_NAME, '')) IN (" + strString + ")) ";
                            strSQL = strSQL + "AND (ACC_COMP_BILL_TRAN_QRY.STOCKITEM_NAME IN (" + strSelction2 + ")) ";
                        }
                    }
                }
                strSQL = strSQL + "ORDER BY INV_STOCKITEM.STOCKGROUP_NAME, INV_STOCKITEM.STOCKITEM_NAME, LEDGER_NAME ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    RProductSales oLedg = new RProductSales();

                    oLedg.strVoucheDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    oLedg.strRefNo = dr["COMP_REF_NO"].ToString();
                    oLedg.strStockCategoryName = dr["BILL_UOM"].ToString();
                    oLedg.DblBillQty = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());
                    oLedg.DblBillRate = Convert.ToDouble(dr["BILL_RATE"].ToString());
                    oLedg.DblBillAmount = Convert.ToDouble(dr["BILL_NET_AMOUNT"].ToString());
                    oLedg.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.strStockGroupName = dr["STOCKGROUP_NAME"].ToString();
                    oLedg.strLedgername = dr["LEDGER_NAME"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strVoucheDate = "";
                    oLedg.strRefNo = "";
                    oLedg.strStockCategoryName = "";
                    oLedg.DblBillQty = 0;
                    oLedg.DblBillRate = 0;
                    oLedg.DblBillAmount = 0;
                    oLedg.strStockItemName = "";
                    oLedg.strStockGroupName = "";
                    oLedg.strLedgername = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        //public List<RProductSales> mGetPartyWiseProductsales(string strDeComID, string strFdate, string strTDate, string strString, string strString2, string strSelction, string strSelction2)
        //{
        //    string strSQL = null;
        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();
        //        SqlDataReader dr;

               
        //        if (strSelction == "Purchase")
        //        {
        //            strSQL = "SELECT LEDGER_NAME FROM  ACC_LEDGER WHERE (LEDGER_GROUP = 203)ORDER BY LEDGER_NAME ";
        //        }

        //        List<RProductSales> ooAccLedger = new List<RProductSales>();
        //        strSQL = "SELECT ACC_COMP_BILL_TRAN_QRY.COMP_VOUCHER_DATE, ACC_COMP_BILL_TRAN_QRY.COMP_REF_NO, ACC_COMP_BILL_TRAN_QRY.BILL_UOM, ACC_COMP_BILL_TRAN_QRY.BILL_QUANTITY, ";
        //        strSQL = strSQL + "ACC_COMP_BILL_TRAN_QRY.BILL_RATE, ACC_COMP_BILL_TRAN_QRY.VOUCHER_CURRENCY_SYMBOL, INV_STOCKITEM.STOCKITEM_NAME, INV_STOCKITEM.STOCKGROUP_NAME, ";
        //        if (strString2 == "Purchase")
        //        {
        //            strSQL = strSQL + "ACC_COMP_BILL_TRAN_QRY.LEDGER_NAME ";
        //        }
        //        else
        //        {
        //            strSQL = strSQL + "ISNULL(ACC_LEDGER.TERITORRY_CODE, '') + '-' + ISNULL(ACC_COMP_BILL_TRAN_QRY.LEDGER_NAME, '') + '-' + ISNULL(ACC_LEDGER.TERRITORRY_NAME, '') AS LEDGER_NAME ";
        //        }

        //        strSQL = strSQL + " , ABS(tb1.BILL_ADD_LESS_AMOUNT) AS BILL_ADD_LESS_AMOUNT, tb1.BILL_AMOUNT ";
        //        strSQL = strSQL + "FROM ACC_COMP_BILL_TRAN_QRY AS ACC_COMP_BILL_TRAN_QRY INNER JOIN ";
        //        strSQL = strSQL + "INV_STOCKITEM AS INV_STOCKITEM ON ACC_COMP_BILL_TRAN_QRY.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
        //        strSQL = strSQL + "ACC_LEDGER ON ACC_COMP_BILL_TRAN_QRY.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME INNER JOIN ";
        //        strSQL = strSQL + "(SELECT BILL_AMOUNT, STOCKITEM_NAME, SUBSTRING(COMP_REF_NO, 7, 30) AS COMP_REF_NO, BILL_ADD_LESS_AMOUNT, BRANCH_ID ";
        //        strSQL = strSQL + "FROM  ACC_BILL_TRAN) AS tb1 ON ACC_COMP_BILL_TRAN_QRY.COMP_REF_NO = tb1.COMP_REF_NO AND ACC_COMP_BILL_TRAN_QRY.STOCKITEM_NAME = tb1.STOCKITEM_NAME AND  ";
        //        strSQL = strSQL + "ACC_COMP_BILL_TRAN_QRY.BRANCH_ID = tb1.BRANCH_ID ";
        //        strSQL = strSQL + "WHERE (ACC_COMP_BILL_TRAN_QRY.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) AND (ACC_COMP_BILL_TRAN_QRY.COMP_VOUCHER_TYPE = " + strSelction + ") ";
        //        if (strString2 != "")
        //        {
        //            if (strString != "")
        //            {
        //                if (strString2 == "Purchase")
        //                {
        //                    strSQL = strSQL + "AND  ACC_COMP_BILL_TRAN_QRY.LEDGER_NAME IN (" + strString + ") ";
        //                    strSQL = strSQL + "AND (ACC_COMP_BILL_TRAN_QRY.STOCKITEM_NAME IN (" + strSelction2 + ")) ";
        //                }
        //                if (strString2 == "Sales")
        //                {
        //                    strSQL = strSQL + "AND ((ISNULL(ACC_LEDGER.TERITORRY_CODE, '') + '-' + ISNULL(ACC_COMP_BILL_TRAN_QRY.LEDGER_NAME, '') + '-' + ISNULL(ACC_LEDGER.TERRITORRY_NAME, '')) IN (" + strString + ")) ";
        //                    strSQL = strSQL + "AND (ACC_COMP_BILL_TRAN_QRY.STOCKITEM_NAME IN (" + strSelction2 + ")) ";
        //                }
        //            }
        //        }
        //        strSQL = strSQL + "ORDER BY ACC_COMP_BILL_TRAN_QRY.COMP_VOUCHER_DATE, INV_STOCKITEM.STOCKGROUP_NAME, INV_STOCKITEM.STOCKITEM_NAME, LEDGER_NAME ";

        //        SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
        //        dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {

        //            RProductSales oLedg = new RProductSales();

        //            oLedg.strVoucheDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
        //            oLedg.strRefNo = dr["COMP_REF_NO"].ToString();
        //            oLedg.strStockCategoryName = dr["BILL_UOM"].ToString();
        //            oLedg.DblBillQty = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());
        //            oLedg.DblBillRate = Convert.ToDouble(dr["BILL_RATE"].ToString());
        //            oLedg.DblBillAmount = Convert.ToDouble(dr["BILL_AMOUNT"].ToString());
        //            oLedg.strStockItemName = dr["STOCKITEM_NAME"].ToString();
        //            oLedg.strStockGroupName = dr["STOCKGROUP_NAME"].ToString();
        //            oLedg.strLedgername = dr["LEDGER_NAME"].ToString();
        //            ooAccLedger.Add(oLedg);
        //        }
        //        if (!dr.HasRows)
        //        {
        //            RProductSales oLedg = new RProductSales();
        //            oLedg.strVoucheDate = "";
        //            oLedg.strRefNo = "";
        //            oLedg.strStockCategoryName = "";
        //            oLedg.DblBillQty = 0;
        //            oLedg.DblBillRate = 0;
        //            oLedg.DblBillAmount = 0;
        //            oLedg.strStockItemName = "";
        //            oLedg.strStockGroupName = "";
        //            oLedg.strLedgername = "";
        //            ooAccLedger.Add(oLedg);
        //        }

        //        dr.Close();
        //        gcnMain.Close();
        //        cmd.Dispose();
        //        return ooAccLedger;
        //    }
        //}
        #endregion
        #region Supplierlist

        public List<RSalesPurchase> LEDGERPARENTGROUP(string strDeComID, int intMode)
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();
                strSQL = "SELECT GR_PARENT ";
                strSQL = strSQL + "FROM (SELECT DISTINCT GR_PARENT ";
                strSQL = strSQL + "FROM ACC_LEDGERGROUP ";
                strSQL = strSQL + "WHERE (GR_GROUP = 203) AND (GR_DEFAULT_GROUP <> 1) ";
                strSQL = strSQL + "UNION ALL ";
                strSQL = strSQL + "SELECT GR_NAME ";
                strSQL = strSQL + "FROM  ACC_LEDGERGROUP AS ACC_LEDGERGROUP_1 ";
                strSQL = strSQL + "WHERE (GR_GROUP = 203) AND (GR_DEFAULT_GROUP <> 1)) AS tb1 ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strLedgerName = dr["GR_PARENT"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        public List<RSalesPurchase> mGetSupplierList(string strDeComID, string strFdate, string strTDate, string strString, int intMode, string strString2, string strBranchID)
        {
            //intMode 1= GR_PARENT data Show in form
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();
                if (intMode == 1)
                {
                    strSQL = "SELECT DISTINCT  GR_PARENT FROM  ACC_LEDGERGROUP WHERE (GR_GROUP = ' " + strString2 + " ')ORDER BY GR_PARENT ";
                }
                if (intMode >= 2)
                {
                    if (intMode >= 5)
                    {
                        strSQL = "SELECT ACC_LEDGERGROUP.GR_NAME, ACC_LEDGERGROUP.GR_LEVEL, ACC_LEDGER.LEDGER_NAME, ACC_LEDGER.LEDGER_ADDRESS1, ACC_LEDGER.LEDGER_ADDRESS2, ACC_LEDGER.LEDGER_CITY, ";
                        strSQL = strSQL + "ACC_LEDGER.LEDGER_POSTAL, ACC_LEDGER.LEDGER_FAX, ACC_LEDGER.LEDGER_PHONE, ACC_LEDGER.LEDGER_EMAIL, ACC_LEDGER.LEDGER_ADD_DATE, ACC_LEDGERGROUP.GR_GROUP, ACC_LEDGERGROUP.GR_PARENT , ACC_LEDGER.LEDGER_CODE, ACC_LEDGER.HOMOEO_HALL, ACC_LEDGER.LEDGER_TARGET,ACC_LEDGER.LEDGER_REP_NAME ";
                        strSQL = strSQL + ", ACC_LEDGER.TERITORRY_CODE + '-' + ACC_LEDGER.LEDGER_REP_NAME + '-' + ACC_LEDGER.TERRITORRY_NAME AS LEDGER_NAME_TCODE ";
                        strSQL = strSQL + "FROM ACC_LEDGERGROUP AS ACC_LEDGERGROUP INNER JOIN ";
                        strSQL = strSQL + "ACC_LEDGER AS ACC_LEDGER ON ACC_LEDGERGROUP.GR_NAME = ACC_LEDGER.LEDGER_PARENT_GROUP ";
                    }
                    else
                    {
                        strSQL = "SELECT  ACC_LEDGERGROUP.GR_NAME, ACC_LEDGERGROUP.GR_LEVEL, ACC_LEDGER.LEDGER_NAME, ACC_LEDGER.LEDGER_ADDRESS1, ACC_LEDGER.LEDGER_ADDRESS2, ACC_LEDGER.LEDGER_CITY, ";
                        strSQL = strSQL + "ACC_LEDGER.LEDGER_POSTAL, ACC_LEDGER.LEDGER_FAX, ACC_LEDGER.LEDGER_PHONE, ACC_LEDGER.LEDGER_EMAIL, ACC_LEDGER.LEDGER_ADD_DATE, ACC_LEDGERGROUP.GR_GROUP,  ";
                        strSQL = strSQL + "ACC_LEDGERGROUP.GR_PARENT, ACC_LEDGER.LEDGER_CODE, ACC_LEDGER.HOMOEO_HALL, ACC_LEDGER.LEDGER_TARGET,  ";
                        strSQL = strSQL + "ACC_LEDGER.TERITORRY_CODE + '-' + ACC_LEDGER.LEDGER_REP_NAME + '-' + ACC_LEDGER.TERRITORRY_NAME AS LEDGER_NAME_TCODE, ACC_LEDGER.LEDGER_REP_NAME ";
                        strSQL = strSQL + "FROM ACC_LEDGERGROUP AS ACC_LEDGERGROUP INNER JOIN ";
                        strSQL = strSQL + "ACC_LEDGER AS ACC_LEDGER ON ACC_LEDGERGROUP.GR_NAME = ACC_LEDGER.LEDGER_PARENT_GROUP INNER JOIN ";
                        strSQL = strSQL + "ACC_LEDGER AS B ON ACC_LEDGER.LEDGER_REP_NAME = B.LEDGER_NAME ";
                    }
                    if (strBranchID != "")
                    {
                        strSQL = strSQL + "where (B.BRANCH_ID = '" + strBranchID + "') ";
                    }
                    if (intMode >= 2)
                    {
                        if (intMode == 3)
                        {
                            if (strString == "Sundry Creditors")
                            {
                                strSQL = strSQL + "and (ACC_LEDGERGROUP.GR_PARENT = 'Sundry Creditors') ";
                                strSQL = strSQL + " AND (B.LEDGER_STATUS = 0)";
                            }
                            else
                            {
                                strSQL = strSQL + "and (ACC_LEDGER.LEDGER_PARENT_GROUP ='" + strString + "' ";
                                strSQL = strSQL + " OR  ACC_LEDGER.LEDGER_PRIMARY_GROUP ='" + strString + "')";
                                strSQL = strSQL + " AND (B.LEDGER_STATUS = 0)";
                            }
                        }
                        if (intMode == 4)
                        {
                            if (strString != "")
                            {
                                strSQL = strSQL + "and (  ACC_LEDGER.LEDGER_REP_NAME  ='" + strString + "')";
                                strSQL = strSQL + " AND (B.LEDGER_STATUS = 0)";
                            }
                            else
                            {
                                strSQL = strSQL + " AND (B.LEDGER_STATUS = 0) ";
                            }
                        }

                        if (intMode == 2)
                        {
                            strSQL = strSQL + " AND (B.LEDGER_STATUS = 0)";
                            if (strString != "")
                            {
                                strSQL = strSQL + "and  (B.LEDGER_NAME ='" + strString + "')";
                            }
                        }
                        if (intMode >= 5)
                        {
                            strSQL = strSQL + " Where LEDGER_GROUP=203  ";
                            if (strString != "")
                            {
                                if (intMode == 5)
                                {
                                    strSQL = strSQL + "and  (ACC_LEDGER.LEDGER_NAME ='" + strString + "')";

                                }
                                else
                                {
                                    strSQL = strSQL + "and   (ACC_LEDGERGROUP.GR_NAME ='" + strString + "' )";
                                }
                            }

                        }
                        if (intMode >= 5)
                        {
                            strSQL = strSQL + "Order by LEDGER_NAME ";
                        }
                        else
                        {
                            strSQL = strSQL + "ORDER BY ACC_LEDGERGROUP.GR_NAME,ACC_LEDGER.LEDGER_CODE ";
                        }
                    }

                }
                if (intMode == 1)
                {
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        RSalesPurchase oLedg = new RSalesPurchase();
                        oLedg.strStockGroupName = dr["GR_PARENT"].ToString();
                        ooAccLedger.Add(oLedg);
                    }
                    dr.Close();
                    gcnMain.Close();
                    cmd.Dispose();
                    return ooAccLedger;
                }
                else
                {

                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (intMode >= 2)
                        {
                            RSalesPurchase oLedg = new RSalesPurchase();
                            oLedg.strStockGroupName = dr["GR_NAME"].ToString();
                            oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
                            oLedg.strLedgerCode = dr["LEDGER_CODE"].ToString();
                            oLedg.strContactPerson = dr["HOMOEO_HALL"].ToString();
                            oLedg.dblTargetAmt = Convert.ToDouble(dr["LEDGER_TARGET"].ToString());
                            oLedg.strPhoneNumber = dr["LEDGER_PHONE"].ToString();
                            oLedg.strAddress1 = dr["LEDGER_ADDRESS1"].ToString();
                            oLedg.strFax = dr["LEDGER_FAX"].ToString();
                            oLedg.strEmail = dr["LEDGER_EMAIL"].ToString();
                            oLedg.strStockGroupPrimary = dr["GR_PARENT"].ToString();
                            oLedg.strLedgerGroupParent = dr["LEDGER_NAME_TCODE"].ToString();
                            ooAccLedger.Add(oLedg);
                        }
                    }
                    if (!dr.HasRows)
                    {
                        RSalesPurchase oLedg = new RSalesPurchase();
                        oLedg.strStockGroupName = "";
                        oLedg.strLedgerName = "";
                        oLedg.strLedgerCode = "";
                        oLedg.strContactPerson = "";
                        oLedg.dblTargetAmt = 0;
                        oLedg.strPhoneNumber = "";
                        oLedg.strAddress1 = "";
                        oLedg.strFax = "";
                        oLedg.strEmail = "";
                        oLedg.strStockGroupPrimary = "";
                        oLedg.strLedgerGroupParent = "";
                        ooAccLedger.Add(oLedg);
                    }
                    dr.Close();
                    gcnMain.Close();
                    cmd.Dispose();
                    return ooAccLedger;
                }

            }
        }
        #endregion
        #region VoucherReport
       
        public List<RSalesPurchase> mGetVoucherReportRefNo(string strDeComID, string strRefNo, string strBranchId, int intMode)
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


                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();
                strSQL = "SELECT ACC_COMPANY_VOUCHER.COMP_VOUCHER_PARTY_NAME, ACC_COMPANY_VOUCHER.COMP_VOUCHER_ADDRESS1, ACC_COMPANY_VOUCHER.COMP_VOUCHER_ADDRESS2, ";
                strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_CITY, ACC_ADD_LESS.ADD_LESS_LEDGER, ACC_ADD_LESS.ADD_LESS_ADD_AMOUNT, ACC_ADD_LESS.ADD_LESS_LESS_AMOUNT, SUBSTRING(ACC_BILL_TRAN.COMP_REF_NO, 7, 30) AS COMP_REF_NO, ";
                strSQL = strSQL + "ACC_BILL_TRAN.COMP_VOUCHER_DATE, ACC_BILL_TRAN.STOCKITEM_NAME, ACC_BILL_TRAN.BILL_QUANTITY, ACC_BILL_TRAN.BILL_RATE, ACC_BILL_TRAN.BILL_UOM, ACC_BILL_TRAN.BILL_PER, ";
                strSQL = strSQL + "ACC_BILL_TRAN.BILL_AMOUNT, isnull(ACC_BILL_TRAN.BILL_ADD_LESS,0) BILL_ADD_LESS, ACC_BILL_TRAN.BILL_ADD_LESS_AMOUNT, ACC_BILL_TRAN.BILL_NET_AMOUNT, INV_STOCKITEM.STOCKITEM_BASEUNITS,  ACC_COMPANY_VOUCHER.PREPARED_DATE, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION, ";
                strSQL = strSQL + "INV_UNIT_MEASUREMENT.INV_UNIT_DECIMAL_NO, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT, ACC_LEDGER.LEDGER_NAME_MERZE, ";
                if (intMode == 16)
                {
                    strSQL = strSQL + "ISNULL(ACC_LEDGER.TERITORRY_CODE, '') + '-' + ISNULL(ACC_COMPANY_VOUCHER.LEDGER_NAME, '') + '-' + ISNULL(ACC_LEDGER.TERRITORRY_NAME, '') AS LEDGER_NAME ";
                }
                else
                {
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.LEDGER_NAME ";
                }
                strSQL = strSQL + "FROM  ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER INNER JOIN ";
                strSQL = strSQL + "ACC_BILL_TRAN AS ACC_BILL_TRAN ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO LEFT OUTER JOIN ";
                strSQL = strSQL + "ACC_ADD_LESS AS ACC_ADD_LESS ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_ADD_LESS.ADD_LESS_COMP_REF_NO INNER JOIN ";
                strSQL = strSQL + "INV_STOCKITEM AS INV_STOCKITEM ON ACC_BILL_TRAN.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
                strSQL = strSQL + "INV_UNIT_MEASUREMENT AS INV_UNIT_MEASUREMENT ON INV_STOCKITEM.STOCKITEM_BASEUNITS = INV_UNIT_MEASUREMENT.UNIT_SYMBOL INNER JOIN ";
                strSQL = strSQL + "ACC_LEDGER ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME ";
                //strSQL = strSQL + "WHERE (ACC_BILL_TRAN.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + "))" ;
                strSQL = strSQL + "WHERE (ACC_COMPANY_VOUCHER.COMP_REF_NO = " + strRefNo + ") ";
                if (strBranchId != "")
                {
                    strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.BRANCH_ID ='" + strBranchId + "' ";
                }

                strSQL = strSQL + "ORDER BY  ACC_BILL_TRAN.BILL_TRAN_KEY,ACC_ADD_LESS.ADD_LESS_LEDGER, ACC_BILL_TRAN.STOCKITEM_NAME ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strLedgerName = dr["LEDGER_NAME_MERZE"].ToString();
                    oLedg.strRefNo = dr["COMP_REF_NO"].ToString();
                    oLedg.strVDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    oLedg.dblBilQty = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());
                    oLedg.strRate = Convert.ToDouble(dr["BILL_RATE"].ToString());
                    oLedg.dblAddLess = Convert.ToDouble(dr["BILL_ADD_LESS"].ToString());
                    oLedg.dblNetBillAmount = Convert.ToDouble(dr["COMP_VOUCHER_NET_AMOUNT"].ToString());
                    oLedg.strItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.dblBillAmount = Convert.ToDouble(dr["BILL_AMOUNT"].ToString());
                    oLedg.strBILL_Per = dr["BILL_PER"].ToString();
                    oLedg.strBILL_UOM = dr["BILL_UOM"].ToString();
                    if (dr["COMP_VOUCHER_NARRATION"].ToString() != "")
                    {
                        oLedg.strEmail = dr["COMP_VOUCHER_NARRATION"].ToString();
                    }
                    else
                    {
                        oLedg.strEmail = "";
                    }
                    ooAccLedger.Add(oLedg);
                }

                if (!dr.HasRows)
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strLedgerName = "";
                    oLedg.strRefNo = "";
                    oLedg.strVDate = "";
                    oLedg.dblBilQty = 0;
                    oLedg.strRate = 0;
                    oLedg.dblAddLess = 0; ;
                    oLedg.dblAddamount = 0;
                    oLedg.strItemName = "";
                    oLedg.dblBillAmount = 0;
                    oLedg.strBILL_Per = "";
                    oLedg.strBILL_UOM = "";
                    oLedg.strEmail = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        public List<RSalesPurchase> mGetVoucherRefNo(string strDeComID, string strFDate, string strTDate, string strSelection, string strBranchId, int intMode)
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();
                strSQL = "SELECT SUBSTRING(COMP_REF_NO, 7, 30) AS COMP_REF_NO, COMP_VOUCHER_TYPE FROM ACC_COMPANY_VOUCHER  ";
                if (strSelection != "")
                {
                    if (intMode == 17)
                    {
                        strSQL = strSQL + " WHERE (SAMPLE_STATUS = 1 ) ";
                    }
                    else
                    {
                        strSQL = strSQL + " WHERE (COMP_VOUCHER_TYPE = " + intMode + ") ";
                    }
                }

                strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strRefNo = dr["COMP_REF_NO"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strRefNo = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        public List<RSalesPurchase> mGetVoucherAddless(string strDeComID, string strString, string strBranchId)
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();
                strSQL = "SELECT COMP_REF_NO, COMP_VOUCHER_TYPE, COMP_VOUCHER_POSITION, LEDGER_NAME, VOUCHER_DEBIT_AMOUNT, VOUCHER_CREDIT_AMOUNT, VOUCHER_ADD_LESS_SIGN ";
                strSQL = strSQL + "FROM ACC_VOUCHER AS ACC_VOUCHER ";
                strSQL = strSQL + "WHERE (COMP_REF_NO = " + strString + ") AND (COMP_VOUCHER_POSITION > 2) ";
                strSQL = strSQL + "ORDER BY COMP_REF_NO ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.dblVtype = Convert.ToDouble(dr["COMP_VOUCHER_TYPE"].ToString());
                    oLedg.dblBilQty = Convert.ToDouble(dr["COMP_VOUCHER_POSITION"].ToString());
                    oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oLedg.dblDiscountAmount = Convert.ToDouble(dr["VOUCHER_DEBIT_AMOUNT"].ToString());
                    oLedg.dbllessamount = Convert.ToDouble(dr["VOUCHER_CREDIT_AMOUNT"].ToString());
                    oLedg.StrSing = dr["VOUCHER_ADD_LESS_SIGN"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.dblVtype = 0;
                    oLedg.strLedgerName = "";
                    oLedg.dblDiscountAmount = 0;
                    oLedg.StrSing = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;

            }
           
        }

        public List<RSalesPurchase> mGetVoucherReport(string strDeComID, string strFDate, string strTDate, string strLedgername, string strBranchId, int intMode, string selection)
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();


                if (selection == "Sum")
                {
                    strSQL = "SELECT   ACC_LEDGER.LEDGER_NAME_MERZE AS TERRITORRYNAME,  ";
                    strSQL = strSQL + "0 ADD_LESS_ADD_AMOUNT , ";
                    strSQL = strSQL + "0 ADD_LESS_LESS_AMOUNT, ";
                    strSQL = strSQL + "'' AS COMP_REF_NO, '' COMP_VOUCHER_DATE, ACC_BILL_TRAN.STOCKITEM_NAME, sum(ACC_BILL_TRAN.BILL_QUANTITY) as BILL_QUANTITY,sum(ACC_BILL_TRAN.BILL_QUANTITY_BONUS) as BILL_QUANTITY_BONUS , ";
                    strSQL = strSQL + "sum(BILL_RATE) BILL_RATE, 0 BILL_ADD_LESS, sum(ACC_BILL_TRAN.BILL_AMOUNT) as BILL_AMOUNT ,BRANCH_NAME , ABS(SUM(ACC_BILL_TRAN.BILL_ADD_LESS_AMOUNT)) AS Commission FROM ACC_LEDGER AS ACC_LEDGER ";
                    strSQL = strSQL + "INNER JOIN ACC_COMPANY_VOUCHER ON ACC_LEDGER.LEDGER_NAME = ACC_COMPANY_VOUCHER.LEDGER_NAME INNER JOIN ACC_BILL_TRAN AS ACC_BILL_TRAN ON ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO LEFT OUTER JOIN ACC_BRANCH AS ACC_BRANCH ON ACC_BILL_TRAN.BRANCH_ID = ACC_BRANCH.BRANCH_ID FULL ";
                    strSQL = strSQL + "OUTER JOIN ACC_ADD_LESS AS ACC_ADD_LESS ON ACC_BILL_TRAN.COMP_REF_NO = ACC_ADD_LESS.ADD_LESS_COMP_REF_NO ";
                    strSQL = strSQL + "WHERE (ACC_BILL_TRAN.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ") ) ";
                    if (strBranchId != "")
                    {
                        strSQL = strSQL + "AND (ACC_BILL_TRAN.COMP_VOUCHER_TYPE = '" + strBranchId + "') ";
                    }
                    strSQL = strSQL + "AND (dbo.ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = " + intMode + ")";

                    if (intMode == 15)
                    {
                        strSQL = strSQL + "AND (ACC_COMPANY_VOUCHER.SAMPLE_STATUS >=0) ";
                    }
                    else
                    {
                        strSQL = strSQL + "AND  (ACC_COMPANY_VOUCHER.SAMPLE_STATUS = 0) ";
                    }

                    if (strLedgername != "")
                    {
                        strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_NAME = '" + strLedgername + "') ";
                    }
                    strSQL = strSQL + "GROUP BY ACC_LEDGER.LEDGER_NAME_MERZE, ACC_BILL_TRAN.STOCKITEM_NAME, ACC_BRANCH.BRANCH_NAME";


                }
                if (selection == null)
                {
                    if (intMode == 17)
                    {
                        strSQL = "SELECT  ACC_LEDGER.LEDGER_NAME_MERZE AS TERRITORRYNAME ";
                        strSQL = strSQL + ",( CASE WHEN ACC_ADD_LESS.ADD_LESS_ADD_AMOUNT IS NULL Then 0 else ACC_ADD_LESS.ADD_LESS_ADD_AMOUNT end ) as ADD_LESS_ADD_AMOUNT , ( case when ACC_ADD_LESS.ADD_LESS_LESS_AMOUNT is null then 0 else ACC_ADD_LESS.ADD_LESS_LESS_AMOUNT end ) as ADD_LESS_LESS_AMOUNT,ACC_BILL_TRAN.COMP_REF_NO BillKey, SUBSTRING(ACC_BILL_TRAN.COMP_REF_NO, 7, 30) AS COMP_REF_NO, ";
                        strSQL = strSQL + "ACC_BILL_TRAN.COMP_VOUCHER_DATE, ACC_BILL_TRAN.STOCKITEM_NAME, ACC_BILL_TRAN.BILL_QUANTITY, ACC_BILL_TRAN.BILL_RATE, ACC_BILL_TRAN.BILL_ADD_LESS, ACC_BILL_TRAN.BILL_NET_AMOUNT, ";
                        strSQL = strSQL + "ACC_BRANCH.BRANCH_NAME ,ACC_COMPANY_VOUCHER.PREPARED_DATE, ACC_BILL_TRAN.BILL_QUANTITY_BONUS, ACC_BILL_TRAN.BILL_AMOUNT, ABS(SUM(ACC_BILL_TRAN.BILL_ADD_LESS_AMOUNT)) AS Commission  ";
                        strSQL = strSQL + "FROM ACC_LEDGER AS ACC_LEDGER INNER JOIN ";
                        strSQL = strSQL + "ACC_COMPANY_VOUCHER ON ACC_LEDGER.LEDGER_NAME = ACC_COMPANY_VOUCHER.LEDGER_NAME INNER JOIN ";
                        strSQL = strSQL + "ACC_BILL_TRAN AS ACC_BILL_TRAN ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO LEFT OUTER JOIN ";
                        strSQL = strSQL + "ACC_BRANCH AS ACC_BRANCH ON ACC_BILL_TRAN.BRANCH_ID = ACC_BRANCH.BRANCH_ID FULL OUTER JOIN ";
                        strSQL = strSQL + "ACC_ADD_LESS AS ACC_ADD_LESS ON ACC_BILL_TRAN.COMP_REF_NO = ACC_ADD_LESS.ADD_LESS_COMP_REF_NO ";
                        strSQL = strSQL + "WHERE (ACC_BILL_TRAN.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ") ) ";
                        if (strBranchId != "")
                        {
                            strSQL = strSQL + "AND (ACC_BILL_TRAN.BRANCH_ID = '" + strBranchId + "') ";
                        }

                        strSQL = strSQL + "AND (ACC_COMPANY_VOUCHER.SAMPLE_STATUS = 1) ";
                        if (strLedgername != "")
                        {
                            strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_NAME = '" + strLedgername + "')";
                        }
                    }
                    else
                    {

                        strSQL = "SELECT  LEDGER_NAME, TERRITORRYNAME, ADD_LESS_ADD_AMOUNT, ADD_LESS_LESS_AMOUNT, BillKey, COMP_REF_NO, COMP_VOUCHER_DATE, STOCKITEM_NAME, BILL_QUANTITY, BILL_RATE, BILL_ADD_LESS, ";
                        strSQL = strSQL + "BILL_NET_AMOUNT, BRANCH_NAME, PREPARED_DATE, BILL_QUANTITY_BONUS, BILL_AMOUNT, Commission ";
                        strSQL = strSQL + "FROM  (SELECT  t1.LEDGER_NAME, t1.TERRITORRYNAME, t1.ADD_LESS_ADD_AMOUNT, t1.ADD_LESS_LESS_AMOUNT, t1.BillKey, t1.COMP_REF_NO, t1.COMP_VOUCHER_DATE, t1.STOCKITEM_NAME, t1.BILL_QUANTITY, ";
                        strSQL = strSQL + "t1.BILL_RATE, t1.BILL_ADD_LESS, t1.BILL_NET_AMOUNT, t1.BRANCH_NAME, t1.PREPARED_DATE, t1.BILL_QUANTITY_BONUS, t1.BILL_AMOUNT, t1.Commission ";
                        strSQL = strSQL + "FROM (SELECT ACC_LEDGER.LEDGER_NAME_MERZE AS TERRITORRYNAME, ACC_LEDGER.LEDGER_NAME, (CASE WHEN ACC_ADD_LESS.ADD_LESS_ADD_AMOUNT IS NULL  ";
                        strSQL = strSQL + "THEN 0 ELSE ACC_ADD_LESS.ADD_LESS_ADD_AMOUNT END) AS ADD_LESS_ADD_AMOUNT, (CASE WHEN ACC_ADD_LESS.ADD_LESS_LESS_AMOUNT IS NULL  ";
                        strSQL = strSQL + "THEN 0 ELSE ACC_ADD_LESS.ADD_LESS_LESS_AMOUNT END) AS ADD_LESS_LESS_AMOUNT, ACC_BILL_TRAN.COMP_REF_NO AS BillKey, SUBSTRING(ACC_BILL_TRAN.COMP_REF_NO, 7, 30)  ";
                        strSQL = strSQL + "AS COMP_REF_NO, ACC_BILL_TRAN.COMP_VOUCHER_DATE, ACC_BILL_TRAN.STOCKITEM_NAME, ACC_BILL_TRAN.BILL_QUANTITY, ACC_BILL_TRAN.BILL_RATE, ACC_BILL_TRAN.BILL_ADD_LESS,  ";
                        strSQL = strSQL + "ACC_BILL_TRAN.BILL_NET_AMOUNT, ACC_BRANCH.BRANCH_NAME, ACC_COMPANY_VOUCHER.PREPARED_DATE, ACC_BILL_TRAN.BILL_QUANTITY_BONUS, ACC_BILL_TRAN.BILL_AMOUNT,  ";
                        strSQL = strSQL + "ABS(ACC_BILL_TRAN.BILL_ADD_LESS_AMOUNT) AS Commission ";
                        strSQL = strSQL + "FROM  ACC_LEDGER AS ACC_LEDGER INNER JOIN ";
                        strSQL = strSQL + "ACC_COMPANY_VOUCHER ON ACC_LEDGER.LEDGER_NAME = ACC_COMPANY_VOUCHER.LEDGER_NAME INNER JOIN ";
                        strSQL = strSQL + "ACC_BILL_TRAN AS ACC_BILL_TRAN ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO LEFT OUTER JOIN ";
                        strSQL = strSQL + "ACC_BRANCH AS ACC_BRANCH ON ACC_BILL_TRAN.BRANCH_ID = ACC_BRANCH.BRANCH_ID FULL OUTER JOIN ";
                        strSQL = strSQL + "ACC_ADD_LESS AS ACC_ADD_LESS ON ACC_BILL_TRAN.COMP_REF_NO = ACC_ADD_LESS.ADD_LESS_COMP_REF_NO ";
                        strSQL = strSQL + "WHERE  (ACC_BILL_TRAN.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) AND (ACC_BILL_TRAN.COMP_VOUCHER_TYPE = " + intMode + "))  ";
                        strSQL = strSQL + "AS t1 LEFT OUTER JOIN ";
                        strSQL = strSQL + "(SELECT COMP_REF_NO, LEDGER_NAME, VOUCHER_ADD_LESS_SIGN, VOUCHER_CREDIT_AMOUNT, VOUCHER_DEBIT_AMOUNT, VOUCHER_REF_KEY ";
                        strSQL = strSQL + "FROM  ACC_VOUCHER ";
                        strSQL = strSQL + "WHERE (COMP_VOUCHER_POSITION <> 1) AND (COMP_VOUCHER_POSITION <> 2) AND (COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) AND (COMP_VOUCHER_TYPE = " + intMode + ")) AS t2 ON t1.BillKey = t2.COMP_REF_NO) AS tb3 ";
                        if (strLedgername != "")
                        {

                            strSQL = strSQL + "WHERE (LEDGER_NAME ='" + strLedgername + "') ";
                        }

                        strSQL = strSQL + "ORDER BY COMP_VOUCHER_DATE ";
                    }


                    //strSQL = strSQL + "ORDER BY t1.COMP_VOUCHER_DATE";
                }


                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();

                    oLedg.strLedgerName = dr["TERRITORRYNAME"].ToString();
                    if (dr["BRANCH_NAME"].ToString() != "")
                    {
                        oLedg.strBranchName = dr["BRANCH_NAME"].ToString();
                    }
                    oLedg.dblAddamount = Convert.ToDouble(dr["ADD_LESS_LESS_AMOUNT"].ToString());
                    oLedg.dbllessamount = Convert.ToDouble(dr["ADD_LESS_ADD_AMOUNT"].ToString());

                    if ((intMode == 13) || (intMode == 33) || (intMode == 32))
                    {
                        if (dr["COMP_VOUCHER_DATE"].ToString() != "")
                        {
                            oLedg.strVDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            oLedg.strVDate = "";
                        }
                    }
                    if ((intMode == 16) && (selection != "Sum"))
                    {
                        oLedg.strVDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    }
                    if (dr["COMP_REF_NO"].ToString() != "")
                    {
                        oLedg.strRefNo = dr["COMP_REF_NO"].ToString();

                    }
                    else
                    {
                        oLedg.strRefNo = "";
                    }
                    oLedg.dblBilQty = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());

                    oLedg.dblBonusQty = Convert.ToDouble(dr["BILL_QUANTITY_BONUS"].ToString());

                    oLedg.strRate = Convert.ToDouble(dr["BILL_RATE"].ToString());
                    oLedg.dblAddLess = Convert.ToDouble(dr["Commission"].ToString());
                    oLedg.strItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.dblBillAmount = Convert.ToDouble(dr["BILL_AMOUNT"].ToString());
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strLedgerName = "";
                    oLedg.dblAddamount = 0;
                    oLedg.dbllessamount = 0;
                    oLedg.strVDate = "";
                    oLedg.strVDate = "";
                    oLedg.strVDate = "";
                    oLedg.strRefNo = "";
                    oLedg.dblBilQty = 0;
                    oLedg.dblBonusQty = 0;
                    oLedg.strRate = 0;
                    oLedg.dblAddLess = 0;
                    oLedg.strItemName = "";
                    oLedg.dblBillAmount = 0;
                    ooAccLedger.Add(oLedg);
                }

                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;

            }
        }

        #endregion
        #region Purchase Register
        public List<RSalesPurchase> mGetPurchaseRegisterReport(string strDeComID, string strFDate, string strTDate, string strLedgername, string strString2)
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();

                strSQL = "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ACC_COMPANY_VOUCHER.COMP_VOUCHER_ADD_AMOUNT, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION, ";
                strSQL = strSQL + " ACC_BILL_TRAN.STOCKITEM_NAME, ACC_BILL_TRAN.BILL_QUANTITY, ACC_BILL_TRAN.BILL_RATE, ACC_BILL_TRAN.BILL_UOM, ACC_BILL_TRAN.BILL_PER, ";
                strSQL = strSQL + "ISNULL(ACC_BILL_TRAN.BILL_ADD_LESS,0) BILL_ADD_LESS, ACC_BILL_TRAN.BILL_NET_AMOUNT AS BILL_NET_AMOUNT, ";
                if ((strString2 == "32") || (strString2 == "33"))
                {
                    strSQL = strSQL + "isnull (ACC_COMPANY_VOUCHER.LEDGER_NAME,'') as LEDGER_NAME ";
                }
                else
                {
                    strSQL = strSQL + "isnull( ACC_LEDGER.TERITORRY_CODE,'') +'-'+ isnull (ACC_COMPANY_VOUCHER.LEDGER_NAME,'') +'-'+ ";
                    strSQL = strSQL + "isnull (ACC_LEDGER.TERRITORRY_NAME,'')as LEDGER_NAME ";
                }
                strSQL = strSQL + "FROM  ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER INNER JOIN ";
                strSQL = strSQL + "ACC_BRANCH AS ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID INNER JOIN ";
                strSQL = strSQL + "ACC_BILL_TRAN AS ACC_BILL_TRAN ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO INNER JOIN ";
                strSQL = strSQL + "ACC_LEDGER ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE (ACC_BILL_TRAN.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + "AND (ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = " + strString2 + ") ";

                if (strLedgername != "")
                {
                    strSQL = strSQL + "AND (ACC_COMPANY_VOUCHER.LEDGER_NAME = '" + strLedgername + "') ";
                }
                strSQL = strSQL + "ORDER BY ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ACC_COMPANY_VOUCHER.LEDGER_NAME, ACC_COMPANY_VOUCHER.COMP_REF_NO ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strRefNo = dr["COMP_REF_NO"].ToString();
                    oLedg.strVDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    oLedg.dblBilQty = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());
                    oLedg.strItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.strRate = Convert.ToDouble(dr["BILL_RATE"].ToString());
                    oLedg.strBILL_UOM = dr["BILL_UOM"].ToString();
                    oLedg.strBILL_Per = dr["BILL_PER"].ToString();
                    oLedg.dblAddLess = Convert.ToDouble(dr["COMP_VOUCHER_ADD_AMOUNT"].ToString());
                    oLedg.dblBillAddLessAmount = Convert.ToDouble(dr["BILL_ADD_LESS"].ToString());
                    oLedg.dblNetBillAmount = Convert.ToDouble(dr["BILL_NET_AMOUNT"].ToString());
                    oLedg.dblBillAmount = Convert.ToDouble(dr["COMP_VOUCHER_NET_AMOUNT"].ToString());
                    oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strRefNo = "0001No";
                    oLedg.strVDate = "";
                    oLedg.dblBilQty = 0;
                    oLedg.strItemName = "";
                    oLedg.strRate =0;
                    oLedg.strBILL_UOM = "";
                    oLedg.strBILL_Per = "";
                    oLedg.dblAddLess = 0;
                    oLedg.dblBillAddLessAmount =0;
                    oLedg.dblNetBillAmount = 0;
                    oLedg.dblBillAmount = 0;
                    oLedg.strLedgerName = "";
                    oLedg.strLedgerName = "";
                    ooAccLedger.Add(oLedg);
                }

                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
              
                return ooAccLedger;
            }
        }

        #endregion
        #region "Invoice List"
        public List<RProductSales> mGetSalesInvoiceReportPriview(string strDeComID, string strcomRef)
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

                List<RProductSales> ooAccLedger = new List<RProductSales>();
                strSQL = "SELECT  ACC_COMPANY_VOUCHER.COMP_REF_NO, ACC_COMPANY_VOUCHER.LEDGER_NAME, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT, ";
                strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_DUE_DATE, ACC_COMPANY_VOUCHER.ORDER_NO, ACC_COMPANY_VOUCHER.ORDER_DATE, ACC_BILL_TRAN.BILL_QUANTITY, ACC_BILL_TRAN.BILL_QUANTITY_BONUS, ";
                strSQL = strSQL + "ACC_BILL_TRAN.BILL_AMOUNT, INV_STOCKITEM.STOCKITEM_NAME, INV_STOCKITEM.POWER_CLASS, INV_STOCKITEM.STOCKGROUP_NAME, INV_STOCKITEM.STOCKCATEGORY_NAME, ";
                strSQL = strSQL + "ACC_LEDGER.LEDGER_NAME_MERZE, ACC_LEDGER.LEDGER_ADDRESS1, ACC_LEDGER.LEDGER_ADDRESS2, ACC_COMPANY_VOUCHER.PREPARED_BY, ACC_COMPANY_VOUCHER.SALES_REP,  ";
                strSQL = strSQL + "ACC_LEDGER_1.LEDGER_CODE +'-' + ACC_LEDGER_1.LEDGER_NAME as Sales_Rep,ACC_LEDGER_1.HOMOEO_HALL  +',' +  ACC_LEDGER.LEDGER_ADDRESS1  as LEDGER_ADDRESS11 ,";
                strSQL = strSQL + "ACC_BILL_TRAN.BILL_RATE, ACC_BILL_TRAN.G_COMM_PER, ACC_LEDGER_1.LEDGER_NAME_MERZE AS Sales_Rep , ACC_LEDGER.TERITORRY_CODE, ACC_LEDGER.TERRITORRY_NAME, ";
                strSQL = strSQL + "ACC_COMPANY_VOUCHER.PREPARED_DATE ";
                strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER INNER JOIN ";
                strSQL = strSQL + "ACC_BILL_TRAN AS ACC_BILL_TRAN ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO INNER JOIN ";
                strSQL = strSQL + "INV_STOCKITEM AS INV_STOCKITEM ON ACC_BILL_TRAN.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME FULL OUTER JOIN ";
                strSQL = strSQL + "ACC_LEDGER ON ACC_COMPANY_VOUCHER.SALES_REP = ACC_LEDGER.LEDGER_NAME FULL OUTER JOIN ";
                strSQL = strSQL + "ACC_LEDGER AS ACC_LEDGER_1 ON ACC_COMPANY_VOUCHER.SALES_REP = ACC_LEDGER_1.LEDGER_NAME ";
                if (strcomRef != "")
                {
                    strSQL = strSQL + "WHERE (ACC_COMPANY_VOUCHER.COMP_REF_NO = " + strcomRef + ") ";
                }
                strSQL = strSQL + "ORDER BY ACC_BILL_TRAN.BILL_TRAN_KEY ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strRefNo = dr["COMP_REF_NO"].ToString();
                    oLedg.strLedgername = dr["LEDGER_NAME"].ToString();
                    oLedg.strVoucheDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    oLedg.DblVNetAmt = Convert.ToDouble(dr["COMP_VOUCHER_NET_AMOUNT"].ToString());
                    if (dr["PREPARED_DATE"].ToString() != "")
                    {
                        oLedg.strVDDate = Convert.ToDateTime(dr["PREPARED_DATE"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        oLedg.strVDDate = "";
                    }
                    oLedg.strSALESREP = dr["Sales_Rep"].ToString();
                    oLedg.strOrderNo = dr["ORDER_NO"].ToString();
                    oLedg.strOrderDate = Convert.ToDateTime(dr["ORDER_DATE"]).ToString("dd-MM-yyyy");
                    oLedg.intSalesQty = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());
                    oLedg.intBonusQty = Convert.ToDouble(dr["BILL_QUANTITY_BONUS"].ToString());
                    oLedg.DblBillRate = Convert.ToDouble(dr["BILL_RATE"].ToString());
                    oLedg.DblBillAmount = Convert.ToDouble(dr["BILL_AMOUNT"].ToString());
                    oLedg.DblGCommPer = Convert.ToDouble(dr["G_COMM_PER"].ToString());
                    oLedg.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.strPowrClass = dr["POWER_CLASS"].ToString();
                    oLedg.strStockGroupName = dr["STOCKGROUP_NAME"].ToString();
                    oLedg.strStockCategoryName = dr["STOCKCATEGORY_NAME"].ToString();
                    oLedg.strAddress1 = dr["LEDGER_ADDRESS11"].ToString();
                    oLedg.strTerritorycode = dr["TERITORRY_CODE"].ToString();
                    oLedg.strLedgerTerritory = dr["TERRITORRY_NAME"].ToString();
                    if (dr["PREPARED_BY"].ToString() != "")
                    {
                        oLedg.strParyName = dr["PREPARED_BY"].ToString();
                    }
                    else
                    {
                        oLedg.strParyName = "";
                    }

                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strRefNo = "";
                    oLedg.strLedgername = "";
                    oLedg.strVoucheDate = "";
                    oLedg.DblVNetAmt = 0;
                    oLedg.strVDDate = "";
                    oLedg.strSALESREP = "";
                    oLedg.strOrderNo = "";
                    oLedg.strOrderDate = "";
                    oLedg.intSalesQty = 0;
                    oLedg.intBonusQty = 0;
                    oLedg.DblBillRate = 0;
                    oLedg.DblBillAmount = 0;
                    oLedg.DblGCommPer = 0;
                    oLedg.strStockItemName = "";
                    oLedg.strPowrClass = "";
                    oLedg.strStockGroupName = "";
                    oLedg.strStockCategoryName = "";
                    oLedg.strParyName = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region Sales  Invoice
        public List<RProductSales> mGetSalesInvoice(string strDeComID, string strSALESREP)
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

                List<RProductSales> ooAccLedger = new List<RProductSales>();

                strSQL = "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DUE_DATE, ";
                strSQL = strSQL + "ACC_COMPANY_VOUCHER.SALES_REP, ACC_COMPANY_VOUCHER.ORDER_NO, ACC_COMPANY_VOUCHER.ORDER_DATE, ACC_BILL_TRAN.BILL_QUANTITY, ACC_BILL_TRAN.BILL_QUANTITY_BONUS, ";
                strSQL = strSQL + "ACC_BILL_TRAN.BILL_RATE, ACC_BILL_TRAN.BILL_AMOUNT, ACC_BILL_TRAN.G_COMM_PER, INV_STOCKITEM.STOCKITEM_NAME, INV_STOCKITEM.POWER_CLASS, INV_STOCKITEM.STOCKGROUP_NAME, ";
                strSQL = strSQL + "INV_STOCKITEM.STOCKCATEGORY_NAME, ISNULL(LTB.TERITORRY_CODE, '') + '-' + ISNULL(LTB.LEDGER_NAME, '') + '-' + ISNULL(LTB.TERRITORRY_NAME, '') AS LedgerN, ";
                strSQL = strSQL + "ISNULL(CTB.LEDGER_CODE, '') +'-'+ ISNULL(CTB.LEDGER_NAME, '') +'-'+ ISNULL(CTB.HOMOEO_HALL, '') AS Party , ACC_COMPANY_VOUCHER.PREPARED_DATE ";
                strSQL = strSQL + "FROM  ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER INNER JOIN ";
                strSQL = strSQL + "ACC_BILL_TRAN AS ACC_BILL_TRAN ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO INNER JOIN ";
                strSQL = strSQL + "INV_STOCKITEM AS INV_STOCKITEM ON ACC_BILL_TRAN.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
                strSQL = strSQL + "(SELECT TERITORRY_CODE, TERRITORRY_NAME, LEDGER_NAME ";
                strSQL = strSQL + "FROM  ACC_LEDGER ";
                strSQL = strSQL + "WHERE (LEDGER_GROUP = 202)) AS LTB ON ACC_COMPANY_VOUCHER.LEDGER_NAME = LTB.LEDGER_NAME LEFT OUTER JOIN ";
                strSQL = strSQL + "(SELECT LEDGER_CODE, HOMOEO_HALL, LEDGER_NAME ";
                strSQL = strSQL + "FROM ACC_LEDGER AS ACC_LEDGER_1 ";
                strSQL = strSQL + "WHERE (LEDGER_GROUP = 204)) AS CTB ON ACC_COMPANY_VOUCHER.SALES_REP = CTB.LEDGER_NAME ";
                strSQL = strSQL + "AND (ACC_COMPANY_VOUCHER.SALES_REP <> '') AND (ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = 16) ";
                if (strSALESREP != "")
                {
                    strSQL = strSQL + "AND(ACC_COMPANY_VOUCHER.SALES_REP = '" + strSALESREP + "') ";
                }
                //strSQL = strSQL + "AND (ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + "))";
                strSQL = strSQL + "ORDER BY ACC_COMPANY_VOUCHER.SALES_REP ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strRefNo = dr["COMP_REF_NO"].ToString();
                    oLedg.strLedgername = dr["LedgerN"].ToString();
                    oLedg.strVoucheDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    oLedg.DblVNetAmt = Convert.ToDouble(dr["COMP_VOUCHER_NET_AMOUNT"].ToString());
                    if (dr["PREPARED_DATE"].ToString() != "")
                    {
                        oLedg.strVDDate = Convert.ToDateTime(dr["PREPARED_DATE"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        oLedg.strVDDate = "";
                    }
                    oLedg.strSALESREP = dr["Party"].ToString();
                    if (dr["ORDER_NO"].ToString() != "")
                    {
                        oLedg.strOrderNo = dr["ORDER_NO"].ToString();
                    }
                    else
                    {
                        oLedg.strOrderNo = "";
                    }
                    if (dr["ORDER_DATE"].ToString() != "")
                    {
                        oLedg.strOrderDate = Convert.ToDateTime(dr["ORDER_DATE"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        oLedg.strOrderDate = "";
                    }
                    oLedg.intSalesQty = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());
                    oLedg.intBonusQty = Convert.ToDouble(dr["BILL_QUANTITY_BONUS"].ToString());
                    oLedg.DblBillRate = Convert.ToDouble(dr["BILL_RATE"].ToString());
                    oLedg.DblBillAmount = Convert.ToDouble(dr["BILL_AMOUNT"].ToString());
                    if (dr["G_COMM_PER"].ToString() != "")
                    {
                        oLedg.DblGCommPer = Convert.ToDouble(dr["G_COMM_PER"].ToString());
                    }
                    else
                    {
                        oLedg.DblGCommPer = 0;
                    }
                    oLedg.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                    if (dr["POWER_CLASS"].ToString() != "")
                    {
                        oLedg.strPowrClass = dr["POWER_CLASS"].ToString();
                    }
                    else
                    {
                        oLedg.strPowrClass = "";
                    }
                    oLedg.strStockGroupName = dr["STOCKGROUP_NAME"].ToString();
                    if (dr["STOCKCATEGORY_NAME"].ToString() != "")
                    {
                        oLedg.strStockCategoryName = dr["STOCKCATEGORY_NAME"].ToString();
                    }
                    else
                    {
                        oLedg.strStockCategoryName = "";
                    }
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strRefNo = "";
                    oLedg.strLedgername = "";
                    oLedg.strVoucheDate = "";
                    oLedg.DblVNetAmt = 0;
                    oLedg.strVDDate = "";
                    oLedg.strSALESREP = "";
                    oLedg.strOrderNo = "";
                    oLedg.strOrderDate = "";
                    oLedg.intSalesQty = 0;
                    oLedg.intBonusQty = 0;
                    oLedg.DblBillRate = 0;
                    oLedg.DblBillAmount = 0;
                    oLedg.DblGCommPer = 0;
                    oLedg.strStockItemName = "";
                    oLedg.strPowrClass = "";
                    oLedg.strStockGroupName = "";
                    oLedg.strStockCategoryName = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                System.Net.ServicePointManager.Expect100Continue = false;
                return ooAccLedger;
            }
        }
        #endregion
        #region "Special party"
        public List<RProductSales> mGetPartyProductSalesAmount(string strDeComID, string strFDate, string strTDate, string strString, string strledgerName, int intmode, string strCustomerName)
        {
            //Customer  intmode =1
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

                List<RProductSales> ooAccLedger = new List<RProductSales>();
                //intmode 1= GroupWise, 2= MpoWise 
                if (intmode == 2)
                {


                    strSQL = "SELECT ACC_BILL_TRAN.BILL_QUANTITY, ACC_BILL_TRAN.BILL_QUANTITY_BONUS, INV_STOCKITEM.STOCKITEM_NAME, INV_STOCKITEM.POWER_CLASS, INV_STOCKITEM.STOCKGROUP_NAME, ";
                    strSQL = strSQL + "INV_STOCKITEM.STOCKCATEGORY_NAME, ACC_BRANCH.BRANCH_NAME, ACC_LEDGER.LEDGER_NAME_MERZE, ACC_LEDGER.LEDGER_PARENT_GROUP, TB1.LEDGER_NAME_MERZE AS Customer, TB1.LEDGER_NAME, ";
                    strSQL = strSQL + "TB1.LEDGER_PARENT_GROUP AS CustomerParent, TB1.LEDGER_PRIMARY_GROUP ";
                    strSQL = strSQL + "FROM  ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER AS ACC_LEDGER ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN AS ACC_BILL_TRAN ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM AS INV_STOCKITEM ON ACC_BILL_TRAN.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID INNER JOIN ";
                    strSQL = strSQL + "(SELECT  LEDGER_NAME, LEDGER_NAME_MERZE, LEDGER_ADDRESS1, LEDGER_ADDRESS2, LEDGER_PARENT_GROUP, LEDGER_PRIMARY_GROUP ";
                    strSQL = strSQL + "FROM  ACC_LEDGER AS ACC_LEDGER_1 ";
                    strSQL = strSQL + "WHERE  (LEDGER_GROUP = 204)) AS TB1 ON ACC_COMPANY_VOUCHER.SALES_REP = TB1.LEDGER_NAME ";
                    strSQL = strSQL + "WHERE (ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) AND (ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = 16) AND ";
                    strSQL = strSQL + "(ACC_COMPANY_VOUCHER.SALES_REP <> '') AND (ACC_BILL_TRAN.BRANCH_ID = '0001') ";
                    //strSQL = strSQL + "ORDER BY ACC_COMPANY_VOUCHER.LEDGER_NAME, INV_STOCKITEM.STOCKGROUP_NAME, INV_STOCKITEM.POWER_CLASS, INV_STOCKITEM.STOCKITEM_NAME ";


                    if (strCustomerName != "")
                    {
                        strSQL = strSQL + "AND TB1.LEDGER_NAME_MERZE IN (" + strCustomerName + ") ";
                    }
                    if (strledgerName != "")
                    {

                        strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_NAME_MERZE = '" + strledgerName + "') ";

                    }

                    if (strString != "Customer")
                    {
                        if (strString != "")
                        {
                            strSQL = strSQL + "AND( TB1.LEDGER_PARENT_GROUP = '" + strString + "')";
                        }

                    }
                    if (strString == "Customer")
                    {
                        if (strString != "")
                        {
                            strSQL = strSQL + "AND(TB1.LEDGER_PRIMARY_GROUP = '" + strString + "')";
                        }

                    }
                    //strSQL = strSQL + "ORDER BY ACC_COMPANY_VOUCHER.LEDGER_NAME, INV_STOCKITEM.STOCKGROUP_NAME, INV_STOCKITEM.POWER_CLASS, INV_STOCKITEM.STOCKITEM_NAME ";
                }
                if (intmode == 1)
                {

                    strSQL = "SELECT tb2.BILL_QUANTITY, tb2.BILL_QUANTITY_BONUS, tb2.STOCKITEM_NAME, tb2.POWER_CLASS, tb2.STOCKGROUP_NAME, tb2.STOCKCATEGORY_NAME, tb2.BRANCH_NAME, tb2.LEDGER_NAME_MERZE,";
                    strSQL = strSQL + "tb2.LEDGER_PARENT_GROUP, tb2.Customer, tb2.LEDGER_NAME, tb2.CustomerParent, tb2.LEDGER_PRIMARY_GROUP, tb2.MPOName, tb3.GR_NAME ";
                    strSQL = strSQL + "FROM  (SELECT TOP (100) PERCENT ACC_BILL_TRAN.BILL_QUANTITY, ACC_BILL_TRAN.BILL_QUANTITY_BONUS, INV_STOCKITEM.STOCKITEM_NAME, INV_STOCKITEM.POWER_CLASS, INV_STOCKITEM.STOCKGROUP_NAME, ";
                    strSQL = strSQL + "INV_STOCKITEM.STOCKCATEGORY_NAME, ACC_BRANCH.BRANCH_NAME, ACC_LEDGER.LEDGER_NAME_MERZE, ACC_LEDGER.LEDGER_PARENT_GROUP, TB1.LEDGER_NAME_MERZE AS Customer, ";
                    strSQL = strSQL + "TB1.LEDGER_NAME, TB1.LEDGER_PARENT_GROUP AS CustomerParent, TB1.LEDGER_PRIMARY_GROUP, ACC_LEDGER.LEDGER_NAME AS MPOName ";
                    strSQL = strSQL + "FROM  ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER AS ACC_LEDGER ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN AS ACC_BILL_TRAN ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM AS INV_STOCKITEM ON ACC_BILL_TRAN.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID INNER JOIN ";
                    strSQL = strSQL + "(SELECT LEDGER_NAME, LEDGER_NAME_MERZE, LEDGER_ADDRESS1, LEDGER_ADDRESS2, LEDGER_PARENT_GROUP, LEDGER_PRIMARY_GROUP ";
                    strSQL = strSQL + "FROM  ACC_LEDGER AS ACC_LEDGER_1 ";
                    strSQL = strSQL + "WHERE (LEDGER_GROUP = 204)) AS TB1 ON ACC_COMPANY_VOUCHER.SALES_REP = TB1.LEDGER_NAME ";
                    strSQL = strSQL + "WHERE (ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) AND (ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = 16) ";
                    strSQL = strSQL + "AND (ACC_COMPANY_VOUCHER.SALES_REP <> '') AND (ACC_BILL_TRAN.BRANCH_ID = '0001') ";
                    strSQL = strSQL + "ORDER BY ACC_COMPANY_VOUCHER.LEDGER_NAME, INV_STOCKITEM.STOCKGROUP_NAME, INV_STOCKITEM.POWER_CLASS, INV_STOCKITEM.STOCKITEM_NAME) AS tb2 INNER JOIN ";
                    strSQL = strSQL + "(SELECT LEDGER_NAME, GR_NAME ";
                    strSQL = strSQL + "FROM  ACC_LEDGER_TO_GROUP) AS tb3 ON tb2.MPOName = tb3.LEDGER_NAME ";


                    if (strCustomerName != "")
                    {
                        strSQL = strSQL + "AND TB1.LEDGER_NAME_MERZE IN (" + strCustomerName + ") ";
                    }
                    if (strledgerName != "")
                    {

                        strSQL = strSQL + "AND (tb3.GR_NAME  = '" + strledgerName + "') ";

                    }

                    if (strString != "Customer")
                    {
                        if (strString != "")
                        {
                            strSQL = strSQL + "AND( tb2.CustomerParent = '" + strString + "')";
                        }

                    }
                    if (strString == "Customer")
                    {
                        if (strString != "")
                        {
                            strSQL = strSQL + "AND(tb2.LEDGER_PRIMARY_GROUP = '" + strString + "')";
                        }

                    }
                    //strSQL = strSQL + "ORDER BY ACC_COMPANY_VOUCHER.LEDGER_NAME, INV_STOCKITEM.STOCKGROUP_NAME, INV_STOCKITEM.POWER_CLASS, INV_STOCKITEM.STOCKITEM_NAME ";
                }
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    RProductSales oLedg = new RProductSales();
                    oLedg.strLedgername = dr["LEDGER_NAME_MERZE"].ToString();
                    oLedg.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.strPowrClass = dr["POWER_CLASS"].ToString();
                    //oLedg.DblBillAmount = Convert.ToDouble(dr["COMP_VOUCHER_NET_AMOUNT"].ToString());
                    oLedg.DblBillQty = Convert.ToDouble(dr["BILL_QUANTITY"].ToString());
                    oLedg.DblBillQtyBonus = Convert.ToDouble(dr["BILL_QUANTITY_BONUS"].ToString());
                    oLedg.strStockGroupName = dr["STOCKGROUP_NAME"].ToString();
                    oLedg.strStockCategoryName = dr["STOCKCATEGORY_NAME"].ToString();
                    //oLedg.strAddress1 = dr["LEDGER_NAME_MERZE"].ToString() + dr["LEDGER_ADDRESS1"].ToString();
                    oLedg.strLedgerGroupName = dr["LEDGER_PARENT_GROUP"].ToString();
                    oLedg.strBranchName = dr["BRANCH_NAME"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strLedgername = "";
                    oLedg.strRefNo = "";
                    oLedg.strVoucheDate = "";
                    oLedg.DblBillP = 0;
                    oLedg.strOrderNo = "";
                    oLedg.strSALESREP = "";
                    oLedg.strAddress1 = "";
                    oLedg.strAddress2 = "";
                    oLedg.strBranchName = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }

        public List<RProductSales> mGetPartyLoad(string strDeComID, string strString, string strledgerName, int intmode)
        {
            //Customer  intmode =1
            string strmode = "";
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

                List<RProductSales> ooAccLedger = new List<RProductSales>();


                if (strledgerName != "")
                {
                    if (Utility.Left(strledgerName, 1).ToUpper() == "D" || Utility.Left(strledgerName, 1).ToUpper() == "R")
                    {
                        strmode = "D";
                    }
                    if (Utility.Left(strledgerName, 1).ToUpper() == "Z")
                    {
                        strmode = "Z";
                    }
                    if (Utility.Left(strledgerName, 1).ToUpper() == "A" || Utility.Left(strledgerName, 1).ToUpper() == "F")
                    {
                        strmode = "F";
                    }
                    if (strledgerName == "Sundry Debtors")
                    {
                        strmode = "S";
                    }
                }

                if (intmode == 1)
                {
                    strSQL = " SELECT    distinct    ACC_LEDGER.LEDGER_NAME_MERZE, ACC_LEDGER.LEDGER_REP_NAME ";
                    strSQL = strSQL + "FROM   ACC_LEDGER INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_TO_GROUP ON ACC_LEDGER.LEDGER_REP_NAME = ACC_LEDGER_TO_GROUP.LEDGER_NAME ";
                    if (strledgerName != "")
                    {
                        strSQL = strSQL + "WHERE (ACC_LEDGER.LEDGER_REP_NAME = '" + strledgerName + "') ";
                    }
                    if (strString != "")
                    {
                        if (strString != "Customer")
                        {
                            strSQL = strSQL + "and  ACC_LEDGER.LEDGER_PARENT_GROUP ='" + strString + "' ";
                        }
                    }
                    strSQL = strSQL + "order by ACC_LEDGER.LEDGER_NAME_MERZE ";
                }

                if (intmode == 0)
                {

                    strSQL = "select * from ACC_LEDGER L, ACC_CUSTOMER_LIST C ,ACC_LEDGER_Z_D_A G ";
                    strSQL = strSQL + "where L.LEDGER_GROUP=204 and L.LEDGER_NAME=C.LEDGER_NAME and L.LEDGER_REP_NAME=G.LEDGER_NAME ";
                    if (strledgerName != "")
                    {

                        if (strmode == "D")
                        {
                            strSQL = strSQL + "AND (G.ZONE  = '" + strledgerName + "') ";
                        }
                        if (strmode == "Z")
                        {
                            strSQL = strSQL + "AND (G.DIVISION  = '" + strledgerName + "') ";
                        }
                        if (strmode == "F")
                        {
                            strSQL = strSQL + "AND (G.AREA  = '" + strledgerName + "') ";
                        }
                        if (strmode == "S")
                        {
                            //strSQL = strSQL + "AND (ACC_LEDGER_Z_D_A.LEDGER_NAME  = '" + strledgerName + "') ";
                        }
                    }
                    if (strString != "")
                    {
                        if (strString != "Customer")
                        {
                            strSQL = strSQL + "and  C.LEDGER_PARENT_GROUP ='" + strString + "' ";
                        }
                        else
                        {
                            strSQL = strSQL + "and  C.LEDGER_PRIMARY_GROUP ='" + strString + "' ";
                        }
                    }
                }


                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strLedgername = dr["LEDGER_NAME_MERZE"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strLedgername = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }



        public List<RProductSales> mGetSpecialPartyGroup(string strDeComID)
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

                List<RProductSales> ooAccLedger = new List<RProductSales>();
                strSQL = "SELECT GR_NAME from ACC_LEDGERGROUP where GR_GROUP=204 order by GR_NAME desc";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strLedgerGroupName = dr["GR_NAME"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strLedgerGroupName = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region "SpecialProductLoad"

        public List<RProductSales> mGetSpecialProductLoad(string strDeComID, int intMode)
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

                List<RProductSales> ooAccLedger = new List<RProductSales>();
                if (intMode == 1)
                {
                    strSQL = "SELECT STOCKITEM_NAME FROM INV_STOCKITEM WHERE (SP_ITEM = 1)ORDER BY STOCKITEM_NAME ";
                }
                else
                {
                    strSQL = "SELECT distinct STOCKCATEGORY_NAME as STOCKITEM_NAME FROM INV_STOCKITEM WHERE (SP_ITEM = 1) and  STOCKCATEGORY_NAME <> ''  ORDER BY STOCKCATEGORY_NAME  ";
                }
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strStockItemName = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region "Spcial Product (pack Size Wise)"
        public List<RProductSales> mGetSpcialProductPackSiseWise(string strDeComID, string strFdate, string strTdate, string PreMonth, string strGroupName, string strPartyName, string strProductSelection, int intstatus, int intMode)
        {
            string strSQL = null, strSelection = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                List<RProductSales> ooAccLedger = new List<RProductSales>();
                SqlDataReader dr;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;
                strSQL = "DELETE FROM SPECIAL_PROEUCT_TEMP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                if (strGroupName != "")
                {
                    strSelection = strGroupName.Substring(0, 1).ToUpper();
                }

                if (intMode == 2)
                {

                    strSQL = "INSERT INTO SPECIAL_PROEUCT_TEMP(ZONE_NAME,DIVISION_NAME,AREA_NAME,LEDGER_MERZE_NAME,STOCK_GROUP_NAME,STOCK_ITEM_NAME,STOCK_CATEGORY_NAME,PRE_TARGET_AMOUNT) ";
                    strSQL = strSQL + "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME,sum( B.BILL_QUANTITY) amnt from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER cv, ";
                    strSQL = strSQL + "INV_STOCKITEM S,ACC_BILL_TRAN B where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and S.STOCKITEM_NAME =B.STOCKITEM_NAME  ";
                    strSQL = strSQL + "and cv.COMP_REF_NO= b.COMP_REF_NO and l.LEDGER_NAME=cv.LEDGER_NAME ";
                    strSQL = strSQL + "AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 AND  B.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " and ";
                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strTdate) + "  ";
                    strSQL = strSQL + "GROUP BY g.GR_PARENT , 	  g.GR_NAME, l.LEDGER_PARENT_GROUP, l.LEDGER_NAME_MERZE,s.STOCKGROUP_NAME, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME  ";
                }
                else
                {
                    strSQL = "INSERT INTO SPECIAL_PROEUCT_TEMP(ZONE_NAME,DIVISION_NAME,AREA_NAME,LEDGER_MERZE_NAME,STOCK_GROUP_NAME,STOCK_ITEM_NAME,STOCK_CATEGORY_NAME,PRE_TARGET_AMOUNT) ";
                    strSQL = strSQL + "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME,sum( B.BILL_QUANTITY) amnt from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER cv, ";
                    strSQL = strSQL + "INV_STOCKITEM S,ACC_BILL_TRAN B where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and S.STOCKITEM_NAME =B.STOCKITEM_NAME  ";
                    strSQL = strSQL + "and cv.COMP_REF_NO= b.COMP_REF_NO and l.LEDGER_NAME=cv.LEDGER_NAME ";
                    strSQL = strSQL + "AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 AND  B.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " and ";
                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strTdate) + "  ";
                    strSQL = strSQL + "GROUP BY g.GR_PARENT , 	  g.GR_NAME, l.LEDGER_PARENT_GROUP, l.LEDGER_NAME_MERZE,s.STOCKGROUP_NAME, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME  ";

                }

                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Transaction.Commit();

                if (intMode == 3)
                {

                    strSQL = "SELECT  LEDGER_MERZE_NAME, STOCK_ITEM_NAME, MONTH_ID, STOCK_CATEGORY_NAME, SUM(PRE_TARGET_AMOUNT) AS Target ";
                    strSQL = strSQL + "FROM   SPECIAL_PROEUCT_TEMP ";

                    if (strProductSelection != "")
                    {
                        if (intMode == 2)
                        {
                            strSQL = strSQL + "where (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                        }
                        else
                        {
                            strSQL = strSQL + "where (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                        }
                    }
                    strSQL = strSQL + "GROUP BY LEDGER_MERZE_NAME, STOCK_ITEM_NAME, MONTH_ID, STOCK_CATEGORY_NAME, ZONE_NAME ";
                    strSQL = strSQL + "HAVING (SUM(PRE_TARGET_AMOUNT) > '0') ";

                }

                if (intMode == 2)
                {

                    strSQL = "SELECT  LEDGER_MERZE_NAME, STOCK_ITEM_NAME, MONTH_ID, STOCK_CATEGORY_NAME, SUM(PRE_TARGET_AMOUNT) AS Target ";
                    strSQL = strSQL + "FROM   SPECIAL_PROEUCT_TEMP ";

                    if (strProductSelection != "")
                    {
                        if (intMode == 2)
                        {
                            strSQL = strSQL + "where (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                        }
                        else
                        {
                            strSQL = strSQL + "where (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                        }
                    }
                    strSQL = strSQL + "GROUP BY LEDGER_MERZE_NAME, STOCK_ITEM_NAME, MONTH_ID, STOCK_CATEGORY_NAME, ZONE_NAME ";
                    strSQL = strSQL + "HAVING (SUM(PRE_TARGET_AMOUNT) > '0') ";

                }
                if (strGroupName != "")
                {

                    strSQL = "SELECT  LEDGER_MERZE_NAME, STOCK_ITEM_NAME, MONTH_ID, STOCK_CATEGORY_NAME, SUM(PRE_TARGET_AMOUNT) AS Target ";
                    strSQL = strSQL + "FROM   SPECIAL_PROEUCT_TEMP ";

                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "WHERE (ZONE_NAME =  '" + strGroupName + "') ";
                    }
                    else if (strSelection == "D")
                    {

                        strSQL = strSQL + "WHERE (DIVISION_NAME =  '" + strGroupName + "') ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "WHERE (DIVISION_NAME =  '" + strGroupName + "') ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "WHERE (AREA_NAME =  '" + strGroupName + "') ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "WHERE (AREA_NAME =  '" + strGroupName + "') ";
                    }

                    if (strProductSelection != "")
                    {
                        if (intMode == 2)
                        {
                            strSQL = strSQL + "and  (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                        }
                        else
                        {
                            strSQL = strSQL + "and (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                        }
                    }
                    strSQL = strSQL + "GROUP BY LEDGER_MERZE_NAME, STOCK_ITEM_NAME, MONTH_ID, STOCK_CATEGORY_NAME, ZONE_NAME ";
                    strSQL = strSQL + "HAVING (SUM(PRE_TARGET_AMOUNT) > '0') ";
                }
                if (strPartyName != "")
                {
                    {
                        strSQL = "SELECT  LEDGER_MERZE_NAME, STOCK_ITEM_NAME, MONTH_ID, STOCK_CATEGORY_NAME, SUM(PRE_TARGET_AMOUNT) AS Target ";
                        strSQL = strSQL + "FROM   SPECIAL_PROEUCT_TEMP ";
                        strSQL = strSQL + "WHERE (LEDGER_MERZE_NAME =  '" + strPartyName + "') ";
                    }
                    if (strProductSelection != "")
                    {
                        if (intMode == 2)
                        {
                            strSQL = strSQL + "and (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                        }
                        else
                        {
                            strSQL = strSQL + "and (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                        }
                    }
                    strSQL = strSQL + "GROUP BY LEDGER_MERZE_NAME, STOCK_ITEM_NAME, MONTH_ID, STOCK_CATEGORY_NAME, ZONE_NAME ";
                    strSQL = strSQL + "HAVING (SUM(PRE_TARGET_AMOUNT) > '0') ";
                }
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strLedgername = dr["LEDGER_MERZE_NAME"].ToString();
                    if (dr["STOCK_ITEM_NAME"].ToString() != "")
                    {
                        oLedg.strStockCategoryName = dr["STOCK_ITEM_NAME"].ToString();
                    }
                    if (dr["STOCK_CATEGORY_NAME"].ToString() != "")
                    {
                        if (intMode == 2)
                        {
                            oLedg.strStockCategoryName = dr["STOCK_CATEGORY_NAME"].ToString();
                        }
                    }
                    if (dr["Target"].ToString() != "")
                    {
                        oLedg.DblBillAmount = Convert.ToDouble(dr["Target"].ToString());
                    }
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region "Spcial Product (12 Month Sales)"
        public List<RProductSales> mGetSpcialProduct12MonthSales(string strDeComID, string strFdate, string strTdate, int intMonth, string strGroupName, string strPartyName, string strProductSelection, int intstatus, int intMode)
        {

            string strSQL = null;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            DateTime dteMonthDate = Convert.ToDateTime(strFdate);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;

                string strSelection = "";

                if (strGroupName != "")
                {
                    strSelection = strGroupName.Substring(0, 1).ToUpper();
                }


                List<RProductSales> ooAccLedger = new List<RProductSales>();

                if (intMonth == 1)
                {
                    strSQL = "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME,MONTH(CV.COMP_VOUCHER_DATE) monthpos, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 1 THEN B.BILL_QUANTITY ELSE 0 END) AS [1st], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 2 THEN B.BILL_QUANTITY ELSE 0 END) AS [2nd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 3 THEN B.BILL_QUANTITY ELSE 0 END) AS [3rd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 4 THEN B.BILL_QUANTITY ELSE 0 END) AS [4th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 5 THEN B.BILL_QUANTITY ELSE 0 END) AS [5th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 6 THEN B.BILL_QUANTITY ELSE 0 END) AS [6th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 7 THEN B.BILL_QUANTITY ELSE 0 END) AS [7th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 8 THEN B.BILL_QUANTITY ELSE 0 END) AS [8th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 9 THEN B.BILL_QUANTITY ELSE 0 END) AS [9th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 10 THEN B.BILL_QUANTITY ELSE 0 END) AS [10th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 11 THEN B.BILL_QUANTITY ELSE 0 END) AS [11th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 12 THEN B.BILL_QUANTITY ELSE 0 END) AS [12th] ";
                    strSQL = strSQL + "from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S,ACC_BILL_TRAN B ,ACC_COMPANY_VOUCHER CV  ";
                    strSQL = strSQL + "where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and S.STOCKITEM_NAME =B.STOCKITEM_NAME  AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 and CV.LEDGER_NAME= l.LEDGER_NAME ";
                    strSQL = strSQL + "AND  B.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " and " + Utility.cvtSQLDateString(strTdate) + " and B.COMP_REF_NO= CV.COMP_REF_NO ";
                }
                else if (intMonth == 2)
                {
                    strSQL = "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME,MONTH(CV.COMP_VOUCHER_DATE) monthpos, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 2 THEN B.BILL_QUANTITY ELSE 0 END) AS [1st], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 3 THEN B.BILL_QUANTITY ELSE 0 END) AS [2nd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 4 THEN B.BILL_QUANTITY ELSE 0 END) AS [3rd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 5 THEN B.BILL_QUANTITY ELSE 0 END) AS [4th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 6 THEN B.BILL_QUANTITY ELSE 0 END) AS [5th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 7 THEN B.BILL_QUANTITY ELSE 0 END) AS [6th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 8 THEN B.BILL_QUANTITY ELSE 0 END) AS [7th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 9 THEN B.BILL_QUANTITY ELSE 0 END) AS [8th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 10 THEN B.BILL_QUANTITY ELSE 0 END) AS [9th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 11 THEN B.BILL_QUANTITY ELSE 0 END) AS [10th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 12 THEN B.BILL_QUANTITY ELSE 0 END) AS [11th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 1 THEN B.BILL_QUANTITY ELSE 0 END) AS [12th] ";
                    strSQL = strSQL + "from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S,ACC_BILL_TRAN B ,ACC_COMPANY_VOUCHER CV  ";
                    strSQL = strSQL + "where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and S.STOCKITEM_NAME =B.STOCKITEM_NAME  AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 and CV.LEDGER_NAME= l.LEDGER_NAME ";
                    strSQL = strSQL + "AND  B.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " and " + Utility.cvtSQLDateString(strTdate) + " and B.COMP_REF_NO= CV.COMP_REF_NO ";
                }
                else if (intMonth == 3)
                {
                    strSQL = "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME,MONTH(CV.COMP_VOUCHER_DATE) monthpos, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 3 THEN B.BILL_QUANTITY ELSE 0 END) AS [1st], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 4 THEN B.BILL_QUANTITY ELSE 0 END) AS [2nd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 5 THEN B.BILL_QUANTITY ELSE 0 END) AS [3rd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 6 THEN B.BILL_QUANTITY ELSE 0 END) AS [4th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 7 THEN B.BILL_QUANTITY ELSE 0 END) AS [5th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 8 THEN B.BILL_QUANTITY ELSE 0 END) AS [6th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 9 THEN B.BILL_QUANTITY ELSE 0 END) AS [7th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 10 THEN B.BILL_QUANTITY ELSE 0 END) AS [8th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 11 THEN B.BILL_QUANTITY ELSE 0 END) AS [9th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 12 THEN B.BILL_QUANTITY ELSE 0 END) AS [10th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 1 THEN B.BILL_QUANTITY ELSE 0 END) AS [11th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 2 THEN B.BILL_QUANTITY ELSE 0 END) AS [12th] ";
                    strSQL = strSQL + "from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S,ACC_BILL_TRAN B ,ACC_COMPANY_VOUCHER CV  ";
                    strSQL = strSQL + "where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and S.STOCKITEM_NAME =B.STOCKITEM_NAME  AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 and CV.LEDGER_NAME= l.LEDGER_NAME ";
                    strSQL = strSQL + "AND  B.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " and " + Utility.cvtSQLDateString(strTdate) + " and B.COMP_REF_NO= CV.COMP_REF_NO ";
                }
                else if (intMonth == 4)
                {
                    strSQL = "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME,MONTH(CV.COMP_VOUCHER_DATE) monthpos, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 4 THEN B.BILL_QUANTITY ELSE 0 END) AS [1st], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 5 THEN B.BILL_QUANTITY ELSE 0 END) AS [2nd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 6 THEN B.BILL_QUANTITY ELSE 0 END) AS [3rd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 7 THEN B.BILL_QUANTITY ELSE 0 END) AS [4th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 8 THEN B.BILL_QUANTITY ELSE 0 END) AS [5th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 9 THEN B.BILL_QUANTITY ELSE 0 END) AS [6th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 10 THEN B.BILL_QUANTITY ELSE 0 END) AS [7th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 11 THEN B.BILL_QUANTITY ELSE 0 END) AS [8th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 12 THEN B.BILL_QUANTITY ELSE 0 END) AS [9th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 1 THEN B.BILL_QUANTITY ELSE 0 END) AS [10th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 2 THEN B.BILL_QUANTITY ELSE 0 END) AS [11th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 3 THEN B.BILL_QUANTITY ELSE 0 END) AS [12th] ";
                    strSQL = strSQL + "from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S,ACC_BILL_TRAN B ,ACC_COMPANY_VOUCHER CV  ";
                    strSQL = strSQL + "where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and S.STOCKITEM_NAME =B.STOCKITEM_NAME  AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 and CV.LEDGER_NAME= l.LEDGER_NAME ";
                    strSQL = strSQL + "AND  B.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " and " + Utility.cvtSQLDateString(strTdate) + " and B.COMP_REF_NO= CV.COMP_REF_NO ";
                }
                else if (intMonth == 5)
                {
                    strSQL = "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME,MONTH(CV.COMP_VOUCHER_DATE) monthpos, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 5 THEN B.BILL_QUANTITY ELSE 0 END) AS [1st], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 6 THEN B.BILL_QUANTITY ELSE 0 END) AS [2nd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 7 THEN B.BILL_QUANTITY ELSE 0 END) AS [3rd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 8 THEN B.BILL_QUANTITY ELSE 0 END) AS [4th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 9 THEN B.BILL_QUANTITY ELSE 0 END) AS [5th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 10 THEN B.BILL_QUANTITY ELSE 0 END) AS [6th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 11 THEN B.BILL_QUANTITY ELSE 0 END) AS [7th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 12 THEN B.BILL_QUANTITY ELSE 0 END) AS [8th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 1 THEN B.BILL_QUANTITY ELSE 0 END) AS [9th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 2 THEN B.BILL_QUANTITY ELSE 0 END) AS [10th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 3 THEN B.BILL_QUANTITY ELSE 0 END) AS [11th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 4 THEN B.BILL_QUANTITY ELSE 0 END) AS [12th] ";
                    strSQL = strSQL + "from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S,ACC_BILL_TRAN B ,ACC_COMPANY_VOUCHER CV  ";
                    strSQL = strSQL + "where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and S.STOCKITEM_NAME =B.STOCKITEM_NAME  AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 and CV.LEDGER_NAME= l.LEDGER_NAME ";
                    strSQL = strSQL + "AND  B.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " and " + Utility.cvtSQLDateString(strTdate) + " and B.COMP_REF_NO= CV.COMP_REF_NO ";
                }
                else if (intMonth == 6)
                {
                    strSQL = "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME,MONTH(CV.COMP_VOUCHER_DATE) monthpos, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 6 THEN B.BILL_QUANTITY ELSE 0 END) AS [1st], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 7 THEN B.BILL_QUANTITY ELSE 0 END) AS [2nd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 8 THEN B.BILL_QUANTITY ELSE 0 END) AS [3rd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 9 THEN B.BILL_QUANTITY ELSE 0 END) AS [4th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 10 THEN B.BILL_QUANTITY ELSE 0 END) AS [5th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 11 THEN B.BILL_QUANTITY ELSE 0 END) AS [6th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 12 THEN B.BILL_QUANTITY ELSE 0 END) AS [7th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 1 THEN B.BILL_QUANTITY ELSE 0 END) AS [8th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 2 THEN B.BILL_QUANTITY ELSE 0 END) AS [9th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 3 THEN B.BILL_QUANTITY ELSE 0 END) AS [10th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 4 THEN B.BILL_QUANTITY ELSE 0 END) AS [11th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 5 THEN B.BILL_QUANTITY ELSE 0 END) AS [12th] ";
                    strSQL = strSQL + "from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S,ACC_BILL_TRAN B ,ACC_COMPANY_VOUCHER CV  ";
                    strSQL = strSQL + "where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and S.STOCKITEM_NAME =B.STOCKITEM_NAME  AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 and CV.LEDGER_NAME= l.LEDGER_NAME ";
                    strSQL = strSQL + "AND  B.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " and " + Utility.cvtSQLDateString(strTdate) + " and B.COMP_REF_NO= CV.COMP_REF_NO ";
                }
                else if (intMonth == 7)
                {
                    strSQL = "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME,MONTH(CV.COMP_VOUCHER_DATE) monthpos, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 7 THEN B.BILL_QUANTITY ELSE 0 END) AS [1st], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 8 THEN B.BILL_QUANTITY ELSE 0 END) AS [2nd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 9 THEN B.BILL_QUANTITY ELSE 0 END) AS [3rd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 10 THEN B.BILL_QUANTITY ELSE 0 END) AS [4th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 11 THEN B.BILL_QUANTITY ELSE 0 END) AS [5th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 12 THEN B.BILL_QUANTITY ELSE 0 END) AS [6th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 1 THEN B.BILL_QUANTITY ELSE 0 END) AS [7th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 2 THEN B.BILL_QUANTITY ELSE 0 END) AS [8th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 3 THEN B.BILL_QUANTITY ELSE 0 END) AS [9th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 4 THEN B.BILL_QUANTITY ELSE 0 END) AS [10th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 5 THEN B.BILL_QUANTITY ELSE 0 END) AS [11th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 6 THEN B.BILL_QUANTITY ELSE 0 END) AS [12th] ";
                    strSQL = strSQL + "from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S,ACC_BILL_TRAN B ,ACC_COMPANY_VOUCHER CV  ";
                    strSQL = strSQL + "where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and S.STOCKITEM_NAME =B.STOCKITEM_NAME  AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 and CV.LEDGER_NAME= l.LEDGER_NAME ";
                    strSQL = strSQL + "AND  B.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " and " + Utility.cvtSQLDateString(strTdate) + " and B.COMP_REF_NO= CV.COMP_REF_NO ";
                }
                else if (intMonth == 8)
                {
                    strSQL = "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME,MONTH(CV.COMP_VOUCHER_DATE) monthpos, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 8 THEN B.BILL_QUANTITY ELSE 0 END) AS [1st], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 9 THEN B.BILL_QUANTITY ELSE 0 END) AS [2nd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 10 THEN B.BILL_QUANTITY ELSE 0 END) AS [3rd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 11 THEN B.BILL_QUANTITY ELSE 0 END) AS [4th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 12 THEN B.BILL_QUANTITY ELSE 0 END) AS [5th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 1 THEN B.BILL_QUANTITY ELSE 0 END) AS [6th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 2 THEN B.BILL_QUANTITY ELSE 0 END) AS [7th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 3 THEN B.BILL_QUANTITY ELSE 0 END) AS [8th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 4 THEN B.BILL_QUANTITY ELSE 0 END) AS [9th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 5 THEN B.BILL_QUANTITY ELSE 0 END) AS [10th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 6 THEN B.BILL_QUANTITY ELSE 0 END) AS [11th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 7 THEN B.BILL_QUANTITY ELSE 0 END) AS [12th] ";
                    strSQL = strSQL + "from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S,ACC_BILL_TRAN B ,ACC_COMPANY_VOUCHER CV  ";
                    strSQL = strSQL + "where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and S.STOCKITEM_NAME =B.STOCKITEM_NAME  AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 and CV.LEDGER_NAME= l.LEDGER_NAME ";
                    strSQL = strSQL + "AND  B.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " and " + Utility.cvtSQLDateString(strTdate) + " and B.COMP_REF_NO= CV.COMP_REF_NO ";
                }
                else if (intMonth == 9)
                {
                    strSQL = "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME,MONTH(CV.COMP_VOUCHER_DATE) monthpos, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 9 THEN B.BILL_QUANTITY ELSE 0 END) AS [1st], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 10 THEN B.BILL_QUANTITY ELSE 0 END) AS [2nd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 11 THEN B.BILL_QUANTITY ELSE 0 END) AS [3rd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 12 THEN B.BILL_QUANTITY ELSE 0 END) AS [4th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 1 THEN B.BILL_QUANTITY ELSE 0 END) AS [5th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 2 THEN B.BILL_QUANTITY ELSE 0 END) AS [6th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 3 THEN B.BILL_QUANTITY ELSE 0 END) AS [7th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 4 THEN B.BILL_QUANTITY ELSE 0 END) AS [8th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 5 THEN B.BILL_QUANTITY ELSE 0 END) AS [9th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 6 THEN B.BILL_QUANTITY ELSE 0 END) AS [10th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 7 THEN B.BILL_QUANTITY ELSE 0 END) AS [11th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 8 THEN B.BILL_QUANTITY ELSE 0 END) AS [12th] ";
                    strSQL = strSQL + "from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S,ACC_BILL_TRAN B ,ACC_COMPANY_VOUCHER CV  ";
                    strSQL = strSQL + "where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and S.STOCKITEM_NAME =B.STOCKITEM_NAME  AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 and CV.LEDGER_NAME= l.LEDGER_NAME ";
                    strSQL = strSQL + "AND  B.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " and " + Utility.cvtSQLDateString(strTdate) + " and B.COMP_REF_NO= CV.COMP_REF_NO ";
                }
                else if (intMonth == 10)
                {
                    strSQL = "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME,MONTH(CV.COMP_VOUCHER_DATE) monthpos, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 10 THEN B.BILL_QUANTITY ELSE 0 END) AS [1st], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 11 THEN B.BILL_QUANTITY ELSE 0 END) AS [2nd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 12 THEN B.BILL_QUANTITY ELSE 0 END) AS [3rd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 1 THEN B.BILL_QUANTITY ELSE 0 END) AS [4th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 2 THEN B.BILL_QUANTITY ELSE 0 END) AS [5th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 3 THEN B.BILL_QUANTITY ELSE 0 END) AS [6th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 4 THEN B.BILL_QUANTITY ELSE 0 END) AS [7th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 5 THEN B.BILL_QUANTITY ELSE 0 END) AS [8th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 6 THEN B.BILL_QUANTITY ELSE 0 END) AS [9th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 7 THEN B.BILL_QUANTITY ELSE 0 END) AS [10th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 8 THEN B.BILL_QUANTITY ELSE 0 END) AS [11th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 9 THEN B.BILL_QUANTITY ELSE 0 END) AS [12th] ";
                    strSQL = strSQL + "from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S,ACC_BILL_TRAN B ,ACC_COMPANY_VOUCHER CV  ";
                    strSQL = strSQL + "where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and S.STOCKITEM_NAME =B.STOCKITEM_NAME  AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 and CV.LEDGER_NAME= l.LEDGER_NAME ";
                    strSQL = strSQL + "AND  B.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " and " + Utility.cvtSQLDateString(strTdate) + " and B.COMP_REF_NO= CV.COMP_REF_NO ";
                }
                else if (intMonth == 11)
                {
                    strSQL = "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME,MONTH(CV.COMP_VOUCHER_DATE) monthpos, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 11 THEN B.BILL_QUANTITY ELSE 0 END) AS [1st], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 12 THEN B.BILL_QUANTITY ELSE 0 END) AS [2nd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 1 THEN B.BILL_QUANTITY ELSE 0 END) AS [3rd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 2 THEN B.BILL_QUANTITY ELSE 0 END) AS [4th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 3 THEN B.BILL_QUANTITY ELSE 0 END) AS [5th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 4 THEN B.BILL_QUANTITY ELSE 0 END) AS [6th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 5 THEN B.BILL_QUANTITY ELSE 0 END) AS [7th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 6 THEN B.BILL_QUANTITY ELSE 0 END) AS [8th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 7 THEN B.BILL_QUANTITY ELSE 0 END) AS [9th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 8 THEN B.BILL_QUANTITY ELSE 0 END) AS [10th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 9 THEN B.BILL_QUANTITY ELSE 0 END) AS [11th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 10 THEN B.BILL_QUANTITY ELSE 0 END) AS [12th] ";
                    strSQL = strSQL + "from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S,ACC_BILL_TRAN B ,ACC_COMPANY_VOUCHER CV  ";
                    strSQL = strSQL + "where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and S.STOCKITEM_NAME =B.STOCKITEM_NAME  AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 and CV.LEDGER_NAME= l.LEDGER_NAME ";
                    strSQL = strSQL + "AND  B.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " and " + Utility.cvtSQLDateString(strTdate) + " and B.COMP_REF_NO= CV.COMP_REF_NO ";
                }
                else if (intMonth == 12)
                {
                    strSQL = "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE,S.STOCKGROUP_NAME,MONTH(CV.COMP_VOUCHER_DATE) monthpos, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 12 THEN B.BILL_QUANTITY ELSE 0 END) AS [1st], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 1 THEN B.BILL_QUANTITY ELSE 0 END) AS [2nd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 2 THEN B.BILL_QUANTITY ELSE 0 END) AS [3rd], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 3 THEN B.BILL_QUANTITY ELSE 0 END) AS [4th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 4 THEN B.BILL_QUANTITY ELSE 0 END) AS [5th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 5 THEN B.BILL_QUANTITY ELSE 0 END) AS [6th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 6 THEN B.BILL_QUANTITY ELSE 0 END) AS [7th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 7 THEN B.BILL_QUANTITY ELSE 0 END) AS [8th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 8 THEN B.BILL_QUANTITY ELSE 0 END) AS [9th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 9 THEN B.BILL_QUANTITY ELSE 0 END) AS [10th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 10 THEN B.BILL_QUANTITY ELSE 0 END) AS [11th], ";
                    strSQL = strSQL + "SUM(CASE WHEN MONTH(B.COMP_VOUCHER_DATE)  = 11 THEN B.BILL_QUANTITY ELSE 0 END) AS [12th] ";
                    strSQL = strSQL + "from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S,ACC_BILL_TRAN B ,ACC_COMPANY_VOUCHER CV  ";
                    strSQL = strSQL + "where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and S.STOCKITEM_NAME =B.STOCKITEM_NAME  AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 and CV.LEDGER_NAME= l.LEDGER_NAME ";
                    strSQL = strSQL + "AND  B.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " and " + Utility.cvtSQLDateString(strTdate) + " and B.COMP_REF_NO= CV.COMP_REF_NO ";
                }

                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "And (g.GR_PARENT =  '" + strGroupName + "') ";
                    }
                    else if (strSelection == "D")
                    {

                        strSQL = strSQL + "And (g.GR_NAME =  '" + strGroupName + "') ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "And (g.GR_NAME =  '" + strGroupName + "') ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "And (l.LEDGER_PARENT_GROUP =  '" + strGroupName + "') ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "And (l.LEDGER_PARENT_GROUP =  '" + strGroupName + "') ";
                    }
                    if (strProductSelection != "")
                    {
                        if (intMode == 2)
                        {
                            strSQL = strSQL + "where (STOCKCATEGORY_NAME IN (" + strProductSelection + ")) ";
                        }
                        else
                        {
                            strSQL = strSQL + "and  (S.STOCKITEM_NAME IN (" + strProductSelection + ")) ";
                        }
                    }
                }
                if (strPartyName != "")
                {
                    {
                        strSQL = strSQL + "and L.LEDGER_NAME_MERZE='" + strPartyName + "' ";
                    }
                    if (strProductSelection != "")
                    {
                        if (intMode == 2)
                        {
                            strSQL = strSQL + "where (STOCKCATEGORY_NAME IN (" + strProductSelection + ")) ";
                        }
                        else
                        {
                            strSQL = strSQL + "and  (S.STOCKITEM_NAME IN (" + strProductSelection + ")) ";
                        }
                    }
                }
                strSQL = strSQL + "GROUP BY g.GR_PARENT , g.GR_NAME, l.LEDGER_PARENT_GROUP, l.LEDGER_NAME_MERZE,s.STOCKGROUP_NAME, ";
                strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME,MONTH(cv.COMP_VOUCHER_DATE) ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strLedgername = dr["LEDGER_NAME_MERZE"].ToString();

                    if (intMode == 1)
                    {
                        if (dr["STOCKITEM_NAME"].ToString() != "")
                        {
                            oLedg.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                        }
                    }
                    else
                    {
                        if (dr["STOCKCATEGORY_NAME"].ToString() != "")
                        {

                            oLedg.strStockItemName = dr["STOCKCATEGORY_NAME"].ToString();
                        }
                    }
                    if (dr["1st"].ToString() != "")
                    {
                        oLedg.SalQty1 = Convert.ToDouble(dr["1st"].ToString());
                    }

                    if (dr["2nd"].ToString() != "")
                    {
                        oLedg.SalQty2 = Convert.ToDouble(dr["2nd"].ToString());
                    }
                    if (dr["3rd"].ToString() != "")
                    {
                        oLedg.SalQty3 = Convert.ToDouble(dr["3rd"].ToString());
                    }

                    if (dr["4th"].ToString() != "")
                    {
                        oLedg.SalQty4 = Convert.ToDouble(dr["4th"].ToString());
                    }
                    if (dr["5th"].ToString() != "")
                    {
                        oLedg.SalQty5 = Convert.ToDouble(dr["5th"].ToString());
                    }
                    if (dr["6th"].ToString() != "")
                    {
                        oLedg.SalQty6 = Convert.ToDouble(dr["6th"].ToString());
                    }
                    if (dr["7th"].ToString() != "")
                    {
                        oLedg.SalQty7 = Convert.ToDouble(dr["7th"].ToString());
                    }
                    if (dr["8th"].ToString() != "")
                    {
                        oLedg.SalQty8 = Convert.ToDouble(dr["8th"].ToString());
                    }
                    if (dr["9th"].ToString() != "")
                    {
                        oLedg.SalQty9 = Convert.ToDouble(dr["9th"].ToString());
                    }
                    if (dr["10th"].ToString() != "")
                    {
                        oLedg.SalQty10 = Convert.ToDouble(dr["10th"].ToString());
                    }
                    if (dr["11th"].ToString() != "")
                    {
                        oLedg.SalQty11 = Convert.ToDouble(dr["11th"].ToString());
                    }
                    if (dr["12th"].ToString() != "")
                    {
                        oLedg.SalQty12 = Convert.ToDouble(dr["12th"].ToString());
                    }
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region "Spcial Product"
        public List<RProductSales> mGetSpcialProduct(string strDeComID, string strFdate, string strTdate, string PreMonth, string strGroupName, string strPartyName, string strProductSelection, int intstatus, int intMode)
        {
            string strSQL = null, strSelection = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                List<RProductSales> ooAccLedger = new List<RProductSales>();
                SqlDataReader dr;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;
                strSQL = "DELETE FROM SPECIAL_PROEUCT_TEMP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                if (strGroupName != "")
                {
                    strSelection = strGroupName.Substring(0, 1).ToUpper();
                }
                if (intMode == 2)
                {
                    strSQL = "INSERT INTO SPECIAL_PROEUCT_TEMP ";
                    strSQL = strSQL + "(ZONE_NAME, DIVISION_NAME, AREA_NAME, LEDGER_MERZE_NAME, STOCK_CATEGORY_NAME, PRE_TARGET_AMOUNT) ";
                    strSQL = strSQL + "SELECT DISTINCT g.GR_PARENT, g.GR_NAME, v.GR_NAME AS Area, L.LEDGER_NAME_MERZE, INV_STOCKITEM.STOCKCATEGORY_NAME, SALES_TARGET_ITEM_TRAN.TARGET_ITEM_TRAN_AMOUNT ";
                    strSQL = strSQL + "FROM SALES_TARGET_ITEM_TRAN INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON SALES_TARGET_ITEM_TRAN.STOCKCATEGORY_NAME = INV_STOCKITEM.STOCKCATEGORY_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER AS L ON SALES_TARGET_ITEM_TRAN.LEDGER_NAME = L.LEDGER_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGERGROUP_CATEGORY_VIEW AS v ON L.LEDGER_PARENT_GROUP = v.GR_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGERGROUP AS g ON v.GR_PARENT = g.GR_NAME ";
                    strSQL = strSQL + "WHERE  (INV_STOCKITEM.SP_ITEM = 1) AND (SALES_TARGET_ITEM_TRAN.TARGET_ITEM_TRAN_MONTH_ID = '" + PreMonth + "') ";

                }
                else
                {
                    strSQL = "INSERT INTO SPECIAL_PROEUCT_TEMP ";
                    strSQL = strSQL + "(ZONE_NAME, DIVISION_NAME, AREA_NAME, LEDGER_MERZE_NAME, STOCK_ITEM_NAME, STOCK_CATEGORY_NAME, PRE_TARGET_AMOUNT) ";
                    strSQL = strSQL + "SELECT  g.GR_PARENT, g.GR_NAME, v.GR_NAME AS Area, L.LEDGER_NAME_MERZE, INV_STOCKITEM.STOCKITEM_NAME, INV_STOCKITEM.STOCKCATEGORY_NAME, ";
                    strSQL = strSQL + "SALES_TARGET_ITEM_TRAN.TARGET_ITEM_TRAN_AMOUNT ";
                    strSQL = strSQL + "FROM SALES_TARGET_ITEM_TRAN INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON SALES_TARGET_ITEM_TRAN.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER AS L ON SALES_TARGET_ITEM_TRAN.LEDGER_NAME = L.LEDGER_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGERGROUP_CATEGORY_VIEW AS v ON L.LEDGER_PARENT_GROUP = v.GR_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGERGROUP AS g ON v.GR_PARENT = g.GR_NAME ";
                    strSQL = strSQL + "WHERE   (INV_STOCKITEM.SP_ITEM = 1) AND (SALES_TARGET_ITEM_TRAN.TARGET_ITEM_TRAN_MONTH_ID = '" + PreMonth + "') ";
                    strSQL = strSQL + "ORDER BY SALES_TARGET_ITEM_TRAN.TARGET_ITEM_TRAN_MONTH_ID ";
                }
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                if (intMode == 2)
                {
                    strSQL = "INSERT INTO SPECIAL_PROEUCT_TEMP(ZONE_NAME,DIVISION_NAME,AREA_NAME,LEDGER_MERZE_NAME,STOCK_ITEM_NAME,STOCK_CATEGORY_NAME,PRE_SALES_AMOUNT) ";
                    strSQL = strSQL + "select  Lg.GR_PARENT AS ZONE, Lg.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME,sum(BT.BILL_QUANTITY) amnt ";
                    strSQL = strSQL + "from ACC_COMPANY_VOUCHER v ,ACC_LEDGER L , ACC_LEDGERGROUP_CATEGORY_VIEW Cv ,ACC_LEDGERGROUP Lg ,INV_STOCKITEM S, ACC_BILL_TRAN BT ";
                    strSQL = strSQL + "where v.COMP_VOUCHER_TYPE=16 and v.COMP_VOUCHER_MONTH_ID='" + PreMonth + "' and v.LEDGER_NAME= L.LEDGER_NAME and l.LEDGER_PARENT_GROUP = Cv.GR_NAME and  Lg.GR_NAME= Cv.GR_PARENT ";
                    strSQL = strSQL + "and BT.COMP_REF_NO= v.COMP_REF_NO and  BT.STOCKITEM_NAME= s.STOCKITEM_NAME  and s.SP_ITEM=1 ";
                    strSQL = strSQL + "group by  Lg.GR_PARENT , Lg.GR_NAME , l.LEDGER_PARENT_GROUP, l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME ";
                }
                else
                {
                    strSQL = "INSERT INTO SPECIAL_PROEUCT_TEMP(ZONE_NAME,DIVISION_NAME,AREA_NAME,LEDGER_MERZE_NAME,STOCK_ITEM_NAME,STOCK_CATEGORY_NAME,PRE_SALES_AMOUNT) ";
                    strSQL = strSQL + "select  Lg.GR_PARENT AS ZONE, Lg.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME,sum(BT.BILL_QUANTITY) amnt ";
                    strSQL = strSQL + "from ACC_COMPANY_VOUCHER v ,ACC_LEDGER L , ACC_LEDGERGROUP_CATEGORY_VIEW Cv ,ACC_LEDGERGROUP Lg ,INV_STOCKITEM S, ACC_BILL_TRAN BT ";
                    strSQL = strSQL + "where v.COMP_VOUCHER_TYPE=16 and v.COMP_VOUCHER_MONTH_ID='" + PreMonth + "' and v.LEDGER_NAME= L.LEDGER_NAME and l.LEDGER_PARENT_GROUP = Cv.GR_NAME and  Lg.GR_NAME= Cv.GR_PARENT ";
                    strSQL = strSQL + "and BT.COMP_REF_NO= v.COMP_REF_NO and BT.STOCKITEM_NAME= s.STOCKITEM_NAME and s.SP_ITEM=1 ";
                    strSQL = strSQL + "group by  Lg.GR_PARENT , Lg.GR_NAME , l.LEDGER_PARENT_GROUP, l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME ";
                }

                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                if (intMode == 2)
                {
                    strSQL = "INSERT INTO SPECIAL_PROEUCT_TEMP(ZONE_NAME,DIVISION_NAME,AREA_NAME,LEDGER_MERZE_NAME,STOCK_CATEGORY_NAME,CUR_TARGET_AMOUNT) ";
                    strSQL = strSQL + "SELECT DISTINCT g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, L.LEDGER_PARENT_GROUP AS AREA, L.LEDGER_NAME_MERZE, t.STOCKCATEGORY_NAME, t.TARGET_ITEM_TRAN_AMOUNT ";
                    strSQL = strSQL + "FROM  SALES_TARGET_ITEM_PACK_MASTER AS m INNER JOIN ";
                    strSQL = strSQL + "SALES_TARGET_ITEM_TRAN AS t ON m.TARGET_ITEM_PACK_KEY = t.TARGET_ITEM_TRAN_KEY INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGERGROUP_CATEGORY_VIEW AS v INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGERGROUP AS g ON v.GR_PARENT = g.GR_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER AS L ON v.GR_NAME = L.LEDGER_PARENT_GROUP ON t.LEDGER_NAME = L.LEDGER_NAME INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM AS S ON t.STOCKCATEGORY_NAME = S.STOCKCATEGORY_NAME ";
                    strSQL = strSQL + "WHERE  (S.SP_ITEM = 1) AND (t.TARGET_ITEM_TRAN_FROM_DATE >= " + Utility.cvtSQLDateString(strFdate) + ") AND (t.TARGET_ITEM_TRAN_TO_DATE <= " + Utility.cvtSQLDateString(strTdate) + ") ";

                }
                else
                {
                    strSQL = "INSERT INTO SPECIAL_PROEUCT_TEMP(ZONE_NAME,DIVISION_NAME,AREA_NAME,LEDGER_MERZE_NAME,STOCK_ITEM_NAME,STOCK_CATEGORY_NAME,CUR_TARGET_AMOUNT) ";
                    strSQL = strSQL + "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE , ";
                    strSQL = strSQL + "t.STOCKITEM_NAME,t.STOCKCATEGORY_NAME,sum(t.TARGET_ITEM_TRAN_AMOUNT) amnt ";
                    strSQL = strSQL + "from SALES_TARGET_ITEM_PACK_MASTER m,SALES_TARGET_ITEM_TRAN t,ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,INV_STOCKITEM S ";
                    strSQL = strSQL + "where m.TARGET_ITEM_PACK_KEY=t.TARGET_ITEM_TRAN_KEY AND g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "and L.LEDGER_NAME =t.LEDGER_NAME  AND S.STOCKITEM_NAME =T.STOCKITEM_NAME  AND S.SP_ITEM=1 ";
                    strSQL = strSQL + "AND T.TARGET_ITEM_TRAN_FROM_DATE  >= " + Utility.cvtSQLDateString(strFdate) + " and T.TARGET_ITEM_TRAN_TO_DATE <= " + Utility.cvtSQLDateString(strTdate) + " ";
                    strSQL = strSQL + "GROUP BY g.GR_PARENT , g.GR_NAME, l.LEDGER_PARENT_GROUP, l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "t.STOCKITEM_NAME,t.STOCKCATEGORY_NAME ";
                }

                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                if (intMode == 2)
                {
                    strSQL = "INSERT INTO SPECIAL_PROEUCT_TEMP(ZONE_NAME,DIVISION_NAME,AREA_NAME,LEDGER_MERZE_NAME,STOCK_ITEM_NAME,STOCK_CATEGORY_NAME,CUR_SALES_AMOUNT) ";
                    strSQL = strSQL + "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME,sum(distinct B.BILL_QUANTITY) amnt from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER cv, ";
                    strSQL = strSQL + "INV_STOCKITEM S,ACC_BILL_TRAN B where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and  B.STOCKITEM_NAME= s.STOCKITEM_NAME  ";
                    strSQL = strSQL + "and cv.COMP_REF_NO= b.COMP_REF_NO and l.LEDGER_NAME=cv.LEDGER_NAME ";
                    strSQL = strSQL + "AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 AND  B.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " and ";
                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strTdate) + "  ";
                    strSQL = strSQL + "GROUP BY g.GR_PARENT , 	  g.GR_NAME, l.LEDGER_PARENT_GROUP, l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME  ";
                }
                else
                {
                    strSQL = "INSERT INTO SPECIAL_PROEUCT_TEMP(ZONE_NAME,DIVISION_NAME,AREA_NAME,LEDGER_MERZE_NAME,STOCK_ITEM_NAME,STOCK_CATEGORY_NAME,CUR_SALES_AMOUNT) ";
                    strSQL = strSQL + "select g.GR_PARENT AS ZONE, g.GR_NAME AS DIBVISION, l.LEDGER_PARENT_GROUP AS AREA, l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME,sum(distinct B.BILL_QUANTITY) amnt from ACC_LEDGER L,ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER cv, ";
                    strSQL = strSQL + "INV_STOCKITEM S,ACC_BILL_TRAN B where  g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and S.STOCKITEM_NAME =B.STOCKITEM_NAME  ";
                    strSQL = strSQL + "and cv.COMP_REF_NO= b.COMP_REF_NO and l.LEDGER_NAME=cv.LEDGER_NAME ";
                    strSQL = strSQL + "AND S.SP_ITEM=1  AND B.COMP_VOUCHER_TYPE=16 AND  B.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " and ";
                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strTdate) + "  ";
                    strSQL = strSQL + "GROUP BY g.GR_PARENT , 	  g.GR_NAME, l.LEDGER_PARENT_GROUP, l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "s.STOCKITEM_NAME,s.STOCKCATEGORY_NAME  ";
                }

                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();

                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        if (intMode == 2)
                        {
                            strSQL = "SELECT ZONE_NAME, STOCK_CATEGORY_NAME as STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, SUM(CUR_TARGET_AMOUNT) ";
                            strSQL = strSQL + "AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                            strSQL = strSQL + "FROM SPECIAL_PROEUCT_TEMP ";
                            strSQL = strSQL + "WHERE (ZONE_NAME  = '" + strGroupName + "' ) ";
                            strSQL = strSQL + "and STOCK_CATEGORY_NAME <> '' ";
                            if (strProductSelection != "")
                            {
                                if (intMode == 2)
                                {
                                    strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                                }
                                else
                                {
                                    strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                                }
                            }
                            strSQL = strSQL + "GROUP BY ZONE_NAME,   STOCK_CATEGORY_NAME, MONTH_ID ";
                        }
                        else
                        {
                            strSQL = "SELECT ZONE_NAME,  STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, SUM(CUR_TARGET_AMOUNT) ";
                            strSQL = strSQL + "AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                            strSQL = strSQL + "FROM SPECIAL_PROEUCT_TEMP ";
                            strSQL = strSQL + "WHERE (ZONE_NAME  = '" + strGroupName + "' ) ";
                            if (strProductSelection != "")
                            {
                                if (intMode == 2)
                                {
                                    strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                                }
                                else
                                {
                                    strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                                }
                            }
                            strSQL = strSQL + "GROUP BY ZONE_NAME,   STOCK_ITEM_NAME, MONTH_ID ";
                        }

                    }
                    else if (strSelection == "D")
                    {
                        if (intMode == 2)
                        {
                            strSQL = "SELECT ZONE_NAME, DIVISION_NAME, STOCK_CATEGORY_NAME As STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, SUM(CUR_TARGET_AMOUNT) ";
                            strSQL = strSQL + "AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                            strSQL = strSQL + "FROM SPECIAL_PROEUCT_TEMP ";
                            strSQL = strSQL + "WHERE (DIVISION_NAME  = '" + strGroupName + "' ) ";
                            strSQL = strSQL + "and STOCK_CATEGORY_NAME <> '' ";
                            if (strProductSelection != "")
                            {
                                if (intMode == 2)
                                {
                                    strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                                }
                                else
                                {
                                    strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                                }
                            }
                            strSQL = strSQL + "GROUP BY ZONE_NAME, DIVISION_NAME, STOCK_CATEGORY_NAME, MONTH_ID ";
                        }
                        else
                        {
                            strSQL = "SELECT ZONE_NAME, DIVISION_NAME, STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, SUM(CUR_TARGET_AMOUNT) ";
                            strSQL = strSQL + "AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                            strSQL = strSQL + "FROM SPECIAL_PROEUCT_TEMP ";
                            strSQL = strSQL + "WHERE (DIVISION_NAME  = '" + strGroupName + "' ) ";
                            if (strProductSelection != "")
                            {
                                if (intMode == 2)
                                {
                                    strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                                }
                                else
                                {
                                    strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                                }
                            }
                            strSQL = strSQL + "GROUP BY ZONE_NAME, DIVISION_NAME, STOCK_CATEGORY_NAME, MONTH_ID ";
                        }

                    }
                    else if (strSelection == "R")
                    {
                        if (intMode == 2)
                        {
                            strSQL = "SELECT ZONE_NAME, DIVISION_NAME, STOCK_CATEGORY_NAME As STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, SUM(CUR_TARGET_AMOUNT) ";
                            strSQL = strSQL + "AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                            strSQL = strSQL + "FROM SPECIAL_PROEUCT_TEMP ";
                            strSQL = strSQL + "WHERE (DIVISION_NAME  = '" + strGroupName + "' ) ";
                            strSQL = strSQL + "and STOCK_CATEGORY_NAME <> '' ";
                            if (strProductSelection != "")
                            {
                                if (intMode == 2)
                                {
                                    strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                                }
                                else
                                {
                                    strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                                }
                            }
                            strSQL = strSQL + "GROUP BY ZONE_NAME, DIVISION_NAME, STOCK_CATEGORY_NAME, MONTH_ID ";
                        }
                        else
                        {
                            strSQL = "SELECT ZONE_NAME, DIVISION_NAME, STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, SUM(CUR_TARGET_AMOUNT) ";
                            strSQL = strSQL + "AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                            strSQL = strSQL + "FROM SPECIAL_PROEUCT_TEMP ";
                            strSQL = strSQL + "WHERE (DIVISION_NAME  = '" + strGroupName + "' ) ";
                            if (strProductSelection != "")
                            {
                                if (intMode == 2)
                                {
                                    strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                                }
                                else
                                {
                                    strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                                }
                            }
                            strSQL = strSQL + "GROUP BY ZONE_NAME, DIVISION_NAME, STOCK_ITEM_NAME, MONTH_ID ";
                        }


                    }
                    else if (strSelection == "A")
                    {
                        if (intMode == 2)
                        {
                            strSQL = "SELECT ZONE_NAME, DIVISION_NAME, AREA_NAME,STOCK_CATEGORY_NAME as STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, SUM(CUR_TARGET_AMOUNT) ";
                            strSQL = strSQL + "AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                            strSQL = strSQL + "FROM SPECIAL_PROEUCT_TEMP ";
                            strSQL = strSQL + "WHERE (AREA_NAME = '" + strGroupName + "' ) ";
                            strSQL = strSQL + "and  STOCK_CATEGORY_NAME <> '' ";
                            if (strProductSelection != "")
                            {
                                if (intMode == 2)
                                {
                                    strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                                }
                                else
                                {
                                    strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                                }
                            }
                            strSQL = strSQL + "GROUP BY ZONE_NAME, DIVISION_NAME, AREA_NAME, STOCK_CATEGORY_NAME, MONTH_ID ";
                        }
                        else
                        {
                            strSQL = "SELECT ZONE_NAME, DIVISION_NAME, AREA_NAME, STOCK_GROUP_NAME, STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, SUM(CUR_TARGET_AMOUNT) ";
                            strSQL = strSQL + "AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                            strSQL = strSQL + "FROM SPECIAL_PROEUCT_TEMP ";
                            strSQL = strSQL + "WHERE (AREA_NAME = '" + strGroupName + "' ) ";
                            if (strProductSelection != "")
                            {
                                if (intMode == 2)
                                {
                                    strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                                }
                                else
                                {
                                    strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                                }
                            }
                            strSQL = strSQL + "GROUP BY ZONE_NAME, DIVISION_NAME, AREA_NAME, STOCK_GROUP_NAME, STOCK_ITEM_NAME, MONTH_ID ";
                        }

                    }
                    else if (strSelection == "F")
                    {
                        if (intMode == 2)
                        {
                            strSQL = "SELECT ZONE_NAME, DIVISION_NAME, AREA_NAME,STOCK_CATEGORY_NAME as STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, SUM(CUR_TARGET_AMOUNT) ";
                            strSQL = strSQL + "AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                            strSQL = strSQL + "FROM SPECIAL_PROEUCT_TEMP ";
                            strSQL = strSQL + "WHERE (AREA_NAME = '" + strGroupName + "' ) ";
                            strSQL = strSQL + "and  STOCK_CATEGORY_NAME <> '' ";
                            if (strProductSelection != "")
                            {
                                if (intMode == 2)
                                {
                                    strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                                }
                                else
                                {
                                    strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                                }
                            }
                            strSQL = strSQL + "GROUP BY ZONE_NAME, DIVISION_NAME, AREA_NAME, STOCK_CATEGORY_NAME, MONTH_ID ";
                        }
                        else
                        {
                            strSQL = "SELECT ZONE_NAME, DIVISION_NAME, AREA_NAME, STOCK_GROUP_NAME, STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, SUM(CUR_TARGET_AMOUNT) ";
                            strSQL = strSQL + "AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                            strSQL = strSQL + "FROM SPECIAL_PROEUCT_TEMP ";
                            strSQL = strSQL + "WHERE (AREA_NAME = '" + strGroupName + "' ) ";
                            if (strProductSelection != "")
                            {
                                if (intMode == 2)
                                {
                                    strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                                }
                                else
                                {
                                    strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                                }
                            }
                            strSQL = strSQL + "GROUP BY ZONE_NAME, DIVISION_NAME, AREA_NAME, STOCK_GROUP_NAME, STOCK_ITEM_NAME, MONTH_ID ";
                        }


                    }
                    else if (strSelection == "S")
                    {
                        if (intMode == 2)
                        {
                            strSQL = "SELECT STOCK_CATEGORY_NAME as STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) ";
                            strSQL = strSQL + "AS preSales, SUM(CUR_TARGET_AMOUNT) AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                            strSQL = strSQL + "FROM  SPECIAL_PROEUCT_TEMP ";
                            strSQL = strSQL + "where   STOCK_CATEGORY_NAME <> '' ";
                            if (strProductSelection != "")
                            {
                                if (intMode == 2)
                                {
                                    strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                                }
                                else
                                {
                                    strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                                }
                            }
                            strSQL = strSQL + "GROUP BY STOCK_CATEGORY_NAME, MONTH_ID ";


                        }
                        else
                        {
                            strSQL = "SELECT  STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) ";
                            strSQL = strSQL + "AS preSales, SUM(CUR_TARGET_AMOUNT) AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                            strSQL = strSQL + "FROM  SPECIAL_PROEUCT_TEMP ";
                            if (strProductSelection != "")
                            {
                                if (intMode == 2)
                                {
                                    strSQL = strSQL + "where (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                                }
                                else
                                {
                                    strSQL = strSQL + "where (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                                }
                            }
                            strSQL = strSQL + "GROUP BY STOCK_ITEM_NAME, MONTH_ID ";

                        }

                    }
                }
                else if (strPartyName != "")
                {
                    if (intMode == 2)
                    {
                        strSQL = "SELECT ZONE_NAME, DIVISION_NAME, AREA_NAME, LEDGER_MERZE_NAME, STOCK_CATEGORY_NAME as STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, ";
                        strSQL = strSQL + "SUM(CUR_TARGET_AMOUNT) AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                        strSQL = strSQL + "FROM SPECIAL_PROEUCT_TEMP ";
                        strSQL = strSQL + "WHERE (LEDGER_MERZE_NAME = '" + strPartyName + "') ";
                        if (strProductSelection != "")
                        {
                            if (intMode == 2)
                            {
                                strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                            }
                            else
                            {
                                strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                            }
                        }
                        strSQL = strSQL + "and   STOCK_CATEGORY_NAME <> '' ";
                        strSQL = strSQL + "GROUP BY ZONE_NAME, DIVISION_NAME, AREA_NAME, LEDGER_MERZE_NAME,STOCK_CATEGORY_NAME, MONTH_ID ";
                    }
                    else
                    {
                        strSQL = "SELECT ZONE_NAME, DIVISION_NAME, AREA_NAME, LEDGER_MERZE_NAME, STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, ";
                        strSQL = strSQL + "SUM(CUR_TARGET_AMOUNT) AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                        strSQL = strSQL + "FROM SPECIAL_PROEUCT_TEMP ";
                        strSQL = strSQL + "WHERE (LEDGER_MERZE_NAME = '" + strPartyName + "') ";
                        if (strProductSelection != "")
                        {
                            if (intMode == 2)
                            {
                                strSQL = strSQL + "AND (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                            }
                            else
                            {
                                strSQL = strSQL + "AND (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                            }
                        }
                        strSQL = strSQL + "GROUP BY ZONE_NAME, DIVISION_NAME, AREA_NAME, LEDGER_MERZE_NAME,STOCK_ITEM_NAME, MONTH_ID ";
                    }



                }


                if ((strPartyName == "") && (strGroupName == ""))
                {

                    if (intMode == 2)
                    {

                        strSQL = "SELECT  STOCK_CATEGORY_NAME as STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) AS preSales, ";
                        strSQL = strSQL + "SUM(CUR_TARGET_AMOUNT) AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales FROM  SPECIAL_PROEUCT_TEMP ";
                        strSQL = strSQL + "where   STOCK_CATEGORY_NAME <> '' ";
                        if (strProductSelection != "")
                        {
                            if (intMode == 2)
                            {
                                strSQL = strSQL + "and (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                            }
                            else
                            {
                                strSQL = strSQL + "and (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                            }
                        }
                        strSQL = strSQL + "GROUP BY  MONTH_ID ,STOCK_CATEGORY_NAME ";
                    }
                    else
                    {
                        strSQL = "SELECT  STOCK_ITEM_NAME, MONTH_ID, SUM(PRE_TARGET_AMOUNT) AS PreTarget, SUM(PRE_SALES_AMOUNT) ";
                        strSQL = strSQL + "AS preSales, SUM(CUR_TARGET_AMOUNT) AS CurTarget, SUM(CUR_SALES_AMOUNT) AS CurSales ";
                        strSQL = strSQL + "FROM  SPECIAL_PROEUCT_TEMP ";
                        if (strProductSelection != "")
                        {
                            if (intMode == 2)
                            {
                                strSQL = strSQL + "where (STOCK_CATEGORY_NAME IN (" + strProductSelection + ")) ";
                            }
                            else
                            {
                                strSQL = strSQL + "where (STOCK_ITEM_NAME IN (" + strProductSelection + ")) ";
                            }
                        }
                        strSQL = strSQL + "GROUP BY STOCK_ITEM_NAME, MONTH_ID ";
                    }


                }

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    RProductSales oLedg = new RProductSales();
                    if (strSelection == "Z")
                    {
                        oLedg.strLedgerGroupPrimary = dr["ZONE_NAME"].ToString();
                    }
                    if ((strSelection == "D") || (strSelection == "R"))
                    {
                        if (dr["DIVISION_NAME"].ToString() != "")
                        {
                            oLedg.strLedgerGroupParent = dr["DIVISION_NAME"].ToString();
                        }
                    }
                    if (strSelection == "A")
                    {
                        if (dr["AREA_NAME"].ToString() != "")
                        {
                            oLedg.strLedgerGroupName = dr["AREA_NAME"].ToString();
                        }
                    }
                    if (strPartyName != "")
                    {
                        if (dr["LEDGER_MERZE_NAME"].ToString() != "")
                        {
                            oLedg.strLedgerGroupName = dr["LEDGER_MERZE_NAME"].ToString();
                        }
                    }

                    oLedg.strStockItemName = dr["STOCK_ITEM_NAME"].ToString();
                    oLedg.DblBillAmount = Convert.ToDouble(dr["PreTarget"].ToString());
                    oLedg.DblVNetAmt = Convert.ToDouble(dr["preSales"].ToString());
                    oLedg.DblBillQtyBonus = Convert.ToDouble(dr["CurTarget"].ToString());
                    oLedg.DblBillQty = Convert.ToDouble(dr["CurSales"].ToString());
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region "MPO/Product wise Sales Statement (Qty)"

        public List<RProductSales> mGetPRoductLoad(string strDeComID, string strFieldforce, string strFdate, string strTDate, int intMode, string strSelection)
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

                List<RProductSales> ooAccLedger = new List<RProductSales>();

                if (strSelection == "I")
                {
                    strSQL = "SELECT DISTINCT B.STOCKITEM_NAME ";
                    strSQL = strSQL + "FROM  ACC_COMP_BILL_TRAN_QRY AS B INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_Z_D_A AS LG ON B.LEDGER_NAME = LG.LEDGER_NAME ";
                    strSQL = strSQL + "WHERE  B.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ") ";
                    strSQL = strSQL + "AND (B.COMP_VOUCHER_TYPE = 16) AND (B.BRANCH_ID = 0001)  ";
                }
                if (strSelection == "G")
                {
                    strSQL = "SELECT DISTINCT INV_STOCKITEM.STOCKGROUP_NAME AS STOCKITEM_NAME ";
                    strSQL = strSQL + "FROM   ACC_COMP_BILL_TRAN_QRY AS B INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_Z_D_A AS LG ON B.LEDGER_NAME = LG.LEDGER_NAME INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON B.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME ";
                    strSQL = strSQL + "WHERE  B.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ") ";
                    strSQL = strSQL + "AND (B.COMP_VOUCHER_TYPE = 16) AND (B.BRANCH_ID = 0001)  ";
                }
                if (intMode == 1)
                {
                    if (strFieldforce != "")
                    {
                        strSQL = strSQL + "AND  LG.ZONE IN (" + strFieldforce + ") ";
                    }
                }
                if (intMode == 2)
                {
                    if (strFieldforce != "")
                    {
                        strSQL = strSQL + "AND  LG.DIVISION IN (" + strFieldforce + ") ";
                    }
                }
                if (intMode == 3)
                {
                    if (strFieldforce != "")
                    {
                        strSQL = strSQL + "AND  LG.AREA IN (" + strFieldforce + ") ";
                    }
                }
                if (intMode == 4)
                {
                    if (strFieldforce != "")
                    {
                        strSQL = strSQL + "AND  LG.LEDGER_NAME_MERZE IN (" + strFieldforce + ") ";
                    }
                }
                if (strSelection == "I")
                {
                    strSQL = strSQL + "ORDER BY B.STOCKITEM_NAME ";
                }
                if (strSelection == "G")
                {
                    strSQL = strSQL + "ORDER BY INV_STOCKITEM.STOCKGROUP_NAME ";
                }

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RProductSales oLedg = new RProductSales();
                    oLedg.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        public List<RSalesPurchase> mGetMpoGroupLoad(string strDeComID, int intMode, string strString, string strFDate, string strTDate, string vstrUserName)
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

                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();
                if (intMode == 1)
                {
                    strSQL = "SELECT DISTINCT LG.ZONE AS FieldForce ";
                    strSQL = strSQL + "FROM ACC_COMP_BILL_TRAN_QRY AS B INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_Z_D_A AS LG ON B.LEDGER_NAME = LG.LEDGER_NAME ";
                    strSQL = strSQL + "WHERE (B.COMP_VOUCHER_TYPE = 16) AND (B.BRANCH_ID = 0001) ";
                    if (strFDate != "")
                    {
                        strSQL = strSQL + "AND B.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")   ";
                    }
                    if (vstrUserName != "")
                    {
                        strSQL = strSQL + " AND  LG.Division in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + vstrUserName + "')";
                    }
                    strSQL = strSQL + "ORDER BY LG.ZONE ";
                }
                if (intMode == 2)
                {
                    strSQL = "SELECT DISTINCT LG.DIVISION AS FieldForce ";
                    strSQL = strSQL + "FROM ACC_COMP_BILL_TRAN_QRY AS B INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_Z_D_A AS LG ON B.LEDGER_NAME = LG.LEDGER_NAME ";
                    strSQL = strSQL + "WHERE (B.COMP_VOUCHER_TYPE = 16) AND (B.BRANCH_ID = 0001) ";
                    if (strFDate != "")
                    {
                        strSQL = strSQL + "AND B.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")   ";
                    }
                    if (vstrUserName != "")
                    {
                        strSQL = strSQL + " AND  LG.Division in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + vstrUserName + "')";
                    }
                    strSQL = strSQL + "ORDER BY LG.DIVISION ";
                }
                if (intMode == 3)
                {
                    strSQL = "SELECT DISTINCT LG.AREA AS FieldForce ";
                    strSQL = strSQL + "FROM ACC_COMP_BILL_TRAN_QRY AS B INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_Z_D_A AS LG ON B.LEDGER_NAME = LG.LEDGER_NAME ";
                    strSQL = strSQL + "WHERE (B.COMP_VOUCHER_TYPE = 16) AND (B.BRANCH_ID = 0001) ";
                    if (strFDate != "")
                    {
                        strSQL = strSQL + "AND B.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")   ";
                    }
                    if (vstrUserName != "")
                    {
                        strSQL = strSQL + " AND  LG.Division in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + vstrUserName + "')";
                    }
                    strSQL = strSQL + "ORDER BY LG.AREA";
                }
                if (intMode == 4)
                {
                    strSQL = "SELECT DISTINCT LG.LEDGER_NAME_MERZE AS FieldForce ";
                    strSQL = strSQL + "FROM ACC_COMP_BILL_TRAN_QRY AS B INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_Z_D_A AS LG ON B.LEDGER_NAME = LG.LEDGER_NAME ";
                    strSQL = strSQL + "WHERE (B.COMP_VOUCHER_TYPE = 16) AND (B.BRANCH_ID = 0001) ";
                    if (strFDate != "")
                    {
                        strSQL = strSQL + "AND B.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFDate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")   ";
                    }
                    if (vstrUserName != "")
                    {
                        strSQL = strSQL + " AND  LG.Division in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + vstrUserName + "')";
                    }
                    strSQL = strSQL + "ORDER BY LG.LEDGER_NAME_MERZE ";
                }
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strGRName = dr["FieldForce"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }


        

        #endregion
        #region "BKASH"
        public List<RSalesPurchase> mGetBkash(string strDeComID)
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
                List<RSalesPurchase> ooAccLedger = new List<RSalesPurchase>();

                strSQL = "Select  G.ZONE,G.DIVISION, G.AREA,L.BKASH_STATUS, ";
                strSQL = strSQL + "L.LEDGER_NAME_MERZE from  ACC_LEDGER L, ACC_LEDGER_Z_D_A G ";
                strSQL = strSQL + "Where  l.LEDGER_NAME=G.LEDGER_NAME ";
                strSQL = strSQL + "and l.BKASH_STATUS=0 ";
                strSQL =strSQL + " ORDER by  G.ZONE,G.DIVISION, G.AREA,L.LEDGER_NAME_MERZE ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strLedgerGroupParent = dr["ZONE"].ToString();
                    oLedg.strLedgerGroupPrimary = dr["DIVISION"].ToString();
                    oLedg.strGroupAMFM = dr["AREA"].ToString();
                    oLedg.strLedgerName = dr["LEDGER_NAME_MERZE"].ToString();
                    ooAccLedger.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    RSalesPurchase oLedg = new RSalesPurchase();
                    oLedg.strZone = "";
                    oLedg.srtDisvision = "";
                    oLedg.strGroupAMFM = "";
                    oLedg.strLedgerName = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }
        #endregion
        #region "Sales & Collection Performance"
        public List<RPSalesCollectionPerformance> mGetCPSPCollectionPerformanceRepYear(string strDeComID, string strPDeComID, string strPFdate, string strPTDate, string strFate, string strTDate, string strBranchID, string strGroupName,
                                                                     int intMode, int intOrderby, string vstrUserName)
        {


            //
            string strSQL = null, strPreDatabase;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strPreDatabase = "SMART" + strPDeComID + ".DBO.";
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;

                List<RPSalesCollectionPerformance> ooAccLedger = new List<RPSalesCollectionPerformance>();

                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "DELETE FROM SALES_COLLECTION_PER_TEMP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //********************Sales ********************
                //SalesTarget
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP( ZONE, DIVISION, AREA, TERITORY_NAME, TERITORY_CODE, MEDICAL_REPRESENTATIVE, TOTAL_SALES_TARGET , POSITION,CP_SP_GP,LEDGER_NAME_MERZE) ";
                strSQL = strSQL + "SELECT ACC_LEDGER_Z_D_A.ZONE,ACC_LEDGER_Z_D_A.DIVISION,ACC_LEDGER_Z_D_A.AREA,ACC_LEDGER.TERRITORRY_NAME,ACC_LEDGER.TERITORRY_CODE,ACC_LEDGER.LEDGER_NAME,ACC_LEDGER.LEDGER_TARGET,1,ACC_LEDGER.LEDGER_CODE,ACC_LEDGER.LEDGER_REP_NAME ";
                strSQL = strSQL + "FROM ACC_LEDGER_Z_D_A,ACC_LEDGER  WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME= ACC_LEDGER.LEDGER_REP_NAME AND ACC_LEDGER.LEDGER_GROUP =204 AND ACC_LEDGER.LEDGER_NAME  <> 'GP (General Party)' ";

                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Sales
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_SALES,POSITION,LEDGER_NAME_MERZE) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,C.SALES_REP";
                strSQL = strSQL + ",abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) SALES_CURRENT_MONTH   ,isnull(g.GR_PARENT_POSITION,0),L.LEDGER_NAME ";
                strSQL = strSQL + "from " + strPreDatabase + "ACC_LEDGERGROUP g," + strPreDatabase + "ACC_LEDGERGROUP_CATEGORY_VIEW v," + strPreDatabase + "ACC_LEDGER l," + strPreDatabase + "ACC_COMPANY_VOUCHER c where g.GR_NAME=v.GR_PARENT   ";
                strSQL = strSQL + "and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME AND C.COMP_VOUCHER_DATE  >= " + Utility.cvtSQLDateString(strPFdate) + "";
                strSQL = strSQL + "and C.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strPTDate) + " ";
                //strSQL = strSQL + "and L.LEDGER_NAME_MERZE='180-Md. Nasir Uddin-Pekua'  ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =16 AND l.LEDGER_STATUS = 0 group by g.GR_PARENT , ";
                strSQL = strSQL + "g.GR_NAME , l.LEDGER_PARENT_GROUP,C.SALES_REP,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION,L.LEDGER_NAME  ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,SALES,POSITION,LEDGER_NAME_MERZE) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,C.SALES_REP,";
                strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) SALES_CURRENT_MONTH   ,isnull(g.GR_PARENT_POSITION,0) ,L.LEDGER_NAME ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c where g.GR_NAME=v.GR_PARENT   ";
                strSQL = strSQL + "and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME AND C.COMP_VOUCHER_DATE  >= " + Utility.cvtSQLDateString(strFate) + "";
                strSQL = strSQL + "and C.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strTDate) + " ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =16 AND C.BRANCH_ID ='0001' AND l.LEDGER_STATUS = 0 group by g.GR_PARENT , ";
                strSQL = strSQL + "g.GR_NAME , l.LEDGER_PARENT_GROUP,C.SALES_REP,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION,L.LEDGER_NAME ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE  C SET C.CP_SP_GP=L.LEDGER_CODE FROM  ACC_LEDGER L,SALES_COLLECTION_PER_TEMP C WHERE L.LEDGER_NAME=C.MEDICAL_REPRESENTATIVE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "UPDATE  C SET C.LEDGER_NAME_MERZE=L.LEDGER_NAME_MERZE FROM  ACC_LEDGER L,SALES_COLLECTION_PER_TEMP C WHERE L.LEDGER_NAME=C.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Transaction.Commit();

                if (intMode == 1)
                {
                    strSQL = "select ZONE,DIVISION,AREA,TERITORY_CODE,TERITORY_NAME,CP_SP_GP , sum(PREVIOUS_DUES_GOODS)OPDUES,sum(TOTAL_SALES_TARGET)TSalesTarget,  ";
                    strSQL = strSQL + "sum(SALES) Sales,(case when Sum(TOTAL_SALES_TARGET) <> 0 then (sum(SALES)*100)/ Sum(TOTAL_SALES_TARGET) else 0 end )AchPerSales   ";
                    strSQL = strSQL + ",sum(PREVIOUS_SALES) PREVIOUS_SALES From SALES_COLLECTION_PER_TEMP    ";
                    strSQL = strSQL + "where ZONE in(" + strGroupName + ") ";
                    strSQL = strSQL + " AND CP_SP_GP NOT LIKE 'GP%' ";
                    strSQL = strSQL + "Group by ZONE,DIVISION,AREA,TERITORY_CODE,TERITORY_NAME,CP_SP_GP   ";
                }
                if (intMode == 2)
                {
                    strSQL = "select ZONE,DIVISION,AREA,TERITORY_CODE,TERITORY_NAME,CP_SP_GP, sum(PREVIOUS_DUES_GOODS)OPDUES,sum(TOTAL_SALES_TARGET)TSalesTarget, ";
                    strSQL = strSQL + "sum(SALES) Sales,(case when Sum(TOTAL_SALES_TARGET) <> 0 then (sum(SALES)*100)/ Sum(TOTAL_SALES_TARGET) else 0 end )AchPerSales ";
                    strSQL = strSQL + ",sum(PREVIOUS_SALES) PREVIOUS_SALES From SALES_COLLECTION_PER_TEMP  ";
                    strSQL = strSQL + "where DIVISION in(" + strGroupName + ") ";
                    strSQL = strSQL + " AND CP_SP_GP NOT LIKE 'GP%' ";
                    strSQL = strSQL + "Group by ZONE,DIVISION,AREA,TERITORY_CODE,TERITORY_NAME,CP_SP_GP ";
                }
                if (intMode == 3)
                {
                    strSQL = "select ZONE,DIVISION,AREA,TERITORY_CODE,TERITORY_NAME,CP_SP_GP, sum(PREVIOUS_DUES_GOODS)OPDUES,sum(TOTAL_SALES_TARGET)TSalesTarget, ";
                    strSQL = strSQL + "sum(SALES) Sales,(case when Sum(TOTAL_SALES_TARGET) <> 0 then (sum(SALES)*100)/ Sum(TOTAL_SALES_TARGET) else 0 end )AchPerSales ";
                    strSQL = strSQL + ",sum(PREVIOUS_SALES) PREVIOUS_SALES From SALES_COLLECTION_PER_TEMP  ";
                    strSQL = strSQL + "where AREA in(" + strGroupName + ") ";
                    strSQL = strSQL + " AND CP_SP_GP NOT LIKE 'GP%' ";
                    strSQL = strSQL + "Group by ZONE,DIVISION,AREA,TERITORY_CODE,TERITORY_NAME,CP_SP_GP  ";
                }
                if (intMode == 4)
                {
                    strSQL = "select ZONE,DIVISION,AREA,TERITORY_CODE,TERITORY_NAME,CP_SP_GP ,MEDICAL_REPRESENTATIVE, sum(PREVIOUS_DUES_GOODS)OPDUES,sum(TOTAL_SALES_TARGET)TSalesTarget, ";
                    strSQL = strSQL + "sum(SALES) Sales,(case when Sum(TOTAL_SALES_TARGET) <> 0 then (sum(SALES)*100)/ Sum(TOTAL_SALES_TARGET) else 0 end )AchPerSales ";
                    strSQL = strSQL + ",sum(PREVIOUS_SALES) PREVIOUS_SALES From SALES_COLLECTION_PER_TEMP  ";
                    strSQL = strSQL + "where LEDGER_NAME_MERZE in(" + strGroupName + ") ";
                    strSQL = strSQL + " AND CP_SP_GP NOT LIKE 'GP%' ";
                    strSQL = strSQL + "Group by ZONE,DIVISION,AREA,TERITORY_CODE,TERITORY_NAME,CP_SP_GP ,MEDICAL_REPRESENTATIVE ";
                }

                if (intMode == 5)
                {
                    strSQL = "select ZONE,DIVISION,AREA,TERITORY_CODE,TERITORY_NAME,CP_SP_GP ,MEDICAL_REPRESENTATIVE, sum(PREVIOUS_DUES_GOODS)OPDUES,sum(TOTAL_SALES_TARGET)TSalesTarget, ";
                    strSQL = strSQL + "0,sum(SALES) Sales,(case when Sum(TOTAL_SALES_TARGET) <> 0 then (sum(SALES)*100)/ Sum(TOTAL_SALES_TARGET) else 0 end ) AchPerSales ";
                    strSQL = strSQL + ",0 TCollTarget,0,0,0 ";
                    strSQL = strSQL + ",sum(PREVIOUS_SALES) PREVIOUS_SALES From SALES_COLLECTION_PER_TEMP  ";
                    strSQL = strSQL + " WHERE CP_SP_GP NOT LIKE 'GP%' ";
                    if (vstrUserName != "")
                    {
                        strSQL = strSQL + " and  DIVISION in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + vstrUserName + "')";
                    }
                    strSQL = strSQL + "Group by ZONE,DIVISION,AREA,TERITORY_CODE,TERITORY_NAME,CP_SP_GP ,MEDICAL_REPRESENTATIVE ";
                }


                ////if (intOrderby == 1)
                ////{
                ////    strSQL = strSQL + "order by (case when Sum(UPD_TARGET_SALES) <> 0 then(sum(SALES)*100)/ Sum(UPD_TARGET_SALES)else 0 end)  DESC ";
                ////}
                ////else if (intOrderby == 2)
                ////{
                ////    strSQL = strSQL + "order by  (case when Sum(UPD_TARGET_SALES) <> 0 then (sum(COLLECTION)*100)/ Sum(UPD_TARGET_SALES) else 0 end )DESC ";
                ////}
                if (intOrderby == 1)
                {
                    strSQL = strSQL + "order by  (case when Sum(UPD_TARGET_SALES) <> 0 then (sum(SALES)*100)/ Sum(UPD_TARGET_SALES) else 0 end ) desc";

                }
                else if (intOrderby == 2)
                {
                    strSQL = strSQL + "order by (case when sum(UPD_TARGET_COLL) <> 0 then (sum(COLLECTION)*100)/sum(UPD_TARGET_COLL) else 0 end) desc ";
                    //(sum(COLLECTION)*100)/ Sum(UPD_TARGET_SALES)DESC ";
                }
                else
                {
                    if (intMode == 5)
                    {
                        strSQL = strSQL + "order by MEDICAL_REPRESENTATIVE ";
                    }
                    if (intMode == 4)
                    {
                        strSQL = strSQL + "order by MEDICAL_REPRESENTATIVE ";
                    }
                    if (intMode == 3)
                    {
                        strSQL = strSQL + "order by AREA ";
                    }
                    if (intMode == 2)
                    {
                        strSQL = strSQL + "order by DIVISION ";
                    }
                    if (intMode == 1)
                    {
                        strSQL = strSQL + "order by ZONE ";
                    }


                }

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RPSalesCollectionPerformance oLedg = new RPSalesCollectionPerformance();

                    oLedg.strZONE = dr["ZONE"].ToString();
                    oLedg.strDivision = dr["DIVISION"].ToString();
                    oLedg.strCPSPGP = dr["CP_SP_GP"].ToString();
                    oLedg.strTC = dr["TERITORY_CODE"].ToString();
                    oLedg.strTeritorry = dr["TERITORY_NAME"].ToString();
                    oLedg.strArea = dr["AREA"].ToString();
                    oLedg.dblPreviousSales = Convert.ToDouble(dr["PREVIOUS_SALES"].ToString());
                    if (dr["TSalesTarget"].ToString() != "")
                    {
                        oLedg.dblTotalSalesTarget = Convert.ToDouble(dr["TSalesTarget"].ToString());
                    }

                    if (dr["Sales"].ToString() != "")
                    {
                        oLedg.dblSales = Convert.ToDouble(dr["Sales"].ToString());
                    }
                    if (dr["AchPerSales"].ToString() != "")
                    {
                        oLedg.dblSalesAchPer = Convert.ToDouble(dr["AchPerSales"].ToString());
                    }
                    //if (dr["TCollTarget"].ToString() != "")
                    //{
                    //    oLedg.dblTotalCollTarget = Convert.ToDouble(dr["TCollTarget"].ToString());
                    //}


                    ooAccLedger.Add(oLedg);

                }

                if (!dr.HasRows)
                {
                    RPSalesCollectionPerformance oLedg = new RPSalesCollectionPerformance();
                    oLedg.strLedgerNameMerze = "";
                    oLedg.strCPSPGP = "";
                    oLedg.strTC = "";
                    oLedg.strTeritorry = "";
                    oLedg.dblOpeningAmount = 0;
                    oLedg.dblTotalSalesTarget = 0;
                    oLedg.dblUPDSalesTarget = 0;
                    oLedg.dblSales = 0;
                    oLedg.dblSalesAchPer = 0;
                    oLedg.dblTotalCollTarget = 0;
                    oLedg.dblUPDCollTarget = 0;
                    oLedg.dblCollection = 0;
                    oLedg.dblCollectionAchPer = 0;
                    ooAccLedger.Add(oLedg);
                }

                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;

            }
        }
        public List<RPSalesCollectionPerformance> mGetSalesCollectionPerformanceRep(string strDeComID, string strFate, string strTDate, string strBranchID, string strGroupName,
                                                      int intMode, int intOrderby, string gstrUserName, DateTime FirstdayOfMonth, DateTime LasttdayOfMonth, int intDay, int intUpdDay, string vstrUserName)
        {


            //
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
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;

                List<RPSalesCollectionPerformance> ooAccLedger = new List<RPSalesCollectionPerformance>();

                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "DELETE FROM SALES_COLLECTION_PER_TEMP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Previous Dues
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP( ZONE, DIVISION, AREA, TERITORY_NAME, TERITORY_CODE, MEDICAL_REPRESENTATIVE, PREVIOUS_DUES_GOODS , POSITION) ";
                strSQL = strSQL + "SELECT g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, isnull(sum(l.LEDGER_OPENING_BALANCE),0) *-1 PDUES   ";
                strSQL = strSQL + ",isnull(g.GR_PARENT_POSITION,0) from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                strSQL = strSQL + "AND l.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + "AND l.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //Current Month
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP( ZONE, DIVISION, AREA, TERITORY_NAME, TERITORY_CODE, MEDICAL_REPRESENTATIVE, PREVIOUS_DUES_GOODS , POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) SALES_CURRENT_MONTH   ";
                strSQL = strSQL + ",isnull(g.GR_PARENT_POSITION,0) from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =16 ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + "AND l.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Return
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP( ZONE, DIVISION, AREA, TERITORY_NAME, TERITORY_CODE, MEDICAL_REPRESENTATIVE, PREVIOUS_DUES_GOODS , POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0))*-1 RETURN_AMOUNT,isnull(g.GR_PARENT_POSITION,0)   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =13 ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + "AND l.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Debit Amount

                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) DEBIT_AMOUNT,isnull(g.GR_PARENT_POSITION,0)   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                strSQL = strSQL + "AND aV.VOUCHER_TOBY ='Dr' AND aV.COMP_VOUCHER_TYPE =3 ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + " AND  C.SP_JOURNAL =0 ";
                strSQL = strSQL + " AND  C.DISABLE_VOUCHER =0 ";
                strSQL = strSQL + "AND l.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Modified_24-11-19
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "abs(ISNULL(SUM(av.VOUCHER_DEBIT_AMOUNT-av.VOUCHER_CREDIT_AMOUNT),0)) DEBIT_AMOUNT,isnull(g.GR_PARENT_POSITION,0)   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                strSQL = strSQL + "AND aV.VOUCHER_TOBY ='Dr' AND aV.COMP_VOUCHER_TYPE =3 ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + " AND  C.SP_JOURNAL =0 ";
                strSQL = strSQL + " AND  C.DISABLE_VOUCHER =1 ";
                strSQL = strSQL + "AND l.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //Credit Amount
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME ,l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) *-1 CREDIT_AMOUNT,isnull(g.GR_PARENT_POSITION,0)   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                strSQL = strSQL + "AND aV.VOUCHER_TOBY ='Cr' AND aV.COMP_VOUCHER_TYPE =3 ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + " AND  C.SP_JOURNAL =0 ";
                strSQL = strSQL + "AND l.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                ////Cash
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME,l.TERITORRY_CODE, l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + " abs(ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0)) *-1 COLL_CASH_TT,isnull(g.GR_PARENT_POSITION,0) ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av  ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO  ";
                strSQL = strSQL + "AND av.COMP_VOUCHER_TYPE=" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND l.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + "AND l.LEDGER_STATUS = 0 ";
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //New minus pf HL 17_07_20

                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                strSQL = strSQL + "SELECT Z.ZONE,Z.DIVISION,Z.AREA,Z.TERRITORRY_NAME,Z.TERITORRY_CODE,  Z.LEDGER_NAME_MERZE ,ISNULL(SUM(V.VOUCHER_CREDIT_AMOUNT),0) *-1, ";
                strSQL = strSQL + "ISNULL(Z.GR_PARENT_POSITION,0)  FROM ACC_LEDGER_Z_D_A Z,ACC_VOUCHER V WHERE Z.LEDGER_NAME=V.REVERSE_LEDGER1  AND V.AUTOJV=1 AND V.COMP_VOUCHER_TYPE=3 ";
                strSQL = strSQL + "AND V.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND V.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + " AND  V.AUTOJV=1";
                strSQL = strSQL + "GROUP by  Z.ZONE,Z.DIVISION,Z.AREA ,Z.LEDGER_NAME,Z.TERRITORRY_NAME,Z.TERITORRY_CODE, Z.LEDGER_NAME_MERZE,GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //*********



                //********************Sales ********************
                //SalesTarget

                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,TOTAL_SALES_TARGET,POSITION) ";
                strSQL = strSQL + "select V.ZONE,V.DIVISION,V.AREA,V.TERRITORRY_NAME,V.TERITORRY_CODE,V.LEDGER_NAME_MERZE,   sum(TARGET_ACHIEVE_AMOUNT),V.GR_PARENT_POSITION ";
                strSQL = strSQL + "from SALES_TARGET_ACHIEVEMENT ST,ACC_LEDGER_Z_D_A V where ";
                strSQL = strSQL + "ST.LEDGER_NAME=V.LEDGER_NAME ";
                //strSQL = strSQL + "--and    ST.LEDGER_NAME ='Masud Rana-004'   ";
                strSQL = strSQL + "and  TARGET_ACHIEVE_FROM_DATE >= " + Utility.cvtSQLDateString(FirstdayOfMonth.ToString("dd-MM-yyyy")) + " ";
                strSQL = strSQL + "and TARGET_ACHIEVE_TO_DATE<=" + Utility.cvtSQLDateString(LasttdayOfMonth.ToString("dd-MM-yyyy")) + " ";
                strSQL = strSQL + "group by V.ZONE,V.DIVISION,V.AREA,V.TERRITORRY_NAME,V.TERITORRY_CODE,V.LEDGER_NAME_MERZE, V.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //UPDTarget
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,UPD_TARGET_SALES,POSITION) ";
                strSQL = strSQL + "select V.ZONE,V.DIVISION,V.AREA,V.TERRITORRY_NAME,V.TERITORRY_CODE,V.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "( sum(TARGET_ACHIEVE_AMOUNT)/" + intDay + ")* " + Convert.ToInt32(intUpdDay) + " ,V.GR_PARENT_POSITION ";
                strSQL = strSQL + "from SALES_TARGET_ACHIEVEMENT ST,ACC_LEDGER_Z_D_A V where ";
                strSQL = strSQL + "ST.LEDGER_NAME=V.LEDGER_NAME ";
                //strSQL = strSQL + "--and    ST.LEDGER_NAME ='Masud Rana-004'   ";
                strSQL = strSQL + "and  TARGET_ACHIEVE_FROM_DATE >= " + Utility.cvtSQLDateString(FirstdayOfMonth.ToString("dd-MM-yyyy")) + " ";
                strSQL = strSQL + "and TARGET_ACHIEVE_TO_DATE<=" + Utility.cvtSQLDateString(LasttdayOfMonth.ToString("dd-MM-yyyy")) + " ";
                strSQL = strSQL + "group by V.ZONE,V.DIVISION,V.AREA,V.TERRITORRY_NAME,V.TERITORRY_CODE,V.LEDGER_NAME_MERZE, V.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Sales
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,SALES,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE,";
                strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) SALES_CURRENT_MONTH   ,isnull(g.GR_PARENT_POSITION,0) ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c where g.GR_NAME=v.GR_PARENT   ";
                strSQL = strSQL + "and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME AND C.COMP_VOUCHER_DATE  >= " + Utility.cvtSQLDateString(strFate) + "";
                strSQL = strSQL + "and C.COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strTDate) + " ";
                //strSQL = strSQL + "and L.LEDGER_NAME_MERZE='180-Md. Nasir Uddin-Pekua'  ";
                strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =16 AND C.BRANCH_ID ='" + strBranchID + "' AND l.LEDGER_STATUS = 0 group by g.GR_PARENT , ";
                strSQL = strSQL + "g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //************************Collection***********************
                //CollTarget
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,TOTAL_COLL_TARGET,POSITION) ";
                strSQL = strSQL + "select V.ZONE,V.DIVISION,V.AREA,V.TERRITORRY_NAME,V.TERITORRY_CODE,V.LEDGER_NAME_MERZE,   sum(COLL_TARGET_COLL_AMT),V.GR_PARENT_POSITION ";
                strSQL = strSQL + "from SALES_COLL_TARGET_TRAN ST,ACC_LEDGER_Z_D_A V where ";
                strSQL = strSQL + "ST.LEDGER_NAME=V.LEDGER_NAME ";
                //strSQL = strSQL + "--and    ST.LEDGER_NAME ='Masud Rana-004'   ";
                strSQL = strSQL + "and  COLL_TARGET_FROM_DATE >= " + Utility.cvtSQLDateString(FirstdayOfMonth.ToString("dd-MM-yyyy")) + " ";
                strSQL = strSQL + "and COLL_TARGET_TO_DATE<=" + Utility.cvtSQLDateString(LasttdayOfMonth.ToString("dd-MM-yyyy")) + " ";
                strSQL = strSQL + "group by V.ZONE,V.DIVISION,V.AREA,V.TERRITORRY_NAME,V.TERITORRY_CODE,V.LEDGER_NAME_MERZE, V.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //UPDTarget
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,UPD_TARGET_COLL,POSITION) ";
                strSQL = strSQL + "select V.ZONE,V.DIVISION,V.AREA,V.TERRITORRY_NAME,V.TERITORRY_CODE,V.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "( sum(COLL_TARGET_COLL_AMT)/" + intDay + ")* " + Convert.ToInt32(intUpdDay) + " ,V.GR_PARENT_POSITION ";
                strSQL = strSQL + "from SALES_COLL_TARGET_TRAN ST,ACC_LEDGER_Z_D_A V where ";
                strSQL = strSQL + "ST.LEDGER_NAME=V.LEDGER_NAME ";
                //strSQL = strSQL + "--and    ST.LEDGER_NAME ='Masud Rana-004'   ";
                strSQL = strSQL + "and  COLL_TARGET_FROM_DATE >= " + Utility.cvtSQLDateString(FirstdayOfMonth.ToString("dd-MM-yyyy")) + " ";
                strSQL = strSQL + "and COLL_TARGET_TO_DATE<=" + Utility.cvtSQLDateString(LasttdayOfMonth.ToString("dd-MM-yyyy")) + " ";
                strSQL = strSQL + "group by V.ZONE,V.DIVISION,V.AREA,V.TERRITORRY_NAME,V.TERITORRY_CODE,V.LEDGER_NAME_MERZE, V.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //COLLECTION
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,COLLECTION,POSITION) ";
                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,COLLECTION,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME,l.TERITORRY_CODE, l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(AV.VOUCHER_CREDIT_AMOUNT),0) COLL_CASH_TT,isnull(g.GR_PARENT_POSITION,0) from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,";
                strSQL = strSQL + "ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av  where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and ";
                strSQL = strSQL + "l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO  AND av.COMP_VOUCHER_TYPE=1 ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + " ";
                strSQL = strSQL + "AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + "AND l.LEDGER_STATUS =0  ";
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                //New minus pf HL 17_07_20

                strSQL = "INSERT INTO SALES_COLLECTION_PER_TEMP(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,COLLECTION,POSITION) ";
                strSQL = strSQL + "SELECT Z.ZONE,Z.DIVISION,Z.AREA,Z.TERRITORRY_NAME,Z.TERITORRY_CODE,  Z.LEDGER_NAME_MERZE ,ISNULL(SUM(V.VOUCHER_CREDIT_AMOUNT),0) *-1, ";
                strSQL = strSQL + "ISNULL(Z.GR_PARENT_POSITION,0)  FROM ACC_LEDGER_Z_D_A Z,ACC_VOUCHER V WHERE Z.LEDGER_NAME=V.REVERSE_LEDGER1  AND V.AUTOJV=1 AND V.COMP_VOUCHER_TYPE=3 ";
                strSQL = strSQL + "AND V.COMP_VOUCHER_DATE BETWEEN ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + " ";
                strSQL = strSQL + "AND V.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + " AND  V.AUTOJV=1";
                strSQL = strSQL + "GROUP by  Z.ZONE,Z.DIVISION,Z.AREA ,Z.LEDGER_NAME,Z.TERRITORRY_NAME,Z.TERITORRY_CODE, Z.LEDGER_NAME_MERZE,GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //*********


                cmdInsert.Transaction.Commit();

                if (intMode == 1)
                {
                    strSQL = "select ZONE, sum(PREVIOUS_DUES_GOODS)OPDUES,sum(TOTAL_SALES_TARGET)TSalesTarget,  ";
                    strSQL = strSQL + "Sum(UPD_TARGET_SALES)UPD_Sal_TAR,sum(SALES) Sales,(case when Sum(UPD_TARGET_SALES) <> 0 then (sum(SALES)*100)/ Sum(UPD_TARGET_SALES) else 0 end )AchPerSales   ";
                    strSQL = strSQL + ",sum(TOTAL_COLL_TARGET)TCollTarget,sum(UPD_TARGET_COLL)UPDCollTar,sum(COLLECTION) CollV,(case when sum(UPD_TARGET_COLL) <> 0 then (sum(COLLECTION)*100)/sum(UPD_TARGET_COLL) else 0 end) AchPerColl   ";
                    strSQL = strSQL + "From SALES_COLLECTION_PER_TEMP    ";
                    strSQL = strSQL + "where ZONE in(" + strGroupName + ") ";
                    strSQL = strSQL + "Group by ZONE  ";
                }
                if (intMode == 2)
                {
                    strSQL = "select DIVISION, sum(PREVIOUS_DUES_GOODS)OPDUES,sum(TOTAL_SALES_TARGET)TSalesTarget, ";
                    strSQL = strSQL + "Sum(UPD_TARGET_SALES)UPD_Sal_TAR,sum(SALES) Sales,(case when Sum(UPD_TARGET_SALES) <> 0 then (sum(SALES)*100)/ Sum(UPD_TARGET_SALES) else 0 end )AchPerSales ";
                    strSQL = strSQL + ",sum(TOTAL_COLL_TARGET)TCollTarget,sum(UPD_TARGET_COLL)UPDCollTar,sum(COLLECTION) CollV,(case when sum(UPD_TARGET_COLL) <> 0 then (sum(COLLECTION)*100)/sum(UPD_TARGET_COLL) else 0 end)AchPerColl ";
                    strSQL = strSQL + "From SALES_COLLECTION_PER_TEMP  ";
                    strSQL = strSQL + "where DIVISION in(" + strGroupName + ") ";
                    strSQL = strSQL + "Group by DIVISION ";
                }
                if (intMode == 3)
                {
                    strSQL = "select AREA, sum(PREVIOUS_DUES_GOODS)OPDUES,sum(TOTAL_SALES_TARGET)TSalesTarget, ";
                    strSQL = strSQL + "Sum(UPD_TARGET_SALES)UPD_Sal_TAR,sum(SALES) Sales,(case when Sum(UPD_TARGET_SALES) <> 0 then (sum(SALES)*100)/ Sum(UPD_TARGET_SALES) else 0 end )AchPerSales ";
                    strSQL = strSQL + ",sum(TOTAL_COLL_TARGET)TCollTarget,sum(UPD_TARGET_COLL)UPDCollTar,sum(COLLECTION) CollV,(case when sum(UPD_TARGET_COLL) <> 0 then (sum(COLLECTION)*100)/sum(UPD_TARGET_COLL) else 0 end) AchPerColl ";
                    strSQL = strSQL + "From SALES_COLLECTION_PER_TEMP  ";
                    strSQL = strSQL + "where AREA in(" + strGroupName + ") ";
                    strSQL = strSQL + "Group by AREA ";
                }
                if (intMode == 4)
                {
                    strSQL = "select ZONE,DIVISION,AREA,MEDICAL_REPRESENTATIVE, sum(PREVIOUS_DUES_GOODS)OPDUES,sum(TOTAL_SALES_TARGET)TSalesTarget, ";
                    strSQL = strSQL + "Sum(UPD_TARGET_SALES)UPD_Sal_TAR,sum(SALES) Sales,(case when Sum(UPD_TARGET_SALES) <> 0 then (sum(SALES)*100)/ Sum(UPD_TARGET_SALES) else 0 end )AchPerSales ";
                    strSQL = strSQL + ",sum(TOTAL_COLL_TARGET)TCollTarget,sum(UPD_TARGET_COLL)UPDCollTar,sum(COLLECTION) CollV,(case when sum(UPD_TARGET_COLL) <> 0 then (sum(COLLECTION)*100)/sum(UPD_TARGET_COLL) else 0 end)AchPerColl ";
                    strSQL = strSQL + "From SALES_COLLECTION_PER_TEMP  ";
                    strSQL = strSQL + "where MEDICAL_REPRESENTATIVE in(" + strGroupName + ") ";
                    strSQL = strSQL + "Group by ZONE,DIVISION,AREA,MEDICAL_REPRESENTATIVE ";
                }

                if (intMode == 5)
                {
                    strSQL = "select ZONE,DIVISION,AREA,MEDICAL_REPRESENTATIVE, sum(PREVIOUS_DUES_GOODS)OPDUES,sum(TOTAL_SALES_TARGET)TSalesTarget, ";
                    strSQL = strSQL + "Sum(UPD_TARGET_SALES)UPD_Sal_TAR,sum(SALES) Sales,(case when Sum(UPD_TARGET_SALES) <> 0 then (sum(SALES)*100)/ Sum(UPD_TARGET_SALES) else 0 end ) AchPerSales ";
                    strSQL = strSQL + ",sum(TOTAL_COLL_TARGET)TCollTarget,sum(UPD_TARGET_COLL)UPDCollTar,sum(COLLECTION) CollV,(case when sum(UPD_TARGET_COLL) <> 0 then (sum(COLLECTION)*100)/sum(UPD_TARGET_COLL) else 0 end)AchPerColl ";
                    strSQL = strSQL + "From SALES_COLLECTION_PER_TEMP  ";
                    if (vstrUserName !="")
                    {
                        strSQL = strSQL + " WHERE  DIVISION in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + vstrUserName + "')";
                    }
                    strSQL = strSQL + "Group by ZONE,DIVISION,AREA,MEDICAL_REPRESENTATIVE ";
                }


                if (intOrderby == 1)
                {
                    strSQL = strSQL + "order by  (case when Sum(UPD_TARGET_SALES) <> 0 then (sum(SALES)*100)/ Sum(UPD_TARGET_SALES) else 0 end )  DESC";
                       
                }
                else if (intOrderby == 2)
                {
                    strSQL = strSQL + "order by (case when sum(UPD_TARGET_COLL) <> 0 then (sum(COLLECTION)*100)/sum(UPD_TARGET_COLL) else 0 end) DESC";
                        //(sum(COLLECTION)*100)/ Sum(UPD_TARGET_SALES)DESC ";
                }
                else
                {
                    if (intMode == 5)
                    {
                        strSQL = strSQL + "order by MEDICAL_REPRESENTATIVE ";
                    }
                    if (intMode == 4)
                    {
                        strSQL = strSQL + "order by MEDICAL_REPRESENTATIVE ";
                    }
                    if (intMode == 3)
                    {
                        strSQL = strSQL + "order by AREA ";
                    }
                    if (intMode == 2)
                    {
                        strSQL = strSQL + "order by DIVISION ";
                    }
                    if (intMode == 1)
                    {
                        strSQL = strSQL + "order by ZONE ";
                    }


                }

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RPSalesCollectionPerformance oLedg = new RPSalesCollectionPerformance();
                    if (intMode == 1)
                    {
                        oLedg.strZONE = dr["ZONE"].ToString();
                    }
                    if (intMode == 2)
                    {
                        oLedg.strDivision = dr["DIVISION"].ToString();
                    }
                    if (intMode == 3)
                    {
                        oLedg.strArea = dr["AREA"].ToString();
                    }
                    if (intMode == 4)
                    {
                        if (dr["MEDICAL_REPRESENTATIVE"].ToString() != "")
                        {
                            oLedg.strLedgerNameMerze = dr["MEDICAL_REPRESENTATIVE"].ToString();
                        }
                    }
                    if (intMode == 5)
                    {
                        if (dr["MEDICAL_REPRESENTATIVE"].ToString() != "")
                        {
                            oLedg.strLedgerNameMerze = dr["MEDICAL_REPRESENTATIVE"].ToString();
                            oLedg.strZONE = dr["ZONE"].ToString();
                            oLedg.strDivision = dr["DIVISION"].ToString();
                            oLedg.strArea = dr["AREA"].ToString();
                        }
                    }
                    if (dr["OPDUES"].ToString() != "")
                    {
                        oLedg.dblOpeningAmount = Convert.ToDouble(dr["OPDUES"].ToString());
                    }
                    if (dr["TSalesTarget"].ToString() != "")
                    {
                        oLedg.dblTotalSalesTarget = Convert.ToDouble(dr["TSalesTarget"].ToString());
                    }
                    if (dr["UPD_Sal_TAR"].ToString() != "")
                    {
                        oLedg.dblUPDSalesTarget = Convert.ToDouble(dr["UPD_Sal_TAR"].ToString());
                    }
                    if (dr["Sales"].ToString() != "")
                    {
                        oLedg.dblSales = Convert.ToDouble(dr["Sales"].ToString());
                    }
                    if (dr["AchPerSales"].ToString() != "")
                    {
                        oLedg.dblSalesAchPer = Convert.ToDouble(dr["AchPerSales"].ToString());
                    }
                    if (dr["TCollTarget"].ToString() != "")
                    {
                        oLedg.dblTotalCollTarget = Convert.ToDouble(dr["TCollTarget"].ToString());
                    }
                    if (dr["UPDCollTar"].ToString() != "")
                    {
                        oLedg.dblUPDCollTarget = Convert.ToDouble(dr["UPDCollTar"].ToString());
                    }
                    if (dr["CollV"].ToString() != "")
                    {
                        oLedg.dblCollection = Convert.ToDouble(dr["CollV"].ToString());
                    }
                    if (dr["AchPerColl"].ToString() != "")
                    {
                        oLedg.dblCollectionAchPer = Convert.ToDouble(dr["AchPerColl"].ToString());
                    }

                    ooAccLedger.Add(oLedg);

                }

                if (!dr.HasRows)
                {
                    RPSalesCollectionPerformance oLedg = new RPSalesCollectionPerformance();
                    oLedg.strLedgerNameMerze = "";
                    oLedg.dblOpeningAmount = 0;
                    oLedg.dblTotalSalesTarget = 0;
                    oLedg.dblUPDSalesTarget = 0;
                    oLedg.dblSales = 0;
                    oLedg.dblSalesAchPer = 0;
                    oLedg.dblTotalCollTarget = 0;
                    oLedg.dblUPDCollTarget = 0;
                    oLedg.dblCollection = 0;
                    oLedg.dblCollectionAchPer = 0;
                    ooAccLedger.Add(oLedg);
                }

                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;

            }
        }

        #endregion

    }
}
