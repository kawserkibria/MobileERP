using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Inventory.Model
{
    public class SalesPriceLevel
    {
        public string strSalesPriceLevel { get; set; }
        public string strDate { get; set; }
        public double dblFromQty { get; set; }
        public double dblToQty { get; set; }
        public double dblRate { get; set; }
        public double dblDiscount { get; set; }
        public StockItem strPrice { get; set; }
        public string strBonusItem { get; set; }
        public string strBranchID { get; set; }
        public string strBranchName { get; set; }
        public long lngSlNo { get; set; }


    }
}
