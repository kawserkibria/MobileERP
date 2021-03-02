using Dutility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Accms.Forms;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Forms;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSalesRepresentive : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstUnder = new ListBox();
        private ListBox lstcommType = new ListBox();
        private ListBox lstSalesRepresentive = new ListBox();
        private ListBox lstTeritorryCode = new ListBox();
        private ListBox lstInactive = new ListBox();
        public long lngFormPriv { get; set; }
        private long  mlngSlNo{get;set;}
        private string mstrOldLedger {get;set;}
        private string mstrOldCpCode { get; set; }
        private string mstrOldSales { get; set; }
        public int m_action { get; set; }
        private string strComID { get; set; }

        public frmSalesRepresentive()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User InI"
            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.LostFocus += new System.EventHandler(this.uctxtLedgerName_LostFocus);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);
            this.uctxtDrcr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDrcr_KeyPress);
            this.uctxtCommission.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCommission_KeyPress);
            this.uctxtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAddress_KeyPress);
            this.uctxtAddress2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAddress2_KeyPress);
            this.uctxttargetAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxttargetAmount_KeyPress);
            this.uctxtcpCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uctxtcpCode_KeyDown);

            this.uctxtcpCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtcpCode_KeyPress);
            this.uctxtcpCode.GotFocus += new System.EventHandler(this.uctxtcpCode_GotFocus);

            this.uctxthomoeohall.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxthomoeohall_KeyPress);
            this.uctxthomoeohall.GotFocus += new System.EventHandler(this.uctxthomoeohall_GotFocus);
            this.uctxtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPhone_KeyPress);
            this.uctxtComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtComments_KeyPress);

            this.uctxtUnder.KeyDown += new KeyEventHandler(uctxtUnder_KeyDown);
            this.uctxtUnder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtUnder_KeyPress);
            this.uctxtUnder.TextChanged += new System.EventHandler(this.uctxtUnder_TextChanged);
            this.lstUnder.DoubleClick += new System.EventHandler(this.lstUnder_DoubleClick);
            this.uctxtUnder.GotFocus += new System.EventHandler(this.uctxtUnder_GotFocus);

            this.uctxtCommType.KeyDown += new KeyEventHandler(uctxtCommType_KeyDown);
            this.uctxtCommType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCommType_KeyPress);
            this.uctxtCommType.TextChanged += new System.EventHandler(this.uctxtCommType_TextChanged);
            this.lstcommType.DoubleClick += new System.EventHandler(this.lstcommType_DoubleClick);
            this.uctxtCommType.GotFocus += new System.EventHandler(this.uctxtCommType_GotFocus);

            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);
           // this.uctxtSalesRep.GotFocus += new System.EventHandler(this.uctxtSalesRep_GotFocus);
            this.uctxtCommission.GotFocus += new System.EventHandler(this.uctxtCommission_GotFocus);
           
            this.uctxtAddress.GotFocus += new System.EventHandler(this.uctxtAddress_GotFocus);
            this.uctxtAddress2.GotFocus += new System.EventHandler(this.uctxtAddress2_GotFocus);
            this.uctxttargetAmount.GotFocus += new System.EventHandler(this.uctxttargetAmount_GotFocus);
           
            this.uctxtComments.GotFocus += new System.EventHandler(this.uctxtComments_GotFocus);

            this.uctxtSalesRep.KeyDown += new KeyEventHandler(uctxtSalesRep_KeyDown);
            this.uctxtSalesRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSalesRep_KeyPress);
            this.uctxtSalesRep.TextChanged += new System.EventHandler(this.uctxtSalesRep_TextChanged);
            this.lstSalesRepresentive.DoubleClick += new System.EventHandler(this.lstSalesRepresentive_DoubleClick);
            this.uctxtSalesRep.GotFocus += new System.EventHandler(this.uctxtSalesRep_GotFocus);

            this.uctxtTerritoryCode.GotFocus += new System.EventHandler(this.uctxtTerritoryCode_GotFocus);
            this.uctxtTerritoryCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTerritoryCode_KeyPress);
            this.uctxtTerritoryCode.KeyDown += new KeyEventHandler(uctxtTerritoryCode_KeyDown);
            this.uctxtTerritoryCode.TextChanged += new System.EventHandler(this.uctxtTerritoryCode_TextChanged);
            this.lstTeritorryCode.DoubleClick += new System.EventHandler(this.lstTeritorryCode_DoubleClick);

            this.uctxtInactive.KeyDown += new KeyEventHandler(uctxtInactive_KeyDown);
            this.uctxtInactive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtInactive_KeyPress);
            this.uctxtInactive.TextChanged += new System.EventHandler(this.uctxtInactive_TextChanged);
            this.lstInactive.DoubleClick += new System.EventHandler(this.lstInactive_DoubleClick);
            this.uctxtInactive.GotFocus += new System.EventHandler(this.uctxtInactive_GotFocus);

            Utility.CreateListBox(lstUnder, pnlMain, uctxtUnder);
            Utility.CreateListBox(lstInactive, pnlMain, uctxtInactive);      
            Utility.CreateListBox(lstSalesRepresentive, pnlMain, uctxtSalesRep);
            Utility.CreateListBox(lstTeritorryCode, pnlMain, uctxtTerritoryCode);
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
        private void uctxtLedgerName_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtLedgerName.SelectionStart;
            uctxtLedgerName.Text = Utility.gmakeProperCase(uctxtLedgerName.Text);
            uctxtLedgerName.SelectionStart = x;
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
        #region "User Define"
        private void uctxtInactive_TextChanged(object sender, EventArgs e)
        {
            lstInactive.SelectedIndex = lstInactive.FindString(uctxtInactive.Text);
        }

        private void lstInactive_DoubleClick(object sender, EventArgs e)
        {
            uctxtInactive.Text = lstInactive.Text;
            lstInactive.Visible = false;
            uctxtComments.Focus();
        }

        private void uctxtInactive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstInactive.Items.Count > 0)
                {
                    uctxtInactive.Text = lstInactive.Text;
                }
                lstInactive.Visible = false;
                uctxtComments.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtInactive, sender, e);
            }
        }
        private void uctxtInactive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstInactive.SelectedItem != null)
                {
                    lstInactive.SelectedIndex = lstInactive.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstInactive.Items.Count - 1 > lstInactive.SelectedIndex)
                {
                    lstInactive.SelectedIndex = lstInactive.SelectedIndex + 1;
                }
            }

        }

        private void uctxtInactive_GotFocus(object sender, System.EventArgs e)
        {
           
            lstUnder.Visible = false;
            lstInactive.Visible = true;
            lstcommType.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstTeritorryCode.Visible = false;
            lstInactive.SelectedIndex = lstInactive.FindString(uctxtInactive.Text);
        }
        private void uctxtTerritoryCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstTeritorryCode.Items.Count > 0)
                {
                    if (uctxtTerritoryCode.Text != "")
                    {
                        uctxtTeritorryName.Text = "";
                        //uctxtSalesRep.Text = "";
                        if (mstrOldSales!=uctxtTerritoryCode.Text)
                        {
                            uctxtSalesRep.Text = "";
                        }
                        uctxtTerritoryCode.Text = lstTeritorryCode.Text;
                        uctxtTeritorryName.Text = Utility.GetTeritorryName(strComID, uctxtTerritoryCode.Text);
                    }
                }
               
                    uctxtSalesRep.Focus();
               
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtTerritoryCode, sender, e);
            }
        }
        private void uctxtTerritoryCode_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstTeritorryCode.Visible = true;
            lstSalesRepresentive.Visible = false;
            lstcommType.Visible = false;
            lstInactive.Visible = false;
            lstTeritorryCode.SelectedIndex = lstTeritorryCode.FindString(uctxtTerritoryCode.Text);
        }
        private void uctxtTerritoryCode_TextChanged(object sender, EventArgs e)
        {

            lstTeritorryCode.SelectedIndex = lstTeritorryCode.FindString(uctxtTerritoryCode.Text);
        }

        private void lstTeritorryCode_DoubleClick(object sender, EventArgs e)
        {
            uctxtTerritoryCode.Text = lstTeritorryCode.Text;
            if (uctxtTerritoryCode.Text != "")
            {
                uctxtTeritorryName.Text = "";
                if (mstrOldSales != uctxtTerritoryCode.Text)
                {
                    uctxtSalesRep.Text = "";
                }
               
                uctxtTerritoryCode.Text = lstTeritorryCode.Text;
                uctxtTeritorryName.Text = Utility.GetTeritorryName(strComID, uctxtTerritoryCode.Text);
            }
            uctxtSalesRep.Focus();
        }


        private void uctxtTerritoryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstTeritorryCode.SelectedItem != null)
                {
                    lstTeritorryCode.SelectedIndex = lstTeritorryCode.SelectedIndex - 1;
                    uctxtTerritoryCode.Text = lstTeritorryCode.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstTeritorryCode.Items.Count - 1 > lstTeritorryCode.SelectedIndex)
                {
                    lstTeritorryCode.SelectedIndex = lstTeritorryCode.SelectedIndex + 1;
                    uctxtTerritoryCode.Text = lstTeritorryCode.Text;
                }
            }

        }


       
        private void uctxthomoeohall_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstcommType.Visible = false;
            lstTeritorryCode.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstInactive.Visible = false;
        }
        private void uctxthomoeohall_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtUnder.Focus();

            }
        }
        private void uctxtLedgerName_LostFocus(object sender, System.EventArgs e)
        {
            //if (m_action == 1)
            //{
            //    if (Utility.gIsExistLedger(strComID, uctxtLedgerName.Text.ToString()))
            //    {
            //        MessageBox.Show("Sorry This is Duplicate, Can't Save");
                   
            //        uctxtLedgerName.Focus();
            //        return;

            //    }
            //}
         
        }
        private void uctxtSalesRep_TextChanged(object sender, EventArgs e)
        {
            lstSalesRepresentive.SelectedIndex = lstSalesRepresentive.FindString(uctxtSalesRep.Text);
        }

        private void lstSalesRepresentive_DoubleClick(object sender, EventArgs e)
        {
            uctxtSalesRep.Text = lstSalesRepresentive.Text;
            //if (uctxtTerritoryCode.Text == "")
            //{
            uctxtTerritoryCode.Text = Utility.GetTeritorryCodeFromLedgerName(strComID, uctxtSalesRep.Text);
            uctxtTeritorryName.Text = Utility.GetTeritorryName(strComID, uctxtTerritoryCode.Text);
            //}
            uctxtAddress.Focus();
        }

        private void uctxtSalesRep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstSalesRepresentive.Text !="")
                {
                    uctxtSalesRep.Text = lstSalesRepresentive.Text;
                    //if (uctxtTerritoryCode.Text =="")
                    //{
                    uctxtTerritoryCode.Text = Utility.GetTeritorryCodeFromLedgerName(strComID, uctxtSalesRep.Text);
                    uctxtTeritorryName.Text = Utility.GetTeritorryName(strComID, uctxtTerritoryCode.Text);
                    //}
                }
                uctxtAddress.Focus();
              

            }
        }
        private void uctxtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstSalesRepresentive.SelectedItem != null)
                {
                    lstSalesRepresentive.SelectedIndex = lstSalesRepresentive.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstSalesRepresentive.Items.Count - 1 > lstSalesRepresentive.SelectedIndex)
                {
                    lstSalesRepresentive.SelectedIndex = lstSalesRepresentive.SelectedIndex + 1;
                }
            }

        }

        private void uctxtSalesRep_GotFocus(object sender, System.EventArgs e)
        {
            
            lstSalesRepresentive.Visible = true;
            lstUnder.Visible = false;
            lstcommType.Visible = false;
            lstTeritorryCode.Visible = false;
            lstInactive.Visible = false;
            //lstSalesRepresentive.DisplayMember = "value";
            //lstSalesRepresentive.ValueMember = "Key";
            //lstSalesRepresentive.DataSource = new BindingSource(invms.mFillSalesRepLedger((long)Utility.GR_GROUP_TYPE.grCUSTOMER), null);
            try
            {
                if (uctxtTerritoryCode.Text != "")
                {
                    lstSalesRepresentive.DisplayMember = "strLedgerName";
                    lstSalesRepresentive.ValueMember = "strLedgerName";
                    lstSalesRepresentive.DataSource = invms.GetMPONameFromTC(strComID, uctxtTerritoryCode.Text).ToList();
                }
                else
                {
                    lstSalesRepresentive.DisplayMember = "value";
                    lstSalesRepresentive.ValueMember = "Key";
                    lstSalesRepresentive.DataSource = new BindingSource(invms.mFillSalesRepLedger(strComID, (long)Utility.GR_GROUP_TYPE.grCUSTOMER), null);
                }


                lstSalesRepresentive.SelectedIndex = lstSalesRepresentive.FindString(uctxtSalesRep.Text);
            }
            catch (Exception ex)
            {

            }
        }
        private void uctxtDrcr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtCommType.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtDrcr, sender, e);
            }
        }
        private void uctxtComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtComments, sender, e);
            }
        }
        private void uctxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtInactive.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtPhone, sender, e);
            }

        }
        private void uctxtcpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strDuplicate = "";
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action ==1)
                {
                    if (uctxtcpCode.Text != "")
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_CODE", uctxtcpCode.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            uctxtcpCode.Text = "";
                            uctxtcpCode.Focus();
                            return;
                        }
                    }
                    //strDuplicate = Utility.mCheckDuplicateItem("ACC_LEDGER", "LEDGER_NAME", uctxtLedgerName.Text);
                    //if (strDuplicate != "")
                    //{
                    //    MessageBox.Show(strDuplicate);
                    //    uctxtLedgerName.Text = "";
                    //    uctxtLedgerName.Focus();
                    //    return;
                    //}
                }
                else
                {
                    if (mstrOldCpCode != uctxtcpCode.Text)
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_CODE", uctxtcpCode.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            uctxtcpCode.Text = "";
                            uctxtcpCode.Focus();
                            return;
                        }
                    }
                    //if (mstrOldLedger != uctxtLedgerName.Text)
                    //{
                    //    strDuplicate = Utility.mCheckDuplicateItem("ACC_LEDGER", "LEDGER_NAME", uctxtLedgerName.Text);
                    //    if (strDuplicate != "")
                    //    {
                    //        MessageBox.Show(strDuplicate);
                    //        uctxtLedgerName.Text = "";
                    //        uctxtLedgerName.Focus();
                    //        return;
                    //    }
                    //}
                }

                uctxtLedgerName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtcpCode, sender, e);
            }
        }
        private void uctxttargetAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtPhone.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxttargetAmount, sender, e);
            }
        }
        private void uctxtAddress2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxttargetAmount.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtAddress2, sender, e);
            }
        }
        private void uctxtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtAddress2.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtAddress, sender, e);
            }
        }
        private void uctxtCommission_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtAddress.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtCommission, sender, e);
            }
        }

        //private void uctxtSalesRep_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Return)
        //    {
        //        uctxtDrcr.Focus();
        //    }
           
        //}
        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 2)
                {
                    if (mstrOldLedger != uctxtLedgerName.Text)
                    {
                        string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_NAME", uctxtLedgerName.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            uctxtLedgerName.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_NAME", uctxtLedgerName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtLedgerName.Focus();
                        return;
                    }
                }

                uctxthomoeohall.Focus();

            }
        }


        private void uctxtCommType_TextChanged(object sender, EventArgs e)
        {
            lstcommType.SelectedIndex = lstcommType.FindString(uctxtCommission.Text);
        }

        private void lstcommType_DoubleClick(object sender, EventArgs e)
        {
            uctxtCommission.Text = lstcommType.Text;
            uctxtCommission.Focus();
        }

        private void uctxtCommType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstcommType.Items.Count > 0)
                {
                    uctxtCommType.Text = lstcommType.Text;
                }
                uctxtCommission.Focus();

            }
        }
        private void uctxtCommType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstcommType.SelectedItem != null)
                {
                    lstcommType.SelectedIndex = lstcommType.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstcommType.Items.Count - 1 > lstcommType.SelectedIndex)
                {
                    lstcommType.SelectedIndex = lstcommType.SelectedIndex + 1;
                }
            }

        }

        private void uctxtCommission_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstcommType.Visible = false;
            lstTeritorryCode.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstInactive.Visible = false;
        }
        private void uctxtComments_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstcommType.Visible = false;
            lstTeritorryCode.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstInactive.Visible = false;
        }
        private void uctxtcpCode_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstcommType.Visible = false;
            lstInactive.Visible = false;
            lstTeritorryCode.Visible = false;
            lstSalesRepresentive.Visible = false;
        }
        private void uctxttargetAmount_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstcommType.Visible = false;
            lstTeritorryCode.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstInactive.Visible = false;
        }
        private void uctxtAddress2_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstcommType.Visible = false;
            lstTeritorryCode.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstInactive.Visible = false;
        }
        private void uctxtAddress_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstcommType.Visible = false;
            lstTeritorryCode.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstInactive.Visible = false;
        }
        private void uctxtCommType_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstcommType.Visible = false;
            lstTeritorryCode.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstInactive.Visible = false;
            lstcommType.SelectedIndex = lstcommType.FindString(uctxtCommission.Text);


        }
        private void uctxtLedgerName_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstcommType.Visible = false;
            lstTeritorryCode.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstInactive.Visible = false;
        }
        //private void uctxtSalesRep_GotFocus(object sender, System.EventArgs e)
        //{
        //    lstUnder.Visible = false;
        //    lstcommType.Visible = false;
        //    lstSalesRepresentive.Visible = false;
        //}


        private void uctxtUnder_TextChanged(object sender, EventArgs e)
        {
            lstUnder.SelectedIndex = lstUnder.FindString(uctxtUnder.Text);
        }

        private void lstUnder_DoubleClick(object sender, EventArgs e)
        {
            uctxtUnder.Text = lstUnder.Text;
            uctxtTerritoryCode.Focus();
        }

        private void uctxtUnder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstUnder.Items.Count > 0)
                {
                    uctxtUnder.Text = lstUnder.Text;
                }
                uctxtTerritoryCode.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtUnder, sender, e);
            }


        }
        private void uctxtUnder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstUnder.SelectedItem != null)
                {
                    lstUnder.SelectedIndex = lstUnder.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstUnder.Items.Count - 1 > lstUnder.SelectedIndex)
                {
                    lstUnder.SelectedIndex = lstUnder.SelectedIndex + 1;
                }
            }

        }

        private void uctxtUnder_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = true;
            lstcommType.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstTeritorryCode.Visible = false;

            lstUnder.SelectedIndex = lstUnder.FindString(uctxtUnder.Text);
        }

        #endregion
        #region "LoadDefaultdate"
        private void LoadDefaultValueStatus()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"No", 1},
              {"Yes", 2}
            };

            lstInactive.DisplayMember = "Key";
            lstInactive.ValueMember = "Value";
            lstInactive.DataSource = new BindingSource(userCache, null);

        }
        #endregion
        #region "Load"
        private void frmSalesRepresentive_Load(object sender, EventArgs e)
        {
            lstTeritorryCode.Visible = false;
            lstUnder.Visible = false;
            lstcommType.Visible = false;
            lstSalesRepresentive.Visible = false;
            lstInactive.Visible = false;
            uctxtcpCode.Focus();
            lstUnder.DisplayMember = "value";
            lstUnder.ValueMember = "Key";
            lstUnder.DataSource = new BindingSource(invms.mFillSalesRep(strComID, (long)Utility.GR_GROUP_TYPE.grSALES_REP), null);
            LoadDefaultValueStatus();
            lstTeritorryCode.ValueMember = "strTeritorrycode";
            lstTeritorryCode.DisplayMember = "strTeritorrycode";
            lstTeritorryCode.DataSource = accms.mFillTeritorry(strComID, "").ToList();
        }
        #endregion
        #region "Default data"
        private void LoadDefaultValue()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"Flat Amount", 1},
              {"Sales Percent", 2}
            };

            lstcommType.DisplayMember = "Key";
            lstcommType.ValueMember = "Value";
            lstcommType.DataSource = new BindingSource(userCache, null);

        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            uctxtLedgerName.Text="";
            uctxtUnder.Text="";
            uctxthomoeohall.Text = "";
            uctxttargetAmount.Text = "";
            uctxtTeritorryName.Text = "";
            uctxtTerritoryCode.Text = "";
            uctxtcpCode.Text = "";
            uctxtSalesRep.Text="";
            uctxtCommission.Text="";
            uctxtCommType.Text="";
            uctxtAddress.Text="";
            uctxtAddress2.Text ="";
            uctxttargetAmount.Text="";
            uctxtcpCode.Text="";
            uctxtPhone.Text="";
            uctxtComments.Text = "";
            uctxtInactive.Text = "No";
            uctxtcpCode.Focus();
                
        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            double dblOpnBalance = 0,dblCommPercent=0;
            string i = "", strAddress1, strAddress2, strPhone, strComments, strDuplicate="";

            int intstatus = 0;
            if (uctxtInactive.Text=="No")
            {
                intstatus = 0;
            }
            else
            {
                intstatus = 1;
            }
            if (uctxtLedgerName.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtLedgerName.Focus();
                return;
            }
            if (uctxtUnder.Text == "")
            {
                MessageBox.Show("Under Cannot be Empty");
                uctxtUnder.Focus();
                return;
            }
            if (uctxtTerritoryCode.Text == "")
            {
                MessageBox.Show("Teritorry Code Cannot be Empty");
                uctxtTerritoryCode.Focus();
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
            if (m_action == 2)
            {
                if (mstrOldLedger != uctxtLedgerName.Text)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_NAME", uctxtLedgerName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtLedgerName.Focus();
                        return;
                    }
                }
                if (mstrOldCpCode != uctxtcpCode.Text)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_CODE", uctxtcpCode.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtcpCode.Focus();
                        return;
                    }
                }
            }
            else
            {
                strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_NAME", uctxtLedgerName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    uctxtLedgerName.Focus();
                    return;
                }
                if (uctxtcpCode.Text != "")
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGER", "LEDGER_CODE", uctxtcpCode.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtcpCode.Focus();
                        return;
                    }
                }
            }

            if (uctxtCommission.Text =="")
            {
                dblCommPercent = 0;
            }
            else
            {
                dblCommPercent = Convert.ToDouble(uctxtCommission.Text);
            }

             if (uctxtAddress.Text =="")
            {
                strAddress1  = "";
            }
            else
            {
                strAddress1 = uctxtAddress.Text;
            }
            if (uctxtAddress2.Text =="")
            {
                strAddress2  = "";
            }
            else
            {
                strAddress2 = uctxtAddress2.Text;
            }
           
          
             if (uctxtComments.Text =="")
            {
                strComments  = "";
            }
            else
            {
                strComments = uctxtComments.Text;
            }
             if (uctxtPhone.Text == "")
             {
                 strPhone = "";
             }
             else
             {
                 strPhone = uctxtPhone.Text;
             }
            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mSaveSalesRepresentive(strComID, uctxtcpCode.Text, uctxtLedgerName.Text, uctxtTerritoryCode.Text, uctxtTeritorryName.Text,
                                                          Utility.Val(uctxttargetAmount.Text), uctxthomoeohall.Text, intstatus, uctxtUnder.Text, uctxtSalesRep.Text, dblOpnBalance, dblCommPercent, uctxtDrcr.Text, 
                                                            uctxtCommType.Text, strAddress1, strAddress2, strComments, "", "", strPhone);

                        if (i == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Doctor/Customer", uctxtLedgerName.Text,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            } 
                            uctxtLedgerName.Focus();
                            mClear();
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                            
                        }
                        else
                        {
                            MessageBox.Show("Error!!!");
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mUpdateSalesRepresentive(strComID, mstrOldLedger, mlngSlNo, uctxtcpCode.Text, uctxtLedgerName.Text, uctxtTerritoryCode.Text, uctxtTeritorryName.Text,
                                                            Utility.Val(uctxttargetAmount.Text), uctxthomoeohall.Text, intstatus, uctxtSalesRep.Text, uctxtUnder.Text, dblOpnBalance, dblCommPercent, uctxtDrcr.Text,
                                                            uctxtCommType.Text, strAddress1, strAddress2, strComments, "", "", strPhone);

                        if (i == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Doctor/Customer", uctxtLedgerName.Text,
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            } 
                            uctxtLedgerName.Focus();
                            mClear();
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                            btnNew.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("Error!!!");
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmTreeView objfrm = new frmTreeView();
            objfrm.strType = "S";
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAccountsLedgerList objfrm = new frmAccountsLedgerList();
            objfrm.mintLedgerGroup = (int)Utility.GR_GROUP_TYPE.grSALES_REP;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = "Doctor/Customer";
            objfrm.onAddAllButtonClicked = new frmAccountsLedgerList.AddAllClick(DisplayReqList);
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }

        #endregion
        #region "Dispay"
        private void DisplayReqList(List<AccountsLedger> tests, object sender, EventArgs e)
        {
            try
            {
                mClear();
                List<AccountsLedger> ooled = accms.mDisplayLedgerList(strComID, tests[0].lngSlno).ToList();
                if (ooled.Count > 0)
                {
                    uctxtcpCode.Focus();
                    mlngSlNo = Convert.ToInt64(tests[0].lngSlno);
                    m_action = 2;
                    uctxtLedgerName.Text = ooled[0].strOldLedgerName;
                    mstrOldLedger = ooled[0].strOldLedgerName;
                    mstrOldCpCode = ooled[0].strLedgerCode;
                    uctxtcpCode.Text = ooled[0].strLedgerCode;
                    uctxtUnder.Text = ooled[0].strUder;

                    //uctxtSalesRep.Text = Math.Abs(ooled[0].dblOpnBalance).ToString();
                    if (Convert.ToDouble(ooled[0].dblOpnBalance) < 0)
                    {
                        uctxtDrcr.Text = "Dr";
                    }
                    else if (Convert.ToDouble(ooled[0].dblOpnBalance) > 0)
                    {
                        uctxtDrcr.Text = "Cr";
                    }

                    uctxtAddress.Text = ooled[0].strAddress;
                    uctxtAddress2.Text = ooled[0].strAddress2;
                    uctxttargetAmount.Text = ooled[0].strCity;
                    ///uctxtcpCode.Text = ooled[0].strPostalCode;
                    uctxtPhone.Text = ooled[0].strPhone;
                    uctxtComments.Text = ooled[0].strCommnents;
                    if (ooled[0].lngCommType == 1)
                    {
                        uctxtCommType.Text = "Flat Amount";
                    }
                    else if (ooled[0].lngCommType == 2)
                    {
                        uctxtCommType.Text = "Sales Percent";
                    }

                    else if (ooled[0].lngCommType == 3)
                    {
                        uctxtCommType.Text = "Profit Percent";
                    }
                    uctxtSalesRep.Text = ooled[0].strRepName;
                    mstrOldSales = ooled[0].strTeritorryCode;
                    uctxtTerritoryCode.Text = ooled[0].strTeritorryCode;
                    uctxtTeritorryName.Text = ooled[0].strTerritoryName;
                    uctxttargetAmount.Text = ooled[0].dbltargetAmount.ToString();
                    uctxthomoeohall.Text = ooled[0].strhomoeohall.ToString();
                    if (ooled[0].intStatus==0)
                    {
                        uctxtInactive.Text = "No";
                    }
                    else
                    {
                        uctxtInactive.Text = "Yes";
                    }
                }


            }

            catch (Exception ex)
            {

            }
        }
        #endregion

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uctxtcpCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                string strCode = Utility.GetLastLedgeCode(strComID, uctxtcpCode.Text);
                if (strCode !="")
                {
                    uctxtcpCode.Text = "";
                    uctxtcpCode.AppendText(strCode);
                }
            }
        }






    }
}
