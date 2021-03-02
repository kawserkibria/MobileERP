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
    public partial class frmRptSalesInvoice : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();

        List<AccountdGroup> oogrp;
        List<Invoice> ooCustomer;
        private string strComID { get; set; }
        public frmRptSalesInvoice()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.uctxtCustomer.KeyDown += new KeyEventHandler(uctxtCustomer_KeyDown);
            this.uctxtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCustomer_KeyPress);
            this.uctxtCustomer.TextChanged += new System.EventHandler(this.uctxtCustomer_TextChanged);
            this.uctxtCustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtCustomer_KeyUp);
            this.uctxtCustomer.GotFocus += new System.EventHandler(this.uctxtCustomer_GotFocus);
            this.DGcustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGcustomer_KeyPress);
            this.DGcustomer.DoubleClick += new System.EventHandler(this.DGcustomer_DoubleClick);
            this.DGcustomer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGcustomer_CellFormatting);
         
            //Utility.CreateListBox(lstCustomer, pnlMain, uctxtCustomer, 0);       
        }

        #region "User Deifne"
        private void DGcustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGcustomer.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGcustomer.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGcustomer.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void uctxtCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (uctxtCustomer.Text.Length > 2)
            {
                SearchListViewPartyName(ooCustomer, uctxtCustomer.Text);
            }

        }

        private void DGcustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
                txtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                txtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
                DGcustomer.Visible = false;
                btnPrint.Focus();
            }
        }
        private void DGcustomer_DoubleClick(object sender, EventArgs e)
        {
            if (radIndividual.Checked == true )
            {
                int i = Convert.ToInt16(DGcustomer.CurrentRow.Index.ToString());
                txtCustomerCode.Text = DGcustomer.Rows[i].Cells[0].Value.ToString();
                uctxtCustomer.Text = DGcustomer.Rows[i].Cells[1].Value.ToString();
                txtHomoeoHall.Text = DGcustomer.Rows[i].Cells[2].Value.ToString();
                txtCustomerAddress.Text = Utility.gGeCustomerAddress(strComID, uctxtCustomer.Text);
                DGcustomer.Visible = false;
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
                    btnPrint.Focus();

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
                    btnPrint.Focus();
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
            return;
        }
        private void uctxtCustomer_GotFocus(object sender, System.EventArgs e)
        {

            //mloadCustomer();
       
        }

        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnPrint.Focus();

            }
        }
        
        #endregion
        private void SearchListViewPartyName(IEnumerable<Invoice> tests, string searchString = "")
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
            //dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            label3.Visible = false;
            label3.Visible = false;
            uctxtCustomer.Visible = false;
            uctxtCustomer.Text = "";

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (radIndividual.Checked == true)
            {
                if (uctxtCustomer.Text == "")
                {
                    MessageBox.Show("Please Select Party Name.");
                    
                }
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.SalesInvoice;
                frmviewer.strString  = uctxtCustomer.Text;
                frmviewer.Show();
                return;
            }
            if (radAll.Checked == true)
                {             
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.SalesInvoice;
                    frmviewer.strFdate = "01/01/2018";
                    frmviewer.strTdate = "10/01/2018";
                    frmviewer.secondParameter1 = "";
                    frmviewer.strString = "";
                    frmviewer.Show();
                    return;
                }                        
        }

        private void radAll_MouseClick(object sender, MouseEventArgs e)
        {

            label3.Visible = false;
            label3.Visible = false;
            uctxtCustomer.Visible = false; 
            uctxtCustomer.Text = "";
            DGcustomer.Visible = false;
        }

        private void mloadCustomer()
        {
            int introw = 0;
            DGcustomer.Rows.Clear();

            ooCustomer = invms.mFillSalesRepFromMPoNew1(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP, "").ToList();

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

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label3.Visible = true;
            uctxtCustomer.Visible = true;
            uctxtCustomer.Text = "";
            uctxtCustomer.Focus();
            mloadCustomer();
            DGcustomer.Top = uctxtCustomer.Top + 25;
            DGcustomer.Left = uctxtCustomer.Left;
            DGcustomer.Width = uctxtCustomer.Width;
            DGcustomer.Height = 200;
            DGcustomer.BringToFront();
            DGcustomer.AllowUserToAddRows = false;
            DGcustomer.Visible = true; 
        }

        private void radIndividual_CheckedChanged(object sender, EventArgs e)
        {

        } 
      
    }
}
