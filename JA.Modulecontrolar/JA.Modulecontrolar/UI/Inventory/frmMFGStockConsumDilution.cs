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
namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmMFGStockConsumDilution : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWIS = new SPWOIS();
        List<StockItem> oogrp;
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int m_action { get; set; }
        private bool mblnNumbMethod { get; set; }
        public int intType { get; set; }
        private int mintIsPrin { get; set; }
        List<InvoiceConfig> oinv;
        public int intvType { get; set; }
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstProcess = new ListBox();
        private ListBox lstBatch = new ListBox();
        private ListBox lstCosting = new ListBox();
        private ListBox lstSection = new ListBox();
        public int intconvert { get; set; }
        private string strComID { get; set; }
        public frmMFGStockConsumDilution()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User IN"
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.uctxtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtInvoiceNo_KeyPress);
            this.uctxtInvoiceNo.GotFocus += new System.EventHandler(this.uctxtInvoiceNo_GotFocus);

            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.dteDate_GotFocus);

            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);
            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);

            this.uctxtRate.TextChanged += new System.EventHandler(this.uctxtRate_TextChanged);
            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtRate.GotFocus += new System.EventHandler(this.uctxtRate_GotFocus);

            this.uctxtRepackingItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRepackingItem_KeyPress);
            this.uctxtRepackingItem.GotFocus += new System.EventHandler(this.uctxtRepackingItem_GotFocus);

            this.uctxtRepackingQTY.TextChanged += new System.EventHandler(this.uctxtRepackingQTY_TextChanged);
            this.uctxtRepackingQTY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRepackingQTY_KeyPress);
            this.uctxtRepackingQTY.GotFocus += new System.EventHandler(this.uctxtRepackingQTY_GotFocus);


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

            this.uctxtLocation.KeyDown += new KeyEventHandler(uctxtLocation_KeyDown);
            this.uctxtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLocation_KeyPress);
            this.uctxtLocation.TextChanged += new System.EventHandler(this.uctxtLocation_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.uctxtLocation.GotFocus += new System.EventHandler(this.uctxtLocation_GotFocus);

            this.uctxtProcessName.KeyDown += new KeyEventHandler(uctxtProcessName_KeyDown);
            this.uctxtProcessName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtProcessName_KeyPress);
            this.uctxtProcessName.TextChanged += new System.EventHandler(this.uctxtProcessName_TextChanged);
            this.lstProcess.DoubleClick += new System.EventHandler(this.lstProcess_DoubleClick);
            this.uctxtProcessName.GotFocus += new System.EventHandler(this.uctxtProcessName_GotFocus);

            this.uctxtCosting.GotFocus += new System.EventHandler(this.uctxtCosting_GotFocus);
            this.lstCosting.DoubleClick += new System.EventHandler(this.lstCosting_DoubleClick);
            this.uctxtCosting.KeyDown += new KeyEventHandler(uctxtCosting_KeyDown);
            this.uctxtCosting.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCosting_KeyPress);
            this.uctxtCosting.TextChanged += new System.EventHandler(this.uctxtCosting_TextChanged);


            this.uctxtSection.GotFocus += new System.EventHandler(this.uctxtSection_GotFocus);
            this.lstSection.DoubleClick += new System.EventHandler(this.lstSection_DoubleClick);
            this.uctxtSection.KeyDown += new KeyEventHandler(uctxtSection_KeyDown);
            this.uctxtSection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSection_KeyPress);
            this.uctxtSection.TextChanged += new System.EventHandler(this.uctxtSection_TextChanged);

            this.DG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DG_KeyDown);
            this.uclstGrdItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstGrdItem_CellFormatting);
            this.chkFG.Click += new System.EventHandler(this.chkFG_Click);
            this.uctxtRepackingItem.KeyDown += new KeyEventHandler(uctxtRepackingItem_KeyDown);
            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            Utility.CreateListBox(lstProcess, pnlMain, uctxtProcessName);
            Utility.CreateListBox(lstBatch, pnlMain, uctxtBatch);
            Utility.CreateListBox(lstCosting, pnlMain, uctxtCosting);
            Utility.CreateListBox(lstSection , pnlMain, uctxtSection);
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
        private void uctxtRepackingItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
            {
                frmAllReferanceGroup objfrm = new frmAllReferanceGroup();
                objfrm.lngVtype = 9999;
                objfrm.onAddAllButtonClickedFG = new frmAllReferanceGroup.AddAllClickFG(DisplayVoucherListFG);
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
                uctxtRepackingItem.Focus();
            }
        }
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
        private void uctxtRepackingQTY_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstCosting.Visible = false;
            lstSection.Visible = false;
            uclstGrdItem.Visible = false;

        }

        private void uctxtRepackingQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
               
                //uctxtItemName.Focus();
                uctxtBatch.Focus();

            }
        }
        private void uctxtRepackingQTY_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtRepackingQTY.Text) == false)
            {
                uctxtRepackingQTY.Text = "";
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
                        uctxtNarration.Focus();
                    else
                        DG.CurrentCell = DG[iColumn + 1, iRow];
                }
                catch (Exception ex)
                {
                    uctxtNarration.Focus();
                }

            }
        }
        private void uctxtSection_TextChanged(object sender, EventArgs e)
        {
            lstSection.SelectedIndex = lstSection.FindString(uctxtSection.Text);
        }

        private void lstSection_DoubleClick(object sender, EventArgs e)
        {
            uctxtSection.Text = lstSection.Text;
            uctxtItemName.Focus();
        }
        private void uctxtSection_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstCosting.Visible = false;
            lstSection.Visible = true;
            uclstGrdItem.Visible = false;
            lstSection.SelectedIndex = lstSection.FindString(uctxtSection.Text);

        }

        private void uctxtSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstSection.Items.Count > 0)
                {
                    uctxtSection.Text = lstSection.Text;
                }
                uctxtItemName.Focus();

            }
        }

        private void uctxtSection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstSection.SelectedItem != null)
                {
                    lstSection.SelectedIndex = lstSection.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstSection.Items.Count - 1 > lstSection.SelectedIndex)
                {
                    lstSection.SelectedIndex = lstSection.SelectedIndex + 1;
                }
            }

        }


        private void uctxtCosting_TextChanged(object sender, EventArgs e)
        {
            lstCosting.SelectedIndex = lstCosting.FindString(uctxtCosting.Text);
        }
        private void uctxtRepackingItem_GotFocus(object sender, System.EventArgs e)
        {
            
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstCosting.Visible = false;
            lstSection.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtRepackingItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (e.KeyChar == (char)Keys.Return)
                {
                    
                    uctxtRepackingQTY.Focus();
                }
            }


            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtRepackingItem, sender, e);
            }
        }
        private void uctxtCosting_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstCosting.Visible = true;
            lstSection.Visible = false;
            uclstGrdItem.Visible = false;
            lstCosting.SelectedIndex = lstCosting.FindString(uctxtCosting.Text);
        }
        private void uctxtCosting_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (e.KeyChar == (char)Keys.Return)
                {
                    if (lstCosting.Items.Count > 0)
                    {
                        uctxtCosting.Text = lstCosting.Text;
                    }
                    if (uctxtRepackingItem.Visible)
                    {
                        uctxtRepackingItem.Focus();
                    }
                    else
                    {
                        uctxtItemName.Focus();
                    }
                }
            }

            
            if (e.KeyChar==(char)Keys.Back)
            {
                PriorSetFocusText(uctxtCosting, sender, e);
            }
        }
        private void lstCosting_DoubleClick(object sender, EventArgs e)
        {
            uctxtCosting.Text = lstCosting.Text;
            if (uctxtRepackingItem.Visible)
            {
                uctxtRepackingItem.Focus();
            }
            else
            {
                uctxtItemName.Focus();
            }
        }

        private void uctxtCosting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCosting.SelectedItem != null)
                {
                    lstCosting.SelectedIndex = lstCosting.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCosting.Items.Count - 1 > lstCosting.SelectedIndex)
                {
                    lstCosting.SelectedIndex = lstCosting.SelectedIndex + 1;
                }
            }

        }


        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (Utility.Val(uctxtRate.Text) > 0)
                {
                    mAddStockItem(DG, uctxtItemName.Text, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text));
                }
                else
                {
                    MessageBox.Show("Sorry! Rate Cannot be Found");
                    uctxtItemName.Text = "";
                    uctxtItemName.Focus();
                    return;
                }

                uctxtItemName.Text = "";
                uctxtItemName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtRate, uctxtQty);
            }
        }
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstCosting.Visible = false;
            lstSection.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtRate.Text = Utility.gdblGetCostPrice(strComID, uctxtItemName.Text, dteDate.Text).ToString();
                
                uctxtRate.Text = Utility.gdblGetCostPriceNew(strComID, uctxtItemName.Text, dteDate.Text).ToString();
                if (Utility.Val(uctxtRate.Text) != 0)
                {
                    mAddStockItem(DG, uctxtItemName.Text, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text));
                    uctxtItemName.Focus();
                }
                else
                {
                    MessageBox.Show("Rate not Found");
                    uctxtQty.Focus();
                    return;
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtQty, uctxtItemName);
            }
        }

        private void mAddStockItem(DataGridView dg, string strItemName, double dblQty, double dblRate)
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
                selRaw = Convert.ToInt16(dg.RowCount.ToString());
                selRaw = selRaw - 1;
                dg.Rows.Add();
                dg[0, selRaw].Value = strItemName.ToString();
                dg[1, selRaw].Value = dblQty;
                dg[2, selRaw].Value = Utility.gGetBaseUOM(strComID, strItemName.ToString());
                dg[3, selRaw].Value = dblRate;
                dg[4, selRaw].Value = Math.Round(dblQty * dblRate, 2);
                dg[5, selRaw].Value = "Delete";
                dg.AllowUserToAddRows = false;
                uctxtRate.Text = "";
                uctxtQty.Text = "";
                uctxtItemName.Text = "";
                calculateTotal();
                dg.ClearSelection();
                int nColumnIndex = 2;
                int nRowIndex = dg.Rows.Count - 1;
                dg.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                dg.FirstDisplayedScrollingRowIndex = nRowIndex;
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

            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtItemName, uctxtCosting);
            }
        }
        private void mLoadAllItem()
        {
            int introw = 0;
            string strYn = "N";
            uclstGrdItem.Rows.Clear();
            if (chkFG.Checked ==true)
            {
                strYn = "FG";
            }
            else
            {
                strYn = "MC";
            }
           
            if (intvType == (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_CONSUMPTION)
            {
                //oogrp = objWIS.gFillStockItem (strComID, uctxtLocation.Text).ToList();
                //oogrp = invms.mloadAddStockItemRMPack(strComID, uctxtLocation.Text, "", strYn).ToList();
                oogrp = objWIS.mGetProductStatementView(strComID, "", lstBranchName.SelectedValue.ToString(), uctxtLocation.Text, strYn).ToList();
            }
            else
            {
                //oogrp = objWIS.mloadAddStockItemFgNew(strComID, uctxtLocation.Text).ToList();
                oogrp = objWIS.mGetProductStatementView(strComID, "", lstBranchName.SelectedValue.ToString(), uctxtLocation.Text,"").ToList();
            }
            if (oogrp.Count > 0)
            {
               
               
                foreach (StockItem ogrp in oogrp)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, introw].Value = ogrp.strItemName;
                    uclstGrdItem[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit; 

                    introw += 1;
                }
                uclstGrdItem.AllowUserToAddRows = false;
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
            uclstGrdItem.Height = 180;
            uclstGrdItem.BringToFront();
            uclstGrdItem.AllowUserToAddRows = false;
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
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstCosting.Visible = false;
            lstSection.Visible = false;
            mLoadAllItem();
        }
        private void uctxtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnSave.Focus();
           }

            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtNarration,uctxtItemName);
            }
        }
        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstCosting.Visible = false;
            lstSection.Visible = false;
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
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstCosting.Visible = false;
            lstSection.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (Utility.gstrUserName.ToUpper() == "DEEPLAID")
                {
                    dteDate.Enabled = true;
                    dteDate.Focus();
                }
                else
                {
                    uctxtBranchName.Select();
                    uctxtBranchName.Focus();


                }
            }
        }
        private void uctxtInvoiceNo_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstCosting.Visible = false;
            lstSection.Visible = false;
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
                if (lstBatch.Items.Count > 0)
                {
                    uctxtBatch.Text = lstBatch.Text;
                }
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
                    lstBatch.SelectedIndex = lstBatch.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBatch_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = true;
            lstCosting.Visible = false;
            lstSection.Visible = false;
            uclstGrdItem.Visible = false;

            lstBatch.DisplayMember = "Key";
            lstBatch.ValueMember = "Key";
            lstBatch.DataSource = new BindingSource(invms.mFillOpeningBatchNew(strComID, Utility.gstrUserName), null);

            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }



        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            uctxtBatch.Focus();
        }

        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                }

                uctxtBatch.Focus();
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
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstCosting.Visible = false;
            lstSection.Visible = false;
            uclstGrdItem.Visible = false;
            if (lstBranchName.SelectedValue != null)
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName,0).ToList();
            }
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
            //mLoadAllItem();
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
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstCosting.Visible = false;
            lstSection.Visible = false;
            uclstGrdItem.Visible = false;
            
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }
        private void uctxtProcessName_TextChanged(object sender, EventArgs e)
        {
            lstProcess.SelectedIndex = lstProcess.FindString(uctxtProcessName.Text);
        }

        private void lstProcess_DoubleClick(object sender, EventArgs e)
        {
            uctxtProcessName.Text = lstProcess.Text;
            if (m_action == 1)
            {
                if (frmLabel.Text == "Finished Goods")
                {
                    DisplayProcessFG(uctxtProcessName.Text);
                }
                else
                {
                    DisplayProcessRm(uctxtProcessName.Text);
                }
            }

            uctxtCosting.Focus();
        }

        private void uctxtProcessName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstProcess.Items.Count > 0)
                {
                    if (uctxtProcessName.Text != "")
                    {
                        uctxtProcessName.Text = lstProcess.Text;
                    }
                }


                if (m_action == 1)
                {
                    if (frmLabel.Text == "Finished Goods")
                    {
                        DisplayProcessFG(uctxtProcessName.Text);
                    }
                    else
                    {
                        DisplayProcessRm(uctxtProcessName.Text);
                    }
                }
                uctxtCosting.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtProcessName, sender, e);
            }
        }
        private void DisplayProcessRm(string vstrProcess)
        {
            double dblrate = 0;
            try
            {
                int intfg = 0;
                uctxtProcessName.Focus();
                DG.Rows.Clear();
                List<ManuProcess> omanuProcess = invms.mDisplayProcess(strComID, vstrProcess,"").ToList();
                if (omanuProcess.Count > 0)
                {
                    foreach (ManuProcess ts in omanuProcess)
                    {
                        if (ts.intType == 1)
                        {
                            DG.Rows.Add();
                            DG[0, intfg].Value = ts.stritemName;
                            DG[1, intfg].Value = ts.dblqnty;
                            DG[2, intfg].Value = ts.strUnit;
                            dblrate = Utility.gdblGetCostPrice(strComID,ts.stritemName, dteDate.Text);
                            DG[3, intfg].Value = dblrate;
                            DG[4, intfg].Value = Math.Round(ts.dblqnty * dblrate, 2);
                            DG[5, intfg].Value = "Delete";
                            intfg += 1;
                            DG.AllowUserToAddRows = false;
                        }
                        else
                        {
                            DG.Rows.Add();
                            DG[0, intfg].Value = ts.stritemName;
                            DG[1, intfg].Value = ts.dblqnty;
                            DG[2, intfg].Value = ts.strUnit;
                            dblrate = Utility.gdblGetCostPrice(strComID, ts.stritemName, dteDate.Text);
                            DG[3, intfg].Value = dblrate;
                            DG[4, intfg].Value = Math.Round(ts.dblqnty * dblrate, 2);
                            DG[5, intfg].Value = "Delete";
                            intfg += 1;
                            DG.AllowUserToAddRows = false;
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
        private void DisplayProcessFG(string vstrProcess)
        {
            double dblrate = 0;
            try
            {
                int intfg = 0;
                uctxtProcessName.Focus();
                DG.Rows.Clear();
                List<ManuProcess> omanuProcess = invms.mDisplayProcess(strComID,vstrProcess,"").ToList();
                if (omanuProcess.Count > 0)
                {
                    foreach (ManuProcess ts in omanuProcess)
                    {
                        if (ts.intType == 2)
                        {
                            DG.Rows.Add();
                            DG[0, intfg].Value = ts.stritemName;
                            DG[1, intfg].Value = ts.dblqnty;
                            DG[2, intfg].Value = ts.strUnit;
                            dblrate = Utility.gdblGetCostPrice(strComID,ts.stritemName, dteDate.Text);
                            DG[3, intfg].Value = dblrate;
                            DG[4, intfg].Value = Math.Round(ts.dblqnty * dblrate,2) ;
                            DG[5, intfg].Value = "Delete";
                            intfg += 1;
                            DG.AllowUserToAddRows = false;
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
        private void uctxtProcessName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstProcess.SelectedItem != null)
                {
                    lstProcess.SelectedIndex = lstProcess.SelectedIndex - 1;
                    uctxtProcessName.Text = lstProcess.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstProcess.Items.Count - 1 > lstProcess.SelectedIndex)
                {
                    lstProcess.SelectedIndex = lstProcess.SelectedIndex + 1;
                    uctxtProcessName.Text = lstProcess.Text;
                }
            }

        }

        private void uctxtProcessName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = true;
            lstBatch.Visible = false;
            lstCosting.Visible = false;
            uclstGrdItem.Visible = false;
            lstProcess.SelectedIndex = lstProcess.FindString(uctxtProcessName.Text);
        }
        #endregion
        #region "Getconfig"
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, intvType).ToList();
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
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblAmount = 0,dblQty=0;
            for (int i = 0; i < DG.Rows.Count; i++)
            {
                DG.Rows[i].Cells[4].Value = Convert.ToDouble(DG.Rows[i].Cells[1].Value) * Convert.ToDouble(DG.Rows[i].Cells[3].Value);
                dblAmount = dblAmount + Convert.ToDouble(DG.Rows[i].Cells[4].Value);
                dblQty = dblQty + Convert.ToDouble(DG.Rows[i].Cells[1].Value);
               
            }

            lblnetAmount.Text = dblAmount.ToString();
            lblQty.Text = dblQty.ToString();
        }
        #endregion
        #region "Save"
        private string  mSaveConsumtion()
        {
            string strRefNumber = "", strBranchID = "", strDG = "", strmsg="";
            int intRow = 1;

            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

            for (intRow = 0; intRow < DG.Rows.Count; intRow++)
            {

                if (DG[0, intRow].Value != null)
                {
                    strDG += DG[0, intRow].Value.ToString() + "|" + DG[1, intRow].Value.ToString() +
                                            "|" + DG[2, intRow].Value.ToString() + "|" +
                                            DG[3, intRow].Value.ToString() + "|" + DG[4, intRow].Value.ToString() + "|" + uctxtSection.Text + "~";
                }
            }

           

                if (mblnNumbMethod==false)
                {
                    strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intvType) + strBranchID + uctxtInvoiceNo.Text;
                }
                else
                {
                    strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intvType) + strBranchID + Utility.gstrLastNumber(strComID, intvType);
                }
                strmsg = invms.mSaveStockOutWard(strComID, strRefNumber, intvType, dteDate.Text, Utility.Val(lblnetAmount.Text), uctxtNarration.Text, strBranchID,
                                                    uctxtLocation.Text, uctxtBatch.Text, uctxtCosting.Text, uctxtProcessName.Text, strDG, mblnNumbMethod, "", 0, 0, "", "", intType,0,"");

                if (uctxtRepackingItem.Text != "")
                {
                    string j = Utility.gInsertRepacking(strComID, strRefNumber, uctxtRepackingItem.Text, Utility.Val(uctxtRepackingQTY.Text.ToString()), dteDate.Text,uctxtLocation.Text);
                }

            return strmsg;
        }
        #endregion
        #region "Update"
        private string mUpdateConsumtion()
        {
            string strBranchID = "", strDG = "", strmsg = "";
            int intRow = 1;

            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

            for (intRow = 0; intRow < DG.Rows.Count; intRow++)
            {

                if (DG[0, intRow].Value != null)
                {
                    strDG += DG[0, intRow].Value.ToString() + "|" + DG[1, intRow].Value.ToString() +
                                            "|" + DG[2, intRow].Value.ToString() + "|" +
                                            DG[3, intRow].Value.ToString() + "|" + DG[4, intRow].Value.ToString() + "|" + uctxtSection.Text + "~";
                }
            }


            strmsg = invms.mUpdateStockOutWard(strComID, txtRefNo.Text, intvType, dteDate.Text, Utility.Val(lblnetAmount.Text), uctxtNarration.Text, strBranchID,
                                                    uctxtLocation.Text, uctxtBatch.Text, uctxtCosting.Text, uctxtProcessName.Text, strDG, "", 0, 0, "", "", intType,0,"");

            if (uctxtRepackingItem.Text != "")
            {
                string j = Utility.gInsertRepacking(strComID, txtRefNo.Text, uctxtRepackingItem.Text, Utility.Val(uctxtRepackingQTY.Text.ToString()), dteDate.Text, uctxtLocation.Text);
            }



            return strmsg;
        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            uctxtSection.Text="";
            uctxtProcessName.Text="";
            uctxtBatch.Text="";
            uctxtBranchName.Text="";
            uctxtLocation.Text = "";
            DG.Rows.Clear();
            uctxtNarration.Text = "";
            lblnetAmount.Text = "0";
            uctxtRate.Text = "";
            uctxtQty.Text = "";
            lblQty.Text = "0";
            lblnetAmount.Text = "0";
            uctxtRepackingQTY.Text = "";
            uctxtRepackingItem.Text = "";
            
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod)
            {
                uctxtInvoiceNo.Text = Utility.gstrLastNumber(strComID, intvType);
                uctxtInvoiceNo.ReadOnly = true;
               
            }
            else
            {

                uctxtInvoiceNo.Text = Utility.gobjNextNumber(uctxtInvoiceNo.Text);
                uctxtInvoiceNo.ReadOnly = false;
                uctxtInvoiceNo.Select();
            }
            if (Utility.gstrUserName.ToUpper() == "DEEPLAID")
            {
                dteDate.Enabled = true;
                dteDate.Focus();
            }
            else
            {

                uctxtInvoiceNo.Select();
            }
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
                if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return false;
                }
            }

            if (uctxtInvoiceNo.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtInvoiceNo.Focus();
                return false;
            }
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtBranchName.Focus();
                return false;
            }
            if (uctxtLocation.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtLocation.Focus();
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
            string strLockvoucher = Utility.gLockVocher(strComID, intvType);
            if (strLockvoucher != "")
            {
                long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strLockvoucher).ToString("yyyyMMdd"));
                if (lngDate <= lngBackdate)
                {
                    MessageBox.Show("Invalid Date, Back Date is locked");
                    return false;
                }
            }
            if (DG.Rows.Count==0)
            {
                MessageBox.Show("Item Cannot be Empty");
                uctxtItemName.Focus();
                return false;
            }
            if (Utility.Val(lblnetAmount.Text) == 0 || Utility.Val(lblnetAmount.Text) <0)
            {
                MessageBox.Show("Net Amount be Empty");
                uctxtItemName.Focus();
                return false;
            }

            if (m_action == 1)
            {
                string strDuplicate = Utility.mCheckDuplicateItem(strComID,"INV_TRAN", "INV_REF_NO", uctxtInvoiceNo.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    uctxtInvoiceNo.Text = "";
                    uctxtInvoiceNo.Focus();
                    return false;
                }
            }
            string strBranchID = lstBranchName.SelectedValue.ToString();
            if (intvType != (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_FINISHED_GOODS)
            {
                if (oinv[0].mlngBlockNegativeStock > 0)
                {
                    for (int i = 0; i < DG.Rows.Count; i++)
                    {
                        if (DG[0, i].Value.ToString() != "")
                        {
                            if (DG[6, i].Value != null)
                                strBillKey = DG[6, i].Value.ToString();
                            //dblClosingQTY = Utility.gdblClosingStockNew(strComID, DG[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);

                            dblClosingQTY = Utility.gdblClosingStock(strComID, DG[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                            
                            if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            {
                                dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey, uctxtLocation.Text);
                            }
                            dblCurrentQTY = Utility.Val(DG[1, i].Value.ToString());
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
                            //if (intCheckNegetive > 0)
                            //{
                            //    MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                            //    dblClosingQTY = 0;
                            //    DG.Focus();
                            //    return false;
                            //}

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
            }
            if (uctxtLocation.Text == "Dilution Section")
            {
                string strmsg = Utility.gCheckPreviousEntryDilution(strComID, dteDate.Text);
                if (strmsg != "")
                {
                    MessageBox.Show(strmsg);
                    return false;

                }

            }
            return true;
        }

        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "";
            if (ValidateFields() == false)
            {
                return;
            }
            string strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                       
                        i = mSaveConsumtion();

                        if (i == "Inserted...")
                        {
                            
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, strFormName, uctxtInvoiceNo.Text,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSTOCK, strBranchID);
                            }
                            mClear();
                            return;
                        }
                        else
                        {
                            MessageBox.Show(i.ToString());
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
                var strResponseInsert = MessageBox.Show("Do You  want to Update?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = mUpdateConsumtion();

                        if (i == "Updated...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, strFormName, uctxtInvoiceNo.Text,
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtSTOCK, strBranchID);
                            }
                            mClear();
                            frmMFGStockProductionList objfrm = new frmMFGStockProductionList();
                            objfrm.intvType = intvType;
                            objfrm.onAddAllButtonClicked = new frmMFGStockProductionList.AddAllClick(DisplayVoucherList);
                            objfrm.lngFormPriv = lngFormPriv;
                            objfrm.strFormName = strFormName;
                            objfrm.Show();
                            objfrm.MdiParent = this.MdiParent;
                            return;
                        }
                        else
                        {
                            MessageBox.Show(i.ToString());
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
            }


        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmMFGStockProductionList objfrm = new frmMFGStockProductionList();
            objfrm.intvType = intvType;
            objfrm.onAddAllButtonClicked = new frmMFGStockProductionList.AddAllClick(DisplayVoucherList);
            objfrm.lngFormPriv=lngFormPriv;
            if (strFormName == "R && D Consumption")
            {
                objfrm.strFormName = "R && D Consumption";
            }
            else
            {
                objfrm.strFormName = "Dilution Consumption List";
            }
            
            objfrm.intType = intType;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
            uctxtInvoiceNo.Focus();
        }
        #endregion
        #region "Load"
        private void frmMFGStockConsumDilution_Load(object sender, EventArgs e)
        {
            string strYesNo = "Y";
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstCosting.Visible = false;
            lstSection.Visible = false;
            lstBatch.Visible = false;
            DG.AllowUserToAddRows = false;
            
            mGetConfig();
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            mClear();

            if (intvType == (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_CONSUMPTION)
            {
                if (strFormName == "R && D Consumption")
                {
                    frmLabel.Text = "R && D Consumption";
                    btnDilutionStore.Visible = false;
                    btnProcess.Visible = false;
                }
                else
                {
                    frmLabel.Text = "Dilution Consumption";
                }
            }
            else
            {
                frmLabel.Text = "Finished Goods";
            }
           

            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, 202, m_action))
                {
                    strYesNo = "N";
                }
            }
           

            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            if (strYesNo == "Y")
            {
                DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 380, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Qty", "Qty", 100, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 60, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
            }
            else
            {
                DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 520, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Qty", "Qty", 150, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 70, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, false, DataGridViewContentAlignment.TopLeft, true));
                lblnetAmount.Visible = false;
                label15.Visible = false;
            }
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Bill Key", "Bill Key", 100, false, DataGridViewContentAlignment.TopLeft, false));
            lstProcess.ValueMember = "strProcessName";
            lstProcess.DisplayMember = "strProcessName";
            lstProcess.DataSource = invms.mLoadProcess(strComID, "", "", intconvert, 0, Utility.gstrUserName).ToList();

         

            LoadDefaultValue();
           
        }
        #endregion
        #region "Default Value"
        private void LoadDefaultValue()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"By Quantity", 1},
              {"By Value", 2},
              {"Item wise", 2}
            };

            lstCosting.DisplayMember = "Key";
            lstCosting.ValueMember = "Value";
            lstCosting.DataSource = new BindingSource(userCache, null);



        }
        #endregion
        #region "DisplayVoucher List"
        private void DisplayVoucherList(List<MFGvouhcer> tests, object sender, EventArgs e)
        {
            try
            {
                mClear();
                m_action = 2;
                int i=0;
                txtRefNo.Text = tests[0].strVoucherNo.ToString();
                uctxtInvoiceNo.Text = Utility.Mid(tests[0].strVoucherNo.ToString(),6,tests[0].strVoucherNo.Length-6);
                List<MFGvouhcer> oogrp = invms.mDisplayInOutMaster(strComID, tests[0].strVoucherNo.ToString(), intvType, "", "", "", "", "", intType,"").ToList();
                if (oogrp.Count > 0)
                {
                    foreach (MFGvouhcer ogrp in oogrp)
                    {
                        dteDate.Text = ogrp.strDate;
                        uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, ogrp.strBranchId);
                        if (ogrp.strBatch != "")
                        {
                            uctxtBatch.Text = ogrp.strBatch;
                        }
                        else
                        {
                            uctxtBatch.Text = Utility.gcEND_OF_LIST;
                        }

                        uctxtProcessName.Text = ogrp.strProcess;
                        uctxtCosting.Text = ogrp.strCosting;
                        uctxtSection.Text = ogrp.strSection;
                        uctxtNarration.Text = ogrp.strNarration;
                        List<MFGvouhcer> ooInvrp = invms.mDisplayRepacking(strComID, tests[0].strVoucherNo.ToString()).ToList();
                        if (ooInvrp.Count > 0)
                        {
                            uctxtRepackingItem.Text = ooInvrp[0].strItemName;
                            uctxtRepackingQTY.Text = ooInvrp[0].dblQnty.ToString();
                        }
                        List<MFGvouhcer> ooInv = invms.mDisplayInoutTran(strComID, tests[0].strVoucherNo.ToString()).ToList();
                        if (ooInv.Count >0)
                        {
                            foreach (MFGvouhcer oinv in ooInv)
                            {
                                DG.Rows.Add();
                                uctxtLocation.Text = oinv.strLocation;
                                DG[0, i].Value = oinv.strItemName;
                                DG[1, i].Value = oinv.dblQnty.ToString();
                                DG[2, i].Value = oinv.strUOM;
                                DG[3, i].Value = oinv.dblrate;
                                DG[4, i].Value = oinv.dblAmount;
                                DG[5, i].Value = "Delete";
                                DG[6, i].Value = oinv.strBillKey;
                                i += 1;
                            }
                            DG.AllowUserToAddRows = false;
                        }
                        calculateTotal();
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        #region "Lonq"
        private void uctxtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (uctxtItemName.Text != "")
                {
                    SearchListView(oogrp, uctxtItemName.Text);
                }
               //else
               //{
               //    uclstGrdItem.Rows.Clear();
               //    oogrp.Clear();
               //}
            }
            catch (Exception ex)
            {

            }
        }

        private void SearchListView(IEnumerable<StockItem> tests, string searchString = "")
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
        #endregion

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==5)
            {
                DG.Rows.RemoveAt(e.RowIndex);
                calculateTotal();
            }
        }

       

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            calculateTotal();
        }

       

        private void chkFG_Click(object sender, EventArgs e)
        {
            uclstGrdItem.Rows.Clear();
            mLoadAllItem();
            uctxtItemName.Focus();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSerach_Click(object sender, EventArgs e)
        {
            frmAllReferanceGroup objfrm = new frmAllReferanceGroup();
            objfrm.lngVtype  = 9999;
            objfrm.onAddAllButtonClickedFG = new frmAllReferanceGroup.AddAllClickFG(DisplayVoucherListFG);
            objfrm.MdiParent = this.MdiParent;
            objfrm.Show();
            uctxtRepackingItem.Focus();
        }

        private void DisplayVoucherListFG(List<StockItem> tests, object sender, EventArgs e)
        {
            uctxtRepackingItem.Text = tests[0].strItemName;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            
            
            if (System.Windows.Forms.Application.OpenForms["frmMFGStockConsumDilProces"] as frmMFGStockConsumDilProces == null)
            {
                frmMFGStockConsumDilProces objfrm = new frmMFGStockConsumDilProces();
                objfrm.vstrDate = dteDate.Text;
                objfrm.MdiParent = this.MdiParent;
                objfrm.Show();

            }
            else
            {
                frmMFGStockConsumDilProces objfrm = (frmMFGStockConsumDilProces)Application.OpenForms["frmMFGStockConsumDilProces"];
                objfrm.MdiParent = this.MdiParent;
                objfrm.Focus();
            }
        }

        private void chkFG_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDilutionStore_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmMFGdilutionStore"] as frmMFGdilutionStore == null)
            {
                frmMFGdilutionStore objfrm = new frmMFGdilutionStore();
                objfrm.intvType = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_VOUCHER;
                objfrm.lngFormPriv = lngFormPriv;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmMFGdilutionStore objfrm = (frmMFGdilutionStore)Application.OpenForms["frmMFGdilutionStore"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

       




    }
}
