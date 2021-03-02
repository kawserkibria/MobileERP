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
    public partial class frmRptProjection : JA.Shared.UI.frmSmartFormStandard 
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstMrName = new ListBox();

        public string strMontNameYY = "";
        public string strMontName = "";

        public string strThisMonth = "";
        public string strLastMonth= "";

        JACCMS.SWJAGClient accms = new JACCMS.SWJAGClient();
        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient();

        private ListBox lstLedger = new ListBox();
        private ListBox lstLedgerType = new ListBox();
        private ListBox lstMonthID = new ListBox();
        private string strComID { get; set; }
       
      
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptProjection()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

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


            this.txtSearchProjection.GotFocus += new System.EventHandler(this.txtSearchProjection_GotFocus);

            this.txtSearchProjection.KeyDown += new KeyEventHandler(txtSearchProjection_KeyDown);
            this.txtSearchProjection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearchProjection_KeyPress);
            this.txtSearchProjection.TextChanged += new System.EventHandler(this.txtSearchProjection_TextChanged);

            this.txtSearch.KeyDown += new KeyEventHandler(txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearch_KeyPress);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.lstLeftP.DoubleClick += new System.EventHandler(this.lstLeftP_DoubleClick);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);

            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch, 0);
            Utility.CreateListBox(lstMonthID, pnlMain, txtMonthID, 0);
           
        }
        private void txtSearchProjection_TextChanged(object sender, EventArgs e)
        {
            lstLeftP.SelectedIndex = lstLeftP.FindString(txtSearchProjection.Text);
        }
        private void txtSearchProjection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLeftP.SelectedItem != null)
                {
                    lstLeftP.SelectedIndex = lstLeftP.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLeftP.Items.Count - 1 > lstLeftP.SelectedIndex)
                {
                    lstLeftP.SelectedIndex = lstLeftP.SelectedIndex + 1;
                }
            }

        }
        private void txtSearchProjection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //txtSearch.Text = "";

                if (lstLeftP.SelectedItems.Count > 0)
                {
                    lstRightP.Items.Add(lstLeftP.SelectedItem.ToString());
                    lstRightP.SelectedValue = lstLeftP.SelectedValue;
                    lstLeftP.Items.Remove(lstLeftP.SelectedItem.ToString());
                    txtSearchProjection.Text = "";
                    txtSearchProjection.Focus();
                }
                //btnPrint.Focus();       
            }

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

        private void lstLeftP_DoubleClick(object sender, EventArgs e)
        {
            if (lstLeftP.SelectedItems.Count > 0)
            {
                lstRightP.Items.Add(lstLeftP.SelectedItem.ToString());
                lstRightP.SelectedValue = lstLeftP.SelectedValue;
                lstLeftP.Items.Remove(lstLeftP.SelectedItem.ToString());
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

        private void mLoadProjection()
        {
            lstLeftP.Items.Clear();
            List<ProjectionSet> orptt = objExtra.mFillPojictionConfig(strComID,txtMonthID.Text).ToList();
            if (orptt.Count > 0)
            {
               foreach (ProjectionSet ostk in orptt)
                {
                    lstLeftP.Items.Add(ostk.strProjectionName);
                }
            }


        }


        private void mLoadLedgerName()
        {
            int Intmode = 0;
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            string strSelction = "";
            //public List<RSalesPurchase> mGetBkash(string strDeComID)
            if (rbtnMPO.Checked == true)
            {
                Intmode = 1;
            }
            if (rbtnAMFM.Checked == true)
            {
                Intmode = 2;
            }
            if (rbtnDSMRSM.Checked == true)
            {
                Intmode = 3;
            }
            if (rbtnZONE.Checked == true)
            {
                Intmode = 4;
            }

            List<ProjectionSet> orptt = objExtra.mFillDisplayLedgerNameWeeklyReport(strComID, txtMonthID.Text, uctxtBranch.Text, Intmode,Utility.gstrUserName,"").ToList();
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

            lstMonthID.ValueMember = "strMonthID";
            lstMonthID.DisplayMember = "strMonthID";
            lstMonthID.DataSource = objExtra.mFillMonthConfig(strComID, 0).ToList();
            
        }
        private void txtSearchProjection_GotFocus(object sender, System.EventArgs e)
        {

            mLoadProjection();
            
        }
        
        private void lstMonthID_DoubleClick(object sender, EventArgs e)
        {
            txtMonthID.Text = lstMonthID.Text;
            lstMonthID.Visible = false;
            lstLeftP.Items.Clear();
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            lstRightP.Items.Clear();
            mLoadProjection();
            txtSearchProjection.Focus();


    
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
                lstLeftP.Items.Clear();
                lstLeft.Items.Clear();
                lstRight.Items.Clear();
                lstRightP.Items.Clear();
                txtSearchProjection.Focus();
        
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
 

        private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        private void uctxtBranch_GotFocus(object sender, System.EventArgs e)
        {

            lstBranch.Visible = true;
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }
        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranch.Text = lstBranch.Text;
            lstBranch.Visible = false;

            lstLeftP.Items.Clear();
            lstRightP.Items.Clear();
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
                lstLeftP.Items.Clear();
                lstLeft.Items.Clear();
                lstRight.Items.Clear();
                lstRightP.Items.Clear();
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
  
   

        private void SearchProjectName(IEnumerable<Invoice> tests, string searchString = "")
        {
        //    IEnumerable<Invoice> query;
        //    query = tests;
        //    if (searchString != "")
        //    {
        //        query = tests.Where(x => x.strMereString.ToLower().Trim().Contains(searchString.ToLower().Trim()));
        //    }
          
        //    //DGMr.Rows.Clear();
        //    int i = 0;
        //    try
        //    {
        //        foreach (Invoice tran in query)
        //        {
        //            //DGMr.Rows.Add();
        //            //DGMr[0, i].Value = tran.strTeritorryCode;
        //            //DGMr[1, i].Value = tran.strTeritorryName;
        //            //DGMr[2, i].Value = tran.strLedgerName;
        //            //DGMr[3, i].Value = tran.strMereString;
        //            //i += 1;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        }

        private void SearchListViewGroupName(IEnumerable<ProjectionSet> tests, string searchString = "")
        {
            //IEnumerable<ProjectionSet> query;
            //query = tests;
            //if (searchString != "")
            //{
            //    query = tests.Where(x => x.strMerzeName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            //}

            //DGMr.Rows.Clear();
            //int i = 0;
            //try
            //{
            //    foreach (ProjectionSet tran in query)
            //    {
            //        DGMr.Rows.Add();
            //        DGMr[0, i].Value = "";
            //        DGMr[1, i].Value = "";

            //        DGMr[2, i].Value = tran.GroupName;
            //        DGMr[3, i].Value = tran.GroupName;
            //        i += 1;
            //    }


            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}
        }



 
        private void frmRptProjection_Load(object sender, EventArgs e)
        {
 
            lstMonthID.Visible = false;
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

        private void btnRightSingleP_Click(object sender, EventArgs e)
        {
            if (lstLeftP.SelectedItems.Count > 0)
            {
                lstRightP.Items.Add(lstLeftP.SelectedItem.ToString());
                lstRightP.SelectedValue = lstLeftP.SelectedValue;
                lstLeftP.Items.Remove(lstLeftP.SelectedItem.ToString());
            }
        }

        private void btnRightAllP_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstLeftP.Items.Count; i++)
            {
                string strItem = lstLeftP.Items[i].ToString().TrimStart();
                lstRightP.Items.Add(strItem);
            }
            lstLeftP.Items.Clear();
        }

        private void btnLeftSingleP_Click(object sender, EventArgs e)
        {
            if (lstRightP.SelectedItems.Count > 0)
            {
                lstLeftP.Items.Add(lstRightP.SelectedItem.ToString());
                lstRightP.Items.Remove(lstRightP.SelectedItem.ToString());
            }
        }

        private void btnLeftAllP_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRightP.Items.Count; i++)
            {
                string strItem = lstRightP.Items[i].ToString().TrimStart();
                lstLeftP.Items.Add(strItem);
            }
            lstRightP.Items.Clear();
        }

        private void rbtnMPO_Click(object sender, EventArgs e)
        {

            mLoadLedgerName();

        }

        private void rbtnAMFM_Click(object sender, EventArgs e)
        {
            mLoadLedgerName();
        }

        private void rbtnDSMRSM_Click(object sender, EventArgs e)
        {
            mLoadLedgerName();
        }

        private void rbtnZONE_Click(object sender, EventArgs e)
        {
            mLoadLedgerName();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strBranchId = "", strString2 = "", strString3 = "", strString4 = "";


            int intmode = 0, intSelection=0;
            if (rbtnMPO.Checked == true)
            {
                intmode = 4;
            }
            if (rbtnAMFM.Checked == true)
            {
                intmode = 3;
            }
            if (rbtnDSMRSM.Checked == true)
            {
                intmode = 2;
            }
            if (rbtnZONE.Checked == true)
            {
                intmode = 1;
            }


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

            if (lstRightP.Items.Count <= 0)
            {
                MessageBox.Show("Data Not Found.");
                return;
            }
            {
                for (int i = 0; i < lstRightP.Items.Count; i++)
                {
                    strString3 = strString3 + "'" + lstRightP.Items[i].ToString().Replace("'", "''") + "',";
                    strString4 = strString4 + "" + lstRightP.Items[i].ToString().Replace("'", "''") + ",";
                }
                if (strString3 != "")
                {
                    strString3 = Utility.Mid(strString3, 0, strString3.Length - 1);
                    strString4 = Utility.Mid(strString4, 0, strString4.Length - 1);
                }
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

            progressBar1.Value = 0;

            string[] words = strString4.Split(',');
            progressBar1.Maximum = words.Count();
            foreach (string ooObj in words)
            {

                if (ooObj != "")
                {
                    string strProjectionName = ooObj.ToString();
                   
                    List<PCollectionCopmarison> oLedger = objExtra.mGetMontlyLadgerProjection(strComID, txtMonthID.Text, strString2).ToList();
                    if (oLedger.Count > 0)
                    {
                        foreach (PCollectionCopmarison ooL in oLedger)
                        {
                            List<PCollectionCopmarison> objPerfo = objExtra.mGetProjectionReport(strComID, strProjectionName, txtMonthID.Text, "", intSelection, ooL.strLedgerName, strString2).ToList();
                            intSelection += 1;
                        }


                    }
                }
                int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) / (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
                progressBar1.Refresh();
                using (Graphics gr = progressBar1.CreateGraphics())
                {
                    gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Red, new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                            SystemFonts.DefaultFont).Width / 2.0F), progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)));

                }
                progressBar1.Value += 1;
            }




            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.ProjectionR;
            frmviewer.intPosition = intmode;
            frmviewer.strString1 = txtMonthID.Text;
            frmviewer.strString2 = strString3;
            //frmviewer.strFdate = strString4;
            //frmviewer.strledgerName = strString2;
            frmviewer.Show();

        }

    

       

     

       
       

    
    }
}
