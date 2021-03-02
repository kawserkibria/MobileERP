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
using JA.Modulecontrolar.UI.DReport.Inventory.Viewer;
using JA.Modulecontrolar.UI.DReport.Inventory;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmMFGdilutionStoreList : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<MFGvouhcer> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        private ListBox lstFindWhat = new ListBox();
        private ListBox lstExpression = new ListBox();
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int intVtype { get; set; }
        private string strComID { get; set; }
        List<MFGvouhcer> oogrp;
        public frmMFGdilutionStoreList()
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
                mLoadList();
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
            mLoadList();
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
                mLoadList();
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
            //else if (uctxtFindWhat.Text == "Stock Item")
            //{
            //    lstExpression.Visible = true;
            //    lstFindWhat.Visible = false;
            //    uctxtExpression.Visible = true;
            //    uctxtFromDate.Visible = false;
            //    uctxtToDate.Visible = false;
            //    lblfromDate.Visible = false;
            //    lblTodate.Visible = false;
            //    lstExpression.ValueMember = "strItemName";
            //    lstExpression.DisplayMember = "strItemName";
            //    lstExpression.DataSource = invms.gFillStockItemAllWithoutGodown(strComID, false, Utility.gstrUserName, "").ToList();
            //}
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
                //else if (uctxtFindWhat.Text == "Stock Item")
                //{
                //    lstExpression.Visible = true;
                //    lstFindWhat.Visible = false;
                //    uctxtExpression.Visible = true;
                //    uctxtFromDate.Visible = false;
                //    uctxtToDate.Visible = false;
                //    lblfromDate.Visible = false;
                //    lblTodate.Visible = false;
                //    lstExpression.ValueMember = "strItemName";
                //    lstExpression.DisplayMember = "strItemName";
                //    lstExpression.DataSource = invms.gFillStockItemAllWithoutGodown(strComID, false, Utility.gstrUserName, "").ToList();

                //}
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
        private void frmMFGdilutionStoreList_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            mLoadFind();
            DG.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 450, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 250, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 250, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Preview", "Preview", "Preview", 70, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadList();
          
        }
        private void mLoadList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            if (uctxtFindWhat.Text != "")
            {
                if (uctxtFindWhat.Text == "Voucher Number")
                {
                    oogrp = invms.mLoadDilutionStore(strComID, "", "", uctxtFindWhat.Text, uctxtExpression.Text, intVtype).ToList();
                }
                else if (uctxtFindWhat.Text == "Voucher Date")
                {
                    oogrp = invms.mLoadDilutionStore(strComID, uctxtFromDate.Text, uctxtToDate.Text,"", "", intVtype).ToList();
                }
                else
                {
                    oogrp = invms.mLoadDilutionStore(strComID, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), "", "", intVtype).ToList();
                }
                
            }
            else
            {
                oogrp = invms.mLoadDilutionStore(strComID, DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), "", "", intVtype).ToList();
            }
            if (oogrp.Count > 0)
            {
                foreach (MFGvouhcer ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strBillKey;
                    DG[1, introw].Value = ogrp.strVoucherNo;
                    DG[2, introw].Value = ogrp.strDate;
                    DG[3, introw].Value = "Edit";
                    DG[4, introw].Value = "Delete";
                    DG[5, introw].Value = "Preview";
                  
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
              
            }
        }

     

        private List<MFGvouhcer> GetSelectedItem()
        {
            List<MFGvouhcer> items = new List<MFGvouhcer>();
            MFGvouhcer itm = new MFGvouhcer();
            itm.strVoucherNo = DG.CurrentRow.Cells[0].Value.ToString();
            items.Add(itm);
            return items;
        }

        private void DgProcessList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
            if (e.ColumnIndex == 4)
            {
                string strLockvoucher = Utility.gLockVocher(strComID, intVtype);
                if (strLockvoucher != "")
                {
                    long lngDate = Convert.ToInt64(Convert.ToDateTime(DG.CurrentRow.Cells[2].Value).ToString("yyyyMMdd"));
                    long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strLockvoucher).ToString("yyyyMMdd"));
                    if (lngDate <= lngBackdate)
                    {
                        MessageBox.Show("Invalid Date, Back Date is locked");
                        return;
                    }
                }
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = invms.mDeleteInvMasterTran(strComID, DG.CurrentRow.Cells[0].Value.ToString());
                    if (i == "Delted...")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, DG.CurrentRow.Cells[0].Value.ToString(),
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                        }
                    }
                    MessageBox.Show(i.ToString());

                    mLoadList();
                   
                }
            }
            if (e.ColumnIndex == 5)
            {
                if (DG.Rows.Count == 0)
                {
                    return;
                }

                //if (Utility.gblnAccessControl)
                //{
                //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 90))
                //    {
                //         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                //        return;
                //    }
                //}

                JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Inventory.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Inventory.ViewerSelector.DilutionStore;
                frmviewer.strFdate = "";
                frmviewer.strSummDetails = "Details";
                frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                frmviewer.strSelction = "C";
                frmviewer.Show();
            }

        }

      

        private void SearchListViewFG(IEnumerable<ManuProcess> tests, string searchString = "")
        {
            IEnumerable<ManuProcess> query;
         
            query = tests;

         
            if (searchString != "")
            {
                query = tests.Where(x => x.strProcessName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }
      
            DG.Rows.Clear();
            int introw = 0;
            try
            {
                foreach (ManuProcess ogrp in query)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strProcessName;
                    DG[1, introw].Value = ogrp.strGodown;
                    DG[2, introw].Value = "Edit";
                    DG[3, introw].Value = "Delete";
                    DG[4, introw].Value = "Preview";
                   
                    introw += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
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
            PanelSearch.Location = new Point(269, 255);
            uctxtFindWhat.Focus();
        }


        private void mLoadFind()
        {

            lstFindWhat.Items.Clear();
            lstFindWhat.Items.Add("Voucher Number");
            lstFindWhat.Items.Add("Voucher Date");
           

        }






    }
}
