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

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmGroupConfigurationList : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public delegate void AddAllClick(List<AccountdGroup> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public int intGroup { get; set; }
        public long lngFormPriv { get; set; }
        public int intModuleType { get; set; }
        public string strFormName { get; set; }
        List<AccountdGroup> oogrp;
        private string strComID { get; set; }
        public frmGroupConfigurationList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uctxtSearch_KeyDown);
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            this.DG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DG_KeyPress);
        }

        private void frmGroupConfigurationList_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
           if(intGroup ==202)
           {
               frmLabel.Text = "MPO Group List";
           }
           else if (intGroup == 203)
           {
               frmLabel.Text = "Supplier Group List";
           }
           else
           {
               frmLabel.Text = "Group List";
           }
            
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "Sl No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Primary Type", "Primary Type", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Gr Level", "Gr Level", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("CashFlowType", "CashFlowType", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Group Name", "Group Name", 280, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Group Parent", "Group Parent", 300, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Default Group", "Default Group", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Opening Dr", "Opening Dr", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Opening Cr", "Opening Cr", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Mobile No", "Mobile No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Contact No", "Contact No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Pos", "Pos", 300, false, DataGridViewContentAlignment.TopLeft, true));
            mLoadGroupList();
        }
        #region "Group"
        private void mLoadGroupList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            oogrp = accms.GetGroupList(strComID, intGroup, false, Utility.gstrUserName).ToList();
            if (oogrp.Count>0)
            {

                foreach (AccountdGroup ogrp in oogrp )
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.intPrimaryType;
                    DG[2, introw].Value = ogrp.lngGrLevel;
                    DG[3, introw].Value = ogrp.intCashFlowType;
                    DG[4, introw].Value = ogrp.GroupName;
                    DG[5, introw].Value = ogrp.ParentName;
                    DG[6, introw].Value = ogrp.strDefaultGroup;
                    DG[7, introw].Value = ogrp.dblopeningDr;
                    DG[8, introw].Value = ogrp.dblopeningCr;
                    DG[9, introw].Value = "Edit";
                    DG[10, introw].Value = "Delete";
                    DG[11, introw].Value = ogrp.strMobileNo;
                    DG[12, introw].Value = ogrp.strContactNo;
                    DG[13, introw].Value = ogrp.intMode;
                    //DG[10, introw].Style.BackColor = Color.Beige;
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
                lblCount.Text = "Total Record :" + introw;
                DG.AllowUserToAddRows = false;
            }
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 9)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
            if (e.ColumnIndex == 10)
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
                    string i = accms.DeleteGroup(strComID, Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString()));
                    if (i == "1")
                    {

                        if (Utility.gblnAccessControl)
                        {

                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, DG.CurrentRow.Cells[0].Value.ToString(),
                                                                    3, 0, (int)intModuleType, "0001");
                        }
                    }
                    if (i == "1")
                    {
                        mLoadGroupList();
                    }
                    else
                    {
                        MessageBox.Show(i.ToString());
                    }
                    
                    
                }

            }
        }

        private List<AccountdGroup> GetSelectedItem()
        {
            List<AccountdGroup> items = new List<AccountdGroup>();
            AccountdGroup itm = new AccountdGroup();
            itm.lngSlNo = Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString());
            itm.intPrimaryType = Convert.ToInt32(DG.CurrentRow.Cells[1].Value.ToString());
            itm.lngGrLevel = Convert.ToInt32(DG.CurrentRow.Cells[2].Value.ToString());
            itm.intCashFlowType = Convert.ToInt32(DG.CurrentRow.Cells[3].Value.ToString());
            itm.GroupName = DG.CurrentRow.Cells[4].Value.ToString();
            itm.ParentName = DG.CurrentRow.Cells[5].Value.ToString();
            itm.strMobileNo = DG.CurrentRow.Cells[11].Value.ToString();
            itm.strContactNo = DG.CurrentRow.Cells[12].Value.ToString();
            itm.intMode = Convert.ToInt32(DG.CurrentRow.Cells[13].Value.ToString());
            items.Add(itm);
            return items;
        }

        private void DG_DoubleClick(object sender, EventArgs e)
        {
            //if (DG.Rows.Count == 0)
            //{
            //    return;
            //}
            //if (onAddAllButtonClicked != null)
            //    onAddAllButtonClicked(GetSelectedItem(), sender, e);
            //this.Dispose();
        }

        #endregion

        private void uctxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
              SearchListView(oogrp, uctxtSearch.Text);
          
        }


        private void SearchListView(IEnumerable<AccountdGroup> tests, string searchString = "")
        {
            IEnumerable<AccountdGroup> query;
          
            query = tests;
            if (searchString != "")
            {
                query = tests.Where(x => x.GroupName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }
            DG.Rows.Clear();
            int introw = 0;
            try
            {
                foreach (AccountdGroup ogrp in query)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.intPrimaryType;
                    DG[2, introw].Value = ogrp.lngGrLevel;
                    DG[3, introw].Value = ogrp.intCashFlowType;
                    DG[4, introw].Value = ogrp.GroupName;
                    DG[5, introw].Value = ogrp.ParentName;
                    DG[6, introw].Value = ogrp.strDefaultGroup;
                    DG[7, introw].Value = ogrp.dblopeningDr;
                    DG[8, introw].Value = ogrp.dblopeningCr;
                    DG[9, introw].Value = "Edit";
                    DG[10, introw].Value = "Delete";

                    DG[11, introw].Value = ogrp.strMobileNo;
                    DG[12, introw].Value = ogrp.strContactNo;
                    DG[13, introw].Value = ogrp.intMode;
                    DG.Rows[introw].Cells[9].Style.BackColor = Color.Beige;
                    DG.Rows[introw].Cells[10].Style.BackColor = Color.Beige;
                    //DG.Rows[introw].Cells[9].Style.ForeColor = Color.LightGreen;
                    //if (introw % 2 == 0)
                    //{
                    //    //DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //    DG.Rows[introw].Cells[9].Style.BackColor = Color.Beige;
                    //    DG.Rows[introw].Cells[10].Style.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    //DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //    DG.Rows[introw].Cells[9].Style.BackColor = Color.Beige;
                    //    DG.Rows[introw].Cells[10].Style.BackColor = Color.Beige;
                       
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

        private void uctxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                DG.Select();
                DG.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DG.Select();
                DG.Focus();
            }
        }

   

        private void DG_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(Convert.ToString(Convert.ToInt32(e.KeyChar)));
          
            if (e.KeyChar==9)
            {
                if (DG.Rows.Count == 0)
                {
                    return;
                }
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();

            }
        }

       

     

       


    }
}
