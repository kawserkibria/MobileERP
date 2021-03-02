﻿using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Inventory;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmCollectionCommitementList : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<SalesTarget> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public string strForm;
        public long lngFormPriv { get; set; }
        public string  strFormName { get; set; }
        public string strChange { get; set; }
        private string strComID { get; set; }
        private ListBox lstFindWhat = new ListBox();
        private ListBox lstExpression = new ListBox();
        public frmCollectionCommitementList()
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
                //mVoucherList();
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
            //mVoucherList();
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
                //mVoucherList();
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
            if (uctxtFindWhat.Text == "Month ID")
            {
                lstFindWhat.Visible = false;
                lblExpression.Visible = false;
                uctxtExpression.Visible = true;
                uctxtFromDate.Visible = false;
                uctxtToDate.Visible = false;
                lblfromDate.Visible = false;
                lblTodate.Visible = false;
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
                if (uctxtFindWhat.Text == "Month ID")
                {
                    lstExpression.Visible = false;
                    lstFindWhat.Visible = false;
                    uctxtExpression.Visible = true;
                    uctxtFromDate.Visible = false;
                    uctxtToDate.Visible = false;
                    lblfromDate.Visible = false;
                    lblTodate.Visible = false;
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
            lstFindWhat.Items.Add("Voucher Date");

        }
        private void frmPriceConfigList_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
           
            if (strForm == "MC")
            {
                DG.Columns.Add(Utility.Create_Grid_Column("Key No", "Key No", 600, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Month ID", "Month ID", 60, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("From Date", "From Date", 260, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("To Date", "To Date", 350, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Branch ID", "Branch ID", 600, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 80, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Target", "Target", "Target", 80, false, DataGridViewContentAlignment.TopCenter, true));
            }
            else if (strForm == "ACTUAL")
            {
                DG.Columns.Add(Utility.Create_Grid_Column("Key No", "Key No", 600, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Month ID", "Month ID", 120, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("From Date", "From Date", 250, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("To Date", "To Date", 250, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Branch ID", "Branch ID", 600, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Actual", "Actual", "Actual", 130, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 80, false, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, false, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Process", "Process", "Process", 90, false, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Revised", "Revised", "Revised", 130, true, DataGridViewContentAlignment.TopCenter, true));
            }
            else if (strForm == "CTN")
            {
                DG.Columns.Add(Utility.Create_Grid_Column("Key No", "Key No", 600, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Month ID", "Month ID", 120, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("From Date", "From Date", 250, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("To Date", "To Date", 250, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Branch ID", "Branch ID", 600, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Actual", "Actual", "Actual", 130, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 80, false, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, false, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Process", "Process", "Process", 90, false, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Revised", "Revised", "Revised", 130, true, DataGridViewContentAlignment.TopCenter, true));
            }
            else
            {
                DG.Columns.Add(Utility.Create_Grid_Column("Key No", "Key No", 600, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Month ID", "Month ID", 70, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("From Date", "From Date", 200, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("To Date", "To Date", 300, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Branch ID", "Branch ID", 600, false, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 80, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 80, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Process", "Process", "Process", 90, true, DataGridViewContentAlignment.TopCenter, true));
                DG.Columns.Add(Utility.Create_Grid_Column_button("Target", "Target", "Target", 80, false, DataGridViewContentAlignment.TopCenter, true));
            }
          
            if (strForm  =="TA")
            {
                frmLabel.Text = "Sales Target List";
                mFillSalesTarget();
            }
            else if (strForm == "ACTUAL")
            {
                frmLabel.Text = "Sales Target List";
                mFillSalesTarget();
            }
            else if (strForm == "CTN")
            {
                frmLabel.Text = "Collection Target";
                mFillSalesCollection();
            }
            else if (strForm == "CT")
            {
                frmLabel.Text = "Collection Target";
                mFillSalesCollection();
            }
            else if (strForm == "MC")
            {
                frmLabel.Text = "Credit Limit";
                mFillCreditLimit();
            }
        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (DG.Rows.Count > 0)
            //{
            //    if (onAddAllButtonClicked != null)
            //        onAddAllButtonClicked(GetSelectedItem(e.RowIndex), sender, e);
            //    this.Dispose();
            //}
        }
        private void mFillSalesTarget()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<SalesTarget> oogrp;
            //if (uctxtFindWhat.Text != "")
            //{
            //    if (uctxtFindWhat.Text == "Voucher Date")
            //    {
            //        oogrp = invms.mFillStockTransfer(intvType, uctxtFindWhat.Text, uctxtExpression.Text, uctxtFromDate.Text, uctxtToDate.Text).ToList();
            //    }
            //}
            //else
            //{
            oogrp = invms.mFillSalesTarget(strComID).ToList();
            //}



            if (oogrp.Count > 0)
            {
                foreach (SalesTarget ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strKey;
                    DG[1, introw].Value = Convert.ToDateTime(ogrp.strFromDate).ToString("MMMyy").ToUpper();
                    DG[2, introw].Value = ogrp.strFromDate;
                    DG[3, introw].Value = ogrp.strToDate;
                    DG[4, introw].Value = ogrp.strBranchID;
                    DG[5, introw].Value = "Actual";
                    DG[6, introw].Value = "Edit";
                    DG[7, introw].Value = "Delete";
                    DG[8, introw].Value = "Process";
                    DG[9, introw].Value = "Revised";
                    //if (introw % 2 == 0)
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }
        private void mFillCreditLimit()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<SalesTarget> oogrp = invms.mFillSalesCreditLimit(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (SalesTarget ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strKey;
                    DG[1, introw].Value = Convert.ToDateTime(ogrp.strFromDate).ToString("MMMyy").ToUpper();
                    DG[2, introw].Value = ogrp.strFromDate;
                    DG[3, introw].Value = ogrp.strToDate;
                    DG[4, introw].Value = ogrp.strBranchID;

                    DG[5, introw].Value = "View";
                    DG[6, introw].Value = "Edit";
                    DG[7, introw].Value = "Delete";
                    //if (introw % 2 == 0)
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }
        private void mFillSalesCollection()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<SalesTarget> oogrp = invms.mFillSalesCollection(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (SalesTarget ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strKey;
                    DG[1, introw].Value = Convert.ToDateTime(ogrp.strFromDate).ToString("MMMyy").ToUpper();
                    DG[2, introw].Value = ogrp.strFromDate;
                    DG[3, introw].Value = ogrp.strToDate;
                    DG[4, introw].Value = ogrp.strBranchID;
                    DG[5, introw].Value = "Actual";
                    DG[6, introw].Value = "Edit";
                    DG[7, introw].Value = "Delete";
                    DG[8, introw].Value = "Process";
                    DG[9, introw].Value = "Revised";
                    //if (introw % 2 == 0)
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }
        private List<SalesTarget> GetSelectedItem(int inrow)
        {
            List<SalesTarget> items = new List<SalesTarget>();
            SalesTarget itm = new SalesTarget();
            itm.strKey = DG.Rows[inrow].Cells[0].Value.ToString();
            itm.strFromDate = DG.Rows[inrow].Cells[2].Value.ToString();
            itm.strToDate = DG.Rows[inrow].Cells[3].Value.ToString();
            itm.strBranchID  = DG.Rows[inrow].Cells[4].Value.ToString();
            items.Add(itm);
            return items;
        }

        private void DG_DoubleClick(object sender, EventArgs e)
        {
            if (DG.Rows.Count > 0)
            {
                int i = Convert.ToInt16(DG.CurrentRow.Index);
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(i), sender, e);
                this.Dispose();
            }
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==5)
            {
                JA.Modulecontrolar.UI.DReport.Sales.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Sales.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Sales.ViewerSelector.Target;
                frmviewer.strFdate = DG.CurrentRow.Cells[2].Value.ToString();
                frmviewer.strTdate = DG.CurrentRow.Cells[3].Value.ToString();
                if (strForm == "TA")
                {
                    frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                    frmviewer.strSelction = strForm;
                    frmviewer.reportTitle2 = "Sales Target";
                    frmviewer.secondParameter = "";

                }
                else if (strForm == "ACTUAL")
                {
                    frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                    frmviewer.strSelction = "TA";
                    frmviewer.reportTitle2 = "Sales Target";
                    frmviewer.secondParameter = "";

                }
                else if (strForm == "CTN")
                {
                    frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                    frmviewer.strSelction = "CT";
                    frmviewer.reportTitle2 = "Sales Target";
                    frmviewer.secondParameter = "";

                }
                else if (strForm == "CT")
                {
                    frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                    frmviewer.reportTitle2 = "Collection Target";
                    frmviewer.strSelction = strForm;
                    frmviewer.secondParameter = "";
                }
                else if (strForm == "MC")
                {
                    frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                    frmviewer.reportTitle2 = "Credit Limit";
                    frmviewer.strSelction = strForm;
                    frmviewer.secondParameter = "";
                }
                frmviewer.Show();
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
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = invms.mDeleteTarget(strComID, DG.CurrentRow.Cells[0].Value.ToString(), strForm);
                    //MessageBox.Show(i.ToString());
                    //mFillSalesCollection();
                    if (i == "Deleted...")
                    {
                        DG.Rows.RemoveAt(e.RowIndex);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, strFormName,
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                        }
                    }

                }
            }
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
                if (DG.Rows.Count > 0)
                {
                    int i = Convert.ToInt16(DG.CurrentRow.Index);
                    if (onAddAllButtonClicked != null)
                        onAddAllButtonClicked(GetSelectedItem(i), sender, e);
                    this.Dispose();
                }
            }
            if (e.ColumnIndex == 8)
            {
                //if (Utility.gblnAccessControl)
                //{
                //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 94))
                //    {
                //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}
                if (System.Windows.Forms.Application.OpenForms["frmMonthlyAutoBudget"] as frmMonthlyAutoBudget == null)
                {
                    frmMonthlyAutoBudget objfrm = new frmMonthlyAutoBudget();
                    objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                    objfrm.strFromDate = DG.CurrentRow.Cells[2].Value.ToString();
                    objfrm.strToDate = DG.CurrentRow.Cells[3].Value.ToString();
                    objfrm.lngFormPriv = 94;
                    objfrm.strType = strForm;
                    objfrm.MdiParent = this.MdiParent;
                    objfrm.Show();

                }
                else
                {
                    frmMonthlyAutoBudget objfrm = (frmMonthlyAutoBudget)Application.OpenForms["frmMonthlyAutoBudget"];
                    objfrm.lngFormPriv = 94;
                    
                    objfrm.MdiParent = this.MdiParent;
                    objfrm.Focus();
                }
            }
            if (e.ColumnIndex == 9)
            {
                JA.Modulecontrolar.UI.DReport.Sales.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Sales.Viewer.frmReportViewer();
                frmviewer.selector = JA.Modulecontrolar.UI.DReport.Sales.ViewerSelector.Target;
                frmviewer.strFdate = DG.CurrentRow.Cells[2].Value.ToString();
                frmviewer.strTdate = DG.CurrentRow.Cells[3].Value.ToString();
                if (strForm == "TA")
                {
                    frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                    frmviewer.strSelction = strForm;
                    frmviewer.reportTitle2 = "Sales Target";
                    frmviewer.secondParameter = "";

                }
                else if (strForm == "ACTUAL")
                {
                    frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                    frmviewer.strSelction = strForm;
                    frmviewer.reportTitle2 = "Sales Target";
                    frmviewer.secondParameter = "";

                }
                else if (strForm == "CTN")
                {
                    frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                    frmviewer.reportTitle2 = "Collection Target";
                    frmviewer.strSelction = strForm;
                    frmviewer.secondParameter = "";
                }
                else if (strForm == "CT")
                {
                    frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                    frmviewer.reportTitle2 = "Collection Target";
                    frmviewer.strSelction = strForm;
                    frmviewer.secondParameter = "";
                }
                else if (strForm == "MC")
                {
                    frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                    frmviewer.reportTitle2 = "Credit Limit";
                    frmviewer.strSelction = strForm;
                    frmviewer.secondParameter = "";
                }
                frmviewer.Show();
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }






    }
}
