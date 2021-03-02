using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dutility
{
    public class basTableSchemaReport
    {

        public static string gCreateTableReport()
        {
            string strSQL;
            strSQL= CreateVoucherParent();
            strSQL= CreateVoucherParentFC();
            strSQL= CreateVoucherChild();
            strSQL= CreateVoucherChildFC();
            strSQL= CreateLedgerReport();
            strSQL= CreateLedgerReportFC();
            strSQL= CreateTradingAndProfitLoss();
            strSQL= CreateRatioAnalysis();
            strSQL= CreateRatioMainGroup();
            strSQL= CreateLedgerMultiCashBank();
            strSQL= CreateBatchReport();
            strSQL= CreateBatchReportDetails();
            strSQL= CreateGrpSummaryMonthWise();
            strSQL= CreateStockSummaryVoucherWise();
            strSQL= CreateTradingAndProfitLossLedger();
            strSQL= CreateManufacturing();
            strSQL= CreateBudgetReport();
            strSQL= CreateBillTranDum();
            strSQL= CreateProfitAndLoss();
            strSQL= CreateProfitAndLossTemp();
            strSQL= CreateProfitAndLossComp();
            strSQL= CreateProfitAndLossV();
            strSQL= CreateProfitAndLossGroup();
            strSQL= CreateCashFlow();
            strSQL= CreateCashFlowComp();
            strSQL= CreateTrading();
            strSQL= CreateBalanceSheetTemp();
            strSQL= CreateBalanceSheetData();
            strSQL= CreateBalanceSheetCompData();
            strSQL= CreateBalanceSheetData1();
            strSQL= CreateGroupSummary();
            strSQL= CreateTrailBalance();
            strSQL= CreateReceiveAndPayment();
            strSQL= CreateReceiveAndPaymentComp();
            strSQL= CreateMonthlySummaryDummy();
            strSQL= CreateCostCenterOpeingDump();
            strSQL= CreateLedgerCostCenter();
            strSQL= CreateVectorCateReport();
            strSQL= CreateBillWiseYear();
            strSQL= CreateFixedAssetSchedule();
            strSQL= CreateGeneralLedger();
            strSQL= CreateGeneralLedgerView();
            strSQL= CreateCostcenterLedgertemp();
            strSQL= CreateTranDate();
            strSQL = CreateInvStockStatement();
            strSQL = CreateInvStockPackSize();
            strSQL = CreateInvFinishedItemStatement();
            strSQL = CreateInvProductStatementRaw();
            strSQL = CreateInvProductStatementProduction();
            strSQL = CreateAccSpCrossJV();
            strSQL = CreateAccSalCollTargetAchieve();
            strSQL = CreateAccExpenseDump();
            strSQL = CreateTargetDetailTemp();
            strSQL = CreateStoreLedgerTemp();
            strSQL = CreateInvManufacturingTemp();
            strSQL = CreateInvProcessDemandTemp();
            return  strSQL;

        }
        private static string CreateInvProcessDemandTemp()
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
                    strSQL = "CREATE table INV_PROCESS_DEMAND_TEMP(";
                    strSQL = strSQL + "PROCESS_TYPE int default 0 not null,";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(100) null,";
                    strSQL = strSQL + "STOCKITEM_BASEUNITS varchar(10) null,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(100) null,";
                    strSQL = strSQL + "CLS numeric(18,2) default 0 not null,";
                    strSQL = strSQL + "PROCESS_QUANTITY numeric(18,2) default 0 not null";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE INV_MANUFACTURING_COST(ManuCost NUMERIC(18,4) DEFAULT 0 NOT NULL) ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE SPECIAL_PROEUCT_TEMP(";
                    strSQL = strSQL + "ZONE_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "DIVISION_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "AREA_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "LEDGER_MERZE_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "STOCK_GROUP_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "STOCK_ITEM_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "STOCK_CATEGORY_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "MONTH_ID VARCHAR(10) NULL,";
                    strSQL = strSQL + "PRE_TARGET_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PRE_SALES_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CUR_TARGET_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CUR_SALES_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ITEM_POSITION int default 0 not null";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE USER_ONLILE_SECURITY(";
                    strSQL = strSQL + "USER_ID numeric(18,0) identity(1,1) NOT NULL CONSTRAINT PK_USER_ONLILE_SECURITY PRIMARY KEY ,";
                    strSQL = strSQL + "PASSWORD VARCHAR(60)  NULL,";
                    strSQL = strSQL + "COR_MOBILE_NO VARCHAR(30)  NULL,";
                    strSQL = strSQL + "TC VARCHAR(30) NOT NULL,";
                    strSQL = strSQL + "TCNAME VARCHAR(100) NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(100) NOT NULL,";
                    strSQL = strSQL + "GR_NAME VARCHAR(100) NOT NULL,";
                    strSQL = strSQL + "MPO_TYPE smallint default 0 not null,";
                    strSQL = strSQL + "SECURITY_CODE VARCHAR(500) NULL,";
                    strSQL = strSQL + "STATUS SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "LIST_M_D_A NUMERIC(18,0) DEFAULT 0  NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE ACC_SAL_CR_LIMIT_TEMP(";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NULL,";
                    strSQL = strSQL + "AREA_NAME varchar(60) NULL,";
                    strSQL = strSQL + "DIVISION_NAME varchar(60) NULL,";
                    strSQL = strSQL + "ZONE_NAME varchar(60) NULL,";
                    strSQL = strSQL + "CR_LIMIT_1 numeric(18, 4) NULL,";
                    strSQL = strSQL + "CLOSING_BAL_1 numeric(18, 4) NULL,";
                    strSQL = strSQL + "CR_LIMIT_2 numeric(18, 4) NULL,";
                    strSQL = strSQL + "CLOSING_BAL_2 numeric(18, 4) NULL,";
                    strSQL = strSQL + "CR_LIMIT_3 numeric(18, 4) NULL,";
                    strSQL = strSQL + "CLOSING_BAL_3 numeric(18, 4) NULL,";
                    strSQL = strSQL + "CR_LIMIT_4 numeric(18, 4) NULL,";
                    strSQL = strSQL + "CLOSING_BAL_4 numeric(18, 4) NULL";
                    strSQL = strSQL + ") ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE SALES_CHALAN_TEMP(";
                    strSQL = strSQL + "SL_NO  NUMERIC(18,0) IDENTITY(18,1)  NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME_MERZE varchar(100) NULL,";
                    strSQL = strSQL + "CHALAN_NUMBER varchar(50) NULL,";
                    strSQL = strSQL + "DELIVERY_DATE DATETIME NULL,";
                    strSQL = strSQL + "INVOICE_NO varchar(50) NULL,";
                    strSQL = strSQL + "INVOICE_DATE DATETIME NULL,";
                    strSQL = strSQL + "TRANSPORT varchar(50) NULL,";
                    strSQL = strSQL + "DESTINATION varchar(50) NULL,";
                    strSQL = strSQL + "TR_NO varchar(50) NULL,";
                    strSQL = strSQL + "CART_QTY numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BOX_QTY numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "NARRATION varchar(200) NULL,";
                    strSQL = strSQL + "BRANCH_NAME varchar(60) NULL";
                    strSQL = strSQL + ") ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE INV_STOCK_STATTISTICAL_TEMP(";
                    strSQL = strSQL + "STOCKITEM_NAME VARCHAR(100) NULL,";
                    strSQL = strSQL + "STOCKGROUP_NAME  VARCHAR(100) NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_NAME  VARCHAR(100) NULL,";
                    strSQL = strSQL + "BILL_QUANTITY  NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BILL_QUANTITY_BONUS  NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BILL_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "GR_PARENT VARCHAR(100) NULL,";
                    strSQL = strSQL + "LEDGER_ADDRESS1 VARCHAR(200) NULL,";
                    strSQL = strSQL + "POWER_CLASS VARCHAR(100) NULL,";
                    strSQL = strSQL + "LEDGER_NAME_MERZE VARCHAR(100) NULL,";
                    strSQL = strSQL + "SEQ_NO NUMERIC(18,0) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ZONE VARCHAR(100) NULL,";
                    strSQL = strSQL + "DIVISION VARCHAR(100) NULL,";
                    strSQL = strSQL + "AREA VARCHAR(100) NULL,";
                    strSQL = strSQL + "BRANCH_ID varchar(4) null";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE ACC_DAY_BOOK_TEMP(";
                    strSQL = strSQL + "ZONE VARCHAR(100) NULL,";
                    strSQL = strSQL + "TERITORRY_CODE VARCHAR(100) NULL,";
                    strSQL = strSQL + "TERITORRY_NAME VARCHAR(100) NULL,";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(100) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE VARCHAR(100) NULL,";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(200) NULL,";
                    strSQL = strSQL + "LEDGER_NAME_NEW VARCHAR(200) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE DATETIME NULL,";
                    strSQL = strSQL + "VOUCHER_CHEQUE_DATE DATETIME NULL,";
                    strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER VARCHAR(100) NULL,";
                    strSQL = strSQL + "VOUCHER_CHEQUE_DRAWNON VARCHAR(100) NULL,";
                    strSQL = strSQL + "DEBIT_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "VOUCHER_TO_BY VARCHAR(2) NULL,";
                    strSQL = strSQL + "VOUCHER_REVERSE_LEDGER VARCHAR(200),";
                    strSQL = strSQL + "PF_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "HL_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE ACC_DAY_BOOK_TEMP_SUMM (";
                    strSQL = strSQL + "ZONE VARCHAR(60) NULL,";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "VOUCHER_CREDIT_AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PF_AMOUNT  NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "HL_AMOUNT  NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE ACC_DEFAULTER_LEDGER(";
                    strSQL = strSQL + "VOUCHER_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_DEFAULTER_LEDGER PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_ACC_DEFAULTER_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_DEFAULTER_LEDGER_B_ID REFERENCES ACC_BRANCH(BRANCH_ID) ON UPDATE CASCADE,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL,";
                    strSQL = strSQL + "MONTH_ID VARCHAR(6) NOT NULL,";
                    strSQL = strSQL + "DEF_STATUS SMALLINT DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE MPOLIST_TEMP(";
                    strSQL = strSQL + "ZONE VARCHAR(60) NULL,";
                    strSQL = strSQL + "DIVISON VARCHAR(60) NULL,";
                    strSQL = strSQL + "AREA VARCHAR(60) NULL,";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(200) NULL,";
                    strSQL = strSQL + "MOBILE1 VARCHAR(60) NULL,";
                    strSQL = strSQL + "MOBILE2 VARCHAR(60) NULL,";
                    strSQL = strSQL + "TERITORRY_CODE VARCHAR(20) NULL,";
                    strSQL = strSQL + "TERITORRY_NAME VARCHAR(100) NULL,";
                    strSQL = strSQL + "CT INT DEFAULT 1 NOT NULL,";
                    strSQL = strSQL + "LEDGER_CLASS VARCHAR(20) NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE MPOLIST_ZONE(";
                    strSQL = strSQL + "ZONE VARCHAR(60) NULL,";
                    strSQL = strSQL + "ZONE_TOTAL NUMERIC(18,0) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = " CREATE TABLE MPOLIST_DIVISION(";
                    strSQL = strSQL + "DIVISON VARCHAR(60) NULL,";
                    strSQL = strSQL + "DIVISION_TOTAL NUMERIC(18,0) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE MPOLIST_AREA(";
                    strSQL = strSQL + "AREA VARCHAR(60) NULL,";
                    strSQL = strSQL + "AREA_TOTAL NUMERIC(18,0) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE INV_BOM_COST_PRICE (";
                    strSQL = strSQL + "ITEM_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "INV_RATE NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE SAL_PRODUCT_SALES_STATEMENT_TEMP(";
                    strSQL = strSQL + "Zone varchar(250) NULL,";
                    strSQL = strSQL + "Division varchar(250) NULL,";
                    strSQL = strSQL + "Area varchar(250) NULL,";
                    strSQL = strSQL + "LedgerName varchar(250) NULL,";
                    strSQL = strSQL + "StockGroup varchar(250) NULL,";
                    strSQL = strSQL + "ItemName varchar(250) NULL,";
                    strSQL = strSQL + "PackSize varchar(50) NULL,";
                    strSQL = strSQL + "BillQty int NULL";
                    strSQL = strSQL + ") ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE SP_COMMITION_TEMP(";
                    strSQL = strSQL + "AREA varchar(250) NULL,";
                    strSQL = strSQL + "LEDGER_NAME_MARZE varchar(250) NULL,";
                    strSQL = strSQL + "VOUCHER_LEDGER varchar(250) NULL,";
                    strSQL = strSQL + "COMM_REF_NO varchar(250) NULL,";
                    strSQL = strSQL + "AMOUNT1 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT2 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT3 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT4 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT5 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT6 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT7 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT8 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT9 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT10 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT11 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT12 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT13 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT14 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT15 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT16 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT17 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT18 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT19 numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT20 numeric(18, 2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ") ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE ACC_RP_VOCUHER_TEMP(";
                    strSQL = strSQL + "COMP_REF_NO varchar(30) NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NULL,";
                    strSQL = strSQL + "REVERSE_LEDGER varchar(60) NULL,";
                    strSQL = strSQL + "AMOUNT numeric(18, 2) NOT NULL,";
                    strSQL = strSQL + "VOUCHER_TO_BY varchar(2) NULL,";
                    strSQL = strSQL + "VOUCHER_TYPE int NOT NULL,";
                    strSQL = strSQL + "VOUCHER_POSITION int  DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ") ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE MPO_COMM_MAN_PARENT(";
                    strSQL = strSQL + "	COMM_MANUAL_KEY varchar(70) NOT NULL CONSTRAINT PK_COMM_MANUAL_KEY PRIMARY KEY,";
                    strSQL = strSQL + "MONTH_ID VARCHAR(5) NOT NULL CONSTRAINT FK_SALES_COLL_MONTH_ID REFERENCES ACC_MONTH_SETUP(MONTH_ID)ON UPDATE CASCADE,";
                    strSQL = strSQL + "BRANCH_ID char(4) NOT NULL";
                    strSQL = strSQL + "	)";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE MPO_COMM_MAN_PARENT_CHILD(";
                    strSQL = strSQL + "COMM_MANUAL_KEY varchar(70) NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_MPO_COMM_MAN_PARENT_CHILD_LEDGER REFERENCES ACC_LEDGER (LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "HEAD_NAME varchar(60) NOT NULL,";
                    strSQL = strSQL + "AMOUNT numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "COLS numeric(18, 0) default 0 NOT NULL,";
                    strSQL = strSQL + "ROWPOS numeric(18, 0) default 0 NOT NULL";
                    strSQL = strSQL + ") ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE MPO_COMMISSION_PERCENTAGE(";
                    strSQL = strSQL + "COMMISSION_LEDGER varchar(60) NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_MPO_COMMISSION_PERCENTAGE_LEDGER REFERENCES ACC_LEDGER (LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "PERCENTAGES numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "SAL_AMOUNT numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "EFFECTIVE_DATE DATETIME NULL,";
                    strSQL = strSQL + "ACTIVE int default 0 not null";
                    strSQL = strSQL + ") ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //**************************Display Dasboard
                    strSQL = "CREATE TABLE ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(";
                    strSQL = strSQL + "LEDGER_NAME varchar(100) NOT NULL,";
                    strSQL = strSQL + "LEDGER_GROUP_NAME varchar(100) NOT NULL,";
                    strSQL = strSQL + "SAL_TARGET numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "SAL_ACHIEVE numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "COLL_TARGET numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "COLL_ACHIEVE numeric(18, 4) default 0 NOT NULL,";

                    strSQL = strSQL + "M_SAL_TARGET_TOTAL numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "M_SAL_ACHIEVE_TOTAL numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "M_COLL_TARGET_TOTAL numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "M_COLL_ACHIEVE_TOTAL numeric(18, 4) default 0 NOT NULL,";

                    strSQL = strSQL + "Y_SAL_TARGET numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "Y_SAL_ACHIEVE numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "Y_COLL_TARGET numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "Y_COLL_ACHIEVE numeric(18, 4) default 0 NOT NULL,";

                    strSQL = strSQL + "Y_SAL_TARGET_TOTAL numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "Y_SAL_ACHIEVE_TOTAL numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "Y_COLL_TARGET_TOTAL numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "Y_COLL_ACHIEVE_TOTAL numeric(18, 4) default 0 NOT NULL";
                    strSQL = strSQL + ") ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE ACC_FINAL_STATEMENT_DASH(";
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
                    strSQL = strSQL + "POSITION INT  default 9999 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE SALES_COLLECTION_PER_TEMP(";
                    strSQL = strSQL + "ZONE varchar(60) NULL,";
                    strSQL = strSQL + "DIVISION varchar(60) NULL,";
                    strSQL = strSQL + "AREA varchar(60) NULL,";
                    strSQL = strSQL + "TERITORY_NAME varchar(60) NULL,";
                    strSQL = strSQL + "TERITORY_CODE varchar(60) NULL,";
                    strSQL = strSQL + "MEDICAL_REPRESENTATIVE varchar(200) NULL,";
                    strSQL = strSQL + "PREVIOUS_DUES_GOODS numeric(18, 2) default 0 not NULL,";
                    strSQL = strSQL + "TOTAL_SALES_TARGET numeric(18, 2) default 0 not NULL,";
                    strSQL = strSQL + "UPD_TARGET_SALES numeric(18, 2) default 0 not NULL,";
                    strSQL = strSQL + "SALES numeric(18, 2) default 0 not NULL,";
                    strSQL = strSQL + "ACH_PER numeric(18, 2) default 0 not NULL,";
                    strSQL = strSQL + "TOTAL_COLL_TARGET numeric(18, 2) default 0 not NULL,";
                    strSQL = strSQL + "UPD_TARGET_COLL numeric(18, 2) default 0 not NULL,";
                    strSQL = strSQL + "COLLECTION numeric(18, 2) default 0 not NULL,";
                    strSQL = strSQL + "POSITION int default 0 not NULL,";
                    strSQL = strSQL + "CP_SP_GP VARCHAR(30) NULL,";
                    strSQL = strSQL + "LEDGER_NAME_MERZE  VARCHAR(200) NULL,";
                    strSQL = strSQL + "PREVIOUS_SALES  numeric(18, 2) default 0 not NULL";
                    strSQL = strSQL + ") ";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE TWELVE_MONTH_SALES_TEMP(";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME VARCHAR(60) NULL, ";
                    strSQL = strSQL + "STOCKITEM_GROUP VARCHAR(60) NULL,";
                    strSQL = strSQL + "ITEM_CATEGORY VARCHAR(60) NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE INV_PRODUCTION_MASTER(";
                    strSQL = strSQL + "VOUCHER_NO VARCHAR(30) NOT NULL CONSTRAINT PK_INV_PRODUCTION_MASTER_VOUCHER PRIMARY KEY,";
                    strSQL = strSQL + "VOUCHER_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "INV_LOG_NO VARCHAR(50) NOT NULL CONSTRAINT FK_INV_PRODUCTION_MASTER_LOG_NO REFERENCES INV_BATCH(INV_LOG_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BRANCH_ID char(4) NOT NULL CONSTRAINT FK_INV_PRODUCTION_ONE_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID) ON UPDATE CASCADE,";
                    strSQL = strSQL + "CONSUMPTION_GODWNS_NAME varchar(50) NOT NULL CONSTRAINT FK_INV_STOCKITEM_CLOSING_TO_CONSUMPTION_GODWNS_NAME  REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "PROCESS_NAME varchar(50) NOT NULL CONSTRAINT FK_INV_STOCKITEM_CLOSING_PROCESS_NAME  REFERENCES INV_MENU_PROCESS_MAIN(PROCESS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "FG_ITEM varchar(60) NOT NULL CONSTRAINT FK_INV_PRODUCTION_MASTER_FG_ITEM REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "FG_SIZE NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "APP_STATUS INT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "SAMPLE_TO_FG NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "SAMPLE_TO_QC NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "NARRATION varchar(200) NULL ";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE INV_PRODUCTION_CHILD(";
                    strSQL = strSQL + "INV_KEY VARCHAR(50) NOT NULL CONSTRAINT PK_INV_PRODUCTION_INV_KEY PRIMARY KEY,";
                    strSQL = strSQL + "VOUCHER_NO VARCHAR(30) NOT NULL CONSTRAINT FK_INV_PRODUCTION_TOW_LOG_NO REFERENCES INV_PRODUCTION_MASTER(VOUCHER_NO),";
                    strSQL = strSQL + "TO_FG_GODWNS_NAME varchar(50) NOT NULL CONSTRAINT FK_INV_STOCKITEM_CLOSING_TO_FG_GODWNS_NAME  REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_PRODUCTION_CHILD_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKITEM_BASEUNITS varchar(10) NOT NULL CONSTRAINT FK_INV_PRODUCTION_CHILD_BASEUNITS REFERENCES INV_UNIT_MEASUREMENT(UNIT_SYMBOL),";
                    strSQL = strSQL + "RECEIEE_QNTY NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "QNTY NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "RATE NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMNT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PROCESS_TYPE INT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_TRAN_POSITION  INT DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE INV_TRAN_REPACKING(";
                    strSQL = strSQL + "INV_REF_NO VARCHAR(30) NOT NULL CONSTRAINT FK_INV_TRAN_REPACKING_INV_REF_NO REFERENCES INV_MASTER(INV_REF_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_MASTER_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "QNTY NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE DATETIME NULL,";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) NULL CONSTRAINT  FK_INV_TRAN_REPACKING_GODOWNS_NAME REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE PAYMENT_SUMMARY_TEMP(";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NULL,";
                    strSQL = strSQL + "Year1 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Year2 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Year3 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Year4 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Value1 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Value2 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Value3 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Value4 numeric(18, 0) Default 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE Payment_Summary_Monthly_Temp(";
                    strSQL = strSQL + "LEDGER_NAME varchar(255),";
                    strSQL = strSQL + "Month1 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Month2 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Month3 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + " Month4 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Month5 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Month6 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Month7 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Month8 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + " Month9 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Month10 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Month11 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "Month12 numeric(18, 0) Default 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE DAYLI_COLLECTION_TEMP(";
                    strSQL = strSQL + "Voucher_Date smalldatetime NULL,";
                    strSQL = strSQL + "BKashAccount numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "BkashNonActive numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "CashOfHeadOffice numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "PBL01341SND numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "PubaliBankLimitedHerbalSND1260 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "SNDIBBL0028 numeric(18, 0) Default 0 NOT NULL,";
                    strSQL = strSQL + "SoutheastBankSNdAC numeric(18, 0) Default 0 NOT NULL";
                    strSQL = strSQL + ") ";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();



                    //*********************************

                    return strSQL;
                }
                catch (Exception EX)
                {
                    return EX.ToString();
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateInvManufacturingTemp()
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


                    strSQL = "CREATE TABLE INV_MANUFACTURING_TEMP(";
                    strSQL = strSQL + "STOCKITEM_NAME VARCHAR(80) NULL,";
                    strSQL = strSQL + "GROUP_NAME VARCHAR(80) NULL,";
                    strSQL = strSQL + "PREVIOUS_STOCK NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_REF_NO VARCHAR(80) NULL,";
                    strSQL = strSQL + "PROCESS_NAME VARCHAR(80) NULL,";
                    strSQL = strSQL + "GODOWNS_NAME VARCHAR(80) NULL,";
                    strSQL = strSQL + "TO_GODOWNS_NAME VARCHAR(80) NULL,";
                    strSQL = strSQL + "INV_NARRATIONS VARCHAR(300) NULL,";
                    strSQL = strSQL + "INV_VOUCHER_TYPE INT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_DATE DATETIME NULL ,";
                    strSQL = strSQL + "INV_TRAN_QUANTITY NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_TRAN_RATE  NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_TRAN_AMOUNT  NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + " STOCKITEM_BASEUNITS VARCHAR(80) NULL,";
                    strSQL = strSQL + " INV_LOG_NO VARCHAR(80) NULL";
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
        private static string CreateStoreLedgerTemp()
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


                    strSQL = "CREATE TABLE  ACC_STOCK_LEDGER_TEMP(";
                    strSQL = strSQL + "SERIAL_NO NUMERIC(18,0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "INV_REF_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(100) NULL,";
                    strSQL = strSQL + "INV_DATE DATETIME NULL,";
                    strSQL = strSQL + "INV_VOUCHER_TYPE INT,";
                    strSQL = strSQL + "OPNQTY NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "OPNRATE NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "OPNAMNT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INWQTY NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INWRATE NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INWAMNT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "OUTQTY NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "OUTRATE NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "OUTAMNT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CLSQTY NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CLSRATE NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CLSAMNT NUMERIC(18,4) DEFAULT 0 NOT NULL";
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
        private static string CreateTargetDetailTemp()
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


                    strSQL = "CREATE TABLE TARGET_DETAILS_TEMP(";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NULL,";
                    strSQL = strSQL + "STOCK_GROUP_NAME varchar(60) NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_NAME varchar(60) NULL,";
                    strSQL = strSQL + "TARGET_QTY numeric(18, 2) NOT NULL,";
                    strSQL = strSQL + "SALES_QTY numeric(18, 2) NOT NULL,";
                    strSQL = strSQL + "B_QTY numeric(18, 2) NOT NULL";
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
        private static string CreateAccExpenseDump()
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

                    strSQL = "CREATE TABLE ACC_EXPENSE_DUMP(";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NULL,";
                    strSQL = strSQL + "HEAD_NAME varchar(60) NULL,";
                    strSQL = strSQL + "HEAD_NAME1 varchar(60) NULL,";
                    strSQL = strSQL + "CASH_AMOUNT numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "CASH_AMOUNT1 numeric(18, 2) default 0 NOT NULL,";
                    strSQL = strSQL + "REVERSE_LEDGER varchar(60) NULL,";
                    strSQL = strSQL + "COMP_REF_NO varchar(60) NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE DATETIME NULL,";
                    strSQL = strSQL + "CHEQUE_NO varchar(60) NULL,";
                    strSQL = strSQL + "REMARKS varchar(500) NULL,";
                    strSQL = strSQL + "CHECQUE_AMOUNT numeric (18, 2) default 0  NOT NULL,";

                    strSQL = strSQL + "POSITION int default 0 not null ";
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
        private static string CreateAccSalCollTargetAchieve()
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

                    strSQL = "CREATE TABLE ACC_SAL_COLL_TARGET_ACHIEVE(";
                    strSQL = strSQL + "LEDGER_NAME varchar(100) NOT NULL,";
                    strSQL = strSQL + "LEDGER_GROUP_NAME varchar(100) NOT NULL,";
                    strSQL = strSQL + "SAL_TARGET numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "SAL_ACHIEVE numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "COLL_TARGET numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "COLL_ACHIEVE numeric(18, 4) default 0 NOT NULL,";
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
        private static string CreateAccSpCrossJV()
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
                    strSQL = "CREATE TABLE ACC_SP_CROSS_JV(";
                    strSQL = strSQL + "TERITORY_NAME varchar(60) NULL,";
                    strSQL = strSQL + "MR_NAME varchar(60) NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NULL,";
                    strSQL = strSQL + "COMP_REF_NO varchar(60) NULL,";
                    strSQL = strSQL + "AMOUNT numeric(18, 4) default 0 NOT NULL";
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
        private static string CreateInvProductStatementProduction()
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
                    strSQL = "CREATE TABLE INV_PRODUCT_STATEMENT_PRODUCTION(";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(60) NULL,";
                    strSQL = strSQL + "MATARIAL_TYPE varchar(60) NULL,";
                    strSQL = strSQL + "INWARD_VALUE numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "OUTWARD_VALUE numeric(18, 4) default 0 NOT NULL";
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
        private static string CreateInvProductStatementRaw()
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
                    strSQL = "CREATE TABLE INV_PRODUCT_STATEMENT_RAW(";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(60) NULL,";
                    strSQL = strSQL + "MATARIAL_TYPE varchar(60) NULL,";
                    strSQL = strSQL + "OUTWARD_VALUE numeric(18, 4) default 0 NOT NULL";
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



        private static string CreateInvFinishedItemStatement()
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
                    strSQL = "CREATE TABLE INV_FINISHED_ITEM_STATEMENT(";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(60) NULL,";
                    strSQL = strSQL + "ITEM_NAME varchar(60) NULL,";
                    strSQL = strSQL + "OPENING_VALUE numeric(18, 4) default 0  NOT NULL ,";
                    strSQL = strSQL + "INWARD_VALUE numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "SALES_VALUE numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "COMMISSION_VALUE numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "BONUS_VALUE numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "BROKEN_VALUE numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "STAFF_VALUE numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "STAFF_COMMISSION [numeric](18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "SAMPLE_VALUE numeric(18, 4) default 0  NOT NULL";
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
        private static string CreateInvStockPackSize()
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
                    strSQL = "CREATE TABLE INV_STOCK_PACK_SIZE(";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(60) NULL,";
                    strSQL = strSQL + "STOCKITEM_ALIAS varchar(60) NULL,";
                    strSQL = strSQL + "PACK_SIZE_NAME varchar(60) NULL,";
                    strSQL = strSQL + "OPENING_QTY numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "RECIVED_QTY numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "CONVERT_QTY numeric(18, 4)default 0 NOT NULL";
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
        private static string CreateInvStockStatement()
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
                    strSQL = "CREATE TABLE INV_STOCK_STATEMENT(";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(60) NULL,";
                    strSQL = strSQL + "ITEM_NAME varchar(60) NULL,";
                    strSQL = strSQL + "STOCKITEM_ALIAS varchar(60) NULL,";
                    strSQL = strSQL + "OPENING_QTY numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "PRODUCTION_QTY numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "SALES_QTY numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "SAMPLE_QTY numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "RETURN_QTY numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "CONVERT_QTY numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "BROKEN_QTY numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "PHY_STOCK_QTY numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCK_TRANSFER_QTY numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCK_TRANSFER_IN_QTY numeric(18, 4) default 0 NOT NULL,";
                    strSQL = strSQL + "CONSUMPTION_QTY numeric(18, 4) default 0 NOT NULL";
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
       
    private static string CreateFixedAssetSchedule()
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
                    strSQL = "CREATE TABLE FIXED_ASSET_SCHEDULE ( ";
                    strSQL = strSQL + "ASSET_NUMBER varchar (60)  NULL ,";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL ,";
                    strSQL = strSQL + "BRANCH_ID char (4) NULL ,";
                    strSQL = strSQL + "ASSET_PREV_BAL numeric(18, 2) NULL ,";
                    strSQL = strSQL + "ASSET_ADD_THIS_PERIOD numeric(18, 2) NULL ,";
                    strSQL = strSQL + "ASSET_DISPOSAL_THIS_PERIOD numeric(18, 2) NULL ,";
                    strSQL = strSQL + "ASSET_DEP_RATE varchar(10) NULL ,";
                    strSQL = strSQL + "ASSET_DEP_THIS_PERIOD numeric(18, 2) NULL ,";
                    strSQL = strSQL + "ASSET_DEP_ACCU numeric(18, 2) NULL ,";
                    strSQL = strSQL + "ASSET_DEP_ADJUSTMENT numeric(18, 2) NULL,";
                    strSQL = strSQL + "ASSET_PURCHASE_VALUE numeric(18, 2) NULL";
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

        private static string CreateVectorCateReport()
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
                    strSQL = "CREATE TABLE VECTOR_CATEGORY_REPORT (";
                    strSQL = strSQL + "VECTOR_CATEGORY varchar (60) NULL ,";
                    strSQL = strSQL + "VECTOR_MASTER varchar (60) NULL ,";
                    strSQL = strSQL + "VT_TRAN_AMOUNT float NULL ,";
                    strSQL = strSQL + "VT_CURRENCY_SYMBOL varchar (5) NULL";
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
        private static string CreateLedgerCostCenter()
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
                    strSQL = "CREATE TABLE ACC_LEDGER_COST_CENTER_REPORT(";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR (60)  NULL,";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR (60)  NULL,";
                    strSQL = strSQL + "VECTOR_CATEGORY VARCHAR (60)  NULL,";
                    strSQL = strSQL + "VMASTER_NAME VARCHAR (60)  NULL,";
                    strSQL = strSQL + "VT_TRAN_DATE datetime NULL,";
                    strSQL = strSQL + "VT_CURRENCY_SYMBOL varchar (5) NULL,";
                    strSQL = strSQL + "VECTOR_TRANSACTION numeric (12,2) default 0 NOT NULL,";
                    strSQL = strSQL + "OPENING numeric (12,2) default 0 NOT NULL,";
                    strSQL = strSQL + "CLOSING numeric (12,2) default 0 NOT NULL";
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

        private static string CreateCostCenterOpeingDump()
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
                    strSQL = "CREATE TABLE ACC_COST_CENTER_OPENING_REPORT(";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR (60)  NULL,";
                    strSQL = strSQL + "VECTOR_CATEGORY VARCHAR (60)  NULL,";
                    strSQL = strSQL + "VMASTER_NAME VARCHAR (60)  NULL,";
                    strSQL = strSQL + "VT_TRAN_DATE datetime DEFAULT '01-01-1900' NULL,";
                    strSQL = strSQL + "VECTOR_TRANSACTION numeric (12,2) default 0 NOT NULL";
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

        private static string CreateMonthlySummaryDummy()
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
                    strSQL = "CREATE TABLE ACC_MONTHLY_SUMMARY ( ";
                    strSQL = strSQL + "MONTH_ID [char] (6)  NULL ,";
                    strSQL = strSQL + "DEBIT numeric(18, 2) NULL ,";
                    strSQL = strSQL + "CREDIT numeric(18, 2) NULL ";
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
        private static string CreateReceiveAndPaymentComp()
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
                    strSQL = "CREATE TABLE ACC_RECEIPT_AND_PAYMENT_COMP(";
                    strSQL = strSQL + "GR_NO numeric(15,0) IDENTITY(1,1) CONSTRAINT PK_ACC_RECEIPT_AND_PAYMENT_COMP PRIMARY KEY,";
                    strSQL = strSQL + "GR_NAME varchar(100) NULL,";
                    strSQL = strSQL + "GR_PARENT varchar(100) NULL,";
                    strSQL = strSQL + "GR_PRIMARY_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "GR_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GR_RECEIPT_PAYMENT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "FROM_TO varchar(50) NULL,";
                    strSQL = strSQL + "BRANCH_NAME VARCHAR(60) NULL";
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
        private static string CreateReceiveAndPayment()
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
                    strSQL = "CREATE TABLE ACC_RECEIPT_AND_PAYMENT(";
                    strSQL = strSQL + "GR_NO numeric(15,0) IDENTITY(1,1) CONSTRAINT PK_ACC_RECEIPT_AND_PAYMENT PRIMARY KEY,";
                    strSQL = strSQL + "GR_NAME varchar(100) NULL,";
                    strSQL = strSQL + "GR_PARENT varchar(100) NULL,";
                    strSQL = strSQL + "GR_PRIMARY_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "GR_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GR_RECEIPT_PAYMENT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BRANCH_NAME VARCHAR(50) NULL";
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
        private static string CreateTrailBalance()
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
                        strSQL = "CREATE TABLE ACC_TRIAL_BALANCE(";
                        strSQL = strSQL + "GR_NAME varchar(100) NULL,";
                        strSQL = strSQL + "GR_PARENT varchar(100) NULL,";
                        strSQL = strSQL + "GR_OPENING numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "GR_DEBIT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "GR_CREDIT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "BRANCH_NAME VARCHAR(50) NULL";
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
         private static string CreateGroupSummary()
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
                        strSQL = "CREATE TABLE ACC_GROUP_SUMMARY(";
                        strSQL = strSQL + "GR_NAME varchar(100) NULL,";
                        strSQL = strSQL + "GR_PARENT varchar(100) NULL,";
                        strSQL = strSQL + "GR_OPENING numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "GR_DEBIT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "GR_CREDIT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "GR_ADDRESS1 varchar(150) NULL,";
                        strSQL = strSQL + "GR_ADDRESS2 varchar(150) NULL,";
                        strSQL = strSQL + "GR_PHONE_NO varchar(100) NULL,";
                        strSQL = strSQL + "STUDENT_ID VARCHAR(30) NULL ,";
                        strSQL = strSQL + "SESSION_NAME VARCHAR(60) NULL, ";
                        strSQL = strSQL + "SMA_YEAR VARCHAR(30) NULL,";
                        strSQL = strSQL + "CLASS_ROLL_NO VARCHAR(60) NULL,";
                        strSQL = strSQL + "CLASS_NAME VARCHAR(60) NULL,";
                        strSQL = strSQL + "SECTION_NAME VARCHAR(60) NULL,";
                        strSQL = strSQL + "MOBILE_NO VARCHAR(60) NULL,";
                        strSQL = strSQL + "CONTACT_NO_HOME VARCHAR(60) NULL ";
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

         private static string CreateBalanceSheetData1()

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
                        strSQL = "CREATE TABLE ACC_BALANCE_SHEET_1(";
                        strSQL = strSQL + "GR_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_BALANCE_SHEET_1 PRIMARY KEY,";
                        strSQL = strSQL + "GR_NAME VARCHAR (100)  NULL,";
                        strSQL = strSQL + "GR_PARENT VARCHAR (100)  NULL,";
                        strSQL = strSQL + "GR_PRIMARY_TYPE smallint DEFAULT 0 NOT NULL,";   // 'Asset = 1, Lia = 2, Income = 3, Expen =4
                        strSQL = strSQL + "GR_2ND_TYPE smallint DEFAULT 0 NOT NULL,";
                        strSQL = strSQL + "GR_3RD_TYPE smallint DEFAULT 0 NOT NULL,";
                        strSQL = strSQL + "GR_4TH_TYPE smallint DEFAULT 0 NOT NULL,";
                        strSQL = strSQL + "GR_AMOUNT numeric (18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "GR_AMOUNT1 numeric (18,2) default 0 NOT NULL";
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

        private static string CreateBalanceSheetCompData()
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
   
                        strSQL = "CREATE TABLE ACC_BALANCE_SHEET_COMPARISON(";
                        strSQL = strSQL + "GR_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_BALANCE_SHEET_COMPARISON PRIMARY KEY,";
                        strSQL = strSQL + "GR_NAME VARCHAR (100)  NULL,";
                        strSQL = strSQL + "GR_PARENT VARCHAR (100)  NULL,";
                        strSQL = strSQL + "GR_PRIMARY_TYPE smallint DEFAULT 0 NOT NULL,"; //   'Asset = 1, Lia = 2, Income = 3, Expen =4
                        strSQL = strSQL + "GR_AMOUNT numeric (18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "COMPANY_ID char(4) NULL, ";
                        strSQL = strSQL + "BRANCH_NAME VARCHAR(60) NULL, ";
                        strSQL = strSQL + "ASON_DATE datetime NULL ";
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

         private static string CreateBalanceSheetData()

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
                        strSQL = "CREATE TABLE ACC_BALANCE_SHEET(";
                        strSQL = strSQL + "GR_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_BALANCE_SHEET PRIMARY KEY,";
                        strSQL = strSQL + "GR_NAME VARCHAR (100)  NULL,";
                        strSQL = strSQL + "GR_PARENT VARCHAR (100)  NULL,";
                        strSQL = strSQL + "GR_PRIMARY_TYPE smallint DEFAULT 0 NOT NULL," ;  // 'Asset = 1, Lia = 2, Income = 3, Expen =4
                        strSQL = strSQL + "GR_AMOUNT numeric (18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "COMPANY_NAME VARCHAR(100) NULL,";
                        strSQL = strSQL + "BRANCH_NAME VARCHAR(50) NULL";
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

        private static string CreateBalanceSheetTemp()
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
            strSQL = "CREATE TABLE ACC_BALANCE_SHEET_TEMP(";
            strSQL = strSQL + "GR_NO numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_BALANCE_SHEET_TEMP PRIMARY KEY,";
            strSQL = strSQL + "GR_NAME VARCHAR (100)  NULL,";
            strSQL = strSQL + "GR_PARENT VARCHAR (100)  NULL,";
            strSQL = strSQL + "GR_PRIMARY_TYPE smallint DEFAULT 0 NOT NULL,";//    'Asset = 1, Lia = 2, Income = 3, Expen =4
            strSQL = strSQL + "GR_AMOUNT numeric (18,2) default 0 NOT NULL,";
            strSQL = strSQL + "BRANCH_NAME VARCHAR(100) NULL";
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

     private static string CreateTrading()
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
            strSQL = "CREATE TABLE ACC_TRADING_REPORT(";
            strSQL = strSQL + "GR_NAME VARCHAR (50)  NULL,";
            strSQL = strSQL + "GR_PARENT VARCHAR (50)  NULL,";
            strSQL = strSQL + "GR_PRIMARY_TYPE numeric(18,2) default 0 NOT NULL,";//    'Asset = 1, Lia = 2, Income = 3, Expen =4
            strSQL = strSQL + "GR_AMOUNT numeric (18,2) default 0 NOT NULL";
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

     private static string CreateCashFlowComp()

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
            strSQL = "CREATE TABLE ACC_CASH_FLOW_COMP(";
            strSQL = strSQL + "CASHFLOW_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_CASH_FLOW_COMP PRIMARY KEY,";
            strSQL = strSQL + "CASHFLOW_TYPE smallint DEFAULT 0 NOT NULL,";//    'Operating = 1, Investing = 2, Finan = 3
            strSQL = strSQL + "CASHFLOW_SIGN smallint DEFAULT 0 NOT NULL,";//    '1 = Opening, 2= + , 3 = -
            strSQL = strSQL + "CASHFLOW_GROUP VARCHAR (50)  NULL,";
            strSQL = strSQL + "CASHFLOW_LEDGER VARCHAR (60)  NULL,";
            strSQL = strSQL + "CASHFLOW_AMOUNT numeric (18,2) default 0 NOT NULL,";
            strSQL = strSQL + "FROM_TO varchar(50) NULL ";
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
         private static string CreateCashFlow()

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
                        strSQL = "CREATE TABLE ACC_CASH_FLOW(";
                        strSQL = strSQL + "CASHFLOW_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_CASH_FLOW PRIMARY KEY,";
                        strSQL = strSQL + "CASHFLOW_TYPE smallint DEFAULT 0 NOT NULL,";//    'Operating = 1, Investing = 2, Finan = 3
                        strSQL = strSQL + "CASHFLOW_SIGN smallint DEFAULT 0 NOT NULL," ;//   '1 = Opening, 2= + , 3 = -
                        strSQL = strSQL + "CASHFLOW_GROUP VARCHAR (50)  NULL,";
                        strSQL = strSQL + "CASHFLOW_LEDGER VARCHAR (60)  NULL,";//
                        strSQL = strSQL + "CASHFLOW_AMOUNT numeric (18,2) default 0 NOT NULL";
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

        private static string CreateProfitAndLossGroup()
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
                        strSQL = "CREATE TABLE ACC_PROFIT_AND_LOSS_GROUP(";
                        strSQL = strSQL + "GR_SERIAL numeric (18,0) IDENTITY (1,1),";
                        strSQL = strSQL + "GR_NAME VARCHAR (100)  NULL,";
                        strSQL = strSQL + "GR_PARENT VARCHAR (100)  NULL,";
                        strSQL = strSQL + "GR_PRIMARY_TYPE smallint DEFAULT 0 NOT NULL,";//    'Asset = 1, Lia = 2, Income = 3, Expen =4
                        strSQL = strSQL + "GR_AMOUNT numeric (18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "COMPANY_NAME VARCHAR (50) NULL ";
                        //'REFERENCES ACC_COMPANY(COMPANY_ID)"
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

     private static string CreateProfitAndLossV()
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
                        strSQL = "CREATE TABLE ACC_PROFIT_AND_LOSS_V(";
                        strSQL = strSQL + "GR_SERIAL numeric (18,0) IDENTITY (1,1),";
                        strSQL = strSQL + "GR_NAME VARCHAR (100)  NULL,";
                        strSQL = strSQL + "GR_PARENT VARCHAR (100)  NULL,";
                        strSQL = strSQL + "GR_PRIMARY_TYPE smallint DEFAULT 0 NOT NULL,";   // 'Asset = 1, Lia = 2, Income = 3, Expen =4
                        strSQL = strSQL + "GR_SECONDARY_TYPE smallint DEFAULT 0 NOT NULL,";
                        strSQL = strSQL + "GR_AMOUNT numeric (18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "BRANCH_NAME VARCHAR(50) NULL";
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

         private static string CreateProfitAndLossComp()
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
                        strSQL = "CREATE TABLE ACC_PROFIT_AND_LOSS_COMP(";
                        strSQL = strSQL + "GR_SERIAL numeric (18,0) IDENTITY (1,1),";
                        strSQL = strSQL + "GR_NAME VARCHAR (50)  NULL,";
                        strSQL = strSQL + "GR_PARENT VARCHAR (50)  NULL,";
                        strSQL = strSQL + "GR_PRIMARY_TYPE smallint DEFAULT 0 NOT NULL,";//    'Asset = 1, Lia = 2, Income = 3, Expen =4
                        strSQL = strSQL + "GR_AMOUNT numeric (18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "FROM_TO varchar(50) NULL,";
                        strSQL = strSQL + "BRANCH_NAME VARCHAR(50) NULL";
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
         private static string CreateProfitAndLoss()

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
                        strSQL = "CREATE TABLE ACC_PROFIT_AND_LOSS(";
                        strSQL = strSQL + "GR_SERIAL numeric (18,0) IDENTITY (1,1),";
                        strSQL = strSQL + "GR_NAME VARCHAR (50)  NULL,";
                        strSQL = strSQL + "GR_PARENT VARCHAR (50)  NULL,";
                        strSQL = strSQL + "GR_PRIMARY_TYPE smallint DEFAULT 0 NOT NULL," ;//   'Asset = 1, Lia = 2, Income = 3, Expen =4
                        strSQL = strSQL + "GR_AMOUNT numeric (18,2) default 0 NOT NULL";
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
         private static string CreateProfitAndLossTemp()

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
                        strSQL = "CREATE TABLE ACC_PROFIT_AND_LOSS_TEMP(";
                        strSQL = strSQL + "GR_NAME VARCHAR (50)  NULL,";
                        strSQL = strSQL + "GR_PARENT VARCHAR (50) NULL,";
                        strSQL = strSQL + "GR_PRIMARY_TYPE smallint DEFAULT 0 NOT NULL,";
                        strSQL = strSQL + "GR_AMOUNT numeric (12,2) default 0 NOT NULL";
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
         private static string CreateBillTranDum()
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
                        strSQL = "CREATE TABLE ACC_BILL_TRAN_DUM(";
                        strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL ,";
                        strSQL = strSQL + "COMP_VOUCHER_TYPE smallint default 0 NOT NULL,";
                        strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL,";
                        strSQL = strSQL + "STOCKITEM_NAME varchar(200) NULL,";//  'NEW FIELD ADD
                        strSQL = strSQL + "LEDGER_NAME varchar(60) NULL ,";
                        strSQL = strSQL + "BILL_QUANTITY numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "BILL_RATE numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "BILL_UOM VARCHAR(10) NULL,";
                        strSQL = strSQL + "BILL_NET_AMOUNT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "AGNST_COMP_REF_NO VARCHAR(30) NULL,";
                        strSQL = strSQL + "BILL_QUANTITY_BONUS numeric(18,2) default 0 NOT NULL";
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

         private static string CreateGrpSummaryMonthWise()
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

                        strSQL = "CREATE TABLE ACC_GROUP_SUMMARY_MONTH_WISE_RPT(";
                        strSQL = strSQL + "GR_NAME VARCHAR (50)  NULL,";
                        strSQL = strSQL + "JA1N_S numeric (18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "JA2N_S numeric (18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "JA3N_S numeric (18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "JA4N_S numeric (18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "JA5N_S numeric (18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "JA6N_S numeric (18,2) default 0 NOT NULL";
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

         private static string CreateManufacturing()

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
                        strSQL = "CREATE TABLE ACC_MANUFACTURE_REPORT ( ";
                        strSQL = strSQL + "MANUFACTURE_SERIAL numeric (18,0) IDENTITY (1,1),";
                        strSQL = strSQL + "MANUFACTURE_TYPE numeric(5,2) default 0 NOT NULL,";
                        strSQL = strSQL + "MANUFACTURE_SUB_TYPE smallint default 0 NOT NULL,";
                        strSQL = strSQL + "MANUFACTURE_NAME varchar (60)  NOT NULL,";
                        strSQL = strSQL + "MANUFACTURE_GROUP varchar (50)  NOT NULL,";
                        strSQL = strSQL + "MANUFACTURE_AMOUNT numeric(18,2) default 0 NOT NULL";
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
             private static string CreateBudgetReport()

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

                        strSQL = "CREATE TABLE ACC_BUDGET_REPORT ( ";
                        strSQL = strSQL + "BUDGET_NAME varchar (60)  NOT NULL,";
                        strSQL = strSQL + "LEDGER_NAME varchar (60)  NOT NULL,";
                        strSQL = strSQL + "BUDGET_TYPE smallint default 0 NOT NULL,";
                        strSQL = strSQL + "BUDGET_AMOUNT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "BUDGET_ACTUAL numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "BRANCH_ID char (4) NOT NULL ";
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

         private static string CreateTradingAndProfitLossLedger()
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
                        strSQL = "CREATE TABLE ACC_TRADING_PROFIT_LOSS_LEDGER(";
                        strSQL = strSQL + "GR_NAME VARCHAR (50)  NULL,";
                        strSQL = strSQL + "GR_PARENT VARCHAR (50)  NULL,";
                        strSQL = strSQL + "GR_TYPE smallint default 0 NOT NULL," ;//   '1 = Trading, 2 = PL
                        strSQL = strSQL + "GR_SUB_TYPE smallint default 0 NOT NULL,";//    ' 1 = Sales, = 2 = CGS
                        strSQL = strSQL + "GR_AMOUNT numeric (18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "GR_AMOUNT_YTD numeric (18,2) default 0 NOT NULL";
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
         private static string CreateVoucherChildFC()
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
                        strSQL = "CREATE TABLE ACC_VOUCHER_CHILD_FC(";
                        strSQL = strSQL + "CHILD_SERIAL numeric (18,0) IDENTITY (1,1),";
                        strSQL = strSQL + "BRANCH_ID char (4) NULL,";
                        strSQL = strSQL + "COMP_REF_NO varchar(30) NULL,";
                        strSQL = strSQL + "LEDGER_NAME varchar(60) NULL,";
                        strSQL = strSQL + "CHILD_AMOUNT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "CHILD_AMOUNT_FC numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "CHILD_TOBY varchar(2) NULL,";
                        strSQL = strSQL + "CHEQUE_NO varchar(50) NULL,";
                        strSQL = strSQL + "CHEQUE_DATE datetime NULL";
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

     private static string CreateVoucherChild()
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
                        strSQL = "CREATE TABLE ACC_VOUCHER_CHILD(";
                        strSQL = strSQL + "CHILD_SERIAL numeric (18,0) IDENTITY (1,1),";
                        strSQL = strSQL + "BRANCH_ID char (4) NULL,";
                        strSQL = strSQL + "COMP_REF_NO varchar(30) NULL,";
                        strSQL = strSQL + "LEDGER_NAME varchar(200) NULL,";
                        strSQL = strSQL + "CHILD_AMOUNT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "CHILD_TOBY varchar(2) NULL,";
                        strSQL = strSQL + "CHEQUE_NO varchar(50) NULL,";
                        strSQL = strSQL + "CHEQUE_DATE datetime NULL";
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

         private static string CreateVoucherParentFC()
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
                        strSQL = "CREATE TABLE ACC_VOUCHER_PARENT_FC(";
                        strSQL = strSQL + "VOUCHER_SERIAL numeric (18,0) IDENTITY (1,1),";
                        strSQL = strSQL + "COMP_REF_NO varchar(30) NULL,";
                        strSQL = strSQL + "BRANCH_ID char (4) NULL,";
                        strSQL = strSQL + "COMP_VOUCHER_TYPE smallint NOT NULL,";
                        strSQL = strSQL + "COMP_VOUCHER_DATE datetime NULL,";
                        strSQL = strSQL + "LEDGER_NAME varchar(200) NULL,";
                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "VOUCHER_CREDIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT_FC numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "VOUCHER_CREDIT_AMOUNT_FC numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "VOUCHER_TOBY varchar(2) NULL,";
                        strSQL = strSQL + "VOUCHER_BANK_DATE datetime NULL,";
                        strSQL = strSQL + "CHEQUE_NO varchar(50) NULL,";
                        strSQL = strSQL + "CHEQUE_DATE datetime NULL,";
                        strSQL = strSQL + "CHEQUE_DRAWN_ON VARCHAR(50) NULL,";
                        strSQL = strSQL + "VOUCHER_NARRATION VARCHAR(300) NULL";
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

         private static string CreateVoucherParent()
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
                        strSQL = "CREATE TABLE ACC_VOUCHER_PARENT(";
                        strSQL = strSQL + "VOUCHER_SERIAL numeric (18,0) IDENTITY (1,1),";
                        strSQL = strSQL + "COMP_REF_NO varchar(30) NULL,";
                        strSQL = strSQL + "BRANCH_ID char (4) NULL ,";
                        strSQL = strSQL + "COMP_VOUCHER_TYPE smallint NOT NULL,";
                        strSQL = strSQL + "COMP_VOUCHER_DATE datetime NULL,";
                        strSQL = strSQL + "LEDGER_NAME varchar(200) NULL,";
                        strSQL = strSQL + "LEDGER_HEAD varchar(200) NULL,";
                        strSQL = strSQL + "LEDGER_NAME_MERZE varchar(200) NULL,";
                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "VOUCHER_CREDIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "VOUCHER_TOBY varchar(2) NULL,";
                        strSQL = strSQL + "VOUCHER_BANK_DATE datetime NULL,";
                        strSQL = strSQL + "CHEQUE_NO varchar(50) NULL,";
                        strSQL = strSQL + "CHEQUE_DATE datetime NULL,";
                        strSQL = strSQL + "VOUCHER_NARRATION VARCHAR(300) NULL,";
                        strSQL = strSQL + "CHEQUE_DRAWN_ON VARCHAR(50) NULL ";
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

         private static string CreateLedgerMultiCashBank()
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
                        strSQL = "CREATE TABLE ACC_LEDGER_MULTI_CASH_BANK(";
                        strSQL = strSQL + "LEDGER_NAME VARCHAR (60)  NULL,";
                        strSQL = strSQL + "COMP_VOUCHER_DATE datetime NULL,";
                        strSQL = strSQL + "VOUCHER_TOBY char (3) NULL,";
                        strSQL = strSQL + "VOUCHER_REVERSE_LEDGER varchar (60) NULL ,";
                        strSQL = strSQL + "AMOUNT numeric (12,2) default 0 NOT NULL,";
                        strSQL = strSQL + "VOUCHER_DRCR char (3) NULL,";
                        strSQL = strSQL + "TRAN_TYPE smallint default 1 NOT NULL";//    '0=Open,1=Tran, 2 = Close
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

    private static string CreateLedgerReportFC()
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

                        strSQL = "CREATE TABLE ACC_LEDGER_REPORT_FC(";
                        strSQL = strSQL + "LEDGER_REPORT_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_LEDGER_REPORT_FC PRIMARY KEY,";
                        strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL ,";
                        strSQL = strSQL + "VOUCHER_TOBY varchar(2) NOT NULL,";
                        strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL,";//  'Sub Group/Ledger
                        strSQL = strSQL + "COMP_VOUCHER_TYPE smallint DEFAULT 0 NOT NULL,";
                        strSQL = strSQL + "COMP_REF_NO varchar(30) NULL,";
                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "VOUCHER_CREDIT_AMOUNT numeric(18,2) default 0 NOT NULL, ";
                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT_FC numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "VOUCHER_CREDIT_AMOUNT_FC numeric(18,2) default 0 NOT NULL, ";
                        strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                        strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER VARCHAR(30) NULL, ";
                        strSQL = strSQL + "VOUCHER_CHEQUE_DATE datetime NULL, ";
                        strSQL = strSQL + "BRANCH_ID char (4) NOT NULL";
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


     private static string CreateLedgerReport()

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

                        strSQL = "CREATE TABLE ACC_LEDGER_REPORT(";
                        strSQL = strSQL + "LEDGER_REPORT_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_LEDGER_REPORT PRIMARY KEY,";
                        strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL ,";
                        strSQL = strSQL + "VOUCHER_TOBY varchar(2) NOT NULL,";
                        strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL,";//  'Sub Group/Ledger
                        strSQL = strSQL + "COMP_VOUCHER_TYPE smallint DEFAULT 0 NOT NULL,";
                        strSQL = strSQL + "COMP_REF_NO varchar(30) NULL,";
                        strSQL = strSQL + "VOUCHER_DEBIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "VOUCHER_CREDIT_AMOUNT numeric(18,2) default 0 NOT NULL,";
                        strSQL = strSQL + "VOUCHER_CHEQUE_NUMBER VARCHAR(30) NULL, ";
                        strSQL = strSQL + "VOUCHER_CHEQUE_DATE datetime NULL,";
                        strSQL = strSQL + "BRANCH_ID char (4) NOT NULL";
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

         private static string CreateTradingAndProfitLoss()
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
                        strSQL = "CREATE TABLE ACC_TRADING_PROFIT_LOSS(";
                        strSQL = strSQL + "GR_NAME VARCHAR (50)  NULL,";
                        strSQL = strSQL + "GR_PARENT VARCHAR (50)  NULL,";
                        strSQL = strSQL + "GR_TYPE smallint default 0 NOT NULL,";// ;   'Asset = 1, Lia = 2, Income = 3, Expen =4
                        strSQL = strSQL + "GR_SUB_TYPE smallint default 0 NOT NULL," ;//   '
                        strSQL = strSQL + "GR_GROUP smallint default 0 NOT NULL,";
                        strSQL = strSQL + "GR_PRIMARY_TYPE numeric(18,2) default 0 NOT NULL,";//    'Asset = 1, Lia = 2, Income = 3, Expen =4
                        strSQL = strSQL + "GR_AMOUNT numeric (18,2) default 0 NOT NULL";
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

         private static string CreateRatioAnalysis()
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
                        strSQL = "CREATE TABLE ACC_RATIO_ANALYSIS(";
                        strSQL = strSQL + "RATIO_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_RATIO_ANALYSIS PRIMARY KEY,";
                        strSQL = strSQL + "RATIO_HEAD VARCHAR (60)  NULL,";
                        strSQL = strSQL + "RATIO_SUB VARCHAR (60)  NULL,";
                        strSQL = strSQL + "RATIO_AMOUNT VARCHAR (60)  NULL,";
                        strSQL = strSQL + "RATIO_AMOUNT_GOOD VARCHAR (60)  NULL";
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
         private static string CreateRatioMainGroup()
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
                        strSQL = "CREATE TABLE ACC_RATIO_MAINGROUP(";
                        strSQL = strSQL + "RATIO_MAINGROUP_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_RATIO_MAINGROUP PRIMARY KEY,";
                        strSQL = strSQL + "RATIO_MAINGROUP VARCHAR (60)  NULL,";
                        strSQL = strSQL + "RATIO_SUBGROUP VARCHAR (60)  NULL,";
                        strSQL = strSQL + "RATIO_AMOUNT numeric (18,2) default 0 NOT NULL";
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
         private static string CreateBatchReport()
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
                        strSQL = "CREATE TABLE INV_BATCH_REPORT (";
                        strSQL = strSQL + "INV_LOG_NO varchar (50) NOT NULL ,";
                        strSQL = strSQL + "INV_FG varchar (50) NOT NULL ,";
                        strSQL = strSQL + "INV_VOUCHER_TYPE numeric(18, 0) NOT NULL ,";
                        strSQL = strSQL + "STOCKITEM_NAME varchar (60) NOT NULL ,";
                        strSQL = strSQL + "INV_AMOUNT numeric(18, 2) NOT NULL ,";
                        strSQL = strSQL + "INV_QTY Numeric(18, 2),";
                        strSQL = strSQL + "INV_DATE datetime null";
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
         private static string CreateBatchReportDetails()
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

                        strSQL = "CREATE TABLE INV_BATCH_REPORT_DETAILS (";
                        strSQL = strSQL + "INV_LOG_NO varchar (50) NOT NULL ,";
                        strSQL = strSQL + "INV_REF_NO VARCHAR(30) NOT NULL,";
                        strSQL = strSQL + "INV_DATE datetime NULL,";
                        strSQL = strSQL + "INV_VOUCHER_TYPE smallint default 0 NOT NULL,";//    '0 = No, 1 = Yes
                        strSQL = strSQL + "STOCKITEM_NAME varchar (60) NOT NULL ,";
                        strSQL = strSQL + "INV_QTY Numeric(18, 2) default 0 NOT NULL,";
                        strSQL = strSQL + "INV_AMOUNT numeric(18, 2) default 0 NOT NULL";
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
         private static string CreateStockSummaryVoucherWise()
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
                        strSQL = "CREATE TABLE INV_STOCK_SUMMARY_VOUCHER_WISE(";
                        strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL,";
                        strSQL = strSQL + "INV_VOUCHER_TYPE smallint DEFAULT 0 NOT NULL,";
                        strSQL = strSQL + "INV_TRAN_QUANTITY numeric(18,4) default 0 NOT NULL";
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
         private static string CreateBillWiseYear()
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
                        strSQL = "CREATE TABLE ACC_BILL_WISE_YEAR_3(";
                        strSQL = strSQL + "LEDGER_NAME VARCHAR (60)  NULL,";
                        strSQL = strSQL + "YEAR_NAME VARCHAR (50)  NULL,";
                        strSQL = strSQL + "AMOUNT numeric (14,2) default 0 NOT NULL";
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
     private static string CreateGeneralLedger()
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

                    strSQL = "CREATE TABLE ACC_GENERAL_LEDGER(";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NULL ,";
                    strSQL = strSQL + "OPENING_BALANCE numeric(18,2) default 0 NOT NULL ";
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

         private static string CreateGeneralLedgerView()
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
                    strSQL = "CREATE VIEW ACC_GENERAL_LEDGER_VIEW AS ";
                    strSQL = strSQL + "SELECT LEDGER_NAME,SUM(OPENING_BALANCE) AS OPENING_BALANCE ";
                    strSQL = strSQL + "FROM ACC_GENERAL_LEDGER ";
                    strSQL = strSQL + "GROUP BY LEDGER_NAME ";
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
        private static string CreateCostcenterLedgertemp()
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
                    strSQL = "CREATE table SMART_COST_CENTER_LED_TEMP(";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(100) NULL,";
                    strSQL = strSQL + "VMASTER_NAME VARCHAR(100) NULL,";
                    strSQL = strSQL + "TRAN_DATE DATETIME  NULL,";
                    strSQL = strSQL + "OPN_BALANCE NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "DR_BALANCE NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CR_BALANCE NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "VT_TRAN_TOBY CHAR(2)  NULL,";
                    strSQL = strSQL + "CLOSING_BALANCE NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "CLOSING_BALANCE_DR NUMERIC(18,2) DEFAULT 0 NOT NULL ";
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

        private static string CreateTranDate()
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
                        cmd.Connection=gcnmain;
                        strSQL = "CREATE table ACC_TRANSACTION_DATE(";
                        strSQL = strSQL + "LEDGER_NAME VARCHAR(100) NULL,";
                        strSQL = strSQL + "COMP_VOUCHER_DATE datetime DEFAULT GETDATE() NOT NULL,";
                        strSQL = strSQL + "AGE numeric(18,2) default 0 not null";
                        strSQL = strSQL + ")";
                        cmd.CommandText = strSQL;
                        cmd.ExecuteNonQuery();
                        strSQL = "CREATE table ACC_TRANSACTION_DATE_DUMP(";
                        strSQL = strSQL + "LEDGER_NAME VARCHAR(100) NULL,";
                        strSQL = strSQL + "COMP_VOUCHER_DATE datetime DEFAULT GETDATE() NOT NULL,";
                        strSQL = strSQL + "AGE numeric(18,2) default 0 not null";
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
