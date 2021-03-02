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
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Master.Accounts
{
    public partial class frmAccountsLedgerList : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public delegate void AddAllClick(List<AccountsLedger> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public int mintLedgerGroup = 0;
        public string strMySQL { get; set; }

        List<AccountsLedger> oogrp;
        public long lngFormPriv { get; set; }
        public int intModuleType { get; set; }
        public int intStatus { get; set; }
        public int intLoadType { get; set; }
        public string strFormName { get; set; }
        private string strComID { get; set; }
        public frmAccountsLedgerList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtSeacrh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSeacrh_KeyUp);

            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            this.DG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellClick);
            this.txtSeacrh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeacrh_KeyPress);
            this.DG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DG_KeyPress);
        }
        #region "Keyup"
        private void txtSeacrh_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListView(oogrp, txtSeacrh.Text);
        }
        #endregion
        #region "Load"
        private void frmAccountsLedgerList_Load(object sender, EventArgs e)
        {

            if (mintLedgerGroup == 202)
            {
                chkClose.Visible = true;
                frmLabel.Text = "Medical Representative List";
                DG.AllowUserToAddRows = false;
                DG.Columns.Add(Utility.Create_Grid_Column("SLNo", "SLNo", 300, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("TC", "TC", 65, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 240, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Under", "Under", 300, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Default Group", "IDefault Group", 200, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Opening Dr", "Opening Dr", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Opening Cr", "Opening Cr", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 70, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 70, true, DataGridViewContentAlignment.TopCenter, true));
            }
            else if (mintLedgerGroup == 204)
            {
                DG.AllowUserToAddRows = false;
                frmLabel.Text = "Doctor/Customer List";
                DG.Columns.Add(Utility.Create_Grid_Column("SLNo", "SLNo", 300, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("CP Code", "CP Code", 80, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 235, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Under", "Under", 300, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Default Group", "IDefault Group", 200, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Opening Dr", "Opening Dr", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Opening Cr", "Opening Cr", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            }
            else if (mintLedgerGroup == 203)
            {
                DG.AllowUserToAddRows = false;
                frmLabel.Text = "Supplier List";
                lblSearch.Text = "Search(Ledger Name):";
                DG.Columns.Add(Utility.Create_Grid_Column("SLNo", "SLNo", 300, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("CP Code", "CP Code", 80, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 280, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Under", "Under", 327, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Default Group", "IDefault Group", 200, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Opening Dr", "Opening Dr", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Opening Cr", "Opening Cr", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            }
            else
            {
                DG.AllowUserToAddRows = false;
                frmLabel.Text = "Ledger List";
                lblSearch.Text = "Search(Ledger Name):";
                DG.Columns.Add(Utility.Create_Grid_Column("SLNo", "SLNo", 300, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("CP Code", "CP Code", 80, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 280, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Under", "Under", 327, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Default Group", "IDefault Group", 200, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Opening Dr", "Opening Dr", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Opening Cr", "Opening Cr", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            }

            mLoadLedgerList(intLoadType);
            calculateTotal();
            if (intLoadType == 1)
            {
                chkStatus.Checked = false;
            }
            else if (intLoadType == 2)
            {
                chkClose.Checked = true;
            }
            else
            {
                chkStatus.Checked = true;
            }
            txtSeacrh.Focus();
            txtSeacrh.Select();
        }
        #endregion
        #region "SearchListView"
        private void SearchListView(IEnumerable<AccountsLedger> tests, string searchString = "")
        {
            IEnumerable<AccountsLedger> query;

            query = tests;
            try
            {
                if (searchString != "")
                {
                    if (lblSearch.Text == "Search(Code):")
                    {
                        query = tests.Where(x => x.strTeritorryCode.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                    }
                    else if (lblSearch.Text == "Search(Ledger Name):")
                    {
                        query = tests.Where(x => x.strLedgerName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                    }
                }
                DG.Rows.Clear();
                int introw = 0;
                foreach (AccountsLedger ogrp in query)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlno;
                    DG[1, introw].Value = ogrp.strTeritorryCode;
                    DG[2, introw].Value = ogrp.strmerzeString;
                    DG[3, introw].Value = ogrp.strParentGroup;
                    DG[4, introw].Value = ogrp.intDefaultGroup;
                    // DG[4, introw].Value = ogrp.dblOpnBalance;
                    if (ogrp.dblOpnBalance < 0)
                    {
                        DG[5, introw].Value = Math.Abs(ogrp.dblOpnBalance);
                        DG[6, introw].Value = 0;
                    }
                    else
                    {
                        DG[5, introw].Value = 0;
                        DG[6, introw].Value = Math.Abs(ogrp.dblOpnBalance);
                    }
                    DG[7, introw].Value = "Edit";
                    DG[8, introw].Value = "Delete";
                    //if (introw % 2 == 0)
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                calculateTotal();
                DG.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        #endregion
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblDr = 0, dblCr = 0;
            if (mintLedgerGroup != 204)
            {
                for (int i = 0; i < DG.Rows.Count; i++)
                {
                    dblDr = dblDr + Utility.Val(DG.Rows[i].Cells[5].Value.ToString());
                    dblCr = dblCr + Utility.Val(DG.Rows[i].Cells[6].Value.ToString());
                }
            }
            else
            {
                dblDr = 0;
                dblCr = 0;
            }


            lblDr.Text = "Total Debit :" + dblDr.ToString();
            lblCr.Text = "Total Credit :" +  dblCr.ToString();
        }
        #endregion
        #region "Load Ledger List"
        private void mLoadLedgerList(int intstatus)
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            if (strMySQL==null)
            {
                strMySQL = "";
            }
            lblCount.Text = "0";
            oogrp = accms.mFillLedgerListNew(strComID, mintLedgerGroup, intstatus, strMySQL, intLoadType).ToList();
            if (oogrp.Count>0)
            {
                textBox1.Text = oogrp[0].strPreserveSQL;
                textBox2.Text = oogrp[0].intStatus.ToString();
                foreach (AccountsLedger ogrp in oogrp)
                {
                    DG.Rows.Add();

                    DG[0, introw].Value = ogrp.lngSlno;
                    DG[1, introw].Value = ogrp.strTeritorryCode;
                    DG[2, introw].Value = ogrp.strmerzeString;
                    DG[3, introw].Value = ogrp.strParentGroup;
                    DG[4, introw].Value = ogrp.intDefaultGroup;
                   // DG[4, introw].Value = ogrp.dblOpnBalance;
                    if (ogrp.dblOpnBalance <0)
                    {
                        DG[5, introw].Value = Math.Abs(ogrp.dblOpnBalance) ;
                        DG[6, introw].Value = 0;
                    }
                    else
                    {
                        DG[5, introw].Value = 0;
                        DG[6, introw].Value = Math.Abs(ogrp.dblOpnBalance) ;
                    }
                    DG[7, introw].Value = "Edit";
                    DG[8, introw].Value = "Delete";
                    //if (introw % 2 == 0)
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
                lblCount.Text = "Total Record :" + introw;
               
            }
        }
        #endregion
        #region "Click"
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                 //if (Convert.ToInt64(DG.CurrentRow.Cells[4].Value)==1)
                 //{
                 //      MessageBox.Show("Default Group cannot be Alter");
                 //      return;
                 //}
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
            if (e.ColumnIndex == 8)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 3))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                if (Convert.ToInt64(DG.CurrentRow.Cells[4].Value) == 1)
                {
                    MessageBox.Show("Default Legder cannot be Delete");
                    return;
                }
                if (DG.CurrentRow.Cells[0].Value != null)
                {
                    var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponse == DialogResult.Yes)
                    {

                        string i = accms.DeleteLedger(strComID, Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString()));
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, strFormName,
                                                                    3, 0, intModuleType, "0001");
                        } 
                        MessageBox.Show(i.ToString());
                        if (i=="Deleted....")
                        {
                            DG.Rows.RemoveAt(e.RowIndex);
                        }
                        //mLoadLedgerList(0);
                        //if (chkStatus.Checked == true)
                        //{
                        //    mLoadLedgerList(0);
                        //}
                        //else
                        //{
                        //    mLoadLedgerList(1);
                        //}
                    }
                }

            }
           
        }
        #endregion
        #region "SeletedItem"
        private List<AccountsLedger> GetSelectedItem(int i=0)
        {
            int introw = 0;
            List<AccountsLedger> items = new List<AccountsLedger>();
            AccountsLedger itm = new AccountsLedger();
            if (i == 0)
            {
                itm.lngSlno = Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString());
                itm.intDefaultGroup = Convert.ToInt32(DG.CurrentRow.Cells[4].Value);
                itm.strPreserveSQL = textBox1.Text;
                itm.intStatus = Convert.ToInt16(textBox2.Text);
            }
            else
            {
                introw=DG.SelectedCells[0].RowIndex-1;
                itm.lngSlno = Convert.ToInt64(DG.Rows[introw].Cells[0].Value.ToString());
                itm.intDefaultGroup = Convert.ToInt32(DG.Rows[introw].Cells[4].Value);
                itm.strPreserveSQL = textBox1.Text;
                itm.intStatus = Convert.ToInt16(textBox2.Text);
            }
            items.Add(itm);
            return items;
        }
        #endregion
        #region "cellClick"
        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                lblSearch.Text = "Search(Code):";
            }
            else if (e.ColumnIndex == 2)
            {
                lblSearch.Text = "Search(Ledger Name):";
            }
        }
        #endregion

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSeacrh_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar==(char)Keys.Return)
            //{
            //    if (onAddAllButtonClicked != null)
            //        onAddAllButtonClicked(GetSelectedItem(), sender, e);
            //    this.Dispose();
            //}


        }

        private void txtSeacrh_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void txtSeacrh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                DG.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DG.Focus();
            }

        }

        private void DG_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == 13)
            {
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(1), sender, e);
                this.Dispose();
            }
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            strMySQL = "";
            
            if (chkStatus.Checked == true)
            {
                chkClose.Checked = false;
                mLoadLedgerList(0);
                intStatus = 0;
            }
            else
            {
                chkClose.Checked = false;
                mLoadLedgerList(1);
                intStatus = 1;

            }
        }

        private void chkClose_CheckedChanged(object sender, EventArgs e)
        {
            strMySQL = "";

            if (chkClose.Checked == true)
            {
                chkStatus.Checked = false;
                mLoadLedgerList(2);
                intStatus = 2;
                chkClose.Checked = true;
            }
            else
            {
                chkClose.Checked = false;
                mLoadLedgerList(0);
                intStatus = 0;
            }

        }



    }
}
