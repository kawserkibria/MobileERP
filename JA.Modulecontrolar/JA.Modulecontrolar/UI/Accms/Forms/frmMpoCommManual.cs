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
using JA.Modulecontrolar.JINVMS;
using System.Data.SqlClient;
namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmMpoCommManual : JA.Shared.UI.frmSmartFormStandard
    {
        SPWOIS objWois = new SPWOIS();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<AccountsLedger> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public string strLedgerName { get; set; }
        private string strComID { get; set; }
        public int m_action { get; set; }
        private ListBox lstBranch = new ListBox();
        private string strMonthID { get; set; }
        private string strOldMonthID { get; set; }
        private string strOldLedgerName { get; set; }
        List<Invoice> ooPartyName;
        public frmMpoCommManual()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User Define"
            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);
            this.chkStatus.Click += new System.EventHandler(this.chkStatus_Click);
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch);
            #endregion
        }
        #region "User Define"

        private void mloadParty(int intstatus)
        {
            int introw = 0;
            DG.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID, lstBranch.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, intstatus, "","").ToList();

            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DG.Rows.Add();
                    DG[1, introw].Value = ogrp.strLedgerName;
                    DG[0, introw].Value = ogrp.strMereString;
                    DG[9, introw].Value = Utility.GetdblIncenAmnout(strComID, ogrp.strMereString, uctxtMonthID.Text);
                    DG[9, introw].ReadOnly = true;
                    introw += 1;
                }

                DG.AllowUserToAddRows = false;
            }
        }
        private void mloadPartyEdit(int intstatus,string strKey)
        {
            int introw = 0;
            DG.Rows.Clear();

            ooPartyName = objWois.mfillPartyNameNewEdit(strComID, lstBranch.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, intstatus, "", strKey).ToList();

            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DG.Rows.Add();
                    DG[1, introw].Value = ogrp.strLedgerName;
                    DG[0, introw].Value = ogrp.strMereString;
                    introw += 1;
                }

                DG.AllowUserToAddRows = false;
            }
        }
        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranch.Text = lstBranch.Text;
                lstBranch.Visible = false;
        }

        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstBranch.Text;
             
                    lstBranch.Visible = false;
                }
            }
        }
        private void uctxtBranch_KeyDown(object sender, KeyEventArgs e)
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

        private void uctxtBranch_GotFocus(object sender, System.EventArgs e)
        {

            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        #endregion
        #region "MPO"
     


        #endregion
        #region "Load"
        private void frmMpoCommManual_Load(object sender, EventArgs e)
        {
            lstBranch.Visible = false;

            mClear();



            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);


            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 280, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 300, false, DataGridViewContentAlignment.TopLeft, true));

            DG.Columns[1].Frozen = true;
            DG.Columns[0].DefaultCellStyle.BackColor = Color.Beige;
            DG.Columns[1].DefaultCellStyle.BackColor = Color.Bisque;
            List<AccountsLedger> oogrp = accms.mDisplayLedgerlistt(strComID, 1).ToList();
            if (oogrp.Count > 0)
            {
                foreach (AccountsLedger ogrp in oogrp)
                {
                    //DG.Rows.Add();
                    DG.Columns.Add(Utility.Create_Grid_Column(ogrp.strLedgerName, ogrp.strLedgerName, 80, true, DataGridViewContentAlignment.TopLeft, false));
                }

            }

            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            uctxtBranch.Text = Utility.gstrBranchName;
            List<AccountdGroup> ooMonth = accms.mDisplayMonthsetupList(strComID, "1", Utility.gdteFinancialYearFrom, Utility.gdteFinancialYearTo).ToList();
            if (ooMonth.Count > 0)
            {
                uctxtMonthID.Text = ooMonth[0].strMonthID;
                strMonthID = ooMonth[0].strMonthID;
            }

            //mloadParty(0);

            DG.ClearSelection();
            DG[1, 0].Selected = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //mClear();
            frmMpoCommManualList objfrm = new frmMpoCommManualList();
            objfrm.onAddAllButtonClicked = new frmMpoCommManualList.AddAllClick(DisplayVoucherList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }
        #endregion
        #region "Display Voucher List"
        private void DisplayVoucherList(List<AccountsLedger> tests, object sender, EventArgs e)
        {
            try
            {
                
                string strYn = "";
                DG.Rows.Clear();
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                strYn = Utility.Right(tests[0].strConfigkey, 1);
                if (strYn=="A")
                {
                    chkStatus.Checked = true;
                    //mloadParty(0);
                    mloadPartyEdit(0, tests[0].strConfigkey);
                }
                else
                {
                    mloadParty(1);
                    chkStatus.Checked = false;
                }
                chkStatus.Enabled = false;
                uctxtOldKey.Text = tests[0].strConfigkey;
                uctxtMonthID.Text = tests[0].strEfectDate;
                uctxtBranch.Text = Utility.gstrGetBranchName(strComID, tests[0].strBranchID);
                strOldMonthID = tests[0].strEfectDate;
                List<AccountsLedger> ooaccVou = accms.mFillDisplayBill(strComID, tests[0].strConfigkey).ToList();
                if (ooaccVou.Count > 0)
                {
                    foreach (AccountsLedger oCom in ooaccVou)
                    {
                        DG[oCom.intCol, oCom.intRow].Value = oCom.dblToAmt;
                        DG[9, oCom.intRow].ReadOnly = true;
                    }
                }


            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "mclear"
        private void mClear()
        {
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            uctxtBranch.Text = "";
            //uctxtMedicalRep.Text = "";
            DG.Rows.Clear();
            //uctxtLedgerName.Text = "";
            uctxtMonthID.Text = strMonthID;
            uctxtBranch.Text = Utility.gstrBranchName;
            chkStatus.Checked = true;
            uctxtBranch.Focus();
            uctxtBranch.Select();
        }
        #endregion
        #region "Save"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strmsg = "", strkey = "", strBranchID = "", strSQL = "";
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            double dblAmount = 0;
            DataTable dt1 = new DataTable();
            dt1.Columns.Add(new DataColumn("Key"));
            dt1.Columns.Add(new DataColumn("MonthId"));
            dt1.Columns.Add(new DataColumn("BranhID"));
            dt1.Columns.Add(new DataColumn("LedgerName"));
            dt1.Columns.Add(new DataColumn("Headname"));
            dt1.Columns.Add(new DataColumn("Amount"));
            dt1.Columns.Add(new DataColumn("col"));
            dt1.Columns.Add(new DataColumn("row"));
            if (m_action == 1)
            {
                if (chkStatus.Checked)
                {
                    strmsg = Utility.mCheckManual(strComID, strMonthID + "A");
                }
                else
                {
                    strmsg = Utility.mCheckManual(strComID, strMonthID + "I");
                }
                if (strmsg != "")
                {
                    MessageBox.Show(strmsg);
                    return;
                }
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                try
                {
                    strBranchID = lstBranch.SelectedValue.ToString();
                    if (chkStatus.Checked)
                    {
                        strkey = uctxtMonthID.Text + strBranchID + "A";
                    }
                    else
                    {
                        strkey = uctxtMonthID.Text + strBranchID + "I";
                    }
              
                    strmsg = "1";
                    if (strmsg == "1")
                    {

                        for (int intcol = 2; intcol <= DG.Columns.Count - 1; intcol++)
                        {
                            string strHead = DG.Columns[intcol].HeaderText;
                            for (int i = 0; i < DG.Rows.Count; i++)
                            {
                                if (DG[intcol, i].Value != null)
                                {
                                    dblAmount = Convert.ToDouble(DG[intcol, i].Value.ToString());
                                }
                                else
                                {
                                    dblAmount = 0;
                                }
                                dt1.Rows.Add(strkey, uctxtMonthID.Text, strBranchID, DG[1, i].Value.ToString(), strHead, dblAmount, intcol, i);
                                //strmsg = accms.mInsertMpoManual(strComID, strkey, uctxtMonthID.Text, strBranchID, DG[1, i].Value.ToString(), strHead, dblAmount, 0, intcol, i);


                            }

                        }
                        if (dt1.Rows.Count > 0)
                        {
                            //strmsg = objWois.mInsertMpoManual(strComID, strkey, uctxtMonthID.Text, strBranchID, "", "", 0, 1, 0, 0, dt1);

                            using (SqlConnection gcnMain = new SqlConnection(connstring))
                            {
                                if (gcnMain.State == ConnectionState.Open)
                                {
                                    gcnMain.Close();
                                }
                                gcnMain.Open();


                              
                                SqlCommand cmdInsert = new SqlCommand();
                                SqlTransaction myTrans;
                                myTrans = gcnMain.BeginTransaction();
                                cmdInsert.Connection = gcnMain;
                                cmdInsert.Transaction = myTrans;

                                strSQL = "DELETE FROM MPO_COMM_MAN_PARENT_CHILD ";
                                strSQL = strSQL + " WHERE ";
                                strSQL = strSQL + " COMM_MANUAL_KEY ='" + strkey.Replace("'", "''") + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                strSQL = "DELETE FROM MPO_COMM_MAN_PARENT ";
                                strSQL = strSQL + " WHERE ";
                                strSQL = strSQL + " COMM_MANUAL_KEY ='" + strkey.Replace("'", "''") + "' ";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                strSQL = "INSERT INTO MPO_COMM_MAN_PARENT(COMM_MANUAL_KEY,MONTH_ID,BRANCH_ID)";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + strkey.Replace("'", "''") + "' ";
                                strSQL = strSQL + ",'" + strMonthID.Replace("'", "''") + "' ";
                                strSQL = strSQL + ",'" + strBranchID.Replace("'", "''") + "' ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                                if (dt1.Rows.Count > 0)
                                {
                                    progressBar1.Value = 0;
                                    progressBar1.Maximum = dt1.Rows.Count;
                                    foreach (DataRow dr in dt1.Rows)
                                    {

                                        strSQL = "INSERT INTO MPO_COMM_MAN_PARENT_CHILD(COMM_MANUAL_KEY,LEDGER_NAME,HEAD_NAME,AMOUNT,COLS,ROWPOS)";
                                        strSQL = strSQL + "VALUES(";
                                        strSQL = strSQL + "'" + strkey.Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",'" + dr["LedgerName"].ToString().Replace("'", "''") + "' ";
                                        strSQL = strSQL + ",'" + dr["Headname"].ToString().Replace("'", "''") + "' ";
                                        strSQL = strSQL + "," + Utility.Val(dr["Amount"].ToString()) + " ";
                                        strSQL = strSQL + "," + Utility.Val(dr["col"].ToString()) + " ";
                                        strSQL = strSQL + "," + Utility.Val(dr["row"].ToString()) + " ";
                                        strSQL = strSQL + ")";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                        progressBar1.Value += 1;
                                    }
                                }
                                cmdInsert.Transaction.Commit();


                            }



                        }
                        if (strmsg == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Draft MPO Commsiion", strkey,
                                                                        m_action, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                            }
                            MessageBox.Show("Record Saved..");
                            progressBar1.Value = 0;
                            chkStatus.Enabled = true;
                            if (m_action == 2)
                            {
                                m_action = 1;
                                this.Hide();
                                frmMpoCommManualList objfrm = new frmMpoCommManualList();
                                objfrm.onAddAllButtonClicked = new frmMpoCommManualList.AddAllClick(DisplayVoucherList);
                                objfrm.lngFormPriv = lngFormPriv;
                                objfrm.Show();
                                objfrm.MdiParent = this.MdiParent;
                            }

                        }
                    }
                }

                catch (Exception EX)
                {
                    MessageBox.Show(EX.ToString());
                }
            }
        }
        #endregion
        #region "Click"
        private void chkStatus_Click(object sender, EventArgs e)
        {
            int intStatus = 0;
            if (chkStatus.Checked)
            {
                intStatus = 0;
            }
            else
            {
                intStatus = 1;
            }

            mloadParty(intStatus);
      
        }


        #endregion

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            if (uctxtMonthID.Text == "")
            {
                MessageBox.Show("Month ID Cannot be Empty");
                uctxtMonthID.Focus();
                return;
            }
            mloadParty(0);
        }

        private void btnGen_Click_1(object sender, EventArgs e)
        {

        }

        





    }

}