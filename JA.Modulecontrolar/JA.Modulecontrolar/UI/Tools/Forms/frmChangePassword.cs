using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
using System.IO;
using System.Drawing.Imaging;

namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmChangePassword : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();

        private string strComID { get; set; }
        private byte[] _imageData;
        public frmChangePassword()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtOldPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtOldPassWord_KeyPress);
            this.uctxtNewPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtNewPassWord_KeyPress);
            this.uctxtRetypePsaaword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtRetypePsaaword_KeyPress);

        }

        private void uctxtOldPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)Keys.Return)
            {
                uctxtNewPassWord.Focus();
            }
        }

        private void uctxtNewPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtRetypePsaaword.Focus();
            }
        }

        private void uctxtRetypePsaaword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string vstrPassword, vstrOldPass;
            if (Utility.gstrUserName == "")
            {
                MessageBox.Show("No User Found");
                return;
            }
            vstrOldPass = Utility.gstrGetOldPassWord(strComID, Utility.gstrUserName);
            //vstrOldPass = Utility.Decrypt(strstring, Utility.gstrUserName);
            //Utility.Decrypt(rsget["USER_PASS"].ToString(), rsget["USER_LOGIN_NAME"].ToString()).ToString();

            if (vstrOldPass.Trim() != uctxtOldPassWord.Text.Trim())
            {
                MessageBox.Show("Old PassWord is Mismatch");
                uctxtOldPassWord.Focus();
                return;
            }
           
            var strResponseInsert = MessageBox.Show("Do You  want to Change Password?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                vstrPassword = Utility.Encrypt(uctxtNewPassWord.Text, uctxtLogInName.Text);
                string strResponse = accms.mChangePasswod(strComID, Utility.gstrUserName, vstrPassword);
                MessageBox.Show(strResponse);
                uctxtRetypePsaaword.Text = "";
                uctxtNewPassWord.Text = "";
                uctxtOldPassWord.Text = "";
                uctxtOldPassWord.Focus();
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            uctxtLogInName.Text = Utility.gstrUserName;
        }
    }


}

