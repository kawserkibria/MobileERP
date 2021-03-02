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
using JA.Modulecontrolar.JRPT;
using CrystalDecisions.CrystalReports.Engine;
using JA.Modulecontrolar.UI.DReport.Accms.ReportUI;
using JA.Modulecontrolar.UI.DReport.Purchase.ReportUI;
using JA.Modulecontrolar.JSAPUR;
using System.Drawing.Printing;
using System.Threading;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmAccountsVoucherList : JA.Shared.UI.frmJagoronFromSearch
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JRPT.SWRPTClient orptCnn = new SWRPTClient();
        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        SPWOIS objWoIS = new SPWOIS();
        public delegate void AddAllClick(List<AccountsVoucher> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        private String reportTitle = "";
        private String reportHeading = "";
        private String secondParameter = "";
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
        public string ReportSecondParameter1 { get; set; }
        public String ReportTitle { set { reportTitle = value; } get { return reportTitle; } }
        public String ReportSecondParameter { set { secondParameter = value; } get { return secondParameter; } }
        public String ReportHeading { set { reportHeading = value; } get { return reportHeading; } }

        public frmAccountsVoucherList()
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
            this.DG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DG_KeyPress);
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


                mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text);
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
            uctxtExpression.Text = lstExpression.SelectedValue.ToString();
            PanelSearch.Visible = false;
            strPreserveSQl = "";
            mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text);
            DG.Focus();


        }
        private void uctxtExpression_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstExpression.Visible)
                {
                    if (lstExpression.Items.Count > 0)
                    {
                        uctxtExpression.Text = lstExpression.SelectedValue.ToString();
                    }
                }
                strPreserveSQl = "";
                mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text);
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
                else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER) || mintVType == (int)(Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) || mintVType == (int)(Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER) || mintVType == (int)(Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER))
                {


                    lstExpression.DataSource = objWoIS.mLedgerAdditemMrNew(strComID).ToList();
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
                uctxtFromDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                uctxtToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
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
                uctxtFromDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                uctxtToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
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
                    else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER) || mintVType == (int)(Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) || mintVType == (int)(Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER) || mintVType == (int)(Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER))
                    {


                        lstExpression.DataSource = objWoIS.mLedgerAdditemMrNew(strComID).ToList();
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
                    uctxtFromDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    uctxtToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");

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
                    uctxtFromDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    uctxtToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
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
            if (mintVType == (int)(Utility.VOUCHER_TYPE.vtSALES_INVOICE))
            {
                frmLabel.Text = "Sales Invoice List";
                //lstExpression.ValueMember = "strLedgerName";
                //lstExpression.DisplayMember = "strLedgerName";
                //lstExpression.DataSource = accms.mFillLedgerList((int)Utility.GR_GROUP_TYPE.grCUSTOMER).ToList();
            }
            else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtSALES_CHALLAN))
            {
                frmLabel.Text = "Sales Challan List";
            }
            else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtSALES_RETURN))
            {
                frmLabel.Text = "Sales Return List";
            }
            else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtSALES_ORDER))
            {
                frmLabel.Text = "Sales Order List";
            }
            else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER))
            {
                frmLabel.Text = "Payment Voucher List";
            }
            else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER))
            {
                frmLabel.Text = "Receipt Voucher List";
            }
            else if ((mintVType == (int)(Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER)) && mintSp == 0)
            {
                frmLabel.Text = "Journal Voucher List";
            }
            else if ((mintVType == (int)(Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER)) && mintSp == 1)
            {
                frmLabel.Text = "MPO Commission List";
            }
            else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER))
            {
                frmLabel.Text = "Contra Voucher List";
            }
            else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE))
            {
                frmLabel.Text = "Purchase Invoice List";
            }
            else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtPURCHASE_RETURN))
            {
                frmLabel.Text = "Purchase Return List";
            }
            else
            {
                frmLabel.Text = "Accounts Voucher List";
            }

            this.DG.DefaultCellStyle.Font = new Font("verdana", 10F);

            if (mintVType == (int)(Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) && mintSp == 0)
            {
                DG.Columns.Add(Utility.Create_Grid_Column("SLNo", "SLNo", 300, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Voucher key", "Voucher No", 130, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 125, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Trans. Date", "Trans. Date", 110, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("TC Code", "TC code", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("TC Name", "TC", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("LCode", "LCode", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("HomeoHall", "HomeoHall", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Debit Ledger Name", "Debit Ledger Name", 160, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Credit Ledger Name", "Credit Ledger Name", 170, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Branch Name", "Branch Name", 240, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Net Amount", "Net Amount", 115, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 45, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 50, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 50, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Sql", "Sql", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("MR", "MR", "MR", 45, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Print", "Print", "Print", 45, true, DataGridViewContentAlignment.TopCenter, true));
            }
            else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) && mintSp == 2)
            {
                DG.Columns.Add(Utility.Create_Grid_Column("SLNo", "SLNo", 300, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Voucher key", "Voucher No", 130, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 132, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Trans. Date", "Trans. Date", 110, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("TC Code", "TC code", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("TC Name", "TC", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("LCode", "LCode", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("HomeoHall", "HomeoHall", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 300, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Branch Name", "Branch Name", 250, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Net Amount", "Net Amount", 122, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 45, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 50, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 50, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Sql", "Sql", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("DT", "DT", "DT", 45, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Print", "Print", "Print", 45, true, DataGridViewContentAlignment.TopCenter, true));
            }
            else
            {
                DG.Columns.Add(Utility.Create_Grid_Column("SLNo", "SLNo", 300, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Voucher key", "Voucher No", 130, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 132, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Trans. Date", "Trans. Date", 110, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("TC Code", "TC code", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("TC Name", "TC", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("LCode", "LCode", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("HomeoHall", "HomeoHall", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 335, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Branch Name", "Branch Name", 250, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Net Amount", "Net Amount", 118, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 45, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 50, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 60, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Sql", "Sql", 110, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("MR", "MR", "MR", 45, false, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Print", "Print", "Print", 45, true, DataGridViewContentAlignment.TopCenter, true));
            }
            mLoadFind();

            mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text);
        }

        private void mFetchRecord(string strFindWhat, string strExpression, string strFdate, string strTdate)
        {

            double dblAmount = 0;
            DG.Rows.Clear();

            List<AccountsVoucher> ooVlist;
            if (strPreserveSQl == null || strPreserveSQl == "")
            {
                strPreserveSQl = "";
            }
            if (mintVType == (int)(Utility.VOUCHER_TYPE.vtSALES_QUOTATION))
            {
                ooVlist = accms.mOpentableQuo(strComID, mintVType, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), "").ToList();
            }

            else if (strFindWhat == "Voucher Number")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, strExpression,Utility.gstrUserName, "", "", mintSp, strPreserveSQl).ToList();
            }
            else if (strFindWhat == "Voucher Date")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, "",Utility.gstrUserName, strFdate, strTdate, mintSp, strPreserveSQl).ToList();
            }
            else if (strFindWhat == "Ledger Name")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, strExpression,Utility.gstrUserName, "", "", mintSp, strPreserveSQl).ToList();
            }
            else if (strFindWhat == "Branch Name")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, strExpression,Utility.gstrUserName, "", "", mintSp, strPreserveSQl).ToList();
            }
            else if (strFindWhat == "Amount")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, strExpression,Utility.gstrUserName, "", "", mintSp, strPreserveSQl).ToList();
            }
            else if (strFindWhat == "Narrations")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, strExpression,Utility.gstrUserName, "", "", mintSp, strPreserveSQl).ToList();
            }
            else if (strFindWhat == "Cheque Number")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, strExpression,Utility.gstrUserName, "", "", mintSp, strPreserveSQl).ToList();
            }
            else if (strFindWhat == "Cheque Date")
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, "",Utility.gstrUserName, strFdate, strTdate, mintSp, strPreserveSQl).ToList();
            }

            else
            {
                ooVlist = objWoIS.mOpenTable(strComID, mintVType, strFindWhat, "",Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), mintSp, strPreserveSQl).ToList();
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

                    DG[4, j].Value = ovoucher.strTeritorryCode;
                    DG[5, j].Value = ovoucher.strTeritorryName;
                    DG[6, j].Value = ovoucher.strLedgerCode;
                    DG[7, j].Value = ovoucher.strHomeoHall;
                    DG[8, j].Value = ovoucher.strReverseLegder;
                    DG[9, j].Value = ovoucher.strMerzeName;

                   
                    DG[10, j].Value = ovoucher.strBranchName;
                    DG[11, j].Value = ovoucher.dblAmount;
                    dblAmount = dblAmount + ovoucher.dblAmount;
                    DG[12, j].Value = "Edit";
                    DG[13, j].Value = "Delele";
                    DG[14, j].Value = "View";
                    DG[15, j].Value = ovoucher.strPreserveSQL;
                    if (mintSp == 0)
                    {
                        DG[16, j].Value = "MR";
                    }
                    else
                    {
                        DG[16, j].Value = "DT";
                    }
                    DG[17, j].Value = "Print";
                    //if (j % 2 == 0)
                    //{
                    //    DG.Rows[j].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DG.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    //}
                    j += 1;

                }
                DG.AllowUserToAddRows = false;
                lblCount.Text = "Total Record: " + j;
                lblAmount.Text = "Total Amount: " + dblAmount;
            }

        }


        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (mintVType == 16)
                {
                    //string strCheck = Utility.mGetCheckLedgerNamePresent(strComID, "ACC_BILL_TRAN_PROCESS", "AGST_COMP_REF_NO", "COMP_VOUCHER_TYPE", DG.CurrentRow.Cells[1].Value.ToString(),"15");
                    string strCheck = Utility.mCheckChallan(strComID, DG.CurrentRow.Cells[1].Value.ToString());
                    if (strCheck != "")
                    {
                        if (Utility.gblnAdminPrv == true)
                        {
                            MessageBox.Show("Challan Found");
                        }
                        else
                        {
                            MessageBox.Show("Sorry!Challan Found, You cannot Edit this Voucher");
                            DG.Focus();
                            return;
                        }


                    }
                }
                if (mintVType == 3)
                {
                   
                    string strCheck = Utility.mCheckAutoJV(strComID, DG.CurrentRow.Cells[1].Value.ToString());
                    if (strCheck != "")
                    {

                        MessageBox.Show(strCheck);
                        DG.Focus();
                        return;
                    }
                }
                if (mintVType == 15)
                {
                    MessageBox.Show("Auto Process Cannot be Alter");
                    return;
                }
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
            if (e.ColumnIndex == 13)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    double dblAmnt = Convert.ToDouble(DG.CurrentRow.Cells[11].Value.ToString());
                    string strVoucherDate = DG.CurrentRow.Cells[3].Value.ToString();
                    string strBranchID = Utility.gstrGetBranchID(strComID, DG.CurrentRow.Cells[10].Value.ToString());
                    string i = Delete.gDeleteRecord(strComID, DG.CurrentRow.Cells[1].Value.ToString(), mintVType, mblnNumbMethod);
                    if (i == "Delete Successfull..")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, strVoucherDate, strFormName, DG.CurrentRow.Cells[2].Value.ToString(),
                                                                    3, dblAmnt, 1, strBranchID);
                        }
                        DG.Rows.RemoveAt(e.RowIndex);
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
            if (e.ColumnIndex == 14)
            {
                if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
                {
                    //JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                    //frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNo;
                    //frmviewer.strLedgerName = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                    //frmviewer.strString2 = "Sales Invoice List";
                    //frmviewer.intSuppress = 1;
                    //frmviewer.intMode = mintVType;
                    //frmviewer.Show();
                    JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNoListReport;
                    frmviewer.strString = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                    frmviewer.strString2 = "Sales Invoice List";
                    frmviewer.intSuppress = 1;
                    frmviewer.intMode = mintVType;
                    frmviewer.Show();
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
                {
                    JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VoucherSalesChalan;
                    frmviewer.strLedgerName = DG.CurrentRow.Cells[1].Value.ToString();
                    frmviewer.intSuppress = 1;
                    frmviewer.intvType = mintVType;
                    frmviewer.strFdate = "";
                    frmviewer.strTdate = "";
                    frmviewer.intMode = 3;
                    frmviewer.strString2 = "Sales Chalan";
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                }

                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
                {
                    JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.Vouchear;
                    frmviewer.strLedgerName = DG.CurrentRow.Cells[2].Value.ToString();
                    frmviewer.intSuppress = 1;
                    frmviewer.intvType = mintVType;
                    frmviewer.intMode = mintVType;
                    frmviewer.reportTitle2 = "A";
                    frmviewer.strString2 = "Sales Sample (Individual)";
                    frmviewer.strSelction = "Sum";
                    frmviewer.Show();
                }


                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE)
                {
                    JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNo;
                    frmviewer.strLedgerName = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                    frmviewer.strString2 = "Purchase Invoice List";
                    frmviewer.intSuppress = 1;
                    frmviewer.intMode = mintVType;
                    frmviewer.Show();
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER)
                {
                    JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.AccountsVoucher;
                    frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                    frmviewer.intNarration = 1;
                    frmviewer.intSummDetails = 1;
                    frmviewer.strFdate = "";
                    frmviewer.strBranchID = "";
                    frmviewer.strHeading = "Payment Voucher";
                    frmviewer.intVtype = mintVType;
                    frmviewer.Show();
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER)
                {
                    if (mintVType == 0)
                    {
                        JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                        frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.AccountsVoucher;
                        frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                        frmviewer.intNarration = 1;
                        frmviewer.intSummDetails = 1;
                        frmviewer.strFdate = "";
                        frmviewer.strBranchID = "";
                        frmviewer.strHeading = "Receipt Voucher";
                        frmviewer.intVtype = mintVType;
                        frmviewer.Show();
                    }
                    else
                    {
                        JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                        frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.AccountsVoucher;
                        frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                        frmviewer.intNarration = 1;
                        frmviewer.intSummDetails = 1;
                        frmviewer.intSP = mintSp;
                        frmviewer.strFdate = "";
                        frmviewer.strBranchID = "";
                        frmviewer.strHeading = "Receipt Voucher";
                        frmviewer.intVtype = mintVType;
                        frmviewer.Show();
                    }

                }
                else if ((mintVType == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER) && mintSp == 0)
                {
                    JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.AccountsVoucher;
                    frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                    frmviewer.intNarration = 1;
                    frmviewer.intSummDetails = 1;
                    frmviewer.strFdate = "";
                    frmviewer.strBranchID = "";
                    frmviewer.strHeading = "Journal Voucher";
                    frmviewer.intVtype = mintVType;
                    frmviewer.Show();
                }
                else if ((mintVType == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER) && mintSp == 1)
                {
                    string  strFPrevius =  Utility.FirstDayOfMonth( Convert.ToDateTime(DG.CurrentRow.Cells[3].Value.ToString()).AddMonths (-1)).ToString("dd-MM-yyyy");
                    string strTPrevius = Utility.LastDayOfMonth(Convert.ToDateTime(DG.CurrentRow.Cells[3].Value.ToString()).AddMonths (-1)).ToString("dd-MM-yyyy");
                    string strPMonthID = Utility.LastDayOfMonth(Convert.ToDateTime(DG.CurrentRow.Cells[3].Value.ToString()).AddMonths(-1)).ToString("MMMyy");
                    JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.JVSP;
                    frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                    frmviewer.intNarration = 1;
                    frmviewer.intSummDetails = 1;
                    frmviewer.strFdate = "";
                    frmviewer.strBranchID = "";
                    frmviewer.strPMonthID = strPMonthID;
                    frmviewer.strFdate = strFPrevius;
                    frmviewer.strTdate = strTPrevius;
                    frmviewer.strHeading = "MPO Commission Voucher";
                    frmviewer.intVtype = mintVType;
                    frmviewer.Show();
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER)
                {
                    JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.AccountsVoucher;
                    frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                    frmviewer.intNarration = 1;
                    frmviewer.intSummDetails = 1;
                    frmviewer.strFdate = "";
                    frmviewer.strBranchID = "";
                    frmviewer.strHeading = "Contra Voucher";
                    frmviewer.intVtype = mintVType;
                    frmviewer.Show();
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
                {

                    JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNoReturn;
                    frmviewer.strLedgerName = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                    frmviewer.strFdate = "";
                    frmviewer.intMode = mintVType;
                    frmviewer.strString2 = "Sales Return";
                    frmviewer.Show();
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_ORDER)
                {

                    JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNo;
                    frmviewer.strLedgerName = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                    frmviewer.strFdate = "";
                    frmviewer.intMode = mintVType;
                    frmviewer.strString2 = "Sales Order";
                    frmviewer.Show();
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_RETURN)
                {

                    JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNo;
                    frmviewer.strLedgerName = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                    frmviewer.strFdate = "";
                    frmviewer.intMode = mintVType;
                    frmviewer.strString2 = "Purchase Return";
                    frmviewer.Show();
                }

            }
            if (e.ColumnIndex == 16)
            {
                if (mintSp == 0)
                {
                    JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.AccountsVoucherMR;
                    frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                    frmviewer.intNarration = 1;
                    frmviewer.intSummDetails = 1;
                    frmviewer.strFdate = "";
                    frmviewer.strBranchID = "";
                    frmviewer.strHeading = "Money Receipt";
                    frmviewer.intVtype = mintVType;
                    frmviewer.Show();
                }
                else
                {
                    JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.DoctorsReceipt;
                    frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                    frmviewer.intNarration = 1;
                    frmviewer.intSummDetails = 1;
                    frmviewer.strFdate = "";
                    frmviewer.strBranchID = "";
                    frmviewer.strHeading = "Money Receipt";
                    frmviewer.intVtype = mintVType;
                    frmviewer.Show();
                }

            }
            if (e.ColumnIndex == 17)
            {
                string strFPrevius = Utility.FirstDayOfMonth(Convert.ToDateTime(DG.CurrentRow.Cells[3].Value.ToString()).AddMonths(-1)).ToString("dd-MM-yyyy");
                string strTPrevius = Utility.LastDayOfMonth(Convert.ToDateTime(DG.CurrentRow.Cells[3].Value.ToString()).AddMonths(-1)).ToString("dd-MM-yyyy");
                string strPMonthID= Utility.LastDayOfMonth(Convert.ToDateTime(DG.CurrentRow.Cells[3].Value.ToString()).AddMonths(-1)).ToString("MMMyy");
                if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
                {
                    mDirectPrintSI("", "", "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'", "Sales Invoice List");
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
                {
                    mDirectPrintSalesChallan(mintVType, "", "", DG.CurrentRow.Cells[1].Value.ToString(), "Sales Chalan", 3);
                }

                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
                {
                    mDirectPrintSalesChallan(mintVType, "", "", "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'", "Sales Sample (Individual)", mintVType);
                }

                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE)
                {
                    mDirectPrintPurchaseInvoice("Purchase Invoice List", "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'", mintVType, "");
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER)
                {
                    mDirectPrint("", "", mintVType, 1, DG.CurrentRow.Cells[1].Value.ToString(), "", 0, "Payment Voucher", 1, "", "", strPMonthID);
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER)
                {
                    if (mintVType == 0)
                    {
                        mDirectPrint("", "", mintVType, 1, DG.CurrentRow.Cells[1].Value.ToString(), "", 0, "Receipt Voucher", 1, "", "", strPMonthID);
                    }
                    else
                    {
                        mDirectPrint("", "", mintVType, 1, DG.CurrentRow.Cells[1].Value.ToString(), "", 0, "Receipt Voucher", 1, "", "", strPMonthID);
                    }

                }
                else if ((mintVType == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER) && mintSp == 0)
                {
                    mDirectPrint("", "", mintVType, 1, DG.CurrentRow.Cells[1].Value.ToString(), "", 0, "Journal Voucher", 1, "", "", strPMonthID);
                }
                else if ((mintVType == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER) && mintSp == 1)
                {
                    mDirectPrint("", "", mintVType, 1, DG.CurrentRow.Cells[1].Value.ToString(), "", 1, "MPO Commission Voucher", 1,strFPrevius ,strTPrevius,strPMonthID);
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER)
                {
                    mDirectPrint("", "", mintVType, 1, DG.CurrentRow.Cells[1].Value.ToString(), "", 0, "Contra Voucher", 1, "", "", strPMonthID);
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
                {

                    mDirectPrintReturn("Sales Return", DG.CurrentRow.Cells[1].Value.ToString(), mintVType, "");
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_ORDER)
                {
                    mDirectPrintReturn("Sales Order", DG.CurrentRow.Cells[1].Value.ToString(), mintVType, "");
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_RETURN)
                {
                    mDirectPrintReturn("Purchase Return", DG.CurrentRow.Cells[1].Value.ToString(), mintVType, "");
                }

            }

        }
        #region "GetDirectPrint"
        private void mDirectPrintReturn(string strString2, string strLedgerName, int intMode, string strSelction)
        {
            ReportDocument rpt1;
            int milliseconds = 4000;
            rptIReturnnvoice rptreturnInvoice = new rptIReturnnvoice();
            rpt1 = (ReportDocument)rptreturnInvoice;
            this.secondParameter = "";
            this.reportTitle = strString2;
            rpt1.SetDataSource(orpt.mGetVoucherReportRefNo(strComID, strLedgerName, "", intMode).ToList());
            rpt1.Subreports[0].SetDataSource(orpt.mGetVoucherAddless(strComID, strLedgerName, strSelction).ToList());
            //crystalReportViewer1.ReportSource = rpt1;
            InitialiseLabels(rpt1);
            //int intSuppress = 0;
            rpt1.SetParameterValue("intSuppress", 0);
            rpt1.SetParameterValue("ComName", Utility.gstrCompanyName);
            ShowReport(rpt1, true, "");
            Thread.Sleep(milliseconds);
        }
        private void mDirectPrintPurchaseInvoice(string strString2, string strLedgerName, int intMode, string strSelction)
        {
            ReportDocument rpt1;
            int milliseconds = 4000;
            rptInvoice rptInvoice = new rptInvoice();
            rpt1 = (ReportDocument)rptInvoice;
            this.secondParameter = "";

            this.reportTitle = strString2;
            rpt1.SetDataSource(orpt.mGetVoucherReportRefNo(strComID, strLedgerName, "", intMode).ToList());
            rpt1.Subreports[0].SetDataSource(orpt.mGetVoucherAddless(strComID, strLedgerName, strSelction).ToList());
            //crystalReportViewer1.ReportSource = rpt1;
            InitialiseLabels(rpt1);
            int intSuppress = 0;
            if (strString2 == "Purchase Invoice ")
            {
                intSuppress = 0;
                rpt1.SetParameterValue("intSuppress", intSuppress);
            }
            else
            {
                rpt1.SetParameterValue("intSuppress", 1);
            }
            rpt1.SetParameterValue("ComName", Utility.gstrCompanyName);

            ShowReport(rpt1, true, "");
            Thread.Sleep(milliseconds);
        }
        private void mDirectPrintSalesChallan(int intvType, string strFdate, string strTdate, string strLedgerName, string strString2, int intMode)
        {
            ReportDocument rpt1;
            int milliseconds = 4000;
            rptVoucher_Sales_Chalan_Voucher_Det_Sum rptVoucherSalesChalanAllSumm = new rptVoucher_Sales_Chalan_Voucher_Det_Sum();
            rpt1 = (ReportDocument)rptVoucherSalesChalanAllSumm;
            this.reportTitle = strString2;
            if (strFdate != "")
            {
                this.secondParameter = strFdate + " to " + strTdate;
            }
            else
            {
                this.secondParameter = "";
            }
            string strAgnstRef = Utility.mGetAgstRefNo(strComID, strLedgerName.Replace("'", "''"));
            InitialiseLabels(rpt1);
            rpt1.SetDataSource(objWoIS.mGetVoucherSalesChalan(strComID, intvType, strFdate, strTdate, strLedgerName, strString2, intMode).ToList());
            //crystalReportViewer1.ReportSource = rpt1;
            rpt1.SetParameterValue("AGNSR_REF_NO", strAgnstRef);
            rpt1.SetParameterValue("ComName", Utility.gstrCompanyName);
            //ShowReport(rpt1, true, "");
            PrinterSettings settings = new PrinterSettings();
            string defaultPrinterName = settings.PrinterName;
            //MessageBox.Show("Start");=
            rpt1.PrintOptions.PrinterName = defaultPrinterName;
            rpt1.PrintToPrinter(1, true, 0, 0);
            Thread.Sleep(milliseconds);
        }
        private void mDirectPrintSI(string strFdate, string strTdate, string strString, string strString2)
        {
            ReportDocument rpt1;
            int milliseconds = 4000;
            rptInvoice_view VouchearVouNoListReport = new rptInvoice_view();
            rpt1 = (ReportDocument)VouchearVouNoListReport;


            if (strFdate != "")
            {
                this.secondParameter = strFdate + " to " + strTdate;
            }
            else
            {
                this.secondParameter = "";
            }
            this.reportTitle = strString2;
            rpt1.SetDataSource(orpt.mGetSalesInvoiceReportPriview(strComID, strString).ToList());
            //rpt1.Subreports[0].SetDataSource(orpt.mGetVoucherAddless(strComID, strLedgerName, strSelction).ToList());
            //crystalReportViewer1.ReportSource = rpt1;
            InitialiseLabels(rpt1);
            //ShowReport(rpt1, true, "");
            PrinterSettings settings = new PrinterSettings();
            string defaultPrinterName = settings.PrinterName;
            //MessageBox.Show("Start");=
            rpt1.PrintOptions.PrinterName = defaultPrinterName;
            rpt1.PrintToPrinter(1, true, 0, 0);
            Thread.Sleep(milliseconds);
        }
        private void mDirectPrint(string strFdate, string strTdate, int intVtype, int intSummDetails, string strString, string strBranchID, 
                                    int intSP, string strHeading, int intNarration, string strPFDate, string strPTDate,string strPMonthID)
        {
            string Header1 = "", Header2 = "", Header3 = "", Header4 = "", Header5 = "";
            double dblPasesize = 0;
            try
            {

                ReportDocument rpt1;
                List<RAudit> otheading = orptCnn.mGetHeader(strComID, intVtype).ToList();
                if (otheading.Count > 0)
                {
                    foreach (RAudit oo in otheading)
                    {
                        Header1 = oo.strHeader1;
                        Header2 = oo.strHeader2;
                        Header3 = oo.strHeader3;
                        Header4 = oo.strHeader4;
                        Header5 = oo.strHeader5;
                        dblPasesize = oo.dblPazeSize;
                    }

                    if (intSP == 0)
                    {
                        if (dblPasesize == 0)
                        {
                            rptAccountsVoucherN rptAccountsVoucher = new rptAccountsVoucherN();
                            rpt1 = (ReportDocument)rptAccountsVoucher;
                        }
                        else
                        {
                            rptAccountsVoucherNHalf rptAccountsVoucher = new rptAccountsVoucherNHalf();
                            rpt1 = (ReportDocument)rptAccountsVoucher;
                        }
                    }
                    else
                    {
                        rptAccountsVoucherSP rptAccountsVoucherSumm = new rptAccountsVoucherSP();
                        rpt1 = (ReportDocument)rptAccountsVoucherSumm;
                    }
                    if (intSP == 0)
                    {
                        rpt1.SetDataSource(objWoIS.mGetAccountsvoucher(strComID, strFdate, strTdate, intVtype, intSummDetails, strString, strBranchID, intSP).ToList());
                    }
                    else
                    {
                        rpt1.SetDataSource(objWoIS.mGetAccountsvoucherSP(strComID, intVtype, intSummDetails, strString, strBranchID,strPFDate,strPTDate,strPMonthID).ToList());
                    }

                    if (strHeading != "")
                    {
                        this.reportTitle = strHeading;
                    }
                    else
                    {
                        this.reportTitle = "";
                    }

                    InitialiseLabels(rpt1);
                    Thread.Sleep(2000);
                    //crystalReportViewer1.ReportSource = rpt1;
                    if (intNarration == 1)
                    {
                        rpt1.SetParameterValue("intSuppress", 0);
                    }
                    else
                    {
                        rpt1.SetParameterValue("intSuppress", 1);
                    }
                    rpt1.SetParameterValue("strHeaderr1", Header1);
                    rpt1.SetParameterValue("strHeaderr2", Header2);
                    rpt1.SetParameterValue("strHeaderr3", Header3);
                    rpt1.SetParameterValue("strHeaderr4", Header4);
                    ShowReport(rpt1, true, "");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ShowReport(CrystalDecisions.CrystalReports.Engine.ReportDocument rpt, Boolean isDirectPrint, string strReportTitle = "")
        {
            try
            {
                if (isDirectPrint == true)
                {
                    //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    //rpt.PrintToPrinter(1, false, 0, 0);
                    PrinterSettings settings = new PrinterSettings();
                    string defaultPrinterName = settings.PrinterName;
                    //MessageBox.Show("Start");=
                    rpt.PrintOptions.PrinterName = defaultPrinterName;
                    rpt.PrintToPrinter(0, true, 0, 0);
                    
                }
                else
                {
                    //InitialiseParameterLabels(rpt, strReportTitle);
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void InitialiseLabels(ReportDocument rpt)
        {
            try
            {

                ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyName"]).Text = Utility.gstrCompanyName;
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyAddress1"]).Text = Utility.gstrCompanyAddress1;
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyAddress2"]).Text = Utility.gstrCompanyAddress2;
                //((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyEmail"]).Text = Utility.gstrEmail;
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyName2"]).Text = Utility.gstrCompanyName;
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter2"]).Text = Utility.gstrCompanyAddress1;

                ((TextObject)rpt.ReportDefinition.ReportObjects["txtIT"]).Text = Utility.gstrMsg;
                //((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyWeb"]).Text = Utility.gstrWeb;
                if (ReportTitle != "")
                {
                    ((TextObject)rpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.ReportTitle;
                    if (ReportSecondParameter != "")
                    {
                        ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter2"]).Text = this.ReportTitle + " From " + '-' + this.secondParameter;
                    }
                }
                if (ReportSecondParameter != "")
                {
                    ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter"]).Text = this.secondParameter;
                }
                else
                {
                    rpt.ReportDefinition.ReportObjects["txtSecondParameter"].ObjectFormat.EnableSuppress = true;
                }
                if (ReportHeading != "")
                {
                    ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyPhone"]).Text = ReportHeading;
                }

            }
            catch( Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }
        #endregion
        private List<AccountsVoucher> GetSelectedItem(int i = 0)
        {
            int introw = 0;
            List<AccountsVoucher> items = new List<AccountsVoucher>();
            try
            {

                AccountsVoucher itm = new AccountsVoucher();
                itm.strVoucherNo = DG.CurrentRow.Cells[1].Value.ToString();
                itm.strPreserveSQL = DG.CurrentRow.Cells[15].Value.ToString();
                if (i == 0)
                {
                    itm.strVoucherNo = DG.CurrentRow.Cells[1].Value.ToString();
                    itm.strPreserveSQL = DG.CurrentRow.Cells[15].Value.ToString();
                }
                else
                {
                    introw = DG.SelectedCells[0].RowIndex - 1;
                    if (introw != -1)
                    {
                        //itm.lngSlno = Convert.ToInt64(DG.Rows[introw].Cells[0].Value.ToString());
                        //itm.intDefaultGroup = Convert.ToInt32(DG.Rows[introw].Cells[4].Value);
                        itm.strVoucherNo = DG.Rows[introw].Cells[1].Value.ToString();
                        itm.strPreserveSQL = DG.CurrentRow.Cells[15].Value.ToString();
                    }

                }
                items.Add(itm);
                return items;
            }
            catch (Exception ex)
            {
                return items;
            }
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

        #region "Preview"
        private void btnpreview_Click(object sender, EventArgs e)
        {
            if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
            {
                JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNoListReport;
                frmviewer.strString = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "' ";
                frmviewer.strString2 = "Sales Invoice List";
                frmviewer.intSuppress = 1;
                frmviewer.intMode = mintVType;
                frmviewer.Show();
            }
            else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
            {
                JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VoucherSalesChalan;
                frmviewer.strLedgerName = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "' ";
                frmviewer.intSuppress = 1;
                frmviewer.intvType = mintVType;
                frmviewer.strFdate = "";
                frmviewer.strTdate = "";
                frmviewer.intMode = 3;
                frmviewer.strString2 = "Sales Chalan";
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
            }

            else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
            {
                JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.Vouchear;
                frmviewer.strLedgerName = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "' ";
                frmviewer.intSuppress = 1;
                frmviewer.intvType = mintVType;
                frmviewer.intMode = mintVType;
                frmviewer.reportTitle2 = "A";
                frmviewer.strString2 = "Sales Sample (Individual)";
                frmviewer.strSelction = "Sum";
                frmviewer.Show();
            }


            else if (mintVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE)
            {
                JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNo;
                frmviewer.strLedgerName = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                frmviewer.strString2 = "Purchase Invoice List";
                frmviewer.intSuppress = 1;
                frmviewer.intMode = mintVType;
                frmviewer.Show();
            }
            else if (mintVType == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER)
            {
                JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.AccountsVoucher;
                frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                frmviewer.intNarration = 1;
                frmviewer.intSummDetails = 1;
                frmviewer.strFdate = "";
                frmviewer.strBranchID = "";
                frmviewer.strHeading = "Payment Voucher";
                frmviewer.intVtype = mintVType;
                frmviewer.Show();
            }
            else if (mintVType == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER)
            {
                if (mintVType == 0)
                {
                    JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.AccountsVoucher;
                    frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                    frmviewer.intNarration = 1;
                    frmviewer.intSummDetails = 1;
                    frmviewer.strFdate = "";
                    frmviewer.strBranchID = "";
                    frmviewer.strHeading = "Receipt Voucher";
                    frmviewer.intVtype = mintVType;
                    frmviewer.Show();
                }
                else
                {
                    JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.AccountsVoucher;
                    frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                    frmviewer.intNarration = 1;
                    frmviewer.intSummDetails = 1;
                    frmviewer.intSP = mintSp;
                    frmviewer.strFdate = "";
                    frmviewer.strBranchID = "";
                    frmviewer.strHeading = "Receipt Voucher";
                    frmviewer.intVtype = mintVType;
                    frmviewer.Show();
                }

            }
            else if ((mintVType == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER) && mintSp == 0)
            {
                JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.AccountsVoucher;
                frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                frmviewer.intNarration = 1;
                frmviewer.intSummDetails = 1;
                frmviewer.strFdate = "";
                frmviewer.strBranchID = "";
                frmviewer.strHeading = "Journal Voucher";
                frmviewer.intVtype = mintVType;
                frmviewer.Show();
            }
            else if ((mintVType == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER) && mintSp == 1)
            {
                JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.JVSP;
                frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                frmviewer.intNarration = 1;
                frmviewer.intSummDetails = 1;
                frmviewer.strFdate = "";
                frmviewer.strBranchID = "";
                frmviewer.strHeading = "MPO Commission Voucher";
                frmviewer.intVtype = mintVType;
                frmviewer.Show();
            }
            else if (mintVType == (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER)
            {
                JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Accms.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Accms.ViewerSelector.AccountsVoucher;
                frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                frmviewer.intNarration = 1;
                frmviewer.intSummDetails = 1;
                frmviewer.strFdate = "";
                frmviewer.strBranchID = "";
                frmviewer.strHeading = "Contra Voucher";
                frmviewer.intVtype = mintVType;
                frmviewer.Show();
            }
            else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
            {

                JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNoReturn;
                frmviewer.strLedgerName = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                frmviewer.strFdate = "";
                frmviewer.intMode = mintVType;
                frmviewer.strString2 = "Sales Return";
                frmviewer.Show();
            }
            else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_ORDER)
            {

                JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNo;
                frmviewer.strLedgerName = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                frmviewer.strFdate = "";
                frmviewer.intMode = mintVType;
                frmviewer.strString2 = "Sales Order";
                frmviewer.Show();
            }
            else if (mintVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_RETURN)
            {

                JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNo;
                frmviewer.strLedgerName = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                frmviewer.strFdate = "";
                frmviewer.intMode = mintVType;
                frmviewer.strString2 = "Purchase Return";
                frmviewer.Show();
            }
        }
        #endregion
        #region "Direct Print"
        private void btnDPrint_Click(object sender, EventArgs e)
        {
            string strString = "";
            int intRow = 0;
            try
            {

                if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_INVOICE)
                {
                    try
                    {
                        foreach (DataGridViewRow row in DG.SelectedRows)
                        {
                            //MessageBox.Show("Index " + row.Index.ToString());
                            int selectedCount = row.Index;
                            mDirectPrintSI("", "", "'" + DG.Rows[selectedCount].Cells[1].Value.ToString() + "'", "Sales Invoice List");
                            DG.Rows[selectedCount].Cells[1].Selected = false;
                        }
                        DG.CurrentRow.Cells[0].Selected = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
                {
                    try
                    {
                        foreach (DataGridViewRow row in DG.SelectedRows)
                        {
                            //MessageBox.Show("Index " + row.Index.ToString());
                            int selectedCount = row.Index;
                            mDirectPrintSalesChallan(mintVType, "", "", DG.Rows[selectedCount].Cells[1].Value.ToString(), "Sales Chalan", 3);
                            DG.Rows[selectedCount].Cells[1].Selected = false;
                        }
                        DG.CurrentRow.Cells[0].Selected = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }

                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_CHALLAN)
                {
                    try
                    {
                        foreach (DataGridViewRow row in DG.SelectedRows)
                        {
                            //MessageBox.Show("Index " + row.Index.ToString());
                            int selectedCount = row.Index;
                            mDirectPrintSalesChallan(mintVType, "", "", "'" + DG.Rows[selectedCount].Cells[2].Value.ToString() + "'", "Sales Sample (Individual)", mintVType);
                            DG.Rows[selectedCount].Cells[1].Selected = false;
                        }
                        DG.CurrentRow.Cells[0].Selected = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }


                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE)
                {
                    try
                    {
                        foreach (DataGridViewRow row in DG.SelectedRows)
                        {
                            //MessageBox.Show("Index " + row.Index.ToString());
                            int selectedCount = row.Index;
                            mDirectPrintPurchaseInvoice("Purchase Invoice List", "'" + DG.Rows[selectedCount].Cells[1].Value.ToString() + "'", mintVType, "");
                            DG.Rows[selectedCount].Cells[1].Selected = false;
                        }
                        DG.CurrentRow.Cells[0].Selected = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER)
                {
                    try
                    {
                        foreach (DataGridViewRow row in DG.SelectedRows)
                        {
                            int selectedCount = row.Index;
                            mDirectPrint("", "", mintVType, 1, DG.Rows[selectedCount].Cells[1].Value.ToString(), "", 0, "Payment Voucher", 1,"","","");
                            DG.Rows[selectedCount].Cells[1].Selected = false;
                            Thread.Sleep(600);
                        }
                        DG.CurrentRow.Cells[0].Selected = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER)
                {
                    try
                    {
                        if (mintVType == 0)
                        {
                            try
                            {
                                foreach (DataGridViewRow row in DG.SelectedRows)
                                {
                                    //MessageBox.Show("Index " + row.Index.ToString());
                                    int selectedCount = row.Index;
                                    mDirectPrint("", "", mintVType, 1, DG.Rows[selectedCount].Cells[1].Value.ToString(), "", 0, "Receipt Voucher", 1,"","","");
                                    DG.Rows[selectedCount].Cells[1].Selected = false;
                                    Thread.Sleep(600);
                                }
                                DG.CurrentRow.Cells[0].Selected = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }

                        }
                        else
                        {
                            try
                            {
                                foreach (DataGridViewRow row in DG.SelectedRows)
                                {
                                    //MessageBox.Show("Index " + row.Index.ToString());
                                    int selectedCount = row.Index;
                                    mDirectPrint("", "", mintVType, 1, DG.Rows[selectedCount].Cells[1].Value.ToString(), "", 0, "Receipt Voucher", 1,"","","");
                                    DG.Rows[selectedCount].Cells[1].Selected = false;
                                    Thread.Sleep(600);
                                }
                                DG.CurrentRow.Cells[0].Selected = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else if ((mintVType == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER) && mintSp == 0)
                {
                    try
                    {
                        foreach (DataGridViewRow row in DG.SelectedRows)
                        {
                            //MessageBox.Show("Index " + row.Index.ToString());
                            int selectedCount = row.Index;
                            mDirectPrint("", "", mintVType, 1, DG.Rows[selectedCount].Cells[1].Value.ToString(), "", 0, "Journal Voucher", 1,"","","");
                            DG.Rows[selectedCount].Cells[1].Selected = false;
                            Thread.Sleep(600);
                        }
                        DG.CurrentRow.Cells[0].Selected = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else if ((mintVType == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER) && mintSp == 1)
                {
                    try
                    {
                        foreach (DataGridViewRow row in DG.SelectedRows)
                        {

                            int selectedCount = row.Index;
                            mDirectPrint("", "", mintVType, 1, DG.Rows[selectedCount].Cells[1].Value.ToString(), "", 1, "MPO Commission Voucher", 1,"","","");
                            DG.Rows[selectedCount].Cells[1].Selected = false;
                            Thread.Sleep(600);
                        }
                        DG.CurrentRow.Cells[0].Selected = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER)
                {
                    try
                    {
                        foreach (DataGridViewRow row in DG.SelectedRows)
                        {
                            int selectedCount = row.Index;
                            mDirectPrint("", "", mintVType, 1, DG.Rows[selectedCount].Cells[1].Value.ToString(), "", 0, "Contra Voucher", 1,"","","");
                            DG.Rows[selectedCount].Cells[1].Selected = false;
                            Thread.Sleep(600);
                        }
                        DG.CurrentRow.Cells[0].Selected = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_RETURN)
                {
                    try
                    {

                        foreach (DataGridViewRow row in DG.SelectedRows)
                        {
                            //MessageBox.Show("Index " + row.Index.ToString());
                            int selectedCount = row.Index;
                            mDirectPrintReturn("Sales Return", "'" + DG.Rows[selectedCount].Cells[1].Value.ToString() + "'", mintVType, "");
                            DG.Rows[selectedCount].Cells[1].Selected = false;
                        }
                        DG.CurrentRow.Cells[0].Selected = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_ORDER)
                {
                    try
                    {
                        foreach (DataGridViewRow row in DG.SelectedRows)
                        {
                            //MessageBox.Show("Index " + row.Index.ToString());
                            int selectedCount = row.Index;
                            mDirectPrintReturn("Sales Order", DG.Rows[selectedCount].Cells[1].Value.ToString(), mintVType, "");
                            DG.Rows[selectedCount].Cells[1].Selected = false;
                        }
                        DG.CurrentRow.Cells[0].Selected = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else if (mintVType == (int)Utility.VOUCHER_TYPE.vtPURCHASE_RETURN)
                {
                    try
                    {
                        foreach (DataGridViewRow row in DG.SelectedRows)
                        {
                            //MessageBox.Show("Index " + row.Index.ToString());
                            int selectedCount = row.Index;
                            mDirectPrintReturn("Purchase Return", DG.Rows[selectedCount].Cells[1].Value.ToString(), mintVType, "");
                            DG.Rows[selectedCount].Cells[1].Selected = false;
                        }
                        DG.CurrentRow.Cells[0].Selected = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        private void btnFocus_Click(object sender, EventArgs e)
        {
            DG.Select();
            DG.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (mintVType == 16)
            {
                //string strCheck = Utility.mGetCheckLedgerNamePresent(strComID, "ACC_BILL_TRAN_PROCESS", "AGST_COMP_REF_NO", "COMP_VOUCHER_TYPE", DG.CurrentRow.Cells[1].Value.ToString(),"15");
                string strCheck = Utility.mCheckChallan(strComID, DG.CurrentRow.Cells[1].Value.ToString());
                if (strCheck != "")
                {
                    if (Utility.gblnAdminPrv == true)
                    {
                        MessageBox.Show("Challan Found");
                    }
                    else
                    {
                        MessageBox.Show("Sorry!Challan Found, You cannot Edit this Voucher");
                        DG.Focus();
                        return;
                    }


                }
            }

            if (onAddAllButtonClicked != null)
                onAddAllButtonClicked(GetSelectedItem(), sender, e);
            this.Dispose();
        }

        private void DG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (mintVType == 16)
                {
                    //string strCheck = Utility.mGetCheckLedgerNamePresent(strComID, "ACC_BILL_TRAN_PROCESS", "AGST_COMP_REF_NO", "COMP_VOUCHER_TYPE", DG.CurrentRow.Cells[1].Value.ToString(),"15");
                    string strCheck = Utility.mCheckChallan(strComID, DG.CurrentRow.Cells[1].Value.ToString());
                    if (strCheck != "")
                    {
                        if (Utility.gblnAdminPrv == true)
                        {
                            MessageBox.Show("Challan Found");
                        }
                        else
                        {
                            MessageBox.Show("Sorry!Challan Found, You cannot Edit this Voucher");
                            DG.Focus();
                            return;
                        }


                    }
                }

                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(1), sender, e);
                this.Dispose();
            }
        }

       




    }
}
