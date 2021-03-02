using Dutility;
using JA.LAST.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;


namespace JA.LAST.DAL
{
    class DalLast
    {

        #region "DisplayItemGroup"



        public List<ModelLast> mDisplayItemGroup2(string strDeComID, string vstrItemGroup, string vstrDate, string vstrTDate, int intMode)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ModelLast> oogrp = new List<ModelLast>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            //level=1,Item=2,Group=3

            strSQL = "SELECT * FROM INV_SALES_PRICE INNER JOIN ";
            strSQL = strSQL + "INV_STOCKITEM ON INV_SALES_PRICE.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN ";
            strSQL = strSQL + "INV_STOCKGROUP ON INV_STOCKITEM.STOCKGROUP_NAME = INV_STOCKGROUP.STOCKGROUP_NAME ";

            if (intMode == 1)
            {
                strSQL = strSQL + "WHERE  PRICE_LEVEL_NAME='" + vstrItemGroup + "' ";
                strSQL = strSQL + "and (INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE = " + Utility.cvtSQLDateString(vstrDate) + ")  AND (INV_SALES_PRICE.MODULE_STATUS = 0) ";
                strSQL = strSQL + "ORDER BY INV_SALES_PRICE.STOCKITEM_NAME, INV_SALES_PRICE.SALES_PRICE_SERIAL ";
            }
            if (intMode == 2)
            {
                strSQL = strSQL + "WHERE  INV_SALES_PRICE.STOCKITEM_NAME ='" + vstrItemGroup + "' ";
                strSQL = strSQL + "and(INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE BETWEEN " + Utility.cvtSQLDateString(vstrDate) + " AND " + Utility.cvtSQLDateString(vstrTDate) + ") AND (INV_SALES_PRICE.MODULE_STATUS = 0) ";
                strSQL = strSQL + "ORDER BY INV_SALES_PRICE.STOCKITEM_NAME, INV_SALES_PRICE.SALES_PRICE_SERIAL ";
            }

            if (intMode == 3)
            {
                strSQL = strSQL + "WHERE  (INV_STOCKGROUP.STOCKGROUP_PRIMARY = '" + vstrItemGroup + "') ";
                strSQL = strSQL + "and(INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE BETWEEN " + Utility.cvtSQLDateString(vstrDate) + " AND " + Utility.cvtSQLDateString(vstrTDate) + ") AND (INV_SALES_PRICE.MODULE_STATUS = 0)  ";
                strSQL = strSQL + "ORDER BY INV_SALES_PRICE.STOCKITEM_NAME,INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE, INV_SALES_PRICE.SALES_PRICE_SERIAL ";
            }

            if (intMode == 4)
            {
                strSQL = strSQL + "WHERE  INV_STOCKITEM.STOCKGROUP_NAME ='" + vstrItemGroup + "' ";
                strSQL = strSQL + "and(INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE BETWEEN " + Utility.cvtSQLDateString(vstrDate) + " AND " + Utility.cvtSQLDateString(vstrTDate) + ") AND (INV_SALES_PRICE.MODULE_STATUS = 0) ";
                strSQL = strSQL + "ORDER BY INV_SALES_PRICE.STOCKITEM_NAME, INV_SALES_PRICE.SALES_PRICE_SERIAL ";
            }

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {

                    ModelLast ogrp = new ModelLast();
                    ogrp.dblBillRate = Convert.ToDouble(drGetGroup["FROM_QTY"].ToString());
                    //ogrp.dblTO_QTY = Convert.ToDouble(drGetGroup["TO_QTY"].ToString());
                    //ogrp.strRate = Convert.ToDouble(drGetGroup["SALES_PRICE_AMOUNT"].ToString());
                    //if (drGetGroup["PERCENT_DISCOUNT"].ToString() != "")
                    //{
                    //    ogrp.strDiscountAmount = Convert.ToDouble(drGetGroup["PERCENT_DISCOUNT"].ToString());
                    //}
                    //ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    //ogrp.strStockGroupPrimary = drGetGroup["PRICE_LEVEL_NAME"].ToString();
                    //ogrp.strEffDate = Convert.ToDateTime(drGetGroup["SALES_PRICE_EFFECTIVE_DATE"]).ToString("dd-MM-yyyy");
                    //ogrp.strStockGroupName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    //ogrp.strLedgerGroupParent = drGetGroup["STOCKGROUP_PARENT"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        #endregion

        public string connstring { get; set; }
    }
}
