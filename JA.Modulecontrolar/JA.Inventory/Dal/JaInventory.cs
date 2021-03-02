using Dutility;
using JA.Inventory.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using JA.CommonInsert;

namespace JA.Inventory.Dal
{
    public class JaInventory
    {
        //public static string strComID = (from item in Utility.Modules select item).FirstOrDefault();
        private string connstring;
            //= Utility.SQLConnstring();
        private string strSQL = "";

        public string gOpenComID(string strID)
        {
            Utility.Modules.Clear();
            Utility.ModuleAdd(strID);
            return strID;
        }
        #region "ParentGroup"
        public List<Invoice> mFillLedgerParentGroup(string strDeComID,int mintLedgerGroup,string strSeelction)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> ooLed = new List<Invoice>();
            if (strSeelction == "Sales")
            {
                strSQL = "SELECT '' code, '' LEDGER_NAME,GR_NAME LEDGER_PARENT_GROUP FROM ACC_LEDGERGROUP ";
                strSQL = strSQL + "WHERE GR_GROUP  = " + mintLedgerGroup + " ";
                strSQL = strSQL + "ORDER BY GR_NAME";
            }
            else
            {
                strSQL = "SELECT distinct '' code, '' LEDGER_NAME,LEDGER_PARENT_GROUP,LEDGER_DEFAULT,";
                strSQL = strSQL + "LEDGER_OPENING_BALANCE FROM ACC_LEDGER ";
                strSQL = strSQL + "WHERE LEDGER_GROUP = " + mintLedgerGroup + " ";
                strSQL = strSQL + "ORDER BY LEDGER_NAME ASC ";
            }
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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
                    Invoice ogrp = new Invoice();

                    if (drGetGroup["code"].ToString() != "")
                    {
                        ogrp.strTeritorryCode = drGetGroup["code"].ToString();
                    }
                    else
                    {
                        ogrp.strTeritorryCode = "";
                    }
                    ogrp.strLedgerName = drGetGroup["LEDGER_PARENT_GROUP"].ToString();
                    ogrp.strMereString = drGetGroup["code"].ToString() + drGetGroup["LEDGER_PARENT_GROUP"].ToString();
                    ooLed.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ooLed;

            }
        }
        #endregion
        #region "Group"
        public List<StockGroup> mLoadStockGroup(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockGroup> oogrp = new List<StockGroup>();

            strSQL = "SELECT STOCKGROUP_NAME FROM INV_STOCKGROUP ORDER BY STOCKGROUP_NAME ";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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
                    StockGroup ogrp = new StockGroup();
                    ogrp.GroupName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockGroup> mDisplayRecord(string strDeComID, long vstrPrimaryKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockGroup> oogrp = new List<StockGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKGROUP_NAME,STOCKGROUP_PRIMARY,STOCKGROUP_PARENT,GR_NAME,STOCKGROUP_USE_PACK_SIZE,G_STATUS FROM INV_STOCKGROUP WHERE STOCKGROUP_SERIAL = " + vstrPrimaryKey + "";
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
                    StockGroup ogrp = new StockGroup();
                    ogrp.GroupName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    if (drGetGroup["STOCKGROUP_NAME"].ToString() == drGetGroup["STOCKGROUP_PRIMARY"].ToString())
                    {
                        ogrp.GroupUnder = "Primary";
                    }
                    else
                    {
                        ogrp.GroupUnder = drGetGroup["STOCKGROUP_PARENT"].ToString();
                    }
                    if (drGetGroup["GR_NAME"].ToString() != "")
                    {
                        ogrp.GrName = drGetGroup["GR_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.GrName = "";
                    }

                    if (drGetGroup["STOCKGROUP_USE_PACK_SIZE"].ToString() == "0")
                    {
                        ogrp.strPackSize = "No";
                    }
                    else
                    {
                        ogrp.strPackSize = "Yes";
                    }
                    if (drGetGroup["G_STATUS"].ToString() == "0")
                    {
                        ogrp.strStatus = "Yes";
                    }
                    else
                    {
                        ogrp.strStatus = "No";
                    }
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockGroup> mFillStockGroupList(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockGroup> oogrp = new List<StockGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKGROUP_SERIAL, STOCKGROUP_NAME, STOCKGROUP_PARENT,STOCKGROUP_ONE_DOWN, STOCKGROUP_PRIMARY,STOCKGROUP_NAME_DEFAULT ";
            strSQL = strSQL + "FROM INV_STOCKGROUP ORDER BY STOCKGROUP_NAME ASC ";
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
                    StockGroup ogrp = new StockGroup();
                    ogrp.lngslNo = Convert.ToInt64(drGetGroup["STOCKGROUP_SERIAL"].ToString());
                    ogrp.GroupName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    ogrp.GroupUnder = drGetGroup["STOCKGROUP_PARENT"].ToString();
                    ogrp.strPrimary = drGetGroup["STOCKGROUP_PRIMARY"].ToString();
                    if (drGetGroup["STOCKGROUP_ONE_DOWN"].ToString() != "")
                    {
                        ogrp.strOneDown = drGetGroup["STOCKGROUP_ONE_DOWN"].ToString();
                    }
                    else
                    {
                        ogrp.strOneDown = "";
                    }

                    if (drGetGroup["STOCKGROUP_NAME_DEFAULT"].ToString() != "")
                    {
                        ogrp.strDefaultFroup = drGetGroup["STOCKGROUP_NAME_DEFAULT"].ToString();
                    }
                    else
                    {
                        ogrp.strDefaultFroup = "";
                    }
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertGroup(string strDeComID, string vstrName, string vstrUnder, string vstrGrName, int intpacksize, int intStatus)
        {

            string strGroup, strSQL, strPrimary, strParent = "", strOneDown = "";
            long lngGrType = 0, lngManuFacPrimary = 0, lngManuFacSecondary = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();

                //strPrimary = Utility.GetEndGroup(vstrUnder);
                strPrimary = vstrUnder;
                strGroup = vstrName.Replace("'", "''");
                strParent = vstrUnder.Replace("'", "''");

                SqlDataReader drGetGroup;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "SELECT STOCKGROUP_PRIMARY,STOCKGROUP_LEVEL,STOCKGROUP_PARENT,STOCKGROUP_ONE_DOWN,";
                strSQL = strSQL + "STOCKGROUP_PRIMARY_TYPE,STOCKGROUP_SECONDARY_TYPE FROM INV_STOCKGROUP ";
                strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + strParent + "' ";
                cmdInsert.CommandText = strSQL;
                drGetGroup = cmdInsert.ExecuteReader();
                if (drGetGroup.Read())
                {
                    lngGrType = Convert.ToInt32(drGetGroup["STOCKGROUP_LEVEL"]) + 1;
                    lngManuFacPrimary = Convert.ToInt32(drGetGroup["STOCKGROUP_PRIMARY_TYPE"].ToString());
                    lngManuFacSecondary = Convert.ToInt32(drGetGroup["STOCKGROUP_SECONDARY_TYPE"].ToString());
                    if (drGetGroup["STOCKGROUP_PRIMARY"].ToString() == strParent)
                    {
                        strOneDown = strGroup;
                        strPrimary = strParent;
                    }
                    else
                    {
                        strPrimary = drGetGroup["STOCKGROUP_PRIMARY"].ToString();
                        strOneDown = drGetGroup["STOCKGROUP_PARENT"].ToString();
                    }
                }
                drGetGroup.Close();
                if (vstrUnder.ToUpper() == "PRIMARY")
                {
                    strParent = strGroup;
                    strPrimary = strGroup;
                    strOneDown = strGroup;
                    lngGrType = (long)Utility.GROUP_TYPE.gtMAIN_GROUP;
                }


                strSQL = "INSERT INTO INV_STOCKGROUP";
                strSQL = strSQL + "(STOCKGROUP_NAME,STOCKGROUP_PARENT,STOCKGROUP_ONE_DOWN,STOCKGROUP_PRIMARY,";
                strSQL = strSQL + "STOCKGROUP_LEVEL,STOCKGROUP_PRIMARY_TYPE,STOCKGROUP_SECONDARY_TYPE,";
                if (vstrGrName != "")
                {
                    strSQL = strSQL + "GR_NAME,";
                }
                strSQL = strSQL + "STOCKGROUP_USE_PACK_SIZE,G_STATUS) ";
                strSQL = strSQL + "VALUES(";
                strSQL = strSQL + "'" + strGroup + "','" + strParent + "',";
                strSQL = strSQL + "'" + strOneDown + "','" + strPrimary + "',";
                strSQL = strSQL + lngGrType + "," + lngManuFacPrimary + "," + lngManuFacSecondary + " ";
                if (vstrGrName != "")
                {
                    strSQL = strSQL + ",'" + vstrGrName + "'";
                }

                strSQL = strSQL + "," + intpacksize + " ";
                strSQL = strSQL + "," + intStatus + " ";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Transaction.Commit();
                gcnMain.Close();
                return "1";
                //    do
                //    {
                //        if (lngGrType == 1 )
                //        {
                //            blnInsert = true;
                //        }
                //        strSQL = "SELECT STOCKGROUP_PARENT,STOCKGROUP_LEVEL FROM INV_STOCKGROUP ";
                //        strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + strGroup + "' ";
                //        SqlDataReader dr1;
                //        cmdInsert.CommandText = strSQL;
                //        dr1 = cmdInsert.ExecuteReader();
                //        if (dr1.Read())
                //        {
                //            strParent = dr1["STOCKGROUP_PARENT"].ToString().Replace("'", "''");
                //            //lngGroupLavel = (long)dr1["GR_LEVEL"];
                //            lngType = long.Parse(dr1["STOCKGROUP_LEVEL"].ToString());
                //        }

                //        dr1.Close();
                //        if (lngGrType == 1)
                //        {
                //            blnInsert = true;
                //        }
                //        strGroup = strParent;

                //    }

                //    while (blnInsert == false);
            }




        }
        public string mUpdateGroup(string strDeComID, long vstrPrimaryKey, string vstrName, string vstrUnder, string vstrGrName, int intpacksize, int intStatus)
        {

            string strGroup, strSQL, strPrimary = "", strParent = "", strOneDown = "", strOldLedgerGroup = "";
            long lngGrType = 0, lngManuFacPrimary = 0, lngManuFacSecondary = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();

                strPrimary = Utility.GetEndGroup(strDeComID, vstrUnder).ToString().Replace("'", "''");
                strGroup = vstrName.Replace("'", "''");
                strParent = vstrUnder.Replace("'", "''");

                SqlDataReader drGetGroup;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "SELECT STOCKGROUP_NAME FROM INV_STOCKGROUP";
                strSQL = strSQL + " WHERE STOCKGROUP_SERIAL = " + vstrPrimaryKey + "";
                cmdInsert.CommandText = strSQL;
                drGetGroup = cmdInsert.ExecuteReader();
                if (drGetGroup.Read())
                {
                    strOldLedgerGroup = drGetGroup["STOCKGROUP_NAME"].ToString().Replace("'", "''");
                }

                drGetGroup.Close();
                strSQL = "SELECT STOCKGROUP_PRIMARY,STOCKGROUP_LEVEL,STOCKGROUP_PARENT,STOCKGROUP_ONE_DOWN,";
                strSQL = strSQL + "STOCKGROUP_PRIMARY_TYPE,STOCKGROUP_SECONDARY_TYPE FROM INV_STOCKGROUP ";
                strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + strParent + "' ";
                cmdInsert.CommandText = strSQL;
                drGetGroup = cmdInsert.ExecuteReader();
                if (drGetGroup.Read())
                {
                    lngGrType = Convert.ToInt32(drGetGroup["STOCKGROUP_LEVEL"]) + 1;
                    lngManuFacPrimary = Convert.ToInt32(drGetGroup["STOCKGROUP_PRIMARY_TYPE"].ToString());
                    lngManuFacSecondary = Convert.ToInt32(drGetGroup["STOCKGROUP_SECONDARY_TYPE"].ToString());
                    if (drGetGroup["STOCKGROUP_PRIMARY"].ToString() == strParent)
                    {
                        strOneDown = strGroup;
                        strPrimary = strParent;
                    }
                    else
                    {
                        strPrimary = drGetGroup["STOCKGROUP_PRIMARY"].ToString();
                        strOneDown = drGetGroup["STOCKGROUP_PARENT"].ToString();
                    }
                }
                drGetGroup.Close();
                if (vstrUnder.ToUpper() == "PRIMARY")
                {
                    strParent = strGroup;
                    strPrimary = strGroup;
                    strOneDown = strGroup;
                    lngGrType = (long)Utility.GROUP_TYPE.gtMAIN_GROUP;
                }

                strSQL = "UPDATE INV_STOCKGROUP ";
                strSQL = strSQL + "SET STOCKGROUP_NAME = '" + strGroup + "',";
                strSQL = strSQL + "STOCKGROUP_PARENT = '" + strParent + "', ";
                strSQL = strSQL + "STOCKGROUP_ONE_DOWN = '" + strOneDown + "',";
                strSQL = strSQL + "STOCKGROUP_PRIMARY = '" + strPrimary + "', ";
                strSQL = strSQL + "STOCKGROUP_LEVEL = " + lngGrType + ",";
                strSQL = strSQL + "STOCKGROUP_PRIMARY_TYPE = " + lngManuFacPrimary + " ";
                if (vstrGrName != "")
                {
                    strSQL = strSQL + ",GR_NAME = '" + vstrGrName + "'";
                }
                else
                {
                    strSQL = strSQL + ",GR_NAME = NULL";
                }
                strSQL = strSQL + ",STOCKGROUP_USE_PACK_SIZE = " + intpacksize + " ";
                strSQL = strSQL + ",G_STATUS = " + intStatus + " ";
                
                strSQL = strSQL + "WHERE STOCKGROUP_SERIAL = " + vstrPrimaryKey + " ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE INV_STOCKGROUP SET STOCKGROUP_PARENT = '" + strGroup + "' ";
                strSQL = strSQL + "WHERE STOCKGROUP_PARENT = '" + strOldLedgerGroup + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE INV_STOCKGROUP SET STOCKGROUP_ONE_DOWN = '" + strGroup + "' ";
                strSQL = strSQL + "WHERE STOCKGROUP_ONE_DOWN = '" + strOldLedgerGroup + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "UPDATE INV_STOCKGROUP SET STOCKGROUP_PRIMARY = '" + strPrimary + "' ";
                strSQL = strSQL + "WHERE STOCKGROUP_PRIMARY = '" + strOldLedgerGroup + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_PRIMARY_GROUP = '" + strParent + "' ";
                strSQL = strSQL + "WHERE STOCKITEM_PRIMARY_GROUP = '" + strOldLedgerGroup + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                for (int i = 1; i <= 4; i++)
                {
                    strSQL = "SELECT STOCKGROUP_NAME FROM INV_STOCKGROUP WHERE STOCKGROUP_PARENT = '" + strOldLedgerGroup + "' ";
                    cmdInsert.CommandText = strSQL;
                    drGetGroup = cmdInsert.ExecuteReader();
                    if (drGetGroup.Read())
                    {
                        strOldLedgerGroup = drGetGroup["STOCKGROUP_NAME"].ToString() + "~" + strOldLedgerGroup;
                    }
                    drGetGroup.Close();
                }
                drGetGroup.Close();
                if (strOldLedgerGroup != "")
                {
                    strOldLedgerGroup = strOldLedgerGroup.ToString().Substring(0, strOldLedgerGroup.Length - 1);

                    string[] words = strOldLedgerGroup.Split('~');
                    foreach (string name in words)
                    {
                        if (name.ToString() != "")
                        {
                            mUpdateItemDetails(name.ToString(), strPrimary, cmdInsert, gcnMain, drGetGroup);
                        }
                    }
                }



                strSQL = "UPDATE INV_STOCKITEM_TO_GROUP SET  ";
                strSQL = strSQL + "STOCKGROUP_NAME = '" + strGroup + "' ";
                strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + strOldLedgerGroup + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                mUpdateLabel(strPrimary, cmdInsert, gcnMain, drGetGroup);

                cmdInsert.Transaction.Commit();
                gcnMain.Close();
                drGetGroup.Close();
                return "1";
            }

        }
        public string mDeleteStockGroup(string strDeComID, long vlngGroupPrimary)
        {
            string strGroupName = "", strResponse = "", strDefaultName = "";
            bool blnDelete = false;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();

                    SqlDataReader rsGet;
                    SqlCommand cmdDelete = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdDelete.Connection = gcnMain;
                    cmdDelete.Transaction = myTrans;
                    strSQL = "SELECT STOCKGROUP_NAME, STOCKGROUP_PARENT,STOCKGROUP_NAME_DEFAULT, STOCKGROUP_PRIMARY FROM INV_STOCKGROUP WHERE STOCKGROUP_SERIAL = " + vlngGroupPrimary + " ";
                    cmdDelete.CommandText = strSQL;
                    rsGet = cmdDelete.ExecuteReader();
                    if (rsGet.Read())
                    {
                        strGroupName = rsGet["STOCKGROUP_NAME"].ToString();
                        if (rsGet["STOCKGROUP_NAME_DEFAULT"].ToString() != "")
                        {
                            strDefaultName = rsGet["STOCKGROUP_NAME_DEFAULT"].ToString();
                        }
                        else
                        {
                            strDefaultName = "";
                        }
                    }
                    rsGet.Close();
                    strSQL = "SELECT STOCKGROUP_NAME FROM INV_STOCKGROUP WHERE STOCKGROUP_PARENT = '" + strGroupName + "' ";
                    strSQL = strSQL + "AND STOCKGROUP_NAME <> STOCKGROUP_PARENT ";
                    cmdDelete.CommandText = strSQL;
                    rsGet = cmdDelete.ExecuteReader();
                    if (rsGet.Read())
                    {
                        strResponse = "    Sub-Group/Transaction Found     ";
                        return strResponse;
                    }
                    rsGet.Close();

                    if (strDefaultName != "")
                    {
                        strResponse = "Default Group Can't Delete";
                        return strResponse;
                    }


                    //strSQL = "SELECT STOCKGROUP_NAME FROM INV_STOCKITEM WHERE STOCKGROUP_NAME = '" + strGroupName + "' ";
                    //cmdDelete.CommandText = strSQL;
                    //rsGet = cmdDelete.ExecuteReader();
                    //if (rsGet.Read())
                    //{
                    //    blnDelete = true;
                    //}
                    //rsGet.Close();
                    strGroupName = strGroupName.Replace("'", "''");
                    if (blnDelete == false)
                    {
                        strSQL = "DELETE FROM INV_STOCKGROUP ";
                        strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + strGroupName + "'";
                        cmdDelete.CommandText = strSQL;
                        cmdDelete.ExecuteNonQuery();
                        strResponse = "Deleted...";
                    }
                    cmdDelete.Transaction.Commit();
                    gcnMain.Close();
                    rsGet.Close();
                    return strResponse;
                }

                catch (Exception ex)
                {
                    strResponse = "Transaction Found Cannot Delete...";
                    return strResponse;
                }
                finally
                {
                    gcnMain.Close();
                }

            }

        }
        private void mUpdateLabel(string vstrGroupPrimary, SqlCommand cmd, SqlConnection gcnMain, SqlDataReader rsGet)
        {
            long lngGrType = 0;
            string strGroupParent = "";
            rsGet.Close();
            strSQL = "SELECT STOCKGROUP_NAME,STOCKGROUP_PARENT,STOCKGROUP_LEVEL FROM INV_STOCKGROUP ";
            strSQL = strSQL + "WHERE STOCKGROUP_PRIMARY = '" + vstrGroupPrimary + "' ";
            strSQL = strSQL + "AND STOCKGROUP_LEVEL > 1 ";
            strSQL = strSQL + "ORDER BY STOCKGROUP_LEVEL ";
            cmd.Connection = gcnMain;
            cmd.CommandText = strSQL;
            rsGet = cmd.ExecuteReader();
            while (rsGet.Read())
            {
                strGroupParent = rsGet["STOCKGROUP_PARENT"].ToString() + "," + rsGet["STOCKGROUP_NAME"].ToString() + "~" + strGroupParent;
            }
            rsGet.Close();
            if (strGroupParent != "")
            {
                strGroupParent = strGroupParent.ToString().Substring(0, strGroupParent.Length - 1);

                string[] words = strGroupParent.Split('~');
                foreach (string name in words)
                {
                    string[] ooCost = name.Split(',');
                    if (ooCost.ToString() != "")
                    {
                        strSQL = "SELECT STOCKGROUP_LEVEL FROM INV_STOCKGROUP ";
                        strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + ooCost[0].ToString().Replace("'", "''") + "' ";
                        cmd.CommandText = strSQL;
                        rsGet = cmd.ExecuteReader();
                        if (rsGet.Read())
                        {
                            lngGrType = Convert.ToInt64(rsGet["STOCKGROUP_LEVEL"].ToString()) + 1;
                        }
                        rsGet.Dispose();
                        if (lngGrType > 1)
                        {
                            strSQL = "UPDATE INV_STOCKGROUP SET STOCKGROUP_LEVEL =  " + lngGrType + " ";
                            strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + ooCost[1].ToString().Replace("'", "''") + "' ";
                            cmd.CommandText = strSQL;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }



            rsGet.Close();

        }
        private void mUpdateItemDetails(string vstrOldGroup, string vstrPrimary, SqlCommand cmd, SqlConnection gcnmain, SqlDataReader rsGet)
        {
            string strItemName = "", strItemNew = "", strSQL = "", strItemParent = "", strItemPrimary = "", strField = "";
            bool blnInsert = false;
            rsGet.Close();
            strSQL = "SELECT STOCKITEM_NAME FROM INV_STOCKITEM_TO_GROUP WHERE STOCKGROUP_NAME = '" + vstrOldGroup + "' ";
            cmd.CommandText = strSQL;
            rsGet = cmd.ExecuteReader();
            while (rsGet.Read())
            {
                strItemNew = strItemNew + rsGet["STOCKITEM_NAME"].ToString().Replace("'", "''") + "~";
            }
            rsGet.Close();
            if (strItemNew != "")
            {
                strItemNew = strItemNew.ToString().Substring(0, strItemNew.Length - 1);

                string[] words = strItemNew.Split('~');
                foreach (string name in words)
                {
                    strItemName = words[0];
                    strSQL = "DELETE FROM INV_STOCKITEM_TO_GROUP WHERE STOCKITEM_NAME = '" + strItemName + "' ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "DELETE FROM INV_STOCKITEM_LEVEL WHERE STOCKITEM_NAME = '" + strItemName + "' ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    
                    strSQL = "SELECT STOCKGROUP_NAME,STOCKITEM_PRIMARY_GROUP FROM INV_STOCKITEM ";
                    strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + strItemName + "' ";
                    cmd.CommandText = strSQL;
                    rsGet = cmd.ExecuteReader();
                    if (rsGet.Read())
                    {
                        strItemParent = rsGet["STOCKGROUP_NAME"].ToString().Replace("'", "''");
                        strItemPrimary = vstrPrimary;
                        rsGet.Close();
                        strSQL = "INSERT INTO INV_STOCKITEM_TO_GROUP(STOCKGROUP_NAME, STOCKITEM_NAME) ";
                        strSQL = strSQL + "VALUES('" + strItemParent + "','" + strItemName + "')";
                        cmd.CommandText = strSQL;
                        cmd.ExecuteNonQuery();
                        strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_PRIMARY_GROUP = '" + strItemPrimary + "' ";
                        strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + strItemName + "' ";
                        cmd.CommandText = strSQL;
                        cmd.ExecuteNonQuery();
                        do
                        {
                            strSQL = "SELECT STOCKGROUP_PARENT,STOCKGROUP_LEVEL FROM INV_STOCKGROUP ";
                            strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + strItemParent + "'";
                            cmd.CommandText = strSQL;
                            rsGet = cmd.ExecuteReader();
                            if (rsGet.Read())
                            {
                                if (Convert.ToInt64(rsGet["STOCKGROUP_LEVEL"]) == 1)
                                {
                                    blnInsert = true;
                                }

                                if (blnInsert == false)
                                {
                                    strItemParent = rsGet["STOCKGROUP_PARENT"].ToString();
                                    rsGet.Close();
                                    strSQL = "INSERT INTO INV_STOCKITEM_TO_GROUP(STOCKGROUP_NAME,STOCKITEM_NAME) ";
                                    strSQL = strSQL + "VALUES(";
                                    strSQL = strSQL + "'" + strItemParent + "','" + strItemName + "'";
                                    strSQL = strSQL + ")";
                                    cmd.CommandText = strSQL;
                                    cmd.ExecuteNonQuery(); ;
                                }
                            }
                            else
                            {
                                strItemParent = strItemPrimary;
                                blnInsert = true;
                                rsGet.Close();
                            }
                        }

                        while (blnInsert == false);
                        rsGet.Close();
                        strSQL = "INSERT INTO INV_STOCKITEM_LEVEL(STOCKITEM_NAME,STOCKGROUP_LEVEL_1) ";
                        strSQL = strSQL + "VALUES('" + strItemName + "','" + strItemParent + "')";
                        cmd.CommandText = strSQL;
                        cmd.ExecuteNonQuery();
                    }


                    rsGet.Close();
                    string strField1 = "";
                    strSQL = "SELECT STOCKGROUP_NAME,STOCKGROUP_LEVEL FROM INV_STOCKITEM_TO_GROUP_QRY ";
                    strSQL = strSQL + "WHERE STOCKGROUP_LEVEL > 1 ";
                    strSQL = strSQL + "AND STOCKITEM_NAME = '" + strItemName + "' ";
                    strSQL = strSQL + "ORDER BY STOCKGROUP_LEVEL ";
                    cmd.CommandText = strSQL;
                    rsGet = cmd.ExecuteReader();
                    while (rsGet.Read())
                    {
                        strField1 = strField1 + "STOCKGROUP_LEVEL_" + rsGet["STOCKGROUP_LEVEL"] + "|" + rsGet["STOCKGROUP_NAME"] + "~";
                        //rsGet.Close();
                        //strSQL = "UPDATE INV_STOCKITEM_LEVEL SET " + strField + " = '" + rsGet["STOCKGROUP_NAME"] + "' ";
                        //strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + strItemName + "' ";
                        //cmd.CommandText = strSQL;
                        //cmd.ExecuteNonQuery();
                    }
                    rsGet.Close();
                    if (strField1 != "")
                    {
                        strField1 = strField1.ToString().Substring(0, strField1.Length - 1);

                        string[] words1 = strField1.Split('~');
                        foreach (string name1 in words1)
                        {
                            string[] ooCost = name1.Split('|');
                            if (ooCost.ToString() != "")
                            {
                                strSQL = "UPDATE INV_STOCKITEM_LEVEL SET " + ooCost[0] + " = '" + ooCost[1] + "' ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + strItemName + "' ";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }



                    blnInsert = false;
                    rsGet.Close();
                }
            }
        }

        #endregion
        #region "Category"
        public List<StockCategory> mDisplayCategoryRecord(string strDeComID, long vstrPrimaryKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;

            List<StockCategory> oogrp = new List<StockCategory>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM INV_STOCKCATEGORY WHERE STOCKCATEGORY_SERIAL= " + vstrPrimaryKey + "";
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
                    StockCategory ogrp = new StockCategory();
                    ogrp.CategoryName = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    if (drGetGroup["STOCKCATEGORY_NAME"].ToString() == drGetGroup["STOCKCATEGORY_PRIMARY"].ToString())
                    {
                        ogrp.CategoryUnder = "Primary";
                    }
                    else
                    {
                        ogrp.CategoryUnder = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    }
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockCategory> mLoadStockCategory(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockCategory> oogrp = new List<StockCategory>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKCATEGORY_NAME FROM INV_STOCKCATEGORY ";
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
                    StockCategory ogrp = new StockCategory();
                    ogrp.CategoryName = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockCategory> mLoadStockCategoryItem(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockCategory> oogrp = new List<StockCategory>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKCATEGORY_NAME FROM INV_STOCKCATEGORY ";
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
                    StockCategory ogrp = new StockCategory();
                    ogrp.CategoryName = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockCategory> mFillStockCategory(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockCategory> oogrp = new List<StockCategory>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKCATEGORY_SERIAL, STOCKCATEGORY_NAME, STOCKCATEGORY_PARENT, STOCKCATEGORY_PRIMARY ";
            strSQL = strSQL + "FROM INV_STOCKCATEGORY ORDER BY STOCKCATEGORY_NAME ASC ";
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
                    StockCategory ogrp = new StockCategory();
                    ogrp.lngslNo = Convert.ToInt64(drGetGroup["STOCKCATEGORY_SERIAL"].ToString());
                    ogrp.CategoryName = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    ogrp.CategoryUnder = drGetGroup["STOCKCATEGORY_PARENT"].ToString();
                    ogrp.strPrimary = drGetGroup["STOCKCATEGORY_PRIMARY"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertcategory(string strDeComID, string vstrName, string vstrUnder)
        {
            long lngStockType;
            string strSQL, strPrimary;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    if (vstrUnder.ToUpper() == "PRIMARY")
                    {
                        strPrimary = vstrName.Replace("'", "''");
                        vstrUnder = vstrName.Replace("'", "''");
                        lngStockType = 1;
                    }
                    else
                    {
                        strPrimary = Utility.mstrGetPrimary(strDeComID, vstrUnder.Replace("'", "''"));
                        vstrUnder = vstrUnder.Replace("'", "''");
                        lngStockType = 2;
                    }
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    vstrName = vstrName.Replace("'", "''");
                    strSQL = "INSERT INTO INV_STOCKCATEGORY";
                    strSQL = strSQL + "(STOCKCATEGORY_NAME,STOCKCATEGORY_PARENT,STOCKCATEGORY_PRIMARY,STOCKCATEGORY_TYPE) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + vstrName + "','" + vstrUnder + "',";
                    strSQL = strSQL + "'" + strPrimary + "'," + lngStockType + " ";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mUpdatecategory(string strDeComID, long mstrPrimaryKey, string vstrName, string vstrUnder)
        {

            string strSQL, strGroupName, strParent, strPrimary, strOldLedgerGroup = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    strGroupName = vstrName.Replace("'", "''");
                    strParent = vstrUnder.Replace("'", "''");
                    strPrimary = Utility.GetEndGroupStock(strDeComID, strParent);
                    SqlDataReader rsGet;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT STOCKCATEGORY_NAME FROM INV_STOCKCATEGORY ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_SERIAL = " + mstrPrimaryKey + " ";
                    cmdInsert.CommandText = strSQL;
                    rsGet = cmdInsert.ExecuteReader();
                    if (rsGet.Read())
                    {
                        strOldLedgerGroup = rsGet["STOCKCATEGORY_NAME"].ToString().Replace("'", "''");
                    }
                    rsGet.Close();

                    if (vstrUnder.ToUpper() == "PRIMARY")
                    {
                        strPrimary = vstrName.Replace("'", "''");
                        vstrUnder = vstrName.Replace("'", "''");

                    }
                    else
                    {
                        strPrimary = Utility.mstrGetPrimary(strDeComID, vstrUnder.Replace("'", "''"));
                        vstrUnder = vstrUnder.Replace("'", "''");

                    }

                    vstrName = vstrName.Replace("'", "''");
                    strSQL = "UPDATE INV_STOCKCATEGORY ";
                    strSQL = strSQL + "SET STOCKCATEGORY_NAME = '" + strGroupName + "',";
                    strSQL = strSQL + "STOCKCATEGORY_PARENT = '" + strParent + "', ";
                    strSQL = strSQL + "STOCKCATEGORY_PRIMARY = '" + strPrimary + "' ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_SERIAL = " + mstrPrimaryKey + " ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE INV_STOCKCATEGORY SET STOCKCATEGORY_PARENT = '" + strParent + "' ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_PARENT = '" + strOldLedgerGroup + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE INV_STOCKCATEGORY SET STOCKCATEGORY_PRIMARY = '" + strGroupName + "' ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_PRIMARY = '" + strOldLedgerGroup + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_PRIMARY_GROUP = '" + strGroupName + "' ";
                    strSQL = strSQL + "WHERE STOCKITEM_PRIMARY_GROUP = '" + strOldLedgerGroup + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE INV_STOCKITEM SET STOCKCATEGORY_NAME = '" + strGroupName + "' ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_NAME = '" + strOldLedgerGroup + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Updated...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mDeletcategory(string strDeComID, long strSerialfNo)
        {

            string strSQL, strGroupName = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();

                    SqlDataReader rsGet;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT STOCKCATEGORY_NAME, STOCKCATEGORY_PARENT, STOCKCATEGORY_PRIMARY FROM INV_STOCKCATEGORY ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_SERIAL = " + strSerialfNo + " ";
                    cmdInsert.CommandText = strSQL;
                    rsGet = cmdInsert.ExecuteReader();
                    if (rsGet.Read())
                    {
                        strGroupName = rsGet["STOCKCATEGORY_NAME"].ToString().Replace("'", "''");
                    }
                    rsGet.Close();


                    strSQL = "DELETE FROM INV_STOCKCATEGORY ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_NAME = '" + strGroupName.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return ("Transaction Found Cannot be Delete");
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }



        #endregion
        #region "Others Category"
        public List<StockCategory> mDisplayCategoryRecordOthers(string strDeComID, long vstrPrimaryKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockCategory> oogrp = new List<StockCategory>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM INV_STOCKCATEGORY_OTHERS WHERE STOCKCATEGORY_SERIAL= " + vstrPrimaryKey + "";
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
                    StockCategory ogrp = new StockCategory();
                    ogrp.CategoryName = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    if (drGetGroup["STOCKCATEGORY_NAME"].ToString() == drGetGroup["STOCKCATEGORY_PRIMARY"].ToString())
                    {
                        ogrp.CategoryUnder = "Primary";
                    }
                    else
                    {
                        ogrp.CategoryUnder = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    }
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockCategory> mLoadStockCategoryOthers(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockCategory> oogrp = new List<StockCategory>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKCATEGORY_NAME FROM INV_STOCKCATEGORY_OTHERS ";
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
                    StockCategory ogrp = new StockCategory();
                    ogrp.CategoryName = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        //public List<StockCategory> mLoadStockCategoryItem()
        //{
        //    string strSQL;
        //    SqlDataReader drGetGroup;
        //    List<StockCategory> oogrp = new List<StockCategory>();

        //    strSQL = "SELECT STOCKCATEGORY_NAME FROM INV_STOCKCATEGORY ";
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();

        //        SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
        //        drGetGroup = cmd.ExecuteReader();
        //        while (drGetGroup.Read())
        //        {
        //            StockCategory ogrp = new StockCategory();
        //            ogrp.CategoryName = drGetGroup["STOCKCATEGORY_NAME"].ToString();
        //            oogrp.Add(ogrp);

        //        }
        //        drGetGroup.Close();
        //        gcnMain.Dispose();
        //        return oogrp;

        //    }
        //}
        public List<StockCategory> mFillStockCategoryOthers(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockCategory> oogrp = new List<StockCategory>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKCATEGORY_SERIAL, STOCKCATEGORY_NAME, STOCKCATEGORY_PARENT, STOCKCATEGORY_PRIMARY ";
            strSQL = strSQL + "FROM INV_STOCKCATEGORY_OTHERS ORDER BY STOCKCATEGORY_NAME ASC ";
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
                    StockCategory ogrp = new StockCategory();
                    ogrp.lngslNo = Convert.ToInt64(drGetGroup["STOCKCATEGORY_SERIAL"].ToString());
                    ogrp.CategoryName = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    ogrp.CategoryUnder = drGetGroup["STOCKCATEGORY_PARENT"].ToString();
                    ogrp.strPrimary = drGetGroup["STOCKCATEGORY_PRIMARY"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertOtherscategory(string strDeComID, string vstrName, string vstrUnder)
        {
            long lngStockType;
            string strSQL, strPrimary;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    if (vstrUnder.ToUpper() == "PRIMARY")
                    {
                        strPrimary = vstrName.Replace("'", "''");
                        vstrUnder = vstrName.Replace("'", "''");
                        lngStockType = 1;
                    }
                    else
                    {
                        strPrimary = Utility.mstrGetPrimary(strDeComID, vstrUnder.Replace("'", "''"));
                        vstrUnder = vstrUnder.Replace("'", "''");
                        lngStockType = 2;
                    }
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    vstrName = vstrName.Replace("'", "''");
                    strSQL = "INSERT INTO INV_STOCKCATEGORY_OTHERS";
                    strSQL = strSQL + "(STOCKCATEGORY_NAME,STOCKCATEGORY_PARENT,STOCKCATEGORY_PRIMARY,STOCKCATEGORY_TYPE) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + vstrName + "','" + vstrUnder + "',";
                    strSQL = strSQL + "'" + strPrimary + "'," + lngStockType + " ";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mUpdateOtherscategory(string strDeComID, long mstrPrimaryKey, string vstrName, string vstrUnder)
        {

            string strSQL, strGroupName, strParent, strPrimary, strOldLedgerGroup = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    strGroupName = vstrName.Replace("'", "''");
                    strParent = vstrUnder.Replace("'", "''");
                    strPrimary = Utility.GetEndGroupStock(strDeComID, strParent);
                    SqlDataReader rsGet;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT STOCKCATEGORY_NAME FROM INV_STOCKCATEGORY_OTHERS ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_SERIAL = " + mstrPrimaryKey + " ";
                    cmdInsert.CommandText = strSQL;
                    rsGet = cmdInsert.ExecuteReader();
                    if (rsGet.Read())
                    {
                        strOldLedgerGroup = rsGet["STOCKCATEGORY_NAME"].ToString().Replace("'", "''");
                    }
                    rsGet.Close();

                    if (vstrUnder.ToUpper() == "PRIMARY")
                    {
                        strPrimary = vstrName.Replace("'", "''");
                        vstrUnder = vstrName.Replace("'", "''");

                    }
                    else
                    {
                        strPrimary = Utility.mstrGetPrimary(strDeComID, vstrUnder.Replace("'", "''"));
                        vstrUnder = vstrUnder.Replace("'", "''");

                    }

                    vstrName = vstrName.Replace("'", "''");
                    strSQL = "UPDATE INV_STOCKCATEGORY_OTHERS ";
                    strSQL = strSQL + "SET STOCKCATEGORY_NAME = '" + strGroupName + "',";
                    strSQL = strSQL + "STOCKCATEGORY_PARENT = '" + strParent + "', ";
                    strSQL = strSQL + "STOCKCATEGORY_PRIMARY = '" + strPrimary + "' ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_SERIAL = " + mstrPrimaryKey + " ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE INV_STOCKCATEGORY_OTHERS SET STOCKCATEGORY_PARENT = '" + strParent + "' ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_PARENT = '" + strOldLedgerGroup + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "UPDATE INV_STOCKCATEGORY_OTHERS SET STOCKCATEGORY_PRIMARY = '" + strGroupName + "' ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_PRIMARY = '" + strOldLedgerGroup + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_PRIMARY_GROUP = '" + strGroupName + "' ";
                    //strSQL = strSQL + "WHERE STOCKITEM_PRIMARY_GROUP = '" + strOldLedgerGroup + "' ";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();
                    //strSQL = "UPDATE INV_STOCKITEM SET STOCKCATEGORY_NAME = '" + strGroupName + "' ";
                    //strSQL = strSQL + "WHERE STOCKCATEGORY_NAME = '" + strOldLedgerGroup + "' ";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Updated...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mDeletcategoryOthers(string strDeComID, long strSerialfNo)
        {

            string strSQL, strGroupName = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();

                    SqlDataReader rsGet;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT STOCKCATEGORY_NAME, STOCKCATEGORY_PARENT, STOCKCATEGORY_PRIMARY FROM INV_STOCKCATEGORY_OTHERS ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_SERIAL = " + strSerialfNo + " ";
                    cmdInsert.CommandText = strSQL;
                    rsGet = cmdInsert.ExecuteReader();
                    if (rsGet.Read())
                    {
                        strGroupName = rsGet["STOCKCATEGORY_NAME"].ToString().Replace("'", "''");
                    }
                    rsGet.Close();


                    strSQL = "DELETE FROM INV_STOCKCATEGORY_OTHERS ";
                    strSQL = strSQL + "WHERE STOCKCATEGORY_NAME = '" + strGroupName.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        #endregion
        #region "Measurement Unit"
        public string mInsertUnitMeasurement(string strDeComID, string vstrSymbol, string vstrFormal, long noofDecimalPlaces)
        {
            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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
                    vstrSymbol = vstrSymbol.Replace("'", "''");

                    strSQL = "INSERT INTO INV_UNIT_MEASUREMENT (";
                    strSQL = strSQL + "UNIT_SYMBOL, UNIT_FORMAL_NAME, INV_UNIT_DECIMAL_NO) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + vstrSymbol + "', ";
                    strSQL = strSQL + "'" + vstrFormal.Replace("'", "''") + "', ";
                    strSQL = strSQL + "" + (noofDecimalPlaces) + " ";
                    strSQL = strSQL + ")";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mUpdateMeasurementUnit(string strDeComID, long strUnitSerialNo, string vstrSymbol, string vstrFormal, long noofDecimalPlaces)
        {
            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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
                    vstrSymbol = vstrSymbol.Replace("'", "''");

                    strSQL = "UPDATE INV_UNIT_MEASUREMENT SET UNIT_SYMBOL='" + vstrSymbol + "',";
                    strSQL = strSQL + "UNIT_FORMAL_NAME='" + vstrFormal + "',";
                    strSQL = strSQL + "INV_UNIT_DECIMAL_NO=" + noofDecimalPlaces + " ";
                    strSQL = strSQL + "WHERE ";
                    strSQL = strSQL + "INV_UNIT_SERIAL=" + strUnitSerialNo + "";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Updated...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        public List<MeasurementUnit> mLoadMeasurementUnit(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<MeasurementUnit> oogrp = new List<MeasurementUnit>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM INV_UNIT_MEASUREMENT ";
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
                    MeasurementUnit ogrp = new MeasurementUnit();
                    ogrp.strSymbol = drGetGroup["UNIT_SYMBOL"].ToString();
                    ogrp.strFommalName = drGetGroup["UNIT_FORMAL_NAME"].ToString();
                    ogrp.noodDecimalPlace = drGetGroup["INV_UNIT_DECIMAL_NO"].ToString();
                    ogrp.lngslNo = Convert.ToInt64(drGetGroup["INV_UNIT_SERIAL"].ToString());
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public string DeleteMeasurementUnit(string strDeComID, string strSymbol, long strKey)
        {
            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    SqlDataReader dr;
                    SqlCommand cmdDelete = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdDelete.Connection = gcnMain;
                    cmdDelete.Transaction = myTrans;
                    strSQL = "SELECT * FROM INV_STOCKITEM WHERE STOCKITEM_BASEUNITS = '" + strSymbol.Replace("'", "''") + "'";
                    cmdDelete.CommandText = strSQL;
                    dr = cmdDelete.ExecuteReader();
                    if (dr.Read())
                    {
                        return "Related Trunsection exists. Can't delete";
                    }
                    dr.Close();

                    strSQL = "DELETE FROM INV_UNIT_MEASUREMENT WHERE INV_UNIT_SERIAL = " + strKey + "";
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    cmdDelete.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted..";
                }
                catch (Exception ex)
                {
                    return "Transaction Found Cannot be Delete";
                }
                finally
                {

                    gcnMain.Close();
                }
            }
        }

        #endregion
        #region "Godowm"
        public List<Location> mLoadLocationUserPrivilegesRight(string strDeComID,string strUSerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Location> oogrp = new List<Location>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT GODOWNS_NAME FROM USER_PRIVILEGES_LOCATION ";
            strSQL = strSQL + "WHERE USER_LOGIN_NAME='" + strUSerName + "' ";
            strSQL=strSQL +"ORDER BY  GODOWNS_NAME ";
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
                    Location ogrp = new Location();
                    ogrp.strLocation = drGetGroup["GODOWNS_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Location> mLoadLocationUserPrivileges(string strDeComID, string strUSerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Location> oogrp = new List<Location>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT GODOWNS_NAME FROM INV_GODOWNS WHERE GODOWNS_NAME NOT IN (SELECT GODOWNS_NAME FROM USER_PRIVILEGES_LOCATION WHERE USER_LOGIN_NAME='" + strUSerName + "') ";
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
                    Location ogrp = new Location();
                    ogrp.strLocation = drGetGroup["GODOWNS_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        //public string mInsertGodowns(string strDeComID, string vstrLocation, string vstrUnder, string vstrBranch,
        //                            string vstrAddress1, string vstrAddress2, string vstrCity,
        //                            string vstrPhone, string vstrFax,int intsection)
        //{

        //    string strSQL, strBranchId = "", strString = "";
        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }

        //        try
        //        {
        //            gcnMain.Open();
        //            SqlDataReader dr;
        //            strBranchId = Utility.gstrGetBranchID(strDeComID, vstrBranch);
        //            SqlCommand cmdInsert = new SqlCommand();
        //            SqlTransaction myTrans;
        //            myTrans = gcnMain.BeginTransaction();
        //            cmdInsert.Connection = gcnMain;
        //            cmdInsert.Transaction = myTrans;
        //            strSQL = "INSERT INTO INV_GODOWNS(BRANCH_ID,GODOWNS_NAME,GODOWNS_PARENT_GROUP,";
        //            strSQL = strSQL + "GODOWNS_ADDRESS1,GODOWNS_ADDRESS2,GODOWNS_CITY, ";
        //            strSQL = strSQL + "GODOWNS_PHONE,GODOWNS_FAX,SECTION_STATUS) ";
        //            strSQL = strSQL + "VALUES('" + strBranchId + "','" + vstrLocation + "','" + vstrUnder + "', ";
        //            strSQL = strSQL + "'" + vstrAddress1.Replace("'", "''") + "', ";
        //            strSQL = strSQL + "'" + vstrAddress2.Replace("'", "''") + "',";
        //            strSQL = strSQL + "'" + vstrCity.Replace("'", "''") + "', ";
        //            strSQL = strSQL + "'" + vstrPhone.Replace("'", "''") + "', ";
        //            strSQL = strSQL + "'" + vstrFax.Replace("'", "''") + "' ";
        //            strSQL = strSQL + "," + intsection + " ";
        //            strSQL = strSQL + ")";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();
        //            strSQL = "SELECT STOCKITEM_NAME FROM INV_STOCKITEM ";
        //            cmdInsert.CommandText = strSQL;
        //            dr = cmdInsert.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                strString = strString + dr["STOCKITEM_NAME"].ToString() + "~" + vstrLocation + ";";
        //            }
        //            dr.Close();
        //            string[] words = strString.Split(';');
        //            foreach (string ooLoca in words)
        //            {
        //                string[] ooCost = ooLoca.Split('~');
        //                if (ooCost[0] != "")
        //                {
        //                    strSQL = "SELECT GODOWNS_NAME FROM INV_STOCKITEM_CLOSING ";
        //                    strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + ooCost[0].Replace("'", "''") + "' ";
        //                    strSQL = strSQL + "AND GODOWNS_NAME = '" + ooCost[1].ToString() + "' ";
        //                    cmdInsert.CommandText = strSQL;
        //                    dr = cmdInsert.ExecuteReader();
        //                    if (!dr.Read())
        //                    {
        //                        dr.Close();
        //                        strSQL = "INSERT INTO INV_STOCKITEM_CLOSING(";
        //                        strSQL = strSQL + "STOCKITEM_NAME,GODOWNS_NAME ";
        //                        strSQL = strSQL + ")VALUES(";
        //                        strSQL = strSQL + "'" + ooCost[0].Replace("'", "''") + "',";
        //                        strSQL = strSQL + "'" + ooCost[1] + "')";
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                    }
        //                    dr.Close();
        //                }
        //            }

        //            dr.Close();


        //            cmdInsert.Transaction.Commit();
        //            gcnMain.Close();
        //            dr.Close();
        //            return "Inseretd...";
        //        }
        //        catch (Exception ex)
        //        {
        //            return (ex.ToString());
        //        }
        //        finally
        //        {
        //            gcnMain.Close();
        //        }
        //    }
        //}


        //public string mUpdateGodown(string strDeComID, long vstrPrimaryKey, string vstrLocation, string vstrUnder, string vstrBranch,
        //                            string vstrAddress1, string vstrAddress2, string vstrCity,
        //                            string vstrPhone, string vstrFax, int intsection)
        //{

        //    string strSQL, strBranchId = "", strString = "";
        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }

        //        try
        //        {
        //            gcnMain.Open();
        //            SqlDataReader dr;
        //            strBranchId = Utility.gstrGetBranchID(strDeComID, vstrBranch);
        //            SqlCommand cmdInsert = new SqlCommand();
        //            SqlTransaction myTrans;
        //            myTrans = gcnMain.BeginTransaction();
        //            cmdInsert.Connection = gcnMain;
        //            cmdInsert.Transaction = myTrans;

        //            strSQL = "UPDATE INV_GODOWNS SET GODOWNS_NAME = '" + vstrLocation + "',";
        //            strSQL = strSQL + "BRANCH_ID = '" + strBranchId + "',";
        //            strSQL = strSQL + "GODOWNS_PARENT_GROUP = '" + vstrUnder + "',";
        //            strSQL = strSQL + "GODOWNS_ADDRESS1 = '" + vstrAddress1.Replace("'", "''") + "', ";
        //            strSQL = strSQL + "GODOWNS_ADDRESS2 = '" + vstrAddress2.Replace("'", "''") + "',";
        //            strSQL = strSQL + "GODOWNS_CITY = '" + vstrCity.Replace("'", "''") + "', ";
        //            strSQL = strSQL + "GODOWNS_PHONE = '" + vstrPhone.Replace("'", "''") + "', ";
        //            strSQL = strSQL + "GODOWNS_FAX = '" + vstrFax.Replace("'", "''") + "',";
        //            strSQL = strSQL + "SECTION_STATUS = " + intsection + " ";
        //            strSQL = strSQL + "WHERE GODOWNS_SERIAL = " + vstrPrimaryKey + " ";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();

        //            strSQL = "SELECT STOCKITEM_NAME FROM INV_STOCKITEM ";
        //            cmdInsert.CommandText = strSQL;
        //            dr = cmdInsert.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                strString = strString + dr["STOCKITEM_NAME"].ToString() + "~" + vstrLocation + ";";
        //            }
        //            dr.Close();
        //            string[] words = strString.Split(';');
        //            foreach (string ooLoca in words)
        //            {
        //                string[] ooCost = ooLoca.Split('~');
        //                if (ooCost[0] != "")
        //                {
        //                    strSQL = "SELECT GODOWNS_NAME FROM INV_STOCKITEM_CLOSING ";
        //                    strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + ooCost[0].Replace("'", "''") + "' ";
        //                    strSQL = strSQL + "AND GODOWNS_NAME = '" + ooCost[1].ToString() + "' ";
        //                    cmdInsert.CommandText = strSQL;
        //                    dr = cmdInsert.ExecuteReader();
        //                    if (!dr.Read())
        //                    {
        //                        dr.Close();
        //                        strSQL = "INSERT INTO INV_STOCKITEM_CLOSING(";
        //                        strSQL = strSQL + "STOCKITEM_NAME,GODOWNS_NAME ";
        //                        strSQL = strSQL + ")VALUES(";
        //                        strSQL = strSQL + "'" + ooCost[0].Replace("'", "''") + "',";
        //                        strSQL = strSQL + "'" + ooCost[1] + "')";
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                    }
        //                    dr.Close();
        //                }
        //            }

        //            dr.Close();

        //            cmdInsert.Transaction.Commit();
        //            gcnMain.Close();
        //            return "Updated...";
        //        }
        //        catch (Exception ex)
        //        {
        //            return (ex.ToString());
        //        }
        //        finally
        //        {
        //            gcnMain.Close();
        //        }
        //    }
        //}

        public List<Location> mDisplayLocation(string strDeComID, long vstrPrimaryKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Location> oogrp = new List<Location>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM INV_GODOWNS ";
            strSQL = strSQL + "WHERE GODOWNS_SERIAL = " + vstrPrimaryKey + " ";
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
                    Location ogrp = new Location();
                    ogrp.strLocation = drGetGroup["GODOWNS_NAME"].ToString();
                    ogrp.strParentGroup = drGetGroup["GODOWNS_PARENT_GROUP"].ToString();
                    ogrp.strBranch = drGetGroup["BRANCH_ID"].ToString();
                    if (drGetGroup["GODOWNS_ADDRESS1"].ToString() != "")
                    {
                        ogrp.strAddres1 = drGetGroup["GODOWNS_ADDRESS1"].ToString();
                    }
                    else
                    {
                        ogrp.strAddres1 = "";
                    }
                    if (drGetGroup["GODOWNS_ADDRESS2"].ToString() != "")
                    {
                        ogrp.strAddres2 = drGetGroup["GODOWNS_ADDRESS2"].ToString();
                    }
                    else
                    {
                        ogrp.strAddres2 = "";
                    }
                    if (drGetGroup["GODOWNS_CITY"].ToString() != "")
                    {
                        ogrp.strCity = drGetGroup["GODOWNS_CITY"].ToString();
                    }
                    else
                    {
                        ogrp.strCity = "";
                    }
                    if (drGetGroup["GODOWNS_PHONE"].ToString() != "")
                    {
                        ogrp.strPhone = drGetGroup["GODOWNS_PHONE"].ToString();
                    }
                    else
                    {
                        ogrp.strPhone = "";
                    }
                    if (drGetGroup["GODOWNS_FAX"].ToString() != "")
                    {
                        ogrp.strFax = drGetGroup["GODOWNS_FAX"].ToString();
                    }
                    else
                    {
                        ogrp.strFax = "";
                    }
                    ogrp.intSection = Convert.ToInt16(drGetGroup["SECTION_STATUS"].ToString());

                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }


        public List<Location> mLoadLocation(string strDeComID, bool vblngAccessControl, string vstrUserName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Location> oogrp = new List<Location>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            if (vblngAccessControl == true)
            {
                strSQL = "SELECT PRI_LOCATION_SERIAL AS GODOWNS_SERIAL,GODOWNS_NAME,'' BRANCH_ID,0 GODOWNS_DEFAULT FROM USER_PRIVILEGES_LOCATION ";
                strSQL = strSQL + " WHERE USER_LOGIN_NAME='" + vstrUserName + "' ";
            }
            else
            {
                strSQL = "SELECT GODOWNS_SERIAL,GODOWNS_NAME,BRANCH_ID,GODOWNS_DEFAULT FROM INV_GODOWNS ";
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
                    Location ogrp = new Location();
                    ogrp.lngSlNo = Convert.ToInt64(drGetGroup["GODOWNS_SERIAL"].ToString());
                    ogrp.strLocation = drGetGroup["GODOWNS_NAME"].ToString();
                    if (drGetGroup["BRANCH_ID"].ToString() != "")
                    {
                        ogrp.strBranch = Utility.gstrGetBranchName(strDeComID, drGetGroup["BRANCH_ID"].ToString());
                    }
                    else
                    {
                        ogrp.strBranch = "";
                    }
                    ogrp.lngDefault = Convert.ToInt32(drGetGroup["GODOWNS_DEFAULT"]);
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }


        public string mDeleteLocation(string strDeComID, string strSubGroup, long strRefNo)
        {
            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();

                    SqlDataReader dr;
                    strSQL = "SELECT GODOWNS_PARENT_GROUP FROM INV_GODOWNS";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (strSubGroup == dr["GODOWNS_PARENT_GROUP"].ToString())
                        {
                            return ("Cannot remove Godown. Subgroup exists.Remove subgroup first to remove Primary Group");
                        }
                    }
                    dr.Close();
                    SqlCommand cmdDelete = new SqlCommand();
                    SqlTransaction myTrans;
                    cmdDelete.Connection = gcnMain;
                    myTrans = gcnMain.BeginTransaction();
                    cmdDelete.Transaction = myTrans;
                    strSQL = "DELETE FROM INV_STOCKITEM_CLOSING WHERE GODOWNS_NAME = '" + strSubGroup + "' ";
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    strSQL = "DELETE FROM INV_GODOWNS WHERE GODOWNS_SERIAL = " + strRefNo + " ";
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    cmdDelete.Transaction.Commit();
                    return "Delted...";
                }
                catch (Exception ex)
                {
                    return "Transaction Found Cannot be Delete";
                }


            }
        }

        #endregion
        #region "Stock Item"
        public List<StockItem> mFillUOM(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT UNIT_SYMBOL FROM INV_UNIT_MEASUREMENT ";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strUnit = drGetGroup["UNIT_SYMBOL"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> mFillOpeningBatch(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT INV_LOG_NO AS BATCH_NO ";
            strSQL = strSQL + "FROM INV_BATCH ";
            strSQL = strSQL + "WHERE INV_LOG_STATUS = 'Active' ";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strBatch = drGetGroup["BATCH_NO"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> mFillLedger(string strDeComID, long lngGroup)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_GROUP = " + lngGroup + "";
            strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
            strSQL = strSQL + "ORDER BY LEDGER_NAME";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> mGetStockGroup(string strDeComID, int intmode)
        {
            /// intmode=1 all
            /// intmdoe=2 Direct Raw Materials,Indirect Raw Materials
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            if (intmode == 1)
            {
                strSQL = "SELECT DISTINCT STOCKGROUP_PRIMARY  FROM INV_STOCKGROUP  ";
            }
            else
            {
                strSQL = "SELECT DISTINCT STOCKGROUP_PRIMARY  FROM INV_STOCKGROUP WHERE STOCKGROUP_SECONDARY_TYPE IN('1','2') ";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemGroup = drGetGroup["STOCKGROUP_PRIMARY"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> gLoadStockGroup(string strDeComID, bool vblngAccessContron, string vstrUserName, string strFgYN,string strGroupName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<StockItem> oogrp = new List<StockItem>();
            if (vblngAccessContron == true)
            {
                strSQL = "SELECT p.STOCKGROUP_NAME FROM USER_PRIVILEGES_STOCKGROUP p,INV_STOCKGROUP g ";
                strSQL = strSQL + "WHERE p.STOCKGROUP_NAME=g.STOCKGROUP_NAME AND p.USER_LOGIN_NAME='" + vstrUserName + "' ";
                if (strGroupName !="")
                {
                    strSQL = strSQL + " AND g.STOCKGROUP_PRIMARY ='" + strGroupName + "' ";
                }
                if (strFgYN == "Y")
                {
                    strSQL = strSQL + " AND g.STOCKGROUP_PRIMARY_TYPE =3 ";
                }
                if (strFgYN == "P")
                {
                    strSQL = strSQL + " AND g.STOCKGROUP_PRIMARY_TYPE <> 3 ";
                }
                strSQL = strSQL + "ORDER BY p.STOCKGROUP_NAME";
            }
            else if (strFgYN == "Y")
            {
                strSQL = "select DISTINCT INV_STOCKGROUP.STOCKGROUP_NAME  from INV_STOCKITEM ,INV_STOCKGROUP where INV_STOCKITEM.STOCKGROUP_NAME=INV_STOCKGROUP.STOCKGROUP_NAME ";
                strSQL = strSQL + "AND  INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE =3 ";
            }
            else if (strFgYN == "P")
            {
                strSQL = "select DISTINCT INV_STOCKGROUP.STOCKGROUP_NAME  from INV_STOCKITEM ,INV_STOCKGROUP where INV_STOCKITEM.STOCKGROUP_NAME=INV_STOCKGROUP.STOCKGROUP_NAME ";
                strSQL = strSQL + "AND  INV_STOCKGROUP.STOCKGROUP_PRIMARY_TYPE <> 3 ";
            }
            else
            {
                strSQL = "SELECT STOCKGROUP_NAME FROM INV_STOCKGROUP ORDER BY STOCKGROUP_NAME";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemGroup = drGetGroup["STOCKGROUP_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> gLoadStockGroupLevel3(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKGROUP_NAME FROM INV_STOCKGROUP where STOCKGROUP_LEVEL =3  ORDER BY STOCKGROUP_NAME";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemGroup = drGetGroup["STOCKGROUP_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> gLoadStockGroupLevel3PrivilegesRight(string strDeComID,string strUserName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKGROUP_NAME FROM USER_PRIVILEGES_STOCKGROUP ";
            strSQL = strSQL + " WHERE USER_LOGIN_NAME='" + strUserName + "' ";
            strSQL=strSQL +"ORDER BY STOCKGROUP_NAME";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemGroup = drGetGroup["STOCKGROUP_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
     
        public List<StockItem> gLoadStockGroupLevel3Privileges(string strDeComID, string strUserName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = " SELECT STOCKGROUP_NAME FROM INV_STOCKGROUP where STOCKGROUP_LEVEL =3  AND STOCKGROUP_NAME NOT IN (SELECT STOCKGROUP_NAME FROM USER_PRIVILEGES_STOCKGROUP  WHERE USER_LOGIN_NAME='" + strUserName + "' )";
            strSQL = strSQL + "ORDER BY STOCKGROUP_NAME ";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemGroup = drGetGroup["STOCKGROUP_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertStockItem(string strDeComID, string vstrName, string vstrUnder, long lngMaintainBatch, string vstrStatus,
                                        string vstrItemName, string vstrAlias, string vstrdescription, string vstrParent, string vstrCatgory,
                                        string vstrUnit, string vstrAltUnit, string vstrWhere, string vstrWhereUnit, string vstrManufacturer,
                                        string vstrSupplier, string vstrTransalator, string vstritemBangla, double dblMinimumstock, double dblReorderQty,
                                        double dblOpnQty, double dblopnRate, double dblAmnt, string dg, string strMatType, string strPowerClass, string strBatch,int intSP)
        {
            long lngStockStatus = 0, lngloop = 1;
            string strSQL, strPrimary, strStockItem, strParent, strCategory = "", strGroupParent = "", strfiled = "",
            strGodown = "", strdate = "01/01/1900", strBranchID = "", strGodownSerial = "", strItemSerial = "", strRefNo = "", strInOutFlg = "";
            double dblOpeningQty, dblOpeningValue, dblqty = 0, dblTranQty = 0, dblRate;
            bool blnInsert = false;
            int i = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();

                    strPrimary = Utility.gstrGetPrimary(strDeComID, vstrUnder.Replace("'", "''"));
                    if (vstrStatus == "Yes")
                    {
                        lngStockStatus = 1;
                    }

                    strStockItem = vstrItemName.Replace("'", "''");
                    vstrItemName = vstrItemName.Replace("'", "''");
                    strParent = vstrUnder.Replace("'", "''");
                    if (vstrCatgory != "")
                    {
                        strCategory = vstrCatgory.Replace("'", "''");
                    }
                    dblOpeningQty = dblOpnQty;
                    dblOpeningValue = dblAmnt;


                    SqlDataReader dr;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT STOCKGROUP_PARENT FROM INV_STOCKGROUP WHERE STOCKGROUP_NAME='" + strPrimary + "'";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr["STOCKGROUP_PARENT"].ToString() == strParent)
                        {
                            strGroupParent = dr["STOCKGROUP_PARENT"].ToString();
                        }
                        else
                        {
                            strGroupParent = "";
                        }
                    }
                    dr.Close();

                    strSQL = "INSERT INTO INV_STOCKITEM";
                    strSQL = strSQL + "(STOCKITEM_NAME,STOCKITEM_ALIAS,STOCKITEM_DESCRIPTION,STOCKGROUP_NAME,";
                    strSQL = strSQL + "STOCKITEM_PRIMARY_GROUP ";
                    if (vstrCatgory != "")
                    {
                        strSQL = strSQL + ",STOCKCATEGORY_NAME";
                    }
                    strSQL = strSQL + ",STOCKITEM_MANUFACTURER,STOCKITEM_BASEUNITS,";


                    if (vstrAltUnit != "")
                    {
                        strSQL = strSQL + "STOCKITEM_ADDITIONALUNITS,STOCKITEM_CONVERSION,STOCKITEM_DENOMINATOR,";
                    }
                    strSQL = strSQL + "STOCKITEM_OPENING_BALANCE,STOCKITEM_OPENING_RATE,";
                    strSQL = strSQL + "STOCKITEM_OPENING_VALUE,";
                    strSQL = strSQL + "STOCKITEM_MIN_QUANTITY,STOCKITEM_REORDER_LEVEL,STOCKITEM_MAINTAIN_SERIAL,";
                    strSQL = strSQL + "STOCKITEM_STATUS,ISBN_NO,STOCK_ITEM_SUPPLIER";
                    if (vstrTransalator != "")
                    {
                        strSQL = strSQL + ",STOCKOTHERS_NAME";
                    }
                    strSQL = strSQL + ",ITEM_NAME_BANGLA,SERIAL_STATUS,";
                    if (strMatType != "")
                    {
                        strSQL = strSQL + "MATERIAL_TYPE,";
                    }
                    strSQL = strSQL + "POWER_CLASS,SP_ITEM) VALUES(";
                    strSQL = strSQL + "'" + strStockItem + "',";
                    strSQL = strSQL + "'" + vstrAlias + "',";
                    strSQL = strSQL + "'" + vstrdescription.Replace("'", "''") + "',";
                    strSQL = strSQL + "'" + strParent + "',";
                    strSQL = strSQL + "'" + strGroupParent + "',";
                    if (vstrCatgory != "")
                    {
                        //    strSQL = strSQL + "NULL,";
                        //}
                        //else
                        //{
                        strSQL = strSQL + "'" + vstrCatgory + "',";
                    }
                    if (vstrManufacturer == "")
                    {
                        strSQL = strSQL + "NULL,";
                    }
                    else
                    {
                        strSQL = strSQL + "'" + vstrManufacturer + "',";
                    }
                    strSQL = strSQL + "'" + vstrUnit + "',";
                    if (vstrAltUnit != "")
                    {

                        strSQL = strSQL + "'" + vstrAltUnit + "',";
                        strSQL = strSQL + "'" + vstrWhere + "',";
                        strSQL = strSQL + " " + vstrWhereUnit + ",";
                    }
                    strSQL = strSQL + " " + dblOpeningQty + "," + dblopnRate + ",";
                    strSQL = strSQL + " " + dblOpeningValue + "," + dblMinimumstock + "," + dblReorderQty + " ";
                    strSQL = strSQL + "," + lngMaintainBatch + " ";
                    strSQL = strSQL + "," + lngStockStatus + " ";
                    if (vstrManufacturer != "")
                    {
                        strSQL = strSQL + ",NULL";
                    }
                    else
                    {
                        strSQL = strSQL + ",'" + vstrManufacturer + "'";
                    }
                    if (vstrSupplier == Utility.gcEND_OF_LIST)
                    {
                        strSQL = strSQL + ",NULL";
                    }
                    else
                    {
                        strSQL = strSQL + ",'" + vstrSupplier + "'";
                    }
                    if (vstrTransalator != "")
                    {

                        strSQL = strSQL + ",'" + vstrTransalator + "'";
                    }
                    if (vstritemBangla != "")
                    {
                        strSQL = strSQL + ",NULL";
                    }
                    else
                    {
                        strSQL = strSQL + ",'" + vstritemBangla + "'";
                    }
                    strSQL = strSQL + ",0";
                    if (strMatType != "")
                    {
                        strSQL = strSQL + ",'" + strMatType + "'";
                    }
                    strSQL = strSQL + ",'" + strPowerClass + "'";
                    strSQL = strSQL + "," + intSP + " ";
                    strSQL = strSQL + ")";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO INV_STOCKITEM_TO_GROUP(STOCKGROUP_NAME, STOCKITEM_NAME) ";
                    strSQL = strSQL + "VALUES('" + strParent + "','" + strStockItem + "')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    do
                    {

                        if (blnInsert == false)
                        {
                            strSQL = "SELECT STOCKGROUP_PARENT,STOCKGROUP_LEVEL FROM INV_STOCKGROUP ";
                            strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + strParent + "'";
                            SqlDataReader dr1;
                            cmdInsert.CommandText = strSQL;
                            dr1 = cmdInsert.ExecuteReader();
                            while (dr1.Read())
                            {
                                strPrimary = dr1["STOCKGROUP_PARENT"].ToString().Replace("'", "''");
                                if (strParent != dr1["STOCKGROUP_PARENT"].ToString())
                                {
                                    strfiled = strfiled + dr1["STOCKGROUP_PARENT"].ToString().Replace("'", "''") + "~";
                                }
                                //if (long.Parse(dr1["STOCKGROUP_LEVEL"].ToString()) == 1)
                                //{
                                //    blnInsert = true;
                                //}

                                //dr1.Close();
                                //if (blnInsert == false)
                                //{

                                //    strSQL = "INSERT INTO INV_STOCKITEM_TO_GROUP(STOCKGROUP_NAME,STOCKITEM_NAME) ";
                                //    strSQL = strSQL + "VALUES('" + strParent + "','" + strStockItem + "')";

                                //    cmdInsert.CommandText = strSQL;
                                //    cmdInsert.ExecuteNonQuery();
                                //}
                            }
                            //else
                            //{
                            //    strParent = strPrimary;
                            //blnInsert = true;
                            //dr1.Close();
                            //}
                            //}
                            //else
                            //{

                            if (strParent == strPrimary)
                            {
                                blnInsert = true;
                            }
                            else
                            {
                                strParent = strPrimary;
                            }


                            if (!dr1.HasRows)
                            {
                                blnInsert = true;
                            }
                            dr1.Close();
                            //   

                        }
                    }

                    while (blnInsert == false);

                    blnInsert = false;

                    if (strfiled != "")
                    {
                        i = 0;
                        string[] words = strfiled.Split('~');
                        foreach (string ooGroups in words)
                        {
                            if (ooGroups != "")
                            {
                                strSQL = "INSERT INTO INV_STOCKITEM_TO_GROUP(STOCKGROUP_NAME,STOCKITEM_NAME) ";
                                strSQL = strSQL + "VALUES('" + words[i].ToString() + "','" + strStockItem + "')";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                i += 1;
                            }

                        }
                    }
                    i = 0;
                    strfiled = "";


                    SqlDataReader dr2;
                    strSQL = "INSERT INTO INV_STOCKITEM_LEVEL(STOCKITEM_NAME,STOCKGROUP_LEVEL_1) ";
                    strSQL = strSQL + "VALUES('" + strStockItem + "','" + strParent + "')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //strSQL = "SELECT STOCKGROUP_NAME,STOCKGROUP_LEVEL FROM INV_STOCKITEM_TO_GROUP_QRY ";
                    //strSQL = strSQL + "WHERE STOCKGROUP_LEVEL > 1 ";
                    //strSQL = strSQL + "AND STOCKITEM_NAME = '" + strStockItem + "' ";
                    //strSQL = strSQL + "ORDER BY STOCKGROUP_LEVEL ";

                    strSQL = "SELECT INV_STOCKITEM_TO_GROUP.STOCKGROUP_NAME,INV_STOCKITEM_TO_GROUP.STOCKITEM_NAME, INV_STOCKGROUP.STOCKGROUP_LEVEL ";
                    strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM_TO_GROUP ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM_TO_GROUP.STOCKGROUP_NAME ";
                    strSQL = strSQL + "WHERE INV_STOCKGROUP.STOCKGROUP_LEVEL > 1 ";
                    strSQL = strSQL + "AND STOCKITEM_NAME = '" + strStockItem + "' ";
                    cmdInsert.CommandText = strSQL;
                    dr2 = cmdInsert.ExecuteReader();
                    while (dr2.Read())
                    {
                        if (Convert.ToInt64(dr2["STOCKGROUP_LEVEL"].ToString()) < 6)
                        {
                            strfiled = strfiled + "STOCKGROUP_LEVEL_" + dr2["STOCKGROUP_LEVEL"].ToString() + "|" + dr2["STOCKGROUP_NAME"].ToString() + "~";
                        }
                        else
                        {
                            strfiled = "";
                        }
                    }
                    dr2.Close();
                    if (strfiled != "")
                    {
                        string[] words = strfiled.Split('~');
                        foreach (string ooGroups in words)
                        {
                            string[] ooCost = ooGroups.Split('|');
                            if (ooCost[0] != "")
                            {
                                strSQL = "UPDATE INV_STOCKITEM_LEVEL SET " + ooCost[0] + " = '" + ooCost[1] + "' ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + strStockItem + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }
                    strfiled = "";


                    strSQL = "SELECT GODOWNS_NAME FROM INV_GODOWNS ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strfiled = strfiled + dr["GODOWNS_NAME"].ToString() + "~";
                    }
                    dr.Close();
                    if (strfiled != "")
                    {
                        string[] words = strfiled.Split('~');
                        foreach (string ooGroups in words)
                        {
                            if (words[i] != "")
                            {
                                strSQL = "INSERT INTO INV_STOCKITEM_CLOSING(";
                                strSQL = strSQL + "STOCKITEM_NAME,GODOWNS_NAME) VALUES(";
                                strSQL = strSQL + "'" + strStockItem + "',";
                                strSQL = strSQL + "'" + words[i].ToString() + "'";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                            i += 1;

                        }
                    }
                    strfiled = "";
                    i = 0;

                    if (Utility.gblnLocation == false)
                    {
                        if (dg != "")
                        {

                            string[] words = dg.Split('~');
                            foreach (string ooGroups in words)
                            {
                                string[] ooCost = ooGroups.Split('|');
                                if (ooCost[0] != "")
                                {
                                    strSQL = "SELECT GODOWNS_SERIAL,BRANCH_ID FROM INV_GODOWNS WHERE GODOWNs_NAME = '" + ooCost[0].ToString() + "' ";
                                    cmdInsert.CommandText = strSQL;
                                    dr = cmdInsert.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        strGodownSerial = dr["GODOWNS_SERIAL"].ToString();
                                        strBranchID = dr["BRANCH_ID"].ToString();
                                    }
                                    dr.Close();
                                    strSQL = "SELECT max(INV_TRAN_SERIAL)+1 as STOCKITEM_SERIAL FROM INV_TRAN ";
                                    cmdInsert.CommandText = strSQL;
                                    dr = cmdInsert.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        strItemSerial = dr["STOCKITEM_SERIAL"].ToString();
                                    }
                                    dr.Close();


                                    if (Utility.gblnLocation == false)
                                    {
                                        dblqty = Convert.ToDouble(ooCost[1].ToString());
                                    }
                                    else
                                    {
                                        dblqty = dblOpnQty;
                                    }
                                    if (strRefNo == "")
                                    {
                                        strRefNo = Utility.vtSTOCK_OPENING_STR + strBranchID + strItemSerial + "-OPN" + lngloop + strGodownSerial;
                                        strSQL = "INSERT INTO INV_MASTER(INV_REF_NO,";
                                        strSQL = strSQL + "INWORD_QUANTITY,INV_OPENING_FLAG,BRANCH_ID,INV_DATE) ";
                                        strSQL = strSQL + "VALUES('" + strRefNo + "'," + dblqty + "," + (int)Utility.VOUCHER_TYPE.vtSTOCK_OPENING + ",";
                                        strSQL = strSQL + "'" + strBranchID + "',";
                                        strSQL = strSQL + "" + Utility.cvtSQLDateString(strdate) + ")";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }


                                    if (Utility.gblnLocation == false)
                                    {
                                        dblTranQty = Convert.ToDouble(ooCost[1].ToString());
                                    }
                                    else
                                    {
                                        dblTranQty = dblOpnQty;
                                    }
                                    strInOutFlg = "1";
                                    strSQL = "INSERT INTO INV_TRAN ";
                                    strSQL = strSQL + "(INV_TRAN_KEY,INV_TRAN_POSITION,BRANCH_ID,INV_REF_NO,INV_DATE,STOCKITEM_NAME,";
                                    strSQL = strSQL + "INV_TRAN_QUANTITY,INV_TRAN_RATE,INV_TRAN_AMOUNT,GODOWNS_NAME,";
                                    if (ooCost[4] != Utility.gcEND_OF_LIST && ooCost[4] != "")
                                    {
                                        strSQL = strSQL + "INV_LOG_NO,";
                                    }
                                    strSQL = strSQL + "INV_VOUCHER_TYPE,INV_OPENING_FLAG) ";
                                    strSQL = strSQL + "VALUES('" + strRefNo + lngloop + "'," + lngloop + ",";
                                    strSQL = strSQL + "'" + strBranchID + "',";
                                    strSQL = strSQL + "'" + strRefNo + "',";
                                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strdate) + ",";
                                    strSQL = strSQL + "'" + vstrItemName + "',";
                                    strSQL = strSQL + " " + dblTranQty + ",";
                                    if (Utility.gblnLocation == false)
                                    {
                                        dblRate = Convert.ToDouble(ooCost[2]);
                                        strSQL = strSQL + " " + dblRate + ",";//   'Rate
                                        strSQL = strSQL + " " + Math.Round(dblTranQty * dblRate, 2) + ",";//   'Amount
                                    }
                                    else
                                    {

                                        dblRate = dblopnRate;
                                        strSQL = strSQL + " " + dblRate + ",";//   'Rate
                                        // strSQL = strSQL + " " + dblOpeningValue + ",";  //  'Amount
                                        strSQL = strSQL + " " + Math.Round(dblTranQty * dblRate, 2) + ",";//   'Amount
                                    }
                                    strSQL = strSQL + "'" + ooCost[0] + "',";
                                    if (ooCost[4] != Utility.gcEND_OF_LIST && ooCost[4] != "")
                                    {
                                        strSQL = strSQL + "'" + ooCost[4].ToString() + "',";
                                    }
                                    strSQL = strSQL + (int)Utility.VOUCHER_TYPE.vtSTOCK_OPENING + ",1)";

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    lngloop += 1;

                                }

                            }
                        }
                        else
                        {
                            strSQL = "SELECT GODOWNS_SERIAL,BRANCH_ID FROM INV_GODOWNS WHERE GODOWNs_NAME = 'Main Location' ";
                            cmdInsert.CommandText = strSQL;
                            dr = cmdInsert.ExecuteReader();
                            if (dr.Read())
                            {
                                strGodownSerial = dr["GODOWNS_SERIAL"].ToString();
                                strBranchID = dr["BRANCH_ID"].ToString();
                            }
                            dr.Close();
                            strSQL = "SELECT max(INV_TRAN_SERIAL)+1 as STOCKITEM_SERIAL FROM INV_TRAN ";
                            cmdInsert.CommandText = strSQL;
                            dr = cmdInsert.ExecuteReader();
                            if (dr.Read())
                            {
                                strItemSerial = dr["STOCKITEM_SERIAL"].ToString();
                            }
                            dr.Close();


                            if (Utility.gblnLocation == false)
                            {
                                dblqty = 0;
                            }
                            else
                            {
                                dblqty = 0;
                            }

                            if (strRefNo == "")
                            {
                                strRefNo = Utility.vtSTOCK_OPENING_STR + strBranchID + strItemSerial + "-OPN" + lngloop + strGodownSerial;

                                strSQL = "INSERT INTO INV_MASTER(INV_REF_NO,";
                                strSQL = strSQL + "INWORD_QUANTITY,INV_OPENING_FLAG,BRANCH_ID,INV_DATE) ";
                                strSQL = strSQL + "VALUES('" + strRefNo + "'," + dblqty + "," + (int)Utility.VOUCHER_TYPE.vtSTOCK_OPENING + ",";
                                strSQL = strSQL + "'" + strBranchID + "',";
                                strSQL = strSQL + "" + Utility.cvtSQLDateString(strdate) + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }

                            strSQL = "INSERT INTO INV_TRAN ";
                            strSQL = strSQL + "(INV_TRAN_KEY,INV_TRAN_POSITION,BRANCH_ID,INV_REF_NO,INV_DATE,STOCKITEM_NAME,";
                            strSQL = strSQL + "INV_TRAN_QUANTITY,INV_TRAN_RATE,INV_TRAN_AMOUNT,";
                            strSQL = strSQL + "GODOWNS_NAME";
                            if (strBatch != "")
                            {
                                strSQL = strSQL + ",INV_LOG_NO";
                            }
                            strSQL = strSQL + ") ";
                            strSQL = strSQL + "VALUES('" + strRefNo + lngloop + "'," + lngloop + ",";
                            strSQL = strSQL + "'" + strBranchID + "',";
                            strSQL = strSQL + "'" + strRefNo + "',";
                            strSQL = strSQL + " " + Utility.cvtSQLDateString(strdate) + ",";
                            strSQL = strSQL + "'" + vstrItemName + "',";
                            strSQL = strSQL + " " + dblOpeningQty + ",";
                            strSQL = strSQL + " " + dblopnRate  + ",";
                            strSQL = strSQL + " " + dblOpeningValue + ",";
                            strSQL = strSQL + "'Main Location'";
                            if (strBatch != "")
                            {
                                strSQL = strSQL + ",'" + strBatch + "' ";
                            }
                            strSQL = strSQL + ") ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            lngloop += 1;

                        }
                    }
                    else
                    {
                        strSQL = "SELECT GODOWNS_NAME FROM INV_GODOWNS WHERE GODOWNS_DEFAULT = 1 ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            strGodown = dr["GODOWNS_NAME"].ToString();
                        }
                        dr.Close();

                        strSQL = "SELECT GODOWNS_SERIAL FROM INV_GODOWNS WHERE GODOWNs_NAME = '" + strGodown + "' ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            strGodownSerial = dr["GODOWNS_SERIAL"].ToString();
                        }
                        dr.Close();
                        strSQL = "SELECT STOCKITEM_SERIAL FROM INV_STOCKITEM WHERE STOCKITEM_NAME = '" + vstrItemName + "' ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            strItemSerial = dr["STOCKITEM_SERIAL"].ToString();
                        }
                        dr.Close();

                        strRefNo = Utility.vtSTOCK_OPENING_STR + "0001" + strItemSerial + "-OPN" + lngloop + strGodownSerial;
                        strInOutFlg = "1";
                        dblqty = dblOpnQty;
                        strSQL = "DELETE FROM INV_TRAN  where INV_REF_NO='" + strRefNo + "' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "DELETE FROM INV_MASTER   where INV_REF_NO='" + strRefNo + "' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO INV_MASTER ";
                        strSQL = strSQL + "(INV_REF_NO,INV_DATE,INWORD_QUANTITY,INV_OPENING_FLAG,BRANCH_ID) ";
                        strSQL = strSQL + "VALUES('" + strRefNo + "'," + Utility.cvtSQLDateString(strdate) + ",";
                        strSQL = strSQL + " " + dblqty + "," + strInOutFlg + ",";
                        strSQL = strSQL + "'0001'";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO INV_TRAN ";
                        strSQL = strSQL + "(INV_TRAN_KEY,INV_TRAN_POSITION,BRANCH_ID,INV_REF_NO,INV_DATE,STOCKITEM_NAME,";
                        strSQL = strSQL + "INV_TRAN_QUANTITY,INV_TRAN_RATE,INV_TRAN_AMOUNT,GODOWNS_NAME,";
                        strSQL = strSQL + "INV_VOUCHER_TYPE,INV_OPENING_FLAG ";
                        if (strBatch != "")
                        {
                            strSQL = strSQL + ",INV_LOG_NO";
                        }
                        strSQL = strSQL + ") ";
                        strSQL = strSQL + "VALUES('" + strRefNo + "',";
                        strSQL = strSQL + "" + lngloop + ",'0001',";
                        strSQL = strSQL + "'" + strRefNo + "'," + Utility.cvtSQLDateString(strdate) + ",";
                        strSQL = strSQL + "'" + vstrItemName + "'," + dblqty + ",";
                        strSQL = strSQL + " " + dblopnRate + "," + dblOpeningValue + ",";
                        strSQL = strSQL + "'" + strGodown.Replace("'", "''") + "',";
                        strSQL = strSQL + 0 + ",1";
                        if (strBatch != "")
                        {
                            strSQL = strSQL + ",'" + strBatch.Replace("'", "''") + "'";
                        }
                        strSQL = strSQL + ") ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                    }


                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public List<StockItem> mDisplayItemRecord(string strDeComID, long vstrPrimaryKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM INV_STOCKITEM ";
            strSQL = strSQL + "WHERE STOCKITEM_SERIAL = " + vstrPrimaryKey + " ";
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                if (drGetGroup.Read())
                {
                    StockItem ogrp = new StockItem();
                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.strItemcode = drGetGroup["STOCKITEM_ALIAS"].ToString();
                    if (drGetGroup["STOCKITEM_DESCRIPTION"].ToString() != "")
                    {
                        ogrp.strItemDescription = drGetGroup["STOCKITEM_DESCRIPTION"].ToString();
                    }
                    else
                    {
                        ogrp.strItemDescription = "";
                    }
                    ogrp.strItemGroup = drGetGroup["STOCKGROUP_NAME"].ToString();
                    ogrp.strUnit = drGetGroup["STOCKITEM_BASEUNITS"].ToString();
                    if (drGetGroup["STOCKITEM_ADDITIONALUNITS"].ToString() != "")
                    {
                        ogrp.strAltUnit = drGetGroup["STOCKITEM_ADDITIONALUNITS"].ToString();
                        ogrp.strConversion = drGetGroup["STOCKITEM_CONVERSION"].ToString();
                        ogrp.strDenominator = drGetGroup["STOCKITEM_DENOMINATOR"].ToString();
                    }
                    else
                    {
                        ogrp.strAltUnit = "";
                        ogrp.strConversion = "";
                        ogrp.strDenominator = "";
                    }
                    ogrp.dblOpnQty = Convert.ToDouble(drGetGroup["STOCKITEM_OPENING_BALANCE"].ToString());
                    ogrp.dblOpnRate = Convert.ToDouble(drGetGroup["STOCKITEM_OPENING_RATE"].ToString());
                    ogrp.dblOpnValue = Convert.ToDouble(drGetGroup["STOCKITEM_OPENING_VALUE"].ToString());
                    ogrp.dblMinimumStock = Convert.ToDouble(drGetGroup["STOCKITEM_MIN_QUANTITY"].ToString());
                    ogrp.dblReorderQty = Convert.ToDouble(drGetGroup["STOCKITEM_REORDER_LEVEL"].ToString());
                    if (drGetGroup["STOCKITEM_MANUFACTURER"].ToString() != "")
                    {
                        ogrp.strManufacturer = drGetGroup["STOCKITEM_MANUFACTURER"].ToString();
                    }
                    else
                    {
                        ogrp.strManufacturer = "";
                    }
                    //ogrp.str = drGetGroup["STOCK_ITEM_SUPPLIER"].ToString();
                    //ogrp.strItemName = drGetGroup["STOCKOTHERS_NAME"].ToString();
                    if (drGetGroup["ITEM_NAME_BANGLA"].ToString() != "")
                    {
                        ogrp.strItemNameBangla = drGetGroup["ITEM_NAME_BANGLA"].ToString();
                    }
                    else
                    {
                        ogrp.strItemNameBangla = "";
                    }

                    if (drGetGroup["MATERIAL_TYPE"].ToString() != "")
                    {
                        ogrp.strMatType = drGetGroup["MATERIAL_TYPE"].ToString();
                    }
                    else
                    {
                        ogrp.strMatType = "";
                    }
                    if (drGetGroup["STOCKCATEGORY_NAME"].ToString() != "")
                    {
                        ogrp.strItemCategory = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strItemCategory = "";
                    }
                    if (drGetGroup["POWER_CLASS"].ToString() != "")
                    {
                        ogrp.strPowerClass = drGetGroup["POWER_CLASS"].ToString();
                    }
                    else
                    {
                        ogrp.strPowerClass = "";
                    }

                    ogrp.intMaintainBatch = Convert.ToInt32(drGetGroup["STOCKITEM_MAINTAIN_SERIAL"].ToString());

                    if (drGetGroup["STOCKITEM_STATUS"].ToString() == "0")
                    {
                        ogrp.strStatus = "No";
                    }
                    else
                    {
                        ogrp.strStatus = "Yes";
                    }
                    ogrp.intSPItem = Convert.ToInt16(drGetGroup["SP_ITEM"].ToString());
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> mLoadGodownData(string strDeComID, string vstrPrimaryKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM INV_TRAN ";
            strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + vstrPrimaryKey.Replace("'","''") + "'  AND INV_OPENING_FLAG = 1 ";
            strSQL = strSQL + "AND  INV_TRAN_QUANTITY > 0 ";
            strSQL = strSQL + "ORDER BY INV_TRAN_POSITION ";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strBranchName = drGetGroup["GODOWNS_NAME"].ToString();
                    ogrp.dblBranchQty = Convert.ToDouble(drGetGroup["INV_TRAN_QUANTITY"].ToString());
                    ogrp.dblBranchRate = Convert.ToDouble(drGetGroup["INV_TRAN_RATE"].ToString());
                    ogrp.dblBranchAmnout = Math.Round(Convert.ToDouble(drGetGroup["INV_TRAN_QUANTITY"].ToString()) * Convert.ToDouble(drGetGroup["INV_TRAN_RATE"].ToString()), 2);
                    if (drGetGroup["INV_LOG_NO"].ToString() != "")
                    {
                        ogrp.strBatch = drGetGroup["INV_LOG_NO"].ToString();
                    }
                    else
                    {
                        ogrp.strBatch = Utility.gcEND_OF_LIST;
                    }

                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }






        public string mUpdateStockItem(string strDeComID, long vstrPrimaryKey, string vstrName, string vstrUnder, long lngMaintainBatch, string vstrStatus,
                                       string vstrItemName, string vstrAlias, string vstrdescription, string vstrParent, string vstrCatgory,
                                       string vstrUnit, string vstrAltUnit, string vstrWhere, string vstrWhereUnit, string vstrManufacturer,
                                       string vstrSupplier, string vstrTransalator, string vstritemBangla, double dblMinimumstock, double dblReorderQty,
                                       double dblOpnQty, double dblopnRate, double dblAmnt, string dg, string strMatTytpe, string strpowerclass, string strBatch,int intSP)
        {
            long lngStockStatus = 0, lngloop = 1;
            string strSQL, strPrimary, strStockItem, strParent, strCategory = "", strOldStockItem = "", strGroupParent = "", strfiled = "", strInvMasterRef = "",
            strGodown = "", strdate = "01/01/1900", strBranchID = "", strGodownSerial = "", strItemSerial = "", strRefNo = "", strInOutFlg = "";
            double dblOpeningQty, dblOpeningValue, dblqty = 0, dblTranQty = 0, dblRate, dblOldQunatity = 0;
            bool blnInsert = false;
            int i = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();

                    strPrimary = Utility.gstrGetPrimary(strDeComID, vstrUnder.Replace("'", "''"));
                    if (vstrStatus == "Yes")
                    {
                        lngStockStatus = 1;
                    }

                    strStockItem = vstrItemName.Replace("'", "''");
                    strParent = vstrUnder.Replace("'", "''");
                    if (vstrCatgory != "")
                    {
                        strCategory = vstrCatgory.Replace("'", "''");
                    }
                    dblOpeningQty = dblOpnQty;
                    dblOpeningValue = dblAmnt;


                    SqlDataReader dr;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                 

                    strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_OPENING_BALANCE,STOCKITEM_OPENING_VALUE FROM INV_STOCKITEM ";
                    strSQL = strSQL + "WHERE STOCKITEM_SERIAL = " + vstrPrimaryKey + "";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        dblOldQunatity = Convert.ToDouble(dr["STOCKITEM_OPENING_BALANCE"].ToString());
                        strOldStockItem = dr["STOCKITEM_NAME"].ToString();
                    }
                    dr.Close();

                    strSQL = "SELECT STOCKGROUP_PRIMARY FROM INV_STOCKGROUP WHERE STOCKGROUP_NAME = '" + strParent + "'";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        strPrimary = dr["STOCKGROUP_PRIMARY"].ToString();
                    }
                    dr.Close();

                    strSQL = "SELECT STOCKGROUP_PARENT FROM INV_STOCKGROUP WHERE STOCKGROUP_NAME = '" + strPrimary + "'";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        strGroupParent = dr["STOCKGROUP_PARENT"].ToString();
                    }
                    dr.Close();

                    strSQL = "SELECT INV_REF_NO FROM INV_TRAN WHERE STOCKITEM_NAME = '" + strOldStockItem.Replace("'","''") + "'";
                    strSQL = strSQL + "AND INV_VOUCHER_TYPE = 0 ";
                    strSQL = strSQL + "AND INV_INOUT_FLAG IS NULL ";
                    strSQL = strSQL + "AND INV_TRAN_QUANTITY > 0 ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strInvMasterRef = strInvMasterRef + dr["INV_REF_NO"].ToString() +"~";
                    }
                    dr.Close();
                    if (strInvMasterRef =="")
                    {
                        strSQL = "SELECT INV_REF_NO FROM INV_TRAN WHERE STOCKITEM_NAME = '" + strOldStockItem.Replace("'", "''") + "'";
                        strSQL = strSQL + "AND INV_VOUCHER_TYPE = 0";
                        strSQL = strSQL + "AND INV_INOUT_FLAG IS NULL";
                        //strSQL = strSQL + "AND INV_TRAN_QUANTITY > 0 ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        while (dr.Read())
                        {
                            strInvMasterRef = strInvMasterRef + dr["INV_REF_NO"].ToString() + "~";
                        }
                        dr.Close();
                    }
                    strSQL = "DELETE FROM INV_STOCKITEM_LEVEL WHERE STOCKITEM_NAME = '" + strOldStockItem.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_STOCKITEM_TO_GROUP WHERE STOCKITEM_NAME = '" + strOldStockItem.Replace("'", "''") + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (strInvMasterRef != "")
                    {
                        string[] words = strInvMasterRef.Split('~');
                        foreach (string ooGroups in words)
                        {
                            if (ooGroups != "")
                            {
                                strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO='" + ooGroups + "' ";
                                strSQL = strSQL + "AND INV_VOUCHER_TYPE=0 ";
                                strSQL = strSQL + " AND INV_INOUT_FLAG IS NULL ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                strSQL = "DELETE FROM INV_MASTER   where INV_REF_NO='" + ooGroups + "' ";
                                strSQL = strSQL + "AND INV_VOUCHER_TYPE=0 ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }
                    strSQL = "UPDATE INV_STOCKITEM SET ";
                    strSQL = strSQL + "STOCKITEM_NAME = '" + strStockItem + "',";
                    strSQL = strSQL + "STOCKGROUP_NAME = '" + strParent + "',";
                    strSQL = strSQL + "STOCKITEM_ALIAS = '" + vstrAlias + "',";
                    strSQL = strSQL + "STOCKITEM_DESCRIPTION = '" + vstrdescription + "',";
                    strSQL = strSQL + "STOCKITEM_PRIMARY_GROUP = '" + strPrimary + "',";
                    if (vstrCatgory != "")
                    {
                        strSQL = strSQL + "STOCKCATEGORY_NAME='" + strCategory + "',";
                    }
                    else
                    {
                        strSQL = strSQL + "STOCKCATEGORY_NAME = NULL ,";
                    }

                    strSQL = strSQL + "STOCKITEM_BASEUNITS = '" + vstrUnit + "',";

                    if (vstrAltUnit != "")
                    {
                        strSQL = strSQL + "STOCKITEM_ADDITIONALUNITS = '" + vstrAltUnit + "',";
                        strSQL = strSQL + "STOCKITEM_CONVERSION = " + vstrWhere + ",";
                        strSQL = strSQL + "STOCKITEM_DENOMINATOR = " + vstrWhereUnit + ",";
                    }

                    if (vstrManufacturer == "")
                    {
                        strSQL = strSQL + "STOCKITEM_MANUFACTURER = NULL ,";
                    }
                    else
                    {
                        strSQL = strSQL + "STOCKITEM_MANUFACTURER = '" + vstrManufacturer + "',";
                    }
                    strSQL = strSQL + "STOCKITEM_OPENING_BALANCE = " + dblOpnQty + ",";
                    strSQL = strSQL + "STOCKITEM_CLOSING_BALANCE = STOCKITEM_CLOSING_BALANCE - ";
                    strSQL = strSQL + dblOldQunatity + " + " + dblOpnQty + ",";
                    strSQL = strSQL + "STOCKITEM_OPENING_RATE = " + dblopnRate + ",";
                    strSQL = strSQL + "STOCKITEM_OPENING_VALUE = " + dblOpeningValue + ", ";
                    strSQL = strSQL + "STOCKITEM_MIN_QUANTITY = " + dblMinimumstock + ", ";
                    strSQL = strSQL + "STOCKITEM_REORDER_LEVEL = " + dblReorderQty + ", ";
                    strSQL = strSQL + "STOCKITEM_MAINTAIN_SERIAL = " + lngMaintainBatch + ", ";
                    strSQL = strSQL + "STOCKITEM_STATUS = " + lngStockStatus + " ";
                    //If uctxtManufacturer.Text = gcEND_OF_LIST Then
                    //    strSQL = strSQL + ",ISBN_NO = NULL "
                    //Else
                    //    strSQL = strSQL + ",ISBN_NO = '" + Replace$(uctxtIsbnNo.Text, "'", "''") + "'";
                    //End If

                    if (vstrSupplier == Utility.gcEND_OF_LIST)
                    {
                        strSQL = strSQL + ",STOCK_ITEM_SUPPLIER = NULL ";
                    }
                    else
                    {
                        strSQL = strSQL + ",STOCK_ITEM_SUPPLIER = '" + vstrSupplier + "' ";
                    }
                    if (vstrTransalator != "")
                    {
                        //strSQL = strSQL + ",STOCKOTHERS_NAME = NULL ";
                        //}
                        //else
                        //{
                        strSQL = strSQL + ",STOCKOTHERS_NAME = '" + vstrTransalator + "' ";
                    }
                    strSQL = strSQL + ",ITEM_NAME_BANGLA= '" + vstritemBangla + "'";
                    if (strMatTytpe != "")
                    {
                        strSQL = strSQL + ",MATERIAL_TYPE= '" + strMatTytpe + "'";
                    }
                    else
                    {
                        strSQL = strSQL + ",MATERIAL_TYPE= null";
                    }
                    strSQL = strSQL + ",POWER_CLASS= '" + strpowerclass + "'";
                    strSQL = strSQL + ",SP_ITEM=  " + intSP + " ";

                    //strSQL = strSQL + ",SERIAL_STATUS=" + 0 + " ";
                    strSQL = strSQL + "WHERE STOCKITEM_SERIAL = " + vstrPrimaryKey + " ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO INV_STOCKITEM_TO_GROUP(STOCKGROUP_NAME, STOCKITEM_NAME) ";
                    strSQL = strSQL + "VALUES('" + strParent + "','" + strStockItem + "')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    do
                    {

                        if (blnInsert == false)
                        {
                            strSQL = "SELECT STOCKGROUP_PARENT,STOCKGROUP_LEVEL FROM INV_STOCKGROUP ";
                            strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + strParent + "'";
                            SqlDataReader dr1;
                            cmdInsert.CommandText = strSQL;
                            dr1 = cmdInsert.ExecuteReader();
                            while (dr1.Read())
                            {
                                strPrimary = dr1["STOCKGROUP_PARENT"].ToString().Replace("'", "''");
                                if (strParent != dr1["STOCKGROUP_PARENT"].ToString())
                                {
                                    strfiled = strfiled + dr1["STOCKGROUP_PARENT"].ToString().Replace("'", "''") + "~";
                                }
                               
                            }
                          

                            if (strParent == strPrimary)
                            {
                                blnInsert = true;
                            }
                            else
                            {
                                strParent = strPrimary;
                            }


                            if (!dr1.HasRows)
                            {
                                blnInsert = true;
                            }
                            dr1.Close();
                            //   

                        }
                    }

                    while (blnInsert == false);

                    blnInsert = false;

                    if (strfiled != "")
                    {
                        i = 0;
                        string[] words = strfiled.Split('~');
                        foreach (string ooGroups in words)
                        {
                            if (ooGroups != "")
                            {
                                strSQL = "INSERT INTO INV_STOCKITEM_TO_GROUP(STOCKGROUP_NAME,STOCKITEM_NAME) ";
                                strSQL = strSQL + "VALUES('" + words[i].ToString() + "','" + strStockItem + "')";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                i += 1;
                            }

                        }
                    }
                    i = 0;
                    strfiled = "";


                    SqlDataReader dr2;
                    strSQL = "INSERT INTO INV_STOCKITEM_LEVEL(STOCKITEM_NAME,STOCKGROUP_LEVEL_1) ";
                    strSQL = strSQL + "VALUES('" + strStockItem + "','" + strParent + "')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //strSQL = "SELECT STOCKGROUP_NAME,STOCKGROUP_LEVEL FROM INV_STOCKITEM_TO_GROUP_QRY ";
                    //strSQL = strSQL + "WHERE STOCKGROUP_LEVEL > 1 ";
                    //strSQL = strSQL + "AND STOCKITEM_NAME = '" + strStockItem + "' ";
                    //strSQL = strSQL + "ORDER BY STOCKGROUP_LEVEL ";

                    strSQL = "SELECT INV_STOCKITEM_TO_GROUP.STOCKGROUP_NAME,INV_STOCKITEM_TO_GROUP.STOCKITEM_NAME, INV_STOCKGROUP.STOCKGROUP_LEVEL ";
                    strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM_TO_GROUP ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM_TO_GROUP.STOCKGROUP_NAME ";
                    strSQL = strSQL + "WHERE INV_STOCKGROUP.STOCKGROUP_LEVEL > 1 ";
                    strSQL = strSQL + "AND STOCKITEM_NAME = '" + strStockItem + "' ";
                    cmdInsert.CommandText = strSQL;
                    dr2 = cmdInsert.ExecuteReader();
                    while (dr2.Read())
                    {
                        if (Convert.ToInt64(dr2["STOCKGROUP_LEVEL"].ToString()) < 6)
                        {
                            strfiled = strfiled + "STOCKGROUP_LEVEL_" + dr2["STOCKGROUP_LEVEL"].ToString() + "|" + dr2["STOCKGROUP_NAME"].ToString() + "~";
                        }
                        else
                        {
                            strfiled = "";
                        }
                    }
                    dr2.Close();
                    if (strfiled != "")
                    {
                        string[] words = strfiled.Split('~');
                        foreach (string ooGroups in words)
                        {
                            string[] ooCost = ooGroups.Split('|');
                            if (ooCost[0] != "")
                            {
                                strSQL = "UPDATE INV_STOCKITEM_LEVEL SET " + ooCost[0] + " = '" + ooCost[1] + "' ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + strStockItem + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }
                    strfiled = "";


                    strSQL = "SELECT GODOWNS_NAME FROM INV_GODOWNS ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strfiled = strfiled + dr["GODOWNS_NAME"].ToString() + "~";
                    }
                    dr.Close();
                    if (strfiled != "")
                    {
                        string[] words = strfiled.Split('~');
                        foreach (string ooGroups in words)
                        {
                            if (words[i] != "")
                            {
                                strSQL = "SELECT GODOWNS_NAME FROM INV_STOCKITEM_CLOSING ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + strStockItem + "' ";
                                strSQL = strSQL + "AND GODOWNS_NAME = '" + words[i].ToString() + "' ";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (!dr.Read())
                                {
                                    dr.Close();
                                    strSQL = "INSERT INTO INV_STOCKITEM_CLOSING(";
                                    strSQL = strSQL + "STOCKITEM_NAME,GODOWNS_NAME) VALUES(";
                                    strSQL = strSQL + "'" + strStockItem + "',";
                                    strSQL = strSQL + "'" + words[i].ToString() + "'";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                            dr.Close();
                            i += 1;

                        }
                    }
                    dr.Close();
                    strfiled = "";
                    i = 0;

                    if (Utility.gblnLocation == false)
                    {
                        if (dg != "")
                        {

                            string[] words = dg.Split('~');
                            foreach (string ooGroups in words)
                            {
                                string[] ooCost = ooGroups.Split('|');
                                if (ooCost[0] != "")
                                {
                                    strSQL = "SELECT GODOWNS_SERIAL,BRANCH_ID FROM INV_GODOWNS WHERE GODOWNs_NAME = '" + ooCost[0].ToString() + "' ";
                                    cmdInsert.CommandText = strSQL;
                                    dr = cmdInsert.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        strGodownSerial = dr["GODOWNS_SERIAL"].ToString();
                                        strBranchID = dr["BRANCH_ID"].ToString();
                                    }
                                    dr.Close();
                                    strSQL = "SELECT max(INV_TRAN_SERIAL)+1 as STOCKITEM_SERIAL FROM INV_TRAN ";
                                    cmdInsert.CommandText = strSQL;
                                    dr = cmdInsert.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        strItemSerial = dr["STOCKITEM_SERIAL"].ToString();
                                    }
                                    dr.Close();


                                    if (Utility.gblnLocation == false)
                                    {
                                        dblqty = Convert.ToDouble(ooCost[1].ToString());
                                    }
                                    else
                                    {
                                        dblqty = dblOpnQty;
                                    }

                                    if (strRefNo == "")
                                    {
                                        strRefNo = Utility.vtSTOCK_OPENING_STR + strBranchID + strItemSerial + "-OPN" + lngloop + strGodownSerial;

                                        strSQL = "INSERT INTO INV_MASTER(INV_REF_NO,";
                                        strSQL = strSQL + "INWORD_QUANTITY,INV_OPENING_FLAG,BRANCH_ID,INV_DATE) ";
                                        strSQL = strSQL + "VALUES('" + strRefNo + "'," + dblqty + "," + (int)Utility.VOUCHER_TYPE.vtSTOCK_OPENING + ",";
                                        strSQL = strSQL + "'" + strBranchID + "',";
                                        strSQL = strSQL + "" + Utility.cvtSQLDateString(strdate) + ")";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                    if (Utility.gblnLocation == false)
                                    {
                                        dblTranQty = Convert.ToDouble(ooCost[1].ToString());
                                    }
                                    else
                                    {
                                        dblTranQty = dblOpnQty;
                                    }
                                    //strInOutFlg = "1";
                                    strSQL = "INSERT INTO INV_TRAN ";
                                    strSQL = strSQL + "(INV_TRAN_KEY,INV_TRAN_POSITION,BRANCH_ID,INV_REF_NO,INV_DATE,STOCKITEM_NAME,";
                                    strSQL = strSQL + "INV_TRAN_QUANTITY,INV_TRAN_RATE,INV_TRAN_AMOUNT,GODOWNS_NAME,";
                                    if (ooCost[4] != Utility.gcEND_OF_LIST && ooCost[4] != "")
                                    {
                                        strSQL = strSQL + "INV_LOG_NO,";
                                    }
                                    strSQL = strSQL + "INV_VOUCHER_TYPE,INV_OPENING_FLAG) ";
                                    strSQL = strSQL + "VALUES('" + strRefNo + lngloop + "'," + lngloop + ",";
                                    strSQL = strSQL + "'" + strBranchID + "',";
                                    strSQL = strSQL + "'" + strRefNo + "',";
                                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strdate) + ",";
                                    strSQL = strSQL + "'" + vstrItemName.Replace("'", "''") + "',";
                                    strSQL = strSQL + " " + dblTranQty + ",";
                                    if (Utility.gblnLocation == false)
                                    {
                                        dblRate = Convert.ToDouble(ooCost[2]);
                                        strSQL = strSQL + " " + dblRate + ",";//   'Rate
                                        strSQL = strSQL + " " + Convert.ToDouble(ooCost[1]) * dblRate + ",";//   'Amount
                                    }
                                    else
                                    {

                                        dblRate = dblopnRate;
                                        strSQL = strSQL + " " + dblRate + ",";//   'Rate
                                        strSQL = strSQL + " " + dblOpeningValue + ",";  //  'Amount
                                    }
                                    strSQL = strSQL + "'" + ooCost[0] + "',";
                                    if (ooCost[4] != Utility.gcEND_OF_LIST && ooCost[4] != "")
                                    {
                                        strSQL = strSQL + "'" + ooCost[4].ToString() + "',";
                                    }
                                    strSQL = strSQL + (int)Utility.VOUCHER_TYPE.vtSTOCK_OPENING + ",1)";

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    lngloop += 1;
                                }

                            }
                        }
                        else
                        {
                            strSQL = "SELECT GODOWNS_SERIAL,BRANCH_ID FROM INV_GODOWNS WHERE GODOWNs_NAME = 'Main Location' ";
                            cmdInsert.CommandText = strSQL;
                            dr = cmdInsert.ExecuteReader();
                            if (dr.Read())
                            {
                                strGodownSerial = dr["GODOWNS_SERIAL"].ToString();
                                strBranchID = dr["BRANCH_ID"].ToString();
                            }
                            dr.Close();
                            strSQL = "SELECT max(INV_TRAN_SERIAL)+1 as STOCKITEM_SERIAL FROM INV_TRAN ";
                            cmdInsert.CommandText = strSQL;
                            dr = cmdInsert.ExecuteReader();
                            if (dr.Read())
                            {
                                strItemSerial = dr["STOCKITEM_SERIAL"].ToString();
                            }
                            dr.Close();


                            if (Utility.gblnLocation == false)
                            {
                                dblqty = 0;
                            }
                            else
                            {
                                dblqty = 0;
                            }

                            if (strRefNo == "")
                            {
                                strRefNo = Utility.vtSTOCK_OPENING_STR + strBranchID + strItemSerial + "-OPN" + lngloop + strGodownSerial;

                                strSQL = "INSERT INTO INV_MASTER(INV_REF_NO,";
                                strSQL = strSQL + "INWORD_QUANTITY,INV_OPENING_FLAG,BRANCH_ID,INV_DATE) ";
                                strSQL = strSQL + "VALUES('" + strRefNo + "'," + dblqty + "," + (int)Utility.VOUCHER_TYPE.vtSTOCK_OPENING + ",";
                                strSQL = strSQL + "'" + strBranchID + "',";
                                strSQL = strSQL + "" + Utility.cvtSQLDateString(strdate) + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }

                            strSQL = "INSERT INTO INV_TRAN ";
                            strSQL = strSQL + "(INV_TRAN_KEY,INV_TRAN_POSITION,BRANCH_ID,INV_REF_NO,INV_DATE,STOCKITEM_NAME,";
                            strSQL = strSQL + "INV_TRAN_QUANTITY,INV_TRAN_RATE,INV_TRAN_AMOUNT,GODOWNS_NAME";
                            if (strBatch != "")
                            {
                                strSQL = strSQL + ",INV_LOG_NO";
                            }
                            strSQL = strSQL + ") ";
                            strSQL = strSQL + "VALUES('" + strRefNo + lngloop + "'," + lngloop + ",";
                            strSQL = strSQL + "'" + strBranchID + "',";
                            strSQL = strSQL + "'" + strRefNo + "',";
                            strSQL = strSQL + " " + Utility.cvtSQLDateString(strdate) + ",";
                            strSQL = strSQL + "'" + vstrItemName.Replace("'", "''") + "',";
                            strSQL = strSQL + " " + dblOpnQty + ",";
                            strSQL = strSQL + " " + dblopnRate + ",";//   'Rate
                            strSQL = strSQL + " " + dblOpeningValue + ",";  //  'Amount

                            strSQL = strSQL + "'Main Location'";
                            if (strBatch != "")
                            {
                                strSQL = strSQL + ",'" + strBatch + "' ";
                            }
                            strSQL = strSQL + ") ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            lngloop += 1;


                        }
                    }
                    else
                    {
                        strSQL = "SELECT GODOWNS_NAME FROM INV_GODOWNS WHERE GODOWNS_DEFAULT = 1 ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            strGodown = dr["GODOWNS_NAME"].ToString();
                        }
                        dr.Close();

                        strSQL = "SELECT GODOWNS_SERIAL FROM INV_GODOWNS WHERE GODOWNs_NAME = '" + strGodown + "' ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            strGodownSerial = dr["GODOWNS_SERIAL"].ToString();
                        }
                        dr.Close();
                        strSQL = "SELECT STOCKITEM_SERIAL FROM INV_STOCKITEM WHERE STOCKITEM_NAME = '" + vstrItemName.Replace("'", "''") + "' ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            strItemSerial = dr["STOCKITEM_SERIAL"].ToString();
                        }
                        dr.Close();

                        strRefNo = Utility.vtSTOCK_OPENING_STR + "0001" + strItemSerial + "-OPN" + lngloop + strGodownSerial;
                        strInOutFlg = "1";
                        dblqty = dblOpnQty;
                        strSQL = "DELETE FROM INV_TRAN  WHERE INV_REF_NO='" + strRefNo + "' ";
                        strSQL = strSQL + "AND INV_VOUCHER_TYPE=0 ";
                        strSQL = strSQL + " AND INV_INOUT_FLAG IS NULL ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO='" + strRefNo + "' ";
                        strSQL = strSQL + "AND INV_VOUCHER_TYPE=0 ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO INV_MASTER ";
                        strSQL = strSQL + "(INV_REF_NO,INV_DATE,INWORD_QUANTITY,INV_OPENING_FLAG,BRANCH_ID) ";
                        strSQL = strSQL + "VALUES('" + strRefNo + "'," + Utility.cvtSQLDateString(strdate) + ",";
                        strSQL = strSQL + " " + dblqty + "," + strInOutFlg + ",";
                        strSQL = strSQL + "'0001'";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO INV_TRAN ";
                        strSQL = strSQL + "(INV_TRAN_KEY,INV_TRAN_POSITION,BRANCH_ID,INV_REF_NO,INV_DATE,STOCKITEM_NAME,";
                        strSQL = strSQL + "INV_TRAN_QUANTITY,INV_TRAN_RATE,INV_TRAN_AMOUNT,GODOWNS_NAME,";
                        strSQL = strSQL + "INV_VOUCHER_TYPE,INV_OPENING_FLAG ";
                        if (strBatch != "")
                        {
                            strSQL = strSQL + ",INV_LOG_NO";
                        }
                        strSQL = strSQL + ")";
                        strSQL = strSQL + "VALUES('" + strRefNo + "',";
                        strSQL = strSQL + "" + lngloop + ",'0001',";
                        strSQL = strSQL + "'" + strRefNo + "'," + Utility.cvtSQLDateString(strdate) + ",";
                        strSQL = strSQL + "'" + vstrItemName.Replace("'", "''") + "'," + dblqty + ",";
                        strSQL = strSQL + " " + dblopnRate + "," + dblOpeningValue + ",";
                        strSQL = strSQL + "'" + strGodown.Replace("'", "''") + "',";
                        strSQL = strSQL + 0 + ",1";
                        if (strBatch != "")
                        {
                            strSQL = strSQL + ",'" + strGodown.Replace("'", "''") + "'";
                        }
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                    }


                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Updated...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }


        public List<StockItem> mFillStockItemList(string strDeComID, int intStatus, string vstrPrefix = "",string strAlias="")
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKITEM_SERIAL,STOCKITEM_ALIAS,STOCKITEM_NAME,STOCKGROUP_NAME,";
            strSQL = strSQL + "STOCKITEM_OPENING_BALANCE,STOCKITEM_CLOSING_BALANCE FROM INV_STOCKITEM ";
            if (intStatus > 0)
            {
                strSQL = strSQL + "WHERE STOCKITEM_STATUS > 0 ";
            }
            else
            {
                strSQL = strSQL + "WHERE STOCKITEM_STATUS = 0 ";
            }
            if (vstrPrefix != "")
            {
                if (strAlias == "")
                {
                    strSQL = strSQL + "and STOCKITEM_NAME LIKE '" + "%" + vstrPrefix + "%" + "' ";
                }
                else
                {
                    strSQL = strSQL + "and STOCKITEM_ALIAS LIKE '" + "%" + vstrPrefix + "%" + "' ";
                }
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
                    StockItem ogrp = new StockItem();
                    ogrp.lngSlNo = Convert.ToInt64(drGetGroup["STOCKITEM_SERIAL"].ToString());
                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    if (drGetGroup["STOCKITEM_ALIAS"].ToString() != "")
                    {
                        ogrp.strItemcode = drGetGroup["STOCKITEM_ALIAS"].ToString();
                    }
                    else
                    {
                        ogrp.strItemcode = "";
                    }
                    ogrp.strItemGroup = drGetGroup["STOCKGROUP_NAME"].ToString();
                    ogrp.dblOpnValue = Convert.ToDouble(drGetGroup["STOCKITEM_OPENING_BALANCE"].ToString());

                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> mFillStockItemListNew(string strDeComID,int intType,int intSP)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            if (intType == 0)
            {
                strSQL = "select STOCKGROUP_NAME,  STOCKITEM_NAME ,STOCKCATEGORY_NAME  ";
                strSQL=strSQL + "from INV_STOCKITEM ";
                strSQL = strSQL + "WHERE SP_ITEM=" + intSP + " ";
                strSQL = strSQL + "Order By STOCKITEM_NAME ";
            }
            else
            {
                strSQL = " select distinct STOCKGROUP_NAME, '' STOCKITEM_NAME ,STOCKCATEGORY_NAME  from INV_STOCKITEM where STOCKCATEGORY_NAME is not null ";
                strSQL = strSQL + "AND SP_ITEM=" + intSP + " ";
                strSQL = strSQL + "Order By STOCKCATEGORY_NAME ";
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
                    StockItem ogrp = new StockItem();
                    if ( drGetGroup["STOCKITEM_NAME"].ToString() !="")
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strItemName="";
                    }
                    if ( drGetGroup["STOCKCATEGORY_NAME"].ToString() !="")
                    {
                        ogrp.strItemCategory = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strItemCategory="";
                    }
                    ogrp.strItemGroup = drGetGroup["STOCKGROUP_NAME"].ToString();
                    

                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> mFillStockItemListNewEdit(string strDeComID, int intType, string strRefNo)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            if (intType == 0)
            {
                strSQL = "select distinct SALES_TARGET_ITEM_TRAN.STOCKITEM_NAME,'' STOCKCATEGORY_NAME  from SALES_TARGET_ITEM_PACK_MASTER,SALES_TARGET_ITEM_TRAN where SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_KEY=SALES_TARGET_ITEM_TRAN.TARGET_ITEM_TRAN_KEY";
                strSQL = strSQL + " AND SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_KEY='" + strRefNo + "' ";
                strSQL = strSQL + " order by SALES_TARGET_ITEM_TRAN.STOCKITEM_NAME";
            }
            else
            {
                strSQL = "select distinct '' STOCKITEM_NAME, SALES_TARGET_ITEM_TRAN.STOCKCATEGORY_NAME  from SALES_TARGET_ITEM_PACK_MASTER,SALES_TARGET_ITEM_TRAN where SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_KEY=SALES_TARGET_ITEM_TRAN.TARGET_ITEM_TRAN_KEY";
                strSQL = strSQL + " AND SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_KEY='" + strRefNo + "' ";
                strSQL = strSQL + "order by SALES_TARGET_ITEM_TRAN.STOCKCATEGORY_NAME";
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
                    StockItem ogrp = new StockItem();
                    if (drGetGroup["STOCKITEM_NAME"].ToString() != "")
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strItemName = "";
                    }
                    if (drGetGroup["STOCKCATEGORY_NAME"].ToString() != "")
                    {
                        ogrp.strItemCategory = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strItemCategory = "";
                    }
                    //ogrp.strItemGroup = drGetGroup["STOCKGROUP_NAME"].ToString();


                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mDeleteStockItem(string strDeComID, string vstrPrimaryKey)
        {

            string strSQL, strResponse, strInvoiceNo = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();

                    SqlDataReader dr;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;


                    strSQL = "SELECT * FROM INV_TRAN WHERE STOCKITEM_NAME = '" + vstrPrimaryKey + "' AND INV_OPENING_FLAG <> 1 ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        strResponse = "Related Transaction exists. Can't delete";
                        return strResponse;
                    }
                    dr.Close();

                    strSQL = "SELECT INV_REF_NO FROM INV_TRAN WHERE STOCKITEM_NAME = '" + vstrPrimaryKey + "' AND INV_OPENING_FLAG = 1";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        strInvoiceNo = dr["INV_REF_NO"].ToString();
                    }
                    dr.Close();



                    strSQL = "DELETE FROM INV_SALES_PRICE WHERE STOCKITEM_NAME = '" + vstrPrimaryKey + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_TRAN WHERE STOCKITEM_NAME = '" + vstrPrimaryKey + "' ";
                    strSQL = strSQL + "AND INV_OPENING_FLAG=1 ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO  = '" + strInvoiceNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_STOCKITEM_CLOSING WHERE STOCKITEM_NAME  = '" + vstrPrimaryKey + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_STOCKITEM_LEVEL WHERE STOCKITEM_NAME  = '" + vstrPrimaryKey + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                  

                    strSQL = "DELETE FROM INV_STOCKITEM_TO_GROUP WHERE STOCKITEM_NAME  = '" + vstrPrimaryKey + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_STOCKITEM WHERE STOCKITEM_NAME  = '" + vstrPrimaryKey + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return ("Transaction Found Cannot Delete");
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public List<StockItem> mFillStockTreeGroupLevel(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKGROUP_NAME FROM INV_STOCKGROUP ";
            strSQL = strSQL + "WHERE STOCKGROUP_LEVEL = 1";
            strSQL = strSQL + "ORDER BY STOCKGROUP_SERIAL ";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemGroup = drGetGroup["STOCKGROUP_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }



        public List<StockItem> mFillStockTreeGroupLevel1(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKGROUP_NAME,STOCKGROUP_PARENT FROM INV_STOCKGROUP ";
            strSQL = strSQL + "WHERE STOCKGROUP_LEVEL <> 1";
            strSQL = strSQL + "ORDER BY STOCKGROUP_LEVEL ";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemGroup = drGetGroup["STOCKGROUP_NAME"].ToString();
                    ogrp.strParentGroup = drGetGroup["STOCKGROUP_PARENT"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> gFillStockItemManufacturer(string strDeComID, string vstrManufacturer, string vstrGodown, long vlngStockType)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_CLOSING_BALANCE,STOCKITEM_BASEUNITS,";
            strSQL = strSQL + "STOCKITEM_ALIAS FROM INV_STOCK_CLOSING_QRY ";
            strSQL = strSQL + "WHERE GODOWNS_NAME ='" + vstrGodown.Replace("'", "''") + "' ";
            strSQL = strSQL + "AND STOCKITEM_MANUFACTURER = '" + vstrManufacturer.Replace("'", "''") + "' ";
            strSQL = strSQL + "ORDER BY STOCKITEM_NAME ";
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
                    StockItem ogrp = new StockItem();
                    if (Utility.gblnStockItemAlias)
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> mloadAddStockItemFg(string strDeComID, string strRawLocation)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();

            //strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_ALIAS FROM INV_STOCKITEM ";
            //strSQL = strSQL + "WHERE STOCKGROUP_NAME like'%Raw%' ";
            //strSQL = strSQL + "or STOCKGROUP_NAME like '%Work In%' ";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            if (strRawLocation != "")
            {
                //strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_ALIAS,STOCKITEM_CLOSING_BALANCE,STOCKITEM_BASEUNITS FROM INV_MANUFACTURE_ITEM_QRY ";
                //strSQL = strSQL + "WHERE STOCKGROUP_PRIMARY_TYPE IN(3) ";
                //strSQL = strSQL + "AND GODOWNS_NAME= '" + strRawLocation + "' ";


                strSQL = "SELECT INV_STOCKITEM_CLOSING.STOCKITEM_NAME,INV_STOCKITEM_CLOSING.STOCKITEM_CLOSING_BALANCE,INV_STOCKITEM.STOCKITEM_BASEUNITS ";
                strSQL = strSQL + "FROM INV_STOCKITEM_CLOSING INNER JOIN INV_STOCKITEM ON INV_STOCKITEM_CLOSING.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME ";
                strSQL = strSQL + "WHERE INV_STOCKITEM_CLOSING.GODOWNS_NAME = '" + strRawLocation + "' ";
                strSQL = strSQL + " AND INV_STOCKITEM.STOCKITEM_STATUS = 0 AND STOCKITEM_PRIMARY_GROUP = 'Finished Goods' ";
                strSQL = strSQL + "ORDER BY INV_STOCKITEM_CLOSING.STOCKITEM_NAME ";
            }
            else
            {
                strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_ALIAS,sum(STOCKITEM_CLOSING_BALANCE) as STOCKITEM_CLOSING_BALANCE ,STOCKITEM_BASEUNITS FROM INV_MANUFACTURE_ITEM_QRY ";
                strSQL = strSQL + "WHERE STOCKGROUP_PRIMARY_TYPE IN(3) ";
                strSQL = strSQL + "GROUP by STOCKITEM_NAME,STOCKITEM_ALIAS,STOCKITEM_BASEUNITS ";
                strSQL = strSQL + "ORDER BY STOCKITEM_NAME ";
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
                    StockItem ogrp = new StockItem();
                    if (Utility.gblnStockItemAlias)
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_ALIAS"].ToString() + " " + drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    ogrp.dblClsBalance = Convert.ToDouble(drGetGroup["STOCKITEM_CLOSING_BALANCE"]);
                    ogrp.strUnit = drGetGroup["STOCKITEM_BASEUNITS"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> mloadAddStockItemRMPack(string strDeComID, string strRawLocation,string strGroupName,string strFGYN)
        {
            string strSQL,strStockGroupName="";
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();

            //strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_ALIAS FROM INV_STOCKITEM ";
            //strSQL = strSQL + "WHERE STOCKGROUP_NAME like'%Raw%' ";
            //strSQL = strSQL + "or STOCKGROUP_NAME like '%Work In%' ";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


           

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                
                if (strGroupName != "")
                {
                    strSQL = "SELECT LEDGER_PARENT_GROUP  from ACC_LEDGER WHERE LEDGER_NAME= '" + strGroupName + "' ";
                    cmd.CommandText = strSQL;
                    drGetGroup = cmd.ExecuteReader();
                    if (drGetGroup.Read())
                    {
                        if (drGetGroup["LEDGER_PARENT_GROUP"].ToString() == "Direct Raw Materials Purchase")
                        {
                            strStockGroupName = "Direct Raw Materials";
                        }
                        if (drGetGroup["LEDGER_PARENT_GROUP"].ToString() == "Indirect Raw Materials Purchase")
                        {
                            strStockGroupName = "Indirect Raw Materials";
                        }
                    }

                    drGetGroup.Close();
                }

                strSQL = "";

                strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_ALIAS,SUM(STOCKITEM_CLOSING_BALANCE) as STOCKITEM_CLOSING_BALANCE ,STOCKITEM_BASEUNITS FROM INV_MANUFACTURE_ITEM_QRY ";
                if (strFGYN == "Y")
                {
                    strSQL = strSQL + "WHERE STOCKGROUP_PRIMARY_TYPE IN(1,2,3) ";
                }
                else
                {
                    strSQL = strSQL + "WHERE STOCKGROUP_PRIMARY_TYPE IN(1,2) ";
                }
                if (strRawLocation != "")
                {
                    strSQL = strSQL + "AND GODOWNS_NAME= '" + strRawLocation + "' ";
                }
                if (strStockGroupName != "")
                {
                    strSQL = strSQL + "AND STOCKGROUP_PRIMARY = '" + strStockGroupName + "' ";
                }
                strSQL = strSQL + "GROUP by STOCKITEM_NAME,STOCKITEM_ALIAS,STOCKITEM_BASEUNITS ";
                strSQL = strSQL + "ORDER BY STOCKITEM_NAME ";
                cmd.CommandText = strSQL;
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    StockItem ogrp = new StockItem();
                    if (Utility.gblnStockItemAlias)
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_ALIAS"].ToString() + " " + drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    ogrp.dblClsBalance = Convert.ToDouble(drGetGroup["STOCKITEM_CLOSING_BALANCE"]);
                    ogrp.strUnit = drGetGroup["STOCKITEM_BASEUNITS"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> mloadAddStockItem(string strDeComID, string vstrRoot)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_ALIAS FROM INV_STOCKITEM ";
            strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + vstrRoot + "' ";

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
                    StockItem ogrp = new StockItem();
                    if (Utility.gblnStockItemAlias)
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_ALIAS"].ToString() + " " + drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> mloadAddStockItemSI(string strDeComID, string vstrRoot, string strLocation)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            // strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_ALIAS FROM INV_STOCKITEM ";
            //strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + vstrRoot + "' ";
            strSQL = "SELECT STOCKITEM_CLOSING_VIEW.STOCKITEM_NAME,ISNULL(SUM(STOCKITEM_CLOSING_VIEW.STOCKITEM_CLOSING_BALANCE-STOCKITEM_CLOSING_VIEW.STOCKITEM_SALE_BALANCE),0) CLS,STOCKITEM_CLOSING_VIEW.STOCKITEM_BASEUNITS ";
            strSQL = strSQL + "from STOCKITEM_CLOSING_VIEW,INV_STOCKITEM where  INV_STOCKITEM.STOCKITEM_NAME=STOCKITEM_CLOSING_VIEW.STOCKITEM_NAME ";
            strSQL = strSQL + "AND STOCKGROUP_NAME = '" + vstrRoot + "' ";
            strSQL = strSQL + "AND GODOWNS_NAME='" + strLocation + "' ";
            strSQL = strSQL + "GROUP by STOCKITEM_CLOSING_VIEW.STOCKITEM_NAME,STOCKITEM_CLOSING_VIEW.STOCKITEM_BASEUNITS ";

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
                    StockItem ogrp = new StockItem();
                    if (Utility.gblnStockItemAlias)
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_ALIAS"].ToString() + " " + drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    ogrp.dblClsBalance = Convert.ToDouble(drGetGroup["CLS"]);
                    ogrp.strUnit = drGetGroup["STOCKITEM_BASEUNITS"].ToString();

                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }


        //public List<StockItem> mloadAddStockItemNew(string strDeComID, string vstrRoot, string strLocation)
        //{
        //    string strSQL;
        //    SqlDataReader drGetGroup;
        //    List<StockItem> oogrp = new List<StockItem>();
        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);
        //    // strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_ALIAS FROM INV_STOCKITEM ";
        //    //strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + vstrRoot + "' ";
        //    //strSQL = "SELECT STOCKITEM_CLOSING_VIEW.STOCKITEM_NAME,ISNULL(SUM(STOCKITEM_CLOSING_VIEW.STOCKITEM_CLOSING_BALANCE),0) CLS,STOCKITEM_CLOSING_VIEW.STOCKITEM_BASEUNITS ";
        //    //strSQL = strSQL + "from STOCKITEM_CLOSING_VIEW,INV_STOCKITEM where  INV_STOCKITEM.STOCKITEM_NAME=STOCKITEM_CLOSING_VIEW.STOCKITEM_NAME ";
        //    //strSQL = strSQL + "AND STOCKGROUP_NAME = '" + vstrRoot + "' ";
        //    //strSQL = strSQL + "AND GODOWNS_NAME='" + strLocation + "' ";
        //    //strSQL = strSQL + "GROUP by STOCKITEM_CLOSING_VIEW.STOCKITEM_NAME,STOCKITEM_CLOSING_VIEW.STOCKITEM_BASEUNITS ";

        //    strSQL = "SELECT INV_STOCKITEM.STOCKITEM_ALIAS, INV_STOCKITEM.STOCKITEM_NAME,INV_STOCKITEM.STOCKITEM_BASEUNITS,SUM(INV_TRAN.INV_TRAN_QUANTITY) CLS";
        //    strSQL = strSQL + " FROM INV_TRAN ,INV_STOCKITEM WHERE INV_STOCKITEM.STOCKITEM_NAME =INV_TRAN.STOCKITEM_NAME ";
        //    if (vstrRoot != "")
        //    {
        //        strSQL = strSQL + " AND INV_STOCKITEM.STOCKGROUP_NAME = '" + vstrRoot + "' ";
        //    }
        //    strSQL = strSQL + " AND INV_TRAN.GODOWNS_NAME='" + strLocation + "' ";
        //    strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_STATUS=0 ";
        //    strSQL = strSQL + "GROUP BY INV_STOCKITEM.STOCKITEM_ALIAS,INV_STOCKITEM.STOCKITEM_NAME,INV_STOCKITEM.STOCKITEM_BASEUNITS ";

        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();

        //        SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
        //        drGetGroup = cmd.ExecuteReader();
        //        while (drGetGroup.Read())
        //        {
        //            StockItem ogrp = new StockItem();
        //            if (Utility.gblnStockItemAlias)
        //            {
        //                ogrp.strItemName = drGetGroup["STOCKITEM_ALIAS"].ToString() + " " + drGetGroup["STOCKITEM_NAME"].ToString();
        //            }
        //            else
        //            {
        //                ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
        //            }
        //            ogrp.dblClsBalance = Convert.ToDouble(drGetGroup["CLS"]);
        //            ogrp.strUnit = drGetGroup["STOCKITEM_BASEUNITS"].ToString();

        //            oogrp.Add(ogrp);
        //        }
        //        drGetGroup.Close();
        //        gcnMain.Dispose();
        //        return oogrp;

        //    }
        //}

        public List<StockItem> mloadStockItemNotInGroup(string strDeComID, string vstrRoot)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_ALIAS FROM INV_STOCKITEM ";
            strSQL = strSQL + "WHERE STOCKGROUP_NAME <> '" + vstrRoot + "' ";

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
                    StockItem ogrp = new StockItem();
                    if (Utility.gblnStockItemAlias)
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_ALIAS"].ToString() + " " + drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    }
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> gFillStockItem(string strDeComID, string vstrGodown = "", string vstrPrefix = "", bool blngAlias = true)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_CLOSING_BALANCE,STOCKITEM_ALIAS,STOCKITEM_BASEUNITS FROM STOCKITEM_CLOSING_VIEW ";
            if (vstrGodown != "")
            {
                strSQL = strSQL + "WHERE GODOWNS_NAME='" + vstrGodown + "' ";
                if (blngAlias == false)
                {
                    strSQL = strSQL + " AND STOCKITEM_NAME LIKE '" + vstrPrefix.Trim() + "%'";
                }

                else
                {
                    strSQL = strSQL + " AND STOCKITEM_ALIAS LIKE '" + vstrPrefix.Trim() + "%'";
                }
            }
            strSQL = strSQL + "ORDER BY STOCKITEM_NAME ASC";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    if (drGetGroup["STOCKITEM_ALIAS"].ToString() != "")
                    {
                        ogrp.strItemcode = drGetGroup["STOCKITEM_ALIAS"].ToString();
                    }
                    ogrp.strUnit = drGetGroup["STOCKITEM_BASEUNITS"].ToString();
                    ogrp.dblClsBalance = Convert.ToDouble(drGetGroup["STOCKITEM_CLOSING_BALANCE"].ToString());
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public List<StockItem> gFillStockItemAllWithoutGodown(string strDeComID, bool blngAccessControl, string strUserName,string vstrGroupName)
        {
            string strSQL;

            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            if (blngAccessControl)
            {
                strSQL = "SELECT INV_STOCKITEM.STOCKITEM_NAME FROM INV_STOCKITEM,INV_STOCKGROUP WHERE INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME  ";
                strSQL = strSQL + " AND INV_STOCKITEM.STOCKGROUP_NAME  in ( select STOCKGROUP_NAME from USER_PRIVILEGES_STOCKGROUP where USER_LOGIN_NAME ='" + strUserName + "') ";
                strSQL = strSQL + "order by INV_STOCKITEM.STOCKITEM_NAME ";
            }
            else
            {
                strSQL = "SELECT INV_STOCKITEM.STOCKITEM_NAME FROM INV_STOCKITEM,INV_STOCKGROUP WHERE INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME  ";
                if (vstrGroupName =="F")
                {
                    strSQL = strSQL + " AND  INV_STOCKITEM.STOCKITEM_PRIMARY_GROUP ='Finished Goods' ";
                    strSQL = strSQL + " AND  INV_STOCKGROUP.FG_STATUS =0 ";
                }
                else if (vstrGroupName == "D")
                {
                    strSQL = strSQL + " AND  INV_STOCKITEM.STOCKITEM_PRIMARY_GROUP ='Finished Goods' ";
                    strSQL = strSQL + " AND  INV_STOCKGROUP.FG_STATUS =1 ";
                }
                else
                {
                    if (vstrGroupName == "N")
                    {
                        strSQL = strSQL + " AND  INV_STOCKITEM.STOCKITEM_PRIMARY_GROUP <> 'Finished Goods' ";
                    }
                }
                strSQL = strSQL + " ORDER BY INV_STOCKITEM.STOCKITEM_NAME ";

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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }
        public List<StockItem> gFillStockItemAll(string strDeComID, string vstrGodown)
        {
            string strSQL;

            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_BASEUNITS,isnull(sum(STOCKITEM_CLOSING_BALANCE),0) as STOCKITEM_CLOSING_BALANCE FROM STOCKITEM_CLOSING_VIEW ";
            if (vstrGodown != "")
            {
                strSQL = strSQL + "WHERE GODOWNS_NAME='" + vstrGodown + "' ";
            }
            strSQL = strSQL + "GROUP by STOCKITEM_NAME,STOCKITEM_BASEUNITS ORDER BY STOCKITEM_NAME ASC";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    //if (drGetGroup["STOCKITEM_ALIAS"].ToString() != "")
                    //{
                    //    ogrp.strItemcode = drGetGroup["STOCKITEM_ALIAS"].ToString();
                    //}
                    ogrp.strUnit = drGetGroup["STOCKITEM_BASEUNITS"].ToString();
                    ogrp.dblClsBalance = Convert.ToDouble(drGetGroup["STOCKITEM_CLOSING_BALANCE"].ToString());
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }
        public double gFillStockItemPhysical(string strDeComID, string vstrGodown, string strItemName)
        {
            string strSQL;
            double dblcls = 0;
            SqlDataReader drGetGroup;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT STOCKITEM_NAME,STOCKITEM_CLOSING_BALANCE FROM STOCKITEM_CLOSING_VIEW ";
            if (vstrGodown != "")
            {
                strSQL = strSQL + "WHERE GODOWNS_NAME='" + vstrGodown + "' ";
                strSQL = strSQL + "AND  STOCKITEM_NAME='" + strItemName + "' ";
            }
            strSQL = strSQL + "ORDER BY STOCKITEM_NAME ASC";
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                if (drGetGroup.Read())
                {
                    dblcls = Convert.ToDouble(drGetGroup["STOCKITEM_CLOSING_BALANCE"].ToString());
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return dblcls;
            }
        }

        public List<StockItem> gFillStockItemCheck(string strDeComID, string vstrGodown = "", long vlngLedgerGroup = 0, long vlngStockType = 0, long vlngManufacGroup = 0, string vstrPrefix = "")
        {
            string strSQL = "";
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();

            if (Utility.gblnStockItemAlias == true)
            {

                strSQL = "SELECT DISTINCT STOCKITEM_NAME, GODOWNS_NAME, STOCKITEM_CLOSING_BALANCE, STOCKITEM_BASEUNITS, STOCKITEM_ALIAS, STOCKGROUP_PRIMARY, STOCKGROUP_SEQUENCES FROM INV_STOCK_CLOSING_GROUPWISE_QRY ";
                if (vstrGodown != "")
                {
                    strSQL = strSQL + "WHERE GODOWNS_NAME = '" + vstrGodown + "' ";
                    if (vlngStockType == (long)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE)
                    {
                        if (vlngLedgerGroup == (long)Utility.GR_GROUP_TYPE.grFINISHED_PURCHASE)
                        {
                            strSQL = strSQL + "AND STOCKGROUP_SEQUENCES = 800 ";
                        }
                        else
                        {
                            strSQL = strSQL + "AND  (STOCKGROUP_SEQUENCES <> 0) AND STOCKGROUP_SEQUENCES in (990, 980, 900) ";
                        }
                    }
                    else
                    {
                        strSQL = strSQL + "AND STOCKGROUP_SEQUENCES <> 0 ";
                    }
                    //}
                    strSQL = strSQL + "AND STOCKITEM_STATUS = 0 ";
                    strSQL = strSQL + "AND STOCKITEM_NAME LIKE '" + vstrPrefix + "%' ";

                    strSQL = strSQL + "ORDER BY STOCKITEM_NAME ASC ";
                }
            }
            else
            {
                strSQL = "SELECT DISTINCT STOCKITEM_NAME, GODOWNS_NAME, STOCKITEM_CLOSING_BALANCE, STOCKITEM_BASEUNITS, STOCKITEM_ALIAS, STOCKGROUP_PRIMARY, STOCKGROUP_SEQUENCES FROM INV_STOCK_CLOSING_GROUPWISE_QRY ";
                strSQL = strSQL + "WHERE GODOWNS_NAME = '" + vstrGodown + "' ";
                if (vlngStockType == (long)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE)
                {
                    if (Utility.glngBusinessType == 4)
                    {
                        if (vlngLedgerGroup == (long)Utility.GR_GROUP_TYPE.grFINISHED_PURCHASE)
                        {
                            strSQL = strSQL + " AND STOCKGROUP_PRIMARY_TYPE = 3 and STOCKGROUP_SECONDARY_TYPE=0";
                        }
                        else if (vlngManufacGroup == 5)
                        {
                            strSQL = strSQL + " AND STOCKGROUP_PRIMARY_TYPE = 1 and STOCKGROUP_SECONDARY_TYPE=1";
                        }
                        else if (vlngManufacGroup == 6)
                        {
                            strSQL = strSQL + " AND STOCKGROUP_PRIMARY_TYPE = 1 and STOCKGROUP_SECONDARY_TYPE=2";
                        }

                        else
                        {
                            strSQL = strSQL + " AND STOCKGROUP_PRIMARY_TYPE = 2 and STOCKGROUP_SECONDARY_TYPE=0";
                        }
                        strSQL = strSQL + " AND  (STOCKGROUP_SEQUENCES <> 0)";
                        strSQL = strSQL + " AND STOCKITEM_NAME LIKE '" + vstrPrefix + "%' ";
                    }
                    else
                    {
                        if (vlngLedgerGroup == (long)Utility.GR_GROUP_TYPE.grFINISHED_PURCHASE)
                        {
                            strSQL = strSQL + " AND STOCKGROUP_SEQUENCES = 800 ";
                        }
                        else
                        {
                            strSQL = strSQL + " AND  (STOCKGROUP_SEQUENCES <> 0) AND STOCKGROUP_SEQUENCES in (990, 980, 900) ";
                        }
                        strSQL = strSQL + "AND STOCKITEM_NAME LIKE '" + vstrPrefix + "%' ";
                    }


                }
                else
                {
                    strSQL = strSQL + "AND STOCKGROUP_SEQUENCES <> 0 ";
                    strSQL = strSQL + "AND STOCKITEM_NAME LIKE '" + vstrPrefix + "%' ";
                }

                strSQL = strSQL + "AND STOCKITEM_STATUS = 0 ";
                strSQL = strSQL + "ORDER BY STOCKITEM_NAME";
            }

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    if (drGetGroup["STOCKITEM_ALIAS"].ToString() != "")
                    {
                        ogrp.strItemcode = drGetGroup["STOCKITEM_ALIAS"].ToString();
                    }
                    ogrp.strUnit = drGetGroup["STOCKITEM_BASEUNITS"].ToString();
                    ogrp.dblClsBalance = Convert.ToDouble(drGetGroup["STOCKITEM_CLOSING_BALANCE"].ToString());
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }


        #endregion
        #region "Invoice"

        public List<Invoice> mFillBatch(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT INV_LOG_NO ";
            strSQL = strSQL + "FROM INV_BATCH ";
            strSQL = strSQL + "WHERE INV_LOG_STATUS = 'Active' ";
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
                    Invoice ogrp = new Invoice();
                    ogrp.strBatch = drGetGroup["INV_LOG_NO"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public List<Invoice> mfillPartyName(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_NAME,LEDGER_GROUP,LEDGER_BILL_WISE,LEDGER_VECTOR FROM ACC_LEDGER ";
            strSQL = strSQL + " WHERE LEDGER_GROUP <= 203 ";
            strSQL = strSQL + " AND LEDGER_STATUS=0 ";
            strSQL = strSQL + " ORDER BY LEDGER_NAME ASC";
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
                    Invoice ogrp = new Invoice();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Invoice> mFillLedgerStatus(string strDeComID, long vlngGroup, int intStatus,string strBranchID)
        {

            SqlDataReader dr;
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            List<Invoice> ooAccLed = new List<Invoice>();

            strSQL = "SELECT LEDGER_NAME,LEDGER_NAME_MERZE,TERITORRY_CODE,TERRITORRY_NAME FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_GROUP = " + vlngGroup + " ";
            strSQL = strSQL + "AND LEDGER_STATUS = " + intStatus + " ";
            if (strBranchID != "")
            {
                strSQL = strSQL + " AND BRANCH_ID='" + strBranchID + "' ";
            }
            strSQL = strSQL + "ORDER by TERITORRY_CODE ";
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Invoice oaccLed = new Invoice();
                    oaccLed.strLedgerName = dr["LEDGER_NAME"].ToString();
                    if (dr["LEDGER_NAME_MERZE"].ToString() != "")
                    {
                        oaccLed.strMereString = dr["LEDGER_NAME_MERZE"].ToString();
                    }
                    else
                    {
                        oaccLed.strMereString = "";
                    }
                    if (dr["TERITORRY_CODE"].ToString() != "")
                    {
                        oaccLed.strTeritorryCode = dr["TERITORRY_CODE"].ToString();
                    }
                    else
                    {
                        oaccLed.strTeritorryCode = "";
                    }
                    if (dr["TERRITORRY_NAME"].ToString() != "")
                    {
                        oaccLed.strTeritorryName = dr["TERRITORRY_NAME"].ToString();
                    }
                    else
                    {
                        oaccLed.strTeritorryName = "";
                    }
                    ooAccLed.Add(oaccLed);
                }
                dr.Close();
                return ooAccLed;
            }

        }
        public List<Invoice> mfillPartyNameNew(string strDeComID,string strBranchID,bool blngAccessControl,string strUserID,int intStatus,string strMode)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            if (blngAccessControl == true)
            {
                strSQL = "select l.TERITORRY_CODE,l.TERRITORRY_NAME,l.LEDGER_NAME,l.LEDGER_NAME_MERZE ";
                strSQL = strSQL + "from ACC_LEDGER  L,ACC_LEDGERGROUP g ,ACC_TERITORRY t where g.GR_NAME =l.LEDGER_PARENT_GROUP  AND t.TERITORRY_CODE=l.TERITORRY_CODE ";
                if (intStatus == 0)
                {
                    strSQL = strSQL + "and l.LEDGER_STATUS=" + intStatus + " ";
                }
                else
                {
                    strSQL = strSQL + "and l.LEDGER_STATUS in (1,2) ";
                }
                if (strMode=="X")
                {
                    strSQL = strSQL + "and Upper(LEDGER_NAME)  not like 'X%' ";
                }
                strSQL = strSQL + " and  l.LEDGER_GROUP <= 203 ";
                strSQL = strSQL + "and g.GR_PARENT in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + strUserID + "')";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "and l.BRANCH_ID = '" + strBranchID + "' ";
                }
            }
            else
            {
                strSQL = "SELECT l.TERITORRY_CODE,l.TERRITORRY_NAME,l.LEDGER_NAME,l.LEDGER_NAME_MERZE from ACC_TERITORRY t,ACC_LEDGER l where t.TERITORRY_CODE=l.TERITORRY_CODE ";
               
                if (intStatus == 0)
                {
                    strSQL = strSQL + "and l.LEDGER_STATUS=" + intStatus + " ";
                }
                else
                {
                    strSQL = strSQL + "and l.LEDGER_STATUS in (1,2) ";
                }
                if (strMode == "X")
                {
                    strSQL = strSQL + "and Upper(LEDGER_NAME)  not like 'X%' ";
                }
                else
                {
                    strSQL = strSQL + "and Upper(LEDGER_NAME)  not like 'X%' ";
                    strSQL = strSQL + "and len(l.TERITORRY_CODE ) >=3 ";
                }
                strSQL = strSQL + "and l.LEDGER_GROUP <= 203 ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "and l.BRANCH_ID = '" + strBranchID + "' ";
                }
            }
            strSQL = strSQL + "ORDER BY l.TERITORRY_CODE ";

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
                    Invoice ogrp = new Invoice();
                    if (drGetGroup["TERITORRY_CODE"].ToString() != "")
                    {
                        ogrp.strTeritorryCode = drGetGroup["TERITORRY_CODE"].ToString();
                    }
                    else
                    {
                        ogrp.strTeritorryCode = "";
                    }
                    if (drGetGroup["TERRITORRY_NAME"].ToString() != "")
                    {
                        ogrp.strTeritorryName = drGetGroup["TERRITORRY_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strTeritorryName = "";
                    }

                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMereString = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Invoice> mfillPartyNameNewSI(string strDeComID, string strBranchID, bool blngAccessControl, string strUserID, int intStatus, string strMode)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            if (blngAccessControl == true)
            {
                strSQL = "select l.TERITORRY_CODE,l.TERRITORRY_NAME,l.LEDGER_NAME,l.LEDGER_NAME_MERZE ";
                strSQL = strSQL + "from ACC_LEDGER  L,ACC_LEDGERGROUP g ,ACC_TERITORRY t where g.GR_NAME =l.LEDGER_PARENT_GROUP  AND t.TERITORRY_CODE=l.TERITORRY_CODE ";
                strSQL = strSQL + "and l.HALT_MPO=0 ";
                if (intStatus == 0)
                {
                    strSQL = strSQL + "and l.LEDGER_STATUS=" + intStatus + " ";
                }
                else
                {
                    strSQL = strSQL + "and l.LEDGER_STATUS in (1,2) ";
                }
                if (strMode == "X")
                {
                    strSQL = strSQL + "and Upper(LEDGER_NAME)  not like 'X%' ";
                }
                strSQL = strSQL + " and  l.LEDGER_GROUP <= 203 ";
                strSQL = strSQL + "and g.GR_PARENT in (SELECT  LEDGER_GROUP_NAME FROM  USER_PRIVILEGES_COLOR WHERE USER_LOGIN_NAME='" + strUserID + "')";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "and l.BRANCH_ID = '" + strBranchID + "' ";
                }
            }
            else
            {
                strSQL = "SELECT l.TERITORRY_CODE,l.TERRITORRY_NAME,l.LEDGER_NAME,l.LEDGER_NAME_MERZE from ACC_TERITORRY t,ACC_LEDGER l where t.TERITORRY_CODE=l.TERITORRY_CODE ";
                strSQL = strSQL + "and l.HALT_MPO=0 ";
                if (intStatus == 0)
                {
                    strSQL = strSQL + "and l.LEDGER_STATUS=" + intStatus + " ";
                }
                else
                {
                    strSQL = strSQL + "and l.LEDGER_STATUS in (1,2) ";
                }
                if (strMode == "X")
                {
                    strSQL = strSQL + "and Upper(LEDGER_NAME)  not like 'X%' ";
                }
                else
                {
                    strSQL = strSQL + "and Upper(LEDGER_NAME)  not like 'X%' ";
                    strSQL = strSQL + "and len(l.TERITORRY_CODE ) >=3 ";
                }
                strSQL = strSQL + "and l.LEDGER_GROUP <= 203 ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "and l.BRANCH_ID = '" + strBranchID + "' ";
                }
            }
            strSQL = strSQL + "ORDER BY l.TERITORRY_CODE ";

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
                    Invoice ogrp = new Invoice();
                    if (drGetGroup["TERITORRY_CODE"].ToString() != "")
                    {
                        ogrp.strTeritorryCode = drGetGroup["TERITORRY_CODE"].ToString();
                    }
                    else
                    {
                        ogrp.strTeritorryCode = "";
                    }
                    if (drGetGroup["TERRITORRY_NAME"].ToString() != "")
                    {
                        ogrp.strTeritorryName = drGetGroup["TERRITORRY_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strTeritorryName = "";
                    }

                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMereString = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> gLoadInvoiceLocation(string strDeComID, string vstrBranchID, bool gblngAccesscontrol, string strUserName, int intStatus)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            //if (gblngAccesscontrol == true)
            //{
            strSQL = "SELECT GODOWNS_NAME  FROM INV_GODOWNS WHERE GODOWNS_NAME IN ('Sale Center. Dhaka Depot','Main Location') ";
                strSQL = strSQL + " and BRANCH_ID= '" + vstrBranchID + "' ";
            //    if (vstrBranchID != "")
            //    {
            //       
            //        if (intStatus < 2)
            //        {
            //            strSQL = strSQL + " AND SECTION_STATUS= " + intStatus + " ";
            //        }
            //        strSQL = strSQL + "AND GODOWNS_NAME IN (SELECT GODOWNS_NAME FROM USER_PRIVILEGES_LOCATION WHERE USER_LOGIN_NAME='" + strUserName + "')";
            //    }
            //    else
            //    {
            //        strSQL = strSQL + "WHERE GODOWNS_NAME IN (SELECT GODOWNS_NAME FROM USER_PRIVILEGES_LOCATION WHERE USER_LOGIN_NAME='" + strUserName + "')";
            //        if (intStatus < 2)
            //        {
            //            strSQL = strSQL + " AND SECTION_STATUS= " + intStatus + " ";
            //        }
            //    }
            //}
            //else
            //{
            //    strSQL = "SELECT GODOWNS_NAME FROM INV_GODOWNS ";

            //    if (vstrBranchID != "")
            //    {
            //        strSQL = strSQL + "AND BRANCH_ID = '" + vstrBranchID + "' ";
            //        if (intStatus < 2)
            //        {
            //            strSQL = strSQL + " AND SECTION_STATUS= " + intStatus + " ";
            //        }
            //    }
            //}
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
                    StockItem ogrp = new StockItem();
                    ogrp.strLocation = drGetGroup["GODOWNS_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> gLoadLocation(string strDeComID, string vstrBranchID,bool gblngAccesscontrol,string strUserName,int intStatus)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            //if (gblngAccesscontrol == true)
            //{
            strSQL = "SELECT GODOWNS_NAME FROM INV_GODOWNS ";
            if (vstrBranchID != "")
            {
                strSQL = strSQL + " WHERE BRANCH_ID= '" + vstrBranchID + "' ";
                if (intStatus < 2)
                {
                    strSQL = strSQL + " AND SECTION_STATUS= " + intStatus + " ";
                }
            }
            else
            {
                strSQL = strSQL + "WHERE GODOWNS_NAME IN (SELECT GODOWNS_NAME FROM USER_PRIVILEGES_LOCATION WHERE USER_LOGIN_NAME='" + strUserName + "')";
                if (intStatus < 2)
                {
                    strSQL = strSQL + " AND SECTION_STATUS= " + intStatus + " ";
                }
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
                    StockItem ogrp = new StockItem();
                    ogrp.strLocation = drGetGroup["GODOWNS_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Invoice> GetMPONameFromTC(string strDeComID, string strCode)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER WHERE TERITORRY_CODE ='" + strCode.Trim().Replace("'", "''") + "' ";
            strSQL = strSQL + " AND LEDGER_STATUS =0";
            strSQL = strSQL + " AND LEDGER_GROUP= " + (long)Utility.GR_GROUP_TYPE.grCUSTOMER + " ";

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
                    Invoice ogrp = new Invoice();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Invoice> mfillLedgerInvoice(string strDeComID, bool vblngDrcr, long mlngLedgerAs,string strLoose)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER ";
            strSQL = strSQL + " WHERE LEDGER_STATUS=0 ";
            if (strLoose=="Loose")
            {
                strSQL = strSQL + " and LEDGER_NAME like '%Loose%' ";
            }
            if (vblngDrcr == true)
            {
                strSQL = strSQL + " AND (LEDGER_GROUP= " + Utility.GR_GROUP_TYPE.grCUSTOMER + " ";
                strSQL = strSQL + " OR LEDGER_GROUP= " + Utility.GR_GROUP_TYPE.grSUPPLIER + " ";
                strSQL = strSQL + " OR LEDGER_GROUP <=101) ";
            }
            else
            {
                if (mlngLedgerAs > 0)
                {
                    
                    //'        strSQL = strSQL + " OR LEDGER_GROUP= " + grSUPPLIER + " ";
                    if (mlngLedgerAs == (int)Utility.GR_GROUP_TYPE.grSUPPLIER)
                    {
                        strSQL = strSQL + " AND (LEDGER_GROUP= " + mlngLedgerAs + ")";
                    }
                    else
                    {
                        strSQL = strSQL + " AND (LEDGER_GROUP= " + mlngLedgerAs + " ";
                        strSQL = strSQL + " OR LEDGER_GROUP <=101) ";
                    }
                }
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
                    Invoice ogrp = new Invoice();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Invoice> gFillSalesLedgerbatch(string strDeComID, long vlngSLedgerType)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER ";
            if (vlngSLedgerType != 0)
            {
                strSQL = strSQL + "WHERE LEDGER_GROUP = " + vlngSLedgerType + " ";
                strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
            }
            strSQL = strSQL + "ORDER BY LEDGER_NAME";
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
                    Invoice ogrp = new Invoice();
                    ogrp.strSalesLedger = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Invoice> gFillSalesLedger(string strDeComID, long vlngSLedgerType)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER ";
            if (vlngSLedgerType != 0)
            {
                strSQL = strSQL + "WHERE LEDGER_GROUP = " + vlngSLedgerType + " ";
                strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
            }
            strSQL = strSQL + "ORDER BY LEDGER_NAME";
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
                    Invoice ogrp = new Invoice();
                    ogrp.strSalesLedger = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Invoice> gFillPurchaseLedger(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE (LEDGER_GROUP = " + (long)Utility.GR_GROUP_TYPE.grPURCHASE + " ";
            strSQL = strSQL + " OR LEDGER_GROUP = " + (long)Utility.GR_GROUP_TYPE.grFINISHED_PURCHASE + ") ";
            strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
            strSQL = strSQL + "ORDER BY LEDGER_NAME";

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
                    Invoice ogrp = new Invoice();
                    ogrp.strPurchaseLedger = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }



        #endregion
        #region "Sales Representative"



        public List<Invoice> mFillSalesRepFromMPoNew1(string strDeComID, long vlngSLedgerType, string strLedgerName)
        {
            string strSQL, strCode = "", strHomeoHall = "";
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_CODE,LEDGER_NAME,HOMOEO_HALL,LEDGER_NAME_MERZE,HOMOEO_HALL,LEDGER_NAME FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_GROUP = " + vlngSLedgerType + " ";
            strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
            if (strLedgerName != "")
            {
                strSQL = strSQL + "AND LEDGER_REP_NAME = '" + strLedgerName + "' ";
            }
            strSQL = strSQL + "ORDER BY LEDGER_CODE DESC";

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
                    Invoice ogrp = new Invoice();
                    if (drGetGroup["LEDGER_CODE"].ToString() != "")
                    {
                        strCode = drGetGroup["LEDGER_CODE"].ToString();
                    }
                    else
                    {
                        strCode = "";
                    }
                    ogrp.strTeritorryCode = strCode;
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    if (drGetGroup["LEDGER_CODE"].ToString() != "")
                    {
                        strHomeoHall = drGetGroup["HOMOEO_HALL"].ToString();
                    }
                    else
                    {
                        strHomeoHall = "";
                    }

                    ogrp.strTeritorryName = strHomeoHall;

                    ogrp.strMereString = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Invoice> mFillSalesRepFromMPoNew(string strDeComID, long vlngSLedgerType, string strLedgerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_CODE,HOMOEO_HALL,LEDGER_NAME FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_GROUP = " + vlngSLedgerType + " ";
            strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
            strSQL = strSQL + "AND LEDGER_REP_NAME = '" + strLedgerName + "' ";
            strSQL = strSQL + "ORDER BY LEDGER_NAME";

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
                    Invoice ogrp = new Invoice();
                    ogrp.strSalesRepresentative = drGetGroup["LEDGER_CODE"].ToString() + "~" + drGetGroup["LEDGER_NAME"].ToString() + "~" + drGetGroup["HOMOEO_HALL"].ToString(); ;
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Invoice> mFillSalesRepFromMPo(string strDeComID, long vlngSLedgerType, string strLedgerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER ";
            strSQL = strSQL + "WHERE LEDGER_GROUP = " + vlngSLedgerType + " ";
            strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
            strSQL = strSQL + "AND LEDGER_REP_NAME = '" + strLedgerName + "' ";
            strSQL = strSQL + "ORDER BY LEDGER_NAME";

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
                    Invoice ogrp = new Invoice();
                    ogrp.strSalesRepresentative = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Invoice> mFillSalesRepLedger(string strDeComID, long vlngSLedgerType)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER ";
            if (vlngSLedgerType != 0)
            {
                strSQL = strSQL + "WHERE LEDGER_GROUP = " + vlngSLedgerType + " ";
                strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
            }
            strSQL = strSQL + "ORDER BY LEDGER_NAME";

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
                    Invoice ogrp = new Invoice();
                    ogrp.strSalesRepresentative = drGetGroup["LEDGER_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }


        public List<Invoice> mFillSalesRep(string strDeComID, long vlngSLedgerType)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT GR_NAME FROM ACC_LEDGERGROUP ";
            if (vlngSLedgerType != 0)
            {
                strSQL = strSQL + "WHERE GR_GROUP  = " + vlngSLedgerType + " ";
            }
            strSQL = strSQL + "ORDER BY GR_NAME";

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
                    Invoice ogrp = new Invoice();
                    ogrp.strSalesRepresentative = drGetGroup["GR_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public string mSaveSalesRepresentive(string strDeComID, string vstrLedgerCode, string vstrLedgerName, string vstrTeritoryCode, string vstrTeritoryName, double dblTargetAmount,
                                            string vstrHomoeHall, int intStatus, string vstrUnder, string vstrMrName, double dblOpeningBalance, double dblcommPercent,
                                            string vstrDrcr, string vstrCommType, string vstrAddress1,
                                            string vstrAddress2, string vstrCommnets, string vstrCity, string vstrPostal, string vstrPhone)
        {

            string strSQL, strPrimary, strParent = "", strReportGroup = "", strMerzeLedger;
            long lngLedgerGroup = 0, lngGroupType = 0, lngLedgerLevel = 0, lngGrLevel = 0, lngCashFlowType = 0, lngMultiply = 1, lngCommissionType = 0;
            bool blnInsert = true;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();


                if (vstrLedgerCode != "")
                {
                    strMerzeLedger = vstrLedgerCode + '-' + vstrLedgerName + '-' + vstrHomoeHall;
                }
                else if (vstrHomoeHall == "")
                {
                    strMerzeLedger = vstrLedgerName;
                }
                else
                {
                    strMerzeLedger = vstrLedgerName + '-' + vstrHomoeHall;
                }

                vstrLedgerName = vstrLedgerName.Replace("'", "''");
                vstrAddress1 = vstrAddress1.Replace("'", "''");
                vstrAddress2 = vstrAddress2.Replace("'", "''");
                vstrCommnets = vstrCommnets.Replace("'", "''");
                vstrCity = vstrCity.Replace("'", "''");

                strPrimary = Utility.GetEndGroup(strDeComID, vstrUnder);
                strParent = vstrUnder.Replace("'", "''");
                if (vstrDrcr.ToUpper() == "DR")
                {
                    lngMultiply = -1;
                }
                else if (vstrDrcr.ToUpper() == "CR")
                {
                    lngMultiply = 1;
                }
                if (vstrCommType == "Flat Amount")
                {
                    lngCommissionType = 1;
                }
                else if (vstrCommType == "Sales Percent")
                {
                    lngCommissionType = 2;
                }
                else if (vstrCommType == "Profit Percent")
                {
                    lngCommissionType = 3;
                }



                if (vstrDrcr.ToUpper() == "DR")
                {
                    lngMultiply = -1;
                }
                else if (vstrDrcr.ToUpper() == "CR")
                {
                    lngMultiply = 1;
                }
                if (dblOpeningBalance == 0)
                {
                    dblOpeningBalance = 0;
                }
                else
                {
                    dblOpeningBalance = dblOpeningBalance * lngMultiply;
                }



                SqlDataReader drGetGroup;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "SELECT GR_PRIMARY,GR_GROUP,GR_LEVEL,GR_ONE_DOWN,GR_PRIMARY_TYPE,";
                strSQL = strSQL + "GR_CASH_FLOW_TYPE FROM ACC_LEDGERGROUP WHERE GR_NAME = '" + strParent + "' ";
                cmdInsert.CommandText = strSQL;
                drGetGroup = cmdInsert.ExecuteReader();
                if (drGetGroup.Read())
                {
                    strPrimary = drGetGroup["GR_PRIMARY"].ToString();
                    lngLedgerGroup = Convert.ToInt32(drGetGroup["GR_GROUP"].ToString());
                    lngGroupType = Convert.ToInt32(drGetGroup["GR_PRIMARY_TYPE"].ToString());
                    strReportGroup = drGetGroup["GR_ONE_DOWN"].ToString();
                    lngLedgerLevel = Convert.ToInt32(drGetGroup["GR_LEVEL"]) + 1;
                    lngCashFlowType = Convert.ToInt32(drGetGroup["GR_CASH_FLOW_TYPE"].ToString());
                }
                drGetGroup.Close();
                if (lngLedgerGroup == 0)
                {
                    lngLedgerGroup = (long)Utility.GR_GROUP_TYPE.grOTHER_LEDGER;
                }


                strSQL = "INSERT INTO ACC_LEDGER(LEDGER_CODE,LEDGER_NAME,LEDGER_NAME_MERZE,TERITORRY_CODE,TERRITORRY_NAME,LEDGER_TARGET,HOMOEO_HALL,LEDGER_STATUS,LEDGER_PARENT_GROUP,LEDGER_PRIMARY_GROUP,";
                strSQL = strSQL + "LEDGER_ONE_DOWN, ";
                strSQL = strSQL + "LEDGER_OPENING_BALANCE,";
                strSQL = strSQL + "LEDGER_ADDRESS1,LEDGER_ADDRESS2,LEDGER_CITY,LEDGER_POSTAL, ";
                strSQL = strSQL + "LEDGER_PHONE,LEDGER_COMMENTS,";
                strSQL = strSQL + "LEDGER_GROUP,LEDGER_LEVEL,LEDGER_PRIMARY_TYPE,LEDGER_CURRENCY_SYMBOL,";
                strSQL = strSQL + "LEDGER_REP_NAME,LEDGER_REP_COMMISSION_TYPE,LEDGER_REP_COMMISSION) ";
                strSQL = strSQL + "VALUES(";
                strSQL = strSQL + "'" + vstrLedgerCode + "',";
                strSQL = strSQL + "'" + vstrLedgerName + "',";
                strSQL = strSQL + "'" + strMerzeLedger.Replace("'", "''") + "',";
                strSQL = strSQL + "'" + vstrTeritoryCode + "',";
                strSQL = strSQL + "'" + vstrTeritoryName + "',";
                strSQL = strSQL + "" + dblTargetAmount + ",";
                strSQL = strSQL + "'" + vstrHomoeHall + "',";
                strSQL = strSQL + " " + intStatus + ",";
                strSQL = strSQL + "'" + strParent + "', ";
                strSQL = strSQL + "'" + strPrimary + "', ";
                strSQL = strSQL + "'" + "" + "',";
                strSQL = strSQL + " " + dblOpeningBalance + ", ";
                strSQL = strSQL + "'" + vstrAddress1 + "','" + vstrAddress2 + "',";
                strSQL = strSQL + "'" + vstrCity + "','" + vstrPostal + "',";
                strSQL = strSQL + "'" + vstrPhone + "','" + vstrCommnets + "',";
                strSQL = strSQL + " " + lngLedgerGroup + ",";//         'LEDGER_GROUP
                strSQL = strSQL + " " + lngLedgerLevel + ",";//          'LEDGER_LEVEL
                strSQL = strSQL + " " + lngGroupType + ",";//         'LEDGER_PRIMARY_TYPE
                strSQL = strSQL + "'" + Utility.gstrBaseCurrency + "', ";
                strSQL = strSQL + "'" + vstrMrName + "', ";
                strSQL = strSQL + " " + lngCommissionType + ", ";
                strSQL = strSQL + " " + dblcommPercent + " ";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES(";
                strSQL = strSQL + "'" + strParent + "','" + vstrLedgerName + "'";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                do
                {
                    if (lngGroupType == 1)
                    {
                        blnInsert = true;
                    }
                    strSQL = "SELECT GR_PARENT,GR_LEVEL FROM ACC_LEDGERGROUP WHERE GR_NAME = '" + strParent + "' ";
                    SqlDataReader dr1;
                    cmdInsert.CommandText = strSQL;
                    dr1 = cmdInsert.ExecuteReader();
                    if (dr1.Read())
                    {
                        strParent = dr1["GR_PARENT"].ToString().Replace("'", "''");
                        lngGrLevel = long.Parse(dr1["GR_LEVEL"].ToString());
                    }

                    dr1.Close();
                    if (lngGrLevel == 1)
                    {
                        blnInsert = true;
                    }
                    if (blnInsert == false)
                    {
                        strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) ";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + strParent + "','" + vstrLedgerName + "'";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                while (blnInsert == false);

                strSQL = "INSERT INTO INV_SALESREPSENTIVE(LEDGER_NAME,MRR_NO) ";
                strSQL = strSQL + "VALUES(";
                strSQL = strSQL + "'" + vstrLedgerName + "','" + vstrMrName + "'";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Transaction.Commit();
                gcnMain.Close();
                return "1";

            }

        }


        public string mUpdateSalesRepresentive(string strDeComID, string mstrOldLedger, long mlngLedgerSerial, string vstrLedgerCode, string vstrLedgerName, string vstrTeritoryCode,
                                            string vstrTeritoryName, double dblTargetAmount, string vstrHomoeHall, int intStatus, string vstrMrName, string vstrUnder,
                                            double dblOpeningBalance, double dblcommPercent,
                                            string vstrDrcr, string vstrCommType, string vstrAddress1,
                                            string vstrAddress2, string vstrCommnets, string vstrCity, string vstrPostal, string vstrPhone)
        {

            string strSQL, strPrimary, strParent = "", strReportGroup = "", strMerzeLedger = "";
            long lngLedgerGroup = 0, lngGroupType = 0, lngLedgerLevel = 0, lngGrLevel = 0, lngCashFlowType = 0, lngMultiply = 1, lngCommissionType = 0;
            double dblOldOpening = 0, dblClosingBalance = 0;
            bool blnInsert = true;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();

                vstrLedgerName = vstrLedgerName.Replace("'", "''");
                //if (vstrLedgerCode != "")
                //{
                //    strMerzeLedger = vstrLedgerCode + '-' + vstrLedgerName + '-' + vstrHomoeHall;
                //}
                //else
                //{
                //    strMerzeLedger = vstrLedgerName + '-' + vstrHomoeHall;
                //}

                if (vstrLedgerCode != "")
                {
                    strMerzeLedger = vstrLedgerCode + '-' + vstrLedgerName + '-' + vstrHomoeHall;
                }
                else if (vstrHomoeHall == "")
                {
                    strMerzeLedger = vstrLedgerName;
                }
                else
                {
                    strMerzeLedger = vstrLedgerName + '-' + vstrHomoeHall;
                }

                vstrAddress1 = vstrAddress1.Replace("'", "''");
                vstrAddress2 = vstrAddress2.Replace("'", "''");
                vstrCommnets = vstrCommnets.Replace("'", "''");
                vstrCity = vstrCity.Replace("'", "''");

                strPrimary = Utility.GetEndGroup(strDeComID, vstrUnder);
                strParent = vstrUnder.Replace("'", "''");
                if (vstrDrcr.ToUpper() == "DR")
                {
                    lngMultiply = -1;
                }
                else if (vstrDrcr.ToUpper() == "CR")
                {
                    lngMultiply = 1;
                }
                if (vstrCommType == "Flat Amount")
                {
                    lngCommissionType = 1;
                }
                else if (vstrCommType == "Sales Percent")
                {
                    lngCommissionType = 2;
                }
                else if (vstrCommType == "Profit Percent")
                {
                    lngCommissionType = 3;
                }



                if (vstrDrcr.ToUpper() == "DR")
                {
                    lngMultiply = -1;
                }
                else if (vstrDrcr.ToUpper() == "CR")
                {
                    lngMultiply = 1;
                }
                if (dblOpeningBalance == 0)
                {
                    dblOpeningBalance = 0;
                }
                else
                {
                    dblOpeningBalance = dblOpeningBalance * lngMultiply;
                }



                SqlDataReader drGetGroup;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "SELECT GR_PRIMARY,GR_GROUP,GR_LEVEL,GR_ONE_DOWN,GR_PRIMARY_TYPE,";
                strSQL = strSQL + "GR_CASH_FLOW_TYPE FROM ACC_LEDGERGROUP WHERE GR_NAME = '" + strParent + "' ";
                cmdInsert.CommandText = strSQL;
                drGetGroup = cmdInsert.ExecuteReader();
                if (drGetGroup.Read())
                {
                    strPrimary = drGetGroup["GR_PRIMARY"].ToString();
                    lngLedgerGroup = Convert.ToInt32(drGetGroup["GR_GROUP"].ToString());
                    lngGroupType = Convert.ToInt32(drGetGroup["GR_PRIMARY_TYPE"].ToString());
                    strReportGroup = drGetGroup["GR_ONE_DOWN"].ToString();
                    lngLedgerLevel = Convert.ToInt32(drGetGroup["GR_LEVEL"]) + 1;
                    lngCashFlowType = Convert.ToInt32(drGetGroup["GR_CASH_FLOW_TYPE"].ToString());
                }
                drGetGroup.Close();
                if (lngLedgerGroup == 0)
                {
                    lngLedgerGroup = (long)Utility.GR_GROUP_TYPE.grSALES_REP;
                }

                strSQL = "SELECT LEDGER_OPENING_BALANCE,LEDGER_CLOSING_BALANCE FROM ACC_LEDGER ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + mstrOldLedger + "'";
                cmdInsert.CommandText = strSQL;
                drGetGroup = cmdInsert.ExecuteReader();
                if (drGetGroup.Read())
                {

                    dblOldOpening = Convert.ToDouble(drGetGroup["LEDGER_OPENING_BALANCE"].ToString());
                    dblClosingBalance = Convert.ToDouble(drGetGroup["LEDGER_CLOSING_BALANCE"].ToString());
                }
                drGetGroup.Close();


                //'Deduct Old Value
                strSQL = "UPDATE ACC_LEDGER_GROUP_QRY ";
                strSQL = strSQL + "SET ";
                if (dblOldOpening <= 0)
                {
                    strSQL = strSQL + "GR_OPENING_DEBIT = GR_OPENING_DEBIT - " + dblOldOpening + ", ";
                    strSQL = strSQL + "GR_CLOSING_DEBIT = GR_CLOSING_DEBIT - " + dblOldOpening + " ";
                }
                if (dblOldOpening > 0)
                {
                    strSQL = strSQL + "GR_OPENING_CREDIT = GR_OPENING_CREDIT - " + dblOldOpening + ", ";
                    strSQL = strSQL + "GR_CLOSING_CREDIT = GR_CLOSING_CREDIT - " + dblOldOpening + " ";
                }
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + mstrOldLedger + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM ACC_LEDGER_TO_GROUP WHERE LEDGER_NAME = '" + mstrOldLedger + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM ACC_STOCK_IN_HAND WHERE LEDGER_NAME = '" + mstrOldLedger + "'";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "UPDATE ACC_LEDGER ";
                strSQL = strSQL + "SET LEDGER_NAME = '" + vstrLedgerName + "',";
                strSQL = strSQL + "LEDGER_PARENT_GROUP = '" + strParent + "',";
                strSQL = strSQL + "LEDGER_NAME_MERZE = '" + strMerzeLedger.Replace("'", "''") + "',";
                strSQL = strSQL + "LEDGER_PRIMARY_GROUP = '" + strPrimary + "',";
                strSQL = strSQL + "LEDGER_ONE_DOWN = '" + strReportGroup + "',";
                strSQL = strSQL + "LEDGER_OPENING_BALANCE = " + dblOpeningBalance + ", ";
                strSQL = strSQL + "LEDGER_ADDRESS1 = '" + vstrAddress1 + "', ";
                strSQL = strSQL + "LEDGER_ADDRESS2 = '" + vstrAddress2 + "', ";
                strSQL = strSQL + "LEDGER_CITY = '" + vstrCity + "', ";
                strSQL = strSQL + "LEDGER_POSTAL = '" + vstrPostal + "', ";
                strSQL = strSQL + "LEDGER_PHONE = '" + vstrPhone + "', ";
                strSQL = strSQL + "LEDGER_COMMENTS = '" + vstrCommnets + "', ";
                strSQL = strSQL + "LEDGER_GROUP = " + lngLedgerGroup + ",";
                strSQL = strSQL + "LEDGER_LEVEL = " + lngLedgerLevel + ",";
                //strSQL = strSQL + "LEDGER_VECTOR = " + lngVector + ",";
                strSQL = strSQL + "LEDGER_PRIMARY_TYPE = " + lngGroupType + ",";
                strSQL = strSQL + "LEDGER_REP_NAME= '" + vstrMrName + "',";
                strSQL = strSQL + "LEDGER_REP_COMMISSION_TYPE= " + lngCommissionType + ",";

                strSQL = strSQL + "TERITORRY_CODE= '" + vstrTeritoryCode + "', ";
                strSQL = strSQL + "TERRITORRY_NAME= '" + vstrTeritoryName + "', ";
                strSQL = strSQL + "LEDGER_CODE= '" + vstrLedgerCode + "', ";
                strSQL = strSQL + "LEDGER_TARGET= " + dblTargetAmount + ", ";
                strSQL = strSQL + "HOMOEO_HALL= '" + vstrHomoeHall + "', ";
                strSQL = strSQL + "LEDGER_STATUS= " + intStatus + ", ";

                strSQL = strSQL + "LEDGER_REP_COMMISSION= '" + dblcommPercent + "',";
                strSQL = strSQL + "LEDGER_CLOSING_BALANCE = " + Convert.ToDouble((dblClosingBalance + dblOpeningBalance) - dblOldOpening) + " ";
                //'strSQL = strSQL + "LEDGER_CURRENCY_SYMBOL = '" + uctxtCurrency.Text + "' "
                strSQL = strSQL + "WHERE LEDGER_SERIAL = " + mlngLedgerSerial + " ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE ACC_VOUCHER SET VOUCHER_REVERSE_LEDGER = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "WHERE VOUCHER_REVERSE_LEDGER = '" + mstrOldLedger + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES(";
                strSQL = strSQL + "'" + strParent + "','" + vstrLedgerName + "'";
                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                do
                {
                    if (lngGroupType == 1)
                    {
                        blnInsert = true;
                    }
                    strSQL = "SELECT GR_PARENT,GR_LEVEL FROM ACC_LEDGERGROUP WHERE GR_NAME = '" + strParent + "' ";
                    SqlDataReader dr1;
                    cmdInsert.CommandText = strSQL;
                    dr1 = cmdInsert.ExecuteReader();
                    if (dr1.Read())
                    {
                        strParent = dr1["GR_PARENT"].ToString().Replace("'", "''");
                        lngGrLevel = long.Parse(dr1["GR_LEVEL"].ToString());
                    }

                    dr1.Close();
                    if (lngGrLevel == 1)
                    {
                        blnInsert = true;
                    }
                    if (blnInsert == false)
                    {
                        strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) ";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + strParent + "','" + vstrLedgerName + "'";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                while (blnInsert == false);

                strSQL = "UPDATE INV_SALESREPSENTIVE SET LEDGER_NAME ='" + vstrLedgerName + "' ";
                strSQL = strSQL + ",MRR_NO ='" + vstrMrName + "'";
                strSQL = strSQL + " WHERE LEDGER_NAME='" + mstrOldLedger + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                cmdInsert.Transaction.Commit();
                gcnMain.Close();
                return "1";

            }

        }

        #endregion
        #region "Sales Price"

        public List<SalesPriceLevel> mGetPriceLevel(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesPriceLevel> oogrp = new List<SalesPriceLevel>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT PRICE_LEVEL_NAME FROM ACC_PRICE_LEVEL";

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
                    SalesPriceLevel ogrp = new SalesPriceLevel();
                    ogrp.strSalesPriceLevel = drGetGroup["PRICE_LEVEL_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public string mSaveSalesPrice(string strDeComID, string vstrName, int intmode, string mstrPreviousLevel)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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
                    vstrName = vstrName.Replace("'", "''");

                    if (intmode == 1)
                    {
                        strSQL = "INSERT INTO ACC_PRICE_LEVEL(PRICE_LEVEL_NAME) ";
                        strSQL = strSQL + "VALUES ";
                        strSQL = strSQL + "('" + vstrName + "'";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        cmdInsert.Transaction.Commit();
                        gcnMain.Close();
                        return "Inseretd...";
                    }
                    else if (intmode == 2)
                    {
                        strSQL = "UPDATE ACC_PRICE_LEVEL SET PRICE_LEVEL_NAME = '";
                        strSQL = strSQL + vstrName + "' ";
                        strSQL = strSQL + "WHERE PRICE_LEVEL_NAME = '" + mstrPreviousLevel + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        cmdInsert.Transaction.Commit();
                        gcnMain.Close();
                        return "Updated...";
                    }
                    else if (intmode == 3)
                    {
                        strSQL = "DELETE FROM ACC_PRICE_LEVEL ";
                        strSQL = strSQL + "WHERE PRICE_LEVEL_NAME = '" + mstrPreviousLevel + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        cmdInsert.Transaction.Commit();
                        gcnMain.Close();
                        return "Deleted..";
                    }
                    else
                    {
                        return "Error";
                    }



                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }




        #endregion
        #region "Price Config"
        public string mInsertPriceconfig(string strDeComID, string DgGrid, string strKeydate, string mstrPriceLevel, string strEffectivedate)
        {

            string strSQL, strItemName = "", strItemKey = "", strDate = "", strLevelName = "";
            double dblFromQty = 0, dblToQty = 0, dblPrice = 0, dblDiscount = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();

                    SqlDataReader rsGet;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "DELETE FROM INV_SALES_PRICE ";
                    strSQL = strSQL + "WHERE  PRICE_LEVEL_NAME = '" + mstrPriceLevel + "' ";
                    strSQL = strSQL + "AND  SALES_PRICE_EFFECTIVE_DATE = " + Utility.cvtSQLDateString(strEffectivedate) + " ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    string[] words = DgGrid.Split('~');
                    foreach (string ooObj in words)
                    {
                        string[] ooItem = ooObj.Split('|');
                        if (ooItem[0] != "")
                        {
                            strLevelName = ooItem[0].ToString();
                            strDate = ooItem[1].ToString();
                            strItemName = ooItem[2].ToString();
                            dblFromQty = Convert.ToDouble(ooItem[3].ToString());
                            dblToQty = Convert.ToDouble(ooItem[4].ToString());
                            dblPrice = Convert.ToDouble(ooItem[5].ToString());
                            dblDiscount = Convert.ToDouble(ooItem[6].ToString());


                            strItemKey = (strItemName + strKeydate + dblFromQty + dblToQty + strLevelName);
                            strSQL = "SELECT SALES_PRICE_KEY FROM INV_SALES_PRICE ";
                            strSQL = strSQL + "WHERE SALES_PRICE_KEY = '" + strItemKey + "'";
                            cmdInsert.CommandText = strSQL;
                            rsGet = cmdInsert.ExecuteReader();
                            if (rsGet.Read())
                            {
                                rsGet.Close();

                                strSQL = "UPDATE INV_SALES_PRICE ";
                                strSQL = strSQL + "SET SALES_PRICE_AMOUNT = " + dblPrice + ", ";
                                strSQL = strSQL + "FROM_QTY = " + dblFromQty + ",";
                                strSQL = strSQL + "TO_QTY = " + dblToQty + ", ";
                                strSQL = strSQL + "PRICE_UNIQUE_KEY='" + strLevelName + strItemName + strKeydate + "', ";
                                strSQL = strSQL + "ACTUAL_DISCOUNT = " + dblDiscount + ",";
                                strSQL = strSQL + "PERCENT_DISCOUNT = '" + dblDiscount + "' ";
                                //strSQL = strSQL + " MINIMUM_PRICE=" + Val(intMinimumPrice) + "  ";
                                strSQL = strSQL + "WHERE SALES_PRICE_KEY = '" + strItemKey + "' ";
                                strSQL = strSQL + "AND PRICE_LEVEL_NAME = '" + strLevelName + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                            else
                            {
                                rsGet.Close();
                                strSQL = "INSERT INTO INV_SALES_PRICE";
                                strSQL = strSQL + "(SALES_PRICE_KEY,STOCKITEM_NAME,FROM_QTY,TO_QTY,";
                                strSQL = strSQL + "SALES_PRICE_AMOUNT,SALES_PRICE_EFFECTIVE_DATE,";
                                strSQL = strSQL + "PRICE_LEVEL_NAME,PRICE_UNIQUE_KEY,";
                                strSQL = strSQL + "ACTUAL_DISCOUNT,PERCENT_DISCOUNT,MINIMUM_PRICE) ";
                                strSQL = strSQL + "VALUES";
                                strSQL = strSQL + "(";
                                strSQL = strSQL + "'" + strItemKey + " ',";
                                strSQL = strSQL + "'" + strItemName + "',";
                                strSQL = strSQL + "" + dblFromQty + ",";
                                strSQL = strSQL + "" + dblToQty + ",";
                                strSQL = strSQL + "" + dblPrice + ",";
                                strSQL = strSQL + "" + Utility.cvtSQLDateString(strDate) + ",";
                                strSQL = strSQL + "'" + strLevelName + "',";
                                strSQL = strSQL + "'" + strLevelName + strItemName + strKeydate + "',";
                                strSQL = strSQL + "" + dblDiscount + ",";
                                strSQL = strSQL + "'" + dblDiscount + "', ";
                                strSQL = strSQL + "0";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }


                    }
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "1";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }


        public List<SalesPriceLevel> mDisplayItemGroup(string strDeComID, string vstrItemGroup, string vstrDate)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesPriceLevel> oogrp = new List<SalesPriceLevel>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM INV_SALES_PRICE ";
            strSQL = strSQL + "WHERE PRICE_LEVEL_NAME = '" + vstrItemGroup + "' ";
            strSQL = strSQL + "AND SALES_PRICE_EFFECTIVE_DATE = " + Utility.cvtSQLDateString(vstrDate) + " ";
            strSQL = strSQL + "AND MODULE_STATUS = 0 ";
            strSQL = strSQL + "ORDER BY STOCKITEM_NAME ASC, SALES_PRICE_SERIAL ASC ";

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

                    SalesPriceLevel ogrp = new SalesPriceLevel();
                    ogrp.dblFromQty = Convert.ToDouble(drGetGroup["FROM_QTY"].ToString());
                    ogrp.dblToQty = Convert.ToDouble(drGetGroup["TO_QTY"].ToString());
                    ogrp.dblRate = Convert.ToDouble(drGetGroup["SALES_PRICE_AMOUNT"].ToString());
                    ogrp.dblDiscount = Convert.ToDouble(drGetGroup["PERCENT_DISCOUNT"].ToString());
                    StockItem ostr = new StockItem();
                    ostr.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ostr.strUnit = Utility.gGetBaseUOM(strDeComID, drGetGroup["STOCKITEM_NAME"].ToString());
                    ogrp.strPrice = ostr;
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<SalesPriceLevel> mBonusList(string strDeComID, string VstrLevelName, string fDate, string tDate)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesPriceLevel> oogrp = new List<SalesPriceLevel>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT DISTINCT  BRANCH_ID,BONUS_EFFECTIVE_DATE  ";
            strSQL = strSQL + "FROM INV_SALES_BONUS ";
            strSQL = strSQL + " ORDER BY BONUS_EFFECTIVE_DATE ASC ";

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
                    SalesPriceLevel ogrp = new SalesPriceLevel();
                    // ogrp.lngSlNo = Convert.ToInt64(drGetGroup["SALES_PRICE_SERIAL"].ToString());
                    ogrp.strSalesPriceLevel = drGetGroup["BRANCH_ID"].ToString();
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["BONUS_EFFECTIVE_DATE"]).ToString("dd/MM/yyyy");
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<SalesPriceLevel> mGiftList(string strDeComID, string VstrLevelName, string fDate, string tDate)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesPriceLevel> oogrp = new List<SalesPriceLevel>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT DISTINCT  BRANCH_ID,GIFT_EFFECTIVE_DATE  ";
            strSQL = strSQL + "FROM INV_SALES_GIFT ";
            strSQL = strSQL + " ORDER BY GIFT_EFFECTIVE_DATE ASC ";

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
                    SalesPriceLevel ogrp = new SalesPriceLevel();
                    // ogrp.lngSlNo = Convert.ToInt64(drGetGroup["SALES_PRICE_SERIAL"].ToString());
                    ogrp.strSalesPriceLevel = drGetGroup["BRANCH_ID"].ToString();
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["GIFT_EFFECTIVE_DATE"]).ToString("dd/MM/yyyy");
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }


        public List<SalesPriceLevel> mRefreshPriceList(string strDeComID, string VstrLevelName, string fDate, string tDate)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesPriceLevel> oogrp = new List<SalesPriceLevel>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT DISTINCT  PRICE_LEVEL_NAME, SALES_PRICE_EFFECTIVE_DATE  ";
            strSQL = strSQL + "FROM INV_SALES_PRICE ";
            //If mIntegretedSalesPrice <> 1 Then
            strSQL = strSQL + "WHERE MODULE_STATUS=0 ";
            //End If
            if (VstrLevelName == "")
            {
                if (fDate != "")
                {
                    strSQL = strSQL + " AND SALES_PRICE_EFFECTIVE_DATE BETWEEN " + Utility.cvtSQLDateString(fDate) + "";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(tDate) + " ";
                }
                //else
                //{

                //    strSQL = strSQL + " WHERE SALES_PRICE_EFFECTIVE_DATE BETWEEN " + cvtSQLDate(Date) + "";
                //    strSQL = strSQL + " AND " + cvtSQLDate(Date) + " ";
                //}

            }
            else
            {
                strSQL = strSQL + "AND PRICE_LEVEL_NAME like'" + VstrLevelName.Replace("'", "''") + "%' ";
            }
            strSQL = strSQL + " ORDER BY PRICE_LEVEL_NAME ASC ";

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
                    SalesPriceLevel ogrp = new SalesPriceLevel();
                    // ogrp.lngSlNo = Convert.ToInt64(drGetGroup["SALES_PRICE_SERIAL"].ToString());
                    ogrp.strSalesPriceLevel = drGetGroup["PRICE_LEVEL_NAME"].ToString();
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["SALES_PRICE_EFFECTIVE_DATE"]).ToString("dd/MM/yyyy");
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public string mDeletePriceList(string strDeComID, string VstrLevelName, string strDate)
        {
            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();

                    SqlCommand cmdDelete = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdDelete.Connection = gcnMain;
                    cmdDelete.Transaction = myTrans;

                    strSQL = "DELETE FROM INV_SALES_PRICE ";
                    strSQL = strSQL + "WHERE PRICE_LEVEL_NAME='" + VstrLevelName + "' ";
                    strSQL = strSQL + "AND SALES_PRICE_EFFECTIVE_DATE = " + Utility.cvtSQLDateString(strDate) + " ";
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    cmdDelete.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                finally
                {
                    gcnMain.Close();
                }



            }
        }





        #endregion
        #region "Gift Item"
        public string mInsertGiftItem(string strDeComID, string DgGrid, string strAppDate, string strDateKey)
        {

            string strSQL, strItemName = "", strBonusItem = "", strBonusKey = "", strDate = "", strBranchId = "", strItemKey = "", strBonusUOM = "";
            double dblQty = 0, dblGiftQty = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    SqlDataReader rsGet;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    string[] words = DgGrid.Split('~');
                    foreach (string ooObj in words)
                    {
                        string[] ooItem = ooObj.Split(',');
                        if (ooItem[0] != "")
                        {
                            strItemName = ooItem[0].ToString();
                            strDate = ooItem[1].ToString();
                            dblQty = Convert.ToDouble(ooItem[2].ToString());
                            strBonusItem = ooItem[3].ToString();
                            dblGiftQty = Convert.ToDouble(ooItem[4].ToString());
                            strBranchId = Utility.gstrGetBranchID(strDeComID, ooItem[5].ToString());
                            strBonusKey = strBranchId + strItemName + strDateKey;
                            strItemKey = (strBonusKey);

                            strSQL = "SELECT GIFT_KEY FROM INV_SALES_GIFT ";
                            strSQL = strSQL + "WHERE GIFT_KEY = '" + strBonusKey + "'";
                            cmdInsert.CommandText = strSQL;
                            rsGet = cmdInsert.ExecuteReader();
                            if (rsGet.Read())
                            {
                                rsGet.Close();
                                strSQL = "UPDATE INV_SALES_GIFT ";
                                strSQL = strSQL + "SET ";
                                strSQL = strSQL + "GIFT_EFFECTIVE_DATE = " + Utility.cvtSQLDateString(strDate) + ",";
                                strSQL = strSQL + "STOCKITEM_NAME = '" + strItemName + "', ";
                                strSQL = strSQL + "QTY=" + dblQty + ", ";
                                strSQL = strSQL + "STOCKITEM_NAME_GIFT = '" + strBonusItem + "',";
                                strSQL = strSQL + "GIFT_QTY = '" + dblGiftQty + "',";
                                strSQL = strSQL + "BRANCH_ID ='" + strBranchId + "' ";
                                strSQL = strSQL + "WHERE  GIFT_KEY = '" + strBonusKey + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                            else
                            {
                                rsGet.Close();

                                strItemName = ooItem[0].ToString();
                                strDate = ooItem[1].ToString();
                                dblQty = Convert.ToDouble(ooItem[2].ToString());
                                strBonusItem = ooItem[3].ToString();
                                dblGiftQty = Convert.ToDouble(ooItem[4].ToString());
                                strBranchId = Utility.gstrGetBranchID(strDeComID, ooItem[5].ToString());
                                strBonusKey = strBranchId + strItemName + strDateKey;
                                strSQL = "INSERT INTO INV_SALES_GIFT";
                                strSQL = strSQL + "(GIFT_KEY,GIFT_EFFECTIVE_DATE,STOCKITEM_NAME,QTY,";
                                strSQL = strSQL + "STOCKITEM_NAME_GIFT,GIFT_QTY";
                                strSQL = strSQL + ",BRANCH_ID";
                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES";
                                strSQL = strSQL + "(";
                                strSQL = strSQL + "'" + strBonusKey + " ',";
                                strSQL = strSQL + "" + Utility.cvtSQLDateString(strDate) + ",";
                                strSQL = strSQL + "'" + strItemName + "',";
                                strSQL = strSQL + "" + dblQty + ",";
                                strSQL = strSQL + "'" + strBonusItem + "',";
                                strSQL = strSQL + "" + dblGiftQty + ",";
                                if (Utility.gblnBranch)
                                {
                                    strSQL = strSQL + "'" + strBranchId + "'";
                                }
                                else
                                {
                                    strSQL = strSQL + "'0001' ";
                                }
                                strSQL = strSQL + ")";

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                            rsGet.Close();
                        }
                    }
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "1";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public List<SalesPriceLevel> mDisplayGiftItemGroup(string strDeComID, string vstrDate)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesPriceLevel> oogrp = new List<SalesPriceLevel>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM INV_SALES_GIFT ";
            //strSQL = strSQL + "WHERE PRICE_LEVEL_NAME = '" + vstrItemGroup + "' ";
            strSQL = strSQL + "WHERE GIFT_EFFECTIVE_DATE = " + Utility.cvtSQLDateString(vstrDate) + " ";
            // strSQL = strSQL + "AND MODULE_STATUS = 0 ";
            strSQL = strSQL + "ORDER BY STOCKITEM_NAME ASC, GIFT_SERIAL ASC ";

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

                    SalesPriceLevel ogrp = new SalesPriceLevel();
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["GIFT_EFFECTIVE_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.strBonusItem = drGetGroup["STOCKITEM_NAME_GIFT"].ToString();
                    ogrp.dblFromQty = Convert.ToDouble(drGetGroup["QTY"].ToString());
                    ogrp.dblToQty = Convert.ToDouble(drGetGroup["GIFT_QTY"].ToString());
                    ogrp.strBranchName = Utility.gstrGetBranchName(strDeComID, drGetGroup["BRANCH_ID"].ToString());
                    StockItem ostr = new StockItem();
                    ostr.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.strPrice = ostr;
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public string mDeleteGiftItem(string strDeComID, string strAppDate, string vstrBranchId)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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

                    strSQL = "DELETE FROM INV_SALES_GIFT ";
                    strSQL = strSQL + "WHERE GIFT_EFFECTIVE_DATE = " + Utility.cvtSQLDateString(strAppDate) + " ";
                    if (Utility.gblnBranch)
                    {
                        strSQL = strSQL + "AND BRANCH_ID = '" + vstrBranchId + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        #endregion
        #region "Bonus Item"
        public string mInsertBonusItem(string strDeComID, string DgGrid, string strAppDate, string strDateKey)
        {

            string strSQL, strItemName = "", strBonusKey = "", strBonusUOM = "", strDate = "", strBranchId = "", strItemKey = "";
            double dblQty = 0, dblGiftQty = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    SqlDataReader rsGet;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;



                    string[] words = DgGrid.Split('~');
                    foreach (string ooObj in words)
                    {
                        string[] ooItem = ooObj.Split(',');
                        if (ooItem[0] != "")
                        {
                            strItemName = ooItem[0].ToString().Replace("'", "''");
                            strDate = ooItem[1].ToString();
                            dblQty = Convert.ToDouble(ooItem[2].ToString());
                            dblGiftQty = Convert.ToDouble(ooItem[3].ToString());
                            strBonusUOM = Utility.gGetBaseUOM(strDeComID, strItemName);
                            strBranchId = Utility.gstrGetBranchID(strDeComID, ooItem[4].ToString());
                            strBonusKey = strBranchId + strItemName + strDateKey;

                            strItemKey = (strBonusKey);
                            strSQL = "SELECT BONUS_KEY FROM INV_SALES_BONUS ";
                            strSQL = strSQL + "WHERE BONUS_KEY = '" + strBonusKey + "'";
                            cmdInsert.CommandText = strSQL;
                            rsGet = cmdInsert.ExecuteReader();
                            if (rsGet.Read())
                            {
                                rsGet.Close();
                                strSQL = "UPDATE INV_SALES_BONUS ";
                                strSQL = strSQL + "SET ";
                                strSQL = strSQL + "BONUS_EFFECTIVE_DATE = " + Utility.cvtSQLDateString(strDate) + ",";
                                strSQL = strSQL + "STOCKITEM_NAME = '" + strItemName + "', ";
                                strSQL = strSQL + "QTY=" + dblQty + ", ";
                                strSQL = strSQL + "BONUS_QTY = " + dblGiftQty + ",";
                                strSQL = strSQL + "BONUS_UOM = '" + strBonusUOM + "',";
                                strSQL = strSQL + " BRANCH_ID='" + strBranchId + "' ";
                                strSQL = strSQL + "WHERE BONUS_KEY = '" + strItemKey + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                            else
                            {
                                rsGet.Close();
                                strSQL = "INSERT INTO INV_SALES_BONUS";
                                strSQL = strSQL + "(BONUS_KEY,BONUS_EFFECTIVE_DATE,STOCKITEM_NAME,QTY,";
                                strSQL = strSQL + "BONUS_QTY,BONUS_UOM";
                                strSQL = strSQL + ",BRANCH_ID";
                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES";
                                strSQL = strSQL + "(";
                                strSQL = strSQL + "'" + strBonusKey + " ',";
                                strSQL = strSQL + "" + Utility.cvtSQLDateString(strDate) + ",";
                                strSQL = strSQL + "'" + strItemName + "',";
                                strSQL = strSQL + "" + dblQty + ",";
                                strSQL = strSQL + "" + dblGiftQty + ",";
                                strSQL = strSQL + "'" + strBonusUOM + "',";
                                strSQL = strSQL + "'" + strBranchId + "'";
                                strSQL = strSQL + ")";

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                            rsGet.Close();
                        }

                    }

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();

                    return "1";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public List<SalesPriceLevel> mDisplayBonusItemGroup(string strDeComID, string vstrDate)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesPriceLevel> oogrp = new List<SalesPriceLevel>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM INV_SALES_BONUS  ";
            //strSQL = strSQL + "WHERE PRICE_LEVEL_NAME = '" + vstrItemGroup + "' ";
            strSQL = strSQL + "WHERE BONUS_EFFECTIVE_DATE  = " + Utility.cvtSQLDateString(vstrDate) + " ";
            // strSQL = strSQL + "AND MODULE_STATUS = 0 ";
            strSQL = strSQL + "ORDER BY STOCKITEM_NAME ASC ";

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

                    SalesPriceLevel ogrp = new SalesPriceLevel();
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["BONUS_EFFECTIVE_DATE"]).ToString("dd/MM/yyyy");
                    //ogrp.strBonusItem = drGetGroup["STOCKITEM_NAME_GIFT"].ToString();
                    ogrp.dblFromQty = Convert.ToDouble(drGetGroup["QTY"].ToString());
                    ogrp.dblToQty = Convert.ToDouble(drGetGroup["BONUS_QTY"].ToString());
                    ogrp.strBranchName = Utility.gstrGetBranchName(strDeComID, drGetGroup["BRANCH_ID"].ToString());
                    StockItem ostr = new StockItem();
                    ostr.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.strPrice = ostr;
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public string mDeleteBonusItem(string strDeComID, string strAppDate, string vstrBranchId)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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

                    strSQL = "DELETE FROM INV_SALES_BONUS ";
                    strSQL = strSQL + "WHERE BONUS_EFFECTIVE_DATE = " + Utility.cvtSQLDateString(strAppDate) + " ";
                    if (Utility.gblnBranch)
                    {
                        strSQL = strSQL + "AND BRANCH_ID = '" + vstrBranchId + "'";
                    }
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        #endregion
        #region "Sales Order"

        public string msaveSalesOrder(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                        double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency, string strSalesRep,
                                        string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                        bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool mblnNumbMethod,
                                        string strPrepareBy, int intAppStatus, string strApprovedBy, 
                                        string strApprovedDate, double dblNetQty,double  dblLessAmount,double dblTotal)
        {
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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

                    strSQL = Voucher.gInsertCompanyVoucher(strRefNo, mlngVType, strDate, strMonthID, strDueDate, strLedgerName, dblNetAmount, dblTotal, 0, dblLessAmount, 0, strNarrations,
                                                        strBranchId, lngIsMultiCurrency, Utility.Mid(strRefNo, 9, strRefNo.Length - 9), strSalesRep, strDelivery, strPayment, strSupport, dteValidaty,
                                                        strOtherTerms, "", "", strPrepareBy, strDate, "", "", 0, 0, 0, 0, 0, intAppStatus, strApprovedBy, strApprovedDate, "", "", dblNetQty);

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    if (DG != "")
                    {
                        string strBillKey = "", strItemName = "", strPer = "", strBatchNo = "", strGroupName = "", strsubFroup = "";
                        long lngBillPosition = 1, lngloop = 1;
                        double dblqty = 0, dblRate = 0, dblDebitValue, dblbonus = 0, dblCommPer = 0, dblCommAmnt = 0,dblTotalamnt;
                        string[] words = DG.Split('~');
                        foreach (string strValue in words)
                        {
                            string[] ooValue = strValue.Split('|');
                            if (ooValue[0] != "")
                            {
                                strBillKey = strRefNo + lngBillPosition.ToString().PadRight(4, '0');
                                strGroupName = ooValue[0].ToString();
                                strItemName = ooValue[1].ToString();
                                dblqty = Utility.Val(ooValue[4].ToString());
                                strPer = ooValue[6].ToString();
                                dblRate = Utility.Val(ooValue[5].ToString());
                                dblDebitValue = Utility.Val(ooValue[7].ToString());
                                dblbonus = Utility.Val(ooValue[8].ToString());
                                strsubFroup = ooValue[9].ToString();
                                dblTotalamnt = Utility.Val(ooValue[10].ToString());
                                dblCommAmnt = Utility.Val(ooValue[11].ToString());
                                dblCommPer = Utility.Val(ooValue[12].ToString());

                                //if (blnMultiCurr)
                                //{
                                //    dblRate = Utility.Val(ooValue[3].ToString());
                                //    dblFCDebit = dblDebitValue / mdblCurrRate;
                                //    strSQL = Voucher.gInsertBillTranFC(strBillKey, strRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, 0,
                                //                                        strPer, dblRate, dblDebitValue, "", dblCommAmnt, dblDebitValue, "Cr", mdblCurrRate, dblFCDebit, strBranchId,
                                //                                        mstrFCsymbol, lngloop, strPer, "", strBatchNo);
                                //    cmdInsert.CommandText = strSQL;
                                //    cmdInsert.ExecuteNonQuery();
                                //}
                                //else
                                //{
                                strSQL = Voucher.gInsertBillTran(strBillKey, strRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblbonus,
                                                                    strPer, dblRate, dblTotalamnt, "0", dblCommAmnt, dblDebitValue, "Cr", lngloop, strBranchId,
                                                                     Utility.gstrBaseCurrency, strPer, "", "", strBatchNo, "", strsubFroup, "", strGroupName, 0, dblCommPer);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                //}

                                strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, strRefNo, strRefNo, mlngVType, strDate,
                                                                        strItemName, strGodownName, dblqty, strPer, strBillKey, 0, dblDebitValue, strPer);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET APPS_SYNCHONIZED =1,ORDER_DATE= " + Utility.cvtSQLDateString(strDate) + " WHERE COMP_REF_NO='" + strRefNo + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lngBillPosition += 1;
                                lngloop += 1;
                            }
                        }
                        if (mblnNumbMethod == true)
                        {
                            strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        cmdInsert.Transaction.Commit();

                    }


                    gcnMain.Close();
                    return "Inserted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }
        public string mUpdateSalesOrderOnlineComm(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strBranchId, string strGodownName, string DG)
                                     
        {
            string strsubFroup = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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
                    SqlDataReader dr;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    strSQL = "DELETE FROM ACC_BILL_TRAN WHERE COMP_REF_NO = '" + strRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO = '" + strRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                   
                    if (DG != "")
                    {
                        string strBillKey = "", strItemName = "", strPer = "", strBatchNo = "", strGroupName = "";
                        long lngBillPosition = 1, lngloop = 1;
                        double dblqty = 0, dblRate = 0, dblDebitValue, dblbonus = 0, dblCommPer = 0, dblCommAmnt = 0, dblTotalamnt = 0;
                        string[] words = DG.Split('~');
                        foreach (string strValue in words)
                        {
                            string[] ooValue = strValue.Split('|');
                            if (ooValue[0] != "")
                            {
                                strBillKey = Utility.Mid(strRefNo, 9, strRefNo.Length - 9) + lngBillPosition.ToString().PadRight(4, '0');
                                strSQL = "SELECT BILL_TRAN_KEY FROM ACC_BILL_TRAN WHERE BILL_TRAN_KEY='" + strBillKey + "' ";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {
                                    lngBillPosition += 1;
                                    strBillKey = Utility.Mid(strRefNo, 9, strRefNo.Length - 9) + lngBillPosition.ToString().PadRight(4, '0');
                                }
                                dr.Close();
                                strGroupName = ooValue[0].ToString();
                                strItemName = ooValue[1].ToString();
                                dblqty = Utility.Val(ooValue[4].ToString());
                                strPer = ooValue[6].ToString();
                                dblRate = Utility.Val(ooValue[5].ToString());
                                dblDebitValue = Utility.Val(ooValue[7].ToString());
                                dblbonus = Utility.Val(ooValue[8].ToString());
                                strsubFroup = ooValue[9].ToString();
                                dblTotalamnt = Utility.Val(ooValue[10].ToString());
                                dblCommAmnt = Utility.Val(ooValue[11].ToString());
                                dblCommPer = Utility.Val(ooValue[12].ToString());
                               
                                strSQL = Voucher.gInsertBillTran(strBillKey, strRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblbonus,
                                                                    strPer, dblRate, dblCommAmnt, "0", dblTotalamnt, dblDebitValue, "Cr", lngloop, strBranchId,
                                                                     Utility.gstrBaseCurrency, strPer, "", "", strBatchNo, "", strsubFroup, "", strGroupName, 0, dblCommPer);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                               
                                strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, strRefNo, strRefNo, mlngVType, strDate,
                                                                        strItemName, strGodownName, dblqty, strPer, strBillKey, 0, dblDebitValue, strPer);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET APPS_COMM_CAL=1 ";
                                strSQL = strSQL + "WHERE COMP_REF_NO='" + strRefNo + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lngBillPosition += 1;
                                lngloop += 1;
                            }
                        }
                        cmdInsert.Transaction.Commit();

                    }


                    gcnMain.Close();
                    return "1";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }



        }
        public string mUpdateSalesOrder(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                       double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency, string strSalesRep,
                                       string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                       bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, string strPrepareBy, int intAppStatus, string strApprovedBy,
                                        string strApprovedDate, double dblNetQty, int intChaneType, double dblLessAmount, double dblTotal)
        {
            string strsubFroup = "";
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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
                    strSQL = "DELETE FROM ACC_BILL_TRAN WHERE COMP_REF_NO = '" + strRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO = '" + strRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "UPDATE ACC_COMPANY_VOUCHER SET ";
                    strSQL = strSQL + "COMP_REF_NO='" + strRefNo + "',";
                    strSQL = strSQL + "BRANCH_ID = '" + strBranchId + "',";
                    strSQL = strSQL + "LEDGER_NAME= '" + strLedgerName + "',";
                    //strSQL = strSQL + "APPS_CUSTOMER_MERZE= '" + strLedgerName + "',";
                    strSQL = strSQL + "COMP_VOUCHER_DATE = " + Utility.cvtSQLDateString(strDate) + ",";
                    strSQL = strSQL + "COMP_VOUCHER_MONTH_ID = '" + strMonthID + "',";
                    strSQL = strSQL + "COMP_VOUCHER_NET_AMOUNT ='" + dblTotal + "',";
                    strSQL = strSQL + "COMP_VOUCHER_AMOUNT ='" + dblNetAmount + "',";
                    strSQL = strSQL + "APPS_COMP_QTY ='" + dblNetQty + "',";
                    strSQL = strSQL + "COMP_VOUCHER_LESS_AMOUNT ='" + dblLessAmount + "',";
                    strSQL = strSQL + "COMP_VOUCHER_DUE_DATE = " + Utility.cvtSQLDateString(strDueDate) + ", ";
                    strSQL = strSQL + "COMP_VOUCHER_NARRATION = '" + strNarrations + "'";
                    //strSQL = strSQL + ",AGNST_COMP_REF_NO ='" + Utility.Mid(strRefNo, 10, strRefNo.Length - 10) + "'";
                    strSQL = strSQL + ",APPROVED_BY ='" + strApprovedBy.Replace("'", "''") + "' ";
                    strSQL = strSQL + ",APPS_CHANGE =" + intChaneType + " ";
                    if (strApprovedDate != "")
                    {
                        strSQL = strSQL + ",APPROVED_DATE =" + Utility.cvtSQLDateString(strApprovedDate) + "";
                    }
                    else
                    {
                        strSQL = strSQL + ",APPROVED_DATE =NULL";
                    }
                    if (strDelivery != "")
                    {
                        strSQL = strSQL + ",COMP_DELIVERY = '" + strDelivery + "'";
                    }
                    if (strPayment != "")
                    {
                        strSQL = strSQL + ",COMP_TERM_OF_PAYMENTS = '" + strPayment + "'";
                    }
                    if (strSupport != "")
                    {
                        strSQL = strSQL + ",COMP_SUPPORT = '" + strSupport + "'";
                    }
                    if (dteValidaty != "")
                    {
                        strSQL = strSQL + ",COMP_VALIDITY_DATE = " + Utility.cvtSQLDateString(dteValidaty) + "";
                    }
                    else
                    {
                        strSQL = strSQL + ",COMP_VALIDITY_DATE = null";
                    }
                    if (strOtherTerms != "")
                    {
                        strSQL = strSQL + ",COMP_OTHERS = '" + strOtherTerms + "'";
                    }
                    if (strSalesRep != Utility.gcEND_OF_LIST)
                    {
                        strSQL = strSQL + ",SALES_REP = '" + strSalesRep + "' ";
                    }
                    else
                    {
                        strSQL = strSQL + ",SALES_REP = ''";
                    }
                    strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    if (DG != "")
                    {
                        string strBillKey = "", strItemName = "", strPer = "", strBatchNo = "", strGroupName = "";
                        long lngBillPosition = 1, lngloop = 1;

                        double dblqty = 0, dblRate = 0, dblDebitValue, dblbonus = 0, dblCommPer = 0, dblCommAmnt = 0, dblTotalamnt=0;
                        string[] words = DG.Split('~');
                        foreach (string strValue in words)
                        {
                            string[] ooValue = strValue.Split('|');
                            if (ooValue[0] != "")
                            {
                                strBillKey = Utility.Mid(strRefNo, 9, strRefNo.Length - 9) + lngBillPosition.ToString().PadRight(4, '0');
                                strSQL = "SELECT BILL_TRAN_KEY FROM ACC_BILL_TRAN WHERE BILL_TRAN_KEY='" + strBillKey + "' ";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {
                                    lngBillPosition += 1;
                                    strBillKey = Utility.Mid(strRefNo, 9, strRefNo.Length - 9) + lngBillPosition.ToString().PadRight(4, '0');
                                }
                                dr.Close();
                                strGroupName = ooValue[0].ToString();
                                strItemName = ooValue[1].ToString();
                                dblqty = Utility.Val(ooValue[4].ToString());
                                strPer = ooValue[6].ToString();
                                dblRate = Utility.Val(ooValue[5].ToString());
                                dblDebitValue = Utility.Val(ooValue[7].ToString());
                                dblbonus = Utility.Val(ooValue[8].ToString());
                                strsubFroup = ooValue[9].ToString();
                                dblTotalamnt = Utility.Val(ooValue[10].ToString());
                                dblCommAmnt = Utility.Val(ooValue[11].ToString());
                                dblCommPer = Utility.Val(ooValue[12].ToString());
                             
                                strSQL = Voucher.gInsertBillTran(strBillKey, strRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblbonus,
                                                                    strPer, dblRate, dblTotalamnt, "0", dblCommAmnt, dblDebitValue, "Cr", lngloop, strBranchId,
                                                                     Utility.gstrBaseCurrency, strPer, "", "", strBatchNo, "", strsubFroup, "", strGroupName, 0, dblCommPer);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                
                                strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, strRefNo, strRefNo, mlngVType, strDate,
                                                                        strItemName, strGodownName, dblqty, strPer, strBillKey, 0, dblDebitValue, strPer);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET APPS_SYNCHONIZED =1 WHERE COMP_REF_NO='" + strRefNo + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lngBillPosition += 1;
                                lngloop += 1;
                            }
                        }
                        cmdInsert.Transaction.Commit();

                    }


                    gcnMain.Close();
                    return "Updated...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }



        }






        #endregion
        #region "AllOrder"
        public List<Invoice> mGetAllOrder(string strDeComID, string vstrBranchID, long lngrefType, string vstrRefNumber)
        {
            string strSQL, strRefNumber = "";
            SqlDataReader drGetGroup;
            List<Invoice> oogrp = new List<Invoice>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            if (lngrefType != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
            {
                if (lngrefType > 0)
                {
                    // strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(lngrefType) + vstrBranchID + vstrRefNumber;
                    strRefNumber = vstrRefNumber;

                }
                strSQL = "SELECT BILL_TRAN_KEY,STOCKGROUP_NAME,STOCKITEM_NAME,GODOWNS_NAME,BILL_BALANCE_QTY,";
                strSQL = strSQL + "BILL_UOM,BILL_PER,BILL_RATE,BILL_NET_AMOUNT,BILL_AMOUNT,INV_LOG_NO,BILL_QUANTITY_BONUS,BILL_ADD_LESS_AMOUNT ";
                strSQL = strSQL + "FROM ACC_BILL_TRAN_PENDING_QRY ";
                strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNumber + "' ";

            }
            else
            {
                strSQL = "SELECT '' as BILL_TRAN_KEY,'' STOCKGROUP_NAME,STOCKITEM_NAME,'' AS GODOWNS_NAME,SAM_CLASS_QUANTITY AS BILL_BALANCE_QTY,";
                strSQL = strSQL + "SAM_CLASS_UOM AS BILL_UOM,SAM_CLASS_UOM AS BILL_PER,0 AS BILL_RATE,0 as BILL_NET_AMOUNT,0 BILL_AMOUNT,'' as INV_LOG_NO ";
                strSQL = strSQL + ",0 BILL_QUANTITY_BONUS,0 BILL_ADD_LESS_AMOUNT FROM ACC_SAMPLE_CLASS_TRAN ";
                strSQL = strSQL + "WHERE SAMPLE_CLASS = '" + vstrRefNumber + "' ";
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
                    Invoice ogrp = new Invoice();
                    if (lngrefType != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                    {
                        if (drGetGroup["BILL_TRAN_KEY"].ToString() != "")
                        {
                            ogrp.strBillKey = drGetGroup["BILL_TRAN_KEY"].ToString();
                        }
                        else
                        {
                            ogrp.strBillKey = "";
                        }
                    }
                    else
                    {
                        if (drGetGroup["BILL_TRAN_KEY"].ToString() != "")
                        {
                            ogrp.strBillKey = strRefNumber;
                        }
                        else
                        {
                            ogrp.strBillKey = "";
                        }
                    }
                    if (drGetGroup["STOCKGROUP_NAME"].ToString() != "")
                    {
                        ogrp.strGroupName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strGroupName = "";
                    }

                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    if (drGetGroup["GODOWNS_NAME"].ToString() != "")
                    {
                        ogrp.strGodownsName = drGetGroup["GODOWNS_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strGodownsName = "";
                    }
                    if (drGetGroup["INV_LOG_NO"].ToString() != "")
                    {
                        ogrp.strBatch = drGetGroup["INV_LOG_NO"].ToString();
                    }
                    else
                    {
                        ogrp.strBatch = "";
                    }

                    ogrp.strUnit = drGetGroup["BILL_PER"].ToString();
                    ogrp.strUom = drGetGroup["BILL_UOM"].ToString();
                    ogrp.dblQty = Utility.Val(drGetGroup["BILL_BALANCE_QTY"].ToString());
                    ogrp.dblRate = Utility.Val(drGetGroup["BILL_RATE"].ToString());
                    ogrp.dblBonusQty = Utility.Val(drGetGroup["BILL_QUANTITY_BONUS"].ToString());
                    ogrp.dblNetAmount = Utility.Val(drGetGroup["BILL_NET_AMOUNT"].ToString());
                    ogrp.dblBillAmount  = Utility.Val(drGetGroup["BILL_AMOUNT"].ToString());
                    ogrp.dblCommAmount = Math.Abs(Utility.Val(drGetGroup["BILL_ADD_LESS_AMOUNT"].ToString()));
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }

        }

        #endregion
        #region "Get"
        public List<InvoiceConfig> mGetInvoiceConfig(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<InvoiceConfig> oogrp = new List<InvoiceConfig>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT SALES_INVOICE_ITEM_DESCRIPTION,SALES_DISCOUNT_ALLOWED,ALLOW_SEPARATE_PARTY_NAME, ";
            strSQL = strSQL + "SALES_INVOICE_ITEM_DESCRIPTION,BLOCK_NEGATIVE_STOCK,CALC_ADDL_ON_SUB_TOTAL ";
            strSQL = strSQL + "FROM ACC_INVOICE_CONFIG ";
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                if (drGetGroup.Read())
                {
                    InvoiceConfig ogrp = new InvoiceConfig();
                    if (Convert.ToInt32(drGetGroup["SALES_INVOICE_ITEM_DESCRIPTION"]) == 0)
                    {
                        ogrp.mblnItemDescription = false;
                    }
                    else
                    {
                        ogrp.mblnItemDescription = true;
                    }
                    ogrp.mlngSeparateParty = Convert.ToInt32(drGetGroup["ALLOW_SEPARATE_PARTY_NAME"].ToString());
                    if (Convert.ToInt32(drGetGroup["SALES_DISCOUNT_ALLOWED"]) == 1)
                    {
                        ogrp.mblnDiscountAllowed = true;
                    }
                    else
                    {
                        ogrp.mblnDiscountAllowed = false;
                    }
                    ogrp.mlngBlockNegativeStock = Convert.ToInt32(drGetGroup["BLOCK_NEGATIVE_STOCK"].ToString());
                    ogrp.mlngCalcSubTotal = Convert.ToInt32(drGetGroup["CALC_ADDL_ON_SUB_TOTAL"].ToString());
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }
        public List<InvoiceConfig> mGetInvoiceConfigNew(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<InvoiceConfig> oogrp = new List<InvoiceConfig>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT EFFECT_INVENTORY_DIRECT_SALES,EFFECT_INVENTORY_DIRECT_PI FROM ACC_COMPANY ";
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
                    InvoiceConfig ogrp = new InvoiceConfig();
                    ogrp.mlngIsInvEffinDirSalesInv = Convert.ToInt32(drGetGroup["EFFECT_INVENTORY_DIRECT_SALES"].ToString());
                    ogrp.mlngIsInvEffinDirPurcInv = Convert.ToInt32(drGetGroup["EFFECT_INVENTORY_DIRECT_PI"].ToString());
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }

        public string mUpdateOption(string strDeComID, int intNegetive)
        {
            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                    SqlCommand cmdUpdae = new SqlCommand();
                    strSQL = "UPDATE ACC_INVOICE_CONFIG SET BLOCK_NEGATIVE_STOCK  =  " + intNegetive + " ";
                    cmdUpdae.CommandText = strSQL;
                    cmdUpdae.Connection = gcnMain;
                    cmdUpdae.ExecuteNonQuery();
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }


            }
        }
        #endregion
        #region "Sales Invoice"
        //public string mSaveSalesInvoice(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger, double dblTotalAmnt,
        //                               double dblNetAmount, double dblAddAmount, double dblLessAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirSalesInv, long mlngIsChqueCash, string strNarrations,
        //                               string strBranchId, string vstrGodownName, long lngIsMultiCurrency, string strSalesRep, string DGSDalesGrid, string DGVector, string DGBillWise, string DGsalesOrder,
        //                               string DGAddless, bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool blngNumberMethod, string strOrderNo, string strOrderDate, string strPreparedby,
        //                               string strPreparedDate, double dblProcessAmount, double dblRoundOff)
        //{

        //    string strDRCR = "", strGroupName, strReverseLedger = "";
        //    string strBillKey, strItemName,  strItemBangla,strAgnstRefno="", strItemDesc, strAddLess, strBatchNo, strUOm, strPer, strGodownName,  strbatch = "";
        //    double dblCredit = 0, dblqty = 0, dblRate, dblTotalAmount, dblDiscAmount, dblDebitValue, dblBonusQty, dblCostPrice;
        //    long lngloop = 1, lngPosition = 1, mlngCashFlow = 2, lngLedgergroup;
        //    bool blnMultiple = false;
        //    double dblShort = 0,dblCommPer=0;
        //    int intRoundOff = 0;

        //    lngLedgergroup = (long)(Utility.gGetLedgergroup(strDeComID, strLedgerName));

        //    if (lngLedgergroup <= 101)
        //    {
        //        mlngCashFlow = 1;
        //    }
        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }

        //        try
        //        {
        //            gcnMain.Open();
        //            SqlDataReader rsget;
        //            SqlCommand cmdInsert = new SqlCommand();
        //            SqlTransaction myTrans;
        //            myTrans = gcnMain.BeginTransaction();
        //            cmdInsert.Connection = gcnMain;
        //            cmdInsert.Transaction = myTrans;

        //            strSQL = Voucher.gInsertCompanyVoucher(strRefNo, mlngVType, strDate, strMonthID, strDueDate, strLedgerName, dblTotalAmnt,
        //                                                dblNetAmount, dblAddAmount, dblLessAmount, lngAgstRef, strNarrations,
        //                                                strBranchId, lngIsMultiCurrency, "", strSalesRep, "", "", "", "", "",
        //                                                strOrderNo, strOrderDate, strPreparedby, strPreparedDate, "", "", 0, 0, dblProcessAmount, dblRoundOff);

        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();


        //            if (DGVector != "")
        //            {
        //                string[] words = DGVector.Split('~');
        //                foreach (string strVector in words)
        //                {
        //                    string[] ooCost = strVector.Split('|');
        //                    if (ooCost[0] != "")
        //                    {
        //                        strSQL = Voucher.mInsertVector(strRefNo, ooCost[1].ToString(), ooCost[2].ToString(), strDate, strLedgerName, "Dr", lngPosition, lngPosition, 1, ooCost[0].ToString(), Utility.Val(ooCost[3].ToString()), 0, "", mlngVType);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        strSQL = Voucher.mInsertVector(strRefNo, ooCost[1].ToString(), ooCost[2].ToString(), strDate, strLedgerName, "Cr", lngPosition, lngPosition, 2, ooCost[0].ToString(), Utility.Val(ooCost[3].ToString()), 0, "", mlngVType);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        lngPosition += 1;
        //                    }

        //                }
        //            }
        //            lngPosition = 1;
        //            //'If Cash Or Bank Then Should not go in Bill By Bill
        //            if (mlngCashFlow > 1)
        //            {
        //                if (DGBillWise != "")
        //                {
        //                    int intbillpos = 1;
        //                    string strAgstRefNo = "";
        //                    string[] words = DGBillWise.Split('~');
        //                    foreach (string strBill in words)
        //                    {
        //                        string[] ooCost = strBill.Split('|');
        //                        if (ooCost[0] != "")
        //                        {
        //                            strAgstRefNo = strBranchId + ooCost[1].ToString();
        //                            strSQL = Voucher.gInsertBillWise(strBranchId, strRefNo, ooCost[2].ToString(), mlngVType, strLedgerName, intbillpos, ooCost[0].ToString(),
        //                                                                Utility.Val(ooCost[3].ToString()), ooCost[4].ToString(), strAgstRefNo, intbillpos);
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                            intbillpos += 1;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (mlngVType == (long)(Utility.VOUCHER_TYPE.vtSALES_INVOICE))
        //                    {
        //                        strDRCR = "Dr";
        //                    }
        //                    else
        //                    {
        //                        strDRCR = "Cr";
        //                    }

        //                    strSQL = Voucher.gInsertBillWise(strBranchId, strRefNo, strDate, mlngVType, strLedgerName, 0, "New Ref", dblNetAmount, strDRCR, Utility.Mid(strRefNo, 6, strRefNo.Length - 6), 0, strDueDate);
        //                    cmdInsert.CommandText = strSQL;
        //                    cmdInsert.ExecuteNonQuery();
        //                }

        //            }

        //            if (DGSDalesGrid != "")
        //            {
        //                string[] words = DGSDalesGrid.Split('~');
        //                foreach (string strSalesGrid in words)
        //                {
        //                    string[] ooCost = strSalesGrid.Split('|');
        //                    if (ooCost[0] != "")
        //                    {
        //                        strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
        //                        strGroupName = ooCost[0].ToString();
        //                        strItemName = ooCost[1].ToString();
        //                        strItemBangla = "";
        //                        strItemDesc = ooCost[2].ToString();
        //                        strGodownName = vstrGodownName;
        //                        dblqty = Utility.Val(ooCost[3].ToString());
        //                        dblRate = Utility.Val(ooCost[4].ToString());
        //                        dblTotalAmount = Utility.Val(ooCost[6].ToString());
        //                        strUOm = ooCost[5].ToString();
        //                        strPer = ooCost[5].ToString();
        //                        dblDiscAmount = Utility.Val(ooCost[7].ToString());
        //                        dblDebitValue = Utility.Val(ooCost[8].ToString());
        //                        if (ooCost[9].ToString() != "")
        //                        {
        //                            if (ooCost[9].ToString() != Utility.gcEND_OF_LIST)
        //                            {
        //                                strBatchNo = ooCost[9].ToString();
        //                            }
        //                            else
        //                            {
        //                                strBatchNo = "";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            strBatchNo = "";
        //                        }

        //                        dblBonusQty = Utility.Val(ooCost[10].ToString());
        //                        strAddLess = ooCost[11].ToString();
        //                        dblCostPrice = Utility.Val(ooCost[13].ToString());
        //                        dblShort = Utility.Val(ooCost[14].ToString());
        //                        intRoundOff = Convert.ToInt32(ooCost[15]);
        //                        dblCommPer = Convert.ToDouble(ooCost[16]);
        //                        if (ooCost[17].ToString() != "")
        //                        {
        //                            strAgnstRefno = ooCost[17].ToString();
        //                        }
        //                        else
        //                        {
        //                            strAgnstRefno = strRefNo;

        //                        }
        //                        //dblAltWhere = 1;
        //                        if (blnMultiCurr)
        //                        {
        //                        }
        //                        else
        //                        {
        //                            strSQL = Voucher.gInsertBillTran(strBillKey, strRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblBonusQty, strUOm, dblRate, dblDebitValue, strAddLess,
        //                                                                dblDiscAmount, dblTotalAmount, "Cr", lngloop, strBranchId, Utility.gstrBaseCurrency, strPer, "", strAgnstRefno,
        //                                                                strBatchNo, strItemDesc, "", strItemBangla, strGroupName, dblShort,dblCommPer);
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }
        //                        strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, strRefNo, strAgnstRefno, mlngVType, strDate,
        //                                                                strItemName, strGodownName, dblqty, strUOm, strBillKey, 0, 0, strPer);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                    }

        //                    lngPosition = lngPosition + 1;
        //                    lngloop += 1;
        //                }

        //            }

        //            dblCredit = dblNetAmount;
        //            //'Insert Accounts Voucher Table
        //            if (intRoundOff > 0)
        //            {
        //                if (dblRoundOff != 0)
        //                {
        //                    strReverseLedger = "As per Details";
        //                }
        //                else
        //                {
        //                    strReverseLedger = strSalesLedger;
        //                }
        //            }
        //            else
        //            {
        //                strReverseLedger = strSalesLedger;
        //            }
        //            mdblCurrRate = 0;
        //            if (mdblCurrRate == 0)
        //            {
        //                if (intRoundOff > 0)
        //                {
        //                    if (dblRoundOff < 0)
        //                    {
        //                        dblCredit = dblCredit - ((Math.Abs(dblRoundOff) + Math.Abs(dblAddAmount)) - Math.Abs(dblLessAmount));
        //                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 1, strLedgerName, "Dr", dblNetAmount, mlngVType, strReverseLedger, strBranchId, 0, "", "", "", "");
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();

        //                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 2, strSalesLedger, "Cr", dblNetAmount - Math.Abs(dblRoundOff), mlngVType, strReverseLedger, strBranchId, 2, "", "", "", "", "", strbatch);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 3, "Round Off", "Cr", Math.Abs(dblRoundOff), mlngVType, strReverseLedger, strBranchId, 2, "-", "", "", "", "", strbatch);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();

        //                    }
        //                    else if (dblRoundOff > 0)
        //                    {
        //                        dblCredit = dblCredit - ((Math.Abs(dblRoundOff) + Math.Abs(dblAddAmount)) - Math.Abs(dblLessAmount));
        //                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 1, strLedgerName, "Cr", dblNetAmount, mlngVType, strReverseLedger, strBranchId, mlngCashFlow, "", "", "", "", "", strbatch);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 2, strSalesLedger, "Dr", dblNetAmount - Math.Abs(dblRoundOff), mlngVType, strReverseLedger, strBranchId, 2, "", "", "", "");
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 3, "Round Off", "Dr", Math.Abs(dblRoundOff), mlngVType, strReverseLedger, strBranchId, 2, "+", "", "", "");
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                    }
        //                    else
        //                    {
        //                        if (mlngIsChqueCash == 0)
        //                        {
        //                            strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 1, strLedgerName, "Dr", dblNetAmount - Math.Abs(dblRoundOff), mlngVType, strReverseLedger, strBranchId, 0, "", "", "", "");
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }
        //                        else
        //                        {
        //                            strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 1, strLedgerName, "Dr", dblNetAmount, mlngVType, strReverseLedger, strBranchId, 0, "", "", "", "");
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }
        //                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 2, strReverseLedger, "Cr", dblCredit, mlngVType, strLedgerName, strBranchId, mlngCashFlow, "", "", "", "", "", strbatch);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();

        //                    }
        //                }
        //                else
        //                {
        //                    if (mlngIsChqueCash == 0)
        //                    {
        //                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 1, strLedgerName, "Dr", dblNetAmount , mlngVType, strReverseLedger, strBranchId, 0, "", "", "", "");
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                    }
        //                    else
        //                    {
        //                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 1, strLedgerName, "Dr", dblNetAmount, mlngVType, strReverseLedger, strBranchId, 0, "", "", "", "");
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                    }
        //                    strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 2, strReverseLedger, "Cr", dblCredit, mlngVType, strLedgerName, strBranchId, mlngCashFlow, "", "", "", "", "", strbatch);
        //                    cmdInsert.CommandText = strSQL;
        //                    cmdInsert.ExecuteNonQuery();

        //                }
                       

        //            }

        //            if (DGAddless != "")
        //            {
        //                lngPosition = 4;
        //                string[] words = DGAddless.Split('~');
        //                foreach (string strAddless in words)
        //                {
        //                    string[] ooCost = strAddless.Split('|');
        //                    if (ooCost[0] != "")
        //                    {
        //                        if (Utility.Val(ooCost[2]) > 0)
        //                        {
        //                            dblAddAmount = Utility.Val(ooCost[2]);
        //                            dblLessAmount = 0;
        //                        }
        //                        else
        //                        {
        //                            dblLessAmount = Utility.Val(ooCost[2]);
        //                            dblAddAmount = 0;
        //                        }
        //                        strSQL = Voucher.gInsertADDLESS(strRefNo, ooCost[0], strDate, dblAddAmount, dblLessAmount, strBranchId);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        if (dblLessAmount > 0)
        //                        {
        //                            strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, lngPosition, ooCost[0], "Dr", dblLessAmount, mlngVType, strSalesLedger, strBranchId, 0, "-", "", "", "");
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                            dblLessAmount = 0;
        //                        }
        //                        else
        //                        {
        //                            if (dblAddAmount != 0)
        //                            {
        //                                strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, lngPosition, ooCost[0], "Cr", dblAddAmount, mlngVType, strLedgerName, strBranchId, 0, "+", "", "", "", "", strbatch);
        //                                cmdInsert.CommandText = strSQL;
        //                                cmdInsert.ExecuteNonQuery();
        //                            }
        //                            dblAddAmount = 0;
        //                        }
        //                        lngPosition += 1;
        //                        blnMultiple = true;
        //                    }
        //                }
        //            }


        //            if (blnMultiple)
        //            {
        //                strSQL = "UPDATE ACC_VOUCHER SET VOUCHER_REVERSE_LEDGER = '" + "As per Details' ";
        //                strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNo + "'";
        //                cmdInsert.CommandText = strSQL;
        //                cmdInsert.ExecuteNonQuery();
        //            }
        //            blnMultiple = false;





        //            if (strRefType != Utility.gcEND_OF_LIST)
        //            {
        //                if (DGsalesOrder != "")
        //                {
        //                    string[] words = DGsalesOrder.Split('~');
        //                    foreach (string strSalesOrder in words)
        //                    {
        //                        string[] ooCost = strSalesOrder.Split('|');
        //                        if (ooCost[0] != "")
        //                        {
        //                            strSQL = "SELECT SUM(BILL_QUANTITY) AS QTY FROM ACC_BILL_TRAN_PROCESS ";
        //                            strSQL = strSQL + "WHERE AGST_COMP_REF_NO = '" + ooCost[0] + "'";
        //                            cmdInsert.CommandText = strSQL;
        //                            rsget = cmdInsert.ExecuteReader();
        //                            if (rsget.Read())
        //                            {

        //                                if (Utility.Val(rsget["QTY"].ToString()) == 0)
        //                                {
        //                                    rsget.Close();
        //                                    strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
        //                                    strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost[0] + "'";
        //                                    cmdInsert.CommandText = strSQL;
        //                                    cmdInsert.ExecuteNonQuery();
        //                                }
        //                                else
        //                                {
        //                                    rsget.Close();
        //                                    strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 0 ";
        //                                    strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost[0] + "'";
        //                                    cmdInsert.CommandText = strSQL;
        //                                    cmdInsert.ExecuteNonQuery();
        //                                }
        //                            }
        //                            else
        //                            {
        //                                rsget.Close();
        //                            }

        //                            strSQL = "INSERT INTO ACC_VOUCHER_JOIN(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID) ";
        //                            strSQL = strSQL + "VALUES(";
        //                            strSQL = strSQL + "'" + strRefNo + "','" + ooCost[0] + "','" + strBranchId + "'";
        //                            strSQL = strSQL + ")";
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }

        //                    }
        //                }
        //            }

        //            if (blngNumberMethod == true)
        //            {
        //                strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
        //                cmdInsert.CommandText = strSQL;
        //                cmdInsert.ExecuteNonQuery();
        //            }
        //            cmdInsert.Transaction.Commit();

        //            gcnMain.Close();
        //            return "Inserted...";

        //        }
        //        catch (Exception ex)
        //        {
        //            return (ex.ToString());
        //        }
        //        finally
        //        {
        //            gcnMain.Close();

        //        }
        //    }
        //}

        //public string mUpdateSalesInvoice(string strDeComID, string mstrRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger, double dblTotalAmnt,
        //                               double dblNetAmount, double dblAddAmount, double dblLessAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirSalesInv, long mlngIsChqueCash, string strNarrations,
        //                               string strBranchId, string vstrGodownName, long lngIsMultiCurrency, string strSalesRep, string DGSalesGrid, string DGVector, string DGBillWise, string DGsalesOrder, string DGAddless,
        //                               bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, string strOrderNo, string strOrderDate, string strPreparedby, string strPreparedDate, double dblProcessAmount, double dblRoundOff)
        //{

        //    string strDRCR = "",  strGroupName, strReverseLedger="";
        //    string strBillKey, strItemName, strItemBangla, strItemDesc, strAddLess, strBatchNo, strUOm, strPer, strGodownName, strbatch = "", strAgnstRefno="";
        //    double dblCredit = 0, dblqty = 0, dblRate, dblTotalAmount, dblDiscAmount, dblDebitValue, dblBonusQty,  dblCostPrice;
        //    long lngloop = 1, lngPosition = 1, mlngCashFlow = 2, lngLedgergroup;
        //    bool blnMultiple = false;
        //    double dblShort = 0, dblCommPer=0;
        //    int intRoundOff = 0;
        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);
        //    lngLedgergroup = (long)(Utility.gGetLedgergroup(strDeComID, strLedgerName));

        //    if (lngLedgergroup <= 101)
        //    {
        //        mlngCashFlow = 1;
        //    }
           
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }

        //        try
        //        {
        //            gcnMain.Open();
        //            SqlDataReader rsget;
        //            SqlCommand cmdInsert = new SqlCommand();
        //            SqlTransaction myTrans;
        //            myTrans = gcnMain.BeginTransaction();
        //            cmdInsert.Connection = gcnMain;
        //            cmdInsert.Transaction = myTrans;

        //            //'All Delete Code Here
        //            strSQL = "DELETE FROM ACC_BILL_TRAN WHERE COMP_REF_NO = '" + mstrRefNo + "' ";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();
        //            strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO = '" + mstrRefNo + "' ";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();
        //            strSQL = "DELETE FROM ACC_VOUCHER WHERE COMP_REF_NO = '" + mstrRefNo + "' ";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();

        //            strSQL = "DELETE FROM ACC_ADD_LESS WHERE ADD_LESS_COMP_REF_NO = '" + mstrRefNo + "'";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();
        //            strSQL = "DELETE FROM ACC_VOUCHER_JOIN WHERE VOUCHER_JOIN_PRIMARY_REF = '" + mstrRefNo + "'";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();

        //            strSQL = "DELETE FROM ACC_BILL_WISE WHERE COMP_REF_NO = '" + mstrRefNo + "'";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();
              

        //            strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO = '" + mstrRefNo + "' ";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();

        //            strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO = '" + mstrRefNo + "'";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();
        //            strSQL = "DELETE FROM VECTOR_TRANSACTION WHERE COMP_REF_NO = '" + mstrRefNo + "'";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();


        //            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET ";
        //            strSQL = strSQL + "LEDGER_NAME = '" + strLedgerName + "',";
        //            strSQL = strSQL + "BRANCH_ID = '" + strBranchId + "',";
        //            strSQL = strSQL + "COMP_VOUCHER_DATE = " + Utility.cvtSQLDateString(strDate) + ",";
        //            strSQL = strSQL + "COMP_VOUCHER_MONTH_ID = '" + strMonthID + "',";
        //            strSQL = strSQL + "COMP_VOUCHER_NARRATION = '" + strNarrations + "',";
        //            strSQL = strSQL + "COMP_VOUCHER_AMOUNT = " + dblTotalAmnt + ",";
        //            strSQL = strSQL + "COMP_VOUCHER_NET_AMOUNT = " + dblNetAmount + ",";
        //            strSQL = strSQL + "COMP_VOUCHER_ADD_AMOUNT = " + dblAddAmount + ",";
        //            strSQL = strSQL + "COMP_VOUCHER_LESS_AMOUNT = " + dblLessAmount + ",";
        //            strSQL = strSQL + "COMP_VOUCHER_DUE_DATE = " + Utility.cvtSQLDateString(strDueDate) + ",";
        //            strSQL = strSQL + "INSERT_DATE = " + Utility.cvtSQLDateString(DateTime.Today.ToString("dd/MM/yyyy"));


        //            if (strSalesRep != Utility.gcEND_OF_LIST)
        //            {
        //                strSQL = strSQL + ",SALES_REP='" + strSalesRep + "' ";
        //            }
        //            else
        //            {

        //                strSQL = strSQL + ",SALES_REP='' ";
        //            }
        //            if (strOrderNo != "")
        //            {
        //                strSQL = strSQL + ",ORDER_NO='" + strOrderNo + "' ";
        //            }
        //            else
        //            {
        //                strSQL = strSQL + ",ORDER_NO=Null";
        //            }
        //            if (strOrderDate != "")
        //            {
        //                strSQL = strSQL + ",ORDER_DATE=" + Utility.cvtSQLDateString(strOrderDate) + " ";
        //            }
        //            else
        //            {
        //                strSQL = strSQL + ",ORDER_DATE=Null";
        //            }
        //            if (strPreparedby != "")
        //            {
        //                strSQL = strSQL + ",PREPARED_BY='" + strPreparedby + "' ";
        //            }
        //            else
        //            {
        //                strSQL = strSQL + ",PREPARED_BY=Null";
        //            }
        //            if (strPreparedDate != "")
        //            {
        //                strSQL = strSQL + ",PREPARED_DATE=" + Utility.cvtSQLDateString(strPreparedDate) + " ";
        //            }
        //            else
        //            {
        //                strSQL = strSQL + ",PREPARED_DATE=Null";
        //            }
        //            strSQL = strSQL + ",COMP_VOUCHER_PROCESS_AMOUNT=" + dblProcessAmount + " ";
        //            strSQL = strSQL + ",COMP_ROUND_OFF_AMOUNT=" + dblRoundOff + " ";
        //            strSQL = strSQL + " WHERE COMP_REF_NO = '" + mstrRefNo + "'";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();


        //            if (DGVector != "")
        //            {
        //                string[] words = DGVector.Split('~');
        //                foreach (string strVector in words)
        //                {
        //                    string[] ooCost = strVector.Split('|');
        //                    if (ooCost[0] != "")
        //                    {
        //                        strSQL = Voucher.mInsertVector(mstrRefNo, ooCost[1].ToString(), ooCost[2].ToString(), strDate, strLedgerName, "Dr", lngPosition, lngPosition, 1, ooCost[0].ToString(), Utility.Val(ooCost[3].ToString()), 0, "", mlngVType);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        strSQL = Voucher.mInsertVector(mstrRefNo, ooCost[1].ToString(), ooCost[2].ToString(), strDate, strLedgerName, "Cr", lngPosition, lngPosition, 2, ooCost[0].ToString(), Utility.Val(ooCost[3].ToString()), 0, "", mlngVType);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        lngPosition += 1;
        //                    }

        //                }
        //            }
        //            lngPosition = 1;
        //            //'If Cash Or Bank Then Should not go in Bill By Bill
        //            if (mlngCashFlow > 1)
        //            {
        //                if (DGBillWise != "")
        //                {
        //                    int intbillpos = 1;
        //                    string strAgstRefNo = "";
        //                    string[] words = DGBillWise.Split('~');
        //                    foreach (string strBill in words)
        //                    {
        //                        string[] ooCost = strBill.Split('|');
        //                        if (ooCost[0] != "")
        //                        {
        //                            strAgstRefNo = strRefNo;
        //                            strSQL = Voucher.gInsertBillWise(strBranchId, mstrRefNo, ooCost[2].ToString(), mlngVType, strLedgerName, intbillpos, ooCost[0].ToString(),
        //                                                                Utility.Val(ooCost[3].ToString()), ooCost[4].ToString(), strAgstRefNo, intbillpos);
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                            intbillpos += 1;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (mlngVType == (long)(Utility.VOUCHER_TYPE.vtSALES_INVOICE))
        //                    {
        //                        strDRCR = "Dr";
        //                    }
        //                    else
        //                    {
        //                        strDRCR = "Cr";
        //                    }

        //                    strSQL = Voucher.gInsertBillWise(strBranchId, mstrRefNo, strDate, mlngVType, strLedgerName, 0, "New Ref", dblNetAmount, strDRCR, Utility.Mid(strRefNo, 6, strRefNo.Length - 6), 0, strDueDate);
        //                    cmdInsert.CommandText = strSQL;
        //                    cmdInsert.ExecuteNonQuery();
        //                }

        //            }

        //            if (DGSalesGrid != "")
        //            {
        //                string[] words = DGSalesGrid.Split('~');
        //                foreach (string strSalesGrid in words)
        //                {
        //                    string[] ooCost = strSalesGrid.Split('|');
        //                    if (ooCost[0] != "")
        //                    {
        //                        strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
        //                        strGroupName = ooCost[0].ToString();
        //                        strItemName = ooCost[1].ToString();
        //                        strItemBangla = "";
        //                        strItemDesc = ooCost[2].ToString();
        //                        strGodownName = vstrGodownName;
        //                        dblqty = Utility.Val(ooCost[3].ToString());
        //                        dblRate = Utility.Val(ooCost[4].ToString());
        //                        dblTotalAmount = Utility.Val(ooCost[6].ToString());
        //                        strUOm = ooCost[5].ToString();
        //                        strPer = ooCost[5].ToString();
        //                        dblDiscAmount = Utility.Val(ooCost[7].ToString());
        //                        dblDebitValue = Utility.Val(ooCost[8].ToString());
        //                        if (ooCost[9].ToString() != "")
        //                        {
        //                            if (ooCost[9].ToString() != Utility.gcEND_OF_LIST)
        //                            {
        //                                strBatchNo = ooCost[9].ToString();
        //                            }
        //                            else
        //                            {
        //                                strBatchNo = "";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            strBatchNo = "";
        //                        }

        //                        dblBonusQty = Utility.Val(ooCost[10].ToString());
        //                        strAddLess = ooCost[11].ToString();
        //                        dblCostPrice = Utility.Val(ooCost[13].ToString());
        //                        dblShort = Utility.Val(ooCost[14].ToString());
        //                        intRoundOff = Convert.ToInt32(ooCost[15]);
        //                        dblCommPer = Convert.ToDouble(ooCost[16]);
        //                        if (ooCost[17].ToString() != "")
        //                        {
        //                            strAgnstRefno = ooCost[17].ToString();
        //                        }
        //                        else
        //                        {
        //                            strAgnstRefno = strRefNo;

        //                        }
        //                        //dblAltWhere = 1;
        //                        if (blnMultiCurr)
        //                        {
        //                        }
        //                        else
        //                        {
        //                            strSQL = Voucher.gInsertBillTran(strBillKey, mstrRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblBonusQty, strUOm, dblRate, dblDebitValue, strAddLess,
        //                                                                dblDiscAmount, dblTotalAmount, "Cr", lngloop, strBranchId, Utility.gstrBaseCurrency, strPer, "", strAgnstRefno,
        //                                                                strBatchNo, strItemDesc, "", strItemBangla, strGroupName, dblShort, dblCommPer);
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }
        //                        strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, mstrRefNo, strAgnstRefno, mlngVType, strDate,
        //                                                                strItemName, strGodownName, dblqty, strUOm, strBillKey, 0, 0, strPer);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();

        //                    }

        //                    lngPosition = lngPosition + 1;
        //                    lngloop += 1;
        //                }
        //            }

        //            dblCredit = dblNetAmount;
        //            //'Insert Accounts Voucher Table

        //            if (intRoundOff > 0)
        //            {
        //                if (dblRoundOff != 0)
        //                {
        //                    strReverseLedger = "As per Details";
        //                }
        //                else
        //                {
        //                    strReverseLedger = strSalesLedger;
        //                }
        //            }
        //            else
        //            {
        //                strReverseLedger = strSalesLedger;
        //            }

        //            if (mdblCurrRate == 0)
        //            {
        //                if (intRoundOff > 0)
        //                {
        //                    if (dblRoundOff < 0)
        //                    {
        //                        dblCredit = dblCredit - ((Math.Abs(dblRoundOff) + Math.Abs(dblAddAmount)) - Math.Abs(dblLessAmount));
        //                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 1, strLedgerName, "Dr", dblNetAmount, mlngVType, strReverseLedger, strBranchId, 0, "", "", "", "");
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();

        //                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 2, strSalesLedger, "Cr", dblNetAmount - Math.Abs(dblRoundOff), mlngVType, strReverseLedger, strBranchId, 2, "", "", "", "", "", strbatch);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 3, "Round Off", "Cr", Math.Abs(dblRoundOff), mlngVType, strReverseLedger, strBranchId, 2, "-", "", "", "", "", strbatch);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();

        //                    }
        //                    else if (dblRoundOff > 0)
        //                    {
        //                        dblCredit = dblCredit - ((Math.Abs(dblRoundOff) + Math.Abs(dblAddAmount)) - Math.Abs(dblLessAmount));

        //                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 1, strLedgerName, "Cr", dblNetAmount, mlngVType, strReverseLedger, strBranchId, mlngCashFlow, "", "", "", "", "", strbatch);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 2, strSalesLedger, "Dr", dblNetAmount - Math.Abs(dblRoundOff), mlngVType, strReverseLedger, strBranchId, 2, "", "", "", "");
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 3, "Round Off", "Dr", Math.Abs(dblRoundOff), mlngVType, strReverseLedger, strBranchId, 2, "+", "", "", "");
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                    }
        //                    else
        //                    {
        //                        if (mlngIsChqueCash == 0)
        //                        {
        //                            strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 1, strLedgerName, "Dr", dblNetAmount - Math.Abs(dblRoundOff), mlngVType, strReverseLedger, strBranchId, 0, "", "", "", "");
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }
        //                        else
        //                        {
        //                            strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 1, strLedgerName, "Dr", dblNetAmount, mlngVType, strReverseLedger, strBranchId, 0, "", "", "", "");
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }
        //                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 2, strReverseLedger, "Cr", dblCredit, mlngVType, strLedgerName, strBranchId, mlngCashFlow, "", "", "", "", "", strbatch);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();

        //                    }
        //                }
        //                else
        //                {
        //                    if (mlngIsChqueCash == 0)
        //                    {
        //                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 1, strLedgerName, "Dr", dblNetAmount, mlngVType, strReverseLedger, strBranchId, 0, "", "", "", "");
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                    }
        //                    else
        //                    {
        //                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 1, strLedgerName, "Dr", dblNetAmount, mlngVType, strReverseLedger, strBranchId, 0, "", "", "", "");
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                    }
        //                    strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 2, strReverseLedger, "Cr", dblCredit, mlngVType, strLedgerName, strBranchId, mlngCashFlow, "", "", "", "", "", strbatch);
        //                    cmdInsert.CommandText = strSQL;
        //                    cmdInsert.ExecuteNonQuery();

        //                }
                       

        //            }
        //            if (DGAddless != "")
        //            {
        //                lngPosition = 4;


        //                string[] words = DGAddless.Split('~');
        //                foreach (string strAddless in words)
        //                {
        //                    string[] ooCost = strAddless.Split('|');
        //                    if (ooCost[0] != "")
        //                    {
        //                        if (Utility.Val(ooCost[2]) > 0)
        //                        {
        //                            dblAddAmount = Utility.Val(ooCost[2]);
        //                            dblLessAmount = 0;
        //                        }
        //                        else
        //                        {
        //                            dblLessAmount = Utility.Val(ooCost[2]);
        //                            dblAddAmount = 0;
        //                        }
        //                        strSQL = Voucher.gInsertADDLESS(mstrRefNo, ooCost[0], strDate, dblAddAmount, dblLessAmount, strBranchId);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                        if (dblLessAmount > 0)
        //                        {
        //                            strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, lngPosition, ooCost[0], "Dr", dblLessAmount, mlngVType, strSalesLedger, strBranchId, 0, "-", "", "", "");
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                            dblLessAmount = 0;
        //                        }
        //                        else
        //                        {
        //                            if (dblAddAmount != 0)
        //                            {
        //                                strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, lngPosition, ooCost[0], "Cr", dblAddAmount, mlngVType, strLedgerName, strBranchId, 0, "+", "", "", "", "", strbatch);
        //                                cmdInsert.CommandText = strSQL;
        //                                cmdInsert.ExecuteNonQuery();
        //                            }
        //                            dblAddAmount = 0;
        //                        }
        //                        lngPosition += 1;
        //                        blnMultiple = true;
        //                    }
        //                }
        //            }


        //            if (blnMultiple)
        //            {
        //                strSQL = "UPDATE ACC_VOUCHER SET VOUCHER_REVERSE_LEDGER = '" + "As per Details' ";
        //                strSQL = strSQL + "WHERE COMP_REF_NO = '" + mstrRefNo + "'";
        //                cmdInsert.CommandText = strSQL;
        //                cmdInsert.ExecuteNonQuery();
        //            }
        //            blnMultiple = false;
                   
        //            if (strRefType != Utility.gcEND_OF_LIST)
        //            {
        //                if (DGsalesOrder != "")
        //                {
        //                    string[] words = DGsalesOrder.Split('~');
        //                    foreach (string strSalesOrder in words)
        //                    {
        //                        string[] ooCost = strSalesOrder.Split('|');
        //                        if (ooCost[0] != "")
        //                        {
        //                            strSQL = "SELECT SUM(BILL_QUANTITY) AS QTY FROM ACC_BILL_TRAN_PROCESS ";
        //                            strSQL = strSQL + "WHERE AGST_COMP_REF_NO = '" + ooCost[0] + "'";
        //                            cmdInsert.CommandText = strSQL;
        //                            rsget = cmdInsert.ExecuteReader();
        //                            if (rsget.Read())
        //                            {

        //                                if (Utility.Val(rsget["QTY"].ToString()) == 0)
        //                                {
        //                                    rsget.Close();
        //                                    strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
        //                                    strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost[0] + "'";
        //                                    cmdInsert.CommandText = strSQL;
        //                                    cmdInsert.ExecuteNonQuery();
        //                                }
        //                                else
        //                                {
        //                                    rsget.Close();
        //                                    strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 0 ";
        //                                    strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost[0] + "'";
        //                                    cmdInsert.CommandText = strSQL;
        //                                    cmdInsert.ExecuteNonQuery();
        //                                }
        //                            }
        //                            else
        //                            {
        //                                rsget.Close();
        //                            }

        //                            strSQL = "INSERT INTO ACC_VOUCHER_JOIN(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID) ";
        //                            strSQL = strSQL + "VALUES(";
        //                            strSQL = strSQL + "'" + mstrRefNo + "','" + ooCost[0] + "','" + strBranchId + "'";
        //                            strSQL = strSQL + ")";
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }

        //                    }
        //                }
        //            }

        //            cmdInsert.Transaction.Commit();

        //            gcnMain.Close();
        //            return "Updated...";

        //        }
        //        catch (Exception ex)
        //        {
        //            return (ex.ToString());
        //        }
        //        finally
        //        {
        //            gcnMain.Close();

        //        }
        //    }
        //}
        #endregion
        #region "Sales Challan"
        public string mUpdateCosting(string strDeComID, string DGSalesGrid, string strDate)
        {

            string strBillKey, strItemName;
            double dblqty = 0, dblRate;
            long lngloop = 1;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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
                    //SqlTransaction myTrans;
                    //myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    //cmdInsert.Transaction = myTrans;


                    if (DGSalesGrid != "")
                    {

                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split(',');
                            if (ooCost[0] != "")
                            {

                                strItemName = ooCost[0].ToString();
                                dblRate = Utility.gdblGetCostPrice(strDeComID, strItemName, strDate);

                                //strSQL = "UPDATE INV_TRAN SET ";
                                //strSQL = strSQL + "OUTWARD_SALES_AMOUNT= " + (dblqty) * dblRate * -1 + " ";
                                //strSQL = strSQL + " where INV_TRAN_KEY='" + strBillKey + "' ";
                                //cmdInsert.CommandText = strSQL;
                                //cmdInsert.ExecuteNonQuery();


                                lngloop += 1;
                            }
                        }
                    }
                    return "1";
                }


                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }

        //public string mSaveSalesChallan(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
        //                              double dblNetAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirSalesInv, string strNarrations,
        //                              string strBranchId, string vstrGodownName, string DGSalesGrid, string DGsalesOrder, bool mblnNumberMethod,
        //                              string strCustomer, string strDesignation, string strTransport, double dblcrtQty, double dblBox, string strTrNo)
        //{

        //    string strDRCR = "";
        //    string strBillKey, strItemName, strItemBangla, strAddLess, strAgnstKey = "", strAgnsrRefNo = "", strUOm, strPer, strGodownName, strbatch = "";
        //    double dblqty = 0, dblRate, dblTotalAmount, dblBonusQty, dblAltWhere, dblTotalCost = 1, dblCostPrice;
        //    long lngloop = 1;

        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }

        //        try
        //        {
        //            gcnMain.Open();

        //            if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
        //            {
        //                strDRCR = "Cr";
        //            }
        //            else if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtPURCHASE_RECEIVE)
        //            {
        //                strDRCR = "Dr";
        //            }
        //            SqlDataReader rsget;
        //            SqlCommand cmdInsert = new SqlCommand();
        //            SqlTransaction myTrans;
        //            myTrans = gcnMain.BeginTransaction();
        //            cmdInsert.Connection = gcnMain;
        //            cmdInsert.Transaction = myTrans;


        //            strSQL = Voucher.gInsertCompanyVoucher(strRefNo, mlngVType, strDate, strMonthID, strDueDate, strLedgerName, dblNetAmount, dblNetAmount, 0, 0, lngAgstRef, strNarrations,
        //                                                strBranchId, 0, "", strCustomer, "", "", "", "", strTrNo, "", "", "", "", strDesignation, strTransport, dblcrtQty, dblBox);

        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();

        //            strSQL = Voucher.gInteractInvInsertMaster(strLedgerName, strRefNo, mlngVType, strDate, strBranchId, strNarrations);
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();


        //            if (DGSalesGrid != "")
        //            {

        //                string[] words = DGSalesGrid.Split('~');
        //                foreach (string strSalesGrid in words)
        //                {
        //                    string[] ooCost = strSalesGrid.Split('|');
        //                    if (ooCost[0] != "")
        //                    {
        //                        strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
        //                        strItemName = ooCost[0].ToString();
        //                        dblCostPrice = Utility.Val(ooCost[6]);
        //                        //strItemBangla = Utility.gGetItemNameBangla (ooCost[1].ToString());
        //                        strItemBangla = "";
        //                        //trItemDesc = ooCost[1].ToString();
        //                        strGodownName = vstrGodownName;
        //                        dblqty = Utility.Val(ooCost[1].ToString());
        //                        dblRate = Utility.Val(ooCost[2].ToString());
        //                        dblTotalAmount = Utility.Val(ooCost[4].ToString());
        //                        strUOm = ooCost[3].ToString();
        //                        strPer = ooCost[3].ToString();
        //                        if (ooCost[5].ToString() != "")
        //                        {
        //                            strbatch = ooCost[5].ToString();
        //                        }
        //                        else
        //                        {
        //                            strbatch = "";
        //                        }
        //                        strAgnstKey = ooCost[7].ToString();
        //                        strAgnsrRefNo = ooCost[8].ToString();

        //                        dblBonusQty = Utility.Val(ooCost[9].ToString());
        //                        strAddLess = "";
        //                        dblAltWhere = 1;

        //                        strSQL = Voucher.gInsertBillTran(strBillKey, strRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblBonusQty, strUOm, dblRate, dblTotalAmount, strAddLess,
        //                                                            0, dblTotalAmount, strDRCR, lngloop, strBranchId, Utility.gstrBaseCurrency, strPer, "", "", strbatch, "", "", strItemBangla);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();

        //                        strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, strRefNo, strRefNo, mlngVType, strDate,
        //                                                                strItemName, strGodownName, dblqty, strUOm, strAgnstKey, 0, 0, strPer);
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();

        //                        if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
        //                        {
        //                            strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, strRefNo, strAgnsrRefNo, lngAgstRef, strDate,
        //                                                                    strItemName, strGodownName, dblqty * -1, strUOm, strAgnsrRefNo, 0, 0, strPer);
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }

        //                        if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
        //                        {
        //                            strSQL = Voucher.gInventoryInsertTranSalesChallan(strRefNo, strBillKey, lngloop, Math.Round(dblRate, 2), -1 * dblTotalCost, lngAgstRef, strItemName, strGodownName,
        //                                                                        "O", dblqty * -1, dblBonusQty * -1, dblCostPrice, mlngVType, strDate, strBranchId, strbatch, 0, strPer, strUOm);
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }
        //                        else if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
        //                        {
        //                            strSQL = Voucher.gInventoryInsertTranSalesChallanClass(strRefNo, strBillKey, lngloop, Math.Round(dblRate, 2), -1 * dblTotalCost, lngAgstRef, strItemName, strGodownName,
        //                                                                        "O", dblqty * -1, dblBonusQty * -1, dblCostPrice, mlngVType, strDate, strBranchId, strbatch, 0, strPer, strUOm);
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }
        //                        else
        //                        {
        //                            strSQL = Voucher.gInventoryInsertTranSalesChallan(strRefNo, strBillKey, lngloop, Math.Round(dblRate / dblAltWhere, 2), -1 * dblTotalCost, lngAgstRef, strItemName,
        //                                                                        strGodownName, "O", dblqty * -1, dblBonusQty * -1, dblCostPrice, mlngVType, strDate, strBranchId, strbatch, 0, strPer, strUOm);
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }
        //                        if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
        //                        {
        //                            strSQL = "UPDATE INV_TRAN SET ";
        //                            strSQL = strSQL + "OUTWARD_SALES_AMOUNT= 0 ";
        //                            strSQL = strSQL + ",INV_TRAN_RATE= 0 ";
        //                            //strSQL = strSQL + ",OUTWARD_COST_AMOUNT= 0 ";
        //                            // strSQL = strSQL + ",INV_TRAN_AMOUNT= 0 ";
        //                            strSQL = strSQL + " WHERE INV_TRAN_KEY='" + strBillKey + "' ";
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }
        //                        else
        //                        {
        //                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
        //                            strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNo + "'";
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }

        //                        lngloop += 1;
        //                    }
        //                }
        //                if (strRefType != "Sample Class")
        //                {
        //                    if (strRefType != Utility.gcEND_OF_LIST)
        //                    {
        //                        if (DGsalesOrder != "")
        //                        {
        //                            string[] words1 = DGsalesOrder.Split('~');
        //                            foreach (string strSalesOrder in words1)
        //                            {
        //                                string[] ooCost1 = strSalesOrder.Split('|');
        //                                if (ooCost1[0] != "")
        //                                {
        //                                    strSQL = "SELECT SUM(BILL_QUANTITY) AS QTY FROM ACC_BILL_TRAN_PROCESS ";
        //                                    strSQL = strSQL + "WHERE AGST_COMP_REF_NO = '" + ooCost1[0] + "'";
        //                                    cmdInsert.CommandText = strSQL;
        //                                    rsget = cmdInsert.ExecuteReader();
        //                                    if (rsget.Read())
        //                                    {

        //                                        if (Utility.Val(rsget["QTY"].ToString()) == 0)
        //                                        {
        //                                            rsget.Close();
        //                                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
        //                                            strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost1[0] + "'";
        //                                            cmdInsert.CommandText = strSQL;
        //                                            cmdInsert.ExecuteNonQuery();
        //                                        }
        //                                        else
        //                                        {
        //                                            rsget.Close();
        //                                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
        //                                            strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost1[0] + "'";
        //                                            cmdInsert.CommandText = strSQL;
        //                                            cmdInsert.ExecuteNonQuery();
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        rsget.Close();
        //                                    }

        //                                    strSQL = "INSERT INTO ACC_VOUCHER_JOIN(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID) ";
        //                                    strSQL = strSQL + "VALUES(";
        //                                    strSQL = strSQL + "'" + strRefNo + "','" + ooCost1[0] + "','" + strBranchId + "'";
        //                                    strSQL = strSQL + ")";
        //                                    cmdInsert.CommandText = strSQL;
        //                                    cmdInsert.ExecuteNonQuery();
        //                                }
        //                            }

        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (DGsalesOrder != "")
        //                    {
        //                        string[] words1 = DGsalesOrder.Split('~');
        //                        foreach (string strSalesOrder in words1)
        //                        {
        //                            string[] ooCost1 = strSalesOrder.Split('|');
        //                            if (ooCost1[0] != "")
        //                            {
        //                                strSQL = "SELECT SUM(BILL_QUANTITY) AS QTY FROM ACC_BILL_TRAN_PROCESS ";
        //                                strSQL = strSQL + "WHERE AGST_COMP_REF_NO = '" + ooCost1[0] + "'";
        //                                cmdInsert.CommandText = strSQL;
        //                                rsget = cmdInsert.ExecuteReader();
        //                                if (rsget.Read())
        //                                {

        //                                    if (Utility.Val(rsget["QTY"].ToString()) == 0)
        //                                    {
        //                                        rsget.Close();
        //                                        strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
        //                                        strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost1[0] + "'";
        //                                        cmdInsert.CommandText = strSQL;
        //                                        cmdInsert.ExecuteNonQuery();
        //                                    }
        //                                    else
        //                                    {
        //                                        rsget.Close();
        //                                        strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
        //                                        strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost1[0] + "'";
        //                                        cmdInsert.CommandText = strSQL;
        //                                        cmdInsert.ExecuteNonQuery();
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    rsget.Close();
        //                                }

        //                                strSQL = "INSERT INTO ACC_VOUCHER_JOIN_CLASS(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID,CLASS_NAME) ";
        //                                strSQL = strSQL + "VALUES(";
        //                                strSQL = strSQL + "'" + strRefNo + "','" + strRefNo + "','" + strBranchId + "','" + "SC" + strBranchId + ooCost1[0] + "' ";
        //                                strSQL = strSQL + ")";
        //                                cmdInsert.CommandText = strSQL;
        //                                cmdInsert.ExecuteNonQuery();

        //                                strSQL = "UPDATE ACC_BILL_TRAN SET AGNST_COMP_REF_NO = '" + ooCost1[0] + "'";
        //                                strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNo + "'";
        //                                cmdInsert.CommandText = strSQL;
        //                                cmdInsert.ExecuteNonQuery();
        //                                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_NARRATION = 'Sample Class'";
        //                                strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNo + "'";
        //                                cmdInsert.CommandText = strSQL;
        //                                cmdInsert.ExecuteNonQuery();
        //                            }
        //                        }
        //                    }
        //                }
        //            }



        //            if (mblnNumberMethod == true)
        //            {
        //                strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
        //                cmdInsert.CommandText = strSQL;
        //                cmdInsert.ExecuteNonQuery();
        //            }
        //            cmdInsert.Transaction.Commit();
        //            gcnMain.Close();
        //            //string g = mUpdateCosting(strDeComID, DGSalesGrid, strDate);
        //            return "Inserted...";



        //        }
        //        catch (Exception ex)
        //        {
        //            return (ex.ToString());
        //        }
        //        finally
        //        {
        //            gcnMain.Close();

        //        }
        //    }
        //}
        //public string mUpdateSalesChallan(string strDeComID, string mstRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
        //                             double dblNetAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirSalesInv, string strNarrations,
        //                             string strBranchId, string vstrGodownName, string DGSalesGrid, string DGsalesOrder,
        //                                string strCustomer, string strDesignation, string strTransport, double dblcrtQty, double dblBox, string strTrNo)
        //{


        //    string strDRCR = "";
          
        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);
        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }

        //        try
        //        {
        //            gcnMain.Open();

        //            if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
        //            {
        //                strDRCR = "Cr";
        //            }
        //            else if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtPURCHASE_RECEIVE)
        //            {
        //                strDRCR = "Dr";
        //            }
        //            else
        //            {
        //                strDRCR = "";
        //            }
                   

                 

        //            SqlCommand cmdInsert = new SqlCommand();
        //            SqlTransaction myTrans;
        //            myTrans = gcnMain.BeginTransaction();
        //            cmdInsert.Connection = gcnMain;
        //            cmdInsert.Transaction = myTrans;

        //            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET ";
        //            strSQL = strSQL + "LEDGER_NAME = '" + strLedgerName + "',";
        //            strSQL = strSQL + "BRANCH_ID = '" + strBranchId + "',";
        //            strSQL = strSQL + "COMP_VOUCHER_DATE = " + Utility.cvtSQLDateString(strDate) + ",";
        //            strSQL = strSQL + "COMP_VOUCHER_MONTH_ID = '" + strMonthID + "',";
        //            strSQL = strSQL + "COMP_VOUCHER_NARRATION = '" + strNarrations + "',";
        //            strSQL = strSQL + "COMP_VOUCHER_DUE_DATE = " + Utility.cvtSQLDateString(strDueDate) + ",";
        //            strSQL = strSQL + "COMP_VOUCHER_NET_AMOUNT = " + dblNetAmount + ",";
        //            strSQL = strSQL + "COMP_VOUCHER_AMOUNT = " + dblNetAmount + " ";
        //            if (strDesignation != "")
        //            {
        //                strSQL = strSQL + ",COMP_VOUCHER_DESTINATION = '" + strDesignation + "'";
        //            }
        //            //else
        //            //{
        //            //    strSQL = strSQL + ",COMP_VOUCHER_DESTINATION = ''";
        //            //}

        //            if (strTransport != "")
        //            {
        //                strSQL = strSQL + ",TRANSPORT_NAME = '" + strTransport + "'";
        //            }
        //            //else
        //            //{
        //            //    strSQL = strSQL + ",TRANSPORT_NAME = 'Null'";
        //            //}
        //            strSQL = strSQL + ",CRT_QTY = " + dblcrtQty + "";
        //            strSQL = strSQL + ",BOX_QTY = " + dblBox + "";
        //            strSQL = strSQL + ",COMP_OTHERS = '" + strTrNo + "' ";

        //            strSQL = strSQL + "WHERE COMP_REF_NO = '" + mstRefNo + "' ";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();

        //            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
        //            strSQL = strSQL + "WHERE COMP_REF_NO = '" + mstRefNo + "'";
        //            cmdInsert.CommandText = strSQL;
        //            cmdInsert.ExecuteNonQuery();

        //            #region "Comment"
        //            //strSQL = Voucher.gInteractInvInsertMaster(strLedgerName, mstRefNo, mlngVType, strDate, strBranchId, strNarrations);
        //            //cmdInsert.CommandText = strSQL;
        //            //cmdInsert.ExecuteNonQuery();


        //            //if (DGSalesGrid != "")
        //            //{

        //            //    string[] words = DGSalesGrid.Split('~');
        //            //    foreach (string strSalesGrid in words)
        //            //    {
        //            //        string[] ooCost = strSalesGrid.Split('|');
        //            //        if (ooCost[0] != "")
        //            //        {
        //            //            strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
        //            //            strItemName = ooCost[0].ToString();
        //            //            //dblCostPrice = Utility.gdblGetCostPrice(strItemName, strDate);
        //            //            dblCostPrice = Utility.Val(ooCost[6].ToString());
        //            //            //strItemBangla = Utility.gGetItemNameBangla (ooCost[1].ToString());
        //            //            strItemBangla = "";
        //            //            //trItemDesc = ooCost[1].ToString();
        //            //            strGodownName = vstrGodownName;
        //            //            dblqty = Utility.Val(ooCost[1].ToString());
        //            //            dblRate = Utility.Val(ooCost[2].ToString());
        //            //            dblTotalAmount = Utility.Val(ooCost[4].ToString());
        //            //            strUOm = ooCost[3].ToString();
        //            //            strPer = ooCost[3].ToString();
        //            //            if (ooCost[5].ToString() != "")
        //            //            {
        //            //                strbatch = ooCost[5].ToString();
        //            //            }
        //            //            else
        //            //            {
        //            //                strbatch = "";
        //            //            }
        //            //            strAgnstKey = ooCost[7].ToString();
        //            //            strAgnsrRefNo = ooCost[8].ToString();

        //            //            dblBonusQty = 0;
        //            //            strAddLess = "";
        //            //            dblAltWhere = 1;
        //            //            //If InStr(1, .TextMatrix(lngloop, 3), strPer) = 0 Then
        //            //            //    dblAltWhere = gdblDenomation(Replace$(.TextMatrix(lngloop, 1), "'", "''"))
        //            //            //End If

        //            //            strSQL = Voucher.gInsertBillTran(strBillKey, mstRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblBonusQty, strUOm, dblRate, dblTotalAmount, strAddLess,
        //            //                                                0, dblTotalAmount, strDRCR, lngloop, strBranchId, Utility.gstrBaseCurrency, strPer, "", "", strbatch, "", "", strItemBangla);
        //            //            cmdInsert.CommandText = strSQL;
        //            //            cmdInsert.ExecuteNonQuery();

        //            //            strSQL = Voucher.gInsertBillTranProcess(strRefNo + lngloop.ToString().PadLeft(4, '0'), strBranchId, lngloop, strRefNo, strRefNo, mlngVType, strDate,
        //            //                                                 strItemName, strGodownName, dblqty, strUOm, (strRefNo + lngloop.ToString().PadLeft(4, '0')), 0, 0, strPer);
        //            //            cmdInsert.CommandText = strSQL;
        //            //            cmdInsert.ExecuteNonQuery();

        //            //            if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
        //            //            {
        //            //                strSQL = Voucher.gInsertBillTranProcess(strRefNo + lngloop.ToString().PadLeft(4, '0'), strBranchId, lngloop, strRefNo, strAgnsrRefNo, lngAgstRef, strDate,
        //            //                                                        strItemName, strGodownName, dblqty * -1, strUOm, strAgnstKey, 0, 0, strPer);
        //            //                cmdInsert.CommandText = strSQL;
        //            //                cmdInsert.ExecuteNonQuery();
        //            //            }

        //            //            //if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
        //            //            //{
        //            //            if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
        //            //            {
        //            //                strSQL = Voucher.gInventoryInsertTranSales(mstRefNo, strRefNo + lngloop.ToString().PadLeft(4, '0'), lngloop, Math.Round(dblRate, 2), -1 * dblTotalCost, lngAgstRef, strItemName, strGodownName,
        //            //                                                            "O", dblqty * -1, dblBonusQty * -1, dblCostPrice, mlngVType, strDate, strBranchId, strbatch, 0, strPer, strUOm, 0);
        //            //                cmdInsert.CommandText = strSQL;
        //            //                cmdInsert.ExecuteNonQuery();
        //            //            }
        //            //            else
        //            //            {
        //            //                strSQL = Voucher.gInventoryInsertTranSales(mstRefNo, strRefNo + lngloop.ToString().PadLeft(4, '0'), lngloop, Math.Round(dblRate / dblAltWhere, 2), -1 * dblTotalCost, lngAgstRef, strItemName,
        //            //                                                            strGodownName, "O", dblqty * -1, dblBonusQty * -1, dblCostPrice, mlngVType, strDate, strBranchId, strbatch, 0, strPer, strUOm, 0);
        //            //                cmdInsert.CommandText = strSQL;
        //            //                cmdInsert.ExecuteNonQuery();
        //            //            }
        //            //}
        //            //else if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtPURCHASE_RECEIVE)
        //            //{
        //            //    strSQL = Voucher.gInventoryInsertTranSales(strRefNo, strRefNo + lngloop.ToString().PadLeft(4, '0'), lngloop, Math.Round(dblRate, 2), dblTotalCost, lngAgstRef, strItemName, strGodownName,
        //            //                                                    "I", dblqty, dblBonusQty, dblCostPrice, mlngVType, strDate, strBranchId, strbatch, 0, strPer, strUOm, 0);
        //            //    cmdInsert.CommandText = strSQL;
        //            //    cmdInsert.ExecuteNonQuery();
        //            //    strSQL = Voucher.gInventoryInsertTranSales(strRefNo, strRefNo + lngloop.ToString().PadLeft(4, '0'), lngloop, Math.Round(dblRate / dblAltWhere, 2), dblTotalCost, lngAgstRef, strItemName,
        //            //                                                   strGodownName, "I", dblqty, dblBonusQty, dblCostPrice, mlngVType, strDate, strBranchId, strbatch, 0, strPer, strUOm, 0);
        //            //    cmdInsert.CommandText = strSQL;
        //            //    cmdInsert.ExecuteNonQuery();
        //            //}
        //            //        lngloop += 1;
        //            //    }
        //            //}

        //            //if (strRefType != "Sample Class")
        //            //{
        //            //if (strRefType != Utility.gcEND_OF_LIST)
        //            //{
        //            //    if (DGsalesOrder != "")
        //            //    {
        //            //        string[] words1 = DGsalesOrder.Split('~');
        //            //        foreach (string strSalesOrder in words1)
        //            //        {
        //            //            string[] ooCost1 = strSalesOrder.Split('|');
        //            //            if (ooCost1[0] != "")
        //            //            {
        //            //                strSQL = "SELECT SUM(BILL_QUANTITY) AS QTY FROM ACC_BILL_TRAN_PROCESS ";
        //            //                strSQL = strSQL + "WHERE AGST_COMP_REF_NO = '" + ooCost1[0] + "'";
        //            //                cmdInsert.CommandText = strSQL;
        //            //                rsget = cmdInsert.ExecuteReader();
        //            //                if (rsget.Read())
        //            //                {

        //            //                    if (Utility.Val(rsget["QTY"].ToString()) == 0)
        //            //                    {
        //            //                        rsget.Close();
        //            //                        strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
        //            //                        strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost1[1] + "'";
        //            //                        cmdInsert.CommandText = strSQL;
        //            //                        cmdInsert.ExecuteNonQuery();
        //            //                    }
        //            //                    else
        //            //                    {
        //            //                        rsget.Close();
        //            //                        strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 0 ";
        //            //                        strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost1[1] + "'";
        //            //                        cmdInsert.CommandText = strSQL;
        //            //                        cmdInsert.ExecuteNonQuery();
        //            //                    }
        //            //                }
        //            //                else
        //            //                {
        //            //                    rsget.Close();
        //            //                }

        //            //                strSQL = "INSERT INTO ACC_VOUCHER_JOIN(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID) ";
        //            //                strSQL = strSQL + "VALUES(";
        //            //                strSQL = strSQL + "'" + strRefNo + "','" + ooCost1[0] + "','" + strBranchId + "'";
        //            //                strSQL = strSQL + ")";
        //            //                cmdInsert.CommandText = strSQL;
        //            //                cmdInsert.ExecuteNonQuery();
        //            //            }
        //            //        }

        //            //    }
        //            //}
        //            //}

        //            //}
        //            //}
        //            #endregion
        //            cmdInsert.Transaction.Commit();
        //            //}


        //            gcnMain.Close();
        //            return "Updated...";
        //        }
        //        catch (Exception ex)
        //        {
        //            return (ex.ToString());
        //        }
        //        finally
        //        {
        //            gcnMain.Close();

        //        }
        //    }
        //}

        #endregion
        #region "Process"
        public string mDeleteProcess(string strDeComID, string vstrProcess)
        {

            string strSQL, strReturn = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();

                    vstrProcess = vstrProcess.Replace("'", "''");

                    SqlDataReader rsGet;
                    SqlCommand cmdDelete = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdDelete.Connection = gcnMain;
                    cmdDelete.Transaction = myTrans;
                    strSQL = "SELECT PROCESS_NAME FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE PROCESS_NAME = '" + vstrProcess + "' ";
                    cmdDelete.CommandText = strSQL;
                    rsGet = cmdDelete.ExecuteReader();
                    if (rsGet.Read())
                    {
                        strReturn = "Cannot remove this Porcess. Data exists in different voucher.";
                        return strReturn;
                    }
                    rsGet.Close();
                    strSQL = "DELETE FROM INV_MANU_PROCESS WHERE PROCESS_NAME='" + vstrProcess + "' ";
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    strSQL = "DELETE FROM INV_MENU_PROCESS_MAIN WHERE PROCESS_NAME='" + vstrProcess + "' ";
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mInsertProcess(string strDeComID, string oldvstrProcess, string vstrProcess, string Dgfg, string DgRm,
                                    string Dgwastage, int actionmode, int intConvertType, int intTransferType, string strbranchID,string strLocation)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();

                    vstrProcess = vstrProcess.Replace("'", "''");

                    SqlDataReader dr;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    if (actionmode == 2)
                    {
                        strSQL = "DELETE FROM INV_MANU_PROCESS WHERE PROCESS_NAME='" + oldvstrProcess + "' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "SELECT INV_LOG_PROCESS_NAME FROM INV_PRODUCTION_LOG WHERE INV_LOG_PROCESS_NAME='" + oldvstrProcess + "' ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (!dr.Read())
                        {
                            dr.Close();
                            strSQL = "DELETE FROM INV_MENU_PROCESS_MAIN WHERE PROCESS_NAME='" + oldvstrProcess + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();

                            strSQL = "INSERT INTO INV_MENU_PROCESS_MAIN (PROCESS_NAME,CONVERT_Y_N,TRANSFER_TYPE,BRANCH_ID) VALUES ('" + vstrProcess + "'," + " " + intConvertType + "," + intTransferType + ",'"+ strbranchID+"')";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        dr.Close();
                        
                    }
                    else
                    {

                        strSQL = "INSERT INTO INV_MENU_PROCESS_MAIN (PROCESS_NAME,CONVERT_Y_N,TRANSFER_TYPE,BRANCH_ID) VALUES ('" + vstrProcess + "'," + " " + intConvertType + "," + intTransferType + ",'" + strbranchID + "')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    if (DgRm != "")
                    {
                        string strItemName = "", strATL = "", strUOm = "";
                        double dblQnty = 0;
                        long lngloop = 1, lngType = 1;
                        string[] words = DgRm.Split('~');
                        foreach (string strRm in words)
                        {
                            string[] ooCost = strRm.Split('|');
                            if (ooCost[0] != "")
                            {
                                strItemName = ooCost[0].ToString();
                                dblQnty = Utility.Val(ooCost[1].ToString());
                                strATL = ooCost[2].ToString();
                                strUOm = ooCost[2].ToString();
                                strSQL = "INSERT INTO INV_MANU_PROCESS(PROCESS_NAME,STOCKITEM_NAME, ";
                                strSQL = strSQL + "PROCESS_POSITION,PROCESS_QUANTITY,PROCESS_UNIT,INV_PER,PROCESS_TYPE,GODOWNS_NAME) VALUES (";
                                strSQL = strSQL + "'" + vstrProcess + "','" + strItemName.Replace("'","''") + "'," + lngloop + ",";
                                strSQL = strSQL + "" + dblQnty + ",'" + strUOm + "','" + strATL + "'," + lngType + ",'" + strLocation.Replace("'", "''") + "')";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lngloop += 1;
                            }

                        }
                    }

                    if (Dgwastage != "")
                    {
                        string strItemName = "", strATL = "", strUOm = "";
                        double dblQnty = 0;
                        long lngloop = 1, lngType = 3;
                        string[] words = Dgwastage.Split('~');
                        foreach (string strW in words)
                        {
                            string[] ooCost = strW.Split('|');
                            if (ooCost[0] != "")
                            {
                                strItemName = ooCost[0].ToString();
                                dblQnty = Utility.Val(ooCost[1].ToString());
                                strATL = ooCost[2].ToString();
                                strUOm = ooCost[2].ToString();
                                strSQL = "INSERT INTO INV_MANU_PROCESS(PROCESS_NAME,STOCKITEM_NAME, ";
                                strSQL = strSQL + "PROCESS_POSITION,PROCESS_QUANTITY,PROCESS_UNIT,INV_PER,PROCESS_TYPE,GODOWNS_NAME) VALUES (";
                                strSQL = strSQL + "'" + vstrProcess + "','" + strItemName.Replace("'", "''") + "'," + lngloop + ",";
                                strSQL = strSQL + "" + dblQnty + ",'" + strUOm + "','" + strATL + "'," + lngType + ",'" + strLocation.Replace("'", "''") + "')";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lngloop += 1;
                            }

                        }
                    }
                    if (Dgfg != "")
                    {
                        string strItemName = "", strATL = "", strUOm = "";
                        double dblQnty = 0, dblPercent = 0;
                        long lngloop = 1, lngType = 2;
                        string[] words = Dgfg.Split('~');
                        foreach (string strFg in words)
                        {
                            string[] ooCost = strFg.Split('|');
                            if (ooCost[0] != "")
                            {
                                strItemName = ooCost[0].ToString();
                                dblQnty = Utility.Val(ooCost[1].ToString());
                                strATL = ooCost[2].ToString();
                                strUOm = ooCost[2].ToString();
                                dblPercent = Utility.Val(ooCost[3].ToString());
                                strSQL = "INSERT INTO INV_MANU_PROCESS (PROCESS_NAME,STOCKITEM_NAME, ";
                                strSQL = strSQL + "PROCESS_POSITION,PROCESS_QUANTITY,PROCESS_UNIT,INV_PER,PROCESS_TYPE,FG_COST_PERCENT,GODOWNS_NAME) VALUES (";
                                strSQL = strSQL + "'" + vstrProcess + "','" + strItemName.Replace("'", "''") + "'," + lngloop + ",";
                                strSQL = strSQL + "" + dblQnty + ",'" + strUOm + "','" + strATL + "'," + lngType + "," + dblPercent + ",'" + strLocation.Replace("'", "''") + "')";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lngloop += 1;
                            }

                        }
                    }



                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        public List<ManuProcess> mLoadProduction(string strDeComID, string Pyear, int intStatus)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ManuProcess> oogrp = new List<ManuProcess>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT INV_REF_NO_IN,INV_LOG_DATE FROM INV_PRODUCTION_LOG ";
            strSQL = strSQL + " WHERE CONVERTTYPE =" + intStatus + " ";
            strSQL = strSQL + " AND year(INV_LOG_DATE) = '" + Pyear + "' ";

            strSQL = strSQL + " ORDER BY INV_REF_NO_IN ";
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
                    ManuProcess ogrp = new ManuProcess();
                    ogrp.strProcessName = Utility.Mid(drGetGroup["INV_REF_NO_IN"].ToString(), 6, drGetGroup["INV_REF_NO_IN"].ToString().Length - 6);
                    ogrp.strEntryDate = Convert.ToDateTime(drGetGroup["INV_LOG_DATE"]).ToString("dd/MM/yyyy");
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }

        public List<ManuProcess> mLoadProcess(string strDeComID, string Pyear, string vstrProcessName, int intStatus,int intTransfer)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ManuProcess> oogrp = new List<ManuProcess>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT * FROM INV_MENU_PROCESS_MAIN ";
            strSQL = strSQL + " WHERE CONVERT_Y_N =" + intStatus + " ";
            strSQL = strSQL + " AND TRANSFER_TYPE = " + intTransfer + " ";
            if (vstrProcessName != "")
            {
                strSQL = strSQL + " AND PROCESS_NAME LIKE '%" + vstrProcessName + "%' ";
            }
            else if (Pyear != "")
            {

                strSQL = strSQL + " AND year(INSERT_DATE) = '" + Pyear + "' ";
            }
            strSQL = strSQL + " ORDER BY PROCESS_NAME ";
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
                    ManuProcess ogrp = new ManuProcess();
                    ogrp.strProcessName = drGetGroup["PROCESS_NAME"].ToString();
                    ogrp.strEntryDate = Convert.ToDateTime(drGetGroup["INSERT_DATE"]).ToString("dd/MM/yyyy");
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }
        public List<ManuProcess> mLoadFgProcessFG(string strDeComID, string Pyear)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ManuProcess> oogrp = new List<ManuProcess>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strSQL = "SELECT INV_REF_NO_IN,INV_LOG_DATE FROM INV_PRODUCTION_LOG ";
            strSQL = strSQL + " WHERE CONVERTTYPE =1 ";
            strSQL = strSQL + " AND year(INV_LOG_DATE) = '" + Pyear + "' ";

            strSQL = strSQL + " ORDER BY INV_REF_NO_IN ";

            //strSQL = "SELECT * FROM INV_PRODUCTION_LOG ";
            //strSQL = strSQL + " WHERE CONVERTTYPE =1 ";
            //if (Pyear != "")
            //{
            //    strSQL = strSQL + " AND year(INV_LOG_DATE) = '" + Pyear + "' ";
            //}
            //strSQL = strSQL + " ORDER BY INV_LOG_PROCESS_NAME ";
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
                    ManuProcess ogrp = new ManuProcess();
                    ogrp.strProcessName = drGetGroup["INV_REF_NO_IN"].ToString();
                    ogrp.strEntryDate = Convert.ToDateTime(drGetGroup["INV_LOG_DATE"]).ToString("dd/MM/yyyy");
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }
        public List<ManuProcess> mDisplayProcess(string strDeComID, string vstrProcessName,string strType)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ManuProcess> oogrp = new List<ManuProcess>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


            
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                if (strType.ToUpper() == "P")
                {
                    strSQL = "SELECT INV_MENU_PROCESS_MAIN.CONVERT_Y_N,INV_MANU_PROCESS.PROCESS_NAME,INV_MANU_PROCESS.STOCKITEM_NAME,INV_MANU_PROCESS.PROCESS_QUANTITY,";
                    strSQL = strSQL + "INV_MANU_PROCESS.INV_PER,INV_MANU_PROCESS.PROCESS_TYPE,INV_MANU_PROCESS.FG_COST_PERCENT,0 TRANSFER_TYPE,INV_MENU_PROCESS_MAIN.BRANCH_ID,INV_MANU_PROCESS.GODOWNS_NAME FROM INV_MANU_PROCESS,INV_MENU_PROCESS_MAIN  ";
                    strSQL = strSQL + "WHERE INV_MANU_PROCESS.PROCESS_NAME = INV_MENU_PROCESS_MAIN.PROCESS_NAME ";
                    if (vstrProcessName != "")
                    {
                        strSQL = strSQL + "AND INV_MANU_PROCESS.PROCESS_NAME = '" + vstrProcessName + "' ";
                    }
                }
                else
                {
                    strSQL = "SELECT INV_MENU_PROCESS_MAIN.CONVERT_Y_N,INV_MANU_PROCESS.PROCESS_NAME,INV_MANU_PROCESS.STOCKITEM_NAME,INV_MANU_PROCESS.PROCESS_QUANTITY , ";
                    strSQL = strSQL + "INV_MANU_PROCESS.INV_PER, INV_STOCKGROUP.STOCKGROUP_SECONDARY_TYPE PROCESS_TYPE, ";
                    strSQL = strSQL + "INV_MANU_PROCESS.FG_COST_PERCENT,INV_MENU_PROCESS_MAIN.TRANSFER_TYPE,INV_MENU_PROCESS_MAIN.BRANCH_ID,INV_MANU_PROCESS.GODOWNS_NAME ";
                    strSQL = strSQL + "FROM INV_MENU_PROCESS_MAIN,INV_MANU_PROCESS,INV_STOCKGROUP,INV_STOCKITEM  WHERE INV_MENU_PROCESS_MAIN.PROCESS_NAME =INV_MANU_PROCESS.PROCESS_NAME ";
                    strSQL = strSQL + "AND INV_STOCKGROUP.STOCKGROUP_NAME =INV_STOCKITEM.STOCKGROUP_NAME  ";
                    strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_NAME = INV_MANU_PROCESS.STOCKITEM_NAME ";
                    strSQL = strSQL + "AND INV_MANU_PROCESS.PROCESS_NAME = '" + vstrProcessName + "' ";
                }
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    ManuProcess ogrp = new ManuProcess();
                    ogrp.strProcessName = drGetGroup["PROCESS_NAME"].ToString();
                    ogrp.stritemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.dblqnty = Utility.Val(drGetGroup["PROCESS_QUANTITY"].ToString());
                    ogrp.strUnit = drGetGroup["INV_PER"].ToString();
                    //ogrp.strProcessName = drGetGroup["PROCESS_NAME"].ToString();
                    ogrp.intType = Convert.ToInt16(drGetGroup["PROCESS_TYPE"].ToString());
                    ogrp.dblCostPercent = Utility.Val(drGetGroup["FG_COST_PERCENT"].ToString());
                    ogrp.intConverttype = Convert.ToInt16(drGetGroup["CONVERT_Y_N"].ToString());
                    ogrp.intTrasnferType = Convert.ToInt16(drGetGroup["TRANSFER_TYPE"].ToString());
                    ogrp.strBranchID = drGetGroup["BRANCH_ID"].ToString();
                    if (drGetGroup["GODOWNS_NAME"].ToString() != "")
                    {
                        ogrp.strGodown = drGetGroup["GODOWNS_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strGodown = "";
                    }
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }


        #endregion
        #region "Purchase Invoice"
        public string mSavePurchaseInvoice(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger, double dblTotalAmnt,
                                      double dblNetAmount, double dblAddAmount, double dblLessAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirPurcInv, long mlngIsChqueCash, string strNarrations,
                                      string strBranchId, string vstrGodownName, long lngIsMultiCurrency, string strSalesRep, string DGSalesGrid, string DGVector, string DGBillWise, string DGAddLess, string DGsalesOrder,
                                      bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool blngNumberMethod)
        {

            string strDRCR = "", strcheck = "";
            string strBillKey, strItemName, strAgstRefNo = "", strBillPreKey = "", strItemBangla,
                strItemDesc, strAddLess, strBatchNo, strUOm, strPer, strGodownName,
                strGiftItem, strPreRefNo = "", strbatch = "", strAgnstbillkey, strAgnstBillRef;
            double dblCredit = 0, dblqty = 0, dblRate, dblTotalAmount, dblDiscAmount, dblDebitValue, dblBonusQty, dblAltWhere, dblTotalCost = 1, dblGiftQty = 1, dblCostPrice, dblPriorQty = 0, dblCostAmount;
            long lngloop = 1, lngPosition = 1, mlngCashFlow = 2, lngLedgergroup;
            bool blnMultiple = false;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            lngLedgergroup = (long)(Utility.gGetLedgergroup(strDeComID, strLedgerName));

            if (lngLedgergroup <= 101)
            {
                mlngCashFlow = 1;
            }

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    SqlDataReader rsget;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = Voucher.gInsertCompanyVoucher(strRefNo, mlngVType, strDate, strMonthID, strDueDate, strLedgerName, dblTotalAmnt, dblNetAmount, dblAddAmount, dblLessAmount, lngAgstRef, strNarrations,
                                                        strBranchId, lngIsMultiCurrency, "", strSalesRep, "", "", "", "", "");

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    if (DGVector != "")
                    {
                        string[] words = DGVector.Split('~');
                        foreach (string strVector in words)
                        {
                            string[] ooCost = strVector.Split('|');
                            if (ooCost[0] != "")
                            {
                                strSQL = Voucher.mInsertVector(strRefNo, ooCost[1].ToString(), ooCost[2].ToString(), strDate, strLedgerName, "Cr", lngPosition, lngPosition, 1, ooCost[0].ToString(), Utility.Val(ooCost[3].ToString()), 0, "", mlngVType);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                strSQL = Voucher.mInsertVector(strRefNo, ooCost[1].ToString(), ooCost[2].ToString(), strDate, strSalesLedger, "Dr", lngPosition, lngPosition, 2, ooCost[0].ToString(), Utility.Val(ooCost[3].ToString()), 0, "", mlngVType);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lngPosition += 1;
                            }

                        }
                    }
                    lngPosition = 1;
                    if (lngAgstRef != (long)Utility.VOUCHER_TYPE.vtPURCHASE_RECEIVE)
                    {
                        if (mlngIsInvEffinDirPurcInv == 0)
                        {
                            strSQL = Voucher.gInteractInvInsertMaster(strLedgerName, strRefNo, mlngVType, strDate, strBranchId, strNarrations);
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            strcheck = "Yes";
                        }
                        else
                        {
                            strcheck = "No";
                        }
                    }
                    else
                    {
                        strcheck = "No";
                    }
                    //'If Cash Or Bank Then Should not go in Bill By Bill
                    //if (mlngCashFlow > 1)
                    //{
                    if (DGBillWise != "")
                    {
                        int intbillpos = 1;

                        string[] words = DGBillWise.Split('~');
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('|');
                            if (ooCost[0] != "")
                            {
                                strAgstRefNo = strBranchId + ooCost[1].ToString();
                                strSQL = Voucher.gInsertBillWise(strBranchId, strRefNo, ooCost[2].ToString(), mlngVType, strLedgerName, intbillpos, ooCost[0].ToString(),
                                                                    Utility.Val(ooCost[3].ToString()), ooCost[4].ToString(), strAgstRefNo, intbillpos);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                intbillpos += 1;
                            }
                        }
                    }
                    else
                    {
                        if (mlngVType == (long)(Utility.VOUCHER_TYPE.vtSALES_INVOICE))
                        {
                            strDRCR = "Dr";
                        }
                        else
                        {
                            strDRCR = "Cr";
                        }
                        strAgstRefNo = Utility.Mid(strRefNo, 2, strRefNo.Length - 2);
                        strSQL = Voucher.gInsertBillWise(strBranchId, strRefNo, strDate, mlngVType, strLedgerName, 0, "New Ref", dblNetAmount, strDRCR, strAgstRefNo, 0, strDueDate);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    //}

                    if (DGSalesGrid != "")
                    {
                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split('|');
                            if (ooCost[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                                strItemName = ooCost[0].ToString().Replace("'","''");
                                //dblCostPrice = Utility.gdblGetCostPrice(strItemName, strDate);
                                //strItemBangla = Utility.gGetItemNameBangla (ooCost[1].ToString());
                                strItemBangla = "";
                                strItemDesc = ooCost[1].ToString();
                                strGodownName = vstrGodownName;
                                dblqty = Utility.Val(ooCost[2].ToString());
                                dblRate = Utility.Val(ooCost[3].ToString());
                                dblTotalAmount = Utility.Val(ooCost[5].ToString());
                                strUOm = ooCost[4].ToString();
                                strPer = ooCost[4].ToString();


                                dblDiscAmount = Utility.Val(ooCost[5].ToString()) - Utility.Val(ooCost[7].ToString());
                                dblDebitValue = Utility.Val(ooCost[7].ToString());
                                if (ooCost[8].ToString() != "")
                                {
                                    if (ooCost[8].ToString() != Utility.gcEND_OF_LIST)
                                    {
                                        strBatchNo = ooCost[8].ToString();
                                    }
                                    else
                                    {
                                        strBatchNo = "";
                                    }
                                }
                                else
                                {
                                    strBatchNo = "";
                                }

                                dblBonusQty = Utility.Val(ooCost[9].ToString());
                                strAddLess = ooCost[10].ToString();
                                dblCostPrice = Utility.Val(ooCost[12].ToString());
                                strAgnstbillkey = ooCost[13].ToString();
                                strAgnstBillRef = ooCost[14].ToString();

                                dblAltWhere = 1;
                                //If InStr(1, .TextMatrix(lngloop, 3), strPer) = 0 Then
                                //    dblAltWhere = gdblDenomation(Replace$(.TextMatrix(lngloop, 1), "'", "''"))
                                //End If
                                if (blnMultiCurr)
                                {
                                    //dblRate = Val(ucSalesGrid.TextMatrix(lngloop, 4))    '* mdblCurrRate
                                    //dblFCDebit = dblDebitValue / mdblCurrRate
                                    //gInsertBillTranFC strBillKey, strRefNo, mlngVType, uctxtDate.Text, strItemName, strGodownName, dblqty, dblBonusQty, strUOm, dblRate, dblTotalAmount, strAddLess, dblDiscAmount, dblDebitValue, "Cr", mdblCurrRate, dblFCDebit, strBranchId, mstrFCsymbol, lngloop, strPer, , strBatchNo, , strItemBangla    ', strSalesRep
                                }
                                else
                                {
                                    strSQL = Voucher.gInsertBillTran(strBillKey, strRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblBonusQty, strUOm, dblRate, dblTotalAmount, strAddLess,
                                                                        dblDiscAmount, dblDebitValue, "Cr", lngloop, strBranchId, Utility.gstrBaseCurrency, strPer, "", strAgnstbillkey, strBatchNo, strItemDesc, strAgnstBillRef, strItemBangla);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, strRefNo, strRefNo, mlngVType, strDate,
                                                                        strItemName, strGodownName, dblqty, strUOm, strBillKey, 0, 0, strPer);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                if (lngAgstRef != (long)Utility.VOUCHER_TYPE.vtPURCHASE_RECEIVE)
                                {
                                    if (mlngIsInvEffinDirPurcInv == 0)
                                    {
                                        if (dblAltWhere == 0)
                                        {
                                            strSQL = Voucher.gInventoryInsertTranPurchases(strRefNo, strBillKey, lngloop, Math.Round(dblRate / dblAltWhere, 2), dblDebitValue, lngAgstRef, strItemName, strGodownName, "I", dblqty, mlngVType, strDate, strBranchId, strBatchNo, strPer, strUOm);
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            strSQL = Voucher.gInventoryInsertTranPurchases(strRefNo, strBillKey, lngloop, Math.Round(dblRate / dblAltWhere, 2), dblDebitValue, lngAgstRef, strItemName, strGodownName, "I", dblqty, mlngVType, strDate, strBranchId, strBatchNo, strPer, strUOm);
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                    }
                                }

                                if (strRefType != Utility.gcEND_OF_LIST)
                                {

                                    //strSQL = "SELECT BILL_TRAN_KEY,COMP_REF_NO,BILL_QUANTITY,STOCKITEM_NAME FROM ACC_BILL_TRAN ";
                                    //strSQL = strSQL + "WHERE BILL_TRAN_KEY = '" + strRefNo + "'";
                                    //cmdInsert.CommandText = strSQL;
                                    //rsget = cmdInsert.ExecuteReader();
                                    //if (rsget.Read())
                                    //{
                                    //    strItemName = rsget["STOCKITEM_NAME"].ToString();
                                    //    strPreRefNo = rsget["COMP_REF_NO"].ToString();
                                    //    strBillPreKey = rsget["BILL_TRAN_KEY"].ToString();
                                    //}
                                    //rsget.Close();
                                    ////'While Process Sales Challan
                                    //if (lngAgstRef > 0)
                                    //{
                                    //    strSQL = "SELECT BILL_BALANCE_QTY FROM ACC_BILL_TRAN_PENDING_QRY ";
                                    //    strSQL = strSQL + "WHERE BILL_TRAN_KEY = '" + strBillPreKey + "' ";
                                    //    cmdInsert.CommandText = strSQL;
                                    //    rsget = cmdInsert.ExecuteReader();
                                    //    if (rsget.Read())
                                    //    {
                                    //        if (Utility.Val(rsget["BILL_BALANCE_QTY"].ToString()) < dblqty)
                                    //        {
                                    //            rsget.Close();
                                    //            return "Balance Problem in Item " + strItemName;

                                    //        }
                                    //    }
                                    //}
                                    //rsget.Close();
                                    //'Ref Transaction


                                    strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, strRefNo, strAgnstBillRef, lngAgstRef, strDate,
                                                                            strItemName, strGodownName, dblqty * -1, strUOm, strAgnstbillkey, dblDiscAmount, dblDebitValue, strPer);

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();


                                    //if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtPURCHASE_RECEIVE)
                                    //{

                                    //    //dblPriorQty = Utility.gdblGetPriorQty(ucSerialGrid.TextMatrix(lngloop, 1));
                                    //    dblCostAmount = dblCostPrice * dblPriorQty;
                                    //    strSQL = "UPDATE INV_TRAN SET INV_TRAN_AMOUNT = " + dblCostAmount * -1 + ", ";
                                    //    strSQL = strSQL + "OUTWARD_SALES_AMOUNT = OUTWARD_SALES_AMOUNT - " + dblDebitValue + ", ";
                                    //    strSQL = strSQL + "OUTWARD_COST_AMOUNT =  " + dblCostAmount * -1 + " ";
                                    //    strSQL = strSQL + "WHERE INV_TRAN_KEY = '" + strBillPreKey + "' ";
                                    //    cmdInsert.CommandText = strSQL;
                                    //    cmdInsert.ExecuteNonQuery();

                                    //}
                                    //rsget.Close();
                                }

                            }

                            lngPosition = lngPosition + 1;
                            lngloop += 1;
                        }
                    }


                    dblCredit = dblNetAmount;
                    //'Insert Accounts Voucher Table
                    if (mdblCurrRate == 0)
                    {

                        if (mlngCashFlow == 0)
                        {
                            strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 1, strLedgerName, "Cr", dblNetAmount, mlngVType, strSalesLedger, strBranchId, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        else
                        {
                            strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 1, strLedgerName, "Cr", dblNetAmount, mlngVType, strSalesLedger, strBranchId, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 2, strSalesLedger, "Dr", dblNetAmount, mlngVType, strLedgerName, strBranchId, 2, "", "", "", "");
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    else
                    {
                        if (mlngIsChqueCash == 0)
                        {
                            strSQL = Voucher.gInsertSalesVoucherFC(strRefNo, strDate, 1, strLedgerName, "Cr", dblNetAmount, mlngVType, strSalesLedger, strBranchId, mdblCurrRate, mstrFCsymbol, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        else
                        {
                            strSQL = Voucher.gInsertSalesVoucherFC(strRefNo, strDate, 1, strLedgerName, "Cr", dblNetAmount, mlngVType, strSalesLedger, strBranchId, mdblCurrRate, mstrFCsymbol, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        strSQL = Voucher.gInsertSalesVoucherFC(strRefNo, strDate, 2, strSalesLedger, "Dr", dblTotalAmnt, mlngVType, strLedgerName, strBranchId, mdblCurrRate, mstrFCsymbol, 2, "", "", "", "", strbatch);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    if (blnMultiple)
                    {
                        strSQL = "UPDATE ACC_VOUCHER SET VOUCHER_REVERSE_LEDGER = '" + "As per Details' ";
                        strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNo + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    blnMultiple = false;

                    if (strRefType != Utility.gcEND_OF_LIST)
                    {
                        if (DGsalesOrder != "")
                        {
                            string[] words = DGsalesOrder.Split('~');
                            foreach (string strSalesOrder in words)
                            {
                                string[] ooCost = strSalesOrder.Split('|');
                                if (ooCost[0] != "")
                                {
                                    strSQL = "SELECT SUM(BILL_QUANTITY) AS QTY FROM ACC_BILL_TRAN_PROCESS ";
                                    strSQL = strSQL + "WHERE AGST_COMP_REF_NO = '" + ooCost[0] + "'";
                                    cmdInsert.CommandText = strSQL;
                                    rsget = cmdInsert.ExecuteReader();
                                    if (rsget.Read())
                                    {

                                        if (Utility.Val(rsget["QTY"].ToString()) == 0)
                                        {
                                            rsget.Close();
                                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
                                            strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost[0] + "'";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            rsget.Close();
                                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 0 ";
                                            strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost[0] + "'";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                    }

                                    else
                                    {
                                        rsget.Close();
                                    }

                                    strSQL = "INSERT INTO ACC_VOUCHER_JOIN(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID) ";
                                    strSQL = strSQL + "VALUES(";
                                    strSQL = strSQL + "'" + strRefNo + "','" + ooCost[0] + "','" + strBranchId + "'";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }

                            }
                        }
                    }



                    if (DGAddLess != "")
                    {
                        string[] words1 = DGAddLess.Split('~');
                        foreach (string ooassets in words1)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                if (oAssets[1] != "-")
                                {
                                    strSQL = Voucher.gInsertADDLESS(strRefNo, strLedgerName, strDate, dblAddAmount, dblLessAmount, strBranchId);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, lngPosition, oAssets[0], "Dr", Utility.Val(oAssets[2]), mlngVType, oAssets[0], strBranchId, 0, oAssets[1], "", "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    //if (mdblCurrRate != 0)
                                    //{
                                    //    strSQL = "UPDATE ACC_VOUCHER SET ";
                                    //    strSQL = strSQL + "FC_CONVERSION_RATE = " + mdblCurrRate + ", ";
                                    //    strSQL = strSQL + "VOUCHER_CURRENCY_SYMBOL = '" + mstrFCsymbol + "' ";
                                    //    strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNo + "' ";
                                    //    strSQL = strSQL + "AND COMP_VOUCHER_POSITION = " + lngPosition + " ";
                                    //    cmdInsert.CommandText = strSQL;
                                    //    cmdInsert.ExecuteNonQuery();
                                    //    blnMultiple = true;
                                    //}
                                }
                                else
                                {
                                    strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, lngPosition, oAssets[0], "Cr", Utility.Val(oAssets[2]), mlngVType, oAssets[0], strBranchId, 0, oAssets[1], "", "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    //if (mdblCurrRate != 0)
                                    //{
                                    //    strSQL = "UPDATE ACC_VOUCHER SET ";
                                    //    strSQL = strSQL + "FC_CONVERSION_RATE = " + mdblCurrRate + ", ";
                                    //    strSQL = strSQL + "VOUCHER_CURRENCY_SYMBOL = '" + mstrFCsymbol + "' ";
                                    //    strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNo + "' ";
                                    //    strSQL = strSQL + "AND COMP_VOUCHER_POSITION = " + lngPosition + " ";
                                    //    cmdInsert.CommandText = strSQL;
                                    //    cmdInsert.ExecuteNonQuery();
                                    //    blnMultiple = true;
                                    //}
                                }

                            }

                        }
                    }


                    if (blngNumberMethod == true)
                    {
                        strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }



                    cmdInsert.Transaction.Commit();

                    gcnMain.Close();
                    return "Inserted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }
        public string mUpdatePurchaseInvoice(string strDeComID, string mstrRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger, double dblTotalAmnt,
                                      double dblNetAmount, double dblAddAmount, double dblLessAmount, string strRefType, long lngAgstRef, long mlngIsInvEffinDirPurcInv, long mlngIsChqueCash, string strNarrations,
                                      string strBranchId, string vstrGodownName, long lngIsMultiCurrency, string strSalesRep, string DGSalesGrid, string DGVector, string DGBillWise, string DGAddLess, string DGsalesOrder,
                                      bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol)
        {

            string strDRCR = "", strcheck = "";
            string strBillKey, strItemName, strAgstRefNo = "", strBillPreKey = "", strItemBangla, strItemDesc, strAddLess, strBatchNo, strUOm, strPer,
                strGodownName, strGiftItem, strPreRefNo = "", strbatch = "", strAgnstbillkey, strAgnstBillRef;
            double dblCredit = 0, dblqty = 0, dblRate, dblTotalAmount, dblDiscAmount, dblDebitValue, dblBonusQty, dblAltWhere, dblTotalCost = 1,
                dblGiftQty = 1, dblCostPrice, dblPriorQty = 0, dblCostAmount;
            long lngloop = 1, lngPosition = 1, mlngCashFlow = 2, lngLedgergroup;
            bool blnMultiple = false;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            lngLedgergroup = (long)(Utility.gGetLedgergroup(strDeComID, strLedgerName));

            if (lngLedgergroup <= 101)
            {
                mlngCashFlow = 1;
            }
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    SqlDataReader rsget;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    //'All Delete Code Here
                    strSQL = "DELETE FROM ACC_BILL_TRAN WHERE COMP_REF_NO = '" + mstrRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO = '" + mstrRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_VOUCHER WHERE COMP_REF_NO = '" + mstrRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM ACC_ADD_LESS WHERE ADD_LESS_COMP_REF_NO = '" + mstrRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_VOUCHER_JOIN WHERE VOUCHER_JOIN_PRIMARY_REF = '" + mstrRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM ACC_BILL_WISE WHERE COMP_REF_NO = '" + mstrRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //strSQL = "DELETE FROM INV_TRAN_HARDWARE_SL_REF WHERE COMP_REF_NO = '" + mstrRefNo + "' ";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();


                    strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO = '" + mstrRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO = '" + mstrRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM VECTOR_TRANSACTION WHERE COMP_REF_NO = '" + mstrRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strSQL = "UPDATE ACC_COMPANY_VOUCHER SET ";
                    strSQL = strSQL + "LEDGER_NAME = '" + strLedgerName.Replace("'","''") + "',";
                    strSQL = strSQL + "BRANCH_ID = '" + strBranchId + "',";
                    strSQL = strSQL + "COMP_VOUCHER_DATE = " + Utility.cvtSQLDateString(strDate) + ",";
                    strSQL = strSQL + "COMP_VOUCHER_MONTH_ID = '" + strMonthID + "',";
                    strSQL = strSQL + "COMP_VOUCHER_NARRATION = '" + strNarrations + "',";
                    strSQL = strSQL + "COMP_VOUCHER_AMOUNT = " + dblTotalAmnt + ",";
                    strSQL = strSQL + "COMP_VOUCHER_NET_AMOUNT = " + dblNetAmount + ",";
                    strSQL = strSQL + "COMP_VOUCHER_ADD_AMOUNT = " + dblAddAmount + ",";
                    strSQL = strSQL + "COMP_VOUCHER_LESS_AMOUNT = " + dblLessAmount + ",";
                    strSQL = strSQL + "COMP_VOUCHER_DUE_DATE = " + Utility.cvtSQLDateString(strDueDate) + ",";
                    strSQL = strSQL + "INSERT_DATE = " + Utility.cvtSQLDateString(DateTime.Today.ToString("dd/MM/yyyy"));
                    if (strSalesRep != Utility.gcEND_OF_LIST)
                    {
                        strSQL = strSQL + ",SALES_REP='" + strSalesRep + "' ";
                    }
                    else
                    {

                        strSQL = strSQL + ",SALES_REP='' ";
                    }
                    //If uctxtPartyName2.Text <> vbNullString Then
                    //    strSQL = strSQL + ",COMP_VOUCHER_PARTY_NAME = '" + Replace$(uctxtPartyName2.Text, "'", "''") + "' ";
                    //End If
                    //If uctxtAddress3.Text <> vbNullString Then
                    //    strSQL = strSQL + ",COMP_VOUCHER_ADDRESS1 = '" + Replace$(uctxtAddress3.Text, "'", "''") + "' ";
                    //End If
                    //If uctxtAddress4.Text <> vbNullString Then
                    //    strSQL = strSQL + ",COMP_VOUCHER_ADDRESS2 = '" + Replace$(uctxtAddress4.Text, "'", "''") + "' ";
                    //End If
                    //If uctxtCity1.Text <> vbNullString Then
                    //    strSQL = strSQL + ",COMP_VOUCHER_CITY = '" + Replace$(uctxtCity1.Text, "'", "''") + "' ";
                    //End If
                    strSQL = strSQL + " WHERE COMP_REF_NO = '" + mstrRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();



                    if (DGVector != "")
                    {
                        string[] words = DGVector.Split('~');
                        foreach (string strVector in words)
                        {
                            string[] ooCost = strVector.Split('|');
                            if (ooCost[0] != "")
                            {
                                strSQL = Voucher.mInsertVector(mstrRefNo, ooCost[1].ToString(), ooCost[2].ToString(), strDate, strLedgerName, "Cr", lngPosition, lngPosition, 1, ooCost[0].ToString(), Utility.Val(ooCost[3].ToString()), 0, "", mlngVType);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                strSQL = Voucher.mInsertVector(mstrRefNo, ooCost[1].ToString(), ooCost[2].ToString(), strDate, strSalesLedger, "Dr", lngPosition, lngPosition, 2, ooCost[0].ToString(), Utility.Val(ooCost[3].ToString()), 0, "", mlngVType);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lngPosition += 1;
                            }

                        }
                    }
                    lngPosition = 1;
                    if (lngAgstRef != (long)Utility.VOUCHER_TYPE.vtPURCHASE_RECEIVE)
                    {
                        if (mlngIsInvEffinDirPurcInv == 0)
                        {
                            strSQL = Voucher.gInteractInvInsertMaster(strLedgerName, mstrRefNo, mlngVType, strDate, strBranchId, strNarrations);
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            strcheck = "Yes";
                        }
                        else
                        {
                            strcheck = "No";
                        }
                    }
                    else
                    {
                        strcheck = "No";
                    }
                    //'If Cash Or Bank Then Should not go in Bill By Bill
                    //if (mlngCashFlow > 1)
                    //{
                    if (DGBillWise != "")
                    {
                        int intbillpos = 1;

                        string[] words = DGBillWise.Split('~');
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('|');
                            if (ooCost[0] != "")
                            {
                                strAgstRefNo = strBranchId + ooCost[1].ToString();
                                strSQL = Voucher.gInsertBillWise(strBranchId, mstrRefNo, ooCost[2].ToString(), mlngVType, strLedgerName, intbillpos, ooCost[0].ToString(),
                                                                    Utility.Val(ooCost[3].ToString()), ooCost[4].ToString(), strAgstRefNo, intbillpos);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                intbillpos += 1;
                            }
                        }
                    }
                    else
                    {
                        if (mlngVType == (long)(Utility.VOUCHER_TYPE.vtSALES_INVOICE))
                        {
                            strDRCR = "Dr";
                        }
                        else
                        {
                            strDRCR = "Cr";
                        }
                        strAgstRefNo = Utility.Mid(strRefNo, 2, strRefNo.Length - 2);
                        strSQL = Voucher.gInsertBillWise(strBranchId, mstrRefNo, strDate, mlngVType, strLedgerName, 0, "New Ref", dblNetAmount, strDRCR, strAgstRefNo, 0, strDueDate);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    //}

                    if (DGSalesGrid != "")
                    {
                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split('|');
                            if (ooCost[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                                strItemName = ooCost[0].ToString().Replace("'","''");
                                //dblCostPrice = Utility.gdblGetCostPrice(strItemName, strDate);
                                //strItemBangla = Utility.gGetItemNameBangla (ooCost[1].ToString());
                                strItemBangla = "";
                                strItemDesc = ooCost[1].ToString();
                                strGodownName = vstrGodownName;
                                dblqty = Utility.Val(ooCost[2].ToString());
                                dblRate = Utility.Val(ooCost[3].ToString());
                                dblTotalAmount = Utility.Val(ooCost[5].ToString());
                                strUOm = ooCost[4].ToString();
                                strPer = ooCost[4].ToString();


                                dblDiscAmount = Utility.Val(ooCost[5].ToString()) - Utility.Val(ooCost[7].ToString());
                                dblDebitValue = Utility.Val(ooCost[7].ToString());
                                if (ooCost[8].ToString() != "")
                                {
                                    if (ooCost[8].ToString() != Utility.gcEND_OF_LIST)
                                    {
                                        strBatchNo = ooCost[8].ToString();
                                    }
                                    else
                                    {
                                        strBatchNo = "";
                                    }
                                }
                                else
                                {
                                    strBatchNo = "";
                                }

                                dblBonusQty = Utility.Val(ooCost[9].ToString());
                                strAddLess = ooCost[10].ToString();
                                dblCostPrice = Utility.Val(ooCost[12].ToString());

                                strAgnstbillkey = ooCost[13].ToString();
                                strAgnstBillRef = ooCost[14].ToString();

                                dblAltWhere = 1;
                                //If InStr(1, .TextMatrix(lngloop, 3), strPer) = 0 Then
                                //    dblAltWhere = gdblDenomation(Replace$(.TextMatrix(lngloop, 1), "'", "''"))
                                //End If
                                if (blnMultiCurr)
                                {
                                    //dblRate = Val(ucSalesGrid.TextMatrix(lngloop, 4))    '* mdblCurrRate
                                    //dblFCDebit = dblDebitValue / mdblCurrRate
                                    //gInsertBillTranFC strBillKey, strRefNo, mlngVType, uctxtDate.Text, strItemName, strGodownName, dblqty, dblBonusQty, strUOm, dblRate, dblTotalAmount, strAddLess, dblDiscAmount, dblDebitValue, "Cr", mdblCurrRate, dblFCDebit, strBranchId, mstrFCsymbol, lngloop, strPer, , strBatchNo, , strItemBangla    ', strSalesRep
                                }
                                else
                                {
                                    strSQL = Voucher.gInsertBillTran(strBillKey, mstrRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblBonusQty, strUOm, dblRate, dblTotalAmount, strAddLess,
                                                                        dblDiscAmount, dblDebitValue, "Cr", lngloop, strBranchId, Utility.gstrBaseCurrency, strPer, "", strAgnstbillkey, strBatchNo, strItemDesc, strAgnstBillRef, strItemBangla);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, mstrRefNo, mstrRefNo, mlngVType, strDate,
                                                                        strItemName, strGodownName, dblqty, strUOm, strBillKey, 0, 0, strPer);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                if (lngAgstRef != (long)Utility.VOUCHER_TYPE.vtPURCHASE_RECEIVE)
                                {
                                    if (mlngIsInvEffinDirPurcInv == 0)
                                    {
                                        if (dblAltWhere == 0)
                                        {
                                            strSQL = Voucher.gInventoryInsertTranPurchases(mstrRefNo, strBillKey, lngloop, Math.Round(dblRate / dblAltWhere, 2), dblDebitValue, lngAgstRef, strItemName, strGodownName, "I", dblqty, mlngVType, strDate, strBranchId, strBatchNo, strPer, strUOm);
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            strSQL = Voucher.gInventoryInsertTranPurchases(mstrRefNo, strBillKey, lngloop, Math.Round(dblRate / dblAltWhere, 2), dblDebitValue, lngAgstRef, strItemName, strGodownName, "I", dblqty, mlngVType, strDate, strBranchId, strBatchNo, strPer, strUOm);
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                    }
                                }

                                if (strRefType != Utility.gcEND_OF_LIST)
                                {

                                    //strSQL = "SELECT BILL_TRAN_KEY,COMP_REF_NO,BILL_QUANTITY,STOCKITEM_NAME FROM ACC_BILL_TRAN ";
                                    //strSQL = strSQL + "WHERE BILL_TRAN_KEY = '" + strRefNo + "'";
                                    //cmdInsert.CommandText = strSQL;
                                    //rsget = cmdInsert.ExecuteReader();
                                    //if (rsget.Read())
                                    //{
                                    //    strItemName = rsget["STOCKITEM_NAME"].ToString();
                                    //    strPreRefNo = rsget["COMP_REF_NO"].ToString();
                                    //    strBillPreKey = rsget["BILL_TRAN_KEY"].ToString();
                                    //}
                                    //rsget.Close();
                                    ////'While Process Sales Challan
                                    //if (lngAgstRef > 0)
                                    //{
                                    //    strSQL = "SELECT BILL_BALANCE_QTY FROM ACC_BILL_TRAN_PENDING_QRY ";
                                    //    strSQL = strSQL + "WHERE BILL_TRAN_KEY = '" + strBillPreKey + "' ";
                                    //    cmdInsert.CommandText = strSQL;
                                    //    rsget = cmdInsert.ExecuteReader();
                                    //    if (rsget.Read())
                                    //    {
                                    //        if (Utility.Val(rsget["BILL_BALANCE_QTY"].ToString()) < dblqty)
                                    //        {
                                    //            rsget.Close();
                                    //            return "Balance Problem in Item " + strItemName;

                                    //        }
                                    //    }
                                    //}
                                    //rsget.Close();
                                    //'Ref Transaction


                                    strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, mstrRefNo, strAgnstBillRef, lngAgstRef, strDate,
                                                                            strItemName, strGodownName, dblqty * -1, strUOm, strAgnstbillkey, dblDiscAmount, dblDebitValue, strPer);

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();


                                    //if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtPURCHASE_RECEIVE)
                                    //{

                                    //    //dblPriorQty = Utility.gdblGetPriorQty(ucSerialGrid.TextMatrix(lngloop, 1));
                                    //    dblCostAmount = dblCostPrice * dblPriorQty;
                                    //    strSQL = "UPDATE INV_TRAN SET INV_TRAN_AMOUNT = " + dblCostAmount * -1 + ", ";
                                    //    strSQL = strSQL + "OUTWARD_SALES_AMOUNT = OUTWARD_SALES_AMOUNT - " + dblDebitValue + ", ";
                                    //    strSQL = strSQL + "OUTWARD_COST_AMOUNT =  " + dblCostAmount * -1 + " ";
                                    //    strSQL = strSQL + "WHERE INV_TRAN_KEY = '" + strBillPreKey + "' ";
                                    //    cmdInsert.CommandText = strSQL;
                                    //    cmdInsert.ExecuteNonQuery();

                                    //}
                                    //rsget.Close();
                                }

                            }

                            lngPosition = lngPosition + 1;
                            lngloop += 1;
                        }
                    }

                    dblCredit = dblNetAmount;
                    //'Insert Accounts Voucher Table
                    if (mdblCurrRate == 0)
                    {

                        if (mlngCashFlow == 0)
                        {
                            strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 1, strLedgerName, "Cr", dblNetAmount, mlngVType, strSalesLedger, strBranchId, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        else
                        {
                            strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 1, strLedgerName, "Cr", dblNetAmount, mlngVType, strSalesLedger, strBranchId, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 2, strSalesLedger, "Dr", dblNetAmount, mlngVType, strLedgerName, strBranchId, 2, "", "", "", "");
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    else
                    {
                        if (mlngIsChqueCash == 0)
                        {
                            strSQL = Voucher.gInsertSalesVoucherFC(mstrRefNo, strDate, 1, strLedgerName, "Cr", dblNetAmount, mlngVType, strSalesLedger, strBranchId, mdblCurrRate, mstrFCsymbol, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        else
                        {
                            strSQL = Voucher.gInsertSalesVoucherFC(mstrRefNo, strDate, 1, strLedgerName, "Cr", dblNetAmount, mlngVType, strSalesLedger, strBranchId, mdblCurrRate, mstrFCsymbol, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        strSQL = Voucher.gInsertSalesVoucherFC(mstrRefNo, strDate, 2, strSalesLedger, "Dr", dblTotalAmnt, mlngVType, strLedgerName, strBranchId, mdblCurrRate, mstrFCsymbol, 2, "", "", "", "", strbatch);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    if (blnMultiple)
                    {
                        strSQL = "UPDATE ACC_VOUCHER SET VOUCHER_REVERSE_LEDGER = '" + "As per Details' ";
                        strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNo + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    blnMultiple = false;

                    if (DGAddLess != "")
                    {
                        string[] words1 = DGAddLess.Split('~');
                        foreach (string ooassets in words1)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                if (oAssets[1] != "-")
                                {
                                    strSQL = Voucher.gInsertADDLESS(strRefNo, strLedgerName, strDate, dblAddAmount, dblLessAmount, strBranchId);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, lngPosition, oAssets[0], "Dr", Utility.Val(oAssets[2]), mlngVType, oAssets[0], strBranchId, 0, oAssets[1], "", "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    //    if (mdblCurrRate != 0)
                                    //    {
                                    //        strSQL = "UPDATE ACC_VOUCHER SET ";
                                    //        strSQL = strSQL + "FC_CONVERSION_RATE = " + mdblCurrRate + ", ";
                                    //        strSQL = strSQL + "VOUCHER_CURRENCY_SYMBOL = '" + mstrFCsymbol + "' ";
                                    //        strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNo + "' ";
                                    //        strSQL = strSQL + "AND COMP_VOUCHER_POSITION = " + lngPosition + " ";
                                    //        cmdInsert.CommandText = strSQL;
                                    //        cmdInsert.ExecuteNonQuery();
                                    //        blnMultiple = true;
                                    //    }
                                }
                                else
                                {
                                    strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, lngPosition, oAssets[0], "Cr", Utility.Val(oAssets[2]), mlngVType, oAssets[0], strBranchId, 0, oAssets[1], "", "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    //if (mdblCurrRate != 0)
                                    //{
                                    //    strSQL = "UPDATE ACC_VOUCHER SET ";
                                    //    strSQL = strSQL + "FC_CONVERSION_RATE = " + mdblCurrRate + ", ";
                                    //    strSQL = strSQL + "VOUCHER_CURRENCY_SYMBOL = '" + mstrFCsymbol + "' ";
                                    //    strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNo + "' ";
                                    //    strSQL = strSQL + "AND COMP_VOUCHER_POSITION = " + lngPosition + " ";
                                    //    cmdInsert.CommandText = strSQL;
                                    //    cmdInsert.ExecuteNonQuery();
                                    //    blnMultiple = true;
                                    //}
                                }

                            }

                        }




                        if (strRefType != Utility.gcEND_OF_LIST)
                        {
                            if (DGsalesOrder != "")
                            {
                                string[] words = DGsalesOrder.Split('~');
                                foreach (string strSalesOrder in words)
                                {
                                    string[] ooCost = strSalesOrder.Split('|');
                                    if (ooCost[0] != "")
                                    {
                                        strSQL = "SELECT SUM(BILL_QUANTITY) AS QTY FROM ACC_BILL_TRAN_PROCESS ";
                                        strSQL = strSQL + "WHERE AGST_COMP_REF_NO = '" + ooCost[0] + "'";
                                        cmdInsert.CommandText = strSQL;
                                        rsget = cmdInsert.ExecuteReader();
                                        if (rsget.Read())
                                        {

                                            if (Utility.Val(rsget["QTY"].ToString()) == 0)
                                            {
                                                rsget.Close();
                                                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
                                                strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost[0] + "'";
                                                cmdInsert.CommandText = strSQL;
                                                cmdInsert.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                rsget.Close();
                                                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 0 ";
                                                strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost[0] + "'";
                                                cmdInsert.CommandText = strSQL;
                                                cmdInsert.ExecuteNonQuery();
                                            }
                                        }

                                        else
                                        {
                                            rsget.Close();
                                        }

                                        strSQL = "INSERT INTO ACC_VOUCHER_JOIN(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID) ";
                                        strSQL = strSQL + "VALUES(";
                                        strSQL = strSQL + "'" + mstrRefNo + "','" + ooCost[0] + "','" + strBranchId + "'";
                                        strSQL = strSQL + ")";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }

                                }
                            }
                        }
                    }
                    cmdInsert.Transaction.Commit();

                    gcnMain.Close();
                    return "Updated...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }
        #endregion
        #region "Sales Return
        public string mSaveSalesReturn(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger,
                                     double dblNetAmount, double dblTotalAmount, double dblAddAmount, double dblLessAmount, string strRefType,
                                     long lngAgstRef, long mlngIsInvEffinDirSalesInv, string strNarrations,
                                     string strBranchId, string vstrGodownName, long mlngCashFlow, long mlngIsChqueCash, string DGSalesGrid,
                                     string DGsalesOrder, string DGVector, string DGBillWise, string DGAddLess, bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool blngNumberMethod,string strSalesRep)
        {

            string strDRCR = "";
            string strBillKey, strItemName, strItemBangla, strAddLess, strBatchNo = "", strUOm, strPer, strGodownName, strBillAgnstKey = "", strPreRefNo = "", strBillTranKey = "", strGift = "", strbatch = "";
            double dblqty = 0, dblRate, dblBonusQty, dblAltWhere = 1, dblTotalCost = 1, dblCostPrice, dblCredit;
            long lngloop = 1, lngPosition = 1;
            bool blnMultiple = false;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();



                    if (strRefType != Utility.gcEND_OF_LIST)
                    {
                        if (mlngVType == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
                        {
                            if (strRefType == "Sales Invoice")
                            {
                                lngAgstRef = (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE;
                            }
                            else
                            {
                                lngAgstRef = (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE_POS;
                            }
                        }
                        else if (mlngVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_RETURN)
                        {
                            lngAgstRef = (int)Utility.VOUCHER_TYPE.vtPURCHASE_RETURN;
                        }
                    }
                    else
                    {
                        lngAgstRef = 0;
                    }
                    if (strSalesRep == Utility.gcEND_OF_LIST)
                    {
                        strSalesRep = "";
                    }

                    SqlDataReader rsget;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;


                    strSQL = Voucher.gInsertCompanyVoucher(strRefNo, mlngVType, strDate, strMonthID, strDueDate, strLedgerName, dblNetAmount, dblNetAmount, dblAddAmount, dblLessAmount, lngAgstRef, strNarrations,
                                                        strBranchId, 0, "", strSalesRep, "", "", "", "", "");

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DGVector != "")
                    {
                        string[] words = DGVector.Split('~');
                        foreach (string strVector in words)
                        {
                            string[] ooCost = strVector.Split('|');
                            if (ooCost[0] != "")
                            {
                                strSQL = Voucher.mInsertVector(strRefNo, ooCost[1].ToString(), ooCost[2].ToString(), strDate, strLedgerName, "Cr", lngPosition, lngPosition, 1, ooCost[0].ToString(), Utility.Val(ooCost[3].ToString()), 0, "", mlngVType);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                if (mlngVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_RETURN)
                                {
                                    strSQL = Voucher.mInsertVector(strRefNo, ooCost[1].ToString(), ooCost[2].ToString(), strDate, strLedgerName, "Cr", lngPosition, lngPosition, 2, ooCost[0].ToString(), Utility.Val(ooCost[3].ToString()), 0, "", mlngVType);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                else
                                {
                                    strSQL = Voucher.mInsertVector(strRefNo, ooCost[1].ToString(), ooCost[2].ToString(), strDate, strLedgerName, "Dr", lngPosition, lngPosition, 2, ooCost[0].ToString(), Utility.Val(ooCost[3].ToString()), 0, "", mlngVType);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                lngPosition += 1;
                            }

                        }
                    }


                    strSQL = Voucher.gInteractInvInsertMaster(strLedgerName, strRefNo, mlngVType, strDate, strBranchId, strNarrations);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DGBillWise != "")
                    {
                        int intbillpos = 1;
                        string strAgstRefNo = "";
                        string[] words = DGBillWise.Split('~');
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('|');
                            if (ooCost[0] != "")
                            {
                                strAgstRefNo = strBranchId + ooCost[1].ToString();
                                strSQL = Voucher.gInsertBillWise(strBranchId, strRefNo, ooCost[2].ToString(), mlngVType, strLedgerName, intbillpos, ooCost[0].ToString(),
                                                                    Utility.Val(ooCost[3].ToString()), ooCost[4].ToString(), strAgstRefNo, intbillpos);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                intbillpos += 1;
                            }
                        }
                        if (mlngVType == (long)(Utility.VOUCHER_TYPE.vtSALES_RETURN))
                        {
                            strDRCR = "Cr";
                        }
                        else
                        {
                            strDRCR = "Dr";
                        }

                        strSQL = Voucher.gInsertBillWise(strBranchId, strRefNo, strDate, mlngVType, strLedgerName, 0, "New Ref", dblNetAmount, strDRCR, Utility.Mid(strRefNo, 2, strRefNo.Length - 2), 0, strDueDate);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    else
                    {
                        if (mlngVType == (long)(Utility.VOUCHER_TYPE.vtSALES_RETURN))
                        {
                            strDRCR = "Cr";
                        }
                        else
                        {
                            strDRCR = "Dr";
                        }

                        strSQL = Voucher.gInsertBillWise(strBranchId, strRefNo, strDate, mlngVType, strLedgerName, 0, "New Ref", dblNetAmount, strDRCR, Utility.Mid(strRefNo, 2, strRefNo.Length - 2), 0, strDueDate);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }


                    if (DGSalesGrid != "")
                    {

                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split('|');
                            if (ooCost[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                                strItemName = ooCost[0].ToString();
                                strItemBangla = "";
                                //trItemDesc = ooCost[1].ToString();
                                strGodownName = vstrGodownName;
                                dblqty = Utility.Val(ooCost[1].ToString());
                                dblRate = Utility.Val(ooCost[2].ToString());
                                dblTotalAmount = Utility.Val(ooCost[4].ToString());
                                strUOm = ooCost[3].ToString();
                                strPer = ooCost[3].ToString();
                                dblBonusQty = Utility.Val(ooCost[5].ToString());
                                if (ooCost[6].ToString() != "")
                                {
                                    strbatch = ooCost[6].ToString();
                                }
                                else
                                {
                                    strbatch = "";
                                }
                                dblCostPrice = Utility.Val(ooCost[7].ToString());
                                strBillTranKey = ooCost[9].ToString();
                                strGift = "";
                                //dblBonusQty = 0;
                                strAddLess = "";
                                dblAltWhere = 1;
                                //If InStr(1, .TextMatrix(lngloop, 3), strPer) = 0 Then
                                //    dblAltWhere = gdblDenomation(Replace$(.TextMatrix(lngloop, 1), "'", "''"))
                                //End If
                                if (mlngVType == (long)(Utility.VOUCHER_TYPE.vtSALES_RETURN))
                                {
                                    strDRCR = "Cr";
                                }
                                else
                                {
                                    strDRCR = "Dr";
                                }
                                strSQL = Voucher.gInsertBillTran(strBillKey, strRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblBonusQty, strUOm, dblRate, dblTotalAmount, strAddLess,
                                                                    0, dblTotalAmount, strDRCR, lngloop, strBranchId, Utility.gstrBaseCurrency, strPer, "", "", strbatch, "", "", strItemBangla);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                strSQL = Voucher.gInsertBillTranProcess(strRefNo + lngloop.ToString().PadLeft(4, '0'), strBranchId, lngloop, strRefNo, strRefNo, mlngVType, strDate,
                                                                        strItemName, strGodownName, dblqty, strUOm, strRefNo + lngloop.ToString().PadLeft(4, '0'), 0, 0, strPer);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                if (strRefType != Utility.gcEND_OF_LIST)
                                {
                                    strSQL = "SELECT COMP_REF_NO,BILL_TRAN_KEY,STOCKITEM_NAME,BILL_QUANTITY FROM ACC_BILL_TRAN ";
                                    strSQL = strSQL + "WHERE BILL_TRAN_KEY = '" + strBillTranKey + "'";
                                    cmdInsert.CommandText = strSQL;
                                    rsget = cmdInsert.ExecuteReader();
                                    if (rsget.Read())
                                    {
                                        strPreRefNo = rsget["COMP_REF_NO"].ToString();
                                        strBillAgnstKey = rsget["BILL_TRAN_KEY"].ToString();
                                    }
                                    rsget.Close();
                                    strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngPosition, strRefNo, strPreRefNo, lngAgstRef, strDate, strItemName, strGodownName, dblqty * -1, strUOm, strBillAgnstKey, 0, 0, strPer);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                if (mlngVType == (long)(Utility.VOUCHER_TYPE.vtSALES_RETURN))
                                {
                                    strSQL = Voucher.gInventoryInsertTranPurchases(strRefNo, strRefNo + lngloop.ToString().PadLeft(4, '0'), lngloop, dblCostPrice, dblqty * dblCostPrice, lngAgstRef, strItemName, strGodownName, "I", dblqty + dblBonusQty, mlngVType, strDate, strBranchId, strBatchNo, strPer, strUOm);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                else if (mlngVType == (long)(Utility.VOUCHER_TYPE.vtPURCHASE_RETURN))
                                {
                                    strSQL = Voucher.gInventoryInsertPurchaseReturn(strRefNo, strBillKey, lngloop, Math.Round(dblRate, 2), -1 * dblTotalCost, lngAgstRef, strItemName, strGodownName,
                                                                                   "O", dblqty * -1, dblBonusQty * -1, dblCostPrice, mlngVType, strDate, strBranchId, strbatch, 0, strPer, strUOm,0,(int)mlngVType) ;
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    strSQL = "UPDATE INV_TRAN SET ";
                                    strSQL = strSQL + "OUTWARD_COST_AMOUNT = " + dblRate * dblqty*-1 + " ";
                                    strSQL = strSQL + ",OUTWARD_SALES_AMOUNT = " + dblRate * dblqty * -1 + " ";
                                    strSQL = strSQL + ",INV_TRAN_AMOUNT = " + dblRate * dblqty*-1 + " ";
                                    strSQL = strSQL + "WHERE INV_TRAN_KEY='" + strBillKey + "' ";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }

                            }
                            lngPosition += 1;
                            lngloop += 1;
                        }
                    }
                    dblCredit = dblNetAmount;
                    if (mlngVType == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
                    {
                        if (mlngIsChqueCash == 0)
                        {
                            strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 1, strLedgerName, "Cr", dblCredit, mlngVType, strSalesLedger, strBranchId, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        else
                        {
                            strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 1, strLedgerName, "Cr", dblCredit, mlngVType, strSalesLedger, strBranchId, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 2, strSalesLedger, "Dr", dblCredit, mlngVType, strLedgerName, strBranchId, 2, "", "", "", "", "", strbatch);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    else if (mlngVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_RETURN)
                    {
                        if (mlngIsChqueCash == 0)
                        {
                            strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 1, strLedgerName, "Dr", dblCredit, mlngVType, strSalesLedger, strBranchId, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        else
                        {
                            strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 1, strLedgerName, "Dr", dblCredit, mlngVType, strSalesLedger, strBranchId, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, 2, strSalesLedger, "Cr", dblCredit, mlngVType, strLedgerName, strBranchId, 2, "", "", "", "", "", strbatch);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }




                    if (strRefType != Utility.gcEND_OF_LIST)
                    {
                        if (DGsalesOrder != "")
                        {
                            string[] words1 = DGsalesOrder.Split('~');
                            foreach (string strSalesOrder in words1)
                            {
                                string[] ooCost1 = strSalesOrder.Split('|');
                                if (ooCost1[0] != "")
                                {
                                    strSQL = "SELECT SUM(BILL_QUANTITY) AS QTY FROM ACC_BILL_TRAN_PROCESS ";
                                    strSQL = strSQL + "WHERE AGST_COMP_REF_NO = '" + ooCost1[0] + "'";
                                    cmdInsert.CommandText = strSQL;
                                    rsget = cmdInsert.ExecuteReader();
                                    if (rsget.Read())
                                    {

                                        if (Utility.Val(rsget["QTY"].ToString()) == 0)
                                        {
                                            rsget.Close();
                                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
                                            strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost1[0] + "'";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            rsget.Close();
                                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 0 ";
                                            strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost1[0] + "'";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        rsget.Close();
                                    }

                                    strSQL = "INSERT INTO ACC_VOUCHER_JOIN(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID) ";
                                    strSQL = strSQL + "VALUES(";
                                    strSQL = strSQL + "'" + strRefNo + "','" + ooCost1[0] + "','" + strBranchId + "'";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }

                        }
                    }




                    if (DGAddLess != "")
                    {
                        string[] words1 = DGAddLess.Split('~');
                        foreach (string ooassets in words1)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                strSQL = Voucher.gInsertADDLESS(strRefNo, oAssets[0], strDate, dblAddAmount, dblLessAmount, strBranchId);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                if (dblLessAmount > 0)
                                {
                                    strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, lngPosition, oAssets[0], "Dr", dblLessAmount, mlngVType, strSalesLedger, strBranchId, 0, "-", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    dblLessAmount = 0;
                                }
                                else
                                {
                                    if (dblAddAmount != 0)
                                    {
                                        strSQL = Voucher.gInsertSalesVoucher(strRefNo, strDate, lngPosition, oAssets[0], "Cr", dblAddAmount, mlngVType, strLedgerName, strBranchId, 0, "+", "", "", "", "", strbatch);
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                    dblAddAmount = 0;
                                }
                            }

                        }

                    }

                    if (blngNumberMethod == true)
                    {
                        strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inserted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }

        public string mUpdateSalesReturn(string strDeComID, string mstrRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName, string strSalesLedger,
                                     double dblNetAmount, double dblTotalAmount, double dblAddAmount, double dblLessAmount, string strRefType,
                                     long lngAgstRef, long mlngIsInvEffinDirSalesInv, string strNarrations,
                                     string strBranchId, string vstrGodownName, long mlngCashFlow, long mlngIsChqueCash, string DGSalesGrid,
                                     string DGsalesOrder, string DGVector, string DGBillWise, string DGAddLess, bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, string strSalesRep)
        {

            string strDRCR = "";
            string strBillKey, strItemName, strItemBangla, strAddLess, strBatchNo = "", strUOm, strPer, strGodownName, strBillAgnstKey = "", strPreRefNo = "", strBillTranKey = "", strGift = "", strbatch = "";
            double dblqty = 0, dblRate, dblBonusQty, dblTotalCost = 1, dblCostPrice, dblCredit, dblAltWhere = 1;
            long lngloop = 1, lngPosition = 1;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();



                    if (strRefType != Utility.gcEND_OF_LIST)
                    {
                        if (mlngVType == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
                        {
                            if (strRefType == "Sales Invoice")
                            {
                                lngAgstRef = (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE;
                            }
                            else
                            {
                                lngAgstRef = (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE_POS;
                            }
                        }
                        else if (mlngVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_RETURN)
                        {
                            lngAgstRef = (int)Utility.VOUCHER_TYPE.vtPURCHASE_RETURN;
                        }
                    }
                    else
                    {
                        lngAgstRef = 0;
                    }
                    if (strSalesRep == Utility.gcEND_OF_LIST)
                    {
                        strSalesRep = "";
                    }




                    SqlDataReader rsget;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;


                    //'All Delete Code Here
                    strSQL = "DELETE FROM ACC_BILL_TRAN WHERE COMP_REF_NO = '" + mstrRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO = '" + mstrRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_VOUCHER WHERE COMP_REF_NO = '" + mstrRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM ACC_ADD_LESS WHERE ADD_LESS_COMP_REF_NO = '" + mstrRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_VOUCHER_JOIN WHERE VOUCHER_JOIN_PRIMARY_REF = '" + mstrRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM ACC_BILL_WISE WHERE COMP_REF_NO = '" + mstrRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //strSQL = "DELETE FROM INV_TRAN_HARDWARE_SL_REF WHERE COMP_REF_NO = '" + mstrRefNo + "' ";
                    //cmdInsert.CommandText = strSQL;
                    //cmdInsert.ExecuteNonQuery();


                    strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO = '" + mstrRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO = '" + mstrRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM VECTOR_TRANSACTION WHERE COMP_REF_NO = '" + mstrRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();



                    strSQL = "UPDATE ACC_COMPANY_VOUCHER SET ";
                    strSQL = strSQL + "LEDGER_NAME = '" + strLedgerName + "',";
                    strSQL = strSQL + "SALES_REP = '" + strSalesRep + "',";
                    strSQL = strSQL + "BRANCH_ID = '" + strBranchId + "',";
                    strSQL = strSQL + "COMP_VOUCHER_DATE = " + Utility.cvtSQLDateString(strDate) + ",";
                    strSQL = strSQL + "COMP_VOUCHER_MONTH_ID = '" + strMonthID + "',";
                    strSQL = strSQL + "COMP_VOUCHER_NARRATION = '" + strNarrations + "',";
                    strSQL = strSQL + "COMP_VOUCHER_AMOUNT = " + dblTotalAmount + ",";
                    strSQL = strSQL + "COMP_VOUCHER_NET_AMOUNT = " + dblNetAmount + ",";
                    strSQL = strSQL + "COMP_VOUCHER_ADD_AMOUNT = " + dblAddAmount + ",";
                    strSQL = strSQL + "COMP_VOUCHER_LESS_AMOUNT = " + dblLessAmount + ",";
                    strSQL = strSQL + "COMP_VOUCHER_DUE_DATE = " + Utility.cvtSQLDateString(strDueDate) + ",";
                    strSQL = strSQL + "INSERT_DATE = " + Utility.cvtSQLDateString(DateTime.Today.ToString("dd/MM/yyyy"));

                    strSQL = strSQL + " WHERE COMP_REF_NO = '" + mstrRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = Voucher.gInteractInvInsertMaster(strLedgerName, mstrRefNo, mlngVType, strDate, strBranchId, strNarrations);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DGSalesGrid != "")
                    {

                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split('|');
                            if (ooCost[0] != "")
                            {
                                strBillKey = mstrRefNo + lngloop.ToString().PadLeft(4, '0');
                                strItemName = ooCost[0].ToString();
                                //dblCostPrice = Utility.gdblGetCostPrice(strItemName, strDate);
                                //strItemBangla = Utility.gGetItemNameBangla (ooCost[1].ToString());
                                strItemBangla = "";
                                //trItemDesc = ooCost[1].ToString();
                                strGodownName = vstrGodownName;
                                dblqty = Utility.Val(ooCost[1].ToString());
                                dblRate = Utility.Val(ooCost[2].ToString());
                                dblTotalAmount = Utility.Val(ooCost[4].ToString());
                                strUOm = ooCost[3].ToString();
                                strPer = ooCost[3].ToString();
                                dblBonusQty = Utility.Val(ooCost[5].ToString());
                                if (ooCost[6].ToString() != "")
                                {
                                    strbatch = ooCost[6].ToString();
                                }
                                else
                                {
                                    strbatch = "";
                                }
                                dblCostPrice = Utility.Val(ooCost[7].ToString());
                                strBillTranKey = ooCost[8].ToString();
                                strGift = ooCost[9].ToString();

                                strAddLess = "";
                                dblAltWhere = 1;
                                //If InStr(1, .TextMatrix(lngloop, 3), strPer) = 0 Then
                                //    dblAltWhere = gdblDenomation(Replace$(.TextMatrix(lngloop, 1), "'", "''"))
                                //End If
                                if (mlngVType == (long)(Utility.VOUCHER_TYPE.vtSALES_RETURN))
                                {
                                    strDRCR = "Cr";
                                }
                                else
                                {
                                    strDRCR = "Dr";
                                }
                                strSQL = Voucher.gInsertBillTran(strBillKey, mstrRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblBonusQty, strUOm, dblRate, dblTotalAmount, strAddLess,
                                                                    0, dblTotalAmount, strDRCR, lngloop, strBranchId, Utility.gstrBaseCurrency, strPer, "", "", strbatch, "", "", strItemBangla);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, mstrRefNo, strRefNo, mlngVType, strDate,
                                                                        strItemName, strGodownName, dblqty, strUOm, strBillKey, 0, 0, strPer);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                if (strRefType != Utility.gcEND_OF_LIST)
                                {
                                    strSQL = "SELECT COMP_REF_NO,BILL_TRAN_KEY,STOCKITEM_NAME,BILL_QUANTITY FROM ACC_BILL_TRAN ";
                                    strSQL = strSQL + "WHERE BILL_TRAN_KEY = '" + strBillTranKey + "'";
                                    cmdInsert.CommandText = strSQL;
                                    rsget = cmdInsert.ExecuteReader();
                                    if (rsget.Read())
                                    {
                                        strPreRefNo = rsget["COMP_REF_NO"].ToString();
                                        strBillAgnstKey = rsget["BILL_TRAN_KEY"].ToString();
                                    }
                                    rsget.Close();
                                    strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngPosition, mstrRefNo, strPreRefNo, lngAgstRef, strDate, strItemName, strGodownName, dblqty * -1, strUOm, strBillAgnstKey, 0, 0, strPer);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                if (mlngVType == (long)(Utility.VOUCHER_TYPE.vtSALES_RETURN))
                                {
                                    strSQL = Voucher.gInventoryInsertTranSales(mstrRefNo, strBillKey, lngloop, dblCostPrice, dblqty * dblCostPrice, lngAgstRef, strItemName, strGodownName, "I", dblqty + dblBonusQty, mlngVType, strDate, strBranchId, strBatchNo, strPer, strUOm);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                else if (mlngVType == (long)(Utility.VOUCHER_TYPE.vtPURCHASE_RETURN))
                                {
                                    strSQL = Voucher.gInventoryInsertPurchaseReturn(mstrRefNo, strBillKey, lngloop, Math.Round(dblRate, 2), -1 * dblTotalCost, lngAgstRef, strItemName, strGodownName,
                                                                                   "O", dblqty * -1, dblBonusQty * -1, dblCostPrice, mlngVType, strDate, strBranchId, strbatch, 0, strPer, strUOm, 0, (int)mlngVType);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    strSQL = "UPDATE INV_TRAN SET ";
                                    strSQL = strSQL + "OUTWARD_COST_AMOUNT = " + dblRate * dblqty * -1 + " ";
                                    strSQL = strSQL + ",OUTWARD_SALES_AMOUNT = " + dblRate * dblqty * -1 + " ";
                                    strSQL = strSQL + ",INV_TRAN_AMOUNT = " + dblRate * dblqty * -1 + " ";
                                    strSQL = strSQL + "WHERE INV_TRAN_KEY='" + strBillKey + "' ";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }


                            }
                            lngPosition += 1;
                            lngloop += 1;
                        }
                    }
                    dblCredit = dblNetAmount;
                    if (mlngVType == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
                    {
                        if (mlngIsChqueCash == 0)
                        {
                            strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 1, strLedgerName, "Cr", dblCredit, mlngVType, strSalesLedger, strBranchId, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        else
                        {
                            strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 1, strLedgerName, "Cr", dblCredit, mlngVType, strSalesLedger, strBranchId, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 2, strSalesLedger, "Dr", dblCredit, mlngVType, strLedgerName, strBranchId, 2, "", "", "", "", "", strbatch);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    else if (mlngVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_RETURN)
                    {
                        if (mlngIsChqueCash == 0)
                        {
                            strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 1, strLedgerName, "Dr", dblCredit, mlngVType, strSalesLedger, strBranchId, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        else
                        {
                            strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 1, strLedgerName, "Dr", dblCredit, mlngVType, strSalesLedger, strBranchId, 0, "", "", "", "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, 2, strSalesLedger, "Cr", dblCredit, mlngVType, strLedgerName, strBranchId, 2, "", "", "", "", "", strbatch);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }




                    if (strRefType != Utility.gcEND_OF_LIST)
                    {
                        if (DGsalesOrder != "")
                        {
                            string[] words1 = DGsalesOrder.Split('~');
                            foreach (string strSalesOrder in words1)
                            {
                                string[] ooCost1 = strSalesOrder.Split('|');
                                if (ooCost1[0] != "")
                                {
                                    strSQL = "SELECT SUM(BILL_QUANTITY) AS QTY FROM ACC_BILL_TRAN_PROCESS ";
                                    strSQL = strSQL + "WHERE AGST_COMP_REF_NO = '" + ooCost1[0] + "'";
                                    cmdInsert.CommandText = strSQL;
                                    rsget = cmdInsert.ExecuteReader();
                                    if (rsget.Read())
                                    {

                                        if (Utility.Val(rsget["QTY"].ToString()) == 0)
                                        {
                                            rsget.Close();
                                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
                                            strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost1[0] + "'";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            rsget.Close();
                                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 0 ";
                                            strSQL = strSQL + "WHERE COMP_REF_NO = '" + ooCost1[0] + "'";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        rsget.Close();
                                    }

                                    strSQL = "INSERT INTO ACC_VOUCHER_JOIN(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID) ";
                                    strSQL = strSQL + "VALUES(";
                                    strSQL = strSQL + "'" + mstrRefNo + "','" + ooCost1[0] + "','" + strBranchId + "'";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }

                        }
                    }




                    if (DGAddLess != "")
                    {
                        string[] words1 = DGAddLess.Split('~');
                        foreach (string ooassets in words1)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                strSQL = Voucher.gInsertADDLESS(mstrRefNo, oAssets[0], strDate, dblAddAmount, dblLessAmount, strBranchId);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                if (dblLessAmount > 0)
                                {
                                    strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, lngPosition, oAssets[0], "Dr", dblLessAmount, mlngVType, strSalesLedger, strBranchId, 0, "-", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    dblLessAmount = 0;
                                }
                                else
                                {
                                    if (dblAddAmount != 0)
                                    {
                                        strSQL = Voucher.gInsertSalesVoucher(mstrRefNo, strDate, lngPosition, oAssets[0], "Cr", dblAddAmount, mlngVType, strLedgerName, strBranchId, 0, "+", "", "", "", "", strbatch);
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                    dblAddAmount = 0;
                                }
                            }

                        }

                    }

                    //if (DGAddLess != "")
                    //{

                    //    strSQL = Voucher.gInsertADDLESS(strRefNo, strLedgerName, strDate, dblAddAmount, dblLessAmount, strBranchId);
                    //    cmdInsert.CommandText = strSQL;
                    //    cmdInsert.ExecuteNonQuery();
                    //}
                    //}
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Updated...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }
        

        #endregion
        #region "Save Sales Quotation"
        public string mSaveSalesQuotation(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                        double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency,
                                        string strAttention, string strDesignation, string strAdrress,
                                        string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                        bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool mblnNumbMethod)
        {
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "INSERT INTO ACC_QUOTATION_MASTER";
                    strSQL = strSQL + "(QUOTE_REF_NO,PARTY_NAME,ATTENTION,DESIGNATION,QUOTE_ADDRESS1,QUOTE_DATE,";
                    strSQL = strSQL + "QUOTE_DELIVERY,QUOTE_TERM_OF_PAYMENTS,QUOTE_SUPPORT,";

                    if (dteValidaty != "")
                    {
                        strSQL = strSQL + "QUOTE_VALIDITY_DATE,";
                    }
                    strSQL = strSQL + "QUOTE_OTHERS,QUOTE_AMOUNT";
                    strSQL = strSQL + ") ";
                    strSQL = strSQL + "VALUES";
                    strSQL = strSQL + "(";
                    strSQL = strSQL + "'" + strRefNo + "',";
                    strSQL = strSQL + "'" + strLedgerName + "',";
                    strSQL = strSQL + "'" + strAttention + "',";
                    strSQL = strSQL + "'" + strDesignation + "',";
                    strSQL = strSQL + "'" + strAdrress + "',";
                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strDate) + ",";
                    strSQL = strSQL + "'" + strDelivery + "',";
                    strSQL = strSQL + "'" + strPayment + "',";
                    strSQL = strSQL + "'" + strSupport + "',";
                    if (dteValidaty != "")
                    {
                        strSQL = strSQL + "" + Utility.cvtSQLDateString(dteValidaty) + ",";
                    }
                    strSQL = strSQL + "'" + strOtherTerms + "',";
                    strSQL = strSQL + "'" + dblNetAmount + "'";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    if (DG != "")
                    {
                        string strBillKey = "", strItemName = "", strPer = "";
                        long lngBillPosition = 1, lngloop = 1;
                        double dblqty = 0, dblRate = 0, dblDebitValue;
                        string[] words = DG.Split('~');
                        foreach (string strValue in words)
                        {
                            string[] ooValue = strValue.Split(',');
                            if (ooValue[0] != "")
                            {
                                strBillKey = strRefNo + lngBillPosition.ToString().PadRight(4, '0');
                                strItemName = ooValue[0].ToString();
                                dblqty = Utility.Val(ooValue[1].ToString());
                                strPer = ooValue[2].ToString();
                                dblRate = Utility.Val(ooValue[3].ToString());
                                dblDebitValue = Utility.Val(ooValue[4].ToString());
                                strSQL = "INSERT INTO ACC_QUOTATION_TRAN";
                                strSQL = strSQL + "(QUOTE_REF_NO,QUOTE_TRAN_POSITION,";
                                strSQL = strSQL + "STOCKITEM_NAME,QUOTE_QUANTITY,QUOTE_RATE,";
                                strSQL = strSQL + "QUOTE_UOM,QUOTE_PER,QUOTE_AMOUNT";
                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES";
                                strSQL = strSQL + "(";
                                strSQL = strSQL + "'" + strRefNo + "',";
                                strSQL = strSQL + " " + lngBillPosition + ",";
                                strSQL = strSQL + "'" + strItemName + "',";
                                strSQL = strSQL + "" + dblqty + ",";
                                strSQL = strSQL + "" + dblRate + ",";
                                strSQL = strSQL + " '" + strPer + "',";
                                strSQL = strSQL + " '" + strPer + "',";
                                strSQL = strSQL + "" + dblDebitValue + "";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                lngBillPosition += 1;
                                lngloop += 1;
                            }
                        }
                        if (mblnNumbMethod == true)
                        {
                            strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        cmdInsert.Transaction.Commit();
                    }


                    gcnMain.Close();
                    return "Inserted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }

        public string mUpdateeSalesQuotation(string strDeComID, string strOldRefNo, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                         double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency,
                                         string strAttention, string strDesignation, string strAdrress,
                                         string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                         bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, bool mblnNumbMethod)
        {
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM ACC_QUOTATION_TRAN WHERE QUOTE_REF_NO='" + strOldRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM ACC_QUOTATION_MASTER WHERE QUOTE_REF_NO='" + strOldRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strSQL = "INSERT INTO ACC_QUOTATION_MASTER";
                    strSQL = strSQL + "(QUOTE_REF_NO,PARTY_NAME,ATTENTION,DESIGNATION,QUOTE_ADDRESS1,QUOTE_DATE,";
                    strSQL = strSQL + "QUOTE_DELIVERY,QUOTE_TERM_OF_PAYMENTS,QUOTE_SUPPORT,";

                    if (dteValidaty != "")
                    {
                        strSQL = strSQL + "QUOTE_VALIDITY_DATE,";
                    }
                    strSQL = strSQL + "QUOTE_OTHERS,QUOTE_AMOUNT";
                    strSQL = strSQL + ") ";
                    strSQL = strSQL + "VALUES";
                    strSQL = strSQL + "(";
                    strSQL = strSQL + "'" + strRefNo + "',";
                    strSQL = strSQL + "'" + strLedgerName + "',";
                    strSQL = strSQL + "'" + strAttention + "',";
                    strSQL = strSQL + "'" + strDesignation + "',";
                    strSQL = strSQL + "'" + strAdrress + "',";
                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strDate) + ",";
                    strSQL = strSQL + "'" + strDelivery + "',";
                    strSQL = strSQL + "'" + strPayment + "',";
                    strSQL = strSQL + "'" + strSupport + "',";
                    if (dteValidaty != "")
                    {
                        strSQL = strSQL + "" + Utility.cvtSQLDateString(dteValidaty) + ",";
                    }
                    strSQL = strSQL + "'" + strOtherTerms + "',";
                    strSQL = strSQL + "'" + dblNetAmount + "'";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    if (DG != "")
                    {
                        string strBillKey = "", strItemName = "", strPer = "";
                        long lngBillPosition = 1, lngloop = 1;
                        double dblqty = 0, dblRate = 0, dblDebitValue;
                        string[] words = DG.Split('~');
                        foreach (string strValue in words)
                        {
                            string[] ooValue = strValue.Split(',');
                            if (ooValue[0] != "")
                            {
                                strBillKey = strRefNo + lngBillPosition.ToString().PadRight(4, '0');
                                strItemName = ooValue[0].ToString();
                                dblqty = Utility.Val(ooValue[1].ToString());
                                strPer = ooValue[2].ToString();
                                dblRate = Utility.Val(ooValue[3].ToString());
                                dblDebitValue = Utility.Val(ooValue[4].ToString());
                                strSQL = "INSERT INTO ACC_QUOTATION_TRAN";
                                strSQL = strSQL + "(QUOTE_REF_NO,QUOTE_TRAN_POSITION,";
                                strSQL = strSQL + "STOCKITEM_NAME,QUOTE_QUANTITY,QUOTE_RATE,";
                                strSQL = strSQL + "QUOTE_UOM,QUOTE_PER,QUOTE_AMOUNT";
                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES";
                                strSQL = strSQL + "(";
                                strSQL = strSQL + "'" + strRefNo + "',";
                                strSQL = strSQL + " " + lngBillPosition + ",";
                                strSQL = strSQL + "'" + strItemName + "',";
                                strSQL = strSQL + "" + dblqty + ",";
                                strSQL = strSQL + "" + dblRate + ",";
                                strSQL = strSQL + " '" + strPer + "',";
                                strSQL = strSQL + " '" + strPer + "',";
                                strSQL = strSQL + "" + dblDebitValue + "";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                lngBillPosition += 1;
                                lngloop += 1;
                            }
                        }
                        if (mblnNumbMethod == true)
                        {
                            strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        cmdInsert.Transaction.Commit();
                    }


                    gcnMain.Close();
                    return "Updated...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }


        #endregion
        #region "Batch"
        public string mSavebatch(string strDeComID, string strLogNo, string strStartDate, string strEndDate, string strExpireDate, string strLedgerName, string strstatus,
                                 string strNarrations, string strBatchSize, string strManuDate)
        {
            //int intstatus = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    //if (strstatus=="Active")
                    //{
                    //    intstatus = 0;
                    //}
                    //else if (strstatus == "Suspend")
                    //{
                    //    intstatus = 1;
                    //}
                    //else
                    //{
                    //    intstatus = 0;
                    //}

                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "INSERT INTO INV_BATCH ";
                    strSQL = strSQL + "(INV_LOG_NO,INV_LOG_START,INV_LOG_END,INV_LOG_EXPIRE,LEDGER_NAME,INV_LOG_STATUS,INV_LOG_SIZE,INV_LOG_MANU_DATE";
                    strSQL = strSQL + ") ";
                    strSQL = strSQL + "VALUES";
                    strSQL = strSQL + "(";
                    strSQL = strSQL + "'" + strLogNo + "',";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strStartDate) + " ,";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strEndDate) + " ,";
                    if (strExpireDate != "")
                    {
                        strSQL = strSQL + " " + Utility.cvtSQLDateString(strExpireDate) + ",";
                    }
                    else
                    {
                        strSQL = strSQL + "NUll,";
                    }

                    strSQL = strSQL + "'" + strLedgerName + "',";
                    strSQL = strSQL + "'" + strstatus + "',";
                    strSQL = strSQL + "'" + strBatchSize + "',";
                    if (strManuDate != "")
                    {
                        strSQL = strSQL + " " + Utility.cvtSQLDateString(strManuDate) + " ";
                    }
                    else
                    {
                        strSQL = strSQL + "NUll";
                    }
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();


                    gcnMain.Close();
                    return "Inserted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }

        public string mSUpdatebatch(string strDeComID, string msstrOldNo, string strLogNo, string strStartDate, string strEndDate, string strExpireDate, string strLedgerName, string strstatus,
                                string strNarrations, string strBatchSize, string strManuDate)
        {
            //int intstatus = 0;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    //if (strstatus == "Active")
                    //{
                    //    intstatus = 0;
                    //}
                    //else if (strstatus == "Suspend")
                    //{
                    //    intstatus = 1;
                    //}
                    //else
                    //{
                    //    intstatus = 0;
                    //}

                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    //strSQL = "SELECT INV_LOG_NO FROM INV_BATCH where INV_LOG_NO='" + strLogNo + "' ";
                    //SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                    //drGetGroup = cmd.ExecuteReader();
                    //if (drGetGroup.Read())
                    //{
                    //    strOldNo = drGetGroup["INV_LOG_NO"].ToString();

                    //}
                    //drGetGroup.Close();
                    strSQL = "Update INV_BATCH SET ";
                    strSQL = strSQL + "INV_LOG_NO='" + strLogNo + "' ";
                    strSQL = strSQL + ",INV_LOG_START=" + Utility.cvtSQLDateString(strStartDate) + " ";
                    strSQL = strSQL + ",INV_LOG_END=" + Utility.cvtSQLDateString(strEndDate) + " ";
                    if (strExpireDate != "")
                    {
                        strSQL = strSQL + ",INV_LOG_EXPIRE=" + Utility.cvtSQLDateString(strExpireDate) + " ";
                    }
                    else
                    {
                        strSQL = strSQL + ",INV_LOG_EXPIRE= null ";
                    }
                    strSQL = strSQL + ",LEDGER_NAME='" + strLedgerName + "' ";
                    strSQL = strSQL + ",INV_LOG_STATUS='" + strstatus + "' ";
                    strSQL = strSQL + ",INV_LOG_SIZE='" + strBatchSize + "' ";
                    if (strManuDate != "")
                    {
                        strSQL = strSQL + ",INV_LOG_MANU_DATE=" + Utility.cvtSQLDateString(strManuDate) + " ";
                    }
                    else
                    {
                        strSQL = strSQL + ",INV_LOG_MANU_DATE=null ";
                    }
                    strSQL = strSQL + "WHERE INV_LOG_NO='" + msstrOldNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "Update INV_PRODUCTION_LOG SET ";
                    strSQL = strSQL + "INV_LOG_NO='" + strLogNo + "' ";
                    strSQL = strSQL + "WHERE INV_LOG_NO='" + msstrOldNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "Update INV_MASTER SET ";
                    strSQL = strSQL + "INV_LOG_NO='" + strLogNo + "' ";
                    strSQL = strSQL + "WHERE INV_LOG_NO='" + msstrOldNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "Update INV_TRAN SET ";
                    strSQL = strSQL + "INV_LOG_NO='" + strLogNo + "' ";
                    strSQL = strSQL + "WHERE INV_LOG_NO='" + msstrOldNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "Update ACC_BILL_TRAN SET ";
                    strSQL = strSQL + "INV_LOG_NO='" + strLogNo + "' ";
                    strSQL = strSQL + "WHERE INV_LOG_NO='" + msstrOldNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();

                    gcnMain.Close();
                    return "Updated...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }
        public List<Batch> mDisPlaybatch(string strDeComID, long lngslNo, string Pyear = "")
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Batch> oogrp = new List<Batch>();
            strSQL = "SELECT * FROM INV_BATCH ";
            if (lngslNo != 0)
            {
                strSQL = strSQL + " WHERE INV_SERIAL  = " + lngslNo + "  ";
            }
            if (Pyear != "")
            {
                strSQL = strSQL + " WHERE year(INV_LOG_START) = '" + Pyear + "' ";
            }
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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
                    Batch ogrp = new Batch();
                    ogrp.lngSlno = Convert.ToInt64(drGetGroup["INV_SERIAL"].ToString());
                    ogrp.strLogNo = drGetGroup["INV_LOG_NO"].ToString();
                    ogrp.strStartDate = Convert.ToDateTime(drGetGroup["INV_LOG_START"]).ToString("dd/MM/yyyy");
                    ogrp.strEndDate = Convert.ToDateTime(drGetGroup["INV_LOG_END"]).ToString("dd/MM/yyyy");
                    if (drGetGroup["INV_LOG_EXPIRE"].ToString() != "")
                    {
                        ogrp.strExpireDate = Convert.ToDateTime(drGetGroup["INV_LOG_EXPIRE"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        ogrp.strExpireDate = "";
                    }
                    if (drGetGroup["LEDGER_NAME"].ToString() != "")
                    {
                        ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strLedgerName = "";
                    }
                    ogrp.strStatus = drGetGroup["INV_LOG_STATUS"].ToString();
                    if (drGetGroup["INV_LOG_SIZE"].ToString() != "")
                    {
                        ogrp.lngLogSize = Convert.ToInt64(drGetGroup["INV_LOG_SIZE"]);
                    }

                    if (drGetGroup["INV_LOG_MANU_DATE"].ToString() != "")
                    {
                        ogrp.strManuDate = Convert.ToDateTime(drGetGroup["INV_LOG_MANU_DATE"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        ogrp.strManuDate = "";
                    }

                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }
        public List<ManuProcess> mLoadBatch(string strDeComID, string Pyear = "", string vstrProcessName = "")
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ManuProcess> oogrp = new List<ManuProcess>();
            strSQL = "SELECT * FROM INV_MENU_PROCESS_MAIN ";
            if (vstrProcessName != "")
            {
                strSQL = strSQL + " WHERE PROCESS_NAME LIKE '%" + vstrProcessName + "%' ";
            }
            else if (Pyear != "")
            {
                strSQL = strSQL + " WHERE year(INSERT_DATE) = '" + Pyear + "' ";
            }
            strSQL = strSQL + " ORDER BY PROCESS_NAME ";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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
                    ManuProcess ogrp = new ManuProcess();
                    ogrp.strProcessName = drGetGroup["PROCESS_NAME"].ToString();
                    ogrp.strEntryDate = Convert.ToDateTime(drGetGroup["INSERT_DATE"]).ToString("dd/MM/yyyy");
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }

        public string mDeleteBatchSize(string strDeComID, long lngslNo, string strBatchNo)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();

                    SqlDataReader drGetGroup;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT INV_LOG_NO ";
                    strSQL = strSQL + "FROM INV_TRAN ";
                    strSQL = strSQL + "WHERE  INV_LOG_NO='" + strBatchNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    drGetGroup = cmdInsert.ExecuteReader();
                    if (drGetGroup.Read())
                    {
                        return ("Transaction Found Cannot Delete...");
                    }
                    drGetGroup.Close();

                    strSQL = "SELECT INV_LOG_NO ";
                    strSQL = strSQL + "FROM INV_PRODUCTION_LOG ";
                    strSQL = strSQL + "WHERE  INV_LOG_NO='" + strBatchNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    drGetGroup = cmdInsert.ExecuteReader();
                    if (drGetGroup.Read())
                    {
                        return ("Transaction Found Cannot Delete...");
                    }
                    drGetGroup.Close();


                    strSQL = "DELETE FROM INV_BATCH ";
                    strSQL = strSQL + "WHERE INV_SERIAL = " + lngslNo + " ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return ("Transaction Found Cannot Delete...");
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        #endregion
        #region "Tools"
        public List<DatabaseCompany> mloadDatabaseCompnay(string strDeComID)
        {
            string strSQL, strCompaniId = "";
            SqlDataReader drGetGroup;
            List<DatabaseCompany> oogrp = new List<DatabaseCompany>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT NAME FROM master.dbo.sysdatabases WHERE NAME LIKE 'SMART%' ORDER BY NAME ";
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
                    strCompaniId = drGetGroup["NAME"].ToString() + "~" + strCompaniId;
                }
                drGetGroup.Close();

                if (strCompaniId != "")
                {
                    strCompaniId = strCompaniId.ToString().Substring(0, strCompaniId.Length - 1);

                    string[] words = strCompaniId.Split('~');
                    foreach (string name in words)
                    {
                        if (name.ToString() != "")
                        {
                            strSQL = "SELECT * FROM " + name.ToString() + ".dbo.ACC_COMPANY ";

                            SqlCommand cmd1 = new SqlCommand(strSQL, gcnMain);
                            drGetGroup = cmd1.ExecuteReader();
                            while (drGetGroup.Read())
                            {
                                DatabaseCompany odc = new DatabaseCompany();
                                odc.strComID = drGetGroup["COMPANY_ID"].ToString();
                                odc.strComName = drGetGroup["COMPANY_ID"].ToString() + "-"+ drGetGroup["COMPANY_NAME"].ToString();
                                odc.strFDate = Convert.ToDateTime(drGetGroup["COMPANY_FINICIAL_YEAR_FROM"]).ToString("dd/MM/yyyy");
                                odc.strTDate = Convert.ToDateTime(drGetGroup["COMPANY_FINICIAL_YEAR_TO"]).ToString("dd/MM/yyyy");
                                oogrp.Add(odc);
                            }
                            drGetGroup.Close();
                        }
                    }
                }




                gcnMain.Dispose();
                return oogrp;
            }
        }

        #endregion
        #region "Group Configuration"




        public List<StockGroup> mFillStockGroupconfig(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockGroup> oogrp = new List<StockGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT GR_NAME_SERIAL, GR_NAME ";
            strSQL = strSQL + "FROM INV_GROUP_MASTER ORDER BY GR_NAME ASC ";
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
                    StockGroup ogrp = new StockGroup();
                    ogrp.lngslNo = Convert.ToInt64(drGetGroup["GR_NAME_SERIAL"].ToString());
                    ogrp.GroupName = drGetGroup["GR_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public List<StockGroup> mFillStockGroupconfigNew(string strDeComID, string strName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockGroup> oogrp = new List<StockGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


            if (strName != "")
            {
                strSQL = "SELECT STOCKGROUP_NAME,GR_NAME ";
                strSQL = strSQL + "FROM INV_STOCKGROUP ";
                strSQL = strSQL + "WHERE GR_NAME = '" + strName + "' ";
                strSQL = strSQL + "ORDER BY STOCKGROUP_NAME ASC ";
            }
            else
            {
                strSQL = "SELECT DISTINCT '' STOCKGROUP_NAME,GR_NAME ";
                strSQL = strSQL + "FROM INV_STOCKGROUP ";
                strSQL = strSQL + "WHERE GR_NAME IS NOT NULL ";
                strSQL = strSQL + "ORDER BY GR_NAME ASC ";

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
                    StockGroup ogrp = new StockGroup();
                    //ogrp.lngslNo = Convert.ToInt64(drGetGroup["GR_NAME_SERIAL"].ToString());
                    ogrp.GroupName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    ogrp.GrName = drGetGroup["GR_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }


        public List<StockGroup> mFillPackSizeNew(string strDeComID, string strName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockGroup> oogrp = new List<StockGroup>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


            if (strName != "")
            {
                strSQL = "SELECT STOCKITEM_NAME,STOCKCATEGORY_NAME ";
                strSQL = strSQL + "FROM INV_STOCKITEM ";
                strSQL = strSQL + "WHERE STOCKCATEGORY_NAME = '" + strName + "' ";
            }
            else
            {
                strSQL = "SELECT  DISTINCT '' STOCKITEM_NAME,STOCKCATEGORY_NAME ";
                strSQL = strSQL + "FROM INV_STOCKITEM ";
                strSQL = strSQL + "WHERE STOCKCATEGORY_NAME IS NOT NULL ";
            }
            strSQL = strSQL + "ORDER BY STOCKITEM_NAME ASC ";
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
                    StockGroup ogrp = new StockGroup();
                    //ogrp.lngslNo = Convert.ToInt64(drGetGroup["GR_NAME_SERIAL"].ToString());
                    ogrp.GroupName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.GrName = drGetGroup["STOCKCATEGORY_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }


        public string mInsertStockGroupNew(string strDeComID, string vstrName)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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
                    vstrName = vstrName.Replace("'", "''");
                    strSQL = "INSERT INTO INV_GROUP_MASTER";
                    strSQL = strSQL + "(GR_NAME) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + vstrName + "'";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mUpdateStockGroupNew(string strDeComID, string mstrPrimaryKey, string vstrName)
        {

            string strSQL, strGroupName;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    strGroupName = vstrName.Replace("'", "''");
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    vstrName = vstrName.Replace("'", "''");
                    strSQL = "UPDATE INV_GROUP_MASTER ";
                    strSQL = strSQL + "SET GR_NAME = '" + vstrName + "'";
                    strSQL = strSQL + "WHERE GR_NAME = '" + mstrPrimaryKey + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "UPDATE INV_GROUP_COMMISSION_MASTER ";
                    strSQL = strSQL + "SET STOCKGROUP_NAME = '" + vstrName + "'";
                    strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + mstrPrimaryKey + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Updated...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mDeleteStockGroupNew(string strDeComID, string mstrPrimaryKey)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM INV_GROUP_MASTER ";
                    strSQL = strSQL + "WHERE GR_NAME = '" + mstrPrimaryKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return ("Transaction Found Cannot Delete...");
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        #endregion
        #region "Commission Config"

        public List<CommissionConfig> mDisplayCommissionconfig(string strDeComID, string masterKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<CommissionConfig> oogrp = new List<CommissionConfig>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = " select m.GROUP_COMMISSION_KEY,m.BRANCH_ID,m.EFFECTIVE_DATE,m.STOCKGROUP_NAME,m.COMM_STATUS,t.AMOUNT_FORM,t.AMOUNT_TO,t.GROUP_PERCENTAGES ";
            strSQL = strSQL + "from INV_GROUP_COMMISSION_MASTER m,INV_GROUP_COMMISSION_TRAN t where m.GROUP_COMMISSION_KEY=t.GROUP_COMMISSION_KEY ";
            strSQL = strSQL + "AND m.GROUP_COMMISSION_KEY='" + masterKey + "' ";
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
                    CommissionConfig ogrp = new CommissionConfig();
                    ogrp.BranchID = drGetGroup["BRANCH_ID"].ToString();
                    ogrp.strCommissinKey = drGetGroup["GROUP_COMMISSION_KEY"].ToString();
                    ogrp.GroupconfigName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    ogrp.strEffectiveDate = Convert.ToDateTime(drGetGroup["EFFECTIVE_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.strStatus = drGetGroup["COMM_STATUS"].ToString();
                    ogrp.dblAmountFrom = Utility.Val(drGetGroup["AMOUNT_FORM"].ToString());
                    ogrp.dblAmountTo = Utility.Val(drGetGroup["AMOUNT_TO"].ToString());
                    if (drGetGroup["GROUP_PERCENTAGES"].ToString() != "")
                    {
                        ogrp.strPercent = drGetGroup["GROUP_PERCENTAGES"].ToString();
                    }
                    else
                    {
                        ogrp.strPercent = "";
                    }


                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<CommissionConfig> mFillCommissionconfig(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<CommissionConfig> oogrp = new List<CommissionConfig>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT GROUP_COMMISSION_KEY, STOCKGROUP_NAME,EFFECTIVE_DATE,COMM_STATUS ";
            strSQL = strSQL + "FROM INV_GROUP_COMMISSION_MASTER ORDER BY EFFECTIVE_DATE ASC ";
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
                    CommissionConfig ogrp = new CommissionConfig();
                    ogrp.strCommissinKey = drGetGroup["GROUP_COMMISSION_KEY"].ToString();
                    ogrp.GroupconfigName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    ogrp.strEffectiveDate = Convert.ToDateTime(drGetGroup["EFFECTIVE_DATE"]).ToString("dd/MM/yyyy");
                    if (drGetGroup["COMM_STATUS"].ToString() == "0")
                    {
                        ogrp.strStatus = "Normal";
                    }
                    else
                    {
                        ogrp.strStatus = "Staff";
                    }

                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertCommission(string strDeComID, string strCommKey, string vstrBranchID, string vstrGropConfig, string strEffectiveDate, int intstatus, string strGrid)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "INSERT INTO INV_GROUP_COMMISSION_MASTER";
                    strSQL = strSQL + "(GROUP_COMMISSION_KEY,STOCKGROUP_NAME,EFFECTIVE_DATE,COMM_STATUS,BRANCH_ID) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + strCommKey.Replace("'", "''") + "'";
                    strSQL = strSQL + ",'" + vstrGropConfig.Replace("'", "''") + "'";
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(strEffectiveDate) + "";
                    strSQL = strSQL + "," + intstatus + " ";
                    strSQL = strSQL + ",'" + vstrBranchID + "'";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    if (strGrid != "")
                    {

                        string[] words = strGrid.Split('~');
                        foreach (string costcenter in words)
                        {
                            string[] ooCost = costcenter.Split(',');
                            if (ooCost[0] != "")
                            {

                                strSQL = "INSERT INTO INV_GROUP_COMMISSION_TRAN ";
                                strSQL = strSQL + "(GROUP_COMMISSION_KEY,AMOUNT_FORM,AMOUNT_TO,GROUP_PERCENTAGES ";
                                strSQL = strSQL + ")VALUES( ";
                                strSQL = strSQL + "'" + strCommKey.Replace("'", "''") + "'";
                                strSQL = strSQL + "," + Utility.Val(ooCost[0]) + "";
                                strSQL = strSQL + "," + Utility.Val(ooCost[1]) + "";
                                strSQL = strSQL + ",'" + ooCost[2] + "'";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }

                        }
                    }

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mUpdateCommisssion(string strDeComID, string strOldCommKey, string strCommKey, string vstrBranchID, string vstrGropConfig, string strEffectiveDate, int intstatus, string strGrid)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM INV_GROUP_COMMISSION_TRAN ";
                    strSQL = strSQL + "WHERE GROUP_COMMISSION_KEY = '" + strOldCommKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM INV_GROUP_COMMISSION_MASTER ";
                    strSQL = strSQL + "WHERE GROUP_COMMISSION_KEY = '" + strOldCommKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO INV_GROUP_COMMISSION_MASTER";
                    strSQL = strSQL + "(GROUP_COMMISSION_KEY,STOCKGROUP_NAME,EFFECTIVE_DATE,COMM_STATUS,BRANCH_ID) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + strCommKey.Replace("'", "''") + "'";
                    strSQL = strSQL + ",'" + vstrGropConfig.Replace("'", "''") + "'";
                    strSQL = strSQL + "," + Utility.cvtSQLDateString(strEffectiveDate) + " ";
                    strSQL = strSQL + "," + intstatus + " ";
                    strSQL = strSQL + ",'" + vstrBranchID + "'";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    if (strGrid != "")
                    {

                        string[] words = strGrid.Split('~');
                        foreach (string costcenter in words)
                        {
                            string[] ooCost = costcenter.Split(',');
                            if (ooCost[0] != "")
                            {

                                strSQL = "INSERT INTO INV_GROUP_COMMISSION_TRAN ";
                                strSQL = strSQL + "(GROUP_COMMISSION_KEY,AMOUNT_FORM,AMOUNT_TO,GROUP_PERCENTAGES ";
                                strSQL = strSQL + ")VALUES( ";
                                strSQL = strSQL + "'" + strCommKey.Replace("'", "''") + "'";
                                strSQL = strSQL + "," + Utility.Val(ooCost[0]) + "";
                                strSQL = strSQL + "," + Utility.Val(ooCost[1]) + " ";
                                strSQL = strSQL + ",'" + ooCost[2] + "'";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }

                        }
                    }

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Updated...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mDeleteCommission(string strDeComID, string mstrPrimaryKey)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM INV_GROUP_COMMISSION_TRAN ";
                    strSQL = strSQL + "WHERE GROUP_COMMISSION_KEY = '" + mstrPrimaryKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM INV_GROUP_COMMISSION_MASTER ";
                    strSQL = strSQL + "WHERE GROUP_COMMISSION_KEY = '" + mstrPrimaryKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        #endregion
        #region "Section"

        public List<Section> mFillSection(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Section> oogrp = new List<Section>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT SECTION_NAME ";
            strSQL = strSQL + "FROM INV_SECTION_NAME ORDER BY SECTION_NAME ASC ";
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
                    Section ogrp = new Section();
                    ogrp.strSection = drGetGroup["SECTION_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertSection(string strDeComID, string strSectionName)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "INSERT INTO INV_SECTION_NAME";
                    strSQL = strSQL + "(SECTION_NAME) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + strSectionName.Replace("'", "''") + "'";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mUpdateSection(string strDeComID, string stroldSectionName, string strSectionName)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "UPDATE INV_SECTION_NAME SET SECTION_NAME='" + strSectionName + "' ";
                    strSQL = strSQL + "WHERE SECTION_NAME='" + stroldSectionName + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Updated...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mDeleteSection(string strDeComID, string mstrPrimaryKey)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM INV_SECTION_NAME ";
                    strSQL = strSQL + "WHERE SECTION_NAME = '" + mstrPrimaryKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        #endregion
        #region "Material Type "
        public List<MaterialType> mFillMaterialType(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<MaterialType> oogrp = new List<MaterialType>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT MATERIAL_TYPE ";
            strSQL = strSQL + "FROM INV_STOCK_MATERIAL_TYPE ORDER BY MATERIAL_TYPE ASC ";
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
                    MaterialType ogrp = new MaterialType();
                    ogrp.strMaterialType = drGetGroup["MATERIAL_TYPE"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertMaterialType(string strDeComID, string strMaterialTypeName)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "INSERT INTO INV_STOCK_MATERIAL_TYPE";
                    strSQL = strSQL + "(MATERIAL_TYPE) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + strMaterialTypeName.Replace("'", "''") + "'";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mUpdateMaterialType(string strDeComID, string stroldName, string strMaterialTypeName)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "UPDATE INV_STOCK_MATERIAL_TYPE SET MATERIAL_TYPE='" + strMaterialTypeName + "' ";
                    strSQL = strSQL + "WHERE MATERIAL_TYPE='" + stroldName + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Updated...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mDeleteMaterialType(string strDeComID, string mstrPrimaryKey)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM INV_STOCK_MATERIAL_TYPE ";
                    strSQL = strSQL + "WHERE MATERIAL_TYPE = '" + mstrPrimaryKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return ("Transaction Found Cannot Delete");
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        #endregion
        #region "Consumption"
        public string mSaveStockOutWard(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName, string vstrBatchNo,
                                        string vstrCostOption, string vstrProcess, 
                                        string DGSalesGrid, bool blngNumberMethod,
                                        string strFGItem,double dblFgQty,double dblFGRate,string vstrFgLocation,string vstrUOM)
        {


            string strBillKey, strItemName = "", strUOm, strPer, strGodownName, strSection;
            double dblqty = 0, dblRate, dblTotalAmount;
            long lngloop = 1, lngCost = 0;


            //lngLedgergroup = (long)(Utility.gGetLedgergroup(strLedgerName));

            if (vstrCostOption == "By Quantity")
            {
                lngCost = 1;
            }
            else if (vstrCostOption == "By Value")
            {
                lngCost = 2;
            }
            else if (vstrCostOption == "Item wise")
            {
                lngCost = 3;
            }
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


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

                    if (vstrBatchNo == Utility.gcEND_OF_LIST)
                    {
                        vstrBatchNo = "";
                    }

                    strSQL = Voucher.gInsertmaster(strRefNo, strBranchId, mlngVType, strDate, dblNetAmount,
                                                    strNarrations, vstrBatchNo.Replace("'", "''"), lngCost, vstrProcess.Replace("'", "''"), 0);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DGSalesGrid != "")
                    {
                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split('|');
                            if (ooCost[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                                strItemName = ooCost[0].ToString().Replace("'","''");
                                dblqty = Utility.Val(ooCost[1].ToString());
                                strUOm = ooCost[2].ToString();
                                strPer = ooCost[2].ToString();
                                strGodownName = vstrGodownName;

                                dblRate = Utility.Val(ooCost[3].ToString());
                                dblTotalAmount = Utility.Val(ooCost[4].ToString());
                                strSection = ooCost[5].ToString();

                                if (strSection == Utility.gcEND_OF_LIST)
                                {
                                    strSection = "";
                                }
                                if (mlngVType == (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_CONSUMPTION)
                                {
                                    strSQL = Voucher.mInsertTranOutward(strBillKey, lngloop, strRefNo, strItemName, mlngVType,
                                                                         strDate, dblqty, dblRate, strGodownName, dblTotalAmount, "O",
                                                                         strBranchId, vstrBatchNo.Replace("'", "''"), vstrProcess.Replace("'", "''"), strUOm, strPer, strSection);

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                else
                                {
                                    strSQL = Voucher.mInsertTranInward(strBillKey, lngloop, strRefNo, strItemName, mlngVType,
                                                                         strDate, dblqty, dblRate, strGodownName, dblTotalAmount, "I",
                                                                         strBranchId, vstrBatchNo.Replace("'", "''"), vstrProcess.Replace("'", "''"), strUOm, strPer, strSection);

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                   
                                }

                                



                                lngloop += 1;
                            }

                        }
                    }
                    if (strFGItem!="")
                    {
                        lngloop += 1;
                        strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                        strSQL = Voucher.mInsertTranInward(strBillKey, lngloop, strRefNo, strFGItem, 27,
                                                                        strDate, dblFgQty, dblFGRate, vstrFgLocation, Math.Round(dblFgQty * dblFGRate,2), "I",
                                                                        strBranchId, vstrBatchNo.Replace("'", "''"), vstrProcess.Replace("'", "''"), vstrUOM, vstrUOM, "");

                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    if (blngNumberMethod == true)
                    {
                        strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    cmdInsert.Transaction.Commit();

                    gcnMain.Close();
                    return "Inserted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }
        public string mUpdateStockOutWard(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName, string vstrBatchNo,
                                        string vstrCostOption, string vstrProcess, string DGSalesGrid,
                                        string strFGItem, double dblFgQty, double dblFGRate, string vstrFgLocation, string vstrUOM)
        {


            string strBillKey, strItemName, strUOm, strPer, strGodownName, strSection;
            double dblqty = 0, dblRate, dblTotalAmount;
            long lngloop = 1, lngCost = 0;


            //lngLedgergroup = (long)(Utility.gGetLedgergroup(strLedgerName));

            if (vstrCostOption == "By Quantity")
            {
                lngCost = 1;
            }
            else if (vstrCostOption == "By Value")
            {
                lngCost = 2;
            }
            else if (vstrCostOption == "Item wise")
            {
                lngCost = 3;
            }

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM INV_TRAN_REPACKING WHERE INV_REF_NO='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (vstrBatchNo == Utility.gcEND_OF_LIST)
                    {
                        vstrBatchNo = "";
                    }
                    strSQL = Voucher.gInsertmaster(strRefNo, strBranchId, mlngVType, strDate, dblNetAmount,
                                                    strNarrations, vstrBatchNo.Replace("'", "''"), lngCost, vstrProcess.Replace("'", "''"), 0);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DGSalesGrid != "")
                    {
                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split('|');
                            if (ooCost[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                                strItemName = ooCost[0].ToString().Replace("'", "''");
                                dblqty = Utility.Val(ooCost[1].ToString());
                                strUOm = ooCost[2].ToString();
                                strPer = ooCost[2].ToString();
                                strGodownName = vstrGodownName;

                                dblRate = Utility.Val(ooCost[3].ToString());
                                dblTotalAmount = Utility.Val(ooCost[4].ToString());
                                strSection = ooCost[5].ToString();
                                if (strSection == Utility.gcEND_OF_LIST)
                                {
                                    strSection = "";
                                }
                                if (mlngVType == (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_CONSUMPTION)
                                {
                                    strSQL = Voucher.mInsertTranOutward(strBillKey, lngloop, strRefNo, strItemName, mlngVType,
                                                                         strDate, dblqty, dblRate, strGodownName, dblTotalAmount, "O",
                                                                         strBranchId, vstrBatchNo.Replace("'", "''"), vstrProcess.Replace("'", "''"), strUOm, strPer, strSection);

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                else
                                {
                                    strSQL = Voucher.mInsertTranInward(strBillKey, lngloop, strRefNo, strItemName, mlngVType,
                                                                         strDate, dblqty, dblRate, strGodownName, dblTotalAmount, "I",
                                                                         strBranchId, vstrBatchNo.Replace("'", "''"), vstrProcess.Replace("'", "''"), strUOm, strPer, strSection);

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                }
                                lngloop += 1;
                            }

                        }
                    }
                    if (strFGItem != "")
                    {
                        lngloop += 1;
                        strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                        strSQL = Voucher.mInsertTranInward(strBillKey, lngloop, strRefNo, strFGItem, 27,
                                                                        strDate, dblFgQty, dblFGRate, vstrFgLocation, Math.Round(dblFgQty * dblFGRate, 2), "I",
                                                                        strBranchId, vstrBatchNo.Replace("'", "''"), vstrProcess.Replace("'", "''"), vstrUOM, vstrUOM, "");

                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    cmdInsert.Transaction.Commit();

                   
                    gcnMain.Close();
                    return "Updated...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }

        #endregion
        #region "Finished Goods"
        public string mSaveStockInWard(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                       double dblNetAmount, string strNarrations,
                                       string strBranchId, string vstrGodownName, string vstrBatchNo,
                                       string vstrCostOption, string vstrProcess, string DGSalesGrid)
        {


            string strBillKey, strItemName, strUOm, strPer, strGodownName, strSection;
            double dblqty = 0, dblRate, dblTotalAmount;
            long lngloop = 1, lngCost = 0;


            //lngLedgergroup = (long)(Utility.gGetLedgergroup(strLedgerName));

            if (vstrCostOption == "By Quantity")
            {
                lngCost = 1;
            }
            else if (vstrCostOption == "By Value")
            {
                lngCost = 2;
            }
            else if (vstrCostOption == "Item wise")
            {
                lngCost = 3;
            }

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    if (vstrBatchNo == Utility.gcEND_OF_LIST)
                    {
                        vstrBatchNo = "";
                    }
                    strSQL = Voucher.gInsertmaster(strRefNo, strBranchId, mlngVType, strDate, dblNetAmount,
                                                    strNarrations, vstrBatchNo.Replace("'", "''"), lngCost, vstrProcess.Replace("'", "''"), 0);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DGSalesGrid != "")
                    {
                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split(',');
                            if (ooCost[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                                strItemName = ooCost[0].ToString();
                                dblqty = Utility.Val(ooCost[1].ToString());
                                strUOm = ooCost[2].ToString();
                                strPer = ooCost[2].ToString();
                                strGodownName = vstrGodownName;

                                dblRate = Utility.Val(ooCost[3].ToString());
                                dblTotalAmount = Utility.Val(ooCost[4].ToString());
                                strSection = ooCost[5].ToString();
                                if (strSection == Utility.gcEND_OF_LIST)
                                {
                                    strSection = "";
                                }
                                strSQL = Voucher.mInsertTranOutward(strBillKey, lngloop, strRefNo, strItemName, mlngVType,
                                                                     strDate, dblqty, dblRate, strGodownName, dblTotalAmount, "I",
                                                                     strBranchId, vstrBatchNo.Replace("'", "''"), vstrProcess.Replace("'", "''"), strUOm, strPer, strSection);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                strSQL = "update INV_TRAN set INV_TRAN_AMOUNT= " + dblTotalAmount * -1;
                                strSQL = strSQL + ",OUTWARD_COST_AMOUNT = " + dblTotalAmount * -1;
                                strSQL = strSQL + "where INV_TRAN_KEY= '" + strBillKey + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }

                        }
                    }

                    cmdInsert.Transaction.Commit();

                    gcnMain.Close();
                    return "Inserted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }
        public string mUpdateStockInWard(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName, string vstrBatchNo,
                                        string vstrCostOption, string vstrProcess, string DGSalesGrid)
        {


            string strBillKey, strItemName, strUOm, strPer, strGodownName, strSection;
            double dblqty = 0, dblRate, dblTotalAmount;
            long lngloop = 1, lngCost = 0;


            //lngLedgergroup = (long)(Utility.gGetLedgergroup(strLedgerName));

            if (vstrCostOption == "By Quantity")
            {
                lngCost = 1;
            }
            else if (vstrCostOption == "By Value")
            {
                lngCost = 2;
            }
            else if (vstrCostOption == "Item wise")
            {
                lngCost = 3;
            }
            connstring = Utility.SQLConnstringComSwitch(strDeComID);


            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();

                    if (vstrBatchNo == Utility.gcEND_OF_LIST)
                    {
                        vstrBatchNo = "";
                    }
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO ='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = Voucher.gInsertmaster(strRefNo, strBranchId, mlngVType, strDate, dblNetAmount,
                                                    strNarrations, vstrBatchNo.Replace("'", "''"), lngCost, vstrProcess.Replace("'", "''"), 0);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DGSalesGrid != "")
                    {
                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split(',');
                            if (ooCost[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                                strItemName = ooCost[0].ToString();
                                dblqty = Utility.Val(ooCost[1].ToString());
                                strUOm = ooCost[2].ToString();
                                strPer = ooCost[2].ToString();
                                strGodownName = vstrGodownName;

                                dblRate = Utility.Val(ooCost[3].ToString());
                                dblTotalAmount = Utility.Val(ooCost[5].ToString());
                                strSection = ooCost[5].ToString();
                                if (strSection == Utility.gcEND_OF_LIST)
                                {
                                    strSection = "";
                                }

                                strSQL = Voucher.mInsertTranOutward(strBillKey, lngloop, strRefNo, strItemName, mlngVType,
                                                                     strDate, dblqty, dblRate, strGodownName, dblTotalAmount, "I",
                                                                     strBranchId, vstrBatchNo.Replace("'", "''"), vstrProcess.Replace("'", "''"), strUOm, strPer, strSection);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                strSQL = "update INV_TRAN set INV_TRAN_AMOUNT= " + dblTotalAmount;
                                strSQL = strSQL + "where INV_TRAN_KEY= '" + strBillKey + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }

                        }
                    }

                    cmdInsert.Transaction.Commit();

                    gcnMain.Close();
                    return "Updated...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }

        public string mDeleteStockConum(string strDeComID, string strRefNo)
        {
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO ='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM INV_TRAN_REPACKING WHERE INV_REF_NO ='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    cmdInsert.Transaction.Commit();

                    gcnMain.Close();
                    return "Deleted...";

                }
                catch (Exception ex)
                {
                    return ("Transaction Found cannot be Delete");
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }

        public List<MFGvouhcer> mDisplayInOutMaster(string strDeComID, string vstrStockSerial, int intvType, string strFind, string strExpression, string strFdate, string strTodate, string strStockItemName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<MFGvouhcer> oogrp = new List<MFGvouhcer>();
            if (strFind == "Stock Item")
            {
                strSQL = "select DISTINCT m.BRANCH_ID,m.INV_REF_NO,m.INV_LOG_NO,m.INV_DATE,m.INV_VOUCHER_TYPE,m.INV_NARRATIONS,m.INV_AMOUNT,m.PROCESS_NAME,m.INV_COST_OPTION from INV_MASTER m,INV_TRAN t ";
                strSQL = strSQL + " where m.INV_REF_NO=t.INV_REF_NO ";
                strSQL = strSQL + "AND m.INV_VOUCHER_TYPE=" + intvType + " ";
                strSQL = strSQL + "AND m.INV_MANU_VOUCHER_AUTO=0 ";
                strSQL = strSQL + "AND t.STOCKITEM_NAME='" + strExpression + "' ";
                strSQL = strSQL + "AND INV_REF_NO NOT LIKE 'MP%' ";
            }
            else
            {
                strSQL = "SELECT BRANCH_ID,INV_REF_NO,INV_LOG_NO,INV_DATE,INV_VOUCHER_TYPE,INV_NARRATIONS,INV_AMOUNT,PROCESS_NAME,INV_COST_OPTION FROM INV_MASTER ";
                strSQL = strSQL + "where INV_VOUCHER_TYPE=" + intvType + " ";
                strSQL = strSQL + "AND INV_MANU_VOUCHER_AUTO=0 ";
                strSQL = strSQL + "AND INV_REF_NO NOT LIKE 'MP%' ";

                if (vstrStockSerial != "")
                {
                    strSQL = strSQL + "AND INV_REF_NO like '%" + vstrStockSerial + "'";
                }
                else if (strFind == "Voucher Number")
                {
                    strSQL = strSQL + "AND INV_REF_NO like '%" + strExpression + "'";
                }
                else if (strFind == "Voucher Date")
                {
                    strSQL = strSQL + "AND INV_DATE BETWEEN ";
                    strSQL = strSQL + Utility.cvtSQLDateString(strFdate) + " ";
                    strSQL = strSQL + "AND ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strTodate) + " ";
                }
                else
                {
                    strSQL = strSQL + "AND INV_DATE BETWEEN ";
                    strSQL = strSQL + Utility.cvtSQLDateString(strFdate) + " ";
                    strSQL = strSQL + "AND ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strTodate) + " ";
                }
            }
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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
                    MFGvouhcer ogrp = new MFGvouhcer();
                    ogrp.strBranchId = drGetGroup["BRANCH_ID"].ToString();
                    ogrp.strVoucherNo = drGetGroup["INV_REF_NO"].ToString();
                    if (drGetGroup["INV_LOG_NO"].ToString() != "")
                    {
                        ogrp.strBatch = drGetGroup["INV_LOG_NO"].ToString();
                    }
                    else
                    {
                        ogrp.strBatch = "";
                    }
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["INV_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.dblAmount = Convert.ToDouble(drGetGroup["INV_AMOUNT"]);
                    if (drGetGroup["INV_NARRATIONS"].ToString() != "")
                    {
                        ogrp.strNarration = drGetGroup["INV_NARRATIONS"].ToString();
                    }
                    else
                    {
                        ogrp.strNarration = "";
                    }
                    if (Convert.ToInt16(drGetGroup["INV_COST_OPTION"]) == 1)
                    {
                        ogrp.strCosting = "By Quantity";
                    }
                    else if (Convert.ToInt16(drGetGroup["INV_COST_OPTION"]) == 2)
                    {
                        ogrp.strCosting = "By Value";
                    }
                    else if (Convert.ToInt16(drGetGroup["INV_COST_OPTION"]) == 3)
                    {
                        ogrp.strCosting = "Item wise";
                    }
                    if (drGetGroup["PROCESS_NAME"].ToString() != "")
                    {
                        ogrp.strProcess = drGetGroup["PROCESS_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strProcess = "";
                    }
                    //if ( drGetGroup["SECTION_NAME"].ToString() !="")
                    //{
                    //ogrp.strSection  = drGetGroup["SECTION_NAME"].ToString();
                    //}
                    //else
                    //{
                    //     ogrp.strSection="";
                    //}
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<MFGvouhcer> mDisplayInoutTran(string strDeComID, string vstrStockSerial)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<MFGvouhcer> oogrp = new List<MFGvouhcer>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT * from INV_TRAN ";
            strSQL = strSQL + "WHERE INV_REF_NO = '" + vstrStockSerial + "' ";
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
                    MFGvouhcer ogrp = new MFGvouhcer();
                    ogrp.intVtype = Convert.ToInt32( drGetGroup["INV_VOUCHER_TYPE"].ToString());
                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.dblQnty = Math.Abs(Convert.ToDouble(drGetGroup["INV_TRAN_QUANTITY"].ToString()));
                    ogrp.strLocation = drGetGroup["GODOWNS_NAME"].ToString();
                    ogrp.dblrate = Math.Abs(Convert.ToDouble(drGetGroup["INV_TRAN_RATE"].ToString()));
                    ogrp.strUOM = drGetGroup["INV_PER"].ToString();
                    ogrp.dblAmount = Math.Abs(Convert.ToDouble(drGetGroup["INV_TRAN_AMOUNT"].ToString()));
                    if (drGetGroup["SECTION_NAME"].ToString() != "")
                    {
                        ogrp.strSection = drGetGroup["SECTION_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strSection = "";
                    }
                    ogrp.strBillKey = drGetGroup["INV_TRAN_KEY"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<MFGvouhcer> mDisplayRepacking(string strDeComID, string vstrStockSerial)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<MFGvouhcer> oogrp = new List<MFGvouhcer>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT STOCKITEM_NAME,QNTY from INV_TRAN_REPACKING ";
            strSQL = strSQL + "WHERE INV_REF_NO = '" + vstrStockSerial + "' ";
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                if (drGetGroup.Read())
                {
                    MFGvouhcer ogrp = new MFGvouhcer();
                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.dblQnty = Convert.ToDouble(drGetGroup["QNTY"].ToString());
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        #endregion
        #region "Damage"
        public string mSaveStockDamage(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName, string DGSalesGrid, bool blngNumberMethod)
        {


            string strBillKey, strItemName = "", strUOm, strPer, strGodownName, strSection;
            double dblqty = 0, dblRate, dblTotalAmount;
            long lngloop = 1, lngCost = 0;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);



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



                    strSQL = Voucher.gInsertmaster(strRefNo, strBranchId, mlngVType, strDate, dblNetAmount,
                                                    strNarrations, "", lngCost, Utility.gcEND_OF_LIST, 0);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DGSalesGrid != "")
                    {
                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split('|');
                            if (ooCost[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                                strItemName = ooCost[0].ToString();
                                dblqty = Utility.Val(ooCost[1].ToString());
                                strUOm = ooCost[2].ToString();
                                strPer = ooCost[2].ToString();
                                strGodownName = vstrGodownName;

                                dblRate = Utility.Val(ooCost[3].ToString());
                                dblTotalAmount = Utility.Val(ooCost[4].ToString());
                                strSection = "";


                                strSQL = Voucher.mInsertTranOutward(strBillKey, lngloop, strRefNo, strItemName, mlngVType,
                                                                     strDate, dblqty, dblRate, strGodownName, dblTotalAmount, "O",
                                                                     strBranchId, "", "", strUOm, strPer, strSection);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                //strSQL = "update INV_TRAN set INV_TRAN_AMOUNT= " + dblTotalAmount * -1;
                                //strSQL = strSQL + ",OUTWARD_COST_AMOUNT = " + dblTotalAmount * -1;
                                //strSQL = strSQL + "where INV_TRAN_KEY= '" + strBillKey + "' ";
                                //cmdInsert.CommandText = strSQL;
                                //cmdInsert.ExecuteNonQuery();
                                lngloop += 1;
                            }

                        }
                    }

                    if (blngNumberMethod == true)
                    {
                        strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }


                    cmdInsert.Transaction.Commit();

                    gcnMain.Close();
                    return "Inserted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }
        public string mUpdateDamage(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName,
                                        string DGSalesGrid)
        {


            string strBillKey, strItemName, strUOm, strPer, strGodownName, strSection;
            double dblqty = 0, dblRate, dblTotalAmount;
            long lngloop = 1, lngCost = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);



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

                    strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strSQL = Voucher.gInsertmaster(strRefNo, strBranchId, mlngVType, strDate, dblNetAmount,
                                                    strNarrations, "", lngCost, Utility.gcEND_OF_LIST, 0);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DGSalesGrid != "")
                    {
                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split('|');
                            if (ooCost[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                                strItemName = ooCost[0].ToString();
                                dblqty = Utility.Val(ooCost[1].ToString());
                                strUOm = ooCost[2].ToString();
                                strPer = ooCost[2].ToString();
                                strGodownName = vstrGodownName;

                                dblRate = Utility.Val(ooCost[3].ToString());
                                dblTotalAmount = Utility.Val(ooCost[4].ToString());
                                strSection = "";


                                strSQL = Voucher.mInsertTranOutward(strBillKey, lngloop, strRefNo, strItemName, mlngVType,
                                                                     strDate, dblqty, dblRate, strGodownName, dblTotalAmount, "O",
                                                                     strBranchId, "", "", strUOm, strPer, strSection);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                //strSQL = "update INV_TRAN set INV_TRAN_AMOUNT= " + dblTotalAmount * -1;
                                //strSQL = strSQL + ",OUTWARD_COST_AMOUNT = " + dblTotalAmount * -1;
                                //strSQL = strSQL + "where INV_TRAN_KEY= '" + strBillKey + "' ";
                                //cmdInsert.CommandText = strSQL;
                                //cmdInsert.ExecuteNonQuery();

                                lngloop += 1;
                            }

                        }
                    }

                    cmdInsert.Transaction.Commit();

                    gcnMain.Close();
                    return "Updated...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }

        #endregion
        #region "Physical Stock"
        public string mSavePhysicalStock(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName, string DGSalesGrid, bool blngNumberMethod)
        {


            string strBillKey, strItemName = "", strUOm, strPer, strGodownName, strSection;
            double dblqty = 0, dblRate, dblTotalAmount,dblCurrentQty=0;
            long lngloop = 1, lngCost = 0;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);



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



                    strSQL = Voucher.gInsertmaster(strRefNo, strBranchId, mlngVType, strDate, dblNetAmount,
                                                    strNarrations, "", lngCost, "", 0);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DGSalesGrid != "")
                    {
                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split('|');
                            if (ooCost[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                                if (Utility.Left(ooCost[2].ToString(), 1) == "-")
                                {
                                    strItemName = ooCost[0].ToString();
                                    dblCurrentQty = Math.Abs(Utility.Val(ooCost[1].ToString()));
                                    dblqty = Math.Abs(Utility.Val(ooCost[2].ToString()));
                                    strUOm = ooCost[3].ToString();
                                    strPer = ooCost[3].ToString();
                                    strGodownName = vstrGodownName;

                                    dblRate = Utility.Val(ooCost[4].ToString());
                                    dblTotalAmount = Math.Round(dblqty * dblRate, 2);
                                    strSection = "";


                                    strSQL = Voucher.mInsertTranOutwardPhysical(strBillKey, lngloop, strRefNo, strItemName, mlngVType,
                                                                         strDate, dblqty, dblRate, strGodownName, dblTotalAmount, "O",
                                                                         strBranchId, "", "", strUOm, strPer, strSection,0,dblCurrentQty);

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                else
                                {
                                    strItemName = ooCost[0].ToString();
                                    dblCurrentQty = Math.Abs(Utility.Val(ooCost[1].ToString()));
                                    dblqty = Utility.Val(ooCost[2].ToString());
                                    strUOm = ooCost[3].ToString();
                                    strPer = ooCost[3].ToString();
                                    strGodownName = vstrGodownName;

                                    dblRate = Utility.Val(ooCost[4].ToString());
                                    dblTotalAmount = Math.Round(dblqty * dblRate, 2);
                                    strSection = "";


                                    strSQL = Voucher.mInsertTranInward(strBillKey, lngloop, strRefNo, strItemName, mlngVType,
                                                                         strDate, dblqty, dblRate, strGodownName, dblTotalAmount, "I",
                                                                         strBranchId, "", "", strUOm, strPer, strSection,0,dblCurrentQty);

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                            lngloop += 1;
                        }
                    }

                    if (blngNumberMethod == true)
                    {
                        strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }


                    cmdInsert.Transaction.Commit();

                    gcnMain.Close();
                    return "Inserted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }
        public string mUpdatePhysicalStock(string strDeComID, string strRefNo, long mlngVType, string strDate,
                                        double dblNetAmount, string strNarrations,
                                        string strBranchId, string vstrGodownName,
                                        string DGSalesGrid)
        {


            string strBillKey, strItemName, strUOm, strPer, strGodownName, strSection;
            double dblqty = 0, dblRate, dblTotalAmount, dblCurrentQty;
            long lngloop = 1, lngCost = 0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);



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

                    strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strSQL = Voucher.gInsertmaster(strRefNo, strBranchId, mlngVType, strDate, dblNetAmount,
                                                    strNarrations, "", lngCost, "", 0);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DGSalesGrid != "")
                    {
                        string[] words = DGSalesGrid.Split('~');
                        foreach (string strSalesGrid in words)
                        {
                            string[] ooCost = strSalesGrid.Split('|');
                            if (ooCost[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                                if (Utility.Left(ooCost[2].ToString(), 1) == "-")
                                {
                                    strItemName = ooCost[0].ToString();
                                    dblCurrentQty = Math.Abs(Utility.Val(ooCost[1].ToString()));
                                    dblqty = Math.Abs(Utility.Val(ooCost[2].ToString()));
                                    strUOm = ooCost[3].ToString();
                                    strPer = ooCost[3].ToString();
                                    strGodownName = vstrGodownName;

                                    dblRate = Utility.Val(ooCost[4].ToString());
                                    dblTotalAmount = Math.Round(dblqty * dblRate, 2);
                                    strSection = "";


                                    strSQL = Voucher.mInsertTranOutwardPhysical(strBillKey, lngloop, strRefNo, strItemName, mlngVType,
                                                                         strDate, dblqty, dblRate, strGodownName, dblTotalAmount, "O",
                                                                         strBranchId, "", "", strUOm, strPer, strSection);

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                else
                                {
                                    strItemName = ooCost[0].ToString();
                                    dblCurrentQty = Math.Abs(Utility.Val(ooCost[1].ToString()));
                                    dblqty = Utility.Val(ooCost[2].ToString());
                                    strUOm = ooCost[3].ToString();
                                    strPer = ooCost[3].ToString();
                                    strGodownName = vstrGodownName;

                                    dblRate = Utility.Val(ooCost[4].ToString());
                                    dblTotalAmount = Math.Round(dblqty * dblRate, 2);
                                    strSection = "";


                                    strSQL = Voucher.mInsertTranInward(strBillKey, lngloop, strRefNo, strItemName, mlngVType,
                                                                         strDate, dblqty, dblRate, strGodownName, dblTotalAmount, "I",
                                                                         strBranchId, "", "", strUOm, strPer, strSection,0,dblCurrentQty);

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }

                            }
                            lngloop += 1;
                        }
                    }


                    cmdInsert.Transaction.Commit();

                    gcnMain.Close();
                    return "Updated...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }

        public string mDeleteProductionList(string strDeComID, string strRefNo)
        {
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO='" + strRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();

                    gcnMain.Close();
                    return "Deleted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }

        public List<StockItem> mFillDamaPhy(string strDeComID, int mlngVType, string strFind, string strExpression, string strFdate, string strTodate)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            if (strFind != "Stock Item")
            {
                strSQL = "SELECT M.INV_REF_NO,M.BRANCH_ID,M.INV_DATE,M.INV_AMOUNT FROM INV_MASTER M  WHERE M.INV_VOUCHER_TYPE = " + mlngVType + "  ";
            }
            else
            {
                strSQL = "SELECT t.STOCKITEM_NAME, M.INV_REF_NO,M.BRANCH_ID,M.INV_DATE,M.INV_AMOUNT FROM INV_MASTER m,INV_TRAN T WHERE M.INV_REF_NO=T.INV_REF_NO   AND M.INV_VOUCHER_TYPE = " + mlngVType + "  ";
            }

            if (strFind == "Voucher Date")
            {
                strSQL = strSQL + "AND ";
                strSQL = strSQL + "M.INV_DATE BETWEEN ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND ";
                strSQL = strSQL + "" + Utility.cvtSQLDateString(strTodate) + "";
            }
            else if (strFind == "Stock Item")
            {
                strSQL = strSQL + " AND t.STOCKITEM_NAME= '" + strExpression + "' ";
            }
            else if (strExpression != "")
            {
                strSQL = strSQL + "AND ";
                strSQL = strSQL + "M.INV_REF_NO like '%" + strExpression + "'";
            }
            else if (strFind == "Voucher Number")
            {
                strSQL = strSQL + "AND ";
                strSQL = strSQL + "M.INV_REF_NO like '%" + strExpression + "%'";
            }
            else
            {
                strSQL = strSQL + "AND ";
                strSQL = strSQL + "M.INV_DATE BETWEEN ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strTodate) + " ";
                strSQL = strSQL + "AND ";
                strSQL = strSQL + "" + Utility.cvtSQLDateString(strTodate) + "";
            }

            connstring = Utility.SQLConnstringComSwitch(strDeComID);


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
                    StockItem ogrp = new StockItem();
                    ogrp.strRefNo = drGetGroup["INV_REF_NO"].ToString();
                    ogrp.strBranchName = Utility.gstrGetBranchName(strDeComID, drGetGroup["BRANCH_ID"].ToString());
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["INV_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.dblBranchAmnout = Convert.ToDouble(drGetGroup["INV_AMOUNT"].ToString());

                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public List<StockItem> mFillDisplayPhyMaster(string strDeComID, string vstrRefNo)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT INV_REF_NO,BRANCH_ID,INV_DATE,INV_VOUCHER_TYPE,INV_NARRATIONS,INV_AMOUNT FROM INV_MASTER ";
            strSQL = strSQL + "WHERE INV_REF_NO = '" + vstrRefNo + "' ";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strRefNo = drGetGroup["INV_REF_NO"].ToString();
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["INV_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.dblBranchAmnout = Convert.ToDouble(drGetGroup["INV_AMOUNT"].ToString());
                    ogrp.strBranchName = Utility.gstrGetBranchName(strDeComID, drGetGroup["BRANCH_ID"].ToString());
                    if (drGetGroup["INV_NARRATIONS"].ToString() != "")
                    {
                        ogrp.strNarration = drGetGroup["INV_NARRATIONS"].ToString();
                    }
                    else
                    {
                        ogrp.strNarration = "";
                    }
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> mFillDisplayPhysicalStock(string strDeComID, string vstrStockSerial)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT STOCKITEM_NAME,GODOWNS_NAME,INV_TRAN_QUANTITY,INV_TRAN_RATE,INV_CURRENT_STOCK,INV_TRAN_AMOUNT,INV_LOG_NO FROM INV_TRAN ";
            strSQL = strSQL + "WHERE INV_REF_NO = '" + vstrStockSerial.Replace("'", "''") + "' ";
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
                    StockItem ogrp = new StockItem();

                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.strLocation = drGetGroup["GODOWNS_NAME"].ToString();
                    if (drGetGroup["INV_TRAN_QUANTITY"].ToString() != "+" && drGetGroup["INV_TRAN_QUANTITY"].ToString() != "-")
                    {
                        ogrp.dblOpnQty = Convert.ToDouble(drGetGroup["INV_TRAN_QUANTITY"]);
                    }
                    else
                    {
                        ogrp.dblOpnQty = Convert.ToDouble(drGetGroup["INV_TRAN_QUANTITY"]);
                    }

                    ogrp.dblOpnRate = Convert.ToDouble(drGetGroup["INV_TRAN_RATE"].ToString());
                    ogrp.dblReorderQty = Convert.ToDouble(drGetGroup["INV_CURRENT_STOCK"].ToString());
                    ogrp.dblOpnValue = Convert.ToDouble(drGetGroup["INV_TRAN_AMOUNT"].ToString());
                    if (drGetGroup["INV_LOG_NO"].ToString() != "")
                    {
                        ogrp.strBatch = drGetGroup["INV_LOG_NO"].ToString();
                    }
                    else
                    {
                        ogrp.strBatch = "";
                    }
                    oogrp.Add(ogrp);
                }




                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockItem> mFillDisplayStockDamage(string strDeComID, string vstrStockSerial, int intvtype)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT * FROM INV_TRAN ";
            strSQL = strSQL + "WHERE INV_REF_NO = '" + vstrStockSerial.Replace("'", "''") + "' ";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    if (drGetGroup["GODOWNS_NAME"].ToString() != "")
                    {
                        ogrp.strLocation = drGetGroup["GODOWNS_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strLocation = "";
                    }
                    
                    ogrp.dblOpnQty = Math.Abs(Convert.ToDouble(drGetGroup["OUTWARD_QUANTITY"]));
                    ogrp.dblOpnRate = Convert.ToDouble(drGetGroup["INV_TRAN_RATE"].ToString());
                    ogrp.dblOpnValue = Convert.ToDouble(drGetGroup["INV_TRAN_AMOUNT"].ToString());
                    if (drGetGroup["INV_LOG_NO"].ToString() != "")
                    {
                        ogrp.strBatch = drGetGroup["INV_LOG_NO"].ToString();
                    }
                    else
                    {
                        ogrp.strBatch = "";
                    }
                    ogrp.strBillKey = drGetGroup["INV_TRAN_KEY"].ToString();
                    oogrp.Add(ogrp);

                }
                if (!drGetGroup.HasRows)
                {
                    StockItem ogrp = new StockItem();
                    ogrp.strItemName = "";
                    ogrp.strLocation = "";
                    ogrp.dblOpnQty = 0;
                    ogrp.dblOpnRate = 0;
                    ogrp.dblOpnValue = 0;
                    ogrp.strBatch = "";
                    ogrp.strBillKey = "";
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        #endregion
        #region "Transport"
        public List<Transport> mFillTransport(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Transport> oogrp = new List<Transport>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT SERIAL_NO,TRANSPORT_NAME ";
            strSQL = strSQL + "FROM ACC_TRANSPORT_NAME ORDER BY TRANSPORT_NAME ASC ";
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
                    Transport ogrp = new Transport();
                    ogrp.lngSlNo = Convert.ToInt64(drGetGroup["SERIAL_NO"].ToString());
                    ogrp.strTransPort = drGetGroup["TRANSPORT_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertTransport(string strDeComID, string strTransportName)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "INSERT INTO ACC_TRANSPORT_NAME";
                    strSQL = strSQL + "(TRANSPORT_NAME) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + strTransportName.Replace("'", "''") + "'";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mUpdateTransport(string strDeComID, string stroldName, string strTransportName)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "UPDATE ACC_TRANSPORT_NAME SET TRANSPORT_NAME='" + strTransportName + "' ";
                    strSQL = strSQL + "WHERE TRANSPORT_NAME='" + stroldName + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Updated...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mDeleteTransport(string strDeComID, string mstrPrimaryKey)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM ACC_TRANSPORT_NAME ";
                    strSQL = strSQL + "WHERE TRANSPORT_NAME = '" + mstrPrimaryKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        #endregion
        #region "Designation"
        public List<Designation> mFillDesignation(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Designation> oogrp = new List<Designation>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT SERIAL_NO,DESTINATION_NAME ";
            strSQL = strSQL + "FROM ACC_DESTINATION ORDER BY DESTINATION_NAME ASC ";
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
                    Designation ogrp = new Designation();
                    ogrp.lngSlNo = Convert.ToInt64(drGetGroup["SERIAL_NO"].ToString());
                    ogrp.strDesignation = drGetGroup["DESTINATION_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertDesignation(string strDeComID, string strDesignationName)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "INSERT INTO ACC_DESTINATION";
                    strSQL = strSQL + "(DESTINATION_NAME) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + strDesignationName.Replace("'", "''") + "'";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mUpdateDesignation(string strDeComID, string stroldName, string strDesiName)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "UPDATE ACC_DESTINATION SET DESTINATION_NAME='" + strDesiName + "' ";
                    strSQL = strSQL + "WHERE DESTINATION_NAME='" + stroldName + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Updated...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mDeleteDesignation(string strDeComID, string mstrPrimaryKey)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM ACC_DESTINATION ";
                    strSQL = strSQL + "WHERE DESTINATION_NAME = '" + mstrPrimaryKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        #endregion
        #region "Sample class"
        public List<SampleClass> mFillSampleClass(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SampleClass> oogrp = new List<SampleClass>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT CLASS_SERIAL,SAMPLE_CLASS ";
            strSQL = strSQL + "FROM ACC_SAMPLE_CLASS_MASTER ORDER BY SAMPLE_CLASS ASC ";
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
                    SampleClass ogrp = new SampleClass();
                    ogrp.lngSlNo = Convert.ToInt64(drGetGroup["CLASS_SERIAL"].ToString());
                    ogrp.strClassName = drGetGroup["SAMPLE_CLASS"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<SampleClass> mDisplaySampleClass(string strDeComID, string mstKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SampleClass> oogrp = new List<SampleClass>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT STOCKITEM_NAME,SAM_CLASS_QUANTITY,SAM_CLASS_UOM ";
            strSQL = strSQL + "FROM ACC_SAMPLE_CLASS_TRAN ";
            strSQL = strSQL + "where SAMPLE_CLASS='" + mstKey + "' ";
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
                    SampleClass ogrp = new SampleClass();
                    ogrp.dblQty = Convert.ToDouble(drGetGroup["SAM_CLASS_QUANTITY"].ToString());
                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.strUOM = drGetGroup["SAM_CLASS_UOM"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertSampleClass(string strDeComID, string strSampleClass, string DG)
        {

            string strSQL;
            int intloop = 1;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "INSERT INTO ACC_SAMPLE_CLASS_MASTER";
                    strSQL = strSQL + "(SAMPLE_CLASS,EXPORT_TYPE) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + strSampleClass.Replace("'", "''") + "'";
                    strSQL = strSQL + " ,0";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    if (DG != "")
                    {

                        string[] words = DG.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                strSQL = "INSERT INTO ACC_SAMPLE_CLASS_TRAN (";
                                strSQL = strSQL + "CLASS_TRAN_POSITION,SAMPLE_CLASS,";
                                strSQL = strSQL + "STOCKITEM_NAME,SAM_CLASS_QUANTITY,SAM_CLASS_UOM,EXPORT_TYPE ";
                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES (";
                                strSQL = strSQL + "" + intloop + ",";
                                strSQL = strSQL + "'" + strSampleClass.Replace("'", "''") + "' ,";
                                strSQL = strSQL + "'" + oAssets[1] + "',";
                                strSQL = strSQL + " " + Utility.Val(oAssets[2]) + ",";
                                strSQL = strSQL + "'" + oAssets[3] + "'";
                                strSQL = strSQL + " ,0";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "1";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }


        public string mUpdateSampleClass(string strDeComID, string strOldSample, string strSampleClass, string DG)
        {

            string strSQL;
            int intloop = 1;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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
                    strSQL = "DELETE FROM ACC_SAMPLE_CLASS_TRAN ";
                    strSQL = strSQL + "WHERE SAMPLE_CLASS = '" + strOldSample.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_SAMPLE_CLASS_MASTER ";
                    strSQL = strSQL + "WHERE SAMPLE_CLASS = '" + strOldSample.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO ACC_SAMPLE_CLASS_MASTER";
                    strSQL = strSQL + "(SAMPLE_CLASS,EXPORT_TYPE) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + strSampleClass.Replace("'", "''") + "'";
                    strSQL = strSQL + " ,0";
                    strSQL = strSQL + ")";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    if (DG != "")
                    {

                        string[] words = DG.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                strSQL = "INSERT INTO ACC_SAMPLE_CLASS_TRAN (";
                                strSQL = strSQL + "CLASS_TRAN_POSITION,SAMPLE_CLASS,";
                                strSQL = strSQL + "STOCKITEM_NAME,SAM_CLASS_QUANTITY,SAM_CLASS_UOM,EXPORT_TYPE ";
                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES (";
                                strSQL = strSQL + "" + intloop + ",";
                                strSQL = strSQL + "'" + strSampleClass.Replace("'", "''") + "' ,";
                                strSQL = strSQL + "'" + oAssets[1] + "',";
                                strSQL = strSQL + " " + Utility.Val(oAssets[2]) + ",";
                                strSQL = strSQL + "'" + oAssets[3] + "'";
                                strSQL = strSQL + " ,0";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "1";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }

        public string mDeleteSampleClass(string strDeComID, string mstrPrimaryKey)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM ACC_SAMPLE_CLASS_TRAN ";
                    strSQL = strSQL + "WHERE SAMPLE_CLASS = '" + mstrPrimaryKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_SAMPLE_CLASS_MASTER ";
                    strSQL = strSQL + "WHERE SAMPLE_CLASS = '" + mstrPrimaryKey.Replace("'", "''") + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        #endregion
        #region "Target"
        public List<SalesTarget> mFillSalesTarget(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesTarget> oogrp = new List<SalesTarget>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT TARGET_ACHIEVE_KEY,TARGET_ACHIEVE_FROM_DATE,TARGET_ACHIEVE_TO_DATE,BRANCH_ID ";
            strSQL = strSQL + "FROM SALES_TARGET_ACHIEVEMENT_MASTER ";
            //if (strFind == "Voucher Date")
            //{
            //    strSQL =strSQL 
            //}
            strSQL = strSQL + " ORDER BY TARGET_ACHIEVE_FROM_DATE ASC ";
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
                    SalesTarget ogrp = new SalesTarget();
                    ogrp.strKey = drGetGroup["TARGET_ACHIEVE_KEY"].ToString();
                    ogrp.strFromDate = Convert.ToDateTime(drGetGroup["TARGET_ACHIEVE_FROM_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.strToDate = Convert.ToDateTime(drGetGroup["TARGET_ACHIEVE_TO_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.strBranchID = drGetGroup["BRANCH_ID"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<SalesTarget> mDisplayTarget(string strDeComID, string strKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesTarget> oogrp = new List<SalesTarget>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT DISTINCT ACC_LEDGER.TERITORRY_CODE,ACC_LEDGER.LEDGER_NAME,ACC_LEDGER.LEDGER_NAME_MERZE ";
            strSQL = strSQL + "FROM SALES_TARGET_ACHIEVEMENT,ACC_LEDGER WHERE ACC_LEDGER.LEDGER_NAME=SALES_TARGET_ACHIEVEMENT.LEDGER_NAME ";
            strSQL = strSQL + "AND TARGET_ACHIEVE_KEY='" + strKey + "' ";
            strSQL = strSQL + "ORDER BY ACC_LEDGER.TERITORRY_CODE ";
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
                    SalesTarget ogrp = new SalesTarget();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMerzeName = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<SalesTarget> mDisplayTargetLedger(string strDeComID, string strKey, string strLedgerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesTarget> oogrp = new List<SalesTarget>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT ACC_LEDGER.LEDGER_NAME,ACC_LEDGER.LEDGER_NAME_MERZE,SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_FROM_DATE,SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_TO_DATE,SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_MONTH_ID,SALES_TARGET_ACHIEVEMENT.COL_POS,SALES_TARGET_ACHIEVEMENT.ROW_POS,SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_AMOUNT ";
            strSQL = strSQL + "FROM SALES_TARGET_ACHIEVEMENT,ACC_LEDGER WHERE ACC_LEDGER.LEDGER_NAME=SALES_TARGET_ACHIEVEMENT.LEDGER_NAME ";
            strSQL = strSQL + "AND TARGET_ACHIEVE_KEY='" + strKey + "' ";
            strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME='" + strLedgerName + "' ";
            strSQL = strSQL + "ORDER BY SALES_TARGET_ACHIEVEMENT.TARGET_ACHIEVE_DETAIL_SERIAL ASC ";
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
                    SalesTarget ogrp = new SalesTarget();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMerzeName = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ogrp.strMonthID = drGetGroup["TARGET_ACHIEVE_MONTH_ID"].ToString();
                    ogrp.intColPos = Convert.ToInt32(drGetGroup["COL_POS"].ToString());
                    ogrp.intRowPos = Convert.ToInt32(drGetGroup["ROW_POS"].ToString());
                    ogrp.dblAmount = Convert.ToDouble(drGetGroup["TARGET_ACHIEVE_AMOUNT"].ToString());
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<SalesTarget> mFillSalesCollection(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesTarget> oogrp = new List<SalesTarget>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT COLL_TARGET_KEY,COLL_TARGET_FROM_DATE,COLL_TARGET_TO_DATE,BRANCH_ID ";
            strSQL = strSQL + "FROM SALES_COLL_TARGET_MASTER ORDER BY COLL_TARGET_FROM_DATE ASC ";
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
                    SalesTarget ogrp = new SalesTarget();
                    ogrp.strKey = drGetGroup["COLL_TARGET_KEY"].ToString();
                    ogrp.strFromDate = Convert.ToDateTime(drGetGroup["COLL_TARGET_FROM_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.strToDate = Convert.ToDateTime(drGetGroup["COLL_TARGET_TO_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.strBranchID = drGetGroup["BRANCH_ID"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<SalesTarget> mDisplayCollectionTarget(string strDeComID, string strKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesTarget> oogrp = new List<SalesTarget>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT DISTINCT ACC_LEDGER.TERITORRY_CODE,ACC_LEDGER.LEDGER_NAME,ACC_LEDGER.LEDGER_NAME_MERZE ";
            strSQL = strSQL + "FROM SALES_COLL_TARGET_TRAN,ACC_LEDGER WHERE ACC_LEDGER.LEDGER_NAME=SALES_COLL_TARGET_TRAN.LEDGER_NAME ";
            strSQL = strSQL + "AND SALES_COLL_TARGET_TRAN.COLL_TARGET_KEY='" + strKey + "' ";
           
            strSQL = strSQL + "ORDER BY ACC_LEDGER.TERITORRY_CODE ";
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
                    SalesTarget ogrp = new SalesTarget();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMerzeName = drGetGroup["LEDGER_NAME_MERZE"].ToString();

                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<SalesTarget> mDisplaySalesCollection(string strDeComID, string strKey, string strLedgerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesTarget> oogrp = new List<SalesTarget>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT LEDGER_NAME,COLL_TARGET_FROM_DATE,COLL_TARGET_TO_DATE,COLL_TARGET_OPENING, MONTH_ID COLL_TARGET_MONTH_ID,COLL_TARGET_COLL_PER,COL_POS,ROW_POS,COLL_TARGET_COLL_AMT ";
            strSQL = strSQL + "FROM SALES_COLL_TARGET_TRAN ";
            strSQL = strSQL + "where COLL_TARGET_KEY='" + strKey + "' ";
            if (strLedgerName != "")
            {
                strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "' ";
            }
            strSQL = strSQL + "ORDER BY COLL_TARGET_DETAIL_SERIAL ASC ";
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
                    SalesTarget ogrp = new SalesTarget();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMonthID = drGetGroup["COLL_TARGET_MONTH_ID"].ToString();
                    ogrp.intColPos = Convert.ToInt32(drGetGroup["COL_POS"].ToString());
                    ogrp.intRowPos = Convert.ToInt32(drGetGroup["ROW_POS"].ToString());
                    ogrp.dblOpn = Convert.ToDouble(drGetGroup["COLL_TARGET_OPENING"].ToString());
                    ogrp.dblPer = Convert.ToDouble(drGetGroup["COLL_TARGET_COLL_PER"].ToString());
                    ogrp.dblAmount = Convert.ToDouble(drGetGroup["COLL_TARGET_COLL_AMT"].ToString());
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public List<SalesTarget> mFillSalesCreditLimit(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesTarget> oogrp = new List<SalesTarget>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT CREDIT_LIMIT_KEY,CREDIT_LIMIT_FROM_DATE,CREDIT_LIMIT_TO_DATE,BRANCH_ID ";
            strSQL = strSQL + "FROM SALES_CREDIT_LIMIT_MASTER ORDER BY CREDIT_LIMIT_FROM_DATE ASC ";
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
                    SalesTarget ogrp = new SalesTarget();
                    ogrp.strKey = drGetGroup["CREDIT_LIMIT_KEY"].ToString();
                    ogrp.strFromDate = Convert.ToDateTime(drGetGroup["CREDIT_LIMIT_FROM_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.strToDate = Convert.ToDateTime(drGetGroup["CREDIT_LIMIT_TO_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.strBranchID = drGetGroup["BRANCH_ID"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<SalesTarget> mDisplayCreditLimitLedger(string strDeComID, string strKey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesTarget> oogrp = new List<SalesTarget>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT DISTINCT ACC_LEDGER.TERITORRY_CODE, ACC_LEDGER.LEDGER_NAME,ACC_LEDGER.LEDGER_NAME_MERZE FROM SALES_CREDIT_LIMIT,ACC_LEDGER  WHERE ACC_LEDGER.LEDGER_NAME =SALES_CREDIT_LIMIT.LEDGER_NAME ";
            strSQL = strSQL + "AND SALES_CREDIT_LIMIT.CREDIT_LIMIT_KEY='" + strKey + "' ";
            strSQL = strSQL + "ORDER BY ACC_LEDGER.TERITORRY_CODE ASC ";
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
                    SalesTarget ogrp = new SalesTarget();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMerzeName = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<SalesTarget> mDisplayCreditLimit(string strDeComID, string strKey,string strLedgerName)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesTarget> oogrp = new List<SalesTarget>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT LEDGER_NAME,CREDIT_LIMIT_FROM_DATE,CREDIT_LIMIT_TO_DATE,CREDIT_LIMIT_MONTH_ID,COL_POS,ROW_POS,CREDIT_LIMIT_AMOUNT ";
            strSQL = strSQL + "FROM SALES_CREDIT_LIMIT ";
            strSQL = strSQL + "where CREDIT_LIMIT_KEY='" + strKey + "' ";
            strSQL = strSQL + "AND LEDGER_NAME='" + strLedgerName + "' ";
            strSQL = strSQL + "ORDER BY CREDIT_LIMIT_DETAIL_SERIAL ASC ";
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
                    SalesTarget ogrp = new SalesTarget();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMonthID = drGetGroup["CREDIT_LIMIT_MONTH_ID"].ToString();
                    ogrp.intColPos = Convert.ToInt32(drGetGroup["COL_POS"].ToString());
                    ogrp.intRowPos = Convert.ToInt32(drGetGroup["ROW_POS"].ToString());
                    ogrp.dblAmount = Convert.ToDouble(drGetGroup["CREDIT_LIMIT_AMOUNT"].ToString());
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mInsertTarget(string strDeComID, string strInsert, string strKey, string strLedgerName, string strFromDate, string strTodate, string strbranchID, 
                                        string strFormName, string DG,string strPrifix)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlCommand cmdInsert = new SqlCommand();
            SqlTransaction myTrans;
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    SqlDataReader dr;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;
                    if (strFormName == "TA")
                    {
                        if (strInsert == "Y")
                        {
                            strSQL = "INSERT INTO SALES_TARGET_ACHIEVEMENT_MASTER";
                            strSQL = strSQL + "(TARGET_ACHIEVE_KEY,TARGET_ACHIEVE_FROM_DATE,TARGET_ACHIEVE_TO_DATE,BRANCH_ID) ";
                            strSQL = strSQL + "VALUES(";
                            strSQL = strSQL + "'" + strKey.Replace("'", "''") + "'";
                            strSQL = strSQL + "," + Utility.cvtSQLDateString(strFromDate) + " ";
                            strSQL = strSQL + "," + Utility.cvtSQLDateString(strTodate) + " ";
                            strSQL = strSQL + ",'" + strbranchID.Replace("'", "''") + "'";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        if (DG != "")
                        {

                            string[] words = DG.Split('~');
                            foreach (string ooassets in words)
                            {
                                string[] oAssets = ooassets.Split('|');
                                if (oAssets[0] != "")
                                {
                                    strSQL = "INSERT INTO SALES_TARGET_ACHIEVEMENT (";
                                    strSQL = strSQL + "TARGET_ACHIEVE_KEY_REF,TARGET_ACHIEVE_KEY,";
                                    strSQL = strSQL + "LEDGER_NAME,TARGET_ACHIEVE_FROM_DATE,TARGET_ACHIEVE_TO_DATE,TARGET_ACHIEVE_MONTH_ID,COL_POS,ROW_POS,TARGET_ACHIEVE_AMOUNT,EXPORT_TYPE";
                                    strSQL = strSQL + ") ";
                                    strSQL = strSQL + "VALUES (";
                                    strSQL = strSQL + "'" + oAssets[0].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "'" + strKey + "',";
                                    strSQL = strSQL + "'" + oAssets[1].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(oAssets[6]) + ",";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(oAssets[7]) + ",";
                                    strSQL = strSQL + "'" + oAssets[2].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[3]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[4]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[5]) + " ";
                                    //strSQL = strSQL + "'" + oAssets[3] + "'";
                                    strSQL = strSQL + " ,0";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    if (strFormName == "CT")
                    {
                        if (strInsert == "Y")
                        {
                           
                            strSQL = "INSERT INTO SALES_COLL_TARGET_MASTER";
                            strSQL = strSQL + "(COLL_TARGET_KEY,COLL_TARGET_FROM_DATE,COLL_TARGET_TO_DATE,BRANCH_ID) ";
                            strSQL = strSQL + "VALUES(";
                            strSQL = strSQL + "'" + strKey.Replace("'", "''") + "'";
                            strSQL = strSQL + "," + Utility.cvtSQLDateString(strFromDate) + " ";
                            strSQL = strSQL + "," + Utility.cvtSQLDateString(strTodate) + " ";
                            strSQL = strSQL + ",'" + strbranchID.Replace("'", "''") + "'";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        if (DG != "")
                        {


                           
                            DateTime dteFdate = Convert.ToDateTime(strFromDate);
                            string[] words = DG.Split('~');
                            foreach (string ooassets in words)
                            {
                                string[] oAssets = ooassets.Split('|');
                                if (oAssets[0] != "")
                                {

                                    

                                    DateTime lastDate = new DateTime(dteFdate.Year, dteFdate.Month, 1).AddMonths(1).AddDays(-1);
                                    strSQL = "INSERT INTO SALES_COLL_TARGET_TRAN (";
                                    strSQL = strSQL + "COLL_TARGET_KEY_REF,COLL_TARGET_KEY,";
                                    strSQL = strSQL + "LEDGER_NAME,COLL_TARGET_FROM_DATE,COLL_TARGET_TO_DATE,MONTH_ID,COL_POS,ROW_POS,COLL_TARGET_COLL_AMT";
                                    strSQL = strSQL + ") ";
                                    strSQL = strSQL + "VALUES (";
                                    strSQL = strSQL + "'" + oAssets[0].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "'" + strKey + "',";
                                    strSQL = strSQL + "'" + oAssets[1].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(oAssets[6]) + ",";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(oAssets[7]) + ",";
                                    strSQL = strSQL + "'" + oAssets[2].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[3]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[4]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[5]) + "";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    dteFdate=dteFdate.AddMonths(1);
                                }
                            }
                        }
                    }

                    if (strFormName == "MC")
                    {
                        if (strInsert == "Y")
                        {
                            strSQL = "INSERT INTO SALES_CREDIT_LIMIT_MASTER";
                            strSQL = strSQL + "(CREDIT_LIMIT_KEY,CREDIT_LIMIT_FROM_DATE,CREDIT_LIMIT_TO_DATE,BRANCH_ID) ";
                            strSQL = strSQL + "VALUES(";
                            strSQL = strSQL + "'" + strKey.Replace("'", "''") + "'";
                            strSQL = strSQL + "," + Utility.cvtSQLDateString(strFromDate) + " ";
                            strSQL = strSQL + "," + Utility.cvtSQLDateString(strTodate) + " ";
                            strSQL = strSQL + ",'" + strbranchID.Replace("'", "''") + "'";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        if (DG != "")
                        {
                            string strFdate, strTDate, strGFDate, strGTdate;
                            string[] words = DG.Split('~');
                            foreach (string ooassets in words)
                            {
                                string[] oAssets = ooassets.Split('|');
                                if (oAssets[0] != "")
                                {
                                    strSQL = "SELECT FROM_DATE,TO_DATE,GRACE_FROM_DATE,GRACE_TO_DATE,MONTH_STATUS from ACC_COLL_MONTH_SETUP  ";
                                    strSQL = strSQL + " WHERE  MONTH_ID='" + oAssets[2].Replace("'", "''") + "' ";
                                    strSQL = strSQL + "ORDER BY MONTH_ID ";
                                    cmdInsert.CommandText = strSQL;
                                    dr = cmdInsert.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        strFdate = Convert.ToDateTime(dr["FROM_DATE"]).ToString("dd-MM-yyyy");
                                        strTDate = Convert.ToDateTime(dr["TO_DATE"]).ToString("dd-MM-yyyy");
                                        strGFDate = Convert.ToDateTime(dr["GRACE_FROM_DATE"]).ToString("dd-MM-yyyy");
                                        strGTdate = Convert.ToDateTime(dr["GRACE_TO_DATE"]).ToString("dd-MM-yyyy");
                                    }
                                    else
                                    {
                                        return "Grace Table Not Configured";
                                    }
                                    dr.Close();

                                    if (strPrifix == "G")
                                    {
                                        strFdate = strGFDate;
                                        strTDate = strGTdate;
                                    }
                                    strSQL = "INSERT INTO SALES_CREDIT_LIMIT (";
                                    strSQL = strSQL + "CREDIT_LIMIT_KEY_REF,CREDIT_LIMIT_KEY,";
                                    strSQL = strSQL + "LEDGER_NAME,CREDIT_LIMIT_FROM_DATE,CREDIT_LIMIT_TO_DATE,CREDIT_LIMIT_MONTH_ID,COL_POS,ROW_POS,CREDIT_LIMIT_AMOUNT,EXPORT_TYPE";
                                    strSQL = strSQL + ") ";
                                    strSQL = strSQL + "VALUES (";
                                    strSQL = strSQL + "'" + oAssets[0].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "'" + strKey + "',";
                                    strSQL = strSQL + "'" + oAssets[1].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strFdate) + ",";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strTDate) + ",";
                                    strSQL = strSQL + "'" + oAssets[2].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[3]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[4]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[5]) + ",";
                                    //strSQL = strSQL + "'" + oAssets[3] + "'";
                                    strSQL = strSQL + " 0";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                        }
                    }


                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "1";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        public string mUpdateTarget(string strDeComID, string strKey, string strLedgerName, string strFromDate, string strTodate, string strbranchID, string strFormName, string DG)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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
                    if (strFormName == "TA")
                    {
                        strSQL = "DELETE FROM SALES_TARGET_ACHIEVEMENT WHERE TARGET_ACHIEVE_KEY='" + strKey.Replace("'", "''") + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "DELETE FROM SALES_TARGET_ACHIEVEMENT_MASTER WHERE TARGET_ACHIEVE_KEY='" + strKey.Replace("'", "''") + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO SALES_TARGET_ACHIEVEMENT_MASTER";
                        strSQL = strSQL + "(TARGET_ACHIEVE_KEY,TARGET_ACHIEVE_FROM_DATE,TARGET_ACHIEVE_TO_DATE,BRANCH_ID) ";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + strKey.Replace("'", "''") + "'";
                        strSQL = strSQL + "," + Utility.cvtSQLDateString(strFromDate) + " ";
                        strSQL = strSQL + "," + Utility.cvtSQLDateString(strTodate) + " ";
                        strSQL = strSQL + ",'" + strbranchID.Replace("'", "''") + "'";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        if (DG != "")
                        {

                            string[] words = DG.Split('~');
                            foreach (string ooassets in words)
                            {
                                string[] oAssets = ooassets.Split('|');
                                if (oAssets[0] != "")
                                {
                                    strSQL = "INSERT INTO SALES_TARGET_ACHIEVEMENT (";
                                    strSQL = strSQL + "TARGET_ACHIEVE_KEY_REF,TARGET_ACHIEVE_KEY,";
                                    strSQL = strSQL + "LEDGER_NAME,TARGET_ACHIEVE_FROM_DATE,TARGET_ACHIEVE_TO_DATE,TARGET_ACHIEVE_MONTH_ID,COL_POS,ROW_POS,TARGET_ACHIEVE_AMOUNT,EXPORT_TYPE";
                                    strSQL = strSQL + ") ";
                                    strSQL = strSQL + "VALUES (";
                                    strSQL = strSQL + "'" + oAssets[0].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "'" + strKey + "',";
                                    strSQL = strSQL + "'" + oAssets[1].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strFromDate) + ",";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strTodate) + ",";
                                    strSQL = strSQL + "'" + oAssets[2].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[3]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[4]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[5]) + " ";
                                    //strSQL = strSQL + "'" + oAssets[3] + "'";
                                    strSQL = strSQL + " ,0";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    if (strFormName == "CT")
                    {
                        strSQL = "DELETE FROM SALES_COLL_TARGET_TRAN WHERE COLL_TARGET_KEY='" + strKey.Replace("'", "''") + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "DELETE FROM SALES_COLL_TARGET_MASTER WHERE COLL_TARGET_KEY='" + strKey.Replace("'", "''") + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO SALES_COLL_TARGET_MASTER";
                        strSQL = strSQL + "(COLL_TARGET_KEY,COLL_TARGET_FROM_DATE,COLL_TARGET_TO_DATE,BRANCH_ID) ";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + strKey.Replace("'", "''") + "'";
                        strSQL = strSQL + "," + Utility.cvtSQLDateString(strFromDate) + " ";
                        strSQL = strSQL + "," + Utility.cvtSQLDateString(strTodate) + " ";
                        strSQL = strSQL + ",'" + strbranchID.Replace("'", "''") + "'";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        if (DG != "")
                        {
                            DateTime dteFdate = Convert.ToDateTime(strFromDate);
                            string[] words = DG.Split('~');
                            foreach (string ooassets in words)
                            {
                                string[] oAssets = ooassets.Split('|');
                                if (oAssets[0] != "")
                                {
                                    DateTime lastDate = new DateTime(dteFdate.Year, dteFdate.Month, 1).AddMonths(1).AddDays(-1);
                                    strSQL = "INSERT INTO SALES_COLL_TARGET_TRAN (";
                                    strSQL = strSQL + "COLL_TARGET_KEY_REF,COLL_TARGET_KEY,";
                                    strSQL = strSQL + "LEDGER_NAME,COLL_TARGET_FROM_DATE,COLL_TARGET_TO_DATE,MONTH_ID,COL_POS,ROW_POS,COLL_TARGET_COLL_AMT,GRACE_AMOUNT ";
                                    strSQL = strSQL + ") ";
                                    strSQL = strSQL + "VALUES (";
                                    strSQL = strSQL + "'" + oAssets[0].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "'" + strKey + "',";
                                    strSQL = strSQL + "'" + oAssets[1].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(oAssets[6]) + ",";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(oAssets[7]) + ",";
                                    strSQL = strSQL + "'" + oAssets[2].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[3]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[4]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[5]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[6]) + "";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    dteFdate = dteFdate.AddMonths(1);
                                }
                            }
                        }
                    }

                    if (strFormName == "MC")
                    {
                        //strSQL = "DELETE FROM SALES_CREDIT_LIMIT WHERE CREDIT_LIMIT_KEY='" + strKey.Replace("'", "''") + "'";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //strSQL = "DELETE FROM SALES_CREDIT_LIMIT_MASTER WHERE CREDIT_LIMIT_KEY='" + strKey.Replace("'", "''") + "'";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        //strSQL = "INSERT INTO SALES_CREDIT_LIMIT_MASTER";
                        //strSQL = strSQL + "(CREDIT_LIMIT_KEY,CREDIT_LIMIT_FROM_DATE,CREDIT_LIMIT_TO_DATE,BRANCH_ID) ";
                        //strSQL = strSQL + "VALUES(";
                        //strSQL = strSQL + "'" + strKey.Replace("'", "''") + "'";
                        //strSQL = strSQL + "," + Utility.cvtSQLDateString(strFromDate) + " ";
                        //strSQL = strSQL + "," + Utility.cvtSQLDateString(strTodate) + " ";
                        //strSQL = strSQL + ",'" + strbranchID.Replace("'", "''") + "'";
                        //strSQL = strSQL + ")";
                        //cmdInsert.CommandText = strSQL;
                        //cmdInsert.ExecuteNonQuery();
                        if (DG != "")
                        {

                            string[] words = DG.Split('~');
                            foreach (string ooassets in words)
                            {
                                string[] oAssets = ooassets.Split('|');
                                if (oAssets[0] != "")
                                {
                                    strSQL = "DELETE FROM SALES_CREDIT_LIMIT WHERE CREDIT_LIMIT_KEY='" + oAssets[0].Replace("'", "''") + "'";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    strSQL = "INSERT INTO SALES_CREDIT_LIMIT (";
                                    strSQL = strSQL + "CREDIT_LIMIT_KEY_REF,CREDIT_LIMIT_KEY,";
                                    strSQL = strSQL + "LEDGER_NAME,CREDIT_LIMIT_FROM_DATE,CREDIT_LIMIT_TO_DATE,CREDIT_LIMIT_MONTH_ID,COL_POS,ROW_POS,CREDIT_LIMIT_AMOUNT,EXPORT_TYPE";
                                    strSQL = strSQL + ") ";
                                    strSQL = strSQL + "VALUES (";
                                    strSQL = strSQL + "'" + oAssets[0].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "'" + strKey + "',";
                                    strSQL = strSQL + "'" + oAssets[1].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strFromDate) + ",";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strTodate) + ",";
                                    strSQL = strSQL + "'" + oAssets[2].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[3]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[4]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[5]) + ",";
                                    //strSQL = strSQL + "'" + oAssets[3] + "'";
                                    strSQL = strSQL + " 0";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                        }
                    }


                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "1";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }




        public string mDeleteTarget(string strDeComID, string strKey, string strFormName)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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
                    if (strFormName == "TA")
                    {
                        strSQL = "DELETE FROM SALES_TARGET_ACHIEVEMENT WHERE TARGET_ACHIEVE_KEY='" + strKey.Replace("'", "''") + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "DELETE FROM SALES_TARGET_ACHIEVEMENT_MASTER WHERE TARGET_ACHIEVE_KEY='" + strKey.Replace("'", "''") + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                    }

                    if (strFormName == "CT")
                    {
                        strSQL = "DELETE FROM SALES_COLL_TARGET_TRAN WHERE COLL_TARGET_KEY='" + strKey.Replace("'", "''") + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "DELETE FROM SALES_COLL_TARGET_MASTER WHERE COLL_TARGET_KEY='" + strKey.Replace("'", "''") + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                    }

                    if (strFormName == "MC")
                    {
                        strSQL = "DELETE FROM SALES_CREDIT_LIMIT WHERE CREDIT_LIMIT_KEY='" + strKey.Replace("'", "''") + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "DELETE FROM SALES_CREDIT_LIMIT_MASTER WHERE CREDIT_LIMIT_KEY='" + strKey.Replace("'", "''") + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                    }


                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        #endregion
        #region "Sample"
        public List<Sample> mFillSample(string strDeComID,string strPrefix)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Sample> oogrp = new List<Sample>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            //strSQL = "SELECT STOCKGROUP_NAME FROM INV_STOCKGROUP WHERE STOCKGROUP_PRIMARY='Finished Goods'  ORDER BY STOCKGROUP_NAME ";

            strSQL = "SELECT DISTINCT INV_STOCKGROUP.STOCKGROUP_NAME  FROM INV_STOCKITEM ,INV_STOCKGROUP WHERE INV_STOCKITEM.STOCKGROUP_NAME=INV_STOCKGROUP.STOCKGROUP_NAME ";
            strSQL = strSQL + "and INV_STOCKGROUP.STOCKGROUP_PRIMARY='Finished Goods' ";
            if (strPrefix == "SI")
            {
                strSQL = strSQL + "and G_STATUS =0 ";
            }
            strSQL = strSQL + " Order By INV_STOCKGROUP.STOCKGROUP_NAME ASC ";
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
                    Sample ogrp = new Sample();
                    ogrp.strGroupName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public string mInsertSample(string strDeComID, long mlngVType, string strBranchId, string strRefNo, string strDate, string strMonthID, string strLedgerName,
                                       string strDueDate, double dblNetAmount, string strLocation, string strCustomer, string strNarrations, string DG, bool mblnNumbMethod)
        {

            string strSQL, strBillKey ;
            int lngloop = 1,intSameType=0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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
                    //Same sales sample + sales challan
                    intSameType =(int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN ;
                    strSQL = Voucher.gInsertCompanyVoucher(strRefNo, intSameType, strDate, strMonthID, strDueDate, strLedgerName, dblNetAmount, dblNetAmount, 
                                                      0, 0, 0, strNarrations,
                                                      strBranchId, 0, strCustomer, "", "", "", "", "", "","","","","","","",0,0,0,0,1);

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = Voucher.gInteractInvInsertMaster(strLedgerName, strRefNo, intSameType, strDate, strBranchId, strNarrations);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DG != "")
                    {
                        string[] words = DG.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');

                                strSQL = "INSERT INTO ACC_BILL_TRAN";
                                strSQL = strSQL + "(BRANCH_ID,BILL_TRAN_KEY,COMP_REF_NO,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
                                strSQL = strSQL + "STOCKGROUP_NAME,STOCKITEM_NAME,GODOWNS_NAME,BILL_QUANTITY,BILL_QUANTITY_BONUS,";
                                strSQL = strSQL + "BILL_UOM,BILL_PER,BILL_RATE,BILL_AMOUNT,";
                                strSQL = strSQL + "BILL_ADD_LESS,BILL_ADD_LESS_AMOUNT ,";
                                strSQL = strSQL + "BILL_NET_AMOUNT,BILL_TRAN_TOBY,";
                                strSQL = strSQL + "BILL_TRAN_POSITION";
                                strSQL = strSQL + ",INV_LOG_NO ";
                                strSQL = strSQL + ",STOCKITEM_DESCRIPTION ";


                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + strBranchId + "',";
                                strSQL = strSQL + "'" + strBillKey.Trim() + "',";
                                strSQL = strSQL + "'" + strRefNo.Trim() + "'," + intSameType + ",";
                                strSQL = strSQL + " " + Utility.cvtSQLDateString(strDate) + ",";
                                strSQL = strSQL + "'" + oAssets[0] + "',";//            'Group Name
                                strSQL = strSQL + "'" + oAssets[1] + "',";//            'Item Name
                                strSQL = strSQL + "'" + strLocation + "',";//        'Location
                                strSQL = strSQL + "'" + oAssets[3] + "',";//                'Qty
                                strSQL = strSQL + "'" + 0 + "',";//           'BonusQty
                                strSQL = strSQL + "'" + oAssets[4] + "',";//              'Unit
                                strSQL = strSQL + "'" + oAssets[4] + "',";//                 'Unit
                                strSQL = strSQL + " " + oAssets[5] + ",";//              'Rate
                                strSQL = strSQL + " " + oAssets[6] + ",";//          'Total
                                strSQL = strSQL + " '" + 0 + "',";//         'Add/Less
                                strSQL = strSQL + " " + 0 + ",";//
                                strSQL = strSQL + " " + oAssets[6] + ",";//         'Net Amount
                                strSQL = strSQL + "'" + "" + "',";//
                                strSQL = strSQL + "" + lngloop + "";
                                strSQL = strSQL + ",'" + oAssets[7] + "'";
                                strSQL = strSQL + ",'" + oAssets[2] + "'";
                                strSQL = strSQL + ")";



                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();


                                strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, strRefNo, strRefNo, intSameType, strDate,
                                                                           oAssets[1], strLocation, Utility.Val(oAssets[3]), oAssets[4], "", 0, Utility.Val(oAssets[6]), oAssets[4]);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                strSQL = Voucher.gInventoryInsertTranSalesReturn(strRefNo, strBillKey, lngloop, Utility.Val(oAssets[5]), 0, 0, oAssets[1], strLocation,
                                                                               "O", Utility.Val(oAssets[3]) * -1, 0, 0, intSameType, strDate, strBranchId, "", 0, oAssets[4], oAssets[4], 0,13);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                //strSQL = "UPDATE INV_TRAN SET ";
                                //strSQL = strSQL + "OUTWARD_SALES_AMOUNT=0 ";
                                //strSQL = strSQL + " where INV_TRAN_KEY='" + strBillKey + "' ";
                                //cmdInsert.CommandText = strSQL;
                                //cmdInsert.ExecuteNonQuery();

                                lngloop += 1;
                            }
                        }
                    }

                    if (mblnNumbMethod == true)
                    {
                        strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Inseretd...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }


        public string mUpdateSample(string strDeComID, string strOldRefNo, long mlngVType, string strBranchId, string strRefNo, string strDate, string strMonthID, string strLedgerName,
                                       string strDueDate, double dblNetAmount, string strLocation, string strCustomer, string strNarrations, string DG)
        {

            string strSQL, strBillKey; ;
            int lngloop = 1, intSameType=0;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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
                    intSameType = (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN;

                    strSQL = "DELETE FROM ACC_BILL_TRAN WHERE COMP_REF_NO='" + strOldRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO='" + strOldRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_COMPANY_VOUCHER WHERE COMP_REF_NO='" + strOldRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO='" + strOldRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO='" + strOldRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strSQL = Voucher.gInsertCompanyVoucher(strOldRefNo, mlngVType, strDate, strMonthID, strDueDate, strLedgerName, dblNetAmount, dblNetAmount, 0, 0, 0, strNarrations,
                                                       strBranchId, 0, strCustomer, "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 1);


                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = Voucher.gInteractInvInsertMaster(strLedgerName, strOldRefNo, intSameType, strDate, strBranchId, strNarrations);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (DG != "")
                    {



                        string[] words = DG.Split('~');
                        foreach (string ooassets in words)
                        {
                            string[] oAssets = ooassets.Split('|');
                            if (oAssets[0] != "")
                            {
                                strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');

                                strSQL = "INSERT INTO ACC_BILL_TRAN";
                                strSQL = strSQL + "(BRANCH_ID,BILL_TRAN_KEY,COMP_REF_NO,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
                                strSQL = strSQL + "STOCKGROUP_NAME,STOCKITEM_NAME,GODOWNS_NAME,BILL_QUANTITY,BILL_QUANTITY_BONUS,";
                                strSQL = strSQL + "BILL_UOM,BILL_PER,BILL_RATE,BILL_AMOUNT,";
                                strSQL = strSQL + "BILL_ADD_LESS,BILL_ADD_LESS_AMOUNT ,";
                                strSQL = strSQL + "BILL_NET_AMOUNT,BILL_TRAN_TOBY,";
                                strSQL = strSQL + "BILL_TRAN_POSITION";
                                strSQL = strSQL + ",INV_LOG_NO ";
                                strSQL = strSQL + ",STOCKITEM_DESCRIPTION ";


                                strSQL = strSQL + ") ";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + strBranchId + "',";
                                strSQL = strSQL + "'" + strBillKey.Trim() + "',";
                                strSQL = strSQL + "'" + strRefNo.Trim() + "'," + intSameType + ",";
                                strSQL = strSQL + " " + Utility.cvtSQLDateString(strDate) + ",";
                                strSQL = strSQL + "'" + oAssets[0] + "',";//            'Group Name
                                strSQL = strSQL + "'" + oAssets[1] + "',";//            'Item Name
                                strSQL = strSQL + "'" + strLocation + "',";//        'Location
                                strSQL = strSQL + "'" + oAssets[3] + "',";//                'Qty
                                strSQL = strSQL + "'" + 0 + "',";//           'BonusQty
                                strSQL = strSQL + "'" + oAssets[4] + "',";//              'Unit
                                strSQL = strSQL + "'" + oAssets[4] + "',";//                 'Unit
                                strSQL = strSQL + " " + oAssets[5] + ",";//              'Rate
                                strSQL = strSQL + " " + oAssets[6] + ",";//          'Total
                                strSQL = strSQL + " '" + 0 + "',";//         'Add/Less
                                strSQL = strSQL + " " + 0 + ",";//
                                strSQL = strSQL + " " + oAssets[6] + ",";//         'Net Amount
                                strSQL = strSQL + "'" + "" + "',";//
                                strSQL = strSQL + "" + lngloop + "";
                                strSQL = strSQL + ",'" + oAssets[7] + "'";
                                strSQL = strSQL + ",'" + oAssets[2] + "'";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, strOldRefNo, strRefNo, intSameType, strDate,
                                                                           oAssets[1], strLocation, Utility.Val(oAssets[3]), oAssets[4], "", 0, Utility.Val(oAssets[6]), oAssets[4]);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                strSQL = Voucher.gInventoryInsertTranSalesReturn(strOldRefNo, strBillKey, lngloop, Utility.Val(oAssets[5]), 0, 0, oAssets[1], strLocation,
                                                                             "O", Utility.Val(oAssets[3]) * -1, 0, 0, intSameType, strDate, strBranchId, "", 0, oAssets[4], oAssets[4], 0,13);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                //strSQL = "UPDATE INV_TRAN SET ";
                                //strSQL = strSQL + "OUTWARD_SALES_AMOUNT=0 ";
                                //strSQL = strSQL + " where INV_TRAN_KEY='" + strBillKey + "' ";
                                //cmdInsert.CommandText = strSQL;
                                //cmdInsert.ExecuteNonQuery();

                                lngloop += 1;
                            }
                        }
                    }
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Updated...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        public string mDeleteSample(string strDeComID, string strOldRefNo)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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

                    strSQL = "DELETE FROM ACC_BILL_TRAN WHERE COMP_REF_NO='" + strOldRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO='" + strOldRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                   

                    strSQL = "DELETE FROM INV_TRAN WHERE INV_REF_NO='" + strOldRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO='" + strOldRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_COMPANY_VOUCHER WHERE COMP_REF_NO='" + strOldRefNo + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "Deleted...";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        public List<Sample> GetSampleList(string strDeComID, int intvtype, string strFdate, string strTdate, string strFind, string strExpression,string strMySQl)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Sample> oogrp = new List<Sample>();

            //strSQL = "SELECT BRANCH_ID,LEDGER_NAME,SALES_REP,COMP_VOUCHER_DATE,COMP_REF_NO,COMP_VOUCHER_DUE_DATE,COMP_VOUCHER_NET_AMOUNT,COMP_VOUCHER_NARRATION ";
            //strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER ";
            //strSQL = strSQL + "WHERE SAMPLE_STATUS=1 ";
            if (strMySQl == "")
            {
                strSQL = "SELECT ACC_COMPANY_VOUCHER.BRANCH_ID,ACC_LEDGER.LEDGER_NAME_MERZE  LEDGER_NAME,ACC_COMPANY_VOUCHER.SALES_REP,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE,ACC_COMPANY_VOUCHER.COMP_REF_NO, ";
                strSQL = strSQL + " ACC_COMPANY_VOUCHER.COMP_VOUCHER_DUE_DATE,ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT,ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION  ";
                strSQL = strSQL + "FROM ACC_COMPANY_VOUCHER,ACC_LEDGER  WHERE ACC_LEDGER.LEDGER_NAME =ACC_COMPANY_VOUCHER.LEDGER_NAME and  SAMPLE_STATUS=1 ";


                if (strFind == "Voucher Date")
                {
                    strSQL = strSQL + "AND ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE BETWEEN ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + " ";
                    strSQL = strSQL + "AND ";
                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strTdate) + "";
                }
                else if (strFind == "Ledger Name")
                {
                    strSQL = strSQL + " AND LEDGER_NAME= '" + strExpression + "' ";
                }
                else if (strFind == "Voucher Number")
                {
                    strSQL = strSQL + "AND ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_REF_NO like '%" + strExpression + "%'";
                }
                else
                {
                    strSQL = strSQL + "AND ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE BETWEEN ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strTdate) + " ";
                    strSQL = strSQL + "AND ";
                    strSQL = strSQL + "" + Utility.cvtSQLDateString(strTdate) + "";
                }
                strSQL = strSQL + " ORDER BY ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE  ASC ";
            }
            else
            {
                strSQL = strMySQl;
            }
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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
                    Sample ogrp = new Sample();
                    ogrp.strBranchID = drGetGroup["BRANCH_ID"].ToString();
                    ogrp.strMrName = drGetGroup["LEDGER_NAME"].ToString();
                    if (drGetGroup["SALES_REP"].ToString() != "")
                    {
                        ogrp.strCustomer = drGetGroup["SALES_REP"].ToString();
                    }
                    else
                    {
                        ogrp.strCustomer = Utility.gcEND_OF_LIST;
                    }
                    if (drGetGroup["COMP_VOUCHER_NARRATION"].ToString() != "")
                    {
                        ogrp.strNarration = drGetGroup["COMP_VOUCHER_NARRATION"].ToString();
                    }
                    else
                    {
                        ogrp.strNarration = "";
                    }
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["COMP_VOUCHER_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.strSampleNo = drGetGroup["COMP_REF_NO"].ToString();
                    ogrp.strDueDate = drGetGroup["COMP_VOUCHER_DUE_DATE"].ToString();
                    ogrp.dblAmount = Convert.ToDouble(drGetGroup["COMP_VOUCHER_NET_AMOUNT"].ToString());
                    ogrp.strPreserveSQL = strSQL;
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Sample> mDisplaySampleList(string strDeComID, string mstrPrimarykey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Sample> oogrp = new List<Sample>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT BRANCH_ID,LEDGER_NAME,SALES_REP,COMP_VOUCHER_DATE,COMP_REF_NO,COMP_VOUCHER_DUE_DATE,COMP_VOUCHER_NARRATION,COMP_VOUCHER_NET_AMOUNT FROM ACC_COMPANY_VOUCHER WHERE COMP_REF_NO='" + mstrPrimarykey + "' ";

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
                    Sample ogrp = new Sample();
                    ogrp.strBranchID = drGetGroup["BRANCH_ID"].ToString();
                    ogrp.strMrName = drGetGroup["LEDGER_NAME"].ToString();
                    if (drGetGroup["SALES_REP"].ToString() != "")
                    {
                        ogrp.strCustomer = drGetGroup["SALES_REP"].ToString();
                    }
                    else
                    {
                        ogrp.strCustomer = Utility.gcEND_OF_LIST;
                    }
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["COMP_VOUCHER_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.strSampleNo = drGetGroup["COMP_REF_NO"].ToString();
                    if (drGetGroup["COMP_VOUCHER_DUE_DATE"].ToString() != "")
                    {
                        ogrp.strDueDate = Convert.ToDateTime(drGetGroup["COMP_VOUCHER_DUE_DATE"]).ToString("dd/MM/yyyy");
                    }
                    if (drGetGroup["COMP_VOUCHER_NARRATION"].ToString() != "")
                    {
                        ogrp.strNarration = drGetGroup["COMP_VOUCHER_NARRATION"].ToString();
                    }
                    else
                    {
                        ogrp.strNarration = "";
                    }
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Sample> mDisplaySampleItem(string strDeComID, string mstrPrimarykey)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<Sample> oogrp = new List<Sample>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT BILL_TRAN_KEY,STOCKGROUP_NAME,STOCKITEM_NAME,GODOWNS_NAME,BILL_QUANTITY,BILL_RATE,BILL_UOM,BILL_NET_AMOUNT,INV_LOG_NO FROM ACC_BILL_TRAN WHERE COMP_REF_NO='" + mstrPrimarykey + "' ";

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
                    Sample ogrp = new Sample();
                    ogrp.strBillKey = drGetGroup["BILL_TRAN_KEY"].ToString();
                    ogrp.strGroupName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    ogrp.strItemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    if (drGetGroup["GODOWNS_NAME"].ToString() != "")
                    {
                        ogrp.strLocation = drGetGroup["GODOWNS_NAME"].ToString();
                    }
                    else
                    {
                        ogrp.strLocation = "";
                    }
                    ogrp.dblQty = Convert.ToDouble(drGetGroup["BILL_QUANTITY"].ToString());
                    ogrp.dblRate = Convert.ToDouble(drGetGroup["BILL_RATE"].ToString());
                    ogrp.strUnit = drGetGroup["BILL_UOM"].ToString();
                    ogrp.dblAmount = Convert.ToDouble(drGetGroup["BILL_NET_AMOUNT"].ToString());
                    if (drGetGroup["INV_LOG_NO"].ToString() != "")
                    {
                        ogrp.strBatchNo = drGetGroup["INV_LOG_NO"].ToString();
                    }
                    else
                    {
                        ogrp.strBatchNo = "";
                    }


                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        #endregion
        #region "CompnayTest"
        public string mloadDatabaseCompnaytest(string strDeComID)
        {
            string strSQL, strCompaniId = "";
            SqlDataReader drGetGroup;
            List<DatabaseCompany> oogrp = new List<DatabaseCompany>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT NAME FROM master.dbo.sysdatabases WHERE NAME LIKE 'SMART%' ORDER BY NAME ";
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
                    strCompaniId = drGetGroup["NAME"].ToString() + "~" + strCompaniId;
                }
                drGetGroup.Close();

                if (strCompaniId != "")
                {
                    strCompaniId = strCompaniId.ToString().Substring(0, strCompaniId.Length - 1);

                    string[] words = strCompaniId.Split('~');
                    foreach (string name in words)
                    {
                        if (name.ToString() != "")
                        {
                            strSQL = "SELECT * FROM " + name.ToString() + ".dbo.ACC_COMPANY ";

                            SqlCommand cmd1 = new SqlCommand(strSQL, gcnMain);
                            drGetGroup = cmd1.ExecuteReader();
                            while (drGetGroup.Read())
                            {
                                DatabaseCompany odc = new DatabaseCompany();
                                odc.strComID = drGetGroup["COMPANY_ID"].ToString();
                                odc.strComName = drGetGroup["COMPANY_NAME"].ToString();
                                odc.strFDate = Convert.ToDateTime(drGetGroup["COMPANY_FINICIAL_YEAR_FROM"]).ToString("dd/MM/yyyy");
                                odc.strTDate = Convert.ToDateTime(drGetGroup["COMPANY_FINICIAL_YEAR_TO"]).ToString("dd/MM/yyyy");
                                oogrp.Add(odc);
                            }
                            drGetGroup.Close();
                        }
                    }
                }
            }

            return connstring;
        }
        #endregion
        #region "StockGroupPriceList"
        public List<StockItem> mFillStockTreeGroupLevel2(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<StockItem> oogrp = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "SELECT STOCKGROUP_NAME ";
            strSQL = strSQL + "FROM INV_STOCKGROUP ";
            strSQL = strSQL + "WHERE(STOCKGROUP_PARENT <> 'Direct Raw Materials') AND (STOCKGROUP_PARENT <> 'Work in Progress') AND (STOCKGROUP_PARENT <> 'Indirect Raw Materials')";
            strSQL = strSQL + "ORDER BY STOCKGROUP_LEVEL ";
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
                    StockItem ogrp = new StockItem();
                    ogrp.strItemGroup = drGetGroup["STOCKGROUP_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        #endregion
        #region "Sales Item Target"
        public string mInsertItemPackTarget(string strDeComID,string strOldKey, string strInsert, string strKey, string strLedgerName, string strFromDate, string strTodate, string strbranchID, int intType, string DG)
        {

            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

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
                  
                    if (strInsert == "Y")
                    {
                        if (strOldKey != "")
                        {
                            strSQL = "DELETE FROM SALES_TARGET_ITEM_TRAN WHERE TARGET_ITEM_TRAN_KEY='" + strOldKey + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            strSQL = "DELETE FROM SALES_TARGET_ITEM_PACK_MASTER WHERE TARGET_ITEM_PACK_KEY='" + strOldKey + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                        strSQL = "INSERT INTO SALES_TARGET_ITEM_PACK_MASTER";
                        strSQL = strSQL + "(TARGET_ITEM_PACK_KEY,TARGET_ITEM_PACK_FROM_DATE,TARGET_ITEM_PACK_TO_DATE,BRANCH_ID,ITEM_TYPE) ";
                        strSQL = strSQL + "VALUES(";
                        strSQL = strSQL + "'" + strKey.Replace("'", "''") + "'";
                        strSQL = strSQL + "," + Utility.cvtSQLDateString(strFromDate) + " ";
                        strSQL = strSQL + "," + Utility.cvtSQLDateString(strTodate) + " ";
                        strSQL = strSQL + ",'" + strbranchID.Replace("'", "''") + "'";
                        strSQL = strSQL + "," + intType + " ";
                        strSQL = strSQL + ")";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    if (intType == 0)
                    {
                        if (DG != "")
                        {
                            string[] words = DG.Split('~');
                            foreach (string ooassets in words)
                            {
                                string[] oAssets = ooassets.Split('!');
                                if (oAssets[0] != "")
                                {
                                    strSQL = "INSERT INTO SALES_TARGET_ITEM_TRAN (";
                                    strSQL = strSQL + "TARGET_ITEM_TRAN_KEY_REF,TARGET_ITEM_TRAN_KEY,";
                                    strSQL = strSQL + "STOCKITEM_NAME,TARGET_ITEM_TRAN_FROM_DATE,TARGET_ITEM_TRAN_TO_DATE,TARGET_ITEM_TRAN_MONTH_ID,COL_POS,ROW_POS,TARGET_ITEM_TRAN_AMOUNT,LEDGER_NAME";
                                    strSQL = strSQL + ") ";
                                    strSQL = strSQL + "VALUES (";
                                    strSQL = strSQL + "'" + oAssets[0].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "'" + strKey + "',";
                                    strSQL = strSQL + "'" + oAssets[1].Replace("'", "''") + "' ,";
                                    //strSQL = strSQL + "'" + oAssets[2].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(oAssets[2]) + ",";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(oAssets[3]) + ",";
                                    strSQL = strSQL + "'" + oAssets[4].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[5]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[6]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[7]) + ",";
                                    strSQL = strSQL + "'" + oAssets[8].Replace("'", "''") + "'";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (DG != "")
                        {
                            string[] words = DG.Split('~');
                            foreach (string ooassets in words)
                            {
                                string[] oAssets = ooassets.Split('!');
                                if (oAssets[0] != "")
                                {
                                    strSQL = "INSERT INTO SALES_TARGET_ITEM_TRAN (";
                                    strSQL = strSQL + "TARGET_ITEM_TRAN_KEY_REF,TARGET_ITEM_TRAN_KEY,";
                                    strSQL = strSQL + "STOCKCATEGORY_NAME,TARGET_ITEM_TRAN_FROM_DATE,TARGET_ITEM_TRAN_TO_DATE,TARGET_ITEM_TRAN_MONTH_ID,COL_POS,ROW_POS,TARGET_ITEM_TRAN_AMOUNT,LEDGER_NAME";
                                    strSQL = strSQL + ") ";
                                    strSQL = strSQL + "VALUES (";
                                    strSQL = strSQL + "'" + oAssets[0].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "'" + strKey + "',";
                                    strSQL = strSQL + "'" + oAssets[1].Replace("'", "''") + "' ,";
                                    //strSQL = strSQL + "'" + oAssets[2].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(oAssets[2]) + ",";
                                    strSQL = strSQL + "" + Utility.cvtSQLDateString(oAssets[3]) + ",";
                                    strSQL = strSQL + "'" + oAssets[4].Replace("'", "''") + "' ,";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[5]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[6]) + ",";
                                    strSQL = strSQL + " " + Utility.Val(oAssets[7]) + ",";
                                    strSQL = strSQL + "'" + oAssets[8].Replace("'", "''") + "'";
                                    strSQL = strSQL + ")";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                        }
                    }


                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return "1";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();
                }
            }
        }
        public List<SalesTarget> mFillItemPackTarget(string strDeComID)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<SalesTarget> oogrp = new List<SalesTarget>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            strSQL = "select SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_KEY, ACC_BRANCH.BRANCH_NAME,SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_FROM_DATE,";
            strSQL = strSQL + "SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_TO_DATE,SALES_TARGET_ITEM_PACK_MASTER.ITEM_TYPE   ";
            strSQL = strSQL + "from SALES_TARGET_ITEM_PACK_MASTER,ACC_BRANCH ";
            strSQL = strSQL + "where ACC_BRANCH.BRANCH_ID=SALES_TARGET_ITEM_PACK_MASTER.BRANCH_ID ";
            strSQL = strSQL + "ORDER BY SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_FROM_DATE ASC ";
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
                    SalesTarget ogrp = new SalesTarget();
                    ogrp.intType = Convert.ToInt16(drGetGroup["ITEM_TYPE"].ToString());
                    ogrp.strKey = drGetGroup["TARGET_ITEM_PACK_KEY"].ToString();
                    //ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    //ogrp.strMerzeName = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ogrp.strBranchName = drGetGroup["BRANCH_NAME"].ToString();
                    ogrp.strFromDate = Convert.ToDateTime(drGetGroup["TARGET_ITEM_PACK_FROM_DATE"]).ToString("dd/MM/yyyy");
                    ogrp.strToDate = Convert.ToDateTime(drGetGroup["TARGET_ITEM_PACK_TO_DATE"]).ToString("dd/MM/yyyy");
                    
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public List<SalesTarget> mDisplayItemTarget(string strDeComID, string strKey)
        {
            string strSQL,strLedgerName="";
            SqlDataReader drGetGroup;
            List<SalesTarget> oogrp = new List<SalesTarget>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

           
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmd = new SqlCommand();
                //strSQL = "SELECT LEDGER_NAME FROM SALES_TARGET_ITEM_TRAN ";
                //strSQL = strSQL + "where TARGET_ITEM_TRAN_KEY='" + strKey + "' ";
                //strSQL = strSQL + "ORDER BY LEDGER_NAME ASC ";
                //cmd.CommandText = strSQL;
                //cmd.Connection = gcnMain;
                //drGetGroup = cmd.ExecuteReader();
                //if   (drGetGroup.Read())
                //{
                //    strLedgerName = drGetGroup["LEDGER_NAME"].ToString();

                //}
                //drGetGroup.Close();
                strSQL = "select SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_KEY,ACC_LEDGER.LEDGER_NAME, ACC_LEDGER.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ACC_BRANCH.BRANCH_NAME,SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_FROM_DATE,";
                strSQL = strSQL + "SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_TO_DATE,SALES_TARGET_ITEM_TRAN.STOCKITEM_NAME,SALES_TARGET_ITEM_TRAN.COL_POS,SALES_TARGET_ITEM_TRAN.ROW_POS ,";
                strSQL = strSQL + "SALES_TARGET_ITEM_TRAN.TARGET_ITEM_TRAN_AMOUNT,SALES_TARGET_ITEM_TRAN.TARGET_ITEM_TRAN_MONTH_ID  ";
                strSQL = strSQL + "from SALES_TARGET_ITEM_PACK_MASTER,SALES_TARGET_ITEM_TRAN,ACC_LEDGER,ACC_BRANCH  ";
                strSQL = strSQL + "where  SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_KEY=SALES_TARGET_ITEM_TRAN.TARGET_ITEM_TRAN_KEY and ";
                strSQL = strSQL + "ACC_LEDGER.LEDGER_NAME =SALES_TARGET_ITEM_TRAN.LEDGER_NAME  and ACC_BRANCH.BRANCH_ID=SALES_TARGET_ITEM_PACK_MASTER.BRANCH_ID ";
                strSQL = strSQL + "AND SALES_TARGET_ITEM_PACK_MASTER.TARGET_ITEM_PACK_KEY='" + strKey + "' ";
                //strSQL = strSQL + "AND SALES_TARGET_ITEM_TRAN.LEDGER_NAME='" + strLedgerName + "' ";
                strSQL = strSQL + "ORDER BY ROW_POS,ACC_LEDGER.LEDGER_NAME_MERZE ASC ";
                cmd.CommandText = strSQL;
                cmd.Connection = gcnMain;
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    SalesTarget ogrp = new SalesTarget();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strMerzeName = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    ogrp.strMonthID = drGetGroup["TARGET_ITEM_TRAN_MONTH_ID"].ToString();
                    ogrp.intColPos = Convert.ToInt32(drGetGroup["COL_POS"].ToString());
                    ogrp.intRowPos = Convert.ToInt32(drGetGroup["ROW_POS"].ToString());
                    ogrp.dblAmount = Convert.ToDouble(drGetGroup["TARGET_ITEM_TRAN_AMOUNT"].ToString());
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public string mDeleteItemTarget(string strDeComID, string strKey)
        {
            string strSQL;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                try
                {

                    SqlCommand cmdDelete = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdDelete.Connection = gcnMain;
                    cmdDelete.Transaction = myTrans;
                    strSQL = "DELETE FROM SALES_TARGET_ITEM_TRAN WHERE TARGET_ITEM_TRAN_KEY='" + strKey + "' ";
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    strSQL = "DELETE FROM SALES_TARGET_ITEM_PACK_MASTER WHERE TARGET_ITEM_PACK_KEY='" + strKey + "' ";
                    cmdDelete.CommandText = strSQL;
                    cmdDelete.ExecuteNonQuery();
                    cmdDelete.Transaction.Commit();
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }



            }



        }
        

        #endregion
        #region "Production Batch"
        public List<MFGvouhcer> mGetProductionNoFBatch(string strDeComID, string vstrBatchNo)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<MFGvouhcer> oogrp = new List<MFGvouhcer>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "SELECT VOUCHER_NO,FG_SIZE,VOUCHER_DATE FROM INV_PRODUCTION_MASTER ";
                strSQL = strSQL + "WHERE INV_LOG_NO='" + vstrBatchNo + "' ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    MFGvouhcer ogrp = new MFGvouhcer();
                    ogrp.strVoucherNo = drGetGroup["VOUCHER_NO"].ToString();
                    ogrp.strBatchSize = drGetGroup["FG_SIZE"].ToString();
                    ogrp.strDate = Convert.ToDateTime(drGetGroup["VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    oogrp.Add(ogrp);

                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        #endregion
        #region "Outward Againt RefNo"
        public List<InvoiceConfig> mGetStockTranRefNo(string strDeComID, string strLocation, string strRefNo)
        {
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;

                List<InvoiceConfig> oooSamplePrint = new List<InvoiceConfig>();

                //if (strRefNo != "")
                //{
                strSQL = "select Distinct   m.INV_REF_NO RefNo,SUBSTRING( m.INV_REF_NO, 7, 30)INV_REF_NO  from INV_MASTER m, INV_TRAN T ";
                strSQL = strSQL + "where m.INV_REF_NO=T.INV_REF_NO  and  m.INV_TRAN_STATUS=1 ";
                //if (strLocation != "")
                //{
                strSQL = strSQL + "and t.GODOWNS_NAME='" + strLocation + "'";
                strSQL = strSQL + "and t.INV_INOUT_FLAG='O'";
                //}
                //}
                //else
                //{
                //    strSQL = "select Distinct   m.INV_REF_NO  from INV_MASTER m, INV_TRAN T ";
                //    strSQL = strSQL + "where m.INV_REF_NO=T.INV_REF_NO  and  m.INV_TRAN_STATUS=1 ";
                //    if (strRefNo != "")
                //    {
                //        strSQL = strSQL + "and SUBSTRING( m.INV_REF_NO, 7, 30)like '" + '%' + strRefNo + "'";
                //    }
                //}

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (strRefNo != "")
                    {
                        InvoiceConfig oLedg = new InvoiceConfig();
                        oLedg.strRefNo = dr["RefNo"].ToString();
                        oLedg.strAgnstRefNo = dr["INV_REF_NO"].ToString();
                        oooSamplePrint.Add(oLedg);
                    }
                    else
                    {
                        InvoiceConfig oLedg = new InvoiceConfig();
                        oLedg.strRefNo = dr["RefNo"].ToString();
                        oLedg.strAgnstRefNo = dr["INV_REF_NO"].ToString();
                        oooSamplePrint.Add(oLedg);
                    }
                }

                if (!dr.HasRows)
                {
                    InvoiceConfig oLedg = new InvoiceConfig();
                    oLedg.strAgnstRefNo = "";
                    oooSamplePrint.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return oooSamplePrint;
            }
        }

        #endregion
        #region "Dispaly Transfer"
        public List<ManuProcess> mDisplayTransferOutItem(string strDeComID, string strvoucherNo, string strflag)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ManuProcess> oogrp = new List<ManuProcess>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);



            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                strSQL = "select T.PROCESS_NAME,T.STOCKITEM_NAME,t.INV_TRAN_QUANTITY as PROCESS_QUANTITY ";
                strSQL = strSQL + ",t.INV_PER,t.FG_COST_PERCENT,t.INV_TRAN_RATE,t.OUTWARD_SALES_AMOUNT ";
                strSQL = strSQL + "from INV_TRAN t ";
                if (strvoucherNo != "")
                {
                    strSQL = strSQL + "where t.INV_REF_NO = '" + strvoucherNo  + "' ";

                }
                strSQL = strSQL + "and t.INV_INOUT_FLAG='O' ";

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    ManuProcess ogrp = new ManuProcess();
                    ogrp.strProcessName = drGetGroup["PROCESS_NAME"].ToString();
                    ogrp.stritemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.dblqnty = Math.Abs(Utility.Val(drGetGroup["PROCESS_QUANTITY"].ToString()));
                    ogrp.strUnit = drGetGroup["INV_PER"].ToString();
                    ogrp.intType = 1;
                    ogrp.dblCostPercent = Convert.ToDouble(drGetGroup["FG_COST_PERCENT"].ToString());
                    ogrp.dblCostPrice = Convert.ToDouble(drGetGroup["INV_TRAN_RATE"].ToString());
                    ogrp.dblsalesamount = Utility.Val(drGetGroup["OUTWARD_SALES_AMOUNT"].ToString());
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }
        #endregion
               #region "Requisition Out"
        public List<ManuProcess> mDisplayRequisitionNo(string strDeComID, string strRequisionNO)
        {
            string strSQL;
            SqlDataReader drGetGroup;
            List<ManuProcess> oogrp = new List<ManuProcess>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);



            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                strSQL = "select STOCKITEM_NAME,ITEM_QTY ,UNIT from INV_STOCK_REQUISITION_CHILD ";
                if (strRequisionNO != "")
                {
                    strSQL = strSQL + "WHERE REQUISITION_NO = '" + strRequisionNO + "' ";
                }

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {
                    ManuProcess ogrp = new ManuProcess();

                    ogrp.stritemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.dblqnty = Utility.Val(drGetGroup["ITEM_QTY"].ToString());
                    ogrp.strUnit = drGetGroup["UNIT"].ToString();

                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;
            }
        }
        public List<Invoice> mGetStockRequiNo(string strDeComID, string strLocation, string strRefNo)
        {
            string strSQL = null;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;

                List<Invoice> oooSamplePrint = new List<Invoice>();

                //if (strLocation != "")
                //{

                strSQL = "SELECT  REQUISITION_NO AS REQKEY ,SUBSTRING( REQUISITION_NO, 7, 30) as INV_REF_NO  from INV_STOCK_REQUISITION_MASTER ";
                //if (strLocation != "")
                //{
                    strSQL = strSQL + "WHERE GODOWNS_NAME='" + strLocation + "'";
                    strSQL = strSQL + "and REQ_STATUS=1 ";
                //}
                //}
                //else
                //{
                //    strSQL = "select Distinct   m.INV_REF_NO  from INV_MASTER m, INV_TRAN T ";
                //    strSQL = strSQL + "where m.INV_REF_NO=T.INV_REF_NO  and  m.INV_TRAN_STATUS=1 ";
                //    if (strRefNo != "")
                //    {
                //        strSQL = strSQL + "and SUBSTRING( m.INV_REF_NO, 7, 30)like '" + '%' + strRefNo + "'";
                //    }
                //}

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (strLocation != "")
                    {
                        Invoice oLedg = new Invoice();
                        oLedg.strBillKey = dr["REQKEY"].ToString();
                        oLedg.strRefNo = dr["INV_REF_NO"].ToString();
                        oooSamplePrint.Add(oLedg);
                    }
                    else
                    {
                        Invoice oLedg = new Invoice();
                        oLedg.strRefNo = dr["INV_REF_NO"].ToString();
                        oooSamplePrint.Add(oLedg);
                    }
                }

                if (!dr.HasRows)
                {
                    Invoice oLedg = new Invoice();
                    oLedg.strRefNo = "";
                    oooSamplePrint.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                cmd.Dispose();
                return oooSamplePrint;
            }
        }
     

        #endregion
        #region "Requisition"
        public string mUpdateRequisitionNew(string strDeComID, string strRefNoMarze, string strRefNo, long mlngVType, string strDate, double dblNetAmount, string strNarrations,
                                       string strBranchId, string strGodownName, string strProcessName, double dblNetQty, int intstatus, string DG, bool mblnNumbMethod)
        {
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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

                    strSQL = "DELETE FROM INV_STOCK_REQUISITION_CHILD WHERE REQUISITION_NO='" + strRefNoMarze + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_STOCK_REQUISITION_MASTER WHERE REQUISITION_NO='" + strRefNoMarze + "' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = Voucher.gInsertStockRequisitionMaster(strRefNoMarze, strDate, strBranchId, strProcessName, strGodownName, strNarrations, intstatus, dblNetQty, dblNetAmount, mlngVType);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    if (DG != "")
                    {
                        string  strItemName = "", strPer = "";
                        long lngBillPosition = 1, lngloop = 1;
                        double dblqty = 0, dblRate = 0,  dblTotalamnt;
                        string[] words = DG.Split('~');
                        foreach (string strValue in words)
                        {
                            string[] ooValue = strValue.Split('|');
                            if (ooValue[0] != "")
                            {

                                strItemName = ooValue[0].ToString();
                                dblqty = Utility.Val(ooValue[1].ToString());
                                strPer = ooValue[2].ToString();
                                dblRate = Utility.Val(ooValue[3].ToString());
                                dblTotalamnt = Utility.Val(ooValue[4].ToString());

                                strSQL = Voucher.gInsertInvStockReqisitionChild(strRefNoMarze, strItemName, dblqty, dblRate,
                                                                 strPer, dblTotalamnt);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();


                                lngBillPosition += 1;
                                lngloop += 1;
                            }
                        }
                        //if (mblnNumbMethod == true)
                        //{
                        //    strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
                        //    cmdInsert.CommandText = strSQL;
                        //    cmdInsert.ExecuteNonQuery();
                        //}
                        cmdInsert.Transaction.Commit();

                    }


                    gcnMain.Close();
                    return "Updated...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }

        public string mSaveRequisition(string strDeComID, string strRefNo, long mlngVType, string strDate, double dblNetAmount, string strNarrations,
                                        string strBranchId, string strGodownName,string strProcessName,double dblNetQty,int intstatus,string DG, bool mblnNumbMethod)
        {
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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

                    strSQL = Voucher.gInsertStockRequisitionMaster(strRefNo, strDate, strBranchId, strProcessName, strGodownName, strNarrations, intstatus, dblNetQty, dblNetAmount, mlngVType);
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    if (DG != "")
                    {
                        string  strItemName = "", strPer = "";
                        long lngBillPosition = 1, lngloop = 1;
                        double dblqty = 0, dblRate = 0,  dblTotalamnt;
                        string[] words = DG.Split('~');
                        foreach (string strValue in words)
                        {
                            string[] ooValue = strValue.Split('|');
                            if (ooValue[0] != "")
                            {
                               
                                strItemName = ooValue[0].ToString();
                                dblqty = Utility.Val(ooValue[1].ToString());
                                strPer = ooValue[2].ToString();
                                dblRate = Utility.Val(ooValue[3].ToString());
                                dblTotalamnt = Utility.Val(ooValue[4].ToString());

                                strSQL = Voucher.gInsertInvStockReqisitionChild( strRefNo,strItemName, dblqty, dblRate,
                                                                 strPer, dblTotalamnt);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            
                       
                                lngBillPosition += 1;
                                lngloop += 1;
                            }
                        }
                        if (mblnNumbMethod == true)
                        {
                            strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        cmdInsert.Transaction.Commit();

                    }


                    gcnMain.Close();
                    return "Inserted...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }
        }
        public string mUpdateRequisitionComm(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strBranchId, string strGodownName, string DG)
        {
            string strsubFroup = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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
                    strSQL = "DELETE FROM ACC_BILL_TRAN WHERE COMP_REF_NO = '" + strRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO = '" + strRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    if (DG != "")
                    {
                        string strBillKey = "", strItemName = "", strPer = "", strBatchNo = "", strGroupName = "";
                        long lngBillPosition = 1, lngloop = 1;
                        double dblqty = 0, dblRate = 0, dblDebitValue, dblbonus = 0, dblCommPer = 0, dblCommAmnt = 0, dblTotalamnt = 0;
                        string[] words = DG.Split('~');
                        foreach (string strValue in words)
                        {
                            string[] ooValue = strValue.Split('|');
                            if (ooValue[0] != "")
                            {
                                strBillKey = Utility.Mid(strRefNo, 9, strRefNo.Length - 9) + lngBillPosition.ToString().PadRight(4, '0');
                                strGroupName = ooValue[0].ToString();
                                strItemName = ooValue[1].ToString();
                                dblqty = Utility.Val(ooValue[4].ToString());
                                strPer = ooValue[6].ToString();
                                dblRate = Utility.Val(ooValue[5].ToString());
                                dblDebitValue = Utility.Val(ooValue[7].ToString());
                                dblbonus = Utility.Val(ooValue[8].ToString());
                                strsubFroup = ooValue[9].ToString();
                                dblTotalamnt = Utility.Val(ooValue[10].ToString());
                                dblCommAmnt = Utility.Val(ooValue[11].ToString());
                                dblCommPer = Utility.Val(ooValue[12].ToString());


                                strSQL = Voucher.gInsertBillTran(strBillKey, strRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblbonus,
                                                                    strPer, dblRate, dblCommAmnt, "0", dblTotalamnt, dblDebitValue, "Cr", lngloop, strBranchId,
                                                                     Utility.gstrBaseCurrency, strPer, "", "", strBatchNo, "", strsubFroup, "", strGroupName, 0, dblCommPer);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                //}

                                strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, strRefNo, strRefNo, mlngVType, strDate,
                                                                        strItemName, strGodownName, dblqty, strPer, strBillKey, 0, dblDebitValue, strPer);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET APPS_COMM_CAL=1 ";
                                strSQL = strSQL + "WHERE COMP_REF_NO='" + strRefNo + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lngBillPosition += 1;
                                lngloop += 1;
                            }
                        }
                        cmdInsert.Transaction.Commit();

                    }


                    gcnMain.Close();
                    return "1";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }



        }
        public string mUpdateRequisition(string strDeComID, string strRefNo, long mlngVType, string strDate, string strDueDate, string strMonthID, string strLedgerName,
                                       double dblNetAmount, string strNarrations, string strBranchId, string strGodownName, long lngIsMultiCurrency, string strProcessName,
                                       string strDelivery, string strPayment, string strSupport, string dteValidaty, string strOtherTerms, string DG,
                                       bool blnMultiCurr, double mdblCurrRate, string mstrFCsymbol, string strPrepareBy, int intAppStatus, string strApprovedBy,
                                        string strApprovedDate, double dblNetQty, int intChaneType)
        {
            string strsubFroup = "";
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
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
                    strSQL = "DELETE FROM ACC_BILL_TRAN WHERE COMP_REF_NO = '" + strRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO = '" + strRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "UPDATE ACC_COMPANY_VOUCHER SET ";
                    strSQL = strSQL + "COMP_REF_NO='" + strRefNo + "',";
                    strSQL = strSQL + "BRANCH_ID = '" + strBranchId + "',";
                    strSQL = strSQL + "LEDGER_NAME= '" + strLedgerName + "',";
                    strSQL = strSQL + "COMP_VOUCHER_DATE = " + Utility.cvtSQLDateString(strDate) + ",";
                    strSQL = strSQL + "COMP_VOUCHER_MONTH_ID = '" + strMonthID + "',";
                    strSQL = strSQL + "COMP_VOUCHER_NET_AMOUNT ='" + dblNetAmount + "',";
                    strSQL = strSQL + "COMP_VOUCHER_AMOUNT ='" + dblNetAmount + "',";
                    strSQL = strSQL + "APPS_COMP_QTY ='" + dblNetQty + "',";
                    strSQL = strSQL + "COMP_VOUCHER_DUE_DATE = " + Utility.cvtSQLDateString(strDueDate) + ", ";
                    strSQL = strSQL + "COMP_VOUCHER_NARRATION = '" + strNarrations + "'";
                    //strSQL = strSQL + ",AGNST_COMP_REF_NO ='" + Utility.Mid(strRefNo, 10, strRefNo.Length - 10) + "'";
                    strSQL = strSQL + ",APPROVED_BY ='" + strApprovedBy.Replace("'", "''") + "' ";
                    strSQL = strSQL + ",APPS_CHANGE =" + intChaneType + " ";
                    if (strApprovedDate != "")
                    {
                        strSQL = strSQL + ",APPROVED_DATE =" + Utility.cvtSQLDateString(strApprovedDate) + "";
                    }
                    else
                    {
                        strSQL = strSQL + ",APPROVED_DATE =NULL";
                    }
                    if (strDelivery != "")
                    {
                        strSQL = strSQL + ",COMP_DELIVERY = '" + strDelivery + "'";
                    }
                    if (strPayment != "")
                    {
                        strSQL = strSQL + ",COMP_TERM_OF_PAYMENTS = '" + strPayment + "'";
                    }
                    if (strSupport != "")
                    {
                        strSQL = strSQL + ",COMP_SUPPORT = '" + strSupport + "'";
                    }
                    if (dteValidaty != "")
                    {
                        strSQL = strSQL + ",COMP_VALIDITY_DATE = " + Utility.cvtSQLDateString(dteValidaty) + "";
                    }
                    else
                    {
                        strSQL = strSQL + ",COMP_VALIDITY_DATE = null";
                    }
                    if (strOtherTerms != "")
                    {
                        strSQL = strSQL + ",COMP_OTHERS = '" + strOtherTerms + "'";
                    }
                    if (strProcessName != Utility.gcEND_OF_LIST)
                    {
                        strSQL = strSQL + ",SALES_REP = '" + strProcessName + "' ";
                    }
                    else
                    {
                        strSQL = strSQL + ",SALES_REP = ''";
                    }
                    strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNo + "'";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    if (DG != "")
                    {
                        string strBillKey = "", strItemName = "", strPer = "", strBatchNo = "", strGroupName = "";
                        long lngBillPosition = 1, lngloop = 1;
                        double dblqty = 0, dblRate = 0, dblDebitValue, dblbonus = 0, dblCommPer = 0, dblCommAmnt = 0, dblTotalamnt = 0;
                        string[] words = DG.Split('~');
                        foreach (string strValue in words)
                        {
                            string[] ooValue = strValue.Split('|');
                            if (ooValue[0] != "")
                            {
                                strBillKey = Utility.Mid(strRefNo, 9, strRefNo.Length - 9) + lngBillPosition.ToString().PadRight(4, '0');
                                strGroupName = ooValue[0].ToString();
                                strItemName = ooValue[1].ToString();
                                dblqty = Utility.Val(ooValue[4].ToString());
                                strPer = ooValue[6].ToString();
                                dblRate = Utility.Val(ooValue[5].ToString());
                                dblDebitValue = Utility.Val(ooValue[7].ToString());
                                dblbonus = Utility.Val(ooValue[8].ToString());
                                strsubFroup = ooValue[9].ToString();
                                dblTotalamnt = Utility.Val(ooValue[10].ToString());
                                dblCommAmnt = Utility.Val(ooValue[11].ToString());
                                dblCommPer = Utility.Val(ooValue[12].ToString());
                             
                                strSQL = Voucher.gInsertBillTran(strBillKey, strRefNo, mlngVType, strDate, strItemName, strGodownName, dblqty, dblbonus,
                                                                    strPer, dblRate, dblTotalamnt, "0", dblCommAmnt, dblDebitValue, "Cr", lngloop, strBranchId,
                                                                     Utility.gstrBaseCurrency, strPer, "", "", strBatchNo, "", strsubFroup, "", strGroupName, 0, dblCommPer);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                //}

                                strSQL = Voucher.gInsertBillTranProcess(strBillKey, strBranchId, lngloop, strRefNo, strRefNo, mlngVType, strDate,
                                                                        strItemName, strGodownName, dblqty, strPer, strBillKey, 0, dblDebitValue, strPer);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET APPS_SYNCHONIZED =1 WHERE COMP_REF_NO='" + strRefNo + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                lngBillPosition += 1;
                                lngloop += 1;
                            }
                        }
                        cmdInsert.Transaction.Commit();

                    }


                    gcnMain.Close();
                    return "Updated...";

                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }
                finally
                {
                    gcnMain.Close();

                }
            }



        }






        #endregion
        


    }
}
