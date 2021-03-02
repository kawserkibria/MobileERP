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
    public partial class frmRptProductSalesStatement : JA.Shared.UI.frmSmartFormStandard 
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();

        //private ListBox lstMedicalRep = new ListBox();
        public int lngLedgeras { get; set; }

        SPWOIS objWoIS = new SPWOIS();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strReportName { get; set; }
        List<Invoice> ooPartyName;
        List<AccountdGroup> oogrp;

        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private string strComID { get; set; }
        public frmRptProductSalesStatement()
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

            this.uctxtMedicalRep.GotFocus += new System.EventHandler(this.uctxtMedicalRep_GotFocus);
            this.uctxtMedicalRep.KeyDown += new KeyEventHandler(uctxtMedicalRep_KeyDown);
            this.uctxtMedicalRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMedicalRep_KeyPress);
            this.lstMrName.DoubleClick += new System.EventHandler(this.lstMrName_DoubleClick);

            this.uctxtMedicalRep.TextChanged += new System.EventHandler(this.uctxtMedicalRep_TextChanged);
            this.uctxtMedicalRep.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtMedicalRep_KeyUp);
            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);

            this.txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearch_KeyPress);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            //this.txtSearch.GotFocus += new System.EventHandler(this.txtSearch_GotFocus);

            //Utility.CreateListBox(lstMrName, pnlMain, uctxtMedicalRep);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch, 0);
            //Utility.CreateListBox(lstMrName, pnlMain, uctxtMrName, 0);
        }

        #region "User Deifne"
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }

        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstLeft.SelectedValue = lstLeft.SelectedValue;
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnRightSingle.PerformClick();
                lstLeft.SetSelected(0, true);
                txtSearch.Text = "";
                txtSearch.Focus();
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
            //if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            //{
            //    frmAccountsLedger objfrm = new frmAccountsLedger();
            //    objfrm.m_acction = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            //    objfrm.mSingleEntry = 1;
            //    objfrm.Show();

            //}

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
                uctxtMedicalRep.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                DGMr.Visible = false;
              
                if (radIndividual.Checked)
                {
                    mLoadStockGroup();
                }
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
                uctxtMedicalRep.Text = DGMr.Rows[i].Cells[3].Value.ToString();
                DGMr.Visible = false;
                if (radIndividual.Checked)
                {
                    mLoadStockGroup();
                }
                btnPrint.Focus();
            }
        }
        private void radAllItem_Click(object sender, EventArgs e)
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();                    
        }
        private void uctxtMedicalRep_TextChanged(object sender, EventArgs e)
        {
            lstMrName.SelectedIndex = lstMrName.FindString(uctxtMedicalRep.Text);
        }
        private void uctxtMedicalRep_GotFocus(object sender, System.EventArgs e)
        {

            //if (radIndividual.Checked == true)
            //{
            //    mloadParty();
            //    lstMrName.Show();
            //}
            //else
            //{

            //}
        }
        private void uctxtMedicalRep_KeyUp(object sender, KeyEventArgs e)
        {
            if (radIndividual.Checked)
            {
                SearchListViewPartyName(ooPartyName, uctxtMedicalRep.Text);
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
            uctxtMedicalRep.Text = lstMrName.Text;
            lstMrName.Visible = false;
            btnPrint.Focus();
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
                    DGMr.Focus();
                    if (DGMr.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                        uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                        uctxtMedicalRep.Text = DGMr.Rows[i].Cells[3].Value.ToString();
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
                    DGMr.Visible = false;
                    txtSearch.Focus();
                }
               
            }
            mLoadStockGroup();
           
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
        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                dteToDate.Focus();

            }
        }
        private void mLoadStockGroup()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();

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

            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            int intmode = 0;
            if (rbtProductW.Checked == true)
            {
                intmode = 4;
                List<RSalesPurchase> orptt = objWoIS.mGetProductsales(strComID, dteFromDate.Text, dteToDate.Text, strBranchId, uctxtMedicalRep.Text, "", uctxtMedicalRep.Text, intmode, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
                if (orptt.Count > 0)
                {
                    foreach (RSalesPurchase ostk in orptt)
                    {
                        lstLeft.Items.Add(ostk.strItemName);
                    }
                }
            }
            if (radInvoiceWise.Checked == true)
            {
                intmode = 5;
                List<RSalesPurchase> orptt = objWoIS.mGetProductsales(strComID, dteFromDate.Text, dteToDate.Text, strBranchId, uctxtMedicalRep.Text, "", uctxtMedicalRep.Text, intmode, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
                foreach (RSalesPurchase ostk in orptt)
                {
                    if (radInvoiceWise.Checked == true)
                    {
                        lstLeft.Items.Add(Utility.Mid(ostk.strRefNo, 6, ostk.strRefNo.Length - 6));
                        lstLeft.ValueMember = ostk.strRefNo;
                    }
                 
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
                if(radAll.Checked == true)
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
          
                //uctxtMedicalRep.Focus();
            }
        }
        #endregion



        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            lstBranch.Visible = false;
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            label6.Text = "Invoice Wise";
            viiissibalefales();
           
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ///intmode  STOCKITEM = 4, COMP_REF_NO=3 , SalesReport=5
           
           
            string strString2 = "",strRefNo="";
           
      
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

            if ((radAll.Checked == true) && (cheRsmDsm.Checked == true) && (rbtSummary.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductSalesAllRSMSummary;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.strString2 = strString2;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.intMode = 4;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((radAll.Checked == true) && (cheRsmDsm.Checked == true) && (rbtDetails.Checked == true)) 
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductSalesAllRSM;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.strString2 = strString2;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.intMode = 4;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((radAll.Checked == true) && (cheZone.Checked == true) && (rbtSummary.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductSalesAllZONESummary;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.strString2 = strString2;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.intMode = 4;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((radAll.Checked == true) && (cheZone.Checked == true) && (rbtDetails.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductSalesAllZone;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.strString2 = strString2;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.intMode = 4;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }

            if ((radAll.Checked == true) && (cheFmAM.Checked == true) && (rbtSummary.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductSalesAllFMSummary;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.strString2 = strString2;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.intMode = 4;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((radAll.Checked == true) && (cheFmAM.Checked == true) && (rbtSummary.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductSalesAllFM;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.strString2 = strString2;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.intMode = 4;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if ((radAll.Checked == true) && (cheMpo.Checked == true) && (rbtSummary.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductSalesAllMPOSummary ;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.strString2 = strString2;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.intMode = 2;
                frmviewer.reportTitle2 = "A";
                frmviewer.intSuppress = 2;
                frmviewer.Show();
                return;
            }

            if ((radAll.Checked == true) && (cheMpo.Checked == true) && (rbtDetails.Checked == true))
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductSalesAll;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.strString2 = strString2;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.intMode = 2;
                frmviewer.reportTitle2 = "A";
                frmviewer.intSuppress = 2;
                frmviewer.Show();
                return;
            }
          if ((radIndividual.Checked == true) && (rbtProductW.Checked ==true ))
            {

                for (int i = 0; i < lstRight.Items.Count; i++)
                {
                    strString2 = strString2 + "'" + lstRight.Items[i].ToString() + "',";
                    strRefNo = strRefNo + "'" + lstRight.Items[i].ToString() + "',";
                }
                if (strString2 != "")
                {
                    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                    strRefNo = Utility.Mid(strRefNo, 0, strRefNo.Length - 1);
                }
             
             if (strString2 == "")
             {
                 MessageBox.Show("Data Not Found");
                 return;
             }
          
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductSalesIndividual;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.strString = uctxtBranch.Text;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.strString2 = strString2;              
                frmviewer.strSelction = uctxtMedicalRep.Text;
                frmviewer.intMode = 4;
                frmviewer.reportTitle2 = "A";
                frmviewer.strString7 = strRefNo;
                frmviewer.Show();
                return;
            }
          if ((radIndividual.Checked == true) && (radInvoiceWise.Checked == true))
          {
              string strPrevix = "";
              for (int i = 0; i < lstRight.Items.Count; i++)
              {
                  strPrevix =Utility.vtSALES_INVOICE_STR + strBranchId ;
                  strString2 = strString2 + "'" + strPrevix + lstRight.Items[i].ToString() + "',";
                  strRefNo = strRefNo + "'" + lstRight.Items[i].ToString() + "',";
              }
              if (strString2 != "")
              {
                  strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                  strRefNo = Utility.Mid(strRefNo, 0, strRefNo.Length - 1);
              }
              if (strString2 == "")
              {
                  MessageBox.Show("Data Not Found");
                  return;
              }

              frmReportViewer frmviewer = new frmReportViewer();
              frmviewer.selector = ViewerSelector.ProductSalesAll;
              frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
              frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
              frmviewer.strBranchId = strBranchId;
              frmviewer.strString = uctxtBranch.Text;
              frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
              frmviewer.strString2 = strString2;
              frmviewer.strSelction = uctxtMedicalRep.Text;
              frmviewer.intMode = 3;
              frmviewer.reportTitle2 = "A";
              frmviewer.strString7 = strRefNo;
              frmviewer.Show();
              return;
          }

            if (radAll.Checked == true) 
            {

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductSalesAll;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.strString = uctxtBranch.Text;
                frmviewer.strString2 = strString2;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.intMode = 4;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
            }
            if (radIndividual.Checked == true)
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.ProductSalesAll;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strBranchId = strBranchId;
                frmviewer.strString = uctxtBranch.Text;
                frmviewer.secondParameter1 = "Branch : " + uctxtBranch.Text;
                frmviewer.strString2 = strString2;
                frmviewer.strSelction = uctxtMedicalRep.Text;
                frmviewer.intMode = 4;
                frmviewer.reportTitle2 = "A";
                frmviewer.Show();
                return;
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
            groupSelection.Visible = false;
            //textBox2.Visible = false;
            lblMpoName.Visible = false;
            uctxtMedicalRep.Visible = false;
            lstMrName.Visible = false;
        }

         private void viiissibaleTrue()
         {
             groupInvPro.Visible = true;
             groupSelection.Visible = true;
             //textBox2.Visible = true;
             lblMpoName.Visible = false;
             uctxtMedicalRep.Visible = false;
         } 
         private void mloadParty()
         {
             int introw = 0;
             DGMr.Rows.Clear();
             try
             {
                 string strBarchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
                 ooPartyName = invms.mfillPartyNameNew(strComID, strBarchID, Utility.gblnAccessControl, Utility.gstrUserName, 0, "X","").ToList();

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
             catch (Exception ex)
             {

             }
         }
         private void cheFmAM_MouseClick(object sender, MouseEventArgs e)
         {
             if (cheFmAM.Checked == true)
             {
                 cheFmAM.Checked = true;
                 cheMpo.Checked = false;
                 cheRsmDsm.Checked = false;
                 cheZone.Checked = false;
             }
             else
             {
                 cheFmAM.Checked = false;
                 cheMpo.Checked = false;
                 cheRsmDsm.Checked = false;
                 cheZone.Checked = false;
             }
         }

         private void cheRsmDsm_MouseClick(object sender, MouseEventArgs e)
         {
             if (cheRsmDsm.Checked == true)
             {
                 cheFmAM.Checked = false;
                 cheMpo.Checked = false;
                 cheRsmDsm.Checked = true;
                 cheZone.Checked = false;
             }
             else
             {
                 cheFmAM.Checked = false;
                 cheMpo.Checked = false;
                 cheRsmDsm.Checked = false;
                 cheZone.Checked = false;
             }
         }
    
         private void cheZone_Click(object sender, EventArgs e)
         {
            if (cheZone.Checked == true )
            {
                cheFmAM.Checked = false;
                cheMpo.Checked = false;
                cheRsmDsm.Checked = false;
                cheZone.Checked = true;
            }
            else
            {
                cheFmAM.Checked = false;
                cheMpo.Checked = false;
                cheRsmDsm.Checked = false;
                cheZone.Checked = false;
            }

         }
         private void cheMpo_CheckedChanged(object sender, EventArgs e)
         {
             if (cheMpo.Checked == true)
             {
                 cheFmAM.Checked = false;
                 cheMpo.Checked = true;
                 cheRsmDsm.Checked = false;
                 cheZone.Checked = false;
             }
             else
             {
                 cheFmAM.Checked = false;
                 cheMpo.Checked = false;
                 cheRsmDsm.Checked = false;
                 cheZone.Checked = false;
             }
         }



         private void btnRightSingle_Click(object sender, EventArgs e)
         {
             if (lstLeft.SelectedItems.Count > 0)
             {
                 lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                 lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
                 lstLeft.SetSelected(0, true);
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

         private void radInvoiceWise_Click(object sender, EventArgs e)
         {
             lstLeft.Items.Clear();
             lstRight.Items.Clear();
         }

         private void rbtProductW_Click(object sender, EventArgs e)
         {
             lstLeft.Items.Clear();
             lstRight.Items.Clear();
         }

         private void radAll_Click(object sender, EventArgs e)
         {
             dteFromDate.Focus();
             //txtLocationName.Enabled = false;
             lblMpoName.Visible = false;
             lstMrName.Visible = false;
             DGMr.Visible = false;
             uctxtMedicalRep.Text = "";
             groupDetSumm.Enabled = true;
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
             mloadParty();
             lstMrName.Show();
             uctxtMedicalRep.Focus();
             groupDetSumm.Enabled = false;
         }

    
    }
}
