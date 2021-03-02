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
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Transuction.Inventory
{
    public partial class frmStockProduction : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstBatch = new ListBox();
        public int m_action { get; set; }
        List<StockItem> oogrp;
        private bool mblnNumbMethod { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        private int mintIsPrin { get; set; }
        private string strComID { get; set; }
        List<InvoiceConfig> oinv;
        public int mintVtype { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWIS = new SPWOIS();
        public frmStockProduction()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            // this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);
            this.uctxtRate.TextChanged += new System.EventHandler(this.uctxtRate_TextChanged);

            this.uctxtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtInvoiceNo_KeyPress);
            this.uctxtInvoiceNo.GotFocus += new System.EventHandler(this.uctxtInvoiceNo_GotFocus);

            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.dteDate_GotFocus);

            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);

            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtRate.GotFocus += new System.EventHandler(this.uctxtRate_GotFocus);

            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);
            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);

            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);

            this.uclstGrdItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uclstGrdItem_KeyPress);
            this.uclstGrdItem.DoubleClick += new System.EventHandler(this.uclstGrdItem_DoubleClick);

            this.uctxtBatch.KeyDown += new KeyEventHandler(uctxtBatch_KeyDown);
            this.uctxtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatch_KeyPress);
            this.uctxtBatch.TextChanged += new System.EventHandler(this.uctxtBatch_TextChanged);
            this.lstBatch.DoubleClick += new System.EventHandler(this.lstBatch_DoubleClick);
            this.uctxtBatch.GotFocus += new System.EventHandler(this.uctxtBatch_GotFocus);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);
            this.uclstGrdItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstGrdItem_CellFormatting);

            this.uctxtLocation.KeyDown += new KeyEventHandler(uctxtLocation_KeyDown);
            this.uctxtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLocation_KeyPress);
            this.uctxtLocation.TextChanged += new System.EventHandler(this.uctxtLocation_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.uctxtLocation.GotFocus += new System.EventHandler(this.uctxtLocation_GotFocus);
            this.DG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DG_KeyDown);
            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            Utility.CreateListBox(lstBatch, panel2, uctxtBatch);

        }
        private void uclstGrdItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
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
        #region "PriorSetFocus"
        private void PriorSetFocusText(TextBox txtbox, object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Back)
            {
                if (txtbox.SelectionLength > 0)
                {
                    txtbox.SelectionLength = 0;

                    this.SelectNextControl((Control)sender, false, true, true, true);
                }
                else
                {
                    if ((e.KeyChar == (char)Keys.Back) & (((Control)sender).Text.Length == 0))
                    {

                        this.SelectNextControl((Control)sender, false, true, true, true);
                    }
                }
            }


        }
        #endregion
        #region "User Define"
        private void uctxtQty_TextChanged(object sender, EventArgs e)
        {
            if (mintVtype != (int)Utility.VOUCHER_TYPE.vtSTOCK_PHYSICAL)
            {
                if (Utility.IsNumericNew(uctxtQty.Text) == false)
                {
                    uctxtQty.Text = "";
                }
            }
        }

        private void uctxtRate_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtRate.Text) == false)
            {
                uctxtRate.Text = "";
            }
        }
        private void DG_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    e.SuppressKeyPress = true;
                    int iColumn = DG.CurrentCell.ColumnIndex;
                    int iRow = DG.CurrentCell.RowIndex;
                    
                    if (iColumn == DG.Columns.Count - 1)
                        btnSave.Focus();
                    else
                        DG.CurrentCell = DG[iColumn + 1, iRow];
                }
                catch (Exception ex)
                {

                }

            }
        }
        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;

        }
        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBatch.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtRate, sender, e);
            }
        }
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;

        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtRate.Text = Utility.gdblGetCostPrice(strComID, uctxtItemName.Text, dteDate.Text).ToString();
                if (Utility.Val(uctxtRate.Text) != 0)
                {
                    //mAddStockItem(DG, uctxtItemName.Text, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), Utility.gCheckNull(uctxtBatch.Text));
                    uctxtRate.Focus();
                }
                else
                {
                    uctxtRate.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtQty, sender, e);
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
                    uctxtNarration.Focus();
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

        private void DisplayFgQty(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {

                uctxtItemName.Text = tests[0].strItemName;


            }
            catch (Exception ex)
            {

            }
        }
        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtNarration, sender, e);
            }
        }
        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void dteDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBranchName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                uctxtInvoiceNo.Focus();
            }
        }
        private void dteDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                dteDate.Focus();

            }
        }
        private void uctxtInvoiceNo_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            uclstGrdItem.Visible = false;
        }

        private void uctxtBatch_TextChanged(object sender, EventArgs e)
        {
            lstBatch.SelectedIndex = lstBatch.FindString(uctxtLocation.Text);
        }

        private void lstBatch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBatch.Text = lstBatch.Text;
            uctxtItemName.Focus();
        }

        private void uctxtBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                mAddStockItem(DG, uctxtItemName.Text, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), Utility.gCheckNull(uctxtBatch.Text));
                uctxtItemName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBatch, sender, e);
            }
        }
        private void uctxtBatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBatch.SelectedItem != null)
                {
                    lstBatch.SelectedIndex = lstBatch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBatch.Items.Count - 1 > lstBatch.SelectedIndex)
                {
                    lstBatch.SelectedIndex = lstLocation.SelectedIndex + 1;
                }
            }

        }
        private void mAddStockItem(DataGridView dg, string strItemName, double dblQty, double dblRate, string strBatch)
        {
            int selRaw;
            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < dg.RowCount; j++)
            {
                if (dg[0, j].Value != null)
                {
                    strDown = dg[0, j].Value.ToString();
                }
                if (strItemName == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {

                dg.AllowUserToAddRows = true;
                if (strBatch == Utility.gcEND_OF_LIST)
                {
                    strBatch = "";
                }

                selRaw = Convert.ToInt16(dg.RowCount.ToString());
                selRaw = selRaw - 1;
                dg.Rows.Add();
                dg[0, selRaw].Value = strItemName.ToString();
                dg[1, selRaw].Value = invms.gFillStockItemPhysical(strComID, uctxtLocation.Text, strItemName);
                if (mintVtype == (int)Utility.VOUCHER_TYPE.vtSTOCK_DAMAGE)
                {
                    dg[2, selRaw].Value = dblQty;
                }
                else
                {
                    if (Utility.Left(dblQty.ToString(), 1) == "-")
                    {
                        dg[2, selRaw].Value = dblQty;
                        dg[5, selRaw].Value = Math.Abs(dblQty) * dblRate;
                        
                    }
                    else
                    {
                        dg[2, selRaw].Value = "+" + dblQty;
                        dg[5, selRaw].Value = (dblQty * dblRate);
                    }
                }
                dg[3, selRaw].Value = Utility.gGetBaseUOM(strComID, strItemName.ToString());
                dg[4, selRaw].Value = dblRate;
               
                dg[6, selRaw].Value = strBatch;
                dg[7, selRaw].Value = "Delete";
                dg.AllowUserToAddRows = false;
                uctxtItemName.Text = "";
                uctxtQty.Text = "";
                uctxtRate.Text = "";
                uctxtBatch.Text = "";
                calculateTotal();
                dg.ClearSelection();
                int nColumnIndex = 2;
                int nRowIndex = dg.Rows.Count - 1;
                dg.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                dg.FirstDisplayedScrollingRowIndex = nRowIndex;
            }

        }
        private void uctxtBatch_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstBatch.Visible = true;
            uclstGrdItem.Visible = false;
            lstLocation.Visible = false;

            lstBatch.ValueMember = "Key";
            lstBatch.DisplayMember = "Value";
            lstBatch.DataSource = invms.mFillBatch(strComID).ToList();

            lstBatch.SelectedIndex = lstBatch.FindString(uctxtLocation.Text);
        }

        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            if (uctxtLocation.Text != "")
            {
                mLoadAllItem();
            }
            uctxtItemName.Focus();
        }

        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                }
                if (uctxtLocation.Text != "")
                {
                    mLoadAllItem();
                }
                uctxtItemName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtLocation, sender, e);
            }
        }
        private void uctxtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLocation.SelectedItem != null)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLocation.Items.Count - 1 > lstLocation.SelectedIndex)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex + 1;
                }
            }

        }

        private void uctxtLocation_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = true;
            lstBatch.Visible = false;
            uclstGrdItem.Visible = false;
            if (uctxtBranchName.Text != "")
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName,2).ToList();
            }
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }


        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranchName.Text;
            uctxtLocation.Focus();
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }
                uctxtLocation.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBranchName, sender, e);
            }
        }
        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranchName.SelectedItem != null)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranchName.Items.Count - 1 > lstBranchName.SelectedIndex)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = true;
            lstLocation.Visible = false;
            uclstGrdItem.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }



        #endregion

        #region "Getconfig"
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, mintVtype).ToList();
            if (ooVtype.Count > 0)
            {
                if (ooVtype[0].intVoucherNoMethod == 0)
                {
                    mblnNumbMethod = true;
                }
                else
                {
                    mblnNumbMethod = false;
                }
                mintIsPrin = ooVtype[0].intVoucherNoMethod;
            }


        }
        #endregion
        private void frmStockDamage_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
            mGetConfig();
            mClear(); ;
            lstBranchName.Visible = false;
            lstBatch.Visible = false;
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
          
            if (mintVtype == (int)Utility.VOUCHER_TYPE.vtSTOCK_PHYSICAL)
            {
                frmLabel.Text = "Physical Stock";
                this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
                DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 220, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Curr. Stock", "Curr. Stock", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 60, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Batch", "Batch", 140, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column("BillKey", "BillKey", 200, false, DataGridViewContentAlignment.TopLeft, false));
            }
            else
            {
                frmLabel.Text = "Stock Damage";
                this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
                DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 320, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Curr. Stock", "Curr. Stock", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 60, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Batch", "Batch", 140, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column("BillKey", "BillKey", 200, false, DataGridViewContentAlignment.TopLeft, false));
            }
        }
        private void mLoadAllItem()
        {
            int introw = 0;
            //var data = bbSc.GetBBTestFeeMaps(feecat).ToList();
            if (m_action == 1)
            {
                DG.Rows.Clear();
                lblAmount.Text = "";
                lblQnty.Text = "";
            }
            //oogrp = invms.gFillStockItem(strComID, uctxtLocation.Text, "", false).ToList();
            if (mintVtype == (int)Utility.VOUCHER_TYPE.vtSTOCK_DAMAGE)
            {
                oogrp = objWIS.mGetProductStatementView(strComID, "", lstBranchName.SelectedValue.ToString(), uctxtLocation.Text,"").ToList();
            }
            else if (mintVtype == (int)Utility.VOUCHER_TYPE.vtSTOCK_PHYSICAL)
            {
                oogrp = objWIS.mGetProductStatementView(strComID, "", lstBranchName.SelectedValue.ToString(), uctxtLocation.Text,"").ToList();
            }
            else
            {
                oogrp = objWIS.gFillStockItemNew(strComID, "", uctxtLocation.Text).ToList();
            }

            if (oogrp.Count > 0)
            {
                foreach (StockItem ogrp in oogrp)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, introw].Value = ogrp.strItemName;
                    uclstGrdItem[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit ;
                    introw += 1;
                }
                uclstGrdItem.AllowUserToAddRows = false;
            }


        }
        private void mClear()
        {
            uctxtBranchName.Text = "";
            uctxtLocation.Text = "";
            DG.Rows.Clear();
            uctxtItemName.Text = "";
            uctxtBatch.Text = "";
            uctxtRate.Text = "";
            uctxtNarration.Text = "";
            lblAmount.Text = "";
            lblQnty.Text = "";
            lblAmount.Text = "";
            uctxtQty.Text = "";

            uctxtNarration.Text = "";
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod==true)
            {
                uctxtInvoiceNo.Text = Utility.gstrLastNumber(strComID, mintVtype);
                uctxtInvoiceNo.ReadOnly = true;
                dteDate.Select();
            }
            else
            {

                uctxtInvoiceNo.Text = Utility.gobjNextNumber(uctxtInvoiceNo.Text);
                uctxtInvoiceNo.ReadOnly = false;
                uctxtInvoiceNo.Focus();
                uctxtInvoiceNo.Select();
            }

           // uctxtInvoiceNo.Focus();
        }
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblamnt= 0,dblQnty=0;

            for (int i = 0; i < DG.Rows.Count; i++)
            {
                DG.Rows[i].Cells[5].Value= Math.Abs( Utility.Val(DG.Rows[i].Cells[2].Value.ToString())) * Utility.Val(DG.Rows[i].Cells[4].Value.ToString());
                dblamnt = dblamnt + Utility.Val(DG.Rows[i].Cells[5].Value.ToString());
                dblQnty = dblQnty + Utility.Val(DG.Rows[i].Cells[2].Value.ToString());
            }
             
            lblAmount.Text =  dblamnt.ToString();
            lblQnty.Text = dblQnty.ToString();
        }
        #endregion
        #region "Damage"
        private string mDamage()
        {
            string i = "", strDG = "", strBranchId = "", strRefNumber;
            int intRow = 0;

            strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            for (intRow = 0; intRow < DG.Rows.Count; intRow++)
            {

                if (DG[0, intRow].Value != null)
                {
                    strDG += DG[0, intRow].Value.ToString() + "|" + DG[2, intRow].Value.ToString() +
                                            "|" + DG[3, intRow].Value.ToString() + "|" +
                                            DG[4, intRow].Value.ToString() + "|" + DG[5, intRow].Value.ToString() + "|" + "" + "~";
                }
            }

            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        if (mblnNumbMethod == false)
                        {
                            strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(mintVtype) + strBranchId + uctxtInvoiceNo.Text;
                        }
                        else
                        {
                            strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(mintVtype) + strBranchId + Utility.gstrLastNumber(strComID, mintVtype);
                        }
                        i = invms.mSaveStockDamage(strComID, strRefNumber, (long)mintVtype, dteDate.Text, Utility.Val(lblAmount.Text),
                                                   Utility.gCheckNull(uctxtNarration.Text), strBranchId, Utility.gCheckNull(uctxtLocation.Text), strDG, mblnNumbMethod);

                        if (i == "Inserted...")
                        {
                            mClear();
                        }
                        else
                        {
                            MessageBox.Show("Error!!!");
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mUpdateDamage(strComID, textBox1.Text, (long)mintVtype, dteDate.Text, Utility.Val(lblAmount.Text),
                                                   Utility.gCheckNull(uctxtNarration.Text), strBranchId, Utility.gCheckNull(uctxtLocation.Text), strDG);

                        if (i == "Updated...")
                        {
                            mClear();
                        }
                        else
                        {
                            MessageBox.Show("Error!!!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

            }

            return i;
        }
        #endregion
        #region "Physical Stock"
        private string mPhysicalStock()
        {
            string i = "", strDG = "", strBranchId = "", strRefNumber;
            int intRow = 0;

            strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            for (intRow = 0; intRow < DG.Rows.Count; intRow++)
            {

                if (DG[0, intRow].Value != null)
                {
                    strDG += DG[0, intRow].Value.ToString() + "|" + DG[1, intRow].Value.ToString() +
                                            "|" + DG[2, intRow].Value.ToString() + "|" +
                                            DG[3, intRow].Value.ToString() + "|" + DG[4, intRow].Value.ToString() + "|" + "" + "~";
                }
            }

            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        if (mblnNumbMethod == false)
                        {
                            strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(mintVtype) + strBranchId + uctxtInvoiceNo.Text;
                        }
                        else
                        {
                            strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(mintVtype) + strBranchId + Utility.gstrLastNumber(strComID, mintVtype);
                        }

                        i = invms.mSavePhysicalStock(strComID, strRefNumber, (long)mintVtype, dteDate.Text, Utility.Val(lblAmount.Text),
                                                   Utility.gCheckNull(uctxtNarration.Text), strBranchId, Utility.gCheckNull(uctxtLocation.Text), strDG, mblnNumbMethod);

                        if (i == "Inserted...")
                        {
                            mClear();
                        }
                        else
                        {
                            MessageBox.Show("Error!!!");
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            if (m_action == 2)
            {
                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mUpdatePhysicalStock(strComID, textBox1.Text, (long)mintVtype, dteDate.Text, Utility.Val(lblAmount.Text),
                                                   Utility.gCheckNull(uctxtNarration.Text), strBranchId, Utility.gCheckNull(uctxtLocation.Text), strDG);

                        if (i == "Updated...")
                        {
                            mClear();
                        }
                        else
                        {
                            MessageBox.Show("Error!!!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

            }
            return i;
        }
        #endregion

        #region "Validation Field"
        private bool ValidateFields()
        {
            double dblClosingQTY = 0, dblCurrentQTY = 0;
            string strBillKey = "", strNegetiveItem = "";
            int intCheckNegetive = 0;

            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return false;
                }
            }

            if (uctxtInvoiceNo.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtInvoiceNo.Focus();
                return false;
            }
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtBranchName.Focus();
                return false;
            }
            if (Utility.Val(lblAmount.Text) == 0 || Utility.Val(lblAmount.Text) < 0)
            {
                MessageBox.Show("Net Amount be Empty");
                uctxtItemName.Focus();
                return false;
            }
            long lngDate = Convert.ToInt64(dteDate.Value.ToString("yyyyMMdd"));
            long lngFiscalYearfrom = Convert.ToInt64(Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString("yyyyMMdd"));
            long lngFiscalYearTo = Convert.ToInt64(Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString("yyyyMMdd"));

            if (lngDate < lngFiscalYearfrom)
            {
                MessageBox.Show("Invalid Date, Date Can't less then Financial Year");
                return false;
            }
            if (lngDate > lngFiscalYearTo)
            {
                MessageBox.Show("Invalid Date, Date Can't less then Financial Year");
                return false;
            }

            string strBacklockDate = Utility.gCheckBackLock(strComID);
            if (strBacklockDate != "")
            {
                long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strBacklockDate).ToString("yyyyMMdd"));
                if (lngDate <= lngBackdate)
                {
                    MessageBox.Show("Invalid Date, Back Date is locked");
                    return false;
                }
            }

            if (DG.Rows.Count == 0)
            {
                MessageBox.Show("Item Cannot be Empty");
                uctxtItemName.Focus();
                return false;
            }
            if (m_action==1)
            {
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_TRAN", "INV_REF_NO", uctxtInvoiceNo.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    uctxtInvoiceNo.Text = "";
                    uctxtInvoiceNo.Focus();
                    return false;
                }
            }
            if (oinv[0].mlngBlockNegativeStock > 0)
            {
                for (int i = 0; i < DG.Rows.Count; i++)
                {
                    if (DG[0, i].Value.ToString() != "")
                    {
                        if (DG[8, i].Value!=null)
                        {
                            strBillKey = DG[8, i].Value.ToString();
                        }
                        else
                        {
                            strBillKey = "";
                        }
                        if (mintVtype == (int)Utility.VOUCHER_TYPE.vtSTOCK_DAMAGE)
                        {
                            //dblClosingQTY = Utility.gdblClosingStock(strComID, DG[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                            
                            dblClosingQTY = Utility.gdblClosingStockSales(strComID, DG[0, i].Value.ToString(), lstBranchName.SelectedValue.ToString(), "",uctxtLocation.Text);
                            if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            {
                                dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                            }
                            dblCurrentQTY = Utility.Val(DG[2, i].Value.ToString());
                            if ((dblClosingQTY) - dblCurrentQTY < 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + DG[0, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                            else if (dblClosingQTY == 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + DG[0, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                        }
                        else
                        {
                            if (Utility.Left(DG[2, i].Value.ToString(), 1) == "-")
                            {
                                dblClosingQTY = Utility.gdblClosingStock(strComID, DG[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                                if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                                {
                                    dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                                }
                                dblCurrentQTY = Math.Abs(Utility.Val(DG[2, i].Value.ToString()));
                                if ((dblClosingQTY) - dblCurrentQTY < 0)
                                {
                                    strNegetiveItem = strNegetiveItem + Environment.NewLine + DG[0, i].Value.ToString();
                                    intCheckNegetive = 1;
                                    dblClosingQTY = 0;
                                }
                                else if (dblClosingQTY == 0)
                                {
                                    strNegetiveItem = strNegetiveItem + Environment.NewLine + DG[0, i].Value.ToString();
                                    intCheckNegetive = 1;
                                    dblClosingQTY = 0;
                                }
                            }
                        }
                       

                    }
                    dblClosingQTY = 0;
                }
                if (intCheckNegetive > 0)
                {
                    MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                    dblClosingQTY = 0;
                    DG.Focus();
                    return false;
                }
            }

            return true;
        }

        #endregion


        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "";
            if (ValidateFields() == false)
            {
                return;
            }
            try
            {
                string strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
                if (mintVtype == (int)Utility.VOUCHER_TYPE.vtSTOCK_DAMAGE)
                {
                    i = mDamage();
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, strFormName, uctxtInvoiceNo.Text,
                                                                m_action, 0, (int)Utility.MODULE_TYPE.mtSTOCK, strBranchID);
                    }
                }
                else
                {
                    i = mPhysicalStock();
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, strFormName, uctxtInvoiceNo.Text,
                                                                m_action, 0, (int)Utility.MODULE_TYPE.mtSTOCK, strBranchID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(i);
            }


        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
              
                  DG.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmStockProductionList objfrm = new frmStockProductionList();
            objfrm.intvType = mintVtype;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.onAddAllButtonClicked = new frmStockProductionList.AddAllClick(DisplayVoucherList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            uctxtInvoiceNo.Focus();
        }




        private void DisplayVoucherList(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {
                int intrm = 0;
                double dblclsQnty = 0;
                uctxtInvoiceNo.Focus();
               
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DG.Rows.Clear();
                if (mintVtype == (int)Utility.VOUCHER_TYPE.vtSTOCK_PHYSICAL)
                {
                    List<StockItem> oRm = invms.mFillDisplayPhyMaster(strComID, tests[0].strRefNo).ToList();
                    {
                        if (oRm.Count > 0)
                        {
                            textBox1.Text = oRm[0].strRefNo;
                            uctxtInvoiceNo.Text = Utility.Mid(oRm[0].strRefNo, 6, oRm[0].strRefNo.Length - 6);
                            uctxtBranchName.Text = oRm[0].strBranchName;
                            dteDate.Text = oRm[0].strDate;
                            uctxtNarration.Text  = oRm[0].strNarration;


                            List<StockItem> oRm1 = invms.mFillDisplayPhysicalStock(strComID, tests[0].strRefNo).ToList();
                            {

                                uctxtLocation.Text = oRm1[0].strLocation;
                                foreach (StockItem ooRm in oRm1)
                                {
                                    DG.Rows.Add();
                                    dblclsQnty = Utility.gdblClosingStock(strComID, ooRm.strItemName, oRm[0].strLocation, "");
                                    DG[0, intrm].Value = ooRm.strItemName;
                                    //DG[1, intrm].Value = Math.Abs(dblclsQnty);
                                    //DG[1, intrm].Value = invms.gFillStockItemPhysical(strComID, uctxtLocation.Text, ooRm.strItemName);
                                    DG[1, intrm].Value = ooRm.dblReorderQty;
                                    if (mintVtype == (int)Utility.VOUCHER_TYPE.vtSTOCK_DAMAGE)
                                    {
                                        DG[2, intrm].Value =Math.Abs(ooRm.dblOpnQty);
                                    }
                                    else
                                    {
                                        DG[2, intrm].Value = (ooRm.dblOpnQty);
                                    }
                                    DG[3, intrm].Value = Utility.gGetBaseUOM(strComID, ooRm.strItemName);
                                    DG[4, intrm].Value = Math.Abs(ooRm.dblOpnRate);
                                    DG[5, intrm].Value = Math.Abs(ooRm.dblOpnValue);
                                    DG[6, intrm].Value = ooRm.strBatch;
                                    DG[7, intrm].Value = "Delete";
                                    DG[8, intrm].Value = ooRm.strBillKey;
                                    
                                    intrm += 1;
                                    DG.AllowUserToAddRows = false;
                                }
                            }
                        }
                    }

                }
                else
                {
                    List<StockItem> oRm = invms.mFillDisplayPhyMaster(strComID, tests[0].strRefNo).ToList();
                     {
                          if (oRm.Count > 0)
                          {
                              textBox1.Text = oRm[0].strRefNo;
                              uctxtInvoiceNo.Text = Utility.Mid(oRm[0].strRefNo, 6, oRm[0].strRefNo.Length - 6);
                              uctxtBranchName.Text = oRm[0].strBranchName;
                              dteDate.Text = oRm[0].strDate;
                              uctxtNarration.Text = oRm[0].strNarration;
                              List<StockItem> oRm1 = invms.mFillDisplayStockDamage(strComID, tests[0].strRefNo, mintVtype).ToList();
                              {
                                  if (oRm.Count > 0)
                                  {
                                      uctxtLocation.Text = oRm1[0].strLocation;
                                      foreach (StockItem ooRm in oRm1)
                                      {
                                          DG.Rows.Add();
                                          //dblclsQnty = Utility.gdblClosingStock(ooRm.strItemName, oRm[0].strLocation, "");
                                          DG[0, intrm].Value = ooRm.strItemName;
                                          DG[1, intrm].Value = 0;
                                          DG[2, intrm].Value = Math.Abs(ooRm.dblOpnQty);
                                          DG[3, intrm].Value = Utility.gGetBaseUOM(strComID, ooRm.strItemName);
                                          DG[4, intrm].Value = Math.Abs(ooRm.dblOpnRate);
                                          DG[5, intrm].Value = Math.Abs(ooRm.dblOpnValue);
                                          DG[6, intrm].Value = ooRm.strBatch;
                                          DG[7, intrm].Value = "Delete";
                                          DG[8, intrm].Value = ooRm.strBillKey;
                                          intrm += 1;
                                          DG.AllowUserToAddRows = false;
                                      }
                                  }
                              }
                          }
                     }
                }
                calculateTotal();

            }
              


          
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void uctxtItemName_KeyUp(object sender, KeyEventArgs e)
        {

          
            try
            {
                if (uctxtLocation.Text != "")
                {
                    SearchListView(oogrp, uctxtItemName.Text);
                }
                else
                {
                    uclstGrdItem.Rows.Clear();
                    oogrp.Clear();
                }
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
                //query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                query = (from test in tests
                         where test.strItemName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                         select test);
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

                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calculateTotal();
        }

      
    }

}
