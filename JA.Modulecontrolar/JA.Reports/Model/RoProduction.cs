using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Reports.Model
{
    public class RoProduction
    {
        public string strBatchNo { get; set; }
        public string strVoucherNo { get; set; }
        public string strdate { get; set; }
        public string strBranchName { get; set; }
        public string strConsumtionGodown { get; set; }
        public string strToFgGodown { get; set; }
        public string strProcess { get; set; }
        //public string strFgItem { get; set; }
        public string strStockItemName { get; set; }
        public string strUnit { get; set; }
        public double dblReceipeQty { get; set; }
        public double dblQty { get; set; }
        public string strBatchSize { get; set; }
        public string strTotalBatchSize{ get; set; }
        public double dblRate { get; set; }
        public double dblAmount { get; set; }
        public string appStatus { get; set; }
        public int intProcessType { get; set; }


    }
}
