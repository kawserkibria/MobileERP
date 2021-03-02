using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Reports.Model
{
   public class RoConsumption
    {
       public string strCategoryName { get; set; }
       public string strProcessName { get; set; }
       public string strStockItemName { get; set; }
       public string strStockLocation { get; set; }
       public string strStockGroup { get; set; }
        public double dblConv450_ML { get; set; }
        public double dblConv100_ML { get; set; }
        public double dblConv30_ML { get; set; }
        public double dblFG4_50_ML { get; set; }
        public double dblFG_100_ML { get; set; }
        public double dblFG_30_ML { get; set; }
    }
}
