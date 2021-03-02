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
using JA.Modulecontrolar.UI.DReport.Purchase.Viewer;
using JA.Modulecontrolar.UI.DReport.Purchase;
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using JA.Modulecontrolar.UI.DReport.Accms;
using Microsoft.Win32;
using JA.Modulecontrolar.JINVMS;


namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSalesOrdeNewList : JA.Shared.UI.frmJagoronFromSearch
    {
        SPWOIS objWoIS = new SPWOIS();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<AccountsVoucher> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public int intModuleType { get; set; }
        public string strFormName { get; set; }
        public int mintVType { get; set; }
        public int mintSp { get; set; }
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
        private ListBox lstFindWhat = new ListBox();
        public string strPreserveSQl { get; set; }
        private ListBox lstExpression = new ListBox();
        private string strComID { get; set; }
        public frmSalesOrdeNewList()
        {
            InitializeComponent();
            #region "Registry"
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #endregion
            #region "User Define"
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
                int intAreaStaus = 0;
                if (chkAreaStatus.Checked == true)
                {
                    intAreaStaus = 1;
                }

                mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, intAreaStaus);
                PanelSearch.Visible = false;
            }
        }
        private void uctxtFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstFindWhat.Visible = false;
            lstExpression.Visible = false;

        }
        private void uctxtToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstFindWhat.Visible = false;
            lstExpression.Visible = false;

        }
        private void uctxtExpression_TextChanged(object sender, EventArgs e)
        {
            lstExpression.SelectedIndex = lstExpression.FindString(uctxtExpression.Text);
        }

        private void lstExpression_DoubleClick(object sender, EventArgs e)
        {
            int intAreaStaus = 0;
            if (chkAreaStatus.Checked == true)
            {
                intAreaStaus = 1;
            }
            uctxtExpression.Text = lstExpression.SelectedValue.ToString();
            PanelSearch.Visible = false;
            mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, intAreaStaus);
            DG.Focus();


        }
        private void uctxtExpression_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int intAreaStaus = 0;
                if (chkAreaStatus.Checked == true)
                {
                    intAreaStaus = 1;
                }
                if (lstExpression.Visible)
                {
                    if (lstExpression.Items.Count > 0)
                    {
                        uctxtExpression.Text = lstExpression.SelectedValue.ToString();
                    }
                }

                mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, intAreaStaus);
                PanelSearch.Visible = false;
                DG.Focus();


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
            if (uctxtFindWhat.Text == "Ledger Name")
            {
                lstFindWhat.Visible = false;
                lstExpression.Visible = true;
                lblExpression.Visible = true;
                uctxtExpression.Visible = true;
                uctxtFromDate.Visible = false;
                uctxtToDate.Visible = false;
                lblfromDate.Visible = false;
                lblTodate.Visible = false;
                if (mintVType == (int)(Utility.VOUCHER_TYPE.vtSALES_INVOICE))
                {
                    lstExpression.DataSource = accms.mFillLedgerList(strComID, (int)Utility.GR_GROUP_TYPE.grCUSTOMER).ToList();
                    lstExpression.ValueMember = "strLedgerName";
                    lstExpression.DisplayMember = "strmerzeString";
                }
                else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE))
                {

                    lstExpression.DataSource = accms.mFillLedgerList(strComID, (int)Utility.GR_GROUP_TYPE.grSUPPLIER).ToList();
                    lstExpression.ValueMember = "strLedgerName";
                    lstExpression.DisplayMember = "strmerzeString";
                }
                else
                {
                    lstExpression.DataSource = accms.mFillLedgerList(strComID, 206).ToList();
                    lstExpression.ValueMember = "strLedgerName";
                    lstExpression.DisplayMember = "strmerzeString";
                }
            }
            else if (uctxtFindWhat.Text == "Branch Name")
            {
                lstFindWhat.Visible = false;
                lstExpression.Visible = true;
                lblExpression.Visible = true;
                uctxtExpression.Visible = true;
                uctxtFromDate.Visible = false;
                uctxtToDate.Visible = false;
                lblfromDate.Visible = false;
                lblTodate.Visible = false;
                lstExpression.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
                lstExpression.ValueMember = "BranchID";
                lstExpression.DisplayMember = "BranchName";
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

            }
            else if (uctxtFindWhat.Text == "Cheque Date")
            {
                lstExpression.Visible = false;
                lblExpression.Visible = false;
                uctxtExpression.Visible = false;
                uctxtFromDate.Visible = true;
                uctxtToDate.Visible = true;
                lblfromDate.Visible = true;
                lblTodate.Visible = true;
            }
            else
            {
                lstExpression.Visible = false;
                lblExpression.Visible = false;
                uctxtExpression.Visible = false;
                uctxtFromDate.Visible = false;
                uctxtToDate.Visible = false;
                lblfromDate.Visible = false;
                lblTodate.Visible = false;
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
                strPreserveSQl = "";
                if (lstFindWhat.Items.Count > 0)
                {
                    uctxtFindWhat.Text = lstFindWhat.Text;
                }
                if (uctxtFindWhat.Text == "Ledger Name")
                {
                    lstExpression.Visible = true;
                    lblExpression.Visible = true;
                    uctxtExpression.Visible = true;
                    uctxtFromDate.Visible = false;
                    uctxtToDate.Visible = false;
                    lblfromDate.Visible = false;
                    lblTodate.Visible = false;

                    if (mintVType == (int)(Utility.VOUCHER_TYPE.vtSALES_INVOICE))
                    {


                        lstExpression.DataSource = accms.mFillLedgerList(strComID, (int)Utility.GR_GROUP_TYPE.grCUSTOMER).ToList();
                        lstExpression.ValueMember = "strLedgerName";
                        lstExpression.DisplayMember = "strmerzeString";
                    }
                    else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE))
                    {


                        lstExpression.DataSource = accms.mFillLedgerList(strComID, (int)Utility.GR_GROUP_TYPE.grSUPPLIER).ToList();
                        lstExpression.ValueMember = "strLedgerName";
                        lstExpression.DisplayMember = "strmerzeString";
                    }
                    else
                    {

                        lstExpression.DataSource = accms.mFillLedgerList(strComID, 206).ToList();
                        lstExpression.ValueMember = "strLedgerName";
                        lstExpression.DisplayMember = "strmerzeString";
                    }

                }
                else if (uctxtFindWhat.Text == "Branch Name")
                {
                    lstExpression.Visible = true;
                    lblExpression.Visible = true;
                    uctxtExpression.Visible = true;
                    uctxtFromDate.Visible = false;
                    uctxtToDate.Visible = false;
                    lblfromDate.Visible = false;
                    lblTodate.Visible = false;

                    lstExpression.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
                    lstExpression.ValueMember = "BranchID";
                    lstExpression.DisplayMember = "BranchName";
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

                }
                else if (uctxtFindWhat.Text == "Cheque Date")
                {
                    lstExpression.Visible = false;
                    lblExpression.Visible = false;
                    uctxtExpression.Visible = false;
                    uctxtFromDate.Visible = true;
                    uctxtToDate.Visible = true;
                    lblfromDate.Visible = true;
                    lblTodate.Visible = true;
                }
                else
                {
                    lstExpression.Visible = false;
                    lblExpression.Visible = true;
                    uctxtExpression.Visible = true;
                    uctxtFromDate.Visible = false;
                    uctxtToDate.Visible = false;
                    lblfromDate.Visible = false;
                    lblTodate.Visible = false;
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


        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, mintVType).ToList();
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
        private void mLoadFind()
        {
            lstFindWhat.Items.Clear();
            lstFindWhat.Items.Add("Voucher Number");
            lstFindWhat.Items.Add("Voucher Date");
            lstFindWhat.Items.Add("Ledger Name");
            lstFindWhat.Items.Add("Branch Name");
            lstFindWhat.Items.Add("Amount");
            //lstFindWhat.Items.Add("Narrations");
            //lstFindWhat.Items.Add("Cheque Number");
            //lstFindWhat.Items.Add("Cheque Date");

        }

        private void frmAccountsVoucherList_Load(object sender, EventArgs e)
        {
            lstExpression.Visible = false;
            lstFindWhat.Visible = false;
            DG.AllowUserToAddRows = false;
            mGetConfig();
            if (mintVType == (int)(Utility.VOUCHER_TYPE.vtSALES_ORDER))
            {
                frmLabel.Text = "Sales Order List";
            }


            this.DG.DefaultCellStyle.Font = new Font("verdana", 10F);


            DG.Columns.Add(Utility.Create_Grid_Column("SLNo", "SLNo", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Voucher key", "Voucher No", 200, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 170, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 90, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 300, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Branch Name", "Branch Name", 250, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Net Amount", "Net Amount", 118, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("App.", "App.", 40, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.CreateChkBxGrd("Check", "Check", 50, true, DataGridViewContentAlignment.TopLeft, false, false, "Check"));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 45, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delele", "Delele", "Delele", 50, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Sql", "Sql", 110, false, DataGridViewContentAlignment.TopLeft, true));
            mLoadFind();
            int intAreaStaus = 0;
            if (chkAreaStatus.Checked ==true)
            {
                intAreaStaus = 1;
            }
            mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, intAreaStaus);
        }

        private void mFetchRecord(string strFindWhat, string strExpression, string strFdate, string strTdate,int intAreaStatus)
        {
            DG.Rows.Clear();

            List<AccountsVoucher> ooVlist;
            if (strPreserveSQl == null)
            {
                strPreserveSQl = "";
            }
            if (mintVType == (int)(Utility.VOUCHER_TYPE.vtSALES_QUOTATION))
            {
                ooVlist = accms.mOpentableQuo(strComID, mintVType, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), "").ToList();
            }

            else if (strFindWhat == "Voucher Number")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, strExpression, Utility.gstrUserName, "", "", mintSp, strPreserveSQl, intAreaStatus).ToList();
            }
            else if (strFindWhat == "Voucher Date")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, "", Utility.gstrUserName, strFdate, strTdate, mintSp, strPreserveSQl, intAreaStatus).ToList();
            }
            else if (strFindWhat == "Ledger Name")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, strExpression, Utility.gstrUserName, "", "", mintSp, strPreserveSQl, intAreaStatus).ToList();
            }
            else if (strFindWhat == "Branch Name")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, strExpression, Utility.gstrUserName, "", "", mintSp, strPreserveSQl, intAreaStatus).ToList();
            }
            else if (strFindWhat == "Amount")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, strExpression, Utility.gstrUserName, "", "", mintSp, strPreserveSQl, intAreaStatus).ToList();
            }
            else if (strFindWhat == "Narrations")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, strExpression, Utility.gstrUserName, "", "", mintSp, strPreserveSQl, intAreaStatus).ToList();
            }
            else if (strFindWhat == "Cheque Number")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, strExpression, Utility.gstrUserName, "", "", mintSp, strPreserveSQl, intAreaStatus).ToList();
            }
            else if (strFindWhat == "Cheque Date")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, "", Utility.gstrUserName, strFdate, strTdate, mintSp, strPreserveSQl, intAreaStatus).ToList();
            }

            else
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, "", Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), mintSp, strPreserveSQl,intAreaStatus).ToList();
            }



            if (ooVlist.Count() > 0)
            {
                int j = 0;
                foreach (AccountsVoucher ovoucher in ooVlist)
                {
                    DG.Rows.Add();
                    DG[1, j].Value = ovoucher.strVoucherNo;
                    DG[2, j].Value = Utility.Mid(ovoucher.strVoucherNo, 6, ovoucher.strVoucherNo.Length - 6);
                    DG[3, j].Value = Convert.ToDateTime(ovoucher.strTranDate).ToString("dd/MM/yyyy");
                    DG[4, j].Value = ovoucher.strMerzeName;
                    DG[5, j].Value = ovoucher.strBranchName;
                    DG[6, j].Value = ovoucher.dblAmount;
                    if (chkAreaStatus.Checked == false)
                    {
                        if (ovoucher.intAppStatus == 1)
                        {
                            DG[7, j].Value = "No";
                            //Convert.ToBoolean(DG[8, j].Value = false);
                        }
                        else
                        {
                            DG[7, j].Value = "Yes";
                            //Convert.ToBoolean(DG[8, j].Value = true);
                        }
                    }
                    else
                    {
                        if (ovoucher.intAppStatus == 0)
                        {
                            DG[7, j].Value = "No";
                            //Convert.ToBoolean(DG[8, j].Value = false);
                        }
                        else
                        {
                            DG[7, j].Value = "Yes";
                            //Convert.ToBoolean(DG[8, j].Value = true);
                        }
                    }
                    DG[9, j].Value = "Edit";
                    DG[10, j].Value = "Delele";
                    DG[11, j].Value = "View";
                    DG[12, j].Value = ovoucher.strPreserveSQL;
                    j += 1;

                }
                DG.AllowUserToAddRows = false;
                lblCount.Text = "Total Record: " + j;
            }

        }


        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int intAreaStaus = 0;
            if (chkAreaStatus.Checked == true)
            {
                intAreaStaus = 1;
            }
            if (e.ColumnIndex == 13)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, 161, 1))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
               
                string strCheck1 = Utility.mGetCheckLedgerNamePresent(strComID, "ACC_BILL_TRAN_PROCESS", "AGST_COMP_REF_NO", "COMP_VOUCHER_TYPE", DG.CurrentRow.Cells[1].Value.ToString(), "16");
                //string strCheck1 = Utility.mCheckChallan(strComID,  DG.CurrentRow.Cells[1].Value.ToString());
                if (strCheck1 != "")
                {
                    if (strCheck1 != "")
                    {
                        MessageBox.Show("Sorry!Invoice Found, You cannot Undo this Voucher");
                        mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, intAreaStaus);
                        DG.Focus();
                        return;
                    }


                }
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)DG.Rows[DG.CurrentRow.Index].Cells[13];
                if (ch1.Value == null)
                    ch1.Value = false;
                switch (ch1.Value.ToString())
                {
                    case "True":
                        {
                            ch1.Value = false;

                            var strResponse = MessageBox.Show("Do You want to Undo this Order?", "Approved Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (strResponse == DialogResult.Yes)
                            {
                                string i = accms.mUpdateOnLineApprove(strComID, DG.CurrentRow.Cells[1].Value.ToString(), 0, Utility.gstrUserName);
                                if (i == "1")
                                {
                                    mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, intAreaStaus);
                                }
                                else
                                {
                                    MessageBox.Show(i.ToString());
                                }


                            }
                            else
                            {
                                mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, intAreaStaus);
                            }
                            break;
                        }
                    case "False":
                        {
                            ch1.Value = true;
                            var strResponse = MessageBox.Show("Do You want to Approved this Order?", "Approved Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (strResponse == DialogResult.Yes)
                            {
                                string i = accms.mUpdateOnLineApprove(strComID, DG.CurrentRow.Cells[1].Value.ToString(), 1, Utility.gstrUserName);
                                if (i == "1")
                                {
                                    mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, intAreaStaus);
                                }
                                else
                                {
                                    MessageBox.Show(i.ToString());
                                }

                            }
                            else
                            {
                                mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, intAreaStaus);
                            }

                            break;
                        }
                }

            }
            if (e.ColumnIndex == 9)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                //string strCheck = Utility.mGetCheckLedgerNamePresent(strComID, "ACC_COMPANY_VOUCHER", "COMP_REF_NO", "APP_STATUS", DG.CurrentRow.Cells[1].Value.ToString(), "1");
                string strCheck = Utility.mCheckChallan(strComID, DG.CurrentRow.Cells[1].Value.ToString());
                if (strCheck != "")
                {
                    if (strCheck != "")
                    {
                        MessageBox.Show("Sorry!Already Approved, You cannot Edit this Voucher");
                        DG.Focus();
                        return;
                    }
                }
                //string strCheck1 = Utility.mCheckDuplicateItem(strComID, "ACC_BILL_TRAN_PROCESS", "AGST_COMP_REF_NO", DG.CurrentRow.Cells[1].Value.ToString());
                string strCheck1 = Utility.mCheckChallan(strComID, DG.CurrentRow.Cells[1].Value.ToString());
                if (strCheck1 != "")
                {
                    if (strCheck1 != "")
                    {
                        MessageBox.Show("Sorry!Invoice Found, You cannot Edit this Voucher");
                        DG.Focus();
                        return;
                    }


                }


                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
            if (e.ColumnIndex == 10)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                string strCheck = Utility.mGetCheckLedgerNamePresent(strComID, "ACC_COMPANY_VOUCHER", "COMP_REF_NO", "APP_STATUS", DG.CurrentRow.Cells[1].Value.ToString(), "2");
                if (strCheck != "")
                {
                    if (strCheck != "")
                    {
                        MessageBox.Show("Sorry!Already Approved, You cannot Delete this Voucher");
                        DG.Focus();
                        return;
                    }
                }
                string strCheck1 = Utility.mCheckDuplicateItem(strComID, "ACC_BILL_TRAN_PROCESS", "AGST_COMP_REF_NO", DG.CurrentRow.Cells[1].Value.ToString());
                if (strCheck != "")
                {
                    if (strCheck1 != "")
                    {
                        MessageBox.Show("Sorry!Invoice Found, You cannot Delete this Voucher");
                        DG.Focus();
                        return;
                    }


                }

                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    double dblAmnt = Convert.ToDouble(DG.CurrentRow.Cells[6].Value.ToString());
                    string i = Delete.gDeleteRecord(strComID, DG.CurrentRow.Cells[1].Value.ToString(), mintVType, mblnNumbMethod);
                    if (i == "Delete Successfull..")
                    {

                        if (Utility.gblnAccessControl)
                        {

                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, DG.CurrentRow.Cells[1].Value.ToString(),
                                                                    3, dblAmnt, intModuleType, "0001");
                        }
                        DG.Rows.RemoveAt(e.RowIndex);
                        DGSalesGrid.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show(i.ToString());
                    }


                    uctxtFindWhat.Text = "";
                    uctxtExpression.Text = "";
                    uctxtFromDate.Text = "";
                    uctxtToDate.Text = "";

                    //mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text);
                }

            }
            if (e.ColumnIndex == 11)
            {
                if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_ORDER)
                {

                    //JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                    //frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNo;
                    //frmviewer.strLedgerName = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                    //frmviewer.strFdate = "";
                    //frmviewer.intMode = mintVType;
                    //frmviewer.strString2 = "Sales Order";
                    //frmviewer.Show();
                    //frmviewer.Show();
                    JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNoListReport;
                    frmviewer.strString = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                    frmviewer.strString2 = "Sales Order";
                    frmviewer.intSuppress = 1;
                    frmviewer.intMode = mintVType;
                    frmviewer.Show();
                }


            }


        }


        private List<AccountsVoucher> GetSelectedItem()
        {
            List<AccountsVoucher> items = new List<AccountsVoucher>();
            AccountsVoucher itm = new AccountsVoucher();
            itm.strVoucherNo = DG.CurrentRow.Cells[1].Value.ToString();
            if (DG.CurrentRow.Cells[7].Value.ToString() == "No")
            {
                itm.intAppStatus = 0;
            }
            else
            {
                itm.intAppStatus = 1;
            }
            itm.strPreserveSQL = DG.CurrentRow.Cells[12].Value.ToString();
            items.Add(itm);
            return items;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            uctxtFindWhat.Text = "";
            uctxtExpression.Text = "";
            uctxtFromDate.Text = "";
            uctxtToDate.Text = "";
            PanelSearch.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            uctxtFindWhat.Text = "";
            uctxtExpression.Text = "";
            uctxtFromDate.Text = "";
            uctxtToDate.Text = "";
            PanelSearch.Visible = true;
            PanelSearch.Size = new Size(496, 195);
            PanelSearch.Location = new Point(466, 321);
            uctxtFindWhat.Focus();
        }

        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                int intcount = DG.Rows.Count;
                for (int i = 0; i < intcount; i++)
                {
                    if (DG[7, i].Value == "No")
                    {
                        Convert.ToBoolean(DG[8, i].Value = true);
                    }
                    else
                    {
                        Convert.ToBoolean(DG[8, i].Value = false);
                    }
                }
            }
            else
            {
                int intcount = DG.Rows.Count;
                for (int i = 0; i < intcount; i++)
                {
                    Convert.ToBoolean(DG[8, i].Value = false);
                }
            }
        }
        private void DisplayVoucherList(string vstrRefNo)
        {
            try
            {
                int introw = 0;
                DGSalesGrid.Rows.Clear();


                List<AccountsVoucher> ooaccVou = accms.DisplayCompVoucherList(strComID, vstrRefNo, 12).ToList();
                if (ooaccVou.Count > 0)
                {
                    foreach (AccountsVoucher oCom in ooaccVou)
                    {
                      
                        if (oCom.strSalesRepresentive != "")
                        {
                            uctxtCustomer.Text = oCom.strSalesRepresentive;
                          
                        }
                       
                        dteDate.Text = oCom.strTranDate;
                        uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, oCom.strBranchID);


                        List<AccBillwise> ooVouList = accms.DisplayCommonInvoice(strComID, vstrRefNo).ToList();
                        if (ooVouList.Count > 0)
                        {

                            foreach (AccBillwise oacc in ooVouList)
                            {
                                uctxtLocation.Text = oacc.strGodownsName;
                                DGSalesGrid.Rows.Add();
                                DGSalesGrid[0, introw].Value = oacc.strStockGroupName;
                                DGSalesGrid[1, introw].Value = oacc.strStockItemName;
                                DGSalesGrid[2, introw].Value = Utility.mGetPowerClass(strComID, oacc.strStockItemName);
                                DGSalesGrid[3, introw].Value = Utility.mGetPackSize(strComID, oacc.strStockItemName);
                                DGSalesGrid[4, introw].Value = oacc.dblQnty;
                                DGSalesGrid[5, introw].Value = oacc.dblRate;
                                DGSalesGrid[6, introw].Value = oacc.strPer;
                                DGSalesGrid[7, introw].Value = oacc.dblAmount;
                                DGSalesGrid[8, introw].Value = oacc.strBillAddless;
                                DGSalesGrid[9, introw].Value = oacc.dblBonusQnty;
                                DGSalesGrid[10, introw].Value = oacc.dblBillNetAmount;

                                DGSalesGrid[11, introw].Value = "Delete";
                                DGSalesGrid[12, introw].Value = oacc.strSubgroup;
                                DGSalesGrid[13, introw].Value = oacc.dblComm;
                                introw += 1;
                            }
                         
                            DGSalesGrid.AllowUserToAddRows = false;
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
        private string  PopulateGrid()
        {
            string strGrid = "", strSubGroup = "";
            
            double dblCommAmnt = 0, dblCommPer = 0, dblNetAmnt = 0;
            for (int introw = 0; introw < DGSalesGrid.Rows.Count; introw++)
            {

                if (DGSalesGrid[12, introw].Value.ToString() != "")
                {
                    strSubGroup = DGSalesGrid[12, introw].Value.ToString();
                }
                else
                {
                    strSubGroup = "";
                }
                if (DGSalesGrid[8, introw].Value.ToString() != "")
                {
                    dblCommAmnt = Convert.ToDouble(DGSalesGrid[8, introw].Value.ToString());
                }
                else
                {
                    dblCommAmnt = 0;
                }

                if (DGSalesGrid[10, introw].Value.ToString() != "")
                {
                    dblNetAmnt = Convert.ToDouble(DGSalesGrid[10, introw].Value.ToString());
                }
                else
                {
                    dblNetAmnt = 0;
                }
                if (DGSalesGrid[13, introw].Value.ToString() != "")
                {
                    dblCommPer = Convert.ToDouble(DGSalesGrid[13, introw].Value.ToString());
                }
                else
                {
                    dblCommPer = 0;
                }

                strGrid += DGSalesGrid[0, introw].Value.ToString() + "|" + DGSalesGrid[1, introw].Value.ToString() + "|" + DGSalesGrid[2, introw].Value.ToString() +
                                        "|" + DGSalesGrid[3, introw].Value.ToString() + "|" + DGSalesGrid[4, introw].Value.ToString() + "|" +
                                        DGSalesGrid[5, introw].Value.ToString() + "|" + DGSalesGrid[6, introw].Value.ToString() + "|" +
                                        DGSalesGrid[7, introw].Value.ToString() + "|" + DGSalesGrid[9, introw].Value.ToString() + "|" + strSubGroup + "|" +
                                        dblCommAmnt + "|" + dblNetAmnt + "|" + dblCommPer + "~";

                
            }
            return strGrid;
        }
        private void mCalculateDiscount()
        {
            string strItemGroup = "", str2ndGroup = "", strGrid = "", strBranchID = "";
            double dblItemAmount = 0, dblAmount = 0;
            //List<Sample> ooSample = invms.mFillSample().ToList();
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            List<StockGroup> ooSample = invms.mFillStockGroupconfig(strComID).ToList();
            foreach (StockGroup oobj in ooSample)
            {
                strItemGroup = oobj.GroupName;

                for (int int2nd = 0; int2nd < DGSalesGrid.Rows.Count; int2nd++)
                {
                    if (DGSalesGrid[1, int2nd].Value != null)
                    {
                        str2ndGroup = DGSalesGrid[12, int2nd].Value.ToString();
                        if (strItemGroup == str2ndGroup)
                        {

                            dblAmount = (Utility.Val(DGSalesGrid[4, int2nd].Value.ToString()) * Utility.Val(DGSalesGrid[5, int2nd].Value.ToString()));
                            dblItemAmount = dblItemAmount + dblAmount;
                        }
                    }
                }
                if (dblItemAmount != 0)
                {
                    strGrid += strItemGroup + "|" + dblItemAmount + "~";
                }
                dblItemAmount = 0;
            }


            //MessageBox.Show(strGrid);
            if (strGrid != "")
            {
                double dblPercent = 0, dblFixedPercent = 0;
                string strFDate = "", strTdate = "";
                string[] words = strGrid.Split('~');
                foreach (string ooassets in words)
                {
                    string[] oAssets = ooassets.Split('|');
                    if (oAssets[0] != "")
                    {
                        dblPercent = Utility.mdblGetCommiPercen(strComID, oAssets[0], Utility.Val(oAssets[1]), strBranchID);
                        strFDate = Utility.FirstDayOfMonth(dteDate.Value).ToString("dd/MM/yyyy");
                        strTdate = dteDate.Text;
                        //if (m_action == 1)
                        //{
                        dblFixedPercent = Utility.mdblGetMaxCommiPercen(strComID, uctxtCustomer.Text, oAssets[0], strFDate, strTdate, strBranchID, "");
                        //}
                        //else
                        //{
                            //dblFixedPercent = Utility.mdblGetMaxCommiPercen(strComID, uctxtCustomer.Text, oAssets[0], strFDate, strTdate, strBranchID, uctxtOldRefNo.Text);
                        //}
                        if (dblFixedPercent == 40)
                        {
                            dblPercent = 40;
                        }

                        for (int int2nd = 0; int2nd < DGSalesGrid.Rows.Count; int2nd++)
                        {
                            if (DGSalesGrid[12, int2nd].Value != null)
                            {
                                str2ndGroup = DGSalesGrid[12, int2nd].Value.ToString();
                                if (oAssets[0] == str2ndGroup)
                                {
                                    DGSalesGrid[8, int2nd].Value = ((Utility.Val(DGSalesGrid[4, int2nd].Value.ToString()) * Utility.Val(DGSalesGrid[5, int2nd].Value.ToString())) * dblPercent) / 100;
                                    DGSalesGrid[10, int2nd].Value = Utility.Val(DGSalesGrid[7, int2nd].Value.ToString()) - Utility.Val(DGSalesGrid[8, int2nd].Value.ToString());
                                    DGSalesGrid[13, int2nd].Value = dblPercent;
                                }
                            }
                        }
                        dblItemAmount = 0;
                    }
                }
                calculateTotal();
            }



        }
        #region "Calculatetotal
        private void calculateTotal()
        {
            int intloop = 0;
            double  dblCommAmnt = 0;
            double sum = 0;

            try
            {
                for (int i = 0; i < DGSalesGrid.Rows.Count; i++)
                {
                    sum += double.Parse(DGSalesGrid.Rows[i].Cells[7].Value.ToString());
                    dblCommAmnt += double.Parse(DGSalesGrid.Rows[i].Cells[8].Value.ToString());
                    intloop += 1;
                }
               
                txtNetTotal.Text = (sum - dblCommAmnt).ToString();
               
            }
            catch (Exception ex)
            {

            }

        }
        #endregion
        private bool validationFields(string vstrRefNo)
        {
            
            double dblPending = 0, dblCreditLimit = 0, dblLedgerClosing = 0;
            DateTime dteDate = Convert.ToDateTime(DG.CurrentRow.Cells[3].Value.ToString());
            string strMPO = Utility.gGetLedgerNameFromMerze(strComID,DG.CurrentRow.Cells[4].Value.ToString());
            //dblCreditLimit = Utility.gdblCreditLimitGrace(strComID, strMPO, dteDate.ToString("MMMyy"), dteDate.ToString("dd-MM-yyyy"));
            dblCreditLimit = Utility.gdblCreditLimit(strComID, strMPO, dteDate.ToString("MMMyy"));
            string strResponse = Utility.gstrGetCommCal(strComID, vstrRefNo);
            if (strResponse=="No")
            {
                MessageBox.Show("You Need to Commission Calculation First,then Approved!!", "Commission Calculator", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }

            if (dblCreditLimit != 0)
            {
                string strFDate = Utility.FirstDayOfMonth(dteDate).ToString("dd-MM-yyyy");
                dblLedgerClosing = Utility.dblLedgerClosingBalance(strComID, strFDate, dteDate.ToString("dd-MM-yyyy"), strMPO, "");

                dblPending = Math.Round(dblCreditLimit - Math.Abs(dblLedgerClosing), 2);

                if (dblPending < Utility.Val(txtNetTotal.Text))
                {
                    string strCls = "";
                    if (dblLedgerClosing < 0)
                    {
                        strCls = dblLedgerClosing * -1 + " Dr";
                    }
                    else
                    {
                        strCls = dblLedgerClosing + " Cr";
                    }
                    MessageBox.Show("You have crossed your Credit Limit" + Environment.NewLine + "Closing Balance :" + strCls + Environment.NewLine
                                                                    + "Credit Limt :" + dblCreditLimit + Environment.NewLine + "Pending : " + dblPending, "Credit Limit Information", MessageBoxButtons.OK, MessageBoxIcon.Question);
                   
                    return false ;
                
                }
                else
                {
                    
                    return true;
                }
            }
            else
            {
               
                return true;
            }
           
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string strmsg = "";
            int i = 0,intcount=0;
            int intAreaStaus = 0;
            if (chkAreaStatus.Checked == true)
            {
                intAreaStaus = 1;
            }
            try
            {
                for (i = 0; i < DG.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(DG.Rows[i].Cells[8].Value) == true)
                    {
                        if (chkAreaStatus.Checked == false)
                        {
                            if (validationFields(DG[1, i].Value.ToString()) == true)
                            {
                                strmsg = objWoIS.gUpdateOnlineOrder(strComID, DG[1, i].Value.ToString(), 2);
                            }
                            if (strmsg!="1")
                            {
                                MessageBox.Show(strmsg);
                                return;
                            }
                        }
                        else
                        {
                            strmsg = objWoIS.gUpdateOnlineOrder(strComID, DG[1, i].Value.ToString(), 1);
                        }
                        intcount += 1;
                    }
                }
                chkAreaStatus.Checked = false;
                chkSelectAll.Checked = false;
                if (strmsg == "1")
                {
                    MessageBox.Show(intcount + " Records Approved Successfully");
                    mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, intAreaStaus);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string strmsg = "";
            int i = 0,intcount =0;
            int intAreaStaus = 0;
            if (chkAreaStatus.Checked == true)
            {
                intAreaStaus = 1;
            }
            try
            {
                for (i = 0; i < DG.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(DG.Rows[i].Cells[8].Value) == true)
                    {
                        strmsg = objWoIS.gUpdateOnlineOrder(strComID, DG[1, i].Value.ToString(), 3);
                        DGSalesGrid.Rows.Clear();
                        intcount += 1;
                    }
                }
                if (strmsg == "1")
                {
                    MessageBox.Show(intcount + " Records Cancel Successfully");
                    mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, intAreaStaus);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strmsg = "";
            int i = 0, intcount = 0;
            int intAreaStaus = 0;
            if (chkAreaStatus.Checked == true)
            {
                intAreaStaus = 1;
            }
            try
            {
                for (i = 0; i < DG.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(DG.Rows[i].Cells[8].Value) == true)
                    {
                        DGSalesGrid.Rows.Clear();
                        uctxtLocation.Text = "";
                        uctxtCustomer.Text = "";
                        uctxtBranchName.Text = "";
                        DisplayVoucherList(DG[1, i].Value.ToString());
                        mCalculateDiscount();
                        string strGrid = PopulateGrid();
                        strmsg = invms.mUpdateSalesOrderOnlineComm(strComID, DG[1, i].Value.ToString(), 12, dteDate.Value.ToShortDateString(), dteDate.Value.ToShortDateString(),
                                               dteDate.Value.ToString("MMMyy"), "0001", uctxtLocation.Text.ToString(), strGrid);

                      
                        intcount += 1;
                    }
                }
                if (strmsg == "1")
                {
                    chkSelectAll.Checked = false;
                    MessageBox.Show(intcount + " Records Calculate Successfully");
                    mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, intAreaStaus);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void chkAreaStatus_Click(object sender, EventArgs e)
        {
            if (chkAreaStatus.Checked)
            {
                mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, 1);
            }
            else
            {
                mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, 0);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (chkAreaStatus.Checked)
            {
                mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, 1);
            }
            else
            {
                mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, 0);
            }
        }


    }
}
