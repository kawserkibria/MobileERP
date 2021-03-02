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
    public partial class frmRptProductShortDetails : JA.Shared.UI.frmSmartFormStandard
    {

       public string strSelection;

        private ListBox lstGroupConfig = new ListBox();
        private ListBox lstMrName = new ListBox();

        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private string strComID { get; set; }

        List<Invoice> ooPartyName;
        public frmRptProductShortDetails()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);


            this.uctxtGroupConfig.KeyDown += new KeyEventHandler(uctxtGroupConfig_KeyDown);
            this.uctxtGroupConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtGroupConfig_KeyPress);
            this.uctxtGroupConfig.TextChanged += new System.EventHandler(this.uctxtGroupConfig_TextChanged);
            this.lstGroupConfig.DoubleClick += new System.EventHandler(this.lstGroupConfig_DoubleClick);
            this.uctxtGroupConfig.GotFocus += new System.EventHandler(this.uctxtGroupConfig_GotFocus);

            this.uctxtLedgerConfig.KeyDown += new KeyEventHandler(uctxtLedgerConfig_KeyDown);
            this.uctxtLedgerConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerConfig_KeyPress);
            this.uctxtLedgerConfig.TextChanged += new System.EventHandler(this.uctxtLedgerConfig_TextChanged);
            this.uctxtLedgerConfig.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtLedgerConfig_KeyUp);
            this.uctxtLedgerConfig.GotFocus += new System.EventHandler(this.uctxtLedgerConfig_GotFocus);
            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);


            Utility.CreateListBox(lstGroupConfig, PanelGroup, uctxtGroupConfig);
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
                    i += 1;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
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
                if (DGMr.Rows[i].Cells[0].Value != null)
                {
                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                }
                else
                {
                    uctxtTerritoryCode.Text = "";
                }
                if (DGMr.Rows[i].Cells[0].Value != null)
                {
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                }
                else
                {
                    uctxtTeritorryName.Text = "";
                }

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
                if (DGMr.Rows[i].Cells[0].Value != null)
                {
                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                }
                else
                {
                    uctxtTerritoryCode.Text = "";
                }
                if (DGMr.Rows[i].Cells[0].Value != null)
                {
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                }
                else
                {
                    uctxtTeritorryName.Text = "";
                }
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

                        dteFromDate.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    //dteFromDate.Focus();
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

            //DGMr.Top = uctxtLedgerConfig.Top + 25;
            //DGMr.Left = uctxtLedgerConfig.Left;
            //DGMr.Width = uctxtLedgerConfig.Width;
            //DGMr.Height = 200;
            //DGMr.BringToFront();
            //DGMr.AllowUserToAddRows = false;
            return;
        }

        private void uctxtLedgerConfig_GotFocus(object sender, System.EventArgs e)
        {

                mloadParty();
                DGMr.Visible = true;
                DGMr.AllowUserToAddRows = true;

                uctxtLedgerConfig.Visible = true;
                uctxtLedgerConfig.Text = "";
                DGMr.Top = uctxtLedgerConfig.Top + 25;
                DGMr.Left = uctxtLedgerConfig.Left;
                DGMr.Width = uctxtLedgerConfig.Width;
                DGMr.Height = 150;
                DGMr.BringToFront();
                DGMr.AllowUserToAddRows = false;
                uctxtLedgerConfig.Focus();

        }
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
                    DGMr.Columns[2].Width = 270;
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }
        private void uctxtGroupConfig_TextChanged(object sender, EventArgs e)
        {
            lstGroupConfig.SelectedIndex = lstGroupConfig.FindString(uctxtGroupConfig.Text);
        }

        private void lstGroupConfig_DoubleClick(object sender, EventArgs e)
        {
            uctxtGroupConfig.Text = lstGroupConfig.Text;
            btnPrint.Focus();
            lstGroupConfig.Visible = false;
        }

        private void uctxtGroupConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstGroupConfig.Items.Count > 0)
                {
                    uctxtGroupConfig.Text = lstGroupConfig.Text;
                }

                dteFromDate.Focus();
                lstGroupConfig.Visible = false;

            }
        }
        private void uctxtGroupConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstGroupConfig.SelectedItem != null)
                {
                    lstGroupConfig.SelectedIndex = lstGroupConfig.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstGroupConfig.Items.Count - 1 > lstGroupConfig.SelectedIndex)
                {
                    lstGroupConfig.SelectedIndex = lstGroupConfig.SelectedIndex + 1;
                }
            }

        }

        private void uctxtGroupConfig_GotFocus(object sender, System.EventArgs e)
        {
            lstGroupConfig.Visible = true;
            //lstUnder.Visible = false;
            lstGroupConfig.SelectedIndex = lstGroupConfig.FindString(uctxtGroupConfig.Text);
            //lstGroupConfig.Top = 250;
            //lstGroupConfig.Left = 185;
        }
        private void txtGroupName_GotFocus(object sender, System.EventArgs e)
        {
            //lstUnder.Visible = false;
            lstGroupConfig.Visible = false;
            lstGroupConfig.Height = 5;
                 
        }
        private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                //txtUnder.Focus();

            }
        }



        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            //lstBranch.Visible = false;


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
                if (radAll.Checked == true)
                {
                    btnPrint.Focus();
                }
                else
                {
                    if (strSelection == "A")
                    {
                        btnPrint.Focus();
                    }
                    else
                    {
                        btnPrint.Focus();
                 
                    }
                }



            }
        }

        #endregion
      

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            label4.Visible = false;
            uctxtGroupConfig.Visible = false;
            uctxtLedgerConfig .Visible =false ;
            DGMr.Visible =false ;
            lstGroupConfig.Visible = false;
            dteFromDate.Focus();
            if (strSelection == "A")
            {
                PanelGroup.Visible = false;
                lstGroupConfig.Visible = false;
                lstGroupConfig.DisplayMember = "GroupName";
                lstGroupConfig.ValueMember = "GroupName";
                lstGroupConfig.DataSource = invms.mFillStockGroupList(strComID).ToList();
                dteFromDate.Select();
                label4.Visible = true;
                uctxtGroupConfig.Visible = false;

            }
            else
            {
                PanelGroup.Visible = false;
                uctxtLedgerConfig.Visible = false;
                DGMr.Visible = false;

            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (strSelection == "A")
            {

                if (radAll.Checked == true)
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.ProductShortDetails;
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.intMode = 1;
                    frmviewer.Show();
                    return;
                }

                if (radIndividual.Checked == true)

                    if (uctxtGroupConfig.Text == "")
                    {
                        MessageBox.Show("Please Select Group Name.");
                        return;
                    }

                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.ProductShortDetails;
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strString = uctxtGroupConfig.Text;
                    frmviewer.intMode = 1;
                    frmviewer.Show();
                    return;
                }
            }
            else
            {
                if (radAll.Checked == true)
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.ProductShortDetails;
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.intMode = 2;
                    frmviewer.Show();
                    return;
                }

                if (radIndividual.Checked == true)

                    if (uctxtLedgerConfig.Text == "")
                    {
                        MessageBox.Show("Please Select MPO Name.");
                        return;
                    }

                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.ProductShortDetails;
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strString = uctxtLedgerConfig.Text;
                    frmviewer.intMode = 2;
                    frmviewer.Show();
                    return;
                }
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radAll_MouseClick(object sender, MouseEventArgs e)
        {
            PanelGroup.Visible = false;
            dteFromDate.Focus();
            lstGroupConfig.Visible = false;
            uctxtGroupConfig.Text = "";
            uctxtLedgerConfig.Text = "";
 
        }

        private void radIndividual_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radIndividual_MouseClick(object sender, MouseEventArgs e)
        {
            PanelGroup.Visible = false;
            uctxtGroupConfig.Text = "";
          
            label4.Visible = false;
            uctxtGroupConfig.Visible = false;
            uctxtLedgerConfig.Visible = false;
            DGMr.Visible = false;
            lstGroupConfig.Visible = false;

            if (strSelection == "A")
            {
                PanelGroup.Visible = true;
                lstGroupConfig.Visible = true;
                //lstGroupConfig.DisplayMember = "GroupName";
                //lstGroupConfig.ValueMember = "GroupName";
                //lstGroupConfig.DataSource = invms.mFillStockGroupList(strComID).ToList();
               
                label4.Visible = true;
                uctxtGroupConfig.Visible = true;
                uctxtGroupConfig.Focus();
            }
            else
            {
                PanelGroup.Visible = true;
                uctxtLedgerConfig.Visible = true;
                DGMr.Visible = true;
                uctxtLedgerConfig.Focus();

            }

        }

        private void chePartySelection_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chePartySelection_MouseClick(object sender, MouseEventArgs e)
        {
            //panelParty.Visible = true;

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }



    }
}
