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
    public partial class frmMpoCommManualList : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
    
        public delegate void AddAllClick(List<AccountsLedger> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public string strLedgerName { get; set; }
        private string strComID { get; set; }
        public frmMpoCommManualList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
        }


        #region "MPO"
        private void mLoadMPOList()
        {
            int introw = 0;

            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<AccountsLedger> oogrp = accms.mFillManualBill(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (AccountsLedger ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strConfigkey;
                    DG[1, introw].Value = ogrp.strEfectDate;
                    if (Utility.Right(ogrp.strConfigkey,1)=="A")
                    {
                        DG[2, introw].Value = "Active";
                    }
                    else
                    {
                        DG[2, introw].Value = "Inactive";
                    }
                    DG[3, introw].Value = ogrp.strBranchID;
                    DG[4, introw].Value = "Edit";
                    DG[5, introw].Value = "Delete";
                    DG[6, introw].Value = "View";
                    //DG[6, introw].Value = ogrp.strLedgerName;
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;


            }
        }



        private List<AccountsLedger> GetSelectedItem()
        {
            List<AccountsLedger> items = new List<AccountsLedger>();
            AccountsLedger itm = new AccountsLedger();
            itm.strConfigkey = DG.CurrentRow.Cells[0].Value.ToString();
            itm.strEfectDate = DG.CurrentRow.Cells[1].Value.ToString();
            itm.strBranchID = DG.CurrentRow.Cells[3].Value.ToString();
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

        #endregion
        #region "Load"
        private void frmMpoCommManualList_Load(object sender, EventArgs e)
        {

            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("Key", "Key", 80, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Month ID", "Month ID", 450, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Status", "Status", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Branch ID", "Branch ID", 450, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 450, false, DataGridViewContentAlignment.TopLeft, true));
            mLoadMPOList();
        }
        #endregion
        #region "Click"
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
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
            if (e.ColumnIndex == 5)
            {
                string strReposne = Utility.mCheckCommission(strComID, DG.CurrentRow.Cells[2].Value.ToString(), DG.CurrentRow.Cells[1].Value.ToString());
                if (strReposne != "")
                {
                    MessageBox.Show("Transaction Found Cannot Delete");
                    return;
                }

                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = accms.DeleteManualMpoCmm(strComID, DG.CurrentRow.Cells[0].Value.ToString());
                    MessageBox.Show(i.ToString());
                    if (i == "Delete Successfully...")
                    {
                        DG.Rows.RemoveAt(e.RowIndex);
                    }

                }

            }
            if (e.ColumnIndex == 6)
            {

                JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.MpoCommManuallist;
                frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                frmviewer.strString2 = DG.CurrentRow.Cells[1].Value.ToString();
                //frmviewer.strHeading = "Payment Voucher"; 
                frmviewer.Show();
            }
        }
        #endregion


    }


}