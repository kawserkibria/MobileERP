using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dutility
{
    public class UpdateAvgCost
    {
        public class AVGItem
        {
            public string strItemName { get; set; }
            public string strBillTranKey { get; set; }
            public double dblRate { get; set; }
            public double dblAmnt { get; set; }
            public int intVoucherType { get; set; }


            public string strDate = "", strInoutFlag = "";
            public long lngInvSerial;

            public double dblqty = 0, dblCostRate = 0, dblInwardAmount = 0, dblOutwardAmount = 0,
                                  dblRunningQty = 0, dblOutwrdqnty = 0, dblOutCostAmount = 0,
                                  dblCostQnty = 0, dblCostXQnt = 0, dblCostBeforeInward = 0, dblInvCostAmt = 0;


        }
        public static string gUpdateAvgCost(string strcomID, string vstrItemName)
        {

            string strSQL;
            string conDb;
            SqlDataReader dr;
            conDb = Utility.SQLConnstringComSwitch(strcomID);
            List<AVGItem> objItem = new List<AVGItem>();
            List<AVGItem> objItemUpdate = new List<AVGItem>();
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;
                try
                {
                    strSQL = "UPDATE INV_TRAN SET INWARD_AMOUNT=INWARD_QUANTITY * INV_TRAN_RATE WHERE INV_INOUT_FLAG='I' ";
                    strSQL = strSQL + "AND STOCKITEM_NAME='" + vstrItemName.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "SELECT  COMP_VOUCHER_TYPE, BILL_TRAN_KEY,BILL_RATE,(BILL_QUANTITY * BILL_RATE)AS AMT FROM ACC_BILL_TRAN WHERE STOCKITEM_NAME='" + vstrItemName.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        AVGItem ooItem = new AVGItem();
                        ooItem.intVoucherType = Convert.ToInt16(dr["COMP_VOUCHER_TYPE"].ToString());
                        ooItem.strBillTranKey = dr["BILL_TRAN_KEY"].ToString();
                        ooItem.dblRate = Convert.ToDouble(dr["BILL_RATE"].ToString());
                        ooItem.dblAmnt = Convert.ToDouble(dr["AMT"].ToString());
                        objItem.Add(ooItem);
                    }
                    dr.Close();
                    if (objItem.Count > 0)
                    {
                        foreach (AVGItem otem in objItem)
                        {
                            strSQL = "UPDATE INV_TRAN SET INV_TRAN_RATE=" + otem.dblRate + " ";
                            strSQL = strSQL + " ,INV_TRAN_AMOUNT=" + otem.dblAmnt + "";
                            if (otem.intVoucherType == 33 || otem.intVoucherType == 13 || otem.intVoucherType == 27)
                            {
                                strSQL = strSQL + " ,INWARD_AMOUNT=" + otem.dblAmnt + "";
                            }
                            strSQL = strSQL + " WHERE INV_TRAN_KEY='" + otem.strBillTranKey + "' ";
                        }
                    }

                    strSQL = "SELECT INV_TRAN_SERIAL,INV_VOUCHER_TYPE,STOCKITEM_NAME,";
                    strSQL = strSQL + "INV_DATE,INV_TRAN_QUANTITY,INWARD_AMOUNT,OUTWARD_SALES_AMOUNT,INV_TRAN_AMOUNT,OUTWARD_COST_AMOUNT ";
                    strSQL = strSQL + ",INV_INOUT_FLAG,ISNULL(INV_LOG_NO,' ') AS INV_LOG_NO,INV_TRAN_RUNNING_QTY,INV_TRAN_RATE,OUTWARD_QUANTITY FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE STOCKITEM_NAME='" + vstrItemName.Replace("'", "''") + "' ";
                    strSQL = strSQL + "ORDER BY INV_DATE,INWARD_QUANTITY DESC,INV_REF_NO ASC ";
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        AVGItem ooItemUpdate = new AVGItem();
                        if (vstrItemName != dr["STOCKITEM_NAME"].ToString().Trim())
                        {
                            ooItemUpdate.dblRunningQty = 0;
                            ooItemUpdate.dblCostRate = 0;
                            ooItemUpdate.dblCostQnty = 0;
                            ooItemUpdate.dblCostXQnt = 0;
                            ooItemUpdate.dblCostBeforeInward = 0;
                            ooItemUpdate.dblOutCostAmount = 0;
                            ooItemUpdate.dblInwardAmount = 0;
                            ooItemUpdate.dblOutwardAmount = 0;
                            ooItemUpdate.dblRate = 0;
                            ooItemUpdate.dblqty = 0;
                        }
                        ooItemUpdate.strItemName = vstrItemName;
                        ooItemUpdate.lngInvSerial = Convert.ToInt32(dr["INV_TRAN_SERIAL"].ToString());
                        ooItemUpdate.intVoucherType = Convert.ToInt32(dr["INV_VOUCHER_TYPE"]);
                        ooItemUpdate.dblqty = Convert.ToDouble(dr["INV_TRAN_QUANTITY"].ToString());
                        ooItemUpdate.dblRate = Convert.ToDouble(dr["INV_TRAN_RATE"].ToString());
                        ooItemUpdate.strDate = dr["INV_DATE"].ToString();
                        ooItemUpdate.dblOutwrdqnty = Convert.ToDouble(dr["OUTWARD_QUANTITY"].ToString());
                        if (Convert.ToDouble(dr["OUTWARD_COST_AMOUNT"]) != 0)
                        {
                            ooItemUpdate.dblOutCostAmount = Convert.ToDouble(dr["OUTWARD_COST_AMOUNT"]);
                        }
                        //dblBalanceQty = rsGet.Fields("INV_TRAN_RUNNING_QTY").Value
                        if (dr["INV_INOUT_FLAG"] != "")
                        {
                            ooItemUpdate.strInoutFlag = dr["INV_INOUT_FLAG"].ToString();
                        }

                        if (Convert.ToInt32(dr["INV_VOUCHER_TYPE"]) == 13)
                        {
                            ooItemUpdate.dblRunningQty = Math.Abs(ooItemUpdate.dblqty) + ooItemUpdate.dblRunningQty;
                        }
                        else
                        {
                            ooItemUpdate.dblRunningQty = ooItemUpdate.dblqty + ooItemUpdate.dblRunningQty;
                        }
                        if (ooItemUpdate.dblRunningQty == 0)
                        {
                            ooItemUpdate.dblInwardAmount = 0;
                        }

                        if (ooItemUpdate.intVoucherType == 0 || ooItemUpdate.intVoucherType == 13)
                        {
                            ooItemUpdate.dblCostRate = ooItemUpdate.dblRate;
                        }
                        if (ooItemUpdate.intVoucherType == 33 || ooItemUpdate.intVoucherType == 27)
                        {
                            ooItemUpdate.dblInwardAmount = ooItemUpdate.dblOutwardAmount + ooItemUpdate.dblInwardAmount + Convert.ToDouble(dr["INWARD_AMOUNT"]);
                            if (ooItemUpdate.dblRunningQty > 0)
                            {
                                ooItemUpdate.dblCostRate = Math.Round(ooItemUpdate.dblInwardAmount / ooItemUpdate.dblRunningQty, 2);
                            }
                            else
                            {
                                ooItemUpdate.dblCostRate = ooItemUpdate.dblCostRate;
                            }
                            ooItemUpdate.dblOutwardAmount = 0;

                        }
                        else
                        {
                            ooItemUpdate.dblOutwardAmount = Math.Round(ooItemUpdate.dblCostRate * ooItemUpdate.dblRunningQty, 2);
                            ooItemUpdate.dblInwardAmount = 0;
                        }
                        if (ooItemUpdate.strInoutFlag == "I" && ooItemUpdate.dblCostRate == 0)
                        {

                        }
                        else
                        {
                            ooItemUpdate.dblCostRate = ooItemUpdate.dblCostRate;
                            ooItemUpdate.dblCostXQnt = Convert.ToDouble(dr["INV_TRAN_QUANTITY"]);
                        }
                        ooItemUpdate.dblCostQnty = ooItemUpdate.dblRunningQty;
                        ooItemUpdate.dblCostBeforeInward = Math.Round((ooItemUpdate.dblCostRate * ooItemUpdate.dblCostQnty), 2);
                        objItemUpdate.Add(ooItemUpdate);
                    }

                    dr.Close();
                    if (objItemUpdate.Count > 0)
                    {

                        foreach (AVGItem ooUpdate in objItemUpdate)
                        {
                            if (ooUpdate.dblCostQnty < 0)
                            {
                                ooUpdate.dblInvCostAmt = Math.Round((ooUpdate.dblCostRate * ooUpdate.dblCostXQnt), 2);
                                strSQL = "UPDATE INV_TRAN SET OUTWARD_COST_AMOUNT = " + ooUpdate.dblInvCostAmt + ",";
                                if (ooUpdate.intVoucherType == 26)
                                {
                                    strSQL = strSQL + "OUTWARD_SALES_AMOUNT = " + ooUpdate.dblInvCostAmt + ",";
                                }
                                if (ooUpdate.intVoucherType == 23)
                                {
                                    strSQL = strSQL + "OUTWARD_SALES_AMOUNT = " + ooUpdate.dblInvCostAmt + ",";
                                }
                                strSQL = strSQL + "INV_TRAN_AMOUNT = " + ooUpdate.dblInvCostAmt + " ";
                                strSQL = strSQL + "WHERE INV_TRAN_SERIAL = " + ooUpdate.lngInvSerial;
                                strSQL = strSQL + " and STOCKITEM_NAME='" + ooUpdate.strItemName.Replace("'", "''") + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                            if (ooUpdate.dblCostQnty > 0)
                            {

                                ooUpdate.dblInvCostAmt = Math.Round((ooUpdate.dblCostRate * ooUpdate.dblRunningQty), 2);
                                strSQL = "UPDATE INV_TRAN SET OUTWARD_COST_AMOUNT = 0 ";
                                strSQL = strSQL + ",OUTWARD_SALES_AMOUNT = 0 ";
                                strSQL = strSQL + "WHERE INV_TRAN_SERIAL = " + ooUpdate.lngInvSerial;
                                strSQL = strSQL + " and STOCKITEM_NAME='" + ooUpdate.strItemName.Replace("'", "''") + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                if (ooUpdate.strInoutFlag == "I")
                                {
                                    strSQL = "UPDATE INV_TRAN SET ";
                                    strSQL = strSQL + "INV_TRAN_AMOUNT = INV_TRAN_QUANTITY * INV_TRAN_RATE ";
                                    strSQL = strSQL + "WHERE INV_TRAN_SERIAL = " + ooUpdate.lngInvSerial;
                                    strSQL = strSQL + " AND INV_INOUT_FLAG ='I' ";
                                    strSQL = strSQL + " and STOCKITEM_NAME='" + ooUpdate.strItemName.Replace("'", "''") + "' ";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQL = "UPDATE INV_TRAN SET ";
                                    strSQL = strSQL + "INWARD_AMOUNT = INV_TRAN_QUANTITY * " + ooUpdate.dblCostRate + " ";
                                    strSQL = strSQL + "WHERE INV_TRAN_SERIAL = " + ooUpdate.lngInvSerial;
                                    strSQL = strSQL + " AND INV_INOUT_FLAG ='I' ";
                                    strSQL = strSQL + " and STOCKITEM_NAME='" + ooUpdate.strItemName.Replace("'", "''") + "' ";
                                    strSQL = strSQL + " AND INWARD_AMOUNT =0 ";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();


                                    strSQL = "UPDATE INV_TRAN SET ";
                                    strSQL = strSQL + "INWARD_AMOUNT = " + ooUpdate.dblInvCostAmt + " ";
                                    strSQL = strSQL + ",INV_TRAN_AMOUNT = " + ooUpdate.dblInvCostAmt + " ";
                                    strSQL = strSQL + ",INV_TRAN_RATE =  " + ooUpdate.dblCostRate + " ";
                                    strSQL = strSQL + "WHERE INV_TRAN_SERIAL = " + ooUpdate.lngInvSerial;
                                    strSQL = strSQL + " AND INV_INOUT_FLAG ='I' ";
                                    strSQL = strSQL + " AND INV_VOUCHER_TYPE =13 ";
                                    strSQL = strSQL + " AND INV_TRAN_RATE =0 ";
                                    strSQL = strSQL + " and STOCKITEM_NAME='" + ooUpdate.strItemName.Replace("'", "''") + "' ";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                            ooUpdate.dblInvCostAmt = Math.Round((ooUpdate.dblCostRate * ooUpdate.dblCostXQnt), 2);
                            strSQL = "UPDATE INV_TRAN SET OUTWARD_COST_AMOUNT = " + ooUpdate.dblInvCostAmt;
                            strSQL = strSQL + ",INV_TRAN_AMOUNT = " + ooUpdate.dblInvCostAmt + " ";
                            strSQL = strSQL + ",OUTWARD_SALES_AMOUNT =  INV_TRAN_QUANTITY * INV_TRAN_RATE ";
                            strSQL = strSQL + "WHERE INV_TRAN_SERIAL = " + ooUpdate.lngInvSerial;
                            strSQL = strSQL + " AND INV_INOUT_FLAG ='O' ";
                            strSQL = strSQL + " and STOCKITEM_NAME='" + ooUpdate.strItemName.Replace("'", "''") + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();

                            ooUpdate.dblOutCostAmount = 0;
                        }
                    }
                    cmdInsert.Transaction.Commit();
                    return "1";
                }


                catch (Exception ex)
                {
                    return ex.ToString();

                }

            }





        }

    }
}
