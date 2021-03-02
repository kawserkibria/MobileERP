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
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    public partial class frmRptDailyCollection : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWoIS = new SPWOIS();
        private ListBox lstBranchName = new ListBox();
        private string strComID { get; set; }
        List<Invoice> ooPartyName;
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptDailyCollection()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);

            this.uctxtLedgerConfig.KeyDown += new KeyEventHandler(uctxtLedgerConfig_KeyDown);
            this.uctxtLedgerConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerConfig_KeyPress);
            this.uctxtLedgerConfig.TextChanged += new System.EventHandler(this.uctxtLedgerConfig_TextChanged);
            this.uctxtLedgerConfig.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtLedgerConfig_KeyUp);
            this.uctxtLedgerConfig.GotFocus += new System.EventHandler(this.uctxtLedgerConfig_GotFocus);
            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);
            this.radAll.Click += new System.EventHandler(this.radAll_Click);
            this.chkbDailyCollection.Click += new System.EventHandler(this.chkbDailyCollection_Click);
            this.chkBkash.Click += new System.EventHandler(this.chkBkash_Click);
            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
        }
        private void DGMr_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
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
        #region "User Deifne"
        private void uctxtLedgerConfig_KeyUp(object sender, KeyEventArgs e)
        {
         
                SearchListViewPartyName(ooPartyName, uctxtLedgerConfig.Text);
           
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
                    //if (i % 2 == 0)
                    //{
                    //    DGMr.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGMr.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void DGMr_DoubleClick(object sender, EventArgs e)
        {

            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
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
                uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                btnPrint.Focus();
            }
        }


        private void uctxtLedgerConfig_TextChanged(object sender, EventArgs e)
        {
            if (uctxtLedgerConfig.Text == "")
            {
                uctxtTerritoryCode.Text = "";
                uctxtTeritorryName.Text = "";
            }
        }
        private void uctxtLedgerConfig_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtLedgerConfig.Text == "")
                {
                    uctxtLedgerConfig.Text = "";
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        DGMr.Visible = true;
                    }

                    DGMr.Visible = false;

                    return;
                }


                if (uctxtLedgerConfig.Text != "")
                {
                    DGMr.Focus();
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = false;
                        btnPrint.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    btnPrint.Focus();
                }
            }

        }
        private void uctxtLedgerConfig_KeyDown(object sender, KeyEventArgs e)
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

            DGMr.Top = uctxtLedgerConfig.Top + 25;
            DGMr.Left = uctxtLedgerConfig.Left;
            DGMr.Width = uctxtLedgerConfig.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            return;
        }
        private void mloadParty()
        {
            int introw = 0,intstatus=0;
            DGMr.Rows.Clear();
            if (chkStatus.Checked==true)
            {
                intstatus = 1;
            }
            else
            {
                intstatus = 0;
            }

            ooPartyName = invms.mfillPartyNameNew(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName, intstatus, "","").ToList();

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
        private void uctxtLedgerConfig_GotFocus(object sender, System.EventArgs e)
        {
            
        }
        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }
        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranchName.Text;
            lstBranchName.Visible = false;
            dteFromDate.Focus();

        }
        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }
                lstBranchName.Visible = false;
                dteFromDate.Focus();

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
           
        }
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;

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
        

        private void radAll_Click(object sender, EventArgs e)
        {
            uctxtLedgerConfig.Enabled = false;
            chkStatus.Enabled = false;
            chkStatus.Checked = false;
            uctxtLedgerConfig.Text = "";
            dteFromDate.Focus();
        }

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            chkboxcommition.Visible = false;
            txtCommition.Visible = false;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");

            lstBranchName.ValueMember = "Key";
            lstBranchName.DisplayMember = "value";
            lstBranchName.DataSource = accms.mFillBranchAllNew(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
          
            
             if (strReportName == "Contract Bill")
             {
                 mloadParty();
                 lblIndividualVoucher.Visible = true;
                 uctxtLedgerConfig.Visible = true;
                 frmSelection.Visible = true;
                 frmLabel.Text = "Contract Party Bill";
             }
             else if (strReportName =="Daily Collection")
             {
                 chkbDailyCollection.Visible = true;
                 grpDailyCollection.Visible = true;
                 chkBkash.Visible = true;
                 frmLabel.Text = "Daily Collection";
             }
             else if (strReportName == "Contract Party Bill")
             {
                 mloadParty();
                 txtCommition.Visible = true;
                 chkboxcommition.Visible = true;
                 lblIndividualVoucher.Visible = true;
                 uctxtLedgerConfig.Visible = true;
                 frmSelection.Visible = true;
                 frmLabel.Text = "Contract Party Bill-1";
             }
             else
             {
                 frmLabel.Text = strReportName;
                 frmSelection.Visible = false;
                 lblIndividualVoucher.Visible = false;
                 uctxtLedgerConfig.Visible = false;
                 chkBkash.Visible = true;
             }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DateTime dteLedgerFdate, dtpfrom;
            string strBrachID = "", strBkash = "";
            int intInactive = 0, intReportStatus = 0,intStatus=0;

            if (chkBkash.Checked == true)
            {
                strBkash = "B";
            }
            else
            {
                strBkash = "";
            }
            if (cboxOnlyAccounts.Checked == true)
            {
                intReportStatus = 1;
            }
            else
            {
                intReportStatus = 0;
            }
            if (chkStatus.Checked == true)
            {
                intInactive = 1;
            }
            else
            {
                intInactive = 0;
            }
            if (grpDailyCollection.Visible)
            {
                if (optRadall.Checked)
                {
                    intStatus = 3;
                }
                else if (radActive.Checked)
                {
                    intStatus = 0;
                }
                else if (radinactive.Checked)
                {
                    intStatus = 1;
                }
            }

            if (chkboxcommition.Checked == true)
            {
                if (txtCommition.Text == "")
                {
                    MessageBox.Show("Cannot be Empty");
                    txtCommition.Focus();
                    return;
                }
            }
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Branch Name Cannot be Empty");
                uctxtBranchName.Focus();
                return;
            }
            if (uctxtLedgerConfig.Visible && radIndividual.Checked == true)
            {
                if (uctxtLedgerConfig.Text == "")
                {
                    MessageBox.Show("Party Name Cannot be Empty");
                    uctxtLedgerConfig.Focus();
                    return;
                }
            }
            strBrachID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text); ;
            if (chkbDailyCollection.Checked == true)
            {
                long lonnDays = 0;
                lonnDays = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(dteFromDate.Text), Convert.ToDateTime(dteToDate.Text));
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Maximum = (int)lonnDays+1;
                dtpfrom = Convert.ToDateTime(dteFromDate.Text);
                for (int imonth = 0; imonth <= lonnDays; imonth++)
                {
                    if (imonth < 1)
                    {
                        dteLedgerFdate = Convert.ToDateTime(dteFromDate.Text);
                        string sss = objWoIS.mInsertDayliCollectionN(strComID, Convert.ToString(dteLedgerFdate), 1,strBrachID ).ToString();
                    }
                    else
                    {
                        dteLedgerFdate = Convert.ToDateTime(dteFromDate.Value.AddDays(imonth));
                        string sss = objWoIS.mInsertDayliCollectionN(strComID, Convert.ToString(dteLedgerFdate), 0, strBrachID).ToString();
                    }
                    progressBar1.Value += 1;
                }
            }
            
            if (strReportName == "Daily Collection")
            {
                if (chkbDailyCollection.Checked == true)
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.DailyCollectionNew;
                    frmviewer.mstrBranchName = uctxtBranchName.Text;
                    frmviewer.strFdate = dteFromDate.Text;
                    frmviewer.strTdate = dteToDate.Text;
                    frmviewer.strBranchID = strBrachID;
                    frmviewer.intSP = intReportStatus;
                    frmviewer.intSummDetails = intStatus;
                    frmviewer.strHeading = "Daily Collection(Summary) ";
                    frmviewer.Show();
                }
                else
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.DailyCollection;
                    frmviewer.mstrBranchName = uctxtBranchName.Text;
                    frmviewer.strFdate = dteFromDate.Text;
                    frmviewer.strTdate = dteToDate.Text;
                    frmviewer.strBranchID = strBrachID;
                    frmviewer.intSP = intReportStatus;
                    frmviewer.intSummDetails = intStatus;
                    if (strBkash == "B")
                    {
                        frmviewer.strHeading = "Daily Collection(As Per Bkash Statement) ";
                    }
                    else
                    {
                        frmviewer.strHeading = "Daily Collection ";
                    }

                    frmviewer.strSelction = strBkash;
                    if (chkBkash.Checked == true)
                    {
                        frmviewer.intSalesColl = 1;
                    }
                    else
                    {
                        frmviewer.intSalesColl = 0;
                    }
                    frmviewer.Show();
                }
            }
            else if (strReportName == "Contract Bill")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ContactPartyBill;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strString = uctxtLedgerConfig.Text;
                frmviewer.strBranchID = strBrachID;
                frmviewer.strHeading = "Contract Party Bill ";
                frmviewer.Show();
            }
            else if (strReportName == "Contract Party Bill")
            {
                if (chkboxcommition.Checked == true)
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.commitionN;
                    frmviewer.strFdate = dteFromDate.Text;
                    frmviewer.strTdate = dteToDate.Text;
                    frmviewer.strString = uctxtLedgerConfig.Text;
                    frmviewer.strBranchID = strBrachID;
                    frmviewer.mstrBranchName = uctxtBranchName.Text;
                    frmviewer.strHeading = "Commission";
                    frmviewer.intSP = intReportStatus;
                    frmviewer.dblAmount = Convert.ToDouble(txtCommition.Text);
                    frmviewer.Show();
                }
                else
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.ContactPartyBill2;
                    frmviewer.strFdate = dteFromDate.Text;
                    frmviewer.strTdate = dteToDate.Text;
                    frmviewer.strString = uctxtLedgerConfig.Text;
                    frmviewer.strBranchID = strBrachID;
                    frmviewer.mstrBranchName = uctxtBranchName.Text;
                    frmviewer.strHeading = "Contract Party Bill(1) ";
                    frmviewer.intSP = intReportStatus;
                    frmviewer.Show();
                }
            }

        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
            uctxtLedgerConfig.Enabled = true;
            chkStatus.Enabled = true ;
            uctxtLedgerConfig.Focus();
        }

        private void chkStatus_Click(object sender, EventArgs e)
        {
            if (radIndividual.Checked)
            {
                uctxtLedgerConfig.Text = "";
                uctxtLedgerConfig.Focus();
                mloadParty();
                
            }
        }

        private void radAll_Click_1(object sender, EventArgs e)
        {

        }

        private void radIndividual_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chkbDailyCollection_Click(object sender, EventArgs e)
        {
            chkBkash.Checked = false;
        }


        private void chkBkash_Click(object sender, EventArgs e)
        {
            chkbDailyCollection.Checked = false;
        }
      

       
    }
}
