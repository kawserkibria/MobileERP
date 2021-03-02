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
using System.Linq;
using JA.Modulecontrolar.JINVMS;
using JA.Modulecontrolar.UI.Sales.Forms;


namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmUpdateAVG : Form
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        string strComID { get; set; }
        public string strFormType { get; set; }

        public frmUpdateAVG()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            //this.lstLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstLeft_KeyDown);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLeft.SelectedItem != null)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex - 1;

                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLeft.Items.Count - 1 > lstLeft.SelectedIndex)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex+1;

                }
            }
        }
        private void lstLeft_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }
        }

        private void btnLeftSingle_Click(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight.SelectedItem.ToString());
                lstRight.Items.Remove(lstRight.SelectedItem.ToString());
            }
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstLeft.Items.Count; i++)
            {
                string strItem = lstLeft.Items[i].ToString().TrimStart();
                lstRight.Items.Add(strItem);
            }

            lstLeft.Items.Clear();

        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                string strItem = lstRight.Items[i].ToString().TrimStart();
                lstLeft.Items.Add(strItem);
            }
            lstRight.Items.Clear();
        }
        private void mLaodItem()
        {
            long lngRow = 0;
            List<StockItem> oogrp;
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            if (chkFGItem.Checked)
            {
                oogrp = invms.gFillStockItemAllWithoutGodown(strComID, false, "","F").ToList();
            }
            else if (chkDilution.Checked)
            {
                oogrp = invms.gFillStockItemAllWithoutGodown(strComID, false, "", "D").ToList();
            }
            //else if (chkdilutionFGOpn.Checked)
            //{
            //    oogrp = invms.gFillStockItemAllWithoutGodown(strComID, false, "", "D").ToList();
            //}
            else
            {
                oogrp = invms.gFillStockItemAllWithoutGodown(strComID, false, "","N").ToList();
            }
            
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemName);
                    lngRow += 1;
                }
                lblNetTotal.Text = "Total Item:" + lngRow.ToString();
            }
        }
        private void mCalculateFGOpening()
        {
            string strItemName = "", strmsg = "", strSQL = "";
            int intCount = 1, intloop = 1, intloop1 = 1;
            string strdate = "", strRefNo = "", strUOm = "";

            double dblDilutionQnty = 0, dblRate = 0, dblAmount = 0;

            string strBillKey = "";
            SqlDataReader dr;
            SqlCommand cmdupdate = new SqlCommand();

            progressBar1.Minimum = 0;
            lblCount.Text = "0";
            lblNo.Text = "0";
            lblCount.Text = "Total Item: " + lstRight.Items.Count.ToString();

            //progressBar1.Step = 1;
            lblCount.Refresh();

            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                //for (int intRow = 0; intRow < lstRight.Items.Count; intRow++)
                //{

                //intCheck = 0;



                //strItemName = lstRight.Items[intRow].ToString();
                progressBar1.Refresh();
                cmdupdate.Connection = gcnMain;
                DataTable dt = new DataTable();
                //*************Dilution


                strSQL = "SELECT T.STOCKITEM_NAME,T.COMP_VOUCHER_DATE,I.STOCKITEM_BASEUNITS,  SUM(BILL_QUANTITY) AS BILL_QUANTITY, SUM(BILL_QUANTITY) * 13.64 AS AMNT ";
                strSQL = strSQL + " FROM ACC_BILL_TRAN  T,INV_STOCKITEM I ";
                strSQL = strSQL + "WHERE T.STOCKITEM_NAME=I.STOCKITEM_NAME   ";
                strSQL = strSQL + "AND I.STOCKGROUP_NAME in ('Dilution')  AND T.COMP_VOUCHER_TYPE  =16  AND T.GODOWNS_NAME ='Main Location' ";
                strSQL = strSQL + "AND (T.COMP_VOUCHER_DATE  BETWEEN  convert(datetime,'01-01-2020',103) and convert(datetime,'31-10-2020',103)) ";
                strSQL = strSQL + "GROUP BY T.STOCKITEM_NAME,T.COMP_VOUCHER_DATE,I.STOCKITEM_BASEUNITS  ";

                DataSet dsNEW = new DataSet();
                SqlDataAdapter daNEW = new SqlDataAdapter(strSQL, gcnMain);
                daNEW.Fill(dsNEW);
                dt = dsNEW.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    progressBar1.Maximum = dt.Rows.Count;
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            SqlTransaction myTrans;
                            myTrans = gcnMain.BeginTransaction();
                            cmdupdate.Transaction = myTrans;

                            strItemName = row["STOCKITEM_NAME"].ToString();
                            strdate = row["COMP_VOUCHER_DATE"].ToString();
                            dblDilutionQnty = Utility.Val(row["BILL_QUANTITY"].ToString());
                            dblRate = 13.64;
                            dblAmount = Utility.Val(row["AMNT"].ToString());
                            strUOm = row["STOCKITEM_BASEUNITS"].ToString();
                            if (intloop > 20)
                            {
                                intloop1 +=1;
                                intloop = 1;
                            }
                            if (intloop ==1)
                            {
                                strRefNo = "MI00010000" + intloop1;
                                strSQL = VoucherSW.gInsertmasterNew(strRefNo, "0001", 27, strdate, 0,
                                                  "For Dilution Production for the month of 01-01-2020 to 31-10-2020 ", "", 0, "", "0", 0);
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                            }

                            strBillKey = strRefNo + intloop.ToString().PadLeft(4, '0');
                            strSQL = VoucherSW.mInsertTranInward(strBillKey, intloop1, strRefNo, strItemName, 27,
                                                                       strdate, dblDilutionQnty, dblRate, "Main Location", dblAmount, "I",
                                                                       "0001", "", "", strUOm, strUOm, "", 0, 0);
                            cmdupdate.CommandText = strSQL;
                            cmdupdate.ExecuteNonQuery();
                            cmdupdate.Transaction.Commit();
                            intloop += 1;
                            //intloop1 += 1;
                            strBillKey = "";
                            dblAmount = 0;
                            progressBar1.Value += 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(intloop1.ToString());
                        }
                        
                    }

                }

                //return;
                dt.Rows.Clear();
                strItemName = "";
                //progressBar1.Value = 0;
                ////strSQL = "SELECT ISNULL(sum(ACC_BILL_TRAN.BILL_QUANTITY),0) BILL_QUANTITY FROM ACC_BILL_TRAN ,INV_STOCKITEM ";
                ////strSQL = strSQL + "WHERE INV_STOCKITEM.STOCKITEM_NAME =ACC_BILL_TRAN.STOCKITEM_NAME AND INV_STOCKITEM.STOCKGROUP_NAME ='Dilution' and ACC_BILL_TRAN.COMP_VOUCHER_TYPE =16 ";
                ////strSQL = strSQL + "and INV_STOCKITEM.STOCKITEM_NAME ='" + strItemName.Replace("'", "''") + "' ";
                ////strSQL = strSQL + " and ACC_BILL_TRAN.GODOWNS_NAME ='Main Location' ";


                //strSQL = "SELECT T.INV_TRAN_KEY,  I.STOCKGROUP_NAME,T.STOCKITEM_NAME, ABS(SUM(T.INV_TRAN_QUANTITY)) AS OPN_QUANTITY,(ABS(SUM(T.INV_TRAN_AMOUNT ))/ABS(SUM(T.INV_TRAN_QUANTITY ))) RATE,ABS(SUM(T.INV_TRAN_AMOUNT )) INV_TRAN_AMOUNT";
                //strSQL = strSQL + "FROM INV_TRAN T,INV_STOCKITEM I ";
                //strSQL = strSQL + "WHERE T.STOCKITEM_NAME=I.STOCKITEM_NAME ";
                //strSQL = strSQL + "AND I.STOCKGROUP_NAME in ('Dilution')  AND T.INV_VOUCHER_TYPE =0  AND T.GODOWNS_NAME ='Main Location' ";
                //strSQL = strSQL + "GROUP BY T.INV_TRAN_KEY,I.STOCKGROUP_NAME,T.STOCKITEM_NAME   HAVING ABS(SUM(INV_TRAN_QUANTITY)) > 0  ";

                //DataSet ds = new DataSet();
                //SqlDataAdapter da = new SqlDataAdapter(strSQL, gcnMain);
                //da.Fill(ds);
                //dt = ds.Tables[0];
                //if (dt.Rows.Count > 0)
                //{
                //    progressBar1.Maximum = dt.Rows.Count;
                //    foreach (DataRow row in dt.Rows)
                //    {
                //        SqlTransaction myTrans;
                //        myTrans = gcnMain.BeginTransaction();
                //        cmdupdate.Transaction = myTrans;
                //        strItemName = row["STOCKITEM_NAME"].ToString();
                //        dblDilutionQnty = Utility.Val(row["OPN_QUANTITY"].ToString());
                //        dblRate = Utility.Val(row["RATE"].ToString());
                //        dblAmount = Utility.Val(row["INV_TRAN_AMOUNT"].ToString());

                //        strSQL = "UPDATE INV_TRAN SET ";
                //        strSQL = strSQL + "INV_TRAN_QUANTITY= 0 ";
                //        strSQL = strSQL + ",INV_TRAN_RATE=0 ";
                //        strSQL = strSQL + ",INV_TRAN_RATE=0 ";
                //        strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                //        strSQL = strSQL + "AND  INV_VOUCHER_TYPE= 0 ";
                //        strSQL = strSQL + "AND  INV_INOUT_FLAG IS NULL";
                //        strSQL = strSQL + " AND GODOWNS_NAME ='Main Location' ";
                //        strSQL = strSQL + "AND INV_TRAN_KEY = '" + row["INV_TRAN_KEY"].ToString() + "' ";
                //        cmdupdate.CommandText = strSQL;
                //        cmdupdate.ExecuteNonQuery();
                //        strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_BALANCE=" + dblDilutionQnty + " ";
                //        strSQL = strSQL + ",STOCKITEM_OPENING_RATE=0 ";
                //        strSQL = strSQL + ",STOCKITEM_OPENING_VALUE=0 ";
                //        strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                //        cmdupdate.CommandText = strSQL;
                //        cmdupdate.ExecuteNonQuery();




                //        dblDilutionQnty = 0;
                //        dblRate = 0;
                //        dblAmount = 0;
                //        progressBar1.Value += 1;
                //        cmdupdate.Transaction.Commit();
                //    }
                //}
                //dt.Rows.Clear();

                //progressBar1.PerformStep();
                //progressBar1.Refresh();
                //progressBar1.Value = intCount;
                //lblNo.Text = "Records Read = " + lblCount.Text + "/" + intCount;
                lblNo.Refresh();
                intCount += 1;
                strmsg = "1";
            }

            //}



            if (strmsg == "1")
            {
                MessageBox.Show("OK");
            }
        }

        
        private void mCalculateFGold()
        {
            string strItemName = "", strmsg = "", strSQL = "";
            int intFGGroup = 0,intCount=1;

            double dblCostRate = 0,
                                dblDilutionValue = 0, dblDilutionQnty = 0, dblDilutionRate = 0, dblProductionQnty = 0,
                                dblInvoiceValue = 0, dblconsumtpValue = 0, dblCostValue = 0, dblWeight = 0, dblInvoiceRate = 0;

            SqlDataReader dr;
            SqlCommand cmdupdate = new SqlCommand();

            progressBar1.Minimum = 0;
            lblCount.Text = "0";
            lblNo.Text = "0";
            lblCount.Text = "Total Item: " + lstRight.Items.Count.ToString();
            progressBar1.Maximum = lstRight.Items.Count;
            //progressBar1.Step = 1;
            lblCount.Refresh();

            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                for (int intRow = 0; intRow < lstRight.Items.Count; intRow++)
                {

                    //intCheck = 0;
                    dblCostRate = 0;


                    strItemName = lstRight.Items[intRow].ToString();
                    progressBar1.Refresh();
                    cmdupdate.Connection = gcnMain;
                    DataTable dt = new DataTable();
                    //*************Dilution
                    strSQL = "SELECT ISNULL(SUM(INV_TRAN.OUTWARD_SALES_AMOUNT),0) AS PRODUCTION_vALUE FROM INV_STOCKITEM ,INV_TRAN WHERE INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME AND INV_TRAN.INV_VOUCHER_TYPE =26 ";
                    strSQL = strSQL + "AND INV_TRAN.GODOWNS_NAME in ('Dilution Section') ";
                    cmdupdate.CommandText = strSQL;
                    dr = cmdupdate.ExecuteReader();
                    if (dr.Read())
                    {
                        dblDilutionValue = Convert.ToDouble(dr["PRODUCTION_vALUE"]);
                    }
                    dr.Close();

                    strSQL = "SELECT ISNULL(SUM(ACC_BILL_TRAN.BILL_QUANTITY),0) AS BILL_QUANTITY ";
                    strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = ACC_BILL_TRAN.STOCKITEM_NAME AND ACC_BILL_TRAN.COMP_VOUCHER_TYPE =16 AND INV_STOCKGROUP.FG_STATUS=1 ";
                    cmdupdate.CommandText = strSQL;
                    dr = cmdupdate.ExecuteReader();
                    if (dr.Read())
                    {
                        dblDilutionQnty = Convert.ToDouble(dr["BILL_QUANTITY"]);
                    }
                    dr.Close();
                    //end
                    strSQL = "SELECT ISNULL(SUM(INV_TRAN.OUTWARD_SALES_AMOUNT),0) AS CONSUMPTION_VALUE FROM INV_STOCKITEM ,INV_TRAN WHERE INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME AND INV_TRAN.INV_VOUCHER_TYPE =26 ";
                    strSQL = strSQL + "AND INV_TRAN.GODOWNS_NAME NOT IN ('Dilution Section') ";
                    strSQL = strSQL + "AND INV_TRAN.INV_INOUT_FLAG='O' ";
                    strSQL = strSQL + " AND INV_STOCKITEM.MATERIAL_TYPE is not null ";
                    cmdupdate.CommandText = strSQL;
                    dr = cmdupdate.ExecuteReader();
                    if (dr.Read())
                    {
                        dblconsumtpValue = Convert.ToDouble(dr["CONSUMPTION_VALUE"]);
                    }
                    dr.Close();

                    strSQL = "SELECT ISNULL(SUM(ACC_BILL_TRAN.BILL_NET_AMOUNT),0) AS INVOICEVALUE ";
                    strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = ACC_BILL_TRAN.STOCKITEM_NAME AND ACC_BILL_TRAN.COMP_VOUCHER_TYPE =16 AND INV_STOCKGROUP.FG_STATUS <> 1 ";
                    //strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                    cmdupdate.CommandText = strSQL;
                    dr = cmdupdate.ExecuteReader();
                    if (dr.Read())
                    {
                        dblInvoiceValue = Convert.ToDouble(dr["INVOICEVALUE"]);
                    }
                    dr.Close();
                    dblWeight = Math.Round(dblconsumtpValue / dblInvoiceValue, 9);
                    strSQL = "SELECT INV_STOCKGROUP.FG_STATUS ";
                    strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME ";
                    strSQL = strSQL + "WHERE INV_STOCKITEM.STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                    strSQL = strSQL + "GROUP BY INV_STOCKGROUP.FG_STATUS, INV_STOCKITEM.STOCKITEM_NAME ";
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(strSQL, gcnMain);
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            SqlTransaction myTrans;
                            myTrans = gcnMain.BeginTransaction();
                            cmdupdate.Transaction = myTrans;
                            intFGGroup = Convert.ToInt16(row["FG_STATUS"].ToString());
                            if (intFGGroup == 1)
                            {
                                if (dblDilutionValue != 0 && dblDilutionQnty != 0)
                                {
                                    dblDilutionRate = Math.Abs(Math.Round(dblDilutionValue / dblDilutionQnty, 2));
                                }
                                else
                                {
                                    dblDilutionRate = 0;
                                }
                                strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_RATE=" + Math.Abs(dblDilutionRate) + " ";
                                strSQL = strSQL + ",STOCKITEM_OPENING_VALUE=STOCKITEM_OPENING_BALANCE * " + Math.Abs(dblDilutionRate) + " ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                strSQL = strSQL + "AND STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                strSQL = strSQL + "AND STOCKITEM_OPENING_BALANCE <> 0 ";
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                                strSQL = "UPDATE INV_TRAN SET ";
                                strSQL = strSQL + "INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + Math.Abs(dblDilutionRate) + " ";
                                strSQL = strSQL + ",INV_TRAN_RATE=" + dblDilutionRate + " ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                strSQL = strSQL + "AND  INV_VOUCHER_TYPE= 0 ";
                                strSQL = strSQL + "AND  INV_INOUT_FLAG IS NULL";
                                //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                                strSQL = "UPDATE INV_TRAN SET INWARD_AMOUNT=INV_TRAN_QUANTITY * " + Math.Abs(dblDilutionRate) + " ";
                                strSQL = strSQL + ",INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + dblDilutionRate + " ";
                                strSQL = strSQL + ",INV_TRAN_RATE=" + dblDilutionRate + " ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                strSQL = strSQL + "AND  INV_VOUCHER_TYPE NOT IN(33) ";
                                strSQL = strSQL + "AND  INV_INOUT_FLAG='I'";
                                //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                                strSQL = "UPDATE INV_TRAN SET ";
                                strSQL = strSQL + "OUTWARD_SALES_AMOUNT=OUTWARD_QUANTITY * " + Math.Abs(dblDilutionRate) + " ";
                                strSQL = strSQL + ",OUTWARD_COST_AMOUNT=OUTWARD_QUANTITY * " + Math.Abs(dblDilutionRate) + " ";
                                strSQL = strSQL + ",INV_TRAN_AMOUNT=OUTWARD_QUANTITY  * " + Math.Abs(dblDilutionRate) + " ";
                                strSQL = strSQL + ",INV_TRAN_RATE=" + Math.Abs(dblDilutionRate) + " ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                strSQL = strSQL + "AND  INV_INOUT_FLAG='O'";
                                //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();

                            }
                            else
                            {
                                //*************Not Dilution

                                strSQL = "SELECT ISNULL(SUM(INV_TRAN.INV_TRAN_QUANTITY),0) AS FGQNTY ";
                                strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                                strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME INNER JOIN ";
                                strSQL = strSQL + "INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME AND INV_TRAN.INV_VOUCHER_TYPE IN (27,29) AND INV_STOCKGROUP.FG_STATUS <> 1 ";
                                strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                cmdupdate.CommandText = strSQL;
                                dr = cmdupdate.ExecuteReader();
                                if (dr.Read())
                                {
                                    dblProductionQnty = Convert.ToDouble(dr["FGQNTY"]);
                                }
                                dr.Close();

                                strSQL = "SELECT ISNULL(SUM(ACC_BILL_TRAN.BILL_NET_AMOUNT),0) AS INVOICEVALUE ";
                                strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                                strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME INNER JOIN ";
                                strSQL = strSQL + "ACC_BILL_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = ACC_BILL_TRAN.STOCKITEM_NAME AND ACC_BILL_TRAN.COMP_VOUCHER_TYPE =16 AND INV_STOCKGROUP.FG_STATUS <> 1 ";
                                strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                cmdupdate.CommandText = strSQL;
                                dr = cmdupdate.ExecuteReader();
                                if (dr.Read())
                                {
                                    dblInvoiceValue = Convert.ToDouble(dr["INVOICEVALUE"]);
                                }
                                dr.Close();

                                if (dblProductionQnty != 0 && dblInvoiceValue != 0)
                                {
                                    dblInvoiceRate = Math.Abs(Math.Round(dblInvoiceValue / dblProductionQnty, 2));
                                }
                                else
                                {
                                    dblInvoiceRate = 0;
                                }



                                dblCostValue = Math.Round((dblInvoiceValue * dblWeight), 4);
                                if (dblCostValue != 0 && dblProductionQnty != 0)
                                {
                                    dblCostRate = Math.Abs(Math.Round(dblCostValue / dblProductionQnty, 2));
                                }
                                else
                                {
                                    dblCostRate = 0;
                                }
                                if (dblCostRate != 0)
                                {
                                    strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_RATE=" + Math.Abs(dblCostRate) + " ";
                                    strSQL = strSQL + ",STOCKITEM_OPENING_VALUE=STOCKITEM_OPENING_BALANCE * " + Math.Abs(dblCostRate) + " ";
                                    strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                    //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                    strSQL = strSQL + "AND STOCKITEM_OPENING_BALANCE <> 0 ";
                                    cmdupdate.CommandText = strSQL;
                                    cmdupdate.ExecuteNonQuery();
                                    strSQL = "UPDATE INV_TRAN SET ";
                                    strSQL = strSQL + "INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                    strSQL = strSQL + ",INV_TRAN_RATE=" + Math.Abs(dblCostRate) + " ";
                                    strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                    strSQL = strSQL + "AND  INV_VOUCHER_TYPE= 0 ";
                                    strSQL = strSQL + "AND  INV_INOUT_FLAG IS NULL";
                                    //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                    cmdupdate.CommandText = strSQL;
                                    cmdupdate.ExecuteNonQuery();
                                    strSQL = "UPDATE INV_TRAN SET INWARD_AMOUNT=INV_TRAN_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                    strSQL = strSQL + ",INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                    strSQL = strSQL + ",INV_TRAN_RATE=" + Math.Abs(dblCostRate) + " ";
                                    strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                    strSQL = strSQL + "AND  INV_VOUCHER_TYPE NOT IN(33) ";
                                    strSQL = strSQL + "AND  INV_INOUT_FLAG='I'";
                                    //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                    cmdupdate.CommandText = strSQL;
                                    cmdupdate.ExecuteNonQuery();
                                    strSQL = "UPDATE INV_TRAN SET ";
                                    strSQL = strSQL + "OUTWARD_SALES_AMOUNT=OUTWARD_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                    strSQL = strSQL + ",OUTWARD_COST_AMOUNT=OUTWARD_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                    strSQL = strSQL + ",INV_TRAN_AMOUNT=OUTWARD_QUANTITY  * " + Math.Abs(dblCostRate) + " ";
                                    strSQL = strSQL + ",INV_TRAN_RATE=" + Math.Abs(dblCostRate) + " ";
                                    strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                    strSQL = strSQL + "AND  INV_INOUT_FLAG='O'";
                                    //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                    cmdupdate.CommandText = strSQL;
                                    cmdupdate.ExecuteNonQuery();
                                }
                                dblCostRate = 0;
                                dblInvoiceRate = 0;
                                dblInvoiceValue = 0;
                                dblProductionQnty = 0;
                                dblDilutionRate = 0;
                            }
                            cmdupdate.Transaction.Commit();
                        }
                    }

                    progressBar1.PerformStep();
                    progressBar1.Refresh();
                    progressBar1.Value = intCount;
                    lblNo.Text = "Records Read = " + lblCount.Text + "/" + intCount;
                    lblNo.Refresh();
                    intCount += 1;
                    strmsg = "1";
                }

            }



            if (strmsg == "1")
            {
                MessageBox.Show("OK");
            }
        }
        private void mCalculateFG()
        {
            string strItemName = "", strmsg = "", strSQL = "";
            int intFGGroup = 0, intCount = 1;

            double dblCostRate = 0,
                                dblDilutionValue = 0, dblDilutionQnty = 0, dblDilutionRate = 0, dblProductionQnty = 0,
                                dblInvoiceValue = 0, dblconsumtpValue = 0, dblCostValue = 0, dblWeight = 0, dblInvoiceRate = 0;

            SqlDataReader dr;
            SqlCommand cmdupdate = new SqlCommand();

            progressBar1.Minimum = 0;
            lblCount.Text = "0";
            lblNo.Text = "0";
            lblCount.Text = "Total Item: " + lstRight.Items.Count.ToString();
            progressBar1.Maximum = lstRight.Items.Count;
            //progressBar1.Step = 1;
            lblCount.Refresh();

            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                for (int intRow = 0; intRow < lstRight.Items.Count; intRow++)
                {

                    //intCheck = 0;
                    dblCostRate = 0;


                    strItemName = lstRight.Items[intRow].ToString();
                    progressBar1.Refresh();
                    cmdupdate.Connection = gcnMain;
                    DataTable dt = new DataTable();
                    //////*************Dilution
                    ////strSQL = "SELECT ISNULL(SUM(INV_TRAN.OUTWARD_SALES_AMOUNT),0) AS PRODUCTION_vALUE FROM INV_STOCKITEM ,INV_TRAN WHERE INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME AND INV_TRAN.INV_VOUCHER_TYPE =26 ";
                    ////strSQL = strSQL + "AND INV_TRAN.GODOWNS_NAME in ('Dilution Section') ";
                    ////cmdupdate.CommandText = strSQL;
                    ////dr = cmdupdate.ExecuteReader();
                    ////if (dr.Read())
                    ////{
                    ////    dblDilutionValue = Convert.ToDouble(dr["PRODUCTION_vALUE"]);
                    ////}
                    ////dr.Close();

                    ////strSQL = "SELECT ISNULL(SUM(ACC_BILL_TRAN.BILL_QUANTITY),0) AS BILL_QUANTITY ";
                    ////strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                    ////strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME INNER JOIN ";
                    ////strSQL = strSQL + "ACC_BILL_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = ACC_BILL_TRAN.STOCKITEM_NAME AND ACC_BILL_TRAN.COMP_VOUCHER_TYPE =16 AND INV_STOCKGROUP.FG_STATUS=1 ";
                    ////cmdupdate.CommandText = strSQL;
                    ////dr = cmdupdate.ExecuteReader();
                    ////if (dr.Read())
                    ////{
                    ////    dblDilutionQnty = Convert.ToDouble(dr["BILL_QUANTITY"]);
                    ////}
                    ////dr.Close();
                    //////end
                    ////strSQL = "SELECT ISNULL(SUM(INV_TRAN.OUTWARD_SALES_AMOUNT),0) AS CONSUMPTION_VALUE FROM INV_STOCKITEM ,INV_TRAN WHERE INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME AND INV_TRAN.INV_VOUCHER_TYPE =26 ";
                    ////strSQL = strSQL + "AND INV_TRAN.GODOWNS_NAME NOT IN ('Dilution Section') ";
                    ////strSQL = strSQL + "AND INV_TRAN.INV_INOUT_FLAG='O' ";
                    ////strSQL = strSQL + " AND INV_STOCKITEM.MATERIAL_TYPE is not null ";
                    ////cmdupdate.CommandText = strSQL;
                    ////dr = cmdupdate.ExecuteReader();
                    ////if (dr.Read())
                    ////{
                    ////    dblconsumtpValue = Convert.ToDouble(dr["CONSUMPTION_VALUE"]);
                    ////}
                    ////dr.Close();

                    ////strSQL = "SELECT ISNULL(SUM(ACC_BILL_TRAN.BILL_NET_AMOUNT),0) AS INVOICEVALUE ";
                    ////strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                    ////strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME INNER JOIN ";
                    ////strSQL = strSQL + "ACC_BILL_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = ACC_BILL_TRAN.STOCKITEM_NAME AND ACC_BILL_TRAN.COMP_VOUCHER_TYPE =16 AND INV_STOCKGROUP.FG_STATUS <> 1 ";
                    //////strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                    ////cmdupdate.CommandText = strSQL;
                    ////dr = cmdupdate.ExecuteReader();
                    ////if (dr.Read())
                    ////{
                    ////    dblInvoiceValue = Convert.ToDouble(dr["INVOICEVALUE"]);
                    ////}
                    ////dr.Close();
                    ////dblWeight = Math.Round(dblconsumtpValue / dblInvoiceValue, 9);
                    strSQL = "SELECT f1,f2 from FGCostRate ";
                    strSQL = strSQL + "WHERE f1='" + strItemName.Replace("'", "''") + "' ";
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(strSQL, gcnMain);
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            SqlTransaction myTrans;
                            myTrans = gcnMain.BeginTransaction();
                            cmdupdate.Transaction = myTrans;
                            //intFGGroup = Convert.ToInt16(row["FG_STATUS"].ToString());
                            dblCostRate = Convert.ToDouble(row["f2"].ToString());

                            //*************Not Dilution

                            //strSQL = "SELECT ISNULL(SUM(INV_TRAN.INV_TRAN_QUANTITY),0) AS FGQNTY ";
                            //strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                            //strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME INNER JOIN ";
                            //strSQL = strSQL + "INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME AND INV_TRAN.INV_VOUCHER_TYPE IN (27,29) AND INV_STOCKGROUP.FG_STATUS <> 1 ";
                            //strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                            //cmdupdate.CommandText = strSQL;
                            //dr = cmdupdate.ExecuteReader();
                            //if (dr.Read())
                            //{
                            //    dblProductionQnty = Convert.ToDouble(dr["FGQNTY"]);
                            //}
                            //dr.Close();

                            //strSQL = "SELECT ISNULL(SUM(ACC_BILL_TRAN.BILL_NET_AMOUNT),0) AS INVOICEVALUE ";
                            //strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                            //strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME INNER JOIN ";
                            //strSQL = strSQL + "ACC_BILL_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = ACC_BILL_TRAN.STOCKITEM_NAME AND ACC_BILL_TRAN.COMP_VOUCHER_TYPE =16 AND INV_STOCKGROUP.FG_STATUS <> 1 ";
                            //strSQL = strSQL + "AND INV_STOCKITEM.STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                            //cmdupdate.CommandText = strSQL;
                            //dr = cmdupdate.ExecuteReader();
                            //if (dr.Read())
                            //{
                            //    dblInvoiceValue = Convert.ToDouble(dr["INVOICEVALUE"]);
                            //}
                            //dr.Close();

                            //if (dblProductionQnty != 0 && dblInvoiceValue != 0)
                            //{
                            //    dblInvoiceRate = Math.Abs(Math.Round(dblInvoiceValue / dblProductionQnty, 2));
                            //}
                            //else
                            //{
                            //    dblInvoiceRate = 0;
                            //}



                            //dblCostValue = Math.Round((dblInvoiceValue * dblWeight), 4);
                            //if (dblCostValue != 0 && dblProductionQnty != 0)
                            //{
                            //    dblCostRate = Math.Abs(Math.Round(dblCostValue / dblProductionQnty, 2));
                            //}
                            //else
                            //{
                            //    dblCostRate = 0;
                            //}
                            if (dblCostRate != 0)
                            {
                                strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_RATE=" + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + ",STOCKITEM_OPENING_VALUE=STOCKITEM_OPENING_BALANCE * " + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                strSQL = strSQL + "AND STOCKITEM_OPENING_BALANCE <> 0 ";
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                                strSQL = "UPDATE INV_TRAN SET ";
                                strSQL = strSQL + "INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + ",INV_TRAN_RATE=" + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                strSQL = strSQL + "AND  INV_VOUCHER_TYPE= 0 ";
                                strSQL = strSQL + "AND  INV_INOUT_FLAG IS NULL ";
                                strSQL = strSQL + "AND INV_TRAN_QUANTITY <> 0 ";
                                //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                                strSQL = "UPDATE INV_TRAN SET INWARD_AMOUNT=INV_TRAN_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + ",INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + ",INV_TRAN_RATE=" + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                strSQL = strSQL + "AND  INV_VOUCHER_TYPE NOT IN(33) ";
                                strSQL = strSQL + "AND  INV_INOUT_FLAG='I' ";
                                strSQL = strSQL + "AND INV_TRAN_QUANTITY <> 0 ";
                                //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                                strSQL = "UPDATE INV_TRAN SET ";
                                strSQL = strSQL + "OUTWARD_SALES_AMOUNT=OUTWARD_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + ",OUTWARD_COST_AMOUNT=OUTWARD_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + ",INV_TRAN_AMOUNT=OUTWARD_QUANTITY  * " + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + ",INV_TRAN_RATE=" + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                strSQL = strSQL + "AND  INV_INOUT_FLAG='O' ";
                                strSQL = strSQL + "AND INV_TRAN_QUANTITY <> 0 ";
                                //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                            }
                            dblCostRate = 0;
                            dblInvoiceRate = 0;
                            dblInvoiceValue = 0;
                            dblProductionQnty = 0;
                            dblDilutionRate = 0;
                            cmdupdate.Transaction.Commit();
                        }
                        
                    }


                    progressBar1.PerformStep();
                    progressBar1.Refresh();
                    progressBar1.Value = intCount;
                    lblNo.Text = "Records Read = " + lblCount.Text + "/" + intCount;
                    lblNo.Refresh();
                    intCount += 1;
                    strmsg = "1";
                }

            }



            if (strmsg == "1")
            {
                MessageBox.Show("OK");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string strItemName = "", strmsg = "", strSQL = "";
            double dblOpnAvgRate = 0;
            double dblRunningQty = 0, dblClsAmnt = 0, dblCostRate = 0, dblTranQty = 0, dblInwardAmnt = 0, dblCostQty = 0;
            int lngVoucherType = 0;
            long lngInvSerialNo = 0;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            int intCheck = 0;
            try
            {
                if (chkFGItem.Checked == true)
                {
                    //MessageBox.Show("Cannot Generate Process for FG", "Under Constuction");
                    mCalculateFG();
                    return;
                }
                SqlDataReader dr;
                SqlCommand cmdupdate = new SqlCommand();

                progressBar1.Minimum = 0;
                lblCount.Text = "0";
                lblNo.Text = "0";
                lblCount.Text = "Total Item: " + lstRight.Items.Count.ToString();
                progressBar1.Maximum = lstRight.Items.Count;
                //progressBar1.Step = 1;
                lblCount.Refresh();
                for (int intRow = 0; intRow < lstRight.Items.Count; intRow++)
                {
                    dblOpnAvgRate = 0;
                    intCheck = 0;
                    dblCostRate = 0;
                    dblClsAmnt = 0;
                    dblCostQty = 0;
                    strItemName = lstRight.Items[intRow].ToString();
                    progressBar1.Refresh();

                    using (SqlConnection gcnMain = new SqlConnection(connstring))
                    {
                        if (gcnMain.State == ConnectionState.Open)
                        {
                            gcnMain.Close();
                        }
                        gcnMain.Open();
                        cmdupdate.Connection = gcnMain;


                        strSQL = "UPDATE ACC_BILL_TRAN SET BILL_QUANTITY=BILL_AMOUNT / BILL_RATE ";
                        strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                        strSQL = strSQL + "AND  COMP_VOUCHER_TYPE IN(33) ";
                        strSQL = strSQL + "AND  BILL_RATE > 0 ";
                        strSQL = strSQL + "AND  BILL_AMOUNT > 0 ";
                        cmdupdate.CommandText = strSQL;
                        cmdupdate.ExecuteNonQuery();

                        strSQL = "UPDATE INV_TRAN SET INWARD_AMOUNT=INV_TRAN_RATE * INV_TRAN_QUANTITY ";
                        strSQL = strSQL + ",INV_TRAN_AMOUNT=INV_TRAN_RATE * INV_TRAN_QUANTITY ";
                        strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                        strSQL = strSQL + "AND  INV_VOUCHER_TYPE IN(33) ";
                        strSQL = strSQL + "AND  INV_INOUT_FLAG='I'";
                        cmdupdate.CommandText = strSQL;
                        cmdupdate.ExecuteNonQuery();


                        //DataTable dt = new DataTable();
                        List<StockItem> OBJlIST = new List<StockItem>();
                        strSQL = "SELECT INV_TRAN_SERIAL,INV_REF_NO,INV_VOUCHER_TYPE,STOCKITEM_NAME,";
                        strSQL = strSQL + "INV_DATE,INV_TRAN_QUANTITY,INWARD_AMOUNT,OUTWARD_SALES_AMOUNT,INV_TRAN_AMOUNT,OUTWARD_COST_AMOUNT ";
                        strSQL = strSQL + ",INV_INOUT_FLAG,ISNULL(INV_LOG_NO,' ') AS INV_LOG_NO,INV_TRAN_RUNNING_QTY,INV_TRAN_RATE,OUTWARD_QUANTITY FROM INV_TRAN ";
                        strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                        //strSQL = strSQL + "AND INV_VOUCHER_TYPE is not null and INV_VOUCHER_TYPE <> 0 ";
                        strSQL = strSQL + "ORDER BY INV_DATE,INWARD_QUANTITY DESC,INV_REF_NO ASC ";
                        cmdupdate.CommandText = strSQL;
                        dr = cmdupdate.ExecuteReader();
                        while (dr.Read())
                        {
                            StockItem oobjList = new StockItem();
                            oobjList.lngSlNo = Convert.ToInt64(dr["INV_TRAN_SERIAL"]);
                            oobjList.dblOpnQty = Convert.ToDouble(dr["INV_TRAN_QUANTITY"]);
                            oobjList.dblOpnValue = Convert.ToDouble(dr["INV_TRAN_AMOUNT"]);
                            oobjList.lngVtype = Convert.ToInt64(dr["INV_VOUCHER_TYPE"]);
                            OBJlIST.Add(oobjList);
                        }
                        dr.Close();
                        //DataSet ds = new DataSet();
                        //SqlDataAdapter da = new SqlDataAdapter(strSQL, gcnMain);
                        //da.Fill(ds);
                        //dt = ds.Tables[0];


                        SqlTransaction myTrans;
                        myTrans = gcnMain.BeginTransaction();

                        cmdupdate.Transaction = myTrans;
                        strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) AMNT,ISNULL(SUM(INV_TRAN_QUANTITY),0) AS QNTY FROM INV_TRAN ";
                        strSQL = strSQL + "WHERE INV_VOUCHER_TYPE=33 ";
                        strSQL = strSQL + "AND STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                        cmdupdate.CommandText = strSQL;
                        dr = cmdupdate.ExecuteReader();
                        if (dr.Read())
                        {
                            if (Convert.ToDouble(dr["AMNT"]) != 0 && Convert.ToDouble(dr["QNTY"]) != 0)
                            {
                                dblOpnAvgRate = Math.Round(Convert.ToDouble(dr["AMNT"]), 2) / Math.Round(Convert.ToDouble(dr["QNTY"]), 4);
                                dblOpnAvgRate = Math.Round(dblOpnAvgRate, 2);
                            }
                            else
                            {
                                dblOpnAvgRate = 0;
                            }
                        }
                        dr.Close();

                        if (dblOpnAvgRate == 0)
                        {
                            strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) AMNT,ISNULL(SUM(INV_TRAN_QUANTITY),0) AS QNTY FROM INV_TRAN ";
                            strSQL = strSQL + "WHERE INV_VOUCHER_TYPE=0 ";
                            strSQL = strSQL + "AND STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                            cmdupdate.CommandText = strSQL;
                            dr = cmdupdate.ExecuteReader();
                            if (dr.Read())
                            {
                                if (Convert.ToDouble(dr["AMNT"]) != 0 && Convert.ToDouble(dr["QNTY"]) != 0)
                                {
                                    dblOpnAvgRate = Math.Round(Convert.ToDouble(dr["AMNT"]), 2) / Math.Round(Convert.ToDouble(dr["QNTY"]), 4);
                                    dblOpnAvgRate = Math.Round(dblOpnAvgRate, 2);
                                }
                                else
                                {
                                    dblOpnAvgRate = 0;
                                }
                            }
                        }
                        dr.Close();
                        if (dblOpnAvgRate != 0)
                        {
                            strSQL = "UPDATE INV_TRAN SET ";
                            strSQL = strSQL + "INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + Math.Abs(dblOpnAvgRate) + " ";
                            strSQL = strSQL + ",INV_TRAN_RATE=" + Math.Abs(dblOpnAvgRate) + " ";
                            strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                            strSQL = strSQL + "AND  INV_INOUT_FLAG IS NULL ";
                            strSQL = strSQL + "AND  INV_TRAN_QUANTITY <> 0  ";
                            strSQL = strSQL + "AND  INV_VOUCHER_TYPE=0 ";
                            cmdupdate.CommandText = strSQL;
                            cmdupdate.ExecuteNonQuery();
                            strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_VALUE =STOCKITEM_OPENING_BALANCE * " + Math.Abs(dblOpnAvgRate) + " ";
                            strSQL = strSQL + ",STOCKITEM_OPENING_RATE = " + Math.Abs(dblOpnAvgRate) + " ";
                            strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                            cmdupdate.CommandText = strSQL;
                            cmdupdate.ExecuteNonQuery();
                            if (OBJlIST.Count > 0)
                            {
                                dblCostRate = Math.Abs(dblOpnAvgRate);
                                progressBar2.Value = 0;
                                progressBar2.Maximum = OBJlIST.Count;
                                foreach (StockItem row in OBJlIST)
                                {

                                    dblTranQty = Math.Round(Convert.ToDouble(row.dblOpnQty), 3);
                                    dblInwardAmnt = Math.Round(Convert.ToDouble(row.dblOpnValue), 2);
                                    //dblInwardAmnt = Math.Round((dblTranQty * dblCostRate), 2);
                                    lngInvSerialNo = Convert.ToInt64(row.lngSlNo);
                                    lngVoucherType = Convert.ToInt16(row.lngVtype);
                                    //if (lngInvSerialNo == 284165)
                                    //{
                                    //    MessageBox.Show("");
                                    //}

                                    if (lngVoucherType == 33)
                                    {
                                        if (intCheck == 0)
                                        {
                                            //MessageBox.Show(dblRunningQty.ToString());
                                            dblClsAmnt = Math.Round((dblRunningQty * dblCostRate), 2);
                                            dblClsAmnt = dblClsAmnt + dblInwardAmnt;
                                            dblCostQty = Math.Round(dblRunningQty + dblTranQty, 3);
                                            dblCostRate = Math.Round(dblClsAmnt / dblCostQty, 2);
                                            intCheck = 1;
                                        }
                                        else
                                        {
                                            dblClsAmnt = dblClsAmnt + dblInwardAmnt;
                                            dblCostQty = Math.Round(dblRunningQty + dblTranQty, 3);
                                            //MessageBox.Show(dblClsAmnt.ToString());
                                            //dblRunningQty = dblRunningQty + dblTranQty;
                                            dblCostRate = Math.Round(dblClsAmnt / dblCostQty, 2);
                                        }

                                    }
                                    else
                                    {
                                        if (dblCostRate > 0)
                                        {
                                            intCheck = 0;
                                            strSQL = "UPDATE INV_TRAN SET INWARD_AMOUNT=INV_TRAN_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                            strSQL = strSQL + ",INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                            strSQL = strSQL + ",INV_TRAN_RATE=" + Math.Abs(dblCostRate) + " ";
                                            strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                            strSQL = strSQL + "AND  INV_VOUCHER_TYPE NOT IN(33) ";
                                            strSQL = strSQL + "AND  INV_INOUT_FLAG='I'";
                                            strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                            cmdupdate.CommandText = strSQL;
                                            cmdupdate.ExecuteNonQuery();
                                            strSQL = "UPDATE INV_TRAN SET ";
                                            strSQL = strSQL + "OUTWARD_SALES_AMOUNT=OUTWARD_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                            strSQL = strSQL + ",OUTWARD_COST_AMOUNT=OUTWARD_QUANTITY * " + Math.Abs(dblCostRate) + " ";
                                            strSQL = strSQL + ",INV_TRAN_AMOUNT=OUTWARD_QUANTITY  * " + Math.Abs(dblCostRate) + " ";
                                            strSQL = strSQL + ",INV_TRAN_RATE=" + Math.Abs(dblCostRate) + " ";
                                            strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                            strSQL = strSQL + "AND  INV_INOUT_FLAG='O'";
                                            strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                            cmdupdate.CommandText = strSQL;
                                            cmdupdate.ExecuteNonQuery();

                                            //strSQL = "UPDATE INV_PRODUCTION_CHILD SET ";
                                            //strSQL = strSQL + "AMNT=QNTY * " + Math.Abs(dblCostRate) + " ";
                                            //strSQL = strSQL + ",RATE=" + Math.Abs(dblCostRate) + " ";
                                            //strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                            //cmdupdate.CommandText = strSQL;
                                            //cmdupdate.ExecuteNonQuery();
                                        }
                                    }

                                    dblRunningQty = Math.Round((dblRunningQty + dblTranQty), 3);

                                    progressBar2.Value += 1;
                                }
                            }

                        }
                        cmdupdate.Transaction.Commit();

                        cmdupdate.Dispose();
                        if (OBJlIST.Count > 0)
                        {
                            OBJlIST.Clear();
                        }


                        dr.Close();
                        //MessageBox.Show("ok");
                        dblOpnAvgRate = 0;
                        intCheck = 0;
                        dblCostRate = 0;
                        dblClsAmnt = 0;
                        dblRunningQty = 0;
                        dblInwardAmnt = 0;
                        dblCostQty = 0;
                        strItemName = "";
                        dblTranQty = 0;
                        lngInvSerialNo = 0;
                        //dt.Rows.Clear();
                    }
                    progressBar1.Value = intRow;
                    progressBar1.PerformStep();
                    progressBar1.Refresh();
                    lblNo.Text = "Records Read = " + lblCount.Text + "/" + progressBar1.Value.ToString();
                    lblNo.Refresh();
                    strmsg = "1";

                }
                using (SqlConnection gcnMain = new SqlConnection(connstring))
                {
                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }
                    gcnMain.Open();
                    cmdupdate.Connection = gcnMain;

                    List<StockItem> OBJproduct = new List<StockItem>();

                    //for (int intRow1 = 0; intRow1 < lstRight.Items.Count; intRow1++)
                    //{
                    //    strItemName = strItemName + lstRight.Items[intRow1].ToString();
                    //}
                    for (int intRow1 = 0; intRow1 < lstRight.Items.Count; intRow1++)
                    {
                        strItemName = strItemName + "'" + lstRight.Items[intRow1].ToString().Replace("'", "''") + "',";
                    }

                    if (strItemName != "")
                    {
                        strItemName = Utility.Mid(strItemName, 0, strItemName.Length - 1);
                    }

                    strSQL = "SELECT VOUCHER_NO,STOCKITEM_NAME FROM INV_PRODUCTION_CHILD ";
                    if (strItemName != "")
                    {
                        strSQL = strSQL + "WHERE STOCKITEM_NAME in (" + strItemName + ")";
                    }
                    cmdupdate.CommandText = strSQL;
                    dr = cmdupdate.ExecuteReader();
                    while (dr.Read())
                    {
                        StockItem oobjList = new StockItem();
                        oobjList.strRefNo = dr["VOUCHER_NO"].ToString();
                        oobjList.strItemName = dr["STOCKITEM_NAME"].ToString();
                        OBJproduct.Add(oobjList);
                    }

                    dr.Close();
                    if (OBJproduct.Count > 0)
                    {
                        progressBar2.Value = 0;
                        progressBar2.Maximum = OBJproduct.Count;
                        foreach (StockItem row in OBJproduct)
                        {
                            strSQL = "SELECT ISNULL(SUM(INV_TRAN_AMOUNT),0) AMNT,ISNULL(SUM(INV_TRAN_QUANTITY),0) AS QNTY FROM INV_TRAN ";
                            strSQL = strSQL + "WHERE INV_REF_NO='" + row.strRefNo + "' ";
                            strSQL = strSQL + "AND STOCKITEM_NAME='" + row.strItemName.Replace("'", "''") + "' ";
                            cmdupdate.CommandText = strSQL;
                            dr = cmdupdate.ExecuteReader();
                            if (dr.Read())
                            {
                                if (Convert.ToDouble(dr["AMNT"]) != 0 && Convert.ToDouble(dr["QNTY"]) != 0)
                                {
                                    dblCostRate = Math.Round(Convert.ToDouble(dr["AMNT"]), 2) / Math.Round(Convert.ToDouble(dr["QNTY"]), 4);
                                    dblCostRate = Math.Round(dblCostRate, 2);
                                }
                                else
                                {
                                    dblCostRate = 0;
                                }
                            }
                            dr.Close();
                            if (dblCostRate > 0)
                            {
                                strSQL = "UPDATE INV_PRODUCTION_CHILD SET ";
                                strSQL = strSQL + "AMNT=QNTY * " + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + ",RATE=" + Math.Abs(dblCostRate) + " ";
                                strSQL = strSQL + "WHERE VOUCHER_NO='" + row.strRefNo + "' ";
                                strSQL = strSQL + "AND STOCKITEM_NAME='" + row.strItemName.Replace("'", "''") + "' ";
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                                strmsg = "1";
                            }
                            dblCostRate = 0;

                            dr.Close();

                            progressBar2.Value += 1;

                        }

                    }
                    dr.Close();

                }




                if (strmsg == "1")
                {
                    MessageBox.Show("Update Successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    
        private void frmUpdateAVG_Load(object sender, EventArgs e)
        {
            mLaodItem();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }

        private void chkFGItem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFGItem.Checked)
            {
                chkDilution.Checked = false;
                chkFGItem.Checked = true;
               
            }
            mLaodItem();
        }

    
   


        private void mCalculateChallan()
        {
            string strmsg = "", strSQL = "", strRefNumber = "", strDate = "", strBillKey = "";
            int intCount = 1;
            long lngloop = 1;
            SqlCommand cmdupdate = new SqlCommand();
            progressBar1.Minimum = 0;
            lblCount.Text = "0";
            lblNo.Text = "0";
            lblCount.Text = "Total Item: " + lstRight.Items.Count.ToString();
            progressBar1.Maximum = lstRight.Items.Count;
            //progressBar1.Step = 1;
            lblCount.Refresh();
            strDate = "31-10-2020";
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                cmdupdate.Connection = gcnMain;
                DataTable dt = new DataTable();
                progressBar1.Value = 0;
                lblNetTotal.Text = "";
                lblCount.Text = "";
                strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(15) + "0001" + "000000";
                strSQL = "SELECT INV_STOCKITEM.STOCKITEM_NAME,INV_OPENING_TRAN_QRY.INV_TRAN_QUANTITY, INV_OPENING_TRAN_QRY.INV_TRAN_AMOUNT,INV_STOCKITEM.STOCKITEM_BASEUNITS  ";
                strSQL = strSQL + "FROM INV_OPENING_TRAN_QRY INV_OPENING_TRAN_QRY INNER JOIN INV_STOCKITEM INV_STOCKITEM ON ";
                strSQL = strSQL + "INV_OPENING_TRAN_QRY.STOCKITEM_NAME = INV_STOCKITEM.STOCKITEM_NAME INNER JOIN INV_STOCKITEM_LEVEL INV_STOCKITEM_LEVEL ON INV_OPENING_TRAN_QRY.STOCKITEM_NAME = INV_STOCKITEM_LEVEL.STOCKITEM_NAME  ";
                strSQL = strSQL + "WHERE INV_OPENING_TRAN_QRY.GODOWNS_NAME  IN('Main Location') AND INV_OPENING_TRAN_QRY.STOCKGROUP_NAME  IN('Dilution') AND (INV_OPENING_TRAN_QRY.INV_TRAN_QUANTITY <> 0 ";
                strSQL = strSQL + "OR INV_OPENING_TRAN_QRY.INWARD_QUANTITY <> 0 OR INV_OPENING_TRAN_QRY.OUTWARD_QUANTITY <> 0 ) ORDER BY INV_OPENING_TRAN_QRY.GODOWNS_NAME,INV_STOCKITEM_LEVEL.STOCKITEM_NAME ASC ";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, gcnMain);
                da.Fill(ds);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    progressBar1.Maximum = dt.Rows.Count;
                    lblCount.Text = dt.Rows.Count.ToString();
                    foreach (DataRow row in dt.Rows)
                    {
                        SqlTransaction myTrans;
                        myTrans = gcnMain.BeginTransaction();
                        cmdupdate.Transaction = myTrans;


                        if (lngloop == 1)
                        {
                            strSQL = VoucherSW.gInsertmasterNew(strRefNumber, "0001", 15, strDate, 0,
                                                   "Adjust", "", 0, "", "0", 1, "");
                          
                            cmdupdate.CommandText = strSQL;
                            cmdupdate.ExecuteNonQuery();
                        }
                        strBillKey = strRefNumber + lngloop.ToString().PadLeft(4, '0');


                        //strSQL = VoucherSW.gInsertBillTran(strBillKey, strRefNumber, Convert.ToInt64(15), strDate, row["STOCKITEM_NAME"].ToString(), "Main Location", Utility.Val(row["INV_TRAN_QUANTITY"].ToString()),
                        //                        0, row["STOCKITEM_BASEUNITS"].ToString(), 0,
                        //                       Math.Round(Utility.Val(row["INV_TRAN_AMOUNT"].ToString()), 2), "",
                        //                                0, Utility.Val(row["INV_TRAN_AMOUNT"].ToString()), "Cr", lngloop, "0001", Utility.gstrBaseCurrency,
                        //                                row["STOCKITEM_BASEUNITS"].ToString(), "", "", "", "", "", "", "", 0, 0);
                        //cmdupdate.CommandText = strSQL;
                        //cmdupdate.ExecuteNonQuery();

                        //strSQL = VoucherSW.gInsertBillTranProcess(strBillKey, "0001", lngloop, strRefNumber, strRefNumber, Convert.ToInt64(15), strDate,
                        //                                row["STOCKITEM_NAME"].ToString(), "Main Location", Utility.Val(row["INV_TRAN_QUANTITY"].ToString()),
                        //                                row["STOCKITEM_BASEUNITS"].ToString(), "", 0, 0, row["STOCKITEM_BASEUNITS"].ToString());
                        //cmdupdate.CommandText = strSQL;
                        //cmdupdate.ExecuteNonQuery();


                        //strSQL = VoucherSW.gInsertBillTranProcess(strBillKey, "0001", lngloop, strRefNumber, strRefNumber, 16, strDate,
                        //                                        row["STOCKITEM_NAME"].ToString(), "Main Location", Utility.Val(row["BILL_BALANCE_QTY"].ToString()) * -1,
                        //                                        row["STOCKITEM_BASEUNITS"].ToString(), "", 0, 0, row["STOCKITEM_BASEUNITS"].ToString());
                        //cmdupdate.CommandText = strSQL;
                        //cmdupdate.ExecuteNonQuery();
                        strSQL = VoucherSW.gInventoryInsertTranSalesChallan(strRefNumber, strBillKey, lngloop, Math.Round(Utility.Val(row["INV_TRAN_QUANTITY"].ToString()), 2), -1, 16,
                                                                            row["STOCKITEM_NAME"].ToString(), "Main Location",
                                                                    "O", Utility.Val(row["INV_TRAN_QUANTITY"].ToString()) * -1, 0 * -1, 0, Convert.ToInt64(15), strDate,
                                                                    "0001", "", 0, row["STOCKITEM_BASEUNITS"].ToString(), row["STOCKITEM_BASEUNITS"].ToString());
                        cmdupdate.CommandText = strSQL;
                        cmdupdate.ExecuteNonQuery();




                        cmdupdate.Transaction.Commit();
                        progressBar1.PerformStep();
                        progressBar1.Refresh();
                        progressBar1.Value = intCount;
                        lblNo.Text = "Records Read = " + lblCount.Text + "/" + intCount;
                        lblNo.Refresh();
                        intCount += 1;
                        strmsg = "1";
                        lngloop += 1;

                    }


                }


            }



            if (strmsg == "1")
            {
                MessageBox.Show("OK");
            }
        }

       

  






        private void mCalculateTransferNewSample()
        {
            string strItemName = "", strmsg = "", strSQL = "";
            int intCount = 1, intloop = 1, intloop1 = 1;
            string strdate = "", strRefNo = "", strUOm = "";

            double dblDilutionQnty = 0, dblRate = 0, dblAmount = 0;

            string strBillKey = "";
            SqlDataReader dr;
            SqlCommand cmdupdate = new SqlCommand();

            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            lblCount.Text = "0";
            lblNo.Text = "0";
            lblCount.Text = "Total Item: " + lstRight.Items.Count.ToString();

            //progressBar1.Step = 1;
            lblCount.Refresh();

            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                //for (int intRow = 0; intRow < lstRight.Items.Count; intRow++)
                //{

                //intCheck = 0;



                //strItemName = lstRight.Items[intRow].ToString();
                progressBar1.Refresh();
                progressBar1.Value = 0;
                cmdupdate.Connection = gcnMain;
                DataTable dt = new DataTable();
                //*************Dilution



                //strSQL = "SELECT T.STOCKITEM_NAME,T.INV_DATE,I.STOCKITEM_BASEUNITS,  abs(SUM(INV_TRAN_QUANTITY)) AS BILL_QUANTITY, abs(SUM(INV_TRAN_QUANTITY)) * 13.64 AS AMNT  FROM INV_TRAN  T,INV_STOCKITEM I ";
                //strSQL = strSQL + "WHERE T.STOCKITEM_NAME=I.STOCKITEM_NAME AND I.STOCKGROUP_NAME in ('Dilution')  AND T.INV_VOUCHER_TYPE   =23   AND T.GODOWNS_NAME ='Main Location' ";
                //strSQL = strSQL + "AND (T.INV_DATE  BETWEEN  convert(datetime,'01-01-2020',103) and convert(datetime,'31-10-2020',103)) GROUP BY T.STOCKITEM_NAME,T.INV_DATE,I.STOCKITEM_BASEUNITS  ";


                strSQL = "SELECT T.STOCKITEM_NAME,T.INV_DATE,I.STOCKITEM_BASEUNITS,  abs(SUM(INV_TRAN_QUANTITY)) AS BILL_QUANTITY, abs(SUM(INV_TRAN_QUANTITY)) * 13.64 AS AMNT  FROM INV_TRAN  T,INV_STOCKITEM I ";
                strSQL = strSQL + "WHERE T.STOCKITEM_NAME=I.STOCKITEM_NAME   AND I.STOCKGROUP_NAME in ('Dilution')  AND T.INV_VOUCHER_TYPE   =15   AND T.GODOWNS_NAME ='Main Location'  AND T.INV_REF_NO LIKE 'SM%' ";
                strSQL = strSQL + "AND (T.INV_DATE  BETWEEN  convert(datetime,'01-01-2020',103) and convert(datetime,'31-10-2020',103)) GROUP BY T.STOCKITEM_NAME,T.INV_DATE,I.STOCKITEM_BASEUNITS   ";
                 DataSet dsNEW = new DataSet();
                SqlDataAdapter daNEW = new SqlDataAdapter(strSQL, gcnMain);
                daNEW.Fill(dsNEW);
                dt = dsNEW.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    progressBar1.Maximum = dt.Rows.Count;
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            SqlTransaction myTrans;
                            myTrans = gcnMain.BeginTransaction();
                            cmdupdate.Transaction = myTrans;

                            strItemName = row["STOCKITEM_NAME"].ToString();
                            strdate = row["INV_DATE"].ToString();
                            dblDilutionQnty = Utility.Val(row["BILL_QUANTITY"].ToString());
                            dblRate = 13.64;
                            dblAmount = Utility.Val(row["AMNT"].ToString());
                            strUOm = row["STOCKITEM_BASEUNITS"].ToString();
                            //if (intloop > 20)
                            //{
                            //    intloop1 += 1;
                            //    intloop = 1;
                            //}
                            if (intloop == 1)
                            {
                                strRefNo = "SS00010000" + intloop1;
                                strSQL = VoucherSW.gInsertmasterNew(strRefNo, "0001", 27, strdate, 0,
                                                  "For Dilution Production for the month of 01-01-2020 to 31-10-2020 ", "", 0, "", "0", 0);
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                            }

                            strBillKey = strRefNo + intloop.ToString().PadLeft(4, '0');
                            strSQL = VoucherSW.mInsertTranInward(strBillKey, intloop1, strRefNo, strItemName, 27,
                                                                       strdate, dblDilutionQnty, dblRate, "Main Location", dblAmount, "I",
                                                                       "0001", "", "", strUOm, strUOm, "", 0, 0);
                            cmdupdate.CommandText = strSQL;
                            cmdupdate.ExecuteNonQuery();
                            cmdupdate.Transaction.Commit();
                            intloop += 1;
                            //intloop1 += 1;
                            strBillKey = "";
                            dblAmount = 0;
                            progressBar1.Value += 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(intloop1.ToString());
                        }

                    }

                }

                //return;
                dt.Rows.Clear();
                strItemName = "";

                lblNo.Refresh();
                intCount += 1;
                strmsg = "1";
            }

            //}



            if (strmsg == "1")
            {
                MessageBox.Show("OK");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string strItemName = "", strmsg = "", strSQL = "", strdate = "", strRefNo = "", strBillKey = "", strUOm="";
            double dblDilutionQnty = 0, dblAmount=0;
            int intloop = 1;
            SqlDataReader dr;
            SqlCommand cmdupdate = new SqlCommand();

            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
         

            //progressBar1.Step = 1;
            lblCount.Refresh();

            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                //for (int intRow = 0; intRow < lstRight.Items.Count; intRow++)
                //{

                //intCheck = 0;



                //strItemName = lstRight.Items[intRow].ToString();
                progressBar1.Refresh();
                progressBar1.Value = 0;
                cmdupdate.Connection = gcnMain;
                DataTable dt = new DataTable();
                //*************Dilution



                //strSQL = "SELECT T.STOCKITEM_NAME,T.INV_DATE,I.STOCKITEM_BASEUNITS,  abs(SUM(INV_TRAN_QUANTITY)) AS BILL_QUANTITY, abs(SUM(INV_TRAN_QUANTITY)) * 13.64 AS AMNT  FROM INV_TRAN  T,INV_STOCKITEM I ";
                //strSQL = strSQL + "WHERE T.STOCKITEM_NAME=I.STOCKITEM_NAME AND I.STOCKGROUP_NAME in ('Dilution')  AND T.INV_VOUCHER_TYPE   =23   AND T.GODOWNS_NAME ='Main Location' ";
                //strSQL = strSQL + "AND (T.INV_DATE  BETWEEN  convert(datetime,'01-01-2020',103) and convert(datetime,'31-10-2020',103)) GROUP BY T.STOCKITEM_NAME,T.INV_DATE,I.STOCKITEM_BASEUNITS  ";


                strSQL = "SELECT F1, F10 FROM Sheet1$ ";
                strSQL = strSQL + "WHERE F10 < 0 ";
                DataSet dsNEW = new DataSet();
                SqlDataAdapter daNEW = new SqlDataAdapter(strSQL, gcnMain);
                daNEW.Fill(dsNEW);
                dt = dsNEW.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    progressBar1.Maximum = dt.Rows.Count;
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            SqlTransaction myTrans;
                            myTrans = gcnMain.BeginTransaction();
                            cmdupdate.Transaction = myTrans;

                            strItemName = row["F1"].ToString();
                            strdate = "31-01-2021";
                            dblDilutionQnty = Utility.Val(row["F10"].ToString());
                            if (intloop == 1)
                            {
                                strRefNo = "SS00010002" + intloop;
                                strSQL = VoucherSW.gInsertmasterNew(strRefNo, "0001", 27, strdate, 0,
                                                  "For Dilution Production Adhstment for the month of 31-01-2020 to 31-01-2020 ", "", 0, "", "0", 0);
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                            }
                            if (dblDilutionQnty < 0)
                            {
                                strBillKey = strRefNo + intloop.ToString().PadLeft(4, '0');
                                dblAmount = Math.Abs(dblDilutionQnty) * 13.65;
                                strUOm = Utility.gGetBaseUOM(strComID, strItemName);
                                strSQL = VoucherSW.mInsertTranInward(strBillKey, intloop, strRefNo, strItemName, 27,
                                                                           strdate, Math.Abs(dblDilutionQnty), 13.65, "Main Location", dblAmount, "I",
                                                                           "0001", "", "", strUOm, strUOm, "", 0, 0);
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                            }
                            cmdupdate.Transaction.Commit();
                            intloop += 1;
                            //intloop1 += 1;
                            strBillKey = "";
                            dblAmount = 0;
                            progressBar1.Value += 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }
                    MessageBox.Show("Ok");
                }

                //return;
                dt.Rows.Clear();
                strItemName = "";

                lblNo.Refresh();

                strmsg = "1";
            }

            //}



            if (strmsg == "1")
            {
                MessageBox.Show("OK");
            }



        }

        private void chkDilution_Click(object sender, EventArgs e)
        {
            mLaodItem();
        }

       

       
  

        
        

       

      

       
    
       
    }
}