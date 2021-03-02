using Dutility;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Master.Sales
{
    public partial class frmTeritorry : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new JACCMS.SWJAGClient();
        public long lngFormPriv { get; set; }
        public int m_action { get; set; }
        public int mSingleEntry { get; set; }
        public int lngLedgeras { get; set; }
        public string mstrOldName { get; set; }
        public string mstrOldCode { get; set; }
        private string strComID { get; set; }

        public int intVtype { get; set; }
        public frmTeritorry()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtTeritorryName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtTeritorryName_KeyPress);
            this.uctxtTeritorryCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtTeritorryCode_KeyPress);
            this.uctxtTeritorryName.TextChanged += new System.EventHandler(this.uctxtTeritorryName_TextChanged);
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
        #region "Save"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strDuplicate = "",i="";
            if (uctxtTeritorryCode.Text.ToString() == "")
            {
                MessageBox.Show("Code Cannot be Empty");
                uctxtTeritorryCode.Focus();
                return;
            }
            if (uctxtTeritorryName.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtTeritorryName.Focus();
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

                if (mstrOldCode != uctxtTeritorryCode.Text)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_TERITORRY", "TERITORRY_CODE", uctxtTeritorryCode.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtTeritorryCode.Text = "";
                        uctxtTeritorryCode.Focus();
                        return;
                    }
                }
                if (mstrOldName != uctxtTeritorryName.Text)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_TERITORRY", "TERITORRY_NAME", uctxtTeritorryName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtTeritorryName.Text = "";
                        uctxtTeritorryName.Focus();
                        return;
                    }
                }
            }
            else
            {
                strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_TERITORRY", "TERITORRY_CODE", uctxtTeritorryCode.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtTeritorryCode.Text = "";
                        uctxtTeritorryCode.Focus();
                        return;
                    }
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_TERITORRY", "TERITORRY_NAME", uctxtTeritorryName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtTeritorryName.Text = "";
                        uctxtTeritorryName.Focus();
                        return;
                    }

            }

            if (m_action == 1)
            {
               
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = accms.mInsertTeritorry(strComID, uctxtTeritorryCode.Text.ToString().Replace("'", "''"), uctxtTeritorryName.Text.ToString().Replace("'", "''"));

                        if (i == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Teritorry", uctxtTeritorryName.Text.ToString().Replace("'", "''"),
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            } 
                            uctxtTeritorryCode.Focus();
                            uctxtTeritorryCode.Text = "";
                            uctxtTeritorryName.Text = "";
                            
                        }
                        else
                        {
                            MessageBox.Show(i.ToString());
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
                        i = accms.mUpdateTeritorry(strComID, textBox1.Text, uctxtTeritorryName.Text.ToString().Replace("'", "''"));

                        if (i == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Teritorry", uctxtTeritorryName.Text.ToString().Replace("'", "''"),
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            } 
                            btnNew.PerformClick();
                            //uctxtTeritorryCode.Focus();
                            uctxtTeritorryCode.Text = "";
                            uctxtTeritorryName.Text = "";
                            uctxtTeritorryCode.ReadOnly = false;
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                           
                        }
                        else
                        {
                            MessageBox.Show(i.ToString());
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }


        }
        #endregion
        #region "User Define Event"
        private void uctxtTeritorryName_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtTeritorryName.SelectionStart;
            uctxtTeritorryName.Text = Utility.gmakeProperCase(uctxtTeritorryName.Text);
            uctxtTeritorryName.SelectionStart = x;
        }
        private void uctxtTeritorryCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strDuplicate = "";
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 2)
                {
                    if (mstrOldCode != uctxtTeritorryCode.Text)
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_TERITORRY", "TERITORRY_CODE", uctxtTeritorryCode.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            uctxtTeritorryCode.Text = "";
                            uctxtTeritorryCode.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_TERITORRY", "TERITORRY_CODE", uctxtTeritorryCode.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtTeritorryCode.Text = "";
                        uctxtTeritorryCode.Focus();
                        return;
                    }
                }
                uctxtTeritorryName.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtTeritorryCode, sender, e);
            }
        }
        private void uctxtTeritorryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strDuplicate = "";
            if (e.KeyChar==(char)Keys.Return)
            {
                if (m_action == 2)
                {
                    if (mstrOldName != uctxtTeritorryName.Text)
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_TERITORRY", "TERITORRY_NAME", uctxtTeritorryName.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            uctxtTeritorryName.Text = "";
                            uctxtTeritorryName.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_TERITORRY", "TERITORRY_NAME", uctxtTeritorryName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtTeritorryName.Text = "";
                        uctxtTeritorryName.Focus();
                        return;
                    }
                }
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtTeritorryName, sender, e);
            }
        }
        #endregion
        #region "Load"
        private void frmTeritorry_Load(object sender, EventArgs e)
        {
            uctxtTeritorryCode.Select();

        }
        #endregion
        #region "Click"
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmTeritorryList objfrm = new frmTeritorryList();
            objfrm.onAddAllButtonClicked = new frmTeritorryList.AddAllClick(DisplayList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            //uctxtTeritorryCode.Focus();
        }
        #endregion
        #region "Display List"
        private void DisplayList(List<Teritorry> tests, object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                uctxtTeritorryName.Focus();
                uctxtTeritorryCode.ReadOnly = true;
                uctxtTeritorryCode.Text = "";
                uctxtTeritorryName.Text = "";
                m_action = 2;
                textBox1.Text = tests[0].strTeritorrycode.ToString();
                mstrOldCode = tests[0].strTeritorrycode.ToString();
                mstrOldName = tests[0].strTeritorryName.ToString();
                uctxtTeritorryCode.Text = tests[0].strTeritorrycode.ToString();
                uctxtTeritorryName.Text = tests[0].strTeritorryName.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
