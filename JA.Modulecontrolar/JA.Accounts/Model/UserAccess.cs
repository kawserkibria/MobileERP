using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Accounts.Model
{
    public class UserAccess
    {
        public string LogInName { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string LedgerName { get; set; }
        public string MobileNo { get; set; }
        public string SecurityCode { get; set; }
        public string commnets { get; set; }
        public int intAccessLevel { get; set; }
        public int intAdd { get; set; }
        public int intEdit { get; set; }
        public int intDelete { get; set; }
        public string strStatus { get; set; }
        public long lngSlNo { get;set;}
        public string strPassWord { get; set; }
        public byte[] strIamge { get; set; }
        public string AccessLevel { get; set; }
        public string strLogInKey { get; set; }


    }
}
