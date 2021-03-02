using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Inventory.Model
{
    public class ManuProcess
    {
        public string strProcessName { get; set; }
        public string stritemName { get; set; }
        public double dblqnty { get; set; }
        public string strUnit { get; set; }
        public double  dblCostPrice { get; set; }
        public int intType { get; set; }
        public double dblCostPercent { get; set; }
        public string strEntryDate { get; set; }
        public string strRefNoRaw { get; set; }
        public string strRefNoWastage { get; set; }
        public string strLogDate { get; set; }
        public int intConverttype { get; set; }
        public int intTrasnferType { get; set; }
        public double dblsalesamount { get; set; }
        public string strBranchID { get; set; }
        public string strGodown { get; set; }
    }
}
