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
using JA.Modulecontrolar.JINVMS;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmSampleList : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strPreserveSQl { get; set; }
        private ListBox lstFindWhat = new ListBox();
        private ListBox lstExpression = new ListBox();
        public long lngFormPriv { get; set; }
        public delegate void AddAllClick(List<Sample> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public int mintVType { get; set; }
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
        private string strComID { get; set; }

        public frmSampleList()
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
                mFetchRecord();
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
            uctxtExpression.Text = lstExpression.Text;
            PanelSearch.Visible = false;
            mFetchRecord();
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
                        uctxtExpression.Text = lstExpression.Text;
                    }
                }
                //mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text);
                mFetchRecord();
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
            strPreserveSQl = "";
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
            else if (uctxtFindWhat.Text == "Ledger Name")
            {
                lstExpression.Visible = true;
                lstFindWhat.Visible = false;
                uctxtExpression.Visible = true;
                uctxtFromDate.Visible = false;
                uctxtToDate.Visible = false;
                lblfromDate.Visible = false;
                lblTodate.Visible = false;
                if (mintVType == (int)(Utility.VOUCHER_TYPE.vtSALES_INVOICE))
                {

                    lstExpression.ValueMember = "strLedgerName";
                    lstExpression.DisplayMember = "strLedgerName";
                    lstExpression.DataSource = accms.mFillLedgerList(strComID, (int)Utility.GR_GROUP_TYPE.grCUSTOMER).ToList();
                }
                else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE))
                {

                    lstExpression.ValueMember = "strLedgerName";
                    lstExpression.DisplayMember = "strLedgerName";
                    lstExpression.DataSource = accms.mFillLedgerList(strComID, (int)Utility.GR_GROUP_TYPE.grSUPPLIER).ToList();
                }
                else
                {
                    lstExpression.ValueMember = "strLedgerName";
                    lstExpression.DisplayMember = "strLedgerName";
                    lstExpression.DataSource = accms.mFillLedgerList(strComID, 0).ToList();
                }
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
                strPreserveSQl = "";
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
                else if (uctxtFindWhat.Text == "Ledger Name")
                {
                    lstExpression.Visible = true;
                    lstFindWhat.Visible = false;
                    uctxtExpression.Visible = true;
                    uctxtFromDate.Visible = false;
                    uctxtToDate.Visible = false;
                    lblfromDate.Visible = false;
                    lblTodate.Visible = false;
                    if (mintVType == (int)(Utility.VOUCHER_TYPE.vtSALES_INVOICE))
                    {

                        lstExpression.ValueMember = "strLedgerName";
                        lstExpression.DisplayMember = "strLedgerName";
                        lstExpression.DataSource = accms.mFillLedgerList(strComID, (int)Utility.GR_GROUP_TYPE.grCUSTOMER).ToList();
                    }
                    else if (mintVType == (int)(Utility.VOUCHER_TYPE.vtPURCHASE_INVOICE))
                    {

                        lstExpression.ValueMember = "strLedgerName";
                        lstExpression.DisplayMember = "strLedgerName";
                        lstExpression.DataSource = accms.mFillLedgerList(strComID, (int)Utility.GR_GROUP_TYPE.grSUPPLIER).ToList();
                    }
                    else
                    {
                        lstExpression.ValueMember = "strLedgerName";
                        lstExpression.DisplayMember = "strLedgerName";
                        lstExpression.DataSource = accms.mFillLedgerList(strComID, 0).ToList();
                    }

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
        private void frmAccountsVoucherList_Load(object sender, EventArgs e)
        {
            mGetConfig();
            DG.AllowUserToAddRows = false;

          
            DG.Columns.Add(Utility.Create_Grid_Column("SLNo", "SLNo", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Voucher key", "Voucher No", 120, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 110, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Trans. Date", "Trans. Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 280, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Branch Name", "Branch Name",230, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Net Amount", "Net Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
            //if ( Utility.gblngApproved)
            //{
            //    DG.Columns.Add(Utility.Create_Grid_Column("Status", "Status", 100, true, DataGridViewContentAlignment.TopLeft, true));
            //}
           
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 42, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 50, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("SQL", "SQL", 100, false, DataGridViewContentAlignment.TopLeft, true));
            mLoadFind();
            mFetchRecord();
            uctxtFromDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            uctxtToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }
        private void mLoadFind()
        {

            lstFindWhat.Items.Clear();
            lstFindWhat.Items.Add("Voucher Number");
            lstFindWhat.Items.Add("Voucher Date");
            lstFindWhat.Items.Add("Ledger Name");

        }
        private void mFetchRecord()
        {
            DG.Rows.Clear();

            List<Sample> ooVlist;
            if (strPreserveSQl == null || strPreserveSQl == "")
            {
                strPreserveSQl = "";
            }
            //ooVlist = invms.GetSampleList(mintVType, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy")).ToList();
            if (uctxtFindWhat.Text != "")
            {
                if (uctxtFindWhat.Text == "Voucher Number")
                {
                    ooVlist = invms.GetSampleList(strComID, mintVType, "", "", uctxtFindWhat.Text, uctxtExpression.Text, strPreserveSQl).ToList();
                }
                else if (uctxtFindWhat.Text == "Voucher Date")
                {
                    ooVlist = invms.GetSampleList(strComID, mintVType, uctxtFromDate.Text, uctxtToDate.Text, uctxtFindWhat.Text, "", strPreserveSQl).ToList();
                }
                else
                {
                    ooVlist = invms.GetSampleList(strComID, mintVType, uctxtFromDate.Text, uctxtToDate.Text, uctxtFindWhat.Text, uctxtExpression.Text, strPreserveSQl).ToList();
                }
            }
            else
            {
                ooVlist = invms.GetSampleList(strComID, mintVType, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.Date.ToString("dd/MM/yyyy"), "", "", strPreserveSQl).ToList();
            }
           
            if (ooVlist.Count() > 0)
            {
                int j = 0;
                foreach (Sample ovoucher in ooVlist)
                {
                    DG.Rows.Add();
                    DG[1, j].Value = ovoucher.strSampleNo;
                    DG[2, j].Value = Utility.Mid(ovoucher.strSampleNo, 6, ovoucher.strSampleNo.Length - 6);
                    DG[3, j].Value = ovoucher.strDate;
                    DG[4, j].Value = ovoucher.strMrName;
                    DG[5, j].Value = Utility.gstrGetBranchName(strComID, ovoucher.strBranchID);
                    DG[6, j].Value = ovoucher.dblAmount;

                    DG[7, j].Value = "Edit";
                    DG[8, j].Value = "Delete";
                    DG[9, j].Value = "View";
                    DG[10, j].Value = ovoucher.strPreserveSQL;
                    j += 1;

                }
                lblTotalRecord.Text = "Total Record: " + j.ToString();
                DG.AllowUserToAddRows = false;
            }
         
        }
        

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==8)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = invms.mDeleteSample(strComID, DG.CurrentRow.Cells[1].Value.ToString());
                    if (i == "Deleted...")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Sample", DG.CurrentRow.Cells[1].Value.ToString(),
                                                                    1, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                        }
                    }
                    MessageBox.Show(i.ToString());
                    mFetchRecord();
                }

            }

            if (e.ColumnIndex==7)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
            if (e.ColumnIndex == 9)
            {
                JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer();
                if (mintVType == 17)
                {
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.individualSample;
                }
                else
                {
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.intventoryVoucher;
                }
                frmviewer.strFdate = "";
                frmviewer.strString = DG.CurrentRow.Cells[1].Value.ToString();
                frmviewer.strSelction = "S";
                frmviewer.Show();
            }

        }


        private List<Sample> GetSelectedItem()
        {
            List<Sample> items = new List<Sample>();
            Sample itm = new Sample();
            itm.strSampleNo = DG.CurrentRow.Cells[1].Value.ToString();
            itm.strPreserveSQL = DG.CurrentRow.Cells[10].Value.ToString(); 
            items.Add(itm);
            return items;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PanelSearch.Visible = false;
        }
    }
}
