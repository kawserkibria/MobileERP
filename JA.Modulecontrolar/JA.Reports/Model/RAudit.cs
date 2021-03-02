using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JA.Reports.Model
{
   public class RAudit
    {
        public string strHeader1 { get; set; }
        public string strHeader2 { get; set; }
        public string strHeader3 { get; set; }
        public string strHeader4 { get; set; }
        public string strHeader5 { get; set; }
        public double dblPazeSize { get; set; }
        public string strRefno { get; set; }
        public string strVoucherDate { get; set; }
        public string strNarration { get; set; }
        public string strLedgername { get; set; }
        public string strAddress1 { get; set; }
        public string strAddress2 { get; set; }
        public double dblAmount { get; set; }
        public string strToBy { get; set; }
        public string strChequeNo { get; set; }
        public string strChequeDate { get; set; }
        public string strChequeDrawnNo { get; set; }
        public string strAuditDate{ get; set; }
        public string strAuditType { get; set; }
        public string strAuditNo { get; set; }
        public string strUserLoginName { get; set; }
        public double  dblAuditText{ get; set; }
        public double dblAuditamount { get; set; }
        public string strInsertDate { get; set; }
        public string strFromname { get; set; }
        public int intModuletype { get; set; }
        public int intModetype { get; set; }
        public string strAdd { get; set; }
        public string strEdit { get; set; }
        public string strDelete { get; set; }
        public string strDepartment { get; set; }
        public string strDesignation { get; set; }
    }
}
