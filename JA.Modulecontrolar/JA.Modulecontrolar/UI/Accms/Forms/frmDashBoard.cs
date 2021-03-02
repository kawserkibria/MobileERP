using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Forms;
using JA.Modulecontrolar.UI.Accms.Forms;
using Microsoft.Win32;
using System.Data.SqlClient;


namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmDashBoard : JA.Shared.UI.frmJagoronFromSearch
    {


        private ListBox lstBranch = new ListBox();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public int m_action { get; set; }
        private long mlngSLNo { get; set; }
        private string mstrOldLedger { get; set; }
        private string strComID { get; set; }
        public frmDashBoard()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            timer1.Start();
            this.txtBranch.KeyDown += new KeyEventHandler(txtBranch_KeyDown);
            this.txtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBranch_KeyPress);
            this.txtBranch.TextChanged += new System.EventHandler(this.txtBranch_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.txtBranch.GotFocus += new System.EventHandler(this.txtBranch_GotFocus);
            Utility.CreateListBox(lstBranch, pnlBranch, txtBranch);
        }


        #region User Define Code
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

        private void txtBranch_TextChanged(object sender, EventArgs e)
        {

            lstBranch.SelectedIndex = lstBranch.FindString(txtBranch.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            txtBranch.Text = lstBranch.Text;
            lstBranch.Visible = false;
            btnRefresh.Focus();
        }

        private void txtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    txtBranch.Text = lstBranch.Text;

                }
                lstBranch.Visible = false;
                btnRefresh.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                //PriorSetFocusText(txtBranch, sender, e);
            }

        }
        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            lstBranch.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranch.SelectedItem != null)
                {
                    lstBranch.SelectedIndex = lstBranch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranch.Items.Count - 1 > lstBranch.SelectedIndex)
                {
                    lstBranch.SelectedIndex = lstBranch.SelectedIndex + 1;
                }
            }

        }


        private void txtBranch_GotFocus(object sender, System.EventArgs e)
        {

            lstBranch.SelectedIndex = lstBranch.FindString(txtBranch.Text);

        }
        #endregion


        private void frmDashBoard_Load(object sender, EventArgs e)
        {


            var myDate = DateTime.Now;
            lstBranch.Visible = false;

            txtCurrentDate.Text = System.DateTime.Today.ToShortDateString();
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);
            //dteSDRWformDate.Text = firstDay.ToString();
            //dteSDRWToDate.Text = lastDay.ToString();
            //dtpFromRDW.Text = firstDay.ToString();
            //dtpToRDW.Text = lastDay.ToString();

            dteSDRWformDate.Text = Utility.gdteFinancialYearFrom;
            dteSDRWToDate.Text = Utility.gdteFinancialYearTo;
            dtpFromRDW.Text = Utility.gdteFinancialYearFrom;
            dtpToRDW.Text = Utility.gdteFinancialYearTo;

            txtCurrentDate.Text = System.DateTime.Today.ToString("dd-MM-yyyy");

            lstBranch.DisplayMember = "value";
            lstBranch.ValueMember = "Key";
            lstBranch.DataSource = new BindingSource(accms.mfillBranchNew(strComID, Utility.gblnAccessControl, Utility.gstrUserName), null);

            mCalculateAmount();

        }

        private void mCalculateAmount()
        {
            string strBranchId = "";
            if (txtBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            else
            {
                if (txtBranch.Text != "All")
                {
                    strBranchId = Utility.gstrGetBranchID(strComID, txtBranch.Text);
                }
                else
                {
                    strBranchId = "All";
                }

            }

            var myDate = DateTime.Now;
            //int year = DateTime.Now.Year;
            int year = Convert.ToDateTime(Utility.gdteFinancialYearFrom).Year;

            List<AccountsLedger> VoucherAmont = accms.mGetVoucherAmont(strComID, Utility.gdteFinancialYearFrom, Utility.gdteFinancialYearTo, year.ToString(), strBranchId).ToList();
            if (VoucherAmont.Count > 0)
            {
                txtinAmount.Text = VoucherAmont[0].dblVoucherTAmount.ToString();
                textNoOfInvoice.Text = VoucherAmont[0].dblNoVoucher.ToString();
            }


            List<AccountsLedger> TodaySalesAmont = accms.mGetVoucherTodaySalesAmont(strComID, DateTime.Now.ToString("dd/MM/yyyy"), strBranchId).ToList();
            if (TodaySalesAmont.Count > 0)
            {
                txtToDayInvAmt.Text = TodaySalesAmont[0].dblVoucherTAmountToday.ToString();
                txtToDayInvNo.Text = TodaySalesAmont[0].dblNoVoucherToday.ToString();
            }

            List<AccountsLedger> DateRangeWiseSalesAmont = accms.mGetVoucherDateRangeWiseSalesAmont(strComID, dteSDRWformDate.Text, dteSDRWToDate.Text, strBranchId).ToList();
            if (DateRangeWiseSalesAmont.Count > 0)
            {
                txtSalesAmt.Text = DateRangeWiseSalesAmont[0].dblVoucherTAmountToday.ToString();
                //txtToDayInvNo.Text = DateRangeWiseSalesAmont[0].dblNoVoucher.ToString();
            }
            List<AccountsLedger> DateRangeWiseRecevedAmont = accms.mGetVoucherDateRangeWiseRecevedAmont(strComID, dtpFromRDW.Text, dtpToRDW.Text, strBranchId).ToList();
            if (DateRangeWiseRecevedAmont.Count > 0)
            {
                txtRecAmt.Text = DateRangeWiseRecevedAmont[0].dblVoucherRecevedTAmount.ToString();

            }
            double dblCashinHand = 0, dblBakAccount = 0, dblBankOd = 0;
            dblCashinHand = accms.mGetGroupClosing(strComID, Utility.gdteFinancialYearFrom, Utility.gdteFinancialYearTo, "Cash In Hand", strBranchId);
            dblBakAccount = accms.mGetGroupClosing(strComID, Utility.gdteFinancialYearFrom, Utility.gdteFinancialYearTo, "Bank Accounts", strBranchId);
            dblBankOd = accms.mGetGroupClosing(strComID, Utility.gdteFinancialYearFrom, Utility.gdteFinancialYearTo, "Bank OD A/c", strBranchId);
            if (dblCashinHand < 0)
            {
                txtFTCashInHand.Text = Math.Abs(dblCashinHand) + " Dr";
            }
            else
            {
                txtFTCashInHand.Text = Math.Abs(dblCashinHand) + " Cr";
            }
            if (dblBakAccount < 0)
            {
                txtFTCashatBank.Text = Math.Abs(dblBakAccount) + " Dr";
            }
            else
            {
                txtFTCashatBank.Text = Math.Abs(dblBakAccount) + " Cr";
            }
            if (dblBankOd < 0)
            {
                txtBankOD.Text = Math.Abs(dblBankOd) + " Dr";
            }
            else
            {
                txtBankOD.Text = Math.Abs(dblBankOd) + " Cr";
            }


        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            mCalculateAmount();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtCurrentTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dteSDRWformDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteSDRWToDate.Focus();
            }
        }

        private void dteSDRWToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnRefresh.Focus();
            }
        }

        private void dtpFromRDW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dtpToRDW.Focus();
            }
        }

        private void dtpToRDW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnRefresh.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string strSQL = "";
            //string connstring = Utility.SQLConnstringComSwitch(strComID);
            //string strFdate= "01-01-"+ DateTime.Now.ToString("yyyy");
            //string strTdate= "31-12-"+ DateTime.Now.ToString("yyyy");

            //using (SqlConnection gcnMain = new SqlConnection(connstring))
            //{
            //    if (gcnMain.State == ConnectionState.Open)
            //    {
            //        gcnMain.Close();
            //    }
            //    gcnMain.Open();
            //    SqlCommand cmdinsert=new SqlCommand();
            //    cmdinsert.Connection=gcnMain;
            //    strSQL="ALTER VIEW SALES_TARGET_VIEW AS ";
            //    strSQL += "SELECT ACC_LEDGER_Z_D_A.ZONE,  SUM(ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT ) total,0 TARGETAMOUNT ";
            //    strSQL += "FROM ACC_LEDGER_Z_D_A,ACC_COMPANY_VOUCHER WHERE  ACC_LEDGER_Z_D_A.LEDGER_NAME=ACC_COMPANY_VOUCHER.LEDGER_NAME AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE =16 ";
            //    strSQL += "AND ACC_COMPANY_VOUCHER.BRANCH_ID ='0001' ";
            //    strSQL += "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE between " + Utility.cvtSQLDateString(strFdate) + " ";
            //    strSQL += "AND " + Utility.cvtSQLDateString(strTdate) + " ";
            //    strSQL += "AND ACC_LEDGER_Z_D_A.LEDGER_STATUS =0";
            //    strSQL += "group by ACC_LEDGER_Z_D_A.ZONE ";
            //    strSQL += "UNION ALL ";
            //    strSQL += "select V.ZONE,0 total,   ";
            //    strSQL += "sum(TARGET_CHANGE_AMNT) TARGETAMOUNT from SALES_TARGET_ACHIEVEMENT ST,ACC_LEDGER_Z_D_A V ";
            //    strSQL += "where ST.LEDGER_NAME=V.LEDGER_NAME and  TARGET_ACHIEVE_FROM_DATE >= " + Utility.cvtSQLDateString(strFdate) + "  and TARGET_ACHIEVE_TO_DATE<=" + Utility.cvtSQLDateString(strTdate) + " ";
            //    strSQL += "AND V.LEDGER_STATUS =0 AND v.BRANCH_ID ='0001' group by V.ZONE ";
            //    cmdinsert.CommandText=strSQL;
            //    cmdinsert.ExecuteNonQuery();

            //    //string query = "SELECT ACC_LEDGER_Z_D_A.ZONE,  SUM(ACC_COMPANY_VOUCHER.COMP_VOUCHER_NET_AMOUNT ) total ";
            //    //query += "FROM ACC_LEDGER_Z_D_A,ACC_COMPANY_VOUCHER WHERE ACC_LEDGER_Z_D_A.LEDGER_NAME=ACC_COMPANY_VOUCHER.LEDGER_NAME AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_TYPE =16 ";
            //    //query += "AND ACC_COMPANY_VOUCHER.BRANCH_ID ='0001' ";
            //    //query += "AND ACC_COMPANY_VOUCHER.COMP_VOUCHER_DATE between " + Utility.cvtSQLDateString(strFdate) + " ";
            //    //query += "AND " + Utility.cvtSQLDateString(strTdate) + " ";
            //    //query += "group by ACC_LEDGER_Z_D_A.ZONE ORDER BY ACC_LEDGER_Z_D_A.ZONE ";

            //    string query = "SELECT ZONE,ISNULL(SUM(total),0)total,ISNULL(SUM(TARGETAMOUNT),0) TARGETAMOUNT, (CASE WHEN ISNULL(SUM(TARGETAMOUNT),0) > 0 THEN ISNULL(SUM(total),0)/ISNULL(SUM(TARGETAMOUNT),0) *100  ELSE 0 END)ACH ";
            //    query +=" FROM SALES_TARGET_VIEW ";
            //    query += "GROUP BY ZONE ";


               
            //    //DataTable dt = GetData(query)
            //    DataTable dt;
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter da = new SqlDataAdapter(query, gcnMain);
            //    da.Fill(ds);
            //    dt = ds.Tables[0];
            //    if (dt.Rows.Count > 0)
            //    {
            //        try
            //        {

            //            Chart1.DataSource = ds;
            //            Chart1.Series["Sales"].XValueMember = "ZONE";
            //            //set the member columns of the chart data source used to data bind to the X-values of the series  
            //            Chart1.Series["Sales"].YValueMembers = "total";
            //            Chart1.Series["Sales"].Label = "5";
            //            Chart1.Series["Sales"].Label = "5";

            //            //foreach (DataRow row in dt.Rows)
                    
            //            //{
            //            //    double dblPer = Utility.Val(row["ACH"].ToString());
            //            //    Chart1.Series["Sales"].LegendText = dblPer + "%";
            //            //    Chart1.Series["Sales"].Label = dblPer + "%";
            //            //}
            //            //Chart1.Titles.Add("Sales for the date of "+ strFdate + " to" + strTdate );
            //            gcnMain.Close();
                       
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}
        }

    }
}
