using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;
using JA.Modulecontrolar;
using Dutility;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;
using JA.Modulecontrolar.JACCMS;
using System.Reflection;


namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmIndex : Form
    {
        string strComID { get; set; }
        public string strFormType { get; set; }

        public frmIndex()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
        private void RebuildSerial()
        {
            string strSQL = "";
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
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
                    Prog.Value = 0;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    Prog.Value = Prog.Value + 10;
                    strSQL = "DBCC CHECKIDENT(ACC_BILL_TRAN_PROCESS)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(ACC_BILL_WISE)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(ACC_LEDGERGROUP)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 10;

                    strSQL = "DBCC CHECKIDENT(ACC_BILL_TRAN)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(ACC_ADD_LESS)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(ACC_BRANCH_LEDGER_OPENING)";
                    Prog.Value = Prog.Value + 10;
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(ACC_COMPANY_VOUCHER)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(ACC_COMPANY_VOUCHER_POS_TRAN)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(ACC_LEDGER)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 10;
                    strSQL = "DBCC CHECKIDENT(ACC_VOUCHER)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(ACC_VOUCHER_JOIN)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 10;
                    strSQL = "DBCC CHECKIDENT(INV_MASTER)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(INV_PRODUCTION_LOG)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(INV_SALES_BONUS)";
                    Prog.Value = Prog.Value + 10;
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(INV_SALES_GIFT)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(INV_SALES_PRICE)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 10;

                    strSQL = "DBCC CHECKIDENT(INV_STOCKITEM_CLOSING)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(INV_TRAN)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(SYS_AUDIT)";
                    Prog.Value = Prog.Value + 10;
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(VECTOR_MASTER)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DBCC CHECKIDENT(VECTOR_MASTER_CHILD)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 10;
                    strSQL = "DBCC CHECKIDENT(VECTOR_TRANSACTION)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 10;
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    cmdInsert.Dispose();
                    MessageBox.Show("Ok");
                    this.Dispose();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void gAllIndex()
        {
            string strSQL = "";
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
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
                    //'ACC_ADD_LESS
                    Prog.Value = 0;
                    Prog.Value = Prog.Value + 5;
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_ADD_LESS') DROP INDEX ACC_ADD_LESS.IX_ACC_ADD_LESS ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_ADD_LESS] ON [dbo].[ACC_ADD_LESS]([ADD_LESS_DATE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 5;
                    //'ACC_LEDGERGROUP
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_LEDGERGROUP_GR_LEVEL') DROP INDEX ACC_LEDGERGROUP.IX_ACC_LEDGERGROUP_GR_LEVEL ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_LEDGERGROUP_GR_LEVEL] ON [dbo].[ACC_LEDGERGROUP]([GR_LEVEL]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_LEDGERGROUP_GR_SERIAL') DROP INDEX ACC_LEDGERGROUP.IX_ACC_LEDGERGROUP_GR_SERIAL ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //strSQL = "CREATE INDEX [IX_ACC_LEDGERGROUP_GR_SERIAL] ON [dbo].[ACC_LEDGERGROUP]([GR_SERIAL]) ON [PRIMARY]";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 10;
                    //'ACC_LEDGER
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_LEDGER') DROP INDEX ACC_LEDGER.IX_ACC_COMPANY_ID_LEDGER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_LEDGER_LEDGER_PARENT_GROUP') DROP INDEX ACC_LEDGER.IX_ACC_LEDGER_LEDGER_PARENT_GROUP ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_LEDGER_LEDGER_PARENT_GROUP] ON [dbo].[ACC_LEDGER]([LEDGER_PARENT_GROUP]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 5;
                    // 'INV_STOCKGROUP
                    //strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_INV_STOCKGROUP_STOCKGROUP_SERIAL') DROP INDEX INV_STOCKITEM.IX_INV_STOCKGROUP_STOCKGROUP_SERIAL ";
                    //'  cmdInsert.CommandText=strSQL ;
                    //strSQL = ";CREATE INDEX [IX_INV_STOCKGROUP_STOCKGROUP_SERIAL] ON [dbo].[INV_STOCKGROUP]([STOCKGROUP_SERIAL]) ON [PRIMARY]";
                    //'  cmdInsert.CommandText=strSQL ;

                    //'INV_STOCKITEM
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_STOCKITEM') DROP INDEX INV_STOCKITEM.IX_ACC_COMPANY_ID_STOCKITEM ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 5;
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_INV_STOCKITEM_ALIAS_STOCKITEM') DROP INDEX INV_STOCKITEM.IX_INV_STOCKITEM_ALIAS_STOCKITEM ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_INV_STOCKITEM_ALIAS_STOCKITEM] ON [dbo].[INV_STOCKITEM]([STOCKITEM_ALIAS]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_INV_STOCKITEM_STOCKGROUP_NAME') DROP INDEX INV_STOCKITEM.IX_INV_STOCKITEM_STOCKGROUP_NAME ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_INV_STOCKITEM_STOCKGROUP_NAME] ON [dbo].[INV_STOCKITEM]([STOCKGROUP_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 10;
                    // 'ACC_COMPANY_VOUCHER
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_COMP_VOUCHER') DROP INDEX ACC_COMPANY_VOUCHER.IX_ACC_COMPANY_ID_COMP_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_REF_NO_COMP_VOUCHER') DROP INDEX ACC_COMPANY_VOUCHER.IX_ACC_COMP_REF_NO_COMP_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //'strSQL = "CREATE INDEX [IX_ACC_COMP_REF_NO_COMP_VOUCHER] ON [dbo].[ACC_COMPANY_VOUCHER]([COMP_REF_NO]) ON [PRIMARY]";
                    //'  cmdInsert.CommandText=strSQL ;

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_BRANCH_ID_COMP_VOUCHER') DROP INDEX ACC_COMPANY_VOUCHER.IX_ACC_BRANCH_ID_COMP_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_BRANCH_ID_COMP_VOUCHER] ON [dbo].[ACC_COMPANY_VOUCHER]([BRANCH_ID]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 10;
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_LEDGER_NAME_COMP_VOUCHER') DROP INDEX ACC_COMPANY_VOUCHER.IX_ACC_LEDGER_NAME_COMP_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_LEDGER_NAME_COMP_VOUCHER] ON [dbo].[ACC_COMPANY_VOUCHER]([LEDGER_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_VOUCHER_DATE_COMP_VOUCHER') DROP INDEX ACC_COMPANY_VOUCHER.IX_ACC_COMP_VOUCHER_DATE_COMP_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_COMP_VOUCHER_DATE_COMP_VOUCHER] ON [dbo].[ACC_COMPANY_VOUCHER]([COMP_VOUCHER_DATE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_VOUCHER_TYPE_COMP_VOUCHER') DROP INDEX ACC_COMPANY_VOUCHER.IX_ACC_COMP_VOUCHER_TYPE_COMP_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_COMP_VOUCHER_TYPE_COMP_VOUCHER] ON [dbo].[ACC_COMPANY_VOUCHER]([COMP_VOUCHER_TYPE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 5;
                    //'ACC_VOUCHER
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_ACC_VOUCHER') DROP INDEX ACC_VOUCHER.IX_ACC_COMPANY_ID_ACC_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_REF_NO_ACC_VOUCHER') DROP INDEX ACC_VOUCHER.IX_ACC_COMP_REF_NO_ACC_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //strSQL = "CREATE INDEX [IX_ACC_COMP_REF_NO_ACC_VOUCHER] ON [dbo].[ACC_VOUCHER]([COMP_REF_NO]) ON [PRIMARY]";
                    //'      cmdInsert.CommandText=strSQL ;

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_ACC_VOUCHER') DROP INDEX ACC_VOUCHER.IX_ACC_COMPANY_ID_ACC_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_BRANCH_ID_ACC_VOUCHER') DROP INDEX ACC_VOUCHER.IX_ACC_BRANCH_ID_ACC_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_BRANCH_ID_ACC_VOUCHER] ON [dbo].[ACC_VOUCHER]([BRANCH_ID]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 5;
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_VOUCHER_DATE_ACC_VOUCHER') DROP INDEX ACC_VOUCHER.IX_ACC_COMP_VOUCHER_DATE_ACC_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_COMP_VOUCHER_DATE_ACC_VOUCHER] ON [dbo].[ACC_VOUCHER]([COMP_VOUCHER_DATE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_LEDGER_NAME_ACC_VOUCHER') DROP INDEX ACC_VOUCHER.IX_ACC_LEDGER_NAME_ACC_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_LEDGER_NAME_ACC_VOUCHER] ON [dbo].[ACC_VOUCHER]([LEDGER_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_VOUCHER_TYPE_ACC_VOUCHER') DROP INDEX ACC_VOUCHER.IX_ACC_COMP_VOUCHER_TYPE_ACC_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_COMP_VOUCHER_TYPE_ACC_VOUCHER] ON [dbo].[ACC_VOUCHER]([COMP_VOUCHER_TYPE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_VOUCHER_CHEQUE_DATE_ACC_VOUCHER') DROP INDEX ACC_VOUCHER.IX_ACC_VOUCHER_CHEQUE_DATE_ACC_VOUCHER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_VOUCHER_CHEQUE_DATE_ACC_VOUCHER] ON [dbo].[ACC_VOUCHER]([VOUCHER_CHEQUE_DATE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 5;
                    //'ACC_BILL_TRAN
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_ACC_BILL_TRAN') DROP INDEX ACC_BILL_TRAN.IX_ACC_COMPANY_ID_ACC_BILL_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_BRANCH_ID_ACC_BILL_TRAN') DROP INDEX ACC_BILL_TRAN.IX_ACC_BRANCH_ID_ACC_BILL_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_BRANCH_ID_ACC_BILL_TRAN] ON [dbo].[ACC_BILL_TRAN]([BRANCH_ID]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_REF_NO_ACC_BILL_TRAN') DROP INDEX ACC_BILL_TRAN.IX_ACC_COMP_REF_NO_ACC_BILL_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_COMP_REF_NO_ACC_BILL_TRAN] ON [dbo].[ACC_BILL_TRAN]([COMP_REF_NO]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_VOUCHER_TYPE_ACC_BILL_TRAN') DROP INDEX ACC_BILL_TRAN.IX_ACC_COMP_VOUCHER_TYPE_ACC_BILL_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_COMP_VOUCHER_TYPE_ACC_BILL_TRAN] ON [dbo].[ACC_BILL_TRAN]([COMP_VOUCHER_TYPE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_VOUCHER_DATE_ACC_BILL_TRAN') DROP INDEX ACC_BILL_TRAN.IX_ACC_COMP_VOUCHER_DATE_ACC_BILL_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_COMP_VOUCHER_DATE_ACC_BILL_TRAN] ON [dbo].[ACC_BILL_TRAN]([COMP_VOUCHER_DATE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    // 'ACC_BILL_TRAN_APP
                    //strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_ACC_BILL_TRAN_APPR') DROP INDEX ACC_BILL_TRAN.IX_ACC_COMPANY_ID_ACC_BILL_TRAN_APPR ";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();

                    // strSQL = ";IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_BRANCH_ID_ACC_BILL_TRAN_APPR') DROP INDEX ACC_BILL_TRAN.IX_ACC_BRANCH_ID_ACC_BILL_TRAN_APPR ";
                    //// '      cmdInsert.CommandText=strSQL ;
                    // strSQL = ";CREATE INDEX [IX_ACC_BRANCH_ID_ACC_BILL_TRAN_APPR] ON [dbo].[ACC_BILL_TRAN_APPR]([BRANCH_ID]) ON [PRIMARY]";
                    // //'      cmdInsert.CommandText=strSQL ;

                    //strSQL = ";IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_REF_NO_ACC_BILL_TRAN_APPR') DROP INDEX ACC_BILL_TRAN.IX_ACC_COMP_REF_NO_ACC_BILL_TRAN_APPR ";
                    //'      cmdInsert.CommandText=strSQL ;
                    //strSQL = ";CREATE INDEX [IX_ACC_COMP_REF_NO_ACC_BILL_TRAN_APPR] ON [dbo].[ACC_BILL_TRAN_APPR]([COMP_REF_NO]) ON [PRIMARY]";
                    //'      cmdInsert.CommandText=strSQL ;

                    //strSQL = ";IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_VOUCHER_TYPE_ACC_BILL_TRAN_APPR') DROP INDEX ACC_BILL_TRAN.IX_ACC_COMP_VOUCHER_TYPE_ACC_BILL_TRAN_APPR ";
                    //'      cmdInsert.CommandText=strSQL ;
                    //strSQL = ";CREATE INDEX [IX_ACC_COMP_VOUCHER_TYPE_ACC_BILL_TRAN_APPR] ON [dbo].[ACC_BILL_TRAN_APPR]([COMP_VOUCHER_TYPE]) ON [PRIMARY]";
                    //'      cmdInsert.CommandText=strSQL ;

                    //strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_VOUCHER_DATE_ACC_BILL_TRAN_APPR') DROP INDEX ACC_BILL_TRAN_APPR.IX_ACC_COMP_VOUCHER_DATE_ACC_BILL_TRAN_APPR ";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();
                    //strSQL = "CREATE INDEX [IX_ACC_COMP_VOUCHER_DATE_ACC_BILL_TRAN_APPR] ON [dbo].[ACC_BILL_TRAN_APPR]([COMP_VOUCHER_DATE]) ON [PRIMARY]";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();




                    Prog.Value = Prog.Value + 5;
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_STOCKITEM_NAME_ACC_BILL_TRAN') DROP INDEX ACC_BILL_TRAN.IX_ACC_STOCKITEM_NAME_ACC_BILL_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_STOCKITEM_NAME_ACC_BILL_TRAN] ON [dbo].[ACC_BILL_TRAN]([STOCKITEM_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_GODOWNS_NAME_ACC_BILL_TRAN') DROP INDEX ACC_BILL_TRAN.IX_ACC_GODOWNS_NAME_ACC_BILL_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_GODOWNS_NAME_ACC_BILL_TRAN] ON [dbo].[ACC_BILL_TRAN]([GODOWNS_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_AGNST_COMP_REF_NO_ACC_BILL_TRAN') DROP INDEX ACC_BILL_TRAN.IX_ACC_AGNST_COMP_REF_NO_ACC_BILL_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_AGNST_COMP_REF_NO_ACC_BILL_TRAN] ON [dbo].[ACC_BILL_TRAN]([AGNST_COMP_REF_NO]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'ACC_BILL_WISE
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_ACC_BILL_WISE') DROP INDEX ACC_BILL_WISE.IX_ACC_COMPANY_ID_ACC_BILL_WISE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_BRANCH_ID_ACC_BILL_WISE') DROP INDEX ACC_BILL_WISE.IX_ACC_BRANCH_ID_ACC_BILL_WISE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_BRANCH_ID_ACC_BILL_WISE] ON [dbo].[ACC_BILL_WISE]([BRANCH_ID]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 2;
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_REF_NO_ACC_BILL_WISE') DROP INDEX ACC_BILL_WISE.IX_ACC_COMP_REF_NO_ACC_BILL_WISE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_COMP_REF_NO_ACC_BILL_WISE] ON [dbo].[ACC_BILL_WISE]([COMP_REF_NO]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_VOUCHER_TYPE_ACC_BILL_WISE') DROP INDEX ACC_BILL_WISE.IX_ACC_COMP_VOUCHER_TYPE_ACC_BILL_WISE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_COMP_VOUCHER_TYPE_ACC_BILL_WISE] ON [dbo].[ACC_BILL_WISE]([COMP_VOUCHER_TYPE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_VOUCHER_DATE_ACC_BILL_WISE') DROP INDEX ACC_BILL_WISE.IX_ACC_COMP_VOUCHER_DATE_ACC_BILL_WISE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_COMP_VOUCHER_DATE_ACC_BILL_WISE] ON [dbo].[ACC_BILL_WISE]([COMP_VOUCHER_DATE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_VOUCHER_REF_KEY_ACC_BILL_WISE') DROP INDEX ACC_BILL_WISE.IX_ACC_VOUCHER_REF_KEY_ACC_BILL_WISE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_VOUCHER_REF_KEY_ACC_BILL_WISE] ON [dbo].[ACC_BILL_WISE]([VOUCHER_REF_KEY]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 3;
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_AGAINST_VOUCHER_NO_ACC_BILL_WISE') DROP INDEX ACC_BILL_WISE.IX_ACC_AGAINST_VOUCHER_NO_ACC_BILL_WISE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_AGAINST_VOUCHER_NO_ACC_BILL_WISE] ON [dbo].[ACC_BILL_WISE]([AGAINST_VOUCHER_NO]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_LEDGER_NAME_ACC_BILL_WISE') DROP INDEX ACC_BILL_WISE.IX_ACC_LEDGER_NAME_ACC_BILL_WISE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_LEDGER_NAME_ACC_BILL_WISE] ON [dbo].[ACC_BILL_WISE]([LEDGER_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'INV_MASTER
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_INV_MASTER') DROP INDEX INV_MASTER.IX_ACC_COMPANY_ID_INV_MASTER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_BRANCH_ID_INV_MASTER') DROP INDEX INV_MASTER.IX_ACC_BRANCH_ID_INV_MASTER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_BRANCH_ID_INV_MASTER] ON [dbo].[INV_MASTER]([BRANCH_ID]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 2;
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_INV_VOUCHER_TYPE_INV_MASTER') DROP INDEX INV_MASTER.IX_ACC_INV_VOUCHER_TYPE_INV_MASTER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_INV_VOUCHER_TYPE_INV_MASTER] ON [dbo].[INV_MASTER]([INV_VOUCHER_TYPE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_INV_DATE_INV_MASTER') DROP INDEX INV_MASTER.IX_ACC_INV_DATE_INV_MASTER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_INV_DATE_INV_MASTER] ON [dbo].[INV_MASTER]([INV_DATE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_INV_OPENING_FLAG_INV_MASTER') DROP INDEX INV_MASTER.IX_ACC_INV_OPENING_FLAG_INV_MASTER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_INV_OPENING_FLAG_INV_MASTER] ON [dbo].[INV_MASTER]([INV_OPENING_FLAG]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_AGNST_COMP_REF_NO_INV_MASTER') DROP INDEX INV_MASTER.IX_ACC_AGNST_COMP_REF_NO_INV_MASTER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_AGNST_COMP_REF_NO_INV_MASTER] ON [dbo].[INV_MASTER]([AGNST_COMP_REF_NO]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_LEDGER_NAME_INV_MASTER') DROP INDEX INV_MASTER.IX_ACC_LEDGER_NAME_INV_MASTER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_LEDGER_NAME_INV_MASTER] ON [dbo].[INV_MASTER]([LEDGER_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_PROCESS_NAME_INV_MASTER') DROP INDEX INV_MASTER.IX_ACC_PROCESS_NAME_INV_MASTER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_PROCESS_NAME_INV_MASTER] ON [dbo].[INV_MASTER]([PROCESS_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 1;
                    //'INV_TRAN
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_INV_TRAN') DROP INDEX INV_TRAN.IX_ACC_COMPANY_ID_INV_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_BRANCH_ID_INV_TRAN') DROP INDEX INV_TRAN.IX_ACC_BRANCH_ID_INV_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_BRANCH_ID_INV_TRAN] ON [dbo].[INV_TRAN]([BRANCH_ID]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_INV_REF_NO_INV_TRAN') DROP INDEX INV_TRAN.IX_ACC_INV_REF_NO_INV_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_INV_REF_NO_INV_TRAN] ON [dbo].[INV_TRAN]([INV_REF_NO]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_INV_TRAN_KEY_INV_TRAN') DROP INDEX INV_TRAN.IX_ACC_INV_TRAN_KEY_INV_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_INV_TRAN_KEY_INV_TRAN] ON [dbo].[INV_TRAN]([INV_TRAN_KEY]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_STOCKITEM_NAME_INV_TRAN') DROP INDEX INV_TRAN.IX_ACC_STOCKITEM_NAME_INV_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_STOCKITEM_NAME_INV_TRAN] ON [dbo].[INV_TRAN]([STOCKITEM_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_GODOWNS_NAME_INV_TRAN') DROP INDEX INV_TRAN.IX_ACC_GODOWNS_NAME_INV_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_GODOWNS_NAME_INV_TRAN] ON [dbo].[INV_TRAN]([GODOWNS_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 1;
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_INV_DATE_INV_TRAN') DROP INDEX INV_TRAN.IX_ACC_INV_DATE_INV_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_INV_DATE_INV_TRAN] ON [dbo].[INV_TRAN]([INV_DATE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_INV_VOUCHER_TYPE_INV_TRAN') DROP INDEX INV_TRAN.IX_ACC_INV_VOUCHER_TYPE_INV_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_INV_VOUCHER_TYPE_INV_TRAN] ON [dbo].[INV_TRAN]([INV_VOUCHER_TYPE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_INV_OPENING_FLAG_INV_TRAN') DROP INDEX INV_TRAN.IX_ACC_INV_OPENING_FLAG_INV_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_INV_OPENING_FLAG_INV_TRAN] ON [dbo].[INV_TRAN]([INV_OPENING_FLAG]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_INV_INOUT_FLAG_INV_TRAN') DROP INDEX INV_TRAN.IX_ACC_INV_INOUT_FLAG_INV_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_INV_INOUT_FLAG_INV_TRAN] ON [dbo].[INV_TRAN]([INV_INOUT_FLAG]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_BILL_TRAN_AGST_VOUCHER_TYPE_INV_TRAN') DROP INDEX INV_TRAN.IX_ACC_BILL_TRAN_AGST_VOUCHER_TYPE_INV_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_BILL_TRAN_AGST_VOUCHER_TYPE_INV_TRAN] ON [dbo].[INV_TRAN]([BILL_TRAN_AGST_VOUCHER_TYPE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_PROCESS_NAME_INV_TRAN') DROP INDEX INV_TRAN.IX_ACC_PROCESS_NAME_INV_TRAN ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_PROCESS_NAME_INV_TRAN] ON [dbo].[INV_TRAN]([PROCESS_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'INV_SALES_PRICE
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_INV_SALES_PRICE') DROP INDEX INV_SALES_PRICE.IX_ACC_COMPANY_ID_INV_SALES_PRICE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_PRICE_UNIQUE_KEY_INV_SALES_PRICE') DROP INDEX INV_SALES_PRICE.IX_ACC_PRICE_UNIQUE_KEY_INV_SALES_PRICE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_PRICE_UNIQUE_KEY_INV_SALES_PRICE] ON [dbo].[INV_SALES_PRICE]([PRICE_UNIQUE_KEY]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_STOCKITEM_NAME_INV_SALES_PRICE') DROP INDEX INV_SALES_PRICE.IX_ACC_STOCKITEM_NAME_INV_SALES_PRICE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_STOCKITEM_NAME_INV_SALES_PRICE] ON [dbo].[INV_SALES_PRICE]([STOCKITEM_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_SALES_PRICE_EFFECTIVE_DATE_INV_SALES_PRICE') DROP INDEX INV_SALES_PRICE.IX_ACC_SALES_PRICE_EFFECTIVE_DATE_INV_SALES_PRICE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_SALES_PRICE_EFFECTIVE_DATE_INV_SALES_PRICE] ON [dbo].[INV_SALES_PRICE]([SALES_PRICE_EFFECTIVE_DATE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_FROM_QTY_INV_SALES_PRICE') DROP INDEX INV_SALES_PRICE.IX_ACC_FROM_QTY_INV_SALES_PRICE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_FROM_QTY_INV_SALES_PRICE] ON [dbo].[INV_SALES_PRICE]([FROM_QTY]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_TO_QTY_INV_SALES_PRICE') DROP INDEX INV_SALES_PRICE.IX_ACC_TO_QTY_INV_SALES_PRICE ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_TO_QTY_INV_SALES_PRICE] ON [dbo].[INV_SALES_PRICE]([TO_QTY]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'INV_GODOWNS
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_INV_GODOWNS') DROP INDEX INV_GODOWNS.IX_ACC_COMPANY_ID_INV_GODOWNS ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_BRANCH_ID_INV_GODOWNS') DROP INDEX INV_GODOWNS.IX_ACC_BRANCH_ID_INV_GODOWNS ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_BRANCH_ID_INV_GODOWNS] ON [dbo].[INV_GODOWNS]([BRANCH_ID]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'INV_STOCKITEM_CLOSING
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_INV_STOCKITEM_CLOSING') DROP INDEX INV_STOCKITEM_CLOSING.IX_ACC_COMPANY_ID_INV_STOCKITEM_CLOSING ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_STOCKITEM_NAME_INV_STOCKITEM_CLOSING') DROP INDEX INV_STOCKITEM_CLOSING.IX_ACC_STOCKITEM_NAME_INV_STOCKITEM_CLOSING ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_STOCKITEM_NAME_INV_STOCKITEM_CLOSING] ON [dbo].[INV_STOCKITEM_CLOSING]([STOCKITEM_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_GODOWNS_NAME_INV_STOCKITEM_CLOSING') DROP INDEX INV_STOCKITEM_CLOSING.IX_ACC_GODOWNS_NAME_INV_STOCKITEM_CLOSING ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_GODOWNS_NAME_INV_STOCKITEM_CLOSING] ON [dbo].[INV_STOCKITEM_CLOSING]([GODOWNS_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'SYS_AUDIT
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_SYS_AUDIT') DROP INDEX SYS_AUDIT.IX_ACC_COMPANY_ID_SYS_AUDIT ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 1;

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_BRANCH_ID_SYS_AUDIT') DROP INDEX SYS_AUDIT.IX_ACC_BRANCH_ID_SYS_AUDIT ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_BRANCH_ID_SYS_AUDIT] ON [dbo].[SYS_AUDIT]([BRANCH_ID]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_AUDIT_DATE_SYS_AUDIT') DROP INDEX SYS_AUDIT.IX_ACC_AUDIT_DATE_SYS_AUDIT ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_AUDIT_DATE_SYS_AUDIT] ON [dbo].[SYS_AUDIT]([AUDIT_DATE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_AUDIT_TYPE_SYS_AUDIT') DROP INDEX SYS_AUDIT.IX_ACC_AUDIT_TYPE_SYS_AUDIT ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_AUDIT_TYPE_SYS_AUDIT] ON [dbo].[SYS_AUDIT]([AUDIT_TYPE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_USER_LOGIN_NAME_SYS_AUDIT') DROP INDEX SYS_AUDIT.IX_ACC_USER_LOGIN_NAME_SYS_AUDIT ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_USER_LOGIN_NAME_SYS_AUDIT] ON [dbo].[SYS_AUDIT]([USER_LOGIN_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_MODULE_TYPE_SYS_AUDIT') DROP INDEX SYS_AUDIT.IX_ACC_MODULE_TYPE_SYS_AUDIT ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_MODULE_TYPE_SYS_AUDIT] ON [dbo].[SYS_AUDIT]([MODULE_TYPE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 5;
                    //'VECTOR_MASTER_CHILD
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_VECTOR_MASTER_CHILD') DROP INDEX VECTOR_MASTER_CHILD.IX_ACC_COMPANY_ID_VECTOR_MASTER_CHILD ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_BRANCH_ID_VECTOR_MASTER_CHILD') DROP INDEX VECTOR_MASTER_CHILD.IX_ACC_BRANCH_ID_VECTOR_MASTER_CHILD ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_BRANCH_ID_VECTOR_MASTER_CHILD] ON [dbo].[VECTOR_MASTER_CHILD]([BRANCH_ID]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_VECTOR_CATEGORY_NAME_VECTOR_MASTER_CHILD') DROP INDEX VECTOR_MASTER_CHILD.IX_ACC_VECTOR_CATEGORY_NAME_VECTOR_MASTER_CHILD ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_VECTOR_CATEGORY_NAME_VECTOR_MASTER_CHILD] ON [dbo].[VECTOR_MASTER_CHILD]([VECTOR_CATEGORY_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_MASTER_LEDGER_NAME_VECTOR_MASTER_CHILD') DROP INDEX VECTOR_MASTER_CHILD.IX_ACC_MASTER_LEDGER_NAME_VECTOR_MASTER_CHILD ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_MASTER_LEDGER_NAME_VECTOR_MASTER_CHILD] ON [dbo].[VECTOR_MASTER_CHILD]([MASTER_LEDGER_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 5;
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_VMASTER_NAME_VECTOR_MASTER_CHILD') DROP INDEX VECTOR_MASTER_CHILD.IX_ACC_VMASTER_NAME_VECTOR_MASTER_CHILD ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_VMASTER_NAME_VECTOR_MASTER_CHILD] ON [dbo].[VECTOR_MASTER_CHILD]([VMASTER_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'VECTOR_MASTER
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_VECTOR_MASTER') DROP INDEX VECTOR_MASTER.IX_ACC_COMPANY_ID_VECTOR_MASTER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_VECTOR_CATEGORY_NAME_VECTOR_MASTER') DROP INDEX VECTOR_MASTER.IX_ACC_VECTOR_CATEGORY_NAME_VECTOR_MASTER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_VECTOR_CATEGORY_NAME_VECTOR_MASTER] ON [dbo].[VECTOR_MASTER]([VECTOR_CATEGORY_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_VECTOR_UNDER_VECTOR_MASTER') DROP INDEX VECTOR_MASTER.IX_ACC_VECTOR_UNDER_VECTOR_MASTER ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_VECTOR_UNDER_VECTOR_MASTER] ON [dbo].[VECTOR_MASTER]([VECTOR_UNDER]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'VECTOR_TRANSACTION
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMPANY_ID_VECTOR_TRANSACTION') DROP INDEX VECTOR_TRANSACTION.IX_ACC_COMPANY_ID_VECTOR_TRANSACTION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_COMP_REF_NO_VECTOR_TRANSACTION') DROP INDEX VECTOR_TRANSACTION.IX_ACC_COMP_REF_NO_VECTOR_TRANSACTION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_COMP_REF_NO_VECTOR_TRANSACTION] ON [dbo].[VECTOR_TRANSACTION]([COMP_REF_NO]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 5;
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_BRANCH_ID_VECTOR_TRANSACTION') DROP INDEX VECTOR_TRANSACTION.IX_ACC_BRANCH_ID_VECTOR_TRANSACTION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_BRANCH_ID_VECTOR_TRANSACTION] ON [dbo].[VECTOR_TRANSACTION]([BRANCH_ID]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_VT_TRAN_DATE_VECTOR_TRANSACTION') DROP INDEX VECTOR_TRANSACTION.IX_ACC_VT_TRAN_DATE_VECTOR_TRANSACTION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_VT_TRAN_DATE_VECTOR_TRANSACTION] ON [dbo].[VECTOR_TRANSACTION]([VT_TRAN_DATE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_VT_TYPE_VECTOR_TRANSACTION') DROP INDEX VECTOR_TRANSACTION.IX_ACC_VT_TYPE_VECTOR_TRANSACTION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_VT_TYPE_VECTOR_TRANSACTION] ON [dbo].[VECTOR_TRANSACTION]([VT_TYPE]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_VMASTER_NAME_VECTOR_TRANSACTION') DROP INDEX VECTOR_TRANSACTION.IX_ACC_VMASTER_NAME_VECTOR_TRANSACTION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_VMASTER_NAME_VECTOR_TRANSACTION] ON [dbo].[VECTOR_TRANSACTION]([VMASTER_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    Prog.Value = Prog.Value + 5;
                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_LEDGER_NAME_VECTOR_TRANSACTION') DROP INDEX VECTOR_TRANSACTION.IX_ACC_LEDGER_NAME_VECTOR_TRANSACTION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_LEDGER_NAME_VECTOR_TRANSACTION] ON [dbo].[VECTOR_TRANSACTION]([LEDGER_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name From sysindexes WHERE name = 'IX_ACC_VCATEGORY_NAME_VECTOR_TRANSACTION') DROP INDEX VECTOR_TRANSACTION.IX_ACC_VCATEGORY_NAME_VECTOR_TRANSACTION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "CREATE INDEX [IX_ACC_VCATEGORY_NAME_VECTOR_TRANSACTION] ON [dbo].[VECTOR_TRANSACTION]([VCATEGORY_NAME]) ON [PRIMARY]";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    cmdInsert.Dispose();
                    MessageBox.Show("Ok");
                    this.Dispose();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (strFormType=="I")
            {
                gAllIndex();
            }
            else
            {
                RebuildSerial();
            }

        }

        private void frmIndex_Load(object sender, EventArgs e)
        {
            if (strFormType=="I")
            {
                this.Text = "Re-Indexing";
            }
            else
            {
                this.Text = "Rebuild Serial";
            }
        }

       

      

       
    
       
    }
}