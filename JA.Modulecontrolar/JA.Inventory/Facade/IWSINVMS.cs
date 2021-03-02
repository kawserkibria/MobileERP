using JA.Inventory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JA.Inventory.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWSINVMS" in both code and config file together.
    [ServiceContract]
    public interface IWSINVMS
    {
        [OperationContract]
        List<ManuProcess> mDisplayRequisitionNo(string strDeComID, string strRequisionNO);
        [OperationContract]
        List<Invoice> mGetStockRequiNo(string strDeComID, string strLocation, string strRefNo);
        [OperationContract]
        string mUpdateRequisitionNew(string strDeComID, string strRefNoMarze, string strRefNo, long mlngVType, string strDate, double dblNetAmount, string strNarrations,
                                        string strBranchId, string strGodownName, string strProcessName, double dblNetQty, int intstatus, string DG, bool mblnNumbMethod);
        [OperationContract]
        string mSaveRequisition(string strDeComID, string strRefNo, long mlngVType, string strDate, double dblNetAmount, string strNarrations,
                                        string strBranchId, string strGodownName, string strProcessName, double dblNetQty, int intstatus, string DG, bool mblnNumbMethod);

        [OperationContract]
        string mUpdateRequisition(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                       double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency, string strProcessName,
                                       string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                       bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, string strPrepareBy,
                                       int intAppStatus, string strApprovedBy, string strApprovedDate, double dblNetQty, int intChaneType);
      

        [OperationContract]
        List<ManuProcess> mDisplayTransferOutItem(string strDeComID, string strvoucherNo, string strflag);
        [OperationContract]
        List<InvoiceConfig> mGetStockTranRefNo(string strDeComID, string strLocation, string strRefNo);
        [OperationContract]
        List<MFGvouhcer> mDisplayRepacking(string strDeComID, string vstrStockSerial);
        [OperationContract]
        List<MFGvouhcer> mGetProductionNoFBatch(string strDeComID, string vstrBatchNo);
        [OperationContract]
        string mUpdateSalesOrderOnlineComm(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strBranchId, string strGodownName, string DG);
        [OperationContract]
        List<Invoice> mfillPartyNameNewSI(string strDeComID, string strBranchID, bool blngAccessControl, string strUserID, int intStatus, string strMode);
        [OperationContract]
        List<StockItem> mGetStockGroup(string strDeComID, int intmode);
        [OperationContract]
        List<Invoice> mFillLedgerStatus(string strDeComID, long vlngGroup, int intStatus, string strBranchID);
        [OperationContract]
        List<StockItem> gLoadInvoiceLocation(string strDeComID, string vstrBranchID, bool gblngAccesscontrol, string strUserName, int intStatus);
        [OperationContract]
        List<SalesTarget> mDisplayCollectionTarget(string strDeComID, string strKey);
        [OperationContract]
        List<SalesTarget> mDisplayTargetLedger(string strDeComID, string strKey, string strLedgerName);
        [OperationContract]
        List<SalesTarget> mDisplayCreditLimitLedger(string strDeComID, string strKey);
        [OperationContract]
        List<StockItem> mFillStockItemListNewEdit(string strDeComID, int intType, string strRefNo);
        [OperationContract]
        List<SalesTarget> mFillItemPackTarget(string strDeComID);
        [OperationContract]
        List<SalesTarget> mDisplayItemTarget(string strDeComID, string strKey);
        [OperationContract]
        string mDeleteItemTarget(string strDeComID, string strKey);
        [OperationContract]
        string mInsertItemPackTarget(string strDeComID, string strOldKey, string strInsert, string strKey, string strLedgerName, string strFromDate, string strTodate, string strbranchID, int intType, string DG);
        [OperationContract]
        List<StockItem> mFillStockItemListNew(string strDeComID, int intType, int intSP);
        [OperationContract]
        string gOpenComID(string strID);
        [OperationContract]
        List<Invoice> mFillLedgerParentGroup(string strDeComID, int mintLedgerGroup, string strSelectio);
        [OperationContract]
        string mloadDatabaseCompnaytest(string strDeComID);
        [OperationContract]
        List<StockItem> gLoadStockGroupLevel3Privileges(string strDeComID, string strUserName);
        [OperationContract]
        List<StockItem> gLoadStockGroupLevel3PrivilegesRight(string strDeComID, string strUserName);
        [OperationContract]
        List<Location> mLoadLocationUserPrivileges(string strDeComID, string strUSerName);
        [OperationContract]
        List<Location> mLoadLocationUserPrivilegesRight(string strDeComID,string strUSerName);
        [OperationContract]
        List<StockItem> gLoadStockGroupLevel3(string strDeComID);
        [OperationContract]
        List<StockItem> mloadAddStockItemSI(string strDeComID, string vstrRoot, string strLocation);

        [OperationContract]
        List<Invoice> mFillSalesRepFromMPoNew1(string strDeComID, long vlngSLedgerType, string strLedgerName);
        [OperationContract]
        List<Invoice> mfillPartyNameNew(string strDeComID, string strBranchID, bool blngAccessControl, string strUserID, int intStatus, string strMode);
        [OperationContract]
        List<Invoice> mFillSalesRepFromMPoNew(string strDeComID, long vlngSLedgerType, string strLedgerName);

        [OperationContract]
        List<SalesPriceLevel> mBonusList(string strDeComID, string VstrLevelName, string fDate, string tDate);
        [OperationContract]
        List<SalesPriceLevel> mGiftList(string strDeComID, string VstrLevelName, string fDate, string tDate);
        [OperationContract]
        List<ManuProcess> mLoadProduction(string strDeComID, string Pyear, int intStatus);
        //[OperationContract]
        //string mDeleteMFG(string strDeComID, string strOldInvLog, string strOldRm, string strOldWm, string stroldFm);

        [OperationContract]
        List<StockItem> gFillStockItemAllWithoutGodown(string strDeComID, bool blngAccessControl, string strUserName, string vstrGroupName);
        [OperationContract]
        string mDeleteBatchSize(string strDeComID, long lngslNo, string strBatchN);
        [OperationContract]
        List<StockItem> mloadAddStockItem(string strDeComID,string vstrRoot);
        [OperationContract]
        List<Invoice> mFillSalesRepFromMPo(string strDeComID, long vlngSLedgerType, string strLedgerName);
        [OperationContract]
        List<Invoice> GetMPONameFromTC(string strDeComID, string strCode);
        [OperationContract]
        List<StockItem> gFillStockItemAll(string strDeComID, string vstrGodown);
        [OperationContract]
        void DoWork();
        [OperationContract]
        Dictionary<string, string> mLoadStockGroup(string strDeComID);
        [OperationContract]
        Dictionary<string, string> gFillSalesLedgerbatch(string strDeComID, long vlngSLedgerType);
        [OperationContract]
        string mInsertGroup(string strDeComID, string vstrName, string vstrUnder, string vstrGrName, int intpacksize, int intStatus);
        [OperationContract]
        List<StockGroup> mDisplayRecord(string strDeComID, long vstrPrimaryKey);
        [OperationContract]
        List<StockGroup> mFillStockGroupList(string strDeComID);
        [OperationContract]
        string mUpdateGroup(string strDeComID, long vstrPrimaryKey, string vstrName, string vstrUnder, string vstrGrName, int intpacksize, int intStatus);
        [OperationContract]
        string mDeleteStockGroup(string strDeComID, long vlngGroupPrimary);
        [OperationContract]
        List<StockCategory> mDisplayCategoryRecord(string strDeComID, long vstrPrimaryKey);
        [OperationContract]
        Dictionary<string, string> mLoadStockCategory(string strDeComID);
        [OperationContract]
        string mInsertcategory(string strDeComID, string vstrName, string vstrUnder);
        [OperationContract]
        string mUpdatecategory(string strDeComID, long mstrPrimaryKey, string vstrName, string vstrUnder);
        [OperationContract]
        string mDeletcategory(string strDeComID, long strSerialfNo);
        [OperationContract]
        List<StockCategory> mFillStockCategory(string strDeComID);
        [OperationContract]
        Dictionary<string, string> mLoadStockCategoryItem(string strDeComID);

        [OperationContract]
        string mInsertUnitMeasurement(string strDeComID, string vstrSymbol, string vstrFormal, long noofDecimalPlaces);
        [OperationContract]
        string mUpdateMeasurementUnit(string strDeComID, long strUnitSerialNo, string vstrSymbol, string vstrFormal, long noofDecimalPlaces);
        [OperationContract]
        List<MeasurementUnit> mLoadMeasurementUnit(string strDeComID);
        [OperationContract]
        string DeleteMeasurementUnit(string strDeComID, string strSymbol, long strKey);
        //[OperationContract]
        //string mInsertGodowns(string strDeComID, string vstrLocation, string vstrUnder, string vstrBranch,
        //                            string vstrAddress1, string vstrAddress2, string vstrCity,
        //                            string vstrPhone, string vstrFax, int intsection);
        //[OperationContract]
        //string mUpdateGodown(string strDeComID, long vstrPrimaryKey, string vstrLocation, string vstrUnder, string vstrBranch,
        //                            string vstrAddress1, string vstrAddress2, string vstrCity,
        //                            string vstrPhone, string vstrFax, int intsection);
        [OperationContract]
        List<Location> mDisplayLocation(string strDeComID, long vstrPrimaryKey);
        [OperationContract]
        List<Location> mLoadLocation(string strDeComID, bool vblngAccessControl, string vstrUserName);
        [OperationContract]
        string mDeleteLocation(string strDeComID, string strSubGroup, long strRefNo);


        [OperationContract]
        List<StockItem> mFillUOM(string strDeComID);
        [OperationContract]
        Dictionary<string, string> mFillOpeningBatch(string strDeComID);
        [OperationContract]
        List<StockItem> mFillLedger(string strDeComID, long lngGroup);
        [OperationContract]
        List<StockItem> gLoadStockGroup(string strDeComID, bool vblngAccessContron, string vstrUserName, string strFgYN, string strGroupName);
        [OperationContract]
        string mInsertStockItem(string strDeComID, string vstrName, string vstrUnder, long lngMaintainBatch, string vstrStatus,
                                        string vstrItemName, string vstrAlias, string vstrdescription, string vstrParent, string vstrCatgory,
                                        string vstrUnit, string vstrAltUnit, string vstrWhere, string vstrWhereUnit, string vstrManufacturer,
                                        string vstrSupplier, string vstrTransalator, string vstritemBangla, double dblMinimumstock, double dblReorderQty,
                                        double dblOpnQty, double dblopnRate, double dblAmnt, string dg, string strMatType, string strPowerClass, string strBatch, int intSP);
        [OperationContract]
        string mUpdateStockItem(string strDeComID, long vstrPrimaryKey, string vstrName, string vstrUnder, long lngMaintainBatch, string vstrStatus,
                                       string vstrItemName, string vstrAlias, string vstrdescription, string vstrParent, string vstrCatgory,
                                       string vstrUnit, string vstrAltUnit, string vstrWhere, string vstrWhereUnit, string vstrManufacturer,
                                       string vstrSupplier, string vstrTransalator, string vstritemBangla, double dblMinimumstock, double dblReorderQty,
                                       double dblOpnQty, double dblopnRate, double dblAmnt, string dg, string strMatTytpe, string strpowerclass, string strBatch, int intSP);

        [OperationContract]
        List<StockItem> mFillStockItemList(string strDeComID, int intStatus, string vstrPrefix = "", string strAlias = "");
        [OperationContract]
        List<StockItem> mDisplayItemRecord(string strDeComID, long vstrPrimaryKey);
        [OperationContract]
        List<StockItem> mLoadGodownData(string strDeComID, string vstrPrimaryKey);

        [OperationContract]
        string mDeleteStockItem(string strDeComID, string vstrPrimaryKey);
        [OperationContract]
        List<StockItem> mFillStockTreeGroupLevel(string strDeComID);
        //[OperationContract]
        //List<StockItem> mloadAddStockItemNew(string strDeComID, string vstrRoot, string strLocation);
        [OperationContract]
        List<StockItem> mFillStockTreeGroupLevel1(string strDeComID);
        [OperationContract]
        List<StockItem> gLoadLocation(string strDeComID, string vstrBranchID, bool gblngAccesscontrol, string strUserName, int intStatus);
        [OperationContract]
        List<Invoice> mfillLedgerInvoice(string strDeComID, bool vblngDrcr, long mlngLedgerAs, string strLoose);

        [OperationContract]
        List<Invoice> gFillSalesLedger(string strDeComID, long vlngSLedgerType);

        [OperationContract]
        List<Invoice> gFillPurchaseLedger(string strDeComID);


        [OperationContract]
        Dictionary<string, string> mFillSalesRep(string strDeComID, long vlngSLedgerType);

        [OperationContract]
        string mSaveSalesRepresentive(string strDeComID, string vstrLedgerCode, string vstrLedgerName, string vstrTeritoryCode, string vstrTeritoryName, double dblTargetAmount,
                                               string vstrHomoeHall,int intStatus,string vstrUnder, string vstrMrName, double dblOpeningBalance, double dblcommPercent,
                                               string vstrDrcr, string vstrCommType, string vstrAddress1,
                                               string vstrAddress2, string vstrCommnets, string vstrCity, string vstrPostal, string vstrPhone);
        [OperationContract]
        string mUpdateSalesRepresentive(string strDeComID, string mstrOldLedger, long mlngLedgerSerial, string vstrLedgerCode, string vstrLedgerName, string vstrTeritoryCode,
                                             string vstrTeritoryName, double dblTargetAmount,string vstrHomoeHall,int intStatus, string vstrMrName, string vstrUnder,
                                             double dblOpeningBalance, double dblcommPercent,
                                             string vstrDrcr, string vstrCommType, string vstrAddress1,
                                             string vstrAddress2, string vstrCommnets, string vstrCity, string vstrPostal, string vstrPhone);

        [OperationContract]
        List<SalesPriceLevel> mGetPriceLevel(string strDeComID);
        [OperationContract]
        string mSaveSalesPrice(string strDeComID, string vstrName, int intmode, string mstrPreviousLevel);
        [OperationContract]
        List<StockItem> gFillStockItem(string strDeComID, string vstrGodown = "", string vstrPrefix = "", bool blngAlias = true);
        [OperationContract]
        List<StockItem> gFillStockItemCheck(string strDeComID, string vstrGodown = "", long vlngLedgerGroup = 0, long vlngStockType = 0, long vlngManufacGroup = 0, string vstrPrefix = "");
        [OperationContract]
        string mInsertPriceconfig(string strDeComID, string DgGrid, string strKeydate, string mstrPriceLevel, string strEffectivedate);
        [OperationContract]
        List<SalesPriceLevel> mDisplayItemGroup(string strDeComID, string vstrItemGroup, string vstrDate);
        [OperationContract]
        List<SalesPriceLevel> mRefreshPriceList(string strDeComID, string VstrLevelName, string fDate, string tDate);
        [OperationContract]
        string mDeletePriceList(string strDeComID, string VstrLevelName, string strDate);
        [OperationContract]
        string mInsertGiftItem(string strDeComID, string DgGrid, string strAppDate, string strDateKey);

        [OperationContract]
        List<SalesPriceLevel> mDisplayGiftItemGroup(string strDeComID, string vstrDate);
        [OperationContract]
        string mDeleteGiftItem(string strDeComID, string strAppDate, string vstrBranchId);
        [OperationContract]
        string mInsertBonusItem(string strDeComID, string DgGrid, string strAppDate, string strDateKey);
        [OperationContract]
        List<SalesPriceLevel> mDisplayBonusItemGroup(string strDeComID, string vstrDate);
        [OperationContract]
        string mDeleteBonusItem(string strDeComID, string strAppDate, string vstrBranchId);
        [OperationContract]
        string msaveSalesOrder(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                        double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency, string strSalesRep,
                                        string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                        bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool mblnNumbMethod, string strPrepareBy,
                                        int intAppStatus, string strApprovedBy, string strApprovedDate, double dblNetQty,double  dblLessAmount,double dblTotal);

        [OperationContract]
        string mUpdateSalesOrder(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                       double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency, string strSalesRep,
                                       string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                       bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, string strPrepareBy,
                                       int intAppStatus, string strApprovedBy, string strApprovedDate, double dblNetQty, int intChaneType, double dblLessAmount, double dblTotal);

        [OperationContract]
        List<Invoice> mGetAllOrder(string strDeComID, string vstrBranchID, long lngrefType, string vstrRefNumber);

        [OperationContract]
        List<InvoiceConfig> mGetInvoiceConfig(string strDeComID);
        //[OperationContract]
        //string mSaveSalesInvoice(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger, double dblTotalAmnt,
        //                               double dblNetAmount, double dblAddAmount, double dblLessAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirSalesInv, long mlngIsChqueCash, string strNarrations,
        //                               string strBranchId, string vstrGodownName, long lngIsMultiCurrency, string strSalesRep, string DGSalesGrid, string DGVector, string DGBillWise, string DGsalesOrder,string DGAddles,
        //                               bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool blngNumberMethod, string strOrderNo, string strOrderDate, string strPreparedby, string strPreparedDate, 
        //                                double dblProcessAmount, double dblRoundOff);
        [OperationContract]
        List<InvoiceConfig> mGetInvoiceConfigNew(string strDeComID);
        [OperationContract]
        Dictionary<string, string> mFillSalesRepLedger(string strDeComID, long vlngSLedgerType);
        [OperationContract]
        List<Invoice> mfillPartyName(string strDeComID);
        [OperationContract]
        Dictionary<string, string> mFillBatch(string strDeComID);
        //[OperationContract]
        //string mSaveSalesChallan(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
        //                              double dblNetAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirSalesInv, string strNarrations,
        //                              string strBranchId, string vstrGodownName, string DGSalesGrid, string DGsalesOrder, bool mblnNumberMethod, string strCustomer, 
        //                                string strDesignation, string strTransport, double crtQty, double dblBox, string strTrNo);
        //[OperationContract]
        //string mUpdateSalesChallan(string strDeComID, string mstRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
        //                             double dblNetAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirSalesInv, string strNarrations,
        //                             string strBranchId, string vstrGodownName, string DGSalesGrid, string DGsalesOrder,string strCustomer,
        //                             string strDesignation,string strTransport,double dblcrtQty,double dblBox,string strTrNo);
        [OperationContract]
        List<StockItem> gFillStockItemManufacturer(string strDeComID, string vstrManufacturer, string vstrGodown, long vlngStockType);
        [OperationContract]
        string mInsertProcess(string strDeComID, string oldvstrProcess, string vstrProcess, string Dgfg, string DgRm, string Dgwastage,
                                int actionmode, int intConvertType, int intTransferType, string strbranchID, string strLocation);
        [OperationContract]
        List<ManuProcess> mLoadProcess(string strDeComID, string Pyear, string vstrProcessName, int intType, int intTransfer);
        [OperationContract]
        List<ManuProcess> mDisplayProcess(string strDeComID, string vstrProcessName, string strType);
        [OperationContract]
        string mDeleteProcess(string strDeComID, string vstrProcess);
        //[OperationContract]
        //string mInsertMFGvoucher(string strDeComID, string strRefNo, string strInvLog, string strBranchIdFrom, string strBranchIdTo, string strGodown, string strGodownto, string strProcess,
        //                                string strDate, string strNarrations, double mdblAmount,
        //                                string Dgfg, string DgRm, string Dgwastage, int actionmode, bool mblnNumbMethod, int intconvertType);

        //[OperationContract]
        //List<MFGvouhcer> mLoadMFGVoucher(string strDeComID, string fdate, string tdate, int intConType, string strFind, string strExpression, string strStockItemName);
        //[OperationContract]
        //string mUpdateSalesInvoice(string strDeComID, string mstrRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger, double dblTotalAmnt,
        //                           double dblNetAmount, double dblAddAmount, double dblLessAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirSalesInv, long mlngIsChqueCash, string strNarrations,
        //                           string strBranchId, string vstrGodownName, long lngIsMultiCurrency, string strSalesRep, string DGSalesGrid, string DGVector, string DGBillWise, string DGsalesOrder,string DGAddless,
        //                           bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, string strOrderNo, string strOrderDate, string strPreparedby, string strPreparedDate, double dblProcessAmount, double dblRoundOff);
        [OperationContract]
        string mSavePurchaseInvoice(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger, double dblTotalAmnt,
                                  double dblNetAmount, double dblAddAmount, double dblLessAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirPurcInv, long mlngIsChqueCash, string strNarrations,
                                  string strBranchId, string vstrGodownName, long lngIsMultiCurrency, string strSalesRep, string DGSalesGrid, string DGVector, string DGBillWise, string DGAddLess, string DGsalesOrder,
                                  bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool blngNumberMethod);
        [OperationContract]
        string mUpdatePurchaseInvoice(string strDeComID, string mstrRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger, double dblTotalAmnt,
                                      double dblNetAmount, double dblAddAmount, double dblLessAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirPurcInv, long mlngIsChqueCash, string strNarrations,
                                      string strBranchId, string vstrGodownName, long lngIsMultiCurrency, string strSalesRep, string DGSalesGrid, string DGVector, string DGBillWise, string DGAddLess, string DGsalesOrder,
                                      bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol);

        [OperationContract]
        string mSaveSalesReturn(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger,
                                     double dblNetAmount, double dblTotalAmount, double dblAddAmount, double dblLessAmount, string strRefType,
                                     long lngAgstRef, long mlngIsInvEffinDirSalesInv, string strNarrations,
                                     string strBranchId, string vstrGodownName, long mlngCashFlow, long mlngIsChqueCash, string DGSalesGrid,
                                     string DGsalesOrder, string DGVector, string DGBillWise, string DGAddLess, bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool blngNumberMethod, string strSalesRep);
        [OperationContract]
        string mUpdateSalesReturn(string strDeComID, string mstrRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger,
                                     double dblNetAmount, double dblTotalAmount, double dblAddAmount, double dblLessAmount, string strRefType,
                                     long lngAgstRef, long mlngIsInvEffinDirSalesInv, string strNarrations,
                                     string strBranchId, string vstrGodownName, long mlngCashFlow, long mlngIsChqueCash, string DGSalesGrid,
                                     string DGsalesOrder, string DGVector, string DGBillWise, string DGAddLess, bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, string strSalesRep);


        //[OperationContract]
        //List<ManuProcess> mDisplayMFGVoucher(string strDeComID, string strRefNo);
        //[OperationContract]
        //List<MFGvouhcer> mDisplayRMVoucher(string strDeComID, string strRefNo);
        //[OperationContract]
        //List<MFGvouhcer> mDisplayDmVoucher(string strDeComID, string strRefNo);
        //[OperationContract]
        //List<MFGvouhcer> mDisplayFgVoucher(string strDeComID, string strRefNo);
        //[OperationContract]
        //string mUpdateMFGvoucher(string strDeComID, string strOldInvLog, string strOldRm, string strOldWm, string stroldFm, string strInvLog,
        //                                  string strBranchIdFrom, string strBranchIdTo, string strGodown,string strGodownto, string strProcess,
        //                                  string strDate, string strNarrations, double mdblAmount,
        //                                  string Dgfg, string DgRm, string Dgwastage, int actionmode, bool mblnNumbMethod, int intconvertType);

        [OperationContract]
        string mSaveSalesQuotation(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                       double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency,
                                       string strAttention, string strDesignation, string strAdrress,
                                       string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                       bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool mblnNumbMethod);

        [OperationContract]
        string mUpdateeSalesQuotation(string strDeComID, string strOldRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                         double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency,
                                         string strAttention, string strDesignation, string strAdrress,
                                         string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                         bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool mblnNumbMethod);

        [OperationContract]
        string mSavebatch(string strDeComID, string strLogNo, string strStartDate, string strEndDate, string strExpireDate, string strLedgerName, string strstatus,
                                string strNarrations, string strBatchSize, string strManuDate);
        [OperationContract]
        string mSUpdatebatch(string strDeComID, string msstrOldNo, string strLogNo, string strStartDate, string strEndDate, string strExpireDate, string strLedgerName, string strstatus,
                                string strNarrations, string strBatchSize, string strManuDate);
        [OperationContract]
        List<Batch> mDisPlaybatch(string strDeComID, long lngslNo, string Pyear);
        [OperationContract]
        List<DatabaseCompany> mloadDatabaseCompnay(string strDeComID);
        [OperationContract]
        List<StockCategory> mDisplayCategoryRecordOthers(string strDeComID, long vstrPrimaryKey);
        [OperationContract]
        Dictionary<string, string> mLoadStockCategoryOthers(string strDeComID);
        [OperationContract]
        List<StockCategory> mFillStockCategoryOthers(string strDeComID);
        [OperationContract]
        string mInsertOtherscategory(string strDeComID, string vstrName, string vstrUnder);
        [OperationContract]
        string mUpdateOtherscategory(string strDeComID, long mstrPrimaryKey, string vstrName, string vstrUnder);
        [OperationContract]
        string mDeletcategoryOthers(string strDeComID, long strSerialfNo);
        [OperationContract]
        List<StockGroup> mFillStockGroupconfig(string strDeComID);
        [OperationContract]
        string mInsertStockGroupNew(string strDeComID, string vstrName);
        [OperationContract]
        string mUpdateStockGroupNew(string strDeComID, string mstrPrimaryKey, string vstrName);

        [OperationContract]
        string mDeleteStockGroupNew(string strDeComID, string mstrPrimaryKey);

        [OperationContract]
        List<CommissionConfig> mFillCommissionconfig(string strDeComID);

        [OperationContract]
        string mInsertCommission(string strDeComID, string strCommKey, string vstrBranchID, string vstrGropConfig, string strEffectiveDate, int intstatus, string strGrid);

        [OperationContract]
        string mUpdateCommisssion(string strDeComID, string strOldCommKey, string strCommKey, string vstrBranchID, string vstrGropConfig, string strEffectiveDate, int intstatus, string strGrid);

        [OperationContract]
        string mDeleteCommission(string strDeComID, string mstrPrimaryKey);
        [OperationContract]
        List<CommissionConfig> mDisplayCommissionconfig(string strDeComID, string masterKey);

        [OperationContract]
        List<Section> mFillSection(string strDeComID);
        [OperationContract]
        string mInsertSection(string strDeComID, string strSectionName);
        [OperationContract]
        string mUpdateSection(string strDeComID, string stroldSectionName, string strSectionName);
        [OperationContract]
        string mDeleteSection(string strDeComID, string mstrPrimaryKey);

        [OperationContract]
        List<MaterialType> mFillMaterialType(string strDeComID);

        [OperationContract]
        string mInsertMaterialType(string strDeComID,string strSectionName);

        [OperationContract]
        string mUpdateMaterialType(string strDeComID, string stroldName, string strMaterialTypeName);

        [OperationContract]
        string mDeleteMaterialType(string strDeComID, string mstrPrimaryKey);
        [OperationContract]
        Dictionary<string, string> mFillSectionNew(string strDeComID);
        [OperationContract]
        string mSaveStockOutWard(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                         double dblNetAmount, string strNarrations,
                                         string strBranchId, string vstrGodownName, string vstrBatchNo,
                                         string vstrCostOption, string vstrProcess, string DGSalesGrid, bool blngNumberMethod,
                                        string strFGItem, double dblFgQty, double dblFGRate, string vstrFgLocation, string vstrUOM);
        [OperationContract]
        string mUpdateStockOutWard(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                         double dblNetAmount, string strNarrations,
                                         string strBranchId, string vstrGodownName, string vstrBatchNo,
                                         string vstrCostOption, string vstrProcess, string DGSalesGrid,string strFGItem, 
                                         double dblFgQty, double dblFGRate, string vstrFgLocation, string vstrUOM);
        [OperationContract]
        string mSaveStockInWard(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                         double dblNetAmount, string strNarrations,
                                         string strBranchId, string vstrGodownName, string vstrBatchNo,
                                         string vstrCostOption, string vstrProcess, string DGSalesGrid);
        [OperationContract]
        string mUpdateStockInWard(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName, string vstrBatchNo,
                                        string vstrCostOption, string vstrProcess, string DGSalesGrid);

        [OperationContract]
        List<MFGvouhcer> mDisplayInOutMaster(string strDeComID, string vstrStockSerial, int intvType, string strFind, string strExpression, string strFdate, string strTodate, string strStockItemName);

        [OperationContract]
        List<MFGvouhcer> mDisplayInoutTran(string strDeComID, string vstrStockSerial);
        [OperationContract]
        string mDeleteStockConum(string strDeComID, string strRefNo);
        [OperationContract]
        string mSaveStockDamage(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                         double dblNetAmount, string strNarrations,
                                         string strBranchId, string vstrGodownName, string DGSalesGrid, bool blngNumberMethod);
        [OperationContract]
        string mUpdateDamage(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                         double dblNetAmount, string strNarrations,
                                         string strBranchId, string vstrGodownName,
                                         string DGSalesGrid);
        [OperationContract]
        string mSavePhysicalStock(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                         double dblNetAmount, string strNarrations,
                                         string strBranchId, string vstrGodownName, string DGSalesGrid, bool blngNumberMethod);
        [OperationContract]
        string mUpdatePhysicalStock(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                          double dblNetAmount, string strNarrations,
                                          string strBranchId, string vstrGodownName, string DGSalesGrid);

        [OperationContract]
        List<StockItem> mFillDisplayPhyMaster(string strDeComID, string vstrRefNo);
        [OperationContract]
        List<StockItem> mFillDisplayPhysicalStock(string strDeComID, string vstrStockSerial);
        [OperationContract]
        List<StockItem> mFillDisplayStockDamage(string strDeComID, string vstrStockSerial, int intvtype);
        [OperationContract]
        string mDeleteProductionList(string strDeComID, string strRefNo);
        [OperationContract]
        List<StockItem> mFillDamaPhy(string strDeComID, int mlngVType, string strFind, string strExpression, string strFdate, string strTodate);
        //[OperationContract]
        //string mSaveStockTransfer(string strDeComID, string strRefNo, long mlngVType, string strDate,
        //                                 double dblNetAmount, string strNarrations, string strBranchID,
        //                                 string strFromBranchName, string strToBranchName, string DGSalesGrid, bool blngNumberMethod, string vstrProcess);
        //[OperationContract]
        //string mUpdateStockTransfer(string strDeComID, string strRefNo, long mlngVType, string strDate,
        //                                 double dblNetAmount, string strNarrations, string strBranchID,
        //                                 string strFromBranchName, string strToBranchName, string DGSalesGrid,string vstrProcess);

        //[OperationContract]
        //string mDeleteStockTransfer(string strDeComID, string strRefNo);
        //[OperationContract]
        //List<StockItem> mFillStockTransfer(string strDeComID, int mlngVType, string strFind, string strExpression, string strFdate, string strTodate);
        //[OperationContract]
        //List<StockItem> mFillDisplayStockTransfer(string strDeComID, string vstrStockSerial);
        [OperationContract]
        List<Transport> mFillTransport(string strDeComID);
        [OperationContract]
        string mInsertTransport(string strDeComID, string strTransportName);
        [OperationContract]
        string mUpdateTransport(string strDeComID, string stroldName, string strTransportName);
        [OperationContract]
        string mDeleteTransport(string strDeComID, string mstrPrimaryKey);
        [OperationContract]
        List<Designation> mFillDesignation(string strDeComID);
        [OperationContract]
        string mInsertDesignation(string strDeComID, string strDesignationName);
        [OperationContract]
        string mUpdateDesignation(string strDeComID, string stroldName, string strDesiName);
        [OperationContract]
        string mDeleteDesignation(string strDeComID, string mstrPrimaryKey);
        [OperationContract]
        List<SampleClass> mFillSampleClass(string strDeComID);
        [OperationContract]
        string mInsertSampleClass(string strDeComID, string strSampleClass, string DG);
        [OperationContract]
        string mUpdateSampleClass(string strDeComID, string strOldSample, string strSampleClass, string DG);

        [OperationContract]
        string mDeleteSampleClass(string strDeComID, string mstrPrimaryKey);
        [OperationContract]
        List<SampleClass> mDisplaySampleClass(string strDeComID, string mstKey);

        [OperationContract]
        string mInsertTarget(string strDeComID, string strInsert, string strKey, string strLedgerName, string strFromDate, string strTodate, string strbranchID, string strFormName, string DG, string strPrifix);

        [OperationContract]
        List<SalesTarget> mFillSalesTarget(string strDeComID);
        [OperationContract]
        List<SalesTarget> mFillSalesCollection(string strDeComID);
        [OperationContract]
        List<SalesTarget> mDisplayTarget(string strDeComID, string strKey);
        [OperationContract]
        string mUpdateTarget(string strDeComID, string strKey, string strLedgerName, string strFromDate, string strTodate, string strbranchID, string strFormName, string DG);
        [OperationContract]
        string mDeleteTarget(string strDeComID, string strKey, string strFormName);
        [OperationContract]
        List<SalesTarget> mFillSalesCreditLimit(string strDeComID);
        [OperationContract]
        List<SalesTarget> mDisplaySalesCollection(string strDeComID, string strKey, string strLedgerName);
        [OperationContract]
        List<SalesTarget> mDisplayCreditLimit(string strDeComID, string strKey, string strLedgerName);
        [OperationContract]
        List<Sample> mFillSample(string strDeComID, string strPrefix);
        [OperationContract]
        string mInsertSample(string strDeComID, long mlngVType, string strBranchId, string strRefNo, string strDate, string strMonthID, string strLedgerName,
                                        string strDueDate, double dblNetAmount, string strLocation, string strCustomer, string strNarrations, string DG,bool mblnNumbMethod);
        [OperationContract]
        string mUpdateSample(string strDeComID, string strOldRefNo, long mlngVType, string strBranchId, string strRefNo, string strDate, string strMonthID, string strLedgerName,
                                       string strDueDate, double dblNetAmount, string strLocation, string strCustomer, string strNarrations, string DG);

        [OperationContract]
        string mDeleteSample(string strDeComID, string strOldRefNo);

        [OperationContract]
        List<Sample> mDisplaySampleList(string strDeComID, string mstrPrimarykey);

        [OperationContract]
        List<Sample> mDisplaySampleItem(string strDeComID, string mstrPrimarykey);
        [OperationContract]
        List<Sample> GetSampleList(string strDeComID, int intvtype, string strFdate, string strTdate, string strFind, string strExpression, string strMySQl);

        [OperationContract]
        List<StockItem> mloadStockItemNotInGroup(string strDeComID, string vstrRoot);
        [OperationContract]
        List<StockGroup> mFillStockGroupconfigNew(string strDeComID, string strName);
        [OperationContract]
        List<StockGroup> mFillPackSizeNew(string strDeComID, string strName);
        [OperationContract]
        List<StockItem> mloadAddStockItemRMPack(string strDeComID, string strRawLocation, string strGroupName, string strFGYN);
        [OperationContract]
        List<StockItem> mloadAddStockItemFg(string strDeComID, string strLocation);
        [OperationContract]
        Dictionary<string, string> mFillOpeningBatchNew(string strDeComID);
        [OperationContract]
        string mUpdateOption(string strDeComID, int intNegetive);
        [OperationContract]
        List<ManuProcess> mLoadFgProcessFG(string strDeComID, string Pyear);
        [OperationContract]
        double gFillStockItemPhysical(string strDeComID, string vstrGodown, string strItemName);
        [OperationContract]
        List<StockItem> mFillStockTreeGroupLevel2(string strDeComID);

    }
}
