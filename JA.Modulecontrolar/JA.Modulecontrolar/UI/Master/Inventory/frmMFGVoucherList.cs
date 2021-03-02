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
    public partial class frmMFGVoucherList : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        SPWOIS objWIS = new SPWOIS();

        public delegate void AddAllClick(List<MFGvouhcer> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        private ListBox lstFindWhat = new ListBox();
        private ListBox lstExpression = new ListBox();
        public int intConvert { get; set; }
        public long lngFormPriv { get; set; }
        public long lngFormApp_Priv { get; set; }
        public string strFormName { get; set; }
        private string strComID { get; set; }
        public frmMFGVoucherList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtFindWhat.KeyDown += new KeyEventHandler(uctxtFindWhat_KeyDown);
            this.uctxtFindWhat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFindWhat_KeyPress);
            this.uctxtFindWhat.TextChanged += new System.EventHandler(this.uctxtFindWhat_TextChanged);
            this.lstFindWhat.DoubleClick += new System.EventHandler(this.lstFindWhat_DoubleClick);
            this.uctxtFindWhat.GotFocus += new System.EventHandler(this.uctxtFindWhat_GotFocus);

            this.uctxtExpression.KeyDown += new KeyEventHandler(uctxtExpression_KeyDown);
            this.uctxtExpression.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtExpression_KeyPress);
            this.uctxtExpression.TextChanged += new System.EventHandler(this.uctxtExpression_TextChanged);
            this.lstExpression.DoubleClick += new System.EventHandler(this.lstExpression_DoubleClick);
            this.uctxtExpression.GotFocus += new System.EventHandler(this.uctxtExpression_GotFocus);

            this.uctxtFromDate.GotFocus += new System.EventHandler(this.uctxtFromDate_GotFocus);
            this.uctxtFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFromDate_KeyPress);
            this.uctxtToDate.GotFocus += new System.EventHandler(this.uctxtToDate_GotFocus);
            this.uctxtToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtToDate_KeyPress);

            Utility.CreateListBox(lstFindWhat, PanelSearch, uctxtFindWhat, 0);
            Utility.CreateListBox(lstExpression, PanelSearch, uctxtExpression, 0);
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
        private void uctxtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtFromDate.Text = Utility.ctrlDateFormat(uctxtFromDate.Text);
                uctxtToDate.Focus();
            }
        }
        private void uctxtToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtToDate.Text = Utility.ctrlDateFormat(uctxtToDate.Text);


                //mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text);
                mfgVoucherList(0);
                PanelSearch.Visible = false;
            }
        }
        private void uctxtFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstFindWhat.Visible = false;
            lstExpression.Visible = false;
            uctxtFromDate.Text = Utility.ctrlDateFormat(DateTime.Now.ToString("dd-MM-yyyy"));

        }
        private void uctxtToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstFindWhat.Visible = false;
            lstExpression.Visible = false;
            uctxtToDate.Text = Utility.ctrlDateFormat(DateTime.Now.ToString("dd-MM-yyyy"));
        }
        private void uctxtExpression_TextChanged(object sender, EventArgs e)
        {
            lstExpression.SelectedIndex = lstExpression.FindString(uctxtExpression.Text);
        }

        private void lstExpression_DoubleClick(object sender, EventArgs e)
        {
            uctxtExpression.Text = lstExpression.Text;
            PanelSearch.Visible = false;
            mfgVoucherList(0);
            DGMFGVoucherList.Focus();


        }
        private void uctxtExpression_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstExpression.Visible)
                {
                    if (lstExpression.Items.Count > 0)
                    {
                        uctxtExpression.Text = lstExpression.Text;
                    }
                }
                //mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text);
                mfgVoucherList(0);
                PanelSearch.Visible = false;
                DGMFGVoucherList.Focus();


            }
        }
        private void uctxtExpression_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstExpression.SelectedItem != null)
                {
                    lstExpression.SelectedIndex = lstExpression.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstExpression.Items.Count - 1 > lstExpression.SelectedIndex)
                {
                    lstExpression.SelectedIndex = lstExpression.SelectedIndex + 1;
                }
            }

        }

        private void uctxtExpression_GotFocus(object sender, System.EventArgs e)
        {

            lstFindWhat.Visible = false;
            lstExpression.SelectedIndex = lstExpression.FindString(uctxtExpression.Text);

        }
        private void uctxtFindWhat_TextChanged(object sender, EventArgs e)
        {
            lstFindWhat.SelectedIndex = lstFindWhat.FindString(uctxtFindWhat.Text);
        }

        private void lstFindWhat_DoubleClick(object sender, EventArgs e)
        {
            uctxtFindWhat.Text = lstFindWhat.Text;
            if (uctxtFindWhat.Text == "Voucher Number")
            {
                lstFindWhat.Visible = false;
                lblExpression.Visible = false;
                uctxtExpression.Visible = true;
                uctxtFromDate.Visible = false;
                uctxtToDate.Visible = false;
                lblfromDate.Visible = false;
                lblTodate.Visible = false;
            }
            else if (uctxtFindWhat.Text == "Stock Item")
            {
                lstExpression.Visible = true;
                lstFindWhat.Visible = false;
                uctxtExpression.Visible = true;
                uctxtFromDate.Visible = false;
                uctxtToDate.Visible = false;
                lblfromDate.Visible = false;
                lblTodate.Visible = false;
                lstExpression.ValueMember = "strItemName";
                lstExpression.DisplayMember = "strItemName";
                lstExpression.DataSource = invms.gFillStockItemAllWithoutGodown(strComID, false, Utility.gstrUserName,"").ToList();
            }
            else if (uctxtFindWhat.Text == "Voucher Date")
            {
                lstExpression.Visible = false;
                lblExpression.Visible = false;
                uctxtExpression.Visible = false;
                uctxtFromDate.Visible = true;
                uctxtToDate.Visible = true;
                lblfromDate.Visible = true;
                lblTodate.Visible = true;
                uctxtFromDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                uctxtToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
         
            if (uctxtExpression.Visible)
            {
                uctxtExpression.Focus();
            }
            else if (uctxtFromDate.Visible)
            {
                uctxtFromDate.Focus();
            }


        }
        private void uctxtFindWhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstFindWhat.Items.Count > 0)
                {
                    uctxtFindWhat.Text = lstFindWhat.Text;
                }
                if (uctxtFindWhat.Text == "Voucher Number")
                {
                    lstExpression.Visible = false;
                    lstFindWhat.Visible = false;
                    uctxtExpression.Visible = true;
                    uctxtFromDate.Visible = false;
                    uctxtToDate.Visible = false;
                    lblfromDate.Visible = false;
                    lblTodate.Visible = false;
                }
                else if (uctxtFindWhat.Text == "Stock Item")
                {
                    lstExpression.Visible = true;
                    lstFindWhat.Visible = false;
                    uctxtExpression.Visible = true;
                    uctxtFromDate.Visible = false;
                    uctxtToDate.Visible = false;
                    lblfromDate.Visible = false;
                    lblTodate.Visible = false;
                    lstExpression.ValueMember = "strItemName";
                    lstExpression.DisplayMember = "strItemName";
                    lstExpression.DataSource = invms.gFillStockItemAllWithoutGodown(strComID, false, Utility.gstrUserName,"").ToList();

                }
                else if (uctxtFindWhat.Text == "Voucher Date")
                {
                    lstExpression.Visible = false;
                    lblExpression.Visible = false;
                    uctxtExpression.Visible = false;
                    uctxtFromDate.Visible = true;
                    uctxtToDate.Visible = true;
                    lblfromDate.Visible = true;
                    lblTodate.Visible = true;
                    uctxtFromDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    uctxtToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                }
                //else if (uctxtFindWhat.Text == "Cheque Date")
                //{
                //    lstExpression.Visible = false;
                //    lblExpression.Visible = false;
                //    uctxtExpression.Visible = false;
                //    uctxtFromDate.Visible = true;
                //    uctxtToDate.Visible = true;
                //    lblfromDate.Visible = true;
                //    lblTodate.Visible = true;
                //}
                //else
                //{
                //    lstExpression.Visible = false;
                //    lblExpression.Visible = true;
                //    uctxtExpression.Visible = true;
                //    uctxtFromDate.Visible = false;
                //    uctxtToDate.Visible = false;
                //    lblfromDate.Visible = false;
                //    lblTodate.Visible = false;
                //}


                if (uctxtExpression.Visible)
                {
                    uctxtExpression.Focus();
                }
                else if (uctxtFromDate.Visible)
                {
                    uctxtFromDate.Focus();
                }



            }
        }
        private void uctxtFindWhat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstFindWhat.SelectedItem != null)
                {
                    lstFindWhat.SelectedIndex = lstFindWhat.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstFindWhat.Items.Count - 1 > lstFindWhat.SelectedIndex)
                {
                    lstFindWhat.SelectedIndex = lstFindWhat.SelectedIndex + 1;
                }
            }

        }

        private void uctxtFindWhat_GotFocus(object sender, System.EventArgs e)
        {
            lstFindWhat.Visible = true;
            lstExpression.Visible = false;
            lstFindWhat.SelectedIndex = lstFindWhat.FindString(uctxtFindWhat.Text);

        }
        #endregion
        private void frmMFGVoucherList_Load(object sender, EventArgs e)
        {
            if (intConvert == 1)
            {
                frmLabel.Text = "Conversion FG Voucher List";
                DGMFGVoucherList.AllowUserToAddRows = false;
                this.DGMFGVoucherList.DefaultCellStyle.Font = new Font("verdana", 9);
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 200, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Batch No", "Batch No", 250, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Process Name", "Process Name", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Branch ID", "Branch ID", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 70, true, DataGridViewContentAlignment.TopCenter, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 70, true, DataGridViewContentAlignment.TopCenter, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("RefNoOut", "RefNoOut", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("RefNoin", "RefNoin", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("RefNoWastage", "RefNoWastage", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.CreateChkBxGrd("", "", 50, false, DataGridViewContentAlignment.TopLeft, false, false, "Check"));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Status", "Status", 60, false, DataGridViewContentAlignment.TopLeft, true));
            }
            else
            {
                chkSelectAll.Visible = true;
                btnApproved.Visible = true;
                btnNotApproved.Visible = true;
                btnListApp.Visible = true;
                DGMFGVoucherList.AllowUserToAddRows = false;
                this.DGMFGVoucherList.DefaultCellStyle.Font = new Font("verdana", 9);
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 150, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Batch No", "Batch No", 250, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Process Name", "Process Name", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Branch ID", "Branch ID", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 70, true, DataGridViewContentAlignment.TopCenter, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 70, true, DataGridViewContentAlignment.TopCenter, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("RefNoOut", "RefNoOut", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("RefNoin", "RefNoin", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("RefNoWastage", "RefNoWastage", 100, false, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.CreateChkBxGrd("", "", 20, true, DataGridViewContentAlignment.TopLeft, false, false, "Check"));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Status", "Status", 60, true, DataGridViewContentAlignment.TopLeft, true));

                DgRm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 270, true, DataGridViewContentAlignment.TopLeft, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, false));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, false, DataGridViewContentAlignment.TopLeft, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 110, true, DataGridViewContentAlignment.TopLeft, false));
                DgRm.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, false, DataGridViewContentAlignment.TopCenter, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("RQnty", "RQnty", 100, false, DataGridViewContentAlignment.TopLeft, false));
                DgRm.Columns.Add(Utility.Create_Grid_Column("billKey", "billKey", 100, false, DataGridViewContentAlignment.TopLeft, false));

                DgPm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 270, true, DataGridViewContentAlignment.TopLeft, true));
                DgPm.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, false));
                DgPm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, false, DataGridViewContentAlignment.TopLeft, true));
                DgPm.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, false));
                DgPm.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, false, DataGridViewContentAlignment.TopCenter, true));
                DgPm.Columns.Add(Utility.Create_Grid_Column("RQnty", "RQnty", 100, false, DataGridViewContentAlignment.TopLeft, false));
                DgPm.Columns.Add(Utility.Create_Grid_Column("billKey", "billKey", 100, false, DataGridViewContentAlignment.TopLeft, false));

                DgWastageRm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 270, true, DataGridViewContentAlignment.TopLeft, true));
                DgWastageRm.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 80, true, DataGridViewContentAlignment.TopLeft, false));
                DgWastageRm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, false, DataGridViewContentAlignment.TopLeft, true));
                DgWastageRm.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 90, true, DataGridViewContentAlignment.TopLeft, true));
                DgWastageRm.Columns.Add(Utility.Create_Grid_Column_button("", "", "", 50, false, DataGridViewContentAlignment.TopCenter, true));
                DgWastageRm.Columns.Add(Utility.Create_Grid_Column("billKey", "billKey", 100, false, DataGridViewContentAlignment.TopLeft, false));

                dgWastagePm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 270, true, DataGridViewContentAlignment.TopLeft, true));
                dgWastagePm.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 80, true, DataGridViewContentAlignment.TopLeft, false));
                dgWastagePm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, false, DataGridViewContentAlignment.TopLeft, true));
                dgWastagePm.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 80, true, DataGridViewContentAlignment.TopLeft, true));
                dgWastagePm.Columns.Add(Utility.Create_Grid_Column_button("", "", "", 50, false, DataGridViewContentAlignment.TopCenter, true));
                dgWastagePm.Columns.Add(Utility.Create_Grid_Column("billKey", "billKey", 100, false, DataGridViewContentAlignment.TopLeft, false));

            }
            mLoadFind();
            mfgVoucherList(0);
        }
        private void mLoadFind()
        {

            lstFindWhat.Items.Clear();
            lstFindWhat.Items.Add("Voucher Number");
            lstFindWhat.Items.Add("Voucher Date");
            lstFindWhat.Items.Add("Stock Item");

        }

        private void mfgVoucherList(int Appststus)
        {
            int introw = 0;
            this.DGMFGVoucherList.DefaultCellStyle.Font = new Font("verdana", 9);
            DGMFGVoucherList.Rows.Clear();
            List<MFGvouhcer> oogrp;
            if (uctxtFindWhat.Text != "")
            {
                if (uctxtFindWhat.Text == "Voucher Number")
                {
                    oogrp = objWIS.mLoadMFGVoucher(strComID, "", "", intConvert, uctxtFindWhat.Text, uctxtExpression.Text, "", Appststus).ToList();
                }
                else if (uctxtFindWhat.Text == "Voucher Date")
                {
                    oogrp = objWIS.mLoadMFGVoucher(strComID, uctxtFromDate.Text, uctxtToDate.Text, intConvert, uctxtFindWhat.Text, "", "", Appststus).ToList();
                }
                else
                {
                    oogrp = objWIS.mLoadMFGVoucher(strComID, "", "", intConvert, uctxtFindWhat.Text, uctxtExpression.Text, "", Appststus).ToList();
                }
            }
            else
            {
                oogrp = objWIS.mLoadMFGVoucher(strComID, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.Date.ToString("dd/MM/yyyy"), intConvert, "", "", "", Appststus).ToList();
            }

            if (oogrp.Count > 0)
            {
                foreach (MFGvouhcer ogrp in oogrp)
                {
                    DGMFGVoucherList.Rows.Add();
                    DGMFGVoucherList[0, introw].Value = ogrp.strVoucherNo;
                    if (ogrp.strBatch != "")
                    {
                        DGMFGVoucherList[1, introw].Value = ogrp.strBatch;
                    }
                    else
                    {
                        DGMFGVoucherList[1, introw].Value = "End of List";
                    }
                    DGMFGVoucherList[2, introw].Value = ogrp.strDate;
                    DGMFGVoucherList[3, introw].Value = ogrp.dblAmount;

                    DGMFGVoucherList[4, introw].Value = ogrp.strProcess;
                    DGMFGVoucherList[5, introw].Value = ogrp.strBranchId;


                    DGMFGVoucherList[6, introw].Value = "Edit";
                    DGMFGVoucherList[7, introw].Value = "Delete";
                    DGMFGVoucherList[8, introw].Value = "View";

                    DGMFGVoucherList[9, introw].Value = ogrp.strRMRefNo;
                    DGMFGVoucherList[10, introw].Value = ogrp.strFgRefNo;
                    DGMFGVoucherList[11, introw].Value = ogrp.strWmRefNo;
                    if (intConvert == 0)
                    {
                        if (ogrp.intAppStatus == 0)
                        {
                            DGMFGVoucherList[13, introw].Value = "No";
                            //Convert.ToBoolean(DGMFGVoucherList[12, introw].Value = false);
                        }
                        else
                        {
                            DGMFGVoucherList[13, introw].Value = "Yes";
                            //Convert.ToBoolean(DGMFGVoucherList[12, introw].Value = true);
                        }
                    }

                    //if (introw % 2 == 0)
                    //{
                    //    DGMFGVoucherList.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGMFGVoucherList.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                DGMFGVoucherList.AllowUserToAddRows = false;
                lblCount.Text = "Total Record: " + introw;
            }
        }

        private void DGMFGVoucherList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string strmsg="";
            if (e.ColumnIndex == 7)
            {
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    if (Utility.gblnAccessControl)
                    {
                        if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                        {
                             MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                            return;
                        }
                    }
                    string i = objWIS.mDeleteMFG(strComID, DGMFGVoucherList.CurrentRow.Cells[1].Value.ToString(), DGMFGVoucherList.CurrentRow.Cells[9].Value.ToString(),
                                                DGMFGVoucherList.CurrentRow.Cells[11].Value.ToString(), DGMFGVoucherList.CurrentRow.Cells[10].Value.ToString(),intConvert);
                    if (i == "Deleted...")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, DGMFGVoucherList.CurrentRow.Cells[1].Value.ToString(),
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                        }
                        mfgVoucherList(0);
                        MessageBox.Show(i.ToString());
                    }
                    else
                    {
                        MessageBox.Show(i.ToString());
                    }
                   
                }
            }
            if (e.ColumnIndex == 6)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                strmsg = Utility.mGetCheckProductIonApproved(strComID, DGMFGVoucherList.CurrentRow.Cells[10].Value.ToString());

                if (strmsg != "")
                {
                    MessageBox.Show(strmsg);
                    return;
                }

                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }

            if (e.ColumnIndex == 8)
            {
                if (intConvert == 1)
                {
                    JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.intventoryVoucher;
                    frmviewer.strFdate = "";
                    frmviewer.strString = DGMFGVoucherList.CurrentRow.Cells[10].Value.ToString();
                    frmviewer.strSelction = "M";
                    frmviewer.Show();
                }
                else
                {
                    JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.Production;
                    frmviewer.strFdate = "";
                    frmviewer.strString = DGMFGVoucherList.CurrentRow.Cells[10].Value.ToString();
                    frmviewer.strSelction = "M";
                    frmviewer.Show();
                }


            }

        }

        private void DGMFGVoucherList_DoubleClick(object sender, EventArgs e)
        {
            //if (onAddAllButtonClicked != null)
            //    onAddAllButtonClicked(GetSelectedItem(), sender, e);
            //this.Dispose();
        }

        private List<MFGvouhcer> GetSelectedItem()
        {
            List<MFGvouhcer> items = new List<MFGvouhcer>();
            MFGvouhcer itm = new MFGvouhcer();
            if (DGMFGVoucherList.Rows.Count > 0)
            {
                itm.strVoucherNo = DGMFGVoucherList.CurrentRow.Cells[0].Value.ToString();
                itm.strBatch = DGMFGVoucherList.CurrentRow.Cells[1].Value.ToString();
                itm.strDate = DGMFGVoucherList.CurrentRow.Cells[2].Value.ToString();
                itm.strProcess = DGMFGVoucherList.CurrentRow.Cells[4].Value.ToString();
                itm.strBranchId = DGMFGVoucherList.CurrentRow.Cells[5].Value.ToString();

                itm.strRMRefNo = DGMFGVoucherList.CurrentRow.Cells[9].Value.ToString();
                itm.strFgRefNo = DGMFGVoucherList.CurrentRow.Cells[10].Value.ToString();
                itm.strWmRefNo = DGMFGVoucherList.CurrentRow.Cells[11].Value.ToString();

                items.Add(itm);
            }
            return items;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PanelSearch.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            uctxtFindWhat.Text = "";
            uctxtExpression.Text = "";
            uctxtFromDate.Text = "";
            uctxtToDate.Text = "";
            PanelSearch.Visible = true;
            PanelSearch.Size = new Size(364, 195);
            PanelSearch.Location = new Point(269, 255);
            uctxtFindWhat.Focus();
        }

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                int intcount = DGMFGVoucherList.Rows.Count;
                for (int i = 0; i < intcount; i++)
                {

                    Convert.ToBoolean(DGMFGVoucherList[12, i].Value = true);

                }
            }
            else
            {
                int intcount = DGMFGVoucherList.Rows.Count;
                for (int i = 0; i < intcount; i++)
                {
                    Convert.ToBoolean(DGMFGVoucherList[12, i].Value = false);
                }
            }
        }
        private bool ValidateFields(DataGridView DgRm, DataGridView DgPm, DataGridView DgWastageRm, DataGridView dgWastagePm, string strBranchID, string strGodownsName)
        {

            try
            {
               
                double dblClosingQTY = 0, dblCurrentQTY = 0;
                string strBillKey = "", strNegetiveItem = "";
                int intCheckNegetive = 0;
                //if (oinv[0].mlngBlockNegativeStock > 0)
                //{
             
                    for (int i = 0; i < DgRm.Rows.Count; i++)
                    {
                        if (DgRm[0, i].Value.ToString() != "")
                        {

                            //dblClosingQTY = Utility.gdblClosingStock(strComID, DgRm[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                            dblClosingQTY = Utility.gdblClosingStockSales(strComID, DgRm[0, i].Value.ToString(), strBranchID, "", strGodownsName);
                            //if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            //{
                            //    strBillKey = DgRm[6, i].Value.ToString();
                            //    dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                            //}
                            dblCurrentQTY = Utility.Val(DgRm[1, i].Value.ToString());
                            if ((dblClosingQTY) - dblCurrentQTY < 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + DgRm[0, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                        }
                        dblClosingQTY = 0;
                    }
                    for (int i = 0; i < DgPm.Rows.Count; i++)
                    {
                        if (DgPm[0, i].Value.ToString() != "")
                        {

                            //dblClosingQTY = Utility.gdblClosingStock(strComID, DgRm[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                            dblClosingQTY = Utility.gdblClosingStockSales(strComID, DgPm[0, i].Value.ToString(), strBranchID, "", strGodownsName);
                            //if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            //{
                            //    strBillKey = DgPm[6, i].Value.ToString();
                            //    dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                            //}
                            dblCurrentQTY = Utility.Val(DgPm[1, i].Value.ToString());
                            if ((dblClosingQTY) - dblCurrentQTY < 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + DgPm[0, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                        }
                        dblClosingQTY = 0;
                    }
                    if (intCheckNegetive > 0)
                    {
                        MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                        DgRm.Focus();
                        return false;
                    }
                    for (int i = 0; i < DgWastageRm.Rows.Count; i++)
                    {
                        if (DgWastageRm[0, i].Value.ToString() != "")
                        {
                            //strBillKey = DgWastageRm[5, i].Value.ToString();
                            //dblClosingQTY = Utility.gdblClosingStock(strComID, DgWastage[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                            dblClosingQTY = Utility.gdblClosingStockSales(strComID, DgWastageRm[0, i].Value.ToString(), strBranchID, "", strGodownsName);
                            //if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            //{
                            //    strBillKey = DgWastageRm[5, i].Value.ToString();
                            //    dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                            //}
                            dblCurrentQTY = Utility.Val(DgWastageRm[1, i].Value.ToString());
                            if ((dblClosingQTY) - dblCurrentQTY < 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + DgWastageRm[0, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                        }
                        dblClosingQTY = 0;
                    }

                    if (intCheckNegetive > 0)
                    {
                        MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                        DgRm.Focus();
                        return false;
                    }
                    for (int i = 0; i < dgWastagePm.Rows.Count; i++)
                    {
                        if (dgWastagePm[0, i].Value.ToString() != "")
                        {

                            //dblClosingQTY = Utility.gdblClosingStock(strComID, DgWastage[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                            dblClosingQTY = Utility.gdblClosingStockSales(strComID, dgWastagePm[0, i].Value.ToString(), strBranchID, "", strGodownsName);
                            //if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            //{
                            //    strBillKey = dgWastagePm[5, i].Value.ToString();
                            //    dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                            //}
                            dblCurrentQTY = Utility.Val(dgWastagePm[1, i].Value.ToString());
                            if ((dblClosingQTY) - dblCurrentQTY < 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + dgWastagePm[0, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                        }
                        dblClosingQTY = 0;
                    }

                    if (intCheckNegetive > 0)
                    {
                        MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                        DgRm.Focus();
                        return false;
                    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void btnApproved_Click(object sender, EventArgs e)
        {
            int intcount = 0;
          
            string strmsg = "",strBranchID="",strGodowns="",strTLocation="";
            int intrm = 0, intPm = 0, intrmWastage = 0, intPmWastage = 0;
            try
            {
                //if (Utility.gblnAccessControl)
                //{
                //    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, 189, 1))
                //    {
                //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}
              
                for (int i = 0; i < DGMFGVoucherList.Rows.Count; i++)
                {
                    DgRm.Rows.Clear();
                    DgPm.Rows.Clear();
                    DgWastageRm.Rows.Clear();
                    dgWastagePm.Rows.Clear();
                    if (Convert.ToBoolean(DGMFGVoucherList.Rows[i].Cells[12].Value) == true)
                    {
                        
                        List<MFGvouhcer> oRm = objWIS.mDisplayProductionList(strComID, DGMFGVoucherList.Rows[i].Cells[10].Value.ToString()).ToList();
                        {
                            strBranchID = oRm[0].strBranchId;
                            strGodowns = oRm[0].strLocation;
                            strTLocation = oRm[0].strTLocation;
                            foreach (MFGvouhcer ooRm in oRm)
                            {

                                if (ooRm.intProcessType == 1)
                                {
                                    DgRm.Rows.Add();
                                    DgRm[0, intrm].Value = ooRm.strItemName;
                                    DgRm[1, intrm].Value = ooRm.dblQnty + " " + ooRm.strUOM;
                                    DgRm[2, intrm].Value = ooRm.strUOM;
                                    //dblrate = Utility.gdblPurchasePrice(strComID, ts.stritemName, dteDate.Text);
                                    DgRm[3, intrm].Value = Math.Round((ooRm.dblAmount), 4);
                                    DgRm[4, intrm].Value = "Del.";
                                    DgRm[5, intrm].Value = ooRm.dblQnty;
                                    DgRm[6, intrm].Value = ooRm.strBillKey;
                                    intrm += 1;
                                }
                                if (ooRm.intProcessType == 2)
                                {
                                    DgPm.Rows.Add();
                                    DgPm[0, intPm].Value = ooRm.strItemName;
                                    DgPm[1, intPm].Value = ooRm.dblQnty + " " + ooRm.strUOM;
                                    DgPm[2, intPm].Value = ooRm.strUOM;
                                    //dblrate = Utility.gdblPurchasePrice(strComID, ts.stritemName, dteDate.Text);
                                    DgPm[3, intPm].Value = Math.Round((ooRm.dblAmount), 4);
                                    DgPm[4, intPm].Value = "Del.";
                                    DgPm[5, intPm].Value = ooRm.dblQnty;
                                    DgPm[6, intPm].Value = ooRm.strBillKey;
                                    intPm += 1;
                                }
                                if (ooRm.intProcessType == 3)
                                {
                                    DgWastageRm.Rows.Add();
                                    DgWastageRm[0, intrmWastage].Value = ooRm.strItemName;
                                    DgWastageRm[1, intrmWastage].Value = ooRm.dblQnty + " " + ooRm.strUOM;
                                    DgWastageRm[2, intrmWastage].Value = ooRm.strUOM;
                                    //dblrate = Utility.gdblPurchasePrice(strComID, ts.stritemName, dteDate.Text);
                                    DgWastageRm[3, intrmWastage].Value = Math.Round((ooRm.dblAmount), 4);
                                    DgWastageRm[4, intrmWastage].Value = "Del.";
                                    //DgWastageRm[5, intrmWastage].Value = ooRm.dblQnty;
                                    DgWastageRm[5, intrmWastage].Value = ooRm.strBillKey;
                                    intrmWastage += 1;
                                }
                                if (ooRm.intProcessType == 4)
                                {
                                    dgWastagePm.Rows.Add();
                                    dgWastagePm[0, intPmWastage].Value = ooRm.strItemName;
                                    dgWastagePm[1, intPmWastage].Value = ooRm.dblQnty + " " + ooRm.strUOM;
                                    dgWastagePm[2, intPmWastage].Value = ooRm.strUOM;
                                    //dblrate = Utility.gdblPurchasePrice(strComID, ts.stritemName, dteDate.Text);
                                    dgWastagePm[3, intPmWastage].Value = Math.Round((ooRm.dblAmount), 4);
                                    dgWastagePm[4, intPmWastage].Value = "Del.";
                                    //dgWastagePm[5, intPmWastage].Value = ooRm.dblQnty;
                                    dgWastagePm[5, intPmWastage].Value = ooRm.strBillKey;
                                    intPmWastage += 1;
                                }
                                DgRm.AllowUserToAddRows = false;
                                DgWastageRm.AllowUserToAddRows = false;
                                DgPm.AllowUserToAddRows = false;
                                dgWastagePm.AllowUserToAddRows = false;
                            }
                        }
                        if (ValidateFields(DgRm, DgPm, DgWastageRm, dgWastagePm, strBranchID, strGodowns) == false)
                        {
                            return;
                        }

                        strmsg = objWIS.gUpdateProductionOrder(strComID, DGMFGVoucherList[10, i].Value.ToString(), 1, strTLocation);
                        if (strmsg=="1")
                        {
                            DGMFGVoucherList.Rows.RemoveAt(i);
                        }
                        strBranchID = "";
                        strGodowns = "";
                        strTLocation = "";
                        intrm = 0;
                        intPm = 0;
                        intrmWastage = 0;
                        intPmWastage = 0;
                        intcount += 1;
                    }
                }
                if (strmsg == "1")
                {
                    mfgVoucherList(0);
                }
                MessageBox.Show(intcount + " Records Approved Successfully...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnNotApproved_Click(object sender, EventArgs e)
        {
            int intcount = 0;
            string strmsg = "";
            try
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, 190, 1))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                for (int i = 0; i < DGMFGVoucherList.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(DGMFGVoucherList.Rows[i].Cells[12].Value) == true)
                    {
                        strmsg = objWIS.gUpdateProductionOrder(strComID, DGMFGVoucherList[10, i].Value.ToString(), 0,"");
                        intcount += 1;
                    }
                }
                if (strmsg == "1")
                {
                    mfgVoucherList(0);
                }
                MessageBox.Show(intcount + " Records Not Approved Successfully...");
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
        }

        private void btnListApp_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, 191, 1))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                mfgVoucherList(1);
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
        }

    
    }
}
