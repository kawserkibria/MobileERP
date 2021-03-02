using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutility
{
    public class basViewSchemaStock
    {
        public static string gCreateViewStock()
        {
            string strSQL;


            strSQL = CreateBatchQry();
            strSQL = CreateViewZeroSales();
            strSQL = CreateStockLedView();
            strSQL = CreateStockItemToGroupQry();
            strSQL = CreateInvOpeningQry();
            strSQL = CreateInvTranQry();
            strSQL = CreateInvOpeningTranQry();
            strSQL = CreateInvStockQty();
            strSQL = CreateInvSlowMovingStockQty();
            strSQL = CreateInvOpeningTranLocQry();
            strSQL = CreateInvManufacAndAccount();
            strSQL = CreateInvManufacAndAccountTwo();
            strSQL = CreateInvManufacAndAccountThree();
            strSQL = CreateInvTranQtyQry();
            strSQL = CreateInvMasterView();
            strSQL = CreateInvEffectView();
            strSQL = CreateVoucherInvEffect();
            strSQL = CreateViewInvNegativeQty();
            strSQL = CreateProcessQryAson();
            strSQL = CreateAgingYear();
            strSQL = CreateAccGroupCompBillTranQry();
            strSQL = CreateInvStickClosingGroupwiseQry();
            strSQL = CreateInvQtyOnOrder();
            strSQL = CreateStockInvTranDate();
            strSQL = CreateStockInvBillTranDate();
            strSQL = StockTransferReportQry();
            strSQL = CreateViewCheckLedger();
            strSQL = CreateItemColsingView();
            strSQL = CreateclosingviewNew();
            //'CreateInvBatchTranView
            strSQL = CreateBillTranQryAppr();
            strSQL = CreateStockInvManufactureQry();
            strSQL = CreateStockStatementView();
            strSQL = CreateStockPackSizeView();
            strSQL = CreateInvFinishedItemStatementView();
            strSQL = CreateInvProductStatementView();
            strSQL = CreateTargetTempView();
            return strSQL;
        }
        private static string CreateTargetTempView()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TARGET_DETAIL_2_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[TARGET_DETAIL_2_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW TARGET_DETAIL_2_VIEW AS SELECT LEDGER_NAME, STOCK_GROUP_NAME,  ISNULL(STOCKITEM_NAME,'- -') AS STOCKITEM_NAME ,  ";
                    strSQL = strSQL + "ISNULL(STOCKCATEGORY_NAME,' - -') AS STOCKCATEGORY_NAME ,  ISNULL(SUM(TARGET_QTY),0) AS TARGET_QTY, ";
                    strSQL = strSQL + "ISNULL(SUM(SALES_QTY),0) AS SALES_QTY, ISNULL(SUM(B_QTY),0) AS B_QTY From TARGET_DETAILS_TEMP GROUP BY LEDGER_NAME, STOCK_GROUP_NAME, STOCKITEM_NAME, STOCKCATEGORY_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TARGET_DETAIL_2_VIEW1]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[TARGET_DETAIL_2_VIEW1] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW TARGET_DETAIL_2_VIEW1 AS  SELECT ACC_COMPANY_VOUCHER.LEDGER_NAME,INV_STOCKITEM.STOCKGROUP_NAME, ACC_BILL_TRAN.STOCKITEM_NAME, ";
                    strSQL = strSQL + "INV_STOCKITEM.STOCKCATEGORY_NAME, SUM(ACC_BILL_TRAN.BILL_QUANTITY)  AS BILL_QUANTITY,SUM(BILL_QUANTITY_BONUS) AS BONUS  ";
                    strSQL = strSQL + "FROM INV_STOCKITEM INNER JOIN ACC_BILL_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = ACC_BILL_TRAN.STOCKITEM_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER ON ACC_BILL_TRAN.COMP_REF_NO = ACC_COMPANY_VOUCHER.COMP_REF_NO  ";
                    strSQL = strSQL + "GROUP BY ACC_COMPANY_VOUCHER.LEDGER_NAME,INV_STOCKITEM.STOCKGROUP_NAME, INV_STOCKITEM.STOCKCATEGORY_NAME,ACC_BILL_TRAN.STOCKITEM_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TARGET_DETAIL_3_VIEW1]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[TARGET_DETAIL_3_VIEW1] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW TARGET_DETAIL_3_VIEW1 AS  SELECT LEDGER_NAME, STOCKGROUP_NAME, STOCKITEM_NAME, STOCKCATEGORY_NAME, SUM(BILL_QUANTITY) AS BILL_QUANTITY, SUM(BONUS) AS BONUS From TARGET_DETAIL_2_VIEW1 GROUP BY LEDGER_NAME, STOCKGROUP_NAME, STOCKITEM_NAME, STOCKCATEGORY_NAME ";
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TARGET_DETAIL_4_VIEW1]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[TARGET_DETAIL_4_VIEW1] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW TARGET_DETAIL_4_VIEW1 AS  SELECT LEDGER_NAME, STOCKGROUP_NAME, STOCKITEM_NAME, STOCKCATEGORY_NAME, SUM(BILL_QUANTITY) AS BILL_QUANTITY_P, SUM(BONUS) AS BONUS_P From TARGET_DETAIL_2_VIEW1 GROUP BY LEDGER_NAME, STOCKGROUP_NAME, STOCKITEM_NAME, STOCKCATEGORY_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_TRAN_OUTWARD_RATE_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_TRAN_OUTWARD_RATE_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_TRAN_OUTWARD_RATE_QRY AS ";
                    strSQL = strSQL + "SELECT STOCKITEM_NAME, ISNULL(SUM(BILL_NET_AMOUNT), 0) AS BILL_NET_AMOUNT, ISNULL(SUM(BILL_QUANTITY), 0) AS BILL_QUANTITY ";
                    strSQL = strSQL + "FROM ACC_BILL_TRAN ";
                    strSQL = strSQL + "GROUP BY STOCKITEM_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_TRAN_PUR_INWARD_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_TRAN_PUR_INWARD_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_TRAN_PUR_INWARD_QRY AS ";
                    strSQL = strSQL + "SELECT STOCKITEM_NAME, ISNULL(SUM(INWARD_QUANTITY), 0) AS PUR_QUANTITY, ISNULL(SUM(INWARD_AMOUNT), 0) AS PUR_AMOUNT ";
                    strSQL = strSQL + "FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE (INV_VOUCHER_TYPE <> 23) AND (INV_VOUCHER_TYPE = 33) ";
                    strSQL = strSQL + "GROUP BY STOCKITEM_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AGST_REF_NO_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[AGST_REF_NO_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW AGST_REF_NO_VIEW AS ";
                    strSQL = strSQL + "SELECT ACC_VOUCHER_JOIN.VOUCHER_JOIN_PRIMARY_REF,substring(VOUCHER_JOIN_FOREIGN_REF,7,30) VOUCHER_JOIN_FOREIGN_REF ,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE ";
                    strSQL = strSQL + "FROM ACC_VOUCHER_JOIN,ACC_COMPANY_VOUCHER where  ACC_COMPANY_VOUCHER.COMP_REF_NO =ACC_VOUCHER_JOIN.VOUCHER_JOIN_FOREIGN_REF ";
                    strSQL = strSQL + "union all ";
                    strSQL = strSQL + "SELECT VOUCHER_JOIN_PRIMARY_REF, substring(CLASS_NAME,7,30) VOUCHER_JOIN_FOREIGN_REF, null COMP_VOUCHER_DATE FROM ACC_VOUCHER_JOIN_CLASS  ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCKITEM_CLOSING_MFG]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCKITEM_CLOSING_MFG] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW INV_STOCKITEM_CLOSING_MFG AS ";
                    strSQL = strSQL + "SELECT STOCKITEM_NAME,SUM(INV_TRAN_QUANTITY) AS STOCKITEM_CLOSING_BALANCE ";
                    strSQL = strSQL + "From INV_TRAN WHERE GODOWNS_NAME='Main Location' GROUP BY STOCKITEM_NAME  ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_Z_D_A]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_Z_D_A] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGER_Z_D_A AS ";
                    strSQL = strSQL + "SELECT  l.BRANCH_ID,g.GR_PARENT AS ZONE, g.GR_NAME AS DIVISION, l.LEDGER_PARENT_GROUP AS AREA,  ";
                    strSQL = strSQL + "l.LEDGER_NAME, l.TERITORRY_CODE, l.TERRITORRY_NAME,l.LEDGER_NAME_MERZE,g.GR_PARENT_POSITION,l.LEDGER_STATUS,g.GR_MOBILE_NO,l.HALT_MPO FROM  ";
                    strSQL=strSQL +"ACC_LEDGERGROUP AS g INNER JOIN ACC_LEDGERGROUP_CATEGORY_VIEW AS v ON g.GR_NAME = v.GR_PARENT INNER JOIN ACC_LEDGER AS l ON v.GR_NAME = l.LEDGER_PARENT_GROUP  ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_LIST_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_LIST_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE view ACC_LEDGER_LIST_VIEW as ";
                    strSQL = strSQL + "SELECT ACC_LEDGER.LEDGER_NAME, INV_SALESREPSENTIVE.MRR_NO, ACC_LEDGER.LEDGER_GROUP, ACC_LEDGER.LEDGER_OPENING_BALANCE, ACC_LEDGER.LEDGER_SERIAL, ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "FROM ACC_LEDGER LEFT OUTER JOIN ";
                    strSQL = strSQL + "INV_SALESREPSENTIVE ON ACC_LEDGER.LEDGER_NAME = INV_SALESREPSENTIVE.LEDGER_NAME ";
                    strSQL = strSQL + "GROUP BY ACC_LEDGER.LEDGER_NAME, INV_SALESREPSENTIVE.MRR_NO, ACC_LEDGER.LEDGER_GROUP, ACC_LEDGER.LEDGER_OPENING_BALANCE, ACC_LEDGER.LEDGER_SERIAL, ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_PARENT_GROUP";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_CATEGORY_CUST_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_CATEGORY_CUST_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE view ACC_LEDGER_CATEGORY_CUST_VIEW as ";
                    strSQL = strSQL + "SELECT ACC_LEDGER_LIST_VIEW.LEDGER_NAME, ACC_LEDGER_LIST_VIEW.MRR_NO, ACC_LEDGER.LEDGER_GROUP_NAME ";
                    strSQL = strSQL + "FROM ACC_LEDGER_LIST_VIEW INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER ON ACC_LEDGER_LIST_VIEW.MRR_NO = ACC_LEDGER.LEDGER_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[STOCK_STATEMENT_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[STOCK_STATEMENT_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW STOCK_STATEMENT_VIEW AS  ";
                    strSQL = strSQL + "select  t.BRANCH_ID,t.GODOWNS_NAME,s.STOCKGROUP_NAME,s.STOCKITEM_NAME,s.STOCKITEM_ALIAS ITEM_CODE, s.STOCKITEM_BASEUNITS,(isnull(sum(t.INV_TRAN_QUANTITY),0)) as QNTY   ";
                    strSQL = strSQL + "from INV_STOCKITEM s,INV_TRAN t where s.STOCKITEM_NAME =t.STOCKITEM_NAME  ";
                    strSQL = strSQL + "and t.INV_VOUCHER_TYPE not in (15) and s.STOCKITEM_STATUS =0  ";
                    strSQL = strSQL + "group by t.BRANCH_ID,t.GODOWNS_NAME,s.STOCKGROUP_NAME,s.STOCKITEM_NAME,s.STOCKITEM_ALIAS,s.STOCKITEM_BASEUNITS  ";
                    strSQL = strSQL + "union all  ";
                    strSQL = strSQL + "select t.BRANCH_ID,t.GODOWNS_NAME,s.STOCKGROUP_NAME,s.STOCKITEM_NAME,s.STOCKITEM_ALIAS,s.STOCKITEM_BASEUNITS,isnull(sum(t.BILL_QUANTITY+t.BILL_QUANTITY_BONUS ),0)*-1 as QNTY   ";
                    strSQL = strSQL + "from INV_STOCKITEM s,ACC_BILL_TRAN t where s.STOCKITEM_NAME =t.STOCKITEM_NAME  ";
                    strSQL = strSQL + "and t.COMP_VOUCHER_TYPE =16 and s.STOCKITEM_STATUS =0  ";
                    strSQL = strSQL + "group by t.BRANCH_ID,t.GODOWNS_NAME,s.STOCKGROUP_NAME,s.STOCKITEM_NAME,s.STOCKITEM_ALIAS,s.STOCKITEM_BASEUNITS  ";
                    strSQL = strSQL + "union all  ";
                    strSQL = strSQL + "select t.BRANCH_ID,t.GODOWNS_NAME,s.STOCKGROUP_NAME,s.STOCKITEM_NAME,s.STOCKITEM_ALIAS,s.STOCKITEM_BASEUNITS, ( isnull(sum(t.INV_TRAN_QUANTITY),0)) as QNTY   ";
                    strSQL = strSQL + "from INV_STOCKITEM s,INV_TRAN t,ACC_COMPANY_VOUCHER c where s.STOCKITEM_NAME =t.STOCKITEM_NAME   ";
                    strSQL = strSQL + "AND  c.COMP_REF_NO=t.INV_REF_NO  ";
                    strSQL = strSQL + "AND c.SAMPLE_STATUS=1  and s.STOCKITEM_STATUS =0 ";
                    strSQL = strSQL + "group by t.BRANCH_ID,t.GODOWNS_NAME,s.STOCKGROUP_NAME,s.STOCKITEM_NAME,s.STOCKITEM_ALIAS,s.STOCKITEM_BASEUNITS  ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VIEW_MPOWISE_SALES_COLLECTION]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[VIEW_MPOWISE_SALES_COLLECTION] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW VIEW_MPOWISE_SALES_COLLECTION AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER_Z_D_A.ZONE, ACC_LEDGER_Z_D_A.DIVISION, ACC_LEDGER_Z_D_A.AREA, ACC_LEDGER.LEDGER_NAME, ACC_LEDGER.LEDGER_NAME_MERZE, FORMAT(ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ";
                    strSQL = strSQL + "'MMyyyy') monthno, UPPER(ACC_COMPANY_VOUCHER.COMP_VOUCHER_MONTH_ID) COMP_VOUCHER_MONTH_ID, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ";
                    strSQL = strSQL + "ISNULL(abs(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT - VOUCHER_CREDIT_AMOUNT)), 0) SALESAMNT, 0 RECEIPT,ACC_LEDGER.LEDGER_STATUS,ACC_LEDGER.BRANCH_ID  ";
                    strSQL = strSQL + "FROM ACC_LEDGER, ACC_VOUCHER, ACC_COMPANY_VOUCHER, ACC_LEDGER_Z_D_A ";
                    strSQL = strSQL + "WHERE ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_VOUCHER.COMP_REF_NO AND ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE = ACC_LEDGER.LEDGER_NAME_MERZE AND  ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_NAME = ACC_VOUCHER.LEDGER_NAME AND  ";
                    strSQL = strSQL + "ACC_VOUCHER.COMP_VOUCHER_TYPE = 16 ";
                    /*AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE BETWEEN CONVERT(DATETIME,'01-01-2018',103) AND CONVERT(DATETIME,'04-07-2019',103)*/
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE, ACC_LEDGER_Z_D_A.DIVISION, ";
                    strSQL = strSQL + " ACC_LEDGER_Z_D_A.AREA, ACC_LEDGER.LEDGER_NAME_MERZE, FORMAT(ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, 'MMyyyy'), ACC_COMPANY_VOUCHER.COMP_VOUCHER_MONTH_ID, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ACC_LEDGER.LEDGER_NAME,ACC_LEDGER.LEDGER_STATUS,ACC_LEDGER.BRANCH_ID   ";
                    /*ORDER BY LEDGER_NAME_MERZE,FORMAT(ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE,'MMyyyy')*/
                    strSQL = strSQL + "UNION ALL ";
                    strSQL = strSQL + "SELECT ACC_LEDGER_Z_D_A.ZONE, ACC_LEDGER_Z_D_A.DIVISION, ACC_LEDGER_Z_D_A.AREA, ACC_LEDGER.LEDGER_NAME, ACC_LEDGER.LEDGER_NAME_MERZE, FORMAT(ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ";
                    strSQL = strSQL + "'MMyyyy') monthno, UPPER(ACC_COMPANY_VOUCHER.COMP_VOUCHER_MONTH_ID) COMP_VOUCHER_MONTH_ID, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, 0 SALESAMNT, ";
                    strSQL = strSQL + "ISNULL(abs(SUM(ACC_VOUCHER.VOUCHER_DEBIT_AMOUNT - VOUCHER_CREDIT_AMOUNT)), 0) RECEIPT,ACC_LEDGER.LEDGER_STATUS,ACC_LEDGER.BRANCH_ID   ";
                    strSQL = strSQL + "FROM ACC_LEDGER, ACC_VOUCHER, ACC_COMPANY_VOUCHER, ACC_LEDGER_Z_D_A ";
                    strSQL = strSQL + "WHERE ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_VOUCHER.COMP_REF_NO AND ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE = ACC_LEDGER.LEDGER_NAME_MERZE AND ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_NAME = ACC_VOUCHER.LEDGER_NAME AND ACC_VOUCHER.COMP_VOUCHER_TYPE = 1  ";
                    strSQL = strSQL + "GROUP BY ACC_LEDGER_Z_D_A.ZONE, ACC_LEDGER_Z_D_A.DIVISION, ACC_LEDGER_Z_D_A.AREA, ACC_LEDGER.LEDGER_NAME_MERZE, FORMAT(ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, 'MMyyyy'), ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_MONTH_ID, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ACC_LEDGER.LEDGER_NAME,ACC_LEDGER.LEDGER_STATUS,ACC_LEDGER.BRANCH_ID    ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_PRODUCTION_ClASS_POWER]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_PRODUCTION_ClASS_POWER] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW INV_PRODUCTION_ClASS_POWER as select * from INV_STOCK_PACK_SIZE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_TRAN_QRY2]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_TRAN_QRY2] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW INV_TRAN_QRY2 as select * from INV_STOCK_PACK_SIZE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Consumption]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[Consumption] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW Consumption as select * from INV_STOCK_PACK_SIZE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_PRODUCTION_MVC]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_PRODUCTION_MVC] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE view INV_PRODUCTION_MVC as select * from INV_STOCK_PACK_SIZE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateInvProductStatementView()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_PRODUCT_STATEMENT_PRODUCTION_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_PRODUCT_STATEMENT_PRODUCTION_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_PRODUCT_STATEMENT_PRODUCTION_VIEW AS ";
                    strSQL = strSQL + "SELECT STOCKGROUP_NAME, SUM(INWARD_VALUE) * - 1 AS Production, SUM(OUTWARD_VALUE) AS Expenses ";
                    strSQL = strSQL + "FROM INV_PRODUCT_STATEMENT_PRODUCTION ";
                    strSQL = strSQL + "GROUP BY STOCKGROUP_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateInvFinishedItemStatementView()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_FINISHED_ITEM_STATEMENT_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_FINISHED_ITEM_STATEMENT_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_FINISHED_ITEM_STATEMENT_VIEW AS ";
                    strSQL = strSQL + "SELECT STOCKGROUP_NAME, ITEM_NAME, SUM(OPENING_VALUE) AS OPENING_VALUE, SUM(INWARD_VALUE) AS INWARD_VALUE, SUM(SALES_VALUE) AS SALES_VALUE, SUM(COMMISSION_VALUE) AS COMMISSION_VALUE, ";
                    strSQL = strSQL + "SUM(BONUS_VALUE) AS BONUS_VALUE, SUM(BROKEN_VALUE) AS BROKEN_VALUE, SUM(STAFF_VALUE) AS STAFF_VALUE, SUM(STAFF_COMMISSION) AS STAFF_COMMISSION, SUM(SAMPLE_VALUE) ";
                    strSQL = strSQL + "AS SAMPLE_VALUE ";
                    strSQL = strSQL + "FROM INV_FINISHED_ITEM_STATEMENT ";
                    strSQL = strSQL + "GROUP BY STOCKGROUP_NAME, ITEM_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateStockPackSizeView ()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCK_PACK_SIZE_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCK_PACK_SIZE_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_STOCK_PACK_SIZE_VIEW AS ";
                    strSQL = strSQL + "SELECT STOCKGROUP_NAME, PACK_SIZE_NAME, SUM(OPENING_QTY) AS OPENING_QTY, SUM(RECIVED_QTY) AS RECIVED_QTY, SUM(CONVERT_QTY) AS CONVERT_QTY ";
                    strSQL = strSQL + "FROM  INV_STOCK_PACK_SIZE ";
                    strSQL = strSQL + "GROUP BY STOCKGROUP_NAME, PACK_SIZE_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateStockStatementView()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCK_STATEMENT_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCK_STATEMENT_VIEW] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_STOCK_STATEMENT_VIEW AS ";
                    strSQL = strSQL + "SELECT STOCKGROUP_NAME, ITEM_NAME, STOCKITEM_ALIAS, SUM(OPENING_QTY) AS OPENING_QTY, SUM(PRODUCTION_QTY) AS PRODUCTION_QTY, SUM(SALES_QTY) AS SALES_QTY, SUM(SAMPLE_QTY) AS SAMPLE_QTY, ";
                    strSQL = strSQL + "SUM(RETURN_QTY) AS RETURN_QTY, SUM(CONVERT_QTY) AS CONVERT_QTY, SUM(PHY_STOCK_QTY) AS PHY_STOCK_QTY, SUM(BROKEN_QTY) AS BROKEN_QTY, SUM(STOCK_TRANSFER_QTY) AS STOCK_TRANSFER_QTY, ";
                    strSQL = strSQL + "SUM(STOCK_TRANSFER_IN_QTY) AS STOCK_TRANSFER_IN_QTY, SUM(CONSUMPTION_QTY) AS CONSUMPTION_QTY ";
                    strSQL = strSQL + "FROM INV_STOCK_STATEMENT ";
                    strSQL = strSQL + "GROUP BY STOCKGROUP_NAME, ITEM_NAME, STOCKITEM_ALIAS ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }

        private static string CreateStockInvManufactureQry()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_MANUFACTURE_ITEM_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_MANUFACTURE_ITEM_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_MANUFACTURE_ITEM_QRY AS ";
                    strSQL = strSQL + "SELECT s.STOCKGROUP_NAME, s.STOCKITEM_NAME, s.STOCKITEM_ALIAS, SUM(C.STOCKITEM_CLOSING_BALANCE) AS STOCKITEM_CLOSING_BALANCE, g.STOCKGROUP_PRIMARY_TYPE, s.STOCKITEM_BASEUNITS ";
                    strSQL = strSQL + ",C.GODOWNS_NAME,g.STOCKGROUP_PRIMARY,s.STOCKITEM_STATUS FROM INV_STOCKITEM_CLOSING AS C INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM AS s ON C.STOCKITEM_NAME = s.STOCKITEM_NAME INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKGROUP AS g ON s.STOCKGROUP_NAME = g.STOCKGROUP_NAME ";
                    strSQL = strSQL + "GROUP BY s.STOCKGROUP_NAME, s.STOCKITEM_NAME, s.STOCKITEM_ALIAS, g.STOCKGROUP_PRIMARY_TYPE, s.STOCKITEM_BASEUNITS,C.GODOWNS_NAME,g.STOCKGROUP_PRIMARY,s.STOCKITEM_STATUS ";
                    strSQL = strSQL + "HAVING (g.STOCKGROUP_PRIMARY_TYPE IN (1, 2, 3)) AND (s.STOCKITEM_STATUS = 0)";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }



        private static string CreateStockInvTranDate()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_TRAN_DATE_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_TRAN_DATE_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_TRAN_DATE_QRY AS ";
                    strSQL = strSQL + "SELECT TOP 100 PERCENT INV_DATE, STOCKITEM_NAME ";
                    strSQL = strSQL + "FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE (INV_TRAN_RUNNING_QTY = 0) ";
                    strSQL = strSQL + "ORDER BY INV_DATE DESC ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateStockInvBillTranDate()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_BILL_TRAN_DATE_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_BILL_TRAN_DATE_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_BILL_TRAN_DATE_QRY AS ";
                    strSQL = strSQL + "SELECT TOP 100 PERCENT COMP_VOUCHER_DATE, BILL_RATE, BILL_UOM, BILL_PER, COMP_VOUCHER_TYPE, STOCKITEM_NAME ";
                    strSQL = strSQL + "FROM ACC_BILL_TRAN ";
                    strSQL = strSQL + "ORDER BY COMP_VOUCHER_DATE DESC ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateInvQtyOnOrder()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_QTY_ON_ORDER]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_QTY_ON_ORDER] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_QTY_ON_ORDER AS ";
                    strSQL = strSQL + "SELECT ACC_BILL_TRAN.STOCKITEM_NAME, SUM(ACC_BILL_TRAN_PENDING.BALANCE_QUANTITY) AS BALANCE_QTY ";
                    strSQL = strSQL + "FROM ACC_BILL_TRAN_PENDING INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN ON ACC_BILL_TRAN_PENDING.BILL_TRAN_KEY = ACC_BILL_TRAN.BILL_TRAN_KEY ";
                    strSQL = strSQL + "GROUP BY ACC_BILL_TRAN.STOCKITEM_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateAccGroupCompBillTranQry()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_GROUP_COMP_BILL_TRAN_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_GROUP_COMP_BILL_TRAN_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_GROUP_COMP_BILL_TRAN_QRY AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER_TO_GROUP.GR_NAME,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE, ";
                    strSQL = strSQL + "SUBSTRING(ACC_COMPANY_VOUCHER.COMP_REF_NO,7, 30) AS COMP_REF_NO, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.LEDGER_NAME, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DUE_DATE,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION, ACC_BILL_TRAN.STOCKITEM_NAME, ACC_BILL_TRAN.BILL_UOM,";
                    strSQL = strSQL + "ACC_BILL_TRAN.BILL_QUANTITY, ACC_BILL_TRAN.BILL_RATE, ACC_BILL_TRAN.BILL_NET_AMOUNT,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE, ACC_BILL_TRAN.GODOWNS_NAME, ACC_COMPANY_VOUCHER.COMP_VOUCHER_STATUS,";
                    strSQL = strSQL + "ACC_BILL_TRAN.VOUCHER_CURRENCY_SYMBOL, ACC_BILL_TRAN.VOUCHER_FC_AMOUNT, ACC_COMPANY_VOUCHER.BRANCH_ID,";
                    strSQL = strSQL + "ACC_BILL_TRAN.FC_CONVERSION_RATE,ACC_BILL_TRAN.BILL_PER ";
                    strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_TO_GROUP ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER_TO_GROUP.LEDGER_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateInvStickClosingGroupwiseQry()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCK_CLOSING_GROUPWISE_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCK_CLOSING_GROUPWISE_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_STOCK_CLOSING_GROUPWISE_QRY AS ";

                    //'    strSQL = strSQL + "SELECT INV_STOCKITEM_CLOSING.STOCKITEM_NAME, INV_STOCKITEM_CLOSING.GODOWNS_NAME, ISNULL(SUM(INV_TRAN.INV_TRAN_QUANTITY), 0)"
                    //'    strSQL = strSQL + "AS STOCKITEM_CLOSING_BALANCE, INV_STOCKITEM.STOCKITEM_ALIAS, INV_STOCKITEM.STOCKITEM_BASEUNITS,"
                    //'    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_PRIMARY, INV_STOCKGROUP.STOCKGROUP_SEQUENCES, INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE,"
                    //'    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_SECONDARY_TYPE , INV_STOCKITEM.STOCKITEM_STATUS "
                    //'    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING INNER JOIN "
                    //'    strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKITEM_CLOSING.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN "
                    //'    strSQL = strSQL + "INV_STOCKGROUP ON INV_STOCKITEM.STOCKGROUP_NAME = INV_STOCKGROUP.STOCKGROUP_NAME LEFT OUTER JOIN "
                    //'    strSQL = strSQL + "INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME AND "
                    //'    strSQL = strSQL + "INV_STOCKITEM_CLOSING.GODOWNS_NAME = INV_TRAN.GODOWNS_NAME "
                    //'    strSQL = strSQL + "Where (INV_STOCKITEM.STOCKITEM_STATUS = 0) "
                    //'    strSQL = strSQL + "GROUP BY INV_STOCKITEM_CLOSING.STOCKITEM_NAME, INV_STOCKITEM_CLOSING.GODOWNS_NAME, INV_STOCKITEM.STOCKITEM_ALIAS, "
                    //'    strSQL = strSQL + "INV_STOCKITEM.STOCKITEM_BASEUNITS, INV_STOCKITEM.STOCKITEM_STATUS, INV_STOCKGROUP.STOCKGROUP_PRIMARY, "
                    //'    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_SEQUENCES, INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE, "
                    //'    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_SECONDARY_TYPE "
                    strSQL = strSQL + "SELECT INV_STOCKITEM_CLOSING.GODOWNS_NAME, INV_STOCKITEM_CLOSING.STOCKITEM_NAME, INV_STOCKITEM.STOCKITEM_BASEUNITS,";
                    strSQL = strSQL + "INV_STOCKITEM.STOCKITEM_STATUS, INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE, INV_STOCKITEM.STOCKITEM_ALIAS,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_PRIMARY, INV_STOCKGROUP.STOCKGROUP_SEQUENCES, INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE, ";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_SECONDARY_TYPE ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKITEM_CLOSING.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKGROUP ON INV_STOCKITEM.STOCKITEM_PRIMARY_GROUP = INV_STOCKGROUP.STOCKGROUP_PRIMARY ";
                    strSQL = strSQL + "Where (INV_STOCKITEM.STOCKITEM_STATUS = 0) ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateAgingYear()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_BILL_WISE_YEAR_1]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_BILL_WISE_YEAR_1]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_BILL_WISE_YEAR_1 ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT AGAINST_VOUCHER_NO,SUM(BILL_WISE_AMOUNT) AS AMOUNT ";
                    strSQL = strSQL + "FROM ACC_BILL_WISE ";
                    strSQL = strSQL + "GROUP BY AGAINST_VOUCHER_NO ";
                    strSQL = strSQL + "HAVING (SUM(BILL_WISE_AMOUNT) <> 0) ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_BILL_WISE_YEAR_2]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_BILL_WISE_YEAR_2]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_BILL_WISE_YEAR_2 ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER.LEDGER_NAME, DATEPART(YYYY, dbo.ACC_BILL_WISE.COMP_VOUCHER_DATE) AS TYEAR, ";
                    strSQL = strSQL + "ACC_BILL_WISE_YEAR_1.AMOUNT * - 1 AS AMOUNT ";
                    strSQL = strSQL + "FROM ACC_BILL_WISE INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER ON ACC_BILL_WISE.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_WISE_YEAR_1 ON ACC_BILL_WISE.AGAINST_VOUCHER_NO = ACC_BILL_WISE_YEAR_1.AGAINST_VOUCHER_NO ";
                    strSQL = strSQL + "WHERE (ACC_BILL_WISE.BILL_WISE_TOBY = 'Dr') ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateProcessQryAson()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from sysobjects where id = object_id(N'[dbo].[ACC_BILL_TRAN_PENDING_ASON_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_BILL_TRAN_PENDING_ASON_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_BILL_TRAN_PENDING_ASON_QRY AS ";
                    strSQL = strSQL + "SELECT ACC_BILL_TRAN.BILL_TRAN_KEY, ACC_BILL_TRAN.COMP_REF_NO, ACC_BILL_TRAN.COMP_VOUCHER_TYPE,";
                    strSQL = strSQL + "ACC_BILL_TRAN.COMP_VOUCHER_DATE, ACC_BILL_TRAN.BILL_TRAN_POSITION, ACC_BILL_TRAN.STOCKITEM_NAME,";
                    strSQL = strSQL + "ACC_BILL_TRAN.GODOWNS_NAME, ACC_BILL_TRAN.BILL_UOM, ACC_BILL_TRAN.BILL_RATE, ACC_BILL_TRAN.BILL_QUANTITY,";
                    strSQL = strSQL + "ACC_BILL_TRAN.INV_LOG_NO, ACC_COMPANY_VOUCHER.COMP_VOUCHER_DUE_DATE, ACC_COMPANY_VOUCHER.LEDGER_NAME,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.BRANCH_ID, ACC_BILL_TRAN.BILL_PER, ACC_BILL_TRAN_PENDING.BALANCE_QUANTITY,";
                    strSQL = strSQL + "ACC_BILL_TRAN_PENDING.BALANCE_QUANTITY * ACC_BILL_TRAN.BILL_RATE AS BILL_NET_AMOUNT ";
                    strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN ON ACC_COMPANY_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN.COMP_REF_NO INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN_PENDING ON ACC_BILL_TRAN.BILL_TRAN_KEY = ACC_BILL_TRAN_PENDING.BILL_TRAN_KEY ";
                    strSQL = strSQL + "WHERE (ACC_BILL_TRAN.COMP_VOUCHER_TYPE > 0) ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }

        private static string CreateInvEffectView()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_EFFECT_PAY_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_EFFECT_PAY_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW INV_EFFECT_PAY_VIEW AS ";
                    strSQL = strSQL + "SELECT INV_REF_NO + REPLICATE('0',4-DATALENGTH(CONVERT(VARCHAR,INV_CURR_ROW))) + CONVERT(VARCHAR, INV_CURR_ROW) AS INV_REF_NO_KEY, INV_LOG_NO, INV_AMOUNT ";
                    strSQL = strSQL + "FROM INV_EFFECT_PAYMENT ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateVoucherInvEffect()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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


                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_VOUCHER_INV_EFFECT_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_VOUCHER_INV_EFFECT_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_VOUCHER_INV_EFFECT_VIEW AS ";
                    strSQL = strSQL + "SELECT ACC_VOUCHER.LEDGER_NAME,INV_EFFECT_PAY_VIEW.INV_LOG_NO, INV_EFFECT_PAY_VIEW.INV_AMOUNT,ACC_VOUCHER.COMP_VOUCHER_DATE ";
                    strSQL = strSQL + "FROM ACC_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "INV_EFFECT_PAY_VIEW ON ACC_VOUCHER.VOUCHER_REF_KEY = INV_EFFECT_PAY_VIEW.INV_REF_NO_KEY ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        //' private static string CreateInvBatchTranView()
        //'    Dim strSQL As String
        //'    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_BATCH_TRAN_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) "
        //'    strSQL = strSQL + "drop view [dbo].[INV_BATCH_TRAN_QRY]"
        //'    gcnMain.Execute strSQL
        //'
        //'    strSQL = "CREATE VIEW INV_BATCH_TRAN_QRY AS "
        //'    strSQL = strSQL + "SELECT GODOWNS_NAME,STOCKITEM_NAME,INV_LOG_NO,SUM(BATCH_TRAN_QUANTITY) AS QTY "
        //'    strSQL = strSQL + "FROM INV_BATCH_TRAN "
        //'    strSQL = strSQL + "GROUP BY GODOWNS_NAME,STOCKITEM_NAME,INV_LOG_NO"
        //'    gcnMain.Execute strSQL
        //'End Sub
        private static string CreateInvMasterView()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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


                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_MASTER_DETAILS_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_MASTER_DETAILS_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = " CREATE VIEW INV_MASTER_DETAILS_VIEW AS ";
                    strSQL = strSQL + " SELECT INV_MASTER.INV_REF_NO, INV_MASTER.INV_DATE, ";
                    strSQL = strSQL + " INV_MASTER.INWORD_QUANTITY, INV_MASTER.LEDGER_NAME, INV_MASTER.INV_AMOUNT, ";
                    strSQL = strSQL + " ACC_VOUCHER_TYPE.VOUCHER_TYPE_NAME,INV_MASTER.INV_VOUCHER_TYPE ";
                    strSQL = strSQL + " FROM INV_MASTER INNER JOIN ";
                    strSQL = strSQL + " ACC_VOUCHER_TYPE ON ";
                    strSQL = strSQL + " INV_MASTER.INV_VOUCHER_TYPE = ACC_VOUCHER_TYPE.VOUCHER_TYPE_VALUE";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateInvManufacAndAccount()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_VOUCHER_INV_TRAN]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_VOUCHER_INV_TRAN]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGER_VOUCHER_INV_TRAN AS ";


                    //'    strSQL = strSQL + "ACC_LEDGER_VOUCHER.COMP_REF_NO,ACC_LEDGER_VOUCHER.COMP_VOUCHER_DATE, "
                    //'    strSQL = strSQL + "ACC_LEDGER_VOUCHER.LEDGER_GROUP, INV_TRAN.INV_TRAN_AMOUNT,"
                    //'    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE , INV_STOCKGROUP.STOCKGROUP_SECONDARY_TYPE "
                    //'    strSQL = strSQL + "FROM ACC_LEDGER_VOUCHER INNER JOIN "
                    //'    strSQL = strSQL + "ACC_BILL_TRAN_PROCESS ON ACC_LEDGER_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN_PROCESS.COMP_REF_NO INNER JOIN "
                    //'    strSQL = strSQL + "INV_TRAN INNER JOIN INV_STOCKITEM ON INV_TRAN.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN "
                    //'    strSQL = strSQL + "INV_STOCKGROUP ON INV_STOCKITEM.STOCKITEM_PRIMARY_GROUP = INV_STOCKGROUP.STOCKGROUP_PRIMARY ON "
                    //'    strSQL = strSQL + "ACC_BILL_TRAN_PROCESS.AGST_REF_NO_KEY = INV_TRAN.INV_TRAN_KEY "

                    strSQL = strSQL + "SELECT ACC_LEDGER_VOUCHER.BRANCH_ID,ACC_LEDGER_VOUCHER.COMP_REF_NO,";
                    strSQL = strSQL + "ACC_LEDGER_VOUCHER.COMP_VOUCHER_DATE,ACC_LEDGER_VOUCHER.LEDGER_GROUP,INV_TRAN.INV_TRAN_AMOUNT,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE,INV_STOCKGROUP.STOCKGROUP_SECONDARY_TYPE,INV_TRAN.INV_LOG_NO ";
                    strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                    strSQL = strSQL + "INV_TRAN INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON INV_TRAN.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN_PROCESS ON ACC_LEDGER_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN_PROCESS.COMP_REF_NO ON ";
                    strSQL = strSQL + "INV_TRAN.INV_TRAN_KEY = ACC_BILL_TRAN_PROCESS.AGST_REF_NO_KEY ON ";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME ";
                    strSQL = strSQL + "WHERE ACC_BILL_TRAN_PROCESS.BILL_QUANTITY > 0  ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateInvManufacAndAccountTwo()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_VOUCHER_INV_TRAN_TWO]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_VOUCHER_INV_TRAN_TWO]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGER_VOUCHER_INV_TRAN_TWO AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER_VOUCHER.BRANCH_ID,ACC_LEDGER_VOUCHER.COMP_REF_NO,";
                    strSQL = strSQL + "ACC_LEDGER_VOUCHER.COMP_VOUCHER_DATE,ACC_LEDGER_VOUCHER.LEDGER_GROUP, INV_TRAN.INV_TRAN_AMOUNT,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE,INV_STOCKGROUP.STOCKGROUP_SECONDARY_TYPE,INV_TRAN.INV_LOG_NO ";
                    strSQL = strSQL + "FROM ACC_LEDGER_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "INV_TRAN INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON INV_TRAN.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKGROUP ON INV_STOCKITEM.STOCKGROUP_NAME = INV_STOCKGROUP.STOCKGROUP_NAME ON ";
                    strSQL = strSQL + "ACC_LEDGER_VOUCHER.COMP_REF_NO = INV_TRAN.INV_REF_NO ";
                    strSQL = strSQL + "WHERE (ACC_LEDGER_VOUCHER.COMP_VOUCHER_TYPE < 9) ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateInvManufacAndAccountThree()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_LEDGER_VOUCHER_INV_TRAN_THREE]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_LEDGER_VOUCHER_INV_TRAN_THREE]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW ACC_LEDGER_VOUCHER_INV_TRAN_THREE AS ";
                    strSQL = strSQL + "SELECT ACC_LEDGER_VOUCHER.BRANCH_ID,ACC_LEDGER_VOUCHER.COMP_VOUCHER_DATE,INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_SECONDARY_TYPE,ACC_LEDGER_VOUCHER.LEDGER_GROUP,";
                    strSQL = strSQL + "ACC_BILL_TRAN_PROCESS.COMP_VOUCHER_TYPE,INV_TRAN.INV_TRAN_AMOUNT,ACC_BILL_TRAN_PROCESS.BILL_NET_AMOUNT ";
                    strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                    strSQL = strSQL + "INV_TRAN INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON INV_TRAN.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN_PROCESS ON ACC_LEDGER_VOUCHER.COMP_REF_NO = ACC_BILL_TRAN_PROCESS.COMP_REF_NO ON ";
                    strSQL = strSQL + "INV_TRAN.INV_TRAN_KEY = ACC_BILL_TRAN_PROCESS.AGST_REF_NO_KEY ON ";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }

        private static string CreateInvOpeningTranLocQry()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from sysobjects where id = object_id(N'[dbo].[INV_TRAN_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_TRAN_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_TRAN_QRY AS ";
                    strSQL = strSQL + "SELECT GODOWNS_NAME,STOCKITEM_NAME,SUM(INWARD_QUANTITY) AS INWARD_QUANTITY, SUM(INWARD_AMOUNT) AS INWARD_AMOUNT,";
                    strSQL = strSQL + "SUM(OUTWARD_QUANTITY) AS OUTWARD_QUANTITY, SUM(OUTWARD_SALES_AMOUNT) AS OUTWARD_SALES_AMOUNT,";
                    strSQL = strSQL + "SUM(OUTWARD_COST_AMOUNT) As OUTWARD_COST_AMOUNT ";
                    strSQL = strSQL + "FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE (INV_DATE BETWEEN CONVERT(datetime, '01-03-2005', 103) AND CONVERT(datetime, '01-04-2005', 103)) ";
                    strSQL = strSQL + "GROUP BY STOCKITEM_NAME,GODOWNS_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_OPENING_TRAN_LOC_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_OPENING_TRAN_LOC_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW INV_OPENING_TRAN_LOC_QRY AS ";
                    strSQL = strSQL + "SELECT INV_STOCKITEM_CLOSING.GODOWNS_NAME, INV_STOCKITEM_CLOSING.STOCKITEM_NAME, ISNULL(INV_OPENING_QRY.INV_TRAN_AMOUNT, 0) ";
                    strSQL = strSQL + "AS INV_TRAN_AMOUNT, ISNULL(INV_OPENING_QRY.INV_TRAN_QUANTITY, 0) AS INV_TRAN_QUANTITY,";
                    strSQL = strSQL + "ISNULL(INV_TRAN_QRY.INWARD_QUANTITY, 0) AS INWARD_QUANTITY, ISNULL(INV_TRAN_QRY.INWARD_AMOUNT, 0) AS INWARD_AMOUNT,";
                    strSQL = strSQL + "ISNULL(INV_TRAN_QRY.OUTWARD_SALES_AMOUNT, 0) AS OUTWARD_SALES_AMOUNT, ISNULL(INV_TRAN_QRY.OUTWARD_QUANTITY, 0) ";
                    strSQL = strSQL + "AS OUTWARD_QUANTITY, ISNULL(INV_TRAN_QRY.OUTWARD_COST_AMOUNT, 0) AS OUTWARD_COST_AMOUNT ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING LEFT OUTER JOIN ";
                    strSQL = strSQL + "INV_TRAN_QRY ON INV_STOCKITEM_CLOSING.GODOWNS_NAME = INV_TRAN_QRY.GODOWNS_NAME AND ";
                    strSQL = strSQL + "INV_STOCKITEM_CLOSING.STOCKITEM_NAME = INV_TRAN_QRY.STOCKITEM_NAME LEFT OUTER JOIN ";
                    strSQL = strSQL + "INV_OPENING_QRY ON INV_STOCKITEM_CLOSING.STOCKITEM_NAME = INV_OPENING_QRY.STOCKITEM_NAME AND ";
                    strSQL = strSQL + "INV_STOCKITEM_CLOSING.GODOWNS_NAME = INV_OPENING_QRY.GODOWNS_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateBatchQry()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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


                    strSQL = "IF EXISTS (SELECT * From sysobjects WHERE id = object_id(N'[dbo].[INV_BATCH_QRY]') AND OBJECTPROPERTY(id, N'IsView') = 1) DROP VIEW [dbo].[INV_BATCH_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW INV_BATCH_QRY AS ";
                    strSQL = strSQL + "SELECT INV_LOG_NO, SUM(INV_TRAN_QUANTITY) AS QTY, SUM(INV_TRAN_AMOUNT) AS AMOUNT,";
                    strSQL = strSQL + "STOCKITEM_NAME , INV_VOUCHER_TYPE,INV_DATE From INV_TRAN ";
                    strSQL = strSQL + "GROUP BY INV_LOG_NO, STOCKITEM_NAME, INV_VOUCHER_TYPE,INV_DATE ";
                    strSQL = strSQL + "Having (INV_LOG_NO Is Not Null) ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }


        private static string CreateViewZeroSales()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_SLOW_MOVE_ZERO_SALES_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_SLOW_MOVE_ZERO_SALES_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW INV_SLOW_MOVE_ZERO_SALES_QRY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT INV_STOCKITEM.STOCKITEM_NAME, INV_SLOW_MOVING_ITEM.QTY,INV_STOCKITEM.STOCKGROUP_NAME ";
                    strSQL = strSQL + "FROM INV_STOCKITEM LEFT OUTER JOIN ";
                    strSQL = strSQL + "INV_SLOW_MOVING_ITEM ON INV_STOCKITEM.STOCKITEM_NAME = INV_SLOW_MOVING_ITEM.STOCKITEM_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }

        private static string CreateStockLedView()  //'ACC_STOCK_LED_QRY
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCK_LEDGER_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCK_LEDGER_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_STOCK_LEDGER_QRY AS ";
                    strSQL = strSQL + "SELECT ";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_NAME, INV_STOCKITEM_TO_GROUP.STOCKITEM_NAME,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_CLOSING_BALANCE, INV_STOCKGROUP.STOCKGROUP_INWARDQUANTITY,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_OUTWARDQUANTITY,INV_STOCKGROUP.STOCKGROUP_OPENING_VALUE ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_TO_GROUP INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKGROUP ON INV_STOCKITEM_TO_GROUP.STOCKGROUP_NAME = INV_STOCKGROUP.STOCKGROUP_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateStockItemToGroupQry()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCKITEM_TO_GROUP_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCKITEM_TO_GROUP_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW INV_STOCKITEM_TO_GROUP_QRY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT INV_STOCKITEM_TO_GROUP.STOCKGROUP_NAME, INV_STOCKITEM_TO_GROUP.STOCKITEM_NAME,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_LEVEL ";
                    strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM_TO_GROUP ON ";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM_TO_GROUP.STOCKGROUP_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateInvOpeningQry()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from sysobjects where id = object_id(N'[dbo].[INV_OPENING_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_OPENING_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_OPENING_QRY AS ";
                    strSQL = strSQL + "SELECT STOCKITEM_NAME,GODOWNS_NAME,INV_TRAN_QUANTITY,INV_TRAN_AMOUNT ";
                    strSQL = strSQL + "FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE (INV_DATE < CONVERT(datetime, '01-01-1950', 103)) ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }

        private static string CreateInvTranQtyQry()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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


                    strSQL = "if exists (select * from sysobjects where id = object_id(N'[dbo].[INV_TRAN_QTY_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_TRAN_QTY_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW INV_TRAN_QTY_QRY AS ";
                    strSQL = strSQL + "SELECT STOCKITEM_NAME,GODOWNS_NAME,INV_TRAN_QUANTITY,INV_TRAN_AMOUNT ";
                    strSQL = strSQL + "FROM INV_TRAN ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }

        private static string CreateInvTranQry()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from sysobjects where id = object_id(N'[dbo].[INV_TRAN_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_TRAN_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_TRAN_QRY AS ";
                    strSQL = strSQL + "SELECT STOCKITEM_NAME,SUM(INWARD_QUANTITY) AS INWARD_QUANTITY, SUM(INWARD_AMOUNT) AS INWARD_AMOUNT,";
                    strSQL = strSQL + "SUM(OUTWARD_QUANTITY) AS OUTWARD_QUANTITY, SUM(OUTWARD_SALES_AMOUNT) AS OUTWARD_SALES_AMOUNT,";
                    strSQL = strSQL + "SUM(OUTWARD_COST_AMOUNT) As OUTWARD_COST_AMOUNT ";
                    strSQL = strSQL + "FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE (INV_DATE BETWEEN CONVERT(datetime, '01-03-2005', 103) AND CONVERT(datetime, '01-04-2005', 103)) ";
                    strSQL = strSQL + "GROUP BY STOCKITEM_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }

        private static string CreateInvOpeningTranQry()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from sysobjects where id = object_id(N'[dbo].[INV_OPENING_TRAN_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_OPENING_TRAN_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_OPENING_TRAN_QRY AS ";
                    strSQL = strSQL + "SELECT INV_OPENING_QRY.STOCKITEM_NAME,INV_OPENING_QRY.INV_TRAN_QUANTITY,";
                    strSQL = strSQL + "INV_OPENING_QRY.INV_TRAN_AMOUNT,ISNULL(INV_TRAN_QRY.INWARD_QUANTITY, 0) AS INWARD_QUANTITY,";
                    strSQL = strSQL + "ISNULL(INV_TRAN_QRY.INWARD_AMOUNT, 0) AS INWARD_AMOUNT, ISNULL(INV_TRAN_QRY.OUTWARD_QUANTITY, 0)";
                    strSQL = strSQL + "AS OUTWARD_QUANTITY,ISNULL(INV_TRAN_QRY.OUTWARD_SALES_AMOUNT, 0) AS OUTWARD_SALES_AMOUNT,";
                    strSQL = strSQL + "ISNULL(INV_TRAN_QRY.OUTWARD_COST_AMOUNT, 0) AS OUTWARD_COST_AMOUNT ";
                    strSQL = strSQL + "FROM INV_OPENING_QRY LEFT OUTER JOIN ";
                    strSQL = strSQL + "INV_TRAN_QRY ON INV_OPENING_QRY.STOCKITEM_NAME = INV_TRAN_QRY.STOCKITEM_NAME ";
                    cmd.CommandText = strSQL;
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
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_PRIMARY AS STOCKITEM_PRIMARY_GROUP,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE AS STOCKGROUPPRIMARY_TYPE,";
                    strSQL = strSQL + "INV_STOCKGROUP.STOCKGROUP_SECONDARY_TYPE AS STOCKGROUPSECONDARY_TYPE ";
                    strSQL = strSQL + "FROM INV_STOCKITEM INNER JOIN ";
                    strSQL = strSQL + "INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKGROUP ON INV_STOCKITEM.STOCKGROUP_NAME = INV_STOCKGROUP.STOCKGROUP_NAME ";
                    //'strSql = "CREATE VIEW INV_STOCK_QRY AS "
                    //'strSql = strSql + "SELECT INV_TRAN.*, INV_STOCKITEM.STOCKITEM_PRIMARY_GROUP AS STOCKITEM_PRIMARY_GROUP "
                    //'strSql = strSql + "FROM INV_STOCKITEM INNER JOIN "
                    //'strSql = strSql + "INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME "
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateInvSlowMovingStockQty()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_SLOW_MOVE_ZERO_SALES_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_SLOW_MOVE_ZERO_SALES_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_SLOW_MOVE_ZERO_SALES_QRY AS ";
                    strSQL = strSQL + "SELECT INV_STOCKITEM.STOCKITEM_NAME, INV_SLOW_MOVING_ITEM.QTY, INV_STOCKITEM.STOCKGROUP_NAME ";
                    strSQL = strSQL + "FROM INV_STOCKITEM LEFT OUTER JOIN ";
                    strSQL = strSQL + "INV_SLOW_MOVING_ITEM ON INV_STOCKITEM.STOCKITEM_NAME = INV_SLOW_MOVING_ITEM.STOCKITEM_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateViewInvNegativeQty()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_TRAN_NEGATIVE_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[INV_TRAN_NEGATIVE_QRY] ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "CREATE VIEW INV_TRAN_NEGATIVE_QRY ";
                    strSQL = strSQL + "AS ";
                    strSQL = strSQL + "SELECT STOCKITEM_NAME, SUM(INV_TRAN_QUANTITY) AS INV_TRAN_QUANTITY ";
                    strSQL = strSQL + "From INV_TRAN ";
                    strSQL = strSQL + "GROUP BY STOCKITEM_NAME ";
                    strSQL = strSQL + "Having (Sum(INV_TRAN_QUANTITY) < 0) ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string StockTransferReportQry()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCK_TRANSFER_TO]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCK_TRANSFER_TO]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_STOCK_TRANSFER_TO AS ";
                    strSQL = strSQL + "SELECT INV_DATE,INV_REF_NO,GODOWNS_NAME,STOCKITEM_NAME,INV_TRAN_QUANTITY,INV_TRAN_AMOUNT ";
                    strSQL = strSQL + "FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE (INV_VOUCHER_TYPE = 23) AND (INV_INOUT_FLAG = 'I') ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCK_TRANSFER_FROM]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCK_TRANSFER_FROM]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_STOCK_TRANSFER_FROM AS ";
                    strSQL = strSQL + "SELECT INV_REF_NO,STOCKITEM_NAME,GODOWNS_NAME FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE (INV_VOUCHER_TYPE = 23) AND (INV_INOUT_FLAG = 'O') ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCK_TRANSFER_DAY_BOOK]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCK_TRANSFER_DAY_BOOK]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_STOCK_TRANSFER_DAY_BOOK AS ";
                    strSQL = strSQL + "SELECT INV_STOCK_TRANSFER_TO.INV_DATE,INV_STOCK_TRANSFER_TO.INV_REF_NO,";
                    strSQL = strSQL + "INV_STOCK_TRANSFER_FROM.GODOWNS_NAME AS FROM_LOCATION, INV_STOCK_TRANSFER_TO.GODOWNS_NAME AS TO_LOCATION,";
                    strSQL = strSQL + "INV_STOCK_TRANSFER_TO.STOCKITEM_NAME,INV_STOCK_TRANSFER_TO.INV_TRAN_QUANTITY,";
                    strSQL = strSQL + "INV_STOCK_TRANSFER_TO.INV_TRAN_AMOUNT ";
                    strSQL = strSQL + "FROM INV_STOCK_TRANSFER_TO INNER JOIN ";
                    strSQL = strSQL + "INV_STOCK_TRANSFER_FROM ON INV_STOCK_TRANSFER_TO.INV_REF_NO = INV_STOCK_TRANSFER_FROM.INV_REF_NO AND ";
                    strSQL = strSQL + "INV_STOCK_TRANSFER_TO.STOCKITEM_NAME = INV_STOCK_TRANSFER_FROM.STOCKITEM_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    //''new
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_TRAN_QTY_SALES_PRICE_QRY]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_TRAN_QTY_SALES_PRICE_QRY]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_TRAN_QTY_SALES_PRICE_QRY AS ";
                    strSQL = strSQL + "SELECT STOCKITEM_NAME, isnull(SUM(INV_TRAN_QUANTITY),0) AS INV_TRAN_QUANTITY ";
                    strSQL = strSQL + "FROM INV_TRAN ";
                    strSQL = strSQL + "GROUP BY STOCKITEM_NAME ";
                    strSQL = strSQL + "Having (Sum(INV_TRAN_QUANTITY) <> 0) ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_SALES_MAX_DT]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_SALES_MAX_DT]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_SALES_MAX_DT AS ";
                    strSQL = strSQL + "SELECT STOCKITEM_NAME, MAX(SALES_PRICE_EFFECTIVE_DATE) AS MAX_DATE ";
                    strSQL = strSQL + "From INV_SALES_PRICE ";
                    strSQL = strSQL + "GROUP BY STOCKITEM_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_SALES_RATE_Q1]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_SALES_RATE_Q1]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_SALES_RATE_Q1 AS ";
                    strSQL = strSQL + "SELECT INV_SALES_PRICE.SALES_PRICE_AMOUNT, INV_SALES_PRICE.STOCKITEM_NAME ";
                    strSQL = strSQL + "FROM INV_SALES_PRICE INNER JOIN ";
                    strSQL = strSQL + "INV_SALES_MAX_DT ON INV_SALES_PRICE.STOCKITEM_NAME = INV_SALES_MAX_DT.STOCKITEM_NAME AND ";
                    strSQL = strSQL + "INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE = INV_SALES_MAX_DT.MAX_DATE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateViewCheckLedger()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_CHECK_LEDGER]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[ACC_CHECK_LEDGER]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW ACC_CHECK_LEDGER AS ";
                    strSQL = strSQL + "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO,ACC_COMPANY_VOUCHER.LEDGER_NAME, SUM(ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT) AS COMP_VOUCHER_NET_AMOUNT,";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_PARENT_GROUP, ACC_LEDGER.LEDGER_PRIMARY_GROUP, ACC_LEDGER.LEDGER_NAME_DEFAULT,";
                    strSQL = strSQL + "ACC_LEDGERGROUP.GR_NAME, ACC_LEDGERGROUP.GR_PARENT, ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE,";
                    strSQL = strSQL + "ACC_LEDGERGROUP.GR_PRIMARY ";
                    strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGER ON ACC_COMPANY_VOUCHER.LEDGER_NAME = ACC_LEDGER.LEDGER_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_LEDGERGROUP ON ACC_LEDGER.LEDGER_PARENT_GROUP = ACC_LEDGERGROUP.GR_NAME ";
                    strSQL = strSQL + "GROUP BY ACC_COMPANY_VOUCHER.COMP_REF_NO,ACC_COMPANY_VOUCHER.LEDGER_NAME, ACC_LEDGER.LEDGER_PARENT_GROUP, ACC_LEDGER.LEDGER_PRIMARY_GROUP, ";
                    strSQL = strSQL + "ACC_LEDGER.LEDGER_NAME_DEFAULT, ACC_LEDGERGROUP.GR_NAME, ACC_LEDGERGROUP.GR_PARENT, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE , ACC_LEDGERGROUP.GR_PRIMARY ";
                    //''strSQL = strSQL + "HAVING      (ACC_LEDGERGROUP.GR_PARENT = 'Sundry Creditors')"
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }

        private static string CreateItemColsingView()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[STOCKITEM_CLOSING_VIEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[STOCKITEM_CLOSING_VIEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW STOCKITEM_CLOSING_VIEW AS ";
                    //'    strSQL = strSQL + "SELECT INV_STOCKITEM_CLOSING.STOCKITEM_NAME, INV_STOCKITEM_CLOSING.GODOWNS_NAME, ISNULL(SUM(INV_TRAN.INV_TRAN_QUANTITY), 0) "
                    //'    strSQL = strSQL + "AS STOCKITEM_CLOSING_BALANCE, INV_STOCKITEM.STOCKITEM_ALIAS, INV_STOCKITEM.STOCKITEM_BASEUNITS "
                    //'    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING INNER JOIN "
                    //'    strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKITEM_CLOSING.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME LEFT OUTER JOIN "
                    //'    strSQL = strSQL + "INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME AND "
                    //'    strSQL = strSQL + "INV_STOCKITEM_CLOSING.GODOWNS_NAME = INV_TRAN.GODOWNS_NAME "
                    //'    strSQL = strSQL + "WHERE (INV_STOCKITEM.STOCKITEM_STATUS = 0) "
                    //'    strSQL = strSQL + "GROUP BY INV_STOCKITEM_CLOSING.STOCKITEM_NAME, INV_STOCKITEM_CLOSING.GODOWNS_NAME, INV_STOCKITEM.STOCKITEM_ALIAS, "
                    //'    strSQL = strSQL + "INV_STOCKITEM.STOCKITEM_BASEUNITS , INV_STOCKITEM.STOCKITEM_STATUS "

                    strSQL = strSQL + "SELECT INV_STOCKITEM_CLOSING.STOCKITEM_NAME, INV_STOCKITEM_CLOSING.GODOWNS_NAME, INV_STOCKITEM.STOCKITEM_ALIAS,";
                    strSQL = strSQL + "INV_STOCKITEM.STOCKITEM_BASEUNITS , Sum(INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE) ";
                    strSQL = strSQL + "AS STOCKITEM_CLOSING_BALANCE,SUM(INV_STOCKITEM_CLOSING.STOCKITEM_SALE_BALANCE) as STOCKITEM_SALE_BALANCE ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKITEM_CLOSING.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME ";
                    strSQL = strSQL + "WHERE (INV_STOCKITEM.STOCKITEM_STATUS = 0) ";
                    strSQL = strSQL + "GROUP BY INV_STOCKITEM_CLOSING.STOCKITEM_NAME, INV_STOCKITEM_CLOSING.GODOWNS_NAME, INV_STOCKITEM.STOCKITEM_ALIAS, ";
                    strSQL = strSQL + "INV_STOCKITEM.STOCKITEM_BASEUNITS ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateclosingviewNew()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[STOCKITEM_CLOSING_VIEW_NEW]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[STOCKITEM_CLOSING_VIEW_NEW]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW STOCKITEM_CLOSING_VIEW_NEW AS ";
                    strSQL = strSQL + "SELECT INC.STOCKITEM_NAME,INC.STOCKITEM_CLOSING_BALANCE,INC.STOCKITEM_SALE_BALANCE,INV.STOCKITEM_ALIAS,INV.STOCKITEM_BASEUNITS,INC.GODOWNS_NAME FROM INV_STOCKITEM INV,INV_STOCKITEM_CLOSING INC ";
                    strSQL = strSQL + "WHERE INV.STOCKITEM_NAME = INC.STOCKITEM_NAME ";
                    strSQL = strSQL + "AND INV.STOCKITEM_STATUS=0 ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateBillTranQryAppr()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
                    //strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ACC_COMP_BILL_TRAN_QRY_APPR]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    //strSQL = strSQL + "drop view [dbo].[ACC_COMP_BILL_TRAN_QRY_APPR]";
                    //cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();
                    //strSQL = "CREATE VIEW ACC_COMP_BILL_TRAN_QRY_APPR AS ";
                    //strSQL = strSQL + "SELECT SMA_ACC_COMPANY_VOUCHER_APPR.COMP_VOUCHER_DATE, SUBSTRING(SMA_ACC_COMPANY_VOUCHER_APPR.COMP_REF_NO, 7, 30)";
                    //strSQL = strSQL + "AS COMP_REF_NO, SMA_ACC_COMPANY_VOUCHER_APPR.LEDGER_NAME, SMA_ACC_COMPANY_VOUCHER_APPR.COMP_VOUCHER_DUE_DATE,";
                    //strSQL = strSQL + "SMA_ACC_COMPANY_VOUCHER_APPR.COMP_VOUCHER_NARRATION, ACC_BILL_TRAN_APPR.STOCKITEM_NAME,";
                    //strSQL = strSQL + "ACC_BILL_TRAN_APPR.BILL_UOM, ACC_BILL_TRAN_APPR.BILL_QUANTITY, ACC_BILL_TRAN_APPR.BILL_RATE,";
                    //strSQL = strSQL + "ACC_BILL_TRAN_APPR.BILL_NET_AMOUNT, SMA_ACC_COMPANY_VOUCHER_APPR.COMP_VOUCHER_TYPE,";
                    //strSQL = strSQL + "ACC_BILL_TRAN_APPR.GODOWNS_NAME, SMA_ACC_COMPANY_VOUCHER_APPR.COMP_VOUCHER_STATUS,";
                    //strSQL = strSQL + "ACC_BILL_TRAN_APPR.VOUCHER_CURRENCY_SYMBOL, ACC_BILL_TRAN_APPR.VOUCHER_FC_AMOUNT,";
                    //strSQL = strSQL + "SMA_ACC_COMPANY_VOUCHER_APPR.BRANCH_ID , ACC_BILL_TRAN_APPR.FC_CONVERSION_RATE, ACC_BILL_TRAN_APPR.BILL_PER ";
                    //strSQL = strSQL + "FROM SMA_ACC_COMPANY_VOUCHER_APPR INNER JOIN ";
                    //strSQL = strSQL + "ACC_BILL_TRAN_APPR ON SMA_ACC_COMPANY_VOUCHER_APPR.COMP_REF_NO = ACC_BILL_TRAN_APPR.COMP_REF_NO ";
                    //cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();
                    strSQL = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INV_STOCKITEM_TRAN_QRY_COSTING]') and OBJECTPROPERTY(id, N'IsView') = 1) ";
                    strSQL = strSQL + "drop view [dbo].[INV_STOCKITEM_TRAN_QRY_COSTING]";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE VIEW INV_STOCKITEM_TRAN_QRY_COSTING AS ";
                    strSQL = strSQL + "SELECT STOCKITEM_NAME,ISNULL(SUM(INV_TRAN_AMOUNT),0) AS INV_TRAN_AMOUNT ,ISNULL(SUM(INV_TRAN_QUANTITY),0) AS INV_TRAN_QUANTITY FROM INV_TRAN ";
                    strSQL = strSQL + "GROUP BY STOCKITEM_NAME";
                    cmd.CommandText = strSQL;
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
