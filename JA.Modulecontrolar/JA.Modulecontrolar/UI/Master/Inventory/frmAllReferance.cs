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
        private ListBox lstGroup = new ListBox();
        public delegate void AddAllClickFG(List<StockItem> items, object sender, EventArgs e);
        public AddAllClickFG onAddAllButtonClickedFG;
        SPWOIS objWIS = new SPWOIS();
        List<AccBillwise> oogrp;

        List<StockItem> oostritem;
        public string strPartyname = "";
        public string strDate = "";
        public string strBranchID = "";
        public long lngVtype = 0;
        public long lngbtn = 0;
        private string strComID { get; set; }
        public frmAllReferance()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtRefNo.KeyDown += new KeyEventHandler(uctxtRefNo_KeyDown);
            this.DG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DG_KeyPress);
            uctxtRefNo.KeyUp += uctxtRefNo_KeyUp;

            this.uctxtGroupName.KeyDown += new KeyEventHandler(uctxtGroupName_KeyDown);
            this.uctxtGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtGroupName_KeyPress);
            this.uctxtGroupName.TextChanged += new System.EventHandler(this.uctxtGroupName_TextChanged);
            this.lstGroup.DoubleClick += new System.EventHandler(this.lstGroup_DoubleClick);
            this.uctxtGroupName.GotFocus += new System.EventHandler(this.uctxtGroupName_GotFocus);
            Utility.CreateListBox(lstGroup, pnlMain, uctxtGroupName);
        }
        private void uctxtGroupName_TextChanged(object sender, EventArgs e)
        {
            lstGroup.SelectedIndex = lstGroup.FindString(uctxtGroupName.Text);
        }

        private void lstGroup_DoubleClick(object sender, EventArgs e)
        {
            uctxtGroupName.Text = lstGroup.Text;
            uctxtRefNo.Text = "";
            mloadItem();
            lstGroup.Visible = false;
            uctxtRefNo.Focus();
        }

        private void uctxtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstGroup.Items.Count > 0)
                {
                    uctxtGroupName.Text = lstGroup.Text;
                }
                uctxtRefNo.Text = "";
                mloadItem();
                uctxtRefNo.Focus();
            }
            lstGroup.Visible = false;
        }
        private void mloadItem()
        {
            int introw = 0;

            string strDate = DateTime.Now.ToString("dd-MM-yyyy");
            if (uctxtGroupName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtGroupName.FindForm();
                return;
            }

            DG.Rows.Clear();
            oostritem = objWIS.mGetProductStatementView(strComID, uctxtGroupName.Text, "0001", "", "").ToList();
            if (oostritem.Count > 0)
            {

                foreach (StockItem ogrp in oostritem)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strItemName;
                    DG[1, introw].Value = ogrp.strItemcode;
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }

        }
        private void uctxtGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstGroup.SelectedItem != null)
                {
                    lstGroup.SelectedIndex = lstGroup.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstGroup.Items.Count - 1 > lstGroup.SelectedIndex)
                {
                    lstGroup.SelectedIndex = lstGroup.SelectedIndex + 1;
                }
            }

        }

        private void uctxtGroupName_GotFocus(object sender, System.EventArgs e)
        {
            lstGroup.Visible = true;
        }
        private void uctxtRefNo_KeyUp(object sender, KeyEventArgs e)
        {
          
            int intCheck = 1;
         
            if (lngVtype == 9999)
            {
                SearchListViewnew(oostritem, intCheck, uctxtRefNo.Text.ToString());
            }
            else
            {
             
                SearchListViewnew(oostritem, intCheck, uctxtRefNo.Text.ToString());
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
                    DG[1, introw].Value = ogrp.strItemcode;
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

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
                    uctxtRefNo.Text = DG.Rows[i].Cells[1].Value.ToString();
                    if (onAddAllButtonClicked != null)
                        onAddAllButtonClickedFG(GetSelectedItemFG(i), sender, e);
                    this.Dispose();
                }
                //uctxtItemName.Focus();
            }
        }
        private List<StockItem> GetSelectedItemFG(int inrow)
        {
            List<StockItem> items = new List<StockItem>();
            StockItem itm = new StockItem();
            if (lngVtype == 9999)
            {
                itm.strItemName = DG.Rows[inrow].Cells[0].Value.ToString();
            }
            else
            {
                itm.strItemName = DG.Rows[inrow].Cells[1].Value.ToString();
            }
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
                    uctxtRefNo.Text = DG.Rows[i].Cells[1].Value.ToString();
                    if (uctxtRefNo.Text == "")
                    {
                        MessageBox.Show("Code Cannot be Found");
                        return;
                    }
                    if (onAddAllButtonClickedFG != null)
                        onAddAllButtonClickedFG(GetSelectedItemFG(i), sender, e);
                    this.Dispose();
                }
            }

        }
        private void frmAllReferance_Load(object sender, EventArgs e)
        {
            uctxtGroupName.Focus();
            uctxtGroupName.Select();
            if (lngVtype == 9999)
            {

            }
            lstGroup.DisplayMember = "strGroupName";
            lstGroup.ValueMember = "strGroupName";
            lstGroup.DataSource = invms.mFillSample(strComID, "SI").ToList();
            lstGroup.SelectedIndex = lstGroup.FindString(uctxtGroupName.Text);

            DG.AllowUserToAddRows = false;

            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);

            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 330, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Item Code", "Item Code", 220, true, DataGridViewContentAlignment.TopLeft, true));

            uctxtGroupName.Focus();
            uctxtGroupName.Select();


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
                    uctxtRefNo.Text = DG.Rows[i].Cells[1].Value.ToString();
                    if (uctxtRefNo.Text =="")
                    {
                        MessageBox.Show("Code Cannot be Found");
                        return;
                    }
                    if (onAddAllButtonClickedFG != null)
                        onAddAllButtonClickedFG(GetSelectedItemFG(i), sender, e);
                    this.Dispose();
                }



            }
        }







    }
}
