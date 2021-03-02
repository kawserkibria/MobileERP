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
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmBonus : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstBranch = new ListBox();
        public long lngFormPriv { get; set; }
        List<StockItem> oogrp;
        public int m_action { get; set; }
        private string strComID { get; set; }
        public frmBonus()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteApplicableDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteApplicableDate_KeyPress);
            this.dteApplicableDate.LostFocus += new System.EventHandler(this.dteApplicableDate_LostFocus);

            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);

            this.uclstGrdItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uclstGrdItem_KeyPress);
            this.uclstGrdItem.DoubleClick += new System.EventHandler(this.uclstGrdItem_DoubleClick);

            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);
            this.uctxtBranchName.LostFocus += new System.EventHandler(this.uctxtBranchName_LostFocus);

            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);
           
            this.dteApplicableDate.GotFocus += new System.EventHandler(this.dteApplicableDate_GotFocus);

            this.uctxtBonusQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBonusQty_KeyPress);
            this.uctxtBonusQty.LostFocus += new System.EventHandler(this.uctxtBonusQty_LostFocus);
            this.uctxtBonusQty.TextChanged += new System.EventHandler(this.uctxtBonusQty_TextChanged);
            this.uctxtBonusQty.GotFocus += new System.EventHandler(this.uctxtBonusQty_GotFocus);
            this.uclstGrdItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstGrdItem_CellFormatting);

            this.DG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellClick);
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranchName);
        }

        #region "User Deifine"

        private void uclstGrdItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void uctxtQty_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtQty.Text) == false)
            {
                uctxtQty.Text = "";
            }
        }

        private void uctxtBonusQty_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtBonusQty.Text) == false)
            {
                uctxtBonusQty.Text = "";
            }
        }
        private void mLoadAllItem()
        {
            int introw = 0;


            oogrp = invms.mloadAddStockItemFg(strComID, "").ToList();
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
                    uclstGrdItem[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;

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
                        uctxtQty.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtItemName.Text = uclstGrdItem.Rows[i].Cells[0].Value.ToString();
                    uclstGrdItem.Visible = false;
                    uctxtQty.Focus();
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
            uclstGrdItem.Height = 200;
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
                uctxtQty.Focus();
            }
        }
        private void uclstGrdItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtItemName.Text = Utility.GetDgValue(uclstGrdItem, uctxtItemName, 0);
                uclstGrdItem.Visible = false;
                uctxtQty.Focus();
            }
        }
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                try
                {

                    DG.Rows.RemoveAt(e.RowIndex);
                }
                catch (Exception ex)
                {

                }
                //DG.Columns.RemoveAt(e.RowIndex);
            }
        }
        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (DG.Rows.Count > 0)
            //{
            //    uctxtItemName.Text = DG.CurrentRow.Cells[0].Value.ToString();
            //    uctxtQty.Text = Utility.Val(DG.CurrentRow.Cells[1].Value.ToString()).ToString();
            //    //uctxtGiftItemName.Text = DG.CurrentRow.Cells[2].Value.ToString();
            //    uctxtBonusQty.Text = Utility.Val(DG.CurrentRow.Cells[2].Value.ToString()).ToString();
            //    DG.Rows.RemoveAt(e.RowIndex);
            //    uctxtItemName.Focus();

            //}
        }
        private void uctxtBranchName_LostFocus(object sender, System.EventArgs e)
        {
            //mDisplayBonusItemGroup(dteApplicableDate.Value.ToShortDateString());
            //if (uctxtBranchName.Text != "")
            //{
            //    mDisplayBonusItemGroup(dteApplicableDate.Value.ToShortDateString());
            //}

        }
        private void dteApplicableDate_LostFocus(object sender, System.EventArgs e)
        {
            //mDisplayBonusItemGroup(dteApplicableDate.Value.ToShortDateString());
            if (uctxtBranchName.Text != "")
            {
                mDisplayBonusItemGroup(dteApplicableDate.Value.ToShortDateString());
            }

        }
        private void mDisplayBonusItemGroup(string vstrdate)
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
           
            List<SalesPriceLevel> oogrp = invms.mDisplayBonusItemGroup(strComID, vstrdate).ToList();
            if (oogrp.Count > 0)
            {
                DG.Rows.Clear();
                foreach (SalesPriceLevel ogrp in oogrp)
                {
                    DG.Rows.Add();
                    //DG[0, introw].Value = ogrp.lngslNo;
                    uctxtBranchName.Text = ogrp.strBranchName;
                    dteApplicableDate.Text = ogrp.strDate;
                    dteApplicableDate.Text = ogrp.strDate;
                    DG[0, introw].Value = ogrp.strPrice.strItemName;
                    DG[1, introw].Value = ogrp.dblFromQty + " " + Utility.gGetBaseUOM(strComID, ogrp.strPrice.strItemName);
                    //DG[2, introw].Value = ogrp.strBonusItem;
                    DG[2, introw].Value = ogrp.dblToQty + " " + Utility.gGetBaseUOM(strComID, ogrp.strPrice.strItemName);
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
        private void dteApplicableDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
        }
        private void uctxtBonusQty_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
        }
        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
        }
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
        }
        private void uctxtGiftItemName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
        }

        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranch.Text;
            uctxtItemName.Focus();
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranch.Text;
                    lstBranch.Visible = false;
                    if (uctxtBranchName.Text != "")
                    {
                        mDisplayBonusItemGroup(dteApplicableDate.Value.ToShortDateString());
                    }
                    uctxtItemName.Focus();
                }

            }
        }
        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranch.SelectedItem != null)
                {
                    lstBranch.SelectedIndex = lstBranch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranch.Items.Count - 1 > lstBranch.SelectedIndex)
                {
                    lstBranch.SelectedIndex = lstBranch.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = true;

            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);
        }


        private void uctxtBonusQty_LostFocus(object sender, System.EventArgs e)
        {
           
        }
        private void mAdditem(string strItemName, double dblQty, string strGiftItem, double dbltoQty)
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
                DG[1, selRaw].Value = dblQty + " " + Utility.gGetBaseUOM(strComID, strItemName);
               // DG[2, selRaw].Value = strGiftItem;
                DG[2, selRaw].Value = dbltoQty + " " + Utility.gGetBaseUOM(strComID, strItemName);
                DG[3, selRaw].Value = "Delete";
                DG.AllowUserToAddRows = false;
                uctxtItemName.Text = "";
                uctxtQty.Text = "";
                uctxtBonusQty.Text = "";
                uctxtItemName.Focus();
                DG.ClearSelection();
                int nColumnIndex = 2;
                int nRowIndex = DG.Rows.Count - 1;
                DG.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                DG.FirstDisplayedScrollingRowIndex = nRowIndex;
            }

        }
        private void uctxtGiftItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtItemName.Focus();
            }
        }
       
     

        private void DisplayFromQty(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {

                uctxtItemName.Text = tests[0].strItemName;
            }
            catch (Exception ex)
            {

            }
        }

        private void uctxtBonusQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                double dblQty = 0, dblBonusqty = 0;
                if (uctxtItemName.Text == "")
                {
                    MessageBox.Show("Cannot Empty");
                    uctxtItemName.Focus();
                    return;
                }


                if (uctxtQty.Text == "")
                {
                    dblQty = 0;
                }
                else
                {
                    dblQty = Utility.Val(uctxtQty.Text);
                }
                if (uctxtBonusQty.Text == "")
                {
                    dblBonusqty = 0;
                }
                else
                {
                    dblBonusqty = Utility.Val(uctxtBonusQty.Text);
                }

                mAdditem(uctxtItemName.Text, dblQty, "", dblBonusqty);
                uctxtItemName.Focus();
            }
        }



        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBonusQty.Focus();
            }
        }

       

        private void dteApplicableDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBranchName.Focus();
            }
        }

        #endregion
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
        private void frmBonus_Load(object sender, EventArgs e)
        {
            lstBranch.Visible = false;
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 550, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Qty", "Qty", 80, true, DataGridViewContentAlignment.TopLeft, true));
            //DG.Columns.Add(Utility.Create_Grid_Column("Gift Item Name", "Gift Item Name", 330, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Bonus Qty", "Bonus Qty", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            mLoadAllItem();
        }

       

      

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strGrid = "";

            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtBranchName.Focus();
                return;
            }
            if (DG.Rows.Count == 0)
            {
                MessageBox.Show("Item Cannot be Empty");
                uctxtItemName.Focus();
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
                    for (int introw = 0; introw < DG.Rows.Count; introw++)
                    {

                        strGrid = strGrid + DG[0, introw].Value + "," + dteApplicableDate.Text + "," + Utility.Val(DG[1, introw].Value.ToString()) + "," +
                                           Utility.Val(DG[2, introw].Value.ToString()) + "," + uctxtBranchName.Text + "~";
                    }

                    if (strGrid != "")
                    {
                        string strmsg = invms.mInsertBonusItem(strComID, strGrid, dteApplicableDate.Text, dteApplicableDate.Value.ToString("yyyyMMdd"));
                        if (strmsg == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Bonus", "Bonus",
                                                                        m_action , 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            }
                            m_action = 1;
                            DG.Rows.Clear();
                            dteApplicableDate.Focus();
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

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DG.Rows.Clear();
            uctxtBranchName.Text = "";
            frmBonusList objfrm = new frmBonusList();
            objfrm.strText = "B";
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.onAddAllButtonClicked = new frmBonusList.AddAllClick(DisplayPriceList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            dteApplicableDate.Focus();
        }


        private void DisplayPriceList(List<SalesPriceLevel> tests, object sender, EventArgs e)
        {
            try
            {
                m_action = 2;
                dteApplicableDate.Text = tests[0].strDate;
                 mDisplayBonusItemGroup(dteApplicableDate.Value.ToShortDateString());
              

            }
            catch (Exception ex)
            {

            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DG_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
       





















    }
}
