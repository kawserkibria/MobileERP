using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Microsoft.Win32;


namespace JA.Modulecontrolar.UI.Security.Forms
{
    public partial class frmOnlineOrderMapping : JA.Shared.UI.frmJagoronFromSearch
    {

        JACCMS.SWJAGClient accms = new SWJAGClient();
      
        private string strComID { get; set; }
        List<UserAccess> ooUser;
        public frmOnlineOrderMapping()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

          
        }
     
        #region "User Define Event"
       
        #endregion
        private void frmOnlineOrderMapping_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
            uctxtUserID.Focus();

            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "SL No", 70, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("User ID", "User ID", 70, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("PassWord", "PassWord", 80, true , DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Mobile No", "Mobile No", 120, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 220, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Security Code", "Security Code", 220, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Status", "Status", 80, true , DataGridViewContentAlignment.TopLeft, false));
            LoadDefaultValue();
            mloaOnline();
        }

        private void LoadDefaultValue()
        {
           

            SortedDictionary<string, int> userCache2 = new SortedDictionary<string, int>
            {
              {"Active", 0},
              {"Inactive", 1}
              
             
            };

            cboStatus.DisplayMember = "Key";
            cboStatus.ValueMember = "Value";
            cboStatus.DataSource = new BindingSource(userCache2, null);

        }
        private void mloaOnline()
        {
            int introw = 0;
            DG.Rows.Clear();
            //strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            ooUser = accms.mFillOnlineSecurity(strComID).ToList();

            if (ooUser.Count > 0)
            {

                foreach (UserAccess ogrp in ooUser)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.LogInName;
                    DG[2, introw].Value = ogrp.strPassWord;
                    DG[3, introw].Value = ogrp.MobileNo;
                    DG[4, introw].Value = ogrp.LedgerName;
                    DG[5, introw].Value = ogrp.SecurityCode;
                    if (ogrp.intAccessLevel == 0)
                    {
                        DG[6, introw].Value = "Active";
                    }
                    else
                    {
                        DG[6, introw].Value = "Inactive";
                    }
                    introw += 1;
                }

                DG.AllowUserToAddRows = false;
            }
        }

        private void uctxtSeacrh_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListView(ooUser, uctxtSeacrh.Text);
        }


        private void SearchListView(IEnumerable<UserAccess> tests, string searchString)
        {
            IEnumerable<UserAccess> query;
            query = tests;

            if (searchString != "")
            {

                if (lblSearch.Text == "User ID:")
                {
                    query = tests.Where(x => x.LogInName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                }
                else if (lblSearch.Text == "Password:")
                {
                    query = tests.Where(x => x.strPassWord.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                }
                else if (lblSearch.Text == "Mobile No:")
                {
                    query = tests.Where(x => x.MobileNo.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                }
                else if (lblSearch.Text == "Ledger Name:")
                {
                    query = tests.Where(x => x.LedgerName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                }
                
            }
            DG.Rows.Clear();
            int introw = 0;
            try
            {
                foreach (UserAccess ogrp in query)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.LogInName;
                    DG[2, introw].Value = ogrp.strPassWord;
                    DG[3, introw].Value = ogrp.MobileNo;
                    DG[4, introw].Value = ogrp.LedgerName;
                    DG[5, introw].Value = ogrp.SecurityCode;
                    if (ogrp.intAccessLevel == 0)
                    {
                        DG[6, introw].Value = "Active";
                    }
                    else
                    {
                        DG[6, introw].Value = "Inactive";
                    }
                    introw += 1;
                   
                }
                DG.AllowUserToAddRows = false;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DG.Rows.Count > 0)
            {
                long lngSl = Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString());
                txtSLNo.Text = lngSl.ToString();
                uctxtUserID.Text = DG.CurrentRow.Cells[1].Value.ToString();
                uctxtPassword.Text = DG.CurrentRow.Cells[2].Value.ToString();
                uctxtSecurityCode.Text = DG.CurrentRow.Cells[5].Value.ToString();
                cboStatus.Text = DG.CurrentRow.Cells[6].Value.ToString();
                uctxtUserID.Focus();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int intLevel=0;
            if (cboStatus.Text =="Active")
            {
                intLevel=0;
            }
            else
            {
                intLevel=1;
            }
            if (uctxtUserID.Text =="")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtUserID.Focus();
                return;
            }
            if (uctxtPassword.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtPassword.Focus();
                return;
            }
            try
            {
                string i = accms.mUpdateOnLineSecurty(strComID, Convert.ToInt32(txtSLNo.Text), uctxtUserID.Text, uctxtPassword.Text, intLevel,uctxtSecurityCode.Text);
                if (i == "1")
                {
                    MessageBox.Show("Update Successfully..");
                    uctxtPassword.Text = "";
                    uctxtUserID.Text = "";
                    txtSLNo.Text = "";
                    uctxtSecurityCode.Text = "";
                    uctxtUserID.Focus();
                    mloaOnline();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            uctxtUserID.Text = "";
            uctxtPassword.Text = "";
            txtSLNo.Text = "";
            string strInsret = Utility.mInsertOnlineDate(strComID);
            MessageBox.Show(strInsret);
        }

        private void btnSMS_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmOnlineOrderSMS"] as frmOnlineOrderSMS == null)
            {
                frmOnlineOrderSMS objfrm = new frmOnlineOrderSMS();
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;

            }
            else
            {
                frmOnlineOrderSMS objfrm = (frmOnlineOrderSMS)Application.OpenForms["frmOnlineOrderSMS"];
                objfrm.Focus();
                objfrm.MdiParent = this.MdiParent;
            }
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                lblSearch.Text = "User ID:";
            }
            else if (e.ColumnIndex == 2)
            {
                lblSearch.Text = "Password:";
            }
            else if (e.ColumnIndex == 3)
            {
                lblSearch.Text = "Mobile No:";
            }
            else if (e.ColumnIndex == 4)
            {
                lblSearch.Text = "Ledger Name:";
            }
        }

       

    }
}
