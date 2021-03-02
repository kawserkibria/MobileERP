using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using D.API.Model;
using Dutility;
using System.IO;
using JA.CommonInsert;
using System.Net;


namespace D.API.Dal
{
    public class APIDal
    {
        private string connstring;

        #region "SMS"
        public string SendSMS(string phno, string msg)
        {

            ////string gg = Utility.gInsertSMS(strComID, dteImportDate.Text, phno, txtDivision.Text);
            ////return "1";

            string url = "https://gpcmp.grameenphone.com/gpcmpapi/messageplatform/controller.home?username=DeeplaidADMINN&password=Deeplaid_2000&apicode=1&msisdn=" + phno + "&countrycode=880&cli=DPL%20HR&messagetype=1&message=" + msg + "&messageid=0%20210 ";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {

                response.Close();

                //string jj = Utility.gInsertSMS(strComID, dteImportDate.Text, phno, txtDivision.Text);
                return "Sending Success...";
            }
            else
            {
                // EventLog.WriteEntry("ERROR in Sending Message of Mobile No: " + phno, "" + "Trace", EventLogEntryType.Error, 121, short.MaxValue);
                //Application.Exit();
                return "Sending Failed...";

            }
        }
        #endregion
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }  
        public string mobileSMSAPI(string strDeComID, string strMobileNo)
        {
            string strSQL,strResult="",i ="";


            SqlCommand cmdUpdate = new SqlCommand();
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
                    cmdUpdate.Connection = gcnMain;
                    strSQL = "SELECT COR_MOBILE_NO FROM  USER_ONLILE_SECURITY ";
                    strSQL = strSQL + "WHERE COR_MOBILE_NO='" + strMobileNo + "' ";
                    strSQL = strSQL + "AND STATUS=0 ";
                    cmdUpdate.CommandText = strSQL;
                    dr = cmdUpdate.ExecuteReader();
                    if (dr.Read())
                    {
                        strResult = dr["COR_MOBILE_NO"].ToString();
                        var otp = RandomNumber(100000, 900000);
                        if (strResult != "")
                        {
                            dr.Close();
                            var msg = "<>Your DeepLaid security code for APPS is : " + otp ;
                            i = SendSMS(strMobileNo, msg.ToString());
                            if (i == "Sending Success...")
                            {
                                strSQL = "UPDATE USER_ONLILE_SECURITY SET SECURITY_CODE='" + otp.ToString() + "' ";
                                strSQL = strSQL + "WHERE COR_MOBILE_NO='" + strMobileNo + "' ";
                                cmdUpdate.CommandText = strSQL;
                                cmdUpdate.ExecuteNonQuery();
                            }
                         
                        }

                    }
                    else
                    {
                        dr.Close();
                        i = "Your Mobile no is not Valid";
                    }
                    dr.Close();
                    return i;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }


            }
        }

        public AppsVercifysumm mobileSMSVerify(string strDeComID, string strMobileNo, string strOTP, string strSIMSL)
        {
            string strSQL, strResult = "", i = "";

            List<AppsVercify> objapps = new List<AppsVercify>();
            SqlCommand cmdUpdate = new SqlCommand();
            SqlDataReader dr;
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();
                cmdUpdate.Connection = gcnMain;
                strSQL = "SELECT USER_ID,PASSWORD,SECURITY_CODE FROM  USER_ONLILE_SECURITY ";
                strSQL = strSQL + "WHERE COR_MOBILE_NO='" + strMobileNo + "' ";
                strSQL = strSQL + "AND STATUS=0 ";
                cmdUpdate.CommandText = strSQL;
                dr = cmdUpdate.ExecuteReader();
                if (dr.Read())
                {
                    AppsVercify over = new AppsVercify();
                    strResult = dr["SECURITY_CODE"].ToString();

                    if (strResult == strOTP)
                    {
                        over.userid = dr["USER_ID"].ToString();
                        over.password = dr["PASSWORD"].ToString();
                        over.intResult = 1;
                        dr.Close();
                        strSQL = "UPDATE USER_ONLILE_SECURITY SET SIMSL='" + strSIMSL.ToString() + "' ";
                        strSQL = strSQL + "WHERE COR_MOBILE_NO='" + strMobileNo + "' ";
                        cmdUpdate.CommandText = strSQL;
                        cmdUpdate.ExecuteNonQuery();
                    }
                    else
                    {
                        dr.Close();
                        over.userid = "";
                        over.password = "";
                        over.intResult = 0;
                    }
                    objapps.Add(over);

                }
                else
                {
                    dr.Close();
                    AppsVercify over = new AppsVercify();
                    over.userid = "";
                    over.password = "";
                    over.intResult = 0;
                    objapps.Add(over);
                }
                dr.Close();
                AppsVercifysumm objSumm = new AppsVercifysumm();
                objSumm.summary = objapps;
                return objSumm;



            }
        }
        
        public string mGetActive(string strDeComID, string strName)
        {
            string strSQL;
            int intReturn = 0;

            SqlCommand cmdUpdate = new SqlCommand();
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
                    cmdUpdate.Connection = gcnMain;
                    strSQL = "SELECT GR_NAME FROM  ACC_LEDGERGROUP  ";
                    strSQL = strSQL + "WHERE GR_NAME='" + strName + "' ";
                    cmdUpdate.CommandText = strSQL;
                    dr = cmdUpdate.ExecuteReader();
                    if (dr.Read())
                    {

                        intReturn = 0;
                    }
                    else
                    {
                        intReturn = 1;
                    }
                    dr.Close();
                    if (intReturn == 1)
                    {
                        strSQL = "SELECT LEDGER_NAME FROM  ACC_LEDGER WHERE LEDGER_GROUP=202 ";
                        strSQL = strSQL + "AND LEDGER_NAME='" + strName + "' ";
                        cmdUpdate.CommandText = strSQL;
                        dr = cmdUpdate.ExecuteReader();
                        if (dr.Read())
                        {

                            return "0";//Mobile No is Already Exists
                        }
                        else
                        {
                            return "1";
                        }
                    }
                    else
                    {
                        return "0";
                    }
                    dr.Close();
                    gcnMain.Close();

                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }


            }
        }
        public string mGetOTPNo(string strDeComID, string strMobileNo, string strTokenNo)
        {
            string strSQL, strUserID = "";


            SqlCommand cmdUpdate = new SqlCommand();
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
                    cmdUpdate.Connection = gcnMain;
                    strSQL = "SELECT USER_ID,SECURITY_CODE,COR_MOBILE_NO FROM  USER_ONLILE_SECURITY ";
                    strSQL = strSQL + "WHERE COR_MOBILE_NO='" + strMobileNo + "' ";
                    strSQL = strSQL + "AND STATUS=0 ";
                    //strSQL = strSQL + "AND SECURITY_CODE is not null ";
                    cmdUpdate.CommandText = strSQL;
                    dr = cmdUpdate.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr["USER_ID"].ToString() != "")
                        {

                            strUserID = dr["USER_ID"].ToString();//Mobile No is Already Exists
                        }
                        else
                        {
                            strUserID = "";
                        }
                    }
                    else
                    {
                        strUserID = "";
                    }
                    return strUserID;
                    //dr.Close();
                    //strSQL = "SELECT COR_MOBILE_NO FROM  USER_ONLILE_SECURITY ";
                    //strSQL = strSQL + "WHERE COR_MOBILE_NO='" + strMobileNo + "' ";
                    //strSQL = strSQL + "AND STATUS=0 ";
                    //strSQL = strSQL + "AND (SECURITY_CODE is null or SECURITY_CODE ='')";
                    //cmdUpdate.CommandText = strSQL;
                    //dr = cmdUpdate.ExecuteReader();
                    //if (dr.Read())
                    //{
                    //    dr.Close();
                    //    strSQL = "UPDATE USER_ONLILE_SECURITY SET SECURITY_CODE='" + strTokenNo.Replace("'", "''") + "' ";
                    //    strSQL = strSQL + "WHERE COR_MOBILE_NO='" + strMobileNo + "' ";
                    //    cmdUpdate.CommandText = strSQL;
                    //    cmdUpdate.ExecuteNonQuery();
                    //    gcnMain.Dispose();
                    //    return Utility.Right(strTokenNo, 6);

                    //}
                    //else
                    //{
                    //    dr.Close();
                    //    gcnMain.Dispose();
                    //    return "1";//Mobile No is Not Valid

                    //}


                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }


            }
        }
        //public string  mGetOTPNo(string strDeComID, string strMobileNo,string strTokenNo)
        //{
        //    string strSQL;

            
        //    SqlCommand cmdUpdate = new SqlCommand();
        //    SqlDataReader dr;
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
        //            cmdUpdate.Connection = gcnMain;
        //            strSQL = "SELECT SECURITY_CODE,COR_MOBILE_NO FROM  USER_ONLILE_SECURITY ";
        //            strSQL = strSQL + "WHERE COR_MOBILE_NO='" + strMobileNo + "' ";
        //            strSQL = strSQL + "AND STATUS=0 ";
        //            strSQL = strSQL + "AND SECURITY_CODE is not null ";
        //            cmdUpdate.CommandText = strSQL;
        //            dr = cmdUpdate.ExecuteReader();
        //            if (dr.Read())
        //            {
        //                if (dr["SECURITY_CODE"].ToString() != "")
        //                {

        //                    return "0";//Mobile No is Already Exists
        //                }
        //            }
        //            dr.Close();
        //            strSQL = "SELECT COR_MOBILE_NO FROM  USER_ONLILE_SECURITY ";
        //            strSQL = strSQL + "WHERE COR_MOBILE_NO='" + strMobileNo + "' ";
        //            strSQL = strSQL + "AND STATUS=0 ";
        //            strSQL = strSQL + "AND (SECURITY_CODE is null or SECURITY_CODE ='')";
        //            cmdUpdate.CommandText = strSQL;
        //            dr = cmdUpdate.ExecuteReader();
        //            if (dr.Read())
        //            {
        //                dr.Close();
        //                strSQL = "UPDATE USER_ONLILE_SECURITY SET SECURITY_CODE='" + strTokenNo.Replace("'", "''") + "' ";
        //                strSQL = strSQL + "WHERE COR_MOBILE_NO='" + strMobileNo + "' ";
        //                cmdUpdate.CommandText = strSQL;
        //                cmdUpdate.ExecuteNonQuery();
        //                gcnMain.Dispose();
        //                return Utility.Right(strTokenNo, 6);
                      
        //            }
        //            else
        //            {
        //                dr.Close();
        //                gcnMain.Dispose();
        //                return "1";//Mobile No is Not Valid
                        
        //            }
                  
                    
        //        }
        //        catch (Exception ex)
        //        {
        //            return ex.ToString();
        //        }
              

        //    }
        //}
        public List<Commissionslab> mLoadCommissionSlab(string strDeComID)
        {
            string strSQL = "";

            SqlDataReader drGetGroup;
            List<Commissionslab> oogrp = new List<Commissionslab>();

            strSQL = "SELECT STOCKGROUP_NAME,AMOUNT_FORM,AMOUNT_TO,GROUP_PERCENTAGES,EFFECTIVE_DATE FROM INV_GROUP_COMMISSION_MASTER,INV_GROUP_COMMISSION_TRAN WHERE  ";
			strSQL =strSQL + "INV_GROUP_COMMISSION_MASTER.GROUP_COMMISSION_KEY=INV_GROUP_COMMISSION_TRAN.GROUP_COMMISSION_KEY ";
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

                    Commissionslab ogrp = new Commissionslab();
                    ogrp.groupName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    ogrp.dblFromRange = Convert.ToDouble(drGetGroup["AMOUNT_FORM"].ToString());
                    ogrp.dblToRange = Convert.ToDouble(drGetGroup["AMOUNT_TO"].ToString());
                    ogrp.dblPercentage = Convert.ToDouble(drGetGroup["GROUP_PERCENTAGES"].ToString());
                    ogrp.strDate  =Convert.ToDateTime(drGetGroup["EFFECTIVE_DATE"]).ToString("dd-MM-yyyy");
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<StockitemRate> mLoadItemRate(string strDeComID, string strItemName)
        {
            string strSQL = "";

            SqlDataReader drGetGroup;
            List<StockitemRate> oogrp = new List<StockitemRate>();

            strSQL = "SELECT INV_STOCKITEM.STOCKGROUP_NAME,INV_STOCKGROUP.GR_NAME , ";
            strSQL = strSQL + "INV_STOCKITEM.STOCKITEM_NAME, MAX(INV_SALES_PRICE.SALES_PRICE_AMOUNT) AS SALES_PRICE_AMOUNT FROM INV_SALES_PRICE,INV_STOCKITEM,INV_STOCKGROUP ";
            strSQL = strSQL + "WHERE INV_STOCKGROUP.STOCKGROUP_NAME  =INV_STOCKITEM.STOCKGROUP_NAME AND INV_STOCKITEM.STOCKITEM_NAME =INV_SALES_PRICE.STOCKITEM_NAME ";
            strSQL = strSQL + "AND INV_STOCKGROUP.GR_NAME IS NOT NULL ";
            strSQL = strSQL + "AND INV_SALES_PRICE.SALES_PRICE_EFFECTIVE_DATE <= " + Utility.cvtSQLDateString(DateTime.Now.ToString("dd-MM-yyyy")) + " ";
            if (strItemName != "")
            {
                strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_NAME ='" + strItemName.Replace("'", "''") + "' ";
            }

            strSQL = strSQL + "GROUP BY INV_STOCKITEM.STOCKGROUP_NAME,INV_STOCKITEM.STOCKITEM_NAME,INV_STOCKGROUP.GR_NAME ";
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

                    StockitemRate ogrp = new StockitemRate();
                    ogrp.groupName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    ogrp.commgroupgame = drGetGroup["GR_NAME"].ToString();
                    ogrp.itemName = drGetGroup["STOCKITEM_NAME"].ToString();
                    ogrp.dblRate = Convert.ToDouble(drGetGroup["SALES_PRICE_AMOUNT"].ToString());
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Stockgroup> mLoadStockGroup(string strDeComID)
        {
            string strSQL="";

            SqlDataReader drGetGroup;
            List<Stockgroup> oogrp = new List<Stockgroup>();

            strSQL = "SELECT STOCKGROUP_NAME FROM INV_STOCKGROUP WHERE STOCKGROUP_PRIMARY ='Finished Goods' and GR_NAME is not null ";
            strSQL = strSQL + "and G_STATUS =0 ";
            strSQL=strSQL +"ORDER BY STOCKGROUP_NAME ";
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
                   
                    Stockgroup ogrp = new Stockgroup();
                    ogrp.GroupName = drGetGroup["STOCKGROUP_NAME"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<MpoArea> mLoadMpoDivisionNew(string strDeComID, string strDivision)
        {
            string strSQL = "", strDiv = "";

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader drGetGroup;
            List<MpoArea> oogrp = new List<MpoArea>();

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {

                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                long lngslNo = Convert.ToInt64(strDivision);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                strSQL = "SELECT LEDGER_NAME  FROM USER_ONLILE_SECURITY WHERE LIST_M_D_A =" + lngslNo + " ";
                strSQL = strSQL + "AND MPO_TYPE =2 ";
                cmd.CommandText = strSQL;
                drGetGroup = cmd.ExecuteReader();
                if (drGetGroup.Read())
                {
                    strDiv = drGetGroup["LEDGER_NAME"].ToString();
                }
                drGetGroup.Close();
                strSQL = "SELECT TERITORRY_CODE ,LEDGER_NAME,TERRITORRY_NAME   FROM ACC_LEDGER_Z_D_A WHERE DIVISION ='" + strDiv + "' ";
                //strSQL = "SELECT TERITORRY_CODE,LEDGER_NAME,TERRITORRY_NAME FROM ACC_LEDGER WHERE LEDGER_PARENT_GROUP ='" + strDiv + "' ";
                strSQL = strSQL + "AND LEDGER_STATUS=0 ";
                connstring = Utility.SQLConnstringComSwitch(strDeComID);
                cmd.CommandText = strSQL;
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {

                    MpoArea ogrp = new MpoArea();
                    ogrp.strTC = drGetGroup["TERITORRY_CODE"].ToString();
                    ogrp.strMpoName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strTName = drGetGroup["TERRITORRY_NAME"].ToString();

                    oogrp.Add(ogrp);
                }
                if (!drGetGroup.HasRows)
                {
                    MpoArea ogrp = new MpoArea();
                    ogrp.strTC = "";
                    ogrp.strMpoName = "";
                    ogrp.strTName = "";
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<MpoArea> mLoadMpoArea(string strDeComID, string strDivision)
        {
            string strSQL = "",strDiv="";

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            SqlDataReader drGetGroup;
            List<MpoArea> oogrp = new List<MpoArea>();
          
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                long lngslNo = Convert.ToInt64(strDivision);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                strSQL = "SELECT LEDGER_NAME  FROM USER_ONLILE_SECURITY WHERE LIST_M_D_A =" + lngslNo + " ";
                strSQL = strSQL + "AND MPO_TYPE =1 ";
                cmd.CommandText = strSQL;
                drGetGroup = cmd.ExecuteReader();
                if (drGetGroup.Read())
                {
                    strDiv = drGetGroup["LEDGER_NAME"].ToString();
                }
                drGetGroup.Close();
                strSQL = "SELECT TERITORRY_CODE,LEDGER_NAME,TERRITORRY_NAME FROM ACC_LEDGER WHERE LEDGER_PARENT_GROUP ='" + strDiv + "' ";
                strSQL = strSQL + "AND LEDGER_STATUS=0 ";
                connstring = Utility.SQLConnstringComSwitch(strDeComID);
                cmd.CommandText = strSQL;
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {

                    MpoArea ogrp = new MpoArea();
                    ogrp.strTC = drGetGroup["TERITORRY_CODE"].ToString();
                    ogrp.strMpoName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.strTName = drGetGroup["TERRITORRY_NAME"].ToString();

                    oogrp.Add(ogrp);
                }
                if (!drGetGroup.HasRows)
                {
                    MpoArea ogrp = new MpoArea();
                    ogrp.strTC = "";
                    ogrp.strMpoName = "";
                    ogrp.strTName = "";
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public List<Division> mLoadMpoDivisoin(string strDeComID,string strArea)
        {
            string strSQL = "", strA="";

            SqlDataReader drGetGroup;
            List<Division> oogrp = new List<Division>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
        
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                long lngslNo = Convert.ToInt64(strArea);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                strSQL = "SELECT LEDGER_NAME  FROM USER_ONLILE_SECURITY WHERE LIST_M_D_A =" + lngslNo + " ";
                strSQL = strSQL + "AND MPO_TYPE =2 ";
                cmd.CommandText = strSQL;
                drGetGroup = cmd.ExecuteReader();
                if (drGetGroup.Read())
                {
                    strA = drGetGroup["LEDGER_NAME"].ToString();
                }
                drGetGroup.Close();
                strSQL = "SELECT DISTINCT AREA   FROM ACC_LEDGER_Z_D_A WHERE DIVISION  ='" + strA + "' ";
                connstring = Utility.SQLConnstringComSwitch(strDeComID);
                cmd.CommandText = strSQL;
                drGetGroup = cmd.ExecuteReader();
                while (drGetGroup.Read())
                {

                    Division ogrp = new Division();
                    ogrp.strDivision = drGetGroup["AREA"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }
        public MPO gstrGetMpoAreaDevisionList(string strDeComID,string strUserID,string strPassWord)
        {
            string strSQL = "";

            SqlDataReader drGetGroup;
            //List<MPO> oogrp = new List<MPO>();
            MPO ogrp = new MPO();
            SqlCommand cmd = new SqlCommand();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                cmd.Connection = gcnMain;
                strSQL = "SELECT USER_ID FROM USER_ONLILE_SECURITY WHERE STATUS=0 AND USER_ID ='" + strUserID + "' ";
                cmd.CommandText = strSQL;
                drGetGroup = cmd.ExecuteReader();
                if (!drGetGroup.HasRows)
                {
                    //MPO ogrp = new MPO();
                    ogrp.strResponse = "User ID Mismatch";
                    //oogrp.Add(ogrp);
                    return ogrp;
                }
                drGetGroup.Close();
                strSQL = "SELECT USER_ID FROM USER_ONLILE_SECURITY WHERE STATUS=0 AND PASSWORD ='" + strPassWord + "' ";
                strSQL = strSQL + "AND USER_ID ='" + strUserID + "' ";
                cmd.CommandText = strSQL;
                drGetGroup = cmd.ExecuteReader();
                if (!drGetGroup.HasRows)
                {
                    //MPO ogrp = new MPO();
                    ogrp.strResponse = "Password Mismatch";
                    //oogrp.Add(ogrp);
                    return ogrp;
                }
                drGetGroup.Close();

                strSQL = "SELECT USER_ID,PASSWORD,COR_MOBILE_NO,TC,TCNAME,LEDGER_NAME,MPO_TYPE,SECURITY_CODE,LIST_M_D_A FROM USER_ONLILE_SECURITY WHERE STATUS=0";
                strSQL = strSQL + "and USER_ID ='" + strUserID + "' ";
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                drGetGroup = cmd.ExecuteReader();
                if  (drGetGroup.Read())
                {

                    //MPO ogrp = new MPO();
                    ogrp.strUserID = drGetGroup["USER_ID"].ToString();
                    ogrp.strUserPassword = drGetGroup["PASSWORD"].ToString();
                    ogrp.strTeritorryCode = drGetGroup["TC"].ToString();
                    ogrp.strTeritorryName = drGetGroup["TCNAME"].ToString();
                    ogrp.strLedgerName = drGetGroup["LEDGER_NAME"].ToString();
                    ogrp.intMpoType = Convert.ToInt16(drGetGroup["MPO_TYPE"].ToString());
                    if (drGetGroup["COR_MOBILE_NO"].ToString() != "")
                    {
                        ogrp.strMobileNo = drGetGroup["COR_MOBILE_NO"].ToString();
                    }
                    else
                    {
                        ogrp.strMobileNo = "";
                    }
                    if (drGetGroup["SECURITY_CODE"].ToString() != "")
                    {
                        ogrp.strSecurityCode = drGetGroup["SECURITY_CODE"].ToString();
                    }
                    else
                    {
                        ogrp.strSecurityCode = "";
                    }
                    ogrp.lngUniqueNo = Convert.ToInt16(drGetGroup["LIST_M_D_A"].ToString());
                    ogrp.strResponse = "Yes";
                    //oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return ogrp;

            }
        }
        public List<Customer> mLoadCustomerName(string strDeComID, string strTc)
        {
            string strSQL = "";

            SqlDataReader drGetGroup;
            List<Customer> oogrp = new List<Customer>();

            strSQL = "SELECT LEDGER_NAME_MERZE from ACC_LEDGER  where LEDGER_GROUP =204 and TERITORRY_CODE ='" + strTc + "'  and LEDGER_STATUS =0 ";
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

                    Customer ogrp = new Customer();
                    ogrp.strCustomerName  = drGetGroup["LEDGER_NAME_MERZE"].ToString();
                    oogrp.Add(ogrp);
                }
                drGetGroup.Close();
                gcnMain.Dispose();
                return oogrp;

            }
        }

        public List<StockItem> mGetStockItemFromGroup(string strDeComID, string strGroupName, string strBranchID)
        {
            string strSQL = null;
            SqlDataReader dr;
            List<StockItem> ooItem = new List<StockItem>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;
                strSQL = "SELECT  STOCKITEM_NAME,STOCKITEM_BASEUNITS  ";
                strSQL = strSQL + "FROM INV_STOCKITEM ";
                strSQL = strSQL + " ORDER by STOCKITEM_NAME ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    StockItem oLedg = new StockItem();
                    oLedg.strItemName = dr["STOCKITEM_NAME"].ToString();
                    oLedg.strUnit = dr["STOCKITEM_BASEUNITS"].ToString();
                    ooItem.Add(oLedg);
                }
                if (!dr.HasRows)
                {
                    StockItem oLedg = new StockItem();
                    oLedg.strItemName = "";
                    oLedg.dblClsBalance = 0;
                    oLedg.strUnit = "";
                    ooItem.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                return ooItem;
            }
        }
        public string SaveAPISalesOrder(string strDeComID, string strSummary, string strDetails)
        {
            string strSQL="",strAgnstRefNo = "", vstrOrderNo = "", strDate = "", strMonthID = "", strDueDate = "", strLedgerName = "", 
                            strCutomer = "", strApprovedby = "", strApprovedDate = "",strTC="",strCustomer="",strSubGroup="";
            int intAppStstus = 0;
            double dblNetAmount = 0;
            long mlngVType = 0;
            string strBillKey = "", strItemName = "", strPer = "", strBatchNo = "", strGroupName = "",strNarration="";
            long lngBillPosition = 1, lngloop = 1;
            double dblqty = 0, dblRate = 0, dblDebitValue, dblbonus = 0;
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

                    if (strSummary != "")
                    {

                        string[] words = strSummary.Split('~');
                        foreach (string strValue in words)
                        {
                            string[] ooValue = strValue.Split('|');
                            if (ooValue[0] != "")
                            {
                                //vstrOrderNo = Utility.gstrLastNumber(strDeComID, 12);
                                int lngday, lngmm, lngYear;
                                lngday = Convert.ToInt16(Utility.Left(ooValue[4].ToString(), 2).PadLeft(2, '0'));
                                lngmm = Convert.ToInt16(ooValue[4].ToString().Substring(3, 2).PadLeft(2, '0'));
                                lngYear = Convert.ToInt16(Utility.Right(ooValue[4].ToString(), 4));
                                DateTime dteVoucherDate = new DateTime(lngYear, lngmm, lngday);
                                vstrOrderNo = "SO0001SO#" + ooValue[0];
                                strAgnstRefNo = ooValue[0];
                                strApprovedby = ooValue[1];
                                strApprovedDate = ooValue[2];

                                mlngVType = Convert.ToInt64(ooValue[3]);
                                strDate = dteVoucherDate.ToString("dd-MM-yyyy");
                                strMonthID = dteVoucherDate.ToString("MMMyy");
                                strDueDate = dteVoucherDate.ToString("dd-MM-yyyy");
                                // strLedgerName = ooValue[5];
                                dblNetAmount = Convert.ToDouble(ooValue[9]);
                                dblqty = Convert.ToDouble(ooValue[10]);
                                //strSalesRep = ooValue[8];
                                intAppStstus = Convert.ToInt32(ooValue[8]);
                                strTC=ooValue[5];
                                strCustomer =ooValue[7];
                                strNarration = ooValue[11].ToString() + "~" + ooValue[12].ToString();
                                strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER WHERE LEDGER_NAME_MERZE='" + ooValue[5].Replace("'", "''") + "' ";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {
                                    strCutomer = dr["LEDGER_NAME"].ToString();
                                }
                                else
                                {
                                    return "Error";
                                }
                                dr.Close();
                                strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER WHERE TERITORRY_CODE   ='" + ooValue[7].Replace("'", "''") + "' and LEDGER_GROUP =202 and LEDGER_STATUS =0 ";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {
                                    strLedgerName = dr["LEDGER_NAME"].ToString();
                                }
                                else
                                {
                                    return "Error";
                                }
                                dr.Close();

                                strSQL = Voucher.gInsertCompanyVoucher(vstrOrderNo, mlngVType, strDate, strMonthID, strDueDate, strLedgerName, 0, dblNetAmount, 0, 0, 0, strNarration,
                                                        "0001", 0, strAgnstRefNo, strCutomer, "", "", "", "", "", "", "", strApprovedby, strApprovedDate,
                                                        "", "", 0, 0, 0, 0, 0, intAppStstus, strApprovedby,strApprovedDate,strTC,strCustomer,dblqty,1);

                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                strSQL = Voucher.gIncreaseVoucher((int)mlngVType);
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }

                        if (strDetails != "")
                        {
                            dblNetAmount = 0;
                            string[] wordsdetails = strDetails.Split('~');
                            foreach (string strValue1 in wordsdetails)
                            {
                                string[] ooValue1 = strValue1.Split('|');
                                if (ooValue1[0] != "")
                                {
                                    //string ss = "1573926583000|Blank Tab|Blank Tab - 100mg (450gm)|380|3|0|Group - A|Pcs|0~1573926583001|Blank Tab|Blank Tab - 100mg (450gm)|380|3|0|Group - A|Pcs|0~";
                                    vstrOrderNo = "SO0001SO#" + ooValue1[0];
                                    strAgnstRefNo = ooValue1[0];
                                    strBillKey = ooValue1[0] + lngBillPosition.ToString().PadRight(4, '0');
                                    strGroupName = ooValue1[1].ToString();
                                    strItemName = ooValue1[2].ToString();
                                    dblRate = Utility.Val(ooValue1[3].ToString());
                                    dblqty = Utility.Val(ooValue1[4].ToString());
                                    strPer = ooValue1[7].ToString();
                                    dblbonus = Utility.Val(ooValue1[8].ToString());
                                    dblDebitValue = Utility.Val(ooValue1[3].ToString()) * Utility.Val(ooValue1[4].ToString());
                                    strSubGroup = ooValue1[6].ToString();

                                    strSQL = "SELECT BILL_TRAN_KEY FROM ACC_BILL_TRAN WHERE BILL_TRAN_KEY='" + strBillKey + "' ";
                                    cmdInsert.CommandText = strSQL;
                                    dr = cmdInsert.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        lngBillPosition += 1;
                                        strBillKey = ooValue1[0] + lngBillPosition.ToString().PadRight(4, '0');
                                    }
                                    dr.Close();

                                    strSQL = Voucher.gInsertBillTran(strBillKey, vstrOrderNo, mlngVType, strDate, strItemName, "Main Location", dblqty, dblbonus,
                                                                         strPer, dblRate, dblDebitValue, "0", 0, dblDebitValue, "Cr", lngloop, "0001",
                                                                          Utility.gstrBaseCurrency, strPer, "", "", strBatchNo, "", strSubGroup, "", strGroupName, 0, 0);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                   
                                    strSQL = Voucher.gInsertBillTranProcess(strBillKey, "0001", lngloop, vstrOrderNo, vstrOrderNo, mlngVType, strDate,
                                                                        strItemName, "Main Location", dblqty, strPer, strBillKey, 0, dblDebitValue, strPer);

                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    dblNetAmount = dblNetAmount + dblDebitValue;
                                   
                                    lngBillPosition += 1;
                                    lngloop += 1;
                                   
                                }
                            }
                           
                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET ORDER_DATE= " + Utility.cvtSQLDateString(strDate) + ",COMP_VOUCHER_AMOUNT=" + dblNetAmount + " ";
                            strSQL = strSQL + ",ORDER_NO='" + vstrOrderNo + "' ";
                            strSQL = strSQL + "WHERE COMP_REF_NO='" + vstrOrderNo + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();

                            
                        }
                    }
                    cmdInsert.Transaction.Commit();
                    //return vstrOrderNo;
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


        public summaryNew DisplayApiOrder(string strDeComID, string strTc, int intAppSync)
        {
            string strSQL = null, vstrOrderNo = "", strStringLedger = "", strUpdate = "";
            int status = 0;
            string Appriovedby = "", approveDate = "", date = "", doctor = "", mpo = "", orderId = "", strString = "", strDetails = "",strNarration="",strReceiptAdd="";
            double totalAmount = 0, totlaQty = 0;
            SqlDataReader dr;

            summaryNew ooItem = new summaryNew();
            List<summary1> ooItem2 = new List<summary1>();
            List<details> ooItem1 = new List<details>();

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;


                strSQL = "SELECT LEDGER_NAME ";
                strSQL = strSQL + " FROM USER_ONLILE_SECURITY ";
                strSQL = strSQL + " WHERE USER_ID= '" + strTc + "' ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    strStringLedger = dr["LEDGER_NAME"].ToString();
                }

                dr.Close();


                //strSQL = "SELECT COMP_REF_NO,APPROVED_BY,APPROVED_DATE ,COMP_VOUCHER_DATE,APPS_CUSTOMER_MERZE,APPS_TERITORRY_CODE,AGNST_COMP_REF_NO ";
                //strSQL = strSQL + ",APP_STATUS,COMP_VOUCHER_NET_AMOUNT,APPS_COMP_QTY FROM ACC_COMPANY_VOUCHER ";
                //strSQL = strSQL + " WHERE COMP_VOUCHER_TYPE =12 ";
                //strSQL = strSQL + " AND APPS_SYNCHONIZED = " + intAppSync;
                //if (strTc !="")
                //{
                //    strSQL = strSQL + "AND APPS_TERITORRY_CODE='" + strTc + "' ";
                //}
                ////strSQL = strSQL + "AND COMP_REF_NO='SO0001SO#1574316353000' ";


                strSQL = "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO,ACC_COMPANY_VOUCHER.APPROVED_BY,ACC_COMPANY_VOUCHER.APPROVED_DATE ,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE,ACC_COMPANY_VOUCHER.APPS_CUSTOMER_MERZE, ";
                strSQL = strSQL + "ACC_COMPANY_VOUCHER.APPS_TERITORRY_CODE,ACC_COMPANY_VOUCHER.AGNST_COMP_REF_NO ,ACC_COMPANY_VOUCHER.APP_STATUS,ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT,ACC_COMPANY_VOUCHER.APPS_COMP_QTY ";
                strSQL = strSQL + ",ACC_COMPANY_VOUCHER.COMP_VOUCHER_NARRATION FROM ACC_LEDGER_Z_D_A,ACC_COMPANY_VOUCHER  WHERE ACC_COMPANY_VOUCHER.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
                strSQL = strSQL + "and (ACC_LEDGER_Z_D_A.DIVISION ='" + strStringLedger + "'";
                strSQL = strSQL + "or ACC_LEDGER_Z_D_A.AREA ='" + strStringLedger + "'";
                strSQL = strSQL + " or ACC_LEDGER_Z_D_A.LEDGER_NAME = '" + strStringLedger + "') ";
                strSQL = strSQL + "AND  ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE =12  ";
                strSQL = strSQL + " AND ACC_COMPANY_VOUCHER.APPS_SYNCHONIZED =" + intAppSync + " ";
                if (intAppSync == 1)
                {
                    strSQL = strSQL + " AND ACC_COMPANY_VOUCHER.APP_STATUS =1 ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {

                    Appriovedby = Appriovedby = dr["APPROVED_BY"].ToString();
                    if (dr["APPROVED_DATE"].ToString() != "")
                    {
                        approveDate = Convert.ToDateTime(dr["APPROVED_DATE"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        approveDate = "";
                    }
                    date = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    doctor = dr["APPS_CUSTOMER_MERZE"].ToString();
                    mpo = dr["APPS_TERITORRY_CODE"].ToString();
                    orderId = dr["AGNST_COMP_REF_NO"].ToString();
                    status = Convert.ToInt16(dr["APP_STATUS"].ToString());
                    totlaQty = Convert.ToDouble(dr["APPS_COMP_QTY"].ToString());
                    totalAmount = Convert.ToDouble(dr["COMP_VOUCHER_NET_AMOUNT"].ToString());
                    if (dr["COMP_VOUCHER_NARRATION"].ToString() != "")
                    {
                        string[] words = dr["COMP_VOUCHER_NARRATION"].ToString().Split('~');
                        strNarration = words[0];
                        strReceiptAdd = words[1];
                    }
                    else
                    {
                        strNarration = "";
                        strReceiptAdd = "";
                    }
                    strString = strString + dr["COMP_REF_NO"].ToString() + "|" + Appriovedby + "|" + approveDate + "|" + date +
                                                    "|" + doctor + "|" + mpo + "|" + orderId + "|" + status + "|" + totlaQty + "|" + totalAmount + "|" + strNarration + "|" + strReceiptAdd + "~";
                }

                dr.Close();
                if (strString != "")
                {

                    string[] words = strString.Split('~');
                    foreach (string strValue in words)
                    {
                        string[] ooValue = strValue.Split('|');
                        if (ooValue[0] != "")
                        {
                            summary1 oLedg = new summary1();
                            vstrOrderNo = "SO0001SO#" + ooValue[6];
                            oLedg.approveBy = ooValue[1];
                            oLedg.approveDate = ooValue[2];
                            oLedg.date = ooValue[3];
                            oLedg.doctor = ooValue[4];
                            oLedg.mpo = ooValue[5];
                            oLedg.orderId = ooValue[6];
                            oLedg.status = Convert.ToInt16(ooValue[7]);
                            oLedg.totlaQty = Convert.ToDouble(ooValue[8]);
                            oLedg.totalAmount = Convert.ToDouble(ooValue[9]);
                            oLedg.newCustomer = ooValue[10].ToString();
                            oLedg.reciveAddress = ooValue[11].ToString();
                            strUpdate = strUpdate + vstrOrderNo + "~";
                            ooItem2.Add(oLedg);


                            strSQL = "SELECT ";
                            strSQL = strSQL + " b.STOCKGROUP_NAME,b.STOCKITEM_NAME,b.BILL_RATE, ";
                            strSQL = strSQL + "B.BILL_QUANTITY,B.BILL_NET_AMOUNT,B.AGNST_COMP_REF_NO1,c.AGNST_COMP_REF_NO,c.COMP_VOUCHER_DATE,C.APPS_TERITORRY_CODE,C.APPS_CUSTOMER_MERZE   FROM ACC_COMPANY_VOUCHER C,ACC_BILL_TRAN B  ";
                            strSQL = strSQL + " WHERE  C.COMP_REF_NO =B.COMP_REF_NO AND C.COMP_VOUCHER_TYPE =12 ";
                            strSQL = strSQL + "AND C.COMP_REF_NO='" + ooValue[0] + "' ";
                            cmdInsert.CommandText = strSQL;
                            dr = cmdInsert.ExecuteReader();
                            while (dr.Read())
                            {

                                strDetails = strDetails + dr["STOCKGROUP_NAME"].ToString() + "|" + dr["STOCKGROUP_NAME"].ToString() + "|" + dr["STOCKITEM_NAME"].ToString() + "|" + Convert.ToDouble(dr["BILL_RATE"].ToString()) + "|" + Convert.ToDouble(dr["BILL_QUANTITY"].ToString()) +
                                                         "|" + Convert.ToDouble(dr["BILL_NET_AMOUNT"].ToString()) + "|" + dr["AGNST_COMP_REF_NO"].ToString() + "|" +
                                                         dr["AGNST_COMP_REF_NO1"].ToString() + "|" + Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy") +
                                                         "|" + dr["APPS_CUSTOMER_MERZE"].ToString() + "|" + dr["APPS_TERITORRY_CODE"].ToString() + "~";
                            }

                            dr.Close();
                            if (strDetails != "")
                            {
                                string[] worddetails = strDetails.Split('~');
                                foreach (string strValueDetails in worddetails)
                                {
                                    string[] ooValue1 = strValueDetails.Split('|');
                                    if (ooValue1[0] != "")
                                    {
                                        details objdetails = new details();
                                        objdetails.mpo = ooValue1[10];
                                        objdetails.doctorName = ooValue1[9];
                                        objdetails.groupName = ooValue1[1];
                                        objdetails.itemName = ooValue1[2];
                                        objdetails.itemPrice = Convert.ToDouble(ooValue1[3]);
                                        objdetails.itemQuentity = Convert.ToDouble(ooValue1[4]);
                                        objdetails.itemTotalPrice = Convert.ToDouble(ooValue1[5]);
                                        objdetails.orderid = ooValue1[6];
                                        objdetails.slabgroupName = ooValue1[7];
                                        objdetails.date = ooValue1[8];
                                        ooItem1.Add(objdetails);

                                    }
                                }
                            }

                            if (strUpdate != "")
                            {
                                string[] wordUpdat = strUpdate.Split('~');
                                foreach (string strValueDetails in wordUpdat)
                                {
                                    if (strValueDetails != "")
                                    {
                                        if (intAppSync == 0)
                                        {
                                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET APPS_SYNCHONIZED=1 ";
                                            strSQL = strSQL + "WHERE COMP_REF_NO='" + strValueDetails + "' ";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                        if (intAppSync == 1)
                                        {
                                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET APPS_SYNCHONIZED=2 ";
                                            strSQL = strSQL + "WHERE COMP_REF_NO='" + strValueDetails + "' ";
                                            strSQL = strSQL + "AND APP_STATUS =1 ";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }


                        }
                    }
                }

                summaryNew objSumm = new summaryNew();
                objSumm.summary = ooItem2;
                objSumm.details = ooItem1;
                //ooItem.Add(objSumm);

                dr.Close();
                dr.Close();
                gcnMain.Close();
                return objSumm;
            }
        }

        public summaryNew DisplayApiChangeOrder(string strDeComID, string strTc)
        {
            string strSQL = null, vstrOrderNo = "", strStringLedger = "", strUpdate = "";
            int status = 0, intMpoType=0;
            string Appriovedby = "", approveDate = "", date = "", doctor = "", mpo = "", orderId = "", strString = "", strDetails = "";
            double totalAmount = 0, totlaQty = 0;
            SqlDataReader dr;

            summaryNew ooItem = new summaryNew();
            List<summary1> ooItem2 = new List<summary1>();
            List<details> ooItem1 = new List<details>();

            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;


                strSQL = "SELECT MPO_TYPE,LEDGER_NAME ";
                strSQL = strSQL + " FROM USER_ONLILE_SECURITY ";
                strSQL = strSQL + " WHERE USER_ID= '" + strTc + "' ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    strStringLedger = dr["LEDGER_NAME"].ToString();
                    intMpoType = Convert.ToInt16(dr["MPO_TYPE"].ToString());
                }

                dr.Close();


                //strSQL = "SELECT COMP_REF_NO,APPROVED_BY,APPROVED_DATE ,COMP_VOUCHER_DATE,APPS_CUSTOMER_MERZE,APPS_TERITORRY_CODE,AGNST_COMP_REF_NO ";
                //strSQL = strSQL + ",APP_STATUS,COMP_VOUCHER_NET_AMOUNT,APPS_COMP_QTY FROM ACC_COMPANY_VOUCHER ";
                //strSQL = strSQL + " WHERE COMP_VOUCHER_TYPE =12 ";
                //strSQL = strSQL + " AND APPS_SYNCHONIZED = " + intAppSync;
                //if (strTc !="")
                //{
                //    strSQL = strSQL + "AND APPS_TERITORRY_CODE='" + strTc + "' ";
                //}
                ////strSQL = strSQL + "AND COMP_REF_NO='SO0001SO#1574316353000' ";

                if (intMpoType == 0)
                {
                    strSQL = "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO,ACC_COMPANY_VOUCHER.APPROVED_BY,ACC_COMPANY_VOUCHER.APPROVED_DATE ,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE,ACC_COMPANY_VOUCHER.APPS_CUSTOMER_MERZE, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.APPS_TERITORRY_CODE,ACC_COMPANY_VOUCHER.AGNST_COMP_REF_NO ,ACC_COMPANY_VOUCHER.APP_STATUS,ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT,ACC_COMPANY_VOUCHER.APPS_COMP_QTY ";
                    strSQL = strSQL + "FROM ACC_LEDGER_Z_D_A,ACC_COMPANY_VOUCHER  WHERE ACC_COMPANY_VOUCHER.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
                    strSQL = strSQL + "and (ACC_COMPANY_VOUCHER.APPS_TERITORRY_CODE ='" + strTc + "' )";
                    strSQL = strSQL + "AND  ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE =12  ";
                    strSQL = strSQL + " AND ACC_COMPANY_VOUCHER.APPS_CHANGE =1 ";
                }
                else
                {
                    strSQL = "SELECT ACC_COMPANY_VOUCHER.COMP_REF_NO,ACC_COMPANY_VOUCHER.APPROVED_BY,ACC_COMPANY_VOUCHER.APPROVED_DATE ,ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE,ACC_COMPANY_VOUCHER.APPS_CUSTOMER_MERZE, ";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.APPS_TERITORRY_CODE,ACC_COMPANY_VOUCHER.AGNST_COMP_REF_NO ,ACC_COMPANY_VOUCHER.APP_STATUS,ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT,ACC_COMPANY_VOUCHER.APPS_COMP_QTY ";
                    strSQL = strSQL + "FROM ACC_LEDGER_Z_D_A,ACC_COMPANY_VOUCHER  WHERE ACC_COMPANY_VOUCHER.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
                    strSQL = strSQL + "and (ACC_LEDGER_Z_D_A.DIVISION ='" + strStringLedger + "'";
                    strSQL = strSQL + "or ACC_LEDGER_Z_D_A.AREA ='" + strStringLedger + "'";
                    strSQL = strSQL + " or ACC_LEDGER_Z_D_A.LEDGER_NAME = '" + strStringLedger + "') ";
                    strSQL = strSQL + "AND  ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE =12  ";
                    strSQL = strSQL + " AND ACC_COMPANY_VOUCHER.APPS_CHANGE =1 ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {

                    Appriovedby = Appriovedby = dr["APPROVED_BY"].ToString();
                    if (dr["APPROVED_DATE"].ToString() != "")
                    {
                        approveDate = Convert.ToDateTime(dr["APPROVED_DATE"]).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        approveDate = "";
                    }
                    date = Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy");
                    doctor = dr["APPS_CUSTOMER_MERZE"].ToString();
                    mpo = dr["APPS_TERITORRY_CODE"].ToString();
                    orderId = dr["AGNST_COMP_REF_NO"].ToString();
                    status = Convert.ToInt16(dr["APP_STATUS"].ToString());
                    totlaQty = Convert.ToDouble(dr["APPS_COMP_QTY"].ToString());
                    totalAmount = Convert.ToDouble(dr["COMP_VOUCHER_NET_AMOUNT"].ToString());

                    strString = strString + dr["COMP_REF_NO"].ToString() + "|" + Appriovedby + "|" + approveDate + "|" + date +
                                                    "|" + doctor + "|" + mpo + "|" + orderId + "|" + status + "|" + totlaQty + "|" + totalAmount + "~";
                }

                dr.Close();
                if (strString != "")
                {

                    string[] words = strString.Split('~');
                    foreach (string strValue in words)
                    {
                        string[] ooValue = strValue.Split('|');
                        if (ooValue[0] != "")
                        {
                            summary1 oLedg = new summary1();
                            vstrOrderNo = "SO0001SO#" + ooValue[6];
                            oLedg.approveBy = ooValue[1];
                            oLedg.approveDate = ooValue[2];
                            oLedg.date = ooValue[3];
                            oLedg.doctor = ooValue[4];
                            oLedg.mpo = ooValue[5];
                            oLedg.orderId = ooValue[6];
                            oLedg.status = Convert.ToInt16(ooValue[7]);
                            oLedg.totlaQty = Convert.ToDouble(ooValue[8]);
                            oLedg.totalAmount = Convert.ToDouble(ooValue[9]);
                            strUpdate = strUpdate + vstrOrderNo + "~";
                            ooItem2.Add(oLedg);


                            strSQL = "SELECT ";
                            strSQL = strSQL + " b.STOCKGROUP_NAME,b.STOCKITEM_NAME,b.BILL_RATE, ";
                            strSQL = strSQL + "B.BILL_QUANTITY,B.BILL_NET_AMOUNT,B.AGNST_COMP_REF_NO1,c.AGNST_COMP_REF_NO,c.COMP_VOUCHER_DATE,C.APPS_TERITORRY_CODE,C.APPS_CUSTOMER_MERZE   FROM ACC_COMPANY_VOUCHER C,ACC_BILL_TRAN B  ";
                            strSQL = strSQL + " WHERE  C.COMP_REF_NO =B.COMP_REF_NO AND C.COMP_VOUCHER_TYPE =12 ";
                            strSQL = strSQL + "AND C.COMP_REF_NO='" + ooValue[0] + "' ";
                            cmdInsert.CommandText = strSQL;
                            dr = cmdInsert.ExecuteReader();
                            while (dr.Read())
                            {

                                strDetails = strDetails + dr["STOCKGROUP_NAME"].ToString() + "|" + dr["STOCKGROUP_NAME"].ToString() + "|" + dr["STOCKITEM_NAME"].ToString() + "|" + Convert.ToDouble(dr["BILL_RATE"].ToString()) + "|" + Convert.ToDouble(dr["BILL_QUANTITY"].ToString()) +
                                                         "|" + Convert.ToDouble(dr["BILL_NET_AMOUNT"].ToString()) + "|" + dr["AGNST_COMP_REF_NO"].ToString() + "|" +
                                                         dr["AGNST_COMP_REF_NO1"].ToString() + "|" + Convert.ToDateTime(dr["COMP_VOUCHER_DATE"]).ToString("dd-MM-yyyy") +
                                                         "|" + dr["APPS_CUSTOMER_MERZE"].ToString() + "|" + dr["APPS_TERITORRY_CODE"].ToString() + "~";
                            }

                            dr.Close();
                            if (strDetails != "")
                            {
                                string[] worddetails = strDetails.Split('~');
                                foreach (string strValueDetails in worddetails)
                                {
                                    string[] ooValue1 = strValueDetails.Split('|');
                                    if (ooValue1[0] != "")
                                    {
                                        details objdetails = new details();
                                        objdetails.mpo = ooValue1[10];
                                        objdetails.doctorName = ooValue1[9];
                                        objdetails.groupName = ooValue1[1];
                                        objdetails.itemName = ooValue1[2];
                                        objdetails.itemPrice = Convert.ToDouble(ooValue1[3]);
                                        objdetails.itemQuentity = Convert.ToDouble(ooValue1[4]);
                                        objdetails.itemTotalPrice = Convert.ToDouble(ooValue1[5]);
                                        objdetails.orderid = ooValue1[6];
                                        objdetails.slabgroupName = ooValue1[7];
                                        objdetails.date = ooValue1[8];
                                        ooItem1.Add(objdetails);

                                    }
                                }
                            }

                           


                        }
                    }
                }

                summaryNew objSumm = new summaryNew();
                objSumm.summary = ooItem2;
                objSumm.details = ooItem1;
                //ooItem.Add(objSumm);

                dr.Close();
                dr.Close();
                gcnMain.Close();
                return objSumm;
            }
        }
        public List<notification> mGetAppsNotifucation(string strDeComID,string TC)
        {
            string strSQL = null, strStringLedger="";
            int intMpoType = 0;
            SqlDataReader dr;
            List<notification> ooItem = new List<notification>();
            connstring = Utility.SQLConnstringComSwitch(strDeComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;

                strSQL = "SELECT LEDGER_NAME,MPO_TYPE ";
                strSQL = strSQL + " FROM USER_ONLILE_SECURITY ";
                strSQL = strSQL + " WHERE USER_ID= '" + TC + "' ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    strStringLedger = dr["LEDGER_NAME"].ToString();
                    intMpoType =Convert.ToInt16( dr["MPO_TYPE"].ToString());
                }

                dr.Close();

                if (intMpoType == 0)
                {
                    strSQL = "SELECT  ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT,AGNST_COMP_REF_NO, APPS_TERITORRY_CODE,APP_STATUS from ACC_COMPANY_VOUCHER where COMP_VOUCHER_TYPE =12 and APP_STATUS in (2,3) and APPS_NOTIFICATION =3";
                    strSQL = strSQL + " AND APPS_TERITORRY_CODE='" + TC + "' ";
                }
                else
                {
                    strSQL = "SELECT ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT,";
                    strSQL = strSQL + "ACC_COMPANY_VOUCHER.APPS_TERITORRY_CODE,ACC_COMPANY_VOUCHER.AGNST_COMP_REF_NO ,ACC_COMPANY_VOUCHER.APP_STATUS ";
                    strSQL = strSQL + "FROM ACC_LEDGER_Z_D_A,ACC_COMPANY_VOUCHER  WHERE ACC_COMPANY_VOUCHER.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
                    strSQL = strSQL + "and (ACC_LEDGER_Z_D_A.DIVISION ='" + strStringLedger + "'";
                    strSQL = strSQL + "or ACC_LEDGER_Z_D_A.AREA ='" + strStringLedger + "'";
                    strSQL = strSQL + " or ACC_LEDGER_Z_D_A.LEDGER_NAME = '" + strStringLedger + "') ";
                    strSQL = strSQL + "AND  ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE =12  ";
                    strSQL = strSQL + "AND  ACC_COMPANY_VOUCHER.APP_STATUS in (2,3) ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    notification oLedg = new notification();
                    oLedg.orderid = dr["AGNST_COMP_REF_NO"].ToString();
                    oLedg.teritorrycode = dr["APPS_TERITORRY_CODE"].ToString();
                    oLedg.status = Convert.ToInt16(dr["APP_STATUS"].ToString());
                    oLedg.dblNetAmnt = Convert.ToDouble(dr["COMP_VOUCHER_NET_AMOUNT"]);
                    ooItem.Add(oLedg);
                    //objjsonData = objjsonData + JsonConvert.SerializeObject(oLedg);
                    //objjsonData = objjsonData.Replace("\"", "''");
                }
                if (!dr.HasRows)
                {
                    notification oLedg = new notification();
                    //oLedg.strGroupName = "";
                    oLedg.orderid = "";
                    oLedg.status = 0;
                    oLedg.teritorrycode = "";
                    ooItem.Add(oLedg);
                }
                dr.Close();
                gcnMain.Close();
                return ooItem;
            }
        }
        public int  mUpdateNotification(string strDeComID, string strDG)
        {
            string strSQL = null, vstrOrderNo="";
           
          
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

                    if (strDG != "")
                    {

                        string[] words = strDG.Split('~');
                        foreach (string strValue in words)
                        {
                            string[] ooValue = strValue.Split('|');
                            if (ooValue[0] != "")
                            {

                                vstrOrderNo = "SO0001SO#" + ooValue[0];


                                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET APPS_NOTIFICATION= 0 ";
                                strSQL = strSQL + "WHERE COMP_REF_NO='" + vstrOrderNo + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                            }
                        }

                    }
                    cmdInsert.Transaction.Commit();
                    gcnMain.Close();
                    return 1;
                }
                catch (Exception ex)
                {
                    return -1;
                }
             
            }
        }
        public string UpdateAPISalesOrder(string strDeComID, string strSummary)
        {
            string strSQL = "", strAgnstRefNo = "", vstrOrderNo = ""
                            , strApprovedby = "", strApprovedDate = "";
          
           
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

                    if (strSummary != "")
                    {

                        string[] words = strSummary.Split('~');
                        foreach (string strValue in words)
                        {
                            string[] ooValue = strValue.Split('|');
                            if (ooValue[0] != "")
                            {
                                //vstrOrderNo = Utility.gstrLastNumber(strDeComID, 12);
                                int lngday, lngmm, lngYear;
                                lngday = Convert.ToInt16(Utility.Left(ooValue[2].ToString(), 2).PadLeft(2, '0'));
                                lngmm = Convert.ToInt16(ooValue[2].ToString().Substring(3, 2).PadLeft(2, '0'));
                                lngYear = Convert.ToInt16(Utility.Right(ooValue[2].ToString(), 4));
                                DateTime dteVoucherDate = new DateTime(lngYear, lngmm, lngday);
                                vstrOrderNo = "SO0001SO#" + ooValue[0];
                                strAgnstRefNo = ooValue[0];
                                strApprovedby = ooValue[1];
                                strApprovedDate = ooValue[2];

                                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET APP_STATUS= 1 ";
                                strSQL = strSQL + ",APPROVED_BY='" + strApprovedby + "' ";
                                strSQL = strSQL + ",APPROVED_DATE=" + Utility.cvtSQLDateString(strApprovedDate) + " ";
                                strSQL = strSQL + "WHERE COMP_REF_NO='" + vstrOrderNo + "' ";
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
      
    }
}
