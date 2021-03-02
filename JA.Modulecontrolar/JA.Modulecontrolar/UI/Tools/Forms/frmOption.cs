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
using Microsoft.Win32;
using Microsoft.VisualBasic;

namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmOption : Form
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private string strComID { get; set; }
        public frmOption()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }
       
        private void btnOK_Click(object sender, EventArgs e)
        {
            int intNegetive = 0;
            if (chkNegetaive.Checked==true)
            {
                intNegetive = 1;
            }

            string strReponse = invms.mUpdateOption(strComID, intNegetive);
            if (strReponse=="1")
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show(strReponse);
            }

           
        }

        private void frmSelectCompany_Load(object sender, EventArgs e)
        {
             List<InvoiceConfig> oinv = invms.mGetInvoiceConfig(strComID).ToList();
            if (oinv.Count>0)
            {
                if (oinv[0].mlngBlockNegativeStock==1)
                {
                    chkNegetaive.Checked = true;
                }
                else
                {
                    chkNegetaive.Checked = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lvDetails_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(sender, e);
        }



    }
}
