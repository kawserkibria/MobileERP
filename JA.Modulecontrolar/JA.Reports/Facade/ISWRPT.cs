using JA.Reports.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JA.Reports.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISWRPT" in both code and config file together.
    [ServiceContract]
    public interface ISWRPT
    {
        [OperationContract]
        List<RoStockRequisition> mGetStockIn(string strDeComID, string strRefNo);
        [OperationContract]
        List<RoStockRequisition> mGetStockOut(string strDeComID, string strRefNo);
        [OperationContract]
        List<RoStockRequisition> mGetStockRequisition(string strDeComID, string strRefNo);
        [OperationContract]
        List<RoPFHL> mGetMpoClosingValue(string strDeComID, string strFate, string strBranchID, string strPartyName, int intstatus);
        [OperationContract]
        List<RoDayliCollection> mGetCollectionStatementIndividual(string strDeComID, string strFdate, string strTDate, string strBranchId, string strLedgername);
        [OperationContract]
        List<RoDayliCollection> mGetCollectionStatement(string strDeComID, string strFdate, string strTDate, string strBranchId, string strString, int intmode,
                                                       bool blngAccessControl, string strUserName, double dblValue, string strValOption, string strReportOption, int intStatus);
        [OperationContract]
        List<RoPFHL> mGetPFHL(string strDeComID, string strFdate, string strTDate, string strBranchId, string strLedgername);
        [OperationContract]
        List<RoDayliCollection> mgetDailyCollectionN(string strDeComID);
        [OperationContract]
        List<RoPaymentSummaryMonthly> mGetPaymentSummaryMonthly(string strDeComID, string strYear,int intmode);
        [OperationContract]
        List<RoPaymentSummaryearly> mGetPaymentSummaryYearly(string strDeComID, string strYear1, int intmode);
        #region "Production"
        [OperationContract]
        List<RoMonthlyProduction> mGetloadPowerClass(string strDeComID);
        [OperationContract]
        List<RoPackingRawMaterialsStockinfo> mGetLocationQty2(string strDeComID, string strFdate, string strTDate, string strString, string strSelction,
                                                  int intZeroQntySuppress, string strStringNew);
        [OperationContract]
        List<RoConsumption> mGetConversion(string strDeComID, string strFdate, string strTDate, string strStockGroup, string strLoacation, string strpowerClass, int intROption);

        [OperationContract]
        List<RoMonthlyProduction> mGetMonthlyProductionClassPower(string strDeComID, string strFdate, string strTDate, string strStockGroup, string strLoacation, string strpowerClass, int intROption);
        [OperationContract]
        List<RoMonthlyProduction> mGetMonthlyProduction(string strDeComID, string strFdate, string strTDate, string strStockGroup, string strLoacation, int intROption);

        [OperationContract]
        List<RoProduction> GetBatchWiseProductionInd(string strDeComID, string vstrRefNo);
        #endregion
        [OperationContract]
        List<RoMCommission> GetrptSPCommissionHead(string strDeComID, string strCardNo, string strFdate, string strTdate);
        [OperationContract]
        List<RoMCommission> GetrptSPCommission3(string strDeComID, string strFate, string strTDate, string strGrid);
        [OperationContract]
        List<RStockInformation> mGetCommitionN(string strDeComID, string strFdate, string strTDate, string strBranchId, string strLedgername);
        [OperationContract]
        List<RAudit> mGetAudit(string strDeComID, string strFdate, string strTDate, int intVtype, string strLedger, int intROption);
        [OperationContract]
        string gOpenComID(string strID);
        [OperationContract]
        void DoWork();
        #region "Inventory"
        
        [OperationContract]
        List<RStockInformation> mGetGroupCommissionWithSales(string strDeComID, string strFdate, string strTDate, string strString);
        [OperationContract]
        List<RCreditLimit> mDisplayCreditLimitListAll(string strDeComID, string strKey, string strSeclection);
        [OperationContract]
        List<RStockInformation> mGetindividualSalpmle(string strDeComID, string strRefNo);
        [OperationContract]
        string mInsertTempSaleaPrcice(string strCon, string striItemName,string strLevel);
        [OperationContract]
        List<RStockInformation> mGetSalesPriceItem(string strCon, string strgroupName, string strcategory);
        
        [OperationContract]
        List<RStockInformation> mgetStockSummarySPriceWise(string strDeComID, string strString, int intmode);
        [OperationContract]
        List<RStockInformation> mloadCategoryGroup(string strDeComID, int intmode);
        //[OperationContract]
        //List<RStockInformation> mItemMasterForvalue(string strDeComID, string strFdate, string strTDate, string strString, string strSelction,
        //                                      int intZeroQntySuppress, string strBranchID);
        [OperationContract]
        List<RStockInformation> mGetLocationQty(string strDeComID, string strFdate, string strTDate, string strString, string strSelction,
                                                    int intZeroQntySuppress);
        [OperationContract]
        List<RStockInformation> mGetNegetiveStock(string strDeComID);
        [OperationContract]
        List<RStockInformation> mGetBOMList(string strDeComID, string strProcessname, string strType);
        //[OperationContract]
        //List<RStockInformation> mGetSlowFastMoving(string strDeComID, string strFdate, string strTDate, DateTime dteTDate, string str_S_F_Z, string strSelction, string strString);
        [OperationContract]
        List<RStockInformation> mGetMFGProcessReport(string strDeComID, string strProcessname, int intSelection);
        [OperationContract]
        List<RStockInformation> mGetProductTopSheetSalesPrice(string strDeComID, string strFdate, string strTDate);
        [OperationContract]
        List<RStockInformation> mGetStockRegister(string strDeComID, string strFdate, string strTDate, string strFromLocation, string strTLocation);
        [OperationContract]
        List<RStockInformation> mGetGroupCommissionSubReport(string strDeComID, string strFdate, string strTDate);
        [OperationContract]
        List<RStockInformation> mGetGroupCommission(string strDeComID, string strFdate, string strTDate, string strString);
        [OperationContract]
        List<RStockInformation> mGetProductStatementCross(string strDeComID, string strFdate, string strTDate, int inttype);
        [OperationContract]
        List<RStockInformation> mGetProductTopSheet(string strDeComID, string strFdate, string strTDate);
        [OperationContract]
        List<RStockInformation> mGetProductStatement(string strDeComID, string strFdate, string strTDate, string strstring, string strBranchID, int intMode, int intPhyType, int intAliasSorting);
        [OperationContract]
        List<RStockInformation> mGetLocationWiseConsumtion(string strDeComID, string strFdate, string strTDate, string strstring);
        [OperationContract]
        List<RStockInformation> mGetStockSummSalesPrice(string strDeComID, string strLevel, string strCateGory, int intType);

        [OperationContract]
        List<RAccountsGroup> mGetDailyCollection(string strDeComID, string strFate, string strTDate, string strBranchID, 
                                    string struserName, string strBkash,int intasperBkash,string strHlFdate);
        //[OperationContract]
        //List<RStockInformation> mItemMaster(string strDeComID, string strFdate, string strTDate, string strString, string strSelction, int intZeroQntySuppress, bool gstrUserName, string strUserName, string strSelction2);
        [OperationContract]
        List<RStockInformation> mGetStoreLedger(string strDeComID, string strFdate, string strTDate, string strString, string strLocatiion);
        [OperationContract]
        List<RStockInformation> mGetInventortyVoucher(string strDeComID, string strFdate, string strTDate, string strSelection, string strBranchName, string strRefNo,string strSummDet);
        [OperationContract]
        List<RStockInformation> mGetProfitability(string strDeComID, string strFdate, string strTDate, string strGroupName);
        #endregion
        #region "Accounts"
        #region "Honda Loan"
        [OperationContract]
        List<RHondaLoan> mGetHondaLoan(string strDeComID, string strBranchID, string strLedgerName, string strGroupName, string strFdate, string strTDate, int intMode, string strLoanDate, int intSuppress);
        [OperationContract]
        List<RHondaLoan> mHondaLoanFineRecAmoun(string strDeComID, string strLedgerName);
        #endregion
        //[OperationContract]
        //List<RCreditLimit> mGetCreditLimit(string strDeComID, string strBranchID,string strdate1, string strdate2, string strdate3, string strdate4, string strlastdate, string strstring, int Intmode);
        [OperationContract]
        List<RAccountsGroup> mGetAccountsDoctotorvoucher(string strDeComID, string strRefNo);
        //[OperationContract]
        //List<RFinalStatement> mGetFinalStattemnetCustomer(string strDeComID, string strFate, string strTDate, string strBranchID, string strGroupName, string strPartyName, int intstatus, string CustomerGroup, string strCustomer);
        [OperationContract]
        List<RAudit> mGetMR(string strDeComID, string RefNo, int intVtype);
        [OperationContract]
        List<RAudit> mGetHeader(string strDeComID, int intMode);
        [OperationContract]
        List<RAccountsGroup> mTradingQueryVertical(string strDeComID, float intmode);
        [OperationContract]
        List<RAccountsGroup> mGetDailyCollectionDetails(string strDeComID, string strFate, string strTDate, string strBranchID);
        [OperationContract]
        List<RAudit> mgetUserPrivilage(string strDeComID, string strUserName);
        [OperationContract]
        List<RAccountsGroup> mGetBudgetledgerList(string strDeComID);
        [OperationContract]
        List<RAccountsGroup> mGetBudget(string strDeComID, string strString, string strFdate, string strTdate);
        [OperationContract]
        List<RAccountsGroup> mGetAccountsvoucherSP(string strDeComID, int intVtype, int intSummDetails, string strRefNo, 
                                                        string strBranchID, string strFPrevious, string strTPrevious,string strPMonthid);
        [OperationContract]
        List<RStatistics> mGetStatistics(string strDeComID, string strFdate, string strTdate);
        [OperationContract]
        List<RFixedAsset> mUpdateReducingBalance(string strDeComID, DateTime gdteFinicialYearFrom, DateTime strAsOnDate);
        [OperationContract]
        List<RFixedAsset> mUpdateStraightLine(string strDeComID, DateTime gdteFinicialYearFrom, DateTime strAsOnDate, DateTime dtePrevdate);
        [OperationContract]
        List<RAccountsGroup> mGetChequePrint(string strDeComID, int intMode, string RefNo, string strString);
        [OperationContract]
        List<RAccountsGroup> GetrptExpenseSummary(string strDeComID, string strFate, string strTDate, int intSumDet);
        [OperationContract]
        List<RAccountsGroup> GetrptCollectionTargetAchieve(string strDeComID, string strBranchID, string strStringMonth, string strSelection,
                                                            string strFate, string strTDate, string strSalesFate, string strSalesTDate, int inttype, int intStatus, string gstruserName);
        //[OperationContract]
        //List<RAccountsGroup> GetrptSPCommission(string strDeComID, string strFate, string strTDate);
        [OperationContract]
        List<RAccountsGroup> mGetContractsPartBill2(string strDeComID, string strFate, string strTDate, string strBranchID, string strPartName);
        [OperationContract]
        List<RAccountsGroup> mGetPostDateCheque(string strDeComID, string strFate, string strTDate, string strSelection, string strVCDate);
        [OperationContract]
        List<RAccountsGroup> getrptChequePayment(string strDeComID, string strFate, string strTDate, int intSorting);
        [OperationContract]
        List<RFinalStatement> mGetMarketMonitoringSheet(string strDeComID, string strFate, string strTDate, string strBranchID, int intstatus, string strString, string strUserName, int intSelection);
        [OperationContract]
        List<RFinalStatement> mGetFinalStattemnet(string strDeComID, string strFate, string strTDate, string strBranchID, string strGroupName, string strPartyName,
                                                    int intstatus, int intOrderby, double dblValue,double dblValueBelow, string strValOption, string gstrUserName);
        [OperationContract]
        List<RAccountsGroup> mGetContractsPartBill(string strDeComID, string strFate, string strTDate, string strBranchID, string strPartName);
        [OperationContract]
        int mGetBalanceSheet(string strDeComID, DateTime strFdate, DateTime strTDate, int intHorVer, double dblClosing);
        [OperationContract]
        List<RAccountsGroup> mGetBalanceSheetQuery(string strDeComID, int intMode);
        [OperationContract]
        int mGetProfitLoss(string strDeComID, DateTime dtefFdate, DateTime dteTDate, string vstrBranchID, int intHorVer);
        [OperationContract]
        List<RAccountsGroup> mGetProfitLossQuerry(string strDeComID, int intType);
        [OperationContract]
        List<RAccountsGroup> mGetTrailBalance(string strDeComID, DateTime strFdate, DateTime strTDate, int selection);
        [OperationContract]
        List<RAccountsGroup> mGetTrailBalanceQuery(string strDeComID);
        [OperationContract]
        List<RAccountsGroup> mGetAccountsvoucher(string strDeComID, string strFdate, string strTDate, int intVtype, int intSummDetails, string strRefNo, string strBranchID, int intMpoComm);
        [OperationContract]
        List<RAccountsGroup> RefreshLedger(string strDeComID, string strFdate, string strTDate, string vstrLedgerName, string strBranchID, string strSelection);
        [OperationContract]
        List<RAccountsGroup> mReportDayBookDetails(string strDeComID, string strFDate, string strTDate, string strSelection, string strString, string strBranchID);
        [OperationContract]
        List<RAccountsGroup> GroupSummaryReport(string strDeComID, string strFDate, string strTDate, string strSelection, string strGroupName, string strBranchID, int intSuppress);
        [OperationContract]
        int mReceiptPayment(string strDeComID, DateTime strFdate, DateTime strTDate);
        [OperationContract]
        List<RAccountsGroup> mReceiptPaymentQyery(string strDeComID, int intmode);
        [OperationContract]
        List<RAccountsGroup> mCashFlow(string strDeComID, string strFdate, string strTDate);
        [OperationContract]
        int RefreshTradingNew(string strDeComID, DateTime dtefDate, DateTime detTdate, string strBranchID, int intBusinessType, int intSwpCls);
        [OperationContract]
        List<RAccountsGroup> mTradingQuery(string strDeComID, float intmode);
        [OperationContract]
        List<RAccountsGroup> GetCostCenterLedger(string strDeComID, string vdteFromDate, string vdteTodate,
                                            string strBranchId, string strCostcenterLedger);
        //[OperationContract]
        //List<RAccountsGroup> GetCostCategoryReport(string strDeComID, string vdteFromDate, string vdteTodate,
        //                                   string strBranchId, string strCostcenterLedger);
        [OperationContract]
        List<RAccountsGroup> GetCostCenterReport(string strDeComID, string vdteFromDate, string vdteTodate,
                                         string strBranchId, string strCostcenterLedger, int indIndividual);
        [OperationContract]
        double dblManufacturing(string strDeComID, string vdteFromDate, string vdteTodate, string strBranchId);
        [OperationContract]
        List<RAccountsGroup> mManufacturing(string strDeComID, string strSelection);
        #endregion
        [OperationContract]
        List<RAccountsGroup> GetrptSalesCollection(string strDeComID, string strBranchID, string strSelection, string strFate, string strTDate,
                                                        int inttype, int intStatus, int intsummDeta);
        [OperationContract]
        List<RAccountsGroup> mFillDisplayBill(string strDeComID, string strKey);
        [OperationContract]
        List<RAccountsGroup> mFillLedgerListMpoPercen(string strDeComID, string strCommissionLedger);
        [OperationContract]
        int gintProfitLossLedger(string strDeComID, DateTime dtefDate, DateTime dteTdate, string strBranchID, int intBusinessType, int intSwpCls);
    }
}
