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
    public partial class frmStockOthersCategoryList : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<StockCategory> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        private string strComID { get; set; }
        public frmStockOthersCategoryList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

        private void frmStockOthersCategoryList_Load(object sender, EventArgs e)
        {
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "Sl No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Category Name", "Category Name", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Category Parent", "Category Parent", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Category Primary", "Category Primary", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Default Group", "Default Group", 150, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Show", "Show", "Show", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            mLoadCategoryList();
        }

        private void mLoadCategoryList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<StockCategory> oogrp = invms.mFillStockCategoryOthers(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockCategory ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngslNo;
                    DG[1, introw].Value = ogrp.CategoryName;
                    DG[2, introw].Value = ogrp.CategoryUnder;
                    DG[3, introw].Value = ogrp.strPrimary;
                    DG[4, introw].Value = ogrp.strDefaultFroup;

                    DG[5, introw].Value = "Show";
                    DG[6, introw].Value = "Delete";
                    if (introw % 2 == 0)
                    {
                        DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    }
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }
        private List<StockCategory> GetSelectedItem()
        {
            List<StockCategory> items = new List<StockCategory>();
            StockCategory itm = new StockCategory();
            itm.lngslNo = Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString());
            items.Add(itm);
            return items;
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = invms.mDeletcategoryOthers(strComID, Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show(i.ToString());
                    mLoadCategoryList();
                }
            }

            if (e.ColumnIndex == 5)
            {
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
        }




    }
}
