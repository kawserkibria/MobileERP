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
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Net;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSalesChallanAutoProcess : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        SPWOIS objWIS = new SPWOIS();
        private ListBox lstPartyName = new ListBox();
        private string mstrPartyName { get; set; }
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstRefType = new ListBox();
        //public ListBox lstBatch = new ListBox();

        public ListBox lstCustomer = new ListBox();
        public ListBox lstDesignation = new ListBox();
        public ListBox lstTransport = new ListBox();
        public int m_action { get; set; }
        public int intVtype { get; set; }
        private string mySQL { get; set; }
        private bool mblnNumbMethod { get; set; }
        public long lngFormPriv { get; set; }
        private int mintIsPrin { get; set; }
        List<InvoiceConfig> oinv;
        List<Invoice> ooinv;
        List<Invoice> ooPartyName;
        List<StockItem> oogrp;
        List<AccBillwise> ooRefNo;
        private string strComID { get; set; }

        public frmSalesChallanAutoProcess()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User In"
            this.uctxtChallanNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtChallanNo_KeyPress);
            this.uctxtChallanNo.GotFocus += new System.EventHandler(this.uctxtChallanNo_GotFocus);
            this.uctxtChallanNo.KeyDown += new KeyEventHandler(uctxtChallanNo_KeyDown);

            this.uctxtcrtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtcrtQty_KeyPress);
            this.uctxtcrtQty.GotFocus += new System.EventHandler(this.uctxtcrtQty_GotFocus);


            this.uctxtBoxQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBoxQty_KeyPress);
            this.uctxtBoxQty.GotFocus += new System.EventHandler(this.uctxtBoxQty_GotFocus);

            this.uctxtTrNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTrNo_KeyPress);
            this.uctxtTrNo.GotFocus += new System.EventHandler(this.uctxtTrNo_GotFocus);

            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.dteDate_GotFocus);

            this.dteDuedate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDuedate_KeyPress);


            this.uctxtPartyName.KeyDown += new KeyEventHandler(uctxtPartyName_KeyDown);
            this.uctxtPartyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPartyName_KeyPress);
            this.uctxtPartyName.TextChanged += new System.EventHandler(this.uctxtPartyName_TextChanged);

            this.uctxtPartyName.GotFocus += new System.EventHandler(this.uctxtPartyName_GotFocus);
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


            this.uctxtRefType.KeyDown += new KeyEventHandler(uctxtRefType_KeyDown);
            this.uctxtRefType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRefType_KeyPress);
            this.uctxtRefType.TextChanged += new System.EventHandler(this.uctxtRefType_TextChanged);
            this.lstRefType.DoubleClick += new System.EventHandler(this.lstRefType_DoubleClick);
            this.uctxtRefType.GotFocus += new System.EventHandler(this.uctxtRefType_GotFocus);

            this.txtRefTypeNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtRefTypeNew_KeyPress);
            this.txtRefTypeNew.GotFocus += new System.EventHandler(this.txtRefTypeNew_GotFocus);

            //this.txtRefTypeNew.KeyDown += new KeyEventHandler(txtRefTypeNew_KeyDown);
            //this.txtRefTypeNew.LostFocus += new System.EventHandler(this.txtRefTypeNew_LostFocus);

            this.uctxtTransport.KeyDown += new KeyEventHandler(uctxtTransport_KeyDown);
            this.uctxtTransport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTransport_KeyPress);
            this.uctxtTransport.TextChanged += new System.EventHandler(this.uctxtTransport_TextChanged);
            this.lstTransport.DoubleClick += new System.EventHandler(this.lstTransport_DoubleClick);
            this.uctxtTransport.GotFocus += new System.EventHandler(this.uctxtTransport_GotFocus);

            this.uctxtDesignation.KeyDown += new KeyEventHandler(uctxtDesignation_KeyDown);
            this.uctxtDesignation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDesignation_KeyPress);
            this.uctxtDesignation.TextChanged += new System.EventHandler(this.uctxtDesignation_TextChanged);
            this.lstDesignation.DoubleClick += new System.EventHandler(this.lstDesignation_DoubleClick);
            this.uctxtDesignation.GotFocus += new System.EventHandler(this.uctxtDesignation_GotFocus);

            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);
            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);
            this.DGcustomer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGcustomer_CellFormatting);
            this.lstRefTypeNew.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.lstRefTypeNew_CellFormatting);
            this.DGSalesOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGSalesOrder_CellContentClick);
            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            Utility.CreateListBox(lstRefType, pnlMain, uctxtRefType);
            Utility.CreateListBox(lstDesignation, pnlMain, uctxtDesignation);
            Utility.CreateListBox(lstTransport, pnlMain, uctxtTransport);
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
        private void uctxtChallanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                uctxtChallanNo.AppendText((String)rk.GetValue("VoucherNoSC", ""));
                rk.Close();
            }

        }
        private void lstRefTypeNew_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            lstRefTypeNew.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            lstRefTypeNew.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            lstRefTypeNew.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
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

        private void uctxtTrNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtcrtQty.Focus();
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtTrNo, sender, e);
            }
        }
        private void uctxtTrNo_GotFocus(object sender, System.EventArgs e)
        {
            uctxtTrNo.SelectionStart = 0;
            uctxtTrNo.SelectionLength = uctxtTrNo.Text.Length;

            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
        }
        private void uctxtBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtRefType.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBoxQty, sender, e);
            }
        }
        private void uctxtBoxQty_GotFocus(object sender, System.EventArgs e)
        {
            uctxtBoxQty.SelectionStart = 0;
            uctxtBoxQty.SelectionLength = uctxtBoxQty.Text.Length;
            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
        }
        private void uctxtcrtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBoxQty.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtcrtQty, sender, e);
            }
        }
        private void uctxtcrtQty_GotFocus(object sender, System.EventArgs e)
        {
            uctxtcrtQty.SelectionStart = 0;
            uctxtcrtQty.SelectionLength = uctxtcrtQty.Text.Length;

            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
        }

        private void uctxtDesignation_TextChanged(object sender, EventArgs e)
        {
            lstDesignation.SelectedIndex = lstDesignation.FindString(uctxtDesignation.Text);
        }

        private void lstDesignation_DoubleClick(object sender, EventArgs e)
        {
            uctxtDesignation.Text = lstDesignation.Text;
            uctxtTrNo.Focus();
        }
        private void uctxtDesignation_GotFocus(object sender, System.EventArgs e)
        {
            uctxtDesignation.SelectionStart = 0;
            uctxtDesignation.SelectionLength = uctxtDesignation.Text.Length;
            lstDesignation.Visible = true;
            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.ValueMember = "strDesignation";
            lstDesignation.DisplayMember = "strDesignation";
            lstDesignation.DataSource = invms.mFillDesignation(strComID).ToList();
            lstDesignation.SelectedIndex = lstDesignation.FindString(uctxtDesignation.Text);

        }

        private void uctxtDesignation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstDesignation.Items.Count > 0)
                {
                    if (uctxtDesignation.Text != "")
                    {
                        uctxtDesignation.Text = lstDesignation.Text;
                    }
                }
                uctxtTrNo.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtDesignation, sender, e);
            }
        }

        private void uctxtDesignation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstDesignation.SelectedItem != null)
                {
                    lstDesignation.SelectedIndex = lstDesignation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstDesignation.Items.Count - 1 > lstDesignation.SelectedIndex)
                {
                    lstDesignation.SelectedIndex = lstDesignation.SelectedIndex + 1;
                }
            }

        }
        private void uctxtTransport_TextChanged(object sender, EventArgs e)
        {
            lstTransport.SelectedIndex = lstTransport.FindString(uctxtTransport.Text);
        }

        private void lstTransport_DoubleClick(object sender, EventArgs e)
        {
            uctxtTransport.Text = lstTransport.Text;
            uctxtDesignation.Focus();
        }
        private void uctxtTransport_GotFocus(object sender, System.EventArgs e)
        {
            uctxtTransport.SelectionStart = 0;
            uctxtTransport.SelectionLength = uctxtTransport.Text.Length;

            lstBranchName.Visible = false;
            lstPartyName.Visible = false;
            lstTransport.Visible = true;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstDesignation.Visible = false;
            lstTransport.ValueMember = "strTransPort";
            lstTransport.DisplayMember = "strTransPort";
            lstTransport.DataSource = invms.mFillTransport(strComID).ToList();
            lstTransport.SelectedIndex = lstTransport.FindString(uctxtTransport.Text);
        }

        private void uctxtTransport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstTransport.Items.Count > 0)
                {
                    if (uctxtTransport.Text != "")
                    {
                        uctxtTransport.Text = lstTransport.Text;
                    }

                }
                uctxtDesignation.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtTransport, sender, e);
            }
        }

        private void uctxtTransport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstTransport.SelectedItem != null)
                {
                    lstTransport.SelectedIndex = lstTransport.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstTransport.Items.Count - 1 > lstTransport.SelectedIndex)
                {
                    lstTransport.SelectedIndex = lstTransport.SelectedIndex + 1;
                }
            }

        }
        private void uctxtCustomer_TextChanged(object sender, EventArgs e)
        {
            if (uctxtCustomer.Text == "")
            {
                uctxtCustomerCode.Text = "";
                uctxtHomeohall.Text = "";
                uctxtCustomerAddress.Text = "";
            }
        }

        private void lstCustomer_DoubleClick(object sender, EventArgs e)
        {
            uctxtCustomer.Text = lstCustomer.Text;
            uctxtTransport.Focus();
        }
        //private void DGcustomer_DoubleClick(object sender, EventArgs e)
        //{

        //    if (DGMr.SelectedRows.Count > 0)
        //    {
        //        int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
        //        uctxtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
        //        uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
        //        uctxtHomeohall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
        //        uctxtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
        //        DGcustomer.Visible = false;
        //        uctxtLocation.Focus();


        //    }
        //}
        //private void DGcustomer_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Return)
        //    {
        //        //uctxtPartyName.Text = Utility.GetDgValue(DGMr, uctxtPartyName, 0);
        //        int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
        //        uctxtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
        //        uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
        //        uctxtHomeohall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
        //        uctxtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
        //        DGcustomer.Visible = false;
        //        uctxtLocation.Focus();
        //    }
        //}
        //private void uctxtCustomer_GotFocus(object sender, System.EventArgs e)
        //{
        //    lstCustomer.Visible = true;
        //    lstPartyName.Visible = false;
        //    lstBatch.Visible = false;
        //    lstBranchName.Visible = false;
        //    lstLocation.Visible = false;
        //    lstRefType.Visible = false;
        //    lstTransport.Visible = false;
        //    lstDesignation.Visible = false;
        //    //  //lstRefTypeNew.Visible = false;;
        //    //ucdgList.Visible = false;
        //    //DGcustomer.Visible = true;
        //    DGMr.Visible = false;
        //    //lstCustomer.SelectedIndex = lstCustomer.FindString(uctxtCustomer.Text);
        //    if (uctxtPartyName.Text != "")
        //    {
        //        mloadCustomer();
        //        //lstCustomer.Items.Add(oinv.strSalesRepresentative);

        //        //lstCustomer.DisplayMember = "strSalesRepresentative";
        //        //lstCustomer.ValueMember = "strSalesRepresentative";
        //        //lstCustomer.DataSource = ooinv.ToList();

        //    }
        //}
        //private void mloadCustomer()
        //{
        //    int introw = 0;
        //    try
        //    {
        //        DGcustomer.Rows.Clear();

        //        ooinv = invms.mFillSalesRepFromMPoNew1(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP, uctxtPartyName.Text).ToList();

        //        if (ooinv.Count > 0)
        //        {

        //            foreach (Invoice ogrp in ooinv)
        //            {
        //                DGcustomer.Rows.Add();
        //                DGcustomer[0, introw].Value = ogrp.strTeritorryCode;
        //                DGcustomer[1, introw].Value = ogrp.strLedgerName;
        //                DGcustomer[2, introw].Value = ogrp.strTeritorryName;

        //                DGcustomer[3, introw].Value = ogrp.strMereString;
        //                //if (introw % 2 == 0)
        //                //{
        //                //    DGcustomer.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
        //                //}
        //                //else
        //                //{
        //                //    DGcustomer.Rows[introw].DefaultCellStyle.BackColor = Color.White;
        //                //}
        //                introw += 1;
        //            }

        //            DGcustomer.AllowUserToAddRows = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}


        //private void uctxtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //if (e.KeyChar == (char)Keys.Return)
        //    //{
        //    //    if (lstCustomer.Items.Count > 0)
        //    //    {
        //    //        uctxtCustomer.Text = lstCustomer.Text;
        //    //    }
        //    //    uctxtTransport.Focus();
        //    //}
        //    //if (e.KeyChar == (char)Keys.Back)
        //    //{
        //    //    PriorSetFocusText(uctxtCustomer, sender, e);
        //    //}
        //    if (e.KeyChar == (char)Keys.Return)
        //    {
        //        if (uctxtCustomer.Text == "" || uctxtCustomer.Text == Utility.gcEND_OF_LIST)
        //        {
        //            //txtItemCode.Text = "";
        //            uctxtCustomer.Text = "";
        //            uctxtCustomer.Text = Utility.gcEND_OF_LIST;
        //            DGcustomer.Visible = false;
        //            uctxtLocation.Focus();

        //            return;
        //        }


        //        if (uctxtItemName.Text != "")
        //        {
        //            DGcustomer.Focus();
        //            if (DGcustomer.Rows.Count > 0)
        //            {
        //                int i = 0;
        //                uctxtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
        //                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
        //                uctxtHomeohall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
        //                uctxtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
        //                DGcustomer.Visible = false;
        //                uctxtLocation.Focus();
        //            }
        //        }
        //        else
        //        {
        //            int i = 0;

        //            uctxtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
        //            uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
        //            uctxtHomeohall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
        //            uctxtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
        //            DGcustomer.Visible = false;
        //            uctxtLocation.Focus();
        //        }
        //    }
        //    if (e.KeyChar == (char)Keys.Back)
        //    {
        //        PriorSetFocusText(uctxtCustomer, sender, e);
        //    }
        //}

        //private void uctxtCustomer_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //if (e.KeyCode == Keys.Up)
        //    //{
        //    //    if (lstCustomer.SelectedItem != null)
        //    //    {
        //    //        lstCustomer.SelectedIndex = lstCustomer.SelectedIndex - 1;
        //    //    }
        //    //}
        //    //if (e.KeyCode == Keys.Down)
        //    //{
        //    //    if (lstCustomer.Items.Count - 1 > lstCustomer.SelectedIndex)
        //    //    {
        //    //        lstCustomer.SelectedIndex = lstCustomer.SelectedIndex + 1;
        //    //    }
        //    //}
        //    DGcustomer.Visible = true;
        //    //txtFoodCode.Text = "";
        //    //txtFoodName.Text = "";
        //    if (e.KeyCode == Keys.Up)
        //    {
        //        DGcustomer.Focus();
        //    }
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        DGcustomer.Focus();
        //    }

        //    DGcustomer.Top = uctxtCustomer.Top + 25;
        //    DGcustomer.Left = uctxtCustomer.Left;
        //    DGcustomer.Width = uctxtCustomer.Width;
        //    DGcustomer.Height = 200;
        //    //ucdgList.Size = new Size(546, 222);
        //    DGcustomer.BringToFront();
        //    DGcustomer.AllowUserToAddRows = false;
        //    //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
        //    //ucdgList.Focus();
        //    return;

        //}




        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
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
        private void dteDuedate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtPartyName.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                uctxtPartyName.Focus();
            }
        }

        private void uctxtChallanNo_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
        }
        private void dteDate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
        }
        private void dteDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteDuedate.Value = dteDate.Value.AddDays(3);
                dteDuedate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                uctxtChallanNo.Focus();
            }
        }
        private void uctxtChallanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 1)
                {
                    string strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
                    string strRefNo = "SC" + strBarchID + uctxtChallanNo.Text;
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_COMPANY_VOUCHER", "COMP_REF_NO", strRefNo);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtChallanNo.Focus();
                        return;
                    }
                }
                dteDate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtChallanNo, sender, e);
            }
        }
        private void uctxtPartyName_TextChanged(object sender, EventArgs e)
        {
            if (uctxtPartyName.Text == "")
            {
                uctxtTeritoryCode.Text = "";
                uctxtTeritorryName.Text = "";
                uctxtCustomer.Text = "";
                uctxtHomeohall.Text = "";
                uctxtCustomerAddress.Text = "";
                uctxtCustomerCode.Text = "";

            }
        }


        private void uctxtPartyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                DGSalesOrder.Rows.Clear();
                if (uctxtPartyName.Text == "")
                {
                    uctxtPartyName.Text = "";
                    if (DGMr.Rows.Count > 0)
                    {
                        DGMr.Visible = true;
                    }
                    DGMr.Visible = false;
                    return;
                }


                if (uctxtPartyName.Text != "")
                {
                    DGMr.Focus();
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        uctxtPartyName.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                        DGMr.Visible = false;
                        //uctxtCustomer.Text = "End of List";
                        uctxtLocation.Focus();
                    }
                }
                else
                {
                    int i = 0;
                    uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    uctxtPartyName.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                    DGMr.Visible = false;
                    uctxtLocation.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtPartyName, sender, e);
            }
        }
        private void uctxtPartyName_KeyDown(object sender, KeyEventArgs e)
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

            DGMr.Top = uctxtPartyName.Top + 25;
            DGMr.Left = uctxtPartyName.Left;
            DGMr.Width = uctxtPartyName.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            return;

        }

        private void uctxtPartyName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = true;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            DGcustomer.Visible = false;
            mloadParty(lstBranchName.SelectedValue.ToString());
        }
        private void DGMr_DoubleClick(object sender, EventArgs e)
        {
            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                uctxtPartyName.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                DGMr.Visible = false;
                uctxtCustomer.Text = "End of List";
                if (m_action == 1)
                {
                    DGSalesOrder.Rows.Clear();
                }
                else
                {
                    if (mstrPartyName.Trim() != uctxtPartyName.Text.Trim())
                    {
                        DGSalesOrder.Rows.Clear();
                    }
                }
                uctxtLocation.Focus();


            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                uctxtPartyName.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                DGMr.Visible = false;
                uctxtCustomer.Text = "End of List";
                DGSalesOrder.Rows.Clear();
                uctxtLocation.Focus();
            }
        }

        private void txtRefTypeNew_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;

        }


        private void txtRefTypeNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strBillKey, strRefNo, strDate;
            if (e.KeyChar == (char)Keys.Return)
            {
                try
                {
                    if (txtRefTypeNew.Text == "")
                    {
                        txtRefTypeNew.Text = "";
                        uctxtNarration.Focus();
                        return;
                    }


                    if (txtRefTypeNew.Text != "")
                    {
                        lstRefTypeNew.Focus();
                        if (lstRefTypeNew.Rows.Count > 0)
                        {
                            int i = 0;
                            foreach (DataGridViewRow row in lstRefTypeNew.SelectedRows)
                            {
                                i = Convert.ToInt16(row.Index);
                            }

                            txtRefTypeNew.Text = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                            strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                            strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                            strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                            DisplayReferance(strBillKey, strRefNo, strDate);
                            txtRefTypeNew.Focus();
                            lstRefTypeNew.Rows.RemoveAt(i);
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (DataGridViewRow row in lstRefTypeNew.SelectedRows)
                        {
                            i = Convert.ToInt16(row.Index);
                        }

                        txtRefTypeNew.Text = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                        strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                        strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                        strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                        DisplayReferance(strBillKey, strRefNo, strDate);
                        txtRefTypeNew.Focus();
                        lstRefTypeNew.Rows.RemoveAt(i);
                    }


                }

                catch (Exception ex)
                {

                }
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtRefTypeNew, sender, e);
            }
        }


        private void uctxtRefType_TextChanged(object sender, EventArgs e)
        {
            lstRefType.SelectedIndex = lstRefType.FindString(uctxtRefType.Text);
        }

        private void lstRefType_DoubleClick(object sender, EventArgs e)
        {
            DGSalesOrder.Rows.Clear();
            lstRefTypeNew.Rows.Clear();
            uctxtRefType.Text = lstRefType.Text;
            if (lstRefType.Items.Count > 0)
            {
                uctxtRefType.Text = lstRefType.Text;
            }
            if (uctxtRefType.Text != Utility.gcEND_OF_LIST)
            {
                long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                if (uctxtLocation.Text != "")
                {
                    mLoadAllItemOrder(uctxtTeritoryCode.Text, lngRefType, dteDate.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), uctxtLocation.Text, "");
                }
                lstRefType.Visible = false;
                txtRefTypeNew.Focus();
            }
        }

        private void uctxtRefType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                DGSalesOrder.Rows.Clear();
                lstRefTypeNew.Rows.Clear();
                if (lstRefType.Items.Count > 0)
                {
                    uctxtRefType.Text = lstRefType.Text;
                }
                if (uctxtRefType.Text != Utility.gcEND_OF_LIST)
                {
                    long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                    if (uctxtLocation.Text != "")
                    {
                        mLoadAllItemOrder(uctxtTeritoryCode.Text, lngRefType, dteDate.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), uctxtLocation.Text, "");
                    }
                    lstRefType.Visible = false;
                    txtRefTypeNew.Focus();
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtRefType, sender, e);
            }
        }
        private void DisplayReferanceNew(string strBillKey, string strRefNo, string strDate, DataGridView dg)
        {
            try
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
                    if (strBillKey == strDown.ToString())
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
                    dg[0, selRaw].Value = strBillKey;
                    dg[1, selRaw].Value = strRefNo;
                    dg[2, selRaw].Value = strDate;
                    if (uctxtRefType.Text == "Sample Class")
                    {
                        uctxtNarration.Text = strRefNo;
                    }
                    else
                    {
                        uctxtNarration.Text = "";
                    }
                    dg[3, selRaw].Value = "Delete";
                    dg.AllowUserToAddRows = false;
                    txtRefTypeNew.Text = "";
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void DisplayReferance(string strBillKey, string strRefNo, string strDate)
        {
            try
            {


                int selRaw;

                string strDown = "";
                Boolean blngCheck = false;
                for (int j = 0; j < DGSalesOrder.RowCount; j++)
                {
                    if (DGSalesOrder[0, j].Value != null)
                    {
                        strDown = DGSalesOrder[0, j].Value.ToString();
                    }
                    if (strBillKey == strDown.ToString())
                    {
                        blngCheck = true;
                    }

                }
                if (blngCheck == false)
                {

                    DGSalesOrder.AllowUserToAddRows = true;
                    selRaw = Convert.ToInt16(DGSalesOrder.RowCount.ToString());
                    selRaw = selRaw - 1;
                    DGSalesOrder.Rows.Add();
                    DGSalesOrder[0, selRaw].Value = strBillKey;
                    DGSalesOrder[1, selRaw].Value = strRefNo;
                    DGSalesOrder[2, selRaw].Value = strDate;
                    DGSalesOrder[3, selRaw].Value = "Delete";
                    DGSalesOrder.AllowUserToAddRows = false;
                    txtRefTypeNew.Text = "";

                }

            }
            catch (Exception ex)
            {

            }
        }


        private void uctxtRefType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstRefType.SelectedItem != null)
                {
                    lstRefType.SelectedIndex = lstRefType.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstRefType.Items.Count - 1 > lstRefType.SelectedIndex)
                {
                    lstRefType.SelectedIndex = lstRefType.SelectedIndex + 1;
                }
            }

        }

        private void uctxtRefType_GotFocus(object sender, System.EventArgs e)
        {
            uctxtRefType.SelectionStart = 0;
            uctxtRefType.SelectionLength = uctxtRefType.Text.Length;

            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = true;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;

            lstRefType.SelectedIndex = lstRefType.FindString(uctxtRefType.Text);
        }
        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;

            uctxtTransport.Focus();
        }

        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;

                }
                uctxtTransport.Focus();
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

            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = true;
            lstRefType.Visible = false;

            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            //lstRefTypeNew.Visible = false;;
            //ucdgList.Visible = false;

            if (uctxtBranchName.Text != "")
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                //lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, 0).ToList();
                lstLocation.DataSource = invms.gLoadInvoiceLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, 0).ToList();
            }
            if (lstBranchName.SelectedValue == "0001")
            {
                uctxtLocation.Text = lstLocation.Text;
            }
            else
            {
                uctxtLocation.Text = lstLocation.Text;
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
            string strCheckName = Utility.mGetCheckLedgerNamePresent(strComID, "ACC_LEDGER", "LEDGER_NAME", "BRANCH_ID", uctxtTeritoryCode.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text));
            {
                if (strCheckName == "")
                {
                    uctxtPartyName.Text = "";
                    uctxtTeritorryName.Text = "";
                    uctxtTeritoryCode.Text = "";
                    uctxtCustomer.Text = "";
                    uctxtHomeohall.Text = "";
                    uctxtCustomerAddress.Text = "";
                }
            }
            //mloadParty(lstBranchName.SelectedValue.ToString());
            if (lstBranchName.SelectedValue.ToString().Trim() == "0001")
            {
                uctxtLocation.Text = "Main Location";
            }
            else
            {
                uctxtLocation.Text = "";
            }
            uctxtChallanNo.Focus();
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }
                string strCheckName = Utility.mGetCheckLedgerNamePresent(strComID, "ACC_LEDGER", "LEDGER_NAME", "BRANCH_ID", uctxtTeritoryCode.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text));
                {
                    if (strCheckName == "")
                    {
                        uctxtPartyName.Text = "";
                        uctxtTeritorryName.Text = "";
                        uctxtTeritoryCode.Text = "";
                        uctxtCustomer.Text = "";
                        uctxtHomeohall.Text = "";
                        uctxtCustomerAddress.Text = "";
                    }
                }


                //mloadParty(lstBranchName.SelectedValue.ToString());
                if (lstBranchName.SelectedValue.ToString().Trim() == "0001")
                {
                    uctxtLocation.Text = "Main Location";
                }
                else
                {
                    uctxtLocation.Text = "";
                }
                uctxtChallanNo.Focus();
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
            lstPartyName.Visible = false;
            lstBranchName.Visible = true;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }


        #endregion
        #region "Getconfig"
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, intVtype).ToList();
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
        #region "Load Party"
        private void mloadParty(string strBranchID)
        {
            int introw = 0;
            DGMr.Rows.Clear();
            try
            {
                ooPartyName = invms.mfillPartyNameNew(strComID, strBranchID, Utility.gblnAccessControl, Utility.gstrUserName, 0, "","").ToList();

                if (ooPartyName.Count > 0)
                {

                    foreach (Invoice ogrp in ooPartyName)
                    {
                        DGMr.Rows.Add();
                        DGMr[0, introw].Value = ogrp.strTeritorryCode;
                        DGMr[1, introw].Value = ogrp.strTeritorryName;
                        DGMr[2, introw].Value = ogrp.strLedgerName;
                        DGMr[3, introw].Value = ogrp.strMereString;

                        introw += 1;
                    }

                    DGMr.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "Load"
        private void frmSalesChallanAutoProcess_Load(object sender, EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;

            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;

            mGetConfig();

            mClear();
            LoadDefaultValue();
            oinv = invms.mGetInvoiceConfig(strComID).ToList();


            this.lstRefTypeNew.DefaultCellStyle.Font = new Font("verdana", 10F);
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Bill Key", "Bill. Key", 350, false, DataGridViewContentAlignment.TopLeft, true));
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Ref. No", "Ref. No", 150, true, DataGridViewContentAlignment.TopLeft, true));
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 100, true, DataGridViewContentAlignment.TopLeft, true));



        }
        #endregion
        #region "Item Order"
        private void mLoadAllItemOrder(string strPartyname, long lngVtype, string strDate, string strBranchID, string strLocation, string strRefNo)
        {
            int introw = 0;

            lstRefTypeNew.Rows.Clear();
            if (lngVtype != (int)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
            {
                ooRefNo = accms.gFillPreRefNo(strComID, strPartyname, lngVtype, strDate, strBranchID, strLocation, strRefNo, 0).ToList();
            }
            else
            {
                ooRefNo = accms.gFillPreSampleClass(strComID).ToList();
            }
            if (ooRefNo.Count > 0)
            {

                foreach (AccBillwise ogrp in ooRefNo)
                {

                    lstRefTypeNew.Rows.Add();

                    lstRefTypeNew[0, introw].Value = ogrp.strBillKey;
                    if (lngVtype != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                    {
                        lstRefTypeNew[1, introw].Value = Utility.Mid(ogrp.strRefNo, 6, ogrp.strRefNo.Length - 6);
                    }
                    else
                    {
                        lstRefTypeNew[1, introw].Value = ogrp.strRefNo;
                    }
                    lstRefTypeNew[2, introw].Value = ogrp.strDate;


                    introw += 1;
                }
                lstRefTypeNew.AllowUserToAddRows = false;
            }
        }
        #endregion
        #region "Default Value"
        private void LoadDefaultValue()
        {

            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
                {
                  //{Utility.gcEND_OF_LIST, 1},
                  //{gobjVoucherName.VoucherName.GetVoucherName((long)Utility.VOUCHER_TYPE.vtSALES_ORDER), 2},
                  {gobjVoucherName.VoucherName.GetVoucherName((long)Utility.VOUCHER_TYPE.vtSALES_INVOICE), 3},
                   {gobjVoucherName.VoucherName.GetVoucherName((long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS), 4}
                };
            lstRefType.DisplayMember = "Key";
            lstRefType.ValueMember = "Value";
            lstRefType.DataSource = new BindingSource(userCache, null);


        }
        #endregion
        #region "Validation Field"
        //private bool ValidateFields(string strItemName, string strInvoiceNo, double dblCurrentQTY)
        //{
        //    double dblClosingQTY = 0;
        //    string strNegetiveItem = "";
        //    int intCheckNegetive = 0;
        //    string strSQL = "", strRefNo = "", strBranchId = "", strBillKey = "", strUOm = "";
        //    SqlCommand cmdInsert = new SqlCommand();
        //    SqlDataReader dr;
        //    double  dblDilutionRate = 0;
        //    string strYesno = "Y";

        //    if (uctxtPartyName.Text == "")
        //    {
        //        MessageBox.Show("Cannot Empty");
        //        uctxtPartyName.Focus();
        //        return false;
        //    }
        //    if (uctxtChallanNo.Text == "")
        //    {
        //        MessageBox.Show("Cannot Empty");
        //        uctxtChallanNo.Focus();
        //        return false;
        //    }
        //    if (uctxtBranchName.Text == "")
        //    {
        //        MessageBox.Show("Cannot Empty");
        //        uctxtBranchName.Focus();
        //        return false;
        //    }


        //    long lngDate = Convert.ToInt64(dteDate.Value.ToString("yyyyMMdd"));
        //    long lngFiscalYearfrom = Convert.ToInt64(Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString("yyyyMMdd"));
        //    long lngFiscalYearTo = Convert.ToInt64(Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString("yyyyMMdd"));

        //    if (lngDate < lngFiscalYearfrom)
        //    {
        //        MessageBox.Show("Invalid Date, Date Can't less then Financial Year");
        //        return false;
        //    }
        //    if (lngDate > lngFiscalYearTo)
        //    {
        //        MessageBox.Show("Invalid Date, Date Can't less then Financial Year");
        //        return false;
        //    }



        //    if (oinv[0].mlngBlockNegativeStock > 0)
        //    {

        //        if (uctxtRefType.Text == "Sample Class")
        //        {
        //            //dblClosingQTY = Utility.gdblClosingStockSales(strComID, strItemName, uctxtLocation.Text, dteDate.Text);
        //            dblClosingQTY = Utility.gdblClosingStockSales(strComID, strItemName, lstBranchName.SelectedValue.ToString(), "", uctxtLocation.Text);
        //        }
        //        else
        //        {
        //            dblClosingQTY = Utility.gdblClosingStock(strComID, strItemName, uctxtLocation.Text, dteDate.Text);
        //        }
        //        //**********************
        //        if ((dblClosingQTY) - dblCurrentQTY < 0)
        //        {

        //            strBranchId = lstBranchName.SelectedValue.ToString();
        //            strUOm = Utility.gGetBaseUOM(strComID, strItemName);
        //            string connstring = Utility.SQLConnstringComSwitch(strComID);
        //            using (SqlConnection gcnMain = new SqlConnection(connstring))
        //            {
        //                if (gcnMain.State == ConnectionState.Open)
        //                {
        //                    gcnMain.Close();
        //                }
        //                gcnMain.Open();
        //                cmdInsert.Connection = gcnMain;

        //                strSQL = "SELECT ISNULL(INV_TRAN_RATE,0) AS BILL_RATE ";
        //                strSQL = strSQL + "FROM INV_STOCKGROUP INNER JOIN ";
        //                strSQL = strSQL + "INV_STOCKITEM ON INV_STOCKGROUP.STOCKGROUP_NAME = INV_STOCKITEM.STOCKGROUP_NAME INNER JOIN ";
        //                strSQL = strSQL + "INV_TRAN ON INV_STOCKITEM.STOCKITEM_NAME = INV_TRAN.STOCKITEM_NAME ";
        //                //AND INV_STOCKGROUP.FG_STATUS=1 ";
        //                strSQL = strSQL + "AND INV_TRAN.INV_REF_NO='" + strInvoiceNo + "' ";
        //                strSQL = strSQL + "AND INV_TRAN.STOCKITEM_NAME ='" + strItemName.Replace("'", "''") + "' ";
        //                cmdInsert.CommandText = strSQL;
        //                dr = cmdInsert.ExecuteReader();
        //                if (dr.Read())
        //                {
        //                    dblDilutionRate = Math.Abs(Convert.ToDouble(dr["BILL_RATE"]));
        //                }
        //                dr.Close();
        //                if (dblDilutionRate > 0)
        //                {



        //                    strRefNo = gobjVoucherName.VoucherName.GetVoucherString(25) + strBranchId + Utility.gstrLastNumber(strComID, 25);
        //                    SqlTransaction myTrans;
        //                    myTrans = gcnMain.BeginTransaction();
        //                    cmdInsert.Transaction = myTrans;
        //                    strSQL = "INSERT INTO INV_MASTER(INV_REF_NO,INV_VOUCHER_TYPE,INV_DATE,BRANCH_ID) ";
        //                    strSQL = strSQL + "values(";
        //                    strSQL = strSQL + "'" + strRefNo + "' ";
        //                    strSQL = strSQL + "," + 25 + " ";
        //                    strSQL = strSQL + "," + Utility.cvtSQLDateString(dteDate.Text) + " ";
        //                    strSQL = strSQL + ",'" + strBranchId + "'";
        //                    strSQL = strSQL + ")";
        //                    cmdInsert.CommandText = strSQL;
        //                    cmdInsert.ExecuteNonQuery();

        //                    strBillKey = strRefNo + "0001";
        //                    if (dblClosingQTY == 0)
        //                    {
        //                        strSQL = VoucherSW.mInsertTranInward(strBillKey, 1, strRefNo, strItemName, 25, dteDate.Text,
        //                                                                Math.Abs(dblCurrentQTY), dblDilutionRate, uctxtLocation.Text, (Math.Abs(dblCurrentQTY) * dblDilutionRate), "I",
        //                                                                strBranchId, "", "", strUOm, "", "", 0, 0, "Dilution Section");
        //                        cmdInsert.CommandText = strSQL;
        //                        cmdInsert.ExecuteNonQuery();
        //                    }
        //                    else
        //                    {
        //                        if (dblClosingQTY < 0)
        //                        {
        //                            strSQL = VoucherSW.mInsertTranInward(strBillKey, 1, strRefNo, strItemName, 25, dteDate.Text,
        //                                                                    Math.Abs(dblClosingQTY), dblDilutionRate, uctxtLocation.Text, (Math.Abs(dblClosingQTY) * dblDilutionRate), "I",
        //                                                                    strBranchId, "", "", strUOm, "", "", 0, 0, "Dilution Section");
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();
        //                        }
        //                    }

        //                    strSQL = VoucherSW.gIncreaseVoucher(25);
        //                    cmdInsert.CommandText = strSQL;
        //                    cmdInsert.ExecuteNonQuery();
        //                    cmdInsert.Transaction.Commit();
        //                    dblClosingQTY = dblCurrentQTY;
        //                    strYesno = "N";
        //                }

        //            }
        //        }
        //        //**********
        //        if (strYesno == "Y")
        //        {
        //            if (uctxtRefType.Text == "Sample Class")
        //            {
        //                //dblClosingQTY = Utility.gdblClosingStockSales(strComID, strItemName, uctxtLocation.Text, dteDate.Text);
        //                dblClosingQTY = Utility.gdblClosingStockSales(strComID, strItemName, lstBranchName.SelectedValue.ToString(), "", uctxtLocation.Text);
        //            }
        //            else
        //            {
        //                dblClosingQTY = Utility.gdblClosingStock(strComID, strItemName, uctxtLocation.Text, dteDate.Text);
        //            }
        //            //if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
        //            //{
        //            //    dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
        //            //}
        //            //dblCurrentQTY = Utility.Val(DGSalesGrid[2, i].Value.ToString());
        //            if ((dblClosingQTY) - dblCurrentQTY < 0)
        //            {
        //                strNegetiveItem = strNegetiveItem + Environment.NewLine + strItemName + "Invoice No: " + strInvoiceNo + " (Voucher Qty: " + dblCurrentQTY + " Closing Qty : " + dblClosingQTY + ")";
        //                intCheckNegetive = 1;
        //                dblClosingQTY = 0;
        //                //    }
        //                //}
        //                dblClosingQTY = 0;
        //            }
        //        }
        //    }
        //    if (intCheckNegetive > 0)
        //    {
        //        MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
        //        return false;
        //    }


        //    return true;
        //}

        private bool ValidateFields(string strItemName, string strInvoiceNo, double dblCurrentQTY)
        {
            double dblClosingQTY = 0;
            string strNegetiveItem = "";
            int intCheckNegetive = 0;

            SqlCommand cmdInsert = new SqlCommand();
            SqlDataReader dr;


            //if (uctxtPartyName.Text == "")
            //{
            //    MessageBox.Show("Cannot Empty");
            //    uctxtPartyName.Focus();
            //    return false;
            //}
            //if (uctxtChallanNo.Text == "")
            //{
            //    MessageBox.Show("Cannot Empty");
            //    uctxtChallanNo.Focus();
            //    return false;
            //}
            //if (uctxtBranchName.Text == "")
            //{
            //    MessageBox.Show("Cannot Empty");
            //    uctxtBranchName.Focus();
            //    return false;
            //}


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

            if (oinv[0].mlngBlockNegativeStock > 0)
            {

                if (uctxtRefType.Text == "Sample Class")
                {
                    //dblClosingQTY = Utility.gdblClosingStockSales(strComID, strItemName, uctxtLocation.Text, dteDate.Text);
                    dblClosingQTY = Utility.gdblClosingStockSales(strComID, strItemName, lstBranchName.SelectedValue.ToString(), "", uctxtLocation.Text);
                }
                else
                {
                    dblClosingQTY = Utility.gdblClosingStock(strComID, strItemName, uctxtLocation.Text, dteDate.Text);
                }
                //**********************
                if ((dblClosingQTY) - dblCurrentQTY < 0)
                {
                    if ((dblClosingQTY) - dblCurrentQTY < 0)
                    {
                        strNegetiveItem = strNegetiveItem + Environment.NewLine + strItemName + "Invoice No: " + strInvoiceNo + " (Voucher Qty: " + dblCurrentQTY + " Closing Qty : " + dblClosingQTY + ")";
                        intCheckNegetive = 1;
                        dblClosingQTY = 0;
                        //    }
                        //}
                        dblClosingQTY = 0;
                    }
                }
            }
            if (intCheckNegetive > 0)
            {
                MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                return false;
            }


            return true;
        }
        #endregion

        #region "Clear"
        private void mClear()
        {
            uctxtPartyName.Text = "";
            txtNoofOrder.Text = "";
            uctxtNarration.Text = "";
            uctxtDesignation.Text = "";
            uctxtTransport.Text = "";
            uctxtBoxQty.Text = "";
            uctxtCustomer.Text = "";
            lblOrder.Text = "";
            DGSalesOrder.Rows.Clear();
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod == true)
            {
                uctxtChallanNo.Text = Utility.gstrLastNumber(strComID, intVtype);
                uctxtChallanNo.ReadOnly = true;
                uctxtBranchName.Focus();
                uctxtBranchName.Select();
            }
            else
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
                {
                    uctxtChallanNo.Text = "";
                    //uctxtChallanNo.Text = Interaction.GetSetting(Application.ExecutablePath, "frmSalesChallan", "VoucherNoSC");
                    uctxtChallanNo.AppendText((String)rk.GetValue("VoucherNoSC", ""));
                    rk.Close();
                }
                else
                {
                    uctxtChallanNo.Text = "";
                    uctxtChallanNo.AppendText((String)rk.GetValue("VoucherNoPR", ""));
                    rk.Close();
                }
                uctxtChallanNo.Text = Utility.gobjNextNumber(uctxtChallanNo.Text);
                uctxtChallanNo.ReadOnly = false;
                uctxtBranchName.Focus();
                uctxtBranchName.Select();
            }
            //uctxtPartyName.Focus();
        }
        #endregion
        #region "Click"

        #region "SMS"
        public string SendSMS(string phno, string msg)
        {

            string url = "https://gpcmp.grameenphone.com/gpcmpapi/messageplatform/controller.home?username=DeeplaidADMINN&password=Deeplaid_2000&apicode=1&msisdn=" + phno + "&countrycode=880&cli=DPL%20STORE&messagetype=1&message=" + msg + "&messageid=0%20210";

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {

                response.Close();
                return "Sending Success...";
            }
            else
            {
                //EventLog.WriteEntry("ERROR in Sending Message of Mobile No: " + phno, "" + "Trace", EventLogEntryType.Error, 121, short.MaxValue);
                //Application.Exit();
                return "Sending Failed...";

            }
        }
        #endregion

        #endregion



        private void txtRefTypeNew_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string searchString = "";
                if (txtRefTypeNew.Text != "")
                {
                    searchString = txtRefTypeNew.Text.Trim();
                    if (searchString == string.Empty || searchString.Length > 20)
                    {
                        //MessageBox.Show("Enter Valid Consumer Number..!");
                    }
                    else
                    {
                        foreach (DataGridViewRow row in lstRefTypeNew.Rows)
                        {
                            if (row.Cells[1].Value.ToString().Contains(searchString))
                            {
                                lstRefTypeNew.ClearSelection();
                                lstRefTypeNew.CurrentRow.Selected = true;
                                lstRefTypeNew.Rows[row.Index].Selected = true;
                                int index = row.Index;
                                lstRefTypeNew.FirstDisplayedScrollingRowIndex = index;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void SearchListViewRefNo(IEnumerable<AccBillwise> tests, string searchString = "")
        {
            IEnumerable<AccBillwise> query;

            query = tests;
            query = tests.Where(x => x.strRefNo.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            lstRefTypeNew.Rows.Clear();
            int i = 0;
            try
            {
                long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                foreach (AccBillwise tran in query)
                {
                    lstRefTypeNew.Rows.Add();

                    lstRefTypeNew[0, i].Value = tran.strBillKey;
                    if (lngRefType != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                    {
                        lstRefTypeNew[1, i].Value = Utility.Mid(tran.strRefNo, 6, tran.strRefNo.Length - 6);
                    }
                    else
                    {
                        lstRefTypeNew[1, i].Value = tran.strRefNo;
                    }
                    lstRefTypeNew[1, i].Value = tran.strRefNo;
                    lstRefTypeNew[2, i].Value = tran.strDate;
                    //if (i % 2 == 0)
                    //{
                    //    lstRefTypeNew.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    lstRefTypeNew.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



        private void uctxtPartyName_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListViewPartyName(ooPartyName, uctxtPartyName.Text);
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
                    DGMr[0, i].Value = tran.strTeritorryCode;
                    DGMr[1, i].Value = tran.strTeritorryName;
                    DGMr[2, i].Value = tran.strLedgerName;
                    DGMr[3, i].Value = tran.strMereString;
                    //if (i % 2 == 0)
                    //{
                    //    DGMr.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGMr.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void uctxtPartyName_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void uctxtCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListViewCustomerName(ooinv, uctxtCustomer.Text);
        }
        private void SearchListViewCustomerName(IEnumerable<Invoice> tests, string searchString = "")
        {
            IEnumerable<Invoice> query;

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
                    DGcustomer[0, i].Value = tran.strTeritorryCode;
                    DGcustomer[2, i].Value = tran.strTeritorryName;
                    DGcustomer[1, i].Value = tran.strLedgerName;
                    DGcustomer[3, i].Value = tran.strMereString;
                    //if (i % 2 == 0)
                    //{
                    //    DGcustomer.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGcustomer.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



        private void btnRightAll_Click(object sender, EventArgs e)
        {
            int intloop = 0;
            string strBillKey = "", strRefNo, strDate;
            DGSalesOrder.Rows.Clear();
            for (int i = 0; i < lstRefTypeNew.Rows.Count; i++)
            {
                //if (DGSalesOrder.Rows.Count >20)
                //{
                //    lblOrder.Text = "Total: " + DGSalesOrder.Rows.Count.ToString();
                //    return;
                //}
                strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                DisplayReferanceNew(strBillKey, strRefNo, strDate, DGSalesOrder);
                intloop += 1;
            }
            lblOrder.Text = "Total: " + DGSalesOrder.Rows.Count.ToString();
            lstRefTypeNew.Rows.Clear();

        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            string strBillKey = "", strRefNo, strDate;
            //lstRefTypeNew.Rows.Clear();
            for (int i = 0; i < DGSalesOrder.Rows.Count; i++)
            {

                strBillKey = DGSalesOrder.Rows[i].Cells[0].Value.ToString();
                strRefNo = DGSalesOrder.Rows[i].Cells[1].Value.ToString();
                strDate = DGSalesOrder.Rows[i].Cells[2].Value.ToString();
                DisplayReferanceNew(strBillKey, strRefNo, strDate, lstRefTypeNew);

            }
            lstRefTypeNew.AllowUserToAddRows = false;
            DGSalesOrder.Rows.Clear();
            lblOrder.Text = "Total: " + 0;
        }

        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            string strBillKey = "", strRefNo, strDate;


            int i = 0;
            foreach (DataGridViewRow row in lstRefTypeNew.SelectedRows)
            {
                i = Convert.ToInt16(row.Index);
            }
            //if (DGSalesOrder.Rows.Count>20)
            //{
            //    lblOrder.Text = "Total: " + DGSalesOrder.Rows.Count;
            //    return;
            //}
            strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
            strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
            strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
            DisplayReferanceNew(strBillKey, strRefNo, strDate, DGSalesOrder);
            lstRefTypeNew.Rows.RemoveAt(i);
            lblOrder.Text = "Total: " + DGSalesOrder.Rows.Count;
           

        }

        private void btnLeftSingle_Click(object sender, EventArgs e)
        {
            string strBillKey = "", strRefNo, strDate;
            int i = 0;
            try
            {
                foreach (DataGridViewRow row in DGSalesOrder.SelectedRows)
                {
                    i = Convert.ToInt16(row.Index);
                }
                strBillKey = DGSalesOrder.Rows[i].Cells[0].Value.ToString();
                strRefNo = DGSalesOrder.Rows[i].Cells[1].Value.ToString();
                strDate = DGSalesOrder.Rows[i].Cells[2].Value.ToString();
                DisplayReferanceNew(strBillKey, strRefNo, strDate, lstRefTypeNew);

                DGSalesOrder.Rows.RemoveAt(i);
                lblOrder.Text = "Total: " + DGSalesOrder.Rows.Count;
                lstRefTypeNew.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSQL = "", strRefNumber = "", strBillKey = "", strUOM = "", strMySQL = "";
            double dblCostPrice = 0, dblBonusQty = 0, dblTotalCost = 1, dblNetAmnout = 0, dbbILLAmnout = 0, dblProcessAmnt = 0;
            long lngloop = 1, lngAgstRef = 0,intInsertLoop=0;
            lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            string strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            SqlCommand cmdInsert = new SqlCommand();
            SqlDataReader dr;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlTransaction myTrans;
            int introw = 0;
            if (uctxtChallanNo.Text == "")
            {
                MessageBox.Show("Cannot be empty");
                uctxtChallanNo.Focus();
                return;
            }
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Cannot be empty");
                uctxtBranchName.Focus();
                return;
            }
            if (uctxtLocation.Text == "")
            {
                MessageBox.Show("Cannot be empty");
                uctxtLocation.Focus();
                return;
            }
            if (DGSalesOrder.Rows.Count < 1)
            {
                MessageBox.Show("Cannot be empty");
                DGSalesOrder.Focus();
                return;
            }
            //if (DGSalesOrder.Rows.Count > 20)
            //{
            //    MessageBox.Show("Invoice Should be Less than 20 ");
            //    DGSalesOrder.Focus();
            //    return;
            //}
            string strLockvoucher = Utility.gLockVocher(strComID, intVtype);
            long lngDate = Convert.ToInt64(dteDate.Value.ToString("yyyyMMdd"));
            if (strLockvoucher != "")
            {
                long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strLockvoucher).ToString("yyyyMMdd"));
                if (lngDate <= lngBackdate)
                {
                    MessageBox.Show("Invalid Date, Back Date is locked");
                    return;
                }
            }
            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                string connstring = Utility.SQLConnstringComSwitch(strComID);
                using (SqlConnection gcnMain = new SqlConnection(connstring))
                {
                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }
                    gcnMain.Open();
                    cmdInsert.Connection = gcnMain;
                    lngloop = 1;
                    progressBar1.Refresh();
                    progressBar1.Value = 0;
                    progressBar1.Maximum = DGSalesOrder.Rows.Count;
                    try
                    {

                        for (introw = 0; introw < DGSalesOrder.Rows.Count; introw++)
                        {
                            //strSQL = "INSERT INTO INV_SALES_CHALLAN(STOCKITEM_NAME,CHALLAN_NO,CHALLAN_DATE,AGNST_REF_NO,BILL_QTY,BILL_AMOUNT,BILL_BONUS_QTY,BILL_NET_AMOUNT,NARRATION) ";
                            //strSQL = strSQL + "SELECT STOCKITEM_NAME,'SC" + strBarchID + uctxtChallanNo.Text + "'  ,COMP_VOUCHER_DATE,COMP_REF_NO,BILL_QUANTITY,BILL_AMOUNT,BILL_QUANTITY_BONUS,BILL_NET_AMOUNT,'"+ uctxtNarration.Text.Replace("'","''") + "' ";
                            //strSQL = strSQL + "FROM ACC_BILL_TRAN_PENDING_QRY WHERE COMP_REF_NO = '" + DGSalesOrder[0, introw].Value.ToString() + "' ";
                            //cmdInsert.CommandText = strSQL;
                            //cmdInsert.ExecuteNonQuery();
                            //    lngloop += 1;
                            //}
                            intInsertLoop += 1;
                            List<AccBillwise> OBJbILL = new List<AccBillwise>();
                            if (lngAgstRef != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                            {
                                strSQL = "SELECT COMP_REF_NO,STOCKITEM_NAME,BILL_BALANCE_QTY,";
                                strSQL = strSQL + "BILL_UOM,BILL_RATE,BILL_NET_AMOUNT,BILL_AMOUNT ";
                                strSQL = strSQL + "FROM ACC_BILL_TRAN_PENDING_QRY ";
                                strSQL = strSQL + "WHERE COMP_REF_NO = '" + DGSalesOrder[0, introw].Value.ToString() + "' ";
                            }
                            else
                            {
                                strSQL = "SELECT SAMPLE_CLASS COMP_REF_NO,STOCKITEM_NAME,SAM_CLASS_QUANTITY AS BILL_BALANCE_QTY,";
                                strSQL = strSQL + "SAM_CLASS_UOM AS BILL_UOM,0 AS BILL_RATE,0 as BILL_NET_AMOUNT,0 BILL_AMOUNT ";
                                strSQL = strSQL + " FROM ACC_SAMPLE_CLASS_TRAN ";
                                strSQL = strSQL + "WHERE SAMPLE_CLASS = '" + DGSalesOrder[0, introw].Value.ToString() + "' ";
                            }
                            cmdInsert.CommandText = strSQL;
                            dr = cmdInsert.ExecuteReader();
                            while (dr.Read())
                            {
                                AccBillwise ooBill = new AccBillwise();
                                ooBill.strRefNo = dr["COMP_REF_NO"].ToString();
                                ooBill.strStockItemName = dr["STOCKITEM_NAME"].ToString();
                                ooBill.dblQnty = Utility.Val(dr["BILL_BALANCE_QTY"].ToString());
                                ooBill.strPer = dr["BILL_UOM"].ToString();
                                ooBill.dblRate = Utility.Val(dr["BILL_RATE"].ToString());
                                ooBill.dblBillNetAmount = Utility.Val(dr["BILL_NET_AMOUNT"].ToString());
                                ooBill.dblAmount = Utility.Val(dr["BILL_AMOUNT"].ToString());
                                OBJbILL.Add(ooBill);
                            }
                            dr.Close();
                            if (OBJbILL.Count > 0)
                            {
                                myTrans = gcnMain.BeginTransaction();
                                cmdInsert.Transaction = myTrans;
                                if (intInsertLoop == 1)
                                {
                                    if (mblnNumbMethod == false)
                                    {
                                        strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + uctxtChallanNo.Text;
                                    }
                                    else
                                    {
                                        strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + Utility.gstrLastNumber(strComID, intVtype);
                                    }
                                    strSQL = VoucherSW.gInsertCompanyVoucherNew(strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, dteDate.Value.ToString("MMMyy"), dteDuedate.Text, uctxtTeritoryCode.Text,
                                                                                    dbbILLAmnout, dblNetAmnout, 0, 0, lngAgstRef, Utility.gCheckNull(uctxtNarration.Text),
                                                                                            strBarchID, 0, "", uctxtCustomer.Text, "", "", "", "", uctxtTrNo.Text, "", "", "", "", uctxtDesignation.Text,
                                                                                            uctxtTransport.Text, Utility.Val(uctxtcrtQty.Text), Utility.Val(uctxtBoxQty.Text), dblProcessAmnt);
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    strSQL = VoucherSW.gInteractInvInsertMaster(uctxtTeritoryCode.Text, strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, strBarchID,
                                                                                    Utility.gCheckNull(uctxtNarration.Text));
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();

                                    if (mblnNumbMethod == true)
                                    {
                                        strSQL = VoucherSW.gIncreaseVoucher((int)intVtype);
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                }



                                foreach (AccBillwise row1 in OBJbILL)
                                {
                                    double dblClosingQTY = 0, dblCurrentQTY = 0;
                                    //dblCurrentQTY = Utility.Val(row1["BILL_BALANCE_QTY"].ToString());
                                    dblCurrentQTY = Utility.Val(row1.dblQnty.ToString());
                                    if (uctxtRefType.Text == "Sample Class")
                                    {
                                        //dblClosingQTY = Utility.gdblClosingStockSales(strComID, strItemName, uctxtLocation.Text, dteDate.Text);
                                        //dblClosingQTY = Utility.gdblClosingStockSales(strComID, row1.strStockItemName.ToString(), lstBranchName.SelectedValue.ToString(), "", uctxtLocation.Text);

                                        strSQL = "SELECT ISNULL(sum(INV_TRAN_QUANTITY),0) AS CLOSING FROM INV_SALES_STAREMENTVIEW ";
                                        strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + row1.strStockItemName.ToString().Replace("'", "''") + "' ";
                                        strSQL = strSQL + "AND BRANCH_ID = '" + lstBranchName.SelectedValue.ToString() + "' ";
                                        strSQL = strSQL + "AND GODOWNS_NAME = '" + uctxtLocation.Text.Replace("'", "''") + "' ";
                                        cmdInsert.CommandText = strSQL;
                                        dr = cmdInsert.ExecuteReader();
                                        if (dr.Read())
                                        {
                                            dblClosingQTY = Convert.ToDouble(dr["CLOSING"]);
                                        }
                                        else
                                        {
                                            dblClosingQTY = 0;
                                        }
                                        dr.Close();

                                    }
                                    else
                                    {
                                        //dblClosingQTY = Utility.gdblClosingStock(strComID, row1.strStockItemName.ToString(), uctxtLocation.Text, dteDate.Text);

                                        strSQL = "SELECT ISNULL((SUM(INWARD_QUANTITY)-abs(sum(OUTWARD_QUANTITY))),0) AS CLOSING FROM INV_TRAN ";
                                        strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + row1.strStockItemName.ToString().Replace("'", "''") + "' ";
                                        strSQL = strSQL + "AND GODOWNS_NAME = '" + uctxtLocation.Text + "' ";
                                        strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(dteDate.Text) + " ";
                                        strSQL = strSQL + "Union All ";
                                        strSQL = strSQL + "SELECT ISNULL(SUM(INV_TRAN_QUANTITY),0) AS CLOSING FROM INV_TRAN ";
                                        strSQL = strSQL + "WHERE STOCKITEM_NAME = '" + row1.strStockItemName.ToString().Replace("'", "''") + "' ";
                                        strSQL = strSQL + "AND GODOWNS_NAME = '" + uctxtLocation.Text + "' ";
                                        strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(dteDate.Text) + " ";
                                        strSQL = strSQL + "AND INV_VOUCHER_TYPE=0 ";
                                        cmdInsert.CommandText = strSQL;
                                        dr = cmdInsert.ExecuteReader();
                                        while (dr.Read())
                                        {
                                            dblClosingQTY = dblClosingQTY + Convert.ToDouble(dr["CLOSING"]);

                                        }
                                        dr.Close();

                                    }
                                    dr.Close();

                                    if ((dblClosingQTY) - dblCurrentQTY < 0)
                                    {
                                        lblNegetive.Text = "You have no valid quantity for Item: " + row1.strStockItemName.ToString();
                                        lngloop += 1;
                                        strBillKey = strRefNumber + lngloop.ToString().PadLeft(4, '0');
                                        strSQL =  VoucherSW.gInsertBillTran(strBillKey, strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, row1.strStockItemName.ToString(), uctxtLocation.Text, Utility.Val(row1.dblQnty.ToString()),
                                                                dblBonusQty, strUOM, Math.Round(Utility.Val(row1.dblRate.ToString()), 2),
                                                               Math.Round(Utility.Val(row1.dblBillNetAmount.ToString()), 2), "",
                                                                        0, Utility.Val(row1.dblAmount.ToString()), "Cr", lngloop, strBarchID, Utility.gstrBaseCurrency,
                                                                        strUOM, "", "", "", "", "", "", "", 0, 0) + ";";

                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        lngloop += 1;
                                        strBillKey = strRefNumber + lngloop.ToString().PadLeft(4, '0');
                                        strSQL = VoucherSW.gInsertBillTran(strBillKey, strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, row1.strStockItemName.ToString(), uctxtLocation.Text, Utility.Val(row1.dblQnty.ToString()),
                                                                dblBonusQty, strUOM, Math.Round(Utility.Val(row1.dblRate.ToString()), 2),
                                                               Math.Round(Utility.Val(row1.dblBillNetAmount.ToString()), 2), "",
                                                                        0, Utility.Val(row1.dblAmount.ToString()), "Cr", lngloop, strBarchID, Utility.gstrBaseCurrency,
                                                                        strUOM, "", "", "", "", "", "", "", 0, 0);
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();

                                        if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
                                        {
                                            strSQL = VoucherSW.gInventoryInsertTranSalesChallan(strRefNumber, strBillKey, lngloop, Math.Round(Utility.Val(row1.dblRate.ToString()), 2), -1, lngAgstRef,
                                                                                                row1.strStockItemName, uctxtLocation.Text,
                                                                                        "O", Utility.Val(row1.dblQnty.ToString()) * -1, dblBonusQty * -1, dblCostPrice, Convert.ToInt64(intVtype), dteDate.Text,
                                                                                        strBarchID, "", 0, strUOM, strUOM);
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }

                                        else if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                                        {
                                            strSQL = VoucherSW.gInventoryInsertTranSalesChallanClass(strRefNumber, strBillKey, lngloop, Math.Round(Utility.Val(row1.dblRate.ToString()), 2), -1 * dblTotalCost,
                                                                                                    lngAgstRef, row1.strStockItemName.ToString(), uctxtLocation.Text,
                                                                                                    "O", Utility.Val(row1.dblQnty.ToString()) * -1, dblBonusQty * -1, dblCostPrice, Convert.ToInt64(intVtype),
                                                                                                    dteDate.Text, strBarchID, "", 0,
                                                                                                    strUOM, strUOM);
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                       
                                    }

                                    if (uctxtRefType.Text != "Sample Class")
                                    {
                                        strSQL = "INSERT INTO ACC_VOUCHER_JOIN(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID) ";
                                        strSQL = strSQL + "VALUES(";
                                        strSQL = strSQL + "'" + strRefNumber + "','" + DGSalesOrder[0, introw].Value.ToString() + "','" + strBarchID + "'";
                                        strSQL = strSQL + ")";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                    strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
                                    strSQL = strSQL + "WHERE COMP_REF_NO = '" + DGSalesOrder[0, introw].Value.ToString() + "'";
                                    cmdInsert.CommandText = strSQL;
                                    cmdInsert.ExecuteNonQuery();


                                }
                                progressBar1.Value += 1;
                                if (Utility.gblnAccessControl)
                                {
                                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, "Sales Challan", uctxtChallanNo.Text,
                                                                            1, 0, (int)Utility.MODULE_TYPE.mtSALES, strBarchID);
                                }
                               
                                cmdInsert.Transaction.Commit();
                                cmdInsert.Dispose();
                                strSQL = "";
                                strMySQL = "";
                                OBJbILL.Clear();
                            }


                        }

                        cmdInsert.Dispose();
                        gcnMain.Close();
                        strMySQL = "";
                        strSQL = "";
                        mClear();
                        uctxtPartyName.Focus();
                        MessageBox.Show("Process Generate Successfully..");
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(EX.ToString());
                    }



                }

            }
        }
        #region "Save Comment"
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    string strSQL = "", strRefNumber = "", strBillKey = "", strAgnstRefNo = "", strRefNo = "", strUOM = "";
        //    double dblCostPrice = 0, dblBonusQty = 0, dblTotalCost = 1, dblNetAmnout = 0, dbbILLAmnout = 0, dblProcessAmnt = 0;
        //    long lngloop = 1, lngAgstRef = 0;
        //    lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
        //    string strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
        //    SqlCommand cmdInsert = new SqlCommand();
        //    SqlDataReader dr;
        //    DataTable dt = new DataTable();
        //    DataSet ds = new DataSet();
        //    SqlTransaction myTrans;
        //    int introw = 0;
        //    if (uctxtChallanNo.Text == "")
        //    {
        //        MessageBox.Show("Cannot be empty");
        //        uctxtChallanNo.Focus();
        //        return;
        //    }
        //    if (uctxtBranchName.Text == "")
        //    {
        //        MessageBox.Show("Cannot be empty");
        //        uctxtBranchName.Focus();
        //        return;
        //    }
        //    if (uctxtLocation.Text == "")
        //    {
        //        MessageBox.Show("Cannot be empty");
        //        uctxtLocation.Focus();
        //        return;
        //    }
        //    if (DGSalesOrder.Rows.Count < 1)
        //    {
        //        MessageBox.Show("Cannot be empty");
        //        DGSalesOrder.Focus();
        //        return;
        //    }
        //    string strLockvoucher = Utility.gLockVocher(strComID, intVtype);
        //    long lngDate = Convert.ToInt64(dteDate.Value.ToString("yyyyMMdd"));
        //    if (strLockvoucher != "")
        //    {
        //        long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strLockvoucher).ToString("yyyyMMdd"));
        //        if (lngDate <= lngBackdate)
        //        {
        //            MessageBox.Show("Invalid Date, Back Date is locked");
        //            return;
        //        }
        //    }
        //    var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (strResponseInsert == DialogResult.Yes)
        //    {
        //        string connstring = Utility.SQLConnstringComSwitch(strComID);
        //        using (SqlConnection gcnMain = new SqlConnection(connstring))
        //        {
        //            if (gcnMain.State == ConnectionState.Open)
        //            {
        //                gcnMain.Close();
        //            }
        //            gcnMain.Open();
        //            cmdInsert.Connection = gcnMain;
        //            lngloop = 1;
        //            progressBar1.Refresh();
        //            progressBar1.Value = 0;
        //            progressBar1.Maximum = DGSalesOrder.Rows.Count;
        //            try
        //            {
        //                for (introw = 0; introw < DGSalesOrder.Rows.Count; introw++)
        //                {
        //                    //strSQL = "INSERT INTO INV_SALES_CHALLAN(STOCKITEM_NAME,CHALLAN_NO,CHALLAN_DATE,AGNST_REF_NO,BILL_QTY,BILL_AMOUNT,BILL_BONUS_QTY,BILL_NET_AMOUNT,NARRATION) ";
        //                    //strSQL = strSQL + "SELECT STOCKITEM_NAME,'SC" + strBarchID + uctxtChallanNo.Text + "'  ,COMP_VOUCHER_DATE,COMP_REF_NO,BILL_QUANTITY,BILL_AMOUNT,BILL_QUANTITY_BONUS,BILL_NET_AMOUNT,'"+ uctxtNarration.Text.Replace("'","''") + "' ";
        //                    //strSQL = strSQL + "FROM ACC_BILL_TRAN_PENDING_QRY WHERE COMP_REF_NO = '" + DGSalesOrder[0, introw].Value.ToString() + "' ";
        //                    //cmdInsert.CommandText = strSQL;
        //                    //cmdInsert.ExecuteNonQuery();


        //                    if (lngAgstRef != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
        //                    {
        //                        strSQL = "SELECT COMP_REF_NO,BILL_TRAN_KEY,STOCKGROUP_NAME,STOCKITEM_NAME,GODOWNS_NAME,BILL_BALANCE_QTY,";
        //                        strSQL = strSQL + "BILL_UOM,BILL_PER,BILL_RATE,BILL_NET_AMOUNT,BILL_AMOUNT,INV_LOG_NO,BILL_QUANTITY_BONUS,BILL_ADD_LESS_AMOUNT ";
        //                        strSQL = strSQL + "FROM ACC_BILL_TRAN_PENDING_QRY ";
        //                        strSQL = strSQL + "WHERE COMP_REF_NO = '" + DGSalesOrder[0, introw].Value.ToString() + "' ";
        //                    }
        //                    else
        //                    {
        //                        strSQL = "SELECT SAMPLE_CLASS COMP_REF_NO,'' as BILL_TRAN_KEY,'' STOCKGROUP_NAME,STOCKITEM_NAME,'' AS GODOWNS_NAME,SAM_CLASS_QUANTITY AS BILL_BALANCE_QTY,";
        //                        strSQL = strSQL + "SAM_CLASS_UOM AS BILL_UOM,SAM_CLASS_UOM AS BILL_PER,0 AS BILL_RATE,0 as BILL_NET_AMOUNT,0 BILL_AMOUNT,'' as INV_LOG_NO ";
        //                        strSQL = strSQL + ",0 BILL_QUANTITY_BONUS,0 BILL_ADD_LESS_AMOUNT FROM ACC_SAMPLE_CLASS_TRAN ";
        //                        strSQL = strSQL + "WHERE SAMPLE_CLASS = '" + DGSalesOrder[0, introw].Value.ToString() + "' ";
        //                    }

        //                    SqlDataAdapter da = new SqlDataAdapter(strSQL, gcnMain);
        //                    da.Fill(ds);
        //                    dt = ds.Tables[0];
        //                    foreach (DataRow row1 in dt.Rows)
        //                    {
        //                        double dblClosingQTY = 0, dblCurrentQTY = 0;
        //                        dblCurrentQTY = Utility.Val(row1["BILL_BALANCE_QTY"].ToString());
        //                        if (uctxtRefType.Text == "Sample Class")
        //                        {
        //                            //dblClosingQTY = Utility.gdblClosingStockSales(strComID, strItemName, uctxtLocation.Text, dteDate.Text);
        //                            dblClosingQTY = Utility.gdblClosingStockSales(strComID, row1["STOCKITEM_NAME"].ToString(), lstBranchName.SelectedValue.ToString(), "", uctxtLocation.Text);
        //                        }
        //                        else
        //                        {
        //                            dblClosingQTY = Utility.gdblClosingStock(strComID, row1["STOCKITEM_NAME"].ToString(), uctxtLocation.Text, dteDate.Text);
        //                        }
        //                        //**********************




        //                        //if (ValidateFields(row1["STOCKITEM_NAME"].ToString().Replace("'", "''"), row1["COMP_REF_NO"].ToString(), Utility.Val(row1["BILL_BALANCE_QTY"].ToString())) == false)

        //                        if ((dblClosingQTY) - dblCurrentQTY < 0)
        //                        {
        //                            lblNegetive.Text = "You have no valid quantity for Item: " + row1["STOCKITEM_NAME"].ToString();
        //                            //progressBar1.Refresh();
        //                            //progressBar1.Value = 0;
        //                            //return;
        //                            if (strBarchID == "0002")
        //                            {
        //                                strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
        //                                strSQL = strSQL + "WHERE COMP_REF_NO = '" + DGSalesOrder[0, introw].Value.ToString() + "'";
        //                                cmdInsert.CommandText = strSQL;
        //                                cmdInsert.ExecuteNonQuery();
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (uctxtRefType.Text == "Sample Class")
        //                            {
        //                                uctxtNarration.Text = DGSalesOrder[0, introw].Value.ToString();
        //                            }

        //                            lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
        //                            strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

        //                            cmdInsert.Connection = gcnMain;
        //                            strSQL = "SELECT ISNULL(SUM(BILL_AMOUNT),0) AMNT,ISNULL(SUM(BILL_NET_AMOUNT ),0) NETAMNT,ISNULL(SUM(BILL_ADD_LESS_AMOUNT ),0) Addlessamnt ";
        //                            strSQL = strSQL + "FROM ACC_BILL_TRAN_PENDING_QRY ";
        //                            strSQL = strSQL + "WHERE COMP_REF_NO = '" + DGSalesOrder[0, introw].Value.ToString() + "' ";
        //                            cmdInsert.CommandText = strSQL;
        //                            dr = cmdInsert.ExecuteReader();
        //                            if (dr.Read())
        //                            {
        //                                dbbILLAmnout = Math.Round(Utility.Val(dr["AMNT"].ToString()), 0);
        //                                dblNetAmnout = Math.Round(Utility.Val(dr["NETAMNT"].ToString()), 0);
        //                                dblProcessAmnt = Math.Abs(Math.Round(Utility.Val(dr["Addlessamnt"].ToString()), 0));
        //                            }

        //                            dr.Close();
        //                            strSQL = "SELECT ISNULL(SUM(INV_TRAN_QUANTITY),0) AS QTY,ISNULL(SUM(INV_TRAN_AMOUNT),0) AS AMT FROM INV_STOCKITEM_TRAN_QRY ";
        //                            strSQL = strSQL + "WHERE (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') ";
        //                            strSQL = strSQL + "AND STOCKITEM_NAME = '" + row1["STOCKITEM_NAME"].ToString().Replace("'", "''") + "' ";
        //                            strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(dteDate.Text) + " ";
        //                            cmdInsert.CommandText = strSQL;
        //                            dr = cmdInsert.ExecuteReader();
        //                            if (dr.Read())
        //                            {
        //                                if (Utility.Val(dr["QTY"].ToString()) > 0)
        //                                {
        //                                    dblCostPrice = Math.Round(Utility.Val(dr["AMT"].ToString()) / Utility.Val(dr["QTY"].ToString()), 3);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                dblCostPrice = 0;
        //                            }
        //                            dr.Close();

        //                            strUOM = Utility.gGetBaseUOM(strComID, row1["STOCKITEM_NAME"].ToString().Replace("'", "''"));
        //                            strSQL = "";


        //                            strAgnstRefNo = Utility.gstrGetBillKey(strComID, DGSalesOrder[1, introw].Value.ToString(), row1["STOCKITEM_NAME"].ToString().Replace("'", "''"));
        //                            strRefNo = DGSalesOrder[0, introw].Value.ToString();
        //                            dblBonusQty = Utility.Val(row1["BILL_QUANTITY_BONUS"].ToString());



        //                            myTrans = gcnMain.BeginTransaction();
        //                            cmdInsert.Connection = gcnMain;
        //                            cmdInsert.Transaction = myTrans;

        //                            if (lngloop == 1)
        //                            {
        //                                if (mblnNumbMethod == false)
        //                                {
        //                                    strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + uctxtChallanNo.Text;
        //                                }
        //                                else
        //                                {
        //                                    strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + Utility.gstrLastNumber(strComID, intVtype);
        //                                }
        //                                strSQL = VoucherSW.gInsertCompanyVoucherNew(strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, dteDate.Value.ToString("MMMyy"), dteDuedate.Text, uctxtTeritoryCode.Text,
        //                                                                                dbbILLAmnout, dblNetAmnout, 0, 0, lngAgstRef, Utility.gCheckNull(uctxtNarration.Text),
        //                                                                                        strBarchID, 0, "", uctxtCustomer.Text, "", "", "", "", uctxtTrNo.Text, "", "", "", "", uctxtDesignation.Text,
        //                                                                                        uctxtTransport.Text, Utility.Val(uctxtcrtQty.Text), Utility.Val(uctxtBoxQty.Text), dblProcessAmnt);

        //                                cmdInsert.CommandText = strSQL;
        //                                cmdInsert.ExecuteNonQuery();

        //                                strSQL = VoucherSW.gInteractInvInsertMaster(uctxtTeritoryCode.Text, strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, strBarchID,
        //                                                                                Utility.gCheckNull(uctxtNarration.Text));
        //                                cmdInsert.CommandText = strSQL;
        //                                cmdInsert.ExecuteNonQuery();
        //                            }
        //                            strBillKey = strRefNumber + lngloop.ToString().PadLeft(4, '0');

        //                            strSQL = VoucherSW.gInsertBillTran(strBillKey, strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, row1["STOCKITEM_NAME"].ToString(), uctxtLocation.Text, Utility.Val(row1["BILL_BALANCE_QTY"].ToString()),
        //                                                    dblBonusQty, strUOM, Math.Round(Utility.Val(row1["BILL_RATE"].ToString()), 2),
        //                                                   Math.Round(Utility.Val(row1["BILL_NET_AMOUNT"].ToString()), 2), "",
        //                                                            0, Utility.Val(row1["BILL_AMOUNT"].ToString()), "Cr", lngloop, strBarchID, Utility.gstrBaseCurrency,
        //                                                            strUOM, "", "", "", "", "", "", "", 0, 0);
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();

        //                            strSQL = VoucherSW.gInsertBillTranProcess(strBillKey, strBarchID, lngloop, strRefNumber, strRefNumber, Convert.ToInt64(intVtype), dteDate.Text,
        //                                                            row1["STOCKITEM_NAME"].ToString(), uctxtLocation.Text, Utility.Val(row1["BILL_BALANCE_QTY"].ToString()),
        //                                                            strUOM, strAgnstRefNo, 0, 0, strUOM);
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();

        //                            if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
        //                            {
        //                                strSQL = VoucherSW.gInsertBillTranProcess(strBillKey, strBarchID, lngloop, strRefNumber, strRefNo, lngAgstRef, dteDate.Text,
        //                                                                        row1["STOCKITEM_NAME"].ToString(), uctxtLocation.Text, Utility.Val(row1["BILL_BALANCE_QTY"].ToString()) * -1,
        //                                                                        strUOM, strAgnstRefNo, 0, 0, strUOM);
        //                                cmdInsert.CommandText = strSQL;
        //                                cmdInsert.ExecuteNonQuery();
        //                                strSQL = VoucherSW.gInventoryInsertTranSalesChallan(strRefNumber, strBillKey, lngloop, Math.Round(Utility.Val(row1["BILL_BALANCE_QTY"].ToString()), 2), -1, lngAgstRef,
        //                                                                                    row1["STOCKITEM_NAME"].ToString(), uctxtLocation.Text,
        //                                                                            "O", Utility.Val(row1["BILL_BALANCE_QTY"].ToString()) * -1, dblBonusQty * -1, dblCostPrice, Convert.ToInt64(intVtype), dteDate.Text,
        //                                                                            strBarchID, "", 0, strUOM, strUOM);
        //                                cmdInsert.CommandText = strSQL;
        //                                cmdInsert.ExecuteNonQuery();
        //                            }

        //                            else if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
        //                            {
        //                                strSQL = VoucherSW.gInventoryInsertTranSalesChallanClass(strRefNumber, strBillKey, lngloop, Math.Round(Utility.Val(row1["BILL_RATE"].ToString()), 2), -1 * dblTotalCost,
        //                                                                                        lngAgstRef, row1["STOCKITEM_NAME"].ToString(), uctxtLocation.Text,
        //                                                                                        "O", Utility.Val(row1["BILL_BALANCE_QTY"].ToString()) * -1, dblBonusQty * -1, dblCostPrice, Convert.ToInt64(intVtype),
        //                                                                                        dteDate.Text, strBarchID, "", 0,
        //                                                                                        strUOM, strUOM);
        //                                cmdInsert.CommandText = strSQL;
        //                                cmdInsert.ExecuteNonQuery();
        //                            }
        //                            if (uctxtRefType.Text != "Sample Class")
        //                            {
        //                                strSQL = "INSERT INTO ACC_VOUCHER_JOIN(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID) ";
        //                                strSQL = strSQL + "VALUES(";
        //                                strSQL = strSQL + "'" + strRefNumber + "','" + DGSalesOrder[0, introw].Value.ToString() + "','" + strBarchID + "'";
        //                                strSQL = strSQL + ")";
        //                                cmdInsert.CommandText = strSQL;
        //                                cmdInsert.ExecuteNonQuery();
        //                            }
        //                            strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
        //                            strSQL = strSQL + "WHERE COMP_REF_NO = '" + DGSalesOrder[0, introw].Value.ToString() + "'";
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();

        //                            strSQL = "update INV_TRAN set OUTWARD_SALES_AMOUNT=  INV_TRAN_QUANTITY * " + dblCostPrice + " ";
        //                            strSQL = strSQL + ",OUTWARD_COST_AMOUNT=  INV_TRAN_QUANTITY * " + dblCostPrice + " ";
        //                            strSQL = strSQL + ",INV_TRAN_AMOUNT=  INV_TRAN_QUANTITY * " + dblCostPrice + " ";
        //                            strSQL = strSQL + "WHERE INV_TRAN_KEY=  '" + strBillKey + "' ";
        //                            cmdInsert.CommandText = strSQL;
        //                            cmdInsert.ExecuteNonQuery();

        //                            if (Utility.gblnAccessControl)
        //                            {
        //                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, "Sales Challan", uctxtChallanNo.Text,
        //                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSALES, strBarchID);
        //                            }

                                 
        //                            cmdInsert.Transaction.Commit();
        //                            lngloop += 1;




        //                        }
        //                    }
        //                    progressBar1.Value += 1;
        //                }



        //                if (mblnNumbMethod == true)
        //                {
        //                    strSQL = VoucherSW.gIncreaseVoucher((int)intVtype);
        //                    cmdInsert.CommandText = strSQL;
        //                    cmdInsert.ExecuteNonQuery();
        //                }

        //                mClear();
        //                uctxtPartyName.Focus();
        //                MessageBox.Show("Process Generate Successfully..");
        //            }
        //            catch (Exception EX)
        //            {
        //                MessageBox.Show(EX.ToString());
        //            }



        //        }

        //    }
        //}
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {


            frmAccountsVoucherList objfrm = new frmAccountsVoucherList();
            objfrm.mintVType = Convert.ToInt32(intVtype);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = "Sales Challan";
            objfrm.strPreserveSQl = mySQL;
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            dteDate.Focus();
        }

        private void DGSalesOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DGSalesOrder.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void lstRefTypeNew_DoubleClick(object sender, EventArgs e)
        {
            btnRightSingle.PerformClick();
        }

        private void txtRefTypeNew_KeyDown(object sender, KeyEventArgs e)
        {
            lstRefTypeNew.Focus();
        }

        private void lstRefTypeNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnRightSingle.PerformClick();
                txtRefTypeNew.Focus();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strSQL = "", strRefNumber = "", strBillKey = "", strAgnstRefNo = "", strRefNo = "", strUOM = "";
            double dblCostPrice = 0, dblBonusQty = 0, dblTotalCost = 1, dblNetAmnout = 0, dbbILLAmnout = 0, dblProcessAmnt = 0;
            long lngloop = 1, lngAgstRef = 0;
            lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            string strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            SqlCommand cmdInsert = new SqlCommand();
            SqlDataReader dr;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlTransaction myTrans;
            int introw = 0;
            if (uctxtChallanNo.Text == "")
            {
                MessageBox.Show("Cannot be empty");
                uctxtChallanNo.Focus();
                return;
            }
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Cannot be empty");
                uctxtBranchName.Focus();
                return;
            }
            if (uctxtLocation.Text == "")
            {
                MessageBox.Show("Cannot be empty");
                uctxtLocation.Focus();
                return;
            }
            if (DGSalesOrder.Rows.Count < 1)
            {
                MessageBox.Show("Cannot be empty");
                DGSalesOrder.Focus();
                return;
            }
            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                string connstring = Utility.SQLConnstringComSwitch(strComID);
                using (SqlConnection gcnMain = new SqlConnection(connstring))
                {
                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }
                    gcnMain.Open();
                    lngloop = 1;
                    progressBar1.Refresh();
                    progressBar1.Value = 0;
                    progressBar1.Maximum = DGSalesOrder.Rows.Count;
                    try
                    {
                        for (introw = 0; introw < DGSalesOrder.Rows.Count; introw++)
                        {
                            if (lngAgstRef != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                            {
                                strSQL = "SELECT COMP_REF_NO,BILL_TRAN_KEY,STOCKGROUP_NAME,STOCKITEM_NAME,GODOWNS_NAME,BILL_BALANCE_QTY,";
                                strSQL = strSQL + "BILL_UOM,BILL_PER,BILL_RATE,BILL_NET_AMOUNT,BILL_AMOUNT,INV_LOG_NO,BILL_QUANTITY_BONUS,BILL_ADD_LESS_AMOUNT ";
                                strSQL = strSQL + "FROM ACC_BILL_TRAN_PENDING_QRY ";
                                strSQL = strSQL + "WHERE COMP_REF_NO = '" + DGSalesOrder[0, introw].Value.ToString() + "' ";
                            }
                            else
                            {
                                strSQL = "SELECT SAMPLE_CLASS COMP_REF_NO,'' as BILL_TRAN_KEY,'' STOCKGROUP_NAME,STOCKITEM_NAME,'' AS GODOWNS_NAME,SAM_CLASS_QUANTITY AS BILL_BALANCE_QTY,";
                                strSQL = strSQL + "SAM_CLASS_UOM AS BILL_UOM,SAM_CLASS_UOM AS BILL_PER,0 AS BILL_RATE,0 as BILL_NET_AMOUNT,0 BILL_AMOUNT,'' as INV_LOG_NO ";
                                strSQL = strSQL + ",0 BILL_QUANTITY_BONUS,0 BILL_ADD_LESS_AMOUNT FROM ACC_SAMPLE_CLASS_TRAN ";
                                strSQL = strSQL + "WHERE SAMPLE_CLASS = '" + DGSalesOrder[0, introw].Value.ToString() + "' ";
                            }

                            SqlDataAdapter da = new SqlDataAdapter(strSQL, gcnMain);
                            da.Fill(ds);
                            dt = ds.Tables[0];
                            foreach (DataRow row1 in dt.Rows)
                            {
                                if (ValidateFields(row1["STOCKITEM_NAME"].ToString().Replace("'", "''"), row1["COMP_REF_NO"].ToString(), Utility.Val(row1["BILL_BALANCE_QTY"].ToString())) == false)
                                {
                                    progressBar1.Refresh();
                                    progressBar1.Value = 0;
                                    return;
                                }

                            }
                            progressBar1.Value += 1;
                        }
                        introw = 0;
                        progressBar1.Refresh();
                        progressBar1.Value = 0;
                        progressBar1.Maximum = DGSalesOrder.Rows.Count;
                        for (introw = 0; introw < DGSalesOrder.Rows.Count; introw++)
                        {
                            if (DGSalesOrder[0, introw].Value != null)
                            {

                                if (uctxtRefType.Text == "Sample Class")
                                {
                                    uctxtNarration.Text = DGSalesOrder[0, introw].Value.ToString();
                                }

                                lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                                strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

                                cmdInsert.Connection = gcnMain;
                                strSQL = "SELECT ISNULL(SUM(BILL_AMOUNT),0) AMNT,ISNULL(SUM(BILL_NET_AMOUNT ),0) NETAMNT,ISNULL(SUM(BILL_ADD_LESS_AMOUNT ),0) Addlessamnt ";
                                strSQL = strSQL + "FROM ACC_BILL_TRAN_PENDING_QRY ";
                                strSQL = strSQL + "WHERE COMP_REF_NO = '" + DGSalesOrder[0, introw].Value.ToString() + "' ";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {
                                    dbbILLAmnout = Math.Round(Utility.Val(dr["AMNT"].ToString()), 0);
                                    dblNetAmnout = Math.Round(Utility.Val(dr["NETAMNT"].ToString()), 0);
                                    dblProcessAmnt = Math.Abs(Math.Round(Utility.Val(dr["Addlessamnt"].ToString()), 0));
                                }

                                dr.Close();

                                dt.Rows.Clear();

                                if (lngAgstRef != (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                                {
                                    strSQL = "SELECT COMP_REF_NO,BILL_TRAN_KEY,STOCKGROUP_NAME,STOCKITEM_NAME,GODOWNS_NAME,BILL_BALANCE_QTY,";
                                    strSQL = strSQL + "BILL_UOM,BILL_PER,BILL_RATE,BILL_NET_AMOUNT,BILL_AMOUNT,INV_LOG_NO,BILL_QUANTITY_BONUS,BILL_ADD_LESS_AMOUNT ";
                                    strSQL = strSQL + "FROM ACC_BILL_TRAN_PENDING_QRY ";
                                    strSQL = strSQL + "WHERE COMP_REF_NO = '" + DGSalesOrder[0, introw].Value.ToString() + "' ";
                                }
                                else
                                {
                                    strSQL = "SELECT SAMPLE_CLASS COMP_REF_NO,'' as BILL_TRAN_KEY,'' STOCKGROUP_NAME,STOCKITEM_NAME,'' AS GODOWNS_NAME,SAM_CLASS_QUANTITY AS BILL_BALANCE_QTY,";
                                    strSQL = strSQL + "SAM_CLASS_UOM AS BILL_UOM,SAM_CLASS_UOM AS BILL_PER,0 AS BILL_RATE,0 as BILL_NET_AMOUNT,0 BILL_AMOUNT,'' as INV_LOG_NO ";
                                    strSQL = strSQL + ",0 BILL_QUANTITY_BONUS,0 BILL_ADD_LESS_AMOUNT FROM ACC_SAMPLE_CLASS_TRAN ";
                                    strSQL = strSQL + "WHERE SAMPLE_CLASS = '" + DGSalesOrder[0, introw].Value.ToString() + "' ";
                                }

                                SqlDataAdapter da = new SqlDataAdapter(strSQL, gcnMain);
                                da.Fill(ds);
                                dt = ds.Tables[0];
                                if (dt.Rows.Count > 0)
                                {

                                    foreach (DataRow row in dt.Rows)
                                    {

                                        strSQL = "SELECT ISNULL(SUM(INV_TRAN_QUANTITY),0) AS QTY,ISNULL(SUM(INV_TRAN_AMOUNT),0) AS AMT FROM INV_STOCKITEM_TRAN_QRY ";
                                        strSQL = strSQL + "WHERE (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') ";
                                        strSQL = strSQL + "AND STOCKITEM_NAME = '" + row["STOCKITEM_NAME"].ToString().Replace("'", "''") + "' ";
                                        strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(dteDate.Text) + " ";
                                        cmdInsert.CommandText = strSQL;
                                        dr = cmdInsert.ExecuteReader();
                                        if (dr.Read())
                                        {
                                            if (Utility.Val(dr["QTY"].ToString()) > 0)
                                            {
                                                dblCostPrice = Math.Round(Utility.Val(dr["AMT"].ToString()) / Utility.Val(dr["QTY"].ToString()), 3);
                                            }
                                        }
                                        else
                                        {
                                            dblCostPrice = 0;
                                        }
                                        dr.Close();


                                        strUOM = Utility.gGetBaseUOM(strComID, row["STOCKITEM_NAME"].ToString().Replace("'", "''"));
                                        strSQL = "";


                                        strAgnstRefNo = Utility.gstrGetBillKey(strComID, DGSalesOrder[1, introw].Value.ToString(), row["STOCKITEM_NAME"].ToString().Replace("'", "''"));
                                        strRefNo = DGSalesOrder[0, introw].Value.ToString();
                                        dblBonusQty = Utility.Val(row["BILL_QUANTITY_BONUS"].ToString());



                                        myTrans = gcnMain.BeginTransaction();
                                        cmdInsert.Connection = gcnMain;
                                        cmdInsert.Transaction = myTrans;

                                        if (lngloop == 1)
                                        {
                                            if (mblnNumbMethod == false)
                                            {
                                                strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + uctxtChallanNo.Text;
                                            }
                                            else
                                            {
                                                strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + Utility.gstrLastNumber(strComID, intVtype);
                                            }
                                            strSQL = VoucherSW.gInsertCompanyVoucherNew(strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, dteDate.Value.ToString("MMMyy"), dteDuedate.Text, uctxtTeritoryCode.Text,
                                                                                            dbbILLAmnout, dblNetAmnout, 0, 0, lngAgstRef, Utility.gCheckNull(uctxtNarration.Text),
                                                                                                    strBarchID, 0, "", uctxtCustomer.Text, "", "", "", "", uctxtTrNo.Text, "", "", "", "", uctxtDesignation.Text,
                                                                                                    uctxtTransport.Text, Utility.Val(uctxtcrtQty.Text), Utility.Val(uctxtBoxQty.Text), dblProcessAmnt);

                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();

                                            strSQL = VoucherSW.gInteractInvInsertMaster(uctxtTeritoryCode.Text, strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, strBarchID,
                                                                                            Utility.gCheckNull(uctxtNarration.Text));
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                        strBillKey = strRefNumber + lngloop.ToString().PadLeft(4, '0');

                                        strSQL = VoucherSW.gInsertBillTran(strBillKey, strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, row["STOCKITEM_NAME"].ToString(), uctxtLocation.Text, Utility.Val(row["BILL_BALANCE_QTY"].ToString()),
                                                                dblBonusQty, strUOM, Math.Round(Utility.Val(row["BILL_RATE"].ToString()), 2),
                                                               Math.Round(Utility.Val(row["BILL_NET_AMOUNT"].ToString()), 2), "",
                                                                        0, Utility.Val(row["BILL_AMOUNT"].ToString()), "Cr", lngloop, strBarchID, Utility.gstrBaseCurrency,
                                                                        strUOM, "", "", "", "", "", "", "", 0, 0);
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();

                                        strSQL = VoucherSW.gInsertBillTranProcess(strBillKey, strBarchID, lngloop, strRefNumber, strRefNumber, Convert.ToInt64(intVtype), dteDate.Text,
                                                                        row["STOCKITEM_NAME"].ToString(), uctxtLocation.Text, Utility.Val(row["BILL_BALANCE_QTY"].ToString()),
                                                                        strUOM, strAgnstRefNo, 0, 0, strUOM);
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();

                                        if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
                                        {
                                            strSQL = VoucherSW.gInsertBillTranProcess(strBillKey, strBarchID, lngloop, strRefNumber, strRefNo, lngAgstRef, dteDate.Text,
                                                                                    row["STOCKITEM_NAME"].ToString(), uctxtLocation.Text, Utility.Val(row["BILL_BALANCE_QTY"].ToString()) * -1,
                                                                                    strUOM, strAgnstRefNo, 0, 0, strUOM);
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                            strSQL = VoucherSW.gInventoryInsertTranSalesChallan(strRefNumber, strBillKey, lngloop, Math.Round(Utility.Val(row["BILL_BALANCE_QTY"].ToString()), 2), -1, lngAgstRef,
                                                                                                row["STOCKITEM_NAME"].ToString(), uctxtLocation.Text,
                                                                                        "O", Utility.Val(row["BILL_BALANCE_QTY"].ToString()) * -1, dblBonusQty * -1, dblCostPrice, Convert.ToInt64(intVtype), dteDate.Text,
                                                                                        strBarchID, "", 0, strUOM, strUOM);
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }

                                        else if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                                        {
                                            strSQL = VoucherSW.gInventoryInsertTranSalesChallanClass(strRefNumber, strBillKey, lngloop, Math.Round(Utility.Val(row["BILL_RATE"].ToString()), 2), -1 * dblTotalCost,
                                                                                                    lngAgstRef, row["STOCKITEM_NAME"].ToString(), uctxtLocation.Text,
                                                                                                    "O", Utility.Val(row["BILL_BALANCE_QTY"].ToString()) * -1, dblBonusQty * -1, dblCostPrice, Convert.ToInt64(intVtype),
                                                                                                    dteDate.Text, strBarchID, "", 0,
                                                                                                    strUOM, strUOM);
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                        if (uctxtRefType.Text != "Sample Class")
                                        {
                                            strSQL = "INSERT INTO ACC_VOUCHER_JOIN(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID) ";
                                            strSQL = strSQL + "VALUES(";
                                            strSQL = strSQL + "'" + strRefNumber + "','" + DGSalesOrder[0, introw].Value.ToString() + "','" + strBarchID + "'";
                                            strSQL = strSQL + ")";
                                            cmdInsert.CommandText = strSQL;
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                        strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
                                        strSQL = strSQL + "WHERE COMP_REF_NO = '" + DGSalesOrder[0, introw].Value.ToString() + "'";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();

                                        strSQL = "update INV_TRAN set OUTWARD_SALES_AMOUNT=  INV_TRAN_QUANTITY * " + dblCostPrice + " ";
                                        strSQL = strSQL + ",OUTWARD_COST_AMOUNT=  INV_TRAN_QUANTITY * " + dblCostPrice + " ";
                                        strSQL = strSQL + ",INV_TRAN_AMOUNT=  INV_TRAN_QUANTITY * " + dblCostPrice + " ";
                                        strSQL = strSQL + "WHERE INV_TRAN_KEY=  '" + strBillKey + "' ";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();

                                        if (Utility.gblnAccessControl)
                                        {
                                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, "Sales Challan", uctxtChallanNo.Text,
                                                                                    1, 0, (int)Utility.MODULE_TYPE.mtSALES, strBarchID);
                                        }
                                        cmdInsert.Transaction.Commit();
                                        lngloop += 1;

                                    }

                                }



                            }
                            progressBar1.Refresh();
                            progressBar1.Value += 1;
                        }
                        if (mblnNumbMethod == true)
                        {
                            strSQL = VoucherSW.gIncreaseVoucher((int)intVtype);
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        mClear();
                        uctxtPartyName.Focus();
                        MessageBox.Show("Process Generate Successfully..");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }






    }
}
