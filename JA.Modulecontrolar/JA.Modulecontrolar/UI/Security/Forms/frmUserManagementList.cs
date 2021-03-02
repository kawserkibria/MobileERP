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

namespace JA.Modulecontrolar.UI.Security.Forms
{
    public partial class frmUserManagementList : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public delegate void AddAllClick(List<UserAccess> items, object sender, EventArgs e);

        public AddAllClick onAddAllButtonClicked;
        private string strComID { get; set; }
        List<UserAccess> oogrp;
        public frmUserManagementList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtSearch_KeyUp);
        }

        private void frmUserManagementList_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("ID", "ID", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Name", "Name", 300, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("User Level", "User Level", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Status", "Status", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 100, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 100, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadUserManagement();
        }


        private void mLoadUserManagement()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            oogrp = accms.mGetUserAccessData(strComID, "").ToList();
            if (oogrp.Count > 0)
            {

                foreach (UserAccess ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.LogInName;
                    if (ogrp.intAccessLevel == 1)
                    {
                        DG[2, introw].Value = "Administrator";
                    }
                    else if (ogrp.intAccessLevel == 2)
                    {
                        DG[2, introw].Value = "User";
                    }
                    else if (ogrp.intAccessLevel == 3)
                    {
                        DG[2, introw].Value = "Report Viewer";
                    }
                    if (ogrp.strStatus == "A")
                    {
                        DG[3, introw].Value = "Active";
                    }
                    else
                    {
                        DG[3, introw].Value = "Suspend";
                    }

                    DG[4, introw].Value = "Edit";
                    DG[5, introw].Value = "Delete";
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

        private List<UserAccess> GetSelectedItem()
        {
            List<UserAccess> items = new List<UserAccess>();
            UserAccess itm = new UserAccess();
            itm.lngSlNo = Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString());
            itm.LogInName = DG.CurrentRow.Cells[1].Value.ToString();

            items.Add(itm);
            return items;
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
            if (e.ColumnIndex == 5)
            {
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = accms.mDeleteUserControl(strComID, Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString()), DG.CurrentRow.Cells[1].Value.ToString());
                    if (i == "Delete Successfully..")
                    {
                        //if (Utility.gblnAccessControl)
                        //{
                        //    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "LogIn User", "LogIn User",
                        //                                            3, 0, 7, "0001");
                        //}
                    }
                    MessageBox.Show(i.ToString());
                    mLoadUserManagement();
                }

            }
        }

        private void uctxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                SearchListView(oogrp, uctxtSearch.Text);

            }
            catch (Exception ex)
            {

            }
        }
        private void SearchListView(IEnumerable<UserAccess> tests, string searchString = "")
        {
            IEnumerable<UserAccess> query;
            query = tests;
            if (searchString != "")
            {
                //query = tests.Where(x => x.LogInName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                query = (from test in tests
                         where test.LogInName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                         select test);
            }
            DG.Rows.Clear();
            int introw = 0;
            try
            {
                foreach (UserAccess ogrp in query)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.LogInName;
                    if (ogrp.intAccessLevel == 1)
                    {
                        DG[2, introw].Value = "Administrator";
                    }
                    else if (ogrp.intAccessLevel == 2)
                    {
                        DG[2, introw].Value = "User";
                    }
                    else if (ogrp.intAccessLevel == 3)
                    {
                        DG[2, introw].Value = "Report Viewer";
                    }
                    if (ogrp.strStatus == "A")
                    {
                        DG[3, introw].Value = "Active";
                    }
                    else
                    {
                        DG[3, introw].Value = "Suspend";
                    }

                    DG[4, introw].Value = "Edit";
                    DG[5, introw].Value = "Delete";
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
