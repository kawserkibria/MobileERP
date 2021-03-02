using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Master
{
    public partial class frmStockGroupList : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstUnder = new ListBox();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<StockGroup> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        List<StockGroup> oogrp;
        public int m_action { get; set; }
        public int mSingleEntry { get; set; }
        private string strComID { get; set; }
        public frmStockGroupList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
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
        private void frmStockGroupList_Load(object sender, EventArgs e)
        {
            txtSearch.Select();
            txtSearch.Focus();
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "Sl No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Group Name", "Group Name", 250, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Group Parent", "Group Parent", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Group Onew Down", "Group Onew Down", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Group Primary", "Group Primary", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Default Group", "Default Group", 150, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            mLoadGroupList();
        }

        #region "Group List"
        private void mLoadGroupList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            oogrp = invms.mFillStockGroupList(strComID).ToList();
            if (oogrp.Count > 0)
            {

                foreach (StockGroup ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngslNo;
                    DG[1, introw].Value = ogrp.GroupName;
                    DG[2, introw].Value = ogrp.GroupUnder;
                    DG[3, introw].Value = ogrp.strOneDown;
                    DG[4, introw].Value = ogrp.strPrimary;
                    DG[5, introw].Value = ogrp.strDefaultFroup;

                    DG[6, introw].Value = "Edit";
                    DG[7, introw].Value = "Delete";
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
        #endregion
        #region "SelectedItem"
        private List<StockGroup> GetSelectedItem()
        {
            List<StockGroup> items = new List<StockGroup>();
            StockGroup itm = new StockGroup();
            itm.lngslNo  = Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString());
            items.Add(itm);
            return items;
        }
        #endregion
        #region "Cnontent Click"
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.ColumnIndex==7)
             {
                 if (Utility.gblnAccessControl)
                 {
                     if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 3))
                     {
                          MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                         return;
                     }
                 }
                 var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (strResponse == DialogResult.Yes)
                 {
                     string i = invms.mDeleteStockGroup(strComID, Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString()));
                     if (i == "Deleted...")
                     {
                         if (Utility.gblnAccessControl)
                         {
                             string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, DG.CurrentRow.Cells[0].Value.ToString(),
                                                                     3, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                         }
                     }
                     MessageBox.Show(i.ToString());
                     mLoadGroupList();
                 }
             }

             if (e.ColumnIndex == 6)
             {
                 if (Utility.gblnAccessControl)
                 {
                     if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 2))
                     {
                          MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                         return;
                     }
                 }
                 if (DG.CurrentRow.Cells[5].Value.ToString()!="")
                 {
                     MessageBox.Show("Default Group Can't Edit");
                     return;
                 }


                 if (onAddAllButtonClicked != null)
                     onAddAllButtonClicked(GetSelectedItem(), sender, e);
                 this.Dispose();
             }
        }
        #endregion

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                SearchListView(oogrp, txtSearch.Text);

            }
            catch (Exception ex)
            {

            }
        }

        private void SearchListView(IEnumerable<StockGroup> tests, string searchString = "")
        {
            IEnumerable<StockGroup> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                query = tests.Where(x => x.GroupName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }

            //}
            //else if (chkEntryby.Checked)
            //{
            //    query = (from test in tests
            //             where test.entryby.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
            //             select test);

            //}

            //else if (chkAmount.Checked)
            //{
            //    query = (from test in tests
            //             where test.dblNetDebitAmount.ToString().StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
            //             select test);
            //}
            DG.Rows.Clear();
            int introw = 0;
            try
            {
                foreach (StockGroup ogrp in query)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngslNo;
                    DG[1, introw].Value = ogrp.GroupName;
                    DG[2, introw].Value = ogrp.GroupUnder;
                    DG[3, introw].Value = ogrp.strOneDown;
                    DG[4, introw].Value = ogrp.strPrimary;
                    DG[5, introw].Value = ogrp.strDefaultFroup;

                    DG[6, introw].Value = "Edit";
                    DG[7, introw].Value = "Delete";
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
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



    }
}
