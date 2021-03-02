using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutility
{
    public class basViewSchemaAccount
    {

        public static string gCreateViewAccount()
        {
            string strSQL;
            strSQL = CreateLedgerGroupQry();
            strSQL = CreateLedgerView();
            strSQL = CreateLedgerViewBranch();
            strSQL = CreateCompanyVoucherView();
            strSQL = CreateVoucherView();
            strSQL = CreateMainLedger();
            strSQL = CreateBalQry();
            strSQL = CreateLedgerVoucher();
            strSQL = CreateViewCompBillTran();
            strSQL = CreateBillTranProcessView();
            strSQL = CreateBillTranPendingView();
            //strSQL = CreateInvStockQty();
            strSQL = CreateAccBillWiseQry();
            strSQL = CreatePriceLevelView();
            strSQL = CreateAccBranchGroupOpening();
            strSQL = CreateInvStockItemTranQry();
            strSQL = CreateStockItemClosingQry();
            strSQL = CreateManufactureStockQry();
            strSQL = CreateFixedAssetView();
            strSQL = CreateComBillLedgerGodownView();
            strSQL = CreateMainLedgerGrSummary();
            strSQL = CreateViewBranchGroupSummary();
            strSQL = CreateViewBranchGrSummary();
            strSQL = CreateViewVoucherBranchGrSummary();
            strSQL = CreateViewMonthlyLedgerSummary();
            strSQL = CreateLedgerOpeningAsOnQry();
            strSQL = CreateAccVchMultiLedger();
            strSQL = CreateAccCompanyVoucherDetails();
            strSQL = CreateSalesBillWiseQry();
            strSQL = CreateViewCopyBranch();
            strSQL = CreateViewCopyGroupBranch();

            //'BUDGET
            strSQL = CreateLedgerBudgetDetailView();
            strSQL = CreateVoucherBudgetView();
            strSQL = CreateVoucherLedgerBudgetDetailView();
            strSQL = CreateCompanyVoucherBranchView();
            strSQL = CreateCompanyVoucherBranchUserView();
            strSQL = CreateTrialBalanceView();
            strSQL = CreateVoucherSummaryPLBS();

            strSQL = CreateCostCentreOpeningView();
            strSQL = CreateCostCentreAsOnOpeningView();
            strSQL = CreateCostCentreTranDrView();
            strSQL = CreateCostCentreTranCrView();
            strSQL = CreateCostCentreTrialBalanceView();

            strSQL = CreateSalesAndReceiptByMonth();
            strSQL = CreateSalItemSoldByMonthQry();

            strSQL = CreateUserPrivilegesBranchView();
            strSQL = CreateMultiCashBankView();
            strSQL = CreateVoucherSummary();
            strSQL = CreateVoucherSummaryTemp();
            strSQL = CreateLedgerVoucherSummaryTemp();
            //'POS
            strSQL = CreateAccPOSReportQry();
            strSQL = CreateGroupSummaryMonthWise();
            strSQL = CreateLedgerGroupCategoryView();
            strSQL = CreateLedgerGroupCategoryView1();
            strSQL = CreateSalesItemPriceView();
            strSQL = CreateFinalStatementView();
            strSQL = CreateDump();
            strSQL = CreateChequePaymentDetails();
            strSQL = CreateLedgerGroupView();

            strSQL = CreateLedgerCommissionTemp();

            return strSQL;
        }

        private static string CreateChequePaymentDetails()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_CHEQUE_PAYMENT_DETAILS]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_CHEQUE_PAYMENT_DETAILS]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_CHEQUE_PAYMENT_DETAILS AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER.LEDGER_NAME,ACC_VOUCHER.COMP_REF_NO, ACC_VOUCHER.COMP_VOUCHER_DATE, ACC_VOUCHER.VOUCHER_CHEQUE_NUMBER, ACC_VOUCHER.VOUCHER_CHEQUE_DATE,";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_CHEQUE_DRAWN_ON, ACC_LEDGER.LEDGER_GROUP, (ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT +ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT) AS AMOUNT, ACC_VOUCHER.VOUCHER_REVERSE_LEDGER, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION ";
                    strSQL = strSQL + "FROM ACC_LEDGER INNER JOIN ";
                    strSQL = strSQL + "ACC_VOUCHER ON dbo.ACC_LEDGER.LEDGER_NAME = dbo.ACC_VOUCHER.LEDGER_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER ON dbo.ACC_VOUCHER.COMP_REF_NO = dbo.ACC_COMPANY_VOUCHER.COMP_REF_NO ";
                    strSQL = strSQL + "WHERE (ACC_LEDGER.LEDGER_GROUP = 100) AND (ACC_VOUCHER.COMP_VOUCHER_TYPE NOT IN (1, 4))  ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_SAL_COLL_TARGET_ACHIEVE_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_SAL_COLL_TARGET_ACHIEVE_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_SAL_COLL_TARGET_ACHIEVE_VIEW AS ";
                    strSQL = strSQL + "SELECT  LEDGER_NAME, LEDGER_GROUP_NAME, SUM(SAL_TARGET) AS SAL_TARGET, SUM(SAL_ACHIEVE) AS SAL_ACHIEVE, SUM(COLL_TARGET) AS COLL_TARGET, ";
                    strSQL = strSQL + "SUM(COLL_ACHIEVE) AS COLL_ACHIEVE ";
                    strSQL = strSQL + "FROM ACC_SAL_COLL_TARGET_ACHIEVE ";
                    strSQL = strSQL + "GROUP BY LEDGER_NAME, LEDGER_GROUP_NAME";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_EXPENSE_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_EXPENSE_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGER_EXPENSE_VIEW AS ";
                    strSQL = strSQL + "SELECT LEDGER_NAME, HEAD_NAME1,HEAD_NAME,POSITION,SUM(CASH_AMOUNT)CASH_AMOUNT,SUM(CHECQUE_AMOUNT) CHECQUE_AMOUNT,SUM(CASH_AMOUNT1) CASH_AMOUNT1 ";
                    strSQL = strSQL + "FROM ACC_EXPENSE_DUMP ";
                    strSQL = strSQL + "GROUP BY LEDGER_NAME, HEAD_NAME1,HEAD_NAME,POSITION  ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_FIXED_ASSET_REPORT_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_FIXED_ASSET_REPORT_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_FIXED_ASSET_REPORT_QRY AS ";
                    strSQL = strSQL + "SELECT FIXED_ASSET_SCHEDULE.LEDGER_NAME, FIXED_ASSET_SCHEDULE.BRANCH_ID, FIXED_ASSET_SCHEDULE.ASSET_PREV_BAL,FIXED_ASSET_SCHEDULE.ASSET_ADD_THIS_PERIOD, ";
                    strSQL = strSQL + "FIXED_ASSET_SCHEDULE.ASSET_DISPOSAL_THIS_PERIOD,FIXED_ASSET_SCHEDULE.ASSET_DEP_RATE, FIXED_ASSET_SCHEDULE.ASSET_DEP_THIS_PERIOD, FIXED_ASSET_SCHEDULE.ASSET_DEP_ACCU, ";
                    strSQL = strSQL + "ISNULL(FIXED_ASSET_SCHEDULE.ASSET_DEP_ADJUSTMENT,0) AS ASSET_DEP_ADJUSTMENT, FIXED_ASSET_SCHEDULE.ASSET_PURCHASE_VALUE,ACC_LEDGER.LEDGER_PARENT_GROUP , ACC_LEDGER.LEDGER_STATUS, ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_LEVEL, ACC_LEDGER.LEDGER_GROUP FROM FIXED_ASSET_SCHEDULE INNER JOIN ACC_LEDGER ON FIXED_ASSET_SCHEDULE.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[V_DOCTORRS_COLLECTION]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[V_DOCTORRS_COLLECTION]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "create view V_DOCTORRS_COLLECTION as ";
                    strSQL = strSQL + "select  t1.COMP_REF_NO,t1.LEDGER_NAME_MERZE,t1.COMP_VOUCHER_NARRATION,t1.COMP_VOUCHER_NET_AMOUNT,t2.LEDGER_NAME_MERZE as Doctors,t2.VT_TRAN_AMOUNT ";
                    strSQL = strSQL + "from (select v.COMP_REF_NO, l.LEDGER_NAME,l.LEDGER_NAME_MERZE,v.COMP_VOUCHER_NET_AMOUNT,v.COMP_VOUCHER_NARRATION ";
                    strSQL = strSQL + "from ACC_LEDGER l,ACC_COMPANY_VOUCHER  v ";
                    strSQL = strSQL + "where l.LEDGER_NAME =v.LEDGER_NAME ";
                    strSQL = strSQL + "and v.SP_JOURNAL=2) as t1, ";
                    strSQL = strSQL + "(select v.COMP_REF_NO,l.LEDGER_NAME_MERZE,vt.VT_TRAN_AMOUNT ";
                    strSQL = strSQL + "from ACC_LEDGER l,VECTOR_TRANSACTION vt,ACC_COMPANY_VOUCHER v ";
                    strSQL = strSQL + "where l.LEDGER_NAME =vt.LEDGER_NAME  and v.COMP_REF_NO =vt.COMP_REF_NO  and v.SP_JOURNAL=2) as t2 ";
                    strSQL = strSQL + "where t1.COMP_REF_NO=t2.COMP_REF_NO ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_CUSTOMER_LIST]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_CUSTOMER_LIST]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_CUSTOMER_LIST AS ";
                    strSQL = strSQL + "SELECT LEDGER_CODE,LEDGER_NAME,LEDGER_NAME_MERZE,LEDGER_PARENT_GROUP, LEDGER_PRIMARY_GROUP, LEDGER_ADDRESS1, LEDGER_ADDRESS2 FROM  ACC_LEDGER WHERE (LEDGER_GROUP = 204)  ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_CHALLAN_AGAINS_INVOICE_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_CHALLAN_AGAINS_INVOICE_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE  view ACC_CHALLAN_AGAINS_INVOICE_VIEW as ";
                    strSQL = strSQL + "SELECT L.LEDGER_NAME,L.LEDGER_NAME_MERZE, C.COMP_VOUCHER_DATE AS CHALLAN_DATE, C.COMP_REF_NO, C.COMP_VOUCHER_NARRATION, C.CRT_QTY, C.BOX_QTY , C.COMP_OTHERS TRUCK_NO, ";
                    strSQL = strSQL + "C.COMP_VOUCHER_DESPATCH_THRU, C.COMP_VOUCHER_DESTINATION,C.TRANSPORT_NAME ";
                    strSQL = strSQL + "FROM   ACC_COMPANY_VOUCHER C,ACC_LEDGER L WHERE L.LEDGER_NAME =C.LEDGER_NAME  ";
                    strSQL = strSQL + "AND (COMP_VOUCHER_TYPE = 15) ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_CHALLAN_AGAINS_INVOICE_FINAL]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_CHALLAN_AGAINS_INVOICE_FINAL] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_CHALLAN_AGAINS_INVOICE_FINAL AS ";
                    strSQL = strSQL + "SELECT ACC_CHALLAN_AGAINS_INVOICE_VIEW.LEDGER_NAME_MERZE, ACC_CHALLAN_AGAINS_INVOICE_VIEW.CHALLAN_DATE, ACC_CHALLAN_AGAINS_INVOICE_VIEW.COMP_REF_NO, ";
                    strSQL = strSQL + "ACC_BILL_TRAN_PROCESS.AGST_COMP_REF_NO, ACC_CHALLAN_AGAINS_INVOICE_VIEW.CRT_QTY, ACC_CHALLAN_AGAINS_INVOICE_VIEW.BOX_QTY, ";
                    strSQL = strSQL + "ACC_CHALLAN_AGAINS_INVOICE_VIEW.TRUCK_NO, ACC_CHALLAN_AGAINS_INVOICE_VIEW.COMP_VOUCHER_DESPATCH_THRU, ";
                    strSQL = strSQL + "ACC_CHALLAN_AGAINS_INVOICE_VIEW.COMP_VOUCHER_DESTINATION, ACC_CHALLAN_AGAINS_INVOICE_VIEW.COMP_VOUCHER_NARRATION,ACC_CHALLAN_AGAINS_INVOICE_VIEW.TRANSPORT_NAME ";
                    strSQL = strSQL + "FROM  ACC_CHALLAN_AGAINS_INVOICE_VIEW INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN_PROCESS ON ACC_CHALLAN_AGAINS_INVOICE_VIEW.COMP_REF_NO = ACC_BILL_TRAN_PROCESS.COMP_REF_NO ";
                    strSQL = strSQL + "WHERE  (ACC_BILL_TRAN_PROCESS.COMP_VOUCHER_TYPE = 16) OR ";
                    strSQL = strSQL + "(ACC_BILL_TRAN_PROCESS.COMP_VOUCHER_TYPE = 15) ";
                    strSQL = strSQL + "GROUP BY ACC_CHALLAN_AGAINS_INVOICE_VIEW.LEDGER_NAME_MERZE, ACC_CHALLAN_AGAINS_INVOICE_VIEW.CHALLAN_DATE, ACC_CHALLAN_AGAINS_INVOICE_VIEW.COMP_REF_NO, ";
                    strSQL = strSQL + "ACC_BILL_TRAN_PROCESS.AGST_COMP_REF_NO, ACC_CHALLAN_AGAINS_INVOICE_VIEW.COMP_VOUCHER_NARRATION, ACC_CHALLAN_AGAINS_INVOICE_VIEW.CRT_QTY, ";
                    strSQL = strSQL + "ACC_CHALLAN_AGAINS_INVOICE_VIEW.BOX_QTY, ACC_CHALLAN_AGAINS_INVOICE_VIEW.TRUCK_NO, ";
                    strSQL = strSQL + "ACC_CHALLAN_AGAINS_INVOICE_VIEW.COMP_VOUCHER_DESPATCH_THRU, ACC_CHALLAN_AGAINS_INVOICE_VIEW.COMP_VOUCHER_DESTINATION,ACC_CHALLAN_AGAINS_INVOICE_VIEW.COMP_VOUCHER_NARRATION,ACC_CHALLAN_AGAINS_INVOICE_VIEW.TRANSPORT_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RV_VOUCHER_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[RV_VOUCHER_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW RV_VOUCHER_VIEW AS ";
                    strSQL = strSQL + "SELECT  COMP_REF_NO , LEDGER_NAME FROM ACC_VOUCHER WHERE COMP_VOUCHER_POSITION=2 and COMP_VOUCHER_TYPE =1  ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_BANK_WISE_COLLECTION]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_BANK_WISE_COLLECTION] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_BANK_WISE_COLLECTION AS ";
                    strSQL = strSQL + "SELECT LEDGER_NAME,REVERSE_LEDGER ,SUM(AMOUNT) RAMOUNT, 0 PAMOUNT FROM ACC_RP_VOCUHER_TEMP  WHERE VOUCHER_TYPE =1  GROUP bY LEDGER_NAME,REVERSE_LEDGER,VOUCHER_POSITION ";
                    strSQL = strSQL + "union all Select LEDGER_NAME,REVERSE_LEDGER ,0 RAMOUNT,SUM(AMOUNT) PAMOUNT FROM ACC_RP_VOCUHER_TEMP  WHERE VOUCHER_TYPE =2 ";
                    strSQL = strSQL + "GROUP bY LEDGER_NAME,REVERSE_LEDGER,VOUCHER_POSITION  ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_HONDALOAN_IND_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_HONDALOAN_IND_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_HONDALOAN_IND_VIEW AS SELECT DISTINCT DUE_DATE, INSTALLMET_NAME,";
                    strSQL = strSQL + " TO_BY, SUBSTRING(COMP_REF_NO, 7, 30) AS COMP_REF_NO, MONTHLY_AMOUNT, ";
                    strSQL = strSQL + "LEDGER_NAME FROM  ACC_PAYMENT_SCHEDULE AS S WHERE ";
                    strSQL = strSQL + " TO_BY = 'Dr' ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_HONDALOAN]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_HONDALOAN] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE VIEW ACC_HONDALOAN AS  SELECT DISTINCT   MIN(S.DUE_DATE) AS StartM, MAX(S.DUE_DATE) AS EndM, ";
                    strSQL = strSQL + "T.NO_OF_INSTALLMENT, SUM(S.MONTHLY_AMOUNT) AS InsAmount, COUNT(S.INSTALLMET_NAME) AS TEMPLATE_NAME,";
                    strSQL = strSQL + "MAX(S.MONTHLY_AMOUNT) AS MONTHLY_AMOUNT, S.COMP_REF_NO, S.LEDGER_NAME, ACC_LEDGER.LEDGER_NAME_MERZE,";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_PARENT_GROUP, ACC_LEDGER.LEDGER_PHONE FROM  ACC_PAYMENT_SCHEDULE AS S ";
                    strSQL = strSQL + "INNER JOIN ACC_LOAN_TEMPLATE_MASTER AS T ON S.TEMPLATE_NAME = T.TEMPLATE_NAME ";
                    strSQL = strSQL + "INNER JOIN ACC_LEDGER ON S.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME WHERE (S.TO_BY = 'Dr') ";
                    strSQL = strSQL + "GROUP BY T.NO_OF_INSTALLMENT, S.COMP_REF_NO, S.LEDGER_NAME, ACC_LEDGER.LEDGER_NAME_MERZE,";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_PARENT_GROUP, ACC_LEDGER.LEDGER_PHONE";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_HONDALOAN2]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_HONDALOAN2] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_HONDALOAN2 AS  SELECT DATEADD(month, -1, StartM) AS Loandate,  ";
                    strSQL = strSQL + "StartM, EndM, NO_OF_INSTALLMENT, InsAmount, TEMPLATE_NAME, MONTHLY_AMOUNT, COMP_REF_NO, ";
                    strSQL = strSQL + "LEDGER_NAME, LEDGER_NAME_MERZE, LEDGER_PARENT_GROUP,LEDGER_PHONE FROM   ACC_HONDALOAN ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    //Projection
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SALES_EVALUATION_VIEW ]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[SALES_EVALUATION_VIEW ] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW SALES_EVALUATION_VIEW  AS ";
                    strSQL = strSQL + "SELECT SORTING_TYPE,SEL_MODE,PARTICULARS,LEDGER_NAME,";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =1 THEN ISNULL(SUM(AMNT),0) ELSE 0 END  ) AS JAN, ";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =2 THEN ISNULL(SUM(AMNT),0) ELSE 0 END  ) AS FEB,";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =3 THEN ISNULL(SUM(AMNT),0)ELSE 0 END  ) AS MAR,";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =4 THEN ISNULL(SUM(AMNT),0) ELSE 0 END  ) AS APR,";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =5 THEN ISNULL(SUM(AMNT),0) ELSE 0 END  ) AS MAY,";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =6 THEN ISNULL(SUM(AMNT),0) ELSE 0 END  ) AS JUN,";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =7 THEN ISNULL(SUM(AMNT),0) ELSE 0 END  ) AS JUL,";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =8 THEN ISNULL(SUM(AMNT),0) ELSE 0 END  ) AS AUG,";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =9 THEN ISNULL(SUM(AMNT),0) ELSE 0 END  ) AS SEP,";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =10 THEN ISNULL(SUM(AMNT),0)ELSE 0  END  ) AS OCT,";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =11 THEN ISNULL(SUM(AMNT),0) ELSE 0 END  ) AS NOV,";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =12 THEN ISNULL(SUM(AMNT),0) ELSE 0 END  ) AS DEC, ";
                    strSQL = strSQL + "SUM(UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(BALANCE) BALANCE,SUM(TOTAL_PERCENT) TOTAL_PERCENT FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "GROUP BY SORTING_TYPE,SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    //*******************

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SALES_EVALUATION_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[SALES_EVALUATION_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW TwelveMonthView AS SELECT * FROM TWELVE_MONTH_SALES_TEMP ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BANCK_STATEMENT_V]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[BANCK_STATEMENT_V] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW BANCK_STATEMENT_V AS ";
                    strSQL = strSQL + "SELECT  ISNULL(sum(v.VOUCHER_CREDIT_AMOUNT),0)  As RAMOUNT,0 PAMOUNT from ACC_LEDGER l,ACC_VOUCHER v where l.LEDGER_NAME =v.REVERSE_LEDGER1 and v.VOUCHER_TOBY ='Cr' ";
                    strSQL = strSQL + "AND v.COMP_VOUCHER_TYPE =3 AND v.AUTOJV=1 and v.LEDG_PREFIX='HL' ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[collectionStatement_v]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[collectionStatement_v] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = strSQL + "CREATE VIEW  collectionStatement_v as ";
                    strSQL = strSQL + "SELECT  ISNULL(sum(v.VOUCHER_CREDIT_AMOUNT),0)  As RAMOUNT,0 PAMOUNT from ACC_LEDGER l,ACC_VOUCHER v where l.LEDGER_NAME =v.REVERSE_LEDGER1 and v.VOUCHER_TOBY ='Cr' ";
                    strSQL = strSQL + "AND v.COMP_VOUCHER_TYPE =3 AND v.AUTOJV=1 and v.LEDG_PREFIX='HL' ";
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


        private static string CreateFinalStatementView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_FINAL_STATEMENT_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_FINAL_STATEMENT_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_FINAL_STATEMENT_VIEW AS ";
                    strSQL = strSQL + "SELECT ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,DOCTOR_CUSTOMER, ";
                    strSQL = strSQL + "SUM(PREVIOUS_DUES_GOODS) AS PREVIOUS_DUES_GOODS,SUM(PREVIOUS_DUES_SHORT) AS PREVIOUS_DUES_SHORT,SUM(SALES_CURRENT_MONTH) AS SALES_CURRENT_MONTH, ";
                    strSQL = strSQL + "SUM(COLL_ON_COMMIT) AS COLL_ON_COMMIT,SUM(RETURN_AMOUNT) AS RETURN_AMOUNT ,SUM(DEBIT_AMOUNT) AS DEBIT_AMOUNT,SUM(CREDIT_AMOUNT) AS CREDIT_AMOUNT, ";
                    strSQL = strSQL + "SUM(COMMITMENT) AS COMMITMENT,SUM(COLL_CASH_TT) AS COLL_CASH_TT,SUM(COLL_VOUCHER) AS COLL_VOUCHER,SUM(CP_COMMISSION)AS CP_COMMISSION,SUM(PF_HL)AS PF_HL,POSITION ";
                    strSQL = strSQL + "FROM ACC_FINAL_STATEMENT ";
                    strSQL = strSQL + "GROUP BY ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,DOCTOR_CUSTOMER,POSITION ";
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
        private static string CreateSalesItemPriceView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_SALES_ITEM_PRICE_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_SALES_ITEM_PRICE_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW INV_SALES_ITEM_PRICE_VIEW AS ";
                    strSQL = strSQL + "SELECT STOCKITEM_NAME, SALES_PRICE_AMOUNT ";
                    strSQL = strSQL + "FROM INV_SALES_PRICE";
                    //strSQL = strSQL + "WHERE        (SALES_PRICE_EFFECTIVE_DATE <= CONVERT(datetime, '20-06-2018', 103))
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
        private static string CreateLedgerGroupCategoryView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGERGROUP_CATEGORY_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGERGROUP_CATEGORY_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGERGROUP_CATEGORY_VIEW AS ";
                    strSQL = strSQL + "SELECT GR_NAME,GR_PARENT  from ACC_LEDGERGROUP where GR_GROUP =202 ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    //strSQL = "CREATE VIEW ACC_LEDGERGROUP_CATEGORY_VIEW AS ";
                    //strSQL = strSQL + "SELECT LEDGER_GROUP_SERIAL, LEDGER_GROUP_NAME, LEDGER_GROUP_PARENT, LEDGER_GROUP_ONE_DOWN, LEDGER_GROUP_PRIMARY, LEDGER_GROUP_NAME_DEFAULT, LEDGER_GROUP_LEVEL, ";
                    //strSQL = strSQL + "LEDGER_GROUP_SEQUENCES, LEDGER_GROUP_PRIMARY_TYPE, LEDGER_GROUP_SECONDARY_TYPE, LEDGER_GROUP_DEFAULT, BRANCH_ID, INSERT_DATE, UPDATE_DATE, EXPORT_TYPE, EXPORT_FILE_NAME, ";
                    //strSQL = strSQL + "IMPORT_FILE_NAME ";
                    //strSQL = strSQL + "FROM ACC_LEDGERGROUP_CATEGORY ";
                    //strSQL = strSQL + "WHERE (LEDGER_GROUP_LEVEL = 3) AND (LEDGER_GROUP_PRIMARY <> 'PRIMARY')";
                    ////cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();
                    return strSQL;
                }

                finally
                {
                    gcnmain.Close();
                }
            }
        }

        private static string CreateLedgerGroupCategoryView1()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGERGROUP_CATEGORY_VIEW1]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGERGROUP_CATEGORY_VIEW1]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGERGROUP_CATEGORY_VIEW1 AS ";
                    strSQL = strSQL + "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO, ACC_COMPANY_VOUCHER.LEDGER_NAME, ACC_COMPANY_VOUCHER.ORDER_NO, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT, ACC_BILL_TRAN.COMP_REF_NO AS BILL_COMP_REF_NO, ACC_BILL_TRAN.STOCKITEM_NAME, ACC_BILL_TRAN.BILL_QUANTITY, ACC_BILL_TRAN.BILL_RATE, ";
                    strSQL = strSQL + "ACC_BILL_TRAN.BILL_UOM, ACC_BILL_TRAN.BILL_PER, ACC_BILL_TRAN.BILL_ADD_LESS, ACC_BILL_TRAN.BILL_NET_AMOUNT, ACC_BRANCH.BRANCH_NAME ";
                    strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_BRANCH AS ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN AS ACC_BILL_TRAN ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO ";
                    //strSQL = strSQL + "WHERE (ACC_BILL_TRAN.COMP_VOUCHER_DATE BETWEEN CONVERT(datetime, '01-09-2018', 103) AND CONVERT(datetime, '30-09-2018', 103)) AND (ACC_BILL_TRAN.BRANCH_ID = '0001') AND ";
                    //strSQL = strSQL + "(ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = 16 OR";
                    //strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = 18)";
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



        public static string CreateLedgerGroupView()
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
                    //strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_GROUP_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    //strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_GROUP_QRY]";
                    //cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();

                    //strSQL = "CREATE VIEW ACC_LEDGER_GROUP_QRY AS ";
                    //strSQL = strSQL + "SELECT ";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_NAME AS GR_NAME,";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_PARENT AS GR_PARENT,";
                    //strSQL = strSQL + "ACC_LEDGER_TO_GROUP.LEDGER_NAME AS LEDGER_NAME,";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_OPENING_DEBIT,";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_OPENING_CREDIT,";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_DEBIT_TOTAL, ";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_CREDIT_TOTAL, ";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_CLOSING_DEBIT,";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_CLOSING_CREDIT,";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_PRIMARY_TYPE, ";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_LEVEL, ";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_GROUP, ";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_CASH_FLOW_TYPE,ACC_LEDGERGROUP.GR_PRIMARY ";
                    //strSQL = strSQL + "FROM ACC_LEDGERGROUP INNER JOIN ";
                    //strSQL = strSQL + "ACC_LEDGER_TO_GROUP ON ";
                    //strSQL = strSQL + "ACC_LEDGERGROUP.GR_NAME = ACC_LEDGER_TO_GROUP.GR_NAME ";
                    //cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGERGROUP_CATEGORY_VIEW2]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGERGROUP_CATEGORY_VIEW2]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGERGROUP_CATEGORY_VIEW2 AS ";
                    strSQL = strSQL + "SELECT GR_NAME, GR_PARENT ";
                    strSQL = strSQL + "FROM ACC_LEDGERGROUP ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_Z_D_A_GROUP_OPN]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_Z_D_A_GROUP_OPN]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGER_Z_D_A_GROUP_OPN AS ";
                    strSQL = strSQL + "SELECT  g.GR_PARENT AS ZONE, g.GR_NAME AS DIVISION, l.LEDGER_PARENT_GROUP AS area, l.LEDGER_NAME, l.LEDGER_NAME_MERZE, l.LEDGER_OPENING_BALANCE, g.GR_GROUP, l.LEDGER_STATUS, l.BRANCH_ID,g.GR_ONE_DOWN ";
                    strSQL = strSQL + ",l.HALT_MPO FROM  ACC_LEDGERGROUP AS g INNER JOIN ";
                    strSQL = strSQL + " ACC_LEDGERGROUP_CATEGORY_VIEW2 AS v ON g.GR_NAME = v.GR_PARENT INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER AS l ON v.GR_NAME = l.LEDGER_PARENT_GROUP ";
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
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION , ACC_BRANCH.BRANCH_NAME, USER_PRIVILEGES_BRANCH.USER_LOGIN_NAME, ";
                    strSQL= strSQL + " ACC_BRANCH.BRANCH_ID,ACC_COMPANY_VOUCHER.SP_JOURNAL,ACC_COMPANY_VOUCHER.SAMPLE_STATUS,ACC_COMPANY_VOUCHER.APP_STATUS,ACC_COMPANY_VOUCHER.APPROVED_BY ";
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

        //private static string CreateCompanyVoucherBranchView()
        //{
        //    using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
        //    {
        //        if (gcnmain.State == System.Data.ConnectionState.Open)
        //        {
        //            gcnmain.Close();
        //        }
        //        try
        //        {
        //           gcnmain.Open();
        //           string strSQL;
        //           SqlCommand cmd = new SqlCommand();
        //           cmd.Connection = gcnmain;
        //           strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COMPANY_VOUCHER_BRANCH_VIEW ]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
        //           strSQL = strSQL + "drop view [dbo].[ACC_COMPANY_VOUCHER_BRANCH_VIEW ]";
        //           cmd.CommandText = strSQL;
        //           cmd.ExecuteNonQuery();
        //           strSQL = "CREATE VIEW ACC_COMPANY_VOUCHER_BRANCH_VIEW AS ";
        //           strSQL = strSQL + "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO,SUBSTRING(ACC_COMPANY_VOUCHER.COMP_REF_NO,7,23) AS REF_NO,";
        //           strSQL = strSQL + "ACC_COMPANY_VOUCHER.LEDGER_NAME,";
        //           strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE,";
        //           strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE,";
        //           strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_AMOUNT,";
        //           strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT,";
        //           strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION,";
        //           strSQL = strSQL + "ACC_BRANCH.BRANCH_NAME AS BRANCH_NAME ";
        //           strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER INNER JOIN ";
        //           strSQL = strSQL + "ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID ";
        //           cmd.CommandText = strSQL;
        //           cmd.ExecuteNonQuery();
        //           return strSQL;
        //        }

        //        finally
        //        {
        //            gcnmain.Close();
        //        }
        //    }
        //}



        private static string CreateGroupSummaryMonthWise()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_GROUP_VOUCHER]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_GROUP_VOUCHER]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_GROUP_VOUCHER AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGERGROUP.GR_NAME,ACC_LEDGERGROUP.GR_PARENT,ACC_VOUCHER.COMP_VOUCHER_DATE,";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT,ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT ";
                    strSQL = strSQL + "FROM ACC_LEDGER_TO_GROUP INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGERGROUP ON ACC_LEDGER_TO_GROUP.GR_NAME = ACC_LEDGERGROUP.GR_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_VOUCHER ON ACC_LEDGER_TO_GROUP.LEDGER_NAME = ACC_VOUCHER.LEDGER_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_GROUP_SUMMARY_MONTH_WISE]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_GROUP_SUMMARY_MONTH_WISE]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_GROUP_SUMMARY_MONTH_WISE AS ";
                    strSQL = strSQL + "SELECT * FROM ACC_GROUP_VOUCHER ";
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
        //private static string CreateCompanyVoucherBranchUserView()
        //{
        //        using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
        //        {
        //            if (gcnmain.State == System.Data.ConnectionState.Open)
        //            {
        //                gcnmain.Close();
        //            }
        //            try
        //            {
        //                gcnmain.Open();
        //                string strSQL;
        //                SqlCommand cmd = new SqlCommand();
        //                cmd.Connection = gcnmain;
        //                strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COMPANY_VOUCHER_BRANCH_USER_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
        //                strSQL = strSQL + "drop view [dbo].[ACC_COMPANY_VOUCHER_BRANCH_USER_VIEW]";
        //                cmd.CommandText = strSQL;
        //                cmd.ExecuteNonQuery();

        //                strSQL = "CREATE VIEW ACC_COMPANY_VOUCHER_BRANCH_USER_VIEW AS ";
        //                strSQL = strSQL + "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO, SUBSTRING(ACC_COMPANY_VOUCHER.COMP_REF_NO, 7, 23) AS REF_NO,";
        //                strSQL = strSQL + "ACC_COMPANY_VOUCHER.LEDGER_NAME, ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE,";
        //                strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_AMOUNT, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT,";
        //                strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION , ACC_BRANCH.BRANCH_NAME, USER_PRIVILEGES_BRANCH.USER_LOGIN_NAME, ACC_BRANCH.BRANCH_ID ";
        //                strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER INNER JOIN ";
        //                strSQL = strSQL + "ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID INNER JOIN ";
        //                strSQL = strSQL + "USER_PRIVILEGES_BRANCH ON ACC_BRANCH.BRANCH_ID = USER_PRIVILEGES_BRANCH.BRANCH_ID ";
        //                cmd.CommandText = strSQL;
        //                cmd.ExecuteNonQuery();
        //                return strSQL;
        //            }

        //            finally
        //            {
        //                gcnmain.Close();
        //            }
        //        }
        //    }
        private static string CreateUserPrivilegesBranchView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[USER_PRIVILEGES_BRANCH_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[USER_PRIVILEGES_BRANCH_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW USER_PRIVILEGES_BRANCH_VIEW AS ";
                    strSQL = strSQL + "SELECT ACC_BRANCH.BRANCH_ID,ACC_BRANCH.BRANCH_NAME,ACC_BRANCH.BRANCH_ACTIVE,USER_PRIVILEGES_BRANCH.USER_LOGIN_NAME ";
                    strSQL = strSQL + "FROM ACC_BRANCH INNER JOIN ";
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
        private static string CreateVoucherSummaryPLBS()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_VOUCHER_SUMMARY_BS]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_VOUCHER_SUMMARY_BS]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_VOUCHER_SUMMARY_BS AS ";
                    strSQL = strSQL + "SELECT LEDGER_NAME,SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT) AS AMT ";
                    strSQL = strSQL + "FROM ACC_VOUCHER GROUP BY LEDGER_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_VOUCHER_SUMMARY_PL]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_VOUCHER_SUMMARY_PL]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_VOUCHER_SUMMARY_PL AS ";
                    strSQL = strSQL + "SELECT LEDGER_NAME,SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT) AS AMT ";
                    strSQL = strSQL + "FROM ACC_VOUCHER GROUP BY LEDGER_NAME ";
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
        private static string CreateAccCompanyVoucherDetails()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COMPANY_VOUCHER_DETAILS]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_COMPANY_VOUCHER_DETAILS]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_COMPANY_VOUCHER_DETAILS AS ";
                    strSQL = strSQL + "SELECT ACC_COMPANY_VOUCHER.COMP_VOUCHER_SERIAL, ACC_COMPANY_VOUCHER.COMP_REF_NO,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.LEDGER_NAME AS LEDGER_NAME, ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ACC_COMPANY_VOUCHER.COMP_VOUCHER_MONTH_ID,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_AMOUNT, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_PROCESS_AMOUNT, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_DESPATCH_TO, ACC_COMPANY_VOUCHER.COMP_VOUCHER_ADDRESS1,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_ADDRESS2, ACC_COMPANY_VOUCHER.COMP_VOUCHER_TERM_OF_PAYMENTS,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_DESPATCH_THRU, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DESTINATION,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_STATUS, ACC_COMPANY_VOUCHER.BRANCH_ID,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_IS_AUTO , ACC_VOUCHER_TYPE.VOUCHER_TYPE_NAME ";
                    strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_VOUCHER_TYPE ON ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = ACC_VOUCHER_TYPE.VOUCHER_TYPE_VALUE ";
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
        private static string CreateLedgerOpeningAsOnQry()
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
                    string dteFromDate;
                    string dteTodate;
                    dteFromDate = "01-01-1900";
                    dteTodate = "01-01-1900";
                    //'ACC_LEDGER_OPENING_ASON_QRY
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_OPENING_ASON_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_OPENING_ASON_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGER_OPENING_ASON_QRY AS ";
                    strSQL = strSQL + "SELECT LEDGER_NAME,ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT), 0) AS OPENING, BRANCH_ID ";
                    strSQL = strSQL + "FROM ACC_VOUCHER ";
                    strSQL = strSQL + "WHERE COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(dteFromDate) + " ";
                    strSQL = strSQL + "GROUP BY LEDGER_NAME, BRANCH_ID ";
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

        private static string CreateAccVchMultiLedger()
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
                    string dteFromDate;
                    string dteTodate;
                    dteFromDate = "01-01-1900";
                    dteTodate = "01-01-1900";

                    // 'ACC_VCH_MULTI_LEDGER
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_VCH_MULTI_LEDGER]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_VCH_MULTI_LEDGER]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_VCH_MULTI_LEDGER AS ";
                    strSQL = strSQL + "SELECT COMP_REF_NO,BRANCH_ID,COMP_VOUCHER_TYPE,COMP_VOUCHER_POSITION,COMP_VOUCHER_DATE,LEDGER_NAME,";
                    strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER,VOUCHER_CHEQUE_DATE, VOUCHER_CHEQUE_DRAWN_ON, VOUCHER_DEBIT_AMOUNT,";
                    strSQL = strSQL + "VOUCHER_CREDIT_AMOUNT,VOUCHER_BANK_DATE, VOUCHER_REVERSE_LEDGER, VOUCHER_TOBY ";
                    strSQL = strSQL + "FROM ACC_VOUCHER ";
                    strSQL = strSQL + "WHERE (COMP_VOUCHER_DATE ";
                    strSQL = strSQL + "BETWEEN " + Utility.cvtSQLDateString(dteFromDate) + " AND " + Utility.cvtSQLDateString(dteTodate) + ")";
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
        private static string CreateAccBillWiseQry()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SALES_BILLWISE_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[SALES_BILLWISE_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW SALES_BILLWISE_QRY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT dbo.ACC_BILL_WISE.VOUCHER_REF_KEY, SUBSTRING(dbo.ACC_BILL_WISE.AGAINST_VOUCHER_NO, 5, 23) AS AGAINST_REF,";
                    strSQL = strSQL + "SUBSTRING(dbo.ACC_BILL_WISE.COMP_REF_NO, 7, 23) AS REF_NO, dbo.ACC_BILL_WISE.COMP_VOUCHER_TYPE,";
                    strSQL = strSQL + "dbo.ACC_BILL_WISE.COMP_VOUCHER_DATE, dbo.ACC_BILL_WISE.BILL_WISE_POSITION, dbo.ACC_BILL_WISE.BILL_WISE_PREV_NEW,";
                    strSQL = strSQL + "dbo.ACC_BILL_WISE.LEDGER_NAME, dbo.ACC_BILL_WISE.BILL_WISE_AMOUNT, dbo.ACC_BILL_WISE.BILL_WISE_TOBY,";
                    strSQL = strSQL + "dbo.ACC_LEDGER.LEDGER_GROUP , dbo.ACC_LEDGER.LEDGER_PARENT_GROUP, dbo.ACC_BILL_WISE.AGAINST_VOUCHER_NO, dbo.ACC_BILL_WISE.BILL_WISE_DUE_DATE,ACC_BILL_WISE.BRANCH_ID ";
                    strSQL = strSQL + "FROM dbo.ACC_BILL_WISE INNER JOIN ";
                    strSQL = strSQL + "dbo.ACC_LEDGER ON dbo.ACC_BILL_WISE.LEDGER_NAME = dbo.ACC_LEDGER.LEDGER_NAME";
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
        private static string CreateAccBranchGroupOpening()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_BRANCH_GROUP_OPENING]') and OBJECTPROPERTY(id, N'IsView') = 1)";
                    strSQL = strSQL + "drop view [dbo].[ACC_BRANCH_GROUP_OPENING]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_BRANCH_GROUP_OPENING ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT ACC_BRANCH_LEDGER_OPENING.LEDGER_NAME AS LEDGER_NAME,";
                    strSQL = strSQL + "ACC_LEDGER_TO_GROUP.GR_NAME AS GR_NAME, ACC_LEDGERGROUP.GR_PARENT ";
                    strSQL = strSQL + "AS GR_PARENT,ACC_BRANCH_LEDGER_OPENING.BRANCH_LEDGER_OPENING_BALANCE,ACC_LEDGERGROUP.GR_PRIMARY_TYPE, ";
                    strSQL = strSQL + "ACC_LEDGERGROUP.GR_LEVEL,ACC_LEDGERGROUP.GR_GROUP,ACC_BRANCH_LEDGER_OPENING.BRANCH_ID ";
                    strSQL = strSQL + "FROM ACC_BRANCH_LEDGER_OPENING INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_TO_GROUP ON ";
                    strSQL = strSQL + "ACC_BRANCH_LEDGER_OPENING.LEDGER_NAME = ACC_LEDGER_TO_GROUP.LEDGER_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGERGROUP ON ACC_LEDGER_TO_GROUP.GR_NAME = ACC_LEDGERGROUP.GR_NAME ";
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
        private static string CreateBalQry()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_BAL_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_BAL_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_BAL_QRY AS ";
                    strSQL = strSQL + "SELECT ACC_BALANCE_SHEET_TEMP.GR_PARENT, ";
                    strSQL = strSQL + "ACC_BALANCE_SHEET_TEMP.GR_PRIMARY_TYPE, ";
                    strSQL = strSQL + "SUM(ACC_BALANCE_SHEET_TEMP.GR_AMOUNT) AS SumOfGR_AMOUNT ";
                    strSQL = strSQL + "FROM ACC_BALANCE_SHEET_TEMP ";
                    strSQL = strSQL + "GROUP BY ACC_BALANCE_SHEET_TEMP.GR_PARENT, ACC_BALANCE_SHEET_TEMP.GR_PRIMARY_TYPE ";
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

        private static string CreateBillTranPendingView()
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
                    strSQL = "if exists (select * from sysobjects where id = object_id(N'[dbo].[ACC_BILL_TRAN_PENDING_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ACC_BILL_TRAN_PENDING_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_BILL_TRAN_PENDING_QRY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT ACC_BILL_TRAN.BILL_TRAN_KEY, ACC_BILL_TRAN.COMP_REF_NO,";
                    strSQL = strSQL + "ACC_BILL_TRAN.COMP_VOUCHER_TYPE, ACC_BILL_TRAN.COMP_VOUCHER_DATE, ";
                    strSQL = strSQL + "ACC_BILL_TRAN.BILL_TRAN_POSITION,ACC_BILL_TRAN.STOCKGROUP_NAME,ACC_BILL_TRAN.STOCKITEM_NAME, ";
                    strSQL = strSQL + "ACC_BILL_TRAN.GODOWNS_NAME, ACC_BILL_TRAN_PROCESS_QRY.BILL_BALANCE_QTY, ";
                    strSQL = strSQL + "ACC_BILL_TRAN.BILL_UOM,ACC_BILL_TRAN.BILL_RATE, ";
                    strSQL = strSQL + "ACC_BILL_TRAN.BILL_NET_AMOUNT,ACC_BILL_TRAN.BILL_AMOUNT, ACC_BILL_TRAN.BILL_QUANTITY,ACC_BILL_TRAN.INV_LOG_NO, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_DUE_DATE , ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.LEDGER_NAME,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.BRANCH_ID,ACC_BILL_TRAN.BILL_PER,ACC_BILL_TRAN.BILL_QUANTITY_BONUS ";
                    strSQL = strSQL + ",ACC_COMPANY_VOUCHER.APP_STATUS, ACC_COMPANY_VOUCHER.APPROVED_BY, ACC_COMPANY_VOUCHER.ONLINE,ACC_BILL_TRAN.BILL_ADD_LESS_AMOUNT ";
                    strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER INNER JOIN ACC_BILL_TRAN INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN_PROCESS_QRY ON ";
                    strSQL = strSQL + "ACC_BILL_TRAN.BILL_TRAN_KEY = ACC_BILL_TRAN_PROCESS_QRY.AGST_REF_NO_KEY ON ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO ";
                    strSQL = strSQL + "WHERE (ACC_BILL_TRAN.COMP_VOUCHER_TYPE > 0) ";
                    strSQL = strSQL + "AND (ACC_BILL_TRAN_PROCESS_QRY.BILL_BALANCE_QTY > 0)";
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

        private static string CreateBillTranProcessView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_BILL_TRAN_PROCESS_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ACC_BILL_TRAN_PROCESS_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_BILL_TRAN_PROCESS_QRY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT AGST_REF_NO_KEY, SUM(BILL_QUANTITY) AS BILL_BALANCE_QTY ";
                    strSQL = strSQL + "From ACC_BILL_TRAN_PROCESS ";
                    strSQL = strSQL + "GROUP BY AGST_REF_NO_KEY  HAVING (SUM(BILL_QUANTITY) > 0)";
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

        private static string CreateCompanyVoucherView()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COMPANY_VOUCHER_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_COMPANY_VOUCHER_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_COMPANY_VOUCHER_VIEW AS ";
                    strSQL = strSQL + "SELECT COMP_VOUCHER_SERIAL,COMP_REF_NO,";
                    strSQL = strSQL + "LEDGER_NAME, COMP_VOUCHER_TYPE, ";
                    strSQL = strSQL + "COMP_VOUCHER_DATE, COMP_VOUCHER_MONTH_ID,COMP_VOUCHER_AMOUNT,";
                    strSQL = strSQL + "COMP_VOUCHER_NET_AMOUNT, COMP_VOUCHER_PROCESS_AMOUNT, ";
                    strSQL = strSQL + "COMP_VOUCHER_NARRATION, COMP_VOUCHER_DESPATCH_TO, COMP_VOUCHER_ADDRESS1, COMP_VOUCHER_ADDRESS2,";
                    strSQL = strSQL + "COMP_VOUCHER_TERM_OF_PAYMENTS, COMP_VOUCHER_DESPATCH_THRU, COMP_VOUCHER_DESTINATION, COMP_VOUCHER_STATUS,BRANCH_ID,COMP_VOUCHER_IS_AUTO,SP_JOURNAL ";
                    strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER ";
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

        private static string CreateInvStockItemTranQry()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCKITEM_TRAN_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1)";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCKITEM_TRAN_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_STOCKITEM_TRAN_QRY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT INV_STOCKGROUP.STOCKGROUP_NAME, INV_TRAN.INV_TRAN_AMOUNT, INV_TRAN.INV_DATE,INV_TRAN.INV_TRAN_QUANTITY,";
                    strSQL = strSQL + "INV_TRAN.STOCKITEM_NAME ,INV_TRAN.BRANCH_ID,INV_TRAN.INV_INOUT_FLAG,INV_TRAN.INV_VOUCHER_TYPE ";
                    strSQL = strSQL + ",INV_TRAN.OUTWARD_SALES_AMOUNT,INV_TRAN.OUTWARD_COST_AMOUNT,INV_TRAN.GODOWNS_NAME ";
                    //strSQL=strSQL +"(case when dbo.INV_TRAN.OUTWARD_SALES_AMOUNT=0 and INV_INOUT_FLAG ='O' then INV_TRAN.INV_TRAN_AMOUNT else ";
                    //strSQL=strSQL +" INV_TRAN.OUTWARD_SALES_AMOUNT end) OUTWARD_AMOUNT 
                    strSQL=strSQL +"FROM INV_STOCKGROUP INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME INNER JOIN ";
                    strSQL = strSQL + "INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME";
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

        private static string CreateInvStockQty()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCK_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCK_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_STOCK_QRY AS ";
                    strSQL = strSQL + "SELECT INV_TRAN.*,";
                    strSQL = strSQL + "INV_STOCKITEM.STOCKITEM_PRIMARY_GROUP AS STOCKITEM_PRIMARY_GROUP,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE AS STOCKGROUP_PRIMARY_TYPE,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_SECONDARY_TYPE AS STOCKGROUP_SECONDARY_TYPE ";
                    strSQL = strSQL + "FROM INV_STOCKITEM INNER JOIN ";
                    strSQL = strSQL + "INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKGROUP ON INV_STOCKITEM.STOCKGROUP_NAME = INV_STOCKGROUP.STOCKGROUP_NAME ";
                    //'strSQL = "CREATE VIEW INV_STOCK_QRY AS "
                    //'strSQL = strSQL + "SELECT INV_TRAN.*, SUBSTRING(INV_STOCKITEM.STOCKITEM_PRIMARY_GROUP,5,50) AS STOCKITEM_PRIMARY_GROUP "
                    //'strSQL = strSQL + "FROM INV_STOCKITEM INNER JOIN "
                    //'strSQL = strSQL + "INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME "
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

        private static string CreateLedgerGroupQry()
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
                    strSQL = strSQL + "ACC_LEDGERGROUP.GR_CASH_FLOW_TYPE,ACC_LEDGERGROUP.GR_PRIMARY ";
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

        //private static string CreateLedgerGroupView()

        //     {
        //            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
        //            {
        //            if (gcnmain.State == System.Data.ConnectionState.Open)
        //            {
        //                gcnmain.Close();
        //            }
        //            try
        //            {
        //                gcnmain.Open();
        //                string strSQL;
        //                SqlCommand cmd = new SqlCommand();
        //                cmd.Connection = gcnmain;

        //                strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGERGROUP_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
        //                strSQL = strSQL + "drop view [dbo].[ACC_LEDGERGROUP_VIEW]";
        //                cmd.CommandText = strSQL;
        //                cmd.ExecuteNonQuery();
        //                strSQL = "CREATE VIEW ACC_LEDGERGROUP_VIEW AS ";
        //                strSQL = strSQL + "SELECT GR_SERIAL,GR_NAME,";
        //                strSQL = strSQL + "GR_PARENT, ";
        //                strSQL = strSQL + "GR_PRIMARY, ";
        //                strSQL = strSQL + "GR_ONE_DOWN, ";
        //                strSQL = strSQL + "GR_DEFAULT_GROUP, ";
        //                strSQL = strSQL + "GR_OPENING_DEBIT, GR_OPENING_CREDIT, ";
        //                strSQL = strSQL + "GR_DEBIT_TOTAL,GR_CREDIT_TOTAL,GR_CLOSING_DEBIT,GR_CLOSING_CREDIT,GR_DEFAULT_NAME, ";
        //                strSQL = strSQL + "GR_PRIMARY_TYPE, GR_LEVEL, GR_SEQUENCES, GR_GROUP,GR_CASH_FLOW_TYPE ";
        //                strSQL = strSQL + "FROM ACC_LEDGERGROUP ";
        //                cmd.CommandText = strSQL;
        //                cmd.ExecuteNonQuery();
        //                return strSQL;
        //            }

        //            finally
        //            {
        //                gcnmain.Close();
        //            }
        //        }
        //  }

        private static string CreateLedgerView()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_LEDGER_VIEW AS ";
                    strSQL = strSQL + "SELECT LEDGER_SERIAL,LEDGER_NAME,LEDGER_PARTY_TYPE, ";
                    strSQL = strSQL + "LEDGER_PARENT_GROUP, LEDGER_PARTY_UNDER, LEDGER_OPENING_BALANCE, ";
                    strSQL = strSQL + "LEDGER_CLOSING_BALANCE, LEDGER_CREDIT_LIMIT, LEDGER_CURRENCY_NAME, LEDGER_ADDRESS1, LEDGER_ADDRESS2, LEDGER_CITY, ";
                    strSQL = strSQL + "LEDGER_POSTAL, LEDGER_PHONE, LEDGER_FAX,LEDGER_EMAIL,LEDGER_COMMENTS, LEDGER_BENEFIT, LEDGER_NATURE,LEDGER_GROUP,";
                    strSQL = strSQL + "LEDGER_PRIMARY_TYPE,LEDGER_VECTOR,LEDGER_BILL_WISE, LEDGER_INVENTORY_AFFECT, LEDGER_DEFAULT,";
                    strSQL = strSQL + "LEDGER_LEVEL,LEDGER_CASH_FLOW_TYPE, LEDGER_CURRENCY_SYMBOL,LEDGER_PAYROLL, LEDGER_STATUS ";
                    strSQL = strSQL + "FROM ACC_LEDGER ";
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

        private static string CreateLedgerViewBranch()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_VIEW_BRANCH]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_VIEW_BRANCH]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_LEDGER_VIEW_BRANCH AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER.LEDGER_NAME AS LEDGER_NAME, ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_PARENT_GROUP AS LEDGER_PARENT_GROUP,";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_PRIMARY_GROUP AS LEDGER_PRIMARY_GROUP,";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_PRIMARY_TYPE,";
                    strSQL = strSQL + "ACC_BRANCH_LEDGER_OPENING.BRANCH_LEDGER_OPENING_BALANCE,ACC_BRANCH_LEDGER_OPENING.BRANCH_ID,";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_LEVEL, ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_GROUP ";
                    strSQL = strSQL + "FROM ACC_LEDGER INNER JOIN ";
                    strSQL = strSQL + "ACC_BRANCH_LEDGER_OPENING ON ACC_LEDGER.LEDGER_NAME = ACC_BRANCH_LEDGER_OPENING.LEDGER_NAME ";
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

        private static string CreateLedgerVoucher()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_VOUCHER]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_VOUCHER]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_LEDGER_VOUCHER AS ";
                    strSQL = strSQL + "SELECT ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_NAME, ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_PARENT_GROUP,";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_PRIMARY_GROUP,";
                    strSQL = strSQL + "ACC_VOUCHER.COMP_REF_NO, ";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_REF_KEY, ";
                    strSQL = strSQL + "ACC_VOUCHER.COMP_VOUCHER_TYPE, ";
                    strSQL = strSQL + "ACC_VOUCHER.COMP_VOUCHER_DATE, ";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT,";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT,";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_PRIMARY_TYPE, ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_GROUP, ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_MANUFAC_GROUP,";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_TOBY, ";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_CASHFLOW, ";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_NARRATION, ";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_CHEQUE_NUMBER, ";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_CHEQUE_DATE, ";
                    strSQL = strSQL + "ACC_VOUCHER.BRANCH_ID,";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_REVERSE_LEDGER,";
                    strSQL = strSQL + "ACC_VOUCHER.INV_LOG_NO,ACC_VOUCHER.VOUCHER_BANK_DATE, ACC_VOUCHER.BANK_CHARGE_PER, ACC_VOUCHER.BANK_CHARGE_AMOUNT, ACC_VOUCHER.BANK_RECON_STATUS ";
                    strSQL = strSQL + "FROM ACC_LEDGER INNER JOIN ACC_VOUCHER ON ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_NAME = ACC_VOUCHER.LEDGER_NAME ";
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

        private static string CreateMainLedger()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_MAIN_LEDGER]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ACC_MAIN_LEDGER] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_MAIN_LEDGER AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER.LEDGER_NAME AS LEDGER_NAME,ACC_LEDGER.LEDGER_PRIMARY_TYPE,ACC_LEDGER.LEDGER_DEFAULT,";
                    strSQL = strSQL + "ACC_VOUCHER.COMP_VOUCHER_TYPE,ACC_VOUCHER.COMP_VOUCHER_DATE,ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT,";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT,ACC_VOUCHER.VOUCHER_TOBY,ACC_VOUCHER.VOUCHER_CASHFLOW, ACC_LEDGER.LEDGER_PARENT_GROUP AS LEDGER_PARENT_GROUP, ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_LEVEL, ACC_LEDGER.LEDGER_GROUP,ACC_LEDGER.LEDGER_CASH_FLOW_TYPE,ACC_VOUCHER.BRANCH_ID ";
                    strSQL = strSQL + "FROM ACC_LEDGER INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGERGROUP ON ACC_LEDGER.LEDGER_PARENT_GROUP = ACC_LEDGERGROUP.GR_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_VOUCHER ON ACC_LEDGER.LEDGER_NAME = ACC_VOUCHER.LEDGER_NAME ";
                    strSQL = strSQL + "WHERE ACC_LEDGERGROUP.GR_LEVEL = 1 ";
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


        private static string CreatePriceLevelView()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_PRICE_LEVEL_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_PRICE_LEVEL_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_PRICE_LEVEL_VIEW AS ";
                    strSQL = strSQL + "SELECT PRICE_LEVEL_NAME FROM ACC_PRICE_LEVEL ";
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
        private static string CreateStockItemClosingQry()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCK_CLOSING_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1)";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCK_CLOSING_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_STOCK_CLOSING_QRY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT INV_STOCKITEM_CLOSING.GODOWNS_NAME,INV_STOCKITEM_CLOSING.STOCKITEM_NAME, ";
                    strSQL = strSQL + "INV_STOCKITEM.STOCKITEM_BASEUNITS,INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE, ";
                    strSQL = strSQL + "INV_STOCKITEM.STOCKITEM_ALIAS,INV_STOCKITEM.STOCKITEM_MANUFACTURER ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKITEM_CLOSING.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME ";
                    strSQL = strSQL + "WHERE STOCKITEM_STATUS = 0 ";
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
        private static string CreateViewCompBillTran()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COMP_BILL_TRAN_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_COMP_BILL_TRAN_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_COMP_BILL_TRAN_QRY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ";
                    //strSQL = strSQL + "SUBSTRING(ACC_COMPANY_VOUCHER.COMP_REF_NO, 7, 30) AS COMP_REF_NO, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_REF_NO COMP_REF_NO,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.LEDGER_NAME,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_DUE_DATE, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION, ";
                    strSQL = strSQL + "ACC_BILL_TRAN.STOCKITEM_NAME AS STOCKITEM_NAME, ";
                    strSQL = strSQL + "ACC_BILL_TRAN.BILL_UOM, ACC_BILL_TRAN.BILL_QUANTITY,";
                    strSQL = strSQL + "ACC_BILL_TRAN.BILL_RATE,ACC_BILL_TRAN.BILL_NET_AMOUNT,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE, ";
                    strSQL = strSQL + "ACC_BILL_TRAN.GODOWNS_NAME AS GODOWNS_NAME, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_STATUS, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.SAMPLE_STATUS, ";
                    strSQL = strSQL + "ACC_BILL_TRAN.VOUCHER_CURRENCY_SYMBOL,";
                    strSQL = strSQL + "ACC_BILL_TRAN.VOUCHER_FC_AMOUNT,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.BRANCH_ID,ACC_BILL_TRAN.FC_CONVERSION_RATE, ACC_BILL_TRAN.BILL_PER ";
                    strSQL = strSQL + "FROM  dbo.ACC_COMPANY_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN ON ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_REF_NO =ACC_BILL_TRAN.COMP_REF_NO ";
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

        private static string CreateVoucherView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_VOUCHER_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_VOUCHER_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_VOUCHER_VIEW AS ";
                    strSQL = strSQL + "SELECT VOUCHER_SERIAL,COMP_VOUCHER_TYPE,COMP_REF_NO,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE,LEDGER_NAME, ";
                    strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER,VOUCHER_CHEQUE_DATE,VOUCHER_CHEQUE_DRAWN_ON,VOUCHER_BANK_DATE,";
                    strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,VOUCHER_TOBY,COMP_VOUCHER_POSITION,ACC_VOUCHER.BRANCH_ID,VOUCHER_CASHFLOW  ";
                    strSQL = strSQL + "FROM ACC_VOUCHER ";
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

                    strSQL = "if exists (select * from sysobjects where id = object_id(N'[dbo].[ACC_COMPANY_VOUCHER_BRANCH_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_COMPANY_VOUCHER_BRANCH_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_COMPANY_VOUCHER_BRANCH_VIEW AS ";
                    strSQL = strSQL + "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO, SUBSTRING(ACC_COMPANY_VOUCHER.COMP_REF_NO, 7, 23) AS REF_NO, ACC_COMPANY_VOUCHER.LEDGER_NAME, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ACC_COMPANY_VOUCHER.COMP_VOUCHER_AMOUNT, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT, ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION, ACC_BRANCH.BRANCH_NAME, ACC_COMPANY_VOUCHER.SP_JOURNAL, ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_CODE,  ACC_LEDGER.TERITORRY_CODE, ACC_LEDGER.TERRITORRY_NAME, ACC_LEDGER.HOMOEO_HALL,ACC_COMPANY_VOUCHER.SAMPLE_STATUS,ACC_COMPANY_VOUCHER.APP_STATUS ";
                    strSQL = strSQL + ",ACC_COMPANY_VOUCHER.APPROVED_BY,ACC_LEDGER.LEDGER_NAME_MERZE,ACC_BRANCH.BRANCH_ID FROM ACC_COMPANY_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME ";
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
        private static string CreateLedgerBudgetDetailView()
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
                    strSQL = "if exists (select * from sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_BUDGET_DETAIL_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_BUDGET_DETAIL_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGER_BUDGET_DETAIL_VIEW AS ";
                    strSQL = strSQL + " SELECT ACC_LEDGER.LEDGER_PRIMARY_TYPE, ACC_BUDGET_DETAIL.LEDGER_NAME,ACC_BUDGET_DETAIL.BRANCH_ID,ACC_BUDGET_DETAIL.BRANCH_NAME, ";
                    strSQL = strSQL + " ACC_BUDGET_DETAIL.BUDGET_FROM_DATE, ACC_BUDGET_DETAIL.BUDGET_TO_DATE, ";
                    strSQL = strSQL + " ACC_BUDGET_DETAIL.BUDGET_AMOUNT, ";
                    strSQL = strSQL + " ACC_BUDGET_DETAIL.BUDGET_KEY_REF ";
                    strSQL = strSQL + " FROM ACC_LEDGER INNER JOIN ";
                    strSQL = strSQL + " ACC_BUDGET_DETAIL ON ACC_LEDGER.LEDGER_NAME = ACC_BUDGET_DETAIL.LEDGER_NAME ";
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

        private static string CreateVoucherBudgetView()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_VOUCHER_BUDGET_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_VOUCHER_BUDGET_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_VOUCHER_BUDGET_VIEW AS ";
                    strSQL = strSQL + "SELECT (BRANCH_ID + CONVERT(char(6), COMP_VOUCHER_DATE, 112) + LEDGER_NAME) AS BUDGET_KEY, ";
                    strSQL = strSQL + "SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT) As AMOUNT ";
                    strSQL = strSQL + "FROM ACC_VOUCHER ";
                    strSQL = strSQL + "GROUP BY BRANCH_ID + CONVERT(char(6), COMP_VOUCHER_DATE, 112) + LEDGER_NAME ";
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
        private static string CreateVoucherLedgerBudgetDetailView()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_VOUCHER_LEDGER_BUDGET_DETAILS_VIEW ]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_VOUCHER_LEDGER_BUDGET_DETAILS_VIEW ]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_VOUCHER_LEDGER_BUDGET_DETAILS_VIEW AS ";
                    strSQL = strSQL + " SELECT ACC_LEDGER_BUDGET_DETAIL_VIEW.LEDGER_PRIMARY_TYPE,ACC_LEDGER_BUDGET_DETAIL_VIEW.LEDGER_NAME,ACC_LEDGER_BUDGET_DETAIL_VIEW.BRANCH_ID,ACC_LEDGER_BUDGET_DETAIL_VIEW.BRANCH_NAME, ";
                    strSQL = strSQL + " ACC_LEDGER_BUDGET_DETAIL_VIEW.BUDGET_FROM_DATE,ACC_LEDGER_BUDGET_DETAIL_VIEW.BUDGET_TO_DATE, ";
                    strSQL = strSQL + " ACC_LEDGER_BUDGET_DETAIL_VIEW.BUDGET_AMOUNT,ACC_LEDGER_BUDGET_DETAIL_VIEW.BUDGET_KEY_REF, ";
                    strSQL = strSQL + " ACC_VOUCHER_BUDGET_VIEW.AMOUNT ";
                    strSQL = strSQL + " FROM ACC_LEDGER_BUDGET_DETAIL_VIEW LEFT OUTER JOIN ACC_VOUCHER_BUDGET_VIEW ON ";
                    strSQL = strSQL + " ACC_LEDGER_BUDGET_DETAIL_VIEW.BUDGET_KEY_REF=ACC_VOUCHER_BUDGET_VIEW.BUDGET_KEY";
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

        private static string CreateSalesBillWiseQry()
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

                    strSQL = "if exists (select * from sysobjects where id = object_id(N'[dbo].[ACC_BILLWISE_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_BILLWISE_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_BILLWISE_QRY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT ACC_BILL_WISE.VOUCHER_REF_KEY,SUBSTRING(ACC_BILL_WISE.AGAINST_VOUCHER_NO, 7, 30) AS AGAINST_REF,";
                    strSQL = strSQL + "SUBSTRING(ACC_BILL_WISE.COMP_REF_NO, 7, 30) AS REF_NO, ACC_BILL_WISE.COMP_VOUCHER_TYPE,";
                    strSQL = strSQL + "ACC_BILL_WISE.COMP_VOUCHER_DATE, ACC_BILL_WISE.BILL_WISE_POSITION, ACC_BILL_WISE.BILL_WISE_PREV_NEW,";
                    strSQL = strSQL + "ACC_BILL_WISE.LEDGER_NAME, ACC_BILL_WISE.BILL_WISE_AMOUNT, ACC_BILL_WISE.BILL_WISE_TOBY,";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_GROUP , ACC_LEDGER.LEDGER_PARENT_GROUP, ACC_BILL_WISE.AGAINST_VOUCHER_NO ";
                    strSQL = strSQL + "FROM ACC_BILL_WISE INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER ON ACC_BILL_WISE.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME ";
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
        private static string CreateManufactureStockQry()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_MANUFACTURE_STOCK_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[INV_MANUFACTURE_STOCK_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_MANUFACTURE_STOCK_QRY AS ";
                    strSQL = strSQL + "SELECT INV_STOCKGROUP.STOCKGROUP_PRIMARY AS STOCKITEM_PRIMARY_GROUP,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE,INV_STOCKGROUP.STOCKGROUP_SECONDARY_TYPE,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_LEVEL, ";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_NAME AS STOCKGROUP_NAME,";
                    strSQL = strSQL + "INV_TRAN.BRANCH_ID,INV_TRAN.INV_REF_NO,INV_TRAN.INV_LOG_NO,INV_TRAN.INV_OPENING_FLAG,";
                    strSQL = strSQL + "INV_TRAN.STOCKITEM_NAME AS STOCKITEM_NAME,";
                    strSQL = strSQL + "INV_TRAN.GODOWNS_NAME,INV_TRAN.INV_DATE,INV_TRAN.INV_VOUCHER_TYPE,";
                    strSQL = strSQL + "INV_TRAN.INV_TRAN_QUANTITY,INV_TRAN.INV_TRAN_RATE,INV_TRAN.INV_TRAN_AMOUNT ";
                    strSQL = strSQL + "FROM INV_STOCKITEM INNER JOIN ";
                    strSQL = strSQL + "INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKGROUP ON INV_STOCKITEM.STOCKGROUP_NAME = INV_STOCKGROUP.STOCKGROUP_NAME ";
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
        private static string CreateFixedAssetView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_FIXED_ASSET_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ACC_FIXED_ASSET_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_FIXED_ASSET_VIEW AS ";
                    strSQL = strSQL + "SELECT ACC_FIXED_ASSETS.LEDGER_NAME, ACC_FIXED_ASSETS.ASSET_DEP_EFF_DATE, ";
                    strSQL = strSQL + "ACC_FIXED_ASSETS.ASSET_DEP_METHOD, ACC_FIXED_ASSETS.ASSET_LIFE, ACC_FIXED_ASSETS.ASSET_DEP_RATE,";
                    strSQL = strSQL + "ACC_FIXED_ASSETS.ASSET_ACCU_DEP, ACC_FIXED_ASSETS.ASSET_WRITTEN_VALUE, ACC_VOUCHER.BRANCH_ID, ";
                    strSQL = strSQL + "ACC_VOUCHER.COMP_VOUCHER_DATE , ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT, ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT ";
                    strSQL = strSQL + "FROM ACC_FIXED_ASSETS INNER JOIN ";
                    strSQL = strSQL + "ACC_VOUCHER ON ACC_FIXED_ASSETS.LEDGER_NAME = ACC_VOUCHER.LEDGER_NAME ";
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

        private static string CreateComBillLedgerGodownView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COMP_BILL_GODOWN_LEDGER_CONFIG_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ACC_COMP_BILL_GODOWN_LEDGER_CONFIG_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_COMP_BILL_GODOWN_LEDGER_CONFIG_VIEW AS ";
                    strSQL = strSQL + "SELECT ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, SUBSTRING(ACC_COMPANY_VOUCHER.COMP_REF_NO, 7, 30) AS COMP_REF_NO, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.LEDGER_NAME,ACC_BILL_TRAN.STOCKITEM_NAME, ACC_BILL_TRAN.BILL_UOM, ";
                    strSQL = strSQL + "ACC_BILL_TRAN.BILL_QUANTITY, ACC_BILL_TRAN.BILL_NET_AMOUNT,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE, ACC_BILL_TRAN.GODOWNS_NAME, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_STATUS,ACC_BILL_TRAN.VOUCHER_CURRENCY_SYMBOL, ";
                    strSQL = strSQL + "ACC_BILL_TRAN.VOUCHER_FC_AMOUNT, ACC_COMPANY_VOUCHER.BRANCH_ID,";
                    strSQL = strSQL + "ACC_BRANCH.BRANCH_NAME, INV_GODOWNS.GODOWNS_ADDRESS1, INV_GODOWNS.GODOWNS_ADDRESS2,";
                    strSQL = strSQL + "ACC_INVOICE_CONFIG.SALES_ORDER_HEADER, ACC_INVOICE_CONFIG.SALES_ORDER_FOOTER,";
                    strSQL = strSQL + "ACC_INVOICE_CONFIG.PURCHASE_ORDER_HEADER, ACC_INVOICE_CONFIG.PURCHASE_ORDER_FOOTER, ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_ADDRESS1,ACC_LEDGER.LEDGER_CITY, ACC_LEDGER.LEDGER_POSTAL, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_DELIVERY,ACC_COMPANY_VOUCHER.COMP_TERM_OF_PAYMENTS, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_SUPPORT,ACC_COMPANY_VOUCHER.COMP_VALIDITY_DATE, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_OTHERS, ACC_BILL_TRAN.FC_CONVERSION_RATE,";
                    strSQL = strSQL + "ACC_BILL_TRAN.BILL_PER,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_DUE_DATE,ACC_BILL_TRAN.BILL_RATE,ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION ";
                    strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO INNER JOIN ";
                    strSQL = strSQL + "ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID INNER JOIN ";
                    strSQL = strSQL + "INV_GODOWNS ON ACC_BILL_TRAN.GODOWNS_NAME = INV_GODOWNS.GODOWNS_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME CROSS JOIN ";
                    strSQL = strSQL + "ACC_INVOICE_CONFIG ";
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
        private static string CreateMainLedgerGrSummary()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_MAIN_LEDGER_GR_SUMMARY]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ACC_MAIN_LEDGER_GR_SUMMARY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_MAIN_LEDGER_GR_SUMMARY AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER.LEDGER_NAME, ACC_LEDGER.LEDGER_PRIMARY_TYPE,";
                    strSQL = strSQL + "ACC_VOUCHER.COMP_VOUCHER_TYPE, ACC_VOUCHER.COMP_VOUCHER_DATE, ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT, ";
                    strSQL = strSQL + "ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT, ACC_VOUCHER.VOUCHER_TOBY, ACC_VOUCHER.VOUCHER_CASHFLOW,";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_PARENT_GROUP, ACC_LEDGER.LEDGER_LEVEL,";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_GROUP , ACC_LEDGER.LEDGER_CASH_FLOW_TYPE, ACC_VOUCHER.BRANCH_ID,ACC_LEDGERGROUP.GR_PRIMARY_TYPE, ACC_LEDGERGROUP.GR_LEVEL, ACC_LEDGERGROUP.GR_PRIMARY ";
                    strSQL = strSQL + "FROM ACC_LEDGER INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGERGROUP ON ACC_LEDGER.LEDGER_PARENT_GROUP = ACC_LEDGERGROUP.GR_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_VOUCHER ON ACC_LEDGER.LEDGER_NAME = ACC_VOUCHER.LEDGER_NAME ";
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
        private static string CreateViewBranchGroupSummary()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_BRANCH_GROUP_SUMMARY]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ACC_BRANCH_GROUP_SUMMARY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_BRANCH_GROUP_SUMMARY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT ACC_BRANCH_LEDGER_OPENING.LEDGER_NAME, ACC_LEDGER_TO_GROUP.GR_NAME, ACC_LEDGERGROUP.GR_PARENT,";
                    strSQL = strSQL + "ACC_BRANCH_LEDGER_OPENING.BRANCH_LEDGER_OPENING_BALANCE, ACC_LEDGERGROUP.GR_PRIMARY_TYPE,";
                    strSQL = strSQL + "ACC_LEDGERGROUP.GR_LEVEL , ACC_BRANCH_LEDGER_OPENING.BRANCH_ID ";
                    strSQL = strSQL + "FROM ACC_BRANCH_LEDGER_OPENING INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_TO_GROUP ON ACC_BRANCH_LEDGER_OPENING.LEDGER_NAME = ACC_LEDGER_TO_GROUP.LEDGER_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGERGROUP ON ACC_LEDGER_TO_GROUP.GR_NAME = ACC_LEDGERGROUP.GR_NAME ";
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
        private static string CreateViewBranchGrSummary()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_BRANCH_GR_SUMMARY]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ACC_LEDGER_BRANCH_GR_SUMMARY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_LEDGER_BRANCH_GR_SUMMARY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER.LEDGER_NAME, ACC_LEDGER.LEDGER_PARENT_GROUP, ACC_LEDGER.LEDGER_PRIMARY_TYPE,";
                    strSQL = strSQL + "ACC_BRANCH_LEDGER_OPENING.BRANCH_LEDGER_OPENING_BALANCE, ACC_BRANCH_LEDGER_OPENING.BRANCH_ID,";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_LEVEL ";
                    strSQL = strSQL + "FROM  ACC_LEDGER INNER JOIN ";
                    strSQL = strSQL + "ACC_BRANCH_LEDGER_OPENING ON ACC_LEDGER.LEDGER_NAME = ACC_BRANCH_LEDGER_OPENING.LEDGER_NAME ";
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
        private static string CreateViewVoucherBranchGrSummary()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_VOUCHER_BRANCH_GR_SUMMARY]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ACC_LEDGER_VOUCHER_BRANCH_GR_SUMMARY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGER_VOUCHER_BRANCH_GR_SUMMARY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER_VOUCHER.LEDGER_NAME, ACC_LEDGER_VOUCHER.COMP_VOUCHER_DATE, ACC_LEDGERGROUP.GR_NAME,";
                    strSQL = strSQL + "ACC_LEDGERGROUP.GR_PARENT, ACC_LEDGERGROUP.GR_LEVEL, ACC_LEDGER_VOUCHER.VOUCHER_DEBIT_AMOUNT,";
                    strSQL = strSQL + "ACC_LEDGER_VOUCHER.VOUCHER_CREDIT_AMOUNT , ACC_LEDGER_VOUCHER.BRANCH_ID ";
                    strSQL = strSQL + "FROM ACC_LEDGERGROUP INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_VOUCHER ON ACC_LEDGERGROUP.GR_NAME = ACC_LEDGER_VOUCHER.LEDGER_PARENT_GROUP ";
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

        private static string CreateViewMonthlyLedgerSummary()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_MONTHLY_SUMMARY_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ACC_MONTHLY_SUMMARY_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_MONTHLY_SUMMARY_VIEW ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT CAST(YEAR(COMP_VOUCHER_DATE) AS varchar(4)) + CAST(MONTH(COMP_VOUCHER_DATE) AS varchar(2)) AS MonthYear, COMP_VOUCHER_DATE, ";
                    strSQL = strSQL + "LEDGER_NAME , VOUCHER_DEBIT_AMOUNT, VOUCHER_CREDIT_AMOUNT,BRANCH_ID ";
                    strSQL = strSQL + "FROM ACC_VOUCHER ";
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
        private static string CreateViewCopyBranch()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COPY_BRANCH_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ACC_COPY_BRANCH_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_COPY_BRANCH_QRY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER.LEDGER_PRIMARY_GROUP, ACC_LEDGER.LEDGER_GROUP, ACC_LEDGER_TO_GROUP.LEDGER_NAME,";
                    strSQL = strSQL + "ACC_LEDGER_TO_GROUP.GR_NAME ";
                    strSQL = strSQL + "FROM ACC_LEDGER INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_TO_GROUP ON ACC_LEDGER.LEDGER_NAME = ACC_LEDGER_TO_GROUP.LEDGER_NAME ";
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
        private static string CreateViewCopyGroupBranch()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COPY_BRANCH_GROUP_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ACC_COPY_BRANCH_GROUP_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_COPY_BRANCH_GROUP_QRY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGERGROUP.GR_PRIMARY, ACC_LEDGERGROUP.GR_DEFAULT_NAME,";
                    strSQL = strSQL + "ACC_GROUP_TO_LEDGER.GR_NAME , ACC_GROUP_TO_LEDGER.GR_PARENT ";
                    strSQL = strSQL + "FROM ACC_LEDGERGROUP INNER JOIN ";
                    strSQL = strSQL + "ACC_GROUP_TO_LEDGER ON ACC_LEDGERGROUP.GR_NAME = ACC_GROUP_TO_LEDGER.GR_NAME ";
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

        private static string CreateTrialBalanceView()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_TRIAL_BALANCE_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_TRIAL_BALANCE_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_TRIAL_BALANCE_VIEW AS ";
                    strSQL = strSQL + "SELECT GR_NAME, SUM(GR_OPENING) AS GR_OPENING, ";
                    strSQL = strSQL + "SUM(GR_DEBIT) AS GR_DEBIT, SUM(GR_CREDIT) AS GR_CREDIT ";
                    strSQL = strSQL + "FROM ACC_TRIAL_BALANCE GROUP BY GR_NAME ";
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

        private static string CreateCostCentreOpeningView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COST_CENTRE_OPN_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_COST_CENTRE_OPN_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_COST_CENTRE_OPN_VIEW AS ";
                    strSQL = strSQL + "SELECT VMASTER_NAME, SUM(VCHILD_OPENING_BALANCE) AS OPENING ";
                    strSQL = strSQL + "FROM VECTOR_MASTER_CHILD GROUP BY VMASTER_NAME ";
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

        private static string CreateCostCentreAsOnOpeningView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COST_CENTRE_ASON_OPN_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_COST_CENTRE_ASON_OPN_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_COST_CENTRE_ASON_OPN_VIEW AS ";
                    strSQL = strSQL + "SELECT VMASTER_NAME, SUM(VT_TRAN_AMOUNT) AS ASON_OPEN ";
                    strSQL = strSQL + "From VECTOR_TRANSACTION ";
                    strSQL = strSQL + "WHERE VT_TRAN_DATE < CONVERT(datetime, '01-01-2006', 103) ";
                    strSQL = strSQL + "GROUP BY VMASTER_NAME ";
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
        private static string CreateCostCentreTranDrView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COST_CENTRE_TRAN_DR_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_COST_CENTRE_TRAN_DR_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_COST_CENTRE_TRAN_DR_VIEW AS ";
                    strSQL = strSQL + "SELECT VMASTER_NAME, SUM(VT_TRAN_AMOUNT) AS DEBIT ";
                    strSQL = strSQL + "FROM VECTOR_TRANSACTION ";
                    strSQL = strSQL + "WHERE (VT_TRAN_DATE ";
                    strSQL = strSQL + "BETWEEN CONVERT(datetime, '01-01-2006', 103) AND CONVERT(datetime, '31-12-2006', 103)) AND (VT_TRAN_AMOUNT < 0) ";
                    strSQL = strSQL + "GROUP BY VMASTER_NAME ";
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
        private static string CreateCostCentreTranCrView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COST_CENTRE_TRAN_CR_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_COST_CENTRE_TRAN_CR_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_COST_CENTRE_TRAN_CR_VIEW AS ";
                    strSQL = strSQL + "SELECT VMASTER_NAME, SUM(VT_TRAN_AMOUNT) AS CREDIT ";
                    strSQL = strSQL + "FROM VECTOR_TRANSACTION ";
                    strSQL = strSQL + "WHERE (VT_TRAN_DATE ";
                    strSQL = strSQL + "BETWEEN CONVERT(datetime, '01-01-2006', 103) AND CONVERT(datetime, '31-12-2006', 103)) AND (VT_TRAN_AMOUNT > 0) ";
                    strSQL = strSQL + "GROUP BY VMASTER_NAME ";
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
        private static string CreateCostCentreTrialBalanceView()
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COST_CENTRE_TRIAL_BALANCE]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_COST_CENTRE_TRIAL_BALANCE]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_COST_CENTRE_TRIAL_BALANCE AS ";
                    strSQL = strSQL + "SELECT VECTOR_MASTER.VECTOR_CATEGORY_NAME, VECTOR_MASTER.VMASTER_NAME,ISNULL(ACC_COST_CENTRE_OPN_VIEW.OPENING, 0) AS OPN,";
                    strSQL = strSQL + "ISNULL(ACC_COST_CENTRE_ASON_OPN_VIEW.ASON_OPEN, 0) AS AS_ON,ISNULL(ACC_COST_CENTRE_TRAN_DR_VIEW.DEBIT, 0) AS DEBIT,";
                    strSQL = strSQL + "ISNULL(ACC_COST_CENTRE_TRAN_CR_VIEW.CREDIT,0) AS CREDIT ";
                    strSQL = strSQL + "FROM VECTOR_MASTER LEFT OUTER JOIN ";
                    strSQL = strSQL + "ACC_COST_CENTRE_TRAN_CR_VIEW ON ";
                    strSQL = strSQL + "VECTOR_MASTER.VMASTER_NAME = ACC_COST_CENTRE_TRAN_CR_VIEW.VMASTER_NAME LEFT OUTER JOIN ";
                    strSQL = strSQL + "ACC_COST_CENTRE_TRAN_DR_VIEW ON ";
                    strSQL = strSQL + "VECTOR_MASTER.VMASTER_NAME = ACC_COST_CENTRE_TRAN_DR_VIEW.VMASTER_NAME LEFT OUTER JOIN ";
                    strSQL = strSQL + "ACC_COST_CENTRE_ASON_OPN_VIEW ON ";
                    strSQL = strSQL + "VECTOR_MASTER.VMASTER_NAME = ACC_COST_CENTRE_ASON_OPN_VIEW.VMASTER_NAME LEFT OUTER JOIN ";
                    strSQL = strSQL + "ACC_COST_CENTRE_OPN_VIEW ON VECTOR_MASTER.VMASTER_NAME = ACC_COST_CENTRE_OPN_VIEW.VMASTER_NAME ";
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
        private static string CreateSalesAndReceiptByMonth()
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

                    strSQL = "IF EXISTS (SELECT * From sysobjects WHERE id = object_id(N'[dbo].[SAL_SALES_AND_RECEIPT_BY_MONTH]') AND OBJECTPROPERTY(id, N'IsView') = 1) DROP VIEW [dbo].[SAL_SALES_AND_RECEIPT_BY_MONTH]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW SAL_SALES_AND_RECEIPT_BY_MONTH  AS ";
                    strSQL = strSQL + " SELECT LEDGER_PARENT_GROUP,LEDGER_NAME,";
                    strSQL = strSQL + " SUM(VOUCHER_DEBIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 1)))) AS JAN_S,";
                    strSQL = strSQL + " SUM(VOUCHER_CREDIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 1)))) AS JAN_P,";
                    strSQL = strSQL + " SUM(VOUCHER_DEBIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 2)))) AS FEB_S,";
                    strSQL = strSQL + " SUM(VOUCHER_CREDIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 2)))) AS FEB_P,";
                    strSQL = strSQL + " SUM(VOUCHER_DEBIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 3)))) AS MAR_S,";
                    strSQL = strSQL + " SUM(VOUCHER_CREDIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 3)))) AS MAR_P,";
                    strSQL = strSQL + " SUM(VOUCHER_DEBIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 4)))) AS APR_S,";
                    strSQL = strSQL + " SUM(VOUCHER_CREDIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 4)))) AS APR_P,";
                    strSQL = strSQL + " SUM(VOUCHER_DEBIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 5)))) AS MAY_S,";
                    strSQL = strSQL + " SUM(VOUCHER_CREDIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 5)))) AS MAY_P,";
                    strSQL = strSQL + " SUM(VOUCHER_DEBIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 6)))) AS JUN_S,";
                    strSQL = strSQL + " SUM(VOUCHER_CREDIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 6)))) AS JUN_P, ";
                    strSQL = strSQL + " SUM(VOUCHER_DEBIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 7)))) AS JUL_S,";
                    strSQL = strSQL + " SUM(VOUCHER_CREDIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 7)))) AS JUL_P,";
                    strSQL = strSQL + " SUM(VOUCHER_DEBIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 8)))) AS AUG_S,";
                    strSQL = strSQL + " SUM(VOUCHER_CREDIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) -8)))) AS AUG_P,";
                    strSQL = strSQL + " SUM(VOUCHER_DEBIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 9)))) AS SEP_S,";
                    strSQL = strSQL + " SUM(VOUCHER_CREDIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 9)))) AS SEP_P,";
                    strSQL = strSQL + " SUM(VOUCHER_DEBIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 10)))) AS OCT_S,";
                    strSQL = strSQL + " SUM(VOUCHER_CREDIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 10)))) AS OCT_P,";
                    strSQL = strSQL + " SUM(VOUCHER_DEBIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 11)))) AS NOV_S,";
                    strSQL = strSQL + " SUM(VOUCHER_CREDIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 11)))) AS NOV_P,";
                    strSQL = strSQL + " SUM(VOUCHER_DEBIT_AMOUNT * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 12)))) AS DEC_S,";
                    strSQL = strSQL + " SUM(VOUCHER_CREDIT_AMOUNT * (1 - Abs(SIGN(DatePart(mm, COMP_VOUCHER_DATE) - 12)))) As DEC_P";
                    strSQL = strSQL + " FROM ACC_LEDGER_VOUCHER ";
                    strSQL = strSQL + " WHERE LEDGER_GROUP = 202 OR LEDGER_GROUP = 203 ";
                    strSQL = strSQL + " GROUP BY LEDGER_PARENT_GROUP,LEDGER_NAME";
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

        private static string CreateSalItemSoldByMonthQry()
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

                    strSQL = "IF EXISTS (SELECT * From sysobjects WHERE id = object_id(N'[dbo].[SAL_ITEM_SOLD_BY_MONTH]') AND OBJECTPROPERTY(id, N'IsView') = 1) DROP VIEW [dbo].[SAL_ITEM_SOLD_BY_MONTH]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW SAL_ITEM_SOLD_BY_MONTH  AS ";
                    strSQL = strSQL + " SELECT STOCKITEM_NAME,";
                    strSQL = strSQL + " SUM(BILL_QUANTITY * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 1)))) AS JAN_S,";
                    strSQL = strSQL + " SUM(BILL_QUANTITY * (1 - ABS(SIGN(DATEPART(mm,COMP_VOUCHER_DATE) - 2)))) AS FEB_S,";
                    strSQL = strSQL + " SUM(BILL_QUANTITY * (1 - Abs(SIGN(DatePart(mm, COMP_VOUCHER_DATE) - 3)))) As MAR_S,";
                    strSQL = strSQL + " SUM(BILL_QUANTITY * (1 - Abs(SIGN(DatePart(mm, COMP_VOUCHER_DATE) - 4)))) As APR_S,";
                    strSQL = strSQL + " SUM(BILL_QUANTITY * (1 - Abs(SIGN(DatePart(mm, COMP_VOUCHER_DATE) - 5)))) As MAY_S,";
                    strSQL = strSQL + " SUM(BILL_QUANTITY * (1 - Abs(SIGN(DatePart(mm, COMP_VOUCHER_DATE) - 6)))) As JUN_S,";
                    strSQL = strSQL + " SUM(BILL_QUANTITY * (1 - Abs(SIGN(DatePart(mm, COMP_VOUCHER_DATE) - 7)))) As JUL_S,";
                    strSQL = strSQL + " SUM(BILL_QUANTITY * (1 - Abs(SIGN(DatePart(mm, COMP_VOUCHER_DATE) - 8)))) As AUG_S,";
                    strSQL = strSQL + " SUM(BILL_QUANTITY * (1 - Abs(SIGN(DatePart(mm, COMP_VOUCHER_DATE) - 9)))) As SEP_S,";
                    strSQL = strSQL + " SUM(BILL_QUANTITY * (1 - Abs(SIGN(DatePart(mm, COMP_VOUCHER_DATE) - 10)))) As OCT_S,";
                    strSQL = strSQL + " SUM(BILL_QUANTITY * (1 - Abs(SIGN(DatePart(mm, COMP_VOUCHER_DATE) - 11)))) As NOV_S,";
                    strSQL = strSQL + " SUM(BILL_QUANTITY * (1 - Abs(SIGN(DatePart(mm, COMP_VOUCHER_DATE) - 12)))) As DEC_S";
                    strSQL = strSQL + " FROM ACC_BILL_TRAN ";
                    strSQL = strSQL + " WHERE COMP_VOUCHER_TYPE = 16 ";
                    strSQL = strSQL + " GROUP BY STOCKITEM_NAME ";
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
        private static string CreateMultiCashBankView()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_VCH_MULTI_CASH_BANK]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_VCH_MULTI_CASH_BANK]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_VCH_MULTI_CASH_BANK AS ";
                    strSQL = strSQL + "SELECT LEDGER_SERIAL,LEDGER_NAME,LEDGER_PARTY_TYPE, ";
                    strSQL = strSQL + "LEDGER_PARENT_GROUP, LEDGER_PARTY_UNDER, LEDGER_OPENING_BALANCE, ";
                    strSQL = strSQL + "LEDGER_CLOSING_BALANCE, LEDGER_CREDIT_LIMIT, LEDGER_CURRENCY_NAME, LEDGER_ADDRESS1, LEDGER_ADDRESS2, LEDGER_CITY, ";
                    strSQL = strSQL + "LEDGER_POSTAL, LEDGER_PHONE, LEDGER_FAX,LEDGER_EMAIL,LEDGER_COMMENTS, LEDGER_BENEFIT, LEDGER_NATURE,LEDGER_GROUP,";
                    strSQL = strSQL + "LEDGER_PRIMARY_TYPE,LEDGER_VECTOR,LEDGER_BILL_WISE, LEDGER_INVENTORY_AFFECT, LEDGER_DEFAULT,";
                    strSQL = strSQL + "LEDGER_LEVEL,LEDGER_CASH_FLOW_TYPE, LEDGER_CURRENCY_SYMBOL,LEDGER_PAYROLL ";
                    strSQL = strSQL + "FROM ACC_LEDGER ";
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
        private static string CreateAccPOSReportQry()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[POS_ACC_REPORT_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[POS_ACC_REPORT_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW POS_ACC_REPORT_VIEW AS ";
                    strSQL = strSQL + "SELECT ACC_COMPANY_VOUCHER_POS_MASTER.INVOICE_NO, ACC_COMPANY_VOUCHER_POS_MASTER.INVOICE_DATE,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER_POS_MASTER.POS_USER, ACC_COMPANY_VOUCHER_POS_MASTER.DISCOUNT_PERCENTAGE,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER_POS_TRAN.STOCKITEM_NAME, ACC_COMPANY_VOUCHER_POS_MASTER.SUB_TOTAL,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER_POS_MASTER.CUSTOMER_NAME, ACC_COMPANY_VOUCHER_POS_MASTER.TOTAL_VAT,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER_POS_MASTER.CASH_PAY, ACC_COMPANY_VOUCHER_POS_MASTER.CARD_PAY,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER_POS_MASTER.CARD_NO, ACC_COMPANY_VOUCHER_POS_MASTER.PAID_AMOUNT,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER_POS_MASTER.POSTED, ACC_COMPANY_VOUCHER_POS_MASTER.CHEQUE_PAY,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER_POS_MASTER.BRANCH_ID, ACC_COMPANY_VOUCHER_POS_TRAN.BILL_QUANTITY,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER_POS_TRAN.STOCKITEM_BASEUNITS, ACC_COMPANY_VOUCHER_POS_TRAN.BILL_RATE,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER_POS_TRAN.VAT_AMOUNT, ACC_COMPANY_VOUCHER_POS_TRAN.BILL_AMOUNT,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER_POS_TRAN.STOCKITEM_ALIAS ";
                    strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER_POS_MASTER INNER JOIN ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER_POS_TRAN ON ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER_POS_MASTER.INVOICE_NO = ACC_COMPANY_VOUCHER_POS_TRAN.INVOICE_NO ";
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
        private static string CreateVoucherSummary()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_VOUCHER_SUMMARY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_VOUCHER_SUMMARY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_VOUCHER_SUMMARY AS ";
                    strSQL = strSQL + "SELECT LEDGER_NAME, SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT) AS VCH_AMOUNT ";
                    strSQL = strSQL + "FROM ACC_VOUCHER GROUP BY LEDGER_NAME ";
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
        private static string CreateVoucherSummaryTemp()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_VOUCHER_SUMMARY_TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_VOUCHER_SUMMARY_TEMP]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_VOUCHER_SUMMARY_TEMP AS ";
                    strSQL = strSQL + "SELECT LEDGER_NAME, SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT) AS VCH_AMOUNT ";
                    strSQL = strSQL + "FROM ACC_VOUCHER GROUP BY LEDGER_NAME ";
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
        private static string CreateLedgerVoucherSummaryTemp()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_VOUCHER_SUMMARY_TEMP]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_VOUCHER_SUMMARY_TEMP]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGER_VOUCHER_SUMMARY_TEMP AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER.LEDGER_NAME, ACC_LEDGER.LEDGER_OPENING_BALANCE + ISNULL(ACC_VOUCHER_SUMMARY_TEMP.VCH_AMOUNT, 0) AS AMT ";
                    strSQL = strSQL + "FROM ACC_LEDGER LEFT OUTER JOIN ";
                    strSQL = strSQL + "ACC_VOUCHER_SUMMARY_TEMP ON ACC_LEDGER.LEDGER_NAME = ACC_VOUCHER_SUMMARY_TEMP.LEDGER_NAME ";
                    strSQL = strSQL + "WHERE (ACC_LEDGER.LEDGER_PRIMARY_TYPE < 3) ";
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
        private static string CreateLedgerCommissionTemp()
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_Commission_View]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_Commission_View]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_Commission_View AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER.LEDGER_NAME_MERZE ,  sum( ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT) as Samount,'0' as CSamount ";
                    strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER AS ACC_COMPANY_VOUCHER ";
                    strSQL = strSQL + "INNER JOIN ACC_BRANCH ON ACC_COMPANY_VOUCHER.BRANCH_ID = ACC_BRANCH.BRANCH_ID  ";
                    strSQL = strSQL + "INNER JOIN ACC_LEDGER ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME AND ACC_BRANCH.BRANCH_ID = ACC_LEDGER.BRANCH_ID ";
                    strSQL = strSQL + "LEFT OUTER JOIN (SELECT LEDGER_CODE, LEDGER_NAME, LEDGER_ADDRESS1, LEDGER_ADDRESS2 ,HOMOEO_HALL FROM  ACC_LEDGER AS ACC_LEDGER_1 WHERE (LEDGER_GROUP = '204')) ";
                    strSQL = strSQL + "AS Customer ON ACC_COMPANY_VOUCHER.SALES_REP = Customer.LEDGER_NAME ";
                    strSQL = strSQL + "Group by ACC_LEDGER.LEDGER_NAME_MERZE ";
                    strSQL = strSQL + "Union all ";
                    strSQL = strSQL + "SELECT   ACC_LEDGER.LEDGER_NAME_MERZE LEDGER_NAME ,";
                    strSQL = strSQL + "'0' as Samount, sum( ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT) as CSamount ";
                    strSQL = strSQL + "FROM ACC_LEDGER,ACC_COMPANY_VOUCHER,ACC_CUSTOMER_LIST WHERE ACC_LEDGER.LEDGER_NAME =ACC_COMPANY_VOUCHER.LEDGER_NAME ";
                    strSQL = strSQL + "AND ACC_CUSTOMER_LIST.LEDGER_NAME =ACC_COMPANY_VOUCHER.SALES_REP AND (ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE = 16) ";
                    strSQL = strSQL + "Group by ACC_LEDGER.LEDGER_NAME_MERZE  ";
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
        private static string CreateDump()
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
                    strSQL = "CREATE TABLE SAL_PUR_DAILY_TEMP(";
                    strSQL = strSQL + "PRIMARY_TYPE SMALLINT DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ",SECONDARY_TYPE SMALLINT DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ",BRANCH_ID CHAR(4) NULL";
                    strSQL = strSQL + ",SUPPLIER_NAME VARCHAR(60) NULL";
                    strSQL = strSQL + ",STOCKITEM_NAME VARCHAR(60) NULL";
                    strSQL = strSQL + ",QUANTITY NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ",RATE NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ",AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ",VOUCHER_DATE DATETIME NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE ACC_BANK_TEMP(";
                    strSQL = strSQL + "REF_NO SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(200)  NULL,";
                    strSQL = strSQL + "OPENING NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "DEBIT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CREDIT NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE INV_PRODUCTION_TEMP(";
                    strSQL = strSQL + "REF_NO SMALLINT DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ",BRANCH_ID CHAR(4) NULL";
                    strSQL = strSQL + ",STOCKITEM_NAME VARCHAR(60) NULL";
                    strSQL = strSQL + ",QUANTITY NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ",CLOSING_BALANCE NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE ACC_TRANS_SUMMARY_TEMP(";
                    strSQL = strSQL + "REF_NO SMALLINT DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ",PRIMARY_TYPE SMALLINT DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ",BRANCH_ID CHAR(4) NULL";
                    strSQL = strSQL + ",QUANTITY NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ",AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ",PAYMENT NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE ACC_COMP_INWORD(";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL ";
                    strSQL = strSQL + ",INWORD_AMOUNT VARCHAR (150) NULL";
                    strSQL = strSQL + ")";

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
