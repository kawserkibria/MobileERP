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
using Microsoft.VisualBasic;
using Microsoft.Win32;
using JA.Modulecontrolar.JINVMS;


namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmAccountsVoucher : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        SPWOIS objwois = new SPWOIS();
        public long lngFormPriv { get; set; }
        List<StockItem> oogrp;
        public string strFormName { get; set; }
        private string mstrPrserveSql { get; set; }
        public string mstrOldParticulars { get; set; }
        private ListBox lstCostCategory = new ListBox();
        private ListBox lstCostCenter = new ListBox();
        private ListBox lstBatchNo = new ListBox();
        private ListBox lstPrticulars = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstTemplate = new ListBox();
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
        public int intvtype { get; set; }
        public int intSelectedType { get; set; }
        public double mdblCurrRate { get; set; }
        public string mstrFCsymbol { get; set; }
        public double mdblDebit { get; set; }
        List<AccountsLedger> oledger;
        public double mdblCredit { get; set; }
        private ListBox lstBranchName = new ListBox();
        private ListBox lstTypeofRef = new ListBox();
        private ListBox lstBillRefNo = new ListBox();
        private ListBox lstInstallment = new ListBox();
        public int m_action { get; set; }
        private string strComID { get; set; }
        private System.Drawing.Color NormalColor = Color.White;
        private System.Drawing.Color FocusColor = System.Drawing.Color.FromArgb(192, 255, 192);
        public frmAccountsVoucher()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User In"
            
            this.txtDrcr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDrcr_KeyPress);
            this.txtDrcr.GotFocus += new System.EventHandler(this.txtDrcre_GotFocus);
           


            this.txtParticulars.GotFocus += new System.EventHandler(this.txtParticulars_GotFocus);
            this.txtParticulars.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtParticulars_KeyPress);
            this.txtParticulars.KeyDown += new KeyEventHandler(txtParticulars_KeyDown);
            this.lstPrticulars.DoubleClick += new System.EventHandler(this.lstPrticulars_DoubleClick);
            this.txtParticulars.TextChanged += new System.EventHandler(this.txtParticulars_TextChanged);
            
            //this.lstTeritorryCode.DoubleClick += new System.EventHandler(this.lstTeritorryCode_DoubleClick);
            //this.DGMr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGMr_KeyPress);
            //this.DGMr.DoubleClick += new System.EventHandler(this.DGMr_DoubleClick);

            this.txtSingleNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSingleNarration_KeyPress);
            this.txtSingleNarration.GotFocus += new System.EventHandler(this.txtSingleNarration_GotFocus);

            this.txtDebitAmount.TextChanged += new System.EventHandler(this.txtDebitAmount_TextChanged);
            this.txtDebitAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDebitAmount_KeyPress);
            this.txtDebitAmount.GotFocus += new System.EventHandler(this.txtDebitAmount_GotFocus);

            this.txtCreditAmount.TextChanged += new System.EventHandler(this.txtCreditAmount_TextChanged);
            this.txtCreditAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCreditAmount_KeyPress);
            this.txtCreditAmount.GotFocus += new System.EventHandler(this.txtCreditAmount_GotFocus);

            //this.txtDrcr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDrcr_KeyPress);
            //this.txtDrcr.GotFocus += new System.EventHandler(this.txtDrcr_GotFocus);

            this.txtDrcr.TextChanged += new System.EventHandler(this.txtDrcr_TextChanged);
            this.txtDrcr.KeyDown += new KeyEventHandler(txtDrcr_KeyDown);

            this.uctxtJvRvDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtJvRvDate_KeyPress);
            this.uctxtJvRvDate.GotFocus += new System.EventHandler(this.uctxtJvRvDate_GotFocus);
            
            this.txtInstallment.KeyDown += new KeyEventHandler(txtInstallment_KeyDown);
            this.txtInstallment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtInstallment_KeyPress);
            this.txtInstallment.TextChanged += new System.EventHandler(this.txtInstallment_TextChanged);
            this.lstInstallment.DoubleClick += new System.EventHandler(this.lstInstallment_DoubleClick);
            this.txtInstallment.GotFocus += new System.EventHandler(this.txtInstallment_GotFocus);

            this.cboGeneral.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboGeneral_KeyPress);
            this.cboGeneral.GotFocus += new System.EventHandler(this.cboGeneral_GotFocus);

            this.txtBranchName.KeyDown += new KeyEventHandler(txtBranchName_KeyDown);
            this.txtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBranchName_KeyPress);
            this.txtBranchName.TextChanged += new System.EventHandler(this.txtBranchName_TextChanged);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.txtBranchName.GotFocus += new System.EventHandler(this.txtBranchName_GotFocus);

            this.uctxtLocation.KeyDown += new KeyEventHandler(uctxtLocation_KeyDown);
            this.uctxtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLocation_KeyPress);
            this.uctxtLocation.TextChanged += new System.EventHandler(this.uctxtLocation_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.uctxtLocation.GotFocus += new System.EventHandler(this.uctxtLocation_GotFocus);

            this.uctxtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtVoucherNo_KeyPress);
            this.dteVoucherDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteVoucherDate_KeyPress);
            this.dteVoucherDate.GotFocus += new System.EventHandler(this.dteVoucherDate_GotFocus);

            //this.txtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBranchName_KeyPress);

            this.uctxtCostCategory.KeyDown += new KeyEventHandler(uctxtCostCategory_KeyDown);
            this.uctxtCostCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCostCategory_KeyPress);
            this.uctxtCostCategory.TextChanged += new System.EventHandler(this.uctxtCostCategory_TextChanged);
            this.lstCostCategory.DoubleClick += new System.EventHandler(this.lstCostCategory_DoubleClick);
            this.uctxtCostCategory.GotFocus += new System.EventHandler(this.uctxtCostCategory_GotFocus);

            this.uctxtCostCenter.KeyDown += new KeyEventHandler(uctxtCostCenter_KeyDown);
            this.uctxtCostCenter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCostCenter_KeyPress);
            this.uctxtCostCenter.TextChanged += new System.EventHandler(this.uctxtCostCenter_TextChanged);
            this.lstCostCenter.DoubleClick += new System.EventHandler(this.lstCostCenter_DoubleClick);
            this.uctxtCostCenter.GotFocus += new System.EventHandler(this.uctxtCostCenter_GotFocus);

            this.uctxtAmount.GotFocus += new System.EventHandler(this.uctxtAmount_GotFocus);
            this.uctxtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAmount_KeyPress);

            this.txtChequeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtChequeNo_KeyPress);
            this.txtChequeNo.KeyDown += new KeyEventHandler(txtChequeNo_KeyDown);
            this.mskChequeDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(mskChequeDate_KeyPress);
            this.txtDrawnon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDrawnon_KeyPress);

            this.txtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNarration_KeyPress);
            this.txtNarration.GotFocus += new System.EventHandler(this.txtNarration_GotFocus);
            this.txtNarration.KeyDown += new KeyEventHandler(txtNarration_KeyDown);

            this.uctxtBatchNo.KeyDown += new KeyEventHandler(uctxtBatchNo_KeyDown);
            this.uctxtBatchNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatchNo_KeyPress);
            this.uctxtBatchNo.TextChanged += new System.EventHandler(this.uctxtBatchNo_TextChanged);
            this.lstBatchNo.DoubleClick += new System.EventHandler(this.lstBatchNo_DoubleClick);
            this.uctxtBatchNo.GotFocus += new System.EventHandler(this.uctxtBatchNo_GotFocus);

            this.uctxtTypeofRef.KeyDown += new KeyEventHandler(uctxtTypeofRef_KeyDown);
            this.uctxtTypeofRef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTypeofRef_KeyPress);
            this.uctxtTypeofRef.TextChanged += new System.EventHandler(this.uctxtTypeofRef_TextChanged);
            this.lstTypeofRef.DoubleClick += new System.EventHandler(this.lstTypeofRef_DoubleClick);
            this.uctxtTypeofRef.GotFocus += new System.EventHandler(this.uctxtTypeofRef_GotFocus);


            this.txtBillRefNo.KeyDown += new KeyEventHandler(txtBillRefNo_KeyDown);
            this.txtBillRefNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBillRefNo_KeyPress);
            this.txtBillRefNo.TextChanged += new System.EventHandler(this.txtBillRefNo_TextChanged);
            this.lstBillRefNo.DoubleClick += new System.EventHandler(this.lstBillRefNo_DoubleClick);
            this.txtBillRefNo.GotFocus += new System.EventHandler(this.txtBillRefNo_GotFocus);


            this.dtedueDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtedueDate_KeyPress);
            this.txtBillAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBillAmount_KeyPress);
            this.txtBillDrcr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBillDrcr_KeyPress);
            this.txtComm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtComm_KeyPress);
            this.txtInte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtInte_KeyPress);
            
            //this.DGMr.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGMr_CellFormatting);
            this.DG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellDoubleClick);
            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);

            this.uclstGrdItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uclstGrdItem_KeyPress);
            this.uclstGrdItem.DoubleClick += new System.EventHandler(this.uclstGrdItem_DoubleClick);

            this.uctxtQty.TextChanged += new System.EventHandler(this.uctxtQty_TextChanged);
            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);

            this.uctxtRate.TextChanged += new System.EventHandler(this.uctxtRate_TextChanged);
            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtRate.GotFocus += new System.EventHandler(this.uctxtRate_GotFocus);

            this.txtTemplateName.KeyDown += new KeyEventHandler(txtTemplateName_KeyDown);
            this.txtTemplateName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtTemplateName_KeyPress);
            this.txtTemplateName.TextChanged += new System.EventHandler(this.txtTemplateName_TextChanged);
            this.lstTemplate.DoubleClick += new System.EventHandler(this.lstTemplate_DoubleClick);
            this.txtTemplateName.GotFocus += new System.EventHandler(this.txtTemplateName_GotFocus);

            this.uclstGrdItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstGrdItem_CellFormatting);
            this.DGinvms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGinvms_CellContentClick);


            this.btnTempSave.Click += new System.EventHandler(this.btnTempSave_Click);
            this.btnTempClose.Click += new System.EventHandler(this.btnTempClose_Click);
            this.btnJVapply.Click += new System.EventHandler(this.btnJVapply_Click);
            this.btnJVCancel.Click += new System.EventHandler(this.btnJVCancel_Click);
            this.DGJVTemplate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGJVTemplate_CellContentClick);
           
            txtParticulars.Enter += EnterEventp;
            txtParticulars.Leave += LeaveEventp;
            txtNarration.Enter += EnterEvent;
            txtNarration.Leave += LeaveEvent;

            Utility.CreateListBox(lstBranchName, panel2, txtBranchName);
            Utility.CreateListBox(lstCostCategory, pnlCostCenter, uctxtCostCategory);
            Utility.CreateListBox(lstCostCenter, pnlCostCenter, uctxtCostCenter);
            Utility.CreateListBox(lstBatchNo, panel2, uctxtBatchNo);
            Utility.CreateListBox(lstTypeofRef, pnlBillWise, uctxtTypeofRef);
            Utility.CreateListBox(lstBillRefNo, pnlBillWise, txtBillRefNo);
            Utility.CreateListBoxHeight(lstPrticulars, panel2, txtParticulars, 18,190);
            Utility.CreateListBox(lstLocation, PanelInventory, uctxtLocation);
            Utility.CreateListBox(lstTemplate, pnlTemplate,txtTemplateName);
            Utility.CreateListBox(lstInstallment, panelRvSchedule, txtInstallment);
            
            #endregion
        }
       
        #region "PriorSetFocus"

        private void txtCreditAmount_TextChanged(object sender, EventArgs e)
        {
           
            if (Utility.IsNumericNew(txtCreditAmount.Text) == false)
            {
                txtCreditAmount.Text = "";
            }
        }
        private void txtDebitAmount_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(txtDebitAmount.Text) == false)
            {
                txtDebitAmount.Text = "";
            }
        }


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
        #region "User Define Event"
        private void cboGeneral_GotFocus(object sender, System.EventArgs e)
        {
            lstPrticulars.Visible = false;
        }

        private void cboGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtBranchName.Focus();
            }
        }
        private void uctxtJvRvDate_GotFocus(object sender, System.EventArgs e)
        {
            lstInstallment.Visible = false;
            lstBranchName.Visible = false;
            lstBatchNo.Visible = false;
            lstPrticulars.Visible = false;

         
        }
        private void uctxtJvRvDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                try
                {
                    uctxtJvRvDate.Text = Utility.ctrlDateFormat(uctxtJvRvDate.Text);
                    double dblamount = 0;
                    if (txtJVAmount.Text == "")
                    {
                        dblamount = 0;
                    }
                    else
                    {
                        dblamount = Convert.ToDouble(txtJVAmount.Text);
                    }
                    if (txtInstallment.Text != "")
                    {
                        mAddInstallment(txtInstallment.Text, uctxtDueDate.Text, uctxtJvRvDate.Text, dblamount);
                    }
                    txtInstallment.Focus();
                }
                catch (Exception ex)
                {

                }
            }
        }
        private void txtInstallment_TextChanged(object sender, EventArgs e)
        {
            lstInstallment.SelectedIndex = lstInstallment.FindString(txtInstallment.Text);
        }
        private void lstInstallment_DoubleClick(object sender, EventArgs e)
        {
            txtInstallment.Text = lstInstallment.Text;
            lstInstallment.Visible = false;
            List<AccountsLedger> objldr = accms.mGetInstallmentNo(strComID, uctxtAllocationJV.Text, txtInstallment.Text).ToList();
            if (objldr.Count > 0)
            {
                uctxtJVTemplate.Text = objldr[0].strmerzeString;
                txtJVAmount.Text = objldr[0].dblToAmt.ToString();
                uctxtDueDate.Text = objldr[0].strCreditDate;
            }
            uctxtJvRvDate.Focus();
           

        }
        private void txtInstallment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstInstallment.Items.Count > 0)
                {
                    if (txtInstallment.Text != "")
                    {
                        txtInstallment.Text = lstInstallment.Text;
                        List<AccountsLedger> objldr = accms.mGetInstallmentNo(strComID, uctxtAllocationJV.Text, txtInstallment.Text).ToList();
                        if (objldr.Count > 0)
                        {
                            uctxtJVTemplate.Text = objldr[0].strmerzeString;
                            txtJVAmount.Text = objldr[0].dblToAmt.ToString();
                            uctxtDueDate.Text = objldr[0].strCreditDate;

                        }
                        uctxtJvRvDate.Focus();
                    }
                    else
                    {
                        btnJVapply.Focus();
                    }

                }
                else
                {
                    btnJVapply.Focus();
                }
            }
        }

        private void mAddInstallment(string strInstallmentNo, string strReceiptDate, string strduedate, double dblAmount)
        {
            int selRaw;
            double dblFine = 0;
            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < DGJVTemplate.RowCount; j++)
            {
                if (DGJVTemplate[0, j].Value != null)
                {
                    strDown = DGJVTemplate[0, j].Value.ToString();
                }
                if (strInstallmentNo == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {
         
                //long intnoofdays = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(strReceiptDate), Convert.ToDateTime(strduedate)) + 1;
                if (Convert.ToDateTime(strduedate) > Convert.ToDateTime(strReceiptDate))
                {
                    dblFine = 300;
                }
                DGJVTemplate.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DGJVTemplate.RowCount.ToString());
                selRaw = selRaw - 1;
                DGJVTemplate.Rows.Add();
                DGJVTemplate[0, selRaw].Value = strInstallmentNo.ToString();
                DGJVTemplate[1, selRaw].Value = strReceiptDate.ToString();
                DGJVTemplate[2, selRaw].Value = strduedate.ToString();
                DGJVTemplate[3, selRaw].Value = dblAmount.ToString();
                DGJVTemplate[4, selRaw].Value = dblFine;
                DGJVTemplate.AllowUserToAddRows = false;
                txtInstallment.Text = "";
                txtJVAmount.Text = "";
                uctxtDueDate.Text = "";
                uctxtJvRvDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                
                calculateTotal();
            }

        }


        private void txtInstallment_KeyDown(object sender, KeyEventArgs e)
        {
            lstInstallment.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                if (lstInstallment.SelectedItem != null)
                {
                    lstInstallment.SelectedIndex = lstInstallment.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstInstallment.Items.Count - 1 > lstInstallment.SelectedIndex)
                {
                    lstInstallment.SelectedIndex = lstInstallment.SelectedIndex + 1;
                }
            }
           
        }
        private void txtInstallment_GotFocus(object sender, System.EventArgs e)
        {
            
            lstBranchName.Visible = false;
            lstBatchNo.Visible = false;
            lstPrticulars.Visible = false;

            lstInstallment.ValueMember = "strLedgerName";
            lstInstallment.DisplayMember = "strLedgerName";
            lstInstallment.DataSource = accms.mGetInstallmentNo(strComID, uctxtAllocationJV.Text, "").ToList();
            lstInstallment.SelectedIndex = lstInstallment.FindString(txtInstallment.Text);
           
        }

        private void txtTemplateName_TextChanged(object sender, EventArgs e)
        {
            lstTemplate.SelectedIndex = lstTemplate.FindString(txtTemplateName.Text);
        }

        private void lstTemplate_DoubleClick(object sender, EventArgs e)
        {
            txtTemplateName.Text = lstTemplate.Text;
            mDispay(txtTemplateName.Text);
            btnTempSave.Focus();
            lstTemplate.Visible = false;
        }

        private void txtTemplateName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstTemplate.Items.Count > 0)
                {
                    txtTemplateName.Text = lstTemplate.Text;
                    mDispay(txtTemplateName.Text);
                }
                btnTempSave.Focus();
                lstTemplate.Visible = false;

            }
        }
        public void calculateTempLateTotal()
        {
            int intloop = 0;
            double dblTotalAmount = 0;
            try
            {
                for (int i = 0; i < DGTemplate.Rows.Count; i++)
                {
                    dblTotalAmount = dblTotalAmount + Utility.Val(DGTemplate.Rows[i].Cells[2].Value.ToString());
                    
                }
                txtTemplateTotal.Text = Math.Round(dblTotalAmount, 0).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void mDispay(string strLedgerName)
        {
            List<AccountsLedger> ogrp = accms.mDisplayLoanList(strComID, strLedgerName).ToList();
            {
                if (ogrp.Count > 0)
                {
                    DGTemplate.Rows.Clear();
                    int introw = 0;
                    string strdate = "20" + "-" + Utility.Mid(dteVoucherDate.Text, 3, 2) + "-" + Utility.Right(dteVoucherDate.Text,4);
                    DateTime dtedate = Convert.ToDateTime(strdate).AddMonths(1);
                    foreach (AccountsLedger display in ogrp)
                    {
                        DGTemplate.Rows.Add();
                        DGTemplate[0, introw].Value = display.strmerzeString;
                        DGTemplate[1, introw].Value = dtedate.ToString("dd-MM-yyyy");
                        DGTemplate[2, introw].Value = display.dblToAmt.ToString();
                        introw += 1;
                        dtedate=dtedate.AddMonths(1);
                    }
                    calculateTempLateTotal();
                    DGTemplate.AllowUserToAddRows = false;
                }
            }
        }
        private void txtTemplateName_KeyDown(object sender, KeyEventArgs e)
        {
            lstTemplate.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                if (lstTemplate.SelectedItem != null)
                {
                    lstTemplate.SelectedIndex = lstTemplate.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstTemplate.Items.Count - 1 > lstTemplate.SelectedIndex)
                {
                    lstTemplate.SelectedIndex = lstTemplate.SelectedIndex + 1;
                }
            }

        }

        private void txtTemplateName_GotFocus(object sender, System.EventArgs e)
        {

            lstTypeofRef.Visible = false;
            lstPrticulars.Visible = false;
            lstBillRefNo.Visible = false;
         
            lstTemplate.ValueMember = "strLedgerName";
            lstTemplate.DisplayMember = "strLedgerName";
            lstTemplate.DataSource = accms.mFillLoanList(strComID).ToList();
            lstTemplate.SelectedIndex = lstTemplate.FindString(txtTemplateName.Text);
        }


        private void uclstGrdItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void SearchListView(IEnumerable<StockItem> tests, string searchString = "")
        {
            IEnumerable<StockItem> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                //query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                query = (from test in tests
                         where test.strItemName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                         select test);
            }

            //}
            //else if (chkEntryby.Checked)
            //{
            //    query = (from test in tests
            //             where test.entryby.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
            //             select test);

            //}

            //else if (chkAmount.Checked)
            //{
            //    query = (from test in tests
            //             where test.dblNetDebitAmount.ToString().StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
            //             select test);
            //}
            uclstGrdItem.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, i].Value = tran.strItemName;
                    uclstGrdItem[1, i].Value = tran.dblClsBalance + " " + tran.strUnit;
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void uctxtQty_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtQty.Text) == false)
            {
                uctxtQty.Text = "";
            }
        }
        private void uctxtRate_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtRate.Text) == false)
            {
                uctxtRate.Text = "";
            }
        }
        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {
          
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            uclstGrdItem.Visible = false;
        }
        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                mAddStockItem(DGinvms,uctxtLocation.Text, uctxtItemName.Text, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text));
                uctxtItemName.Text = "";
                uctxtItemName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtRate, uctxtItemName);
            }
        }
        private void mAddStockItem(DataGridView dg,string strGodwnsName, string strItemName, double dblQty, double dblRate)
        {
            int selRaw;
            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < dg.RowCount; j++)
            {
                if (dg[1, j].Value != null)
                {
                    strDown = dg[1, j].Value.ToString();
                }
                if (strItemName == strDown.ToString())
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
                dg[0, selRaw].Value = strGodwnsName.ToString();
                dg[1, selRaw].Value = strItemName.ToString();
                dg[2, selRaw].Value = dblQty;
                dg[3, selRaw].Value = Utility.gGetBaseUOM(strComID, strItemName.ToString());
                dg[4, selRaw].Value = dblRate;
                dg[5, selRaw].Value = Math.Round(dblQty * dblRate, 2);
                dg[6, selRaw].Value = "Delete";
                dg.AllowUserToAddRows = false;
                uctxtRate.Text = "";
                uctxtQty.Text = "";
                uctxtItemName.Text = "";
                calculateTotal();
                dg.ClearSelection();
                int nColumnIndex = 2;
                int nRowIndex = dg.Rows.Count - 1;
                dg.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                dg.FirstDisplayedScrollingRowIndex = nRowIndex;
            }

        }
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstLocation.Visible = false;

            uclstGrdItem.Visible = false;
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtRate.Text = Utility.gdblGetCostPrice(strComID, uctxtItemName.Text, dteVoucherDate.Text).ToString();
                if (Utility.Val(uctxtRate.Text) != 0)
                {
                    // mAddStockItem(DG, uctxtItemName.Text, Utility.Val(uctxtQty.Text), Utility.Val(uctxtRate.Text));
                    uctxtRate.Focus();
                }
                else
                {
                    uctxtRate.Focus();
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtQty, uctxtItemName);
            }
        }
        private void EnterEventp(object sender, EventArgs e)
        {
            
            if (sender is TextBox)
                ((TextBox)sender).BackColor = FocusColor;
        }

        private void LeaveEventp(object sender, EventArgs e)
        {
            if (sender is TextBox)
                ((TextBox)sender).BackColor = NormalColor;
        }
        private void EnterEvent(object sender, EventArgs e)
        {
            if (sender is TextBox)
                ((TextBox)sender).BackColor = FocusColor;
        }

        private void LeaveEvent(object sender, EventArgs e)
        {
            if (sender is TextBox)
                ((TextBox)sender).BackColor = NormalColor;
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

        //private void DGMr_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
        //    DGMr.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
        //    DGMr.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        //}
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                //txtNarration.Text = Interaction.GetSetting(Application.ExecutablePath, intvtype.ToString(), "Narration");
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                txtNarration.AppendText ((String)rk.GetValue("Narration" + intvtype.ToString(), ""));
                rk.Close();
            }

        }
        private void dteVoucherDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBatchNo.Visible = false;
            lstBranchName.Visible = false;
            lstPrticulars.Visible = false;

        }
        private void txtNarration_GotFocus(object sender, System.EventArgs e)
        {
            lstBatchNo.Visible = false;
            lstBranchName.Visible = false;
            lstPrticulars.Visible = false;

        }

        private void txtBillDrcr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtComm.Focus();
            }
        }
        private void txtInte_KeyPress(object sender, KeyPressEventArgs e)
        {
            double dblComm = 0, dblint = 0;
            if (e.KeyChar == (char)Keys.Return)
            {

                if (txtBillRefNo.Text != "")
                {
                    {
                        if (txtComm.Text == "")
                        {
                            dblComm = 0;
                        }
                        else
                        {
                            dblComm = Convert.ToDouble(txtComm.Text);
                        }
                        if (txtInte.Text == "")
                        {
                            dblint = 0;
                        }
                        else
                        {
                            dblint = Convert.ToDouble(txtInte.Text);
                        }

                        mAdditemBill(uctxtTypeofRef.Text, txtBillRefNo.Text, dtedueDate.Text, Convert.ToDouble(txtBillAmount.Text), txtBillDrcr.Text, dblComm, dblint);
                        txtBillAmount.Text = (Convert.ToDouble(txtBillPreTotal.Text) - Convert.ToDouble(txtBillTotal.Text)).ToString();
                    }

                }
                //txtBillDrcr.Text = uctxtDrCr.Text;
                uctxtTypeofRef.Text = "";
                txtBillRefNo.Text = "";
                txtComm.Text = "0";
                txtInte.Text = "0";
                uctxtTypeofRef.Focus();

            }
        }

        private void mAdditemBill(string strTypeofRef, string strBillRefNo, string strdueDate, double dblAmount, string strDrcr, double dblComm, double dblInt)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < dgBillBranch.RowCount; j++)
            {
                if (dgBillBranch[1, j].Value != null)
                {
                    strDown = dgBillBranch[2, j].Value.ToString();
                }
                if (strBillRefNo == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {

                dgBillBranch.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(dgBillBranch.RowCount.ToString());
                selRaw = selRaw - 1;
                dgBillBranch.Rows.Add();
                dgBillBranch[0, selRaw].Value = strTypeofRef.ToString();
                dgBillBranch[1, selRaw].Value = strBillRefNo.ToString();
                dgBillBranch[2, selRaw].Value = strdueDate.ToString();
                dgBillBranch[3, selRaw].Value = dblAmount.ToString();
                dgBillBranch[4, selRaw].Value = strDrcr.ToString();
                dgBillBranch[5, selRaw].Value = dblComm.ToString();
                dgBillBranch[6, selRaw].Value = dblInt.ToString();
                dgBillBranch.AllowUserToAddRows = false;
                uctxtTypeofRef.Text = "";
                txtBillRefNo.Text = "";
                txtBillAmount.Text = "";
                txtComm.Text = "0";
                txtInte.Text = "0";
                calculateTotal();
            }

        }


        private void txtComm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtInte.Focus();
            }
        }
        private void txtBillAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtBillDrcr.Focus();
            }
        }
        private void dtedueDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtBillAmount.Focus();
            }
        }
        private void txtBillRefNo_TextChanged(object sender, EventArgs e)
        {
            lstBillRefNo.SelectedIndex = lstBillRefNo.FindString(txtBillRefNo.Text);
        }

        private void lstBillRefNo_DoubleClick(object sender, EventArgs e)
        {
            txtBillRefNo.Text = lstBillRefNo.Text;
            dtedueDate.Focus();
        }

        private void txtBillRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBillRefNo.Items.Count > 0)
                {
                    txtBillRefNo.Text = lstBillRefNo.Text;
                }
                dtedueDate.Focus();

            }
        }
        private void txtBillRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBillRefNo.SelectedItem != null)
                {
                    lstBillRefNo.SelectedIndex = lstBillRefNo.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBillRefNo.Items.Count - 1 > lstBillRefNo.SelectedIndex)
                {
                    lstBillRefNo.SelectedIndex = lstBillRefNo.SelectedIndex + 1;
                }
            }

        }

        private void txtBillRefNo_GotFocus(object sender, System.EventArgs e)
        {

            lstTypeofRef.Visible = false;
            lstPrticulars.Visible = false;
            if (uctxtTypeofRef.Text == "Agst Ref")
            {
                lstBillRefNo.Visible = true;
                lstBillRefNo.SelectedIndex = lstBillRefNo.FindString(txtBillRefNo.Text);
            }
            else
            {
                lstBillRefNo.Visible = false;
            }

        }
        private void uctxtTypeofRef_TextChanged(object sender, EventArgs e)
        {
            lstTypeofRef.SelectedIndex = lstTypeofRef.FindString(uctxtTypeofRef.Text);
        }

        private void lstTypeofRef_DoubleClick(object sender, EventArgs e)
        {
            uctxtTypeofRef.Text = lstTypeofRef.Text;
            txtBillRefNo.Focus();
        }

        private void uctxtTypeofRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtBillTotal.Text == txtBillPreTotal.Text)
                {
                    btnBillapply.Focus();
                    return;
                }
                if (txtBillAmount.Text == "" || txtBillAmount.Text == "0")
                {
                    btnBillapply.Focus();
                    return;
                }
                else
                {
                    if (lstTypeofRef.Items.Count > 0)
                    {
                        uctxtTypeofRef.Text = lstTypeofRef.Text;
                    }

                    txtBillRefNo.Focus();
                }


            }
        }
        private void uctxtTypeofRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstTypeofRef.SelectedItem != null)
                {
                    lstTypeofRef.SelectedIndex = lstTypeofRef.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstTypeofRef.Items.Count - 1 > lstTypeofRef.SelectedIndex)
                {
                    lstTypeofRef.SelectedIndex = lstTypeofRef.SelectedIndex + 1;
                }
            }

        }

        private void uctxtTypeofRef_GotFocus(object sender, System.EventArgs e)
        {
            lstTypeofRef.Visible = true;
            lstPrticulars.Visible = false;
            lstTypeofRef.SelectedIndex = lstTypeofRef.FindString(uctxtTypeofRef.Text);
        }
        private void uctxtBatchNo_TextChanged(object sender, EventArgs e)
        {
            lstBatchNo.SelectedIndex = lstBatchNo.FindString(uctxtBatchNo.Text);
        }

        private void lstBatchNo_DoubleClick(object sender, EventArgs e)
        {
            uctxtBatchNo.Text = lstBatchNo.Text;
            txtDrcr.Focus();
        }

        private void uctxtBatchNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBatchNo.Items.Count > 0)
                {
                    uctxtBatchNo.Text = lstBatchNo.Text;
                }
                txtDrcr.Focus();

            }
        }
        private void uctxtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBatchNo.SelectedItem != null)
                {
                    lstBatchNo.SelectedIndex = lstBatchNo.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBatchNo.Items.Count - 1 > lstBatchNo.SelectedIndex)
                {
                    lstBatchNo.SelectedIndex = lstBatchNo.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBatchNo_GotFocus(object sender, System.EventArgs e)
        {
            lstBatchNo.Visible = true;
            lstBranchName.Visible = false;
            lstPrticulars.Visible = false;
            lstBatchNo.SelectedIndex = lstBatchNo.FindString(uctxtBatchNo.Text);
        }




        private void txtSingleNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtDrcr.Text == "Dr")
                {
                    txtDebitAmount.Focus();
                }
                else
                {
                    txtCreditAmount.Focus();
                }

            }
        }
        private void txtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtParticulars, sender, e);
            }
        }
        private void txtChequeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                mskChequeDate.Focus();
            }
        }
        private void mskChequeDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtDrawnon.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                txtChequeNo.Focus();
            }
        }
        private void txtDrawnon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnBankApply.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtDrawnon, txtChequeNo);
            }
        }
        #endregion
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dbldebitAmount = 0, dblCreditAmount = 0, dblNetAmount = 0, dblBillAmount = 0,dblInvmsAmount=0,dblJvTemplate=0,dblFine=0;
            for (int i = 0; i < DG.Rows.Count; i++)
            {
                dbldebitAmount = dbldebitAmount + Convert.ToDouble(DG.Rows[i].Cells[9].Value);
                dblCreditAmount = dblCreditAmount + Convert.ToDouble(DG.Rows[i].Cells[10].Value);
            }
            for (int i = 0; i < DgCostCenter.Rows.Count; i++)
            {
                dblNetAmount = dblNetAmount + Convert.ToDouble(DgCostCenter.Rows[i].Cells[2].Value);
            }
            for (int i = 0; i < dgBillBranch.Rows.Count; i++)
            {
                dblBillAmount = dblBillAmount + Convert.ToDouble(dgBillBranch.Rows[i].Cells[3].Value);
            }
            for (int i = 0; i < DGinvms.Rows.Count; i++)
            {
                dblInvmsAmount = dblInvmsAmount + Convert.ToDouble(DGinvms.Rows[i].Cells[5].Value);
            }
            for (int i = 0; i < DGJVTemplate.Rows.Count; i++)
            {
                dblJvTemplate = dblJvTemplate + Convert.ToDouble(DGJVTemplate.Rows[i].Cells[3].Value);
                dblFine = dblFine + Convert.ToDouble(DGJVTemplate.Rows[i].Cells[4].Value);
            }

            txtNetDebit.Text = dbldebitAmount.ToString();
            txtNetCredit.Text = dblCreditAmount.ToString();
            txtTotal.Text = dblNetAmount.ToString();
            txtBillTotal.Text = dblBillAmount.ToString();
            txtInvmsAmount.Text = dblInvmsAmount.ToString();
            uctxtJVTotal.Text = dblJvTemplate.ToString();
            txtJvFine.Text = dblFine.ToString();
        }
        #endregion
        private void uclstGrdItem_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (uclstGrdItem.SelectedRows.Count > 0)
            {
                uctxtItemName.Text = Utility.GetDgValue(uclstGrdItem, uctxtItemName, 0);
                uclstGrdItem.Visible = false;
                uctxtQty.Focus();


            }
        }
        private void uclstGrdItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtItemName.Text = Utility.GetDgValue(uclstGrdItem, uctxtItemName, 0);
                uclstGrdItem.Visible = false;
                uctxtQty.Focus();
            }
        }
        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (uctxtItemName.Text == "")
                {
                    uctxtItemName.Text = "";
                    uclstGrdItem.Visible = false;
                    btnAppInvms.Focus();
                    return;
                }


                if (uctxtItemName.Text != "")
                {
                    uclstGrdItem.Focus();
                    if (uclstGrdItem.Rows.Count > 0)
                    {
                        int i = 0;

                        uctxtItemName.Text = uclstGrdItem.Rows[i].Cells[0].Value.ToString();
                        uclstGrdItem.Visible = false;
                        uctxtQty.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtItemName.Text = uclstGrdItem.Rows[i].Cells[0].Value.ToString();
                    uclstGrdItem.Visible = false;
                    uctxtQty.Focus();
                }
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtItemName, uctxtLocation);
            }
        }
        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            uclstGrdItem.Visible = true;
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
            if (e.KeyCode == Keys.Up)
            {
                uclstGrdItem.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                uclstGrdItem.Focus();
            }

            uclstGrdItem.Top = uctxtItemName.Top + 25;
            uclstGrdItem.Left = uctxtItemName.Left;
            uclstGrdItem.Width = uctxtItemName.Width;
            uclstGrdItem.Height = 120;
            //ucdgList.Size = new Size(546, 222);
            uclstGrdItem.BringToFront();
            uclstGrdItem.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }

        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {

            mloadItem();
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstLocation.Visible = false;

        }
        private void mloadItem()
        {
            int introw = 0;
            uclstGrdItem.Rows.Clear();
            if (uctxtLocation.Text == "")
            {
                return;
            }
            string strDate = DateTime.Now.ToString("dd-MM-yyyy");
            oogrp = invms.mloadAddStockItemRMPack(strComID, uctxtLocation.Text, "", "N").ToList();
            //oogrp = objwois.gFillStockItem(strComID, uctxtLocation.Text).ToList();
         
            //oogrp = invms.mloadAddStockItemSI(strComID, uctxtGroupName.Text, uctxtLocation.Text).ToList();
            //oogrp = objWIS.mGetProductStatementNew(strComID, strDate, "'" + uctxtGroupName.Text.ToString() + "' ", "0001").ToList();

            if (oogrp.Count > 0)
            {

                foreach (StockItem ogrp in oogrp)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, introw].Value = ogrp.strItemName;
                    uclstGrdItem[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;

                    introw += 1;
                }

                uclstGrdItem.AllowUserToAddRows = false;
            }
        }
        #region "User Define event"
        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }
        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            lstLocation.Visible = false;
            uctxtItemName.Focus();
           

        }
        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                }

                uctxtItemName.Focus();

            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    Utility.PriorSetFocusText(txtBranchName, dteVoucherDate);
            //}
        }
        private void uctxtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLocation.SelectedItem != null)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLocation.Items.Count - 1 > lstLocation.SelectedIndex)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex + 1;
                }
            }
          

        }
        private void uctxtLocation_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstBatchNo.Visible = false;
            lstPrticulars.Visible = false;
            lstLocation.Visible = true;
            uclstGrdItem.Visible = false;
            lstLocation.ValueMember = "strLocation";
            lstLocation.DisplayMember = "strLocation";
            lstLocation.DataSource = invms.gLoadLocation(strComID, "", Utility.gblnAccessControl, Utility.gstrUserName, 0).ToList();
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }
        private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                txtChequeNo.Text = "";
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                txtChequeNo.AppendText((String)rk.GetValue("CHEQUENO" + intvtype.ToString(), ""));
                rk.Close();
            }

        }
        //private void frmAccountsVoucher_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //if (e.KeyCode == Keys.Escape)
        //    //{
        //    //    var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    //    if (strResponse == DialogResult.Yes)
        //    //    {
        //    //        //this.Dispose();
        //    //    }
        //    //}
        //}
        private void uctxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (uctxtAmount.Text != "")
                {
                    if (uctxtAmount.Text != "0")
                    {
                        mAdditemCostCenter("", uctxtCostCategory.Text, uctxtCostCenter.Text, Convert.ToDouble(uctxtAmount.Text), txtdrcr1.Text);
                        uctxtCostCenter.Text = "";
                        uctxtCostCenter.Focus();
                        uctxtAmount.Text = (Utility.Val(txtpreAmount.Text) - Utility.Val(txtTotal.Text)).ToString();
                    }
                    else
                    {
                        btnApply.Focus();
                    }
                }
                else
                {
                    uctxtAmount.Focus();
                }
                calculateTotal();
                uctxtCostCategory.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtAmount, uctxtCostCenter);
            }
        }
        private void uctxtAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = false;
            lstCostCategory.Visible = false;
            lstBranchName.Visible = false;
            lstPrticulars.Visible = false;
        }
        private void uctxtCostCenter_TextChanged(object sender, EventArgs e)
        {
            lstCostCenter.SelectedIndex = lstCostCenter.FindString(uctxtCostCenter.Text);
        }

        private void lstCostCenter_DoubleClick(object sender, EventArgs e)
        {
            uctxtCostCenter.Text = lstCostCenter.Text;
            uctxtAmount.Focus();
        }

        private void uctxtCostCenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtCostCenter.Text !="")
                {
                    uctxtCostCenter.Text = lstCostCenter.Text;
                    uctxtAmount.Focus();
                }
                else
                {
                    uctxtCostCenter.Focus();
                }
                uctxtAmount.Text = (Utility.Val(txtpreAmount.Text) - Utility.Val(txtTotal.Text)).ToString();
               

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtCostCenter, uctxtCostCategory);
            }
        }
        private void uctxtCostCenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCostCenter.SelectedItem != null)
                {
                    lstCostCenter.SelectedIndex = lstCostCenter.SelectedIndex - 1;
                    uctxtCostCenter.Text = lstCostCenter.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCostCenter.Items.Count - 1 > lstCostCenter.SelectedIndex)
                {
                    lstCostCenter.SelectedIndex = lstCostCenter.SelectedIndex + 1;
                    uctxtCostCenter.Text = lstCostCenter.Text;
                }
            }

        }
        private void mAdditemCostCenter(string strBranchName, string strCostCategory, string strCostCenter, double dblnetamount, string strDrcr)
        {
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < DgCostCenter.RowCount; j++)
            {
                if (DgCostCenter[1, j].Value != null)
                {
                    strDown = DgCostCenter[1, j].Value.ToString();
                }
                if (strCostCenter == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {

                DgCostCenter.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DgCostCenter.RowCount.ToString());
                selRaw = selRaw - 1;
                DgCostCenter.Rows.Add();
                //DgCostCenter[0, selRaw].Value = strBranchName.ToString();
                DgCostCenter[0, selRaw].Value = strCostCategory.ToString();
                DgCostCenter[1, selRaw].Value = strCostCenter.ToString();
                DgCostCenter[2, selRaw].Value = dblnetamount.ToString();
                DgCostCenter[4, selRaw].Value = strDrcr;
                DgCostCenter.AllowUserToAddRows = false;
                calculateTotal();
            }

        }
        private void uctxtCostCenter_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCenter.Visible = true;
            lstCostCategory.Visible = false;
            lstBranchName.Visible = false;
            lstPrticulars.Visible = false;
            if (uctxtCostCategory.Text != "")
            {
                lstCostCenter.ValueMember = "strCostCenter";
                lstCostCenter.DisplayMember = "strCostCenter";
                lstCostCenter.DataSource = accms.mFillVectorMaster(strComID, uctxtCostCategory.Text).ToList();
            }
            lstCostCenter.SelectedIndex = lstCostCenter.FindString(uctxtCostCenter.Text);
        }
        private void uctxtCostCategory_TextChanged(object sender, EventArgs e)
        {
            lstCostCategory.Visible = true;
            lstCostCategory.SelectedIndex = lstCostCategory.FindString(uctxtCostCategory.Text);
        }

        private void lstCostCategory_DoubleClick(object sender, EventArgs e)
        {
            uctxtCostCategory.Text = lstCostCategory.Text;
            uctxtCostCenter.Focus();
        }

        private void uctxtCostCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (Utility.Val(txtpreAmount.Text) == Utility.Val(txtTotal.Text))
                {
                    btnApply.Focus();
                    return;
                }

                if (uctxtAmount.Text != "0")
                {
                    if (uctxtCostCategory.Text !="")
                    {
                        uctxtCostCategory.Text = lstCostCategory.Text;
                        uctxtCostCenter.Focus();
                    }
                    else
                    {
                        btnApply.Focus();
                    }
                   
                }
                else
                {
                    btnApply.Focus();
                }

            }
        }
        private void uctxtCostCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCostCategory.SelectedItem != null)
                {
                    lstCostCategory.SelectedIndex = lstCostCategory.SelectedIndex - 1;
                    uctxtCostCategory.Text = lstCostCategory.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCostCategory.Items.Count - 1 > lstCostCategory.SelectedIndex)
                {
                    lstCostCategory.SelectedIndex = lstCostCategory.SelectedIndex + 1;
                    uctxtCostCategory.Text = lstCostCategory.Text;
                }
            }

        }

        private void uctxtCostCategory_GotFocus(object sender, System.EventArgs e)
        {
            //lstCostCategory.Visible = false;
            lstCostCenter.Visible = false;
            lstBranchName.Visible = false;
            lstPrticulars.Visible = false;

        }


        private void uctxtVoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                dteVoucherDate.Focus();

            }
        }
        private void dteVoucherDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if ((intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) || (intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER))
                {
                    if (cboGeneral.Text == "")
                    {
                        MessageBox.Show("Selection Type Cannot be Empty");
                        cboGeneral.Focus();
                        return;
                    }
                }
                dteVoucherDate.Text = Utility.ctrlDateFormat(dteVoucherDate.Text);
                if (dteVoucherDate.Text =="")
                {
                    dteVoucherDate.Focus();
                    return;
                }
                if (txtBranchName.Enabled)
                {
                    txtBranchName.Focus();
                }
                else if (uctxtBatchNo.Enabled)
                {
                    uctxtBatchNo.Focus();
                }
                else
                {
                    txtDrcr.Focus();
                }
            }
            //if (e.KeyChar==(char)Keys.Back)
            //{
            //    cboGeneral.Focus();
            //}
        }
        private void txtDrcre_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false; ;
            lstBatchNo.Visible = false;
            lstPrticulars.Visible = false;
        }
        private void txtParticulars_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstBatchNo.Visible = false;
            lstPrticulars.Visible = true;
            mLoadAccountsVoucher(intvtype, txtDrcr.Text);
            lstPrticulars.SelectedIndex = lstPrticulars.FindString(txtParticulars.Text);

        }
       
        private void txtSingleNarration_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstBatchNo.Visible = false;
            lstPrticulars.Visible = false;

        }
        private void txtDebitAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstBatchNo.Visible = false;
            lstPrticulars.Visible = false;
        }
        private void txtCreditAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstBatchNo.Visible = false;
            lstPrticulars.Visible = false;
        }
        private void txtDrcr_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstBatchNo.Visible = false;
            lstPrticulars.Visible = false;
        }
        private void txtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.SelectedIndex = lstBranchName.FindString(txtBranchName.Text);
        }
        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            txtBranchName.Text = lstBranchName.Text;
            lstBranchName.Visible = false;
            
            if (uctxtBatchNo.Enabled)
            {
                uctxtBatchNo.Focus();
            }
            else
            {
                txtParticulars.Focus();
            }

        }
        private void txtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if ((intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) || (intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER))
                {
                    if (cboGeneral.Text == "")
                    {
                        MessageBox.Show("Selection Type Cannot be Empty");
                        cboGeneral.Focus();
                        return;
                    }
                }
                if (lstBranchName.Items.Count > 0)
                {
                    txtBranchName.Text = lstBranchName.Text;
                }
               
                if (uctxtBatchNo.Enabled)
                {
                    uctxtBatchNo.Focus();
                }
                else
                {
                    txtParticulars.Focus();
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(txtBranchName,dteVoucherDate);
            }
        }
        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranchName.SelectedItem != null)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranchName.Items.Count - 1 > lstBranchName.SelectedIndex)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex + 1;
                }
            }
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                frmBranch objfrm = new frmBranch();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.mSingleEntry = 1;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }

        }
        private void txtBranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = true;
            lstBatchNo.Visible = false;
            lstPrticulars.Visible = false;
        }
        private void txtDrcr_KeyDown(object sender, KeyEventArgs e)
        {


        }
        private void txtDrcr_TextChanged(object sender, EventArgs e)
        {

            if (txtDrcr.Text.Substring(0, 1).ToUpper() == "D")
            {
                txtDrcr.Text = "Dr";
                txtParticulars.Focus();
            }
            else if (txtDrcr.Text.Substring(0, 1).ToUpper() == "C")
            {
                txtDrcr.Text = "Cr";
                txtParticulars.Focus();
            }




        }
        //private void DGMr_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Return)
        //    {

        //        int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
        //        uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
        //        uctxtTeritorryName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
        //        txtParticulars.Text = DGMr.Rows[i].Cells[1].Value.ToString();
        //        lblCurrentBalance.Text = "Curr. Bal.: " + Utility.gstrLedgerBalance(strComID, txtParticulars.Text);
        //        DGMr.Visible = false;
        //        mKeypress();
        //        if (txtDrcr.Text == "Dr")
        //        {
        //            txtDebitAmount.Focus();
        //        }
        //        else
        //        {
        //            txtCreditAmount.Focus();
        //        }
        //    }
        //}
        //private void DGMr_DoubleClick(object sender, EventArgs e)
        //{
        //    //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
        //    //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
        //    //int LastDay = lastDay.Day;


        //    if (DGMr.SelectedRows.Count > 0)
        //    {
        //        int i = Convert.ToInt16(DGMr.CurrentRow.Index.ToString());
              
        //        uctxtTerritoryCode.Text = DGMr.Rows[i].Cells[0].Value.ToString();
        //        uctxtTeritorryName.Text = DGMr.Rows[i].Cells[2].Value.ToString();
        //        txtParticulars.Text = DGMr.Rows[i].Cells[1].Value.ToString();
        //        lblCurrentBalance.Text = "Curr. Bal.: " + Utility.gstrLedgerBalance(strComID, txtParticulars.Text);
        //        DGMr.Visible = false;
        //        mKeypress();
        //        if (txtDrcr.Text == "Dr")
        //        {
        //            txtDebitAmount.Focus();
        //        }
        //        else
        //        {
        //            txtCreditAmount.Focus();
        //        }


        //    }
        //}

        private void txtParticulars_TextChanged(object sender, EventArgs e)
        {
            lstPrticulars.SelectedIndex = lstPrticulars.FindString(txtParticulars.Text);
            //if (txtParticulars.Text == "")
            //{
            //    uctxtTerritoryCode.Text = "";
            //    uctxtTeritorryName.Text = "";
            //}


        }
        //private void txtParticulars_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //if (e.KeyCode == Keys.F3)
        //    //{
        //    //    frmSearch objfrm = new frmSearch();
        //    //    objfrm.MdiParent = MdiParent;
        //    //    objfrm.mintGrouptype = intvtype;
        //    //    objfrm.mstrdrcr = txtDrcr.Text;
        //    //    objfrm.onAddAllButtonClicked = new frmSearch.AddAllClick(DisplayReqList);
        //    //    objfrm.Show();
        //    //    objfrm.MdiParent = this.MdiParent;
        //    //}
        //    DGMr.Visible = true;
        //    if (e.KeyCode == Keys.Up)
        //    {
        //        DGMr.Focus();
        //    }
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        DGMr.Focus();
        //    }
        //    DGMr.Top = txtParticulars.Top + 25;
        //    DGMr.Left = txtParticulars.Left;
        //    DGMr.Width = txtParticulars.Width;
        //    DGMr.Height = 270;
        //    //ucdgList.Size = new Size(546, 222);
        //    DGMr.BringToFront();
        //    DGMr.AllowUserToAddRows = false;
        //    //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
        //    //ucdgList.Focus();
        //    return;

        //}
        private void txtCreditAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            double dblCredittAmnt = 0, dblcharge = 0;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (intvtype != 3)
                {
                    chkIncludeX.Checked = false;
                }

                if (txtCreditAmount.Text == "0")
                {
                    txtCreditAmount.Focus();
                    return;
                }
                if (txtParticulars.Text != "" && txtCreditAmount.Text != "0" && intSelectedType == 0)
                {
                    if (intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER)
                    {
                        if (Utility.gbcheckBkashEffec(strComID, intvtype))
                        {
                            if (Utility.gbcheckBkashLedger(strComID, lstPrticulars.SelectedValue.ToString()))
                            {
                                //if (chkBkashCharge.Checked == true)
                                if (cboGeneral.Text == "With Bkash Account")
                                {
                                    dblcharge = Math.Round((Utility.Val(txtCreditAmount.Text) * 1.5) / 100, 2);
                                    dblCredittAmnt = Utility.Val(txtCreditAmount.Text.ToString()) - dblcharge;
                                    addItem(txtDrcr.Text, txtParticulars.Text, lstPrticulars.SelectedValue.ToString(), Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                           Convert.ToDouble(Utility.Val(txtDebitAmount.Text.ToString())), dblCredittAmnt, "", "", 0);
                                    addItem(txtDrcr.Text, "Bkash Charge (L)", "Bkash Charge (L)", Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                         Convert.ToDouble(Utility.Val(txtDebitAmount.Text.ToString())), dblcharge, "", "", 0);
                                }
                                else
                                {
                                    addItem(txtDrcr.Text, txtParticulars.Text, lstPrticulars.SelectedValue.ToString(), Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                       Convert.ToDouble(Utility.Val(txtDebitAmount.Text.ToString())), Convert.ToDouble(Utility.Val(txtCreditAmount.Text)), "", "", 0);
                                }
                            }
                            else
                            {

                                addItem(txtDrcr.Text, txtParticulars.Text, lstPrticulars.SelectedValue.ToString(), Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                       Convert.ToDouble(Utility.Val(txtDebitAmount.Text.ToString())), Convert.ToDouble(Utility.Val(txtCreditAmount.Text)), "", "", 0);
                               
                            }
                        }
                        else
                        {
                            addItem(txtDrcr.Text, txtParticulars.Text, lstPrticulars.SelectedValue.ToString(), Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                       Convert.ToDouble(Utility.Val(txtDebitAmount.Text.ToString())), Convert.ToDouble(Utility.Val(txtCreditAmount.Text)), "", "", 0);
                        }
                    }
                    else
                    {
                        if (intvtype == 3)
                        {
                            if (Utility.Left(txtParticulars.Text.ToString().ToUpper(), 2) == "HL")
                            {
                                DG[9, 0].Value = 0;
                                DG[9, 0].Value = Convert.ToDouble(Utility.Val(txtCreditAmount.Text));

                                addItem(txtDrcr.Text, txtParticulars.Text, lstPrticulars.SelectedValue.ToString(), Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                     Convert.ToDouble(Utility.Val(txtDebitAmount.Text.ToString())), Convert.ToDouble(Utility.Val(txtCreditAmount.Text)), "", "", 0);
                                //if (Utility.Val (txtFine.Text) > 0)
                                //{
                                //    addItem(txtDrcr.Text, "HL-Late Payment Fine", "HL-Late Payment Fine", Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                //      0, Convert.ToDouble(Utility.Val(txtFine.Text.ToString())), "", "", 0);
                                //    addItem("Dr", txtParticulars.Text, txtParticulars.Text, Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                //      Convert.ToDouble(Utility.Val(txtFine.Text.ToString())), 0, "", "", 0);
                                //    //DG[9, 0].Value = Utility.Val(txtNetDebit.Text) + Utility.Val(txtFine.Text.ToString());
                                //}
                            }
                            else
                            {
                                addItem(txtDrcr.Text, txtParticulars.Text, lstPrticulars.SelectedValue.ToString(), Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                     Convert.ToDouble(Utility.Val(txtDebitAmount.Text.ToString())), Convert.ToDouble(Utility.Val(txtCreditAmount.Text)), "", "", 0);
                            }
                        }
                        else
                        {
                            addItem(txtDrcr.Text, txtParticulars.Text, lstPrticulars.SelectedValue.ToString(), Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                     Convert.ToDouble(Utility.Val(txtDebitAmount.Text.ToString())), Convert.ToDouble(Utility.Val(txtCreditAmount.Text)), "", "", 0);
                        }
                    }
                    txtParticulars.Text = "";
                    txtSingleNarration.Text = "";
                    uctxtTeritorryName.Text = "";
                    uctxtTerritoryCode.Text = "";
                    txtDebitAmount.Text = "0";
                    txtCreditAmount.Text = "0";
                }
                if (intSelectedType == 1)
                {
                    txtParticulars.Text = "";
                    txtSingleNarration.Text = "";
                    uctxtTeritorryName.Text = "";
                    uctxtTerritoryCode.Text = "";
                    txtDebitAmount.Text = "0";
                    txtCreditAmount.Text = "0";
                    intSelectedType = 0;
                }
                calculateTotal();
                if (intvtype == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER || intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER)
                {
                    txtDrcr.Text = "Cr";

                    if (txtNetDebit.Text == txtNetCredit.Text)
                    {
                        if (grpBankInformation.Visible == false)
                        {
                            txtNarration.Focus();
                        }
                    }
                    else
                    {
                        if (grpBankInformation.Visible)
                        {
                            txtChequeNo.Focus();
                        }
                        else
                        {
                            txtDrcr.Focus();
                            txtDrcr.Select();
                        }
                    }
                }
                else if (intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER || intvtype == (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER)
                {
                    if (pnlCostCenter.Visible)
                    {
                        uctxtCostCategory.Focus();
                        return;
                    }
                    else
                    {
                        txtDrcr.Text = "Dr";
                    }
                    if (txtNetDebit.Text == txtNetCredit.Text)
                    {
                        txtNarration.Focus();
                    }
                    else
                    {
                        if (grpBankInformation.Visible)
                        {
                            txtChequeNo.Focus();
                            lstPrticulars.Visible = false;
                            return;
                        }
                        else
                        {
                            txtDrcr.Focus();
                            txtDrcr.Select();
                        }
                    }
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtCreditAmount, sender, e);
            }
        }
        private void txtDebitAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            double dblCredittAmnt = 0, dblcharge = 0;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (intvtype != 3)
                {
                    chkIncludeX.Checked = false;
                }
                if (txtDebitAmount.Text == "0")
                {
                    txtDebitAmount.Focus();
                    return;
                }
                if (txtParticulars.Text != "" && txtDebitAmount.Text != "0" && intSelectedType == 0)
                {

                    if (intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER)
                    {
                        if (Utility.gbcheckBkashEffec(strComID, intvtype))
                        {
                            if (Utility.gbcheckBkashLedger(strComID, DG[3,0].Value.ToString())==false)
                            {
                                if (cboGeneral.Text == "With Bkash Account")
                                {
                                    dblcharge = Math.Round((Utility.Val(txtDebitAmount.Text) * 1.5) / 100, 2);
                                    dblCredittAmnt = Utility.Val(txtDebitAmount.Text.ToString()) - dblcharge;
                                    addItem(txtDrcr.Text, "Bkash Charge (Exp.)", "Bkash Charge (Exp.)", Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                       dblcharge, Convert.ToDouble(Utility.Val(txtCreditAmount.Text)), "", "", 0);
                                    addItem(txtDrcr.Text, txtParticulars.Text, lstPrticulars.SelectedValue.ToString(), Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                        dblCredittAmnt, Convert.ToDouble(Utility.Val(txtCreditAmount.Text)), "", "", 0);
                                }
                                else
                                {
                                    addItem(txtDrcr.Text, txtParticulars.Text, lstPrticulars.SelectedValue.ToString(), Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                                Convert.ToDouble(Utility.Val(txtDebitAmount.Text.ToString())), Convert.ToDouble(Utility.Val(txtCreditAmount.Text)), "", "", 0);
                                }

                            }
                            else
                            {
                                addItem(txtDrcr.Text, txtParticulars.Text, lstPrticulars.SelectedValue.ToString(), Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                             Convert.ToDouble(Utility.Val(txtDebitAmount.Text.ToString())), Convert.ToDouble(Utility.Val(txtCreditAmount.Text)), "", "", 0);
                            }
                        }
                        else
                        {
                            addItem(txtDrcr.Text, txtParticulars.Text, lstPrticulars.SelectedValue.ToString(), Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                                    Convert.ToDouble(Utility.Val(txtDebitAmount.Text.ToString())), Convert.ToDouble(Utility.Val(txtCreditAmount.Text)), "", "", 0);
                        }
                    }
                    else
                    {
                        addItem(txtDrcr.Text, txtParticulars.Text, lstPrticulars.SelectedValue.ToString(), Utility.gCheckNull(uctxtTeritorryName.Text), Utility.gCheckNull(txtSingleNarration.Text), "", "", "",
                         Convert.ToDouble(Utility.Val(txtDebitAmount.Text.ToString())), Convert.ToDouble(Utility.Val(txtCreditAmount.Text)), "", "", 0);
                    }

                  
                    txtParticulars.Text = "";
                    txtSingleNarration.Text = "";
                    uctxtTeritorryName.Text = "";
                    uctxtTerritoryCode.Text = "";
                    txtDebitAmount.Text = "0";
                    txtCreditAmount.Text = "0";
                    calculateTotal();
                    if (intvtype == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER || intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER)
                    {
                        txtDrcr.Text = "Cr";

                        if (txtNetDebit.Text == txtNetCredit.Text)
                        {
                            if (pnlCostCenter.Visible)
                            {
                                uctxtCostCategory.Focus();
                            }
                            else
                            {
                                txtDrcr.Focus();
                            }
                        }
                        else
                        {
                            if (pnlCostCenter.Visible)
                            {
                                uctxtCostCategory.Focus();
                            }
                            else
                            {
                                if (grpBankInformation.Visible)
                                {
                                    txtChequeNo.Focus();
                                    lstPrticulars.Visible = false;
                                    return;
                                }
                                else
                                {
                                    txtDrcr.Focus();
                                    txtDrcr.Select();
                                }
                            }
                        }
                    }
                    else if (intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER || intvtype == (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER)
                    {
                        txtDrcr.Text = "Dr";
                        if (txtNetDebit.Text == txtNetCredit.Text)
                        {
                            if (grpBankInformation.Visible)
                            {
                                txtChequeNo.Focus();
                            }
                            else
                            {
                                txtNarration.Focus();
                            }
                        }
                        else
                        {
                            if (pnlCostCenter.Visible)
                            {
                                uctxtCostCategory.Focus();
                            }
                            else
                            {
                                if (grpBankInformation.Visible)
                                {

                                    txtChequeNo.Focus();
                                    lstPrticulars.Visible = false;
                                    return;
                                }
                                else
                                {
                                    txtDrcr.Focus();
                                    txtDrcr.Select();
                                }
                            }
                        }
                    }
                }
                if (intSelectedType == 1)
                {
                    txtParticulars.Text = "";
                    txtSingleNarration.Text = "";
                    uctxtTeritorryName.Text = "";
                    uctxtTerritoryCode.Text = "";
                    txtDebitAmount.Text = "0";
                    txtCreditAmount.Text = "0";
                    intSelectedType = 0;
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtDebitAmount, sender, e);
            }
        }
        private void lstPrticulars_DoubleClick(object sender, EventArgs e)
        {
            txtParticulars.Text = lstPrticulars.Text;
            lstPrticulars.Visible = false;
            mKeypress();
           
            if (txtDebitAmount.Enabled)
            {
                txtDebitAmount.Focus();
            }
            else
            {
                txtCreditAmount.Focus();
            }
            if (intvtype == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER)
            {

                if (Utility.Left(txtParticulars.Text.ToString().ToUpper(), 2) == "HL")
                {
                    pnlTemplate.Visible = true;
                    txtTemplateAllocation.Text = txtParticulars.Text;
                    pnlTemplate.Top = txtSingleNarration.Top + 60;
                    pnlTemplate.Left = txtSingleNarration.Left;
                    pnlTemplate.Size = new Size(785, 221);
                    DGTemplate.Size = new Size(769, 102);
                    btnApply.Top = DGTemplate.Height + 87;
                    btnCancel.Top = DGTemplate.Height + 87;
                    txtTemplateName.Focus();
                    txtTemplateName.Select();
                    if (txtParticulars.Text.Trim() != txtTemplateAllocation.Text.Trim())
                    {
                        DGTemplate.Rows.Clear();
                    }
                }
            }
            else if (intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER)
            {
                if (txtParticulars.Text != "")
                {
                    if (Utility.Left(txtParticulars.Text.ToString().ToUpper(), 2) == "HL" && Utility.Left(txtDrcr.Text.ToString().ToUpper(), 2) == "CR")
                    {
                        //if (chkLoanTransfer.Checked == false)
                        if (cboGeneral.Text != "HL-Transfer")
                        {
                            if (txtParticulars.Text != "HL-Late Payment Fine")
                            {
                                panelRvSchedule.Visible = true;
                                uctxtAllocationJV.Text = txtParticulars.Text;
                                panelRvSchedule.Top = txtSingleNarration.Top + 60;
                                panelRvSchedule.Left = txtSingleNarration.Left;
                                panelRvSchedule.Size = new Size(785, 221);
                                DGJVTemplate.Size = new Size(769, 102);
                                btnJVapply.Top = DGJVTemplate.Height + 87;
                                btnJVCancel.Top = DGJVTemplate.Height + 87;
                                txtInstallment.Focus();
                                txtInstallment.Select();
                                if (txtParticulars.Text.Trim() != uctxtAllocationJV.Text.Trim())
                                {
                                    DGJVTemplate.Rows.Clear();
                                }
                            }
                        }

                    }
                    else if (Utility.Left(txtParticulars.Text.ToString().ToUpper(), 2) == "HL" && Utility.Left(txtDrcr.Text.ToString().ToUpper(), 2) == "DR")
                    {
                        //txtCreditAmount.Text = Utility.GetHLTransferAmount(strComID, txtParticulars.Text).ToString();
                    }
                    else
                    {
                        mDisplayewffectInventory();
                    }
                }
            }
            else
            {
                mDisplayewffectInventory();
            }
           lblBalance.Text  = "Curr. Balance: " + Utility.gstrLedgerBalance(strComID, lstPrticulars.SelectedValue.ToString());
        }
        private void txtParticulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstPrticulars.SelectedItem != null)
                {
                    lstPrticulars.SelectedIndex = lstPrticulars.SelectedIndex - 1;
                    txtParticulars.Text = lstPrticulars.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstPrticulars.Items.Count - 1 > lstPrticulars.SelectedIndex)
                {
                    lstPrticulars.SelectedIndex = lstPrticulars.SelectedIndex + 1;
                    txtParticulars.Text = lstPrticulars.Text;
                }
            }

        }
        private void txtParticulars_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                try
                {
                    if (lstPrticulars.Items.Count > 0)
                    {
                        if (txtParticulars.Text != "")
                        {
                            txtParticulars.Text = lstPrticulars.Text;
                            mKeypress();

                            if (txtDebitAmount.Enabled)
                            {
                                txtDebitAmount.Focus();
                            }
                            else
                            {
                                txtCreditAmount.Focus();
                            }
                        }
                        else
                        {
                            txtNarration.Focus();
                        }
                        if (intvtype == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER)
                        {
                            if (txtParticulars.Text != "")
                            {
                                if (Utility.Left(txtParticulars.Text.ToString().ToUpper(), 2) == "HL" && Utility.Left(txtDrcr.Text.ToString().ToUpper(), 2) == "DR")
                                {
                                    pnlTemplate.Visible = true;
                                    txtTemplateAllocation.Text = txtParticulars.Text;
                                    pnlTemplate.Top = txtSingleNarration.Top + 60;
                                    pnlTemplate.Left = txtSingleNarration.Left;
                                    pnlTemplate.Size = new Size(785, 221);
                                    DGTemplate.Size = new Size(769, 102);
                                    btnApply.Top = DGTemplate.Height + 87;
                                    btnCancel.Top = DGTemplate.Height + 87;
                                    txtTemplateName.Focus();
                                    txtTemplateName.Select();
                                    if (txtParticulars.Text.Trim() != txtTemplateAllocation.Text.Trim())
                                    {
                                        DGTemplate.Rows.Clear();
                                    }
                                }
                            }
                        }
                        else if (intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER)
                        {
                            if (txtParticulars.Text != "")
                            {
                                if (Utility.Left(txtParticulars.Text.ToString().ToUpper(), 2) == "HL" && Utility.Left(txtDrcr.Text.ToString().ToUpper(), 2) == "CR")
                                {
                                    if (cboGeneral.Text != "HL-Transfer")
                                    {
                                        if (txtParticulars.Text != "HL-Late Payment Fine")
                                        {
                                            if ((int)cboGeneral.SelectedValue != 4)
                                            {
                                                panelRvSchedule.Visible = true;
                                                uctxtAllocationJV.Text = txtParticulars.Text;
                                                panelRvSchedule.Top = txtSingleNarration.Top + 60;
                                                panelRvSchedule.Left = txtSingleNarration.Left;
                                                panelRvSchedule.Size = new Size(785, 221);
                                                DGJVTemplate.Size = new Size(769, 102);
                                                btnJVapply.Top = DGJVTemplate.Height + 87;
                                                btnJVCancel.Top = DGJVTemplate.Height + 87;
                                                txtInstallment.Focus();
                                                txtInstallment.Select();
                                                if (txtParticulars.Text.Trim() != uctxtAllocationJV.Text.Trim())
                                                {
                                                    DGJVTemplate.Rows.Clear();
                                                }
                                            }
                                        }
                                    }

                                }
                                else if (Utility.Left(txtParticulars.Text.ToString().ToUpper(), 2) == "HL" && Utility.Left(txtDrcr.Text.ToString().ToUpper(), 2) == "DR")
                                {
                                    //if (chkLoanTransfer.Checked)
                                    //{
                                    //    txtDebitAmount.Text = Utility.GetHLTransferAmount(strComID, txtParticulars.Text).ToString();
                                    //}
                                }
                                else
                                {
                                    mDisplayewffectInventory();
                                }
                            }
                           
                        }
                       

                        else
                        {
                            mDisplayewffectInventory();
                        }
                    }
                    lblBalance.Text = "Curr. Balance: " + Utility.gstrLedgerBalance(strComID, lstPrticulars.SelectedValue.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtParticulars, sender, e);
            }
        }
        private void mDisplayewffectInventory()
        {
            if (Utility.mblnInventoryEffect(strComID, txtParticulars.Text) == true)
            {
                
                pnlCostCenter.Visible = false;
                PanelInventory.Visible = true;
                txtAllocation.Text = txtParticulars.Text;
                PanelInventory.Top = txtSingleNarration.Top + 60;
                PanelInventory.Left = txtSingleNarration.Left;
                PanelInventory.Size = new Size(785, 221);
                DGinvms.Size = new Size(769, 102);
                btnApply.Top = DGinvms.Height + 87;
                btnCancel.Top = DGinvms.Height + 87;
                uctxtLocation.Focus();
                uctxtLocation.Select();
                if (txtParticulars.Text.Trim() != txtAllocation.Text.Trim())
                {
                    DGinvms.Rows.Clear();
                }
              
            }
        }
        private void mKeypress()
        {
            if (intvtype == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER || intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER)
            {
                if (txtDrcr.Text == "Dr")
                {
                    txtDebitAmount.Enabled = true;
                    txtCreditAmount.Enabled = false;
                    txtDebitAmount.Text = Math.Abs(Utility.Val(txtNetCredit.Text) - Utility.Val(txtNetDebit.Text)).ToString();
                    txtCreditAmount.Text = "0";
                }
                if (txtDrcr.Text == "Cr")
                {
                    txtDebitAmount.Enabled = false;
                    txtCreditAmount.Enabled = true;
                    txtDebitAmount.Text = "0";
                    txtCreditAmount.Text = (Utility.Val(txtNetDebit.Text) - Utility.Val(txtNetCredit.Text)).ToString();
                }
            }
            if (intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER || intvtype == (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER)
            {
                if (txtDrcr.Text == "Cr")
                {
                    txtDebitAmount.Enabled = false;
                    txtCreditAmount.Enabled = true;
                    txtDebitAmount.Text = "0";
                    txtCreditAmount.Text = Math.Abs(Utility.Val(txtNetDebit.Text) - Utility.Val(txtNetCredit.Text)).ToString();
                }
                if (txtDrcr.Text == "Dr")
                {
                    txtDebitAmount.Enabled = true;
                    txtCreditAmount.Enabled = false;
                    //txtDebitAmount.Text = "0";
                    txtCreditAmount.Text = "0";
                    txtDebitAmount.Text = Math.Abs(Utility.Val(txtNetCredit.Text) - Utility.Val(txtNetDebit.Text)).ToString();
                }
            }
        }
        private void txtDrcr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                mKeypress();
                txtParticulars.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                txtDrcr.SelectionLength = 0;
                //Utility.PriorSetFocusText(txtDrcr, txtBranchName);
                txtBranchName.Focus();

            }
        }

        #endregion
        #region "Accounts Voucher"
        private void mLoadAccountsVoucher(int mintGrouptype, string mstrdrcr)
        {
            int intStatus = 0, intbkash = 0;
            string strBranchID;
            if (chkIncludeX.Checked == true)
            {
                intStatus = 1;
            }
            else
            {
                intStatus = 0;
            }
            if (cboGeneral.Text == "With Bkash Account")
            {
                intbkash = 1;
            }
            else
            {
                intbkash = 0;
            }
            if (txtBranchName.Text != "")
            {
                strBranchID = lstBranchName.SelectedValue.ToString();
            }
            else
            {
                strBranchID = "";
            }
            if (intvtype == 4 || intvtype == 2)
            {
                lstPrticulars.ValueMember = "strLedgerName";
                lstPrticulars.DisplayMember = "strmerzeString";
                lstPrticulars.DataSource = accms.mFillLedger(strComID, intvtype, "", txtDrcr.Text, Utility.gstrUserName).ToList();
            }
            else if (intvtype == 3)
            {
                lstPrticulars.ValueMember = "strLedgerName";
                lstPrticulars.DisplayMember = "strmerzeString";
                lstPrticulars.DataSource = objwois.mFillJVLedger(strComID, intvtype, "", txtDrcr.Text, intStatus, intbkash, Utility.gstrUserName, strBranchID).ToList();
            }
            else
            {
                lstPrticulars.ValueMember = "strLedgerName";
                lstPrticulars.DisplayMember = "strmerzeString";
                lstPrticulars.DataSource = objwois.mFillLedger(strComID, intvtype, "", txtDrcr.Text, intStatus, intbkash, Utility.gstrUserName, strBranchID).ToList();
            }


        }
        #endregion
        #region "Getconfig"
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, intvtype).ToList();
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
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
           
            if (intvtype == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER)
            {
                //uctxtVoucherNo.Text = Interaction.GetSetting(Application.ExecutablePath, "frmPaymentVoucher", "VoucherNoPV");
                uctxtVoucherNo.AppendText ((String)rk.GetValue("VoucherNoPV", ""));
                rk.Close();
            }
            else
            {
                //uctxtVoucherNo.Text = Interaction.GetSetting(Application.ExecutablePath, "frmPaymentVoucher", "VoucherNoJV");
                uctxtVoucherNo.AppendText ((String)rk.GetValue("VoucherNoJV", ""));
                rk.Close();
            }

        }
        #endregion
        #region "Load"
        private void defaultvalue()
        {
            if (intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER)
            {
                SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"General", 1},
              {"With Bkash Account", 2}
            };

                cboGeneral.DisplayMember = "Key";
                cboGeneral.ValueMember = "Value";
                cboGeneral.DataSource = new BindingSource(userCache, null);
            }
            else
            {
                SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"General", 1},
              {"HL-Transfer", 3},
              {"HL-Fine", 4},
              {"Others Charge", 5}
            };

                cboGeneral.DisplayMember = "Key";
                cboGeneral.ValueMember = "Value";
                cboGeneral.DataSource = new BindingSource(userCache, null);
            }
        }
   

        private void frmAccountsVoucher_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
            DGTemplate.AllowUserToAddRows = false;
            DGJVTemplate.AllowUserToAddRows = false;
            lstTemplate.Visible = false;
          
            lstInstallment.Visible = false;
            mskChequeDate.Text = DateAndTime.Now.ToString("dd-MM-yyyy");
            dteVoucherDate.Text = DateAndTime.Now.ToString("dd-MM-yyyy");
            uctxtJvRvDate.Text = DateAndTime.Now.ToString("dd-MM-yyyy");
            mGetConfig();
            mClear();
         
            if (Utility.gblnBranch == true)
            {
                txtBranchName.Enabled = true;
                txtBranchName.BackColor = Color.White;
            }
            else
            {
                txtBranchName.Enabled = false;
                txtBranchName.Text = Utility.gstrBranchName;

            }

            if (Utility.glngIsMaintainBatch == 0)
            {
                uctxtBatchNo.BackColor = Color.White;
                uctxtBatchNo.Enabled = true;
            }
            else
            {
                uctxtBatchNo.Enabled = false;
            }


            if (mblnNumbMethod)
            {
                uctxtVoucherNo.ReadOnly = true;
                if ((intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) || (intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER))
                {
                    cboGeneral.Focus();
                    cboGeneral.Select();
                }
                else
                {
                    dteVoucherDate.Focus();
                    dteVoucherDate.Select();
                }
            }
            else
            {
                if ((intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) || (intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER))
                {
                    cboGeneral.Focus();
                    cboGeneral.Select();
                }
                else
                {
                    uctxtVoucherNo.Focus();
                    uctxtVoucherNo.Select();
                }
            }
            //uctxtVoucherNo.Focus();
            //uctxtVoucherNo.Select();
            lstBranchName.Visible = false;
            lstCostCategory.Visible = false;
            lstBatchNo.Visible = false;
            lstTypeofRef.Visible = false;
            lstBillRefNo.Visible = false;
            dgCopyBillGrid.AllowUserToAddRows = false;
            dgCopyGrid.AllowUserToAddRows = false;
            if (intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER || intvtype == (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER)
            {
                txtDrcr.Text = "Cr";
            }
            else
            {
                txtDrcr.Text = "Dr";
            }
            if (intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER)
            {
                frmLabel.Text = "Receipt Voucher";
            }
            else if (intvtype == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER)
            {
                frmLabel.Text = "Payment Voucher";
            }
            else if (intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER)
            {
                frmLabel.Text = "Journal Voucher";
            }
            else
            {
                frmLabel.Text = "Contra Voucher";
            }
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstCostCategory.ValueMember = "strVectorcategory";
            lstCostCategory.DisplayMember = "strVectorcategory";
            lstCostCategory.DataSource = accms.mFillVectorCategory(strComID).ToList();
            LoadDefaultValue();
            if ((intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) || (intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER))
            {
                cboGeneral.Visible = true;
                lblSelectionType.Visible = true;
                defaultvalue();
            }
          
            
        }
        #endregion
        #region "Default Value"
        private void LoadDefaultValue()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"Advance", 1},
              {"Agst Ref", 2},
              {"New Ref", 2}
            };

            lstTypeofRef.DisplayMember = "Key";
            lstTypeofRef.ValueMember = "Value";
            lstTypeofRef.DataSource = new BindingSource(userCache, null);



        }
        #endregion
        #region "Display Req List"
        private void DisplayReqList(List<AccountsLedger> tests, object sender, EventArgs e)
        {
            try
            {

                txtParticulars.Text = tests[0].strLedgerName;



            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "Validation"
        private bool ValidateFields()
        {
            double dblClosingQTY = 0, dblCurrentQTY = 0;
            string strBillKey = "", strNegetiveItem = "";
            int intCheckNegetive = 0;
            try
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (dteVoucherDate.Text == "")
                {
                    MessageBox.Show("Date Cannot be Empty");
                    dteVoucherDate.Focus();
                    return false;
                }

                if (Utility.Val(txtNetDebit.Text) != Utility.Val(txtNetCredit.Text))
                {
                    MessageBox.Show("Total Amount mismatch", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if ((intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) || (intvtype==(int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER))
                {
                    if (cboGeneral.Text =="")
                    {
                        MessageBox.Show("Selction Type Cannot be Delete");
                        cboGeneral.Focus();
                        return false ;
                    }
                }

                long lngDate = Convert.ToInt64(Convert.ToDateTime(dteVoucherDate.Text).ToString("yyyyMMdd"));
                long lngFiscalYearfrom = Convert.ToInt64(Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString("yyyyMMdd"));
                long lngFiscalYearTo = Convert.ToInt64(Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString("yyyyMMdd"));

                if (lngDate < lngFiscalYearfrom)
                {
                    MessageBox.Show("Invalid Date, Date Can't less then Financial Year");
                    return false;
                }
                if (lngDate > lngFiscalYearTo)
                {
                    MessageBox.Show("Invalid Date, Date Can't less then Financial Year");
                    return false;
                }

                string strBacklockDate = Utility.gCheckBackLock(strComID);
                if (strBacklockDate != "")
                {
                    long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strBacklockDate).ToString("yyyyMMdd"));
                    if (lngDate <= lngBackdate)
                    {
                        MessageBox.Show("Invalid Date, Back Date is locked");
                        return false;
                    }
                }
                for (int i = 0; i < DGinvms.Rows.Count; i++)
                {
                 
                    if (DGinvms[0, i].Value != "" && DGinvms[0, i].Value != null)
                    {
                        if (DGinvms[7, i].Value != null)
                            strBillKey = DGinvms[7, i].Value.ToString();
                        dblClosingQTY = Utility.gdblClosingStockNew(strComID, DGinvms[1, i].Value.ToString(), uctxtLocation.Text, dteVoucherDate.Text);
                        if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                        {
                            dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                        }
                        dblCurrentQTY = Utility.Val(DGinvms[2, i].Value.ToString());
                        if ((dblClosingQTY) - dblCurrentQTY < 0)
                        {
                            strNegetiveItem = strNegetiveItem + Environment.NewLine + DGinvms[1, i].Value.ToString();
                            intCheckNegetive = 1;
                            dblClosingQTY = 0;
                        }
                        else if (dblClosingQTY == 0)
                        {
                            strNegetiveItem = strNegetiveItem + Environment.NewLine + DGinvms[1, i].Value.ToString();
                            intCheckNegetive = 1;
                            dblClosingQTY = 0;
                        }
                        //if (intCheckNegetive > 0)
                        //{
                        //    MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                        //    dblClosingQTY = 0;
                        //    DG.Focus();
                        //    return false;
                        //}

                    }
                    dblClosingQTY = 0;
                }
                if (intCheckNegetive > 0)
                {
                    MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                    dblClosingQTY = 0;
                    DG.Focus();
                    return false;
                }



                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
                
            }
        }
        
        #endregion
        #region "Save"
        private string mSave()
        {
            string strBranchID = "", strNarration = "", strVdate = "", strDrCr = "", strMonthID = "", strLedgerName = "",
                            strVoyageNo = "", strCostcenter = "", strDGBillWise = "", strRefNumber = "", vstrFineRefNo="", strVoucherGrid = "",strInveffect="",strTemplate="",strTemplateJV="";
            long lngMultiCurrency = 0, intCashFlow = 0;
            string i = "";
            int intRow;
             int intLoanTransfer = 0;
            if (cboGeneral.Text =="General")
            {
                intLoanTransfer = 1;
            }
            else if (cboGeneral.Text == "With Bkash Account")
            {
                intLoanTransfer = 2;
            }
            else if (cboGeneral.Text == "HL-Transfer")
            {
                intLoanTransfer = 3;
            }
            else if (cboGeneral.Text == "HL-Fine")
            {
                intLoanTransfer = 4;
            }
            else if (cboGeneral.Text == "Others Charge")
            {
                intLoanTransfer = 5;
            }

            double dbldebitAmount = 0, dblcreditAmount = 0,dblFine=0;



            strBranchID = Utility.gstrGetBranchID(strComID, txtBranchName.Text);
            strNarration = txtNarration.Text.Replace("'", "''");
            if (Utility.glngIsMaintainBatch == 1)
            {
                strVoyageNo = uctxtBatchNo.Text.Replace("'", "''");
            }
            else
            {
                strVoyageNo = "";
            }

            if (Utility.gblnMultipleCurrency)
            {
                mdblCurrRate = Utility.gdblCurrRate;
                mstrFCsymbol = Utility.gstrFCsymbol;
            }
            else
            {
                mdblCurrRate = 0;
            }

            if (mdblCurrRate != 0)
            {
                lngMultiCurrency = 1;
            }
            else
            {
                lngMultiCurrency = 0;
            }
            strVdate = dteVoucherDate.Text.ToString();
            strLedgerName = DG[3, 0].Value.ToString();
            strMonthID = Convert.ToDateTime(dteVoucherDate.Text).ToString("MMMyy").ToUpper();
            for (intRow = 0; intRow < dgCopyGrid.Rows.Count; intRow++)
            {

                if (dgCopyGrid[0, intRow].Value != null)
                {
                    strCostcenter += dgCopyGrid[0, intRow].Value.ToString() + "|" + dgCopyGrid[3, intRow].Value.ToString() +
                                            "|" + dgCopyGrid[2, intRow].Value.ToString() + "|" + dgCopyGrid[3, intRow].Value.ToString() + "|" + dgCopyGrid[4, intRow].Value.ToString() + "~";
                }
            }
            for (intRow = 0; intRow < dgCopyBillGrid.Rows.Count; intRow++)
            {
                if (dgCopyBillGrid[0, intRow].Value != null)
                {

                    strDGBillWise = strDGBillWise + Utility.gCheckNull(dgCopyBillGrid[0, intRow].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(dgCopyBillGrid[3, intRow].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(dgCopyBillGrid[2, intRow].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(dgCopyBillGrid[3, intRow].Value.ToString()) + "|" +
                                                                Utility.Val(dgCopyBillGrid[4, intRow].Value.ToString()) + "|" +
                                                                 Utility.gCheckNull(dgCopyBillGrid[5, intRow].Value.ToString()) + "~";
                }

            }
            for (intRow = 0; intRow < DGinvms.Rows.Count; intRow++)
            {
                if (DGinvms[0, intRow].Value != null)
                {

                    strInveffect = strInveffect + Utility.gCheckNull(DGinvms[0, intRow].Value.ToString()) + "|" + //location
                                                                Utility.gCheckNull(DGinvms[1, intRow].Value.ToString()) + "|" + //item
                                                                Utility.gCheckNull(DGinvms[2, intRow].Value.ToString()) + "|" + //qty
                                                                Utility.gCheckNull(DGinvms[3, intRow].Value.ToString()) + "|" + //unit
                                                                Utility.Val(DGinvms[4, intRow].Value.ToString()) + "|" + //rate
                                                                Utility.Val(DGinvms[5, intRow].Value.ToString()) + "~"; //amount
                }

            }
            for (intRow = 0; intRow < DGTemplate.Rows.Count; intRow++)
            {
                if (DGTemplate[0, intRow].Value != null)
                {

                    strTemplate = strTemplate + strLedgerName + "|" + //Ledger
                                                                txtTemplateName.Text + "|" + //Template
                                                                Utility.gCheckNull(DGTemplate[0, intRow].Value.ToString()) + "|" +//installment
                                                                 Utility.gCheckNull(DGTemplate[1, intRow].Value.ToString()) + "|" + //date 
                                                                Utility.Val(DGTemplate[2, intRow].Value.ToString()) + "~"; //amount
                                                                
                }

            }
            for (intRow = 0; intRow < DGJVTemplate.Rows.Count; intRow++)
            {
                if (DGJVTemplate[0, intRow].Value != null)
                {
                    if (DGJVTemplate[4, intRow].Value.ToString() !="")
                    {
                        dblFine = dblFine + Convert.ToDouble(DGJVTemplate[4, intRow].Value.ToString());
                    }
                    else
                    {
                        dblFine = 0;
                    }
                    strTemplateJV = strTemplateJV + uctxtAllocationJV.Text + "|" + //Ledger
                                                                uctxtJVTemplate.Text + "|" + //Template
                                                                Utility.gCheckNull(DGJVTemplate[0, intRow].Value.ToString()) + "|" +//installment
                                                                Utility.gCheckNull(DGJVTemplate[1, intRow].Value.ToString()) + "|" + //Rdate 
                                                                Utility.gCheckNull(DGJVTemplate[2, intRow].Value.ToString()) + "|" + //Ddate 
                                                                Utility.Val(DGJVTemplate[3, intRow].Value.ToString()) + "|" + //amount
                                                                Utility.Val(DGJVTemplate[4, intRow].Value.ToString()) + "~"; //Fine

                }

            }
            if (mblnNumbMethod == false)
            {
                strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intvtype) + strBranchID + uctxtVoucherNo.Text;
            }
            else
            {
                strRefNumber = gobjVoucherName.VoucherName.GetVoucherString(intvtype) + strBranchID + Utility.gstrLastNumber(strComID,intvtype);
            }

            strVoucherGrid = PopulatedGrid(strRefNumber);
            i = accms.SaveVoucher(strComID, strVoucherGrid, strDrCr, strRefNumber, intvtype, strVdate, strMonthID, strVdate, strLedgerName, "", 1, intCashFlow,
                                                    strVoyageNo, Convert.ToDouble(txtNetDebit.Text), Convert.ToDouble(txtNetDebit.Text), 0, 0,
                                                    dbldebitAmount, dblcreditAmount, 0, 0, "", 0, 0, "", strNarration,
                                                    strBranchID, strCostcenter, strDGBillWise, mblnNumbMethod, lngMultiCurrency, "", "", "", "", "", "", "", "", "", "", 0, 
                                                    strInveffect, strTemplate, strTemplateJV,intLoanTransfer);

            if (1==1)
            {
                if (dblFine > 0)
                   
                {
                     vstrFineRefNo = gobjVoucherName.VoucherName.GetVoucherString(intvtype) + strBranchID + Utility.gstrLastNumber(strComID,intvtype);
                     string strLate = Utility.gInsertLateFine(strComID, vstrFineRefNo, DG.Rows[1].Cells[3].Value.ToString(), "HL-Late Payment Fine", strBranchID, intvtype, strMonthID, strVdate,
                                                                    dblFine, "Late Installment Fine", strRefNumber, 1, intLoanTransfer);
                }
            }

          
            return i;


        }
      


        #endregion
        #region "Populate Grid"
        private string PopulatedGrid(string vstrRefNumber)
        {
            string strBranchID = "", strNarration = "", strDrCr = "", strLedgerName = "", strChecuqueNo = "",
                               strCheckDate = "", strDrwanon = "", strSingleNarration = "", strReverseLedger = "",
                                  strVoucherGrid = "", strReverseLedger1="";
            long lngLedgergroup = 0, intCashFlow = 0;
            int intLedgerCount = 0,intTotalCashFlow=0,intCountCashFlow=0,intPosition=0;
            //string i = "";
            //int intRow;
            double dbldebitAmount = 0, dblcreditAmount = 0;



            strBranchID = Utility.gstrGetBranchID(strComID, txtBranchName.Text);
            for (int intvrow = 0; intvrow < DG.Rows.Count; intvrow++)
            {
                if (DG.Rows[intvrow].Cells[3].Value != null)
                {
                    intLedgerCount += 1;
                    lngLedgergroup = (long)(Utility.gGetLedgergroup(strComID, DG.Rows[intvrow].Cells[3].Value.ToString()));
                    if (lngLedgergroup <= 101)
                    {
                        intTotalCashFlow += 1;
                    }
                }
            }
            for (int intvrow = 0; intvrow < DG.Rows.Count; intvrow++)
            {
                if (intLedgerCount > 2)
                {
                    strReverseLedger = "As Per Details";
                    if (intvrow == 0)
                    {
                        strReverseLedger1 = DG.Rows[1].Cells[3].Value.ToString();
                    }
                    else if (intvrow == 1)
                    {
                        strReverseLedger1 = DG.Rows[0].Cells[3].Value.ToString();
                    }
                    else if (intvrow == 2)
                    {
                        strReverseLedger1 = DG.Rows[2].Cells[3].Value.ToString();
                    }
                }
                else if (intvrow == 0)
                {
                    strReverseLedger = DG.Rows[1].Cells[3].Value.ToString();
                }
                else if (intvrow == 1)
                {
                    strReverseLedger = DG.Rows[0].Cells[3].Value.ToString();
                }
                if (DG.Rows[intvrow].Cells[3].Value != null)
                {
                    lngLedgergroup = (long)(Utility.gGetLedgergroup(strComID, DG.Rows[intvrow].Cells[3].Value.ToString()));

                    if (lngLedgergroup > 101)
                    {
                        if (intTotalCashFlow != intCountCashFlow)
                        {
                            intCashFlow = 1;
                            intCountCashFlow += 1;
                        }
                    }
                    else
                    {
                        intCashFlow = 0;
                    }


                    strDrCr = DG[0, intvrow].Value.ToString();
                    strLedgerName = DG[3, intvrow].Value.ToString();
                    if (lngLedgergroup == 100)
                    {
                        strChecuqueNo = DG[5, intvrow].Value == null ? "" : DG[5, intvrow].Value.ToString();
                        strCheckDate = DG[6, intvrow].Value == null ? "" : DG[6, intvrow].Value.ToString();
                        strDrwanon = DG[7, intvrow].Value == null ? "" : DG[7, intvrow].Value.ToString();
                        if (strCheckDate =="  -  -")
                        {
                            strCheckDate = "";
                        }
                      
                    }
                    else
                    {
                        strChecuqueNo = "";
                        strCheckDate = "";
                        strDrwanon = "";
                    }
                    strSingleNarration = DG[8, intvrow].Value == null ? "" : DG[8, intvrow].Value.ToString();
                    dbldebitAmount = Convert.ToDouble(DG[9, intvrow].Value.ToString());
                    dblcreditAmount = Convert.ToDouble(DG[10, intvrow].Value.ToString());

                    strVoucherGrid = strVoucherGrid + strDrCr + "|" + strLedgerName + "|" + strReverseLedger + "|" + intCashFlow + "|"
                                                    + "|" + dbldebitAmount + "|" + dblcreditAmount + "|" + strSingleNarration + "|" + strNarration + "|" +
                                                             strChecuqueNo + "|" + strCheckDate + "|" + strDrwanon + "|" + strReverseLedger1 + "~";

                    if (strChecuqueNo !="")
                    {
                        RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
                        rk.SetValue("CHEQUENO" + intvtype, strChecuqueNo);
                        rk.Close();
                    }
                   
                }

            }
            return strVoucherGrid;
        }
        #endregion
        #region "Update"
        private string mUpdate()
        {
            string strBranchID = "", strNarration = "", strVdate = "", strMonthID = "", strLedgerName = "",
                             strReverseLedger = "",strVoucherGrid="",
                             strVoyageNo = "", strCostcenter = "", strDGBillWise = "",vstrFineRefNo="", strInveffect = "", strTemplate = "", strTemplateJV="";
            long lngMultiCurrency = 0,  intCashFlow = 0;
            
            string i = "";
            int intRow;
            double dbldebitAmount = 0, dblcreditAmount = 0, dblFine=0;
            int intLoanTransfer = 0;
            //if (chkLoanTransfer.Checked)
            //{
            //    intLoanTransfer = 1;
            //}
            if (cboGeneral.Text == "General")
            {
                intLoanTransfer = 1;
            }
            else if (cboGeneral.Text == "With Bkash Account")
            {
                intLoanTransfer = 2;
            }
            else if (cboGeneral.Text == "HL-Transfer")
            {
                intLoanTransfer = 3;
            }
            else if (cboGeneral.Text == "HL-Fine")
            {
                intLoanTransfer = 4;
            }
            else if (cboGeneral.Text == "Others Charge")
            {
                intLoanTransfer = 5;
            }
            
            strBranchID = Utility.gstrGetBranchID(strComID, txtBranchName.Text);
            strNarration = txtNarration.Text.Replace("'", "''");
            if (Utility.glngIsMaintainBatch == 1)
            {
                strVoyageNo = uctxtBatchNo.Text.Replace("'", "''");
            }
            else
            {
                strVoyageNo = "";
            }

            if (Utility.gblnMultipleCurrency)
            {
                mdblCurrRate = Utility.gdblCurrRate;
                mstrFCsymbol = Utility.gstrFCsymbol;
            }
            else
            {
                mdblCurrRate = 0;
            }

            if (mdblCurrRate != 0)
            {
                lngMultiCurrency = 1;
            }
            else
            {
                lngMultiCurrency = 0;
            }
            strVdate = dteVoucherDate.Text.ToString();
            strLedgerName = DG[3, 0].Value.ToString();

            for (int intvrow = 0; intvrow < DG.Rows.Count; intvrow++)
            {
                if (intvtype==(int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER  || intvtype==(int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER )
                {
                    if  (DG[0, intvrow].Value.ToString().ToUpper()=="DR")
                    {
                        strLedgerName = DG[3, intvrow].Value.ToString();
                        break;
                    }
                }
                else
                {
                    if (DG[0, intvrow].Value.ToString().ToUpper() == "CR")
                    {
                        strLedgerName = DG[3, intvrow].Value.ToString();
                        break;
                    }
                }
            }

            strMonthID = Convert.ToDateTime(dteVoucherDate.Text).ToString("MMMyy").ToUpper();
            for (intRow = 0; intRow < dgCopyGrid.Rows.Count; intRow++)
            {

                if (dgCopyGrid[0, intRow].Value != null)
                {
                    strCostcenter += dgCopyGrid[0, intRow].Value.ToString() + "|" + dgCopyGrid[3, intRow].Value.ToString() +
                                            "|" + dgCopyGrid[2, intRow].Value.ToString() + "|" + dgCopyGrid[3, intRow].Value.ToString() + "|" +
                                            dgCopyGrid[4, intRow].Value.ToString() + "~";

                }
            }
            for (intRow = 0; intRow < dgCopyBillGrid.Rows.Count; intRow++)
            {
                if (dgCopyBillGrid[0, intRow].Value != null)
                {

                    strDGBillWise = strDGBillWise + Utility.gCheckNull(dgCopyBillGrid[0, intRow].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(dgCopyBillGrid[3, intRow].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(dgCopyBillGrid[2, intRow].Value.ToString()) + "|" +
                                                                Utility.gCheckNull(dgCopyBillGrid[3, intRow].Value.ToString()) + "|" +
                                                                Utility.Val(dgCopyBillGrid[4, intRow].Value.ToString()) + "|" +
                                                                 Utility.gCheckNull(dgCopyBillGrid[5, intRow].Value.ToString()) + "~";
                }

            }
            for (intRow = 0; intRow < DGinvms.Rows.Count; intRow++)
            {
                if (DGinvms[0, intRow].Value != null)
                {

                    strInveffect = strInveffect + Utility.gCheckNull(DGinvms[0, intRow].Value.ToString()) + "|" + //location
                                                                Utility.gCheckNull(DGinvms[1, intRow].Value.ToString()) + "|" + //item
                                                                Utility.gCheckNull(DGinvms[2, intRow].Value.ToString()) + "|" + //qty
                                                                Utility.gCheckNull(DGinvms[3, intRow].Value.ToString()) + "|" + //unit
                                                                Utility.Val(DGinvms[4, intRow].Value.ToString()) + "|" + //rate
                                                                Utility.Val(DGinvms[5, intRow].Value.ToString()) + "~"; //amount
                }

            }
            for (intRow = 0; intRow < DGTemplate.Rows.Count; intRow++)
            {
                if (DGTemplate[0, intRow].Value != null)
                {

                    strTemplate = strTemplate + strLedgerName + "|" + //Ledger
                                                                txtTemplateName.Text + "|" + //Template
                                                                Utility.gCheckNull(DGTemplate[0, intRow].Value.ToString()) + "|" +//installment
                                                                 Utility.gCheckNull(DGTemplate[1, intRow].Value.ToString()) + "|" + //date 
                                                                Utility.Val(DGTemplate[2, intRow].Value.ToString()) + "~"; //amount

                }

            }
            for (intRow = 0; intRow < DGJVTemplate.Rows.Count; intRow++)
            {
                if (DGJVTemplate[0, intRow].Value != null)
                {
                    if (DGJVTemplate[4, intRow].Value.ToString() != "")
                    {
                        dblFine = dblFine + Convert.ToDouble(DGJVTemplate[4, intRow].Value.ToString());
                    }
                    else
                    {
                        dblFine = 0;
                    }

                    strTemplateJV = strTemplateJV + uctxtAllocationJV.Text + "|" + //Ledger
                                                                uctxtJVTemplate.Text + "|" + //Template
                                                                Utility.gCheckNull(DGJVTemplate[0, intRow].Value.ToString()) + "|" +//installment
                                                                Utility.gCheckNull(DGJVTemplate[1, intRow].Value.ToString()) + "|" + //Rdate 
                                                                Utility.gCheckNull(DGJVTemplate[2, intRow].Value.ToString()) + "|" + //Ddate 
                                                                Utility.Val(DGJVTemplate[3, intRow].Value.ToString()) + "|" + //amount
                                                                Utility.Val(DGJVTemplate[4, intRow].Value.ToString()) + "~"; //Fine

                }

            }

            strVoucherGrid = PopulatedGrid(uctxtOldNo.Text);
            i = accms.UpdateVoucher(strComID, strVoucherGrid, "", uctxtOldNo.Text, intvtype, strVdate, strMonthID, strVdate, strLedgerName, strReverseLedger, 1, intCashFlow,
                                                    strVoyageNo, 0, Convert.ToDouble(txtNetDebit.Text), 0, 0, dbldebitAmount, dblcreditAmount, 0, 0, "", 0, 0, "", strNarration,
                                                    strBranchID, strCostcenter, strDGBillWise, lngMultiCurrency, "", "", "", "", "", "", "", "", "", "", strInveffect, strTemplate, strTemplateJV,intLoanTransfer);

            if (1 == 1)
            {
                if (dblFine > 0)
                {
                    //vstrFineRefNo = gobjVoucherName.VoucherName.GetVoucherString(intvtype) + strBranchID + Utility.gstrLastNumber(strComID, intvtype);
                    string strLate = Utility.gInsertLateFine(strComID, uctxtOldNo.Text.Trim(), DG.Rows[1].Cells[3].Value.ToString(), "HL-Late Payment Fine", strBranchID, intvtype, strMonthID, strVdate,
                                                                   dblFine, "Late Installment Fine", uctxtOldNo.Text.Trim(), 2, intLoanTransfer);
                }
            }

          
            return i;
        }


        #endregion
        #region "Button Save"
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (ValidateFields() == false)
            {
                return;
            }
            //Interaction.SaveSetting(Application.ExecutablePath, intvtype.ToString(), "Narration", txtNarration.Text);
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
            rk.SetValue("Narration" + intvtype, txtNarration.Text);
            rk.Close();
           

            try
            {
                if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
                {
                    var strResponse = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponse == DialogResult.Yes)
                    {
                        string response = mSave();
                        if (response == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteVoucherDate.Text, strFormName, uctxtVoucherNo.Text,
                                                                        1, Utility.Val(txtNetDebit.Text), (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                            }
                          
                            mClear();
                            if ((intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) || (intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER))
                            {
                                txtParticulars.Focus();
                                txtParticulars.Select();
                            }
                            else
                            {
                                txtBranchName.Focus();
                                txtBranchName.Select();
                            }
                           
                        }
                        else
                        {
                            MessageBox.Show(response);
                        }
                    }
                    else
                    {
                        txtNarration.Focus();
                    }
                }
                else
                {
                    var strResponse = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponse == DialogResult.Yes)
                    {
                        string response = mUpdate();
                        if (response == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, dteVoucherDate.Text, strFormName, uctxtVoucherNo.Text,
                                                                        2, Utility.Val(txtNetDebit.Text), (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                            }
                            mClear();
                            //txtBranchName.Focus();
                            frmAccountsVoucherList objfrm = new frmAccountsVoucherList();
                            objfrm.mintVType = intvtype;
                            objfrm.onAddAllButtonClicked = new frmAccountsVoucherList.AddAllClick(DisplayVoucherList);
                            objfrm.lngFormPriv = lngFormPriv;
                            objfrm.strFormName = strFormName;
                            objfrm.intModuleType = (int)Utility.MODULE_TYPE.mtACCOUNT;
                            objfrm.strPreserveSQl = mstrPrserveSql;
                            objfrm.Show();
                            objfrm.MdiParent = this.MdiParent;
                        }
                        else
                        {
                            MessageBox.Show(response);
                        }
                    }
                    else
                    {
                        txtNarration.Focus();
                    }

                }


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            txtSingleNarration.Text = "";
            txtLedgerName.Text = "";
            txtDebitAmount.Text = "0";
            lblCurrentBalance.Text = "";
            lblBalance.Text = "";
            txtDebitAmount.Enabled = false;
            txtCreditAmount.Enabled = false;
            grpBankInformation.Visible = false;
            pnlCostCenter.Visible = false;
            PanelInventory.Visible = false;
            DGinvms.Rows.Clear();
            txtCreditAmount.Text = "0";
            if (intvtype == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER || intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER)
            {
                txtDrcr.Text = "Dr";
                //txtBranchName.Focus();
                //txtBranchName.Select();
            }
            else if (intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER || intvtype == (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER)
            {
                txtDrcr.Text = "Cr";
                //txtBranchName.Focus();
                //txtBranchName.Select();
            }
            if ((intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) || (intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER))
            {
                cboGeneral.Focus();
                cboGeneral.Select();
            }
            else
            {
                dteVoucherDate.Select();
                dteVoucherDate.Focus();
            }
               

            //chkLoanTransfer.Checked = false;
            //cboGeneral.Text = "";
            panelRvSchedule.Visible = false;
            pnlTemplate.Visible = false;
            DGTemplate.Rows.Clear();
            DGJVTemplate.Rows.Clear();
            //txtDrcr.Text = "Dr";
            txtFine.Text = "";
            txtJvFine.Text = "";
            //if (intvtype != (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER)
            //{
            //    txtChequeNo.Text = "";
            //    mskChequeDate.Text = "";
            //    txtDrawnon.Text = "";
            //}
            //txtBranchName.Text = "";
            dgCopyGrid.Rows.Clear();
            DgCostCenter.Rows.Clear();
            //txtNarration.Text = "";
            uctxtOldNo.Text = "";
            txtNetDebit.Text = "0";
            txtNetCredit.Text = "0";
            DG.Rows.Clear();
            DGTemplate.Rows.Clear();
            DGJVTemplate.Rows.Clear();
            txtTemplateAllocation.Text = "";
            txtTemplateName.Text = "";
            //cboGeneral.Text = "";
            //chkBkashCharge.Checked = false;
            if (Utility.gblnBranch == true)
            {
                txtBranchName.Enabled = true;
                txtBranchName.BackColor = Color.White;
            }
            else
            {
                txtBranchName.Enabled = false;
                txtBranchName.Text = Utility.gstrBranchName;

            }
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            if (mblnNumbMethod)
            {
                uctxtVoucherNo.Text = Utility.gstrLastNumber(strComID, intvtype);
            }
            else
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                if (intvtype == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER)
                {
                    //uctxtVoucherNo.Text = Interaction.GetSetting(Application.ExecutablePath, "frmPaymentVoucher", "VoucherNoPV");

                    uctxtVoucherNo.AppendText((String)rk.GetValue("VoucherNoPV", ""));
                    rk.Close();
                }
                else
                {
                    //uctxtVoucherNo.Text = Interaction.GetSetting(Application.ExecutablePath, "frmPaymentVoucher", "VoucherNoJV");
                    uctxtVoucherNo.AppendText ((String)rk.GetValue("VoucherNoJV", ""));
                    rk.Close();
                }
                uctxtVoucherNo.Text = Utility.gobjNextNumber(uctxtVoucherNo.Text);
            }


        }
        #endregion
        #region "Additem"
        private void addItem(string strDrCr
                               , string strLegderName
                               , string strTeritorryCode
                               , string strTeritorryName
                               , string strSinleNarration
                               , string strChechueNo
                               , string strchequedate
                               , string strDrawnOn
                               , double dblDrAmount
                               , double dblCrAmount
                               , string strCostCategory
                               , string strCostCenter
                               , double dblCostCenterAmount)
        {
            int selraw = 0;
            if (strLegderName != "" && dblDrAmount > 0)
            {

                mdblDebit = mdblDebit + dblDrAmount;
                mdblCredit = mdblCredit + dblCrAmount;

                DG.AllowUserToAddRows = true;
                selraw = Convert.ToInt16(DG.RowCount.ToString());
                selraw = selraw - 1;
                DG.Rows.Add(1);
                lblCurrentBalance.Text = "";
                if (strDrCr.ToUpper() == "DR")
                {
                    DG[0, selraw].Value = "Dr";
                    DG[1, selraw].Value = strLegderName;
                    DG[2, selraw].Value = Utility.gstrLedgerBalance(strComID, strTeritorryCode);
                    DG[3, selraw].Value = strTeritorryCode;
                    DG[4, selraw].Value = strTeritorryName;
                    DG[5, selraw].Value = strChechueNo;
                    DG[6, selraw].Value = strchequedate;
                    DG[7, selraw].Value = strDrawnOn;
                    DG[8, selraw].Value = strSinleNarration;
                    DG[9, selraw].Value = dblDrAmount;
                    DG[10, selraw].Value = 0;
                    DG[11, selraw].Value = "Delete";
                    DG[11, selraw].Style.BackColor = Color.Aqua;
                    //mdblDebit = mdblDebit + dblDrAmount;
                }
            }
            if (strLegderName != "" && dblCrAmount > 0)
            {
                mdblDebit = mdblDebit + dblDrAmount;
                mdblCredit = mdblCredit + dblCrAmount;

                DG.AllowUserToAddRows = true;
                selraw = Convert.ToInt16(DG.RowCount.ToString());
                selraw = selraw - 1;
                DG.Rows.Add(1);
                DG[0, selraw].Value = "Cr";
                DG[1, selraw].Value = strLegderName;
                DG[2, selraw].Value = Utility.gstrLedgerBalance(strComID, strTeritorryCode);
                DG[3, selraw].Value = strTeritorryCode;
                DG[4, selraw].Value = strTeritorryName;
                DG[5, selraw].Value = strChechueNo;
                DG[6, selraw].Value = strchequedate;
                DG[6, selraw].Value = strDrawnOn;
                DG[8, selraw].Value = strSinleNarration;
                DG[9, selraw].Value = 0;
                DG[10, selraw].Value = dblCrAmount;
                DG[11, selraw].Value = "Delete";
                DG[11, selraw].Style.BackColor = Color.Aqua;
                //mdblCredit = mdblCredit + dblCrAmount;
            }

            if (Utility.gbcheckCostCenter(strComID, txtParticulars.Text) == true)
            {
                pnlCostCenter.Visible = true;
                uctxtCostCategory.Focus();
                uctxtCostCategory.Select();
                pnlCostCenter.Top = txtSingleNarration.Top + 60;
                pnlCostCenter.Left = txtSingleNarration.Left;
                pnlCostCenter.Size = new Size(737, 212);
                DgCostCenter.Size = new Size(710, 102);
                btnApply.Top = DgCostCenter.Height + 87;
                btnCancel.Top = DgCostCenter.Height + 87;
                uctxtAmount.Text = (dblDrAmount + dblCrAmount).ToString();
                txtpreAmount.Text = (dblDrAmount + dblCrAmount).ToString();
                txtLedgerName.Text = strLegderName;
                txtdrcr1.Text = txtDrcr.Text;
                DgCostCenter.Rows.Clear();
                for (int i = 0; i < dgCopyGrid.Rows.Count; i++)
                {
                    if (dgCopyGrid[0, i].Value != null)
                    {
                        if (dgCopyGrid[0, i].Value.ToString() == strLegderName)
                        {
                            DgCostCenter.AllowUserToAddRows = true;
                            selraw = Convert.ToInt16(DgCostCenter.RowCount.ToString());
                            selraw = selraw - 1;
                            DgCostCenter.Rows.Add(1);
                            DgCostCenter.Rows[selraw].Cells[0].Value = dgCopyGrid[1, i].Value;
                            DgCostCenter.Rows[selraw].Cells[1].Value = dgCopyGrid[2, i].Value;
                            DgCostCenter.Rows[selraw].Cells[2].Value = dgCopyGrid[3, i].Value;
                            DgCostCenter.Rows[selraw].Cells[4].Value = txtdrcr1.Text;
                            DgCostCenter.AllowUserToAddRows = false;
                        }
                    }
                }
                if (Utility.gbcheckBankLedger(strComID, txtParticulars.Text) == true)
                {
                    grpBankInformation.Visible = true;
                    introw.Text = selraw.ToString();
                    grpBankInformation.Top = txtSingleNarration.Top + 60;
                    grpBankInformation.Left = txtSingleNarration.Left;
                    grpBankInformation.Size = new Size(348, 186);

                }
                else
                {
                    introw.Text = "";
                }

            }
            else if ((Utility.gbcheckBankLedger(strComID, txtParticulars.Text) == true))
            {
                grpBankInformation.Visible = true;
                introw.Text = selraw.ToString();
                grpBankInformation.Top = txtSingleNarration.Top + 60;
                grpBankInformation.Left = txtSingleNarration.Left;
                grpBankInformation.Size = new Size(348, 186);
                txtChequeNo.Focus();
                return;
            }
            else
            {
                introw.Text = "";
                txtDrcr.Focus();
            }

            //if (Utility.mblnBillWise(strComID, txtParticulars.Text) == true)
            //{
            //    pnlBillWise.Visible = true;
            //    pnlBillWise.Top = txtSingleNarration.Top + 60;
            //    pnlBillWise.Left = txtSingleNarration.Left;
            //    pnlBillWise.Size = new Size(711, 301);
            //    txtBillLedger.Text = strLegderName;
            //    if (intvtype == 2)
            //    {
            //        txtBillDrcr.Text = "Dr";
            //    }
            //    else
            //    {
            //        txtBillDrcr.Text = "Cr";
            //    }
            //    txtBillPreTotal.Text = (dblDrAmount + dblCrAmount).ToString();
            //    txtBillAmount.Text = (dblDrAmount + dblCrAmount).ToString();
            //    txtComm.Text = "0";
            //    txtInte.Text = "0";
            //    lblBillWise.Text = "Bill Wise Details for " + txtParticulars.Text;
            //    //DgCostCenter.Size = new Size(687, 173);
            //    dgBillBranch.Rows.Clear();
            //    for (int i = 0; i < dgCopyBillGrid.Rows.Count; i++)
            //    {

            //        if (dgCopyBillGrid[0, i].Value != null)
            //        {
            //            if (dgCopyBillGrid[0, i].Value.ToString() == strLegderName)
            //            {
            //                dgBillBranch.AllowUserToAddRows = true;
            //                selraw = Convert.ToInt16(dgBillBranch.RowCount.ToString());
            //                selraw = selraw - 1;
            //                dgBillBranch.Rows.Add(1);
            //                dgBillBranch.Rows[selraw].Cells[0].Value = dgCopyBillGrid[1, i].Value;
            //                dgBillBranch.Rows[selraw].Cells[1].Value = dgCopyBillGrid[2, i].Value;
            //                dgBillBranch.Rows[selraw].Cells[2].Value = dgCopyBillGrid[3, i].Value;
            //                dgBillBranch.Rows[selraw].Cells[3].Value = dgCopyBillGrid[4, i].Value;
            //                dgBillBranch.Rows[selraw].Cells[4].Value = dgCopyBillGrid[5, i].Value;
            //                dgBillBranch.Rows[selraw].Cells[5].Value = dgCopyBillGrid[6, i].Value;

            //                dgBillBranch.AllowUserToAddRows = false;
            //            }
            //        }
            //    }
            //    uctxtTypeofRef.Focus();
            //}
         

            DG.AllowUserToAddRows = false;
        }
        #endregion
        #region "button Down"
        private void btnDown_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region "button Apply"
        private void btnApply_Click(object sender, EventArgs e)
        {
            //string strCostcenter = "";
            if (Utility.Val(txtTotal.Text) > 0)
            {
                if (DgCostCenter[0, 0].Value != null)
                {
                    if (Utility.Val(txtpreAmount.Text) != Utility.Val(txtTotal.Text))
                    {
                        MessageBox.Show("Amount is mismatch");
                        uctxtAmount.Focus();
                        return;
                    }
                }
            }
            for (int i = 0; i < DgCostCenter.Rows.Count; i++)
            {
                if (DgCostCenter[1, i].Value != null)
                {
                    mDeleteRow(dgCopyGrid, DgCostCenter[1, i].Value.ToString());
                }
            }
            for (int i = 0; i < DgCostCenter.Rows.Count; i++)
            {

                if (DgCostCenter[0, i].Value != null)
                {
                    mAdditemCostCenterTemp(txtLedgerName.Text, DgCostCenter[0, i].Value.ToString(), DgCostCenter[1, i].Value.ToString(), Convert.ToDouble(DgCostCenter[2, i].Value.ToString()), DgCostCenter[4, i].Value.ToString());

                }
            }

            pnlCostCenter.Visible = false;
            if (grpBankInformation.Visible)
            {
                txtChequeNo.Focus();
            }
            else
            {
                txtDrcr.Focus();
            }
        }
        #endregion
        #region "Add Item"
        private void mAdditemCostCenterTemp(string strLedgerName, string strCostCategory, string strCostCenter, double dblnetamount, string strDrcr)
        {
            int selRaw;
            dgCopyGrid.AllowUserToAddRows = true;
            selRaw = Convert.ToInt16(dgCopyGrid.RowCount.ToString());
            selRaw = selRaw - 1;
            dgCopyGrid.Rows.Add();
            dgCopyGrid[0, selRaw].Value = strLedgerName.ToString();
            dgCopyGrid[1, selRaw].Value = strCostCategory.ToString();
            dgCopyGrid[2, selRaw].Value = strCostCenter.ToString();
            dgCopyGrid[3, selRaw].Value = dblnetamount.ToString();
            dgCopyGrid[4, selRaw].Value = strDrcr;
            dgCopyGrid.AllowUserToAddRows = false;

        }
        private void mAdditemBillTemp(string strLedgerName, string strTypeofRef, string strBillRefNo, string strdueDate, double dblAmount, string strDrcr, double dblComm, double dblInt)
        {
            int selRaw;



            //string strDown = "";
            //Boolean blngCheck = false;
            //for (int j = 0; j < dgCopyBillGrid.RowCount; j++)
            //{
            //    if (dgCopyBillGrid[2, j].Value != null)
            //    {
            //        strDown = dgCopyBillGrid[2, j].Value.ToString();
            //    }
            //    if (strBillRefNo == strDown.ToString())
            //    {
            //        blngCheck = true;
            //    }

            //}
            //if (blngCheck == false)
            //{
            //if (txtBillPreTotal.Text != txtBillTotal.Text)
            //{
            dgCopyBillGrid.AllowUserToAddRows = true;
            selRaw = Convert.ToInt16(dgCopyBillGrid.RowCount.ToString());
            selRaw = selRaw - 1;
            dgCopyBillGrid.Rows.Add();
            dgCopyBillGrid[0, selRaw].Value = strLedgerName.ToString();
            dgCopyBillGrid[1, selRaw].Value = strTypeofRef.ToString();
            dgCopyBillGrid[2, selRaw].Value = strBillRefNo.ToString();
            dgCopyBillGrid[3, selRaw].Value = strdueDate.ToString();
            dgCopyBillGrid[4, selRaw].Value = dblAmount.ToString();
            dgCopyBillGrid[5, selRaw].Value = strDrcr.ToString();
            dgCopyBillGrid[6, selRaw].Value = dblComm.ToString();
            dgCopyBillGrid[7, selRaw].Value = dblInt.ToString();
            dgCopyBillGrid.AllowUserToAddRows = false;
            //}
            //}



        }
        #endregion
        #region "Cost Center Content Click"
        private void DgCostCenter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    double dblamnt = 0;
                    if (e.RowIndex == 0)
                    {
                        //dblamnt = Convert.ToDouble(txtpreAmount.Text);
                        //uctxtAmount.Text = (Convert.ToDouble(txtpreAmount.Text) - dblamnt).ToString();
                        //mDeleteRow(dgCopyGrid, txtpreAmount.Text);
                        //DgCostCenter.Rows.Clear();
                        //dgCopyGrid.Rows.Clear();
                        //if (dgCopyGrid.Rows.Count == 1)
                        //{
                        //    dgCopyGrid.Rows.Clear();
                        //}
                        mDeleteRow(dgCopyGrid, DgCostCenter[1, e.RowIndex].Value.ToString());
                        DgCostCenter.Rows.RemoveAt(e.RowIndex);
                        for (int i = 0; i < DgCostCenter.Rows.Count; i++)
                        {
                            dblamnt = dblamnt + Convert.ToDouble(DgCostCenter.Rows[i].Cells[3].Value);
                        }
                        uctxtAmount.Text = (Convert.ToDouble(txtpreAmount.Text) - dblamnt).ToString();
                        uctxtCostCategory.Focus();
                    }

                    else
                    {
                        string strMainLedger = txtLedgerName.Text;
                        //for (int inttemp = 0; inttemp < dgCopyGrid.Rows.Count;inttemp ++ )
                        //{
                        //    if (strMainLedger==dgCopyGrid[0,inttemp].Value.ToString() )
                        //    {
                        //        dgCopyGrid.Rows.RemoveAt(inttemp);
                        //    }
                        //}
                        mDeleteRow(dgCopyGrid, DgCostCenter[1,e.RowIndex].Value.ToString());
                        DgCostCenter.Rows.RemoveAt(e.RowIndex);
                        for (int i = 0; i < DgCostCenter.Rows.Count; i++)
                        {
                            dblamnt = dblamnt + Convert.ToDouble(DgCostCenter.Rows[i].Cells[3].Value);
                        }
                        uctxtAmount.Text = (Convert.ToDouble(txtpreAmount.Text) - dblamnt).ToString();
                        uctxtCostCategory.Focus();
                    }


                    calculateTotal();
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "Button Cancel"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlCostCenter.Visible = false;
            txtDrcr.Focus();
        }
        #endregion
        #region "Cell click"
        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex != 8)
            //{
            //    if (DG.Rows.Count > 0 && DG.CurrentRow.Cells[0].Value != null)
            //    {
            //        introw.Text = e.RowIndex.ToString();
            //        txtDrcr.Text = DG.CurrentRow.Cells[0].Value.ToString();
            //        txtParticulars.Text = DG.CurrentRow.Cells[1].Value.ToString();
            //        if (DG.CurrentRow.Cells[5].Value != null)
            //        {
            //            txtChequeNo.Text = DG.CurrentRow.Cells[5].Value.ToString();
            //        }
            //        else
            //        {
            //            txtChequeNo.Text = "";
            //        }
            //        if (DG.CurrentRow.Cells[6].Value != null)
            //        {
            //            mskChequeDate.Text = DG.CurrentRow.Cells[6].Value.ToString();
            //        }
            //        else
            //        {
            //            mskChequeDate.Text = "";
            //        }
            //        if (DG.CurrentRow.Cells[7].Value != null )
            //        {
            //            txtDrawnon.Text = DG.CurrentRow.Cells[7].Value.ToString();
            //        }
            //        else
            //        {
            //            txtDrawnon.Text = "";
            //        }
            //        if (DG.CurrentRow.Cells[8].Value != null)
            //        {
            //            txtSingleNarration.Text = DG.CurrentRow.Cells[8].Value.ToString();
            //        }
            //        else
            //        {
            //            txtSingleNarration.Text = "";
            //        }
            //        txtDebitAmount.Text = DG.CurrentRow.Cells[9].Value.ToString();
            //        txtCreditAmount.Text = DG.CurrentRow.Cells[10].Value.ToString();

            //        if (txtDrcr.Text == "Dr")
            //        {
            //            txtDebitAmount.Enabled = true;
            //        }
            //        if (txtDrcr.Text == "Cr")
            //        {
            //            txtCreditAmount.Enabled = true;
            //        }
            //        // intSelectedType = 1;
            //        DG.Rows.RemoveAt(e.RowIndex);
            //        calculateTotal();
            //        txtParticulars.Select();
            //        txtParticulars.Focus();
            //    }
            //}
        }
        #endregion
        #region "Datagrid Conett Click"
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                try
                {

                    DG.Rows.RemoveAt(e.RowIndex);
                    calculateTotal();
                }
                catch (Exception ex)
                {

                }
            }
        }
        #endregion
        #region "Button Bank Apply"
        private void btnBankApply_Click(object sender, EventArgs e)
        {
            grpBankInformation.Visible = false;
            if (Utility.Val(txtNetCredit.Text) == Utility.Val(txtNetDebit.Text))
            {
                txtNarration.Focus();
            }
            else
            {
                txtDrcr.Focus();
            }
            int i = Convert.ToInt16(introw.Text);
            DG.Rows[i].Cells[5].Value = txtChequeNo.Text;
            if (mskChequeDate.Text != Utility.gcMaskDate)
            {
                DG.Rows[i].Cells[6].Value = mskChequeDate.Text;
            }
            else
            {
                DG.Rows[i].Cells[6].Value = "";
            }
            DG.Rows[i].Cells[7].Value = txtDrawnon.Text;
            //txtChequeNo.Text = "";
            //txtDrawnon.Text = "";
        }
        #endregion
        #region "Button Edit"
        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmAccountsVoucherList objfrm = new frmAccountsVoucherList();
            objfrm.mintVType = intvtype;
            objfrm.onAddAllButtonClicked = new frmAccountsVoucherList.AddAllClick(DisplayVoucherList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = strFormName;
            objfrm.strPreserveSQl = mstrPrserveSql;
            objfrm.intModuleType = (int)Utility.MODULE_TYPE.mtACCOUNT;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;

        }
        #endregion
        #region "Display Voucher"
        private void DisplayVoucherList(List<AccountsVoucher> tests, object sender, EventArgs e)
        {
            try
            {
                int introw = 0;
                string strteritorryCode = "";
                if ((intvtype == (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER) || (intvtype == (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER))
                {
                    cboGeneral.Focus();
                    cboGeneral.Select();
                }
                else
                {
                    dteVoucherDate.Select();
                    dteVoucherDate.Focus();
                }
               
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DG.Rows.Clear();
                dgCopyGrid.Rows.Clear();
                DgCostCenter.Rows.Clear();
                DGTemplate.Rows.Clear();
                DGJVTemplate.Rows.Clear();
                uctxtOldNo.Text = tests[0].strVoucherNo;
                mstrPrserveSql = tests[0].strPreserveSQL;
                List<AccountsVoucher> ooaccVou = accms.DisplayCompVoucherList(strComID, tests[0].strVoucherNo, intvtype).ToList();
                if (ooaccVou.Count > 0)
                {
                    foreach (AccountsVoucher oCom in ooaccVou)
                    {
                        uctxtVoucherNo.Text = Utility.Mid(oCom.strVoucherNo, 6, oCom.strVoucherNo.Length - 6);
                        dteVoucherDate.Text = oCom.strTranDate;
                        txtBranchName.Text = Utility.gstrGetBranchName(strComID, oCom.strBranchID);
                        txtNarration.Text = oCom.strNarration;

                        List<AccountsVoucher> ooVouList = accms.DisplayVoucherList(strComID, tests[0].strVoucherNo, intvtype,0).ToList();
                        if (ooVouList.Count > 0)
                        {
                            txtPosition.Text =ooVouList[0].intvoucherPos.ToString();
                            cboGeneral.SelectedValue = ooVouList[0].intTrasnsfer;
                            foreach (AccountsVoucher oacc in ooVouList)
                            {
                                DG.Rows.Add();
                                DG[0, introw].Value = oacc.strToby;
                                DG[1, introw].Value = oacc.strMerzeName;
                                strteritorryCode = Utility.GetTeritorryCodeFromLedgerName(strComID, oacc.strLedgerName);
                                DG[3, introw].Value = oacc.strLedgerName;
                                //DG[4, introw].Value = Utility.GetTeritorryName(strComID, strteritorryCode);
                                DG[4, introw].Value = "";
                                DG[5, introw].Value = oacc.strChequeNo;
                                DG[6, introw].Value = oacc.strChequeDate;
                                DG[7, introw].Value = oacc.strDrawnOn;
                                DG[8, introw].Value = oacc.strSingleNarration;
                                DG[9, introw].Value = oacc.dblDebitAmount;
                                DG[10, introw].Value = oacc.dblCreditAmount;
                                DG[11, introw].Value = "Delete";
                                introw += 1;
                            }
                            DG.AllowUserToAddRows = false;

                            List<VectorCategory> ooVector = accms.DisplayVectorList(strComID, tests[0].strVoucherNo).ToList();
                            if (ooVouList.Count > 0)
                            {
                                introw = 0;
                                foreach (VectorCategory oacc in ooVector)
                                {
                                    dgCopyGrid.Rows.Add();
                                    dgCopyGrid[0, introw].Value = oacc.accountsLedger.strLedgerName;
                                    dgCopyGrid[1, introw].Value = oacc.strVectorcategory;
                                    dgCopyGrid[2, introw].Value = oacc.strCostCenter;
                                    dgCopyGrid[3, introw].Value = Math.Abs(oacc.dblAmount);
                                    dgCopyGrid[4, introw].Value = oacc.strDrcr;

                                    introw += 1;
                                }
                            }
                            List<AccBillwise> obill = accms.DisplaycommonInvoiceBill(strComID, tests[0].strVoucherNo).ToList();
                            {
                                if (obill.Count > 0)
                                {
                                    int i = 0;
                                    foreach (AccBillwise ooBill in obill)
                                    {
                                        dgCopyBillGrid.Rows.Add();
                                        dgCopyBillGrid.Rows[i].Cells[0].Value = ooBill.strLedgerName;
                                        dgCopyBillGrid.Rows[i].Cells[1].Value = ooBill.strBillPrevNew;
                                        dgCopyBillGrid.Rows[i].Cells[2].Value = ooBill.strAgnstVoucherRefNo;
                                        dgCopyBillGrid.Rows[i].Cells[3].Value = ooBill.strDueDate;
                                        dgCopyBillGrid.Rows[i].Cells[4].Value = Math.Abs(ooBill.dblAmount);
                                        dgCopyBillGrid.Rows[i].Cells[5].Value = ooBill.strDrCr;
                                        //dgCopyBillGrid.Rows[i].Cells[6].Value = ooBill.STRC;
                                        //dgCopyBillGrid.Rows[i].Cells[7].Value = ooBill.strDrCr;
                                        i += 1;
                                    }
                                }
                            }
                            List<MFGvouhcer> ooInv = invms.mDisplayInoutTran(strComID, tests[0].strVoucherNo.ToString()).ToList();
                            if (ooInv.Count > 0)
                            {
                                int i = 0;
                                foreach (MFGvouhcer oinv in ooInv)
                                {
                                    DGinvms.Rows.Add();
                                    uctxtLocation.Text = oinv.strLocation;
                                    DGinvms[0, i].Value = oinv.strLocation;
                                    DGinvms[1, i].Value = oinv.strItemName;
                                    DGinvms[2, i].Value = oinv.dblQnty.ToString();
                                    DGinvms[3, i].Value = oinv.strUOM;
                                    DGinvms[4, i].Value = oinv.dblrate;
                                    DGinvms[5, i].Value = Math.Round(oinv.dblQnty * oinv.dblrate,2);
                                    DGinvms[6, i].Value = "Delete";
                                    DGinvms[7, i].Value = oinv.strBillKey;
                                    i += 1;
                                }
                                DGinvms.AllowUserToAddRows = false;
                            }

                            List<AccountsLedger> objTemplate = accms.DisplayAccountsTemplate(strComID,tests[0].strVoucherNo).ToList();
                            {
                                if (objTemplate.Count > 0)
                                {
                                    int i = 0;
                                    if (intvtype == (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER)
                                    {
                                        foreach (AccountsLedger ooBill in objTemplate)
                                        {
                                            DGTemplate.Rows.Add();
                                            txtTemplateName.Text = ooBill.strmerzeString;
                                            DGTemplate.Rows[i].Cells[0].Value = ooBill.strLedgerName;
                                            DGTemplate.Rows[i].Cells[1].Value = ooBill.strCreditDate;
                                            DGTemplate.Rows[i].Cells[2].Value = ooBill.dblToAmt;
                                            i += 1;
                                        }
                                        DGTemplate.AllowUserToAddRows = false;
                                    }
                                    else
                                    {
                                        foreach (AccountsLedger ooBill in objTemplate)
                                        {
                                            DGJVTemplate.Rows.Add();
                                            txtTemplateName.Text = ooBill.strmerzeString;
                                            DGJVTemplate.Rows[i].Cells[0].Value = ooBill.strLedgerName;
                                            DGJVTemplate.Rows[i].Cells[1].Value = ooBill.strcloseDate;
                                            DGJVTemplate.Rows[i].Cells[2].Value = ooBill.strCreditDate;
                                            DGJVTemplate.Rows[i].Cells[3].Value = ooBill.dblToAmt;
                                            DGJVTemplate.Rows[i].Cells[4].Value = ooBill.dblFromAmt;
                                            i += 1;
                                        }
                                        DGJVTemplate.AllowUserToAddRows = false;

                                    }
                                }
                            }


                        }
                        //uctxtVoucherNo.Focus();
                        calculateTotal();
                        calculateTempLateTotal();

                    }
                }


            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "Button "
        private void btnNew_Click(object sender, EventArgs e)
        {
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
        }

        private void btnBillapply_Click(object sender, EventArgs e)
        {
            double dblInte = 0;
            if (txtBillPreTotal.Text != txtBillTotal.Text)
            {
                MessageBox.Show("Bill Amount Mismatch");
                txtTotal.Focus();
                return;
            }
            mDeleteRow(dgCopyBillGrid, txtBillLedger.Text);
            for (int i = 0; i < dgBillBranch.Rows.Count; i++)
            {

                if (dgBillBranch[6, i].Value == null)
                {
                    dblInte = Utility.Val(dgBillBranch[6, i].Value.ToString());
                }
                else
                {
                    dblInte = 0;
                }

                if (dgBillBranch[0, i].Value != null)
                {
                    mAdditemBillTemp(txtBillLedger.Text, dgBillBranch[0, i].Value.ToString(), dgBillBranch[1, i].Value.ToString(), dgBillBranch[2, i].Value.ToString(),
                                                    Utility.Val(dgBillBranch[3, i].Value.ToString()), dgBillBranch[4, i].Value.ToString(),
                                                    0, 0);

                }
            }
            pnlBillWise.Visible = false;
            txtDrcr.Focus();
        }

        private void btnBillCancel_Click(object sender, EventArgs e)
        {
            pnlBillWise.Visible = false;
        }
        #endregion
        #region "Delete Row"
        private void mDeleteRow(DataGridView dg, string strMainLedger)
        {

            string strBillLedger, strString = "";
            try
            {
                for (int inttemp = 0; inttemp < dg.Rows.Count; inttemp++)
                {
                    strBillLedger = dg[2, inttemp].Value.ToString();

                    if (strBillLedger == strMainLedger)
                    {
                        strString = strString + inttemp + ",";
                    }
                }

                string[] words = strString.Split(',');
                foreach (string branch in words)
                {
                    if (branch != "")
                    {
                        int introw = Convert.ToInt16(branch);
                        if (introw.ToString() != "")
                        {
                            dg.Rows.RemoveAt(introw);
                        }
                    }

                }

            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }


        }
        #endregion
        #region "Dg Cell Content Click"
        private void dgBillBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.ColumnIndex == 7)
                {
                    double dblamnt = 0;
                    string strMainLedger, strBillLedger = "", strString = "";
                    strMainLedger = txtBillLedger.Text;
                    if (e.RowIndex == 0)
                    {
                        dblamnt = Convert.ToDouble(txtBillPreTotal.Text);
                        uctxtAmount.Text = (Convert.ToDouble(txtBillPreTotal.Text) - dblamnt).ToString();

                        //for (int inttemp = 0; inttemp < dgCopyBillGrid.Rows.Count; inttemp++)
                        // {
                        //     strBillLedger = dgCopyBillGrid[0, inttemp].Value.ToString();

                        //     if (strBillLedger == strMainLedger)                           
                        //     {
                        //         strString = strString + inttemp + ",";
                        //     }
                        // }
                        //  string[] words = strString.Split(',');
                        //  foreach (string branch in words)
                        //  {
                        //      if (branch != "")
                        //      {
                        //          int introw = Convert.ToInt16(words[0]);
                        //          if (introw.ToString() != "")
                        //          {
                        //              dgCopyBillGrid.Rows.RemoveAt(introw);
                        //          }
                        //      }
                        //  }
                        mDeleteRow(dgCopyBillGrid, strMainLedger);
                        dgBillBranch.Rows.RemoveAt(e.RowIndex);

                    }

                    else
                    {

                        //for (int inttemp = 0; inttemp < dgCopyBillGrid.Rows.Count; inttemp++)
                        //{
                        //    if (strMainLedger == dgCopyBillGrid[0, inttemp].Value.ToString())
                        //    {
                        //        dgCopyBillGrid.Rows.RemoveAt(inttemp);
                        //    }
                        //}
                        mDeleteRow(dgCopyBillGrid, strMainLedger);
                        dgBillBranch.Rows.RemoveAt(e.RowIndex);
                        //dgBillBranch.Rows.RemoveAt(e.RowIndex);
                        for (int i = 0; i < dgBillBranch.Rows.Count; i++)
                        {
                            dblamnt = dblamnt + Convert.ToDouble(dgBillBranch.Rows[i].Cells[3].Value);
                        }
                        uctxtAmount.Text = (Convert.ToDouble(txtpreAmount.Text) - dblamnt).ToString();
                    }


                    calculateTotal();
                }
            }
            catch (Exception ex)
            {
                //dgCopyBillGrid.Rows.Clear();
                MessageBox.Show(ex.ToString());
            }




        }
        #endregion
        #region "Key Event"

        public bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }
        //private void txtParticulars_KeyUp(object sender, KeyEventArgs e)
        //{
        //    int intchek = 0;
        //    if (IsNumeric(txtParticulars.Text))
        //    {
        //        intchek = 1;
        //    }
        //    else
        //    {
        //        intchek = 0;
        //    }

        //    SearchListViewPartyName(oledger, txtParticulars.Text, intchek);
        //}

        //private void SearchListViewPartyName(IEnumerable<AccountsLedger> tests, string searchString, int intMode)
        //{
        //    IEnumerable<AccountsLedger> query;
        //    //if ((searchString.Length > 0))
        //    //{
        //    query = tests;

        //    //if (chkVoucheNo.Checked == true)
        //    //{
        //    if (searchString != "")
        //    {
        //        //query = tests.Where(x => x.strmerzeString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
        //        if (intMode == 0)
        //        {
        //            query = (from test in tests
        //                     where test.strmerzeString.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
        //                     select test);
        //        }
        //        else
        //        {
        //            query = tests.Where(x => x.strmerzeString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
        //        }
        //    }
        //    //}
        //    //else if (chkEntryby.Checked)
        //    //{
        //    //    query = (from test in tests
        //    //             where test.entryby.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
        //    //             select test);

        //    //}

        //    //else if (chkAmount.Checked)
        //    //{
        //    //    query = (from test in tests
        //    //             where test.dblNetDebitAmount.ToString().StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
        //    //             select test);
        //    //}
        //    lstPrticulars.Items.Clear();
        //    int introw = 0;
        //    try
        //    {
        //        foreach (AccountsLedger tran in query)
        //        {

        //            //DGMr.Rows.Add();

        //            //DGMr[0, introw].Value = tran.strTeritorryCode;
        //            //DGMr[1, introw].Value = tran.strLedgerName;
        //            //DGMr[2, introw].Value = tran.strTeritoryyName;
        //            //DGMr[3, introw].Value = tran.strmerzeString;
        //            //if (introw % 2 == 0)
        //            //{
        //            //    DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
        //            //}
        //            //else
        //            //{
        //            //    DGMr.Rows[introw].DefaultCellStyle.BackColor = Color.White;
        //            //}
        //            introw += 1;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //}

        private void btnChequeCancel_Click(object sender, EventArgs e)
        {
            grpBankInformation.Visible = false;
        }

        private void DG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DG.Rows.Count > 0)
            {
                var strResponseInsert = MessageBox.Show("Do You Want to Modify this Ledger?" + "(" + DG.CurrentRow.Cells[1].Value.ToString() + ")", "Modify Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    introw.Text = e.RowIndex.ToString();
                    txtDrcr.Text = DG.CurrentRow.Cells[0].Value.ToString();
                    mstrOldParticulars = DG.CurrentRow.Cells[1].Value.ToString();
                    txtParticulars.Text = DG.CurrentRow.Cells[1].Value.ToString();
                    if (DG.CurrentRow.Cells[5].Value != null)
                    {
                        txtChequeNo.Text = DG.CurrentRow.Cells[5].Value.ToString();
                    }
                    else
                    {
                        txtChequeNo.Text = "";
                    }
                    if (DG.CurrentRow.Cells[6].Value != null)
                    {
                        mskChequeDate.Text = DG.CurrentRow.Cells[6].Value.ToString();
                    }
                    else
                    {
                        mskChequeDate.Text = "";
                    }
                    if (DG.CurrentRow.Cells[7].Value != null)
                    {
                        txtDrawnon.Text = DG.CurrentRow.Cells[7].Value.ToString();
                    }
                    else
                    {
                        txtDrawnon.Text = "";
                    }
                    if (DG.CurrentRow.Cells[8].Value != null)
                    {
                        txtSingleNarration.Text = DG.CurrentRow.Cells[8].Value.ToString();
                    }
                    else
                    {
                        txtSingleNarration.Text = "";
                    }
                    txtDebitAmount.Text = DG.CurrentRow.Cells[9].Value.ToString();
                    txtCreditAmount.Text = DG.CurrentRow.Cells[10].Value.ToString();

                    if (txtDrcr.Text == "Dr")
                    {
                        txtDebitAmount.Enabled = true;
                    }
                    if (txtDrcr.Text == "Cr")
                    {
                        txtCreditAmount.Enabled = true;
                    }
                    // intSelectedType = 1;
                    DG.Rows.RemoveAt(e.RowIndex);
                    calculateTotal();
                    // txtParticulars.Select();
                    txtParticulars.Focus();
                }
            }
            //if (e.ColumnIndex != 8)
            //{
            //    if (DG.Rows.Count > 0 && DG.CurrentRow.Cells[0].Value != null)
            //    {
            //        
            //    }
            //}
        }

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dbldebitAmount = 0, dblCreditAmount = 0;
            int selraw;
            try
            {
                if (DG.Rows.Count > 0)
                {
                    for (int i = 0; i < DG.Rows.Count; i++)
                    {
                        dbldebitAmount = dbldebitAmount + Convert.ToDouble(DG.Rows[i].Cells[9].Value);
                        dblCreditAmount = dblCreditAmount + Convert.ToDouble(DG.Rows[i].Cells[10].Value);
                    }
                    if (dbldebitAmount != Utility.Val(txtNetCredit.Text))
                    {
                        for (int i = 0; i < DG.Rows.Count; i++)
                        {
                            if (DG.Rows[i].Cells[0].Value != null )
                            {
                                if (DG.Rows[i].Cells[0].Value.ToString() == "Cr")
                                {
                                    DG.Rows[i].Cells[10].Value = 0;
                                    //if (i == 0)
                                    //{
                                    DG.Rows[i].Cells[10].Value = dbldebitAmount;
                                    //}
                                }
                            }
                        }
                        //DG.Rows[1].Cells[10].Value = dbldebitAmount;
                    }
                    else if (dblCreditAmount != Utility.Val(txtNetDebit.Text))
                    {
                        for (int i = 0; i < DG.Rows.Count; i++)
                        {
                            if (DG.Rows[i].Cells[0].Value != null)
                            {
                                if (DG.Rows[i].Cells[0].Value.ToString() == "Dr")
                                {
                                    DG.Rows[i].Cells[9].Value = 0;
                                    //if (i == 0)
                                    //{
                                    DG.Rows[i].Cells[9].Value = dblCreditAmount;
                                    //}
                                }
                            }
                        }

                    }
                }
                if (DG[0, e.RowIndex].Value.ToString().ToUpper() == "DR")
                {

                    if (Utility.gbcheckCostCenter(strComID, DG[1, e.RowIndex].Value.ToString()) == true)
                    {
                        pnlCostCenter.Visible = true;
                        uctxtCostCategory.Focus();
                        uctxtCostCategory.Select();
                        pnlCostCenter.Top = txtSingleNarration.Top + 60;
                        pnlCostCenter.Left = txtSingleNarration.Left;
                        pnlCostCenter.Size = new Size(695, 269);
                        DgCostCenter.Size = new Size(710, 147);
                        btnApply.Top = DgCostCenter.Height + 70;
                        btnCancel.Top = DgCostCenter.Height + 70;
                        uctxtAmount.Text = Utility.Val(DG[9, e.RowIndex].Value.ToString()).ToString();
                        txtpreAmount.Text = Utility.Val(DG[9, e.RowIndex].Value.ToString()).ToString();
                        txtLedgerName.Text = DG[1, e.RowIndex].Value.ToString();
                        txtdrcr1.Text = txtDrcr.Text;
                        DgCostCenter.Rows.Clear();
                        for (int i = 0; i < dgCopyGrid.Rows.Count; i++)
                        {
                            if (dgCopyGrid[0, i].Value != null)
                            {
                                if (dgCopyGrid[0, i].Value.ToString() == txtLedgerName.Text)
                                {
                                    DgCostCenter.AllowUserToAddRows = true;
                                    selraw = Convert.ToInt16(DgCostCenter.RowCount.ToString());
                                    selraw = selraw - 1;
                                    DgCostCenter.Rows.Add(1);
                                    DgCostCenter.Rows[selraw].Cells[0].Value = dgCopyGrid[1, i].Value;
                                    DgCostCenter.Rows[selraw].Cells[1].Value = dgCopyGrid[2, i].Value;
                                    DgCostCenter.Rows[selraw].Cells[2].Value = dgCopyGrid[3, i].Value;
                                    DgCostCenter.Rows[selraw].Cells[4].Value = txtdrcr1.Text;
                                    DgCostCenter.AllowUserToAddRows = false;
                                }
                            }
                        }
                    }
                    if (Utility.gbcheckBankLedger(strComID, DG[1, e.RowIndex].Value.ToString()) == true)
                    {
                        grpBankInformation.Visible = true;
                        introw.Text = e.RowIndex.ToString();
                        if (DG[5, e.RowIndex].Value.ToString() != "")
                        {
                            txtChequeNo.Text = DG[5, e.RowIndex].Value.ToString();
                        }
                        else
                        {
                            txtChequeNo.Text = "";
                        }
                        if (DG[6, e.RowIndex].Value != null)
                        {
                            mskChequeDate.Text = DG[6, e.RowIndex].Value.ToString();
                        }
                        else
                        {
                            mskChequeDate.Text = "";
                        }
                        if (DG[7, e.RowIndex].Value != null)
                        {
                            txtDrawnon.Text = DG[7, e.RowIndex].Value.ToString();
                        }
                        else
                        {
                            txtDrawnon.Text = "";
                        }
                        txtChequeNo.Focus();
                    }
                    else
                    {
                        txtChequeNo.Text = "";
                        mskChequeDate.Text = "";
                        txtDrawnon.Text = "";
                    }
                }
                else if (DG[0, e.RowIndex].Value.ToString().ToUpper() == "CR")
                {

                    if (Utility.gbcheckCostCenter(strComID, DG[1, e.RowIndex].Value.ToString()) == true)
                    {
                        pnlCostCenter.Visible = true;
                        uctxtCostCategory.Focus();
                        uctxtCostCategory.Select();
                        pnlCostCenter.Top = txtSingleNarration.Top + 60;
                        pnlCostCenter.Left = txtSingleNarration.Left;
                        pnlCostCenter.Size = new Size(695, 269);
                        DgCostCenter.Size = new Size(710, 147);
                        btnApply.Top = DgCostCenter.Height + 70;
                        btnCancel.Top = DgCostCenter.Height + 70;
                        uctxtAmount.Text = Utility.Val(DG[10, e.RowIndex].Value.ToString()).ToString();
                        txtpreAmount.Text = Utility.Val(DG[10, e.RowIndex].Value.ToString()).ToString();
                        txtLedgerName.Text = DG[1, e.RowIndex].Value.ToString();
                        txtdrcr1.Text = txtDrcr.Text;
                        DgCostCenter.Rows.Clear();
                        for (int i = 0; i < dgCopyGrid.Rows.Count; i++)
                        {
                            if (dgCopyGrid[0, i].Value != null)
                            {
                                if (dgCopyGrid[0, i].Value.ToString() == txtLedgerName.Text)
                                {
                                    DgCostCenter.AllowUserToAddRows = true;
                                    selraw = Convert.ToInt16(DgCostCenter.RowCount.ToString());
                                    selraw = selraw - 1;
                                    DgCostCenter.Rows.Add(1);
                                    DgCostCenter.Rows[selraw].Cells[0].Value = dgCopyGrid[1, i].Value;
                                    DgCostCenter.Rows[selraw].Cells[1].Value = dgCopyGrid[2, i].Value;
                                    DgCostCenter.Rows[selraw].Cells[2].Value = dgCopyGrid[3, i].Value;
                                    DgCostCenter.Rows[selraw].Cells[4].Value = txtdrcr1.Text;
                                    DgCostCenter.AllowUserToAddRows = false;
                                }
                            }
                        }
                    }
                    if (Utility.gbcheckBankLedger(strComID, DG[1, e.RowIndex].Value.ToString()) == true)
                    {
                        grpBankInformation.Visible = true;
                        introw.Text = e.RowIndex.ToString();
                        if (DG[5, e.RowIndex].Value != null)
                        {
                            txtChequeNo.Text = DG[5, e.RowIndex].Value.ToString();
                        }
                        if (DG[6, e.RowIndex].Value != null)
                        {
                            mskChequeDate.Text = DG[6, e.RowIndex].Value.ToString();
                        }
                        if (DG[7, e.RowIndex].Value != null)
                        {
                            txtDrawnon.Text = DG[7, e.RowIndex].Value.ToString();
                        }
                        txtChequeNo.Focus();
                    }
                    else
                    {
                        txtChequeNo.Text = "";
                        mskChequeDate.Text = "";
                        txtDrawnon.Text = "";
                    }
                }

                calculateTotal();
                if (pnlCostCenter.Visible == false)
                {
                    if (Utility.Val(txtNetDebit.Text) == Utility.Val(txtNetCredit.Text))
                    {
                        if (grpBankInformation.Visible)
                        {
                            txtChequeNo.Focus();
                        }
                        else if (pnlCostCenter.Visible)
                        {
                            uctxtCostCategory.Focus();
                        }
                        else
                        {
                            txtNarration.Focus();
                        }
                    }
                    else
                    {
                        DG.Focus();
                    }
                }
                else
                {
                    uctxtCostCategory.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void DG_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Back)
            {
                txtNarration.Focus();
            }
        }

        private void chkIncludeX_Click(object sender, EventArgs e)
        {
            txtParticulars.Focus();
        }

        private void btnInvMsCancel_Click(object sender, EventArgs e)
        {
            PanelInventory.Visible = false;
            DGinvms.Rows.Clear();
        }

        private void btnAppInvms_Click(object sender, EventArgs e)
        {
            PanelInventory.Visible = false;
            if (txtDebitAmount.Enabled )
            {
                txtDebitAmount.Text = txtInvmsAmount.Text;
                txtDebitAmount.Focus();
            }
            else
            {
                txtCreditAmount.Text = txtInvmsAmount.Text;
                txtCreditAmount.Focus();
            }
        }

        private void uctxtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (uctxtItemName.Text != "")
                {
                    SearchListView(oogrp, uctxtItemName.Text);
                }
                //else
                //{
                //    uclstGrdItem.Rows.Clear();
                //    oogrp.Clear();
                //}
            }
            catch (Exception ex)
            {

            }
        }

        private void DGinvms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==6)
            {
                DGinvms.Rows.RemoveAt(e.RowIndex);
                calculateTotal();
            }
        }

        private void chkBkashCharge_Click(object sender, EventArgs e)
        {
            DG.Rows.Clear();
            txtParticulars.Text = "";
            txtDebitAmount.Text = "0";
            txtCreditAmount.Text = "0";
            dteVoucherDate.Focus();
            txtParticulars.Focus();
        }

        private void btnTempSave_Click(object sender, EventArgs e)
        {
            pnlTemplate.Visible = false;
            txtDebitAmount.Text = txtTemplateTotal.Text;
            txtDebitAmount.Focus();
        }

        private void btnTempClose_Click(object sender, EventArgs e)
        {
            pnlTemplate.Visible = false;
        }

        private void btnJVCancel_Click(object sender, EventArgs e)
        {
            panelRvSchedule.Visible = false;
        }

        private void btnJVapply_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGJVTemplate.Rows.Count == 0)
                {
                    txtInstallment.Focus();
                    MessageBox.Show("Cannot be Empty");
                    return;
                }
            
                panelRvSchedule.Visible = false;
                txtCreditAmount.Text = uctxtJVTotal.Text;
                txtFine.Text = txtJvFine.Text;
                txtCreditAmount.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chek your Date");
            }
        }

        private void DGJVTemplate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==5)
            {
                DGJVTemplate.Rows.RemoveAt(e.RowIndex);
                calculateTempLateTotal();
            }
        }

        private void btnJVapply_Click_1(object sender, EventArgs e)
        {

        }

        private void chkLoanTransfer_Click(object sender, EventArgs e)
        {
            txtBranchName.Focus();
        }

       

      
    }
}
