using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutility
{
    public class basInventory
    {

        public static string GetEndGroup(string strComID,string sStart)
        {

            string strSQL, strGrpName = "";
            string conDb;
            SqlDataReader dr;
            conDb = Utility.SQLConnstringComSwitch(strComID);
             strSQL = "SELECT STOCKGROUP_PRIMARY FROM INV_STOCKGROUP ";
             strSQL = strSQL + "WHERE STOCKGROUP_NAME = '" + sStart + "' ";
             using (SqlConnection gcnMain = new SqlConnection(conDb))
             {
                 if (gcnMain.State == System.Data.ConnectionState.Open)
                 {
                     gcnMain.Close();
                 }
                 gcnMain.Open();
                 SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                 dr = cmd.ExecuteReader();
                 if (dr.Read())
                 {
                     strGrpName = dr["STOCKGROUP_PRIMARY "].ToString();
                 }
                 else
                 {
                     strGrpName = "PRIMARY";
                 }

                 dr.Close();
                 gcnMain.Close();
                 return strGrpName;


             }

        }
    }
}
