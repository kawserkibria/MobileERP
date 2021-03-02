using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using JA.Modulecontrolar.UI.DReport.Accms;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;

using Microsoft.Win32;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using Mayhedi.Office.Excel.Reader;
using JA.Modulecontrolar.UI.Sales.Forms;

namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmSplitCompany : JA.Shared.UI.frmSmartFormStandard
    {


        JACCMS.SWJAGClient accms = new SWJAGClient();

        private string strComID { get; set; }
        private string mstrCurSymbol;
        private string mstrCurFormallName;
        private string mstrCurString;
        private long mlngCurDecimalPl;
        private byte[] _imageData;
        public frmSplitCompany()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dtefinancialform.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpFromDate_KeyPress);
            this.dteFinanicalTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpToDate_KeyPress);
            this.txtCompanyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCompanyName_KeyPress);

        }
        #region User Define code



        #endregion

        private void dtpFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteFinanicalTo.Focus();
            }
        }
        private void txtCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnSave.Focus();
            }
        }
        private void dtpToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtCompanyName.Text = Utility.gstrCompanyName + "-" + dtefinancialform.Value.ToString("dd-MM-yyyy");
                txtCompanyName.Focus();
            }
        }
        private void changeRegionalSetting()
        {
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
            rkey.SetValue("sShortDate", "dd-MM-yyyy");
            rkey.Close();

        }

        private static string gCreatedatabase(string ServerName, string strCompanyID)
        {
            string conDb;
            string strdatabasename;
            string strSql;

            strdatabasename = "SMART" + strCompanyID;
            conDb = "Data Source=" + ServerName + " ;Initial Catalog= master;User ID=" + Utility.gstDatabaserUserName + " ;Password=" + Utility.gstDatabasePassword + " ";
            using (SqlConnection gcnmain = new SqlConnection(conDb))
            {
                strSql = "CREATE DATABASE " + strdatabasename;
                gcnmain.Open();
                SqlCommand cmd = new SqlCommand(strSql, gcnmain);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                return ServerName;
            }
        }



        private void mSaveCompanyInfo(string strCompnayID, string strBranchID)
        {
            string strSQL;
            long lngAccessType;
            long lngBusinessType;
            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
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

                lngBusinessType = Utility.glngGetBusinessType("Manufacturing Company");
                lngAccessType = 1;


                strSQL = "INSERT INTO ACC_COMPANY(COMPANY_ID,BRANCH_ID,COMPANY_NAME,COMPANY_INT_NAME,";
                strSQL = strSQL + "COMPANY_ADD1,";
                strSQL = strSQL + "COMPANY_ADD2,";
                strSQL = strSQL + "COMPANY_COUNTRY ,";
                strSQL = strSQL + "COMPANY_BUSINESS_TYPE,";
                strSQL = strSQL + "COMPANY_FINICIAL_YEAR_FROM , ";
                strSQL = strSQL + "COMPANY_FINICIAL_YEAR_TO, ";
                strSQL = strSQL + "COMPANY_BASE_CURRENCY_SYMBOL,COMPANY_ACCESS_CONTROL,";
                strSQL = strSQL + "BACKUP_TARGET, ";
                strSQL = strSQL + "COMPANY_BRANCH,IS_MULTIPLE_LOCATION";
                strSQL = strSQL + ")";
                strSQL = strSQL + "VALUES (";
                strSQL = strSQL + "'" + strCompnayID.Trim() + "',";
                strSQL = strSQL + "'" + strBranchID.Trim() + "',";
                strSQL = strSQL + "'" + txtCompanyName.Text.Replace("'", "''") + "',";
                strSQL = strSQL + "'" + txtCompanyName.Text.Replace("'", "''") + "',";
                strSQL = strSQL + "'Address1',";
                strSQL = strSQL + "'Address2',";
                strSQL = strSQL + "'Bangladesh',";

                strSQL = strSQL + " " + lngBusinessType + ",";
                strSQL = strSQL + " " + Utility.cvtSQLDate(dtefinancialform.Value) + ",";
                strSQL = strSQL + " " + Utility.cvtSQLDate(dteFinanicalTo.Value) + " ,";
                strSQL = strSQL + "'BDT',";
                strSQL = strSQL + " " + lngAccessType + ",";
                strSQL = strSQL + "'D:\',";
                strSQL = strSQL + "1,1";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                Utility.gstrCompanyName = txtCompanyName.Text.Replace("'", "''");
                Utility.gstrBranchID = strBranchID.Trim();
                Utility.gstrCompanyID = strCompnayID.Trim();
                strSQL = "INSERT INTO ACC_BRANCH(BRANCH_ID,BRANCH_NAME,BRANCH_INT_NAME,BRANCH_NAME_DEFAULT,BRANCH_TYPE) ";
                strSQL = strSQL + "VALUES(";
                strSQL = strSQL + "'" + strBranchID + "',";
                strSQL = strSQL + "'" + Utility.gstrCompanyName + "',";
                strSQL = strSQL + "'" + Utility.gstrCompanyName.Trim() + "',";
                strSQL = strSQL + "'" + Utility.gstrCompanyName.Trim() + "',";
                strSQL = strSQL + "1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                myTrans.Commit();
            }
        }

        #region "Split"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string ServerName, strCompanyID = "0001", strBarchID, strCompanyName;

            string strSQL;
            if (txtCompanyName.Text == "")
            {
                MessageBox.Show("Company Name Cannot be empty");
                txtCompanyName.Focus();
                return;
            }
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");

            SqlDataReader Dr;
            string conDb;
            changeRegionalSetting();

            strCompanyID = Utility.gstrGetLastSerl();
            strBarchID = "0001";
            txtCompanyName.Text = "Company Name - " + strCompanyID;
            Utility.strDataBase = "SMART" + strCompanyID;
            regKey.SetValue("gstrDataBaseName", Utility.strDataBase);
            regKey.SetValue("CompanyID", strCompanyID);

            ServerName = Utility.gGetServerName();
            conDb = "Data Source=" + ServerName + " ;Initial Catalog= master;User ID=" + Utility.gstDatabaserUserName + " ;Password=" + Utility.gstDatabasePassword + " ";
            strSQL = "SELECT NAME FROM master.dbo.sysdatabases WHERE NAME = '" + Utility.strDataBase + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strCompanyName = txtCompanyName.Text.Replace("'", "''");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                Dr = cmd.ExecuteReader();
                if ((Dr.Read()) != true)
                {
                    Utility.gstrCompanyID = strCompanyID.Trim();
                    Utility.gstrBranchID = strBarchID.Trim();
                    Utility.gstrCompanyName = strCompanyName;
                    Utility.gdteFinancialYearFrom = Utility.DateFormat(dtefinancialform.Value);
                    Utility.gdteFinancialYearTo = Utility.DateFormat(dteFinanicalTo.Value);
                    Utility.gstrFinicialYearFrom = Utility.gstrDateToStr(dtefinancialform.Text);
                    Utility.gstrFinicialYearTo = Utility.gstrDateToStr(dteFinanicalTo.Text);
                    Utility.gstrBusinessType = "Manufacturing Company";
                    mstrCurSymbol = "BDT";
                    mstrCurFormallName = "BDT";

                    mstrCurString = "";
                    mlngCurDecimalPl = 0;
                    gCreatedatabase(ServerName, strCompanyID);

                    basTableSchemaAccount.gCreateAccounts("Manufacturing Company");
                    proBar.Value = proBar.Value + 10;
                    basTableSchemaStock.gCreateStock();
                    proBar.Value = proBar.Value + 20;
                    basTableSchemaReport.gCreateTableReport();
                    proBar.Value = proBar.Value + 20;
                    basViewSchemaAccount.gCreateViewAccount();
                    basViewSchemaStock.gCreateViewStock();
                    basProcedure.gCreateAdavanceSP();
                    CreateDefaultdata.gInsertBaseCurrency(mstrCurSymbol, mstrCurFormallName, mstrCurString, mlngCurDecimalPl);
                    mSaveCompanyInfo(strCompanyID, strBarchID);

                    MemoryStream ms = new MemoryStream();
                    pbImage.Image.Save(ms, ImageFormat.Jpeg);
                    _imageData = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(_imageData, 0, _imageData.Length);
                    CreateDefaultdata.gInsertAccessControl("Deeplaid", "DeepLaid", _imageData, strBarchID);

                    string strSourceDB = "";

                    //strSourceDB = "SMART" + Utility.gstrCompanyID;
                    strSourceDB = "TROA0010";
                    Dr.Close();
                    gcnMain.Close();
                    string cnn = "";
                    SqlTransaction myTrans;
                    SqlCommand cmdInsert = new SqlCommand();
                    cnn = Utility.SQLConnstringComSwitch(strCompanyID);
                    using (SqlConnection gcnMainnew = new SqlConnection(cnn))
                    {
                        if (gcnMainnew.State == ConnectionState.Open)
                        {
                            gcnMainnew.Close();
                        }
                        gcnMainnew.Open();
                        myTrans = gcnMainnew.BeginTransaction();
                        cmdInsert.Connection = gcnMainnew;
                        cmdInsert.Transaction = myTrans;
                        //Accounts


                        strSQL = "INSERT INTO ACC_BRANCH(BRANCH_CREATE_DATE,BRANCH_ID,BRANCH_NAME,BRANCH_INT_NAME,BRANCH_NAME_DEFAULT,BRANCH_ADD1,BRANCH_ADD2,BRANCH_ADD3,BRANCH_ADD4,BRANCH_COUNTRY,";
                        strSQL = strSQL + "BRANCH_PHONE,BRANCH_FAX,BRANCH_STATUS,BRANCH_ACTIVE,BRANCH_TYPE,BRANCH_FLAG,BRANCH_COMMENTS,LOGO_REF,ENTRYBY,UPDATEBY) ";
                        strSQL = strSQL + "SELECT BRANCH_CREATE_DATE,BRANCH_ID,BRANCH_NAME,BRANCH_INT_NAME,BRANCH_NAME_DEFAULT,BRANCH_ADD1,BRANCH_ADD2,BRANCH_ADD3,BRANCH_ADD4,";
                        strSQL = strSQL + "BRANCH_COUNTRY,BRANCH_PHONE,BRANCH_FAX,BRANCH_STATUS,BRANCH_ACTIVE,BRANCH_TYPE,BRANCH_FLAG,BRANCH_COMMENTS,LOGO_REF,";
                        strSQL = strSQL + "ENTRYBY,UPDATEBY FROM " + strSourceDB + ".dbo.ACC_BRANCH WHERE BRANCH_ID <>'0001' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_VOUCHER_TYPE", 1);
                        



                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_DESTINATION", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_TERITORRY", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_MASTER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_COMMISSION_MASTER", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_COMMISSION_TRAN", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LEDGERGROUP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_GROUP_TO_LEDGER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();


                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LEDGER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LEDGER_TO_GROUP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                       

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "VECTOR_CATEGORY", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "VECTOR_MASTER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                     

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_UNIT_MEASUREMENT", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKGROUP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        proBar.Value = proBar.Value + 10;
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKCATEGORY", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCK_MATERIAL_TYPE", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_TO_STOCKITEM", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM", 1);
                        strSQL = "INSERT INTO INV_STOCKITEM(STOCKITEM_NAME,ITEM_NAME_BANGLA,STOCKITEM_ALIAS,STOCKITEM_DESCRIPTION,STOCKGROUP_NAME,STOCKCATEGORY_NAME,STOCKITEM_PRIMARY_GROUP,STOCKITEM_OPENING_BALANCE,";
                        strSQL = strSQL + "STOCKITEM_OPENING_VALUE,STOCKITEM_OPENING_RATE,STOCKITEM_CLOSING_BALANCE,STOCKITEM_INWARDQUANTITY,STOCKITEM_OUTWARDQUANTITY,STOCKITEM_BASEUNITS,STOCKITEM_ADDITIONALUNITS, ";
                        strSQL = strSQL + "STOCKITEM_CONVERSION,STOCKITEM_DENOMINATOR,STOCKITEM_MIN_QUANTITY,STOCKITEM_REORDER_LEVEL,STOCKITEM_MAINTAIN_SERIAL,SP_ITEM,STOCKITEM_MANUFACTURER,ISBN_NO,STOCKITEM_STATUS, ";
                        strSQL = strSQL + "STOCK_ITEM_SUPPLIER,SERIAL_STATUS,POWER_CLASS,MATERIAL_TYPE,INSERT_DATE,STOCKOTHERS_NAME,UPDATE_DATE) ";
                        strSQL = strSQL + "SELECT STOCKITEM_NAME,ITEM_NAME_BANGLA,STOCKITEM_ALIAS,STOCKITEM_DESCRIPTION,STOCKGROUP_NAME,STOCKCATEGORY_NAME,STOCKITEM_PRIMARY_GROUP,STOCKITEM_OPENING_BALANCE, ";
                        strSQL = strSQL + "STOCKITEM_OPENING_VALUE,STOCKITEM_OPENING_RATE,STOCKITEM_CLOSING_BALANCE,STOCKITEM_INWARDQUANTITY,STOCKITEM_OUTWARDQUANTITY,STOCKITEM_BASEUNITS, ";
                        strSQL = strSQL + "STOCKITEM_ADDITIONALUNITS,STOCKITEM_CONVERSION,STOCKITEM_DENOMINATOR,STOCKITEM_MIN_QUANTITY,STOCKITEM_REORDER_LEVEL,STOCKITEM_MAINTAIN_SERIAL, ";
                        strSQL = strSQL + "SP_ITEM,STOCKITEM_MANUFACTURER,ISBN_NO,STOCKITEM_STATUS,STOCK_ITEM_SUPPLIER,SERIAL_STATUS,POWER_CLASS,MATERIAL_TYPE,INSERT_DATE,STOCKOTHERS_NAME,UPDATE_DATE  ";
                        strSQL = strSQL + "FROM " + strSourceDB + ".dbo.INV_STOCKITEM WHERE STOCKITEM_STATUS =0 ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM_TO_GROUP", 1);
                        strSQL = "INSERT INTO INV_STOCKITEM_TO_GROUP(STOCKITEM_NAME,STOCKGROUP_NAME,INSERT_DATE,UPDATE_DATE) ";
                        strSQL = strSQL + "SELECT INV_STOCKITEM.STOCKITEM_NAME,INV_STOCKITEM_TO_GROUP.STOCKGROUP_NAME,INV_STOCKITEM_TO_GROUP.INSERT_DATE,INV_STOCKITEM_TO_GROUP.UPDATE_DATE ";
                        strSQL = strSQL + "FROM " + strSourceDB + ".dbo.INV_STOCKITEM_TO_GROUP," + strSourceDB + ".dbo.INV_STOCKITEM ";
                        strSQL = strSQL + "where INV_STOCKITEM.STOCKITEM_NAME =INV_STOCKITEM_TO_GROUP.STOCKITEM_NAME and INV_STOCKITEM.STOCKITEM_STATUS =0 ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM_LEVEL", 1);
                        strSQL = "INSERT INTO INV_STOCKITEM_LEVEL(STOCKITEM_NAME,STOCKGROUP_LEVEL_1,STOCKGROUP_LEVEL_2,STOCKGROUP_LEVEL_3,STOCKGROUP_LEVEL_4,STOCKGROUP_LEVEL_5,INSERT_DATE,UPDATE_DATE) ";
                        strSQL = strSQL + "SELECT INV_STOCKITEM.STOCKITEM_NAME,INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_1,INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_2,INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_3,INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_4,";
                        strSQL = strSQL + "INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_5,INV_STOCKITEM_LEVEL.INSERT_DATE,INV_STOCKITEM_LEVEL.UPDATE_DATE ";
                        strSQL = strSQL + "FROM " + strSourceDB + ".dbo.INV_STOCKITEM_LEVEL," + strSourceDB + ".dbo.INV_STOCKITEM WHERE INV_STOCKITEM.STOCKITEM_NAME=INV_STOCKITEM_LEVEL.STOCKITEM_NAME ";
                        strSQL = strSQL + "and INV_STOCKITEM.STOCKITEM_STATUS =0 ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GODOWNS", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BRANCH_LEDGER_OPENING", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM_CLOSING", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_PRICE_LEVEL", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_SALES_PRICE", 1);
                        strSQL = "INSERT INTO INV_SALES_PRICE(SALES_PRICE_KEY,PRICE_UNIQUE_KEY,STOCKITEM_NAME,FROM_QTY,TO_QTY,SALES_PRICE_AMOUNT,SALES_PRICE_EFFECTIVE_DATE,PRICE_LEVEL_NAME,ACTUAL_DISCOUNT,  ";
                        strSQL = strSQL + "PERCENT_DISCOUNT,MINIMUM_PRICE,INSERT_DATE,MODULE_STATUS,UPDATE_DATE)  ";
                        strSQL = strSQL + "SELECT INV_SALES_PRICE.SALES_PRICE_KEY,INV_SALES_PRICE.PRICE_UNIQUE_KEY,INV_SALES_PRICE.STOCKITEM_NAME,INV_SALES_PRICE.FROM_QTY,INV_SALES_PRICE.TO_QTY,INV_SALES_PRICE.SALES_PRICE_AMOUNT, ";
                        strSQL = strSQL + "INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE,INV_SALES_PRICE.PRICE_LEVEL_NAME,INV_SALES_PRICE.ACTUAL_DISCOUNT, ";
                        strSQL = strSQL + "INV_SALES_PRICE.PERCENT_DISCOUNT,INV_SALES_PRICE.MINIMUM_PRICE,INV_SALES_PRICE.INSERT_DATE,INV_SALES_PRICE.MODULE_STATUS,";
                        strSQL = strSQL + " INV_SALES_PRICE.UPDATE_DATE FROM " + strSourceDB + ".dbo.INV_SALES_PRICE," + strSourceDB + ".dbo.INV_STOCKITEM  ";
                        strSQL = strSQL + "WHERE INV_STOCKITEM.STOCKITEM_NAME=INV_SALES_PRICE.STOCKITEM_NAME and INV_STOCKITEM.STOCKITEM_STATUS =0  ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        proBar.Value = proBar.Value + 10;
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_TRANSPORT_NAME", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();


                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_EXPENSE_CONFIG_MASTER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_EXPENSE_CONFIG_TRAN", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_FIXED_ASSET_ADJUSTMENT_DEP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_FIXED_ASSET_PURCHASE_AMOUNT", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_MENU_PROCESS_MAIN", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        proBar.Value = proBar.Value + 10;

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LOAN_TEMPLATE_MASTER", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LOAN_TEMPLATE_CHILD", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_MANU_PROCESS", 1);
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_PAYMENT_SCHEDULE", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_COMPANY_VOUCHER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_VOUCHER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_MASTER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_TRAN", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BILL_TRAN", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BILL_TRAN_PROCESS", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();


                        strSQL = "INSERT INTO INV_MANU_PROCESS(PROCESS_NAME,STOCKITEM_NAME,PROCESS_POSITION,PROCESS_QUANTITY,PROCESS_UNIT,INV_PER,FG_COST_PERCENT,INSERT_DATE,UPDATE_DATE,PROCESS_TYPE) ";
                        strSQL = strSQL + "SELECT INV_MANU_PROCESS.PROCESS_NAME,INV_MANU_PROCESS.STOCKITEM_NAME,INV_MANU_PROCESS.PROCESS_POSITION,INV_MANU_PROCESS.PROCESS_QUANTITY,INV_MANU_PROCESS.PROCESS_UNIT,";
                        strSQL = strSQL + "INV_MANU_PROCESS.INV_PER,INV_MANU_PROCESS.FG_COST_PERCENT,INV_MANU_PROCESS.INSERT_DATE,INV_MANU_PROCESS.UPDATE_DATE,INV_MANU_PROCESS.PROCESS_TYPE ";
                        strSQL = strSQL + "FROM " + strSourceDB + ".dbo.INV_MANU_PROCESS, " + strSourceDB + ".dbo.INV_STOCKITEM ";
                        strSQL = strSQL + "WHERE INV_STOCKITEM.STOCKITEM_NAME=INV_MANU_PROCESS.STOCKITEM_NAME and INV_STOCKITEM.STOCKITEM_STATUS =0 ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "USER_FORM_CONFIG", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO USER_CONFIG(USER_LOGIN_NAME,USER_CREATE_DATE,USER_FULL_NAME,USER_PASS,USER_LEBEL,USER_STATUS,DEPARTMENT,DESIGNATION,IMAGE)";
                        strSQL = strSQL + "select USER_LOGIN_NAME,USER_CREATE_DATE,USER_FULL_NAME,USER_PASS,USER_LEBEL,USER_STATUS,DEPARTMENT,DESIGNATION,IMAGE from " + strSourceDB + ".dbo.USER_CONFIG ";
                        strSQL = strSQL + "where USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') and USER_STATUS <> 'S' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO USER_PRIVILEGES_BRANCH(USER_LOGIN_KEY,USER_LOGIN_NAME,BRANCH_ID ) ";
                        strSQL = strSQL + "SELECT USER_PRIVILEGES_BRANCH.USER_LOGIN_KEY,USER_PRIVILEGES_BRANCH.USER_LOGIN_NAME,USER_PRIVILEGES_BRANCH.BRANCH_ID  ";
                        strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_BRANCH," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_BRANCH.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
                        strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO USER_PRIVILEGES_COLOR(USER_LOGIN_NAME,LEDGER_GROUP_NAME ) ";
                        strSQL = strSQL + "SELECT USER_PRIVILEGES_COLOR.USER_LOGIN_NAME,USER_PRIVILEGES_COLOR.LEDGER_GROUP_NAME  ";
                        strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_COLOR," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_COLOR.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
                        strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO USER_PRIVILEGES_LOCATION(USER_LOGIN_NAME,GODOWNS_NAME ) ";
                        strSQL = strSQL + "SELECT USER_PRIVILEGES_LOCATION.USER_LOGIN_NAME,USER_PRIVILEGES_LOCATION.GODOWNS_NAME  ";
                        strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_LOCATION," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_LOCATION.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
                        strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO USER_PRIVILEGES_STOCKGROUP(USER_LOGIN_NAME,STOCKGROUP_NAME ) ";
                        strSQL = strSQL + "SELECT USER_PRIVILEGES_STOCKGROUP.USER_LOGIN_NAME,USER_PRIVILEGES_STOCKGROUP.STOCKGROUP_NAME   ";
                        strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_STOCKGROUP," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_STOCKGROUP.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
                        strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE   ) ";
                        strSQL = strSQL + "SELECT USER_PRIVILEGES_MAIN.USER_LOGIN_KEY,USER_PRIVILEGES_MAIN.USER_LOGIN_NAME,USER_PRIVILEGES_MAIN.PRI_MODULE,USER_PRIVILEGES_MAIN.PRI_TYPE      ";
                        strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_MAIN," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_MAIN.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
                        strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";

                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO USER_PRIVILEGES_CHILD(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_COMPONENT ,PRI_ADD, ";
                        strSQL = strSQL + "PRI_EDIT ,PRI_DELETE , PRI_APPR,MODULE_TYPE) ";
                        strSQL = strSQL + "SELECT USER_PRIVILEGES_CHILD.USER_LOGIN_KEY,USER_PRIVILEGES_CHILD.USER_LOGIN_NAME,USER_PRIVILEGES_CHILD.PRI_COMPONENT ,USER_PRIVILEGES_CHILD.PRI_ADD, ";
                        strSQL = strSQL + "USER_PRIVILEGES_CHILD.PRI_EDIT ,   USER_PRIVILEGES_CHILD.PRI_DELETE , USER_PRIVILEGES_CHILD.PRI_APPR,USER_PRIVILEGES_CHILD.MODULE_TYPE   ";
                        strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_CHILD," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_CHILD.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND  ";
                        strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        //*********************

                        //strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_BALANCE=0 ";
                        //strSQL = strSQL + ",STOCKITEM_OPENING_VALUE=0  ";
                        //strSQL = strSQL + ",STOCKITEM_OPENING_RATE=0  ";
                        //strSQL = strSQL + ",STOCKITEM_CLOSING_BALANCE=0  ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //strSQL = "UPDATE INV_STOCKITEM_CLOSING SET STOCKITEM_CLOSING_BALANCE=0 ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();




                        proBar.Value = proBar.Value + 20;
                        cmdInsert.Transaction.Commit();
                        //string j = mInsertAccountsClosing(strCompanyID, strSourceDB);
                        //if (j == "1")
                        //{
                        //    j = mInsertStockItemClosing(strCompanyID, strSourceDB);
                        //    if (j == "1")
                        //    {

                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show(j);
                        //    }
                        //}
                        //else
                        //{
                        //    MessageBox.Show(j);
                        //}
                        //basTrigger.gCreateTrigger();

                        //strSQL = "UPDATE ACC_LEDGERGROUP SET GR_OPENING_DEBIT = (SELECT isnull(sum(l.LEDGER_OPENING_BALANCE),0)  PDUES  ";
                        //strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l ";
                        //strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                        //strSQL = strSQL + "and L.LEDGER_ONE_DOWN  ='Sundry Debtors') WHERE GR_NAME ='Sundry Debtors' ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //MessageBox.Show("Thankyou,Successfully Split Your Company");
                        gcnMainnew.Close();
                        gcnMain.Close();
                        cmdInsert.Dispose();
                        cmd.Dispose();
                        Dr.Close();


                    }
                }

            }



        }
        #endregion
        private void frmSplitCompany_Load(object sender, EventArgs e)
        {
            pbImage.Image = imagelst.Images[0];
            txtCompanyName.Text = Utility.gstrCompanyName + "-" + dtefinancialform.Value.ToString("dd-MM-yyyy");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #region "Method"

        private string mInsertTableDataBranch(string strComID, string vstrSourceDB, string vTable, int intStartIndex)
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

        private string mFieldNameBranch(string strComID, string vTable, string vTable1, int intStartIndex)
        {
            string strSQL, strField = "";
            string conDb;
            SqlDataReader reader;
            conDb = Utility.SQLConnstringComSwitch(strComID);

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
                    if (reader.GetName(intgpos) != "ONLINE" && reader.GetName(intgpos) != "APP_STATUS" && reader.GetName(intgpos) != "SP_ITEM" && reader.GetName(intgpos) != "UPDATE_DATE" && reader.GetName(intgpos) != "VOUCHER_TYPE_LOCK_VOUCHER_NO" && reader.GetName(intgpos) != "EXPORT_TYPE" && reader.GetName(intgpos) != "EXPORT_FILE_NAME" && reader.GetName(intgpos) != "IMPORT_FILE_NAME")
                    {
                        strField = strField + reader.GetName(intgpos).ToString() + ",";
                    }
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

        private string mInsertTableData(string strComID, string vstrSourceDB, string vTable, int intStartIndex)
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

        private string mFieldName(string strComID, string vTable, string vTable1, int intStartIndex)
        {
            string strSQL, strField = "";
            string conDb;
            SqlDataReader reader;
            conDb = Utility.SQLConnstringComSwitch(strComID);

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
                    if (reader.GetName(intgpos) != "SECTION_STATUS" && reader.GetName(intgpos) != "IMPORT_FILE_NAME" && reader.GetName(intgpos) != "EXPORT_FILE_NAME" && reader.GetName(intgpos) != "EXPORT_TYPE" && reader.GetName(intgpos) != "INV_DRIVER_NAME" && reader.GetName(intgpos) != "INV_WORKER_NAME" && reader.GetName(intgpos) != "USER_PASS_TYPE" && reader.GetName(intgpos) != "STOCKITEM_NAME_BANGLA" && reader.GetName(intgpos) != "COST_TYPE" && reader.GetName(intgpos) != "LEDGER_NAME_MERZE" && reader.GetName(intgpos) != "UPDATE_DATE" && reader.GetName(intgpos) != "VOUCHER_TYPE_LOCK_VOUCHER_NO" && reader.GetName(intgpos) != "EXPORT_TYPE" && reader.GetName(intgpos) != "EXPORT_FILE_NAME" && reader.GetName(intgpos) != "IMPORT_FILE_NAME")
                    {
                        strField = strField + reader.GetName(intgpos).ToString() + ",";
                    }
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
        #endregion
        #region "Model"

        private class accLedger
        {
            public string strItemName { get; set; }
            public string strRefNo1 { get; set; }
            public string strLedgerName { get; set; }
            public string strBranchId { get; set; }
            public double dblTotalAmnt { get; set; }
            public double dblAmnt { get; set; }

        }
        private class stockItem
        {

            public string strItemName { get; set; }
            public string strBranchId { get; set; }
            public string strGodownsName { get; set; }
            public long lngSlNo { get; set; }
            public double dblclsQty { get; set; }
            public double dblRate { get; set; }
            public double dblclsAmnt { get; set; }

        }
        #endregion
        private void button1_Click_2(object sender, EventArgs e)
        {
            //mInsertAccountsClosing("SMART0002");
            //mInsertStockItemClosing("SMART0002");
        }
        private string mInsertStockItemClosing(string strComID, string strSourceDB)
        {
            string strSQL;
            string conDb;

            int intItemSl = 1, intGodownsl = 1;
            int intRow = 1;
            string strGodownSerial = "", strRefNo = "", strItemSerial = "", strLoc = "";
            string dteDate = "01/01/1900";


            conDb = Utility.SQLConnstringComSwitch(strComID);
            try
            {

                using (SqlConnection gcnMain = new SqlConnection(conDb))
                {
                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }


                    gcnMain.Open();
                    List<stockItem> objItem = new List<stockItem>();
                    List<stockItem> objMaster = new List<stockItem>();

                    SqlCommand cmdInsert = new SqlCommand();
                    SqlDataReader Dr;
                    cmdInsert.Connection = gcnMain;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_BALANCE=0 ";
                    strSQL = strSQL + ",STOCKITEM_OPENING_VALUE=0  ";
                    strSQL = strSQL + ",STOCKITEM_OPENING_RATE=0  ";
                    strSQL = strSQL + ",STOCKITEM_CLOSING_BALANCE=0  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE INV_STOCKITEM_CLOSING SET STOCKITEM_CLOSING_BALANCE=0 ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "SELECT  INV_STOCKITEM.STOCKITEM_NAME,INV_TRAN.BRANCH_ID,INV_TRAN.GODOWNS_NAME,isnull(sum(INV_TRAN.INV_TRAN_QUANTITY),0) INV_TRAN_QUANTITY,(CASE WHEN sum(INV_TRAN.INV_TRAN_QUANTITY)<>0 THEN round(isnull(sum(INV_TRAN.INV_TRAN_AMOUNT),0)/sum(INV_TRAN.INV_TRAN_QUANTITY),2) ELSE 0 END )rate,";
                    strSQL = strSQL + "(CASE WHEN sum(INV_TRAN.INV_TRAN_QUANTITY)<>0 THEN isnull(sum(INV_TRAN.INV_TRAN_AMOUNT),0) ELSE 0 END )INV_TRAN_AMOUNT ";
                    strSQL = strSQL + "FROM " + strSourceDB + ".DBO.INV_TRAN," + strSourceDB + ".DBO.INV_STOCKITEM  ";
                    strSQL = strSQL + "WHERE INV_STOCKITEM.STOCKITEM_NAME =INV_TRAN.STOCKITEM_NAME ";
                    strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_STATUS=0 ";
                    //strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_NAME='Antico - 100ml'";
                    strSQL = strSQL + "GROUP BY INV_STOCKITEM.STOCKITEM_NAME,INV_TRAN.GODOWNS_NAME,INV_TRAN.BRANCH_ID ";
                    //--HAVING sum(INV_TRAN_QUANTITY)<>0 ";
                    strSQL = strSQL + "ORDER BY INV_TRAN.GODOWNS_NAME ";

                    cmdInsert.CommandText = strSQL;
                    Dr = cmdInsert.ExecuteReader();
                    while (Dr.Read())
                    {
                        stockItem obran = new stockItem();
                        obran.strItemName = Dr["STOCKITEM_NAME"].ToString();
                        obran.strBranchId = Dr["BRANCH_ID"].ToString();
                        obran.strGodownsName = Dr["GODOWNS_NAME"].ToString();
                        obran.dblclsQty = Convert.ToDouble(Dr["INV_TRAN_QUANTITY"].ToString());
                        obran.dblRate = Convert.ToDouble(Dr["rate"].ToString());
                        obran.dblclsAmnt = Convert.ToDouble(Dr["INV_TRAN_AMOUNT"].ToString());
                        objItem.Add(obran);
                    }
                    Dr.Close();

                    if (objItem.Count > 0)
                    {


                        progressBar1.Value = 0;
                        progressBar1.Maximum = objItem.Count();
                        //label4.Text = intRow.ToString();
                        foreach (stockItem Item in objItem)
                        {
                            strItemSerial = intItemSl.ToString();
                            strGodownSerial = intGodownsl.ToString();
                            strLoc = Item.strGodownsName;
                            strRefNo = Utility.vtSTOCK_OPENING_STR + Item.strBranchId + strItemSerial + "-OPN" + "1" + strGodownSerial;


                            strSQL = "INSERT INTO INV_MASTER (BRANCH_ID,INV_REF_NO,INV_VOUCHER_TYPE,INV_DATE ) VALUES ";
                            strSQL = strSQL + "('" + Item.strBranchId + "','" + strRefNo + "',0," + Utility.cvtSQLDateString(dteDate) + " ) ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            strSQL = "INSERT INTO INV_TRAN (INV_TRAN_KEY, BRANCH_ID,INV_REF_NO,STOCKITEM_NAME,GODOWNS_NAME, INV_VOUCHER_TYPE,INV_DATE,INV_TRAN_POSITION,INV_OPENING_FLAG,INV_TRAN_QUANTITY,INV_TRAN_RATE,INV_TRAN_AMOUNT,INV_TRAN_RUNNING_QTY) VALUES ";
                            strSQL = strSQL + "('" + strRefNo + "','" + Item.strBranchId + "','" + strRefNo + "','" + Item.strItemName.Replace("'", "''") + "', '" + strLoc + "',0," + Utility.cvtSQLDateString(dteDate) + ",1,1," + Item.dblclsQty + "," + Item.dblRate + "," + Item.dblclsAmnt + "," + Item.dblclsQty + ") ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            strSQL = "INSERT INTO INV_STOCKITEM_CLOSING(STOCKITEM_NAME,GODOWNS_NAME,STOCKITEM_CLOSING_BALANCE) VALUES(";
                            strSQL = strSQL + "'" + Item.strItemName.Replace("'", "''") + "','" + strLoc.Replace("'", "''") + "'," + Item.dblclsQty + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            progressBar1.Value += 1;
                            intRow += 1;
                            intItemSl += 1;
                            intGodownsl += 1;
                            //label4.Text = intRow.ToString();
                        }
                    }
                    Dr.Close();

                    strSQL = "SELECT  INV_STOCKITEM.STOCKITEM_NAME,isnull(sum(INV_TRAN.INV_TRAN_QUANTITY),0) INV_TRAN_QUANTITY,(CASE WHEN sum(INV_TRAN.INV_TRAN_QUANTITY)<>0 THEN round(isnull(sum(INV_TRAN.INV_TRAN_AMOUNT),0)/sum(INV_TRAN.INV_TRAN_QUANTITY),2) ELSE 0 END )rate,";
                    strSQL = strSQL + "(CASE WHEN sum(INV_TRAN.INV_TRAN_QUANTITY)<>0 THEN isnull(sum(INV_TRAN.INV_TRAN_AMOUNT),0) ELSE 0 END )INV_TRAN_AMOUNT ";
                    strSQL = strSQL + "FROM " + strSourceDB + ".DBO.INV_TRAN," + strSourceDB + ".DBO.INV_STOCKITEM  ";
                    strSQL = strSQL + "WHERE INV_STOCKITEM.STOCKITEM_NAME =INV_TRAN.STOCKITEM_NAME ";
                    strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_STATUS=0 ";
                    //strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_NAME='Antico - 100ml'";
                    strSQL = strSQL + "GROUP BY INV_STOCKITEM.STOCKITEM_NAME ";
                    //--HAVING sum(INV_TRAN_QUANTITY)<>0 ";

                    cmdInsert.CommandText = strSQL;
                    Dr = cmdInsert.ExecuteReader();
                    while (Dr.Read())
                    {
                        stockItem obran = new stockItem();
                        obran.strItemName = Dr["STOCKITEM_NAME"].ToString();
                        obran.dblclsQty = Convert.ToDouble(Dr["INV_TRAN_QUANTITY"].ToString());
                        obran.dblRate = Convert.ToDouble(Dr["rate"].ToString());
                        obran.dblclsAmnt = Convert.ToDouble(Dr["INV_TRAN_AMOUNT"].ToString());
                        objMaster.Add(obran);
                    }
                    Dr.Close();
                    if (objMaster.Count > 0)
                    {
                        progressBar1.Value = 0;
                        progressBar1.Maximum = objMaster.Count();

                        foreach (stockItem Item in objMaster)
                        {
                            strSQL = "UPDATE INV_STOCKITEM ";
                            strSQL = strSQL + "SET STOCKITEM_OPENING_BALANCE=" + Item.dblclsQty + " ";
                            strSQL = strSQL + ",STOCKITEM_OPENING_RATE=" + Item.dblRate + " ";
                            strSQL = strSQL + ",STOCKITEM_OPENING_VALUE=" + Item.dblclsAmnt + " ";
                            strSQL = strSQL + " WHERE STOCKITEM_NAME ='" + Item.strItemName.Replace("'", "''") + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                    }

                    cmdInsert.Transaction.Commit();




                    //MessageBox.Show("");

                    gcnMain.Dispose();
                    gcnMain.Close();
                    Dr.Close();
                    cmdInsert.Dispose();

                }

                return "1";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return ex.ToString();
            }

        }


        private string mInsertAccountsClosing(string strComID, string strSourceDB)
        {
            string strSQL, strFdate = "", strTDate = "", vstrBranchID = "";
            string conDb;
            string strOldLedger = "";
            string strBranchKey = "";
            double dblclsAmnt = 0, dblGP = 0;
            conDb = Utility.SQLConnstringComSwitch(strComID);
            try
            {

                using (SqlConnection gcnMain = new SqlConnection(conDb))
                {
                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }


                    gcnMain.Open();
                    SqlDataReader Dr;

                    List<accLedger> objLedger = new List<accLedger>();
                    List<accLedger> objBranch = new List<accLedger>();
                    List<accLedger> objLederMaster = new List<accLedger>();
                    SqlCommand cmdInsert = new SqlCommand();

                    cmdInsert.Connection = gcnMain;
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;



                    strSQL = "INSERT INTO ACC_COMP_VOUCHER_TEMP (LEDGER_NAME,MONTH_ID,COMP_VOUCHER_DATE,COMP_VOUCHER_TYPE,NET_AMOUNT)";
                    strSQL = strSQL + "SELECT ACC_VOUCHER.LEDGER_NAME,ACC_COMPANY_VOUCHER.COMP_VOUCHER_MONTH_ID,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE,ISNULL(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT -ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT) ,0) ";
                    strSQL = strSQL + "from " + strSourceDB + ".dbo.ACC_COMPANY_VOUCHER," + strSourceDB + ".dbo.ACC_VOUCHER  where ACC_COMPANY_VOUCHER.SP_JOURNAL =1  ";
                    strSQL = strSQL + "and ACC_COMPANY_VOUCHER.COMP_VOUCHER_MONTH_ID ='DEC19' ";
                    strSQL = strSQL + "GROUP BY ACC_VOUCHER.LEDGER_NAME,ACC_COMPANY_VOUCHER.COMP_VOUCHER_MONTH_ID,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE,ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE ACC_LEDGERGROUP SET GR_OPENING_DEBIT=0 ";
                    strSQL = strSQL + ",GR_OPENING_CREDIT=0  ";
                    strSQL = strSQL + ",GR_DEBIT_TOTAL=0  ";
                    strSQL = strSQL + ",GR_CREDIT_TOTAL=0  ";
                    strSQL = strSQL + ",GR_CLOSING_DEBIT=0  ";
                    strSQL = strSQL + ",GR_CLOSING_CREDIT=0  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE ACC_LEDGER SET LEDGER_OPENING_BALANCE=0 ";
                    strSQL = strSQL + ",LEDGER_FC_OPENING_BALANCE=0  ";
                    strSQL = strSQL + ",LEDGER_CLOSING_BALANCE=0  ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "SELECT BRANCH_ID FROM " + strSourceDB + ".dbo.ACC_BRANCH  ORDER BY BRANCH_ID ";
                    cmdInsert.CommandText = strSQL;
                    Dr = cmdInsert.ExecuteReader();
                    while (Dr.Read())
                    {
                        accLedger obran = new accLedger();
                        obran.strBranchId = Dr["BRANCH_ID"].ToString();
                        objBranch.Add(obran);
                    }
                    Dr.Close();
                    strSQL = "SELECT LEDGER_NAME,BRANCH_ID FROM " + strSourceDB + ".dbo.ACC_LEDGER  ";
                    //strSQL = strSQL + "WHERE LEDGER_NAME in ('Accumulated Depreciation') ";
                    //strSQL = strSQL + " WHERE LEDGER_GROUP NOT IN (203) ";
                    strSQL = strSQL + "ORDER BY LEDGER_NAME ";
                    cmdInsert.CommandText = strSQL;
                    Dr = cmdInsert.ExecuteReader();
                    while (Dr.Read())
                    {
                        accLedger ledger = new accLedger();
                        ledger.strLedgerName = Dr["LEDGER_NAME"].ToString();
                        ledger.strBranchId = Dr["BRANCH_ID"].ToString();
                        objLedger.Add(ledger);
                    }
                    Dr.Close();
                    strSQL = "SELECT COMPANY_ID,COMPANY_FINICIAL_YEAR_FROM   ,COMPANY_FINICIAL_YEAR_TO  FROM " + strSourceDB + ".dbo.ACC_COMPANY ";
                    cmdInsert.CommandText = strSQL;
                    Dr = cmdInsert.ExecuteReader();
                    if (Dr.Read())
                    {
                        strFdate = Convert.ToDateTime(Dr["COMPANY_FINICIAL_YEAR_FROM"]).ToString("dd-MM-yyyy");
                        strTDate = Convert.ToDateTime(Dr["COMPANY_FINICIAL_YEAR_TO"]).ToString("dd-MM-yyyy");
                        //vstrBranchID = Dr["COMPANY_ID"].ToString();
                    }
                    Dr.Close();
                    //int icount = 1;
                    //if (objBranch.Count > 0)
                    //{
                    //    foreach (accLedger bran in objBranch)
                    //    {
                    if (objLedger.Count > 0)
                    {
                        //label4.Text = icount.ToString();
                        progressBar1.Value = 0;
                        progressBar1.Maximum = objLedger.Count();
                        foreach (accLedger oled in objLedger)
                        {

                            dblclsAmnt = Utility.dblLedgerClosingBalanceSplit(strComID, strFdate, strTDate, oled.strLedgerName.Replace("'", "''"), "", strSourceDB);
                            if (dblclsAmnt != 0)
                            {
                                if (oled.strBranchId != "")
                                {
                                    strBranchKey = oled.strLedgerName + oled.strBranchId;
                                    strSQL = "INSERT INTO ACC_BRANCH_LEDGER_OPENING(BRANCH_LEDGER_KEY,BRANCH_ID,LEDGER_NAME,BRANCH_LEDGER_OPENING_BALANCE)";
                                    strSQL = strSQL + "VALUES(";
                                    strSQL = strSQL + "'" + strBranchKey.Replace("'", "''") + "' ";
                                    strSQL = strSQL + ",'" + oled.strBranchId + "' ";
                                    strSQL = strSQL + ",'" + oled.strLedgerName.Replace("'", "''") + "' ";
                                    strSQL = strSQL + "," + dblclsAmnt + " ";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    strSQL = "INSERT INTO ACC_BRANCH_LEDGER_OPENING(BRANCH_LEDGER_KEY,BRANCH_ID,LEDGER_NAME,BRANCH_LEDGER_OPENING_BALANCE)";
                                    strSQL = strSQL + "SELECT '" + oled.strLedgerName.Replace("'", "''") + "'BRANCH_ID,BRANCH_ID,'" + oled.strLedgerName.Replace("'", "''") + "',0 FROM ACC_BRANCH   WHERE BRANCH_ID NOT IN ('" + oled.strBranchId + "')";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                else
                                {
                                    strBranchKey = oled.strLedgerName + "0001";
                                    strSQL = "INSERT INTO ACC_BRANCH_LEDGER_OPENING(BRANCH_LEDGER_KEY,BRANCH_ID,LEDGER_NAME,BRANCH_LEDGER_OPENING_BALANCE)";
                                    strSQL = strSQL + "VALUES(";
                                    strSQL = strSQL + "'" + strBranchKey.Replace("'", "''") + "' ";
                                    strSQL = strSQL + ",'0001' ";
                                    strSQL = strSQL + ",'" + oled.strLedgerName.Replace("'", "''") + "' ";
                                    strSQL = strSQL + "," + dblclsAmnt + " ";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    strSQL = "INSERT INTO ACC_BRANCH_LEDGER_OPENING(BRANCH_LEDGER_KEY,BRANCH_ID,LEDGER_NAME,BRANCH_LEDGER_OPENING_BALANCE)";
                                    strSQL = strSQL + "SELECT '" + oled.strLedgerName.Replace("'", "''") + "'BRANCH_ID,BRANCH_ID,'" + oled.strLedgerName.Replace("'", "''") + "',0 FROM ACC_BRANCH   WHERE BRANCH_ID NOT IN ('0001')";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                strSQL = "UPDATE ACC_LEDGER SET LEDGER_OPENING_BALANCE=" + dblclsAmnt + " ";
                                strSQL = strSQL + " WHERE LEDGER_NAME ='" + oled.strLedgerName.Replace("'", "''") + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                //strSQL = "UPDATE ACC_LEDGER SET LEDGER_OPENING_BALANCE=" + dblclsAmnt + " ";
                                //strSQL = strSQL + " WHERE LEDGER_NAME ='" + oled.strLedgerName.Replace("'", "''") + "' ";
                                //strSQL = strSQL + " AND BRANCH_ID ='" + oled.strBranchId + "' ";
                                //cmdInsert.CommandText = strSQL;
                                //cmdInsert.ExecuteNonQuery();
                                dblclsAmnt = 0;
                                dblclsAmnt = 0;
                                //dblopn = 0;
                            }


                            progressBar1.Value += 1;
                        }
                    }
                    //    }
                    //    icount += 1;
                    //}

                    Dr.Close();
                    Dr.Close();



                    strSQL = "UPDATE ACC_LEDGER SET LEDGER_OPENING_BALANCE=0,LEDGER_CLOSING_BALANCE=0 WHERE LEDGER_PRIMARY_TYPE IN(3,4)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();





                    strSQL = "UPDATE ACC_BRANCH_LEDGER_OPENING SET BRANCH_LEDGER_OPENING_BALANCE = (SELECT ISNULL(SUM(GR_AMOUNT),0) from  " + strSourceDB + ".dbo.ACC_BALANCE_SHEET WHERE GR_PARENT='Profit & Loss Accounts') ";
                    strSQL = strSQL + "WHERE LEDGER_NAME = 'Profit & Loss A/c' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();


                    gcnMain.Dispose();
                    gcnMain.Close();
                    Dr.Close();
                    cmdInsert.Dispose();

                }

                return "1";


            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ServerName, strCompanyID = "0001", strBarchID, strCompanyName;

            string strSQL;
            if (txtCompanyName.Text == "")
            {
                MessageBox.Show("Company Name Cannot be empty");
                txtCompanyName.Focus();
                return;
            }
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");

            SqlDataReader Dr;
            string conDb;
            changeRegionalSetting();

            strCompanyID = Utility.gstrGetLastSerl();
            strBarchID = "0001";
            txtCompanyName.Text = "Company Name - " + strCompanyID;
            Utility.strDataBase = "SMART" + strCompanyID;
            regKey.SetValue("gstrDataBaseName", Utility.strDataBase);
            regKey.SetValue("CompanyID", strCompanyID);

            ServerName = Utility.gGetServerName();
            conDb = "Data Source=" + ServerName + " ;Initial Catalog= master;User ID=" + Utility.gstDatabaserUserName + " ;Password=" + Utility.gstDatabasePassword + " ";
            strSQL = "SELECT NAME FROM master.dbo.sysdatabases WHERE NAME = '" + Utility.strDataBase + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strCompanyName = txtCompanyName.Text.Replace("'", "''");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                Dr = cmd.ExecuteReader();
                if ((Dr.Read()) != true)
                {
                    Utility.gstrCompanyID = strCompanyID.Trim();
                    Utility.gstrBranchID = strBarchID.Trim();
                    Utility.gstrCompanyName = strCompanyName;
                    Utility.gdteFinancialYearFrom = Utility.DateFormat(dtefinancialform.Value);
                    Utility.gdteFinancialYearTo = Utility.DateFormat(dteFinanicalTo.Value);
                    Utility.gstrFinicialYearFrom = Utility.gstrDateToStr(dtefinancialform.Text);
                    Utility.gstrFinicialYearTo = Utility.gstrDateToStr(dteFinanicalTo.Text);
                    Utility.gstrBusinessType = "Manufacturing Company";
                    mstrCurSymbol = "BDT";
                    mstrCurFormallName = "BDT";

                    mstrCurString = "";
                    mlngCurDecimalPl = 0;
                    gCreatedatabase(ServerName, strCompanyID);

                    basTableSchemaAccount.gCreateAccounts("Manufacturing Company");
                    proBar.Value = proBar.Value + 10;
                    basTableSchemaStock.gCreateStock();
                    proBar.Value = proBar.Value + 20;
                    basTableSchemaReport.gCreateTableReport();
                    proBar.Value = proBar.Value + 20;
                    basViewSchemaAccount.gCreateViewAccount();
                    basViewSchemaStock.gCreateViewStock();
                    basProcedure.gCreateAdavanceSP();
                    CreateDefaultdata.gInsertBaseCurrency(mstrCurSymbol, mstrCurFormallName, mstrCurString, mlngCurDecimalPl);
                    mSaveCompanyInfo(strCompanyID, strBarchID);

                    MemoryStream ms = new MemoryStream();
                    pbImage.Image.Save(ms, ImageFormat.Jpeg);
                    _imageData = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(_imageData, 0, _imageData.Length);
                    CreateDefaultdata.gInsertAccessControl("Deeplaid", "DeepLaid", _imageData, strBarchID);

                    string strSourceDB = "";

                    //strSourceDB = "SMART" + Utility.gstrCompanyID;
                    strSourceDB = "SMART0002";
                    Dr.Close();
                    gcnMain.Close();
                    string cnn = "";
                    SqlTransaction myTrans;
                    SqlCommand cmdInsert = new SqlCommand();
                    cnn = Utility.SQLConnstringComSwitch(strCompanyID);
                    using (SqlConnection gcnMainnew = new SqlConnection(cnn))
                    {
                        if (gcnMainnew.State == ConnectionState.Open)
                        {
                            gcnMainnew.Close();
                        }
                        gcnMainnew.Open();
                        myTrans = gcnMainnew.BeginTransaction();
                        cmdInsert.Connection = gcnMainnew;
                        cmdInsert.Transaction = myTrans;
                        //Accounts


                        strSQL = "INSERT INTO ACC_BRANCH(BRANCH_CREATE_DATE,BRANCH_ID,BRANCH_NAME,BRANCH_INT_NAME,BRANCH_NAME_DEFAULT,BRANCH_ADD1,BRANCH_ADD2,BRANCH_ADD3,BRANCH_ADD4,BRANCH_COUNTRY,";
                        strSQL = strSQL + "BRANCH_PHONE,BRANCH_FAX,BRANCH_STATUS,BRANCH_ACTIVE,BRANCH_TYPE,BRANCH_FLAG,BRANCH_COMMENTS,LOGO_REF,ENTRYBY,UPDATEBY) ";
                        strSQL = strSQL + "SELECT BRANCH_CREATE_DATE,BRANCH_ID,BRANCH_NAME,BRANCH_INT_NAME,BRANCH_NAME_DEFAULT,BRANCH_ADD1,BRANCH_ADD2,BRANCH_ADD3,BRANCH_ADD4,";
                        strSQL = strSQL + "BRANCH_COUNTRY,BRANCH_PHONE,BRANCH_FAX,BRANCH_STATUS,BRANCH_ACTIVE,BRANCH_TYPE,BRANCH_FLAG,BRANCH_COMMENTS,LOGO_REF,";
                        strSQL = strSQL + "ENTRYBY,UPDATEBY FROM " + strSourceDB + ".dbo.ACC_BRANCH WHERE BRANCH_ID <>'0001' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_VOUCHER_TYPE", 1);




                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_DESTINATION", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_TERITORRY", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_MASTER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_COMMISSION_MASTER", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_COMMISSION_TRAN", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LEDGERGROUP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_GROUP_TO_LEDGER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();


                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LEDGER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LEDGER_TO_GROUP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();


                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "VECTOR_CATEGORY", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "VECTOR_MASTER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();



                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_UNIT_MEASUREMENT", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKGROUP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        proBar.Value = proBar.Value + 10;
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKCATEGORY", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCK_MATERIAL_TYPE", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_TO_STOCKITEM", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM", 1);
                        //strSQL = "INSERT INTO INV_STOCKITEM(STOCKITEM_NAME,ITEM_NAME_BANGLA,STOCKITEM_ALIAS,STOCKITEM_DESCRIPTION,STOCKGROUP_NAME,STOCKCATEGORY_NAME,STOCKITEM_PRIMARY_GROUP,STOCKITEM_OPENING_BALANCE,";
                        //strSQL = strSQL + "STOCKITEM_OPENING_VALUE,STOCKITEM_OPENING_RATE,STOCKITEM_CLOSING_BALANCE,STOCKITEM_INWARDQUANTITY,STOCKITEM_OUTWARDQUANTITY,STOCKITEM_BASEUNITS,STOCKITEM_ADDITIONALUNITS, ";
                        //strSQL = strSQL + "STOCKITEM_CONVERSION,STOCKITEM_DENOMINATOR,STOCKITEM_MIN_QUANTITY,STOCKITEM_REORDER_LEVEL,STOCKITEM_MAINTAIN_SERIAL,SP_ITEM,STOCKITEM_MANUFACTURER,ISBN_NO,STOCKITEM_STATUS, ";
                        //strSQL = strSQL + "STOCK_ITEM_SUPPLIER,SERIAL_STATUS,POWER_CLASS,MATERIAL_TYPE,INSERT_DATE,STOCKOTHERS_NAME,UPDATE_DATE) ";
                        //strSQL = strSQL + "SELECT STOCKITEM_NAME,ITEM_NAME_BANGLA,STOCKITEM_ALIAS,STOCKITEM_DESCRIPTION,STOCKGROUP_NAME,STOCKCATEGORY_NAME,STOCKITEM_PRIMARY_GROUP,STOCKITEM_OPENING_BALANCE, ";
                        //strSQL = strSQL + "STOCKITEM_OPENING_VALUE,STOCKITEM_OPENING_RATE,STOCKITEM_CLOSING_BALANCE,STOCKITEM_INWARDQUANTITY,STOCKITEM_OUTWARDQUANTITY,STOCKITEM_BASEUNITS, ";
                        //strSQL = strSQL + "STOCKITEM_ADDITIONALUNITS,STOCKITEM_CONVERSION,STOCKITEM_DENOMINATOR,STOCKITEM_MIN_QUANTITY,STOCKITEM_REORDER_LEVEL,STOCKITEM_MAINTAIN_SERIAL, ";
                        //strSQL = strSQL + "SP_ITEM,STOCKITEM_MANUFACTURER,ISBN_NO,STOCKITEM_STATUS,STOCK_ITEM_SUPPLIER,SERIAL_STATUS,POWER_CLASS,MATERIAL_TYPE,INSERT_DATE,STOCKOTHERS_NAME,UPDATE_DATE  ";
                        //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.INV_STOCKITEM WHERE STOCKITEM_STATUS =0 ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        ////strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM_TO_GROUP", 1);
                        //strSQL = "INSERT INTO INV_STOCKITEM_TO_GROUP(STOCKITEM_NAME,STOCKGROUP_NAME,INSERT_DATE,UPDATE_DATE) ";
                        //strSQL = strSQL + "SELECT INV_STOCKITEM.STOCKITEM_NAME,INV_STOCKITEM_TO_GROUP.STOCKGROUP_NAME,INV_STOCKITEM_TO_GROUP.INSERT_DATE,INV_STOCKITEM_TO_GROUP.UPDATE_DATE ";
                        //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.INV_STOCKITEM_TO_GROUP," + strSourceDB + ".dbo.INV_STOCKITEM ";
                        //strSQL = strSQL + "where INV_STOCKITEM.STOCKITEM_NAME =INV_STOCKITEM_TO_GROUP.STOCKITEM_NAME and INV_STOCKITEM.STOCKITEM_STATUS =0 ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        ////strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM_LEVEL", 1);
                        //strSQL = "INSERT INTO INV_STOCKITEM_LEVEL(STOCKITEM_NAME,STOCKGROUP_LEVEL_1,STOCKGROUP_LEVEL_2,STOCKGROUP_LEVEL_3,STOCKGROUP_LEVEL_4,STOCKGROUP_LEVEL_5,INSERT_DATE,UPDATE_DATE) ";
                        //strSQL = strSQL + "SELECT INV_STOCKITEM.STOCKITEM_NAME,INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_1,INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_2,INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_3,INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_4,";
                        //strSQL = strSQL + "INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_5,INV_STOCKITEM_LEVEL.INSERT_DATE,INV_STOCKITEM_LEVEL.UPDATE_DATE ";
                        //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.INV_STOCKITEM_LEVEL," + strSourceDB + ".dbo.INV_STOCKITEM WHERE INV_STOCKITEM.STOCKITEM_NAME=INV_STOCKITEM_LEVEL.STOCKITEM_NAME ";
                        //strSQL = strSQL + "and INV_STOCKITEM.STOCKITEM_STATUS =0 ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GODOWNS", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BRANCH_LEDGER_OPENING", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM_CLOSING", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_PRICE_LEVEL", 0);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        ////strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_SALES_PRICE", 1);
                        //strSQL = "INSERT INTO INV_SALES_PRICE(SALES_PRICE_KEY,PRICE_UNIQUE_KEY,STOCKITEM_NAME,FROM_QTY,TO_QTY,SALES_PRICE_AMOUNT,SALES_PRICE_EFFECTIVE_DATE,PRICE_LEVEL_NAME,ACTUAL_DISCOUNT,  ";
                        //strSQL = strSQL + "PERCENT_DISCOUNT,MINIMUM_PRICE,INSERT_DATE,MODULE_STATUS,UPDATE_DATE)  ";
                        //strSQL = strSQL + "SELECT INV_SALES_PRICE.SALES_PRICE_KEY,INV_SALES_PRICE.PRICE_UNIQUE_KEY,INV_SALES_PRICE.STOCKITEM_NAME,INV_SALES_PRICE.FROM_QTY,INV_SALES_PRICE.TO_QTY,INV_SALES_PRICE.SALES_PRICE_AMOUNT, ";
                        //strSQL = strSQL + "INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE,INV_SALES_PRICE.PRICE_LEVEL_NAME,INV_SALES_PRICE.ACTUAL_DISCOUNT, ";
                        //strSQL = strSQL + "INV_SALES_PRICE.PERCENT_DISCOUNT,INV_SALES_PRICE.MINIMUM_PRICE,INV_SALES_PRICE.INSERT_DATE,INV_SALES_PRICE.MODULE_STATUS,";
                        //strSQL = strSQL + " INV_SALES_PRICE.UPDATE_DATE FROM " + strSourceDB + ".dbo.INV_SALES_PRICE," + strSourceDB + ".dbo.INV_STOCKITEM  ";
                        //strSQL = strSQL + "WHERE INV_STOCKITEM.STOCKITEM_NAME=INV_SALES_PRICE.STOCKITEM_NAME and INV_STOCKITEM.STOCKITEM_STATUS =0  ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //proBar.Value = proBar.Value + 10;
                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_TRANSPORT_NAME", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();


                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_EXPENSE_CONFIG_MASTER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_EXPENSE_CONFIG_TRAN", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_FIXED_ASSET_ADJUSTMENT_DEP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_FIXED_ASSET_PURCHASE_AMOUNT", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_MENU_PROCESS_MAIN", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        proBar.Value = proBar.Value + 10;

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LOAN_TEMPLATE_MASTER", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LOAN_TEMPLATE_CHILD", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_MANU_PROCESS", 1);
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_PAYMENT_SCHEDULE", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_COMPANY_VOUCHER", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_VOUCHER", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_MASTER", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_TRAN", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BILL_TRAN", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BILL_TRAN_PROCESS", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();


                        //strSQL = "INSERT INTO INV_MANU_PROCESS(PROCESS_NAME,STOCKITEM_NAME,PROCESS_POSITION,PROCESS_QUANTITY,PROCESS_UNIT,INV_PER,FG_COST_PERCENT,INSERT_DATE,UPDATE_DATE,PROCESS_TYPE) ";
                        //strSQL = strSQL + "SELECT INV_MANU_PROCESS.PROCESS_NAME,INV_MANU_PROCESS.STOCKITEM_NAME,INV_MANU_PROCESS.PROCESS_POSITION,INV_MANU_PROCESS.PROCESS_QUANTITY,INV_MANU_PROCESS.PROCESS_UNIT,";
                        //strSQL = strSQL + "INV_MANU_PROCESS.INV_PER,INV_MANU_PROCESS.FG_COST_PERCENT,INV_MANU_PROCESS.INSERT_DATE,INV_MANU_PROCESS.UPDATE_DATE,INV_MANU_PROCESS.PROCESS_TYPE ";
                        //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.INV_MANU_PROCESS, " + strSourceDB + ".dbo.INV_STOCKITEM ";
                        //strSQL = strSQL + "WHERE INV_STOCKITEM.STOCKITEM_NAME=INV_MANU_PROCESS.STOCKITEM_NAME and INV_STOCKITEM.STOCKITEM_STATUS =0 ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "USER_FORM_CONFIG", 1);
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = "INSERT INTO USER_CONFIG(USER_LOGIN_NAME,USER_CREATE_DATE,USER_FULL_NAME,USER_PASS,USER_LEBEL,USER_STATUS,DEPARTMENT,DESIGNATION,IMAGE)";
                        //strSQL = strSQL + "select USER_LOGIN_NAME,USER_CREATE_DATE,USER_FULL_NAME,USER_PASS,USER_LEBEL,USER_STATUS,DEPARTMENT,DESIGNATION,IMAGE from " + strSourceDB + ".dbo.USER_CONFIG ";
                        //strSQL = strSQL + "where USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') and USER_STATUS <> 'S' ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = "INSERT INTO USER_PRIVILEGES_BRANCH(USER_LOGIN_KEY,USER_LOGIN_NAME,BRANCH_ID ) ";
                        //strSQL = strSQL + "SELECT USER_PRIVILEGES_BRANCH.USER_LOGIN_KEY,USER_PRIVILEGES_BRANCH.USER_LOGIN_NAME,USER_PRIVILEGES_BRANCH.BRANCH_ID  ";
                        //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_BRANCH," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_BRANCH.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
                        //strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = "INSERT INTO USER_PRIVILEGES_COLOR(USER_LOGIN_NAME,LEDGER_GROUP_NAME ) ";
                        //strSQL = strSQL + "SELECT USER_PRIVILEGES_COLOR.USER_LOGIN_NAME,USER_PRIVILEGES_COLOR.LEDGER_GROUP_NAME  ";
                        //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_COLOR," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_COLOR.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
                        //strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //strSQL = "INSERT INTO USER_PRIVILEGES_LOCATION(USER_LOGIN_NAME,GODOWNS_NAME ) ";
                        //strSQL = strSQL + "SELECT USER_PRIVILEGES_LOCATION.USER_LOGIN_NAME,USER_PRIVILEGES_LOCATION.GODOWNS_NAME  ";
                        //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_LOCATION," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_LOCATION.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
                        //strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = "INSERT INTO USER_PRIVILEGES_STOCKGROUP(USER_LOGIN_NAME,STOCKGROUP_NAME ) ";
                        //strSQL = strSQL + "SELECT USER_PRIVILEGES_STOCKGROUP.USER_LOGIN_NAME,USER_PRIVILEGES_STOCKGROUP.STOCKGROUP_NAME   ";
                        //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_STOCKGROUP," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_STOCKGROUP.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
                        //strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE   ) ";
                        //strSQL = strSQL + "SELECT USER_PRIVILEGES_MAIN.USER_LOGIN_KEY,USER_PRIVILEGES_MAIN.USER_LOGIN_NAME,USER_PRIVILEGES_MAIN.PRI_MODULE,USER_PRIVILEGES_MAIN.PRI_TYPE      ";
                        //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_MAIN," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_MAIN.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
                        //strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";

                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();

                        //strSQL = "INSERT INTO USER_PRIVILEGES_CHILD(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_COMPONENT ,PRI_ADD, ";
                        //strSQL = strSQL + "PRI_EDIT ,PRI_DELETE , PRI_APPR,MODULE_TYPE) ";
                        //strSQL = strSQL + "SELECT USER_PRIVILEGES_CHILD.USER_LOGIN_KEY,USER_PRIVILEGES_CHILD.USER_LOGIN_NAME,USER_PRIVILEGES_CHILD.PRI_COMPONENT ,USER_PRIVILEGES_CHILD.PRI_ADD, ";
                        //strSQL = strSQL + "USER_PRIVILEGES_CHILD.PRI_EDIT ,   USER_PRIVILEGES_CHILD.PRI_DELETE , USER_PRIVILEGES_CHILD.PRI_APPR,USER_PRIVILEGES_CHILD.MODULE_TYPE   ";
                        //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_CHILD," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_CHILD.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND  ";
                        //strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //*********************

                        //strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_BALANCE=0 ";
                        //strSQL = strSQL + ",STOCKITEM_OPENING_VALUE=0  ";
                        //strSQL = strSQL + ",STOCKITEM_OPENING_RATE=0  ";
                        //strSQL = strSQL + ",STOCKITEM_CLOSING_BALANCE=0  ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //strSQL = "UPDATE INV_STOCKITEM_CLOSING SET STOCKITEM_CLOSING_BALANCE=0 ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();




                        proBar.Value = proBar.Value + 20;
                        cmdInsert.Transaction.Commit();
                        //string j = mInsertAccountsClosing(strCompanyID, strSourceDB);
                        //if (j == "1")
                        //{
                        //    j = mInsertStockItemClosing(strCompanyID, strSourceDB);
                        //    if (j == "1")
                        //    {

                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show(j);
                        //    }
                        //}
                        //else
                        //{
                        //    MessageBox.Show(j);
                        //}
                        //basTrigger.gCreateTrigger();

                        //strSQL = "UPDATE ACC_LEDGERGROUP SET GR_OPENING_DEBIT = (SELECT isnull(sum(l.LEDGER_OPENING_BALANCE),0)  PDUES  ";
                        //strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l ";
                        //strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                        //strSQL = strSQL + "and L.LEDGER_ONE_DOWN  ='Sundry Debtors') WHERE GR_NAME ='Sundry Debtors' ";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //MessageBox.Show("Thankyou,Successfully Split Your Company");
                        gcnMainnew.Close();
                        gcnMain.Close();
                        cmdInsert.Dispose();
                        cmd.Dispose();
                        Dr.Close();


                    }
                }

            }
       
    }

        private void button4_Click(object sender, EventArgs e)
        {
            string cnn = "", strSQL, strCompanyID = "0004";
            SqlTransaction myTrans;
            SqlCommand cmdInsert = new SqlCommand();
            cnn = Utility.SQLConnstringComSwitch(strCompanyID);
            string strSourceDB = "SMART0004";
            using (SqlConnection gcnMainnew = new SqlConnection(cnn))
            {
                if (gcnMainnew.State == ConnectionState.Open)
                {
                    gcnMainnew.Close();
                }
                try
                {
                    gcnMainnew.Open();
                    myTrans = gcnMainnew.BeginTransaction();
                    cmdInsert.Connection = gcnMainnew;
                    cmdInsert.Transaction = myTrans;

                    //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_COMPANY_VOUCHER", 1);
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();

                    //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BILL_TRAN_PROCESS", 1);
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();

                    //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_VOUCHER", 1);
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();

                    strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BILL_TRAN", 1);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BILL_TRAN_PROCESS", 1);
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();

                    //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_MASTER", 1);
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();

                    //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_TRAN", 1);
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();

                    strSQL = "UPDATE ACC_LEDGER SET LEDGER_OPENING_BALANCE=0,LEDGER_CLOSING_BALANCE=0,LEDGER_OPENING=0,";
                    strSQL = strSQL + "LEDGER_DEBIT=0,LEDGER_CREDIT=0,LEDGER_ON_ACCOUNT_VALUE=0";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE ACC_LEDGERGROUP SET GR_OPENING_DEBIT=0,GR_OPENING_CREDIT=0,GR_DEBIT_TOTAL=0,";
                    strSQL = strSQL + "GR_CREDIT_TOTAL=0,GR_CLOSING_DEBIT=0,GR_CLOSING_CREDIT=0";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE ACC_BRANCH_LEDGER_OPENING SET BRANCH_LEDGER_OPENING_BALANCE=0";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_BALANCE=0,STOCKITEM_OPENING_VALUE=0,STOCKITEM_OPENING_RATE=0,";
                    strSQL = strSQL + "STOCKITEM_CLOSING_BALANCE=0";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE INV_STOCKITEM_CLOSING SET STOCKITEM_CLOSING_BALANCE=0,STOCKITEM_SALE_BALANCE=0";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE ACC_VOUCHER_TYPE SET VOUCHER_TYPE_TOTAL_VOUCHER=0 ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();




                    proBar.Value = proBar.Value + 20;
                    cmdInsert.Transaction.Commit();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    string cnn = "", strSQL, strCompanyID = "0004";
        //    SqlTransaction myTrans;
        //    SqlCommand cmdInsert = new SqlCommand();
        //    cnn = Utility.SQLConnstringComSwitch(strCompanyID);
        //    string strSourceDB = "TROA0010";
        //    using (SqlConnection gcnMainnew = new SqlConnection(cnn))
        //    {
        //        if (gcnMainnew.State == ConnectionState.Open)
        //        {
        //            gcnMainnew.Close();
        //        }
        //        try
        //        {
        //            gcnMainnew.Open();
        //            myTrans = gcnMainnew.BeginTransaction();
        //            cmdInsert.Connection = gcnMainnew;
        //            cmdInsert.Transaction = myTrans;
        //            //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_TO_STOCKITEM", 1);
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();
        //            //strSQL = "INSERT INTO INV_GROUP_TO_STOCKITEM(STOCKGROUP_PARENT,INSERT_DATE,STOCKGROUP_NAME) SELECT STOCKGROUP_PARENT,INSERT_DATE,STOCKGROUP_NAME FROM TROA0010.dbo.INV_GROUP_TO_STOCKITEM ";
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();
        //            ////strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM", 1);
        //            //strSQL = "INSERT INTO INV_STOCKITEM(STOCKITEM_NAME,STOCKITEM_ALIAS,STOCKITEM_DESCRIPTION,STOCKGROUP_NAME,STOCKCATEGORY_NAME,STOCKITEM_PRIMARY_GROUP,STOCKITEM_OPENING_BALANCE,";
        //            //strSQL = strSQL + "STOCKITEM_OPENING_VALUE,STOCKITEM_OPENING_RATE,STOCKITEM_CLOSING_BALANCE,STOCKITEM_INWARDQUANTITY,STOCKITEM_OUTWARDQUANTITY,STOCKITEM_BASEUNITS,STOCKITEM_ADDITIONALUNITS, ";
        //            //strSQL = strSQL + "STOCKITEM_CONVERSION,STOCKITEM_DENOMINATOR,STOCKITEM_MIN_QUANTITY,STOCKITEM_REORDER_LEVEL,STOCKITEM_MAINTAIN_SERIAL,STOCKITEM_MANUFACTURER,STOCKITEM_STATUS, ";
        //            //strSQL = strSQL + "POWER_CLASS,MATERIAL_TYPE,INSERT_DATE,UPDATE_DATE) ";
        //            //strSQL = strSQL + "SELECT STOCKITEM_NAME,STOCKITEM_ALIAS,STOCKITEM_DESCRIPTION,STOCKGROUP_NAME,STOCKCATEGORY_NAME,STOCKITEM_PRIMARY_GROUP,STOCKITEM_OPENING_BALANCE, ";
        //            //strSQL = strSQL + "STOCKITEM_OPENING_VALUE,STOCKITEM_OPENING_RATE,STOCKITEM_CLOSING_BALANCE,STOCKITEM_INWARDQUANTITY,STOCKITEM_OUTWARDQUANTITY,STOCKITEM_BASEUNITS, ";
        //            //strSQL = strSQL + "STOCKITEM_ADDITIONALUNITS,STOCKITEM_CONVERSION,STOCKITEM_DENOMINATOR,STOCKITEM_MIN_QUANTITY,STOCKITEM_REORDER_LEVEL,STOCKITEM_MAINTAIN_SERIAL, ";
        //            //strSQL = strSQL + "STOCKITEM_MANUFACTURER,STOCKITEM_STATUS,POWER_CLASS,MATERIAL_TYPE,INSERT_DATE,UPDATE_DATE  ";
        //            //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.INV_STOCKITEM WHERE STOCKITEM_STATUS =0 ";
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();

        //            ////strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM_TO_GROUP", 1);
        //            //strSQL = "INSERT INTO INV_STOCKITEM_TO_GROUP(STOCKITEM_NAME,STOCKGROUP_NAME,INSERT_DATE,UPDATE_DATE) ";
        //            //strSQL = strSQL + "SELECT INV_STOCKITEM.STOCKITEM_NAME,INV_STOCKITEM_TO_GROUP.STOCKGROUP_NAME,INV_STOCKITEM_TO_GROUP.INSERT_DATE,INV_STOCKITEM_TO_GROUP.UPDATE_DATE ";
        //            //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.INV_STOCKITEM_TO_GROUP," + strSourceDB + ".dbo.INV_STOCKITEM ";
        //            //strSQL = strSQL + "where INV_STOCKITEM.STOCKITEM_NAME =INV_STOCKITEM_TO_GROUP.STOCKITEM_NAME and INV_STOCKITEM.STOCKITEM_STATUS =0 ";
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();

        //            ////strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM_LEVEL", 1);
        //            //strSQL = "INSERT INTO INV_STOCKITEM_LEVEL(STOCKITEM_NAME,STOCKGROUP_LEVEL_1,STOCKGROUP_LEVEL_2,STOCKGROUP_LEVEL_3,STOCKGROUP_LEVEL_4,STOCKGROUP_LEVEL_5,INSERT_DATE,UPDATE_DATE) ";
        //            //strSQL = strSQL + "SELECT INV_STOCKITEM.STOCKITEM_NAME,INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_1,INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_2,INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_3,INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_4,";
        //            //strSQL = strSQL + "INV_STOCKITEM_LEVEL.STOCKGROUP_LEVEL_5,INV_STOCKITEM_LEVEL.INSERT_DATE,INV_STOCKITEM_LEVEL.UPDATE_DATE ";
        //            //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.INV_STOCKITEM_LEVEL," + strSourceDB + ".dbo.INV_STOCKITEM WHERE INV_STOCKITEM.STOCKITEM_NAME=INV_STOCKITEM_LEVEL.STOCKITEM_NAME ";
        //            //strSQL = strSQL + "and INV_STOCKITEM.STOCKITEM_STATUS =0 ";
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();

        //            //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GODOWNS", 1);
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();

        //            ////strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BRANCH_LEDGER_OPENING", 1);
        //            ////strSQL ="INSERT INTO ACC_BRANCH_LEDGER_OPENING(BRANCH_LEDGER_KEY,BRANCH_ID,LEDGER_NAME,BRANCH_LEDGER_OPENING_BALANCE,INSERT_DATE,UPDATE_DATE) ";
        //            ////strSQL = strSQL + "SELECT BRANCH_LEDGER_KEY,BRANCH_ID,LEDGER_NAME,BRANCH_LEDGER_OPENING_BALANCE,INSERT_DATE,UPDATE_DATE FROM " + strSourceDB + ".dbo.ACC_BRANCH_LEDGER_OPENING ";
        //            ////strSQL = strSQL + "WHERE LEDGER_NAME IN (SELECT LEDGER_NAME FROM ACC_LEDGER )";
        //            ////cmdInsert.CommandText = strSQL;
        //            ////cmdInsert.ExecuteNonQuery();

        //            ////strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM_CLOSING", 1);
        //            ////cmdInsert.CommandText = strSQL;
        //            ////cmdInsert.ExecuteNonQuery();

        //            //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_PRICE_LEVEL", 0);
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();
        //            //cmdInsert.Transaction.Commit();
        //            //return;

        //            //strSQL ="INSERT INTO INV_STOCKITEM_CLOSING(STOCKITEM_NAME,GODOWNS_NAME,STOCKITEM_CLOSING_BALANCE,STOCKITEM_SALE_BALANCE,INSERT_DATE,UPDATE_DATE) ";
        //            //strSQL = strSQL + "SELECT STOCKITEM_NAME,GODOWNS_NAME,STOCKITEM_CLOSING_BALANCE,STOCKITEM_SALE_BALANCE,INSERT_DATE,UPDATE_DATE FROM " + strSourceDB + ".INV_STOCKITEM_CLOSING ";
        //            //strSQL = strSQL + "WHERE STOCKITEM_NAME IN (SELECT STOCKITEM_NAME FROM INV_STOCKITEM) ";
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();

        //            //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_SALES_PRICE", 1);
        //            //strSQL = "INSERT INTO INV_SALES_PRICE(SALES_PRICE_KEY,PRICE_UNIQUE_KEY,STOCKITEM_NAME,FROM_QTY,TO_QTY,SALES_PRICE_AMOUNT,SALES_PRICE_EFFECTIVE_DATE,PRICE_LEVEL_NAME,ACTUAL_DISCOUNT,  ";
        //            //strSQL = strSQL + "PERCENT_DISCOUNT,INSERT_DATE,MODULE_STATUS,UPDATE_DATE)  ";
        //            //strSQL = strSQL + "SELECT INV_SALES_PRICE.SALES_PRICE_KEY,INV_SALES_PRICE.PRICE_UNIQUE_KEY,INV_SALES_PRICE.STOCKITEM_NAME,INV_SALES_PRICE.FROM_QTY,INV_SALES_PRICE.TO_QTY,INV_SALES_PRICE.SALES_PRICE_AMOUNT, ";
        //            //strSQL = strSQL + "INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE,INV_SALES_PRICE.PRICE_LEVEL_NAME,INV_SALES_PRICE.ACTUAL_DISCOUNT, ";
        //            //strSQL = strSQL + "INV_SALES_PRICE.PERCENT_DISCOUNT,INV_SALES_PRICE.INSERT_DATE,INV_SALES_PRICE.MODULE_STATUS,";
        //            //strSQL = strSQL + " INV_SALES_PRICE.UPDATE_DATE FROM " + strSourceDB + ".dbo.INV_SALES_PRICE," + strSourceDB + ".dbo.INV_STOCKITEM  ";
        //            //strSQL = strSQL + "WHERE INV_STOCKITEM.STOCKITEM_NAME=INV_SALES_PRICE.STOCKITEM_NAME and INV_STOCKITEM.STOCKITEM_STATUS =0  ";
        //            //strSQL = strSQL + "and INV_SALES_PRICE.STOCKITEM_NAME IN (SELECT STOCKITEM_NAME FROM INV_STOCKITEM) ";
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();
        //            //proBar.Value = proBar.Value + 10;
        //            //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_TRANSPORT_NAME", 1);
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();


        //            //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_COMPANY_VOUCHER", 1);
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();
        //            //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_VOUCHER", 1);
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();
        //            //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_MASTER", 1);
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();
        //            //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_TRAN", 1);
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();
        //            //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BILL_TRAN", 1);
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();
        //            //strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BILL_TRAN_PROCESS", 1);
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();


        //            //strSQL = "INSERT INTO INV_MANU_PROCESS(PROCESS_NAME,STOCKITEM_NAME,PROCESS_POSITION,PROCESS_QUANTITY,PROCESS_UNIT,INV_PER,FG_COST_PERCENT,INSERT_DATE,UPDATE_DATE,PROCESS_TYPE) ";
        //            //strSQL = strSQL + "SELECT INV_MANU_PROCESS.PROCESS_NAME,INV_MANU_PROCESS.STOCKITEM_NAME,INV_MANU_PROCESS.PROCESS_POSITION,INV_MANU_PROCESS.PROCESS_QUANTITY,INV_MANU_PROCESS.PROCESS_UNIT,";
        //            //strSQL = strSQL + "INV_MANU_PROCESS.INV_PER,INV_MANU_PROCESS.FG_COST_PERCENT,INV_MANU_PROCESS.INSERT_DATE,INV_MANU_PROCESS.UPDATE_DATE,INV_MANU_PROCESS.PROCESS_TYPE ";
        //            //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.INV_MANU_PROCESS, " + strSourceDB + ".dbo.INV_STOCKITEM ";
        //            //strSQL = strSQL + "WHERE INV_STOCKITEM.STOCKITEM_NAME=INV_MANU_PROCESS.STOCKITEM_NAME and INV_STOCKITEM.STOCKITEM_STATUS =0 ";
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();

        //            strSQL = Utility.mInsertTableData(strCompanyID, "SMART0003", "USER_FORM_CONFIG", 1);
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();

        //            strSQL = "INSERT INTO USER_CONFIG(USER_LOGIN_NAME,USER_CREATE_DATE,USER_FULL_NAME,USER_PASS,USER_LEBEL,USER_STATUS)";
        //            strSQL = strSQL + "select USER_LOGIN_NAME,USER_CREATE_DATE,USER_FULL_NAME,USER_PASS,USER_LEBEL,USER_STATUS from " + strSourceDB + ".dbo.USER_CONFIG ";
        //            strSQL = strSQL + "where USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') and USER_STATUS <> 'S' ";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();

        //            strSQL = "INSERT INTO USER_PRIVILEGES_BRANCH(USER_LOGIN_KEY,USER_LOGIN_NAME,BRANCH_ID ) ";
        //            strSQL = strSQL + "SELECT USER_PRIVILEGES_BRANCH.USER_LOGIN_KEY,USER_PRIVILEGES_BRANCH.USER_LOGIN_NAME,USER_PRIVILEGES_BRANCH.BRANCH_ID  ";
        //            strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_BRANCH," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_BRANCH.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
        //            strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();

        //            //strSQL = "INSERT INTO USER_PRIVILEGES_COLOR(USER_LOGIN_NAME,LEDGER_GROUP_NAME ) ";
        //            //strSQL = strSQL + "SELECT USER_PRIVILEGES_COLOR.USER_LOGIN_NAME,USER_PRIVILEGES_COLOR.LEDGER_GROUP_NAME  ";
        //            //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_COLOR," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_COLOR.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
        //            //strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();
        //            //strSQL = "INSERT INTO USER_PRIVILEGES_LOCATION(USER_LOGIN_NAME,GODOWNS_NAME ) ";
        //            //strSQL = strSQL + "SELECT USER_PRIVILEGES_LOCATION.USER_LOGIN_NAME,USER_PRIVILEGES_LOCATION.GODOWNS_NAME  ";
        //            //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_LOCATION," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_LOCATION.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
        //            //strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();

        //            //strSQL = "INSERT INTO USER_PRIVILEGES_STOCKGROUP(USER_LOGIN_NAME,STOCKGROUP_NAME ) ";
        //            //strSQL = strSQL + "SELECT USER_PRIVILEGES_STOCKGROUP.USER_LOGIN_NAME,USER_PRIVILEGES_STOCKGROUP.STOCKGROUP_NAME   ";
        //            //strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_STOCKGROUP," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_STOCKGROUP.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
        //            //strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();

        //            strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE   ) ";
        //            strSQL = strSQL + "SELECT USER_PRIVILEGES_MAIN.USER_LOGIN_KEY,USER_PRIVILEGES_MAIN.USER_LOGIN_NAME,USER_PRIVILEGES_MAIN.PRI_MODULE,USER_PRIVILEGES_MAIN.PRI_TYPE      ";
        //            strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_MAIN," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_MAIN.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND   ";
        //            strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";

        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();

        //            strSQL = "INSERT INTO USER_PRIVILEGES_CHILD(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_COMPONENT ,PRI_ADD, ";
        //            strSQL = strSQL + "PRI_EDIT ,PRI_DELETE) ";
        //            strSQL = strSQL + "SELECT USER_PRIVILEGES_CHILD.USER_LOGIN_KEY,USER_PRIVILEGES_CHILD.USER_LOGIN_NAME,USER_PRIVILEGES_CHILD.PRI_COMPONENT ,USER_PRIVILEGES_CHILD.PRI_ADD, ";
        //            strSQL = strSQL + "USER_PRIVILEGES_CHILD.PRI_EDIT ,   USER_PRIVILEGES_CHILD.PRI_DELETE   ";
        //            strSQL = strSQL + "FROM " + strSourceDB + ".dbo.USER_PRIVILEGES_CHILD," + strSourceDB + ".dbo.USER_CONFIG WHERE USER_PRIVILEGES_CHILD.USER_LOGIN_NAME =USER_CONFIG.USER_LOGIN_NAME  AND  ";
        //            strSQL = strSQL + "USER_CONFIG.USER_LOGIN_NAME not in ('Troyee','DeepLaid','DeepLaidNew') AND USER_CONFIG.USER_STATUS <> 'S' ";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();
        //            //*********************





        //            proBar.Value = proBar.Value + 20;
        //            cmdInsert.Transaction.Commit();
        //        }

        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.ToString());
        //        }
        //    }

        //}
    

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //double dblclsAmnt = Utility.dblLedgerClosingBalanceSplit(strComID, "01-01-2019", "31-12-2019", "Sales Accounts", "0002", "SMART0002");
        //    //mInsertAccountsClosing("0003", "SMART0002");
        //    //mInsertStockItemClosing("0003", "SMART0002");
        //    //SqlCommand cmdInsert = new SqlCommand();
        //    //double  dblGP = Convert.ToDouble(Utility.gdblGPMFSplit(strComID, "SMART0002"));

        //    //dblGP = Convert.ToDouble(Utility.gdblGPMF(strComID, "01-01-2018", "31-12-2019", ""));

        //    string strSQL, strFdate = "", strTDate = "", vstrBranchID = "";
        //    string conDb;
        //    string strOldLedger = "";
        //    string strBranchKey = "";
        //    double dblclsAmnt = 0, dblGP = 0;
        //    conDb = Utility.SQLConnstringComSwitch(strComID);

        //    using (SqlConnection gcnMain = new SqlConnection(conDb))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }


        //        gcnMain.Open();
        //        SqlDataReader Dr;

        //        List<accLedger> objLedger = new List<accLedger>();
        //        List<accLedger> objBranch = new List<accLedger>();
        //        List<accLedger> objLederMaster = new List<accLedger>();
        //        SqlCommand cmdInsert = new SqlCommand();

        //        cmdInsert.Connection = gcnMain;
        //        SqlTransaction myTrans;
        //        myTrans = gcnMain.BeginTransaction();
        //        cmdInsert.Connection = gcnMain;
        //        cmdInsert.Transaction = myTrans;




        //        strSQL = "SELECT F1,isnull(F3,0)F3 FROM Sheet1 WHERE F1 IS NOT NULL ";
        //        //strSQL = strSQL + "AND F1 not in ('Abies Can 10M - 30ml') ";
        //        cmdInsert.CommandText = strSQL;
        //        string hh = "";
        //        Dr = cmdInsert.ExecuteReader();
        //        try
        //        {
        //            while (Dr.Read())
        //            {
        //                accLedger obran = new accLedger();
        //                hh = Dr["F1"].ToString();
        //                obran.strLedgerName = Dr["F1"].ToString();
        //                obran.dblAmnt = Convert.ToDouble(Dr["F3"].ToString());
        //                objBranch.Add(obran);
        //            }
        //            Dr.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(hh.ToString());
        //        }




        //        if (objBranch.Count > 0)
        //        {
        //            //label4.Text = icount.ToString();
        //            progressBar1.Value = 0;
        //            progressBar1.Maximum = objBranch.Count();
        //            foreach (accLedger oled in objBranch)
        //            {


        //                strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_RATE=0";
        //                strSQL = strSQL + " ,STOCKITEM_OPENING_VALUE =0 ";
        //                strSQL = strSQL + " WHERE STOCKITEM_NAME ='" + oled.strLedgerName.Replace("'", "''") + "' ";
        //                cmdInsert.CommandText = strSQL;
        //                cmdInsert.ExecuteNonQuery();
        //                strSQL = "UPDATE INV_TRAN SET INV_TRAN_RATE=0 ";
        //                strSQL = strSQL + " ,INV_TRAN_AMOUNT =0";
        //                strSQL = strSQL + " WHERE STOCKITEM_NAME ='" + oled.strLedgerName.Replace("'", "''") + "' ";
        //                strSQL = strSQL + " and GODOWNS_NAME in ('Main Location','Sale Center. Dhaka Depot') ";
        //                strSQL = strSQL + " and INV_VOUCHER_TYPE =0 ";
        //                cmdInsert.CommandText = strSQL;
        //                cmdInsert.ExecuteNonQuery();
        //                progressBar1.Value += 1;
        //            }



        //        }



        //        cmdInsert.Transaction.Commit();


        //        gcnMain.Dispose();
        //        gcnMain.Close();
        //        Dr.Close();
        //        cmdInsert.Dispose();


        //    }




        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    string strSQL, strFdate = "", strTDate = "", vstrBranchID = "";
        //    string conDb;
        //    string strOldLedger = "",strTest="";
        //    string strBranchKey = "";
        //    double dblclsAmnt = 0, dblGP = 0;
        //    int mintVtype = 0;
        //    string strInKey = "", strRefNo = "", strItemName = "";
        //    int intloop = 1;
        //    int intcount = 0;
        //    conDb = Utility.SQLConnstringComSwitch(strComID);

        //    using (SqlConnection gcnMain = new SqlConnection(conDb))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }


        //        gcnMain.Open();
        //        SqlDataReader Dr;

        //        List<accLedger> objLedger = new List<accLedger>();
        //        List<accLedger> objBranch = new List<accLedger>();
        //        List<accLedger> objLederMaster = new List<accLedger>();
        //        SqlCommand cmdInsert = new SqlCommand();

        //        cmdInsert.Connection = gcnMain;
        //        SqlTransaction myTrans;
                
        //        cmdInsert.Connection = gcnMain;
               




        //        strSQL = "SELECT F1 FROM Sheet1 WHERE F1 IS NOT NULL ";
        //        //strSQL = strSQL + "AND F1 in ('ST#000001') ";
        //        cmdInsert.CommandText = strSQL;
        //        string hh = "";
        //        Dr = cmdInsert.ExecuteReader();
        //        try
        //        {
        //            while (Dr.Read())
        //            {
        //                accLedger obran = new accLedger();
        //                hh = Dr["F1"].ToString();
        //                obran.strLedgerName = Dr["F1"].ToString();
        //                //obran.dblAmnt = Convert.ToDouble(Dr["F3"].ToString());
        //                objBranch.Add(obran);
        //            }
        //            Dr.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(hh.ToString());
        //        }

        //        try
        //        {
                  
        //            if (objBranch.Count > 0)
        //            {
        //                //label4.Text = icount.ToString();
        //                progressBar1.Value = 0;
        //                progressBar1.Maximum = objBranch.Count();
        //                foreach (accLedger oled in objBranch)
        //                {
        //                    if (Utility.Left(oled.strLedgerName, 2) == "ST")
        //                    {
        //                        mintVtype = 23;
        //                        strRefNo = "ST0001" + Utility.gstrLastNumber("0002", mintVtype);
        //                    }
        //                    else if (Utility.Left(oled.strLedgerName, 2) == "PI")
        //                    {
        //                        mintVtype = 33;
        //                        strRefNo = "PI0001" + Utility.gstrLastNumber("0002", mintVtype);
        //                    }
        //                    else if (Utility.Left(oled.strLedgerName, 2) == "FG")
        //                    {
        //                        mintVtype = 27;
        //                        strRefNo = "FG0001" + Utility.gstrLastNumber("0002", mintVtype);
        //                    }
        //                    else if (Utility.Left(oled.strLedgerName, 2) == "MC")
        //                    {
        //                        mintVtype = 26;
        //                        strRefNo = "MC0001" + Utility.gstrLastNumber("0002", mintVtype);
        //                    }
        //                    string strDate="31-12-2019";
        //                    myTrans = gcnMain.BeginTransaction();
        //                    cmdInsert.Transaction = myTrans;
        //                    strTest = oled.strLedgerName;
        //                    strSQL = "INSERT INTO INV_MASTER(BRANCH_ID,INV_REF_NO,INV_VOUCHER_TYPE,INV_COST_OPTION,INV_DATE,INWORD_QUANTITY,INV_AMOUNT,INV_OPENING_FLAG,INV_NARRATIONS,LEDGER_NAME,PROCESS_NAME,AGNST_COMP_REF_NO) ";
        //                    strSQL = strSQL + "SELECT BRANCH_ID,'" + strRefNo + "' ,INV_VOUCHER_TYPE,INV_COST_OPTION," + Utility.cvtSQLDateString(strDate) + ",INWORD_QUANTITY,INV_AMOUNT,INV_OPENING_FLAG,INV_NARRATIONS,LEDGER_NAME,PROCESS_NAME,AGNST_COMP_REF_NO ";
        //                    strSQL = strSQL + "FROM SMART0003.dbo.INV_MASTER WHERE INV_REF_NO LIKE '%" + oled.strLedgerName + "'";
        //                    cmdInsert.CommandText = strSQL;
        //                    cmdInsert.ExecuteNonQuery();
        //                    strSQL = "SELECT INV_TRAN_KEY,INV_REF_NO,STOCKITEM_NAME  FROM SMART0003.dbo.INV_TRAN WHERE INV_REF_NO LIKE '%" + oled.strLedgerName + "'";
        //                    cmdInsert.CommandText = strSQL;
        //                    Dr = cmdInsert.ExecuteReader();
        //                    while  (Dr.Read())
        //                    {
        //                        accLedger okey = new accLedger();
        //                        okey.strBranchId  = Dr["INV_TRAN_KEY"].ToString();
        //                        okey.strRefNo1 = Dr["INV_REF_NO"].ToString();
        //                        strOldLedger= Dr["INV_REF_NO"].ToString();
        //                        okey.strItemName = Dr["STOCKITEM_NAME"].ToString();
        //                        objLedger.Add(okey);
        //                    }
        //                    Dr.Close();
        //                    intloop = 1;
        //                    foreach (accLedger ookey in objLedger)
        //                    {
        //                        strItemName = ookey.strItemName;
        //                        strInKey = strRefNo + intloop.ToString().PadLeft(4, '0');
        //                        strSQL = "INSERT INTO INV_TRAN(INV_TRAN_KEY,BRANCH_ID,INV_REF_NO,STOCKITEM_NAME,GODOWNS_NAME,INV_DATE,INV_TRAN_POSITION,INV_VOUCHER_TYPE,INV_OPENING_FLAG,INV_INOUT_FLAG,OPENING_QUANTITY,INWARD_QUANTITY,";
        //                        strSQL = strSQL + "INWARD_AMOUNT,INV_TRAN_QUANTITY,INV_UOM,INV_PER,INV_TRAN_RATE,INV_TRAN_AMOUNT,OUTWARD_QUANTITY,OUTWARD_SALES_AMOUNT,OUTWARD_COST_AMOUNT) ";
        //                        strSQL = strSQL + "SELECT '" + strInKey + "',BRANCH_ID,'" + strRefNo + "',STOCKITEM_NAME,GODOWNS_NAME," + Utility.cvtSQLDateString(strDate) + ",INV_TRAN_POSITION,INV_VOUCHER_TYPE,INV_OPENING_FLAG,INV_INOUT_FLAG,OPENING_QUANTITY,INWARD_QUANTITY, ";
        //                        strSQL = strSQL + "INWARD_AMOUNT,INV_TRAN_QUANTITY,INV_UOM,INV_PER,INV_TRAN_RATE,INV_TRAN_AMOUNT,OUTWARD_QUANTITY,OUTWARD_SALES_AMOUNT,OUTWARD_COST_AMOUNT  ";
        //                        strSQL = strSQL + "FROM SMART0003.dbo.INV_TRAN WHERE INV_TRAN_KEY = '" + ookey.strBranchId + "'";
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        strSQL = "DELETE FROM INV_TRAN WHERE INV_TRAN_KEY='" + ookey.strBranchId + "' ";
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        intloop += 1;
        //                    }


        //                    //strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO LIKE '%" + oled.strLedgerName + "'";
        //                    //cmdInsert.CommandText = strSQL;
        //                    //cmdInsert.ExecuteNonQuery();

        //                    cmdInsert.Transaction.Commit();

        //                    strSQL = VoucherSW.gIncreaseVoucher((int)mintVtype);
        //                    cmdInsert.CommandText = strSQL;
        //                    cmdInsert.ExecuteNonQuery();

        //                    strSQL = "DELETE FROM Sheet1 WHERE F1= '" + oled.strLedgerName + "'";
        //                    cmdInsert.CommandText = strSQL;
        //                    cmdInsert.ExecuteNonQuery();
        //                    //strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_RATE=0";
        //                    //strSQL = strSQL + " ,STOCKITEM_OPENING_VALUE =0 ";
        //                    //strSQL = strSQL + " WHERE STOCKITEM_NAME ='" + oled.strLedgerName.Replace("'", "''") + "' ";
        //                    //cmdInsert.CommandText = strSQL;
        //                    //cmdInsert.ExecuteNonQuery();
        //                    //strSQL = "UPDATE INV_TRAN SET INV_TRAN_RATE=0 ";
        //                    //strSQL = strSQL + " ,INV_TRAN_AMOUNT =0";
        //                    //strSQL = strSQL + " WHERE STOCKITEM_NAME ='" + oled.strLedgerName.Replace("'", "''") + "' ";
        //                    //strSQL = strSQL + " and GODOWNS_NAME in ('Main Location','Sale Center. Dhaka Depot') ";
        //                    //strSQL = strSQL + " and INV_VOUCHER_TYPE =0 ";
        //                    //cmdInsert.CommandText = strSQL;
        //                    //cmdInsert.ExecuteNonQuery();
        //                    progressBar1.Value += 1;

        //                }

        //                MessageBox.Show("Ok");

        //                gcnMain.Dispose();
        //                gcnMain.Close();
        //                Dr.Close();
        //                cmdInsert.Dispose();


        //            }




                   
        //        }
        //        catch (Exception EX)
        //        {
        //            MessageBox.Show(strTest + " " + strItemName);
        //        }
        //    }


        //}

    }




}

