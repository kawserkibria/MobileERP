using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace MayhediExportExcelToTree
{
     
   public class Export
    {

      
       public static void ExportToExcel(TreeView tvwGroup,string SavePath )
       {
           string csvData = "";
           if (File.Exists(@"C:\ExportedTree.csv"))
           {
               File.Delete(@"C:\ExportedTree.csv");
           }
           BuildCSV(tvwGroup.Nodes, ref csvData, 0);

           using (StreamWriter writer = new StreamWriter(@"C:\ExportedTree.csv"))
          // using (StreamWriter writer = new StreamWriter(strPath))
           {
               writer.Write(csvData);
           }

           ExpoertExcel(SavePath);
       }


       private static void BuildCSV(TreeNodeCollection nodes, ref string csvData, int depth)
       {
           foreach (TreeNode node in nodes)
           {
               csvData = csvData + new String(',', depth) + node.Text + "\n";

               if (node.Nodes.Count > 0)
                   BuildCSV(node.Nodes, ref csvData, depth + 1);
           }
       }

       private static void ExpoertExcel(string strTPath)
       {
           string csv = @"C:\ExportedTree.csv";
           //string xls = @"c:\output.xlsx";

          // string csv = strFPath;
           string xls = strTPath;


           // init the Appl obj
           Excel.Application xl = new Excel.Application();

           // get the worksheet
           Excel.Workbook wb = xl.Workbooks.Open(csv);
           Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.get_Item(1);

           // select the used range
           Excel.Range used = ws.UsedRange;

           // autofit the columns
           used.EntireColumn.AutoFit();

           // save as xlsx
           wb.SaveAs(xls, 51);

           wb.Close();
       }
       //private static void Convert_CSV_To_Excel(string strCSvPath,string ExcelPath)
       //{

        

       //    //string csv = @"C:\ExportedTree.csv";
       //    //string xls = @"c:\output.xlsx";

       //    string csv = strCSvPath;
       //    string xls = ExcelPath;


       //    // init the Appl obj
       //    Excel.Application xl = new Excel.Application();

       //    // get the worksheet
       //    Excel.Workbook wb = xl.Workbooks.Open(csv);
       //    Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.get_Item(1);

       //    // select the used range
       //    Excel.Range used = ws.UsedRange;

       //    // autofit the columns
       //    used.EntireColumn.AutoFit();

       //    // save as xlsx
       //    wb.SaveAs(xls, 51);

       //    wb.Close();
       //    xl.Quit();

       //}










    }
}
