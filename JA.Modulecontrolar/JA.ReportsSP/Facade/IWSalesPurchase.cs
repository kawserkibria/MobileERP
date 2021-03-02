using JA.ReportsSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JA.ReportsSP.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWSalesPurchase" in both code and config file together.
    [ServiceContract]
    //[ServiceKnownType(typeof(RProductSales))]
    public interface IWSalesPurchase
    {
        [OperationContract]
        List<RPSalesCollectionPerformance> mGetCPSPCollectionPerformanceRepYear(string strDeComID, string strPDeComID, string strPFdate, string strPTDate, string strFate, string strTDate, string strBranchID, string strGroupName,
                                                                    int intMode, int intOrderby, string vstrUserName);
        [OperationContract]
        string gOpenComID(string strID);
        #region Sales
        [OperationContract]
        List<RProductSales> mGetSpcialProduct12MonthSales(string strDeComID, string strFdate, string strTdate, int intMonth, string strGroupName, string strPartyName, string strProductSelection, int intstatus, int intMode);
        [OperationContract]
        List<RProductSales> mGetSpcialProductPackSiseWise(string strDeComID, string strFdate, string strTdate, string PreMonth, string strGroupName, string strPartyName, string strProductSelection, int intstatus, int intMode);
        [OperationContract]
        List<RProductSales> mGetSpcialProduct(string strDeComID, string strFdate, string strTdate, string PreMonth, string strGroupName, string strPartyName, string strProductSelection, int intstatus, int intMode);
        [OperationContract]
        List<RProductSales> mGetSpecialProductLoad(string strDeComID, int intmode);
        [OperationContract]
        List<RProductSales> mGetPartyProductSalesAmount(string strDeComID, string strFDate, string strTDate, string strString, string strledgerName, int intmode, string strCustomerName);
        //[OperationContract]
        //List<RProductSales> mGetPartyAmount(string strDeComID, string strFDate, string strTDate, string strString, string strledgerName, int intmode, string strCustomerName);
        [OperationContract]
        List<RProductSales> mGetPartyLoad(string strDeComID, string strString, string strledgerName, int intmode);
        [OperationContract]
        List<RProductSales> mGetSpecialPartyGroup(string strDeComID);
        [OperationContract]
        List<RSalesPurchase> mGetTargetSalesStatementYearly(string strDeComID, string strBranchId, string strString);
        //[OperationContract]
        //List<RSalesPurchase> mGetVoucherSalesChalan(string strDeComID, int intvtype,string strFDate, string strTDate, string strLedgername, string strBranchId, int intMode);
        [OperationContract]
        List<RSalesPurchase> mGetChalanPending(string strDeComID, string strFdate, string strTDate, string strString, int intmode);
        [OperationContract]
        List<RSalesPurchase> mGetSalesChalan(string strDeComID, string strFdate, string strTDate, string strBranchId, string strString, int intmode);
        //[OperationContract]
        //List<RProductSales> mGetPartyWiseS(string strDeComID, string strFdate, string strTDate, string strString, string strSelction, bool blngAccessControl, string strUserName);

        [OperationContract]
        List<RSalesPurchase> mGetMpoListNew(string strDeComID, string strFdate, string strTDate, string strBranchId, string strStrtring, int intmode);
        [OperationContract]
        List<RSalesPurchase> mGetSalesStatement(string strDeComID, string strFdate, string strTDate, string strBranchId, string strStrtring,
                                    int intAscDese, bool blngAccessControl, string strUserName, double dblValue, string strValOption, string strReportOption, int intStatus);

        [OperationContract]
        List<RSalesPurchase> mGetSalesStatementIndividual(string strDeComID, string strFdate, string strTDate, string strBranchId, string strLedgername);
        [OperationContract]
        List<RSalesPurchase> mGetItemWiseSales(string strDeComID, string strFdate, string strTDate, string strItemName, int intItemGroup);
        //[OperationContract]
        //List<RProductSales> mGetDesignationCategory(string strDeComID, string strFdate, string strTDate, string strBranchId, string strString, int intMode, bool blngAccessControl, string strUserName);
        //[OperationContract]
        //List<RSalesPurchase> mGetProductsales(string strDeComID, string strFdate, string strTdate, string strBranchId, string Strsting, string Strsting2, string strSelction, int intmode, bool blngAccessControl, string strUserName);
        //[OperationContract]
        //List<RProductSales> mGetPartyWiseProductsales(string strDeComID, string strFdate, string strTDate, string strString, string strString2, string strSelction, string strSelction2);
        [OperationContract]
        List<RProductSales> mGetPartyWiseProductsales2(string strDeComID, string strFdate, string strTDate, string strString, string strString2, string strSelction, string strSelction2);
        [OperationContract]
        List<RProductSales> mGetLedgerlistnew(string strDeComID, string strBranchId, string strSelction, int intMode);
        [OperationContract]
        List<RProductSales> mGetProductShortSummary(string strDeComID, string strFdate, string strTDate);
        [OperationContract]
        List<RProductSales> mGetProductShortDetails(string strDeComID, string strFdate, string strTDate, string strStockGroupName, int intmode);
        [OperationContract]
        List<RProductSales> mGetSalesTargetStatement(string strDeComID, string strFdate, string strTDate, string strBranchId, string strLagername);
        [OperationContract]
        List<RProductSales> mGetSalesStatementIndividuall(string strDeComID, string strFdate, string strTDate, string strLagername);

        //[OperationContract]
        //List<RProductSales> mGetSalesStatementPackSize(string strDeComID, string strFdate, string strTDate, string strSelction2, int intMode, bool blngAccessControl, string strUserName);
        [OperationContract]
        List<RProductSales> mGetSalesInvoice(string strDeComID, string strSALESREP);
        //[OperationContract]
        //List<RProductSales> mGetStatisticalProductSales(string strDeComID, string strFdate, string strTDate, string strBranchId, string strString, int intMode, bool blngAccessControl, string strUserName);

        #endregion
        [OperationContract]
        List<RSalesPurchase> mDisplayItemGroup(string strDeComID, string vstrItemGroup, string vstrDate, string vstrTDate, int intMode);
        List<RSalesPurchase> mGetParty_Wise_ItemwiseSumm_All_Indivi_PurInv(string strDeComID, string strFDate, string strTDate, string strLedgername);
        #region Price list
        [OperationContract]
        List<RSalesPurchase> mGetPricelistReport(string strDeComID, string strStockItemName);
        #endregion
        #region Purchase
        [OperationContract]
        List<RProductSales> mGetSalesInvoiceReportPriview(string strDeComID, string strcomRef);
        [OperationContract]
        List<RSalesPurchase> mGetPurchaseRegisterReport(string strDeComID, string strFDate, string strTDate, string strLedgername, string strString2);
        [OperationContract]
        List<RSalesPurchase> mGetSupplierList(string strDeComID, string strFdate, string strTDate, string strString, int intMode, string strString2, string strBranchID);
        [OperationContract]
        List<RSalesPurchase> LEDGERPARENTGROUP(string strDeComID, int intMode);
        [OperationContract]
        List<RSalesPurchase> mGetVoucherReport(string strDeComID, string strFDate, string strTDate, string strLedgername, string strBranchId, int intMode, string selection);
        [OperationContract]
        List<RSalesPurchase> mGetVoucherReportRefNo(string strDeComID, string strRefNo, string strBranchId, int intMode);
        [OperationContract]
        List<RSalesPurchase> mGetVoucherRefNo(string strDeComID, string strFDate, string strTDate, string strSelection, string strBranchId, int intMode);
        [OperationContract]
        List<RSalesPurchase> mGetPayablesReport(string strDeComID, string strFDate, string strTDate, string strLedgername);
        [OperationContract]
        List<RSalesPurchase> mGetVoucherAddless(string strDeComID, string strString, string strBranchId);
        #endregion
        #region "MPO/Product wise Sales Statement (Qty)"
        [OperationContract]
        List<RProductSales> mGetPRoductLoad(string strDeComID, string strFieldforce, string strFdate, string strTDate, int intMode, string strSelection);
        [OperationContract]
        List<RSalesPurchase> mGetMpoGroupLoad(string strDeComID, int intMode, string strString, string strFDate, string strTDate, string vstrUserName);
        //[OperationContract]
        //List<RSalesPurchase> mGetMpoProductSalesStatementQty(string strDeComID, int intMode, string strLedgerGroup,
        //                                                          string strProduct, string strFdate, string strTDate, string strStockGroup,
        //                                                          bool blngAccessControl, string strUserName);
        #endregion
        [OperationContract]
        List<RSalesPurchase> mGetBkash(string strDeComID);
        [OperationContract]
        List<RPSalesCollectionPerformance> mGetSalesCollectionPerformanceRep(string strDeComID, string strFate, string strTDate, string strBranchID, string strGroupName,
                                                                   int intMode, int intOrderby, string gstrUserName, DateTime FirstdayOfMonth, DateTime LasttdayOfMonth, int intDay, int intUpdDay, string vstrUserName);

    }
}
