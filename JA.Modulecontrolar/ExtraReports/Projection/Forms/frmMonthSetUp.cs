
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Dutility;
using ExtraReports.EXTRA;
using System.Drawing.Drawing2D;
//using EX.Projection.Model;


namespace ExtraReports.Projection.Forms
{
 
    public partial class frmMonthSetUp : JA.Shared.UI.frmSmartFormStandard
    {
        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient();
        private ListBox lstLedger = new ListBox();
        private ListBox lstStatus = new ListBox();

        public delegate void AddAllClick(List<ProjectonMonthConfig> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public string strStatusType = "";
        public string mstrmonthId { get; set; }
        public long lngFormPriv;
        public int intStatus = 0;
        public int mintOldStatus = 0;
       
        public int m_action { get; set; }
        private string strComID { get; set; }
        public frmMonthSetUp()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtMonthID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonthID_KeyPress);
            this.txtMonthID.GotFocus += new System.EventHandler(this.txtMonthID_GotFocus);
            this.txtMonthID.KeyDown += new KeyEventHandler(txtMonthID_KeyDown);
            this.txtMonthID.TextChanged += new System.EventHandler(this.txtMonthID_TextChanged);


            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);

            this.txtStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStatus_KeyPress);
            this.txtStatus.GotFocus += new System.EventHandler(this.txtStatus_GotFocus);
            this.txtStatus.KeyDown += new KeyEventHandler(txtStatus_KeyDown);
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            this.lstStatus.DoubleClick += new System.EventHandler(this.txtStatus_DoubleClick);
            Utility.CreateListBox(lstStatus, pnlMain, txtStatus);
        }

        private void txtStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstStatus.Items.Count > 0)
                {
                    txtStatus.Text = lstStatus.Text;
                    lstStatus.Visible = false;
                    btnSave.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                dteToDate.Focus();
            }
        }
        private void txtStatus_GotFocus(object sender, System.EventArgs e)
        {
            lstStatus.Visible = true;
            lstStatus.Height = 60;
            lstStatus.SelectedIndex = lstStatus.FindString(txtStatus.Text);
            mloadLedgerType();
        }
        private void txtStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstStatus.SelectedItem != null)
                {
                    lstStatus.SelectedIndex = lstStatus.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstStatus.Items.Count - 1 > lstStatus.SelectedIndex)
                {
                    lstStatus.SelectedIndex = lstStatus.SelectedIndex + 1;
                }
            }

        }
        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            lstStatus.SelectedIndex = lstStatus.FindString(txtStatus.Text);

        }
        private void txtStatus_DoubleClick(object sender, EventArgs e)
        {
            txtStatus.Text = lstStatus.Text;
            lstStatus.Visible = false;
            btnSave.Focus();


        }
        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteToDate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                txtMonthID.Focus();
            }
        }

        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtStatus.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                dteFromDate.Focus();
            }
        }
        private void txtMonthID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dateset();

                txtStatus.Focus();
            }
        }
        private void txtMonthID_GotFocus(object sender, System.EventArgs e)
        {

        }
        private void txtMonthID_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtMonthID_TextChanged(object sender, EventArgs e)
        {
            int x = txtMonthID.SelectionStart;
            txtMonthID.Text = Utility.gmakeProperCase(txtMonthID.Text).ToUpper();
            txtMonthID.SelectionStart = x;
    
        }
        private void txtMonthID_DoubleClick(object sender, EventArgs e)
        {
        
        }

        #region "Display List"
        private void DisplayList(List<ProjectonMonthConfig> tests, object sender, EventArgs e)
        {
            try
            {


                m_clear();
                m_action = 2;
                txtMonthID.ReadOnly = true;
                mstrmonthId = tests[0].strMonthID.ToString();
                textBox1.Text = tests[0].intSerial.ToString();
                txtMonthID.Text = tests[0].strMonthID.ToString();
                dteFromDate.Text = tests[0].strFromDate.ToString();
                dteToDate.Text = tests[0].strToDate.ToString();
                txtStatus.Text = tests[0].strStatus.ToString();

                txtMonthID.Focus();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        private void mloadLedgerType()
        {

            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"Active", 1},
              {"Inactive", 2},    
            };

            lstStatus.DisplayMember = "Key";
            lstStatus.ValueMember = "Value";
            lstStatus.DataSource = new BindingSource(userCache, null);

        }

        private void frmMonthSetUp_Load(object sender, EventArgs e)
        {
            lstStatus.Visible = false;
            m_action = 1;
        }
        private void m_clear()
        {
            txtMonthID.Text = "";
            txtStatus.Text = "";
            txtMonthID.ReadOnly = false;
            m_action = 1;
            txtMonthID.Focus();
        }
        #region "Validation"
        private bool ValidateFields()
        {
            string strDuplicate = "";
            {
                if (txtMonthID.Text.ToString() == "")
                {
                    MessageBox.Show("Code Cannot be Empty");
                    txtMonthID.Focus();
                    return false;
                }
                if (txtStatus.Text.ToString() == "")
                {
                    MessageBox.Show("Code Cannot be Empty");
                    txtStatus.Focus();
                    return false;
                }

                //if (Utility.gblnAccessControl)
                //{
                //    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                //    {
                //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return false;
                //    }
                //}


                if (m_action == 1)
                {

                    //if (mstrOldCode != txtMonthID.Text)
                    //{
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "PRO_MONTH_CONFIG", "MONTH_ID", txtMonthID.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtMonthID.Text = "";
                        txtMonthID.Focus();
                        return false;
                    }
                  
                    //List<Attendence> oogrp = Hrmc.mFillMonthConfig(strComID, "", 2).ToList();
                    //{
                    //    if (oogrp.Count > 0)
                    //    {
                    //        if (oogrp[0].intStatus == Convert.ToInt32(lstStatus.SelectedValue))
                    //        {
                    //            MessageBox.Show("only One Month Active at a Time");
                    //            txtStatus.Focus();
                    //            return false;
                    //        }
                    //    }
                    //}
                }
                else
                {
                    if (mstrmonthId != txtMonthID.Text)
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "PRO_MONTH_CONFIG", "MONTH_ID", txtMonthID.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            txtMonthID.Text = "";
                            txtMonthID.Focus();
                            return false;
                        }
                    }
                    //if (mintOldStatus != Convert.ToInt32(lstStatus.SelectedValue))
                    //{
                    //    List<Attendence> oogrp = Hrmc.mFillMonthConfig(strComID, "", 2).ToList();
                    //    {
                    //        if (oogrp.Count > 0)
                    //        {
                    //            if (oogrp[0].intStatus == Convert.ToInt32(lstStatus.SelectedValue))
                    //            {
                    //                MessageBox.Show("only One Month Active at a Time");
                    //                txtStatus.Focus();
                    //                return false;
                    //            }
                    //        }
                    //    }
                    //}

                }
            }

            return true;
        }
        #endregion
        private void Status()
        {

            if (txtStatus.Text == "Active")
            {
                intStatus = 1;
                strStatusType = "A";
            }
            if (txtStatus.Text == "Inactive")
            {
                intStatus = 0;
                strStatusType = "C";
            }
        }
        private void dateset()
        {
            string  strMonth = "";
            int intMonth = 0, intYY = 0;

            strMonth = txtMonthID.Text.Substring(0, 3).ToUpper();

            intYY = Convert .ToInt32(txtMonthID.Text.Substring(3, 2));
            intYY = Convert.ToInt32("20" + intYY);
            if (strMonth=="JAN")
            {
                intMonth = 1;
            }
            else if (strMonth == "FEB")
            {
                intMonth = 2;
            }
            else if (strMonth == "MAR")
            {
                intMonth = 3;
            }

            else if (strMonth == "APR")
            {
                intMonth = 4;
            }

            else if (strMonth == "MAY")
            {
                intMonth = 5;
            }

            else if (strMonth == "JUN")
            {
                intMonth = 6;
            }

            else if (strMonth == "JUL")
            {
                intMonth = 7;
            }

            else if (strMonth == "AUG")
            {
                intMonth = 8;
            }

            else if (strMonth == "SEP")
            {
                intMonth = 9;
            }

            else if (strMonth == "OCT")
            {
                intMonth = 10;
            }
            else if (strMonth == "NOV")
            {
                intMonth = 11;
            }
            else if (strMonth == "DEC")
            {
                intMonth = 12;
            }
            else
            {
                return;
            }

            //var now = DateTime.Now;
            var startOfMonth = new DateTime( intYY, intMonth, 1);
            dteFromDate.Text =Convert.ToDateTime( startOfMonth).ToString();
            var DaysInMonth = DateTime.DaysInMonth(dteFromDate.Value.Year, dteFromDate.Value.Month);
            var lastDay = new DateTime(intYY, intMonth,DaysInMonth);
            var EndOfMonth = new DateTime(intYY, intMonth, DaysInMonth);
            dteToDate.Text = Convert.ToDateTime(EndOfMonth).ToString();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
          
            string i = "";
            if (ValidateFields() == false)
            {
                return;
            }


            Status();
            if (m_action == 1)
            {

                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    { 
                        i = objExtra.mInsertMonthConfig(strComID, txtMonthID.Text, dteFromDate.Text, dteToDate.Text, intStatus);

                        if (i == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Month Setup", "Month Setup",
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtPURCHASE, "0001");
                            }
                            m_clear();

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
                     i = objExtra.mUpdateMonthConfigpublic(strComID,  txtMonthID.Text, dteFromDate.Text, dteToDate.Text, intStatus, Convert.ToInt16(textBox1.Text));

                        if (i == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Month Setup", "Month Setup",
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtPURCHASE, "0001");
                            }
                            btnNew.PerformClick();
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            m_clear();
            frmMonthList objfrm = new frmMonthList();
            objfrm.onAddAllButtonClicked = new frmMonthList.AddAllClick(DisplayList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.strFormTitel = "MonthID List";
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }

    }
}
