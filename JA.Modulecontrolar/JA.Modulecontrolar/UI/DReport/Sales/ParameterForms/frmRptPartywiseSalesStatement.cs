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
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.DReport.Sales.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    public partial class frmRptPartywiseSalesStatement : JA.Shared.UI.frmSmartFormStandard
    {       
        private ListBox lstCustomer = new ListBox();
        private ListBox lstMrName = new ListBox();
        public int lngLedgeras { get; set; }
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;
        List<Invoice> ooCustomer;
        private string strComID { get; set; }
        public frmRptPartywiseSalesStatement()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);

            this.uctxtCustomer.KeyDown += new KeyEventHandler(uctxtCustomer_KeyDown);
            this.uctxtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCustomer_KeyPress);
            this.uctxtCustomer.TextChanged += new System.EventHandler(this.uctxtCustomer_TextChanged);
            this.lstCustomer.DoubleClick += new System.EventHandler(this.lstCustomer_DoubleClick);
            this.uctxtCustomer.GotFocus += new System.EventHandler(this.uctxtCustomer_GotFocus);
            this.DGcustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGcustomer_KeyPress);
            this.DGcustomer.DoubleClick += new System.EventHandler(this.DGcustomer_DoubleClick);
            this.DGcustomer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGcustomer_CellFormatting);
            
            this.uctxtMrName.GotFocus += new System.EventHandler(this.uctxtMrName_GotFocus);
            this.uctxtMrName.KeyDown += new KeyEventHandler(uctxtMrName_KeyDown);
            this.uctxtMrName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMrName_KeyPress);
            this.lstMrName.DoubleClick += new System.EventHandler(this.lstMrName_DoubleClick);
            this.uctxtMrName.TextChanged += new System.EventHandler(this.uctxtMrName_TextChanged);
            this.uctxtMrName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtMrName_KeyUp);

            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);

            Utility.CreateListBox(lstMrName, pnlMain, uctxtMrName, 0);
            Utility.CreateListBox(lstCustomer, pnlMain, uctxtCustomer);

        }

        #region "User Deifne"
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

        private void DGMr_DoubleClick(object sender, EventArgs e)
        {

            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                btnPrint.Focus();
            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                btnPrint.Focus();
            }
        }
        private void uctxtCustomer_TextChanged(object sender, EventArgs e)
        {

            if (uctxtCustomer.Text == "")
            {
                txtCustomerCode.Text = "";
                txtHomoeoHall.Text = "";
                txtCustomerAddress.Text = "";
            }
        }

        private void lstCustomer_DoubleClick(object sender, EventArgs e)
        {
            //uctxtCustomer.Text = lstCustomer.Text;
            string[] words = lstCustomer.Text.Split('~');
            foreach (string word in words)
            {
                if (words[0].ToString() != Utility.gcEND_OF_LIST)
                {
                    txtCustomerCode.Text = words[0].ToString();
                    uctxtCustomer.Text = words[1].ToString();
                    txtHomoeoHall.Text = words[2].ToString();
                    txtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
                }
                else
                {
                    uctxtCustomer.Text = Utility.gcEND_OF_LIST;
                }
            }
            dteFromDate.Focus();
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
                    dteFromDate.Focus();

                    return;
                }
                else
                {
                    if (DGcustomer.Rows.Count > 0)
                    {
                        int i = 0;

                        txtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                        uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                        txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                        txtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
                        DGcustomer.Visible = false;
                    }
                    dteFromDate.Focus();
                }
            }
         
        }
        private void uctxtCustomer_KeyDown(object sender, KeyEventArgs e)
        {

            DGcustomer.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                DGcustomer.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DGcustomer.Focus();
            }
            if (chePartySelction.Checked)
            {
                SearchListViewCustomer(ooCustomer, uctxtCustomer.Text);
            }
            return;
        }
        private void uctxtCustomer_GotFocus(object sender, System.EventArgs e)
        {

            DGcustomer.Top = uctxtCustomer.Top + 25;
            DGcustomer.Left = uctxtCustomer.Left;
            DGcustomer.Width = uctxtCustomer.Width;
            DGcustomer.Height = 200;
            DGcustomer.BringToFront();
            DGcustomer.Visible = true;
            DGcustomer.AllowUserToAddRows = false;
           mloadCustomer();
        }
        private void uctxtMrName_GotFocus(object sender, System.EventArgs e)
        {

            if (radIndividual.Checked)
            {
                mloadParty();
            }
            else
            {

            }
        }
        private void mloadParty()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName,0,"").ToList();

            if (ooPartyName.Count > 0)
            {

                foreach (Invoice ogrp in ooPartyName)
                {
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = true;
                    DGMr.Columns[0].Visible = true;
                    DGMr[0, introw].Value = ogrp.strTeritorryCode;
                    DGMr[1, introw].Value = ogrp.strTeritorryName;
                    DGMr[2, introw].Value = ogrp.strLedgerName;
                    DGMr[3, introw].Value = ogrp.strMereString;
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }
        private void uctxtMrName_KeyUp(object sender, KeyEventArgs e)
        {
            if (radIndividual.Checked)
            {
                SearchListViewPartyName(ooPartyName, uctxtMrName.Text);
            }
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
        private void lstMrName_DoubleClick(object sender, EventArgs e)
        {
            uctxtMrName.Text = lstMrName.Text;
            lstMrName.Visible = false;
            btnPrint.Focus();
        }
        private void uctxtMrName_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {


                if (uctxtMrName.Text == "")
                {
                    uctxtMrName.Text = "";
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        DGMr.Visible = true;
                    }

                    DGMr.Visible = false;

                    return;
                }
                if (uctxtMrName.Text != "")
                {
                    DGMr.Focus();
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = false;

                        if (chePartySelction.Checked == true)
                        {
                            uctxtCustomer.Focus();
                        }
                        else
                        {
                            dteFromDate.Focus();
                        }
                      
                         
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    if (chePartySelction.Checked == true)
                    {
                        uctxtCustomer.Focus();
                    }
                    else
                    {
                        dteFromDate.Focus();
                    }
                }
            }
   

        }
        private void uctxtMrName_TextChanged(object sender, EventArgs e)
        {
            lstMrName.SelectedIndex = lstMrName.FindString(uctxtMrName.Text);
        }
        private void uctxtMrName_KeyDown(object sender, KeyEventArgs e)
        {

            DGMr.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                DGMr.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DGMr.Focus();
            }


            return;
        }
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            uctxtMrName.Visible = false;
        }
        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteToDate.Focus();
            }
        }

        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnPrint.Focus();
            }
       
        }             
        #endregion
        private void mLaodItem()
        {                 
        }
        private void SearchListViewCustomer(IEnumerable<Invoice> tests, string searchString = "")
        {
            IEnumerable<Invoice> query;
            query = tests;
            if (searchString != "")
            {
                query = tests.Where(x => x.strMereString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }

            DGcustomer.Rows.Clear();
            int i = 0;
            try
            {
                foreach (Invoice tran in query)
                {

                    DGcustomer.Rows.Add();
                    DGcustomer[0, i].Value = tran.strTeritorryCode;
                    DGcustomer[1, i].Value = tran.strLedgerName;
                    DGcustomer[2, i].Value = tran.strTeritorryName;
                    DGcustomer[3, i].Value = tran.strMereString;
                    i += 1;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            lblMpoName.Visible = false;
            uctxtMrName.Visible = false;
            lstMrName.Visible = false;  
            lstCustomer.Visible = false;
            visiblefalse();
            //lstMedicalRep.Visible = false;
            lstCustomer.DisplayMember = "value";
            lstCustomer.ValueMember = "Key";
            lstCustomer.DataSource = new BindingSource(invms.mFillSalesRepLedger(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP), null);
            lstCustomer.SelectedIndex = lstCustomer.FindString(uctxtCustomer.Text);
            //int year = DateTime.Now.Year;
            //int Month = DateTime.Now.Month;
            //int Day = DateTime.Now.Day;
            //DateTime firstDay = new DateTime(year, Month, 1);
            //dteFromDate.Text = firstDay.ToString();
            //dteToDate.Text = dteFromDate.Text;
            //dteToDate.Text = firstDay.AddMonths(1).AddDays(-1).ToString();
            dteFromDate.Select();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if ((radIndividual.Checked == true) && (chePartySelction.Checked == true))
            {
                if (dteFromDate.Value > dteToDate.Value)
                {
                    MessageBox.Show("Please Check Date.");
                    return;
                }

                if (uctxtMrName.Text == "")
                {
                    MessageBox.Show("Please Select Ledger Name.");
                    return;
                }
                if (uctxtCustomer.Text == "")
                {
                    MessageBox.Show("Please Select Party Name.");
                    return;
                }
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseS;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strString = uctxtMrName.Text;
                frmviewer.strSelction = uctxtCustomer.Text;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;

            }
            if (radIndividual.Checked == true)
            {
                if (uctxtMrName.Text == "")
                {
                    MessageBox.Show("Please Select Ledger Name.");
                    return;
                }
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseS;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strString = uctxtMrName.Text;
                frmviewer.strSelction = uctxtCustomer.Text;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }

            if (radAll.Checked == true)
            {

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.PartyWiseS;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strString = "";
                frmviewer.reportTitle2 = "A";
                frmviewer.strSelction = uctxtCustomer.Text;
                frmviewer.Show();

                return;
            }
        }
        private void radAll_MouseClick(object sender, MouseEventArgs e)
        {
        
            lstCustomer.Visible = false;       
            visiblefalse();
            dteFromDate.Select();
            lblMpoName.Visible = false;
            uctxtMrName.Visible = false;
            lstMrName.Visible = false;
            DGMr.Visible = false;
            DGcustomer.Visible = false;
        }
        private void visiblefalse()
        {

            lblMpoName.Visible = false;
            uctxtMrName.Visible = false;
            lblParty.Visible = false;
            uctxtCustomer.Visible = false;
            chePartySelction.Visible = false;
        }
        private void visibletrue()
        {

            lblMpoName.Visible = true;
            uctxtMrName.Visible = true;
            lblParty.Visible = true;
            uctxtCustomer.Visible = true;
            chePartySelction.Visible = true;
        }

        private void mloadCustomer()
        {
            int introw = 0;
            DGcustomer.Rows.Clear();

            ooCustomer = invms.mFillSalesRepFromMPoNew1(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP, uctxtMrName.Text).ToList();

            if (ooCustomer.Count > 0)
            {

                foreach (Invoice ogrp in ooCustomer)
                {
                    DGcustomer.Rows.Add();
                    DGcustomer[0, introw].Value = ogrp.strTeritorryCode;
                    DGcustomer[1, introw].Value = ogrp.strLedgerName;
                    DGcustomer[2, introw].Value = ogrp.strTeritorryName;
                    DGcustomer[3, introw].Value = ogrp.strMereString;
                    introw += 1;
                }

                DGcustomer.AllowUserToAddRows = false;
            }
        }
        private void DGcustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //uctxtPartyName.Text = Utility.GetDgValue(DGMr, uctxtPartyName, 0);
                int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
                txtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                txtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
                DGcustomer.Visible = false;
                dteFromDate.Focus();
            }
        }
        private void DGcustomer_DoubleClick(object sender, EventArgs e)
        {
            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
                txtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                txtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
                DGcustomer.Visible = false;
                dteFromDate.Focus();


            }
        }


        private void radIndividual_Click(object sender, EventArgs e)
        {
            chePartySelction.Visible = true;
            uctxtMrName.Text = "";
            chePartySelction.Checked = false;
            lblMpoName.Visible = true;
            uctxtMrName.Visible = true;
            lstMrName.Visible = false;
            uctxtMrName.Focus();
            DGMr.Top = uctxtMrName.Top + 25;
            DGMr.Left = uctxtMrName.Left;
            DGMr.Width = uctxtMrName.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.Visible = true;
            DGMr.AllowUserToAddRows = false;
        }

        private void chePartySelction_Click(object sender, EventArgs e)
        {
            if (chePartySelction.Checked == true)
            {
                lblParty.Visible = true;
                uctxtCustomer.Visible = true;
                uctxtCustomer.Focus();
            }
            else
            {
                DGcustomer.Visible = false;
                lblParty.Visible = false;
                uctxtCustomer.Visible = false;
                uctxtCustomer.Text = "";

            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

      
    }
}
