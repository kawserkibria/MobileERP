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
    public partial class frmMFGdilutionStore : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objwois = new SPWOIS();
        private ListBox lstLocation = new ListBox();
        private ListBox lstBranchName = new ListBox();
        private bool mblnNumbMethod { get; set; }
        public int intvType { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int m_action { get; set; }
        public int intConvert { get; set; }
        List<InvoiceConfig> oinv;
        List<StockItem> oogrp;
        List<StockItem> ooRm_WAS;
        private string mstrOldProcess { get; set; }
        private string strComID { get; set; }
        public frmMFGdilutionStore()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.dteDate_GotFocus);

            this.txtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNarration_KeyPress);
            this.txtNarration.GotFocus += new System.EventHandler(this.txtNarration_GotFocus);

            this.uctxtConsumption.GotFocus += new System.EventHandler(this.uctxtConsumption_GotFocus);
            this.uctxtConsumption.KeyDown += new KeyEventHandler(uctxtConsumption_KeyDown);
            this.uctxtConsumption.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtConsumption_KeyPress);
            this.ucRmList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ucRmList_KeyPress);
            this.ucRmList.DoubleClick += new System.EventHandler(this.ucRmList_DoubleClick);
            this.txtRmQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtRmQty_KeyPress);
            this.txtRmQty.GotFocus += new System.EventHandler(this.txtRmQty_GotFocus);

            this.uctxtFgItem.GotFocus += new System.EventHandler(this.uctxtFgItem_GotFocus);
            this.uctxtFgItem.KeyDown += new KeyEventHandler(uctxtFgItem_KeyDown);
            this.uctxtFgItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFgItem_KeyPress);
            this.ucFGList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ucFGList_KeyPress);
            this.ucFGList.DoubleClick += new System.EventHandler(this.ucFGList_DoubleClick);
            this.uctxtFgQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFgQty_KeyPress);


            this.uctxtLocation.KeyDown += new KeyEventHandler(uctxtLocation_KeyDown);
            this.uctxtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLocation_KeyPress);
            this.uctxtLocation.TextChanged += new System.EventHandler(this.uctxtLocation_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.uctxtLocation.GotFocus += new System.EventHandler(this.uctxtLocation_GotFocus);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);


            this.DgRm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgRm_CellContentClick);
            this.uctxtConsumption.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtConsumption_KeyUp);
            this.DgFG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgFG_CellContentClick);

            this.ucFGList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ucFGList_CellFormatting);
            this.ucRmList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ucRmList_CellFormatting);
           


            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);


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
        #region "User Define"
        private void txtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }

        }
        private void txtNarration_GotFocus(object sender, System.EventArgs e)
        {
            lstLocation.Visible = false;
            lstBranchName.Visible = false;
            ucFGList.Visible = false;
            ucRmList.Visible = false;
        }
        private void dteDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBranchName.Focus();
            }

        }
        private void dteDate_GotFocus(object sender, System.EventArgs e)
        {
            lstLocation.Visible = false;
            lstBranchName.Visible = false;
            ucFGList.Visible = false;
            ucRmList.Visible = false;
        }
        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }
        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            uctxtFgItem.Focus();
        }
        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                }
                lstLocation.Visible = false;
                uctxtFgItem.Focus();
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


            lstLocation.Visible = true;
            lstBranchName.Visible = false;
            ucFGList.Visible = false;
            ucRmList.Visible = false;
           
            if (lstBranchName.SelectedValue != null)
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, 0).ToList();
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
            ucFGList.Visible = false;
            ucRmList.Visible = false;
          
            lstBranchName.Visible = true;
            lstLocation.Visible = false;


            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }
        private void ucFGList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ucFGList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            ucFGList.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            ucFGList.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void ucRmList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ucRmList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            ucRmList.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            ucRmList.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void txtRmQty_GotFocus(object sender, System.EventArgs e)
        {
            ucFGList.Visible = false;
            ucRmList.Visible = false;
           

        }
        //*********************
        private void uctxtProcessName_GotFocus(object sender, System.EventArgs e)
        {
            
            ucFGList.Visible = false;
            ucRmList.Visible = false;
          
            lstBranchName.Visible = false;
            lstLocation.Visible = false;

        }
        private void uctxtConsumption_GotFocus(object sender, System.EventArgs e)
        {
            ucFGList.Visible = false;
            ucRmList.Visible = false;
          
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
           
        }
        private void txtRmQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtConsumption.Text != "")
                {
                    double dblrate = Utility.gdblGetCostPriceNew(strComID, uctxtConsumption.Text, dteDate.Text);
                    if (dblrate != 0)
                    {
                        mAddStockItem(DgRm, uctxtConsumption.Text, dblrate, Utility.Val(txtRmQty.Text));
                        uctxtConsumption.Text = "";
                        txtRmQty.Text = "";
                        uctxtConsumption.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Rate not Found");
                        txtRmQty.Focus();
                        txtRmQty.Text = "";
                        return;
                    }
                    
               
                }
                else
                {
                    uctxtConsumption.Focus();
                }
            }
        }
        private void ucRmList_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (ucFGList.SelectedRows.Count > 0)
            {
                uctxtConsumption.Text = Utility.GetDgValue(ucRmList, uctxtConsumption, 0);
                ucRmList.Visible = false;
                txtRmQty.Focus();


            }
        }
        private void ucRmList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtConsumption.Text = Utility.GetDgValue(ucRmList, uctxtConsumption, 0);
                ucRmList.Visible = false;
                txtRmQty.Focus();
            }
        }
        private void uctxtConsumption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (uctxtConsumption.Text == "")
                {
                    uctxtConsumption.Text = "";
                    ucRmList.Visible = false;
                    txtNarration.Focus();
                    return;
                }


                if (uctxtConsumption.Text != "")
                {
                    ucRmList.Focus();
                    if (ucRmList.Rows.Count > 0)
                    {
                        int i = 0;

                        uctxtConsumption.Text = ucRmList.Rows[i].Cells[0].Value.ToString();
                        ucFGList.Visible = false;
                        txtRmQty.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtConsumption.Text = ucRmList.Rows[i].Cells[0].Value.ToString();
                    ucRmList.Visible = false;
                    txtRmQty.Focus();
                }


            }
        }
        private void uctxtConsumption_KeyDown(object sender, KeyEventArgs e)
        {
            ucRmList.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                ucRmList.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                ucRmList.Focus();
            }

            ucRmList.Top = uctxtConsumption.Top + 25;
            ucRmList.Left = uctxtConsumption.Left;
            ucRmList.Width = uctxtConsumption.Width;
            ucRmList.Height = 150;
            //ucdgList.Size = new Size(546, 222);
            ucRmList.BringToFront();
            ucRmList.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }
       
        private void uctxtFgItem_GotFocus(object sender, System.EventArgs e)
        {
            ucFGList.Visible = false;
            ucRmList.Visible = false;
           
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
        }

        private void uctxtFgQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtFgItem.Text != "")
                {
                    mAddStockItem(DgFG, uctxtFgItem.Text,0, Utility.Val(uctxtFgQty.Text));
                    uctxtFgItem.Text = "";
                    uctxtFgQty.Text = "";
                    uctxtFgItem.Focus();
                }
                else
                {
                    uctxtConsumption.Focus();
                }
            }
        }
        private void ucFGList_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (ucFGList.SelectedRows.Count > 0)
            {
                uctxtFgItem.Text = Utility.GetDgValue(ucFGList, uctxtFgItem, 0);
                ucFGList.Visible = false;
                uctxtFgQty.Focus();


            }
        }
        private void ucFGList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtFgItem.Text = Utility.GetDgValue(ucFGList, uctxtFgItem, 0);
                ucFGList.Visible = false;
                uctxtFgQty.Focus();
            }
        }
        private void uctxtFgItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (uctxtFgItem.Text == "")
                {
                    uctxtFgItem.Text = "";
                    ucFGList.Visible = false;
                    uctxtConsumption.Focus();
                    return;
                }


                if (uctxtFgItem.Text != "")
                {
                    ucFGList.Focus();
                    if (ucFGList.Rows.Count > 0)
                    {
                        int i = 0;

                        uctxtFgItem.Text = ucFGList.Rows[i].Cells[0].Value.ToString();
                        ucFGList.Visible = false;
                        uctxtFgQty.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtFgItem.Text = ucFGList.Rows[i].Cells[0].Value.ToString();
                    ucFGList.Visible = false;
                    uctxtFgQty.Focus();
                }


            }
        }
        private void uctxtFgItem_KeyDown(object sender, KeyEventArgs e)
        {
            ucFGList.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                ucFGList.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                ucFGList.Focus();
            }

            ucFGList.Top = uctxtFgItem.Top + 25;
            ucFGList.Left = uctxtFgItem.Left;
            ucFGList.Width = uctxtFgItem.Width;
            ucFGList.Height = 200;
            //ucdgList.Size = new Size(546, 222);
            ucFGList.BringToFront();
            ucFGList.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }
        #endregion

        private void mAddStockItem(DataGridView dg, string strItemName,double dblrate, double dblQty)
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
                if (dg == DgFG)
                {
                    dg[3, selRaw].Value = 0;
                    dg[4, selRaw].Value = "Delete";
                }
                else if (dg == DgRm)
                {
                    dg[3, selRaw].Value = Math.Round(dblQty * dblrate,2);
                    dg[4, selRaw].Value = "Delete";
                }
                else
                {
                    dg[3, selRaw].Value = "Delete";
                }
                dg.AllowUserToAddRows = false;
                dg.ClearSelection();
                int nColumnIndex = 2;
                int nRowIndex = dg.Rows.Count - 1;
                dg.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                dg.FirstDisplayedScrollingRowIndex = nRowIndex;
                calculateTotal();
            }

        }

        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblRmAmount = 0, dblFGQty = 0;
            try
            {
                for (int i = 0; i < DgFG.Rows.Count; i++)
                {

                    dblFGQty = dblFGQty + Convert.ToDouble(DgFG.Rows[i].Cells[1].Value);

                }
                for (int i = 0; i < DgRm.Rows.Count; i++)
                {

                    dblRmAmount = dblRmAmount + Convert.ToDouble(DgRm.Rows[i].Cells[3].Value);

                }
                txtRMTotal.Text = dblRmAmount.ToString();
                txtFGQnty.Text = dblFGQty.ToString();
                if (dblRmAmount > 0 && dblFGQty > 0)
                {
                    lblFGRate.Text = "FG rate : " + Math.Round(dblRmAmount / dblFGQty, 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show ( ex.ToString());
            }
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
               
            }


        }
        #endregion
        private void frmMFGdilutionStore_Load(object sender, EventArgs e)
        {
            string strYesNo = "Y";
            mGetConfig();
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, 202, m_action))
                {
                    strYesNo = "N";
                }
            }
            DgFG.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 260, true, DataGridViewContentAlignment.TopLeft, true));
            DgFG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DgFG.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DgFG.Columns.Add(Utility.Create_Grid_Column("Cost(%)", "Cost(%)", 150, false, DataGridViewContentAlignment.TopLeft, true));
           // DgFG.Columns.Add(Utility.Create_Grid_Column_button("Show", "Show", "Show", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DgFG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            if (strYesNo == "Y")
            {
                DgRm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 150, true, DataGridViewContentAlignment.TopLeft, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Qnt.", "Qnt.", 70, true, DataGridViewContentAlignment.TopLeft, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, true, DataGridViewContentAlignment.TopLeft, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
            }
            else
            {
                DgRm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 270, true, DataGridViewContentAlignment.TopLeft, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Qnt.", "Qnt.", 70, true, DataGridViewContentAlignment.TopLeft, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, true, DataGridViewContentAlignment.TopLeft, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, false, DataGridViewContentAlignment.TopLeft, true));

                lblFGRate.Visible = false;
                txtRMTotal.Visible = false;
                label12.Visible = false;
            }
            //DgRm.Columns.Add(Utility.Create_Grid_Column_button("Show", "Show", "Show", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DgRm.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DgRm.Columns.Add(Utility.Create_Grid_Column("Key", "Key", 100, false, DataGridViewContentAlignment.TopLeft, false));

         

            DgFG.AllowUserToAddRows = false;
            DgRm.AllowUserToAddRows = false;
           
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
           
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            mClear();

        }
        private void mLoadAllItemRMWAS()
        {

            int introw = 0;
            this.ucRmList.DefaultCellStyle.Font = new Font("verdana", 10.5F);

           

            try
            {
                ucRmList.Rows.Clear();
                ooRm_WAS = invms.mloadAddStockItemRMPack(strComID, uctxtLocation.Text, "", "N").ToList();

                if (ooRm_WAS.Count > 0)
                {

                    foreach (StockItem ogrp in ooRm_WAS)
                    {
                        ucRmList.Rows.Add();
                        ucRmList[0, introw].Value = ogrp.strItemName;
                        ucRmList[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;
                        introw += 1;
                    }
                    ucRmList.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void mLoadAllItemFG()
        {
            int introw = 0;
            try
            {
                ucFGList.Rows.Clear();
                oogrp = invms.gFillStockItemAllWithoutGodown(strComID, false, "", "D").ToList();
                if (oogrp.Count > 0)
                {

                    foreach (StockItem ogrp in oogrp)
                    {
                        ucFGList.Rows.Add();
                        ucFGList[0, introw].Value = ogrp.strItemName;
                        ucFGList[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;
                        introw += 1;
                    }
                    ucFGList.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void mClear()
        {
            
            DgFG.Rows.Clear();
            DgRm.Rows.Clear();
            uctxtBranchName.Text = "";
            uctxtLocation.Text = "";
            txtNarration.Text = "";
            txtFGQnty.Text = "";
            txtRmQty.Text = "";
            txtRMTotal.Text = "";
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod)
            {
                uctxtInvoiceNo.Text = Utility.gstrLastNumber(strComID, intvType);
                uctxtInvoiceNo.ReadOnly = true;
                dteDate.Focus();
                dteDate.Select();
            }
            else
            {

                uctxtInvoiceNo.Text = Utility.gobjNextNumber(uctxtInvoiceNo.Text);
                uctxtInvoiceNo.ReadOnly = false;
                uctxtInvoiceNo.Focus();
                uctxtInvoiceNo.Select();
            }
           
        }

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
            if (DgRm.Rows.Count == 0)
            {
                MessageBox.Show("Item Cannot be Empty");
                uctxtConsumption.Focus();
                return false;
            }
            if (Utility.Val(txtRMTotal.Text) == 0 || Utility.Val(txtFGQnty.Text) < 0)
            {
                MessageBox.Show("Net Amount be Empty");
                uctxtConsumption.Focus();
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
            string strBranchID = lstBranchName.SelectedValue.ToString();

            if (oinv[0].mlngBlockNegativeStock > 0)
            {
                for (int i = 0; i < DgRm.Rows.Count; i++)
                {
                    try
                    {
                        if (DgRm[0, i].Value.ToString() != "")
                        {
                            if (DgRm[5, i].Value != null)
                                strBillKey = DgRm[5, i].Value.ToString();
                            //dblClosingQTY = Utility.gdblClosingStockNew(strComID, DG[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);

                            dblClosingQTY = Utility.gdblClosingStock(strComID, DgRm[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);

                            if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            {
                                dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey, uctxtLocation.Text);
                            }
                            dblCurrentQTY = Utility.Val(DgRm[1, i].Value.ToString());
                            if ((dblClosingQTY) - dblCurrentQTY < 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + DgRm[0, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                            else if (dblClosingQTY == 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + DgRm[0, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    dblClosingQTY = 0;
                }
                if (intCheckNegetive > 0)
                {
                    MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                    dblClosingQTY = 0;
                    DgRm.Focus();
                    return false;
                }
            }


            return true;
        }

        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strFG = "", strRM = "", strRefNumber = "", i = "";

            if (ValidateFields() == false)
            {
                return;
            }

           
           

            string strbranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                try
                {

                    for (int intRow = 0; intRow < DgFG.Rows.Count; intRow++)
                    {
                        if (DgFG[0, intRow].Value != null)
                        {
                            strFG = strFG + Utility.gCheckNull(DgFG[0, intRow].Value.ToString()) + "|" + Utility.Val(DgFG[1, intRow].Value.ToString()) + "|" +
                                Utility.gCheckNull(DgFG[2, intRow].Value.ToString()) + "|" + Utility.Val(DgFG[3, intRow].Value.ToString()) + "~";
                        }
                    }

                    for (int intRow = 0; intRow < DgRm.Rows.Count; intRow++)
                    {
                        if (DgRm[0, intRow].Value != null)
                        {
                            strRM = strRM + Utility.gCheckNull(DgRm[0, intRow].Value.ToString()) + "|" + Utility.Val(DgRm[1, intRow].Value.ToString()) + "|" + Utility.gCheckNull(DgRm[2, intRow].Value.ToString()) + "|" + Utility.gCheckNull(DgRm[3, intRow].Value.ToString()) + "~";
                        }

                    }

                    if (m_action == 1)
                    {
                        if (mblnNumbMethod == false)
                        {
                            strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intvType) + strbranchID + uctxtInvoiceNo.Text;
                        }
                        else
                        {
                            strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intvType) + strbranchID + Utility.gstrLastNumber(strComID, intvType);
                        }
                    }
                    else
                    {
                        strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intvType) + strbranchID + uctxtInvoiceNo.Text;
                    }

                    i = objwois.mSaveDilutionStore(strComID, strRefNumber, intvType, dteDate.Text, txtNarration.Text, strbranchID, uctxtLocation.Text, strFG, strRM, Utility.Val(txtRMTotal.Text), Utility.Val(txtFGQnty.Text), mblnNumbMethod, m_action);

                    if (i == "1")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Dilution Store", "",
                                                                    m_action, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                        }
                        mClear();
                        m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmMFGdilutionStoreList objfrm = new frmMFGdilutionStoreList();
            objfrm.onAddAllButtonClicked = new frmMFGdilutionStoreList.AddAllClick(DisplayProcess);
            objfrm.MdiParent = this.MdiParent;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.intVtype = intvType;
            objfrm.Show();
        }

        private void DisplayProcess(List<MFGvouhcer> tests, object sender, EventArgs e)
        {
            try
            {


                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DgFG.Rows.Clear();
                DgRm.Rows.Clear();
                dteDate.Focus();
                int intrm = 0, intFg = 0;
                List<MFGvouhcer> ooItem = invms.DisplayDilutionstore(strComID, tests[0].strVoucherNo).ToList();
                if (ooItem.Count > 0)
                {

                    uctxtInvoiceNo.Text = ooItem[0].strVoucherNo;
                    uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, ooItem[0].strBranchId);
                    
                    dteDate.Text = ooItem[0].strDate;
                    txtNarration.Text = ooItem[0].strNarration;
                    foreach (MFGvouhcer ts in ooItem)
                    {

                        if (ts.strINOutFlag.TrimEnd() == "O")
                        {
                            DgRm.Rows.Add();
                            uctxtLocation.Text = ts.strLocation;
                            DgRm[0, intrm].Value = ts.strItemName;
                            DgRm[1, intrm].Value =  Math.Abs(ts.dblQnty);
                            DgRm[2, intrm].Value = Utility.gGetBaseUOM(strComID, ts.strItemName);
                            DgRm[3, intrm].Value = Math.Abs(ts.dblAmount);
                            DgRm[4, intrm].Value = "Delete";
                            DgRm[5, intrm].Value = ts.strBillKey;
                            
                            intrm += 1;
                            DgRm.AllowUserToAddRows = false;
                        }
                        else
                        {
                            DgFG.Rows.Add();
                           
                            DgFG[0, intFg].Value = ts.strItemName;
                            DgFG[1, intFg].Value = ts.dblQnty;
                            DgFG[2, intFg].Value = Utility.gGetBaseUOM(strComID, ts.strItemName);
                            DgFG[3, intFg].Value = "Delete";
                            intFg += 1;
                            DgFG.AllowUserToAddRows = false;
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

        private void DgRm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==4)
            {
                DgRm.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void DgFG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DgFG.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uctxtFgItem_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //this.ucFGList.DefaultCellStyle.Font = new Font("verdana", 15.5F);
                SearchListViewFG(oogrp, uctxtFgItem.Text);
            }
            catch (Exception EX)
            {

            }
        }

        private void SearchListViewFG(IEnumerable<StockItem> tests, string searchString = "")
        {
            IEnumerable<StockItem> query;
      
            query = tests;
            if (searchString != "")
            {
                query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }
            ucFGList.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    ucFGList.Rows.Add();
                    ucFGList[0, i].Value = tran.strItemName;
                    ucFGList[1, i].Value = tran.dblClsBalance + " "+ tran.strUnit; ;
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void uctxtConsumption_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                SearchListViewRm(ooRm_WAS, uctxtConsumption.Text);
            }
            catch (Exception EX)
            {

            }
        }

       

        private void SearchListViewRm(IEnumerable<StockItem> tests, string searchString = "")
        {
            IEnumerable<StockItem> query;
        
            query = tests;

            if (searchString != "")
            {
                query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }
          
            ucRmList.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    ucRmList.Rows.Add();
                    ucRmList[0, i].Value = tran.strItemName;
                    ucRmList[1, i].Value = tran.dblClsBalance + " "+ tran.strUnit;
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            mLoadAllItemFG();
            mLoadAllItemRMWAS();
        }

      

     

      
    }
}
