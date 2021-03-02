using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Inventory.Model
{
   public class InvoiceConfig
    {
       public long mlngItemDesc { get; set; }
       public long mlngSeparateParty { get; set; }
       public bool mblnDiscountAllowed { get; set; }
       public bool mblnItemDescription { get; set; }
       public long mlngBlockNegativeStock { get; set; }
       public long mlngCalcSubTotal { get; set; }
       public bool gblnStockItemAlias { get; set; }
       public long mlngIsInvEffinDirSalesInv { get; set; }
       public long mlngIsInvEffinDirPurcInv { get; set; }
       public string strAgnstRefNo { get; set; }
       public string strRefNo { get; set; }

    }
}
