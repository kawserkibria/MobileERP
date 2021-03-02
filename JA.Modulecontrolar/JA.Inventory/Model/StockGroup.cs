using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Inventory.Model
{
    public class StockGroup
    {
        public string GroupName { get; set; }
        public string GroupUnder { get; set; }
        public long lngslNo { get; set; }
        public string strPrimary { get; set; }
        public string strDefaultFroup { get; set; }
        public string GrName { get; set; }
        public string strPackSize { get; set; }
        public string strOneDown { get; set; }
        public string strStatus { get; set; }
    }
}
