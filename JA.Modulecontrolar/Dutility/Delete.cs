using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutility
{
    public class Delete
    {


        public static string gDeleteRecord(string strComID, string vstrRefNo, long vlngVType, bool blngnumberMethod)
        {

            string strSQL, strBranchId, strStuJournal, strResponse, strChequeRefKey, strMrRefKey, strRefNoFromReader = "";
            long lngCnt;
            string dteDate;
            double dblTranTotal = 0;

            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstringComSwitch(strComID)))
            {
                if (gcnmain.State == System.Data.ConnectionState.Open)
                {
                    gcnmain.Close();
                }
                try
                {
                    gcnmain.Open();
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    SqlCommand cmd = new SqlCommand();

                    strSQL = "SELECT COMP_VOUCHER_DATE,BRANCH_ID,COMP_VOUCHER_AMOUNT";
                    strSQL = strSQL + "  FROM ACC_COMPANY_VOUCHER ";
                    strSQL = strSQL + " WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        strBranchId = dr["BRANCH_ID"].ToString();
                        dblTranTotal = Convert.ToDouble(dr["COMP_VOUCHER_AMOUNT"].ToString());
                        dteDate = dr["COMP_VOUCHER_DATE"].ToString();
                        //strStuJournal = dr["STU_JOUNAL_REF_NO"].ToString();
                        //strChequeRefKey = dr["CHEQUE_REF_NO_KEY"].ToString();
                        //strMrRefKey = dr["MR_REF_NO_KEY"].ToString();
                    }
                    dr.Close();
                    myTrans = gcnmain.BeginTransaction();
                    cmd.Transaction = myTrans;

                    strSQL = "SELECT COMP_REF_NO  FROM ACC_COMPANY_VOUCHER  WHERE  AGNST_COMP_REF_NO='" + vstrRefNo + "' ";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr["COMP_REF_NO"].ToString() != "")
                        {
                            return "Related Record Found You Must Delete First :" + Utility.Mid(dr["COMP_REF_NO"].ToString(), 6, dr["COMP_REF_NO"].ToString().Length - 6);
                        }
                    }
                    dr.Close();
                    strSQL = "SELECT LEDGER_NAME ,TEMPLATE_NAME ,INSTALLMET_NAME FROM ACC_PAYMENT_SCHEDULE WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    strSQL = strSQL + " AND RECEIVED_AMOUNT <0 ";
                    
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["LEDGER_NAME"].ToString() + "|" + dr["TEMPLATE_NAME"].ToString() + "|" + dr["INSTALLMET_NAME"].ToString() + "~" + strRefNoFromReader;
                    }

                    dr.Dispose();
                    if (strRefNoFromReader != "")
                    {
                        string[] words = strRefNoFromReader.Split('~');
                        foreach (string name in words)
                        {
                            string[] words1 = name.Split('|');
                            if (name.ToString() != "")
                            {
                                strSQL = "UPDATE  ACC_PAYMENT_SCHEDULE SET INSTALL_STATUS=0 ";
                                strSQL = strSQL + "WHERE LEDGER_NAME='" + words1[0].ToString() + "' ";
                                strSQL = strSQL + "AND TEMPLATE_NAME ='" + words1[1].ToString() + "' ";
                                strSQL = strSQL + "AND INSTALLMET_NAME='" + words1[2].ToString() + "' ";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        strSQL = "DELETE FROM ACC_PAYMENT_SCHEDULE WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                        cmd.CommandText = strSQL;
                        cmd.ExecuteNonQuery();
                    }
                    strRefNoFromReader = "";
                    strSQL = "UPDATE ACC_PAYMENT_SCHEDULE SET ";
                    strSQL = strSQL + "LEDGER_NAME=FROM_LEDGER_NAME";
                    strSQL = strSQL + ",FROM_LEDGER_NAME='Null' ";
                    strSQL = strSQL + ",NARRATION='Null' ";
                    strSQL = strSQL + ",transfer_type='N' ";
                    strSQL = strSQL + ",INSTALL_STATUS=0 ";
                    strSQL = strSQL + "WHERE NARRATION = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strRefNoFromReader = "";

                    strSQL = "SELECT VOUCHER_REF_KEY,LEDGER_NAME,VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,VOUCHER_TOBY FROM ACC_VOUCHER WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["VOUCHER_REF_KEY"].ToString() + "~" + strRefNoFromReader;
                    }

                    dr.Dispose();
                    if (strRefNoFromReader != "")
                    {
                        strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                        string[] words = strRefNoFromReader.Split('~');
                        foreach (string name in words)
                        {
                            if (name.ToString() != "")
                            {
                                strSQL = "DELETE FROM ACC_VOUCHER WHERE VOUCHER_REF_KEY = '" + name.ToString() + "'";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    strRefNoFromReader = "";


                    strSQL = "SELECT INV_TRAN_KEY FROM INV_TRAN WHERE INV_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["INV_TRAN_KEY"].ToString() + "~" + strRefNoFromReader;
                    }

                    dr.Dispose();
                    if (strRefNoFromReader != "")
                    {
                        strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                        string[] words = strRefNoFromReader.Split('~');
                        foreach (string name in words)
                        {
                            if (name.ToString() != "")
                            {
                                strSQL = "DELETE FROM INV_TRAN WHERE INV_TRAN_KEY= '" + name.ToString() + "'";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    strRefNoFromReader = "";

                    dr.Close();
                    strSQL = "DELETE FROM ACC_ADD_LESS WHERE ADD_LESS_COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_QUOTATION_TRAN WHERE QUOTE_REF_NO='" + vstrRefNo + "' ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "DELETE FROM ACC_QUOTATION_MASTER WHERE QUOTE_REF_NO='" + vstrRefNo + "' ";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    //strSQL = "DELETE FROM INV_EFFECT_PAYMENT WHERE INV_REF_NO = '" + vstrRefNo + "'";
                    //cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();
                    strSQL = "DELETE FROM VECTOR_TRANSACTION WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "SELECT VOUCHER_REF_KEY FROM ACC_BILL_WISE WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["VOUCHER_REF_KEY"].ToString() + "~" + strRefNoFromReader;
                    }
                    dr.Close();
                    if (strRefNoFromReader != "")
                    {
                        strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                        string[] words1 = strRefNoFromReader.Split('~');
                        foreach (string name in words1)
                        {
                            if (name.ToString() != "")
                            {
                                strSQL = "DELETE FROM ACC_BILL_WISE WHERE VOUCHER_REF_KEY = '" + name.ToString() + "'";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    strRefNoFromReader = "";
                    dr.Close();
                    strSQL = "SELECT BILL_TRAN_KEY,AGST_COMP_REF_NO FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["BILL_TRAN_KEY"].ToString() + "," + dr["AGST_COMP_REF_NO"].ToString() + "~" + strRefNoFromReader;
                    }
                    dr.Close();
                    if (strRefNoFromReader != "")
                    {
                        strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                        string[] words1 = strRefNoFromReader.Split('~');
                        foreach (string name in words1)
                        {
                            string[] ooCost = name.Split(',');
                            if (ooCost[0].ToString() != "")
                            {
                                strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE BILL_TRAN_KEY = '" + ooCost[0].ToString() + "'";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                                strSQL = "update ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS=0 ";
                                strSQL = strSQL + "WHERE COMP_REF_NO='" + ooCost[1] + "'";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    //strRefNoFromReader = "";


                    //strSQL = "SELECT BILL_TRAN_KEY FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    //cmd.CommandText = strSQL;
                    //dr = cmd.ExecuteReader();
                    //while (dr.Read())
                    //{
                    //    strRefNoFromReader = dr["BILL_TRAN_KEY"].ToString() + "~" + strRefNoFromReader;
                    //}
                    //dr.Close();
                    //if (strRefNoFromReader != "")
                    //{
                    //    strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                    //    string[] words1 = strRefNoFromReader.Split('~');
                    //    foreach (string name in words1)
                    //    {
                    //        if (name.ToString() != "")
                    //        {
                    //            strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE BILL_TRAN_KEY = '" + name.ToString() + "'";
                    //            cmd.CommandText = strSQL;
                    //            cmd.ExecuteNonQuery();
                    //        }
                    //    }
                    //}

                    strRefNoFromReader = "";
                    strSQL = "SELECT BILL_TRAN_KEY FROM ACC_BILL_TRAN WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["BILL_TRAN_KEY"].ToString() + "~" + strRefNoFromReader;
                    }
                    dr.Close();
                    if (strRefNoFromReader != "")
                    {
                        strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                        string[] words1 = strRefNoFromReader.Split('~');
                        foreach (string name in words1)
                        {
                            if (name.ToString() != "")
                            {
                                strSQL = "DELETE FROM ACC_BILL_TRAN WHERE BILL_TRAN_KEY = '" + name.ToString() + "'";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    strRefNoFromReader = "";



                    strSQL = "DELETE FROM ACC_VOUCHER_JOIN WHERE VOUCHER_JOIN_PRIMARY_REF = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_VOUCHER_JOIN_CLASS WHERE VOUCHER_JOIN_PRIMARY_REF = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    strSQL = "DELETE FROM ACC_COMPANY_VOUCHER WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    if (blngnumberMethod == true)
                    {

                        strSQL = "UPDATE ACC_VOUCHER_TYPE ";
                        strSQL = strSQL + "SET VOUCHER_TYPE_TOTAL_VOUCHER = VOUCHER_TYPE_TOTAL_VOUCHER - 1 ";
                        strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + vlngVType + " ";
                        cmd.CommandText = strSQL;
                        cmd.ExecuteNonQuery();
                        strSQL = "SELECT COUNT(COMP_REF_NO) AS CNT FROM ACC_COMPANY_VOUCHER ";
                        strSQL = strSQL + "WHERE COMP_VOUCHER_TYPE = " + vlngVType + " ";
                        cmd.CommandText = strSQL;
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {

                            lngCnt = Convert.ToInt64(dr["CNT"]);
                            if (lngCnt == 0)
                            {
                                dr.Close();
                                strSQL = "UPDATE ACC_VOUCHER_TYPE SET VOUCHER_TYPE_TOTAL_VOUCHER = 0 ";
                                strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + vlngVType + " ";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        dr.Close();
                    }
                    cmd.Transaction.Commit();
                    //gInsertDeleteLog vstrRefNo, dteDate, vtSALES_CHALLAN, strBranchId
                    //            If gblnAccessControl Then
                    //    'gblnAuditTrail gstrUserName, dteDate, "Sales Challan", vstrRefNo, _
                    //     ttDEL_DATA, 0, mtSALES, strBranchId
                    //End If
                    strResponse = "Delete Successfull..";
                    return strResponse;
                }
                catch (Exception ex)
                {
                    return "Ralated Transaction Found,Can't Delete";
                }
                finally
                {
                    gcnmain.Close();
                }
            }
        }


        public static string gDeleteRecordforUpdate(string strComID,string vstrRefNo, long vlngVType)
        {

            string strSQL, strBranchId, strStuJournal, strResponse, strChequeRefKey, strMrRefKey, strRefNoFromReader = "";
            //long lngCnt;
            string dteDate;
            double dblTranTotal = 0;

            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstringComSwitch(strComID)))
            {
                if (gcnmain.State == System.Data.ConnectionState.Open)
                {
                    gcnmain.Close();
                }
                try
                {
                    gcnmain.Open();
                    SqlDataReader dr;
                    SqlTransaction myTrans;
                    SqlCommand cmd = new SqlCommand();

                    strSQL = "SELECT COMP_VOUCHER_DATE,BRANCH_ID,COMP_VOUCHER_AMOUNT";
                    strSQL = strSQL + "  FROM ACC_COMPANY_VOUCHER ";
                    strSQL = strSQL + " WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        strBranchId = dr["BRANCH_ID"].ToString();
                        dblTranTotal = Convert.ToDouble(dr["COMP_VOUCHER_AMOUNT"].ToString());
                        dteDate = dr["COMP_VOUCHER_DATE"].ToString();
                        //strStuJournal = dr["STU_JOUNAL_REF_NO"].ToString();
                        //strChequeRefKey = dr["CHEQUE_REF_NO_KEY"].ToString();
                        //strMrRefKey = dr["MR_REF_NO_KEY"].ToString();
                    }
                    dr.Close();
                    myTrans = gcnmain.BeginTransaction();
                    cmd.Transaction = myTrans;
                    strSQL = "SELECT VOUCHER_REF_KEY,LEDGER_NAME,VOUCHER_DEBIT_AMOUNT,VOUCHER_CREDIT_AMOUNT,VOUCHER_TOBY FROM ACC_VOUCHER WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["VOUCHER_REF_KEY"].ToString() + "~" + strRefNoFromReader;
                    }

                    dr.Dispose();
                    if (strRefNoFromReader != "")
                    {
                        strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                        string[] words = strRefNoFromReader.Split('~');
                        foreach (string name in words)
                        {
                            if (name.ToString() != "")
                            {
                                strSQL = "DELETE FROM ACC_VOUCHER WHERE VOUCHER_REF_KEY = '" + name.ToString() + "'";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    strRefNoFromReader = "";


                    strSQL = "SELECT INV_TRAN_KEY FROM INV_TRAN WHERE INV_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["INV_TRAN_KEY"].ToString() + "~" + strRefNoFromReader;
                    }

                    dr.Dispose();
                    if (strRefNoFromReader != "")
                    {
                        strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                        string[] words = strRefNoFromReader.Split('~');
                        foreach (string name in words)
                        {
                            if (name.ToString() != "")
                            {
                                strSQL = "DELETE FROM INV_TRAN WHERE INV_TRAN_KEY= '" + name.ToString() + "'";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    strRefNoFromReader = "";

                    dr.Close();
                    strSQL = "DELETE FROM ACC_ADD_LESS WHERE ADD_LESS_COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "DELETE FROM INV_MASTER WHERE INV_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    //strSQL = "DELETE FROM INV_EFFECT_PAYMENT WHERE INV_REF_NO = '" + vstrRefNo + "'";
                    //cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();
                    strSQL = "DELETE FROM VECTOR_TRANSACTION WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    strSQL = "SELECT VOUCHER_REF_KEY FROM ACC_BILL_WISE WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["VOUCHER_REF_KEY"].ToString() + "~" + strRefNoFromReader;
                    }
                    dr.Close();
                    if (strRefNoFromReader != "")
                    {
                        strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                        string[] words1 = strRefNoFromReader.Split('~');
                        foreach (string name in words1)
                        {
                            if (name.ToString() != "")
                            {
                                strSQL = "DELETE FROM ACC_BILL_WISE WHERE VOUCHER_REF_KEY = '" + name.ToString() + "'";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    strRefNoFromReader = "";
                    dr.Close();
                    strSQL = "SELECT BILL_TRAN_KEY FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["BILL_TRAN_KEY"].ToString() + "~" + strRefNoFromReader;
                    }
                    dr.Close();
                    if (strRefNoFromReader != "")
                    {
                        strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                        string[] words1 = strRefNoFromReader.Split('~');
                        foreach (string name in words1)
                        {
                            if (name.ToString() != "")
                            {
                                strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE BILL_TRAN_KEY = '" + name.ToString() + "'";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    //strRefNoFromReader = "";

                    //strSQL = "SELECT BILL_TRAN_KEY FROM ACC_BILL_TRAN_PROCESS WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    //cmd.CommandText = strSQL;
                    //dr = cmd.ExecuteReader();
                    //while (dr.Read())
                    //{
                    //    strRefNoFromReader = dr["BILL_TRAN_KEY"].ToString() + "~" + strRefNoFromReader;
                    //}
                    //dr.Close();
                    //if (strRefNoFromReader != "")
                    //{
                    //    strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                    //    string[] words1 = strRefNoFromReader.Split('~');
                    //    foreach (string name in words1)
                    //    {
                    //        if (name.ToString() != "")
                    //        {
                    //            strSQL = "DELETE FROM ACC_BILL_TRAN_PROCESS WHERE BILL_TRAN_KEY = '" + name.ToString() + "'";
                    //            cmd.CommandText = strSQL;
                    //            cmd.ExecuteNonQuery();
                    //        }
                    //    }
                    //}

                    strRefNoFromReader = "";
                    strSQL = "SELECT BILL_TRAN_KEY FROM ACC_BILL_TRAN WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strRefNoFromReader = dr["BILL_TRAN_KEY"].ToString() + "~" + strRefNoFromReader;
                    }
                    dr.Close();
                    if (strRefNoFromReader != "")
                    {
                        strRefNoFromReader = strRefNoFromReader.ToString().Substring(0, strRefNoFromReader.Length - 1);

                        string[] words1 = strRefNoFromReader.Split('~');
                        foreach (string name in words1)
                        {
                            if (name.ToString() != "")
                            {
                                strSQL = "DELETE FROM ACC_BILL_TRAN WHERE BILL_TRAN_KEY = '" + name.ToString() + "'";
                                cmd.CommandText = strSQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    strRefNoFromReader = "";


                    //strSQL = "DELETE FROM ACC_COMPANY_VOUCHER WHERE COMP_REF_NO = '" + vstrRefNo + "'";
                    //cmd.CommandText = strSQL;
                    //cmd.ExecuteNonQuery();

                    //strSQL = "SELECT COUNT(COMP_REF_NO) AS CNT FROM ACC_COMPANY_VOUCHER ";
                    //strSQL = strSQL + "WHERE COMP_VOUCHER_TYPE = " + vlngVType + " ";
                    //cmd.CommandText = strSQL;
                    //dr = cmd.ExecuteReader();
                    //if (dr.Read())
                    //{

                    //    lngCnt = Convert.ToInt64(dr["CNT"]);
                    //    if (lngCnt == 0)
                    //    {
                    //        dr.Close();
                    //        strSQL = "UPDATE ACC_VOUCHER_TYPE SET VOUCHER_TYPE_TOTAL_VOUCHER = 0 ";
                    //        strSQL = strSQL + "WHERE VOUCHER_TYPE_VALUE = " + vlngVType + " ";
                    //        cmd.CommandText = strSQL;
                    //        cmd.ExecuteNonQuery();
                    //    }
                    //}
                    dr.Close();
                 
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    strResponse = "Yes";
                    return strResponse;
                }

                finally
                {
                    gcnmain.Close();
                }
            }
        }





    }
}
