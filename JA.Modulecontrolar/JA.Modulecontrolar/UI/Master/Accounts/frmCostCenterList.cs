using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Master.Accounts
{
    public partial class frmCostCenterList : JA.Shared.UI.frmSmartFormStandard
    {
        public long lngFormPriv { get; set; }
        private ListBox lstCostCategory = new ListBox();
        private string strComID { get; set; }
        public delegate void AddAllClick(List<VectorCategory> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        JACCMS.SWJAGClient accms = new SWJAGClient();
        List<VectorCategory> oogrp;
        public frmCostCenterList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtSeacrh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSeacrh_KeyUp);
          
        }
        private void txtSeacrh_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListView(oogrp, txtSeacrh.Text);
        }
        private void SearchListView(IEnumerable<VectorCategory> tests, string searchString = "")
        {
            IEnumerable<VectorCategory> query;

            query = tests;
            try
            {
                if (searchString != "")
                {
                    if (lblSearch.Text == "Cost Center:")
                    {
                        query = tests.Where(x => x.strCostCenter.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                    }
                    else if (lblSearch.Text == "Cost Category:")
                    {
                        query = tests.Where(x => x.strVectorcategory.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                    }
                }
                DG.Rows.Clear();
                int introw = 0;
                foreach (VectorCategory ogrp in query)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.strCostCenter;
                    DG[2, introw].Value = ogrp.strVectorcategory;
                    DG[3, introw].Value = "Edit";
                    DG[4, introw].Value = "Delete";
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
                MessageBox.Show(ex.ToString());

            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmCostCenterList_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "Sl No", 320, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Cost Center", "Cost Center", 380, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Cost Catgory", "Cost Catgory", 330, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 45, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadCostCenter();

        }

        private void mLoadCostCenter()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            oogrp = accms.mFillCostCenter(strComID).ToList();
            if (oogrp.Count > 0)
            {

                foreach (VectorCategory ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.strCostCenter;
                    DG[2, introw].Value = ogrp.strVectorcategory;
                    DG[3, introw].Value = "Edit";
                    DG[4, introw].Value = "Delete";
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
                lblCount.Text = "Total Record: " + introw;
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
            if (e.ColumnIndex == 4)
            {
                try
                {
                    if (Utility.gblnAccessControl)
                    {
                        if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                        {
                             MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                            return;
                        }
                    }
                    var strResponseDel = MessageBox.Show("Do You Want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponseDel == DialogResult.Yes)
                    {
                        string strresponse = accms.DeleteCostCenter(strComID, DG.CurrentRow.Cells[1].Value.ToString());
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Cost Center", DG.CurrentRow.Cells[1].Value.ToString(),
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                        }
                        
                        MessageBox.Show(strresponse);
                        mLoadCostCenter();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        private List<VectorCategory> GetSelectedItem()
        {
            List<VectorCategory> items = new List<VectorCategory>();
            VectorCategory itm = new VectorCategory();
            itm.lngSlNo  = Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString());
            itm.strVectorcategory  = DG.CurrentRow.Cells[2].Value.ToString();
            itm.strCostCenter = DG.CurrentRow.Cells[1].Value.ToString();
            items.Add(itm);
            return items;
        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              if (e.ColumnIndex == 1)
            {
                lblSearch.Text = "Cost Center:";
            }
            else if (e.ColumnIndex == 2)
            {
                lblSearch.Text = "Cost Category:";
            }
        }



    }
}
