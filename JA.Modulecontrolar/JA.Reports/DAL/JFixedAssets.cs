using Dutility;
using JA.Reports.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;


namespace JA.Reports.Dal
{
  public  class JFixedAssets
    {
      private string connstring ;
      //= Utility.SQLConnstring();
        private string strSQL = "";


        public List<RFixedAsset> mUpdateReducingBalance(string strDeComID, DateTime gdteFinicialYearFrom, DateTime dteAsOnDate)
        {
          
            DateTime dtePurchaseDate, dteNextDate, dteFromDate;
            long lngDiff = 0;
            double dblPurchase = 0, dblAddThisYear = 0, dblTotalCost = 0, dblDepreciation = 0,
                dblThisPeriodDep = 0, dblAccuDep = 0, curPrevAdjustment = 0, curAdjustment = 0,
                dblPrevBal = 0, dblTotalSale = 0, dblDeprate=0;
            long intDay = 0;
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
                strSQL = "DELETE FROM FIXED_ASSET_SCHEDULE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                List<FixedAssets1> oFixed1 = new List<FixedAssets1>();
                List<FixedAssets1> oFixedAssetFinal = new List<FixedAssets1>();
                strSQL = "SELECT * FROM ACC_FIXED_ASSETS WHERE ASSET_DEP_METHOD = 1 ";

                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    FixedAssets1 fxdAsst = new FixedAssets1();
                    fxdAsst.strAssetLedger = dr["LEDGER_NAME"].ToString();
                    fxdAsst.strAssetNumber = dr["ASSET_SERIAL"].ToString();
                    fxdAsst.dteFromDate = Convert.ToDateTime(dr["ASSET_DEP_EFF_DATE"]);
                    fxdAsst.dteDiffEffDate = Convert.ToDateTime(dr["ASSET_DEP_EFF_DATE"]);
                    fxdAsst.vsngDepRate = Convert.ToDouble(dr["ASSET_DEP_RATE"]);
                    fxdAsst.dblAccuDep = Convert.ToDouble(dr["ASSET_ACCU_DEP"]);
                    fxdAsst.dblWrittenDownValue = Utility.mdblGetOpening(strDeComID, fxdAsst.strAssetLedger) * -1;
                    fxdAsst.dblTotalCost = fxdAsst.dblWrittenDownValue;
                    //dteAccToDate =  DateAdd("d", -1, gdteFinicialYearFrom);
                    fxdAsst.dteAccToDate = gdteFinicialYearFrom.AddDays(-1);
                    fxdAsst.dteNextDate = gdteFinicialYearFrom;
                    oFixed1.Add(fxdAsst);
                }
                dr.Close();
                if (oFixed1.Count > 0)
                {

                    foreach (FixedAssets1 oFixedItem in oFixed1)
                    {
                        //FixedAssets1 fxdAsstfinal = new FixedAssets1();
                        strSQL = "SELECT ISNULL(SUM(ADJUSTMENT_AMOUNT),0) AMNT FROM ACC_FIXED_ASSET_ADJUSTMENT_DEP ";
                        strSQL = strSQL + "WHERE LEDGER_NAME = '" + oFixedItem.strAssetLedger + "' ";
                        strSQL = strSQL + "AND ADJUSTMENT_DATE < " + Utility.cvtSQLDateString(gdteFinicialYearFrom.ToString("dd/MM/yyyy")) + " ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            curPrevAdjustment = Convert.ToDouble(dr["AMNT"]);
                        }
                        dr.Close();

                        strSQL = "SELECT ISNULL(SUM(ADJUSTMENT_AMOUNT),0) AMNT FROM ACC_FIXED_ASSET_ADJUSTMENT_DEP ";
                        strSQL = strSQL + "WHERE LEDGER_NAME = '" + oFixedItem.strAssetLedger + "' ";
                        strSQL = strSQL + "AND ADJUSTMENT_DATE BETWEEN " + Utility.cvtSQLDateString(gdteFinicialYearFrom.ToString("dd/MM/yyyy")) + " ";
                        strSQL = strSQL + "AND " + Utility.cvtSQLDateString(dteAsOnDate.ToString("dd/MM/yyyy")) + " ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            curAdjustment = Convert.ToDouble(dr["AMNT"]);
                        }
                        dr.Close();

                        dblPrevBal = oFixedItem.dblTotalCost;
                        dblDeprate = oFixedItem.vsngDepRate;
                        dblThisPeriodDep = oFixedItem.dblThisPeriodDep;
                        dblAddThisYear = oFixedItem.dblAddThisYear;
                        dblTotalSale = oFixedItem.dblTotalSale;
                        dblAccuDep = oFixedItem.dblAccuDep;
                        curPrevAdjustment = oFixedItem.curPrevAdjustment;

                        strSQL = "SELECT COMP_VOUCHER_DATE,VOUCHER_TOBY,SUM(VOUCHER_DEBIT_AMOUNT-VOUCHER_CREDIT_AMOUNT) AS AMOUNT FROM ACC_VOUCHER WHERE LEDGER_NAME = '" + oFixedItem.strAssetLedger + "' ";
                        strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(gdteFinicialYearFrom.ToString("dd/MM/yyyy")) + " ";
                        strSQL = strSQL + "AND " + Utility.cvtSQLDateString(dteAsOnDate.ToString("dd/MM/yyyy")) + ") ";
                        strSQL = strSQL + "GROUP BY COMP_VOUCHER_DATE,VOUCHER_TOBY ";
                        strSQL = strSQL + "ORDER BY COMP_VOUCHER_DATE ASC ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        while (dr.Read())
                        {
                            FixedAssets1 fxdAsstfinal = new FixedAssets1();
                            dtePurchaseDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]);
                            dblPurchase = Convert.ToDouble(dr["Amount"]);
                            lngDiff = Utility.DateDiff(Utility.DateInterval.Day, dtePurchaseDate, oFixedItem.dteFromDate);
                            if (lngDiff > 0)
                            {
                                dteNextDate = oFixedItem.dteFromDate.AddDays(1);
                            }
                            else
                            {
                                dteNextDate = dtePurchaseDate.AddDays(1);
                            }
                            if (dblPurchase > 0)
                            {
                                dblAddThisYear = dblAddThisYear + dblPurchase;

                            }
                            if (dblPurchase < 0)
                            {
                                dblTotalSale = dblAddThisYear + Math.Abs(dblPurchase);

                            }
                            dteNextDate = oFixedItem.dteAccToDate;

                            lngDiff = Utility.DateDiff(Utility.DateInterval.Day, oFixedItem.dteDiffEffDate, dtePurchaseDate);
                            if (lngDiff < 0)
                            {
                                intDay = Utility.DateDiff(Utility.DateInterval.Day, oFixedItem.dteDiffEffDate, dteAsOnDate) + 1;
                                //intDay = DateDiff("d", dteDiffEffDate, uctxtAsOn.Text) + 1
                            }
                            else
                            {
                                intDay = Utility.DateDiff(Utility.DateInterval.Day, oFixedItem.dteDiffEffDate, dteAsOnDate ) + 1;
                            }

                            dblPrevBal = oFixedItem.dblTotalCost;
                            dblTotalCost = dblTotalCost + dblPurchase;
                            dblDepreciation = Math.Round(((((dblPurchase) * oFixedItem.vsngDepRate) * intDay) / 365) / 100, 0);
                            dblThisPeriodDep = dblThisPeriodDep + dblDepreciation;
                            dblAccuDep = dblAccuDep + dblDepreciation;
                            dteFromDate = dtePurchaseDate.AddDays(1);
                            
                            fxdAsstfinal.strAssetNumber = oFixedItem.strAssetNumber;
                            fxdAsstfinal.strAssetLedger  = oFixedItem.strAssetLedger;
                            fxdAsstfinal.dblPrevBal  = dblPrevBal;
                            fxdAsstfinal.dblAddThisYear  = dblAddThisYear;
                            fxdAsstfinal.dblTotalSale = dblTotalSale;
                            fxdAsstfinal.dblThisPeriodDep = dblThisPeriodDep;
                            fxdAsstfinal.dblAccuDepBak = oFixedItem.dblAccuDep ;
                            fxdAsstfinal.curPrevAdjustment = curPrevAdjustment;
                            fxdAsstfinal.curAdjustment = curAdjustment;
                            fxdAsstfinal.dblInitialCost = 0;

                            oFixedAssetFinal.Add(fxdAsstfinal);
                        }
                        if (!dr.HasRows)
                        {
                            FixedAssets1 fxdAsstfinal = new FixedAssets1();
                            fxdAsstfinal.strAssetNumber = oFixedItem.strAssetNumber;
                            fxdAsstfinal.strAssetLedger = oFixedItem.strAssetLedger;
                            fxdAsstfinal.dblPrevBal = dblPrevBal;
                            fxdAsstfinal.dblAddThisYear = dblAddThisYear;
                            fxdAsstfinal.dblTotalSale = dblTotalSale;
                            fxdAsstfinal.dblThisPeriodDep = Math.Round(((dblPrevBal) * dblDeprate) / 100, 0);
                            fxdAsstfinal.dblAccuDepBak = oFixedItem.dblAccuDep;
                            fxdAsstfinal.curPrevAdjustment = curPrevAdjustment;
                            fxdAsstfinal.curAdjustment = curAdjustment;
                            fxdAsstfinal.vsngDepRate = dblDeprate;
                            fxdAsstfinal.dblInitialCost = 0;

                            oFixedAssetFinal.Add(fxdAsstfinal);
                        }
                        dr.Close();

                    }

                }

                if (oFixedAssetFinal.Count > 0)
                {
                    foreach (FixedAssets1 ofxdInsert in oFixedAssetFinal)
                    {
                        strSQL = "INSERT INTO FIXED_ASSET_SCHEDULE(ASSET_NUMBER,LEDGER_NAME,";
                        strSQL = strSQL + "ASSET_PREV_BAL,ASSET_ADD_THIS_PERIOD,";
                        strSQL = strSQL + "ASSET_DISPOSAL_THIS_PERIOD,ASSET_DEP_RATE,ASSET_DEP_THIS_PERIOD, ";
                        strSQL = strSQL + "ASSET_DEP_ACCU,ASSET_PURCHASE_VALUE) ";
                        strSQL = strSQL + "VALUES(" + ofxdInsert.strAssetNumber + ",";
                        strSQL = strSQL + "'" + ofxdInsert.strAssetLedger + "'," + ofxdInsert.dblPrevBal + ",";
                        strSQL = strSQL + " " + ofxdInsert.dblAddThisYear + "," + ofxdInsert.dblTotalSale + ",";
                        strSQL = strSQL + " " + ofxdInsert.vsngDepRate + "," + ofxdInsert.dblThisPeriodDep + ", ";
                        strSQL = strSQL + " " + ofxdInsert.dblAccuDepBak + "," + ofxdInsert.dblInitialCost + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                cmdInsert.Transaction.Commit();
                List<RFixedAsset> ooAccLedger = new List<RFixedAsset>();
                strSQL = "SELECT LEDGER_NAME, ASSET_PREV_BAL, ASSET_ADD_THIS_PERIOD, ASSET_DISPOSAL_THIS_PERIOD, ASSET_DEP_RATE, ASSET_DEP_THIS_PERIOD, ASSET_DEP_ACCU, ASSET_DEP_ADJUSTMENT, ";
                strSQL = strSQL + "LEDGER_PARENT_GROUP ";
                strSQL = strSQL + "FROM  ACC_FIXED_ASSET_REPORT_QRY AS ACC_FIXED_ASSET_REPORT_QRY ";
                strSQL = strSQL + "ORDER BY LEDGER_PARENT_GROUP, LEDGER_NAME ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RFixedAsset oLedg = new RFixedAsset();
                    oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oLedg.dblAssetPrevBal = Convert.ToDouble(dr["ASSET_PREV_BAL"].ToString());
                    oLedg.dblAssetAddThisPeriod = Convert.ToDouble(dr["ASSET_ADD_THIS_PERIOD"].ToString());
                    oLedg.dblAssetDisposalthisPeriod = Convert.ToDouble(dr["ASSET_DISPOSAL_THIS_PERIOD"].ToString());
                    oLedg.dblAssetDepRate = Convert.ToDouble(dr["ASSET_DEP_RATE"].ToString());
                    oLedg.dblAssetDepThisPeriod = Convert.ToDouble(dr["ASSET_DEP_THIS_PERIOD"].ToString());
                    oLedg.dblAssetDepAccu = Convert.ToDouble(dr["ASSET_DEP_ACCU"].ToString());
                    oLedg.dblAssetDepAdjustMent = Convert.ToDouble(dr["ASSET_DEP_ADJUSTMENT"].ToString());
                    oLedg.strLedgerGroupParent = dr["LEDGER_PARENT_GROUP"].ToString();
                    ooAccLedger.Add(oLedg);
                }

                if (!dr.HasRows)
                {
                    RFixedAsset oLedg = new RFixedAsset();
                    oLedg.strLedgerName = "";
                    oLedg.dblAssetPrevBal = 0;
                    oLedg.dblAssetAddThisPeriod = 0;
                    oLedg.dblAssetDisposalthisPeriod = 0;
                    oLedg.dblAssetDepRate = 0;
                    oLedg.dblAssetDepThisPeriod = 0;
                    oLedg.dblAssetDepAccu = 0;
                    oLedg.dblAssetDepAdjustMent = 0;
                    oLedg.strLedgerGroupParent = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }


        public List<RFixedAsset> mUpdateStraightLine(string strDeComID, DateTime gdteFinicialYearFrom, DateTime dteAsOnDate, DateTime dtePrevdate)
        {

            DateTime dtePurchaseDate, dteNextDate, dteFromDate,dtePreviosDate;
            string strDrcr = "";
            long lngDiff = 0;
            double dblPurchase = 0, dblAddThisYear = 0, dblTotalCost = 0, dblDepreciation = 0, dblDeprate = 0,
                dblThisPeriodDep = 0, dblAccuDep = 0, curPrevAdjustment = 0, curAdjustment = 0, dblPrevBal = 0, dblTotalSale = 0, PrevAdjustment=0,
                dblPreviousAmnt = 0, dblPreviousThisAmnt = 0, curAdjustmentAmnt=0;
            long intDay = 0,intPrevday=0,intCheck=0;
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
                strSQL = "DELETE FROM FIXED_ASSET_SCHEDULE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                List<FixedAssets1> oFixed1 = new List<FixedAssets1>();
                List<FixedAssets1> oFixedAssetFinal = new List<FixedAssets1>();
                strSQL = "SELECT * FROM ACC_FIXED_ASSETS WHERE ASSET_DEP_METHOD = 2 ";
                //strSQL = strSQL + " AND LEDGER_NAME in ('Air Conditioner Of Factory Premises')";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    FixedAssets1 fxdAsst = new FixedAssets1();
                    fxdAsst.strAssetLedger = dr["LEDGER_NAME"].ToString();
                    fxdAsst.strAssetNumber = dr["ASSET_SERIAL"].ToString();
                    if (dr["ASSET_PERCENT"].ToString() == "1")
                    {
                        if (Convert.ToDouble(dr["ASSET_DEP_RATE"]) > 0)
                        {
                            fxdAsst.strAssetRate = dr["ASSET_DEP_RATE"].ToString() + "%";
                            //fxdAsst.dblAssetLife = 100 / Convert.ToDouble(dr["ASSET_DEP_RATE"]);
                            fxdAsst.dblAssetLife = Convert.ToDouble(dr["ASSET_DEP_RATE"]);
                        }

                    }
                    else
                    {
                        fxdAsst.dblAssetLife = Convert.ToDouble(dr["ASSET_LIFE"]);
                        fxdAsst.strAssetRate = fxdAsst.dblAssetLife.ToString();
                    }
                    fxdAsst.dteFromDate = Convert.ToDateTime(dr["ASSET_DEP_EFF_DATE"]);
                    fxdAsst.dteDiffEffDate = Convert.ToDateTime(dr["ASSET_DEP_EFF_DATE"]);
                    fxdAsst.vsngDepRate = Convert.ToDouble(dr["ASSET_DEP_RATE"]);
                    fxdAsst.dblAccuDep = Convert.ToDouble(dr["ASSET_ACCU_DEP"]);
                    fxdAsst.dblSalvageValue = Convert.ToDouble(dr["ASSET_SALVAGE_VALUE"]);
                    fxdAsst.dblWrittenDownValue = Utility.mdblGetOpening(strDeComID, fxdAsst.strAssetLedger) * -1;
                    fxdAsst.dblTotalCost = fxdAsst.dblWrittenDownValue;
                    //dteAccToDate =  DateAdd("d", -1, gdteFinicialYearFrom);
                    //fxdAsst.dteAccToDate =  gdteFinicialYearFrom.AddDays(-1);
                    fxdAsst.dteAccToDate = gdteFinicialYearFrom.AddYears(-1);
                    fxdAsst.dteNextDate = gdteFinicialYearFrom;

                    lngDiff = Utility.DateDiff(Utility.DateInterval.Day, fxdAsst.dteFromDate, fxdAsst.dteAccToDate) + 1;
                    if (lngDiff < 0)
                    {

                    }
                    else
                    {
                        if (fxdAsst.dblAssetLife != 0)
                        {
                            //dblDepreciation = Math.Round((Math.Round((((fxdAsst.dblTotalCost - fxdAsst.dblSalvageValue)) / fxdAsst.dblAssetLife), 0) * lngDiff) / 365, 0);
                            //dblDepreciation = Math.Round((Math.Round((((fxdAsst.dblTotalCost - fxdAsst.dblSalvageValue)) / fxdAsst.dblAssetLife), 0) * 365) / 100, 0);
                            dblDepreciation = Math.Round(((((fxdAsst.dblTotalCost) * fxdAsst.dblAssetLife) * 365) / 365) / 100, 0);
                        }
                        fxdAsst.dblAccuDep = fxdAsst.dblAccuDep + dblDepreciation;
                    }

                    lngDiff = Utility.DateDiff(Utility.DateInterval.Day, fxdAsst.dteFromDate, gdteFinicialYearFrom);

                    if (lngDiff < 0)
                    {
                        lngDiff = Utility.DateDiff(Utility.DateInterval.Day, fxdAsst.dteFromDate, dteAsOnDate) + 1;
                        if (fxdAsst.dblAssetLife != 0)
                        {
                            dblDepreciation = Math.Round((Math.Round((((dblTotalCost - fxdAsst.dblSalvageValue)) / fxdAsst.dblAssetLife), 0) * lngDiff) / 365, 0);
                        }
                        fxdAsst.dblThisPeriodDep = dblDepreciation;
                    }
                    else
                    {
                        lngDiff = Utility.DateDiff(Utility.DateInterval.Day, gdteFinicialYearFrom, dteAsOnDate) + 1;
                        if (fxdAsst.dblAssetLife != 0)
                        {
                            dblDepreciation = Math.Round((Math.Round((((dblTotalCost - fxdAsst.dblSalvageValue)) / fxdAsst.dblAssetLife), 0) * lngDiff) / 365, 0);
                        }
                        fxdAsst.dblThisPeriodDep = dblDepreciation;
                    }

                    oFixed1.Add(fxdAsst);
                }
                dr.Close();
                if (oFixed1.Count > 0)
                {

                    foreach (FixedAssets1 oFixedItem in oFixed1)
                    {

                        strSQL = "SELECT ISNULL(SUM(ADJUSTMENT_AMOUNT),0) AMNT FROM ACC_FIXED_ASSET_ADJUSTMENT_DEP ";
                        strSQL = strSQL + "WHERE LEDGER_NAME = '" + oFixedItem.strAssetLedger + "' ";
                        strSQL = strSQL + "AND ADJUSTMENT_DATE < " + Utility.cvtSQLDateString(gdteFinicialYearFrom.ToString("dd/MM/yyyy")) + " ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            curPrevAdjustment = Convert.ToDouble(dr["AMNT"]);
                        }
                        dr.Close();

                        strSQL = "SELECT ISNULL(SUM(ADJUSTMENT_AMOUNT),0) AMNT FROM ACC_FIXED_ASSET_ADJUSTMENT_DEP ";
                        strSQL = strSQL + "WHERE LEDGER_NAME = '" + oFixedItem.strAssetLedger + "' ";
                        strSQL = strSQL + "AND ADJUSTMENT_DATE BETWEEN " + Utility.cvtSQLDateString(gdteFinicialYearFrom.ToString("dd/MM/yyyy")) + " ";
                        strSQL = strSQL + "AND " + Utility.cvtSQLDateString(dteAsOnDate.ToString("dd/MM/yyyy")) + " ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            curAdjustment = Convert.ToDouble(dr["AMNT"]);
                        }
                        dr.Close();

                        strSQL = "SELECT COMP_VOUCHER_DATE,isnull(SUM(VOUCHER_DEBIT_AMOUNT-VOUCHER_CREDIT_AMOUNT),0) AS AMNT FROM ACC_VOUCHER ";
                        strSQL = strSQL + "WHERE LEDGER_NAME = '" + oFixedItem.strAssetLedger + "' ";
                        strSQL = strSQL + "AND COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(gdteFinicialYearFrom.ToString("dd/MM/yyyy")) + " ";
                        strSQL = strSQL + "GROUP by COMP_VOUCHER_DATE ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        while (dr.Read())
                        {
                            dtePreviosDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]);
                            intPrevday = Utility.DateDiff(Utility.DateInterval.Day, dtePreviosDate, gdteFinicialYearFrom);
                            dblPreviousThisAmnt = dblPreviousThisAmnt + Math.Round(((((Convert.ToDouble(dr["AMNT"])) * oFixedItem.dblAssetLife) * intPrevday) / 365) / 100, 2);
                            PrevAdjustment = PrevAdjustment +Convert.ToDouble(dr["AMNT"]);

                            intDay = Utility.DateDiff(Utility.DateInterval.Day, gdteFinicialYearFrom, dteAsOnDate) + 1;
                            curAdjustmentAmnt = curAdjustmentAmnt + Math.Round(((((Convert.ToDouble(dr["AMNT"])) * oFixedItem.dblAssetLife) * intDay) / 365) / 100, 2);
                        }
                        dr.Close();

                        dblPrevBal = oFixedItem.dblTotalCost + PrevAdjustment;

                        dblDeprate = oFixedItem.vsngDepRate;
                        dblThisPeriodDep = oFixedItem.dblThisPeriodDep;
                        dblAddThisYear = oFixedItem.dblAddThisYear;
                        dblTotalSale = oFixedItem.dblTotalSale;
                        dblAccuDep = oFixedItem.dblAccuDep;
                        curPrevAdjustment = oFixedItem.curPrevAdjustment;

                        if (oFixedItem.dblAssetLife > 0)
                        {
                            intDay = Utility.DateDiff(Utility.DateInterval.Day, gdteFinicialYearFrom, dteAsOnDate) + 1;
                            // dblDepreciation = Math.Round(((((dblPurchase) * oFixedItem.dblAssetLife) * intDay) / 365) / 100, 0);
                            dblDepreciation = Math.Round(((((oFixedItem.dblTotalCost) * oFixedItem.dblAssetLife) * intDay) / 365) / 100, 0);
                        }
                        if (gdteFinicialYearFrom > dtePrevdate)
                        {
                            intPrevday = Utility.DateDiff(Utility.DateInterval.Day, dtePrevdate, gdteFinicialYearFrom);
                            //dblPreviousThisAmnt = Math.Round(((((PrevAdjustment) * oFixedItem.dblAssetLife) * intPrevday) / 365) / 100, 2);
                            dblPreviousAmnt = Math.Round(((((oFixedItem.dblTotalCost) * oFixedItem.dblAssetLife) * intPrevday) / 365) / 100, 0);
                            dblPreviousAmnt = dblPreviousAmnt + dblPreviousThisAmnt;
                        }
                        else
                        {
                            dblPreviousAmnt = 0;
                            dblPreviousAmnt = dblAccuDep ;
                        }
                        strSQL = "SELECT COMP_VOUCHER_DATE,VOUCHER_TOBY,SUM(VOUCHER_DEBIT_AMOUNT-VOUCHER_CREDIT_AMOUNT) AS AMOUNT FROM ACC_VOUCHER WHERE LEDGER_NAME = '" + oFixedItem.strAssetLedger + "' ";
                        strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(gdteFinicialYearFrom.ToString("dd/MM/yyyy")) + " ";
                        strSQL = strSQL + "AND " + Utility.cvtSQLDateString(dteAsOnDate.ToString("dd/MM/yyyy")) + ") ";
                        strSQL = strSQL + "GROUP BY COMP_VOUCHER_DATE,VOUCHER_TOBY ";
                        strSQL = strSQL + "ORDER BY COMP_VOUCHER_DATE ASC ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        while (dr.Read())
                        {
                            FixedAssets1 fxdAsstfinal = new FixedAssets1();
                            dtePurchaseDate = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]);
                            dblPurchase = Convert.ToDouble(dr["Amount"]);
                            strDrcr = dr["VOUCHER_TOBY"].ToString();
                            //dblPurchase = oFixedItem.dblTotalCost;
                            lngDiff = Utility.DateDiff(Utility.DateInterval.Day, dtePurchaseDate, oFixedItem.dteFromDate);
                            if (lngDiff > 0)
                            {
                                dteNextDate = oFixedItem.dteFromDate.AddDays(1);
                            }
                            else
                            {
                                dteNextDate = dtePurchaseDate.AddDays(1);
                            }
                            if (dblPurchase > 0)
                            {
                                dblAddThisYear = dblAddThisYear + dblPurchase;

                            }
                            if (dblPurchase < 0)
                            {
                                dblTotalSale = dblAddThisYear + Math.Abs(dblPurchase);

                            }
                            // dteNextDate = oFixedItem.dteAccToDate;


                            lngDiff = Utility.DateDiff(Utility.DateInterval.Day, oFixedItem.dteDiffEffDate, dtePurchaseDate);
                            if (lngDiff < 0)
                            {
                                intDay = Utility.DateDiff(Utility.DateInterval.Day, dtePurchaseDate, dteAsOnDate) + 1;
                                //intDay = DateDiff("d", dteDiffEffDate, uctxtAsOn.Text) + 1
                                dblThisPeriodDep = Math.Round(((((dblPurchase) * oFixedItem.dblAssetLife) * intDay) / 365) / 100, 2);
                            }
                            else
                            {
                                intDay = Utility.DateDiff(Utility.DateInterval.Day, dtePurchaseDate, dteAsOnDate) + 1;
                                dblThisPeriodDep = Math.Round(((((dblPurchase) * oFixedItem.dblAssetLife) * intDay) / 365) / 100, 2);
                            }

                            //if (oFixedItem.dblAssetLife > 0 && intCheck==0)
                            //{
                            //    intDay = Utility.DateDiff(Utility.DateInterval.Day, gdteFinicialYearFrom, dteAsOnDate) + 1;
                            //    // dblDepreciation = Math.Round(((((dblPurchase) * oFixedItem.dblAssetLife) * intDay) / 365) / 100, 0);
                            //    dblDepreciation = Math.Round(((((oFixedItem.dblTotalCost) * oFixedItem.dblAssetLife) * intDay) / 365) / 100, 0);
                            //}
                            //if (gdteFinicialYearFrom > dtePrevdate)
                            //{
                            //    intPrevday = Utility.DateDiff(Utility.DateInterval.Day, dtePrevdate, gdteFinicialYearFrom);
                            //    //dblPreviousThisAmnt = Math.Round(((((PrevAdjustment) * oFixedItem.dblAssetLife) * intPrevday) / 365) / 100, 2);
                            //    dblPreviousAmnt = Math.Round(((((oFixedItem.dblTotalCost) * oFixedItem.dblAssetLife) * intPrevday) / 365) / 100, 0);
                            //    dblPreviousAmnt = dblPreviousAmnt + dblPreviousThisAmnt;
                            //}

                            dblThisPeriodDep = dblThisPeriodDep + dblDepreciation + curAdjustmentAmnt;
                            dblAccuDep = dblAccuDep + dblDepreciation;
                            dteFromDate = dtePurchaseDate.AddDays(1);
                            dblTotalCost = dblTotalCost + dblPurchase + dblTotalSale;
                            
                            fxdAsstfinal.vsngDepRate = oFixedItem.vsngDepRate;
                            fxdAsstfinal.strAssetNumber = oFixedItem.strAssetNumber;
                            fxdAsstfinal.strAssetLedger = oFixedItem.strAssetLedger;
                            fxdAsstfinal.dblPrevBal = dblPrevBal;
                            fxdAsstfinal.dblAddThisYear = dblAddThisYear;
                            fxdAsstfinal.dblTotalSale = dblTotalSale;
                            fxdAsstfinal.dblThisPeriodDep = Math.Round(dblThisPeriodDep,2);
                            fxdAsstfinal.dblAccuDepBak =dblPreviousAmnt; //Closing
                            fxdAsstfinal.curPrevAdjustment = curPrevAdjustment;
                            fxdAsstfinal.curAdjustment = curAdjustment;
                            fxdAsstfinal.dblInitialCost = 0;
                            oFixedAssetFinal.Add(fxdAsstfinal);
                            dblThisPeriodDep = 0;
                            dblAccuDep = 0;
                            dblTotalSale = 0;
                            dblPurchase = 0;
                            dblAddThisYear = 0;
                            dblPrevBal = 0;
                            dblDepreciation = 0;
                            dblPreviousAmnt = 0;
                            dblPreviousThisAmnt = 0;
                            //intCheck = 1;

                        }
                        if (!dr.HasRows)
                        {
                            if (gdteFinicialYearFrom> dtePrevdate)
                            {
                                intPrevday = Utility.DateDiff(Utility.DateInterval.Day, dtePrevdate, gdteFinicialYearFrom);
                                //dblPreviousThisAmnt = Math.Round(((((PrevAdjustment) * oFixedItem.dblAssetLife) * intPrevday) / 365) / 100, 2);
                                dblPreviousAmnt = Math.Round(((((oFixedItem.dblTotalCost) * oFixedItem.dblAssetLife) * intPrevday) / 365) / 100, 0);
                                dblPreviousAmnt = dblPreviousAmnt + dblPreviousThisAmnt;
                            }
                           
                            intDay = Utility.DateDiff(Utility.DateInterval.Day, gdteFinicialYearFrom, dteAsOnDate) + 1;
                            dblThisPeriodDep = Math.Round(((((oFixedItem.dblTotalCost) * oFixedItem.dblAssetLife) * intDay) / 365) / 100, 0);

                            dblThisPeriodDep = dblThisPeriodDep + 0 + curAdjustmentAmnt ;
                            FixedAssets1 fxdAsstfinal = new FixedAssets1();
                            fxdAsstfinal.strAssetNumber = oFixedItem.strAssetNumber;
                            fxdAsstfinal.strAssetLedger = oFixedItem.strAssetLedger;
                            fxdAsstfinal.dblPrevBal = dblPrevBal;
                            fxdAsstfinal.dblAddThisYear = dblAddThisYear;
                            fxdAsstfinal.dblTotalSale = dblTotalSale;
                            //fxdAsstfinal.dblThisPeriodDep = Math.Round(((dblPrevBal) * dblDeprate) / 100, 0);
                            fxdAsstfinal.dblThisPeriodDep = dblThisPeriodDep;
                            //fxdAsstfinal.dblAccuDepBak = oFixedItem.dblAccuDep;
                            fxdAsstfinal.dblAccuDepBak = Math.Round(dblPreviousAmnt, 2); //Closing

                            fxdAsstfinal.curPrevAdjustment = curPrevAdjustment;
                            fxdAsstfinal.curAdjustment = curAdjustment;
                            fxdAsstfinal.vsngDepRate = dblDeprate;
                            fxdAsstfinal.dblInitialCost = 0;
                            oFixedAssetFinal.Add(fxdAsstfinal);
                            
                            dblAddThisYear = 0;
                            curAdjustmentAmnt = 0;
                            dblDepreciation = 0;
                            dblPreviousAmnt = 0;
                        }
                        dr.Close();

                    }

                }

                if (oFixedAssetFinal.Count > 0)
                {
                    foreach (FixedAssets1 ofxdInsert in oFixedAssetFinal)
                    {
                        strSQL = "INSERT INTO FIXED_ASSET_SCHEDULE(ASSET_NUMBER,LEDGER_NAME,";
                        strSQL = strSQL + "ASSET_PREV_BAL,ASSET_ADD_THIS_PERIOD,";
                        strSQL = strSQL + "ASSET_DISPOSAL_THIS_PERIOD,ASSET_DEP_RATE,ASSET_DEP_THIS_PERIOD, ";
                        strSQL = strSQL + "ASSET_DEP_ACCU,ASSET_PURCHASE_VALUE) ";
                        strSQL = strSQL + "VALUES(" + ofxdInsert.strAssetNumber + ",";
                        strSQL = strSQL + "'" + ofxdInsert.strAssetLedger + "'," + ofxdInsert.dblPrevBal + ",";
                        strSQL = strSQL + " " + ofxdInsert.dblAddThisYear + "," + ofxdInsert.dblTotalSale + ",";
                        strSQL = strSQL + " " + ofxdInsert.vsngDepRate + "," + ofxdInsert.dblThisPeriodDep + ", ";
                        strSQL = strSQL + " " + ofxdInsert.dblAccuDepBak + "," + ofxdInsert.dblInitialCost + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                cmdInsert.Transaction.Commit();

                List<RFixedAsset> ooAccLedger = new List<RFixedAsset>();
                strSQL = "SELECT LEDGER_PARENT_GROUP,LEDGER_NAME, ISNULL(SUM(ASSET_PREV_BAL),0) ASSET_PREV_BAL, ISNULL(SUM(ASSET_ADD_THIS_PERIOD),0) ASSET_ADD_THIS_PERIOD, ISNULL(SUM(ASSET_DISPOSAL_THIS_PERIOD),0)ASSET_DISPOSAL_THIS_PERIOD,  ";
                strSQL = strSQL + "ASSET_DEP_RATE, ISNULL(SUM(ASSET_DEP_THIS_PERIOD),0) ASSET_DEP_THIS_PERIOD, ISNULL(SUM(ASSET_DEP_ACCU),0) ASSET_DEP_ACCU,ISNULL(SUM( ASSET_DEP_ADJUSTMENT) ,0)ASSET_DEP_ADJUSTMENT ";
                strSQL = strSQL + "FROM  ACC_FIXED_ASSET_REPORT_QRY AS ACC_FIXED_ASSET_REPORT_QRY  ";
                strSQL = strSQL + "GROUP BY LEDGER_PARENT_GROUP,LEDGER_NAME,ASSET_DEP_RATE ";
                strSQL = strSQL + "ORDER BY LEDGER_PARENT_GROUP, LEDGER_NAME  ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RFixedAsset oLedg = new RFixedAsset();
                    oLedg.strLedgerName = dr["LEDGER_NAME"].ToString();
                    oLedg.dblAssetPrevBal = Convert.ToDouble(dr["ASSET_PREV_BAL"].ToString());
                    oLedg.dblAssetAddThisPeriod = Convert.ToDouble(dr["ASSET_ADD_THIS_PERIOD"].ToString());
                    oLedg.dblAssetDisposalthisPeriod = Convert.ToDouble(dr["ASSET_DISPOSAL_THIS_PERIOD"].ToString());
                    oLedg.dblAssetDepRate = Convert.ToDouble(dr["ASSET_DEP_RATE"].ToString());
                    oLedg.dblAssetDepThisPeriod = Convert.ToDouble(dr["ASSET_DEP_THIS_PERIOD"].ToString());
                    oLedg.dblAssetDepAccu = Convert.ToDouble(dr["ASSET_DEP_ACCU"].ToString());
                    oLedg.dblAssetDepAdjustMent = Convert.ToDouble(dr["ASSET_DEP_ADJUSTMENT"].ToString());
                    oLedg.strLedgerGroupParent = dr["LEDGER_PARENT_GROUP"].ToString();
                    ooAccLedger.Add(oLedg);
                }

                if (!dr.HasRows)
                {
                    RFixedAsset oLedg = new RFixedAsset();
                    oLedg.strLedgerName = "";
                    oLedg.dblAssetPrevBal = 0;
                    oLedg.dblAssetAddThisPeriod = 0;
                    oLedg.dblAssetDisposalthisPeriod = 0;
                    oLedg.dblAssetDepRate = 0;
                    oLedg.dblAssetDepThisPeriod = 0;
                    oLedg.dblAssetDepAccu = 0;
                    oLedg.dblAssetDepAdjustMent = 0;
                    oLedg.strLedgerGroupParent = "";
                    ooAccLedger.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return ooAccLedger;
            }
        }

        #region "Comments"

        //public string mUpdateReducingBalance(DateTime gdteFinicialYearFrom)
        //{
        //    //string strAssetLedger = "", strAssetNumber = "", strFromDate = "",dteAccToDate,dteNextDate, dteDiffEffDate = "", vsngDepRate = "";
        //    //double dblAccuDep = 0, dblWrittenDownValue = 0, dblTotalCost;
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        SqlDataReader dr;
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
        //        List<FixedAssets1> oFixed1 = new List<FixedAssets1>();
        //        strSQL = "SELECT * FROM ACC_FIXED_ASSETS WHERE ASSET_DEP_METHOD = 1 ";
        //        cmdInsert.CommandText = strSQL;
        //        dr = cmdInsert.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            FixedAssets1 fxdAsst = new FixedAssets1();
        //            fxdAsst.strAssetLedger = dr["LEDGER_NAME"].ToString();
        //            fxdAsst.strAssetNumber = dr["ASSET_SERIAL"].ToString();
        //            fxdAsst.dteFromDate = Convert.ToDateTime(dr["ASSET_DEP_EFF_DATE"]);
        //            fxdAsst.dteDiffEffDate = Convert.ToDateTime(dr["ASSET_DEP_EFF_DATE"]);
        //            fxdAsst.vsngDepRate = dr["ASSET_DEP_RATE"].ToString();
        //            fxdAsst.dblAccuDep = Convert.ToDouble(dr["ASSET_ACCU_DEP"]);
        //            fxdAsst.dblWrittenDownValue = Utility.mdblGetOpening(fxdAsst.strAssetLedger) * -1;
        //            fxdAsst.dblTotalCost = fxdAsst.dblWrittenDownValue;
        //            //dteAccToDate =  DateAdd("d", -1, gdteFinicialYearFrom);
        //            fxdAsst.dteAccToDate = gdteFinicialYearFrom.AddDays(-1);
        //            fxdAsst.dteNextDate = gdteFinicialYearFrom;
        //            oFixed1.Add(fxdAsst);
        //        }
        //        dr.Close();
        //        if (oFixed1.Count > 0)
        //        {
        //            DateTime dteMinDate;
        //            long lngDiff, lngYearDays = 0, lngSeg = 0, lnglastLoop = 0, lngLoopPrior = 0;
        //            double dblPrePurchase = 0, dblTotalCost = 0, dblWrittenDownValue = 0, dblDepreciation = 0, dblCurrDepr = 0;
        //            bool blnYearDays = false;
        //            DateTime dteAccToDate;
        //            foreach (FixedAssets1 oFixedItem in oFixed1)
        //            {
        //                if (oFixedItem.dblTotalCost == 0)
        //                {
        //                    strSQL = "SELECT MIN(COMP_VOUCHER_DATE) AS MINDATE FROM ACC_VOUCHER ";
        //                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + oFixedItem.strAssetLedger + "' ";
        //                    cmdInsert.CommandText = strSQL;
        //                    dr = cmdInsert.ExecuteReader();
        //                    if (dr.Read())
        //                    {
        //                        if (dr["MINDATE"].ToString() != "")
        //                        {
        //                            dteMinDate = Convert.ToDateTime(dr["MINDATE"]);
        //                        }
        //                        else
        //                        {
        //                            lngDiff = Utility.DateDiff(Utility.DateInterval.Day, oFixedItem.dteFromDate, gdteFinicialYearFrom);
        //                            if (lngDiff > 0)
        //                            {
        //                                dblPrePurchase = Utility.mdblPrePurchase(oFixedItem.strAssetLedger, oFixedItem.dteFromDate.ToString("dd/MM/yyyy"));
        //                                dblTotalCost = dblWrittenDownValue + dblPrePurchase;
        //                            }
        //                            dteMinDate = oFixedItem.dteFromDate;
        //                        }
        //                        dr.Close();
        //                        if (dblWrittenDownValue == 0)
        //                        {
        //                            lngDiff = Utility.DateDiff(Utility.DateInterval.Day, dteMinDate, oFixedItem.dteAccToDate) + 1;
        //                        }
        //                        else
        //                        {
        //                            lngDiff = Utility.DateDiff(Utility.DateInterval.Day, dteMinDate, oFixedItem.dteAccToDate) + 1;
        //                        }

        //                        if (lngDiff > 0)
        //                        {
        //                            //lngYearDays = mlngTotalDays(dteMinDate, dteAccToDate);
        //                            lngYearDays = Convert.ToInt64(dteMinDate.Subtract(oFixedItem.dteAccToDate).TotalDays);
        //                            lngSeg = lngDiff % lngYearDays;
        //                            if (lngSeg > 0)
        //                            {
        //                                blnYearDays = Utility.mblnLeapYear(dteMinDate, oFixedItem.dteAccToDate);
        //                            }
        //                            if (blnYearDays)
        //                            {
        //                                lngSeg = lngSeg - 1;
        //                            }
        //                            lnglastLoop = (lngDiff - lngSeg) / lngYearDays;
        //                            //dteAccToDate = DateAdd("d", -1, DateAdd("d", lngSeg, dteMinDate));
        //                            dteAccToDate = (dteMinDate.AddDays(lngSeg)).AddDays(-1);

        //                            for (lngLoopPrior = 0; lngLoopPrior <= lnglastLoop; lngLoopPrior++)
        //                            {
        //                                lngDiff = Utility.DateDiff(Utility.DateInterval.Day, dteMinDate, oFixedItem.dteAccToDate) + 1;

        //                                if (lngDiff > 0)
        //                                {
        //                                    lngYearDays = Convert.ToInt64(dteMinDate.Subtract(oFixedItem.dteAccToDate).TotalDays);
        //                                }
        //                                else
        //                                {
        //                                    lngYearDays = 365;
        //                                }
        //                                dblDepreciation = Math.Round((((((oFixedItem.dblTotalCost - dblPrePurchase) - oFixedItem.dblAccuDep) * Convert.ToDouble(oFixedItem.vsngDepRate) * lngDiff) / lngYearDays) / 100), 0);
        //                                dblCurrDepr = dblCurrDepr + dblDepreciation;

        //                                dblDepreciation = Math.Round(((((dblPrePurchase) * Convert.ToDouble(oFixedItem.vsngDepRate) * lngDiff) / lngYearDays) / 100), 0);
        //                                dblCurrDepr = dblCurrDepr + dblDepreciation;

        //                                strSQL = "SELECT COMP_VOUCHER_DATE,SUM(VOUCHER_DEBIT_AMOUNT - VOUCHER_CREDIT_AMOUNT) AS AMOUNT ";
        //                                strSQL = strSQL + "FROM ACC_VOUCHER WHERE LEDGER_NAME = '" + oFixedItem.strAssetLedger + "' ";
        //                                strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(dteMinDate.ToString("dd/MM/yyyy") + " ";
        //                                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(dteAccToDate.ToString("dd/MM/yyyy")) + ") ";
        //                                strSQL = strSQL + "GROUP BY COMP_VOUCHER_DATE ";
        //                                strSQL = strSQL + "ORDER BY COMP_VOUCHER_DATE ASC ";
        //                                cmdInsert.CommandText = strSQL;
        //                                dr = cmdInsert.ExecuteReader();
        //                                while (dr.Read())
        //                                {

        //                                }


        //                            }











        //                        }


        //                    }
        //                }



        //            }
        //        }





        //    }



        //}
        #endregion

















    }
}
