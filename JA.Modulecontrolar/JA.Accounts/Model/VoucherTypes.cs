using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Accounts.Model
{
    public class VoucherTypes
    {
        public string typeofVoucher { get; set; }
        public string voucherName { get; set; }
        public string voucherNoMethod { get; set; }
        public long lngSlNo { get; set; }
        public long StartingNo { get; set; }
        public long  noWidth { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public long PrintSaving { get; set; }
        public long TotalVoucher { get; set; }
        public int intVoucherNoMethod { get; set; }
        public int intBkash { get; set; }
    }
}
