using Dutility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JA.Modulecontrolar.JACCMS;

using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Master.Accounts
{
    public partial class frmGroupConfiguration : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();

        private ListBox lstAccountType = new ListBox();
        private ListBox lstUnder = new ListBox();
        private ListBox lstCashFlowType = new ListBox();
        private string mstrOLDGroup { get; set; }
        public int inttype { get; set; }
        public long lngFormPriv { get; set; }
        public int intModuleType { get; set; }
        public string strFoemName { get; set; }
        private string strComID { get; set; }
        public frmGroupConfiguration()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtGroupName.GotFocus += new System.EventHandler(this.txtGroupName_GotFocus);
            this.txtGroupName.LostFocus += new System.EventHandler(this.txtGroupName_LostFocus);
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            this.txtGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGroupName_KeyPress);

            this.txtUnder.GotFocus += new System.EventHandler(this.txtUnder_GotFocus);
            this.txtAccountsType.GotFocus += new System.EventHandler(this.txtAccountsType_GotFocus);
            this.txtCashFlowType.GotFocus += new System.EventHandler(this.txtCashFlowType_GotFocus);

            this.txtUnder.KeyDown += new KeyEventHandler(txtUnder_KeyDown);
            this.txtUnder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUnder_KeyPress);
            this.txtAccountsType.KeyDown += new KeyEventHandler(txtAccountsType_KeyDown);
            this.txtAccountsType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAccountsType_KeyPress);
            this.txtUnder.TextChanged += new System.EventHandler(this.txtUnder_TextChanged);


            this.txtCashFlowType.KeyDown += new KeyEventHandler(txtCashFlowType_KeyDown);
            this.txtCashFlowType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCashFlowType_KeyPress);

            this.lstUnder.DoubleClick += new System.EventHandler(this.lstUnder_DoubleClick);
            this.lstAccountType.DoubleClick += new System.EventHandler(this.lstAccountType_DoubleClick);
            this.lstCashFlowType.DoubleClick += new System.EventHandler(this.lstCashFlowType_DoubleClick);

            this.txtMobileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtMobileNo_KeyPress);
            this.txtMobileNo.GotFocus += new System.EventHandler(this.txtMobileNo_GotFocus);

            this.txtConatctNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtConatctNo_KeyPress);
            this.txtConatctNo.GotFocus += new System.EventHandler(this.txtConatctNo_GotFocus);

            this.txtAccountsType.TextChanged += new System.EventHandler(this.txtAccountsType_TextChanged);
            this.txtCashFlowType.TextChanged += new System.EventHandler(this.txtCashFlowType_TextChanged);

            this.txtSortingPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSortingPos_KeyPress);
            this.txtSortingPos.GotFocus += new System.EventHandler(this.txtSortingPos_GotFocus);

            Utility.CreateListBox(lstAccountType, pnlMain, txtAccountsType);
            Utility.CreateListBox(lstUnder, pnlMain, txtUnder);
            Utility.CreateListBox(lstCashFlowType, pnlMain, txtCashFlowType);
            TabChange();
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
        #region "Tab change
        private void TabChange()
        {
            txtGroupName.Focus();
           
                txtGroupName.AllToNextTab(txtUnder);
                txtUnder.AllToNextTab(txtAccountsType);
                txtAccountsType.AllToNextTab(txtCashFlowType);
                txtCashFlowType.AllToNextTab(btnSave);
           
           

        }
        #endregion
        #region User DefineEvent
        private void txtSortingPos_GotFocus(object sender, System.EventArgs e)
        {
            lstAccountType.Visible = false;
            lstCashFlowType.Visible = false;
            lstUnder.Visible = false;
        }
        private void txtConatctNo_GotFocus(object sender, System.EventArgs e)
        {
            lstAccountType.Visible = false;
            lstCashFlowType.Visible = false;
            lstUnder.Visible = false;
        }
        private void txtMobileNo_GotFocus(object sender, System.EventArgs e)
        {
            lstAccountType.Visible = false;
            lstCashFlowType.Visible = false;
            lstUnder.Visible = false;
        }
        private void txtSortingPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }

        }
        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtConatctNo.Focus();
            }

        }
        private void txtConatctNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtSortingPos.Visible)
                {
                    txtSortingPos.Focus();
                }
                else
                {
                    btnSave.Focus();   
                }
                
            }
            
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

        private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strGroup = "";
            strGroup = txtGroupName.Text.Trim().Replace("'", "''");
            if (e.KeyChar ==(char)Keys.Return)
            {
                if (txtSlNo.Text == "")
                {
                    if (Utility.gIsExistGroup(strComID, strGroup) == true)
                    {
                        txtGroupName.Text = "";
                        MessageBox.Show("Sorry This is Duplicate, Can't Save");
                        txtGroupName.Focus();
                        return;
                    }
                }
                else
                {
                    if (mstrOLDGroup.Trim().ToUpper() != txtGroupName.Text.Trim().ToUpper())
                    {
                        string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGERGROUP", "GR_NAME", txtGroupName.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            txtGroupName.Focus();
                            return;
                        }
                    }
                }
                if (txtUnder.Enabled)
                {
                    txtUnder.Focus();
                }
                else
                {
                    txtCashFlowType.Focus();
                }
            }

        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            int x = txtGroupName.SelectionStart;
            txtGroupName.Text = Utility.gmakeProperCase(txtGroupName.Text);
            txtGroupName.SelectionStart = x;
        }
        private void txtGroupName_LostFocus(object sender, System.EventArgs e)
        {
           
           
        }
        private void txtCashFlowType_TextChanged(object sender, EventArgs e)
        {
            lstCashFlowType.SelectedIndex = lstCashFlowType.FindString(txtCashFlowType.Text);
        }
        private void txtAccountsType_TextChanged(object sender, EventArgs e)
        {
            lstAccountType.SelectedIndex = lstAccountType.FindString(txtAccountsType.Text);
        }
        private void txtUnder_TextChanged(object sender, EventArgs e)
        {
            lstUnder.SelectedIndex = lstUnder.FindString(txtUnder.Text);
        }
        private void lstCashFlowType_DoubleClick(object sender, EventArgs e)
        {
            txtCashFlowType.Text = lstCashFlowType.Text;
            lstCashFlowType.Visible = false;
            if (txtMobileNo.Visible)
            {
                txtMobileNo.Focus();
            }
            else
            {
                btnSave.Focus();
            }
        }
        private void lstAccountType_DoubleClick(object sender, EventArgs e)
        {
            txtAccountsType.Text = lstAccountType.Text;
            txtCashFlowType.Focus();
        }
        private void lstUnder_DoubleClick(object sender, EventArgs e)
        {
            txtUnder.Text = lstUnder.Text;
            lstUnder.Visible = false;
            lstAccountType.Visible = false;
            if (txtMobileNo.Visible)
            {
                txtMobileNo.Focus();
            }
            else
            {
                btnSave.Focus();
            }
        }
        private void txtCashFlowType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCashFlowType.Items.Count > 0)
                {
                    txtCashFlowType.Text = lstCashFlowType.Text;
                }

                if (txtMobileNo.Visible)
                {
                    txtMobileNo.Focus();
                }
                else
                {
                    btnSave.Focus();
                }
                lstCashFlowType.Visible = false;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtCashFlowType, sender, e);
            }
        }
        private void txtCashFlowType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCashFlowType.SelectedItem != null)
                {
                    lstCashFlowType.SelectedIndex = lstCashFlowType.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCashFlowType.Items.Count - 1 > lstCashFlowType.SelectedIndex)
                {
                    lstCashFlowType.SelectedIndex = lstCashFlowType.SelectedIndex + 1;
                }
            }

        }
        private void txtAccountsType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstAccountType.Items.Count > 0)
                {
                    txtAccountsType.Text = lstAccountType.Text;
                }
                
                txtCashFlowType.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtAccountsType, sender, e);
            }
        }
        private void txtAccountsType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstAccountType.SelectedItem != null)
                {
                    lstAccountType.SelectedIndex = lstAccountType.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstAccountType.Items.Count - 1 > lstAccountType.SelectedIndex)
                {
                    lstAccountType.SelectedIndex = lstAccountType.SelectedIndex + 1;
                }
            }

        }
        private void txtUnder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstUnder.Items.Count > 0)
                {
                    txtUnder.Text = lstUnder.Text;
                }
                    lstUnder.Visible = false;
                    lstAccountType.Visible = false;
                    if (txtMobileNo.Visible)
                    {
                        txtMobileNo.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
                    }

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtUnder, sender, e);
            }
        }
        private void txtUnder_KeyDown(object sender, KeyEventArgs e)
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
        private void txtGroupName_GotFocus(object sender, System.EventArgs e)
        {
            lstAccountType.Visible = false;
            lstCashFlowType.Visible = false;
            lstUnder.Visible = false;
        }
        private void txtUnder_GotFocus(object sender, System.EventArgs e)
        {
            lstAccountType.Visible = false;
            lstCashFlowType.Visible = false;
            lstUnder.Visible = true;
            if (inttype == 0)
            {
                lstUnder.DisplayMember = "value";
                lstUnder.ValueMember = "Key";
                lstUnder.DataSource = new BindingSource(accms.GetAccountsGroup(strComID), null);
            }
            else
            {
                lstUnder.ValueMember = "GroupName";
                lstUnder.DisplayMember = "GroupName";
                lstUnder.DataSource = accms.mFillGroup(strComID, inttype).ToList();
            }
            lstUnder.SelectedIndex = lstUnder.FindString(txtUnder.Text);
        }
        private void txtAccountsType_GotFocus(object sender, System.EventArgs e)
        {
            lstAccountType.Visible = true;
            lstCashFlowType.Visible = false;
            lstUnder.Visible = false;
            lstAccountType.SelectedIndex = lstAccountType.FindString(txtAccountsType.Text);
        }
        private void txtCashFlowType_GotFocus(object sender, System.EventArgs e)
        {
            lstAccountType.Visible = false;
            lstCashFlowType.Visible = true;
            lstUnder.Visible = false;
        }
        #endregion
        #region "Account Type"
        private void mAccountType()
        {

            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"Assets", 1},
              {"Liabilities", 2},
              {"Income", 3},
              {"Expenses", 4}
            };

            lstAccountType.DisplayMember = "Key";
            lstAccountType.ValueMember = "Value";
            lstAccountType.DataSource = new BindingSource(userCache, null);

        }
        #endregion
        #region "Cash Flow"
        private void mCashFlow()
        {


            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"End of List", 4},
              {"Operating Activities", 1},
              {"Investing Activities", 2},
              {"Financing Activities", 3}
            };

            lstCashFlowType.DisplayMember = "Key";
            lstCashFlowType.ValueMember = "Value";
            lstCashFlowType.DataSource = new BindingSource(userCache, null);

        }
        #endregion
        #region "Load"
        private void Form1_Load(object sender, EventArgs e)
        {
            lstAccountType.Visible = false;
            lstCashFlowType.Visible = false;
            lstUnder.Visible = false;
            if (inttype == 0)
            {
                lstUnder.DisplayMember = "value";
                lstUnder.ValueMember = "Key";
                lstUnder.DataSource = new BindingSource(accms.GetAccountsGroup(strComID), null);
            }
            else if (inttype==203)
            {

                frmLabel.Text = "Supplier Group";
                lstUnder.ValueMember = "GroupName";
                lstUnder.DisplayMember = "GroupName";
                lstUnder.DataSource = accms.mFillGroup(strComID, inttype).ToList();
            }
            else
            {

                frmLabel.Text = "MPO Group";
                lblContactNo.Visible = true;
                lblMobileNo.Visible = true;
                txtConatctNo.Visible = true;
                txtMobileNo.Visible = true;
                lblSorting.Visible = true;
                txtSortingPos.Visible = true;
                lstUnder.ValueMember = "GroupName";
                lstUnder.DisplayMember = "GroupName";
                lstUnder.DataSource = accms.mFillGroup(strComID, inttype).ToList();
            }
            mAccountType();
            mCashFlow();
        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            short i =0;
            int intGrpPos = 9999;
            if (txtGroupName.Text =="")
            {
                MessageBox.Show("Group Name Cannot be Empty");
                txtGroupName.Focus();
                return;
            }
            if (txtUnder.Text == "")
            {
                MessageBox.Show("Accounts Type Cannot be Empty");
                txtAccountsType.Focus();
                return;
            }
            if (txtCashFlowType.Text =="")
            {
                txtCashFlowType.Text = "Operating Activities";
            }
            else  if (txtCashFlowType.Text == Utility.gcEND_OF_LIST)
            {
                txtCashFlowType.Text = "Operating Activities";
            }
            if (txtSortingPos.Text != "")
            {
                intGrpPos = Convert.ToInt32(txtSortingPos.Text);
            }
            else
            {
                intGrpPos = 9999;
            }

            if (txtSlNo.Text == "")
            {

                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 1))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }

                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGERGROUP", "GR_NAME", txtGroupName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    txtGroupName.Focus();
                    return;
                }
               
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = accms.InsertGroup(strComID, txtGroupName.Text.ToString(), txtUnder.Text.ToString(), txtCashFlowType.Text.ToString(),
                                                txtAccountsType.Text.ToString(),txtMobileNo.Text,txtConatctNo.Text,intGrpPos);

                        if (i == 1)
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFoemName, txtGroupName.Text,
                                                                        1, 0, (int)intModuleType, "0001");
                            }
                            string strUnder = txtUnder.Text;
                            mClear();
                            txtUnder.Text = strUnder;
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
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                if (mstrOLDGroup.Trim().ToUpper() != txtGroupName.Text.Trim().ToUpper())
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_LEDGERGROUP", "GR_NAME", txtGroupName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtGroupName.Focus();
                        return;
                    }
                }


                var strResponseUpdate = MessageBox.Show("Do You  Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseUpdate == DialogResult.Yes)
                {
                    try
                    {
                        i = accms.mUpdateGroup(strComID, Convert.ToUInt32(txtSlNo.Text.ToString()), txtGroupName.Text.ToString(), txtUnder.Text.ToString(),
                                                txtCashFlowType.Text.ToString(), txtAccountsType.Text.ToString(), txtMobileNo.Text, txtConatctNo.Text,intGrpPos);

                        if (i == 1)
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFoemName, txtGroupName.Text,
                                                                        2, 0, (int)intModuleType, "0001");
                            } 
                            mClear();
                            frmGroupConfigurationList objfrm = new frmGroupConfigurationList();
                            objfrm.lngFormPriv = lngFormPriv;
                            objfrm.intModuleType = intModuleType;
                            objfrm.strFormName = strFoemName;
                            objfrm.intGroup = inttype;
                            objfrm.onAddAllButtonClicked = new frmGroupConfigurationList.AddAllClick(DisplayReqList);
                            objfrm.Show();
                            objfrm.MdiParent = MdiParent;
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
            
            //frmTreeView objfrm = new frmTreeView();
            //objfrm.MdiParent = this.MdiParent;
            //if (inttype >0)
            //{
            //    if (inttype == 203)
            //    {
            //        objfrm.strType = "C";
            //    }
            //    else
            //    {
            //        objfrm.strType = "M";
            //    }
            //}
            //else
            //{
            //    objfrm.strType = "";
            //}
            //objfrm.Show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmGroupConfigurationList objfrm = new frmGroupConfigurationList();
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.intModuleType = intModuleType;
            objfrm.strFormName = strFoemName;
            objfrm.intGroup = inttype;
            objfrm.onAddAllButtonClicked = new frmGroupConfigurationList.AddAllClick(DisplayReqList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            txtGroupName.Text = "";
            txtAccountsType.Text = "";
            txtCashFlowType.Text = "";
            txtUnder.Text = "";
            txtSlNo.Text = "";
            txtMobileNo.Text = "";
            txtConatctNo.Text = "";
            txtSortingPos.Text = "";
            txtGroupName.Focus();
        }
        #endregion
        #region "Display List"
        private void DisplayReqList(List<AccountdGroup> tests, object sender, EventArgs e)
        {
            try
            {
                foreach (AccountdGroup ts in tests)
                {
                    txtSlNo.Text = ts.lngSlNo.ToString();
                    mstrOLDGroup = ts.GroupName;
                    txtGroupName.Text = ts.GroupName;
                    txtCashFlowType.Enabled  = false;
                    txtAccountsType.Enabled = false;
                    if (ts.lngGrLevel == 1)
                    {
                        txtUnder.Text = "Primary";
                    }
                    else
                    {
                        txtUnder.Text = ts.ParentName;
                    }
                    if (ts.intPrimaryType == 1)
                    {
                        txtAccountsType.Text = "Assets";
                    }
                    else if (ts.intPrimaryType==2)
                    {
                        txtAccountsType.Text = "Liabilities";
                    }
                    else if (ts.intPrimaryType == 3)
                    {
                        txtAccountsType.Text = "Income";
                    }
                    else if (ts.intPrimaryType == 4)
                    {
                        txtAccountsType.Text = "Expenses";
                    }

                  
                    if (ts.intCashFlowType  == 1)
                    {
                        txtCashFlowType.Text ="Operating Activities";
                    }
                    else if (ts.intCashFlowType == 2)
                    {
                        txtCashFlowType.Text ="Investing Activities";
                    }
                    else if (ts.intCashFlowType == 3)
                    {
                        txtCashFlowType.Text ="Financing Activities";
                    }
                    else 
                    {
                        txtCashFlowType.Text ="End of List";
                    }
                    txtMobileNo.Text = ts.strMobileNo;
                    txtConatctNo.Text = ts.strContactNo;
                    txtSortingPos.Text = ts.intMode.ToString();
                    txtGroupName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

     













    }
}
