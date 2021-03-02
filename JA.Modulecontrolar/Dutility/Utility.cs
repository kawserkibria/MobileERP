using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Drawing;
using System.Xml;
using System.Globalization;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.Odbc;
using MayhediControlLibrary;
using System.Diagnostics;
using System.Security.AccessControl;




namespace Dutility
{
    public class Utility
    {
       
        public static string strDataBase { set; get; }
        public static string gcnMain { set; get; }
        public static string gstrPhoneNo { set; get; }
        public static string gstrMsg = "Developed By: Tulip IT";
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
        public static bool gblngSingleStockTransfer { set; get; }
        public static bool gblngDifferentTransfer { set; get; }
        public static bool gblngManufacturing { set; get; }
        public static bool gblngBookingInformation { set; get; }
        public static bool gblngSalesInvoiceSlip { set; get; }
        public static bool gblngAdmissionRealEstate { set; get; }
        public static bool gblngSingleNarration { set; get; }
        public static bool gblngPhysicalStock { set; get; }
        public static bool gblnStockItemAlias { set; get; }


        public static bool gblngApproved { set; get; }
        public static string gstrBaseCurrency = "BDT";
        public static string gstrUserName;

        public static string gstDatabaserUserName = "sa";
        public static string gstrpassword;
        public static string gstrInstanceName { set; get; }
        //public static string gstrInstanceName = "IT-MAYHEDI\\JAGORONR2";
        public static string gstDatabasePassword = "tulip123";
        //public static string gstDatabasePassword = "Admin420420";
        public static string gstrAppDatabase;
        public static string gstrSmartMessage = "Smart Accounting";
        public const string gs_PASSWORD_ENCRYPT_DECRYPT = "SMAT";
        public const string gcMaskDate = "  /  /";
        public static bool gblnAdminPrv { set; get; }
        public static long glngIntegrateInventory { set; get; }
        public static bool gblnBranch { set; get; }
        public static bool gblnMultipleCurrency { set; get; }
        public static string gstrFCsymbol { set; get; }
        public static double gdblCurrRate { set; get; }
        public static long glngIsMaintainBatch { set; get; }

        public static string gstrJagoromMsg = "Powered by Jagoron Software";

        public const string DEFAULT_DATE_FORMAT = "dd-MM-yyyy";
        public const string HACK_PREFIX = "X";
        public const string gcEND_OF_LIST = "End of List";
        public const string vtOPENING_BILLWISE_STR = "OB";
        public const string vtPAYMENT_VOUCHER_STR = "PV";
        public const string vtJOURNAL_VOUCHER_STR = "JV";
        public const string vtRECEIPT_VOUCHER_STR = "RV";
        public const string vtCONTRA_STR = "CV";
        public const string vtSALES_QUOTATION_STR = "SQ";
        public const string vtSALES_ORDER_STR = "SO";
        public const string vtSALES_DELIVERY_ORDER_STR = "SD";
        public const string vtSALES_CHALLAN_STR = "SC";
        public const string vtSALES_INVOICE_STR = "SI";
        public const string vtSALES_INVOICE_POS_STR = "SP";
        public const string vtSALES_RETURN_STR = "SR";
        public const string vtSTOCK_OPENING_STR = "OP";
        public const string vtPURCHASE_ORDER_STR = "PO";
        public const string vtPURCHASE_RECEIVE_STR = "PE";
        public const string vtPURCHASE_INVOICE_STR = "PI";
        public const string vtPURCHASE_RETURN_STR = "PR";
        public const string vtHW_CUSTOMER_RECEIPT_STR = "CR";
        public const string vtHW_DELIVERY_SLIP_STR = "DS";
        public const string vtHW_RETURN_SUPPLIER_STR = "RC";
        public const string vtSTOCK_INWARD_STR = "RI";
        public const string vtSTOCK_OUTWARD_STR = "II";
        public const string vtSTOCK_TRANSFER_STR = "IT";
        public const string vtSTOCK_IN_STR = "IN";
        public const string vtSTOCK_OUT_STR = "IO";
        public const string vtSTOCK_SAMPLE_STR = "SM";
        public const string vtSTOCK_PRODUCTION_STR = "MP";
        public const string vtSTOCK_TRANSFERIN = "TI";
        public const string vtSTOCK_RETURN_STR = "ST";
        public const string vtSTOCK_DAMAGE_STR = "ID";
        public const string vtSTOCK_PHYSICAL_STR = "IP";
        //public const string vtSTOCK_REQUISITION_STR = "QR";
        public const string vtSTOCK_MFG_CONSUMPTION_STR = "MC";
        public const string vtSTOCK_MFG_FINISHEDGOODS_STR = "MF";
        public const string vtSTOCK_MFG_VOUCHER_STR = "MV";
        public const string vtSTOCKREQUISITION = "QR";
        //public const string vtSTOCK_OUT_STR = "MI";
        public const string vtSTOCK_MFG_VCH_CONS_STR = "MO";
        public static string UserRoleID
        { set; get; }
        public static string UserRoleName
        { set; get; }
        public static string UserDepartmentGroupID
        { set; get; }
        public static string UserDepartmentGroupTiitle
        { set; get; }
        public static string UserDesignation
        { set; get; }
        public static string UserImageID
        { set; get; }
        public static string UserName
        { set; get; }

        public static string UpdateBy
        { set; get; }
        public static string CompanyID
        { set; get; }
        public static string LocationID
        { set; get; }
        public static string MachineID
        { set; get; }
        public static string Booth
        { set; get; }
        public static string Month
        { set; get; }
        public static string Year
        { set; get; }
        public static string UserDepartmentTypeID { set; get; }
        public static string UserDepartmentTypeTitle { set; get; }
        public static string UserDepartment
        { set; get; }
        public static byte[] EmployeePhoto { get; set; }
        public class AccessList
        {
            public string ModuleID { set; get; }
            public string ModuleName { set; get; }
            public string ObjSerial { get; set; }
            public string ObjID { get; set; }
            public string ObjName { get; set; }
            public string ObjType { get; set; }
            public string AuthenticationLevel { get; set; }
            public string RoleID { get; set; }
            public string RoleName { get; set; }
            public string FormID { set; get; }
            public string FormName { set; get; }

        }
        public static List<string> Modules = new List<string>();
        public static void ModuleAdd(string value)
        {
            Utility.Modules.Add(value);
        }

        public enum GROUP_TYPE
        {
            gtMAIN_GROUP = 1,
            gtSUB_GROUP = 2
        }
        public enum VOUCHER_TYPE
        {
            vtRECEIPT_VOUCHER = 1,
            vtPAYMENT_VOUCHER = 2,
            vtJOURNAL_VOUCHER = 3,
            vtCONTRA_VOUCHER = 4,
            vtCREDIT_NOTE = 5,
            vtDEBIT_NOTE = 6,
            vtDELIVERY_NOTE = 7,
            vtINVESTMENT = 8,

            //'vtPURCHASE_VOUCHER = 8
            vtSALES = 9,
            vtSALES_VOUCHER = 11,
            vtSALES_ORDER = 12,
            vtSALES_RETURN = 13,
            vtDELIVERY_ORDER = 14,
            vtSALES_CHALLAN = 15,
            vtSALES_INVOICE = 16,
            vtSALES_QUOTATION = 19,
            vtSALES_INVOICE_POS = 18,

            vtSTOCK_OPENING = 0,
            vtSTOCK_INWARD = 21,
            vtSTOCK_OUTWARD = 22,
            vtSTOCK_TRANSFER = 23,
            vtSTOCK_DAMAGE = 24,
            vtSTOCK_PHYSICAL = 25,
            vtSTOCK_MFG_CONSUMPTION = 26,
            vtSTOCK_MFG_FINISHED_GOODS = 27,
            vtSTOCK_MFG_VOUCHER = 29,
            vtSTOCK_MFG_PRODUCTION = 51,
            vtSTOCK_RETURN = 28,

            vtPURCHASE = 30,
            vtPURCHASE_ORDER = 31,
            vtPURCHASE_RETURN = 32,
            vtPURCHASE_INVOICE = 33,
            vtPURCHASE_RECEIVE = 34,
            vtSTOCK_REQUISITION = 40,

            vtHW_PRODUCT_RECEIVED = 41,
            vtHW_PRODUCT_REPLACEMENT = 42,
            vtHW_RETURN_SUPPLIER = 43,
            vtHW_RECEIVE_SUPPLIER = 44,
            vtSTOCK_TRANFERIN = 55,
            vt_POS_MODULE = 10,
            vt_STOCK_ABSOVED = 66,
            vt_SALESSAMPLE = 17,
            vt_SAMPLE_CLASS = 50
            

        }
        public enum MODULE_TYPE
        {
            mtSALES = 1,
            mtPURCHASE = 2,
            mtSTOCK = 3,
            mtACCOUNT = 4,
            mtTOOLS = 9,
            mtLC = 5,
            mtCO_OPERAIVE = 6,
            mtHW = 7,
            mtHRD = 8,
            mtProjection = 10
        }
        public enum GR_GROUP_TYPE
        {
            grBANKACCOUNTS = 100,
            grCash = 101,
            grSTOCK_IN_HAND = 401,
            grCUSTOMER = 202,
            grSUPPLIER = 203,
            grSALES_REP = 204,
            grOTHER_LEDGER = 205,
            grFIXED_ASSET = 206,//    'Fixed Asset
            grSALES = 211,//    'Trading
            grPURCHASE = 212,//    'Trading
            grDIRECT_EXPENSES = 213,//    'Trading
            grCOMPLEMENTARY_GOODS = 214,//    'Trading
            grOTHER_INCOME = 215,//    'Trading
            grFINISHED_PURCHASE = 216,//
            grPROFIT_AND_LOOS = 301,//
            grBRANCH_ACCOUNT = 217,//    'Previous 501 - Changed to 217
            grCONSIGNEE_ACOUNT = 502//

        }
        public enum LEDGER_PRM_TYPE
        {
            lgrASSET = 1,
            lgrLIABILITY = 2,
            lgrINCOME = 3,
            lgrEXPENSES = 4
        }

        public enum ACTION_MODE_ENUM
        {
            ADD_MODE = 1,
            EDIT_MODE = 2,
            DISP_MODE = 3
        }
        public class GetCallType
        {
            public static int intCallType;
            public static int getCallType
            {
                get
                {
                    return intCallType;
                }
                set
                {
                    intCallType = value;
                }
            }
        }
        public static string GetMonth(int intDay)
        {
            string Month = "";
            if (intDay == 1)
            {
                Month = "JAN";
            }
            else if (intDay == 2)
            {
                Month = "FEB";
            }
            else if (intDay == 3)
            {
                Month = "MAR";
            }
            else if (intDay == 4)
            {
                Month = "APR";
            }
            else if (intDay == 5)
            {
                Month = "MAY";
            }
            else if (intDay == 6)
            {
                Month = "JUN";
            }
            else if (intDay == 7)
            {
                Month = "JUL";
            }
            else if (intDay == 8)
            {
                Month = "AUG";
            }
            else if (intDay == 9)
            {
                Month = "SEP";
            }
            else if (intDay == 10)
            {
                Month = "OCT";
            }
            else if (intDay == 11)
            {
                Month = "NOV";
            }
            else if (intDay == 12)
            {
                Month = "DEC";
            }
            return Month;
        }

        public static string gmakeProperCase(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }
        public static string Right(string param, int length)
        {
            string result = param.Substring(param.Length - length, length);
            return result;
        }
        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = (12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month) + 1;
            return Math.Abs(monthsApart);
        }
        public static DateTime NextMonth(DateTime date)
        {
            if (date.Day != DateTime.DaysInMonth(date.Year, date.Month))
                return date.AddMonths(1);
            else
                return date.AddDays(1).AddMonths(1).AddDays(-1);
        }
        public static int mstrGetVoucherType(string strName)
        {
            switch (strName)
            {
                case "Sales Invoice":
                    return (int)VOUCHER_TYPE.vtSALES_INVOICE;
                    break;
                case "Sales Invoice Pos":
                    return (int)VOUCHER_TYPE.vtSALES_INVOICE_POS;
                    break;
                case "Sales Return":
                    return (int)VOUCHER_TYPE.vtSALES_RETURN;
                    break;
                case "Purchase Invoice":
                    return (int)VOUCHER_TYPE.vtPURCHASE_INVOICE;
                    break;
                case "Purchase Return":
                    return (int)VOUCHER_TYPE.vtPURCHASE_RETURN;
                    break;
                case "Contra":
                    return (int)VOUCHER_TYPE.vtCONTRA_VOUCHER;
                    break;
                case "Journal":
                    return (int)VOUCHER_TYPE.vtJOURNAL_VOUCHER;
                    break;
                case "Payment":
                    return (int)VOUCHER_TYPE.vtPAYMENT_VOUCHER;
                    break;
                case "Receipt":
                    return (int)VOUCHER_TYPE.vtRECEIPT_VOUCHER;
                    break;
                case "Stock Transfer":
                    return (int)VOUCHER_TYPE.vtSTOCK_TRANSFER;
                    break;
                default:
                    return 0;
                    break;
            }

        }
        public static string gstrGetBusinessType(int vlngBType)
        {
            switch (vlngBType)
            {
                case 1:
                    return "Trading Company";
                    break;
                case 2:
                    return "Real Estate";
                    break;
                case 3:
                    return "Educational Institution";
                    break;
                case 4:
                    return "Manufacturing Company";
                    break;
                case 5:
                    return "Drug Store";
                    break;
                case 6:
                    return "Hotel Management";
                    break;
                case 7:
                    return "Non-Profit Company";
                    break;
                case 8:
                    return "Hospital";
                    break;
                case 9:
                    return "POS";
                    break;
                case 10:
                    return "Hotel Management";
                    break;
                case 11:
                    return "Co-Operative Society";
                    break;
                case 12:
                    return "Book Publisher";
                    break;
                default:
                    return "NONE";
                    break;
            }

        }
        public static string gstrGetLastSerl()
        {
            string strSQL;
            string conDb;
            int intName;
            SqlDataReader dr;
            conDb = SQLConnstring();
            strSQL = "SELECT NAME FROM master.dbo.sysdatabases WHERE NAME LIKE 'SMART%' ORDER BY NAME DESC ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        intName = Convert.ToInt32(Utility.Right(dr["NAME"].ToString(), 4)) + 1;
                        return (intName.ToString().PadLeft(4, '0'));

                    }
                    else
                    {
                        return "0001";
                    }
                }
                catch (Exception ex)
                {
                    return "0001";
                }
                dr.Close();
                gcnMain.Close();



            }

        }
        public class TCPIP
        {
                public string strSessionID {get;set;}
                public string strNetTrasport {get;set;}
                public string strHostname {get;set;}
                public string strProramArea {get;set;}
                public string strConnectTime {get;set;}
                public string strIPAddress { get; set; }
        }
        public static List<TCPIP> getTCPIP(string strcomID)
        {
            string strSQL, conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            
            ////SELECT DB_NAME(database_id) as [DB]
            ////    , login_name
            ////    , nt_domain
            ////    , nt_user_name
            ////    , status
            ////    , host_name
            ////    , program_name
            ////    , COUNT(*) AS [Connections]
            ////FROM sys.dm_exec_sessions
            ////WHERE database_id > 0  and database_id <> 7
            ////and PROGRAM_NAME='.Net SqlClient Data Provider' 
            ////GROUP BY database_id, login_name, status, host_name, program_name, nt_domain, nt_user_name;



            List<TCPIP> oTcp = new List<TCPIP>();
            strSQL = "SELECT DISTINCT ";
            //strSQL = strSQL + "c.session_id, ";
            strSQL = strSQL + "c.net_transport, ";
            strSQL = strSQL + "s.host_name,  ";
            strSQL = strSQL + "s.program_name,  ";
            strSQL = strSQL + "s.nt_user_name, ";
            strSQL = strSQL + "c.connect_time,  ";
            strSQL = strSQL + "s.client_interface_name, ";
            strSQL = strSQL + "c.client_net_address, ";
            strSQL = strSQL + "c.local_net_address,  ";
            strSQL = strSQL + "s.login_name,  ";
            strSQL = strSQL + "s.nt_domain ";
            //strSQL = strSQL + "s.login_time ";
            strSQL = strSQL + "FROM sys.dm_exec_connections AS c ";
            strSQL = strSQL + "JOIN sys.dm_exec_sessions AS s ";
            strSQL = strSQL + "ON c.session_id = s.session_id and c.net_transport='TCP'  AND s.database_id > 0  and s.database_id <> 7 ";
            strSQL = strSQL + "and s.PROGRAM_NAME='.Net SqlClient Data Provider'  ";
            strSQL = strSQL + " ORDER by c.connect_time desc";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TCPIP ootcp = new TCPIP();
                    //ootcp.strSessionID = dr["client_net_address"].ToString();
                    ootcp.strNetTrasport = dr["net_transport"].ToString();
                    ootcp.strHostname = dr["host_name"].ToString();
                    ootcp.strProramArea = dr["program_name"].ToString();
                    ootcp.strConnectTime = dr["connect_time"].ToString();
                    ootcp.strIPAddress = dr["client_net_address"].ToString();
                    oTcp.Add(ootcp);

                }
                dr.Close();
                gcnMain.Close();
                return oTcp;




            }

        }
        public static bool gblnMaindPrivileges(string strcomID, string VstrUserName, long vlngComponent)
        {
            string strSQL = "", conDb, strLoginKey;
            long lngPrivileges = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strLoginKey = VstrUserName.Trim() + vlngComponent.ToString();
            strSQL = "SELECT (PRI_TYPE) AS TOTAL_PRI FROM USER_PRIVILEGES_MAIN ";
            strSQL = strSQL + "WHERE USER_LOGIN_KEY = '" + strLoginKey + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lngPrivileges = Convert.ToInt64(dr["TOTAL_PRI"]);
                    }
                    dr.Close();
                    gcnMain.Close();
                    if (lngPrivileges > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    return false;
                }


            }

        }
        public static bool gblnChildPrivileges(string strcomID,string VstrUserName, long vlngComponent)
        {
            string strSQL = "", conDb, strLoginKey;
            long lngPrivileges = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strLoginKey = VstrUserName.Trim() + vlngComponent.ToString();
            strSQL = "SELECT (PRI_ADD + PRI_EDIT + PRI_DELETE) AS TOTAL_PRI FROM USER_PRIVILEGES_CHILD ";
            strSQL = strSQL + "WHERE USER_LOGIN_KEY = '" + strLoginKey + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lngPrivileges = Convert.ToInt64(dr["TOTAL_PRI"]);
                    }
                    dr.Close();
                    gcnMain.Close();
                    if (lngPrivileges > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    return false;
                }


            }

        }
        public static bool glngGetPriviliges(string strcomID, string VstrUserName, long vlngComponent, long vlngAction)
        {
            string strSQL="", conDb, strLoginKey;
            long lngPrivileges=0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strLoginKey = VstrUserName.Trim() + vlngComponent.ToString();
            if (vlngAction == 1)
            {
                strSQL = "SELECT PRI_ADD AS PRI FROM USER_PRIVILEGES_CHILD ";
            }
            if (vlngAction == 2)
            {
                strSQL = "SELECT PRI_EDIT AS PRI FROM USER_PRIVILEGES_CHILD ";
            }
            if (vlngAction == 3)
            {
                strSQL = "SELECT PRI_DELETE AS PRI FROM USER_PRIVILEGES_CHILD ";
            }
            if (vlngAction == 4)
            {
                strSQL = "SELECT PRI_APPR AS PRI FROM USER_PRIVILEGES_CHILD ";
            }
            strSQL = strSQL + "WHERE USER_LOGIN_KEY = '" + strLoginKey + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lngPrivileges = Convert.ToInt64(dr["PRI"]);
                    }
                    dr.Close();
                    gcnMain.Close();
                    if (lngPrivileges ==0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                   
                }
                catch (Exception ex)
                {
                    return false;
                }
               

            }

        }
        public static bool gIsExistGroup(string strcomID, string strGroup)
        {
            string strSQL, conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT GR_NAME FROM ACC_LEDGERGROUP ";
            strSQL = strSQL + " WHERE GR_NAME = '" + strGroup + "'";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    return false;
                }
                dr.Close();
                gcnMain.Close();

            }

        }
        public static double gdblClosingStockSales(string strcomID, string vstrItemName, string vstrLocation, string strgroupName,string vstrGodownsName)
        {

            string strSQL;
            string conDb;
            double dblclosing = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            strSQL = "SELECT ISNULL(sum(QNTY),0) AS CLOSING FROM STOCK_STATEMENT_VIEW ";
            strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName.Replace("'","''") + "' ";
            strSQL = strSQL + "AND BRANCH_ID = '" + vstrLocation + "' ";
            strSQL = strSQL + "AND GODOWNS_NAME = '" + vstrGodownsName.Replace("'","''") + "' ";
           
            if (strgroupName != "")
            {
                strSQL = strSQL + "AND STOCKGROUP_NAME = '" + strgroupName + "' ";
            }
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblclosing =Convert.ToDouble(dr["CLOSING"]);
                    return dblclosing;
                }
                else
                {
                    return 0;
                }

                dr.Close();
                gcnMain.Close();
            }
        }
        public static double gdblClosingStock(string strcomID, string vstrItemName, string vstrLocation, string voucherDate = "")
        {

            string strSQL;
            string conDb;
            double dblclosing = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            if (voucherDate != "")
            {
                //strSQL = "SELECT ISNULL(STOCKITEM_CLOSING_BALANCE,0) AS CLOSING FROM INV_STOCKITEM_CLOSING ";
                //strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName.Replace("'","''") + "' ";
                //strSQL = strSQL + "AND GODOWNS_NAME = '" + vstrLocation + "' ";
                strSQL = "SELECT ISNULL(SUM(INV_TRAN_QUANTITY),0) AS CLOSING FROM INV_TRAN ";
                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName.Replace("'", "''") + "' ";
                strSQL = strSQL + "AND GODOWNS_NAME = '" + vstrLocation + "' ";
            }
            else
            {
                strSQL = "SELECT ISNULL(SUM(INWARD_QUANTITY-ABS(OUTWARD_QUANTITY)),0) AS CLOSING FROM INV_TRAN ";
                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName.Replace("'", "''") + "' ";
                strSQL = strSQL + "AND GODOWNS_NAME = '" + vstrLocation + "' ";
                if (voucherDate != "")
                {
                    strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(voucherDate) + " ";
                }
                strSQL = strSQL + "Union All ";
                strSQL = strSQL + "SELECT ISNULL(SUM(INV_TRAN_QUANTITY),0) AS CLOSING FROM INV_TRAN ";
                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName.Replace("'", "''") + "' ";
                strSQL = strSQL + "AND GODOWNS_NAME = '" + vstrLocation + "' ";
                if (voucherDate != "")
                {
                    strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(voucherDate) + " ";
                }
                strSQL = strSQL + "AND INV_VOUCHER_TYPE=0 ";

            }
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblclosing = Convert.ToDouble(dr["CLOSING"]);
                    return dblclosing;
                }
                else
                {
                    return 0;
                }

                dr.Close();
                gcnMain.Close();
            }
        }

        public static double gdblClosingStockNew(string strcomID, string vstrItemName, string vstrLocation, string voucherDate = "")
        {

            string strSQL;
            string conDb;
            
            double dblclosing = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            if (voucherDate != "")
            {
                strSQL = "SELECT sum(INV_TRAN_QUANTITY) CLOSING from INV_TRAN ";
                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName.Replace("'","''") + "' ";
                strSQL = strSQL + "AND GODOWNS_NAME = '" + vstrLocation + "' ";
            }
            else
            {
                strSQL = "SELECT ISNULL(SUM(INWARD_QUANTITY-ABS(OUTWARD_QUANTITY)),0) AS CLOSING FROM INV_TRAN ";
                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName.Replace("'", "''") + "' ";
                strSQL = strSQL + "AND GODOWNS_NAME = '" + vstrLocation + "' ";
                if (voucherDate != "")
                {
                    strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(voucherDate) + " ";
                }
                strSQL = strSQL + "Union All ";
                strSQL = strSQL + "SELECT ISNULL(SUM(INV_TRAN_QUANTITY),0) AS CLOSING FROM INV_TRAN ";
                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName + "' ";
                strSQL = strSQL + "AND GODOWNS_NAME = '" + vstrLocation + "' ";
                if (voucherDate != "")
                {
                    strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(voucherDate) + " ";
                }
                strSQL = strSQL + "AND INV_VOUCHER_TYPE=0 ";

            }
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblclosing = Convert.ToDouble(dr["CLOSING"]);
                    return dblclosing;
                }
                else
                {
                    return 0;
                }

                dr.Close();
                gcnMain.Close();
            }
        }
        public static double gdblGetBillTranQty(string strcomID, string vstrRefKey)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT BILL_QUANTITY as BILL_QUANTITY FROM ACC_BILL_TRAN WHERE BILL_TRAN_KEY = '" + vstrRefKey + "'";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return Math.Abs(Convert.ToDouble(dr["BILL_QUANTITY"].ToString()));
                }
                else
                {
                    return 0;
                }

                dr.Close();
                gcnMain.Close();



            }

        }

        public static double gdblGetBillQty(string strcomID, string vstrRefKey)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT INV_TRAN_QUANTITY as BILL_QUANTITY FROM INV_TRAN WHERE INV_TRAN_KEY = '" + vstrRefKey + "'";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return Math.Abs(Convert.ToDouble(dr["BILL_QUANTITY"].ToString()));
                }
                else
                {
                    return 0;
                }

                dr.Close();
                gcnMain.Close();



            }

        }
        public static string gstrGetBillKey(string strcomID, string vstrRefNo, string vstrItemName)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT BILL_TRAN_KEY as BILL_TRAN_KEY FROM ACC_BILL_TRAN WHERE STOCKITEM_NAME = '" + vstrItemName + "'";
            strSQL = strSQL + " AND COMP_REF_NO='" + vstrRefNo + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["BILL_TRAN_KEY"].ToString();
                }
                else
                {
                    return "";
                }

                dr.Close();
                gcnMain.Close();



            }
        }
        public static int gintManuFacGroup(string strcomID, string vstrPurchaseLedger)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_MANUFAC_GROUP FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrPurchaseLedger + "'";
            strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return Convert.ToInt32(dr["LEDGER_MANUFAC_GROUP"].ToString());
                }
                else
                {
                    return 0;
                }

                dr.Close();
                gcnMain.Close();



            }

        }
        public static int gintPurchaseValue(string strcomID, string vstrPurchaseLedger)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_GROUP FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrPurchaseLedger + "'";
            strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return Convert.ToInt32(dr["LEDGER_GROUP"].ToString());
                }
                else
                {
                    return 0;
                }

                dr.Close();
                gcnMain.Close();



            }

        }
        public static string gblnAuditTrail(string VstrUserName,
                               string vstrAuditDate,
                               string vstrAuditType,
                               string vstrAuditNo,
                               long vlngTxnType,
                               double vdblAmount,
                               int vsngModuleType,
                               string vstrBranchID, string vstrChangeNo="")
        {

            string strSQL, conDb;

            conDb = SQLConnstring();
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    strSQL = "INSERT INTO SYS_AUDIT(";
                    strSQL = strSQL + "AUDIT_DATE,AUDIT_TYPE,AUDIT_NO";
                    strSQL = strSQL + ",AUDIT_ADD_DATE,USER_LOGIN_NAME,AUDIT_TXN,AUDIT_AMOUNT,";
                    strSQL = strSQL + "MODULE_TYPE,BRANCH_ID";
                    if (vstrChangeNo !="")
                    {
                        strSQL = strSQL + ",CHANGE_NO";
                    }
                    strSQL = strSQL + ") ";
                    strSQL = strSQL + "VALUES";
                    strSQL = strSQL + "(";
                    strSQL = strSQL + "" + Utility.cvtSQLDateString(vstrAuditDate) + ",'" + vstrAuditType + "' ";
                    strSQL = strSQL + ",'" + vstrAuditNo + "'," + Utility.cvtSQLDateString(DateTime.Now.ToString("dd/MM/yyyy")) + ",'" + VstrUserName + "'";
                    strSQL = strSQL + "," + vlngTxnType + ", ";
                    strSQL = strSQL + "" + vdblAmount + ", ";
                    strSQL = strSQL + "" + vsngModuleType + ", ";
                    strSQL = strSQL + "'" + vstrBranchID + "' ";
                    if (vstrChangeNo != "")
                    {
                        strSQL = strSQL + ",'" + vstrChangeNo + "' ";
                    }
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    cmd.ExecuteNonQuery();
                    gcnMain.Close();
                    cmd.Dispose();
                    return "1";

                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                finally
                {


                }

            }

        }

        public static bool getPackSizeYeNo(string strcomID, string strGrName)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT STOCKGROUP_USE_PACK_SIZE FROM INV_STOCKGROUP ";
            strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + strGrName.Replace("'", "''") + "'";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Convert.ToInt32(dr["STOCKGROUP_USE_PACK_SIZE"]) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                dr.Close();
                gcnMain.Close();



            }

        }
        public static string gstrLastNumber(string strcomID, int vintVoucherType)
        {

            string strSQL, strPrefix = "", strSuffix = "", strstring = "";
            string conDb;
            long lngBegingNo, lngTotalVoucher;
            int intWidth;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT * FROM ACC_VOUCHER_TYPE ";
            strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + vintVoucherType + " ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strPrefix = dr["VOUCHER_TYPE_PREFIX"].ToString();
                    strSuffix = dr["VOUCHER_TYPE_SUFFIX"].ToString();
                    lngBegingNo = Convert.ToInt64(dr["VOUCHER_TYPE_BEGINING_NUMBER"]);
                    lngTotalVoucher = Convert.ToInt64(dr["VOUCHER_TYPE_TOTAL_VOUCHER"]);
                    intWidth = Convert.ToInt32(dr["VOUCHER_TYPE_NUMERIC_WIDTH"].ToString());

                    strstring = strPrefix.Trim() + (lngBegingNo + lngTotalVoucher).ToString().PadLeft(intWidth, '0') + strSuffix;
                    // gstrLastNumber = Trim$(strPrefix) & Format$(![VOUCHER_TYPE_BEGINING_NUMBER] + ![VOUCHER_TYPE_TOTAL_VOUCHER], String$(![VOUCHER_TYPE_NUMERIC_WIDTH], "0")) & strSuffix
                    return strstring;
                }
                else
                {
                    return "";
                }

                dr.Close();
                gcnMain.Close();
            }

        }

        public static string gGetDefaultBranch(string strcomID, string vstrDefaultName)
        {

            string strSQL, strBranchName = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT BRANCH_ID FROM ACC_BRANCH WHERE BRANCH_FLAG = 1 ";
            strSQL += " AND BRANCH_ID='" + vstrDefaultName + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strBranchName = "There are Default branch found in ID" + dr["BRANCH_ID"].ToString();
                }

                dr.Close();
                gcnMain.Close();
                return strBranchName;


            }

        }
        public static double gGetReceiptAmountVoucher(string strcomID, string strLedgerName, int intvoucherType, int intSpVoucher, string strFdate, string strTdate,string strMonthID)
        {

            string strSQL;
            double dblTotal = 0;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {

                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                strSQL = "SELECT ISNULL((NET_AMOUNT),0) AMNT FROM ACC_COMP_VOUCHER_TEMP ";
                strSQL = strSQL + "WHERE  COMP_VOUCHER_TYPE = " + intvoucherType + " ";
                strSQL = strSQL + " and LEDGER_NAME ='" + strLedgerName + "' ";
                //strSQL = strSQL + "  and COMP_VOUCHER_DATE between " + cvtSQLDateString(strFdate) + " ";
                //strSQL = strSQL + "  and  " + cvtSQLDateString(strTdate) + " ";
                strSQL = strSQL + " AND MONTH_ID='" + strMonthID + "' ";
                strSQL = strSQL + " ORDER BY COMP_VOUCHER_DATE DESC ";
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblTotal = Convert.ToDouble(dr["AMNT"]);
                }
                dr.Close();
                if (strMonthID != "")
                {
                    if (Left(strMonthID, 3).ToUpper() == "DEC")
                    {
                        return dblTotal;
                    }
                }
                strSQL = "SELECT isnull(sum(v.VOUCHER_CREDIT_AMOUNT),0) as total ";
                strSQL = strSQL + " from ACC_COMPANY_VOUCHER c,ACC_VOUCHER v where c.COMP_REF_NO=v.COMP_REF_NO ";
                strSQL = strSQL + "and c.COMP_VOUCHER_TYPE = " + intvoucherType + " ";
                strSQL = strSQL + " and c.LEDGER_NAME ='" + strLedgerName + "' ";
                strSQL = strSQL + "  and c.SP_JOURNAL =" + intSpVoucher + " ";
                strSQL = strSQL + "  and c.COMP_VOUCHER_DATE between " + cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "  and  " + cvtSQLDateString(strTdate) + " ";
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                        dblTotal = dblTotal + Convert.ToDouble(dr["total"]);
                }

                dr.Close();
                gcnMain.Close();
                return dblTotal;


            }

        }
        public static double gGetReceiptAmountOfParty(string strcomID, string strLedgerName, int intvoucherType, int intSpVoucher, string strFdate, string strTdate)
        {

            string strSQL;
            double dblTotal = 0, dblHLPFTotal = 0;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);





            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                strSQL = "SELECT ISNULL(SUM(NET_AMOUNT),0) total FROM ACC_COMP_VOUCHER_TEMP ";
                strSQL = strSQL + "WHERE  COMP_VOUCHER_TYPE = " + intvoucherType + " ";
                strSQL = strSQL + " and LEDGER_NAME ='" + strLedgerName + "' ";
                strSQL = strSQL + "  and COMP_VOUCHER_DATE between " + cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "  and  " + cvtSQLDateString(strTdate) + " ";
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblTotal = Convert.ToDouble(dr["total"]);
                }

                dr.Close();
                strSQL = "SELECT isnull(sum(v.VOUCHER_CREDIT_AMOUNT-v.VOUCHER_DEBIT_AMOUNT),0) as total ";
                strSQL = strSQL + " from ACC_COMPANY_VOUCHER c,ACC_VOUCHER v where c.COMP_REF_NO=v.COMP_REF_NO ";
                strSQL = strSQL + "and c.COMP_VOUCHER_TYPE = 3 AND  c.AUTOJV=1 ";
                strSQL = strSQL + " and v.LEDGER_NAME ='" + strLedgerName + "' ";
                strSQL = strSQL + "  and c.SP_JOURNAL =0 ";
                strSQL = strSQL + "  and c.COMP_VOUCHER_DATE between " + cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "  and  " + cvtSQLDateString(strTdate) + " ";
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblHLPFTotal = Convert.ToDouble(dr["total"]);
                }
                dr.Close();
                strSQL = "SELECT isnull(sum(v.VOUCHER_CREDIT_AMOUNT-v.VOUCHER_DEBIT_AMOUNT),0) as total ";
                strSQL = strSQL + " from ACC_COMPANY_VOUCHER c,ACC_VOUCHER v where c.COMP_REF_NO=v.COMP_REF_NO ";
                strSQL = strSQL + "and c.COMP_VOUCHER_TYPE = " + intvoucherType + " ";
                strSQL = strSQL + " and v.LEDGER_NAME ='" + strLedgerName + "' ";
                strSQL = strSQL + "  and c.SP_JOURNAL =" + intSpVoucher + " ";
                strSQL = strSQL + "  and c.COMP_VOUCHER_DATE between " + cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "  and  " + cvtSQLDateString(strTdate) + " ";
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblTotal = dblTotal + Convert.ToDouble(dr["total"]) + dblHLPFTotal;
                }

                dr.Close();
                gcnMain.Close();
                return dblTotal;


            }

        }
        public static string gGeCustomerHooeohall(string strcomID, string vstrLegdername)
        {

            string strSQL, strHomeo = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT HOMOEO_HALL as HOMOEO_HALL FROM ACC_LEDGER WHERE LEDGER_NAME = '" + vstrLegdername + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strHomeo = dr["HOMOEO_HALL"].ToString();
                }
                else
                {
                    strHomeo = "";
                }

                dr.Close();
                gcnMain.Close();
                return strHomeo;


            }

        }
        public static string gGeCustomerCode(string strcomID, string vstrLegdername)
        {

            string strSQL, strCode = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_CODE as LEDGER_CODE FROM ACC_LEDGER WHERE LEDGER_NAME = '" + vstrLegdername + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strCode = dr["LEDGER_CODE"].ToString();
                }
                else
                {
                    strCode = "";
                }
                dr.Close();
                gcnMain.Close();
                return strCode;


            }

        }
        public static string gGeCustomerAddress(string strcomID, string vstrLegdername)
        {

            string strSQL, strAddress = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_ADDRESS1 + ',' + LEDGER_ADDRESS2 as Address FROM ACC_LEDGER WHERE LEDGER_NAME = '" + vstrLegdername + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strAddress = dr["Address"].ToString();
                }

                dr.Close();
                gcnMain.Close();
                return strAddress;


            }

        }
        public static string gGetAppsCustomerMerze(string strcomID, string vstrLegdername, string vstrRefNo)
        {

            string strSQL, strName = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT APPS_CUSTOMER_MERZE FROM ACC_COMPANY_VOUCHER WHERE LEDGER_NAME = '" + vstrLegdername.Replace("'","''") + "' ";
            strSQL = strSQL + "AND COMP_REF_NO ='" + vstrRefNo + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strName = dr["APPS_CUSTOMER_MERZE"].ToString();
                }

                dr.Close();
                gcnMain.Close();
                return strName;


            }

        }
        public static string mGetItemDescription(string strcomID, string vstrItemName)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT STOCKITEM_DESCRIPTION FROM INV_STOCKITEM ";
            strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName.Replace("'","''") + "'";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return (dr["STOCKITEM_DESCRIPTION"].ToString());
                }
                else
                {
                    return "";
                }

                dr.Close();
                gcnMain.Close();



            }

        }
        public static string mGetPowerClass(string strcomID, string vstrItemName)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT POWER_CLASS FROM INV_STOCKITEM ";
            strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName + "'";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return (dr["POWER_CLASS"].ToString());
                }
                else
                {
                    return "";
                }

                dr.Close();
                gcnMain.Close();



            }

        }
        public static string mGetPackSize(string strcomID, string vstrItemName)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT STOCKCATEGORY_NAME FROM INV_STOCKITEM ";
            strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName + "'";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return (dr["STOCKCATEGORY_NAME"].ToString());
                }
                else
                {
                    return "";
                }

                dr.Close();
                gcnMain.Close();



            }

        }

        public static string mGetStockGroupFromItemGroup(string strcomID, string vstrItemName)
        {

            string strSQL;
            string conDb;
            int lnglong = 0;

            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT GR_NAME from INV_STOCKGROUP ";
            strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + vstrItemName + "' ";
            strSQL = strSQL + "AND GR_NAME is not null ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["GR_NAME"].ToString();
                }
                else
                {
                    return "";
                }

                dr.Close();
                gcnMain.Close();



            }

        }


        public static double mdblGetBonus(string strComID, string vstrItemName, string strBranchId, double vdblQty, string vdteDate)
        {

            string strSQL;
            string conDb;
            int lnglong=0;
            
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strComID );
            strSQL = "SELECT QTY,BONUS_QTY FROM INV_SALES_BONUS ";
            strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName.Replace("'","''") + "' ";
            strSQL = strSQL + "AND BONUS_EFFECTIVE_DATE <= " + Utility.cvtSQLDateString(vdteDate) + " ";
            strSQL = strSQL + "AND BRANCH_ID = " + strBranchId + " ";
            //strSQL = strSQL + "AND BONUS_QTY <= " + vdblQty + " ";
            strSQL = strSQL + "ORDER BY BONUS_EFFECTIVE_DATE DESC ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //return (vdblQty / (Convert.ToDouble(dr["QTY"]) * Convert.ToDouble(dr["BONUS_QTY"])));
                    lnglong = (int)(vdblQty / Convert.ToDouble(dr["QTY"]));
                    //lnglong = Convert.ToInt32(vdblQty / Convert.ToDouble(dr["QTY"]));
                    return lnglong * Convert.ToDouble(dr["BONUS_QTY"]);
                }
                else
                {
                    return 0;
                }

                dr.Close();
                gcnMain.Close();



            }

        }
        public static double mdblGetMaxCommiPercen(string strcomID, string vstrLedgerName, string vstrGroup, string strfDate, string strTadate, string strBranchID,string strVNo)
        {

            string strSQL;
            string conDb;

            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            try
            {
                strSQL = " SELECT isnull(max(ACC_BILL_TRAN.G_COMM_PER),0) G_COMM_PER  FROM ACC_COMPANY_VOUCHER,ACC_BILL_TRAN,INV_STOCKGROUP WHERE ";
                strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_REF_NO =ACC_BILL_TRAN.COMP_REF_NO AND ACC_BILL_TRAN.STOCKGROUP_NAME =INV_STOCKGROUP.STOCKGROUP_NAME ";
                strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.SALES_REP ='" + vstrLedgerName.Trim().Replace("'", "''") + "' AND INV_STOCKGROUP.GR_NAME ='" + vstrGroup.Trim().Replace("'", "''") + "' ";
                strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE  BETWEEN " + cvtSQLDateString(strfDate) + " and " + cvtSQLDateString(strTadate) + " ";
                strSQL = strSQL + " AND ACC_COMPANY_VOUCHER.BRANCH_ID ='" + strBranchID + "' ";
                if (strVNo !="")
                {
                    strSQL = strSQL + " AND ACC_COMPANY_VOUCHER.COMP_REF_NO <> '" + strVNo + "' ";
                }
                using (SqlConnection gcnMain = new SqlConnection(conDb))
                {
                    if (gcnMain.State == System.Data.ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }

                    gcnMain.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return (Convert.ToDouble(dr["G_COMM_PER"]));
                    }
                    else
                    {
                        return 0;
                    }

                    dr.Close();
                    gcnMain.Close();



                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        


        public static double mdblGetCommiPercen(string strcomID, string vstrGroup, double vdblQty,string strBranchID)
        {

            string strSQL;
            string conDb;
           
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL="select t.GROUP_PERCENTAGES  from INV_STOCKGROUP g,INV_GROUP_COMMISSION_MASTER m,INV_GROUP_COMMISSION_TRAN t ";
            strSQL=strSQL +"where m.GROUP_COMMISSION_KEY=t.GROUP_COMMISSION_KEY and m.STOCKGROUP_NAME=g.GR_NAME ";
            //and t.AMOUNT_FORM >=15 and t.AMOUNT_TO < 15
            strSQL=strSQL +"and " + vdblQty + " between t.AMOUNT_FORM and t.AMOUNT_TO ";
            strSQL = strSQL + "and m.STOCKGROUP_NAME='" + vstrGroup + "' ";
            strSQL = strSQL + "and m.BRANCH_ID='" + strBranchID + "' ";
            strSQL = strSQL + "order by m.EFFECTIVE_DATE desc ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return (Convert.ToDouble(dr["GROUP_PERCENTAGES"]));
                }
                else
                {
                    return 0;
                }

                dr.Close();
                gcnMain.Close();


            }

        }

        public static string gstrGetPrimary(string strcomID, string vstrUnder)
        {

            string strSQL, strPrimary = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT STOCKGROUP_PRIMARY FROM INV_STOCKGROUP ";
            strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + vstrUnder + "'";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strPrimary = dr["STOCKGROUP_PRIMARY"].ToString();
                }
                else
                {
                    strPrimary = "";
                }

                dr.Close();
                gcnMain.Close();
                return strPrimary;


            }

        }


        public static string mGetCompanyCreateDate(string strcomID)
        {

            string strSQL, strDate = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT COMPANY_CREATE_DATE FROM ACC_COMPANY ";

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strDate = Convert.ToDateTime(dr["COMPANY_CREATE_DATE"]).AddDays(-365).ToString();
                }
                else
                {
                    strDate = "01-01-1900";
                }

                dr.Close();
                gcnMain.Close();
                return strDate;


            }

        }
        public static string gGetLedgerNameFromMerze(string strcomID, string vstrLedgerName)
        {

            string strSQL, strLedgerName = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_NAME  FROM ACC_LEDGER WHERE LEDGER_NAME_MERZE  = '" + vstrLedgerName.Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strLedgerName = dr["LEDGER_NAME"].ToString();
                }
                else
                {
                    strLedgerName = "";
                }

                dr.Close();
                gcnMain.Close();
                return strLedgerName;


            }

        }
        public static string gGetLedgerNameMerze(string strcomID, string vstrLedgerName)
        {

            string strSQL,strLedgerName="";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_NAME_MERZE FROM ACC_LEDGER WHERE LEDGER_NAME  = '" + vstrLedgerName.Replace("'","''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strLedgerName= dr["LEDGER_NAME_MERZE"].ToString();
                }
                else
                {
                    strLedgerName= "";
                }

                dr.Close();
                gcnMain.Close();
                return strLedgerName;


            }

        }
        public static long gGetLedgergroup(string strcomID,string vstrLedgerName)
        {

            string strSQL;
            long lngGrp = 0;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_GROUP FROM ACC_LEDGER WHERE LEDGER_NAME  = '" + vstrLedgerName + "' ";
            //strSQL += "AND LEDGER_STATUS = 0 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lngGrp = Convert.ToInt64(dr["LEDGER_GROUP"].ToString());
                }
                else
                {
                    lngGrp = Convert.ToInt64(dr["LEDGER_GROUP"].ToString());
                }

                dr.Close();
                gcnMain.Close();
                return lngGrp;


            }

        }
        public static string gstrRemoveSpaceAndUCase(string vstrString)
        {
            return vstrString.Replace(" ", "");
        }

        public static string mstrGetLastBranch(string strcomID)
        {

            string strSQL, strbranchID = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT MAX(BRANCH_ID) +1 AS BRANCH_ID FROM ACC_BRANCH ORDER BY BRANCH_ID DESC";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strbranchID = dr["BRANCH_ID"].ToString().PadLeft(4, '0');
                }
                else
                {
                    strbranchID = "0001";
                }

                dr.Close();
                gcnMain.Close();
                return strbranchID;


            }

        }

        public static string gGetBaseUOM(string strcomID,string vstrItemName)
        {

            string strSQL, strUnit = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT STOCKITEM_BASEUNITS FROM INV_STOCKITEM WHERE STOCKITEM_NAME = '" + vstrItemName.Replace("'","''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strUnit = dr["STOCKITEM_BASEUNITS"].ToString();
                }


                dr.Close();
                gcnMain.Close();
                return strUnit;


            }

        }
        public static bool gbcheckBankLedger(string strcomID,string vstrLedgerName)
        {

            string strSQL;
            bool blngcheck = false;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_GROUP FROM ACC_LEDGER WHERE LEDGER_NAME  = '" + vstrLedgerName + "' ";
            strSQL += "AND LEDGER_STATUS = 0 ";
            strSQL += "AND LEDGER_GROUP= 100 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    blngcheck = true;
                }
                else
                {
                    blngcheck = false;
                }

                dr.Close();
                gcnMain.Close();
                return blngcheck;


            }

        }
        public static bool gbcheckBkashEffec(string strcomID, int intVoucherType)
        {

            string strSQL;
            bool blngcheck = false;
            string conDb;
            int intCheck = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT VOUCHER_TYPE_AUTO_MR_NO FROM ACC_VOUCHER_TYPE WHERE VOUCHER_TYPE_VALUE  = '" + intVoucherType + "' ";
            strSQL += "AND VOUCHER_TYPE_AUTO_MR_NO = 1 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    intCheck = Convert.ToInt32(dr["VOUCHER_TYPE_AUTO_MR_NO"]);
                    blngcheck = true;
                }
                else
                {
                    blngcheck = false;
                }


                dr.Close();
                gcnMain.Close();

                return blngcheck;


            }

        }
        public static bool gbcheckBkashLedger(string strcomID, string vstrLedgerName)
        {

            string strSQL;
            bool blngcheck = false;
            string conDb;
            int intCheck = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT BKASH_STATUS FROM ACC_LEDGER WHERE LEDGER_NAME  = '" + vstrLedgerName + "' ";
            strSQL += "AND BKASH_STATUS = 1 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    intCheck = Convert.ToInt32(dr["BKASH_STATUS"]);
                    blngcheck = true;
                }
                else
                {
                    intCheck = 0;
                    blngcheck = false;
                }
                

                dr.Close();
                gcnMain.Close();
                
                return blngcheck;


            }

        }
        public static string gGetRVReverseLedger(string strcomID, string vstrRefNo)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
           
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "SELECT LEDGER_NAME FROM ACC_VOUCHER WHERE COMP_REF_NO  = '" + vstrRefNo + "' ";
                strSQL += "AND VOUCHER_TOBY='Dr'";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["LEDGER_NAME"].ToString();
                }
                else
                {
                 return "";
                }


                dr.Close();
                gcnMain.Close();

            }

        }
        public static bool mblnInventoryEffect(string strcomID, string vstrLedgerName)
        {

            string strSQL;
            bool blngcheck = false;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_BILL_WISE FROM ACC_LEDGER WHERE LEDGER_NAME  = '" + vstrLedgerName + "' ";
            strSQL += "AND LEDGER_STATUS = 0 ";
            strSQL += "AND LEDGER_INVENTORY_AFFECT= 2 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    blngcheck = true;
                }
                else
                {
                    blngcheck = false;
                }

                dr.Close();
                gcnMain.Close();
                return blngcheck;


            }

        }
        public static bool mblnBillWise(string strcomID,string vstrLedgerName)
        {

            string strSQL;
            bool blngcheck = false;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_BILL_WISE FROM ACC_LEDGER WHERE LEDGER_NAME  = '" + vstrLedgerName + "' ";
            strSQL += "AND LEDGER_STATUS = 0 ";
            strSQL += "AND LEDGER_BILL_WISE= 2 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    blngcheck = true;
                }
                else
                {
                    blngcheck = false;
                }

                dr.Close();
                gcnMain.Close();
                return blngcheck;


            }

        }
        public static bool gbcheckCostCenter(string strcomID,string vstrLedgerName)
        {

            string strSQL;
            bool blngcheck = false;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_VECTOR FROM ACC_LEDGER WHERE LEDGER_NAME  = '" + vstrLedgerName + "' ";
            strSQL += "AND LEDGER_STATUS = 0 ";
            strSQL += "AND LEDGER_VECTOR= 2 ";
            strSQL += "AND LEDGER_GROUP <> 202 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    blngcheck = true;
                }
                else
                {
                    blngcheck = false;
                }

                dr.Close();
                gcnMain.Close();
                return blngcheck;


            }

        }


        public static bool gIsExistLedger(string strcomID,string vstrLedgerName)
        {

            string strSQL;
            bool blngcheck = false;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER WHERE LEDGER_NAME  = '" + vstrLedgerName.Replace("'","''") + "' ";
            //strSQL += "AND LEDGER_STATUS = 0 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    blngcheck = true;
                }
                else
                {
                    blngcheck = false;
                }

                dr.Close();
                gcnMain.Close();
                return blngcheck;


            }

        }


        public static string gstrGetBranchName(string strcomID,string vstrBranchID)
        {
            string strSQL = "", strBranchName = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT BRANCH_NAME FROM ACC_BRANCH WHERE BRANCH_ID  = '" + vstrBranchID + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strBranchName = dr["BRANCH_NAME"].ToString();
                }

                dr.Close();
                gcnMain.Close();
                return strBranchName;


            }

        }


        public static long mlngGetLedgerSerial(string strcomID,string vstrLedgerName)
        {
            long lngSlNo;
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_SERIAL FROM ACC_LEDGER WHERE LEDGER_NAME  = '" + vstrLedgerName + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lngSlNo = Convert.ToInt64(dr["LEDGER_SERIAL"].ToString());
                }
                else
                {
                    lngSlNo = 1;
                }
                dr.Close();
                gcnMain.Close();
                return lngSlNo;


            }

        }
        public static string gstrGetBranchID(string strcomID, string vstrBranchname)
        {
            string strID;
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT BRANCH_ID FROM ACC_BRANCH WHERE BRANCH_NAME  = '" + vstrBranchname + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strID = dr["BRANCH_ID"].ToString();
                }
                else
                {
                    strID = "";
                }
                dr.Close();
                if (strID=="")
                {
                    strID = gstrGetBranchIDfromGodown(strcomID,vstrBranchname);
                }
                gcnMain.Close();
                return strID;


            }

        }

        public static string gstrGetBranchIDfromGodown(string strcomID, string vstrBranchname)
        {
            string strID;
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT BRANCH_ID FROM INV_GODOWNS WHERE GODOWNS_NAME  = '" + vstrBranchname + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strID = dr["BRANCH_ID"].ToString();
                }
                else
                {
                    strID = "";
                }
                dr.Close();
                gcnMain.Close();
                return strID;


            }

        }
        public static long mlngFixedAsset(string vstrGroupName)
        {
            long lnggrp;
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstring();
            strSQL = "SELECT GR_GROUP FROM ACC_LEDGERGROUP WHERE GR_NAME = '" + vstrGroupName + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lnggrp = Convert.ToInt64(dr["GR_GROUP"].ToString());
                }
                else
                {
                    lnggrp = 0;
                }
                dr.Close();
                gcnMain.Close();
                return lnggrp;


            }

        }
        public static string mstrGetPrimary(string strcomID,string vstrUnder)
        {

            string strSQL, strcategory = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT STOCKCATEGORY_PRIMARY FROM INV_STOCKCATEGORY ";
            strSQL = strSQL + "WHERE STOCKCATEGORY_NAME = '" + vstrUnder + "'";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strcategory = dr["STOCKCATEGORY_PRIMARY"].ToString();
                }

                dr.Close();
                gcnMain.Close();
                return strcategory;

            }

        }
        public static string GetEndGroupStock(string strcomID,string sStart)
        {

            string strSQL, strcategory = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT STOCKGROUP_PRIMARY FROM INV_STOCKGROUP WHERE STOCKGROUP_NAME = '" + sStart + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strcategory = dr["STOCKGROUP_PRIMARY"].ToString();
                }
                else
                {
                    strcategory = "PRIMARY";
                }

                dr.Close();
                gcnMain.Close();
                return strcategory;

            }

        }
        public static long glngDeductGroupOpeningupdate(string strcomID,string vstrGroup, double vdblOpening)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "UPDATE ACC_LEDGERGROUP SET ";

            if (vdblOpening < 0)
            {
                strSQL = strSQL + "GR_OPENING_DEBIT = GR_OPENING_DEBIT - " + vdblOpening + ", ";
                strSQL = strSQL + "GR_CLOSING_DEBIT = GR_CLOSING_DEBIT - " + vdblOpening + " ";
                strSQL = strSQL + "WHERE GR_NAME = '" + vstrGroup + "' ";
                strSQL = strSQL + "AND  GR_OPENING_DEBIT <> 0 ";
            }
            else 
            {
                strSQL = strSQL + "GR_OPENING_CREDIT = GR_OPENING_CREDIT - " + vdblOpening + ", ";
                strSQL = strSQL + "GR_CLOSING_CREDIT = GR_CLOSING_CREDIT - " + vdblOpening + " ";
                strSQL = strSQL + "WHERE GR_NAME = '" + vstrGroup + "' ";
                strSQL = strSQL + "AND  GR_OPENING_CREDIT <> 0 ";

            }
            
           

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                cmd.ExecuteNonQuery();
                gcnMain.Close();
                return 1;


            }

        }

        public static long glngDeductGroupOpening(string strcomID,string vstrGroup, double vdblOpening)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "UPDATE ACC_LEDGERGROUP SET ";
            //if (vdblOpening < 0)
            //{
            //    strSQL = strSQL + "GR_OPENING_DEBIT = GR_OPENING_DEBIT - " + vdblOpening + " ";
            //}
            //else
            //{
            //    strSQL = strSQL + "GR_OPENING_CREDIT = GR_OPENING_CREDIT - " + vdblOpening + " ";
            //}

            //strSQL = strSQL + "WHERE GR_NAME = '" + vstrGroup + "'";

            if (vdblOpening < 0)
            {
                strSQL = strSQL + "GR_OPENING_DEBIT = GR_OPENING_DEBIT + " + vdblOpening + ", ";
                strSQL = strSQL + "GR_CLOSING_DEBIT = GR_CLOSING_DEBIT + " + vdblOpening + " ";
            }
            else 
            {
                strSQL = strSQL + "GR_OPENING_CREDIT = GR_OPENING_CREDIT + " + vdblOpening + ", ";
                strSQL = strSQL + "GR_CLOSING_CREDIT = GR_CLOSING_CREDIT + " + vdblOpening + " ";
            }
            strSQL = strSQL + "WHERE GR_NAME = '" + vstrGroup + "' ";

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                cmd.ExecuteNonQuery();
                gcnMain.Close();
                return 1;


            }

        }
        public static long glngAddGroupOpeninDebit(string strcomID,string vstrGroup, double dblopn,double dblcls)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "UPDATE ACC_LEDGERGROUP SET ";
            strSQL = strSQL + "GR_OPENING_DEBIT = " + dblopn + " ";
            strSQL = strSQL + ",GR_CLOSING_DEBIT = " + dblcls + " ";
            strSQL = strSQL + "WHERE GR_NAME = '" + vstrGroup + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                cmd.ExecuteNonQuery();
                gcnMain.Close();
                return 1;


            }

        }
        public static long glngAddGroupOpeninCredit(string strcomID,string vstrGroup, double dblopn, double dblcls)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "UPDATE ACC_LEDGERGROUP SET ";
            strSQL = strSQL + "GR_OPENING_CREDIT = " + dblopn + " ";
            strSQL = strSQL + ",GR_CLOSING_CREDIT = " + dblcls + " ";
            strSQL = strSQL + "WHERE GR_NAME = '" + vstrGroup + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                cmd.ExecuteNonQuery();
                gcnMain.Close();
                return 1;


            }

        }
        public static long glngAddGroupOpening(string strcomID,string vstrGroup, double vdblOpening)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "UPDATE ACC_LEDGERGROUP SET ";
            if (vdblOpening < 0)
            {
                strSQL = strSQL + "GR_OPENING_DEBIT = GR_OPENING_DEBIT + " + vdblOpening + " ";
            }
            else
            {
                strSQL = strSQL + "GR_OPENING_CREDIT = GR_OPENING_CREDIT + " + vdblOpening + " ";
            }

            strSQL = strSQL + "WHERE GR_NAME = '" + vstrGroup + "'";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                cmd.ExecuteNonQuery();
                gcnMain.Close();
                return 1;


            }

        }
        public static double gdblCreditLimit(string strcomID,string vstrLedgerName,string strMonthID)
        {

            string strSQL;
            string conDb;
            double dblCrditAmount = 0;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "SELECT ISNULL(CREDIT_LIMIT_AMOUNT,0) as CLAMOUNT  ";
                strSQL = strSQL + "FROM SALES_CREDIT_LIMIT WHERE LEDGER_NAME='" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND upper(CREDIT_LIMIT_MONTH_ID)='" + strMonthID.ToUpper() + "' ";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    dblCrditAmount = Utility.Val(rsGet["CLAMOUNT"].ToString());
                }
                else
                {
                    dblCrditAmount = 0;
                }
                rsGet.Close();
                gcnMain.Close();
                return dblCrditAmount;

            }
        }
        //public static double gdblCreditLimitGrace(string strcomID, string vstrLedgerName, string strMonthID,string strDate)
        //{

        //    string strSQL,strFDate="",strTDate="";
        //    string conDb;
        //    double dblCrditAmount = 0;
        //    conDb = SQLConnstringComSwitch(strcomID);

        //    using (SqlConnection gcnMain = new SqlConnection(conDb))
        //    {
        //        if (gcnMain.State == System.Data.ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();

        //        SqlDataReader rsGet;
        //        SqlCommand cmd = new SqlCommand();

        //        strSQL ="SELECT FROM_DATE,TO_DATE from ACC_COLL_MONTH_SETUP ";
        //        strSQL = strSQL + " WHERE  " +  cvtSQLDateString(strDate) + " between FROM_DATE and TO_DATE ";
        //        cmd.Connection = gcnMain;
        //        cmd.CommandText = strSQL;
        //        rsGet = cmd.ExecuteReader();
        //        if (rsGet.Read())
        //        {
        //            strFDate = rsGet["FROM_DATE"].ToString();
        //            strTDate = rsGet["TO_DATE"].ToString();
        //        }
        //        rsGet.Close();
        //        if (strFDate == "")
        //        {
        //            strSQL = "SELECT GRACE_FROM_DATE,GRACE_TO_DATE from ACC_COLL_MONTH_SETUP ";
        //            strSQL = strSQL + " WHERE  " + cvtSQLDateString(strDate) + " between GRACE_FROM_DATE and GRACE_TO_DATE ";
        //            cmd.Connection = gcnMain;
        //            cmd.CommandText = strSQL;
        //            rsGet = cmd.ExecuteReader();
        //            if (rsGet.Read())
        //            {
        //                strFDate = rsGet["GRACE_FROM_DATE"].ToString();
        //                strTDate = rsGet["GRACE_TO_DATE"].ToString();
        //            }

        //            rsGet.Close();
        //        }
        //        strSQL = "SELECT ISNULL(CREDIT_LIMIT_AMOUNT,0) as CLAMOUNT  ";
        //        strSQL = strSQL + "FROM SALES_CREDIT_LIMIT WHERE LEDGER_NAME='" + vstrLedgerName + "' ";
        //        strSQL = strSQL + "AND upper(CREDIT_LIMIT_MONTH_ID)='" + strMonthID.ToUpper() + "' ";
        //        strSQL = strSQL + "AND CREDIT_LIMIT_FROM_DATE>=" + Utility.cvtSQLDateString(strFDate) + " ";
        //        strSQL = strSQL + "AND CREDIT_LIMIT_TO_DATE <=" + Utility.cvtSQLDateString(strTDate) + " ";
        //        cmd.Connection = gcnMain;
        //        cmd.CommandText = strSQL;
        //        rsGet = cmd.ExecuteReader();
        //        if (rsGet.Read())
        //        {
        //            dblCrditAmount = Utility.Val(rsGet["CLAMOUNT"].ToString());
        //        }
        //        else
        //        {
        //            dblCrditAmount = 0;
        //        }
        //        rsGet.Close();
        //        gcnMain.Close();
        //        return dblCrditAmount;

        //    }
        //}
        public static double gdblCreditPeriod(string strcomID,string vstrLedgerName,
                                         string vdteDate)
        {

            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "SELECT LEDGER_CREDIT_PERIOD ";
                strSQL = strSQL + "FROM ACC_LEDGER WHERE LEDGER_NAME='" + vstrLedgerName + "' ";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    return Convert.ToDouble(rsGet["LEDGER_CREDIT_PERIOD"].ToString());
                }
                else
                {
                    return 0;
                }
                rsGet.Close();
                gcnMain.Close();

            }
        }
        public static double gdblBalanceBFLedger(string strcomID,string strLedgerName, string vstrFdate, string vdteDate)
        {

            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "SELECT isnull(sum(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) As Amnt ";
                strSQL = strSQL + "from ACC_LEDGER l,ACC_VOUCHER v where l.LEDGER_NAME =v.LEDGER_NAME and l.LEDGER_GROUP in (101,100) ";
                strSQL = strSQL + " AND  v.COMP_VOUCHER_DATE < " + cvtSQLDateString(vstrFdate) + " ";
                strSQL = strSQL + " AND  l.LEDGER_NAME = '" + strLedgerName.Replace("'","''") + "' ";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    return Convert.ToDouble(rsGet["Amnt"]);
                }
                else
                {
                    return 0;
                }
                rsGet.Close();
                gcnMain.Close();

            }
        }
        public static double gdblBalanceBF(string strcomID, string vstrFdate, string vdteDate)
        {

            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL="SELECT isnull(sum(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) As Amnt ";
                strSQL=strSQL +"from ACC_LEDGER l,ACC_VOUCHER v where l.LEDGER_NAME =v.LEDGER_NAME and l.LEDGER_GROUP in (101,100) ";
                strSQL = strSQL + " AND  v.COMP_VOUCHER_DATE < " + cvtSQLDateString(vstrFdate) + " ";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    return Convert.ToDouble(rsGet["Amnt"]);
                }
                else
                {
                    return 0;
                }
                rsGet.Close();
                gcnMain.Close();

            }
        }
        public static double gdblExpneseCash(string strcomID, long lngGroup, string vstrFdate, string vdteDate)
        {

            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "SELECT isnull(sum(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) As Amnt ";
                strSQL = strSQL + "from ACC_LEDGER l,ACC_VOUCHER v where l.LEDGER_NAME =v.LEDGER_NAME ";
                strSQL = strSQL + "and l.LEDGER_GROUP =" + lngGroup + " ";
                strSQL = strSQL + " AND v.VOUCHER_TOBY ='Dr'";
                strSQL = strSQL + " AND  v.COMP_VOUCHER_DATE BETWEEN " + cvtSQLDateString(vstrFdate) + " ";
                strSQL = strSQL + " AND  " + cvtSQLDateString(vdteDate) + " ";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    return Convert.ToDouble(rsGet["Amnt"]);
                }
                else
                {
                    return 0;
                }
                rsGet.Close();
                gcnMain.Close();

            }
        }
        public static double gdblExpneseBank(string strcomID, long lngGroup, string vstrFdate, string vdteDate)
        {

            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "SELECT isnull(sum(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) As Amnt ";
                strSQL = strSQL + "from ACC_LEDGER l,ACC_VOUCHER v where l.LEDGER_NAME =v.LEDGER_NAME ";
                strSQL = strSQL + "and l.LEDGER_GROUP =" + lngGroup + " ";
                strSQL = strSQL + " AND v.VOUCHER_TOBY ='Cr'";
                strSQL = strSQL + " AND  v.COMP_VOUCHER_DATE BETWEEN " + cvtSQLDateString(vstrFdate) + " ";
                strSQL = strSQL + " AND  " + cvtSQLDateString(vdteDate) + " ";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    return Convert.ToDouble(rsGet["Amnt"]);
                }
                else
                {
                    return 0;
                }
                rsGet.Close();
                gcnMain.Close();

            }
        }
        public static double gdblDisplayTemp(string strcomID, string strLedgername)
        {

            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "select isnull(SUM(CASH_AMOUNT),0)CASH_AMOUNT from ACC_LEDGER_EXPENSE_VIEW  ";
                strSQL = strSQL + "WHERE HEAD_NAME ='" + strLedgername + "' ";
                
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    return Convert.ToDouble(rsGet["CASH_AMOUNT"]);
                }
                else
                {
                    return 0;
                }
                rsGet.Close();
                gcnMain.Close();

            }
        }
        public static double gdblCasReceivedfromOthers(string strcomID, string strLedgername, int intvtype, string vstrFdate, string vdteDate)
        {

            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "SELECT isnull(sum(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) As Amnt ";
                strSQL = strSQL + "from ACC_LEDGER l,ACC_VOUCHER v where l.LEDGER_NAME =v.LEDGER_NAME ";
                strSQL = strSQL + "AND v.LEDGER_NAME ='" + strLedgername + "' ";
                strSQL = strSQL + "AND v.COMP_VOUCHER_TYPE =" + intvtype + " ";
                strSQL = strSQL + "AND v.VOUCHER_TOBY ='DR' ";
                strSQL = strSQL + " AND  v.COMP_VOUCHER_DATE between  " + cvtSQLDateString(vstrFdate) + " ";
                strSQL = strSQL + " AND  " + cvtSQLDateString(vdteDate) + " ";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    return Convert.ToDouble(rsGet["Amnt"]);
                }
                else
                {
                    return 0;
                }
                rsGet.Close();
                gcnMain.Close();

            }
        }
        public static double gdblCasReceivedfrommpo(string strcomID, string strLedgername, int intvtype, string vstrFdate, string vdteDate)
        {

            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "SELECT isnull(sum(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) As Amnt ";
                strSQL = strSQL + "from ACC_LEDGER l,ACC_VOUCHER v where l.LEDGER_NAME =v.LEDGER_NAME ";
                strSQL = strSQL + "AND v.LEDGER_NAME ='" + strLedgername + "' ";
                strSQL = strSQL + "AND v.COMP_VOUCHER_TYPE =" + intvtype + " ";
                strSQL = strSQL + " AND  v.COMP_VOUCHER_DATE between  " + cvtSQLDateString(vstrFdate) + " ";
                strSQL = strSQL + " AND  " + cvtSQLDateString(vdteDate) + " ";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    return Convert.ToDouble(rsGet["Amnt"]);
                }
                else
                {
                    return 0;
                }
                rsGet.Close();
                gcnMain.Close();

            }
        }
        public static double gdblReceived(string strcomID,long lngGroup, string vstrFdate, string vdteDate)
        {

            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "SELECT isnull(sum(v.VOUCHER_DEBIT_AMOUNT-v.VOUCHER_CREDIT_AMOUNT),0) As Amnt ";
                strSQL = strSQL + "from ACC_LEDGER l,ACC_VOUCHER v where l.LEDGER_NAME =v.LEDGER_NAME ";
                strSQL=strSQL + "and l.LEDGER_GROUP =" + lngGroup + " ";
                strSQL = strSQL + " AND  v.COMP_VOUCHER_DATE < " + cvtSQLDateString(vstrFdate) + " ";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    return Convert.ToDouble(rsGet["Amnt"]);
                }
                else
                {
                    return 0;
                }
                rsGet.Close();
                gcnMain.Close();

            }
        }
        public static string gdblGetFCSymbol(string strcomID,string vstrLedgerName,
                                          string vdteDate)
        {

            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "SELECT CURRENCY_SYMBOL  FROM SMA_FC_CONFIG ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName.Trim().Replace("'", "''") + "' ";
                strSQL = strSQL + "AND ";
                strSQL = strSQL + "(EFFECTIVE_DATE <= ";
                strSQL = strSQL + "" + Utility.cvtSQLDateString(vdteDate) + ") ";
                strSQL = strSQL + "ORDER BY EFFECTIVE_DATE DESC";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    return rsGet["CURRENCY_SYMBOL"].ToString();
                }
                else
                {
                    return "";
                }
                rsGet.Close();
                gcnMain.Close();

            }
        }
        public static double gdblGetFCRate(string strcomID,string vstrLedgerName,
                                           string vdteDate)
        {

            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "SELECT ISNULL(CURRENCY_RATE,0) AS CURRENCY_RATE  FROM SMA_FC_CONFIG ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName.Trim().Replace("'", "''") + "' ";
                strSQL = strSQL + "AND ";
                strSQL = strSQL + "(EFFECTIVE_DATE <= ";
                strSQL = strSQL + "" + Utility.cvtSQLDateString(vdteDate) + ") ";
                strSQL = strSQL + "ORDER BY EFFECTIVE_DATE DESC";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    return Convert.ToDouble(rsGet["CURRENCY_RATE"].ToString());
                }
                else
                {
                    return 0;
                }
                rsGet.Close();
                gcnMain.Close();

            }
        }
        public static double gdblGetEnterpriseSalesPrice(string strcomID,string vstrStockItem,
                                            string vdteDate,
                                            double dblqty,
                                            double dblCommission,
                                            string vstrPriceLevel = "")
        {

            string strSQL;
            string conDb;
            int mIntegretedSalesPrice = 0;
            double dblRate = 0;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "SELECT INTEGREATED_SALES_PRICE FROM ACC_NEW_CONFIG";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    mIntegretedSalesPrice = Convert.ToInt16(rsGet["INTEGREATED_SALES_PRICE"].ToString());
                }
                rsGet.Close();

                if (vstrPriceLevel != "")
                {
                    strSQL = "SELECT SALES_PRICE_AMOUNT,ACTUAL_DISCOUNT FROM INV_SALES_PRICE ";
                }
                else
                {
                    strSQL = "SELECT MAX(SALES_PRICE_AMOUNT) AS SALES_PRICE_AMOUNT,SALES_PRICE_EFFECTIVE_DATE,ACTUAL_DISCOUNT FROM INV_SALES_PRICE ";
                }
                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrStockItem.Trim().Replace("'", "''") + "' ";
                if (mIntegretedSalesPrice != 1)
                {
                    strSQL = strSQL + "AND MODULE_STATUS=0 ";
                }
                strSQL = strSQL + "AND ";
                strSQL = strSQL + "(SALES_PRICE_EFFECTIVE_DATE <= ";
                strSQL = strSQL + "" + Utility.cvtSQLDateString(vdteDate) + ") ";
                if (vstrPriceLevel != "")
                {
                    strSQL = strSQL + "AND PRICE_LEVEL_NAME='" + vstrPriceLevel.Replace("'", "''") + "' ";
                }
                strSQL = strSQL + "AND (INV_SALES_PRICE.FROM_QTY <=" + dblqty + " AND ";
                strSQL = strSQL + " INV_SALES_PRICE.TO_QTY >= " + dblqty + " ) ";
                if (vstrPriceLevel != "")
                {
                    strSQL = strSQL + "ORDER BY SALES_PRICE_EFFECTIVE_DATE DESC";
                }
                else
                {

                    strSQL = strSQL + "GROUP BY SALES_PRICE_EFFECTIVE_DATE,ACTUAL_DISCOUNT ";
                    strSQL = strSQL + "ORDER BY SALES_PRICE_EFFECTIVE_DATE DESC ";
                }
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    dblRate = Convert.ToDouble(rsGet["SALES_PRICE_AMOUNT"]);
                }
                else
                {
                    dblRate = 0;
                }
                gcnMain.Close();
                return dblRate;
            }
        }


        public static double gdblPurchasePrice(string strcomID,string vstrItemName,
                                           string vdteDate,
                                           string vstrGodownName = "")
        {

            string strSQL;
            string conDb;
            double dblRate = 0;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlDataReader rsGet;
                SqlCommand cmd = new SqlCommand();
                strSQL = "SELECT ISNULL(INV_TRAN_RATE,0) AS BILL_RATE  FROM INV_TRAN ";
                strSQL = strSQL + "WHERE  STOCKITEM_NAME = '" + vstrItemName.Replace("'","''") + "' ";
                strSQL = strSQL + "AND inv_voucher_type in (33)";//first opn + 2nd purchase
                strSQL = strSQL + "ORDER BY INV_DATE  DESC ";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                rsGet = cmd.ExecuteReader();
                if (rsGet.Read())
                {
                    dblRate = Convert.ToDouble(rsGet["BILL_RATE"]);
                }
                else
                {
                    dblRate = 0;
                }
                rsGet.Close();
                if (dblRate == 0)
                {
                    strSQL = "SELECT ISNULL(STOCKITEM_OPENING_RATE,0) AS BILL_RATE  FROM INV_STOCKITEM ";
                    strSQL = strSQL + "WHERE  STOCKITEM_NAME = '" + vstrItemName.Replace("'", "''") + "' ";
                    cmd.Connection = gcnMain;
                    cmd.CommandText = strSQL;
                    rsGet = cmd.ExecuteReader();
                    if (rsGet.Read())
                    {
                        dblRate = Convert.ToDouble(rsGet["BILL_RATE"]);
                    }
                    else
                    {
                        dblRate = 0;
                    }
                }
                //strSQL = "SELECT BILL_RATE,BILL_UOM,BILL_PER from INV_BILL_TRAN_DATE_QRY ";
                //strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName + "' ";
                //strSQL = strSQL + "AND COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(vdteDate) + " ";
                //strSQL = strSQL + "AND COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE + " ";
                //strSQL = strSQL + "ORDER BY COMP_VOUCHER_DATE DESC ";
                //cmd.Connection = gcnMain;
                //cmd.CommandText = strSQL;
                //rsGet = cmd.ExecuteReader();
                //if (rsGet.Read())
                //{
                //    dblRate = Convert.ToDouble(rsGet["BILL_RATE"]);
                //    if (rsGet["BILL_UOM"].ToString() != rsGet["BILL_PER"].ToString())
                //    {
                //        //    If gdblDenomation(vstrItemName) <> 0 Then
                //        //        gdblPurchasePrice = Format$(rsGetPrice.Fields("BILL_RATE").Value / gdblDenomation(vstrItemName), "######0.00")
                //        //    End If
                //        //End If
                //    }
                //}
                //else
                //{
                //    rsGet.Close();
                //    strSQL = "SELECT BILL_RATE,BILL_UOM,BILL_PER from INV_BILL_TRAN_DATE_COPY_PUR_PRICE ";
                //    strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName + "' ";
                //    strSQL = strSQL + "AND COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(vdteDate) + " ";
                //    strSQL = strSQL + "AND COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE + " ";
                //    strSQL = strSQL + "ORDER BY COMP_VOUCHER_DATE DESC ";
                //    cmd.Connection = gcnMain;
                //    cmd.CommandText = strSQL;
                //    rsGet = cmd.ExecuteReader();
                //    if (rsGet.Read())
                //    {
                //        dblRate = Convert.ToDouble(rsGet["BILL_RATE"]);
                //    }

                //}
                rsGet.Close();

                gcnMain.Close();
                return dblRate;
            }
        }



        public static string gInsertUpdateLog(string strcomID,string vstrMasterOld, double vdblOldOpening, string vstrMasterNew, double vdblNewOpening, string vstrMasterTable, string vstrMasterPK)
        {

            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "INSERT INTO ACC_UPDATE_LOG(MASTER_OLD,MASTER_OLD_OPENING,MASTER_NEW,MASTER_NEW_OPENING,MASTER_TABLE,MASTER_PRIMARY_FIELD) ";
                strSQL = strSQL + "VALUES";
                strSQL = strSQL + "(";
                strSQL = strSQL + "'" + vstrMasterOld + "',";
                strSQL = strSQL + " " + vdblOldOpening + ",";
                strSQL = strSQL + "'" + vstrMasterNew + "',";
                strSQL = strSQL + " " + vdblNewOpening + ",";
                strSQL = strSQL + "'" + vstrMasterTable + "',";
                strSQL = strSQL + "'" + vstrMasterPK + "' ";
                strSQL = strSQL + ")";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                cmd.ExecuteNonQuery();
                gcnMain.Close();
                return "1";
            }
        }




        public static string GetEndGroup(string strcomID, string sStart)
        {
            string strEngGroup;
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT GR_PRIMARY FROM ACC_LEDGERGROUP WHERE GR_NAME = '" + sStart + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strEngGroup = dr["GR_PRIMARY"].ToString();
                }
                else
                {
                    strEngGroup = "PRIMARY";
                }
                dr.Close();
                gcnMain.Close();
                return strEngGroup;
            }

        }

        public static string gCheckBackLock(string strcomID)
        {
            string strEngGroup;
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT BACK_LOCK_DATE FROM ACC_INVOICE_CONFIG WHERE BACK_LOCK_POSTING =1";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strEngGroup = dr["BACK_LOCK_DATE"].ToString();
                }
                else
                {
                    strEngGroup = "";
                }
                dr.Close();
                gcnMain.Close();
                return strEngGroup;
            }

        }
        public static double gdblGetPriorQty(string strcomID,string vstrItemKey)
        {
            string strSQL;
            string conDb;
            double dblRate = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            strSQL = "SELECT INV_TRAN_QUANTITY FROM INV_TRAN WHERE INV_TRAN_KEY = '" + vstrItemKey + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return Utility.Val(dr["INV_TRAN_QUANTITY"].ToString());
                }
                else
                {
                    return 0;
                }
                dr.Close();
                gcnMain.Close();
            }

            return dblRate;


        }
        public static double gdblGetCostPriceWeightAvg(string strcomID, string vstrItemName, string vdteDate)
        {
            string strSQL;
            string conDb;

            double dblRate = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();


                strSQL = "SELECT ISNULL(SUM(INV_TRAN_QUANTITY),0) AS QTY,ISNULL(SUM(INV_TRAN_AMOUNT),0) AS AMT FROM INV_STOCKITEM_TRAN_QRY ";
                //strSQL = strSQL + "WHERE (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') ";
                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName + "' ";
                strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(vdteDate) + " ";


                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Utility.Val(dr["QTY"].ToString()) > 0)
                    {
                        dblRate = Math.Round(Utility.Val(dr["AMT"].ToString()) / Utility.Val(dr["QTY"].ToString()), 4);
                    }
                }
                else
                {
                    dblRate = 0;
                }

                gcnMain.Close();
                cmd.Dispose();
            }

            dr.Close();

            return dblRate;

        }
        public static double gdblGetCostPriceReturn(string strcomID, string vstrItemName, string vdteDate)
        {
            string strSQL;
            string conDb;

            double dblRate = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();


                strSQL = "SELECT ISNULL(SUM(INV_TRAN_QUANTITY),0) AS QTY,ISNULL(SUM(INV_TRAN_AMOUNT),0) AS AMT FROM INV_STOCKITEM_TRAN_QRY ";
                strSQL = strSQL + "WHERE (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') ";
                strSQL = strSQL + "AND STOCKITEM_NAME = '" + vstrItemName + "' ";
                //strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(vdteDate) + " ";


                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Utility.Val(dr["QTY"].ToString()) > 0)
                    {
                        dblRate = Utility.Val(dr["AMT"].ToString()) / Utility.Val(dr["QTY"].ToString());
                    }
                }
                else
                {
                    dblRate = 0;
                }

                gcnMain.Close();
                cmd.Dispose();
            }

            dr.Close();

            return dblRate;

        }
        public static double gdblGetOpeningRate(string strcomID, string vstrItemName, string vdteDate)
        {
            string strSQL;
            string conDb;

            double dblRate = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();


                strSQL = "SELECT ISNULL(SUM(STOCKITEM_OPENING_RATE),0) AS QTY FROM INV_STOCKITEM ";
                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName.Trim().Replace("'", "''") + "' ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Utility.Val(dr["QTY"].ToString()) > 0)
                    {
                        dblRate = Math.Round(Utility.Val(dr["QTY"].ToString()), 2);
                    }
                }
                else
                {
                    dblRate = 0;
                }

                gcnMain.Close();
                cmd.Dispose();
            }

            dr.Close();

            return dblRate;

        }
        public static double gdblGetCostPrice(string strcomID,string vstrItemName, string vdteDate)
        {
            string strSQL;
            string conDb;

            double dblRate = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();


                strSQL = "SELECT ISNULL(SUM(INV_TRAN_QUANTITY),0) AS QTY,ISNULL(SUM(INV_TRAN_AMOUNT),0) AS AMT FROM INV_STOCKITEM_TRAN_QRY ";
                strSQL = strSQL + "WHERE (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') ";
                strSQL = strSQL + "AND STOCKITEM_NAME = '" + vstrItemName.Trim().Replace("'","''") + "' ";
                strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(vdteDate) + " ";


                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Utility.Val(dr["QTY"].ToString()) > 0)
                    {
                        dblRate = Math.Round(Utility.Val(dr["AMT"].ToString()) / Utility.Val(dr["QTY"].ToString()),2);
                    }
                }
                else
                {
                    dblRate = 0;
                }

                gcnMain.Close();
                cmd.Dispose();
            }

            dr.Close();

            return dblRate;

        }
        public static double gdblGetCostPriceNew(string strcomID,string vstrItemName, string vdteDate)
        {
            string strSQL;
            string conDb;

            double dblRate = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();


                strSQL = "SELECT ISNULL(SUM(INV_TRAN_QUANTITY),0) AS QTY,ISNULL(SUM(INV_TRAN_AMOUNT),0) AS AMT FROM INV_STOCKITEM_TRAN_QRY ";
                //strSQL = strSQL + "WHERE (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') ";
                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName + "' ";
                strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(vdteDate) + " ";


                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Utility.Val(dr["QTY"].ToString()) > 0)
                    {
                        dblRate = Math.Round(Utility.Val(dr["AMT"].ToString()) / Utility.Val(dr["QTY"].ToString()),2);
                    }
                }
                else
                {
                    dblRate = 0;
                }

                gcnMain.Close();
                cmd.Dispose();
            }

            dr.Close();

            return dblRate;

        }
        public static string gstrLedgerBalance(string strcomID,string vstrLedgerName)
        {
            double dblExpenses = 0;
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT ISNULL(LEDGER_CLOSING_BALANCE,0) AS LEDGER_CLOSING_BALANCE FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName.Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblExpenses = Utility.Val(dr["LEDGER_CLOSING_BALANCE"].ToString());
                }
                else
                {
                    dblExpenses = 0;
                }
                dr.Close();
                gcnMain.Close();
                if (dblExpenses < 0)
                {
                    return Math.Abs(dblExpenses) + " Dr";
                }
                else if (dblExpenses > 0)
                {
                    return Math.Abs(dblExpenses) + " Cr";
                }
                else
                {
                    return "0";
                }


            }

        }
        public static double gGetdblLedgerClosingBalance(string strDeComID, string strFdate, string strTDate,
                                                    string vstrLedgerName, string strBranchID)
        {
            string strSQL = null;
            string connstring;
            double dblBackYearOpening = 0, dblOPening = 0, dblYearOpening = 0, dblclosing = 0;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;
                if (strBranchID == "")
                {
                    strSQL = "SELECT LEDGER_OPENING_BALANCE *-1 AS OPENING FROM ACC_LEDGER ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                }
                else
                {
                    strSQL = "SELECT BRANCH_LEDGER_OPENING_BALANCE *-1 AS OPENING FROM ACC_BRANCH_LEDGER_OPENING ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName.Replace("'", "''") + "' ";
                    if (strBranchID != "")
                    {
                        strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                    }
                }

                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblOPening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) *-1  AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + "INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE >= ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + "";
                strSQL = strSQL + " AND  ";
                strSQL = strSQL + " ACC_VOUCHER.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFdate) + " ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0)  AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + " INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE < ";
                strSQL = strSQL + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + " ";
                strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrASSET + " OR ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrLIABILITY + " ) ";

                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblBackYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();


                dblOPening = dblYearOpening + dblBackYearOpening + dblOPening;

                if (dblOPening < 0)
                {
                    dblclosing = dblOPening;
                }
                else
                {
                    dblclosing = dblOPening;
                }

                //strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT),0) AS TOTAL_CREDIT,";
                //strSQL = strSQL + "ISNULL(SUM(VOUCHER_DEBIT_AMOUNT),0) AS TOTAL_DEBIT ";
                //strSQL = strSQL + "FROM ACC_VOUCHER ";
                //strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                //strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN ";
                //strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + " ";
                //strSQL = strSQL + "AND ";
                //strSQL = strSQL + " " + Utility.cvtSQLDateString(strTDate) + ") ";
                //if (strBranchID != "")
                //{
                //    strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                //}
                //cmdInsert.CommandText = strSQL;
                //dr = cmdInsert.ExecuteReader();
                //if (dr.Read())
                //{
                //    dblTotalCredit = Convert.ToDouble(dr["TOTAL_CREDIT"].ToString());
                //    dblTotalDebit = Convert.ToDouble(dr["TOTAL_DEBIT"].ToString());
                //}
                //dr.Close();
                //dblclosing = dblOPening + (dblTotalCredit - dblTotalDebit);

                //dr.Close();
                gcnMain.Close();
                cmdInsert.Dispose();
                return dblclosing;

            }
        }
        public static string gstrGetCommCal(string strDeComID, string vstrRefNo)
        {
            string strSQL = null,strYesNo="No";
            string connstring;
           

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;

                strSQL = "SELECT APPS_COMM_CAL FROM ACC_COMPANY_VOUCHER ";
                strSQL = strSQL + "WHERE COMP_REF_NO = '" + vstrRefNo + "' ";
               

                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["APPS_COMM_CAL"].ToString() == "1")
                    {
                        strYesNo= "Yes";
                    }
                    else
                    {
                        strYesNo= "No";
                    }
                }
                dr.Close();

              
                dr.Close();
                gcnMain.Close();
                cmdInsert.Dispose();
                return strYesNo;

            }
        }
        public static double dblLedgerClosingBalance(string strDeComID, string strFdate, string strTDate,
                                                    string vstrLedgerName, string strBranchID)
        {
            string strSQL = null;
            string connstring;
            double dblBackYearOpening = 0, dblOPening = 0, dblYearOpening = 0, dblOpeningDr = 0, dblOpeningCr = 0,
                                       dblTotalCredit = 0, dblTotalDebit = 0, dblclosing = 0;
           
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;
                if (strBranchID == "")
                {
                    strSQL = "SELECT LEDGER_OPENING_BALANCE AS OPENING FROM ACC_LEDGER ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                }
                else
                {
                    strSQL = "SELECT BRANCH_LEDGER_OPENING_BALANCE AS OPENING FROM ACC_BRANCH_LEDGER_OPENING ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName.Replace("'", "''") + "' ";
                    if (strBranchID != "")
                    {
                        strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                    }
                }

                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblOPening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + "INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE >= ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + "";
                strSQL = strSQL + " AND  ";
                strSQL = strSQL + " ACC_VOUCHER.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFdate) + " ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + " INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE < ";
                strSQL = strSQL + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + " ";
                strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrASSET + " OR ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrLIABILITY + " ) ";

                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblBackYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();


                dblOPening = dblYearOpening + dblBackYearOpening + dblOPening;

                if (dblOPening < 0)
                {
                    dblOpeningDr = dblOPening;
                }
                else
                {
                    dblOpeningCr = dblOPening;
                }
                ///Sales Invoice Credit Limit
                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT),0) AS TOTAL_CREDIT,";
                strSQL = strSQL + "ISNULL(SUM(VOUCHER_DEBIT_AMOUNT),0) AS TOTAL_DEBIT ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strTDate) + ") ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblTotalCredit = Convert.ToDouble(dr["TOTAL_CREDIT"].ToString());
                    dblTotalDebit = Convert.ToDouble(dr["TOTAL_DEBIT"].ToString());
                }
                //dr.Close();
                dblclosing = dblOPening + (dblTotalCredit - dblTotalDebit);

                dr.Close();
                gcnMain.Close();
                cmdInsert.Dispose();
                return dblclosing;

            }
        }
        public static double dblLedgerOpBalanceNew(string strDeComID, string strFdate, string strTDate,
                                                   string vstrLedgerName, string strBranchID)
        {
            string strSQL = null;
            string connstring;
            double dblBackYearOpening = 0, dblOPening = 0, dblYearOpening = 0, dblOpeningDr = 0, dblOpeningCr = 0,
                                       dblTotalCredit = 0, dblTotalDebit = 0, dblclosing = 0;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;
                if (strBranchID == "")
                {
                    strSQL = "SELECT LEDGER_OPENING_BALANCE AS OPENING FROM ACC_LEDGER ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                }
                else
                {
                    strSQL = "SELECT BRANCH_LEDGER_OPENING_BALANCE AS OPENING FROM ACC_BRANCH_LEDGER_OPENING ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName.Replace("'", "''") + "' ";
                    if (strBranchID != "")
                    {
                        strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                    }
                }

                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblOPening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + "INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE >= ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + "";
                strSQL = strSQL + " AND  ";
                strSQL = strSQL + " ACC_VOUCHER.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFdate) + " ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + " INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE < ";
                strSQL = strSQL + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + " ";
                strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrASSET + " OR ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrLIABILITY + " ) ";

                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblBackYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();





                dblOPening = dblYearOpening + dblBackYearOpening + dblOPening;

                if (dblOPening < 0)
                {
                    dblOpeningDr = dblOPening;
                }
                else
                {
                    dblOpeningCr = dblOPening;
                }
                ///////Sales Invoice Credit Limit
                ////strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT),0) AS TOTAL_CREDIT,";
                ////strSQL = strSQL + "ISNULL(SUM(VOUCHER_DEBIT_AMOUNT),0) AS TOTAL_DEBIT ";
                ////strSQL = strSQL + "FROM ACC_VOUCHER ";
                ////strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                ////strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN ";
                ////strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + " ";
                ////strSQL = strSQL + "AND ";
                ////strSQL = strSQL + " " + Utility.cvtSQLDateString(strTDate) + ") ";
                ////if (strBranchID != "")
                ////{
                ////    strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                ////}
                ////cmdInsert.CommandText = strSQL;
                ////dr = cmdInsert.ExecuteReader();
                ////if (dr.Read())
                ////{
                ////    dblTotalCredit = Convert.ToDouble(dr["TOTAL_CREDIT"].ToString());
                ////    dblTotalDebit = Convert.ToDouble(dr["TOTAL_DEBIT"].ToString());
                ////}
                //////dr.Close();
                dblclosing = dblOPening + (dblTotalCredit - dblTotalDebit);

                dr.Close();
                gcnMain.Close();
                cmdInsert.Dispose();
                return dblclosing;

            }
        }
        public static string cvtSQLDate(DateTime vdteDate)
        {
            string strdate;
            strdate = string.Format("{0}-{1}-{2}", vdteDate.Day, vdteDate.Month, vdteDate.Year);
            strdate = "Convert (DateTime  ,'" + strdate + "', 103)";

            return strdate;
        }
        public static string cvtSQLDateString(string vdteDate)
        {
            string strdate;
            //strdate = string.Format("{0}-{1}-{2}", vdteDate.Day, vdteDate.Month, vdteDate.Year);
            strdate = "Convert (DateTime  ,'" + vdteDate + "', 103)";

            return strdate;
        }

        public static string cvtSQLDateStringnew(string vdteDate)
        {
            string strYear,strMonth,strday,strDate="";

            //strdate = string.Format("{0}-{1}-{2}", vdteDate.Day, vdteDate.Month, vdteDate.Year);
           // strdate = "Convert (DateTime  ,'" + vdteDate + "', 103)";
            strYear = Utility.Left(vdteDate, 4);
            strMonth = vdteDate.Substring(4, 2);
            strday = Utility.Right(vdteDate, 2);
            strDate = strday + "/" + strMonth + "/" + strYear;
            return strDate;
        }
        public static string cvtSQLTime(string vstrTime)
        {
            string strTime;
            //strdate = string.Format("{0}-{1}-{2}", vdteDate.Day, vdteDate.Month, vdteDate.Year);
            strTime = "Convert (DateTime  ,'" + vstrTime + "', 100)";

            return strTime;
        }
        public static DataGridView CreateDataGrid(DataGridView datagrid, Panel panel1, TextBox textbox1)
        {


            //datagrid.Size = new System.Drawing.Size(100, 100);
            datagrid.BorderStyle = BorderStyle.FixedSingle;
            datagrid.BackColor = Color.Thistle;
            datagrid.Top = textbox1.Top + 25;
            datagrid.Left = textbox1.Left;
            datagrid.Width = textbox1.Width;
            panel1.Controls.Add(datagrid);
            datagrid.BringToFront();
            return datagrid;
        }
        public static ListBox CreateListBoxHeight(ListBox listBox1, Panel panel1, TextBox textbox1, int lngwidth = 0, int intheight = 0)
        {
            int lngwiwth = (int)(textbox1.Width) + lngwidth;
            //listBox1.Location = new System.Drawing.Point(12, 12); 
            listBox1.Size = new System.Drawing.Size(100, 100);
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            //listBox1.BackColor = Color.Thistle;
            listBox1.BackColor = Color.LightCyan;
            listBox1.Top = textbox1.Top + 25;
            listBox1.Left = textbox1.Left;
            listBox1.Width = lngwiwth;
            listBox1.Height = intheight;
            //listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            listBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            panel1.Controls.Add(listBox1);
            listBox1.BringToFront();
            return listBox1;
        }
        public static ListBox CreateListBox(ListBox listBox1, Panel panel1, TextBox textbox1, int lngwidth = 0)
        {
            int lngwiwth = (int)(textbox1.Width) + lngwidth;
            //listBox1.Location = new System.Drawing.Point(12, 12); 
            listBox1.Size = new System.Drawing.Size(100, 100);
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            //listBox1.BackColor = Color.Thistle;
            listBox1.BackColor = Color.LightCyan;
            listBox1.Top = textbox1.Top + 25;
            listBox1.Left = textbox1.Left;
            listBox1.Width = lngwiwth;
            //listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            listBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            panel1.Controls.Add(listBox1);
            listBox1.BringToFront();
            return listBox1;
        }
        public static string GetDgValue(DataGridView DG, TextBox textbox1, int lngwidth)
        {
            int lngwiwth = (int)(textbox1.Width) + lngwidth;
            string strName = "";
            //DG.Size = new System.Drawing.Size(100, 100);
            DG.BorderStyle = BorderStyle.FixedSingle;
            DG.BackColor = Color.Thistle;
            DG.Top = textbox1.Top + 25;
            DG.Left = textbox1.Left;

            //DG.Location = new Point(textbox1.Left, textbox1.Top + 25);
            DG.Width = lngwiwth;
            // DG.Height = lngwiwth;
            // panel1.Controls.Add(listBox1);
            DG.BringToFront();
            if (DG.Rows.Count > 0)
            {

                int i = Convert.ToInt16(DG.CurrentRow.Index.ToString());
                strName = DG.Rows[i].Cells[0].Value.ToString();
            }

            return strName;
        }
        public static string DateFormat(DateTime vdteDate)
        {
            string strdate;
            strdate = string.Format("{0}-{1}-{2}", vdteDate.Day, vdteDate.Month, vdteDate.Year);
            return strdate;
        }

        public static string gstrGetDatetoString(string vdteDate)
        {
            string strdate;
            strdate = vdteDate.Substring(0, 10);

            return strdate;
        }

        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            string result = param.Substring(startIndex, length);
            //return the result of the operation
            return result;
        }
        public enum DateInterval
        {
            Year,
            Month,
            Weekday,
            Day,
            Hour,
            Minute,
            Second
        }


        public static long DateDiff(DateInterval interval, DateTime date1, DateTime date2)
        {

            TimeSpan ts = date2 - date1; 
            //if (dt1 > dt2)
            //{
            //    TimeSpan ts = dt2 - dt1;
            //    return Convert.ToDecimal(ts.TotalMinutes);
            //}
            //else
            //{
            //    return 0;
            //}
            switch (interval)
            {
                case DateInterval.Year:
                    return date2.Year - date1.Year;
                case DateInterval.Month:
                    return (date2.Month - date1.Month) + (12 * (date2.Year - date1.Year));
                case DateInterval.Weekday:
                    return Fix(ts.TotalDays) / 7;
                case DateInterval.Day:
                    return Fix(ts.TotalDays);
                case DateInterval.Hour:
                    return Fix(ts.TotalHours);
                case DateInterval.Minute:
                    return Fix(ts.TotalMinutes);
                default:
                    return Fix(ts.TotalSeconds);
            } 


        }
        private static long Fix(double Number)
        {
            if (Number >= 0)
            {
                return (long)Math.Floor(Number);
            }
            return (long)Math.Ceiling(Number);
        } 
        public static decimal WorkingHour(DateInterval interval, DateTime dt1, DateTime dt2)
        {

            TimeSpan ts = dt2 - dt1;
            return Convert.ToDecimal(ts.TotalMinutes);

        }
        public static string PropercaseFirst(string s)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(s);
            //// Check for empty string.
            //if (string.IsNullOrEmpty(s))
            //{
            //    return string.Empty;
            //}
            //// Return char and concat substring.
            //return char.ToUpper(s[0]) + s.Substring(1);
        }


        public static bool IsNumeric(string input)
        {
            if (input == "")
            {
                return true;
            }
            double test;
            return double.TryParse(input, out test);
        }


        public class Age
        {
            public int Year { set; get; }
            public int Month { set; get; }
            public int Day { set; get; }
            public int Hour { set; get; }
        }
        public static string CalculateAge(DateTime Bday)
        {
            Age age = new Age();
            DateTime Cday = DateTime.Today;
            string strage = "";
            if ((Cday.Year - Bday.Year) > 0 ||
               (((Cday.Year - Bday.Year) == 0) && ((Bday.Month < Cday.Month) ||
               ((Bday.Month == Cday.Month) && (Bday.Day <= Cday.Day)))))
            {
                int DaysInBdayMonth = DateTime.DaysInMonth(Bday.Year, Bday.Month);
                int DaysRemain = Cday.Day + (DaysInBdayMonth - Bday.Day);

                if (Cday.Month > Bday.Month)
                {
                    age.Year = Cday.Year - Bday.Year;
                    age.Month = Cday.Month - (Bday.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    age.Day = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                    strage = age.Year + "yr(s)," + age.Month + "month(s,)" + age.Day + "day(s)";
                }
                else if (Cday.Month == Bday.Month)
                {
                    if (Cday.Day >= Bday.Day)
                    {
                        age.Year = Cday.Year - Bday.Year;
                        age.Month = 0;
                        age.Day = Cday.Day - Bday.Day;
                        strage = age.Year + " yr(s)," + age.Month + " month(s,)" + age.Day + " day(s)";
                    }
                    else
                    {
                        age.Year = (Cday.Year - 1) - Bday.Year;
                        age.Month = 11;
                        age.Day = DateTime.DaysInMonth(Bday.Year, Bday.Month) - (Bday.Day - Cday.Day);
                        strage = age.Year + " yr(s)," + age.Month + " month(s,)" + age.Day + " day(s)";
                    }
                }
                else
                {
                    age.Year = (Cday.Year - 1) - Bday.Year;
                    age.Month = Cday.Month + (11 - Bday.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    age.Day = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                    strage = age.Year + " yr(s)," + age.Month + " month(s,)" + age.Day + " day(s)";
                }
            }
            else
            {


                throw new ArgumentException("Birthday date must be earlier than current date");
            }
            return strage;
        }









        public static DataGridViewTextBoxColumn Create_Grid_Column(string pname, string htext, int cwidth, Boolean true_false, DataGridViewContentAlignment Align,
                                                                Boolean read_only)
        {
            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.DataPropertyName = pname;
            col0.HeaderText = htext;
            col0.DefaultCellStyle.ForeColor = Color.Black;
            col0.DefaultCellStyle.BackColor = Color.White;
            col0.Visible = true_false;
            col0.DefaultCellStyle.Alignment = Align;
            col0.Width = cwidth;
            col0.ReadOnly = read_only;
            return col0;
        }

        public static DataGridViewCheckBoxColumn CreateChkBxGrd(string pname, string htext, int cwidth, Boolean visibility, DataGridViewContentAlignment Algin, bool IsReadOnly, bool Isfrozen, string columnType)
        {
            DataGridViewCheckBoxColumn Ckbox = new DataGridViewCheckBoxColumn();
            Ckbox.DataPropertyName = pname;
            Ckbox.HeaderText = htext;
            Ckbox.Name = pname;
            Ckbox.DefaultCellStyle.ForeColor = Color.Black;
            Ckbox.DefaultCellStyle.BackColor = Color.White;
            Ckbox.Visible = visibility;
            Ckbox.DefaultCellStyle.Alignment = Algin;
            Ckbox.Width = cwidth - 1;
            Ckbox.ReadOnly = IsReadOnly;
            Ckbox.Frozen = Isfrozen;
            return Ckbox;

        }
        public static DataGridViewButtonColumn Create_Grid_Column_button(string pname, string htext, string btext, int cwidth, Boolean true_false,
            DataGridViewContentAlignment Align, Boolean read_only)
        {
            DataGridViewButtonColumn col0 = new DataGridViewButtonColumn();
            col0.DataPropertyName = pname;
            col0.HeaderText = htext;
            col0.Text = btext;
            //col0.DefaultCellStyle.ForeColor = Color.Red;
            //col0.DefaultCellStyle.BackColor = Color.White;
            col0.Visible = true_false;
            col0.DefaultCellStyle.Alignment = Align;
            col0.Width = cwidth;
            col0.ReadOnly = read_only;
            return col0;
        }

        public static DataGridViewImageColumn Create_Grid_Column_Image(string pname, string htext, string btext, int cwidth, Boolean true_false,
            DataGridViewContentAlignment Align, Boolean read_only)
        {
            DataGridViewImageColumn col0 = new DataGridViewImageColumn();
            col0.DataPropertyName = pname;
            col0.HeaderText = htext;
            col0.Name = btext;
            col0.DefaultCellStyle.ForeColor = Color.Red;
            col0.DefaultCellStyle.BackColor = Color.White;
            col0.Visible = true_false;
            col0.DefaultCellStyle.Alignment = Align;
            col0.Width = cwidth;
            col0.ReadOnly = read_only;
            col0.ImageLayout = DataGridViewImageCellLayout.Normal;
            return col0;
        }
        //public static double val(string strdouble)
        //{
        //    if (strdouble == "")
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToDouble(strdouble);
        //    }
        //}

        public static double Val(string expression)
        {
            if (expression == null)
                return 0;

            //try the entire string, then progressively smaller substrings to replicate the behavior of VB's 'Val', which ignores trailing characters after a recognizable value:
            for (int size = expression.Length; size > 0; size--)
            {
                double testDouble;
                if (double.TryParse(expression.Substring(0, size), out testDouble))
                    return testDouble;
            }

            //no value is recognized, so return 0:
            return 0;
        }
        public static String SQLcomID()
        {
            
            //string strComID = (from item in Utility.Modules select item).FirstOrDefault();
            //strDatabaseName = "SMART" + strComID;
            //RegistryKey RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, (Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32));
            //RegistryView platformView = (Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
            //RegistryKey registryBase = RegistryKey.OpenBaseKey( RegistryHive.CurrentUser, platformView);
            //RegistryKey registryEntry = registryBase.OpenSubKey("SmartAccounts");
            //if (registryEntry == null)
            //{
            //    registryBase.Close();
            //    return "";
            //}
            //string strComID = (String)registryEntry.GetValue("CompanyID", "");
            RegistryKey regKey1 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\SmartAccounts");
            string strComID = (String)regKey1.GetValue("CompanyID");
            return strComID;

        }
        public static String SQLConnstringWcf()
        {
            string strDatabaseName = "";
            string strComID  = (from item in Utility.Modules select item).FirstOrDefault();
            if (strComID=="")
            {
                strComID = "0003";
            }
            strDatabaseName = "SMART" + strComID;
            return "Data Source=" + gGetServerName() + " ;Initial Catalog= " + strDatabaseName + ";User ID=" + gstDatabaserUserName + " ;Password=" + gstDatabasePassword + " ";
            //return "Data Source=" + gstrInstanceName + " ;Initial Catalog= " + strDatabaseName + ";User ID=" + gstDatabaserUserName + " ;Password=" + gstDatabasePassword + " ";


        }
        public static void GetComID(string id)
        {
            Utility.gstrCompanyID = id;
        }


        public static String SQLConnstringComSwitch(string strComID)
        {
            string strDatabaseName = "";
            //Data Source=190.190.200.100,1433;Network Library=DBMSSOCN; Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;
            strDatabaseName = "SMART" + strComID;
            return "Data Source=" + gGetServerName() + " ;Initial Catalog= " + strDatabaseName + ";User ID=" + gstDatabaserUserName + " ;Password=" + gstDatabasePassword + " ";


        }


        public static String SQLConnstring()
        {
            string strDatabaseName = "", strComID="";
            RegistryKey regKey1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey1.GetValue("CompanyID", "0001");
            strDatabaseName = "SMART" + strComID;
            return "Data Source=" + gGetServerName() + " ;Initial Catalog= " + strDatabaseName + ";User ID=" + gstDatabaserUserName + " ;Password=" + gstDatabasePassword + " ";


        }

        public static String ODBCConnstring()
        {
            string strDatabaseName = "SMART" + Interaction.GetSetting(Application.ExecutablePath, "sCompany", "sName", "0001");
            //return  "Data Source=" + gGetServerName() + " ;Initial Catalog= " + strDatabaseName + ";User ID=" + GlobalVariable.gstrUserName + " ;Password=" + GlobalVariable.gstrpassword + " ";;
            return "Driver={SQL Server};Server=" + gGetServerName() + ";DataBase=" + strDatabaseName + " ;Uid=" + gstDatabaserUserName + " ;Pwd=" + gstDatabasePassword + ";";

        }


        //public static String gopenDatabaseConnection
        //   {
        //          get
        //       {
        //           GlobalVariable.gcnMain = "Data Source=" + gGetServerName() + " ;Initial Catalog= " + gGetDatabaseName() + ";User ID=" + GlobalVariable.gstDatabaserUserName + " ;Password=" + GlobalVariable.gstrpassword  + " ";
        //              return GlobalVariable.gcnMain ;
        //          }
        //       set 
        //       {
        //           GlobalVariable.gcnMain = "Data Source=" + gGetServerName() + " ;Initial Catalog= " + gGetDatabaseName() + ";User ID=" + GlobalVariable.gstDatabaserUserName + " ;Password=" + GlobalVariable.gstrpassword + " ";
        //       }
        //   }
        //public static string gGetDatabaseName()
        //{
        //    //Interaction.SaveSetting(App.EXEName, "textboxes", "textbox1", textbox1.Text);

        //    GlobalVariable.strDataBase = Interaction.GetSetting(Application.ExecutablePath, "sCompany", "sName", "0001");
        //    //RegistryKey regKey = Registry.CurrentUser.CreateSubKey("sCompany");
        //   // GlobalVariable.strDataBase = (String)regKey.GetValue("sCompany");
        //    return GlobalVariable.strDataBase;
        //}
        //public static string creaateWrite(string strCompID)
        //{
        //    string strPath = @"D:";
        //    string FileName = strPath + "\\COMPID.txt";
            
        //        using (StreamWriter newTask = new StreamWriter("COMPID.txt", true))
        //        {
        //            newTask.WriteLine(strCompID);
        //        }

        //        FileStream objFile = new FileStream(FileName, FileMode.Create, FileAccess.Write);
        //        StreamWriter objWriter = new StreamWriter(objFile);
        //        //gstrInstanceName = Microsoft.VisualBasic.Interaction.InputBox("Input a valid ServerName", "Server Name", " ", 250, 250);
        //        gstrInstanceName = strCompID;
        //        objWriter.Write(gstrInstanceName);
        //        objWriter.Close();
        //        return gstrInstanceName;
           
           
        //}
        //public static string createRead()
        //{

        //    string strPath = @"D:";
        //    string FileName = strPath + "\\COMPID.txt";
        //    if (System.IO.File.Exists(FileName) == true)
        //    {
        //       // string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");

        //        using (StreamReader sr = new StreamReader(FileName))
        //        {
        //            gstrInstanceName = sr.ReadLine();
        //            if (gstrInstanceName == null)
        //            {
        //                return "0001";
        //            }
        //            else
        //            {
        //                return gstrInstanceName;
        //            }
        //        }

        //    }
        //    else
        //    {
        //        gstrInstanceName = "0001";
        //    }
        //    return gstrInstanceName;
           
        //}
        public static string gGetServerName()
        {

            //string strPath = Environment.CurrentDirectory;
            //string FileName = strPath + "\\Server.txt";
            //if (System.IO.File.Exists(FileName) == true)
            //{
            //    using (StreamReader sr = new StreamReader(FileName))
            //    {
            //        gstrInstanceName = sr.ReadLine();
            //        return gstrInstanceName;
            //    }
            //}
            //else
            //{
            //    FileStream objFile = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            //    StreamWriter objWriter = new StreamWriter(objFile);
            //    gstrInstanceName = Microsoft.VisualBasic.Interaction.InputBox("Input a valid ServerName", "Server Name", " ", 250, 250);
            //    objWriter.Write(gstrInstanceName);
            //    objWriter.Close();
            //    return gstrInstanceName;
            //}
            //return @"192.168.31.223";//local
            //return @"192.168.1.83\DEEPLAID";//local
            //return @"192.168.1.150";//backup
            return @"KAWSIR";
            //return @"192.168.0.10\DEEPLAID";
            
        }


        public static string gstrGetpading(string Prefix)
        {

            int i;
            for (i = 1; i <= 4; i++)
            {
                if (Prefix.Length == 1)
                {
                    Prefix = "000" + Prefix;
                }
                else if (Prefix.Length == 2)
                {
                    Prefix = "00" + Prefix;
                }
                else if (Prefix.Length == 3)
                {
                    Prefix = "0" + Prefix;
                }
                else if (Prefix.Length == 4)
                {
                    return Prefix;
                }
            }

            return Prefix;
        }






        public static string InsertExecutue(string strSQL, string strConn)
        {

            using (SqlConnection gcnMain = new SqlConnection(strConn))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();


                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    return "1";

                }
                catch (SqlException ex)
                {
                    return "0";
                    //return (ex.Message.ToString());
                }
                finally
                {

                    gcnMain.Close();
                    gcnMain.Dispose();
                }
            }
        }

        public static string InsertOdbcExecutue(string strSQL, string strConn)
        {

            using (OdbcConnection gcnMain = new OdbcConnection(strConn))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();



                    OdbcCommand cmdInsert = new OdbcCommand();
                    OdbcTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    return "1";

                }
                catch (Exception ex)
                {

                    return ex.ToString();
                    throw;
                }
                finally
                {


                    gcnMain.Close();
                    gcnMain.Dispose();
                }
            }
        }

        public static OdbcDataReader ExecuteReaderodbc(string strSQL, string strConn)
        {
            OdbcDataReader reader;
            using (OdbcConnection conn = new OdbcConnection(strConn))
            {
                OdbcCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                try
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    //conn.Close();
                }
            }
            return reader;
        }

        public static DataSet ExecuteDatatable(string strSQL, string strConn)
        {
            SqlDataAdapter oda;
            DataSet ds;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.Connection = conn;
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                oda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                conn.Close();
                oda.Fill(ds);
                return ds;
            }
        }







        //public static string  gGetSelctCompnay()
        //{
        //    OdbcDataReader rdr;
        //    string strSQL="",strcheck="";
        //    string connstring = ODBCConnstring();
        //     strSQL = "SELECT * FROM ACC_COMPANY ";
        //     using (OdbcConnection conn = new OdbcConnection(connstring))
        //    {
        //        conn.Open();
        //        OdbcCommand cmd = new OdbcCommand(strSQL, conn);
        //        rdr = cmd.ExecuteReader();
        //        if (rdr.Read())
        //        {
        //            gstrCompanyID = rdr["COMPANY_ID"].ToString();
        //            gstrCompanyName = rdr["COMPANY_NAME"].ToString();
        //            gstrCompanyAddress1 = rdr["COMPANY_ADD1"].ToString();
        //            gstrCompanyAddress2 = rdr["COMPANY_ADD2"].ToString();
        //            gstrPhoneNo = rdr["COMPANY_PHONE"].ToString();
        //            gstrFinicialYearFrom = rdr["COMPANY_FINICIAL_YEAR_FROM"].ToString();
        //            gstrFinicialYearTo = rdr["COMPANY_FINICIAL_YEAR_TO"].ToString();
        //            lngAccessControl = Convert.ToInt64 (rdr["COMPANY_ACCESS_CONTROL"].ToString());

        //            if (lngAccessControl==1)
        //            {
        //                gblnAccessControl = false;
        //            }
        //            else

        //            {
        //                gblnAccessControl = true;

        //            }

        //            strcheck="1";
        //        }
        //        return strcheck;
        //        rdr.Close();
        //        conn.Close();
        //    }

        //}


        public static long glngGetBusinessType(string vstrBType)
        {
            //vstrBType = vstrBType ;
            switch (vstrBType)
            {
                case "Trading Company":
                    return 1;
                case "Real Estate":
                    return 2;
                case "Educational Institution":
                    return 3;
                case "Manufacturing Company":
                    return 4;
                case "Drug Store":
                    return 5;
                case "Motel/Hotel":
                    return 6;
                case "Non-Profit Company":
                    return 7;
                case "Hospital":
                    return 8;
                case "POS":
                    return 9;
                default:
                    return 10;
            }
        }

        public static void ClearForm(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }

                if (c.HasChildren)
                {
                    ClearForm(c);
                }

                if (c is CheckBox)
                {

                    ((CheckBox)c).Checked = false;
                }

                if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
                if (c is ComboBox)
                {
                    if (((ComboBox)c).Items.Count > 0)
                        ((ComboBox)c).SelectedIndex = 0;
                }
            }
        }


        public static string gstrDateToStr(string vstrDate)
        {
            string strYear = "", intMonth = "", intDay = "";
            if (vstrDate != "")
            {
                strYear = Convert.ToDateTime(vstrDate).ToString("yyyy");
                intMonth = Convert.ToDateTime(vstrDate).ToString("MM");
                intDay = Convert.ToDateTime(vstrDate).ToString("dd");
            }
            return (strYear + intMonth.PadRight(2, '0') + intDay.PadRight(2, '0'));
        }


        public static string Encrypt(string toEncrypt, string key)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);



            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                //of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray = cTransform.TransformFinalBlock
                    (toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);


        }

        public static string Decrypt(string cipherString, string key)
        {
            bool useHashing = true;
            byte[] keyArray;

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock
                    (toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);


        }

        public static string gSelectCompanyName(string strcomID,string strUserControl )
        {

            string strSQL, strBranchName = "";
            string conDb;
            //long lngAccessControl = 0;
            SqlDataReader dr;
            conDb = Utility.SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT * FROM ACC_COMPANY ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //strBranchName = "There are Default branch found in ID" + dr["BRANCH_ID"].ToString();
                    Utility.gstrCompanyID = dr["COMPANY_ID"].ToString();
                    Utility.gstrBranchID = dr["BRANCH_ID"].ToString();
                    Utility.gstrCompanyName = dr["COMPANY_NAME"].ToString();
                    if (dr["COMPANY_ADD1"].ToString() != "")
                    {
                        Utility.gstrCompanyAddress1 = dr["COMPANY_ADD1"].ToString();
                    }
                    else
                    {
                        Utility.gstrCompanyAddress1 = "";
                    }

                    if (dr["COMPANY_ADD2"].ToString() != "")
                    {
                        Utility.gstrCompanyAddress2 = dr["COMPANY_ADD2"].ToString();
                    }
                    else
                    {
                        Utility.gstrCompanyAddress2 = "";
                    }
                    if (dr["COMPANY_COUNTRY"].ToString() != "")
                    {
                        Utility.gstrCounty = dr["COMPANY_COUNTRY"].ToString();
                    }
                    else
                    {
                        Utility.gstrCounty = "";
                    }
                    if (dr["COMPANY_FAX"].ToString() != "")
                    {
                        Utility.gstrFax = dr["COMPANY_FAX"].ToString();
                    }
                    else
                    {
                        Utility.gstrFax = "";
                    }
                    Utility.gstrFinicialYearFrom = Utility.gstrDateToStr(dr["COMPANY_FINICIAL_YEAR_FROM"].ToString());
                    Utility.gstrFinicialYearTo = Utility.gstrDateToStr(dr["COMPANY_FINICIAL_YEAR_TO"].ToString());
                    Utility.gdteFinancialYearFrom = dr["COMPANY_FINICIAL_YEAR_FROM"].ToString();
                    Utility.gdteFinancialYearTo = dr["COMPANY_FINICIAL_YEAR_TO"].ToString();
                    Utility.gstrBaseCurrency = dr["COMPANY_BASE_CURRENCY_SYMBOL"].ToString();
                    if (dr["COMPANY_BRANCH"].ToString() == "1")
                    {
                        Utility.gblnBranch = true;
                    }
                    else
                    {
                        Utility.gblnBranch = false;
                    }
                    //if (Utility.gblnBranch)
                    //{
                    //    mlngBranchOption = 2;
                    //}
                    //else
                    //{
                    //    mlngBranchOption = 0;
                    //}

                    Utility.lngAccessControl = Convert.ToInt64(dr["COMPANY_ACCESS_CONTROL"].ToString());
                    if (dr["IS_INCOME_EXPENSES"].ToString() == "1")
                    {
                        Utility.gblnIncomeExpenses = true; ;
                    }
                    else
                    {
                        Utility.gblnIncomeExpenses = false; ;
                    }
                    if (dr["IS_MULTIPLE_CURRENCY"].ToString() == "1")
                    {
                        Utility.gblnMultipleCurrency = true; ;
                    }
                    else
                    {
                        Utility.gblnMultipleCurrency = false; ;
                    }
                    if (dr["IS_MULTIPLE_LOCATION"].ToString() == "1")
                    {
                        Utility.gblnLocation = true; ;
                    }
                    else
                    {
                        Utility.gblnLocation = false; ;
                    }

                    Utility.glngIntegrateInventory = Convert.ToInt64(dr["COMPANY_MAINTAIN"].ToString());
                    if (dr["MAINTAIN_BATCH"].ToString() == "0")
                    {
                        Utility.glngIsMaintainBatch = 2;
                    }
                    else
                    {
                        Utility.glngIsMaintainBatch = 1;
                    }

                    Utility.glngBusinessType = Convert.ToInt64(dr["COMPANY_BUSINESS_TYPE"].ToString());
                    Utility.glngIsMaintainBatch = Convert.ToInt64(dr["MAINTAIN_BATCH"].ToString());

                    Utility.gstrBaseCurrency = dr["COMPANY_BASE_CURRENCY_SYMBOL"].ToString();
                    if (Convert.ToInt64(dr["ITEM_PRODUCT_CODE_ACTIVE"].ToString()) == 1)
                    {
                        Utility.gblnStockItemAlias = true;
                    }
                    else
                    {
                        Utility.gblnStockItemAlias = false;
                    }
                    Utility.gstrCompanyPhone = dr["COMPANY_PHONE"].ToString();

                    if (Convert.ToInt64(dr["SINGLE_STOCK_TRANFER"].ToString()) == 1)
                    {
                        Utility.gblngSingleStockTransfer = true;
                    }
                    else
                    {
                        Utility.gblngSingleStockTransfer = false;
                    }
                    if (Convert.ToInt64(dr["DIFFERENT_STOCK_TRANFER"].ToString()) == 1)
                    {
                        Utility.gblngDifferentTransfer = true;
                    }
                    else
                    {
                        Utility.gblngDifferentTransfer = false;
                    }
                    if (Convert.ToInt64(dr["MANUFACTURING_SYSTEM"].ToString()) == 1)
                    {
                        Utility.gblngManufacturing = true;
                    }
                    else
                    {
                        Utility.gblngManufacturing = false;
                    }
                    if (dr["COMPANY_COMMENTS"].ToString() != "")
                    {
                        Utility.gstrComments = dr["COMPANY_COMMENTS"].ToString();
                    }
                    else
                    {
                        Utility.gstrComments = dr["COMPANY_COMMENTS"].ToString();
                    }
                    if (Convert.ToInt64(dr["BOOKING_INFORMATION"].ToString()) == 1)
                    {
                        Utility.gblngBookingInformation = true;
                    }
                    else
                    {
                        Utility.gblngBookingInformation = false;
                    }
                    if (Convert.ToInt64(dr["SLIP_SALES_INVOICE"].ToString()) == 1)
                    {
                        Utility.gblngSalesInvoiceSlip = true;
                    }
                    else
                    {
                        Utility.gblngSalesInvoiceSlip = false;
                    }
                    if (Convert.ToInt64(dr["ADMISSION_REAL_ESTATE"].ToString()) == 1)
                    {
                        Utility.gblngAdmissionRealEstate = true;
                    }
                    else
                    {
                        Utility.gblngAdmissionRealEstate = false;
                    }
                    if (Convert.ToInt64(dr["SINGLE_NARRATION"].ToString()) == 1)
                    {
                        Utility.gblngSingleNarration = true;
                    }
                    else
                    {
                        Utility.gblngSingleNarration = false;
                    }
                    if (Convert.ToInt64(dr["PHYSICAL_STOCK"].ToString()) == 1)
                    {
                        Utility.gblngPhysicalStock = true;
                    }
                    else
                    {
                        Utility.gblngPhysicalStock = false;
                    }
                    if (Convert.ToInt64(dr["APPROVED"].ToString()) == 1)
                    {
                        Utility.gblngApproved = true;
                    }
                    else
                    {
                        Utility.gblngApproved = false;
                    }


                    Utility.gstrBranchName = Utility.gstrGetBranchName(strcomID,Utility.gstrBranchID);
                    if (Utility.lngAccessControl == 1)
                    {
                        Utility.gblnAccessControl = false;
                    }
                    else
                    {
                        Utility.gblnAccessControl = true;
                    }
                    //if (Utility.gblnBranch)
                    //{
                    //    mlngBranchOption = 2;
                    //}
                    //else
                    //{
                    //    mlngBranchOption = 0;
                    //}
                }

                dr.Close();

                if (strUserControl.ToUpper()  == "YES")
                {
                    Utility.gblnAccessControl = true;
                    strSQL = "SELECT USER_LOGIN_NAME,USER_PASS,USER_LOGIN_NAME FROM USER_CONFIG ";
                    strSQL = strSQL + "WHERE USER_LOGIN_NAME <> '" + "Smart" + "' ";
                    strSQL = strSQL + "AND USER_LEBEL = 1 ";
                    strSQL = strSQL + "ORDER BY USER_LOGIN_SERIAL ASC ";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Utility.gstrOldUserName = dr["USER_LOGIN_NAME"].ToString();
                        Utility.gstrOldPassword = Utility.Decrypt(dr["USER_PASS"].ToString(), dr["USER_LOGIN_NAME"].ToString());
                    }

                }
                dr.Close();
                gcnMain.Close();
                return strBranchName;

            }

        }
        
        public static string gGetUSerAdmin(string strcomID)
        {

            string strSQL= "",strDatabase="";
            string conDb;
            //long lngAccessControl = 0;
            SqlDataReader dr;
            conDb = "Data Source=" + Utility.gGetServerName() + ";Initial Catalog=master;User ID=" + Utility.gstDatabaserUserName + " ;Password=" + Utility.gstDatabasePassword + " ";
            strDatabase="SMART" + strcomID ;
            strSQL = "SELECT NAME FROM master.dbo.sysdatabases WHERE NAME ='" + strDatabase + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                 SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                cmd.CommandText = strSQL;
                dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    return "";
                }
            }

            conDb = Utility.SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT USER_LOGIN_NAME,USER_PASS,USER_LOGIN_NAME FROM USER_CONFIG ";
            strSQL = strSQL + "WHERE USER_LOGIN_NAME <> '" + "Deeplaid" + "' ";
            strSQL = strSQL + "AND USER_LEBEL = 1 ";
            strSQL = strSQL + "ORDER BY USER_LOGIN_SERIAL ASC ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Utility.gstrOldUserName = dr["USER_LOGIN_NAME"].ToString();
                    Utility.gstrOldPassword = Utility.Decrypt(dr["USER_PASS"].ToString(), dr["USER_LOGIN_NAME"].ToString());
                }
                dr.Close();
                gcnMain.Close();
                Utility.gblnAccessControl = true;
                return Utility.gstrOldUserName;

            }

        }
        public static void PriorSetFocusText(TextBox txtbox, TextBox txtFocus)
        {
            if (txtbox.SelectionLength > 0)
            {
                txtbox.SelectionLength = 0;
                txtFocus.Focus();
            }
            if (txtbox.SelectionLength == 0 && txtbox.Text =="")
            {
                txtbox.SelectionLength = 0;
                txtFocus.Focus();
            }
        }
        public static long glngGetRefType(string vstrReference)
        {
            switch (vstrReference)
            {
                case "Advance":
                    return 1;
                case "Agst Ref":
                    return 2;
                case "New Ref":
                    return 3;
                case "On Account":
                    return 4;
                default:
                    return 0;
            }


        }
        public static string gstrGetRefName(int vstrType)
        {
            switch (vstrType)
            {
                case 1:
                    return "Advance";
                case 2:
                    return "Agst Ref";
                case 3:
                    return "New Ref";
                case 4:
                    return "On Account";
                default:
                    return "None";
            }


        }


        public static string gCheckNull(string vstrName)
        {

            if (vstrName == null)
                return "";

            if (vstrName != "")
            {
                return vstrName;
            }
            else
            {
                return "";
            }
        }


        public static string gstrGiftItem(string strcomID,string vstrItemName,
                                         string vdteDate,
                                         double vdblQty,
                                         double dblqty)
        {

            string strSQL, strGiftItem = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT STOCKITEM_NAME_GIFT,QTY,GIFT_QTY FROM INV_SALES_GIFT ";
            strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrItemName + "' ";
            strSQL = strSQL + "AND GIFT_EFFECTIVE_DATE <= " + Utility.cvtSQLDateString(vdteDate) + " ";
            strSQL = strSQL + "ORDER BY GIFT_EFFECTIVE_DATE DESC ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strGiftItem = dr["STOCKITEM_NAME_GIFT"].ToString();
                }
                else
                {
                    strGiftItem = "";
                }
                dr.Close();
                gcnMain.Close();
                return strGiftItem;
            }

        }
        public static string GetSalesLedger(string strcomID, string strRefNo)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_NAME ";
            strSQL = strSQL + "FROM ACC_VOUCHER WHERE COMP_REF_NO ='" + strRefNo.Trim().Replace("'", "''") + "' ";
            strSQL = strSQL + " AND COMP_VOUCHER_POSITION=2 ";
            strSQL = strSQL + " AND COMP_VOUCHER_TYPE=16 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["LEDGER_NAME"].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string GetLedgerNameMerze(string strcomID, string strName)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_NAME_MERZE ";
            strSQL = strSQL + "FROM ACC_LEDGER WHERE LEDGER_NAME ='" + strName.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["LEDGER_NAME_MERZE"].ToString();
                }
                else
                {
                    strString = "End of List";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string GetSalesInvoiceLastNo(string strcomID, string strPrefix)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT max(COMP_REF_NO) COMP_REF_NO FROM ACC_COMPANY_VOUCHER WHERE COMP_VOUCHER_TYPE =16 ";
            strSQL = strSQL + "AND COMP_REF_NO LIKE '%" + strPrefix + "%' ";
            strSQL = strSQL + "group by COMP_VOUCHER_SERIAL order by COMP_VOUCHER_SERIAL desc ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        strString = Utility.Mid(dr["COMP_REF_NO"].ToString(),6,dr["COMP_REF_NO"].ToString().Length-6);
                    }
                    else
                    {
                        strString = "";
                    }
                    dr.Close();
                    gcnMain.Dispose();
                    return strString;
                }
                catch (Exception ex)
                {
                    return "";
                }

            }
        }
        public static long GetslNoFItem(string strcomID, string strName)
        {
            string strSQL = "";
            string conDb;
            long lngSLNo;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT STOCKITEM_SERIAL  from INV_STOCKITEM WHERE STOCKITEM_NAME ='" + strName.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lngSLNo = Convert.ToInt64(dr["STOCKITEM_SERIAL"].ToString());
                }
                else
                {
                    lngSLNo = 0;
                }
                dr.Close();
                gcnMain.Dispose();
                return lngSLNo;

            }
        }
        public static string gstrGetLedgerAddress(string strcomID, string strName)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT (LEDGER_ADDRESS1+LEDGER_ADDRESS2) ADDR ";
            strSQL = strSQL + "FROM ACC_LEDGER WHERE LEDGER_NAME_MERZE ='" + strName.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["ADDR"].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string GetLedgerNameFromMerzeName(string strcomID, string strName)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_NAME ";
            strSQL = strSQL + "FROM ACC_LEDGER WHERE LEDGER_NAME_MERZE ='" + strName.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["LEDGER_NAME"].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string GetMerzeNameFromTeritorryCode(string strcomID, string strTc)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_NAME_MERZE ";
            strSQL = strSQL + "FROM ACC_LEDGER WHERE TERITORRY_CODE ='" + strTc.Trim().Replace("'", "''") + "' ";
            strSQL = strSQL + " AND LEDGER_STATUS =0 ";
            strSQL = strSQL + " AND LEDGER_GROUP =202 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["LEDGER_NAME_MERZE"].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string GetLedgerNameFromTeritorryCode(string strcomID, string strTc)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_NAME ";
            strSQL = strSQL + "FROM ACC_LEDGER WHERE TERITORRY_CODE ='" + strTc.Trim().Replace("'", "''") + "' ";
            strSQL = strSQL + " AND LEDGER_STATUS =0 ";
            strSQL = strSQL + " AND LEDGER_GROUP =202 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["LEDGER_NAME"].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string GetTeritorryCodeFromLedgerName(string strcomID,string strName)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT TERITORRY_CODE ";
            strSQL = strSQL + "FROM ACC_LEDGER WHERE LEDGER_NAME ='" + strName.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["TERITORRY_CODE"].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string GetCPCodeFromLedgerName(string strcomID, string strName)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_CODE ";
            strSQL = strSQL + "FROM ACC_LEDGER WHERE LEDGER_NAME ='" + strName.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["LEDGER_CODE"].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string GetstrReverseLegder(string strcomID, string strRefNo)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT VOUCHER_REVERSE_LEDGER ";
            strSQL = strSQL + "FROM ACC_VOUCHER WHERE COMP_REF_NO ='" + strRefNo.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["VOUCHER_REVERSE_LEDGER"].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string GetCPNameFromLedgerName(string strcomID, string strName)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT HOMOEO_HALL ";
            strSQL = strSQL + "FROM ACC_LEDGER WHERE LEDGER_NAME ='" + strName.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["HOMOEO_HALL"].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string GetTeritorryCode(string strcomID,string strName)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT TERITORRY_CODE ";
            strSQL = strSQL + "FROM ACC_TERITORRY WHERE TERITORRY_NAME ='" + strName.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["TERITORRY_CODE"].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
       
        public static void UpdateComID(string strcomID,string strUserName,string strCOMID)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "Update USER_CONFIG SET COMP_ID='" + strCOMID + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                cmd.ExecuteNonQuery();
                gcnMain.Dispose();
               

            }
        }
       
        public static string GetTeritorryName(string strcomID,string strCode)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT TERITORRY_NAME ";
            strSQL = strSQL + "FROM ACC_TERITORRY WHERE TERITORRY_CODE ='" + strCode.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["TERITORRY_NAME"].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string mCheckDuplicateItemPrice(string strcomID,string mstrPriceLevel, string strEffectivedate)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT *  FROM INV_SALES_PRICE ";
            strSQL = strSQL + "WHERE PRICE_LEVEL_NAME ='" + mstrPriceLevel + "' ";
            strSQL = strSQL + "AND SALES_PRICE_EFFECTIVE_DATE =" + Utility.cvtSQLDateString(strEffectivedate) + " ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = "Cannot Insert Duplicate Value";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string mGetValue(string strcomID, string strTableName, string strfield, string strValue)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT " + strfield + " ";
            strSQL = strSQL + "FROM " + strTableName + " WHERE " + strfield + " ='" + strValue.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    strString = strValue;
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string mCheckChallan(string strcomID, string strValue)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT  SUM(BILL_QUANTITY) FROM ACC_BILL_TRAN_PROCESS ";
            strSQL = strSQL + "WHERE AGST_COMP_REF_NO ='" + strValue + "' ";
            strSQL = strSQL + "HAVING SUM(BILL_QUANTITY) = 0  and count(COMP_REF_NO) >=2 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = "Cannot Insert Duplicate Value";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }

        public static long  mGetDeliveryDays(string strcomID, string strMpoName)
        {
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT LEDGER_CREDIT_PERIOD from ACC_LEDGER WHERE LEDGER_NAME='" + strMpoName + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return Convert.ToInt64(dr["LEDGER_CREDIT_PERIOD"]);
                }
                else
                {
                    return 0;
                }
                dr.Close();
                gcnMain.Dispose();
               

            }
        }
        public static string mCheckDuplicateItem(string strcomID,string strTableName, string strfield, string strValue)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT " + strfield + " ";
            strSQL = strSQL + "FROM " + strTableName + " WHERE " + strfield + " ='" + strValue.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = "Cannot Insert Duplicate Value";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string mGetCheckLedgerNamePresent(string strcomID, string strTableName, string strfield, string strfield1, string strValue, string strValue1)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT " + strfield + " ";
            strSQL = strSQL + "FROM " + strTableName + " WHERE " + strfield + " ='" + strValue.Trim().Replace("'", "''") + "' ";
            strSQL =strSQL + " AND " + strfield1 + " ='" + strValue1.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr[0].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string mGetCheckMpoCommission(string strcomID, string strTableName, string strfield, string strfield1, string strValue, string strValue1)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT " + strfield + " ";
            strSQL = strSQL + "FROM " + strTableName + " WHERE " + strfield + " ='" + strValue.Trim().Replace("'", "''") + "' ";
            strSQL = strSQL + " AND " + strfield1 + " ='" + strValue1.Trim().Replace("'", "''") + "' ";
            strSQL = strSQL + " AND SP_JOURNAL=1 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr[0].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string mGetRefNo(string strcomID,string strTableName, string strfield,string strfield1, string strValue)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT " + strfield + " ";
            strSQL = strSQL + "FROM " + strTableName + " WHERE " + strfield1 + " ='" + strValue.Trim().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr[0].ToString();
                }
                else
                {
                    strString = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string getDSMfromGrName(string strcomID,string strValue)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT GR_PARENT FROM ACC_LEDGERGROUP WHERE GR_NAME='" + strValue.ToString().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = dr["GR_PARENT"].ToString();
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static double mdblGetOpening(string strcomID,string strLedgerName)
        {
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT  isnull(LEDGER_OPENING_BALANCE,0) as LEDGER_OPENING_BALANCE  FROM ACC_LEDGER WHERE LEDGER_NAME='" + strLedgerName.ToString().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return Convert.ToDouble(dr["LEDGER_OPENING_BALANCE"]);
                }
                else
                {
                    return 0;
                }
                dr.Close();
                gcnMain.Dispose();
                

            }
        }
        public static double mdblPrePurchase(string strcomID,string strLedgerName, string vdteFromDate)
        {
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT ISNULL(SUM(VOUCHER_DEBIT_AMOUNT - VOUCHER_CREDIT_AMOUNT),0) AS AMOUNT ";
            strSQL = strSQL + "FROM ACC_VOUCHER WHERE LEDGER_NAME = '" + strLedgerName.ToString().Replace("'", "''") + "' ";
            strSQL = strSQL + "AND COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(vdteFromDate) + " ";

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return Convert.ToDouble(dr["AMOUNT"]);
                }
                else
                {
                    return 0;
                }
                dr.Close();
                gcnMain.Dispose();


            }
        }

       

        public static void InitialiseMainForm(Control mainFrom, string struserName, string strRoleName, string Department, 
                                                string Designation, byte[] vimage, UserWidgetMetro userWidget)
        {
            //GetEmpImage

            //UserImage oo = new UserImage();

            //Utility.CenterObject(mainPanel);
            //moduleNamePanel.Top = mainPanel.Top - (moduleNamePanel.Height + 20);
            //moduleNamePanel.Left = mainPanel.Left;
            //moduleNamePanel.Width = mainPanel.Width;

            
          
            userWidget.lblUserName.Text = struserName;
            userWidget.lblLogInAs.Text = "Login As: " + strRoleName;
            Size sz = new Size(380, 110);
            userWidget.Size = sz;
            //userWidget.Location = new Point(830, 114);
            userWidget.lblDesignation.Text = Department + "," + Designation;
            //userWidget.picUser.Image = new Bitmap(Utility.EmployeePhoto);

            userWidget.picUser.Image = null;
            if (vimage != null)
            {
                MemoryStream ms = new MemoryStream(vimage, 0, vimage.Length);
                ms.Write(vimage, 0, vimage.Length);
                userWidget.picUser.Image = Image.FromStream(ms, true); //Exception occurs here
                userWidget.picUser.SizeMode = PictureBoxSizeMode.StretchImage;
                userWidget.picUser.Image = Utility.ScaleImage(userWidget.picUser.Image, 100, 100);
            }

            Utility.PositionTopRight(mainFrom, userWidget, 0);
            //Utility.PositionBottomRight(mainFrom, dateWidget, 20);

        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }
        public static void PositionBottomRight(Control container, Control content)
        {
            Rectangle workingArea = Screen.GetWorkingArea(container);
            content.Location = new Point(workingArea.Right - content.Width, workingArea.Bottom - content.Height);
        }
        public static void PositionBottomRight(Control container, Control content, Int16 offset)
        {
            Rectangle workingArea = Screen.GetWorkingArea(container);
            content.Location = new Point(workingArea.Right - content.Width, workingArea.Bottom - offset - content.Height);
        }
        public static void PositionTopRight(Control container, Control content, Int16 offset)
        {
            Rectangle workingArea = Screen.GetWorkingArea(container);
            content.Location = new Point(workingArea.Right - content.Width + 20, workingArea.Top + offset);
        }

        public static void PositionCenter(Control container, Control content, Int16 offset)
        {
            Rectangle workingArea = Screen.GetWorkingArea(container);
            content.Location = new Point((workingArea.Width - content.Width) / 2, (workingArea.Height - content.Width) / 2);
        }

        public static void CenterObject(Control control)
        {
            Rectangle parentRect = control.Parent.ClientRectangle;
            control.Left = (parentRect.Width - control.Width) / 2;
            control.Top = (parentRect.Height - control.Height) / 2;

        }

        public static class GetAllMenuStripItems
        {
            #region Methods

            /// <summary>
            /// Gets a list of all ToolStripMenuItems
            /// </summary>
            /// <param name="menuStrip">The menu strip control</param>
            /// <returns>List of all ToolStripMenuItems</returns>
            public static List<ToolStripMenuItem> GetItems(MenuStrip menuStrip)
            {
                List<ToolStripMenuItem> myItems = new List<ToolStripMenuItem>();
                foreach (ToolStripMenuItem i in menuStrip.Items)
                {
                    GetMenuItems(i, myItems);
                }
                return myItems;
            }

            /// <summary>
            /// Gets the menu items.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <param name="items">The items.</param>
            private static void GetMenuItems(ToolStripMenuItem item, List<ToolStripMenuItem> items)
            {
                items.Add(item);
                foreach (ToolStripItem i in item.DropDownItems)
                {
                    if (i is ToolStripMenuItem)
                    {
                        GetMenuItems((ToolStripMenuItem)i, items);
                    }
                }
            }

            #endregion Methods
        }
        public static void EnforceSecurity(string moduleID, MenuStrip menuStrip, Panel buttonPanel)
        {
            List<AccessList> items = Utility.AccessLists.Where(x => x.ModuleID == moduleID).ToList();
            List<ToolStripMenuItem> myItems = GetAllMenuStripItems.GetItems(menuStrip);
            Utility.UserRoleID = "";
            Utility.UserRoleName = "";
            if (items.Count > 0)
            {
                Utility.UserRoleID = items.First().RoleID;
                Utility.UserRoleName = items.First().RoleName;
            }
            foreach (var item in myItems)
            {
                item.Enabled = false;
                if (items.Count > 0)
                {

                    foreach (AccessList m in items)
                    {

                        if (item.Name.ToString() == m.ObjID.ToString())
                        {
                            item.Enabled = true;
                        }
                    }

                }

            }

            foreach (var pan in buttonPanel.Controls)
            {
                if (pan.GetType() == typeof(Button))
                {
                    ((Button)pan).Enabled = false;
                    foreach (AccessList m in items)
                    {

                        if (((Button)pan).Name.ToString() == m.ObjID.ToString())
                        {
                            ((Button)pan).Enabled = true;
                        }
                    }
                }

            }
        }


        public static List<AccessList> AccessLists = new List<AccessList>();
        public static void AccessAdd(AccessList al)
        {
            Utility.AccessLists.Add(al);
        }

        public static string gobjNextNumber(string CurID)
        {
            string a = CurID;
            string b = string.Empty;
            string c = string.Empty;
            long val = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                {
                    b += a[i];
                }
                else
                {
                    c += a[i];
                }
            }

            if (b.Length > 0)
                val = int.Parse(b) + 1;
            if (val > 0)
            {
                return c + (int.Parse(b) + 1).ToString();
            }
            else
            {
                return "";
            }


        }




        public static System.Boolean IsNumericNew(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false
            return false;
        }




        public static string ctrlDateFormat(string  strName)

        {
            string strDate = "";
            
            if (strName.Length == 6)
            {
                strDate=  Utility.Left(strName, 2) + "-" + Utility.Mid(strName, 2, 2) + "-" + "20" + Utility.Right(strName, 2);
            }
            else if (strName.Length == 8)
            {
                strDate= Utility.Left(strName, 2) + "-" + Utility.Mid(strName, 2, 2) + "-" + Utility.Right(strName, 4);
            }
            else if (strName.Length == 10)
            {
                strDate= strName;
            }
            else if (strName.Length == 2)
            {
                strDate= Utility.Left(strName, 2) + "-" + Utility.Mid(DateTime.Now.ToString("dd-MM-yyyy"), 3, 2) + "-" + Utility.Right(DateTime.Now.ToString("dd-MM-yyyy"), 4);
            }
            else if (strName.Length == 4)
            {
                strDate = Utility.Left(strName, 2) + "-" + Utility.Right(strName, 2) + "-" + Utility.Right(DateTime.Now.ToString("dd-MM-yyyy"), 4);
            }
            else
            {
                strDate= "";
            }
            if (!IsDateTime(strDate))
            {
                strDate  = "";
            }
            return strDate;


        }

        public static bool IsDateTime(string txtDate)
        {
            DateTime tempDate;
            return DateTime.TryParse(txtDate, out tempDate);
        }

        public static double Getdblclosing(string strcomID,string vstrLedgerName,string strDate)
        {
            string conDb, strSQL;
           
            double dblOPening = 0, dblYearOpening = 0, dblBackYearOpening = 0, dbltotalDebit = 0, dbltotalCredit = 0, dblclosing = 0;
            conDb = SQLConnstringComSwitch(strcomID);
            string strFiscalYearfrom = cvtSQLDateStringnew(gstrFinicialYearFrom);
            string strFiscalYearTo = cvtSQLDateStringnew(gstrFinicialYearTo);
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmdInsert = new SqlCommand();
                SqlDataReader dr;
                try
                {
                    cmdInsert.Connection = gcnMain;
                    strSQL = "SELECT isnull(LEDGER_OPENING_BALANCE,0) AS OPENING FROM ACC_LEDGER ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblOPening = Convert.ToDouble(dr["OPENING"]);
                    }
                    dr.Close();
                    strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                    strSQL = strSQL + "FROM ACC_VOUCHER ";
                    strSQL = strSQL + "INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                    strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                    strSQL = strSQL + "AND COMP_VOUCHER_DATE >= ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strFiscalYearfrom) + "";
                    strSQL = strSQL + " AND  ";
                    strSQL = strSQL + " COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strDate) + " ";
                    // strSQL = strSQL + "AND BRANCH_ID = '" + strBranchId + "' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblYearOpening = Convert.ToDouble(dr["OPENING"]);
                    }
                    dr.Close();

                    strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                    strSQL = strSQL + "FROM ACC_VOUCHER ";
                    strSQL = strSQL + " INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                    strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                    strSQL = strSQL + " AND COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFiscalYearTo) + " ";
                    strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrASSET + " OR ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrLIABILITY + " ) ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblBackYearOpening = Convert.ToDouble(dr["OPENING"]);
                    }
                    dr.Close();
                    dblOPening = dblYearOpening + dblBackYearOpening + dblOPening;

                    strSQL = "SELECT isnull(SUM(VOUCHER_CREDIT_AMOUNT),0) AS TOTAL_CREDIT,";
                    strSQL = strSQL + "isnull(SUM(VOUCHER_DEBIT_AMOUNT),0) AS TOTAL_DEBIT ";
                    strSQL = strSQL + "FROM ACC_VOUCHER ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                    strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strFiscalYearfrom) + " ";
                    strSQL = strSQL + "AND ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strDate) + ") ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dbltotalDebit = Convert.ToDouble(dr["TOTAL_DEBIT"]);
                        dbltotalCredit = Convert.ToDouble(dr["TOTAL_CREDIT"]);
                    }
                    dr.Close();

                    dblclosing = dblOPening + (dbltotalCredit - dbltotalDebit);

                }

                catch (Exception ex)
                {
                    return 0;
                }
                return dblclosing;                


            }
        }

        public static bool  mblnLeapYear(DateTime vdteFromDate, DateTime vdteTodate)
        {
            long lngDays;
            long   lngCnt;
            DateTime dte29;
            long lngDiff;
            bool blngtrue = false;
            for (lngCnt = vdteFromDate.Year; lngCnt <= vdteTodate.Year; lngCnt++)
            {
                if (IsLeapYear(lngCnt))
                {
                    lngDays=366;
                }
                else
                {
                    lngDays = 365;
                }
               
                //lngDays =IIf(IsLeapYear(lngCnt), 366, 365);
                
                if (lngDays == 366)
                {
                    dte29 = Convert.ToDateTime("29-02-" + System.Convert.ToString(lngCnt));
                    lngDiff = Utility.DateDiff (Utility.DateInterval.Day, dte29, vdteFromDate);
                    if (lngDiff < 0)
                        blngtrue= true;
                }
                else
                {
                    blngtrue= false;
                }
            }
            return blngtrue;
        }

        public static bool IsLeapYear(long Yr)
        {
            bool bRet;
            if (Yr % 4 == 0)
            {
                if (Yr % 100 == 0)
                {
                    if (Yr % 400 == 0)
                        bRet = true;
                    else
                        bRet = false;
                }
                else
                    bRet = true;
            }
            else
                bRet = false;
           return  bRet;
        }


        public static string mUpdateBackupPath(string strcomID,string strPath1,string strPath2)
        {
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }


                gcnMain.Open();

                try
                {
                    SqlTransaction myTrans;
                    SqlCommand cmdUpdate = new SqlCommand();
                    myTrans = gcnMain.BeginTransaction();
                    cmdUpdate.Connection = gcnMain;
                    cmdUpdate.Transaction = myTrans;

                    strSQL = "UPDATE ACC_COMPANY SET BACKUP_TARGET = '" + strPath1 + "' ";
                    cmdUpdate.CommandText = strSQL;
                    cmdUpdate.ExecuteNonQuery();
                    if (strPath2.Length >0)
                    {
                        strSQL = "UPDATE ACC_COMPANY SET BACKUP_CLIENT = '" + strPath2 + "' ";
                        cmdUpdate.CommandText = strSQL;
                        cmdUpdate.ExecuteNonQuery();
                    }
                    cmdUpdate.Transaction.Commit();
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                finally
                {
                    gcnMain.Dispose();
                }


            }
        }
        public static string Backup(string strcomID,string strTarget,string strTarget1)
        {
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }


                gcnMain.Open();

                try
                {
                    //SqlTransaction myTrans;
                    SqlCommand cmdUpdate = new SqlCommand();
                    //myTrans = gcnMain.BeginTransaction();
                    cmdUpdate.Connection = gcnMain;
                    //cmdUpdate.Transaction = myTrans;

                    strSQL = "BACKUP DATABASE SMART" + strcomID + " TO DISK = '" + strTarget + "' WITH INIT ";
                    cmdUpdate.CommandText = strSQL;
                    cmdUpdate.CommandTimeout = 0;
                    cmdUpdate.ExecuteNonQuery();
                    if (strTarget1.Length >0)
                    {
                        strSQL = "BACKUP DATABASE SMART" + strcomID + " TO DISK = '" + strTarget1 + "' WITH INIT ";
                        cmdUpdate.CommandText = strSQL;
                        cmdUpdate.CommandTimeout = 0;
                        cmdUpdate.ExecuteNonQuery();
                    }

                    //cmdUpdate.Transaction.Commit();
                    cmdUpdate.CommandTimeout = 30;
                    return "Backup Successfull..";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                finally
                {
                    gcnMain.Dispose();
                }


            }
        }

        public static string Restore(string strcomID,string strDataBase,string strRestoreFile)
        {
            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }


                gcnMain.Open();

                try
                {
                    //SqlTransaction myTrans;
                    SqlCommand cmdUpdate = new SqlCommand();
                    //myTrans = gcnMain.BeginTransaction();
                    cmdUpdate.Connection = gcnMain;
                    //cmdUpdate.Transaction = myTrans;
                    strSQL = "USE MASTER ";
                    strSQL = strSQL + "RESTORE DATABASE " + strDataBase + " FROM DISK = '" + strRestoreFile + "' with ";
                    strSQL = strSQL + "NOUNLOAD,REPLACE ";
                    cmdUpdate.CommandText = strSQL;
                    cmdUpdate.ExecuteNonQuery();

                    return "Restore Successfull..";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                finally
                {
                    gcnMain.Dispose();
                }


            }
        }

        public static bool Kill(string args)
        {
            foreach (Process proc in Process.GetProcessesByName(args))
            {
                proc.Kill();
            }
            return false;


        }
        public static double gdblChallanAmount(string strcomID, string strMerzename, string strFdate, string strTDate)
        {
            string strSQL;
            double dblAmnt = 0;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);


            strSQL = "SELECT isnull(sum(ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT),0) AMNT ";
            strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER INNER JOIN ";
            strSQL = strSQL + "ACC_LEDGER ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME ";
            strSQL = strSQL + "WHERE ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE  between " + Utility.cvtSQLDateString(strFdate) + " ";
            strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + " ";
            strSQL = strSQL + "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE=16 ";
            strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME_MERZE='" + strMerzename.ToString().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblAmnt = Convert.ToDouble(dr["AMNT"].ToString());
                }
                else
                {
                    dblAmnt = 0;
                }
                dr.Close();
                gcnMain.Dispose();
                return dblAmnt;

            }
        }
        public static double gdblInvoiceAmount(string strcomID, string strrRefNo)
        {
            string strSQL;
            double dblAmnt = 0;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            strSQL = "SELECT SUM(BILL_NET_AMOUNT) AMNT FROM ACC_BILL_TRAN WHERE COMP_VOUCHER_TYPE =16";
            strSQL = strSQL + "AND COMP_REF_NO='" + strrRefNo + "' ";
            
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblAmnt = Convert.ToDouble(dr["AMNT"].ToString());
                }
                else
                {
                    dblAmnt = 0;
                }
                dr.Close();
                gcnMain.Dispose();
                return dblAmnt;

            }
        }

        public static string gUpdateHaltZone(string strcomID, string strZone)
        {
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);



            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = gcnMain;
                strSQL = "UPDATE ACC_LEDGER SET HALT_MPO=0 FROM ACC_LEDGER_Z_D_A,ACC_LEDGER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE ='" + strZone + "' ";
                cmdUpdate.CommandText = strSQL;
                cmdUpdate.ExecuteNonQuery();
                gcnMain.Dispose();
                return "1";

            }
        }
        public static string gUpdateHalt(string strcomID, string strMerxeName)
        {
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

         

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = gcnMain;
                strSQL ="UPDATE ACC_LEDGER set HALT_MPO=1 " ;
                strSQL = strSQL + "WHERE LEDGER_NAME_MERZE='" + strMerxeName.Replace("'","''") + "' ";
                cmdUpdate.CommandText = strSQL;
                cmdUpdate.ExecuteNonQuery();
                gcnMain.Dispose();
                return "1";

            }
        }
        public static string gstrSMSMobileNo(string strcomID, string strMerzeName)
        {
            string strSQL;
            string strMobile = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            strSQL = "SELECT LEDGER_PHONE ";
            strSQL = strSQL + "FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE ACC_LEDGER.LEDGER_NAME_MERZE='" + strMerzeName + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strMobile = dr["LEDGER_PHONE"].ToString();
                }
                else
                {
                    strMobile = "";
                }
                dr.Close();
                gcnMain.Dispose();
                return strMobile;

            }
        }
        public static long glngGetPrimaryType(string strValue)
        {
            string strSQL;
            long lngType = 0;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstring();
            strSQL = "SELECT GR_PRIMARY_TYPE FROM ACC_LEDGERGROUP WHERE GR_NAME='" + strValue.ToString().Replace("'", "''") + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lngType = Convert.ToInt64(dr["GR_PRIMARY_TYPE"].ToString());
                }
                else
                {
                    lngType = 0;
                }
                dr.Close();
                gcnMain.Dispose();
                return lngType;

            }
        }

       
        public static DateTime LastDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }
        public static DateTime FirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
        public static string DeleteCompnay(string strcomID,string strDataBase)
        {
            string strSQL;
            string conDb;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }


                gcnMain.Open();

                try
                {
                    //SqlTransaction myTrans;
                    SqlCommand cmdUpdate = new SqlCommand();
                    //myTrans = gcnMain.BeginTransaction();
                    cmdUpdate.Connection = gcnMain;
                    //cmdUpdate.Transaction = myTrans;
                    strSQL = "USE MASTER ";
                    strSQL = strSQL + "DROP DATABASE " + strDataBase + " ";
                    cmdUpdate.CommandText = strSQL;
                    cmdUpdate.ExecuteNonQuery();
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                finally
                {
                    gcnMain.Dispose();
                }


            }

        }


        public static string mInsertTranData(string strComID, string vstrSourceDB,
                                                  string vTable, int intStartIndex, string vstrFilterFiled, string gdteFinYearFrom, string gdteFinYearTo)
        {
            string strSQL = "", strField = "";
            strField = mFieldName(strComID, vstrSourceDB + ".dbo." + vTable, vTable, intStartIndex);
            if (strField != "")
            {
                strSQL = "INSERT INTO " + vTable + "(" + strField + ") ";
                strSQL = strSQL + "SELECT " + strField + " FROM " + vstrSourceDB + ".dbo." + vTable;
                strSQL = strSQL + "WHERE " + vstrFilterFiled + " BETWEEN " + Utility.cvtSQLDateString(gdteFinYearFrom) + " ";
                strSQL = strSQL + " and " + Utility.cvtSQLDateString(gdteFinYearTo) + "";
            }
            return strSQL;


        }

        public static string mInsertTranDataOpening(string strComID, string vstrSourceDB,
                                                    string vTable, int intStartIndex, string vstrFilterFiled, string gdteFinYearFrom)
        {
            string strSQL = "", strField = "";
            strField = mFieldName(strComID, vstrSourceDB + ".dbo." + vTable, vTable, intStartIndex);
            if (strField != "")
            {
                strSQL = "INSERT INTO " + vTable + "(" + strField + ") ";
                strSQL = strSQL + "SELECT " + strField + " FROM " + vstrSourceDB + ".dbo." + vTable;
                strSQL = strSQL + "WHERE " + vstrFilterFiled + " < " + Utility.cvtSQLDateString(gdteFinYearFrom) + " ";
            }
            return strSQL;


        }

        public static string mInsertTableDataBranch(string strComID, string vstrSourceDB, string vTable, int intStartIndex)
        {
            string strSQL = "", strField = "";
            strField = mFieldNameBranch(strComID, vstrSourceDB + ".dbo." + vTable, vTable, intStartIndex);
            if (strField != "")
            {
                strSQL = "INSERT INTO " + vTable + "(" + strField + ") ";
                strSQL = strSQL + "SELECT " + strField + " FROM " + vstrSourceDB + ".dbo." + vTable;
                strSQL = strSQL + " WHERE BRANCH_ID <> '0001' ";
            }
            return strSQL;


        }

        private static string mFieldNameBranch(string strComID, string vTable, string vTable1, int intStartIndex)
        {
            string strSQL, strField = "";
            string conDb;
            SqlDataReader reader;
            conDb = SQLConnstringComSwitch(strComID);

            strSQL = "SELECT * FROM " + vTable;
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                reader = cmd.ExecuteReader();
                for (int intgpos = intStartIndex; intgpos < reader.FieldCount; intgpos++)
                {
                    strField = strField + reader.GetName(intgpos).ToString() + ",";
                }
                reader.Close();
                gcnMain.Dispose();
                if (strField != "")
                {
                    strField = Utility.Mid(strField, 0, strField.Length - 1);
                }

                return strField;

            }
        }

        public static string mInsertTableData(string strComID, string vstrSourceDB, string vTable, int intStartIndex)
        {
            string strSQL = "", strField = "";
            strField = mFieldName(strComID, vstrSourceDB + ".dbo." + vTable, vTable, intStartIndex);
            if (strField != "")
            {
                strSQL = "INSERT INTO " + vTable + "(" + strField + ") ";
                strSQL = strSQL + "SELECT " + strField + " FROM " + vstrSourceDB + ".dbo." + vTable;
            }
            return strSQL;


        }

        private static string mFieldName(string strComID, string vTable, string vTable1, int intStartIndex)
        {
            string strSQL, strField = "";
            string conDb;
            SqlDataReader reader;
            conDb = SQLConnstringComSwitch(strComID);

            strSQL = "SELECT * FROM " + vTable;
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                reader = cmd.ExecuteReader();
                for (int intgpos = intStartIndex; intgpos < reader.FieldCount; intgpos++)
                {
                    strField = strField + reader.GetName(intgpos).ToString() + ",";
                }
                reader.Close();
                gcnMain.Dispose();
                if (strField != "")
                {
                    strField = Utility.Mid(strField, 0, strField.Length - 1);
                }

                return strField;

            }
        }


        public static string mGetAgstRefNo(string strcomID, string strRefNo)
        {
            string strSQL,strString="";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            strSQL = "SELECT STUFF((SELECT ',' + substring(VOUCHER_JOIN_FOREIGN_REF,7,30) FROM ACC_VOUCHER_JOIN ";
            strSQL = strSQL + " where VOUCHER_JOIN_PRIMARY_REF like '%" + strRefNo + "' ";
            strSQL = strSQL + "FOR XML PATH('')), 1, 1, '') AgstRefNo ";
            strSQL = strSQL + " union all ";
            strSQL = strSQL + "SELECT STUFF((SELECT ',' + substring(CLASS_NAME ,7,30) FROM ACC_VOUCHER_JOIN_CLASS ";
            strSQL = strSQL + "where VOUCHER_JOIN_PRIMARY_REF like '%" + strRefNo + "' ";
            strSQL = strSQL + "FOR XML PATH('')), 1, 1, '') AgstRefNo ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["AgstRefNo"].ToString() !="")
                    {
                        strString =dr["AgstRefNo"].ToString();
                    }
                }
               
                dr.Close();
                gcnMain.Dispose();
                return strString;


            }
        }

        public static string mInsertOnlineDate(string strcomID)
        {
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }


                gcnMain.Open();

                try
                {
                    SqlTransaction myTrans;
                    SqlCommand cmdUpdate = new SqlCommand();
                    myTrans = gcnMain.BeginTransaction();
                    cmdUpdate.Connection = gcnMain;
                    cmdUpdate.Transaction = myTrans;


                    //strSQL = "INSERT INTO USER_ONLILE_SECURITY(USER_ID,PASSWORD) ";
                    //strSQL = strSQL + "SELECT TERITORRY_CODE,TERITORRY_CODE FROM ACC_LEDGER WHERE LEDGER_GROUP =202 AND TERRITORRY_NAME IS NOT NULL and TERITORRY_CODE NOT IN (SELECT USER_ID FROM USER_ONLILE_SECURITY) ";
                    //cmdUpdate.CommandText = strSQL;
                    //cmdUpdate.ExecuteNonQuery();



                    //strSQL = "INSERT INTO USER_ONLILE_SECURITY(PASSWORD,COR_MOBILE_NO,TC,TCNAME,LEDGER_NAME,MPO_TYPE,LIST_M_D_A) ";
                    //strSQL = strSQL + "SELECT TERITORRY_CODE,LEDGER_PHONE,TERITORRY_CODE,TERRITORRY_NAME,LEDGER_NAME,0 ,TERITORRY_CODE  FROM ACC_LEDGER WHERE LEDGER_GROUP =202 AND LEDGER_STATUS =0 ";
                    //strSQL = strSQL + "AND TERITORRY_CODE NOT IN ('OD','BD','NC') AND TERRITORRY_NAME ";
                    //strSQL = strSQL + "IS NOT NULL and TERITORRY_CODE NOT IN (SELECT USER_ID FROM USER_ONLILE_SECURITY) ";
                    //cmdUpdate.CommandText = strSQL;
                    //cmdUpdate.ExecuteNonQuery();
                    //strSQL = "INSERT INTO USER_ONLILE_SECURITY(PASSWORD,COR_MOBILE_NO,TC,TCNAME,LEDGER_NAME,MPO_TYPE,LIST_M_D_A) ";
                    //strSQL = strSQL + "select  GR_SERIAL,GR_MOBILE_NO,'Area','Area',GR_NAME  ,1,GR_SERIAL   from ACC_LEDGERGROUP  WHERE GR_NAME LIKE 'AH%'";
                    //strSQL = strSQL + "AND GR_MOBILE_NO IS NOT NULL AND GR_MOBILE_NO <> '' AND GR_NAME ";
                    //strSQL = strSQL + "IS NOT NULL and GR_NAME NOT IN (SELECT LEDGER_NAME FROM USER_ONLILE_SECURITY) ";
                    //cmdUpdate.CommandText = strSQL;
                    //cmdUpdate.ExecuteNonQuery();
                    //strSQL = "INSERT INTO USER_ONLILE_SECURITY(PASSWORD,COR_MOBILE_NO,TC,TCNAME,LEDGER_NAME,MPO_TYPE,LIST_M_D_A) ";
                    //strSQL = strSQL + "select GR_SERIAL,GR_MOBILE_NO,'Division','Division',GR_NAME  ,2,GR_SERIAL   from ACC_LEDGERGROUP WHERE GR_NAME LIKE 'DH%'";
                    //strSQL = strSQL + "AND GR_MOBILE_NO IS NOT NULL AND GR_MOBILE_NO <> '' AND GR_NAME ";
                    //strSQL = strSQL + "IS NOT NULL and GR_NAME NOT IN (SELECT LEDGER_NAME FROM USER_ONLILE_SECURITY) ";

                    strSQL = "INSERT INTO USER_ONLILE_SECURITY(PASSWORD,COR_MOBILE_NO,TC,TCNAME,LEDGER_NAME,MPO_TYPE) ";
                    strSQL = strSQL + "SELECT  TERITORRY_CODE,LEDGER_PHONE,TERITORRY_CODE,TERRITORRY_NAME,LEDGER_NAME,0 FROM ACC_LEDGER ";
                    strSQL = strSQL + "WHERE LEDGER_GROUP =202 AND LEDGER_STATUS =0 ";
                    strSQL = strSQL + "AND TERITORRY_CODE NOT IN ('OD','BD','NC') ";
                    strSQL=  strSQL + "AND TERRITORRY_NAME ";
                    strSQL = strSQL + "IS NOT NULL and LEDGER_NAME NOT IN (SELECT LEDGER_NAME FROM USER_ONLILE_SECURITY) ";
                    strSQL = strSQL + "UNION ALL ";
                    //strSQL = strSQL + "SELECT distinct 'AREA',GR_MOBILE_NO,'AREA','AREA',AREA ,1    FROM ACC_LEDGER_Z_D_A WHERE LEDGER_STATUS =0 AND AREA like 'AH%'  ";
                    strSQL = strSQL + " SELECT distinct 'AREA',GR_MOBILE_NO,'AREA','AREA',GR_NAME  ,1    FROM ACC_LEDGERGROUP WHERE GR_NAME like 'AH%' ";
                    strSQL = strSQL + "AND GR_MOBILE_NO IS NOT NULL AND GR_MOBILE_NO <> '' AND GR_NAME ";
                    strSQL = strSQL + "IS NOT NULL and GR_NAME NOT IN (SELECT LEDGER_NAME FROM USER_ONLILE_SECURITY) ";
                    strSQL = strSQL + "UNION ALL ";
                    //strSQL = strSQL + "SELECT distinct 'Division',GR_MOBILE_NO,'Division','Division',DIVISION ,2   FROM ACC_LEDGER_Z_D_A  WHERE LEDGER_STATUS =0 ";
                    strSQL = strSQL + " SELECT distinct 'Division',GR_MOBILE_NO,'Division','Division',GR_NAME  ,2    FROM ACC_LEDGERGROUP WHERE GR_NAME like 'DH%' ";
                    strSQL = strSQL + "AND GR_MOBILE_NO IS NOT NULL AND GR_MOBILE_NO <> '' AND GR_NAME ";
                    strSQL = strSQL + "IS NOT NULL and GR_NAME NOT IN (SELECT LEDGER_NAME FROM USER_ONLILE_SECURITY) ";
                    cmdUpdate.CommandText = strSQL;
                    cmdUpdate.ExecuteNonQuery();
                    strSQL = "UPDATE USER_ONLILE_SECURITY set LIST_M_D_A=USER_ID ";
                    cmdUpdate.CommandText = strSQL;
                    cmdUpdate.ExecuteNonQuery();
                    cmdUpdate.Transaction.Commit();
                    return "Ok";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                finally
                {
                    gcnMain.Dispose();
                }


            }

        }

        public static string  GetMpoDateFromTroyeeTemporary(string strCondb,string strValue)
        {
            string strSQL;
            string strFadte = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strCondb);
            strSQL = "SELECT COMP_VALIDITY_DATE FROM ACC_COMPANY_VOUCHER WHERE COMP_REF_NO='" + strValue.ToString() + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strFadte = Convert.ToDateTime(dr["COMP_VALIDITY_DATE"]).ToString("dd-MM-yyyy");
                }
              
                dr.Close();
                gcnMain.Dispose();
                return strFadte;

            }
        }
        public static string GetLastLedgeCode(string strCondb, string strValue)
        {
            string strSQL;
            string strsTRING = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strCondb);
            strSQL = "SELECT LEDGER_CODE  FROM ACC_LEDGER WHERE LEDGER_GROUP =204 AND LEDGER_CODE LIKE '" + strValue + "%' ";
            strSQL=strSQL +" ORDER BY LEDGER_CODE DESC ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();

                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        strsTRING = dr["LEDGER_CODE"].ToString();
                    }

                    dr.Close();
                    gcnMain.Dispose();
                    return strsTRING;
                }
                catch (Exception EX)
                {
                    return "";
                }

            }
        }
        public static string GetMpoDateToTroyeeTemporary(string strCondb, string strValue)
        {
            string strSQL;
            string strFadte = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strCondb);
            strSQL = "SELECT UPDATE_DATE FROM ACC_COMPANY_VOUCHER WHERE COMP_REF_NO='" + strValue.ToString() + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strFadte = Convert.ToDateTime(dr["UPDATE_DATE"]).ToString("dd-MM-yyyy");
                }

                dr.Close();
                gcnMain.Dispose();
                return strFadte;

            }
        }
        public static double  GetHLTransferAmount(string strCondb, string strLedgername)
        {
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strCondb);
            strSQL = "SELECT isnull(SUM(MONTHLY_AMOUNT),0) amnt FROM  ACC_PAYMENT_SCHEDULE WHERE INSTALL_STATUS =0 ";
            strSQL = strSQL + " AND  LEDGER_NAME ='" + strLedgername.ToString() + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return Convert.ToDouble( dr["amnt"]);
                }
                else
                {
                    return 0;
                }

                dr.Close();
                gcnMain.Dispose();
               

            }
        }
        public static string gstrGetOldPassWord(string strCondb, string strUserName)
        {
            string strSQL;
                      string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strCondb);
            strSQL = "SELECT USER_LOGIN_NAME,USER_PASS FROM USER_CONFIG WHERE USER_LOGIN_NAME='" + strUserName.ToString() + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return Decrypt(dr["USER_PASS"].ToString(), dr["USER_LOGIN_NAME"].ToString()).ToString();
                }
                else
                {
                    return "";
                }

                dr.Close();
                gcnMain.Dispose();
                

            }

        }
     
        public static string mInsertLedgerOthers(string strCondb, string strLedgerName,int intmonth,double dblcls)
        {
            string strSQL;
            string conDb;

            conDb = SQLConnstringComSwitch(strCondb);
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                   
                    strSQL = "INSERT INTO SALES_PERFORMANCE(SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO,AMNT,SORTING_TYPE) ";
                    strSQL = strSQL + "values(1,'O.Dues','" + strLedgerName + "'," + intmonth + "," + dblcls + ",16)";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    cmd.ExecuteNonQuery();
                    gcnMain.Dispose();
                    return "1";


                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }


            }

        }
        public static string mUpdateCommParent(string strCondb, string strLedgerName,string strMonthID,string stRRefNo)
        {
            string strSQL;
            string conDb;
            
            conDb = SQLConnstringComSwitch(strCondb);
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();

                    strSQL = "UPDATE MPO_COMM_MAN_PARENT SET AGNST_REF_NO='" + stRRefNo + "' ";
                    strSQL = strSQL + "WHERE LEDGER_NAME ='" + strLedgerName.Replace("'", "''");
                    strSQL = strSQL + "AND MONTH_ID ='" + strMonthID.Replace("'", "''");
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    cmd.ExecuteNonQuery();
                    gcnMain.Dispose();
                    return "1";
                   
                    
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }


            }

        }

        public static string mCheckCommission(string strcomID, string strLedgerName,string strMonthid)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT count(*) as cnt FROM ACC_COMPANY_VOUCHER ";
            strSQL = strSQL + "WHERE LEDGER_NAME ='" + strLedgerName + "' ";
            strSQL = strSQL + "AND AGNST_COMP_REF_NO ='" + strMonthid + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Convert.ToInt32(dr["cnt"]) > 0)
                    {
                        strString = "Cannot Insert Duplicate Value";
                    }
                    else
                    {
                        strString = "";
                    }
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string mCheckManual(string strcomID, string strMonthid)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT count(*) as cnt FROM MPO_COMM_MAN_PARENT ";
            //strSQL = strSQL + "WHERE LEDGER_NAME ='" + strLedgerName + "' ";
            strSQL = strSQL + "WHERE MONTH_ID ='" + strMonthid + "' ";
            strSQL = strSQL + "AND RIGHT(COMM_MANUAL_KEY,1)='I' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Convert.ToInt32(dr["cnt"]) > 0)
                    {
                        strString = "Cannot Insert Duplicate Value";
                    }
                    else
                    {
                        strString = "";
                    }
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static string mGetDraft(string strcomID, string strMonthid,string strLedgerName,string strHeadID)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL="SELECT MPO_COMM_MAN_PARENT_CHILD.AMOUNT ";
            strSQL=strSQL +"FROM ACC_LEDGER, MPO_COMM_MAN_PARENT,MPO_COMM_MAN_PARENT_CHILD WHERE ACC_LEDGER.LEDGER_NAME =MPO_COMM_MAN_PARENT_CHILD.LEDGER_NAME AND ";
            strSQL = strSQL + "MPO_COMM_MAN_PARENT.COMM_MANUAL_KEY=MPO_COMM_MAN_PARENT_CHILD.COMM_MANUAL_KEY ";
            strSQL = strSQL + " AND ACC_LEDGER.LEDGER_NAME='" + strLedgerName + "' ";
            strSQL = strSQL + " AND MPO_COMM_MAN_PARENT_CHILD.HEAD_NAME='" + strHeadID + "' ";
            strSQL = strSQL + " AND MPO_COMM_MAN_PARENT.MONTH_ID='" + strMonthid + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["AMOUNT"].ToString();
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
        public static double  mGetBatchUsed(string strcomID, string strBatchNo)
        {
            string strSQL;
            string conDb;
            double dblTotalBatchSize = 0, dblUsedSize = 0;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnMain;
                    strSQL = "SELECT ISNULL(INV_LOG_SIZE,0) INV_LOG_SIZE  FROM INV_BATCH WHERE INV_LOG_NO ='" + strBatchNo.Trim().Replace("'", "''") + "' ";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dblTotalBatchSize = Convert.ToDouble(dr["INV_LOG_SIZE"]);
                    }
                    dr.Close();

                    strSQL = "SELECT ISNULL(SUM(FG_SIZE),0) QUANTITY FROM INV_PRODUCTION_MASTER WHERE INV_LOG_NO ='" + strBatchNo.Trim().Replace("'", "''") + "' ";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dblUsedSize = Convert.ToDouble(dr["QUANTITY"]);
                    }
                    dr.Close();

                    return (dblTotalBatchSize - dblUsedSize);
                   
                    dr.Close();
                    gcnMain.Dispose();

                }
                catch (Exception EX)
                {
                    return 1;
                }
            }
        }
        public static string mGetCheckProductIonApproved(string strcomID, string strRefNo)
        {
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    strSQL = "SELECT APP_STATUS FROM INV_PRODUCTION_MASTER  WHERE VOUCHER_NO ='" + strRefNo + "' ";
                    strSQL = strSQL + "AND APP_STATUS=1 ";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return "Approved Voucher Cannot be Alter";
                    }
                    else
                    {
                        return "";
                    }
                    dr.Close();
                    gcnMain.Dispose();
                }
                catch (Exception EX)
                {
                    return EX.ToString();
                }


            }
        }
        public static double mGetBatchSize(string strcomID, string strBatchNo)
        {
            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    strSQL = "SELECT ISNULL(INV_LOG_SIZE,0) INV_LOG_SIZE  from INV_BATCH WHERE INV_LOG_NO ='" + strBatchNo + "' ";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return Convert.ToDouble(dr["INV_LOG_SIZE"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                    dr.Close();
                    gcnMain.Dispose();
                }
                catch (Exception EX)
                {
                    return 1;
                }
               

            }
        }
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static string gInsertLateFine(string strcomID, string vstrRefNumber, string vstrLedgerName,string vstrRevesrLedgerName,string vstrBranchID, int vlngVoucherType ,
                                                string vstrMonthID, string vdteDate, double vdblAmount, 
                                                string vstrNarrations, string vstrAgnstRefNo,int action,int intTransfer)
        {
            string strSQL = "", strBillWiseRef="";
            string conDb;
            int intvoucherPosition=1;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            {
                using (SqlConnection gcnMain = new SqlConnection(conDb))
                {
                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }
                    try
                    {
                        gcnMain.Open();
                        SqlCommand cmdInsert = new SqlCommand();
                        SqlTransaction myTrans;
                        myTrans = gcnMain.BeginTransaction();
                        cmdInsert.Connection = gcnMain;
                        cmdInsert.Transaction = myTrans;
                        if (action == 2)
                        {
                            strSQL = "SELECT COMP_REF_NO  FROM ACC_COMPANY_VOUCHER  WHERE  AGNST_COMP_REF_NO='" + vstrRefNumber + "' ";
                            cmdInsert.CommandText = strSQL;
                            dr = cmdInsert.ExecuteReader();
                            if(dr.Read())
                            {
                                vstrRefNumber = dr["COMP_REF_NO"].ToString();
                            }
                            dr.Close();

                            strSQL = "DELETE FROM ACC_VOUCHER WHERE COMP_REF_NO='" + vstrRefNumber + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            strSQL = "DELETE FROM ACC_COMPANY_VOUCHER WHERE COMP_REF_NO='" + vstrRefNumber + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        strSQL = "INSERT INTO ACC_COMPANY_VOUCHER";
                        strSQL = strSQL + "(BRANCH_ID,COMP_REF_NO,COMP_VOUCHER_MONTH_ID,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,COMP_VOUCHER_DUE_DATE,";
                        strSQL = strSQL + "LEDGER_NAME,COMP_VOUCHER_AMOUNT,COMP_VOUCHER_NET_AMOUNT";
                        if (vstrNarrations != "")
                        {
                            strSQL = strSQL + ",COMP_VOUCHER_NARRATION ";
                        }
                        if (vstrAgnstRefNo != "")
                        {
                            strSQL = strSQL + ",AGNST_COMP_REF_NO ";
                        }
                        strSQL = strSQL + ") ";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + vstrBranchID + "',";
                        strSQL = strSQL + "'" + vstrRefNumber.Trim() + "',";
                        strSQL = strSQL + "'" + vstrMonthID + "',";
                        strSQL = strSQL + " " + vlngVoucherType + ",";
                        strSQL = strSQL + " " + Utility.cvtSQLDateString(vdteDate) + ",";
                        strSQL = strSQL + " " + Utility.cvtSQLDateString(vdteDate) + ",";
                        strSQL = strSQL + "'" + vstrLedgerName + "',";
                        strSQL = strSQL + " " + vdblAmount + ",";
                        strSQL = strSQL + " " + vdblAmount + " ";
                        if (vstrNarrations != "")
                        {
                            strSQL = strSQL + ",'" + vstrNarrations + "'";
                        }
                        if (vstrAgnstRefNo != "")
                        {
                            strSQL = strSQL + ",'" + vstrAgnstRefNo + "'";
                        }

                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strBillWiseRef = vstrRefNumber + intvoucherPosition.ToString("0000");
                        strSQL = "INSERT INTO ACC_VOUCHER";
                        strSQL = strSQL + "(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,COMP_VOUCHER_TYPE,";
                        strSQL = strSQL + "COMP_VOUCHER_DATE,COMP_VOUCHER_POSITION,LEDGER_NAME,";
                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                        strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER ";
                        strSQL = strSQL + ",VOUCHER_CURRENCY_SYMBOL";
                        strSQL = strSQL + ",AGNST_COMP_REF_NO,TRANSFER_TYPE";
                        strSQL = strSQL + ") VALUES(";
                        strSQL = strSQL + "'" + vstrBranchID + "',";
                        strSQL = strSQL + "'" + strBillWiseRef + "','" + vstrRefNumber + "',";
                        strSQL = strSQL + " " + vlngVoucherType + "," + Utility.cvtSQLDateString(vdteDate) + ",";
                        strSQL = strSQL + " " + intvoucherPosition + ",'" + vstrLedgerName + "',";
                        strSQL = strSQL + " " + vdblAmount + " ";
                        strSQL = strSQL + ",0 ";
                        strSQL = strSQL + ",'Dr' ";
                        strSQL = strSQL + ",'" + vstrRevesrLedgerName + "' ";
                        strSQL = strSQL + ",'" + Utility.gstrBaseCurrency + "' ";
                        strSQL = strSQL + ",'" + vstrAgnstRefNo + "' ";
                        strSQL = strSQL + "," + intTransfer + " ";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        intvoucherPosition += 1;
                        strBillWiseRef = vstrRefNumber + intvoucherPosition.ToString("0000");
                        strSQL = "INSERT INTO ACC_VOUCHER";
                        strSQL = strSQL + "(BRANCH_ID,VOUCHER_REF_KEY,COMP_REF_NO,COMP_VOUCHER_TYPE,";
                        strSQL = strSQL + "COMP_VOUCHER_DATE,COMP_VOUCHER_POSITION,LEDGER_NAME,";
                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,";
                        strSQL = strSQL + "VOUCHER_TOBY,VOUCHER_REVERSE_LEDGER ";
                        strSQL = strSQL + ",VOUCHER_CURRENCY_SYMBOL";
                        strSQL = strSQL + ",AGNST_COMP_REF_NO,TRANSFER_TYPE";
                        strSQL = strSQL + ") VALUES(";
                        strSQL = strSQL + "'" + vstrBranchID + "',";
                        strSQL = strSQL + "'" + strBillWiseRef + "','" + vstrRefNumber + "',";
                        strSQL = strSQL + " " + vlngVoucherType + "," + Utility.cvtSQLDateString(vdteDate) + ",";
                        strSQL = strSQL + " " + intvoucherPosition + ",'" + vstrRevesrLedgerName + "' ";
                        strSQL = strSQL + ",0";
                        strSQL = strSQL + "," + vdblAmount + " ";
                        strSQL = strSQL + ",'Cr'";
                        strSQL = strSQL + ",'" + vstrLedgerName + "'";
                        strSQL = strSQL + ",'" + Utility.gstrBaseCurrency + "'";
                        strSQL = strSQL + ",'" + vstrAgnstRefNo + "' ";
                        strSQL = strSQL + "," + intTransfer + " ";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        if (action == 1)
                        {
                            strSQL = "UPDATE ACC_VOUCHER_TYPE ";
                            strSQL = strSQL + "SET VOUCHER_TYPE_TOTAL_VOUCHER = VOUCHER_TYPE_TOTAL_VOUCHER + 1 ";
                            strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + vlngVoucherType + " ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        cmdInsert.Transaction.Commit();

                        return "Related Record " + vstrRefNumber + " Updated" ;

                    }
                    catch (Exception ex)
                    {
                        return ex.ToString();
                    }
                }
            }

        }
        public static  double gdblGPMF(string strDeComID, string strFdate, string strTDate, string vstrBranchID)
        {
            string strSQL = null;
            string conDb;
            double dblOpeningStock = 0, dblClosingStock = 0, dblCGS = 0, dblPurchase = 0, dblSales = 0, dblTransfer = 0;
            conDb = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdGet = new SqlCommand();

                double OPNRAWDIR = 0, PURRAWDIR = 0, RETRAWDIR = 0, CLSRAWDIR = 0, DIREXPGRP = 0, DIREXPLED = 0, MANUCOST = 0;

                strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) OPENING FROM INV_MANUFACTURE_STOCK_QRY ";
                strSQL = strSQL + "WHERE STOCKGROUP_PRIMARY_TYPE = 1 AND INV_DATE <  " + Utility.cvtSQLDateString(strFdate) + " ";
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    OPNRAWDIR = Convert.ToDouble(dr["OPENING"].ToString());

                }
                dr.Close();
                strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) OPENING FROM INV_MANUFACTURE_STOCK_QRY ";
                strSQL = strSQL + "WHERE STOCKGROUP_PRIMARY_TYPE = 1  AND INV_VOUCHER_TYPE = 33 ";
                strSQL = strSQL + "AND INV_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + " "; 
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    PURRAWDIR = Convert.ToDouble(dr["OPENING"].ToString());

                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) OPENING FROM INV_MANUFACTURE_STOCK_QRY ";
                strSQL = strSQL + "WHERE STOCKGROUP_PRIMARY_TYPE = 1  AND INV_VOUCHER_TYPE = 32 ";
                strSQL = strSQL + "AND INV_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + " ";
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    RETRAWDIR = Convert.ToDouble(dr["OPENING"].ToString());

                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) OPENING FROM INV_MANUFACTURE_STOCK_QRY ";
                strSQL = strSQL + "WHERE STOCKGROUP_PRIMARY_TYPE = 1  AND INV_DATE <=  " + Utility.cvtSQLDateString(strTDate) + " ";
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    CLSRAWDIR = Convert.ToDouble(dr["OPENING"].ToString());

                }
                dr.Close();


                strSQL = "SELECT ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT - ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER LEFT OUTER JOIN ACC_LEDGER_GROUP_QRY ON ACC_VOUCHER.LEDGER_NAME = ACC_LEDGER_GROUP_QRY.LEDGER_NAME ";
                strSQL = strSQL + "WHERE (ACC_LEDGER_GROUP_QRY.GR_PRIMARY_TYPE = 4) AND ACC_LEDGER_GROUP_QRY.GR_GROUP = 213 AND ";
                strSQL = strSQL + "(ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                strSQL=strSQL +"AND ACC_LEDGER_GROUP_QRY.GR_LEVEL = 2 ";
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    DIREXPGRP = Convert.ToDouble(dr["OPENING"].ToString());

                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT - ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER LEFT OUTER JOIN ACC_LEDGER_GROUP_QRY ON ACC_VOUCHER.LEDGER_NAME = ACC_LEDGER_GROUP_QRY.LEDGER_NAME ";
                strSQL = strSQL + "WHERE (ACC_LEDGER_GROUP_QRY.GR_PRIMARY_TYPE = 4) AND ACC_LEDGER_GROUP_QRY.GR_GROUP = 213 AND ";
                strSQL = strSQL + "(COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                strSQL = strSQL + "AND ACC_LEDGER_GROUP_QRY.GR_LEVEL = 2 ";
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    DIREXPLED = Convert.ToDouble(dr["OPENING"].ToString());

                }
                dr.Close();
                strSQL = "SELECT ISNULL(SUM(VOUCHER_DEBIT_AMOUNT - VOUCHER_CREDIT_AMOUNT),0) OPENING FROM ACC_MAIN_LEDGER ";
                strSQL = strSQL + "WHERE (COMP_VOUCHER_DATE BETWEEN  " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                strSQL = strSQL + "AND LEDGER_GROUP = 213 AND LEDGER_PRIMARY_TYPE = 4 AND LEDGER_LEVEL = 2 ";
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    DIREXPLED = Convert.ToDouble(dr["OPENING"].ToString());

                }

                MANUCOST = ((OPNRAWDIR + PURRAWDIR + RETRAWDIR + DIREXPGRP + DIREXPLED) - CLSRAWDIR) ;
              


                //strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) AS OPENING FROM INV_STOCK_QRY ";
                //strSQL = strSQL + "WHERE INV_DATE < " + Utility.cvtSQLDateString(strFdate) + " ";
                //if (vstrBranchID != "")
                //{
                //    strSQL = strSQL + " AND BRANCH_ID='" + vstrBranchID + "' ";
                //}
                //cmdGet.CommandText = strSQL;
                //cmdGet.Connection = gcnMain;
                //dr = cmdGet.ExecuteReader();
                //if (dr.Read())
                //{
                //    dblOpeningStock = Convert.ToDouble(dr["OPENING"].ToString());

                //}
                //dr.Close();

                //strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) AS OPENING FROM INV_STOCK_QRY ";
                //strSQL = strSQL + "WHERE INV_DATE <= " + Utility.cvtSQLDateString(strTDate) + " ";
                //if (vstrBranchID != "")
                //{
                //    strSQL = strSQL + " AND BRANCH_ID='" + vstrBranchID + "' ";
                //}
                //cmdGet.CommandText = strSQL;
                //cmdGet.Connection = gcnMain;
                //dr = cmdGet.ExecuteReader();
                //if (dr.Read())
                //{
                //    dblClosingStock = Convert.ToDouble(dr["OPENING"].ToString());

                //}
                //dr.Close();
                //strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) AS OPENING FROM INV_TRAN ";
                //strSQL = strSQL + "WHERE INV_DATE <= " + Utility.cvtSQLDateString(strTDate) + " ";
                //strSQL = strSQL + "AND INV_VOUCHER_TYPE = 23 ";
                //if (Utility.glngBusinessType == 4)
                //{
                //    strSQL = strSQL + "AND STOCKGROUP_PRIMARY_TYPE = 3 ";
                //}
                //if (vstrBranchID != "")
                //{
                //    strSQL = strSQL + " AND BRANCH_ID='" + vstrBranchID + "' ";
                //}
                //cmdGet.CommandText = strSQL;
                //cmdGet.Connection = gcnMain;
                //dr = cmdGet.ExecuteReader();
                //if (dr.Read())
                //{
                //    dblTransfer = Convert.ToDouble(dr["OPENING"].ToString());

                //}
                //dr.Close();

                //strSQL = "SELECT ";
                //strSQL = strSQL + "ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT - ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AS DEBIT_TOTAL ";
                //strSQL = strSQL + "FROM ACC_VOUCHER LEFT OUTER JOIN ";
                //strSQL = strSQL + "ACC_LEDGER_GROUP_QRY ON ACC_VOUCHER.LEDGER_NAME = ACC_LEDGER_GROUP_QRY.LEDGER_NAME ";
                //strSQL = strSQL + "WHERE (ACC_LEDGER_GROUP_QRY.GR_PRIMARY_TYPE = 4) ";
                //strSQL = strSQL + "AND ACC_LEDGER_GROUP_QRY.GR_GROUP LIKE '21%' ";
                //strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                //strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                //strSQL = strSQL + "AND ACC_LEDGER_GROUP_QRY.GR_LEVEL = 2 ";
                //if (vstrBranchID != "")
                //{
                //    strSQL = strSQL + " AND BRANCH_ID='" + vstrBranchID + "' ";
                //}
                //cmdGet.CommandText = strSQL;
                //cmdGet.Connection = gcnMain;
                //dr = cmdGet.ExecuteReader();
                //if (dr.Read())
                //{
                //    dblPurchase = Convert.ToDouble(dr["DEBIT_TOTAL"].ToString());

                //}
                //dr.Close();
                //strSQL = "SELECT ISNULL(SUM( VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS TOTAL ";
                //strSQL = strSQL + "FROM ACC_MAIN_LEDGER ";
                //strSQL = strSQL + "WHERE (COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                //strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                //strSQL = strSQL + "AND LEDGER_GROUP LIKE '211%' ";
                //strSQL = strSQL + "AND LEDGER_PRIMARY_TYPE = 3 ";
                //strSQL = strSQL + "AND LEDGER_LEVEL = 2 ";
                //if (vstrBranchID != "")
                //{
                //    strSQL = strSQL + " AND BRANCH_ID='" + vstrBranchID + "' ";
                //}
                //cmdGet.CommandText = strSQL;
                //cmdGet.Connection = gcnMain;
                //dr = cmdGet.ExecuteReader();
                //if (dr.Read())
                //{
                //    dblSales = dblSales + Convert.ToDouble(dr["TOTAL"].ToString());

                //}
                //dr.Close();

                //strSQL = "SELECT ISNULL(SUM(VOUCHER_DEBIT_AMOUNT - VOUCHER_CREDIT_AMOUNT),0) AS TOTAL ";
                //strSQL = strSQL + "FROM ACC_MAIN_LEDGER ";
                //strSQL = strSQL + "WHERE ";
                //strSQL = strSQL + "(COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                //strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                //strSQL = strSQL + "AND LEDGER_GROUP LIKE '21%' ";
                //strSQL = strSQL + "AND LEDGER_PRIMARY_TYPE = 4 ";
                //strSQL = strSQL + "AND LEDGER_LEVEL = 2 ";
                //if (vstrBranchID != "")
                //{
                //    strSQL = strSQL + " AND BRANCH_ID='" + vstrBranchID + "' ";
                //}
                //cmdGet.CommandText = strSQL;
                //cmdGet.Connection = gcnMain;
                //dr = cmdGet.ExecuteReader();
                //if (dr.Read())
                //{
                //    dblPurchase = dblPurchase + Convert.ToDouble(dr["TOTAL"].ToString());

                //}
                //dr.Close();


                //gcnMain.Close();
                ////dblCGS = (dblOpeningStock + dblPurchase + dblTransfer) - dblClosingStock;
                //dblCGS = (dblOpeningStock + dblPurchase) - dblClosingStock;

                //return (dblSales - dblCGS);
                return MANUCOST;
            }
        }

        public static double gdblGPMFSplit(string strDeComID, string strSourceDB)
        {
            string strSQL = null;
            string conDb;
            string strFdate = "", strTDate = "", vstrBranchID = "";
            double dblOpeningStock = 0, dblClosingStock = 0, dblCGS = 0, dblPurchase = 0, dblSales = 0, dblTransfer = 0;
            double dblIncome1 = 0, dblExpenses = 0, dblTotalIncome = 0, dblTotalExpense = 0;
            conDb = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdGet = new SqlCommand();

                strSQL = "SELECT COMPANY_ID,COMPANY_FINICIAL_YEAR_FROM   ,COMPANY_FINICIAL_YEAR_TO  FROM " + strSourceDB + ".dbo.ACC_COMPANY ";
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    strFdate = Convert.ToDateTime(dr["COMPANY_FINICIAL_YEAR_FROM"]).ToString("dd-MM-yyyy");
                    strTDate = Convert.ToDateTime(dr["COMPANY_FINICIAL_YEAR_TO"]).ToString("dd-MM-yyyy");
                    vstrBranchID = dr["COMPANY_ID"].ToString();
                }
                dr.Close();


                strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) AS OPENING FROM " + strSourceDB + ".dbo.INV_STOCK_QRY ";
                strSQL = strSQL + "WHERE INV_DATE < " + Utility.cvtSQLDateString(strFdate) + " ";
                //if (vstrBranchID != "")
                //{
                //    strSQL = strSQL + " AND BRANCH_ID='" + vstrBranchID + "' ";
                //}
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    dblOpeningStock = Convert.ToDouble(dr["OPENING"].ToString());

                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) AS OPENING FROM " + strSourceDB + ".dbo.INV_STOCK_QRY ";
                strSQL = strSQL + "WHERE INV_DATE <= " + Utility.cvtSQLDateString(strTDate) + " ";
                //if (vstrBranchID != "")
                //{
                //    strSQL = strSQL + " AND BRANCH_ID='" + vstrBranchID + "' ";
                //}
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    dblClosingStock = Convert.ToDouble(dr["OPENING"].ToString());

                }
                dr.Close();
                strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) AS OPENING FROM " + strSourceDB + ".dbo.INV_TRAN ";
                strSQL = strSQL + "WHERE INV_DATE <= " + Utility.cvtSQLDateString(strTDate) + " ";
                strSQL = strSQL + "AND INV_VOUCHER_TYPE = 23 ";
                if (Utility.glngBusinessType == 4)
                {
                    //strSQL = strSQL + "AND STOCKGROUP_PRIMARY_TYPE = 3 ";
                }
                //if (vstrBranchID != "")
                //{
                //    strSQL = strSQL + " AND BRANCH_ID='" + vstrBranchID + "' ";
                //}
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    dblTransfer = Convert.ToDouble(dr["OPENING"].ToString());

                }
                dr.Close();

                strSQL = "SELECT ";
                strSQL = strSQL + "ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT - ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AS DEBIT_TOTAL ";
                strSQL = strSQL + "FROM " + strSourceDB + ".dbo.ACC_VOUCHER LEFT OUTER JOIN ";
                strSQL = strSQL + "" + strSourceDB + ".dbo.ACC_LEDGER_GROUP_QRY ON ACC_VOUCHER.LEDGER_NAME = ACC_LEDGER_GROUP_QRY.LEDGER_NAME ";
                strSQL = strSQL + "WHERE (ACC_LEDGER_GROUP_QRY.GR_PRIMARY_TYPE = 4) ";
                strSQL = strSQL + "AND ACC_LEDGER_GROUP_QRY.GR_GROUP LIKE '21%' ";
                strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                strSQL = strSQL + "AND ACC_LEDGER_GROUP_QRY.GR_LEVEL = 2 ";
                //if (vstrBranchID != "")
                //{
                //    strSQL = strSQL + " AND BRANCH_ID='" + vstrBranchID + "' ";
                //}
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    dblPurchase = Convert.ToDouble(dr["DEBIT_TOTAL"].ToString());

                }
                dr.Close();
                strSQL = "SELECT ISNULL(SUM( VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS TOTAL ";
                strSQL = strSQL + "FROM " + strSourceDB + ".dbo.ACC_MAIN_LEDGER ";
                strSQL = strSQL + "WHERE (COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                strSQL = strSQL + "AND LEDGER_GROUP LIKE '211%' ";
                strSQL = strSQL + "AND LEDGER_PRIMARY_TYPE = 3 ";
                strSQL = strSQL + "AND LEDGER_LEVEL = 2 ";
                //if (vstrBranchID != "")
                //{
                //    strSQL = strSQL + " AND BRANCH_ID='" + vstrBranchID + "' ";
                //}
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    dblSales = dblSales + Convert.ToDouble(dr["TOTAL"].ToString());

                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_DEBIT_AMOUNT - VOUCHER_CREDIT_AMOUNT),0) AS TOTAL ";
                strSQL = strSQL + "FROM " + strSourceDB + ".dbo.ACC_MAIN_LEDGER ";
                strSQL = strSQL + "WHERE ";
                strSQL = strSQL + "(COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                strSQL = strSQL + "AND LEDGER_GROUP LIKE '21%' ";
                strSQL = strSQL + "AND LEDGER_PRIMARY_TYPE = 4 ";
                strSQL = strSQL + "AND LEDGER_LEVEL = 2 ";
                //if (vstrBranchID != "")
                //{
                //    strSQL = strSQL + " AND BRANCH_ID='" + vstrBranchID + "' ";
                //}
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    dblPurchase = dblPurchase + Convert.ToDouble(dr["TOTAL"].ToString());

                }
                dr.Close();


              
                //dblCGS = (dblOpeningStock + dblPurchase + dblTransfer) - dblClosingStock;
                dblCGS = (dblOpeningStock + dblPurchase) - dblClosingStock;

                //return (dblSales - dblCGS);

               



                //-- Income Transaction

                strSQL = "SELECT  ";
                strSQL = strSQL + "SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT - ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT) AS DEBIT_TOTAL ";
                strSQL = strSQL + "FROM  " + strSourceDB + ".dbo.ACC_VOUCHER LEFT OUTER JOIN ";
                strSQL = strSQL + "" + strSourceDB + ".dbo.ACC_LEDGER_GROUP_QRY ON " + strSourceDB + ".dbo.ACC_VOUCHER.LEDGER_NAME = ACC_LEDGER_GROUP_QRY.LEDGER_NAME ";
                strSQL = strSQL + "WHERE (ACC_LEDGER_GROUP_QRY.GR_PRIMARY_TYPE = 3) ";
                // strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = " + vstrBranchID + " "
                strSQL = strSQL + "AND ACC_LEDGER_GROUP_QRY.GR_GROUP <> '211' ";
                strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                strSQL = strSQL + "AND ACC_LEDGER_GROUP_QRY.GR_LEVEL = 2 ";
                strSQL = strSQL + "GROUP BY ACC_LEDGER_GROUP_QRY.GR_NAME, ACC_LEDGER_GROUP_QRY.GR_PARENT,ACC_LEDGER_GROUP_QRY.GR_PRIMARY_TYPE ";
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    dblIncome1 = Convert.ToDouble(dr["DEBIT_TOTAL"].ToString());

                }
                dr.Close();




                strSQL = "SELECT LEDGER_NAME,LEDGER_PARENT_GROUP,LEDGER_PRIMARY_TYPE,SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT) AS TOTAL ";
                strSQL = strSQL + "FROM " + strSourceDB + ".dbo.ACC_MAIN_LEDGER ";
                strSQL = strSQL + " WHERE ";
                strSQL = strSQL + "(COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                //   strSQL = strSQL + "AND BRANCH_ID = '" + vstrBranchID + "' "
                strSQL = strSQL + "AND LEDGER_GROUP <> '211' ";
                strSQL = strSQL + "AND LEDGER_PRIMARY_TYPE = 3 ";
                strSQL = strSQL + "AND LEDGER_LEVEL = 2 ";
                strSQL = strSQL + "GROUP BY LEDGER_NAME, LEDGER_PARENT_GROUP,LEDGER_PRIMARY_TYPE";
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    dblIncome1 = dblIncome1 + Convert.ToDouble(dr["TOTAL"].ToString());

                }
                dr.Close();
                // //-- Expenses Transaction

                strSQL = "SELECT ";
                strSQL = strSQL + "SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT - ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT) AS DEBIT_TOTAL ";
                strSQL = strSQL + "FROM " + strSourceDB + ".dbo.ACC_VOUCHER LEFT OUTER JOIN ";
                strSQL = strSQL + "" + strSourceDB + ".dbo.ACC_LEDGER_GROUP_QRY ON ACC_VOUCHER.LEDGER_NAME = ACC_LEDGER_GROUP_QRY.LEDGER_NAME ";
                strSQL = strSQL + "WHERE (ACC_LEDGER_GROUP_QRY.GR_PRIMARY_TYPE = 4) ";
                // strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = " + vstrBranchID + " "

                strSQL = strSQL + "AND ACC_LEDGER_GROUP_QRY.GR_GROUP NOT LIKE '21%' ";
                strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                strSQL = strSQL + "AND ACC_LEDGER_GROUP_QRY.GR_LEVEL = 2 ";
                strSQL = strSQL + "GROUP BY ACC_LEDGER_GROUP_QRY.GR_NAME, ACC_LEDGER_GROUP_QRY.GR_PARENT,ACC_LEDGER_GROUP_QRY.GR_PRIMARY_TYPE ";
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    dblExpenses = Convert.ToDouble(dr["DEBIT_TOTAL"].ToString());

                }
                dr.Close();

                strSQL = "SELECT SUM(VOUCHER_DEBIT_AMOUNT - VOUCHER_CREDIT_AMOUNT) AS TOTAL ";
                strSQL = strSQL + "FROM " + strSourceDB + ".dbo.ACC_MAIN_LEDGER ";
                strSQL = strSQL + " WHERE ";
                strSQL = strSQL + "(COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                //    strSQL = strSQL + "AND BRANCH_ID = '" + vstrBranchID + "' "
                strSQL = strSQL + "AND LEDGER_GROUP NOT LIKE '21%' ";
                strSQL = strSQL + "AND LEDGER_PRIMARY_TYPE = 4 ";
                strSQL = strSQL + "AND LEDGER_LEVEL = 2 ";
                strSQL = strSQL + "GROUP BY LEDGER_NAME, LEDGER_PARENT_GROUP,LEDGER_PRIMARY_TYPE";
                cmdGet.CommandText = strSQL;
                cmdGet.Connection = gcnMain;
                dr = cmdGet.ExecuteReader();
                if (dr.Read())
                {
                    dblExpenses = dblExpenses + Convert.ToDouble(dr["TOTAL"].ToString());

                }
                dr.Close();


                //strSQL = "SELECT ISNULL(SUM(GR_AMOUNT),0) AS GR_AMOUNT FROM ACC_PROFIT_AND_LOSS WHERE GR_PRIMARY_TYPE = 3 ";
                //cmdGet.CommandText = strSQL;
                //cmdGet.Connection = gcnMain;
                //dr = cmdGet.ExecuteReader();
                //if (dr.Read())
                //{
                //    dblTotalIncome = Convert.ToDouble(dr["GR_AMOUNT"].ToString());
                //}
                //dr.Close();
                //strSQL = "SELECT ISNULL(SUM(GR_AMOUNT),0) AS GR_AMOUNT FROM ACC_PROFIT_AND_LOSS WHERE GR_PRIMARY_TYPE = 4  ";
                //cmdGet.CommandText = strSQL;
                //cmdGet.Connection = gcnMain;
                //dr = cmdGet.ExecuteReader();
                //if (dr.Read())
                //{
                //    dblTotalExpense = Convert.ToDouble(dr["GR_AMOUNT"].ToString());
                //}
                //dr.Close();
                if (dblTotalIncome > dblTotalExpense)
                {
                    dblCGS = dblCGS + (dblTotalIncome - dblTotalExpense);
                }
                if (dblTotalIncome < dblTotalExpense)
                {
                    dblCGS = dblCGS + (dblTotalExpense - dblTotalIncome);
                }

                return Math.Round(dblCGS,2);



            }
        }
        #region "SecurityGroup"
        public static string mLoadStockGroupSecurity(string strCondb, string vstrUserName)
        {
            string strSQL, strString = "", conDb;
            SqlDataReader drGetGroup;
            conDb = SQLConnstringComSwitch(strCondb);
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    strSQL = "SELECT STOCKGROUP_NAME from USER_PRIVILEGES_STOCKGROUP ";
                    strSQL = strSQL + " WHERE USER_LOGIN_NAME = '" + vstrUserName + "'";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    drGetGroup = cmd.ExecuteReader();
                    while (drGetGroup.Read())
                    {
                        strString = strString + "'" + drGetGroup["STOCKGROUP_NAME"].ToString().Replace("'","''") + "',";
                    }
                    drGetGroup.Close();
                    gcnMain.Dispose();
                    if (strString != "")
                    {
                        strString = Utility.Mid(strString, 0, strString.Length - 1);
                    }
                    return strString;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }

            }
        }
        public static string mLoadStockItemSecurity(string strCondb, string vstrUserName)
        {
            string strSQL, strString = "", conDb;
            SqlDataReader drGetGroup;
            conDb = SQLConnstringComSwitch(strCondb);
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    strSQL = "SELECT DISTINCT INV_STOCKITEM.STOCKITEM_NAME  from USER_PRIVILEGES_STOCKGROUP, INV_STOCKITEM WHERE INV_STOCKITEM.STOCKGROUP_NAME= USER_PRIVILEGES_STOCKGROUP.STOCKGROUP_NAME ";
                    strSQL = strSQL + " AND USER_PRIVILEGES_STOCKGROUP.USER_LOGIN_NAME = '" + vstrUserName + "'";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    drGetGroup = cmd.ExecuteReader();
                    while (drGetGroup.Read())
                    {
                        strString = strString + "'" + drGetGroup["STOCKITEM_NAME"].ToString().Replace("'","''") + "',";
                    }
                    drGetGroup.Close();
                    gcnMain.Dispose();
                    if (strString != "")
                    {
                        strString = Utility.Mid(strString, 0, strString.Length - 1);
                    }
                    return strString;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }

            }
        }
        #endregion

        public static double dblLedgerSalesClosing(string strDeComID, string strFdate, string strTDate,
                                                   string vstrLedgerName, string strBranchID)
        {
            string strSQL = null;
            string connstring;
            double dblBackYearOpening = 0, dblOPening = 0, dblYearOpening = 0, dblOpeningDr = 0, dblOpeningCr = 0,
                                       dblTotalCredit = 0, dblTotalDebit = 0, dblclosing = 0;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;
                if (strBranchID == "")
                {
                    strSQL = "SELECT LEDGER_OPENING_BALANCE AS OPENING FROM ACC_LEDGER ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                }
                else
                {
                    strSQL = "SELECT BRANCH_LEDGER_OPENING_BALANCE AS OPENING FROM ACC_BRANCH_LEDGER_OPENING ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName.Replace("'", "''") + "' ";
                    if (strBranchID != "")
                    {
                        strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                    }
                }

                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblOPening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();
                strBranchID = "";

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + "INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE >= ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + "";
                strSQL = strSQL + " AND  ";
                strSQL = strSQL + " ACC_VOUCHER.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strTDate) + " ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + " INNER JOIN ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE < ";
                strSQL = strSQL + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrASSET + " OR ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrLIABILITY + " ) ";

                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblBackYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + "WHERE COMP_VOUCHER_TYPE =13 ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE >= ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + "";
                strSQL = strSQL + " AND  ";
                strSQL = strSQL + " COMP_VOUCHER_DATE <= " + Utility.cvtSQLDateString(strTDate) + " ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblYearOpening = dblYearOpening+ Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();


                dblOPening = dblYearOpening + dblBackYearOpening + dblOPening;

                if (dblOPening < 0)
                {
                    dblOpeningDr = dblOPening;
                }
                else
                {
                    dblOpeningCr = dblOPening;
                }
                ///Sales Invoice Credit Limit
                //strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT),0) AS TOTAL_CREDIT,";
                //strSQL = strSQL + "ISNULL(SUM(VOUCHER_DEBIT_AMOUNT),0) AS TOTAL_DEBIT ";
                //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.ACC_VOUCHER ";
                //strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                //strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN ";
                //strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + " ";
                //strSQL = strSQL + "AND ";
                //strSQL = strSQL + " " + Utility.cvtSQLDateString(strTDate) + ") ";
                //if (strBranchID != "")
                //{
                //    strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                //}
                //cmdInsert.CommandText = strSQL;
                //dr = cmdInsert.ExecuteReader();
                //if (dr.Read())
                //{
                //    dblTotalCredit = Convert.ToDouble(dr["TOTAL_CREDIT"].ToString());
                //    dblTotalDebit = Convert.ToDouble(dr["TOTAL_DEBIT"].ToString());
                //}
                //dr.Close();
                dblclosing = dblOPening + (dblTotalCredit - dblTotalDebit);

                dr.Close();
                gcnMain.Close();
                cmdInsert.Dispose();
                return Math.Round(dblclosing, 2);

            }
        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        public static double dblLedgerClosingBalanceSplit(string strDeComID, string strFdate, string strTDate,
                                                    string vstrLedgerName, string strBranchID, string strSourceDB)
        {
            string strSQL = null;
            string connstring;
            double dblBackYearOpening = 0, dblOPening = 0, dblYearOpening = 0, dblOpeningDr = 0, dblOpeningCr = 0,
                                       dblTotalCredit = 0, dblTotalDebit = 0, dblclosing = 0;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;
                if (strBranchID == "")
                {
                    strSQL = "SELECT LEDGER_OPENING_BALANCE AS OPENING FROM " + strSourceDB + ".dbo.ACC_LEDGER ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                }
                else
                {
                    strSQL = "SELECT BRANCH_LEDGER_OPENING_BALANCE AS OPENING FROM " + strSourceDB + ".dbo.ACC_BRANCH_LEDGER_OPENING ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName.Replace("'", "''") + "' ";
                    if (strBranchID != "")
                    {
                        strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                    }
                }

                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblOPening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();
                strBranchID = "";

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM " + strSourceDB + ".dbo.ACC_VOUCHER ";
                strSQL = strSQL + "INNER JOIN " + strSourceDB + ".dbo.ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE >= ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + "";
                strSQL = strSQL + " AND  ";
                strSQL = strSQL + " ACC_VOUCHER.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strTDate) + " ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM " + strSourceDB + ".dbo.ACC_VOUCHER ";
                strSQL = strSQL + " INNER JOIN " + strSourceDB + ".dbo.ACC_LEDGER ON ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE < ";
                strSQL = strSQL + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrASSET + " OR ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrLIABILITY + " ) ";

                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblBackYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();


                dblOPening = dblYearOpening + dblBackYearOpening + dblOPening;

                if (dblOPening < 0)
                {
                    dblOpeningDr = dblOPening;
                }
                else
                {
                    dblOpeningCr = dblOPening;
                }
                ///Sales Invoice Credit Limit
                //strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT),0) AS TOTAL_CREDIT,";
                //strSQL = strSQL + "ISNULL(SUM(VOUCHER_DEBIT_AMOUNT),0) AS TOTAL_DEBIT ";
                //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.ACC_VOUCHER ";
                //strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                //strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN ";
                //strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + " ";
                //strSQL = strSQL + "AND ";
                //strSQL = strSQL + " " + Utility.cvtSQLDateString(strTDate) + ") ";
                //if (strBranchID != "")
                //{
                //    strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                //}
                //cmdInsert.CommandText = strSQL;
                //dr = cmdInsert.ExecuteReader();
                //if (dr.Read())
                //{
                //    dblTotalCredit = Convert.ToDouble(dr["TOTAL_CREDIT"].ToString());
                //    dblTotalDebit = Convert.ToDouble(dr["TOTAL_DEBIT"].ToString());
                //}
                //dr.Close();
                dblclosing = dblOPening + (dblTotalCredit - dblTotalDebit);

                dr.Close();
                gcnMain.Close();
                cmdInsert.Dispose();
                return Math.Round(dblclosing,2);

            }
        }
        public static double dblLedgerCollectionforMonth(string strDeComID, string strFdate, string strTDate,
                                                 string vstrLedgerName, string strBranchID)
        {
            string strSQL = null;
            string connstring;
            double dblOPening = 0, dblTotalCredit = 0, dblTotalDebit = 0, dblclosing = 0;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT),0) AS TOTAL_CREDIT,";
                strSQL = strSQL + "ISNULL(SUM(VOUCHER_DEBIT_AMOUNT),0) AS TOTAL_DEBIT ";
                strSQL = strSQL + "FROM ACC_VOUCHER ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strTDate) + ") ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND BRANCH_ID = '" + strBranchID + "' ";
                }
                strSQL = strSQL + "AND COMP_VOUCHER_TYPE = 1 ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblTotalCredit = Convert.ToDouble(dr["TOTAL_CREDIT"].ToString());
                    dblTotalDebit = Convert.ToDouble(dr["TOTAL_DEBIT"].ToString());
                }
                //dr.Close();
                dblclosing = dblOPening + (dblTotalCredit - dblTotalDebit);

                dr.Close();
                gcnMain.Close();
                cmdInsert.Dispose();
                return dblclosing;

            }
        }
        public static string gInsertRepacking(string strcomID, string vstrRefNo, string vstrItemName, double dblQty,string vstrDate,string vstrGodowns)
        {

            string strSQL, connstring;
            connstring = Utility.SQLConnstringComSwitch(strcomID);
            try
            {
                using (SqlConnection gcnMain = new SqlConnection(connstring))
                {
                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }
                    gcnMain.Open();
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    //strSQL = "DELETE FROM INV_TRAN_REPACKING ";
                    //strSQL = strSQL + "WHERE INV_REF_NO='" + vstrRefNo + "' ";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();

                   
                    strSQL = "INSERT INTO INV_TRAN_REPACKING(";
                    strSQL = strSQL + "INV_REF_NO,STOCKITEM_NAME,QNTY,COMP_VOUCHER_DATE,GODOWNS_NAME";
                    strSQL = strSQL + ") ";
                    strSQL = strSQL + "VALUES";
                    strSQL = strSQL + "(";
                    strSQL = strSQL + "'" + vstrRefNo + "'";
                    strSQL = strSQL + ",'" + vstrItemName.Replace("'","''") + "'";
                    strSQL = strSQL + "," + dblQty + "";
                    strSQL = strSQL + "," + cvtSQLDateString(vstrDate)  + " ";
                    strSQL = strSQL + ",'" + vstrGodowns.Replace("'", "''") + "'";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    return "1";

                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
            }

        }

        public static string mCheckAutoJV(string strcomID, string strValue)
        {
            string strSQL, strString = "";
            string conDb;
            SqlDataReader dr;
            conDb = SQLConnstringComSwitch(strcomID);
            strSQL = "SELECT  AUTOJV FROM ACC_COMPANY_VOUCHER ";
            strSQL = strSQL + "WHERE COMP_REF_NO ='" + strValue + "' ";
            strSQL = strSQL + "AND AUTOJV=1 ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    strString = "Sorry!Auto Journal Cannot be Alter";
                }
                dr.Close();
                gcnMain.Dispose();
                return strString;

            }
        }
       

    }
}
