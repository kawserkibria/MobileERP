using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
using JA.Modulecontrolar.UI.DReport.Inventory.Viewer;
using JA.Modulecontrolar.UI.DReport.Inventory;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmProcessInformationList : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<ManuProcess> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int intVtype { get; set; }
        private string strComID { get; set; }
        List<ManuProcess> oogrp;
        public frmProcessInformationList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
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
        private void frmProcessInformationList_Load(object sender, EventArgs e)
        {
            DgProcessList.AllowUserToAddRows = false;
            this.DgProcessList.DefaultCellStyle.Font = new Font("verdana", 9);
            DgProcessList.Columns.Add(Utility.Create_Grid_Column("Process Name", "Process Name", 450, true, DataGridViewContentAlignment.TopLeft, true));
            DgProcessList.Columns.Add(Utility.Create_Grid_Column("Location Name", "Location Name", 250, true, DataGridViewContentAlignment.TopLeft, true));
            DgProcessList.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DgProcessList.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DgProcessList.Columns.Add(Utility.Create_Grid_Column_button("Preview", "Preview", "Preview", 60, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadProcessList(0);
            if (intVtype == 0)
            {
                frmLabel.Text = "MFG Process List";
            }
            else
            {
                frmLabel.Text = "FG to FG Process List";
            }
        }
        private void mLoadProcessList(int intTransfer)
        {
            int introw = 0;
            this.DgProcessList.DefaultCellStyle.Font = new Font("verdana", 9);
            DgProcessList.Rows.Clear();
            oogrp = invms.mLoadProcess(strComID, "", "", intVtype,intTransfer,Utility.gstrUserName).ToList();
            if (oogrp.Count > 0)
            {
                foreach (ManuProcess ogrp in oogrp)
                {
                    DgProcessList.Rows.Add();
                    DgProcessList[0, introw].Value = ogrp.strProcessName;
                    DgProcessList[1, introw].Value = ogrp.strGodown;
                    DgProcessList[2, introw].Value = "Edit";
                    DgProcessList[3, introw].Value = "Delete";
                    DgProcessList[4, introw].Value = "Preview";
                  
                    introw += 1;
                }
                DgProcessList.AllowUserToAddRows = false;
                lblCount.Text = "Total Record :" + introw;
            }
        }

        private void DgProcessList_DoubleClick(object sender, EventArgs e)
        {
            //if (onAddAllButtonClicked != null)
            //    onAddAllButtonClicked(GetSelectedItem(), sender, e);
            //this.Dispose();
        }

        private List<ManuProcess> GetSelectedItem()
        {
            List<ManuProcess> items = new List<ManuProcess>();
            ManuProcess itm = new ManuProcess();
            itm.strProcessName = DgProcessList.CurrentRow.Cells[0].Value.ToString();
            items.Add(itm);
            return items;
        }

        private void DgProcessList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
            if (e.ColumnIndex == 3)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = invms.mDeleteProcess(strComID, DgProcessList.CurrentRow.Cells[0].Value.ToString());
                    if (i == "Delted...")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, DgProcessList.CurrentRow.Cells[0].Value.ToString(),
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                        }
                    }
                    MessageBox.Show(i.ToString());
                    if (chkTransfer.Checked)
                    {
                        mLoadProcessList(0);
                    }
                    else
                    {
                        mLoadProcessList(1);
                    }
                }
            }
            if (e.ColumnIndex == 4)
            {
                if (DgProcessList.Rows.Count == 0)
                {
                    return;
                }

                if (Utility.gblnAccessControl)
                {
                    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 90))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
              

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.MFGProcessReport;
                frmviewer.strString = DgProcessList.CurrentRow.Cells[0].Value.ToString();
                frmviewer.intype = 2;
                frmviewer.intSuppress = intVtype;
                frmviewer.Show();
            }

        }

        private void txtSerach_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListViewFG(oogrp, txtSerach.Text);
        }

        private void SearchListViewFG(IEnumerable<ManuProcess> tests, string searchString = "")
        {
            IEnumerable<ManuProcess> query;
         
            query = tests;

         
            if (searchString != "")
            {
                query = tests.Where(x => x.strProcessName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }
      
            DgProcessList.Rows.Clear();
            int introw = 0;
            try
            {
                foreach (ManuProcess ogrp in query)
                {
                    DgProcessList.Rows.Add();
                    DgProcessList[0, introw].Value = ogrp.strProcessName;
                    DgProcessList[1, introw].Value = ogrp.strGodown;
                    DgProcessList[2, introw].Value = "Edit";
                    DgProcessList[3, introw].Value = "Delete";
                    DgProcessList[4, introw].Value = "Preview";
                   
                    introw += 1;
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void chkTransfer_Click(object sender, EventArgs e)
        {
            if (chkTransfer.Checked)
            {
                mLoadProcessList(0);
            }
            else
            {
                mLoadProcessList(1);
            }
        }







    }
}
