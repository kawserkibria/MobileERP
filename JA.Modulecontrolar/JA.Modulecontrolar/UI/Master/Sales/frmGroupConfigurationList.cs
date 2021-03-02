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



namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmGroupConfigurationList : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<StockGroup> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        private string strComID { get; set; }
        public frmGroupConfigurationList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

        private void frmGroupConfigurationList_Load(object sender, EventArgs e)
        {
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "Sl No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Name", "Name", 600, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 100, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 100, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadGroupList();
        }

        #region "Load"
        private void mLoadGroupList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<StockGroup> oogrp = invms.mFillStockGroupconfig(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockGroup ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngslNo;
                    DG[1, introw].Value = ogrp.GroupName;


                    DG[2, introw].Value = "Edit";
                    DG[3, introw].Value = "Delete";
                   
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
        #region "CellContentClick"
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = invms.mDeleteStockGroupNew(strComID, DG.CurrentRow.Cells[1].Value.ToString());
                    if (i == "Deleted...")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, DG.CurrentRow.Cells[1].Value.ToString(),
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                        }
                    }            
                    MessageBox.Show(i.ToString());
                    mLoadGroupList();
                }
            }
            if (e.ColumnIndex == 2)
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
        }
        #endregion
        #region "SelectedItem"
        private List<StockGroup> GetSelectedItem()
        {
            List<StockGroup> items = new List<StockGroup>();
            StockGroup itm = new StockGroup();
            itm.GroupName = DG.CurrentRow.Cells[1].Value.ToString();
            items.Add(itm);
            return items;
        }
        #endregion
    }
}
