﻿using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Forms;
using JA.Modulecontrolar.UI.Accms.Forms;
using JA.Modulecontrolar.JINVMS;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmCommissionN : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstUnder = new ListBox();
        private ListBox lstBranch = new ListBox();
        private ListBox lstMedicalRep = new ListBox();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public long lngFormPriv { get; set; }
        public int lngLedgeras { get; set; }
        private bool mblnNumbMethod { get; set; }
        public int m_action { get; set; }
        List<Invoice> ooPartyName;
        private string strComID { get; set; }
        public frmCommissionN()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.uctxtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtVoucherNo_KeyPress);
            this.dteVoucherDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteVoucherDate_KeyPress);
            this.dteFDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFDate_KeyPress);
            this.dteVoucherDate.GotFocus += new System.EventHandler(this.dteVoucherDate_GotFocus);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
           

            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);
            this.uctxtMedicalRep.KeyDown += new KeyEventHandler(uctxtMedicalRep_KeyDown);
            this.uctxtMedicalRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMedicalRep_KeyPress);
            this.uctxtMedicalRep.TextChanged += new System.EventHandler(this.uctxtMedicalRep_TextChanged);
            this.uctxtMedicalRep.GotFocus += new System.EventHandler(this.uctxtMedicalRep_GotFocus);
            this.uctxtMedicalRep.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uctxtMedicalRep_KeyUp);

            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);

            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.txtNarr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNarr_KeyPress);
            this.DG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DG_KeyDown);

            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch);
        }
        private void DG_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                e.SuppressKeyPress = true;
                int iColumn = DG.CurrentCell.ColumnIndex;
                int iRow = DG.CurrentCell.RowIndex;
                if (iRow == DG.Rows.Count - 1)
                    txtNarr.Focus();
                else
                    DG.CurrentCell = DG[iColumn, iRow+1];


            }
        }
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
        private void mloadParty()
        {
            int introw = 0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID).ToList();

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
                    if (introw % 2 == 0)
                    {
                        DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    }
                    introw += 1;
                }

                DGMr.AllowUserToAddRows = false;
            }
        }
       
        #region "Getconfig"
        private void DGMr_DoubleClick(object sender, EventArgs e)
        {

            if (DGMr.SelectedRows.Count > 0)
            {
                int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
                uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                uctxtMedicalRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                if (btnCommission.Enabled)
                {
                    btnCommission.Focus();
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
                uctxtMedicalRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                DGMr.Visible = false;
                if (btnCommission.Enabled)
                {
                    btnCommission.Focus();
                }
            }
        }
        private void uctxtMedicalRep_KeyUp(object sender, KeyEventArgs e)
        {
           
                SearchListViewPartyName(ooPartyName, uctxtMedicalRep.Text);
           
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
                    if (i % 2 == 0)
                    {
                        DGMr.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        DGMr.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    i += 1;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, 3).ToList();
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
                // mintIsPrin = ooVtype[0].intVoucherNoMethod;
            }

        }
        #endregion
        private void frmCommission_Load(object sender, EventArgs e)
        {
           
            mGetConfig();
            mClear();
            DGCC.Columns.Clear();
            this.DG.DefaultCellStyle.Font = new Font("verdana", 10);


            DGCC.Columns.Add(Utility.Create_Grid_Column("Month ID", "Month ID", 90, true, DataGridViewContentAlignment.TopLeft, false));
            DGCC.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 90, true, DataGridViewContentAlignment.TopLeft, false));
            //DGCC.Columns.Add(Utility.CreateChkBxGrd ("", "", 90, true, DataGridViewContentAlignment.TopLeft, true,true,""));
            DGCC.Columns[0].ReadOnly = true;
            DGCC.Columns[1].ReadOnly = true;
            DGCC.AllowUserToAddRows = false;

            DG.Columns.Clear();
            this.DG.DefaultCellStyle.Font = new Font("verdana", 10);


            DG.Columns.Add(Utility.Create_Grid_Column("Ledger", "Ledger", 310, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Comm.(%)", "Comm.(%)", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 120, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Incen.Comm.(%)", "Incen.Comm.(%)", 120, false, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Net Amount", "Net Amount", 110, true, DataGridViewContentAlignment.TopLeft, true));

        

            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID,Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranch.Visible = false;
            lstMedicalRep.Visible = false;
            mloadParty();
            dteVoucherDate.Select();
            dteVoucherDate.Focus();
            
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
        #region "User define"
        private void dteVoucherDate_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstBranch.Visible = false;
            DGMr.Visible = false;
        }
       
        private void txtNarr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtNarr, uctxtMedicalRep);
            }
        }

        private void uctxtMedicalRep_TextChanged(object sender, EventArgs e)
        {
            //lstMedicalRep.SelectedIndex = lstMedicalRep.FindString(uctxtMedicalRep.Text);
        }
        private void uctxtMedicalRep_GotFocus(object sender, System.EventArgs e)
        {

          


        }
        private void lstMedicalRep_DoubleClick(object sender, EventArgs e)
        {
            uctxtMedicalRep.Text = lstMedicalRep.Text;
            lstMedicalRep.Visible = false;
            dteFDate.Focus();
        }
        private void uctxtMedicalRep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtMedicalRep.Text == "")
                {
                    if (btnCommission.Enabled)
                    {
                        btnCommission.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
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
                        uctxtMedicalRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                        DGMr.Visible = false;
                        if (btnCommission.Enabled)
                        {
                            btnCommission.Focus();
                        }
                        else
                        {
                            btnSave.Focus();
                        }
                    }
                }
                else
                {
                    int i = 0;

                    uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
                    uctxtTeritorryName.Text = DGMr.Rows[i].Cells[1].Value.ToString();
                    uctxtMedicalRep.Text = DGMr.Rows[i].Cells[2].Value.ToString();
                    DGMr.Visible = false;
                    if (btnCommission.Enabled)
                    {
                        btnCommission.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }
            }
            if (e.KeyChar==(char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtMedicalRep, uctxtBranch);
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

            DGMr.Top = uctxtMedicalRep.Top + 25;
            DGMr.Left = uctxtMedicalRep.Left;
            DGMr.Width = uctxtMedicalRep.Width;
            DGMr.Height = 240;
            DGMr.BringToFront();
            DGMr.AllowUserToAddRows = false;
            return;

        }


        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnCommission.Focus();
            }
        }
        private void dteFDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteToDate.Focus();
            }
        }
        private void dteVoucherDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBranch.Focus();
            }
        }
        private void uctxtVoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteVoucherDate.Focus();
            }
        }
        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranch.Text = lstBranch.Text;
            uctxtMedicalRep.Focus();
            lstBranch.Visible = false;
        }

        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstBranch.Text;


                    uctxtMedicalRep.Focus();
                    lstBranch.Visible = false;
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBranch, sender, e);
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

        private void uctxtBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = true;
            //lstUnder.Visible = false;

            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        #endregion

        
        private void btnNew_Click(object sender, EventArgs e)
        {
            mClear();
            frmAccountsVoucherList objfrm = new frmAccountsVoucherList();
            objfrm.mintVType = 3;
            objfrm.mintSp = 1;
            objfrm.onAddAllButtonClicked = new frmAccountsVoucherList.AddAllClick(DisplayVoucherList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
            dteVoucherDate.Focus();

        }
        #region "Display Voucher"
        private void DisplayVoucherList(List<AccountsVoucher> tests, object sender, EventArgs e)
        {
            try
            {
                int introw = 0;
                string strteritorryCode = "";
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DG.Rows.Clear();
                //dgCopyGrid.Rows.Clear();
                //DgCostCenter.Rows.Clear();
                uctxtOldNo.Text = tests[0].strVoucherNo;
                btnCommission.Enabled = false;
                List<AccountsVoucher> ooaccVou = accms.DisplayCompVoucherList(strComID, tests[0].strVoucherNo, 3).ToList();
                if (ooaccVou.Count > 0)
                {
                    foreach (AccountsVoucher oCom in ooaccVou)
                    {
                        uctxtVoucherNo.Text = Utility.Mid(oCom.strVoucherNo, 6, oCom.strVoucherNo.Length - 6);
                        dteVoucherDate.Text = oCom.strTranDate;
                        uctxtBranch.Text = Utility.gstrGetBranchName(strComID, oCom.strBranchID);
                        txtNarr.Text = oCom.strNarration;
                        uctxtMedicalRep.Text =oCom.strLedgerName;
                        uctxtMonthID.Text = oCom.strMonthID;
                        strteritorryCode = Utility.GetTeritorryCodeFromLedgerName(strComID, oCom.strLedgerName);
                        uctxtTerritoryCode.Text = strteritorryCode;
                        uctxtTeritorryName.Text = Utility.GetTeritorryName(strComID, strteritorryCode);
                        List<AccountsVoucher> ooVouList = accms.DisplayVoucherList(strComID, tests[0].strVoucherNo, 3).ToList();
                        if (ooVouList.Count > 0)
                        {

                            foreach (AccountsVoucher oacc in ooVouList)
                            {
                                DG.Rows.Add();
                                DG[0, introw].Value = oacc.strLedgerName;
                                DG[1, introw].Value = oacc.strAgnstRefNo;
                                DG[2, introw].Value = oacc.dblDebitAmount;
                                DG[4, introw].Value = oacc.dblDebitAmount;
                                introw += 1;
                            }
                            DG.AllowUserToAddRows = false;
                            
                        }
                        introw = 0;
                        List<AccountdGroup> oogrp = accms.mDisplayMonthTarget(strComID, dteFDate.Text, dteToDate.Text, uctxtMedicalRep.Text).ToList();
                        if (oogrp.Count > 0)
                        {
                            foreach (AccountdGroup ogrp in oogrp)
                            {
                                DGCC.Rows.Add();
                                if (uctxtMonthID.Text == ogrp.strMonthID)
                                {
                                    DGCC[0, introw].Style.BackColor = Color.Red;
                                    uctxtAmount.Text = ogrp.dblAmount.ToString();
                                }
                                DGCC[0, introw].Value = ogrp.strMonthID;
                                DGCC[1, introw].Value = ogrp.dblAmount;
                                introw += 1;
                            }
                        }
                        List<AccountdGroup> oForm = accms.mGetDateFromMonthID(strComID, uctxtMonthID.Text).ToList();
                        if (oForm.Count>0)
                        {
                            dteFDate.Text = oForm[0].strFromdate;
                            dteToDate.Text = oForm[0].strTodate;
                        }

                        txtCashCollection.Text = Utility.gGetReceiptAmountOfParty(strComID, uctxtMedicalRep.Text, 1, 0, dteFDate.Text, dteToDate.Text).ToString();
                        txtVoucherColl.Text = Utility.gGetReceiptAmountVoucher(strComID, uctxtMedicalRep.Text, 3, 1, dteFDate.Text, dteToDate.Text).ToString();
                        txttotalAmt.Text = (Utility.Val(txtCashCollection.Text) + Utility.Val(txtVoucherColl.Text)).ToString();
                        calculateTotal();

                    }
                }


            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        private void mLoadGroupList()
        {
            int introw = 0;
            double dblFromAmnt = 0,dblToAmnt=0,dblPercentage=0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<AccountsLedger> oogrp = accms.mDisplayLedgerlistt(strComID, 203).ToList();
            if (oogrp.Count > 0)
            {

                foreach (AccountsLedger ogrp in oogrp)
                {
                    DG.Rows.Add();
                 
                   // DG[0, introw].Value = ogrp.strConfigkey;
                    DG[0, introw].Value = ogrp.strLedgerName;
                    DG[1, introw].Value = 0;
                    DG[2, introw].Value = 0;
                    DG[3, introw].Value = 0;
                    DG[4, introw].Value = 0;
                    //DG.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    //DG.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    //DG.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //DG.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                 

                    List<AccountsLedger> oLedger = accms.mDisplayLedgerPercen(strComID, ogrp.strLedgerName).ToList();
                    foreach (AccountsLedger oled in oLedger)
                    {
                        dblFromAmnt = oled.dblFromAmt;
                        dblToAmnt = oled.dblToAmt;
                        dblPercentage = oled.dblConfigPer;
                        if (Utility.Val(txttotalAmt.Text) > dblFromAmnt && Utility.Val(txttotalAmt.Text) < dblToAmnt)
                        {
                            DG[1, introw].Value = oled.dblConfigPer.ToString();
                            DG[2, introw].Value = (Utility.Val(txttotalAmt.Text) * dblPercentage) / 100;
                            DG[3, introw].Value =0;
                            DG[4, introw].Value = (Utility.Val(txttotalAmt.Text) * dblPercentage) / 100;
                        }
                        else
                        {
                            DG[1, introw].Value = 0;
                            DG[2, introw].Value = 0;
                            DG[3, introw].Value = 0;
                            DG[4, introw].Value = 0;
                        }
                        
                    }
                   
                    introw += 1;
                }
                calculateTotal();
                DG.AllowUserToAddRows = false;
            }
        }
        private void btnCommission_Click(object sender, EventArgs e)
        {
            int introw = 0;
            this.DGCC.DefaultCellStyle.Font = new Font("verdana", 9);

            DGCC.Rows.Clear();
            txtCashCollection.Text = Utility.gGetReceiptAmountOfParty(strComID, uctxtMedicalRep.Text, 1, 0, dteFDate.Text, dteToDate.Text).ToString();
            txtVoucherColl.Text = Utility.gGetReceiptAmountVoucher(strComID, uctxtMedicalRep.Text, 3, 1, dteFDate.Text, dteToDate.Text).ToString();
            txttotalAmt.Text = (Utility.Val(txtCashCollection.Text) + Utility.Val(txtVoucherColl.Text)).ToString();
            List<AccountdGroup> oogrp = accms.mDisplayMonthTarget(strComID, dteFDate.Text, dteToDate.Text, uctxtMedicalRep.Text).ToList();
            if (oogrp.Count > 0)
            {
                foreach (AccountdGroup ogrp in oogrp)
                {
                    DGCC.Rows.Add();
                    if (uctxtMonthID.Text == ogrp.strMonthID)
                    {
                        DGCC[0, introw].Style.BackColor = Color.Red;
                        uctxtAmount.Text = ogrp.dblAmount.ToString();
                    }
                    DGCC[0, introw].Value = ogrp.strMonthID;
                    DGCC[1, introw].Value = ogrp.dblAmount;
                    introw += 1;
                }
            }

            mLoadGroupList();
            DG.Focus();
            SendKeys.Send("{tab}");
            SendKeys.Send("{tab}");


        }


        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblTotalAmount = 0;

            for (int i = 0; i < DG.Rows.Count; i++)
            {
                if (DG.Rows[i].Cells[4].Value != null)
                {
                    
                    dblTotalAmount = dblTotalAmount + Utility.Val(DG.Rows[i].Cells[4].Value.ToString());
                }
            }

           
            txtFTotal.Text = dblTotalAmount.ToString();

        }
        #endregion

      

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dblAmnt = 0,dblAmount1=0;
            if (e.ColumnIndex == 2)
            {
                if (DG[1, e.RowIndex].Value != null)
                {
                    dblAmnt =  Convert.ToDouble(DG[1, e.RowIndex].Value.ToString());
                }
                else
                {
                    dblAmnt = dblAmnt;
                }
                if (DG[2, e.RowIndex].Value != null)
                {
                    dblAmount1 = Convert.ToDouble(DG[2, e.RowIndex].Value.ToString());
                }
                else
                {
                    dblAmount1 = dblAmount1;
                }
                if (dblAmnt > 0)
                {
                    DG[2, e.RowIndex].Value = DG[4, e.RowIndex].Value;
                   
                }
                else
                {
                    DG[3, e.RowIndex].Value = dblAmount1;
                    DG[4, e.RowIndex].Value = dblAmount1;
                }

            }
            calculateTotal();

        }
        private void mClear()
        {
            DG.Rows.Clear();
            DGCC.Rows.Clear();
            txtDrCr.Text = "Cr";
            uctxtMedicalRep.Text = "";
            txtCashCollection.Text = "";
            txtCollComit.Text = "";
            txtVoucherColl.Text = "";
            uctxtTeritorryName.Text = "";
            uctxtTerritoryCode.Text = "";
            txttotalAmt.Text = "";
            txtFTotal.Text = "";
            List<AccountdGroup> oogrp = accms.mDisplayMonthsetupList(strComID, "1").ToList();
            if (oogrp.Count > 0)
            {
                uctxtMonthID.Text = oogrp[0].strMonthID;
                dteFDate.Text = oogrp[0].strFromdate;
                dteToDate.Text = oogrp[0].strTodate;
            }
            if (mblnNumbMethod)
            {
                uctxtVoucherNo.ReadOnly = true;
                uctxtVoucherNo.Text = Utility.gstrLastNumber(strComID, 3);
            }
            else
            {
                uctxtVoucherNo.ReadOnly = false;
                uctxtVoucherNo.Text = Utility.gobjNextNumber(uctxtVoucherNo.Text);
            }
            if (uctxtVoucherNo.ReadOnly==false)
            {
                uctxtVoucherNo.Focus();
            }
            else
            {
                dteVoucherDate.Focus();
            }
        }
        #region "Populate Grid"
        private string PopulatedGrid(string vstrRefNumber)
        {
            string strBranchID = "", strNarration = "", strDrCr = "", strLedgerName = "", strChecuqueNo = "",
                               strCheckDate = "", strDrwanon = "", strSingleNarration = "", strReverseLedger = "",
                                  strVoucherGrid = "";
            long lngLedgergroup = 0, intCashFlow = 0;
            int intLedgerCount = 0;
            //string i = "";
            //int intRow;
            double dbldebitAmount = 0, dblcreditAmount = 0, dblPercentage=0;



            //strBranchID = Utility.gstrGetBranchID(txtBranchName.Text);
            intLedgerCount = DG.Rows.Count;
            for (int intvrow = 0; intvrow < DG.Rows.Count; intvrow++)
            {
                if (intLedgerCount > 2)
                {
                    strReverseLedger = "As Per Details";
                }
                else if (intvrow == 0)
                {
                    strReverseLedger = DG.Rows[1].Cells[1].Value.ToString();
                }
                else if (intvrow == 1)
                {
                    strReverseLedger = DG.Rows[0].Cells[1].Value.ToString();
                }
                if (DG.Rows[intvrow].Cells[1].Value != null)
                {
                    lngLedgergroup = (long)(Utility.gGetLedgergroup(strComID, DG.Rows[intvrow].Cells[0].Value.ToString()));

                    if (lngLedgergroup <= 101)
                    {
                        intCashFlow = 1;
                    }


                    strDrCr = "Dr";
                    strLedgerName = DG[0, intvrow].Value.ToString();
                    if (DG[4, intvrow].Value != null)
                    {
                        dbldebitAmount = Convert.ToDouble(DG[4, intvrow].Value.ToString());
                    }
                    else
                    {
                        dbldebitAmount = 0;
                    }
                    if (DG[1, intvrow].Value != null)
                    {
                        dblPercentage = Convert.ToDouble(DG[1, intvrow].Value.ToString());
                    }
                    else
                    {
                        dblPercentage = 0;
                    }


                    if (dbldebitAmount > 0)
                    {

                        strVoucherGrid = strVoucherGrid + strDrCr + "|" + strLedgerName + "|" + strReverseLedger + "|" + intCashFlow + "|"
                                                      + "|" + dbldebitAmount + "|" + dblcreditAmount + "|" + strSingleNarration + "|" + strNarration + "|" +
                                                               strChecuqueNo + "|" + strCheckDate + "|" + strDrwanon + "|" + dblPercentage + "~";
                    }
                }
            }

            if (Utility.Val(txtFTotal.Text) > 0)
            {
                dblcreditAmount = Utility.Val(txtFTotal.Text);
                dbldebitAmount = 0;
                strDrCr = "Cr";
                strVoucherGrid = strVoucherGrid + strDrCr + "|" + uctxtMedicalRep.Text + "|" + strReverseLedger + "|" + intCashFlow + "|"
                                             + "|" + dbldebitAmount + "|" + dblcreditAmount + "|" + strSingleNarration + "|" + strNarration + "|" +
                                                      strChecuqueNo + "|" + strCheckDate + "|" + strDrwanon + "|" + dblPercentage + "~";
            }

            return strVoucherGrid;
        }
        #endregion
        private string mSave()
        {
            string  strDGvoucher, strRefNumber = "", strBranchID = "", strNarration = "", strReverseLedger = "",  strLedgerName = "", strVdate, strMonthID;
            int intLedgerCount, intCashFlow = 0;
           
            double dbldebitAmount = 0, dblcreditAmount = 0;
            int intvtype = (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER;
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            strNarration = txtNarr.Text.Replace("'", "''");

            if (mblnNumbMethod == false)
            {
                strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intvtype) + strBranchID + uctxtVoucherNo.Text;
            }
            else
            {
                strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intvtype) + strBranchID + Utility.gstrLastNumber(strComID, intvtype);
            }

            strVdate = dteVoucherDate.Text;
            strMonthID = dteVoucherDate.Value.ToString("MMMyy").ToUpper();
            intLedgerCount = DG.Rows.Count;
            strLedgerName = uctxtMedicalRep.Text;
            strDGvoucher = PopulatedGrid(strRefNumber);
            string i = accms.SaveVoucher(strComID, strDGvoucher, "Dr", strRefNumber, intvtype, strVdate, strMonthID, strVdate, strLedgerName, strReverseLedger, 1, intCashFlow,
                                                   "", Convert.ToDouble(txtFTotal.Text), Convert.ToDouble(txtFTotal.Text), 0, 0, dbldebitAmount, dblcreditAmount, 0, 0, "", 0, 0, "", strNarration,
                                                   strBranchID, "", "", mblnNumbMethod, 0, "", "", "", "", "", "", "", "", "", "", 1);

             return i;
           


           
        }

        private string mUpdate()
        {
            string strRefNumber = "", strBranchID = "", strNarration = "", strReverseLedger = "",  strLedgerName = "", strVdate, strMonthID, strDGvoucher;
            int intLedgerCount, intCashFlow = 0;
            double dbldebitAmount = 0, dblcreditAmount = 0;
            int intvtype = (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER;
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            strNarration = txtNarr.Text.Replace("'", "''");

            strVdate = dteVoucherDate.Text;
            strMonthID = dteVoucherDate.Value.ToString("MMMyy").ToUpper();
            intLedgerCount = DG.Rows.Count;
            strLedgerName = uctxtMedicalRep.Text;

            strDGvoucher = PopulatedGrid(strRefNumber);
            string i = accms.UpdateVoucher(strComID, strDGvoucher, "", uctxtOldNo.Text, intvtype, strVdate, strMonthID, strVdate, strLedgerName, strReverseLedger, 1, intCashFlow,
                                                  "", 0, Convert.ToDouble(txtFTotal.Text), 0, 0, dbldebitAmount, dblcreditAmount, 0, 0, "", 0, 0, "", strNarration,
                                                  strBranchID, "", "", 0, "", "", "", "", "", "", "", "", "", "");

            return i;
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (uctxtMedicalRep.Text == "")
            {
                MessageBox.Show("Cannot be empty");
                uctxtMedicalRep.Focus();
                return;
            }
            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Cannot be empty");
                uctxtBranch.Focus();
                return;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                    MessageBox.Show("You have no Permission to Access");
                    return;
                }
            }

            if (m_action ==(int)Utility.ACTION_MODE_ENUM.ADD_MODE)
            {
                string s = mSave();
                if (s=="1")
                {
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Commission Configuration", "Commission Configuration",
                                                                1, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                    } 
                    mClear();
                }
            }
            else
            {
                string k = mUpdate();
                if (k == "1")
                {
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Commission Configuration", "Commission Configuration",
                                                                2, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                    } 
                    mClear();
                }
            }
          

        }






    }



}