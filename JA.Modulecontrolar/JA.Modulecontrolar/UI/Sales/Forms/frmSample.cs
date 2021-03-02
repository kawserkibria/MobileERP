using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using JA.Modulecontrolar.JINVMS;
using JA.Modulecontrolar.UI.Accms.Forms;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSample : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        SPWOIS objWIS = new SPWOIS();
        public long lngFormPriv { get; set; }
        private string mySQL { get; set; }
        public int m_action { get; set; }
        public long vtype { get; set; }
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
        private string strComID { get; set; }

        List<Invoice> ooPartyName;
        List<Invoice> ooinv;
        //private DataGridView ucdgList = new DataGridView();
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstSalesRepresentive = new ListBox();
        private ListBox lstCustomer = new ListBox();
        private ListBox lstGroup = new ListBox();
        private ListBox lstBatch = new ListBox();
        List<StockItem> oogrp;
        public frmSample()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User In"
            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtItemName.LostFocus += new System.EventHandler(this.uctxtItemName_LostFocus);
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);

            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);
            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);

            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtRate.GotFocus += new System.EventHandler(this.uctxtRate_GotFocus);
            this.uctxtRate.TextChanged += new System.EventHandler(this.uctxtRate_TextChanged);

            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);
            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);

            this.ucdgList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ucdgList_KeyPress);
            this.ucdgList.DoubleClick += new System.EventHandler(this.ucdgList_DoubleClick);

            this.uctxtSampleNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSampleNo_KeyPress);
            this.uctxtSampleNo.GotFocus += new System.EventHandler(this.uctxtSampleNo_GotFocus);

            this.uctxtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDate_KeyPress);
            this.uctxtDate.GotFocus += new System.EventHandler(this.uctxtDate_GotFocus);

            this.dteDueDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDueDate_KeyPress);
            this.dteDueDate.GotFocus += new System.EventHandler(this.dteDueDate_GotFocus);

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

            this.uctxtSalesRep.KeyDown += new KeyEventHandler(uctxtSalesRep_KeyDown);
            this.uctxtSalesRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSalesRep_KeyPress);
            //this.uctxtSalesRep.TextChanged += new System.EventHandler(this.uctxtSalesRep_TextChanged);
            //this.lstSalesRepresentive.DoubleClick += new System.EventHandler(this.lstSalesRepresentive_DoubleClick);
            this.uctxtSalesRep.GotFocus += new System.EventHandler(this.uctxtSalesRep_GotFocus);

            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);

            this.uctxtCustomer.KeyDown += new KeyEventHandler(uctxtCustomer_KeyDown);
            this.uctxtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCustomer_KeyPress);
            this.uctxtCustomer.TextChanged += new System.EventHandler(this.uctxtCustomer_TextChanged);
            //this.lstCustomer.DoubleClick += new System.EventHandler(this.lstCustomer_DoubleClick);
            this.uctxtCustomer.GotFocus += new System.EventHandler(this.uctxtCustomer_GotFocus);
            this.DGcustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGcustomer_KeyPress);
            this.DGcustomer.DoubleClick += new System.EventHandler(this.DGcustomer_DoubleClick);
            this.uctxtGroupName.KeyDown += new KeyEventHandler(uctxtGroupName_KeyDown);
            this.uctxtGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtGroupName_KeyPress);
            this.uctxtGroupName.TextChanged += new System.EventHandler(this.uctxtGroupName_TextChanged);
            this.lstGroup.DoubleClick += new System.EventHandler(this.lstGroup_DoubleClick);
            this.uctxtGroupName.GotFocus += new System.EventHandler(this.uctxtGroupName_GotFocus);

            this.uctxtBatch.KeyDown += new KeyEventHandler(uctxtBatch_KeyDown);
            this.uctxtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatch_KeyPress);
            this.uctxtBatch.TextChanged += new System.EventHandler(this.uctxtBatch_TextChanged);
            this.lstBatch.DoubleClick += new System.EventHandler(this.lstBatch_DoubleClick);
            this.uctxtBatch.GotFocus += new System.EventHandler(this.uctxtBatch_GotFocus);
            this.ucdgList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ucdgList_CellFormatting);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);
            this.DGcustomer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGcustomer_CellFormatting);
            //this.chkFG.Click += new System.EventHandler(this.chkFG_Click);

            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            //Utility.CreateListBox(lstSalesRepresentive, pnlMain, uctxtSalesRep);
            //Utility.CreateListBox(lstCustomer, pnlMain, uctxtCustomer);
            Utility.CreateListBox(lstGroup, panel2, uctxtGroupName);
            Utility.CreateListBox(lstBatch, panel2, uctxtBatch);
            #endregion
        }
        //private void chkFG_Click(object sender, EventArgs e)
        //{
        //    ucdgList.Rows.Clear();
        //    mloadItem();
        //    uctxtItemName.Focus();
        //}

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
        private void ucdgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ucdgList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            ucdgList.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            ucdgList.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
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
        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstCustomer.Visible = false;
            lstBatch.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
           

        }
        private void uctxtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {

            {
                if (e.KeyChar == (char)Keys.Return)
                {
                    btnSave.Focus();
                }
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
            if (uctxtGroupName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtGroupName.Focus();
                return;
            }
            if (uctxtItemName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtItemName.Focus();
                return;
            }
            mAdditem(uctxtGroupName.Text, uctxtItemName.Text, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text),Utility.gCheckNull( uctxtBatch.Text));
            uctxtGroupName.Focus();
        }

        private void uctxtBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBatch.Items.Count > 0)
                {
                    uctxtBatch.Text = lstBatch.Text;
                }
                if (uctxtGroupName.Text == "")
                {
                    MessageBox.Show("Cannot be Empty");
                    uctxtGroupName.Focus();
                    return;
                }
                if (uctxtItemName.Text == "")
                {
                    MessageBox.Show("Cannot be Empty");
                    uctxtItemName.Focus();
                    return;
                }
                mAdditem(uctxtGroupName.Text, uctxtItemName.Text, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text), Utility.gCheckNull(uctxtBatch.Text));
               

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBatch, sender, e);
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

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstCustomer.Visible = false;
            lstBatch.Visible = true;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
            lstBatch.ValueMember = "Key";
            lstBatch.DisplayMember = "Value";
            lstBatch.DataSource = invms.mFillBatch(strComID).ToList();

            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }
        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstCustomer.Visible = false;
            lstBatch.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
        }
        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {

            {
                if (e.KeyChar == (char)Keys.Return)
                {
                   
                    uctxtBatch.Focus();
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtRate, sender, e);
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

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstCustomer.Visible = false ;
            lstGroup.Visible = true;
            lstBatch.Visible = false;
            ucdgList.Visible = false;
            //lstGroup.Visible = false;
            lstGroup.DisplayMember = "strGroupName";
            lstGroup.ValueMember = "strGroupName";
            lstGroup.DataSource = invms.mFillSample(strComID,"",Utility.gstrUserName).ToList();
            lstGroup.SelectedIndex = lstGroup.FindString(uctxtGroupName.Text);
        }
        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstCustomer.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
            lstBatch.Visible = false;
            mloadItem();

        }
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstCustomer.Visible = false;
            lstBatch.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;

        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {

            {
                double dblrate = 0;
                if (e.KeyChar == (char)Keys.Return)
                {
                    dblrate = Utility.gdblGetEnterpriseSalesPrice(strComID, uctxtItemName.Text, uctxtDate.Text, Utility.Val(uctxtQty.Text.ToString()), 0, "");
                    uctxtRate.Text = dblrate.ToString();
                    uctxtRate.Focus();
                }

            }

            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtQty, sender, e);
            }
        }
        private void uctxtCustomer_TextChanged(object sender, EventArgs e)
        {
            //lstCustomer.SelectedIndex = lstCustomer.FindString(uctxtSalesRep.Text);
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
            uctxtGroupName.Focus();
        }

        private void uctxtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtCustomer.Text == "" || uctxtCustomer.Text == Utility.gcEND_OF_LIST)
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
                        uctxtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
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
                    uctxtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
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

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstCustomer.Visible = true;
            lstBatch.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
            if (uctxtSalesRep.Text != "")
            {
                mloadCustomer();
                //lstCustomer.Items.Add(oinv.strSalesRepresentative);

                //lstCustomer.DisplayMember = "strSalesRepresentative";
                //lstCustomer.ValueMember = "strSalesRepresentative";
                //lstCustomer.DataSource = ooinv.ToList();

            }
            //lstCustomer.DisplayMember = "value";
            //lstCustomer.ValueMember = "Key";
            //lstCustomer.DataSource = new BindingSource(invms.mFillSalesRepLedger((long)Utility.GR_GROUP_TYPE.grSALES_REP), null);
            //lstCustomer.SelectedIndex = lstCustomer.FindString(uctxtCustomer.Text);
        }
        private void mloadCustomer()
        {
            int introw = 0;
            DGcustomer.Rows.Clear();

            ooinv = invms.mFillSalesRepFromMPoNew1(strComID,(long)Utility.GR_GROUP_TYPE.grSALES_REP, uctxtSalesRep.Text).ToList();

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

        private void dteDueDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtLocation.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                uctxtDate.Focus();
            }
        }
        private void dteDueDate_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstCustomer.Visible = false;
            lstBatch.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
        }
        private void uctxtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteDueDate.Text = uctxtDate.Text;
                uctxtSalesRep.Focus();
            }

        }
        private void uctxtDate_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstCustomer.Visible = false;
            lstBatch.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
        }
        private void uctxtSampleNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtDate.Focus();

            }
        }
        private void uctxtSampleNo_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstCustomer.Visible = false;
            lstBatch.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
        }
        private void uctxtSalesRep_TextChanged(object sender, EventArgs e)
        {
            lstSalesRepresentive.SelectedIndex = lstSalesRepresentive.FindString(uctxtSalesRep.Text);
        }

        private void lstSalesRepresentive_DoubleClick(object sender, EventArgs e)
        {
            uctxtSalesRep.Text = lstSalesRepresentive.Text;
            dteDueDate.Focus();
        }

        private void uctxtSalesRep_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            //{
               
            //        if (lstSalesRepresentive.Items.Count > 0)
            //        {
            //            uctxtSalesRep.Text = lstSalesRepresentive.Text;
            //        }
            //        dteDueDate.Focus();
            //}
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(uctxtSalesRep, sender, e);
            //}
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtSalesRep.Text == "")
                {
                    //txtItemCode.Text = "";
                    uctxtSalesRep.Text = "";
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        //uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        //uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        //uctxtSalesRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = true;
                        //dteDuedate.Focus();
                    }
                    //if (uctxtSalesRep.Text != "")
                    //{
                    //    mloadCustomer();
                    //    //lstCustomer.Items.Add(oinv.strSalesRepresentative);

                    //    //lstCustomer.DisplayMember = "strSalesRepresentative";
                    //    //lstCustomer.ValueMember = "strSalesRepresentative";
                    //    //lstCustomer.DataSource = ooinv.ToList();

                    //}
                    DGMr.Visible = false;
                    //uctxtNarration.Focus();

                    return;
                }


                if (uctxtItemName.Text != "")
                {
                    DGMr.Focus();
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtSalesRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = false;
                        uctxtCustomer.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtSalesRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    uctxtCustomer.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtSalesRep, sender, e);
            }
        }
        private void uctxtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //{
            //    if (lstSalesRepresentive.SelectedItem != null)
            //    {
            //        lstSalesRepresentive.SelectedIndex = lstSalesRepresentive.SelectedIndex - 1;
            //    }
            //}
            //if (e.KeyCode == Keys.Down)
            //{
            //    if (lstSalesRepresentive.Items.Count - 1 > lstSalesRepresentive.SelectedIndex)
            //    {
            //        lstSalesRepresentive.SelectedIndex = lstSalesRepresentive.SelectedIndex + 1;
            //    }
            //}
            DGMr.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                DGMr.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DGMr.Focus();
            }

            DGMr.Top = uctxtSalesRep.Top + 25;
            DGMr.Left = uctxtSalesRep.Left;
            DGMr.Width = uctxtSalesRep.Width;
            DGMr.Height = 200;
            //ucdgList.Size = new Size(546, 222);
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;
        }
        private void DGMr_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtSalesRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                uctxtCustomer.Focus();


            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtSalesRep.Text = Utility.GetDgValue(DGMr, uctxtSalesRep, 0);
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTeritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtSalesRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();

                DGMr.Visible = false;
                uctxtCustomer.Focus();
            }
        }
        private void uctxtSalesRep_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = true;
            lstCustomer.Visible = false;
            lstBatch.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;

            lstSalesRepresentive.DisplayMember = "strLedgerName";
            lstSalesRepresentive.ValueMember = "strLedgerName";
            lstSalesRepresentive.DataSource = accms.mFillLedgerList(strComID, 202).ToList();
            //List<AccountsLedger> oogrp = accms.mFillLedgerList(202).ToList();
            lstSalesRepresentive.SelectedIndex = lstSalesRepresentive.FindString(uctxtSalesRep.Text);
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
                uctxtGroupName.Focus();

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


            lstBranchName.Visible = false;
            lstLocation.Visible = true;
            lstSalesRepresentive.Visible = false;
            lstCustomer.Visible = false;
            lstBatch.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
            if (uctxtBranchName.Text !="")
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName,2).ToList();
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
            mloadParty(lstBranchName.SelectedValue.ToString());
            uctxtSampleNo.Focus();
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }
                mloadParty(lstBranchName.SelectedValue.ToString());
                uctxtSampleNo.Focus();
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
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstCustomer.Visible = false;
            lstBatch.Visible = false;
            lstGroup.Visible = false;
            ucdgList.Visible = false;
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }
        private void ucdgList_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


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
        private void uctxtItemName_LostFocus(object sender, System.EventArgs e)
        {

           


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
               }
                else
                {
                    int i = 0;

                    uctxtItemName.Text = ucdgList.Rows[i].Cells[0].Value.ToString();
                    ucdgList.Visible = false;
                    uctxtQty.Focus();
                }

            }

            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtItemName, sender, e);
            }
        }
        #endregion
        #region "Load Item"
        private void mloadItem()
        {
            int introw=0;
            //string strYn = "";
            //if (chkFG.Checked == true)
            //{
            //    strYn = "FG";
            //}
            //else
            //{
            //    strYn = "MC";
            //}
            ucdgList.Rows.Clear();
            //oogrp = invms.mloadAddStockItem(uctxtGroupName.Text).ToList();
            //oogrp = objWIS.gFillStockItemNew(strComID, uctxtGroupName.Text, uctxtLocation.Text).ToList();
            oogrp = objWIS.mGetProductStatementView(strComID, uctxtGroupName.Text, lstBranchName.SelectedValue.ToString(), uctxtLocation.Text, "").ToList();
            if (oogrp.Count > 0)
            {

                foreach (StockItem ogrp in oogrp)
                {
                    ucdgList.Rows.Add();
                    ucdgList[0, introw].Value = ogrp.strItemName;
                    //DG[1, introw].Value = ogrp.strItemcode;
                    //DG[2, introw].Value = ogrp.strUnit;
                    ucdgList[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;

                    introw += 1;
                }

                ucdgList.AllowUserToAddRows = false;
            }
        }
        #endregion
        #region "Getconfig"
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, vtype).ToList();
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
        private void frmSample_Load(object sender, EventArgs e)
        {
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstGroup.Visible = false;
            lstBatch.Visible = false;
            DG.AllowUserToAddRows = false;
            mGetConfig();
            mcLear();
            //mloadParty();
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("Group Name", "Group Name", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Qty", "Qty", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 60, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Batch", "Batch", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 70, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("billkey", "billkey", 100, false, DataGridViewContentAlignment.TopLeft, false));
        }
        private void mloadParty(string strBarnchID)
        {
            int introw = 0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID, strBarnchID, Utility.gblnAccessControl, Utility.gstrUserName, 0, "","").ToList();

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
        #endregion
        #region "Validation"
        private bool ValidateFields()
        {
            double dblClosingQTY = 0, dblCurrentQTY = 0, dblBillQty = 0;
            string strBillKey = "", strNegetiveItem = "";
            int intCheckNegetive = 0;
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtBranchName.Focus();
                return false;
            }
            if (uctxtSampleNo.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtSampleNo.Focus();
                return false;
            }
            if (uctxtSalesRep.Text == "")
            {
                MessageBox.Show("Cannot Empty");
                uctxtSalesRep.Focus();
                return false;
            }
            if (DG.Rows.Count == 0)
            {
                MessageBox.Show("Item Cannot be Empty");
                uctxtItemName.Focus();
                return false;
            }
            if (Utility.Val(lblAmount.Text) == 0 || Utility.Val(lblAmount.Text) < 0)
            {
                MessageBox.Show("Net Amount be Empty");
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


            long lngDate = Convert.ToInt64(uctxtDate.Value.ToString("yyyyMMdd"));
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
            string strLockvoucher = Utility.gLockVocher(strComID, (int)vtype);
            if (strLockvoucher != "")
            {
                long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strLockvoucher).ToString("yyyyMMdd"));
                if (lngDate <= lngBackdate)
                {
                    MessageBox.Show("Invalid Date, Back Date is locked");
                    return false;
                }
            }

            if (DG.Rows.Count == 0)
            {
                MessageBox.Show("Item cannot be Empty");
                uctxtItemName.Focus();
                return true;
            }


            for (int i = 0; i < DG.Rows.Count; i++)
            {
                if (DG[1, i].Value != null)
                {

                    if (DG[8, i].Value != null)
                    {
                        strBillKey = DG[8, i].Value.ToString();
                    }
                    else
                    {
                        strBillKey = "";
                    }
                    //if (chkFG.Checked)
                    //{
                        dblClosingQTY = Utility.gdblClosingStockSales(strComID, DG[1, i].Value.ToString(), lstBranchName.SelectedValue.ToString(), "", uctxtLocation.Text);
                    //}
                    //else
                    //{
                    //    dblClosingQTY = Utility.gdblClosingStock(strComID, DG[1, i].Value.ToString(), uctxtLocation.Text, uctxtDate.Text);
                    //}
                   
                    if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                    {
                        dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey, uctxtLocation.Text);
                    }
                    dblCurrentQTY = Utility.Val(DG[2, i].Value.ToString());
                    if ((dblClosingQTY) - dblCurrentQTY < 0)
                    {
                        strNegetiveItem = strNegetiveItem + Environment.NewLine + DG[1, i].Value.ToString() + " (Curr. Qty: " + dblCurrentQTY + " Closing Qty : " + dblClosingQTY + ")";
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



            return true;
        }
        #endregion
        #region "Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strResponse, strDGSales = "", strBranchID = "", strRefNo = "", strItemDes, strBatch = "", strDuplicate="";
          
            if (ValidateFields() == false)
            {
                return;
            }
            
            for (int i = 0; i < DG.Rows.Count; i++)
            {
                if (DG[2, i].Value != null)
                {
                    strItemDes = Utility.mGetItemDescription(strComID, DG[2, i].Value.ToString());
                }
                else
                {
                    strItemDes = "";
                }
                if (DG[6, i].Value!=null)
                {
                    strBatch = DG[6, i].Value.ToString();
                }
                else
                {
                    strBatch = "";
                }
                strDGSales = strDGSales + Utility.gCheckNull(DG[0, i].Value.ToString()) + "|" //group
                                                            + Utility.gCheckNull(DG[1, i].Value.ToString()) + "|" +//Item
                                                            strItemDes + "|" +//Des
                                                            Utility.Val(DG[2, i].Value.ToString()) + "|" +//qty
                                                            Utility.gCheckNull(DG[3, i].Value.ToString()) + "|" +//Unit
                                                            Utility.Val(DG[4, i].Value.ToString()) + "|" + //rate
                                                            Utility.Val(DG[5, i].Value.ToString()) + "|" + //aount
                                                            strBatch + "|" + //batch
                                                             "~";
              
            }
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);

             if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
             {
                 strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_COMPANY_VOUCHER", "COMP_REF_NO", uctxtSampleNo.Text);
                 if (strDuplicate != "")
                 {
                     MessageBox.Show(strDuplicate);
                     uctxtSampleNo.Focus();
                     return;
                 }


                 if (mblnNumbMethod == false)
                 {
                     strRefNo = gobjVoucherName.VoucherName.GetVoucherString(vtype) + strBranchID + uctxtSampleNo.Text;
                 }
                 else
                 {
                     strRefNo = gobjVoucherName.VoucherName.GetVoucherString(vtype) + strBranchID + Utility.gstrLastNumber(strComID, (int)vtype);
                 }

                 strResponse = invms.mInsertSample(strComID, vtype, strBranchID, strRefNo, uctxtDate.Text, uctxtDate.Value.ToString("MMMyy"),
                                                     uctxtSalesRep.Text, dteDueDate.Text, Utility.Val(lblAmount.Text), uctxtLocation.Text,
                                                      Utility.gCheckNull(uctxtCustomer.Text), Utility.gCheckNull(uctxtNarration.Text), strDGSales, mblnNumbMethod);

                 if (strResponse == "Inseretd...")
                 {
                     if (Utility.gblnAccessControl)
                     {
                         string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, uctxtDate.Text, "Sample", uctxtSampleNo.Text,
                                                                 1, Utility.Val(lblAmount.Text), (int)Utility.MODULE_TYPE.mtSALES, strBranchID);
                     } 
                     mcLear();
                 }
                 else
                 {
                     MessageBox.Show(strResponse);
                 }
             }
             else
             {
                 strResponse = invms.mUpdateSample(strComID, uctxtOld.Text, vtype, strBranchID, uctxtOld.Text, uctxtDate.Text, uctxtDate.Value.ToString("MMMyy"),
                                                    uctxtSalesRep.Text, dteDueDate.Text, Utility.Val(lblAmount.Text), uctxtLocation.Text,
                                                     Utility.gCheckNull(uctxtCustomer.Text), Utility.gCheckNull(uctxtNarration.Text), strDGSales);

                 if (strResponse == "Updated...")
                 {
                     if (Utility.gblnAccessControl)
                     {
                         string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, uctxtDate.Text, "Sample", uctxtSampleNo.Text,
                                                                 2, Utility.Val(lblAmount.Text), (int)Utility.MODULE_TYPE.mtSALES, strBranchID);
                     } 
                     mcLear();
                 }
                 else
                 {
                     MessageBox.Show(strResponse);
                 }
             }

        }
        #endregion
        #region "Clear"
        private void mcLear()
        {
            uctxtBranchName.Text = "";
            uctxtSalesRep.Text = "";
            uctxtCustomer.Text = "";
            uctxtLocation.Text = "";
            uctxtTeritorryName.Text = "";
            uctxtTeritoryCode.Text = "";
            uctxtCustomerCode.Text = "";
            uctxtCustomerAddress.Text = "";
            uctxtHomeohall.Text = "";
            DG.Rows.Clear();
            lblQnty.Text = "0";
            lblAmount.Text = "0";
            uctxtNarration.Text = "";
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod)
            {
                uctxtSampleNo.Text = Utility.gstrLastNumber(strComID, (int)vtype);
                uctxtSampleNo.ReadOnly = true;
                uctxtBranchName.Focus();
                uctxtBranchName.Select();
            }
            else
            {
                uctxtSampleNo.Text = Utility.gobjNextNumber(uctxtSampleNo.Text);
                uctxtBranchName.Focus();
                uctxtBranchName.Select();
            }

           
        }
        #endregion
        #region "Key Up"
        private void uctxtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListView(oogrp, uctxtItemName.Text);
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
            int i=0;
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
        #endregion
        #region "Additem"
        private void mAdditem(string strGroupName,string strItemName, double dblQty, double dblRate,string strBatch)
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
                DG[0, selRaw].Value = strGroupName;
                DG[1, selRaw].Value = strItemName;
                DG[2, selRaw].Value = dblQty;
                DG[3, selRaw].Value = Utility.gGetBaseUOM(strComID, strItemName);
                DG[4, selRaw].Value = dblRate;
                DG[5, selRaw].Value = Math.Round(dblQty * dblRate, 2);
                if (strBatch != Utility.gcEND_OF_LIST)
                {
                    DG[6, selRaw].Value = strBatch;
                }
                else
                {
                    DG[6, selRaw].Value = "";
                }
                DG[7, selRaw].Value = "Delete";
                DG.AllowUserToAddRows = false;
                uctxtItemName.Text = "";
                uctxtQty.Text = "";
                uctxtRate.Text = "";
                uctxtBatch.Text = "";
                uctxtItemName.Focus();
                calculateTotal();
                DG.ClearSelection();
                int nColumnIndex = 2;
                int nRowIndex = DG.Rows.Count - 1;
                DG.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                DG.FirstDisplayedScrollingRowIndex = nRowIndex;
            }

        }
        #endregion
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblTotalQnty = 0,dblTotal=0;
            for (int i = 0; i < DG.Rows.Count; i++)
            {
                if (DG.Rows[i].Cells[2].Value != null)
                {
                    dblTotalQnty = dblTotalQnty + Utility.Val(DG.Rows[i].Cells[2].Value.ToString());
                    dblTotal = dblTotal + Utility.Val(DG.Rows[i].Cells[5].Value.ToString());
                }

            }

            lblQnty.Text = dblTotalQnty.ToString();
            lblAmount.Text = dblTotal.ToString();

        }
        #endregion
        #region "Click"
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==7)
            {
                DG.Rows.RemoveAt(e.RowIndex);
                calculateTotal();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmSampleList objfrm = new frmSampleList();
            objfrm.mintVType = (int)vtype;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strPreserveSQl = mySQL;
            objfrm.onAddAllButtonClicked = new frmSampleList.AddAllClick(DisplayVoucherList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            uctxtBranchName.Focus();
        }
        #endregion
        #region "DisplayVoucher"
        private void DisplayVoucherList(List<Sample> tests, object sender, EventArgs e)
        {
            try
            {
                int introw = 0;
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DG.Rows.Clear();

              
               // uctxtNarration.Text = tests[0].strn;
                List<Sample> ooaccVou = invms.mDisplaySampleList(strComID, tests[0].strSampleNo).ToList();
                if (ooaccVou.Count > 0)
                {
                    foreach (Sample oCom in ooaccVou)
                    {
                        mySQL = tests[0].strPreserveSQL;
                        uctxtOld.Text = oCom.strSampleNo;
                        uctxtSampleNo.Text = Utility.Mid(oCom.strSampleNo,6,oCom.strSampleNo.Length-6);
                        uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, oCom.strBranchID);
                        uctxtLocation.Text = oCom.strLocation;
                        uctxtCustomer.Text = oCom.strCustomer;
                        uctxtSalesRep.Text = oCom.strMrName;
                        uctxtTeritoryCode.Text = Utility.GetTeritorryCodeFromLedgerName(strComID, oCom.strMrName);
                        uctxtTeritorryName.Text = Utility.GetTeritorryName(strComID, uctxtTeritoryCode.Text);
                        
                       
                        uctxtDate.Text = oCom.strDate;
                        dteDueDate.Text = oCom.strDueDate;
                        uctxtNarration.Text = oCom.strNarration;


                        List<Sample> ooVouList = invms.mDisplaySampleItem(strComID, tests[0].strSampleNo).ToList();
                        if (ooVouList.Count > 0)
                        {

                            foreach (Sample oacc in ooVouList)
                            {
                                uctxtLocation.Text = oacc.strLocation;
                                DG.Rows.Add();
                                DG[0, introw].Value = oacc.strGroupName;
                                DG[1, introw].Value = oacc.strItemName;
                                DG[2, introw].Value = oacc.dblQty;
                                DG[3, introw].Value = oacc.strUnit;
                                DG[4, introw].Value = oacc.dblRate;
                                DG[5, introw].Value = oacc.dblAmount;
                                DG[7, introw].Value = "Delete";
                                DG[8, introw].Value = oacc.strBillKey;

                                introw += 1;
                            }
                            DG.AllowUserToAddRows = false;
                        }

                        calculateTotal();


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
        #endregion

        private void uctxtSalesRep_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListViewPartyName(ooPartyName, uctxtSalesRep.Text);
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
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string strunit = Utility.gGetBaseUOM(strComID, DG[1, e.RowIndex].Value.ToString());
                double dblQty = Utility.Val(DG[2, e.RowIndex].Value.ToString());
                double dblrate = Utility.Val(DG[4, e.RowIndex].Value.ToString());
                DG[2, e.RowIndex].Value= dblQty + " " + strunit;
                DG[5, e.RowIndex].Value = (dblQty * dblrate) ;
                calculateTotal();
                btnSave.Focus();
            }
        }

     
    }
}
