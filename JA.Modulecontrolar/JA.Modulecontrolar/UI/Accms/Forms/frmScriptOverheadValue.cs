using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;
using JA.Modulecontrolar;
using Dutility;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;
using System.Reflection;



namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmScriptOverheadValue : Form
    {
        SPWOIS objWIS = new SPWOIS();
        string strComID { get; set; }
        public string strFormType { get; set; }

        public frmScriptOverheadValue()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
     
        private void updateAccVoucher()
        {

            string strAsOndate = "";
            string strFDate = Utility.FirstDayOfMonth(Convert.ToDateTime(dteFromDate.Value)).ToString("dd-MM-yyyy");
            string strLDate = Utility.LastDayOfMonth(Convert.ToDateTime(dteFromDate.Value)).ToString("dd-MM-yyyy");
            double  dblTotalOH = 0, dblNewOhvalue = 0, dblinwordqty = 0, dblinwValue = 0, dblpuOH = 0;
            string strSQL = "",  strItemName="";
            double dbldirectexpens = 0, dbltotalinwardamount = 0, dblOverHet = 0;
            
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    gcnMain.Open();
                    SqlDataReader dr;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    Prog.Value = 0;

                    cmdInsert.Connection = gcnMain;
                    strSQL = "ALTER VIEW INV_TRAN_QRY AS ";
                    strSQL = strSQL + "SELECT STOCKGROUP_NAME,STOCKITEM_NAME,SUM(INV_TRAN_QUANTITY) AS OPN_QUANTITY,";
                    strSQL = strSQL + "SUM(INV_TRAN_AMOUNT) AS OPN_AMOUNT,0 AS INWARD_QUANTITY, 0 AS INWARD_AMOUNT,";
                    strSQL = strSQL + "0 OUTWARD_QUANTITY,0 OUTWARD_SALES_AMOUNT, 0 AS OUTWARD_COST_AMOUNT  ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_TRAN_QRY ";
                    strSQL = strSQL + "WHERE (INV_DATE < " + Utility.cvtSQLDateString(strFDate) + ")  ";
                    strSQL = strSQL + "AND INV_VOUCHER_TYPE <> " + (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER + " ";
                    strSQL = strSQL + "GROUP BY STOCKGROUP_NAME,STOCKITEM_NAME ";
                    strSQL = strSQL + "Union All ";
                    strSQL = strSQL + "SELECT STOCKGROUP_NAME,STOCKITEM_NAME, 0 OPN_QUANTITY,0 OPN_AMOUNT, SUM(INV_TRAN_QUANTITY) AS INWARD_QUANTITY, SUM(INV_TRAN_AMOUNT) AS INWARD_AMOUNT, ";
                    strSQL = strSQL + "0 OUTWARD_QUANTITY, 0 OUTWARD_SALES_AMOUNT, 0 AS OUTWARD_COST_AMOUNT ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_TRAN_QRY ";
                    strSQL = strSQL + "WHERE (INV_DATE BETWEEN ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strFDate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strLDate) + ")";
                    strSQL = strSQL + "AND INV_VOUCHER_TYPE <> " + (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER + " ";
                    strSQL = strSQL + "AND INV_INOUT_FLAG='I' GROUP BY STOCKGROUP_NAME,STOCKITEM_NAME ";
                    strSQL = strSQL + "Union All ";
                    strSQL = strSQL + "SELECT STOCKGROUP_NAME,STOCKITEM_NAME, 0 OPN_QUANTITY,0 OPN_AMOUNT,0 INWARD_QUANTITY,0 INWARD_AMOUNT,";
                    strSQL = strSQL + "SUM(INV_TRAN_QUANTITY) AS OUTWARD_QUANTITY, SUM(OUTWARD_SALES_AMOUNT) AS OUTWARD_SALES_AMOUNT,SUM(OUTWARD_COST_AMOUNT) AS OUTWARD_COST_AMOUNT ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_TRAN_QRY ";
                    strSQL = strSQL + "WHERE (INV_DATE BETWEEN ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strFDate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strLDate) + ")";
                    strSQL = strSQL + "AND INV_VOUCHER_TYPE <> " + (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER + " ";
                    strSQL = strSQL + "AND INV_INOUT_FLAG='O' GROUP BY STOCKGROUP_NAME,STOCKITEM_NAME";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "ALTER VIEW INV_OPENING_TRAN_QRY AS ";
                    strSQL = strSQL + "SELECT STOCKGROUP_NAME,STOCKITEM_NAME,SUM(OPN_QUANTITY) AS INV_TRAN_QUANTITY, SUM(OPN_AMOUNT) AS INV_TRAN_AMOUNT,";
                    strSQL = strSQL + "SUM(INWARD_QUANTITY) AS INWARD_QUANTITY, SUM(INWARD_AMOUNT) AS INWARD_AMOUNT,";
                    strSQL = strSQL + "SUM(OUTWARD_QUANTITY) AS OUTWARD_QUANTITY, SUM(OUTWARD_SALES_AMOUNT) AS OUTWARD_SALES_AMOUNT,";
                    strSQL = strSQL + "SUM(OUTWARD_COST_AMOUNT) AS OUTWARD_COST_AMOUNT,SUM(OPN_QUANTITY+INWARD_QUANTITY+OUTWARD_QUANTITY) CLS , ";
                    strSQL = strSQL + "SUM(OPN_AMOUNT+INWARD_AMOUNT+OUTWARD_COST_AMOUNT) CLSAMNT  ";
                    strSQL = strSQL + "FROM INV_TRAN_QRY ";
                    strSQL = strSQL + "GROUP BY STOCKGROUP_NAME,STOCKITEM_NAME ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    strAsOndate = Utility.LastDayOfMonth(dteFromDate.Value).ToString();

                    strSQL = "DELETE FROM INV_TRAN_OVERHEAD WHERE OH_DTATE BETWEEN  " + Utility.cvtSQLDateString(strAsOndate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(strAsOndate) + " ";
                    strSQL = strSQL + " AND  STOCKITEM_NAME ='Deloba-30Cap' ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "SELECT ISNULL(SUM(VOUCHER_DEBIT_AMOUNT-VOUCHER_CREDIT_AMOUNT),0) as amount FROM ACC_GROUP_VOUCHER  WHERE GR_PARENT  ='Direct Expenses' ";
                    strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strFDate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strLDate) + ")";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr["amount"].ToString() != "")
                        {
                            dbldirectexpens = Convert.ToDouble(dr["amount"].ToString());
                        }
                    }
                    dr.Close();

                   
                    strSQL = "SELECT  ABS(ISNULL(SUM(INWARD_AMOUNT),0))AS INWARD_AMOUNT ";
                    strSQL = strSQL + "FROM INV_OPENING_TRAN_QRY  ";
                    strSQL = strSQL + "WHERE STOCKGROUP_NAME IN ('Bio-Chemic','Bio-Laid','Blank Tab','Dilution','FG-100 Group','Glublues & Sac-Lac','Herbal','Herbal (Unani)','Herbal Sample','Homoeo Comb.','Homoeo Sample','Mother Tincture','Sample Item','Santoninum 3x','Trituration Tablet','Unani (H)','Unani Patent','Unani Sample') ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    if (dr.Read())
                    {
                        if (dr["INWARD_AMOUNT"].ToString() != "")
                        {
                            dbltotalinwardamount = Convert.ToDouble(dr["INWARD_AMOUNT"].ToString());
                        }
                        else
                        {
                            dbltotalinwardamount = 0;
                        }
                    }
                    dr.Close();



                    if (dbldirectexpens != 0)
                    {
                        dblOverHet = dbldirectexpens / dbltotalinwardamount;
                    }
                    else
                    {
                        dblOverHet = 0;
                    }

                    DataTable dt = new DataTable();
                    strSQL = "SELECT STOCKITEM_NAME FROM INV_STOCKITEM  ";
                    strSQL = strSQL + " WHERE  STOCKITEM_PRIMARY_GROUP ='Finished Goods' ";
                    strSQL = strSQL + " AND  STOCKITEM_NAME ='Deloba-30Cap' ";
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(strSQL, gcnMain);
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Prog.Value = 0;
                        Prog.Maximum = dt.Rows.Count;
                        foreach (DataRow row in dt.Rows)
                        {

                            strItemName = row["STOCKITEM_NAME"].ToString();
                            strSQL = "SELECT STOCKGROUP_NAME,STOCKITEM_NAME,ABS(ISNULL( SUM(INV_TRAN_QUANTITY),0)) AS INWARD_QUANTITY, ABS(ISNULL( SUM(INV_TRAN_AMOUNT),0)) AS INWARD_AMOUNT  ";
                            strSQL = strSQL + "FROM INV_STOCKITEM_TRAN_QRY ";
                            strSQL = strSQL + "WHERE (INV_DATE BETWEEN ";
                            strSQL = strSQL + " " + Utility.cvtSQLDateString(strFDate) + " ";
                            strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strLDate) + ")";
                            strSQL = strSQL + "AND STOCKITEM_NAME  = '" + strItemName + "' ";
                            //strSQL = strSQL + "AND INV_VOUCHER_TYPE <> " + (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER + " ";
                            strSQL = strSQL + "AND INV_VOUCHER_TYPE IN (27,29) ";
                            strSQL = strSQL + "AND INV_INOUT_FLAG='I' GROUP BY STOCKGROUP_NAME,STOCKITEM_NAME ";
                            cmdInsert.CommandText = strSQL;
                            dr = cmdInsert.ExecuteReader();
                            if (dr.Read())
                            {
                                dblinwordqty = Convert.ToDouble(dr["INWARD_QUANTITY"].ToString());
                                dblinwValue = Convert.ToDouble(dr["INWARD_AMOUNT"].ToString());
                                dblTotalOH = dblinwValue * dblOverHet;
                                dblpuOH = dblTotalOH / dblinwordqty;
                                dblNewOhvalue = dblinwValue + dblTotalOH;
                            }

                            dr.Close();
                            myTrans = gcnMain.BeginTransaction();
                            cmdInsert.Transaction = myTrans;
                            strSQL = "INSERT INTO INV_TRAN_OVERHEAD(STOCKITEM_NAME,OVERHEAD_VALUE,OH_DTATE,OVERHEAD_RATE)VALUES ";
                            strSQL = strSQL + "('" + strItemName + "'," + dblNewOhvalue + "," + Utility.cvtSQLDateString(strAsOndate) + "," + dblTotalOH + ") ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            cmdInsert.Transaction.Commit();
                            strItemName = "";
                            dblNewOhvalue = 0;
                            dblTotalOH = 0;
                            dblinwValue = 0;
                            dblinwordqty = 0;
                            Prog.Value += 1;
                           

                        }
                    }

                  
                    gcnMain.Close();
                    cmdInsert.Dispose();
                    MessageBox.Show("Ok");
                    this.Dispose();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    


        private void btnOk_Click(object sender, EventArgs e)
        {

            updateAccVoucher();
          
        }

        private void frmScriptOverheadValue_Load(object sender, EventArgs e)
        {
            this.Text = "Overhead Generation";
            dteFromDate.Text = Utility.LastDayOfMonth(dteFromDate.Value).ToString();
        }

       

      

       
    
       
    }
}