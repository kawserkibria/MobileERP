﻿using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Inventory;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmPriceConfigList : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<SalesPriceLevel> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public string strText { get; set; }
        public long lngFormPriv { get; set; }
        private string strComID { get; set; }

        public frmPriceConfigList()
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
        private void frmPriceConfigList_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("Sl No", "Sl No", 600, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Price Level", "Price Level", 535, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadPriceList("");
        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (DG.Rows.Count > 0)
            //{
            //    if (onAddAllButtonClicked != null)
            //        onAddAllButtonClicked(GetSelectedItem(e.RowIndex), sender, e);
            //    this.Dispose();
            //}
        }
        private void mLoadPriceList(string vstrlevelName)
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<SalesPriceLevel> oogrp = invms.mRefreshPriceList(strComID, vstrlevelName, "", "").ToList();
            if (oogrp.Count > 0)
            {
                foreach (SalesPriceLevel ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.strSalesPriceLevel;
                    DG[2, introw].Value = ogrp.strDate;
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
        }

        private List<SalesPriceLevel> GetSelectedItem(int inrow)
        {
            List<SalesPriceLevel> items = new List<SalesPriceLevel>();
            SalesPriceLevel itm = new SalesPriceLevel();
            itm.strSalesPriceLevel = DG.Rows[inrow].Cells[1].Value.ToString();
            itm.strDate = DG.Rows[inrow].Cells[2].Value.ToString();
            items.Add(itm);
            return items;
        }

        private void DG_DoubleClick(object sender, EventArgs e)
        {
            //if (DG.Rows.Count > 0)
            //{
            //    int i = Convert.ToInt16(DG.CurrentRow.Index);
            //    if (onAddAllButtonClicked != null)
            //        onAddAllButtonClicked(GetSelectedItem(i), sender, e);
            //    this.Dispose();
            //}
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
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
                    string i = invms.mDeletePriceList(strComID, DG.CurrentRow.Cells[1].Value.ToString(), DG.CurrentRow.Cells[2].Value.ToString());
                    if (i == "Deleted...")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Sales Price List", DG.CurrentRow.Cells[1].Value.ToString(),
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                        }
                    }
                    MessageBox.Show(i.ToString());
                    mLoadPriceList("");
                }
        }
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
                int i = Convert.ToInt16(DG.CurrentRow.Index);
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(i), sender, e);
                this.Dispose();
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }






    }
}
