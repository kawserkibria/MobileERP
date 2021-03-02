using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutility
{
    public class basTrigger
    {
        public static string gCreateTrigger()
        {
            string strSQL;
            strSQL= CreateAccLedgerDeleteTrigger();
            strSQL=  CreateAccLedgerInsertTrigger();
            strSQL = CreateStockItemChallanDelete();
            strSQL = CreateStockItemChallanInsert();
            strSQL = CreateStockItemClosingDelete();
            strSQL = CreateStockItemClosingInsert();
            strSQL = CreateStockItemCostDelete();
            strSQL = CreateStockItemRunning();
            strSQL = CreateStockItemSaleDelete();
            strSQL = CreateStockItemSaleInsert();
            strSQL = CreateStockItemTransaction();
            //strSQL= CreateAccGroupLedgerUniqueTrigger();
            //strSQL= CreateStockClosingTrigger();
            return  strSQL;
        }
        private static string CreateStockItemTransaction()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnmain.State == System.Data.ConnectionState.Open)
                {
                    gcnmain.Close();
                }
                try
                {
                    gcnmain.Open();
                    string strSQL = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnmain;

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_TRANSACTION' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER TR_INV_STOCKITEM_TRANSACTION ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_TRANSACTION' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER JG_INV_STOCKITEM_TRANSACTION ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();


                    strSQL = " CREATE TRIGGER JG_INV_STOCKITEM_TRANSACTION ON INV_STOCKITEM AFTER INSERT AS DECLARE @STOCKITEM VARCHAR(60) DECLARE @STOCKGROUP VARCHAR(60) DECLARE @INSQTY NUMERIC(18,2) ";
                    strSQL = strSQL + "SELECT @INSQTY=STOCKITEM_OPENING_BALANCE,@STOCKITEM=STOCKITEM_NAME, @STOCKGROUP=STOCKGROUP_NAME FROM inserted BEGIN ";
                    strSQL = strSQL + "UPDATE INV_STOCKITEM SET INV_STOCKITEM.STOCKITEM_CLOSING_BALANCE =   @INSQTY FROM INV_STOCKITEM WHERE INV_STOCKITEM.STOCKITEM_NAME = @STOCKITEM End BEGIN ";
                    strSQL = strSQL + "UPDATE INV_STOCKGROUP SET STOCKGROUP_CLOSING_BALANCE = STOCKGROUP_CLOSING_BALANCE + @INSQTY ,STOCKGROUP_OPENING_VALUE = STOCKGROUP_OPENING_VALUE + @INSQTY  ";
                    strSQL = strSQL + "WHERE STOCKGROUP_NAME= @STOCKGROUP End ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateStockItemSaleInsert()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnmain.State == System.Data.ConnectionState.Open)
                {
                    gcnmain.Close();
                }
                try
                {
                    gcnmain.Open();
                    string strSQL = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnmain;

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_SALE_INSERT' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER TR_INV_STOCKITEM_SALE_INSERT ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_SALE_INSERT' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER JG_INV_STOCKITEM_SALE_INSERT ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = " CREATE TRIGGER JG_INV_STOCKITEM_SALE_INSERT ON ACC_BILL_TRAN FOR INSERT AS UPDATE INV_STOCKITEM_CLOSING ";
                    strSQL = strSQL + "SET INV_STOCKITEM_CLOSING.STOCKITEM_SALE_BALANCE = INV_STOCKITEM_CLOSING.STOCKITEM_SALE_BALANCE + inserted.BILL_QUANTITY + inserted.BILL_QUANTITY_BONUS ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING JOIN inserted on INV_STOCKITEM_CLOSING.STOCKITEM_NAME = inserted.STOCKITEM_NAME ";
                    strSQL = strSQL + "AND INV_STOCKITEM_CLOSING.GODOWNS_NAME = inserted.GODOWNS_NAME WHERE inserted.COMP_VOUCHER_TYPE = 16 ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateStockItemSaleDelete()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnmain.State == System.Data.ConnectionState.Open)
                {
                    gcnmain.Close();
                }
                try
                {
                    gcnmain.Open();
                    string strSQL = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnmain;

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_SALE_DELETE' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER TR_INV_STOCKITEM_SALE_DELETE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_SALE_DELETE' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER JG_INV_STOCKITEM_SALE_DELETE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = " CREATE TRIGGER JG_INV_STOCKITEM_SALE_DELETE ON ACC_BILL_TRAN FOR DELETE AS UPDATE INV_STOCKITEM_CLOSING SET ";
                    strSQL = strSQL + "INV_STOCKITEM_CLOSING.STOCKITEM_SALE_BALANCE = INV_STOCKITEM_CLOSING.STOCKITEM_SALE_BALANCE - (deleted.BILL_QUANTITY + deleted.BILL_QUANTITY_BONUS) ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING JOIN deleted on INV_STOCKITEM_CLOSING.STOCKITEM_NAME = deleted.STOCKITEM_NAME ";
                    strSQL = strSQL + "AND INV_STOCKITEM_CLOSING.GODOWNS_NAME = deleted.GODOWNS_NAME WHERE deleted.COMP_VOUCHER_TYPE = 16 ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateStockItemRunning()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnmain.State == System.Data.ConnectionState.Open)
                {
                    gcnmain.Close();
                }
                try
                {
                    gcnmain.Open();
                    string strSQL = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnmain;

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_RUNNING' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER TR_INV_STOCKITEM_RUNNING ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_RUNNING' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER JG_INV_STOCKITEM_RUNNING ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TRIGGER JG_INV_STOCKITEM_RUNNING ON INV_TRAN AFTER INSERT AS DECLARE @InvTranSerial float ";
                    strSQL = strSQL + "DECLARE @InvVoucherType INT DECLARE @StockItem VARCHAR(50) ";
                    strSQL = strSQL + "DECLARE @InvTranDate DATETIME DECLARE @InvStartDate DATETIME DECLARE @InvEndDate DATETIME ";
                    strSQL = strSQL + "DECLARE @InvQty float DECLARE @InvTranQty float DECLARE @InvAmt float DECLARE @InvCostRate float ";
                    strSQL = strSQL + "DECLARE @InvCostAmt float ";
                    strSQL = strSQL + "SELECT @InvTranSerial = INV_TRAN_SERIAL,@InvVoucherType = INV_VOUCHER_TYPE,@StockItem = STOCKITEM_NAME,";
                    strSQL = strSQL + "@InvTranDate = INV_DATE,@InvTranQty = INV_TRAN_QUANTITY FROM inserted ";
                    strSQL = strSQL + "UPDATE INV_TRAN SET INV_TRAN_RUNNING_QTY = (SELECT SUM(INV_TRAN_QUANTITY) FROM INV_TRAN P ";
                    strSQL = strSQL + "WHERE P.INV_DATE <= @InvTranDate AND P.STOCKITEM_NAME = @StockItem) ";
                    strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND INV_DATE = @InvTranDate ";
                    strSQL = strSQL + "UPDATE INV_TRAN SET INV_TRAN_RUNNING_QTY = INV_TRAN_RUNNING_QTY + @InvTranQty WHERE INV_DATE > @InvTranDate AND ";
                    strSQL = strSQL + "STOCKITEM_NAME = @StockItem IF @InvTranQty < 0 BEGIN SET @InvStartDate = '01-01-1899' ";
                    strSQL = strSQL + "SELECT @InvStartDate = INV_DATE FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND INV_DATE < convert(datetime,@InvTranDate,103)  ";
                    strSQL = strSQL + "AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) FROM ";
                    strSQL = strSQL + "INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE > convert(datetime,@InvStartDate,103) ";
                    strSQL = strSQL + "AND INV_DATE <= convert(datetime,@InvTranDate,103)) AND INV_TRAN_SERIAL <> @InvTranSerial ";
                    strSQL = strSQL + "IF @InvQty <> 0 SET @InvCostRate = @InvAmt/@InvQty SET @InvCostAmt = (@InvCostRate * @InvTranQty) ";
                    strSQL = strSQL + "IF @InvCostAmt IS NULL SET @InvCostAmt = 0 ";
                    strSQL = strSQL + "UPDATE INV_TRAN SET OUTWARD_COST_AMOUNT = @InvCostAmt, ";
                    strSQL = strSQL + "INV_TRAN_AMOUNT = @InvCostAmt WHERE INV_TRAN_SERIAL = @InvTranSerial END ";
                    strSQL = strSQL + "IF @InvTranQty > 0 BEGIN SET @InvStartDate = '01-01-1899' ";
                    strSQL = strSQL + "SELECT @InvStartDate = INV_DATE FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND INV_DATE < convert(datetime,@InvTranDate,103)  ";
                    strSQL = strSQL + "AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE SET @InvEndDate = '01-01-2099' ";
                    strSQL = strSQL + "SELECT @InvEndDate = INV_DATE FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND ";
                    strSQL = strSQL + "INV_DATE > convert(datetime,@InvTranDate,103)  AND INV_TRAN_RUNNING_QTY = 0 ";
                    strSQL = strSQL + "ORDER BY INV_DATE SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) ";
                    strSQL = strSQL + "FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE >= convert(datetime,@InvTranDate,103) ";
                    strSQL = strSQL + "AND INV_DATE <= convert(datetime,@InvEndDate,103)) AND (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') ";
                    strSQL = strSQL + "IF @InvQty <> 0 SET @InvCostRate = @InvAmt/@InvQty IF @InvCostRate IS NULL SET @InvCostRate = 0 ";
                    strSQL = strSQL + "UPDATE INV_TRAN SET INV_TRAN_RATE = @InvCostRate, INV_TRAN_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate , ";
                    strSQL = strSQL + "OUTWARD_COST_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate WHERE STOCKITEM_NAME = @StockItem ";
                    strSQL = strSQL + "AND (INV_DATE >= convert(datetime,@InvTranDate,103) AND INV_DATE <= convert(datetime,@InvEndDate,103)) ";
                    strSQL = strSQL + "AND INV_TRAN_QUANTITY < 0 END IF @InvTranQty = 0 BEGIN SET @InvStartDate = '01-01-1899' ";
                    strSQL = strSQL + "SELECT @InvStartDate = INV_DATE FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND ";
                    strSQL = strSQL + "INV_DATE < convert(datetime,@InvTranDate,103)  AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE ";
                    strSQL = strSQL + "SET @InvEndDate = '01-01-2099' SELECT @InvEndDate = INV_DATE FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem ";
                    strSQL = strSQL + "AND INV_DATE > convert(datetime,@InvTranDate,103)  AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE ";
                    strSQL = strSQL + "SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE >= convert(datetime,@InvTranDate,103) ";
                    strSQL = strSQL + "AND INV_DATE <= convert(datetime,@InvEndDate,103)) AND (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') ";
                    strSQL = strSQL + "IF @InvQty <> 0 SET @InvCostRate = @InvAmt/@InvQty IF @InvCostRate IS NULL SET @InvCostRate = 0 ";
                    strSQL = strSQL + "UPDATE INV_TRAN SET INV_TRAN_RATE = @InvCostRate, INV_TRAN_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate , ";
                    strSQL = strSQL + "OUTWARD_COST_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate WHERE STOCKITEM_NAME = @StockItem ";
                    strSQL = strSQL + "AND (INV_DATE >= convert(datetime,@InvTranDate,103) AND INV_DATE <= convert(datetime,@InvEndDate,103)) ";
                    strSQL = strSQL + "AND INV_TRAN_QUANTITY < 0 END ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateStockItemCostDelete()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnmain.State == System.Data.ConnectionState.Open)
                {
                    gcnmain.Close();
                }
                try
                {
                    gcnmain.Open();
                    string strSQL = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnmain;

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_COST_DELETE' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER TR_INV_STOCKITEM_COST_DELETE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_COST_DELETE' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER JG_INV_STOCKITEM_COST_DELETE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "CREATE TRIGGER JG_INV_STOCKITEM_COST_DELETE ON INV_TRAN AFTER DELETE AS DECLARE @InvTranSerial float ";
                    strSQL = strSQL + "DECLARE @InvVoucherType INT DECLARE @StockItem VARCHAR(50) DECLARE @InvTranDate DATETIME ";
                    strSQL = strSQL + "DECLARE @InvStartDate DATETIME DECLARE @InvEndDate DATETIME DECLARE @InvQty float DECLARE @InvTranQty float ";
                    strSQL = strSQL + "DECLARE @InvAmt float DECLARE @InvCostRate float DECLARE @InvCostAmt float ";
                    strSQL = strSQL + "SELECT @InvTranSerial = INV_TRAN_SERIAL,@InvVoucherType = INV_VOUCHER_TYPE,@StockItem = STOCKITEM_NAME,";
                    strSQL = strSQL + "@InvTranDate = INV_DATE,@InvTranQty = INV_TRAN_QUANTITY FROM deleted UPDATE INV_TRAN ";
                    strSQL = strSQL + "SET INV_TRAN_RUNNING_QTY = (SELECT SUM(INV_TRAN_QUANTITY) FROM INV_TRAN P WHERE P.INV_DATE <= @InvTranDate ";
                    strSQL = strSQL + "AND P.STOCKITEM_NAME = @StockItem) WHERE STOCKITEM_NAME = @StockItem AND INV_DATE = @InvTranDate ";
                    strSQL = strSQL + "UPDATE INV_TRAN SET INV_TRAN_RUNNING_QTY = INV_TRAN_RUNNING_QTY - @InvTranQty ";
                    strSQL = strSQL + "WHERE INV_DATE > @InvTranDate AND STOCKITEM_NAME = @StockItem IF @InvTranQty < 0 BEGIN ";
                    strSQL = strSQL + "SET @InvStartDate = '01-01-1899' SELECT @InvStartDate = INV_DATE FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND INV_DATE < convert(datetime,@InvTranDate,103)  ";
                    strSQL = strSQL + "AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) ";
                    strSQL = strSQL + "FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE > convert(datetime,@InvStartDate,103) ";
                    strSQL = strSQL + "AND INV_DATE <= convert(datetime,@InvTranDate,103)) AND INV_TRAN_SERIAL <> @InvTranSerial IF @InvQty <> 0 ";
                    strSQL = strSQL + "SET @InvCostRate = @InvAmt/@InvQty SET @InvCostAmt = (@InvCostRate * @InvTranQty) ";
                    strSQL = strSQL + "IF @InvCostAmt IS NULL SET @InvCostAmt = 0 UPDATE INV_TRAN SET OUTWARD_COST_AMOUNT = @InvCostAmt, ";
                    strSQL = strSQL + "INV_TRAN_AMOUNT = @InvCostAmt WHERE INV_TRAN_SERIAL = @InvTranSerial END IF @InvTranQty > 0 BEGIN ";
                    strSQL = strSQL + "SET @InvStartDate = '01-01-1899' SELECT @InvStartDate = INV_DATE FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND INV_DATE < convert(datetime,@InvTranDate,103)  ";
                    strSQL = strSQL + "AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE SET @InvEndDate = '01-01-2099' ";
                    strSQL = strSQL + "SELECT @InvEndDate = INV_DATE FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND INV_DATE > convert(datetime,@InvTranDate,103)  ";
                    strSQL = strSQL + "AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) ";
                    strSQL = strSQL + "FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE >= convert(datetime,@InvStartDate,103) ";
                    strSQL = strSQL + "AND INV_DATE <= convert(datetime,@InvEndDate,103)) AND (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') ";
                    strSQL = strSQL + "IF @InvQty <> 0 SET @InvCostRate = @InvAmt/@InvQty IF @InvCostRate IS NULL SET @InvCostRate = 0 ";
                    strSQL = strSQL + "UPDATE INV_TRAN SET INV_TRAN_RATE = @InvCostRate, INV_TRAN_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate , ";
                    strSQL = strSQL + "OUTWARD_COST_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate WHERE STOCKITEM_NAME = @StockItem ";
                    strSQL = strSQL + "AND (INV_DATE >= convert(datetime,@InvStartDate,103) AND INV_DATE <= convert(datetime,@InvEndDate,103)) ";
                    strSQL = strSQL + "AND INV_TRAN_QUANTITY < 0 END IF @InvTranQty = 0 BEGIN SET @InvStartDate = '01-01-1899' ";
                    strSQL = strSQL + "SELECT @InvStartDate = INV_DATE FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem ";
                    strSQL = strSQL + "AND INV_DATE < convert(datetime,@InvTranDate,103)  AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE ";
                    strSQL = strSQL + "SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE >= convert(datetime,@InvStartDate,103) AND ";
                    strSQL = strSQL + "INV_DATE <= convert(datetime,@InvTranDate,103)) AND (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') ";
                    strSQL = strSQL + "IF @InvQty <> 0 SET @InvCostRate = @InvAmt/@InvQty IF @InvCostRate IS NULL SET @InvCostRate = 0 ";
                    strSQL = strSQL + "UPDATE INV_TRAN SET INV_TRAN_RATE = @InvCostRate, INV_TRAN_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate , ";
                    strSQL = strSQL + "OUTWARD_COST_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate WHERE STOCKITEM_NAME = @StockItem AND ";
                    strSQL = strSQL + "INV_DATE >= @InvTranDate AND INV_TRAN_QUANTITY < 0 END ";


                    //strSQL = " CREATE TRIGGER JG_INV_STOCKITEM_COST_DELETE ON INV_TRAN AFTER DELETE AS DECLARE @InvTranSerial numeric(18,4) DECLARE @InvVoucherType INT DECLARE @StockItem VARCHAR(60) ";
                    //strSQL = strSQL + "DECLARE @InvTranDate DATETIME DECLARE @InvStartDate DATETIME DECLARE @InvEndDate DATETIME DECLARE @InvQty numeric(18,4) DECLARE @InvTranQty numeric(18,4) ";
                    //strSQL = strSQL + "DECLARE @InvAmt numeric(18,4) DECLARE @InvCostRate numeric(18,4) DECLARE @InvCostAmt numeric(18,4) ";
                    //strSQL = strSQL + "SELECT @InvTranSerial = INV_TRAN_SERIAL,@InvVoucherType = INV_VOUCHER_TYPE,@StockItem = STOCKITEM_NAME,@InvTranDate = INV_DATE,@InvTranQty = INV_TRAN_QUANTITY ";
                    //strSQL = strSQL + "FROM deleted UPDATE INV_TRAN SET INV_TRAN_RUNNING_QTY = (SELECT SUM(INV_TRAN_QUANTITY) FROM INV_TRAN P WHERE P.INV_DATE <= @InvTranDate ";
                    //strSQL = strSQL + "AND P.STOCKITEM_NAME = @StockItem) WHERE STOCKITEM_NAME = @StockItem AND INV_DATE = @InvTranDate ";
                    //strSQL = strSQL + "UPDATE INV_TRAN SET INV_TRAN_RUNNING_QTY = INV_TRAN_RUNNING_QTY - @InvTranQty WHERE INV_DATE > @InvTranDate AND STOCKITEM_NAME = @StockItem ";
                    //strSQL = strSQL + "IF @InvTranQty < 0 BEGIN SET @InvStartDate = '01-01-1899' SELECT @InvStartDate = INV_DATE FROM INV_TRAN ";
                    //strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND INV_DATE < convert(datetime,@InvTranDate,103)  AND INV_TRAN_RUNNING_QTY = 0 ";
                    //strSQL = strSQL + "ORDER BY INV_DATE SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem ";
                    //strSQL = strSQL + "AND (INV_DATE > convert(datetime,@InvStartDate,103) AND INV_DATE <= convert(datetime,@InvTranDate,103)) AND INV_TRAN_SERIAL <> @InvTranSerial ";
                    //strSQL = strSQL + "IF @InvQty <> 0 SET @InvCostRate = @InvAmt/@InvQty SET @InvCostAmt = (@InvCostRate * @InvTranQty) IF @InvCostAmt IS NULL SET @InvCostAmt = 0 ";
                    //strSQL = strSQL + "UPDATE INV_TRAN SET OUTWARD_COST_AMOUNT = @InvCostAmt, INV_TRAN_AMOUNT = @InvCostAmt WHERE INV_TRAN_SERIAL = @InvTranSerial END ";
                    //strSQL = strSQL + "IF @InvTranQty > 0 BEGIN SET @InvStartDate = '01-01-1899' SELECT @InvStartDate = INV_DATE FROM INV_TRAN ";
                    //strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND INV_DATE < convert(datetime,@InvTranDate,103)  AND INV_TRAN_RUNNING_QTY = 0 ";
                    //strSQL = strSQL + "ORDER BY INV_DATE SET @InvEndDate = '01-01-3099' SELECT @InvEndDate = INV_DATE FROM INV_TRAN ";
                    //strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND INV_DATE > convert(datetime,@InvTranDate,103)  AND INV_TRAN_RUNNING_QTY = 0 ";
                    //strSQL = strSQL + "ORDER BY INV_DATE SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) FROM INV_TRAN ";
                    //strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE >= convert(datetime,@InvStartDate,103) AND INV_DATE <= convert(datetime,@InvEndDate,103)) ";
                    //strSQL = strSQL + "AND (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') IF @InvQty <> 0 SET @InvCostRate = @InvAmt/@InvQty IF @InvCostRate IS NULL SET @InvCostRate = 0 ";
                    //strSQL = strSQL + "UPDATE INV_TRAN SET INV_TRAN_RATE = @InvCostRate, INV_TRAN_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate , OUTWARD_COST_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate ";
                    //strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE >= convert(datetime,@InvStartDate,103) AND INV_DATE <= convert(datetime,@InvEndDate,103)) ";
                    //strSQL = strSQL + "AND INV_TRAN_QUANTITY < 0 END IF @InvTranQty = 0 BEGIN SET @InvStartDate = '01-01-1899' SELECT @InvStartDate = INV_DATE FROM INV_TRAN ";
                    //strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND INV_DATE < convert(datetime,@InvTranDate,103)  AND INV_TRAN_RUNNING_QTY = 0 ";
                    //strSQL = strSQL + "ORDER BY INV_DATE SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) FROM INV_TRAN ";
                    //strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE >= convert(datetime,@InvStartDate,103) AND INV_DATE <= convert(datetime,@InvTranDate,103)) ";
                    //strSQL = strSQL + "AND (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') IF @InvQty <> 0 SET @InvCostRate = @InvAmt/@InvQty IF @InvCostRate IS NULL SET @InvCostRate = 0 ";
                    //strSQL = strSQL + "UPDATE INV_TRAN SET INV_TRAN_RATE = @InvCostRate, INV_TRAN_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate , OUTWARD_COST_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate ";
                    //strSQL = strSQL + "WHERE STOCKITEM_NAME = @StockItem AND INV_DATE >= @InvTranDate AND INV_TRAN_QUANTITY < 0 END ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateStockItemClosingInsert()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnmain.State == System.Data.ConnectionState.Open)
                {
                    gcnmain.Close();
                }
                try
                {
                    gcnmain.Open();
                    string strSQL = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnmain;

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_CLOSING_INSERT' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER TR_INV_STOCKITEM_CLOSING_INSERT ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_CLOSING_INSERT' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER JG_INV_STOCKITEM_CLOSING_INSERT ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = " CREATE TRIGGER JG_INV_STOCKITEM_CLOSING_INSERT ON INV_TRAN FOR INSERT AS UPDATE INV_STOCKITEM_CLOSING SET ";
                    strSQL = strSQL + "INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE = INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE + inserted.INV_TRAN_QUANTITY ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING JOIN inserted on INV_STOCKITEM_CLOSING.STOCKITEM_NAME = inserted.STOCKITEM_NAME ";
                    strSQL = strSQL + "AND INV_STOCKITEM_CLOSING.GODOWNS_NAME = inserted.GODOWNS_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateStockItemClosingDelete()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnmain.State == System.Data.ConnectionState.Open)
                {
                    gcnmain.Close();
                }
                try
                {
                    gcnmain.Open();
                    string strSQL = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnmain;

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_CLOSING_DELETE' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER TR_INV_STOCKITEM_CLOSING_DELETE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_CLOSING_DELETE' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER JG_INV_STOCKITEM_CLOSING_DELETE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = " CREATE TRIGGER JG_INV_STOCKITEM_CLOSING_DELETE ON INV_TRAN FOR DELETE AS UPDATE INV_STOCKITEM_CLOSING SET ";
                    strSQL = strSQL + "INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE = INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE + (deleted.INV_TRAN_QUANTITY * -1) ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING JOIN deleted ON INV_STOCKITEM_CLOSING.STOCKITEM_NAME = deleted.STOCKITEM_NAME ";
                    strSQL = strSQL + "AND INV_STOCKITEM_CLOSING.GODOWNS_NAME = deleted.GODOWNS_NAME ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateStockItemChallanInsert()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnmain.State == System.Data.ConnectionState.Open)
                {
                    gcnmain.Close();
                }
                try
                {
                    gcnmain.Open();
                    string strSQL = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnmain;

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_CHALLAN_INSERT' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER TR_INV_STOCKITEM_CHALLAN_INSERT ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_CHALLAN_INSERT' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER JG_INV_STOCKITEM_CHALLAN_INSERT ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = " CREATE TRIGGER JG_INV_STOCKITEM_CHALLAN_INSERT ON ACC_BILL_TRAN FOR INSERT AS UPDATE INV_STOCKITEM_CLOSING SET ";
                    strSQL = strSQL + "INV_STOCKITEM_CLOSING.STOCKITEM_SALE_BALANCE = INV_STOCKITEM_CLOSING.STOCKITEM_SALE_BALANCE - (inserted.BILL_QUANTITY + inserted.BILL_QUANTITY_BONUS) ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING JOIN inserted on INV_STOCKITEM_CLOSING.STOCKITEM_NAME = inserted.STOCKITEM_NAME ";
                    strSQL = strSQL + "AND INV_STOCKITEM_CLOSING.GODOWNS_NAME = inserted.GODOWNS_NAME WHERE inserted.COMP_VOUCHER_TYPE = 15 AND inserted.COMP_REF_NO LIKE 'SC%'";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
        private static string CreateStockItemChallanDelete()
        {
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnmain.State == System.Data.ConnectionState.Open)
                {
                    gcnmain.Close();
                }
                try
                {
                    gcnmain.Open();
                    string strSQL = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnmain;

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_CHALLAN_DELETE' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER TR_INV_STOCKITEM_CHALLAN_DELETE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_CHALLAN_DELETE' AND type = 'TR') ";
                    strSQL = strSQL + "DROP TRIGGER JG_INV_STOCKITEM_CHALLAN_DELETE ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = " CREATE TRIGGER JG_INV_STOCKITEM_CHALLAN_DELETE ON ACC_BILL_TRAN FOR DELETE AS UPDATE INV_STOCKITEM_CLOSING SET ";
                    strSQL = strSQL + "INV_STOCKITEM_CLOSING.STOCKITEM_SALE_BALANCE = INV_STOCKITEM_CLOSING.STOCKITEM_SALE_BALANCE + deleted.BILL_QUANTITY + deleted.BILL_QUANTITY_BONUS ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING JOIN deleted on INV_STOCKITEM_CLOSING.STOCKITEM_NAME = deleted.STOCKITEM_NAME ";
                    strSQL = strSQL + "AND INV_STOCKITEM_CLOSING.GODOWNS_NAME = deleted.GODOWNS_NAME WHERE deleted.COMP_VOUCHER_TYPE = 15 AND deleted.COMP_REF_NO LIKE 'SC%'";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    return strSQL;
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }
  private static string CreateAccGroupLedgerUniqueTrigger()

    {
    using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
    {
        if (gcnmain.State == System.Data.ConnectionState.Open)
        {
            gcnmain.Close();
        }
        try
        {
            gcnmain.Open();
            string strSQL="";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection=gcnmain;

            strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_ACC_GROUP_UNIQUE' AND type = 'TR') ";
            strSQL = strSQL + "DROP TRIGGER TR_ACC_GROUP_UNIQUE ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
            strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_ACC_LEDGER_UNIQUE' AND type = 'TR') ";
            strSQL = strSQL + "DROP TRIGGER TR_ACC_LEDGER_UNIQUE ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();

            strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_ACC_GROUP_UNIQUE' AND type = 'TR') ";
            strSQL = strSQL + "DROP TRIGGER JG_ACC_GROUP_UNIQUE ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
            return strSQL;
            strSQL = "CREATE TRIGGER JG_ACC_GROUP_UNIQUE ON ACC_LEDGERGROUP WITH ENCRYPTTION AFTER INSERT AS ";
            strSQL = strSQL + "DECLARE @GROUP_NAME char(60) ";
            strSQL = strSQL + "SELECT @GROUP_NAME = REPLACE(GR_NAME,' ','') FROM inserted ";
            strSQL = strSQL + "BEGIN ";
            strSQL = strSQL + "INSERT INTO ACC_GROUP_LEDGER_UNIQUE(GROUP_LEDGER_NAME) VALUES(@GROUP_NAME)";
            strSQL = strSQL + "End ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
            strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_ACC_LEDGER_UNIQUE' AND type = 'TR') ";
            strSQL = strSQL + "DROP TRIGGER JG_ACC_LEDGER_UNIQUE ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
            return strSQL;
            strSQL = "CREATE TRIGGER JG_ACC_LEDGER_UNIQUE ON ACC_LEDGER AFTER INSERT AS ";
            strSQL = strSQL + "DECLARE @LEDGER_NAME char(70) ";
            strSQL = strSQL + "SELECT @LEDGER_NAME = REPLACE(LEDGER_NAME,' ','') FROM inserted ";
            strSQL = strSQL + "BEGIN ";
            strSQL = strSQL + "INSERT INTO ACC_GROUP_LEDGER_UNIQUE(GROUP_LEDGER_NAME) VALUES(@LEDGER_NAME)";
            strSQL = strSQL + "End ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
            return strSQL;
            }
            finally
            {
                gcnmain.Close();
            }
        }
    }

  private static string CreateAccLedgerDeleteTrigger()
  {
      using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
              strSQL = "ALTER TABLE INV_TRAN ALTER COLUMN OUTWARD_SALES_AMOUNT NUMERIC(25,2)";
              cmd.CommandText = strSQL;
              cmd.ExecuteNonQuery();
              strSQL = "ALTER TABLE INV_TRAN ALTER COLUMN OUTWARD_COST_AMOUNT NUMERIC(25,2)";
              cmd.CommandText = strSQL;
              cmd.ExecuteNonQuery();
              strSQL = "ALTER TABLE INV_TRAN ALTER COLUMN INV_TRAN_AMOUNT NUMERIC(25,2)";
              cmd.CommandText = strSQL;
              cmd.ExecuteNonQuery();

              strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_ACC_LEDGER_DELETE' AND type = 'TR') ";
              strSQL = strSQL + "DROP TRIGGER TR_ACC_LEDGER_DELETE ";
              cmd.CommandText = strSQL;
              cmd.ExecuteNonQuery();

              strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_ACC_LEDGER_DELETE' AND type = 'TR') ";
              strSQL = strSQL + "DROP TRIGGER JG_ACC_LEDGER_DELETE ";
              cmd.CommandText = strSQL;
              cmd.ExecuteNonQuery();
              strSQL = "CREATE TRIGGER JG_ACC_LEDGER_DELETE ON ACC_VOUCHER AFTER DELETE AS DECLARE @LEDGER_NAME VARCHAR(60) DECLARE @DEBIT numeric(18,2) ";
              strSQL = strSQL + "SELECT @DEBIT = (VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT), @LEDGER_NAME = LEDGER_NAME FROM deleted BEGIN ";
              strSQL = strSQL + "UPDATE ACC_LEDGER SET LEDGER_CLOSING_BALANCE = LEDGER_CLOSING_BALANCE - @DEBIT WHERE LEDGER_NAME = @LEDGER_NAME END ";
              cmd.CommandText = strSQL;
              cmd.ExecuteNonQuery();
              return strSQL;
          }
          finally
          {
              gcnmain.Close();
          }
      }
  }

  private static string CreateAccLedgerInsertTrigger()
  {
      using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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

              strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_ACC_LEDGER_INSERT' AND type = 'TR') ";
              strSQL = strSQL + "DROP TRIGGER TR_ACC_LEDGER_INSERT ";
              cmd.CommandText = strSQL;
              cmd.ExecuteNonQuery();

              strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_ACC_LEDGER_INSERT' AND type = 'TR') ";
              strSQL = strSQL + "DROP TRIGGER JG_ACC_LEDGER_INSERT ";
              cmd.CommandText = strSQL;
              cmd.ExecuteNonQuery();
              strSQL = "CREATE TRIGGER JG_ACC_LEDGER_INSERT ON ACC_VOUCHER AFTER INSERT AS DECLARE @LEDGER_NAME varchar(60) DECLARE @DEBIT numeric(18,2) ";
              strSQL = strSQL + "SELECT @DEBIT = (VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT), @LEDGER_NAME = LEDGER_NAME FROM inserted BEGIN ";
              strSQL = strSQL + "UPDATE ACC_LEDGER SET LEDGER_CLOSING_BALANCE = LEDGER_CLOSING_BALANCE + @DEBIT WHERE LEDGER_NAME = @LEDGER_NAME End ";
              cmd.CommandText = strSQL;
              cmd.ExecuteNonQuery();
              return strSQL;
          }
          finally
          {
              gcnmain.Close();
          }
      }
  }
private static string CreateStockClosingTrigger()
{
 using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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
    
            strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_CLOSING_DELETE' AND type = 'TR') ";
            strSQL = strSQL + "DROP TRIGGER TR_INV_STOCKITEM_CLOSING_DELETE ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
            strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_CLOSING_INSERT' AND type = 'TR') ";
            strSQL = strSQL + "DROP TRIGGER TR_INV_STOCKITEM_CLOSING_INSERT ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();

            strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_CLOSING_INSERT' AND type = 'TR') ";
            strSQL = strSQL + " DROP TRIGGER JG_INV_STOCKITEM_CLOSING_INSERT ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
            strSQL = "CREATE trigger JG_INV_STOCKITEM_CLOSING_INSERT on INV_TRAN  WITH ENCRYPTION FOR INSERT AS";
            strSQL = strSQL + " UPDATE INV_STOCKITEM_CLOSING SET";
            strSQL = strSQL + " INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE = INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE";
            strSQL = strSQL + " + inserted.INV_TRAN_QUANTITY from INV_STOCKITEM_CLOSING Join inserted";
            strSQL = strSQL + " on INV_STOCKITEM_CLOSING.STOCKITEM_NAME=inserted.STOCKITEM_NAME AND";
            strSQL = strSQL + " INV_STOCKITEM_CLOSING.GODOWNS_NAME = inserted.GODOWNS_NAME";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();

            strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_CLOSING_DELETE' AND type = 'TR') ";
            strSQL = strSQL + " DROP TRIGGER JG_INV_STOCKITEM_CLOSING_DELETE ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
            strSQL = "create trigger JG_INV_STOCKITEM_CLOSING_DELETE on INV_TRAN WITH ENCRYPTION FOR DELETE AS ";
            strSQL = strSQL + " UPDATE INV_STOCKITEM_CLOSING SET ";
            strSQL = strSQL + " INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE=INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE+ ";
            strSQL = strSQL + " (deleted.INV_TRAN_QUANTITY *-1) FROM INV_STOCKITEM_CLOSING ";
            strSQL = strSQL + " JOIN deleted on INV_STOCKITEM_CLOSING.STOCKITEM_NAME=deleted.STOCKITEM_NAME ";
            strSQL = strSQL + " AND INV_STOCKITEM_CLOSING.GODOWNS_NAME=deleted.GODOWNS_NAME ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();

            strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_COST_DELETE' AND type = 'TR') ";
            strSQL = strSQL + " DROP TRIGGER JG_INV_STOCKITEM_COST_DELETE ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();

            strSQL = " CREATE TRIGGER JG_INV_STOCKITEM_COST_DELETE ON INV_TRAN WITH ENCRYPTION AFTER DELETE AS ";
            strSQL = strSQL + " DECLARE @InvTranSerial numeric(18,0) DECLARE @InvVoucherType INT ";
            strSQL = strSQL + " DECLARE @StockItem VARCHAR(60) DECLARE @InvTranDate DATETIME "; 
            strSQL = strSQL + " DECLARE @InvStartDate DATETIME DECLARE @InvEndDate DATETIME ";
            strSQL = strSQL + " DECLARE @InvQty numeric(18,4) DECLARE @InvTranQty numeric(18,4) DECLARE @InvAmt numeric(25,2)";
            strSQL = strSQL + " DECLARE @InvCostRate numeric(25,2) DECLARE @InvCostAmt numeric(25,2) ";

            strSQL = strSQL + " SELECT @InvTranSerial = INV_TRAN_SERIAL,@InvVoucherType = INV_VOUCHER_TYPE,@StockItem = STOCKITEM_NAME,@InvTranDate = INV_DATE,@InvTranQty = INV_TRAN_QUANTITY ";
            strSQL = strSQL + " FROM deleted UPDATE INV_TRAN SET INV_TRAN_RUNNING_QTY = (SELECT SUM(INV_TRAN_QUANTITY) ";
            strSQL = strSQL + " FROM INV_TRAN P WHERE P.INV_DATE <= @InvTranDate AND P.STOCKITEM_NAME = @StockItem) ";
            strSQL = strSQL + " WHERE STOCKITEM_NAME = @StockItem AND INV_DATE = @InvTranDate ";
            strSQL = strSQL + " UPDATE INV_TRAN SET INV_TRAN_RUNNING_QTY = INV_TRAN_RUNNING_QTY - @InvTranQty ";
            strSQL = strSQL + " WHERE INV_DATE > @InvTranDate AND STOCKITEM_NAME = @StockItem IF @InvTranQty < 0 BEGIN ";
            strSQL = strSQL + " SET @InvStartDate = '01-01-1899' SELECT @InvStartDate = INV_DATE FROM INV_TRAN ";
            strSQL = strSQL + " WHERE STOCKITEM_NAME = @StockItem AND INV_DATE < convert(datetime,@InvTranDate,103)  ";
            strSQL = strSQL + " AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE ";
            strSQL = strSQL + " SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) FROM INV_TRAN ";
            strSQL = strSQL + " WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE > convert(datetime,@InvStartDate,103) ";
            strSQL = strSQL + " AND INV_DATE <= convert(datetime,@InvTranDate,103)) ";
            strSQL = strSQL + " AND INV_TRAN_SERIAL <> @InvTranSerial IF @InvQty <> 0 ";
            strSQL = strSQL + " SET @InvCostRate = @InvAmt/@InvQty SET @InvCostAmt = (@InvCostRate * @InvTranQty) ";
            

            strSQL = strSQL + " IF @InvCostAmt IS NULL SET @InvCostAmt = 0 UPDATE INV_TRAN ";
            strSQL = strSQL + " SET OUTWARD_COST_AMOUNT = @InvCostAmt, INV_TRAN_AMOUNT = @InvCostAmt ";
            strSQL = strSQL + " WHERE INV_TRAN_SERIAL = @InvTranSerial END IF @InvTranQty > 0 BEGIN ";
            strSQL = strSQL + " SET @InvStartDate = '01-01-1899' SELECT @InvStartDate = INV_DATE FROM INV_TRAN ";
            strSQL = strSQL + " WHERE STOCKITEM_NAME = @StockItem AND INV_DATE < convert(datetime,@InvTranDate,103)  ";
            strSQL = strSQL + " AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE SET @InvEndDate = '01-01-2099' ";
            strSQL = strSQL + " SELECT @InvEndDate = INV_DATE FROM INV_TRAN WHERE ";
            strSQL = strSQL + " STOCKITEM_NAME = @StockItem AND INV_DATE > convert(datetime,@InvTranDate,103)  AND ";
            strSQL = strSQL + " INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE";
            strSQL = strSQL + " SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) FROM INV_TRAN ";
            strSQL = strSQL + " WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE >= convert(datetime,@InvStartDate,103) ";
            strSQL = strSQL + " AND INV_DATE <= convert(datetime,@InvEndDate,103)) AND (INV_INOUT_FLAG IS NULL OR ";
            strSQL = strSQL + " INV_INOUT_FLAG = 'I') IF @InvQty <> 0 SET @InvCostRate = @InvAmt/@InvQty IF @InvCostRate IS NULL ";
            strSQL = strSQL + " SET @InvCostRate = 0 UPDATE INV_TRAN SET INV_TRAN_RATE = @InvCostRate, INV_TRAN_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate , ";
            strSQL = strSQL + " OUTWARD_COST_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate ";
            strSQL = strSQL + " WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE >= convert(datetime,@InvStartDate,103) ";
            strSQL = strSQL + " AND INV_DATE <= convert(datetime,@InvEndDate,103)) AND INV_TRAN_QUANTITY < 0 END ";
            strSQL = strSQL + " IF @InvTranQty = 0 BEGIN SET @InvStartDate = '01-01-1899' ";
            strSQL = strSQL + " SELECT @InvStartDate = INV_DATE FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND ";
            strSQL = strSQL + " INV_DATE < convert(datetime,@InvTranDate,103)  AND INV_TRAN_RUNNING_QTY = 0 ";
            strSQL = strSQL + " ORDER BY INV_DATE SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) ";
            strSQL = strSQL + " FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND ";
            strSQL = strSQL + " (INV_DATE >= convert(datetime,@InvStartDate,103) AND ";
            strSQL = strSQL + " INV_DATE <= convert(datetime,@InvTranDate,103)) AND (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') IF @InvQty <> 0 ";
            strSQL = strSQL + " SET @InvCostRate = @InvAmt/@InvQty IF @InvCostRate IS NULL SET @InvCostRate = 0 ";
            strSQL = strSQL + " UPDATE INV_TRAN SET INV_TRAN_RATE = @InvCostRate, ";
            strSQL = strSQL + " INV_TRAN_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate , OUTWARD_COST_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate WHERE STOCKITEM_NAME = @StockItem AND INV_DATE >= @InvTranDate AND INV_TRAN_QUANTITY < 0 END";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();

            strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'JG_INV_STOCKITEM_RUNNING' AND type = 'TR') ";
            strSQL = strSQL + " DROP TRIGGER JG_INV_STOCKITEM_RUNNING ";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
            strSQL = "CREATE TRIGGER JG_INV_STOCKITEM_RUNNING ON INV_TRAN WITH ENCRYPTION AFTER INSERT AS DECLARE @InvTranSerial numeric(18,0) DECLARE @InvVoucherType INT";
            strSQL = strSQL + " DECLARE @StockItem VARCHAR(60) DECLARE @InvTranDate DATETIME DECLARE @InvStartDate DATETIME DECLARE @InvEndDate DATETIME";
            strSQL = strSQL + " DECLARE @InvQty numeric(18,4) DECLARE @InvTranQty numeric(18,4) DECLARE @InvAmt numeric(25,2) DECLARE @InvCostRate numeric(25,2) DECLARE @InvCostAmt numeric(25,2)";

            strSQL = strSQL + " SELECT @InvTranSerial = INV_TRAN_SERIAL,@InvVoucherType = INV_VOUCHER_TYPE,@StockItem = STOCKITEM_NAME,";
            strSQL = strSQL + " @InvTranDate = INV_DATE,@InvTranQty = INV_TRAN_QUANTITY FROM inserted UPDATE INV_TRAN SET";
            strSQL = strSQL + " INV_TRAN_RUNNING_QTY = (SELECT SUM(INV_TRAN_QUANTITY) FROM INV_TRAN P WHERE P.INV_DATE <= @InvTranDate AND P.STOCKITEM_NAME = @StockItem)";
            strSQL = strSQL + " WHERE STOCKITEM_NAME = @StockItem AND INV_DATE = @InvTranDate UPDATE INV_TRAN SET INV_TRAN_RUNNING_QTY = INV_TRAN_RUNNING_QTY + @InvTranQty";
            strSQL = strSQL + " WHERE INV_DATE > @InvTranDate AND STOCKITEM_NAME = @StockItem IF @InvTranQty < 0 BEGIN SET @InvStartDate = '01-01-1899'";
            strSQL = strSQL + " SELECT @InvStartDate = INV_DATE FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND INV_DATE < convert(datetime,@InvTranDate,103)";
            strSQL = strSQL + " AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) FROM INV_TRAN";
            strSQL = strSQL + " WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE > convert(datetime,@InvStartDate,103) AND INV_DATE <= convert(datetime,@InvTranDate,103))";
            strSQL = strSQL + " AND INV_TRAN_SERIAL <> @InvTranSerial IF @InvQty <> 0 SET @InvCostRate = @InvAmt/@InvQty SET @InvCostAmt = (@InvCostRate * @InvTranQty)";
            strSQL = strSQL + " IF @InvCostAmt IS NULL SET @InvCostAmt = 0 UPDATE INV_TRAN SET OUTWARD_COST_AMOUNT = @InvCostAmt, INV_TRAN_AMOUNT = @InvCostAmt";
            strSQL = strSQL + " WHERE INV_TRAN_SERIAL = @InvTranSerial END IF @InvTranQty > 0 BEGIN SET @InvStartDate = '01-01-1899' SELECT @InvStartDate = INV_DATE";
            strSQL = strSQL + " FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND INV_DATE < convert(datetime,@InvTranDate,103)  AND INV_TRAN_RUNNING_QTY = 0";
            strSQL = strSQL + " ORDER BY INV_DATE SET @InvEndDate = '01-01-2099' SELECT @InvEndDate = INV_DATE FROM INV_TRAN";
            strSQL = strSQL + " WHERE STOCKITEM_NAME = @StockItem AND INV_DATE > convert(datetime,@InvTranDate,103)  AND INV_TRAN_RUNNING_QTY = 0";
            strSQL = strSQL + " ORDER BY INV_DATE SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) FROM INV_TRAN";
            strSQL = strSQL + " WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE >= convert(datetime,@InvTranDate,103) AND INV_DATE <= convert(datetime,@InvEndDate,103))";
            strSQL = strSQL + " AND (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') IF @InvQty <> 0 SET @InvCostRate = @InvAmt/@InvQty IF @InvCostRate IS NULL";
            strSQL = strSQL + " SET @InvCostRate = 0 UPDATE INV_TRAN SET INV_TRAN_RATE = @InvCostRate, INV_TRAN_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate ,";
            strSQL = strSQL + " OUTWARD_COST_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE >= convert(datetime,@InvTranDate,103)";
            strSQL = strSQL + " AND INV_DATE <= convert(datetime,@InvEndDate,103)) AND INV_TRAN_QUANTITY < 0 END IF @InvTranQty = 0 BEGIN SET @InvStartDate = '01-01-1899'";
            strSQL = strSQL + " SELECT @InvStartDate = INV_DATE FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND INV_DATE < convert(datetime,@InvTranDate,103)";
            strSQL = strSQL + " AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE SET @InvEndDate = '01-01-2099'";
            strSQL = strSQL + " SELECT @InvEndDate = INV_DATE FROM INV_TRAN WHERE STOCKITEM_NAME = @StockItem AND INV_DATE > convert(datetime,@InvTranDate,103)";
            strSQL = strSQL + " AND INV_TRAN_RUNNING_QTY = 0 ORDER BY INV_DATE SELECT @InvQty = SUM(INV_TRAN_QUANTITY),@InvAmt = SUM(INV_TRAN_AMOUNT) FROM INV_TRAN";
            strSQL = strSQL + " WHERE STOCKITEM_NAME = @StockItem AND (INV_DATE >= convert(datetime,@InvTranDate,103) AND INV_DATE <= convert(datetime,@InvEndDate,103))";
            strSQL = strSQL + " AND (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') IF @InvQty <> 0 SET @InvCostRate = @InvAmt/@InvQty IF @InvCostRate IS NULL";
            strSQL = strSQL + " SET @InvCostRate = 0 UPDATE INV_TRAN SET INV_TRAN_RATE = @InvCostRate, INV_TRAN_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate ,";
            strSQL = strSQL + " OUTWARD_COST_AMOUNT = INV_TRAN_QUANTITY * @InvCostRate WHERE STOCKITEM_NAME = @StockItem AND";
            strSQL = strSQL + " (INV_DATE >= convert(datetime,@InvTranDate,103) AND INV_DATE <= convert(datetime,@InvEndDate,103)) AND INV_TRAN_QUANTITY < 0 END";
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
            //'    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_CLOSING_DELETE' AND type = 'TR') "
            //'    strSQL = strSQL + " DROP TRIGGER TR_INV_STOCKITEM_CLOSING_DELETE "
            //'    gcnMain.Execute strSQL
            //'    strSQL = "CREATE TRIGGER TR_INV_STOCKITEM_CLOSING_DELETE  ON INV_TRAN WITH ENCRYPTION FOR DELETE AS UPDATE INV_STOCKITEM_CLOSING SET INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE = INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE + (deleted.INV_TRAN_QUANTITY * -1) FROM INV_STOCKITEM_CLOSING JOIN deleted ON INV_STOCKITEM_CLOSING.STOCKITEM_NAME = deleted.STOCKITEM_NAME AND INV_STOCKITEM_CLOSING.GODOWNS_NAME = deleted.GODOWNS_NAME"
            //'    gcnMain.Execute strSQL
            //'    strSQL = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'TR_INV_STOCKITEM_CLOSING_INSERT' AND type = 'TR') "
            //'    strSQL = strSQL + " DROP TRIGGER TR_INV_STOCKITEM_CLOSING_INSERT "
            //'    gcnMain.Execute strSQL
            //'    strSQL = "CREATE TRIGGER TR_INV_STOCKITEM_CLOSING_INSERT ON INV_TRAN WITH ENCRYPTION FOR INSERT AS UPDATE INV_STOCKITEM_CLOSING SET INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE = INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE + inserted.INV_TRAN_QUANTITY From INV_STOCKITEM_CLOSING JOIN inserted on INV_STOCKITEM_CLOSING.STOCKITEM_NAME = inserted.STOCKITEM_NAME AND INV_STOCKITEM_CLOSING.GODOWNS_NAME = inserted.GODOWNS_NAME"
            //'    gcnMain.Execute strSQL
            //''New
            //'CREATE TRIGGER JG_INV_STOCKITEM_RUNNING ON INV_TRAN AFTER INSERT AS DECLARE @STOCKITEM VARCHAR(60) DECLARE @INVQTY FLOAT DECLARE @INVAMT FLOAT
            //'DECLARE @INVCOSTRATE VARCHAR(60) DECLARE @FRDATE DATETIME DECLARE @TODATE DATETIME SELECT @FRDATE=COMPANY_FINICIAL_YEAR_FROM,
            //'@TODATE=COMPANY_FINICIAL_YEAR_TO FROM ACC_COMPANY SELECT @STOCKITEM=STOCKITEM_NAME FROM INSERTED SELECT @INVQTY=ISNULL(SUM(INWARD_QUANTITY),0),
            //'@INVAMT=ISNULL(SUM(INV_TRAN_AMOUNT),0) FROM INV_TRAN WHERE (INV_INOUT_FLAG='I' OR INV_INOUT_FLAG IS NULL) AND INV_VOUCHER_TYPE <> 23
            //'AND STOCKITEM_NAME=@STOCKITEM IF @INVQTY <> 0 BEGIN SET @INVCOSTRATE=@INVAMT/@INVQTY UPDATE INV_TRAN SET INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * @INVCOSTRATE,
            //'OUTWARD_COST_AMOUNT=OUTWARD_QUANTITY * @INVCOSTRATE WHERE STOCKITEM_NAME=@STOCKITEM AND INV_INOUT_FLAG='O' AND (INV_DATE BETWEEN @FRDATE AND @TODATE)
            //'UPDATE INV_TRAN SET INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * @INVCOSTRATE,INWARD_AMOUNT=INWARD_QUANTITY * @INVCOSTRATE WHERE STOCKITEM_NAME=@STOCKITEM
            //'AND INV_INOUT_FLAG='I' AND INV_VOUCHER_TYPE = 23 AND (INV_DATE BETWEEN @FRDATE AND @TODATE) END

            //cmd.CommandText = strSQL;
            //cmd.ExecuteNonQuery();
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
