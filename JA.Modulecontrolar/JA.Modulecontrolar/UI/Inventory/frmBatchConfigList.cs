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
using Microsoft.Win32;


namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmBatchConfigList : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<Batch> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public string strPreserveSQl { get; set; }
        private string strComID { get; set; }
        private ListBox lstFindWhat = new ListBox();
        private ListBox lstExpression = new ListBox();
        public frmBatchConfigList()
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

        private void frmBatchConfigList_Load(object sender, EventArgs e)
        {
            string strFDate,strTdate;
            DG.AllowUserToAddRows = false;
            strFDate =Utility.FirstDayOfMonth(DateTime.Now).ToString("dd-MM-yyyy");
            strTdate=Utility.LastDayOfMonth(DateTime.Now).ToString("dd-MM-yyyy");
            mLoadFind();
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "Sl No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Batch No", "Batch No", 140, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 160, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Location Name", "Location Name", 160, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Start Date", "Start Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Expire Date", "Expire Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Status", "Status", 90, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("strSQL", "strSQL", 100, false, DataGridViewContentAlignment.TopLeft, true));
            mLoadbatchList("", strFDate, strTdate);
           
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

                strPreserveSQl = "";
                //mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text);
                mLoadbatchList("",uctxtFromDate.Text,uctxtToDate.Text);
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
            strPreserveSQl = "";
            DG.Focus();


        }
        private void uctxtExpression_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                strPreserveSQl = "";
                if (lstExpression.Visible)
                {
                    if (lstExpression.Items.Count > 0)
                    {
                        uctxtExpression.Text = lstExpression.Text;
                    }
                }
                //mFetchRecord(uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text);
                mLoadbatchList(uctxtExpression.Text,"","");
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
            strPreserveSQl = "";
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
                lstExpression.DataSource = invms.gFillStockItemAllWithoutGodown(strComID, false, Utility.gstrUserName, "").ToList();
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
                    lstExpression.DataSource = invms.gFillStockItemAllWithoutGodown(strComID, false, Utility.gstrUserName, "").ToList();

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
        private void mLoadbatchList(string vstrVoucherNo,string vstrFdate,string vstrTDate)
        {
            int introw = 0;
            long lngcount = 1;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            if (strPreserveSQl == null || strPreserveSQl == "")
            {
                strPreserveSQl = "";
            }
            List<Batch> oogrp = invms.mDisPlaybatch(strComID, 0, Utility.gstrUserName, vstrVoucherNo, vstrFdate, vstrTDate, "", strPreserveSQl).ToList();
            if (oogrp.Count > 0)
            {
                foreach (Batch ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlno;
                    DG[1, introw].Value = ogrp.strLogNo;
                    DG[2, introw].Value =  Utility.gstrGetAlias(strComID, Utility.gstrGetItemCodefromBatch(ogrp.strLogNo));
                    DG[3, introw].Value = ogrp.strGodownsName;
                    DG[4, introw].Value = ogrp.strStartDate;
                    DG[5, introw].Value = ogrp.strExpireDate;
                    DG[6, introw].Value = ogrp.strStatus;
                    DG[7, introw].Value = "Edit";
                    DG[8, introw].Value = "Delete";
                    DG[9, introw].Value = ogrp.strPreserveSQL;
                    //if (introw % 2 == 0)
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                    lngcount += 1;
                }
                DG.AllowUserToAddRows = false;
                lblBatch.Text = "Total Batch : " + lngcount.ToString();
            }
        }
        private List<Batch> GetSelectedItem()
        {
            List<Batch> items = new List<Batch>();
            Batch itm = new Batch();
            itm.lngSlno = Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString());
            itm.strPreserveSQL =DG.CurrentRow.Cells[9].Value.ToString();
            items.Add(itm);
            return items;
        }
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string strmsg = "";
            if (e.ColumnIndex == 7)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                //if (Utility.gstrUserName.ToUpper() != "DEEPLAID")
                //{
                //    strmsg = Utility.mGetCheckBatchApproved(strComID, DG.CurrentRow.Cells[1].Value.ToString());

                //    if (strmsg != "")
                //    {
                //        MessageBox.Show(strmsg);
                //        return;
                //    }
                //}
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();

            }

            if (e.ColumnIndex == 8)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 3))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = invms.mDeleteBatchSize(strComID, Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString()), DG.CurrentRow.Cells[1].Value.ToString());
                    if (i == "Deleted...")
                    {
                        DG.Rows.RemoveAt(e.RowIndex);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, strFormName,
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                        }
                    }
                    MessageBox.Show(i.ToString());
                    //mLoadbatchList();
                }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            uctxtFindWhat.Text = "";
            uctxtExpression.Text = "";
            uctxtFromDate.Text = "";
            uctxtToDate.Text = "";
            PanelSearch.Visible = true;
            PanelSearch.Size = new Size(364, 195);
            PanelSearch.Location = new Point(265, 160);
            uctxtFindWhat.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PanelSearch.Visible = false;
        }


    }
}
