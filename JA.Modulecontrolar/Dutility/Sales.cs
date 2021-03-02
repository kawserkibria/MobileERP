using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Dutility
{
    public class Sales
    {
        public class ledger
        {
            public string LedgerName { get; set; }
        }
        public static List<ledger> gFillSalesLedger(long  vlngSLedgerType =0,long  vlngPLedgerType=0,long vlngCash=0)
        {

            string strSQL;

            List<ledger> ooStr = new List<ledger>();
            using (SqlConnection gcnmain = new SqlConnection(Utility.SQLConnstring()))
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





    }
}
