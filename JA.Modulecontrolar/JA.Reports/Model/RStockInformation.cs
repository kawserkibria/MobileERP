using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Reports.Model
{
   public class RStockInformation
    {
       public long lngDiff { get; set; }
       public string strClosing { get; set; }
       public string strItemName { get; set; }
       public string strItemAlias { get; set; }
       public string strMaterialType { get; set; }
       public string strGroupName { get; set; }
       public string strLocationName { get; set; }
       public string strFromLocationName { get; set; }
       public string strToLocationName { get; set; }
       public string strRefNo { get; set; }
       public string strLedgerName { get; set; }
       public string strInvDate { get; set; }
       public string strVType { get; set; }
       public string strUnit { get; set; }
       public string strAltUnit { get; set; }
       public double  dblOpnQty { get; set; }
       public double dblOpnRate { get; set; }
       public double dblOpnAmnt { get; set; }
       public double dblInwQty { get; set; }
       public double dblInwRate { get; set; }
       public double dblInwAmount { get; set; }
       public double dblOutWardQty { get; set; }
       public double dblOutwardRate { get; set; }
       public double dblOutwardAmnt { get; set; }
       public double dblSampleQty { get; set; }
       public double dblSampleValue { get; set; }
       public double dblReturnQty { get; set; }
       public double dblReturnValue { get; set; }
       public double dblConvertQty { get; set; }
       public double dblPhyStockQty { get; set; }
       public double dblStockTranserQty { get; set; }
       public double dblTranserOutQty { get; set; }
       public double dblConsumptionQty { get; set; }
       public double dblBroken { get; set; }
       public double dblBrokenValue { get; set; }
       public double dblBonusValue { get; set; }
       public double dblclsQty { get; set; }
       public double dblclsRate { get; set; }
       public double dblclsAmnt { get; set; }
       public double dblStaffvalue { get; set; }
       public double dblCommissionValue{ get; set; }
       public string  strKey { get; set; }
       public string strGroupParent { get; set; }
       public string strGroupPrimary { get; set; }
       public int intVtype { get; set; }
       public string strNarration { get; set; }
       public string strBatchNo { get; set; }
       public string strItemCategory { get; set; }
       public string StockItemBASEUNITS { get; set; }

    }
}
