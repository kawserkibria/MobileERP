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
using JA.Modulecontrolar.UI.Accms.Forms;
using JA.Modulecontrolar.UI.Forms;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Inventory;
using Microsoft.VisualBasic;
using JA.Modulecontrolar.UI.Accms;
using JA.Modulecontrolar.JSAPUR;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSalesOrderNew : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        SPWOIS objWIS = new SPWOIS();
        private string strMysql { get; set; }
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstGroup = new ListBox();
        //public long mlngvtype { get; set; }
        public int m_action { get; set; }
        public long lngFormPriv { get; set; }
        private string strOldBranchName { get; set; }
        List<Invoice> ooCustomer;
        List<Invoice> ooPartyName;
        public int intVtype { get; set; }
        public int lngLedgeras { get; set; }
        public double mdblNetAmount { get; set; }
        private int mintIsPrin { get; set; }
        List<InvoiceConfig> oinv;
        List<StockItem> oogrp;
        private string strComID { get; set; }
        private bool mblnNumbMethod { get; set; }
        public frmSalesOrderNew()
        {
            InitializeComponent();
            #region "Registry"
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #endregion
            #region "User IN"

            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.uctxtCustomerMarz.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtCustomerMarz_KeyUp);
            this.uctxtCustomerMarz.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtCustomerMarz_KeyUp);
            this.uctxtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtItemName_KeyUp);

            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);
            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.ucdgList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ucdgList_KeyPress);
            this.ucdgList.DoubleClick += new System.EventHandler(this.ucdgList_DoubleClick);

            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);
            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);

            this.uctxtGroupName.KeyDown += new KeyEventHandler(uctxtGroupName_KeyDown);
            this.uctxtGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtGroupName_KeyPress);
            this.uctxtGroupName.TextChanged += new System.EventHandler(this.uctxtGroupName_TextChanged);
            this.lstGroup.DoubleClick += new System.EventHandler(this.lstGroup_DoubleClick);
            this.uctxtGroupName.GotFocus += new System.EventHandler(this.uctxtGroupName_GotFocus);

            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);
            this.DGcustomer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGcustomer_CellFormatting);
            this.ucdgList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ucdgList_CellFormatting);

            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);
            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);
            //this.uctxtRate.LostFocus += new System.EventHandler(this.uctxtRate_LostFocus);

            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtRate.GotFocus += new System.EventHandler(this.uctxtRate_GotFocus);
            this.uctxtRate.TextChanged += new System.EventHandler(this.uctxtRate_TextChanged);

            this.uctxtCustomerMarz.KeyDown += new KeyEventHandler(uctxtCustomerMarz_KeyDown);
            this.uctxtCustomerMarz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCustomerMarz_KeyPress);
            this.uctxtCustomerMarz.GotFocus += new System.EventHandler(this.uctxtCustomerMarz_GotFocus);
            this.DGcustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGcustomer_KeyPress);
            this.DGcustomer.DoubleClick += new System.EventHandler(this.DGcustomer_DoubleClick);

            this.uctxtLedegerNameMarze.KeyDown += new KeyEventHandler(uctxtLedegerNameMarze_KeyDown);
            this.uctxtLedegerNameMarze.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedegerNameMarze_KeyPress);
            this.uctxtLedegerNameMarze.GotFocus += new System.EventHandler(this.uctxtLedegerNameMarze_GotFocus);
            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);

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

            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            Utility.CreateListBox(lstGroup, panel2, uctxtGroupName);


            #endregion
        }
       
        #region "Getconfig"
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, (long)intVtype).ToList();
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
            int intloop = 0;
            double  dblBillAmount = 0,dblCommAmnt=0;
            

            double  sum = 0;
           double  Qty = 0;
            try
            {
                for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
                {
                    sum += double.Parse(DGSalesGrid.Rows[i].Cells[7].Value.ToString());
                    Qty += double.Parse(DGSalesGrid.Rows[i].Cells[4].Value.ToString());
                    dblCommAmnt += double.Parse(DGSalesGrid.Rows[i].Cells[8].Value.ToString());
                    intloop += 1;
                }
                lblTotalAmount.Text = sum.ToString();
                lblQuantityTotal.Text = Qty.ToString();
                //txtTotal.Text = dblNetAmount.ToString();
                txtBillTotal.Text = dblBillAmount.ToString();
                txtCommAmnt.Text = dblCommAmnt.ToString();
                txtNetTotal.Text = (sum - dblCommAmnt).ToString();
                txtTotalItem.Text = "Total Item :" + intloop;
            }
            catch (Exception ex)
            {

            }
            
        }
        #endregion
        #region "User Define Event"
        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtItemName.Text == "")
                {
                    ucdgList.Visible = false;
                    uctxtNarration.Focus();
                }
                if (uctxtItemName.Text != "")
                {
                    ucdgList.Focus();
                    if (ucdgList.Rows.Count > 0)
                    {
                        int i = 0;

                        uctxtItemName.Text = ucdgList.Rows[i].Cells[0].Value.ToString();
                        ucdgList.Visible = false;
                        uctxtQty.Focus();
                    }
                }
                else
                {

                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtItemName, uctxtLocation);
            }
        }
        private void uctxtCustomerMarz_KeyDown(object sender, KeyEventArgs e)
        {

            DGcustomer.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                DGcustomer.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DGcustomer.Focus();
            }

            DGcustomer.Top = uctxtCustomerMarz.Top + 25;
            DGcustomer.Left = uctxtCustomerMarz.Left;
            DGcustomer.Width = uctxtCustomerMarz.Width;
            DGcustomer.Height = 200;
            DGcustomer.BringToFront();
            DGcustomer.AllowUserToAddRows = false;
            return;
        }
        private void uctxtCustomerMarz_GotFocus(object sender, System.EventArgs e)
        {

            DGMr.Top = uctxtLedegerNameMarze.Top + 25;
            DGMr.Left = uctxtLedegerNameMarze.Left;
            DGMr.Width = uctxtLedegerNameMarze.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGcustomer.Visible = true;
            DGcustomer.AllowUserToAddRows = false;
            DGcustomer.Visible = false;
            if (uctxtLedegerNameMarze.Text != "")
            {
                mloadcustomer();
            }
            DGcustomer.AllowUserToAddRows = true;
        }
        private void uctxtCustomerMarz_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtCustomerMarz.Text == "" || uctxtCustomerMarz.Text == Utility.gcEND_OF_LIST)
                {
                    uctxtCustomerMarz.Text = "";
                    uctxtCustomerMarz.Text = Utility.gcEND_OF_LIST;
                    DGcustomer.Visible = false;
                    uctxtLocation.Focus();
                    return;
                }

                if (uctxtItemName.Text != "")
                {
                    DGcustomer.Focus();
                    if (DGcustomer.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtCustomer.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                        uctxtCustomerMarz.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();

                        DGcustomer.Visible = false;
                        uctxtLocation.Focus();
                    }
                }
                else
                {
                    if (DGcustomer.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtCustomer.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                        uctxtCustomerMarz.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                        DGcustomer.Visible = false;
                    }
                    else
                    {
                        uctxtCustomerMarz.Text = "End of List";
                    }
                    uctxtLocation.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtCustomerMarz, uctxtLedegerNameMarze);
            }

        }
        private void uctxtLedegerNameMarze_KeyDown(object sender, KeyEventArgs e)
        {
            DGMr.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                DGMr.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DGMr.Focus();
            }

            DGMr.Top = uctxtLedegerNameMarze.Top + 25;
            DGMr.Left = uctxtLedegerNameMarze.Left;
            DGMr.Width = uctxtLedegerNameMarze.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            return;

        }
        private void uctxtLedegerNameMarze_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtLedegerNameMarze.Text == "")
                {
                    uctxtLedegerNameMarze.Text = "";
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        DGMr.Visible = true;
                    }

                    DGMr.Visible = false;

                    return;
                }

                if (uctxtLedegerNameMarze.Text != "")
                {
                    DGMr.Focus();
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtLedgerName.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        uctxtLedegerNameMarze.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        DGMr.Visible = false;
                        uctxtCustomerMarz.Focus();

                    }
                }
                else
                {
                    int i = 0;
                    uctxtLedgerName.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtLedegerNameMarze.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    DGMr.Visible = false;
                    uctxtCustomerMarz.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtLedegerNameMarze, uctxtBranchName);
            }


        }
        private void uctxtLedegerNameMarze_GotFocus(object sender, System.EventArgs e)
        {
            DGMr.Top = uctxtLedegerNameMarze.Top + 25;
            DGMr.Left = uctxtLedegerNameMarze.Left;
            DGMr.Width = uctxtLedegerNameMarze.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.Visible = true;
            DGMr.AllowUserToAddRows = false;
            if (uctxtBranchName.Text != "")
            {
                mloadParty(lstBranchName.SelectedValue.ToString());
            }
            DGMr.Visible = true;
            DGMr.AllowUserToAddRows = true;

        }
        private void dteDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtLedegerNameMarze.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                uctxtLedegerNameMarze.Focus();
            }
        }
        //private void uctxtRate_LostFocus(object sender, System.EventArgs e)
        //{
        //    //double dblQty = 0, dblRate = 0;
        //    //if (uctxtItemName.Text != "")
        //    //{
        //    //    if (uctxtQty.Text == "")
        //    //    {
        //    //        dblQty = 0;
        //    //    }
        //    //    else
        //    //    {
        //    //        dblQty = Convert.ToDouble(uctxtQty.Text);
        //    //    }
        //    //    if (uctxtRate.Text == "")
        //    //    {
        //    //        dblRate = 0;
        //    //    }
        //    //    else
        //    //    {
        //    //        dblRate = Convert.ToDouble(uctxtRate.Text);
        //    //    }
        //    //    mAdditem(uctxtItemName.Text, dblQty, dblRate);
        //    }

        //}
        //private void mAdditem(string strItemName, double dblQty, double dblRate)
        //{
        //    int selRaw;

        //    string strDown = "";
        //    Boolean blngCheck = false;
        //    for (int j = 0; j < DGSalesGrid.RowCount; j++)
        //    {
        //        if (DGSalesGrid[0, j].Value != null)
        //        {
        //            strDown = DGSalesGrid[0, j].Value.ToString();
        //        }
        //        if (strItemName == strDown.ToString())
        //        {
        //            blngCheck = true;
        //        }

        //    }
        //    if (blngCheck == false)
        //    {

        //        DGSalesGrid.AllowUserToAddRows = true;
        //        selRaw = Convert.ToInt16(DGSalesGrid.RowCount.ToString());
        //        selRaw = selRaw - 1;
        //        DGSalesGrid.Rows.Add();
        //        DGSalesGrid[0, selRaw].Value = strItemName;
        //        DGSalesGrid[1, selRaw].Value = dblQty;
        //        DGSalesGrid[2, selRaw].Value = Utility.gGetBaseUOM(strComID, strItemName);
        //        DGSalesGrid[3, selRaw].Value = dblRate;
        //        DGSalesGrid[4, selRaw].Value = Math.Round(dblQty * dblRate, 2);
        //        DGSalesGrid.AllowUserToAddRows = false;
        //        uctxtItemName.Text = "";
        //        uctxtQty.Text = "";
        //        uctxtRate.Text = "";
        //        uctxtItemName.Focus();
        //        //calculateTotal();
        //    }

        //}

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
       
        private void ucdgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ucdgList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            ucdgList.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            ucdgList.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void DGcustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGcustomer.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGcustomer.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGcustomer.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void DGMr_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void DGMr_DoubleClick(object sender, EventArgs e)
        {
            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtLedgerName.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtLedegerNameMarze.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                DGMr.Visible = false;
                uctxtCustomerMarz.Focus();
            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtLedgerName.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtLedegerNameMarze.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                DGMr.Visible = false;
                uctxtCustomerMarz.Focus();
            }
        }
        private void uctxtTerritoryCode_TextChanged(object sender, EventArgs e)
        {
            if (uctxtLedegerNameMarze.Text == "")
            {
                uctxtLedegerNameMarze.Text = "";
                uctxtCustomerMarz.Text = "";
            }

        }
        private void uctxtTerritoryCode_KeyDown(object sender, KeyEventArgs e)
        {

            DGMr.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                DGMr.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DGMr.Focus();
            }

            DGMr.Top = uctxtLedegerNameMarze.Top + 25;
            DGMr.Left = uctxtLedegerNameMarze.Left;
            DGMr.Width = uctxtLedegerNameMarze.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            return;
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
     
        private void uctxtOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteDate.Focus();

            }
        }
        private void uctxtGroupName_TextChanged(object sender, EventArgs e)
        {
            lstGroup.SelectedIndex = lstGroup.FindString(uctxtGroupName.Text);
        }

        private void lstGroup_DoubleClick(object sender, EventArgs e)
        {
            uctxtGroupName.Text = lstGroup.Text;
            uctxtItemName.Focus();
        }

        private void uctxtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstGroup.Items.Count > 0)
                {
                    uctxtGroupName.Text = lstGroup.Text;
                }
                uctxtItemName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtGroupName, sender, e);
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

            ucdgList.VirtualMode = false;
            DGMr.Visible = false;
            DgCostCenter.Visible = false;
            lstBranchName.Visible = false;
            lstGroup.Visible = true;
            lstLocation.Visible = false;
            lstGroup.DisplayMember = "strGroupName";
            lstGroup.ValueMember = "strGroupName";
            lstGroup.DataSource = invms.mFillSample(strComID,"").ToList();
            lstGroup.SelectedIndex = lstGroup.FindString(uctxtGroupName.Text);
        }
        private void ucdgList_DoubleClick(object sender, EventArgs e)
        {
            if (ucdgList.SelectedRows.Count > 0)
            {
                uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
                ucdgList.Visible = false;
                uctxtQty.Focus();
            }
        }
        private void ucdgList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
                ucdgList.Visible = false;
                uctxtQty.Focus();
            }
        }

        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {
            ucdgList.VirtualMode = false;
            DGMr.Visible = false;
            DgCostCenter.Visible = false;
            lstBranchName.Visible = false;
            lstGroup.Visible = false;
            lstLocation.Visible = false;
            mCalculateDiscount();
        }
        private void mCalculateDiscount()
        {
            string strItemGroup = "", str2ndGroup = "", strGrid = "", strBranchID = "";
            double dblItemAmount = 0, dblAmount = 0;
            //List<Sample> ooSample = invms.mFillSample().ToList();
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            List<StockGroup> ooSample = invms.mFillStockGroupconfig(strComID).ToList();
            foreach (StockGroup oobj in ooSample)
            {
                strItemGroup = oobj.GroupName;

                for (int int2nd = 0; int2nd < DGSalesGrid.Rows.Count; int2nd++)
                {
                    if (DGSalesGrid[1, int2nd].Value != null)
                    {
                        str2ndGroup = DGSalesGrid[12, int2nd].Value.ToString();
                        if (strItemGroup == str2ndGroup)
                        {

                            dblAmount = (Utility.Val(DGSalesGrid[4, int2nd].Value.ToString()) * Utility.Val(DGSalesGrid[5, int2nd].Value.ToString()));
                            dblItemAmount = dblItemAmount + dblAmount;
                        }
                    }
                }
                if (dblItemAmount != 0)
                {
                    strGrid += strItemGroup + "|" + dblItemAmount + "~";
                }
                dblItemAmount = 0;
            }


            //MessageBox.Show(strGrid);
            if (strGrid != "")
            {
                double dblPercent = 0, dblFixedPercent = 0;
                string strFDate = "", strTdate = "";
                string[] words = strGrid.Split('~');
                foreach (string ooassets in words)
                {
                    string[] oAssets = ooassets.Split('|');
                    if (oAssets[0] != "")
                    {
                        dblPercent = Utility.mdblGetCommiPercen(strComID, oAssets[0], Utility.Val(oAssets[1]), strBranchID);
                        strFDate = Utility.FirstDayOfMonth(dteDate.Value).ToString("dd/MM/yyyy");
                        strTdate = dteDate.Text;
                        if (m_action == 1)
                        {
                            dblFixedPercent = Utility.mdblGetMaxCommiPercen(strComID, uctxtCustomer.Text, oAssets[0], strFDate, strTdate, strBranchID, "");
                        }
                        else
                        {
                            dblFixedPercent = Utility.mdblGetMaxCommiPercen(strComID, uctxtCustomer.Text, oAssets[0], strFDate, strTdate, strBranchID, uctxtOldRefNo.Text);
                        }
                        if (dblFixedPercent == 40)
                        {
                            dblPercent = 40;
                        }

                        for (int int2nd = 0; int2nd < DGSalesGrid.Rows.Count; int2nd++)
                        {
                            if (DGSalesGrid[12, int2nd].Value != null)
                            {
                                str2ndGroup = DGSalesGrid[12, int2nd].Value.ToString();
                                if (oAssets[0] == str2ndGroup)
                                {
                                    DGSalesGrid[8, int2nd].Value = ((Utility.Val(DGSalesGrid[4, int2nd].Value.ToString()) * Utility.Val(DGSalesGrid[5, int2nd].Value.ToString())) * dblPercent) / 100;
                                    DGSalesGrid[10, int2nd].Value = Utility.Val(DGSalesGrid[7, int2nd].Value.ToString()) - Utility.Val(DGSalesGrid[8, int2nd].Value.ToString());
                                    DGSalesGrid[13, int2nd].Value = dblPercent;
                                }
                            }
                        }
                        dblItemAmount = 0;
                    }
                }
                calculateTotal();
            }



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

        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }

        private void uctxtBatch_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }

        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            ucdgList.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                ucdgList.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                ucdgList.Focus();
            }

            ucdgList.Top = uctxtItemName.Top + 25;
            ucdgList.Left = uctxtItemName.Left;
            ucdgList.Width = uctxtItemName.Width;
            ucdgList.Height = 200;
            ucdgList.BringToFront();
            ucdgList.AllowUserToAddRows = false;
            return;
        }

        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstGroup.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            mloadItem();
        }
        private void mloadItem()
        {
            int introw = 0;
            ucdgList.Rows.Clear();
            if (uctxtLocation.Text == "")
            {
                return;
            }
            //oogrp = invms.mloadAddStockItemSI(strComID, uctxtGroupName.Text, uctxtLocation.Text).ToList();
            oogrp = objWIS.gFillStockItemNew(strComID, uctxtGroupName.Text, uctxtLocation.Text).ToList();

            if (oogrp.Count > 0)
            {

                foreach (StockItem ogrp in oogrp)
                {
                    ucdgList.Rows.Add();
                    ucdgList[0, introw].Value = ogrp.strItemName;
                    ucdgList[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;

                    introw += 1;
                }

                ucdgList.AllowUserToAddRows = false;
            }
        }
        //private void mAddStockItem(string strGroupName, string strItemName, string strPowerClass, string strPackSize, double dblQty, double dblRate,
        //                            string strUom, string strDis, string strBatch, double dblShort)
        //{
        //    int selRaw;

        //    string strDown = "";
        //    double dblDis = 0;
        //    Boolean blngCheck = false;
        //    for (int j = 0; j < DGSalesGrid.RowCount; j++)
        //    {
        //        if (DGSalesGrid[2, j].Value != null)
        //        {
        //            strDown = DGSalesGrid[2, j].Value.ToString();
        //        }
        //        if (strItemName == strDown.ToString())
        //        {
        //            blngCheck = true;

        //        }

        //    }
        //    if (blngCheck == false)
        //    {

        //        DGSalesGrid.AllowUserToAddRows = true;
        //        selRaw = Convert.ToInt16(DGSalesGrid.RowCount.ToString());
        //        selRaw = selRaw - 1;
        //        DGSalesGrid.Rows.Add();
        //        //if (strDis != "")
        //        //{
        //        //    if (Utility.Right(strDis, 1) == "%")
        //        //    {
        //        //        dblDis = ((dblQty * dblRate) * Utility.Val(strDis)) / 100;
        //        //    }
        //        //    else
        //        //    {
        //        //        dblDis = Utility.Val(strDis);
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    dblDis = 0;
        //        //}

        //        double dblbonus = Math.Round(Utility.mdblGetBonus(strComID, uctxtItemName.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), Utility.Val(uctxtQty.Text.ToString()), dteDate.Text), 2);
        //        if (m_action == 2)
        //        {
        //            DGSalesGrid[0, selRaw].Value = Utility.mGetRefNo(strComID, "ACC_BILL_TRAN", "BILL_TRAN_KEY", "COMP_REF_NO", uctxtOldRefNo.Text);
        //        }


        //        DGSalesGrid[1, selRaw].Value = strGroupName.ToString();
        //        DGSalesGrid[2, selRaw].Value = strItemName.ToString();
        //        DGSalesGrid[3, selRaw].Value = strPowerClass.ToString();
        //        DGSalesGrid[4, selRaw].Value = strPackSize.ToString();
        //        DGSalesGrid[5, selRaw].Value = dblQty.ToString();
        //        DGSalesGrid[6, selRaw].Value = dblRate.ToString();
        //        DGSalesGrid[7, selRaw].Value = strUom;
        //        DGSalesGrid[8, selRaw].Value = (dblQty * dblRate);
        //        DGSalesGrid[9, selRaw].Value = dblDis;
        //        DGSalesGrid[10, selRaw].Value = (dblQty * dblRate) - dblDis;
        //        //DGSalesGrid[11, selRaw].Value = strBatch;
        //        //DGSalesGrid[12, selRaw].Value = dblbonus;
        //        //DGSalesGrid[13, selRaw].Value = dblShort;
        //        DGSalesGrid[11, selRaw].Value = "Delete";
        //        //DGSalesGrid[15, selRaw].Value = Utility.mGetStockGroupFromItemGroup(strComID, strGroupName);

        //        uctxtQty.Text = "";
        //        uctxtRate.Text = "";
        //        uctxtItemName.Text = "";
        //        DGSalesGrid.AllowUserToAddRows = false;
        //        calculateTotal();
        //    }
        //    else
        //    {
        //        uctxtItemName.Text = "";
        //        MessageBox.Show("Item is Already Exists");
        //        uctxtItemName.Focus();
        //        return;
        //    }

        //}


        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strPowerClass = "", strUOM = "", strPackSize = "";

            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtItemName.Text != "")
                {
                    if (uctxtItemName.Text != "")
                    {
                        strUOM = Utility.gGetBaseUOM(strComID, uctxtItemName.Text);
                        strPowerClass = Utility.mGetPowerClass(strComID, uctxtItemName.Text);
                        strPackSize = Utility.mGetPackSize(strComID, uctxtItemName.Text);
                        if (uctxtRate.Text != "" && uctxtRate.Text != "0")
                        {
                            mAddStockItem(uctxtGroupName.Text, uctxtItemName.Text, strPowerClass, strPackSize, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), strUOM, "", "");
                            uctxtItemName.Focus();
                        }
                        else
                        {
                            uctxtRate.Focus();
                        }
                    }
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtRate, uctxtQty);
            }

        }


        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {

            double dblrate = 0;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_ORDER)
                {
                    dblrate = Utility.gdblGetEnterpriseSalesPrice(strComID, uctxtItemName.Text, dteDate.Text, Utility.Val(uctxtQty.Text.ToString()), 0, "");
                    uctxtRate.Text = dblrate.ToString();
                }
                else
                {
                    dblrate = Utility.gdblPurchasePrice(uctxtItemName.Text, dteDate.Text, uctxtLocation.Text);
                    uctxtRate.Text = dblrate.ToString();
                }
                uctxtRate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtQty, uctxtItemName);
            }

        }

        private void mAddStockItem(string strGroupName, string strItemName, string strPowerClass, string strPackSize, double dblQty, double dblRate,
                              string strUom, string strDis, string strBatch)
        {
            int selRaw;

            string strDown = "";
            double dblDis = 0;
            Boolean blngCheck = false;
            for (int j = 0; j < DGSalesGrid.RowCount; j++)
            {
                if (DGSalesGrid[1, j].Value != null)
                {
                    strDown = DGSalesGrid[1, j].Value.ToString();
                }
                if (strItemName == strDown.ToString())
                {
                    blngCheck = true;
                    uctxtItemName.Text = "";
                    uctxtQty.Text = "";
                    uctxtRate.Text = "";
                    MessageBox.Show("Item is Already Exists");
                    return;

                }

            }
            if (blngCheck == false)
            {

                DGSalesGrid.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DGSalesGrid.RowCount.ToString());
                selRaw = selRaw - 1;
                DGSalesGrid.Rows.Add();
                //if (strDis != "")
                //{
                //    if (Utility.Right(strDis, 1) == "%")
                //    {
                //        dblDis = ((dblQty * dblRate) * Utility.Val(strDis)) / 100;
                //    }
                //    else
                //    {
                //        dblDis = Utility.Val(strDis);
                //    }
                //}
                //else
                //{
                //    dblDis = 0;
                //}
                double dblbonus = Math.Round(Utility.mdblGetBonus(strComID, uctxtItemName.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), Utility.Val(uctxtQty.Text.ToString()), dteDate.Text), 2);
                if (m_action == 2)
                {
                    DGSalesGrid[0, selRaw].Value = Utility.mGetRefNo(strComID, "ACC_BILL_TRAN", "BILL_TRAN_KEY", "COMP_REF_NO", uctxtOldRefNo.Text);
                }



                DGSalesGrid[0, selRaw].Value = strGroupName.ToString();
                DGSalesGrid[1, selRaw].Value = strItemName.ToString();
                DGSalesGrid[2, selRaw].Value = strPowerClass.ToString();
                DGSalesGrid[3, selRaw].Value = strPackSize.ToString();
                DGSalesGrid[4, selRaw].Value = dblQty.ToString();
                DGSalesGrid[5, selRaw].Value = dblRate.ToString();
                DGSalesGrid[6, selRaw].Value = strUom.ToString();
                DGSalesGrid[7, selRaw].Value = (dblQty * dblRate);
                DGSalesGrid[8, selRaw].Value = dblbonus;
                DGSalesGrid[9, selRaw].Value = dblbonus;
                DGSalesGrid[11, selRaw].Value = "Delete";
                DGSalesGrid[12, selRaw].Value = Utility.mGetStockGroupFromItemGroup(strComID, strGroupName); ;
                uctxtQty.Text = "";
                uctxtRate.Text = "";
                uctxtItemName.Text = "";
                DGSalesGrid.AllowUserToAddRows = false;
                calculateTotal();
            }
            else
            {
                uctxtItemName.Text = "";
                MessageBox.Show("Item is Already Exists");
                uctxtItemName.Focus();
                return;
            }

        }

        private void DGcustomer_DoubleClick(object sender, EventArgs e)
        {

            if (DGcustomer.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                uctxtCustomerMarz.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                DGcustomer.Visible = false;
                uctxtLocation.Focus();

            }

        }
        private void DGcustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                uctxtCustomerMarz.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                DGcustomer.Visible = false;
                uctxtLocation.Focus();
            }
        }

        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            uctxtGroupName.Focus();
        }

        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                }
                if (uctxtLocation.Text == "")
                {
                    uctxtLocation.Text = lstLocation.Text;
                }
                uctxtGroupName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtLocation, uctxtCustomerMarz);
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
            lstGroup.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            if (uctxtBranchName.Text != "")
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName,0).ToList();
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
            lstBranchName.Visible = false;
            dteDate.Focus();
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }


                if (strOldBranchName != uctxtBranchName.Text)
                {
                    uctxtLedegerNameMarze.Text = "";
                    uctxtCustomerMarz.Text = "";
                    uctxtLocation.Text = "";
                }
                lstBranchName.Visible = false;
                dteDate.Focus();
            }
            
        }
        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            lstBranchName.Visible = true;
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
            //if (m_action == 1)
            //{
            //    lstBranchName.Visible = true;
            //}
            lstLocation.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtLedegerNameMarze.Focus();

            }

        }


        #endregion
        #region "Default Value"
        private void LoadDefaultValue()
        {

            SortedDictionary<string, int> userCacheRef = new SortedDictionary<string, int>
            {
              {"Advance", 1},
              {"Agst Ref", 2},
              {"New Ref", 2}
            };




            if ((long)Utility.VOUCHER_TYPE.vtSALES_INVOICE == intVtype)
            {
                SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
                {
                  {Utility.gcEND_OF_LIST, 1},
                  {gobjVoucherName.VoucherName.GetVoucherName((long)Utility.VOUCHER_TYPE.vtSALES_ORDER), 2}
                };

            }
            else
            {
                SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
                {
                  {Utility.gcEND_OF_LIST, 1},
                  {gobjVoucherName.VoucherName.GetVoucherName((long)Utility.VOUCHER_TYPE.vtPURCHASE_ORDER), 2},
                };

            }


        }
        #endregion
        #region "Load"
        #region "Clear"
        private void mClear()
        {
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            uctxtBranchName.Text = "";
            uctxtLedegerNameMarze.Text = "";
            uctxtCustomerMarz.Text = "";
            uctxtLocation.Text = "";
            uctxtNarration.Text = "";
            uctxtOldRefNo.Text = "";
            uctxtLedgerName.Text = "";
            uctxtCustomer.Text = "";
            uctxtGroupName.Text = "";
            uctxtItemName.Text = "";
            uctxtQty.Text = "";
            uctxtRate.Text = "";
            lblQuantityTotal.Text = "";
            lblTotalAmount.Text = "";
            txtTotalItem.Text = "";
            txtApprovedby.Text = "";
            txtApprovedDate.Text = "";
            txtApprovedStatus.Text = "";
            txtCommAmnt.Text = "";
            txtNetTotal.Text = "";
            DGSalesGrid.Rows.Clear();
            if (mblnNumbMethod)
            {
                uctxtOrderNo.Text = Utility.gstrLastNumber(strComID, (int)intVtype);
                uctxtOrderNo.ReadOnly = true;
                uctxtBranchName.Select();
            }
            else
            {
                uctxtOrderNo.Text = Utility.gobjNextNumber(uctxtOrderNo.Text);
                uctxtOrderNo.ReadOnly = false;
                uctxtBranchName.Select();
            }

        }
        #endregion

        private void mloadParty(string strBranchID)
        {
            int introw = 0;
            DGMr.Rows.Clear();
            ooPartyName = invms.mfillPartyNameNew(strComID, strBranchID, Utility.gblnAccessControl, Utility.gstrUserName, 0, "").ToList();
            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DGMr.Rows.Add();
                    DGMr[0, introw].Value = ogrp.strLedgerName;
                    DGMr[1, introw].Value = ogrp.strMereString;
                    introw += 1;

                }

                DGMr.AllowUserToAddRows = false;
            }
        }
        private void mloadcustomer()
        {
            int introw = 0;
            DGcustomer.Rows.Clear();

            ooCustomer = invms.mFillSalesRepFromMPoNew1(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP, uctxtLedgerName.Text).ToList();

            if (ooCustomer.Count > 0)
            {

                foreach (Invoice ogrp in ooCustomer)
                {
                    DGcustomer.Rows.Add();
                    DGcustomer[0, introw].Value = ogrp.strLedgerName;
                    DGcustomer[1, introw].Value = ogrp.strMereString;
                    introw += 1;
                }

                DGcustomer.AllowUserToAddRows = false;
            }
        }
        #endregion
        #region "DisplayVoucher"
        private void DisplayVoucherList(List<AccountsVoucher> tests, object sender, EventArgs e)
        {
            try
            {
                int introw = 0;
                mClear();
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DGSalesGrid.Rows.Clear();
                //DGSalesGrid.Enabled = false ;
                uctxtQty.ReadOnly = true;
                uctxtRate.ReadOnly = true;
                uctxtBranchName.Focus();
                uctxtOldRefNo.Text = tests[0].strVoucherNo;
              
                strMysql = tests[0].strPreserveSQL;
                txtApprovedStatus.Text = tests[0].intAppStatus.ToString();
                List<AccountsVoucher> ooaccVou = accms.DisplayCompVoucherList(strComID, tests[0].strVoucherNo, intVtype).ToList();
                if (ooaccVou.Count > 0)
                {
                    foreach (AccountsVoucher oCom in ooaccVou)
                    {
                        uctxtOrderNo.Text = Utility.Mid(oCom.strVoucherNo, 6, oCom.strVoucherNo.Length - 6);
                        if (oCom.strSalesRepresentive != "")
                        {
                            uctxtCustomer.Text = oCom.strSalesRepresentive;
                            uctxtCustomerMarz.Text = Utility.gGetLedgerNameMerze(strComID, oCom.strSalesRepresentive);
                        }
                        else
                        {
                            uctxtCustomerMarz.Text = Utility.gcEND_OF_LIST;
                        }
                        uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, oCom.strBranchID);
                        strOldBranchName = uctxtBranchName.Text;
                        uctxtNarration.Text = oCom.strNarration;
                        txtCommAmnt.Text = oCom.dblLessAmount.ToString();
                        txtNetTotal.Text = oCom.dblNetAmount.ToString();
                        lblTotalAmount.Text = oCom.dblAmount.ToString();
                        uctxtPreParedBy.Text = oCom.strPreparedby;
                        dteDate.Text = oCom.strTranDate;
                        uctxtLedgerName.Text = oCom.strLedgerName;
                        uctxtLedegerNameMarze.Text = oCom.strMerzeName;
                        
                        lblTotalAmount.Text = oCom.dblAmount.ToString();
                        if (oCom.strApprovedby != "")
                        {
                            txtApprovedby.Text = oCom.strApprovedby;
                        }
                        else
                        {
                            txtApprovedby.Text = "";
                        }
                        if (oCom.strApproveddate != "")
                        {
                            txtApprovedDate.Text = oCom.strApproveddate;
                        }
                        else
                        {
                            txtApprovedDate.Text = "";
                        }
                        if (oCom.intChangeType==0)
                        {
                            chkChange.Checked = false;
                        }
                        else
                        {
                            chkChange.Checked = true;
                        }

                        List<AccBillwise> ooVouList = accms.DisplayCommonInvoice(strComID, tests[0].strVoucherNo).ToList();
                        if (ooVouList.Count > 0)
                        {

                            foreach (AccBillwise oacc in ooVouList)
                            {
                                uctxtLocation.Text = oacc.strGodownsName;
                                DGSalesGrid.Rows.Add();
                                DGSalesGrid[0, introw].Value = oacc.strStockGroupName;
                                DGSalesGrid[1, introw].Value = oacc.strStockItemName;
                                DGSalesGrid[2, introw].Value = Utility.mGetPowerClass(strComID, oacc.strStockItemName);
                                DGSalesGrid[3, introw].Value = Utility.mGetPackSize(strComID, oacc.strStockItemName);
                                DGSalesGrid[4, introw].Value = oacc.dblQnty;
                                DGSalesGrid[5, introw].Value = oacc.dblRate;
                                DGSalesGrid[6, introw].Value = oacc.strPer;
                                DGSalesGrid[7, introw].Value = oacc.dblAmount;  
                                DGSalesGrid[8, introw].Value = oacc.strBillAddless;
                                DGSalesGrid[9, introw].Value = oacc.dblBonusQnty;
                                DGSalesGrid[10, introw].Value = oacc.dblBillNetAmount;
                               
                                DGSalesGrid[11, introw].Value = "Delete";
                                DGSalesGrid[12, introw].Value = oacc.strSubgroup;
                                DGSalesGrid[13, introw].Value = oacc.dblComm;
                                introw += 1;
                            }
                            txtTotalItem.Text = "Total Item :" + introw;
                            DGSalesGrid.AllowUserToAddRows = false;
                        }


                        //calculateTotal();


                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion
        #region "Keyup"
        private void uctxtLedegerNameMarze_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListViewPartyName(ooPartyName, uctxtLedegerNameMarze.Text);
        }

        private void uctxtCustomerMarz_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListViewCustomerName(ooCustomer, uctxtCustomerMarz.Text);
        }
        private void SearchListView(IEnumerable<StockItem> tests, string searchString = "")
        {
            IEnumerable<StockItem> query;

            query = tests;


            if (searchString != "")
            {
                query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }

            ucdgList.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    ucdgList.Rows.Add();
                    ucdgList[0, i].Value = tran.strItemName;
                    ucdgList[1, i].Value = tran.dblClsBalance + " " + tran.strUnit;

                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
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

        private void SearchListViewPartyName(IEnumerable<Invoice> tests, string searchString = "")
        {
            IEnumerable<Invoice> query;
            query = tests;

            if (searchString != "")
            {
                query = tests.Where(x => x.strMereString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }
            DGMr.Rows.Clear();
            int i = 0;
            try
            {
                foreach (Invoice tran in query)
                {
                    DGMr.Rows.Add();
                    DGMr[0, i].Value = tran.strLedgerName;
                    DGMr[1, i].Value = tran.strMereString;
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



        private void SearchListViewCustomerName(IEnumerable<Invoice> tests, string searchString = "")
        {
            IEnumerable<Invoice> query;
            if (tests == null)
            {
                return;
            }

            query = tests;

            if (searchString != "")
            {
                query = tests.Where(x => x.strMereString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }

            DGcustomer.Rows.Clear();
            int i = 0;
            try
            {
                foreach (Invoice tran in query)
                {
                    DGcustomer.Rows.Add();
                    DGcustomer[0, i].Value = tran.strLedgerName;
                    DGcustomer[1, i].Value = tran.strMereString;
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #endregion
        #region "Save"
        private bool ValidateFields()
        {
            if (uctxtOrderNo.Text == "")
            {
                MessageBox.Show("Order Name Cannot be Empty");
                uctxtOrderNo.Focus();
                return false;
            }
            if (uctxtLedegerNameMarze.Text == "")
            {
                MessageBox.Show("Party Name Cannot be Empty");
                uctxtLedegerNameMarze.Focus();
                return false;
            }
            if (Utility.Val(lblTotalAmount.Text) == 0 || Utility.Val(lblTotalAmount.Text) < 0)
            {
                MessageBox.Show("Net Amount be Empty");
                uctxtItemName.Focus();
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "", strGrid = "", strBranchID = "", strRefNo = "", strSubGroup = "";
            int intAppstatus = 0,intChnageType=0;
            double dblCommAmnt = 0, dblCommPer = 0, dblNetAmnt = 0;
            if (ValidateFields() == false)
            {
                return;
            }
            mCalculateDiscount();
           if (chkChange.Checked)
           {
               intChnageType = 1;
           }

            if (Utility.gblnBranch)
            {
                strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            }
            else
            {
                strBranchID = Utility.gstrBranchID;
            }
            if (txtApprovedStatus.Text =="")
            {
                intAppstatus = 1;
            }

            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        for (int introw = 0; introw < DGSalesGrid.Rows.Count; introw++)
                        {
                            
                            if (DGSalesGrid[12, introw].Value.ToString() !="")
                            {
                                strSubGroup = DGSalesGrid[12, introw].Value.ToString();
                            }
                            else
                            {
                                strSubGroup = "";
                            }
                            if (DGSalesGrid[8, introw].Value.ToString() !="")
                            {
                                dblCommAmnt = Convert.ToDouble(DGSalesGrid[8, introw].Value.ToString());
                            }
                            else
                            {
                                dblCommAmnt = 0;
                            }

                            if (DGSalesGrid[10, introw].Value.ToString() != "")
                            {
                                dblNetAmnt = Convert.ToDouble(DGSalesGrid[10, introw].Value.ToString());
                            }
                            else
                            {
                                dblNetAmnt = 0;
                            }
                            if (DGSalesGrid[13, introw].Value.ToString() != "")
                            {
                                dblCommPer = Convert.ToDouble(DGSalesGrid[13, introw].Value.ToString());
                            }
                            else
                            {
                                dblCommPer = 0;
                            }

                            strGrid += DGSalesGrid[0, introw].Value.ToString() + "|" + DGSalesGrid[1, introw].Value.ToString() + "|" + DGSalesGrid[2, introw].Value.ToString() +
                                                    "|" + DGSalesGrid[3, introw].Value.ToString() + "|" + DGSalesGrid[4, introw].Value.ToString() + "|" +
                                                    DGSalesGrid[5, introw].Value.ToString() + "|" + DGSalesGrid[6, introw].Value.ToString() + "|" +
                                                    DGSalesGrid[7, introw].Value.ToString() + "|" + DGSalesGrid[9, introw].Value.ToString() + "|" + strSubGroup + "|" +
                                                    dblCommAmnt + "|" + dblNetAmnt + "|" + dblCommPer + "~";
                        }
                        if (mblnNumbMethod)
                        {
                            strRefNo = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBranchID + Utility.gstrLastNumber(strComID, (int)intVtype);
                        }
                        else
                        {
                            strRefNo = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBranchID + Utility.gstrLastNumber(strComID, (int)intVtype);
                        }
                        i = invms.msaveSalesOrder(strComID, strRefNo, intVtype, dteDate.Value.ToShortDateString(), dteDate.Value.ToShortDateString(),
                                                dteDate.Value.ToString("MMMyy"), uctxtLedgerName.Text, Utility.Val(lblTotalAmount.Text), Utility.gCheckNull(uctxtNarration.Text),
                                                strBranchID, uctxtLocation.Text, 0, uctxtCustomer.Text, "", "",
                                                "", "", "", strGrid, false, 0, "", mblnNumbMethod, Utility.gstrUserName,intAppstatus,
                                                txtApprovedby.Text.ToString(), txtApprovedDate.Text.ToString(), Utility.Val(lblQuantityTotal.Text), 
                                                Utility.Val(txtCommAmnt.Text), Utility.Val(txtNetTotal.Text));

                        if (i == "Inserted...")
                        {
                            btnNew.PerformClick();
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
            else
            {

                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        for (int introw = 0; introw < DGSalesGrid.Rows.Count; introw++)
                        {
                            if (DGSalesGrid[12, introw].Value.ToString() != "")
                            {
                                strSubGroup = DGSalesGrid[12, introw].Value.ToString();
                            }
                            else
                            {
                                strSubGroup = "";
                            }
                            if (DGSalesGrid[8, introw].Value.ToString() != "")
                            {
                                dblCommAmnt = Convert.ToDouble(DGSalesGrid[8, introw].Value.ToString());
                            }
                            else
                            {
                                dblCommAmnt = 0;
                            }

                            if (DGSalesGrid[10, introw].Value.ToString() != "")
                            {
                                dblNetAmnt = Convert.ToDouble(DGSalesGrid[10, introw].Value.ToString());
                            }
                            else
                            {
                                dblNetAmnt = 0;
                            }
                            if (DGSalesGrid[13, introw].Value.ToString() != "")
                            {
                                dblCommPer = Convert.ToDouble(DGSalesGrid[13, introw].Value.ToString());
                            }
                            else
                            {
                                dblCommPer = 0;
                            }
                              strGrid += DGSalesGrid[0, introw].Value.ToString() + "|" + DGSalesGrid[1, introw].Value.ToString() + "|" + DGSalesGrid[2, introw].Value.ToString() +
                                                    "|" + DGSalesGrid[3, introw].Value.ToString() + "|" + DGSalesGrid[4, introw].Value.ToString() + "|" +
                                                    DGSalesGrid[5, introw].Value.ToString() + "|" + DGSalesGrid[6, introw].Value.ToString() + "|" +
                                                    DGSalesGrid[7, introw].Value.ToString() + "|" + DGSalesGrid[9, introw].Value.ToString() + "|" + strSubGroup + "|" +
                                                    dblCommAmnt + "|" + dblNetAmnt + "|" + dblCommPer + "~";
                        }
                        

                        i = invms.mUpdateSalesOrder(strComID, uctxtOldRefNo.Text, intVtype, dteDate.Value.ToShortDateString(), dteDate.Value.ToShortDateString(),
                                                dteDate.Value.ToString("MMMyy"), uctxtLedgerName.Text, Utility.Val(lblTotalAmount.Text), Utility.gCheckNull(uctxtNarration.Text),
                                                strBranchID, uctxtLocation.Text, 0, uctxtCustomer.Text, "", "",
                                                "", "", "", strGrid, false, 0, "",Utility.gstrUserName,Convert.ToInt16(txtApprovedStatus.Text),
                                                txtApprovedby.Text.ToString(), txtApprovedDate.Text.ToString(), Utility.Val(lblQuantityTotal.Text), intChnageType,
                                                Utility.Val(txtCommAmnt.Text), Utility.Val(txtNetTotal.Text));

                        if (i == "Updated...")
                        {
                            btnNew.PerformClick();
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

        }
        #endregion
        #region "Click"
        private void DGSalesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                DGSalesGrid.Rows.RemoveAt(e.RowIndex);
                calculateTotal();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmSalesOrdeNewList objfrm = new frmSalesOrdeNewList();
            objfrm.mintVType = intVtype;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = "Sales Order";
            objfrm.strPreserveSQl = strMysql;
            objfrm.onAddAllButtonClicked = new frmSalesOrdeNewList.AddAllClick(DisplayVoucherList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            //uctxtRefNo.Focus();
        }
        #endregion
        #region "Load"
        private void frmSalesOrderNew_Load(object sender, EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstGroup.Visible = false;
            if (Utility.gblnAccessControl)
            {
                uctxtPreParedBy.Text = Utility.gstrUserName;
            }

            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            //oinv = invms.mGetInvoiceConfig(strComID).ToList();

            mGetConfig();
            mClear();
            uctxtBranchName.Select();
        }
        #endregion 

        private void button1_Click(object sender, EventArgs e)
        {
            //"|||16/11/19|CP-4588-DEEPLAID HOMOEO HALL-DR. DULAL MIAH|1|305|1573926583000|0|798|3~|||16/11/19|CP-4588-DEEPLAID HOMOEO HALL-DR. DULAL MIAH|1|305|1573926583001|0|798|3~"
            //string vstrOrderNo = Utility.gstrLastNumber(strComID, (int)intVtype);
            //string ss1 = "1573926583000|||12|16/11/2019|CP-4588-DEEPLAID HOMOEO HALL-DR. DULAL MIAH|1|305|0|798|3~1573926583001|||12|16/11/2019|CP-4588-DEEPLAID HOMOEO HALL-DR. DULAL MIAH|1|305|0|798|3~";
            //string ss = "1573926583000|Blank Tab|Blank Tab - 100mg (450gm)|380|3|0|Group - A|Pcs|0~1573926583001|Blank Tab|Blank Tab - 100mg (450gm)|380|3|0|Group - A|Pcs|0~";
            //string jj = invms.SaveAPISalesOrder(strComID, ss1, ss);

            //long lngday, lngmm, lngYear;
            //string ss = "16/11/2019";
            ////MessageBox.Show(ss.ToString().Substring(3, 2).PadLeft(2, '0'));
            //lngday = Convert.ToInt32(Utility.Left(ss.ToString(), 2).PadLeft(2, '0'));
            //lngmm = Convert.ToInt32(ss.ToString().Substring(3, 2).PadLeft(2, '0'));
            //lngYear = Convert.ToInt32(Utility.Right(ss.ToString(), 4));
            //DateTime gg =  Convert.ToDateTime(ss);
        }

        private void btndown_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //API.SWAPIClient objW = new API.SWAPIClient();
            //List<JA.Modulecontrolar.API.Summary> values = objW.DisplayApiOrder("0002").ToList();
        }

        private void chkChange_Click(object sender, EventArgs e)
        {
            if (chkChange.Checked)
            {
                DGSalesGrid.Enabled  = true;
               
                uctxtQty.ReadOnly = false;
                uctxtRate.ReadOnly = false;
            }
            else
            {
                DGSalesGrid.Enabled = false;
                uctxtQty.ReadOnly = true;
                uctxtRate.ReadOnly = true;
            }
        }

        

       

      
       




    }



}

