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
using JA.Modulecontrolar.UI.Sales;
namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmLedgerConfigurationList : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public delegate void AddAllClick(List<AccountsLedger> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public int intGroup { get; set; }
        private string strComID { get; set; }
        public frmLedgerConfigurationList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

 
        #region "Group"
        private void mLoadGroupList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<AccountsLedger> oogrp = accms.mDisplayLedgerlistt(strComID,203).ToList();
            if (oogrp.Count>0)
            {

                foreach (AccountsLedger ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strConfigkey;
                    DG[1, introw].Value = ogrp.strLedgerName;
                    DG[2, introw].Value = ogrp.strEfectDate;
                    DG[3, introw].Value = "Edit";
                    DG[4, introw].Value = "Delete";
                    if (ogrp.strLedgerName.ToUpper() == "Commission For Delivery 5%".ToUpper())
                    {
                        DG[5, introw].Value = "%";
                    }
                    else if (ogrp.strLedgerName.ToUpper() == "Commission On Collection 10%".ToUpper())
                    {
                        DG[5, introw].Value = "%";
                    }
                    else
                    {
                        DG[5, introw].Value = "Amount";
                    }
                    DG[6, introw].Value = "View";
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
            }
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 3)
            {
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
            if (e.ColumnIndex == 4)
            {
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
                    string i = accms.DeleteLedgerConfig(strComID, DG.CurrentRow.Cells[0].Value.ToString());
                    MessageBox.Show(i.ToString());
                    mLoadGroupList();
                }
            }
            if (e.ColumnIndex == 5)
            {

                if (System.Windows.Forms.Application.OpenForms["frmLedgerConfigurationPercentage"] as frmLedgerConfigurationPercentage == null)
                {
                    frmLedgerConfigurationPercentage objfrm = new frmLedgerConfigurationPercentage();
                    objfrm.strLedgerName = DG.CurrentRow.Cells[1].Value.ToString();
                    objfrm.Show();
                    objfrm.MdiParent = this.MdiParent;
                }
                else
                {
                    frmLedgerConfigurationPercentage objfrm = (frmLedgerConfigurationPercentage)Application.OpenForms["frmLedgerConfigurationPercentage"];
                    objfrm.Focus();
                    objfrm.MdiParent = this.MdiParent;
                }

            }
            if (e.ColumnIndex == 6)
            {

                JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.LedgerConfig;
                frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                frmviewer.strHeading = "Ledger Configuration List";
                frmviewer.Show();
            }
        }

        private List<AccountsLedger> GetSelectedItem()
        {
            List<AccountsLedger> items = new List<AccountsLedger>();
            AccountsLedger itm = new AccountsLedger();
            itm.strConfigkey = DG.CurrentRow.Cells[0].Value.ToString();
            itm.strLedgerName = DG.CurrentRow.Cells[1].Value.ToString();
            itm.strEfectDate = DG.CurrentRow.Cells[2].Value.ToString();

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

        private void frmLedgerConfigurationList_Load(object sender, EventArgs e)
        {
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("Configkey", "Configkey", 10, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Group Name", "Group Name", 400, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Dist.", "Dist.", "Dist.", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Dist.", "View.", "View.", 60, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadGroupList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }


    }

}