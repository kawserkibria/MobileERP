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
    public partial class FrmCRF : Form
    {
        public string connstring = Utility.SQLConnstring();
        public FrmCRF()
        {
            InitializeComponent();
        }

        private void FrmCRF_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = Convert.ToDateTime(JA.Modulecontrolar.UI.Sales.Forms.frmReport.dt1);
            dateTimePicker2.Value = Convert.ToDateTime(JA.Modulecontrolar.UI.Sales.Forms.frmReport.dt2);
            //dateTimePicker2.Value = Convert.ToDateTime(JA.Modulecontrolar.Forms.FRMR.dt2);

            rp1();
        }


        public void rp1()
        {

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();





                //SqlDataAdapter Sqlda = new SqlDataAdapter("Arte", gcnMain);
                //Sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                ////Sqlda.SelectCommand.Parameters.AddWithValue("@aiddd", textBox1.Text);
                //DataTable dtb1 = new DataTable();
                //Sqlda.Fill(dtb1);
                //gcnMain.Close();

                ////JA.Modulecontrolar.CrystalReport.CR2 cr22 = new CrystalReport.CR2();

                //JA.Modulecontrolar.Report.CR2 cr22 = new Report.CR2();
                //cr22.Database.Tables["Area1"].SetDataSource(dtb1);

                //CRV.ReportSource = null;
                //CRV.ReportSource = cr22;
            }
        }

    }
}
