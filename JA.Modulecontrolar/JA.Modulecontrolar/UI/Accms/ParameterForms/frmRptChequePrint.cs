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
    public partial class frmRptChequePrint : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstVoucher = new ListBox();
        private ListBox lstItem = new ListBox();
        private ListBox lstBranchName = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptChequePrint()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);

            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);

            this.uctxtVoucherNo.KeyDown += new KeyEventHandler(uctxtVoucherNo_KeyDown);
            this.uctxtVoucherNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtVoucherNo_KeyPress);
            this.uctxtVoucherNo.TextChanged += new System.EventHandler(this.uctxtVoucherNo_TextChanged);
            this.lstVoucher.DoubleClick += new System.EventHandler(this.lstVoucher_DoubleClick);
            this.uctxtVoucherNo.GotFocus += new System.EventHandler(this.uctxtVoucherNo_GotFocus);
            
            this.TxtSalf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TxtSalf_KeyPress);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAmount_KeyPress);

            Utility.CreateListBox(lstVoucher, pnlMain, uctxtVoucherNo, 0);
            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
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
        private void TxtSalf_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Return)
            {
                txtAmount.Focus();
            }

        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            uctxtVoucherNo.Enabled = true;
            if (e.KeyChar == (char)Keys.Return)
            {
                btnPrint.Focus();
            }

        }
        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranchName.Text;
            //lstVoucher.Items.Clear();
            lstBranchName.Visible = false;
            uctxtVoucherNo.Focus();

        }

        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = true;
            lstVoucher.Visible = false;
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            uctxtVoucherNo.Enabled = true;
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }
                //lstVoucher.Items.Clear();
                uctxtVoucherNo.Focus();
                lstBranchName.Visible = false; 
            }
          
        }

        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranchName.SelectedItem != null)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranchName.Items.Count - 1 > lstBranchName.SelectedIndex)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex + 1;
                }
            }

        }

        private void uctxtVoucherNo_TextChanged(object sender, EventArgs e)
        {
            lstVoucher.SelectedIndex = lstVoucher.FindString(uctxtVoucherNo.Text);
        }

        private void lstVoucher_DoubleClick(object sender, EventArgs e)
        {
            uctxtVoucherNo.Text = lstVoucher.Text;
            textBox1.Text = lstVoucher.SelectedValue.ToString();
            lstVoucher.Visible = false;
            TxtSalf.Focus();
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
                //uctxtVoucherNo.Focus();
                TxtSalf.Focus();
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
            lstBranchName.Visible = false;
            mloadVoucher();
            lstVoucher.SelectedIndex = lstVoucher.FindString(uctxtVoucherNo.Text);
        }

        private void mloadVoucher()
        {
            int intVtype = 0;
            if (radPayment.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER;
            }
            else if (radJournal.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER;
            }
            else if (radContra.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER;
            }
            lstVoucher.ValueMember = "strVoucherNo";
            lstVoucher.DisplayMember = "strOrderNo";
            lstVoucher.DataSource = accms.mGetChequeRefNo(strComID, intVtype, "", "", 0).ToList();

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

        private void radIndividual_Click(object sender, EventArgs e)
        {
            uctxtVoucherNo.Enabled = true;
            uctxtVoucherNo.Text = "";
            //textBox1.Text = "";
            uctxtVoucherNo.Focus();
            //txtLocationName.Enabled = true;
            //txtLocationName.Focus();
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
            uctxtVoucherNo.Enabled = true;
            uctxtVoucherNo.Text = "";
            textBox1.Text = "";
            lstVoucher.Visible = false;
            //txtLocationName.Enabled = false;
        }

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            uctxtBranchName.Select();
            lstVoucher.Visible = true;
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intVtype = 0, intDetails = 0, intnaration = 0;
            string strRefNo = "", strbranchID = "",strHeading="",  VoucerTo ="" , PF = "";
           
        
           
            string strBranchId = "", strMonthID = "";

            int intmode = 0, intSelection = 0;


            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Please Select Branch Name.");
                return;
            }
            else
            {
                strBranchId = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text); ;
            }

             
            if (radPayment.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtPAYMENT_VOUCHER;
                strHeading = "Payment";
                 PF = "PV";
                 VoucerTo = "Cr";
                strRefNo = PF + strBranchId + uctxtVoucherNo.Text;
            }
            if (radJournal.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER;
                strHeading = "Journal";
                 PF = "JV";
                 VoucerTo = "Dr";
                strRefNo = PF + strBranchId + uctxtVoucherNo.Text;
            }
           if (radContra.Checked == true)
            {
                intVtype = (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER;
                strHeading = "Contra";
                 VoucerTo = "Dr";
                 PF = "CV";
                strRefNo = PF + strBranchId + uctxtVoucherNo.Text;
            }
           
            if (ckbHoizontal.Checked == true  )
            {
                intmode = 1;
            }
            //double dblamont = "";
            //dblamont= txtAmount.Text;
            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.Chequeprint;
            frmviewer.intSummDetails = intDetails;
            frmviewer.strSelf = TxtSalf.Text ;
            frmviewer.dblAmount = Convert.ToDouble((txtAmount.Text).ToString());
            frmviewer.intVtype = intVtype;
            frmviewer.strString = strRefNo;
            frmviewer.intNarration = intmode;
            frmviewer.strSelction = VoucerTo;
            frmviewer.ShowDialog();

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

       

        
    }
}
