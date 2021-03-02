using Dutility;
using JA.Modulecontrolar.JINVMS;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.DReport.Purchase.Viewer;
namespace JA.Modulecontrolar.UI.DReport.Purchase.ParameterForms
{
    public partial class frmRptReturnRegisterOld : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private ListBox lstMedicalRep = new ListBox();
        public frmRptReturnRegisterOld()
        {
            InitializeComponent();

            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            //this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);
            this.uctxtMedicalRep.KeyDown += new KeyEventHandler(uctxtMedicalRep_KeyDown);
            this.uctxtMedicalRep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtMedicalRep_KeyPress);
            this.uctxtMedicalRep.TextChanged += new System.EventHandler(this.uctxtMedicalRep_TextChanged);
            this.lstMedicalRep.DoubleClick += new System.EventHandler(this.lstMedicalRep_DoubleClick);
            this.uctxtMedicalRep.GotFocus += new System.EventHandler(this.uctxtMedicalRep_GotFocus);
            Utility.CreateListBox(lstMedicalRep, pnlMain, uctxtMedicalRep);

        }

        #region "User Deifne"
        private void uctxtMedicalRep_TextChanged(object sender, EventArgs e)
        {
            lstMedicalRep.SelectedIndex = lstMedicalRep.FindString(uctxtMedicalRep.Text);
        }
        private void uctxtMedicalRep_GotFocus(object sender, System.EventArgs e)
        {

            lstMedicalRep.Visible = true;
            lstMedicalRep.ValueMember = "strLedgerName";
            lstMedicalRep.DisplayMember = "strLedgerName";
            lstMedicalRep.DataSource = accms.mLedgerAdditem("").ToList();

            lstMedicalRep.Top = 200;
            lstMedicalRep.Left = 143;
        }
        private void lstMedicalRep_DoubleClick(object sender, EventArgs e)
        {
            uctxtMedicalRep.Text = lstMedicalRep.Text;
            lstMedicalRep.Visible = false;
            dteFromDate.Focus();
        }
        private void uctxtMedicalRep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstMedicalRep.Items.Count > 0)
                {
                    uctxtMedicalRep.Text = lstMedicalRep.Text;
                    lstMedicalRep.Visible = false;
                    btnPrint.Focus();
                }
            }
        }
        private void uctxtMedicalRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstMedicalRep.SelectedItem != null)
                {
                    lstMedicalRep.SelectedIndex = lstMedicalRep.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstMedicalRep.Items.Count - 1 > lstMedicalRep.SelectedIndex)
                {
                    lstMedicalRep.SelectedIndex = lstMedicalRep.SelectedIndex + 1;
                }
            }

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

        }

        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
        }

        private void frmRptStoreLedger_Load(object sender, EventArgs e)
        {
            uctxtMedicalRep.Visible = false;
            label4.Visible = false;
            rbtnAll.PerformClick();
            tetReportHader.Text = "Return Register";
            lstMedicalRep.Visible = false;           
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if ((rbtnAll.Checked == true) && (chkboxSummary.Checked == true))
            {
                string strBrachID = "";
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.rptPurchesRetSumm;
                frmviewer.strFdate = dteToDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strLedgerName = uctxtMedicalRep.Text;
                frmviewer.Show();
                return;
            }
            if ((rbtnIndividualParty.Checked == true) && (chkboxSummary.Checked == true))
            {
                string strBrachID = "";

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.rptPurchesRetSumm;
                frmviewer.strFdate = dteToDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strLedgerName = uctxtMedicalRep.Text;
                frmviewer.Show();
                return;
            }

            if (rbtnAll.Checked == true)
            {
                string strBrachID = "";

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.rptPurchesRetAll;
                frmviewer.strFdate = dteToDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.Show();
                return;
            }

            if (rbtnIndividualParty.Checked == true)
            {
                string strBrachID = "";

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.rptPurchesRetAll;
                frmviewer.strFdate = dteToDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strLedgerName = uctxtMedicalRep.Text;
                frmviewer.Show();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        private void rbtnIndividualParty_Click(object sender, EventArgs e)
        {
            uctxtMedicalRep.Visible = true;
            label4.Visible = true;
        }

        private void rbtnAll_Click(object sender, EventArgs e)
        {
            uctxtMedicalRep.Visible = false;
            label4.Visible = false;
            lstMedicalRep.Visible = false;
        }

        private void chkboxSummary_Click(object sender, EventArgs e)
        {
            if (chkboxSummary.Checked == true )
            {
                ChkboxNarr.Enabled = false;
            }
            else 
            {
                ChkboxNarr.Enabled = true;
            }
           
        }
    }
}
