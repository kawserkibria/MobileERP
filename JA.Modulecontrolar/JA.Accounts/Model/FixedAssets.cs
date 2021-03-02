using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Accounts.Model
{
    public class FixedAssets
    {
        public double  dblPurchaseAmount{get;set;}   
        public double  dblAssetsLife {get;set;}   
        public double  dblDepRate {get;set;}   
        public double  dblAccumulatedDep {get;set;}  
        public double  dblWrittendownValue {get;set;} 
        public double  dblSalvageValue {get;set;}
        public string strEffectiveDate { get; set; }
        public string strBranchID { get; set; }
        public string strBranchName { get; set; }
        public string strLedgerName { get; set; }
        public string strDepMethod { get; set; }
        public string strRefNo { get; set; }
        public long  lngSerialNo { get; set; }


    }
}
