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
using JA.Modulecontrolar.JSAPUR;
using JA.Modulecontrolar.UI.DReport.Sales.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Sales.ParameterForms
{
    public partial class frmRptSpecialProduct : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstCustomerGroupname = new ListBox();
        public string strFromshow { get; set; }
        public int lngLedgeras { get; set; }
        public string strSelection { get; set; }

        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strReportName { get; set; }
        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;
        List<RProductSales> ooPartyGroup;

        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private string strComID { get; set; }
        public frmRptSpecialProduct()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);
            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);

            this.uctxtMedicalRep.GotFocus += new System.EventHandler(this.uctxtMedicalRep_GotFocus);
            this.uctxtMedicalRep.KeyDown += new KeyEventHandler(uctxtMedicalRep_KeyDown);
            this.uctxtMedicalRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMedicalRep_KeyPress);
            this.uctxtMedicalRep.TextChanged += new System.EventHandler(this.uctxtMedicalRep_TextChanged);
            this.uctxtMedicalRep.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtMedicalRep_KeyUp);

            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);

            this.txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearch_KeyPress);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.GotFocus += new System.EventHandler(this.txtSearch_GotFocus);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch, 0);

        }

        #region "User Deifne"

        private void txtSearch_GotFocus(object sender, System.EventArgs e)
        {

            if ((lstLeft.Items.Count == 0) || (lstRight.Items.Count == 0))
            {
                if (rbtProductWise.Checked)
                {
                    mLoadStockGroup();
                }
                else
                {
                    mLoadStockGroup();
                }
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }
        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstRight.SelectedValue = lstLeft.SelectedValue;
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }
        }
        private void lstRight_DoubleClick(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight.SelectedItem.ToString());
                lstLeft.SelectedValue = lstRight.SelectedValue;
                lstRight.Items.Remove(lstRight.SelectedItem.ToString());
            }

        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstLeft.SelectedItems.Count > 0)
                {
                    lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                    lstRight.SelectedValue = lstLeft.SelectedValue;
                    lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
                    txtSearch.Text = "";
                    txtSearch.Focus();
                }
                btnPrint.Focus();
            }

        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLeft.SelectedItem != null)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLeft.Items.Count - 1 > lstLeft.SelectedIndex)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex + 1;
                }
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
            uctxtLedgerConfig.Text = "";
            if (DGMr.SelectedRows.Count > 0)
            {
                if (rbtMPO.Checked == true)
                {
                    int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtMedicalRep.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    txtSearch.Focus();
                }
                else
                {
                    int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());

                    uctxtMedicalRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    txtSearch.Focus();

                }

            }
        }
        private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtLedgerConfig.Text = "";
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtMedicalRep.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                if (rbtMPO.Checked == true)
                {
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                }
                DGMr.Visible = false;
                if (radGroup.Checked == true)
                {
                    uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                }
                txtSearch.Focus();
            }
        }
        private void radAllItem_Click(object sender, EventArgs e)
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
        }
        private void uctxtMedicalRep_TextChanged(object sender, EventArgs e)
        {
            if (uctxtMedicalRep.Text == "")
            {
                uctxtTerritoryCode.Text = "";
                uctxtLedgerConfig.Text = "";
            }
        }
        private void uctxtMedicalRep_GotFocus(object sender, System.EventArgs e)
        {
            mloadParty();
        }
        private void uctxtMedicalRep_KeyUp(object sender, KeyEventArgs e)
        {
            uctxtLedgerConfig.Text = "";
            if (rbtMPO.Checked)
            {
                SearchListViewPartyName(ooPartyName, uctxtMedicalRep.Text);
            }
            else
            {
                SearchListViewGroupName(oogrp, uctxtMedicalRep.Text);
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
        private void uctxtMedicalRep_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtMedicalRep.Text == "")
                {
                    uctxtMedicalRep.Text = "";
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        DGMr.Visible = true;
                    }

                    DGMr.Visible = false;

                    return;
                }
                if (uctxtMedicalRep.Text != "")
                {
                    if (radGroup.Checked == true)
                    {
                        DGMr.Focus();
                        if (DGMr.Rows.Count > 0)
                        {
                            int i = 0;

                            uctxtMedicalRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                            uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                            DGMr.Visible = false;
                            txtSearch.Focus();
                        }
                    }
                    else
                    {
                        int i = 0;
                        uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtMedicalRep.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                        uctxtLedgerConfig.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = false;
                        txtSearch.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtMedicalRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    txtSearch.Focus(); ;

                }

            }


        }
        private void uctxtMedicalRep_KeyDown(object sender, KeyEventArgs e)
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
        private void datefuntion()
        {
            dteFromDate.Text = 1 + "/" + dteFromDate.Value.Month + "/" + dteFromDate.Value.Year.ToString();
            dteToDate.Text = dteFromDate.Value.AddMonths(11).ToString();

            int dayss = dteToDate.Value.Day;
            dteToDate.Text = dteToDate.Value.AddDays(-dayss).ToString();
            dteToDate.Text = dteToDate.Value.AddDays(32).ToString();
            dayss = dteToDate.Value.Day;
            dteToDate.Text = dteToDate.Value.AddDays(-dayss).ToString();
        }
        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (strFromshow == "12MonthSales")
                {

                    datefuntion();
                }

                if (strFromshow == "12MonthSales")
                {
                    if (groupInvPro.Visible == true)
                    {
                        uctxtMedicalRep.Focus();
                    }
                    else
                    {
                        txtSearch.Focus();
                    }
                }
                else
                {
                    dteToDate.Focus();
                }

            }
        }
        private void mLoadStockGroup()
        {
            int intmode = 0;
            lstLeft.Items.Clear();
            lstRight.Items.Clear();

            lstLeft.Items.Clear();
            lstRight.Items.Clear();


            if (rbtProductWise.Checked)
            {
                intmode = 1;
            }
            else
            {
                intmode = 2;
            }

            List<RProductSales> orptt = orpt.mGetSpecialProductLoad(strComID, intmode).ToList();
            if (orptt.Count > 0)
            {
                foreach (RProductSales ostk in orptt)
                {
                    lstLeft.Items.Add(ostk.strStockItemName);
                }
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
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
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
                    uctxtMedicalRep.Focus();
                    uctxtMedicalRep.Visible = true;
                    uctxtMedicalRep.Text = "";
                    DGMr.Top = uctxtMedicalRep.Top + 25;
                    DGMr.Left = uctxtMedicalRep.Left;
                    DGMr.Width = uctxtMedicalRep.Width;
                    DGMr.Height = 200;
                    DGMr.BringToFront();
                    DGMr.Visible = true;
                    DGMr.AllowUserToAddRows = false;
                }

            }
        }
        #endregion
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ///intmode  STOCKITEM = 4, COMP_REF_NO=3 , SalesReport=5
            int IntreportS = 0;
            string strString = "";
            string strString2 = "";
            int intSuppress = 0;

            dateTimePicker1.Text = dteFromDate.Value.ToString();

            int day = dteFromDate.Value.Day;
            dateTimePicker1.Text = dateTimePicker1.Value.AddDays(-day).ToString();
            int day1 = dateTimePicker1.Value.Day;
            int year1 = dateTimePicker1.Value.Year;
            string PreMonoth = Convert.ToDateTime(dateTimePicker1.Value).ToString("MMMyy");

            int intModee = 0;

            string strBranchId = "";
            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            }

            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                strString2 = strString2 + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
            }
            if (strString2 != "")
            {
                strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
            }

            if (radGroup.Checked == true)
            {
                intModee = 1;
            }
            else
            {
                intModee = 2;
            }

            if (strFromshow == "12MonthSales")
            {
                datefuntion();

                if (rbtPackSizeWise.Checked)
                {
                    intModee = 2;
                }
                else
                {
                    intModee = 1;
                }

                if ((radIndividual.Checked == true) && (rbtMPO.Checked == true))
                {

                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.mGetSpcialProduct12MonthSales;
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strBranchId = uctxtBranch.Text;
                    frmviewer.strString4 = PreMonoth;
                    frmviewer.strSelction = "";
                    frmviewer.strString = "";
                    frmviewer.strString2 = strString2;
                    if (radGroup.Checked == true)
                    {
                        frmviewer.strSelction = uctxtMedicalRep.Text;
                        frmviewer.strString3 = uctxtMedicalRep.Text;
                    }
                    else
                    {
                        frmviewer.strString = uctxtMedicalRep.Text;
                        frmviewer.strString3 = uctxtMedicalRep.Text;
                    }
                    frmviewer.reportTitle2 = "A";
                    frmviewer.intMode = intModee;
                    frmviewer.Show();
                    return;
                }

                if ((radIndividual.Checked == true) && (radGroup.Checked == true))
                {

                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.mGetSpcialProduct12MonthSales;
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strBranchId = uctxtBranch.Text;
                    frmviewer.strString4 = PreMonoth;
                    frmviewer.strSelction = "";
                    frmviewer.strString = "";
                    frmviewer.strString2 = strString2;
                    if (radGroup.Checked == true)
                    {
                        frmviewer.strSelction = uctxtMedicalRep.Text;
                        frmviewer.strString3 = uctxtMedicalRep.Text;
                    }
                    else
                    {
                        frmviewer.strString = uctxtMedicalRep.Text;
                        frmviewer.strString3 = uctxtMedicalRep.Text;
                    }
                    frmviewer.reportTitle2 = "A";
                    frmviewer.intMode = intModee;
                    frmviewer.Show();
                    return;
                }

                if (radAll.Checked == true)
                {

                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.mGetSpcialProduct12MonthSales;
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strBranchId = uctxtBranch.Text;
                    frmviewer.strString4 = PreMonoth;
                    frmviewer.strSelction = "";
                    frmviewer.strString = "";
                    frmviewer.strString2 = strString2;
                    if (radGroup.Checked == true)
                    {
                        frmviewer.strSelction = uctxtMedicalRep.Text;
                        frmviewer.strString3 = uctxtMedicalRep.Text;
                    }
                    else
                    {
                        frmviewer.strString = uctxtMedicalRep.Text;
                        frmviewer.strString3 = uctxtMedicalRep.Text;
                    }
                    frmviewer.reportTitle2 = "A";
                    frmviewer.intMode = intModee;
                    frmviewer.Show();
                    return;
                }

            }
            else
            {

                if ((radIndividual.Checked == true) && (rbtMPO.Checked == true))
                {

                    frmReportViewer frmviewer = new frmReportViewer();
                    if (strFromshow == "PackSise")
                    {
                        frmviewer.selector = ViewerSelector.SpcialProductPackSizeWise;
                    }
                    else
                    {
                        frmviewer.selector = ViewerSelector.SpcialProduct;
                    }
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strBranchId = uctxtBranch.Text;
                    frmviewer.strString4 = PreMonoth;
                    frmviewer.strSelction = "";
                    frmviewer.strString = "";
                    frmviewer.strString2 = strString2;
                    if (radGroup.Checked == true)
                    {
                        frmviewer.strSelction = uctxtMedicalRep.Text;
                        frmviewer.strString3 = uctxtMedicalRep.Text;
                    }
                    else
                    {
                        frmviewer.strString = uctxtMedicalRep.Text;
                        frmviewer.strString3 = uctxtMedicalRep.Text;
                    }

                    if (strFromshow == "PackSise")
                    {
                        if (rbtPackSizeWise.Checked)
                        {
                            frmviewer.intMode = 2;
                        }
                        else
                        {
                            frmviewer.intMode = 3;
                        }
                    }
                    if (strFromshow == "SpecialProductTarget")
                    {
                        if (rbtPackSizeWise.Checked)
                        {
                            frmviewer.intMode = 2;
                        }
                        else
                        {
                            frmviewer.intMode = 3;
                        }
                    }
                        
                    else
                    {
                        frmviewer.intMode = 4;
                    }
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                    return;
                }

                if ((radIndividual.Checked == true) && (radGroup.Checked == true))
                {

                    frmReportViewer frmviewer = new frmReportViewer();
                    if (strFromshow == "PackSise")
                    {
                        frmviewer.selector = ViewerSelector.SpcialProductPackSizeWise;
                    }
                    else
                    {
                        frmviewer.selector = ViewerSelector.SpcialProduct;
                    }
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strBranchId = uctxtBranch.Text;
                    frmviewer.strString4 = PreMonoth;
                    frmviewer.strSelction = "";
                    frmviewer.strString = "";
                    frmviewer.strString2 = strString2;
                    if (radGroup.Checked == true)
                    {
                        frmviewer.strSelction = uctxtMedicalRep.Text;
                        frmviewer.strString3 = uctxtMedicalRep.Text;
                    }
                    else
                    {
                        frmviewer.strString = uctxtMedicalRep.Text;
                        frmviewer.strString3 = uctxtMedicalRep.Text;
                    }

                    if (strFromshow == "PackSise")
                    {
                        if (rbtPackSizeWise.Checked)
                        {
                            frmviewer.intMode = 2;
                        }
                        else
                        {
                            frmviewer.intMode = 3;
                        }
                    }
                    if (strFromshow == "SpecialProductTarget")
                    {
                        if (rbtPackSizeWise.Checked)
                        {
                            frmviewer.intMode = 2;
                        }
                        else
                        {
                            frmviewer.intMode = 3;
                        }
                    }

                    else
                    {
                        frmviewer.intMode = 4;
                    }
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                    return;
                }

                if (radAll.Checked == true)
                {

                    frmReportViewer frmviewer = new frmReportViewer();
                    if (strFromshow == "PackSise")
                    {
                        frmviewer.selector = ViewerSelector.SpcialProductPackSizeWise;
                    }
                    else
                    {
                        frmviewer.selector = ViewerSelector.SpcialProduct;
                    }
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strBranchId = uctxtBranch.Text;
                    frmviewer.strString4 = PreMonoth;
                    frmviewer.strSelction = "";
                    frmviewer.strString = "";
                    frmviewer.strString2 = strString2;
                    if (radGroup.Checked == true)
                    {
                        frmviewer.strSelction = uctxtMedicalRep.Text;
                        frmviewer.strString3 = uctxtMedicalRep.Text;
                    }
                    else
                    {
                        frmviewer.strString = uctxtMedicalRep.Text;
                        frmviewer.strString3 = uctxtMedicalRep.Text;
                    }

                    if (strFromshow == "PackSise")
                    {
                        if (rbtPackSizeWise.Checked)
                        {
                            frmviewer.intMode = 2;
                        }
                        else
                        {
                            frmviewer.intMode = 3;
                        }
                    }
                    if (strFromshow == "SpecialProductTarget")
                    {
                        if (rbtPackSizeWise.Checked)
                        {
                            frmviewer.intMode = 2;
                        }
                        else
                        {
                            frmviewer.intMode = 3;
                        }
                    }
                    else
                    {
                        frmviewer.intMode = 4;
                    }
                    frmviewer.reportTitle2 = "A";
                    frmviewer.Show();
                    return;
                }

            }

        }
        private void radInvoiceWise_MouseClick(object sender, MouseEventArgs e)
        {
            label6.Text = "Invoice Wise";
            dteFromDate.Focus();
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            label6.Text = "Product Wise";
            dteFromDate.Focus();
        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            viiissibalefales();
            groupboxMpoFMRSM.Enabled = true;
            dteFromDate.Focus();
        }
        private void viiissibalefales()
        {
            groupInvPro.Visible = false;
            lblMpoName.Visible = false;
            uctxtMedicalRep.Visible = false;
            lstCustomerGroupname.Visible = false;
        }

        private void viiissibaleTrue()
        {
            groupInvPro.Visible = true;
            lblMpoName.Visible = false;
            uctxtMedicalRep.Visible = false;
        }
        private void mloadParty()
        {

            if (radGroup.Checked == true)
            {
                int introw = 0;
                DGMr.Rows.Clear();

                oogrp = accms.GetGroupList(strComID, 202, false, Utility.gstrUserName).ToList();

                if (oogrp.Count > 0)
                {

                    DGMr.Columns[2].HeaderText = "MPO Group";
                    DGMr.Columns[2].Width = 400;
                    foreach (AccountdGroup ogrp in oogrp)
                    {
                        DGMr.Rows.Add();
                        DGMr.Columns[1].Visible = false;
                        DGMr.Columns[0].Visible = false;
                        DGMr[2, introw].Value = ogrp.GroupName;
                        //DGMr[3, introw].Value = ogrp.GroupName;
                        introw += 1;
                    }

                    DGMr.AllowUserToAddRows = false;
                }

            }
            else
            {
                int introw = 0;
                DGMr.Rows.Clear();
                string strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
                ooPartyName = invms.mfillPartyNameNew(strComID, strBarchID, Utility.gblnAccessControl, Utility.gstrUserName, 0, "","").ToList();

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


        }
        private void cheFmAM_MouseClick(object sender, MouseEventArgs e)
        {
            if (cheCP.Checked == true)
            {
                cheCP.Checked = true;
                cheSP.Checked = false;
                cheGeneral.Checked = false;
            }
            else
            {
                cheCP.Checked = false;
                cheSP.Checked = false;
                cheGeneral.Checked = false;
            }
        }

        private void cheRsmDsm_MouseClick(object sender, MouseEventArgs e)
        {
            if (cheGeneral.Checked == true)
            {
                cheCP.Checked = false;
                cheSP.Checked = false;
                cheGeneral.Checked = true;
            }
            else
            {
                cheCP.Checked = false;
                cheSP.Checked = false;
                cheGeneral.Checked = false;
            }
        }
        private void cheMpo_CheckedChanged(object sender, EventArgs e)
        {
            if (cheSP.Checked == true)
            {
                cheCP.Checked = false;
                cheSP.Checked = true;
                cheGeneral.Checked = false;
            }
            else
            {
                cheCP.Checked = false;
                cheSP.Checked = false;
                cheGeneral.Checked = false;
            }
        }



        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstRight.SelectedValue = lstLeft.SelectedValue;
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }
        }
        private void btnLeftSingle_Click(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight.SelectedItem.ToString());
                lstRight.Items.Remove(lstRight.SelectedItem.ToString());
            }
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstLeft.Items.Count; i++)
            {
                string strItem = lstLeft.Items[i].ToString().TrimStart();
                lstRight.Items.Add(strItem);
            }

            lstLeft.Items.Clear();
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                string strItem = lstRight.Items[i].ToString().TrimStart();
                lstLeft.Items.Add(strItem);
            }
            lstRight.Items.Clear();
        }
        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            lblMpoName.Visible = false;
            lstCustomerGroupname.Visible = false;
            DGMr.Visible = false;
            uctxtMedicalRep.Text = "";
        }
        private void radIndividual_Click(object sender, EventArgs e)
        {
            viiissibaleTrue();
            groupboxMpoFMRSM.Enabled = false;
            lblMpoName.Visible = true;
            uctxtMedicalRep.Visible = true;
            uctxtMedicalRep.Text = "";
            DGMr.Top = uctxtMedicalRep.Top + 25;
            DGMr.Left = uctxtMedicalRep.Left;
            DGMr.Width = uctxtMedicalRep.Width;
            DGMr.Height = 200;
            DGMr.BringToFront();
            DGMr.Visible = true;
            DGMr.AllowUserToAddRows = false;
            lstCustomerGroupname.Show();
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            mloadParty();
            uctxtMedicalRep.Focus();
        }
        private void rbtMPO_Click(object sender, EventArgs e)
        {
            DGMr.Rows.Clear();
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            uctxtMedicalRep.Text = "";
            DGMr.Visible = true;
            lblMpoName.Text = "";
            lblMpoName.Text = "MPO Name";
            mloadParty();
        }

        private void radGroup_Click(object sender, EventArgs e)
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            DGMr.Rows.Clear();
            DGMr.Width = uctxtMedicalRep.Width;
            uctxtMedicalRep.Text = "";
            DGMr.Visible = true;
            lblMpoName.Text = "MPO Group";
            mloadParty();
        }

        private void frmRptSpecialProduct_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            rbtPackSizeWise.Visible = true;
            lstBranch.Visible = false;
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            lstCustomerGroupname.Visible = true;
            lstCustomerGroupname.ValueMember = "strLedgerGroupName";
            lstCustomerGroupname.DisplayMember = "strLedgerGroupName";
            lstCustomerGroupname.DataSource = orpt.mGetSpecialPartyGroup(strComID).ToList();

            label6.Text = "Invoice Wise";
            viiissibalefales();
            //int year = DateTime.Now.Year;
            //int Month = DateTime.Now.Month;
            //int Day = DateTime.Now.Day;
            //DateTime firstDay = new DateTime(year, Month, 1);
            //dteFromDate.Text = firstDay.ToString();
            //dteToDate.Text = dteFromDate.Text;
            //dteToDate.Text = firstDay.AddMonths(1).AddDays(-1).ToString();
            GboxSelection.Visible = true;

            frmLabel.Text = strSelection;
            //if (strFromshow == "SpecialProductTarget")
            //{
            //    GboxSelection.Visible = false;
            //}
            if (strFromshow == "12MonthSales")
            {
                dteToDate.Enabled = false;
            }

        }
        private void rbtProductWise_Click(object sender, EventArgs e)
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            txtSearch.Focus();

        }

        private void rbtPackSizeWise_Click(object sender, EventArgs e)
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            txtSearch.Focus();
        }

    }
}
