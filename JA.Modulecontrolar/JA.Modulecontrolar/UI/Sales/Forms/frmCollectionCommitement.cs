using Dutility;
using JA.Modulecontrolar.JINVMS;
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
using JA.Modulecontrolar.UI.Accms.Forms;
using System.IO;
using Mayhedi.Office.Excel.Reader;
using JA.Modulecontrolar.UI.Sales.Forms;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales
{
    public partial class frmCollectionCommitement : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstBranch = new ListBox();
        private ListBox lstLedgerName = new ListBox();
        public long lngFormPriv { get; set; }
        public string strtFormName { get; set; }
        public int m_action { get; set; }
        public string strSelection { get; set; }
        private string strComID { get; set; }
        public frmCollectionCommitement()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dtefromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtefromDate_KeyPress);
            this.dtefromDate.GotFocus += new System.EventHandler(this.dtefromDate_GotFocus);
            this.dteTodate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteTodate_KeyPress);
            this.dteTodate.GotFocus += new System.EventHandler(this.dteTodate_GotFocus);

            this.uctxtbranchName.KeyDown += new KeyEventHandler(uctxtbranchName_KeyDown);
            this.uctxtbranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtbranchName_KeyPress);
            this.uctxtbranchName.TextChanged += new System.EventHandler(this.uctxtbranchName_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtbranchName.GotFocus += new System.EventHandler(this.uctxtbranchName_GotFocus);

            this.uctxtLedgerName.KeyDown += new KeyEventHandler(uctxtLedgerName_KeyDown);
            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);
            this.lstLedgerName.DoubleClick += new System.EventHandler(this.lstLedgerName_DoubleClick);
            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);

            this.DG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DG_KeyDown);
            this.DG.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DG_EditingControlShowing);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtbranchName);
            Utility.CreateListBox(lstLedgerName, pnlMain, uctxtLedgerName);
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
        #region "Keydown"
        private void DG_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (DG.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (DG.CurrentCell.ColumnIndex != 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }
        }
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
        #endregion
        #region "User Define"
        private void uctxtLedgerName_TextChanged(object sender, EventArgs e)
        {
            lstLedgerName.Visible = true;
            lstLedgerName.SelectedIndex = lstLedgerName.FindString(uctxtLedgerName.Text);
        }

        private void lstLedgerName_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerName.Text = lstLedgerName.Text;
            mAdditem(lstLedgerName.SelectedValue.ToString(), uctxtLedgerName.Text);
            lstLedgerName.Visible = false;
            DG.Focus();
        }
        private void mAdditem(string strLedgerName,string strMerzeName)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < DG.RowCount; j++)
            {
                if (DG[0, j].Value != null)
                {
                    strDown = DG[1, j].Value.ToString();
                }
                if (strLedgerName == strDown.ToString())
                {
                    blngCheck = true;
                    MessageBox.Show("MPO Name already Exists!");
                    uctxtLedgerName.Focus();
                    return;
                }

            }
            if (blngCheck == false)
            {

                DG.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DG.RowCount.ToString());
                selRaw = selRaw - 1;
                DG.Rows.Add();
                DG[0, selRaw].Value = strMerzeName;
                DG[1, selRaw].Value = strLedgerName;
                DG.AllowUserToAddRows = false;
                uctxtLedgerName.Text = "";
                DG.ClearSelection();
                int nColumnIndex = 2;
                int nRowIndex = DG.Rows.Count - 1;
                DG.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                DG.FirstDisplayedScrollingRowIndex = nRowIndex;
            }

        }
        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerName.Items.Count > 0)
                {
                    if (uctxtLedgerName.Text != "")
                    {
                        uctxtLedgerName.Text = lstLedgerName.Text;
                        mAdditem(lstLedgerName.SelectedValue.ToString(), uctxtLedgerName.Text);
                        uctxtLedgerName.Focus();
                    }
                    else
                    {
                        DG.Focus();
                    }

                }
                lstLedgerName.Visible = false;

               

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
            lstBranch.Visible = false;
          
            lstLedgerName.SelectedIndex = lstLedgerName.FindString(uctxtLedgerName .Text);
        }

        private void dtefromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteTodate.Focus();

            }
        }
        private void dteTodate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int intmonthNo;
                DateTime dteStartDate;
                DG.Rows.Clear();
                for (int intcol = 0; intcol < DG.ColumnCount; intcol++)
                {
                    DG.Columns.RemoveAt(intcol);
                    intcol--;
                }
                dteStartDate = dtefromDate.Value;
                int intmonth = Utility.GetMonthDifference(dteTodate.Value, dtefromDate.Value);
                DG.RowTemplate.Height = 40;
                DG.Columns.Add(Utility.Create_Grid_Column("MPO Name", "MPO Name", 400, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 300, false, DataGridViewContentAlignment.TopLeft, true));
                for (int i = 1; i <= intmonth; i++)
                {
                    //DG.Rows.Add(1);
                    //DG.Rows[i].Cells[0].Value = i;
                    string strMMYY = Utility.GetMonth(i);
                    intmonthNo = dteStartDate.Month;
                    DG.Columns.Add(Utility.Create_Grid_Column(Utility.GetMonth(intmonthNo) + dteStartDate.Year.ToString().Substring(2, 2), Utility.GetMonth(intmonthNo) + dteStartDate.Year.ToString().Substring(2, 2), 100, true, DataGridViewContentAlignment.TopLeft, false));
                    dteStartDate = Utility.NextMonth(dteStartDate);
                }
                uctxtbranchName.Focus();

            }
        }
        private void dtefromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false ;
            lstLedgerName.Visible = false;
        }
        private void dteTodate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
            lstLedgerName.Visible = false;
        }
        private void uctxtbranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtbranchName.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtbranchName.Text = lstBranch.Text;
            if (btnGenerate.Enabled)
            {
                var strResponseInsert = MessageBox.Show("Do You Want to Generate?", "Generate Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    btnGenerate.Focus();
                }
                else
                {
                    btnSave.Focus();
                }
            }
            else
            {
                DG.Focus();
            }
            lstBranch.Visible = false;
        }

        private void uctxtbranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtbranchName.Text = lstBranch.Text;
                    
                }
                lstBranch.Visible = false;

                if (btnGenerate.Enabled)
                {
                    var strResponseInsert = MessageBox.Show("Do You Want to Generate?", "Generate Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponseInsert == DialogResult.Yes)
                    {
                        btnGenerate.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }
                else
                {
                    //DG.Focus();
                    uctxtLedgerName.Focus();
                }
                lstBranch.Visible = false;

            }
        }
        private void uctxtbranchName_KeyDown(object sender, KeyEventArgs e)
        {
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

        private void uctxtbranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = true;
            lstLedgerName.Visible = false;
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtbranchName.Text);
        }
        #endregion
        #region "Generate"
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int intmonthNo;
            DateTime dteStartDate;
            DG.Rows.Clear();
            for (int intcol = 0; intcol < DG.ColumnCount; intcol++)
            {
                DG.Columns.RemoveAt(intcol);
                intcol--;
            }
            dteStartDate = dtefromDate.Value;
            int intmonth = Utility.GetMonthDifference(dteTodate.Value, dtefromDate.Value);
            DG.RowTemplate.Height = 40;
            DG.Columns.Add(Utility.Create_Grid_Column("MPO NAME", "MPO NAME", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("LEDGER Name", "LEDGER Name", 300, false, DataGridViewContentAlignment.TopLeft, true));
            for (int i = 1; i <= intmonth; i++)
            {
                //DG.Rows.Add(1);
                //DG.Rows[i].Cells[0].Value = i;
                string strMMYY = Utility.GetMonth(i);
                intmonthNo = dteStartDate.Month;
                DG.Columns.Add(Utility.Create_Grid_Column(Utility.GetMonth(intmonthNo) + dteStartDate.Year.ToString().Substring(2, 2), Utility.GetMonth(intmonthNo) + dteStartDate.Year.ToString().Substring(2, 2), 100, true, DataGridViewContentAlignment.TopLeft, false));
                dteStartDate = Utility.NextMonth(dteStartDate);
            }

            List<AccountsLedger> oogrp = accms.mFillLedgerListTARGET(strComID, lstBranch.SelectedValue.ToString()).ToList();
             if (oogrp.Count > 0)
             {
                 int introw=0;
                 this.DG.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;          // wrapped to subsequent lines
                 this.DG.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; 
                 foreach(AccountsLedger ogrp in oogrp)
                 {
                     DG.Rows.Add();
                     DG[0, introw].Value = ogrp.strmerzeString;
                     DG[1, introw].Value = ogrp.strLedgerName;
                     DG.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                     introw += 1;
                 }
                 DG.AllowUserToAddRows = false;
                 lblTotalrecord.Text = "Total MPO: " + introw.ToString() + " ";
             }
        }
        #endregion
        #region "Load"
        private void frmCollectionCommitement_Load(object sender, EventArgs e)
        {
            lstBranch.Visible = false;
            lstLedgerName.Visible = false;
            dtefromDate.Text = Utility.gdteFinancialYearFrom;
            dteTodate.Text = Utility.gdteFinancialYearTo;
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            lstLedgerName.ValueMember = "strLedgerName";
            lstLedgerName.DisplayMember = "strmerzeString";
            lstLedgerName.DataSource = accms.mFillLedgerListTARGET(strComID, lstBranch.SelectedValue.ToString()) .ToList();
            if (strSelection=="TA")
            {
                frmLabel.Text = "Sales Target";
            }
            else if (strSelection == "MC")
            {
                frmLabel.Text = "Credit Limit";
            }
            else if (strSelection == "TA")
            {
                frmLabel.Text = "Collection Target ";
            }

            //int intmonthNo;
            //DateTime dteStartDate;
            //DG.Rows.Clear();
            //for (int intcol = 0; intcol < DG.ColumnCount; intcol++)
            //{
            //    DG.Columns.RemoveAt(intcol);
            //    intcol--;
            //}
            //dteStartDate = dtefromDate.Value;
            //int intmonth = Utility.GetMonthDifference(dteTodate.Value, dtefromDate.Value);
            //DG.RowTemplate.Height = 40;
            //DG.Columns.Add(Utility.Create_Grid_Column("MPO Name", "MPO Name", 400, true, DataGridViewContentAlignment.TopLeft, true));
            //DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 300, false, DataGridViewContentAlignment.TopLeft, true));
            //for (int i = 1; i <= intmonth; i++)
            //{
            //    //DG.Rows.Add(1);
            //    //DG.Rows[i].Cells[0].Value = i;
            //    string strMMYY = Utility.GetMonth(i);
            //    intmonthNo = dteStartDate.Month;
            //    DG.Columns.Add(Utility.Create_Grid_Column(Utility.GetMonth(intmonthNo) + dteStartDate.Year.ToString().Substring(2, 2), Utility.GetMonth(intmonthNo) + dteStartDate.Year.ToString().Substring(2, 2), 100, true, DataGridViewContentAlignment.TopLeft, false));
            //    dteStartDate = Utility.NextMonth(dteStartDate);
            //}

        }
        #endregion
        #region "Import"
        private void btnImport_Click(object sender, EventArgs e)
        {



            string strSheetName = "";
            long lngCount = 0;
            Stream myStream = null;
            DG.Rows.Clear();
            if (uctxtbranchName.Text == "")
            {
                MessageBox.Show("Branch Name Cannot be Empty");
                uctxtbranchName.Focus();
                return;
            }
            lblDisplay.Text = "Please ..Wait.... File is Loading";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {


                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            string strFileName = "", strPath = "";
                            int selRaw = 0, i = 1;
                            strPath = openFileDialog1.FileName;
                            strFileName = strPath.Substring(strPath.LastIndexOf('\\') + 1);
                            strPath = strPath.Replace(strFileName, "");

                            var stream = new MemoryStream(File.ReadAllBytes(Path.Combine(strPath, strFileName)));
                            //var data = Mayhedi.Office.Excel.Reader.Read.ReadObjFromExel(stream);
                            if (strSelection == "TA")
                            {
                                strSheetName = "Sales Target";
                            }
                            else if (strSelection == "CT")
                            {
                                string strdate = dtefromDate.Value.ToString("yyyy");
                                strSheetName = "Collection Target-" + strdate;
                            }
                            else if (strSelection == "MC")
                            {
                                strSheetName = "Credit Limit";
                            }
                            var data = Read.ReadObjFromExel(stream, strSheetName);

                            string[] value = data.Split('~');

                            foreach (string word in value)
                            {
                                if (word != "")
                                {
                                    DG.AllowUserToAddRows = true;
                                    selRaw = Convert.ToInt16(DG.RowCount.ToString());
                                    selRaw = selRaw - 1;
                                    DG.Rows.Add(1);
                                    string[] value1 = word.Split('!');
                                    DG[0, selRaw].Value = Utility.GetMerzeNameFromTeritorryCode(strComID, value1[0].ToString());
                                    DG[1, selRaw].Value = Utility.GetLedgerNameFromTeritorryCode(strComID, value1[0].ToString());  
                                    DG[2, selRaw].Value = Math.Round(Utility.Val(value1[1]),2);
                                    DG[3, selRaw].Value = Math.Round(Utility.Val(value1[2]), 2);
                                    DG[4, selRaw].Value = Math.Round(Utility.Val(value1[3]), 2);
                                    DG[5, selRaw].Value = Math.Round(Utility.Val(value1[4]), 2);
                                    DG[6, selRaw].Value = Math.Round(Utility.Val(value1[5]), 2);
                                    DG[7, selRaw].Value = Math.Round(Utility.Val(value1[6]), 2);
                                    DG[8, selRaw].Value = Math.Round(Utility.Val(value1[7]), 2);
                                    DG[9, selRaw].Value = Math.Round(Utility.Val(value1[8]), 2);
                                    DG[10, selRaw].Value = Math.Round(Utility.Val(value1[9]), 2);
                                    DG[11, selRaw].Value = Math.Round(Utility.Val(value1[10]), 2);
                                    DG[12, selRaw].Value = Math.Round(Utility.Val(value1[11]), 2);
                                    DG[13, selRaw].Value = Math.Round(Utility.Val(value1[12]), 2);
                                    //if (selRaw % 2 == 0)
                                    //{
                                    //    DG.Rows[selRaw].DefaultCellStyle.BackColor = Color.Beige;
                                    //}
                                    //else
                                    //{
                                    //    DG.Rows[selRaw].DefaultCellStyle.BackColor = Color.White;
                                    //}
                                    lngCount += 1;

                                }

                            }
                            lblTotalrecord.Text = "Total Count:" + lngCount.ToString();
                            lblDisplay.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        #endregion
        #region "Save/Edit"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string hh = "", strDuplicate = "";
            string strInsert = "Y",strFdate="",strTdate="";
            string strLedgerName = "",strKey,strChildKey,strBranchID,srTran="",strvalue="",strMonthID="";
            if (uctxtbranchName.Text =="")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtbranchName.Focus();
                return;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
           
            if (DG[0, 0].Value == null)
            {
                MessageBox.Show("No Record Found");
                return;
            }

          
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtbranchName.Text);
            strKey =(dtefromDate.Value.ToString("ddMMyyyy") + dteTodate.Value.ToString("ddMMyyyy") + strBranchID).Replace(" ",string.Empty);
            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        srTran = "";

                        if (strSelection == "TA")
                        {
                            strDuplicate = Utility.mCheckDuplicateItem(strComID, "SALES_TARGET_ACHIEVEMENT_MASTER", "TARGET_ACHIEVE_KEY", strKey);
                        }
                        else if (strSelection == "CT")
                        {
                            strDuplicate = Utility.mCheckDuplicateItem(strComID, "SALES_COLL_TARGET_MASTER", "COLL_TARGET_KEY", strKey);
                        }
                        else if (strSelection == "MC")
                        {
                            strDuplicate = Utility.mCheckDuplicateItem(strComID, "SALES_CREDIT_LIMIT_MASTER", "CREDIT_LIMIT_KEY", strKey);
                        }
                       
                        if (strDuplicate !="")
                        {
                            MessageBox.Show(strDuplicate);
                            return;
                        }
                        progressBar1.Value = 0;
                        progressBar1.Maximum = DG.Rows.Count;
                        for (int introw = 0; introw < DG.Rows.Count; introw++)
                        {
                            if (DG[1, introw].Value != null)
                            {


                                strLedgerName = DG[1, introw].Value.ToString().Trim();

                                //if (strLedgerName == "Asraful Haque Suhuk")
                                //{
                                //    MessageBox.Show("");
                                //}
                                

                                for (int intcol = 2; intcol < DG.Columns.Count; intcol++)
                                {
                                    strMonthID = DG.Columns[intcol].HeaderText;
                                    strFdate = GetDateFromMonthID(strMonthID);
                                    strTdate = Utility.LastDayOfMonth(Convert.ToDateTime(strFdate)).ToString("dd-MM-yyyy");

                                    strChildKey = (DG[1, introw].Value + strMonthID).Replace(" ", string.Empty);
                                    //strChildKey = (DG[1, introw].Value + strMonthID);

                                    if (DG[intcol, introw].Value != null)
                                    {
                                        strvalue = DG[intcol, introw].Value.ToString();
                                    }
                                    else
                                    {
                                        strvalue = "";
                                    }
                                    srTran = strChildKey + "|" + strLedgerName + "|" + strMonthID + "|" + intcol + "|" + introw + "|" + strvalue + "|" + strFdate + "|" + strTdate;
                                    srTran += "~";
                                    hh = invms.mInsertTarget(strComID, strInsert, strKey, "", dtefromDate.Text.ToString(), dteTodate.Text.ToString(), strBranchID, strSelection, srTran,"");
                                    if ( hh!="1")
                                    {
                                        MessageBox.Show("Name Mismatch " + strLedgerName);
                                        return;
                                       
                                    }
                                    srTran = "";
                                    strInsert = "N";
                                }
                            }

                            progressBar1.Value += 1;
                        }

                        if (hh == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strtFormName, strtFormName,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSALES, strBranchID);
                            } 
                            DG.Rows.Clear();
                            uctxtbranchName.Text = "";
                            lblTotalrecord.Text = "";
                            mClear();
                            uctxtbranchName.Focus();
                        }
                        else
                        {
                            MessageBox.Show(hh);
                        }
                      


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(hh.ToString());
                    }
                }
            }

            else
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        srTran = "";
                        string strDelete = invms.mDeleteTarget(strComID, textBox1.Text, strSelection);
                        if (strDelete == "Deleted...")
                        {
                            progressBar1.Value = 0;
                            progressBar1.Maximum = DG.Rows.Count;
                            for (int introw = 0; introw < DG.Rows.Count; introw++)
                            {
                                if (DG[1, introw].Value != null)
                                {

                                    strLedgerName = DG[1, introw].Value.ToString().Trim();
                                    //if (strLedgerName == "Md. Mizanur Rahman")
                                    //{
                                    //    MessageBox.Show("");
                                    //}


                                    for (int intcol = 2; intcol < DG.Columns.Count; intcol++)
                                    {
                                        strMonthID = DG.Columns[intcol].HeaderText;
                                        strFdate = GetDateFromMonthID(strMonthID);
                                        strTdate = Utility.LastDayOfMonth(Convert.ToDateTime(strFdate)).ToString("dd-MM-yyyy");

                                        strChildKey = (DG[1, introw].Value + strMonthID).Replace(" ", string.Empty);
                                        //strChildKey = (DG[1, introw].Value + strMonthID);

                                        if (DG[intcol, introw].Value != null)
                                        {
                                            strvalue = DG[intcol, introw].Value.ToString();
                                        }
                                        else
                                        {
                                            strvalue = "";
                                        }
                                        srTran = strChildKey + "|" + strLedgerName + "|" + strMonthID + "|" + intcol + "|" + introw + "|" + strvalue + "|" + strFdate + "|" + strTdate;
                                        srTran += "~";
                                        hh = invms.mInsertTarget(strComID, strInsert, textBox1.Text, "", dtefromDate.Text.ToString(), dteTodate.Text.ToString(), strBranchID, strSelection, srTran,"");
                                        if (hh != "1")
                                        {
                                            MessageBox.Show("Name Mismatch " + strLedgerName);
                                            return;

                                        }
                                        srTran = "";
                                        strInsert = "N";
                                    }
                                }
                                progressBar1.Value += 1;
                            }

                            if (hh == "1")
                            {
                                if (Utility.gblnAccessControl)
                                {
                                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strtFormName, strtFormName,
                                                                            2, 0, (int)Utility.MODULE_TYPE.mtSALES, strBranchID);
                                }
                                DG.Rows.Clear();
                                uctxtbranchName.Text = "";
                                lblTotalrecord.Text = "";
                                btnGenerate.Enabled = true;
                                mClear();
                                uctxtbranchName.Focus();
                                m_action = 1;
                            }
                            else
                            {
                                MessageBox.Show(hh);
                            }

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(hh.ToString());
                    }
                }

            }

        }
        #endregion
        #region "Get MonthID"
        private string GetDateFromMonthID(string strMonthID)
        {
            long lnYY=Convert.ToInt64(Utility.Right(strMonthID,2));
            string strMonth =Utility.Left(strMonthID,3);
            if(strMonth.ToUpper()=="JAN")
            {
                return "01-01-" + "20" + lnYY;
            }
            else if (strMonth.ToUpper() == "FEB")
            {
                return "01-02-" + "20" + lnYY;
            }
            else if (strMonth.ToUpper() == "MAR")
            {
                return "01-03-" + "20" + lnYY;
            }
            else if (strMonth.ToUpper() == "APR")
            {
                return "01-04-" + "20" + lnYY;
            }
            else if (strMonth.ToUpper() == "MAY")
            {
                return "01-05-" + "20" + lnYY;
            }
            else if (strMonth.ToUpper() == "JUN")
            {
                return "01-06-" + "20" + lnYY;
            }
            else if (strMonth.ToUpper() == "JUL")
            {
                return "01-07-" + "20" + lnYY;
            }
            else if (strMonth.ToUpper() == "AUG")
            {
                return "01-08-" + "20" + lnYY;
            }
            else if (strMonth.ToUpper() == "SEP")
            {
                return "01-09-" + "20" + lnYY;
            }
            else if (strMonth.ToUpper() == "OCT")
            {
                return "01-10-" + "20" + lnYY;
            }
            else if (strMonth.ToUpper() == "NOV")
            {
                return "01-11-" + "20" + lnYY;
            }
            else if (strMonth.ToUpper() == "DEC")
            {
                return "01-12-" + "20" + lnYY;
            }
            else
            {
                return "";
            }
        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            DG.Rows.Clear();
            uctxtbranchName.Text = "";
            btnGenerate.Enabled = true;
            lblCount.Text = "";
            lblDisplay.Text = "";
            lblTotalrecord.Text = "";
            progressBar1.Value = 0;
            dtefromDate.Enabled = true ;
            dteTodate.Enabled = true;
            uctxtLedgerName.Visible = false;
            lblLedgerName.Visible = false;
            m_action = 1;
        }
        #endregion
        #region "List All"
        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmCollectionCommitementList objfrm = new frmCollectionCommitementList();
            objfrm.strForm = strSelection;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = strtFormName;
            objfrm.onAddAllButtonClicked = new frmCollectionCommitementList.AddAllClick(DisplayList);
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
           
        }
        #endregion
        #region "Display List"
        private void DisplayList(List<SalesTarget> tests, object sender, EventArgs e)
        {
            
            int intPos = 0;
            try
            {

                m_action = 2;
                uctxtbranchName.Focus();
                uctxtLedgerName.Visible = true;
                lblLedgerName.Visible = true;
                btnGenerate.Enabled = false;
                dtefromDate.Enabled = false;
                dteTodate.Enabled = false;
                textBox1.Text = tests[0].strKey;
                dtefromDate.Text = tests[0].strFromDate;
                dteTodate.Text = tests[0].strToDate;
                uctxtbranchName.Text = Utility.gstrGetBranchName(strComID, tests[0].strBranchID);
                int intmonthNo;
                DateTime dteStartDate;
                DG.Rows.Clear();
                for (int intcol = 0; intcol < DG.ColumnCount; intcol++)
                {
                    DG.Columns.RemoveAt(intcol);
                    intcol--;
                }
                dteStartDate = dtefromDate.Value;
                int intmonth = Utility.GetMonthDifference(dteTodate.Value, dtefromDate.Value);
                DG.RowTemplate.Height = 40;
                DG.Columns.Add(Utility.Create_Grid_Column("MPO Name", "MPO Name", 400, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 300, false, DataGridViewContentAlignment.TopLeft, true));
                for (int i = 1; i <= intmonth; i++)
                {
                    //DG.Rows.Add(1);
                    //DG.Rows[i].Cells[0].Value = i;
                    string strMMYY = Utility.GetMonth(i);
                    intmonthNo = dteStartDate.Month;
                    DG.Columns.Add(Utility.Create_Grid_Column(Utility.GetMonth(intmonthNo) + dteStartDate.Year.ToString().Substring(2, 2), Utility.GetMonth(intmonthNo) + dteStartDate.Year.ToString().Substring(2, 2), 100, true, DataGridViewContentAlignment.TopLeft, false));
                    dteStartDate = Utility.NextMonth(dteStartDate);
                }
                //btnGenerate.PerformClick();
                if (strSelection == "TA")
                {
                    List<SalesTarget> objtar = invms.mDisplayTarget(strComID, tests[0].strKey).ToList();
                    foreach (SalesTarget ootar in objtar)
                    {
                        DG.Rows.Add();
                        DG[0, intPos].Value = ootar.strMerzeName;
                        DG[1, intPos].Value = ootar.strLedgerName;
                        List<SalesTarget> objtarmew = invms.mDisplayTargetLedger(strComID, tests[0].strKey, ootar.strLedgerName).ToList();
                        foreach (SalesTarget objCr in objtarmew)
                        {
                            DG[objCr.intColPos, intPos].Value = objCr.dblAmount;
                        }
                        intPos += 1;
                    }
                    lblTotalrecord.Text = "Total Record :" + intPos.ToString();
                }
                else if (strSelection == "CT")
                {
                    //List<SalesTarget> objtar = invms.mDisplaySalesCollection(strComID, tests[0].strKey).ToList();
                    //foreach (SalesTarget ootar in objtar)
                    //{
                    //    DG[ootar.intColPos, ootar.intRowPos].Value = ootar.dblAmount;
                    //}
                    List<SalesTarget> objtar = invms.mDisplayCollectionTarget(strComID, tests[0].strKey).ToList();
                    foreach (SalesTarget ootar in objtar)
                    {
                        DG.Rows.Add();
                        DG[0, intPos].Value = ootar.strMerzeName;
                        DG[1, intPos].Value = ootar.strLedgerName;
                        List<SalesTarget> objtarmew = invms.mDisplaySalesCollection(strComID, tests[0].strKey, ootar.strLedgerName).ToList();
                        foreach (SalesTarget objCr in objtarmew)
                        {
                            DG[objCr.intColPos, intPos].Value = objCr.dblAmount;
                        }
                        intPos += 1;
                    }
                    lblTotalrecord.Text = "Total Record :" + intPos.ToString();
                }

                else if (strSelection == "MC")
                {
                    List<SalesTarget> objtar = invms.mDisplayCreditLimitLedger(strComID, tests[0].strKey).ToList();
                    foreach (SalesTarget ootar in objtar)
                    {
                        DG.Rows.Add();
                        DG[0, intPos].Value = ootar.strMerzeName;
                        DG[1, intPos].Value = ootar.strLedgerName;
                        List<SalesTarget> objtarmew = invms.mDisplayCreditLimit(strComID, tests[0].strKey,ootar.strLedgerName).ToList();
                        foreach (SalesTarget objCr in objtarmew)
                        {
                            DG[objCr.intColPos, intPos].Value = objCr.dblAmount;
                        }
                        intPos += 1;
                    }
                    lblTotalrecord.Text = "Total Record :" + intPos.ToString();
                    

                }
                btnGenerate.Enabled = false;
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "Check Excel Sheet"
        private void btnCheckExcelSheet_Click(object sender, EventArgs e)
        {
            string strLedgerName = "",stristring="",strMerzename="";
            for (int introw = 0; introw < DG.Rows.Count; introw++)
            {
                if (DG[1, introw].Value != null)
                {
                    strLedgerName =DG[1, introw].Value.ToString();
                    strMerzename = DG[0, introw].Value.ToString();
                    string strName= Utility.mGetValue(strComID, "ACC_LEDGER", "LEDGER_NAME", strLedgerName);
                    {
                        if (strName !="")
                        {
                            stristring = stristring + strMerzename + Environment.NewLine;
                        }
                    }
                    strName = "";
                    strMerzename = "";

                }
            }

            if (stristring!="")
            {
                //frmChekExcelSheet objfrm = new frmChekExcelSheet(stristring);
                if (System.Windows.Forms.Application.OpenForms["frmChekExcelSheet"] as frmChekExcelSheet == null)
                {
                    frmChekExcelSheet objfrm = new frmChekExcelSheet(stristring);
                    objfrm.Show();
                    objfrm.MdiParent = this.MdiParent;

                }
                else
                {
                    frmChekExcelSheet objfrm = (frmChekExcelSheet)Application.OpenForms["frmChekExcelSheet"];
                    objfrm.Focus();
                    objfrm.MdiParent = this.MdiParent;
                }
            }
            else
            {
                MessageBox.Show("No Records Found");
                return;
            }

        }
        #endregion

       


    }
}
