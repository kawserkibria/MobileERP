using ExtraReports.Projection.Reports.RProjection.Viewer;
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
using ExtraReports.JSAPUR;
using ExtraReports.JACCMS;
using Dutility;
using ExtraReports.JINVMS;
using ExtraReports.EXTRA;
using System.Drawing.Drawing2D;

namespace ExtraReports.Projection.Reports.RProjection.ParameterForms
{
 
    public partial class frmRptPerfoemance : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new JACCMS.SWJAGClient();
        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient();
        private ListBox lstLedger = new ListBox();
        private ListBox lstLedgerType = new ListBox();
      

        private string strComID { get; set; }
        public frmRptPerfoemance()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtLedgerType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLedgerType_KeyPress);
            this.txtLedgerType.GotFocus += new System.EventHandler(this.txtLedgerType_GotFocus);
            this.txtLedgerType.KeyDown += new KeyEventHandler(txtLedgerType_KeyDown);
            this.txtLedgerType.TextChanged += new System.EventHandler(this.txtLedgerType_TextChanged);
            this.lstLedgerType.DoubleClick += new System.EventHandler(this.lstLedgerType_DoubleClick);
            Utility.CreateListBox(lstLedgerType, pnlMain, txtLedgerType);
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);

            this.txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearch_KeyPress);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);


        }

        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteToDate.Focus();
            }
        }

        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnPrint.Focus();
            }
        }
        private void txtLedgerType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerType.Items.Count > 0)
                {
                    txtLedgerType.Text = lstLedgerType.Text;
                  
                    lstLedgerType.Visible = false;
                    groupSelectionstatus();
                    MpoLoad();
                   
                }
            }
        }

        private void groupSelectionstatus()
        {
            if (txtLedgerType.Text == "All")
            {
                lstLeft.Items.Clear();
                lstRight.Items.Clear();
                groupSelection.Enabled = false;
                dteFromDate.Focus();
            }
            else
            {
                groupSelection.Enabled = true;
                txtSearch.Focus();
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
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



        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //txtSearch.Text = "";

                if (lstLeft.SelectedItems.Count > 0)
                {
                    lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                    lstRight.SelectedValue = lstLeft.SelectedValue;
                    lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
                    txtSearch.Text = "";
                    txtSearch.Focus();
                }
                //btnPrint.Focus();       
            }

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
        private void txtLedgerType_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerType.Visible = true;
            lstLedgerType.SelectedIndex = lstLedgerType.FindString(txtLedgerType.Text);
            mloadLedgerType();
        }
        private void txtLedgerType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLedgerType.SelectedItem != null)
                {
                    lstLedgerType.SelectedIndex = lstLedgerType.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedgerType.Items.Count - 1 > lstLedgerType.SelectedIndex)
                {
                    lstLedgerType.SelectedIndex = lstLedgerType.SelectedIndex + 1;
                }
            }

        }
        private void txtLedgerType_TextChanged(object sender, EventArgs e)
        {
            lstLedgerType.SelectedIndex = lstLedgerType.FindString(txtLedgerType.Text);

        }
        private void lstLedgerType_DoubleClick(object sender, EventArgs e)
        {
            txtLedgerType.Text = lstLedgerType.Text;
            lstLedgerType.Visible = false;
            dteFromDate.Focus();
            groupSelectionstatus();
            MpoLoad();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            string strmsg = "", strName = "All", strString = "";
            int intMode = 0;
            progressBar1.Value = 0;
            if (txtLedgerType.Text != "All")
            {
                strName = txtLedgerType.Text.Substring(0, 1);
            }
            if (lstRight.Items.Count > 0)
            {
                for (int i = 0; i < lstRight.Items.Count; i++)
                {
                    strString = strString + "'" + lstRight.Items[i].ToString() + "',";
                }
                if (strString != "")
                {
                    strString = Utility.Mid(strString, 0, strString.Length - 1);
                }
            }
            List<AccountsLedger> objLedger = accms.mFillLedgerSelection(strComID, 202, strName, strString).ToList();
            if (objLedger.Count > 0)
            {
                progressBar1.Maximum = objLedger.Count;
                foreach (AccountsLedger ooLedger in objLedger)
                {
                    strmsg = objExtra.mInsertMpoPerformance(strComID, ooLedger.strLedgerName, dteFromDate.Text, dteToDate.Text, intMode);
                    int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) / (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
                    progressBar1.Refresh();
                    using (Graphics gr = progressBar1.CreateGraphics())
                    {
                        gr.DrawString(percent.ToString() + "%",SystemFonts.DefaultFont,Brushes.Red,new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                                SystemFonts.DefaultFont).Width / 2.0F),progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)));

                    }
                    progressBar1.Value += 1;
                    intMode += 1;

                }
            }

            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.Performance;
            frmviewer.strFdate = dteFromDate.Text;
            frmviewer.strTdate = dteToDate.Text;
            frmviewer.Show();
        }
        private void mloadLedgerType()
        {

            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"MPO", 2},
              {"All", 1},
              {"AM/FM", 3},
              {"DSM/RSM", 4},
              {"Zone", 5},       
            };

            lstLedgerType.DisplayMember = "Key";
            lstLedgerType.ValueMember = "Value";
            lstLedgerType.DataSource = new BindingSource(userCache, null);

        }
        private void MpoLoad()
        {
            txtSearch.Focus();
            mLoadLedgerName();
        }
        private void mLoadLedgerName()
        {

            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            int intType = 0;

            if (txtLedgerType.Text == "MPO")
            {
                intType = 4;
            }
            else if (txtLedgerType.Text == "AM/FM")
            {
                intType = 3;
            }
            else if (txtLedgerType.Text == "DSM/RSM")
            {
                intType = 2;
            }
            else if (txtLedgerType.Text == "Zone")
            {

                intType = 1;
            }
            if (intType > 0)
            {
                List<Mprojection> orptt = objExtra.mGetLedgerGroupLoad(strComID, intType).ToList();
                if (orptt.Count > 0)
                {
                    foreach (Mprojection ostk in orptt)
                    {
                        lstLeft.Items.Add(ostk.strGRName);
                    }
                }
            }
           

        }

        private void frmRptPerfoemance_Load(object sender, EventArgs e)
        {
            txtLedgerType.Text = "All";
            lstLedgerType.Visible = true;
            groupSelection.Enabled = false;
            txtLedgerType.Select();
            lstLedgerType.Visible = false;
            txtSearch.Visible = true;
            dteFromDate.Text = "01" + "-" + "01" + "-" + DateTime.Now.ToString("yyyy");
            dteToDate.Text = "31" + "-" + "12" + "-" + DateTime.Now.ToString("yyyy");

        }



        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

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

        private void lstRight_DoubleClick(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight.SelectedItem.ToString());
                lstLeft.SelectedValue = lstRight.SelectedValue;
                lstRight.Items.Remove(lstRight.SelectedItem.ToString());
            }
        }



    }
}
