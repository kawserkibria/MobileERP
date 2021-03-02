using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Accounts.Model
{
    public class AccountsLedger
    {
        public long  lngSlno { get; set; }
        public long lngLedgerGroup { get; set; }
        public double dblPFAmount { get; set; }
        public string strPFLedger { get; set; }
        public string strHLLedgerName { get; set; }
        public string strOldLedgerName { get; set; }
        public string strLedgerName { get; set; }
        public string strTeritorryCode { get; set; }
        public string strTeritoryyName { get; set; }
        public string strmerzeString { get; set; }
        public string strParentGroup { get; set; }
        public string strPreserveSQL { get; set; }
        public long lngCommType { get; set; }
        public string strUder { get;set; }
        public string strCostCente { get;set; }
        public string strCurrency { get;set; }
        public string streffectInventory { get;set ;}
        public string strcloseDate { get; set; }
        public string strDifference { get; set; }
        public double dblOpnBalance { get;set; }
        public string strDrcr { get;set; }
        public string strAddress { get;set;}
        public string strAddress2 { get; set; }
        public string strCity { get;set; }
        public string strPostalCode { get;set;}
        public string strPhone { get; set; }
        public string strFax { get;set; }
        public string strEmail { get;set;}
        public string strInactive { get; set; }
        public string strCommnents { get; set; }
        public int intDefaultGroup { get; set; }
        public int intCostCenter { get; set; }
        public int intBillwise { get; set; }
        public int intLedgerPrimaryType { get; set; }
        public int intInventoryEffect { get; set; }
        public int intStatus { get; set; }
        public string strCreditLimit { get; set; }
        public double dblPeriod { get;set;}
        public string strCreditDate { get; set; }
        public string strPriceLevel { get; set; }
        public string strCantactPerson { get; set; }
        public string strResinDate { get; set; }
        public string strCommission { get; set; }
        public string strRepName { get; set; }
        public int intBkash { get; set; }
        public string strTerritoryName { get; set; }
        public string strEfectDate { get; set; }
        public string strConfigkey { get; set; }
        public double dblFromAmt { get; set; }
        public double dblToAmt { get; set; }
        public double dblConfigPer { get; set; }
        public double dblVoucherTAmount { get; set; }
        public double dblNoVoucher { get; set; }
        public double dblVoucherTAmountToday { get; set; }
        public double dblNoVoucherToday { get; set; }
        public double dblVoucherRecevedTAmount { get; set; }
        public string strCurrentYear { get; set; }
        public string strClass { get; set; }
        public string strLedgerCode { get; set; }
        public string strhomoeohall { get; set; }
        public double dbltargetAmount { get; set; }
        public double dblMpoPercentage { get; set; }
        public string strBranchID { get; set; }

        public int intCol { get; set; }
        public int intRow { get; set; }

    }
}
