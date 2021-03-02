using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Reports.Model
{
   public class RFixedAsset
    {


        public string strLedgerName{ get; set; }
        public string strLedgerGroupParent{ get; set; }
        public double dblAssetPrevBal { get; set; }
        public double dblAssetAddThisPeriod { get; set; }
        public double dblAssetDisposalthisPeriod { get; set; }
        public double dblAssetDepRate { get; set; }
        public double dblAssetDepThisPeriod { get; set; }
        public double dblAssetDepAccu { get; set; }
        public double dblAssetDepAdjustMent { get; set; }
    }
}
