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
    public partial class frmStationery : JA.Shared.UI.frmSmartFormStandard
    {
        JRPT.SWRPTClient orptCnn = new SWRPTClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWIS = new SPWOIS();
        List<RoStationery> oogrp;
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int m_action { get; set; }
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
        List<InvoiceConfig> oinv;
        public int intvType { get; set; }
        private ListBox lstBranchName = new ListBox();
        private ListBox lstFromLocation = new ListBox();
        private ListBox lstToLocation = new ListBox();
 

        public int intconvert { get; set; }
        private string strComID { get; set; }
        public frmStationery()
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


    


            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);
            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);

            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);

            this.uclstGrdItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uclstGrdItem_KeyPress);
            this.uclstGrdItem.DoubleClick += new System.EventHandler(this.uclstGrdItem_DoubleClick);


            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);

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

            this.DG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DG_KeyDown);
            this.uclstGrdItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstGrdItem_CellFormatting);
          
            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstFromLocation, pnlMain, uctxtFromLocation);
            Utility.CreateListBox(lstToLocation, pnlMain, uctxtToLocation);

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
   


        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {
           
            lstBranchName.Visible = false;
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
        }
  
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {


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


        }
        private void mLoadAllItem()
        {
            int introw = 0;
            uclstGrdItem.Rows.Clear();

            oogrp = objWIS.mGetStationeryITemLoad(strComID).ToList();
         
            if (oogrp.Count > 0)
            {

                foreach (RoStationery ogrp in oogrp)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, introw].Value = ogrp.strItemName;
                    uclstGrdItem[1, introw].Value = ogrp.dblQty ;
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
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
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
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
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
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (Utility.gstrUserName == "DeepLaid")
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
            lstFromLocation.Visible = false;
            uclstGrdItem.Visible = false;
            lstToLocation.Visible = false;
        }

 
        private void uctxtFromLocation_TextChanged(object sender, EventArgs e)
        {
            lstFromLocation.SelectedIndex = lstFromLocation.FindString(uctxtFromLocation.Text);
        }

        private void lstFromLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtFromLocation.Text = lstFromLocation.Text;
            lstFromLocation.Visible = false;
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
                lstFromLocation.Visible = false;
                uctxtToLocation.Focus();
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

            lstBranchName.Visible = false;
            lstFromLocation.Visible = true;
            lstToLocation.Visible = false;
            uclstGrdItem.Visible = false;
            if (lstBranchName.SelectedValue != null)
            {
                lstFromLocation.ValueMember = "strLocation";
                lstFromLocation.DisplayMember = "strLocation";
                lstFromLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName,0).ToList();
            }
            lstFromLocation.SelectedIndex = lstFromLocation.FindString(uctxtFromLocation.Text);
            //mLoadAllItem();
        }


        private void uctxtToLocation_TextChanged(object sender, EventArgs e)
      {
            lstToLocation.SelectedIndex = lstToLocation.FindString(uctxtToLocation.Text);
        }

        private void lstToLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtToLocation.Text = lstToLocation.Text;
            lstToLocation.Visible = false;
            mLoadAllItem();
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
                lstToLocation.Visible = false;
                uctxtItemName.Focus();
                mLoadAllItem();
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

            lstBranchName.Visible = false;
            lstToLocation.Visible = true;
            lstFromLocation.Visible = false;
            uclstGrdItem.Visible = false;
            if (lstBranchName.SelectedValue != null)
            {
                lstToLocation.ValueMember = "strLocation";
                lstToLocation.DisplayMember = "strLocation";
                lstToLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, 0).ToList();
            }
            lstToLocation.SelectedIndex = lstToLocation.FindString(uctxtToLocation.Text);
           
        }



        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
            lstToLocation.Visible = true;
        }

        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranchName.Text;
            uctxtFromLocation.Focus();
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }
                uctxtFromLocation.Focus();
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
            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
           
          
            
            uclstGrdItem.Visible = false;
            
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
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
        private string mSaveConsumtion()
        {
            string  strBranchID = "", strDG = "", strmsg = "";
            int intRow = 1;

            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

            for (intRow = 0; intRow < DG.Rows.Count; intRow++)
            {

                if (DG[0, intRow].Value != null)
                {
     
                    strDG += DG[0, intRow].Value.ToString() + "|" + DG[1, intRow].Value.ToString() +
                                            "|" + DG[2, intRow].Value.ToString() + "|" +
                                            DG[3, intRow].Value.ToString() + "|" + DG[4, intRow].Value.ToString() + "~";
                }
            }

            strmsg = objWIS.mSaveStationery(strComID, uctxtInvoiceNo.Text, intvType, dteDate.Text, Utility.Val(lblnetAmount.Text), uctxtNarration.Text, strBranchID,
                                                uctxtFromLocation.Text, uctxtToLocation.Text, strDG,0);


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
                                     DG[3, intRow].Value.ToString() + "|" + DG[4, intRow].Value.ToString() + "~";
                }
            }
            
            strmsg = objWIS.mUpdateTranStationery(strComID,txtRefNo.Text, uctxtInvoiceNo.Text, intvType, dteDate.Text, Utility.Val(lblnetAmount.Text), uctxtNarration.Text, strBranchID,
                                                uctxtFromLocation.Text, uctxtToLocation.Text, strDG,0);
            
            return strmsg;
        }
        #endregion
        #region "Clear"
        private void mClear()
        {
     
            uctxtBranchName.Text="";
            uctxtFromLocation.Text = "";
            DG.Rows.Clear();
            uctxtNarration.Text = "";
            lblnetAmount.Text = "0";
            uctxtQty.Text = "";
            lblQty.Text = "0";
            lblnetAmount.Text = "0";
            uctxtToLocation.Text = "";
          
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod)
            {
                uctxtInvoiceNo.Text = Utility.gstrLastNumber(strComID, intvType);
                uctxtInvoiceNo.ReadOnly = true;
                if (Utility.gstrUserName == "DeepLaid")
                {
                    dteDate.Enabled = true;
                    dteDate.Focus();
                }
                else
                {

                    uctxtInvoiceNo.Select();
                }
            }
            else
            {

                uctxtInvoiceNo.Text = Utility.gobjNextNumber(uctxtInvoiceNo.Text);
                uctxtInvoiceNo.ReadOnly = false;
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
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, m_action))
            //    {
            //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //        return false;
            //    }
            //}

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
            if (uctxtFromLocation.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtFromLocation.Focus();
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
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_MASTER", "INV_REF_NO", uctxtInvoiceNo.Text);
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
                            {
                                strBillKey = DG[6, i].Value.ToString();
                            }
                            dblClosingQTY = Utility.gdblClosingStock(strComID, DG[0, i].Value.ToString(),uctxtFromLocation.Text,dteDate.Text);
                            if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            {
                                dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQtyStationary(strComID, strBillKey);
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
                            frmStationeryList objfrm = new frmStationeryList();
                            objfrm.intvType = intvType;
                            objfrm.onAddAllButtonClicked = new frmStationeryList.AddAllClick(DisplayVoucherList);
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
            frmStationeryList objfrm = new frmStationeryList();
            objfrm.intvType = intvType;
            objfrm.onAddAllButtonClicked = new frmStationeryList.AddAllClick(DisplayVoucherList);
            objfrm.lngFormPriv=lngFormPriv;
            objfrm.strFormName = strFormName;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
            uctxtInvoiceNo.Focus();
        }
        #endregion
        #region "Load"
        private void frmStationery_Load(object sender, EventArgs e)
        {
            lstBranchName.Visible = false;
            lstFromLocation.Visible = false;
           
            DG.AllowUserToAddRows = false;
            mGetConfig();
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            mClear();

       
                frmLabel.Text = "Stationary";
                lblRepackingFG.Visible = true;
                uctxtToLocation.Visible = true;
        
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 380, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Qty", "Qty", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 60, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, true, DataGridViewContentAlignment.TopLeft, true ));
            DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Bill Key", "Bill Key", 100, false, DataGridViewContentAlignment.TopLeft, false));
            //LoadDefaultValue();
           
        }
        #endregion
        #region "Default Value"
 
        #endregion
        #region "DisplayVoucher List"
        private void DisplayVoucherList(List<Stationery> tests, object sender, EventArgs e)
        {
            try
            {
                mClear();
                m_action = 2;
                int i=0;
                txtRefNo.Text = tests[0].strinvRefNo.ToString();
                uctxtInvoiceNo.Text = tests[0].strinvRefNo.ToString();

                List<RoStationery> oogrp = orptCnn.mGetStationery(strComID, tests[0].strinvRefNo.ToString()).ToList();
                        if (oogrp.Count >0)
                        {
                            foreach (RoStationery oinv in oogrp)
                            {

                                //oLedg.strBranchId = "Branch : " + Utility.gstrGetBranchName(strDeComID, dr["BRANCH_ID"].ToString());
                                DG.Rows.Add();
                                dteDate.Text = oinv.strinsertDate;
                                uctxtBranchName.Text = oinv.strBranchName;
                                uctxtNarration.Text = oinv.StringinvNarrations;
                                uctxtFromLocation.Text = oinv.strfromGodounName;
                                uctxtToLocation.Text = oinv.strtoGodounName;
                                DG[0, i].Value = oinv.strItemName;
                                DG[1, i].Value = oinv.dblQty.ToString();
                                DG[2, i].Value = oinv.strUnit;
                                DG[3, i].Value = oinv.dblRate;
                                DG[4, i].Value = oinv.dblinvAmount;
                                DG[5, i].Value = "Delete";
                                //DG[6, i].Value = oinv.strBillKey;
                                i += 1;
                            }
                            DG.AllowUserToAddRows = false;
                        }
                        calculateTotal();
                       
                    
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

        private void SearchListView(IEnumerable<RoStationery> tests, string searchString = "")
        {
            IEnumerable<RoStationery> query;
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
                foreach (RoStationery tran in query)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, i].Value = tran.strItemName;
                    uclstGrdItem[1, i].Value = tran.dblQty + " " + tran.strUnit; 
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
            frmStationeryList objfrm = new frmStationeryList();
            //objfrm.lngVtype  = 9999;
            objfrm.onAddAllButtonClicked = new frmStationeryList.AddAllClick(DisplayVoucherList);
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
            uctxtToLocation.Focus();
        }

        private void DisplayVoucherList(List<StockItem> tests, object sender, EventArgs e)
        {
            uctxtToLocation.Text = tests[0].strItemName;
        }




    }
}
