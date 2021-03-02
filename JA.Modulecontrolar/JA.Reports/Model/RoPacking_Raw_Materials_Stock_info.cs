using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Reports.Model
{
  public  class RoPackingRawMaterialsStockinfo
    {

      public string strLocationName{ get; set; }
        public string strItemName{ get; set; }
        public string strStockItemName { get; set; }
        public string strGroupParent { get; set; }
        public string strGroupPrimary { get; set; }
        public string strAltUnit { get; set; }
        public string strGroupName { get; set; }
        public double dblOpening { get; set; }
        public double dblInReceived{ get; set; }
        public double dblInStockTransfer { get; set; }
        public double dblOutConjumption { get; set; }
        public double dblOutdblStockTransfer { get; set; }
        public double dblOutDefect { get; set; }
        public double dblOutWastage { get; set; }
        public double dblOutRepack { get; set; }
        
    }
}
