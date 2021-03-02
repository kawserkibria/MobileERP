using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Accms.Forms;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSalesOrder : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstPartyName = new ListBox();
        private ListBox lstSalesRep = new ListBox();
        private ListBox lstBranch = new ListBox();
        private ListBox lstLocation = new ListBox();
        public int m_action { get; set; }
        public long mlngvtype { get; set; }
        public long mlngSlNo { get; set; }
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
        List<StockItem> oogrp;
        private string strComID { get; set; }
        public frmSalesOrder()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);

            this.uclstGrdItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uclstGrdItem_KeyPress);
            this.uclstGrdItem.DoubleClick += new System.EventHandler(this.uclstGrdItem_DoubleClick);

            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);

            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtRate.LostFocus += new System.EventHandler(this.uctxtRate_LostFocus);

            this.uctxtSalesOrderNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSalesOrderNo_KeyPress);
            this.uctxtSalesOrderNo.GotFocus += new System.EventHandler(this.uctxtSalesOrderNo_GotFocus);

            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.uctxtDate_GotFocus);

            this.dteDueDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDueDate_KeyPress);
            this.dteDueDate.GotFocus += new System.EventHandler(this.dteDueDate_GotFocus);

            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);
            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);

            this.uctxtdelivery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtdelivery_KeyPress);
            this.uctxtdelivery.GotFocus += new System.EventHandler(this.uctxtdelivery_GotFocus);

            this.uctxtSupportWarrenty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSupportWarrenty_KeyPress);
            this.uctxtSupportWarrenty.GotFocus += new System.EventHandler(this.uctxtSupportWarrenty_GotFocus);

            this.uctxtOthersterms.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtOthersterms_KeyPress);
            this.uctxtOthersterms.GotFocus += new System.EventHandler(this.uctxtOthersterms_GotFocus);

            this.uctxtPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPayment_KeyPress);
            this.uctxtPayment.GotFocus += new System.EventHandler(this.uctxtPayment_GotFocus);

            this.uctxtValidityQuotation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtValidityQuotation_KeyPress);
            this.uctxtValidityQuotation.GotFocus += new System.EventHandler(this.uctxtValidityQuotation_GotFocus);

            this.uctxtPartyName.KeyDown += new KeyEventHandler(uctxtPartyName_KeyDown);
            this.uctxtPartyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPartyName_KeyPress);
            this.uctxtPartyName.TextChanged += new System.EventHandler(this.uctxtPartyName_TextChanged);
            this.lstPartyName.DoubleClick += new System.EventHandler(this.lstPartyName_DoubleClick);
            this.uctxtPartyName.GotFocus += new System.EventHandler(this.uctxtPartyName_GotFocus);

            this.uctxtSalesRepresentive.KeyDown += new KeyEventHandler(uctxtSalesRepresentive_KeyDown);
            this.uctxtSalesRepresentive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSalesRepresentive_KeyPress);
            this.uctxtSalesRepresentive.TextChanged += new System.EventHandler(this.uctxtSalesRepresentive_TextChanged);
            this.lstSalesRep.DoubleClick += new System.EventHandler(this.lstSalesRep_DoubleClick);
            this.uctxtSalesRepresentive.GotFocus += new System.EventHandler(this.uctxtSalesRepresentive_GotFocus);

            this.uctxtbranchName.KeyDown += new KeyEventHandler(uctxtbranchName_KeyDown);
            this.uctxtbranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtbranchName_KeyPress);
            this.uctxtbranchName.TextChanged += new System.EventHandler(this.uctxtbranchName_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtbranchName.GotFocus += new System.EventHandler(this.uctxtbranchName_GotFocus);

            this.uctxtLocation.KeyDown += new KeyEventHandler(uctxtLocation_KeyDown);
            this.uctxtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLocation_KeyPress);
            this.uctxtLocation.TextChanged += new System.EventHandler(this.uctxtLocation_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.uctxtLocation.GotFocus += new System.EventHandler(this.uctxtLocation_GotFocus);

            Utility.CreateListBox(lstPartyName, pnlMain, uctxtPartyName);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtbranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            Utility.CreateListBox(lstSalesRep, pnlMain, uctxtSalesRepresentive);

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
        private void uctxtdelivery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtSupportWarrenty.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtdelivery, sender, e);
            }

        }
        private void uctxtdelivery_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
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
        private void uctxtRate_LostFocus(object sender, System.EventArgs e)
        {
            double dblQty = 0, dblRate = 0;
            if (uctxtItemName.Text != "")
            {
                if (uctxtQty.Text == "")
                {
                    dblQty = 0;
                }
                else
                {
                    dblQty = Convert.ToDouble(uctxtQty.Text);
                }
                if (uctxtRate.Text == "")
                {
                    dblRate = 0;
                }
                else
                {
                    dblRate = Convert.ToDouble(uctxtRate.Text);
                }
                mAdditem(uctxtItemName.Text, dblQty, dblRate);
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
        private void DisplayFromQty(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {

                uctxtItemName.Text = tests[0].strItemName;
            }
            catch (Exception ex)
            {

            }
        }
        

        private void mAdditem(string strItemName, double dblQty, double dblRate)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < DG.RowCount; j++)
            {
                if (DG[0, j].Value != null)
                {
                    strDown = DG[0, j].Value.ToString();
                }
                if (strItemName == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {

                DG.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DG.RowCount.ToString());
                selRaw = selRaw - 1;
                DG.Rows.Add();
                DG[0, selRaw].Value = strItemName;
                DG[1, selRaw].Value = dblQty ;
                DG[2, selRaw].Value = Utility.gGetBaseUOM(strComID,  strItemName);
                DG[3, selRaw].Value = dblRate;
                DG[4, selRaw].Value = Math.Round(dblQty * dblRate,2);
                DG.AllowUserToAddRows = false;
                uctxtItemName.Text = "";
                uctxtQty.Text = "";
                uctxtRate.Text = "";
                uctxtItemName.Focus();
                calculateTotal();
            }

        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            double dblrate = 0;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (mlngvtype == (int)Utility.VOUCHER_TYPE.vtSALES_ORDER)
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
                PriorSetFocusText(uctxtQty, sender, e);
            }
        }

        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
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

        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
        }

        private void uctxtOthersterms_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtPayment.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtOthersterms, sender, e);
            }
        }

        private void uctxtOthersterms_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtValidityQuotation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtValidityQuotation, sender, e);
            }
        }
        private void uctxtValidityQuotation_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtValidityQuotation.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtPayment, sender, e);
            }
        }

        private void uctxtPayment_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtSupportWarrenty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtOthersterms.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtSupportWarrenty, sender, e);
            }
        }

        private void uctxtSupportWarrenty_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtdelivery.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtNarration, sender, e);
            }
        }

        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void dteDueDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtbranchName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                uctxtSalesRepresentive.Focus();
            }
        }

        private void dteDueDate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtPartyName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                uctxtSalesOrderNo.Focus();
            }
        }

        private void uctxtDate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtSalesOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteDate.Focus();

            }
        }

        private void uctxtSalesOrderNo_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            mLoadAllItem();
            uctxtItemName.Focus();
        }

        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                    mLoadAllItem();
                }
                uctxtItemName.Focus();
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
            lstLocation.Visible = true;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            lstPartyName.Visible = false;
            uclstGrdItem.Visible = false;
            if (uctxtbranchName.Text !="")
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                lstLocation.DataSource = invms.gLoadLocation(strComID, Utility.gstrGetBranchID(strComID, uctxtbranchName.Text.ToString()), Utility.gblnAccessControl, Utility.gstrUserName,1).ToList();
            }
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }



        private void uctxtbranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtbranchName.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtbranchName.Text = lstBranch.Text;
            uctxtLocation.Focus();
        }

        private void uctxtbranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtbranchName.Text = lstBranch.Text;
                }
                uctxtLocation.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtbranchName, sender, e);
            }
        }
        private void uctxtbranchName_KeyDown(object sender, KeyEventArgs e)
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

        private void uctxtbranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = true;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtbranchName.Text);
        }
        private void uctxtSalesRepresentive_TextChanged(object sender, EventArgs e)
        {
            lstSalesRep.SelectedIndex = lstSalesRep.FindString(uctxtSalesRepresentive.Text);
        }

        private void lstSalesRep_DoubleClick(object sender, EventArgs e)
        {
            uctxtSalesRepresentive.Text = lstSalesRep.Text;
            dteDueDate.Focus();
        }

        private void uctxtSalesRepresentive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstSalesRep.Items.Count > 0)
                {
                    uctxtSalesRepresentive.Text = lstSalesRep.Text;
                }
                dteDueDate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtSalesRepresentive, sender, e);
            }
        }
        private void uctxtSalesRepresentive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstSalesRep.SelectedItem != null)
                {
                    lstSalesRep.SelectedIndex = lstSalesRep.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstSalesRep.Items.Count - 1 > lstSalesRep.SelectedIndex)
                {
                    lstSalesRep.SelectedIndex = lstSalesRep.SelectedIndex + 1;
                }
            }

        }

        private void uctxtSalesRepresentive_GotFocus(object sender, System.EventArgs e)
        {
            lstSalesRep.Visible = true;
            lstBranch.Visible = false;
            lstLocation.Visible = false;
            lstPartyName.Visible = false;
            uclstGrdItem.Visible = false;
            lstSalesRep.SelectedIndex = lstSalesRep.FindString(uctxtSalesRepresentive.Text);

        }



        private void uctxtPartyName_TextChanged(object sender, EventArgs e)
        {
            lstPartyName.SelectedIndex = lstPartyName.FindString(uctxtPartyName.Text);
        }

        private void lstPartyName_DoubleClick(object sender, EventArgs e)
        {
            uctxtPartyName.Text = lstPartyName.Text;
            uctxtSalesRepresentive.Focus();
        }

        private void uctxtPartyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstPartyName.Items.Count > 0)
                {
                    uctxtPartyName.Text = lstPartyName.Text;
                }
                uctxtSalesRepresentive.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtPartyName, sender, e);
            }
        }
        private void uctxtPartyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstPartyName.SelectedItem != null)
                {
                    lstPartyName.SelectedIndex = lstPartyName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstPartyName.Items.Count - 1 > lstPartyName.SelectedIndex)
                {
                    lstPartyName.SelectedIndex = lstPartyName.SelectedIndex + 1;
                }
            }

        }

        private void uctxtPartyName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = true;
            lstBranch.Visible = false;
            lstLocation.Visible = false;
            lstSalesRep.Visible = false;
            uclstGrdItem.Visible = false;
            lstPartyName.SelectedIndex = lstPartyName.FindString(uctxtPartyName.Text);
        }

        #endregion
        #region "All Item"
        private void mLoadAllItem()
        {
            int introw = 0;
            if (uctxtLocation.Text == "")
            {
                return;
            }
            oogrp = invms.gFillStockItem(strComID, uctxtLocation.Text, "", false).ToList();
            if (oogrp.Count > 0)
            {

                foreach (StockItem ogrp in oogrp)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, introw].Value = ogrp.strItemName;
                    uclstGrdItem[1, introw].Value = ogrp.dblClsBalance;

                    if (introw % 2 == 0)
                    {
                        uclstGrdItem.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        uclstGrdItem.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    }
                    introw += 1;
                }
                uclstGrdItem.AllowUserToAddRows = false;
            }


        }
        #endregion

        #region "Getconfig"
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, (long)mlngvtype).ToList();
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
        private void frmSalesOrder_Load(object sender, EventArgs e)
        {
            mGetConfig();
            mClear();
            

            lstPartyName.Visible = false;
            lstLocation.Visible = false;
            lstBranch.Visible = false;
            lstSalesRep.Visible = false;
            if (mlngvtype ==(long)Utility.VOUCHER_TYPE.vtSALES_ORDER)
            {
                frmLabel.Text = "Sales Order";
            }
            else if (mlngvtype ==(long)Utility.VOUCHER_TYPE.vtPURCHASE_ORDER)
            {
                frmLabel.Text = "Purchase Order";
            }

            this.DG.DefaultCellStyle.Font = new Font("verdana", 10);
            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 380, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Qty", "Qty", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 60, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            if (mlngvtype == (long)Utility.VOUCHER_TYPE.vtSALES_ORDER)
            {
                lstPartyName.ValueMember = "strSalesLedger";
                lstPartyName.DisplayMember = "strSalesLedger";
                lstPartyName.DataSource = invms.gFillSalesLedger(strComID, (long)Utility.GR_GROUP_TYPE.grCUSTOMER).ToList();
            }
            else
            {
                lstPartyName.ValueMember = "strSalesLedger";
                lstPartyName.DisplayMember = "strSalesLedger";
                lstPartyName.DataSource = invms.gFillSalesLedger(strComID, (long)Utility.GR_GROUP_TYPE.grSUPPLIER).ToList();
            }

            lstSalesRep.ValueMember = "strSalesLedger";
            lstSalesRep.DisplayMember = "strSalesLedger";
            lstSalesRep.DataSource = invms.gFillSalesLedger(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP).ToList();
            mLoadAllItem();

        }
        #endregion
        #region "Save"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "", strGrid = "", strBranchID = "", strRefNo="";
            if (uctxtSalesOrderNo.Text == "")
            {
                MessageBox.Show("Order Name Cannot be Empty");
                uctxtSalesOrderNo.Focus();
                return;
            }
            if (uctxtPartyName.Text == "")
            {
                MessageBox.Show("Party Name Cannot be Empty");
                uctxtPartyName.Focus();
                return;
            }
            if (Utility.Val(lblTotalAmnt.Text) == 0 || Utility.Val(lblTotalAmnt.Text) < 0)
            {
                MessageBox.Show("Net Amount be Empty");
                uctxtItemName.Focus();
                return ;
            }
            if (Utility.gblnBranch)
            {
                strBranchID = Utility.gstrGetBranchID(strComID, uctxtbranchName.Text);
            }
            else
            {
                strBranchID = Utility.gstrBranchID;
            }

            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        for (int introw = 0; introw < DG.Rows.Count; introw++)
                        {
                            strGrid += DG[0, introw].Value.ToString() + "," + DG[1, introw].Value.ToString() + "," + DG[2, introw].Value.ToString() +
                                                    "," + DG[3, introw].Value.ToString() + "," + DG[4, introw].Value.ToString() + "~";
                        }
                        if (mlngvtype == (long)Utility.VOUCHER_TYPE.vtSALES_ORDER)
                        {
                            if (mblnNumbMethod)
                            {
                                strRefNo = gobjVoucherName.VoucherName.GetVoucherString(mlngvtype) + strBranchID + Utility.gstrLastNumber(strComID, (int)mlngvtype);
                                //strRefNo = Utility.gstrLastNumber((int)mlngvtype);
                            }
                            else
                            {
                                //strRefNo = Utility.vtSALES_ORDER_STR + strBranchID + uctxtSalesOrderNo.Text;
                                strRefNo = gobjVoucherName.VoucherName.GetVoucherString(mlngvtype) + strBranchID + Utility.gstrLastNumber(strComID, (int)mlngvtype);
                            }
                        }
                        else
                        {
                            if (mblnNumbMethod)
                            {
                                strRefNo = gobjVoucherName.VoucherName.GetVoucherString(mlngvtype) + strBranchID + Utility.gstrLastNumber(strComID, (int)mlngvtype);
                                //strRefNo = Utility.gstrLastNumber((int)mlngvtype);
                            }
                            else
                            {
                                //strRefNo = Utility.vtSALES_ORDER_STR + strBranchID + uctxtSalesOrderNo.Text;
                                strRefNo = gobjVoucherName.VoucherName.GetVoucherString(mlngvtype) + strBranchID + Utility.gstrLastNumber(strComID, (int)mlngvtype);
                            }
                        }

                        i = invms.msaveSalesOrder(strComID, strRefNo, mlngvtype, dteDate.Value.ToShortDateString(), dteDate.Value.ToShortDateString(),
                                                dteDate.Value.ToString("MMMyy"), uctxtPartyName.Text, Utility.Val(lblTotalAmnt.Text), Utility.gCheckNull(uctxtNarration.Text),
                                                strBranchID, uctxtLocation.Text, 0, uctxtSalesRepresentive.Text, Utility.gCheckNull(uctxtdelivery.Text), Utility.gCheckNull(uctxtPayment.Text),
                                                Utility.gCheckNull(uctxtSupportWarrenty.Text), Utility.gCheckNull(uctxtValidityQuotation.Text),
                                                Utility.gCheckNull(uctxtOthersterms.Text), strGrid, false, 0, "", mblnNumbMethod, Utility.gstrUserName, 0, "", "", 
                                                Utility.Val(lblTotalQnty.Text),0,0);

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
                        for (int introw = 0; introw < DG.Rows.Count; introw++)
                        {
                            strGrid += DG[0, introw].Value.ToString() + "," + DG[1, introw].Value.ToString() + "," + DG[2, introw].Value.ToString() +
                                                    "," + DG[3, introw].Value.ToString() + "," + DG[4, introw].Value.ToString() + "~";
                        }

                        i = invms.mUpdateSalesOrder(strComID, textBox1.Text, mlngvtype, dteDate.Value.ToShortDateString(), dteDate.Value.ToShortDateString(),
                                                dteDate.Value.ToString("MMMyy"), uctxtPartyName.Text, Utility.Val(lblTotalAmnt.Text), Utility.gCheckNull(uctxtNarration.Text),
                                                strBranchID, uctxtLocation.Text, 0, uctxtSalesRepresentive.Text, Utility.gCheckNull(uctxtdelivery.Text), Utility.gCheckNull(uctxtPayment.Text),
                                                Utility.gCheckNull(uctxtSupportWarrenty.Text), Utility.gCheckNull(uctxtValidityQuotation.Text), 
                                                Utility.gCheckNull(uctxtOthersterms.Text), strGrid, false, 0, "", Utility.gstrUserName,0,"","", Utility.Val(lblTotalQnty.Text),0,0,0);

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
        #region "Clear"
        private void mClear()
        {
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            uctxtSalesOrderNo.Text = "";
            textBox1.Text = "";
            uctxtPartyName.Text = "";
            uctxtSalesRepresentive.Text = "";
            uctxtbranchName.Text = "";
            uctxtLocation.Text = "";
            uctxtNarration.Text = "";
            uctxtOthersterms.Text = "";
            uctxtPayment.Text = "";
            uctxtSupportWarrenty.Text = "";
            uctxtOthersterms.Text = "";
            uctxtValidityQuotation.Text = "";
            uctxtdelivery.Text = "";
            lblTotalAmnt.Text = "0";
            lblTotalQnty.Text = "0";
            DG.Rows.Clear();
            if (mblnNumbMethod)
            {
                uctxtSalesOrderNo.Text = Utility.gstrLastNumber(strComID, (int)mlngvtype);
                uctxtSalesOrderNo.ReadOnly = true;
                dteDate.Select();
            }
            else
            {
                uctxtSalesOrderNo.Text = Utility.gobjNextNumber(uctxtSalesOrderNo.Text);
                uctxtSalesOrderNo.ReadOnly = false;
                uctxtSalesOrderNo.Select();
            }

            uctxtSalesOrderNo.Focus();



        }
        #endregion
        #region "Edit"
        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmAccountsVoucherList objfrm = new frmAccountsVoucherList();
            objfrm.mintVType = (int)mlngvtype;
            objfrm.onAddAllButtonClicked = new frmAccountsVoucherList.AddAllClick(DisplayVoucherList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            uctxtSalesOrderNo.Focus();
        }
        #endregion
        #region "Display Voucher"
        private void DisplayVoucherList(List<AccountsVoucher> tests, object sender, EventArgs e)
        {
            try
            {
                int introw = 0;
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DG.Rows.Clear();

                List<AccountsVoucher> ooaccVou = accms.DisplayCompVoucherList(strComID, tests[0].strVoucherNo, mlngvtype).ToList();
                if (ooaccVou.Count > 0)
                {
                    foreach (AccountsVoucher oCom in ooaccVou)
                    {
                        textBox1.Text = oCom.strVoucherNo;
                        uctxtSalesOrderNo.Text = Utility.Mid(oCom.strVoucherNo,6,oCom.strVoucherNo.Length-6);
                        dteDate.Text = oCom.strTranDate;
                        dteDueDate.Text = oCom.strDueDate;
                        uctxtPartyName.Text = oCom.strLedgerName;
                        uctxtSalesRepresentive.Text = oCom.strSalesRepresentive;
                        uctxtbranchName.Text = Utility.gstrGetBranchName(strComID, oCom.strBranchID);
                        uctxtNarration.Text = oCom.strNarration;
                        uctxtdelivery.Text = oCom.strDelivery;
                        uctxtSupportWarrenty.Text = oCom.strSupport;
                        uctxtOthersterms.Text = oCom.strOthers;
                        uctxtPayment.Text = oCom.strtermofPayment;
                        uctxtValidityQuotation.Text = oCom.strValidityDate;
                        List<AccBillwise> ooVouList = accms.DisplayBillWise(strComID, oCom.strVoucherNo).ToList();
                            if (ooVouList.Count > 0)
                            {
                                introw = 0;
                                foreach (AccBillwise oacc in ooVouList)
                                {
                                    DG.Rows.Add();
                                    uctxtLocation.Text = oacc.strGodownsName;
                                    DG[0, introw].Value = oacc.strStockItemName;
                                    DG[1, introw].Value = oacc.dblQnty;
                                    DG[2, introw].Value = oacc.strPer;
                                    DG[3, introw].Value = oacc.dblRate;
                                    DG[4, introw].Value = oacc.dblAmount;
                                    introw += 1;
                                }
                            }
                            DG.AllowUserToAddRows = false;
                        }
                        uctxtSalesOrderNo.Focus();
                        calculateTotal();

                    }



            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblNetAmount = 0, dblQnty=0;

            for (int i = 0; i < DG.Rows.Count; i++)
            {
                dblQnty = dblQnty + Utility.Val(DG.Rows[i].Cells[1].Value.ToString());
                dblNetAmount = dblNetAmount + Utility.Val(DG.Rows[i].Cells[4].Value.ToString());
            }

            lblTotalQnty.Text = dblQnty.ToString();
            lblTotalAmnt.Text = dblNetAmount.ToString();

        }
        #endregion
        #region "Grid Content Click"
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==5)
            {
                DG.Rows.RemoveAt(e.RowIndex);
                calculateTotal();
            }
        }
        #endregion

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

        #region "Key Up"
        private void uctxtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (oogrp.Count > 0)
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
            uclstGrdItem.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, i].Value = tran.strItemName;
                    uclstGrdItem[1, i].Value = tran.dblClsBalance;
                    if (i % 2 == 0)
                    {
                        uclstGrdItem.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        uclstGrdItem.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #endregion
    }
}
