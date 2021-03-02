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

namespace JA.Modulecontrolar.UI.Transuction.Inventory
{
    public partial class frmMFGVoucher : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWIS = new SPWOIS();
        public int m_action { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int intvType { get; set; }
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstProcess = new ListBox();
        private ListBox lstBatch = new ListBox();
        private ListBox lstFgLocation = new ListBox();

        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
        private double mdblAmount { get; set; }
        List<InvoiceConfig> oinv;
        List<ManuProcess> ooItem;
        public int intconvert { get; set; }
        private const string mcGROUP_PREFIX = "G_";
        private const string mcLEDGER_PREFIX = "L_";
        private string strComID { get; set; }
        public frmMFGVoucher()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtVoucherNo_KeyPress);
            this.uctxtVoucherNo.GotFocus += new System.EventHandler(this.uctxtVoucherNo_GotFocus);
            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);
            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);

            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.dteDate_GotFocus);
            this.uctxtFgItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFgItem_KeyPress);
            this.uctxtFgItem.GotFocus += new System.EventHandler(this.uctxtFgItem_GotFocus);

            this.uctxtSampletoFg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSampletoFg_KeyPress);
            this.uctxtSampletoFg.GotFocus += new System.EventHandler(this.uctxtSampletoFg_GotFocus);

            this.uctxtSampleToQC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSampleToQC_KeyPress);
            this.uctxtSampleToQC.GotFocus += new System.EventHandler(this.uctxtSampleToQC_GotFocus);

            this.txtFGQnty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtFGQnty_KeyPress);
            this.txtFGQnty.GotFocus += new System.EventHandler(this.txtFGQnty_GotFocus);


            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);

            this.uctxtLocation.KeyDown += new KeyEventHandler(uctxtLocation_KeyDown);
            this.uctxtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLocation_KeyPress);
            this.uctxtLocation.TextChanged += new System.EventHandler(this.uctxtLocation_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.uctxtLocation.GotFocus += new System.EventHandler(this.uctxtLocation_GotFocus);

            this.uctxtProcessName.KeyDown += new KeyEventHandler(uctxtProcessName_KeyDown);
            this.uctxtProcessName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtProcessName_KeyPress);
            this.uctxtProcessName.TextChanged += new System.EventHandler(this.uctxtProcessName_TextChanged);
            this.lstProcess.DoubleClick += new System.EventHandler(this.lstProcess_DoubleClick);
            this.uctxtProcessName.GotFocus += new System.EventHandler(this.uctxtProcessName_GotFocus);

            this.DgRm.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgRm_CellEndEdit);
            this.DgWastageRm.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgWastage_CellEndEdit);
            this.dgWastagePm.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgWastagePm_CellEndEdit);
            this.DgPm.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgPm_CellEndEdit);

            this.uctxtBatch.KeyDown += new KeyEventHandler(uctxtBatch_KeyDown);
            this.uctxtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatch_KeyPress);
            this.uctxtBatch.TextChanged += new System.EventHandler(this.uctxtBatch_TextChanged);
            this.lstBatch.DoubleClick += new System.EventHandler(this.lstBatch_DoubleClick);
            this.uctxtBatch.GotFocus += new System.EventHandler(this.uctxtBatch_GotFocus);

            this.txtFgLocation.KeyDown += new KeyEventHandler(txtFgLocation_KeyDown);
            this.txtFgLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtFgLocation_KeyPress);
            this.txtFgLocation.TextChanged += new System.EventHandler(this.txtFgLocation_TextChanged);
            this.lstFgLocation.DoubleClick += new System.EventHandler(this.lstFgLocation_DoubleClick);
            this.txtFgLocation.GotFocus += new System.EventHandler(this.txtFgLocation_GotFocus);

            this.chkChangeRm.Click += new System.EventHandler(this.chkChangeRm_Click);
            this.chkChangePm.Click += new System.EventHandler(this.chkChangePm_Click);
            this.chkPartial.Click += new System.EventHandler(this.chkPartial_Click);
            this.uctxtSampletoFg.TextChanged += new System.EventHandler(this.uctxtSampletoFg_TextChanged);
            this.uctxtSampleToQC.TextChanged += new System.EventHandler(this.uctxtSampleToQC_TextChanged);

            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            Utility.CreateListBox(lstProcess, pnlMain, uctxtProcessName);
            Utility.CreateListBox(lstBatch, pnlMain, uctxtBatch);
            Utility.CreateListBox(lstFgLocation, pnlMain, txtFgLocation);

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
        #region "Display Process"
        private void DisplayProcess(string vstrProcess)
        {
            double dblrate = 0, dblCostPercent = 0, dblCostFgQnt = 0;
            try
            {
                int intrm = 0, intWastage = 0, intPm = 0;
               

              
               
                dblCostFgQnt = Utility.Val(txtFGQnty.Text.ToString());
                dblCostPercent = 100;
                //uctxtProcessName.Focus();
                DgRm.Rows.Clear();
                DgWastageRm.Rows.Clear();
                dgWastagePm.Rows.Clear();
                DgPm.Rows.Clear();
                mdblAmount = 0;
                ooItem = invms.mDisplayProcess(strComID, vstrProcess,"").ToList();
                if (ooItem.Count > 0)
                {
                    
                    foreach (ManuProcess ts in ooItem)
                    {
                        dblrate = 0;

                        if (ts.intType == 1)
                        {
                            DgRm.Rows.Add();
                            DgRm[0, intrm].Value = ts.stritemName;
                            DgRm[1, intrm].Value = ts.dblqnty + " " + ts.strUnit;
                            DgRm[2, intrm].Value = ts.strUnit;
                            dblrate = Utility.gdblPurchasePrice(strComID, ts.stritemName, dteDate.Text);
                            DgRm[3, intrm].Value = Math.Round((ts.dblqnty * dblrate), 4);
                            DgRm[4, intrm].Value = "Del.";
                            DgRm[5, intrm].Value = ts.dblqnty;
                            mdblAmount = mdblAmount + Math.Round(Utility.Val(DgRm[3, intrm].Value.ToString()), 4);
                            DgWastageRm.Rows.Add();
                            DgWastageRm[0, intrm].Value = ts.stritemName;
                            DgWastageRm[1, intrm].Value = 0;
                            DgWastageRm[2, intrm].Value = ts.strUnit;
                            DgWastageRm[3, intrm].Value = 0;
                            DgWastageRm[4, intrm].Value = "Del.";
                            intrm += 1;
                        }
                        if (ts.intType == 2)
                        {
                            DgPm.Rows.Add();
                            DgPm[0, intPm].Value = ts.stritemName;
                            DgPm[1, intPm].Value = Math.Round(ts.dblqnty) + " " + ts.strUnit;
                            DgPm[2, intPm].Value = ts.strUnit;
                            dblrate = Utility.gdblPurchasePrice(strComID, ts.stritemName, dteDate.Text);
                            DgPm[3, intPm].Value = Math.Round((Math.Round(ts.dblqnty) * dblrate), 4);
                            DgPm[4, intPm].Value = "Del.";
                            DgPm[5, intPm].Value = ts.dblqnty;
                            mdblAmount = mdblAmount + Math.Round(Utility.Val(DgPm[3, intPm].Value.ToString()), 4);
                            dgWastagePm.Rows.Add();
                            dgWastagePm[0, intPm].Value = ts.stritemName;
                            dgWastagePm[1, intPm].Value = 0;
                            dgWastagePm[2, intPm].Value = ts.strUnit;
                            dgWastagePm[3, intPm].Value = 0;
                            dgWastagePm[4, intPm].Value = "Del.";
                            intPm += 1;
                        }

                        DgRm.AllowUserToAddRows = false;
                        DgWastageRm.AllowUserToAddRows = false;
                        DgPm.AllowUserToAddRows = false;
                        dgWastagePm.AllowUserToAddRows = false;
                        intWastage += 1;
                        if (ts.intType == 0)
                        {
                            uctxtFgItem.Text = ts.stritemName;
                        }
                    }

                }

                if (mdblAmount != 0)
                {
                    txtFgValue.Text = (Math.Round(mdblAmount, 2)).ToString();
                    lblUnitPrice.Text = "Unit Price of F. Goods: " + Math.Round((((mdblAmount / dblCostFgQnt) * dblCostPercent) / 100), 2).ToString();
                }
                calculateTotal();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion
        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblRmAmount = 0, dblWastageAmount = 0, dblpm = 0, dblUnitPrice = 0, dblfgQnty,dblWastagePm=0;
            dblfgQnty = Utility.Val(txtFGQnty.Text);

            for (int i = 0; i < DgRm.Rows.Count; i++)
            {

                dblRmAmount = dblRmAmount + Utility.Val(DgRm.Rows[i].Cells[3].Value.ToString());
            }
            for (int i = 0; i < DgWastageRm.Rows.Count; i++)
            {

                dblWastageAmount = dblWastageAmount + Utility.Val(DgWastageRm.Rows[i].Cells[3].Value.ToString());
            }
            for (int i = 0; i < DgPm.Rows.Count; i++)
            {

                dblpm = dblpm + Utility.Val(DgPm.Rows[i].Cells[3].Value.ToString());
            }
            for (int i = 0; i < dgWastagePm.Rows.Count; i++)
            {

                dblWastagePm = dblWastagePm + Utility.Val(dgWastagePm.Rows[i].Cells[3].Value.ToString());
            }
            lblRmAmount.Text = Math.Round(dblRmAmount, 2).ToString();
            lblPmAmount.Text = Math.Round(dblpm, 2).ToString();
            lblWastagePmAmount.Text = Math.Round(dblWastagePm, 2).ToString();
            lblWastageRmAmnt.Text = Math.Round(dblWastageAmount).ToString();
            txtFgValue.Text = "";
            txtFgValue.Text = (Math.Round(dblRmAmount + dblWastageAmount + dblpm + dblWastagePm, 2)).ToString();
            dblUnitPrice = (dblRmAmount + dblWastageAmount + dblpm) / dblfgQnty;
            if (chkChangeRm.Checked == true || chkChangePm.Checked == true)
            {
                lblUnitPrice.Text = "Unit Price of F. Goods: " + Math.Round(dblUnitPrice, 2).ToString();
            }

        }
        #endregion
        #region "User Define"
        private void uctxtSampleToQC_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtSampleToQC.Text) == false)
            {
                uctxtSampleToQC.Text = "";
            }
        }
        private void uctxtSampletoFg_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtSampletoFg.Text) == false)
            {
                uctxtSampletoFg.Text = "";
            }
        }
        private void uctxtSampleToQC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtNarration.Focus();
            }
        }

        private void uctxtSampleToQC_GotFocus(object sender, System.EventArgs e)
        {
            lstProcess.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstFgLocation.Visible = false;
            lstBatch.Visible = false;
        }
        private void uctxtSampletoFg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtSampleToQC.Focus();
            }
        }

        private void uctxtSampletoFg_GotFocus(object sender, System.EventArgs e)
        {
            lstProcess.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstFgLocation.Visible = false;
            lstBatch.Visible = false;
        }
       private void uctxtVoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtBatch.Enabled)
                {
                    uctxtBatch.Focus();
                }
                else
                {
                    dteDate.Focus();
                }
            }

        }

        private void uctxtVoucherNo_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstFgLocation.Visible = false;
        }
        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstFgLocation.Visible = false;
        }

        private void txtFgLocation_TextChanged(object sender, EventArgs e)
        {
            lstFgLocation.SelectedIndex = lstFgLocation.FindString(txtFgLocation.Text);
        }

        private void lstFgLocation_DoubleClick(object sender, EventArgs e)
        {
            txtFgLocation.Text = lstFgLocation.Text;
            if (uctxtProcessName.Enabled)
            {
                uctxtProcessName.Focus();
            }
            else
            {
                uctxtNarration.Focus();
            }
        }

        private void txtFgLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstFgLocation.Items.Count > 0)
                {
                    txtFgLocation.Text = lstFgLocation.Text;
                }
                if (uctxtProcessName.Enabled)
                {
                    uctxtProcessName.Focus();
                }
                else
                {
                    txtFGQnty.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtFgLocation, sender, e);
            }

        }
        private void txtFgLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstFgLocation.SelectedItem != null)
                {
                    lstFgLocation.SelectedIndex = lstFgLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstFgLocation.Items.Count - 1 > lstFgLocation.SelectedIndex)
                {
                    lstFgLocation.SelectedIndex = lstFgLocation.SelectedIndex + 1;
                }
            }

        }
        private void txtWastageQty_GotFocus(object sender, System.EventArgs e)
        {
            
            lstBatch.Visible = false;
            lstLocation.Visible = false;
            lstBranchName.Visible = false;
            lstProcess.Visible = false;
            lstFgLocation.Visible = false;
        }
        private void txtFGQnty_GotFocus(object sender, System.EventArgs e)
        {
             
            lstBatch.Visible = false;
            lstLocation.Visible = false;
            lstBranchName.Visible = false;
            lstProcess.Visible = false;
            lstFgLocation.Visible = false;
        }

        private void txtFgLocation_GotFocus(object sender, System.EventArgs e)
        {

            lstBatch.Visible = false;
            lstLocation.Visible = false;
            lstBranchName.Visible = false;
            lstProcess.Visible = false;
            lstFgLocation.Visible = true;
            if (uctxtBranchName.Text != "")
            {
                lstFgLocation.ValueMember = "strLocation";
                lstFgLocation.DisplayMember = "strLocation";
                lstFgLocation.DataSource = invms.gLoadInvoiceLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, 0).ToList();
            }
            if (lstBranchName.SelectedValue == "0001")
            {
                txtFgLocation.Text = lstFgLocation.Text;
            }
            else
            {
                txtFgLocation.Text = lstFgLocation.Text;
            }
            //lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
            lstFgLocation.SelectedIndex = lstFgLocation.FindString(txtFgLocation.Text);
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
        private void uctxtBatch_TextChanged(object sender, EventArgs e)
        {
            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }

        private void lstBatch_DoubleClick(object sender, EventArgs e)
        {
            double dblTotalBatchSize = 0, dblUsedBatchSize = 0;
            uctxtBatch.Text = lstBatch.Text;
            dblTotalBatchSize = Utility.mGetBatchSize(strComID, uctxtBatch.Text);
            dblUsedBatchSize = Utility.mGetBatchUsed(strComID, uctxtBatch.Text);

            txtFGQnty.Text = Utility.mGetBatchUsed(strComID, uctxtBatch.Text).ToString();
            lblBatchSize.Text = "Batch Size: " + Utility.mGetBatchSize(strComID, uctxtBatch.Text);
            lblPending.Text = "Pending: " + Utility.mGetBatchUsed(strComID, uctxtBatch.Text);
            lblUsed.Text = "Used: " + mGetSubstractValue(Utility.mGetBatchSize(strComID, uctxtBatch.Text), Utility.mGetBatchUsed(strComID, uctxtBatch.Text)).ToString();
          
            dteDate.Focus();
        }

        private void uctxtBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBatch.Items.Count > 0)
                {
                    double dblTotalBatchSize = 0, dblUsedBatchSize = 0;
                    uctxtBatch.Text = lstBatch.Text;
                    dblTotalBatchSize = Utility.mGetBatchSize(strComID, uctxtBatch.Text);
                    dblUsedBatchSize = Utility.mGetBatchUsed(strComID, uctxtBatch.Text);

                    txtFGQnty.Text = Utility.mGetBatchUsed(strComID, uctxtBatch.Text).ToString();
                    lblBatchSize.Text = "Batch Size: " + Utility.mGetBatchSize(strComID, uctxtBatch.Text);
                    lblPending.Text = "Pending: "  + Utility.mGetBatchUsed(strComID, uctxtBatch.Text);
                    lblUsed.Text = "Used: " + mGetSubstractValue(Utility.mGetBatchSize(strComID, uctxtBatch.Text), Utility.mGetBatchUsed(strComID, uctxtBatch.Text)).ToString();
                }
                dteDate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBatch, sender, e);
            }

        }

        private static string mGetSubstractValue(double value1, double value2)
        {
            double dblAmnt3;
           
            dblAmnt3 = value1 - value2;
            return dblAmnt3.ToString();

        }
        private void uctxtBatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBatch.SelectedItem != null)
                {
                    lstBatch.SelectedIndex = lstBatch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBatch.Items.Count - 1 > lstBatch.SelectedIndex)
                {
                    lstBatch.SelectedIndex = lstBatch.SelectedIndex + 1;
                }
            }

        }


        private void uctxtBatch_GotFocus(object sender, System.EventArgs e)
        {
            if (uctxtBatch.Enabled)
            {
                lstBatch.Visible = true;
            }
            else
            {
                lstBatch.Visible = false;
            }
            lstLocation.Visible = false;
            lstBranchName.Visible = false;
            lstProcess.Visible = false;
            lstFgLocation.Visible = false;
            lstBatch.DisplayMember = "Key";
            lstBatch.ValueMember = "Key";
            lstBatch.DataSource = new BindingSource(invms.mFillOpeningBatchNew(strComID), null);
            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }
      
        private void uctxtFgItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtFGQnty.Focus();
            }
        }
      
        private void uctxtFgItem_GotFocus(object sender, System.EventArgs e)
        {
            lstProcess.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstFgLocation.Visible = false;
            lstBatch.Visible = false;
        }

        private void uctxtProcessName_TextChanged(object sender, EventArgs e)
        {
            lstProcess.SelectedIndex = lstProcess.FindString(uctxtProcessName.Text);
        }

        private void lstProcess_DoubleClick(object sender, EventArgs e)
        {
            uctxtProcessName.Text = lstProcess.Text;
            if (uctxtProcessName.Text != "")
            {
                DisplayProcess(uctxtProcessName.Text);
                mDisplayReceipeChangeRM(1);
                mDisplayReceipeChangePM(1);
            }
            uctxtFgItem.Focus();
        }

        private void uctxtProcessName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstProcess.Items.Count > 0)
                {
                    uctxtProcessName.Text = lstProcess.Text;
                }
                if (uctxtProcessName.Text != "")
                {
                    DisplayProcess(uctxtProcessName.Text);
                    double dblUsedBatchSize = Utility.mGetBatchUsed(strComID, uctxtBatch.Text);
                    if (dblUsedBatchSize!=0 )
                    {
                        mDisplayReceipeChangeRM(1);
                        mDisplayReceipeChangePM(1);
                    }
                }
                uctxtFgItem.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtProcessName, sender, e);
            }
        }
        private void uctxtProcessName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstProcess.SelectedItem != null)
                {
                    lstProcess.SelectedIndex = lstProcess.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstProcess.Items.Count - 1 > lstProcess.SelectedIndex)
                {
                    lstProcess.SelectedIndex = lstProcess.SelectedIndex + 1;
                }
            }

        }

        private void uctxtProcessName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstBatch.Visible = false;
            lstProcess.Visible = true;
            lstFgLocation.Visible = false;
            lstProcess.SelectedIndex = lstProcess.FindString(uctxtProcessName.Text);
        }
        private void dteDate_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstFgLocation.Visible = false;
        }


        private void dteDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBranchName.Focus();

            }
        }

        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            dteDate.Focus();
        }

        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                }
                txtFgLocation.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtLocation, sender, e);
            }
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
            lstLocation.Visible = true;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstFgLocation.Visible = false;
            if (uctxtBranchName.Text != "")
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName,0).ToList();
            }
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }


        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranchName.Text;
            uctxtLocation.Focus();
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }
                uctxtLocation.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBranchName, sender, e);
            }
        }
        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
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

        }

        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = true;
            lstLocation.Visible = false;
            lstFgLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }
        #endregion
        #region "Getconfig"
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, intvType).ToList();
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
        #region "Load"
        private void frmMFGVoucher_Load(object sender, EventArgs e)
        {
            DgRm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 270, true, DataGridViewContentAlignment.TopLeft, true));
            DgRm.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DgRm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, false, DataGridViewContentAlignment.TopLeft, true));
            DgRm.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 110, true, DataGridViewContentAlignment.TopLeft, false));
            DgRm.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, false, DataGridViewContentAlignment.TopCenter, true));
            DgRm.Columns.Add(Utility.Create_Grid_Column("RQnty", "RQnty", 100, false, DataGridViewContentAlignment.TopLeft, false));
            DgRm.Columns.Add(Utility.Create_Grid_Column("billKey", "billKey", 100, false, DataGridViewContentAlignment.TopLeft, false));

            DgPm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 270, true, DataGridViewContentAlignment.TopLeft, true));
            DgPm.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DgPm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, false, DataGridViewContentAlignment.TopLeft, true));
            DgPm.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DgPm.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, false, DataGridViewContentAlignment.TopCenter, true));
            DgPm.Columns.Add(Utility.Create_Grid_Column("RQnty", "RQnty", 100, false, DataGridViewContentAlignment.TopLeft, false));
            DgPm.Columns.Add(Utility.Create_Grid_Column("billKey", "billKey", 100, false, DataGridViewContentAlignment.TopLeft, false));

            DgWastageRm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 270, true, DataGridViewContentAlignment.TopLeft, true));
            DgWastageRm.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 80, true, DataGridViewContentAlignment.TopLeft, false));
            DgWastageRm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, false, DataGridViewContentAlignment.TopLeft, true));
            DgWastageRm.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 90, true, DataGridViewContentAlignment.TopLeft, true));
            DgWastageRm.Columns.Add(Utility.Create_Grid_Column_button("", "", "", 50, false, DataGridViewContentAlignment.TopCenter, true));
            DgWastageRm.Columns.Add(Utility.Create_Grid_Column("billKey", "billKey", 100, false, DataGridViewContentAlignment.TopLeft, false));

            dgWastagePm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 270, true, DataGridViewContentAlignment.TopLeft, true));
            dgWastagePm.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 80, true, DataGridViewContentAlignment.TopLeft, false));
            dgWastagePm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, false, DataGridViewContentAlignment.TopLeft, true));
            dgWastagePm.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 80, true, DataGridViewContentAlignment.TopLeft, true));
            dgWastagePm.Columns.Add(Utility.Create_Grid_Column_button("", "", "", 50, false, DataGridViewContentAlignment.TopCenter, true));
            dgWastagePm.Columns.Add(Utility.Create_Grid_Column("billKey", "billKey", 100, false, DataGridViewContentAlignment.TopLeft, false));

            mGetConfig();
            mClear();

            cboYear.Items.Clear();
            cboYear.Text = DateTime.Now.ToString("yyyy");
            DateTime dteFdate=Convert.ToDateTime(Utility.gdteFinancialYearFrom);
            int intyear = (int)(Utility.DateDiff(Utility.DateInterval.Year,Convert.ToDateTime(Utility.gdteFinancialYearFrom), Convert.ToDateTime(Utility.gdteFinancialYearTo))) +1;
            for (int i = 1; i <= intyear;i++ )
            {
                cboYear.Items.Add(dteFdate.ToString("yyyy"));
                dteFdate = dteFdate.AddYears(1);
            }
            DgRm.AllowUserToAddRows = false;
            DgWastageRm.AllowUserToAddRows = false;
            DgPm.AllowUserToAddRows = false;
            dgWastagePm.AllowUserToAddRows = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstFgLocation.Visible = false;
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            lstProcess.ValueMember = "strProcessName";
            lstProcess.DisplayMember = "strProcessName";
            lstProcess.DataSource = invms.mLoadProcess(strComID, "", "", 0,1).ToList();
        }
        #endregion
        #region "GetMonth"
        private static string GetMonth(int intDay)
        {
            string Month = "";
            if (intDay == 1)
            {
                Month = "January";
            }
            else if (intDay == 2)
            {
                Month = "February";
            }
            else if (intDay == 3)
            {
                Month = "March";
            }
            else if (intDay == 4)
            {
                Month = "April";
            }
            else if (intDay == 5)
            {
                Month = "May";
            }
            else if (intDay == 6)
            {
                Month = "June";
            }
            else if (intDay == 7)
            {
                Month = "July";
            }
            else if (intDay == 8)
            {
                Month = "August";
            }
            else if (intDay == 9)
            {
                Month = "September";
            }
            else if (intDay == 10)
            {
                Month = "October";
            }
            else if (intDay == 11)
            {
                Month = "November";
            }
            else if (intDay == 12)
            {
                Month = "December";
            }
            return Month;
        }
        #endregion
        #region "Validation Field"
        private bool ValidateFields()
        {

            try
            {
                if (uctxtProcessName.Text == "")
                {
                    MessageBox.Show("Cannot Empty");
                    uctxtProcessName.Focus();
                    return false;
                }
                if (uctxtBatch.Text == "")
                {
                    MessageBox.Show("Cannot Empty");
                    uctxtBatch.Focus();
                    return false;
                }

                if (uctxtLocation.Text == "")
                {
                    MessageBox.Show("Cannot Empty");
                    uctxtLocation.Focus();
                    return false;
                }
                if (txtFgLocation.Text == "")
                {
                    MessageBox.Show("Cannot Empty");
                    txtFgLocation.Focus();
                    return false;
                }
                if (uctxtVoucherNo.Text == "")
                {
                    MessageBox.Show("Cannot Empty");
                    uctxtVoucherNo.Focus();
                    return false;
                }

                long lngDate = Convert.ToInt64(dteDate.Value.ToString("yyyyMMdd"));
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
                double dblClosingQTY = 0, dblCurrentQTY = 0;
                string strBillKey = "", strNegetiveItem = "";
                int intCheckNegetive = 0;
                if (oinv[0].mlngBlockNegativeStock > 0)
                {
                    for (int i = 0; i < DgRm.Rows.Count; i++)
                    {
                        if (DgRm[0, i].Value.ToString() != "")
                        {
                           
                            //dblClosingQTY = Utility.gdblClosingStock(strComID, DgRm[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                            dblClosingQTY = Utility.gdblClosingStockSales(strComID, DgRm[0, i].Value.ToString(), lstBranchName.SelectedValue.ToString(), "", uctxtLocation.Text);
                            if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            {
                                strBillKey = DgRm[6, i].Value.ToString();
                                dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                            }
                            dblCurrentQTY = Utility.Val(DgRm[1, i].Value.ToString());
                            if ((dblClosingQTY) - dblCurrentQTY < 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + DgRm[0, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                        }
                        dblClosingQTY = 0;
                    }
                    for (int i = 0; i < DgPm.Rows.Count; i++)
                    {
                        if (DgPm[0, i].Value.ToString() != "")
                        {
                           
                            //dblClosingQTY = Utility.gdblClosingStock(strComID, DgRm[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                            dblClosingQTY = Utility.gdblClosingStockSales(strComID, DgPm[0, i].Value.ToString(), lstBranchName.SelectedValue.ToString(), "", uctxtLocation.Text);
                            if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            {
                                strBillKey = DgPm[6, i].Value.ToString();
                                dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                            }
                            dblCurrentQTY = Utility.Val(DgPm[1, i].Value.ToString());
                            if ((dblClosingQTY) - dblCurrentQTY < 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + DgPm[0, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                        }
                        dblClosingQTY = 0;
                    }
                    if (intCheckNegetive > 0)
                    {
                        MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                        DgRm.Focus();
                        return false;
                    }
                    for (int i = 0; i < DgWastageRm.Rows.Count; i++)
                    {
                        if (DgWastageRm[0, i].Value.ToString() != "")
                        {
                            //strBillKey = DgWastageRm[5, i].Value.ToString();
                            //dblClosingQTY = Utility.gdblClosingStock(strComID, DgWastage[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                            dblClosingQTY = Utility.gdblClosingStockSales(strComID, DgWastageRm[0, i].Value.ToString(), lstBranchName.SelectedValue.ToString(), "", uctxtLocation.Text);
                            if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            {
                                strBillKey = DgWastageRm[5, i].Value.ToString();
                                dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                            }
                            dblCurrentQTY = Utility.Val(DgWastageRm[1, i].Value.ToString());
                            if ((dblClosingQTY) - dblCurrentQTY < 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + DgWastageRm[0, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                        }
                        dblClosingQTY = 0;
                    }

                    if (intCheckNegetive > 0)
                    {
                        MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                        DgRm.Focus();
                        return false;
                    }
                    for (int i = 0; i < dgWastagePm.Rows.Count; i++)
                    {
                        if (dgWastagePm[0, i].Value.ToString() != "")
                        {
                           
                            //dblClosingQTY = Utility.gdblClosingStock(strComID, DgWastage[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                            dblClosingQTY = Utility.gdblClosingStockSales(strComID, dgWastagePm[0, i].Value.ToString(), lstBranchName.SelectedValue.ToString(), "", uctxtLocation.Text);
                            if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                            {
                                strBillKey = dgWastagePm[5, i].Value.ToString();
                                dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey);
                            }
                            dblCurrentQTY = Utility.Val(dgWastagePm[1, i].Value.ToString());
                            if ((dblClosingQTY) - dblCurrentQTY < 0)
                            {
                                strNegetiveItem = strNegetiveItem + Environment.NewLine + dgWastagePm[0, i].Value.ToString();
                                intCheckNegetive = 1;
                                dblClosingQTY = 0;
                            }
                        }
                        dblClosingQTY = 0;
                    }

                    if (intCheckNegetive > 0)
                    {
                        MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                        DgRm.Focus();
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region "Save"
        private string mSaveMFGvoucher()
        {
            string strBranchId = "", strInsert = "", strUnit = "", strbatch = "", strDG = "", strRefNo = "", strNarrtion = "";
            double dblReceipeqty = 0, dblSampleFg = 1, dblSampleQC = 1;
            int intRow = 0, intVtype = 51;
            if (uctxtBatch.Text == Utility.gcEND_OF_LIST)
            {
                strbatch = "";
            }
            else
            {
                strbatch = uctxtBatch.Text;
            }
            if (uctxtNarration.Text == "")
            {
                strNarrtion = "";
            }
            else
            {
                strNarrtion = uctxtNarration.Text;
            }
            if (uctxtSampletoFg.Text != "")
            {
                dblSampleFg = Convert.ToDouble(uctxtSampletoFg.Text);
            }
            if (uctxtSampleToQC.Text != "")
            {
                dblSampleQC = Convert.ToDouble(uctxtSampleToQC.Text);
            }

            dblReceipeqty = Utility.mGetBatchSize(strComID, uctxtBatch.Text);
            strUnit = Utility.gGetBaseUOM(strComID, uctxtFgItem.Text.ToString());
            strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text); ;
            //strBranchIdTo = Utility.gstrGetBranchID(strComID, txtFgLocation.Text);
            strDG = uctxtFgItem.Text + "|" + txtFGQnty.Text + "|" + strUnit + "|" + Utility.Val(txtFgValue.Text.ToString()) + "|" + dblReceipeqty + "|" + 0 + "|" + "~";


            for (intRow = 0; intRow < DgRm.Rows.Count; intRow++)
            {
                if (DgRm[0, intRow].Value != null)
                {
                    strDG = strDG + Utility.gCheckNull(DgRm[0, intRow].Value.ToString()) + "|" + Utility.Val(DgRm[1, intRow].Value.ToString()) + "|"
                                            + Utility.gCheckNull(DgRm[2, intRow].Value.ToString()) + "|" + Utility.Val(DgRm[3, intRow].Value.ToStringNull()) + "|" +
                                            Utility.gCheckNull(DgRm[5, intRow].Value.ToString()) + "|" + 1 + "~";
                }

            }
            intRow = 0;
            for (intRow = 0; intRow < DgPm.Rows.Count; intRow++)
            {
                if (DgPm[0, intRow].Value != null)
                {
                    strDG = strDG + Utility.gCheckNull(DgPm[0, intRow].Value.ToString()) + "|" + Utility.Val(DgPm[1, intRow].Value.ToString()) + "|"
                                           + Utility.gCheckNull(DgPm[2, intRow].Value.ToString()) + "|" + Utility.Val(DgPm[3, intRow].Value.ToStringNull()) + "|" +
                                           Utility.gCheckNull(DgPm[5, intRow].Value.ToString()) + "|" + 2 + "~";
                }

            }
            intRow = 0;
            for (intRow = 0; intRow < DgWastageRm.Rows.Count; intRow++)
            {
                if (DgWastageRm[0, intRow].Value != null)
                {
                    strDG = strDG + Utility.gCheckNull(DgWastageRm[0, intRow].Value.ToString()) + "|" + Utility.Val(DgWastageRm[1, intRow].Value.ToString()) + "|"
                                            + Utility.gCheckNull(DgWastageRm[2, intRow].Value.ToString()) + "|" + Utility.Val(DgWastageRm[3, intRow].Value.ToStringNull()) + "|" +
                                            0 + "|" + 3 + "~";
                }
            }
            intRow = 0;
            for (intRow = 0; intRow < dgWastagePm.Rows.Count; intRow++)
            {
                if (dgWastagePm[0, intRow].Value != null)
                {
                    strDG = strDG + Utility.gCheckNull(dgWastagePm[0, intRow].Value.ToString()) + "|" + Utility.Val(dgWastagePm[1, intRow].Value.ToString()) + "|"
                                            + Utility.gCheckNull(dgWastagePm[2, intRow].Value.ToString()) + "|" + Utility.Val(dgWastagePm[3, intRow].Value.ToStringNull()) + "|" +
                                            0 + "|" + 4 + "~";
                }
            }

            try
            {
                if (mblnNumbMethod)
                {
                    strRefNo = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBranchId + Utility.gstrLastNumber(strComID, (int)intVtype);
                }
                else
                {
                    strRefNo = gobjVoucherName.VoucherName.GetVoucherString(intVtype) + strBranchId + Utility.gstrLastNumber(strComID, (int)intVtype);
                }

                strInsert = objWIS.mInsertProductionMfg(strComID, strRefNo, strbatch, strBranchId, uctxtLocation.Text.ToString(),
                                                                txtFgLocation.Text.ToString(), uctxtProcessName.Text, uctxtFgItem.Text, Utility.Val(txtFGQnty.Text.ToString()),
                                                                Utility.Val(txtFgValue.Text.ToString()), dteDate.Value.ToShortDateString(),
                                                                uctxtNarration.Text.ToString(), strDG, 0, dblSampleFg, dblSampleQC, strNarrtion);
                if (strInsert == "Inseretd...")
                {
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "MFG Production", uctxtProcessName.Text,
                                                                m_action, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                    }
                }

                return strInsert;
            }


            catch (Exception ex)
            {
                return (ex.ToString());
            }

        }
        private string mUpdatMFGvoucher()
        {
            string strBranchId = "", strInsert = "", strUnit = "", strbatch = "", strDG = "", strRefNo = "", strNarrtion="";
           double dblReceipeqty = 0, dblSampleFg = 1, dblSampleQC = 1;
           int intRow = 0, intVtype = 29;
           if (uctxtBatch.Text == Utility.gcEND_OF_LIST)
           {
               strbatch = "";
           }
           else
           {
               strbatch = uctxtBatch.Text;
           }
           if (uctxtNarration.Text == "")
           {
               strNarrtion = "";
           }
           else
           {
               strNarrtion = uctxtNarration.Text;
           }
           if (uctxtSampletoFg.Text != "")
           {
               dblSampleFg = Convert.ToDouble(uctxtSampletoFg.Text);
           }
           if (uctxtSampleToQC.Text != "")
           {
               dblSampleQC = Convert.ToDouble(uctxtSampleToQC.Text);
           }
            dblReceipeqty = Utility.mGetBatchSize(strComID, uctxtBatch.Text);
            strUnit = Utility.gGetBaseUOM(strComID, uctxtFgItem.Text.ToString());
            strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text); ;
            //strBranchIdTo = Utility.gstrGetBranchID(strComID, txtFgLocation.Text);
            strDG = uctxtFgItem.Text + "|" + txtFGQnty.Text + "|" + strUnit + "|" + Utility.Val(txtFgValue.Text.ToString()) + "|" + dblReceipeqty + "|" + 0 + "|" + "~";


            for (intRow = 0; intRow < DgRm.Rows.Count; intRow++)
            {
                if (DgRm[0, intRow].Value != null)
                {
                    strDG = strDG + Utility.gCheckNull(DgRm[0, intRow].Value.ToString()) + "|" + Utility.Val(DgRm[1, intRow].Value.ToString()) + "|"
                                            + Utility.gCheckNull(DgRm[2, intRow].Value.ToString()) + "|" + Utility.Val(DgRm[3, intRow].Value.ToStringNull()) + "|" +
                                            Utility.gCheckNull(DgRm[5, intRow].Value.ToString()) + "|" + 1 + "~";
                }

            }
            intRow = 0;
            for (intRow = 0; intRow < DgPm.Rows.Count; intRow++)
            {
                if (DgPm[0, intRow].Value != null)
                {
                    strDG = strDG + Utility.gCheckNull(DgPm[0, intRow].Value.ToString()) + "|" + Utility.Val(DgPm[1, intRow].Value.ToString()) + "|"
                                           + Utility.gCheckNull(DgPm[2, intRow].Value.ToString()) + "|" + Utility.Val(DgPm[3, intRow].Value.ToStringNull()) + "|" +
                                           Utility.gCheckNull(DgPm[5, intRow].Value.ToString()) + "|" + 2 + "~";
                }

            }
            intRow = 0;
            for (intRow = 0; intRow < DgWastageRm.Rows.Count; intRow++)
            {
                if (DgWastageRm[0, intRow].Value != null)
                {
                    strDG = strDG + Utility.gCheckNull(DgWastageRm[0, intRow].Value.ToString()) + "|" + Utility.Val(DgWastageRm[1, intRow].Value.ToString()) + "|"
                                            + Utility.gCheckNull(DgWastageRm[2, intRow].Value.ToString()) + "|" + Utility.Val(DgWastageRm[3, intRow].Value.ToStringNull()) + "|" +
                                            0 + "|" + 3 + "~";
                }
            }
            intRow = 0;
            for (intRow = 0; intRow < dgWastagePm.Rows.Count; intRow++)
            {
                if (dgWastagePm[0, intRow].Value != null)
                {
                    strDG = strDG + Utility.gCheckNull(dgWastagePm[0, intRow].Value.ToString()) + "|" + Utility.Val(dgWastagePm[1, intRow].Value.ToString()) + "|"
                                            + Utility.gCheckNull(dgWastagePm[2, intRow].Value.ToString()) + "|" + Utility.Val(dgWastagePm[3, intRow].Value.ToStringNull()) + "|" +
                                            0 + "|" + 4 + "~";
                }
            }

            try
            {
                
                strRefNo = textBox1.Text.Trim();
                strInsert = objWIS.mUpdateProductionMfg(strComID, strRefNo, strbatch, strBranchId, uctxtLocation.Text.ToString(),
                                                                txtFgLocation.Text.ToString(), uctxtProcessName.Text, uctxtFgItem.Text, Utility.Val(txtFGQnty.Text.ToString()),
                                                                Utility.Val(txtFgValue.Text.ToString()), dteDate.Value.ToShortDateString(),
                                                                uctxtNarration.Text.ToString(), strDG, 0, dblSampleFg, dblSampleQC, strNarrtion);
                if (strInsert == "Updated...")
                {
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "MFG Production", uctxtProcessName.Text,
                                                                m_action, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                    }
                }
                return strInsert;
            }


            catch (Exception ex)
            {
                return (ex.ToString());
            }

        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            uctxtBatch.Text = "";
            uctxtBranchName.Text = "";
            uctxtLocation.Text = "";
            uctxtVoucherNo.Text = "";
            uctxtBatch.Text = "";
            uctxtProcessName.Text = "";
            textBox1.Text = "";
            DgRm.Rows.Clear();
            DgWastageRm.Rows.Clear();
            DgPm.Rows.Clear();
            dgWastagePm.Rows.Clear();
            //txtFgLocation.Text = "";
            lblUnitPrice.Text = "0";
            txtRm.Text = "";
            lblRmAmount.Text = "0";
            lblPmAmount.Text = "0";
            uctxtSampleToQC.Text = "";
            uctxtSampletoFg.Text = "";
            lblWastageRmAmnt.Text = "0";
            lblWastagePmAmount.Text = "0";
            lblBatchSize.Text = "0";
            lblUsed.Text = "0";
            lblPending.Text = "0";
            txtFm.Text = "";
            uctxtNarration.Text = "";
            uctxtProcessName.Enabled = true;
            uctxtBatch.Enabled = true;
            //txtFgLocation.Text = "";
            txtWm.Text = "";
            uctxtFgItem.Text = "";
            txtFGQnty.Text = "";
            txtFgValue.Text = "";
            chkChangePm.Checked = false;
            chkChangeRm.Checked = false;
            chkPartial.Checked = false;
            if (Utility.gblnBranch == true)
            {
                uctxtBranchName.Enabled = true;
                uctxtLocation.Enabled = true;
            }
            else
            {
                uctxtBranchName.Enabled = false;
                uctxtLocation.Enabled = false;
                uctxtBranchName.Text = Utility.gstrBranchName;
                uctxtLocation.Text = "Main Location";
            }
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;

            if (mblnNumbMethod)
            {
                uctxtVoucherNo.Text = Utility.gstrLastNumber(strComID, (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_PRODUCTION);
                uctxtVoucherNo.ReadOnly = true;
                uctxtBatch.Focus();
                uctxtBatch.Select();
            }
            else
            {
                uctxtVoucherNo.ReadOnly = false;
                uctxtVoucherNo.Focus();
                uctxtVoucherNo.Select();
            }

        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields() == false)
            {
                return;
            }

            try
            {
                if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
                {
                    string strInsert = mSaveMFGvoucher();
                    if (strInsert == "Inseretd...")
                    {
                        mClear();
                    }
                    else
                    {
                        MessageBox.Show(strInsert);
                    }

                }
                else
                {
                    string strInsert = mUpdatMFGvoucher();
                    if (strInsert == "Updated...")
                    {
                        mClear();
                    }
                    else
                    {
                        MessageBox.Show(strInsert);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmMFGVoucherList objfrm = new frmMFGVoucherList();
            objfrm.onAddAllButtonClicked = new frmMFGVoucherList.AddAllClick(DisplayProcess);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = strFormName;
            objfrm.intConvert = 0;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }
        #endregion
        #region "Display"
        private void DisplayProcess(List<MFGvouhcer> tests, object sender, EventArgs e)
        {
            try
            {
                int intrm = 0, intPm = 0, intrmWastage = 0, intPmWastage = 0;
                double dblCostPercent = 0, dblCostFgQnt = 0, dblTotalBatchSize = 0, dblUsedBatchSize=0;
                dteDate.Focus();
               
                uctxtProcessName.Enabled = false;
                uctxtBatch.Enabled = false;
                lstBatch.Visible = false;
                uctxtBatch.Focus();

                //dteDate.Text = tests[0].strDate;
                //txtRm.Text = tests[0].strRMRefNo;
                //txtWm.Text = tests[0].strWmRefNo;
                //txtFm.Text = tests[0].strFgRefNo;
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;

                DgRm.Rows.Clear();
                DgPm.Rows.Clear();
                DgWastageRm.Rows.Clear();
                dgWastagePm.Rows.Clear();
                mdblAmount = 0;
                textBox1.Text = tests[0].strFgRefNo;
                dblTotalBatchSize = Utility.mGetBatchSize(strComID, tests[0].strBatch);
                dblUsedBatchSize = Utility.mGetBatchUsed(strComID, tests[0].strBatch);


                lblBatchSize.Text = "Batch Size: " + Utility.mGetBatchSize(strComID, tests[0].strBatch);
                lblPending.Text = "Pending: "  + Utility.mGetBatchUsed(strComID, tests[0].strBatch);
                lblUsed.Text = "Used: " + mGetSubstractValue(Utility.mGetBatchSize(strComID, tests[0].strBatch), Utility.mGetBatchUsed(strComID, tests[0].strBatch)).ToString();
                List<MFGvouhcer> oRm = objWIS.mDisplayProductionList(strComID, tests[0].strFgRefNo).ToList();
                {
                    if (oRm.Count > 0)
                    {
                        uctxtLocation.Text = oRm[0].strLocation;
                        uctxtVoucherNo.Text = Utility.Mid(oRm[0].strVoucherNo,6,oRm[0].strVoucherNo.Length -6);
                        if (tests[0].strBatch != "")
                        {
                            uctxtBatch.Text = oRm[0].strBatch;
                        }
                        else
                        {
                            uctxtBatch.Text = Utility.gcEND_OF_LIST;
                        }
                        uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, oRm[0].strBranchId);
                        uctxtLocation.Text = oRm[0].strLocation;
                        txtFgLocation.Text = oRm[0].strTLocation;
                        uctxtProcessName.Text = oRm[0].strProcess;
                        uctxtNarration.Text = oRm[0].strNarration;
                        uctxtSampletoFg.Text =oRm[0].dblSampleFG.ToString();
                        uctxtSampleToQC.Text = oRm[0].dblSampleQC.ToString();

                        foreach (MFGvouhcer ooRm in oRm)
                        {
                           
                            if (ooRm.intProcessType == 0)
                            {
                                dblCostFgQnt = Utility.Val(ooRm.strBatchSize);
                                dblCostPercent = 100;
                                uctxtFgItem.Text = ooRm.strItemName;
                                txtFGQnty.Text = ooRm.strBatchSize;
                                txtFgValue.Text = ooRm.dblAmount.ToString();
                            }
                            if (ooRm.intProcessType == 1)
                            {
                                DgRm.Rows.Add();
                                DgRm[0, intrm].Value = ooRm.strItemName;
                                DgRm[1, intrm].Value = ooRm.dblQnty + " " + ooRm.strUOM;
                                DgRm[2, intrm].Value = ooRm.strUOM;
                                //dblrate = Utility.gdblPurchasePrice(strComID, ts.stritemName, dteDate.Text);
                                DgRm[3, intrm].Value = Math.Round((ooRm.dblAmount), 4);
                                DgRm[4, intrm].Value = "Del.";
                                DgRm[5, intrm].Value = ooRm.dblQnty;
                                DgRm[6, intrm].Value = ooRm.strBillKey;
                                mdblAmount = mdblAmount + Math.Round(Utility.Val(DgRm[3, intrm].Value.ToString()), 4);
                                intrm += 1;
                            }
                            if (ooRm.intProcessType == 2)
                            {
                                DgPm.Rows.Add();
                                DgPm[0, intPm].Value = ooRm.strItemName;
                                DgPm[1, intPm].Value = ooRm.dblQnty + " " + ooRm.strUOM;
                                DgPm[2, intPm].Value = ooRm.strUOM;
                                //dblrate = Utility.gdblPurchasePrice(strComID, ts.stritemName, dteDate.Text);
                                DgPm[3, intPm].Value = Math.Round((ooRm.dblAmount), 4);
                                DgPm[4, intPm].Value = "Del.";
                                DgPm[5, intPm].Value = ooRm.dblQnty;
                                DgPm[6, intPm].Value = ooRm.strBillKey;
                                mdblAmount = mdblAmount + Math.Round(Utility.Val(DgPm[3, intPm].Value.ToString()), 4);
                                intPm += 1;
                            }
                            if (ooRm.intProcessType == 3)
                            {
                                DgWastageRm.Rows.Add();
                                DgWastageRm[0, intrmWastage].Value = ooRm.strItemName;
                                DgWastageRm[1, intrmWastage].Value = ooRm.dblQnty + " " + ooRm.strUOM;
                                DgWastageRm[2, intrmWastage].Value = ooRm.strUOM;
                                //dblrate = Utility.gdblPurchasePrice(strComID, ts.stritemName, dteDate.Text);
                                DgWastageRm[3, intrmWastage].Value = Math.Round((ooRm.dblAmount), 4);
                                DgWastageRm[4, intrmWastage].Value = "Del.";
                                //DgWastageRm[5, intrmWastage].Value = ooRm.dblQnty;
                                DgWastageRm[5, intrmWastage].Value = ooRm.strBillKey;
                                mdblAmount = mdblAmount + Math.Round(Utility.Val(DgWastageRm[3, intrmWastage].Value.ToString()), 4);
                                intrmWastage += 1;
                            }
                            if (ooRm.intProcessType == 4)
                            {
                                dgWastagePm.Rows.Add();
                                dgWastagePm[0, intPmWastage].Value = ooRm.strItemName;
                                dgWastagePm[1, intPmWastage].Value = ooRm.dblQnty + " " + ooRm.strUOM;
                                dgWastagePm[2, intPmWastage].Value = ooRm.strUOM;
                                //dblrate = Utility.gdblPurchasePrice(strComID, ts.stritemName, dteDate.Text);
                                dgWastagePm[3, intPmWastage].Value = Math.Round((ooRm.dblAmount), 4);
                                dgWastagePm[4, intPmWastage].Value = "Del.";
                                //dgWastagePm[5, intPmWastage].Value = ooRm.dblQnty;
                                dgWastagePm[5, intPmWastage].Value = ooRm.strBillKey;
                                mdblAmount = mdblAmount + Math.Round(Utility.Val(dgWastagePm[3, intPmWastage].Value.ToString()), 4);
                                intPmWastage += 1;
                            }
                            DgRm.AllowUserToAddRows = false;
                            DgWastageRm.AllowUserToAddRows = false;
                            DgPm.AllowUserToAddRows = false;
                            dgWastagePm.AllowUserToAddRows = false;




                            DgRm.AllowUserToAddRows = false;

                        }
                    }
                }

                if (mdblAmount != 0)
                {

                    lblUnitPrice.Text = "Unit Price of F. Goods: " + Math.Round((((mdblAmount / dblCostFgQnt) * dblCostPercent) / 100), 4).ToString();
                }
                calculateTotal();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion
        #region "SelectedIndex"
        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboYear.Text != "")
            //{
            //    mLoadMonthTree(cboYear.Text.ToString());
            //}
        }
        #endregion
        #region "ReeVuew"
        private void tvNode_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //uctxtProcessName.Text = tvNode.SelectedNode.Text;
            //DisplayProcess(tvNode.SelectedNode.Text);
            //uctxtProcessName.Enabled = false;
            uctxtBatch.Focus();
        }
        #endregion
        #region "Ceel Eidt"
        private void DgPm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            double dblQty = 0, dblrate = 0;
            if (e.ColumnIndex == 1)
            {
                dblQty = Convert.ToDouble(DgPm[1, e.RowIndex].Value);
                dblrate = Utility.gdblPurchasePrice(strComID, DgPm[0, e.RowIndex].Value.ToString(), dteDate.Text);
                DgPm[1, e.RowIndex].Value = DgPm[1, e.RowIndex].Value + " " + Utility.gGetBaseUOM(strComID, DgPm[0, e.RowIndex].Value.ToString());
                DgPm[3, e.RowIndex].Value = Math.Round(dblQty * dblrate, 4);
                calculateTotal();
            }
        }
        private void dgWastagePm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dblQty = 0, dblrate = 0;
            try
            {
                if (e.ColumnIndex == 1)
                {
                    dblQty = Convert.ToDouble(dgWastagePm[1, e.RowIndex].Value);
                    dblrate = Utility.gdblPurchasePrice(strComID, dgWastagePm[0, e.RowIndex].Value.ToString(), dteDate.Text);
                    dgWastagePm[1, e.RowIndex].Value = dgWastagePm[1, e.RowIndex].Value + " " + Utility.gGetBaseUOM(strComID, dgWastagePm[0, e.RowIndex].Value.ToString());
                    dgWastagePm[3, e.RowIndex].Value = Math.Round(dblQty * dblrate, 4);
                    calculateTotal();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void DgWastage_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dblQty = 0, dblrate = 0;
            try
            {
                if (e.ColumnIndex == 1)
                {
                    dblQty = Convert.ToDouble(DgWastageRm[1, e.RowIndex].Value);
                    dblrate = Utility.gdblPurchasePrice(strComID, DgWastageRm[0, e.RowIndex].Value.ToString(), dteDate.Text);
                    DgWastageRm[1, e.RowIndex].Value = DgWastageRm[1, e.RowIndex].Value + " " + Utility.gGetBaseUOM(strComID, DgWastageRm[0, e.RowIndex].Value.ToString());
                    DgWastageRm[3, e.RowIndex].Value = Math.Round(dblQty * dblrate, 4);
                    calculateTotal();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DgRm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dblQty = 0, dblrate=0;
            try
            {
                if (e.ColumnIndex == 1)
                {
                    dblQty = Convert.ToDouble(DgRm[1, e.RowIndex].Value);
                    dblrate = Utility.gdblPurchasePrice(strComID, DgRm[0, e.RowIndex].Value.ToString(), dteDate.Text);
                    DgRm[1, e.RowIndex].Value = DgRm[1, e.RowIndex].Value + " " + Utility.gGetBaseUOM(strComID, DgRm[0, e.RowIndex].Value.ToString());
                    DgRm[3, e.RowIndex].Value = Math.Round(dblQty * dblrate, 4);
                    calculateTotal();
                }
            }
            catch (Exception ex)
                {

                }


        }
        private void mDisplayReceipeChangeRM(int intType)
        {
            double dblfgQnty = 0, dblFgEdit = 0, dblrate = 0, dblRmAmount = 0, dblPmAmount = 0, dblUnitPrice,dblRMSchangeSize=0;
            string strUnit = "";
            int intrm = 0, intPm = 0;
           
            dblfgQnty = Utility.mGetBatchSize(strComID, uctxtBatch.Text);
            dblFgEdit = Utility.Val(txtFGQnty.Text);
            dblRMSchangeSize = Utility.mGetBatchUsed(strComID, uctxtBatch.Text);
            if (dblfgQnty == dblRMSchangeSize)
            {
                dblFgEdit = Utility.Val(txtFGQnty.Text);
            }
            else
            {
                dblFgEdit = dblRMSchangeSize;
            }
            if (chkChangeRm.Checked ==true && chkPartial.Checked==true)
            {
                dblFgEdit = Utility.Val(txtFGQnty.Text);
            }
            foreach (ManuProcess ts1 in ooItem)
            {
                strUnit = Utility.gGetBaseUOM(strComID, ts1.stritemName).ToString();

                if (ts1.intType == 1)
                {
                    if (chkChangeRm.Checked == true)
                    {
                        dblrate = 0;
                        //dblrate = Utility.gdblPurchasePrice(strComID, ts1.stritemName, dteDate.Text);
                        dblrate = Utility.gdblGetCostPriceNew(strComID, ts1.stritemName, dteDate.Text);
                        DgRm[1, intrm].Value = Math.Round(Utility.Val(ts1.dblqnty.ToString()) * (dblFgEdit / dblfgQnty), 4) + " " + strUnit;

                        DgRm[3, intrm].Value = Math.Round((Utility.Val(DgRm[1, intrm].Value.ToString()) * dblrate), 4);
                        dblRmAmount = dblRmAmount + Utility.Val(DgRm[3, intrm].Value.ToString());
                        DgRm[5, intrm].Value = Utility.Val(DgRm[1, intrm].Value.ToString());
                        intrm += 1;
                    }
                    else
                    {
                        if (intType ==1)
                        {
                            dblrate = 0;
                            //dblrate = Utility.gdblPurchasePrice(strComID, ts1.stritemName, dteDate.Text);
                            dblrate = Utility.gdblGetCostPriceNew(strComID, ts1.stritemName, dteDate.Text);
                            DgRm[1, intrm].Value = Math.Round(Utility.Val(ts1.dblqnty.ToString()) * (dblFgEdit / dblfgQnty), 4) + " " + strUnit;

                            DgRm[3, intrm].Value = Math.Round((Utility.Val(DgRm[1, intrm].Value.ToString()) * dblrate), 4);
                            dblRmAmount = dblRmAmount + Utility.Val(DgRm[3, intrm].Value.ToString());
                            DgRm[5, intrm].Value = Utility.Val(DgRm[1, intrm].Value.ToString());
                            intrm += 1;
                        }
                    }
                }
                DgRm.AllowUserToAddRows = false;
                //if (ts1.intType == 2)
                //{
                //    if (chkChangePm.Checked == true)
                //    {
                //        dblrate = 0;
                //        dblrate = Utility.gdblPurchasePrice(strComID, ts1.stritemName, dteDate.Text);
                //        DgPm[1, intPm].Value = Math.Round(Utility.Val(Math.Round(ts1.dblqnty).ToString()) * (dblFgEdit / dblfgQnty), 0) + " " + strUnit;

                //        DgPm[3, intPm].Value = Math.Round((Utility.Val(DgPm[1, intPm].Value.ToString()) * dblrate), 4);
                //        dblPmAmount = dblPmAmount + Utility.Val(DgPm[3, intPm].Value.ToString());
                //        //DgPm[5, intPm].Value = Utility.Val(DgPm[1, intPm].Value.ToString());
                //        intPm += 1;
                //    }
                //}
                dblPmAmount = Utility.Val(lblPmAmount.Text);
            }

            if (DgRm.Rows.Count > 0)
            {

                txtFgValue.Text = (Math.Round(dblRmAmount + dblPmAmount, 2)).ToString();
                dblUnitPrice = (dblRmAmount + dblPmAmount) / dblfgQnty;
                if (chkChangePm.Checked == true || chkChangeRm.Checked == true)
                {
                    lblUnitPrice.Text = "Unit Price of F. Goods: " + Math.Round(dblUnitPrice, 2).ToString();
                }
            }
            calculateTotal();
        }
        private void mDisplayReceipeChangeFG()
        {
            double dblfgQnty = 0, dblFgEdit = 0, dblrate = 0, dblRmAmount = 0, dblPmAmount = 0, dblUnitPrice, dblRMSchangeSize = 0;
            string strUnit = "";
            int intrm = 0, intPm = 0;
            dblfgQnty = Utility.mGetBatchSize(strComID, uctxtBatch.Text);
            dblFgEdit = Utility.Val(txtFGQnty.Text);
            dblRMSchangeSize = Utility.mGetBatchUsed(strComID, uctxtBatch.Text);
            //if (dblfgQnty == dblRMSchangeSize)
            //{
            //    dblFgEdit = Utility.Val(txtFGQnty.Text);
            //}
            //else
            //{
            dblFgEdit = dblRMSchangeSize;
            //}
            if (dblFgEdit==0)
            {
                MessageBox.Show("Batch Size Not Found");
                uctxtBatch.Focus();
                return;
            }
            foreach (ManuProcess ts1 in ooItem)
            {
                strUnit = Utility.gGetBaseUOM(strComID, ts1.stritemName).ToString();

                if (ts1.intType == 1)
                {
                    //if (chkChangeRm.Checked == true)
                    //{
                        dblrate = 0;
                        //dblrate = Utility.gdblPurchasePrice(strComID, ts1.stritemName, dteDate.Text);
                        dblrate = Utility.gdblGetCostPriceNew(strComID, ts1.stritemName, dteDate.Text);
                        DgRm[1, intrm].Value = Math.Round(Utility.Val(ts1.dblqnty.ToString()) * (dblFgEdit / dblfgQnty), 4) + " " + strUnit;

                        DgRm[3, intrm].Value = Math.Round((Utility.Val(DgRm[1, intrm].Value.ToString()) * dblrate), 4);
                        dblRmAmount = dblRmAmount + Utility.Val(DgRm[3, intrm].Value.ToString());
                        //DgRm[5, intrm].Value = Utility.Val(DgRm[1, intrm].Value.ToString());
                        intrm += 1;
                    //}
                }
                if (ts1.intType == 2)
                {
                    //if (chkChangePm.Checked == true)
                    //{
                        dblrate = 0;
                        //dblrate = Utility.gdblPurchasePrice(strComID, ts1.stritemName, dteDate.Text);
                        dblrate = Utility.gdblGetCostPriceNew(strComID, ts1.stritemName, dteDate.Text);
                        DgPm[1, intPm].Value = Math.Round(Utility.Val(Math.Round(ts1.dblqnty).ToString()) * (dblFgEdit / dblfgQnty), 0) + " " + strUnit;

                        DgPm[3, intPm].Value = Math.Round((Utility.Val(DgPm[1, intPm].Value.ToString()) * dblrate), 4);
                        dblPmAmount = dblPmAmount + Utility.Val(DgPm[3, intPm].Value.ToString());
                        //DgPm[5, intPm].Value = Utility.Val(DgPm[1, intPm].Value.ToString());
                        intPm += 1;
                    //}
                }
                
            }

            if (DgRm.Rows.Count > 0)
            {

                txtFgValue.Text = (Math.Round(dblRmAmount + dblPmAmount, 2)).ToString();
                dblUnitPrice = (dblRmAmount + dblPmAmount) / dblfgQnty;
                if (chkChangePm.Checked == true || chkChangeRm.Checked == true)
                {
                    lblUnitPrice.Text = "Unit Price of F. Goods: " + Math.Round(dblUnitPrice, 2).ToString();
                }
            }
            calculateTotal();
        }
        private void mDisplayReceipeChangePM(int intType)
        {
            double dblfgQnty = 0, dblFgEdit = 0, dblrate = 0, dblRmAmount = 0, dblPmAmount = 0, dblUnitPrice, dblRMSchangeSize = 0;
            string strUnit = "";
            int intrm = 0, intPm = 0;
            
            dblfgQnty = Utility.mGetBatchSize(strComID, uctxtBatch.Text);
            dblFgEdit = Utility.Val(txtFGQnty.Text);
            dblRMSchangeSize = Utility.mGetBatchUsed(strComID, uctxtBatch.Text);
            ////if (dblfgQnty == dblRMSchangeSize)
            ////{
            ////    dblFgEdit = Utility.Val(txtFGQnty.Text);
            ////}
            ////else
            ////{
            ////    dblFgEdit = dblRMSchangeSize;
            ////}
            foreach (ManuProcess ts1 in ooItem)
            {
                strUnit = Utility.gGetBaseUOM(strComID, ts1.stritemName).ToString();

                //if (ts1.intType == 1)
                //{
                //    if (chkChangeRm.Checked == true)
                //    {
                //        dblrate = 0;
                //        dblrate = Utility.gdblPurchasePrice(strComID, ts1.stritemName, dteDate.Text);
                //        DgRm[1, intrm].Value = Math.Round(Utility.Val(ts1.dblqnty.ToString()) * (dblFgEdit / dblfgQnty), 4) + " " + strUnit;

                //        DgRm[3, intrm].Value = Math.Round((Utility.Val(DgRm[1, intrm].Value.ToString()) * dblrate), 4);
                //        dblRmAmount = dblRmAmount + Utility.Val(DgRm[3, intrm].Value.ToString());
                //        //DgRm[5, intrm].Value = Utility.Val(DgRm[1, intrm].Value.ToString());
                //        intrm += 1;
                //    }
                //}
                if (ts1.intType == 2)
                {
                    if (chkChangePm.Checked == true)
                    {
                        dblrate = 0;
                        //dblrate = Utility.gdblPurchasePrice(strComID, ts1.stritemName, dteDate.Text);
                        dblrate = Utility.gdblGetCostPriceNew(strComID, ts1.stritemName, dteDate.Text);
                        DgPm[1, intPm].Value = Math.Round(Utility.Val(Math.Round(ts1.dblqnty).ToString()) * (dblFgEdit / dblfgQnty), 0) + " " + strUnit;

                        DgPm[3, intPm].Value = Math.Round((Utility.Val(DgPm[1, intPm].Value.ToString()) * dblrate), 4);
                        dblPmAmount = dblPmAmount + Utility.Val(DgPm[3, intPm].Value.ToString());
                        //DgPm[5, intPm].Value = Utility.Val(DgPm[1, intPm].Value.ToString());
                        intPm += 1;
                    }
                    else
                    {
                        if (intType==1)
                        {
                            dblrate = 0;
                            //dblrate = Utility.gdblPurchasePrice(strComID, ts1.stritemName, dteDate.Text);
                            dblrate = Utility.gdblGetCostPriceNew(strComID, ts1.stritemName, dteDate.Text);
                            DgPm[1, intPm].Value = Math.Round(Utility.Val(Math.Round(ts1.dblqnty).ToString()) * (dblFgEdit / dblfgQnty), 0) + " " + strUnit;

                            DgPm[3, intPm].Value = Math.Round((Utility.Val(DgPm[1, intPm].Value.ToString()) * dblrate), 4);
                            dblPmAmount = dblPmAmount + Utility.Val(DgPm[3, intPm].Value.ToString());
                            //DgPm[5, intPm].Value = Utility.Val(DgPm[1, intPm].Value.ToString());
                            intPm += 1;
                        }
                    
                    }

                }
                dblRmAmount = Utility.Val(lblRmAmount.Text);
            }

            if (DgRm.Rows.Count > 0)
            {

                txtFgValue.Text = (Math.Round(dblRmAmount + dblPmAmount, 2)).ToString();
                dblUnitPrice = (dblRmAmount + dblPmAmount) / dblfgQnty;
                if (chkChangePm.Checked == true || chkChangeRm.Checked == true)
                {
                    lblUnitPrice.Text = "Unit Price of F. Goods: " + Math.Round(dblUnitPrice, 2).ToString();
                }
            }
            calculateTotal();
        }
        private void DgFG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dblfgQnty = 0, dblFgEdit = 0, dblrate = 0, dblRmAmount = 0, dblWastageAmount = 0, dblUnitPrice;

            int intrm = 0, intfg = 0, intwastage = 0;
            if (e.ColumnIndex == 1)
            {
                foreach (ManuProcess ts in ooItem)
                {
                    if (ts.intType == 2)
                    {
                        dblfgQnty = ts.dblqnty;
                        intfg += 1;
                        foreach (ManuProcess ts1 in ooItem)
                        {
                            if (ts1.intType == 1)
                            {
                                //dblrate = Utility.gdblPurchasePrice(strComID, ts1.stritemName, dteDate.Text);
                                dblrate = Utility.gdblGetCostPriceNew(strComID, ts1.stritemName, dteDate.Text);
                                DgRm[1, intrm].Value = Math.Round(Utility.Val(ts1.dblqnty.ToString()) * (dblFgEdit / dblfgQnty), 4);
                                DgRm[3, intrm].Value = Math.Round((Utility.Val(DgRm[1, intrm].Value.ToString()) * dblrate), 4);
                                dblRmAmount = dblRmAmount + Utility.Val(DgRm[3, intrm].Value.ToString());
                                intrm += 1;
                            }
                            if (ts1.intType == 3)
                            {
                                //dblrate = Utility.gdblPurchasePrice(strComID, ts1.stritemName, dteDate.Text);
                                dblrate = Utility.gdblGetCostPriceNew(strComID, ts1.stritemName, dteDate.Text);
                                dblWastageAmount = dblWastageAmount + Math.Round((Utility.Val(DgWastageRm[1, intwastage].Value.ToString()) * dblrate), 3);
                                intwastage += 1;
                            }
                        }

                    }
                }
            }
            if (DgRm.Rows.Count > 0)
            {
                dblUnitPrice = (dblRmAmount + dblWastageAmount) / Utility.Val(txtFGQnty.Text);
                lblUnitPrice.Text = "Unit Price of F. Goods: " + Math.Round(dblUnitPrice, 4).ToString();
            }
            calculateTotal();

        }
        #endregion
        #region "Click"
        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            frmMFGVoucherTreeview objfrm = new frmMFGVoucherTreeview();
            objfrm.strYear = cboYear.Text;
            objfrm.intConvertFg = 0;
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }
        #endregion

        private void txtFGQnty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Return)
                {
                    uctxtSampletoFg.Focus();
                    mDisplayReceipeChangeFG();
                  
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }
        private void chkPartial_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFGQnty.Text != "")
                {
                    if (chkPartial.Checked)
                    {

                        if (ooItem.Count > 0)
                        {
                            ooItem.Clear();
                        }
                        ooItem = invms.mDisplayProcess(strComID, uctxtProcessName.Text, "").ToList();
                        mDisplayReceipeChangeRM(0);
                    }
                    else
                    {
                        //DisplayProcess(uctxtProcessName.Text);

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void chkChangeRm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFGQnty.Text != "")
                {
                    if (chkChangeRm.Checked)
                    {
                       
                        if (ooItem.Count > 0)
                        {
                            ooItem.Clear();
                        }
                        ooItem = invms.mDisplayProcess(strComID, uctxtProcessName.Text,"").ToList();
                        mDisplayReceipeChangeRM(0);
                    }
                    else
                    {
                        //DisplayProcess(uctxtProcessName.Text);
                       
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void chkChangePm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFGQnty.Text != "")
                {
                    if (chkChangePm.Checked == true)
                    {
                       
                        if (ooItem.Count > 0)
                        {
                            ooItem.Clear();
                        }
                        ooItem = invms.mDisplayProcess(strComID, uctxtProcessName.Text,"").ToList();
                        mDisplayReceipeChangePM(0);
                    }
                    else
                    {
                        //DisplayProcess(uctxtProcessName.Text);
                        //mDisplayReceipeChangePM();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void lblUsed_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmAllReferance"] as frmAllReferance == null)
            {
                frmAllReferance objfrm = new frmAllReferance();
                objfrm.lngVtype = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_PRODUCTION;
                objfrm.strPartyname = uctxtBatch.Text;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmAllReferance objfrm = (frmAllReferance)Application.OpenForms["frmAllReferance"];
                objfrm.lngVtype = (int)Utility.VOUCHER_TYPE.vtSTOCK_MFG_PRODUCTION; 
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

       

    }
}
