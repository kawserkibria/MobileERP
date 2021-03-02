﻿using Dutility;
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
    public partial class frmStockStationary : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstFromLocation = new ListBox();
        private ListBox lstToLocation = new ListBox();
       
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
        public frmStockStationary()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            // this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            #region "User In"
            this.uctxtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtInvoiceNo_KeyPress);
            this.uctxtInvoiceNo.GotFocus += new System.EventHandler(this.uctxtInvoiceNo_GotFocus);

            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.dteDate_GotFocus);

            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);
            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);

           

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

            this.uctxtToLocation.KeyDown += new KeyEventHandler(uctxtToLocation_KeyDown);
            this.uctxtToLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtToLocation_KeyPress);
            this.uctxtToLocation.TextChanged += new System.EventHandler(this.uctxtToLocation_TextChanged);
            this.lstToLocation.DoubleClick += new System.EventHandler(this.lstToLocation_DoubleClick);
            this.uctxtToLocation.GotFocus += new System.EventHandler(this.uctxtToLocation_GotFocus);

          
            this.uclstGrdItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstGrdItem_CellFormatting);

            Utility.CreateListBox(lstFromLocation, pnlMain, uctxtFromLocation);
            Utility.CreateListBox(lstToLocation, pnlMain, uctxtToLocation);
         
            #endregion

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
            
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
          

        }
       
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
          
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
           
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtRate.Text = Utility.gdblGetCostPriceNew(strComID, uctxtItemName.Text, dteDate.Text).ToString();

                if (Utility.Val(uctxtRate.Text) == 0)
                {
                   
                    MessageBox.Show("Rate Cannot be Empty");
                    uctxtQty.Focus();
                    return;
                }
                else
                {
                    mAddStockItem(DG, uctxtItemName.Text, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), "");
                    uctxtItemName.Text = "";
                    uctxtQty.Text = "";
                    uctxtItemName.Focus();
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
           
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
         
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
            
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
           
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
            
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
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
            
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
            
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
    
        private void uctxtToLocation_TextChanged(object sender, EventArgs e)
        {
            lstToLocation.SelectedIndex = lstToLocation.FindString(uctxtToLocation.Text);
        }

        private void lstToLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtToLocation.Text = lstToLocation.Text;
            uctxtItemName.Focus();
        }

        private void uctxtToLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstToLocation.Items.Count > 0)
                {
                    uctxtToLocation.Text = lstToLocation.Text;
                }
                uctxtItemName.Focus();
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

            lstFromLocation.Visible = false;
            lstToLocation.Visible = true;
           
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
            //if (uctxtFromLocation.Text != "")
            //{
            //    mLoadAllItem();
            //}
            uctxtToLocation.Focus();
        }

        private void uctxtFromLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstFromLocation.Items.Count > 0)
                {
                    uctxtFromLocation.Text = lstFromLocation.Text;
                }
                //if (uctxtFromLocation.Text != "")
                //{
                //    mLoadAllItem();
                //}
                uctxtToLocation.Focus();
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
          
            //string strBranchID = Utility.gstrGetBranchIDfromGodown(strComID, uctxtFromLocation.Text.Trim());
            //oogrp = invms.mloadAddStockItemRMPack(strComID, uctxtFromLocation.Text, "", "STA").ToList();
            oogrp = objWIS.mGetProductStatementView(strComID,"","0001", uctxtFromLocation.Text, "STA").ToList();
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

            lstFromLocation.Visible = true;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
           
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
        private void frmStockStationary_Load(object sender, EventArgs e)
        {
            string strYesNo = "Y";
            mGetConfig();
            mClear(); ;
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            lstFromLocation.Visible = false;
          
            DG.AllowUserToAddRows = false;

            frmLabel.Text = "Stationary Use";
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
                DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 400, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Curr. Stock", "Curr. Stock", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 60, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 130, true, DataGridViewContentAlignment.TopLeft, true));
            }
            else
            {
                DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 520, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Curr. Stock", "Curr. Stock", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 200, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 60, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 130, false, DataGridViewContentAlignment.TopLeft, true));
                label8.Visible = false;
                lblAmount.Visible = false;
            }
            DG.Columns.Add(Utility.Create_Grid_Column("Batch", "Batch", 150, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("InvTranKey", "InvTranKey", 200, false, DataGridViewContentAlignment.TopLeft, true));

            lstToLocation.ValueMember = "strLocation";
            lstToLocation.DisplayMember = "strLocation";
            lstToLocation.DataSource = invms.gLoadLocation(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName,2).ToList();
            //lstToLocation.DataSource = new BindingSource(invms.gLoadLocationEndofList(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName, 2), null);
            

            lstFromLocation.ValueMember = "strLocation";
            lstFromLocation.DisplayMember = "strLocation";
            lstFromLocation.DataSource = invms.gLoadLocation(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName,2).ToList();

            //lstProcess.ValueMember = "strProcessName";
            //lstProcess.DisplayMember = "strProcessName";
            //lstProcess.DataSource = invms.mLoadProcess(strComID, "", "", 0,0).ToList();

        }
        private void mClear()
        {
            uctxtFromLocation.Text = "";
            uctxtToLocation.Text = "";
            DG.Rows.Clear();
            uctxtItemName.Text = "";
            
            uctxtRate.Text = "";
            uctxtNarration.Text = "";
            lblAmount.Text = "";
            uctxtQty.Text = "";
            uctxtNarration.Text = "";
            
            lblQnty.Text = "";
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
           
            if (mblnNumbMethod)
            {
                uctxtInvoiceNo.Text = Utility.gstrLastNumber(strComID, mintVtype);
                uctxtInvoiceNo.ReadOnly = true;
                dteDate.Select();
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
            string i = "", strDG = "", strBranchId = "",strToBranchId="", strRefNumber,strProcess="";
            int intRow = 0;

            strBranchId = Utility.gstrGetBranchID(strComID, uctxtFromLocation.Text);
            strToBranchId = Utility.gstrGetBranchID(strComID, uctxtToLocation.Text);
          
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
                            strRefNumber = "TS" + strBranchId + uctxtInvoiceNo.Text;
                        }
                        else
                        {
                            strRefNumber = "TS" + strBranchId + Utility.gstrLastNumber(strComID, mintVtype);
                        }

                        i = objWIS.mSaveStockTransfer(strComID, strRefNumber, (long)mintVtype, dteDate.Text, Utility.Val(lblAmount.Text),
                                                   Utility.gCheckNull(uctxtNarration.Text), strBranchId, strToBranchId,Utility.gCheckNull(uctxtFromLocation.Text),
                                                   Utility.gCheckNull(uctxtToLocation.Text), strDG, mblnNumbMethod, strProcess);

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
                        i = objWIS.mUpdateStockTransfer(strComID, textBox1.Text, (long)mintVtype, dteDate.Text, Utility.Val(lblAmount.Text),
                                                   Utility.gCheckNull(uctxtNarration.Text), strBranchId, strToBranchId, Utility.gCheckNull(uctxtFromLocation.Text),
                                                   Utility.gCheckNull(uctxtToLocation.Text), strDG,strProcess);

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

            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
            //    {
            //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //        return false;
            //    }
            //}
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
            //if (Utility.Val(lblAmount.Text) == 0 || Utility.Val(lblAmount.Text) < 0)
            //{
            //    MessageBox.Show("Net Amount Cannot be Empty");
            //    uctxtItemName.Focus();
            //    return false;
            //}
            string strLockvoucher = Utility.gLockVocher(strComID, mintVtype);
            long lngDate = Convert.ToInt64(Convert.ToDateTime(dteDate.Text).ToString("yyyyMMdd"));
            if (strLockvoucher != "")
            {
                long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strLockvoucher).ToString("yyyyMMdd"));
                if (lngDate <= lngBackdate)
                {
                    MessageBox.Show("Invalid Date, Back Date is locked");
                    return false;
                }
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
                        if (DG[8, i].Value != null)
                        {
                            strBillKey = DG[8, i].Value.ToString();
                        }
                        else
                        {
                            strBillKey = "";
                        }

                        dblClosingQTY = Utility.gdblClosingStock(strComID, DG[0, i].Value.ToString(), uctxtFromLocation.Text, dteDate.Text);
                        //dblClosingQTY = Utility.gdblClosingStockSales(strComID, DG[0, i].Value.ToString(), strBranchID, "",uctxtFromLocation.Text);
                        if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                        {
                            dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey, uctxtFromLocation.Text);
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
            string i="";
            if (ValidateFields() == false)
            {
                return;
            }

            try
            {
                i = mStockTransfer();
                //MessageBox.Show(i);
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
                calculateTotal();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmStockTransferList objfrm = new frmStockTransferList();
            objfrm.intvType = mintVtype;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFlag = "O";
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
                uctxtInvoiceNo.Focus();
               
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DG.Rows.Clear();
                if (mintVtype == (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER)
                {
                    uctxtInvoiceNo.Text = Utility.Mid(tests[0].strRefNo,6,tests[0].strRefNo.Length-6);
                    textBox1.Text = tests[0].strRefNo;
                   // uctxtFromLocation.Text = tests[0].strBranchName;
                    dteDate.Text = tests[0].strDate;
                    uctxtNarration.Text = tests[0].strNarration;
                    List<StockItem> oRm = objWIS.mFillDisplayStockTransfer(strComID, tests[0].strRefNo).ToList();
                    {
                        if (oRm.Count > 0)
                        {
                            foreach (StockItem ooRm in oRm)
                            {
                                if (ooRm.strInOUT.ToString().ToUpper().TrimEnd() == "O")
                                {
                                    DG.Rows.Add();
                                    //dblclsQnty = Utility.gdblClosingStock(ooRm.strItemName, oRm[0].strLocation, "");
                                    DG[0, intrm].Value = ooRm.strItemName;
                                    DG[1, intrm].Value = dblclsQnty;
                                    DG[2, intrm].Value = Math.Abs( ooRm.dblOpnQty);
                                    DG[3, intrm].Value = Utility.gGetBaseUOM(strComID, ooRm.strItemName);
                                    DG[4, intrm].Value = Math.Abs( ooRm.dblOpnRate);
                                    DG[5, intrm].Value = Math.Abs( ooRm.dblOpnValue);
                                    //DG[6, intrm].Value = ooRm.strBatch;
                                    DG[7, intrm].Value = "Delete";
                                    uctxtFromLocation.Text  =ooRm.strToLocation;
                                   
                                    DG[8, intrm].Value = ooRm.strBillKey;
                                    intrm += 1;
                                    DG.AllowUserToAddRows = false;
                                }
                                else
                                {
                                    uctxtToLocation.Text = ooRm.strToLocation;
                                }
                            }
                        }
                    }

                }
                else if (mintVtype == (int)Utility.VOUCHER_TYPE.vtSTATIONARY)
                {
                    uctxtInvoiceNo.Text = Utility.Mid(tests[0].strRefNo, 6, tests[0].strRefNo.Length - 6);
                    textBox1.Text = tests[0].strRefNo;
                    // uctxtFromLocation.Text = tests[0].strBranchName;
                    dteDate.Text = tests[0].strDate;
                    uctxtNarration.Text = tests[0].strNarration;
                    List<StockItem> oRm = objWIS.mFillDisplayStockStationary(strComID, tests[0].strRefNo, tests[0].strFromLocation).ToList();
                    {
                        if (oRm.Count > 0)
                        {
                            uctxtFromLocation.Text = Utility.gstrGetLocation(strComID, tests[0].strRefNo, "O");
                            foreach (StockItem ooRm in oRm)
                            {
                                if (ooRm.strInOUT.ToString().ToUpper().TrimEnd() == "O")
                                {
                                    DG.Rows.Add();
                                    //dblclsQnty = Utility.gdblClosingStock(ooRm.strItemName, oRm[0].strLocation, "");
                                    DG[0, intrm].Value = ooRm.strItemName;
                                    DG[1, intrm].Value = dblclsQnty;
                                    DG[2, intrm].Value = Math.Abs(ooRm.dblOpnQty);
                                    DG[3, intrm].Value = Utility.gGetBaseUOM(strComID, ooRm.strItemName);
                                    DG[4, intrm].Value = Math.Abs(ooRm.dblOpnRate);
                                    DG[5, intrm].Value = Math.Abs(ooRm.dblOpnValue);
                                    //DG[6, intrm].Value = ooRm.strBatch;
                                    DG[7, intrm].Value = "Delete";


                                    uctxtToLocation.Text = tests[0].strToLocation;

                                    DG[8, intrm].Value = ooRm.strBillKey;
                                    intrm += 1;
                                    DG.AllowUserToAddRows = false;
                                }
                                else
                                {
                                    if (ooRm.strToLocation != Utility.gcEND_OF_LIST)
                                    {
                                        uctxtToLocation.Text = tests[0].strToLocation;
                                    }
                                    else
                                    {
                                        uctxtToLocation.Text = Utility.gcEND_OF_LIST;
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

                SearchListView(oogrp, uctxtItemName.Text);

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
                         where test.strItemName.ToString().StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
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

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DG.Rows[e.RowIndex].Cells[5].Value = Utility.Val(DG.Rows[e.RowIndex].Cells[2].Value.ToString()) * Utility.Val(DG.Rows[e.RowIndex].Cells[4].Value.ToString());
            calculateTotal();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (System.Windows.Forms.Application.OpenForms["frmStockStationaryReturn"] as frmStockStationaryReturn == null)
        //    {
        //        frmStockStationaryReturn objfrm = new frmStockStationaryReturn();
        //        objfrm.MdiParent = this.MdiParent;
        //        objfrm.Show();

        //    }
        //    else
        //    {
        //        frmStockStationaryReturn objfrm = (frmStockStationaryReturn)Application.OpenForms["frmStockStationaryReturn"];
        //        objfrm.Focus();
        //        objfrm.MdiParent = this.MdiParent;
        //    }
        //}
    }

}
