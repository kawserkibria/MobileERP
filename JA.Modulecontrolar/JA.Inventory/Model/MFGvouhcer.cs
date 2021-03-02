using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Inventory.Model
{
    public class MFGvouhcer
    {
        public string strVoucherNo { get; set; }
        public string strBatch { get; set; }
        public string strBatchSize { get; set; }
        public double dblAmount { get; set; }
        public string strDate { get; set; }
        public string strProcess { get; set; }
        public string strBranchId { get; set; }
        public string strLocation { get; set; }
        public string strTLocation { get; set; }
        public string strItemName { get; set; }
        public string strfgItem { get; set; }
        public double dblQnty { get; set; }
        public double dblReceipe { get; set; }
        public double dblrate { get; set; }
        public string strUOM { get; set; }
        public double dblCostPercent { get; set; }
        public string strRMRefNo { get; set; }
        public string strWmRefNo { get; set; }
        public string strFgRefNo { get; set; }
        public string strSection { get; set; }
        public string strNarration { get; set; }
        public string  strCosting { get; set; }
        public string strBillKey { get; set; }
        public long lngSlno { get;set;}
        public int intAppStatus { get; set; }
        public int intProcessType { get; set; }
        public double dblSampleFG { get; set; }
        public double dblSampleQC { get; set; }
        public int intVtype { get; set; }

    }
}
