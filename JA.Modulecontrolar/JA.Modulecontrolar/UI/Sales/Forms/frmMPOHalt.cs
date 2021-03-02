using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JA.Modulecontrolar.UI.Inventory;

using Dutility;

using Microsoft.Win32;
using JA.Modulecontrolar.EXTRA;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmMPOHalt : JA.Shared.UI.frmSmartFormStandard
    {
        //JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient();
        public long lngFormPriv { get; set; }
        public int lngLedgeras { get; set; }
        public string mstrOldDestination { get; set; }
        public int m_action { get; set; }
        public int intVtype { get; set; }
        private string strComID { get; set; }

        public frmMPOHalt()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
         
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
        #region "user Define"
       
        #endregion
        private void frmMPOHalt_Load(object sender, EventArgs e)
        {
           
            List<Mprojection> orptt = objExtra.mGetLedgerGroupLoad(strComID, 1, Utility.gstrUserName).ToList();
            cboMPOHalt.DisplayMember = "strGRName";
            cboMPOHalt.ValueMember = "strGRName";
            cboMPOHalt.DataSource = objExtra.mGetLedgerGroupLoad(strComID, 1, Utility.gstrUserName).ToList();
           
        }

        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strmsg="";
            var strResponseInsert = MessageBox.Show("Do You want to Halt?", "Halt Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                string kk = Utility.gUpdateHaltZone(strComID, cboMPOHalt.Text);
                if (lstRight.Items.Count > 0)
                {
                   
                    for (int i = 0; i < lstRight.Items.Count; i++)
                    {
                        strmsg = Utility.gUpdateHalt(strComID, lstRight.Items[i].ToString());
                    }
                    if (strmsg == "1")
                    {
                        //MessageBox.Show("Halt Successfully...");
                    }
                    else
                    {
                        MessageBox.Show(strmsg);
                    }
                }
                if (kk=="1")
                {
                    MessageBox.Show("Halt Successfully...");
                }
               
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
          
        }
        #endregion

        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstRight.SelectedValue = lstLeft.SelectedValue;
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstLeft.Items.Count; i++)
            {
                string strItem = lstLeft.Items[i].ToString().TrimStart();
                lstRight.Items.Add(strItem);
            }
            lstLeft.Items.Clear();
        }

        private void btnLeftSingle_Click(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight.SelectedItem.ToString());
                lstRight.Items.Remove(lstRight.SelectedItem.ToString());
            }
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                string strItem = lstRight.Items[i].ToString().TrimStart();
                lstLeft.Items.Add(strItem);
            }
            lstRight.Items.Clear();
        }

        private void cboMPOHalt_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            if (cboMPOHalt.SelectedValue.ToString() !="")
            {
                List<Mprojection> objLedger = objExtra.mGetDivisionFromZone(strComID, cboMPOHalt.Text,0).ToList();
                if (objLedger.Count > 0)
                {
                    foreach (Mprojection oPro in objLedger)
                    {
                        lstLeft.Items.Add(oPro.strLedgerNameMerze);
                    }
                }
                List<Mprojection> objLedger1 = objExtra.mGetDivisionFromZone(strComID, cboMPOHalt.Text, 1).ToList();
                if (objLedger.Count > 0)
                {
                    foreach (Mprojection oPro in objLedger1)
                    {
                        lstRight.Items.Add(oPro.strLedgerNameMerze);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Return)
            {
                btnRightSingle.PerformClick();
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }
      

      
    }
}
