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
using System.Data.SqlClient;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmStockStationaryReturn : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstFromLocation = new ListBox();
        private ListBox lstToLocation = new ListBox();

        public int m_action { get; set; }
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        private string strComID { get; set; }
        List<InvoiceConfig> oinv;
        public int mintVtype { get; set; }
        List<StockItem> objStockitem;

        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWIS = new SPWOIS();
        public frmStockStationaryReturn()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            #region "User In"
            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.dteDate_GotFocus);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtQty_KeyPress);
            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);
            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);

            this.uctxtFromLocation.KeyDown += new KeyEventHandler(uctxtFromLocation_KeyDown);
            this.uctxtFromLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFromLocation_KeyPress);
            this.uctxtFromLocation.TextChanged += new System.EventHandler(this.uctxtFromLocation_TextChanged);
            this.lstFromLocation.DoubleClick += new System.EventHandler(this.lstFromLocation_DoubleClick);
            this.uctxtFromLocation.GotFocus += new System.EventHandler(this.uctxtFromLocation_GotFocus);

            this.uctxtToLocation.KeyDown += new KeyEventHandler(uctxtToLocation_KeyDown);
            this.uctxtToLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtToLocation_KeyPress);
            this.uctxtToLocation.TextChanged += new System.EventHandler(this.uctxtToLocation_TextChanged);
            this.lstToLocation.DoubleClick += new System.EventHandler(this.lstToLocation_DoubleClick);
            this.uctxtToLocation.GotFocus += new System.EventHandler(this.uctxtToLocation_GotFocus);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);


            Utility.CreateListBox(lstFromLocation, pnlMain, uctxtFromLocation);
            Utility.CreateListBox(lstToLocation, pnlMain, uctxtToLocation);

            #endregion

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Keys.Escape == keyData)
            {
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }

            return false;
        }
        #region "PriorSetFocus"
        private void PriorSetFocusText(TextBox txtbox, object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Back)
            {
                if (txtbox.SelectionLength > 0)
                {
                    txtbox.SelectionLength = 0;

                    this.SelectNextControl((Control)sender, false, true, true, true);
                }
                else
                {
                    if ((e.KeyChar == (char)Keys.Back) & (((Control)sender).Text.Length == 0))
                    {

                        this.SelectNextControl((Control)sender, false, true, true, true);
                    }
                }
            }


        }
        #endregion
        #region "User Define"

        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {

            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;


        }

        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {

            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;

        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                btnNext.PerformClick();

            }

        }
        private void uctxtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtNarration, sender, e);
            }
        }
        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {

            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;
            //uclstGrdItem.Visible = false;

        }
        private void dteDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtFromLocation.Focus();

            }

        }
        private void dteDate_GotFocus(object sender, System.EventArgs e)
        {

            lstFromLocation.Visible = false;
            lstToLocation.Visible = false;


        }
        private void uctxtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                dteDate.Focus();

            }
        }


        private void uctxtToLocation_TextChanged(object sender, EventArgs e)
        {
            lstToLocation.SelectedIndex = lstToLocation.FindString(uctxtToLocation.Text);
        }

        private void lstToLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtToLocation.Text = lstToLocation.Text;
            lstToLocation.Visible = false;
            //uctxtItemName.Focus();
        }

        private void uctxtToLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstToLocation.Items.Count > 0)
                {
                    uctxtToLocation.Text = lstToLocation.Text;
                }
                lstToLocation.Visible = false;
                //uctxtItemName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtToLocation, sender, e);
            }
        }
        private void uctxtToLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstToLocation.SelectedItem != null)
                {
                    lstToLocation.SelectedIndex = lstToLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstToLocation.Items.Count - 1 > lstToLocation.SelectedIndex)
                {
                    lstToLocation.SelectedIndex = lstToLocation.SelectedIndex + 1;
                }
            }

        }

        private void uctxtToLocation_GotFocus(object sender, System.EventArgs e)
        {

            lstFromLocation.Visible = false;
            lstToLocation.Visible = true;



            lstToLocation.SelectedIndex = lstToLocation.FindString(uctxtToLocation.Text);
        }


        private void uctxtFromLocation_TextChanged(object sender, EventArgs e)
        {
            lstFromLocation.SelectedIndex = lstFromLocation.FindString(uctxtFromLocation.Text);
        }

        private void lstFromLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtFromLocation.Text = lstFromLocation.Text;
            uctxtToLocation.Focus();
        }

        private void uctxtFromLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstFromLocation.Items.Count > 0)
                {
                    uctxtFromLocation.Text = lstFromLocation.Text;
                }

                uctxtToLocation.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtFromLocation, sender, e);
            }
        }

        private void uctxtFromLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstFromLocation.SelectedItem != null)
                {
                    lstFromLocation.SelectedIndex = lstFromLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstFromLocation.Items.Count - 1 > lstFromLocation.SelectedIndex)
                {
                    lstFromLocation.SelectedIndex = lstFromLocation.SelectedIndex + 1;
                }
            }

        }

        private void uctxtFromLocation_GotFocus(object sender, System.EventArgs e)
        {

            lstFromLocation.Visible = true;
            lstToLocation.Visible = false;


            lstFromLocation.SelectedIndex = lstFromLocation.FindString(uctxtFromLocation.Text);
        }



        #endregion

        #region "Getconfig"
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, mintVtype).ToList();
            if (ooVtype.Count > 0)
            {
                if (ooVtype[0].intVoucherNoMethod == 0)
                {
                    mblnNumbMethod = true;
                }
                else
                {
                    mblnNumbMethod = false;
                }
                mintIsPrin = ooVtype[0].intVoucherNoMethod;
            }


        }
        #endregion
        private void frmStockStationaryReturn_Load(object sender, EventArgs e)
        {

            mGetConfig();
            mClear(); ;
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            lstFromLocation.Visible = false;

            DG.AllowUserToAddRows = false;
            DGright.AllowUserToAddRows = false;
            frmLabel.Text = "Stationary Return";

            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "SL NO", 400, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 250, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("QTY", "QTY", 100, true, DataGridViewContentAlignment.TopLeft, true));

            DGright.Columns.Add(Utility.Create_Grid_Column("SL No", "SL NO", 400, false, DataGridViewContentAlignment.TopLeft, true));
            DGright.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DGright.Columns.Add(Utility.Create_Grid_Column("QTY", "QTY", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DGright.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));

            lstToLocation.ValueMember = "strLocation";
            lstToLocation.DisplayMember = "strLocation";
            lstToLocation.DataSource = invms.gLoadLocation(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName, 2).ToList();



            lstFromLocation.ValueMember = "strLocation";
            lstFromLocation.DisplayMember = "strLocation";
            lstFromLocation.DataSource = invms.gLoadLocation(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName, 2).ToList();



        }
        private void mClear()
        {
            uctxtFromLocation.Text = "";
            uctxtToLocation.Text = "";
            DG.Rows.Clear();
        }


        #region "Validation Field"
        private bool ValidateFields()
        {



            if (uctxtFromLocation.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtFromLocation.Focus();
                return false;
            }


            if (uctxtFromLocation.Text.TrimStart() == uctxtToLocation.Text.TrimStart())
            {
                MessageBox.Show("Both Location Cannot be Same");
                uctxtFromLocation.Focus();
                return false;
            }

            string strLockvoucher = Utility.gLockVocher(strComID, mintVtype);
            long lngDate = Convert.ToInt64(Convert.ToDateTime(dteDate.Text).ToString("yyyyMMdd"));
            if (strLockvoucher != "")
            {
                long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strLockvoucher).ToString("yyyyMMdd"));
                if (lngDate <= lngBackdate)
                {
                    MessageBox.Show("Invalid Date, Back Date is locked");
                    return false;
                }
            }




            return true;
        }

        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "";
            if (ValidateFields() == false)
            {
                return;
            }

            try
            {

                string strSQL = "", strBillKey = "", strRefNo = "", strBranchId = "", strNarrations = "",
                    strDate = "", strItemName = "", strGodownName = "", strUOm = "";
                SqlCommand cmdQuery = new SqlCommand();
                SqlDataReader dr;
                long lngSlNo, lngloop = 1;
                double dblqty = 0, dblRate = 0, dblTotalAmount = 0;
                SqlCommand cmdInsert = new SqlCommand();
                string connstring = Utility.SQLConnstringComSwitch(strComID);

                using (SqlConnection gcnMain = new SqlConnection(connstring))
                {
                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }
                    gcnMain.Open();

                    cmdQuery.Connection = gcnMain;

                    strDate = dteDate.Text;
                    strBranchId = Utility.gstrGetBranchID(strComID, uctxtFromLocation.Text);
                    strGodownName = uctxtFromLocation.Text;
                    strRefNo = "TS" + strBranchId + Utility.gstrLastNumber(strComID, 60);
                    strNarrations = uctxtNarration.Text;



                    for (int introw = 0; introw < DGright.Rows.Count; introw++)
                    {
                        lngSlNo = Convert.ToInt64(DGright[0, introw].Value);



                        strItemName = DGright[1, introw].Value.ToString();
                        dblqty = Convert.ToDouble(DGright[2, introw].Value.ToString());
                        dblRate = Utility.gdblGetCostPriceNew(strComID, strItemName, strDate);
                        dblTotalAmount = Math.Round(dblqty * dblRate, 2);


                        SqlTransaction myTrans;
                        myTrans = gcnMain.BeginTransaction();
                        cmdInsert.Connection = gcnMain;
                        cmdInsert.Transaction = myTrans;

                        if (introw == 0)
                        {
                            strSQL = VoucherSW.gInsertmasterNew(strRefNo, strBranchId, 60, strDate, 0,
                                                        strNarrations, "", 0, "", "0", 6, "");
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();

                            strSQL = VoucherSW.gIncreaseVoucher(60);
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        strBillKey = strRefNo + lngloop.ToString().PadLeft(4, '0');
                        strSQL = VoucherSW.mInsertTranInward(strBillKey, lngloop, strRefNo, strItemName, 60,
                                                                    strDate, dblqty, dblRate, uctxtToLocation.Text, dblTotalAmount, "I",
                                                                    strBranchId, "", "", strUOm, strUOm, "", 0, 0, "");

                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "UPDATE INV_TRAN SET ";
                        strSQL = strSQL + "INV_TRAN_QUANTITY=INV_TRAN_QUANTITY+" + dblqty;
                        strSQL = strSQL + ",OUTWARD_QUANTITY=OUTWARD_QUANTITY+" + dblqty;
                        strSQL = strSQL + ",INV_TRAN_AMOUNT= INV_TRAN_AMOUNT -" + dblTotalAmount;
                        strSQL = strSQL + ",OUTWARD_SALES_AMOUNT=OUTWARD_SALES_AMOUNT+" + dblTotalAmount;
                        strSQL = strSQL + ",OUTWARD_COST_AMOUNT=OUTWARD_COST_AMOUNT +" + dblTotalAmount;
                        strSQL = strSQL + "WHERE INV_TRAN_SERIAL=" + lngSlNo + " ";
                        strSQL = strSQL + "AND STOCKITEM_NAME='" + strItemName.Replace("'", "''") + "' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        cmdInsert.Transaction.Commit();



                        lngloop += 1;

                    }

                    MessageBox.Show("Success");
                    DG.Rows.Clear();
                    DGright.Rows.Clear();
                    gcnMain.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                DG.Rows.RemoveAt(e.RowIndex);
                //calculateTotal();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //mClear();
            //frmStockTransferList objfrm = new frmStockTransferList();
            //objfrm.intvType = mintVtype;
            //objfrm.lngFormPriv = lngFormPriv;
            //objfrm.strFlag = "O";
            //objfrm.onAddAllButtonClicked = new frmStockTransferList.AddAllClick(DisplayVoucherList);
            //objfrm.Show();
            //objfrm.MdiParent = MdiParent;
            //uctxtInvoiceNo.Focus();
        }






        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            SqlCommand cmdQuery = new SqlCommand();
            SqlDataReader dr;
            string connstring = Utility.SQLConnstringComSwitch(strComID);

            try
            {
                using (SqlConnection gcnMain = new SqlConnection(connstring))
                {
                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }
                    gcnMain.Open();

                    cmdQuery.Connection = gcnMain;
                    DG.Rows.Clear();
                    //if (objStockitem.Count>0 )
                    //{
                    //    objStockitem.Clear();
                    //}
                    List<StockItem> objStockitem1 = new List<StockItem>();
                    strSQL = "SELECT INV_TRAN_SERIAL,STOCKITEM_NAME,INV_TRAN_QUANTITY FROM INV_TRAN WHERE INV_VOUCHER_TYPE =60    ";
                    strSQL = strSQL + "AND INV_DATE BETWEEN " + Utility.cvtSQLDateString(Utility.gdteFinancialYearFrom) + " ";
                    strSQL = strSQL + "AND  " + Utility.cvtSQLDateString(Utility.gdteFinancialYearTo) + " ";
                    strSQL = strSQL + "AND  GODOWNS_NAME='" + uctxtFromLocation.Text + "' ";
                    strSQL = strSQL + "AND  INV_INOUT_FLAG='O' ";
                    cmdQuery.CommandText = strSQL;
                    dr = cmdQuery.ExecuteReader();
                    while (dr.Read())
                    {
                        StockItem ooItem = new StockItem();
                        ooItem.lngSlNo = Convert.ToInt64(dr["INV_TRAN_SERIAL"]);
                        ooItem.strItemName = dr["STOCKITEM_NAME"].ToString();
                        ooItem.dblOpnQty = Math.Abs(Utility.Val(dr["INV_TRAN_QUANTITY"].ToString()));
                        objStockitem1.Add(ooItem);
                    }
                    if (objStockitem1.Count > 0)
                    {
                        objStockitem = objStockitem1.ToList();
                    }
                    int introw = 0;
                    foreach (StockItem row in objStockitem1)
                    {
                        DG.Rows.Add();
                        DG[0, introw].Value = row.lngSlNo;
                        DG[1, introw].Value = row.strItemName;
                        DG[2, introw].Value = Math.Abs(Utility.Val(row.dblOpnQty.ToString()));

                        introw += 1;

                    }
                    dr.Close();
                    gcnMain.Close();

                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
        }



        private void SearchListView(IEnumerable<StockItem> tests, string searchString)
        {
            IEnumerable<StockItem> query;

            query = tests;


            if (searchString != "")
            {

                query = (from test in tests
                         where test.strItemName.ToString().StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                         select test);
            }

            DG.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    DG.Rows.Add();
                    DG[0, i].Value = tran.lngSlNo;
                    DG[1, i].Value = tran.strItemName;
                    DG[2, i].Value = tran.dblOpnQty;
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                SearchListView(objStockitem, txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void mAddright(DataGridView dg, long lngSlNo, string strItemName, double dblQty)
        {
            int selRaw;
            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < dg.RowCount; j++)
            {
                if (dg[0, j].Value != null)
                {
                    strDown = dg[0, j].Value.ToString();
                }
                if (lngSlNo.ToString() == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {

                dg.AllowUserToAddRows = true;


                selRaw = Convert.ToInt16(dg.RowCount.ToString());
                selRaw = selRaw - 1;
                dg.Rows.Add();
                dg[0, selRaw].Value = lngSlNo;
                dg[1, selRaw].Value = strItemName.ToString();
                dg[2, selRaw].Value = dblQty;

                txtQty.Text = "";

                //calculateTotal();
                dg.ClearSelection();
                int nColumnIndex = 2;
                int nRowIndex = dg.Rows.Count - 1;
                dg.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                dg.FirstDisplayedScrollingRowIndex = nRowIndex;
            }

        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Text == "")
                {
                    return;
                }
                foreach (DataGridViewRow r in DG.SelectedRows)
                {

                    mAddright(DGright, Convert.ToInt64(r.Cells[0].Value.ToString()), r.Cells[1].Value.ToString(), Utility.Val(txtQty.Text.ToString()));
                    DGright.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DGright_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DGright.Rows.RemoveAt(e.RowIndex);

            }
        }
    }

}
