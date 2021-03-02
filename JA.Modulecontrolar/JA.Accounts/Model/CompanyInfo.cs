using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Accounts.Model
{
    public class CompanyInfo
    {

        public static string gstrEmail { set; get; }
        public static string gstrWeb { set; get; }
        public static string gstrCompanyName { set; get; }
        public static string gstrCompanyAddress1 { set; get; }
        public static string gstrCompanyAddress2 { set; get; }
        public static string gdteFinancialYearFrom { set; get; }
        public static string gstrFinicialYearFrom { set; get; }
        public static string gstrFinicialYearTo { set; get; }
        public static string gdteFinancialYearTo { set; get; }
        public static long lngAccessControl { set; get; }
        public static string gstrAccessControl { set; get; }
        public static bool gblnAccessControl { set; get; }
        public static string gstrBusinessType { set; get; }
        public static string gstrBranchID { set; get; }
        public static string gstrCompanyID { set; get; }
        //public static string gblnIncomeExpenses;
        public static bool gblnLocation { set; get; }
        public static long glngBusinessType { set; get; }
        public static bool gblnIncomeExpenses { set; get; }
        public static string gstrCompanyPhone { set; get; }
        public static string gstrBranchName { set; get; }

        public static string gstrOldUserName { set; get; }
        public static string gstrOldPassword { set; get; }

        public static string gstrOnline { set; get; }
        public static string gstrFax { set; get; }
        public static string gstrCounty { set; get; }
        public static string gstrComments { set; get; }


    }
}
