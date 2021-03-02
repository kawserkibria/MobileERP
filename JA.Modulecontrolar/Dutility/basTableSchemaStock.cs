using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dutility
{
    public class basTableSchemaStock
    {
        public static string gCreateStock()
        {
            string strSQL;
            strSQL = CreateStockInvMaterialType();
            strSQL = CreateStockInvSectionName();
            strSQL = CreateStockInvGroupCommMaster();
            strSQL = CreateStockInvGroupCommTran();
            strSQL = CreateStockInvGroupMaster();
            strSQL = CreateStockInvSalesRepresentative();
            strSQL = CreateLocations();
            strSQL = CreateStockGroup();
            strSQL = CreateStockCategory();
            strSQL = CreateStockCategoryOthers();
            strSQL = CreateStockOthers();
            strSQL = CreateInvUnitMeasurement();
            strSQL = CreateSlowMoving();
            strSQL = CreateStockItem();
            strSQL = CreateStockItemLevel();
            strSQL = CreateStockItemClosing();
            strSQL = CreateProcessMain();
            strSQL = CreateProcess();
            strSQL = CreateSalesPrice();
            strSQL = CreateInvGroupToStock();
            strSQL = CreateStockItemToGroup();
            strSQL = CreateInventoryMaster();
            strSQL = CreateInventoryTransaction();
            strSQL = CreateInventoryConfig();
            strSQL = CreateInventoryOption();
            strSQL = CreateInvAdjustemnts();
            strSQL = CreateQuotationTran();
            strSQL = CreateQuotationConfig();
            strSQL = CreateInvBillofMaterials();
            strSQL = CreateBillTranProcess();
            strSQL = CreateInventoryStockSummary();
            strSQL = CreateInventoryStockOpening();
            strSQL = CreateProductionLog();
            strSQL = CreateInvBatch();
            strSQL = CreateInvEffect();
            strSQL = CreateInvProfitReport();
            strSQL = CreateBillTran();
            strSQL = CreateMarkUp();
            strSQL = CreateInvStockItemSerialMaster();
            strSQL = CreateInvStockItemSerial();
            strSQL = CreateSalesBonus();
            strSQL = CreateSalesGift();
            strSQL = CreateAccPOSConfig();
            strSQL = CreateCompanyVoucherPOSMaster();
            strSQL = CreateCompanyVoucherPOSTran();
            strSQL = CreateVoucherBatch();
            //strSQL = CreateVoucherBatchApp();
            strSQL = CreateStockRequisitionMaster();
            strSQL = CreateStockRequisitionChild();
            strSQL = CreateStockRequisition();
            strSQL = CreateBookingInformationMaster();
            strSQL = CreateBookingInformationChild();
            strSQL = CreateAdmissionForm();
            strSQL = CreateConfig();
            strSQL = CreateLogo();
            strSQL = CreateTableSalesStock();
            strSQL = CreateBarcoteImage();
            strSQL = mCreateDumpLedger();
            strSQL = mCreateBatchConfig();
            strSQL = CreateTableSMS();
            strSQL = CreateGuaranteeCard();
            strSQL = CreateStockMultipleItem();
            strSQL = CreateManualStockTemp();
            strSQL = CreateCopyPurPrice();
            strSQL = CreateItemSLHW();
            //strSQL = CreateBillTran_Appr();
            //strSQL = CreateBillTranProcessApp();
            strSQL = CreateAccLedgerStockAmnout();
            strSQL = CreateUserPrivilegesBranch();
            strSQL = CreateItePackTarget();
            return strSQL;
        }
        private static string CreateItePackTarget()
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
                    strSQL = "CREATE TABLE SALES_TARGET_ITEM_PACK_MASTER(";
                    strSQL = strSQL + " TARGET_ITEM_PACK_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "TARGET_ITEM_PACK_KEY varchar(100) NOT NULL CONSTRAINT PK_TARGET_ITEM_PACK_KEY PRIMARY KEY,";
                    strSQL = strSQL + "TARGET_ITEM_PACK_FROM_DATE datetime NOT NULL,";
                    strSQL = strSQL + "TARGET_ITEM_PACK_TO_DATE datetime NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char(4) NULL,";
                    strSQL = strSQL + "ITEM_TYPE SMALLINT DEFAULT 0 NOT NULL ";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE SALES_TARGET_ITEM_TRAN(";
                    strSQL = strSQL + "TARGET_ITEM_TRAN_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "TARGET_ITEM_TRAN_KEY_REF varchar(200) NOT NULL CONSTRAINT UQ_TARGET_ITEM_PACK_TRAN_KEY_REF UNIQUE,";
                    strSQL = strSQL + "TARGET_ITEM_TRAN_KEY varchar(100) NOT NULL CONSTRAINT FK_TARGET_ITEM_TRAN_KEY REFERENCES SALES_TARGET_ITEM_PACK_MASTER (TARGET_ITEM_PACK_KEY)ON UPDATE CASCADE,";
                    //strSQL = strSQL + "STOCKGROUP_NAME varchar(50) NOT NULL CONSTRAINT FK_SALES_TARGET_ITEM_TRAN_STOCKGROUP_NAME REFERENCES INV_STOCKGROUP(STOCKGROUP_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) Null CONSTRAINT FK_SALES_TARGET_ITEM_TRAN_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME),";
                    strSQL = strSQL + "STOCKCATEGORY_NAME varchar(50) NULL CONSTRAINT FK_SALES_TARGET_PACK_TRAN_STOCKCATEGORY_NAME REFERENCES INV_STOCKCATEGORY(STOCKCATEGORY_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_SALES_TARGET_ITEM_PACK_MASTER_LEDGER REFERENCES ACC_LEDGER (LEDGER_NAME)ON UPDATE CASCADE,";
                    strSQL = strSQL + "TARGET_ITEM_TRAN_FROM_DATE datetime NOT NULL,";
                    strSQL = strSQL + "TARGET_ITEM_TRAN_TO_DATE datetime NOT NULL,";
                    strSQL = strSQL + "TARGET_ITEM_TRAN_MONTH_ID varchar(6) NOT NULL,";
                    strSQL = strSQL + "COL_POS smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ROW_POS smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "TARGET_ITEM_TRAN_AMOUNT numeric(18, 2) NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "EXPORT_TYPE smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "EXPORT_FILE_NAME varchar(25) NULL,";
                    strSQL = strSQL + "IMPORT_FILE_NAME varchar(25) NULL";
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
        private static string CreateUserPrivilegesBranch()
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
                    strSQL = "CREATE TABLE USER_PRIVILEGES_BRANCH(";
                    strSQL = strSQL + "PRI_BRANCH_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "USER_LOGIN_KEY varchar (50) CONSTRAINT PK_USER_PRIVILEGES_BRANCH PRIMARY KEY,";//    'Branch ID + User Name
                    strSQL = strSQL + "USER_LOGIN_NAME VARCHAR(30) NOT NULL CONSTRAINT FK_USER_PRI_BRANCH_LOGIN_NAME REFERENCES USER_CONFIG(USER_LOGIN_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_USER_PRI_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "ENTRYBY VARCHAR(100) NULL,";
                    strSQL = strSQL + "UPDATEBY VARCHAR(100) NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE USER_PRIVILEGES_STOCKGROUP(";
                    strSQL = strSQL + "PRI_STOCKGROUP_SERIAL numeric (18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "USER_LOGIN_NAME varchar(30) NOT NULL CONSTRAINT  FK_USER_PRIVILEGES_STOCKGROUP_LOGIN_NAME REFERENCES USER_CONFIG(USER_LOGIN_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(50) NOT NULL CONSTRAINT  FK_USER_PRIVILEGES_STOCKGROUP_STOCKGROUP_NAME REFERENCES INV_STOCKGROUP(STOCKGROUP_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE USER_PRIVILEGES_COLOR(";
                    strSQL = strSQL + "PRI_STOCKGROUP_SERIAL numeric (18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "USER_LOGIN_NAME varchar(30) NOT NULL CONSTRAINT  FK_USER_PRIVILEGES_COLOR_LOGIN_NAME REFERENCES USER_CONFIG(USER_LOGIN_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "LEDGER_GROUP_NAME varchar(50) NOT NULL CONSTRAINT  FK_USER_PRIVILEGES_COLOR_LEDGER_GROUP_NAME REFERENCES ACC_LEDGERGROUP(GR_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE USER_PRIVILEGES_LOCATION(";
                    strSQL = strSQL + "PRI_LOCATION_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "USER_LOGIN_NAME varchar(30) NOT NULL CONSTRAINT  FK_USER_PRIVILEGES_LOCATION_LOGIN_NAME REFERENCES USER_CONFIG(USER_LOGIN_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) NOT NULL CONSTRAINT  FK_USER_PRIVILEGES_LOCATION_GODOWNS_NAME REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "CREATE TABLE USER_PRIVILEGES_LEDGER(";
                    strSQL = strSQL + "PRI_LEDGER_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "USER_LOGIN_NAME varchar(30) NOT NULL CONSTRAINT  FK_USER_PRIVILEGES_LEDGER_LOGIN_NAME REFERENCES USER_CONFIG(USER_LOGIN_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT  FK_USER_PRIVILEGES_LEDGER_GODOWNS_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE SAL_TARGET_STATEMENT_YEARLY_VIEW(";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(50) NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_NAME varchar(50) NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NULL,";
                    strSQL = strSQL + "TAR_QTY_1 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "SAL_QTY_1 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "TAR_QTY_2 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "SAL_QTY_2 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "TAR_QTY_3 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "SAL_QTY_3 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "TAR_QTY_4 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "SAL_QTY_4 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "TAR_QTY_5 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "SAL_QTY_5 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "TAR_QTY_6 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "SAL_QTY_6 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "TAR_QTY_7 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "SAL_QTY_7 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "TAR_QTY_8 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "SAL_QTY_8 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "TAR_QTY_9 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "SAL_QTY_9 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "TAR_QTY_10 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "SAL_QTY_10 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "TAR_QTY_11 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "SAL_QTY_11 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "TAR_QTY_12 numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "SAL_QTY_12 numeric(18, 4) NOT NULL";
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
        private static string CreateAccLedgerStockAmnout()
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
                    strSQL = "CREATE TABLE ACC_LEDGER_STOCK_AMOUNT(";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(60) NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME VARCHAR(60) NOT NULL,";
                    strSQL = strSQL + "QTY NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "AMOUNT NUMERIC(18,2) DEFAULT 0 NOT NULL";
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
        private static string CreateStockInvMaterialType()
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
                    strSQL = "CREATE TABLE INV_STOCK_MATERIAL_TYPE(";
                    strSQL = strSQL + "MATERIAL_TYPE varchar(60) NOT NULL  CONSTRAINT PK_INV_MATERIAL_TYPE PRIMARY KEY";
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
        private static string CreateStockInvSalesRepresentative()
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
                    strSQL = "CREATE TABLE INV_SALESREPSENTIVE(";
                    strSQL = strSQL + "SALES_REPSENTIVESERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_SALESREPSENTIVE REFERENCES ACC_LEDGER (LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "MRR_NO varchar(60) NOT NULL ,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime NULL";
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
        private static string CreateStockInvSectionName()
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
                    strSQL = "CREATE TABLE INV_SECTION_NAME(";
                    strSQL = strSQL + "SECTION_NAME varchar(60) NOT NULL  CONSTRAINT PK_INV_SECTION_NAME PRIMARY KEY";
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



        private static string CreateStockInvGroupCommMaster()
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
                    strSQL = "CREATE TABLE INV_GROUP_COMMISSION_MASTER(";
                    strSQL = strSQL + "GROUP_COMMISSION_KEY varchar (70) NOT NULL  CONSTRAINT PK_GROUP_COMMISSION_KEY PRIMARY KEY,";//BRANCHid+STOCKGROUPNAME+EFFECTIVEDATE+STATUS
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(50) NULL,";
                    strSQL = strSQL + "EFFECTIVE_DATE datetime NOT NULL,";
                    strSQL = strSQL + "COMM_STATUS smallint NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char(4) NOT NULL CONSTRAINT FK_INV_GROUP_COMMISSION_MASTER_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID) ON UPDATE CASCADE";
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

        private static string CreateStockInvGroupCommTran()
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
                    strSQL = "CREATE TABLE INV_GROUP_COMMISSION_TRAN(";
                    strSQL = strSQL + "GROUP_COMMISSION_KEY varchar(70) NULL CONSTRAINT FK_INV_GROUP_COMMISSION_TRAN_GROUP_COMMISSION_KEY REFERENCES INV_GROUP_COMMISSION_MASTER (GROUP_COMMISSION_KEY)ON UPDATE CASCADE,";
                    strSQL = strSQL + "AMOUNT_FORM numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "AMOUNT_TO numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "GROUP_PERCENTAGES varchar(10) NULL";
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
        private static string CreateStockInvGroupMaster()
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
                    strSQL = "CREATE TABLE INV_GROUP_MASTER(";
                    strSQL = strSQL + "GR_NAME_SERIAL numeric(18, 0) IDENTITY(1,1) NOT NULL,";
                    strSQL = strSQL + "GR_NAME varchar(50) NOT NULL  CONSTRAINT PK_INV_GROUP_GR_NAME PRIMARY KEY,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime NULL";
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


        private static string CreateLocations()
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

                    strSQL = "CREATE TABLE INV_GODOWNS(";
                    strSQL = strSQL + "GODOWNS_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) CONSTRAINT PK_INV_GODOWNS PRIMARY KEY,";
                    strSQL = strSQL + "GODOWNS_NAME_DEFAULT varchar(50) NULL,";
                    strSQL = strSQL + "GODOWNS_ADDRESS1 varchar(50) NULL,";
                    strSQL = strSQL + "GODOWNS_ADDRESS2 varchar(50) NULL,";
                    strSQL = strSQL + "GODOWNS_CITY varchar(50) NULL,";
                    strSQL = strSQL + "GODOWNS_PHONE varchar(50) NULL,";
                    strSQL = strSQL + "GODOWNS_FAX varchar(50) NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_INV_GODOWNS_BRANCH_ID  REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "GODOWNS_PARENT_GROUP varchar(50) NOT NULL,";
                    strSQL = strSQL + "GODOWNS_OPENING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_OPENING_VALUE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_OPENING_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_CLOSING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_INWARDQUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_OUTWARDQUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_DEFAULT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "SECTION_STATUS smallint default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "EXPORT_TYPE smallint default 1 NOT NULL,";//    '1 = Not Exported, 2 = Exported, 3 = Imported
                    strSQL = strSQL + "EXPORT_FILE_NAME VARCHAR(25) NULL,";
                    strSQL = strSQL + "IMPORT_FILE_NAME VARCHAR(25) NULL";
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


        private static string CreateBarcoteImage()
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
                    strSQL = "SELECT NAME FROM SYSOBJECTS WHERE NAME='BARCODE_IMAGE' ";
                    strSQL = "CREATE TABLE BARCODE_IMAGE(";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_BARCODE_IMAGE_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + " BARCODE_IMAGE IMAGE NULL";
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
        private static string CreateCopyPurPrice()
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
                    strSQL = "CREATE TABLE INV_BILL_TRAN_DATE_COPY_PUR_PRICE(";
                    strSQL = strSQL + "COMP_VOUCHER_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "BILL_RATE NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BILL_UOM VARCHAR(10) NOT NULL,";
                    strSQL = strSQL + "BILL_PER VARCHAR(10) NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE NUMERIC(18,0) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "STOCKiTEM_NAME VarChar(100) NOT NULL ";
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

        private static string CreateMarkUp()
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
                    strSQL = "CREATE TABLE INV_MARK_UP(";
                    strSQL = strSQL + "MARK_UP_NO numeric(15,0) IDENTITY(1,1) CONSTRAINT PK_INV_MARK_UP PRIMARY KEY ,";
                    strSQL = strSQL + "MARKUP_KEY char (50) NOT NULL ,";
                    strSQL = strSQL + "INV_LOG_NO varchar (50) NOT NULL ,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar (60) NOT NULL ,";
                    strSQL = strSQL + "MARKUP_VALUE numeric(18, 2) NOT NULL ,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null ,";
                    strSQL = strSQL + "MARKUP_PER char (1) NULL";
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
        private static string CreateInvStockItemSerialMaster()
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

                    strSQL = "CREATE TABLE INV_STOCKITEM_SERIAL_MASTER ( ";
                    strSQL = strSQL + "SERIAL_SERIAL numeric (18,0) IDENTITY (1,1),";
                    strSQL = strSQL + "STOCKITEM_SERIAL varchar(50) CONSTRAINT PK_INV_STOCKITEM_SERIAL_MASTER PRIMARY KEY,";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL,"; // 'COMP_REF_NO
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_INV_STOCKITEM_SERIAL_MASTER_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_STOCKITEM_SERIAL_MASTER_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "SERIAL_STATUS smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PURCHASE_WARRANTY datetime NULL,";
                    strSQL = strSQL + "SALES_WARRANTY datetime NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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


        private static string CreateInvStockItemSerial()
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

                    strSQL = "CREATE TABLE INV_STOCKITEM_SERIAL ( ";
                    strSQL = strSQL + "VOUCHER_SERIAL numeric (18,0) IDENTITY (1,1),";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL,";//  'COMP_REF_NO
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_INV_STOCKITEM_SERIAL_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_STOCKITEM_SERIAL_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "VOUCHER_POSITION smallint default 1 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NULL,";
                    strSQL = strSQL + "STOCKITEM_SERIAL varchar(50),";
                    strSQL = strSQL + "WARRANTY datetime NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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

        private static string CreateInvBatch()
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

                    strSQL = "CREATE TABLE INV_BATCH(";
                    strSQL = strSQL + "INV_SERIAL numeric(18, 0) IDENTITY (1, 1) NOT NULL ,";
                    strSQL = strSQL + "INV_LOG_NO varchar (50) CONSTRAINT PK_INV_BATCH PRIMARY KEY,";
                    strSQL = strSQL + "INV_LOG_START datetime NULL ,";
                    strSQL = strSQL + "INV_LOG_END datetime NULL ,";
                    strSQL = strSQL + "INV_LOG_EXPIRE datetime NULL,";
                    strSQL = strSQL + "INV_LOG_MANU_DATE datetime NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NULL,";
                    strSQL = strSQL + "INV_LOG_SIZE numeric(18, 4) NOT NULL,";
                    strSQL = strSQL + "INV_LOG_STATUS char (10) NULL,";
                    strSQL = strSQL + "NRT_NO varchar (60) NULL,";
                    strSQL = strSQL + "GRT_NO varchar (60) NULL,";
                    strSQL = strSQL + "COMMIDITY varchar (60) NULL,";
                    strSQL = strSQL + "QUANTITY NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null ";
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

        private static string CreateInvEffect()
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

                    strSQL = "CREATE TABLE INV_EFFECT_PAYMENT( ";
                    strSQL = strSQL + "INV_NO numeric (15,0) IDENTITY(1,1) CONSTRAINT PK_INV_EFFECT_PAYMENT PRIMARY KEY,";
                    strSQL = strSQL + "INV_REF_NO varchar (30) NOT NULL ,";
                    strSQL = strSQL + "INV_LOG_NO varchar (50) NULL CONSTRAINT FK_INV_EFFECT_PAYMENT_INV_LOG_NO REFERENCES INV_BATCH(INV_LOG_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "INV_GODOWNS varchar (50) NOT NULL ,";
                    strSQL = strSQL + "INV_CURR_ROW int NOT NULL ,";
                    strSQL = strSQL + "INV_ROW numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INV_COL numeric(18,2) default 0 NOT NULL ,";
                    strSQL = strSQL + "INV_KEY varchar (50) NOT NULL ,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_EFFECT_PAYMENT_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "INV_QTY numeric(18,2) default 0 NOT NULL ,";
                    strSQL = strSQL + "INV_PER VARCHAR(10) NULL,";
                    strSQL = strSQL + "INV_UNIT varchar (50) NOT NULL ,";
                    strSQL = strSQL + "INV_RATE numeric(18,2) default 0 NOT NULL ,";
                    strSQL = strSQL + "INV_AMOUNT numeric(18,2) default 0 NOT NULL,";
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
        private static string CreateProductionLog()
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
                    strSQL = "CREATE TABLE INV_PRODUCTION_LOG(";
                    strSQL = strSQL + "INV_PRODUCTION_NO numeric(15,0) IDENTITY(1,1) CONSTRAINT PK_INV_PRODUCTION_LOG PRIMARY KEY ,";
                    strSQL = strSQL + "INV_LOG_NO varchar (30) NOT NULL ,";
                    strSQL = strSQL + "INV_REF_NO_OUT varchar (30) NOT NULL ,";
                    strSQL = strSQL + "INV_LOG_PROCESS_NAME varchar (50) NOT NULL CONSTRAINT FK_INV_PRODUCTION_LOG_INV_LOG_PROCESS_NAME REFERENCES INV_MENU_PROCESS_MAIN(PROCESS_NAME) ON UPDATE CASCADE ,";
                    strSQL = strSQL + "INV_LOG_DATE datetime NOT NULL ,";
                    strSQL = strSQL + "INV_LOG_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "CONVERTTYPE smallint default 0 not null,";
                    strSQL = strSQL + "INV_REF_NO_IN varchar (30) NOT NULL,";
                    strSQL = strSQL + "INV_REF_NO_WASTAGE varchar (30) NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT PK_INV_PRODUCTION_LOG_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
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


        private static string CreateProcessMain()
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
                    strSQL = "CREATE TABLE INV_MENU_PROCESS_MAIN (";
                    strSQL = strSQL + "PROCESS_SERIAL numeric(18, 0) IDENTITY (1, 1) NOT NULL, ";
                    strSQL = strSQL + "PROCESS_NAME varchar (50) PRIMARY KEY, ";
                    strSQL = strSQL + "CONVERT_Y_N smallint default 0 not null,";
                    strSQL = strSQL + "TRANSFER_TYPE SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4)  NULL CONSTRAINT FK_INV_MENU_PROCESS_MAIN_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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
        private static string CreateProcess()
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

                    strSQL = "CREATE TABLE INV_MANU_PROCESS (";
                    strSQL = strSQL + "PROCRESS_SERIAL numeric(18, 0) IDENTITY (1, 1) PRIMARY KEY,";
                    strSQL = strSQL + "PROCESS_NAME varchar (50)  NOT NULL ,";
                    //strSQL = strSQL + "STOCKITEM_NAME varchar (60) NOT NULL, ";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_MANU_PROCESS_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "PROCESS_POSITION smallint NOT NULL ,";
                    strSQL = strSQL + "PROCESS_QUANTITY numeric(18, 4) default 0 NOT NULL ,";
                    strSQL = strSQL + "PROCESS_UNIT varchar (10)  NOT NULL ,";
                    strSQL = strSQL + "INV_PER VARCHAR(10)  NULL,";
                    strSQL = strSQL + "FG_COST_PERCENT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50)  NULL CONSTRAINT FK_INV_MANU_PROCESS_MAIN_GODOWNS_NAME REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "PROCESS_TYPE SmallInt Default 0 NOT NULL";
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

        private static string CreateInvGroupToStock()
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
                    strSQL = "CREATE TABLE INV_GROUP_TO_STOCKITEM ( ";
                    strSQL = strSQL + "SERIAL numeric(18, 0) IDENTITY (1, 1) CONSTRAINT PK_INV_GROUP_TO_STOCKITEM PRIMARY KEY , ";
                    strSQL = strSQL + "STOCKGROUP_PARENT varchar (50)  NULL , ";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar (50) NULL ";// 'REFERENCES INV_STOCKGROUP(STOCKGROUP_NAME) ON UPDATE CASCADE "
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

        private static string CreateSlowMoving()
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
                    strSQL = "CREATE TABLE INV_SLOW_MOVING_ITEM(";
                    strSQL = strSQL + "INV_SLOW_NO numeric(15,0) IDENTITY(1,1), ";
                    strSQL = strSQL + "STOCKITEM_NAME varchar (60) NULL , ";
                    strSQL = strSQL + "STOCKITEM_LAST_SOLD_DATE datetime null,";
                    strSQL = strSQL + "QTY numeric(18,2) default 0 ,";
                    strSQL = strSQL + "AMOUNT numeric(18,2) default 0 ,";
                    strSQL = strSQL + "DAYDIFF smallint NULL";
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
        private static string DropTableStock()
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

                    //'INV_EFFECT_PAYMENT
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnmain;
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_EFFECT_PAYMENT]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) ";
                    strSQL = strSQL + "drop table [dbo].[INV_EFFECT_PAYMENT] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_STOCKITEM_SERIAL
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCKITEM_SERIAL]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) ";
                    strSQL = strSQL + "drop table [dbo].[INV_STOCKITEM_SERIAL] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();



                    //'INV_STOCKITEM_SERIAL_MASTER
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCKITEM_SERIAL_MASTER]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) ";
                    strSQL = strSQL + "drop table [dbo].[INV_STOCKITEM_SERIAL_MASTER] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();



                    //'ACC_BILL_TRAN_PROCESS
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_BILL_TRAN_PROCESS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[ACC_BILL_TRAN_PROCESS] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_STOCKITEM_CLOSING
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCKITEM_CLOSING]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_STOCKITEM_CLOSING] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_STOCK_OPENING
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_DELIVERY_MAN]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[ACC_DELIVERY_MAN] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCK_OPENING]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_STOCK_OPENING] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_STOCK_SUMMARY
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCK_SUMMARY]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_STOCK_SUMMARY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'ACC_QUOTATION_CONFIG
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_QUOTATION_CONFIG]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[ACC_QUOTATION_CONFIG] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'ACC_QUOTATION_TRAN
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_QUOTATION_TRAN]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[ACC_QUOTATION_TRAN] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'ACC_BILL_TRAN
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_BILL_TRAN]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[ACC_BILL_TRAN] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    //'INV_BATCH
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_BATCH]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_BATCH] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_STOCKITEM_TO_GROUP
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCKITEM_TO_GROUP]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_STOCKITEM_TO_GROUP]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_SALES_PRICE
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_SALES_PRICE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_SALES_PRICE]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_ADJUSTMENTS
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_ADJUSTMENTS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_ADJUSTMENTS] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_TRAN
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_TRAN]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_TRAN] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_GROUP_TO_STOCKITEM
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_GROUP_TO_STOCKITEM]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_GROUP_TO_STOCKITEM] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_MASTER
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_MASTER]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_MASTER] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_BILL_OF_MATERIALS
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_BILL_OF_MATERIALS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_BILL_OF_MATERIALS] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'inv_slow_moving_item
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_SLOW_MOVING_ITEM]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_SLOW_MOVING_ITEM] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_CONFIG
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_CONFIG]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_CONFIG] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_OPTION
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_OPTION]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_OPTION] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_GODOWNS
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_GODOWNS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_GODOWNS]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_PRODUCTION_LOG
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_PRODUCTION_LOG]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_PRODUCTION_LOG]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_MANU_PROCESS
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_MANU_PROCESS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_MANU_PROCESS]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_MENU_PROCESS_MAIN
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_MENU_PROCESS_MAIN]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) ";
                    strSQL = strSQL + "drop table [dbo].[INV_MENU_PROCESS_MAIN]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_STOCKITEM_LEVEL
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCKITEM_LEVEL]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_STOCKITEM_LEVEL] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    //'INV_STOCKITEM
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCKITEM]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_STOCKITEM]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_UNIT_MEASUREMENT
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_UNIT_MEASUREMENT]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_UNIT_MEASUREMENT]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    //'INV_STOCKCATEGORY
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCKCATEGORY]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_STOCKCATEGORY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    //'INV_STOCKGROUP
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCKGROUP]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[INV_STOCKGROUP] ";
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


        private static string CreateStockCategory()
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
                    strSQL = "CREATE TABLE INV_STOCKCATEGORY(";
                    strSQL = strSQL + "STOCKCATEGORY_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_NAME varchar(50) CONSTRAINT PK_INV_STOCKCATEGORY PRIMARY KEY,";
                    strSQL = strSQL + "STOCKCATEGORY_PARENT varchar(50) NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_PRIMARY varchar(50) NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_OPENING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_CLOSING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_INWARDQUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_OUTWARDQUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_DEBIT_CLOSING_BAL numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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
        private static string CreateStockCategoryOthers()
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
                    strSQL = "CREATE TABLE INV_STOCKCATEGORY_OTHERS(";
                    strSQL = strSQL + "STOCKCATEGORY_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_NAME varchar(50) CONSTRAINT PK_INV_STOCKCATEGORY_OTHERS_KEY PRIMARY KEY,";
                    strSQL = strSQL + "STOCKCATEGORY_PARENT varchar(50) NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_PRIMARY varchar(50) NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_OPENING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_CLOSING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_INWARDQUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_OUTWARDQUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_DEBIT_CLOSING_BAL numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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

        private static string CreateStockGroup()
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
                    strSQL = "CREATE TABLE INV_STOCKGROUP(";
                    strSQL = strSQL + "STOCKGROUP_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(50) CONSTRAINT PK_INV_STOCKGROUP PRIMARY KEY,";
                    strSQL = strSQL + "STOCKGROUP_PARENT varchar(50) NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_ONE_DOWN varchar(50) NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_PRIMARY varchar(50) NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_NAME_DEFAULT varchar(50) NULL,";
                    strSQL = strSQL + "STOCKGROUP_OPENING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_CLOSING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_INWARDQUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_OUTWARDQUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_OPENING_VALUE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_DEBIT_CLOSING_BAL numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_LEVEL smallint default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_SEQUENCES smallint default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_PRIMARY_TYPE smallint default 0 NOT NULL,";    //' 1 = Raw Materails
                    //' 2 = WIP
                    //' 3 = FG
                    strSQL = strSQL + "STOCKGROUP_SECONDARY_TYPE smallint default 0 NOT NULL,";    //'1 = Indirect Raw Materials
                    strSQL = strSQL + "STOCKGROUP_DEFAULT smallint default 0 NOT NULL,";    //'0 = Not Default, 2 = Default

                    strSQL = strSQL + "STOCKGROUP_USE_PACK_SIZE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "GR_NAME varchar(50) NULL CONSTRAINT FK_INV_STOCKGROUP_GR_NAME REFERENCES INV_GROUP_MASTER(GR_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "G_STATUS smallint default 0 NOT NULL,";

                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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

        private static string CreateStockItem()
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

                    strSQL = "CREATE TABLE INV_STOCKITEM(";
                    strSQL = strSQL + "STOCKITEM_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) CONSTRAINT PK_INV_STOCKITEM PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "ITEM_NAME_BANGLA nvarchar(60) NULL,";
                    strSQL = strSQL + "STOCKITEM_ALIAS varchar(50) NULL,";
                    //'strSQL = strSQL + "STOCKITEM_ALIAS varchar(50) CONSTRAINT UQ_INV_STOCKITEM UNIQUE NULL,";
                    strSQL = strSQL + "STOCKITEM_DESCRIPTION varchar(300) NULL,";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(50) NOT NULL CONSTRAINT FK_INV_STOCKITEM_STOCKGROUP_NAME REFERENCES INV_STOCKGROUP(STOCKGROUP_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKCATEGORY_NAME varchar(50) NULL CONSTRAINT FK_INV_STOCKITEM_STOCKCATEGORY_NAME REFERENCES INV_STOCKCATEGORY(STOCKCATEGORY_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKITEM_PRIMARY_GROUP varchar(50) NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_OPENING_BALANCE numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_OPENING_VALUE numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_OPENING_RATE numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_CLOSING_BALANCE numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_INWARDQUANTITY numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_OUTWARDQUANTITY numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_BASEUNITS varchar(10) NOT NULL CONSTRAINT FK_INV_STOCKITEM_STOCKITEM_BASEUNITS REFERENCES INV_UNIT_MEASUREMENT(UNIT_SYMBOL) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKITEM_ADDITIONALUNITS varchar(20) NULL,";
                    strSQL = strSQL + "STOCKITEM_CONVERSION numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_DENOMINATOR numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_MIN_QUANTITY numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_REORDER_LEVEL numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_MAINTAIN_SERIAL smallint default 0 NOT NULL,";//    ' 0 = n/a, 1= Serl, 2 = Batch
                    strSQL = strSQL + "SP_ITEM smallint default 0 NOT NULL,";//    ' 0 = no, 1= yes
                    strSQL = strSQL + "STOCKITEM_MANUFACTURER varchar (60) NULL,";
                    strSQL = strSQL + "ISBN_NO VARCHAR(100) NULL,";
                    strSQL = strSQL + "STOCKITEM_STATUS smallint default 0 NOT NULL,";//    ' 0 = Active, 1 = Inactive
                    strSQL = strSQL + "STOCK_ITEM_SUPPLIER VARCHAR(60) NULL,";
                    strSQL = strSQL + "SERIAL_STATUS SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "POWER_CLASS varchar(60) NULL,";
                    strSQL = strSQL + "MATERIAL_TYPE varchar(60)  NULL CONSTRAINT FK_INV_STOCKITEM_MATERIAL_TYPE REFERENCES INV_STOCK_MATERIAL_TYPE (MATERIAL_TYPE)ON UPDATE CASCADE,";

                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "STOCKOTHERS_NAME varchar(70) NULL CONSTRAINT FK_INV_STOCKITEM_STOCKOTHERS_NAME REFERENCES INV_STOCKOTHERS_CATEGORY(STOCKOTHERS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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
        private static string CreateStockItemLevel()
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

                    strSQL = "CREATE TABLE INV_STOCKITEM_LEVEL(";
                    strSQL = strSQL + "STOCKITEM_LEVEL_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_INV_STOCKITEM_LEVEL PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_STOCKITEM_LEVEL_STOCKITEM_NAME UNIQUE REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKGROUP_LEVEL_1 varchar(50) NULL,";
                    strSQL = strSQL + "STOCKGROUP_LEVEL_2 varchar(50) NULL,";
                    strSQL = strSQL + "STOCKGROUP_LEVEL_3 varchar(50) NULL,";
                    strSQL = strSQL + "STOCKGROUP_LEVEL_4 varchar(50) NULL,";
                    strSQL = strSQL + "STOCKGROUP_LEVEL_5 varchar(50) NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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
        private static string CreateStockItemClosing()
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
                    strSQL = "CREATE TABLE INV_STOCKITEM_CLOSING(";
                    strSQL = strSQL + "STOCKITEM_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_INV_STOCKITEM_CLOSING PRIMARY KEY,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_STOCKITEM_CLOSING_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) NOT NULL CONSTRAINT FK_INV_STOCKITEM_CLOSING_GODOWNS_NAME  REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKITEM_CLOSING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_SALE_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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
        private static string CreateStockItemToGroup()
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
                    strSQL = "CREATE TABLE INV_STOCKITEM_TO_GROUP(";
                    strSQL = strSQL + "SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_INV_STOCKITEM_TO_GROUP PRIMARY KEY,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_STOCKITEM_TO_GROUP_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(50) NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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

        private static string CreateSalesPrice()
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
                    strSQL = "CREATE TABLE INV_SALES_PRICE(";
                    strSQL = strSQL + "SALES_PRICE_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "SALES_PRICE_KEY varchar(150) CONSTRAINT PK_INV_SALES_PRICE PRIMARY KEY,";//    'Stock  Int Item + Eff Date
                    strSQL = strSQL + "PRICE_UNIQUE_KEY varchar(150) ,";//    'Item Name + Date ,Purpose : To Differ from Other Days Price and Item + From + To Quantity
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_SALES_PRICE_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "FROM_QTY numeric(18,2) NOT NULL,";
                    strSQL = strSQL + "TO_QTY numeric(18,2) NOT NULL,";
                    strSQL = strSQL + "SALES_PRICE_AMOUNT numeric(18,2) NOT NULL,";
                    strSQL = strSQL + "SALES_PRICE_EFFECTIVE_DATE datetime NOT NULL,";
                    strSQL = strSQL + "PRICE_LEVEL_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_SALES_PRICE_PRICE_LEVEL_NAME REFERENCES ACC_PRICE_LEVEL(PRICE_LEVEL_NAME) ON UPDATE CASCADE, ";
                    strSQL = strSQL + "ACTUAL_DISCOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "PERCENT_DISCOUNT varchar(6),";
                    strSQL = strSQL + "MINIMUM_PRICE SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "MODULE_STATUS SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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

        private static string CreateInventoryMaster()
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

                    strSQL = "CREATE TABLE INV_MASTER(";
                    strSQL = strSQL + "INV_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT PK_INV_MASTER_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "INV_REF_NO VARCHAR(30) CONSTRAINT PK_INV_MASTER PRIMARY KEY,";//   'INV_REF_NO
                    strSQL = strSQL + "INV_VOUCHER_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "INV_COST_OPTION smallint default 0 NOT NULL,";//   '1=QTY,2=VALUE,3=ITEM
                    strSQL = strSQL + "INV_DATE datetime NOT NULL,";
                    strSQL = strSQL + "INWORD_QUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INV_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INV_OPENING_FLAG smallint default 0 NOT NULL,";
                    strSQL = strSQL + "INV_NARRATIONS varchar(400) NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NULL CONSTRAINT FK_INV_MASTER_LEDGER_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "PROCESS_NAME Varchar(50) Null,";
                    strSQL = strSQL + "AGNST_COMP_REF_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "INV_VEHICLE_NO VARCHAR(50) NULL,";
                    strSQL = strSQL + "INV_LOG_NO varchar (50) NULL,";
                    strSQL = strSQL + "INV_TRAN_STATUS smallint default 0 NOT NULL,";
                    strSQL = strSQL + "INV_MANU_VOUCHER_AUTO smallint default 0 NOT NULL,";//    '0=NO, 1=YES
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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

        private static string CreateInventoryTransaction()
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


                    strSQL = "CREATE TABLE INV_TRAN(";
                    strSQL = strSQL + "INV_TRAN_SERIAL numeric (18,0) IDENTITY (1,1),";
                    strSQL = strSQL + "INV_TRAN_KEY VARCHAR(50) CONSTRAINT PK_INV_TRAN PRIMARY KEY,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_INV_TRAN_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "INV_REF_NO VARCHAR(30) NOT NULL CONSTRAINT FK_INV_TRAN_INV_REF_NO REFERENCES INV_MASTER(INV_REF_NO) ON UPDATE CASCADE,";//   'INV_REF_NO
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_TRAN_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) NOT NULL CONSTRAINT FK_INV_TRAN_GODOWNS_NAME REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "INV_DATE datetime NOT NULL,";
                    strSQL = strSQL + "INV_TRAN_POSITION smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_VOUCHER_TYPE smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_OPENING_FLAG smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_INOUT_FLAG char(2) NULL ,";
                    strSQL = strSQL + "OPENING_QUANTITY numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "INWARD_QUANTITY numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "INWARD_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INV_TRAN_QUANTITY numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "INV_UOM VARCHAR(10)  NULL,";
                    strSQL = strSQL + "INV_PER VARCHAR(10)  NULL,";
                    strSQL = strSQL + "INV_TRAN_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INV_TRAN_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "OUTWARD_QUANTITY numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "OUTWARD_SALES_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "OUTWARD_COST_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INV_CURRENT_STOCK numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_TRAN_AGST_VOUCHER_TYPE smallint null,";
                    strSQL = strSQL + "INV_TRAN_IS_GIFT smallint default 0 NOT NULL,";//   ' 0 = NO , 1 = YES
                    strSQL = strSQL + "PROCESS_NAME Varchar(50) NULL,";
                    strSQL = strSQL + "INV_LOG_NO varchar (50) NULL,";
                    strSQL = strSQL + "INV_TRAN_RUNNING_QTY numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "FG_COST_PERCENT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PROFIT_UPDATE SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "SECTION_NAME varchar(60) NULL CONSTRAINT FK_INV_TRAN_SECTION_NAME REFERENCES INV_SECTION_NAME (SECTION_NAME)ON UPDATE CASCADE,";
                    strSQL = strSQL + "CONVERSION_TYPE numeric(18, 4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "STAFF_QTY smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_SORT_ORDER smallint DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INWARD_SALES_RETURN_AMOUNT numeric(18, 2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_TRAN_BALANCE_QTY numeric(18, 4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_TRAN_RUNNING_QTY_LOCATION numeric(18, 4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_PRIMARY_TYPE int default 0  not null,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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
        private static string CreateInventoryStockSummary()
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

                    strSQL = "CREATE TABLE INV_STOCK_SUMMARY(";
                    strSQL = strSQL + "STOCKITEM_PRIMARY_GROUP varchar(50) NULL,";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar(50) NULL,";
                    strSQL = strSQL + "STOCKCATEGORY_NAME varchar(50) NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NULL ,";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) NULL,";
                    strSQL = strSQL + "INWARD_QUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INWARD_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "OUTWARD_QUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "OUTWARD_COST_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "OUTWARD_SALES_AMOUNT numeric(18,2) default 0 NOT NULL";
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
        private static string CreateInventoryStockOpening()
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
                    strSQL = "CREATE TABLE INV_STOCK_OPENING(";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL ,";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) NULL,";
                    strSQL = strSQL + "OPENING_QUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "OPENING_VALUE numeric(18,2) default 0 NOT NULL";
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

        private static string CreateInventoryConfig()
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
                    strSQL = "CREATE TABLE INV_CONFIG(";
                    strSQL = strSQL + "CONFIG_NO numeric(15,0) IDENTITY(1,1) CONSTRAINT PK_INV_CONFIG PRIMARY KEY,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "GODOWNS smallint default 0 NOT NULL";
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

        private static string CreateInventoryOption()
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
                    strSQL = "CREATE TABLE INV_OPTION(";
                    strSQL = strSQL + "STOCK_VALUATION smallint default 1 NOT NULL,";//    '0 = Weighted Avg 1 = Average Cost
                    strSQL = strSQL + "FILTER_ITEM_IN_PURCHASE smallint default 0 NOT NULL,";//    '0 = No Filter 1 = Yes
                    strSQL = strSQL + "LAST_INV_TRAN_SERIAL numeric(18,0) default 0 NOT NULL,";//   ' Track Last Inv Tran Serial for Track Weight
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";//
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
        private static string CreateInvAdjustemnts()
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

                    strSQL = "CREATE TABLE INV_ADJUSTMENTS(";
                    strSQL = strSQL + "ADJ_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_INV_ADJUSTMENTS PRIMARY KEY,";
                    strSQL = strSQL + "INV_DATE datetime NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_ADJUSTMENTS_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) NOT NULL CONSTRAINT FK_INV_ADJUSTMENTS_GODOWNS_NAME REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "ADJ_REASON varchar(50)  NULL,";
                    strSQL = strSQL + "ADJ_QUANTITY numeric(18,2) default 0 NOT NULL,";
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

        private static string CreateBillTran()
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
                    strSQL = "CREATE TABLE ACC_BILL_TRAN(";
                    strSQL = strSQL + "BILL_TRAN_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "BILL_TRAN_KEY VARCHAR(50) CONSTRAINT PK_ACC_BILL_TRAN PRIMARY KEY,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_COMP_REF_NO REFERENCES ACC_COMPANY_VOUCHER(COMP_REF_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL,";
                    strSQL = strSQL + "BILL_TRAN_POSITION smallint default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "ITEM_NAME_BANGLA varchar(60) NULL,"; //'NEW FIELD ADD
                    strSQL = strSQL + "STOCKITEM_DESCRIPTION varchar(300) NULL,";   // 'NEW FIELD ADD
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_GODOWNS_NAME REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BILL_TRAN_PREV_NEW smallint default 0 NOT NULL,";  // '(On a/c = 1, New Ref = 2, Agst Ref = 3)
                    strSQL = strSQL + "BILL_QUANTITY numeric(18,4) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_QUANTITY_BONUS numeric(18,4) default 0 NULL,";
                    strSQL = strSQL + "BILL_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_UOM VARCHAR(10)  NULL,";
                    strSQL = strSQL + "BILL_PER VARCHAR(10)  NULL,";
                    strSQL = strSQL + "BILL_UOM_BONUS numeric(18,4) default 0 NULL,";
                    strSQL = strSQL + "BILL_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_ADD_LESS VARCHAR(10) NULL,";
                    strSQL = strSQL + "BILL_ADD_LESS_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_NET_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_TRAN_TOBY char(2) NOT NULL,";
                    strSQL = strSQL + "BILL_TRAN_ISOPEN smallint default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_STATUS smallint default 0 NOT NULL,";
                    //'strSQL = strSQL + "SALES_REP varchar(50) NULL, "
                    strSQL = strSQL + "VOUCHER_CURRENCY_SYMBOL varchar(5) null, ";//    ' REFERENCES ACC_CURRENCY(CURRENCY_SYMBOL) ON UPDATE CASCADE,"
                    strSQL = strSQL + "VOUCHER_FC_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "FC_CONVERSION_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "AGNST_COMP_REF_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "AGNST_COMP_REF_NO1 VARCHAR(30) NULL,";
                    strSQL = strSQL + "INV_LOG_NO varchar (50) NULL,";   //  'REFERENCES INV_BATCH(INV_LOG_NO) ON UPDATE CASCADE
                    strSQL = strSQL + "SHORT_QTY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "G_COMM_PER numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STAFF_QTY smallint default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar (70) NULL,";   //  'REFERENCES INV_BATCH(INV_LOG_NO) ON UPDATE CASCADE
                    strSQL = strSQL + "BILL_SALE_BALANCE numeric(18,2) default 0 NOT NULL,";
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
        private static string CreateBillTran_Appr()
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
                    strSQL = "CREATE TABLE ACC_BILL_TRAN_APPR(";
                    strSQL = strSQL + "BILL_TRAN_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "BILL_TRAN_KEY VARCHAR(50) CONSTRAINT PK_ACC_BILL_TRAN_APP PRIMARY KEY,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_APPR_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_APPR_COMP_REF_NO REFERENCES SMA_ACC_COMPANY_VOUCHER_APPR(COMP_REF_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL,";
                    strSQL = strSQL + "BILL_TRAN_POSITION smallint default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_APPR_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKITEM_DESCRIPTION varchar(300) NULL,";//   'NEW FIELD ADD
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_APPR_GODOWNS_NAME REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BILL_TRAN_PREV_NEW smallint default 0 NOT NULL,";//    '(On a/c = 1, New Ref = 2, Agst Ref = 3)
                    strSQL = strSQL + "BILL_QUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_QUANTITY_BONUS numeric(18,2) default 0 NULL,";
                    strSQL = strSQL + "BILL_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_UOM VARCHAR(10)  NULL,";
                    strSQL = strSQL + "BILL_PER VARCHAR(10)  NULL,";
                    strSQL = strSQL + "BILL_UOM_BONUS numeric(18,2) default 0 NULL,";
                    strSQL = strSQL + "BILL_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_ADD_LESS VARCHAR(10) NULL,";
                    strSQL = strSQL + "BILL_ADD_LESS_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_NET_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_TRAN_TOBY char(2) NOT NULL,";
                    strSQL = strSQL + "BILL_TRAN_ISOPEN smallint default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_STATUS smallint default 0 NOT NULL,";
                    //'strSQL = strSQL + "SALES_REP varchar(50) NULL, "
                    strSQL = strSQL + "VOUCHER_CURRENCY_SYMBOL varchar(5) null, "; //   ' REFERENCES ACC_CURRENCY(CURRENCY_SYMBOL) ON UPDATE CASCADE,"
                    strSQL = strSQL + "VOUCHER_FC_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "FC_CONVERSION_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "AGNST_COMP_REF_NO VARCHAR(30) NULL,";
                    strSQL = strSQL + "AGNST_COMP_REF_NO1 VARCHAR(30) NULL,";
                    strSQL = strSQL + "INV_LOG_NO varchar (50) NULL,";//  'REFERENCES INV_BATCH(INV_LOG_NO) ON UPDATE CASCADE
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE HW_TEMP_ITEM_SERIAL(";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL,";
                    strSQL = strSQL + "ITEM_NAME VARCHAR(100) NULL,";
                    strSQL = strSQL + "HW_SL_NO VARCHAR(500) NULL,";
                    strSQL = strSQL + "EXPIRE_DATE VARCHAR(500) NULL";
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
        private static string CreateBillTranProcessApp()
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
                    strSQL = "CREATE TABLE ACC_BILL_TRAN_PROCESS_APPR(";
                    strSQL = strSQL + "BILL_TRAN_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_BILL_TRAN_PROCESS_APP PRIMARY KEY,";
                    // 'strSql = strSql + "BILL_TRAN_KEY VARCHAR(50) PRIMARY KEY,"
                    strSQL = strSQL + "BILL_TRAN_KEY VARCHAR(50) ,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_PROCESS_APP_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_PROCESS_APP_COMP_REF_NO REFERENCES SMA_ACC_COMPANY_VOUCHER_APPR(COMP_REF_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL,";
                    strSQL = strSQL + "BILL_TRAN_POSITION smallint default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_PROCESS_APP_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_PROCESS_APP_GODOWNS_NAME REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BILL_QUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_UOM VARCHAR(10)  NULL,";
                    strSQL = strSQL + "BILL_PER VARCHAR(10)  NULL,";
                    strSQL = strSQL + "AGST_REF_NO_KEY varchar(50) NULL ,";
                    strSQL = strSQL + "AGST_COMP_REF_NO varchar(30) NULL,";
                    strSQL = strSQL + "ADD_LESS_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_NET_AMOUNT numeric (18,2) default 0 NOT NULL, ";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null ";
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

        private static string CreateQuotationTran()
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
                    strSQL = "CREATE TABLE ACC_QUOTATION_TRAN(";
                    strSQL = strSQL + "QUOTE_TRAN_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_QUOTATION_TRAN PRIMARY KEY,";
                    strSQL = strSQL + "QUOTE_REF_NO VARCHAR(30) NOT NULL CONSTRAINT FK_ACC_QUOTATION_TRAN_QUOTE_REF_NO REFERENCES ACC_QUOTATION_MASTER(QUOTE_REF_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "QUOTE_TRAN_POSITION smallint default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_ACC_QUOTATION_TRAN_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "QUOTE_QUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "QUOTE_UOM VARCHAR(10)  NULL,";
                    strSQL = strSQL + "QUOTE_PER VARCHAR(10)  NULL,";
                    strSQL = strSQL + "QUOTE_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "QUOTE_AMOUNT numeric(18,2) default 0 NOT NULL,";
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
        private static string CreateQuotationConfig()
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
                    strSQL = "CREATE TABLE ACC_QUOTATION_CONFIG(";
                    strSQL = strSQL + "QUOTATION_CONFIG_NO numeric(15,0) IDENTITY (1,1) CONSTRAINT PK_ACC_QUOTATION_CONFIG PRIMARY KEY,";
                    strSQL = strSQL + "QUOTE_HEADER varchar(300) NULL ,";
                    strSQL = strSQL + "QUOTE_FOOTER varchar(300) NULL ,";
                    strSQL = strSQL + "QUOTE_ITEM_DESCRIPTION smallint default 0, ";
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
        private static string CreateInvUnitMeasurement()
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
                    strSQL = "CREATE TABLE INV_UNIT_MEASUREMENT(";
                    strSQL = strSQL + "INV_UNIT_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "UNIT_SYMBOL varchar(10) CONSTRAINT PK_INV_UNIT_MEASUREMENT PRIMARY KEY ,";
                    strSQL = strSQL + "UNIT_FORMAL_NAME varchar(50) NOT NULL ,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "INV_UNIT_DECIMAL_NO smallint default 0 NOT NULL ";
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
        private static string CreateInvBillofMaterials()
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

                    strSQL = "CREATE TABLE INV_BILL_OF_MATERIALS(";
                    strSQL = strSQL + "INV_BILL_MATERIAL_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_INV_BILL_OF_MATERIALS PRIMARY KEY,";
                    strSQL = strSQL + "MAINITEM_NAME VARCHAR(60), ";
                    strSQL = strSQL + "STOCKITEM_NAME VARCHAR(60) NOT NULL CONSTRAINT FK_INV_BILL_OF_MATERIALS_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";//    'STOCKITEM_NAME
                    strSQL = strSQL + "STOCKITEM_QUANTITY numeric(18,2) default 0 NOT NULL, ";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) NOT NULL CONSTRAINT FK_INV_BILL_OF_MATERIALS_GODOWNS_NAME REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
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


        private static string CreateBillTranProcess()
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
                    strSQL = "CREATE TABLE ACC_BILL_TRAN_PROCESS(";
                    strSQL = strSQL + "BILL_TRAN_SERIAL numeric (18,0) IDENTITY (1,1) CONSTRAINT PK_ACC_BILL_TRAN_PROCESS PRIMARY KEY,";
                    //'strSql = strSql + "BILL_TRAN_KEY VARCHAR(50) PRIMARY KEY,"
                    strSQL = strSQL + "BILL_TRAN_KEY VARCHAR(50) ,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_PROCESS_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_PROCESS_COMP_REF_NO REFERENCES ACC_COMPANY_VOUCHER(COMP_REF_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "COMP_VOUCHER_DATE datetime NOT NULL,";
                    strSQL = strSQL + "BILL_TRAN_POSITION smallint default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_PROCESS_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) NOT NULL CONSTRAINT FK_ACC_BILL_TRAN_PROCESS_GODOWNS_NAME REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BILL_QUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_UOM VARCHAR(10)  NULL,";
                    strSQL = strSQL + "BILL_PER VARCHAR(10)  NULL,";
                    strSQL = strSQL + "AGST_REF_NO_KEY varchar(50) NULL ,";
                    strSQL = strSQL + "AGST_COMP_REF_NO varchar(30) NULL,";
                    strSQL = strSQL + "ADD_LESS_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BILL_NET_AMOUNT numeric (18,2) default 0 NOT NULL, ";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null ";
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
        private static string CreateInvProfitReport()
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
                    strSQL = "CREATE TABLE INV_PROFIT_REPORT ( ";
                    strSQL = strSQL + "STOCKITEM_NAME varchar (60)   NULL ,";
                    strSQL = strSQL + "STOCKGROUP_NAME varchar (50)  NULL, ";
                    strSQL = strSQL + "SALES_AMOUNT numeric(18, 2) default 0 NOT NULL ,";
                    strSQL = strSQL + "SALES_QUANTITY numeric(18, 2) default 0 NOT NULL ,";
                    strSQL = strSQL + "COST_RATE numeric(18, 2) default 0 NOT NULL ,";
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
        private static string CreateSalesBonus()
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
                    strSQL = "CREATE TABLE INV_SALES_BONUS(";
                    strSQL = strSQL + "BONUS_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "BONUS_KEY varchar(58) CONSTRAINT PK_INV_SALES_BONUS PRIMARY KEY,";//    'Stock  Int Item + Eff Date    yyyymmdd
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "BONUS_EFFECTIVE_DATE datetime NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "QTY numeric(12,2) NOT NULL,";
                    strSQL = strSQL + "BONUS_QTY numeric(12,2) default 0 NOT NULL,";
                    strSQL = strSQL + "BONUS_UOM varchar(50) NOT NULL,";
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
        private static string CreateSalesGift()
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

                    strSQL = "CREATE TABLE INV_SALES_GIFT(";
                    strSQL = strSQL + "GIFT_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "GIFT_KEY varchar(68) CONSTRAINT PK_INV_SALES_GIFT PRIMARY KEY,";//    'Stock  Int Item + Eff Date    yyyymmdd
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "GIFT_EFFECTIVE_DATE datetime NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "QTY numeric(12,2) NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_NAME_GIFT varchar(60) NOT NULL, ";
                    strSQL = strSQL + "GIFT_QTY numeric(12,2) default 0 NOT NULL,";
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

        private static string CreateAccPOSConfig()
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
                    strSQL = " CREATE TABLE ACC_POS_CONFIG (";
                    strSQL = strSQL + "POS_CONFIG_NO numeric(18, 0) IDENTITY (1, 1) CONSTRAINT PK_ACC_POS_CONFIG PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "POS_HEADER varchar(300)  NULL ,";
                    strSQL = strSQL + "POS_FOOTER varchar(300)  NULL ,";
                    strSQL = strSQL + "SALES_LEDGER varchar(60)  NOT NULL ,";
                    strSQL = strSQL + "DEFAULT_LEDGER varchar(60)  NOT NULL ,";
                    strSQL = strSQL + "ADD_LESS_LEDGER varchar(60)  NOT NULL ,";
                    strSQL = strSQL + "VAT_LEDGER varchar(60)  NOT NULL ,";
                    strSQL = strSQL + "INSERT_DATE DateTime default getdate() not null ";
                    strSQL = strSQL + " )";
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
        private static string CreateCompanyVoucherPOSMaster()
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

                    strSQL = "CREATE TABLE ACC_COMPANY_VOUCHER_POS_MASTER(";
                    strSQL = strSQL + "INVOICE_NO VARCHAR(50) CONSTRAINT PK_ACC_COMP_VOUCHER_POS PRIMARY KEY NOT NULL,";
                    // 'strSQL = strSQL + "BRANCH_ID char (4) CONSTRAINT PK_ACC_BRANCH PRIMARY KEY NOT NULL,"
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_COM_VOU_POSMASTER_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "INVOICE_DATE DATETIME DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "POS_USER VARCHAR(50) NOT NULL,";
                    strSQL = strSQL + "CUSTOMER_NAME VARCHAR(100) NULL,";
                    strSQL = strSQL + "CUSTOMER_PHONE VARCHAR(50) NULL,";
                    strSQL = strSQL + "SUB_TOTAL numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "DISCOUNT_PERCENTAGE numeric (18,2) default 0 not NULL,";
                    strSQL = strSQL + "DISCOUNT_SIGN  SMALLINT DEFAULT 0 not NULL,";//    'Change OPI 12/09/2006
                    strSQL = strSQL + "TOTAL_VAT numeric (18,2)default 0 not NULL,";
                    strSQL = strSQL + "CASH_PAY numeric (18,2) default 0 not NULL,";
                    strSQL = strSQL + "CHEQUE_PAY numeric (18,2) default 0 not NULL,";
                    strSQL = strSQL + "CHEQUE_NO varchar(60) NULL,";
                    strSQL = strSQL + "CARD_PAY numeric (18,2) default 0 not NULL,";
                    strSQL = strSQL + "CARD_NO varchar(50) NULL,";
                    strSQL = strSQL + "CARD_EXP_DATE DATETIME NULL,";
                    strSQL = strSQL + "BALANCE numeric (18,2) default 0 not NULL,";
                    strSQL = strSQL + "PAID_AMOUNT numeric (18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "CHANGE_AMOUNT numeric (18,2) default 0 not NULL,";
                    //'strSQL = strSQL + "CASH_LEDGER varchar(60)  NULL,"
                    strSQL = strSQL + "CASH_LEDGER varchar(60) NULL CONSTRAINT FK_ACC_COM_VOU_POS_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BANK_LEDGER varchar(60) NULL,";
                    strSQL = strSQL + "CARD_LEDGER varchar(60) NULL,";
                    strSQL = strSQL + "ADD_LESS_LEDGER varchar(60)  NULL,";
                    strSQL = strSQL + "VAT_LEDGER varchar(60) NULL,";
                    strSQL = strSQL + "SALES_LEDGER varchar(60) NOT NULL,";
                    strSQL = strSQL + "POSTED smallint default 0 NOT NULL,";
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
        private static string CreateCompanyVoucherPOSTran()
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

                    strSQL = "CREATE TABLE ACC_COMPANY_VOUCHER_POS_TRAN(";
                    strSQL = strSQL + "SERIAL_NO numeric(18, 0) IDENTITY (1, 1) NOT NULL,";
                    //'strSQL = strSQL + "BRANCH_ID char (4) CONSTRAINT PK_ACC_BRANCH PRIMARY KEY NOT NULL,"
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_ACC_COM_VOU_POSTRAN_B_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "BILL_TRAN_KEY VARCHAR(50) CONSTRAINT PK_ACC_POS_TRAN PRIMARY KEY,";
                    strSQL = strSQL + "INVOICE_NO varchar(50)  NOT NULL CONSTRAINT FK_ACC_COMPANY_VOUCHER_POS_TRAN REFERENCES ACC_COMPANY_VOUCHER_POS_MASTER(INVOICE_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "POS_TRAN_POSITION numeric(18, 0) NOT NULL ,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_ACC_POS_TRAN_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKITEM_ALIAS varchar (50) NOT NULL ,";
                    strSQL = strSQL + "STOCKITEM_DESCRIPTION varchar(50) NULL ,";
                    strSQL = strSQL + "BILL_QUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_BASEUNITS varchar(10) NOT NULL ,";
                    strSQL = strSQL + "BILL_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "VAT_AMOUNT numeric(18, 2) default 0 not NULL ,";
                    strSQL = strSQL + "BILL_AMOUNT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL";
                    strSQL = strSQL + " ) ";
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
        private static string CreateVoucherBatch()
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
                    strSQL = "ALTER TABLE ACC_VOUCHER ADD ";
                    strSQL = strSQL + "INV_LOG_NO varchar (50) NULL CONSTRAINT FK_ACC_VOUCHER_INV_LOG_NO REFERENCES INV_BATCH(INV_LOG_NO) ON UPDATE CASCADE ";
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
        private static string CreateVoucherBatchApp()
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
                    strSQL = "ALTER TABLE SMA_ACC_VOUCHER_APPR ADD ";
                    strSQL = strSQL + "INV_LOG_NO varchar (50) NULL CONSTRAINT FK_ACC_VOUCHER_APPR_INV_LOG_NO REFERENCES INV_BATCH(INV_LOG_NO) ON UPDATE CASCADE";
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
        private static string CreateStockRequisitionMaster()
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
                    strSQL = "CREATE TABLE INV_STOCK_REQUISITION_MASTER(";
                    strSQL = strSQL + "REQUISITION_NO VARCHAR(30) CONSTRAINT PK_PRIMARY_KEY_REQUISITION_NO PRIMARY KEY NOT NULL,";
                    strSQL = strSQL + "INVOICE_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_INV_STOCK_REQUISITION_MASTER_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID) ON UPDATE CASCADE,";
                    strSQL = strSQL + "NARRATIONS VARCHAR(200)  NULL,";
                    strSQL = strSQL + "REQ_STATUS SMALLINT DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "NET_TOTAL NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_VOUCHER_TYPE NUMERIC(18,0) NOT NULL";
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
        private static string CreateStockRequisitionChild()
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
                    strSQL = "CREATE TABLE INV_STOCK_REQUISITION_CHILD(";
                    strSQL = strSQL + "REQUISITION_NO varchar(15) NOT NULL CONSTRAINT FK_INV_STOCK_REQUISITION_CHILD_REQUISITION_NO REFERENCES INV_STOCK_REQUISITION_MASTER(REQUISITION_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_STOCK_REQUISITION_CHILD_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "ITEM_QTY NUMERIC(18,0) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "ITEM_RATE NUMERIC(18,0) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + " UNIT VARCHAR(10) NOT NULL,";
                    strSQL = strSQL + "ITEM_AMOUNT NUMERIC(18,0) DEFAULT 0 NOT NULL ";
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
        private static string CreateStockRequisition()
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
                    strSQL = "CREATE TABLE INV_STOCK_REQUISITION(";
                    strSQL = strSQL + "REQUISITION_NO varchar(15) NOT NULL CONSTRAINT FK_INV_STOCK_REQUISITION_REQUISITION_NO REFERENCES INV_STOCK_REQUISITION_MASTER(REQUISITION_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "INV_REF_NO VARCHAR(30) NOT NULL CONSTRAINT FK_INV_STOCK_REQUISITIONINV_REF_NO REFERENCES INV_MASTER(INV_REF_NO) ON UPDATE CASCADE ";
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
        private static string mCreateDumpLedger()
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
                    strSQL = "create table SMA_LEDGER_FIXED(";
                    strSQL = strSQL + " LEDGER_NAME varchar(60) NULL";
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
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnmain;
                    strSQL = "CREATE TABLE SMT_CONFIG(";
                    strSQL = strSQL + "CONFIG_INDEX  NUMERIC(18,0) PRIMARY KEY,";
                    strSQL = strSQL + "CONFIG_NAME VarChar(100)";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(1,'Voyage No')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(2,'Stock Absorved')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(3,'Branch Name')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(4,'Process Information')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(5,'Booking Information')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(6,'Application Form')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(7,'Sales Invoice')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(8,'Purchase Invoice')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(9,'Supplier Information')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(10,'Customer Information')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(11,'Payment')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(12,'Receipt')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(13,'Journal')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(14,'Contra')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(15,'Voucher Types')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_CONFIG(CONFIG_INDEX,CONFIG_NAME) VALUES(16,'Groups')";
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
        private static string CreateBookingInformationMaster()
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
                    strSQL = "CREATE TABLE SMA_BOOKING_INFORMATION_MASTER(";
                    strSQL = strSQL + "TEMPLATE_NAME varchar(60) NOT NULL CONSTRAINT PK_SMA_BOOKING_INFORMATION PRIMARY KEY,";
                    strSQL = strSQL + "TORAL_LAND_AREA NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PRICE_PER_UNIT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "TOTAL_AMOUNT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BOOKING_AMOUNT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "NET_AMOUNT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BOOKING_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "NO_OF_INTALLMENT NUMERIC(18,0) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PAYMENT_FREQUENT VARCHAR(60) NOT NULL ";
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
        private static string CreateBookingInformationChild()
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
                    strSQL = "CREATE TABLE SMA_BOOKING_INFORMATION_CHILD(";
                    strSQL = strSQL + "TEMPLATE_NAME varchar(60) NOT NULL CONSTRAINT FK_SMA_BOOKING_INFORMATION_CHILD_TEMPLATE_NAME REFERENCES SMA_BOOKING_INFORMATION_MASTER(TEMPLATE_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "INSTALLMENT_NAME VARCHAR(60) NOT NULL,";
                    strSQL = strSQL + "INSTALLMENT_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "INTALLMENT_AMOUNT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "COMISSION NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INTEREST NUMERIC(18,2) DEFAULT 0 NOT NULL ";
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
        private static string CreateAdmissionForm()
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
                    strSQL = "Create Table SMA_ADMISSION_FORM(";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_SMA_ADMISSION_FORM_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "CUSTOMER_ID VARCHAR(15) NOT NULL CONSTRAINT PK_CUSTOMER_ID PRIMARY KEY,";
                    strSQL = strSQL + "FATHERS_NAME VARCHAR (60) NULL,";
                    strSQL = strSQL + "HUSBAND_NAME VARCHAR (60) NULL,";
                    strSQL = strSQL + "MOTHERS_NAME VARCHAR (60) NULL,";
                    strSQL = strSQL + "CONTACT_PERSON VARCHAR (60) NULL,";
                    strSQL = strSQL + "CONTACT_ADDRESS VARCHAR (200) NULL,";
                    strSQL = strSQL + "MOBILE_NO1 VARCHAR (60) NULL,";
                    strSQL = strSQL + "MOBILE_NO2 VARCHAR (60) NULL,";
                    strSQL = strSQL + "RESIDENCE_NO VARCHAR (60) NULL,";
                    strSQL = strSQL + "OFFICE_NO VARCHAR (100) NULL,";
                    strSQL = strSQL + "FAX VARCHAR (100) NULL,";
                    strSQL = strSQL + "E_MAIL VARCHAR (60) NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_SMA_ADMISSION_FORM_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID) ON UPDATE CASCADE,";
                    strSQL = strSQL + "BLOCK_NAME VARCHAR (60) NULL,";
                    strSQL = strSQL + "AREA VARCHAR (60) NULL,";
                    strSQL = strSQL + "FACING VARCHAR (60) NULL,";
                    strSQL = strSQL + "PLOT_SIZE NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PRICE_PER_KHATHA NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "TOTAL_PRICE NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "PAYMENT_MODE SMALLINT DEFAULT 0 NOT NULL,";
                    //''1=CASH,0 =INSTALMENT
                    strSQL = strSQL + "NO_OF_INSTALLMENT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "MONTHLY_INSTALLMENT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BOOKING_MONEY NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "DOWN_PAYMENT NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "DATE_OF_BOOKING DATETIME NULL,";
                    strSQL = strSQL + "CALCULATION_DATE DATETIME NULL,";
                    strSQL = strSQL + "PROFESSION_NAME VARCHAR (60) NULL,";
                    strSQL = strSQL + "AGE NUMERIC(18,0) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "NATIONALITY VARCHAR (60) NULL,";
                    strSQL = strSQL + "NATIONAL_ID_CARD VARCHAR (60) NULL,";
                    strSQL = strSQL + "PRESENT_ADDRESS1 VARCHAR (100) NULL,";
                    strSQL = strSQL + "PRESENT_ADDRESS2 VARCHAR (100) NULL,";
                    strSQL = strSQL + "VILLAGE VARCHAR (60) NULL,";
                    strSQL = strSQL + "P_OFFICE VARCHAR (60) NULL,";
                    strSQL = strSQL + "THANA VARCHAR (60) NULL,";
                    strSQL = strSQL + "DISTRICT VARCHAR (60) NULL,";
                    strSQL = strSQL + "REPRESENTATIVE VARCHAR (60) NULL CONSTRAINT FK_SMA_ADMISSION_FORM_REPRESENTATIVE REFERENCES ACC_LEDGER(LEDGER_NAME),";
                    strSQL = strSQL + "REPESENTATIVE_ADDRESS VARCHAR (60) NULL,";
                    strSQL = strSQL + "NOMINEE_NAME VARCHAR (60) NULL,";
                    strSQL = strSQL + "RELATIONSHIP VARCHAR (60) NULL,";
                    strSQL = strSQL + "REFERENCE VARCHAR (60) NULL,";
                    strSQL = strSQL + "WORK_STA_NAME VARCHAR(100) NULL,";
                    strSQL = strSQL + "DESIGNATION_NAME VARCHAR(100) NULL ,";
                    strSQL = strSQL + "MONTHLY_INCOME NUMERIC(18,2) default 0  NULL ,";
                    strSQL = strSQL + "MARITAL_STATUS VARCHAR(60) NULL ,";
                    strSQL = strSQL + "NO_OF_FAMILY_MEMBER VARCHAR(60) NULL ,";
                    strSQL = strSQL + "NO_OF_EARNING_MEMBER VARCHAR(60) NULL, ";
                    strSQL = strSQL + "PRODUCT_NAME VARCHAR(100) NULL ,";
                    strSQL = strSQL + "MODEL_NAME VARCHAR(100) NULL ,";
                    strSQL = strSQL + "CASH_PRICE NUMERIC(18,2) default 0  NULL ,";
                    strSQL = strSQL + "SALES_CENTER_NAME VARCHAR(100) NULL ,";
                    strSQL = strSQL + "PURCHASE_DATE DATETIME NULL ,";
                    strSQL = strSQL + "PRESENT_STATUS VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR1_NAME VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR1_F_NAME VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR1_PRESET_ADDRES VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR1_PERMANNET_ADDRE VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR1_PHONE VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR1_PRFESSION VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR1_DESIGNATION VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR1_MONTHLY_INCOME VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR2_NAME VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR2_F_NAME VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR3_PRESET_ADDRES VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR2_PERMANNET_ADDRE VARCHAR(100) NULL, ";
                    strSQL = strSQL + "GRANTOR2_PHONE VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR2_PRFESSION VARCHAR(100) NULL ,";
                    strSQL = strSQL + "GRANTOR2_DESIGNATION VARCHAR(100) NULL, ";
                    strSQL = strSQL + "GRANTOR2_MONTHLY_INCOME NUMERIC(18,2) default 0 NULL ,";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE SMA_CUSTOMER_IMAGE(";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_SMA_CUSTOMER_IMAGE_LEDGER REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "LEDGER_IMAGE image NULL ";
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
        private static string mCreateBatchConfig()
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
                    strSQL = "CREATE TABLE SMT_BATCH_CONFIG(";
                    strSQL = strSQL + "SL_NO NUMERIC(18,0) DEFAULT 0 NOT NULL ,";
                    strSQL = strSQL + "PARTICULARS VARCHAR(60) NULL ";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_BATCH_CONFIG (SL_NO,PARTICULARS)VALUES(1,'NRT_NO')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_BATCH_CONFIG (SL_NO,PARTICULARS)VALUES(2,'GRT_NO')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_BATCH_CONFIG (SL_NO,PARTICULARS)VALUES(3,'COMMIDITY')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_BATCH_CONFIG (SL_NO,PARTICULARS)VALUES(4,'QUANTITY')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_BATCH_CONFIG (SL_NO,PARTICULARS)VALUES(5,'STATUS')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_BATCH_CONFIG (SL_NO,PARTICULARS)VALUES(6,'PARTY_NAME')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_BATCH_CONFIG (SL_NO,PARTICULARS)VALUES(7,'BIRTH_DATE')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_BATCH_CONFIG (SL_NO,PARTICULARS)VALUES(8,'EXPIRE_DATE')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_BATCH_CONFIG (SL_NO,PARTICULARS)VALUES(9,'START_DATE')";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMT_BATCH_CONFIG (SL_NO,PARTICULARS)VALUES(10,'END_DATE')";
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
        private static string CreateLogo()
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
                    strSQL = "CREATE TABLE SMA_LOGO(";
                    strSQL = strSQL + "COMP_LOGO_NO SMALLINT DEFAULT 0 NOT NULL CONSTRAINT PK_COMP_LOGO_NO PRIMARY KEY,";
                    strSQL = strSQL + "LOGO_NAME image NULL ";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "INSERT INTO SMA_LOGO(COMP_LOGO_NO)VALUES(0) ";
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
        private static string CreateTableSalesStock()
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
                    strSQL = "CREATE TABLE SALES_STOCK_DUMP(";
                    strSQL = strSQL + "STOCKITEM_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "STOCKITEM_BASEUNITS VARCHAR(60) NULL,";
                    strSQL = strSQL + "STOCKITEM_ADDITIONALUNITS VARCHAR(60) NULL,";
                    strSQL = strSQL + "STOCKITEM_CONVERSION NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "STOCKITEM_DENOMINATOR NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BILL_QUANTITY NUMERIC(18,2) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "BILL_RATE NUMERIC(18,2) DEFAULT 0 NOT NULL,";

                    strSQL = strSQL + "COMP_REF_NO VARCHAR(60) NULL,";
                    strSQL = strSQL + "AGST_REF_NO VARCHAR(60) NULL";
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
        private static string CreateTableSMS()
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
                    strSQL = "CREATE TABLE SMS_TEXT(";
                    strSQL = strSQL + "SMS_NAME VARCHAR(1000) NULL,";
                    strSQL = strSQL + "LEDGER_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "MOBILE_NO VARCHAR(15) NULL,";
                    strSQL = strSQL + "USER_NAME VARCHAR(60) NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE SMS_MASTER(";
                    strSQL = strSQL + "SMS_NO VARCHAR(60) NULL,";
                    strSQL = strSQL + "SMS_NAME VARCHAR(1000) NULL ";
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

        private static string CreateGuaranteeCard()
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
                    strSQL = "CREATE TABLE JAG_SERVICE_TYPE(";
                    strSQL = strSQL + "SERVICE_TYPE VARCHAR(60)NOT NULL CONSTRAINT PK_JAG_SERVICE_TYPE PRIMARY KEY";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE JAG_GUARANTEE_CARD(";
                    strSQL = strSQL + "SERIAL_NO VARCHAR(80) NOT NULL CONSTRAINT PK_JAG_GUARANTEE_CARD_SL PRIMARY KEY,";
                    strSQL = strSQL + "CLIENT_NAME VARCHAR(60) NOT NULL,";
                    strSQL = strSQL + "CLIENT_ADDRESS VARCHAR(100) NULL,";
                    strSQL = strSQL + "PHONE_NO VARCHAR(50) NULL,";
                    strSQL = strSQL + "MOBILE_NO VARCHAR(50) NULL,";
                    strSQL = strSQL + "MODEL_NO VARCHAR(60) NOT NULL CONSTRAINT FK_JAG_GUARANTEE_CARD_MODEL_NO REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "PURCHASE_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "LEDGER_NAME varchar (60) NOT NULL CONSTRAINT FK_JAG_GUARANTEE_CARD_LEDGER_NAME REFERENCES ACC_LEDGER(LEDGER_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TABLE JAG_GUARANTEE_CARD_TEMP(";
                    strSQL = strSQL + "SERIAL_NO varchar (80) NOT NULL CONSTRAINT FK_JAG_GUARANTEE_CARD_TEMP_SERIAL_NO REFERENCES JAG_GUARANTEE_CARD(SERIAL_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "SERVICE_TYPE VARCHAR(60)NOT NULL CONSTRAINT FK_JAG_GUARANTEE_CARD_TEMP_SERVICE_TYPE REFERENCES JAG_SERVICE_TYPE(SERVICE_TYPE) ON UPDATE CASCADE,";
                    strSQL = strSQL + "SERVICE_MODE VARCHAR(10) NOT NULL,";
                    strSQL = strSQL + "EXPIRE_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "SERVICE_LENGTH NUMERIC(18,2) DEFAULT 0 NOT NULL";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE JAG_SERVICE_DETAILS(";
                    strSQL = strSQL + "DETAILS_NO NUMERIC(18,0) IDENTITY(18,1) NOT NULL CONSTRAINT PK_DETAILS_NO_DETAILS_NO PRIMARY KEY,";
                    strSQL = strSQL + "SERIAL_NO varchar (80) NOT NULL CONSTRAINT FK_JAG_SERVICE_DETAILS_SERIAL_NO REFERENCES JAG_GUARANTEE_CARD(SERIAL_NO) ON UPDATE CASCADE,";
                    strSQL = strSQL + "SERVICE_DATE DATETIME NOT NULL,";
                    strSQL = strSQL + "PROBLEM_DETAILS VARCHAR(200) NULL,";
                    strSQL = strSQL + "SERVICE_DETAILS VARCHAR(200) NULL";
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
        private static string CreateStockOthers()
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
                    strSQL = "CREATE TABLE INV_STOCKOTHERS_CATEGORY(";
                    strSQL = strSQL + "STOCKOTHERS_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "STOCKOTHERS_NAME varchar(70) CONSTRAINT PK_INV_STOCKOTHERS_CATEGORY PRIMARY KEY,";
                    strSQL = strSQL + "STOCKOTHERS_PARENT varchar(70) NOT NULL,";
                    strSQL = strSQL + "STOCKOTHERS_PRIMARY varchar(70) NOT NULL,";
                    strSQL = strSQL + "STOCKOTHERS_OPENING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKOTHERS_CLOSING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKOTHERS_INWARDQUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKOTHERS_OUTWARDQUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKOTHERS_DEBIT_CLOSING_BAL numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "STOCKOTHERS_TYPE smallint default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null";
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
        private static string CreateStockMultipleItem()
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
                    strSQL = "CREATE table INV_ITEM_MULTIPLE_T(";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_ITEM_MULTIPLE_T_STOCKITEM_NAME  REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKOTHERS_NAME varchar(70) NULL CONSTRAINT FK_INV_ITEM_MULTIPLE_T_STOCKOTHERS_NAME REFERENCES INV_STOCKOTHERS_CATEGORY(STOCKOTHERS_NAME)";
                    strSQL = strSQL + ")";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE table INV_ITEM_MULTIPLE_W(";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_ITEM_MULTIPLE_W_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    strSQL = strSQL + "STOCKCATEGORY_NAME varchar(50) NULL CONSTRAINT FK_INV_ITEM_MULTIPLE_W_STOCKCATEGORY_NAME REFERENCES INV_STOCKCATEGORY(STOCKCATEGORY_NAME)";
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
        private static string CreateEnclosed()
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

                    strSQL = "CREATE TABLE CNF_ENCLOSED(";
                    strSQL = strSQL + "ENCLOSED_NAME VARCHAR(300) NULL";
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

        private static string CreateManualStockTemp()
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
                    strSQL = "CREATE TABLE SMA_AUTO_GENERATE_MANUAL_STOCK(";
                    strSQL = strSQL + "MANUAL_KEY VARCHAR(70) NOT NULL CONSTRAINT PK_PRIMARY_KAY PRIMARY KEY,";
                    strSQL = strSQL + "BRANCH_ID VARCHAR(4) NULL,";
                    strSQL = strSQL + "GROUP_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "ACC_LEDGER VARCHAR(60) NULL,";
                    strSQL = strSQL + "VOUCHER_DATE DATETIME NULL,";
                    strSQL = strSQL + "ITEM_NAME VARCHAR(60) NULL,";
                    strSQL = strSQL + "INV_QTY NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_RATE NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "INV_AMOUNT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "T0_BY VARCHAR(2) NULL";
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
        private static string CreateItemSLHW()
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
                    //strSQL = "CREATE TABLE INV_TRAN_HARDWARE_SL_REF(";
                    //strSQL = strSQL + "HW_SL_NO VARCHAR(60) NOT NULL CONSTRAINT PK_HW_SL_REF PRIMARY KEY,";
                    //strSQL = strSQL + "COMP_REF_NO VARCHAR(30) NOT NULL CONSTRAINT FK_INV_TRAN_HARWARE_SL REFERENCES INV_MASTER(INV_REF_NO) ON UPDATE CASCADE,";
                    //strSQL = strSQL + "VT_TRAN_DATE DATETIME NOT NULL,";
                    //strSQL = strSQL + "BRANCH_ID VARCHAR(4) NOT NULL,";
                    //strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_INV_TRAN_HARDWARE_SL_REF_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    ////'        strSQL = strSQL + "ITEM_QTY NUMERIC(18,2) DEFAULT 0 NOT NULL,"
                    //strSQL = strSQL + "SL_NO NUMERIC(18,0) DEFAULT 0 NOT NULL,";
                    //strSQL = strSQL + "LIST_REF_NO VARCHAR(60) NOT NULL ,";
                    //strSQL = strSQL + "VTYPE NUMERIC(18,0) DEFAULT 0 NOT NULL,";
                    //strSQL = strSQL + "HW_SL_STATUS SMALLINT DEFAULT 0 NOT NULL,";
                    //strSQL = strSQL + "VOUCHER_REF_NO VARCHAR(30) NULL,";
                    //strSQL = strSQL + "AGNST_REF_NO VARCHAR(30) NULL,";
                    //strSQL = strSQL + "WARENTY_DATE DATETIME NULL,";
                    //strSQL = strSQL + "EXPIRE_DATE DATETIME NULL";
                    //strSQL = strSQL + ")";
                    //cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();
                    //strSQL = "CREATE TABLE SMA_HW_CUS_RECEIVED_MAS(";
                    //strSQL = strSQL + "CUS_REF_NO VARCHAR(60) NOT NULL CONSTRAINT PK_CUS_REF_NO PRIMARY KEY,";
                    //strSQL = strSQL + "VOUCHER_TYPE NUMERIC(9,0) NOT NULL,";
                    //strSQL = strSQL + "COMP_VOUCHER_DATE DATETIME NOT NULL,";
                    //strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_CUS_REC_BRANCH_ID REFERENCES ACC_BRANCH(BRANCH_ID),";
                    //strSQL = strSQL + "GODOWNS_NAME varchar(50) NOT NULL CONSTRAINT FK_GODOWNS_NAME_CUS_REC REFERENCES INV_GODOWNS(GODOWNS_NAME) ON UPDATE CASCADE,";
                    //strSQL = strSQL + "F_BRANCH_ID char (4) NOT NULL ,";
                    //strSQL = strSQL + "SI_REF_NO VARCHAR(30) NULL,";
                    //strSQL = strSQL + "AGNST_REF_NO VARCHAR(30) NULL,";
                    ////'' CONSTRAINT FK_AGNST_REF_NO_CUS_REC REFERENCES INV_MASTER(INV_REF_NO) ON UPDATE CASCADE,"
                    //strSQL = strSQL + "CUSTOMER_NAME VARCHAR(100),";
                    //strSQL = strSQL + "NARRATIONS VARCHAR(100) NULL,";
                    //strSQL = strSQL + "COMP_VOUCHER_AMOUNT NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    //strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    //strSQL = strSQL + "UPDATE_DATE datetime  NULL";
                    //strSQL = strSQL + ")";
                    //cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();
                    //strSQL = "CREATE TABLE SMA_HW_CUS_RECEIVED_TRAN(";
                    //strSQL = strSQL + "CUS_REF_NO VARCHAR(60) NOT NULL CONSTRAINT FK_CUS_REF_NO_CUS_REC_TRAN REFERENCES SMA_HW_CUS_RECEIVED_MAS(CUS_REF_NO) ON UPDATE CASCADE,";
                    //strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_CUS_REC_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    //strSQL = strSQL + "HW_SL_NO VARCHAR(60) NOT NULL,";
                    ////''CONSTRAINT FK_CUS_REC_TRAN_HW_SL_NO REFERENCES INV_TRAN_HARDWARE_SL_REF(HW_SL_NO),"
                    //strSQL = strSQL + "PROBLEM_DES VARCHAR(100),";
                    //strSQL = strSQL + "ITEM_QNTY NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    //strSQL = strSQL + "ITEM_RATE NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    //strSQL = strSQL + "ITEM_AMOUNT NUMERIC(18,4) DEFAULT 0 NOT NULL";
                    //strSQL = strSQL + ")";
                    //cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();

                    //strSQL = "CREATE TABLE SMA_HW_ISSUE_TO_CUS(";
                    //strSQL = strSQL + "CUS_REF_NO VARCHAR(60) NOT NULL CONSTRAINT FK_SMA_HW_ISSUE_TO_CUS_REC_TRAN REFERENCES SMA_HW_CUS_RECEIVED_MAS(CUS_REF_NO) ON UPDATE CASCADE,";
                    //strSQL = strSQL + "OLD_STOCKITEM VARCHAR(60) NULL,";
                    //strSQL = strSQL + "OLD_HW_SL_NO VARCHAR(60) NULL,";
                    //strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_SMA_HW_ISSUE_TO_CUS_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    //strSQL = strSQL + "HW_SL_NO VARCHAR(60) NOT NULL CONSTRAINT FK_SMA_HW_ISSUE_TO_CUS_HW_SL_NO REFERENCES INV_TRAN_HARDWARE_SL_REF(HW_SL_NO),";
                    //strSQL = strSQL + "REMARKS VARCHAR(50) NULL";
                    //strSQL = strSQL + ")";
                    //cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();
                    //strSQL = "CREATE TABLE SMA_HW_ADDITIONAL_ITEM(";
                    //strSQL = strSQL + "CUS_REF_NO VARCHAR(60) NOT NULL CONSTRAINT FK_SMA_HW_ADDITIONAL_ITEM_REC_TRAN REFERENCES SMA_HW_CUS_RECEIVED_MAS(CUS_REF_NO) ON UPDATE CASCADE,";
                    //strSQL = strSQL + "STOCKITEM_NAME varchar(60) NOT NULL CONSTRAINT FK_SMA_HW_ADDITIONAL_ITEM_STOCKITEM_NAME REFERENCES INV_STOCKITEM(STOCKITEM_NAME) ON UPDATE CASCADE,";
                    //strSQL = strSQL + "ITEM_QNTY NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    //strSQL = strSQL + "ITEM_RATE NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    //strSQL = strSQL + "ITEM_AMOUNT NUMERIC(18,4) DEFAULT 0 NOT NULL";
                    //strSQL = strSQL + ")";
                    //cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();

                    strSQL = "CREATE TABLE ITEM_LAST_SALES_PRICE(";
                    strSQL = strSQL + "STOCKITEM_NAME varchar(60) null,";
                    strSQL = strSQL + "ITEM_ALIAS varchar(100) null,";
                    strSQL = strSQL + "ITEM_RATE NUMERIC(18,4) DEFAULT 0 NOT NULL,";
                    strSQL = strSQL + "VAT varchar(30) null";
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
