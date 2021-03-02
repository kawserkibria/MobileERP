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
using JA.Modulecontrolar.JACCMS;
using System.Reflection;
using JA.Modulecontrolar.JINVMS;
using JA.Modulecontrolar.JRPT;


namespace JA.Modulecontrolar.UI.Tools.Forms
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

       
        private void upDateSIVoucher()
        {
            string strSQL = "", strString = "", strCompRefNo, strKey, strDate, strPartyname = "",strSymbol="";
            double dblNetAmount=0, dblRoundOff=0;
             int lngloop = 0;
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
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    //string strItemname = "";
                    //List<StockItem> oogrp = invms.gFillStockItemAllWithoutGodown(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "").ToList();
                    //if (oogrp.Count > 0)
                    //{
                    //    foreach (StockItem ostk in oogrp)
                    //    {
                    //        strItemname = ostk.strLocation;
                    //    }
                    //}


          
                    strSQL = "SELECT STOCKITEM_NAME FROM INV_STOCKITEM  ";
                    strSQL = strSQL + " WHERE  STOCKITEM_PRIMARY_GROUP ='Finished Goods' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strString = strString + dr["COMP_REF_NO"].ToString() + "~" + dr["VOUCHER_REF_KEY"].ToString() + "~" + dr["COMP_VOUCHER_DATE"].ToString() + "~" + dr["LEDGER_NAME"].ToString() + "|";
                        lngloop+=1;
                    }
                    dr.Close();
                    if (strString != "")
                    {
                        Prog.Value = 0;
                        string[] words = strString.Split('|');
                        Prog.Maximum = lngloop;
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('~');
                            if (ooCost[0] != "")
                            {

                                strCompRefNo = ooCost[0].ToString();
                                strKey = ooCost[1].ToString();
                                strDate = Convert.ToDateTime (ooCost[2]).ToString("dd-MM-yyyy");
                                //strLedgerName = ooCost[3].ToString();
                                //dblNetAmount = Convert.ToDouble(words[4].ToString());
                                strSQL = "SELECT LEDGER_NAME ,VOUCHER_CREDIT_AMOUNT  from ACC_VOUCHER WHERE COMP_VOUCHER_TYPE =16 and COMP_REF_NO ='" + strCompRefNo + "' and VOUCHER_TOBY ='Cr' ";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {
                                    strPartyname = dr["LEDGER_NAME"].ToString();
                                    dblNetAmount = Convert.ToDouble(dr["VOUCHER_CREDIT_AMOUNT"].ToString());
                                }
                                dr.Close();
                                strSQL = "SELECT VOUCHER_DEBIT_AMOUNT,VOUCHER_TOBY from ACC_VOUCHER WHERE COMP_VOUCHER_TYPE =16 and COMP_REF_NO ='" + strCompRefNo + "' and LEDGER_NAME ='Round Off'";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {

                                    dblRoundOff = Convert.ToDouble(dr["VOUCHER_DEBIT_AMOUNT"].ToString());
                                    strSymbol = dr["VOUCHER_TOBY"].ToString();
                                    if (strSymbol=="Dr")
                                    {
                                        dblRoundOff = dblRoundOff * -1;
                                    }
                                    
                                }
                                dr.Close();
                                strSQL = "DELETE FROM ACC_VOUCHER WHERE COMP_REF_NO='" + strCompRefNo + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                if (dblRoundOff < 0)
                                {
                                    //dblCredit = dblCredit - ((Math.Abs(dblRoundOff) + Math.Abs(dblAddAmount)) - Math.Abs(dblLessAmount));
                                    strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 1, strPartyname, "Dr", dblNetAmount, 16, "As per Details", "0001", 0, "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 2, "Sales Accounts", "Cr", dblNetAmount + Math.Abs(dblRoundOff), 16, "As per Details", "0001", 2, "", "", "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 3, "Round Off", "Dr", Math.Abs(dblRoundOff), 16, "As per Details", "0001", 2, "-", "", "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                }
                                else if (dblRoundOff > 0)
                                {
                                    //dblCredit = dblCredit - ((Math.Abs(dblRoundOff) + Math.Abs(dblAddAmount)) - Math.Abs(dblLessAmount));
                                    strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 2, "Sales Accounts", "Cr", dblNetAmount - Math.Abs(dblRoundOff), 16, "As per Details", "0001", 2, "", "", "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 1, strPartyname, "Dr", dblNetAmount, 16, "As per Details", "0001", 0, "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQL = VoucherSW.gInsertSalesVoucher(strCompRefNo, strDate, 3, "Round Off", "Cr", Math.Abs(dblRoundOff), 16, "As per Details", "0001", 2, "+", "", "", "", "", "");
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                }
                                Prog.Value += 1;
                            }

                        }
                    }

                    cmdInsert.Transaction.Commit();
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
        private void updateAccVoucher()
        {

            string strFDate = Utility.FirstDayOfMonth(Convert.ToDateTime(dteFromDate.Value)).ToString("dd-MM-yyyy");
            string strLDate = Utility.LastDayOfMonth(Convert.ToDateTime(dteFromDate.Value)).ToString("dd-MM-yyyy");

            string strSQL = "", strString = "", strItemName="";
   
            int lngloop = 0;
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
                    SqlDataReader dr11;
                    SqlDataReader dr2;
                    SqlDataReader dr3;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    Prog.Value = 0;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;



                    double dbldirectexpens = 0, dbltotalinwardamount = 0, dblOverHet = 0;

                    strSQL = "SELECT ISNULL(SUM(VOUCHER_DEBIT_AMOUNT-VOUCHER_CREDIT_AMOUNT),0) as amount FROM ACC_GROUP_VOUCHER  WHERE GR_PARENT  ='Direct Expenses' ";
                    strSQL = strSQL + "AND (COMP_VOUCHER_DATE BETWEEN ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strFDate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strLDate) + ")";
                    cmdInsert.CommandText = strSQL;
                    dr11 = cmdInsert.ExecuteReader();
                    if (dr11.Read())
                    {
                        if (dr11["amount"].ToString() != "")
                        {
                            dbldirectexpens = Convert.ToDouble(dr11["amount"].ToString());
                        }
                    }
                    dr11.Close();

                    strSQL = "SELECT  ABS(ISNULL(SUM(INV_TRAN_AMOUNT),0))AS INWARD_AMOUNT ";
                    strSQL = strSQL + "FROM INV_STOCKITEM_TRAN_QRY  ";
                    strSQL = strSQL + "WHERE (INV_DATE BETWEEN ";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(strFDate) + " ";
                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strLDate) + ")";
                    strSQL = strSQL + "AND INV_INOUT_FLAG='I' ";
                    strSQL = strSQL + "AND INV_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_FINISHED_GOODS + " ";

                    cmdInsert.CommandText = strSQL;
                    dr2 = cmdInsert.ExecuteReader();
                    if (dr2.Read())
                    {
                        if (dr2["INWARD_AMOUNT"].ToString() != "")
                        {
                            dbltotalinwardamount = Convert.ToDouble(dr2["INWARD_AMOUNT"].ToString());
                        }
                        else
                        {
                            dbltotalinwardamount = 0;
                        }
                    }
                    dr2.Close();



                    if (dbldirectexpens != 0)
                    {
                        dblOverHet = dbldirectexpens / dbltotalinwardamount;
                    }
                    else
                    {
                        dblOverHet = 0;
                    }

                         


                    strSQL = "SELECT STOCKITEM_NAME FROM INV_STOCKITEM  ";
                    strSQL = strSQL + " WHERE  STOCKITEM_PRIMARY_GROUP ='Finished Goods' ";
                   
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strString = strString + dr["STOCKITEM_NAME"].ToString() + "|";
                        lngloop += 1;
                    }
                    dr.Close();
                    if (strString != "")
                    {
                        Prog.Value = 0;
                        string[] words = strString.Split('|');
                        Prog.Maximum = lngloop;
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('~');
                            if (ooCost[0] != "")
                            {

                                strItemName = ooCost[0].ToString();



                                strSQL = "SELECT STOCKGROUP_NAME,STOCKITEM_NAME,ABS(ISNULL( SUM(INV_TRAN_QUANTITY),0)) AS INWARD_QUANTITY, ABS(ISNULL( SUM(INV_TRAN_AMOUNT),0)) AS INWARD_AMOUNT  ";
                                strSQL = strSQL + "FROM INV_STOCKITEM_TRAN_QRY ";
                                strSQL = strSQL + "WHERE (INV_DATE BETWEEN ";
                                strSQL = strSQL + " " + Utility.cvtSQLDateString(strFDate) + " ";
                                strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strLDate) + ")";
                                strSQL = strSQL + "AND STOCKITEM_NAME  = '" + strItemName + "' ";
                                //strSQL = strSQL + "AND INV_VOUCHER_TYPE <> " + (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER + " ";
                                strSQL = strSQL + "AND INV_VOUCHER_TYPE = " + (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_FINISHED_GOODS + " ";
                                strSQL = strSQL + "AND INV_INOUT_FLAG='I' GROUP BY STOCKGROUP_NAME,STOCKITEM_NAME ";
                                cmdInsert.CommandText = strSQL;
                                dr3 = cmdInsert.ExecuteReader();


                                double dblrateratio = 0, dblTotalOH = 0, dblNewOhvalue = 0, dblinwordqty = 0, dblinwValue = 0, dblpuOH = 0;
                          

                                if (dr3.Read())
                                {
                                    dblinwordqty = Convert.ToDouble(dr3["INWARD_QUANTITY"].ToString());
                                    dblinwValue = Convert.ToDouble(dr3["INWARD_AMOUNT"].ToString());
                                    //dblrateratio = Convert.ToDouble(dr3["OH"].ToString());
                                    dblTotalOH = dblinwValue * dblOverHet;
                                    dblpuOH = dblTotalOH / dblinwordqty;
                                    dblNewOhvalue = dblinwValue + dblTotalOH;
                                }

                                dr3.Close();

                                strSQL = "INSERT INTO INV_TRAN_OVERHEAD(STOCKITEM_NAME,OVERHEAD_VALUE,OH_DTATE)VALUES ";
                                strSQL = strSQL + "('" + strItemName + "'," + dblNewOhvalue + ",'" + DateTime.Now + "') ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                Prog.Value += 1;
                            }

                        }
                    }

                    cmdInsert.Transaction.Commit();
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
        private void updateAG()
        {
            string strSQL = "", strString = "", strGroupName = "",strGrParent="",strGrOneDown="",strprimary="";
            double dblLedgerOpn = 0, dblGroupDrAmount = 0, dblDr = 0,dblCr=0;;
            int lngloop = 0;
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
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    strSQL = "SELECT GR_NAME,GR_PARENT ";
                    strSQL = strSQL + "FROM ACC_LEDGERGROUP ";
                    //strSQL = strSQL + "WHERE GR_PARENT = '" + vstrGroupName + "'";
                    // strSQL = strSQL + "AND GR_GROUP <> 401 ";
                    //strSQL = strSQL + "WHERE GR_PARENT='Advance Deposit & Prepayment' ";
                    cmdInsert.CommandText = strSQL;
                    dr = cmdInsert.ExecuteReader();
                    while (dr.Read())
                    {
                        strString = strString + dr["GR_NAME"].ToString() + "|";
                        lngloop += 1;
                    }
                    dr.Close();
                    if (strString != "")
                    {
                        Prog.Value = 0;
                        string[] words = strString.Split('|');
                        Prog.Maximum = lngloop;
                        foreach (string strBill in words)
                        {
                            string[] ooCost = strBill.Split('~');
                            if (ooCost[0] != "")
                            {

                                strGroupName = ooCost[0].ToString();
                                //if (strGroupName == "Advance Deposit & Prepayment")
                                //{
                                //    MessageBox.Show("");
                                //}
                                strSQL = "select isnull(sum(LEDGER_OPENING_BALANCE),0) amnt from ACC_LEDGER_Z_D_A_GROUP_OPN  ";
                                strSQL = strSQL + "WHERE  ZONE='" + ooCost[0] + "' or division ='" + ooCost[0] + "' or Area ='" + ooCost[0] + "'";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {

                                    dblGroupDrAmount = Convert.ToDouble(dr["amnt"]);
                                    dr.Close();
                                   
                                    if (dblGroupDrAmount > 0)
                                    {
                                        dblCr = dblGroupDrAmount;
                                        dblDr = 0;
                                    }
                                    else
                                    {
                                        dblDr = 0;
                                        dblDr = dblGroupDrAmount;
                                    }

                                    dr.Close();


                                    if (dblGroupDrAmount != 0)
                                    {

                                        strSQL = "UPDATE ACC_LEDGERGROUP SET GR_OPENING_DEBIT=" + dblDr + ",";
                                        strSQL = strSQL + "GR_OPENING_CREDIT =" + dblCr + " ";
                                        strSQL = strSQL + " WHERE GR_NAME='" + ooCost[0] + "' ";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                    else
                                    {


                                        strSQL = "SELECT isnull(SUM(GR_OPENING_DEBIT),0) amnt FROM ACC_LEDGERGROUP WHERE GR_PARENT = '" + ooCost[0].ToString() + "' ";
                                        cmdInsert.CommandText = strSQL;
                                        dr = cmdInsert.ExecuteReader();
                                        if (dr.Read())
                                        {
                                            dblGroupDrAmount = Convert.ToDouble(dr["amnt"]);
                                            if (dblGroupDrAmount > 0)
                                            {
                                                dblCr = dblGroupDrAmount;
                                                dblDr = 0;
                                            }
                                            else
                                            {
                                                dblCr = 0;
                                                dblDr = dblGroupDrAmount;
                                            }
                                            dr.Close();
                                            if (dblGroupDrAmount != 0)
                                            {
                                                strSQL = "UPDATE ACC_LEDGERGROUP SET GR_OPENING_DEBIT=" + dblDr + ",";
                                                strSQL = strSQL + "GR_OPENING_CREDIT =" + dblCr + " ";
                                                strSQL = strSQL + " WHERE GR_NAME='" + ooCost[0] + "' ";
                                                cmdInsert.CommandText = strSQL;
                                                cmdInsert.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }

                                dr.Close();

                                dblGroupDrAmount = 0;
                                dblDr = 0;
                                dblCr = 0;
                                Prog.Value += 1;
                            }

                        }
                    }

                    cmdInsert.Transaction.Commit();
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
            this.Text = "Update Script";
        }

       

      

       
    
       
    }
}