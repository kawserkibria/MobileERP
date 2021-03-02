using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dutility
{
    public class basTableSchemaAccount
    {
        public static string gCreateAccounts(string vstrCompanyName)
        {
            string strSQL;
            strSQL = CreateTeritorry();
            strSQL = CreateCurrency();
            strSQL = CreateclassMaster();
            strSQL = CreateclassTran();
            strSQL = CreateDestination();
            strSQL = CreateTransportName();
            strSQL = CreateCompanyInformation(vstrCompanyName);
            strSQL = CreateBranch();
            strSQL = CreateGroupCompany();
            strSQL = CreateGroupCompanyTran();
            strSQL = CreateConfig();
            strSQL = CreateUser();
            strSQL = CreateUserPrivilegesMain();
            strSQL = CreateUserPrivilegesChild();
            
            strSQL = CreateLogin();
            strSQL = CreateLedgerGroup();
            strSQL = CreateLedger();
            strSQL = CreateBranchLedgerOpening();
            strSQL = CreateFixedAssetPurchaseAmount();
            strSQL = CreateFixedAssetAccDep();
            strSQL = CreateLedgerOpeningBalance();
            strSQL = CreateLedgerTransaction();

            strSQL = CreateLedgerAndGroup();
            strSQL = CreateLedgerToGroup();
            strSQL = CreateGroupToLedger();
            strSQL = CreateVoucherType();
            strSQL = CreateCompanyVoucher();
            strSQL = CreateVoucher();
            strSQL = CreateVoucherJoin();
            strSQL = CreateCurrencyExchange();
            strSQL = CreateStockInHand();
            strSQL = CreateSysAudit();
            strSQL = CreateSalesPriceReport();
            strSQL = CreateFixedAsset();
            strSQL = CreateFixedAssetAdjustment();
            strSQL = CreateUtility();
            strSQL = CreateBranchLedgerConfig();
            strSQL = CreateBudgetMaster();
            strSQL = CreateBudgetDetail();
            strSQL = CreateCostCategory();
            strSQL = CreateCostCenter();

            strSQL = CreateVectorTransaction();
            strSQL = CreateVectorMasterChild();

            strSQL = CreatePriceLevel();
            strSQL = CreateInvoiceConfig();
            strSQL = CreateVoucherConfig();
            strSQL = CreateQuatationMaster();
            strSQL = CreateBillWise();
            strSQL = CreateAddLess();
            strSQL = CreateLedgerInterestMaster();
            strSQL = CreateLedgerInterestDetails();
            strSQL = CreateInterest();
            strSQL = CreateAccStatistics();
            strSQL = CreateBillTranPENDING();
            strSQL = CreateBranchOpening();
            strSQL = CreateDeleteLog();
            strSQL = CreateUpdateLog();
          
            strSQL = CreateVoucherDocument();
            strSQL = CreatePDCAutoChequeMaster();
            strSQL = CreateMRMaster();
          
            strSQL = CreateChequePrint();
            strSQL = CreateDebtorStatement();
            strSQL = CreateNewConfig();
            strSQL = CreateTableService();
            strSQL = CreateBillStaDump();
            strSQL = CreateTargetAchievmentMaster();
            strSQL = CreateTargetAchievmentTran();
            strSQL = CreateCreditLimitMaster();
            strSQL = CreateCreditSales();
            strSQL = CreateSalesCollTarMaster();
            strSQL = CreateSalesCollTran();
            strSQL = CreateExpenseConfig();

            strSQL = CreateProjection();
            return strSQL;
        }
         #region AccountsSchema
        private static string CreateProjection()
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
                    strSQL = "CREATE TABLE SALES_PERFORMANCE(";
                    strSQL = strSQL + "PARTICULARS VARCHAR(30) NOT NULL,";
                    strSQL = strSQL + "SEL_MODE INT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "MONTH_NO INTEGER NOT NULL,";
                    strSQL = strSQL + "AMNT NUMERIC(18,2) DEFAULT 0  NOT NULL,";
                    strSQL = strSQL + "SORTING_TYPE INT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "UP_TO_DATE_AMNT  NUMERIC(18,2) DEFAULT 0  NOT NULL,";
                    strSQL = strSQL + "BALANCE  NUMERIC(18,2) DEFAULT 0  NOT NULL,";
                    strSQL = strSQL + "TOTAL_PERCENT NUMERIC(18,2) DEFAULT 0 NOT NULL ";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE PRO_MONTH_CONFIG(";
                    strSQL = strSQL + "MONTH_SERIAL int IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "MONTH_ID varchar(5) NOT NULL CONSTRAINT PK_PRO_MONTH_CONFIG_MONTH_ID PRIMARY KEY,";
                    strSQL = strSQL + "FROM_DATE datetime NOT NULL,";
                    strSQL = strSQL + "TO_DATE datetime NOT NULL,";
                    strSQL = strSQL + "STATUS SMALLINT DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE PROJECTION_SETUP(";
                    strSQL = strSQL + "PROJECTION_SERIAL int IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "PROJECTION_KEY varchar(50) NOT NULL CONSTRAINT PK_PROJECTION_SETUP_PROJECTION_KEY PRIMARY KEY,";
                    strSQL = strSQL + "MONTH_ID varchar(5) NULL CONSTRAINT FK_PROJECTION_SETUP_PROJECTION_MONTH REFERENCES PRO_MONTH_CONFIG(MONTH_ID) ON UPDATE CASCADE,";
                    strSQL = strSQL + "PROJECTION_NAME varchar(50) NULL,";
                    strSQL = strSQL + "PROJECTION_DATE datetime NOT NULL,";
                    strSQL = strSQL + "PROJECTION_START_DATE datetime NOT NULL,";
                    strSQL = strSQL + "PROJECTION_END_DATE datetime NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE PRO_MONTHLY_PROJECTION_CHILD(";
                    strSQL = strSQL + "MONTHLY_PROJECTION_KEY varchar(70) NOT NULL,";
                    strSQL = strSQL + "SL_NO NUMERIC(18,0) IDENTITY(1,1) PRIMARY KEY,";
                    strSQL = strSQL + "MONTH_ID varchar(5) NULL CONSTRAINT FK_PRO_MONTHLY_PROJECTION_CHILD_MONTH_ID REFERENCES PRO_MONTH_CONFIG(MONTH_ID) ON UPDATE CASCADE,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NULL CONSTRAINT FK_PRO_MONTHLY_PROJECTION_CHILD_LEDGER_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "PROJECTION_NAME varchar(60) NOT NULL,";
                    strSQL = strSQL + "AMOUNT numeric(18, 2) NOT NULL,";
                    strSQL = strSQL + "COLS numeric(18, 0) NOT NULL,";
                    strSQL = strSQL + "ROWPOS numeric(18, 0) NOT NULL";
                    strSQL = strSQL + ") ";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE PRO_WEEKLY_PROJECTION(";
                    strSQL = strSQL + "WEEKLY_PROJECTION_KEY varchar(70) NOT NULL ,";
                    strSQL = strSQL + "SL_NO numeric(18, 0) IDENTITY(1,1) NOT NULL CONSTRAINT PK_WEEKLY_PROJECTION_SL_NO PRIMARY KEY,";
                    strSQL = strSQL + "MONTH_ID varchar(5) NULL CONSTRAINT FK_PRO_WEEKLY_PROJECTION_MONTH_ID REFERENCES PRO_MONTH_CONFIG(MONTH_ID) ON UPDATE CASCADE,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_PRO_WEEKLY_PROJECTION_LEDGER REFERENCES ACC_LEDGER (LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "PROJECTION_NAME varchar(60) NOT NULL,";
                    strSQL = strSQL + "AMOUNT numeric(18, 2) NOT NULL,";
                    strSQL = strSQL + "COLS numeric(18, 0) NOT NULL,";
                    strSQL = strSQL + "ROWPOS numeric(18, 0) NOT NULL,";
                    strSQL = strSQL + "COMM_PROJECTON_NAME varchar(60) NULL";
                    strSQL = strSQL + ") ";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE PROJECTION_TEMP(";
                    strSQL = strSQL + "SERIAL_NO int IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar(70) NULL,";
                    strSQL = strSQL + "PROJECTION_NAME varchar(50) NULL,";
                    strSQL = strSQL + "MONTH_NAME varchar(50) NULL,";
                    strSQL = strSQL + "AMOUNT numeric(18, 2)  DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ") ";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE ACC_COMP_VOUCHER_TEMP(";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(60) NOT NULL,";
                    strSQL = strSQL + "MONTH_ID VARCHAR(5) NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE DATETIME NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE INT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "NET_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SALES_EVALUATION_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[SALES_EVALUATION_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW SALES_EVALUATION_VIEW AS ";
                    strSQL = strSQL + "SELECT SORTING_TYPE,SEL_MODE,PARTICULARS,LEDGER_NAME,";
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =1 THEN ISNULL(SUM(AMNT),0) ELSE 0 END  ) AS JAN,";
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
                    strSQL = strSQL + "(CASE WHEN MONTH_NO =12 THEN ISNULL(SUM(AMNT),0) ELSE 0 END  ) AS DEC,";
                    strSQL = strSQL + "SUM(UP_TO_DATE_AMNT) UP_TO_DATE_AMNT,SUM(BALANCE) BALANCE FROM SALES_PERFORMANCE ";
                    strSQL = strSQL + "GROUP BY SORTING_TYPE,SEL_MODE,PARTICULARS,LEDGER_NAME,MONTH_NO ";

                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SALES_EVALUATION_VIEW1]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[SALES_EVALUATION_VIEW1]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW SALES_EVALUATION_VIEW1 AS ";
                    strSQL = strSQL + "SELECT * FROM ACC_LEDGERGROUP WHERE GR_GROUP=100  ";
                    cmd.Connection = gcnmain;
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
        private static string CreateExpenseConfig()
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
                    strSQL = "CREATE TABLE ACC_EXPENSE_CONFIG_MASTER(";
                    strSQL = strSQL + "SL_NO numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "CONFIGL_KEY varchar(70) CONSTRAINT PK_ACC_EXPENSE_CONFIG_MASTER_CONFIG_KEY PRIMARY KEY ,";       //EXPENSE+DATE
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_ACC_EXPENSE_CONFIG_MASTER_LEDGER REFERENCES ACC_LEDGER (LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "EFFECTIVE_DATE datetime not null,";
                    strSQL = strSQL + "VOUCHER_TYPE smallint default 0 not null,";
                    strSQL = strSQL + "PER_STATUS smallint default 0 not null,";
                    strSQL = strSQL + "POSITION INT DEFAULT 0 NOT NULL ";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE ACC_EXPENSE_CONFIG_TRAN(";
                    strSQL = strSQL + "CONFIGL_KEY varchar(70) NOT NULL CONSTRAINT FK_ACC_EXPENSE_CONFIG_TRAN_CONFIGL_KEY REFERENCES ACC_EXPENSE_CONFIG_MASTER (CONFIGL_KEY) ON UPDATE CASCADE,";
                    strSQL = strSQL + "AMOUNT_FORM numeric(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT_TO numeric(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "EFFECTIVE_DATE datetime not null,";
                    strSQL = strSQL + "CONFIG_PERCENTAGES numeric(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE ACC_FINAL_STATEMENT(";
                    strSQL = strSQL + "ZONE varchar(60) NULL,";
                    strSQL = strSQL + "DIVISION varchar(60) NULL,";
                    strSQL = strSQL + "AREA varchar(60) NULL,";
                    strSQL = strSQL + "TERITORY_NAME varchar(60) NULL,";
                    strSQL = strSQL + "TERITORY_CODE varchar(60) NULL,";
                    strSQL = strSQL + "MEDICAL_REPRESENTATIVE varchar(200) NULL,";
                    strSQL = strSQL + "DOCTOR_CUSTOMER varchar(200) NULL,";
                    strSQL = strSQL + "PREVIOUS_DUES_GOODS numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "PREVIOUS_DUES_SHORT numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "SALES_CURRENT_MONTH numeric (18, 2) default 0  NOT NULL ,";
                    strSQL = strSQL + "COLL_ON_COMMIT numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "RETURN_AMOUNT numeric (18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "DEBIT_AMOUNT numeric (18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "CREDIT_AMOUNT numeric (18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMMITMENT numeric (18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "COLL_CASH_TT numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "COLL_VOUCHER numeric (18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "CP_COMMISSION numeric (18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "PF_HL numeric (18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "POSITION INT  default 9999 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE ACC_MARKET_MONITROING_SHEET(";
                    strSQL = strSQL + "ZONE varchar(60) NULL,";
                    strSQL = strSQL + "DIVISION varchar(60) NULL,";
                    strSQL = strSQL + "AREA varchar(60) NULL,";
                    strSQL = strSQL + "TERITORRY_NAME varchar(60) NULL,";
                    strSQL = strSQL + "TERITORRY_CODE varchar(60) NULL,";
                    strSQL = strSQL + "MR_NAME varchar(200) NULL,";
                    strSQL = strSQL + "TOTAL_OS numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMMITMENT numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "COLLECTION_AMNT numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "SALES_TARGET numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "ACHIEVE numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "SP_VOUCHER numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "SALES_RETURN numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "JV_DEBIT numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "JV_CREDIT numeric(18, 2) default 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE USER_FORM_CONFIG(";
                    strSQL = strSQL + "SL_NO numeric (18,0) IDENTITY (1,1) NOT NULL PRIMARY KEY,";
                    strSQL = strSQL + "FORM_KEY varchar(200) NULL,";
                    strSQL = strSQL + "FORM_NAME varchar(60) NULL,";
                    strSQL = strSQL + "MODULE_TYPE SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "MODE_TYPE SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + " FORM_STATUS SMALLINT DEFAULT 0 NOT NULL,";
                    //strSQL = strSQL + " MODULE_FORM_NAME varchar (60) NULL,";
                    //strSQL = strSQL + " FORM_POS varchar(30) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE ACC_LOAN_TEMPLATE_MASTER(";
                    strSQL = strSQL + "TEMPLATE_NAME VARCHAR(60) NOT NULL CONSTRAINT PK_TEMPLATE_NAME_MASTER PRIMARY KEY,";
                    strSQL = strSQL + "INSTALLMENT_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "NO_OF_INSTALLMENT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "MONTHLY_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE ACC_LOAN_TEMPLATE_CHILD(";
                    strSQL = strSQL + "TEMPLATE_NAME VARCHAR(60) NOT NULL CONSTRAINT FK_TEMPLATE_NAME_CHILD REFERENCES  ACC_LOAN_TEMPLATE_MASTER(TEMPLATE_NAME),";
                    strSQL = strSQL + "INSTALLMET_NAME VARCHAR(60) NOT NULL,";
                    strSQL = strSQL + "MONTHLY_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE ACC_PAYMENT_SCHEDULE(";
                    strSQL = strSQL + "SL_NO numeric (18,0) IDENTITY (1,1) NOT NULL PRIMARY KEY,";
                    //strSQL = strSQL + "COMP_REF_NO VARCHAR(30) CONSTRAINT FK_ACC_PAYMENT_SCHEDULE_TRAN_COMP_REF_NO REFERENCES ACC_COMPANY_VOUCHER(COMP_REF_NO),";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_ACC_PAYMENT_SCHEDULE_LEDGER REFERENCES ACC_LEDGER (LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "TEMPLATE_NAME VARCHAR(60) NOT NULL CONSTRAINT FK_ACC_PAYMENT_SCHEDULE_TEMPLATE REFERENCES  ACC_LOAN_TEMPLATE_MASTER(TEMPLATE_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "DUE_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "RECEIVE_DATE DATETIME NULL,";
                    strSQL = strSQL + "RECEIVED_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INSTALLMET_NAME VARCHAR(60) NOT NULL,";
                    strSQL = strSQL + "MONTHLY_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "FINE_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "TO_BY CHAR(2) NOT NULL,";
                    strSQL = strSQL + "INSTALL_STATUS INT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "TRANSFER_TYPE CHAR(1) DEFAULT 'N' NOT NULL,";
                    strSQL = strSQL + "TRANSFER_DATE DATETIME NULL,";
                    strSQL = strSQL + "NARRATION  VARCHAR(200) NULL,";
                    strSQL = strSQL + "FROM_LEDGER_NAME  VARCHAR(60) NULL";
                    strSQL = strSQL + ")";

                    cmd.Connection = gcnmain;
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
        private static string CreateTeritorry()
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
                    strSQL = "CREATE TABLE ACC_TERITORRY(";
                    strSQL = strSQL + "TERR_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "TERITORRY_CODE varchar(8) CONSTRAINT PK_ACC_TERITORRY_TERITORRY_CODE PRIMARY KEY ,";
                    strSQL = strSQL + "TERITORRY_NAME varchar(60) NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE ACC_MONTH_SETUP(";
                    strSQL = strSQL + "MONTH_ID VARCHAR(5) CONSTRAINT PK_MONTH_ID PRIMARY KEY,";
                    strSQL = strSQL + "FROM_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "TO_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "MONTH_STATUS SMALLINT DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE ACC_COLL_MONTH_SETUP(";
                    strSQL = strSQL + "MONTH_ID VARCHAR(5) CONSTRAINT PK_ACC_COLL_MONTH_SETUP_MONTH_ID PRIMARY KEY,";
                    strSQL = strSQL + "FROM_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "TO_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "GRACE_FROM_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "GRACE_TO_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "MONTH_STATUS SMALLINT DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
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
        private static string CreateclassMaster()
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
                    strSQL = "CREATE TABLE ACC_SAMPLE_CLASS_MASTER(";
                    strSQL = strSQL + "CLASS_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "SAMPLE_CLASS varchar(50) NOT NULL CONSTRAINT PK_ACC_SAMPLE_CLASS_MASTER PRIMARY KEY,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "EXPORT_TYPE smallint NULL,";
                    strSQL = strSQL + "EXPORT_FILE_NAME varchar(25) NULL,";
                    strSQL = strSQL + "IMPORT_FILE_NAME varchar(25) NULL";
                    strSQL = strSQL + ")";

                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        private static string CreateclassTran()
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
                    strSQL = "CREATE TABLE ACC_SAMPLE_CLASS_TRAN(";
                    strSQL = strSQL + "CLASS_TRAN_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL CONSTRAINT PK_ACC_SAMPLE_CLASS_TRAN PRIMARY KEY,";
                    strSQL = strSQL + "SAMPLE_CLASS varchar(50) NOT NULL CONSTRAINT FK_ACC_SAMPLE_CLASS_TRAN_SAMPLE_CLASS REFERENCES ACC_SAMPLE_CLASS_MASTER (SAMPLE_CLASS)ON UPDATE CASCADE,";
                    strSQL = strSQL + "CLASS_TRAN_POSITION smallint NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL,";
                    strSQL = strSQL + "SAM_CLASS_QUANTITY numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "SAM_CLASS_UOM varchar(10) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "EXPORT_TYPE smallint NULL,";
                    strSQL = strSQL + "EXPORT_FILE_NAME varchar(25) NULL,";
                    strSQL = strSQL + "IMPORT_FILE_NAME varchar(25) NULL";
                    strSQL = strSQL + ")";


                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        private static string CreateDestination()
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
                    strSQL = "CREATE TABLE ACC_DESTINATION(";
                    strSQL = strSQL + "SERIAL_NO numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "DESTINATION_NAME varchar(60) NOT NULL CONSTRAINT PK_ACC_DESTINATION PRIMARY KEY CLUSTERED ";
                    strSQL = strSQL + ")";


                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        private static string CreateTransportName()
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
                    strSQL =  "CREATE TABLE ACC_TRANSPORT_NAME(";
                    strSQL = strSQL + "SERIAL_NO numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "TRANSPORT_NAME varchar(60) NOT NULL CONSTRAINT PK_ACC_TRANSPORT_NAME PRIMARY KEY";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        private static string CreateTargetAchievmentMaster()
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
                    strSQL = "CREATE TABLE SALES_TARGET_ACHIEVEMENT_MASTER(";
                    strSQL = strSQL + "TARGET_ACHIEVE_DETAIL_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "TARGET_ACHIEVE_KEY varchar(20) NOT NULL CONSTRAINT PK_TARGET_ACHIEVE_KEY PRIMARY KEY,";
                    strSQL = strSQL + "TARGET_ACHIEVE_FROM_DATE datetime NOT NULL,";
                    strSQL = strSQL + "TARGET_ACHIEVE_TO_DATE datetime NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char(4) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        private static string CreateTargetAchievmentTran()
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
                    strSQL = "CREATE TABLE SALES_TARGET_ACHIEVEMENT(";
                    strSQL = strSQL + "TARGET_ACHIEVE_DETAIL_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "TARGET_ACHIEVE_KEY_REF varchar(125) NOT NULL CONSTRAINT UQ_SALES_TARGET_ACHIEVEMENT UNIQUE,";
                    strSQL = strSQL + "TARGET_ACHIEVE_KEY varchar(20) NOT NULL CONSTRAINT FK_SALES_TARGET_ACHIEVEMENT_KEY REFERENCES SALES_TARGET_ACHIEVEMENT_MASTER (TARGET_ACHIEVE_KEY)ON UPDATE CASCADE,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_SALES_TARGET_ACHIEVEMENT_LEDGER REFERENCES ACC_LEDGER (LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "TARGET_ACHIEVE_FROM_DATE datetime NOT NULL,";
                    strSQL = strSQL + "TARGET_ACHIEVE_TO_DATE datetime NOT NULL,";
                    strSQL = strSQL + "TARGET_ACHIEVE_MONTH_ID varchar(6) NOT NULL,";
                    strSQL = strSQL + "COL_POS smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ROW_POS smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "TARGET_ACHIEVE_AMOUNT numeric(18, 2) NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "EXPORT_TYPE smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "EXPORT_FILE_NAME varchar(25) NULL,";
                    strSQL = strSQL + "IMPORT_FILE_NAME varchar(25) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        private static string CreateCreditLimitMaster()
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
                    strSQL = "CREATE TABLE SALES_CREDIT_LIMIT_MASTER(";
                    strSQL = strSQL + "CREDIT_LIMIT_DETAIL_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "CREDIT_LIMIT_KEY varchar(20) NOT NULL CONSTRAINT PK_CREDIT_LIMIT_KEY PRIMARY KEY,";
                    strSQL = strSQL + "CREDIT_LIMIT_FROM_DATE datetime NOT NULL,";
                    strSQL = strSQL + "CREDIT_LIMIT_TO_DATE datetime NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char(4) NULL";
                    strSQL = strSQL + ")"; 
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        private static string CreateCreditSales()
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
                    strSQL = "CREATE TABLE SALES_CREDIT_LIMIT(";
                    strSQL = strSQL + "CREDIT_LIMIT_DETAIL_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "CREDIT_LIMIT_KEY_REF varchar(125) NOT NULL CONSTRAINT UQ_SALES_CREDIT_LIMIT UNIQUE,";
                    strSQL = strSQL + "CREDIT_LIMIT_KEY varchar(20) NOT NULL  CONSTRAINT FK_SALES_CREDIT_LIMIT_KEY REFERENCES SALES_CREDIT_LIMIT_MASTER (CREDIT_LIMIT_KEY)ON UPDATE CASCADE,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_SALES_CREDIT_LIMIT_LEDGER REFERENCES ACC_LEDGER (LEDGER_NAME)ON UPDATE CASCADE,";
                    strSQL = strSQL + "CREDIT_LIMIT_FROM_DATE datetime NOT NULL,";
                    strSQL = strSQL + "CREDIT_LIMIT_TO_DATE datetime NOT NULL,";
                    strSQL = strSQL + "CREDIT_LIMIT_MONTH_ID varchar(6) NOT NULL,";
                    strSQL = strSQL + "COL_POS smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ROW_POS smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CREDIT_LIMIT_AMOUNT numeric(18, 2) NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "EXPORT_TYPE smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "EXPORT_FILE_NAME varchar(25) NULL,";
                    strSQL = strSQL + "IMPORT_FILE_NAME varchar(25) NULL";
                    strSQL = strSQL + ")";


                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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


        private static string CreateSalesCollTarMaster()
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
                    strSQL = "CREATE TABLE SALES_COLL_TARGET_MASTER(";
                    strSQL = strSQL + "COLL_TARGET_DETAIL_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "COLL_TARGET_KEY varchar(20) NOT NULL CONSTRAINT PK_COLL_TARGET_KEY PRIMARY KEY,";
                    strSQL = strSQL + "COLL_TARGET_FROM_DATE datetime NOT NULL,";
                    strSQL = strSQL + "COLL_TARGET_TO_DATE datetime NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char(4) NULL";

                    strSQL = strSQL + ")";


                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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


        private static string CreateSalesCollTran()
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
                    strSQL = "CREATE TABLE SALES_COLL_TARGET_TRAN(";
                    strSQL = strSQL + "COLL_TARGET_DETAIL_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "COLL_TARGET_KEY_REF varchar(125) NOT NULL CONSTRAINT UQ_SALES_COLL_TARGET_TRAN UNIQUE,";
                    strSQL = strSQL + "COLL_TARGET_KEY varchar(20) NOT NULL CONSTRAINT FK_SALES_COLL_TARGET_KEY REFERENCES SALES_COLL_TARGET_MASTER (COLL_TARGET_KEY)ON UPDATE CASCADE,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_SALES_COLL_TARGET_LEDGER REFERENCES dbo.ACC_LEDGER (LEDGER_NAME)ON UPDATE CASCADE,";
                    strSQL = strSQL + "COLL_TARGET_FROM_DATE datetime NOT NULL,";
                    strSQL = strSQL + "COLL_TARGET_TO_DATE datetime NOT NULL,";
                    //strSQL = strSQL + "COLL_TARGET_MONTH_ID varchar(6) NOT NULL,";
                    //strSQL = strSQL + "MONTH_ID VARCHAR(5) NOT NULL CONSTRAINT FK_SALES_COLL_MONTH_ID REFERENCES ACC_MONTH_SETUP(MONTH_ID)ON UPDATE CASCADE,";
                    strSQL = strSQL + "MONTH_ID VARCHAR(5) NOT NULL,";
                    strSQL = strSQL + "COLL_TARGET_OPENING numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "COLL_TARGET_COLL_PER numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "COLL_TARGET_COLL_AMT numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "COL_POS smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ROW_POS smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "EXPORT_TYPE smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "EXPORT_FILE_NAME varchar(25) NULL,";
                    strSQL = strSQL + "IMPORT_FILE_NAME varchar(25) NULL";
                    strSQL = strSQL + ")";

                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        //private static string CreateMicroCredit()
        //{
        //    using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
        //    {
        //        if (gcnmain.State == System.Data.ConnectionState.Open)
        //        {
        //            gcnmain.Close();
        //        }
        //        try
        //        {
        //            gcnmain.Open();
        //            string strSQL;
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection=gcnmain;
        //            strSQL = "CREATE TABLE MICRO_OCCUPATION(";
        //            strSQL = strSQL + "OCCUPATION_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL, ";
        //            strSQL = strSQL + "OCCUPATION varchar(60) CONSTRAINT PK_OCCUPATION_OCCUPATION PRIMARY KEY, ";
        //            strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
        //            strSQL = strSQL + "UPDATE_DATE datetime NULL";
        //            strSQL = strSQL + ")";
        //            cmd.CommandText=strSQL;
        //            cmd.ExecuteNonQuery();
        //            strSQL = "CREATE TABLE MICRO_DIVISION(";
        //            strSQL = strSQL + "MICRO_DIVISION_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
        //            strSQL = strSQL + "DIVISION_NAME VARCHAR(60)  CONSTRAINT PK_MICRO_DIVISION_NAME PRIMARY KEY,";
        //            strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
        //            strSQL = strSQL + "UPDATE_DATE datetime NULL";
        //            strSQL = strSQL + ")";
        //            cmd.CommandText=strSQL;
        //            cmd.ExecuteNonQuery();
        //            strSQL = "CREATE TABLE MICRO_ZONE(";
        //            strSQL = strSQL + "MICRO_ZONE_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
        //            strSQL = strSQL + "ZONE_NAME VARCHAR(60) CONSTRAINT PK_MICRO_ZONE_NAME PRIMARY KEY,";
        //            //        strSQL = strSQL + "ZONE_NAME VARCHAR(60),"
        //            strSQL = strSQL + "DIVISION_NAME VARCHAR(60) NOT NULL CONSTRAINT FK_MICRO_ZONE_DIVISION_NAME REFERENCES MICRO_DIVISION(DIVISION_NAME) ON UPDATE CASCADE,";
        //            strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
        //            strSQL = strSQL + "UPDATE_DATE datetime NULL";
        //            strSQL = strSQL + ")";
        //            cmd.CommandText=strSQL;
        //            cmd.ExecuteNonQuery();
        //            strSQL = "CREATE TABLE MICRO_MEMBER(";
        //            strSQL = strSQL + "MEMBER_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL, ";
        //            strSQL = strSQL + "MR_NO varchar(60) NOT NUll ,";
        //            strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_MICRO_MEMBER_LEDGER_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
        //            strSQL = strSQL + "MEMBER_DATE datetime NULL,";
        //            strSQL = strSQL + "ZONE_NAME varchar(60) NULL CONSTRAINT FK_ZONE_NAME REFERENCES MICRO_ZONE(ZONE_NAME) ON UPDATE CASCADE,";
        //            strSQL = strSQL + "OCCUPATION varchar(60) NOT NULL CONSTRAINT FK_OCCUPATION REFERENCES MICRO_OCCUPATION(OCCUPATION) ON UPDATE CASCADE,";
        //            //        strSQL = strSQL + "FULL_NAME varchar(60) NOT NULL,"
        //            strSQL = strSQL + "DATE_OF_BIRTH datetime NULL,";
        //            strSQL = strSQL + "BIRTH_PLACE varchar(60) NULL,";
        //            strSQL = strSQL + "ADDRESS1 varchar(60) NULL,";
        //            strSQL = strSQL + "ADDRESS2 varchar(60) NULL,";
        //            strSQL = strSQL + "FATHER_NAME varchar(60) NULL,";
        //            strSQL = strSQL + "MOTHER_NAME varchar(60) NULL,";
        //            strSQL = strSQL + "ADDRESS_PERMANENT1 varchar(60) NULL,";
        //            strSQL = strSQL + "ADDRESS_PERMANENT2 varchar(60) NULL,";
        //            strSQL = strSQL + "NOMINEE_NAME varchar(60) NULL,";
        //            strSQL = strSQL + "NOMINEE_ADDRESS varchar(60) NULL,";
        //            strSQL = strSQL + "STATUS numeric(4,0) default 1 NOT NULL,";
        //            strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
        //            strSQL = strSQL + "UPDATE_DATE datetime NULL";
        //            strSQL = strSQL + ")";
                    
        //            cmd.CommandText = strSQL;
        //            cmd.ExecuteNonQuery();
        //            return strSQL;
        //        }
        //        finally
        //        {
        //            gcnmain.Close();
        //        }
        //    }
        //}
        //private static string CreateImportExport()
        //{
        //    using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
        //    {
        //        if (gcnmain.State == System.Data.ConnectionState.Open)
        //        {
        //            gcnmain.Close();
        //        }
        //        try
        //        {
        //            gcnmain.Open();
        //            string strSQL;
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = gcnmain;
        //            strSQL = "CREATE TABLE ACC_IMPORT_EXPORT_DOC_MASTER(";
        //            strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL CONSTRAINT PK_ACC_IMPORT_EXPORT_DOC_MASTER_COMPRE_NO PRIMARY KEY,";
        //            strSQL = strSQL + "VOUCHER_DATE  DATETIME  NULL,";
        //            strSQL = strSQL + "LEDGER_NAME VARCHAR(60) CONSTRAINT FK_ACC_IMPORT_EXPORT_DOC_MASTER_LEDGER_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
        //            strSQL = strSQL + "DELIVERY_DATE  DATETIME NULL,";
        //            strSQL = strSQL + "LC_NO VARCHAR(60) NULL,";
        //            strSQL = strSQL + "LC_DATE  DATETIME NULL,";
        //            strSQL = strSQL + "BILL_NO VARCHAR(60) NULL,";
        //            strSQL = strSQL + "BILL_DATE DATETIME NOT NULL,";
        //            strSQL = strSQL + "SALES_CONTACT VARCHAR(60) NULL,";
        //            strSQL = strSQL + "WEIGHT VARCHAR(20) NULL,";
        //            strSQL = strSQL + "DOC_VALUE VARCHAR(20) NULL,";
        //            strSQL = strSQL + "DOC_RECEIVED_DATE DATETIME  NULL,";
        //            strSQL = strSQL + "DOC_DELIVERY_DATE DATETIME  NULL,";
        //            strSQL = strSQL + "DOC_REMARKS VARCHAR(100),";
        //            strSQL = strSQL + "DOC_ENCLOSED VARCHAR(250),";
        //            strSQL = strSQL + "IMPORT_EXPORT_STATUS SMALLINT DEFAULT 0 NOT NULL," ;  // '0=EXP 1=IMPORT
        //            strSQL = strSQL + "INSERT_DATE DATETIME DEFAULT GETDATE() NOT NULL";
        //            strSQL = strSQL + ")";
        //            cmd.CommandText = strSQL;
        //            cmd.ExecuteNonQuery();
        //            strSQL = "CREATE TABLE ACC_IMPORT_EXPORT_DOC_TRAN(";
        //            strSQL = strSQL + "COMP_REF_NO VARCHAR(30) CONSTRAINT FK_ACC_IMPORT_EXPORT_DOC_TRAN_COMP_REF_NO REFERENCES ACC_IMPORT_EXPORT_DOC_MASTER(COMP_REF_NO) ON UPDATE CASCADE,";
        //            strSQL = strSQL + "ITEM_NAME VARCHAR(60) NULL,";
        //            strSQL = strSQL + "DOC_QTY NUMERIC(18,2) DEFAULT 0 NOT NULL,";
        //            strSQL = strSQL + "TOTAL_QTY NUMERIC(18,2) DEFAULT 0 NOT NULL,";
        //            strSQL = strSQL + "DELIVERY_QTY NUMERIC(18,2) DEFAULT 0 NOT NULL,";
        //            strSQL = strSQL + "REMAINING_QTY NUMERIC(18,2) DEFAULT 0 NOT NULL,";
        //            strSQL = strSQL + "INSERT_DATE DATETIME DEFAULT GETDATE() NOT NULL";
        //            strSQL = strSQL + ")";
        //            cmd.CommandText = strSQL;
        //            cmd.ExecuteNonQuery();
        //            return strSQL;
        //        }
        //        finally
        //        {
        //            gcnmain.Close();
        //        }
        //    }
        //}
        private static string CreateVectorTemp()
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
                    strSQL = "CREATE  TABLE ACC_VECTOR_TEMP(";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "COST_CATEGORY VARCHAR(60) NULL,";
                    strSQL = strSQL + "COST_CENTER VARCHAR(60) NULL,";
                    strSQL = strSQL + "NET_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";

                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateBillStaDump()
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
                    strSQL = "CREATE  TABLE ACC_BILL_STA_DUMP(";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "SISTERN_CONCERN VARCHAR(60) NULL,";
                    strSQL = strSQL + "NET_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PAYMENT_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BALANCE_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INWORD VARCHAR(300) NULL";
                    strSQL = strSQL + ")";
                
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateTableService()
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
                    strSQL = "CREATE TABLE ACC_SERVICE_TYPE(";
                    strSQL = strSQL + "SERVICE_TYPE numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_SERVICE_TYPE_SERVICE_NAME PRIMARY KEY,";
                    strSQL = strSQL + "LEDGER_PARENT_GROUP varchar(50) NOT NULL CONSTRAINT FK_ACC_SERVICE_TYPE_LEDGER_PARENT_GROUP REFERENCES ACC_LEDGERGROUP(GR_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "ADDRESS1 VARCHAR(60) NULL,";
                    strSQL = strSQL + "ADDRESS2 VARCHAR(60) NULL,";
                    strSQL = strSQL + "INSERT_DATE DATETIME DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE ACC_SERVICE_EXPENSES(";
                    strSQL = strSQL + "SERVICE_EXEPENSES VARCHAR(60) NOT NULL CONSTRAINT PK_ACC_SERVICE_EXPENSES_SERVICE_EXEPENSESE PRIMARY KEY,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE ACC_SERVICE_INVOICE_MASTER(";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL CONSTRAINT PK_ACC_SERVICE_INVOICE_COMPRE_NO PRIMARY KEY,";
                    strSQL = strSQL + "LEDGER_PARENT_GROUP varchar(60) NOT NULL CONSTRAINT FK_ACC_SERVICE_TYPE_SERVICE_TYPE REFERENCES ACC_LEDGER(LEDGER_NAME),";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(60) CONSTRAINT FK_ACC_SERVICE_INVOICE_MASTER_LEDGER_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BRANCH_ID CHAR(4) NULL,";
                    strSQL = strSQL + "CLEARANCE_OF VARCHAR(60) NULL,";
                    strSQL = strSQL + "CONSIGNMENT_VALUE NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BILL_OF_ENTRY VARCHAR(60) NULL,";
                    strSQL = strSQL + "BILL_DATE  DATETIME  NULL,";
                    strSQL = strSQL + "LC_NO VARCHAR(60) NULL,";
                    strSQL = strSQL + "DELIVERY_DATE  DATETIME NULL,";
                    strSQL = strSQL + "AWP_NO VARCHAR(60) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "VOUCHER_NET_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PURPOSE_OF_ADDLESS VARCHAR(60) NULL,";
                    strSQL = strSQL + "ADD_LESS_AMOUNT VARCHAR(20) NULL,";
                    strSQL = strSQL + "NET_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "NARRATION VARCHAR(100) NULL,";
                    strSQL = strSQL + "ENCLOSED VARCHAR(300) NULL,";
                    strSQL = strSQL + "CURRENCY VARCHAR(3) null,";
                    strSQL = strSQL + "INSERT_DATE DATETIME DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE ACC_SERVICE_INVOICE_TRAN(";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) CONSTRAINT FK_ACC_SERVICE_INVOICE_TRAN_COMP_REF_NO REFERENCES ACC_SERVICE_INVOICE_MASTER(COMP_REF_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "SERVICE_EXEPENSES VARCHAR(60) CONSTRAINT FK_ACC_SERVICE_INVOICE_TRAN_SERVICE_EXEPENSES REFERENCES ACC_SERVICE_EXPENSES(SERVICE_EXEPENSES) ON UPDATE CASCADE,";
                    strSQL = strSQL + "E_DESCRIPTION VARCHAR(60) NULL,";
                    strSQL = strSQL + "VOUCHER_NET_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CLOSING_BALANACE_UPT0 NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BALANCE NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE DATETIME DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE ACC_IMPORT_EXEPORT_INVOICE_MASTER(";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL CONSTRAINT PK_ACC_IMPORT_EXEPORT_INVOICE_MASTER_COMPRE_NO PRIMARY KEY,";
                    strSQL = strSQL + "LEDGER_PARENT_GROUP varchar(60) NULL CONSTRAINT FK_ACC_IMPORT_EXEPORT_INVOICE_MASTER_SERVICE_TYPE REFERENCES ACC_LEDGER(LEDGER_NAME),";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(60) CONSTRAINT FK_ACC_IMPORT_EXEPORT_INVOICE_MASTER_LEDGER_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BRANCH_ID CHAR(4) NULL,";
                    strSQL = strSQL + "CLEARANCE_OF VARCHAR(60) NULL,";
                    strSQL = strSQL + "CONSIGNMENT_VALUE NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BILL_OF_ENTRY VARCHAR(60) NULL,";
                    strSQL = strSQL + "BILL_DATE  DATETIME  NULL,";
                    strSQL = strSQL + "LC_NO VARCHAR(60) NULL,";
                    strSQL = strSQL + "DELIVERY_DATE  DATETIME NULL,";
                    strSQL = strSQL + "AWP_NO VARCHAR(60) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "VOUCHER_NET_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PURPOSE_OF_ADDLESS VARCHAR(60) NULL,";
                    strSQL = strSQL + "ADD_LESS_AMOUNT VARCHAR(20) NULL,";
                    strSQL = strSQL + "NET_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "NARRATION VARCHAR(100) NULL,";
                    strSQL = strSQL + "ENCLOSED VARCHAR(300) NULL,";
                    strSQL = strSQL + "IMPORT_EXPORT_STATUS smallint DEFAULT 0 NOT NULL,";//    '0-IMPORT 1=EXPORT
                    strSQL = strSQL + "INSERT_DATE DATETIME DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE ACC_IMPORT_EXEPORT_INVOICE_TRAN(";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) CONSTRAINT FK_ACC_IMPORT_EXEPORT_INVOICE_TRAN_COMP_REF_NO REFERENCES ACC_IMPORT_EXEPORT_INVOICE_MASTER(COMP_REF_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "SERVICE_EXEPENSES VARCHAR(60),";
                    strSQL = strSQL + "E_DESCRIPTION VARCHAR(60) NULL,";
                    strSQL = strSQL + "VOUCHER_NET_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CLOSING_BALANACE_UPT0 NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BALANCE NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE DATETIME DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
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
        private static string CreateNewConfig()
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
                    strSQL = "CREATE TABLE ACC_NEW_CONFIG(";
                    strSQL = strSQL + "DR_CR SMALLINT DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ",PDC_SCHEDULE_DASH_BORD SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "COMPARE_ACC_REPORTS smallint default 0 NOT NULL,";
                    strSQL = strSQL + "INTEGREATED_SALES_PRICE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "SI_CHALLAN_DETAILAS smallint default 0 NOT NULL,";
                    strSQL = strSQL + "ACC_MONEY_RECEIPT SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BLOCK_CR_CASH SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ITEM_BANGLA SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ITEM_SERIAL SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CREDIT_LIMIT_LOCKED smallint default 0 not null ";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO ACC_NEW_CONFIG(DR_CR) VALUES (0)";
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
        private static string CreateComputerReg()
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
                    strSQL = "CREATE TABLE JAG_REG(IP_ADDRESS VARCHAR (20) NOT NULL";
                    strSQL = strSQL + ",USER_MODE VARCHAR(4) NOT NULL";
                    strSQL = strSQL + ",USER_KEY VARCHAR(29)  NULL";
                    strSQL = strSQL + ",REG_NO VARCHAR(29)  NULL,";
                    strSQL = strSQL + "HDD_SL_N0 VARCHAR(100) NULL,";
                    strSQL = strSQL + "HDD_MODEL_NO VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateMRMaster()
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
                    strSQL = "CREATE TABLE SMA_MR_AUTO(";
                    strSQL = strSQL + "MR_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "MR_REF_NO_KEY  VARCHAR(153) CONSTRAINT PK_SMA_MR_AUTO_MR_REF_NO_KEY PRIMARY KEY NOT NULL,";
                    //''Book No+LedgerName+Chequeno
                    strSQL = strSQL + "BOOK_NO VARCHAR(30) NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_SMA_MR_AUTO_LEDGER_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "MR_NO varchar (60) NOT NULL ,";
                    strSQL = strSQL + "ENTRY_DATE datetime NOT NULL,";
                    strSQL = strSQL + "MR_STATUS smallint default 0 NOT NULL,";
                    //''0= ACTIVEI=INACTIVE
                    strSQL = strSQL + "MODULE_TYPE smallint default 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE SMA_FC_CONFIG_MASTER(";
                    strSQL = strSQL + "FC_UNIQUE_KEY_MASTER VARCHAR (8) NOT NULL CONSTRAINT PK_PRIMARY_KEY_FC_UNIQUE_KEY_MASTER PRIMARY KEY,";
                    strSQL = strSQL + "EFFECTIVE_DATE DateTime Not NULL ,";
                    strSQL = strSQL + "OPTION_TYPE smallint default 0 not null";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE SMA_FC_CONFIG(";
                    strSQL = strSQL + "FC_UNIQUE_KEY VARCHAR (68) NOT NULL CONSTRAINT PK_PRIMARY_KEY PRIMARY KEY,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_SMA_FC_CONFIG_LEDGER_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "EFFECTIVE_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "FC_UNIQUE_KEY_MASTER varchar(8) NOT NULL CONSTRAINT FK_FC_UNIQUE_KEY_MASTER REFERENCES SMA_FC_CONFIG_MASTER(FC_UNIQUE_KEY_MASTER) ON UPDATE CASCADE,";
                    strSQL = strSQL + "FROM_QTY NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CURRENCY_SYMBOL varchar(5) NOT NULL CONSTRAINT FK_SMA_FC_CONFIG_CUR_SYMBOL REFERENCES ACC_CURRENCY(CURRENCY_SYMBOL) ON UPDATE CASCADE,";
                    strSQL = strSQL + "CURRENCY_RATE NUMERIC(18,4) DEFAULT 0 NOT NULL";
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
        private static string CreatePDCAutoChequeMaster()
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
                    strSQL = " CREATE TABLE SMA_PDC_CHEQUE(";
                    strSQL = strSQL + "CHEQUE_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "CHEQUE_REF_NO_KEY  VARCHAR(153) CONSTRAINT PK_SMA_PDC_CHEQUE_CHEQUE_REF_NO_KEY PRIMARY KEY NOT NULL,";
                    // ''Book No+LedgerName+Chequeno
                    strSQL = strSQL + "BOOK_NO VARCHAR(30) NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_SMA_PDC_CHEQUE_LEDGER_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "CHEQUE_NO varchar (60) NOT NULL ,";
                    strSQL = strSQL + "ENTRY_DATE datetime NOT NULL,";
                    strSQL = strSQL + "CHEQUE_STATUS smallint default 0 NOT NULL,";
                    strSQL = strSQL + "MODULE_STATUS smallint default 0 NOT NULL,";
                    //''0= ACTIVEI=INACTIVE
                    strSQL = strSQL + "MODULE_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateDebtorStatement()
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
                    strSQL = "CREATE TABLE ACC_DEBTOR_STATEMENT(";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR (60) NULL,";
                    strSQL = strSQL + "OPENING_BALANCE NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "SALES_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ADJUSTMENT_DEBIT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "COLLECTION NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "RETURN_AMT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ADJUSTMENT_CREDIT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ADJUSTMENT_PRICE_DEDUCTION NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ADJUSTMENT_WARRENTY NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ADJUSTMENT_OTHERS NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateChequePrint()
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
                strSQL = "CREATE TABLE JAG_CHEQUE_PRINT(";
                strSQL = strSQL + "LEDGER_NAME VARCHAR (60) NULL,";
                strSQL = strSQL + "CHEQUE_NO VARCHAR (60) NULL,";
                strSQL = strSQL + "BOOK_NO VARCHAR (30) NULL,";
                strSQL = strSQL + "CHEQUE_STATUS SMALLINT DEFAULT 0 NOT NULL, ";
                strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                strSQL = strSQL + ")";
                SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateVoucherType()
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
                    strSQL = "CREATE TABLE ACC_VOUCHER_TYPE(";
                    strSQL = strSQL + "VOUCHER_TYPE_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_VOUCHER_TYPE PRIMARY KEY,";
                    strSQL = strSQL + "VOUCHER_TYPE_VALUE smallint default 0 NOT NULL,";//   '0 = No, 1 = Yes
                    strSQL = strSQL + "VOUCHER_TYPE_NAME varchar(50) NOT NULL,";
                    strSQL = strSQL + "VOUCHER_TYPE_NUMBERING_METHOD smallint default 0 NOT NULL,";//    '0 = Automatic, 1 = Manual
                    strSQL = strSQL + "VOUCHER_TYPE_BEGINING_NUMBER numeric(18,2) default 1 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_TYPE_NUMERIC_WIDTH numeric(18) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_TYPE_PREFIX varchar(20) NULL,";
                    strSQL = strSQL + "VOUCHER_TYPE_SUFFIX varchar(20) NULL,";
                    strSQL = strSQL + "VOUCHER_TYPE_PRINTAFTERSAVE smallint default 0 NOT NULL,";//    '0 = No, 1 = Yes
                    strSQL = strSQL + "VOUCHER_TYPE_ALT_UNIT smallint default 0 NOT NULL,";//    '0 = No, 1 = Yes
                    strSQL = strSQL + "VOUCHER_TYPE_TOTAL_VOUCHER numeric(18,0) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_TYPE_CANCEL_VOUCHER numeric(18,0) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_TYPE_AUTO_CHEQUE smallint default 2 NOT NULL,";//   '2 = No, 1 = Yes
                    strSQL = strSQL + "VOUCHER_TYPE_AUTO_MR_NO smallint default 2 NOT NULL,";//    '2 = No, 1 = Yes
                    strSQL = strSQL + "VOUCHER_TYPE_SINGLE_NARRATION varchar(200) NULL,";
                    strSQL = strSQL + "VOUCHER_CHEQUE_BANK varchar(50)  NULL,";
                    strSQL = strSQL + "VOUCHER_CHEQUE_BOOK varchar(50)  NULL,";
                    strSQL = strSQL + "VOUCHER_AUTO_MR_BANK varchar(50)  NULL,";
                    strSQL = strSQL + "VOUCHER_AUTO_MR_BOOK varchar(50)  NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        
        private static string CreateVoucherDocument()
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
                    strSQL = "CREATE TABLE ACC_VOUCHER_DOCUMENT(";
                    strSQL = strSQL + "ATTATCHMENT_KEY VARCHAR(300) CONSTRAINT PK_ACC_VOUCHER_DOCUMENT_ATTATCHMENT_KEY PRIMARY KEY,";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) CONSTRAINT FK_ACC_VOUCHER_DOCUMENT_VOUCHER_NO_COMP_REF_NO REFERENCES ACC_COMPANY_VOUCHER(COMP_REF_NO) NOT NULL,";//    'COMP_REF_NO
                    strSQL = strSQL + "ATTATCHMENT_FILE image NULL,";
                    strSQL = strSQL + "ATTATCHMENT_DOC VARCHAR(100) NULL ";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateStudentForm()
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
                    strSQL = "CREATE Table SMA_STUDENT_FORM(";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_SMA_STUDENT_FORM_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STUDENT_ID VARCHAR(15) NOT NULL CONSTRAINT PK_STUDENT_ID PRIMARY KEY,";
                    strSQL = strSQL + "SESSION_NAME VARCHAR (30) NULL,";
                    strSQL = strSQL + "SMA_YEAR VARCHAR (5) NULL,";
                    strSQL = strSQL + "CLASS_ROLL_NO VARCHAR (20) NULL,";
                    strSQL = strSQL + "CLASS_NAME VARCHAR (50) NULL,";
                    strSQL = strSQL + "SECTION_NAME VARCHAR (50) NULL,";
                    strSQL = strSQL + "FATHERS_NAME VARCHAR (60) NULL,";
                    strSQL = strSQL + "MOTHRS_NAME VARCHAR (60) NULL,";
                    strSQL = strSQL + "FATHES_PROFESSION VARCHAR (60) NULL,";
                    strSQL = strSQL + "NATIONAL_ID_CARD VARCHAR (15) NULL,";
                    strSQL = strSQL + "CONTACT_NO_HOME VARCHAR (30) NULL,";
                    strSQL = strSQL + "MOBILE_NO VARCHAR (30) NULL,";
                    strSQL = strSQL + "OTHERS_INFORMATION VARCHAR (200) NULL,";
                    strSQL = strSQL + "PRESENT_ADDRESS VARCHAR (200) NULL,";
                    strSQL = strSQL + "PERMANENT_ADDRESS VARCHAR (200)  NULL ,";
                    strSQL = strSQL + "SSC_ROLL_NO VARCHAR (50) NULL,";
                    strSQL = strSQL + "SSC_REG_NO VARCHAR (50) NULL,";
                    strSQL = strSQL + "SSC_SESSION VARCHAR (30) NULL,";
                    strSQL = strSQL + "SSC_YEAR VARCHAR (5) NULL,";
                    strSQL = strSQL + "SSC_GPA VARCHAR (10) NULL,";
                    strSQL = strSQL + "SSC_GRADE VARCHAR (4) NULL,";
                    strSQL = strSQL + "SSC_INSTITUTE VARCHAR (100) NULL,";
                    strSQL = strSQL + "HSC_ROLL_NO VARCHAR (50) NULL,";
                    strSQL = strSQL + "HSC_REG_NO VARCHAR (50) NULL,";
                    strSQL = strSQL + "HSC_SESSION VARCHAR (30) NULL,";
                    strSQL = strSQL + "HSC_YEAR VARCHAR (5) NULL,";
                    strSQL = strSQL + "HSC_GPA VARCHAR (10) NULL,";
                    strSQL = strSQL + "HSC_GRADE VARCHAR (4) NULL,";
                    strSQL = strSQL + "HSC_INSTITUTE VARCHAR (100) NULL,";
                    strSQL = strSQL + "STU_CONCESSION NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "STU_TRANSCRIPT_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "STU_TRANSCRIPT_STATUS VARCHAR(30) NULL,";
                    strSQL = strSQL + "DEGREE_ROOL_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "DEGREE_REG_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "DEGREE_YEAR VARCHAR(4) NULL,";
                    strSQL = strSQL + "DEGREE_GRADE VARCHAR(30) NULL,";
                    strSQL = strSQL + "DEGREE_SESSION VARCHAR(30) NULL,";
                    strSQL = strSQL + "DEGREE_GPA VARCHAR(30) NULL,";
                    strSQL = strSQL + "DEGREE_INSTITUTE VARCHAR(100) NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                 
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    
                    strSQL = "CREATE TABLE SMA_STUDENT_IMAGE(";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_SMA_STUDENT_IMAGE_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STUDENT_IMAGE image NULL";
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
        private static string CreateBillWiseTemp()
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
                   strSQL = "CREATE TABLE SMA_ACC_BILL_WISE_APPR(";
                    strSQL = strSQL + "BILL_WISE_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_SMA_ACC_BILL_WISE_TEMP PRIMARY KEY,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_SMA_ACC_BILL_WISE_TEMP_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";;
                    strSQL = strSQL + "VOUCHER_REF_KEY varchar (50) NOT NULL,";
                    strSQL = strSQL + "AGAINST_VOUCHER_NO varchar(50) NOT NULL,";
                    strSQL = strSQL + "COMP_REF_NO varchar(60) NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE smallint NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NULL,";
                    strSQL = strSQL + "VOUCHER_ROW_POSITION smallint default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_WISE_POSITION smallint default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_WISE_PREV_NEW smallint default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_SMA_ACC_BILL_WISE_TEMP_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BILL_WISE_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_WISE_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_WISE_TOBY char(2) NOT NULL,";
                    strSQL = strSQL + "BILL_WISE_IS_OPEN smallint default 0 NOT NULL,";
                    strSQL = strSQL + "OPENING_DATE datetime NULL,";
                    strSQL = strSQL + "BILL_WISE_DUE_DATE datetime DEFAULT GETDATE() NULL,";
                    strSQL = strSQL + "COMISSION numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INTEREST numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateVectorTransactionTemp()
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
                    strSQL = "CREATE TABLE SMA_VECTOR_TRANSACTION_APPR(";
                    strSQL = strSQL + "VT_TRAN_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_SMA_VECTOR_TRANSACTION_APPR PRIMARY KEY,";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) CONSTRAINT FK_SMA_VECTOR_TRANSACTION_APPR_REF_NO REFERENCES SMA_ACC_COMPANY_VOUCHER_APPR(COMP_REF_NO),";//    'COMP_REF_NO
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_SMA_VECTOR_TRANSACTION_APPR_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "VT_TRAN_DATE datetime NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_POSITION smallint default 0 NOT NULL,";//    'position of the company voucher
                    strSQL = strSQL + "VT_POSITION smallint default 0 NOT NULL,";//    'position of this entry in this vch
                    strSQL = strSQL + "VT_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "VMASTER_NAME varchar (60) NULL CONSTRAINT FK_SMA_VECTOR_TRANSACTION_APPR_VMASTER REFERENCES VECTOR_MASTER(VMASTER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_SMA_VECTOR_TRANSACTION_APPR_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "VCATEGORY_NAME varchar(60) NULL ,";
                    strSQL = strSQL + "VT_TRAN_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VT_TRAN_TOBY char (2) NOT NULL,";
                    strSQL = strSQL + "VOUCHER_FC_DEBIT_AMOUNT numeric(18,2) default 0 NULL,";
                    strSQL = strSQL + "VOUCHER_FC_CREDIT_AMOUNT numeric(18,2) default 0 NULL,";
                    strSQL = strSQL + "FC_CONVERSION_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VT_CURRENCY_SYMBOL VARCHAR (5) NULL CONSTRAINT FK_SMA_VECTOR_TRANSACTION_APPR_CURRENCY REFERENCES ACC_CURRENCY(CURRENCY_SYMBOL) ON UPDATE CASCADE, ";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateVoucherTemp()
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
                    strSQL = "CREATE TABLE SMA_ACC_VOUCHER_APPR(";
                    strSQL = strSQL + "VOUCHER_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_SMA_ACC_VOUCHER_TEMP PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) CONSTRAINT FK_SMA_ACC_VOUCHER_TEMP_COMP_REF_NO REFERENCES SMA_ACC_COMPANY_VOUCHER_APPR(COMP_REF_NO) NOT NULL,";//    'COMP_REF_NO
                    strSQL = strSQL + "VOUCHER_REF_KEY VARCHAR(50) CONSTRAINT UQ_SMA_ACC_VOUCHER_TEMP UNIQUE NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_SMA_ACC_VOUCHER_TEMP_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_POSITION smallint default 0 NOT NULL,";//    'position of this entry in this vch
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_SMA_ACC_VOUCHER_TEMP_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER VARCHAR(30) NULL,";
                    strSQL = strSQL + "VOUCHER_CHEQUE_DATE datetime NULL,";
                    strSQL = strSQL + "VOUCHER_CHEQUE_DRAWN_ON varchar(60) NULL,";
                    strSQL = strSQL + "VOUCHER_BANK_DATE datetime NULL,"; //   'For Bank Reconsiliation
                    strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_CREDIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_ADD_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_LESS_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_TOBY char (2) NOT NULL,";
                    strSQL = strSQL + "VOUCHER_REVERSE_LEDGER varchar (60) NULL ," ;//   'NOT NULL REFERENCES ACC_LEDGER(LEDGER_NAME),"
                    strSQL = strSQL + "VOUCHER_FC_DEBIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_FC_CREDIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_CURRENCY_SYMBOL varchar (5) NULL CONSTRAINT FK_SMA_ACC_VOUCHER_TEMP_CURRENCY REFERENCES ACC_CURRENCY(CURRENCY_SYMBOL) ON UPDATE CASCADE,";
                    strSQL = strSQL + "VOUCHER_ADD_LESS_SIGN Varchar(30) NULL,";
                    strSQL = strSQL + "FC_CONVERSION_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_CASHFLOW smallint default 0 Null," ;//   '0=No 1=Yes
                    strSQL = strSQL + "AGNST_COMP_REF_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "VOUCHER_NARRATION varchar(300) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        
        private static string CreateCompanyVoucherTemp()
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
                    strSQL = "CREATE TABLE SMA_ACC_COMPANY_VOUCHER_APPR(";
                    strSQL = strSQL + "COMP_VOUCHER_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) CONSTRAINT PK_SMA_ACC_COMPANY_VOUCHER_APP PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_SMA_ACC_COMPANY_VOUCHER_APP_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_SMA_ACC_COMPANY_VOUCHER_APP_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_MONTH_ID VARCHAR(6) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_ADD_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_LESS_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_NET_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_PROCESS_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_BALANCE numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_NARRATION varchar(400) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DESPATCH_TO varchar(30) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_PARTY_NAME varchar(60) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_ADDRESS1 varchar(50) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_ADDRESS2 varchar(50) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_CITY varchar(30) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_TERM_OF_PAYMENTS varchar(20) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DESPATCH_THRU varchar(30) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DESTINATION varchar(30) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_CREDIT_DAYS numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DUE_DATE datetime NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_STATUS smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_FC smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_AGAINST_REF smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_IS_AUTO smallint default 0 NOT NULL,";//    '0 = Manual,1 = Auto
                    strSQL = strSQL + "AGNST_COMP_REF_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "POS_LEDGER varchar(60) NULL,";
                    strSQL = strSQL + "SALES_REP varchar(60) NULL, ";
                    strSQL = strSQL + "COMP_DELIVERY varchar(300) NULL,";
                    strSQL = strSQL + "COMP_TERM_OF_PAYMENTS varchar(300) NULL,";
                    strSQL = strSQL + "COMP_SUPPORT varchar(300) NULL,";
                    strSQL = strSQL + "COMP_VALIDITY_DATE datetime NULL,";
                    strSQL = strSQL + "COMP_OTHERS varchar(300) NULL,";
                    strSQL = strSQL + "COMP_LOGO_NO SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "POST_STATUS smallint default 0 NOT NULL,";
                    //'0 = Unpost 1=Post
                    strSQL = strSQL + "STU_JOUNAL_STATUS SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "STU_JOUNAL_REF_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "CHEQUE_REF_NO_KEY varchar(153) NULL,";
                    strSQL = strSQL + "MR_REF_NO_KEY varchar(153) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";

                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateUpdateLog()
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
                    strSQL = "CREATE TABLE ACC_UPDATE_LOG(";
                    strSQL = strSQL + "UPDATE_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "MASTER_OLD varchar (60) NOT NULL,";
                    strSQL = strSQL + "MASTER_OLD_OPENING numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "MASTER_NEW varchar (60) NOT NULL,";
                    strSQL = strSQL + "MASTER_NEW_OPENING numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "MASTER_TABLE varchar (60) NOT NULL,";
                    strSQL = strSQL + "MASTER_PRIMARY_FIELD varchar (60) NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateDeleteLog()
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
                    strSQL = "CREATE TABLE ACC_DELETE_LOG(";
                    strSQL = strSQL + "DELETE_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4)  NOT NULL,";
                    strSQL = strSQL + "COMP_REF_NO varchar (50) NULL, ";//    'Branch_ID + COMP_REF_NO
                    strSQL = strSQL + "COMP_VOUCHER_TYPE smallint NULL, ";
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateBranchOpening()
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
                    strSQL = "CREATE TABLE ACC_BRANCH_OPENING(";
                    strSQL = strSQL + "BRANCH_OPENING_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_BRANCH_OPENING_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "LEDGER_OPENING_KEY varchar(60) CONSTRAINT PK_ACC_BRANCH_OPENING PRIMARY KEY NOT NULL,";//    'Branch ID + Ledger Name
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_ACC_BRANCH_OPENING_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";//    'Company ID + Ledger Name
                    strSQL = strSQL + "BRANCH_OPENING_BALANCE numeric(18,2) default 0 NOT NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateBillTranPENDING()
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
                    strSQL = "CREATE TABLE ACC_BILL_TRAN_PENDING (";
                    strSQL = strSQL + "BILL_TRAN_KEY varchar (50) CONSTRAINT PK_ACC_BILL_TRAN_PENDING PRIMARY KEY ,";
                    strSQL = strSQL + "BALANCE_QUANTITY float NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateAccStatistics()
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
                    strSQL = "CREATE TABLE ACC_STATISTICS (";
                    strSQL = strSQL + "STATISTICS_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_STATISTICS PRIMARY KEY,";
                    strSQL = strSQL + "STATISTICS_NAME varchar(60),";
                    strSQL = strSQL + "STATISTICS_COUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STATISTICS_TYPE smallint default 0 NOT NULL ";
                    //  ' 1 = Accounts, 0 = Vouchers
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateInterest()
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
                    strSQL = "CREATE TABLE ACC_INTEREST(";
                    strSQL = strSQL + "INTEREST_NO numeric(10,0) IDENTITY(1,1) CONSTRAINT PK_ACC_INTEREST PRIMARY KEY,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL, ";
                    strSQL = strSQL + "BRANCH_ID CHAR(4) NULL,";
                    strSQL = strSQL + "AMOUNT numeric (18,2) default 0 NOT NULL ,";
                    strSQL = strSQL + "BALANCE numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "FROM_DATE datetime ,";
                    strSQL = strSQL + "TO_DATE datetime ,";
                    strSQL = strSQL + "TOTAL_DAYS INT default 0 NOT NULL,";
                    strSQL = strSQL + "RATE numeric(18,2) NOT NULL,";
                    strSQL = strSQL + "INTEREST numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateLedgerInterestDetails()
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
                    strSQL = "CREATE TABLE ACC_LEDGER_INTEREST_DETAILS (";
                    strSQL = strSQL + "INTEREST_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_LEDGER_INTEREST_DETAILS PRIMARY KEY,";
                    strSQL = strSQL + "INTEREST_MASTER_KEY varchar(80) NOT NULL CONSTRAINT FK_ACC_LEDGER_INTEREST_DETAILS_MASTER REFERENCES ACC_LEDGER_INTEREST_MASTER(INTEREST_MASTER_KEY) ON UPDATE CASCADE,";
                    strSQL = strSQL + "INTEREST_RATE numeric(18,2) NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID CHAR(4) NULL,";
                    strSQL = strSQL + "INTEREST_PER smallint default 0 NOT NULL,";
                    //' 1 = 30-Day Month,2 = 365 Day Year,3 = Calender Month, 4 = Calender Year
                    strSQL = strSQL + "INTEREST_ON smallint default 0 NOT NULL,";
                    //' 1 = All Balances, 2 = Credit Balances , 3 = Debit Balances
                    strSQL = strSQL + "INTEREST_FROM_DATE datetime NOT NULL,";
                    strSQL = strSQL + "INTEREST_TO_DATE datetime NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateLedgerInterestMaster()
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
                    strSQL = "CREATE TABLE ACC_LEDGER_INTEREST_MASTER(";
                    strSQL = strSQL + "INTEREST_MASTER_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "INTEREST_MASTER_KEY varchar(80) CONSTRAINT PK_ACC_LEDGER_INTEREST_MASTER PRIMARY KEY,";//    'COMPANY ID + LEDGER_NAME + Date
                    strSQL = strSQL + "INTEREST_CREATE_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID CHAR(4) NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) CONSTRAINT FK_ACC_LEDGER_INTEREST_MASTER_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE, ";
                    strSQL = strSQL + "PRINCIPAL_AMOUNT numeric(18,2) default 0, ";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateAddLess()
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
                    strSQL = "CREATE TABLE ACC_ADD_LESS( ";
                    strSQL = strSQL + "ADD_LESS_SERIAL [numeric](18, 0) IDENTITY (1, 1) CONSTRAINT PK_ACC_ADD_LESS PRIMARY KEY,";
                    strSQL = strSQL + "ADD_LESS_LEDGER [varchar] (60) NULL CONSTRAINT FK_ACC_ADD_LESS_LEDGER_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE ,";
                    strSQL = strSQL + "ADD_LESS_COMP_REF_NO [varchar] (30)  NULL , ";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_ADD_LESS_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "ADD_LESS_DATE [datetime] NULL , ";
                    strSQL = strSQL + "ADD_LESS_ADD_AMOUNT [numeric](9, 2) NULL ,";
                    strSQL = strSQL + "ADD_LESS_LESS_AMOUNT [numeric](9, 2) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";
                    strSQL = strSQL + ") ";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateBillWise()
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
                    strSQL = "CREATE TABLE ACC_BILL_WISE(";
                    strSQL = strSQL + "BILL_WISE_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_BILL_WISE PRIMARY KEY,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_BILL_WISE_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "VOUCHER_REF_KEY varchar (50) NOT NULL,";
                    strSQL = strSQL + "AGAINST_VOUCHER_NO varchar(50) NOT NULL,";
                    strSQL = strSQL + "COMP_REF_NO varchar(60) NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE smallint NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NULL,";
                    strSQL = strSQL + "VOUCHER_ROW_POSITION smallint default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_WISE_POSITION smallint default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_WISE_PREV_NEW smallint default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_ACC_BILL_WISE_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BILL_WISE_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_WISE_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_WISE_TOBY char(2) NOT NULL,";
                    strSQL = strSQL + "BILL_WISE_IS_OPEN smallint default 0 NOT NULL,";
                    strSQL = strSQL + "OPENING_DATE datetime NULL,";
                    strSQL = strSQL + "BILL_WISE_DUE_DATE datetime DEFAULT GETDATE() NULL,";
                    strSQL = strSQL + "COMISSION numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INTEREST numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ") ";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateQuatationMaster()
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
                    strSQL = "CREATE TABLE ACC_QUOTATION_MASTER(";
                    strSQL = strSQL + "QUOTE_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "QUOTE_REF_NO VARCHAR(30) CONSTRAINT PK_ACC_QUOTATION_MASTER PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "PARTY_NAME varchar(60) NOT NULL,";
                    strSQL = strSQL + "QUOTE_ADDRESS1 varchar(200) NULL,";
                    strSQL = strSQL + "QUOTE_ADDRESS2 varchar(200) NULL,";
                    strSQL = strSQL + "ATTENTION varchar(50) NULL,";
                    strSQL = strSQL + "DESIGNATION varchar(50) NULL,";
                    strSQL = strSQL + "QUOTE_DATE datetime NOT NULL,";
                    strSQL = strSQL + "QUOTE_DELIVERY varchar(300) NULL,";
                    strSQL = strSQL + "QUOTE_TERM_OF_PAYMENTS varchar(300) NULL,";
                    strSQL = strSQL + "QUOTE_SUPPORT varchar(300) NULL,";
                    strSQL = strSQL + "QUOTE_VALIDITY_DATE datetime NULL,";
                    strSQL = strSQL + "QUOTE_OTHERS varchar(300) NULL,";
                    strSQL = strSQL + "QUOTE_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";

                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateVoucherConfig()
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
                    strSQL = "CREATE TABLE ACC_VOUCHER_CONFIG( ";
                    strSQL = strSQL + "VOUCHER_CONFIG_NO numeric(15,0) IDENTITY(1,1) CONSTRAINT PK_VOUCHER_CONFIG_NO PRIMARY KEY,";
                    strSQL = strSQL + "VOUCHER_HEADER1 varchar(50) NULL, ";
                    strSQL = strSQL + "VOUCHER_HEADER2 varchar(50) NULL, ";
                    strSQL = strSQL + "VOUCHER_HEADER3 varchar(50) NULL, ";
                    strSQL = strSQL + "VOUCHER_HEADER4 varchar(50) NULL, ";
                    strSQL = strSQL + "VOUCHER_HEADER5 varchar(50) NULL,";
                    strSQL = strSQL + "VOUCHER_TYPE_VALUE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "PRINT_MINIMIZE smallint default 0 NOT NULL ";//    '0 = Full Page, 1 = Half Page
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateInvoiceConfig()
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
                    strSQL = "CREATE TABLE ACC_INVOICE_CONFIG( ";
                    strSQL = strSQL + "INVOICE_CONFIG_NO numeric(15,0) IDENTITY(1,1) CONSTRAINT PK_ACC_INVOICE_CONFIG PRIMARY KEY,";
                    strSQL = strSQL + "SALES_INVOICE_DECLARE varchar(300) NULL, ";
                    strSQL = strSQL + "PURCHASE_INVOICE_DECLARE varchar(200) NULL ,";
                    strSQL = strSQL + "SALES_ORDER_HEADER varchar(300) NULL, ";
                    strSQL = strSQL + "SALES_ORDER_FOOTER varchar(300) NULL ,";
                    strSQL = strSQL + "PURCHASE_ORDER_HEADER varchar(300) NULL, ";
                    strSQL = strSQL + "PURCHASE_ORDER_FOOTER varchar(300) NULL ,";
                    strSQL = strSQL + "SALES_INVOICE_REPORT smallint default 1 NOT NULL,";//    ' 1 = DETAILS REPORT , 2 = SHORT REPORT
                    strSQL = strSQL + "PURCHASE_INVOICE_REPORT smallint default 1 NOT NULL,";//    ' 1 = DETAILS REPORT , 2 = SHORT REPORT
                    strSQL = strSQL + "SALES_INVOICE_ITEM_DESCRIPTION smallint default 0 NOT NULL,";//    ' 1 = YES , 2 = NO
                    strSQL = strSQL + "PURCHASE_INVOICE_ITEM_DESCRIPTION smallint default 0 NOT NULL,";//    ' 1 = YES , 2 = NO
                    strSQL = strSQL + "SALES_DISCOUNT_ALLOWED smallint default 1 NOT NULL," ;//   ' 1 = Not Allowed , 2 = Allowed
                    strSQL = strSQL + "PURCHASE_DISCOUNT_ALLOWED smallint default 1 NOT NULL,";//    ' 1 = Not Allowed , 2 = Allowed
                    strSQL = strSQL + "SALES_DISCOUNT_ON smallint default 1 NOT NULL," ;//   ' 1 = TOTAL AMOUNT , 2 = RATE
                    strSQL = strSQL + "PURCHASE_DISCOUNT_ON smallint default 1 NOT NULL," ;//   ' 1 = TOTAL AMOUNT , 2 = RATE
                    strSQL = strSQL + "PRINT_QTY_COL smallint default 1 NOT NULL,";//    ' 1 =Print Yes, 0 = No Print
                    strSQL = strSQL + "PRINT_CURRENT_BALANCE smallint default 0 NOT NULL,";//    ' 1 =Print Yes, 0 = No Print
                    strSQL = strSQL + "PRINT_MINI_COL smallint default 0 NOT NULL,";
                    strSQL = strSQL + "PRINT_MINI_COL_PURCHASE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "PRINT_DECLARE_COL smallint default 0 NOT NULL,";
                    strSQL = strSQL + "PRINT_NARRATION_COL smallint default 0 NOT NULL,";
                    strSQL = strSQL + "PRINT_REPORT_FOOTER smallint default 0 NOT NULL,";
                    strSQL = strSQL + "PRINT_ITEM_DESCRIPTION smallint default 0 NOT NULL,";//    ' 1 =Print Yes, 0 = No Print
                    strSQL = strSQL + "REPORT_FOOTER_DESC VARCHAR(300) NULL,";
                    strSQL = strSQL + "PRINT_ITEM_SORT_ORDER smallint default 0 NOT NULL,";
                    strSQL = strSQL + "ALLOW_SEPARATE_PARTY_NAME smallint default 0 NOT NULL,";//    ' 0 = NO , 1 = YES
                    strSQL = strSQL + "BLOCK_NEGATIVE_STOCK smallint default 0 NOT NULL,";
                    strSQL = strSQL + "CALC_ADDL_ON_SUB_TOTAL smallint default 0 NOT NULL,";
                    strSQL = strSQL + "MORE_FOOTER smallint default 0 NOT NULL,";
                    strSQL = strSQL + "SALES_MIN_PRICE SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "SALES_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "SALES_QTY_INWORD SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "SALES_AMOUNT_INWORD SMALLINT DEFAULT 1 NOT NULL,";
                    strSQL = strSQL + "MR_HALF smallint default 0 NOT NULL,";
                    strSQL = strSQL + "ITEM_IMAGE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "HIDE_COMPANY_NAME smallint default 0 NOT NULL,";
                    strSQL = strSQL + "AUTO_CHEQUE_NO smallint default 2 NOT NULL,";
                    strSQL = strSQL + "AUTO_MR_NO  smallint default 2 NOT NULL,";
                    strSQL = strSQL + "BACK_LOCK_POSTING SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BACK_LOCK_DATE DATETIME NULL,";
                    strSQL = strSQL + "HIDE_INITIAL_COMPANY_NAME smallint default 0 NOT NULL,";
                    strSQL = strSQL + "INTEREST_CAL smallint default 0 NOT NULL,";
                    strSQL = strSQL + "GRARNTEE_CARD smallint default 0 NOT NULL,";
                    strSQL = strSQL + "ATTN_PAYROLL smallint default 0 NOT NULL ";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreatePriceLevel()
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
                    strSQL = "CREATE TABLE ACC_PRICE_LEVEL(";
                    strSQL = strSQL + "PRICE_LEVEL_NAME varchar(60) CONSTRAINT PK_ACC_PRICE_LEVEL PRIMARY KEY,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
private static string CreateVectorMasterChild()
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
                    strSQL = "CREATE TABLE VECTOR_MASTER_CHILD(";
                    strSQL = strSQL + "VCHILD_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_VECTOR_MASTER_CHILD PRIMARY KEY,";
                    strSQL = strSQL + "VMASTER_NAME varchar(60) NULL CONSTRAINT FK_VMAS_MAS_VECTOR_MASTER_CHILD_VMASTER_NAME REFERENCES VECTOR_MASTER(VMASTER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "VECTOR_CATEGORY_NAME varchar(60) NULL,";
                    strSQL = strSQL + "VCHILD_OPENING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VCHILD_CLOSING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_VECTOR_MASTER_CHILD_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "MASTER_LEDGER_NAME varchar(60) NULL CONSTRAINT FK_ACC_LEDGER_VECTOR_MASTER_CHILD_M_LEDGER_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "VECTOR_TO_BY varchar(2) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateVectorTransaction()
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
                    strSQL = "CREATE TABLE VECTOR_TRANSACTION(";
                    strSQL = strSQL + "VT_TRAN_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_VECTOR_TRANSACTION PRIMARY KEY,";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) CONSTRAINT FK_VECTOR_TRANSACTION_REF_NO REFERENCES ACC_COMPANY_VOUCHER(COMP_REF_NO),";//    'COMP_REF_NO
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_VECTOR_TRANSACTION_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "VT_TRAN_DATE datetime NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_POSITION smallint default 0 NOT NULL,";//    'position of the company voucher
                    strSQL = strSQL + "VT_POSITION smallint default 0 NOT NULL,";//    'position of this entry in this vch
                    strSQL = strSQL + "VT_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "VMASTER_NAME varchar (60) NULL CONSTRAINT FK_VECTOR_TRANSACTION_VMASTER REFERENCES VECTOR_MASTER(VMASTER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_VECTOR_TRANSACTION_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "VCATEGORY_NAME varchar(60) NULL ,";
                    //strSQL = strSQL + "VGROUP_NAME varchar(60) NOT NULL ,";
                    strSQL = strSQL + "VT_TRAN_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VT_TRAN_TOBY char (2) NOT NULL,";
                    strSQL = strSQL + "VOUCHER_FC_DEBIT_AMOUNT numeric(18,2) default 0 NULL,";
                    strSQL = strSQL + "VOUCHER_FC_CREDIT_AMOUNT numeric(18,2) default 0 NULL,";
                    strSQL = strSQL + "FC_CONVERSION_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VT_CURRENCY_SYMBOL VARCHAR (5) NULL CONSTRAINT FK_VECTOR_TRANSACTION_CURRENCY REFERENCES ACC_CURRENCY(CURRENCY_SYMBOL) ON UPDATE CASCADE, ";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        
        private static string CreateBudgetDetail()
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
                    strSQL = "CREATE TABLE ACC_BUDGET_DETAIL(";
                    strSQL = strSQL + "BUDGET_DETAILS_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_BUDGET_DETAIL PRIMARY KEY,";
                    strSQL = strSQL + "BUDGET_KEY varchar (68) NOT NULL CONSTRAINT FK_ACC_BUDGET_DETAIL_KEY REFERENCES ACC_BUDGET_MASTER(BUDGET_KEY)," ;//   'Branch ID,Year(4),Month(2),Ledger_Name
                    strSQL = strSQL + "BUDGET_KEY_REF varchar (58) NOT NULL ,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_BUDGET_DETAIL_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "BRANCH_NAME varchar (60) NOT NULL ,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_ACC_BUDGET_DETAIL_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BUDGET_FROM_DATE datetime NOT NULL,";
                    strSQL = strSQL + "BUDGET_TO_DATE datetime NOT NULL,";
                    strSQL = strSQL + "BUDGET_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";

                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateBudgetMaster()
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
                    strSQL = "CREATE TABLE ACC_BUDGET_MASTER(";
                    strSQL = strSQL + "BUDGET_MASTER_SERIAL numeric (18,0) IDENTITY (1,1) ,";
                    strSQL = strSQL + "BUDGET_KEY varchar (68) CONSTRAINT PK_ACC_BUDGET_MASTER PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
          
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateBranchLedgerConfig()
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
                    strSQL = "CREATE TABLE ACC_BRANCH_LEDGER_CONFIG(";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_ACC_BRANCH_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_BRANCH_LEDGER_B_ID REFERENCES ACC_BRANCH(BRANCH_ID)";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateUtility()
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
                    strSQL = "CREATE TABLE UTILITY(";
                    strSQL = strSQL + "VERSION_NUMBER numeric (20) NOT NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateFixedAssetAdjustment()
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
                    strSQL = "CREATE TABLE ACC_FIXED_ASSET_ADJUSTMENT_DEP(";
                    strSQL = strSQL + "ADJUSTMENT_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "ADJUSTMENT_REF_NO VARCHAR(30) CONSTRAINT PK_ACC_FIXED_ASSET_ADJUSTMENT_DEP PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_FIXED_ASSET_ADJUSTMENT_DEP_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_ACC_FIXED_ASSET_ADJUSTMENT_DEP_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "ADJUSTMENT_DATE datetime NOT NULL,";
                    strSQL = strSQL + "ADJUSTMENT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateFixedAsset()
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
                    strSQL = "CREATE TABLE ACC_FIXED_ASSETS(";
                    strSQL = strSQL + "ASSET_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_FIXED_ASSETS PRIMARY KEY,";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_ACC_FIXED_ASSETS_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "ASSET_PURCHASE_COST numeric(18,2) default 0 NOT NULL," ;//   'Purchase Cost
                    strSQL = strSQL + "ASSET_DEP_EFF_DATE datetime NOT NULL," ;//   'Depriciation Effective Form
                    strSQL = strSQL + "ASSET_DEP_METHOD smallint default 0 NOT NULL,"; //   ' 1 = Reducing Balance , 2 = Straight Line
                    strSQL = strSQL + "ASSET_LIFE numeric(18,2) default 0 NOT NULL," ;//   'Depriciation Rate
                    strSQL = strSQL + "ASSET_DEP_RATE numeric(18,2) default 0 NOT NULL,";//    'Depriciation Rate
                    strSQL = strSQL + "ASSET_ACCU_DEP numeric(18,2) default 0 NOT NULL," ;//   'Accumulated Depriciation
                    strSQL = strSQL + "ASSET_WRITTEN_VALUE numeric(18,2) default 0 NOT NULL,";//    'Written Down Value
                    strSQL = strSQL + "ASSET_SALVAGE_VALUE numeric(18,2) default 0 NOT NULL,";//    'Salvage Value
                    strSQL = strSQL + "ASSET_PERCENT smallint default 0 NOT NULL," ;//   'Straight Line Method 0 = Years, 1 = Percent
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateSalesPriceReport()
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
                    strSQL =  "CREATE TABLE INV_SALES_PRICE_RPT ( ";
                    strSQL = strSQL + "STOCKITEM_NAME varchar (60) NULL, ";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar (50)  NULL , ";
                    strSQL = strSQL + "STOCKITEM_PRIMARY_GROUP varchar (50)  NULL , ";
                    strSQL = strSQL + "STOCKITEM_BASEUNITS varchar (50)  NULL , ";
                    strSQL = strSQL + "SALES_PRICE_AMOUNT numeric(18,2) DEFAULT 0 NOT NULL, ";
                    strSQL = strSQL + "SALES_PRICE_EFFECTIVE_DATE [datetime] NULL, ";
                    strSQL = strSQL + "FROM_QTY numeric(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "TO_QTY numeric(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PRICE_LEVEL_NAME varchar(60) NULL,";
                    strSQL = strSQL + "ACTUAL_DISCOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "PERCENT_DISCOUNT varchar(6) NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ") ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE INV_STOCK_VALUATION_TEMP(";
                    strSQL = strSQL + "STOCKITEM_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "INV_TRAN_QUANTITY NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_TRAN_AMOUNT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_TRAN_LAST_PURCHASE_PRICE NUMERIC(18,4) DEFAULT 0 NOT NULL";
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
        private static string CreateSysAudit()
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
                    strSQL = "CREATE TABLE SYS_AUDIT(";
                    strSQL = strSQL + "AUDIT_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_SYS_AUDIT PRIMARY KEY,";
                    strSQL = strSQL + "AUDIT_DATE datetime NOT NULL,";
                    strSQL = strSQL + "AUDIT_TYPE VARCHAR (50)  NULL,";
                    strSQL = strSQL + "AUDIT_NO varchar (50) NOT NULL,";
                    strSQL = strSQL + "CHANGE_NO  varchar (50) NULL,";
                    strSQL = strSQL + "AUDIT_ADD_DATE datetime NOT NULL,";
                    strSQL = strSQL + "USER_LOGIN_NAME VARCHAR (30) NOT NULL CONSTRAINT FK_SYS_AUDIT_LOGIN_NAME REFERENCES USER_CONFIG(USER_LOGIN_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "AUDIT_TXN smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AUDIT_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL,";
                    strSQL = strSQL + "MODULE_TYPE smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";

                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateStockInHand()
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
                    strSQL = "CREATE TABLE ACC_STOCK_IN_HAND(";
                    strSQL = strSQL + "STOCK_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_STOCK_IN_HAND PRIMARY KEY,";
                    strSQL = strSQL + "CLOSING_KEY VARCHAR(80) CONSTRAINT UQ_ACC_STOCK_IN_HAND UNIQUE NOT NULL, " ;//   'company_id+branch_id+date+ledger_name
                    strSQL = strSQL + "BRANCH_ID char (4) NULL CONSTRAINT FK_ACC_STOCK_IN_HAND_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NULL CONSTRAINT FK_ACC_STOCK_IN_HAND_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME),";
                    strSQL = strSQL + "STOCK_DATE datetime NULL,";
                    strSQL = strSQL + "STOCK_CLOSING_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCK_TO_BY varchar(2) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateCurrencyExchange()
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
                    strSQL = "CREATE TABLE ACC_CURRENCY_EXCHANGE(";
                    strSQL = strSQL + "CURRENCY_EXCHANGE_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "CURRENCY_EXCHANGE_KEY varchar(13) CONSTRAINT PK_ACC_CURRENCY_EXCHANGE_KEY PRIMARY KEY,";//    'Date + Symbol
                    strSQL = strSQL + "CURRENCY_SYMBOL varchar(5) NOT NULL CONSTRAINT FK_ACC_CURRENCY_EXCHANGE_CUR_SYMBOL REFERENCES ACC_CURRENCY(CURRENCY_SYMBOL) ON UPDATE CASCADE,";
                    strSQL = strSQL + "CURRENCY_STD_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "CURRENCY_BUY_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "CURRENCY_SELL_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateVoucherJoin()
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
                    strSQL = "CREATE TABLE ACC_VOUCHER_JOIN(";
                    strSQL = strSQL + "VOUCHER_JOIN_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_VOUCHER_JOIN PRIMARY KEY,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_VOUCHER_JOIN_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "VOUCHER_JOIN_PRIMARY_REF VARCHAR(30) NOT NULL CONSTRAINT FK_ACC_VOUCHER_JOIN_PRIMARY_REF REFERENCES ACC_COMPANY_VOUCHER(COMP_REF_NO),";
                    strSQL = strSQL + "VOUCHER_JOIN_FOREIGN_REF VARCHAR(30) NOT NULL CONSTRAINT FK_ACC_VOUCHER_JOIN_FOREIGN_REF REFERENCES ACC_COMPANY_VOUCHER(COMP_REF_NO),";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE ACC_VOUCHER_JOIN_CLASS(";
                    strSQL = strSQL + "VOUCHER_JOIN_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_VOUCHER_JOIN_CLASS PRIMARY KEY,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_VOUCHER_JOIN_CLASS_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "VOUCHER_JOIN_PRIMARY_REF VARCHAR(30) NOT NULL CONSTRAINT FK_ACC_VOUCHER_JOIN_CLASS_PRIMARY_REF REFERENCES ACC_COMPANY_VOUCHER(COMP_REF_NO),";
                    strSQL = strSQL + "VOUCHER_JOIN_FOREIGN_REF VARCHAR(30) NOT NULL CONSTRAINT FK_ACC_VOUCHER_JOIN_CLASS_FOREIGN_REF REFERENCES ACC_COMPANY_VOUCHER(COMP_REF_NO),";
                    strSQL = strSQL + "CLASS_NAME VARCHAR(100) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd1 = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateVoucher()
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
                    strSQL = "CREATE TABLE ACC_VOUCHER(";
                    strSQL = strSQL + "VOUCHER_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_VOUCHER PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) CONSTRAINT FK_ACC_VOUCHER_COMP_REF_NO REFERENCES ACC_COMPANY_VOUCHER(COMP_REF_NO) NOT NULL,";//    'COMP_REF_NO
                    strSQL = strSQL + "VOUCHER_REF_KEY VARCHAR(50) CONSTRAINT UQ_ACC_VOUCHER UNIQUE NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_VOUCHER_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_POSITION smallint default 0 NOT NULL,"  ;//  'position of this entry in this vch
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_ACC_VOUCHER_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER VARCHAR(30) NULL,";
                    strSQL = strSQL + "VOUCHER_CHEQUE_DATE datetime NULL,";
                    strSQL = strSQL + "VOUCHER_CHEQUE_DRAWN_ON varchar(60) NULL,";
                    strSQL = strSQL + "VOUCHER_BANK_DATE datetime NULL," ;//  'For Bank Reconsiliation
                    strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_CREDIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_ADD_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_LESS_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_TOBY char (2) NOT NULL,";
                    strSQL = strSQL + "VOUCHER_REVERSE_LEDGER varchar (60) NULL ," ;//   'NOT NULL REFERENCES ACC_LEDGER(LEDGER_NAME),"
                    strSQL = strSQL + "VOUCHER_FC_DEBIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_FC_CREDIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_CURRENCY_SYMBOL varchar (5) NULL CONSTRAINT FK_ACC_VOUCHER_CURRENCY REFERENCES ACC_CURRENCY(CURRENCY_SYMBOL) ON UPDATE CASCADE,";
                    strSQL = strSQL + "VOUCHER_ADD_LESS_SIGN Varchar(30) NULL,";
                    strSQL = strSQL + "FC_CONVERSION_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_CASHFLOW smallint default 0 Null,";//    '0=No 1=Yes
                    strSQL = strSQL + "AGNST_COMP_REF_NO VARCHAR(60) NULL,";
                    strSQL = strSQL + "VOUCHER_NARRATION varchar(300) NULL,";
                    strSQL = strSQL + "BANK_CHARGE_PER varchar(10) NULL,";
                    strSQL = strSQL + "BANK_CHARGE_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BANK_RECON_STATUS char(2) default 'N' NOT NULL,";
                    strSQL = strSQL + "TRANSFER_TYPE smallint default 0 not null,";
                    strSQL = strSQL + "AUTOJV SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "REVERSE_LEDGER1 varchar (60) NULL,";
                    strSQL = strSQL + "LEDG_PREFIX varchar (2) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateCompanyVoucher()
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
                    strSQL = "CREATE TABLE ACC_COMPANY_VOUCHER(";
                    strSQL = strSQL + "COMP_VOUCHER_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) CONSTRAINT PK_ACC_COMPANY_VOUCHER PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "SAMPLE_STATUS SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_COMPANY_VOUCHER_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_ACC_COMPANY_VOUCHER_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_MONTH_ID VARCHAR(6) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_ADD_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_LESS_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_NET_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_PROCESS_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_ROUND_OFF_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_BALANCE numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_NARRATION varchar(400) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DESPATCH_TO varchar(30) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_PARTY_NAME varchar(60) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_ADDRESS1 varchar(50) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_ADDRESS2 varchar(50) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_CITY varchar(30) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_TERM_OF_PAYMENTS varchar(20) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DESPATCH_THRU varchar(30) NULL,";
                    strSQL = strSQL + "AUTOJV SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_CREDIT_DAYS numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DUE_DATE datetime NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_STATUS smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_FC smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_AGAINST_REF smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_IS_AUTO smallint default 0 NOT NULL,";//    '0 = Manual,1 = Auto
                    strSQL = strSQL + "AGNST_COMP_REF_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "POS_LEDGER varchar(60) NULL,";
                    strSQL = strSQL + "SALES_REP varchar(60) NULL, ";
                    strSQL = strSQL + "COMP_DELIVERY varchar(300) NULL,";
                    strSQL = strSQL + "COMP_TERM_OF_PAYMENTS varchar(300) NULL,";
                    strSQL = strSQL + "COMP_SUPPORT varchar(300) NULL,";
                    strSQL = strSQL + "COMP_VALIDITY_DATE datetime NULL,";
                    strSQL = strSQL + "COMP_OTHERS varchar(300) NULL,";
                    strSQL = strSQL + "COMP_LOGO_NO SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "APP_STATUS SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "APPROVED_BY varchar(60) null,";
                    strSQL = strSQL + "ONLINE SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "NET_G_COMM numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "PREPARED_BY VARCHAR(30)  NULL CONSTRAINT FK_ACC_COM_VOUCHER_U_NAME REFERENCES USER_CONFIG(USER_LOGIN_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "PREPARED_DATE datetime NULL,";
                    strSQL = strSQL + "ORDER_NO varchar(50) NULL,";
                    strSQL = strSQL + "ORDER_DATE datetime NULL,";
                    strSQL = strSQL + "CRT_QTY numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BOX_QTY numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DESTINATION varchar(60)  NULL CONSTRAINT FK_ACC_COM_VOUCHER_DES_NAME REFERENCES ACC_DESTINATION(DESTINATION_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "TRANSPORT_NAME varchar(60)  NULL CONSTRAINT FK_ACC_COM_VOUCHER_TRAN_NAME REFERENCES ACC_TRANSPORT_NAME(TRANSPORT_NAME) ON UPDATE CASCADE,";

                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "N_STAFF SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "SP_JOURNAL SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "DISABLE_VOUCHER SMALLINT DEFAULT 0  NOT NULL,";

                    strSQL = strSQL + " APPROVED_DATE DATETIME NULL,";
                    strSQL = strSQL + " APPS_TERITORRY_CODE VARCHAR(30) NULL,";
                    strSQL = strSQL + " APPS_CUSTOMER_MERZE VARCHAR(200) NULL,";
                    strSQL = strSQL + " APPS_COMP_QTY NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + " APPS_NOTIFICATION SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + " APPS_SYNCHONIZED SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + " APPS_COMM_CAL  SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        
        private static string CreateLedgerTransaction()
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
                    strSQL = "CREATE TABLE ACC_LEDGER_TRANSACTION(";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) CONSTRAINT PK_ACC_LEDGER_TRANSACTION PRIMARY KEY,";
                    strSQL = strSQL + "LEDGER_DEBIT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_CREDIT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateFixedAssetAccDep()
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
                    strSQL = "CREATE TABLE ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION(";
                    strSQL = strSQL + "BRANCH_LEDGER_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION PRIMARY KEY,";
                    strSQL = strSQL + "BRANCH_LEDGER_KEY varchar (68) NOT NULL,";   // 'Combination of Branch ID + Ledger Name ( Company_id + ledger Name)
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BRANCH_ACCUMULATED_DEPRECIATION numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateFixedAssetPurchaseAmount()
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
                    strSQL = "CREATE TABLE ACC_FIXED_ASSET_PURCHASE_AMOUNT(";
                    strSQL = strSQL + "BRANCH_LEDGER_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_FIXED_ASSET_PURCHASE_AMOUNT PRIMARY KEY,";
                    strSQL = strSQL + "BRANCH_LEDGER_KEY varchar (68) NOT NULL," ;//   'Combination of Branch ID + Ledger Name ( Company_id + ledger Name)
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_FIXED_ASSET_PURCHASE_AMOUNT_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_ACC_FIXED_ASSET_PURCHASE_AMOUNT_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BRANCH_PURCHASE_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateConfig()
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
                    strSQL = "CREATE TABLE ACC_CONFIG(";
                    strSQL = strSQL + "CONFIG_NO numeric(10,0) IDENTITY (1,1) CONSTRAINT PK_ACC_CONFIG PRIMARY KEY, ";
                    strSQL = strSQL + "IS_INCOME_EXPENSES smallint default 0 NOT NULL, ";
                    strSQL = strSQL + "IS_MULTIPLE_CURRENCY smallint default 0 NOT NULL, ";
                    strSQL = strSQL + "IS_MULTIPLE_LOCATION smallint default 0 NOT NULL, ";
                    strSQL = strSQL + "BACKUP_TARGET varchar(50) NULL,";
                    strSQL = strSQL + "BACKUP_TIMES numeric (10,0) NULL,";
                    strSQL = strSQL + "IS_CASH_OR_CREDIT smallint default 0 NOT NULL, ";//    '0 = Cash Sale, 1 = Credit Sale
                    strSQL = strSQL + "IS_CURSOR_QTY_COL smallint default 0 NOT NULL, ";   // '0 = No, 1 = Yes
                    strSQL = strSQL + "CASH_LEDGER_NAME varchar(60) NULL, ";// 'REFERENCES ACC_LEDGER(LEDGER_NAME),"
                    strSQL = strSQL + "SALES_LEDGER_NAME varchar(60) NULL, "; ///   ' REFERENCES ACC_LEDGER(LEDGER_NAME),"
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        private static string CreateGroupCompanyTran()
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
                    strSQL = "CREATE TABLE ACC_GROUPCOMPANY_TRAN(";
                    strSQL = strSQL + "GROUPCOMPANY_TRAN_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_GROUPCOMPANY_TRAN PRIMARY KEY,";
                    strSQL = strSQL + "GROUPCOMPANY_TRAN_CREATE_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "GROUPCOMPANY_ID char (4)  NOT NULL CONSTRAINT FK_ACC_GROUPCOMPANY_TRAN_G_ID REFERENCES ACC_GROUPCOMPANY(GROUPCOMPANY_ID),";
                    strSQL = strSQL + "GROUPCOMPANY_NAME varchar (60),";
                    strSQL = strSQL + "GROUPCOMPANY_DATABASE varchar(9) NULL,";
                    strSQL = strSQL + "COMPANY_NAME varchar (60),";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        private static string CreateGroupCompany()
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
                     strSQL = "CREATE TABLE ACC_GROUPCOMPANY(";
                    strSQL = strSQL + "GROUPCOMPANY_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "GROUPCOMPANY_CREATE_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "GROUPCOMPANY_ID char (4) CONSTRAINT PK_ACC_GROUPCOMPANY PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "GROUPCOMPANY_NAME varchar (60)  NOT NULL,";
                    strSQL = strSQL + "GROUPCOMPANY_ADD1 varchar(50) NULL,";
                    strSQL = strSQL + "GROUPCOMPANY_ADD2 varchar(50) NULL,";
                    strSQL = strSQL + "GROUPCOMPANY_ADD3 varchar(50) NULL,";
                    strSQL = strSQL + "GROUPCOMPANY_ADD4 varchar(50) NULL,";
                    strSQL = strSQL + "GROUPCOMPANY_CITY varchar(30) NULL,";
                    strSQL = strSQL + "GROUPCOMPANY_EMAIL varchar(50) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        
        private static string CreateCompanyInformation(string  vstrCompanyName)
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
                    strSQL = "CREATE TABLE ACC_COMPANY(";
                    strSQL = strSQL + "COMPANY_ID char(4) CONSTRAINT PK_ACC_COMPANY PRIMARY KEY,";
                    strSQL = strSQL + "BRANCH_ID char(4) NOT NULL,";
                    strSQL = strSQL + "COMPANY_CREATE_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "COMPANY_NAME varchar (60) UNIQUE  NOT NULL,";
                    strSQL = strSQL + "COMPANY_INT_NAME varchar (60)  NOT NULL,";
                    strSQL = strSQL + "COMPANY_ADD1 varchar(80) NULL,";
                    strSQL = strSQL + "COMPANY_ADD2 varchar(80) NULL,";
                    strSQL = strSQL + "COMPANY_ADD3 varchar(50) NULL,";
                    strSQL = strSQL + "COMPANY_ADD4 varchar(50) NULL,";
                    strSQL = strSQL + "COMPANY_COUNTRY varchar(30) NULL,";
                    strSQL = strSQL + "COMPANY_PHONE varchar(30) NULL,";
                    strSQL = strSQL + "COMPANY_FAX varchar(30) NULL,";
                    strSQL = strSQL + "COMPANY_BUSINESS_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMPANY_FINICIAL_YEAR_FROM datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "COMPANY_FINICIAL_YEAR_TO datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "COMPANY_MAINTAIN smallint default 2 NOT NULL,";
                    strSQL = strSQL + "COMPANY_BASE_CURRENCY_SYMBOL varchar(5) NULL CONSTRAINT FK_ACC_COMPANY_CURRENCY_SYMBOL REFERENCES ACC_CURRENCY(CURRENCY_SYMBOL) ON UPDATE CASCADE,";
                    strSQL = strSQL + "COMPANY_BRANCH smallint default 0 NOT NULL,";//    ' 0 = No, 1 = Yes
                    strSQL = strSQL + "COMPANY_ACCESS_CONTROL smallint default 0 NOT NULL,";   // ' 0 = Restricted, 1 = Open
                    strSQL = strSQL + "COMPANY_COMMENTS varchar(50) NULL,";
                    strSQL = strSQL + "IS_INCOME_EXPENSES smallint default 0 NOT NULL, ";
                    strSQL = strSQL + "IS_MULTIPLE_CURRENCY smallint default 0 NOT NULL, ";
                    strSQL = strSQL + "IS_MULTIPLE_LOCATION smallint default 0 NOT NULL, " ;//   '0 = No, 1 = Yes
                    strSQL = strSQL + "BACKUP_TARGET varchar(50) NULL,";
                    strSQL = strSQL + "BACKUP_CLIENT varchar(50) NULL,";
                    strSQL = strSQL + "BACKUP_TIMES numeric (10,0) NULL,";
                    strSQL = strSQL + "IS_CASH_OR_CREDIT smallint default 0 NOT NULL, ";//    '0 = Cash Sale, 1 = Credit Sale
                    strSQL = strSQL + "IS_CURSOR_QTY_COL smallint default 0 NOT NULL, " ;//   '0 = No, 1 = Yes
                    strSQL = strSQL + "CASH_LEDGER_NAME varchar(60) NULL,";
                    strSQL = strSQL + "SALES_LEDGER_NAME varchar(60) NULL,";
                    strSQL = strSQL + "POS_VAT numeric(9, 2) NULL ,";
                    strSQL = strSQL + "VAT_REGISTRATION varchar(50) NULL,";
                    strSQL = strSQL + "STOCKITEM_ALIAS smallint default 0 NOT NULL, " ;//   '0 = No, 1 = Yes
                    strSQL = strSQL + "EFFECT_INVENTORY_DIRECT_SALES smallint default 0 NOT NULL," ;//   '0 = Yes, 1 = No
                    strSQL = strSQL + "SINGLE_STOCK_TRANFER smallint default 1 NOT NULL," ;//   '0 = No, 1 = Yes
                    strSQL = strSQL + "DIFFERENT_STOCK_TRANFER smallint default 0 NOT NULL," ;//   '0 = No, 1 = Yes
                    if  (vstrCompanyName == "Manufacturing Company" )
                    {
                        strSQL = strSQL + "MANUFACTURING_SYSTEM smallint default 1 NOT NULL,";   // '0 = No, 1 = Yes
                        strSQL = strSQL + "MAINTAIN_BATCH smallint default 1 NOT NULL,";   // '0 = No, 1 = Yes
                    }
                    else{
                        strSQL = strSQL + "MANUFACTURING_SYSTEM smallint default 0 NOT NULL,";   // '0 = No, 1 = Yes
                        strSQL = strSQL + "MAINTAIN_BATCH smallint default 0 NOT NULL,";//    '0 = No, 1 = Yes
                    }
                    if (vstrCompanyName == "Real Estate")
                    {
                        strSQL = strSQL + "BOOKING_INFORMATION smallint default 1 NOT NULL,"; ;
                        strSQL = strSQL + "ADMISSION_REAL_ESTATE smallint default 1 NOT NULL,"; ;
                    }
                    else
                    {
                        strSQL = strSQL + "BOOKING_INFORMATION smallint default 0 NOT NULL,"; 
                        strSQL = strSQL + "ADMISSION_REAL_ESTATE smallint default 0 NOT NULL,"; 
                    }
                    strSQL = strSQL + "SLIP_SALES_INVOICE smallint default 0 NOT NULL,";;
                    strSQL = strSQL + "SINGLE_NARRATION smallint default 0 NOT NULL,";;
                    strSQL = strSQL + "APPROVED smallint default 0 NOT NULL,";;
                    strSQL = strSQL + "PHYSICAL_STOCK smallint default 1 NOT NULL,";;
                    strSQL = strSQL + "SMS smallint default 0 NOT NULL,";
                    strSQL = strSQL + "ITEM_PRODUCT_CODE_ACTIVE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "EFFECT_INVENTORY_DIRECT_PI smallint default 0 NOT NULL,";
                    strSQL = strSQL + "IS_MULTIPLE_CURRENCY_SYMBOL VARCHAR(5) NULL,";
                    strSQL = strSQL + "IS_MULTIPLE_CURRENCY_RATE NUMERIC(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";

                    strSQL = strSQL + ")";


                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateCurrency()
        {
            string conn=Utility.SQLConnstring();
            using (SqlConnection gcnmain = new SqlConnection(conn))
            {
                if (gcnmain.State == System.Data.ConnectionState.Open)
                {
                    gcnmain.Close();
                }
                try
                {
                    gcnmain.Open();
                    string strSQL;
                    strSQL = "CREATE TABLE ACC_CURRENCY(";
                    strSQL = strSQL + "CURRENCY_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "CURRENCY_SYMBOL varchar(5) CONSTRAINT PK_ACC_CURRENCY PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "CURRENCY_NAME varchar(30) NOT NULL,";
                    strSQL = strSQL + "CURRENCY_STRING varchar(10) NULL,";
                    strSQL = strSQL + "CURRENCY_DECIMAL smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "EXPORT_TYPE smallint default 1 NOT NULL,";
                    //'1 = Not Exported, 2 = Exported, 3 = Imported
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        private static string CreateBranch()
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
                    strSQL = "CREATE TABLE ACC_BRANCH(";
                    strSQL = strSQL + "BRANCH_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "BRANCH_CREATE_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) CONSTRAINT PK_ACC_BRANCH PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "BRANCH_NAME varchar (60)  NOT NULL ,";
                    strSQL = strSQL + "BRANCH_INT_NAME varchar (56) NOT NULL,";
                    strSQL = strSQL + "BRANCH_NAME_DEFAULT varchar(60) NULL,";
                    strSQL = strSQL + "BRANCH_ADD1 varchar(50) NULL,";
                    strSQL = strSQL + "BRANCH_ADD2 varchar(50) NULL,";
                    strSQL = strSQL + "BRANCH_ADD3 varchar(50) NULL,";
                    strSQL = strSQL + "BRANCH_ADD4 varchar(50) NULL,";
                    strSQL = strSQL + "BRANCH_COUNTRY varchar(30) NULL,";
                    strSQL = strSQL + "BRANCH_PHONE varchar(30) NULL,";
                    strSQL = strSQL + "BRANCH_FAX varchar(30) NULL,";
                    strSQL = strSQL + "BRANCH_STATUS char(1) NOT NULL DEFAULT 'A'," ;  // 'This Field is Unsed
                    strSQL = strSQL + "BRANCH_ACTIVE smallint default 0 NOT NULL," ;   //' 0 = Active, 1 = Inactive
                    strSQL = strSQL + "BRANCH_TYPE smallint NOT NULL DEFAULT 0,"  ;  //'1= Main Branch,0=Sub Branch
                    strSQL = strSQL + "BRANCH_FLAG smallint NOT NULL DEFAULT 0," ;   //'1= Current Branch,0 = Opt Branch
                    strSQL = strSQL + "BRANCH_COMMENTS varchar(50) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "LOGO_REF smallint default 0 NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        private static string CreateUser()
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
                     strSQL = "CREATE TABLE USER_CONFIG(";
                    strSQL = strSQL + "USER_LOGIN_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "USER_LOGIN_NAME varchar (30) CONSTRAINT PK_USER_CONFIG PRIMARY KEY,";
                    strSQL = strSQL + "USER_CREATE_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "USER_FULL_NAME varchar (25) NOT NULL,";
                    strSQL = strSQL + "USER_PASS varchar(28) NOT NULL,";
                    strSQL = strSQL + "USER_LEBEL smallint default 0 NOT NULL,";
                   // '1 = Admin, 2 = Operator, 3 = Report Viewer
                    strSQL = strSQL + "USER_STATUS char(1) NOT NULL,";
                    strSQL = strSQL + "USER_COMMENTS VARCHAR(40)  NULL,";
                    strSQL = strSQL + "DEPARTMENT VARCHAR(100)  NULL,";
                    strSQL = strSQL + "DESIGNATION VARCHAR(100)  NULL,";
                    strSQL = strSQL + "IMAGE IMAGE NULL,";
                    strSQL = strSQL + "COMP_ID varchar(4) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateUserPrivilegesMain()
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
                    strSQL = "CREATE TABLE USER_PRIVILEGES_MAIN(";
                    strSQL = strSQL + "PRI_MAIN_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_USER_PRIVILEGES_MAIN PRIMARY KEY,";
                    strSQL = strSQL + "USER_LOGIN_KEY varchar (50) NOT NULL,";
                    strSQL = strSQL + "USER_LOGIN_NAME VARCHAR(30)  NOT NULL CONSTRAINT FK_USER_PRIVILEGES_MAIN_L_NAME REFERENCES USER_CONFIG(USER_LOGIN_NAME) ON UPDATE CASCADE,"   ;
                    strSQL = strSQL + "PRI_MODULE smallint default 0 NOT NULL,";   //'1 = Sales, 2 = Purchase
                    strSQL = strSQL + "PRI_TYPE smallint default 0 NOT NULL,";//    '1 = Full Access, 2 = Partial, 0 = No Access
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateUserPrivilegesChild()
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
                    strSQL = "CREATE TABLE USER_PRIVILEGES_CHILD(";
                    strSQL = strSQL + "PRI_CHILD_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "USER_LOGIN_KEY varchar (50) CONSTRAINT PK_USER_PRIVILEGES_CHILD PRIMARY KEY,";
                    strSQL = strSQL + "USER_LOGIN_NAME VARCHAR(30) NOT NULL CONSTRAINT FK_USER_PRIVILEGES_CHILD_L_NAME REFERENCES USER_CONFIG(USER_LOGIN_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "PRI_COMPONENT smallint default 0 NOT NULL,";//    '1 = Customer List
                    strSQL = strSQL + "PRI_ADD smallint default 0 NOT NULL,";//    ' 0 = No , 1 = Yes
                    strSQL = strSQL + "PRI_EDIT smallint default 0 NOT NULL,";
                    strSQL = strSQL + "PRI_DELETE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "PRI_APPR smallint default 0 NOT NULL,";
                    strSQL = strSQL + "MODULE_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
      
        private static string CreateLogin()
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
                    strSQL = "CREATE TABLE ACC_LOGIN(";
                    strSQL = strSQL + "LOGIN_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_LOGIN PRIMARY KEY,";
                    //'strSQL = strSQL + "USER_ID char (10)  NOT NULL,";
                    strSQL = strSQL + "USER_LOGIN_NAME VARCHAR(30) NOT NULL CONSTRAINT FK_ACC_LOGIN_USER_LOGIN_NAME REFERENCES USER_CONFIG(USER_LOGIN_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "LOGIN_DATE datetime NOT NULL,";
                    strSQL = strSQL + "LOGIN_TIME datetime NOT NULL,";
                    strSQL = strSQL + "LOGOUT_DATE datetime NULL,";
                    strSQL = strSQL + "LOGOUT_TIME datetime NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        private static string CreateLedgerGroup()
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
                    strSQL = "CREATE TABLE ACC_LEDGERGROUP(";
                    strSQL = strSQL + "GR_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "GR_NAME varchar (50) CONSTRAINT PK_ACC_LEDGERGROUP PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "GR_PARENT varchar(50) NOT NULL,";
                    strSQL = strSQL + "GR_ONE_DOWN varchar(50) NOT NULL,";
                    strSQL = strSQL + "GR_PRIMARY varchar(50) NOT NULL,";
                    strSQL = strSQL + "GR_OPENING_DEBIT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GR_OPENING_CREDIT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GR_DEBIT_TOTAL numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GR_CREDIT_TOTAL numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GR_CLOSING_DEBIT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GR_CLOSING_CREDIT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GR_LEVEL smallint DEFAULT 0 NOT NULL," ;//   '1 = Main Group, 2 = Sub Group
                    strSQL = strSQL + "GR_SEQUENCES numeric(5) default 1 NOT NULL,";
                    strSQL = strSQL + "GR_GROUP smallint default 0 NOT NULL, ";//    '1 = CASH, 2 = BANK 2 = OTHER
                    strSQL = strSQL + "GR_PRIMARY_TYPE smallint DEFAULT 0 NOT NULL," ;//   'Asset = 1, Lia = 2, Income = 3, Expen =4
                    strSQL = strSQL + "GR_DEFAULT_GROUP smallint DEFAULT 0 NOT NULL," ;//   '0 = New Group, 1 = Default Group
                    strSQL = strSQL + "GR_CASH_FLOW_TYPE smallint default 4 NOT NULL,";//    '1=Operating Activities  2=Investing Activities 3=Financing Activities
                    strSQL = strSQL + "GR_AFFECT_GP smallint default 0 NOT NULL,";//
                    strSQL = strSQL + "GR_MANUFAC_GROUP smallint default 0 NOT NULL,";
                    strSQL = strSQL + "GR_DEFAULT_NAME varchar(50) NULL,";
                    strSQL = strSQL + "GR_MOBILE_NO varchar(50) NULL,";
                    strSQL = strSQL + "GR_CONTACT_NO varchar(50) NULL,";
                    strSQL = strSQL + "GR_PARENT_POSITION INT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    
                    strSQL = strSQL + "UPDATE_DATE datetime null, ";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateLedger()
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
                    
                    strSQL = "CREATE TABLE ACC_LEDGER(";
                    strSQL = strSQL + "LEDGER_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NULL CONSTRAINT FK_ACC_LEDGER_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "LEDGER_CODE varchar(20) NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) CONSTRAINT PK_ACC_LEDGER PRIMARY KEY,";
                    strSQL = strSQL + "LEDGER_NAME_MERZE varchar(200) NOT NULL,";
                    strSQL = strSQL + "HOMOEO_HALL varchar(60) NULL,";
                    strSQL = strSQL + "TERITORRY_CODE varchar(8) NULL CONSTRAINT FK_ACC_LEDGER_TERITORRY_CODE REFERENCES ACC_TERITORRY(TERITORRY_CODE) ON UPDATE CASCADE,";
                    strSQL = strSQL + "TERRITORRY_NAME varchar(60) NULL,";
                    strSQL = strSQL + "LEDGER_PARTY_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_CURRENCY_SYMBOL varchar(5) NOT NULL,";
                    strSQL = strSQL + "LEDGER_CASH_FLOW_TYPE smallint default 4 NOT NULL,";//    '1=Operating Activities  2=Investing Activities 3=Financing Activities, 4 = CASH,BANK,OD A/C
                    strSQL = strSQL + "LEDGER_PARENT_GROUP varchar(50) NOT NULL CONSTRAINT FK_ACC_LEDGER_PARENT_GROUP REFERENCES ACC_LEDGERGROUP(GR_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "LEDGER_PRIMARY_GROUP varchar(50) NOT NULL,";
                    strSQL = strSQL + "LEDGER_ONE_DOWN varchar(60) NOT NULL,";
                    strSQL = strSQL + "LEDGER_PARTY_UNDER varchar(50) NULL,";
                    strSQL = strSQL + "LEDGER_NAME_DEFAULT varchar(60) NULL,";
                    strSQL = strSQL + "LEDGER_PRICE_LABEL varchar(60) NULL,";
                    strSQL = strSQL + "LEDGER_STATUS smallint default 0 NOT NULL," ;//   ' 0 = Active, 1 = Inactive
                    strSQL = strSQL + "LEDGER_OPENING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "PF_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PF_LEDGER_NAME varchar (60) NULL,";
                    strSQL = strSQL + "HL_LEDGER_NAME varchar (60) NULL,";
                    strSQL = strSQL + "LEDGER_FC_OPENING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_CLOSING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_ON_ACCOUNT_VALUE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_OPENING numeric(18,2) default 0 NOT NULL,";//    'For Dump
                    strSQL = strSQL + "LEDGER_DEBIT numeric(18,2) default 0 NOT NULL,";//    'For Dump
                    strSQL = strSQL + "LEDGER_CREDIT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_CREDIT_LIMIT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_CREDIT_PERIOD numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_CURRENCY_NAME varchar(10) default 'Tk.' NOT NULL,";
                    strSQL = strSQL + "LEDGER_ADDRESS1 varchar(50) NULL,";
                    strSQL = strSQL + "LEDGER_ADDRESS2 varchar(50) NULL,";
                    strSQL = strSQL + "LEDGER_CITY varchar(30) NULL,";
                    strSQL = strSQL + "LEDGER_POSTAL varchar(30) NULL,";
                    strSQL = strSQL + "LEDGER_FAX varchar(30) NULL,";
                    strSQL = strSQL + "LEDGER_PHONE varchar(30) NULL,";
                    strSQL = strSQL + "LEDGER_MOBILE varchar(30) NULL,";
                    strSQL = strSQL + "LEDGER_EMAIL varchar(50) NULL,";
                    strSQL = strSQL + "LEDGER_COUNTRY varchar(50) NULL,";
                    strSQL = strSQL + "LEDGER_CONTACT varchar(50) NULL,";
                    strSQL = strSQL + "LEDGER_COMMENTS varchar(50) NULL,";
                    strSQL = strSQL + "LEDGER_BENEFIT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_VECTOR smallint default 1 NOT NULL," ;//   ' 0 = No, 1 = Yes
                    strSQL = strSQL + "LEDGER_PAYROLL smallint default 0 NOT NULL,";   // ' 0 = No, 1 = Yes
                    strSQL = strSQL + "LEDGER_BILL_WISE smallint default 1 NOT NULL,";//   ' 1 = No, 2 = Yes
                    strSQL = strSQL + "LEDGER_NATURE char(1) default 'D' NOT NULL,";
                    strSQL = strSQL + "LEDGER_LEVEL smallint default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_GROUP smallint default 0 NOT NULL," ;//   '1 = Cash, 2 = Bank Accounts, 3 = sundry Debtors,4 = indirec ex
                    strSQL = strSQL + "LEDGER_PRIMARY_TYPE smallint default 0 NOT NULL,";  //  '1 = ASSET, 2 = LIABILITY, 3 = INCOME, 4 = EXPENSES
                    strSQL = strSQL + "LEDGER_DEFAULT smallint default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_REP_NAME varchar(60) NULL,";
                    strSQL = strSQL + "LEDGER_INVENTORY_AFFECT smallint default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_REP_COMMISSION_TYPE smallint default 0 NOT NULL,";//    '1=Flat Commission,2=Sales Percent 3=profit Percent
                    strSQL = strSQL + "LEDGER_REP_COMMISSION numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_MANUFAC_GROUP smallint default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_ADD_DATE datetime NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "LEDGER_RESIGN_DATE datetime NULL,";
                    strSQL = strSQL + "LEDGER_GROUP_NAME varchar(50) NULL,";
                    strSQL = strSQL + "LEDGER_TARGET numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_COMMISSION smallint default 0 NOT NULL,";
                    strSQL = strSQL + "LEDGER_CLASS varchar(50) NULL,";
                    strSQL = strSQL + "CLOSE_DATE datetime NULL,";
                    strSQL = strSQL + "BKASH_STATUS smallint default 0 NOT NULL,";
                    strSQL = strSQL + "HALT_MPO smallint default 0 NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateBranchLedgerOpening()
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
                    strSQL = "CREATE TABLE ACC_BRANCH_LEDGER_OPENING(";
                    strSQL = strSQL + "BRANCH_LEDGER_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_BRANCH_LEDGER_OPENING PRIMARY KEY,";
                    strSQL = strSQL + "BRANCH_LEDGER_KEY varchar (68) NOT NULL," ;//   'Combination of Branch ID + Ledger Name ( Company_id + ledger Name)
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_BRANCH_LEDGER_OPENING_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_ACC_BRANCH_LEDGER_OPENING_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BRANCH_LEDGER_OPENING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null, ";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                   
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateLedgerOpeningBalance()
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
                strSQL = "CREATE TABLE ACC_LEDGER_OPENING(";
                strSQL = strSQL + "LEDGER_NAME varchar(60) CONSTRAINT PK_ACC_LEDGER_OPENING PRIMARY KEY,";
                strSQL = strSQL + "LEDGER_OPENING numeric(18,2) default 0 NOT NULL,";
                strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateLedgerAndGroup()
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
                    strSQL = "CREATE TABLE ACC_GROUP_LEDGER(";
                    strSQL = strSQL + "GROUP_LEDGER_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_GROUP_LEDGER PRIMARY KEY,";
                    strSQL = strSQL + "GROUP_LEDGER_NAME varchar(60) NOT NULL,";
                    strSQL = strSQL + "GROUP_LEDGER_PARENT varchar(50) NOT NULL,";
                    strSQL = strSQL + "GROUP_LEDGER_LEVEL smallint DEFAULT 0 NOT NULL,";  //  '1 = Main Group, 2 = Sub Group
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateLedgerToGroup()
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
                    strSQL = "CREATE TABLE ACC_LEDGER_TO_GROUP(";
                    strSQL = strSQL + "SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_LEDGER_TO_GROUP PRIMARY KEY,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_ACC_LEDGER_TO_GROUP_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "GR_NAME varchar (50) NOT NULL,";//     'Gr_Name
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null ,";
                    strSQL = strSQL + "CONSTRAINT U_ACC_LEDGER_TO_GROUP UNIQUE NONCLUSTERED (LEDGER_NAME,GR_NAME)";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
        private static string CreateGroupToLedger()
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
                    strSQL = "CREATE TABLE ACC_GROUP_TO_LEDGER(";
                    strSQL = strSQL + "SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_GROUP_TO_LEDGER PRIMARY KEY,";
                    strSQL = strSQL + "GR_NAME varchar (50) CONSTRAINT FK_ACC_GROUP_TO_LEDGER_GR_NAME REFERENCES ACC_LEDGERGROUP(GR_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "GR_PARENT varchar (50) NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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


        public static string CreateCostCategory()
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
                    strSQL = "CREATE TABLE VECTOR_CATEGORY(";
                    strSQL = strSQL + "VECTOR_CATEGORY_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "VECTOR_CATEGORY_NAME varchar(60) CONSTRAINT PK_VECTOR_CATEGORY PRIMARY KEY,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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


        public static string CreateCostCenter()
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
                    strSQL = "CREATE TABLE VECTOR_MASTER(";
                    strSQL = strSQL + "VMASTER_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "VMASTER_NAME varchar(60) CONSTRAINT PK_VECTOR_MASTER PRIMARY KEY,";
                    strSQL = strSQL + "VECTOR_UNDER varchar(60) NULL,";
                    strSQL = strSQL + "VECTOR_CATEGORY_NAME varchar(60) NOT NULL CONSTRAINT FK_VECTOR_MASTER_CATEGORY REFERENCES VECTOR_CATEGORY(VECTOR_CATEGORY_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "VMASTER_OPENING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VMASTER_CLOSING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null, ";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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

        
        //****************************************Stock

#endregion

       










        
    }
}
