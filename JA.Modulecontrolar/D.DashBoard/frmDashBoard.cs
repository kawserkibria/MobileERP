using Dutility;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D.DashBoard
{
    public partial class frmDashBoard : Form
    {
        string strComID { get; set; }
        string strFormatDate = "", strFormatToDate = "", strFormatLastDate = "", strYearFormDate = "",
                        strCurrentTdate = "", strCurrentFdate = "", strCurrentDate = "";
        int i;
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer tmr = null;
        public frmDashBoard()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User Define Event"
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            this.DG.Paint += new System.Windows.Forms.PaintEventHandler(this.DG_Paint);

            this.btnDisplay2.Click += new System.EventHandler(this.btnDisplay2_Click);
            #endregion
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
           
            timer1.Start();
            timer2.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            
            timer1.Stop();
        }
        #region "Class"
        public class Zone
        {
            public string strZoneName { get; set; }
            public string strDivision { get; set; }
            public string strArea { get; set; }
            public double dblSalesTarget { get; set; }
            public double dblSaleAchv { get; set; }
            public double dblCollTarget { get; set; }
            public double dblCollAch { get; set; }

            public double dblSalesTargetMonthlyTotal { get; set; }
            public double dblSaleAchvMonthlyTotal { get; set; }
            public double dblCollTargetMonthlyTotal { get; set; }
            public double dblCollAchMonthlyTotal { get; set; }


            public double dblSalesTargetYearly { get; set; }
            public double dblSaleAchvYearly { get; set; }
            public double dblCollTargetYearly { get; set; }
            public double dblCollAchYearly { get; set; }


            public double dblSalesTargetYearlyTotal { get; set; }
            public double dblSaleAchvYearlyTotal { get; set; }
            public double dblCollTargetYearlyTotal { get; set; }
            public double dblCollAchYearlyTotal { get; set; }
            public string strMobile { get; set; }
            public string strContact { get; set; }
            public string strMobi { get; set; }
        }
        #endregion
        #region "Function"
        public List<Zone> GetZone()
        {
            string strSQL = null;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            List<Zone> objList = new List<Zone>();
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                strSQL = "SELECT DISTINCT ZONE FROM ACC_LEDGER_Z_D_A WHERE ZONE LIKE '%Zone%' and ZONE <> 'X-MPO Accounts-Zone' ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Zone oozone = new Zone();
                    oozone.strZoneName = dr["ZONE"].ToString();
                    objList.Add(oozone);
                }
                return objList;
            }
        }
       
        public long  GetTotalMPO(string strZone)
        {
            string strSQL = null;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
          
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                strSQL = "SELECT COUNT(LEDGER_STATUS) LEDGER_STATUS FROM ACC_LEDGER_Z_D_A WHERE ZONE ='" + strZone + "'  AND LEDGER_STATUS =0 ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    return Convert.ToInt64(dr["LEDGER_STATUS"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        public long GetTotalMPO1(string strZone)
        {
            string strSQL = null;
            string connstring = Utility.SQLConnstringComSwitch(strComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                strSQL = "SELECT COUNT(LEDGER_STATUS) LEDGER_STATUS FROM ACC_LEDGER_Z_D_A WHERE ZONE in(" + strZone + ")  AND LEDGER_STATUS =0 ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    return Convert.ToInt64(dr["LEDGER_STATUS"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        public long GetTotalDivisoion1(string strZone)
        {
            string strSQL = null;
            string connstring = Utility.SQLConnstringComSwitch(strComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                strSQL = "SELECT count(distinct DIVISION ) LEDGER_STATUS FROM ACC_LEDGER_Z_D_A WHERE ZONE in(" + strZone + ")  AND LEDGER_STATUS =0 ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    return Convert.ToInt64(dr["LEDGER_STATUS"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        public long GetTotalArea1(string strZone)
        {
            string strSQL = null;
            string connstring = Utility.SQLConnstringComSwitch(strComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                strSQL = "SELECT count(distinct AREA) LEDGER_STATUS FROM ACC_LEDGER_Z_D_A WHERE ZONE in(" + strZone + ")  AND LEDGER_STATUS =0 ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    return Convert.ToInt64(dr["LEDGER_STATUS"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        public List<Zone> GetDisvison(string strZone)
        {
            string strSQL = null;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            List<Zone> objList = new List<Zone>();
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                strSQL = "SELECT ACC_LEDGER_Z_D_A.DIVISION ,ACC_LEDGER_Z_D_A.GR_MOBILE_NO, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.SAL_TARGET),0)SAL_TARGET ,";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.SAL_ACHIEVE),0) SAL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.COLL_TARGET),0)COLL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.COLL_ACHIEVE),0) COLL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_SAL_TARGET_TOTAL),0)M_SAL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_SAL_ACHIEVE_TOTAL),0)M_SAL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_COLL_TARGET_TOTAL),0)M_COLL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_COLL_ACHIEVE_TOTAL),0)M_COLL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_TARGET),0)Y_SAL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_ACHIEVE),0)Y_SAL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_TARGET),0)Y_COLL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_ACHIEVE),0)Y_COLL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_TARGET_TOTAL),0)Y_SAL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_ACHIEVE_TOTAL),0)Y_SAL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_TARGET_TOTAL),0)Y_COLL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_ACHIEVE_TOTAL),0)Y_COLL_ACHIEVE_TOTAL ";
                strSQL = strSQL + "FROM ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY,ACC_LEDGER_Z_D_A WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE =ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strZone.Replace("'","''") + "' ";
                strSQL = strSQL + "GROUP by ACC_LEDGER_Z_D_A.DIVISION,ACC_LEDGER_Z_D_A.GR_MOBILE_NO ";


                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Zone oozone = new Zone();
                    oozone.strDivision = dr["DIVISION"].ToString();
                    oozone.dblSalesTarget = Convert.ToDouble(dr["SAL_TARGET"].ToString());
                    oozone.dblSaleAchv = Convert.ToDouble(dr["SAL_ACHIEVE"].ToString());
                    oozone.dblCollTarget = Convert.ToDouble(dr["COLL_TARGET"].ToString());
                    oozone.dblCollAch = Convert.ToDouble(dr["COLL_ACHIEVE"].ToString());

                    oozone.dblSalesTargetMonthlyTotal = Convert.ToDouble(dr["M_SAL_TARGET_TOTAL"].ToString());
                    oozone.dblSaleAchvMonthlyTotal = Convert.ToDouble(dr["M_SAL_ACHIEVE_TOTAL"].ToString());
                    oozone.dblCollTargetMonthlyTotal = Convert.ToDouble(dr["M_COLL_TARGET_TOTAL"].ToString());
                    oozone.dblCollAchMonthlyTotal = Convert.ToDouble(dr["M_COLL_ACHIEVE_TOTAL"].ToString());

                    oozone.dblSalesTargetYearly = Convert.ToDouble(dr["Y_SAL_TARGET"].ToString());
                    oozone.dblSaleAchvYearly = Convert.ToDouble(dr["Y_SAL_ACHIEVE"].ToString());
                    oozone.dblCollTargetYearly = Convert.ToDouble(dr["Y_COLL_TARGET"].ToString());
                    oozone.dblCollAchYearly = Convert.ToDouble(dr["Y_COLL_ACHIEVE"].ToString());

                    oozone.dblSalesTargetYearlyTotal = Convert.ToDouble(dr["Y_SAL_TARGET_TOTAL"].ToString());
                    oozone.dblSaleAchvYearlyTotal = Convert.ToDouble(dr["Y_SAL_ACHIEVE_TOTAL"].ToString());
                    oozone.dblCollTargetYearlyTotal = Convert.ToDouble(dr["Y_COLL_TARGET_TOTAL"].ToString());
                    oozone.dblCollAchYearlyTotal = Convert.ToDouble(dr["Y_COLL_ACHIEVE_TOTAL"].ToString());
                    if (dr["GR_MOBILE_NO"].ToString() != "")
                    {
                        oozone.strMobile = dr["GR_MOBILE_NO"].ToString();
                    }
                    else
                    {
                        oozone.strMobile = "";
                    }
                   

                    objList.Add(oozone);
                }
                return objList;
            }

        }
        public string GetMobileNo(string strZone)
        {
            string strSQL = null;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            List<Zone> objList = new List<Zone>();
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                strSQL = "SELECT GR_MOBILE_NO  from ACC_LEDGERGROUP WHERE GR_NAME ='" + strZone + "' ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                if  (dr.Read())
                {
                    return dr["GR_MOBILE_NO"].ToString();
                }
                else
                {
                    return "";
                }
                
            }

        }
        public double dblClosingdues(string strZone)
        {
            string strSQL = null;
            double dblclosing = 0;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            List<Zone> objList = new List<Zone>();
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                strSQL = "SELECT ACC_LEDGER_Z_D_A.DIVISION,ACC_LEDGER_Z_D_A.ZONE   FROM ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY,ACC_LEDGER_Z_D_A ";
                strSQL = strSQL + "WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE =ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.LEDGER_NAME ";
                strSQL = strSQL + "AND ZONE ='" + strZone + "' GROUP by ZONE ,ACC_LEDGER_Z_D_A.DIVISION,ACC_LEDGER_Z_D_A.ZONE ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dblclosing = dblclosing + Math.Round(dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom, DateTime.Now.ToString("dd-MM-yyyy"), "", dr["DIVISION"].ToString(), "", ""), 0);
                }
                return dblclosing;
            }

        }
        public List<Zone> GetZoneTarget()
        {
            string strSQL = null;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            List<Zone> objList = new List<Zone>();
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                strSQL = "SELECT ACC_LEDGER_Z_D_A.ZONE ,'' GR_MOBILE_NO, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.SAL_TARGET),0)SAL_TARGET ,";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.SAL_ACHIEVE),0) SAL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.COLL_TARGET),0)COLL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.COLL_ACHIEVE),0) COLL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_SAL_TARGET_TOTAL),0)M_SAL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_SAL_ACHIEVE_TOTAL),0)M_SAL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_COLL_TARGET_TOTAL),0)M_COLL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_COLL_ACHIEVE_TOTAL),0)M_COLL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_TARGET),0)Y_SAL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_ACHIEVE),0)Y_SAL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_TARGET),0)Y_COLL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_ACHIEVE),0)Y_COLL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_TARGET_TOTAL),0)Y_SAL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_ACHIEVE_TOTAL),0)Y_SAL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_TARGET_TOTAL),0)Y_COLL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_ACHIEVE_TOTAL),0)Y_COLL_ACHIEVE_TOTAL ";
                strSQL = strSQL + "FROM ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY,ACC_LEDGER_Z_D_A WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE =ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.LEDGER_NAME ";
                //strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE in '" + strZone.Replace("'", "''") + "' ";
                strSQL = strSQL + "GROUP by ZONE ";


                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Zone oozone = new Zone();
                    oozone.strDivision = dr["ZONE"].ToString();
                    oozone.dblSalesTarget = Convert.ToDouble(dr["SAL_TARGET"].ToString());
                    oozone.dblSaleAchv = Convert.ToDouble(dr["SAL_ACHIEVE"].ToString());
                    oozone.dblCollTarget = Convert.ToDouble(dr["COLL_TARGET"].ToString());
                    oozone.dblCollAch = Convert.ToDouble(dr["COLL_ACHIEVE"].ToString());

                    oozone.dblSalesTargetMonthlyTotal = Convert.ToDouble(dr["M_SAL_TARGET_TOTAL"].ToString());
                    oozone.dblSaleAchvMonthlyTotal = Convert.ToDouble(dr["M_SAL_ACHIEVE_TOTAL"].ToString());
                    oozone.dblCollTargetMonthlyTotal = Convert.ToDouble(dr["M_COLL_TARGET_TOTAL"].ToString());
                    oozone.dblCollAchMonthlyTotal = Convert.ToDouble(dr["M_COLL_ACHIEVE_TOTAL"].ToString());

                    oozone.dblSalesTargetYearly = Convert.ToDouble(dr["Y_SAL_TARGET"].ToString());
                    oozone.dblSaleAchvYearly = Convert.ToDouble(dr["Y_SAL_ACHIEVE"].ToString());
                    oozone.dblCollTargetYearly = Convert.ToDouble(dr["Y_COLL_TARGET"].ToString());
                    oozone.dblCollAchYearly = Convert.ToDouble(dr["Y_COLL_ACHIEVE"].ToString());

                    oozone.dblSalesTargetYearlyTotal = Convert.ToDouble(dr["Y_SAL_TARGET_TOTAL"].ToString());
                    oozone.dblSaleAchvYearlyTotal = Convert.ToDouble(dr["Y_SAL_ACHIEVE_TOTAL"].ToString());
                    oozone.dblCollTargetYearlyTotal = Convert.ToDouble(dr["Y_COLL_TARGET_TOTAL"].ToString());
                    oozone.dblCollAchYearlyTotal = Convert.ToDouble(dr["Y_COLL_ACHIEVE_TOTAL"].ToString());
                    if (dr["GR_MOBILE_NO"].ToString() != "")
                    {
                        oozone.strMobile = dr["GR_MOBILE_NO"].ToString();
                    }
                    else
                    {
                        oozone.strMobile = "";
                    }


                    objList.Add(oozone);
                }
                return objList;
            }

        }
        public List<Zone> GetZoneTotal(string strZone)
        {
            string strSQL = null;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            List<Zone> objList = new List<Zone>();
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                
                strSQL = "SELECT ACC_LEDGER_Z_D_A.ZONE,";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.SAL_TARGET),0)SAL_TARGET ,";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.SAL_ACHIEVE),0) SAL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.COLL_TARGET),0)COLL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.COLL_ACHIEVE),0) COLL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_SAL_TARGET_TOTAL),0)M_SAL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_SAL_ACHIEVE_TOTAL),0)M_SAL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_COLL_TARGET_TOTAL),0)M_COLL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_COLL_ACHIEVE_TOTAL),0)M_COLL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_TARGET),0)Y_SAL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_ACHIEVE),0)Y_SAL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_TARGET),0)Y_COLL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_ACHIEVE),0)Y_COLL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_TARGET_TOTAL),0)Y_SAL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_ACHIEVE_TOTAL),0)Y_SAL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_TARGET_TOTAL),0)Y_COLL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_ACHIEVE_TOTAL),0)Y_COLL_ACHIEVE_TOTAL ";
                strSQL = strSQL + "FROM ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY,ACC_LEDGER_Z_D_A WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE =ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE='" + strZone.Replace("'", "''") + "' ";
                strSQL = strSQL + "GROUP by ACC_LEDGER_Z_D_A.ZONE ";


                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Zone oozone = new Zone();
                    oozone.strDivision = dr["ZONE"].ToString();
                    oozone.dblSalesTarget = Convert.ToDouble(dr["SAL_TARGET"].ToString());
                    oozone.dblSaleAchv = Convert.ToDouble(dr["SAL_ACHIEVE"].ToString());
                    oozone.dblCollTarget = Convert.ToDouble(dr["COLL_TARGET"].ToString());
                    oozone.dblCollAch = Convert.ToDouble(dr["COLL_ACHIEVE"].ToString());

                    oozone.dblSalesTargetMonthlyTotal = Convert.ToDouble(dr["M_SAL_TARGET_TOTAL"].ToString());
                    oozone.dblSaleAchvMonthlyTotal = Convert.ToDouble(dr["M_SAL_ACHIEVE_TOTAL"].ToString());
                    oozone.dblCollTargetMonthlyTotal = Convert.ToDouble(dr["M_COLL_TARGET_TOTAL"].ToString());
                    oozone.dblCollAchMonthlyTotal = Convert.ToDouble(dr["M_COLL_ACHIEVE_TOTAL"].ToString());

                    oozone.dblSalesTargetYearly = Convert.ToDouble(dr["Y_SAL_TARGET"].ToString());
                    oozone.dblSaleAchvYearly = Convert.ToDouble(dr["Y_SAL_ACHIEVE"].ToString());
                    oozone.dblCollTargetYearly = Convert.ToDouble(dr["Y_COLL_TARGET"].ToString());
                    oozone.dblCollAchYearly = Convert.ToDouble(dr["Y_COLL_ACHIEVE"].ToString());

                    oozone.dblSalesTargetYearlyTotal = Convert.ToDouble(dr["Y_SAL_TARGET_TOTAL"].ToString());
                    oozone.dblSaleAchvYearlyTotal = Convert.ToDouble(dr["Y_SAL_ACHIEVE_TOTAL"].ToString());
                    oozone.dblCollTargetYearlyTotal = Convert.ToDouble(dr["Y_COLL_TARGET_TOTAL"].ToString());
                    oozone.dblCollAchYearlyTotal = Convert.ToDouble(dr["Y_COLL_ACHIEVE_TOTAL"].ToString());

                    objList.Add(oozone);
                }
                return objList;
            }
        }
        public List<Zone> GetZoneTotal1(string strZone)
        {
            string strSQL = null;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            List<Zone> objList = new List<Zone>();
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;

                strSQL = "SELECT ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.SAL_TARGET),0)SAL_TARGET ,";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.SAL_ACHIEVE),0) SAL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.COLL_TARGET),0)COLL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.COLL_ACHIEVE),0) COLL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_SAL_TARGET_TOTAL),0)M_SAL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_SAL_ACHIEVE_TOTAL),0)M_SAL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_COLL_TARGET_TOTAL),0)M_COLL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_COLL_ACHIEVE_TOTAL),0)M_COLL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_TARGET),0)Y_SAL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_ACHIEVE),0)Y_SAL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_TARGET),0)Y_COLL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_ACHIEVE),0)Y_COLL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_TARGET_TOTAL),0)Y_SAL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_ACHIEVE_TOTAL),0)Y_SAL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_TARGET_TOTAL),0)Y_COLL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_ACHIEVE_TOTAL),0)Y_COLL_ACHIEVE_TOTAL ";
                strSQL = strSQL + "FROM ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY,ACC_LEDGER_Z_D_A WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE =ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.ZONE in (" + strZone + ")";
               // strSQL = strSQL + "GROUP by ACC_LEDGER_Z_D_A.ZONE ";


                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Zone oozone = new Zone();
                    //oozone.strDivision = dr["ZONE"].ToString();
                    oozone.dblSalesTarget = Convert.ToDouble(dr["SAL_TARGET"].ToString());
                    oozone.dblSaleAchv = Convert.ToDouble(dr["SAL_ACHIEVE"].ToString());
                    oozone.dblCollTarget = Convert.ToDouble(dr["COLL_TARGET"].ToString());
                    oozone.dblCollAch = Convert.ToDouble(dr["COLL_ACHIEVE"].ToString());

                    oozone.dblSalesTargetMonthlyTotal = Convert.ToDouble(dr["M_SAL_TARGET_TOTAL"].ToString());
                    oozone.dblSaleAchvMonthlyTotal = Convert.ToDouble(dr["M_SAL_ACHIEVE_TOTAL"].ToString());
                    oozone.dblCollTargetMonthlyTotal = Convert.ToDouble(dr["M_COLL_TARGET_TOTAL"].ToString());
                    oozone.dblCollAchMonthlyTotal = Convert.ToDouble(dr["M_COLL_ACHIEVE_TOTAL"].ToString());

                    oozone.dblSalesTargetYearly = Convert.ToDouble(dr["Y_SAL_TARGET"].ToString());
                    oozone.dblSaleAchvYearly = Convert.ToDouble(dr["Y_SAL_ACHIEVE"].ToString());
                    oozone.dblCollTargetYearly = Convert.ToDouble(dr["Y_COLL_TARGET"].ToString());
                    oozone.dblCollAchYearly = Convert.ToDouble(dr["Y_COLL_ACHIEVE"].ToString());

                    oozone.dblSalesTargetYearlyTotal = Convert.ToDouble(dr["Y_SAL_TARGET_TOTAL"].ToString());
                    oozone.dblSaleAchvYearlyTotal = Convert.ToDouble(dr["Y_SAL_ACHIEVE_TOTAL"].ToString());
                    oozone.dblCollTargetYearlyTotal = Convert.ToDouble(dr["Y_COLL_TARGET_TOTAL"].ToString());
                    oozone.dblCollAchYearlyTotal = Convert.ToDouble(dr["Y_COLL_ACHIEVE_TOTAL"].ToString());

                    objList.Add(oozone);
                }
                return objList;
            }
        }
        public List<Zone> GetArea(string strDivison)
        {
           
            string strSQL = null;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            List<Zone> objList = new List<Zone>();
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                //strSQL = "SELECT DISTINCT DIVISION  FROM ACC_LEDGER_Z_D_A WHERE ZONE ='" + strZone + "' ";

                strSQL = "SELECT ACC_LEDGER_Z_D_A.AREA ,ACC_LEDGER_Z_D_A.DIVISION,ACC_LEDGERGROUP.GR_MOBILE_NO, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.SAL_TARGET),0)SAL_TARGET ,";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.SAL_ACHIEVE),0) SAL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.COLL_TARGET),0)COLL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.COLL_ACHIEVE),0) COLL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_SAL_TARGET_TOTAL),0)M_SAL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_SAL_ACHIEVE_TOTAL),0)M_SAL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_COLL_TARGET_TOTAL),0)M_COLL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.M_COLL_ACHIEVE_TOTAL),0)M_COLL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_TARGET),0)Y_SAL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_ACHIEVE),0)Y_SAL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_TARGET),0)Y_COLL_TARGET, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_ACHIEVE),0)Y_COLL_ACHIEVE, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_TARGET_TOTAL),0)Y_SAL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_SAL_ACHIEVE_TOTAL),0)Y_SAL_ACHIEVE_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_TARGET_TOTAL),0)Y_COLL_TARGET_TOTAL, ";
                strSQL = strSQL + "ISNULL(sum(ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.Y_COLL_ACHIEVE_TOTAL),0)Y_COLL_ACHIEVE_TOTAL ";
                strSQL = strSQL + "FROM ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY,ACC_LEDGER_Z_D_A,ACC_LEDGERGROUP WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME_MERZE =ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY.LEDGER_NAME ";
                strSQL = strSQL + " AND ACC_LEDGERGROUP.GR_NAME =ACC_LEDGER_Z_D_A.AREA ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.DIVISION='" + strDivison.Replace("'", "''") + "' ";
                strSQL = strSQL + "GROUP by ACC_LEDGER_Z_D_A.AREA,ACC_LEDGER_Z_D_A.DIVISION,ACC_LEDGERGROUP.GR_MOBILE_NO ";


                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Zone oozone = new Zone();
                    oozone.strDivision = dr["DIVISION"].ToString();
                    oozone.strArea = dr["AREA"].ToString();
                    oozone.dblSalesTarget = Convert.ToDouble(dr["SAL_TARGET"].ToString());
                    oozone.dblSaleAchv = Convert.ToDouble(dr["SAL_ACHIEVE"].ToString());
                    oozone.dblCollTarget = Convert.ToDouble(dr["COLL_TARGET"].ToString());
                    oozone.dblCollAch = Convert.ToDouble(dr["COLL_ACHIEVE"].ToString());

                    oozone.dblSalesTargetMonthlyTotal = Convert.ToDouble(dr["M_SAL_TARGET_TOTAL"].ToString());
                    oozone.dblSaleAchvMonthlyTotal = Convert.ToDouble(dr["M_SAL_ACHIEVE_TOTAL"].ToString());
                    oozone.dblCollTargetMonthlyTotal = Convert.ToDouble(dr["M_COLL_TARGET_TOTAL"].ToString());
                    oozone.dblCollAchMonthlyTotal = Convert.ToDouble(dr["M_COLL_ACHIEVE_TOTAL"].ToString());

                    oozone.dblSalesTargetYearly = Convert.ToDouble(dr["Y_SAL_TARGET"].ToString());
                    oozone.dblSaleAchvYearly = Convert.ToDouble(dr["Y_SAL_ACHIEVE"].ToString());
                    oozone.dblCollTargetYearly = Convert.ToDouble(dr["Y_COLL_TARGET"].ToString());
                    oozone.dblCollAchYearly = Convert.ToDouble(dr["Y_COLL_ACHIEVE"].ToString());

                    oozone.dblSalesTargetYearlyTotal = Convert.ToDouble(dr["Y_SAL_TARGET_TOTAL"].ToString());
                    oozone.dblSaleAchvYearlyTotal = Convert.ToDouble(dr["Y_SAL_ACHIEVE_TOTAL"].ToString());
                    oozone.dblCollTargetYearlyTotal = Convert.ToDouble(dr["Y_COLL_TARGET_TOTAL"].ToString());
                    oozone.dblCollAchYearlyTotal = Convert.ToDouble(dr["Y_COLL_ACHIEVE_TOTAL"].ToString());
                    if (dr["GR_MOBILE_NO"].ToString() != "")
                    {
                        oozone.strMobile = dr["GR_MOBILE_NO"].ToString();
                    }
                    else
                    {
                        oozone.strMobile = "";
                    }

                    objList.Add(oozone);
                }
                return objList;
            }
        }
        #endregion
        #region "Load"
        private void mload()
        {
           

            strCurrentFdate = Utility.FirstDayOfMonth(DateTime.Now).ToString("dd-MM-yyyy");
            strCurrentTdate = Utility.LastDayOfMonth(DateTime.Now).ToString("dd-MM-yyyy");
            strCurrentDate = DateTime.Now.ToString("dd-MM-yyyy");

            strFormatDate = Utility.FirstDayOfMonth(DateTime.Now).ToString("dd-MM-yy");
            strFormatToDate = Utility.LastDayOfMonth(DateTime.Now).ToString("dd-MM-yy");
            strFormatLastDate = Utility.LastDayOfMonth(DateTime.Now).ToString("dd-MM-yy");

            strYearFormDate = Convert.ToDateTime("01-01-" + DateTime.Now.Year).ToString("dd-MM-yy");
            //strYearToDate = Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString("dd-MM-yy");
            
            DG.Rows.Clear();
            Rectangle workingArea = Screen.GetWorkingArea(this);
            if (workingArea.Width == 1920)
            {
                DG.DefaultCellStyle.Font = new Font("Verdana", 11,FontStyle.Bold);
                DG.Width = 2000;
             
                DG.Columns.Add(Utility.Create_Grid_Column("Field Force", "Field Force", 400, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Mobile No", "Mobile No", 50, true, DataGridViewContentAlignment.MiddleRight, true));
                //***********Ist
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 5, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 150, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 150, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 150, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 150, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                //***********
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 5, true, DataGridViewContentAlignment.MiddleRight, true));
                //*********2nd
                DG.Columns.Add(Utility.Create_Grid_Column("Monthly Total", "Monthly Total", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                //***********
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 5, true, DataGridViewContentAlignment.MiddleRight, true));
                //*********3rd
                DG.Columns.Add(Utility.Create_Grid_Column("Yearly up to Date", "Yearly up to Date", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                //*************
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 5, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Present Dues", "Present Dues", 150, true, DataGridViewContentAlignment.MiddleRight, true));

                //DG.Rows.Add(1);
                //********ist
                DG[3, 0].Style.BackColor = Color.Bisque;
                DG[4, 0].Style.BackColor = Color.Bisque;
                DG[5, 0].Style.BackColor = Color.Bisque;
                DG[6, 0].Style.BackColor = Color.Bisque;
                DG[7, 0].Style.BackColor = Color.Bisque;
                DG[8, 0].Style.BackColor = Color.Bisque;
                DG[3, 0].Value = "Sales Target";
                DG[4, 0].Value = "Sales Ach.";
                DG[5, 0].Value = "Ach.(%)";
                DG[6, 0].Value = "Coll. Target";
                DG[7, 0].Value = "Coll. Ach.";
                DG[8, 0].Value = "Ach.(%)";

                //*******2nd
                DG[10, 0].Style.BackColor = Color.Beige;
                DG[11, 0].Style.BackColor = Color.Beige;
                DG[10, 0].Value = "Sales Ach.(%)";
                DG[11, 0].Value = "Coll. Ach.(%)";
                //*********3rd
                DG[13, 0].Style.BackColor = Color.LightPink;
                DG[14, 0].Style.BackColor = Color.LightPink;
                DG[13, 0].Value = "Sales Ach.(%)";
                DG[14, 0].Value = "Coll. Ach.(%)";
                //************


                this.DG.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
                this.DG.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            }
            else if (workingArea.Width == 1360)
            {
                DG.DefaultCellStyle.Font = new Font("Verdana", 9.5f);
                DG.Width = 1900;
                DG.Columns.Add(Utility.Create_Grid_Column("Field Force", "Field Force", 280, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Mobile No", "Mobile No", 50, true, DataGridViewContentAlignment.MiddleRight, true));
                //***********Ist
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 5, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 70, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 70, true, DataGridViewContentAlignment.MiddleRight, true));
                //***********
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 5, true, DataGridViewContentAlignment.MiddleRight, true));
                //*********2nd
                DG.Columns.Add(Utility.Create_Grid_Column("Monthly Total", "Monthly Total", 80, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 80, true, DataGridViewContentAlignment.MiddleRight, true));
                //***********
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 5, true, DataGridViewContentAlignment.MiddleRight, true));
                //*********3rd
                DG.Columns.Add(Utility.Create_Grid_Column("Yearly up to Date", "Yearly up to Date", 80, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 80, true, DataGridViewContentAlignment.MiddleRight, true));
                //*************
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 5, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Present Dues", "Present Dues", 100, true, DataGridViewContentAlignment.MiddleRight, true));

                //DG.Rows.Add(1);
                //********ist
                DG[3, 0].Style.BackColor = Color.Bisque;
                DG[4, 0].Style.BackColor = Color.Bisque;
                DG[5, 0].Style.BackColor = Color.Bisque;
                DG[6, 0].Style.BackColor = Color.Bisque;
                DG[7, 0].Style.BackColor = Color.Bisque;
                DG[8, 0].Style.BackColor = Color.Bisque;
                DG[3, 0].Value = "Sales Target";
                DG[4, 0].Value = "Sales Ach.";
                DG[5, 0].Value = "Ach.(%)";
                DG[6, 0].Value = "Coll. Target";
                DG[7, 0].Value = "Coll. Ach.";
                DG[8, 0].Value = "Ach.(%)";

                //*******2nd
                DG[10, 0].Style.BackColor = Color.Beige;
                DG[11, 0].Style.BackColor = Color.Beige;
                DG[10, 0].Value = "Sales Ach.(%)";
                DG[11, 0].Value = "Coll. Ach.(%)";
                //*********3rd
                DG[13, 0].Style.BackColor = Color.LightPink;
                DG[14, 0].Style.BackColor = Color.LightPink;
                DG[13, 0].Value = "Sales Ach.(%)";
                DG[14, 0].Value = "Coll. Ach.(%)";
                //************


                this.DG.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
                this.DG.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            }
            else
            {
                DG.DefaultCellStyle.Font = new Font("Verdana", 9.5f);
                DG.Columns.Add(Utility.Create_Grid_Column("Field Force", "Field Force", 300, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Mobile No", "Mobile No", 50, true, DataGridViewContentAlignment.MiddleRight, true));
                //***********Ist
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 5, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 70, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 100, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 70, true, DataGridViewContentAlignment.MiddleRight, true));
                //***********
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 5, true, DataGridViewContentAlignment.MiddleRight, true));
                //*********2nd
                DG.Columns.Add(Utility.Create_Grid_Column("Monthly Total", "Monthly Total", 90, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 60, true, DataGridViewContentAlignment.MiddleRight, true));
                //***********
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 5, true, DataGridViewContentAlignment.MiddleRight, true));
                //*********3rd
                DG.Columns.Add(Utility.Create_Grid_Column("Yearly up to Date", "Yearly up to Date", 90, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 60, true, DataGridViewContentAlignment.MiddleRight, true));
                //*************
                DG.Columns.Add(Utility.Create_Grid_Column("", "", 5, true, DataGridViewContentAlignment.MiddleRight, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Present Dues", "Present Dues", 100, true, DataGridViewContentAlignment.MiddleRight, true));

                //DG.Rows.Add(1);
                //********ist
                DG[3, 0].Style.BackColor = Color.Bisque;
                DG[4, 0].Style.BackColor = Color.Bisque;
                DG[5, 0].Style.BackColor = Color.Bisque;
                DG[6, 0].Style.BackColor = Color.Bisque;
                DG[7, 0].Style.BackColor = Color.Bisque;
                DG[8, 0].Style.BackColor = Color.Bisque;
                DG[3, 0].Value = "Sales Target";
                DG[4, 0].Value = "Sales Ach.";
                DG[5, 0].Value = "Ach.(%)";
                DG[6, 0].Value = "Coll. Target";
                DG[7, 0].Value = "Coll. Ach.";
                DG[8, 0].Value = "Ach.(%)";

                //*******2nd
                DG[10, 0].Style.BackColor = Color.Beige;
                DG[11, 0].Style.BackColor = Color.Beige;
                DG[10, 0].Value = "Sales Ach.(%)";
                DG[11, 0].Value = "Coll. Ach.(%)";
                //*********3rd
                DG[13, 0].Style.BackColor = Color.LightPink;
                DG[14, 0].Style.BackColor = Color.LightPink;
                DG[13, 0].Value = "Sales Ach.(%)";
                DG[14, 0].Value = "Coll. Ach.(%)";
                //************


                this.DG.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
                this.DG.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //DG.ColumnHeadersHeight = DG.ColumnHeadersHeight * 4;
            }
           
          
        }
        private void MergeCellsInColumn(int col, int row1, int row2)
        {
            Graphics g = DG.CreateGraphics();
            Pen p = new Pen(DG.GridColor);
            Rectangle r1 = DG.GetCellDisplayRectangle(col, row1, true);
            Rectangle r2 = DG.GetCellDisplayRectangle(col, row2, true);

            int recHeight = 0;
            string recValue = string.Empty;
            for (int i = row1; i <= row2; i++)
            {
                recHeight += DG.GetCellDisplayRectangle(col, i, true).Height;
                if (DG[col, i].Value != null)
                    recValue += DG[col, i].Value.ToString() + " ";
            }
            Rectangle newCell = new Rectangle(r1.X, r1.Y, r1.Width, recHeight);
            g.FillRectangle(new SolidBrush(DG.DefaultCellStyle.BackColor), newCell);
            g.DrawRectangle(p, newCell);
            g.DrawString(recValue, DG.DefaultCellStyle.Font, new SolidBrush(DG.DefaultCellStyle.ForeColor), newCell.X + 3, newCell.Y + 3);
        }
        private void frmDashBoard_Load(object sender, EventArgs e)
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            Utility.gstrCompanyID = (String)regKey.GetValue("CompanyID", "0001");
            Utility.gSelectCompanyName(Utility.gstrCompanyID, "NO");
            //lblDatetime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
            comboBox1.ValueMember = "strZoneName";
            comboBox1.DisplayMember = "strZoneName";
            comboBox1.DataSource = GetZone().ToList();
            mload();


            StartTimer();

            timer1.Interval = 2000;//5 minutes
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();

         
        }
        #endregion
        #region "Timer"
        private void timer1_Tick(object sender, EventArgs e)
        {
          
            //string strName="'EAST ZONE (SOBUR REZA PRODHAN)','NORTH ZONE (SAJIB AHMED)','SOUTH ZONE (H.M SYFULLAH)','WEST ZONE (ABDULLAH AL MARUF)'";
            lblDatetime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
            if (i == 0)
            {
                comboBox1.SelectedValue = "EAST ZONE (SOBUR REZA PRODHAN)";
                string dd = GetrptCollectionTargetAchieve(strComID, "0001", strCurrentFdate, strCurrentTdate, strCurrentDate, 0, comboBox1.SelectedValue.ToString(), Convert.ToDateTime("01-01-" + DateTime.Now.Year).ToString("dd-MM-yyyy"), Convert.ToDateTime("31-12-" + DateTime.Now.Year).ToString("dd-MM-yyyy"));
                string uu = mGetFinalStattemnet(strComID, strCurrentFdate, strCurrentTdate, "0001", "EAST ZONE (SOBUR REZA PRODHAN)", "", 2);
                btnDisplay.PerformClick();
                //timer1.Stop();
            }

            else if (i == 1)
            {
                Thread.Sleep(20000);
            }
            else if (i == 2)
            {
                lblHeading.Text = "Zonal Sales && Collection Analysis";
                comboBox1.SelectedValue = "NORTH ZONE (SAJIB AHMED)";
                string dd = GetrptCollectionTargetAchieve(strComID, "0001", strCurrentFdate, strCurrentTdate, strCurrentDate, 0, comboBox1.SelectedValue.ToString(), Convert.ToDateTime("01-01-" + DateTime.Now.Year).ToString("dd-MM-yyyy"), Convert.ToDateTime("31-12-" + DateTime.Now.Year).ToString("dd-MM-yyyy"));
                string uu = mGetFinalStattemnet(strComID, strCurrentFdate, strCurrentTdate, "0001", "NORTH ZONE (SAJIB AHMED)", "", 2);
                btnDisplay.PerformClick();
                Thread.Sleep(20000);
            }
            else if (i == 3)
            {
                Thread.Sleep(20000);
            }
            
            else if (i == 4)
            {
                lblHeading.Text = "Zonal Sales && Collection Analysis";
                comboBox1.SelectedValue = "SOUTH ZONE (H.M SYFULLAH)";
                string dd = GetrptCollectionTargetAchieve(strComID, "0001", strCurrentFdate, strCurrentTdate, strCurrentDate, 0, comboBox1.SelectedValue.ToString(), Convert.ToDateTime("01-01-" + DateTime.Now.Year).ToString("dd-MM-yyyy"), Convert.ToDateTime("31-12-" + DateTime.Now.Year).ToString("dd-MM-yyyy"));
                string uu = mGetFinalStattemnet(strComID, strCurrentFdate, strCurrentTdate, "0001", "SOUTH ZONE (H.M SYFULLAH)", "", 2);
                btnDisplay.PerformClick();
                Thread.Sleep(20000);
            }
            
            else if (i == 5)
            {
                Thread.Sleep(20000);
               
            }
            else if (i == 6)
            {
                Thread.Sleep(20000);

            }
            else if (i == 7)
            {
                lblHeading.Text = "Zonal Sales & Collection Analysis";
                comboBox1.SelectedValue = "WEST ZONE (ABDULLAH AL MARUF)";
                string dd = GetrptCollectionTargetAchieve(strComID, "0001", strCurrentFdate, strCurrentTdate, strCurrentDate, 0, comboBox1.SelectedValue.ToString(), Convert.ToDateTime("01-01-" + DateTime.Now.Year).ToString("dd-MM-yyyy"), Convert.ToDateTime("31-12-" + DateTime.Now.Year).ToString("dd-MM-yyyy"));
                string uu = mGetFinalStattemnet(strComID, strCurrentFdate, strCurrentTdate, "0001", "WEST ZONE (ABDULLAH AL MARUF)", "", 2);
                btnDisplay.PerformClick();
                Thread.Sleep(20000);
            }
            else if (i == 8)
            {
                Thread.Sleep(20000);
            }
            else if (i == 9)
            {
                //lblHeading.Text = "National Sales & Collection Analysis";
                //comboBox1.Text = "National Sales";
                //string dd1 = GetrptCollectionZone(strComID, "0001", strCurrentFdate, strCurrentTdate, strCurrentDate, 0, strName, Convert.ToDateTime("01-01-" + DateTime.Now.Year).ToString("dd-MM-yyyy"),
                //                                Convert.ToDateTime("31-12-" + DateTime.Now.Year).ToString("dd-MM-yyyy"));
                //string uu = mGetFinalStattemnet(strComID, strCurrentFdate, strCurrentTdate, "0001", "ZONE", "", 2);
                string dd, uu;
                dd = GetrptCollectionTargetAchieveSummarry(strComID, "0001", strCurrentFdate, strCurrentTdate, strCurrentDate, 0, "EAST ZONE (SOBUR REZA PRODHAN)", 
                                                        Convert.ToDateTime("01-01-" + DateTime.Now.Year).ToString("dd-MM-yyyy"), Convert.ToDateTime("31-12-" + DateTime.Now.Year).ToString("dd-MM-yyyy"),0);
                uu = mGetFinalStattemnet(strComID, strCurrentFdate, strCurrentTdate, "0001", "EAST ZONE (SOBUR REZA PRODHAN)", "", 2);

                dd = GetrptCollectionTargetAchieveSummarry(strComID, "0001", strCurrentFdate, strCurrentTdate, strCurrentDate, 0, "WEST ZONE (ABDULLAH AL MARUF)", 
                                            Convert.ToDateTime("01-01-" + DateTime.Now.Year).ToString("dd-MM-yyyy"), Convert.ToDateTime("31-12-" + DateTime.Now.Year).ToString("dd-MM-yyyy"),1);
                uu = mGetFinalStattemnet(strComID, strCurrentFdate, strCurrentTdate, "0001", "WEST ZONE (ABDULLAH AL MARUF)", "", 2);

                dd = GetrptCollectionTargetAchieveSummarry(strComID, "0001", strCurrentFdate, strCurrentTdate, strCurrentDate, 0, "NORTH ZONE (SAJIB AHMED)", Convert.ToDateTime("01-01-" + DateTime.Now.Year).ToString("dd-MM-yyyy"), 
                                                Convert.ToDateTime("31-12-" + DateTime.Now.Year).ToString("dd-MM-yyyy"),1);
                uu = mGetFinalStattemnet(strComID, strCurrentFdate, strCurrentTdate, "0001", "NORTH ZONE (SAJIB AHMED)", "", 2);

                dd = GetrptCollectionTargetAchieveSummarry(strComID, "0001", strCurrentFdate, strCurrentTdate, strCurrentDate, 0, "SOUTH ZONE (H.M SYFULLAH)", Convert.ToDateTime("01-01-" + DateTime.Now.Year).ToString("dd-MM-yyyy"),
                                        Convert.ToDateTime("31-12-" + DateTime.Now.Year).ToString("dd-MM-yyyy"),1);
                uu = mGetFinalStattemnet(strComID, strCurrentFdate, strCurrentTdate, "0001", "SOUTH ZONE (H.M SYFULLAH)", "", 2);

                
                //btnDisplay2.PerformClick();
              

            }
            else if (i == 10)
            {
                lblHeading.Text = "National Sales & Collection Analysis";
                comboBox1.Text = "National Sales";
                btnDisplay2.PerformClick();
                Thread.Sleep(10000);
            }
            else if (i == 11)
            {

                Thread.Sleep(20000);
                i = -1;
            }
            i += 1;

        }
        #endregion
        #region "Display"
        private void DG_Paint(object sender, PaintEventArgs e)
        {
            //this code merge column header HeaderCol(2) and HeaderCol(3)
            //************Ist
            Rectangle r1 = DG.GetCellDisplayRectangle(3, -1, true);
            Rectangle r2 = DG.GetCellDisplayRectangle(5, -1, true);

            r1.X += 8;
            r1.Y += 2;
            r1.Width += r2.Width - 2;
            r1.Height -= 5;

            using (SolidBrush br = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(br, r1);
            }
            //draw text
            //using (SolidBrush br = new SolidBrush(this.DG.ColumnHeadersDefaultCellStyle.ForeColor))
            //{
            //    StringFormat sf = new StringFormat();
            //    e.Graphics.DrawString("            Monthly Up to Date", DG.ColumnHeadersDefaultCellStyle.Font, br, r1, sf);
            //}
            Rectangle r3 = DG.GetCellDisplayRectangle(4, -1, true);
            Rectangle r4 = DG.GetCellDisplayRectangle(8, -1, true);

            r3.X += 8;
            r3.Y += 2;
            r3.Width += r4.Width - 2;
            r3.Height -= 5;

            using (SolidBrush br = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(br, r3);
            }
            //draw text
            using (SolidBrush br = new SolidBrush(this.DG.ColumnHeadersDefaultCellStyle.ForeColor))
            {
                StringFormat sf = new StringFormat();
                e.Graphics.DrawString(" Monthly Up to Date", DG.ColumnHeadersDefaultCellStyle.Font, br, r3, sf);
            }
            Rectangle r5 = DG.GetCellDisplayRectangle(6, -1, true);
            Rectangle r6 = DG.GetCellDisplayRectangle(8, -1, true);

            r5.X += 8;
            r5.Y += 2;
            r5.Width += r6.Width - 2;
            r5.Height -= 5;

            using (SolidBrush br = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(br, r5);
            }
            using (SolidBrush br = new SolidBrush(this.DG.ColumnHeadersDefaultCellStyle.ForeColor))
            {
                StringFormat sf = new StringFormat();
                e.Graphics.DrawString("(" + strCurrentFdate + "  to ", DG.ColumnHeadersDefaultCellStyle.Font, br, r5, sf);
            }
            Rectangle r7 = DG.GetCellDisplayRectangle(7, -1, true);
            Rectangle r8 = DG.GetCellDisplayRectangle(8, -1, true);

            r7.X += 8;
            r7.Y += 2;
            r7.Width += r8.Width - 2;
            r7.Height -= 5;

            using (SolidBrush br = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(br, r7);
            }
            using (SolidBrush br = new SolidBrush(this.DG.ColumnHeadersDefaultCellStyle.ForeColor))
            {
                StringFormat sf = new StringFormat();
                e.Graphics.DrawString(" " + strCurrentDate + ")", DG.ColumnHeadersDefaultCellStyle.Font, br, r7, sf);
            }
          
            //***************

            Rectangle r9 = DG.GetCellDisplayRectangle(10, -1, true);
            Rectangle r10 = DG.GetCellDisplayRectangle(11, -1, true);

            r9.X += 8;
            r9.Y += 2;
            r9.Width += r10.Width - 2;
            r9.Height -= 5;

            using (SolidBrush br = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(br, r9);
            }
            using (SolidBrush br = new SolidBrush(this.DG.ColumnHeadersDefaultCellStyle.ForeColor))
            {
                StringFormat sf = new StringFormat();
                e.Graphics.DrawString("Monthly Total" + "(" + strCurrentFdate + "  to " + strCurrentTdate + ")", DG.ColumnHeadersDefaultCellStyle.Font, br, r9, sf);
               
            }

            //***************

            Rectangle r11 = DG.GetCellDisplayRectangle(13, -1, true);
            Rectangle r12 = DG.GetCellDisplayRectangle(14, -1, true);

            r11.X += 8;
            r11.Y += 2;
            r11.Width += r12.Width - 2;
            r11.Height -= 5;

            using (SolidBrush br = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(br, r11);
            }
            using (SolidBrush br = new SolidBrush(this.DG.ColumnHeadersDefaultCellStyle.ForeColor))
            {
                StringFormat sf = new StringFormat();
                e.Graphics.DrawString("Yearly up to Date" + "(" + strYearFormDate + "  to " + strCurrentDate + ")", DG.ColumnHeadersDefaultCellStyle.Font, br, r11, sf);
            }

          
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            int intTotalArea = 0;

            DG.AllowUserToAddRows = true;
            DG.Rows.Clear();

            DG.Rows.Add(1);
          
            //********ist
            DG[3, 0].Style.BackColor = Color.Bisque;
            DG[4, 0].Style.BackColor = Color.Bisque;
            DG[5, 0].Style.BackColor = Color.Bisque;
            DG[6, 0].Style.BackColor = Color.Bisque;
            DG[7, 0].Style.BackColor = Color.Bisque;
            DG[8, 0].Style.BackColor = Color.Bisque;
            DG[3, 0].Value = "Sales Target";
            DG[4, 0].Value = "Sales Ach.";
            DG[5, 0].Value = "Ach.(%)";
            DG[6, 0].Value = "Coll. Target";
            DG[7, 0].Value = "Coll. Ach.";
            DG[8, 0].Value = "Ach.(%)";

            //*******2nd
            DG[10, 0].Style.BackColor = Color.Beige;
            DG[11, 0].Style.BackColor = Color.Beige;
            DG[10, 0].Value = "Sales Ach.(%)";
            DG[11, 0].Value = "Coll. Ach.(%)";
            //*********3rd
            DG[13, 0].Style.BackColor = Color.LightPink;
            DG[14, 0].Style.BackColor = Color.LightPink;
            DG[13, 0].Value = "Sales Ach.(%)";
            DG[14, 0].Value = "Coll. Ach.(%)";
            //************
            int i = 1;

            double dblClosing = 0;         

            lblTotalMpo.Text = Convert.ToInt64(GetTotalMPO(comboBox1.SelectedValue.ToString())).ToString();
            List<Zone> objDivision = GetDisvison(comboBox1.SelectedValue.ToString()).ToList();
            lblTotalDivision.Text = objDivision.Count.ToString();
            foreach (Zone ooDivision in objDivision)
            {
                dblClosing = dblClosing + Math.Round(dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom, DateTime.Now.ToString("dd-MM-yyyy"), "", ooDivision.strDivision, "", ""), 0);
                mAdditemDivision(ooDivision.strDivision,ooDivision.strMobile, ooDivision.dblSalesTarget, ooDivision.dblSaleAchv, ooDivision.dblCollTarget, ooDivision.dblCollAch, ooDivision.dblSalesTargetMonthlyTotal,
                               ooDivision.dblSaleAchvMonthlyTotal, ooDivision.dblCollTargetMonthlyTotal, ooDivision.dblCollAchMonthlyTotal, ooDivision.dblSalesTargetYearly,
                               ooDivision.dblSaleAchvYearly, ooDivision.dblCollTargetYearly, ooDivision.dblCollAchYearly,
                               ooDivision.dblSalesTargetYearlyTotal,ooDivision.dblSaleAchvYearlyTotal,ooDivision.dblCollTargetYearlyTotal,ooDivision.dblCollAchYearlyTotal);

                List<Zone> objArea = GetArea(ooDivision.strDivision).ToList();
                {
                    intTotalArea = intTotalArea + objArea.Count;
                    foreach (Zone ooArea in objArea)
                    {
                        if (ooDivision.strDivision.ToUpper() == ooArea.strDivision.ToUpper())
                        {
                            mAdditemArea(ooArea.strArea, ooArea.strMobile, ooArea.dblSalesTarget, ooArea.dblSaleAchv, ooArea.dblCollTarget, ooArea.dblCollAch, ooArea.dblSalesTargetMonthlyTotal,
                               ooArea.dblSaleAchvMonthlyTotal, ooArea.dblCollTargetMonthlyTotal, ooArea.dblCollAchMonthlyTotal, ooArea.dblSalesTargetYearly,
                               ooArea.dblSaleAchvYearly, ooArea.dblCollTargetYearly, ooArea.dblCollAchYearly,
                               ooArea.dblSalesTargetYearlyTotal, ooArea.dblSaleAchvYearlyTotal, ooArea.dblCollTargetYearlyTotal, ooArea.dblCollAchYearlyTotal);
                        }

                    }
                   

                }
                i += 1;
              
                
            }
            label5.Text = intTotalArea.ToString();
            List<Zone> objZone = GetZoneTotal(comboBox1.SelectedValue.ToString()).ToList();
           if (objZone.Count>0)
           {
               CalculateZone(objZone[0].strDivision, objZone[0].dblSalesTarget, objZone[0].dblSaleAchv, objZone[0].dblCollTarget, objZone[0].dblCollAch, objZone[0].dblSalesTargetMonthlyTotal,
                               objZone[0].dblSaleAchvMonthlyTotal, objZone[0].dblCollTargetMonthlyTotal, objZone[0].dblCollAchMonthlyTotal, objZone[0].dblSalesTargetYearly,
                               objZone[0].dblSaleAchvYearly, objZone[0].dblCollTargetYearly, objZone[0].dblCollAchYearly,
                               objZone[0].dblSalesTargetYearlyTotal, objZone[0].dblSaleAchvYearlyTotal, objZone[0].dblCollTargetYearlyTotal, objZone[0].dblCollAchYearlyTotal,dblClosing);
           }
            DG.AllowUserToAddRows = false;
        }
        #endregion
        #region "GetArea"
        private void mGetArea(string strDivision)
        {
            int i = 1;
            List<Zone> objArea = GetArea(strDivision).ToList();
            DG.Rows.Add(Convert.ToInt16(objArea.Count));
            foreach (Zone ooArea in objArea)
            {
                DG[0, i].Value = ooArea.strArea;
                i += 1;
            }
            DG.AllowUserToAddRows = false;
        }
        #endregion
        #region "AddItem"
        private void mAdditemDivision(string strItemName,string strMobile,double dblSalsTarget,double dblSalesAch,double dblCollTarget,double dblCollAche
                                , double dblMonthlySalesTarget, double dblMonthlySalesAche, double dblMonthlyCollTarget, double dblMonthlyCollAche
                                , double dblYearlySalesTarget, double dblYearlySalesAche, double dblYearlyCollTarget, double dblYearlyCollAche
                                , double dblYearlyTotalSalesTarget, double dblYearlyTotalSalesAche, double dblYearlyTotalCollTarget, double dblYearlyTotalCollAche)
            
        {
            int selRaw;
            double dblClosing = 0;
            DG.AllowUserToAddRows = true;
            selRaw = Convert.ToInt16(DG.RowCount.ToString());
            selRaw = selRaw - 1;
            DG.Rows.Add();
            DG[0, selRaw].Value = strItemName;
            DG[1, selRaw].Value = Utility.Right(strMobile, 3);
            DG[1, selRaw].Style.BackColor = Color.Ivory;
                DG[0, selRaw].Style.BackColor = Color.Aqua;
                for (int intcol = 2; intcol <= DG.Columns.Count - 2; intcol++)
                {
                    DG[intcol, selRaw].Style.BackColor = Color.Aqua;

                    DG[2, selRaw].Style.BackColor = Color.BlueViolet;
                    DG[3, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblSalsTarget, 0));
                    DG[4, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblSalesAch, 0));
                    DG[5, selRaw].Value = Math.Round((Math.Round(dblSalesAch, 0)/Math.Round(dblSalsTarget, 0))*100,2);
                    DG[6, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblCollTarget, 0)); 
                    DG[7, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblCollAche, 0));
                    DG[8, selRaw].Value = Math.Round((Math.Round(dblCollAche, 0) / Math.Round(dblCollTarget, 0)) * 100,2);

                    DG[9, selRaw].Style.BackColor = Color.BlueViolet;
                    DG[10, selRaw].Value = Math.Round((Math.Round(dblMonthlySalesAche, 0) / Math.Round(dblMonthlySalesTarget, 0)) * 100,2);
                    DG[11, selRaw].Value = Math.Round((Math.Round(dblMonthlyCollAche, 0) / Math.Round(dblMonthlyCollTarget, 0)) * 100,2) ;

                    //DG[10, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlySalesTarget, 0));
                    //DG[11, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlySalesAche, 0));
                    //DG[9, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlyCollTarget, 0));
                    //DG[10, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlyCollAche, 0));

                    DG[12, selRaw].Style.BackColor = Color.BlueViolet;
                    DG[13, selRaw].Value = Math.Round((Math.Round(dblYearlySalesAche, 0) / Math.Round(dblYearlySalesTarget, 0)) * 100,2);
                    DG[14, selRaw].Value =Math.Round((Math.Round(dblYearlyCollAche, 0) / Math.Round(dblYearlyCollTarget, 0)) * 100,2);

                    DG[15, selRaw].Style.BackColor = Color.BlueViolet;

                    //DG[12, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlySalesTarget, 0));
                    //DG[13, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlySalesAche, 0));
                    //DG[14, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyCollTarget, 0));
                    //DG[15, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyCollAche, 0));
                    //DG[16, selRaw].Style.BackColor = Color.BlueViolet;
                    //DG[17, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalSalesTarget, 0));
                    //DG[18, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalSalesAche, 0)); ;
                    //DG[19, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalCollTarget, 0));
                    //DG[20, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalCollAche, 0));
                   
                }
                dblClosing = Math.Round(dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom, DateTime.Now.ToString("dd-MM-yyyy"), "0001", strItemName, "", ""), 0);
                //if (dblClosing < 0)
                //{
                //    DG[16, selRaw].Value = Math.Abs(dblClosing) + " Dr";
                //    DG[16, selRaw].Style.BackColor = Color.Aqua;
                //    DG[16, selRaw].Value = String.Format("{0:#,##0}", Math.Abs(dblClosing)) + " Dr";

                //}
                //else
                //{
                //    DG[16, selRaw].Value = Math.Abs(dblClosing) + " Cr";
                //    DG[16, selRaw].Style.BackColor = Color.Aqua;
                //    DG[16, selRaw].Value = String.Format("{0:#,##0}", Math.Abs(dblClosing)) + " Cr";
                //}
                DG[16, selRaw].Value = Math.Abs(dblClosing) ;
                DG[16, selRaw].Style.BackColor = Color.Aqua;
                DG[16, selRaw].Value = String.Format("{0:#,##0}", Math.Abs(dblClosing)) ;

        }

        private void mAdditemZone(string strItemName, string strMobile, double dblSalsTarget, double dblSalesAch, double dblCollTarget, double dblCollAche
                                , double dblMonthlySalesTarget, double dblMonthlySalesAche, double dblMonthlyCollTarget, double dblMonthlyCollAche
                                , double dblYearlySalesTarget, double dblYearlySalesAche, double dblYearlyCollTarget, double dblYearlyCollAche
                                , double dblYearlyTotalSalesTarget, double dblYearlyTotalSalesAche, double dblYearlyTotalCollTarget, double dblYearlyTotalCollAche,double dblclosing)
        {
            int selRaw;
            //double dblClosing = 0;
            DG.AllowUserToAddRows = true;
            selRaw = Convert.ToInt16(DG.RowCount.ToString());
            selRaw = selRaw - 1;
            DG.Rows.Add();
            DG[0, selRaw].Value = strItemName;
            strMobile = GetMobileNo(strItemName);
            if (strMobile != "")
            {
                DG[1, selRaw].Value = Utility.Right(strMobile, 3);
            }
            else
            {
                DG[1, selRaw].Value = "";
            }
            DG[1, selRaw].Style.BackColor = Color.Ivory;
            DG[0, selRaw].Style.BackColor = Color.Ivory;
            for (int intcol = 2; intcol <= DG.Columns.Count - 2; intcol++)
            {
                //DG[intcol, selRaw].Style.BackColor = Color.Aqua;

                DG[2, selRaw].Style.BackColor = Color.BlueViolet;
                DG[3, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblSalsTarget, 0));
                DG[4, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblSalesAch, 0));
                DG[5, selRaw].Value = Math.Round((Math.Round(dblSalesAch, 0) / Math.Round(dblSalsTarget, 0)) * 100, 2);
                DG[6, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblCollTarget, 0));
                DG[7, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblCollAche, 0));
                DG[8, selRaw].Value = Math.Round((Math.Round(dblCollAche, 0) / Math.Round(dblCollTarget, 0)) * 100, 2);

                DG[9, selRaw].Style.BackColor = Color.BlueViolet;
                DG[10, selRaw].Value = Math.Round((Math.Round(dblMonthlySalesAche, 0) / Math.Round(dblMonthlySalesTarget, 0)) * 100, 2);
                DG[11, selRaw].Value = Math.Round((Math.Round(dblMonthlyCollAche, 0) / Math.Round(dblMonthlyCollTarget, 0)) * 100, 2);

                //DG[10, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlySalesTarget, 0));
                //DG[11, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlySalesAche, 0));
                //DG[9, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlyCollTarget, 0));
                //DG[10, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlyCollAche, 0));

                DG[12, selRaw].Style.BackColor = Color.BlueViolet;
                DG[13, selRaw].Value = Math.Round((Math.Round(dblYearlySalesAche, 0) / Math.Round(dblYearlySalesTarget, 0)) * 100, 2);
                DG[14, selRaw].Value = Math.Round((Math.Round(dblYearlyCollAche, 0) / Math.Round(dblYearlyCollTarget, 0)) * 100, 2);

                DG[15, selRaw].Style.BackColor = Color.BlueViolet;

                //DG[12, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlySalesTarget, 0));
                //DG[13, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlySalesAche, 0));
                //DG[14, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyCollTarget, 0));
                //DG[15, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyCollAche, 0));
                //DG[16, selRaw].Style.BackColor = Color.BlueViolet;
                //DG[17, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalSalesTarget, 0));
                //DG[18, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalSalesAche, 0)); ;
                //DG[19, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalCollTarget, 0));
                //DG[20, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalCollAche, 0));

                //if (dblclosing < 0)
                //{
                //    DG[16, selRaw].Value = Math.Abs(dblclosing) + " Dr";
                //    DG[16, selRaw].Style.BackColor = Color.Ivory;
                //    DG[16, selRaw].Value = String.Format("{0:#,##0}", Math.Abs(dblclosing)) + " Dr";
                //}
                //else
                //{
                //    DG[16, selRaw].Value = Math.Abs(dblclosing) + " Cr";
                //    DG[16, selRaw].Style.BackColor = Color.Ivory;
                //    DG[16, selRaw].Value = String.Format("{0:#,##0}", Math.Abs(dblclosing)) + " Cr";
                //}
                DG[16, selRaw].Value = Math.Abs(dblclosing) ;
                DG[16, selRaw].Style.BackColor = Color.Ivory;
                DG[16, selRaw].Value = String.Format("{0:#,##0}", Math.Abs(dblclosing));
            }


        }
        private void mAdditemArea(string strItemName, string strMobile, double dblSalsTarget, double dblSalesAch, double dblCollTarget, double dblCollAche
                               , double dblMonthlySalesTarget, double dblMonthlySalesAche, double dblMonthlyCollTarget, double dblMonthlyCollAche
                               , double dblYearlySalesTarget, double dblYearlySalesAche, double dblYearlyCollTarget, double dblYearlyCollAche
                               , double dblYearlyTotalSalesTarget, double dblYearlyTotalSalesAche, double dblYearlyTotalCollTarget, double dblYearlyTotalCollAche)
        {
            int selRaw;
            double dblClosing = 0;
            DG.AllowUserToAddRows = true;
            selRaw = Convert.ToInt16(DG.RowCount.ToString());
            selRaw = selRaw - 1;
            DG.Rows.Add();
            DG[0, selRaw].Value = " " + strItemName;
            DG[1, selRaw].Value = Utility.Right(strMobile, 3);
            DG[1, selRaw].Style.BackColor = Color.Ivory;
            for (int intcol = 2; intcol <= DG.Columns.Count - 2; intcol++)
            {
                ////////DG[intcol, selRaw].Style.BackColor = Color.Aqua;
                DG[2, selRaw].Style.BackColor = Color.HotPink;
                DG[3, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblSalsTarget, 0));
                DG[4, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblSalesAch, 0));
                DG[5, selRaw].Value = Math.Round((Math.Round(dblSalesAch, 0) / Math.Round(dblSalsTarget, 0)) * 100, 2);
                DG[6, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblCollTarget, 0));
                DG[7, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblCollAche, 0));
                DG[8, selRaw].Value = Math.Round((Math.Round(dblCollAche, 0) / Math.Round(dblCollTarget, 0)) * 100, 2);

                DG[9, selRaw].Style.BackColor = Color.HotPink;
                DG[10, selRaw].Value = Math.Round((Math.Round(dblMonthlySalesAche, 0) / Math.Round(dblMonthlySalesTarget, 0)) * 100, 2);
                DG[11, selRaw].Value = Math.Round((Math.Round(dblMonthlyCollAche, 0) / Math.Round(dblMonthlyCollTarget, 0)) * 100, 2);

                //DG[10, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlySalesTarget, 0));
                //DG[11, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlySalesAche, 0));
                //DG[9, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlyCollTarget, 0));
                //DG[10, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlyCollAche, 0));

                DG[12, selRaw].Style.BackColor = Color.HotPink;
                DG[13, selRaw].Value = Math.Round((Math.Round(dblYearlySalesAche, 0) / Math.Round(dblYearlySalesTarget, 0)) * 100, 2);
                DG[14, selRaw].Value = Math.Round((Math.Round(dblYearlyCollAche, 0) / Math.Round(dblYearlyCollTarget, 0)) * 100, 2);

                DG[15, selRaw].Style.BackColor = Color.HotPink;

                //////DG[12, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlySalesTarget, 0));
                //////DG[13, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlySalesAche, 0));
                //////DG[14, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyCollTarget, 0));
                //////DG[15, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyCollAche, 0));
                //////DG[16, selRaw].Style.BackColor = Color.BlueViolet;
                //////DG[17, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalSalesTarget, 0));
                //////DG[18, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalSalesAche, 0)); ;
                //////DG[19, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalCollTarget, 0));
                //////DG[20, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalCollAche, 0));
            }

            dblClosing = Math.Round(dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom, DateTime.Now.ToString("dd-MM-yyyy"), "0001", "", strItemName, ""), 0);
            //if (dblClosing < 0)
            //{
            //    DG[16, selRaw].Value = Math.Abs(dblClosing) + " Dr";
            //    DG[16, selRaw].Style.BackColor = Color.Ivory;
            //    DG[16, selRaw].Value = String.Format("{0:#,##0}", Math.Abs(dblClosing)) + " Dr";
            //}
            //else
            //{
            //    DG[16, selRaw].Value = Math.Abs(dblClosing) + " Cr";
            //    DG[16, selRaw].Style.BackColor = Color.Ivory;
            //    DG[16, selRaw].Value = String.Format("{0:#,##0}", Math.Abs(dblClosing)) + " Cr";
            //}
            DG[16, selRaw].Value = Math.Abs(dblClosing);
            DG[16, selRaw].Style.BackColor = Color.Ivory;
            DG[16, selRaw].Value = String.Format("{0:#,##0}", Math.Abs(dblClosing));
        }
        private void CalculateZone(string strzone, double dblSalsTarget, double dblSalesAch, double dblCollTarget, double dblCollAche
                              , double dblMonthlySalesTarget, double dblMonthlySalesAche, double dblMonthlyCollTarget, double dblMonthlyCollAche
                              , double dblYearlySalesTarget, double dblYearlySalesAche, double dblYearlyCollTarget, double dblYearlyCollAche
                              , double dblYearlyTotalSalesTarget, double dblYearlyTotalSalesAche, double dblYearlyTotalCollTarget, double dblYearlyTotalCollAche,double dblclosig)
        {
            int selRaw;
            //double dblClosing = 0;
            DG.AllowUserToAddRows = true;
            selRaw = Convert.ToInt16(DG.RowCount.ToString());
            selRaw = selRaw - 1;
            DG.Rows.Add();
            DG[0, selRaw].Style.BackColor = Color.LemonChiffon;
            DG[0, selRaw].Value = "        " + "Zone Total";
            DG[1, selRaw].Style.BackColor = Color.LemonChiffon;
            for (int intcol = 2; intcol <= DG.Columns.Count - 2; intcol++)
            {
                DG[intcol, selRaw].Style.BackColor = Color.LemonChiffon;
               
                DG[3, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblSalsTarget, 0));
                DG[4, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblSalesAch, 0));
                DG[5, selRaw].Value = Math.Round((Math.Round(dblSalesAch, 0) / Math.Round(dblSalsTarget, 0)) * 100, 2);
                mChangeColor(5, Convert.ToDouble(DG[5, selRaw].Value));
                mChangeColorGrren(5, 80);
                DG[6, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblCollTarget, 0));
                DG[7, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblCollAche, 0));
                DG[8, selRaw].Value = Math.Round((Math.Round(dblCollAche, 0) / Math.Round(dblCollTarget, 0)) * 100, 2);
                mChangeColor(8, Convert.ToDouble(DG[8, selRaw].Value));
                mChangeColorGrren(8, 80);
                DG[10, selRaw].Value = Math.Round((Math.Round(dblMonthlySalesAche, 0) / Math.Round(dblMonthlySalesTarget, 0)) * 100, 2);
                
                mChangeColor(10, Convert.ToDouble(DG[10, selRaw].Value));
                mChangeColorGrren(10, 80);

                DG[11, selRaw].Value = Math.Round((Math.Round(dblMonthlyCollAche, 0) / Math.Round(dblMonthlyCollTarget, 0)) * 100, 2);
                mChangeColor(11, Convert.ToDouble(DG[11, selRaw].Value));
                mChangeColorGrren(11, 80);
                //DG[10, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlySalesTarget, 0));
                //DG[11, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlySalesAche, 0));
                //DG[9, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlyCollTarget, 0));
                //DG[10, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblMonthlyCollAche, 0));

                
                DG[13, selRaw].Value = Math.Round((Math.Round(dblYearlySalesAche, 0) / Math.Round(dblYearlySalesTarget, 0)) * 100, 2);
                mChangeColor(13, Convert.ToDouble(DG[13, selRaw].Value));
                mChangeColorGrren(13, 80);

                DG[14, selRaw].Value = Math.Round((Math.Round(dblYearlyCollAche, 0) / Math.Round(dblYearlyCollTarget, 0)) * 100, 2);
                mChangeColor(14, Convert.ToDouble(DG[14, selRaw].Value));
                mChangeColorGrren(14, 80);
                //////DG[12, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlySalesTarget, 0));
                //////DG[13, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlySalesAche, 0));
                //////DG[14, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyCollTarget, 0));
                //////DG[15, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyCollAche, 0));
                //////DG[16, selRaw].Style.BackColor = Color.BlueViolet;
                //////DG[17, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalSalesTarget, 0));
                //////DG[18, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalSalesAche, 0)); ;
                //////DG[19, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalCollTarget, 0));
                //////DG[20, selRaw].Value = String.Format("{0:#,##0}", Math.Round(dblYearlyTotalCollAche, 0));
                //dblClosing = Math.Round(dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom, DateTime.Now.ToString("dd-MM-yyyy"), "", "", "", strzone),0);
                //if (dblclosig < 0)
                //{
                //DG[16, selRaw].Value = Math.Abs(dblclosig) + " Dr";
                //DG[16, selRaw].Style.BackColor = Color.Ivory;
                //DG[16, selRaw].Value = String.Format("{0:#,##0}", Math.Abs(Math.Round(dblclosig, 0))) + " Dr";
                //}
                //else
                //{
                //    DG[16, selRaw].Value = Math.Abs(dblclosig) + " Cr";
                //    DG[16, selRaw].Style.BackColor = Color.Ivory;
                //    DG[16, selRaw].Value = String.Format("{0:#,##0}", Math.Abs(Math.Round(dblclosig, 0))) + " Cr";
                //}
                DG[16, selRaw].Value = Math.Abs(dblclosig) ;
                DG[16, selRaw].Style.BackColor = Color.Ivory;
                DG[16, selRaw].Value = String.Format("{0:#,##0}", Math.Abs(Math.Round(dblclosig, 0)));
            }


        }
        private void mChangeColor(int col, double dblPrecenatge)
        {
            double dblRowValue = 0;
            for (int irow=1;irow <DG.Rows.Count;irow++)
            {
                dblRowValue= Convert.ToDouble(DG[col,irow].Value);
                if (dblPrecenatge > dblRowValue  )
                {
                    DG[col, irow].Style.BackColor = Color.Red;
                    DG[col, irow].Style.ForeColor = Color.White;
                }
            }

        }
        private void mChangeColorGrren(int col, double dblPrecenatge)
        {
            double dblRowValue = 0;
            for (int irow = 1; irow < DG.Rows.Count; irow++)
            {
                dblRowValue = Convert.ToDouble(DG[col, irow].Value);
                if (dblPrecenatge < dblRowValue)
                {
                    DG[col, irow].Style.BackColor = Color.GreenYellow;
                    DG[col, irow].Style.ForeColor = Color.Black;
                }
            }

        }
        #endregion
        #region "Closing Balance"
        public static double dblLedgerClosingBalance(string strDeComID, string strFdate, string strTDate,
                                                   string strBranchID, string vstrDivision, string vstrArea, string vstrZone)
        {
            string strSQL = null;
            string connstring;
            double dblBackYearOpening = 0, dblOPening = 0, dblYearOpening = 0, dblOpeningDr = 0, dblOpeningCr = 0,
                                       dblTotalCredit = 0, dblTotalDebit = 0, dblclosing = 0;

            connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = gcnMain;
                if (strBranchID == "")
                {
                    strSQL = "SELECT  ISNULL(SUM(ACC_LEDGER.LEDGER_OPENING_BALANCE),0) AS OPENING  FROM ACC_LEDGER,ACC_LEDGER_Z_D_A WHERE ACC_LEDGER.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME    ";
                    //strSQL = strSQL + "AND ACC_LEDGER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                    if (vstrDivision != "")
                    {
                        strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.DIVISION = '" + vstrDivision + "' ";
                    }
                    else if (vstrArea != "")
                    {
                        strSQL = strSQL + "  AND ACC_LEDGER_Z_D_A.AREA = '" + vstrArea + "' ";
                    }
                    else
                    {
                        strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.ZONE = '" + vstrZone + "' ";
                    }
                }
                else
                {
                    strSQL = "SELECT ISNULL(SUM(ACC_BRANCH_LEDGER_OPENING.BRANCH_LEDGER_OPENING_BALANCE),0) AS OPENING FROM ACC_BRANCH_LEDGER_OPENING,ACC_LEDGER_Z_D_A WHERE ACC_BRANCH_LEDGER_OPENING.LEDGER_NAME =ACC_LEDGER_Z_D_A.LEDGER_NAME  ";
                    //strSQL = strSQL + "WHERE ACC_BRANCH_LEDGER_OPENING.LEDGER_NAME = '" + vstrLedgerName.Replace("'", "''") + "' ";
                    if (strBranchID != "")
                    {
                        strSQL = strSQL + "AND ACC_BRANCH_LEDGER_OPENING.BRANCH_ID = '" + strBranchID + "' ";
                    }
                    if (vstrDivision != "")
                    {
                        strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.DIVISION = '" + vstrDivision + "' ";
                    }
                    else if (vstrArea != "")
                    {
                        strSQL = strSQL + "  AND ACC_LEDGER_Z_D_A.AREA = '" + vstrArea + "' ";
                    }
                    else
                    {
                        strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.ZONE = '" + vstrZone + "' ";
                    }
                }

                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblOPening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM  ACC_VOUCHER , ACC_LEDGER,ACC_LEDGER_Z_D_A WHERE ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
				strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_LEDGER.LEDGER_NAME  ";
                //strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND ACC_VOUCHER.COMP_VOUCHER_DATE >= ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + "";
                strSQL = strSQL + " AND  ";
                strSQL = strSQL + " ACC_VOUCHER.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFdate) + " ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                if (vstrDivision != "")
                {
                    strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.DIVISION = '" + vstrDivision + "' ";
                }
                else if (vstrArea != "")
                {
                    strSQL = strSQL + "  AND ACC_LEDGER_Z_D_A.AREA = '" + vstrArea + "' ";
                }
                else
                {
                    strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.ZONE = '" + vstrZone + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();

                strSQL = "SELECT ISNULL(SUM(VOUCHER_CREDIT_AMOUNT - VOUCHER_DEBIT_AMOUNT),0) AS OPENING ";
                strSQL = strSQL + "FROM  ACC_VOUCHER , ACC_LEDGER,ACC_LEDGER_Z_D_A WHERE ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER.LEDGER_NAME ";
                strSQL = strSQL + "AND ACC_LEDGER_Z_D_A.LEDGER_NAME =ACC_LEDGER.LEDGER_NAME  ";
                //strSQL = strSQL + "WHERE ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND COMP_VOUCHER_DATE < ";
                strSQL = strSQL + Utility.cvtSQLDateString(Utility.gstrFinicialYearFrom) + " ";
                strSQL = strSQL + "AND (ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrASSET + " OR ACC_LEDGER.LEDGER_PRIMARY_TYPE = " + (int)Utility.LEDGER_PRM_TYPE.lgrLIABILITY + " ) ";

                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                if (vstrDivision != "")
                {
                    strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.DIVISION = '" + vstrDivision + "' ";
                }
                else if (vstrArea != "")
                {
                    strSQL = strSQL + "  AND ACC_LEDGER_Z_D_A.AREA = '" + vstrArea + "' ";
                }
                else
                {
                    strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.ZONE = '" + vstrZone + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblBackYearOpening = Convert.ToDouble(dr["OPENING"].ToString());
                }
                dr.Close();


                dblOPening = dblYearOpening + dblBackYearOpening + dblOPening;

                if (dblOPening < 0)
                {
                    dblOpeningDr = dblOPening;
                }
                else
                {
                    dblOpeningCr = dblOPening;
                }
                ///Sales Invoice Credit Limit
                strSQL = "SELECT ISNULL(SUM(ACC_VOUCHER.VOUCHER_CREDIT_AMOUNT),0) AS TOTAL_CREDIT,";
                strSQL = strSQL + "ISNULL(SUM(VOUCHER_DEBIT_AMOUNT),0) AS TOTAL_DEBIT ";
                strSQL = strSQL + "FROM ACC_VOUCHER,ACC_LEDGER_Z_D_A WHERE ACC_VOUCHER.LEDGER_NAME= ACC_LEDGER_Z_D_A.LEDGER_NAME ";
                //strSQL = strSQL + "AND ACC_VOUCHER.LEDGER_NAME = '" + vstrLedgerName + "' ";
                strSQL = strSQL + "AND (ACC_VOUCHER.COMP_VOUCHER_DATE BETWEEN ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFdate) + " ";
                strSQL = strSQL + "AND ";
                strSQL = strSQL + " " + Utility.cvtSQLDateString(strTDate) + ") ";
                if (strBranchID != "")
                {
                    strSQL = strSQL + "AND ACC_VOUCHER.BRANCH_ID = '" + strBranchID + "' ";
                }
                if (vstrDivision != "")
                {
                    strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.DIVISION = '" + vstrDivision + "' ";
                }
                else if (vstrArea != "")
                {
                    strSQL = strSQL + "  AND ACC_LEDGER_Z_D_A.AREA = '" + vstrArea + "' ";
                }
                else
                {
                    strSQL = strSQL + " AND ACC_LEDGER_Z_D_A.ZONE = '" + vstrZone + "' ";
                }
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    dblTotalCredit = Convert.ToDouble(dr["TOTAL_CREDIT"].ToString());
                    dblTotalDebit = Convert.ToDouble(dr["TOTAL_DEBIT"].ToString());
                }
                //dr.Close();
                dblclosing = dblOPening + (dblTotalCredit - dblTotalDebit);

                dr.Close();
                gcnMain.Close();
                cmdInsert.Dispose();
                return dblclosing;

            }
        }
        //public static double dblLedgerClosingBalance(string strDeComID, string strFdate, string strTDate,
        //                                            string strBranchID, string vstrDivision, string vstrArea, string vstrZone)
        //{
        //    string strSQL = null;
        //    string connstring;
        //    double  dblclosing = 0;

        //    connstring = Utility.SQLConnstringComSwitch(strDeComID);

        //    using (SqlConnection gcnMain = new SqlConnection(connstring))
        //    {
        //        if (gcnMain.State == ConnectionState.Open)
        //        {
        //            gcnMain.Close();
        //        }
        //        gcnMain.Open();
        //        SqlDataReader dr;
        //        SqlCommand cmdInsert = new SqlCommand();
        //        cmdInsert.Connection = gcnMain;

        //        strSQL = "SELECT isnull(sum(PREVIOUS_DUES_GOODS+abs(SALES_CURRENT_MONTH)+DEBIT_AMOUNT - (RETURN_AMOUNT+COLL_VOUCHER +COLL_CASH_TT +CREDIT_AMOUNT)),0) *-1 as cls  ";
        //        strSQL = strSQL + "FROM ACC_FINAL_STATEMENT_DASH WHERE ";
        //        if (vstrDivision != "")
        //        {
        //            strSQL = strSQL + " DIVISION = '" + vstrDivision + "' ";
        //        }
        //        else if (vstrArea != "")
        //        {
        //            strSQL = strSQL + " AREA = '" + vstrArea + "' ";
        //        }
        //        else
        //        {
        //            strSQL = strSQL + " ZONE = '" + vstrZone + "' ";
        //        }
        //        cmdInsert.CommandText = strSQL;
        //        dr = cmdInsert.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            return Convert.ToDouble(dr["cls"].ToString());
        //        }
        //        else
        //        {
        //            return 0;
        //        }

        //        dr.Close();
        //        gcnMain.Close();
        //        cmdInsert.Dispose();
        //        return dblclosing;

        //    }
        //}
        #endregion
        #region "Collection"
        public string GetrptCollectionTargetAchieve(string strDeComID, string strBranchID, string strFate, string strTDate, string strCurrentDate, int intStatus, 
                                                        string strZone, string stryearFdate, string stryearTdate)
        {
            string strSQL = null,strPreviousMonth="";
            string connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strPreviousMonth = Utility.LastDayOfMonth(Convert.ToDateTime(strCurrentDate).AddMonths(-1)).ToString("dd-MM-yyyy");
            long intnofdays = 0, intnodays1 = 0;
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "DELETE from ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                intnofdays =Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(strFate), Convert.ToDateTime(strCurrentDate)) + 1;
                intnodays1 = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(strFate), Convert.ToDateTime(strTDate)) + 1;
                //intYearly = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(stryearFdate), Convert.ToDateTime(strCurrentDate)) + 1;
                //intYearly1 = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(stryearFdate), Convert.ToDateTime(stryearTdate)) + 1;
                if (intnofdays>25)
                {
                    intnofdays = 25;
                }
                else
                {
                    intnofdays = intnofdays;
                }
                if (intnodays1 > 25)
                {
                    intnodays1 = 25;
                }
                else
                {
                    intnodays1 = intnodays1;
                }
                //*************Monthly UptoDate
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,SAL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)/25 * " + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,SAL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE  from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG ";
                strSQL = strSQL + "where  l.LEDGER_NAME =c.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME  ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,COLL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "(ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0)/ + " + intnodays1 + ") *" + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,COLL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";

                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //HLPF
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,COLL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) *-1 COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.REVERSE_LEDGER1  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 AND av.AUTOJV=1 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";

                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //************************
                //******MonthlyTotal

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,M_SAL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)  AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,M_SAL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE  from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG ";
                strSQL = strSQL + "where  l.LEDGER_NAME =c.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME  ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,M_COLL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0) AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,M_COLL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";

                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //************************
                //******Yearly Total
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_SAL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + " ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)  AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(stryearFdate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strPreviousMonth) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_SAL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)/25 * " + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_SAL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE  from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG ";
                strSQL = strSQL + "where  l.LEDGER_NAME =c.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME  ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(stryearFdate) + ") AND (" + Utility.cvtSQLDateString(strCurrentDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_COLL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + " (ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0)) AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(stryearFdate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strPreviousMonth) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_COLL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "(ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0)/ + " + intnodays1 + ") *" + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();



                //string strModifyDate = Convert.ToDateTime(stryearFdate).AddMonths(1).ToString("dd-MM-yyyy");
                string strModifyDate = Convert.ToDateTime(stryearFdate).ToString("dd-MM-yyyy");

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_COLL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strModifyDate) + ") AND (" + Utility.cvtSQLDateString(strCurrentDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //hlPF
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_COLL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0)*-1 COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.REVERSE_LEDGER1  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 AND av.AUTOJV=1 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strModifyDate) + ") AND (" + Utility.cvtSQLDateString(strCurrentDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //************************
                //******Yearly up to Date
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_SAL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)  AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(stryearFdate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strPreviousMonth) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_SAL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE  from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG ";
                strSQL = strSQL + "where  l.LEDGER_NAME =c.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME  ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(stryearFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_COLL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0) AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(stryearFdate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strPreviousMonth) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_COLL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "(ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0)/ + " + intnodays1 + ") *" + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_COLL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(stryearFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";

                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //hl
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_COLL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) *-1 COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.REVERSE_LEDGER1  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 AND av.AUTOJV=1 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(stryearFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";

                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //*****************

                //strSQL = "DELETE FROM ACC_SAL_COLL_TARGET_ACHIEVE WHERE (COLL_ACHIEVE + COLL_TARGET + SAL_TARGET + SAL_ACHIEVE)=0 ";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();
                return "1";

            }
        }
        public string GetrptCollectionTargetAchieveSummarry(string strDeComID, string strBranchID, string strFate, string strTDate, string strCurrentDate, int intStatus,
                                                        string strZone, string stryearFdate, string stryearTdate,int intmode)
        {
            string strSQL = null, strPreviousMonth = "";
            string connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strPreviousMonth = Utility.LastDayOfMonth(Convert.ToDateTime(strCurrentDate).AddMonths(-1)).ToString("dd-MM-yyyy");
            long intnofdays = 0, intnodays1 = 0;
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                if (intmode == 0)
                {
                    strSQL = "DELETE from ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                intnofdays = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(strFate), Convert.ToDateTime(strCurrentDate)) + 1;
                intnodays1 = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(strFate), Convert.ToDateTime(strTDate)) + 1;
                //intYearly = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(stryearFdate), Convert.ToDateTime(strCurrentDate)) + 1;
                //intYearly1 = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(stryearFdate), Convert.ToDateTime(stryearTdate)) + 1;
                if (intnofdays > 25)
                {
                    intnofdays = 25;
                }
                else
                {
                    intnofdays = intnofdays;
                }
                if (intnodays1 > 25)
                {
                    intnodays1 = 25;
                }
                else
                {
                    intnodays1 = intnodays1;
                }
                //*************Monthly UptoDate
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,SAL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)/25 * " + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,SAL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE  from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG ";
                strSQL = strSQL + "where  l.LEDGER_NAME =c.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME  ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,COLL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "(ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0)/ + " + intnodays1 + ") *" + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,COLL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";

                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //************************
                //******MonthlyTotal

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,M_SAL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)  AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,M_SAL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE  from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG ";
                strSQL = strSQL + "where  l.LEDGER_NAME =c.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME  ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,M_COLL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0) AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";

                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,M_COLL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";

                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //************************
                //******Yearly Total
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_SAL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + " ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)  AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(stryearFdate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strPreviousMonth) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_SAL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)/25 * " + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_SAL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE  from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG ";
                strSQL = strSQL + "where  l.LEDGER_NAME =c.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME  ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(stryearFdate) + ") AND (" + Utility.cvtSQLDateString(strCurrentDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS in (0,1,2) ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_COLL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + " (ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0)) AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(stryearFdate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strPreviousMonth) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_COLL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "(ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0)/ + " + intnodays1 + ") *" + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();



                string strModifyDate = Convert.ToDateTime(stryearFdate).AddMonths(1).ToString("dd-MM-yyyy");

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_COLL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strModifyDate) + ") AND (" + Utility.cvtSQLDateString(strCurrentDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //************************
                //******Yearly up to Date
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_SAL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)  AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(stryearFdate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strPreviousMonth) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_SAL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE  from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG ";
                strSQL = strSQL + "where  l.LEDGER_NAME =c.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME  ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(stryearFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_COLL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0) AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(stryearFdate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strPreviousMonth) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_COLL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "(ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0)/ + " + intnodays1 + ") *" + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_COLL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(stryearFdate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE='" + strZone + "' ";

                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //*****************

                //strSQL = "DELETE FROM ACC_SAL_COLL_TARGET_ACHIEVE WHERE (COLL_ACHIEVE + COLL_TARGET + SAL_TARGET + SAL_ACHIEVE)=0 ";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();
                return "1";

            }
        }
        public string mGetFinalStattemnet(string strDeComID, string strFate, string strTDate, string strBranchID, string strGroupName,
                                                        string strPartyName, int intstatus)
        {
            string strSQL = null, strSelection = "", strName="";
           string connstring = Utility.SQLConnstringComSwitch(strDeComID);

            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlDataReader dr;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;
                strSQL = "DELETE FROM ACC_FINAL_STATEMENT_DASH";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                if (strGroupName != "")
                {
                    if (strGroupName.Contains("ZONE") == true)
                    {
                        strName= "'EAST ZONE (SOBUR REZA PRODHAN)','NORTH ZONE (SAJIB AHMED)','SOUTH ZONE (H.M SYFULLAH)','WEST ZONE (ABDULLAH AL MARUF)'";
                        strSelection = "Z";
                    }
                    else
                    {
                        strSelection = strGroupName.Substring(0, 1).ToUpper();
                    }

                }

                //Previous Dues
                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                strSQL = strSQL + "SELECT g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, isnull(sum(l.LEDGER_OPENING_BALANCE),0) *-1 PDUES   ";
                strSQL = strSQL + ",g.GR_PARENT_POSITION from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                strSQL = strSQL + "AND l.BRANCH_ID ='" + strBranchID + "' ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //Current Month
                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) SALES_CURRENT_MONTH   ";
                strSQL = strSQL + ",g.GR_PARENT_POSITION from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =16 ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Return
                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0))*-1 RETURN_AMOUNT,g.GR_PARENT_POSITION   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =13 ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Debit Amount

                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) DEBIT_AMOUNT,g.GR_PARENT_POSITION   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                strSQL = strSQL + "AND aV.VOUCHER_TOBY ='Dr' AND aV.COMP_VOUCHER_TYPE =3 ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + " AND  C.SP_JOURNAL =0 ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //Credit Amount
                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME ,l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) *-1 CREDIT_AMOUNT,g.GR_PARENT_POSITION   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                strSQL = strSQL + "AND aV.VOUCHER_TOBY ='Cr' AND aV.COMP_VOUCHER_TYPE =3 ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + " AND  C.SP_JOURNAL =0 ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //Cash
                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME,l.TERITORRY_CODE, l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + " abs(ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0)) *-1 COLL_CASH_TT,g.GR_PARENT_POSITION ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av  ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO  ";
                strSQL = strSQL + "AND av.COMP_VOUCHER_TYPE=" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND l.BRANCH_ID ='" + strBranchID + "' ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //SP Journal
                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME ,l.TERITORRY_CODE,l.LEDGER_NAME_MERZE,";
                strSQL = strSQL + "ABS(ISNULL(SUM(aV.VOUCHER_CREDIT_AMOUNT-aV.VOUCHER_DEBIT_AMOUNT),0)) *-1 COLL_VOUCHER,g.GR_PARENT_POSITION   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =3 and c.SP_JOURNAL=1 ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                //*********opn
                //Current Month Sales
                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,SALES_CURRENT_MONTH,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) SALES_CURRENT_MONTH,g.GR_PARENT_POSITION   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =16 ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Return
                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,RETURN_AMOUNT,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) RETURN_AMOUNT,g.GR_PARENT_POSITION   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =13 ";
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Debit Amount

                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,DEBIT_AMOUNT,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) DEBIT_AMOUNT,g.GR_PARENT_POSITION   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                strSQL = strSQL + "AND aV.VOUCHER_TOBY ='Dr' AND aV.COMP_VOUCHER_TYPE =3 ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + " AND  C.SP_JOURNAL =0 ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //Credit Amount
                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,CREDIT_AMOUNT,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME ,l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) CREDIT_AMOUNT,g.GR_PARENT_POSITION   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                strSQL = strSQL + "AND aV.VOUCHER_TOBY ='Cr' AND aV.COMP_VOUCHER_TYPE =3 ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                strSQL = strSQL + " AND  C.SP_JOURNAL =0 ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Commitment
                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,COMMITMENT,POSITION) ";
                strSQL = strSQL + " select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME ,l.TERITORRY_CODE,l.LEDGER_NAME_MERZE,";
                strSQL = strSQL + " ISNULL(SUM(C.COLL_TARGET_COLL_AMT),0) COMMITMENT ,g.GR_PARENT_POSITION  ";
                strSQL = strSQL + " from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,SALES_COLL_TARGET_MASTER m,SALES_COLL_TARGET_TRAN c ";
                strSQL = strSQL + " where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME  and m.COLL_TARGET_KEY=c.COLL_TARGET_KEY ";
                strSQL = strSQL + " AND C.COLL_TARGET_FROM_DATE >= " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + " AND C.COLL_TARGET_TO_DATE <= " + Utility.cvtSQLDateString(strTDate) + " ";
                strSQL = strSQL + " AND m.BRANCH_ID ='" + strBranchID + "' ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Cash
                //strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,COLL_CASH_TT,POSITION) ";
                //strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME,l.TERITORRY_CODE, l.LEDGER_NAME_MERZE, ";
                //strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) COLL_CASH_TT,g.GR_PARENT_POSITION ";
                //strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av  ";
                //strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO  ";
                //strSQL = strSQL + "AND av.COMP_VOUCHER_TYPE=" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " ";
                //strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                //strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                //strSQL = strSQL + "AND l.BRANCH_ID ='" + strBranchID + "' ";

                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,COLL_CASH_TT,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME,l.TERITORRY_CODE, l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(AV.VOUCHER_CREDIT_AMOUNT),0) COLL_CASH_TT,g.GR_PARENT_POSITION ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av  ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO  ";
                strSQL = strSQL + "AND av.COMP_VOUCHER_TYPE=" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                strSQL = strSQL + "AND l.BRANCH_ID ='" + strBranchID + "' ";

                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //SP Journal
                strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,COLL_VOUCHER,POSITION) ";
                strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME ,l.TERITORRY_CODE,l.LEDGER_NAME_MERZE,";
                strSQL = strSQL + "ISNULL(SUM(aV.VOUCHER_CREDIT_AMOUNT-aV.VOUCHER_DEBIT_AMOUNT),0) COLL_VOUCHER,g.GR_PARENT_POSITION   ";
                strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =3 and c.SP_JOURNAL=1 ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                if (strGroupName != "")
                {
                    if (strSelection == "Z")
                    {
                        strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                    }
                    else if (strSelection == "D")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "R")
                    {
                        strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "A")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "F")
                    {
                        strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                    }
                    else if (strSelection == "S")
                    {
                        strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                    }
                }
                else if (strPartyName != "")
                {
                    strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                }
                if (intstatus < 2)
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS =" + intstatus + " ";
                }
                else
                {
                    strSQL = strSQL + "AND l.LEDGER_STATUS in (0,1)";
                }
                strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //*******************Close Ledger
                if (intstatus == 2)
                {
                    //Previous Dues
                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                    strSQL = strSQL + "SELECT g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, isnull(sum(l.LEDGER_OPENING_BALANCE),0) *-1 PDUES   ";
                    strSQL = strSQL + ",g.GR_PARENT_POSITION from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP ";
                    strSQL = strSQL + "AND l.BRANCH_ID ='" + strBranchID + "' ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Current Month
                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                    strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) SALES_CURRENT_MONTH   ";
                    strSQL = strSQL + ",g.GR_PARENT_POSITION from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c ";
                    strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME ";
                    strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =16 ";
                    strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //Return
                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                    strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0))*-1 RETURN_AMOUNT   ";
                    strSQL = strSQL + ",g.GR_PARENT_POSITION from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c ";
                    strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME ";
                    strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =13 ";
                    strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //Debit Amount

                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                    strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) DEBIT_AMOUNT,g.GR_PARENT_POSITION   ";
                    strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                    strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                    strSQL = strSQL + "AND aV.VOUCHER_TOBY ='Dr' AND aV.COMP_VOUCHER_TYPE =3 ";
                    strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                    strSQL = strSQL + " AND  C.SP_JOURNAL =0 ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Credit Amount
                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                    strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME ,l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) *-1 CREDIT_AMOUNT,g.GR_PARENT_POSITION   ";
                    strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                    strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                    strSQL = strSQL + "AND aV.VOUCHER_TOBY ='Cr' AND aV.COMP_VOUCHER_TYPE =3 ";
                    strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                    strSQL = strSQL + " AND  C.SP_JOURNAL =0 ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Cash
                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                    strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME,l.TERITORRY_CODE, l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + " abs(ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0)) *-1 COLL_CASH_TT,g.GR_PARENT_POSITION ";
                    strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av  ";
                    strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO  ";
                    strSQL = strSQL + "AND av.COMP_VOUCHER_TYPE=" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " ";
                    strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.BRANCH_ID ='" + strBranchID + "' ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //SP Journal
                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,PREVIOUS_DUES_GOODS,POSITION) ";
                    strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME ,l.TERITORRY_CODE,l.LEDGER_NAME_MERZE,";
                    strSQL = strSQL + "ABS(ISNULL(SUM(aV.VOUCHER_CREDIT_AMOUNT-aV.VOUCHER_DEBIT_AMOUNT),0)) *-1 COLL_VOUCHER,g.GR_PARENT_POSITION   ";
                    strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                    strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                    strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =3 and c.SP_JOURNAL=1 ";
                    strSQL = strSQL + "AND C.COMP_VOUCHER_DATE < " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    //*********opn
                    //Current Month Sales
                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,SALES_CURRENT_MONTH,POSITION) ";
                    strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) SALES_CURRENT_MONTH,g.GR_PARENT_POSITION   ";
                    strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c ";
                    strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME ";
                    strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                    strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =16 ";
                    strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //Return
                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,RETURN_AMOUNT,POSITION) ";
                    strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) RETURN_AMOUNT ,g.GR_PARENT_POSITION  ";
                    strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c ";
                    strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME ";
                    strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                    strSQL = strSQL + "AND  C.COMP_VOUCHER_TYPE =13 ";
                    strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //Debit Amount

                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,DEBIT_AMOUNT,POSITION) ";
                    strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME , l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) DEBIT_AMOUNT,g.GR_PARENT_POSITION   ";
                    strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                    strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                    strSQL = strSQL + "AND aV.VOUCHER_TOBY ='Dr' AND aV.COMP_VOUCHER_TYPE =3 ";
                    strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                    strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                    strSQL = strSQL + " AND  C.SP_JOURNAL =0 ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //Credit Amount
                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,CREDIT_AMOUNT,POSITION) ";
                    strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME ,l.TERITORRY_CODE,l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) CREDIT_AMOUNT,g.GR_PARENT_POSITION   ";
                    strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                    strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                    strSQL = strSQL + "AND aV.VOUCHER_TOBY ='Cr' AND aV.COMP_VOUCHER_TYPE =3 ";
                    strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                    strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                    strSQL = strSQL + " AND  C.SP_JOURNAL =0 ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //Commitment
                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,COMMITMENT,POSITION) ";
                    strSQL = strSQL + " select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME ,l.TERITORRY_CODE,l.LEDGER_NAME_MERZE,";
                    strSQL = strSQL + " ISNULL(SUM(C.COLL_TARGET_COLL_AMT),0) COMMITMENT,g.GR_PARENT_POSITION   ";
                    strSQL = strSQL + " from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,SALES_COLL_TARGET_MASTER m,SALES_COLL_TARGET_TRAN c ";
                    strSQL = strSQL + " where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =c.LEDGER_NAME  and m.COLL_TARGET_KEY=c.COLL_TARGET_KEY ";
                    strSQL = strSQL + " AND C.COLL_TARGET_FROM_DATE >= " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + " AND C.COLL_TARGET_TO_DATE <= " + Utility.cvtSQLDateString(strTDate) + " ";
                    strSQL = strSQL + " AND m.BRANCH_ID ='" + strBranchID + "' ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //Cash
                    //strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,COLL_CASH_TT,POSITION) ";
                    //strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME,l.TERITORRY_CODE, l.LEDGER_NAME_MERZE, ";
                    //strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) COLL_CASH_TT,g.GR_PARENT_POSITION ";
                    //strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av  ";
                    //strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO  ";
                    //strSQL = strSQL + "AND av.COMP_VOUCHER_TYPE=" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " ";
                    //strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                    //strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                    //strSQL = strSQL + "AND l.BRANCH_ID ='" + strBranchID + "' ";
                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,COLL_CASH_TT,POSITION) ";
                    strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME,l.TERITORRY_CODE, l.LEDGER_NAME_MERZE, ";
                    strSQL = strSQL + "ISNULL(SUM(AV.VOUCHER_CREDIT_AMOUNT),0) COLL_CASH_TT,g.GR_PARENT_POSITION ";
                    strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av  ";
                    strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO  ";
                    strSQL = strSQL + "AND av.COMP_VOUCHER_TYPE=" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " ";
                    strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                    strSQL = strSQL + "AND l.BRANCH_ID ='" + strBranchID + "' ";

                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";
                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //SP Journal
                    strSQL = "INSERT INTO ACC_FINAL_STATEMENT_DASH(ZONE,DIVISION,AREA,TERITORY_NAME,TERITORY_CODE,MEDICAL_REPRESENTATIVE,COLL_VOUCHER,POSITION) ";
                    strSQL = strSQL + "select g.GR_PARENT AS zone, g.GR_NAME AS Division, l.LEDGER_PARENT_GROUP AS area,l.TERRITORRY_NAME ,l.TERITORRY_CODE,l.LEDGER_NAME_MERZE,";
                    strSQL = strSQL + "ISNULL(SUM(aV.VOUCHER_CREDIT_AMOUNT-aV.VOUCHER_DEBIT_AMOUNT),0) COLL_VOUCHER,g.GR_PARENT_POSITION   ";
                    strSQL = strSQL + "from ACC_LEDGERGROUP g,ACC_LEDGERGROUP_CATEGORY_VIEW v,ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av ";
                    strSQL = strSQL + "where g.GR_NAME=v.GR_PARENT  and v.GR_NAME=l.LEDGER_PARENT_GROUP and l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO ";
                    strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =3 and c.SP_JOURNAL=1 ";
                    strSQL = strSQL + "AND C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate);
                    strSQL = strSQL + "AND C.BRANCH_ID ='" + strBranchID + "' ";
                    if (strGroupName != "")
                    {
                        if (strSelection == "Z")
                        {
                            strSQL = strSQL + "AND g.GR_PARENT in (" + strName + ")";
                        }
                        else if (strSelection == "D")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "R")
                        {
                            strSQL = strSQL + "AND g.GR_NAME ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "A")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "F")
                        {
                            strSQL = strSQL + "AND l.LEDGER_PARENT_GROUP ='" + strGroupName + "' ";
                        }
                        else if (strSelection == "S")
                        {
                            strSQL = strSQL + "AND g.GR_ONE_DOWN ='" + strGroupName + "' ";
                        }
                    }
                    else if (strPartyName != "")
                    {
                        strSQL = strSQL + "AND l.LEDGER_NAME ='" + strPartyName + "' ";
                    }
                    strSQL = strSQL + "AND l.LEDGER_STATUS =2";
                    strSQL = strSQL + "AND l.CLOSE_DATE > " + Utility.cvtSQLDateString(strFate) + " ";
                    strSQL = strSQL + "AND l.CLOSE_DATE  is not null ";

                    strSQL = strSQL + "group by g.GR_PARENT , g.GR_NAME , l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE,l.TERITORRY_CODE,l.TERRITORRY_NAME,g.GR_PARENT_POSITION ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                ///****************

                cmdInsert.Transaction.Commit();
                gcnMain.Close();
                return "1";

            }
        }
        public string GetrptCollectionZone(string strDeComID, string strBranchID, string strFate, string strTDate, string strCurrentDate, int intStatus,
                                                       string strZone, string stryearFdate, string stryearTdate)
        {
            string strSQL = null, strPreviousMonth = "";
            string connstring = Utility.SQLConnstringComSwitch(strDeComID);
            strPreviousMonth = Utility.LastDayOfMonth(Convert.ToDateTime(strCurrentDate).AddMonths(-1)).ToString("dd-MM-yyyy");
            long intnofdays = 0, intnodays1 = 0;
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "DELETE from ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                intnofdays = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(strFate), Convert.ToDateTime(strCurrentDate)) + 1;
                intnodays1 = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(strFate), Convert.ToDateTime(strTDate)) + 1;
                //intYearly = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(stryearFdate), Convert.ToDateTime(strCurrentDate)) + 1;
                //intYearly1 = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(stryearFdate), Convert.ToDateTime(stryearTdate)) + 1;
                if (intnofdays > 25)
                {
                    intnofdays = 25;
                }
                else
                {
                    intnofdays = intnofdays;
                }
                if (intnodays1 > 25)
                {
                    intnodays1 = 25;
                }
                else
                {
                    intnodays1 = intnodays1;
                }
                //*************Monthly UptoDate
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,SAL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)/25 * " + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,SAL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE  from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG ";
                strSQL = strSQL + "where  l.LEDGER_NAME =c.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME  ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,COLL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "(ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0)/ + " + intnodays1 + ") *" + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,COLL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";

                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //************************
                //******MonthlyTotal

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,M_SAL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)  AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,M_SAL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE  from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG ";
                strSQL = strSQL + "where  l.LEDGER_NAME =c.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME  ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,M_COLL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0) AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";

                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,M_COLL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(strFate) + ") AND (" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";

                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //************************
                //******Yearly uptoDate
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_SAL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + " ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)  AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(stryearFdate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strPreviousMonth) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_SAL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)/25 * " + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_SAL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE  from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG ";
                strSQL = strSQL + "where  l.LEDGER_NAME =c.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME  ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(stryearFdate) + ") AND (" + Utility.cvtSQLDateString(strCurrentDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_COLL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + " (ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0)) AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(stryearFdate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strPreviousMonth) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_COLL_TARGET) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "(ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0)/ + " + intnodays1 + ") *" + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();





                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_COLL_ACHIEVE) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(stryearFdate) + ") AND (" + Utility.cvtSQLDateString(strCurrentDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";

                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //************************
                //******Yearly up to Date
                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_SAL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.TARGET_ACHIEVE_AMOUNT),0)  AS TARGET_ACHIEVE_AMOUNT FROM SALES_TARGET_ACHIEVEMENT_MASTER M ,SALES_TARGET_ACHIEVEMENT T, ";
                strSQL = strSQL + "ACC_LEDGER L, ACC_LEDGER_Z_D_A LG WHERE M.TARGET_ACHIEVE_KEY=T.TARGET_ACHIEVE_KEY AND L.LEDGER_NAME =T.LEDGER_NAME and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.TARGET_ACHIEVE_FROM_DATE >= (" + Utility.cvtSQLDateString(stryearFdate) + ") AND T.TARGET_ACHIEVE_TO_DATE <=(" + Utility.cvtSQLDateString(stryearTdate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_SAL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE  from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG ";
                strSQL = strSQL + "where  l.LEDGER_NAME =c.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME  ";
                strSQL = strSQL + "AND C.COMP_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE + " ";
                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(stryearFdate) + ") AND (" + Utility.cvtSQLDateString(stryearTdate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_COLL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0) AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(stryearFdate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(stryearTdate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_NAME,LEDGER_GROUP_NAME,Y_COLL_TARGET_TOTAL) ";
                strSQL = strSQL + "SELECT L.LEDGER_NAME_MERZE AS LEDGER_NAME ,l.LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "(ISNULL(SUM(T.COLL_TARGET_COLL_AMT),0)/ + " + intnodays1 + ") *" + intnofdays + "   AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T, ACC_LEDGER_Z_D_A LG , ";
                strSQL = strSQL + "ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= (" + Utility.cvtSQLDateString(strFate) + ") AND T.COLL_TARGET_TO_DATE <=(" + Utility.cvtSQLDateString(strTDate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";
                strSQL = strSQL + "GROUP BY L.LEDGER_NAME_MERZE,l.LEDGER_PARENT_GROUP ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO  ACC_SAL_COLL_TARGET_ACHIEVE_DISPLAY(LEDGER_GROUP_NAME,LEDGER_NAME,Y_COLL_ACHIEVE_TOTAL) ";
                strSQL = strSQL + "SELECT l.LEDGER_PARENT_GROUP ,l.LEDGER_NAME_MERZE, ";
                strSQL = strSQL + "ISNULL(SUM(av.VOUCHER_CREDIT_AMOUNT),0) COLLECTION_AMNT   from ACC_LEDGER l,ACC_COMPANY_VOUCHER c,ACC_VOUCHER av, ACC_LEDGER_Z_D_A LG  ";
                strSQL = strSQL + "where l.LEDGER_NAME =av.LEDGER_NAME  and c.COMP_REF_NO =av.COMP_REF_NO AND  L.LEDGER_NAME=LG.LEDGER_NAME   ";
                strSQL = strSQL + "AND aV.COMP_VOUCHER_TYPE =" + (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER + " and C.COMP_VOUCHER_NET_AMOUNT > 0 ";
                strSQL = strSQL + "AND (c.COMP_VOUCHER_DATE BETWEEN (" + Utility.cvtSQLDateString(stryearFdate) + ") AND (" + Utility.cvtSQLDateString(stryearTdate) + ")) ";
                strSQL = strSQL + " AND L.LEDGER_STATUS =" + intStatus + " ";
                strSQL = strSQL + " AND l.BRANCH_ID='" + strBranchID + "' ";
                strSQL = strSQL + " AND LG.ZONE in (" + strZone + ")";

                strSQL = strSQL + "GROUP by  l.LEDGER_PARENT_GROUP,l.LEDGER_NAME_MERZE ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //*****************

                //strSQL = "DELETE FROM ACC_SAL_COLL_TARGET_ACHIEVE WHERE (COLL_ACHIEVE + COLL_TARGET + SAL_TARGET + SAL_ACHIEVE)=0 ";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();
                return "1";

            }
        }
        #endregion
        #region "Show"
        private void btnShow_Click(object sender, EventArgs e)
        {
            double dblClosing = 0;
            int intTotalArea = 0;
           
            lblHeading.Text = "Zonal Sales & Collection Analysis";
            DG.AllowUserToAddRows = true;
            DG.Rows.Clear();
            DG.Rows.Add();
            //********ist
            DG[3, 0].Style.BackColor = Color.Bisque;
            DG[4, 0].Style.BackColor = Color.Bisque;
            DG[5, 0].Style.BackColor = Color.Bisque;
            DG[6, 0].Style.BackColor = Color.Bisque;
            DG[7, 0].Style.BackColor = Color.Bisque;
            DG[8, 0].Style.BackColor = Color.Bisque;
            DG[3, 0].Value = "Sales Target";
            DG[4, 0].Value = "Sales Ach.";
            DG[5, 0].Value = "Ach.(%)";
            DG[6, 0].Value = "Coll. Target";
            DG[7, 0].Value = "Coll. Ach.";
            DG[8, 0].Value = "Ach.(%)";

            //*******2nd
            DG[10, 0].Style.BackColor = Color.Beige;
            DG[11, 0].Style.BackColor = Color.Beige;
            DG[10, 0].Value = "Sales Ach.(%)";
            DG[11, 0].Value = "Coll. Ach.(%)";
            //*********3rd
            DG[13, 0].Style.BackColor = Color.LightPink;
            DG[14, 0].Style.BackColor = Color.LightPink;
            DG[13, 0].Value = "Sales Ach.(%)";
            DG[14, 0].Value = "Coll. Ach.(%)";
            //************
            int i = 1;

            string dd = GetrptCollectionTargetAchieve(strComID, "0001", strCurrentFdate, strCurrentTdate, strCurrentDate, 0, comboBox1.SelectedValue.ToString(),
                                    Convert.ToDateTime("01-01-" + DateTime.Now.Year).ToString("dd-MM-yyyy"), Convert.ToDateTime("31-12-" + DateTime.Now.Year).ToString("dd-MM-yyyy"));
         


            lblTotalMpo.Text = Convert.ToInt64(GetTotalMPO(comboBox1.SelectedValue.ToString())).ToString();
            List<Zone> objDivision = GetDisvison(comboBox1.SelectedValue.ToString()).ToList();
            lblTotalDivision.Text = objDivision.Count.ToString();
            foreach (Zone ooDivision in objDivision)
            {
                dblClosing = dblClosing + Math.Round(dblLedgerClosingBalance(strComID, Utility.gdteFinancialYearFrom, DateTime.Now.ToString("dd-MM-yyyy"), "", ooDivision.strDivision, "", ""), 0);
                mAdditemDivision(ooDivision.strDivision, ooDivision.strMobile, ooDivision.dblSalesTarget, ooDivision.dblSaleAchv, ooDivision.dblCollTarget, ooDivision.dblCollAch, ooDivision.dblSalesTargetMonthlyTotal,
                               ooDivision.dblSaleAchvMonthlyTotal, ooDivision.dblCollTargetMonthlyTotal, ooDivision.dblCollAchMonthlyTotal, ooDivision.dblSalesTargetYearly,
                               ooDivision.dblSaleAchvYearly, ooDivision.dblCollTargetYearly, ooDivision.dblCollAchYearly,
                               ooDivision.dblSalesTargetYearlyTotal, ooDivision.dblSaleAchvYearlyTotal, ooDivision.dblCollTargetYearlyTotal, ooDivision.dblCollAchYearlyTotal);

                List<Zone> objArea = GetArea(ooDivision.strDivision).ToList();
                {
                    intTotalArea = intTotalArea + objDivision.Count;
                    foreach (Zone ooArea in objArea)
                    {
                        if (ooDivision.strDivision.ToUpper() == ooArea.strDivision.ToUpper())
                        {
                            mAdditemArea(ooArea.strArea, ooArea.strMobile, ooArea.dblSalesTarget, ooArea.dblSaleAchv, ooArea.dblCollTarget, ooArea.dblCollAch, ooArea.dblSalesTargetMonthlyTotal,
                               ooArea.dblSaleAchvMonthlyTotal, ooArea.dblCollTargetMonthlyTotal, ooArea.dblCollAchMonthlyTotal, ooArea.dblSalesTargetYearly,
                               ooArea.dblSaleAchvYearly, ooArea.dblCollTargetYearly, ooArea.dblCollAchYearly,
                               ooArea.dblSalesTargetYearlyTotal, ooArea.dblSaleAchvYearlyTotal, ooArea.dblCollTargetYearlyTotal, ooArea.dblCollAchYearlyTotal);
                        }

                    }
                }
                i += 1;


            }
            List<Zone> objZone = GetZoneTotal(comboBox1.SelectedValue.ToString()).ToList();
            if (objZone.Count > 0)
            {
                CalculateZone(objZone[0].strDivision ,objZone[0].dblSalesTarget, objZone[0].dblSaleAchv, objZone[0].dblCollTarget, objZone[0].dblCollAch, objZone[0].dblSalesTargetMonthlyTotal,
                                objZone[0].dblSaleAchvMonthlyTotal, objZone[0].dblCollTargetMonthlyTotal, objZone[0].dblCollAchMonthlyTotal, objZone[0].dblSalesTargetYearly,
                                objZone[0].dblSaleAchvYearly, objZone[0].dblCollTargetYearly, objZone[0].dblCollAchYearly,
                                objZone[0].dblSalesTargetYearlyTotal, objZone[0].dblSaleAchvYearlyTotal, objZone[0].dblCollTargetYearlyTotal, objZone[0].dblCollAchYearlyTotal, dblClosing);
            }
            label5.Text = intTotalArea.ToString();
            DG.AllowUserToAddRows = false;


            ////Thread.Sleep(20000);
            ////lblHeading.Text = "National Sales & Collection Analysis";
            ////string strName = "'EAST ZONE (SOBUR REZA PRODHAN)','NORTH ZONE (SAJIB AHMED)','SOUTH ZONE (H.M SYFULLAH)','WEST ZONE (ABDULLAH AL MARUF)'";
            ////DG.AllowUserToAddRows = true;
            ////DG.Rows.Clear();
            ////DG.Rows.Add();
            //////********ist
            ////DG[3, 0].Style.BackColor = Color.Bisque;
            ////DG[4, 0].Style.BackColor = Color.Bisque;
            ////DG[5, 0].Style.BackColor = Color.Bisque;
            ////DG[6, 0].Style.BackColor = Color.Bisque;
            ////DG[7, 0].Style.BackColor = Color.Bisque;
            ////DG[8, 0].Style.BackColor = Color.Bisque;
            ////DG[3, 0].Value = "Sales Target";
            ////DG[4, 0].Value = "Sales Ach.";
            ////DG[5, 0].Value = "Ach.(%)";
            ////DG[6, 0].Value = "Coll. Target";
            ////DG[7, 0].Value = "Coll. Ach.";
            ////DG[8, 0].Value = "Ach.(%)";

            //////*******2nd
            ////DG[10, 0].Style.BackColor = Color.Beige;
            ////DG[11, 0].Style.BackColor = Color.Beige;
            ////DG[10, 0].Value = "Sales Ach.(%)";
            ////DG[11, 0].Value = "Coll. Ach.(%)";
            //////*********3rd
            ////DG[13, 0].Style.BackColor = Color.LightPink;
            ////DG[14, 0].Style.BackColor = Color.LightPink;
            ////DG[13, 0].Value = "Sales Ach.(%)";
            ////DG[14, 0].Value = "Coll. Ach.(%)";


            ////string dd1 = GetrptCollectionZone(strComID, "0001", strCurrentFdate, strCurrentTdate, strCurrentDate, 0, strName, Convert.ToDateTime("01-01-" + DateTime.Now.Year).ToString("dd-MM-yyyy"), Convert.ToDateTime("31-12-" + DateTime.Now.Year).ToString("dd-MM-yyyy"));
            ////long lngDiv = GetTotalDivisoion1(strName);
            ////long lngArea = GetTotalArea1(strName);
            ////lblTotalMpo.Text = Convert.ToInt64(GetTotalMPO1(strName)).ToString();
            ////List<Zone> objDivision1 = GetZoneTarget().ToList();
            ////lblTotalDivision.Text = lngDiv.ToString();
            ////label5.Text = lngArea.ToString();
            ////foreach (Zone ooDivision in objDivision1)
            ////{
            ////    double dblclosing = dblClosingdues(ooDivision.strDivision);
            ////    mAdditemZone(ooDivision.strDivision, ooDivision.strMobile, ooDivision.dblSalesTarget, ooDivision.dblSaleAchv, ooDivision.dblCollTarget, ooDivision.dblCollAch, ooDivision.dblSalesTargetMonthlyTotal,
            ////                   ooDivision.dblSaleAchvMonthlyTotal, ooDivision.dblCollTargetMonthlyTotal, ooDivision.dblCollAchMonthlyTotal, ooDivision.dblSalesTargetYearly,
            ////                   ooDivision.dblSaleAchvYearly, ooDivision.dblCollTargetYearly, ooDivision.dblCollAchYearly,
            ////                   ooDivision.dblSalesTargetYearlyTotal, ooDivision.dblSaleAchvYearlyTotal, ooDivision.dblCollTargetYearlyTotal, ooDivision.dblCollAchYearlyTotal, dblclosing);


            ////    i += 1;


            ////}
           
        }
        #endregion

        private void btnShow_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDisplay2_Click(object sender, EventArgs e)
        {
            int intTotalArea = 0;
            double dblCls = 0;
            string strName = "'EAST ZONE (SOBUR REZA PRODHAN)','NORTH ZONE (SAJIB AHMED)','SOUTH ZONE (H.M SYFULLAH)','WEST ZONE (ABDULLAH AL MARUF)'";
            DG.AllowUserToAddRows = true;
            DG.Rows.Clear();

            DG.Rows.Add(1);
            
            //********ist
            DG[3, 0].Style.BackColor = Color.Bisque;
            DG[4, 0].Style.BackColor = Color.Bisque;
            DG[5, 0].Style.BackColor = Color.Bisque;
            DG[6, 0].Style.BackColor = Color.Bisque;
            DG[7, 0].Style.BackColor = Color.Bisque;
            DG[8, 0].Style.BackColor = Color.Bisque;
            DG[3, 0].Value = "Sales Target";
            DG[4, 0].Value = "Sales Ach.";
            DG[5, 0].Value = "Ach.(%)";
            DG[6, 0].Value = "Coll. Target";
            DG[7, 0].Value = "Coll. Ach.";
            DG[8, 0].Value = "Ach.(%)";

            //*******2nd
            DG[10, 0].Style.BackColor = Color.Beige;
            DG[11, 0].Style.BackColor = Color.Beige;
            DG[10, 0].Value = "Sales Ach.(%)";
            DG[11, 0].Value = "Coll. Ach.(%)";
            //*********3rd
            DG[13, 0].Style.BackColor = Color.LightPink;
            DG[14, 0].Style.BackColor = Color.LightPink;
            DG[13, 0].Value = "Sales Ach.(%)";
            DG[14, 0].Value = "Coll. Ach.(%)";
            //************
            int i = 1;


            long lngDiv = GetTotalDivisoion1(strName);
            long lngArea = GetTotalArea1(strName);
            lblTotalMpo.Text = Convert.ToInt64(GetTotalMPO1(strName)).ToString();
            List<Zone> objDivision = GetZoneTarget().ToList();
            //List<Zone> objDivision = GetZoneTotal("EAST ZONE (SOBUR REZA PRODHAN)").ToList();
            lblTotalDivision.Text = lngDiv.ToString();
            label5.Text = lngArea.ToString();
           
           
            foreach (Zone ooDivision in objDivision)
            {
               
                double dblclosing = dblClosingdues(ooDivision.strDivision);
                dblCls = dblCls + dblClosingdues(ooDivision.strDivision);
                mAdditemZone(ooDivision.strDivision, ooDivision.strMobile, ooDivision.dblSalesTarget, ooDivision.dblSaleAchv, ooDivision.dblCollTarget, ooDivision.dblCollAch, ooDivision.dblSalesTargetMonthlyTotal,
                               ooDivision.dblSaleAchvMonthlyTotal, ooDivision.dblCollTargetMonthlyTotal, ooDivision.dblCollAchMonthlyTotal, ooDivision.dblSalesTargetYearly,
                               ooDivision.dblSaleAchvYearly, ooDivision.dblCollTargetYearly, ooDivision.dblCollAchYearly,
                               ooDivision.dblSalesTargetYearlyTotal, ooDivision.dblSaleAchvYearlyTotal, ooDivision.dblCollTargetYearlyTotal, ooDivision.dblCollAchYearlyTotal, dblclosing);

                Thread.Sleep(10000);
                i += 1;


            }
            //label5.Text = intTotalArea.ToString();
            List<Zone> objZone = GetZoneTotal1(strName).ToList();
        
            if (objZone.Count > 0)
            {
                CalculateZone(objZone[0].strDivision, objZone[0].dblSalesTarget, objZone[0].dblSaleAchv, objZone[0].dblCollTarget, objZone[0].dblCollAch, objZone[0].dblSalesTargetMonthlyTotal,
                                objZone[0].dblSaleAchvMonthlyTotal, objZone[0].dblCollTargetMonthlyTotal, objZone[0].dblCollAchMonthlyTotal, objZone[0].dblSalesTargetYearly,
                                objZone[0].dblSaleAchvYearly, objZone[0].dblCollTargetYearly, objZone[0].dblCollAchYearly,
                                objZone[0].dblSalesTargetYearlyTotal, objZone[0].dblSaleAchvYearlyTotal, objZone[0].dblCollTargetYearlyTotal, objZone[0].dblCollAchYearlyTotal, dblCls);
            }
            DG.AllowUserToAddRows = false;
        }

        private void StartTimer()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            lblDatetime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
        }

        private void frmDashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utility.Kill("Dashboard");
            this.Dispose();

        }

      

      

      

       
    }
}
