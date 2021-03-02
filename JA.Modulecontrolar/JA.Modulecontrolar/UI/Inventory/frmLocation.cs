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
    public partial class frmLocation : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstUnder = new ListBox();
        private ListBox lstBranch = new ListBox();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWIS = new SPWOIS();
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int m_action { get; set; }
        private string mstrOldLocation { get; set; }
        private string strComID { get; set; }
        public frmLocation()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.txtLocationName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLocationName_KeyPress);
            this.txtLocationName.GotFocus += new System.EventHandler(this.txtLocationName_GotFocus);
            this.txtLocationName.TextChanged += new System.EventHandler(this.txtLocationName_TextChanged);

            this.txtAddress1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAddress1_KeyPress);
            this.txtAddress1.GotFocus += new System.EventHandler(this.txtAddress1_GotFocus);

            this.txtAddress2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAddress2_KeyPress);
            this.txtAddress2.GotFocus += new System.EventHandler(this.txtAddress2_GotFocus);

            this.txtCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCity_KeyPress);
            this.txtCity.GotFocus += new System.EventHandler(this.txtCity_GotFocus);

            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtPhone_KeyPress);
            this.txtPhone.GotFocus += new System.EventHandler(this.txtPhone_GotFocus);

            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtFax_KeyPress);
            this.txtFax.GotFocus += new System.EventHandler(this.txtFax_GotFocus);

            this.txtUnder.KeyDown += new KeyEventHandler(txtUnder_KeyDown);
            this.txtUnder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUnder_KeyPress);
            this.txtUnder.TextChanged += new System.EventHandler(this.txtUnder_TextChanged);
            this.lstUnder.DoubleClick += new System.EventHandler(this.lstUnder_DoubleClick);
            this.txtUnder.GotFocus += new System.EventHandler(this.txtUnder_GotFocus);

            this.txtBranch.KeyDown += new KeyEventHandler(txtBranch_KeyDown);
            this.txtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBranch_KeyPress);
            this.txtBranch.TextChanged += new System.EventHandler(this.txtBranch_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.txtBranch.GotFocus += new System.EventHandler(this.txtBranch_GotFocus);


            Utility.CreateListBox(lstUnder, pnlMain, txtUnder);
            Utility.CreateListBox(lstBranch, pnlMain, txtBranch);
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
        #region "User Define"
        private void txtFax_GotFocus(object sender, System.EventArgs e)
        {

            lstBranch.Visible = false;
            lstUnder.Visible = false;
        }
        private void txtPhone_GotFocus(object sender, System.EventArgs e)
        {

            lstBranch.Visible = false;
            lstUnder.Visible = false;
        }
        private void txtCity_GotFocus(object sender, System.EventArgs e)
        {

            lstBranch.Visible = false;
            lstUnder.Visible = false;
        }
        private void txtAddress2_GotFocus(object sender, System.EventArgs e)
        {

            lstBranch.Visible = false;
            lstUnder.Visible = false;
        }
        private void txtAddress1_GotFocus(object sender, System.EventArgs e)
        {

            lstBranch.Visible = false;
            lstUnder.Visible = false;
        }
        private void txtLocationName_GotFocus(object sender, System.EventArgs e)
        {
          
            lstBranch.Visible = false;
            lstUnder.Visible = false;
        }
        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
            if (e.KeyChar==(char)Keys.Back)
            {
                PriorSetFocusText(txtPhone, sender, e);
            }
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtPhone, sender, e);
            }
        }
        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtPhone.Focus();

            }
        }
        private void txtAddress2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtCity.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtAddress2, sender, e);
            }
        }
        private void txtAddress1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtPhone.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtAddress1, sender, e);
            }
        }
        private void txtLocationName_TextChanged(object sender, EventArgs e)
        {
            int x = txtLocationName.SelectionStart;
            txtLocationName.Text = Utility.gmakeProperCase(txtLocationName.Text);
            txtLocationName.SelectionStart = x;
        }
        private void txtLocationName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 1)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_GODOWNS", "GODOWNS_NAME", txtLocationName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtLocationName.Text = "";
                        txtLocationName.Focus();
                        return;
                    }
                }
                txtBranch.Focus();
            }

        }
        private void txtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(txtBranch.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            txtBranch.Text = lstBranch.Text;
            txtAddress1.Focus();
        }

        private void txtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    txtBranch.Text = lstBranch.Text;
                }
                txtAddress1.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(txtBranch, sender, e);
            }
        }
        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = true;
            lstUnder.Visible = false;
           
            lstBranch.SelectedIndex = lstBranch.FindString(txtBranch.Text);
        }



        private void txtUnder_TextChanged(object sender, EventArgs e)
        {
            lstUnder.SelectedIndex = lstUnder.FindString(txtUnder.Text);
        }

        private void lstUnder_DoubleClick(object sender, EventArgs e)
        {
            txtUnder.Text = lstUnder.Text;
            txtBranch.Focus();
        }

        private void txtUnder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstUnder.Items.Count > 0)
                {
                    txtUnder.Text = lstUnder.Text;
                }
                txtBranch.Focus();

            }
            //if (e.KeyChar == (char)Keys.Back)
            //{
            //    PriorSetFocusText(txtLocationName, sender, e);
            //}
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
            lstUnder.SelectedIndex = lstUnder.FindString(txtUnder.Text);
        }

        #endregion
        #region "Load"
        private void frmLocation_Load(object sender, EventArgs e)
        {
            txtLocationName.Select();
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            LoadDefaultValue();
        }
        #endregion
        #region "DefaultValue"
        private void LoadDefaultValue()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"Primary", 1}
              
            };

            lstUnder.DisplayMember = "Key";
            lstUnder.ValueMember = "Value";
            lstUnder.DataSource = new BindingSource(userCache, null);

           

        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            txtLocationName.Text = "";
            txtUnder.Text = "";
            txtBranch.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtLocationName.Focus();

        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            int intSection = 0;
            string i = "";
            string straddress1,strAddress2,strcity,strPhone,strfax;
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (txtLocationName.Text == "")
            {
                MessageBox.Show("Location Name Cannot be Empty");
                txtLocationName.Focus();
                return;
            }
            if (txtBranch.Text == "")
            {
                MessageBox.Show("Branch Name Cannot be Empty");
                txtUnder.Focus();
                return;
            }
            txtUnder.Text = "Primary";
            txtCity.Text = "Bangladesh";

            if (txtAddress1.Text != "")
            {
                straddress1=txtAddress1.Text;
            }
            else
            {
                straddress1=txtAddress1.Text ;
            }
            if (txtAddress2.Text != "")
            {
                strAddress2=txtAddress2.Text;
            }
            else
            {
                strAddress2=txtAddress2.Text ;
            }
            if (txtCity.Text != "")
            {
                strcity=txtCity.Text;
            }
            else
            {
                strcity=txtCity.Text ;
            }
            if (txtPhone.Text != "")
            {
                strPhone=txtPhone.Text;
            }
            else
            {
                strPhone=txtPhone.Text ;
            }
            if (txtFax.Text != "")
            {
                strfax=txtFax.Text;
            }
            else
            {
                strfax=txtFax.Text ;
            }
            if (chkSection.Checked==true)
            {
                intSection = 1;
            }
            else
            {
                intSection = 0;
            }
            if (m_action == 1)
            {

                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_GODOWNS", "GODOWNS_NAME", txtLocationName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    txtLocationName.Text = "";
                    txtLocationName.Focus();
                    return;
                }
               
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = objWIS.mInsertGodowns(strComID, txtLocationName.Text, txtUnder.Text, txtBranch.Text, straddress1, strAddress2, strcity, strPhone, strfax, intSection);

                        if (i == "Inseretd...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, txtLocationName.Text,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                            }
                            btnNew.PerformClick();
                            mClear();
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                            //mLoadLocationList();
                        }
                        else
                        {
                            MessageBox.Show(i);
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
                if (mstrOldLocation.ToUpper() != txtLocationName.Text.ToUpper())
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_GODOWNS", "GODOWNS_NAME", txtLocationName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtLocationName.Focus();
                        return;
                    }
                }

                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = objWIS.mUpdateGodown(strComID, Convert.ToInt64(txtSlNo.Text), txtLocationName.Text.ToString(),
                                                txtUnder.Text.ToString(), txtBranch.Text, straddress1, strAddress2, strcity, strPhone, strfax, intSection);

                        if (i == "Updated...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, txtLocationName.Text,
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                            }
                            btnNew.PerformClick();
                            mClear();
                            //mLoadLocationList();
                        }
                        else
                        {
                            MessageBox.Show(i);
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (DG.Rows.Count > 0)
            //{
            //    mClear();
            //    m_action = 2;
            //    txtSlNo.Text = DG.CurrentRow.Cells[0].Value.ToString();
            //    List<Location> ooGrp = invms.mDisplayLocation(Convert.ToInt64(DG.CurrentRow.Cells[0].Value)).ToList();
            //    if (ooGrp.Count > 0)
            //    {
            //        txtLocationName.Text = ooGrp[0].strLocation;
            //        txtUnder.Text = ooGrp[0].strParentGroup;
            //        txtBranch.Text = Utility.gstrGetBranchName(ooGrp[0].strBranch);
            //        txtAddress1.Text = ooGrp[0].strAddres1;
            //        txtAddress2.Text = ooGrp[0].strAddres2;
            //        txtCity.Text = ooGrp[0].strCity;
            //        txtPhone.Text = ooGrp[0].strPhone;
            //        txtFax.Text = ooGrp[0].strFax;

            //    }
            //}
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
     
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmLocationList objfrm = new frmLocationList();
            objfrm.onAddAllButtonClicked = new frmLocationList.AddAllClick(DisplayVoucherList);
            objfrm.MdiParent = MdiParent;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }
        #endregion
        #region "Display"
        private void DisplayVoucherList(List<Location> tests, object sender, EventArgs e)
        {
            try
            {
                mClear();
                m_action = 2;
                txtSlNo.Text = tests[0].lngSlNo.ToString();
                List<Location> ooGrp = invms.mDisplayLocation(strComID, Convert.ToInt64(tests[0].lngSlNo)).ToList();
                if (ooGrp.Count > 0)
                {
                    mstrOldLocation = ooGrp[0].strLocation;
                    txtLocationName.Text = ooGrp[0].strLocation;
                    txtUnder.Text = ooGrp[0].strParentGroup;
                    txtBranch.Text = Utility.gstrGetBranchName(strComID, ooGrp[0].strBranch);
                    txtAddress1.Text = ooGrp[0].strAddres1;
                    txtAddress2.Text = ooGrp[0].strAddres2;
                    txtCity.Text = ooGrp[0].strCity;
                    txtPhone.Text = ooGrp[0].strPhone;
                    txtFax.Text = ooGrp[0].strFax;
                    if (ooGrp[0].intSection==1)
                    {
                        chkSection.Checked = true;
                    }
                    else
                    {
                        chkSection.Checked = false;
                    }

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
