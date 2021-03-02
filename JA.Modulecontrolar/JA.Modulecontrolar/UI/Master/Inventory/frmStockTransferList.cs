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
    public partial class frmStockTransferList : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        SPWOIS objWIS = new SPWOIS();
        private ListBox lstFindWhat = new ListBox();
        private ListBox lstExpression = new ListBox();
        public delegate void AddAllClick(List<StockItem> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int intvType { get; set; }
        private string strComID { get; set; }
        public string strFlag { get; set; }
        public frmStockTransferList()
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
                mVoucherList();
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
            mVoucherList();
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
                mVoucherList();
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
        private void frmMFGVoucherList_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
            if (intvType ==(int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER   )
            {
                frmLabel.Text = "Stock Transfer List (Out)";
            }
            else if  (intvType == (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANFERIN)
            {
                frmLabel.Text = "Stock Transfer List (IN)";
            }
            else
            {
                frmLabel.Text = "Physical Stock List";
            }
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 200, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 300, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Narration", "Narration", 200, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 60, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadFind();
            mVoucherList();
        }
        private void mLoadFind()
        {

            lstFindWhat.Items.Clear();
            lstFindWhat.Items.Add("Voucher Number");
            lstFindWhat.Items.Add("Voucher Date");
            lstFindWhat.Items.Add("Stock Item");

        }
        private void mVoucherList()
        {
            int introw = 0;
            List<StockItem> oogrp;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            //List<StockItem> oogrp = invms.mFillStockTransfer(intvType).ToList();

            if (uctxtFindWhat.Text != "")
            {
                if (uctxtFindWhat.Text == "Voucher Number")
                {
                    oogrp = objWIS.mFillStockTransfer(strComID, intvType, uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, strFlag).ToList();
                }
                else if (uctxtFindWhat.Text == "Voucher Date")
                {
                    oogrp = objWIS.mFillStockTransfer(strComID, intvType, uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, strFlag).ToList();
                }
                else
                {
                    oogrp = objWIS.mFillStockTransfer(strComID, intvType, uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text, strFlag).ToList();
                }
            }
            else
            {
                oogrp = objWIS.mFillStockTransfer(strComID, intvType, uctxtFindWhat.Text, uctxtExpression.Text, DateTime.Now.ToString("dd/MM/yyyy"),
                                            DateTime.Now.Date.ToString("dd/MM/yyyy"), strFlag).ToList();
            }



            if (oogrp.Count > 0)
            {
                foreach (StockItem ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strRefNo;
                    DG[1, introw].Value = Utility.Mid(ogrp.strRefNo,6,ogrp.strRefNo.Length-6);
                    DG[2, introw].Value = ogrp.strDate;
                    DG[3, introw].Value = ogrp.dblBranchAmnout;
                    DG[4, introw].Value = ogrp.strNarration ;

                    DG[5, introw].Value = "Edit";
                    //DGMFGVoucherList[5, introw].Value = "Print";
                    DG[6, introw].Value = "Delete";
                    DG[7, introw].Value = "View";
                    
                   
                    introw += 1;
                }
                lblCount.Text = "Total Record: " + introw;
                DG.AllowUserToAddRows = false;
            }
        }

        private void DGMFGVoucherList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                if (intvType == (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER)
                {
                    string strcheck = objWIS.mCheckStockRequisition(strComID, DG.CurrentRow.Cells[0].Value.ToString());
                    if (strcheck != "")
                    {
                        MessageBox.Show(strcheck);
                        return;
                    }
                }
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {

                    double dblAmnt = Convert.ToDouble(DG.CurrentRow.Cells[3].Value.ToString());
                    string strVoucherDate = DG.CurrentRow.Cells[2].Value.ToString();
                    string strBranchID = "0001";
     
                    string i = objWIS.mDeleteStockTransfer(strComID, DG.CurrentRow.Cells[0].Value.ToString());
              
                    if (i == "Delted...")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, strVoucherDate, strFormName, DG.CurrentRow.Cells[0].Value.ToString(),
                                                                    3, dblAmnt, (int)Utility.MODULE_TYPE.mtSTOCK, strBranchID);
                        }
                    }
                    MessageBox.Show(i.ToString());
                    //mVoucherList();
                    DG.Rows.RemoveAt(e.RowIndex);
                }
            }
            if (e.ColumnIndex == 5)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                if(intvType ==(int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER)
                {
                    string strcheck = objWIS.mCheckStockRequisition(strComID, DG.CurrentRow.Cells[0].Value.ToString());
                    if (strcheck != "")
                    {
                        MessageBox.Show(strcheck);
                        return;
                    }
                }
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
            if (e.ColumnIndex == 7)
            {

                JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.intventoryVoucher;
                frmviewer.strFdate = "";
                frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                frmviewer.strSelction = "T";
                frmviewer.Show();

            }
        }

        private void DGMFGVoucherList_DoubleClick(object sender, EventArgs e)
        {
            if (intvType == (int)Utility.VOUCHER_TYPE.vtSTOCK_TRANSFER)
            {
                string strcheck = objWIS.mCheckStockRequisition(strComID, DG.CurrentRow.Cells[0].Value.ToString());
                if (strcheck != "")
                {
                    MessageBox.Show(strcheck);
                    return;
                }
            }
            if (onAddAllButtonClicked != null)
                onAddAllButtonClicked(GetSelectedItem(), sender, e);
            this.Dispose();
        }

        private List<StockItem > GetSelectedItem()
        {
            List<StockItem> items = new List<StockItem>();
            StockItem itm = new StockItem();
            itm.strRefNo = DG.CurrentRow.Cells[0].Value.ToString();
            itm.strDate = DG.CurrentRow.Cells[2].Value.ToString();
            itm.strNarration = DG.CurrentRow.Cells[4].Value.ToString();
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
