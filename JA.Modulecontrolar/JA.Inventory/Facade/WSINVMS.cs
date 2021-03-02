using JA.Inventory.Dal;
using JA.Inventory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JA.Inventory.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WSINVMS" in both code and config file together.
    public class WSINVMS : IWSINVMS
    {
        public List<ManuProcess> mDisplayRequisitionNo(string strDeComID, string strRequisionNO)
        {
            return new JaInventory().mDisplayRequisitionNo(strDeComID, strRequisionNO);
        }
        public List<Invoice> mGetStockRequiNo(string strDeComID, string strLocation, string strRefNo)
        {
            return new JaInventory().mGetStockRequiNo(strDeComID, strLocation, strRefNo);
        }
        public string mUpdateRequisitionNew(string strDeComID, string strRefNoMarze, string strRefNo, long mlngVType, string strDate, double dblNetAmount, string strNarrations,
                                      string strBranchId, string strGodownName, string strProcessName, double dblNetQty, int intstatus, string DG, bool mblnNumbMethod)
        {
            return new JaInventory().mUpdateRequisitionNew(strDeComID, strRefNoMarze, strRefNo, mlngVType, strDate, dblNetAmount, strNarrations,
                                        strBranchId, strGodownName, strProcessName, dblNetQty, intstatus, DG, mblnNumbMethod);
        }

        public string mSaveRequisition(string strDeComID, string strRefNo, long mlngVType, string strDate, double dblNetAmount, string strNarrations,
                                       string strBranchId, string strGodownName, string strProcessName, double dblNetQty, int intstatus, string DG, bool mblnNumbMethod)
        {
            return new JaInventory().mSaveRequisition(strDeComID, strRefNo, mlngVType, strDate, dblNetAmount, strNarrations,
                                        strBranchId, strGodownName, strProcessName, dblNetQty, intstatus, DG, mblnNumbMethod);
        }

        public string mUpdateRequisition(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                       double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency, string strProcessName,
                                       string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                       bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, string strPrepareBy,
                                       int intAppStatus, string strApprovedBy, string strApprovedDate, double dblNetQty, int intChaneType)
        {
            return new JaInventory().mUpdateRequisition(strDeComID, strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName,
                                                    dblNetAmount, strNarrations, strBranchId, strGodownName, lngIsMultiCurrency, strProcessName,
                                                    strDelivery, strPayment, strSupport, dteValidaty, strOtherTerms, DG,
                                                    blnMultiCurr, mdblCurrRate, mstrFCsymbol, strPrepareBy, intAppStatus, strApprovedBy, strApprovedDate, dblNetQty, intChaneType);
        }
       
        public List<ManuProcess> mDisplayTransferOutItem(string strDeComID, string strvoucherNo, string strflag)
        {
            return new JaInventory().mDisplayTransferOutItem(strDeComID, strvoucherNo, strflag);
        }
        public List<InvoiceConfig> mGetStockTranRefNo(string strDeComID, string strLocation, string strRefNo)
        {
            return new JaInventory().mGetStockTranRefNo(strDeComID, strLocation, strRefNo);
        }
        public List<MFGvouhcer> mDisplayRepacking(string strDeComID, string vstrStockSerial)
        {
            return new JaInventory().mDisplayRepacking(strDeComID, vstrStockSerial);
        }
        public List<MFGvouhcer> mGetProductionNoFBatch(string strDeComID, string vstrBatchNo)
        {
            return new JaInventory().mGetProductionNoFBatch(strDeComID, vstrBatchNo);
        }
        public string mUpdateSalesOrderOnlineComm(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strBranchId, string strGodownName, string DG)
        {
            return new JaInventory().mUpdateSalesOrderOnlineComm(strDeComID, strRefNo, mlngVType, strDate, strDueDate, strMonthID, strBranchId, strGodownName, DG);
        }
        public List<Invoice> mfillPartyNameNewSI(string strDeComID, string strBranchID, bool blngAccessControl, string strUserID, int intStatus, string strMode)
        {
            return new JaInventory().mfillPartyNameNewSI(strDeComID, strBranchID, blngAccessControl, strUserID, intStatus, strMode);
        }
        public List<StockItem> mGetStockGroup(string strDeComID, int intmode)
        {
            return new JaInventory().mGetStockGroup(strDeComID,intmode);
        }
        public List<Invoice> mFillLedgerStatus(string strDeComID, long vlngGroup, int intStatus, string strBranchID)
        {
            return new JaInventory().mFillLedgerStatus(strDeComID, vlngGroup, intStatus, strBranchID);
        }
        public List<StockItem> gLoadInvoiceLocation(string strDeComID, string vstrBranchID, bool gblngAccesscontrol, string strUserName, int intStatus)
        {
            return new JaInventory().gLoadInvoiceLocation(strDeComID, vstrBranchID, gblngAccesscontrol, strUserName, intStatus);
        }
        public List<SalesTarget> mDisplayCollectionTarget(string strDeComID, string strKey)
        {
            return new JaInventory().mDisplayCollectionTarget(strDeComID, strKey);
        }
        public List<SalesTarget> mDisplayTargetLedger(string strDeComID, string strKey, string strLedgerName)
        {
            return new JaInventory().mDisplayTargetLedger(strDeComID, strKey, strLedgerName);
        }
        public List<SalesTarget> mDisplayCreditLimitLedger(string strDeComID, string strKey)
        {
            return new JaInventory().mDisplayCreditLimitLedger(strDeComID, strKey);
        }
        public List<StockItem> mFillStockItemListNewEdit(string strDeComID, int intType, string strRefNo)
        {
            return new JaInventory().mFillStockItemListNewEdit(strDeComID, intType, strRefNo);
        }
        public string gOpenComID(string strID)
        {
            return new JaInventory().gOpenComID(strID);
        }
        public void DoWork()
        {
        }
        public List<SalesTarget> mFillItemPackTarget(string strDeComID)
        {
            return new JaInventory().mFillItemPackTarget(strDeComID);
        }

        public List<SalesTarget> mDisplayItemTarget(string strDeComID, string strKey)
        {
            return new JaInventory().mDisplayItemTarget(strDeComID, strKey);
        }

        public string mDeleteItemTarget(string strDeComID, string strKey)
        {
            return new JaInventory().mDeleteItemTarget(strDeComID, strKey);
        }
        public string mInsertItemPackTarget(string strDeComID, string strOldKey, string strInsert, string strKey, string strLedgerName, string strFromDate, string strTodate, string strbranchID, int intType, string DG)
        {
            return new JaInventory().mInsertItemPackTarget(strDeComID, strOldKey, strInsert, strKey, strLedgerName, strFromDate, strTodate, strbranchID, intType, DG);
        }
        public List<StockItem> mFillStockItemListNew(string strDeComID, int intType, int intSP)
        {
            return new JaInventory().mFillStockItemListNew(strDeComID, intType, intSP);
        }
        public List<Invoice> mFillLedgerParentGroup(string strDeComID, int mintLedgerGroup, string strSelection)
        {
            return new JaInventory().mFillLedgerParentGroup(strDeComID, mintLedgerGroup, strSelection);
        }
        public string mloadDatabaseCompnaytest(string strDeComID)
        {
            return new JaInventory().mloadDatabaseCompnaytest(strDeComID);
        }
        public List<StockItem> gLoadStockGroupLevel3PrivilegesRight(string strDeComID, string strUserName)
        {
            return new JaInventory().gLoadStockGroupLevel3PrivilegesRight(strDeComID, strUserName);
        }
        public List<StockItem> gLoadStockGroupLevel3Privileges(string strDeComID, string strUserName)
        {
            return new JaInventory().gLoadStockGroupLevel3Privileges(strDeComID, strUserName);
        }
        public List<Location> mLoadLocationUserPrivileges(string strDeComID, string strUSerName)
        {
            return new JaInventory().mLoadLocationUserPrivileges(strDeComID, strUSerName);
        }
        public List<Location> mLoadLocationUserPrivilegesRight(string strDeComID, string strUSerName)
        {
            return new JaInventory().mLoadLocationUserPrivilegesRight(strDeComID, strUSerName);
        }
        public List<StockItem> gLoadStockGroupLevel3(string strDeComID)
        {
            return new JaInventory().gLoadStockGroupLevel3(strDeComID);
        }
        public List<StockItem> mloadAddStockItemSI(string strDeComID, string vstrRoot, string strLocation)
        {
            return new JaInventory().mloadAddStockItemSI(strDeComID, vstrRoot, strLocation);
        }
        public List<Invoice> mFillSalesRepFromMPoNew1(string strDeComID, long vlngSLedgerType, string strLedgerName)
        {
            return new JaInventory().mFillSalesRepFromMPoNew1(strDeComID, vlngSLedgerType, strLedgerName);
        }
        public List<Invoice> mfillPartyNameNew(string strDeComID, string strBranchID, bool blngAccessControl, string strUserID, int intStatus, string strMode)
        {
            return new JaInventory().mfillPartyNameNew(strDeComID, strBranchID, blngAccessControl, strUserID, intStatus, strMode);
        }
        public List<Invoice> mFillSalesRepFromMPoNew(string strDeComID, long vlngSLedgerType, string strLedgerName)
        {
            return new JaInventory().mFillSalesRepFromMPoNew(strDeComID, vlngSLedgerType, strLedgerName);
        }

        public List<SalesPriceLevel> mBonusList(string strDeComID, string VstrLevelName, string fDate, string tDate)
        {
            return new JaInventory().mBonusList(strDeComID, VstrLevelName, fDate, tDate);
        }

        public List<SalesPriceLevel> mGiftList(string strDeComID, string VstrLevelName, string fDate, string tDate)
        {
            return new JaInventory().mGiftList(strDeComID, VstrLevelName, fDate, tDate);
        }
        public List<ManuProcess> mLoadProduction(string strDeComID, string Pyear, int intStatus)
        {
            return new JaInventory().mLoadProduction(strDeComID, Pyear, intStatus);
        }
        //public string mDeleteMFG(string strDeComID, string strOldInvLog, string strOldRm, string strOldWm, string stroldFm)
        //{
        //    return new JaInventory().mDeleteMFG(strDeComID,strOldInvLog, strOldRm, strOldWm, stroldFm);
        //}
        public List<StockItem> gFillStockItemAllWithoutGodown(string strDeComID, bool blngAccessControl, string strUserName, string vstrGroupName)
        {
            return new JaInventory().gFillStockItemAllWithoutGodown(strDeComID, blngAccessControl, strUserName, vstrGroupName);
        }
        public string mDeleteBatchSize(string strDeComID, long lngslNo, string strBatchNo)
        {
            return new JaInventory().mDeleteBatchSize(strDeComID, lngslNo, strBatchNo);
        }
        public List<StockItem> mloadAddStockItem(string strDeComID, string vstrRoot)
        {
            return new JaInventory().mloadAddStockItem(strDeComID, vstrRoot);
        }
        //public List<StockItem> mloadAddStockItemNew(string strDeComID, string vstrRoot, string strLocation)
        //{
        //    return new JaInventory().mloadAddStockItemNew(strDeComID,vstrRoot, strLocation);
        //}
        public List<Invoice> mFillSalesRepFromMPo(string strDeComID, long vlngSLedgerType, string strLedgerName)
        {
            return new JaInventory().mFillSalesRepFromMPo(strDeComID, vlngSLedgerType, strLedgerName);
        }
        public List<Invoice> GetMPONameFromTC(string strDeComID, string strCode)
        {
            return new JaInventory().GetMPONameFromTC(strDeComID, strCode);
        }
        public List<StockItem> gFillStockItemAll(string strDeComID, string vstrGodown)
        {
            return new JaInventory().gFillStockItemAll(strDeComID, vstrGodown);
        }

        public Dictionary<string, string> mLoadStockGroup(string strDeComID)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("Primary", "Primary");
            foreach (StockGroup ogrp in new JaInventory().mLoadStockGroup(strDeComID))
            {
                ooGrp.Add(ogrp.GroupName, ogrp.GroupName);
            }
            return ooGrp;
        }

        public Dictionary<string, string> gFillSalesLedgerbatch(string strDeComID, long vlngSLedgerType)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("End of List", "End of List");
            foreach (Invoice ogrp in new JaInventory().gFillSalesLedgerbatch(strDeComID, vlngSLedgerType))
            {
                ooGrp.Add(ogrp.strSalesLedger, ogrp.strSalesLedger);
            }
            return ooGrp;
        }

        public string mInsertGroup(string strDeComID, string vstrName, string vstrUnder, string vstrGrName, int intpacksize, int intStatus)
        {
            return new JaInventory().mInsertGroup(strDeComID, vstrName, vstrUnder, vstrGrName, intpacksize, intStatus);
        }

        public List<StockGroup> mFillStockGroupList(string strDeComID)
        {
            return new JaInventory().mFillStockGroupList(strDeComID);
        }
        public List<StockGroup> mDisplayRecord(string strDeComID, long vstrPrimaryKey)
        {
            return new JaInventory().mDisplayRecord(strDeComID, vstrPrimaryKey);
        }
        public string mUpdateGroup(string strDeComID, long vstrPrimaryKey, string vstrName, string vstrUnder, string vstrGrName, int intpacksize, int intStatus)
        {
            return new JaInventory().mUpdateGroup(strDeComID, vstrPrimaryKey, vstrName, vstrUnder, vstrGrName, intpacksize, intStatus);
        }
        public string mDeleteStockGroup(string strDeComID, long vlngGroupPrimary)
        {
            return new JaInventory().mDeleteStockGroup(strDeComID, vlngGroupPrimary);
        }



        public List<StockCategory> mDisplayCategoryRecord(string strDeComID, long vstrPrimaryKey)
        {
            return new JaInventory().mDisplayCategoryRecord(strDeComID, vstrPrimaryKey);
        }

        public Dictionary<string, string> mLoadStockCategory(string strDeComID)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("Primary", "Primary");
            foreach (StockCategory ogrp in new JaInventory().mLoadStockCategory(strDeComID))
            {
                ooGrp.Add(ogrp.CategoryName, ogrp.CategoryName);
            }
            return ooGrp;
        }

        public Dictionary<string, string> mLoadStockCategoryItem(string strDeComID)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            //ooGrp.Add("Primary", "Primary");
            foreach (StockCategory ogrp in new JaInventory().mLoadStockCategoryItem(strDeComID))
            {
                ooGrp.Add(ogrp.CategoryName, ogrp.CategoryName);
            }
            return ooGrp;
        }
        public List<StockCategory> mFillStockCategory(string strDeComID)
        {
            return new JaInventory().mFillStockCategory(strDeComID);
        }
        public string mInsertcategory(string strDeComID, string vstrName, string vstrUnder)
        {
            return new JaInventory().mInsertcategory(strDeComID, vstrName, vstrUnder);
        }

        public string mUpdatecategory(string strDeComID, long mstrPrimaryKey, string vstrName, string vstrUnder)
        {
            return new JaInventory().mUpdatecategory(strDeComID, mstrPrimaryKey, vstrName, vstrUnder);
        }

        public string mDeletcategory(string strDeComID, long strSerialfNo)
        {
            return new JaInventory().mDeletcategory(strDeComID, strSerialfNo);
        }

        public string mInsertUnitMeasurement(string strDeComID, string vstrSymbol, string vstrFormal, long noofDecimalPlaces)
        {
            return new JaInventory().mInsertUnitMeasurement(strDeComID, vstrSymbol, vstrFormal, noofDecimalPlaces);
        }

        public string mUpdateMeasurementUnit(string strDeComID, long strUnitSerialNo, string vstrSymbol, string vstrFormal, long noofDecimalPlaces)
        {
            return new JaInventory().mUpdateMeasurementUnit(strDeComID, strUnitSerialNo, vstrSymbol, vstrFormal, noofDecimalPlaces);
        }
        public List<MeasurementUnit> mLoadMeasurementUnit(string strDeComID)
        {
            return new JaInventory().mLoadMeasurementUnit(strDeComID);
        }
        public string DeleteMeasurementUnit(string strDeComID, string strSymbol, long strKey)
        {
            return new JaInventory().DeleteMeasurementUnit(strDeComID, strSymbol, strKey);
        }
        //public string mInsertGodowns(string strDeComID, string vstrLocation, string vstrUnder, string vstrBranch, 
        //                            string vstrAddress1, string vstrAddress2, string vstrCity,
        //                            string vstrPhone, string vstrFax, int intsection)
        //{
        //    return new JaInventory().mInsertGodowns(strDeComID,vstrLocation, vstrUnder, vstrBranch,
        //                                            vstrAddress1, vstrAddress2, vstrCity,
        //                                            vstrPhone, vstrFax,intsection);
        //}
        //public string mUpdateGodown(string strDeComID, long vstrPrimaryKey, string vstrLocation, string vstrUnder, string vstrBranch,
        //                            string vstrAddress1, string vstrAddress2, string vstrCity,
        //                            string vstrPhone, string vstrFax, int intsection)
        //{
        //    return new JaInventory().mUpdateGodown(strDeComID,vstrPrimaryKey, vstrLocation, vstrUnder, vstrBranch,
        //                                           vstrAddress1, vstrAddress2, vstrCity,
        //                                           vstrPhone, vstrFax,intsection);
        //}
        public List<Location> mDisplayLocation(string strDeComID, long vstrPrimaryKey)
        {
            return new JaInventory().mDisplayLocation(strDeComID, vstrPrimaryKey);
        }
        public List<Location> mLoadLocation(string strDeComID, bool vblngAccessControl, string vstrUserName)
        {
            return new JaInventory().mLoadLocation(strDeComID, vblngAccessControl, vstrUserName);
        }
        public string mDeleteLocation(string strDeComID, string strSubGroup, long strRefNo)
        {
            return new JaInventory().mDeleteLocation(strDeComID, strSubGroup, strRefNo);
        }



        public List<StockItem> mFillUOM(string strDeComID)
        {
            return new JaInventory().mFillUOM(strDeComID);
        }


        public Dictionary<string, string> mFillOpeningBatch(string strDeComID)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("End of List", "End of List");
            foreach (StockItem ogrp in new JaInventory().mFillOpeningBatch(strDeComID))
            {
                ooGrp.Add(ogrp.strBatch, ogrp.strBatch);
            }
            return ooGrp;
        }
        public Dictionary<string, string> mFillOpeningBatchNew(string strDeComID)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("End of List", "End of List");
            foreach (StockItem ogrp in new JaInventory().mFillOpeningBatch(strDeComID))
            {
                ooGrp.Add(ogrp.strBatch, ogrp.strBatch);
            }
            return ooGrp;
        }

        public List<StockItem> mFillLedger(string strDeComID, long lngGroup)
        {
            return new JaInventory().mFillLedger(strDeComID, lngGroup);
        }

        public List<StockItem> gLoadStockGroup(string strDeComID, bool vblngAccessContron, string vstrUserName, string strFgYN, string strGroupName)
        {
            return new JaInventory().gLoadStockGroup(strDeComID, vblngAccessContron, vstrUserName, strFgYN, strGroupName);
        }

        public string mInsertStockItem(string strDeComID, string vstrName, string vstrUnder, long lngMaintainBatch, string vstrStatus,
                                        string vstrItemName, string vstrAlias, string vstrdescription, string vstrParent, string vstrCatgory,
                                        string vstrUnit, string vstrAltUnit, string vstrWhere, string vstrWhereUnit, string vstrManufacturer,
                                        string vstrSupplier, string vstrTransalator, string vstritemBangla, double dblMinimumstock, double dblReorderQty,
                                        double dblOpnQty, double dblopnRate, double dblAmnt, string dg, string strMatType, string strPowerClass, string strBatch, int intSP)
        {
            return new JaInventory().mInsertStockItem(strDeComID, vstrName, vstrUnder, lngMaintainBatch, vstrStatus,
                                        vstrItemName, vstrAlias, vstrdescription, vstrParent, vstrCatgory,
                                        vstrUnit, vstrAltUnit, vstrWhere, vstrWhereUnit, vstrManufacturer,
                                        vstrSupplier, vstrTransalator, vstritemBangla, dblMinimumstock, dblReorderQty,
                                        dblOpnQty, dblopnRate, dblAmnt, dg, strMatType, strPowerClass, strBatch, intSP);
        }



        public string mUpdateStockItem(string strDeComID, long vstrPrimaryKey, string vstrName, string vstrUnder, long lngMaintainBatch, string vstrStatus,
                                       string vstrItemName, string vstrAlias, string vstrdescription, string vstrParent, string vstrCatgory,
                                       string vstrUnit, string vstrAltUnit, string vstrWhere, string vstrWhereUnit, string vstrManufacturer,
                                       string vstrSupplier, string vstrTransalator, string vstritemBangla, double dblMinimumstock, double dblReorderQty,
                                       double dblOpnQty, double dblopnRate, double dblAmnt, string dg, string strMatTytpe, string strpowerclass, string strBatch, int intSP)
        {
            return new JaInventory().mUpdateStockItem(strDeComID, vstrPrimaryKey, vstrName, vstrUnder, lngMaintainBatch, vstrStatus,
                                       vstrItemName, vstrAlias, vstrdescription, vstrParent, vstrCatgory,
                                       vstrUnit, vstrAltUnit, vstrWhere, vstrWhereUnit, vstrManufacturer,
                                       vstrSupplier, vstrTransalator, vstritemBangla, dblMinimumstock, dblReorderQty,
                                       dblOpnQty, dblopnRate, dblAmnt, dg, strMatTytpe, strpowerclass, strBatch, intSP);
        }

        public List<StockItem> mFillStockItemList(string strDeComID, int intStatus, string vstrPrefix = "", string strAlias = "")
        {
            return new JaInventory().mFillStockItemList(strDeComID, intStatus, vstrPrefix, strAlias);
        }

        public List<StockItem> mDisplayItemRecord(string strDeComID, long vstrPrimaryKey)
        {
            return new JaInventory().mDisplayItemRecord(strDeComID, vstrPrimaryKey);
        }
        public List<StockItem> mLoadGodownData(string strDeComID, string vstrPrimaryKey)
        {
            return new JaInventory().mLoadGodownData(strDeComID, vstrPrimaryKey);
        }
        public string mDeleteStockItem(string strDeComID, string vstrPrimaryKey)
        {
            return new JaInventory().mDeleteStockItem(strDeComID, vstrPrimaryKey);
        }
        public List<StockItem> mFillStockTreeGroupLevel(string strDeComID)
        {
            return new JaInventory().mFillStockTreeGroupLevel(strDeComID);
        }

        //public List<StockItem> mloadAddStockItem(string vstrRoot)
        //{
        //    return new JaInventory().mloadAddStockItem(vstrRoot);
        //}

        public List<StockItem> mFillStockTreeGroupLevel1(string strDeComID)
        {
            return new JaInventory().mFillStockTreeGroupLevel1(strDeComID);
        }

        public List<StockItem> gLoadLocation(string strDeComID, string vstrBranchID, bool gblngAccesscontrol, string strUserName, int intStatus)
        {
            return new JaInventory().gLoadLocation(strDeComID, vstrBranchID, gblngAccesscontrol, strUserName, intStatus);
        }

        public List<Invoice> mfillLedgerInvoice(string strDeComID, bool vblngDrcr, long mlngLedgerAs, string strLoose)
        {
            return new JaInventory().mfillLedgerInvoice(strDeComID, vblngDrcr, mlngLedgerAs, strLoose);
        }

        public List<Invoice> gFillSalesLedger(string strDeComID, long vlngSLedgerType)
        {
            return new JaInventory().gFillSalesLedger(strDeComID, vlngSLedgerType);
        }

        public List<Invoice> gFillPurchaseLedger(string strDeComID)
        {
            return new JaInventory().gFillPurchaseLedger(strDeComID);
        }

        public Dictionary<string, string> mFillSalesRep(string strDeComID, long vlngSLedgerType)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            //ooGrp.Add("End of List", "End of List");
            foreach (Invoice ogrp in new JaInventory().mFillSalesRep(strDeComID, vlngSLedgerType))
            {
                ooGrp.Add(ogrp.strSalesRepresentative, ogrp.strSalesRepresentative);
            }
            return ooGrp;
        }

        public string mSaveSalesRepresentive(string strDeComID, string vstrLedgerCode, string vstrLedgerName, string vstrTeritoryCode, string vstrTeritoryName, double dblTargetAmount,
                                            string vstrHomoeHall, int intStatus, string vstrUnder, string vstrMrName, double dblOpeningBalance, double dblcommPercent,
                                            string vstrDrcr, string vstrCommType, string vstrAddress1,
                                            string vstrAddress2, string vstrCommnets, string vstrCity, string vstrPostal, string vstrPhone)
        {
            return new JaInventory().mSaveSalesRepresentive(strDeComID, vstrLedgerCode, vstrLedgerName, vstrTeritoryCode, vstrTeritoryName, dblTargetAmount, vstrHomoeHall, intStatus, vstrUnder,
                                           vstrMrName, dblOpeningBalance, dblcommPercent, vstrDrcr, vstrCommType, vstrAddress1,
                                           vstrAddress2, vstrCommnets, vstrCity, vstrPostal, vstrPhone);
        }


        public string mUpdateSalesRepresentive(string strDeComID, string mstrOldLedger, long mlngLedgerSerial, string vstrLedgerCode, string vstrLedgerName, string vstrTeritoryCode,
                                            string vstrTeritoryName, double dblTargetAmount, string vstrHomoeHall, int intStatus, string vstrMrName, string vstrUnder,
                                            double dblOpeningBalance, double dblcommPercent,
                                            string vstrDrcr, string vstrCommType, string vstrAddress1,
                                            string vstrAddress2, string vstrCommnets, string vstrCity, string vstrPostal, string vstrPhone)
        {
            return new JaInventory().mUpdateSalesRepresentive(strDeComID, mstrOldLedger, mlngLedgerSerial, vstrLedgerCode, vstrLedgerName, vstrTeritoryCode, vstrTeritoryName,
                                           dblTargetAmount, vstrHomoeHall, intStatus, vstrMrName, vstrUnder, dblOpeningBalance, dblcommPercent,
                                            vstrDrcr, vstrCommType, vstrAddress1,
                                            vstrAddress2, vstrCommnets, vstrCity, vstrPostal, vstrPhone);
        }

        public List<SalesPriceLevel> mGetPriceLevel(string strDeComID)
        {
            return new JaInventory().mGetPriceLevel(strDeComID);
        }
        public string mSaveSalesPrice(string strDeComID, string vstrName, int intmode, string mstrPreviousLevel)
        {
            return new JaInventory().mSaveSalesPrice(strDeComID, vstrName, intmode, mstrPreviousLevel);
        }

        public List<StockItem> gFillStockItem(string strDeComID, string vstrGodown = "", string vstrPrefix = "", bool blngAlias = true)
        {
            return new JaInventory().gFillStockItem(strDeComID, vstrGodown, vstrPrefix, blngAlias);
        }

        public List<StockItem> gFillStockItemCheck(string strDeComID, string vstrGodown = "", long vlngLedgerGroup = 0, long vlngStockType = 0, long vlngManufacGroup = 0, string vstrPrefix = "")
        {
            return new JaInventory().gFillStockItemCheck(strDeComID, vstrGodown, vlngLedgerGroup, vlngStockType, vlngManufacGroup, vstrPrefix);
        }
        public string mInsertPriceconfig(string strDeComID, string DgGrid, string strKeydate, string mstrPriceLevel, string strEffectivedate)
        {
            return new JaInventory().mInsertPriceconfig(strDeComID, DgGrid, strKeydate, mstrPriceLevel, strEffectivedate);
        }
        public List<SalesPriceLevel> mDisplayItemGroup(string strDeComID, string vstrItemGroup, string vstrDate)
        {
            return new JaInventory().mDisplayItemGroup(strDeComID, vstrItemGroup, vstrDate);
        }

        public List<SalesPriceLevel> mRefreshPriceList(string strDeComID, string VstrLevelName, string fDate, string tDate)
        {
            return new JaInventory().mRefreshPriceList(strDeComID, VstrLevelName, fDate, tDate);
        }
        public string mDeletePriceList(string strDeComID, string VstrLevelName, string strDate)
        {
            return new JaInventory().mDeletePriceList(strDeComID, VstrLevelName, strDate);
        }
        public string mInsertGiftItem(string strDeComID, string DgGrid, string strAppDate, string strDateKey)
        {
            return new JaInventory().mInsertGiftItem(strDeComID, DgGrid, strAppDate, strDateKey);
        }
        public List<SalesPriceLevel> mDisplayGiftItemGroup(string strDeComID, string vstrDate)
        {
            return new JaInventory().mDisplayGiftItemGroup(strDeComID, vstrDate);
        }
        public string mDeleteGiftItem(string strDeComID, string strAppDate, string vstrBranchId)
        {
            return new JaInventory().mDeleteGiftItem(strDeComID, strAppDate, vstrBranchId);
        }

        public string mInsertBonusItem(string strDeComID, string DgGrid, string strAppDate, string strDateKey)
        {
            return new JaInventory().mInsertBonusItem(strDeComID, DgGrid, strAppDate, strDateKey);
        }
        public List<SalesPriceLevel> mDisplayBonusItemGroup(string strDeComID, string vstrDate)
        {
            return new JaInventory().mDisplayBonusItemGroup(strDeComID, vstrDate);
        }
        public string mDeleteBonusItem(string strDeComID, string strAppDate, string vstrBranchId)
        {
            return new JaInventory().mDeleteBonusItem(strDeComID, strAppDate, vstrBranchId);
        }
        public string msaveSalesOrder(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                        double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency, string strSalesRep,
                                        string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                        bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool mblnNumbMethod, string strPrepareBy,
                                        int intAppStatus, string strApprovedBy, string strApprovedDate, double dblNetQty,double  dblLessAmount,double dblTotal)
        {
            return new JaInventory().msaveSalesOrder(strDeComID, strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName,
                                                     dblNetAmount, strNarrations, strBranchId, strGodownName, lngIsMultiCurrency, strSalesRep,
                                                     strDelivery, strPayment, strSupport, dteValidaty, strOtherTerms, DG,
                                                     blnMultiCurr, mdblCurrRate, mstrFCsymbol, mblnNumbMethod, strPrepareBy, intAppStatus, strApprovedBy, strApprovedDate, dblNetQty,  dblLessAmount, dblTotal);
        }

        public string mUpdateSalesOrder(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                       double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency, string strSalesRep,
                                       string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                       bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, string strPrepareBy,
                                       int intAppStatus, string strApprovedBy, string strApprovedDate, double dblNetQty, int intChaneType,double  dblLessAmount,double dblTotal)
        {
            return new JaInventory().mUpdateSalesOrder(strDeComID, strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName,
                                                    dblNetAmount, strNarrations, strBranchId, strGodownName, lngIsMultiCurrency, strSalesRep,
                                                    strDelivery, strPayment, strSupport, dteValidaty, strOtherTerms, DG,
                                                    blnMultiCurr, mdblCurrRate, mstrFCsymbol, strPrepareBy, intAppStatus, strApprovedBy, strApprovedDate, dblNetQty, intChaneType, dblLessAmount, dblTotal);
        }

        public List<Invoice> mGetAllOrder(string strDeComID, string vstrBranchID, long lngrefType, string vstrRefNumber)
        {
            return new JaInventory().mGetAllOrder(strDeComID, vstrBranchID, lngrefType, vstrRefNumber);
        }
        public List<InvoiceConfig> mGetInvoiceConfig(string strDeComID)
        {
            return new JaInventory().mGetInvoiceConfig(strDeComID);
        }

        //public string mSaveSalesInvoice(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger, double dblTotalAmnt,
        //                               double dblNetAmount,double dblAddAmount,double dblLessAmount,string strRefType,long lngAgstRef,long mlngIsInvEffinDirSalesInv,long mlngIsChqueCash,  string strNarrations, 
        //                               string strBranchId, string vstrGodownName, long lngIsMultiCurrency, string strSalesRep, string DGSalesGrid,string DGVector,string DGBillWise,string DGsalesOrder,string DGAddles,
        //                               bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool blngNumberMethod, string strOrderNo, string strOrderDate, string strPreparedby, string strPreparedDate, double dblProcessAmount, double dblRoundOff)
        //{
        //    return new JaInventory().mSaveSalesInvoice(strDeComID,strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName, strSalesLedger,
        //                                                  dblTotalAmnt,dblNetAmount, dblAddAmount, dblLessAmount, strRefType, lngAgstRef, mlngIsInvEffinDirSalesInv, mlngIsChqueCash, strNarrations,
        //                                                  strBranchId, vstrGodownName, lngIsMultiCurrency, strSalesRep, DGSalesGrid, DGVector, DGBillWise, DGsalesOrder,DGAddles,
        //                                                  blnMultiCurr, mdblCurrRate, mstrFCsymbol, blngNumberMethod, strOrderNo, strOrderDate, strPreparedby, strPreparedDate,dblProcessAmount, dblRoundOff);

        //}

        public List<InvoiceConfig> mGetInvoiceConfigNew(string strDeComID)
        {
            return new JaInventory().mGetInvoiceConfigNew(strDeComID);
        }

        public Dictionary<string, string> mFillSalesRepLedger(string strDeComID, long vlngSLedgerType)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("End of List", "End of List");
            foreach (Invoice ogrp in new JaInventory().mFillSalesRepLedger(strDeComID, vlngSLedgerType))
            {
                ooGrp.Add(ogrp.strSalesRepresentative, ogrp.strSalesRepresentative);
            }
            return ooGrp;
        }

        public Dictionary<string, string> mFillBatch(string strDeComID)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("End of List", "End of List");
            foreach (Invoice ogrp in new JaInventory().mFillBatch(strDeComID))
            {
                ooGrp.Add(ogrp.strBatch, ogrp.strBatch);
            }
            return ooGrp;
        }


        public List<Invoice> mfillPartyName(string strDeComID)
        {
            return new JaInventory().mfillPartyName(strDeComID);
        }

        // public string mSaveSalesChallan(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
        //                              double dblNetAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirSalesInv,  string strNarrations,
        //                              string strBranchId, string vstrGodownName, string DGSalesGrid, string DGsalesOrder, bool mblnNumberMethod,
        //                              string strCustomer,string strDesignation,string strTransport,double crtQty,double dblBox,string strTrNo)
        // {
        //     return new JaInventory().mSaveSalesChallan(strDeComID,strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName,
        //                               dblNetAmount, strRefType, lngAgstRef, mlngIsInvEffinDirSalesInv, strNarrations,
        //                               strBranchId, vstrGodownName, DGSalesGrid, DGsalesOrder,mblnNumberMethod,
        //                                strCustomer, strDesignation, strTransport, crtQty, dblBox, strTrNo);
        // }

        // public string mUpdateSalesChallan(string strDeComID, string mstRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
        //                             double dblNetAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirSalesInv, string strNarrations,
        //                             string strBranchId, string vstrGodownName, string DGSalesGrid, string DGsalesOrder,string strCustomer,string strDesignation,string strTransport,double dblcrtQty,double dblBox,string strTrNo)
        //{
        //    return new JaInventory().mUpdateSalesChallan(strDeComID,mstRefNo, strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName,
        //                                                 dblNetAmount, strRefType, lngAgstRef, mlngIsInvEffinDirSalesInv, strNarrations,
        //                                                 strBranchId, vstrGodownName, DGSalesGrid, DGsalesOrder, strCustomer, 
        //                                                 strDesignation, strTransport, dblcrtQty, dblBox,strTrNo);
        //}

        public List<StockItem> gFillStockItemManufacturer(string strDeComID, string vstrManufacturer, string vstrGodown, long vlngStockType)
        {
            return new JaInventory().gFillStockItemManufacturer(strDeComID, vstrManufacturer, vstrGodown, vlngStockType);
        }

        public string mInsertProcess(string strDeComID, string oldvstrProcess, string vstrProcess, string Dgfg, string DgRm, string Dgwastage,
                                    int actionmode, int intConvertType, int intTransferType, string strbranchID, string strLocation)
        {
            return new JaInventory().mInsertProcess(strDeComID, oldvstrProcess, vstrProcess, Dgfg, DgRm, Dgwastage, actionmode, intConvertType, intTransferType,strbranchID,strLocation);
        }

        public List<ManuProcess> mLoadProcess(string strDeComID, string Pyear, string vstrProcessName, int intType, int intTransfer)
        {
            return new JaInventory().mLoadProcess(strDeComID, Pyear, vstrProcessName, intType,intTransfer);
        }
        public List<ManuProcess> mDisplayProcess(string strDeComID, string vstrProcessName, string strType)
        {
            return new JaInventory().mDisplayProcess(strDeComID, vstrProcessName, strType);
        }
        public string mDeleteProcess(string strDeComID, string vstrProcess)
        {
            return new JaInventory().mDeleteProcess(strDeComID, vstrProcess);
        }

        //    public string mInsertMFGvoucher(string strDeComID, string strRefNo, string strInvLog, string strBranchIdFrom, string strBranchIdTo, string strGodown, string strGodownto, string strProcess,
        //                                   string strDate, string strNarrations, double mdblAmount,
        //                                   string Dgfg, string DgRm, string Dgwastage, int actionmode, bool mblnNumbMethod,int intconvertType)
        //{
        //    return new JaInventory().mInsertMFGvoucher(strDeComID,strRefNo,strInvLog, strBranchIdFrom, strBranchIdTo, strGodown, strGodownto, strProcess,
        //                                                  strDate, strNarrations, mdblAmount,
        //                                                  Dgfg, DgRm, Dgwastage, actionmode, mblnNumbMethod, intconvertType);
        //}

        //    public List<MFGvouhcer> mLoadMFGVoucher(string strDeComID, string fdate, string tdate, int intConType, string strFind, string strExpression, string strStockItemName)
        //{
        //    return new JaInventory().mLoadMFGVoucher(strDeComID,fdate,  tdate,  intConType,  strFind,  strExpression,  strStockItemName);
        //}

        //public string mUpdateSalesInvoice(string strDeComID, string mstrRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger, double dblTotalAmnt,
        //                          double dblNetAmount, double dblAddAmount, double dblLessAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirSalesInv, long mlngIsChqueCash, string strNarrations,
        //                          string strBranchId, string vstrGodownName, long lngIsMultiCurrency, string strSalesRep, string DGSalesGrid, string DGVector, string DGBillWise, string DGsalesOrder, string DGAddless,
        //                          bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, string strOrderNo, string strOrderDate, string strPreparedby, string strPreparedDate, double dblProcessAmount, double dblRoundOff)
        //{
        //    return new JaInventory().mUpdateSalesInvoice(strDeComID, mstrRefNo, strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName, strSalesLedger, dblTotalAmnt,
        //                                                  dblNetAmount, dblAddAmount, dblLessAmount, strRefType, lngAgstRef, mlngIsInvEffinDirSalesInv, mlngIsChqueCash, strNarrations,
        //                                                  strBranchId, vstrGodownName, lngIsMultiCurrency, strSalesRep, DGSalesGrid, DGVector, DGBillWise, DGsalesOrder, DGAddless,
        //                                                  blnMultiCurr, mdblCurrRate, mstrFCsymbol, strOrderNo, strOrderDate, strPreparedby, strPreparedDate, dblProcessAmount, dblRoundOff);
        //}
        public string mSavePurchaseInvoice(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger, double dblTotalAmnt,
                                 double dblNetAmount, double dblAddAmount, double dblLessAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirPurcInv, long mlngIsChqueCash, string strNarrations,
                                 string strBranchId, string vstrGodownName, long lngIsMultiCurrency, string strSalesRep, string DGSalesGrid, string DGVector, string DGBillWise, string DGAddLess, string DGsalesOrder,
                                 bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool blngNumberMethod)
        {
            return new JaInventory().mSavePurchaseInvoice(strDeComID, strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName, strSalesLedger, dblTotalAmnt,
                                                     dblNetAmount, dblAddAmount, dblLessAmount, strRefType, lngAgstRef, mlngIsInvEffinDirPurcInv, mlngIsChqueCash, strNarrations,
                                                     strBranchId, vstrGodownName, lngIsMultiCurrency, strSalesRep, DGSalesGrid, DGVector, DGBillWise, DGAddLess, DGsalesOrder,
                                                     blnMultiCurr, mdblCurrRate, mstrFCsymbol, blngNumberMethod);
        }


        public string mUpdatePurchaseInvoice(string strDeComID, string mstrRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger, double dblTotalAmnt,
                                     double dblNetAmount, double dblAddAmount, double dblLessAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirPurcInv, long mlngIsChqueCash, string strNarrations,
                                     string strBranchId, string vstrGodownName, long lngIsMultiCurrency, string strSalesRep, string DGSalesGrid, string DGVector, string DGBillWise, string DGAddLess, string DGsalesOrder,
                                     bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol)
        {
            return new JaInventory().mUpdatePurchaseInvoice(strDeComID, mstrRefNo, strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName, strSalesLedger, dblTotalAmnt,
                                                      dblNetAmount, dblAddAmount, dblLessAmount, strRefType, lngAgstRef, mlngIsInvEffinDirPurcInv, mlngIsChqueCash, strNarrations,
                                                      strBranchId, vstrGodownName, lngIsMultiCurrency, strSalesRep, DGSalesGrid, DGVector, DGBillWise, DGAddLess, DGsalesOrder,
                                                      blnMultiCurr, mdblCurrRate, mstrFCsymbol);
        }

        public string mSaveSalesReturn(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger,
                                    double dblNetAmount, double dblTotalAmount, double dblAddAmount, double dblLessAmount, string strRefType,
                                    long lngAgstRef, long mlngIsInvEffinDirSalesInv, string strNarrations,
                                    string strBranchId, string vstrGodownName, long mlngCashFlow, long mlngIsChqueCash, string DGSalesGrid,
                                    string DGsalesOrder, string DGVector, string DGBillWise, string DGAddLess, bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool blngNumberMethod, string strSalesRep)
        {
            return new JaInventory().mSaveSalesReturn(strDeComID, strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName, strSalesLedger,
                                                          dblNetAmount, dblTotalAmount, dblAddAmount, dblLessAmount, strRefType,
                                                          lngAgstRef, mlngIsInvEffinDirSalesInv, strNarrations,
                                                          strBranchId, vstrGodownName, mlngCashFlow, mlngIsChqueCash, DGSalesGrid,
                                                          DGsalesOrder, DGVector, DGBillWise, DGAddLess, blnMultiCurr, mdblCurrRate, mstrFCsymbol, blngNumberMethod, strSalesRep);
        }

        public string mUpdateSalesReturn(string strDeComID, string mstrRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger,
                                    double dblNetAmount, double dblTotalAmount, double dblAddAmount, double dblLessAmount, string strRefType,
                                    long lngAgstRef, long mlngIsInvEffinDirSalesInv, string strNarrations,
                                    string strBranchId, string vstrGodownName, long mlngCashFlow, long mlngIsChqueCash, string DGSalesGrid,
                                    string DGsalesOrder, string DGVector, string DGBillWise, string DGAddLess, bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, string strSalesRep)
        {
            return new JaInventory().mUpdateSalesReturn(strDeComID, mstrRefNo, strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName, strSalesLedger,
                                                          dblNetAmount, dblTotalAmount, dblAddAmount, dblLessAmount, strRefType,
                                                          lngAgstRef, mlngIsInvEffinDirSalesInv, strNarrations,
                                                          strBranchId, vstrGodownName, mlngCashFlow, mlngIsChqueCash, DGSalesGrid,
                                                          DGsalesOrder, DGVector, DGBillWise, DGAddLess, blnMultiCurr, mdblCurrRate, mstrFCsymbol, strSalesRep);
        }



        // public List<ManuProcess> mDisplayMFGVoucher(string strDeComID, string strRefNo)
        //{
        //    return new JaInventory().mDisplayMFGVoucher(strDeComID,strRefNo);
        //}

        //public List<MFGvouhcer> mDisplayRMVoucher(string strDeComID, string strRefNo)
        //{
        //    return new JaInventory().mDisplayRMVoucher(strDeComID, strRefNo);
        //}

        // public List<MFGvouhcer> mDisplayDmVoucher(string strDeComID, string strRefNo)
        //{
        //    return new JaInventory().mDisplayDmVoucher(strDeComID,strRefNo);
        //}

        // public List<MFGvouhcer> mDisplayFgVoucher(string strDeComID, string strRefNo)
        //{
        //    return new JaInventory().mDisplayFgVoucher(strDeComID,strRefNo);
        //}
        // public string mUpdateMFGvoucher(string strDeComID, string strOldInvLog, string strOldRm, string strOldWm, string stroldFm, string strInvLog,
        //                                  string strBranchIdFrom, string strBranchIdTo, string strGodown,string strGodownto, string strProcess,
        //                                  string strDate, string strNarrations, double mdblAmount,
        //                                  string Dgfg, string DgRm, string Dgwastage, int actionmode, bool mblnNumbMethod,int intconvertType)
        //{
        //    return new JaInventory().mUpdateMFGvoucher(strDeComID,strOldInvLog, strOldRm, strOldWm, stroldFm, strInvLog,
        //                                               strBranchIdFrom, strBranchIdTo, strGodown,strGodownto, strProcess,
        //                                               strDate, strNarrations, mdblAmount,
        //                                               Dgfg, DgRm, Dgwastage, actionmode, mblnNumbMethod, intconvertType);
        //}

        public string mSaveSalesQuotation(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                      double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency,
                                      string strAttention, string strDesignation, string strAdrress,
                                      string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                      bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool mblnNumbMethod)
        {
            return new JaInventory().mSaveSalesQuotation(strDeComID, strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName,
                                                       dblNetAmount, strNarrations, strBranchId, strGodownName, lngIsMultiCurrency,
                                                       strAttention, strDesignation, strAdrress,
                                                       strDelivery, strPayment, strSupport, dteValidaty, strOtherTerms, DG,
                                                       blnMultiCurr, mdblCurrRate, mstrFCsymbol, mblnNumbMethod);
        }


        public string mUpdateeSalesQuotation(string strDeComID, string strOldRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                        double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency,
                                        string strAttention, string strDesignation, string strAdrress,
                                        string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                        bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool mblnNumbMethod)
        {
            return new JaInventory().mUpdateeSalesQuotation(strDeComID, strOldRefNo, strRefNo, mlngVType, strDate, strDueDate, strMonthID, strLedgerName,
                                                         dblNetAmount, strNarrations, strBranchId, strGodownName, lngIsMultiCurrency,
                                                         strAttention, strDesignation, strAdrress,
                                                         strDelivery, strPayment, strSupport, dteValidaty, strOtherTerms, DG,
                                                         blnMultiCurr, mdblCurrRate, mstrFCsymbol, mblnNumbMethod);
        }



        public string mSavebatch(string strDeComID, string strLogNo, string strStartDate, string strEndDate, string strExpireDate, string strLedgerName, string strstatus,
                                string strNarrations, string strBatchSize, string strManuDate)
        {
            return new JaInventory().mSavebatch(strDeComID, strLogNo, strStartDate, strEndDate, strExpireDate, strLedgerName, strstatus,
                                           strNarrations, strBatchSize, strManuDate);
        }

        public string mSUpdatebatch(string strDeComID, string msstrOldNo, string strLogNo, string strStartDate, string strEndDate, string strExpireDate, string strLedgerName, string strstatus,
                               string strNarrations, string strBatchSize, string strManuDate)
        {
            return new JaInventory().mSUpdatebatch(strDeComID, msstrOldNo, strLogNo, strStartDate, strEndDate, strExpireDate, strLedgerName, strstatus,
                                          strNarrations, strBatchSize, strManuDate);
        }
        public List<Batch> mDisPlaybatch(string strDeComID, long lngslNo, string Pyear = "")
        {
            return new JaInventory().mDisPlaybatch(strDeComID, lngslNo, Pyear);
        }

        public List<DatabaseCompany> mloadDatabaseCompnay(string strDeComID)
        {
            return new JaInventory().mloadDatabaseCompnay(strDeComID);
        }

        public List<StockCategory> mDisplayCategoryRecordOthers(string strDeComID, long vstrPrimaryKey)
        {
            return new JaInventory().mDisplayCategoryRecordOthers(strDeComID, vstrPrimaryKey);
        }
        //public List<StockCategory> mLoadStockCategoryOthers()
        //{
        //    return new JaInventory().mLoadStockCategoryOthers();
        //}
        public Dictionary<string, string> mLoadStockCategoryOthers(string strDeComID)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("Primary", "Primary");
            foreach (StockCategory ogrp in new JaInventory().mLoadStockCategoryOthers(strDeComID))
            {
                ooGrp.Add(ogrp.CategoryName, ogrp.CategoryName);
            }
            return ooGrp;
        }
        public List<StockCategory> mFillStockCategoryOthers(string strDeComID)
        {
            return new JaInventory().mFillStockCategoryOthers(strDeComID);
        }
        public string mInsertOtherscategory(string strDeComID, string vstrName, string vstrUnder)
        {
            return new JaInventory().mInsertOtherscategory(strDeComID, vstrName, vstrUnder);
        }
        public string mUpdateOtherscategory(string strDeComID, long mstrPrimaryKey, string vstrName, string vstrUnder)
        {
            return new JaInventory().mUpdateOtherscategory(strDeComID, mstrPrimaryKey, vstrName, vstrUnder);
        }
        public string mDeletcategoryOthers(string strDeComID, long strSerialfNo)
        {
            return new JaInventory().mDeletcategoryOthers(strDeComID, strSerialfNo);
        }

        public List<StockGroup> mFillStockGroupconfig(string strDeComID)
        {
            return new JaInventory().mFillStockGroupconfig(strDeComID);
        }
        public string mInsertStockGroupNew(string strDeComID, string vstrName)
        {
            return new JaInventory().mInsertStockGroupNew(strDeComID, vstrName);
        }

        public string mUpdateStockGroupNew(string strDeComID, string mstrPrimaryKey, string vstrName)
        {
            return new JaInventory().mUpdateStockGroupNew(strDeComID, mstrPrimaryKey, vstrName);
        }

        public string mDeleteStockGroupNew(string strDeComID, string mstrPrimaryKey)
        {
            return new JaInventory().mDeleteStockGroupNew(strDeComID, mstrPrimaryKey);
        }

        public List<CommissionConfig> mFillCommissionconfig(string strDeComID)
        {
            return new JaInventory().mFillCommissionconfig(strDeComID);
        }

        public string mInsertCommission(string strDeComID, string strCommKey, string vstrBranchID, string vstrGropConfig, string strEffectiveDate, int intstatus, string strGrid)
        {
            return new JaInventory().mInsertCommission(strDeComID, strCommKey, vstrBranchID, vstrGropConfig, strEffectiveDate, intstatus, strGrid);
        }


        public string mUpdateCommisssion(string strDeComID, string strOldCommKey, string strCommKey, string vstrBranchID, string vstrGropConfig, string strEffectiveDate, int intstatus, string strGrid)
        {
            return new JaInventory().mUpdateCommisssion(strDeComID, strOldCommKey, strCommKey, vstrBranchID, vstrGropConfig, strEffectiveDate, intstatus, strGrid);
        }
        public string mDeleteCommission(string strDeComID, string mstrPrimaryKey)
        {
            return new JaInventory().mDeleteCommission(strDeComID, mstrPrimaryKey);
        }
        public List<CommissionConfig> mDisplayCommissionconfig(string strDeComID, string masterKey)
        {
            return new JaInventory().mDisplayCommissionconfig(strDeComID, masterKey);
        }

        public List<Section> mFillSection(string strDeComID)
        {
            return new JaInventory().mFillSection(strDeComID);
        }

        public string mInsertSection(string strDeComID, string strSectionName)
        {
            return new JaInventory().mInsertSection(strDeComID, strSectionName);
        }
        public string mUpdateSection(string strDeComID, string stroldSectionName, string strSectionName)
        {
            return new JaInventory().mUpdateSection(strDeComID, stroldSectionName, strSectionName);
        }
        public string mDeleteSection(string strDeComID, string mstrPrimaryKey)
        {
            return new JaInventory().mDeleteSection(strDeComID, mstrPrimaryKey);
        }

        public List<MaterialType> mFillMaterialType(string strDeComID)
        {
            return new JaInventory().mFillMaterialType(strDeComID);
        }

        public string mInsertMaterialType(string strDeComID, string strSectionName)
        {
            return new JaInventory().mInsertMaterialType(strDeComID, strSectionName);
        }
        public string mUpdateMaterialType(string strDeComID, string stroldName, string strMaterialTypeName)
        {
            return new JaInventory().mUpdateMaterialType(strDeComID, stroldName, strMaterialTypeName);
        }
        public string mDeleteMaterialType(string strDeComID, string mstrPrimaryKey)
        {
            return new JaInventory().mDeleteMaterialType(strDeComID, mstrPrimaryKey);
        }
        public Dictionary<string, string> mFillSectionNew(string strDeComID)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("End of List", "End of List");
            foreach (Section ogrp in new JaInventory().mFillSection(strDeComID))
            {
                ooGrp.Add(ogrp.strSection, ogrp.strSection);
            }
            return ooGrp;
        }

        public string mSaveStockOutWard(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                       double dblNetAmount, string strNarrations,
                                       string strBranchId, string vstrGodownName, string vstrBatchNo,
                                       string vstrCostOption, string vstrProcess, string DGSalesGrid, bool blngNumberMethod,
                                      string strFGItem, double dblFgQty, double dblFGRate, string vstrFgLocation, string vstrUOM)
        {
            return new JaInventory().mSaveStockOutWard(strDeComID, strRefNo, mlngVType, strDate,
                                                       dblNetAmount, strNarrations,
                                                       strBranchId, vstrGodownName, vstrBatchNo,
                                                       vstrCostOption, vstrProcess, DGSalesGrid, blngNumberMethod, 
                                                       strFGItem, dblFgQty, dblFGRate, vstrFgLocation, vstrUOM);
        }
        public string mUpdateStockOutWard(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName, string vstrBatchNo,
                                        string vstrCostOption, string vstrProcess, string DGSalesGrid,
                                        string strFGItem, double dblFgQty, double dblFGRate, string vstrFgLocation, string vstrUOM)
        {
            return new JaInventory().mUpdateStockOutWard(strDeComID, strRefNo, mlngVType, strDate,
                                                       dblNetAmount, strNarrations,
                                                       strBranchId, vstrGodownName, vstrBatchNo,
                                                       vstrCostOption, vstrProcess, DGSalesGrid, strFGItem,  
                                                       dblFgQty,  dblFGRate,  vstrFgLocation,  vstrUOM);
        }

        public string mSaveStockInWard(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName, string vstrBatchNo,
                                        string vstrCostOption, string vstrProcess, string DGSalesGrid)
        {
            return new JaInventory().mSaveStockInWard(strDeComID, strRefNo, mlngVType, strDate,
                                                       dblNetAmount, strNarrations,
                                                       strBranchId, vstrGodownName, vstrBatchNo,
                                                       vstrCostOption, vstrProcess, DGSalesGrid);
        }
        public string mUpdateStockInWard(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName, string vstrBatchNo,
                                        string vstrCostOption, string vstrProcess, string DGSalesGrid)
        {
            return new JaInventory().mUpdateStockInWard(strDeComID, strRefNo, mlngVType, strDate,
                                                       dblNetAmount, strNarrations,
                                                       strBranchId, vstrGodownName, vstrBatchNo,
                                                       vstrCostOption, vstrProcess, DGSalesGrid);
        }

        public List<MFGvouhcer> mDisplayInOutMaster(string strDeComID, string vstrStockSerial, int intvType, string strFind, string strExpression, string strFdate, string strTodate, string strStockItemName)
        {
            return new JaInventory().mDisplayInOutMaster(strDeComID, vstrStockSerial, intvType, strFind, strExpression, strFdate, strTodate, strStockItemName);
        }

        public List<MFGvouhcer> mDisplayInoutTran(string strDeComID, string vstrStockSerial)
        {

            return new JaInventory().mDisplayInoutTran(strDeComID, vstrStockSerial);
        }
        public string mDeleteStockConum(string strDeComID, string strRefNo)
        {
            return new JaInventory().mDeleteStockConum(strDeComID, strRefNo);
        }

        public string mSaveStockDamage(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName, string DGSalesGrid, bool blngNumberMethod)
        {
            return new JaInventory().mSaveStockDamage(strDeComID, strRefNo, mlngVType, strDate,
                                                     dblNetAmount, strNarrations,
                                                     strBranchId, vstrGodownName, DGSalesGrid, blngNumberMethod);
        }



        public string mUpdateDamage(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName,
                                        string DGSalesGrid)
        {
            return new JaInventory().mUpdateDamage(strDeComID, strRefNo, mlngVType, strDate,
                                                    dblNetAmount, strNarrations,
                                                    strBranchId, vstrGodownName, DGSalesGrid);
        }

        public string mSavePhysicalStock(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName, string DGSalesGrid, bool blngNumberMethod)
        {
            return new JaInventory().mSavePhysicalStock(strDeComID, strRefNo, mlngVType, strDate,
                                                   dblNetAmount, strNarrations,
                                                   strBranchId, vstrGodownName, DGSalesGrid, blngNumberMethod);
        }


        public string mUpdatePhysicalStock(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                         double dblNetAmount, string strNarrations,
                                         string strBranchId, string vstrGodownName, string DGSalesGrid)
        {
            return new JaInventory().mUpdatePhysicalStock(strDeComID, strRefNo, mlngVType, strDate,
                                                           dblNetAmount, strNarrations,
                                                           strBranchId, vstrGodownName, DGSalesGrid);
        }
        public List<StockItem> mFillDamaPhy(string strDeComID, int mlngVType, string strFind, string strExpression, string strFdate, string strTodate)
        {
            return new JaInventory().mFillDamaPhy(strDeComID, mlngVType, strFind, strExpression, strFdate, strTodate);
        }
        public List<StockItem> mFillDisplayPhyMaster(string strDeComID, string vstrRefNo)
        {
            return new JaInventory().mFillDisplayPhyMaster(strDeComID, vstrRefNo);
        }
        public List<StockItem> mFillDisplayPhysicalStock(string strDeComID, string vstrStockSerial)
        {
            return new JaInventory().mFillDisplayPhysicalStock(strDeComID, vstrStockSerial);
        }

        public List<StockItem> mFillDisplayStockDamage(string strDeComID, string vstrStockSerial, int intvtype)
        {
            return new JaInventory().mFillDisplayStockDamage(strDeComID, vstrStockSerial, intvtype);
        }
        public string mDeleteProductionList(string strDeComID, string strRefNo)
        {
            return new JaInventory().mDeleteProductionList(strDeComID, strRefNo);
        }
        //public string mSaveStockTransfer(string strDeComID, string strRefNo, long mlngVType, string strDate,
        //                                double dblNetAmount, string strNarrations, string strBranchID,
        //                                string strFromBranchName, string strToBranchName, string DGSalesGrid, bool blngNumberMethod,string vstrProcess)
        //{
        //    return new JaInventory().mSaveStockTransfer(strDeComID,strRefNo,  mlngVType,  strDate,
        //                                 dblNetAmount,  strNarrations,  strBranchID,
        //                                 strFromBranchName, strToBranchName, DGSalesGrid, blngNumberMethod,vstrProcess);
        //}


        //public string mUpdateStockTransfer(string strDeComID, string strRefNo, long mlngVType, string strDate,
        //                                double dblNetAmount, string strNarrations, string strBranchID,
        //                                string strFromBranchName, string strToBranchName, string DGSalesGrid, string vstrProcess)
        //{
        //    return new JaInventory().mUpdateStockTransfer(strDeComID,strRefNo, mlngVType, strDate,
        //                                                    dblNetAmount, strNarrations, strBranchID,
        //                                                    strFromBranchName, strToBranchName, DGSalesGrid, vstrProcess);
        //}


        //public string mDeleteStockTransfer(string strDeComID, string strRefNo)
        //{
        //    return new JaInventory().mDeleteStockTransfer(strDeComID,strRefNo);
        //}
        //public List<StockItem> mFillStockTransfer(string strDeComID, int mlngVType, string strFind, string strExpression, string strFdate, string strTodate)
        //{
        //    return new JaInventory().mFillStockTransfer(strDeComID, mlngVType,  strFind,  strExpression,  strFdate,  strTodate);
        //}
        //public List<StockItem> mFillDisplayStockTransfer(string strDeComID, string vstrStockSerial)
        //{
        //    return new JaInventory().mFillDisplayStockTransfer(strDeComID,vstrStockSerial);
        //}

        public List<Transport> mFillTransport(string strDeComID)
        {
            return new JaInventory().mFillTransport(strDeComID);
        }
        public string mInsertTransport(string strDeComID, string strTransportName)
        {
            return new JaInventory().mInsertTransport(strDeComID, strTransportName);
        }
        public string mUpdateTransport(string strDeComID, string stroldName, string strTransportName)
        {
            return new JaInventory().mUpdateTransport(strDeComID, stroldName, strTransportName);
        }

        public string mDeleteTransport(string strDeComID, string mstrPrimaryKey)
        {
            return new JaInventory().mDeleteTransport(strDeComID, mstrPrimaryKey);
        }

        public List<Designation> mFillDesignation(string strDeComID)
        {
            return new JaInventory().mFillDesignation(strDeComID);
        }

        public string mInsertDesignation(string strDeComID, string strDesignationName)
        {
            return new JaInventory().mInsertDesignation(strDeComID, strDesignationName);
        }
        public string mUpdateDesignation(string strDeComID, string stroldName, string strDesiName)
        {
            return new JaInventory().mUpdateDesignation(strDeComID, stroldName, strDesiName);
        }
        public string mDeleteDesignation(string strDeComID, string mstrPrimaryKey)
        {
            return new JaInventory().mDeleteDesignation(strDeComID, mstrPrimaryKey);
        }

        public List<SampleClass> mFillSampleClass(string strDeComID)
        {
            return new JaInventory().mFillSampleClass(strDeComID);
        }

        public string mInsertSampleClass(string strDeComID, string strSampleClass, string DG)
        {
            return new JaInventory().mInsertSampleClass(strDeComID, strSampleClass, DG);
        }
        public string mUpdateSampleClass(string strDeComID, string strOldSample, string strSampleClass, string DG)
        {
            return new JaInventory().mUpdateSampleClass(strDeComID, strOldSample, strSampleClass, DG);
        }
        public string mDeleteSampleClass(string strDeComID, string mstrPrimaryKey)
        {
            return new JaInventory().mDeleteSampleClass(strDeComID, mstrPrimaryKey);
        }
        public List<SampleClass> mDisplaySampleClass(string strDeComID, string mstKey)
        {
            return new JaInventory().mDisplaySampleClass(strDeComID, mstKey);
        }
        public string mInsertTarget(string strDeComID, string strInsert, string strKey, string strLedgerName, string strFromDate, string strTodate, string strbranchID, string strFormName, string DG, string strPrifix)
        {
            return new JaInventory().mInsertTarget(strDeComID, strInsert, strKey, strLedgerName, strFromDate, strTodate, strbranchID, strFormName, DG, strPrifix);
        }
        public List<SalesTarget> mFillSalesTarget(string strDeComID)
        {
            return new JaInventory().mFillSalesTarget(strDeComID);
        }

        public List<SalesTarget> mFillSalesCollection(string strDeComID)
        {
            return new JaInventory().mFillSalesCollection(strDeComID);
        }
        public List<SalesTarget> mDisplayTarget(string strDeComID, string strKey)
        {
            return new JaInventory().mDisplayTarget(strDeComID, strKey);
        }
        public string mUpdateTarget(string strDeComID, string strKey, string strLedgerName, string strFromDate, string strTodate, string strbranchID, string strFormName, string DG)
        {
            return new JaInventory().mUpdateTarget(strDeComID, strKey, strLedgerName, strFromDate, strTodate, strbranchID, strFormName, DG);
        }
        public string mDeleteTarget(string strDeComID, string strKey, string strFormName)
        {
            return new JaInventory().mDeleteTarget(strDeComID, strKey, strFormName);
        }
        public List<SalesTarget> mFillSalesCreditLimit(string strDeComID)
        {
            return new JaInventory().mFillSalesCreditLimit(strDeComID);
        }
        public List<SalesTarget> mDisplaySalesCollection(string strDeComID, string strKey, string strLedgerName)
        {
            return new JaInventory().mDisplaySalesCollection(strDeComID, strKey, strLedgerName);
        }
        public List<SalesTarget> mDisplayCreditLimit(string strDeComID, string strKey, string strLedgerName)
        {
            return new JaInventory().mDisplayCreditLimit(strDeComID, strKey, strLedgerName);
        }

        public List<Sample> mFillSample(string strDeComID, string strPrefix)
        {
            return new JaInventory().mFillSample(strDeComID, strPrefix);
        }
        public string mInsertSample(string strDeComID, long mlngVType, string strBranchId, string strRefNo, string strDate, string strMonthID, string strLedgerName,
                                       string strDueDate, double dblNetAmount, string strLocation, string strCustomer, string strNarrations, string DG, bool mblnNumbMethod)
        {
            return new JaInventory().mInsertSample(strDeComID, mlngVType, strBranchId, strRefNo, strDate, strMonthID, strLedgerName,
                                        strDueDate, dblNetAmount, strLocation, strCustomer, strNarrations, DG, mblnNumbMethod);
        }

        public string mUpdateSample(string strDeComID, string strOldRefNo, long mlngVType, string strBranchId, string strRefNo, string strDate, string strMonthID, string strLedgerName,
                                       string strDueDate, double dblNetAmount, string strLocation, string strCustomer, string strNarrations, string DG)
        {
            return new JaInventory().mUpdateSample(strDeComID, strOldRefNo, mlngVType, strBranchId, strRefNo, strDate, strMonthID, strLedgerName,
                                        strDueDate, dblNetAmount, strLocation, strCustomer, strNarrations, DG);
        }

        public string mDeleteSample(string strDeComID, string strOldRefNo)
        {
            return new JaInventory().mDeleteSample(strDeComID, strOldRefNo);
        }

        public List<Sample> mDisplaySampleList(string strDeComID, string mstrPrimarykey)
        {
            return new JaInventory().mDisplaySampleList(strDeComID, mstrPrimarykey);
        }
        public List<Sample> mDisplaySampleItem(string strDeComID, string mstrPrimarykey)
        {
            return new JaInventory().mDisplaySampleItem(strDeComID, mstrPrimarykey);
        }
        public List<Sample> GetSampleList(string strDeComID, int intvtype, string strFdate, string strTdate, string strFind, string strExpression, string strMySQl)
        {
            return new JaInventory().GetSampleList(strDeComID, intvtype, strFdate, strTdate, strFind, strExpression, strMySQl);
        }
        public List<StockItem> mloadStockItemNotInGroup(string strDeComID, string vstrRoot)
        {
            return new JaInventory().mloadStockItemNotInGroup(strDeComID, vstrRoot);
        }

        public List<StockGroup> mFillStockGroupconfigNew(string strDeComID, string strName)
        {
            return new JaInventory().mFillStockGroupconfigNew(strDeComID, strName);
        }

        public List<StockGroup> mFillPackSizeNew(string strDeComID, string strName)
        {
            return new JaInventory().mFillPackSizeNew(strDeComID, strName);
        }
        public List<StockItem> mloadAddStockItemRMPack(string strDeComID, string strRawLocation, string strGroupName, string strFGYN)
        {
            return new JaInventory().mloadAddStockItemRMPack(strDeComID, strRawLocation, strGroupName, strFGYN);
        }
        public List<StockItem> mloadAddStockItemFg(string strDeComID, string strLocation)
        {
            return new JaInventory().mloadAddStockItemFg(strDeComID, strLocation);
        }
        public string mUpdateOption(string strDeComID, int intNegetive)
        {
            return new JaInventory().mUpdateOption(strDeComID, intNegetive);
        }
        public List<ManuProcess> mLoadFgProcessFG(string strDeComID, string Pyear)
        {
            return new JaInventory().mLoadFgProcessFG(strDeComID, Pyear);
        }
        public double gFillStockItemPhysical(string strDeComID, string vstrGodown, string strItemName)
        {
            return new JaInventory().gFillStockItemPhysical(strDeComID, vstrGodown, strItemName);
        }
        public List<StockItem> mFillStockTreeGroupLevel2(string strDeComID)
        {
            return new JaInventory().mFillStockTreeGroupLevel2(strDeComID);
        }
    }
}
