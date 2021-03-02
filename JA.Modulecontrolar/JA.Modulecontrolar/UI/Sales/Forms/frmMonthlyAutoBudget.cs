using Dutility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
using System.Data.SqlClient;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmMonthlyAutoBudget : JA.Shared.UI.frmSmartFormStandard
    {
      
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strFromDate { get; set; }
        public  string strToDate { get; set; }
        public long lngFormPriv { get; set; }
        public string strType { get; set; }
        public int m_action { get; set; }
        private string strComID { get; set; }
        private ListBox lstLedgerName = new ListBox();
        public frmMonthlyAutoBudget()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteFromdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromdate_KeyPress);
            this.dteFromdate.GotFocus += new System.EventHandler(this.dteFromdate_GotFocus);

            this.txtLedgerName.GotFocus += new System.EventHandler(this.txtLedgerName_GotFocus);
            this.txtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLedgerName_KeyPress);
            this.txtLedgerName.TextChanged += new System.EventHandler(this.txtLedgerName_TextChanged);
            this.txtLedgerName.KeyDown += new KeyEventHandler(txtLedgerName_KeyDown);
            this.lstLedgerName.DoubleClick += new System.EventHandler(this.lstLedgerName_DoubleClick);
            Utility.CreateListBoxHeight(lstLedgerName, pnlMain, txtLedgerName, 0, 100);
           
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
        #region "User Deifine"
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
                    btnSave.Focus();
                }
                else
                {
                    lstLedgerName.Visible = false;
                    btnSave.Focus();
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
        private void dteFromdate_GotFocus(object sender, System.EventArgs e)
        {

            lstLedgerName.Visible = false;

        }
        private void txtLedgerName_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerName.Visible = true;

        }
       
        private void dteFromdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtLedgerName.Focus();
            }
        }
       
        #endregion
        private void frmMonthlyAutoBudget_Load(object sender, EventArgs e)
        {
            dteFDate.Text = strFromDate;
            dteTDate.Text =strToDate;
         
            lstLedgerName.ValueMember = "strLedgerName";
            lstLedgerName.DisplayMember = "strmerzeString";
            lstLedgerName.DataSource = accms.mFillLedgerStatus(strComID, 202, 0).ToList();
           
            dteFromdate.Focus();
            dteFromdate.Select();
        }
        #region "click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strLedgerName = "", strPreviousFDate = "", strPreviousTdate = "";
            string strNextFdate = "", strNextTdate = "", strSQl = "",strMonthID="",strmsg="", strNextDate="";
            double dblTargetForMonth = 0;
            double dblSalesTarget = 0, dblSales = 0, dblPending = 0, dblMonthlyInstallment = 0;
            double dblPartial = 0;
            double dblCollAmnt = 0, dblCollTarget = 0;
            int intMode = 3,intCount=0;
            SqlCommand cmdInsert = new SqlCommand();
            SqlTransaction myTrans;
            SqlDataReader DR;
            if (dteFromdate.Value.Month == 11)
            {
                intMode = 2;
            }
            else if (dteFromdate.Value.Month == 12)
            {
                intMode = 1;
            }
            else
            {
                intMode = 3;
            }
            if (txtLedgerName.Text != "")
            {
                strLedgerName = lstLedgerName.SelectedValue.ToString();
            }
            else
            {
                strLedgerName = "";
            }
            if (dteFromdate.Value.Month == 1)
            {
                MessageBox.Show("First Month Cannot be Generate for Budget");
                dteFromdate.Focus();
                return;
            }
            strPreviousFDate = Utility.FirstDayOfMonth(dteFromdate.Value.AddMonths(-1)).ToString("dd-MM-yyyy");
            strPreviousTdate = Utility.LastDayOfMonth(dteFromdate.Value.AddMonths(-1)).ToString("dd-MM-yyyy");
            long lngDate = Convert.ToInt64(Convert.ToDateTime(dteFromdate.Text).ToString("yyyyMMdd"));
            long lngFiscalYearfrom = Convert.ToInt64(Convert.ToDateTime(dteFDate.Text).ToString("yyyyMMdd"));
            long lngFiscalYearTo = Convert.ToInt64(Convert.ToDateTime(dteTDate.Text).ToString("yyyyMMdd"));

            if (lngDate < lngFiscalYearfrom)
            {
                MessageBox.Show("Invalid Date, Date Can't less then Process Date");
                return;
            }
            if (lngDate > lngFiscalYearTo)
            {
                MessageBox.Show("Invalid Date, Date Can't less then Process Date");
                return;
            }
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            var strResponseInsert = MessageBox.Show("Do You Want to Generate this voucher?", "Budget Voucher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.No)
            {
                return;
            }
            try
            {
                List<AccountsLedger> ledger = accms.GetCustomerLedgerNew(strComID, strLedgerName).ToList();
                if (ledger.Count > 0)
                {
                    progressBar1.Value = 0;
                    progressBar1.Maximum = ledger.Count;
                    using (SqlConnection gcnMain = new SqlConnection(connstring))
                    {
                        if (gcnMain.State == ConnectionState.Open)
                        {
                            gcnMain.Close();
                        }

                        gcnMain.Open();
                       
                        foreach (AccountsLedger objLegder in ledger)
                        {
                            if (strType == "TA")
                            {
                                //Target
                                dblSalesTarget = Utility.gdblTargetAmnt(strComID, objLegder.strRepName, strPreviousFDate, strPreviousTdate, Convert.ToDateTime(strPreviousFDate).ToString("MMMyy"));
                                dblSales = Utility.gdblBillAmountforLedger(strComID, objLegder.strRepName, strPreviousFDate, strPreviousTdate);
                                dblPending = Math.Round(dblSalesTarget - dblSales, 2);
                                dblMonthlyInstallment = Math.Round(dblPending / intMode, 2);
                                strNextDate = dteFromdate.Value.ToString("dd-MM-yyyy");
                               
                                string strUniqueKey = objLegder.strRepName + dteFromdate.Value.ToString("MMMyy");
                                dblPartial = dblMonthlyInstallment;
                                for (int intRow = 1; intRow <= intMode; intRow++)
                                {


                                    strNextFdate = Utility.FirstDayOfMonth(Convert.ToDateTime(strNextDate)).ToString("dd-MM-yyyy");
                                    strNextTdate = Utility.LastDayOfMonth(Convert.ToDateTime(strNextDate)).ToString("dd-MM-yyyy");
                                    strMonthID = Convert.ToDateTime(strNextFdate).ToString("MMMyy").ToUpper();
                                    dblTargetForMonth = Utility.gdblTargetAmnt(strComID, objLegder.strRepName, strNextFdate, strNextTdate, strMonthID);
                                    dblTargetForMonth = Math.Round(dblTargetForMonth + dblMonthlyInstallment, 2);

                                    //MessageBox.Show(strNextDate);
                                    myTrans = gcnMain.BeginTransaction();
                                    cmdInsert.Connection = gcnMain;
                                    cmdInsert.Transaction = myTrans;
                                    strSQl = "DELETE FROM TARGET_ACHIEVEMENT_CH ";
                                    strSQl = strSQl + "WHERE LEDGER_NAME='" + objLegder.strRepName + "' ";
                                    strSQl = strSQl + "AND MONTH_ID='" + strMonthID + "' ";
                                    strSQl = strSQl + "AND CH_TYPE =1 ";
                                    strSQl = strSQl + "AND UNIQUE_KEY ='" + strUniqueKey + "' ";
                                    strSQl = strSQl + "AND FLAG_TYPE ='ACTUAL' ";
                                    cmdInsert.CommandText = strSQl;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQl = "INSERT INTO TARGET_ACHIEVEMENT_CH(UNIQUE_KEY,LEDGER_NAME,MONTH_ID,TARGET_AMOUNT,CH_TYPE,FLAG_TYPE) ";
                                    strSQl = strSQl + "VALUES(";
                                    strSQl = strSQl + "'" + strUniqueKey + "' ";
                                    strSQl = strSQl + ",'" + objLegder.strRepName + "' ";
                                    strSQl = strSQl + ",'" + strMonthID + "' ";
                                    strSQl = strSQl + "," + dblMonthlyInstallment + " ";
                                    strSQl = strSQl + ",1,'ACTUAL')";
                                    cmdInsert.CommandText = strSQl;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQl = "SELECT ISNULL(SUM(TARGET_AMOUNT),0) AMNT from TARGET_ACHIEVEMENT_CH ";
                                    strSQl = strSQl + "WHERE LEDGER_NAME='" + objLegder.strRepName.Replace("'", "''") + "' ";
                                    strSQl = strSQl + "AND MONTH_ID='" + strMonthID + "' ";
                                    strSQl = strSQl + "AND FLAG_TYPE ='ACTUAL' ";
                                    cmdInsert.CommandText = strSQl;
                                    DR = cmdInsert.ExecuteReader();
                                    if (DR.Read())
                                    {
                                        dblPartial = Convert.ToDouble(DR["AMNT"]);
                                    }
                                    DR.Close();
                                    strSQl = "UPDATE SALES_TARGET_ACHIEVEMENT SET TARGET_CHANGE_AMNT=" + dblPartial + " ";
                                    strSQl = strSQl + "WHERE LEDGER_NAME='" + objLegder.strRepName.Replace("'", "''") + "' ";
                                    strSQl = strSQl + "AND TARGET_ACHIEVE_MONTH_ID='" + strMonthID + "' ";
                                    cmdInsert.CommandText = strSQl;
                                    cmdInsert.ExecuteNonQuery();


                                    cmdInsert.Transaction.Commit();
                                    strNextDate = Convert.ToDateTime(strNextDate).AddMonths(1).ToString("dd-MM-yyyy");
                                    dblTargetForMonth = 0;
                                    dblPartial = 0;
                                }
                                dblSalesTarget = 0;
                                dblSales = 0;
                                dblPending = 0;
                                dblMonthlyInstallment = 0;
                            }
                            else
                            {
                                //Collection
                                
                                dblCollTarget = Utility.gdblCollTargetAmnt(strComID, objLegder.strRepName, strPreviousFDate, strPreviousTdate, Convert.ToDateTime(strPreviousFDate).ToString("MMMyy"));
                                dblCollAmnt = Utility.gdblCollectionAmountforLedger(strComID, objLegder.strRepName, strPreviousFDate, strPreviousTdate);
                                dblPending = Math.Round(dblCollTarget - dblCollAmnt, 2);
                                if (dblPending > 0)
                                {
                                    dblMonthlyInstallment = Math.Round(dblPending / intMode, 2);
                                }
                                else
                                {
                                    dblMonthlyInstallment = 0;
                                }
                                strNextDate = dteFromdate.Value.ToString("dd-MM-yyyy");

                                string strUniqueKey = objLegder.strRepName + dteFromdate.Value.ToString("MMMyy");
                                dblPartial = dblMonthlyInstallment;
                                for (int intRow = 1; intRow <= intMode; intRow++)
                                {


                                    strNextFdate = Utility.FirstDayOfMonth(Convert.ToDateTime(strNextDate)).ToString("dd-MM-yyyy");
                                    strNextTdate = Utility.LastDayOfMonth(Convert.ToDateTime(strNextDate)).ToString("dd-MM-yyyy");
                                    strMonthID = Convert.ToDateTime(strNextFdate).ToString("MMMyy").ToUpper();
                                    dblTargetForMonth = Utility.gdblCollTargetAmnt(strComID, objLegder.strRepName, strNextFdate, strNextTdate, strMonthID);

                                    dblTargetForMonth = Math.Round(dblTargetForMonth + dblMonthlyInstallment, 2);

                                    //MessageBox.Show(strNextDate);
                                    myTrans = gcnMain.BeginTransaction();
                                    cmdInsert.Connection = gcnMain;
                                    cmdInsert.Transaction = myTrans;
                                    strSQl = "DELETE FROM TARGET_ACHIEVEMENT_CH ";
                                    strSQl = strSQl + "WHERE LEDGER_NAME='" + objLegder.strRepName + "' ";
                                    strSQl = strSQl + "AND MONTH_ID='" + strMonthID + "' ";
                                    strSQl = strSQl + "AND CH_TYPE =1 ";
                                    strSQl = strSQl + "AND UNIQUE_KEY ='" + strUniqueKey + "' ";
                                    strSQl = strSQl + "AND FLAG_TYPE ='CT' ";
                                    cmdInsert.CommandText = strSQl;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQl = "INSERT INTO TARGET_ACHIEVEMENT_CH(UNIQUE_KEY,LEDGER_NAME,MONTH_ID,TARGET_AMOUNT,CH_TYPE,FLAG_TYPE) ";
                                    strSQl = strSQl + "VALUES(";
                                    strSQl = strSQl + "'" + strUniqueKey + "' ";
                                    strSQl = strSQl + ",'" + objLegder.strRepName + "' ";
                                    strSQl = strSQl + ",'" + strMonthID + "' ";
                                    strSQl = strSQl + "," + dblMonthlyInstallment + " ";
                                    strSQl = strSQl + ",1,'CT')";
                                    cmdInsert.CommandText = strSQl;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQl = "SELECT ISNULL(SUM(TARGET_AMOUNT),0) AMNT from TARGET_ACHIEVEMENT_CH ";
                                    strSQl = strSQl + "WHERE LEDGER_NAME='" + objLegder.strRepName.Replace("'", "''") + "' ";
                                    strSQl = strSQl + "AND MONTH_ID='" + strMonthID + "' ";
                                    strSQl = strSQl + "AND FLAG_TYPE ='CT' ";
                                    cmdInsert.CommandText = strSQl;
                                    DR = cmdInsert.ExecuteReader();
                                    if (DR.Read())
                                    {
                                        dblPartial = Convert.ToDouble(DR["AMNT"]);
                                    }
                                    DR.Close();
                                    strSQl = "UPDATE SALES_COLL_TARGET_TRAN SET TARGET_CHANGE_AMNT=" + dblPartial + " ";
                                    strSQl = strSQl + "WHERE LEDGER_NAME='" + objLegder.strRepName.Replace("'", "''") + "' ";
                                    strSQl = strSQl + "AND MONTH_ID='" + strMonthID + "' ";
                                    cmdInsert.CommandText = strSQl;
                                    cmdInsert.ExecuteNonQuery();


                                    cmdInsert.Transaction.Commit();
                                    strNextDate = Convert.ToDateTime(strNextDate).AddMonths(1).ToString("dd-MM-yyyy");
                                    dblTargetForMonth = 0;
                                    dblPartial = 0;
                                }
                                dblCollAmnt = 0;
                                dblCollTarget  = 0;
                                dblPending = 0;
                                dblMonthlyInstallment = 0;
                                //End

                            }
                            int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) / (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
                            progressBar1.Refresh();
                            using (Graphics gr = progressBar1.CreateGraphics())
                            {
                                gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Red, new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                                        SystemFonts.DefaultFont).Width / 2.0F), progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)));

                            }
                            progressBar1.Value += 1;
                            intCount += 1;
                        }
                      
                        MessageBox.Show(intCount + " Records Undo Successfully..");
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {

           

        }

       
        #endregion
        
       




















    }
}
