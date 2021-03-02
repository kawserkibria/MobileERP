using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.ReportsSP.Model
{
    public class RPSalesCollectionPerformance
    {
       
        public string strCPSPGP { get; set; }
        public string strTC { get; set; }
        public string strTeritorry { get; set; }
        public string strZONE { get; set; }
        public string strDivision { get; set; }
        public string strArea { get; set; }
        public string strLedgerNameMerze { get; set; }
        public double dblOpeningAmount { get; set; }
        public double dblTotalSalesTarget { get; set; }
        public double dblUPDSalesTarget { get; set; }
        public double dblSales { get; set; }
        public double dblSalesAchPer { get; set; }
        public double dblTotalCollTarget { get; set; }
        public double dblUPDCollTarget { get; set; }
        public double dblCollection { get; set; }
        public double dblCollectionAchPer { get; set; }
        public double dblPreviousSales { get; set; }
        

    }
}
