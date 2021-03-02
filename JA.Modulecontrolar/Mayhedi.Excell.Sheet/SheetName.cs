using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayhedi.Excell.Sheet
{
    public class SheetName
    {
        public DataTable GetExcelSheetName(string strFile)
        {
            DataTable dt=null;
            OleDbConnection OleDbcon;
            if (!string.IsNullOrEmpty(strFile))
            {
                
                OleDbcon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFile + ";Extended Properties=Excel 12.0;");
                if (OleDbcon.State == ConnectionState.Open)
                {
                    OleDbcon.Close();
                }
                OleDbcon.Open();
                dt = OleDbcon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                OleDbcon.Close();
                //comboBox1.Items.Clear();
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    String sheetName = dt.Rows[i]["TABLE_NAME"].ToString();
                //    sheetName = sheetName.Substring(0, sheetName.Length - 1);
                //    comboBox1.Items.Add(sheetName);
                //}

            }
            return dt;
        }
    }
}
