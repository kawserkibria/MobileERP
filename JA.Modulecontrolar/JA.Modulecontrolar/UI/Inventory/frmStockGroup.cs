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
using Microsoft.Win32;
using Microsoft.VisualBasic;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmStockGroup : JA.Shared.UI.frmJagoronFromSearch
    {
        private ListBox lstUnder = new ListBox();
        private ListBox lstGroupConfig = new ListBox();

        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public int m_action { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int mSingleEntry { get; set; }
        private string mstrOldGroup { get; set; }
        private string strComID { get; set; }
        public frmStockGroup()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.txtUnder.KeyDown += new KeyEventHandler(txtUnder_KeyDown);
            this.txtUnder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUnder_KeyPress);
            this.txtUnder.TextChanged += new System.EventHandler(this.txtUnder_TextChanged);
            this.lstUnder.DoubleClick += new System.EventHandler(this.lstUnder_DoubleClick);
            this.txtUnder.GotFocus += new System.EventHandler(this.txtUnder_GotFocus);


            this.uctxtGroupConfig.KeyDown += new KeyEventHandler(uctxtGroupConfig_KeyDown);
            this.uctxtGroupConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtGroupConfig_KeyPress);
            this.uctxtGroupConfig.TextChanged += new System.EventHandler(this.uctxtGroupConfig_TextChanged);
            this.lstGroupConfig.DoubleClick += new System.EventHandler(this.lstGroupConfig_DoubleClick);
            this.uctxtGroupConfig.GotFocus += new System.EventHandler(this.uctxtGroupConfig_GotFocus);


            this.txtGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtGroupName_KeyPress);
            this.txtGroupName.GotFocus += new System.EventHandler(this.txtGroupName_GotFocus);
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            this.txtGroupName.KeyDown += new KeyEventHandler(txtGroupName_KeyDown);

            this.cboPackSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboPackSize_KeyPress);
            this.cboPackSize.GotFocus += new System.EventHandler(this.cboPackSize_GotFocus);

            this.cboStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboStatus_KeyPress);
            this.cboStatus.GotFocus += new System.EventHandler(this.cboStatus_GotFocus);

            Utility.CreateListBox(lstUnder, pnlMain, txtUnder);
            Utility.CreateListBox(lstGroupConfig, pnlMain, uctxtGroupConfig);
           
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
        private void PriorSetFocusCombo(ComboBox txtbox, object sender, KeyPressEventArgs e)
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
        private void txtGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                //txtGroupName.AppendText(Interaction.GetSetting(Application.ExecutablePath, "Group", "StockGROUP"));
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                txtGroupName.AppendText((String)rk.GetValue("StockGROUP", ""));
                rk.Close();
            }

        }
        private void cboStatus_GotFocus(object sender, System.EventArgs e)
        {
            
            lstGroupConfig.Visible = false;
            lstUnder.Visible = false;

        }
        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusCombo(cboStatus, sender, e);
            }
        }
        private void cboPackSize_GotFocus(object sender, System.EventArgs e)
        {
            lstGroupConfig.Visible = false;
            lstUnder.Visible = false;

        }
        private void cboPackSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                cboStatus.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusCombo(cboPackSize, sender, e);
            }
        }
        private void uctxtGroupConfig_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtGroupConfig.SelectionStart;
            uctxtGroupConfig.Text = Utility.gmakeProperCase(uctxtGroupConfig.Text);
            uctxtGroupConfig.SelectionStart = x;
            lstGroupConfig.SelectedIndex = lstGroupConfig.FindString(uctxtGroupConfig.Text);
        }

        private void lstGroupConfig_DoubleClick(object sender, EventArgs e)
        {
            uctxtGroupConfig.Text = lstGroupConfig.Text;
            cboPackSize.Focus();
        }
       
        private void uctxtGroupConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtGroupConfig.Text != "")
                {
                    uctxtGroupConfig.Text = lstGroupConfig.Text;
                }
                
                cboPackSize.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtGroupConfig, sender, e);
            }

            
        }
        private void uctxtGroupConfig_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Up)
            {
                if (lstGroupConfig.SelectedItem != null)
                {
                    lstGroupConfig.SelectedIndex = lstGroupConfig.SelectedIndex - 1;
                }
                uctxtGroupConfig.Text = lstGroupConfig.Text;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstGroupConfig.Items.Count - 1 > lstGroupConfig.SelectedIndex)
                {
                    lstGroupConfig.SelectedIndex = lstGroupConfig.SelectedIndex + 1;
                }
                uctxtGroupConfig.Text = lstGroupConfig.Text;
            }

        }

        private void uctxtGroupConfig_GotFocus(object sender, System.EventArgs e)
        {
            lstGroupConfig.Visible = true;
            lstUnder.Visible = false;
            if (uctxtGroupConfig.Text != "")
            {
                lstGroupConfig.SetSelected(0, false);
                lstGroupConfig.SelectedIndex = lstGroupConfig.FindString(uctxtGroupConfig.Text);
            }
           
        }
        private void txtGroupName_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = false;
            lstGroupConfig.Visible = false;

        }
        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            int x = txtGroupName.SelectionStart;
            txtGroupName.Text = Utility.gmakeProperCase(txtGroupName.Text);
            txtGroupName.SelectionStart = x;
        }
        private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 1)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCKGROUP", "STOCKGROUP_NAME", txtGroupName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtGroupName.Text = "";
                        txtGroupName.Focus();
                        return;
                    }
                }
                txtUnder.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtGroupName, sender, e);
            }

        }
        private void txtUnder_TextChanged(object sender, EventArgs e)
        {
            int x = txtUnder.SelectionStart;
            txtUnder.Text = Utility.gmakeProperCase(txtUnder.Text);
            txtUnder.SelectionStart = x;

            lstUnder.SelectedIndex = lstUnder.FindString(txtUnder.Text);
        }

        private void lstUnder_DoubleClick(object sender, EventArgs e)
        {
            txtUnder.Text = lstUnder.Text;
            uctxtGroupConfig.Focus();
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
                uctxtGroupConfig.Focus();

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

        private void txtUnder_GotFocus(object sender, System.EventArgs e)
        {
            lstUnder.Visible = true;
            lstGroupConfig.Visible = false;
            lstUnder.DisplayMember = "value";
            lstUnder.ValueMember = "Key";
            lstUnder.DataSource = new BindingSource(invms.mLoadStockGroup(strComID), null);
            lstUnder.SelectedIndex = lstUnder.FindString(txtUnder.Text);
        }

        #endregion
        #region "Load"
        private void frmGroup_Load(object sender, EventArgs e)
        {
            lstGroupConfig.Visible = false;
            lstUnder.Visible = false;
            txtGroupName.Select();

            lstGroupConfig.DisplayMember = "GroupName";
            lstGroupConfig.ValueMember = "GroupName";
            lstGroupConfig.DataSource = invms.mFillStockGroupconfig(strComID).ToList();
            
           
        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "",strGRName="";
            int intPackSize = 0,intStatus=0;

           // Interaction.SaveSetting(Application.ExecutablePath, "Group", "StockGROUP", txtGroupName.Text);
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
            rk.SetValue("StockGROUP", txtGroupName.Text);
            rk.Close();
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (txtGroupName.Text == "")
            {
                MessageBox.Show("Group Name Cannot be Empty");
                txtGroupName.Focus();
                return;
            }
            if (txtUnder.Text == "")
            {
                MessageBox.Show("Group Under Cannot be Empty");
                txtUnder.Focus();
                return;
            }
            if (uctxtGroupConfig.Text !="")
            {
                strGRName = uctxtGroupConfig.Text;
            }
            else
            {
                strGRName = "";
            }
            if (cboPackSize.Text =="Yes")
            {
                intPackSize = 1;
            }
            else
            {
                intPackSize = 0;
            }
            if (cboStatus.Text == "Yes")
            {
                intStatus  = 0;
            }
            else
            {
                intStatus = 1;
            }
            if (m_action==1)
            {
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCKGROUP", "STOCKGROUP_NAME", txtGroupName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    txtGroupName.Text = "";
                    txtGroupName.Focus();
                    return;
                }


                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mInsertGroup(strComID, txtGroupName.Text.ToString(), txtUnder.Text.ToString(), strGRName, intPackSize, intStatus);

                        if (i == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, txtGroupName.Text,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                            }
                            btnNew.PerformClick();
                            txtGroupName.Focus();
                            //txtUnder.Text = "";
                            txtGroupName.Text = "";
                            txtSlNo.Text = "";
                            uctxtGroupConfig.Text = "";
                            cboPackSize.Text = "No";
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                            //mLoadGroupList();
                            if (mSingleEntry == 1)
                            {
                                mSingleEntry = 0;
                                this.Dispose();
                            }
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
                if (mstrOldGroup != txtGroupName.Text)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_STOCKGROUP", "STOCKGROUP_NAME", txtGroupName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtGroupName.Focus();
                        return;
                    }
                }


                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mUpdateGroup(strComID, Convert.ToInt64(txtSlNo.Text), txtGroupName.Text.ToString(), txtUnder.Text.ToString(), strGRName, intPackSize,intStatus);

                        if (i == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, txtGroupName.Text,
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                            }
                            btnNew.PerformClick();
                            txtGroupName.Focus();
                            txtUnder.Text = "";
                            txtGroupName.Text = "";
                            txtSlNo.Text = "";
                            uctxtGroupConfig.Text = "";
                            cboPackSize.Text = "No";
                            m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;

                            frmStockGroupList objfrm = new frmStockGroupList();
                            objfrm.lngFormPriv = lngFormPriv;
                            objfrm.strFormName = strFormName;
                            objfrm.onAddAllButtonClicked = new frmStockGroupList.AddAllClick(DisplayVoucherList);
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
            frmStockGroupList objfrm = new frmStockGroupList();
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormName = strFormName;
            objfrm.onAddAllButtonClicked = new frmStockGroupList.AddAllClick(DisplayVoucherList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            
           
        }
        private void btnTreeView_Click(object sender, EventArgs e)
        {
            frmStockTree objfrm = new frmStockTree();
            objfrm.strName = "1";
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }
        #endregion
        #region "Display VoucherList"
        private void DisplayVoucherList(List<StockGroup> tests, object sender, EventArgs e)
        {
            try
            {
                txtGroupName.Focus();
                m_action = 2;
                txtSlNo.Text = tests[0].lngslNo.ToString();
                List<StockGroup> ooGrp = invms.mDisplayRecord(strComID, Convert.ToInt64(tests[0].lngslNo)).ToList();
                if (ooGrp.Count > 0)
                {
                    mstrOldGroup = ooGrp[0].GroupName;
                    txtGroupName.Text = ooGrp[0].GroupName;
                    txtUnder.Text = ooGrp[0].GroupUnder;
                    uctxtGroupConfig.Text = ooGrp[0].GrName;
                    cboPackSize.Text = ooGrp[0].strPackSize;
                    cboStatus.Text = ooGrp[0].strStatus ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}
