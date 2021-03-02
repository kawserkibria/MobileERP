using Dutility;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.DReport.Accms.ParameterForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmIncentiveGenerate : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWois = new SPWOIS();
        public long lngFormPriv { get; set; }
        private string strComID { get; set; }
        private ListBox lstLedgerName = new ListBox();
        public frmIncentiveGenerate()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteImportDate.GotFocus += new System.EventHandler(this.dteImportDate_GotFocus);
            this.dteImportDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteImportDate_KeyPress);

            this.txtLedgerName.GotFocus += new System.EventHandler(this.txtLedgerName_GotFocus);
            this.txtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLedgerName_KeyPress);
            this.txtLedgerName.TextChanged += new System.EventHandler(this.txtLedgerName_TextChanged);
            this.txtLedgerName.KeyDown += new KeyEventHandler(txtLedgerName_KeyDown);
            this.lstLedgerName.DoubleClick += new System.EventHandler(this.lstLedgerName_DoubleClick);
            Utility.CreateListBoxHeight(lstLedgerName, pnlMain, txtLedgerName, 0, 100);
        }
        private void dteImportDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtLedgerName.Focus();
               
            }

        }
        #region "User Define"
        private void txtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLedgerName.SelectedItem != null)
                {
                    lstLedgerName.SelectedIndex = lstLedgerName.SelectedIndex - 1;
                    txtLedgerName.Text = lstLedgerName.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedgerName.Items.Count - 1 > lstLedgerName.SelectedIndex)
                {
                    lstLedgerName.SelectedIndex = lstLedgerName.SelectedIndex + 1;
                    txtLedgerName.Text = lstLedgerName.Text;
                }
            }

        }
        private void txtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtLedgerName.Text != "")
                {

                    txtLedgerName.Text = lstLedgerName.Text;
                    lstLedgerName.Visible = false;
                    btnEdit.Focus();
                }
                else
                {
                    lstLedgerName.Visible = false;
                    btnEdit.Focus();
                }



            }
           


        }
        private void txtLedgerName_TextChanged(object sender, EventArgs e)
        {
           
            lstLedgerName.SelectedIndex = lstLedgerName.FindString(txtLedgerName.Text);
        }

        private void lstLedgerName_DoubleClick(object sender, EventArgs e)
        {
            txtLedgerName.Text = lstLedgerName.Text;
            lstLedgerName.Visible = false;
            btnEdit.Focus();
        }
        private void dteImportDate_GotFocus(object sender, System.EventArgs e)
        {
            
            lstLedgerName.Visible = false;

        }
       
        private void txtLedgerName_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerName.Visible = true;
            
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Keys.Escape == keyData)
            {
                //return base.ProcessCmdKey(ref msg, keyData);
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }

            return false;
        }
        #endregion
        #region "Generation"
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string strSQL = "", strLedgerName = "", strBranchID="0001",strFdate = "", strTDate = "",
                            strincentiveKey = "", strmonthId = "",strType = "",strLedgerName1="";
            int intInsert = 0,intyear, intype = 0;
            double dblSalesPer = 0, dblCollPer = 0, dblIncentive = 0, dblIncentivePer = 0, dblSales = 0, dblSalesTarget = 0, dblColl = 0,
                           dblCollTarget = 0, dblcollActPer = 0, dblSalesActPer = 0, dblDededoction = 0, dblDSMColl = 0, 
                           dblDSMCTarget = 0, dblDSMPer = 0;

            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 1))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (txtLedgerName.Text != "")
            {
                strLedgerName = lstLedgerName.SelectedValue.ToString();
            }
            else
            {
                strLedgerName = "";
            }

       
            var strResponseInsert = MessageBox.Show("Do You Want to Generate this auto Voucher?", "Journal Voucher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.No)
            {
                return;
            }
           
            if (radMonthly.Checked)
            {
                strType = "M";
            }
            else if (radYearly.Checked)
            {
                strType = "Y";
            }
            else if (radYearlyExtra.Checked)
            {
                strType = "E";
            }
            if (cboType.Text == "MPO")
            {
                intype = 1;
            }
            else if (cboType.Text == "AH")
            {
                intype = 2;
            }
            else if (cboType.Text == "DH")
            {
                intype = 3;
            }
            intyear = Convert.ToInt32(dteImportDate.Value.ToString("yyyy"));

           
            strFdate = Utility.FirstDayOfMonth(dteImportDate.Value).ToString("dd-MM-yyyy");
            strTDate = Utility.LastDayOfMonth(dteImportDate.Value).ToString("dd-MM-yyyy");
          
            string FirstdayOfMonth = Utility.FirstDayOfMonth(dteImportDate.Value).ToString("dd-MM-yyyy");
            string LasttdayOfMonth = Utility.LastDayOfMonth(dteImportDate.Value).ToString("dd-MM-yyyy");

           
            progressBar1.Value = 0;
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            List<AccountsLedger> ledger = accms.GetCustomerLedgeNew(strComID, strLedgerName, intype).ToList();
            progressBar1.Maximum = ledger.Count;
            foreach (AccountsLedger ooLedger in ledger)
            {
                List<IncentiveCal> objIncentive = accms.mGetIncentive(strComID, intyear, strType, intype, dteImportDate.Value.ToString(), dteImportDate.Value.Month).ToList();
                List<IncentiveCal> objIncArea = accms.mGetIncentive(strComID, intyear, strType, 2, dteImportDate.Value.ToString(), dteImportDate.Value.Month).ToList();

                using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
                {
                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }
                    try
                    {
                        gcnMain.Open();
                        cmd.Connection = gcnMain;
                        dblIncentive = 0;
                        if (intype == 1)
                        {
                            strLedgerName = ooLedger.strParentGroup ;
                            strLedgerName1 = ooLedger.strRepName;
                        }
                        else
                        {
                            strLedgerName = ooLedger.strRepName ;
                           
                        }
                        if (strType.ToUpper() == "M")
                        {
                            #region "MPO"

                            if (intype == 1)
                            {
                                strSQL = "SELECT ISNULL(SUM(C.COMP_VOUCHER_NET_AMOUNT),0) ACHIEVE ";
                                strSQL = strSQL + "from ACC_LEDGER l,ACC_COMPANY_VOUCHER c , ACC_LEDGER_Z_D_A LG where  l.LEDGER_NAME =c.LEDGER_NAME  ";
                                strSQL = strSQL + " and L.LEDGER_NAME=LG.LEDGER_NAME  AND C.COMP_VOUCHER_TYPE = 16 ";
                                strSQL = strSQL + "AND (C.COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                                strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                                strSQL = strSQL + "AND L.LEDGER_STATUS in (0) AND l.BRANCH_ID='0001' ";
                                strSQL = strSQL + "AND L.LEDGER_NAME ='" + ooLedger.strRepName.Replace("'", "''") + "' ";
                                cmd.CommandText = strSQL;
                                dr = cmd.ExecuteReader();
                                if (dr.Read())
                                {
                                    dblSales = Convert.ToDouble(dr["ACHIEVE"].ToString());
                                }
                                dr.Close();


                                strSQL = "SELECT ISNULL(SUM(TARGET_CHANGE_AMNT),0) SALESTARGET ";
                                strSQL = strSQL + "from SALES_TARGET_ACHIEVEMENT ST,ACC_LEDGER_Z_D_A V where ";
                                strSQL = strSQL + "ST.LEDGER_NAME=V.LEDGER_NAME ";
                                //strSQL = strSQL + "--and    ST.LEDGER_NAME ='Masud Rana-004'   ";
                                strSQL = strSQL + "AND ST.LEDGER_NAME ='" + ooLedger.strRepName.Replace("'", "''") + "' ";
                                strSQL = strSQL + "and  ST.TARGET_ACHIEVE_FROM_DATE >= " + Utility.cvtSQLDateString(FirstdayOfMonth) + " ";
                                strSQL = strSQL + "and ST.TARGET_ACHIEVE_TO_DATE<=" + Utility.cvtSQLDateString(LasttdayOfMonth) + " ";
                                if (strBranchID != "")
                                {
                                    strSQL = strSQL + "AND v.BRANCH_ID ='" + strBranchID + "' ";
                                }
                                cmd.CommandText = strSQL;
                                dr = cmd.ExecuteReader();
                                if (dr.Read())
                                {
                                    dblSalesTarget = Convert.ToDouble(dr["SALESTARGET"].ToString());
                                }
                                dr.Close();
                                if (dblSalesTarget > 0)
                                {
                                    //dblSalesActPer = Math.Round((dblSales / dblSalesTarget) * 100, 2);
                                    dblSalesActPer = (dblSales / dblSalesTarget) * 100;
                                }
                                else
                                {
                                    dblSalesActPer = 0;
                                }
                            }

                            strSQL = "SELECT  ";
                            strSQL = strSQL + "ISNULL(SUM(T.TARGET_CHANGE_AMNT),0)  AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T ";
                            strSQL = strSQL + ", ACC_LEDGER_Z_D_A LG , ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                            strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= " + Utility.cvtSQLDateString(strFdate) + "   AND T.COLL_TARGET_TO_DATE <= " + Utility.cvtSQLDateString(strTDate) + ")";
                            strSQL = strSQL + "AND L.LEDGER_STATUS in (0) AND l.BRANCH_ID='0001' ";
                            if (intype == 1)
                            {
                                strSQL = strSQL + "AND L.LEDGER_NAME ='" + ooLedger.strRepName.Replace("'", "''") + "' ";
                            }
                            else if (intype == 2)
                            {
                                strSQL = strSQL + "AND LG.AREA ='" + ooLedger.strRepName.Replace("'", "''") + "' ";
                            }
                            else if (intype == 3)
                            {
                                strSQL = strSQL + "AND LG.DIVISION ='" + ooLedger.strRepName.Replace("'", "''") + "' ";
                            }
                            cmd.CommandText = strSQL;
                            //cmd.Connection = gcnMain;
                            dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                dblCollTarget = Convert.ToDouble(dr["TARGET_ACHIEVE_AMOUNT"].ToString());
                            }
                            dr.Close();

                            strSQL = "SELECT ISNULL(SUM(RECEIPT),0) COLLECTION_AMNT FROM VIEW_MPOWISE_SALES_COLLECTION ";
                            strSQL = strSQL + "WHERE (COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                            strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                            strSQL = strSQL + "AND LEDGER_STATUS in (0) AND BRANCH_ID='0001' ";
                            if (intype == 1)
                            {
                                strSQL = strSQL + "AND LEDGER_NAME ='" + ooLedger.strRepName.Replace("'", "''") + "' ";
                            }
                            else if (intype == 2)
                            {
                                strSQL = strSQL + "AND AREA ='" + ooLedger.strRepName.Replace("'", "''") + "' ";
                            }
                            else if (intype == 3)
                            {
                                strSQL = strSQL + "AND DIVISION ='" + ooLedger.strRepName.Replace("'", "''") + "' ";
                            }

                            cmd.CommandText = strSQL;
                            cmd.CommandTimeout = 0;
                            //cmd.Connection = gcnMain;
                            dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                dblColl = Convert.ToDouble(dr["COLLECTION_AMNT"].ToString());
                            }
                            dr.Close();
                            if (intype == 1)
                            {
                                dblDededoction = Math.Round(dblCollTarget * 0.90, 2);
                            }
                            else
                            {
                                dblDededoction = 0;
                            }
                            if (dblCollTarget > 0)
                            {
                                dblcollActPer = (dblColl / dblCollTarget) * 100;
                               
                            }
                            else
                            {
                                dblcollActPer = 0;
                            }
                            string strUnder = "", strDivision = "N";
                            if (intype == 3)
                            {
                                strSQL = "SELECT GR_NAME FROM ACC_LEDGERGROUP WHERE GR_PARENT ='" + ooLedger.strRepName.Replace("'", "''") + "' ";
                                strSQL = strSQL + "AND DUPLICATE=1 ";
                                cmd.CommandText = strSQL;
                                //cmd.Connection = gcnMain;
                                dr = cmd.ExecuteReader();
                                if (dr.Read())
                                {
                                    strUnder = dr["GR_NAME"].ToString();
                                    strDivision = "Y";
                                }
                                else
                                {
                                    strDivision = "N";
                                }
                                dr.Close();

                                
                                if (strDivision == "Y")
                                {
                                    strSQL = "SELECT  ";
                                    strSQL = strSQL + "ISNULL(SUM(T.TARGET_CHANGE_AMNT),0)  AS TARGET_ACHIEVE_AMOUNT FROM SALES_COLL_TARGET_MASTER M,SALES_COLL_TARGET_TRAN T ";
                                    strSQL = strSQL + ", ACC_LEDGER_Z_D_A LG , ACC_LEDGER L WHERE M.COLL_TARGET_KEY=T.COLL_TARGET_KEY AND L.LEDGER_NAME =T.LEDGER_NAME  and L.LEDGER_NAME=LG.LEDGER_NAME ";
                                    strSQL = strSQL + "AND (T.COLL_TARGET_FROM_DATE >= " + Utility.cvtSQLDateString(strFdate) + "   AND T.COLL_TARGET_TO_DATE <= " + Utility.cvtSQLDateString(strTDate) + ")";
                                    strSQL = strSQL + "AND L.LEDGER_STATUS in (0) AND l.BRANCH_ID='0001' ";
                                    strSQL = strSQL + "AND LG.AREA ='" + strUnder.Replace("'", "''") + "' ";
                                    cmd.CommandText = strSQL;
                                    //cmd.Connection = gcnMain;
                                    dr = cmd.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        dblDSMCTarget = Convert.ToDouble(dr["TARGET_ACHIEVE_AMOUNT"].ToString());
                                    }
                                    dr.Close();

                                    
                                    strSQL = "SELECT ISNULL(SUM(RECEIPT),0) COLLECTION_AMNT FROM VIEW_MPOWISE_SALES_COLLECTION ";
                                    strSQL = strSQL + "WHERE (COMP_VOUCHER_DATE BETWEEN " + Utility.cvtSQLDateString(strFdate) + " ";
                                    strSQL = strSQL + " AND " + Utility.cvtSQLDateString(strTDate) + ") ";
                                    strSQL = strSQL + "AND LEDGER_STATUS in (0) AND BRANCH_ID='0001' ";
                                    if (intype == 1)
                                    {
                                        strSQL = strSQL + "AND LEDGER_NAME ='" + ooLedger.strRepName.Replace("'", "''") + "' ";
                                    }
                                    else if (intype == 2)
                                    {
                                        strSQL = strSQL + "AND AREA ='" + ooLedger.strRepName.Replace("'", "''") + "' ";
                                    }
                                    else if (intype == 3)
                                    {
                                        strSQL = strSQL + "AND DIVISION ='" + ooLedger.strRepName.Replace("'", "''") + "' ";
                                    }

                                    cmd.CommandText = strSQL;
                                    //cmd.Connection = gcnMain;
                                    dr = cmd.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        dblDSMColl = Convert.ToDouble(dr["COLLECTION_AMNT"].ToString());
                                    }
                                    dr.Close();
                                    if (dblDSMCTarget > 0)
                                    {
                                        dblDSMPer = Math.Round((dblDSMColl / dblDSMCTarget) * 100, 2);
                                    }
                                    else
                                    {
                                        dblDSMPer = 0;
                                    }
                                    foreach (IncentiveCal ooIncArea in objIncArea)
                                    {

                                        dblSalesPer = ooIncArea.dblMnothSales;
                                        dblCollPer = ooIncArea.dblMnothColl;
                                        dblIncentivePer = ooIncArea.dblMnothInc;


                                        if (dblCollPer == 100)
                                        {
                                            if (dblDSMPer >= dblCollPer)
                                            {
                                                strDivision = "Y";

                                            }
                                            else
                                            {
                                                dblIncentive = 0;
                                                strDivision = "N";
                                                dblcollActPer = 0;
                                            }
                                        }
                                        else if (dblCollPer == 120)
                                        {
                                            if (dblDSMPer >= dblCollPer)
                                            {
                                                strDivision = "Y";
                                            }
                                            else
                                            {
                                                dblIncentive = 0;
                                                strDivision = "N";
                                                dblcollActPer = 0;
                                            }
                                        }

                                    }

                                }
                            }

                            bool blngInsert = true;
                            if (intype == 1)
                            {
                                foreach (IncentiveCal ooIncentive in objIncentive)
                                {
                                    dblSalesPer = ooIncentive.dblMnothSales;
                                    dblCollPer = ooIncentive.dblMnothColl;
                                    dblIncentivePer = ooIncentive.dblMnothInc;
                                    if (blngInsert == true)
                                    {
                                        if (dblSalesPer == 100 && dblCollPer == 100)
                                        {
                                            if (dblSalesActPer >= 100 && dblcollActPer >= 100)
                                            {
                                                if (dblcollActPer < 120)
                                                {
                                                    dblIncentive = Math.Round(((dblColl - dblDededoction) * dblIncentivePer) / 100, 2);
                                                    blngInsert = false;
                                                }
                                            }
                                        }
                                        else if (dblSalesPer == 100 && dblCollPer == 120)
                                        {
                                            if (dblSalesActPer >= 100 && dblcollActPer >= 120)
                                            {
                                                dblIncentive = Math.Round(((dblColl - dblDededoction) * dblIncentivePer) / 100, 2);
                                                blngInsert = false;
                                            }
                                        }
                                    }

                                }
                            }
                            else if (intype == 2)
                            {
                               
                                    foreach (IncentiveCal ooIncentive in objIncentive)
                                    {
                                        dblSalesPer = ooIncentive.dblMnothSales;
                                        dblCollPer = ooIncentive.dblMnothColl;
                                        dblIncentivePer = ooIncentive.dblMnothInc;
                                        if (blngInsert == true)
                                        {
                                            if (dblCollPer == 100)
                                            {
                                                if (dblcollActPer >= 100 && dblcollActPer <120)
                                                {
                                                    dblIncentive = Math.Round(((dblColl) * dblIncentivePer) / 100, 2);
                                                    blngInsert = false;
                                                }
                                            }

                                            else if (dblCollPer == 120)
                                            {
                                                if (dblcollActPer >= dblCollPer)
                                                {
                                                    dblIncentive = Math.Round(((dblColl) * dblIncentivePer) / 100, 2);
                                                    blngInsert = false;
                                                }
                                            }
                                        }

                                    }
                                
                            }
                            else if (intype == 3)
                            {
                               
                                    foreach (IncentiveCal ooIncentive in objIncentive)
                                    {

                                        dblSalesPer = ooIncentive.dblMnothSales;
                                        dblCollPer = ooIncentive.dblMnothColl;
                                        dblIncentivePer = ooIncentive.dblMnothInc;

                                        if (blngInsert == true)
                                        {
                                            if (dblCollPer == 90)
                                            {
                                                if (dblcollActPer >= dblCollPer && dblcollActPer < 100)
                                                {
                                                    dblIncentive = Math.Round(((dblColl) * dblIncentivePer) / 100, 2);
                                                    blngInsert = false;
                                                }
                                            }
                                            else if (dblCollPer == 100)
                                            {
                                                if (dblcollActPer >= dblCollPer && dblcollActPer < 115)
                                                {
                                                    dblIncentive = Math.Round(((dblColl) * dblIncentivePer) / 100, 2);
                                                    blngInsert = false;
                                                }
                                            }
                                            else if (dblCollPer == 115)
                                            {
                                                if (dblcollActPer >= dblCollPer)
                                                {
                                                    dblIncentive = Math.Round(((dblColl) * dblIncentivePer) / 100, 2);
                                                    blngInsert = false;
                                                }
                                            }
                                            else
                                            {
                                                dblIncentive = 0;
                                            }
                                        }
                                }
                            }
                           
                            strmonthId =dteImportDate.Value.ToString("MMMyy").ToUpper();
                            strincentiveKey = intyear + strmonthId + intype + strType.ToUpper();
                            if (dblIncentive > 0)
                            {
                                SqlCommand cmdInsert = new SqlCommand();
                                SqlTransaction myTrans;
                                myTrans = gcnMain.BeginTransaction();
                                cmdInsert.Connection = gcnMain;
                                cmdInsert.Transaction = myTrans;
                                if (intInsert == 0)
                                {
                                    strSQL = "DELETE FROM ACC_INCENTIVE_CHILD ";
                                    strSQL = strSQL + "WHERE INCENTIVE_KEY='" + strincentiveKey + "' ";
                                    if (txtLedgerName.Text != "")
                                    {
                                        strSQL = strSQL + "AND MERZE_NAME='" + strLedgerName.Replace("'", "''") + "' ";
                                    }
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();
                                    if (txtLedgerName.Text == "")
                                    {
                                        strSQL = "DELETE FROM ACC_INCENTIVE_MASTER ";
                                        strSQL = strSQL + "WHERE INCENTIVE_KEY='" + strincentiveKey + "' ";
                                        strSQL = strSQL + "AND INC_MODE='M' ";
                                        strSQL = strSQL + "AND INC_TYPE=" + intype + " ";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                        strSQL = "INSERT INTO ACC_INCENTIVE_MASTER(";
                                        strSQL = strSQL + "INCENTIVE_KEY";
                                        strSQL = strSQL + ",MONTH_ID";
                                        strSQL = strSQL + ",MONTH_DATE";
                                        strSQL = strSQL + ",INC_MODE";
                                        strSQL = strSQL + ",INC_YEAR";
                                        strSQL = strSQL + ",INC_TYPE";
                                        strSQL = strSQL + ")";
                                        strSQL = strSQL + "VALUES(";
                                        strSQL = strSQL + "'" + strincentiveKey + "' ";
                                        strSQL = strSQL + ",'" + strmonthId + "' ";
                                        strSQL = strSQL + "," + Utility.cvtSQLDateString(strTDate) + " ";
                                        strSQL = strSQL + ",'" + strType.ToUpper() + "'";
                                        strSQL = strSQL + "," + intyear + "";
                                        strSQL = strSQL + "," + intype + " ";
                                        strSQL = strSQL + ")";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                }
                                strSQL = "INSERT INTO ACC_INCENTIVE_CHILD(";
                                strSQL = strSQL + "INCENTIVE_KEY";
                                strSQL = strSQL + ",MERZE_NAME";
                                strSQL = strSQL + ",SALES_TARGET";
                                strSQL = strSQL + ",SALES_ACH";
                                strSQL = strSQL + ",ACH_PER";
                                strSQL = strSQL + ",NNTY_DEDUC";
                                strSQL = strSQL + ",COLL_TARGET";
                                strSQL = strSQL + ",COLL_ACH";
                                strSQL = strSQL + ",COLL_ACH_PER";
                                strSQL = strSQL + ",INCEN_AMOUNT";
                                strSQL = strSQL + ")";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + strincentiveKey + "' ";
                                strSQL = strSQL + ",'" + strLedgerName + "' ";
                                strSQL = strSQL + "," + dblSalesTarget + "";
                                strSQL = strSQL + "," + dblSales + "";
                                strSQL = strSQL + "," + dblSalesActPer + "";
                                strSQL = strSQL + "," + dblDededoction + "";
                                strSQL = strSQL + "," + dblCollTarget + "";
                                strSQL = strSQL + "," + dblColl + "";
                                strSQL = strSQL + "," + dblcollActPer + " ";
                                strSQL = strSQL + "," + dblIncentive + " ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                strSQL = "UPDATE MPO_COMM_MAN_PARENT_CHILD SET AMOUNT=" + dblIncentive + " ";
                                strSQL = strSQL + "FROM MPO_COMM_MAN_PARENT, MPO_COMM_MAN_PARENT_CHILD WHERE MPO_COMM_MAN_PARENT.COMM_MANUAL_KEY =MPO_COMM_MAN_PARENT_CHILD.COMM_MANUAL_KEY ";
                                strSQL = strSQL + "AND MPO_COMM_MAN_PARENT.MONTH_ID ='" + strmonthId + "' ";
                                strSQL = strSQL + "AND  MPO_COMM_MAN_PARENT_CHILD.HEAD_NAME='Incentive  For Value Target' ";
                                strSQL = strSQL + "AND MPO_COMM_MAN_PARENT_CHILD.LEDGER_NAME ='" + strLedgerName1 + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();

                                cmdInsert.Transaction.Commit();
                                intInsert += 1;

                            }
                            dblSales = 0;
                            dblSalesTarget = 0;
                            dblSalesActPer = 0;
                            dblDededoction = 0;
                            dblCollTarget = 0;
                            dblColl = 0;
                            dblcollActPer = 0;
                            dblIncentive = 0;
                            #endregion
                        }
                        else if (strType.ToUpper() == "Y")
                        {
                            MessageBox.Show("Under Constriction");
                            return;
                        }
                        else if (strType.ToUpper() == "E")
                        {
                            MessageBox.Show("Under Constriction");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return;
                    }


                }
                int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) / (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
                progressBar1.Refresh();
                using (Graphics gr = progressBar1.CreateGraphics())
                {
                    gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Red, new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                            SystemFonts.DefaultFont).Width / 2.0F), progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)));

                }
                progressBar1.Value += 1;
            }

            MessageBox.Show("Process Generation Successfully " + intInsert.ToString());
        }
        #endregion
        #region "Change"
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.Text.ToString().ToUpper() == "MPO")
            {
                lstLedgerName.ValueMember = "strRepName";
                lstLedgerName.DisplayMember = "strParentGroup";
                lstLedgerName.DataSource = accms.GetCustomerLedgeNew(strComID, "", 1).ToList();
            }
            else if (cboType.Text.ToString().ToUpper() == "AH")
            {
                lstLedgerName.ValueMember = "strRepName";
                lstLedgerName.DisplayMember = "strRepName";
                lstLedgerName.DataSource = accms.GetCustomerLedgeNew(strComID, "", 2).ToList();
            }
            else if (cboType.Text.ToString().ToUpper() == "DH")
            {
                lstLedgerName.ValueMember = "strRepName";
                lstLedgerName.DisplayMember = "strRepName";
                lstLedgerName.DataSource = accms.GetCustomerLedgeNew(strComID, "", 3).ToList();
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmIncentiveGenerateList objfrm = new frmIncentiveGenerateList();
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.MdiParent = MdiParent;
            objfrm.Show();
        }

        private void btnIncentiveConfig_Click(object sender, EventArgs e)
        {
            if (cboType.Text =="")
            {
                MessageBox.Show("Type Cannot be empty");
                cboType.Focus();
                return;
            }
            frmIncentiveConfig objfrm = new frmIncentiveConfig();
            objfrm.strType = cboType.Text;
            objfrm.MdiParent = MdiParent;
            objfrm.Show();
        }

        private void frmIncentiveGenerate_Load(object sender, EventArgs e)
        {

        }

       









    }
}
