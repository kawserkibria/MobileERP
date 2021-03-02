using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Reports.Model
{
   public class RoStockRequisition
    {
        public string strItemName { get; set; }
        public string strItemAlias { get; set; }
        public string strMaterialType { get; set; }
        public string strBranchName { get; set; }
        public string strLocationName { get; set; }
        public string strToLocationName { get; set; }
        public string strFromLocationName { get; set; }
        public string strRefNo { get; set; }
        public string strAgnRefNo { get; set; }
        public string strProcessName { get; set; }
        public string strInvDate { get; set; }
        public string strVType { get; set; }
        public string strUnit { get; set; }
        public double dblQty { get; set; }
        public double dblRate { get; set; }
        public double dblAmnt { get; set; }
        public string strGroupParent { get; set; }
        public string strGroupPrimary { get; set; }
        public int intVtype { get; set; }
        public string strNarration { get; set; }
        public string strBatchNo { get; set; }
        public string strItemCategory { get; set; }

   }
}
