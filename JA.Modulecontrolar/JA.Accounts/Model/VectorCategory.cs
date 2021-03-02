using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Accounts.Model
{
    public class VectorCategory
    {
        public string strVectorcategory { get; set; }
        public string strCostCenter { get; set; }
        public string strBranchId { get; set; }
        public string strDrcr { get; set; }
        public AccountsLedger  accountsLedger {get;set;}
        public double dblAmount { get; set; }
        public long lngSlNo { get; set; }
    }
}
