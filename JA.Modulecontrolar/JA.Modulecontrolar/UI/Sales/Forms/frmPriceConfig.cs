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
using JA.Modulecontrolar.UI.Inventory;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmPriceConfig : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private ListBox lstLevelName = new ListBox();
        public long lngFormPriv { get; set; }
        public int m_action { get; set; }
        List<StockItem> oogrp;
        private string strComID { get; set; }

        public frmPriceConfig()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            #region "User Ini"
            this.txtLevelName.KeyDown += new KeyEventHandler(txtLevelName_KeyDown);
            this.txtLevelName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLevelName_KeyPress);
            this.txtLevelName.TextChanged += new System.EventHandler(this.txtLevelName_TextChanged);
            this.lstLevelName.DoubleClick += new System.EventHandler(this.lstLevelName_DoubleClick);
            this.txtLevelName.GotFocus += new System.EventHandler(this.txtLevelName_GotFocus);


            this.dteEffectiveDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteEffectiveDate_KeyPress);
            this.dteEffectiveDate.GotFocus += new System.EventHandler(this.dteEffectiveDate_GotFocus);
            this.dteEffectiveDate.LostFocus += new System.EventHandler(this.dteEffectiveDate_LostFocus);

            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);

            this.uclstGrdItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uclstGrdItem_KeyPress);
            this.uclstGrdItem.DoubleClick += new System.EventHandler(this.uclstGrdItem_DoubleClick);


            this.uctxtFromQty.TextChanged += new System.EventHandler(this.uctxtFromQty_TextChanged);
            this.uctxtFromQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFromQty_KeyPress);
            this.uctxtFromQty.GotFocus += new System.EventHandler(this.uctxtFromQty_GotFocus);

            this.uctxtToQty.TextChanged += new System.EventHandler(this.uctxtToQty_TextChanged);
            this.uctxtToQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtToQty_KeyPress);
            this.uctxtToQty.GotFocus += new System.EventHandler(this.uctxtToQty_GotFocus);
            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtRate.GotFocus += new System.EventHandler(this.uctxtRate_GotFocus);
            this.uctxtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDiscount_KeyPress);
            this.uclstGrdItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstGrdItem_CellFormatting);
            this.uctxtDiscount.GotFocus += new System.EventHandler(this.uctxtDiscount_GotFocus);

            Utility.CreateListBox(lstLevelName, pnlMain, txtLevelName);
            #endregion
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
        #region "User Define Event"
        private void uclstGrdItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void uctxtFromQty_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtFromQty.Text) == false)
            {
                uctxtFromQty.Text = "";
            }
        }

        private void uctxtToQty_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtToQty.Text) == false)
            {
                uctxtToQty.Text = "";
            }
        }

        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtItemName.Text == "")
                {
                    uctxtItemName.Text = "";
                    uclstGrdItem.Visible = false;
                    btnSave.Focus();
                    return;
                }


                if (uctxtItemName.Text != "")
                {
                    uclstGrdItem.Focus();
                    if (uclstGrdItem.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtItemName.Text = uclstGrdItem.Rows[i].Cells[0].Value.ToString();
                        uclstGrdItem.Visible = false;
                        uctxtFromQty.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtItemName.Text = uclstGrdItem.Rows[i].Cells[0].Value.ToString();
                    uclstGrdItem.Visible = false;
                    uctxtFromQty.Focus();
                }


            }
        }

        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            uclstGrdItem.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                uclstGrdItem.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                uclstGrdItem.Focus();
            }

            uclstGrdItem.Top = uctxtItemName.Top + 25;
            uclstGrdItem.Left = uctxtItemName.Left;
            uclstGrdItem.Width = uctxtItemName.Width;
            uclstGrdItem.Height = 300;
            //ucdgList.Size = new Size(546, 222);
            uclstGrdItem.BringToFront();
            uclstGrdItem.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }
        private void uclstGrdItem_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (uclstGrdItem.SelectedRows.Count > 0)
            {
                uctxtItemName.Text = Utility.GetDgValue(uclstGrdItem, uctxtItemName, 0);
                uclstGrdItem.Visible = false;
                uctxtFromQty.Focus();
            }
        }
        private void uclstGrdItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtItemName.Text = Utility.GetDgValue(uclstGrdItem, uctxtItemName, 0);
                uclstGrdItem.Visible = false;
                uctxtFromQty.Focus();
            }
        }
        private void dteEffectiveDate_LostFocus(object sender, System.EventArgs e)
        {
            //if  (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
            //{
            if (txtLevelName.Text != "")
            {
                //mDisplayItemGroup(txtLevelName.Text);
            }
            //}
        }
        private void mDisplayItemGroup(string vstrlevelName)
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);

            List<SalesPriceLevel> oogrp = invms.mDisplayItemGroup(strComID, txtLevelName.Text, dteEffectiveDate.Text).ToList();
            if (oogrp.Count > 0)
            {
                DG.Rows.Clear();
                uctxtOldRefNo.Text = oogrp[0].strSalesPriceLevel;
                foreach (SalesPriceLevel ogrp in oogrp)
                {
                    DG.Rows.Add();
                    //DG[0, introw].Value = ogrp.lngslNo;
                    DG[0, introw].Value = ogrp.strPrice.strItemName;
                    DG[1, introw].Value = ogrp.strPrice.strUnit;
                    DG[2, introw].Value = ogrp.dblFromQty;
                    DG[3, introw].Value = ogrp.dblToQty;
                    DG[4, introw].Value = ogrp.dblRate;
                    DG[5, introw].Value = ogrp.dblDiscount;
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
        private void dteEffectiveDate_GotFocus(object sender, System.EventArgs e)
        {
            lstLevelName.Visible = false;

        }
        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {
            lstLevelName.Visible = false;

        }
        private void uctxtFromQty_GotFocus(object sender, System.EventArgs e)
        {
            lstLevelName.Visible = false;

        }
        private void uctxtToQty_GotFocus(object sender, System.EventArgs e)
        {
            lstLevelName.Visible = false;

        }
        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {
            lstLevelName.Visible = false;

        }
      
        private void uctxtDiscount_GotFocus(object sender, System.EventArgs e)
        {
            lstLevelName.Visible = false;

        }
        private void txtLevelName_TextChanged(object sender, EventArgs e)
        {
            lstLevelName.SelectedIndex = lstLevelName.FindString(txtLevelName.Text);
        }

        private void lstLevelName_DoubleClick(object sender, EventArgs e)
        {
            txtLevelName.Text = lstLevelName.Text;
            dteEffectiveDate.Focus();
        }

        private void txtLevelName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLevelName.Items.Count > 0)
                {
                    txtLevelName.Text = lstLevelName.Text;
                }
                dteEffectiveDate.Focus();

            }
        }
        private void txtLevelName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLevelName.SelectedItem != null)
                {
                    lstLevelName.SelectedIndex = lstLevelName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLevelName.Items.Count - 1 > lstLevelName.SelectedIndex)
                {
                    lstLevelName.SelectedIndex = lstLevelName.SelectedIndex + 1;
                }
            }

        }

        private void txtLevelName_GotFocus(object sender, System.EventArgs e)
        {
            lstLevelName.Visible = true;
           
        }



        private void uctxtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                double dblFromQty = 1, dblToQty = 9999, dblRate = 0, dbldiscount = 0;
                if (uctxtFromQty.Text != "")
                {
                    dblFromQty = Convert.ToDouble(uctxtFromQty.Text);
                }
                if (uctxtToQty.Text != "")
                {
                    dblToQty = Convert.ToDouble(uctxtToQty.Text);
                }
                if (uctxtRate.Text != "" && uctxtRate.Text  !="0")
                {
                    dblRate = Convert.ToDouble(uctxtRate.Text);
                }
                else
                {
                    return;
                }
                if (uctxtDiscount.Text != "")
                {
                    dbldiscount = Convert.ToDouble(uctxtDiscount.Text);
                }

                mAdditemBill(uctxtItemName.Text, uctxtUnit.Text, dblFromQty, dblToQty, dblRate, dbldiscount);

            }
        }

        private void mAdditemBill(string strItemName, string strUnit, double dblFromQty, double dblToQty, double dblRate, double dblDiscount)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < DG.RowCount; j++)
            {
                if (DG[0, j].Value != null)
                {
                    strDown = DG[0, j].Value.ToString();
                }
                if (strItemName == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {

                DG.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DG.RowCount.ToString());
                selRaw = selRaw - 1;
                DG.Rows.Add();
                DG[0, selRaw].Value = strItemName;
                DG[1, selRaw].Value = Utility.gGetBaseUOM(strComID, strItemName);
                DG[2, selRaw].Value = dblFromQty.ToString();
                DG[3, selRaw].Value = dblToQty.ToString();
                DG[4, selRaw].Value = dblRate.ToString();
                DG[5, selRaw].Value = dblDiscount.ToString();
                DG[6, selRaw].Value = "Delete";
                DG.AllowUserToAddRows = false;
                uctxtItemName.Text = "";
                uctxtFromQty.Text = "1";
                uctxtToQty.Text = "9999";
                uctxtUnit.Text = "";
                uctxtRate.Text = "";
                uctxtDiscount.Text = "";
                uctxtItemName.Focus();
                DG.ClearSelection();
                int nColumnIndex = 2;
                int nRowIndex = DG.Rows.Count - 1;
                DG.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                DG.FirstDisplayedScrollingRowIndex = nRowIndex;
            }

        }


        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtDiscount.Focus();

            }
        }
        private void uctxtToQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtRate.Focus();

            }
        }
        private void uctxtFromQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtToQty.Focus();

            }
        }
       

        private void dteEffectiveDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (dteEffectiveDate.Text != "")
                {
                    dteEffectiveDate.Text = Utility.ctrlDateFormat(dteEffectiveDate.Text);
                    if (txtLevelName.Text != "")
                    {
                        mDisplayItemGroup(txtLevelName.Text);
                    }
                    uctxtItemName.Focus();
                }


            }
        }
       

      
        #endregion
        #region "DisplayReqList"
        private void DisplayReqList(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {
                
                uctxtItemName.Text = tests[0].strItemName;
                uctxtUnit.Text = tests[0].strUnit;
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "Load All Item"
        private void mLoadAllItem()
        {
            int introw = 0;


            //oogrp = invms.gFillStockItemAll("").ToList();
            oogrp = invms.mloadAddStockItemFg(strComID, "F").ToList();
            //var bil = (from tsfee in oogrp
            //           select new
            //           {
            //               tsfee.strItemName,
            //               tsfee.dblClsBalance
            //           }).ToList();

            ////uclstGrdItem.value
            //uclstGrdItem.DataSource = bil;
            //uclstGrdItem.Columns[1].Name = "Stock Item";
            //uclstGrdItem.Columns[2].Name = "Cls. Qty";

            if (oogrp.Count > 0)
            {
                foreach (StockItem ogrp in oogrp)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, introw].Value = ogrp.strItemName;
                    uclstGrdItem[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit ;

                    //if (introw % 2 == 0)
                    //{
                    //    uclstGrdItem.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    uclstGrdItem.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                uclstGrdItem.AllowUserToAddRows = false;
            }


        }
        #endregion
        #region "Load"
        private void frmPriceConfig_Load(object sender, EventArgs e)
        {
            lstLevelName.Visible = false;
            //DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 250, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("From Qty", "From Qty", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("To Qty", "To Qty", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Discount", "Discount", 80, true, DataGridViewContentAlignment.TopLeft, true));
            //DG.Columns.Add(Utility.Create_Grid_Column_button("Show", "Show", "Show", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            lstLevelName.ValueMember = "strSalesPriceLevel";
            lstLevelName.DisplayMember = "strSalesPriceLevel";
            lstLevelName.DataSource = invms.mGetPriceLevel(strComID).ToList();
            mLoadAllItem();

        }
        #endregion
        #region "Click"
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==6)
            {
                DG.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strGrid="";
            if (txtLevelName.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                txtLevelName.Focus();
                return;
            }
            if (dteEffectiveDate.Text == "")
            {
                MessageBox.Show("Date Cannot be Empty");
                dteEffectiveDate.Focus();
                return;
            }
            if (DG.Rows.Count ==0)
            {
                MessageBox.Show("Item Cannot be Empty");
                uctxtItemName.Focus();
                return;
            
            }
            double dblAmnont = 0;
            for (int introw = 0; introw < DG.Rows.Count; introw++)
            {
                dblAmnont = Convert.ToDouble(DG[3, introw].Value);
            }
            if (dblAmnont==0)
            {
                MessageBox.Show("Price Cannot be Empty or 0");
                txtLevelName.Focus();
                return;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }

            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                try
                {
                    for (int introw=0;introw< DG.Rows.Count ;introw++)
                    {
                        strGrid =strGrid + txtLevelName.Text + "|"+ dteEffectiveDate.Text + "|" + DG[0,introw].Value + "|" + Convert.ToDouble(DG[2,introw].Value) +"|" +
                                            Convert.ToDouble( DG[3,introw].Value) +"|" + Convert.ToDouble(DG[4,introw].Value) +"|" + Convert.ToDouble(DG[5,introw].Value) +"~";
                    }

                    if (strGrid != "")
                    {
                        string strmsg = invms.mInsertPriceconfig(strComID, strGrid, Convert.ToDateTime(dteEffectiveDate.Text).ToString("yyyyMMdd"), txtLevelName.Text, dteEffectiveDate.Text);
                        if (strmsg == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Price Config", txtLevelName.Text,
                                                                        m_action, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            } 

                            DG.Rows.Clear();
                            txtLevelName.Text = "";
                            uctxtDiscount.Text = "";
                            uctxtOldRefNo.Text = "";
                            uctxtItemName.Text = "";
                            uctxtFromQty.Text = "1";
                            uctxtToQty.Text = "9999";
                            dteEffectiveDate.ReadOnly = false;
                            m_action = 1;
                            txtLevelName.Focus();
                        }
                        else
                        {
                            MessageBox.Show(strmsg);
                        }
                    }
                   
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DG.Rows.Count >0 )
            {
                uctxtItemName.Text = DG.CurrentRow.Cells[0].Value.ToString();
                uctxtUnit.Text = DG.CurrentRow.Cells[1].Value.ToString();
                uctxtFromQty.Text = DG.CurrentRow.Cells[2].Value.ToString();
                uctxtToQty.Text = DG.CurrentRow.Cells[3].Value.ToString();
                uctxtRate.Text = DG.CurrentRow.Cells[4].Value.ToString();
                uctxtDiscount.Text = DG.CurrentRow.Cells[5].Value.ToString();
                uctxtItemName.Focus();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            uctxtToQty.Text = "9999";
            uctxtFromQty.Text = "1";
            uctxtItemName.Text = "";
            uctxtDiscount.Text = "";
            txtLevelName.Text = "";

            txtLevelName.Focus();
            frmPriceConfigList objfrm = new frmPriceConfigList();
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.onAddAllButtonClicked = new frmPriceConfigList.AddAllClick(DisplayPriceList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
           
        }
        #endregion
        #region "Display Price List"
        private void DisplayPriceList(List<SalesPriceLevel> tests, object sender, EventArgs e)
        {
            try
            {
                dteEffectiveDate.Focus();
                DG.Rows.Clear();
                dteEffectiveDate.ReadOnly = true;
                m_action = 2;
                txtLevelName.Text = tests[0].strSalesPriceLevel;
                dteEffectiveDate.Text = tests[0].strDate;
                mDisplayItemGroup(txtLevelName.Text);
                
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "Keu Up"
        private void uctxtItemName_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
               
              SearchListView(oogrp, uctxtItemName.Text);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "Seacr List"
        private void SearchListView(IEnumerable<StockItem> tests, string searchString)
        {
            IEnumerable<StockItem> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }
            //}
            //else if (chkEntryby.Checked)
            //{
            //    query = (from test in tests
            //             where test.entryby.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
            //             select test);

            //}

            //else if (chkAmount.Checked)
            //{
            //    query = (from test in tests
            //             where test.dblNetDebitAmount.ToString().StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
            //             select test);
            //}
            uclstGrdItem.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, i].Value = tran.strItemName;
                    uclstGrdItem[1, i].Value = tran.dblClsBalance + " " + tran.strUnit;
                    //if (i % 2 == 0)
                    //{
                    //    uclstGrdItem.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    uclstGrdItem.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #endregion





    }
}
