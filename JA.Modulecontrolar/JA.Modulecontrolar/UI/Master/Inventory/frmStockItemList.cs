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
using JA.Modulecontrolar.JINVMS;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Master.Inventory
{
    public partial class frmStockItemList : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<StockItem> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        private string strComID { get; set; }
        public frmStockItemList()
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
        private void frmStockItemList_Load(object sender, EventArgs e)
        {
            txtSerach.Select();
            txtSerach.Focus();
            DG.AllowUserToAddRows = false;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "Sl No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Stock Item", "Stock Item", 300, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Product Code", "Product Code", 189, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Under", "Under", 250, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Opn Qty", "Opn Qty", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            mStockItemList(0,"");
        }

        #region "Item List"
        private void mStockItemList(int intstatus,string strPrefix)
        {
            int introw = 0;
             List<StockItem> oogrp;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            if (lblSearch.Text == "Item Name Wise Search :")
            {
                oogrp = invms.mFillStockItemList(strComID, intstatus, strPrefix,"").ToList();
            }
            else
            {
                oogrp = invms.mFillStockItemList(strComID, intstatus, strPrefix,"Alias").ToList();
            }
            if (oogrp.Count > 0)
            {
                foreach (StockItem ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.strItemName;
                    DG[2, introw].Value = ogrp.strItemcode;
                    DG[3, introw].Value = ogrp.strItemGroup;
                    DG[4, introw].Value = ogrp.dblOpnValue;
                    DG[5, introw].Value = "Edit";
                    DG[6, introw].Value = "Delete";
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
        #region "Changed"
        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStatus.Checked==true)
            {
                mStockItemList(0, "");
            }
            else
            {
                mStockItemList(1, "");
            }
        }
       
        private void txtSerach_TextChanged(object sender, EventArgs e)
        {
            if (chkStatus.Checked == true)
            {
                mStockItemList(0, txtSerach.Text);
            }
            else
            {
                mStockItemList(1, txtSerach.Text);
            }
        }
        #endregion
        #region "Content Click"
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
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
            if (e.ColumnIndex == 6)
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
                    string i = invms.mDeleteStockItem(strComID, DG.CurrentRow.Cells[1].Value.ToString());
                    if (i == "Delted...")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, DG.CurrentRow.Cells[1].Value.ToString(),
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                        }
                    }
                    MessageBox.Show(i.ToString());
                    if (chkStatus.Checked == true)
                    {
                        mStockItemList(0, "");
                    }
                    else
                    {
                        mStockItemList(1, "");
                    }
                }

            }
        }
        #endregion
        private List<StockItem> GetSelectedItem()
        {
            List<StockItem> items = new List<StockItem>();
            StockItem itm = new StockItem();
            itm.lngSlNo = Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString());
            items.Add(itm);
            return items;
        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==1)
            {
                lblSearch.Text = "Item Name Wise Search :";
                txtSerach.Focus();
            }
            else if (e.ColumnIndex ==2)
            {
                lblSearch.Text = "Item Code Wise Search :";
                txtSerach.Focus();
            }
        }




    }
}
