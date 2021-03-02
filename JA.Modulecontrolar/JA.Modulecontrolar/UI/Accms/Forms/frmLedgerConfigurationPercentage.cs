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
namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmLedgerConfigurationPercentage : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public delegate void AddAllClick(List<AccountsLedger> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public string strLedgerName { get; set; }
        private string strComID { get; set; }
        private double dblPercentage { get; set; }
        public frmLedgerConfigurationPercentage()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.DG.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);
            this.chkActive.Click += new System.EventHandler(this.chkActive_Click);
        }


        #region "MPO"
        private void mLoadMPOList(int intStatus)
        {
            int introw = 0, intcol=3;
            double dblPer = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<AccountsLedger> oogrp = accms.mFillLedgerListNew(strComID, 202, intStatus, "", 0).ToList();
            if (oogrp.Count > 0)
            {
                foreach (AccountsLedger ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strTeritorryCode;
                    DG[1, introw].Value = ogrp.strLedgerName;
                    DG[2, introw].Value = ogrp.strmerzeString;
                    if (lblLedgerName.Text.ToUpper() == "Salary by Voucher".ToUpper())
                    {
                        intcol = 3;
                        List<AccountsVoucher> objList = accms.mFillLedgerListMpoPercenNew(strComID, lblLedgerName.Text, ogrp.strLedgerName).ToList();
                        if (objList.Count > 0)
                        {
                            foreach (AccountsVoucher oobjList in objList)
                            {
                                DG[intcol, introw].Value = oobjList.dblCreditAmount;
                                intcol += 1;
                            }
                                //for (int intcol = 3; intcol < DG.Columns.Count; intcol++)
                                //{
                                //    DG[intcol, introw].Value = objList[0].dblCreditAmount;
                                //}
                                //DG[3, introw].Value = objList[0].dblCreditAmount;
                                //DG[5, introw].Value = objList[0].strDueDate;
                        }
                        else
                        {
                            DG[3, introw].Value = 0;
                            DG[4, introw].Value = 0;
                        }
                    }
                    else
                    {
                        List<AccountsVoucher> objList = accms.mFillLedgerListMpoPercen(strComID, lblLedgerName.Text, ogrp.strLedgerName).ToList();
                        if (objList.Count > 0)
                        {
                            DG[4, introw].Value = objList[0].dblDebitAmount;
                        }
                        else
                        {
                            DG[3, introw].Value = 0;
                            DG[4, introw].Value = 0;
                        }

                    }
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;


            }
        }

       
        #endregion

        private void frmLedgerConfigurationPercentage_Load(object sender, EventArgs e)
        {
            lblLedgerName.Text = strLedgerName;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("TC", "TC", 80, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 80, false, DataGridViewContentAlignment.TopLeft, true));
           
            if (lblLedgerName.Text.ToUpper() == "Salary by Voucher".ToUpper())
            {
                int intmonthNo;
                DateTime dteStartDate = Convert.ToDateTime(Utility.gdteFinancialYearFrom);
                int intmonth = Utility.GetMonthDifference(Convert.ToDateTime(Utility.gdteFinancialYearFrom), Convert.ToDateTime(Utility.gdteFinancialYearTo))+2;
                DG.Columns.Add(Utility.Create_Grid_Column("MPO Name", "MPO Name", 300, true, DataGridViewContentAlignment.TopLeft, true));
                //DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, false));
                //DG.Columns.Add(Utility.Create_Grid_Column("%", "%", 100, false, DataGridViewContentAlignment.TopLeft, false));
                //DG.Columns.Add(Utility.Create_Grid_Column("Effective Date", "Effective Date", 100, true, DataGridViewContentAlignment.TopLeft, false));
                for (int i = 1; i <= intmonth; i++)
                {
                    //DG.Rows.Add(1);
                    //DG.Rows[i].Cells[0].Value = i;
                    string strMMYY = Utility.GetMonth(i);
                    intmonthNo = dteStartDate.Month;
                    DG.Columns.Add(Utility.Create_Grid_Column(Utility.GetMonth(intmonthNo) + dteStartDate.Year.ToString().Substring(2, 2), Utility.GetMonth(intmonthNo) + dteStartDate.Year.ToString().Substring(2, 2), 100, true, DataGridViewContentAlignment.TopLeft, false));
                    dteStartDate = Utility.NextMonth(dteStartDate);
                }
                DG.Columns[1].Frozen = true;
                DG.Columns[2].Frozen = true;
                DG.Columns[0].DefaultCellStyle.BackColor = Color.Beige;
                DG.Columns[1].DefaultCellStyle.BackColor = Color.Bisque;
                DG.Columns[2].DefaultCellStyle.BackColor = Color.Beige;
            }
            else
            {
                DG.Columns.Add(Utility.Create_Grid_Column("MPO Name", "MPO Name", 450, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, false, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("%", "%", 100, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("Effective Date", "Effective Date", 100, false, DataGridViewContentAlignment.TopLeft, false));
            }
            mLoadMPOList(0);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strmsg = "",strDate="";
            int intStatus = 0;
            double dblAmount = 0, dblPercentage = 0;
            if(chkActive.Checked)
            {
                intStatus = 0;
            }
            else
            {
                intStatus = 1;
            }
            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                try
                {
                    strmsg = accms.mInsertMpoPercentage(strComID, lblLedgerName.Text, "", 0, 0, "", 1,intStatus);
                    if (strmsg == "1")
                    {
                        progressBar1.Value = 0;
                        progressBar1.Maximum = DG.Rows.Count;
                        if (lblLedgerName.Text == "Salary By Voucher")
                        {
                            for (int i = 0; i < DG.Rows.Count; i++)
                            {
                                for (int intcol = 3; intcol < DG.Columns.Count; intcol++)
                                {
                                    if (DG[intcol, i].Value != null)
                                    {
                                        dblAmount = Utility.Val(DG[intcol, i].Value.ToString());
                                        strDate = mGeteffectiveDate(DG.Columns[intcol].HeaderText);
                                        strDate = Utility.LastDayOfMonth(Convert.ToDateTime(strDate)).ToString("dd-MM-yyyy");
                                        //MessageBox.Show(dd.ToString());
                                        strmsg = accms.mInsertMpoPercentage(strComID, lblLedgerName.Text, DG[1, i].Value.ToString(), dblPercentage, dblAmount, strDate, 0, intStatus);
                                    }
                                }
                                //return;
                                //if (DG[5, i].Value != null)
                                //{
                                //    strDate = DG[5, i].Value.ToString();
                                //}
                                //else
                                //{
                                //    strDate = "";
                                //}

                                //if (DG[4, i].Value != null)
                                //{
                                //    dblPercentage = Convert.ToDouble(DG[4, i].Value.ToString());
                                //}
                                //else
                                //{
                                //    dblPercentage = 0;
                                //}
                                //if (DG[3, i].Value != null)
                                //{
                                //    dblAmount = Convert.ToDouble(DG[3, i].Value.ToString());
                                //}
                                //else
                                //{
                                //    dblAmount = 0;
                                //}

                                //strmsg = accms.mInsertMpoPercentage(strComID, lblLedgerName.Text, DG[1, i].Value.ToString(), dblPercentage, dblAmount, strDate, 0, intStatus);
                                progressBar1.Value += 1;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < DG.Rows.Count; i++)
                            {
                                //if (DG[3, i].Value.ToString() != "0")
                                //{
                                if (DG[5, i].Value != null)
                                {
                                    strDate = DG[5, i].Value.ToString();
                                }
                                else
                                {
                                    strDate = "";
                                }

                                if (DG[4, i].Value != null)
                                {
                                    dblPercentage = Convert.ToDouble(DG[4, i].Value.ToString());
                                }
                                else
                                {
                                    dblPercentage = 0;
                                }
                                if (DG[3, i].Value != null)
                                {
                                    dblAmount = Convert.ToDouble(DG[3, i].Value.ToString());
                                }
                                else
                                {
                                    dblAmount = 0;
                                }

                                strmsg = accms.mInsertMpoPercentage(strComID, lblLedgerName.Text, DG[1, i].Value.ToString(), dblPercentage, dblAmount, strDate, 0, intStatus);
                                //}
                                progressBar1.Value += 1;
                            }
                        }
                        if (strmsg == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "MPO Commsiion Percentage", lblLedgerName.Text,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                            }
                            MessageBox.Show("Record Saved..");

                        }
                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(strmsg);
                }
            }
        }
        private string  mGeteffectiveDate(string strMonhtID)
        {
            string strDate="";
            string strmm = Utility.Left(strMonhtID, 3);
            int intMm = Convert.ToInt16(Utility.Right(strMonhtID, 2).ToString());
            if (strmm.ToUpper()=="JAN")
            {
                strDate = "01-01-" + intMm;
            }
            else if (strmm.ToUpper() == "FEB")
            {
                strDate = "01-02-" + intMm;
            }
            else if (strmm.ToUpper() == "MAR")
            {
                strDate = "01-03-" + intMm;
            }
            else if (strmm.ToUpper() == "APR")
            {
                strDate = "01-04-" + intMm;
            }
            else if (strmm.ToUpper() == "MAY")
            {
                strDate = "01-05-" + intMm;
            }
            else if (strmm.ToUpper() == "JUN")
            {
                strDate = "01-06-" + intMm;
            }
            else if (strmm.ToUpper() == "JUL")
            {
                strDate = "01-07-" + intMm;
            }
            else if (strmm.ToUpper() == "AUG")
            {
                strDate = "01-08-" + intMm;
            }
            else if (strmm.ToUpper() == "SEP")
            {
                strDate = "01-09-" + intMm;
            }
            else if (strmm.ToUpper() == "OCT")
            {
                strDate = "01-10-" + intMm;
            }
            else if (strmm.ToUpper() == "NOV")
            {
                strDate = "01-11-" + intMm;
            }
            else if (strmm.ToUpper() == "DEC")
            {
                strDate = "01-12-" + intMm;
            }

            return strDate;
        }
        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dblAmount = 0;
            dblAmount = Convert.ToDouble(DG[e.ColumnIndex, e.RowIndex].Value);
            for (int i = e.ColumnIndex; i < DG.Columns.Count; i++)
            {
                if (chkChange.Checked == true)
                {
                    if (lblLedgerName.Text.ToUpper() == "Salary by Voucher".ToUpper())
                    {
                        DG[i, e.RowIndex].Value = dblAmount;
                    }
                }
            }
            if (e.ColumnIndex == 3)
            {

                for (int i = e.RowIndex; i < DG.Rows.Count; i++)
                {
                    if (chkChange.Checked == true)
                    {
                        if (lblLedgerName.Text.ToUpper() == "Salary by Voucher".ToUpper())
                        {
                            DG[3, i].Value = dblAmount;
                        }
                        else
                        {
                            DG[4, i].Value = dblAmount;
                        }
                    }
                    //else
                    //{
                    //    //if (DG[5, e.RowIndex].Value != null)
                    //    //DG[5, i].Value = Utility.ctrlDateFormat(DG[5, i].Value.ToString());
                    //}
                }
                
            }
            else if (e.ColumnIndex == 3 && lblLedgerName.Text != "Salary by Voucher")
            {
                dblAmount = Convert.ToDouble(DG[e.ColumnIndex, e.RowIndex].Value);
                for (int i = e.RowIndex; i < DG.Rows.Count; i++)
                {
                    if (chkChange.Checked == true)
                    {
                        if (lblLedgerName.Text.ToUpper() == "Salary by Voucher".ToUpper())
                        {
                            DG[3, i].Value = dblAmount;
                        }
                        else
                        {
                            DG[4, i].Value = dblAmount;
                        }
                    }
                    else
                    {
                        //if (DG[5, e.RowIndex].Value != null)
                        //    DG[5, i].Value = Utility.ctrlDateFormat(DG[5, i].Value.ToString());
                    }
                }
            }
            else
            {
                //if (DG[5, e.RowIndex].Value !=null)
                //DG[5, e.RowIndex].Value = Utility.ctrlDateFormat(DG[5, e.RowIndex].Value.ToString());
            }
        }

        private void chkActive_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                mLoadMPOList(0);
            }
            else
            {
                mLoadMPOList(1);
            }
        }

        private void DG_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {

        }

     



    }

}