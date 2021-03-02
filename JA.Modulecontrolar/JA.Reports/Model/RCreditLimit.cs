using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Reports.Model
{
    public class RCreditLimit
    {

        public string strLedgerName { get; set; }
        public string strLedgerGroupParent { get; set; }
        public string strDiviison { get; set; }
        public string strZone { get; set; }
        public double dblCriditLimit1 { get; set; }
        public double dblCriditLimit2 { get; set; }
        public double dblCriditLimit3 { get; set; }
        public double dblCriditLimit4 { get; set; }
        public double dblClosingBalance1 { get; set; }
        public double dblClosingBalance2 { get; set; }
        public double dblClosingBalance3 { get; set; }
        public double dblClosingBalance4 { get; set; }
        public string strMonthID { get; set; }
        public string strDate { get; set; }
        public double dblAmount { get; set; }
        public string strFROM_DATE { get; set; }
        public string strTO_DATE { get; set; }
        public string strGRACE_FROM_DATE { get; set; }
        public string strGRACE_TO_DATE { get; set; }

        public string strFROM_DATE2 { get; set; }
        public string strTO_DATE2 { get; set; }
        public string strGRACE_FROM_DATE2 { get; set; }
        public string strGRACE_TO_DATE2 { get; set; }

    }
}
