using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmAllItem : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public int mloadType { get; set; }//1-Salesprices
        public long lngVtype { get; set; }//1-Salesprices
        public string vstrManufacturer { get; set; }
        public string strSalesLedger { get; set; }
        public string vstrGodown { get; set; }
        List<StockItem> oogrp;
        public delegate void AddAllClick(List<StockItem> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public frmAllItem()
        {
            InitializeComponent();
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);
            this.DG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DG_KeyPress);
            uctxtItemName.KeyUp += uctxtItemName_KeyUp;
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
        }

        #region "User Define"
        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {
            mLoadAllItem();

        }
        private void uctxtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            //long result;
            int intCheck=1;
            //if (long.TryParse(uctxtItemName.Text, out result))
            //{
            //    intCheck = 1;
            //}
            //else
            //{
            //    intCheck = 1;
            //}

            SearchListView(oogrp, intCheck, uctxtItemName.Text.ToString());
        }
        private List<StockItem> GetSelectedItem(int inrow)
        {
            List<StockItem> items = new List<StockItem>();
            StockItem itm = new StockItem();
            itm.strItemName = DG.Rows[inrow].Cells[0].Value.ToString();
            itm.strUnit  = DG.Rows[inrow].Cells[2].Value.ToString();
            itm.dblClsBalance = Convert.ToDouble(DG.Rows[inrow].Cells[3].Value.ToString());
            items.Add(itm);
            return items;
        }
        private void DG_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i = Convert.ToInt16(DG.CurrentRow.Index);
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtItemName.Text = DG.Rows[i].Cells[0].Value.ToString();
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(i), sender, e);
                this.Dispose();
                //uctxtItemName.Focus();
            }
        }
        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                DG.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DG.Focus();
            }
            if (e.KeyCode==Keys.Return)
            {
                int i = Convert.ToInt16(DG.CurrentRow.Index);
                uctxtItemName.Text = DG.Rows[i].Cells[0].Value.ToString();
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(i), sender, e);
                this.Dispose();
            }
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                frmStockItem objfrm = new frmStockItem();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.mSingleEntry = 1;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
              
            }

        }

        #endregion
        private void frmAllItem_Load(object sender, EventArgs e)
        {
            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 350, true , DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Alias", "Alias", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 60, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("ClsQty", "ClsQty", 100, true, DataGridViewContentAlignment.TopLeft, true));
           

        }


        private void SearchListView(IEnumerable<StockItem> tests, int intcheck, string searchString = "")
        {
            int introw = 0;
            IEnumerable<StockItem> query;

            if (searchString !="")
            {
                query = (from test in tests
                         where test.strItemName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                         select test);
            }
            else
            {
                query = tests;
            }
            DG.Rows.Clear();
            foreach (StockItem ogrp in query)
            {
                DG.Rows.Add();
                DG[0, introw].Value = ogrp.strItemName;
                DG[1, introw].Value = ogrp.strItemcode;
                DG[2, introw].Value = ogrp.strUnit;
                DG[3, introw].Value = ogrp.dblClsBalance;

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


        private void mLoadAllItem()
        {
            int introw = 0;
            long lngLedgerGroup=0,lngLedgerManufacFroup=0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            if (mloadType != 1)
            {
                if (lngVtype == (long)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE)
                {
                    lngLedgerGroup = Utility.gintPurchaseValue(strSalesLedger.Replace("'", "''"));
                }
                if (lngVtype == (long)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE)
                {
                    lngLedgerManufacFroup = Utility.gintManuFacGroup(strSalesLedger.Replace("'", "''"));
                }
                if (Utility.glngBusinessType == 4)
                {
                    oogrp = invms.gFillStockItemCheck(vstrGodown, lngLedgerGroup, lngVtype, lngLedgerManufacFroup, "").ToList();
                }
                else
                {
                    oogrp = invms.gFillStockItem("", "", false).ToList();
                }
            }
            else
            {
                oogrp = invms.gFillStockItem("", "", false).ToList();
            }
            if (oogrp.Count > 0)
            {

                foreach (StockItem ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strItemName;
                    DG[1, introw].Value = ogrp.strItemcode;
                    DG[2, introw].Value = ogrp.strUnit;
                    DG[3, introw].Value = ogrp.dblClsBalance;
                   
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

        private void DG_DoubleClick(object sender, EventArgs e)
        {
            if (DG.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DG.CurrentRow.Index);
                uctxtItemName.Text = DG.Rows[i].Cells[0].Value.ToString();
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(i), sender, e);
                this.Dispose();
            }
        }

        private void uctxtItemName_TextChanged(object sender, EventArgs e)
        {

        }


       






      

    }
}
