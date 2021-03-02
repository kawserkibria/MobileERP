using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace Dutility
{
    public class StockSchema
    {
        public static string gCreateStock()
        {
            string strSQL;
            strSQL = CreateLocations();
            return strSQL;
        }

        private static string CreateLocations()
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

                    strSQL = "CREATE TABLE INV_GODOWNS(";
                    strSQL = strSQL + "GODOWNS_SERIAL numeric (18,0) IDENTITY (1,1) NOT NULL,";
                    strSQL = strSQL + "GODOWNS_NAME varchar(50) CONSTRAINT PK_INV_GODOWNS PRIMARY KEY,";
                    strSQL = strSQL + "GODOWNS_NAME_DEFAULT varchar(50) NULL,";
                    strSQL = strSQL + "GODOWNS_ADDRESS1 varchar(50) NULL,";
                    strSQL = strSQL + "GODOWNS_ADDRESS2 varchar(50) NULL,";
                    strSQL = strSQL + "GODOWNS_CITY varchar(50) NULL,";
                    strSQL = strSQL + "GODOWNS_PHONE varchar(50) NULL,";
                    strSQL = strSQL + "GODOWNS_FAX varchar(50) NULL,";
                    strSQL = strSQL + "BRANCH_ID char (4) NOT NULL CONSTRAINT FK_INV_GODOWNS_BRANCH_ID  REFERENCES ACC_BRANCH(BRANCH_ID),";
                    strSQL = strSQL + "GODOWNS_PARENT_GROUP varchar(50) NOT NULL,";
                    strSQL = strSQL + "GODOWNS_OPENING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_OPENING_VALUE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_OPENING_RATE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_CLOSING_BALANCE numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_INWARDQUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_OUTWARDQUANTITY numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "GODOWNS_DEFAULT numeric(18,2) default 0 NOT NULL,";
                    strSQL = strSQL + "INSERT_DATE datetime DEFAULT GETDATE() NOT NULL,";
                    strSQL = strSQL + "UPDATE_DATE datetime null,";
                    strSQL = strSQL + "EXPORT_TYPE smallint default 1 NOT NULL,";//    '1 = Not Exported, 2 = Exported, 3 = Imported
                    strSQL = strSQL + "EXPORT_FILE_NAME VARCHAR(25) NULL,";
                    strSQL = strSQL + "IMPORT_FILE_NAME VARCHAR(25) NULL";
                    strSQL = strSQL + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, gcnmain);
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
