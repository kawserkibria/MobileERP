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
    public partial class frmRptCollStatement : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;
        public string strReportName { get; set; }
        public string strBranchID { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptCollStatement()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);
            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);



            this.txtLess.GotFocus += new System.EventHandler(this.txtLess_GotFocus);
            this.txtLess.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLess_KeyPress);
            this.txtLess.TextChanged += new System.EventHandler(this.txtLess_TextChanged);

            this.TxtGreater.GotFocus += new System.EventHandler(this.TxtGreater_GotFocus);
            this.TxtGreater.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TxtGreater_KeyPress);
            this.TxtGreater.TextChanged += new System.EventHandler(this.TxtGreater_TextChanged);

            this.uctxtMrName.GotFocus += new System.EventHandler(this.uctxtMrName_GotFocus);
            this.uctxtMrName.KeyDown += new KeyEventHandler(uctxtMrName_KeyDown);
            this.uctxtMrName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMrName_KeyPress);
            this.lstMrName.DoubleClick += new System.EventHandler(this.lstMrName_DoubleClick);
            this.uctxtMrName.TextChanged += new System.EventHandler(this.uctxtMrName_TextChanged);
            this.uctxtMrName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtMrName_KeyUp);
            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);
            //this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch, 0);
            Utility.CreateListBox(lstMrName, pnlMain, uctxtMrName, 0);
        }

        #region "User Deifne"

        private void TxtGreater_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(TxtGreater.Text) == false)
            {
                TxtGreater.Text = "";
            }
        }
        private void TxtGreater_GotFocus(object sender, System.EventArgs e)
        {
            txtLess.Text = "";
        }

        private void TxtGreater_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteFromDate.Focus();
            }
        }
        
        private void txtLess_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(txtLess.Text) == false)
            {
                txtLess.Text = "";
            }
        }
        private void txtLess_GotFocus(object sender, System.EventArgs e)
        {
            TxtGreater.Text = "";
        }

        private void txtLess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteFromDate.Focus();
            }

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
                dteFromDate.Focus();

                
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

        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        private void uctxtBranch_GotFocus(object sender, System.EventArgs e)
        {

            lstBranch.Visible = true;

            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);


            lstBranch.Top = 184;
            lstBranch.Left = 140;
        }
        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranch.Text = lstBranch.Text;
            lstBranch.Visible = false;

            dteFromDate.Focus();

        }
        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstBranch.Text;

                    dteFromDate.Focus();
                    lstBranch.Visible = false;
                }

            }

        }
        private void uctxtBranch_KeyDown(object sender, KeyEventArgs e)
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
        private void uctxtMrName_TextChanged(object sender, EventArgs e)
        {
            lstMrName.SelectedIndex = lstMrName.FindString(uctxtMrName.Text);
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
            dteFromDate.Focus();
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
                        dteFromDate.Focus(); 
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    dteFromDate.Focus();
                }
            }

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
                if (radAll.Checked == true )
                {

                    btnPrint.Focus();
                    
                }
                else
                {
                    btnPrint.Focus();
                }             
            }
        }      
        #endregion      
        private void mloadParty()
        {
            int introw = 0,intstatus=0;
            DGMr.Rows.Clear();
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            if (radActive.Checked==true)
            {
                intstatus = 0;
            }
            else
            {
                intstatus = 1;
            }
            ooPartyName = invms.mfillPartyNameNew(strComID, strBranchID, Utility.gblnAccessControl, Utility.gstrUserName, intstatus, "").ToList();

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

                //DGMr.AllowUserToAddRows = false;
            }
        }

        private void mLaodItem()
        {
         
        }

 
        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            lblMpoName.Visible = false;
            uctxtMrName.Visible = false;
            lstMrName.Visible = false;
            lstBranch.Visible = false;

            panel3.Enabled = true;
        
            radAll.PerformClick();


            lstBranch.DisplayMember = "value";
            lstBranch.ValueMember = "Key";
            lstBranch.DataSource = accms.mfillBranchNew(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            
            uctxtBranch.Select();
         
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strBranchId = "";
            string strReportOption = "";
            string strValOption = "";
            double dblAmount=0;
            int intchkstatus = 0;

            if (radActive.Checked==true)
            {
                intchkstatus = 0;
            }
            else if (radInactive.Checked == true)
            {
                intchkstatus = 1;
            }
            else
            {
                intchkstatus = 3;
            }
           
          

            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            if (dteFromDate.Value > dteToDate.Value)
            {
                MessageBox.Show("Please Check Date.");
                return;
            }

            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            }
            if (txtLess.Text!="")
            {
                dblAmount = Convert.ToDouble((txtLess.Text).ToString());
                strValOption = "<";
            }
            if (TxtGreater.Text!= "")
            {
                dblAmount = Convert.ToDouble((TxtGreater.Text).ToString());
                strValOption = ">";
            }


            if (cheMPO.Checked==true)
            {
                strReportOption = "MPO";
            }
            if (cheFMAM.Checked == true)
            {
                strReportOption = "AM";
            }
            if (cheRSMDSM.Checked == true)
            {
                strReportOption = "DSM";
            }
            if (cheZone.Checked==true)
            {
                strReportOption = "ZONE";
            }
            if (chkboxRV.Checked == true)
            {
                strReportOption = "MPOWithRV";
            }
            if ((radAll.Checked == true) && (chkboxRV.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.rptDailyCollectionRV;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.dblAmount = dblAmount;
                frmviewer.strString2 = strValOption;
                frmviewer.strString3 = strReportOption;
                frmviewer.ReportSecondParameter = "Branch : " + uctxtBranch.Text;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.strString = "";
                frmviewer.intStatusNew = intchkstatus;
                frmviewer.reportTitle2 = "A";
                frmviewer.strSelction = uctxtMrName.Text;
                frmviewer.Show();
                return;
            }
            if ((radIndividual.Checked == true) && (chkboxRV.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.rptDailyCollectionRV;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.dblAmount = dblAmount;
                frmviewer.strString2 = strValOption;
                frmviewer.strString3 = strReportOption;
                frmviewer.ReportSecondParameter = "Branch : " + uctxtBranch.Text;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.strString = "";
                frmviewer.intStatusNew = intchkstatus;
                frmviewer.reportTitle2 = "A";
                frmviewer.strSelction = uctxtMrName.Text;
                frmviewer.Show();
                return;
            }
            if ((radAll.Checked == true) && (cheZone.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.CollectionStatementZone;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.dblAmount = dblAmount;
                frmviewer.strString2 = strValOption;
                frmviewer.strString3 = strReportOption;
                frmviewer.ReportSecondParameter = "Branch : " + uctxtBranch.Text;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.strString = "";
                frmviewer.intStatusNew = intchkstatus;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((radAll.Checked == true) && (cheRSMDSM.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.CollectionStatementRSM;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.dblAmount = dblAmount;
                frmviewer.strString2 = strValOption;
                frmviewer.strString3 = strReportOption;
                frmviewer.ReportSecondParameter = "Branch : " + uctxtBranch.Text;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.strString = "";
                frmviewer.reportTitle2 = "A";
                frmviewer.intStatusNew = intchkstatus;
                frmviewer.intMode = 0;
                frmviewer.Show();
                return;
            }
            if ((radAll.Checked == true) && (cheMPO .Checked == true ))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.CollectionStatementMPO;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.dblAmount = dblAmount;
                frmviewer.strString2 = strValOption;
                frmviewer.strString3 = strReportOption;
                frmviewer.strString = uctxtMrName.Text;
                frmviewer.ReportSecondParameter = "Branch : " + uctxtBranch.Text;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.reportTitle2 = "A";
                frmviewer.intStatusNew = intchkstatus;
                frmviewer.intMode = 0;
                frmviewer.Show();
                return;
            }
            if ((radAll.Checked == true) && (cheFMAM.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.CollectionStatementFM;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.dblAmount = dblAmount;
                frmviewer.strString2 = strValOption;
                frmviewer.strString3 = strReportOption;
                frmviewer.ReportSecondParameter = "Branch : " + uctxtBranch.Text;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.strString = "";
                frmviewer.intStatusNew = intchkstatus;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if (radAll.Checked == true) 
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.allMpoCollectionStatement;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.dblAmount = dblAmount;
                frmviewer.strString2 = strValOption;
                frmviewer.strString3 = strReportOption;
                frmviewer.ReportSecondParameter = "Branch : " + uctxtBranch.Text;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.strString = "";
                frmviewer.intStatusNew = intchkstatus;
                frmviewer.reportTitle2 = "A";
                frmviewer.strString = "";
                frmviewer.Show();

            }
            if (radIndividual.Checked == true) 
            {

                if (uctxtMrName.Text == "")
                {
                    MessageBox.Show("Please Select MPO Name.");
                    return;
                }
                if (radIndividual.Checked == true)
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.CollectionStatementIndividualF;
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strBranchId = strBranchId;
                    frmviewer.strString = uctxtMrName.Text;
                    frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                    frmviewer.strSelction = uctxtMrName.Text;
                    frmviewer.reportTitle2 = "A";
                    frmviewer.intStatusNew = intchkstatus;
                    frmviewer.intMode = 5;
                    frmviewer.Show();
                    return;
                }

            }
  
        }

        private void radAll_MouseClick(object sender, MouseEventArgs e)
        {
            //panel4.Enabled = false;
            panel3.Enabled = true;
            lstMrName.Visible = false;
            uctxtMrName.Text = "";
            //dteFromDate.Focus();
            lblMpoName.Visible = false;
            uctxtMrName.Visible = false;
            DGMr.Visible = false;
        }
        private void radIndividual_MouseClick(object sender, MouseEventArgs e)
        {
            //panel4.Enabled = true;
            panel3.Enabled = false;
            lstMrName.Visible = false;
            uctxtMrName.Text = "";
            //dteFromDate.Focus();
            lblMpoName.Visible = true;
            uctxtMrName.Visible = true;
        }
        private void cheMPO_MouseClick(object sender, MouseEventArgs e)
        {
            if (cheMPO.Checked == true)
            {
                cheMPO.Checked = true;
                cheFMAM.Checked = false;
                cheRSMDSM.Checked = false;
                cheZone.Checked = false;
                chkboxRV.Checked = false;
            }
            else
            {
                cheMPO.Checked = false;
                cheFMAM.Checked = false;
                cheRSMDSM.Checked = false;
                cheZone.Checked = false;
                chkboxRV.Checked = false;
            }

        }
        private void cheFMAM_MouseClick(object sender, MouseEventArgs e)
        {
            if (cheFMAM.Checked == true)
            {
                cheMPO.Checked = false;
                cheFMAM.Checked = true;
                cheRSMDSM.Checked = false;
                cheZone.Checked = false;
                chkboxRV.Checked = false;
            }
            else 
            {
                cheMPO.Checked = false;
                cheFMAM.Checked = false;
                cheRSMDSM.Checked = false;
                cheZone.Checked = false;
                chkboxRV.Checked = false;
            }
        }
        private void cheRSMDSM_MouseClick(object sender, MouseEventArgs e)
        {
            if (cheRSMDSM.Checked == true)
            {
                cheMPO.Checked = false;
                cheFMAM.Checked = false;
                cheRSMDSM.Checked = true;
                cheZone.Checked = false;
                chkboxRV.Checked = false;
            }
            else
            {
                cheMPO.Checked = false;
                cheFMAM.Checked = false;
                cheRSMDSM.Checked = false;
                cheZone.Checked = false;
                chkboxRV.Checked = false;
            }
        }

        private void cheZone_MouseClick(object sender, MouseEventArgs e)
        {
            if (cheZone.Checked == true)
            {
                cheMPO.Checked = false;
                cheFMAM.Checked = false;
                cheRSMDSM.Checked = false;
                cheZone.Checked = true;
                chkboxRV.Checked = false;
            }
            else
            {
                cheMPO.Checked = false;
                cheFMAM.Checked = false;
                cheRSMDSM.Checked = false;
                cheZone.Checked = false;
                chkboxRV.Checked = false;
            }
        }

         
        private void radAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
            uctxtMrName.Visible = true;
            uctxtMrName.Text = "";
            DGMr.Top = uctxtMrName.Top + 25;
            DGMr.Left = uctxtMrName.Left;
            DGMr.Width = uctxtMrName.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.Visible = true;
            DGMr.AllowUserToAddRows = false;
            radAll.Visible = true;
            radActive.Checked = true;
            cheMPO.Checked = false;
            optAll.Visible = false;
            txtLess.Text = "";
            TxtGreater.Text = "";
            label4.Enabled = false;
            label6.Enabled = false;
            txtLess.Enabled = false;
            TxtGreater.Enabled = false;
            uctxtMrName.Focus();

            
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            txtLess.Text = "";
            TxtGreater.Text = "";
            label4.Enabled = true;
            label6.Enabled = true;
            txtLess.Enabled = true;
            TxtGreater.Enabled = true;
            dteFromDate.Focus();
            lblMpoName.Visible = false;
            uctxtMrName.Visible = false;
            optAll.Visible = true;
        }

        

        private void chkbox_Click(object sender, EventArgs e)
        {
            if (uctxtMrName.Visible)
            {
                uctxtMrName.Focus();
            }
            mloadParty();
        }

        private void radActive_Click(object sender, EventArgs e)
        {
            mloadParty();
        }

        private void radInactive_Click(object sender, EventArgs e)
        {
            mloadParty();
        }

        private void chkboxRV_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkboxRV.Checked == true)
            {
                cheMPO.Checked = false;
                cheFMAM.Checked = false;
                cheRSMDSM.Checked = false;
                cheZone.Checked = false;
                chkboxRV.Checked = true;
            }
            else
            {
                cheMPO.Checked = false;
                cheFMAM.Checked = false;
                cheRSMDSM.Checked = false;
                cheZone.Checked = false;
                chkboxRV.Checked = false;
            }
        }

      

      

     

      



    }
}
