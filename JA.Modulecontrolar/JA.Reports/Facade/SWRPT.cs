using JA.Reports.Dal;
using JA.Reports.DAL;
using JA.Reports.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JA.Reports.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SWRPT" in both code and config file together.
    public class SWRPT : ISWRPT
    {
        public List<RoStockRequisition> mGetStockIn(string strDeComID, string strRefNo)
        {
            return new RInventory().mGetStockIn(strDeComID, strRefNo);
        }
        public List<RoStockRequisition> mGetStockOut(string strDeComID, string strRefNo)
        {
            return new RInventory().mGetStockOut(strDeComID, strRefNo);
        }
        public List<RoStockRequisition> mGetStockRequisition(string strDeComID, string strRefNo)
        {
            return new RInventory().mGetStockRequisition(strDeComID, strRefNo);
        }
        public List<RoPFHL> mGetMpoClosingValue(string strDeComID, string strFate, string strBranchID, string strPartyName, int intstatus)
        {
            return new RInventory().mGetMpoClosingValue(strDeComID, strFate, strBranchID, strPartyName, intstatus);
        }
        public List<RoDayliCollection> mGetCollectionStatementIndividual(string strDeComID, string strFdate, string strTDate, string strBranchId, string strLedgername)
        {
            return new RInventory().mGetCollectionStatementIndividual(strDeComID, strFdate, strTDate, strBranchId, strLedgername);
        }
        public List<RoDayliCollection> mGetCollectionStatement(string strDeComID, string strFdate, string strTDate, string strBranchId, string strString, int intmode,
                                                        bool blngAccessControl, string strUserName, double dblValue, string strValOption, string strReportOption, int intStatus)
        {
            return new RInventory().mGetCollectionStatement(strDeComID, strFdate, strTDate, strBranchId, strString, intmode,
                                                         blngAccessControl, strUserName, dblValue, strValOption, strReportOption, intStatus);
        }
        public List<RoPFHL> mGetPFHL(string strDeComID, string strFdate, string strTDate, string strBranchId, string strLedgername)
        {
            return new RInventory().mGetPFHL(strDeComID, strFdate, strTDate, strBranchId, strLedgername);
        }
        #region "Daily Coll New"
        public List<RoDayliCollection> mgetDailyCollectionN(string strDeComID)
        {
            return new RInventory().mgetDailyCollectionN(strDeComID);
        }
        #endregion
        #region "Yealy/Monthly Payment Summ"
        public List<RoPaymentSummaryMonthly> mGetPaymentSummaryMonthly(string strDeComID, string strYear, int intmode)
        {
            return new RInventory().mGetPaymentSummaryMonthly(strDeComID, strYear,  intmode);
        }
        public List<RoPaymentSummaryearly> mGetPaymentSummaryYearly(string strDeComID, string strYear1, int intmode)
        {
            return new RInventory().mGetPaymentSummaryYearly(strDeComID, strYear1, intmode);
        }
        #endregion
        #region "Production"
        public List<RoMonthlyProduction> mGetloadPowerClass(string strDeComID)
        {
            return new RInventory().mGetloadPowerClass(strDeComID);
        }
        public List<RoPackingRawMaterialsStockinfo> mGetLocationQty2(string strDeComID, string strFdate, string strTDate, string strString, string strSelction,
                                               int intZeroQntySuppress, string strStringNew)
        {
            return new RInventory().mGetLocationQty2(strDeComID, strFdate, strTDate, strString, strSelction,
                                                    intZeroQntySuppress, strStringNew);
        }
        public List<RoConsumption> mGetConversion(string strDeComID, string strFdate, string strTDate, string strStockGroup, string strLoacation, string strpowerClass, int intROption)
        {
            return new RInventory().mGetConversion(strDeComID, strFdate, strTDate, strStockGroup, strLoacation, strpowerClass, intROption);
        }


        public List<RoMonthlyProduction> mGetMonthlyProductionClassPower(string strDeComID, string strFdate, string strTDate, string strStockGroup, string strLoacation, string strpowerClass, int intROption)
        {
            return new RInventory().mGetMonthlyProductionClassPower(strDeComID, strFdate, strTDate, strStockGroup, strLoacation, strpowerClass, intROption);
        }
        public List<RoMonthlyProduction> mGetMonthlyProduction(string strDeComID, string strFdate, string strTDate, string strStockGroup, string strLoacation, int intROption)
        {
            return new RInventory().mGetMonthlyProduction(strDeComID, strFdate, strTDate, strStockGroup, strLoacation, intROption);
        }
        public List<RoProduction> GetBatchWiseProductionInd(string strDeComID, string vstrRefNo)
        {
            return new RInventory().GetBatchWiseProductionInd(strDeComID, vstrRefNo);
        }
        #endregion
        #region "SP Commission"
        public List<RoMCommission> GetrptSPCommissionHead(string strDeComID, string strCardNo, string strFdate, string strTdate)
        {
            return new RInventory().GetrptSPCommissionHead(strDeComID, strCardNo, strFdate, strTdate);
        }
        public List<RoMCommission> GetrptSPCommission3(string strDeComID, string strFate, string strTDate, string strGrid)
        {
            return new RInventory().GetrptSPCommission3(strDeComID, strFate, strTDate, strGrid);
        }
        #endregion
        #region "CompanyID"
        public string gOpenComID(string strID)
        {
            return new RInventory().gOpenComID(strID);
        }
        #endregion
        public void DoWork()
        {
        }
        #region "CommitionN"
        public List<RStockInformation> mGetCommitionN(string strDeComID, string strFdate, string strTDate, string strBranchId, string strLedgername)
        {
            return new RInventory().mGetCommitionN(strDeComID, strFdate, strTDate, strBranchId, strLedgername);
        }
        #endregion
        #region "Inventory"
        public List<RStockInformation> mGetGroupCommissionWithSales(string strDeComID, string strFdate, string strTDate, string strString)
        {
            return new RInventory().mGetGroupCommissionWithSales(strDeComID, strFdate, strTDate, strString);
        }
        public List<RCreditLimit> mDisplayCreditLimitListAll(string strDeComID, string strKey, string strSeclection)
        {
            return new RInventory().mDisplayCreditLimitListAll(strDeComID, strKey, strSeclection);
        }
        public List<RStockInformation> mGetindividualSalpmle(string strDeComID, string strRefNo)
        {
            return new RInventory().mGetindividualSalpmle(strDeComID, strRefNo);
        }
        public string mInsertTempSaleaPrcice(string strCon, string striItemName, string strLevel)
        {
            return new RInventory().mInsertTempSaleaPrcice(strCon, striItemName,strLevel);
        }
         public List<RStockInformation> mGetSalesPriceItem(string strCon, string strgroupName, string strcategory)
         {
             return new RInventory().mGetSalesPriceItem(strCon, strgroupName, strcategory);
         }
      
        public List<RStockInformation> mgetStockSummarySPriceWise(string strDeComID, string strString, int intmode)
        {
            return new RInventory().mgetStockSummarySPriceWise(strDeComID, strString, intmode);
        }
        public List<RStockInformation> mloadCategoryGroup(string strDeComID, int intmode)
        {
            return new RInventory().mloadCategoryGroup(strDeComID, intmode);
        }
        //public List<RStockInformation> mItemMasterForvalue(string strDeComID, string strFdate, string strTDate, string strString, string strSelction,
        //                                      int intZeroQntySuppress, string strBranchID)
        //{
        //    return new RInventory().mItemMasterForvalue(strDeComID, strFdate, strTDate, strString, strSelction, intZeroQntySuppress,strBranchID);
        //}
        public List<RStockInformation> mGetLocationQty(string strDeComID, string strFdate, string strTDate, string strString, string strSelction,
                                                    int intZeroQntySuppress)
        {
            return new RInventory().mGetLocationQty(strDeComID, strFdate, strTDate, strString, strSelction, intZeroQntySuppress);
        }
        public List<RStockInformation> mGetNegetiveStock(string strDeComID)
        {
            return new RInventory().mGetNegetiveStock(strDeComID);
        }
        public List<RStockInformation> mGetBOMList(string strDeComID, string strProcessname, string strType)
        {
            return new RInventory().mGetBOMList(strDeComID, strProcessname,strType);
        }
        //public List<RStockInformation> mGetSlowFastMoving(string strDeComID, string strFdate, string strTDate, DateTime dteTDate, string str_S_F_Z, string strSelction, string strString)
        //{
        //    return new RInventory().mGetSlowFastMoving(strDeComID, strFdate, strTDate, dteTDate, str_S_F_Z, strSelction, strString);
        //}
        public List<RStockInformation> mGetMFGProcessReport(string strDeComID, string strProcessname, int intSelection)
        {
            return new RInventory().mGetMFGProcessReport(strDeComID, strProcessname,intSelection);
        }
        public List<RStockInformation> mGetProductTopSheetSalesPrice(string strDeComID, string strFdate, string strTDate)
        {
            return new RInventory().mGetProductTopSheetSalesPrice(strDeComID, strFdate, strTDate);
        }
        public List<RStockInformation> mGetStockRegister(string strDeComID, string strFdate, string strTDate, string strFromLocation, string strTLocation)
        {
            return new RInventory().mGetStockRegister(strDeComID, strFdate, strTDate, strFromLocation, strTLocation);
        }
        public List<RStockInformation> mGetGroupCommissionSubReport(string strDeComID, string strFdate, string strTDate)
        {
            return new RInventory().mGetGroupCommissionSubReport(strDeComID, strFdate, strTDate);
        }
        public List<RStockInformation> mGetGroupCommission(string strDeComID, string strFdate, string strTDate, string strString)
        {
            return new RInventory().mGetGroupCommission(strDeComID, strFdate, strTDate, strString);
        }
        public List<RStockInformation> mGetProductStatementCross(string strDeComID, string strFdate, string strTDate, int inttype)
        {
            return new RInventory().mGetProductStatementCross(strDeComID, strFdate, strTDate, inttype);
        }
        public List<RStockInformation> mGetProductTopSheet(string strDeComID, string strFdate, string strTDate)
        {
            return new RInventory().mGetProductTopSheet(strDeComID, strFdate, strTDate);
        }
        public List<RStockInformation> mGetProductStatement(string strDeComID, string strFdate, string strTDate, string strstring, string strBranchID, int intMode, int intPhyType, int intAliasSorting)
        {
            return new RInventory().mGetProductStatement(strDeComID, strFdate, strTDate, strstring, strBranchID, intMode, intPhyType,intAliasSorting);
        }
        public List<RStockInformation> mGetLocationWiseConsumtion(string strDeComID, string strFdate, string strTDate, string strstring)
        {
            return new RInventory().mGetLocationWiseConsumtion(strDeComID, strFdate, strTDate, strstring);
        }
        public List<RStockInformation> mGetStockSummSalesPrice(string strDeComID, string strLevel, string strCateGory, int intType)
        {
            return new RInventory().mGetStockSummSalesPrice(strDeComID, strLevel, strCateGory, intType);
        }
        //public List<RStockInformation> mItemMaster(string strDeComID, string strFdate, string strTDate, string strString, string strSelction, int intZeroQntySuppress, bool gstrUserName, string strUserName, string strSelction2)
        //{
        //    return new RInventory().mItemMaster(strDeComID, strFdate, strTDate, strString, strSelction, intZeroQntySuppress, gstrUserName, strUserName,strSelction2);
        //}
        public List<RStockInformation> mGetStoreLedger(string strDeComID, string strFdate, string strTDate, string strString, string strLocatiion)
        {
            return new RInventory().mGetStoreLedger(strDeComID, strFdate, strTDate, strString, strLocatiion);
        }
        public List<RStockInformation> mGetInventortyVoucher(string strDeComID, string strFdate, string strTDate, string strSelection, string strBranchName, string strRefNo, string strSummDet)
        {
            return new RInventory().mGetInventortyVoucher(strDeComID, strFdate, strTDate, strSelection, strBranchName, strRefNo, strSummDet);
        }
        public List<RStockInformation> mGetProfitability(string strDeComID, string strFdate, string strTDate, string strGroupName)
        {
            return new RInventory().mGetProfitability(strDeComID, strFdate, strTDate, strGroupName);
        }
        #endregion
        #region "Accounts"
        #region "Honda Loan"
        public List<RHondaLoan> mGetHondaLoan(string strDeComID, string strBranchID, string strLedgerName, string strGroupName, string strFdate, string strTDate, int intMode, string strLoanDate, int intSuppress)
        {
            return new RInventory().mGetHondaLoan(strDeComID, strBranchID, strLedgerName, strGroupName, strFdate, strTDate, intMode, strLoanDate,intSuppress);
        }
        public List<RHondaLoan> mHondaLoanFineRecAmoun(string strDeComID, string strLedgerName)
        {
            return new RInventory().mHondaLoanFineRecAmoun(strDeComID, strLedgerName);
        }
        #endregion
        //public List<RCreditLimit> mGetCreditLimit(string strDeComID,string strBranchID, string strdate1, string strdate2, string strdate3, string strdate4, string strlastdate, string strstring, int Intmode)
        //{
        //    return new RInventory().mGetCreditLimit(strDeComID,strBranchID, strdate1, strdate2, strdate3, strdate4, strlastdate, strstring, Intmode);
        //}
        public List<RAccountsGroup> mGetAccountsDoctotorvoucher(string strDeComID, string strRefNo)
        {
            return new RInventory().mGetAccountsDoctotorvoucher(strDeComID, strRefNo);
        }

        //public List<RFinalStatement> mGetFinalStattemnetCustomer(string strDeComID, string strFate, string strTDate, string strBranchID, string strGroupName, string strPartyName, int intstatus, string CustomerGroup, string strCustomer)
        //{
        //    return new RInventory().mGetFinalStattemnetCustomer(strDeComID, strFate, strTDate, strBranchID, strGroupName, strPartyName, intstatus, CustomerGroup, strCustomer);
        //}
        public List<RAudit> mGetMR(string strDeComID, string RefNo,int intVtype)
        {
            return new RInventory().mGetMR(strDeComID, RefNo, intVtype);
        }
        public List<RAudit> mGetHeader(string strDeComID, int intMode)
        {
            return new RInventory().mGetHeader(strDeComID, intMode);
        }
        public List<RAccountsGroup> mTradingQueryVertical(string strDeComID, float intmode)
        {
            return new RInventory().mTradingQueryVertical(strDeComID, intmode);
        }
        public List<RAccountsGroup> mGetDailyCollectionDetails(string strDeComID, string strFate, string strTDate, string strBranchID)
        {
            return new RInventory().mGetDailyCollectionDetails(strDeComID, strFate, strTDate, strBranchID);
        }
        public List<RAudit> mgetUserPrivilage(string strDeComID, string strUserName)
        {
            return new RInventory().mgetUserPrivilage(strDeComID, strUserName);
        }

        public List<RAccountsGroup> mGetBudgetledgerList(string strDeComID)
        {
            return new RInventory().mGetBudgetledgerList(strDeComID);
        }

        public List<RAccountsGroup> mGetBudget(string strDeComID, string strString, string strFdate, string strTdate)
        {
            return new RInventory().mGetBudget(strDeComID, strString, strFdate, strTdate);
        }
        public List<RAccountsGroup> mGetAccountsvoucherSP(string strDeComID, int intVtype, int intSummDetails, string strRefNo,
                                                            string strBranchID, string strFPrevious, string strTPrevious, string strPmonthid)
        {
            return new RInventory().mGetAccountsvoucherSP(strDeComID, intVtype, intSummDetails, strRefNo, strBranchID, strFPrevious, strTPrevious,strPmonthid);
        }

        public List<RAudit> mGetAudit(string strDeComID, string strFdate, string strTDate, int intVtype, string strLedger, int intROption)
        {
            return new RInventory().mGetAudit(strDeComID, strFdate, strTDate, intVtype, strLedger, intROption);
        }

        public List<RStatistics> mGetStatistics(string strDeComID, string strFdate, string strTdate)
        {
            return new RInventory().mGetStatistics(strDeComID, strFdate, strTdate);
        }
        public List<RFixedAsset> mUpdateReducingBalance(string strDeComID, DateTime gdteFinicialYearFrom, DateTime strAsOnDate)
        {
            return new JFixedAssets().mUpdateReducingBalance(strDeComID, gdteFinicialYearFrom, strAsOnDate);
        }
        public List<RFixedAsset> mUpdateStraightLine(string strDeComID, DateTime gdteFinicialYearFrom, DateTime strAsOnDate, DateTime dtePrevdate)
        {
            return new JFixedAssets().mUpdateStraightLine(strDeComID, gdteFinicialYearFrom, strAsOnDate,dtePrevdate);
        }
        public List<RAccountsGroup> mGetChequePrint(string strDeComID, int intMode, string RefNo, string strString)
        {
            return new RInventory().mGetChequePrint(strDeComID, intMode, RefNo, strString);
        }
        public List<RAccountsGroup> GetrptExpenseSummary(string strDeComID, string strFate, string strTDate, int intSumDet)
        {
            return new RInventory().GetrptExpenseSummary(strDeComID, strFate, strTDate,intSumDet);
        }
        public List<RAccountsGroup> GetrptCollectionTargetAchieve(string strDeComID, string strBranchID, string strStringMonth, string strSelection, string strFate, 
                                                                    string strTDate, string strSalesFate, string strSalesTDate, int inttype, int intStatus,string gstruserName)
        {
            return new RInventory().GetrptCollectionTargetAchieve(strDeComID, strBranchID, strStringMonth, strSelection, strFate, strTDate, strSalesFate, strSalesTDate, inttype, intStatus, gstruserName);
        }
        //public List<RAccountsGroup> GetrptSPCommission(string strDeComID, string strFate, string strTDate)
        //{
        //    return new RInventory().GetrptSPCommission(strDeComID, strFate, strTDate);
        //}
        public List<RAccountsGroup> mGetContractsPartBill2(string strDeComID, string strFate, string strTDate, string strBranchID, string strPartName)
        {
            return new RInventory().mGetContractsPartBill2(strDeComID, strFate, strTDate, strBranchID, strPartName);
        }
        public List<RAccountsGroup> mGetPostDateCheque(string strDeComID, string strFate, string strTDate, string strSelection, string strVCDate)
        {
            return new RInventory().mGetPostDateCheque(strDeComID, strFate, strTDate,  strSelection, strVCDate);
        }
        public List<RAccountsGroup> getrptChequePayment(string strDeComID, string strFate, string strTDate, int intSorting)
        {
            return new RInventory().getrptChequePayment(strDeComID, strFate, strTDate,intSorting);
        }
        public List<RFinalStatement> mGetMarketMonitoringSheet(string strDeComID, string strFate, string strTDate,
                                                                string strBranchID, int intstatus, string strString, string strUserName, int intSelection)
        {
            return new RInventory().mGetMarketMonitoringSheet(strDeComID, strFate, strTDate, strBranchID, intstatus, strString, strUserName,intSelection);
        }
        public List<RFinalStatement> mGetFinalStattemnet(string strDeComID, string strFate, string strTDate, string strBranchID, string strGroupName, string strPartyName,
                                                            int intstatus, int intOrderby, double dblValue,double dblValueBelow, string strValOption, string gstrUserName)
        {
            return new RInventory().mGetFinalStattemnet( strDeComID,  strFate,  strTDate,  strBranchID,  strGroupName,  strPartyName,  intstatus,  intOrderby,  dblValue,dblValueBelow,  strValOption,gstrUserName);
        }
        public List<RAccountsGroup> mGetContractsPartBill(string strDeComID, string strFate, string strTDate, string strBranchID, string strPartName)
        {
            return new RInventory().mGetContractsPartBill(strDeComID, strFate, strTDate, strBranchID, strPartName);
        }
        public List<RAccountsGroup> mGetDailyCollection(string strDeComID, string strFate, string strTDate, string strBranchID, string struserName,
                                                            string strBkash, int intasperBkash, string strHlFdate)
        {
            return new RInventory().mGetDailyCollection(strDeComID, strFate, strTDate, strBranchID, struserName, strBkash, intasperBkash, strHlFdate);
        }
        public int mGetBalanceSheet(string strDeComID, DateTime strFdate, DateTime strTDate, int intHorVer, double dblClosing)
        {
            return new RInventory().mGetBalanceSheet(strDeComID, strFdate, strTDate,intHorVer, dblClosing);
        }
        public List<RAccountsGroup> mGetTrailBalance(string strDeComID, DateTime strFdate, DateTime strTDate, int selection)
        {
            return new RInventory().mGetTrailBalance(strDeComID, strFdate, strTDate, selection);
        }
        public List<RAccountsGroup> mGetTrailBalanceQuery(string strDeComID)
        {
            return new RInventory().mGetTrailBalanceQuery(strDeComID);
        }

        public List<RAccountsGroup> mGetBalanceSheetQuery(string strDeComID, int intMode)
        {
            return new RInventory().mGetBalanceSheetQuery(strDeComID, intMode);
        }
        public int mGetProfitLoss(string strDeComID, DateTime dtefFdate, DateTime dteTDate, string vstrBranchID, int intHorVer)
        {
            return new RInventory().mGetProfitLoss(strDeComID, dtefFdate, dteTDate, vstrBranchID,intHorVer);
        }
        public List<RAccountsGroup> mGetProfitLossQuerry(string strDeComID, int intType)
        {
            return new RInventory().mGetProfitLossQuerry(strDeComID, intType);
        }
        public List<RAccountsGroup> mGetAccountsvoucher(string strDeComID, string strFdate, string strTDate,
                                                        int intVtype, int intSummDetails, string strRefNo, string strBranchID, int intMpoComm)
        {
            return new RInventory().mGetAccountsvoucher(strDeComID, strFdate, strTDate, intVtype, intSummDetails, strRefNo, strBranchID, intMpoComm);
        }
        public List<RAccountsGroup> RefreshLedger(string strDeComID, string strFdate, string strTDate, string vstrLedgerName, string strBranchID, string strSelection)
        {
            return new RInventory().RefreshLedger(strDeComID, strFdate, strTDate, vstrLedgerName, strBranchID, strSelection);
        }
        public List<RAccountsGroup> mReportDayBookDetails(string strDeComID, string strFDate, string strTDate, string strSelection, string strString, string strBranchID)
        {
            return new RInventory().mReportDayBookDetails(strDeComID, strFDate, strTDate, strSelection, strString, strBranchID);
        }
        public List<RAccountsGroup> GroupSummaryReport(string strDeComID, string strFDate, string strTDate, string strSelection, string strGroupName, string strBranchID, int intSuppress)
        {
            return new RInventory().GroupSummaryReport(strDeComID, strFDate, strTDate, strSelection, strGroupName, strBranchID,intSuppress);
        }
        public int mReceiptPayment(string strDeComID, DateTime strFdate, DateTime strTDate)
        {
            return new RInventory().mReceiptPayment(strDeComID, strFdate, strTDate);
        }
        public List<RAccountsGroup> mReceiptPaymentQyery(string strDeComID, int intmode)
        {
            return new RInventory().mReceiptPaymentQyery(strDeComID, intmode);
        }
        public List<RAccountsGroup> mCashFlow(string strDeComID, string strFdate, string strTDate)
        {
            return new RInventory().mCashFlow(strDeComID, strFdate, strTDate);
        }
        public int RefreshTradingNew(string strDeComID, DateTime dtefDate, DateTime detTdate, string strBranchID, int intBusinessType, int intSwpCls)
        {
            return new RInventory().RefreshTradingNew(strDeComID, dtefDate, detTdate, strBranchID, intBusinessType, intSwpCls);
        }
        public List<RAccountsGroup> mTradingQuery(string strDeComID, float intmode)
        {
            return new RInventory().mTradingQuery(strDeComID, intmode);
        }
        public List<RAccountsGroup> GetCostCenterLedger(string strDeComID, string vdteFromDate, string vdteTodate,
                                           string strBranchId, string strCostcenterLedger)
        {
            return new RInventory().GetCostCenterLedger(strDeComID, vdteFromDate, vdteTodate, strBranchId, strCostcenterLedger);
        }
        //public List<RAccountsGroup> GetCostCategoryReport(string strDeComID, string vdteFromDate, string vdteTodate,
        //                                   string strBranchId, string strCostcenterLedger)
        //{
        //    return new RInventory().GetCostCategoryReport(strDeComID, vdteFromDate, vdteTodate, strBranchId, strCostcenterLedger);
        //}
        public List<RAccountsGroup> GetCostCenterReport(string strDeComID, string vdteFromDate, string vdteTodate,
                                          string strBranchId, string strCostcenterLedger, int indIndividual)
        {
            return new RInventory().GetCostCenterReport(strDeComID, vdteFromDate, vdteTodate, strBranchId, strCostcenterLedger, indIndividual);
        }

        public double dblManufacturing(string strDeComID, string vdteFromDate, string vdteTodate, string strBranchId)
        {
            return new RInventory().dblManufacturing(strDeComID, vdteFromDate, vdteTodate, strBranchId);
        }
        public List<RAccountsGroup> mManufacturing(string strDeComID, string strSelection)
        {
            return new RInventory().mManufacturing(strDeComID, strSelection);
        }
        #endregion
        #region "Sales Collection"
        public List<RAccountsGroup> GetrptSalesCollection(string strDeComID, string strBranchID,  string strSelection,
                                                            string strFate, string strTDate, int inttype, int intStatus, int intsummDeta)
        {
            return new RInventory().GetrptSalesCollection(strDeComID, strBranchID, strSelection, strFate, strTDate, inttype, intStatus,intsummDeta);
        }
        #endregion
        #region "DisplayBill"
        public List<RAccountsGroup> mFillDisplayBill(string strDeComID, string strKey)
        {
            return new RInventory().mFillDisplayBill(strDeComID, strKey);
        }
        #endregion
        #region "LedgerListMPOPercent"
        public List<RAccountsGroup> mFillLedgerListMpoPercen(string strDeComID, string strCommissionLedger)
        {
            return new RInventory().mFillLedgerListMpoPercen(strDeComID, strCommissionLedger);
        }
        #endregion
        #region "ProfitLossLedger"
        public int gintProfitLossLedger(string strDeComID, DateTime dtefDate, DateTime dteTdate, string strBranchID, int intBusinessType, int intSwpCls)
        {
            return new RInventory().gintProfitLossLedger(strDeComID, dtefDate, dteTdate, strBranchID, intBusinessType, intSwpCls);
        }
        #endregion

    }
}
