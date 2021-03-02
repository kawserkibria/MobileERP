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
    public partial class frmProcessInformation : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();

        private ListBox lstLocation = new ListBox();
        private ListBox lstBranchName = new ListBox();
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int m_action { get; set; }
        public int intConvert { get; set; }
        List<StockItem> oogrp;
        List<StockItem> ooRm_WAS;
        private string mstrOldProcess { get; set; }
        private string strComID { get; set; }
        public frmProcessInformation()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtProcessName.KeyDown += new KeyEventHandler(uctxtProcessName_KeyDown);
            this.uctxtProcessName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtProcessName_KeyPress);
            this.uctxtProcessName.TextChanged += new System.EventHandler(this.uctxtProcessName_TextChanged);
            this.uctxtProcessName.GotFocus += new System.EventHandler(this.uctxtProcessName_GotFocus);

            this.uctxtConsumption.GotFocus += new System.EventHandler(this.uctxtConsumption_GotFocus);
            this.uctxtConsumption.KeyDown += new KeyEventHandler(uctxtConsumption_KeyDown);
            this.uctxtConsumption.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtConsumption_KeyPress);
            this.ucRmList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ucRmList_KeyPress);
            this.ucRmList.DoubleClick += new System.EventHandler(this.ucRmList_DoubleClick);
            this.txtRmQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtRmQty_KeyPress);
            this.txtRmQty.GotFocus += new System.EventHandler(this.txtRmQty_GotFocus);
            
            this.uctxtWastage.GotFocus += new System.EventHandler(this.uctxtWastage_GotFocus);
            this.uctxtWastage.KeyDown += new KeyEventHandler(uctxtWastage_KeyDown);
            this.uctxtWastage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtWastage_KeyPress);
            this.ucWastageList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ucWastageList_KeyPress);
            this.ucWastageList.DoubleClick += new System.EventHandler(this.ucWastageList_DoubleClick);
            this.txtWasQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtWasQty_KeyPress);

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
            this.DgWastage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgWastage_CellContentClick);
            this.DgFG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgFG_CellContentClick);

            this.ucFGList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ucFGList_CellFormatting);
            this.ucRmList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ucRmList_CellFormatting);
            this.ucWastageList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ucWastageList_CellFormatting);


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
            ucWastageList.Visible = false;
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
            ucWastageList.Visible = false;
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
        private void ucWastageList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ucWastageList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            ucWastageList.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            ucWastageList.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void uctxtProcessName_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtProcessName.SelectionStart;
            uctxtProcessName.Text = Utility.gmakeProperCase(uctxtProcessName.Text);
            uctxtProcessName.SelectionStart = x;
        }
        private void txtRmQty_GotFocus(object sender, System.EventArgs e)
        {
            ucFGList.Visible = false;
            ucRmList.Visible = false;
            ucWastageList.Visible = false;

        }

        private void uctxtWastage_GotFocus(object sender, System.EventArgs e)
        {
            ucFGList.Visible = false;
            ucRmList.Visible = false;
            ucWastageList.Visible = false;

        }

        private void txtWasQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtWastage.Text != "")
                {
                    mAddStockItem(DgWastage, uctxtWastage.Text, Utility.Val(txtWasQty.Text));
                    uctxtWastage.Text = "";
                    txtWasQty.Text = "";
                    uctxtWastage.Focus();
                }
                else
                {
                    btnSave.Focus();
                }
            }
        }
        private void ucWastageList_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (ucWastageList.SelectedRows.Count > 0)
            {
                uctxtWastage.Text = Utility.GetDgValue(ucWastageList, uctxtWastage, 0);
                ucWastageList.Visible = false;
                txtWasQty.Focus();


            }
        }
        private void ucWastageList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtWastage.Text = Utility.GetDgValue(ucWastageList, uctxtWastage, 0);
                ucWastageList.Visible = false;
                txtWasQty.Focus();
            }
        }
        private void uctxtWastage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (uctxtWastage.Text == "")
                {
                    uctxtWastage.Text = "";
                    ucWastageList.Visible = false;
                    btnSave.Focus();
                    return;
                }


                if (uctxtWastage.Text != "")
                {
                    ucWastageList.Focus();
                    if (ucWastageList.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtWastage.Text = ucWastageList.Rows[i].Cells[0].Value.ToString();
                        ucWastageList.Visible = false;
                        txtWasQty.Focus();
                    }
                }
                else
                {
                    int i = 0;
                    uctxtWastage.Text = ucWastageList.Rows[i].Cells[0].Value.ToString();
                    ucWastageList.Visible = false;
                    txtWasQty.Focus();
                }


            }
        }
        private void uctxtWastage_KeyDown(object sender, KeyEventArgs e)
        {
            ucWastageList.Visible = true;
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
            if (e.KeyCode == Keys.Up)
            {
                ucWastageList.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                ucWastageList.Focus();
            }

            ucWastageList.Top = uctxtWastage.Top + 25;
            ucWastageList.Left = uctxtWastage.Left;
            ucWastageList.Width = uctxtWastage.Width;
            ucWastageList.Height = 110;
            //ucdgList.Size = new Size(546, 222);
            ucWastageList.BringToFront();
            ucWastageList.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }
        //*********************
        private void uctxtProcessName_GotFocus(object sender, System.EventArgs e)
        {
            
            ucFGList.Visible = false;
            ucRmList.Visible = false;
            ucWastageList.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;

        }

        private void uctxtConsumption_GotFocus(object sender, System.EventArgs e)
        {
            ucFGList.Visible = false;
            ucRmList.Visible = false;
            ucWastageList.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
        }

        private void txtRmQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtConsumption.Text != "")
                {
                    mAddStockItem(DgRm, uctxtConsumption.Text, Utility.Val(txtRmQty.Text));
                    uctxtConsumption.Text = "";
                    txtRmQty.Text = "";
                    uctxtConsumption.Focus();
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
                    //uctxtWastage.Focus();
                    btnSave.Focus();
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
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
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
        private void uctxtProcessName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 1)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_MENU_PROCESS_MAIN", "PROCESS_NAME", uctxtProcessName.Text);
                    if (strDuplicate != "")
                    {

                        MessageBox.Show(strDuplicate);
                        uctxtProcessName.Text = "";
                        uctxtProcessName.Focus();
                        return;

                    }
                }


                uctxtBranchName.Focus();
            }
        }
        private void uctxtProcessName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                //uctxtItemName.AppendText(Interaction.GetSetting(Application.ExecutablePath, "StockItem", "ItemName"));
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                uctxtProcessName.AppendText((String)rk.GetValue("ProcessName", ""));
                rk.Close();
            }

        }
        private void uctxtFgItem_GotFocus(object sender, System.EventArgs e)
        {
            ucFGList.Visible = false;
            ucRmList.Visible = false;
            ucWastageList.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
        }

        private void uctxtFgQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtFgItem.Text != "")
                {
                    mAddStockItem(DgFG, uctxtFgItem.Text, Utility.Val(uctxtFgQty.Text));
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
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
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
       
      
        private void mAddStockItem(DataGridView dg, string strItemName, double dblQty)
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
                    dg[3, selRaw].Value = 100;
                    dg[4, selRaw].Value = "Delete";
                }
                else if (dg == DgRm)
                {
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
               // calculateTotal();
            }

        }




        #endregion

        private void frmProcessInformation_Load(object sender, EventArgs e)
        {
            DgFG.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 350, true, DataGridViewContentAlignment.TopLeft, true));
            DgFG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DgFG.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DgFG.Columns.Add(Utility.Create_Grid_Column("Cost(%)", "Cost(%)", 150, true, DataGridViewContentAlignment.TopLeft, true));
           // DgFG.Columns.Add(Utility.Create_Grid_Column_button("Show", "Show", "Show", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DgFG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            DgRm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 500, true, DataGridViewContentAlignment.TopLeft, true));
            DgRm.Columns.Add(Utility.Create_Grid_Column("Qnt.", "Qnt.", 110, true, DataGridViewContentAlignment.TopLeft, false));
            DgRm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 90, true, DataGridViewContentAlignment.TopLeft, true));
            DgRm.Columns.Add(Utility.Create_Grid_Column("Cost(%)", "Cost(%)", 200, false, DataGridViewContentAlignment.TopLeft, false));
            //DgRm.Columns.Add(Utility.Create_Grid_Column_button("Show", "Show", "Show", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DgRm.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            DgWastage.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 500, true, DataGridViewContentAlignment.TopLeft, true));
            DgWastage.Columns.Add(Utility.Create_Grid_Column("Qnt.", "Qnt.", 110, true, DataGridViewContentAlignment.TopLeft, false));
            DgWastage.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 90, true, DataGridViewContentAlignment.TopLeft, true));
            DgRm.Columns.Add(Utility.Create_Grid_Column("Cost(%)", "Cost(%)", 200, false, DataGridViewContentAlignment.TopLeft, true));
           // DgWastage.Columns.Add(Utility.Create_Grid_Column_button("Show", "Show", "Show", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DgWastage.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            DgFG.AllowUserToAddRows = false;
            DgRm.AllowUserToAddRows = false;
            DgWastage.AllowUserToAddRows = false;
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            if (intConvert==0)
            {
                frmLabel.Text = "MFG Process Entry";
            }
            else
            {
                frmLabel.Text = "FG to FG Process Entry";
            }

            mLoadAllItemFG();
            if (intConvert==1)
            {
                chkconversionFg.Checked = true;
                chkTransfer.Visible = false;
                mLoadAllItemConversion();
                
            }
            else
            {
                mLoadAllItemRMWAS();
                chkconversionFg.Checked = false;
                chkTransfer.Visible = true;
            }

        }
        private void mLoadAllItemRMWAS()
        {
            
            int introw = 0;
            //long lngLedgerGroup = 0, lngLedgerManufacFroup = 0;
            this.ucRmList.DefaultCellStyle.Font = new Font("verdana", 10.5F);
            this.ucWastageList.DefaultCellStyle.Font = new Font("verdana", 10.5F);

            ucRmList.Rows.Clear();
            ucWastageList.Rows.Clear();
            try
            {


                ooRm_WAS = invms.mloadAddStockItemRMPack(strComID, "","","N").ToList();
                if (ooRm_WAS.Count > 0)
                {

                    foreach (StockItem ogrp in ooRm_WAS)
                    {
                        ucRmList.Rows.Add();
                        ucWastageList.Rows.Add();
                        ucRmList[0, introw].Value = ogrp.strItemName;
                        ucRmList[1, introw].Value = ogrp.dblClsBalance + " "+ ogrp.strUnit;
                        ucWastageList[0, introw].Value = ogrp.strItemName;
                        ucWastageList[1, introw].Value = ogrp.dblClsBalance + " "+ ogrp.strUnit;

                        //if (introw % 2 == 0)
                        //{
                        //    ucRmList.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                        //    ucWastageList.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                        //}
                        //else
                        //{
                        //    ucRmList.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                        //    ucWastageList.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                        //}
                        introw += 1;
                    }
                    ucWastageList.AllowUserToAddRows = false;
                    ucRmList.AllowUserToAddRows = false;
                }
            }
            catch(Exception ex)
            {

            }
        }


        private void mLoadAllItemFG()
        {
            int introw = 0;
            //long lngLedgerGroup = 0, lngLedgerManufacFroup = 0;
            //this.ucFGList.DefaultCellStyle.Font = new Font("verdana", 15.5F);
            ucFGList.Rows.Clear();
            oogrp = invms.mloadAddStockItemFg(strComID, "").ToList();
            if (oogrp.Count > 0)
            {

                foreach (StockItem ogrp in oogrp)
                {
                    ucFGList.Rows.Add();
                    ucFGList[0, introw].Value = ogrp.strItemName;
                   // ucFGList[1, introw].Value = ogrp.strItemcode;
                    //ucFGList[2, introw].Value = ogrp.strUnit;
                    ucFGList[1, introw].Value = ogrp.dblClsBalance + " "+ ogrp.strUnit;

                    //if (introw % 2 == 0)
                    //{
                    //    ucFGList.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    ucFGList.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                ucFGList.AllowUserToAddRows = false;
            }
        }

        private void mClear()
        {
            uctxtProcessName.Text = "";
            DgFG.Rows.Clear();
            DgRm.Rows.Clear();
            uctxtBranchName.Text = "";
            uctxtLocation.Text = "";
            chkconversionFg.Checked = false;
            DgWastage.Rows.Clear();
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            uctxtProcessName.Focus();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strFG = "", strRM = "", strDGwastage = "", i="";
            int intConversionfg,intTransfer=0;
            if (chkconversionFg.Checked == true)
            {
                intConversionfg = 1;
            }
            else
            {
                intConversionfg = 0;
            }
            if (intConversionfg == 0)
            {
                if (chkTransfer.Checked == true)
                {
                    intTransfer = 0;
                }
                else
                {
                    intTransfer = 1;
                }
            }
            else
            {
                intTransfer = 0;
            }

            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (uctxtProcessName.Text =="")
            {
                MessageBox.Show("Cannot empty");
                uctxtProcessName.Focus();
                return;
            }
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Cannot empty");
                uctxtBranchName.Focus();
                return;
            }
            if (uctxtLocation.Text == "")
            {
                MessageBox.Show("Cannot empty");
                uctxtLocation.Focus();
                return;
            }
            if (m_action==1)
            {
                RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
                rk.SetValue("ProcessName",uctxtProcessName.Text);
                rk.Close();
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_MENU_PROCESS_MAIN", "PROCESS_NAME", uctxtProcessName.Text);
                if (strDuplicate != "")
                {

                    MessageBox.Show(strDuplicate);
                    uctxtProcessName.Text = "";
                    uctxtProcessName.Focus();
                    return;

                }
            }

            if (m_action == 2)
            {
                if (mstrOldProcess != uctxtProcessName.Text)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_MENU_PROCESS_MAIN", "PROCESS_NAME", uctxtProcessName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtProcessName.Text = mstrOldProcess;
                        uctxtProcessName.Focus();
                        return;
                    }
                }
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
                            strRM = strRM + Utility.gCheckNull(DgRm[0, intRow].Value.ToString()) + "|" + Utility.Val(DgRm[1, intRow].Value.ToString()) + "|" + Utility.gCheckNull(DgRm[2, intRow].Value.ToString()) + "~";
                        }
                          
                    }

                    for (int intRow = 0; intRow < DgWastage.Rows.Count; intRow++)
                    {
                        if (DgWastage[0, intRow].Value != null)
                        {
                            strDGwastage = strDGwastage + Utility.gCheckNull(DgWastage[0, intRow].Value.ToString()) + "|" + Utility.Val(DgWastage[1, intRow].Value.ToString()) + "|" + Utility.gCheckNull(DgWastage[2, intRow].Value.ToString()) + "~";
                        }
                    }


                    i = invms.mInsertProcess(strComID, mstrOldProcess, uctxtProcessName.Text, strFG, strRM, strDGwastage, m_action, intConversionfg, intTransfer, strbranchID,uctxtLocation.Text);

                    if (i == "Inseretd...")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, uctxtProcessName.Text,
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
            frmProcessInformationList objfrm = new frmProcessInformationList();
            objfrm.onAddAllButtonClicked = new frmProcessInformationList.AddAllClick(DisplayProcess);
            objfrm.MdiParent = this.MdiParent;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.intVtype = intConvert;
            objfrm.Show();
        }

        private void DisplayProcess(List<ManuProcess> tests, object sender, EventArgs e)
        {
            try
            {

                int intrm = 0,intfg=0,intwastage=0;
                uctxtProcessName.Focus();
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DgFG.Rows.Clear();
                DgRm.Rows.Clear();
                DgWastage.Rows.Clear();
                List<ManuProcess> ooItem = invms.mDisplayProcess(strComID, tests[0].strProcessName,"P").ToList();
                if (ooItem.Count > 0)
                {
                    mstrOldProcess = tests[0].strProcessName;
                    uctxtProcessName.Text = tests[0].strProcessName;
                    uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, ooItem[0].strBranchID);
                    
                    if (ooItem[0].intConverttype == 1)
                    {
                        chkconversionFg.Checked = true;
                    }
                    else
                    {
                        chkconversionFg.Checked = false;
                    }
                    foreach (ManuProcess ts in ooItem)
                    {
                        uctxtLocation.Text = ts.strGodown;
                        if (ts.intType == 1)
                        {
                            DgRm.Rows.Add();
                            DgRm[0, intrm].Value = ts.stritemName;
                            DgRm[1, intrm].Value = ts.dblqnty;
                            DgRm[2, intrm].Value = ts.strUnit;
                            DgRm[4, intrm].Value = "Delete";
                            intrm += 1;
                            DgRm.AllowUserToAddRows = false;
                        }
                        if (ts.intType == 3)
                        {
                            DgWastage.Rows.Add();
                            DgWastage[0, intwastage].Value = ts.stritemName;
                            DgWastage[1, intwastage].Value = ts.dblqnty;
                            DgWastage[2, intwastage].Value = ts.strUnit;
                            DgWastage[3, intwastage].Value = "Delete";
                            intwastage += 1;
                            DgWastage.AllowUserToAddRows = false;
                        }
                        if (ts.intType == 2)
                        {
                            DgFG.Rows.Add();
                            DgFG[0, intfg].Value = ts.stritemName;
                            DgFG[1, intfg].Value = ts.dblqnty;
                            DgFG[2, intfg].Value = ts.strUnit;
                            DgFG[3, intfg].Value = ts.dblCostPercent;
                            DgFG[4, intfg].Value = "Delete";
                            intfg += 1;
                            DgFG.AllowUserToAddRows = false;
                        }

                       

                    }

                }

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

        private void DgWastage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DgWastage.Rows.RemoveAt(e.RowIndex);
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
            //this.ucFGList.DefaultCellStyle.Font = new Font("verdana", 15.5F);
            SearchListViewFG(oogrp, uctxtFgItem.Text);
        }

        private void SearchListViewFG(IEnumerable<StockItem> tests, string searchString = "")
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
            SearchListViewRm(ooRm_WAS, uctxtConsumption.Text);
        }

        private void uctxtWastage_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListVieWWm(ooRm_WAS, uctxtWastage.Text);
        }

        private void SearchListViewRm(IEnumerable<StockItem> tests, string searchString = "")
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

        private void SearchListVieWWm(IEnumerable<StockItem> tests, string searchString = "")
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
            ucWastageList.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    ucWastageList.Rows.Add();
                    ucWastageList[0, i].Value = tran.strItemName;
                    ucWastageList[1, i].Value = tran.dblClsBalance + " "+ tran.strUnit;
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void chkconversionFg_Click(object sender, EventArgs e)
        {
            //if (chkconversionFg.Checked==true)
            //{
            //    uctxtProcessName.Focus();
            //    mLoadAllItemConversion();
            //}
            //else
            //{
            //    uctxtProcessName.Focus();
            //    mLoadAllItemRMWAS();
            //}
        }

        private void mLoadAllItemConversion()
        {
            int introw = 0;
            //long lngLedgerGroup = 0, lngLedgerManufacFroup = 0;
            this.ucRmList.DefaultCellStyle.Font = new Font("verdana", 10.5F);
            this.ucWastageList.DefaultCellStyle.Font = new Font("verdana", 10.5F);
            ucRmList.Rows.Clear();
            ucWastageList.Rows.Clear();
            try
            {


                ooRm_WAS = invms.mloadAddStockItemFg(strComID, "").ToList();
                if (oogrp.Count > 0)
                {

                    foreach (StockItem ogrp in ooRm_WAS)
                    {
                        ucRmList.Rows.Add();
                        ucWastageList.Rows.Add();
                        ucRmList[0, introw].Value = ogrp.strItemName;
                        ucWastageList[0, introw].Value = ogrp.strItemName;
                        ucRmList[1, introw].Value = ogrp.dblClsBalance+ " "+ ogrp.strUnit;
                        ucWastageList[1, introw].Value = ogrp.dblClsBalance +" " + ogrp.strUnit;
                        //if (introw % 2 == 0)
                        //{
                        //    ucRmList.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                        //    ucWastageList.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                        //}
                        //else
                        //{
                        //    ucRmList.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                        //    ucWastageList.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                        //}
                        introw += 1;
                    }
                    ucRmList.AllowUserToAddRows = false;
                    ucWastageList.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void chkconversionFg_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uctxtConsumption_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void btnFGProcess_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmProcessFG"] as frmProcessFG == null)
            {
                frmProcessFG objfrm = new frmProcessFG();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmProcessFG objfrm = (frmProcessFG)Application.OpenForms["frmProcessFG"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

      

     

      
    }
}
