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
    public partial class frmSalesChallan : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        SPWOIS objWIS = new SPWOIS();
        private ListBox lstPartyName = new ListBox();
        private string mstrPartyName { get; set; }
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstRefType = new ListBox();
        public ListBox lstBatch = new ListBox();

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

        public frmSalesChallan()
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
            this.dteDuedate.GotFocus += new System.EventHandler(this.dteDuedate_GotFocus);

            this.uctxtPartyName.KeyDown += new KeyEventHandler(uctxtPartyName_KeyDown);
            this.uctxtPartyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPartyName_KeyPress);
            this.uctxtPartyName.TextChanged += new System.EventHandler(this.uctxtPartyName_TextChanged);
            //this.lstPartyName.DoubleClick += new System.EventHandler(this.lstPartyName_DoubleClick);
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
          
            this.txtRefTypeNew.KeyDown += new KeyEventHandler(txtRefTypeNew_KeyDown);
            this.txtRefTypeNew.LostFocus += new System.EventHandler(this.txtRefTypeNew_LostFocus);
            this.lstRefTypeNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(lstRefTypeNew_KeyPress);
            this.lstRefTypeNew.DoubleClick += new System.EventHandler(this.lstRefTypeNew_DoubleClick);

            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);
            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);

            this.ucdgList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ucdgList_KeyPress);
            this.ucdgList.DoubleClick += new System.EventHandler(this.ucdgList_DoubleClick);

            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);
            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);

            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtRate.GotFocus += new System.EventHandler(this.uctxtRate_GotFocus);
            this.uctxtRate.TextChanged += new System.EventHandler(this.uctxtRate_TextChanged);

            this.uctxtBatch.KeyDown += new KeyEventHandler(uctxtBatch_KeyDown);
            this.uctxtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatch_KeyPress);
            this.uctxtBatch.TextChanged += new System.EventHandler(this.uctxtBatch_TextChanged);
            this.lstBatch.DoubleClick += new System.EventHandler(this.lstBatch_DoubleClick);
            this.uctxtBatch.GotFocus += new System.EventHandler(this.uctxtBatch_GotFocus);

            //this.uctxtCustomer.KeyDown += new KeyEventHandler(uctxtCustomer_KeyDown);
            //this.uctxtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCustomer_KeyPress);
            //this.uctxtCustomer.TextChanged += new System.EventHandler(this.uctxtCustomer_TextChanged);
            ////this.lstCustomer.DoubleClick += new System.EventHandler(this.lstCustomer_DoubleClick);
            //this.uctxtCustomer.GotFocus += new System.EventHandler(this.uctxtCustomer_GotFocus);
            //this.DGcustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGcustomer_KeyPress);
            //this.DGcustomer.DoubleClick += new System.EventHandler(this.DGcustomer_DoubleClick);

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
            this.ucdgList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ucdgList_CellFormatting);
            this.lstRefTypeNew.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.lstRefTypeNew_CellFormatting);

            //Utility.CreateListBox(lstPartyName, pnlMain, uctxtPartyName);
            Utility.CreateListBox(lstBranchName, pnlMain,uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            Utility.CreateListBox(lstRefType, pnlMain, uctxtRefType);
            Utility.CreateListBox(lstBatch, panel2, uctxtBatch);

            //Utility.CreateListBox(lstCustomer, pnlMain, uctxtCustomer);
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
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblTotalQnty = 0, dblTotalAmount = 0;
            long lngTotal=0;

            for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
            {
                if (DGSalesGrid.Rows[i].Cells[1].Value != null)
                {
                    dblTotalQnty = dblTotalQnty + Utility.Val(DGSalesGrid.Rows[i].Cells[2].Value.ToString());
                    dblTotalAmount = dblTotalAmount + Utility.Val(DGSalesGrid.Rows[i].Cells[5].Value.ToString());
                    lngTotal +=1;
                }
            }

            lblQuantityTotal.Text = dblTotalQnty.ToString();
            lblNetTotal.Text = dblTotalAmount.ToString();
            if (DGSalesGrid.Rows.Count > 0)
            {
                txtTotalItem.Text = "Total Item: " +  lngTotal.ToString();
            }
            else
            {
                txtTotalItem.Text = "";
            }
            if (DGSalesOrder.Rows.Count==0)
            {
                txtNoofOrder.Text = "";
            }
        }
        #endregion
        #region "User Define"
        private void uctxtChallanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                //txtNarration.Text = Interaction.GetSetting(Application.ExecutablePath, intvtype.ToString(), "Narration");
                
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                uctxtChallanNo.AppendText((String)rk.GetValue("VoucherNoSC",""));
                rk.Close();
            }

        }
        private void lstRefTypeNew_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            lstRefTypeNew.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            lstRefTypeNew.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            lstRefTypeNew.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
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
        private void lstRefTypeNew_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;

            string strBillKey,strRefNo,strDate;
            if (lstRefTypeNew.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());

                txtRefTypeNew.Text = Utility.GetDgValue(lstRefTypeNew, uctxtItemName, 0);

                strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                DisplayReferance(strBillKey, strRefNo, strDate);
                lstRefTypeNew.Visible = false;
                txtRefTypeNew.Focus();
                lstRefTypeNew.Rows.RemoveAt(i);
              
                

            }
        }
        private void lstRefTypeNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strBillKey, strRefNo, strDate;
            if (lstRefTypeNew.SelectedRows.Count > 0)
            if (e.KeyChar == (char)Keys.Return)
            {
                txtRefTypeNew.Text = Utility.GetDgValue(lstRefTypeNew, uctxtItemName, 0);
                int i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());
                strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                DisplayReferance(strBillKey, strRefNo, strDate);
                lstRefTypeNew.Visible = false;
                txtRefTypeNew.Focus();
                lstRefTypeNew.Rows.RemoveAt(i);
               
            }
        }

        private void ucdgList_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (ucdgList.SelectedRows.Count > 0)
            {
                uctxtRefType.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
                ucdgList.Visible = false;
                uctxtRefType.Focus();


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
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
        }
        private void uctxtBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtRefType.Enabled)
                {
                    uctxtRefType.Focus();
                }
                else
                {
                    uctxtItemName.Focus();
                }
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
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
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
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
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
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            ucdgList.Visible = false;
            lstRefTypeNew.Visible = false;
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
            lstBatch.Visible = false;
            lstTransport.Visible = true;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstRefTypeNew.Visible = false;
            lstDesignation.Visible = false;
            ucdgList.Visible = false;
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
            if (uctxtCustomer.Text =="")
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
        private void DGcustomer_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
                uctxtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                uctxtHomeohall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                uctxtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID,uctxtCustomer.Text);
                DGcustomer.Visible = false;
                uctxtLocation.Focus();


            }
        }
        private void DGcustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtPartyName.Text = Utility.GetDgValue(DGMr, uctxtPartyName, 0);
                int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
                uctxtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                uctxtHomeohall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                uctxtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID,uctxtCustomer.Text);
                DGcustomer.Visible = false;
                uctxtLocation.Focus();
            }
        }
        private void uctxtCustomer_GotFocus(object sender, System.EventArgs e)
        {
            lstCustomer.Visible = true;
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
            //DGcustomer.Visible = true;
            DGMr.Visible = false;
            //lstCustomer.SelectedIndex = lstCustomer.FindString(uctxtCustomer.Text);
            if (uctxtPartyName .Text != "")
            {
                mloadCustomer();
                //lstCustomer.Items.Add(oinv.strSalesRepresentative);

                //lstCustomer.DisplayMember = "strSalesRepresentative";
                //lstCustomer.ValueMember = "strSalesRepresentative";
                //lstCustomer.DataSource = ooinv.ToList();

            }
        }
        private void mloadCustomer()
        {
            int introw = 0;
            try
            {
                DGcustomer.Rows.Clear();

                ooinv = invms.mFillSalesRepFromMPoNew1(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP, uctxtPartyName.Text).ToList();

                if (ooinv.Count > 0)
                {

                    foreach (Invoice ogrp in ooinv)
                    {
                        DGcustomer.Rows.Add();
                        DGcustomer[0, introw].Value = ogrp.strTeritorryCode;
                        DGcustomer[1, introw].Value = ogrp.strLedgerName;
                        DGcustomer[2, introw].Value = ogrp.strTeritorryName;

                        DGcustomer[3, introw].Value = ogrp.strMereString;
                        //if (introw % 2 == 0)
                        //{
                        //    DGcustomer.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                        //}
                        //else
                        //{
                        //    DGcustomer.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                        //}
                        introw += 1;
                    }

                    DGcustomer.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
        

        private void uctxtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            //{
            //    if (lstCustomer.Items.Count > 0)
            //    {
            //        uctxtCustomer.Text = lstCustomer.Text;
            //    }
            //    uctxtTransport.Focus();
            //}
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(uctxtCustomer, sender, e);
            //}
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtCustomer.Text == "" || uctxtCustomer.Text ==Utility.gcEND_OF_LIST)
                {
                    //txtItemCode.Text = "";
                    uctxtCustomer.Text = "";
                    uctxtCustomer.Text = Utility.gcEND_OF_LIST;
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
                        uctxtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                        uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                        uctxtHomeohall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                        uctxtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID,uctxtCustomer.Text);
                        DGcustomer.Visible = false;
                        uctxtLocation.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                    uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                    uctxtHomeohall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                    uctxtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID,uctxtCustomer.Text);
                    DGcustomer.Visible = false;
                    uctxtLocation.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtCustomer, sender, e);
            }
        }

        private void uctxtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //{
            //    if (lstCustomer.SelectedItem != null)
            //    {
            //        lstCustomer.SelectedIndex = lstCustomer.SelectedIndex - 1;
            //    }
            //}
            //if (e.KeyCode == Keys.Down)
            //{
            //    if (lstCustomer.Items.Count - 1 > lstCustomer.SelectedIndex)
            //    {
            //        lstCustomer.SelectedIndex = lstCustomer.SelectedIndex + 1;
            //    }
            //}
            DGcustomer.Visible = true;
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
            if (e.KeyCode == Keys.Up)
            {
                DGcustomer.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DGcustomer.Focus();
            }

            DGcustomer.Top = uctxtCustomer.Top + 25;
            DGcustomer.Left = uctxtCustomer.Left;
            DGcustomer.Width = uctxtCustomer.Width;
            DGcustomer.Height = 200;
            //ucdgList.Size = new Size(546, 222);
            DGcustomer.BringToFront();
            DGcustomer.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }




        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
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
        private void uctxtBatch_TextChanged(object sender, EventArgs e)
        {
            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }

        private void lstBatch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBatch.Text = lstBatch.Text;
            addItem();
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
                addItem();
                uctxtItemName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBatch, sender, e);
            }
        }
        private void addItem()
        {
            string  strUOM = "";
            //double dblDis = 0;

            //if (uctxtItemName.Text != "*****Press F3*****")
            //{
                if (uctxtItemName.Text != "")
                {
                    strUOM = Utility.gGetBaseUOM(strComID, uctxtItemName.Text);
                    //strItemDescription = Utility.mGetItemDescription(uctxtItemName.Text);
                    mAddStockItem(uctxtItemName.Text, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), strUOM, uctxtBatch.Text);
                    uctxtItemName.Focus();
                }
            //}

        }

        private void mAddStockItem(string strItemName,  double dblQty, double dblRate, string strUom, string strBatch)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < DGSalesGrid.RowCount; j++)
            {
                if (DGSalesGrid[0, j].Value != null)
                {
                    strDown = DGSalesGrid[0, j].Value.ToString();
                }
                if (strItemName == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {

                DGSalesGrid.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DGSalesGrid.RowCount.ToString());
                selRaw = selRaw - 1;
                DGSalesGrid.Rows.Add();
               
                //DgCostCenter[0, selRaw].Value = strBranchName.ToString();
                DGSalesGrid[1, selRaw].Value = strItemName.ToString();
                DGSalesGrid[2, selRaw].Value = dblQty.ToString();
                DGSalesGrid[3, selRaw].Value = dblRate.ToString();
                DGSalesGrid[4, selRaw].Value = strUom;
                DGSalesGrid[5, selRaw].Value = (dblQty * dblRate);
                if (strBatch != Utility.gcEND_OF_LIST)
                {
                    DGSalesGrid[6, selRaw].Value = strBatch;
                }
                else
                {
                    DGSalesGrid[6, selRaw].Value = "";
                }
                DGSalesGrid[7, selRaw].Value = "Delete";
                uctxtItemName.Text = "";
                uctxtQty.Text = "";
                uctxtRate.Text = "";
                uctxtBatch.Text = "";

                DGSalesGrid.AllowUserToAddRows = false;
                calculateTotal();
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

            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = true;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
            lstBatch.ValueMember = "Key";
            lstBatch.DisplayMember = "Value";
            lstBatch.DataSource = invms.mFillBatch(strComID).ToList();

            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }

        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
        }
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            double dblrate = 0, dblBonus = 0;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
                {
                    dblrate = Utility.gdblGetEnterpriseSalesPrice(strComID, uctxtItemName.Text, dteDate.Text, Utility.Val(uctxtQty.Text.ToString()), 0, "");
                    dblBonus = Utility.mdblGetBonus(strComID, uctxtItemName.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), Utility.Val(uctxtQty.Text.ToString()), dteDate.Text);
                    uctxtRate.Text = dblrate.ToString();
                    uctxtRate.Text = dblBonus.ToString();
                    uctxtRate.Focus();
                }
                else
                {

                    dblrate = Utility.gdblPurchasePrice(uctxtItemName.Text, dteDate.Text, uctxtLocation.Text);
                    uctxtRate.Text = dblrate.ToString();
                    uctxtRate.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtQty, sender, e);
            }
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


        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
        }
        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtItemName.Text == "")
                {
                    //txtItemCode.Text = "";
                    uctxtItemName.Text = "";
                    ucdgList.Visible = false;
                    uctxtNarration.Focus();
                    return;
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
                    //ucdgList.Visible = true;
                    //ucdgList.Top = uctxtItemName.Top + 25;
                    //ucdgList.Left = uctxtItemName.Left;
                    //ucdgList.Width = uctxtItemName.Width;
                    //ucdgList.Size = new Size (546, 222);
                    //ucdgList.BringToFront();
                    //ucdgList.AllowUserToAddRows = false;
                    //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
                    //ucdgList.Focus();
                    //return;
                }
                else
                {
                    int i = 0;

                    uctxtItemName.Text = ucdgList.Rows[i].Cells[0].Value.ToString();
                    ucdgList.Visible = false;
                    uctxtQty.Focus();
                }

            }
        }


        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            ucdgList.Visible = true;
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
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
            //ucdgList.Size = new Size(546, 222);
            ucdgList.BringToFront();
            ucdgList.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }

        private void DisplayToQty(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {

                uctxtItemName.Text = tests[0].strItemName;


            }
            catch (Exception ex)
            {

            }
        }
        private void dteDuedate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstRefTypeNew.Visible = false;
            lstDesignation.Visible = false;
            ucdgList.Visible = false;
        }
        private void mloadItem()
        {
            int introw = 0;
            ucdgList.Rows.Clear();
            //oogrp = invms.mloadAddStockItem("").ToList();
            oogrp = invms.mloadAddStockItemFg(strComID, uctxtLocation.Text).ToList();
            if (oogrp.Count > 0)
            {

                foreach (StockItem ogrp in oogrp)
                {
                    ucdgList.Rows.Add();
                    ucdgList[0, introw].Value = ogrp.strItemName;
                    //DG[1, introw].Value = ogrp.strItemcode;
                    //DG[2, introw].Value = ogrp.strUnit;
                    ucdgList[1, introw].Value = ogrp.dblClsBalance;

                    //if (introw % 2 == 0)
                    //{
                    //    ucdgList.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    ucdgList.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }

                ucdgList.AllowUserToAddRows = false;
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
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
        }
        private void dteDate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
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
                    string strRefNo = "SC" +strBarchID + uctxtChallanNo.Text;
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
            //lstPartyName.SelectedIndex = lstPartyName.FindString(uctxtPartyName.Text);
        }

        private void lstPartyName_DoubleClick(object sender, EventArgs e)
        {
            //uctxtPartyName.Text = lstPartyName.Text;
            //dteDuedate.Focus();
        }

        private void uctxtPartyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 1)
                {
                    DGSalesGrid.Rows.Clear();
                    DGSalesOrder.Rows.Clear();
                    calculateTotal();
                }
                else
                {
                    if (mstrPartyName.Trim() != uctxtPartyName.Text.Trim())
                    {
                        DGSalesGrid.Rows.Clear();
                        DGSalesOrder.Rows.Clear();
                        calculateTotal();
                    }
                }
                if (uctxtPartyName.Text == "")
                {
                    //txtItemCode.Text = "";
                    uctxtPartyName.Text = "";
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
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
                        //uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        uctxtPartyName.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                        DGMr.Visible = false;
                        //uctxtCustomer.Focus();
                        uctxtCustomer.Text = "End of List";
                        uctxtLocation.Focus();
                    }
                }
                else
                {
                    int i = 0;
                    uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    uctxtPartyName.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                    //uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    //uctxtPartyName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    //uctxtCustomer.Focus();
                    uctxtCustomer.Text = "End of List";
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
            //if (e.KeyCode == Keys.Up)
            //{
            //    if (lstPartyName.SelectedItem != null)
            //    {
            //        lstPartyName.SelectedIndex = lstPartyName.SelectedIndex - 1;
            //    }
            //}
            //if (e.KeyCode == Keys.Down)
            //{
            //    if (lstPartyName.Items.Count - 1 > lstPartyName.SelectedIndex)
            //    {
            //        lstPartyName.SelectedIndex = lstPartyName.SelectedIndex + 1;
            //    }
            //}
           
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
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
            //ucdgList.Size = new Size(546, 222);
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }

        private void uctxtPartyName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = true;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
            //DGMr.Visible = fal;
            DGcustomer.Visible = false;
            mloadParty(lstBranchName.SelectedValue.ToString());
            //this.uctxtPartyName.KeyDown += new KeyEventHandler(uctxtPartyName_KeyDown);
            //lstPartyName.ValueMember = "strLedgerName";
            //lstPartyName.DisplayMember = "strLedgerName";
            //lstPartyName.DataSource = invms.mfillPartyName().ToList();


            //lstPartyName.SelectedIndex = lstPartyName.FindString(uctxtPartyName.Text);
        }
        private void DGMr_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                //uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                //uctxtPartyName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                uctxtPartyName.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                DGMr.Visible = false;
                //uctxtCustomer.Focus();
                uctxtCustomer.Text = "End of List";
                if (m_action == 1)
                {
                    DGSalesGrid.Rows.Clear();
                    DGSalesOrder.Rows.Clear();
                    calculateTotal();
                }
                else
                {
                    if (mstrPartyName.Trim() != uctxtPartyName.Text.Trim())
                    {
                        DGSalesGrid.Rows.Clear();
                        DGSalesOrder.Rows.Clear();
                        calculateTotal();
                    }
                }
                uctxtLocation.Focus();


            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtPartyName.Text = Utility.GetDgValue(DGMr, uctxtPartyName, 0);
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                //uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                //uctxtPartyName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                uctxtPartyName.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                DGMr.Visible = false;
                //uctxtCustomer.Focus();
                uctxtCustomer.Text = "End of List";
                if (m_action == 1)
                {
                    DGSalesGrid.Rows.Clear();
                    DGSalesOrder.Rows.Clear();
                    calculateTotal();
                }
                else
                {
                    if (mstrPartyName.Trim() != uctxtPartyName.Text.Trim())
                    {
                        DGSalesGrid.Rows.Clear();
                        DGSalesOrder.Rows.Clear();
                        calculateTotal();
                    }
                }
                uctxtLocation.Focus();
            }
        }
        private void txtRefTypeNew_LostFocus(object sender, System.EventArgs e)
        {
            //int i = 0;
            //double dblPrice = 0;
            //if (m_action != (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
            //{
            //    if (txtRefTypeNew.Text != Utility.gcEND_OF_LIST)
            //    {
            //        long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            //        string strBraID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            //        DGSalesGrid.Rows.Clear();
            //        for (int introw = 0; introw < DGSalesOrder.Rows.Count; introw++)
            //        {
            //            if (DGSalesOrder[0, introw].Value != null)
            //            {
            //                List<Invoice> ooinv = invms.mGetAllOrder(strComID, strBraID, lngRefType, DGSalesOrder[0, introw].Value.ToString()).ToList();
            //                if (ooinv.Count > 0)
            //                {
            //                    foreach (Invoice oinv in ooinv)
            //                    {
            //                        DGSalesGrid.Rows.Add();
            //                        DGSalesGrid[0, i].Value = oinv.dblQty;
            //                        dblPrice = Utility.gdblGetEnterpriseSalesPrice(strComID, oinv.strItemName, dteDate.Text, oinv.dblQty, 0);
            //                        DGSalesGrid[1, i].Value = oinv.strItemName;
            //                        //DGSalesGrid[2, i].Value = Utility.mGetItemDescription(oinv.strItemName);
            //                        DGSalesGrid[2, i].Value = oinv.dblQty + " " + oinv.strUom;
            //                        if (uctxtRefType.Text == "Sample Class")
            //                        {
            //                            DGSalesGrid[2, i].ReadOnly = false;
            //                        }
            //                        else
            //                        {
            //                            DGSalesGrid[2, i].ReadOnly = true;
            //                        }
            //                        DGSalesGrid[4, i].Value = oinv.strUnit;
            //                        if (lngRefType != 50)
            //                        {
            //                            //DGSalesGrid[3, i].Value = oinv.dblRate;
            //                            DGSalesGrid[3, i].Value = Math.Round(oinv.dblBillAmount, 2) / oinv.dblQty;
            //                            //DGSalesGrid[5, i].Value = Math.Round(oinv.dblQty * oinv.dblRate, 2);
            //                            DGSalesGrid[5, i].Value = Math.Round(oinv.dblBillAmount,2);
            //                        }
            //                        else
            //                        {
            //                            DGSalesGrid[3, i].Value = dblPrice;
            //                            DGSalesGrid[5, i].Value = Math.Round(oinv.dblQty * dblPrice, 2);
            //                        }
            //                        //DGSalesGrid[7, i].Value = oinv.dblDiscount;
            //                        //DGSalesGrid[8, i].Value = Math.Round((oinv.dblQty * dblPrice) - oinv.dblDiscount, 2);
            //                        DGSalesGrid[6, i].Value = oinv.strBatch;
            //                        DGSalesGrid[7, i].Value = "Delete";
            //                        DGSalesGrid[8, i].Value = Utility.gstrGetBillKey(strComID, DGSalesOrder[1, introw].Value.ToString(), oinv.strItemName);
            //                        DGSalesGrid[9, i].Value = DGSalesOrder[0, introw].Value.ToString();
            //                        DGSalesGrid[10, i].Value = oinv.dblBonusQty;
            //                        i += 1;
            //                    }
            //                    DGSalesGrid.AllowUserToAddRows = false;
            //                }
            //                uctxtNarration.Text = DGSalesOrder[0, introw].Value.ToString();
            //            }
            //            txtTotalItem.Text = "Total Item: " + i.ToString();
            //            txtNoofOrder.Text = "Total Invoice: " + (introw + 1).ToString();
                        
            //            calculateTotal();
            //        }
            //    }
            //}
        }
        private void txtRefTypeNew_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = true;
            ucdgList.Visible = false;
            lstRefTypeNew.Top = txtRefTypeNew.Top + 25;
            lstRefTypeNew.Left = txtRefTypeNew.Left;
            lstRefTypeNew.Width = txtRefTypeNew.Width;
            lstRefTypeNew.Height = 200;
            //ucdgList.Size = new Size(546, 222);
            lstRefTypeNew.BringToFront();
            lstRefTypeNew.AllowUserToAddRows = false;

            //long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            //if (uctxtLocation.Text != "")
            //{
            //    mLoadAllItemOrder(uctxtPartyName.Text, lngRefType, dteDate.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), uctxtLocation.Text);
            //}
           
        }
       
        private void txtRefTypeNew_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F3)
            //{
            //    lstRefType.Visible = false;
            //    long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
            //    frmAllReferance objfrm = new frmAllReferance();
            //    objfrm.strPartyname = uctxtPartyName.Text;
            //    objfrm.strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);;
            //    objfrm.strDate = dteDate.Text;
            //    objfrm.lngVtype = lngRefType;
            //    objfrm.onAddAllButtonClicked = new frmAllReferance.AddAllClick(DisplayReferance);
            //    objfrm.Show();
            //    objfrm.MdiParent = MdiParent;
            //}
            lstRefTypeNew.Visible = true;
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
            if (e.KeyCode == Keys.Up)
            {
                lstRefTypeNew.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                lstRefTypeNew.Focus();
            }

            lstRefTypeNew.Top = txtRefTypeNew.Top + 25;
            lstRefTypeNew.Left = txtRefTypeNew.Left;
            lstRefTypeNew.Width = txtRefTypeNew.Width;
            lstRefTypeNew.Height = 200;
            //ucdgList.Size = new Size(546, 222);
            lstRefTypeNew.BringToFront();
            lstRefTypeNew.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;


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
                        //txtItemCode.Text = "";
                        txtRefTypeNew.Text = "";
                        lstRefTypeNew.Visible = false;
                        mloadOrder();
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
                            //i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());
                            strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                            strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                            strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                            DisplayReferance(strBillKey, strRefNo, strDate);
                            lstRefTypeNew.Visible = false;
                            txtRefTypeNew.Focus();
                            lstRefTypeNew.Rows.RemoveAt(i);
                        }
                    }
                    else
                    {
                        int i = 0;
                       // i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());
                        foreach (DataGridViewRow row in lstRefTypeNew.SelectedRows)
                        {
                            i = Convert.ToInt16(row.Index);
                        }

                        txtRefTypeNew.Text = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                        //i = Convert.ToInt16(lstRefTypeNew.CurrentRow.Index.ToString());
                        strBillKey = lstRefTypeNew.Rows[i].Cells[0].Value.ToString();
                        strRefNo = lstRefTypeNew.Rows[i].Cells[1].Value.ToString();
                        strDate = lstRefTypeNew.Rows[i].Cells[2].Value.ToString();
                        DisplayReferance(strBillKey, strRefNo, strDate);
                        lstRefTypeNew.Visible = false;
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
        private void mloadOrder()
        {
            int i = 0;
            double dblPrice = 0;
            if (m_action != (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
            {
                if (txtRefTypeNew.Text != Utility.gcEND_OF_LIST)
                {
                    long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                    string strBraID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
                    DGSalesGrid.Rows.Clear();
                  
                    for (int introw = 0; introw < DGSalesOrder.Rows.Count; introw++)
                    {
                        if (DGSalesOrder[0, introw].Value != null)
                        {
                            List<Invoice> ooinv = invms.mGetAllOrder(strComID, strBraID, lngRefType, DGSalesOrder[0, introw].Value.ToString()).ToList();
                            if (ooinv.Count > 0)
                            {
                                foreach (Invoice oinv in ooinv)
                                {
                                    DGSalesGrid.Rows.Add();
                                    DGSalesGrid[0, i].Value = oinv.dblQty;
                                    dblPrice = Utility.gdblGetEnterpriseSalesPrice(strComID, oinv.strItemName, dteDate.Text, oinv.dblQty, 0);
                                    DGSalesGrid[1, i].Value = oinv.strItemName;
                                    //DGSalesGrid[2, i].Value = Utility.mGetItemDescription(oinv.strItemName);
                                    DGSalesGrid[2, i].Value = oinv.dblQty + " " + oinv.strUom;
                                    if (uctxtRefType.Text == "Sample Class")
                                    {
                                        DGSalesGrid[2, i].ReadOnly = false;
                                    }
                                    else
                                    {
                                        DGSalesGrid[2, i].ReadOnly = true;
                                    }
                                    DGSalesGrid[4, i].Value = oinv.strUnit;
                                    if (lngRefType != 50)
                                    {
                                        //DGSalesGrid[3, i].Value = oinv.dblRate;
                                        DGSalesGrid[3, i].Value = Math.Round(oinv.dblBillAmount, 2) / oinv.dblQty;
                                        //DGSalesGrid[5, i].Value = Math.Round(oinv.dblQty * oinv.dblRate, 2);
                                        DGSalesGrid[5, i].Value = Math.Round(oinv.dblBillAmount, 2);
                                    }
                                    else
                                    {
                                        DGSalesGrid[3, i].Value = dblPrice;
                                        DGSalesGrid[5, i].Value = Math.Round(oinv.dblQty * dblPrice, 2);
                                    }
                                    //DGSalesGrid[7, i].Value = oinv.dblDiscount;
                                    //DGSalesGrid[8, i].Value = Math.Round((oinv.dblQty * dblPrice) - oinv.dblDiscount, 2);
                                    DGSalesGrid[6, i].Value = oinv.strBatch;
                                    DGSalesGrid[7, i].Value = "Delete";
                                    DGSalesGrid[8, i].Value = Utility.gstrGetBillKey(strComID, DGSalesOrder[1, introw].Value.ToString(), oinv.strItemName);
                                    DGSalesGrid[9, i].Value = DGSalesOrder[0, introw].Value.ToString();
                                    DGSalesGrid[10, i].Value = oinv.dblBonusQty;
                                    i += 1;
                                }
                                DGSalesGrid.AllowUserToAddRows = false;
                            }
                          
                            if (uctxtRefType.Text == "Sample Class")
                            {
                                uctxtNarration.Text = DGSalesOrder[0, introw].Value.ToString();
                            }
                            else
                            {
                                uctxtNarration.Text = "";
                            }
                        }
                        txtTotalItem.Text = "Total Item: " + i.ToString();
                        txtNoofOrder.Text = "Total Invoice: " + (introw + 1).ToString();

                        calculateTotal();
                    }
                }
            }
        }

        private void uctxtRefType_TextChanged(object sender, EventArgs e)
        {
            lstRefType.SelectedIndex = lstRefType.FindString(uctxtRefType.Text);
        }

        private void lstRefType_DoubleClick(object sender, EventArgs e)
        {
            uctxtRefType.Text = lstRefType.Text;
            if (uctxtRefType.Text != Utility.gcEND_OF_LIST)
            {
                txtRefTypeNew.Focus();
            }
            else
            {
                uctxtItemName.Focus();
            }
        }

        private void uctxtRefType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstRefType.Items.Count > 0)
                {
                    uctxtRefType.Text = lstRefType.Text;
                }
                if (uctxtRefType.Text != Utility.gcEND_OF_LIST)
                {
                    long lngRefType = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                    if (uctxtLocation.Text != "")
                    {
                        mLoadAllItemOrder(uctxtTeritoryCode.Text, lngRefType, dteDate.Text, Utility.gstrGetBranchID(strComID, uctxtBranchName.Text), uctxtLocation.Text,"");
                    }
                    txtRefTypeNew.Focus();
                }
                else
                {
                    uctxtItemName.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtRefType, sender, e);
            }
        }

        private void DisplayReferance(string strBillKey,string strRefNo,string strDate)
        {
            try
            {

                //uctxtItemName.Text = tests[0].strItemName;
                int selRaw;
                // string strSalesOrder = "";

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
                    calculateTotal();
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
            lstRefTypeNew.Visible = false;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
            lstRefType.SelectedIndex = lstRefType.FindString(uctxtRefType.Text);
        }
        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            //if (uctxtLocation.Text != "")
            //{
            //    mLoadAllItem();
            //}
            uctxtTransport.Focus();
        }

        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                    //if (uctxtLocation.Text != "")
                    //{
                    //    mLoadAllItem();
                    //}
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
        private void mLoadAllItem()
        {
            int introw = 0;
            //var data = bbSc.GetBBTestFeeMaps(feecat).ToList();

            oogrp = invms.mloadAddStockItemFg(strComID, uctxtLocation.Text).ToList();
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
                    ucdgList.Rows.Add();
                    ucdgList[0, introw].Value = ogrp.strItemName;
                    ucdgList[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;

                    //if (introw % 2 == 0)
                    //{
                    //    ucdgList.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    ucdgList.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                ucdgList.AllowUserToAddRows = false;
            }


        }
        private void uctxtLocation_GotFocus(object sender, System.EventArgs e)
        {

            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = true;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;

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
                    if (strCheckName =="")
                    {
                        uctxtPartyName.Text ="";
                        uctxtTeritorryName.Text ="";
                        uctxtTeritoryCode.Text ="";
                        uctxtCustomer.Text ="";
                        uctxtHomeohall.Text ="";
                        uctxtCustomerAddress.Text ="";
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
            lstBatch.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            lstRefTypeNew.Visible = false;
            ucdgList.Visible = false;
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
                ooPartyName = invms.mfillPartyNameNew(strComID, strBranchID, Utility.gblnAccessControl, Utility.gstrUserName, 0, "").ToList();

                if (ooPartyName.Count > 0)
                {

                    foreach (Invoice ogrp in ooPartyName)
                    {
                        DGMr.Rows.Add();
                        DGMr[0, introw].Value = ogrp.strTeritorryCode;
                        DGMr[1, introw].Value = ogrp.strTeritorryName;
                        DGMr[2, introw].Value = ogrp.strLedgerName;
                        DGMr[3, introw].Value = ogrp.strMereString;
                        //if (introw % 2 == 0)
                        //{
                        //    DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                        //}
                        //else
                        //{
                        //    DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                        //}
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
        private void frmSalesChallan_Load(object sender, EventArgs e)
        {
            lstPartyName.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstRefType.Visible = false;
            lstBatch.Visible = false;
            lstCustomer.Visible = false;
            lstTransport.Visible = false;
            lstDesignation.Visible = false;
            ucdgList.Visible = false;
            uctxtRefType.Enabled = false;
            DGSalesGrid.AllowUserToAddRows = false;
            mGetConfig();
            mClear();
          
            if (mblnNumbMethod==true)
            {
                uctxtChallanNo.ReadOnly = true;
                uctxtBranchName.Focus();
                uctxtBranchName.Select();
            }
            else
            {
                uctxtBranchName.Focus();
                uctxtBranchName.Select();
            }
            LoadDefaultValue();
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
           // oinv = invms.mGetInvoiceConfigNew().ToList();
            
            this.lstRefTypeNew.DefaultCellStyle.Font = new Font("verdana", 10F);
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Bill Key", "Bill. Key", 350, false, DataGridViewContentAlignment.TopLeft, true));
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Ref. No", "Ref. No", 150, true, DataGridViewContentAlignment.TopLeft, true));
            lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
            //lstRefTypeNew.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
           
           
        }
        #endregion
        #region "Item Order"
        private void mLoadAllItemOrder(string strPartyname, long lngVtype, string strDate, string strBranchID,string strLocation,string strRefNo)
        {
            int introw = 0;
            //this.lstRefTypeNew.DefaultCellStyle.Font = new Font("verdana", 9);
            lstRefTypeNew.Rows.Clear();
            if (lngVtype != (int)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
            {
                ooRefNo = accms.gFillPreRefNo(strComID, strPartyname, lngVtype, strDate, strBranchID, strLocation, strRefNo,0).ToList();
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
                  {Utility.gcEND_OF_LIST, 1},
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
        private bool ValidateFields()
        {
            double dblClosingQTY = 0, dblCurrentQTY = 0,dblBillQty=0;
            string strBillKey = "", strNegetiveItem = "";
            int intCheckNegetive = 0;


            if (uctxtPartyName.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtPartyName.Focus();
                return false;
            }
            if (uctxtChallanNo.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtChallanNo.Focus();
                return false;
            }
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtBranchName.Focus();
                return false;
            }
            if (DGSalesGrid.Rows.Count == 0)
            {
                MessageBox.Show("Item Cannot be Empty");
                uctxtItemName.Focus();
                return false;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return false;
                }
            }
            if (uctxtRefType.Text != "Sample Class")
            {
                if (Utility.Val(lblNetTotal.Text) == 0 || Utility.Val(lblNetTotal.Text) < 0)
                {
                    MessageBox.Show("Net Amount Cannot be Empty");
                    uctxtItemName.Focus();
                    return false;
                }
               
            }
            else
            {
                if (uctxtNarration.Text =="")
                {
                    uctxtNarration.Text = "Sample Class";
                }
                
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

            //string strBacklockDate = Utility.gCheckBackLock(strComID);
            //if (strBacklockDate != "")
            //{
            //    long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strBacklockDate).ToString("yyyyMMdd"));
            //    if (lngDate <= lngBackdate)
            //    {
            //        MessageBox.Show("Invalid Date, Back Date is locked");
            //        return false;
            //    }
            //}
            //if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
            //{
            //    if (intVtype != (int)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
            //    {

            //        for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
            //        {
            //            if (DGSalesGrid[0, i].Value != null)
            //            {
            //                dblBillQty = Utility.Val(DGSalesGrid[0, i].Value.ToString());
            //                dblCurrentQTY = Utility.Val(DGSalesGrid[2, i].Value.ToString());
            //                if (dblCurrentQTY > dblBillQty)
            //                {
            //                    MessageBox.Show("Current Qty Cannot be Grater than Your Bill Qty");
            //                    DGSalesGrid.Focus();
            //                    return false;
            //                }
            //            }
            //            dblCurrentQTY = 0;
            //            dblBillQty = 0;
            //        }
            //    }
            //}


         
            if (oinv[0].mlngBlockNegativeStock > 0)
            {
                for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
                {
                    if (DGSalesGrid[1, i].Value != null)
                    {
                        
                        if (DGSalesGrid[8, i].Value!=null)
                        {
                            strBillKey = DGSalesGrid[8, i].Value.ToString();
                        }
                        else
                        {
                            strBillKey = "";
                        }
                        if (uctxtRefType.Text == "Sample Class")
                        {
                            dblClosingQTY = Utility.gdblClosingStockNew(strComID, DGSalesGrid[1, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                        }
                        else
                        {
                            dblClosingQTY = Utility.gdblClosingStock(strComID, DGSalesGrid[1, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                        }
                        
                        if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                        {
                            dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                        }
                        dblCurrentQTY = Utility.Val(DGSalesGrid[2, i].Value.ToString());
                        if ((dblClosingQTY) - dblCurrentQTY < 0)
                        {
                            strNegetiveItem = strNegetiveItem + Environment.NewLine + DGSalesGrid[1, i].Value.ToString() + " (Voucher Qty: " + dblCurrentQTY + " Closing Qty : " + dblClosingQTY + ")" ;
                            intCheckNegetive = 1;
                            dblClosingQTY = 0;
                        }
                    }
                    dblClosingQTY = 0;
                }
            }
            if (intCheckNegetive > 0)
            {
                MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                DGSalesGrid.Focus();
                return false;
            }

          
            return true;
        }
        #endregion
        #region "Save"
        private string mSaveSalesChallanNew()
        {
            string strSQL = "",  strBarchID = "", strRefNumber = "", strAgnstRefNo, strRefNo;
            double dblCostPrice = 0, dblBonusQty = 0;
            long lngAgstRef;
            string strBillKey = "";
            long lngloop = 1;
            SqlDataReader dr;
            double dblTotalCost = 1, dblAltWhere = 1;
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                try
                {
                    lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                    strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
                    gcnMain.Open();
                    //SqlDataReader rsget;
                    SqlCommand cmdInsert = new SqlCommand();
                    SqlTransaction myTrans;
                    myTrans = gcnMain.BeginTransaction();
                    cmdInsert.Connection = gcnMain;
                    cmdInsert.Transaction = myTrans;

                    if (mblnNumbMethod == false)
                    {
                        strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + uctxtChallanNo.Text;
                    }
                    else
                    {
                        strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + Utility.gstrLastNumber(strComID, intVtype);
                    }

                    strSQL = VoucherSW.gInsertCompanyVoucherNew(strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, dteDate.Value.ToString("MMMyy"), dteDuedate.Text, uctxtTeritoryCode.Text, Utility.Val(lblNetTotal.Text), Utility.Val(lblNetTotal.Text), 0, 0, lngAgstRef, Utility.gCheckNull(uctxtNarration.Text),
                                                        strBarchID, 0, "", uctxtCustomer.Text, "", "", "", "", uctxtTrNo.Text, "", "", "", "", uctxtDesignation.Text, uctxtTransport.Text, Utility.Val(uctxtcrtQty.Text), Utility.Val(uctxtBoxQty.Text));

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = VoucherSW.gInteractInvInsertMaster(uctxtTeritoryCode.Text, strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, strBarchID, Utility.gCheckNull(uctxtNarration.Text));
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
                    {
                        strBillKey = strRefNumber + lngloop.ToString().PadLeft(4, '0');
                        //////dblCostPrice = Utility.gdblGetCostPrice(strComID, DGSalesGrid[1, i].Value.ToString(), dteDate.Text);
                        strSQL = "SELECT ISNULL(SUM(INV_TRAN_QUANTITY),0) AS QTY,ISNULL(SUM(INV_TRAN_AMOUNT),0) AS AMT FROM INV_STOCKITEM_TRAN_QRY ";
                        strSQL = strSQL + "WHERE (INV_INOUT_FLAG IS NULL OR INV_INOUT_FLAG = 'I') ";
                        strSQL = strSQL + "AND STOCKITEM_NAME = '" + DGSalesGrid[1, i].Value.ToString() + "' ";
                        strSQL = strSQL + "AND INV_DATE <= " + Utility.cvtSQLDateString(dteDate.Text) + " ";
                        cmdInsert.CommandText = strSQL;
                        dr = cmdInsert.ExecuteReader();
                        if (dr.Read())
                        {
                            if (Utility.Val(dr["QTY"].ToString()) > 0)
                            {
                                dblCostPrice = Math.Round(Utility.Val(dr["AMT"].ToString()) / Utility.Val(dr["QTY"].ToString()), 2);
                            }
                        }
                        else
                        {
                            dblCostPrice = 0;
                        }
                        dr.Close();
                        strSQL = "";
                        if (DGSalesGrid[8, i].Value != null)
                        {
                            strAgnstRefNo = DGSalesGrid[8, i].Value.ToString();
                        }
                        else
                        {
                            strAgnstRefNo = "";
                        }

                        if (DGSalesGrid[9, i].Value != null)
                        {
                            strRefNo = DGSalesGrid[9, i].Value.ToString();
                        }
                        else
                        {
                            strRefNo = "";
                        }
                        if (DGSalesGrid[10, i].Value != null)
                        {
                            dblBonusQty = Utility.Val(DGSalesGrid[10, i].Value.ToString());
                        }
                        else
                        {
                            dblBonusQty = 0;
                        }

                        //strDGSales = strDGSales + Utility.gCheckNull(DGSalesGrid[1, i].Value.ToString()) + "|" +//Item
                        //                                            Utility.Val(DGSalesGrid[2, i].Value.ToString()) + "|" +//qty
                        //                                            Utility.Val(DGSalesGrid[3, i].Value.ToString()) + "|" +//rate
                        //                                            Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()) + "|" + //Unit
                        //                                            Utility.Val(DGSalesGrid[5, i].Value.ToString()) + "|" + //amount
                        //                                            Utility.gCheckNull(DGSalesGrid[6, i].Value.ToString()) + "|" //Batch
                        //                                            + dblCostPrice + "|" //cost price
                        //                                            + strAgnstRefNo + "|" //Bill Key
                        //                                            + strRefNo + "|" + dblBonusQty + " ~"; //Ref

                        //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";

                        strSQL = VoucherSW.gInsertBillTran(strBillKey, strRefNumber, Convert.ToInt64(intVtype), dteDate.Text, DGSalesGrid[1, i].Value.ToString(), uctxtLocation.Text, Utility.Val(DGSalesGrid[2, i].Value.ToString()),
                                                            dblBonusQty, Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()), Utility.Val(DGSalesGrid[3, i].Value.ToString()),
                                                            Utility.Val(DGSalesGrid[5, i].Value.ToString()), "",
                                                                    0, Utility.Val(DGSalesGrid[5, i].Value.ToString()), "Cr", lngloop, strBarchID, Utility.gstrBaseCurrency,
                                                                    Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()), "", "",
                                                                    Utility.gCheckNull(DGSalesGrid[6, i].Value.ToString()), "", "", "", "", 0, 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = VoucherSW.gInsertBillTranProcess(strBillKey, strBarchID, lngloop, strRefNumber, strRefNumber, Convert.ToInt64(intVtype), dteDate.Text,
                                                                DGSalesGrid[1, i].Value.ToString(), uctxtLocation.Text, Utility.Val(DGSalesGrid[2, i].Value.ToString()),
                                                                Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()), strAgnstRefNo, 0, 0, Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()));
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
                        {
                            strSQL = VoucherSW.gInsertBillTranProcess(strBillKey, strBarchID, lngloop, strRefNumber, strRefNo, lngAgstRef, dteDate.Text,
                                                                    DGSalesGrid[1, i].Value.ToString(), uctxtLocation.Text, Utility.Val(DGSalesGrid[2, i].Value.ToString()) * -1,
                                                                    Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()), strAgnstRefNo, 0, 0, Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()));
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            strSQL = VoucherSW.gInventoryInsertTranSalesChallan(strRefNumber, strBillKey, lngloop, Math.Round(Utility.Val(DGSalesGrid[3, i].Value.ToString()), 2), -1 * dblTotalCost, lngAgstRef,
                                                                                DGSalesGrid[1, i].Value.ToString(), uctxtLocation.Text,
                                                                        "O", Utility.Val(DGSalesGrid[2, i].Value.ToString()) * -1, dblBonusQty * -1, dblCostPrice, Convert.ToInt64(intVtype), dteDate.Text,
                                                                        strBarchID, Utility.gCheckNull(DGSalesGrid[6, i].Value.ToString()), 0, Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()), Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()));
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                        else if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                        {
                            strSQL = VoucherSW.gInventoryInsertTranSalesChallanClass(strRefNumber, strBillKey, lngloop, Math.Round(Utility.Val(DGSalesGrid[3, i].Value.ToString()), 2), -1 * dblTotalCost,
                                                                                    lngAgstRef, DGSalesGrid[1, i].Value.ToString(), uctxtLocation.Text,
                                                                                    "O", Utility.Val(DGSalesGrid[2, i].Value.ToString()) * -1, dblBonusQty * -1, dblCostPrice, Convert.ToInt64(intVtype),
                                                                                    dteDate.Text, strBarchID, Utility.gCheckNull(DGSalesGrid[6, i].Value.ToString()), 0,
                                                                                    Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()), Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()));
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        else
                        {
                            strSQL = VoucherSW.gInventoryInsertTranSalesChallan(strRefNumber, strBillKey, lngloop, Math.Round(Utility.Val(DGSalesGrid[3, i].Value.ToString()) / dblAltWhere, 2), -1 * dblTotalCost, lngAgstRef, DGSalesGrid[1, i].Value.ToString(),
                                                                        uctxtLocation.Text, "O", Utility.Val(DGSalesGrid[2, i].Value.ToString()) * -1, dblBonusQty * -1, dblCostPrice,
                                                                        Convert.ToInt64(intVtype), dteDate.Text, strBarchID, Utility.gCheckNull(DGSalesGrid[6, i].Value.ToString()), 0, Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()), Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()));
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                        lngloop += 1;

                    }
                    for (int i = 0; i < DGSalesOrder.Rows.Count; i++)
                    {
                        if (DGSalesOrder[0, i].Value != null)
                        {
                            //strDGSalesOrder = strDGSalesOrder + Utility.gCheckNull(DGSalesOrder[0, i].Value.ToString()) + "|" +
                            //                                            Utility.gCheckNull(DGSalesOrder[1, i].Value.ToString()) + "|" +
                            //                                            Utility.gCheckNull(DGSalesOrder[2, i].Value.ToString()) + "~";
                            if (uctxtRefType.Text != "Sample Class")
                            {
                                strSQL = "SELECT SUM(BILL_QUANTITY) AS QTY FROM ACC_BILL_TRAN_PROCESS ";
                                strSQL = strSQL + "WHERE AGST_COMP_REF_NO = '" + DGSalesOrder[0, i].Value.ToString() + "'";
                                cmdInsert.CommandText = strSQL;
                                dr = cmdInsert.ExecuteReader();
                                if (dr.Read())
                                {

                                    if (Utility.Val(dr["QTY"].ToString()) == 0)
                                    {
                                        dr.Close();
                                        strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
                                        strSQL = strSQL + "WHERE COMP_REF_NO = '" + DGSalesOrder[0, i].Value.ToString() + "'";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        dr.Close();
                                        strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
                                        strSQL = strSQL + "WHERE COMP_REF_NO = '" + DGSalesOrder[0, i].Value.ToString() + "'";
                                        cmdInsert.CommandText = strSQL;
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    dr.Close();
                                }

                                strSQL = "INSERT INTO ACC_VOUCHER_JOIN(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID) ";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + strRefNumber + "','" + DGSalesOrder[0, i].Value.ToString() + "','" + strBarchID + "'";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                            else
                            {
                                strSQL = "INSERT INTO ACC_VOUCHER_JOIN_CLASS(VOUCHER_JOIN_PRIMARY_REF,VOUCHER_JOIN_FOREIGN_REF,BRANCH_ID,CLASS_NAME) ";
                                strSQL = strSQL + "VALUES(";
                                strSQL = strSQL + "'" + strRefNumber + "','" + strRefNumber + "','" + strBarchID + "','" + "SC" + strBarchID + DGSalesOrder[0, i].Value.ToString() + "' ";
                                strSQL = strSQL + ")";
                                cmdInsert.CommandText = strSQL;
                                cmdInsert.ExecuteNonQuery();
                            }
                        }

                    }

                    if (lngAgstRef == (long)Utility.VOUCHER_TYPE.vt_SAMPLE_CLASS)
                    {
                        strSQL = "UPDATE INV_TRAN SET ";
                        strSQL = strSQL + "OUTWARD_SALES_AMOUNT= 0 ";
                        strSQL = strSQL + ",INV_TRAN_RATE= 0 ";
                        //strSQL = strSQL + ",OUTWARD_COST_AMOUNT= 0 ";
                        // strSQL = strSQL + ",INV_TRAN_AMOUNT= 0 ";
                        strSQL = strSQL + " WHERE INV_TRAN_KEY='" + strBillKey + "' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    else
                    {
                        strSQL = "UPDATE ACC_COMPANY_VOUCHER SET COMP_VOUCHER_STATUS = 1 ";
                        strSQL = strSQL + "WHERE COMP_REF_NO = '" + strRefNumber + "'";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, "Sales Challan", uctxtChallanNo.Text,
                                                                1, 0, (int)Utility.MODULE_TYPE.mtSALES, strBarchID);
                    }
                    if (mblnNumbMethod == true)
                    {
                        strSQL = VoucherSW.gIncreaseVoucher((int)intVtype);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    cmdInsert.Transaction.Commit();
                    return "Inserted...";
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    return ex.ToString();
                }
                finally
                {
                    gcnMain.Close();
                    
                }
                

            }


        }
        private string mSaveSalesChallan()
        {
            string strDGSales = "", strDGSalesOrder = "", strBarchID = "", strRefNumber = "", strAgnstRefNo, strRefNo;
            double dblCostPrice = 0,dblBonusQty=0;
            long lngAgstRef;
            try
            {
                for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
                {
                    dblCostPrice = Utility.gdblGetCostPrice(strComID, DGSalesGrid[1, i].Value.ToString(), dteDate.Text);
                    if (DGSalesGrid[8, i].Value != null)
                    {
                        strAgnstRefNo = DGSalesGrid[8, i].Value.ToString();
                    }
                    else
                    {
                        strAgnstRefNo = "";
                    }

                    if (DGSalesGrid[9, i].Value != null)
                    {
                        strRefNo = DGSalesGrid[9, i].Value.ToString();
                    }
                    else
                    {
                        strRefNo = "";
                    }
                    if (DGSalesGrid[10, i].Value != null)
                    {
                        dblBonusQty = Utility.Val(DGSalesGrid[10, i].Value.ToString());
                    }
                    else
                    {
                        dblBonusQty = 0;
                    }

                    strDGSales = strDGSales + Utility.gCheckNull(DGSalesGrid[1, i].Value.ToString()) + "|" +//Item
                                                                Utility.Val(DGSalesGrid[2, i].Value.ToString()) + "|" +//qty
                                                                Utility.Val(DGSalesGrid[3, i].Value.ToString()) + "|" +//rate
                                                                Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()) + "|" + //Unit
                                                                Utility.Val(DGSalesGrid[5, i].Value.ToString()) + "|" + //amount
                                                                Utility.gCheckNull(DGSalesGrid[6, i].Value.ToString()) + "|" //Batch
                                                                + dblCostPrice + "|" //cost price
                                                                + strAgnstRefNo + "|" //Bill Key
                                                                + strRefNo + "|" + dblBonusQty + " ~"; //Ref

                    //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";
                }

                for (int i = 0; i < DGSalesOrder.Rows.Count; i++)
                {
                    if (DGSalesOrder[0, i].Value != null)
                    {
                        strDGSalesOrder = strDGSalesOrder + Utility.gCheckNull(DGSalesOrder[0, i].Value.ToString()) + "|" +
                                                                    Utility.gCheckNull(DGSalesOrder[1, i].Value.ToString()) + "|" +
                                                                    Utility.gCheckNull(DGSalesOrder[2, i].Value.ToString()) + "~";
                    }
                }

                lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

                if (mblnNumbMethod == false)
                {
                    strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + uctxtChallanNo.Text;
                }
                else
                {
                    strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBarchID + Utility.gstrLastNumber(strComID, intVtype);
                }

                string strMsg = objWIS.mSaveSalesChallan(strComID, strRefNumber, intVtype, dteDate.Text, dteDuedate.Text, dteDate.Value.ToString("MMMyy"), uctxtPartyName.Text,
                                                    Utility.Val(lblNetTotal.Text), uctxtRefType.Text, lngAgstRef, 0, Utility.gCheckNull(uctxtNarration.Text), strBarchID,
                                                    Utility.gCheckNull(uctxtLocation.Text), strDGSales, strDGSalesOrder,mblnNumbMethod,uctxtCustomer.Text,uctxtDesignation.Text,
                                                    uctxtTransport.Text, Utility.Val(uctxtcrtQty.Text),Utility.Val(uctxtBoxQty.Text),uctxtTrNo.Text);
                if (Utility.gblnAccessControl)
                {
                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, "Sales Challan", uctxtChallanNo.Text,
                                                            1, 0, (int)Utility.MODULE_TYPE.mtSALES, strBarchID);
                } 
                return strMsg;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                
            }
            
        }
        #endregion
        #region "Update"
        private string mUpdateSalesChallan()
        {
            string strDGSales = "", strDGSalesOrder = "", strBarchID = "", strAgnstRefNo = "", strRefNo="";
            long lngAgstRef;
            double dblCostPrice, dblBonusQty=0;
            try
            {
                //for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
                //{
                //    dblCostPrice = Utility.gdblGetCostPrice(strComID, DGSalesGrid[1, i].Value.ToString(), dteDate.Text);
                //    strDGSales = strDGSales + Utility.gCheckNull(DGSalesGrid[1, i].Value.ToString()) + "," +//Item
                //                                                Utility.Val(DGSalesGrid[2, i].Value.ToString()) + "," +//qty
                //                                                Utility.Val(DGSalesGrid[3, i].Value.ToString()) + "," +//rate
                //                                                Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()) + "," + //Unit
                //                                                Utility.Val(DGSalesGrid[5, i].Value.ToString()) + "," + //amount
                //                                                Utility.gCheckNull(DGSalesGrid[6, i].Value.ToString()) + "," //Batch
                //                                                + dblCostPrice + "~"; //cost price
                //                                                //+ Utility.gCheckNull(DGSalesGrid[8, i].Value.ToString()) + "," //Bill Key
                //                                                //+ Utility.gCheckNull(DGSalesGrid[9, i].Value.ToString()) + " ~"; //Ref

                //    //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";
                //}
                for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
                {
                    dblCostPrice = Utility.gdblGetCostPrice(strComID, DGSalesGrid[1, i].Value.ToString(), dteDate.Text);
                    if (DGSalesGrid[8, i].Value != null)
                    {
                        strAgnstRefNo = DGSalesGrid[8, i].Value.ToString();
                    }
                    else
                    {
                        strAgnstRefNo = "";
                    }

                    if (DGSalesGrid[9, i].Value != null)
                    {
                        strRefNo = DGSalesGrid[9, i].Value.ToString();
                    }
                    else
                    {
                        strRefNo = "";
                    }
                    if (DGSalesGrid[10, i].Value != null)
                    {
                        dblBonusQty = Utility.Val(DGSalesGrid[10, i].Value.ToString());
                    }
                    else
                    {
                        dblBonusQty = 0;
                    }

                    strDGSales = strDGSales + Utility.gCheckNull(DGSalesGrid[1, i].Value.ToString()) + "|" +//Item
                                                                Utility.Val(DGSalesGrid[2, i].Value.ToString()) + "|" +//qty
                                                                Utility.Val(DGSalesGrid[3, i].Value.ToString()) + "|" +//rate
                                                                Utility.gCheckNull(DGSalesGrid[4, i].Value.ToString()) + "|" + //Unit
                                                                Utility.Val(DGSalesGrid[5, i].Value.ToString()) + "|" + //amount
                                                                Utility.gCheckNull(DGSalesGrid[6, i].Value.ToString()) + "|" //Batch
                                                                + dblCostPrice + "|" //cost price
                                                                + strAgnstRefNo + "|" //Bill Key
                                                                + strRefNo + "|" + dblBonusQty + " ~"; //Ref

                    //Utility.gCheckNull(DGSalesGrid[10, i].Value.ToString()) + "~";
                }
                for (int i = 0; i < DGSalesOrder.Rows.Count; i++)
                {
                    if (DGSalesOrder[0, i].Value != null)
                    {
                        strDGSalesOrder = strDGSalesOrder + Utility.gCheckNull(DGSalesOrder[0, i].Value.ToString()) + "|" +
                                                                    Utility.gCheckNull(DGSalesOrder[1, i].Value.ToString()) + "|" +
                                                                    Utility.gCheckNull(DGSalesOrder[2, i].Value.ToString()) + "~";
                    }
                }

                lngAgstRef = gobjVoucherName.VoucherName.GetVoucherType(uctxtRefType.Text);
                strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

                string strMsg = objWIS.mUpdateSalesChallan(strComID, txtOldRefNo.Text, uctxtChallanNo.Text, intVtype, dteDate.Text, dteDuedate.Text, dteDate.Value.ToString("MMMyy"), uctxtTeritoryCode.Text,
                                                    Utility.Val(lblNetTotal.Text), uctxtRefType.Text, lngAgstRef, 0, Utility.gCheckNull(uctxtNarration.Text), strBarchID,
                                                    Utility.gCheckNull(uctxtLocation.Text), strDGSales, strDGSalesOrder,
                                                    uctxtCustomer.Text, uctxtDesignation.Text,
                                                    uctxtTransport.Text, Utility.Val(uctxtcrtQty.Text), Utility.Val(uctxtBoxQty.Text), uctxtTrNo.Text);
                if (Utility.gblnAccessControl)
                {
                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteDate.Text, "Sales Challan", uctxtChallanNo.Text,
                                                            2, 0, (int)Utility.MODULE_TYPE.mtSALES, strBarchID);
                } 
                return strMsg;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {

            }

        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            uctxtPartyName.Text = "";
            //uctxtBranchName.Text = "";
            txtNoofOrder.Text = "";
            txtTotalItem.Text = "";
            //uctxtLocation.Text = "Main Location";
            //uctxtRefType.Text = "";
            uctxtNarration.Text = "";
            lblNetTotal.Text = "";
            lblQuantityTotal.Text = "";
            uctxtDesignation.Text = "";
            //uctxtTrNo.Text = "";
            uctxtTransport.Text = "";
            //uctxtcrtQty.Text = "";
            uctxtBoxQty.Text = "";
            uctxtCustomer.Text = "";
            DGSalesGrid.Rows.Clear();
            DGSalesOrder.Rows.Clear();
            DGSalesOrder.Enabled = true;
            DGSalesGrid.Enabled = true;
            uctxtRefType.Enabled = true;
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod==true)
            {
                uctxtChallanNo.Text = Utility.gstrLastNumber(strComID, intVtype);
            }
            else
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
                {
                    uctxtChallanNo.Text = "";
                    //uctxtChallanNo.Text = Interaction.GetSetting(Application.ExecutablePath, "frmSalesChallan", "VoucherNoSC");
                    uctxtChallanNo.AppendText ((String)rk.GetValue("VoucherNoSC", ""));
                    rk.Close();
                }
                else
                {
                    uctxtChallanNo.Text = "";
                    uctxtChallanNo.AppendText((String)rk.GetValue("VoucherNoPR", ""));
                    rk.Close();
                }
                uctxtChallanNo.Text = Utility.gobjNextNumber(uctxtChallanNo.Text);
            }
            uctxtPartyName.Focus();
        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "", strDuplicate="";
            string strmsg = "", strDate = "", strStartNo = "", strEndNo = "", strMobileNo = "";
            double dblAmnt = 0;
            if (ValidateFields() == false)
            {
                return;
            }

            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                try
                {
                    if (intVtype == (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
                    {
                        RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
                        rk.SetValue("NarrationsSC", uctxtNarration.Text);
                        rk.SetValue("VoucherNoSC", uctxtChallanNo.Text);
                        rk.Close();
                    }
                    else
                    {
                        RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
                        rk.SetValue("NarrationsPR", uctxtNarration.Text);
                        rk.SetValue("VoucherNoPR", uctxtChallanNo.Text);
                        rk.Close();
                    }
                    if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
                    {

                        i = mSaveSalesChallanNew();
                        if (i == "Inserted...")
                        {

                            
                            strMobileNo = Utility.gstrSMSMobileNo(strComID, uctxtPartyName.Text);
                            if (strMobileNo != "")
                            {
                                for (int intRow = 0; intRow < DGSalesOrder.Rows.Count; intRow++)
                                {
                                    if (uctxtRefType.Text == "Sample Class")
                                    {
                                        dblAmnt = 0;
                                    }
                                    else
                                    {
                                        dblAmnt = dblAmnt + Utility.gdblInvoiceAmount(strComID, DGSalesOrder[0, intRow].Value.ToString());
                                    }
                                    if (intRow == 0)
                                    {
                                        strDate = DGSalesOrder[2, intRow].Value.ToString();
                                        strStartNo = DGSalesOrder[1, intRow].Value.ToString();
                                    }
                                    else
                                    {

                                        strEndNo = Utility.Right(DGSalesOrder[1, intRow].Value.ToString(), 2);
                                    }

                                }
                                string strFirstate = Utility.FirstDayOfMonth(Convert.ToDateTime(dteDate.Text)).ToString("dd-MM-yyyy");
                                strmsg = "Inv. Date:" + strDate + Environment.NewLine + "Order No:" + uctxtChallanNo.Text + Environment.NewLine + "Tras.: " + uctxtTransport.Text +
                                            Environment.NewLine + "Tr. No.: " + uctxtTrNo.Text +
                                            Environment.NewLine + "Inv: " + strStartNo + "-" + strEndNo + Environment.NewLine +
                                            "Amount: " + dblAmnt  + Environment.NewLine + "Car. Qty:" + uctxtcrtQty.Text + Environment.NewLine + "Box Qty.:" + uctxtBoxQty.Text + Environment.NewLine +
                                            "Add. Item: " + uctxtNarration.Text + Environment.NewLine + "Total Bill : " + Utility.gdblChallanAmount(strComID, uctxtPartyName.Text, strFirstate, dteDate.Text) + Environment.NewLine + "Powered by: Deeplaid MIS and IT";
                                //string hh = SendSMS(strMobileNo, strmsg);
                                //MessageBox.Show(strmsg);
                            }
                            else
                            {
                                MessageBox.Show ("Sms cannot be Sent,Mobile No Not Found");
                            }
                            mClear();
                        }
                        else
                        {
                            MessageBox.Show(i.ToString());
                        }
                    }
                    else
                    {
                        i = mUpdateSalesChallan();
                        if (i == "Updated...")
                        {
                            mClear();
                        }

                    }
                }
                catch (Exception ex)
                {
                    if (i == "Inserted...")
                    {
                        mClear();
                    }
                    else if (i == "Updated...")
                    {
                        mClear();
                    }
                    else
                    {
                        MessageBox.Show(i.ToString());
                    }

                }
            }
        }
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
          
            frmAccountsVoucherList objfrm = new frmAccountsVoucherList();
            objfrm.mintVType = Convert.ToInt32(intVtype);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = "Sales Challan";
            objfrm.strPreserveSQl = mySQL;
            objfrm.onAddAllButtonClicked = new frmAccountsVoucherList.AddAllClick(DisplayVoucherList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            dteDate.Focus();
        }
        #endregion

        private void DisplayVoucherList(List<AccountsVoucher> tests, object sender, EventArgs e)
        {
            try
            {
                int introw = 0;
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DGSalesGrid.Rows.Clear();
                DGSalesOrder.Enabled = false;
                //DGSalesGrid.Enabled = false;
                uctxtRefType.Enabled = false;
                List<AccountsVoucher> ooaccVou = accms.DisplayCompVoucherList(strComID, tests[0].strVoucherNo, intVtype).ToList();
                if (ooaccVou.Count > 0)
                {
                    mySQL = tests[0].strPreserveSQL;
                    foreach (AccountsVoucher oCom in ooaccVou)
                    {
                        uctxtChallanNo.Text = Utility.Mid(oCom.strVoucherNo, 6, oCom.strVoucherNo.Length - 6); 
                        txtOldRefNo.Text = oCom.strVoucherNo;
                        dteDate.Text = oCom.strTranDate;
                        
                        dteDuedate.Text = oCom.strDueDate;
                        uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, oCom.strBranchID);
                        uctxtNarration.Text = oCom.strNarration;

                        mstrPartyName = oCom.strLedgerName;
                        uctxtPartyName.Text = oCom.strLedgerName;
                        uctxtTeritoryCode.Text = Utility.GetLedgerNameFromMerzeName(strComID, oCom.strLedgerName);
                        //uctxtTeritoryCode.Text = Utility.GetTeritorryCodeFromLedgerName(strComID, uctxtPartyName.Text);
                        //uctxtTeritorryName.Text = Utility.GetTeritorryName(strComID, uctxtTeritoryCode.Text);

                        if (oCom.strSalesRepresentive != "")
                        {
                            uctxtCustomer.Text = oCom.strSalesRepresentive;
                            uctxtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, oCom.strSalesRepresentive);
                            uctxtCustomerCode.Text = Utility.gGeCustomerCode(strComID, uctxtCustomer.Text);
                            uctxtHomeohall.Text = Utility.gGeCustomerHooeohall(strComID, uctxtCustomer.Text);
                        }
                        else
                        {
                            uctxtCustomer.Text = Utility.gcEND_OF_LIST;
                        }

                       

                        uctxtDesignation.Text = oCom.strDesignation;
                        uctxtTransport.Text = oCom.strtransport;
                        uctxtTrNo.Text = oCom.strOthers ;
                        uctxtcrtQty.Text = oCom.dblCrtQnty.ToString() ;
                        uctxtBoxQty.Text = oCom.dblBoxQnty.ToString();
                        List<AccBillwise> ooVouList = accms.DisplayCommonInvoice(strComID,tests[0].strVoucherNo).ToList();
                        if (ooVouList.Count > 0)
                        {

                            foreach (AccBillwise oacc in ooVouList)
                            {
                                uctxtLocation.Text = oacc.strGodownsName;
                                DGSalesGrid.Rows.Add();
                                DGSalesGrid[0, introw].Value = oacc.dblQnty;
                                DGSalesGrid[1, introw].Value = oacc.strStockItemName;
                                DGSalesGrid[2, introw].Value = oacc.dblQnty;
                                DGSalesGrid[3, introw].Value = oacc.dblRate;
                                DGSalesGrid[4, introw].Value = oacc.strPer;
                                DGSalesGrid[5, introw].Value = oacc.dblAmount;
                                DGSalesGrid[6, introw].Value = oacc.strBatchNo;
                                DGSalesGrid[8, introw].Value = oacc.strBillKey;
                                DGSalesGrid[7, introw].Value = "Delete";
                                DGSalesGrid[10, introw].Value = oacc.dblBonusQnty;
                                
                                //DGSalesGrid[8, introw].Value = oacc.strRefNo;
                                introw += 1;
                            }
                            txtTotalItem.Text = "Total Item: " + introw.ToString();
                            DGSalesGrid.AllowUserToAddRows = false;
                        }
                        //else
                        //{
                        //    uctxtRefType.Text = Utility.gcEND_OF_LIST;
                        //}
                    }
                    List<AccBillwise> ooOrder = accms.DisplaycommonInvoiceOrder(strComID, tests[0].strVoucherNo.ToString(), intVtype).ToList();
                    if (ooOrder.Count > 0)
                    {
                        introw = 0;
                        foreach (AccBillwise oaccOrder in ooOrder)
                        {
                            DGSalesOrder.Rows.Add();
                            DGSalesOrder[0, introw].Value = oaccOrder.strBillKey;
                            DGSalesOrder[1, introw].Value = Utility.Mid(oaccOrder.strRefNo,6,oaccOrder.strRefNo.Length-6);
                            //DGSalesOrder[1, introw].Value = oaccOrder.strRefNo;
                            DGSalesOrder[2, introw].Value = oaccOrder.strDate;
                            if (Utility.Left(oaccOrder.strRefNo,2)=="SC")
                            {
                                uctxtRefType.Text = "Sample Class";
                            }
                            else
                            {
                                uctxtRefType.Text = oaccOrder.strRefType;
                            }
                            DGSalesOrder[3, introw].Value = "Delete";
                            introw += 1;

                        }
                        txtNoofOrder.Text = "Total Invoice: " + introw.ToString();
                        DGSalesOrder.AllowUserToAddRows = false;
                    }
                    else
                    {
                        uctxtRefType.Text = Utility.gcEND_OF_LIST;
                    }



                    calculateTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucdgList_KeyUp(object sender, KeyEventArgs e)
        {
           
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
            ucdgList.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    ucdgList.Rows.Add();
                    ucdgList[0, i].Value = tran.strItemName;
                    ucdgList[1, i].Value = tran.dblClsBalance + " " + tran.strUnit;
                    //if (i % 2 == 0)
                    //{
                    //    ucdgList.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    ucdgList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
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
            SearchListView(oogrp, uctxtItemName.Text);
        }

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
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            //if (searchString != "")
            //{
                query = tests.Where(x => x.strRefNo.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            //}
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

        private void DGSalesOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    DGSalesOrder.Rows.RemoveAt(e.RowIndex);
                    //DGSalesGrid.Rows.Clear();
                    //txtRefTypeNew_LostFocus(sender, e);
                    mloadOrder();
                    calculateTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DGSalesGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
                if (e.ColumnIndex==2)
                {
                    string strunit = Utility.gGetBaseUOM(strComID, DGSalesGrid[1, e.RowIndex].Value.ToString());
                    double dblQty =  Utility.Val(DGSalesGrid[2, e.RowIndex].Value.ToString());
                    double dblrate = Utility.Val(DGSalesGrid[3, e.RowIndex].Value.ToString());
                    DGSalesGrid[2, e.RowIndex].Value = dblQty + " " + strunit.ToString();
                    DGSalesGrid[5, e.RowIndex].Value = (dblQty * dblrate) ;
                    calculateTotal();
                    btnSave.Focus();
                }
        }

        private void uctxtPartyName_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListViewPartyName(ooPartyName, uctxtPartyName.Text);
        }
        private void SearchListViewPartyName(IEnumerable<Invoice> tests, string searchString = "")
        {
            IEnumerable<Invoice> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                query = tests.Where(x => x.strMereString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
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
            DGMr.Rows.Clear();
            int i = 0;
            try
            {
                foreach (Invoice  tran in query)
                {
                    DGMr.Rows.Add();
                    DGMr[0, i].Value = tran.strTeritorryCode ;
                    DGMr[1, i].Value = tran.strTeritorryName ;
                    DGMr[2, i].Value = tran.strLedgerName ;
                    DGMr[3, i].Value = tran.strMereString ;
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
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                query = tests.Where(x => x.strMereString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
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

        private void uctxtCustomer_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void DGSalesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {

                if (uctxtRefType.Text == "End of List")
                {
                    if (m_action != 2)
                    {
                        DGSalesGrid.Rows.RemoveAt(e.RowIndex);
                        calculateTotal();
                    }
                }
                else if (uctxtRefType.Text=="Sample Class")
                {
                    if (m_action != 2)
                    {
                        DGSalesGrid.Rows.RemoveAt(e.RowIndex);
                        calculateTotal();
                    }
                }
            }
        }

        private void uctxtTrNo_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    SPWOIS objw = new SPWOIS();
        //    string ff = objw.SendSMS("", "");
        //}


    }
}
