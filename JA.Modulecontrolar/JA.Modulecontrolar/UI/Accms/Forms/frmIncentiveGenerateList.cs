using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Accms.Forms;
using Dutility;
using Microsoft.Win32;
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using JA.Modulecontrolar.UI.DReport.Accms;



namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmIncentiveGenerateList : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
       
        public int m_action { get; set; }
        public long lngFormPriv { get; set; }
        public int intVtype { get; set; }
        private string strComID { get; set; }

        public frmIncentiveGenerateList()
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
        private void GeIncentiveList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<IncentiveCal> oogrp = accms.mFillIncentiveGenList(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (IncentiveCal ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strIncentiveKey;
                    DG[1, introw].Value = ogrp.intYear.ToString();
                    DG[2, introw].Value = ogrp.strEffetiveMonth;
                    DG[3, introw].Value = ogrp.strInc_Mode;
                    if (ogrp.intType==1)
                    {
                    DG[4, introw].Value = "MPO";
                    }
                    else  if (ogrp.intType==2)
                    {
                    DG[4, introw].Value = "AH";
                    }
                    else  if (ogrp.intType==3)
                    {
                    DG[4, introw].Value = "DH";
                    }
                    DG[5, introw].Value = "Delete";
                    DG[6, introw].Value = "View";
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }

        private void frmIncentiveCalculationList_Load(object sender, EventArgs e)
        {
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("Key", "Key", 80, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Year", "Year", 80, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Month ID", "Month ID", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Mode", "Mode", 80, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Type", "Type", 80, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 60, true, DataGridViewContentAlignment.TopCenter, true));
            
            GeIncentiveList();
        }
       

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = accms.DeletetIncentiveGenList(strComID, DG.CurrentRow.Cells[0].Value.ToString());
                    if (i == "1")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Incentive Generation", DG.CurrentRow.Cells[0].Value.ToString(),
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                        }
                    }
                    GeIncentiveList();
                }
            }
            if (e.ColumnIndex == 6)
            {
                try
                {
                    int inttype = 1;
                    if (DG.CurrentRow.Cells[4].Value.ToString()=="MPO")
                    {
                        inttype = 1;
                    }
                    else if (DG.CurrentRow.Cells[4].Value.ToString() == "AH")
                    {
                        inttype = 2;
                    }
                    else
                    {
                        inttype = 3;
                    }
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.IncGenview;
                    frmviewer.strString = DG.CurrentRow.Cells[0].Value.ToString();
                    frmviewer.strString2 = DG.CurrentRow.Cells[3].Value.ToString(); ;
                    frmviewer.intSalesCollection = inttype;
                    frmviewer.strHeading = "Monthly Incentive " + DG.CurrentRow.Cells[4].Value.ToString();
                    frmviewer.Show();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
