using JA.Modulecontrolar.UI.Projection.Reports.RProjection.Viewer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
//using JA.Modulecontrolar.JINVMS;
using System.Windows.Forms;

using Dutility;
using System.Drawing.Drawing2D;
using JA.Modulecontrolar.JSAPUR;
using JA.Modulecontrolar.JINVMS;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.EXTRA;

namespace JA.Modulecontrolar.UI.Projection.Reports.RProjection.ParameterForms
{
    public partial class frmRptProjectionQuickView : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstZone = new ListBox();
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();

        public string strMontNameYY = "";
        public string strMontName = "";

        public string strThisMonth = "";
        public string strLastMonth = "";

        JACCMS.SWJAGClient accms = new JACCMS.SWJAGClient();
        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient();

        private ListBox lstLedger = new ListBox();
        private ListBox lstLedgerType = new ListBox();
        private ListBox lstMonthID = new ListBox();
        private string strComID { get; set; }


        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptProjectionQuickView()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");



            this.txtZone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtZone_KeyPress);
            this.txtZone.GotFocus += new System.EventHandler(this.txtZone_GotFocus);
            this.txtZone.KeyDown += new KeyEventHandler(txtZone_KeyDown);
            this.txtZone.TextChanged += new System.EventHandler(this.txtZone_TextChanged);
            this.lstZone.DoubleClick += new System.EventHandler(this.lstZone_DoubleClick);

            this.txtMonthID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonthID_KeyPress);
            this.txtMonthID.GotFocus += new System.EventHandler(this.txtMonthID_GotFocus);
            this.txtMonthID.KeyDown += new KeyEventHandler(txtMonthID_KeyDown);
            this.txtMonthID.TextChanged += new System.EventHandler(this.txtMonthID_TextChanged);
            this.lstMonthID.DoubleClick += new System.EventHandler(this.lstMonthID_DoubleClick);

            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);
            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);

            this.txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearch_KeyPress);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch, 0);
            Utility.CreateListBox(lstMonthID, pnlMain, txtMonthID, 0);
            Utility.CreateListBox(lstZone, pnlMain, txtZone, 0);

        }

        private void txtZone_GotFocus(object sender, System.EventArgs e)
        {
            lstZone.Visible = true;
            lstZone.ValueMember = "strMerzeName";
            lstZone.DisplayMember = "strMerzeName";
            lstZone.DataSource = objExtra.mFillDisplayLedgerNameWeeklyReport(strComID, txtMonthID.Text, uctxtBranch.Text, 4, Utility.gstrUserName,"").ToList();
        }
        private void lstZone_DoubleClick(object sender, EventArgs e)
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            txtZone.Text = lstZone.Text;
            mLoadLedgerName();
            lstZone.Visible = false;


        }
        private void txtZone_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstZone.Items.Count > 0)
                {
                    txtZone.Text = lstZone.Text;
                    lstZone.Visible = false;
                    lstLeft.Items.Clear();
                    lstRight.Items.Clear();
                    mLoadLedgerName();
                }
                txtSearch.Focus();

            }

        }
        private void txtZone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstZone.SelectedItem != null)
                {
                    lstZone.SelectedIndex = lstZone.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstZone.Items.Count - 1 > lstZone.SelectedIndex)
                {
                    lstZone.SelectedIndex = lstZone.SelectedIndex + 1;
                }
            }

        }

        private void txtZone_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLeft.SelectedItem != null)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLeft.Items.Count - 1 > lstLeft.SelectedIndex)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex + 1;
                }
            }

        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLeft.SelectedItems.Count > 0)
                {
                    lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                    lstRight.SelectedValue = lstLeft.SelectedValue;
                    lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
                    txtSearch.Text = "";
                    txtSearch.Focus();
                }
            }

        }
        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstRight.SelectedValue = lstLeft.SelectedValue;
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }

        }
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

        private void mLoadLedgerName()
        {

            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<ProjectionSet> orptt = objExtra.mFillDisplayLedgerNameWeeklyReport(strComID, txtMonthID.Text, uctxtBranch.Text, 3, Utility.gstrUserName,txtZone.Text).ToList();
            if (orptt.Count > 0)
            {
                foreach (ProjectionSet ostk in orptt)
                {
                    lstLeft.Items.Add(ostk.strMerzeName);
                }
            }

            txtSearch.Focus();
        }
        private void txtMonthID_TextChanged(object sender, EventArgs e)
        {
            lstMonthID.SelectedIndex = lstMonthID.FindString(uctxtBranch.Text);
        }
        private void txtMonthID_GotFocus(object sender, System.EventArgs e)
        {

            lstMonthID.Visible = true;
            lstZone.Visible = false;
            lstMonthID.ValueMember = "strMonthID";
            lstMonthID.DisplayMember = "strMonthID";
            lstMonthID.DataSource = objExtra.mFillMonthConfig(strComID, 0).ToList();

        }
        private void lstMonthID_DoubleClick(object sender, EventArgs e)
        {
            txtMonthID.Text = lstMonthID.Text;
            lstMonthID.Visible = false;
            txtZone.Focus();
            lstLeft.Items.Clear();
            lstRight.Items.Clear();

        }
        private void txtMonthID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstMonthID.Items.Count > 0)
                {
                    txtMonthID.Text = lstMonthID.Text;

                    lstMonthID.Visible = false;
                }
                txtZone.Focus();
                lstLeft.Items.Clear();
                lstRight.Items.Clear();
            }
        }
        private void txtMonthID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstMonthID.SelectedItem != null)
                {
                    lstMonthID.SelectedIndex = lstMonthID.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstMonthID.Items.Count - 1 > lstMonthID.SelectedIndex)
                {
                    lstMonthID.SelectedIndex = lstMonthID.SelectedIndex + 1;
                }
            }

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
        #region "User Deifne"
        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        private void uctxtBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstZone.Visible = false;
            lstMonthID.Visible = false;
            lstBranch.Visible = true;
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranch.Text = lstBranch.Text;
            lstBranch.Visible = false;


            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            txtMonthID.Focus();
        }
        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstBranch.Text;

                    lstBranch.Visible = false;
                }
                lstLeft.Items.Clear();
                lstRight.Items.Clear();
                txtMonthID.Focus();
            }

        }
        private void uctxtBranch_KeyDown(object sender, KeyEventArgs e)
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
        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnPrint.Focus();

            }
        }

        #endregion

        private void dateset()
        {
            string strMonth = "";
            int intMonth = 0, intYY = 0;

            strMonth = txtMonthID.Text.Substring(0, 3).ToUpper();

            intYY = Convert.ToInt32(txtMonthID.Text.Substring(3, 2));
            intYY = Convert.ToInt32("20" + intYY);
            if (strMonth == "JAN")
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

            var startOfMonth = new DateTime(intYY, intMonth, 1);
            dteFromDate.Text = Convert.ToDateTime(startOfMonth).ToString();
            dteToDate.Text = dteFromDate.Value.AddMonths(-1).ToString();
            strThisMonth = Convert.ToDateTime(dteFromDate.Text).ToString("MMMyy");
            strLastMonth = Convert.ToDateTime(dteToDate.Text).ToString("MMMyy");

        }
        private void frmRptProjectionQuickView_Load(object sender, EventArgs e)
        {

            lstMonthID.Visible = false;
            lstZone.Visible = false;
            dteFromDate.Text = DateTime.Now.ToString();
            dteToDate.Text = DateTime.Now.ToString();
            uctxtBranch.Focus();
            lstBranch.Visible = false;
            lstMrName.Visible = false;
            lstMonthID.Visible = false;
            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            frmLabel.Text = "Projection";
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strBranchId = "", strString2 = "";

            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            }

            if (txtMonthID.Text == "")
            {
                MessageBox.Show("Please Select Month.");
                txtMonthID.Focus();
                return;
            }

            if (lstRight.Items.Count <= 0)
            {
                MessageBox.Show("Data Not Found.");
                return;
            }
            {
                for (int i = 0; i < lstRight.Items.Count; i++)
                {
                    strString2 = strString2 + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
                }
                if (strString2 != "")
                {
                    strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
                }
            }


            frmReportViewer frmviewer = new frmReportViewer();
            if (rbtnWeekly.Checked == true)
            {
                frmviewer.selector = ViewerSelector.ProjectionRW;
            }
            else
            {
                frmviewer.selector = ViewerSelector.ProjectionRM;
            }
            frmviewer.strString1 = txtMonthID.Text;
            frmviewer.strString2 = strString2;
            frmviewer.intmode = 1;
            frmviewer.strledgerName = txtZone.Text;
            frmviewer.Show();

        }











    }
}
