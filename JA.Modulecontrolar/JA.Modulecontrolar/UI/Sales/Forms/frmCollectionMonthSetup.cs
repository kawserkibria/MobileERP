using Dutility;
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

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmCollectionMonthSetup : JA.Shared.UI.frmSmartFormStandard
    {
      
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string mstrOldMonthId { get; set; }
        public long lngFormPriv { get; set; }
        private string mstrOlActive { get; set; }
        public int m_action { get; set; }
        private string strComID { get; set; }
        public frmCollectionMonthSetup()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteFromdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromdate_KeyPress);
            this.dteTodate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteTodate_KeyPress);
            this.uctxtMonthID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMonthID_KeyPress);
            this.uctxtMonthID.TextChanged += new System.EventHandler(this.uctxtMonthID_TextChanged);
            this.cboStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboStatus_KeyPress);
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
        #region "User Deifine"

        private void uctxtMonthID_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtMonthID.SelectionStart;
            uctxtMonthID.Text = Utility.gmakeProperCase(uctxtMonthID.Text).ToUpper();
            uctxtMonthID.SelectionStart = x;
        }
        private void dteFromdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteTodate.Focus();
            }
        }
        private void dteTodate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                cboStatus.Focus();
            }
        }
        private void uctxtMonthID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteFromdate.Focus();
            }
        }
        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
        }
        #endregion
        private void frmCollectionMonthSetup_Load(object sender, EventArgs e)
        {
            uctxtMonthID.Select();
            uctxtMonthID.Focus();
        }
        #region "click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (uctxtMonthID.Text =="")
            {
                MessageBox.Show("Month ID Cannot be Empty");
                uctxtMonthID.Focus();
                return;
            }

            string strMonth = Utility.Left(uctxtMonthID.Text, 3);
            int intfromMonth = dteFromdate.Value.Month;
            string strFnonth = Utility.GetMonth(intfromMonth);
            if (strMonth.ToUpper() != strFnonth.ToUpper())
            {
                MessageBox.Show("From Date is not in This Month");
                dteFromdate.Focus();
                return;
            }
            long lngDate = Convert.ToInt64(dteFromdate.Value.ToString("yyyyMMdd"));
            long lngtodate = Convert.ToInt64(dteTodate.Value.ToString("yyyyMMdd"));

            if (lngtodate < lngDate)
            {
                MessageBox.Show("To Date, Date Can't less then from Date");
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


            if (m_action == 1)
            {

                List<AccountdGroup> oogrp = accms.mDisplayMonthsetupList(strComID, uctxtMonthID.Text).ToList();
                {
                    if (oogrp.Count>0)
                    {
                        if (oogrp[0].strStstus == cboStatus.Text)
                        {
                            MessageBox.Show("only One Month Active at a Time");
                            uctxtMonthID.Focus();
                            return;
                        }
                    }
                }

                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_MONTH_SETUP", "MONTH_ID", uctxtMonthID.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            uctxtMonthID.Focus();
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                            return;
                        }

                        string strmsg = accms.mSaveMonthConfig(strComID, uctxtMonthID.Text, dteFromdate.Text, dteTodate.Text, cboStatus.Text);
                        if (strmsg == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Collection Month Setup",uctxtMonthID.Text,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            }
                            mClear();
                        }
                        else
                        {
                            MessageBox.Show(strmsg);
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
                var strResponseUpdate = MessageBox.Show("Do You  want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseUpdate == DialogResult.Yes)
                {
                    try
                    {
                        if (mstrOldMonthId != uctxtMonthID.Text)
                        {
                            string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_MONTH_SETUP", "MONTH_ID", uctxtMonthID.Text);
                            if (strDuplicate != "")
                            {
                                MessageBox.Show(strDuplicate);
                                uctxtMonthID.Focus();
                                return;
                            }
                        }
                        if (mstrOlActive != cboStatus.Text)
                        {
                            List<AccountdGroup> oogrp = accms.mDisplayMonthsetupList(strComID, uctxtMonthID.Text).ToList();
                            {
                                if (oogrp.Count > 0)
                                {
                                    if (oogrp[0].strStstus == cboStatus.Text)
                                    {
                                        MessageBox.Show("only One Month Active at a Time");
                                        uctxtMonthID.Focus();
                                        return;
                                    }
                                }
                            }
                        }


                        string strmsg = accms.mUpdateMonthConfig(strComID, mstrOldMonthId, uctxtMonthID.Text, dteFromdate.Text, dteTodate.Text, cboStatus.Text);
                        if (strmsg == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Collection Month Setup", uctxtMonthID.Text,
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            }
                            mClear();
                        }
                        else
                        {
                            MessageBox.Show(strmsg);
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

            mClear();
            frmCollectionMonthSetupList objfrm = new frmCollectionMonthSetupList();
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.onAddAllButtonClicked = new frmCollectionMonthSetupList.AddAllClick(DisplayList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;

        }

        private void DisplayList(List<AccountdGroup> tests, object sender, EventArgs e)
        {
            try
            {
                m_action = 2;
                mstrOldMonthId = tests[0].strMonthID;
                uctxtMonthID.Text = tests[0].strMonthID;
                dteFromdate.Text = tests[0].strFromdate;
                dteTodate.Text = tests[0].strTodate;
                cboStatus.Text = tests[0].strStstus;
                mstrOlActive = tests[0].strStstus;


            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        private void mClear()
        {
            uctxtMonthID.Text = "";
            cboStatus.Text = "Active";
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            uctxtMonthID.Focus();
        }
       




















    }
}
