using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Accms.Forms;
using JA.Modulecontrolar.JACCMS;

using Dutility;
using JA.Modulecontrolar.JINVMS;

using TextObject = CrystalDecisions.CrystalReports.Engine.TextObject;
//using CrystalReportsReportDefModelLib;
//using JA.Modulecontrolar.CrystalReport;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace JA.Modulecontrolar.UI.Sales.Forms
{


    public partial class frmReport : Form
    {

        public static string tvvv;
        public static string dt1;
        public static string dt2;
        public static int But1;
        public string connstring = Utility.SQLConnstring();

        //SqlConnection sqlcon = new SqlConnection(@"Server=PC1\DEEPLAID;Database=SMS;User ID=sa;Password=manager; Max Pool Size=2000; Connect Timeout=1000;");
        public frmReport()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {


            JA.Modulecontrolar.UI.Sales.Forms.frmReport.dt1 = dateTimePicker1.Value.ToShortDateString();
            JA.Modulecontrolar.UI.Sales.Forms.frmReport.dt2 = dateTimePicker2.Value.ToShortDateString();



            //JA.Modulecontrolar.UI.Sales.Forms.frmReport.tvvv = textBox1.Text;




            JA.Modulecontrolar.UI.Sales.Forms.FrmCRF emp = new JA.Modulecontrolar.UI.Sales.Forms.FrmCRF();

            JA.Modulecontrolar.UI.Sales.Forms.FrmCRF c = new JA.Modulecontrolar.UI.Sales.Forms.FrmCRF();
            
         
            
            c.rp1();

            emp.Show();
         


  

        }
    }
}