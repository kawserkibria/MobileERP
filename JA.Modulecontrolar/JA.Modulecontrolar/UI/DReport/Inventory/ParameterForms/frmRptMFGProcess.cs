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
    public partial class frmRptMFGProcess : JA.Shared.UI.frmSmartFormStandard
    {
       
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstProcess = new ListBox();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public string strName { get; set; }
        private string strComID { get; set; }
        public frmRptMFGProcess()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            //this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);
            this.uctxtName.KeyDown += new KeyEventHandler(uctxtName_KeyDown);
            this.uctxtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtName_KeyPress);
            this.uctxtName.TextChanged += new System.EventHandler(this.uctxtName_TextChanged);
            this.lstProcess.DoubleClick += new System.EventHandler(this.lstProcess_DoubleClick);
            this.uctxtName.GotFocus += new System.EventHandler(this.uctxtName_GotFocus);
            this.btnRowDelete.Click += new System.EventHandler(this.btnRowDelete_Click);
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
          
            uctxtQty.Focus();


        }

        private void uctxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstProcess.Items.Count > 0)
                {
                    uctxtName.Text = lstProcess.Text;
                }
               
                uctxtQty.Focus();


            }
        }
        private void mAddItem(string strProcess,double dblQty)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text =strProcess;
            lvi.SubItems.Add(dblQty.ToString());
            lvwProcess.Items.Add(lvi);
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



        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
            lstProcess.Visible = false;  
        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
           

        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtName.Text == "")
                {
                    btnPrint.Focus();
                }
                else
                {
                    uctxtName.Focus();
                }
                mAddItem(uctxtName.Text,Utility.Val(uctxtQty.Text.ToString()));
                uctxtName.Text = "";
                uctxtQty.Text = "";
                

              

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intCheck=0;
            double dblQty=0;
            string strString = "";

            for (intCheck = 0; intCheck < lvwProcess.Items.Count;intCheck ++ )
            {
                if (lvwProcess.Items[intCheck].Checked == true)
                {
                   
                    dblQty = Utility.Val(lvwProcess.Items[intCheck].SubItems[1].Text.ToString());
                    strString += lvwProcess.Items[intCheck].Text + "~" + dblQty + "|";
                }
               

            }

               if (strString =="")
               {
                   return;
               }
                
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.MFGProcessReport;
                frmviewer.strString = strString;
                frmviewer.intype = 1;
                frmviewer.Show();
            
           
           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void frmRptProduct_Load(object sender, EventArgs e)
        {
            lstProcess.Visible = false;
            lstProcess.ValueMember = "strProcessName";
            lstProcess.DisplayMember = "strProcessName";
            lstProcess.DataSource = invms.mLoadProcess(strComID, "", "", 0, 0, Utility.gstrUserName).ToList();
        }


        private void chkSelectAll_Click(object sender, EventArgs e)
        {
            if (lvwProcess.Items.Count>0)
            {
                if (chkSelectAll.Checked == true)
                {
                    int intcount = lvwProcess.Items.Count;
                    for (int i = 0; i < intcount; i++)
                    {
                        lvwProcess.Items[i].Checked = true;
                    }
                }
                else
                {
                    int intcount = lvwProcess.Items.Count;
                    for (int i = 0; i < intcount; i++)
                    {
                        lvwProcess.Items[i].Checked = false;
                    }
                }
            }
            chkSelectAll.Checked = false;

        }

        private void btnRowDelete_Click(object sender, EventArgs e)
        {
            
           if (lvwProcess.Items.Count>0)
           {
               for (int i = 0; i < lvwProcess.Items.Count; i++)
               {
                   if (lvwProcess.Items[i].Checked == true)
                   {
                       lvwProcess.Items.RemoveAt(i);
                   }
               }
              
           }
            
        }

        private void btnRowDelete_Click_1(object sender, EventArgs e)
        {

        }

        private void chkStockRequisition_Click(object sender, EventArgs e)
        {
            if (chkStockRequisition.Checked == true)
            {
                lstProcess.Visible = false;
                lstProcess.ValueMember = "strProcessName";
                lstProcess.DisplayMember = "strProcessName";
                lstProcess.DataSource = invms.mLoadProcess(strComID, "", "", 0, 0, Utility.gstrUserName).ToList();
            }
            else
            {
                lstProcess.Visible = false;
                lstProcess.ValueMember = "strProcessName";
                lstProcess.DisplayMember = "strProcessName";
                lstProcess.DataSource = invms.mLoadProcess(strComID, "", "", 0, 1, Utility.gstrUserName).ToList();
            }
            uctxtName.Focus();
        }

        private void chkStockRequisition_CheckedChanged(object sender, EventArgs e)
        {

        }

       
    }
}
