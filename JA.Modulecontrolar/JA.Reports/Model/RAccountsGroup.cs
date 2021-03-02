using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Reports.Model
{
    public class RAccountsGroup
    {
        public string strUserName { get; set; }
        public string strSalesRep { get; set; }
        public string strMonthID { get; set; }
        public string strGrName { get; set; }
        public string strRefNo { get; set; }
        public string strGrParent { get; set; }
        public string strLedgerName { get; set; }
        public int intPrimaryType { get; set; }
        public double  dblAmount { get; set; }
        public double dblCashOpn { get; set; }
        public double dblBankOpn { get; set; }
        public double dblOdopn { get; set; }
        public string strBranchId { get; set; }
        public int intGrSequences { get; set; }
        public double dblOpening { get; set; }
        public double dblOpeningDr { get; set; }
        public double dblOpeningCr { get; set; }
        public double ClosingDr { get; set; }
        public double ClosingCr { get; set; }
        public double OpeningAndDebit { get; set; }
        public double OpeningAndCredit { get; set; }
        public double dblDebit { get; set; }
        public double dblCredit { get; set; }
        public double dblDr { get; set; }
        public double dblPF { get; set; }
        public double dblHL { get; set; }
        public double dblCr { get; set; }
        public string stVouchertoby { get; set; }
        public string strDate { get; set; }
        public string strNarration { get; set; }
        public int intvoucherType { get; set; }
        public string strCashFlowType { get; set; }
        public int intCashFlowSign { get; set; }
        public string strCashFlowGroup { get; set; }
        public string strCashFlowLedger { get; set; }
        public double dblCashFlowAmnt { get; set; }
        public double dblClosing { get; set; }
        public string strVectormaster { get; set; }
        public string strToBy { get; set; }
        public long lngslNo { get; set; }
        public long lngManuType { get; set; }
        public long lngSubType { get; set; }
        public string strManuName { get; set; }
        public double dblMnauAmount { get; set; }
        public double dblRunningTotal { get; set; }
        public string strManuGroup { get; set; }
        public string strTerritoryCode { get; set; }
        public string strTeritorryName { get; set; }
        public string strLcode { get; set; }
        public string strAddress1 { get; set; }
        public string strAddress2 { get; set; }
        public string strCheuqueNo { get; set; }
        public string strChequeDate { get; set; }
        public string strDrawnOn { get; set; }
        public string strReverseLedger { get; set; }
        public double dblSalTarget { get; set; }
        public double dblSaltargetAchieve { get; set; }
        public double dblColltarget { get; set; }
        public double dblCollAcieve { get; set; }
        public string strPeriod { get; set; }
        public string strFromDate { get; set; }
        public string strToDate { get; set; }

        public string strZone { get; set; }
        public string strTC { get; set; }
        public string strTN { get; set; }

    }
}
