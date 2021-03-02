using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Modulecontrolar.UI.DReport.Inventory
{
    public enum ViewerSelector
    {
        StockInformatiuon, GroupWise, GroupoptionWiseOpn, GroupoptionWiseINW, GroupoptionWiseOUTW, GroupoptionWiseClos, GroupoptionWiseOpnInw, 
        GroupoptionWiseOpnOutw, GroupoptionWiseOpnCls, GroupoptionWiseInwOotw, GroupoptionWiseInwCls, GroupoptionWiseOutwCls, GroupoptionWiseOpnInwOutw, 
        GroupoptionWiseOpnInwCls, GroupoptionWiseOpnOutwCls, GroupoptionWiseInwOutwCls, GroupoptionWiseOpnInwOutwCls, LocationWise, PackSizeWise, ManufacturerWise, 
        storeLedger, storeLedgerIndividual, intventoryVoucher, profitability, profitabilityAllVoucherW,profitabilityAllDueW,profitabilityGroupVouchDate,profitabilityGroupDueW,
        StockinfoItemWiseCls, StockinfoItemWiseInwCls, StockinfoItemWiseInwOutw, StockinfoItemWiseInwOutwCls, StockinfoItemWiseInw, StockinfoItemWiseOpnCls,
        StockinfoItemWiseOpnInw, StockinfoItemWiseOpnInwCls, StockinfoItemWiseOpnInwOutw, StockinfoItemWiseOpnInwOutwCls, StockinfoItemWiseOpnOutw, 
        StockinfoItemWiseOpnOutwCls, StockinfoItemWiseOpn, StockinfoItemWiseOutw, StockinfoItemWiseOutwCls,
        StockinfoCatWiseCls, StockinfoCatWiseInwCls, StockinfoCatWiseInwOutw, StockinfoCatWiseInwOutwCls, StockinfoCatWiseInw, StockinfoCatWiseOpnCls,
        StockinfoCatWiseOpnInw, StockinfoCatWiseOpnInwCls, StockinfoCatWiseOpnInwOutw, StockinfoCatWiseOpnInwOutwCls, StockinfoCatWiseOpnOutw, 
        StockinfoCatWiseOpnOutwCls, StockinfoCatWiseOpn, StockinfoCatWiseOutw, StockinfoCatWiseOutwCls,
        StockinfoLctWiseCls, StockinfoLctWiseInwCls, StockinfoLctWiseInwOutw, StockinfoLctWiseInwOutwCls, StockinfoLctWiseInw, StockinfoLctWiseOpnCls,
        StockinfoLctWiseOpnInw, StockinfoLctWiseOpnInwCls, StockinfoLctWiseOpnInwOutw, StockinfoLctWiseOpnInwOutwCls, StockinfoLctWiseOpnOutw, 
        StockinfoLctWiseOpnOutwCls, StockinfoLctWiseOpn, StockinfoLctWiseOutw, StockinfoLctWiseOutwCls,StockLevel,StockIPrice,LocationConsum,
        StockStatement,ProducTopSheet,ProductStatment,GroupCommission,StockRegister,ProductTopSheetSalesPrice,MFGProcessReport,SlowFastMoving,
        BOMList, NegetiveStock, LocationWiseQty, GroupWiseValueSup, StockSummSPrice, individualSample, GroupCommissionWithSalesValue, Production,
        PackingRawMaterialsStock, Production_Convertion, MonthlyProduction_Class_Power, MonthlyProduction, StockinfoLctWiseOutwHorizontal, StockIn, StockOut, StockRequisition

    }
}
