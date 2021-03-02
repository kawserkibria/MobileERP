using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Inventory.Model
{
    public class Batch
    {
        public long  lngSlno { get; set; }
        public string strLogNo { get; set; }
        public string strStartDate { get; set; }
        public string strEndDate { get; set; }
        public string strExpireDate { get; set; }
        public string strLedgerName { get; set; }
        public string strStatus { get; set; }
        public long  lngLogSize { get; set; }
        public string strManuDate { get; set; }
       
    }
}
