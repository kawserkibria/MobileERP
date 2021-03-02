using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutility
{
    public class CreateView
    {
        
         public static string gCreateViewAccounts()
         {
             string strSQL;
             strSQL = CreateLedgerGroupView();
             strSQL = CreateCompanyVoucherBranchUserView();
             strSQL = CreateCompanyVoucherBranchView();
             return strSQL;
         }

         private static string CreateLedgerGroupView()
         {
             using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
             {
                 if (gcnmain.State == System.Data.ConnectionState.Open)
                 {
                     gcnmain.Close();
                 }
                 try
                 {
                     gcnmain.Open();
                     string strSQL;
                     SqlCommand cmd = new SqlCommand();
                     cmd.Connection = gcnmain;
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_GROUP_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_GROUP_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                     strSQL = "CREATE VIEW ACC_LEDGER_GROUP_QRY AS ";
                     strSQL = strSQL + "SELECT ";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_NAME AS GR_NAME,";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_PARENT AS GR_PARENT,";
                     strSQL = strSQL + "ACC_LEDGER_TO_GROUP.LEDGER_NAME AS LEDGER_NAME,";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_OPENING_DEBIT,";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_OPENING_CREDIT,";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_DEBIT_TOTAL, ";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_CREDIT_TOTAL, ";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_CLOSING_DEBIT,";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_CLOSING_CREDIT,";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_PRIMARY_TYPE, ";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_LEVEL, ";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_GROUP, ";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_CASH_FLOW_TYPE ";
                     strSQL = strSQL + "FROM ACC_LEDGERGROUP INNER JOIN ";
                     strSQL = strSQL + "ACC_LEDGER_TO_GROUP ON ";
                     strSQL = strSQL + "ACC_LEDGERGROUP.GR_NAME = ACC_LEDGER_TO_GROUP.GR_NAME ";
                     
                     cmd.CommandText = strSQL;
                     cmd.ExecuteNonQuery();
                     return strSQL;
                 }

                 finally
                 {
                     gcnmain.Close();
                 }
             }
         }


         private static string CreateCompanyVoucherBranchUserView()
         {
             using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
             {
                 if (gcnmain.State == System.Data.ConnectionState.Open)
                 {
                     gcnmain.Close();
                 }
                 try
                 {
                     gcnmain.Open();
                     string strSQL;
                     SqlCommand cmd = new SqlCommand();
                     cmd.Connection = gcnmain;
                     strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COMPANY_VOUCHER_BRANCH_USER_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                     strSQL = strSQL + "drop view [dbo].[ACC_COMPANY_VOUCHER_BRANCH_USER_VIEW]";
                     cmd.CommandText = strSQL;
                     cmd.ExecuteNonQuery();
                    
                    strSQL = "CREATE VIEW ACC_COMPANY_VOUCHER_BRANCH_USER_VIEW AS ";
                    strSQL = strSQL + "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO, SUBSTRING(ACC_COMPANY_VOUCHER.COMP_REF_NO, 7, 23) AS REF_NO,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.LEDGER_NAME, ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_AMOUNT, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION , ACC_BRANCH.BRANCH_NAME, USER_PRIVILEGES_BRANCH.USER_LOGIN_NAME, ACC_BRANCH.BRANCH_ID ";
                    strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID INNER JOIN ";
                    strSQL = strSQL + "USER_PRIVILEGES_BRANCH ON ACC_BRANCH.BRANCH_ID = USER_PRIVILEGES_BRANCH.BRANCH_ID ";

                     cmd.CommandText = strSQL;
                     cmd.ExecuteNonQuery();
                     return strSQL;
                 }

                 finally
                 {
                     gcnmain.Close();
                 }
             }
         }

         private static string CreateCompanyVoucherBranchView()
         {
             using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
             {
                 if (gcnmain.State == System.Data.ConnectionState.Open)
                 {
                     gcnmain.Close();
                 }
                 try
                 {
                     gcnmain.Open();
                     string strSQL;
                     SqlCommand cmd = new SqlCommand();
                     cmd.Connection = gcnmain;
                     strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COMPANY_VOUCHER_BRANCH_VIEW ]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                     strSQL = strSQL + "drop view [dbo].[ACC_COMPANY_VOUCHER_BRANCH_VIEW ]";
                     cmd.CommandText = strSQL;
                     cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_COMPANY_VOUCHER_BRANCH_VIEW AS ";
                    strSQL = strSQL + "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO,SUBSTRING(ACC_COMPANY_VOUCHER.COMP_REF_NO,7,23) AS REF_NO,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.LEDGER_NAME,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_AMOUNT,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION,";
                    strSQL = strSQL + "ACC_BRANCH.BRANCH_NAME AS BRANCH_NAME ";
                    strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID ";

                     cmd.CommandText = strSQL;
                     cmd.ExecuteNonQuery();
                     return strSQL;
                 }

                 finally
                 {
                     gcnmain.Close();
                 }
             }
         }


    }
}
