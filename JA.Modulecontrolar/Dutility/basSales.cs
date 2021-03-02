using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Dutility
{
    public class basSales
    {
        public class ledger
        {
            public string LedgerName { get; set; }
        }
        public static List<ledger> gFillSalesLedger(string strComID,long  vlngSLedgerType =0,long  vlngPLedgerType=0,long vlngCash=0)
        {

            string strSQL;

            List<ledger> ooStr = new List<ledger>();
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
                    SqlCommand cmd = new SqlCommand();
                   
                    strSQL = "SELECT LEDGER_NAME FROM ACC_LEDGER ";
                    if (vlngSLedgerType != 0 )
                    {
                        strSQL = strSQL + "WHERE LEDGER_GROUP = " + vlngSLedgerType + " ";
                        strSQL = strSQL + "AND LEDGER_STATUS = 0 ";
                    }
                    strSQL = strSQL + "ORDER BY LEDGER_NAME";
                    cmd.Connection = gcnmain;
                    cmd.CommandText = strSQL;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ledger ostr = new ledger();
                        ostr.LedgerName = dr["LEDGER_NAME"].ToString();
                        ooStr.Add(ostr);
                        
                    }
                    dr.Close();
                    return ooStr;
                    
                }

                finally
                {
                    gcnmain.Close();
                }
            }
        }


        //public static string mInsertBillWise(string vstrLedgerName,string strGrid)
        //{

        //    string strSQL;
        //    using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
        //    {
        //        if (gcnmain.State == System.Data.ConnectionState.Open)
        //        {
        //            gcnmain.Close();
        //        }
        //        try
        //        {
        //            gcnmain.Open();
        //            SqlDataReader dr;
        //            SqlCommand cmdInsert = new SqlCommand();

        //            string strBranchName;
        //            double dblBranchAmount = 0;
        //            string[] words = strGrid.Split('~');
        //            foreach (string branch in words)
        //            {
        //                string[] ooBranch = branch.Split(',');

        //                if (ooBranch[0] != "")
        //                {
        //                    strBranchName = ooBranch[0].ToString();
        //                    dblBranchAmount = Convert.ToDouble(ooBranch[1]);
        //                    strSQL = "INSERT INTO ACC_BRANCH_LEDGER_OPENING (";
        //                    strSQL = strSQL + "BRANCH_LEDGER_KEY,BRANCH_ID, ";
        //                    strSQL = strSQL + "LEDGER_NAME,BRANCH_LEDGER_OPENING_BALANCE ";
        //                    strSQL = strSQL + ") ";
        //                    strSQL = strSQL + "VALUES (";
        //                    strSQL = strSQL + "'" + strLedgerName + Utility.gstrGetBranchID(strBranchName.Replace("'", "''")) + "' ,";
        //                    strSQL = strSQL + "'" + Utility.gstrGetBranchID(strBranchName.Replace("'", "''")) + "',";
        //                    strSQL = strSQL + "'" + strLedgerName + "',";
        //                    strSQL = strSQL + " " + dblBranchAmount * lngMultiply + " ";
        //                    strSQL = strSQL + ")";

        //                    cmdInsert.CommandText = strSQL;
        //                    cmdInsert.ExecuteNonQuery();
        //                }
        //            }

        //        }

        //        finally
        //        {
        //            gcnmain.Close();
        //        }
        //    }
        //}






    }
}
