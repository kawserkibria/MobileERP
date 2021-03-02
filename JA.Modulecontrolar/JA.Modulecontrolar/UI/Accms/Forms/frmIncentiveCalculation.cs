using Dutility;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Tools.Forms;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmIncentiveCalculation : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public int m_action { get; set; }
        public long lngFormPriv { get; set; }

        int intyear = 0;
        public delegate void AddAllClick(List<IncentiveCal> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public frmIncentiveCalculation()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtMonthlySales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtMonthlySales_KeyPress);
            this.txtMonthlyCollection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtMonthlyCollection_KeyPress);
            this.txtMonthlyIncentive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtMonthlyIncentive_KeyPress);

            this.txtyearIncBudget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtyearIncBudget_KeyPress);
            this.txtyearIncBouns.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtyearIncBouns_KeyPress);
            this.txtyearIncMPO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtyearIncMPO_KeyPress);
            this.txtyearIncAH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtyearIncAH_KeyPress);
            this.txtyearIncDH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtyearIncDH_KeyPress);

            this.txtExtBudget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtExtBudget_KeyPress);
            this.txtExtMPO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtExtMPO_KeyPress);
            this.txtExtAH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtExtAH_KeyPress);
            this.txtExtDH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtExtDH_KeyPress);

            this.dteFdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtefDate_KeyPress);
            this.dteTdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.cboType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboType_KeyPress);

            this.dteMFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteMFromDate_KeyPress);
            this.dteTFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteTFromDate_KeyPress);

            this.dteYealyDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteYealyDate_KeyPress);
            this.dteYearlyExtraDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteYearlyExtraDate_KeyPress);
            
        }
        #region "User Defind code"
        private void dteYearlyExtraDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtExtBudget.Focus();
            }
        }

        private void dteYealyDate_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                txtyearIncBudget.Focus();
            }
        }
        private void dteMFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                dteTFromDate.Focus();
            }
        }
        private void dteTFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                txtMonthlySales.Focus();
            }
        }
        private void txtyearIncBudget_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Return)
            {

                if (txtyearIncBudget.Text == "")
                {
                    dteYearlyExtraDate.Focus();
                }
                else
                {
                    txtyearIncBouns.Focus();
                }

            }

        }
        private void txtExtBudget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtExtBudget.Text == "")
                {
                    btnSave.Focus();
                }
                else
                {
                    txtExtMPO.Focus();
                }
          

            }

        }

        private void dteDate_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (e.KeyChar == (char)Keys.Return)
            {
                cboType.Focus();
            }
        }
        private void cboType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                dteMFromDate.Focus();

            }

        }
        private void dtefDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                dteTdate.Focus();

            }

        }
        private void dteTdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                cboType.Focus();

            }

        }
        private void txtMonthlySales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (txtMonthlySales.Text == "")
                {
                    dteYealyDate.Focus();
                }
                else
                {
                    txtMonthlyCollection.Focus();
                }

            }

        }
        private void txtMonthlyCollection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
             
                txtMonthlyIncentive.Focus();

            }

        }
        private void txtMonthlyIncentive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnMonthlyAdd.Focus();

            }

        }


        private void txtyearIncBouns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                txtyearIncMPO.Focus();

            }

        }
        private void txtyearIncMPO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                txtyearIncAH.Focus();

            }
        }
        private void txtyearIncAH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                txtyearIncDH.Focus();

            }
        }
        private void txtyearIncDH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnYear.Focus();

            }
 
        }


        private void txtExtMPO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                txtExtAH.Focus();

            }
   
        }
        private void txtExtAH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                txtExtDH.Focus();

            }

        }
        private void txtExtDH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnYealyExtra.Focus();

            }

        }
        #endregion
        private void frmIncentiveCalculation_Load(object sender, EventArgs e)
        {
            DGMonth.AllowUserToAddRows = false;
            DGYear.AllowUserToAddRows = false;
            DGYearE.AllowUserToAddRows = false;
            dteFdate.Text = "01-01-" + dteFdate.Value.ToString("yyyy");
            dteTdate.Text = "30-11-" + dteFdate.Value.ToString("yyyy");
            dteYealyDate.Text = "31-12-" + dteMFromDate.Value.ToString("yyyy");
            dteYearlyExtraDate.Text = "31-12-" + dteMFromDate.Value.ToString("yyyy");

            DGMonth.Columns.Add(Utility.Create_Grid_Column("Type", "Type", 60, true, DataGridViewContentAlignment.TopLeft, true));
            DGMonth.Columns.Add(Utility.Create_Grid_Column("Month", "Month", 170, true, DataGridViewContentAlignment.TopLeft, true));
            DGMonth.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 100, false, DataGridViewContentAlignment.TopLeft, true));
            DGMonth.Columns.Add(Utility.Create_Grid_Column("Sales(%)", "Sales(%)", 80, true, DataGridViewContentAlignment.TopLeft, true));
            DGMonth.Columns.Add(Utility.Create_Grid_Column("Coll.(%)", "Coll.(%))", 80, true, DataGridViewContentAlignment.TopLeft, true));
            DGMonth.Columns.Add(Utility.Create_Grid_Column("Incentive(%)", "Incentive(%))", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DGMonth.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DGMonth.Columns.Add(Utility.Create_Grid_Column("", "", 100, false, DataGridViewContentAlignment.TopLeft, true));

            DGYear.Columns.Add(Utility.Create_Grid_Column("Month", "Month", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DGYear.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 100, false, DataGridViewContentAlignment.TopLeft, true));
            DGYear.Columns.Add(Utility.Create_Grid_Column("Budget", "Budget", 50, true, DataGridViewContentAlignment.TopLeft, true));
            DGYear.Columns.Add(Utility.Create_Grid_Column("Bonus", "Bonus", 50, true, DataGridViewContentAlignment.TopLeft, true));
            DGYear.Columns.Add(Utility.Create_Grid_Column("MPO(%)", "MPO(%)", 60, true, DataGridViewContentAlignment.TopLeft, true));
            DGYear.Columns.Add(Utility.Create_Grid_Column("AH(%)", "AH(%))", 50, true, DataGridViewContentAlignment.TopLeft, true));
            DGYear.Columns.Add(Utility.Create_Grid_Column("DH(%)", "DH(%))", 50, true, DataGridViewContentAlignment.TopLeft, true));
            DGYear.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DGYear.Columns.Add(Utility.Create_Grid_Column("", "", 100, false, DataGridViewContentAlignment.TopLeft, true));

            DGYearE.Columns.Add(Utility.Create_Grid_Column("Month", "Month", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DGYearE.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 80, false, DataGridViewContentAlignment.TopLeft, true));
            DGYearE.Columns.Add(Utility.Create_Grid_Column("Budget", "Budget", 50, true, DataGridViewContentAlignment.TopLeft, true));
            DGYearE.Columns.Add(Utility.Create_Grid_Column("MPO(%)", "MPO(%)", 75, true, DataGridViewContentAlignment.TopLeft, true));
            DGYearE.Columns.Add(Utility.Create_Grid_Column("AH(%)", "AH(%))", 65, true, DataGridViewContentAlignment.TopLeft, true));
            DGYearE.Columns.Add(Utility.Create_Grid_Column("DH(%)", "DH(%))", 65, true, DataGridViewContentAlignment.TopLeft, true));
            DGYearE.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DGYearE.Columns.Add(Utility.Create_Grid_Column("", "", 100, false, DataGridViewContentAlignment.TopLeft, true));
        }

        private void btnMonthlyAdd_Click(object sender, EventArgs e)
        {
            if (cboType.Text == "")
            {
                MessageBox.Show("Type Cannot be Empty");
                cboType.Focus();
                return;
            }
            string strmonth = "";
            long intCompare = 0;
            int intMonth = dteMFromDate.Value.Month;
            intCompare = Utility.DateDiff(Utility.DateInterval.Month, dteMFromDate.Value, dteTFromDate.Value) + 1;
            for (int introw = 0; introw < intCompare;introw++ )
            {
                strmonth = intMonth + "," + strmonth;
                intMonth += 1;
            }
            if (strmonth != "")
            {
                strmonth = Utility.Mid(strmonth, 0, strmonth.Length - 1);
            }
            mAddMonthlyIncentive(DGMonth, cboType.Text, dteMFromDate.Text, dteTFromDate.Text, Utility.Val(txtMonthlySales.Text),
                                  Utility.Val(txtMonthlyCollection.Text), Utility.Val(txtMonthlyIncentive.Text),strmonth);
            txtMonthlySales.Text = "";
            txtMonthlyCollection.Text = "";
            txtMonthlyIncentive.Text = "";
            dteMFromDate.Focus();
        }

        private void mAddMonthlyIncentive(DataGridView dg, string vstrType, string vstrFDate, string vstrTDate, double dblSales, double dblColl, double dblIncentive,string strEffectiveMonth)
        {
            int selRaw;

            dg.AllowUserToAddRows = true;
            selRaw = Convert.ToInt16(dg.RowCount.ToString());
            selRaw = selRaw - 1;
            dg.Rows.Add();
            dg[0, selRaw].Value = vstrType;
            dg[1, selRaw].Value = Convert.ToDateTime(vstrFDate).ToString("MMMyy").ToUpper() + " to " + Convert.ToDateTime(vstrTDate).ToString("MMMyy").ToUpper();
            dg[2, selRaw].Value = vstrTDate;
            dg[3, selRaw].Value = dblSales;
            dg[4, selRaw].Value = dblColl;
            dg[5, selRaw].Value = dblIncentive;
            dg[6, selRaw].Value = "Delete";
            dg[7, selRaw].Value = strEffectiveMonth;
            dg.AllowUserToAddRows = false;
            dg.ClearSelection();
            int nColumnIndex = 2;
            int nRowIndex = dg.Rows.Count - 1;
            dg.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
            dg.FirstDisplayedScrollingRowIndex = nRowIndex;
        }
        private void mAddYearlyIncentive(DataGridView dg, string vstrFDate, string vstrTDate, double dblIncenBudget, 
                                            long lngNoofBonus, double dblIncenMpo, double dblIncenAH, double dblIncenDH,string strMonthEfftive)
        {
            int selRaw;


            dg.AllowUserToAddRows = true;
            selRaw = Convert.ToInt16(dg.RowCount.ToString());
            selRaw = selRaw - 1;
            dg.Rows.Add();
            dg[0, selRaw].Value = Convert.ToDateTime(vstrFDate).ToString("MMMyy").ToUpper() + " to " + Convert.ToDateTime(vstrTDate).ToString("MMMyy").ToUpper();
            dg[1, selRaw].Value = vstrTDate;
            dg[2, selRaw].Value = dblIncenBudget;
            dg[3, selRaw].Value = lngNoofBonus;
            dg[4, selRaw].Value = dblIncenMpo;
            dg[5, selRaw].Value = dblIncenAH;
            dg[6, selRaw].Value = dblIncenDH;
            dg[7, selRaw].Value = "Delete";
            dg[8, selRaw].Value = strMonthEfftive ;
            dg.AllowUserToAddRows = false;
            dg.ClearSelection();
            int nColumnIndex = 2;
            int nRowIndex = dg.Rows.Count - 1;
            dg.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
            dg.FirstDisplayedScrollingRowIndex = nRowIndex;
        }
        private void mAddYearlyExtraIncentive(DataGridView dg, string vstrFDate, string vstrTDate, double dblIncenBudget, double dblIncenMpo, double dblIncenAH, double dblIncenDH, string strMonthEfftive)
        {
            int selRaw;


            dg.AllowUserToAddRows = true;
            selRaw = Convert.ToInt16(dg.RowCount.ToString());
            selRaw = selRaw - 1;
            dg.Rows.Add();
            dg[0, selRaw].Value = Convert.ToDateTime(vstrFDate).ToString("MMMyy").ToUpper() + " to " + Convert.ToDateTime(vstrTDate).ToString("MMMyy").ToUpper();
            dg[1, selRaw].Value = vstrTDate;
            dg[2, selRaw].Value = dblIncenBudget;
            dg[3, selRaw].Value = dblIncenMpo;
            dg[4, selRaw].Value = dblIncenAH;
            dg[5, selRaw].Value = dblIncenDH;
            dg[6, selRaw].Value = "Delete";
            dg[7, selRaw].Value = strMonthEfftive;
            dg.AllowUserToAddRows = false;
            dg.ClearSelection();
            int nColumnIndex = 2;
            int nRowIndex = dg.Rows.Count - 1;
            dg.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
            dg.FirstDisplayedScrollingRowIndex = nRowIndex;
        }
        private void DGMonth_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                DGMonth.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnYear_Click(object sender, EventArgs e)
        {

            string strmonth = "";
            long intCompare = 0;
            int intMonth = dteMFromDate.Value.Month;
            intCompare = Utility.DateDiff(Utility.DateInterval.Month, dteYealyDate.Value, dteYealyDate.Value) + 1;
            for (int introw = 0; introw < intCompare; introw++)
            {
                strmonth = intMonth + "," + strmonth;
                intMonth += 1;
            }
            if (strmonth != "")
            {
                strmonth = Utility.Mid(strmonth, 0, strmonth.Length - 1);
            }
            mAddYearlyIncentive(DGYear, Utility.FirstDayOfMonth(dteYealyDate.Value).ToString("dd-MM-yyyy"), dteYealyDate.Text, 
                                Convert.ToInt64(txtyearIncBudget.Text), Convert.ToInt64(txtyearIncBouns.Text),
                                Utility.Val(txtyearIncMPO.Text),
                                Utility.Val(txtyearIncAH.Text), Utility.Val(txtyearIncDH.Text),strmonth);
            txtyearIncBudget.Text = "";
            txtyearIncBouns.Text = "";
            txtyearIncMPO.Text = "";
            txtyearIncAH.Text = "";
            txtyearIncDH.Text = "";
            dteYealyDate.Focus();
        }

        private void btnYealyExtra_Click(object sender, EventArgs e)
        {
            string strmonth = "";
            long intCompare = 0;
            int intMonth = dteMFromDate.Value.Month;
            intCompare = Utility.DateDiff(Utility.DateInterval.Month, dteYearlyExtraDate.Value, dteYearlyExtraDate.Value) + 1;
            for (int introw = 0; introw < intCompare; introw++)
            {
                strmonth = intMonth + "," + strmonth;
                intMonth += 1;
            }
            if (strmonth != "")
            {
                strmonth = Utility.Mid(strmonth, 0, strmonth.Length - 1);
            }
            mAddYearlyExtraIncentive(DGYearE, Utility.FirstDayOfMonth(dteYearlyExtraDate.Value).ToString("dd-MM-yyyy"), dteYearlyExtraDate.Text,
                                    Utility.Val(txtExtBudget.Text), Utility.Val(txtExtMPO.Text),
                                    Utility.Val(txtExtAH.Text), Utility.Val(txtExtDH.Text), strmonth);
            txtExtBudget.Text = "";
            txtExtMPO.Text = "";
            txtExtAH.Text = "";
            txtExtDH.Text = "";
            dteYearlyExtraDate.Focus();
        }

        private void cboType_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void DGYear_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                DGYear.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void DGyearExtra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        private void mClear()
        {

            DGMonth.Rows.Clear();
            DGYear.Rows.Clear();
            DGYearE.Rows.Clear();
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            cboType.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strDGMonth = "", strDGYear = "", DGyearExtra = "", i = "", strMode = "";
            int intYear = 0;

         
            intYear = dteFdate.Value.Year;
            try
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (DGMonth.Rows.Count > 0)
                {
                    for (int introw = 0; introw < DGMonth.Rows.Count; introw++)
                    {

                        strDGMonth = strDGMonth + DGMonth[0, introw].Value + "|" +
                            DGMonth[1, introw].Value.ToString() + "|" + DGMonth[2, introw].Value.ToString() + "|" +
                                           DGMonth[3, introw].Value.ToString() + "|" + DGMonth[4, introw].Value.ToString() + "|" +
                                           DGMonth[5, introw].Value.ToString() + "|"+ DGMonth[7, introw].Value.ToString() +  "~";
                    }
                }
                if (DGYear.Rows.Count > 0)
                {
                    for (int introw = 0; introw < DGYear.Rows.Count; introw++)
                    {


                        strDGYear = strDGYear + DGYear[0, introw].Value + "|" + DGYear[1, introw].Value.ToString() + "|" +
                            DGYear[2, introw].Value.ToString() + "|" + DGYear[3, introw].Value.ToString() + "|" +
                                           DGYear[4, introw].Value.ToString() + "|" + DGYear[5, introw].Value.ToString() + "|" +
                                           DGYear[6, introw].Value.ToString() +"|" + DGYear[8, introw].Value.ToString()  + "~";
                    }

                }
                if (DGYearE.Rows.Count > 0)
                {
                    for (int introw = 0; introw < DGYearE.Rows.Count; introw++)
                    {


                        DGyearExtra = DGyearExtra + DGYearE[0, introw].Value + "|" + DGYearE[1, introw].Value.ToString() + "|" +
                            DGYearE[2, introw].Value.ToString() + "|" + DGYearE[3, introw].Value.ToString() + "|" + DGYearE[4, introw].Value.ToString() + "|" +
                                           DGYearE[5, introw].Value.ToString() + "|" + DGYearE[7, introw].Value.ToString() + "~";

                    }
                }

                i = accms.mInsertIncentiveCalculation(strComID, dteFdate.Text, dteTdate.Text, intYear, strDGMonth, strDGYear, DGyearExtra, m_action);
               
                if (i == "1")
                {
                    mClear();
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Incentive Calculation", "Incentive Calculation",
                                                                m_action, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                    }
                }
                else
                {
                    MessageBox.Show(i.ToString());
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmIncentiveCalculationList objfrm = new frmIncentiveCalculationList();
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.onAddAllButtonClicked = new frmIncentiveCalculationList.AddAllClick(DisplayList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }

 
        private void DisplayList(List<IncentiveCal> tests, object sender, EventArgs e)
        {
            try
            {
                int introw = 0;
                cboType.Text = "";
                m_action = 2;
                intyear = Convert.ToInt32( tests[0].intYear.ToString());
                dteFdate.Text = Convert.ToDateTime(tests[0].strFdate).ToString("dd/MM-yyyy");
                dteTdate.Text = Convert.ToDateTime(tests[0].strTdate).ToString("dd/MM-yyyy");
                List<IncentiveCal> ooaccVouddd = accms.mDisplayIncentive(strComID, intyear,"M").ToList();
                if (ooaccVouddd.Count > 0)
                {

                    int inttype = 0;

                    foreach (IncentiveCal oacc in ooaccVouddd)
                    {
                        DGMonth.Rows.Add();
                        inttype = oacc.intType;
                        if (inttype == 1)
                        {
                            DGMonth[0, introw].Value = "MPO";
                        }
                        else if (inttype == 2)
                        {
                            DGMonth[0, introw].Value = "AH";
                        }
                        else
                        {
                            DGMonth[0, introw].Value = "DH";
                        }
                        DGMonth[1, introw].Value = oacc.strParticulars;
                        DGMonth[2, introw].Value = oacc.strTdate;
                        DGMonth[3, introw].Value = oacc.dblMnothSales;
                        DGMonth[4, introw].Value = oacc.dblMnothColl;
                        DGMonth[5, introw].Value = oacc.dblMnothInc;
                        DGMonth[6, introw].Value = "Delete";
                        DGMonth[7, introw].Value = oacc.strEffetiveMonth;
                        DGMonth.AllowUserToAddRows = false;
                        introw += 1;
                    }
                    DGMonth.AllowUserToAddRows = false;
                }


                List<IncentiveCal> ooaccVYear = accms.mDisplayIncentive(strComID, intyear, "Y").ToList();
                if (ooaccVYear.Count > 0)
                {
                    int introwy = 0;
                    foreach (IncentiveCal oaccy in ooaccVYear)
                    {
                        DGYear.Rows.Add();
                        DGYear[0, introwy].Value = oaccy.strParticulars;
                        DGYear[1, introwy].Value = oaccy.strTdate;
                        DGYear[2, introwy].Value = oaccy.dblBudget;
                        DGYear[3, introwy].Value = oaccy.dblMnothBonus;
                        DGYear[4, introwy].Value = oaccy.dblIncMPO;
                        DGYear[5, introwy].Value = oaccy.dblINCAH;
                        DGYear[6, introwy].Value = oaccy.dblIncDH;
                        DGYear[7, introwy].Value = "Delete";
                        DGYear[8, introwy].Value = oaccy.strEffetiveMonth;
                        DGYear.AllowUserToAddRows = false;
                        introwy += 1;
                    }
                    DGYear.AllowUserToAddRows = false;
                }
                List<IncentiveCal> ooaccVYearEx = accms.mDisplayIncentive(strComID, intyear, "E").ToList();
                if (ooaccVYearEx.Count > 0)
                {
                    int introwyE = 0;

                    foreach (IncentiveCal oaccee in ooaccVYearEx)
                    {
                        DGYearE.Rows.Add();
                        DGYearE[0, introwyE].Value = oaccee.strParticulars;
                        DGYearE[1, introwyE].Value = oaccee.strTdate;
                        DGYearE[2, introwyE].Value = oaccee.dblBudget;
                        DGYearE[3, introwyE].Value = oaccee.dblIncMPO;
                        DGYearE[4, introwyE].Value = oaccee.dblINCAH;
                        DGYearE[5, introwyE].Value = oaccee.dblIncDH;
                        DGYearE[6, introwyE].Value = "Delete";
                        DGYearE[7, introwyE].Value = oaccee.strEffetiveMonth;
                        DGYearE.AllowUserToAddRows = false;

                        introwyE += 1;
                    }
                    DGYearE.AllowUserToAddRows = false;
                }
                
                cboType.Focus();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGYearE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                DGYearE.Rows.RemoveAt(e.RowIndex);
            }
        }

     

  

    }
}