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
            this.lstLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstLeft_KeyDown);
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
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex + 1;

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

        private void mCalculateFG()
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
                                    dblDilutionRate = Math.Abs(Math.Round(dblDilutionValue / dblDilutionQnty, 3));
                                }
                                else
                                {
                                    dblDilutionRate = 0;
                                }
                                strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_RATE=" + dblDilutionRate + " ";
                                strSQL = strSQL + ",STOCKITEM_OPENING_VALUE=STOCKITEM_OPENING_BALANCE * " + dblDilutionRate + " ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                                strSQL = "UPDATE INV_TRAN SET ";
                                strSQL = strSQL + "INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + dblDilutionRate + " ";
                                strSQL = strSQL + ",INV_TRAN_RATE=" + dblDilutionRate + " ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                strSQL = strSQL + "AND  INV_VOUCHER_TYPE= 0 ";
                                strSQL = strSQL + "AND  INV_INOUT_FLAG IS NULL";
                                //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                                strSQL = "UPDATE INV_TRAN SET INWARD_AMOUNT=INV_TRAN_QUANTITY * " + dblDilutionRate + " ";
                                strSQL = strSQL + ",INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + dblDilutionRate + " ";
                                strSQL = strSQL + ",INV_TRAN_RATE=" + dblDilutionRate + " ";
                                strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                strSQL = strSQL + "AND  INV_VOUCHER_TYPE NOT IN(33) ";
                                strSQL = strSQL + "AND  INV_INOUT_FLAG='I'";
                                //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                cmdupdate.CommandText = strSQL;
                                cmdupdate.ExecuteNonQuery();
                                strSQL = "UPDATE INV_TRAN SET ";
                                strSQL = strSQL + "OUTWARD_SALES_AMOUNT=OUTWARD_QUANTITY * " + dblDilutionRate + " ";
                                strSQL = strSQL + ",OUTWARD_COST_AMOUNT=OUTWARD_QUANTITY * " + dblDilutionRate + " ";
                                strSQL = strSQL + ",INV_TRAN_AMOUNT=OUTWARD_QUANTITY  * " + dblDilutionRate + " ";
                                strSQL = strSQL + ",INV_TRAN_RATE=" + dblDilutionRate + " ";
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
                                strSQL = strSQL + "INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME AND INV_TRAN.INV_VOUCHER_TYPE =27 AND INV_STOCKGROUP.FG_STATUS <> 1 ";
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
                                    dblInvoiceRate = Math.Abs(Math.Round(dblInvoiceValue / dblProductionQnty, 3));
                                }
                                else
                                {
                                    dblInvoiceRate = 0;
                                }



                                dblCostValue = Math.Round((dblInvoiceValue * dblWeight), 4);
                                if (dblCostValue != 0 && dblProductionQnty != 0)
                                {
                                    dblCostRate = Math.Round(dblCostValue / dblProductionQnty, 3);
                                }
                                else
                                {
                                    dblCostRate = 0;
                                }
                                if (dblCostRate != 0)
                                {
                                    strSQL = "UPDATE INV_TRAN SET INWARD_AMOUNT=INV_TRAN_QUANTITY * " + dblCostRate + " ";
                                    strSQL = strSQL + ",INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + dblCostRate + " ";
                                    strSQL = strSQL + ",INV_TRAN_RATE=" + dblDilutionRate + " ";
                                    strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                    strSQL = strSQL + "AND  INV_VOUCHER_TYPE NOT IN(33) ";
                                    strSQL = strSQL + "AND  INV_INOUT_FLAG='I'";
                                    //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                    cmdupdate.CommandText = strSQL;
                                    cmdupdate.ExecuteNonQuery();
                                    strSQL = "UPDATE INV_TRAN SET ";
                                    strSQL = strSQL + "OUTWARD_SALES_AMOUNT=OUTWARD_QUANTITY * " + dblDilutionRate + " ";
                                    strSQL = strSQL + ",OUTWARD_COST_AMOUNT=OUTWARD_QUANTITY * " + dblDilutionRate + " ";
                                    strSQL = strSQL + ",INV_TRAN_AMOUNT=OUTWARD_QUANTITY  * " + dblDilutionRate + " ";
                                    strSQL = strSQL + ",INV_TRAN_RATE=" + dblDilutionRate + " ";
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

        private void mCalculateAmountOut()
        {
            string strmsg = "", strSQL = "";
            int  intCount = 1;

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

                cmdupdate.Connection = gcnMain;
                DataTable dt = new DataTable();
                progressBar1.Value = 0;
                lblNetTotal.Text = "";
                lblCount.Text = "";
                strSQL = "SELECT INV_TRAN.INV_REF_NO, SUM(INV_TRAN.INV_TRAN_AMOUNT) AMNT FROM INV_TRAN WHERE INV_INOUT_FLAG = 'O' GROUP BY INV_TRAN.INV_REF_NO ";
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
                      

                        strSQL = "UPDATE INV_MASTER SET INV_AMOUNT=" + Utility.Val(row["AMNT"].ToString()) + " ";
                        strSQL = strSQL + "WHERE INV_REF_NO='" + row["INV_REF_NO"].ToString() + "' ";
                        //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
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

                    }

                   
                }
               

            }



            if (strmsg == "1")
            {
                MessageBox.Show("OK");
            }
        }
        private void mCalculateAmountIN()
        {
            string strmsg = "", strSQL = "";
            int intCount = 1;

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

                cmdupdate.Connection = gcnMain;
                DataTable dt = new DataTable();
                progressBar1.Value = 0;
                lblNetTotal.Text = "";
                lblCount.Text = "";
                strSQL = "SELECT INV_TRAN.INV_REF_NO, SUM(INV_TRAN.INV_TRAN_AMOUNT) AMNT FROM INV_TRAN WHERE INV_INOUT_FLAG = 'I' GROUP BY INV_TRAN.INV_REF_NO ";
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


                        strSQL = "UPDATE INV_MASTER SET INV_AMOUNT=" + Utility.Val(row["AMNT"].ToString()) + " ";
                        strSQL = strSQL + "WHERE INV_REF_NO='" + row["INV_REF_NO"].ToString() + "' ";
                        //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
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

                    }


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

            int intCheck = 0;
            try
            {
                if (chkFGItem.Checked == true)
                {
                    //MessageBox.Show("Cannot Generate Process for FG", "Under Constuction");
                    mCalculateFG();
                    return;
                }
                if (chkDilution.Checked == true)
                {
                    //MessageBox.Show("Cannot Generate Process for FG", "Under Constuction");
                    mCalculateFG();
                    return;
                }
                if (chkAmount.Checked == true)
                {
                    //MessageBox.Show("Cannot Generate Process for FG", "Under Constuction");
                    
                    mCalculateAmountOut();
                    return;
                }
                if (checkBox1.Checked == true)
                {
                    //MessageBox.Show("Cannot Generate Process for FG", "Under Constuction");

                    mCalculateAmountIN();
                    return;
                }
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
                    string connstring = Utility.SQLConnstringComSwitch(strComID);
                    using (SqlConnection gcnMain = new SqlConnection(connstring))
                    {
                        if (gcnMain.State == ConnectionState.Open)
                        {
                            gcnMain.Close();
                        }
                        gcnMain.Open();


                        SqlDataReader dr;
                        SqlCommand cmdupdate = new SqlCommand();
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


                        DataTable dt = new DataTable();
                        strSQL = "SELECT INV_TRAN_SERIAL,INV_VOUCHER_TYPE,STOCKITEM_NAME,";
                        strSQL = strSQL + "INV_DATE,INV_TRAN_QUANTITY,INWARD_AMOUNT,OUTWARD_SALES_AMOUNT,INV_TRAN_AMOUNT,OUTWARD_COST_AMOUNT ";
                        strSQL = strSQL + ",INV_INOUT_FLAG,ISNULL(INV_LOG_NO,' ') AS INV_LOG_NO,INV_TRAN_RUNNING_QTY,INV_TRAN_RATE,OUTWARD_QUANTITY FROM INV_TRAN ";
                        strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                        //strSQL = strSQL + "AND INV_VOUCHER_TYPE is not null and INV_VOUCHER_TYPE <> 0 ";
                        strSQL = strSQL + "ORDER BY INV_DATE,INWARD_QUANTITY DESC,INV_REF_NO ASC ";

                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(strSQL, gcnMain);
                        da.Fill(ds);
                        dt = ds.Tables[0];


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
                        if (dblOpnAvgRate==0)
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
                            strSQL = strSQL + "INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + dblOpnAvgRate + " ";
                            strSQL = strSQL + ",INV_TRAN_RATE=" + dblOpnAvgRate + " ";
                            strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                            strSQL = strSQL + "AND  INV_INOUT_FLAG IS NULL ";
                            strSQL = strSQL + "AND  INV_TRAN_QUANTITY <> 0  ";
                            strSQL = strSQL + "AND  INV_VOUCHER_TYPE=0 ";
                            cmdupdate.CommandText = strSQL;
                            cmdupdate.ExecuteNonQuery();
                            strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_VALUE =STOCKITEM_OPENING_BALANCE * " + dblOpnAvgRate + " ";
                            strSQL = strSQL + ",STOCKITEM_OPENING_RATE = " + dblOpnAvgRate + " ";
                            strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                            cmdupdate.CommandText = strSQL;
                            cmdupdate.ExecuteNonQuery();
                            if (dt.Rows.Count > 0)
                            {
                                dblCostRate = Math.Abs(dblOpnAvgRate);
                                progressBar2.Value = 0;
                                progressBar2.Maximum = dt.Rows.Count;
                                foreach (DataRow row in dt.Rows)
                                {

                                    dblTranQty = Math.Round(Convert.ToDouble(row["INV_TRAN_QUANTITY"]), 3);
                                    dblInwardAmnt = Math.Round(Convert.ToDouble(row["INWARD_AMOUNT"]), 2);
                                    lngInvSerialNo = Convert.ToInt64(row["INV_TRAN_SERIAL"]);
                                    lngVoucherType = Convert.ToInt16(row["INV_VOUCHER_TYPE"]);


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
                                            strSQL = "UPDATE INV_TRAN SET INWARD_AMOUNT=INV_TRAN_QUANTITY * " + dblCostRate + " ";
                                            strSQL = strSQL + ",INV_TRAN_AMOUNT=INV_TRAN_QUANTITY * " + dblCostRate + " ";
                                            strSQL = strSQL + ",INV_TRAN_RATE=" + dblCostRate + " ";
                                            strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                            strSQL = strSQL + "AND  INV_VOUCHER_TYPE NOT IN(33) ";
                                            strSQL = strSQL + "AND  INV_INOUT_FLAG='I'";
                                            strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                            cmdupdate.CommandText = strSQL;
                                            cmdupdate.ExecuteNonQuery();
                                            strSQL = "UPDATE INV_TRAN SET ";
                                            strSQL = strSQL + "OUTWARD_SALES_AMOUNT=OUTWARD_QUANTITY * " + dblCostRate + " ";
                                            strSQL = strSQL + ",OUTWARD_COST_AMOUNT=OUTWARD_QUANTITY * " + dblCostRate + " ";
                                            strSQL = strSQL + ",INV_TRAN_AMOUNT=OUTWARD_QUANTITY  * " + dblCostRate + " ";
                                            strSQL = strSQL + ",INV_TRAN_RATE=" + dblCostRate + " ";
                                            strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                                            strSQL = strSQL + "AND  INV_INOUT_FLAG='O'";
                                            strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                                            cmdupdate.CommandText = strSQL;
                                            cmdupdate.ExecuteNonQuery();
                                           

                                        }
                                    }

                                    dblRunningQty = Math.Round((dblRunningQty + dblTranQty), 3);
                                    progressBar2.Value += 1;
                                }
                            }

                        }


                        cmdupdate.Transaction.Commit();

                        //MessageBox.Show("ok");
                        dblOpnAvgRate = 0;
                        intCheck = 0;
                        dblCostRate = 0;
                        dblClsAmnt = 0;
                        dblCostQty = 0;
                        strItemName = "";
                    }
                    progressBar1.Value = intRow;
                    progressBar1.PerformStep();
                    progressBar1.Refresh();
                    lblNo.Text = "Records Read = " + lblCount.Text + "/" + progressBar1.Value.ToString();
                    lblNo.Refresh();
                    strmsg = "1";

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
                chkAmount.Checked = false;
                checkBox1.Checked = false;
            }
            mLaodItem();
        }

        private void chkDilution_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDilution.Checked)
            {
                chkFGItem.Checked = false;
                chkDilution.Checked = true;
                chkAmount.Checked = false;
                checkBox1.Checked = false;
            }
            mLaodItem();
        }

        private void chkAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAmount.Checked)
            {
                chkFGItem.Checked = false;
                chkDilution.Checked = false ;
                chkAmount.Checked = true;
                checkBox1.Checked = false;
                lstRight.Items.Clear();
                lstLeft.Items.Clear();

            }
            else
            {
                mLaodItem();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                chkFGItem.Checked = false;
                chkDilution.Checked = false;
                chkAmount.Checked = false;
                checkBox1.Checked = true;
                lstRight.Items.Clear();
                lstLeft.Items.Clear();

            }
            else
            {
                mLaodItem();
            }
        }

     

       

       
  

        
        

       

      

       
    
       
    }
}