using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Modulecontrolar.UI.DReport.Sales
{
    public enum ViewerSelector
    {
        MpoList,PartyWiseS, rptMpoListLedgerWAll, allMpoSalesStatement, SalesStatementMPO, SalesStatementFM, SalesStatementRSM, SalesStatementZone, 
        SalesStatementIndividual, LevelWise, ItemwiseSales, StockGroupSales, DesignationCategory,ProductSalesAll, ProductSalesAllFM, ProductSalesAllRSM, 
        ProductSalesAllZone, ProductSalesIndividual, PartyWiseProductSalesAll,
        ProductShortSumm, ProductShortDetails, SalesTargetStatement, TargetSalesStatementYearly, SalesStatementIndividualF, SalesStatementPackSize, SalesInvoice,
        StatisticalProductSales, PartyWiseProductWise, PartyWiseProductWise2, SalesChalan, ChalanPending, ProductSalesAmountProduct, ProductSalesAmount,
        mGetSpcialProduct12MonthSales, SpcialProduct, SpcialProductPackSizeWise, individualSample, Target, ProductSalesAllFMSummary, ProductSalesAllRSMSummary, ProductSalesAllZONESummary,
        ProductSalesAllMPOSummary, MpoProductWiseSalesStatementQty, BKash, ProductSales12MonthQty,
        SalesCollectonperformance, SalesOrder, CPSPSalescollPer, CollectionStatementZone,
        CollectionStatementRSM, CollectionStatementMPO, CollectionStatementFM, allMpoCollectionStatement,
        CollectionStatementIndividualF, TCSalesCollection, rptDailyCollectionRV, Pendingorder
    }
}
