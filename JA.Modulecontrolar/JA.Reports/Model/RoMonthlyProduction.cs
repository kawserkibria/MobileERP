using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Reports.Model
{
    public class RoMonthlyProduction
    {
        public string strLocationname { get; set; }
        public string strLedgerName { get; set; }
        public string strPowerClass { get; set; }
        public string strItemName { get; set; }
        public string strStockGroup{ get; set; }
        public string strPackSize { get; set; }
        public double dblBatchSize { get; set; }
        public string strBatchNo { get; set; }
        public double dblTargetQty { get; set; }
        public double dblProduction { get; set; }
        public double dblTotal_FG { get; set; }
        public double dblSampleToFG { get; set; }
        public double dblSampleToQC { get; set; }
        public double dblLoss { get; set; }
        public double dblPrevious { get; set; }
        public double dblGain { get; set; }
        public double dblConversion { get; set; }
        public double dblRepacking { get; set; }
        public double dblTotal { get; set; }
        

    }
}
