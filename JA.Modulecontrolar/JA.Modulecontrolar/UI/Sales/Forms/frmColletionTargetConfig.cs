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
    public partial class frmColletionTargetConfig : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstBranch = new ListBox();
        public int m_action { get; set; }
        public long lngFormPriv { get; set; }
        public string strOldKey { get; set; }
        public string strFromName { get; set; }
        public string strSelectioname { get; set; }
        private string strComID { get; set; }

        public frmColletionTargetConfig()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.uctxtMonthID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMonthID_KeyPress);
            this.uctxtMonthID.GotFocus += new System.EventHandler(this.uctxtMonthID_GotFocus);

            this.dtefromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtefromDate_KeyPress);
            this.dtefromDate.GotFocus += new System.EventHandler(this.dtefromDate_GotFocus);
            this.dteTodate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteTodate_KeyPress);
            this.dteTodate.GotFocus += new System.EventHandler(this.dteTodate_GotFocus);

            this.uctxtbranchName.KeyDown += new KeyEventHandler(uctxtbranchName_KeyDown);
            this.uctxtbranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtbranchName_KeyPress);
            this.uctxtbranchName.TextChanged += new System.EventHandler(this.uctxtbranchName_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtbranchName.GotFocus += new System.EventHandler(this.uctxtbranchName_GotFocus);
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
        #region "User Define"
        private void uctxtMonthID_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;

        }
        private void uctxtMonthID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtbranchName.Focus();

            }
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
                uctxtbranchName.Focus();

            }
        }
        private void dtefromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false ;
            
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
            btnGenerate.Focus();
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
                btnGenerate.Focus();

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
         
            DateTime dteStartDate;
            double dblclosing = 0;
            DG.Rows.Clear();
            for (int intcol = 0; intcol < DG.ColumnCount; intcol++)
            {
                DG.Columns.RemoveAt(intcol);
                intcol--;
            }
            dteStartDate = dtefromDate.Value;
            int intmonth = Utility.GetMonthDifference(dteTodate.Value, dtefromDate.Value);
            DG.RowTemplate.Height = 40;
            DG.Columns.Add(Utility.Create_Grid_Column("MPO Name", "MPO Name", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 400, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Opening Balance", "Opening Balance", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Collection Target by(%)", "Collection Target by(%)", 150, true, DataGridViewContentAlignment.TopLeft, false ));
            DG.Columns.Add(Utility.Create_Grid_Column("Collection Target by Amount", "Collection Target by Amount", 220, true, DataGridViewContentAlignment.TopLeft, false));


            List<AccountsLedger> oogrp = accms.mFillLedgerList(strComID, 202).ToList();
             if (oogrp.Count > 0)
             {
                 int introw=0;
                 foreach(AccountsLedger ogrp in oogrp)
                 {
                     DG.Rows.Add();
                     DG[0, introw].Value = ogrp.strTeritorryCode;
                     DG[1, introw].Value = ogrp.strLedgerName;
                     dblclosing = Utility.Getdblclosing(strComID, ogrp.strLedgerName, dtefromDate.Value.ToString("dd-MM-yyyy"));
                     if (dblclosing > 0)
                     {
                         DG[2, introw].Value = Math.Abs(dblclosing) + " Cr";
                     }
                     else
                     {
                         DG[2, introw].Value = Math.Abs (dblclosing) + " Dr";
                     }
                     introw += 1;
                 }
                 DG.AllowUserToAddRows = false;
             }
        }

        private void frmCollectionCommitement_Load(object sender, EventArgs e)
        {
            lstBranch.Visible = false;
            dtefromDate.Text = Utility.gdteFinancialYearFrom;
            dteTodate.Text = Utility.gdteFinancialYearTo;
            
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            List<AccountdGroup> oogrp = accms.mDisplayMonthsetupList(strComID, "1", Utility.gdteFinancialYearFrom, Utility.gdteFinancialYearTo).ToList();
            if (oogrp.Count>0)
            {
                uctxtMonthID.Text = oogrp[0].strMonthID;
                dtefromDate.Text = oogrp[0].strFromdate;
                dteTodate.Text = oogrp[0].strTodate;
            }



            uctxtMonthID.Select();
        }
        #region ""Click
        private void btnImport_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
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
                            var data = Read.ReadObjFromExel(stream,"");
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
                                }
                            }


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
            string hh = "", strInsert="Y";
            string strLedgerName = "", strKey, strChildKey, strBranchID, srTran = "", strvalue = "", strMonthID = "";
            double dblPer = 0;
            if (uctxtbranchName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtbranchName.Focus();
                return;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtbranchName.Text);
            strKey = (dtefromDate.Value.ToString("ddMMyyyy") + dteTodate.Value.ToString("ddMMyyyy") + strBranchID).Replace(" ", string.Empty);
            if (m_action == 1)
            {
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "SALES_COLL_TARGET_TRAN", "COLL_TARGET_MONTH_ID", uctxtMonthID.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    uctxtMonthID.Focus();                   
                    return;
                }


                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        srTran = "";

                        for (int introw = 0; introw < DG.Rows.Count; introw++)
                        {

                            strLedgerName = DG[1, introw].Value.ToString();
                            for (int intcol = 2; intcol < DG.Columns.Count; intcol++)
                            {
                                strMonthID = DG.Columns[intcol].HeaderText + uctxtMonthID.Text.ToString().ToUpper();
                                strChildKey = (DG[1, introw].Value + strMonthID).Replace(" ", string.Empty);
                                if (DG[intcol, introw].Value != null)
                                {
                                    strvalue = DG[4, introw].Value.ToString();
                                }
                                else
                                {
                                    strvalue = "0";
                                }

                                if (DG[3, introw].Value != null)
                                {
                                    dblPer  = Convert.ToDouble( DG[3, introw].Value.ToString());
                                }
                                else
                                {
                                    dblPer = 0;
                                }

                                srTran = strChildKey + "," + strLedgerName + "," + dtefromDate.Value.ToString("MMMyy").ToUpper() + "," + dblPer + "," + intcol + "," + introw + "," + strvalue + "";
                                srTran += "~";
                                hh = invms.mInsertTarget(strComID, strInsert, strKey, "", dtefromDate.Text.ToString(), dteTodate.Text.ToString(), strBranchID, strFromName, srTran,"");
                                if (hh!="1")
                                {
                                    MessageBox.Show(hh);
                                }
                                strInsert = "N";
                            }
                        }

                       // hh = invms.mInsertTarget(strKey, "", dtefromDate.Text.ToString(), dteTodate.Text.ToString(), strBranchID, strFromName, srTran);
                        if (hh == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Collection Target", "Collection Target",
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            } 
                            DG.Rows.Clear();
                            uctxtbranchName.Text = "";
                            uctxtbranchName.Focus();
                           
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

                        for (int introw = 0; introw < DG.Rows.Count; introw++)
                        {

                            strLedgerName = DG[0, introw].Value.ToString();
                            for (int intcol = 1; intcol < DG.Columns.Count; intcol++)
                            {
                                strMonthID = DG.Columns[intcol].HeaderText + uctxtMonthID.Text.ToString().ToUpper();
                                strChildKey = (DG[1, introw].Value + strMonthID).Replace(" ", string.Empty);
                                if (DG[intcol, introw].Value != null)
                                {
                                    strvalue = DG[4, introw].Value.ToString();
                                }
                                else
                                {
                                    strvalue = "0";
                                }

                                if (DG[3, introw].Value != null)
                                {
                                    dblPer = Convert.ToDouble(DG[3, introw].Value.ToString());
                                }
                                else
                                {
                                    dblPer = 0;
                                }

                                srTran = srTran + strChildKey + "," + strLedgerName + "," + dtefromDate.Value.ToString("MMMyy").ToUpper() + "," + dblPer + "," + intcol + "," + introw + "," + strvalue + "";
                                srTran += "~";
                            }
                        }

                        hh = invms.mUpdateTarget(strComID, textBox1.Text, "", dtefromDate.Text.ToString(), dteTodate.Text.ToString(), strBranchID, strFromName, srTran);

                        if (hh == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Collection Target", "Collection Target",
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            }
                            DG.Rows.Clear();
                            uctxtbranchName.Text = "";
                            uctxtbranchName.Focus();
                            m_action = 1;
                            btnGenerate.Enabled = true;
                            uctxtMonthID.Enabled = true;

                        }
                        
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(hh.ToString());
                    }
                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmCollectionCommitementList objfrm = new frmCollectionCommitementList();
            objfrm.strForm = strFromName;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = "Target Achievement";
            objfrm.onAddAllButtonClicked = new frmCollectionCommitementList.AddAllClick(DisplayList);
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
            dtefromDate.Focus();
        }
        #endregion
        #region "Display List"
        private void DisplayList(List<SalesTarget> tests, object sender, EventArgs e)
        {
            try
            {
                m_action = 2;
                double dblclosing = 0;

                textBox1.Text = tests[0].strKey;
                dtefromDate.Text = tests[0].strFromDate;
                dteTodate.Text = tests[0].strToDate;
                uctxtbranchName.Text = Utility.gstrGetBranchName(strComID, tests[0].strBranchID);
                btnGenerate.PerformClick();
                progressBar1.Value = 0;

                List<SalesTarget> objtar = invms.mDisplaySalesCollection(strComID, tests[0].strKey,"").ToList();
                progressBar1.Maximum = objtar.Count;
                foreach (SalesTarget ootar in objtar)
                {
                    //DG[1, ootar.intRowPos].Value = ootar.dblOpn;
                    dblclosing = Utility.Getdblclosing(strComID, ootar.strLedgerName, dtefromDate.Value.ToString("dd-MM-yyyy"));
                    if (dblclosing > 0)
                    {
                        DG[2, ootar.intRowPos].Value = Math.Abs(dblclosing) + " Cr";
                    }
                    else
                    {
                        DG[2, ootar.intRowPos].Value = Math.Abs(dblclosing) + " Dr";
                    }


                    DG[3, ootar.intRowPos].Value = ootar.dblPer;
                   
                    DG[4, ootar.intRowPos].Value = ootar.dblAmount;
                    progressBar1.Value += 1;
                }
                btnGenerate.Enabled = false;
                uctxtMonthID.Enabled = false;
                progressBar1.Value = 0;
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            double dblPercen = 0;

            // dataGridView1.Rows.Clear();
            //dblAmount = 2000;
            if (e.RowIndex == 0)
            {
                dblPercen = Convert.ToDouble(DG[e.ColumnIndex, e.RowIndex].Value);
                for (int i = e.RowIndex; i < DG.Rows.Count; i++)
                {
                    DG[3, i].Value = dblPercen;
                    DG[4, i].Value = (Utility.Val(DG[2, i].Value.ToString()) * dblPercen) / 100;
                    //}
                    //else
                    //{
                    //    DG[2, i].Value = dblPercen;
                    //    DG[e.ColumnIndex,e.RowIndex].Value = (Utility.Val(DG[1, e.RowIndex].Value.ToString()) * dblPercen) / 100;
                    //}
                }
            }
            else
            {
                dblPercen = Convert.ToDouble(DG[e.ColumnIndex, e.RowIndex].Value);
                DG[4, e.RowIndex].Value = (Utility.Val(DG[2, e.RowIndex].Value.ToString()) * dblPercen) / 100;
            }
        }

      

    




    }
}
