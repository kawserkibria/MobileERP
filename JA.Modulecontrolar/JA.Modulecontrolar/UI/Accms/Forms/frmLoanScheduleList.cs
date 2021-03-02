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
    public partial class frmLoanScheduleList : JA.Shared.UI.frmSmartFormStandard
    {

        public delegate void AddAllClick(List<AccountsLedger> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        JACCMS.SWJAGClient accms = new SWJAGClient();
      
        public long lngFormPriv { get; set; }
        private string strComID { get; set; }
        public frmLoanScheduleList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
           
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

        
      
        #endregion
        private void mLoadTemplateList()
        {
            int introw = 0;

            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<AccountsLedger> oogrp = accms.mFillLoanList(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (AccountsLedger ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strLedgerName;
                    DG[1, introw].Value = ogrp.strLedgerName;
                    DG[2, introw].Value = ogrp.dblToAmt;
                    DG[3, introw].Value = ogrp.dblNoVoucher;
                    DG[4, introw].Value = "Edit";
                    DG[5, introw].Value = "Delete";
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;


            }
        }



        private List<AccountsLedger> GetSelectedItem()
        {
            List<AccountsLedger> items = new List<AccountsLedger>();
            AccountsLedger itm = new AccountsLedger();
            itm.strLedgerName = DG.CurrentRow.Cells[0].Value.ToString();
            itm.dblToAmt = Convert.ToDouble(DG.CurrentRow.Cells[2].Value);
            itm.dblNoVoucher = Convert.ToDouble(DG.CurrentRow.Cells[3].Value);
            items.Add(itm);
            return items;
        }

        private void DG_DoubleClick(object sender, EventArgs e)
        {
            if (DG.Rows.Count == 0)
            {
                return;
            }
            if (onAddAllButtonClicked != null)
                onAddAllButtonClicked(GetSelectedItem(), sender, e);
            this.Dispose();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLoanScheduleList_Load(object sender, EventArgs e)
        {
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("Template Name", "Template Name", 80, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Template Name", "Template Name", 190, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Total Amount", "Total Amount", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("No of Installment", "No of Installment", 130, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            mLoadTemplateList();
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                //string strReposne = Utility.mCheckCommission(strComID, DG.CurrentRow.Cells[2].Value.ToString(), DG.CurrentRow.Cells[1].Value.ToString());
                //if (strReposne != "")
                //{
                //    MessageBox.Show("Commission is Already Configured, Cannot Alter");
                //    return;
                //}
                //if (Utility.gblnAccessControl)
                //{
                //    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                //    {
                //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
            if (e.ColumnIndex == 5)
            {
                //string strReposne = Utility.mCheckCommission(strComID, DG.CurrentRow.Cells[2].Value.ToString(), DG.CurrentRow.Cells[1].Value.ToString());
                //if (strReposne != "")
                //{
                //    MessageBox.Show("Transaction Found Cannot Delete");
                //    return;
                //}

                //if (Utility.gblnAccessControl)
                //{
                //    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                //    {
                //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}
                var strResponse = MessageBox.Show("Do You Want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = accms.DeleteTemplate(strComID, DG.CurrentRow.Cells[0].Value.ToString());
                    MessageBox.Show(i.ToString());
                    if (i == "Delete Successfully...")
                    {
                        DG.Rows.RemoveAt(e.RowIndex);
                    }

                }

            }
        }
      

       
       
       
        
      
    }
}
