using Dutility;
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
    public partial class frmCommission : JA.Shared.UI.frmSmartFormStandard
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
        public string mstrSQL { get; set; }
        List<Invoice> ooPartyName;
        private string strComID { get; set; }
        public frmCommission()
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
            this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);
            this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);

            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.txtNarr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNarr_KeyPress);
            this.txtNarr.KeyDown += new KeyEventHandler(txtNarr_KeyDown);
            this.DG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DG_KeyDown);

            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch);
        }
        private void txtNarr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                //txtNarration.Text = Interaction.GetSetting(Application.ExecutablePath, intvtype.ToString(), "Narration");
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                txtNarr.AppendText((String)rk.GetValue("MpoNarration" + 3.ToString(), ""));
                rk.Close();
            }

        }
        private void DGMr_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DGMr.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
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
        private void mloadParty(int intstatus)
        {
            int introw = 0;
            DGMr.Rows.Clear();

            ooPartyName = invms.mfillPartyNameNew(strComID, lstBranch.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, intstatus, "","").ToList();

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
                    //if (introw % 2 == 0)
                    //{
                    //    DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
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
                    //if (i % 2 == 0)
                    //{
                    //    DGMr.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DGMr.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //}
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
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);


            DGCC.Columns.Add(Utility.Create_Grid_Column("Month ID", "Month ID", 90, true, DataGridViewContentAlignment.TopLeft, false));
            DGCC.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 90, true, DataGridViewContentAlignment.TopLeft, false));
            //DGCC.Columns.Add(Utility.CreateChkBxGrd ("", "", 90, true, DataGridViewContentAlignment.TopLeft, true,true,""));
            DGCC.Columns[0].ReadOnly = true;
            DGCC.Columns[1].ReadOnly = true;
            DGCC.AllowUserToAddRows = false;

            DG.Columns.Clear();
            //this.DG.DefaultCellStyle.Font = new Font("verdana", 10);


            DG.Columns.Add(Utility.Create_Grid_Column("Ledger", "Ledger", 310, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Comm.(%)", "Comm.(%)", 90, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 90, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Incen.Comm.(%)", "Incen.Comm.(%)", 120, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Net Amount", "Net Amount", 110, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, false, DataGridViewContentAlignment.TopCenter, true));
        

            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID,Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranch.Visible = false;
            lstMedicalRep.Visible = false;
            mloadParty(0);
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
            objfrm.strPreserveSQl = mstrSQL;
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
                string strMM = "";
                this.DGCC.DefaultCellStyle.Font = new Font("verdana", 9);
                DateTime dtePrevios = dteFDate.Value.AddDays(-1);
                strMM = dtePrevios.ToString("MMMyy").ToUpper();
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DG.Rows.Clear();
                //dgCopyGrid.Rows.Clear();
                //DgCostCenter.Rows.Clear();
                uctxtOldNo.Text = tests[0].strVoucherNo;
                //btnCommission.Enabled = false;
                List<AccountsVoucher> ooaccVou = accms.DisplayCompVoucherList(strComID, tests[0].strVoucherNo, 3).ToList();
                if (ooaccVou.Count > 0)
                {
                    foreach (AccountsVoucher oCom in ooaccVou)
                    {
                        uctxtVoucherNo.Text = Utility.Mid(oCom.strVoucherNo, 6, oCom.strVoucherNo.Length - 6);
                        dteVoucherDate.Text = oCom.strTranDate;
                        uctxtBranch.Text = Utility.gstrGetBranchName(strComID, oCom.strBranchID);
                        txtNarr.Text = oCom.strNarration;
                        uctxtMedicalRep.Text =oCom.strLedgerNameNew;
                        //uctxtMonthID.Text = oCom.strMonthID;
                        uctxtMonthID.Text = oCom.strAgnstRefNo;
                        mstrSQL = tests[0].strPreserveSQL;
                        strteritorryCode = Utility.GetTeritorryCodeFromLedgerName(strComID, oCom.strLedgerNameNew);
                        uctxtTerritoryCode.Text = strteritorryCode;
                        uctxtTeritorryName.Text = Utility.GetTeritorryName(strComID, strteritorryCode);
                        List<AccountsVoucher> ooVouList = accms.DisplayVoucherList(strComID, tests[0].strVoucherNo, 3, 1).ToList();
                        if (ooVouList.Count > 0)
                        {

                            foreach (AccountsVoucher oacc in ooVouList)
                            {
                                DG.Rows.Add();
                                DG[0, introw].Value = oacc.strLedgerName;
                                DG[1, introw].Value = oacc.strAgnstRefNo;
                                DG[2, introw].Value = oacc.dblDebitAmount;
                                DG[4, introw].Value = oacc.dblDebitAmount;
                                DG[5, introw].Value = "Delete";
                                introw += 1;
                            }
                            DG.AllowUserToAddRows = false;
                            
                        }
                        introw = 0;
                        //List<AccountdGroup> oogrp = accms.mDisplayMonthTarget(strComID, dteFDate.Text, dteToDate.Text, uctxtMedicalRep.Text).ToList();
                        //if (oogrp.Count > 0)
                        //{
                        //    foreach (AccountdGroup ogrp in oogrp)
                        //    {
                        //        DGCC.Rows.Add();
                        //        if (uctxtMonthID.Text == ogrp.strMonthID)
                        //        {
                        //            DGCC[0, introw].Style.BackColor = Color.Yellow;
                        //            //uctxtAmount.Text = ogrp.dblAmount.ToString();
                        //        }
                        //        //DGCC[0, introw].Value = ogrp.strMonthID;
                        //        //DGCC[1, introw].Value = ogrp.dblAmount;
                        //        introw += 1;
                        //    }
                        //}
                        List<AccountdGroup> oForm = accms.mGetDateFromMonthID(strComID, uctxtMonthID.Text).ToList();
                        if (oForm.Count>0)
                        {
                            dteFDate.Text = oForm[0].strFromdate;
                            dteToDate.Text = oForm[0].strTodate;
                        }
                        else
                        {
                            dteFDate.Text = Utility.GetMpoDateFromTroyeeTemporary(strComID, tests[0].strVoucherNo);
                            dteToDate.Text = Utility.GetMpoDateToTroyeeTemporary(strComID, tests[0].strVoucherNo);
                        }
                        List<AccountdGroup> oogrpmonth = accms.mDisplayMonthTarget(strComID, Utility.gdteFinancialYearFrom, Utility.gdteFinancialYearTo, uctxtMedicalRep.Text).ToList();
                        if (oogrpmonth.Count > 0)
                        {
                            foreach (AccountdGroup ogrp in oogrpmonth)
                            {
                                DGCC.Rows.Add();
                                if (uctxtMonthID.Text == ogrp.strMonthID)
                                {
                                    DGCC[0, introw].Style.BackColor = Color.Yellow;
                                    uctxtAmount.Text = ogrp.dblAmount.ToString();
                                }
                                DGCC[0, introw].Value = ogrp.strMonthID;
                                DGCC[1, introw].Value = ogrp.dblAmount;
                                introw += 1;
                            }
                        }
                        DateTime dtePrevios1 = dteFDate.Value.AddDays(-1);
                        DateTime dtePreviosTdate = Utility.LastDayOfMonth(dtePrevios1);
                        txtCashCollection.Text = Utility.gGetReceiptAmountOfParty(strComID, uctxtMedicalRep.Text, 1, 0, dteFDate.Text, dteToDate.Text).ToString();
                        //txtVoucherColl.Text = Utility.gGetReceiptAmountVoucher(strComID, uctxtMedicalRep.Text, 3, 1, dteFDate.Text, dteToDate.Text,uctxtMonthID.Text).ToString();
                        //txtVoucherColl.Text = Utility.gGetReceiptAmountVoucher(strComID, uctxtMedicalRep.Text, 3, 1, dtePrevios1.ToString("dd-MM-yyyy"), dtePreviosTdate.ToString("dd-MM-yyyy"), strMM).ToString();
                        txtVoucherColl.Text = Utility.gGetReceiptAmountVoucher(strComID, uctxtMedicalRep.Text, 3, 1, dtePrevios1.ToString("dd-MM-yyyy"), dtePreviosTdate.ToString("dd-MM-yyyy"), dtePrevios1.ToString("MMMyy")).ToString();
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
            string strMsg = "";
            double dblManualBill = 0;
            //this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<AccountsLedger> oogrp = accms.mDisplayDraftLedger(strComID,uctxtMonthID.Text, uctxtMedicalRep.Text).ToList();
            if (oogrp.Count > 0)
            {

                foreach (AccountsLedger ogrp in oogrp)
                {
                    DG.Rows.Add();
                    List<AccountsVoucher> objAmount = accms.mFillLedgerListMpoPercen(strComID, ogrp.strLedgerName, uctxtMedicalRep.Text).ToList();
                    if (objAmount.Count != 0)
                    {
                        DG[0, introw].Value = ogrp.strLedgerName;
                        DG[1, introw].Value = 0;
                        DG[2, introw].Value = 0;
                        DG[3, introw].Value = 0;
                        DG[4, introw].Value = 0;


                        if (objAmount[0].dblDebitAmount != 0)
                        {
                            DG[1, introw].Value = objAmount[0].dblDebitAmount;
                            DG[2, introw].Value = Math.Round((Utility.Val(txttotalAmt.Text) * objAmount[0].dblDebitAmount) / 100, 0);
                            DG[3, introw].Value = 0;
                            DG[4, introw].Value = Math.Round((Utility.Val(txttotalAmt.Text) * objAmount[0].dblDebitAmount) / 100, 0);
                        }
                        else
                        {
                            //long intDays = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(objAmount[0].strDueDate), Convert.ToDateTime(dteVoucherDate.Text)) + 1;
                            if (objAmount[0].strDueDate != "")
                            {
                                string strDate = mGeteffectiveDate(uctxtMonthID.Text);
                              
                                //if (Convert.ToDateTime(objAmount[0].strDueDate) >= Convert.ToDateTime(dteVoucherDate.Text))
                                if (Convert.ToDateTime(strDate).ToString("MMMyy").ToUpper() == Convert.ToDateTime(dteVoucherDate.Text).ToString("MMMyy").ToUpper())
                                {
                                    //DG[1, introw].Value = 0;
                                    //DG[2, introw].Value = objAmount[0].dblCreditAmount;
                                    //DG[3, introw].Value = 0;
                                    //DG[4, introw].Value = objAmount[0].dblCreditAmount;
                                    DG[1, introw].Value = 0;
                                    DG[2, introw].Value = Utility.gdblSalaryByVoucher(strComID, uctxtMedicalRep.Text, strDate);
                                    DG[3, introw].Value = 0;
                                    DG[4, introw].Value = Utility.gdblSalaryByVoucher(strComID, uctxtMedicalRep.Text, strDate);
                                   
                                }
                                else
                                {
                                    if (ogrp.strLedgerName == "Salary By Voucher" && objAmount[0].dblCreditAmount > 0)
                                    {
                                        strMsg = "Salary is Not Configured/Date is Expired,Please Check";
                                    }
                                    else
                                    {
                                        if (ogrp.strLedgerName == "Salary By Voucher" && objAmount[0].dblCreditAmount == 0)
                                        {
                                            strMsg = "Salary is Not Configured/Date is Expired,Please Check";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                DG[1, introw].Value = 0;
                                DG[2, introw].Value = 0;
                                DG[3, introw].Value = 0;
                                DG[4, introw].Value = 0;
                                dblManualBill = accms.mFillDisplayManualBill(strComID, uctxtMonthID.Text, uctxtMedicalRep.Text, ogrp.strLedgerName);
                                //DG[1, introw].Value = dblManualBill;
                                DG[2, introw].Value = dblManualBill;
                                DG[4, introw].Value = dblManualBill;
                                if (ogrp.strLedgerName == "Salary By Voucher" && objAmount[0].dblCreditAmount == 0)
                                    strMsg = "Salary is Not Configured/Date is Expired,Please Check";
                            }
                        }
                    }
                    else
                    {
                        dblManualBill = accms.mFillDisplayManualBill(strComID, uctxtMonthID.Text, uctxtMedicalRep.Text, ogrp.strLedgerName);
                        //DG[1, introw].Value = dblManualBill;
                        DG[2, introw].Value = dblManualBill;
                        DG[4, introw].Value = dblManualBill;
                    }

                    DG[5, introw].Value = "Delete";
                    introw += 1;
                  
                }
                calculateTotal();
                DG.AllowUserToAddRows = false;
                if (strMsg != "")
                {
                    MessageBox.Show(strMsg, "Deep Laid", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                //foreach (DataGridViewRow item in this.DG.Rows)
                //{
                //    if (Convert.ToDouble(item.Cells[4].Value) == 0)
                //    {
                //        DG.Rows.Remove(item);
                //    }
                //}

                //for (int indel = 0; indel < DG.Rows.Count; indel++)
                //{
                //    if (Convert.ToDouble(DG[4, indel].Value) == 0)
                //    {
                //        DG.Rows.RemoveAt(indel);
                //    }
                //    //indel--;
                //}
            }
        }
        #region "Comment"
        //private void mLoadGroupList()
        //{
        //    int introw = 0;
        //    double dblFromAmnt = 0,dblToAmnt=0,dblPercentage=0;
        //    //this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
        //    DG.Rows.Clear();
        //    List<AccountsLedger> oogrp = accms.mDisplayLedgerlistt(strComID, 203).ToList();
        //    if (oogrp.Count > 0)
        //    {

        //        foreach (AccountsLedger ogrp in oogrp)
        //        {
        //            DG.Rows.Add();
                 
        //           // DG[0, introw].Value = ogrp.strConfigkey;
        //            DG[0, introw].Value = ogrp.strLedgerName;
        //            DG[1, introw].Value = 0;
        //            DG[2, introw].Value = 0;
        //            DG[3, introw].Value = 0;
        //            DG[4, introw].Value = 0;
        //            //DG.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //            //DG.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        //            //DG.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            //DG.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                 

        //            List<AccountsLedger> oLedger = accms.mDisplayLedgerPercen(strComID, ogrp.strLedgerName).ToList();
        //            foreach (AccountsLedger oled in oLedger)
        //            {
        //                dblFromAmnt = oled.dblFromAmt;
        //                dblToAmnt = oled.dblToAmt;

        //                dblPercentage = oled.dblConfigPer;
        //                //if (Utility.Val(txttotalAmt.Text) > dblFromAmnt && Utility.Val(txttotalAmt.Text) < dblToAmnt)
        //                //{
        //                    DG[1, introw].Value = oled.dblConfigPer.ToString();
        //                    DG[2, introw].Value = Math.Round((Utility.Val(txttotalAmt.Text) * dblPercentage) / 100,0);
        //                    DG[3, introw].Value = 0;
        //                    DG[4, introw].Value = Math.Round((Utility.Val(txttotalAmt.Text) * dblPercentage) / 100,0);
        //                    DG[5, introw].Value = "Delete";
        //                //}
        //                //else
        //                //{
        //                //    DG[1, introw].Value = 0;
        //                //    DG[2, introw].Value = 0;
        //                //    DG[3, introw].Value = 0;
        //                //    DG[4, introw].Value = 0;
        //                //    DG[5, introw].Value = "Delete";
        //                //}
                        
        //            }
                   
        //            introw += 1;
        //        }
        //        calculateTotal();
        //        DG.AllowUserToAddRows = false;
        //    }
        //}
        #endregion
        private string mGeteffectiveDate(string strMonhtID)
        {
            string strDate = "";
            string strmm = Utility.Left(strMonhtID, 3);
            int intMm = Convert.ToInt16("20" + Utility.Right(strMonhtID, 2).ToString());
            if (strmm.ToUpper() == "JAN")
            {
                strDate = "01-01-" + intMm;
            }
            else if (strmm.ToUpper() == "FEB")
            {
                strDate = "01-02-" + intMm;
            }
            else if (strmm.ToUpper() == "MAR")
            {
                strDate = "01-03-" + intMm;
            }
            else if (strmm.ToUpper() == "APR")
            {
                strDate = "01-04-" + intMm;
            }
            else if (strmm.ToUpper() == "MAY")
            {
                strDate = "01-05-" + intMm;
            }
            else if (strmm.ToUpper() == "JUN")
            {
                strDate = "01-06-" + intMm;
            }
            else if (strmm.ToUpper() == "JUL")
            {
                strDate = "01-07-" + intMm;
            }
            else if (strmm.ToUpper() == "AUG")
            {
                strDate = "01-08-" + intMm;
            }
            else if (strmm.ToUpper() == "SEP")
            {
                strDate = "01-09-" + intMm;
            }
            else if (strmm.ToUpper() == "OCT")
            {
                strDate = "01-10-" + intMm;
            }
            else if (strmm.ToUpper() == "NOV")
            {
                strDate = "01-11-" + intMm;
            }
            else if (strmm.ToUpper() == "DEC")
            {
                strDate = "01-12-" + intMm;
            }

            return strDate;
        }
        private void btnCommission_Click(object sender, EventArgs e)
        {
            int introw = 0;
            string strMM = "";
            this.DGCC.DefaultCellStyle.Font = new Font("verdana", 9);
            DateTime dtePrevios = dteFDate.Value.AddDays(-1);
            DateTime dtePreviosTdate = Utility.LastDayOfMonth(dtePrevios);
            strMM = dtePrevios.ToString("MMMyy").ToUpper();
            DGCC.Rows.Clear();
            txtCashCollection.Text = Utility.gGetReceiptAmountOfParty(strComID, uctxtMedicalRep.Text, 1, 0, dteFDate.Text, dteToDate.Text).ToString();
            txtVoucherColl.Text = Utility.gGetReceiptAmountVoucher(strComID, uctxtMedicalRep.Text, 3, 1, dtePrevios.ToString("dd-MM-yyyy"), dtePreviosTdate.ToString("dd-MM-yyyy"), strMM).ToString();
            txttotalAmt.Text = (Utility.Val(txtCashCollection.Text) + Utility.Val(txtVoucherColl.Text)).ToString();
            List<AccountdGroup> oogrp = accms.mDisplayMonthTarget(strComID, Utility.gdteFinancialYearFrom, Utility.gdteFinancialYearTo, uctxtMedicalRep.Text).ToList();
            if (oogrp.Count > 0)
            {
                foreach (AccountdGroup ogrp in oogrp)
                {
                    DGCC.Rows.Add();
                    if (uctxtMonthID.Text == ogrp.strMonthID)
                    {
                        DGCC[0, introw].Style.BackColor = Color.Yellow;
                        uctxtAmount.Text = ogrp.dblAmount.ToString();
                    }
                    DGCC[0, introw].Value = ogrp.strMonthID;
                    DGCC[1, introw].Value =ogrp.dblAmount;
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
            //txtNarr.Text = "";
            txtCashCollection.Text = "";
            txtCollComit.Text = "";
            txtVoucherColl.Text = "";
            uctxtTeritorryName.Text = "";
            uctxtTerritoryCode.Text = "";
            txttotalAmt.Text = "";
            txtFTotal.Text = "";
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            List<AccountdGroup> oogrp = accms.mDisplayMonthsetupList(strComID, "1", Utility.gdteFinancialYearFrom, Utility.gdteFinancialYearTo).ToList();
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
                if (intLedgerCount >= 2)
                {
                    strReverseLedger = "As Per Details";
                }
                else if (intvrow == 0)
                {
                    if (intLedgerCount > 1)
                    {
                        strReverseLedger = DG.Rows[1].Cells[1].Value.ToString();
                    }
                    else
                    {
                        strReverseLedger = uctxtMedicalRep.Text;
                    }
                }
                else if (intvrow == 1)
                {
                    strReverseLedger = DG.Rows[0].Cells[1].Value.ToString();
                }
                if (DG.Rows[intvrow].Cells[2].Value != null)
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


                    if (dbldebitAmount != 0)
                    {

                        strVoucherGrid = strVoucherGrid + strDrCr + "|" + strLedgerName + "|" + strReverseLedger + "|" + intCashFlow + "|"
                                                      + "|" + dbldebitAmount + "|" + 0 + "|" + strSingleNarration + "|" + strNarration + "|" +
                                                               strChecuqueNo + "|" + strCheckDate + "|" + strDrwanon + "|" + dblPercentage + "~";

                        dblcreditAmount = dbldebitAmount;
                        strDrCr = "Cr";
                        if (intLedgerCount > 1)
                        {
                            strVoucherGrid = strVoucherGrid + strDrCr + "|" + uctxtMedicalRep.Text + "|" + strReverseLedger + "|" + intCashFlow + "|"
                                                         + "|" + 0 + "|" + dblcreditAmount + "|" + strSingleNarration + "|" + strNarration + "|" +
                                                                  strChecuqueNo + "|" + strCheckDate + "|" + strDrwanon + "|" + dblPercentage + "~";
                        }
                        else
                        {
                            strVoucherGrid = strVoucherGrid + strDrCr + "|" + uctxtMedicalRep.Text + "|" + strLedgerName + "|" + intCashFlow + "|"
                                                        + "|" + 0 + "|" + dblcreditAmount + "|" + strSingleNarration + "|" + strNarration + "|" +
                                                                 strChecuqueNo + "|" + strCheckDate + "|" + strDrwanon + "|" + dblPercentage + "~";
                        }
                    }
                }
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
                                                   strBranchID, "", "", mblnNumbMethod, 0, "", "", "", uctxtMonthID.Text, "", "", "", "", "", "", 1,"","","",0);

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
                                                  strBranchID, "", "", 0, "", "", "", uctxtMonthID.Text, "", "", "", "", "", "","","","",0);

            return i;
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string kk = "", strDuplicate="";
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
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            long lngDate = Convert.ToInt64(Convert.ToDateTime(dteVoucherDate.Text).ToString("yyyyMMdd"));
            string strLockvoucher = Utility.gLockVocher(strComID, (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER);
            if (strLockvoucher != "")
            {
                long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strLockvoucher).ToString("yyyyMMdd"));
                if (lngDate <= lngBackdate)
                {
                    MessageBox.Show("Invalid Date, Back Date is locked");
                    return;
                }
            }
            if (Utility.Val(txtFTotal.Text) == 0)
            {
                MessageBox.Show("0 Amount Cannot be Saved");
                uctxtBranch.Focus();
                return;
            }

            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
            rk.SetValue("MpoNarration" + 3, txtNarr.Text);
            rk.Close();
            try
            {
                if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
                {
                    strDuplicate = Utility.mGetCheckMpoCommission(strComID, "ACC_COMPANY_VOUCHER", "LEDGER_NAME", "AGNST_COMP_REF_NO", uctxtMedicalRep.Text.ToString(), uctxtMonthID.Text.ToString());
                    if (strDuplicate !="")
                    {
                        MessageBox.Show("Alreday Save");
                        return;
                    }
                    string s = mSave();
                    if (s == "1")
                    {
                        //kk = Utility.mUpdateCommParent(strComID, uctxtMedicalRep.Text, uctxtMonthID.Text, uctxtVoucherNo.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteVoucherDate.Text, "Commission Configuration", uctxtVoucherNo.Text,
                                                                    1, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                        }

                        mClear();
                    }
                    else
                    {
                        MessageBox.Show("Cannot Insert Duplicate Value");
                        return;
                    }
                }
                else
                {
                    string k = mUpdate();
                    if (k == "1")
                    {
                        // kk = Utility.mUpdateCommParent(strComID, uctxtMedicalRep.Text, uctxtMonthID.Text, uctxtVoucherNo.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteVoucherDate.Text, "Commission Configuration", uctxtVoucherNo.Text,
                                                                    2, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                        }
                        mClear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==5)
            {
                DG.Rows.RemoveAt(e.RowIndex);
                calculateTotal();
            }
        }

        private void chkStatus_Click(object sender, EventArgs e)
        {
            int intStatus = 0;
            if (chkStatus.Checked)
            {
                intStatus = 0;
            }
            else
            {
                intStatus = 1;
            }

            mloadParty(intStatus);
            uctxtMedicalRep.Focus();
        }

     






    }



}