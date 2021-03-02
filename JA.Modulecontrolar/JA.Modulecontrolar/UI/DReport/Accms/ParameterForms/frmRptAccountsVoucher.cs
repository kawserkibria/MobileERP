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
    public partial class frmRptAccountsVoucher : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstVoucher = new ListBox();
        private ListBox lstItem = new ListBox();
        private string strComID { get; set; }
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptAccountsVoucher()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);

            this.uctxtVoucherNo.KeyDown += new KeyEventHandler(uctxtVoucherNo_KeyDown);
            this.uctxtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtVoucherNo_KeyPress);
            this.uctxtVoucherNo.TextChanged += new System.EventHandler(this.uctxtVoucherNo_TextChanged);
            this.lstVoucher.DoubleClick += new System.EventHandler(this.lstVoucher_DoubleClick);
            this.uctxtVoucherNo.GotFocus += new System.EventHandler(this.uctxtVoucherNo_GotFocus);

            Utility.CreateListBox(lstVoucher, pnlMain, uctxtVoucherNo, 0);
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

        private void uctxtVoucherNo_TextChanged(object sender, EventArgs e)
        {
            lstVoucher.SelectedIndex = lstVoucher.FindString(uctxtVoucherNo.Text);
        }

        private void lstVoucher_DoubleClick(object sender, EventArgs e)
        {
            uctxtVoucherNo.Text = lstVoucher.Text;
            textBox1.Text = lstVoucher.SelectedValue.ToString();
            lstVoucher.Visible = false;
        }

        private void uctxtVoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstVoucher.Items.Count > 0)
                {
                    uctxtVoucherNo.Text = lstVoucher.Text;
                    textBox1.Text = lstVoucher.SelectedValue.ToString();
                }
                lstVoucher.Visible = false;
                dteFromDate.Focus();

            }
        }
        private void uctxtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstVoucher.SelectedItem != null)
                {
                    lstVoucher.SelectedIndex = lstVoucher.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstVoucher.Items.Count - 1 > lstVoucher.SelectedIndex)
                {
                    lstVoucher.SelectedIndex = lstVoucher.SelectedIndex + 1;
                }
            }

        }

        private void uctxtVoucherNo_GotFocus(object sender, System.EventArgs e)
        {
            lstVoucher.Visible = true;
            mloadVoucher();
            lstVoucher.SelectedIndex = lstVoucher.FindString(uctxtVoucherNo.Text);
        }

        private void mloadVoucher()
        {
            int intVtype = 0,intSP=0;
            if (radSp.Checked==true)
            {
                intSP = 1;
            }
            else
            {
                intSP = 0;
            }
            if (radPayment.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER;
            }
            else if (radReceipt.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER;
            }
            else if (radJournal.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER;
            }
            else if (radContra.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER;
            }
            else if (radSp.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER;
            }
            lstVoucher.ValueMember = "strVoucherNo";
            lstVoucher.DisplayMember = "strOrderNo";
            lstVoucher.DataSource = accms.mGetRefNo(strComID, intVtype, dteFromDate.Text, dteToDate.Text, intSP).ToList();

        }
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstVoucher.Visible = false;
            lstItem.Visible = false;

        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstVoucher.Visible = false;
            lstItem.Visible = false;

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

        private void radIndividual_Click(object sender, EventArgs e)
        {
            uctxtVoucherNo.Enabled = true;
            uctxtVoucherNo.Text = "";
            textBox1.Text = "";
            uctxtVoucherNo.Focus();
            //txtLocationName.Enabled = true;
            //txtLocationName.Focus();
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
            uctxtVoucherNo.Enabled = false;
            uctxtVoucherNo.Text = "";
            textBox1.Text = "";
            lstVoucher.Visible = false;
            //txtLocationName.Enabled = false;
        }

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
            lstVoucher.Visible = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intVtype = 0, intDetails = 0, intnaration = 0,intSP=0;
            string strRefNo = "",strMpoComm = "", strbranchID = "",strHeading="";
            if (radSp.Checked==true)
            {
                intSP = 1;
            }
            else
            {
                intSP = 0;
            }
            if (radPayment.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER;
                strHeading = "Payment";
            }
            else if (radReceipt.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER;
                strHeading = "Receipt";
            }
            else if (radJournal.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER;
                strHeading = "Journal";
            }
            else if (radContra.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER;
                strHeading = "Contra";
            }
            else if (radSp.Checked == true && chkboxMPOComm.Checked==false )
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER;
                strHeading = "MPO Commission1";
            }
            else if (radSp.Checked == true && chkboxMPOComm.Checked == true )
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER;
                strHeading = "MPO Commission";
            }
            if (chkNarration.Checked == true)
            {
                intnaration = 1;
            }
            if (radDetails.Checked == true)
            {
                intDetails = 2;
            }
            else
            {
                intDetails = 0;
            }
            if (radIndividual.Checked == true)
            {

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Voucher No cannot be Empty");
                    uctxtVoucherNo.Focus();
                    return;
                }
                strRefNo = textBox1.Text;
                intDetails = 1;
                if (chkboxMPOComm.Checked == true)
                {
                    strMpoComm = "MCInduvidual";
                }
                else
                {
                    strMpoComm = "";
                }
            }
            else
            {
                strRefNo = "";
            }
            if (strHeading != "MPO Commission")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.AccountsVoucher;
                frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");
                frmviewer.intSummDetails = intDetails;
                frmviewer.intVtype = intVtype;
                frmviewer.intNarration = intnaration;
                frmviewer.strString = strRefNo;
                frmviewer.strBranchID = strbranchID;
                frmviewer.strHeading = strHeading;
                frmviewer.intSP = intSP;
                frmviewer.Show();
            }
            else
            {
                string strPFdate = "", strPTdate = "",strPMonthID="";
                frmReportViewer frmviewer = new frmReportViewer();
                if (strMpoComm == "MCInduvidual")
                {

                    strPFdate = Utility.FirstDayOfMonth( dteFromDate.Value.AddMonths(-1)).ToString("dd-MM-yyyy");
                    strPTdate = Utility.LastDayOfMonth(dteFromDate.Value.AddMonths(-1)).ToString("dd-MM-yyyy");
                    strPMonthID = Utility.FirstDayOfMonth(dteFromDate.Value.AddMonths(-1)).ToString("MMMyy");
                    frmviewer.selector = ViewerSelector.JVSP;
                    frmviewer.strFdate = strPFdate;
                    frmviewer.strTdate = strPTdate;
                    frmviewer.strPMonthID = strPMonthID;
                    frmviewer.intSummDetails = intDetails;
                    frmviewer.intVtype = intVtype;
                    frmviewer.intNarration = intnaration;
                    frmviewer.strString = strRefNo;
                    frmviewer.strBranchID = strbranchID;
                    frmviewer.strHeading = strHeading;
                    frmviewer.ReportSecondParameter = "A";
                    frmviewer.strSelf = "MC";
                    frmviewer.intSP = intSP;
                    frmviewer.Show();
                }
                else
                {
                   

                    strPFdate = Utility.FirstDayOfMonth(dteFromDate.Value.AddMonths(-1)).ToString("dd-MM-yyyy");
                    strPTdate = Utility.LastDayOfMonth(dteFromDate.Value.AddMonths(-1)).ToString("dd-MM-yyyy");
                    strPMonthID = Utility.FirstDayOfMonth(dteFromDate.Value.AddMonths(-1)).ToString("MMMyy");
                    frmviewer.selector = ViewerSelector.MpoCommissionSP;
                    frmviewer.strPFdate = strPFdate;
                    frmviewer.strPTdate = strPTdate;
                    frmviewer.strPMonthID = strPMonthID;
                    frmviewer.strFdate = dteFromDate.Value.ToString("dd-MM-yyyy");
                    frmviewer.strTdate = dteToDate.Value.ToString("dd-MM-yyyy");

                    frmviewer.intSummDetails = intDetails;
                    frmviewer.intVtype = intVtype;
                    frmviewer.intNarration = intnaration;
                    frmviewer.strString = strRefNo;
                    frmviewer.strBranchID = strbranchID;
                    frmviewer.strHeading = strHeading;
                    frmviewer.ReportSecondParameter = "A";
                    frmviewer.strSelf = "MC";
                    frmviewer.intSP = intSP;
                    frmviewer.Show();
                }

            }

        }

       

        private void radReceipt_Click(object sender, EventArgs e)
        {
            uctxtVoucherNo.Focus();
            uctxtVoucherNo.Text = "";
            textBox1.Text = "";
        }

        private void radJournal_Click(object sender, EventArgs e)
        {
            uctxtVoucherNo.Focus();
            uctxtVoucherNo.Text = "";
            textBox1.Text = "";
        }

        private void radContra_Click(object sender, EventArgs e)
        {
            uctxtVoucherNo.Focus();
            uctxtVoucherNo.Text = "";
            textBox1.Text = "";
        }

        private void radPayment_Click(object sender, EventArgs e)
        {
            uctxtVoucherNo.Text = "";
            uctxtVoucherNo.Focus();
            textBox1.Text = "";
        }

        private void radSummary_Click(object sender, EventArgs e)
        {
            chkNarration.Checked = false;
            chkNarration.Visible = false;
        }

        private void radDetails_Click(object sender, EventArgs e)
        {
            chkNarration.Visible = true;
        }

        private void radSp_Click(object sender, EventArgs e)
        {
            uctxtVoucherNo.Focus();
            uctxtVoucherNo.Text = "";
            textBox1.Text = "";
        }

        private void chkboxMPOComm_Click(object sender, EventArgs e)
        {
            if (chkboxMPOComm.Checked == true)
            {
                groupBox4.Visible = false;
            }
            else
            {
                groupBox4.Visible = true;
            }

                
        }

       

        
    }
}
