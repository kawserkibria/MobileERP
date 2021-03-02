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
using JA.Modulecontrolar.JSAPUR;
namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    public partial class frmRptStatisticalProductSales : JA.Shared.UI.frmSmartFormStandard 
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;
        public int lngLedgeras { get; set; }
        private string strComID { get; set; }
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        public frmRptStatisticalProductSales()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);        
            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);
            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);

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
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch, 0);
            //Utility.CreateListBox(lstMrName, pnlMain, uctxtMrName, 0);
        }

        #region "User Deifne"
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
                if (radDesigCat.Checked == true)
                {
                    int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());              
                    uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    dteFromDate.Focus();
                    
                }
                else
                {
                    int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    dteFromDate.Focus();
                }


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
        private void uctxtMrName_TextChanged(object sender, EventArgs e)
        {
            if (uctxtMrName.Text == "")
            {
                uctxtTerritoryCode.Text = "";
                uctxtTeritorryName.Text = "";
            }
        }
        private void uctxtMrName_GotFocus(object sender, System.EventArgs e)
        {
            if (radDesigCat.Checked)
            {
                mloadGroup();
            }
            else
            {
                mloadParty();
            }
        }
        private void uctxtMrName_KeyUp(object sender, KeyEventArgs e)
        {
            if (radMR.Checked )
            {
                SearchListViewPartyName(ooPartyName, uctxtMrName.Text);
            }
            else
            {
                SearchListViewGroupName(oogrp, uctxtMrName.Text);
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

        private void SearchListViewGroupName(IEnumerable<AccountdGroup> tests, string searchString = "")
        {
            IEnumerable<AccountdGroup> query;
            query = tests;
            if (searchString != "")
            {
                query = tests.Where(x => x.GroupName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }

            DGMr.Rows.Clear();
            int i = 0;
            try
            {
                foreach (AccountdGroup tran in query)
                {
                    DGMr.Rows.Add();
                    DGMr[0, i].Value = "";
                    DGMr[1, i].Value = "";

                    DGMr[2, i].Value = tran.GroupName;
                    DGMr[3, i].Value = tran.GroupName;
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
                        if (radDesigCat.Checked == true)
                        {
                            uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        }
                        else
                        {
                            uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                            uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                            uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        }
                            DGMr.Visible = false;
                            dteFromDate.Focus();
                        
                    }
                }
                else
                {
                    int i = 0;
                    if (radDesigCat.Checked == true)
                    {
                        uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    }
                    else
                    {
                        uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtMrName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    }
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
        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        private void uctxtBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = true;
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
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

                dteFromDate.Focus();

                radAll.PerformClick();
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
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
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
        private void mloadParty()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID, "", false, Utility.gstrUserName, 0, "").ToList();
           
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
        private void mloadGroup()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            oogrp = accms.GetGroupList(strComID, 202, false, Utility.gstrUserName).ToList();

            if (oogrp.Count > 0)
            {

                foreach (AccountdGroup ogrp in oogrp)
                {
                    DGMr.Rows.Add();
                    DGMr.Columns[1].Visible = false;
                    DGMr.Columns[0].Visible = false;
                    DGMr[2, introw].Value = ogrp.GroupName;
                    DGMr[3, introw].Value = ogrp.GroupName;

                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }
        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
        }   
        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intmode = 0;
            if (radIndividual.Checked == true)
            {
                if (radDesigCat.Checked == true )
                {
                    intmode = 2;
                }
                else
                {
                    intmode = 1;
                }
                
            }
            else
            {
                 intmode = 1;
            }
            string strBranchId = "";
            if (dteFromDate.Value > dteToDate.Value)
            {
                MessageBox.Show("Please Check Date.");
                return;
            }

            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            }

            if (radAll .Checked == true )
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.StatisticalProductSales;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strString = uctxtMrName.Text;
                frmviewer.strBranchId = strBranchId;
                frmviewer.secondParameter1 = "Branch :" + uctxtBranch.Text;
                frmviewer.reportTitle2 = "A";
                frmviewer.intMode = 1;
                frmviewer.intSuppress = 0;
                frmviewer.Show();
                return;
            }

            if (radIndividual.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.StatisticalProductSales;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strBranchId = strBranchId;
                frmviewer.intMode = intmode;
                frmviewer.secondParameter1 = "Branch :" + uctxtBranch.Text;
                frmviewer.reportTitle2 = "A";
                if (radDesigCat.Checked == true)
                {
                    frmviewer.strString = uctxtMrName.Text;
                }
                else
                {
                    frmviewer.strString = uctxtMrName.Text;
                    //frmviewer.strString = "MPO Name :" + uctxtMrName.Text;
                }

                frmviewer.intSuppress = 1;
                frmviewer.Show();
                return;
            }                     
        }
        private void radAll_MouseClick(object sender, MouseEventArgs e)
        {
            panelDes.Visible = false;
            lstMrName.Visible = false;
            uctxtMrName.Text = "";
            DGMr.Visible = false;
            labCatname.Visible = false;
            uctxtMrName.Visible = false;
            dteFromDate.Focus();
        }

        private void radDesigCat_CheckedChanged(object sender, EventArgs e)
        {
            if (radDesigCat.Checked == true)
            {
                lstMrName.Visible = false;
            }  
        }
        private void frmRptStatisticalProductSales_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");


            labCatname.Left = 33;
            panelDes.Visible = false;
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
           
            lstMrName.ValueMember = "strLedgerName";
            lstMrName.DisplayMember = "strLedgerName";
            lstMrName.DataSource = accms.mFillLedgerList(strComID, (int)Utility.GR_GROUP_TYPE.grCUSTOMER).ToList();
           

            lstMrName.Visible = false;
            radAll.PerformClick();
            lstBranch.Visible = false;
            lstBranch.Top =193;
            lstBranch.Left = 135;
            DGMr.Visible = false;
            labCatname.Visible = false;
            uctxtMrName.Visible = false;
            //dteFromDate.Text = Utility.gdteFinancialYearFrom;
        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
            panelDes.Visible = true;
            radDesigCat.PerformClick();
            labCatname.Text = "MPO Group :";
            labCatname.Left = 20;
            uctxtMrName.Text = "";
           
            DGMr.Visible = false;
            labCatname.Visible = true;
            uctxtMrName.Visible = true;
            DGMr.Top = uctxtMrName.Top + 25;
            DGMr.Left = uctxtMrName.Left;
            DGMr.Width = uctxtMrName.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            DGMr.Visible = true;
            uctxtMrName.Focus();
        }

        private void radDesigCat_Click(object sender, EventArgs e)
        {
            labCatname.Text = "MPO Group :";
            labCatname.Left =20;
            uctxtMrName.Text = "";
           
            DGMr.Top = uctxtMrName.Top + 25;
            DGMr.Left = uctxtMrName.Left;
            DGMr.Width = uctxtMrName.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            DGMr.Visible = true;
            uctxtMrName.Focus();
        }

        private void radMR_Click(object sender, EventArgs e)
        {
            labCatname.Text = "MPO:";
            labCatname.Left = 20;
            uctxtMrName.Text = "";
           
            DGMr.Top = uctxtMrName.Top + 25;
            DGMr.Left = uctxtMrName.Left;
            DGMr.Width = uctxtMrName.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            DGMr.Visible = true;
            uctxtMrName.Focus();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }        
    }
}
