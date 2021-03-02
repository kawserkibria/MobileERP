using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Reports.Model
{
  public  class RoPaymentSummaryearly
    {
        public int IntYear1 { get; set; }
        public int IntYear2 { get; set; }
        public int IntYear3 { get; set; }
        public int IntYear4 { get; set; }
        public double dbl1stYearAmont { get; set; }
        public double dbl2ndYearAmont { get; set; }
        public double dbl3rdYearAmont { get; set; }
        public double dbl4thYearAmont { get; set; }
        public double dbl5tYearAmont { get; set; }
        public string strLedgerName { get; set; }

    }
}
