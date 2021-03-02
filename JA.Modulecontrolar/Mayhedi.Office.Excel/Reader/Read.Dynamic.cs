using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mayhedi.Reflection;

namespace Mayhedi.Office.Excel.Reader
{
    public partial class Read
    {
        public static string  ReadObjFromExel(Stream stream,string strSheetName)
        {
            string tt = "";
            var result = new List<object>();

            var columnHeaders = GetRowValues(stream, strSheetName, "1");
            var objProp = (columnHeaders.Where(header => !string.IsNullOrEmpty(header))
                .Select(header => new FieldMask()
                        {
                            FieldName=header,
                            FieldType = typeof(string)
                        })).ToList();
            
            //var excelHeaders = new List<string>();

            //for (var i = 1; i <= columnHeaders.Count; i++)
            //    excelHeaders.Add(Utility.IntToAlpha(i));

            //var rowsCount = excelHeaders.Select(header => GetColumnValues(stream, "", header.ToString()).Count).Concat(new[] {0}).Max();

            //for (var i = 1; i < rowsCount; i++)
            long k = 0;
            while (true)
            {
                var obj = WisganceTypeGenerator.CreateNewObject(objProp);

                var values = GetRowValues(stream, strSheetName, (k + 3).ToString());
              
              
                if (!values.Any())
                    break;
                string ss = "";
                for (var c = 0; c < objProp.Count; c++)
                {
                    try
                    {
                        var propertyInfo = obj.GetType().GetProperty(objProp[c].FieldName);
                        propertyInfo.SetValue(obj, values[c], null);
                       
                        if (c == objProp.Count - 1)
                        {
                            tt += values[c].ToString() + "~";
                        }
                        else
                        {
                            tt += values[c].ToString() + "!";
                        }
                       
                    }
                    catch (Exception) { }
                }

                result.Add(obj);
                k++;
            }

            return tt;
        }


        public static string ReadObjFromExelNew(Stream stream, string strSheetName)
        {
            string tt = "";
            var result = new List<object>();

            var columnHeaders = GetRowValues(stream, strSheetName, "1");
            var objProp = (columnHeaders.Where(header => !string.IsNullOrEmpty(header))
                .Select(header => new FieldMask()
                {
                    FieldName = header,
                    FieldType = typeof(string)
                })).ToList();

            //var excelHeaders = new List<string>();

            //for (var i = 1; i <= columnHeaders.Count; i++)
            //    excelHeaders.Add(Utility.IntToAlpha(i));

            //var rowsCount = excelHeaders.Select(header => GetColumnValues(stream, "", header.ToString()).Count).Concat(new[] {0}).Max();

            //for (var i = 1; i < rowsCount; i++)
            long k = 0;
            while (true)
            {
                var obj = WisganceTypeGenerator.CreateNewObject(objProp);

                var values = GetRowValues(stream, strSheetName, (k + 1).ToString());


                if (!values.Any())
                    break;
                string ss = "";
                for (var c = 0; c < objProp.Count; c++)
                {
                    try
                    {
                        var propertyInfo = obj.GetType().GetProperty(objProp[c].FieldName);
                        propertyInfo.SetValue(obj, values[c], null);

                        if (c == objProp.Count-1)
                        {
                            tt += values[c].ToString() + "~";
                        }
                        else
                        {
                            tt += values[c].ToString() + "!";
                        }

                    }
                    catch (Exception) { }
                }

                result.Add(obj);
                k++;
            }

            return tt;
        }


    }
}