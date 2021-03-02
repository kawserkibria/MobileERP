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

namespace JA.Modulecontrolar.UI.Master
{
    public partial class frmSection : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public int m_action { get; set; }
        public int mSingleEntry { get; set; }
        private string strComID { get; set; }
        public frmSection()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtSectionName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSectionName_KeyPress);

        }

        private void uctxtSectionName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strmsg = "";
            if (uctxtSectionName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtSectionName.Focus();
                return;
            }
            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You Want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        try
                        {
                            strmsg = invms.mInsertSection(strComID, uctxtSectionName.Text);
                            txtOldSectionName.Text = "";
                            uctxtSectionName.Text = "";
                            uctxtSectionName.Focus();
                            //MessageBox.Show(strmsg);
                        }
                        catch (Exception EX)
                        {
                            MessageBox.Show(strmsg);
                        }
                    }
                    catch (Exception EX)
                    {

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
                        strmsg = invms.mUpdateSection(strComID, Utility.gCheckNull(txtOldSectionName.Text), Utility.gCheckNull(uctxtSectionName.Text));
                        txtOldSectionName.Text = "";
                        uctxtSectionName.Text = "";
                        uctxtSectionName.Focus();
                        //MessageBox.Show(strmsg);
                        m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(strmsg);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmSectionList objfrm = new frmSectionList();
            objfrm.onAddAllButtonClicked = new frmSectionList.AddAllClick(DisplayList);
            objfrm.MdiParent = MdiParent;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }
        private void DisplayList(List<Section> tests, object sender, EventArgs e)
        {
            try
            {
                txtOldSectionName.Text = "";
                uctxtSectionName.Text = "";
                m_action = 2;
                uctxtSectionName.Text = tests[0].strSection.ToString();
                txtOldSectionName.Text = tests[0].strSection.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



    }
}
