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
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    public partial class frmRptGroupSummary : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstLedgerList = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptGroupSummary()
        {
           
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);

           
            this.lstLedgerList.DoubleClick += new System.EventHandler(this.lstLedgerList_DoubleClick);
            this.uctxtLedgerName.KeyDown += new KeyEventHandler(uctxtLedgerName_KeyDown);
            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);

           
            Utility.CreateListBoxHeight(lstLedgerList, pnlMain, uctxtLedgerName,0,200);
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

        private void uctxtLedgerName_TextChanged(object sender, EventArgs e)
        {
            lstLedgerList.SelectedIndex = lstLedgerList.FindString(uctxtLedgerName.Text);
        }

        private void lstLedgerList_DoubleClick(object sender, EventArgs e)
        {
            if (radLedgerWise.Checked)
            {
                uctxtLedgerName.Text = lstLedgerList.Text;
                //string[] words = lstLedgerList.Text.Split('-');
                //foreach (string word in words)
                //{
                //    try
                //    {

                //        uctxtLedgerName.Text = words[0].ToString();
                //        uctxtTerritoryCode.Text = words[1].ToString();
                //        uctxtTeritorryName.Text = words[2].ToString();
                //        uctxtLedgerName.Text = words[0].ToString();
                //    }
                //    catch (Exception ex)
                //    {

                //    }

                //}
            }
            else
            {
                uctxtLedgerName.Text = lstLedgerList.Text;
            }
            dteFromDate.Focus();
        }
        private void mLaod(string strName)
        {
            if (strName=="G")
            {
                lstLedgerList.DisplayMember = "strLedgerName";
                lstLedgerList.ValueMember = "strLedgerName";
                lstLedgerList.DataSource = accms.mFillLedgerNew(strComID, 2).ToList();
            }
            if (strName == "L")
            {
                lstLedgerList.DisplayMember = "strLedgerName";
                lstLedgerList.ValueMember = "strLedgerName";
                lstLedgerList.DataSource = accms.mLedgerAdditemMr(strComID, "",0).ToList();
            }
        }
        private void uctxtLedgerName_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerList.Visible = true;
            //if (radGroupWise.Checked == true)
            //{
            //    lstLedgerList.DisplayMember = "strLedgerName";
            //    lstLedgerList.ValueMember = "strLedgerName";
            //    lstLedgerList.DataSource = accms.mFillLedgerNew(2).ToList();
            //}
            //else
            //{
            //    lstLedgerList.DisplayMember = "strLedgerName";
            //    lstLedgerList.ValueMember = "strLedgerName";
            //    lstLedgerList.DataSource = accms.mLedgerAdditemMr("").ToList();
            //}


            lstLedgerList.SelectedIndex = lstLedgerList.FindString(uctxtLedgerName.Text);

        }

        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerList.Items.Count > 0)
                {
                    // uctxtLedgerName.Text = lstLedgerList.Text;
                    if (radLedgerWise.Checked)
                    {
                        uctxtLedgerName.Text = lstLedgerList.Text;
                        //string[] words = lstLedgerList.Text.Split('-');
                        //foreach (string word in words)
                        //{

                        //    try
                        //    {

                        //        uctxtLedgerName.Text = words[0].ToString();
                        //        uctxtTerritoryCode.Text = words[1].ToString();
                        //        uctxtTeritorryName.Text = words[2].ToString();
                        //        uctxtLedgerName.Text = words[0].ToString();
                        //    }
                        //    catch (Exception ex)
                        //    {

                        //    }

                        //}
                    }
                    else
                    {
                        uctxtLedgerName.Text = lstLedgerList.Text;
                    }
                }
                dteFromDate.Focus();

            }
        }

        private void uctxtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLedgerList.SelectedItem != null)
                {
                    lstLedgerList.SelectedIndex = lstLedgerList.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedgerList.Items.Count - 1 > lstLedgerList.SelectedIndex)
                {
                    lstLedgerList.SelectedIndex = lstLedgerList.SelectedIndex + 1;
                }
            }

        }

        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerList.Visible = false;
           

        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerList.Visible = false;
           

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
        

        #endregion
        private void mLaodItem()
        {
            //lstItem.ValueMember = "strItemName";
            //lstItem.DisplayMember = "strItemName";
            //lstItem.DataSource = invms.gFillStockItem("", "", false).ToList();
         
        }




        private void frmRptGroupSummary_Load(object sender, EventArgs e)
        {
            uctxtLedgerName.Select();
            //dteFromDate.Text = Utility.gdteFinancialYearFrom;
            //dteToDate.Text = Utility.gdteFinancialYearTo;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            lstLedgerList.DisplayMember = "strLedgerName";
            lstLedgerList.ValueMember = "strLedgerName";
            lstLedgerList.DataSource = accms.mFillLedgerNew(strComID, 2).ToList();
          
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strBrachID = "";
            int intselection = 0,intSuppress=0;
            if (uctxtLedgerName.Text =="")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtLedgerName.Focus();
                return;
            }
            if (chkSuppress.Checked ==true)
            {
                intSuppress = 1;
            }
            else
            {
                intSuppress = 0;
            }

            //1 =opn + tran +clos
            //2 opn +tran;3 opn + clos;4 tran + opn;5 tran + opn,6 =cls + opn,7 cls + tran 8 =opn, 9 tran 10 cls;
            if (chkOpening.Checked ==true && chkTransaction.Checked==true && chkClosing.Checked==true)
            {
                intselection = 1;
            }
            else if (chkOpening.Checked == true && chkTransaction.Checked )
            {
                intselection = 2;
            }
            else if (chkOpening.Checked == true && chkClosing.Checked)
            {
                intselection = 3;
            }
            else if (chkTransaction.Checked==true && chkClosing.Checked==true)
            {
                intselection = 4;
            }
            else if (chkTransaction.Checked == true && chkOpening.Checked == true)
            {
                intselection = 5;
            }
            else if (chkClosing.Checked == true && chkOpening.Checked == true)
            {
                intselection = 6;
            }
            else if (chkClosing.Checked == true && chkTransaction.Checked == true)
            {
                intselection = 7;
            }
            else if (chkOpening.Checked == true && chkTransaction.Checked == false && chkClosing.Checked == false)
            {
                intselection = 8;
            }
            else if (chkOpening.Checked == false && chkTransaction.Checked == true && chkClosing.Checked == false)
            {
                intselection = 9;
            }
            else if (chkOpening.Checked == false && chkTransaction.Checked == false && chkClosing.Checked == true)
            {
                intselection = 10;
            }
            else
            {
                intselection = 1;
            }

            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.Group;
            frmviewer.strFdate = dteFromDate.Text;
            frmviewer.strTdate = dteToDate.Text;
            frmviewer.strString = uctxtLedgerName.Text;
            frmviewer.strBranchID = strBrachID;
            frmviewer.intSummDetails  = intselection;
            frmviewer.intSP = intSuppress;
            if (radGroupWise.Checked == true)
            {
                frmviewer.strSelction = "Group";
                frmviewer.strHeading = "Group Summary";
            }
            else
            {
                frmviewer.strSelction = "Ledger";
                frmviewer.strHeading = "Group Summary (Ledger)";
            }

            frmviewer.strHeading = uctxtLedgerName.Text;
            frmviewer.Show();
          

           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void radGroupWise_Click(object sender, EventArgs e)
        {
            mLaod("G");
            //uctxtLedgerName.Focus();
        }

        private void radLedgerWise_Click(object sender, EventArgs e)
        {
            mLaod("G");
            //uctxtLedgerName.Focus();
        }
    }
}
