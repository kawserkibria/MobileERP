using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Accounts.Model
{
    public class AccountdGroup
    {
        public string GroupName { get; set; }
        public string ParentName { get; set; }
        public string strDefaultGroup { get; set; }
        public double dblopeningDr { get; set; }
        public double dblopeningCr { get; set; }
        public string strMonthID { get; set; }
        public int intPrimaryType { get; set; }
        public int intCashFlowType { get; set; }
        public long lngSlNo { get; set; }
        public long lngGrLevel { get; set; }
        public double dblAmount { get; set; }
        public string strFromdate { get; set; }
        public string strTodate { get; set; }
        public string strGFromDate { get; set; }
        public string strGTodate { get; set; }

        public string strStstus { get; set; }
        public string strKey { get; set; }
        public string strFormName { get; set; }
        public string strMobileNo { get; set; }
        public string strContactNo { get; set; }
        public int intModule { get; set; }
        public int intMode { get; set; }
        public int intStatus { get; set; }

    }
}
