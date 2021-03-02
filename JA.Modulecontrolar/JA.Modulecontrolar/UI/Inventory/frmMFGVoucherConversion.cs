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
    public partial class frmMFGVoucherConversion : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWIS = new SPWOIS();
        public int m_action { get; set; }
        public int intvType { get; set; }
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstProcess = new ListBox();
        private ListBox lstBatch = new ListBox();
        private ListBox lstFgLocation = new ListBox();
        private bool mblnNumbMethod { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        private int mintIsPrin { get; set; }
        private double  mdblAmount {get;set;}
        List<InvoiceConfig> oinv;
        List<ManuProcess> ooItem;
        List<StockItem> oogrp;
        List<StockItem> ooRm_WAS;
        private const string mcGROUP_PREFIX = "G_";
        private const string mcLEDGER_PREFIX = "L_";
        private string strComID { get; set; }
        public frmMFGVoucherConversion()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User IN"
            this.uctxtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtVoucherNo_KeyPress);
            this.uctxtVoucherNo.GotFocus += new System.EventHandler(this.uctxtVoucherNo_GotFocus);
            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);
            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);

            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.dteDate_GotFocus);

            this.uctxtFgItem.KeyDown += new KeyEventHandler(uctxtFgItem_KeyDown);
            this.uctxtFgItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFgItem_KeyPress);
            this.uctxtFgItem.GotFocus += new System.EventHandler(this.uctxtFgItem_GotFocus);

            this.ucFG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ucFG_KeyPress);
            this.ucFG.DoubleClick += new System.EventHandler(this.ucFG_DoubleClick);

            this.uctxtConsumption.KeyDown += new KeyEventHandler(uctxtConsumption_KeyDown);
            this.uctxtConsumption.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtConsumption_KeyPress);
            this.uctxtConsumption.GotFocus += new System.EventHandler(this.uctxtConsumption_GotFocus);

            this.ucConsumption.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ucConsumption_KeyPress);
            this.ucConsumption.DoubleClick += new System.EventHandler(this.ucConsumption_DoubleClick);


            this.uctxtWastage.KeyDown += new KeyEventHandler(uctxtWastage_KeyDown);
            this.uctxtWastage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtWastage_KeyPress);
            this.uctxtWastage.GotFocus += new System.EventHandler(this.uctxtWastage_GotFocus);

            this.uclstWastage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uclstWastage_KeyPress);
            this.uclstWastage.DoubleClick += new System.EventHandler(this.uclstWastage_DoubleClick);

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

            this.DgFG.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgFG_CellEndEdit);
            this.DgRm.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgRm_CellEndEdit);

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

            this.ucFG.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ucFG_CellFormatting);
            this.ucConsumption.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ucConsumption_CellFormatting);
            this.uclstWastage.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstWastage_CellFormatting);
            this.btnDashBoard.Click += new System.EventHandler(this.btnDashBoard_Click);

            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            Utility.CreateListBox(lstProcess, pnlMain, uctxtProcessName);
            Utility.CreateListBox(lstBatch, pnlMain, uctxtBatch);
            Utility.CreateListBox(lstFgLocation, pnlMain, txtFgLocation);
            #endregion

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
        #region "DisplayProcess"
        private void DisplayProcess(string vstrProcess)
        {
            double dblrate = 0, dblCostPercent = 0, dblCostFgQnt=0,dblLastFGQnty = 0;
            try
            {
                int intrm = 0, intfg = 0, intwastage = 0;
                
                uctxtProcessName.Focus();
                DgFG.Rows.Clear();
                DgRm.Rows.Clear();
                DgWastage.Rows.Clear();
                mdblAmount = 0;
                ooItem = invms.mDisplayProcess(strComID, vstrProcess,"P").ToList();
                if (ooItem.Count > 0)
                {
                    //uctxtProcessName.Text = tests[0].strProcessName;
                    foreach (ManuProcess ts in ooItem)
                    {
                        if (ts.intType == 1)
                        {
                            DgRm.Rows.Add();
                            DgRm[0, intrm].Value = ts.stritemName;
                            DgRm[1, intrm].Value = ts.dblqnty;
                            DgRm[2, intrm].Value = ts.strUnit;
                            //dblrate = Utility.gdblGetCostPriceWeightAvg(strComID, ts.stritemName, dteDate.Text);
                            dblrate = Utility.gdblGetCostPriceNew(strComID, ts.stritemName, dteDate.Text);
                            DgRm[3, intrm].Value = Math.Round( (ts.dblqnty * dblrate ),3);
                            DgRm[4, intrm].Value = "Delete";
                            mdblAmount = mdblAmount + Math.Round(Utility.Val(DgRm[3, intrm].Value.ToString()),3);
                            intrm += 1;
                            DgRm.AllowUserToAddRows = false;
                        }
                        if (ts.intType == 3)
                        {
                            DgWastage.Rows.Add();
                            DgWastage[0, intwastage].Value = ts.stritemName;
                            DgWastage[1, intwastage].Value = ts.dblqnty;
                            DgWastage[2, intwastage].Value = ts.strUnit;
                            //dblrate = Utility.gdblGetCostPriceWeightAvg(strComID, ts.stritemName, dteDate.Text);
                            dblrate = Utility.gdblGetCostPriceNew(strComID, ts.stritemName, dteDate.Text);
                            DgWastage[3, intwastage].Value = (ts.dblqnty * dblrate);
                            DgWastage[4, intwastage].Value = "Delete";
                            mdblAmount = mdblAmount + Math.Round(Utility.Val(DgWastage[3, intwastage].Value.ToString()),3);
                            intwastage += 1;
                            DgWastage.AllowUserToAddRows = false;
                        }
                        if (ts.intType == 2)
                        {
                            DgFG.Rows.Add();
                            DgFG[0, intfg].Value = ts.stritemName;
                            DgFG[1, intfg].Value = ts.dblqnty;
                            DgFG[2, intfg].Value = ts.strUnit;
                            //DgFG[3, intwastage].Value = ts.dblCostPrice;
                            DgFG[5, intfg].Value = "Delete";
                           
                            dblCostFgQnt = dblCostFgQnt + ts.dblqnty;
                            //dblrate = Utility.gdblGetCostPriceWeightAvg(strComID, ts.stritemName, dteDate.Text);
                            dblrate = Utility.gdblGetCostPriceNew(strComID, ts.stritemName, dteDate.Text);
                            dblLastFGQnty = ts.dblqnty;
                            if (ts.dblCostPercent >0)
                            {
                                if (intfg == 0)
                                {
                                    DgFG[3, intfg].Value = Math.Round(((mdblAmount * ts.dblCostPercent) / 100), 3).ToString();
                                }
                                else
                                {
                                    //DgFG[3, intfg].Value = Math.Round(((ts.dblqnty * dblrate)), 3).ToString();
                                    DgFG[3, intfg].Value = 0;
                                    ts.dblCostPercent = 0;
                                }
                            }
                            else
                            {
                                DgFG[3, intfg].Value = mdblAmount;
                            }
                            dblCostPercent = dblCostPercent + ts.dblCostPercent;
                            DgFG[4, intfg].Value = ts.dblCostPercent;
                            intfg += 1;
                            DgFG.AllowUserToAddRows = false;
                        }
                    }

                }
                if (mdblAmount !=0)
                {
                    if (dblCostPercent > 0)
                    {
                        //lblUnitPrice.Text = "Unit Price of F. Goods: " + Environment.NewLine  + Math.Round((((mdblAmount / dblCostFgQnt) * dblCostPercent) / 100),4).ToString();
                        lblUnitPrice.Text = "Unit Price of F. Goods: " + Environment.NewLine + Math.Round((((mdblAmount / dblLastFGQnty) * dblCostPercent) / 100), 4).ToString();
                    }
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
            double dblqntc = 0, dblqncAmount = 0, dblQntW=0,dblAmntW=0;
           
            for (int i = 0; i < DgRm.Rows.Count; i++)
            {
                dblqntc = dblqntc + Utility.Val (DgRm.Rows[i].Cells[1].Value.ToString());
                dblqncAmount = dblqncAmount + Utility.Val (DgRm.Rows[i].Cells[3].Value.ToString());
            }
            for (int i = 0; i < DgWastage.Rows.Count; i++)
            {
               dblQntW = dblQntW + Utility.Val (DgRm.Rows[i].Cells[1].Value.ToString());
                dblAmntW = dblAmntW + Utility.Val (DgRm.Rows[i].Cells[3].Value.ToString());
            }
            lblQntC.Text = "Total Qnty: " + Environment.NewLine + dblqntc;
            lblTCamount.Text = "Total Amount: " + Environment.NewLine + dblqncAmount;

            lblWqnt.Text = "Total Qnty: " + Environment.NewLine + dblQntW;
            lblwAmount.Text = "Total Amount: " + Environment.NewLine + dblAmntW;
            
        }
        #endregion
         #region "User Define"
        private void uclstWastage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            uclstWastage.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            uclstWastage.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            uclstWastage.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void ucConsumption_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ucConsumption.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            ucConsumption.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            ucConsumption.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void ucFG_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ucFG.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            ucFG.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            ucFG.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
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
            ucConsumption.Visible = false;
            ucFG.Visible = false;
            lstFgLocation.Visible = false;
            uclstWastage.Visible = false;
        }
        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            ucConsumption.Visible = false;
            ucFG.Visible = false;
            lstFgLocation.Visible = false;
            uclstWastage.Visible = false;
        }
        private void txtFgLocation_TextChanged(object sender, EventArgs e)
        {
            lstFgLocation.SelectedIndex = lstFgLocation.FindString(txtFgLocation.Text);
        }

        private void lstFgLocation_DoubleClick(object sender, EventArgs e)
        {
            txtFgLocation.Text = lstFgLocation.Text;
            mLoadAllItemFG();
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
                    mLoadAllItemFG();
                }
                if (uctxtProcessName.Enabled)
                {
                    uctxtProcessName.Focus();
                }
                else
                {
                    uctxtNarration.Focus();
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


        private void txtFgLocation_GotFocus(object sender, System.EventArgs e)
        {

            lstBatch.Visible = false;
            lstLocation.Visible = false;
            lstBranchName.Visible = false;
            lstProcess.Visible = false;
            ucConsumption.Visible = false;
            ucFG.Visible = false;
            lstFgLocation.Visible = true;
            uclstWastage.Visible = false;
            if (uctxtBranchName.Text != "")
            {
                lstFgLocation.ValueMember = "strLocation";
                lstFgLocation.DisplayMember = "strLocation";
                lstFgLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName,2).ToList();
            }
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
            uctxtBatch.Text = lstBatch.Text;
            if (Utility.gstrUserName.ToUpper() == "DEEPLAID")
            {
                dteDate.Enabled = true;
                dteDate.Focus();
            }
            else
            {

                uctxtBranchName.Select();
            }
        }

        private void uctxtBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBatch.Items.Count > 0)
                {
                    uctxtBatch.Text = lstBatch.Text;
                }

                if (Utility.gstrUserName.ToUpper() == "DEEPLAID")
                {
                    dteDate.Enabled = true;
                    dteDate.Focus();
                }
                else
                {

                    uctxtBranchName.Select();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBatch, sender, e);
            }

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
            ucConsumption.Visible = false;
            ucFG.Visible = false;
            uclstWastage.Visible = false;
            lstFgLocation.Visible = false;
            lstBatch.SelectedIndex = lstBatch.FindString(uctxtBatch.Text);
        }
        private void DisplayFgQty(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {

                uctxtFgItem.Text = tests[0].strItemName;


            }
            catch (Exception ex)
            {

            }
        }
        private void DisplayRawQty(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {

                uctxtConsumption.Text = tests[0].strItemName;


            }
            catch (Exception ex)
            {

            }
        }
        private void DisplayWastageQty(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {

                uctxtWastage.Text = tests[0].strItemName;


            }
            catch (Exception ex)
            {

            }
        }
        private void uctxtFgItem_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F3)
            //{
            //    frmAllItem objfrm = new frmAllItem();
            //    objfrm.MdiParent = MdiParent;
            //    objfrm.mloadType = 1;
            //    objfrm.onAddAllButtonClicked = new frmAllItem.AddAllClick(DisplayFgQty);
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;


            //}
            ucFG.Visible = true;
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
            if (e.KeyCode == Keys.Up)
            {
                ucFG.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                ucFG.Focus();
            }

            ucFG.Top = uctxtFgItem.Top + 25;
            ucFG.Left = uctxtFgItem.Left;
            ucFG.Width = uctxtFgItem.Width;
            ucFG.Height = 150;
            //ucdgList.Size = new Size(546, 222);
            ucFG.BringToFront();
            ucFG.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }
        private void uctxtConsumption_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F3)
            //{
            //    frmAllItem objfrm = new frmAllItem();
            //    objfrm.MdiParent = MdiParent;
            //    objfrm.mloadType = 1;
            //    objfrm.onAddAllButtonClicked = new frmAllItem.AddAllClick(DisplayRawQty);
            //    objfrm.Show();
            //    objfrm.MdiParent = this.MdiParent;
            //}
            ucConsumption.Visible = true;
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
            if (e.KeyCode == Keys.Up)
            {
                ucConsumption.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                ucConsumption.Focus();
            }

            ucConsumption.Top = uctxtConsumption.Top + 25;
            ucConsumption.Left = uctxtConsumption.Left;
            ucConsumption.Width = uctxtConsumption.Width;
            ucConsumption.Height = 150;
            //ucdgList.Size = new Size(546, 222);
            ucConsumption.BringToFront();
            ucConsumption.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }
        private void uctxtWastage_KeyDown(object sender, KeyEventArgs e)
        {
            uclstWastage.Visible = true;
            //txtFoodCode.Text = "";
            //txtFoodName.Text = "";
            if (e.KeyCode == Keys.Up)
            {
                uclstWastage.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                uclstWastage.Focus();
            }

            uclstWastage.Top = uctxtWastage.Top + 25;
            uclstWastage.Left = uctxtWastage.Left;
            uclstWastage.Width = uctxtWastage.Width;
            uclstWastage.Height = 150;
            //ucdgList.Size = new Size(546, 222);
            uclstWastage.BringToFront();
            uclstWastage.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;


        }
        private void mAddStockItem(DataGridView dg, string strItemName, double dblQty)
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
                dg[0, selRaw].Value = strItemName.ToString();
                dg[1, selRaw].Value = dblQty;
                dg[2, selRaw].Value = Utility.gGetBaseUOM(strComID, strItemName.ToString());
                //dg[3, selRaw].Value = Utility.gGetBaseUOM(strItemName.ToString());
                dg.AllowUserToAddRows = false;
                // calculateTotal();
            }

        }
      

        private void uctxtWastage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtWastage.Text == "")
                {
                    //txtItemCode.Text = "";
                    uctxtWastage.Text = "";
                    uclstWastage.Visible = false;
                    btnSave.Focus();
                    return;
                }


                if (uctxtWastage.Text != "")
                {
                    uclstWastage.Focus();
                    if (uclstWastage.Rows.Count > 0)
                    {
                        int i = 0;

                        uctxtWastage.Text = uclstWastage.Rows[i].Cells[0].Value.ToString();
                        mAddStockItem(DgWastage, uctxtWastage.Text, 1);
                        uclstWastage.Visible = false;
                        uctxtWastage.Text = "";
                        uclstWastage.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtWastage.Text = uclstWastage.Rows[i].Cells[0].Value.ToString();
                    uclstWastage.Visible = false;
                    btnSave.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtWastage, sender, e);
            }
        }
        private void uctxtWastage_GotFocus(object sender, System.EventArgs e)
        {
            lstProcess.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstFgLocation.Visible = false;
            lstBatch.Visible = false;
            ucConsumption.Visible = false;
            ucFG.Visible = false;
            uclstWastage.Visible = false;
            //mloadNotInGroup("Finished Goods",uclstWastage);
        }
        private void uclstWastage_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (uclstWastage.SelectedRows.Count > 0)
            {
                uctxtWastage.Text = Utility.GetDgValue(uclstWastage, uctxtWastage, 0);
                mAddStockItem(DgWastage, uctxtWastage.Text, 1);
                uclstWastage.Visible = false;
                uctxtWastage.Text = "";
                uctxtWastage.Focus();


            }
        }
        private void uclstWastage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtWastage.Text = Utility.GetDgValue(uclstWastage, uctxtWastage, 0);
                mAddStockItem(DgWastage, uctxtWastage.Text, 1);
                uclstWastage.Visible = false;
                uctxtWastage.Text = "";
                uctxtWastage.Focus();
            }
        }
        private void uctxtConsumption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtConsumption.Text == "")
                {
                    uctxtConsumption.Text = "";
                    ucConsumption.Visible = false;
                    uctxtWastage.Focus();
                    return;
                }


                if (uctxtConsumption.Text != "")
                {
                    ucConsumption.Focus();
                    if (ucConsumption.Rows.Count > 0)
                    {
                        int i = 0;

                        uctxtConsumption.Text = ucConsumption.Rows[i].Cells[0].Value.ToString();
                        ucConsumption.Visible = false;
                        mAddStockItem(DgRm, uctxtConsumption.Text, 1);
                        uctxtConsumption.Text = "";

                        uctxtConsumption.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtConsumption.Text = ucConsumption.Rows[i].Cells[0].Value.ToString();
                    ucConsumption.Visible = false;
                    uctxtWastage.Focus();
                }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtConsumption, sender, e);
            }
        }
        private void uctxtConsumption_GotFocus(object sender, System.EventArgs e)
        {
            lstProcess.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstBatch.Visible = false;
            ucConsumption.Visible = false;
            ucFG.Visible = false;
            lstFgLocation.Visible = false;
            uclstWastage.Visible = false;
            //mloadNotInGroup("Finished Goods",ucConsumption);
        }

        private void ucConsumption_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (ucConsumption.SelectedRows.Count > 0)
            {
                uctxtConsumption.Text = Utility.GetDgValue(ucConsumption, uctxtConsumption, 0);
                mAddStockItem(DgRm, uctxtConsumption.Text, 1);
                ucConsumption.Visible = false;
                uctxtConsumption.Text = "";
                uctxtConsumption.Focus();


            }
        }
        private void ucConsumption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtConsumption.Text = Utility.GetDgValue(ucConsumption, uctxtConsumption, 0);
                ucConsumption.Visible = false;
                mAddStockItem(DgRm, uctxtConsumption.Text, 1);
                uctxtConsumption.Text = "";
                uctxtConsumption.Focus();
            }
        }
        private void uctxtFgItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtFgItem.Text == "")
                {
                    uctxtFgItem.Text = "";
                    ucFG.Visible = false;
                    uctxtConsumption.Focus();
                    return;
                }


                if (uctxtFgItem.Text != "")
                {
                    ucFG.Focus();
                    if (ucFG.Rows.Count > 0)
                    {
                        int i = 0;

                        uctxtFgItem.Text = ucFG.Rows[i].Cells[0].Value.ToString();
                        mAddStockItem(DgFG, uctxtFgItem.Text, 1);
                        ucFG.Visible = false;
                        uctxtFgItem.Text = "";
                        uctxtFgItem.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtFgItem.Text = ucFG.Rows[i].Cells[0].Value.ToString();
                    ucFG.Visible = false;
                    uctxtConsumption.Focus();
                }


            }
        }
        private void ucFG_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (ucFG.SelectedRows.Count > 0)
            {
                uctxtFgItem.Text = Utility.GetDgValue(ucFG, uctxtFgItem, 0);
                mAddStockItem(DgFG, uctxtFgItem.Text, 1);
                ucFG.Visible = false;
                uctxtFgItem.Text = "";
                ucFG.Focus();


            }
        }
        private void ucFG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtFgItem.Text = Utility.GetDgValue(ucFG, uctxtFgItem, 0);
                mAddStockItem(DgFG, uctxtFgItem.Text, 1);
                uctxtFgItem.Text = "";
                ucFG.Visible = false;
                uctxtFgItem.Focus();
            }
        }
        private void uctxtFgItem_GotFocus(object sender, System.EventArgs e)
        {
            lstProcess.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstFgLocation.Visible = false;
            ucConsumption.Visible = false;
            ucFG.Visible = false;
            uclstWastage.Visible = false;
            lstBatch.Visible = false;
            //mloadItem("Finished Goods");
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
            }
            uctxtNarration.Focus();
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
                }
                uctxtNarration.Focus();

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
            ucConsumption.Visible = false;
            ucFG.Visible = false;
            lstFgLocation.Visible = false;
            uclstWastage.Visible = false;
            lstProcess.SelectedIndex = lstProcess.FindString(uctxtProcessName.Text);
        }
        private void dteDate_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            ucConsumption.Visible = false;
            ucFG.Visible = false;
            lstFgLocation.Visible = false;
            uclstWastage.Visible = false;
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
            mLoadAllItemRMWAS();
            txtFgLocation.Focus();
        }
        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                    mLoadAllItemRMWAS();
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
            ucConsumption.Visible = false;
            ucFG.Visible = false;
            uclstWastage.Visible = false;
            try
            {
                if (uctxtBranchName.Text != "")
                {
                    lstLocation.ValueMember = "strLocation";
                    lstLocation.DisplayMember = "strLocation";
                    lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, 0).ToList();
                }
                lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
            }
            catch (Exception ex)
            {

            }
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
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            ucConsumption.Visible = false;
            ucFG.Visible = false;
            uclstWastage.Visible = false;
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID,Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

         #endregion
         #region "Getconfig"
        private void mGetConfig()
        {
            List<VoucherTypes> ooVtype = accms.mGetConfig(strComID, intvType).ToList();
            if (ooVtype.Count > 0)
            {
                //if (ooVtype[0].intVoucherNoMethod == 0)
                //{
                mblnNumbMethod = true;
                //}
                //else
                //{
                //    mblnNumbMethod = false;
                //}
                mintIsPrin = ooVtype[0].intVoucherNoMethod;
            }
          

        }
        #endregion
         #region "Load"
        private void frmMFGVoucher_Load(object sender, EventArgs e)
        {
            string strYesNo = "Y";
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, 202, m_action))
                {
                    strYesNo = "N";
                }
            }
            if (strYesNo == "Y")
            {
                DgFG.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 250, true, DataGridViewContentAlignment.TopLeft, true));
                DgFG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, false));
                DgFG.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DgFG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 120, true, DataGridViewContentAlignment.TopLeft, true));
            }
            else
            {
                DgFG.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 350, true, DataGridViewContentAlignment.TopLeft, true));
                DgFG.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 100, true, DataGridViewContentAlignment.TopLeft, false));
                DgFG.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 100, true, DataGridViewContentAlignment.TopLeft, true));
                DgFG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 120, false, DataGridViewContentAlignment.TopLeft, true));
                lblTCamount.Visible = false;
                lblwAmount.Visible = false;
                lblUnitPrice.Visible = false;
            }
            DgFG.Columns.Add(Utility.Create_Grid_Column("Cost(%)", "Cost(%)", 120, true, DataGridViewContentAlignment.TopLeft, true));
            // DgFG.Columns.Add(Utility.Create_Grid_Column_button("Show", "Show", "Show", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DgFG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            if (strYesNo == "Y")
            {
                DgRm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 300, true, DataGridViewContentAlignment.TopLeft, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 120, true, DataGridViewContentAlignment.TopLeft, false));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, true, DataGridViewContentAlignment.TopLeft, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 200, true, DataGridViewContentAlignment.TopLeft, true));
            }
            else
            {
                DgRm.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 480, true, DataGridViewContentAlignment.TopLeft, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 120, true, DataGridViewContentAlignment.TopLeft, false));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, true, DataGridViewContentAlignment.TopLeft, true));
                DgRm.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 200, false, DataGridViewContentAlignment.TopLeft, true));
            }
            //DgRm.Columns.Add(Utility.Create_Grid_Column_button("Show", "Show", "Show", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DgRm.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            if (strYesNo == "Y")
            {
                DgWastage.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 300, true, DataGridViewContentAlignment.TopLeft, true));
                DgWastage.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 120, true, DataGridViewContentAlignment.TopLeft, true));
                DgWastage.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, true, DataGridViewContentAlignment.TopLeft, true));
                DgWastage.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 200, true, DataGridViewContentAlignment.TopLeft, true));
            }
            else
            {
                DgWastage.Columns.Add(Utility.Create_Grid_Column("Name of Item", "Name of Item", 480, true, DataGridViewContentAlignment.TopLeft, true));
                DgWastage.Columns.Add(Utility.Create_Grid_Column("Qnty", "Qnty", 120, true, DataGridViewContentAlignment.TopLeft, true));
                DgWastage.Columns.Add(Utility.Create_Grid_Column("Unit", "Unit", 70, true, DataGridViewContentAlignment.TopLeft, true));
                DgWastage.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 200, false, DataGridViewContentAlignment.TopLeft, true));
            }
            // DgWastage.Columns.Add(Utility.Create_Grid_Column_button("Show", "Show", "Show", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DgWastage.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            mGetConfig();
            mClear();
           
          
            //mLoadMonthTree(DateTime.Now.ToString("yyyy"));
            cboYear.Items.Clear();
            cboYear.Text = DateTime.Now.ToString("yyyy");
            DateTime dteFdate = Convert.ToDateTime(Utility.gdteFinancialYearFrom);
            int intyear = (int)(Utility.DateDiff(Utility.DateInterval.Year, Convert.ToDateTime(Utility.gdteFinancialYearFrom), Convert.ToDateTime(Utility.gdteFinancialYearTo))) + 1;
            for (int i = 1; i <= intyear; i++)
            {
                cboYear.Items.Add(dteFdate.ToString("yyyy"));
                dteFdate = dteFdate.AddYears(1);
            }

            DgFG.AllowUserToAddRows = false;
            DgRm.AllowUserToAddRows = false;
            DgWastage.AllowUserToAddRows = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            oinv = invms.mGetInvoiceConfig(strComID).ToList();
            //oinv = invms.mGetInvoiceConfigNew(strComID).ToList();

            //lstProcess.ValueMember = "strProcessName";
            //lstProcess.DisplayMember = "strProcessName";
            //lstProcess.DataSource = invms.mLoadFgProcessFG(strComID, "").ToList();

            lstProcess.ValueMember = "strProcessName";
            lstProcess.DisplayMember = "strProcessName";
            lstProcess.DataSource = invms.mLoadProcess(strComID, "", "", 1, 0, Utility.gstrUserName).ToList();

            lstBatch.DisplayMember = "value";
            lstBatch.ValueMember = "Key";
            lstBatch.DataSource = new BindingSource(invms.mFillOpeningBatchNew(strComID, Utility.gstrUserName), null);
       
            
        }
        #endregion
         #region "Get Month"
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
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return false;
                }
            }
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
            //if (Utility.Val(lblUnitPrice.Text) == 0 || Utility.Val(lblUnitPrice.Text) < 0)
            //{
            //    MessageBox.Show("Net Amount be Empty");
            //    uctxtProcessName.Focus();
            //    return false;
            //}

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
            string strLockvoucher = Utility.gLockVocher(strComID, intvType);
           
            if (strLockvoucher != "")
            {
                long lngBackdate = Convert.ToInt64(Convert.ToDateTime(strLockvoucher).ToString("yyyyMMdd"));
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
                        strBillKey = DgRm[0, i].ToString();
                        //dblClosingQTY = Utility.gdblClosingStock(strComID, DgRm[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                        dblClosingQTY = Utility.gdblClosingStockSales(strComID, DgRm[0, i].Value.ToString(), lstBranchName.SelectedValue.ToString(), "",uctxtLocation.Text);
                        if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                        {
                            dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey, uctxtLocation.Text);
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

                if (intCheckNegetive > 0)
                {
                    MessageBox.Show("You have no valid quantity for Item: " + strNegetiveItem);
                    DgRm.Focus();
                    return false;
                }

                for (int i = 0; i < DgWastage.Rows.Count; i++)
                {
                    if (DgWastage[0, i].Value.ToString() != "")
                    {
                        strBillKey = DgWastage[0, i].Value.ToString();
                        //dblClosingQTY = Utility.gdblClosingStock(strComID, DgWastage[0, i].Value.ToString(), uctxtLocation.Text, dteDate.Text);
                        dblClosingQTY = Utility.gdblClosingStockSales(strComID, DgWastage[0, i].Value.ToString(), lstBranchName.SelectedValue.ToString(), "",uctxtLocation.Text);
                        if (m_action == (int)Utility.ACTION_MODE_ENUM.EDIT_MODE)
                        {
                            dblClosingQTY = dblClosingQTY + Utility.gdblGetBillQty(strComID, strBillKey, uctxtLocation.Text);
                        }
                        dblCurrentQTY = Utility.Val(DgWastage[1, i].Value.ToString());
                        if ((dblClosingQTY) - dblCurrentQTY < 0)
                        {
                            strNegetiveItem = strNegetiveItem + Environment.NewLine + DgWastage[0, i].Value.ToString();
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
        #endregion
         #region "Save"
        private string mSaveMFGvoucher()
        {
            string strBranchId = "", strFG = "", strRM = "", strDGwastage = "", strBranchIdTo, strbatch,strInsert="";
             double dblAmnt = 0;
             if (uctxtBatch.Text == Utility.gcEND_OF_LIST)
             {
                 strbatch = "";
             }
             else
             {
                 strbatch = uctxtBatch.Text;
             }
             for (int intRow = 0; intRow < DgFG.Rows.Count; intRow++)
            {
                if (DgFG[0, intRow].Value != null)
                {
                    dblAmnt = dblAmnt+ Utility.Val(DgFG[3, intRow].Value.ToString());
                    strFG = strFG + Utility.gCheckNull(DgFG[0, intRow].Value.ToString()) + "|" + Utility.Val(DgFG[1, intRow].Value.ToString()) + "|" +
                        Utility.gCheckNull(DgFG[2, intRow].Value.ToString()) + "|" + Utility.Val(DgFG[3, intRow].Value.ToString()) + "~";
                
                }
            }

            for (int intRow = 0; intRow < DgRm.Rows.Count; intRow++)
            {
                if (DgRm[0, intRow].Value != null)
                {
                    strRM = strRM + Utility.gCheckNull(DgRm[0, intRow].Value.ToString()) + "|" + Utility.Val(DgRm[1, intRow].Value.ToString()) + "|"
                                            + Utility.gCheckNull(DgRm[2, intRow].Value.ToString()) + "|" + Utility.Val(DgRm[3, intRow].Value.ToStringNull()) + "~";
                }

            }

            for (int intRow = 0; intRow < DgWastage.Rows.Count; intRow++)
            {
                if (DgWastage[0, intRow].Value != null)
                {
                    strDGwastage = strDGwastage + Utility.gCheckNull(DgWastage[0, intRow].Value.ToString()) + "|" + Utility.Val(DgWastage[1, intRow].Value.ToString())
                                        + "|" + Utility.gCheckNull(DgWastage[2, intRow].Value.ToString()) + "|" + Utility.Val(DgWastage[3, intRow].Value.ToString()) + "~";
                }
            }
            strBranchId=Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            strBranchIdTo = Utility.gstrGetBranchID(strComID, txtFgLocation.Text);
            try
            {
                strInsert = objWIS.mInsertMFGvoucher(strComID, uctxtVoucherNo.Text, strbatch, strBranchId, strBranchIdTo, uctxtLocation.Text, txtFgLocation.Text, uctxtProcessName.Text, dteDate.Value.ToShortDateString(),
                                                            uctxtNarration.Text, dblAmnt, strFG, strRM, strDGwastage, m_action, mblnNumbMethod, 1);

               return strInsert;
            }


            catch (Exception ex)
            {
                return (ex.ToString());
            }
            
        }
        private string mUpdatMFGvoucher()
        {
            string strBranchId = "", strFG = "", strRM = "", strDGwastage = "", strBranchIdTo = "", strbatch;
            double dblAmnt = 0;
            if (uctxtBatch.Text == Utility.gcEND_OF_LIST)
            {
                strbatch = "";
            }
            else
            {
                strbatch = uctxtBatch.Text;
            }
            for (int intRow = 0; intRow < DgFG.Rows.Count; intRow++)
            {
                if (DgFG[0, intRow].Value != null)
                {
                    dblAmnt = dblAmnt + Utility.Val(DgFG[3, intRow].Value.ToString());
                    strFG = strFG + Utility.gCheckNull(DgFG[0, intRow].Value.ToString()) + "|" + Utility.Val(DgFG[1, intRow].Value.ToString()) + "|" +
                        Utility.gCheckNull(DgFG[2, intRow].Value.ToString()) + "|" + Utility.Val(DgFG[3, intRow].Value.ToString()) + "~";

                }
            }

            for (int intRow = 0; intRow < DgRm.Rows.Count; intRow++)
            {
                if (DgRm[0, intRow].Value != null)
                {
                    strRM = strRM + Utility.gCheckNull(DgRm[0, intRow].Value.ToString()) + "|" + Utility.Val(DgRm[1, intRow].Value.ToString()) + "|"
                                            + Utility.gCheckNull(DgRm[2, intRow].Value.ToString()) + "|" + Utility.Val(DgRm[3, intRow].Value.ToStringNull()) + "~";
                }

            }

            for (int intRow = 0; intRow < DgWastage.Rows.Count; intRow++)
            {
                if (DgWastage[0, intRow].Value != null)
                {
                    strDGwastage = strDGwastage + Utility.gCheckNull(DgWastage[0, intRow].Value.ToString()) + "|" + Utility.Val(DgWastage[1, intRow].Value.ToString())
                                        + "|" + Utility.gCheckNull(DgWastage[2, intRow].Value.ToString()) + "|" + Utility.Val(DgWastage[3, intRow].Value.ToString()) + "~";
                }
            }
            strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            strBranchIdTo = Utility.gstrGetBranchID(strComID, txtFgLocation.Text);
            try
            {
                string strInsert = objWIS.mUpdateMFGvoucher(strComID, strbatch, Utility.gCheckNull(txtRm.Text), Utility.gCheckNull(txtWm.Text), Utility.gCheckNull(txtFm.Text), Utility.gCheckNull(uctxtBatch.Text),
                                                            strBranchId,strBranchIdTo, uctxtLocation.Text,txtFgLocation.Text, uctxtProcessName.Text, dteDate.Value.ToShortDateString(), 
                                                            uctxtNarration.Text, dblAmnt, strFG, strRM, strDGwastage, m_action, mblnNumbMethod,1);

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
            DgFG.Rows.Clear();
            DgRm.Rows.Clear();
            DgWastage.Rows.Clear();
            txtFgLocation.Text = "";
            lblQntC.Text = "0";
            lblTCamount.Text = "0";
            lblWqnt.Text = "0";
            lblwAmount.Text = "0";
            lblUnitPrice.Text = "0";
            txtRm.Text = "";
            txtFm.Text = "";
            uctxtNarration.Text = "";
            uctxtProcessName.Enabled = true;
            uctxtBatch.Enabled = true;
            txtFgLocation.Text = "";
            txtWm.Text = "";
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
                uctxtVoucherNo.Text = Utility.gstrLastNumber(strComID, intvType);
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
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, uctxtVoucherNo.Text,
                                                                    1, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                        }
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
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, uctxtVoucherNo.Text,
                                                                    2, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                        }
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
        #endregion
         #region "Click"
        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            frmMFGVoucherTreeview objfrm = new frmMFGVoucherTreeview();
            objfrm.strYear = cboYear.Text;
            objfrm.intConvertFg = 1;
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmMFGVoucherList objfrm = new frmMFGVoucherList();
            objfrm.onAddAllButtonClicked = new frmMFGVoucherList.AddAllClick(DisplayProcess);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = strFormName;
            objfrm.intConvert = 1;
            objfrm.intVoucherType = intvType;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }
        private void DisplayProcess(List<MFGvouhcer> tests, object sender, EventArgs e)
        {
            try
            {
                int intrm = 0, intfg = 0, intwastage = 0;
                double dblCostPercent = 0, dblLastFGQnty = 0, dblCostFgQnt = 0;
                dteDate.Focus();
                uctxtProcessName.Enabled = false;
                uctxtBatch.Enabled = false;
                lstBatch.Visible = false;
                if (tests[0].strBatch != "")
                {
                    uctxtBatch.Text = tests[0].strBatch;
                }
                else
                {
                    uctxtBatch.Text = Utility.gcEND_OF_LIST;
                }
                uctxtBranchName.Text = Utility.gstrGetBranchName(strComID, tests[0].strBranchId);
                uctxtVoucherNo.Text = tests[0].strVoucherNo;
                uctxtProcessName.Text = tests[0].strProcess;
                dteDate.Text = tests[0].strDate;
                txtRm.Text = tests[0].strRMRefNo;
                txtWm.Text = tests[0].strWmRefNo;
                txtFm.Text = tests[0].strFgRefNo;
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DgFG.Rows.Clear();
                DgRm.Rows.Clear();
                DgWastage.Rows.Clear();
                mdblAmount = 0;
                List<MFGvouhcer> oRm = objWIS.mDisplayRMVoucher(strComID, tests[0].strRMRefNo).ToList();
                {
                    if (oRm.Count > 0)
                    {
                        uctxtLocation.Text = oRm[0].strLocation;
                        foreach (MFGvouhcer ooRm in oRm)
                        {
                            DgRm.Rows.Add();
                            double dblrate = Utility.gdblGetCostPriceWeightAvg(strComID, ooRm.strItemName, dteDate.Text);
                            DgRm[0, intrm].Value = ooRm.strItemName;
                            DgRm[1, intrm].Value = ooRm.dblQnty.ToString();
                            DgRm[2, intrm].Value = ooRm.strUOM;
                            DgRm[3, intrm].Value = (ooRm.dblQnty * dblrate);
                            DgRm[4, intrm].Value = "Delete";
                            mdblAmount = mdblAmount + Math.Round(Utility.Val(DgRm[3, intrm].Value.ToString()),3);
                            intrm += 1;
                            DgRm.AllowUserToAddRows = false;
                        }
                    }
                }
                List<MFGvouhcer> owm = objWIS.mDisplayDmVoucher(strComID, tests[0].strWmRefNo).ToList();
                {
                    if (owm.Count > 0)
                    {
                        foreach (MFGvouhcer oowm in owm)
                        {
                            DgWastage.Rows.Add();
                            double dblrate = Utility.gdblGetCostPriceWeightAvg(strComID, oowm.strItemName, dteDate.Text);
                            DgWastage[0, intwastage].Value = oowm.strItemName;
                            DgWastage[1, intwastage].Value = oowm.dblQnty.ToString();
                            DgWastage[2, intwastage].Value = oowm.strUOM;
                            DgWastage[3, intwastage].Value = (oowm.dblQnty * dblrate);
                            DgWastage[4, intwastage].Value = "Delete";
                            mdblAmount = mdblAmount + Math.Round(Utility.Val(DgWastage[3, intwastage].Value.ToString()),3);
                            intwastage += 1;
                            DgWastage.AllowUserToAddRows = false;
                        }
                    }
                }
                List<MFGvouhcer> ofg = objWIS.mDisplayFgVoucher(strComID, tests[0].strFgRefNo).ToList();
                {
                    if (ofg.Count > 0)
                    {
                        foreach (MFGvouhcer oofg in ofg)
                        {
                            DgFG.Rows.Add();
                            txtFgLocation.Text = oofg.strLocation;
                            DgFG[0, intfg].Value = oofg.strItemName;
                            DgFG[1, intfg].Value = oofg.dblQnty.ToString();
                            DgFG[2, intfg].Value = oofg.strUOM;
                            double dblrate = Utility.gdblGetCostPriceWeightAvg(strComID, oofg.strItemName, dteDate.Text);
                            dblCostFgQnt = dblCostFgQnt + oofg.dblQnty;
                            dblLastFGQnty = oofg.dblQnty;
                            dblCostPercent = 100;
                            if (intfg == 0)
                            {
                                //DgFG[3, intfg].Value = Math.Round((oofg.dblQnty * oofg.dblrate), 3);
                                DgFG[3, intfg].Value = Math.Round(((mdblAmount * dblCostPercent) / 100), 3).ToString();
                            }
                            else
                            {
                                //DgFG[3, intfg].Value = Math.Round(((ts.dblqnty * dblrate)), 3).ToString();
                                DgFG[3, intfg].Value = 0;
                               
                            }
                            DgFG[4, intfg].Value = dblCostPercent;
                            DgFG[5, intfg].Value = "Delete";
                            intfg += 1;
                            DgFG.AllowUserToAddRows = false;
                        }
                    }
                    if (mdblAmount != 0)
                    {
                        if (dblCostPercent > 0)
                        {
                            //lblUnitPrice.Text = "Unit Price of F. Goods: " + Environment.NewLine + Math.Round((((mdblAmount / dblCostFgQnt) * dblCostPercent) / 100), 4).ToString();
                            lblUnitPrice.Text = "Unit Price of F. Goods: " + Environment.NewLine + Math.Round((((mdblAmount / dblLastFGQnty) * dblCostPercent) / 100), 4).ToString();
                        }
                    }
                    calculateTotal();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void tvNode_AfterSelect(object sender, TreeViewEventArgs e)
        {
            uctxtBatch.Focus();
        }

       
        #endregion
         #region "Cell End"
        private void DgRm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dblRmQnty = 0, dblRmEdit = 0, dblFgRate = 0,dblFgQty=0;
            string strItemName="";
            if (e.ColumnIndex == 1)
            {
                //for (int i = 0; i < DgFG.Rows.Count; i++)
                //{
                //    dblFgEdit = dblFgEdit + Utility.Val(DgFG[1, i].Value.ToString());
                //}

                strItemName = DgRm[0, e.RowIndex].Value.ToString();
                dblRmEdit = Utility.Val(DgRm[1, e.RowIndex].Value.ToString());
                foreach (ManuProcess ts in ooItem)
                {
                    if (ts.intType == 2)
                    {
                        dblFgQty = ts.dblqnty;
                    }
                    if (ts.intType == 1)
                    {
                        if (strItemName == ts.stritemName)
                        {
                            dblRmQnty = ts.dblqnty;
                        }
                    }
                }
                dblFgRate = Math.Round(dblFgQty / dblRmQnty,3);
                if (dblFgRate > 0)
                {
                    for (int i = 0; i < DgFG.Rows.Count; i++)
                    {
                        DgFG[1, 0].Value = Math.Round(dblRmEdit * dblFgRate, 2);
                    }
                    
                }

            }
        }
        private void DgFG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dblfgQnty = 0, dblFgEdit = 0, dblrate = 0;

            int intrm = 0, intfg = 0, intwastage = 0;
            if (e.ColumnIndex == 1)
            {
                for (int i = 0; i < DgFG.Rows.Count; i++)
                {
                    dblFgEdit = dblFgEdit + Utility.Val(DgFG[e.ColumnIndex, i].Value.ToString());
                }
                    foreach (ManuProcess ts in ooItem)
                    {
                        if (ts.intType == 2)
                        {
                            dblfgQnty = ts.dblqnty;
                            intfg+=1;
                            foreach (ManuProcess ts1 in ooItem)
                            {
                                if (ts1.intType == 1)
                                {
                                    dblrate = Utility.gdblGetCostPriceNew(strComID,ts1.stritemName, dteDate.Text);
                                    DgRm[1, intrm].Value = Math.Round(Utility.Val(ts1.dblqnty.ToString()) * (dblFgEdit / dblfgQnty), 3);
                                    DgRm[3, intrm].Value =Math.Round((Utility.Val(DgRm[1, intrm].Value.ToString()) * dblrate),3);
                                    intrm += 1;
                                }
                                if (ts1.intType == 3)
                                {
                                    dblrate = Utility.gdblGetCostPriceNew(strComID,ts1.stritemName, dteDate.Text);
                                    DgWastage[1, intwastage].Value = Math.Round(Utility.Val(ts1.dblqnty.ToString()) * (dblFgEdit / dblfgQnty), 3);
                                    DgWastage[3, intwastage].Value = Math.Round((Utility.Val(DgWastage[1, intwastage].Value.ToString()) * dblrate),3);
                                    intwastage += 1;
                                }
                            }

                        }
                    }
                 }

            mDistinctRate();
            calculateTotal();

        }
        #endregion
         #region "Distict Rate"
        private void mDistinctRate()
        {
            double dblfgQnty = 0, dblFgEdit = 0, dblrate = 0, dblFGAmount = 0, dblFgRate = 0;
            int intrm = 0, intfg = 0, intwastage = 0;
            string strItem = "";
            for (int i = 0; i < DgFG.Rows.Count; i++)
            {
                dblFgEdit = dblFgEdit + Utility.Val(DgFG[1, i].Value.ToString());
            }
          

            for (intfg = 0; intfg < DgFG.Rows.Count; intfg++)
            {
                if (DgFG[0, intfg].Value.ToString() != "")
                {
                    for (intrm = 0; intrm < DgRm.Rows.Count; intrm++)
                    {
                        strItem = DgRm[0, intrm].Value.ToString();
                        if (strItem != "")
                        {
                            dblrate = Utility.gdblGetCostPriceNew(strComID,strItem, dteDate.Text);
                        }
                        if (dblFgEdit > 0)
                        {
                            dblFGAmount = Math.Round(dblFGAmount + (Utility.Val(DgRm[1, intrm].Value.ToString()) / dblFgEdit * Utility.Val(DgFG[1, intfg].Value.ToString()) * dblrate), 3);
                        }
                    }

                    for (intwastage = 0; intwastage < DgWastage.Rows.Count; intwastage++)
                    {
                        strItem = DgWastage[0, intrm].Value.ToString();
                        if (strItem != "")
                        {
                            dblrate = Utility.gdblGetCostPriceNew(strComID,strItem, dteDate.Text);
                        }
                        if (dblFgEdit > 0)
                        {
                            dblFGAmount = Math.Round(dblFGAmount + (Utility.Val(DgWastage[1, intwastage].Value.ToString()) / dblFgEdit * Utility.Val(DgFG[1, intfg].Value.ToString()) * dblrate), 3);
                        }
                    }

                }

                for (intfg = 0; intfg < DgFG.Rows.Count; intfg++)
                {
                    if (DgFG[0, intfg].Value.ToString() != "")
                    {
                        if (DgFG[4, intfg].Value.ToString() != "0")
                        {
                            if (DgFG[3, intfg].Value.ToString() != "0")
                            {
                                DgFG[3, intfg].Value = ((dblFGAmount / 100) * Utility.Val(DgFG[4, intfg].Value.ToString()));
                            }
                        }
                    }
                }


                if (dblFGAmount != 0)
                {
                    if (dblfgQnty != 0)
                    {
                        if (dblFGAmount != 0)
                        {
                            lblUnitPrice.Text = (Math.Round((Convert.ToDouble((mdblAmount / dblfgQnty)) * 100) / 100, 3)).ToString();
                        }
                    }
                }
            }
        }
        #endregion
         #region "KeyUp"
        private void uctxtFgItem_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (txtFgLocation.Text != "")
                {
                    SearchListViewFG(oogrp, uctxtFgItem.Text);
                }
                else
                {
                    ucFG.Rows.Clear();
                    oogrp.Clear();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void SearchListViewFG(IEnumerable<StockItem> tests, string searchString = "")
        {
            IEnumerable<StockItem> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
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
            ucFG.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    ucFG.Rows.Add();
                    ucFG[0, i].Value = tran.strItemName;
                    ucFG[1, i].Value = tran.dblClsBalance + " " + tran.strUnit; ;
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void uctxtConsumption_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (uctxtLocation.Text != "")
                {
                    SearchListViewRm(ooRm_WAS, uctxtConsumption.Text);
                }
                else
                {
                    ucConsumption.Rows.Clear();
                    uclstWastage.Rows.Clear();
                    ooRm_WAS.Clear();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void SearchListViewCM(IEnumerable<StockItem> tests, string searchString = "")
        {
            IEnumerable<StockItem> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
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
            ucConsumption.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    ucConsumption.Rows.Add();
                    ucConsumption[0, i].Value = tran.strItemName;
                    ucConsumption[1, i].Value = tran.dblClsBalance + " " + tran.strUnit;
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void uctxtWastage_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (uctxtLocation.Text != "")
                {
                    SearchListViewRm(ooRm_WAS, uctxtConsumption.Text);
                }
                else
                {
                    ucConsumption.Rows.Clear();
                    uclstWastage.Rows.Clear();
                    ooRm_WAS.Clear();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SearchListViewWS(IEnumerable<StockItem> tests, string searchString = "")
        {
            IEnumerable<StockItem> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
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
            uclstWastage.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    uclstWastage.Rows.Add();
                    uclstWastage[0, i].Value = tran.strItemName;
                    uclstWastage[1, i].Value = tran.dblClsBalance + " " + tran.strUnit;
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #endregion
         #region "Lad All"
        private void mLoadAllItemRMWAS()
        {

            int introw = 0;
            //long lngLedgerGroup = 0, lngLedgerManufacFroup = 0;
            this.ucConsumption.DefaultCellStyle.Font = new Font("verdana", 10.5F);
            this.uclstWastage.DefaultCellStyle.Font = new Font("verdana", 10.5F);

            ucConsumption.Rows.Clear();
            uclstWastage.Rows.Clear();
            try
            {
                ooRm_WAS = invms.mloadAddStockItemRMPack(strComID, uctxtLocation.Text,"","N").ToList();


                if (ooRm_WAS.Count > 0)
                {

                    foreach (StockItem ogrp in ooRm_WAS)
                    {
                        ucConsumption.Rows.Add();
                        uclstWastage.Rows.Add();
                        ucConsumption[0, introw].Value = ogrp.strItemName;
                        ucConsumption[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;
                        uclstWastage[0, introw].Value = ogrp.strItemName;
                        uclstWastage[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;

                        //if (introw % 2 == 0)
                        //{
                        //    ucConsumption.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                        //    uclstWastage.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                        //}
                        //else
                        //{
                        //    ucConsumption.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                        //    uclstWastage.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                        //}
                        introw += 1;
                    }
                    uclstWastage.AllowUserToAddRows = false;
                    ucConsumption.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void mLoadAllItemFG()
        {
            int introw = 0;
            //long lngLedgerGroup = 0, lngLedgerManufacFroup = 0;
            this.ucFG.DefaultCellStyle.Font = new Font("verdana", 10.5F);
            ucFG.Rows.Clear();
            //oogrp = invms.mloadAddStockItemFg().ToList();
            oogrp = invms.mloadAddStockItemFg(strComID, txtFgLocation.Text).ToList();
            if (oogrp.Count > 0)
            {

                foreach (StockItem ogrp in oogrp)
                {
                    ucFG.Rows.Add();
                    ucFG[0, introw].Value = ogrp.strItemName;
                    // ucFG[1, introw].Value = ogrp.strItemcode;
                    //ucFG[2, introw].Value = ogrp.strUnit;
                    ucFG[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;

                    //if (introw % 2 == 0)
                    //{
                    //    ucFG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    ucFG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                ucFG.AllowUserToAddRows = false;
            }
        }
        #endregion

        private void SearchListViewRm(IEnumerable<StockItem> tests, string searchString = "")
        {
            IEnumerable<StockItem> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
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
            ucConsumption.Rows.Clear();
            int i = 0;
            try
            {
                foreach (StockItem tran in query)
                {
                    ucConsumption.Rows.Add();
                    ucConsumption[0, i].Value = tran.strItemName;
                    ucConsumption[1, i].Value = tran.dblClsBalance + " " + tran.strUnit;
                    i += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #region "Click"
        private void DgFG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==5)
            {
                DgFG.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void DgRm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DgRm.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void DgWastage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DgWastage.Rows.RemoveAt(e.RowIndex);
            }
        }

      
        #endregion

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_2(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

      










    }
}
