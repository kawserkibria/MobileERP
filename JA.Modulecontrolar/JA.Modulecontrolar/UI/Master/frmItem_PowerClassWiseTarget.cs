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

namespace JA.Modulecontrolar.UI.Master
{
    public partial class frmItem_PowerClassWiseTarget : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstBranch = new ListBox();
        //private ListBox lstLedgerList = new ListBox();
        public long lngFormPriv { get; set; }
        public string strtFormName { get; set; }
        public int m_action { get; set; }
        public string strSelection { get; set; }
        private string strComID { get; set; }
        public frmItem_PowerClassWiseTarget()
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
            this.DG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DG_KeyDown);
            this.radPackSize.Click += new System.EventHandler(this.radPackSize_Click);
            this.DG.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DG_EditingControlShowing);

            Utility.CreateListBox(lstBranch, pnlMain, uctxtbranchName);
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
       



        private void dtefromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteTodate.Text = Utility.LastDayOfMonth(dtefromDate.Value).ToString();
                uctxtbranchName.Focus();

            }
        }
        private void dteTodate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtbranchName.Focus();

            }
        }
        private void dtefromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
        }
        private void dteTodate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;

        }
        private void uctxtbranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtbranchName.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtbranchName.Text = lstBranch.Text;
            lstBranch.Visible = false;
            btnGenerate.PerformClick();
            DG.Focus();
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
                //if (lstBranch.SelectedValue != null)
                //{
                //    mloadParty(lstBranch.SelectedValue.ToString());
                //}
                btnGenerate.PerformClick();
                DG.Focus();

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
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtbranchName.Text);
        }
        #endregion

        
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int  inttype = 0,introw = 0;;
            string strBranchID;
            //DateTime dteStartDate;
            if (radItemWise.Checked == true)
            {
                inttype = 0;
            }
            else
            {
                inttype = 1;
            }
            DG.Rows.Clear();
            for (int intcol = 0; intcol < DG.ColumnCount; intcol++)
            {
                DG.Columns.RemoveAt(intcol);
                intcol--;
            }
       
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtbranchName.Text);
            DG.RowTemplate.Height = 40;
            if (radItemWise.Checked == true)
            {
                DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("MPO Name", "MPO Name", 300, true, DataGridViewContentAlignment.TopLeft, true));
            }
            else
            {
                DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("MPO Name", "MPO Name", 300, true, DataGridViewContentAlignment.TopLeft, true));
            }
            List<StockItem> oogrp;
            if (m_action == 1)
            {
                 oogrp = invms.mFillStockItemListNew(strComID, inttype, 1).ToList();
            }
            else
            {
                oogrp = invms.mFillStockItemListNewEdit(strComID, inttype, txtOldKey.Text.ToString()).ToList();
            }
            if (oogrp.Count > 0)
            {
                foreach (StockItem osockItem in oogrp)
                {
                    if (inttype == 0)
                    {
                        DG.Columns.Add(Utility.Create_Grid_Column(osockItem.strItemName, osockItem.strItemName, 100, true, DataGridViewContentAlignment.TopLeft, false));
                    }
                    else
                    {
                        DG.Columns.Add(Utility.Create_Grid_Column(osockItem.strItemCategory, osockItem.strItemCategory, 100, true, DataGridViewContentAlignment.TopLeft, false));
                    }
                }
            }
            List<Invoice> objinv = invms.mfillPartyNameNew(strComID, strBranchID, false, Utility.gstrUserName, 0,"").ToList();
            if (objinv.Count > 0)
            {
                
                foreach (Invoice inv in objinv)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = inv.strLedgerName;
                    DG[1, introw].Value = inv.strMereString;
                   
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
            DG.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DG.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DG.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
         
            DG.Columns[0].DefaultCellStyle.BackColor = Color.Bisque;
            DG.Columns[1].DefaultCellStyle.BackColor = Color.Bisque;
            SendKeys.Send("{tab}");
        }

        private void frmCollectionCommitement_Load(object sender, EventArgs e)
        {
            lstBranch.Visible = false;
            
            dtefromDate.Text = Utility.gdteFinancialYearFrom;
            dteTodate.Text = Utility.LastDayOfMonth(dtefromDate.Value).ToString();
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
   
            btnGenerate.PerformClick();
            DG.Columns[0].DefaultCellStyle.BackColor = Color.Bisque;
            DG.Columns[1].DefaultCellStyle.BackColor = Color.Bisque;

        }

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
                                strSheetName = "Collection Target";
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
                                    DG[0, selRaw].Value = value1[0];
                                    DG[1, selRaw].Value = value1[1];
                                    DG[2, selRaw].Value = value1[2];
                                    DG[3, selRaw].Value = value1[3];
                                    DG[4, selRaw].Value = value1[4];
                                    DG[5, selRaw].Value = value1[5];
                                    DG[6, selRaw].Value = value1[6];
                                    DG[7, selRaw].Value = value1[7];
                                    DG[8, selRaw].Value = value1[8];
                                    DG[9, selRaw].Value = value1[9];
                                    DG[10, selRaw].Value = value1[10];
                                    DG[11, selRaw].Value = value1[11];
                                    DG[12, selRaw].Value = value1[12];
                                    DG[13, selRaw].Value = value1[13];
                                    if (selRaw % 2 == 0)
                                    {
                                        DG.Rows[selRaw].DefaultCellStyle.BackColor = Color.Beige;
                                    }
                                    else
                                    {
                                        DG.Rows[selRaw].DefaultCellStyle.BackColor = Color.White;
                                    }
                                    lngCount += 1;

                                }

                            }
                            lblCount.Text = "Total Count:" + lngCount.ToString();
                            lblDisplay.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string hh = "",  strItemPack = "";
            string strInsert = "Y", strFdate = "", strTdate = "", strOldKey = "", strDuplicate = "";
            int inttype = 0, intcount = 1;

            string strLedgerName = "", strKey, strChildKey, strBranchID, srTran = "", strvalue = "", strMonthID = "";
            if (uctxtbranchName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtbranchName.Focus();
                return;
            }
            if (radItemWise.Checked == true)
            {
                inttype = 0;
            }
            else
            {
                inttype = 1;
            }
            if (txtOldKey.Text != "")
            {
                strOldKey = txtOldKey.Text;
            }
            else
            {
                strOldKey = "";
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtbranchName.Text);
            strKey = (dtefromDate.Value.ToString("ddMMyyyy") + dteTodate.Value.ToString("ddMMyyyy") + strBranchID).Replace(" ", string.Empty) + inttype;
            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {

                if (m_action == 1)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "SALES_TARGET_ITEM_PACK_MASTER", "TARGET_ITEM_PACK_KEY", strKey);

                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        return;
                    }
                }
                try
                {
                    progressBar1.Value = 0;
                    progressBar1.Maximum = DG.Rows.Count;
                    for (int introw = 0; introw < DG.Rows.Count; introw++)
                    {
                        if (DG[1, introw].Value != null)
                        {

                            strLedgerName = DG[0, introw].Value.ToString();
                            //strItemPack = DG[1, introw].Value.ToString();
                            //if (strLedgerName == "290-Sajib Howlader-Nawabganj (Dinajpur)")
                            //{
                            //    MessageBox.Show("");
                            //}

                            for (int intcol = 2; intcol < DG.Columns.Count; intcol++)
                            {
                                strMonthID = dtefromDate.Value.ToString("MMMyy");
                                strItemPack = DG.Columns[intcol].HeaderText;
                                strFdate = dtefromDate.Text;
                                strTdate = dteTodate.Text;

                                strChildKey = (strLedgerName.Replace(" ", string.Empty) + strItemPack.Replace(" ", string.Empty) + strMonthID).Replace(" ", string.Empty);

                                if (DG[intcol, introw].Value != null)
                                {
                                    strvalue = DG[intcol, introw].Value.ToString();
                                }
                                else
                                {
                                    strvalue = "";
                                }
                                srTran = strChildKey + "!" + strItemPack + "!" + strFdate + "!" + strTdate + "!" + strMonthID + "!" + intcol + "!" + introw + "!" + strvalue + "!" + strLedgerName + "!";
                                srTran += "~";
                                hh = invms.mInsertItemPackTarget(strComID, strOldKey, strInsert, strKey, strLedgerName, dtefromDate.Text.ToString(), dteTodate.Text.ToString(), strBranchID, inttype, srTran);
                                if (hh != "1")
                                {
                                    MessageBox.Show("Name Mismatch " + strLedgerName);
                                    return;
                                }
                                srTran = "";
                                strInsert = "N";
                            }
                            strInsert = "N";
                        }
                        progressBar1.Value += 1;
                        intcount += 1;
                    }
                    if (hh == "1")
                    {
                        mclear();
                        MessageBox.Show(intcount-1 + " Records Insert Successfully");
                        progressBar1.Value = 0;
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }
        private void mclear()
        {
            btnGenerate.Enabled = true ;
            radItemWise.Enabled = true;
            radPackSize.Enabled = true;
            dtefromDate.Enabled = true;
            //dteTodate.Enabled = true;
            uctxtbranchName.Text = "";
            txtOldKey.Text = "";
            DG.Rows.Clear();
            m_action = 1;
            dtefromDate.Focus();
        }
        private string GetDateFromMonthID(string strMonthID)
        {
            long lnYY = Convert.ToInt64(Utility.Right(strMonthID, 2));
            string strMonth = Utility.Left(strMonthID, 3);
            if (strMonth.ToUpper() == "JAN")
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            mclear();
            frmItem_PowerClassWiseTargetList objfrm = new frmItem_PowerClassWiseTargetList();
            objfrm.strForm = strSelection;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = strtFormName;
            objfrm.onAddAllButtonClicked = new frmItem_PowerClassWiseTargetList.AddAllClick(DisplayList);
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
            
        }


        private void DisplayList(List<SalesTarget> tests, object sender, EventArgs e)
        {
            try
            {
                m_action = 2;
                txtOldKey.Text = tests[0].strKey;
                textBox1.Text = tests[0].strLedgerName;
                uctxtbranchName.Text = tests[0].strBranchName;
                dtefromDate.Text = tests[0].strFromDate;
                dteTodate.Text = tests[0].strToDate;

                if (tests[0].intType ==0)
                {
                    radItemWise.Checked = true;
                }
                else
                {
                    radPackSize.Checked = true;
                }
                btnGenerate.PerformClick();

                List<SalesTarget> objtar = invms.mDisplayItemTarget(strComID, tests[0].strKey).ToList();
                foreach (SalesTarget ootar in objtar)
                {
                    DG[ootar.intColPos, ootar.intRowPos].Value = ootar.dblAmount;
                }
                DG.Columns[0].DefaultCellStyle.BackColor = Color.Bisque;
                DG.Columns[1].DefaultCellStyle.BackColor = Color.Bisque;
                btnGenerate.Enabled = false;
                radItemWise.Enabled = false;
                radPackSize.Enabled = false;
                dtefromDate.Enabled = false;
                dteTodate.Enabled = false;
                DG.Focus();
                SendKeys.Send("{tab}");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void radPackSize_Click(object sender, EventArgs e)
        {
            btnGenerate.PerformClick();
        }

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dblAmount = 0;
            //int intcolimncount = DG.Columns.Count;
            //if (intcolimncount ==e.ColumnIndex)
            //{
            //    SendKeys.Send("{tab}");
            //    SendKeys.Send("{tab}");
            //}
            //if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
            //{
            //    dblAmount = Convert.ToDouble(DG[e.ColumnIndex, e.RowIndex].Value);
            //    for (int i = e.ColumnIndex; i < DG.Columns.Count; i++)
            //    {
            //        DG[i, e.RowIndex].Value = dblAmount;
            //    }
            //}
            if (e.RowIndex == 0)
            {
                dblAmount = Convert.ToDouble(DG[e.ColumnIndex, e.RowIndex].Value);
                for (int i = e.RowIndex; i < DG.Rows.Count; i++)
                {
                    DG[e.ColumnIndex, i].Value = dblAmount;
                }
            }
            else
            {
            }
        }

        private void radPackSize_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radItemWise_Click(object sender, EventArgs e)
        {
            btnGenerate.PerformClick();
        }

       

       




    }
}
