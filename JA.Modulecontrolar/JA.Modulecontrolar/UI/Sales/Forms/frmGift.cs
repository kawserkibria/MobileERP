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
    public partial class frmGift : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstBranch = new ListBox();
        public long lngFormPriv { get; set; }
        List<StockItem> oogrp;
        private string strComID { get; set; }

        public int m_action { get; set; }
        public frmGift()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User Ini"
            this.dteApplicableDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteApplicableDate_KeyPress);
            this.dteApplicableDate.LostFocus += new System.EventHandler(this.dteApplicableDate_LostFocus);

            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);

            this.uclstItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uclstItem_KeyPress);
            this.uclstItem.DoubleClick += new System.EventHandler(this.uclstItem_DoubleClick);

            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);

            this.uctxtGiftItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtGiftItemName_KeyPress);
            this.uctxtGiftItemName.GotFocus += new System.EventHandler(this.uctxtGiftItemName_GotFocus);
            this.uctxtGiftItemName.KeyDown += new KeyEventHandler(uctxtGiftItemName_KeyDown);

            this.uclstGiftItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uclstGiftItem_KeyPress);
            this.uclstGiftItem.DoubleClick += new System.EventHandler(this.uclstGiftItem_DoubleClick);

            this.uctxtGiftQty.TextChanged += new System.EventHandler(this.uctxtGiftQty_TextChanged);
            this.uctxtGiftQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtGiftQty_KeyPress);
            this.uctxtGiftQty.LostFocus += new System.EventHandler(this.uctxtGiftQty_LostFocus);
            this.uctxtGiftItemName.GotFocus += new System.EventHandler(this.uctxtGiftItemName_GotFocus);
            this.uctxtGiftQty.GotFocus += new System.EventHandler(this.uctxtGiftQty_GotFocus);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);

            //this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);
            this.dteApplicableDate.GotFocus += new System.EventHandler(this.dteApplicableDate_GotFocus);
            this.uclstItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstItem_CellFormatting);
            this.uclstGiftItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstGiftItem_CellFormatting);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranchName);
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
        #region "User Deifine"
        private void uclstGiftItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            uclstGiftItem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            uclstGiftItem.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            uclstGiftItem.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void uclstItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            uclstItem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            uclstItem.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            uclstItem.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void uctxtQty_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtQty.Text) == false)
            {
                uctxtQty.Text = "";
            }
        }

        private void uctxtGiftQty_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtGiftQty.Text) == false)
            {
                uctxtGiftQty.Text = "";
            }
        }
        private void uclstGiftItem_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (uclstItem.SelectedRows.Count > 0)
            {
                uclstGiftItem.Text = Utility.GetDgValue(uclstItem, uctxtItemName, 0);
                uclstGiftItem.Visible = false;
                uctxtGiftQty.Focus();
            }
        }
        private void uclstGiftItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtGiftItemName.Text = Utility.GetDgValue(uclstGiftItem, uctxtItemName, 0);
                uclstGiftItem.Visible = false;
                uctxtGiftQty.Focus();
            }
        }

        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtItemName.Text == "")
                {
                    uctxtItemName.Text = "";
                    uclstItem.Visible = false;
                    btnSave.Focus();
                    return;
                }


                if (uctxtItemName.Text != "")
                {
                    uclstItem.Focus();
                    if (uclstItem.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtItemName.Text = uclstItem.Rows[i].Cells[0].Value.ToString();
                        uclstItem.Visible = false;
                        uctxtQty.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtItemName.Text = uclstItem.Rows[i].Cells[0].Value.ToString();
                    uclstItem.Visible = false;
                    uctxtQty.Focus();
                }


            }
        }

        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            uclstItem.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                uclstItem.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                uclstItem.Focus();
            }

            uclstItem.Top = uctxtItemName.Top + 25;
            uclstItem.Left = uctxtItemName.Left;
            uclstItem.Width = uctxtItemName.Width;
            uclstItem.Height = 300;
            //ucdgList.Size = new Size(546, 222);
            uclstItem.BringToFront();
            uclstItem.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }
        private void uclstItem_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (uclstItem.SelectedRows.Count > 0)
            {
                uctxtItemName.Text = Utility.GetDgValue(uclstItem, uctxtItemName, 0);
                uclstItem.Visible = false;
                uctxtQty.Focus();
            }
        }
        private void uclstItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtItemName.Text = Utility.GetDgValue(uclstItem, uctxtItemName, 0);
                uclstItem.Visible = false;
                uctxtQty.Focus();
            }
        }


        private void dteApplicableDate_LostFocus(object sender, System.EventArgs e)
        {
             
           
        }
        private void mDisplayGiftItemGroup(string vstrdate)
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<SalesPriceLevel> oogrp = invms.mDisplayGiftItemGroup(strComID, vstrdate).ToList();
            if (oogrp.Count > 0)
            {
                foreach (SalesPriceLevel ogrp in oogrp)
                {
                    DG.Rows.Add();
                    //DG[0, introw].Value = ogrp.lngslNo;
                    uctxtBranchName.Text = ogrp.strBranchName;
                    dteApplicableDate.Text = ogrp.strDate;
                    dteApplicableDate.Text = ogrp.strDate;
                    DG[0, introw].Value = ogrp.strPrice.strItemName;
                    DG[1, introw].Value = ogrp.dblFromQty + Utility.gGetBaseUOM(strComID, ogrp.strPrice.strItemName);
                    DG[2, introw].Value = ogrp.strBonusItem;
                    DG[3, introw].Value = ogrp.dblToQty + Utility.gGetBaseUOM(strComID, ogrp.strPrice.strItemName);

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
        private void dteApplicableDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
        }
        private void uctxtGiftQty_GotFocus(object sender, System.EventArgs e)
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


        private void uctxtGiftQty_LostFocus(object sender, System.EventArgs e)
        {
           
        }
        private void uctxtGiftItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtGiftItemName.Text == "")
                {
                    uctxtGiftItemName.Text = "";
                    uclstGiftItem.Visible = false;
                    uctxtGiftQty.Focus();
                    return;
                }


                if (uctxtGiftItemName.Text != "")
                {
                    uclstGiftItem.Focus();
                    if (uclstItem.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtGiftItemName.Text = uclstGiftItem.Rows[i].Cells[0].Value.ToString();
                        uclstGiftItem.Visible = false;
                        uctxtQty.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtGiftItemName.Text = uclstGiftItem.Rows[i].Cells[0].Value.ToString();
                    uclstGiftItem.Visible = false;
                    uctxtGiftQty.Focus();
                }


            }
        }

        private void uctxtGiftItemName_KeyDown(object sender, KeyEventArgs e)
        {
            uclstGiftItem.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                uclstGiftItem.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                uclstGiftItem.Focus();
            }

            uclstGiftItem.Top = uctxtGiftItemName.Top + 25;
            uclstGiftItem.Left = uctxtGiftItemName.Left;
            uclstGiftItem.Width = uctxtGiftItemName.Width;
            uclstGiftItem.Height = 300;
            //ucdgList.Size = new Size(546, 222);
            uclstGiftItem.BringToFront();
            uclstGiftItem.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }

        private void DisplayToQty(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {

                uctxtGiftItemName.Text = tests[0].strItemName;
            }
            catch (Exception ex)
            {

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

        private void uctxtGiftQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                double dblQty = 0, dblGiftqty = 0;
                if (uctxtItemName.Text == "")
                {
                    MessageBox.Show("Cannot Empty");
                    uctxtItemName.Focus();
                    return;
                }
                if (uctxtGiftItemName.Text == "")
                {
                    MessageBox.Show("Cannot Empty");
                    uctxtGiftItemName.Focus();
                    return;
                }

                if (uctxtQty.Text == "")
                {
                    dblQty = 0;
                }
                else
                {
                    dblQty = Convert.ToDouble(uctxtQty.Text);
                }
                if (uctxtGiftQty.Text == "")
                {
                    dblGiftqty = 0;
                }
                else
                {
                    dblGiftqty = Convert.ToDouble(uctxtGiftQty.Text);
                }

                mAdditem(uctxtItemName.Text, dblQty, uctxtGiftItemName.Text, dblGiftqty);
                uctxtItemName.Focus();
            }
        }



        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtGiftItemName.Focus();
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
        #region "Load All Item"
        private void mLoadAllItem()
        {
            int introw = 0;


            oogrp = invms.gFillStockItemAll(strComID, "").ToList();
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
                    uclstGiftItem.Rows.Add();
                    uclstItem.Rows.Add();
                    uclstGiftItem[0, introw].Value = ogrp.strItemName;
                    uclstGiftItem[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;;
                    uclstItem[0, introw].Value = ogrp.strItemName;
                    uclstItem[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;

                    //if (introw % 2 == 0)
                    //{
                    //    uclstGiftItem.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //    uclstItem.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    uclstGiftItem.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //    uclstItem.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                uclstGiftItem.AllowUserToAddRows = false;
                uclstItem.AllowUserToAddRows = false;
            }


        }
        #endregion
        #region "Load"
        private void frmGift_Load(object sender, EventArgs e)
        {
            lstBranch.Visible = false;
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 300, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Qty", "Qty", 60, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Gift Item Name", "Gift Item Name", 300, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Qty", "Qty", 60, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            mLoadAllItem();
        }
        #endregion
        #region "Add Item"
        private void mAdditem(string strItemName,double dblQty, string strGiftItem, double dbltoQty)
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
                DG[2, selRaw].Value = strGiftItem;
                DG[3, selRaw].Value = dbltoQty + " " + Utility.gGetBaseUOM(strComID, strItemName);
                DG.AllowUserToAddRows = false;
                uctxtItemName.Text = "";
                uctxtQty.Text = "";
                uctxtGiftItemName.Text = "";
                uctxtGiftQty.Text = "";
                uctxtItemName.Focus();
                DG.ClearSelection();
                int nColumnIndex = 2;
                int nRowIndex = DG.Rows.Count - 1;
                DG.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                DG.FirstDisplayedScrollingRowIndex = nRowIndex;
            }

        }
        #endregion
        #region "Click"
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
                                            DG[2, introw].Value + "," + Utility.Val(DG[3, introw].Value.ToString()) + "," + uctxtBranchName.Text + "~";
                    }

                    if (strGrid != "")
                    {
                        string strmsg = invms.mInsertGiftItem(strComID, strGrid, dteApplicableDate.Text, dteApplicableDate.Value.ToString("yyyyMMdd"));
                        if (strmsg == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Gift", "Gift",
                                                                        m_action, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            } 
                            DG.Rows.Clear();
                            m_action = 1;
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

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==5)
            {
                DG.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (DG.Rows.Count > 0)
            //{
            //    uctxtItemName.Text = DG.CurrentRow.Cells[0].Value.ToString();
            //    uctxtQty.Text = DG.CurrentRow.Cells[1].Value.ToString();
            //    uctxtGiftItemName.Text = DG.CurrentRow.Cells[2].Value.ToString();
            //    uctxtGiftQty.Text = DG.CurrentRow.Cells[3].Value.ToString();
            //    DG.Rows.RemoveAt(e.RowIndex);
            //    uctxtItemName.Focus();

            //}
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DG.Rows.Clear();
            uctxtBranchName.Text = "";
            frmBonusList objfrm = new frmBonusList();
            objfrm.strText = "G";
            objfrm.onAddAllButtonClicked = new frmBonusList.AddAllClick(DisplayPriceList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            dteApplicableDate.Focus();
        }

        #endregion
        #region "Key Up"
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
            uclstItem.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    uclstItem.Rows.Add();
                    uclstItem[0, i].Value = tran.strItemName;
                    uclstItem[1, i].Value = tran.dblClsBalance + " " + tran.strUnit; ;;
                    //if (i % 2 == 0)
                    //{
                    //    uclstItem.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    uclstItem.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void uctxtGiftItemName_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {

                SearchListView1(oogrp, uctxtGiftItemName.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void SearchListView1(IEnumerable<StockItem> tests, string searchString)
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
            uclstGiftItem.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    uclstGiftItem.Rows.Add();
                    uclstGiftItem[0, i].Value = tran.strItemName;
                    uclstGiftItem[1, i].Value = tran.dblClsBalance + " " + tran.strUnit; ;
                    //if (i % 2 == 0)
                    //{
                    //    uclstGiftItem.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    uclstGiftItem.Rows[i].DefaultCellStyle.BackColor = Color.White;
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
        #region "Display"
        private void DisplayPriceList(List<SalesPriceLevel> tests, object sender, EventArgs e)
        {
            try

            {
                m_action = 2;
                dteApplicableDate.Text = tests[0].strDate;
                mDisplayGiftItemGroup(dteApplicableDate.Value.ToShortDateString());

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

    }
}
