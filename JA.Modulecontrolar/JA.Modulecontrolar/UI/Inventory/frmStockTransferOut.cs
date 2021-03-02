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
using JA.Modulecontrolar.JRPT;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmStockTransferOut : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstreqoiLocation = new ListBox();
        private ListBox lstFromLocation = new ListBox();
      
      
        private ListBox lstProcess = new ListBox();
        private ListBox lstBranch = new ListBox();
        private ListBox lstreqoiNo = new ListBox();
        
        public int m_action { get; set; }
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
        private string mstrPrserveSql { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        private string strComID { get; set; }
        List<InvoiceConfig> oinv;
        public int mintVtype { get; set; }
        List<StockItem> oogrp;
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWIS = new SPWOIS();
        JRPT.SWRPTClient orptCnn = new SWRPTClient();
        public frmStockTransferOut()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User In"
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

            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);
            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);

            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);

            this.uclstGrdItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uclstGrdItem_KeyPress);
            this.uclstGrdItem.DoubleClick += new System.EventHandler(this.uclstGrdItem_DoubleClick);

            this.uctxtFromLocation.KeyDown += new KeyEventHandler(uctxtFromLocation_KeyDown);
            this.uctxtFromLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFromLocation_KeyPress);
            this.uctxtFromLocation.TextChanged += new System.EventHandler(this.uctxtFromLocation_TextChanged);
            this.lstFromLocation.DoubleClick += new System.EventHandler(this.lstFromLocation_DoubleClick);
            this.uctxtFromLocation.GotFocus += new System.EventHandler(this.uctxtFromLocation_GotFocus);

            this.uctxtProcessName.KeyDown += new KeyEventHandler(uctxtProcessName_KeyDown);
            this.uctxtProcessName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtProcessName_KeyPress);
            this.uctxtProcessName.TextChanged += new System.EventHandler(this.uctxtProcessName_TextChanged);
            this.lstProcess.DoubleClick += new System.EventHandler(this.lstProcess_DoubleClick);
            this.uctxtProcessName.GotFocus += new System.EventHandler(this.uctxtProcessName_GotFocus);
            this.uclstGrdItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstGrdItem_CellFormatting);


            this.txtBranch.KeyDown += new KeyEventHandler(txtBranch_KeyDown);
            this.txtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBranch_KeyPress);
            this.txtBranch.TextChanged += new System.EventHandler(this.txtBranch_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.txtBranch.GotFocus += new System.EventHandler(this.txtBranch_GotFocus);

            this.uctxtRequiLocation.KeyDown += new KeyEventHandler(uctxtRequiLocation_KeyDown);
            this.uctxtRequiLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRequiLocation_KeyPress);
            this.uctxtRequiLocation.TextChanged += new System.EventHandler(this.uctxtRequiLocation_TextChanged);
            this.lstreqoiLocation.DoubleClick += new System.EventHandler(this.lstreqoiLocation_DoubleClick);
            this.uctxtRequiLocation.GotFocus += new System.EventHandler(this.uctxtRequiLocation_GotFocus);

            this.txtRequsiNo.KeyDown += new KeyEventHandler(txtRequsiNo_KeyDown);
            this.txtRequsiNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtRequsiNo_KeyPress);
            this.txtRequsiNo.TextChanged += new System.EventHandler(this.txtRequsiNo_TextChanged);
            this.lstreqoiNo.DoubleClick += new System.EventHandler(this.lstreqoiNo_DoubleClick);
            this.txtRequsiNo.GotFocus += new System.EventHandler(this.txtRequsiNo_GotFocus);

            Utility.CreateListBox(lstreqoiNo, pnlMain, txtRequsiNo);
            Utility.CreateListBox(lstreqoiLocation, pnlMain, uctxtRequiLocation );
            Utility.CreateListBox(lstBranch, pnlMain, txtBranch);
            Utility.CreateListBox(lstFromLocation, pnlMain, uctxtFromLocation);
           
            Utility.CreateListBox(lstProcess, pnlMain, uctxtProcessName);
            #endregion

        }
        #region "Format"
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
        #endregion
        #region "Load"
        private void Refload()
        {
            
            lstreqoiNo.ValueMember = "strBillKey";
            lstreqoiNo.DisplayMember = "strRefNo";
            lstreqoiNo.DataSource = invms.mGetStockRequiNo(strComID, uctxtRequiLocation.Text, "").ToList();
        }
        #endregion
        #region "DisplayRequisition"
        private void DisplayRequisition(string vstrProcess)
        {
            double dblrate = 0;
            try
            {
                int intfg = 0;
                uctxtProcessName.Focus();
                DG.Rows.Clear();
                List<ManuProcess> omanuProcess = invms.mDisplayRequisitionNo(strComID, vstrProcess).ToList();
                if (omanuProcess.Count > 0)
                {
                    foreach (ManuProcess ts in omanuProcess)
                    {
                     
                            DG.Rows.Add();
                            DG[0, intfg].Value = ts.stritemName;
                            DG[2, intfg].Value = ts.dblqnty;
                            DG[3, intfg].Value = ts.strUnit;
                            dblrate = Math.Abs(Utility.gdblGetCostPriceNew(strComID, ts.stritemName, dteDate.Text));
                            DG[4, intfg].Value = dblrate;
                            DG[5, intfg].Value = Math.Round(ts.dblqnty * dblrate, 2);
                            DG[7, intfg].Value = "Delete";
                            intfg += 1;
                            DG.AllowUserToAddRows = false;
                       
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
        private void uctxtRequiLocation_TextChanged(object sender, EventArgs e)
        {
            lstreqoiLocation.SelectedIndex = lstreqoiLocation.FindString(uctxtRequiLocation.Text);
        }

        private void lstreqoiLocation_DoubleClick(object sender, EventArgs e)
        {

            uctxtRequiLocation.Text = lstreqoiLocation.Text;
            if (chkwithRequisiton.Checked)
            {
                Refload();
                if (uctxtRequiLocation.Text != "")
                {
                    txtRequsiNo.Focus();
                }
                else
                {
                    uctxtNarration.Focus();
                }
            }
            else
            {
                uctxtNarration.Focus();
            }
        }

        private void uctxtRequiLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstreqoiLocation.Items.Count > 0)
                {

                    uctxtRequiLocation.Text = lstreqoiLocation.Text;

                }
                if (chkwithRequisiton.Checked)
                {
                    if (uctxtRequiLocation.Text != "")
                    {
                        txtRequsiNo.Focus();
                    }
                    else
                    {
                        uctxtNarration.Focus();
                    }
                }
                else
                {
                    uctxtNarration.Focus();
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtRequiLocation, sender, e);
            }
        }
        private void uctxtRequiLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstreqoiLocation.SelectedItem != null)
                {
                    lstreqoiLocation.SelectedIndex = lstreqoiLocation.SelectedIndex - 1;
                    uctxtRequiLocation.Text = lstreqoiLocation.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstreqoiLocation.Items.Count - 1 > lstreqoiLocation.SelectedIndex)
                {
                    lstreqoiLocation.SelectedIndex = lstreqoiLocation.SelectedIndex + 1;
                    uctxtRequiLocation.Text = lstreqoiLocation.Text;
                }
            }

        }

        private void uctxtRequiLocation_GotFocus(object sender, System.EventArgs e)
        {
            lstreqoiLocation.Visible = true;
            lstreqoiNo.Visible = false;
            lstBranch.Visible = false;
            lstFromLocation.Visible = false;

            lstProcess.Visible = false;

            uclstGrdItem.Visible = false;

            lstreqoiLocation.SelectedIndex = lstreqoiLocation.FindString(uctxtRequiLocation.Text);
        }

        private void txtRequsiNo_TextChanged(object sender, EventArgs e)
        {
            lstreqoiNo.SelectedIndex = lstreqoiNo.FindString(txtRequsiNo.Text);
        }

        private void lstreqoiNo_DoubleClick(object sender, EventArgs e)
        {
            txtRequsiNo.Text = lstreqoiNo.Text;

            DisplayRequisition(lstreqoiNo.SelectedValue.ToString());
            uctxtNarration.Focus();
        }

        private void txtRequsiNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstreqoiNo.Items.Count > 0)
                {
                    txtRequsiNo.Text = lstreqoiNo.Text;
                    if (lstreqoiNo.SelectedValue != null)
                    {
                        DisplayRequisition(lstreqoiNo.SelectedValue.ToString());
                    }
                }
                uctxtItemName.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtRequsiNo, sender, e);
            }
        }
        private void txtRequsiNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstreqoiNo.SelectedItem != null)
                {
                    lstreqoiNo.SelectedIndex = lstreqoiNo.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstreqoiNo.Items.Count - 1 > lstreqoiNo.SelectedIndex)
                {
                    lstreqoiNo.SelectedIndex = lstreqoiNo.SelectedIndex + 1;
                }
            }

        }

        private void txtRequsiNo_GotFocus(object sender, System.EventArgs e)
        {
            lstreqoiLocation.Visible = false;
            lstreqoiNo.Visible = true;
            lstBranch.Visible = false;
            lstFromLocation.Visible = false;

            lstProcess.Visible = false;
            try
            {
              
                uclstGrdItem.Visible = false;
                if (chkwithRequisiton.Checked)
                {
                    Refload();
                }
                else
                {
                    lstreqoiNo.ValueMember = "strBillKey";
                    lstreqoiNo.DisplayMember = "strRefNo";
                    lstreqoiNo.DataSource = invms.mGetStockRequiNo(strComID,"None", "").ToList();
                }

                lstreqoiNo.SelectedIndex = lstreqoiNo.FindString(txtRequsiNo.Text);
            }
            catch (Exception ex)
            {

            }

        }
        private void txtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(txtBranch.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            txtBranch.Text = lstBranch.Text;
            uctxtInvoiceNo.Focus();
        }

        private void txtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    txtBranch.Text = lstBranch.Text;
                }
                uctxtInvoiceNo.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtBranch, sender, e);
            }
        }
        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstreqoiLocation.Visible = false;
            lstreqoiNo.Visible = false;
            lstBranch.Visible = true;
            lstFromLocation.Visible = false;

            lstProcess.Visible = false;

            uclstGrdItem.Visible = false;

            lstBranch.SelectedIndex = lstBranch.FindString(txtBranch.Text);
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
                if (uctxtProcessName.Text != "")
                {
                    DisplayProcessRm(uctxtProcessName.Text);
                }
            }

            if (uctxtRequiLocation.Enabled)
            {
                uctxtRequiLocation.Focus();
            }
            else
            {
                uctxtItemName.Focus();
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
                List<ManuProcess> omanuProcess = invms.mDisplayProcess(strComID, vstrProcess,"P").ToList();
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
                            dblrate = Utility.gdblGetCostPrice(strComID, ts.stritemName, dteDate.Text);
                            DG[4, intfg].Value = dblrate;
                            DG[5, intfg].Value = Math.Round(ts.dblqnty * dblrate, 2);
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
                    if (uctxtProcessName.Text != "")
                    {
                        DisplayProcessRm(uctxtProcessName.Text);
                    }
                }
                if (uctxtRequiLocation.Enabled)
                {
                    uctxtRequiLocation.Focus();
                }
                else
                {
                    uctxtItemName.Focus();
                }
              
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtProcessName, sender, e);
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
            lstreqoiLocation.Visible = false;
            lstreqoiNo.Visible = false;
            lstBranch.Visible = false;
            lstFromLocation.Visible = false;
           
            lstProcess.Visible = true;
            
            uclstGrdItem.Visible = false;

            if (uctxtFromLocation.Text != "")
            {
                lstProcess.ValueMember = "strProcessName";
                lstProcess.DisplayMember = "strProcessName";
                lstProcess.DataSource = invms.mLoadProcessNew(strComID, "", "", 0, 0, uctxtFromLocation.Text).ToList();
            }

            lstProcess.SelectedIndex = lstProcess.FindString(uctxtProcessName.Text);
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
            lstreqoiLocation.Visible = false;
            lstreqoiNo.Visible = false;
            lstBranch.Visible = false;
            
            lstFromLocation.Visible = false;
            
            lstProcess.Visible = false;

        }
        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtItemName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtRate, sender, e);
            }
        }
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
            lstreqoiLocation.Visible = false;
            lstreqoiNo.Visible = false;
            lstBranch.Visible = false;
            
            lstFromLocation.Visible = false;
            
            lstProcess.Visible = false;
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtRate.Text = Utility.gdblPurchasePrice(strComID, uctxtItemName.Text, dteDate.Text).ToString();
                uctxtRate.Text = Utility.gdblGetCostPriceNew(strComID, uctxtItemName.Text, dteDate.Text).ToString();
                if (Utility.Val(uctxtRate.Text) != 0)
                {
                    mAddStockItem(DG, uctxtItemName.Text, Utility.Val(uctxtQty.Text), Math.Abs(Utility.Val(uctxtRate.Text)), "");
                    uctxtItemName.Focus();
                }
                else
                {
                    MessageBox.Show("Rate Cannot be Found");
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
                    //txtItemCode.Text = "";
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
            lstreqoiLocation.Visible = false;
            lstreqoiNo.Visible = false;
            lstBranch.Visible = false;
            
            lstFromLocation.Visible = false;
            
            uclstGrdItem.Visible = false;
            lstProcess.Visible = false;
            if (uctxtFromLocation.Text != "")
            {
                mLoadAllItem();
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
        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {
            lstreqoiLocation.Visible = false;
            lstreqoiNo.Visible = false;
            lstBranch.Visible = false;
            
            lstFromLocation.Visible = false;
            
            uclstGrdItem.Visible = false;
            lstProcess.Visible = false;
        }
        private void dteDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtFromLocation.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                uctxtInvoiceNo.Focus();
            }
        }
        private void dteDate_GotFocus(object sender, System.EventArgs e)
        {
            lstreqoiLocation.Visible = false;
            lstreqoiNo.Visible = false;
            lstBranch.Visible = false;
            
            lstFromLocation.Visible = false;
            
            uclstGrdItem.Visible = false;
            lstProcess.Visible = false;
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
                    uctxtFromLocation.Focus();
                }

            }
        }
        private void uctxtInvoiceNo_GotFocus(object sender, System.EventArgs e)
        {
            lstreqoiLocation.Visible = false;
            lstreqoiNo.Visible = false;
            lstBranch.Visible = false;
            
            lstFromLocation.Visible = false;
            
            uclstGrdItem.Visible = false;
            lstProcess.Visible = false;
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
                dg[6, selRaw].Value = strBatch;
                dg[7, selRaw].Value = "Delete";
                dg.AllowUserToAddRows = false;
                uctxtItemName.Text = "";
                uctxtQty.Text = "";
                uctxtRate.Text = "";
              
                calculateTotal();
                dg.ClearSelection();
                int nColumnIndex = 2;
                int nRowIndex = dg.Rows.Count - 1;
                dg.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                dg.FirstDisplayedScrollingRowIndex = nRowIndex;
            }

        }
       

        private void uctxtFromLocation_TextChanged(object sender, EventArgs e)
        {
            lstFromLocation.SelectedIndex = lstFromLocation.FindString(uctxtFromLocation.Text);
        }

        private void lstFromLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtFromLocation.Text = lstFromLocation.Text;
          
            uctxtProcessName.Focus();
        }

        private void uctxtFromLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstFromLocation.Items.Count > 0)
                {
                    uctxtFromLocation.Text = lstFromLocation.Text;
                }
                
                uctxtProcessName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtFromLocation, sender, e);
            }
        }
        private void mLoadAllItem()
        {
            int introw = 0;
            uclstGrdItem.Rows.Clear();
            //oogrp = objWIS.gFillStockItem(strComID, uctxtFromLocation.Text).ToList();
            //oogrp = objWIS.gFillStockItemNew(strComID,"", uctxtFromLocation.Text).ToList();
            //string strBranchID = Utility.gstrGetBranchIDfromGodown(strComID, uctxtFromLocation.Text.Trim());
            
            oogrp = objWIS.mGetProductStatementView(strComID, "", lstBranch.SelectedValue.ToString(), uctxtFromLocation.Text,"").ToList();
            
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
            lstreqoiLocation.Visible = false;
            lstreqoiNo.Visible = false;
            lstBranch.Visible = false;
            lstFromLocation.Visible = true;
            
            uclstGrdItem.Visible = false;
            
            lstProcess.Visible = false;
            lstFromLocation.SelectedIndex = lstFromLocation.FindString(uctxtFromLocation.Text);
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
        #region "clear"
        private void mClear()
        {
            uctxtFromLocation.Text = "";
            DG.Rows.Clear();
            uctxtItemName.Text = "";
            uctxtRate.Text = "";
            uctxtNarration.Text = "";
            lblAmount.Text = "";
            uctxtQty.Text = "";
            uctxtNarration.Text = "";
            uctxtProcessName.Text = "";
            lblQnty.Text = "";
            uctxtRequiLocation.Text = "";
            txtRequsiNo.Text = "";
            uctxtRequiLocation.Enabled = true;
            txtRequsiNo.Enabled = true;
            if (Utility.gstrUserName.ToUpper() == "DEEPLAID")
            {
                dteDate.Enabled = true;
                dteDate.Focus();

            }
            else
            {
                uctxtFromLocation.Focus();
            }
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod)
            {
                uctxtInvoiceNo.Text = Utility.gstrLastNumber(strComID, mintVtype);
                uctxtInvoiceNo.ReadOnly = true;
                txtBranch.Select();
            }
            else
            {

                uctxtInvoiceNo.Text = Utility.gobjNextNumber(uctxtInvoiceNo.Text);
                uctxtInvoiceNo.ReadOnly = false;
                txtBranch.Select();
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
            string i = "", strDG = "", strBranchId = "",strToBranchId="", strRefNumber,strProcess="",strReqKey="";
            int intRow = 0;

            strBranchId = Utility.gstrGetBranchID(strComID, uctxtFromLocation.Text);
         
            if (m_action == 1)
            {
                if (txtRequsiNo.Text != "")
                {
                    strReqKey = lstreqoiNo.SelectedValue.ToString();
                }
                else
                {
                    strReqKey = "";
                }
            }
            if (uctxtProcessName.Text !="")
            {
                strProcess =uctxtProcessName.Text;
            }
            else
            {
                strProcess ="";
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
                            strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(mintVtype) + strBranchId + uctxtInvoiceNo.Text;
                        }
                        else
                        {
                            strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(mintVtype) + strBranchId + Utility.gstrLastNumber(strComID, mintVtype);
                        }

                        i = objWIS.mSaveStockTransferOut(strComID, strRefNumber, (long)mintVtype, dteDate.Text, Utility.Val(lblAmount.Text),
                                                   Utility.gCheckNull(uctxtNarration.Text), strBranchId, strToBranchId,Utility.gCheckNull(uctxtFromLocation.Text),
                                                   Utility.gCheckNull(uctxtRequiLocation.Text), strDG, mblnNumbMethod, strProcess, strReqKey);

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

                        i = objWIS.mUpdateStockTransferOut(strComID, textBox1.Text, (long)mintVtype, dteDate.Text, Utility.Val(lblAmount.Text),
                                                   Utility.gCheckNull(uctxtNarration.Text), strBranchId, strToBranchId, Utility.gCheckNull(uctxtFromLocation.Text),
                                                   Utility.gCheckNull(uctxtRequiLocation.Text), strDG, mblnNumbMethod, strProcess, strReqKey);

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
            double dblClosingQTY = 0, dblCurrentQTY = 0;
            string strBillKey = "", strNegetiveItem = "";
            int intCheckNegetive = 0;

            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (uctxtFromLocation.Text.TrimStart() == uctxtRequiLocation.Text.TrimStart())
            {
                MessageBox.Show("Both Location Cannot be Same");
                uctxtFromLocation.Focus();
                return false;
            }
            if (uctxtRequiLocation.Text=="")
            {
                MessageBox.Show("To Location Cannot be empty");
                uctxtRequiLocation.Focus();
                return false;
            }

            if (m_action == 1)
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

            string strLockvoucher = Utility.gLockVocher(strComID, mintVtype);
            if (strLockvoucher != "")
            {
                long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strLockvoucher).ToString("yyyyMMdd"));
                if (lngDate <= lngBackdate)
                {
                    MessageBox.Show("Invalid Date, Back Date is locked");
                    return false;
                }
            }
            try
            {
                for (int i = 0; i < DG.Rows.Count; i++)
                {
                    if (DG[0, i].Value.ToString() != "")
                    {
                        dblClosingQTY = Utility.gdblClosingStock(strComID, DG[0, i].Value.ToString(), uctxtFromLocation.Text, dteDate.Value.ToString("dd-MM-yyyy"));
                        //dblClosingQTY = objWIS.mGetProductStatementView(strComID,""lstBranch.SelectedValue.ToString(), uctxtFromLocation.Text, "").ToList();
                        if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                        {
                            strBillKey = DG[8, i].Value.ToString();
                            dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey, uctxtFromLocation.Text);
                        }
                        dblCurrentQTY = Utility.Val(DG[2, i].Value.ToString());
                        if ((dblClosingQTY) - dblCurrentQTY < 0)
                        {
                            strNegetiveItem = strNegetiveItem + Environment.NewLine + DG[0, i].Value.ToString();
                            intCheckNegetive = 1;
                            dblClosingQTY = 0;
                        }
                    }
                    dblClosingQTY = 0;
                }

                if (intCheckNegetive > 0)
                {
                    MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                    DG.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
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
        #region "Click"
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                DG.Rows.RemoveAt(e.RowIndex);
            }
            calculateTotal();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmStockTransferList objfrm = new frmStockTransferList();
            objfrm.intvType = mintVtype;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFlag = "O";
            objfrm.onAddAllButtonClicked = new frmStockTransferList.AddAllClick(DisplayVoucherList);
            objfrm.strPreserveSQl = mstrPrserveSql;
            objfrm.MdiParent = MdiParent;
            objfrm.Show();
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
                if (mintVtype == (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER)
                {
                    uctxtInvoiceNo.Text = Utility.Mid(tests[0].strRefNo, 6, tests[0].strRefNo.Length - 6);
                    textBox1.Text = tests[0].strRefNo;
                    // uctxtFromLocation.Text = tests[0].strBranchName;
                    dteDate.Text = tests[0].strDate;
                    uctxtNarration.Text = tests[0].strNarration;
                    mstrPrserveSql = tests[0].strPreserveSQL;
                    List<StockItem> oRm = objWIS.mFillDisplayStockTransferOut(strComID, tests[0].strRefNo).ToList();
                    {
                        if (oRm.Count > 0)
                        {
                            foreach (StockItem ooRm in oRm)
                            {

                                DG.Rows.Add();
                                //dblclsQnty = Utility.gdblClosingStock(ooRm.strItemName, oRm[0].strLocation, "");
                                DG[0, intrm].Value = ooRm.strItemName;
                                DG[1, intrm].Value = dblclsQnty;
                                DG[2, intrm].Value = Math.Abs(ooRm.dblOpnQty);
                                DG[3, intrm].Value = Utility.gGetBaseUOM(strComID, ooRm.strItemName);
                                DG[4, intrm].Value = Math.Abs(ooRm.dblOpnRate);
                                DG[5, intrm].Value = Math.Abs(ooRm.dblOpnValue);
                                DG[6, intrm].Value = ooRm.strBatch;
                                DG[7, intrm].Value = "Delete";
                                DG[8, intrm].Value = ooRm.strBillKey;
                                uctxtFromLocation.Text = ooRm.strFromLocation;
                                
                                uctxtProcessName.Text = ooRm.strProcess;
                                uctxtRequiLocation.Enabled = false;
                                txtRequsiNo.Enabled = false;
                                uctxtRequiLocation.Text = ooRm.strToLocation;
                                if (ooRm.strItemCategory != "")
                                {
                                    txtRequsiNo.Text = Utility.Mid(ooRm.strItemCategory, 6, ooRm.strItemCategory.Length - 6);
                                }
                                else
                                {
                                    txtRequsiNo.Text = "";
                                }
                                txtBranch.Text = Utility.gstrBranchName;
                                DG[8, intrm].Value = ooRm.strBillKey;
                                intrm += 1;
                                DG.AllowUserToAddRows = false;

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
                if (uctxtItemName.Text != "")
                {
                    SearchListView(oogrp, uctxtItemName.Text);
                }
             
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "SearchList"
        private void SearchListView(IEnumerable<StockItem> tests, string searchString)
        {
            IEnumerable<StockItem> query;
        
            query = tests;
            if (searchString != "")
            {
                //query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
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
        #endregion
        #region "Cell Edit"
        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DG.Rows[e.RowIndex].Cells[5].Value = Utility.Val(DG.Rows[e.RowIndex].Cells[2].Value.ToString()) * Utility.Val(DG.Rows[e.RowIndex].Cells[4].Value.ToString());
            calculateTotal();
        }
        #endregion
        #region load
        private void frmStockTransferOut_Load(object sender, EventArgs e)
        {
            string strYesNo = "Y";
            mGetConfig();
            mClear(); ;
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            lstFromLocation.Visible = false;

            lstProcess.Visible = false;
            DG.AllowUserToAddRows = false;

            frmLabel.Text = "Stock Transfer(Out)";
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, 202, m_action))
                {
                    strYesNo = "N";
                }
            }
           
           
            if (strYesNo == "Y")
            {
                DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 340, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Curr. Stock", "Curr. Stock", 150, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 90, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 70, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
            }
            else
            {
                DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 500, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Curr. Stock", "Curr. Stock", 250, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 80, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, false, DataGridViewContentAlignment.TopLeft, true));
                label8.Visible = false;
                lblAmount.Visible = false;
            }
            DG.Columns.Add(Utility.Create_Grid_Column("Batch", "Batch", 150, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("InvTranKey", "InvTranKey", 200, false, DataGridViewContentAlignment.TopLeft, true));
            lstFromLocation.ValueMember = "strLocation";
            lstFromLocation.DisplayMember = "strLocation";
            lstFromLocation.DataSource = invms.gLoadLocation(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName, 2).ToList();
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();



            lstreqoiLocation.ValueMember = "Key";
            lstreqoiLocation.DisplayMember = "Value";
            lstreqoiLocation.DataSource = invms.gLoadLocationOut(strComID, "1", Utility.gblnAccessControl, Utility.gstrUserName, 0).ToList();

        }
        #endregion

        private void chkwithRequisiton_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chkwithRequisiton_Click(object sender, EventArgs e)
        {
            if (chkwithRequisiton.Checked)
            {
                Refload();
                txtRequsiNo.Focus();
            }
            else
            {
                uctxtItemName.Focus();
            }
        }
    }

}
