using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmMFGStockProductionList : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();

        public delegate void AddAllClick(List<MFGvouhcer> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        private ListBox lstFindWhat = new ListBox();
        private ListBox lstExpression = new ListBox();
        public int intType { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int intvType { get; set; }
        private string strComID { get; set; }
        public frmMFGStockProductionList()
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
                mfgVoucherList();
                PanelSearch.Visible = false;
            }
        }
        private void uctxtFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstFindWhat.Visible = false;
            lstExpression.Visible = false;
            uctxtFromDate.Text = Utility.ctrlDateFormat(DateTime.Now.ToString("dd-MM-yyyy"));

        }
        private void uctxtToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstFindWhat.Visible = false;
            lstExpression.Visible = false;
            uctxtToDate.Text = Utility.ctrlDateFormat(DateTime.Now.ToString("dd-MM-yyyy"));

        }
        private void uctxtExpression_TextChanged(object sender, EventArgs e)
        {
            lstExpression.SelectedIndex = lstExpression.FindString(uctxtExpression.Text);
        }

        private void lstExpression_DoubleClick(object sender, EventArgs e)
        {
            uctxtExpression.Text = lstExpression.Text;
            PanelSearch.Visible = false;
            DGMFGVoucherList.Focus();


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
                mfgVoucherList();
                PanelSearch.Visible = false;
                DGMFGVoucherList.Focus();


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
            else if (uctxtFindWhat.Text == "Stock Item")
            {
                lstExpression.Visible = true;
                lstFindWhat.Visible = false;
                uctxtExpression.Visible = true;
                uctxtFromDate.Visible = false;
                uctxtToDate.Visible = false;
                lblfromDate.Visible = false;
                lblTodate.Visible = false;
                lstExpression.ValueMember = "strItemName";
                lstExpression.DisplayMember = "strItemName";
                lstExpression.DataSource = invms.gFillStockItemAllWithoutGodown(strComID, false, Utility.gstrUserName,"").ToList();
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
            //    lblExpression.Visible = false;
            //    uctxtExpression.Visible = false;
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
        private void uctxtFindWhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

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
                else if (uctxtFindWhat.Text == "Stock Item")
                {
                    lstExpression.Visible = true;
                    lstFindWhat.Visible = false;
                    uctxtExpression.Visible = true;
                    uctxtFromDate.Visible = false;
                    uctxtToDate.Visible = false;
                    lblfromDate.Visible = false;
                    lblTodate.Visible = false;
                    lstExpression.ValueMember = "strItemName";
                    lstExpression.DisplayMember = "strItemName";
                    lstExpression.DataSource = invms.gFillStockItemAllWithoutGodown(strComID, false, Utility.gstrUserName,"").ToList();

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
        private void mLoadFind()
        {
            
            lstFindWhat.Items.Clear();
            lstFindWhat.Items.Add("Voucher Number");
            lstFindWhat.Items.Add("Voucher Date");
            //lstFindWhat.Items.Add("Stock Item");
        

        }
        private void frmMFGVoucherList_Load(object sender, EventArgs e)
        {
            DGMFGVoucherList.AllowUserToAddRows = false;
            if (intvType ==(int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_FINISHED_GOODS )
            {
                frmLabel.Text = "Finished Goods List";
            }
            else if (intvType == (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_CONSUMPTION)
            {
                //frmLabel.Text = "Dilution Consumption List";  
                frmLabel.Text = strFormName;
            }
            else
            {
                frmLabel.Text = "Manufacturing Voucher List";
            }
            if (intType == 4)
            {
                this.DGMFGVoucherList.DefaultCellStyle.Font = new Font("verdana", 9);
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 200, false, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 150, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Consumption Location", "Consumption Location", 170, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Batch No", "Batch No", 130, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 130, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 50, true, DataGridViewContentAlignment.TopCenter, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("", " ", 40, true, DataGridViewContentAlignment.TopLeft, true));
            }
            else
            {
                this.DGMFGVoucherList.DefaultCellStyle.Font = new Font("verdana", 9);
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 200, false, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 150, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Consumption Location", "Consumption Location", 200, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Batch No", "Batch No", 140, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 130, true, DataGridViewContentAlignment.TopLeft, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 50, true, DataGridViewContentAlignment.TopCenter, true));
                DGMFGVoucherList.Columns.Add(Utility.Create_Grid_Column("", " ", 40, false, DataGridViewContentAlignment.TopLeft, true));
            }
            mLoadFind();
            mfgVoucherList();
        }

        private void mfgVoucherList()
        {
            int introw = 0;
            List<MFGvouhcer> oogrp;
            this.DGMFGVoucherList.DefaultCellStyle.Font = new Font("verdana", 9);
            DGMFGVoucherList.Rows.Clear();
            if (uctxtFindWhat.Text !="")
            {
                if (uctxtFindWhat.Text == "Voucher Number")
                {
                    oogrp = invms.mDisplayInOutMaster(strComID, uctxtExpression.Text, intvType, uctxtFindWhat.Text, "", "", "", "", intType,Utility.gstrUserName ).ToList();
                }
                else if (uctxtFindWhat.Text == "Voucher Date")
                {
                    oogrp = invms.mDisplayInOutMaster(strComID, "", intvType, uctxtFindWhat.Text, "", uctxtFromDate.Text, uctxtToDate.Text, "", intType, Utility.gstrUserName).ToList();
                }
                else
                {
                    oogrp = invms.mDisplayInOutMaster(strComID, "", intvType, uctxtFindWhat.Text, uctxtExpression.Text, "", "", "", intType, Utility.gstrUserName).ToList();
                }
            }
            else
            {
                oogrp = invms.mDisplayInOutMaster(strComID, "", intvType, "", "", DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.Date.ToString("dd/MM/yyyy"), "", intType, Utility.gstrUserName).ToList();
            }
            
            if (oogrp.Count > 0)
            {
                foreach (MFGvouhcer ogrp in oogrp)
                {
                    DGMFGVoucherList.Rows.Add();
                    DGMFGVoucherList[0, introw].Value = ogrp.strVoucherNo;
                    DGMFGVoucherList[1, introw].Value = Utility.Mid(ogrp.strVoucherNo,6,ogrp.strVoucherNo.Length-6);
                    DGMFGVoucherList[2, introw].Value = ogrp.strLocation;
                    DGMFGVoucherList[3, introw].Value = ogrp.strBatch;
                    DGMFGVoucherList[4, introw].Value = ogrp.strDate;
                    DGMFGVoucherList[5, introw].Value = ogrp.dblAmount;

                    DGMFGVoucherList[6, introw].Value = "Edit";
                    DGMFGVoucherList[7, introw].Value = "Delete";
                    DGMFGVoucherList[8, introw].Value = "View";
                    if(ogrp.intAppStatus ==0)
                    {
                        DGMFGVoucherList[9, introw].Value = "No";
                    }
                    else
                    {
                        DGMFGVoucherList[9, introw].Value = "Yes";
                    }
                    introw += 1;
                }
                DGMFGVoucherList.AllowUserToAddRows = false;
            }
        }

        private void DGMFGVoucherList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string strmsg = "";

                if (e.ColumnIndex == 6)
                {
                    if (Utility.gblnAccessControl)
                    {
                        if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                        {
                            MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    if (Utility.gstrUserName.ToUpper() != "DEEPLAID")
                    {
                        strmsg = Utility.mGetCheckProductIonApproved(strComID, DGMFGVoucherList.CurrentRow.Cells[0].Value.ToString());

                        if (strmsg != "")
                        {
                            MessageBox.Show(strmsg);
                            return;
                        }
                    }
                    if (onAddAllButtonClicked != null)
                        onAddAllButtonClicked(GetSelectedItem(), sender, e);
                    this.Dispose();
                }
                if (e.ColumnIndex == 7)
                {
                    if (Utility.gblnAccessControl)
                    {
                        if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                        {
                            MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                     strmsg = Utility.mGetCheckProductIonApproved(strComID, DGMFGVoucherList.CurrentRow.Cells[0].Value.ToString());

                     if (strmsg != "")
                     {
                         MessageBox.Show("Approved Voucher Cannot be Delete..");
                         return;
                     }
                     string strLockvoucher = Utility.gLockVocher(strComID, intvType);
                     long lngDate = Convert.ToInt64(Convert.ToDateTime(DGMFGVoucherList.CurrentRow.Cells[4].Value.ToString()).ToString("yyyyMMdd"));
                     if (strLockvoucher != "")
                     {
                         long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strLockvoucher).ToString("yyyyMMdd"));
                         if (lngDate <= lngBackdate)
                         {
                             MessageBox.Show("Invalid Date, Back Date is locked");
                             return;
                         }
                     }
                    var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponse == DialogResult.Yes)
                    {
                        double dblAmnt = Convert.ToDouble(DGMFGVoucherList.CurrentRow.Cells[5].Value.ToString());
                        string strVoucherDate = DGMFGVoucherList.CurrentRow.Cells[4].Value.ToString();
                        //string strBranchID = Utility.gstrGetBranchID(strComID, DGMFGVoucherList.CurrentRow.Cells[10].Value.ToString());

                        string i = invms.mDeleteStockConum(strComID, DGMFGVoucherList.CurrentRow.Cells[0].Value.ToString());
                        if (i == "Deleted...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, strVoucherDate, strFormName, DGMFGVoucherList.CurrentRow.Cells[0].Value.ToString(),
                                                                        3, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                            }
                            DGMFGVoucherList.Rows.RemoveAt(e.RowIndex);
                        }
                        MessageBox.Show(i.ToString());
                        //mfgVoucherList();
                        
                    }
                }
                if (e.ColumnIndex == 8)
                {
                    if (intvType == (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_CONSUMPTION)
                    {
                        String strRefNo = "";
                        strRefNo = DGMFGVoucherList.CurrentRow.Cells[0].Value.ToString();

                        if (Utility.mGetRepakingCheck(strComID, strRefNo) == true)
                        {
                            JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer();
                            frmviewer.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.Repaking;
                            frmviewer.strFdate = "";
                            frmviewer.strSummDetails = "Details";
                            frmviewer.strString = DGMFGVoucherList.CurrentRow.Cells[0].Value.ToString();
                            frmviewer.strSelction = "C";
                            frmviewer.Show();
                        }
                        else
                        {
                            JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer();
                            frmviewer.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.intventoryVoucher;
                            frmviewer.strFdate = "";
                            frmviewer.strSummDetails = "Details";
                            frmviewer.strString = DGMFGVoucherList.CurrentRow.Cells[0].Value.ToString();
                            frmviewer.strSelction = "C";
                            frmviewer.Show();

                        }
                    }
                    else if (intvType == (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_FINISHED_GOODS)
                    {
                        JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer();
                        frmviewer.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.intventoryVoucher;
                        frmviewer.strFdate = "";
                        frmviewer.strSummDetails = "Details";
                        frmviewer.strString = DGMFGVoucherList.CurrentRow.Cells[0].Value.ToString();
                        frmviewer.strSelction = "F";
                        frmviewer.Show();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        

        private void DGMFGVoucherList_DoubleClick(object sender, EventArgs e)
        {
            if (onAddAllButtonClicked != null)
                onAddAllButtonClicked(GetSelectedItem(), sender, e);
            this.Dispose();
        }

        private List<MFGvouhcer> GetSelectedItem()
        {
            List<MFGvouhcer> items = new List<MFGvouhcer>();
            MFGvouhcer itm = new MFGvouhcer();
            itm.strVoucherNo = DGMFGVoucherList.CurrentRow.Cells[0].Value.ToString();
           
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
            PanelSearch.Location = new Point(269, 291);
            uctxtFindWhat.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PanelSearch.Visible = false;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
