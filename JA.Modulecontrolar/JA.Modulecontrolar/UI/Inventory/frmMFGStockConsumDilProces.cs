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
using JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms;


namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmMFGStockConsumDilProces : Form
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        string strComID { get; set; }
        public string strFormType { get; set; }
        public string vstrDate { get; set; }
    
        public frmMFGStockConsumDilProces()
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

            oogrp = invms.gFillDilution(strComID, vstrDate,"0001").ToList();
            
            
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
            string strItemName = "", strRefNo = "", strmsg = "", strSQL = "";
            int  intCount = 1;

            double dblDilutionValue = 0, dblDilutionQnty = 0, dblDilutionRate = 0,
                                dblInvoiceValue = 0, dblconsumtpValue = 0, dblCostValue = 0, dblWeight = 0, dblInvoiceRate = 0;

            SqlDataReader dr;
            SqlCommand cmdupdate = new SqlCommand();
            //DataTable dt = new DataTable();
            // DataSet ds = new DataSet();
            progressBar1.Value = 0;
            lblCount.Text = "0";
            lblNo.Text = "0";
            lblCount.Text = "Total Item: " + lstRight.Items.Count.ToString();
            progressBar1.Maximum = lstRight.Items.Count;
            //progressBar1.Step = 1;
            lblCount.Refresh();
            List<StockItem> OBJiTEM = new List<StockItem>();
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
                    //dblCostRate = 0;


                    strRefNo = lstRight.Items[intRow].ToString();
                    progressBar1.Refresh();
                    cmdupdate.Connection = gcnMain;
                    
                    //*************Dilution
                    //strSQL = "SELECT ISNULL(SUM(INV_TRAN.OUTWARD_SALES_AMOUNT),0) AS PRODUCTION_vALUE FROM INV_STOCKITEM ,INV_TRAN WHERE INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME AND INV_TRAN.INV_VOUCHER_TYPE =26 ";
                    //strSQL = strSQL + "AND INV_TRAN.GODOWNS_NAME in ('Dilution Section') ";


                    strSQL = "SELECT  ISNULL(SUM(INV_TRAN.OUTWARD_SALES_AMOUNT),0) AS PRODUCTION_vALUE ";
                    strSQL = strSQL + "FROM  INV_STOCKITEM AS INV_STOCKITEM INNER JOIN INV_TRAN AS INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME INNER JOIN INV_MASTER AS INV_MASTER ON INV_TRAN.INV_REF_NO = INV_MASTER.INV_REF_NO INNER JOIN INV_STOCKGROUP ON INV_STOCKITEM.STOCKGROUP_NAME = INV_STOCKGROUP.STOCKGROUP_NAME  WHERE (INV_MASTER.INV_VOUCHER_TYPE = 26) ";
                    strSQL = strSQL + "AND INV_TRAN.GODOWNS_NAME in ('Dilution Section') ";
                    cmdupdate.CommandText = strSQL;
                    dr = cmdupdate.ExecuteReader();
                    if (dr.Read())
                    {
                        dblDilutionValue = Convert.ToDouble(dr["PRODUCTION_vALUE"]);
                    }
                    dr.Close();

                    strSQL = "SELECT ISNULL(SUM(ACC_BILL_TRAN.BILL_QUANTITY+ACC_BILL_TRAN.BILL_QUANTITY_BONUS),0) AS BILL_QUANTITY ";
                    strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
                    strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME INNER JOIN ";
                    strSQL = strSQL + "ACC_BILL_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = ACC_BILL_TRAN.STOCKITEM_NAME AND ACC_BILL_TRAN.COMP_VOUCHER_TYPE =16 AND INV_STOCKGROUP.FG_STATUS=1 ";
                    strSQL = strSQL + "AND ACC_BILL_TRAN.BRANCH_ID ='0001' ";
                    cmdupdate.CommandText = strSQL;
                    dr = cmdupdate.ExecuteReader();
                    if (dr.Read())
                    {
                        dblDilutionQnty = Convert.ToDouble(dr["BILL_QUANTITY"]);
                    }
                    dr.Close();
                    //end
                    strSQL = "SELECT ISNULL(SUM(INV_TRAN.OUTWARD_SALES_AMOUNT),0) AS CONSUMPTION_VALUE FROM INV_STOCKITEM ,INV_TRAN WHERE INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME AND INV_TRAN.INV_VOUCHER_TYPE =26 ";
                    strSQL = strSQL + "AND INV_TRAN.GODOWNS_NAME IN ('Dilution Section') ";
                    strSQL = strSQL + "AND INV_TRAN.INV_INOUT_FLAG='O' ";
                    strSQL = strSQL + "AND INV_DATE BETWEEN " + Utility.cvtSQLDateString(vstrDate) + " ";
                    strSQL = strSQL + "AND " + Utility.cvtSQLDateString(vstrDate) + " ";
                    strSQL = strSQL + " AND INV_STOCKITEM.MATERIAL_TYPE is not null ";
                    cmdupdate.CommandText = strSQL;
                    dr = cmdupdate.ExecuteReader();
                    if (dr.Read())
                    {
                        dblconsumtpValue = Convert.ToDouble(dr["CONSUMPTION_VALUE"]);
                    }
                    dr.Close();
                    if (dblconsumtpValue==0)
                    {
                        MessageBox.Show("Sorry! RM/PM Consumption not found for the date of " + vstrDate);
                        return;
                    }

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

                    
                    strSQL = "SELECT DISTINCT INV_STOCKITEM.STOCKITEM_NAME   FROM INV_STOCKGROUP , INV_STOCKITEM ,ACC_BILL_TRAN ";
                    strSQL = strSQL + "WHERE  INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME AND INV_STOCKITEM.STOCKITEM_NAME = ACC_BILL_TRAN.STOCKITEM_NAME  ";
                    strSQL = strSQL + "AND ACC_BILL_TRAN.COMP_REF_NO ='" + strRefNo + "' AND FG_STATUS=1  ";
                    cmdupdate.CommandText = strSQL;
                    dr = cmdupdate.ExecuteReader();
                    while (dr.Read())
                    {
                        StockItem ostock = new StockItem();
                        ostock.strItemName = dr["STOCKITEM_NAME"].ToString();
                        OBJiTEM.Add(ostock);
                    }

                    dr.Close();

                    if (OBJiTEM.Count > 0)
                    {
                        foreach (StockItem row in OBJiTEM)
                        {
                            SqlTransaction myTrans;
                            myTrans = gcnMain.BeginTransaction();
                            cmdupdate.Transaction = myTrans;

                            if (dblDilutionValue != 0 && dblDilutionQnty != 0)
                            {
                                dblDilutionRate = Math.Abs(Math.Round(dblDilutionValue / dblDilutionQnty, 3));
                            }
                            else
                            {
                                dblDilutionRate = 0;
                            }
                            strItemName = row.strItemName.ToString();
                            strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_RATE=" + dblDilutionRate + " ";
                            strSQL = strSQL + ",STOCKITEM_OPENING_VALUE=STOCKITEM_OPENING_BALANCE * " + dblDilutionRate + " ";
                            strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                            //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                            strSQL = strSQL + "AND STOCKITEM_OPENING_BALANCE <> 0 ";
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
                            strSQL = strSQL + ",GODOWNS_NAME1='Dilution Section' ";
                            strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                            strSQL = strSQL + "AND INV_REF_NO='" + strRefNo + "' ";
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
                            strSQL = strSQL + ",GODOWNS_NAME1='Dilution Section' ";
                            strSQL = strSQL + "WHERE STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                            strSQL = strSQL + "AND INV_REF_NO='" + strRefNo + "' ";
                            strSQL = strSQL + "AND  INV_INOUT_FLAG='O'";
                            //strSQL = strSQL + "AND INV_TRAN_SERIAL = '" + lngInvSerialNo + "' ";
                            cmdupdate.CommandText = strSQL;
                            cmdupdate.ExecuteNonQuery();
                            strSQL = "UPDATE ACC_BILL_TRAN SET DILUTION_PROCESS =1 ";
                            //strSQL = strSQL + "WHERE STOCKITEM_NAME ='" + strItemName.Replace("'", "''") + "' ";
                            strSQL = strSQL + "WHERE COMP_REF_NO='" + strRefNo + "' ";
                            cmdupdate.CommandText = strSQL;
                            cmdupdate.ExecuteNonQuery();
                            cmdupdate.Transaction.Commit();
                            cmdupdate.Dispose();
                            //dblCostRate = 0;
                            dblInvoiceRate = 0;
                            dblInvoiceValue = 0;
                            //dblProductionQnty = 0;
                            dblDilutionRate = 0;
                           
                        }
                        
                    }
                    dr.Close();
                    progressBar1.PerformStep();
                    progressBar1.Refresh();
                    progressBar1.Value = intCount;
                    intCount += 1;
                }
                if (OBJiTEM.Count > 0)
                {
                    OBJiTEM.Clear();
                }
            

                cmdupdate.Dispose();
                gcnMain.Close();
                lblNo.Text = "Records Read = " + lblCount.Text + "/" + intCount;
                lblNo.Refresh();
                lstRight.Items.Clear();
                strmsg = "1";
            }





            if (strmsg == "1")
            {
                MessageBox.Show("OK");
            }
        }


     
        private void btnOk_Click(object sender, EventArgs e)
        {

            try
            {
                mCalculateFG();
                return;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void frmMFGStockConsumDilProces_Load(object sender, EventArgs e)
        {
            textBox1.Text = vstrDate;
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

        private void btnView_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmRptDilutionProcessPending"] as frmRptDilutionProcessPending == null)
            {
                frmRptDilutionProcessPending objfrm = new frmRptDilutionProcessPending();
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

            }
            else
            {
                frmRptDilutionProcessPending objfrm = (frmRptDilutionProcessPending)Application.OpenForms["frmRptDilutionProcessPending"];
                objfrm.MdiParent = this.MdiParent;
                objfrm.Focus();
            }
        }

       

     

       

       
  

        
        

       

      

       
    
       
    }
}