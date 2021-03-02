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
using Microsoft.Win32;


namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmDepreciationAdjustment : JA.Shared.UI.frmJagoronFromSearch
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstLedger = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strDefaultComID { get; set; }
        public int m_action { get; set; }
        public frmDepreciationAdjustment()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strDefaultComID = (String)regKey.GetValue("CompanyID", "0001");

            this.uctxtVoucherNo.GotFocus += new System.EventHandler(this.uctxtVoucherNo_GotFocus);
            this.dteEffectiveDate.GotFocus += new System.EventHandler(this.dteEffectiveDate_GotFocus);
            this.uctxtAmount.GotFocus += new System.EventHandler(this.uctxtAmount_GotFocus);
            this.uctxtAmount.TextChanged += new System.EventHandler(this.uctxtAmount_TextChanged);

            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);

            this.uctxtLedger.KeyDown += new KeyEventHandler(uctxtLedger_KeyDown);
            this.uctxtLedger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedger_KeyPress);
            this.uctxtLedger.TextChanged += new System.EventHandler(this.uctxtLedger_TextChanged);
            this.lstLedger.DoubleClick += new System.EventHandler(this.lstLedger_DoubleClick);
            this.uctxtLedger.GotFocus += new System.EventHandler(this.uctxtLedger_GotFocus);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch);
            Utility.CreateListBox(lstLedger, pnlMain, uctxtLedger);
            TabChange();
        }

        #region "Tab change
        private void TabChange()
        {
            uctxtVoucherNo.Focus();
            uctxtVoucherNo.AllToNextTab(dteEffectiveDate);
            dteEffectiveDate.AllToNextTab(uctxtBranch);
            uctxtBranch.AllToNextTab(uctxtLedger);
            uctxtLedger.AllToNextTab(uctxtAmount);
            uctxtAmount.AllToNextTab(btnSave);

        }
        #endregion
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

        private void uctxtAmount_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtAmount.Text) == false)
            {
                uctxtAmount.Text = "";
            }
        }


        private void uctxtAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstLedger.Visible = false;
            lstBranch.Visible = false;

        }
        private void dteEffectiveDate_GotFocus(object sender, System.EventArgs e)
        {
            lstLedger.Visible = false;
            lstBranch.Visible = false;

        }
        private void uctxtVoucherNo_GotFocus(object sender, System.EventArgs e)
        {
            lstLedger.Visible = false;
            lstBranch.Visible = false;

        }
        private void uctxtLedger_TextChanged(object sender, EventArgs e)
        {
            lstLedger.SelectedIndex = lstLedger.FindString(uctxtLedger.Text);
        }

        private void lstLedger_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedger.Text = lstLedger.Text;
            uctxtAmount.Focus();
        }

        private void uctxtLedger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedger.Items.Count > 0)
                {
                    uctxtLedger.Text = lstLedger.Text;
                }
                uctxtAmount.Focus();

            }
        }
        private void uctxtLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLedger.SelectedItem != null)
                {
                    lstLedger.SelectedIndex = lstLedger.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedger.Items.Count - 1 > lstLedger.SelectedIndex)
                {
                    lstLedger.SelectedIndex = lstLedger.SelectedIndex + 1;
                }
            }

        }

        private void uctxtLedger_GotFocus(object sender, System.EventArgs e)
        {
            lstLedger.Visible = true;
            lstBranch.Visible = false;
            lstLedger.SelectedIndex = lstLedger.FindString(uctxtLedger.Text);
          
        }



        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranch.Text = lstBranch.Text;
            uctxtLedger.Focus();
        }
        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstBranch.Text;
                }
                uctxtLedger.Focus();

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
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }




        private void frmDepreciationAdjustment_Load(object sender, EventArgs e)
        {
            uctxtVoucherNo.Focus();
            lstLedger.Visible = false;
            lstBranch.Visible = false;
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("Ref No.", "Ref No.", 90, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 330, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Branch Name", "Branch Name", 320, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 80, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit.", "Edit", "Edit.", 40, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            lstLedger.ValueMember = "LedgerName";
            lstLedger.DisplayMember = "LedgerName";
            lstLedger.DataSource = basSales.gFillSalesLedger(strDefaultComID , (long)Utility.GR_GROUP_TYPE.grFIXED_ASSET);

            lstBranch.ValueMember = "BranchName";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillGetBranch(strDefaultComID).ToList();
            mLoadAdjustment();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (uctxtVoucherNo.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtVoucherNo.Focus();
                return;
            }
            if (uctxtLedger.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtLedger.Focus();
                return;
            }
            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtBranch.Focus();
                return;
            }
            double dblAmount = 0;
            if (uctxtAmount.Text!="")
            {
                dblAmount = Convert.ToDouble(uctxtAmount.Text);
            }
            else
            {
                dblAmount = 0;
            }

            var strResponseInsert = MessageBox.Show("Do You Want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                try
                {

                    string strmsg = accms.mInsertAssetsAdjustment(strDefaultComID, uctxtVoucherNo.Text.ToString(), textBox1.Text.ToString(), 
                                                                    dteEffectiveDate.Text.ToString(), uctxtBranch.Text.ToString(),
                                                                    uctxtLedger.Text.ToString(), dblAmount);
                    //MessageBox.Show(strmsg);
                    mClear();
                    mLoadAdjustment();
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void mLoadAdjustment()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<FixedAssets> oogrp = accms.mGetFixedAssetsAdjustment(strDefaultComID).ToList();
            if (oogrp.Count > 0)
            {

                foreach (FixedAssets ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strRefNo;
                    DG[1, introw].Value = ogrp.strEffectiveDate;
                    DG[2, introw].Value = ogrp.strLedgerName;
                    DG[3, introw].Value = Utility.gstrGetBranchName(strDefaultComID, ogrp.strBranchID);
                    DG[4, introw].Value = ogrp.dblPurchaseAmount;
                    DG[5, introw].Value = "Edit";
                    DG[6, introw].Value = "Delete";
                    if (introw % 2 == 0)
                    {
                        DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    }
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }
        private void  mClear()
        {
            uctxtVoucherNo.Text = "";
            uctxtLedger.Text = "";
            uctxtBranch.Text = "";
            uctxtAmount.Text = "";
            uctxtVoucherNo.Focus();

        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (DG.Rows.Count > 0)
                {
                    textBox1.Text = DG.CurrentRow.Cells[0].Value.ToString();
                    uctxtVoucherNo.Text = Utility.Mid(DG.CurrentRow.Cells[0].Value.ToString(), 4, DG.CurrentRow.Cells[0].Value.ToString().Length-4);
                    dteEffectiveDate.Text = DG.CurrentRow.Cells[1].Value.ToString();
                    uctxtLedger.Text = DG.CurrentRow.Cells[2].Value.ToString();
                    uctxtBranch.Text = DG.CurrentRow.Cells[3].Value.ToString();
                    uctxtAmount.Text = DG.CurrentRow.Cells[4].Value.ToString();
                    uctxtVoucherNo.Focus();
                }
            }
            
            
            if (e.ColumnIndex==6)
            {
                try
                {
                    var strResponseDel = MessageBox.Show("Do You Want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponseDel == DialogResult.Yes)
                    {
                        string strresponse = accms.mDeleteAssetsAdjustment(strDefaultComID, DG.CurrentRow.Cells[0].Value.ToString());
                        mLoadAdjustment();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }



    }
}
