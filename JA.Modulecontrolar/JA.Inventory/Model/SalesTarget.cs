using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Inventory.Model
{
    public class SalesTarget
    {
        public string  strKey { get; set; }
        public string strFromDate { get; set; }
        public string strBranchName { get; set; }
        public string strToDate { get; set; }
        public string strLedgerName { get; set; }
        public string strMerzeName { get; set; }
        public string strBranchID { get; set; }
        public double dblAmount { get; set; }
        public double dblPer { get; set; }
        public double dblOpn { get; set; }
        public long  lngslNo { get; set; }
        public string strMonthID { get; set; }
        public int intRowPos { get; set; }
        public int intColPos { get; set; }
        public int intType { get; set; }

    }
}
