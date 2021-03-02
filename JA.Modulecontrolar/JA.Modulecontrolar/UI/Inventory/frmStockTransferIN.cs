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
//using JA.Modulecontrolar.JRPT;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmStockTransferIN : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstFromLocation = new ListBox();
        private ListBox lstToLocation = new ListBox();
        private ListBox lstBatch = new ListBox();
       
        private ListBox lstInvoiceNo = new ListBox();
       
        public int m_action { get; set; }
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        private string strComID { get; set; }
        List<InvoiceConfig> oinv;
        public int mintVtype { get; set; }
        List<StockItem> oogrp;
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
     
        SPWOIS objWIS = new SPWOIS();
        public frmStockTransferIN()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User In"
            this.uctxtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtInvoiceNo_KeyPress);
            this.uctxtInvoiceNo.GotFocus += new System.EventHandler(this.uctxtInvoiceNo_GotFocus);
            this.uctxtInvoiceNo.KeyDown += new KeyEventHandler(uctxtInvoiceNo_KeyDown);
            this.uctxtInvoiceNo.TextChanged += new System.EventHandler(this.uctxtInvoiceNo_TextChanged);
            this.lstInvoiceNo.DoubleClick += new System.EventHandler(this.lstInvoiceNo_DoubleClick);


            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.dteDate_GotFocus);

            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);
            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);

            this.uctxtRate.TextChanged += new System.EventHandler(this.uctxtRate_TextChanged);
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

            this.uctxtFromLocation.KeyDown += new KeyEventHandler(uctxtFromLocation_KeyDown);
            this.uctxtFromLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFromLocation_KeyPress);
            this.uctxtFromLocation.TextChanged += new System.EventHandler(this.uctxtFromLocation_TextChanged);
            this.lstFromLocation.DoubleClick += new System.EventHandler(this.lstFromLocation_DoubleClick);
            this.uctxtFromLocation.GotFocus += new System.EventHandler(this.uctxtFromLocation_GotFocus);

            this.uctxtToLocation.KeyDown += new KeyEventHandler(uctxtToLocation_KeyDown);
            this.uctxtToLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtToLocation_KeyPress);
            this.uctxtToLocation.TextChanged += new System.EventHandler(this.uctxtToLocation_TextChanged);
            this.lstToLocation.DoubleClick += new System.EventHandler(this.lstToLocation_DoubleClick);
            this.uctxtToLocation.GotFocus += new System.EventHandler(this.uctxtToLocation_GotFocus);

        
            this.uclstGrdItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstGrdItem_CellFormatting);

            Utility.CreateListBox(lstFromLocation, pnlMain, uctxtFromLocation);
            Utility.CreateListBox(lstToLocation, pnlMain, uctxtToLocation);
            Utility.CreateListBox(lstBatch, panel2, uctxtBatch);
           
            Utility.CreateListBox(lstInvoiceNo, pnlMain, uctxtInvoiceNo);
            #endregion

        }
        #region "Formating"
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
               
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }

            return false;
        }
        #endregion
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
        private void uctxtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstInvoiceNo.Items.Count > 0)
                {
                    if (uctxtInvoiceNo.Text == "")
                    {
                        uctxtInvoiceNo.Text = lstInvoiceNo.Text;
                    }
                }


                if (m_action == 1)
                {
                    if (uctxtInvoiceNo.Text != "")
                    {
                        DisplayProcessRm(lstInvoiceNo.SelectedValue.ToString());
                    }
                }
                uctxtNarration.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtInvoiceNo, sender, e);
            }
        }
        private void uctxtInvoiceNo_GotFocus(object sender, System.EventArgs e)
        {
            Refload();
            lstInvoiceNo.Visible = true;
            lstBatch.Visible = false;
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
            
        }

        private void uctxtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            lstInvoiceNo.SelectedIndex = lstInvoiceNo.FindString(uctxtInvoiceNo.Text);
        }

        private void Refload()
        {
            lstInvoiceNo.ValueMember = "strRefNo";
            lstInvoiceNo.DisplayMember = "strAgnstRefNo";
            lstInvoiceNo.DataSource = invms.mGetStockTranRefNo(strComID, uctxtFromLocation.Text, "").ToList();
        }

        private void lstInvoiceNo_DoubleClick(object sender, EventArgs e)
        {
            uctxtInvoiceNo.Text = lstInvoiceNo.Text;
            if (m_action == 1)
            {
                if (uctxtInvoiceNo.Text != "")
                {
                    DisplayProcessRm(lstInvoiceNo.SelectedValue.ToString());
                }
            }
            uctxtNarration.Focus();
        }

        private void DisplayProcessRm(string vstrProcess)
        {
            try
            {
                int intfg = 0;
               
                DG.Rows.Clear();
                List<ManuProcess> omanuProcess = invms.mDisplayTransferOutItem(strComID, vstrProcess, "O").ToList();
                if (omanuProcess.Count > 0)
                {
                    foreach (ManuProcess ts in omanuProcess)
                    {
                        if (ts.intType == 1)
                        {
                            DG.Rows.Add();
                            DG[0, intfg].Value = ts.stritemName;
                            DG[2, intfg].Value = ts.dblqnty;
                            DG[3, intfg].Value = ts.strUnit;
                            DG[4, intfg].Value = ts.dblCostPrice;
                            DG[5, intfg].Value = ts.dblsalesamount;
                            DG[7, intfg].Value = "Delete";
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

        private void uctxtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstInvoiceNo.SelectedItem != null)
                {
                    lstInvoiceNo.SelectedIndex = lstInvoiceNo.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstInvoiceNo.Items.Count - 1 > lstInvoiceNo.SelectedIndex)
                {
                    lstInvoiceNo.SelectedIndex = lstInvoiceNo.SelectedIndex + 1;
                }
            }

        }
       

        private void uctxtQty_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtQty.Text) == false)
            {
                uctxtQty.Text = "";
            }
        }
        private void uctxtRate_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtRate.Text) == false)
            {
                uctxtRate.Text = "";
            }
        }
        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {
            lstInvoiceNo.Visible = false;
            lstBatch.Visible = false;
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            

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
            lstInvoiceNo.Visible = false;
            lstBatch.Visible = false;
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtRate.Text = Utility.gdblPurchasePrice(strComID, uctxtItemName.Text, dteDate.Text).ToString();
                uctxtRate.Text = Utility.gdblGetCostPriceNew(strComID, uctxtItemName.Text, dteDate.Text).ToString();
                if (Utility.Val(uctxtRate.Text) != 0)
                {
                    uctxtItemName.Focus();
                }
                else
                {
                    MessageBox.Show("Rate Cannot be found");
                    uctxtQty.Focus();
                    return;
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
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtItemName, sender, e);
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
            lstInvoiceNo.Visible = false;
            lstBatch.Visible = false;
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
            
            //if (uctxtFromLocation.Text != "")
            //{
            //    mLoadAllItem();
            //}
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
            lstInvoiceNo.Visible = false;
            lstBatch.Visible = false;
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
            
        }
        private void dteDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtToLocation.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                uctxtInvoiceNo.Focus();
            }
        }
        private void dteDate_GotFocus(object sender, System.EventArgs e)
        {
            lstInvoiceNo.Visible = false;
            lstBatch.Visible = false;
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
            
        }
   

        private void uctxtBatch_TextChanged(object sender, EventArgs e)
        {
            lstBatch.SelectedIndex = lstBatch.FindString(uctxtToLocation.Text);
        }

        private void lstBatch_DoubleClick(object sender, EventArgs e)
        {
            uctxtToLocation.Text = lstBatch.Text;

        }

        private void uctxtBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBatch.Items.Count > 0)
                {
                    uctxtBatch.Text = lstBatch.Text;
                }
                mAddStockItem(DG, uctxtItemName.Text, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), Utility.gCheckNull(uctxtBatch.Text));
                uctxtItemName.Text = "";
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
                    lstBatch.SelectedIndex = lstToLocation.SelectedIndex + 1;
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
                dg[1, selRaw].Value = 0;
                dg[2, selRaw].Value = dblQty;
                dg[3, selRaw].Value = Utility.gGetBaseUOM(strComID, strItemName.ToString());
                dg[4, selRaw].Value = dblRate;
                dg[5, selRaw].Value = (dblQty * dblRate);
                //dg[6, selRaw].Value = strBatch;
                //dg[7, selRaw].Value = "Delete";
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

            lstInvoiceNo.Visible = false;
            lstFromLocation.Visible = false;
            lstBatch.Visible = true;
            uclstGrdItem.Visible = false;
            lstToLocation.Visible = false;
            
            lstBatch.ValueMember = "Key";
            lstBatch.DisplayMember = "Value";
            lstBatch.DataSource = invms.mFillBatch(strComID).ToList();

            lstBatch.SelectedIndex = lstBatch.FindString(uctxtToLocation.Text);
        }

        private void uctxtToLocation_TextChanged(object sender, EventArgs e)
        {
            lstToLocation.SelectedIndex = lstToLocation.FindString(uctxtToLocation.Text);
        }

        private void lstToLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtToLocation.Text = lstToLocation.Text;
            if (uctxtFromLocation.Enabled)
            {
                uctxtFromLocation.Focus();
            }
            else
            {
                uctxtNarration.Focus();
            }
            lstToLocation.Visible = false;
        }

        private void uctxtToLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstToLocation.Items.Count > 0)
                {
                    uctxtToLocation.Text = lstToLocation.Text;
                }
                lstToLocation.Visible = false;
                if (uctxtFromLocation.Enabled)
                {
                    uctxtFromLocation.Focus();
                }
                else
                {
                    uctxtNarration.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtToLocation, sender, e);
            }
        }
        private void uctxtToLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstToLocation.SelectedItem != null)
                {
                    lstToLocation.SelectedIndex = lstToLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstToLocation.Items.Count - 1 > lstToLocation.SelectedIndex)
                {
                    lstToLocation.SelectedIndex = lstToLocation.SelectedIndex + 1;
                }
            }

        }

        private void uctxtToLocation_GotFocus(object sender, System.EventArgs e)
        {
            lstInvoiceNo.Visible = false;
            lstFromLocation.Visible = false;
            lstToLocation.Visible = true;
            lstBatch.Visible = false;
            uclstGrdItem.Visible = false;
            
            lstToLocation.SelectedIndex = lstToLocation.FindString(uctxtToLocation.Text);
        }


        private void uctxtFromLocation_TextChanged(object sender, EventArgs e)
        {
            lstFromLocation.SelectedIndex = lstFromLocation.FindString(uctxtFromLocation.Text);
        }

        private void lstFromLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtFromLocation.Text = lstFromLocation.Text;
            uctxtInvoiceNo.Focus();
        }

        private void uctxtFromLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstFromLocation.Items.Count > 0)
                {
                    uctxtFromLocation.Text = lstFromLocation.Text;
                }
                uctxtInvoiceNo.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtFromLocation, sender, e);
            }
        }
      
        private void uctxtFromLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstFromLocation.SelectedItem != null)
                {
                    lstFromLocation.SelectedIndex = lstFromLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstFromLocation.Items.Count - 1 > lstFromLocation.SelectedIndex)
                {
                    lstFromLocation.SelectedIndex = lstFromLocation.SelectedIndex + 1;
                }
            }

        }

        private void uctxtFromLocation_GotFocus(object sender, System.EventArgs e)
        {
            lstInvoiceNo.Visible = false;
            lstFromLocation.Visible = true;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
            lstBatch.Visible = false;
            
            lstFromLocation.SelectedIndex = lstFromLocation.FindString(uctxtFromLocation.Text);
        }
        private void mLoadAllItem()
        {
            int introw = 0;
            uclstGrdItem.Rows.Clear();
            string strBranchID = Utility.gstrGetBranchIDfromGodown(strComID, uctxtFromLocation.Text.Trim());
            oogrp = objWIS.mGetProductStatementView(strComID, "", strBranchID, uctxtFromLocation.Text,"").ToList();
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
        #region "Claer"
        private void mClear()
        {
            uctxtFromLocation.Text = "";
            uctxtToLocation.Text = "";
            DG.Rows.Clear();
            uctxtItemName.Text = "";
            uctxtBatch.Text = "";
            uctxtRate.Text = "";
            uctxtNarration.Text = "";
            lblAmount.Text = "";
            uctxtQty.Text = "";
            uctxtNarration.Text = "";
            
            uctxtInvoiceNo.Text = "";
            uctxtInvoiceNo.Enabled = true ;
            uctxtFromLocation.Enabled = true;
            lblQnty.Text = "";
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod)
            {
                uctxtVoucherNo.Text = Utility.gstrLastNumber(strComID, mintVtype);
                uctxtVoucherNo.ReadOnly = true;
                dteDate.Select();
            }
            else
            {

                uctxtVoucherNo.Text = Utility.gobjNextNumber(uctxtInvoiceNo.Text);
                uctxtVoucherNo.ReadOnly = false;
                dteDate.Select();
            }

            
        }
        #endregion
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblamnt= 0,dblQnty=0;

            for (int i = 0; i < DG.Rows.Count; i++)
            {
                DG.Rows[i].Cells[5].Value = Utility.Val(DG.Rows[i].Cells[2].Value.ToString()) * Utility.Val(DG.Rows[i].Cells[4].Value.ToString());
                dblamnt = dblamnt + Utility.Val(DG.Rows[i].Cells[5].Value.ToString());
                dblQnty = dblQnty + Utility.Val(DG.Rows[i].Cells[2].Value.ToString());
            }

            lblAmount.Text =  dblamnt.ToString();
            lblQnty.Text = dblQnty.ToString();
        }
        #endregion
        #region "Damage"
        private string mStockTransfer()
        {
            string i = "", strDG = "", strBranchId = "",strToBranchId="", strRefNumber,strAgnstRefNo="";
            int intRow = 0;

          
            strToBranchId = Utility.gstrGetBranchID(strComID, uctxtToLocation.Text);
            if (m_action == 1)
            {
                if (uctxtInvoiceNo.Text != "")
                {
                    strAgnstRefNo = lstInvoiceNo.SelectedValue.ToString();
                }
                else
                {
                    strAgnstRefNo = "";
                }
            }
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
                            strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(mintVtype) + strToBranchId + uctxtInvoiceNo.Text;
                        }
                        else
                        {
                            strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(mintVtype) + strToBranchId + Utility.gstrLastNumber(strComID, mintVtype);
                        }


                       
                        i = objWIS.mSaveStockTransferIN(strComID, strRefNumber, 23, dteDate.Text, Utility.Val(lblAmount.Text),
                                                   Utility.gCheckNull(uctxtNarration.Text), strToBranchId,
                                                   Utility.gCheckNull(uctxtToLocation.Text), strDG, mblnNumbMethod, "", strAgnstRefNo, mintVtype, m_action);

                        if (i == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, strFormName, uctxtInvoiceNo.Text,
                                                                        1, Utility.Val(lblAmount.Text), (int)Utility.MODULE_TYPE.mtSTOCK, strBranchId);
                            }
                            mClear();
                        }
                        else
                        {
                            MessageBox.Show(i);
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else if (m_action == 2)
            {
                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = objWIS.mSaveStockTransferIN(strComID, textBox1.Text, 23, dteDate.Text, Utility.Val(lblAmount.Text),
                                                  Utility.gCheckNull(uctxtNarration.Text), strToBranchId,
                                                  Utility.gCheckNull(uctxtToLocation.Text), strDG, mblnNumbMethod, "", strAgnstRefNo, mintVtype, m_action);

                        if (i == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, strFormName, uctxtInvoiceNo.Text,
                                                                        2, Utility.Val(lblAmount.Text), (int)Utility.MODULE_TYPE.mtSTOCK, strBranchId);
                            }
                            mClear();
                        }
                        else
                        {
                            MessageBox.Show(i);
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
            if (uctxtFromLocation.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtFromLocation.Focus();
                return false;
            }

            if (DG.Rows.Count == 0)
            {
                MessageBox.Show("Item Cannot be Empty");
                uctxtItemName.Focus();
                return false;
            }
            if (uctxtFromLocation.Text.TrimStart() == uctxtToLocation.Text.TrimStart())
            {
                MessageBox.Show("Both Location Cannot be Same");
                uctxtFromLocation.Focus();
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
           

            return true;
        }

        #endregion
        #region "Save"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i="";
            if (ValidateFields() == false)
            {
                return;
            }
            try
            {
                i = mStockTransfer();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(i);
            }



        }

        #endregion
        #region "Event"
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
            frmStockTransferList objfrm = new frmStockTransferList();
            objfrm.intvType = mintVtype;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFlag = "I";
            objfrm.onAddAllButtonClicked = new frmStockTransferList.AddAllClick(DisplayVoucherList);
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
                if (uctxtInvoiceNo.Enabled)
                {
                    uctxtInvoiceNo.Focus();
                }
                else
                {
                    dteDate.Focus();
                }

                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DG.Rows.Clear();
                uctxtFromLocation.Enabled = false;
                uctxtInvoiceNo.Enabled = false;
                uctxtVoucherNo.Text = Utility.Mid(tests[0].strRefNo, 6, tests[0].strRefNo.Length - 6);
                textBox1.Text = tests[0].strRefNo;
          
                dteDate.Text = tests[0].strDate;
                uctxtNarration.Text = tests[0].strNarration;
                List<StockItem> oRm = objWIS.mFillDisplayStockTransferin(strComID, tests[0].strRefNo).ToList();
                {
                    if (oRm.Count > 0)
                    {
                        uctxtInvoiceNo.Text = Utility.Mid(oRm[0].strAgnstRefNo, 6, oRm[0].strAgnstRefNo.Length - 6);
                        uctxtFromLocation.Text = objWIS.gstrGetFromLocation(strComID, oRm[0].strAgnstRefNo);
                        foreach (StockItem ooRm in oRm)
                        {
                            DG.Rows.Add();
                            DG[0, intrm].Value = ooRm.strItemName;
                            DG[1, intrm].Value = dblclsQnty;
                            DG[2, intrm].Value = Math.Abs(ooRm.dblOpnQty);
                            DG[3, intrm].Value = Utility.gGetBaseUOM(strComID, ooRm.strItemName);
                            DG[4, intrm].Value = Math.Abs(ooRm.dblOpnRate);
                            DG[5, intrm].Value = Math.Abs(ooRm.dblOpnValue);
                            DG[6, intrm].Value = ooRm.strBatch;
                            DG[7, intrm].Value = "Delete";
                            uctxtToLocation.Text = ooRm.strToLocation;
                            //uctxtProcessName.Text = ooRm.strProcess;
                            DG[8, intrm].Value = ooRm.strBillKey;
                            intrm += 1;
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

        private void uctxtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (uctxtItemName.Text != "")
                {
                    SearchListView(oogrp, uctxtItemName.Text);
                }
               
            }
            catch (Exception ex)
            {

            }
        }

        private void SearchListView(IEnumerable<StockItem> tests, string searchString)
        {
            IEnumerable<StockItem> query;
           
            query = tests;

        
            if (searchString != "")
            {
                query = (from test in tests
                         where test.strItemName.ToString().StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                         select test);
            }
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

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DG.Rows[e.RowIndex].Cells[5].Value = Utility.Val(DG.Rows[e.RowIndex].Cells[2].Value.ToString()) * Utility.Val(DG.Rows[e.RowIndex].Cells[4].Value.ToString());
            calculateTotal();
        }

        #endregion
        #region "Load"
        private void frmStockTransferIN_Load(object sender, EventArgs e)
        {
            mGetConfig();
            mClear(); ;
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            lstFromLocation.Visible = false;
            lstBatch.Visible = false;
            
            DG.AllowUserToAddRows = false;

            frmLabel.Text = "Stock Transfer(In)";
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 300, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Curr. Stock", "Curr. Stock", 100, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 60, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Batch", "Batch", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("InvTranKey", "InvTranKey", 200, false, DataGridViewContentAlignment.TopLeft, true));

            lstToLocation.ValueMember = "strLocation";
            lstToLocation.DisplayMember = "strLocation";
            lstToLocation.DataSource = invms.gLoadLocation(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName, 2).ToList();

            lstFromLocation.ValueMember = "strLocation";
            lstFromLocation.DisplayMember = "strLocation";
            lstFromLocation.DataSource = invms.gLoadLocation(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName, 2).ToList();

           
            dteDate.Select();
            dteDate.Focus();
        }
        #endregion
    }

}
