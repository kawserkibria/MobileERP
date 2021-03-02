using Dutility;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Security.Forms
{
    public partial class frmOnlineOrderSMS : Form
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        
        public frmOnlineOrderSMS()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            

            this.txtMobileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileNo_KeyPress);
            this.dteImportDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dteImportDate_KeyPress);
           

            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            
        }
       
        private void dteImportDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strText = "", strMobile="";
            if (e.KeyChar == (char)Keys.Return)
            {
                if (chkAll.Checked)
                {
                    List<UserAccess> ooUser = accms.mFillOnlineSecurity(strComID).ToList();
                    if (ooUser.Count > 0)
                    {
                        foreach (UserAccess objUser in ooUser)
                        {

                            strText = strText + "Your User ID :" + objUser.lngSlNo + Environment.NewLine + "Your Password :" + objUser.strPassWord + " " + Environment.NewLine ;
                            strMobile = strMobile + objUser.MobileNo + ",";
                        }

                        textBox1.Text = strText;
                        txtMobileNo.Text = strMobile;
                    }
                }
                else
                {

                }
                btnSendSMS.Focus();
            }

        }
        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                dteImportDate.Focus();
            }

        }
     
        #region "SMS"
        public string SendSMS(string phno, string msg)
        {

            ////string gg = Utility.gInsertSMS(strComID, dteImportDate.Text, phno, txtDivision.Text);
            ////return "1";

            string url = "https://gpcmp.grameenphone.com/gpcmpapi/messageplatform/controller.home?username=DeeplaidADMINN&password=Deeplaid_2000&apicode=1&msisdn=" + phno + "&countrycode=880&cli=DPL%20HR&messagetype=1&message=" + msg + "&messageid=0%20210 ";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {

                response.Close();

                //string jj = Utility.gInsertSMS(strComID, dteImportDate.Text, phno, txtDivision.Text);
                return "Sending Success...";
            }
            else
            {
               // EventLog.WriteEntry("ERROR in Sending Message of Mobile No: " + phno, "" + "Trace", EventLogEntryType.Error, 121, short.MaxValue);
                //Application.Exit();
                return "Sending Failed...";

            }
        }
        #endregion

   

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       

      

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                string strText = "";
                if (txtMobileNo.Text == "")
                {
                    MessageBox.Show("Cannot be Empty");
                    txtMobileNo.Focus();
                    return;
                }

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Cannot be Empty");
                    textBox1.Focus();
                    return;
                }
                string strReturn = "";
                var strResponseInsert = MessageBox.Show("Do You Want to Send SMS ?", "SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    if (txtMobileNo.Text != "")
                    {
                        if (chkAll.Checked)
                        {
                            List<UserAccess> ooUser = accms.mFillOnlineSecurity(strComID).ToList();
                            if (ooUser.Count > 0)
                            {
                                foreach (UserAccess objUser in ooUser)
                                {
                                    strText = "Your User ID :" + objUser.lngSlNo + Environment.NewLine + "Your Password :" + objUser.strPassWord + " ";
                                    strReturn = SendSMS(objUser.MobileNo, strText);
                                }

                            }
                        }
                        else
                        {



                            strReturn = SendSMS(txtMobileNo.Text, textBox1.Text);

                        }

                    }

                    MessageBox.Show(strReturn);
                }
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.ToString());
            }
        }

        private void btnSendSMS_Click_1(object sender, EventArgs e)
        {

        }

        private void frmOnlineOrderSMS_Load(object sender, EventArgs e)
        {

        }

       

    }
}
