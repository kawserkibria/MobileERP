using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Reports.Model
{
   public class RHondaLoan
    {
        public string strLedgerName{ get; set; }
        public double dblLoanAmount { get; set; }
        public string strDate { get; set; }
        public string strCom_Ref_No { get; set; }
        public string strCom_Ref_No_Rec_V_No { get; set; }
        public double dblInstallmentAmt { get; set; }
        public string strStartDate { get; set; }
        public string strEndDate { get; set; }
        public int intTotalInstallment { get; set; }
        public int intTakeInstallment { get; set; }
        public double dblTakeLoanAmount { get; set; }
        public double dblBalance{ get; set; }
        public double dblFine { get; set; }
        public double dblRecFineAmount { get; set; }
        public double dblClosingBalance { get; set; }
        public double dblLoanPayemnt { get; set; }
        public int intInstallmentNo { get; set; }
        public string strGroupName { get; set; }
        public string strPhoneNumber { get; set; }
        public double dblCrAmount { get; set; }
       

    }
}
