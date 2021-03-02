using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Inventory.Model
{
    public class StockCategory
    {
        public string CategoryName { get; set; }
        public string CategoryUnder { get; set; }
        public long lngslNo { get; set; }
        public string strPrimary { get; set; }
        public string strDefaultFroup { get; set; }
    }
}
