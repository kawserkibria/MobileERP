using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmVoucherTypes : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstNoMethod = new ListBox();
        private ListBox lstPrintSave = new ListBox();
        public long lngFormPriv { get; set; }
        public delegate void AddAllClick(List<VoucherTypes> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngMtype { get; set; }
        public long lngvtype { get; set; }
        private string strComID { get; set; }
        public frmVoucherTypes(long value,long vMtype)
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User Ini"
            this.uctxtTypeOfVoucher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTypeOfVoucher_KeyPress);
            this.uctxtTypeOfVoucher.GotFocus += new System.EventHandler(this.uctxtTypeOfVoucher_GotFocus);

            this.uctxtVoucher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtVoucher_KeyPress);
            this.uctxtVoucher.GotFocus += new System.EventHandler(this.uctxtVoucher_GotFocus);

            this.uctxtNuemricalPart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNuemricalPart_KeyPress);
            this.uctxtNuemricalPart.GotFocus += new System.EventHandler(this.uctxtNuemricalPart_GotFocus);

            this.uctxtPrefix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPrefix_KeyPress);
            this.uctxtPrefix.GotFocus += new System.EventHandler(this.uctxtPrefix_GotFocus);

            this.uctxtSuffix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSuffix_KeyPress);
            this.uctxtSuffix.GotFocus += new System.EventHandler(this.uctxtSuffix_GotFocus);

            this.uctxtStartingMethod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtStartingMethod_KeyPress);
            this.uctxtStartingMethod.GotFocus += new System.EventHandler(this.uctxtStartingMethod_GotFocus);

            this.uctxtNumeringMethod.GotFocus += new System.EventHandler(this.uctxtNumeringMethod_GotFocus);
            this.lstNoMethod.DoubleClick += new System.EventHandler(this.lstNoMethod_DoubleClick);
            this.uctxtNumeringMethod.KeyDown += new KeyEventHandler(uctxtNumeringMethod_KeyDown);
            this.uctxtNumeringMethod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNumeringMethod_KeyPress);
            this.uctxtNumeringMethod.TextChanged += new System.EventHandler(this.uctxtNumeringMethod_TextChanged);

            this.uctxtPrintAfterSavingVoucher.GotFocus += new System.EventHandler(this.uctxtPrintAfterSavingVoucher_GotFocus);
            this.lstPrintSave.DoubleClick += new System.EventHandler(this.lstPrintSave_DoubleClick);
            this.uctxtPrintAfterSavingVoucher.KeyDown += new KeyEventHandler(uctxtPrintAfterSavingVoucher_KeyDown);
            this.uctxtPrintAfterSavingVoucher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPrintAfterSavingVoucher_KeyPress);
            this.uctxtPrintAfterSavingVoucher.TextChanged += new System.EventHandler(this.uctxtPrintAfterSavingVoucher_TextChanged);
            Utility.CreateListBox(lstNoMethod, pnlMain, uctxtNumeringMethod);
            Utility.CreateListBox(lstPrintSave, pnlMain, uctxtPrintAfterSavingVoucher);
            lngvtype = value;
            lngMtype = vMtype;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int intEffectBkash = 2;
            if (uctxtTypeOfVoucher.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtTypeOfVoucher.Focus();
                return;
            }
            if (uctxtTypeOfVoucher.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtTypeOfVoucher.Focus();
                return;
            }
            if (uctxtVoucher.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtVoucher.Focus();
                return;
            }
            if (uctxtNumeringMethod.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtNumeringMethod.Focus();
                return;
            }

            if (uctxtStartingMethod.Text == "" || uctxtStartingMethod.Text == "0")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtStartingMethod.Focus();
                return;
            }
            if (uctxtNuemricalPart.Text == "" || uctxtNuemricalPart.Text=="0")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtNuemricalPart.Focus();
                return;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 2))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (chkBkash.Checked==true)
            {
                intEffectBkash = 1;
            }
            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                try
                {
                    bool blngcheck;
                    if (chkTotallVoucher.Checked==true)
                    {
                        blngcheck=true;
                    }
                    else
                    {
                        blngcheck=false;
                    }
                    string strmsg = accms.mUpdteVoucherTypes(strComID, lngMtype, lngvtype, Convert.ToInt64(uctxtNuemricalPart.Text.ToString()), Utility.gCheckNull(uctxtPrefix.Text),
                                                            Utility.gCheckNull(uctxtNumeringMethod.Text), Utility.gCheckNull(uctxtSuffix.Text),
                                                            blngcheck, uctxtVoucher.Text, Convert.ToInt64(uctxtStartingMethod.Text), Utility.gCheckNull(uctxtPrintAfterSavingVoucher.Text), intEffectBkash);

                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Voucher Types", "Voucher Types",
                                                                2, 0, (int)lngMtype, "0001");
                    } 
                    if (strmsg == "1")
                    {
                        this.Hide();
                        if (onAddAllButtonClicked != null)
                            onAddAllButtonClicked(GetSelectedItem(), sender, e);
                        this.Dispose();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private List<VoucherTypes> GetSelectedItem()
        {
            List<VoucherTypes> items = new List<VoucherTypes>();
            VoucherTypes itm = new VoucherTypes();
            itm.StartingNo  = Convert.ToInt64 (uctxtStartingMethod.Text);
            items.Add(itm);
            return items;
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
        private void uctxtStartingMethod_GotFocus(object sender, System.EventArgs e)
        {
            lstPrintSave.Visible = false;
            lstNoMethod.Visible = false;

        }
        private void uctxtStartingMethod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtNuemricalPart.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtStartingMethod, sender, e);
            }
        }

        private void uctxtNuemricalPart_GotFocus(object sender, System.EventArgs e)
        {
            lstPrintSave.Visible = false;
            lstNoMethod.Visible = false;

        }
        private void uctxtNuemricalPart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtPrefix.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtNuemricalPart, sender, e);
            }
        }

        private void uctxtSuffix_GotFocus(object sender, System.EventArgs e)
        {
            lstPrintSave.Visible = false;
            lstNoMethod.Visible = false;

        }
        private void uctxtSuffix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtPrintAfterSavingVoucher.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtSuffix, sender, e);
            }
        }

        private void uctxtPrefix_GotFocus(object sender, System.EventArgs e)
        {
            lstPrintSave.Visible = false;
            lstNoMethod.Visible = false;

        }
        private void uctxtPrefix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtSuffix.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtPrefix, sender, e);
            }
        }
        private void uctxtVoucher_GotFocus(object sender, System.EventArgs e)
        {
            lstPrintSave.Visible = false;
            lstNoMethod.Visible = false;

        }
        private void uctxtVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtNumeringMethod.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtVoucher, sender, e);
            }
        }
        private void uctxtTypeOfVoucher_GotFocus(object sender, System.EventArgs e)
        {
            lstPrintSave.Visible = false;
            lstNoMethod.Visible = false;

        }
        private void uctxtTypeOfVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtVoucher.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtTypeOfVoucher, sender, e);
            }
        }
        private void uctxtPrintAfterSavingVoucher_TextChanged(object sender, EventArgs e)
        {
            lstPrintSave.SelectedIndex = lstPrintSave.FindString(uctxtPrintAfterSavingVoucher.Text);
        }

        private void lstPrintSave_DoubleClick(object sender, EventArgs e)
        {
            uctxtPrintAfterSavingVoucher.Text = lstPrintSave.Text;
            lstPrintSave.Visible = false;
            btnSave.Focus();
        }


        private void uctxtPrintAfterSavingVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstPrintSave.Items.Count > 0)
                {
                    uctxtPrintAfterSavingVoucher.Text = lstPrintSave.Text;
                }
                lstPrintSave.Visible = false;
                btnSave.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtPrintAfterSavingVoucher, sender, e);
            }
        }

        private void uctxtPrintAfterSavingVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstPrintSave.SelectedItem != null)
                {
                    lstPrintSave.SelectedIndex = lstPrintSave.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstPrintSave.Items.Count - 1 > lstPrintSave.SelectedIndex)
                {
                    lstPrintSave.SelectedIndex = lstPrintSave.SelectedIndex + 1;
                }
            }

        }
        private void uctxtPrintAfterSavingVoucher_GotFocus(object sender, System.EventArgs e)
        {
            lstNoMethod.Visible = false ;
            lstPrintSave.Visible = true;
            lstPrintSave.SelectedIndex = lstPrintSave.FindString(uctxtPrintAfterSavingVoucher.Text);
        }


        private void uctxtNumeringMethod_TextChanged(object sender, EventArgs e)
        {
            lstNoMethod.SelectedIndex = lstNoMethod.FindString(uctxtNumeringMethod.Text);
        }

        private void lstNoMethod_DoubleClick(object sender, EventArgs e)
        {
            uctxtNumeringMethod.Text = lstNoMethod.Text;
            uctxtStartingMethod.Focus();
        }


        private void uctxtNumeringMethod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstNoMethod.Items.Count > 0)
                {
                    uctxtNumeringMethod.Text = lstNoMethod.Text;
                }
                uctxtStartingMethod.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtNumeringMethod, sender, e);
            }
        }

        private void uctxtNumeringMethod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstNoMethod.SelectedItem != null)
                {
                    lstNoMethod.SelectedIndex = lstNoMethod.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstNoMethod.Items.Count - 1 > lstNoMethod.SelectedIndex)
                {
                    lstNoMethod.SelectedIndex = lstNoMethod.SelectedIndex + 1;
                }
            }

        }
        private void uctxtNumeringMethod_GotFocus(object sender, System.EventArgs e)
        {
            lstNoMethod.Visible = true;
            lstPrintSave.Visible = false;
            lstNoMethod.SelectedIndex = lstNoMethod.FindString(uctxtNumeringMethod.Text);
        }
        #endregion
        private void mDisplayVoucherTypes()
        {
            if (lngvtype==(long)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER)
            {
                chkBkash.Visible = true;
            }
            List<VoucherTypes> oogrp = accms.mLaodVoucherTypes(strComID, 0, lngvtype).ToList();
            if (oogrp.Count > 0)
            {

                foreach (VoucherTypes ogrp in oogrp)
                {
                    uctxtTypeOfVoucher.Text = ogrp.voucherName;
                    uctxtVoucher.Text = ogrp.voucherName;
                    uctxtNumeringMethod.Text = ogrp.voucherNoMethod;
                    //uctxtNumeringMethod.Text = ogrp.voucherName;
                    uctxtStartingMethod.Text = ogrp.StartingNo.ToString();
                    uctxtNuemricalPart.Text = ogrp.noWidth.ToString();
                    uctxtPrefix.Text = ogrp.Prefix;
                    uctxtSuffix.Text = ogrp.Suffix;
                    if (ogrp.PrintSaving == 2)
                    {
                        uctxtPrintAfterSavingVoucher.Text = "Yes";
                    }
                    else if (ogrp.PrintSaving == 1)
                    {
                        uctxtPrintAfterSavingVoucher.Text = "Preview";
                    }
                    else if (ogrp.PrintSaving == 0)
                    {
                        uctxtPrintAfterSavingVoucher.Text = "No";
                    }
                    if (ogrp.intBkash==1)
                    {
                        chkBkash.Checked = true;
                    }
                    else
                    {
                        chkBkash.Checked =false;
                    }
                }

            }
        }

        private void frmVoucherTypes_Load(object sender, EventArgs e)
        {
            if (lngMtype == (long)Utility.MODULE_TYPE.mtSTOCK)
            {
                frmLabel.Text = "Inventory Voucher Types";
            }
            else if (lngMtype == (long)Utility.MODULE_TYPE.mtACCOUNT)
            {
                frmLabel.Text = "Accounts Voucher Types";
            }
            else if (lngMtype == (long)Utility.MODULE_TYPE.mtSALES)
            {
                frmLabel.Text = "Sales Voucher Types";
            }
            else if (lngMtype == (long)Utility.MODULE_TYPE.mtPURCHASE)
            {
                frmLabel.Text = "Purchase Voucher Types";
            }
            
            mDisplayVoucherTypes();
            LoadDefaultValue();
        }

        private void LoadDefaultValue()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"Automatic", 0},
              {"Manual", 1}
            };

            lstNoMethod.DisplayMember = "Key";
            lstNoMethod.ValueMember = "Value";
            lstNoMethod.DataSource = new BindingSource(userCache, null);

            SortedDictionary<string, int> userCache1 = new SortedDictionary<string, int>
            {
              {"No", 0},
              {"Preview", 1},
               {"Print", 2}
            };

            lstPrintSave.DisplayMember = "Key";
            lstPrintSave.ValueMember = "Value";
            lstPrintSave.DataSource = new BindingSource(userCache1, null);

        }

      
    }
}
