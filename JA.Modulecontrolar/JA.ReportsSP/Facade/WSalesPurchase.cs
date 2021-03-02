using JA.ReportsSP.DAL;
using JA.ReportsSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JA.ReportsSP.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WSalesPurchase" in both code and config file together.
    public class WSalesPurchase : IWSalesPurchase
    {
        public string gOpenComID(string strID)
        {
            return new SalesPurchase().gOpenComID(strID);
        }

        #region Sales
        public List<RProductSales> mGetSpecialProductLoad(string strDeComID, int intmode)
        {
            return new SalesPurchase().mGetSpecialProductLoad(strDeComID, intmode);
        }
        public List<RProductSales> mGetSpcialProduct12MonthSales(string strDeComID, string strFdate, string strTdate, int intMonth, string strGroupName, string strPartyName, string strProductSelection, int intstatus, int intMode)
        {
            return new SalesPurchase().mGetSpcialProduct12MonthSales(strDeComID, strFdate, strTdate, intMonth, strGroupName, strPartyName, strProductSelection, intstatus, intMode);
        }
        public List<RProductSales> mGetSpcialProductPackSiseWise(string strDeComID, string strFdate, string strTdate, string PreMonth, string strGroupName, string strPartyName, string strProductSelection, int intstatus, int intMode)
        {
            return new SalesPurchase().mGetSpcialProductPackSiseWise(strDeComID, strFdate, strTdate, PreMonth, strGroupName, strPartyName, strProductSelection, intstatus, intMode);
        }
        public List<RProductSales> mGetSpcialProduct(string strDeComID, string strFdate, string strTdate, string PreMonth, string strGroupName, string strPartyName, string strProductSelection, int intstatus, int intMode)
        {
            return new SalesPurchase().mGetSpcialProduct(strDeComID, strFdate, strTdate, PreMonth, strGroupName, strPartyName, strProductSelection, intstatus, intMode);
        }
        public List<RProductSales> mGetPartyProductSalesAmount(string strDeComID, string strFDate, string strTDate, string strString, string strledgerName, int intmode, string strCustomerName)
        {
            return new SalesPurchase().mGetPartyProductSalesAmount(strDeComID, strFDate, strTDate, strString, strledgerName, intmode, strCustomerName);
        }
        //public List<RProductSales> mGetPartyAmount(string strDeComID, string strFDate, string strTDate, string strString, string strledgerName, int intmode, string strCustomerName)
        //{
        //    return new SalesPurchase().mGetPartyAmount(strDeComID, strFDate, strTDate, strString, strledgerName, intmode, strCustomerName);
        //}
        public List<RProductSales> mGetPartyLoad(string strDeComID, string strString, string strledgerName, int intmode)
        {
            return new SalesPurchase().mGetPartyLoad(strDeComID, strString, strledgerName, intmode);
        }
        public List<RProductSales> mGetSpecialPartyGroup(string strDeComID)
        {
            return new SalesPurchase().mGetSpecialPartyGroup(strDeComID);
        }
        public List<RSalesPurchase> mGetTargetSalesStatementYearly(string strDeComID, string strBranchId, string strString)
        {
            return new SalesPurchase().mGetTargetSalesStatementYearly(strDeComID, strBranchId, strString);
        }
        //public List<RSalesPurchase> mGetVoucherSalesChalan(string strDeComID, int intvtype,string strFDate, string strTDate, string strLedgername, string strBranchId, int intMode)
        //{
        //    return new SalesPurchase().mGetVoucherSalesChalan(strDeComID, intvtype,strFDate, strTDate, strLedgername, strBranchId, intMode);
        //}
        public List<RSalesPurchase> mGetChalanPending(string strDeComID, string strFdate, string strTDate, string strString, int intmode)
        {
            return new SalesPurchase().mGetChalanPending(strDeComID, strFdate, strTDate, strString, intmode);
        }
        public List<RSalesPurchase> mGetSalesChalan(string strDeComID, string strFdate, string strTDate, string strBranchId, string strString, int intmode)
        {
            return new SalesPurchase().mGetSalesChalan(strDeComID, strFdate, strTDate, strBranchId, strString, intmode);
        }
        //public List<RProductSales> mGetPartyWiseS(string strDeComID, string strFdate, string strTDate, string strString, string strSelction, bool blngAccessControl, string strUserName)
        //{
        //    return new SalesPurchase().mGetPartyWiseS(strDeComID, strFdate, strTDate, strString, strSelction, blngAccessControl, strUserName);
        //}
        public List<RSalesPurchase> mGetMpoListNew(string strDeComID, string strFdate, string strTDate, string strBranchId, string strStrtring, int intmode)
        {
            return new SalesPurchase().mGetMpoListNew(strDeComID, strFdate, strTDate, strBranchId, strStrtring, intmode);
        }
        public List<RSalesPurchase> mGetSalesStatement(string strDeComID, string strFdate, string strTDate, string strBranchId, string strStrtring, int intAscDese,
                        bool blngAccessControl, string strUserName, double dblValue, string strValOption, string strReportOption, int intStatus)
        {
            return new SalesPurchase().mGetSalesStatement(strDeComID, strFdate, strTDate, strBranchId, strStrtring, intAscDese, blngAccessControl,
                                    strUserName, dblValue, strValOption, strReportOption, intStatus);
        }
        public List<RSalesPurchase> mGetSalesStatementIndividual(string strDeComID, string strFdate, string strTDate, string strBranchId, string strLedgername)
        {
            return new SalesPurchase().mGetSalesStatementIndividual(strDeComID, strFdate, strTDate, strBranchId, strLedgername);
        }
        public List<RSalesPurchase> mGetItemWiseSales(string strDeComID, string strFdate, string strTDate, string strItemName, int intItemGroup)
        {
            return new SalesPurchase().mGetItemWiseSales(strDeComID, strFdate, strTDate, strItemName, intItemGroup);
        }
        //public List<RSalesPurchase> mGetProductsales(string strDeComID, string strFdate, string strTdate, string strBranchId, string Strsting, string Strsting2, string strSelction, int intmode, bool blngAccessControl, string strUserName)
        //{
        //    return new SalesPurchase().mGetProductsales(strDeComID, strFdate, strTdate, strBranchId, Strsting, Strsting2, strSelction, intmode, blngAccessControl,  strUserName);
        //}
        //public List<RProductSales> mGetPartyWiseProductsales(string strDeComID, string strFdate, string strTDate, string strString, string strString2, string strSelction, string strSelction2)
        //{
        //    return new SalesPurchase().mGetPartyWiseProductsales(strDeComID, strFdate, strTDate, strString, strString2, strSelction, strSelction2);
        //}
        public List<RProductSales> mGetPartyWiseProductsales2(string strDeComID, string strFdate, string strTDate, string strString, string strString2, string strSelction, string strSelction2)
        {
            return new SalesPurchase().mGetPartyWiseProductsales2(strDeComID, strFdate, strTDate, strString, strString2, strSelction, strSelction2);
        }
        public List<RProductSales> mGetLedgerlistnew(string strDeComID, string strBranchId, string strSelction, int intMode)
        {
            return new SalesPurchase().mGetLedgerlistnew(strDeComID, strBranchId, strSelction, intMode);
        }
        public List<RProductSales> mGetProductShortSummary(string strDeComID, string strFdate, string strTDate)
        {
            return new SalesPurchase().mGetProductShortSummary(strDeComID, strFdate, strTDate);
        }
        public List<RProductSales> mGetProductShortDetails(string strDeComID, string strFdate, string strTDate, string strStockGroupName, int intmode)
        {
            return new SalesPurchase().mGetProductShortDetails(strDeComID, strFdate, strTDate, strStockGroupName,intmode);
        }
        public List<RProductSales> mGetSalesTargetStatement(string strDeComID, string strFdate, string strTDate, string strBranchId, string strLagername)
        {
            return new SalesPurchase().mGetSalesTargetStatement(strDeComID, strFdate, strTDate, strBranchId, strLagername);
        }
        public List<RProductSales> mGetSalesStatementIndividuall(string strDeComID, string strFdate, string strTDate, string strLagername)
        {
            return new SalesPurchase().mGetSalesStatementIndividuall(strDeComID, strFdate, strTDate, strLagername);
        }
        //public List<RProductSales> mGetSalesStatementPackSize(string strDeComID, string strFdate, string strTDate, string strSelction2, int intMode, bool blngAccessControl, string strUserName)
        //{
        //    return new SalesPurchase().mGetSalesStatementPackSize(strDeComID, strFdate, strTDate, strSelction2, intMode,blngAccessControl, strUserName);
        //}
        public List<RProductSales> mGetSalesInvoice(string strDeComID, string strSALESREP)
        {
          
            return new SalesPurchase().mGetSalesInvoice(strDeComID, strSALESREP);
        }
        //public List<RProductSales> mGetStatisticalProductSales(string strDeComID, string strFdate, string strTDate, string strBranchId, string strString, int intMode, bool blngAccessControl, string strUserName)
        //{
        //    return new SalesPurchase().mGetStatisticalProductSales(strDeComID, strFdate, strTDate, strBranchId, strString,intMode, blngAccessControl, strUserName);
        //}
        #endregion
        public List<RSalesPurchase> mDisplayItemGroup(string strDeComID, string vstrItemGroup, string vstrDate, string vstrTDate, int intMode)
        {
            return new SalesPurchase().mDisplayItemGroup(strDeComID, vstrItemGroup, vstrDate, vstrTDate, intMode);
        }
        public List<RSalesPurchase> mGetParty_Wise_ItemwiseSumm_All_Indivi_PurInv(string strDeComID, string strFDate, string strTDate, string strLedgername)
        {
            return new SalesPurchase().mGetParty_Wise_ItemwiseSumm_All_Indivi_PurInv(strDeComID, strFDate, strTDate, strLedgername);
        }
        //public List<RProductSales> mGetDesignationCategory(string strDeComID, string strFdate, string strTDate, string strBranchId, string strString, int intMode, bool blngAccessControl, string strUserName)
        //{
        //    return new SalesPurchase().mGetDesignationCategory(strDeComID, strFdate, strTDate, strBranchId, strString, intMode, blngAccessControl, strUserName);
        //}
        #region Price List
        public List<RSalesPurchase> mGetPricelistReport(string strDeComID, string strStockItemName)
        {
            return new SalesPurchase().mGetPricelistReport(strDeComID, strStockItemName);
        }
        #endregion
        #region Purchase register
        public List<RProductSales> mGetSalesInvoiceReportPriview(string strDeComID, string strcomRef)
        {
            return new SalesPurchase().mGetSalesInvoiceReportPriview(strDeComID, strcomRef);
        }
        public List<RSalesPurchase> mGetPurchaseRegisterReport(string strDeComID, string strFDate, string strTDate, string strLedgername, string strString2)
        {
            
            return new SalesPurchase().mGetPurchaseRegisterReport(strDeComID, strFDate, strTDate, strLedgername, strString2);
        }
        public List<RSalesPurchase> mGetSupplierList(string strDeComID, string strFdate, string strTDate, string strString, int intMode, string strString2, string strBranchID)
        {
            return new SalesPurchase().mGetSupplierList(strDeComID, strFdate, strTDate, strString, intMode, strString2, strBranchID);
        }
        public List<RSalesPurchase> LEDGERPARENTGROUP(string strDeComID, int intMode)
        {
            return new SalesPurchase().LEDGERPARENTGROUP(strDeComID, intMode);
        }
        public List<RSalesPurchase> mGetVoucherReport(string strDeComID, string strFDate, string strTDate, string strLedgername, string strBranchId, int intMode, string selection)
        {
            return new SalesPurchase().mGetVoucherReport(strDeComID, strFDate, strTDate, strLedgername, strBranchId, intMode, selection);
        }
        public List<RSalesPurchase> mGetVoucherReportRefNo(string strDeComID, string strRefNo, string strBranchId, int intMode)
        {
            return new SalesPurchase().mGetVoucherReportRefNo(strDeComID, strRefNo, strBranchId, intMode);
        }
        public List<RSalesPurchase> mGetVoucherRefNo(string strDeComID, string strFDate, string strTDate, string strSelection, string strBranchId, int intMode)
        {
            return new SalesPurchase().mGetVoucherRefNo(strDeComID, strFDate, strTDate, strSelection, strBranchId, intMode);
        }
        public List<RSalesPurchase> mGetPayablesReport(string strDeComID, string strFDate, string strTDate, string strLedgername)
        {
            return new SalesPurchase().mGetPayablesReport(strDeComID, strFDate, strTDate, strLedgername);
        }
        public List<RSalesPurchase> mGetVoucherAddless(string strDeComID, string strString, string strBranchId)
        {
            return new SalesPurchase().mGetVoucherAddless(strDeComID, strString, strBranchId);
        }
        #endregion
        #region "MPO/Product wise Sales Statement (Qty)"

        public List<RProductSales> mGetPRoductLoad(string strDeComID, string strFieldforce, string strFdate, string strTDate, int intMode, string strSelection)
        {
            return new SalesPurchase().mGetPRoductLoad(strDeComID, strFieldforce, strFdate, strTDate, intMode, strSelection);
        }
        public List<RSalesPurchase> mGetMpoGroupLoad(string strDeComID, int intMode, string strString, string strFDate, string strTDate, string vstrUserName)
        {
            return new SalesPurchase().mGetMpoGroupLoad(strDeComID, intMode, strString, strFDate, strTDate,vstrUserName);
        }
        //public List<RSalesPurchase> mGetMpoProductSalesStatementQty(string strDeComID, int intMode, string strLedgerGroup,
        //                                                           string strProduct, string strFdate, string strTDate, string strStockGroup,
        //                                                           bool blngAccessControl, string strUserName)
        //{
        //    return new SalesPurchase().mGetMpoProductSalesStatementQty(strDeComID, intMode, strLedgerGroup, strProduct,
        //                                                                strFdate, strTDate, strStockGroup, blngAccessControl, strUserName);
        //}
        #endregion

        public List<RSalesPurchase> mGetBkash(string strDeComID)
        {
            return new SalesPurchase().mGetBkash(strDeComID);
        }
        public List<RPSalesCollectionPerformance> mGetSalesCollectionPerformanceRep(string strDeComID, string strFate, string strTDate, string strBranchID, string strGroupName,
                                                                int intMode, int intOrderby, string gstrUserName, DateTime FirstdayOfMonth, DateTime LasttdayOfMonth, int intDay, int intUpdDay, string vstrUserName)
        {
            return new SalesPurchase().mGetSalesCollectionPerformanceRep(strDeComID, strFate, strTDate, strBranchID, strGroupName,
                                                                     intMode, intOrderby, gstrUserName, FirstdayOfMonth, LasttdayOfMonth, intDay, intUpdDay,vstrUserName);
        }
        public List<RPSalesCollectionPerformance> mGetCPSPCollectionPerformanceRepYear(string strDeComID, string strPDeComID, string strPFdate, string strPTDate, string strFate, string strTDate, string strBranchID, string strGroupName,
                                                                    int intMode, int intOrderby, string vstrUserName)
        {
            return new SalesPurchase().mGetCPSPCollectionPerformanceRepYear(strDeComID, strPDeComID, strPFdate, strPTDate, strFate, strTDate, strBranchID, strGroupName,
                                                                           intMode, intOrderby, vstrUserName);
        }
    }
}
