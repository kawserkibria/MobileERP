using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.Projection.Model
{
    public class ProjectonMonthConfig
    {
        public int intSerial { get; set; }
        public int intStatus { get; set; }
        public string strMonthID { get; set; }
        public string strFromDate { get; set; }
        public string strToDate { get; set; }
        public string strDivision { get; set; }
        public string strArea { get; set; }
        public string strGRName { get; set; }
        public string strStatus { get; set; }

        public long lngTotalArea { get; set; }
        public long lngTotalLedger { get; set; }
        public string strZone { get; set; }

    }
}
