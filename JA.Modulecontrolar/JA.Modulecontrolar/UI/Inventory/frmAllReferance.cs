using Dutility;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
using JA.Modulecontrolar.JINVMS;
using JA.Modulecontrolar.UI.DReport.Inventory.Viewer;
using JA.Modulecontrolar.UI.DReport.Inventory;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmAllReferance : JA.Shared.UI.frmJagoronFromSearch
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<AccBillwise> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;

        public delegate void AddAllClickFG(List<StockItem> items, object sender, EventArgs e);
        public AddAllClickFG onAddAllButtonClickedFG;

        List<AccBillwise> oogrp;
        List<StockItem> oostritem;
        public string strPartyname = "";
        public string strDate = "";
        public string strBranchID = "";
        public long lngVtype = 0;
        private string strComID { get; set; }
        public frmAllReferance()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtRefNo.KeyDown += new KeyEventHandler(uctxtRefNo_KeyDown);
            this.DG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DG_KeyPress);
            uctxtRefNo.KeyUp += uctxtRefNo_KeyUp;
        }
        private void uctxtRefNo_KeyUp(object sender, KeyEventArgs e)
        {
            //long result;
            int intCheck = 1;
            //if (long.TryParse(uctxtItemName.Text, out result))
            //{
            //    intCheck = 1;
            //}
            //else
            //{
            //    intCheck = 1;
            //}
            if (lngVtype == 9999)
            {
                SearchListViewnew(oostritem, intCheck, uctxtRefNo.Text.ToString());
            }
            else
            {
                SearchListView(oogrp, intCheck, uctxtRefNo.Text.ToString());
            }
        }
        private void SearchListViewnew(IEnumerable<StockItem> tests, int intcheck, string searchString = "")
        {
            try
            {
                int introw = 0;
                IEnumerable<StockItem> query;

                if (searchString != "")
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
                    DG[1, introw].Value = ogrp.strItemName;
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void SearchListView(IEnumerable<AccBillwise> tests, int intcheck, string searchString = "")
        {
            int introw = 0;
            IEnumerable<AccBillwise> query;

            if (searchString != "")
            {
                query = (from test in tests
                         where test.strRefNo.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                         select test);
            }
            else
            {
                query = tests;
            }
            DG.Rows.Clear();
            foreach (AccBillwise ogrp in query)
            {
                DG.Rows.Add();
                DG[0, introw].Value = ogrp.strBillKey;
                if (lngVtype != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                {
                    DG[1, introw].Value = Utility.Mid(ogrp.strRefNo, 6, ogrp.strRefNo.Length - 6);
                }
                else
                {
                    DG[1, introw].Value = ogrp.strRefNo;
                }
                DG[2, introw].Value = ogrp.strDate;
               
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

        private void DG_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i = Convert.ToInt16(DG.CurrentRow.Index);
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lngVtype == 9999)
                {
                    uctxtRefNo.Text = DG.Rows[i].Cells[0].Value.ToString();
                    if (onAddAllButtonClickedFG != null)
                        onAddAllButtonClickedFG(GetSelectedItemFG(i), sender, e);
                    this.Dispose();
                }
                else
                {
                    uctxtRefNo.Text = DG.Rows[i].Cells[0].Value.ToString();
                    if (onAddAllButtonClicked != null)
                        onAddAllButtonClicked(GetSelectedItem(i), sender, e);
                    this.Dispose();
                }
                //uctxtItemName.Focus();
            }
        }
        private List<StockItem> GetSelectedItemFG(int inrow)
        {
            List<StockItem> items = new List<StockItem>();
            StockItem itm = new StockItem();
            itm.strItemName = DG.Rows[inrow].Cells[1].Value.ToString();
            items.Add(itm);
            return items;
        }
        private List<AccBillwise> GetSelectedItem(int inrow)
        {
            List<AccBillwise> items = new List<AccBillwise>();
            AccBillwise itm = new AccBillwise();
            itm.strBillKey = DG.Rows[inrow].Cells[0].Value.ToString();
            itm.strRefNo = DG.Rows[inrow].Cells[1].Value.ToString();
            itm.strDate = DG.Rows[inrow].Cells[2].Value.ToString();
            items.Add(itm);
            return items;
        }

        private void uctxtRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                DG.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DG.Focus();
            }
            if (e.KeyCode == Keys.Return)
            {
                if (DG.CurrentRow == null)
                    return;
                int i = Convert.ToInt16(DG.CurrentRow.Index);
                if (lngVtype == 9999)
                {
                    uctxtRefNo.Text = DG.Rows[i].Cells[0].Value.ToString();
                    if (onAddAllButtonClickedFG != null)
                        onAddAllButtonClickedFG(GetSelectedItemFG(i), sender, e);
                    this.Dispose();
                }
                else
                {
                    uctxtRefNo.Text = DG.Rows[i].Cells[0].Value.ToString();
                    if (onAddAllButtonClicked != null)
                        onAddAllButtonClicked(GetSelectedItem(i), sender, e);
                    this.Dispose();
                }
            }

        }
        private void frmAllReferance_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
          
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            if (lngVtype == (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_PRODUCTION)
            {
                lblName.Visible = false;
                uctxtRefNo.Visible = false;
                DG.Columns.Add(Utility.Create_Grid_Column("Bill Key", "Bill. Key", 350, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Ref. No", "Ref. No", 150, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Batch Size", "Batch Size", 150, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Batch Date", "Batch Date", 115, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 50, true, DataGridViewContentAlignment.TopCenter, true));
                mLoadAllItemBatch();
            }
            else if (lngVtype == 9999)
            {
                
                DG.Columns.Add(Utility.Create_Grid_Column("Bill Key", "Bill. Key", 350, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 450, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Batch Size", "Batch Size", 150, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Batch Date", "Batch Date", 115, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 50, false, DataGridViewContentAlignment.TopCenter, true));
                mLoadAllItemFG();
            }
            else
            {
                if (lngVtype == (long)Utility.VOUCHER_TYPE.vtSALES_ORDER)
                {
                    frmLabel.Text = "Sales Order";
                }
                else if (lngVtype == (long)Utility.VOUCHER_TYPE.vtPURCHASE_ORDER)
                {
                    frmLabel.Text = "Purchase Order";
                }
                DG.Columns.Add(Utility.Create_Grid_Column("Bill Key", "Bill. Key", 350, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Ref. No", "Ref. No", 300, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 200, true, DataGridViewContentAlignment.TopLeft, true));
                mLoadAllItem();
            }
            uctxtRefNo.Focus();
            uctxtRefNo.Select();
        }
        private void mLoadAllItemBatch()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();

            List<MFGvouhcer>  oogrp = invms.mGetProductionNoFBatch(strComID, strPartyname).ToList();
           
            if (oogrp.Count > 0)
            {

                foreach (MFGvouhcer ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strVoucherNo;

                    DG[1, introw].Value = Utility.Mid(ogrp.strVoucherNo, 6, ogrp.strVoucherNo.Length - 6);
                   
                    DG[2, introw].Value = ogrp.strBatchSize ;
                    DG[3, introw].Value = ogrp.strDate;
                    DG[4, introw].Value = "View";
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
        private void mLoadAllItemFG()
        {
            int introw = 0;
            //long lngLedgerGroup = 0, lngLedgerManufacFroup = 0;
            //this.ucFGList.DefaultCellStyle.Font = new Font("verdana", 15.5F);
            DG.Rows.Clear();
            oostritem = invms.mloadAddStockItemFg(strComID, "").ToList();
            if (oostritem.Count > 0)
            {

                foreach (StockItem ogrp in oostritem)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strItemName;
                    DG[1, introw].Value = ogrp.strItemName;
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }
        private void mLoadAllItem()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            if (lngVtype != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS )
            {
                oogrp = accms.gFillPreRefNo(strComID, strPartyname, lngVtype, strDate, strBranchID, "","",0).ToList();
            }
            else
            {
                oogrp = accms.gFillPreSampleClass(strComID).ToList();
            }
            if (oogrp.Count > 0)
            {

                foreach (AccBillwise ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strBillKey;
                    if (lngVtype != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                    {
                        DG[1, introw].Value = Utility.Mid(ogrp.strRefNo, 6, ogrp.strRefNo.Length - 6);
                    }
                    else
                    {
                        DG[1, introw].Value = ogrp.strRefNo;
                    }
                    DG[2, introw].Value = ogrp.strDate;
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
                uctxtRefNo.Text = DG.Rows[i].Cells[0].Value.ToString();
                if (lngVtype == 9999)
                {
                    uctxtRefNo.Text = DG.Rows[i].Cells[0].Value.ToString();
                    if (onAddAllButtonClickedFG != null)
                        onAddAllButtonClickedFG(GetSelectedItemFG(i), sender, e);
                    this.Dispose();
                }
                else
                {
                    uctxtRefNo.Text = DG.Rows[i].Cells[0].Value.ToString();
                    if (onAddAllButtonClicked != null)
                        onAddAllButtonClicked(GetSelectedItem(i), sender, e);
                    this.Dispose();
                }
              


            }
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==4)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Production;
                frmviewer.strFdate = "";
                frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                frmviewer.strSelction = "M";
                frmviewer.Show();
            }
        }





    }
}
