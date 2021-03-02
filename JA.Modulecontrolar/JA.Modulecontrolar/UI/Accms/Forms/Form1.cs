using Dutility;
using JA.Modulecontrolar.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class Form1 : Form
    {
        API.SWAPIClient objapi = new API.SWAPIClient();
        public Form1()
        {
            InitializeComponent();
        }
        //public static string WriteFromObject()
        //{
        //    // Create User object.  
        //    //var user = {"Bob", 42}

        //    //// Create a stream to serialize the object to.  
        //    //var ms = new MemoryStream();

        //    //// Serializer the User object to the stream.  
        //    //var ser = new DataContractJsonSerializer(typeof(User));
        //    //ser.WriteObject(ms, user);
        //    //byte[] json = ms.ToArray();
        //    //ms.Close();
        //    //return Encoding.UTF8.GetString(json, 0, json.Length);
        //}  

        private void Form1_Load(object sender, EventArgs e)
        {
            //var  test = objapi.mGetOTPNo("0002", "01700712449");
          

//            string test = objapi.mLoadStockGroup("0002");
           
            //MessageBox.Show(test);
            //this.DG.DefaultCellStyle.Font = new Font("verdana", 10);
            //DG.Columns.Add(Utility.Create_Grid_Column("Monthly", "Monthly", 250, true, DataGridViewContentAlignment.TopLeft, false));
            //DG.Columns.Add(Utility.Create_Grid_Column("", "", 250, true, DataGridViewContentAlignment.TopLeft, false));
            //DG.Rows.Add(2);
            //DG[0, 1].Value = "Sales";
            //DG[0, 2].Value = "Collection";


            //DG.Columns.Add(Utility.Create_Grid_Column("To Amount", "To Amount", 250, true, DataGridViewContentAlignment.TopLeft, false));
            //DG.Columns.Add(Utility.Create_Grid_Column("Get Comm.(%)", "Get Comm.(%)", 140, true, DataGridViewContentAlignment.TopLeft, false));
        }
    }
}
