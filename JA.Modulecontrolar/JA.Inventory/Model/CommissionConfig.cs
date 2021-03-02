using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Inventory.Model
{
    public class CommissionConfig
    {
        public string BranchID { get; set; }
        public string GroupconfigName { get; set; }
        public string strEffectiveDate { get; set; }
        public double dblAmountFrom { get; set; }
        public double dblAmountTo { get; set; }
        public string strPercent { get; set; }
        public string strStatus { get; set; }
        public string strCommissinKey { get; set; }
    }
}
