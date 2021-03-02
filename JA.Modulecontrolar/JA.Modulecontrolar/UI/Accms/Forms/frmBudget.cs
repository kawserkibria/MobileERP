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
    public partial class frmBudget : JA.Shared.UI.frmSmartFormStandard
    {

        JACCMS.SWJAGClient accms = new SWJAGClient();
        
        public  int m_action { get; set; }
        private ListBox lstLedgerName = new ListBox();
        private ListBox lstBranchName = new ListBox();
        public long lngFormPriv { get; set; }
        private string strComID { get; set; }
        public frmBudget()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtLedgerName.KeyDown += new KeyEventHandler(uctxtLedgerName_KeyDown);
            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);


            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);
            this.lstLedgerName.DoubleClick += new System.EventHandler(this.lstLedgerName_DoubleClick);
            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);
            this.DG.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DG_CellFormatting);
            this.DG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DG_KeyDown);
            Utility.CreateListBox(lstLedgerName, pnlMain, uctxtLedgerName);
            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
        }
        #region "USer Define"
        private void DG_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                e.SuppressKeyPress = true;
                int iColumn = DG.CurrentCell.ColumnIndex;
                int iRow = DG.CurrentCell.RowIndex;
                if (iColumn == DG.Columns.Count - 1)
                    btnSave.Focus();
                else
                    DG.CurrentCell = DG[iColumn + 1, iRow];


            }
        }
        private void DG_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DG.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Bisque;
            DG.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DG.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }

        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranchName.Text;

            uctxtLedgerName.Focus();
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }

                uctxtLedgerName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtBranchName, uctxtLedgerName);
            }
        }
        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            lstBranchName.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranchName.SelectedItem != null)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranchName.Items.Count - 1 > lstBranchName.SelectedIndex)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {
           
            lstLedgerName.Visible = false;
            
          
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }


        private void uctxtLedgerName_TextChanged(object sender, EventArgs e)
        {
            lstLedgerName.Visible = true;
            lstLedgerName.SelectedIndex = lstLedgerName.FindString(uctxtLedgerName.Text);
        }

        private void lstLedgerName_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerName.Text = lstLedgerName.Text;
            lstLedgerName.Visible = false;
            if (m_action == 1)
            {
                Generate();
            }
            DG.Focus();
            SendKeys.Send("{tab}");
            SendKeys.Send("{tab}");
        }

        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerName.Items.Count > 0)
                {
                    uctxtLedgerName.Text = lstLedgerName.Text;
                }
                lstLedgerName.Visible = false;
                if (m_action == 1)
                {
                    Generate();
                }
                DG.Focus();
                SendKeys.Send("{tab}");
                SendKeys.Send("{tab}");
            }
           
        }
        private void uctxtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLedgerName.SelectedItem != null)
                {
                    lstLedgerName.SelectedIndex = lstLedgerName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedgerName.Items.Count - 1 > lstLedgerName.SelectedIndex)
                {
                    lstLedgerName.SelectedIndex = lstLedgerName.SelectedIndex + 1;
                }
            }

        }

        private void uctxtLedgerName_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLedgerName.SelectedIndex = lstLedgerName.FindString(uctxtLedgerName.Text);
        }
        #endregion
        private void Generate()
        {
            long lngTotalMonth = 0;
           
           

            //string strFdate = "", strTdate = "";
            DateTime dteDate = Convert.ToDateTime(Utility.gdteFinancialYearFrom);
            //strFdate = Utility.gdteFinancialYearFrom;
            DG.AllowUserToAddRows = true;
            lngTotalMonth = Utility.DateDiff(Utility.DateInterval.Month, Convert.ToDateTime(Utility.gdteFinancialYearFrom), Convert.ToDateTime(Utility.gdteFinancialYearTo)) + 1;
            for (int lngMonth = 0; lngMonth < lngTotalMonth; lngMonth++)
            {
                DG.Rows.Add();
                DG[0, lngMonth].Value = Utility.FirstDayOfMonth(dteDate).ToString("dd-MM-yyyy");
                DG[1, lngMonth].Value = Utility.LastDayOfMonth(dteDate).ToString("dd-MM-yyyy");
                dteDate = dteDate.AddMonths(1);
            }
            DG.AllowUserToAddRows = false;
        }
        private void frmBudget_Load(object sender, EventArgs e)
        {
            uctxtBranchName.Select();
            uctxtBranchName.Focus();
            lstLedgerName.Visible = false;
            lstBranchName.Visible = false;
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("From Period", "From Period", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("To Period", "To Period", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 150, true, DataGridViewContentAlignment.TopLeft, false));

            lstLedgerName.ValueMember = "strLedgerName";
            lstLedgerName.DisplayMember = "strLedgerName";
            lstLedgerName.DataSource = accms.mFillLedgerList(strComID, 4).ToList();

            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            DG.Columns[0].DefaultCellStyle.BackColor = Color.Bisque;
            DG.Columns[1].DefaultCellStyle.BackColor = Color.Bisque;

          

        }

        private void DG_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dblAmount = 0;
            if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
            {
                if (e.RowIndex == 0)
                {
                    dblAmount = Convert.ToDouble(DG[e.ColumnIndex, e.RowIndex].Value);
                    for (int i = e.RowIndex; i < DG.Rows.Count; i++)
                    {
                        DG[2, i].Value = dblAmount;
                    }
                }
                else
                {
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strKey,strBranchID="",strDG="",strKeyRef="";
            double dblAmount = 0;
            if (uctxtBranchName.Text =="")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtBranchName.Focus();
                return;
            }
            if (uctxtLedgerName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtLedgerName.Focus();
                return;
            }

            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            strKey = strBranchID + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString("yyyymmdd") + Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString("yyyymmdd") + uctxtLedgerName.Text.Replace("'", "''");

            for (int i = 0; i < DG.Rows.Count; i++)
            {

                if (DG[2, i].Value.ToString() != null)
                {
                    dblAmount = Utility.Val(DG[2, i].Value.ToString());
                }
                else
                {
                    dblAmount = 0;
                }
                
                strKeyRef = strBranchID + Convert.ToDateTime(DG[0, i].Value).ToString("yyyy") + Convert.ToDateTime(DG[0, i].Value).ToString("MM") + uctxtLedgerName.Text.Replace("'", "''");
                strDG = strDG + strKeyRef + "," +//Group
                                uctxtLedgerName.Text + "," +//ledgerName
                                strBranchID + "," +//branchID
                                uctxtBranchName.Text + "," +//branchName
                                DG[0, i].Value.ToString() + "," + //fromdate
                                DG[1, i].Value.ToString() + "," + //todate
                               dblAmount  + "~"; //Amount

                //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";
            }

            if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
            {
                string strResponse = Utility.mCheckDuplicateItem(strComID, "ACC_BUDGET_MASTER", "BUDGET_KEY", strKey);
                if (strResponse !="")
                {
                    MessageBox.Show(strResponse);
                    uctxtLedgerName.Focus();
                    return;
                }
                
                string s = accms.mSaveBudget(strComID, strKey, strDG);
                if (s == "1")
                {
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Budget Configuration", uctxtLedgerName.Text,
                                                                1, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, strBranchID);
                    }
                    mClear();
                  
                }
                else
                {
                    MessageBox.Show(s);
                }
            }
            else
            {
                string k = accms.mUpdateBudget(strComID,textBox1.Text, strKey, strDG);
                if (k == "1")
                {
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Budget Configuration", uctxtLedgerName.Text,
                                                                2, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, strBranchID);
                    }
                    mClear();
                }
                else
                {
                    MessageBox.Show(k);
                }
            }
        }
       
        private void mClear()
        {
            uctxtBranchName.Text = "";
            uctxtLedgerName.Text = "";
            DG.Rows.Clear();
            m_action = 1;
            uctxtBranchName.ReadOnly = false;
            uctxtLedgerName.ReadOnly = false;
            textBox1.Text = "";
            uctxtBranchName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmBudgetList objfrm = new frmBudgetList();
            objfrm.onAddAllButtonClicked = new frmBudgetList.AddAllClick(DisplayReqList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }
        private void DisplayReqList(List<AccountdGroup> tests, object sender, EventArgs e)
        {
            try
            {
                m_action = 2;
                uctxtBranchName.ReadOnly = true;
                uctxtLedgerName.ReadOnly = true;
                uctxtBranchName.Select();
                uctxtBranchName.Focus();
                List<AccountdGroup> ogrp=accms.mDisplayBudgetList(strComID,tests[0].GroupName).ToList();
                {
                    textBox1.Text = tests[0].GroupName;
                    if (ogrp.Count>0)
                    {
                        int introw=0;
                        foreach(AccountdGroup display in ogrp)
                        {
                            DG.Rows.Add();
                            uctxtLedgerName.Text = display.GroupName;
                            uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, display.strMonthID);

                            DG[0, introw].Value = display.strFromdate;
                            DG[1, introw].Value = display.strTodate;
                            DG[2, introw].Value = display.dblAmount;
                            introw += 1;
                        }
                        DG.AllowUserToAddRows = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            //string values = objW.mGetOTPNo("0001", "01700712449"); 
        }
    }
}
