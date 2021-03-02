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
using JA.Modulecontrolar.UI.DReport.Inventory.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Inventory.ParameterForms
{
    public partial class frmRptBOMList : JA.Shared.UI.frmSmartFormStandard
    {
       
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstProcess = new ListBox();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public string strName { get; set; }
        private string strComID { get; set; }
        public frmRptBOMList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

           
            this.uctxtName.KeyDown += new KeyEventHandler(uctxtName_KeyDown);
            this.uctxtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtName_KeyPress);
            this.uctxtName.TextChanged += new System.EventHandler(this.uctxtName_TextChanged);
            this.lstProcess.DoubleClick += new System.EventHandler(this.lstProcess_DoubleClick);
            this.uctxtName.GotFocus += new System.EventHandler(this.uctxtName_GotFocus);
            Utility.CreateListBox(lstProcess, pnlMain, uctxtName, 0);
         
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
        private void uctxtName_TextChanged(object sender, EventArgs e)
        {
           
            lstProcess.SelectedIndex = lstProcess.FindString(uctxtName.Text);
        }

        private void lstProcess_DoubleClick(object sender, EventArgs e)
        {
            uctxtName.Text = lstProcess.Text;
            lstProcess.Visible = false;  
            btnPrint.Focus();


        }

        private void uctxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstProcess.Items.Count > 0)
                {
                    uctxtName.Text = lstProcess.Text;
                }
                lstProcess.Visible = false;  
                btnPrint.Focus();


            }
        }
       
        private void uctxtName_KeyDown(object sender, KeyEventArgs e)
        {
            lstProcess.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                if (lstProcess.SelectedItem != null)
                {
                    lstProcess.SelectedIndex = lstProcess.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstProcess.Items.Count - 1 > lstProcess.SelectedIndex)
                {
                    lstProcess.SelectedIndex = lstProcess.SelectedIndex + 1;
                }
            }

        }

        private void uctxtName_GotFocus(object sender, System.EventArgs e)
        {
            
            

        }

        //private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Return)
        //    {
        //        dteToDate.Focus();

        //    }
        //}

        //private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        //{
        //    lstProcess.Visible = false;  
        //}
        //private void dteToDate_GotFocus(object sender, System.EventArgs e)
        //{
        //    lstProcess.Visible = false;  

        //}
        

        //private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Return)
        //    {
        //        btnPrint.Focus();

        //    }
        //}
       

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {

            string strSelection = "";
            if (radWithAlias.Checked)
            {
                strSelection = "W";
            }
            else if (radWithoutAlias.Checked)
            {
                strSelection = "O";
            }
            else
            {
                strSelection = "N";
            }

            if (uctxtName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtName.Focus();
                return;
            }
            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.BOMList;
            frmviewer.strString = uctxtName.Text;
            frmviewer.strSelction = strSelection;
            frmviewer.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void frmRptBOMList_Load(object sender, EventArgs e)
        {
            lstProcess.Visible = false;
            lstProcess.ValueMember = "strProcessName";
            lstProcess.DisplayMember = "strProcessName";
            lstProcess.DataSource = invms.mLoadProcess(strComID, "", "", 0,0).ToList();
            if (Utility.gstrUserName.ToUpper() =="DEEPLAID")
            {
                pnlSelection.Visible = true;
            }
            else
            {
                pnlSelection.Visible = false;
            }
        }

        private void chkstockrequisition_Click(object sender, EventArgs e)
        {
            if (chkstockrequisition.Checked==true)
            {
                lstProcess.Visible = false;
                lstProcess.ValueMember = "strProcessName";
                lstProcess.DisplayMember = "strProcessName";
                lstProcess.DataSource = invms.mLoadProcess(strComID, "", "", 0, 1).ToList();
            }
            else
            {
                lstProcess.Visible = false;
                lstProcess.ValueMember = "strProcessName";
                lstProcess.DisplayMember = "strProcessName";
                lstProcess.DataSource = invms.mLoadProcess(strComID, "", "", 0, 0).ToList();
            }
            uctxtName.Focus();

        }


    }
}
