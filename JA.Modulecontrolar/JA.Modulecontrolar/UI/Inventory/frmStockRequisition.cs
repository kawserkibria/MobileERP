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
    public partial class frmStockRequisition : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstFromLocation = new ListBox();
       
        private ListBox lstProcess = new ListBox();
        private ListBox lstBranch = new ListBox();
        public int m_action { get; set; }
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        private string mstrPrserveSql { get; set; }
        private string strComID { get; set; }
        List<InvoiceConfig> oinv;
        public int mintVtype { get; set; }
       
        List<StockItem> oogrp;
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWIS = new SPWOIS();
        public frmStockRequisition()
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

            Utility.CreateListBox(lstFromLocation, pnlMain, uctxtFromLocation);
           
            Utility.CreateListBox(lstProcess, pnlMain, uctxtProcessName);
            Utility.CreateListBox(lstBranch, pnlMain, txtBranch);
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
                    DisplayProcessRm(uctxtProcessName.Text,0);
                }
            }

            uctxtItemName.Focus();
        }
        private void DisplayProcessRm(string vstrProcess,double dblMaualQty)
        {
            double dblrate = 0;
            try
            {
                int intfg = 0;
                uctxtProcessName.Focus();
              
                DG.Rows.Clear();
                List<ManuProcess> omanuProcess = invms.mDisplayProcess(strComID, vstrProcess,"S").ToList();
                if (omanuProcess.Count > 0)
                {
                    foreach (ManuProcess ts in omanuProcess)
                    {
                        if (ts.intType == 1)
                        {
                            DG.Rows.Add();
                            if (dblMaualQty == 0)
                            {
                                DG[0, intfg].Value = ts.strGroupName ;
                                DG[1, intfg].Value = ts.stritemName;
                                DG[3, intfg].Value = ts.dblqnty;
                                DG[4, intfg].Value = ts.strUnit;
                                //dblrate = Utility.gdblGetCostPrice(strComID, ts.stritemName, dteDate.Text);
                                dblrate = Utility.gdblGetCostPriceNew(strComID, ts.stritemName, dteDate.Text);
                                DG[5, intfg].Value = dblrate;
                                DG[6, intfg].Value = Math.Round(ts.dblqnty * dblrate, 2);
                                DG[8, intfg].Value = "Delete";
                            }
                            else
                            {
                                DG[0, intfg].Value = ts.strGroupName;
                                DG[1, intfg].Value = ts.stritemName;
                                DG[3, intfg].Value = ts.dblqnty * dblMaualQty;
                                DG[4, intfg].Value = ts.strUnit;
                                //dblrate = Utility.gdblGetCostPrice(strComID, ts.stritemName, dteDate.Text);
                                dblrate = Utility.gdblGetCostPriceNew(strComID, ts.stritemName, dteDate.Text);
                                DG[5, intfg].Value = dblrate;
                                DG[6, intfg].Value = Math.Round((ts.dblqnty * dblMaualQty) * dblrate, 2);
                                DG[8, intfg].Value = "Delete";
                            }
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
                        uctxtProcessManuQty.Text = "0";
                    }
                }


                if (m_action == 1)
                {
                    if (uctxtProcessName.Text != "")
                    {
                        DisplayProcessRm(uctxtProcessName.Text,0);
                    }
                }
                uctxtItemName.Focus();
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
            lstBranch.Visible = false;
            lstFromLocation.Visible = false;
            lstProcess.Visible = true;
            uclstGrdItem.Visible = false;
            uctxtProcessManuQty.Text = "0";
            if (uctxtFromLocation.Text != "")
            {
                lstProcess.ValueMember = "strProcessName";
                lstProcess.DisplayMember = "strProcessName";
                lstProcess.DataSource = invms.mLoadProcessNew(strComID, "", "", 0, 0,uctxtFromLocation.Text).ToList();
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
            lstBranch.Visible = false;
           
            lstFromLocation.Visible = false;
          
            lstProcess.Visible = false;

        }
        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtItemName.Text = "";
                uctxtItemName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtRate, sender, e);
            }
        }
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
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
                    mAddStockItem(DG, uctxtItemName.Text, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), "");
                    uctxtItemName.Focus();
                    uctxtItemName.Text = "";
                    uctxtQty.Text = "";
                    uctxtRate.Text = "";
                }
                else
                {
                    MessageBox.Show("Rate Cannot be Found");
                    uctxtItemName.Focus();
                    uctxtQty.Text = "";
                    uctxtRate.Text = "";
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
            lstBranch.Visible = false;
           
            lstFromLocation.Visible = false;
            uclstGrdItem.Visible = false;
            lstProcess.Visible = false;
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
            try
            {
                for (int j = 0; j < dg.RowCount; j++)
                {
                    if (dg[1, j].Value != null)
                    {
                        strDown = dg[1, j].Value.ToString();
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
                    dg[0, selRaw].Value = Utility.gGetStockGroup(strComID, strItemName).ToString();
                    dg[3, selRaw].Value = 0;
                    dg[1, selRaw].Value = strItemName.ToString();
                    dg[2, selRaw].Value = 0;
                    dg[3, selRaw].Value = dblQty;
                    dg[4, selRaw].Value = Utility.gGetBaseUOM(strComID, strItemName.ToString());
                    dg[5, selRaw].Value = dblRate;
                    dg[6, selRaw].Value = (dblQty * dblRate);
                    dg[7, selRaw].Value = strBatch;
                    dg[8, selRaw].Value = "Delete";
                    dg.AllowUserToAddRows = false;


                    calculateTotal();
                    dg.ClearSelection();
                    int nColumnIndex = 2;
                    int nRowIndex = dg.Rows.Count - 1;
                    dg.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                    dg.FirstDisplayedScrollingRowIndex = nRowIndex;
                  
                }
            }
            catch (Exception ex)
            {

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
            //string strLocation = "Main Location";
            string strBranchID = Utility.gstrGetBranchIDfromGodown(strComID, uctxtFromLocation.Text.Trim());
            if (uctxtFromLocation.Text =="")
            {
                MessageBox.Show("Location Cannot be empty");
                uctxtFromLocation.Focus();
                return;
            }
            if (chkFG.Checked)
            {
                oogrp = objWIS.mGetProductRequisition(strComID, "", strBranchID, uctxtFromLocation.Text, "FGU").ToList();
            }
            else if (chkStationary.Checked)
            {
                oogrp = objWIS.mGetProductRequisition(strComID, "", strBranchID, uctxtFromLocation.Text, "STA").ToList();
            }
            else
            {
                oogrp = objWIS.mGetProductRequisition(strComID, "", strBranchID, uctxtFromLocation.Text, "NOTIN").ToList();
            }
            if (oogrp.Count > 0)
            {
               
                foreach (StockItem ogrp in oogrp)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, introw].Value = ogrp.strItemName;
                    //uclstGrdItem[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;
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
        #region "Load"
        private void frmStockDamage_Load(object sender, EventArgs e)
        {
            string strYesNo = "Y";
            mGetConfig();
            mClear(); ;
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            lstFromLocation.Visible = false;
            
            lstProcess.Visible = false;
            DG.AllowUserToAddRows = false;

            frmLabel.Text = "Stock Requisition";
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
                DG.Columns.Add(Utility.Create_Grid_Column("Group Name", "Group Name", 170, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 170, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Curr. Stock", "Curr. Stock", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 80, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 60, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 60, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
              
            }
            else
            {
                DG.Columns.Add(Utility.Create_Grid_Column("Group Name", "Group Name", 180, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 250, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Curr. Stock", "Curr. Stock", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 150, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 60, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, false, DataGridViewContentAlignment.TopLeft, true));
                label8.Visible = false;
                lblAmount.Visible = false;
            }
            DG.Columns.Add(Utility.Create_Grid_Column("Batch", "Batch", 150, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("InvTranKey", "InvTranKey", 200, false, DataGridViewContentAlignment.TopLeft, true));

            //DG.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //DG.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            //DG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            lstFromLocation.ValueMember = "strLocation";
            lstFromLocation.DisplayMember = "strLocation";
            lstFromLocation.DataSource = invms.gLoadLocation(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName,2).ToList();

           

            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

          

        }
        #endregion
        #region "Clear"
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
            uctxtBatch1.Text = "";
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
                DG.Rows[i].Cells[6].Value = Utility.Val(DG.Rows[i].Cells[3].Value.ToString()) * Utility.Val(DG.Rows[i].Cells[5].Value.ToString());
                dblamnt = dblamnt + Utility.Val(DG.Rows[i].Cells[6].Value.ToString());
                dblQnty = dblQnty + Utility.Val(DG.Rows[i].Cells[3].Value.ToString());
            }

            lblAmount.Text =  dblamnt.ToString();
            lblQnty.Text = dblQnty.ToString();
        }
        #endregion
        #region "Damage"
  
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
            string strBranchID = Utility.gstrGetBranchIDfromGodown(strComID, uctxtFromLocation.Text.Trim());
            if (oinv[0].mlngBlockNegativeStock > 0)
            {
                for (int i = 0; i < DG.Rows.Count; i++)
                {
                    if (DG[0, i].Value.ToString() != "")
                    {
                        if (DG[9, i].Value != null)
                        {
                            strBillKey = DG[9, i].Value.ToString();
                        }
                        else
                        {
                            strBillKey = "";
                        }

                        //dblClosingQTY = Utility.gdblClosingStock(strComID, DG[0, i].Value.ToString(), uctxtFromLocation.Text, dteDate.Text);
                        dblClosingQTY = Utility.gdblClosingStockSales(strComID, DG[1, i].Value.ToString(), strBranchID, "",uctxtFromLocation.Text);
                        if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                        {
                            dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey, uctxtFromLocation.Text);
                        }
                        dblCurrentQTY = Utility.Val(DG[3, i].Value.ToString());
                        if ((dblClosingQTY) - dblCurrentQTY < 0)
                        {
                            strNegetiveItem = strNegetiveItem + Environment.NewLine + DG[1, i].Value.ToString();
                            intCheckNegetive = 1;
                            dblClosingQTY = 0;
                        }
                        else if (dblClosingQTY == 0)
                        {
                            strNegetiveItem = strNegetiveItem + Environment.NewLine + DG[1, i].Value.ToString();
                            intCheckNegetive = 1;
                            dblClosingQTY = 0;
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
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "", strGrid = "", strBranchID = "", strRefNo = "", strBatch = "";
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (txtBranch.Text == "")
            {
                MessageBox.Show("Branch Name Cannot be Empty");
                txtBranch.Focus();
                return;
            }
            if (uctxtInvoiceNo.Text == "")
            {
                MessageBox.Show("Requisition No Cannot be Empty");
                uctxtInvoiceNo.Focus();
                return;
            }

            if (Utility.Val(lblQnty.Text) == 0 || Utility.Val(lblAmount.Text) < 0)
            {
                MessageBox.Show("Net Amount Cannot be Empty");
                uctxtItemName.Focus();
                return;
            }
            string strLockvoucher = Utility.gLockVocher(strComID, mintVtype);
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

            strBranchID = Utility.gstrGetBranchID(strComID, txtBranch.Text);
            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        for (int introw = 0; introw < DG.Rows.Count; introw++)
                        {
                            strGrid += DG[1, introw].Value.ToString() + "|" + DG[3, introw].Value.ToString() + "|" + DG[4, introw].Value.ToString() +
                                                    "|" + DG[5, introw].Value.ToString() + "|" + DG[6, introw].Value.ToString() + "~";
                        }

                        if (mblnNumbMethod)
                        {
                            strRefNo = gobjVoucherName.VoucherName.GetVoucherString(mintVtype) + strBranchID + Utility.gstrLastNumber(strComID, mintVtype);

                        }
                        else
                        {

                            strRefNo = gobjVoucherName.VoucherName.GetVoucherString(mintVtype) + strBranchID + uctxtInvoiceNo.Text;
                        }

                        strBatch = uctxtBatch1.Text;

                        i = invms.mSaveRequisition(strComID, strRefNo, mintVtype, dteDate.Value.ToShortDateString(),
                             Utility.Val(lblAmount.Text), Utility.gCheckNull(uctxtNarration.Text), strBranchID,
                               uctxtFromLocation.Text, uctxtProcessName.Text, Utility.Val(lblQnty.Text), 1, strGrid, mblnNumbMethod, strBatch);

                        if (i == "Inserted...")
                        {
                            btnNew.PerformClick();
                            mClear();
                            if (Utility.gblnAccessControl)
                            {
                                if (Utility.glngGetPriviliges(strComID, Utility.gstrUserName, 206, m_action))
                                {
                                    JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer();
                                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.StockRequisition;
                                    frmviewer.strFdate = "";
                                    frmviewer.strString = Utility.Mid(strRefNo, 6, strRefNo.Length - 6);
                                    frmviewer.strSelction = "T";
                                    frmviewer.Show();
                                    return;
                                }
                            }
                            else
                            {
                                JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer();
                                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.StockRequisition;
                                frmviewer.strFdate = "";
                                frmviewer.strString = Utility.Mid(strRefNo, 6, strRefNo.Length - 6);
                                frmviewer.strSelction = "T";
                                frmviewer.Show();
                                return;
                            }

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
                        for (int introw = 0; introw < DG.Rows.Count; introw++)
                        {
                            strGrid += DG[1, introw].Value.ToString() + "|" + DG[3, introw].Value.ToString() + "|" + DG[4, introw].Value.ToString() +
                                                    "|" + DG[5, introw].Value.ToString() + "|" + DG[6, introw].Value.ToString() + "~";
                        }


                        strBatch = uctxtBatch1.Text;

                        i = invms.mUpdateRequisitionNew(strComID, textBox1.Text, uctxtInvoiceNo.Text, mintVtype, dteDate.Value.ToShortDateString(),
                                 Utility.Val(lblAmount.Text), Utility.gCheckNull(uctxtNarration.Text), strBranchID,
                                   uctxtFromLocation.Text, uctxtProcessName.Text, Utility.Val(lblQnty.Text), 1, strGrid, mblnNumbMethod, strBatch);

                        if (i == "Updated...")
                        {
                            btnNew.PerformClick();
                            mClear();

                        }

                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }



            }

        }
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                DG.Rows.RemoveAt(e.RowIndex);
            }
            calculateTotal();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmStockRequisitionList objfrm = new frmStockRequisitionList();
            objfrm.intvType = mintVtype;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.onAddAllButtonClicked = new frmStockRequisitionList.AddAllClick(DisplayVoucherList);
            objfrm.strPreserveSQl = mstrPrserveSql;
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            uctxtInvoiceNo.Focus();
        }

        #endregion
        #region "List"
        private void DisplayVoucherList(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {
                int intrm = 0;

                uctxtInvoiceNo.Focus();


                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DG.Rows.Clear();

                uctxtInvoiceNo.Text = Utility.Mid(tests[0].strRefNo, 6, tests[0].strRefNo.Length - 6);
                textBox1.Text = tests[0].strRefNo;
                uctxtFromLocation.Text = tests[0].strLocation;
                uctxtProcessName.Text = tests[0].strProcess;
                dteDate.Text = tests[0].strDate;
                uctxtNarration.Text = tests[0].strNarration;
                txtBranch.Text = tests[0].strBranchName;
                uctxtBatch1.Text = tests[0].strBatch;
                mstrPrserveSql = tests[0].strPreserveSQL;
                List<StockItem> oRm = objWIS.mFillDisplayStockRequisition(strComID, tests[0].strRefNo).ToList();
                {
                    if (oRm.Count > 0)
                    {
                        foreach (StockItem ooRm in oRm)
                        {

                            DG.Rows.Add();
                            //dblclsQnty = Utility.gdblClosingStock(ooRm.strItemName, oRm[0].strLocation, "");
                            DG[0, intrm].Value = ooRm.strItemGroup;
                            DG[1, intrm].Value = ooRm.strItemName;
                            DG[2, intrm].Value = "";
                            DG[3, intrm].Value = Math.Abs(ooRm.dblOpnQty);
                            DG[4, intrm].Value = ooRm.strToUnit;
                            DG[5, intrm].Value = Math.Abs(ooRm.dblOpnRate);
                            DG[6, intrm].Value = Math.Abs(ooRm.dblOpnValue);
                            DG[7, intrm].Value = "";
                            DG[8, intrm].Value = "Delete";
                            DG[9, intrm].Value = ooRm.strBillKey;
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
        #endregion
        #region "Keyup"
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
        #region "Search"
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
        #endregion
        #region "CellEdut"
        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DG.Rows[e.RowIndex].Cells[6].Value = Utility.Val(DG.Rows[e.RowIndex].Cells[3].Value.ToString()) * Utility.Val(DG.Rows[e.RowIndex].Cells[5].Value.ToString());
            calculateTotal();
        }
        #endregion
        #region "Click"
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (uctxtProcessName.Text != "")
            {
                
                DisplayProcessRm(uctxtProcessName.Text, Utility.Val(uctxtProcessManuQty.Text));
                uctxtNarration.Focus();
            }
        }
        #endregion

        private void chkFG_Click(object sender, EventArgs e)
        {
            if (chkFG.Checked == true)
            {
                chkStationary.Checked = false;
                mLoadAllItem();
            }
          
        }

        private void btnSerach1_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 62))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmBatchconfig"] as frmBatchconfig == null)
            {
                frmBatchconfig objfrm = new frmBatchconfig();
                objfrm.MdiParent = this.MdiParent;
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.lngFormPriv = 62;
                objfrm.strFormName = "Batch Configuration";
                objfrm.mSingleEntry = 1;
                objfrm.MdiParent = this.MdiParent;
                objfrm.onAddAllButtonClicked = new frmBatchconfig.AddAllClick(Display);
                objfrm.Show();

            }
            else
            {
                frmBatchconfig objfrm = (frmBatchconfig)Application.OpenForms["frmBatchconfig"];
                objfrm.strFormName = "Batch Configuration";
                objfrm.lngFormPriv = 62;
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }


        private void Display(List<Batch> tests, object sender, EventArgs e)
        {
            try
            {
                uctxtBatch1.Text = tests[0].strLogNo;
                uctxtFromLocation.Focus();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            frmBatchConfigList objfrm = new frmBatchConfigList();
            objfrm.onAddAllButtonClicked = new frmBatchConfigList.AddAllClick(DisplayVoucherList);
            objfrm.MdiParent = MdiParent;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strPreserveSQl = mstrPrserveSql;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }
        private void DisplayVoucherList(List<Batch> tests, object sender, EventArgs e)
        {
            try
            {
                List<Batch> oogrp = invms.mDisPlaybatch(strComID, Convert.ToInt64(tests[0].lngSlno), "", "", "", "", "", "").ToList();
                if (oogrp.Count > 0)
                {
                    uctxtBatch1.Text = oogrp[0].strLogNo;
                    uctxtFromLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void chkStationary_Click(object sender, EventArgs e)
        {
            if (chkStationary.Checked == true)
            {
                chkFG.Checked = false;
                mLoadAllItem();
            }
        }
    }

}
