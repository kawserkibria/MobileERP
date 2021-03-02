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
    public partial class frmIncentiveCalculationList : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public delegate void AddAllClick(List<IncentiveCal> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public int m_action { get; set; }
        public long lngFormPriv { get; set; }
        public int intVtype { get; set; }
        private string strComID { get; set; }

        public frmIncentiveCalculationList()
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
            List<IncentiveCal> oogrp = accms.mFillIncentive(strComID, 2021).ToList();
            if (oogrp.Count > 0)
            {
                foreach (IncentiveCal ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.intYear;
                    DG[1, introw].Value = ogrp.strFdate;
                    DG[2, introw].Value = ogrp.strTdate;
                    DG[3, introw].Value = "Edit";
                    DG[4, introw].Value = "Delete";
                    DG[5, introw].Value = "View";
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }

        private void frmIncentiveCalculationList_Load(object sender, EventArgs e)
        {
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("Year", "Year", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("From Date", "From Date", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("To Date","To Date", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 80, true, DataGridViewContentAlignment.TopCenter, true));
            GeIncentiveList();
        }
        private List<IncentiveCal> GetSelectedItem()
        {
            List<IncentiveCal> items = new List<IncentiveCal>();
            IncentiveCal itm = new IncentiveCal();
            itm.intYear = Convert.ToInt32( DG.CurrentRow.Cells[0].Value.ToString());
            itm.strFdate = DG.CurrentRow.Cells[1].Value.ToString();
            itm.strTdate  = DG.CurrentRow.Cells[2].Value.ToString();
            items.Add(itm);
            return items;
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
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
                    string i = accms.DeletetIncentive(strComID,Convert.ToInt32( DG.CurrentRow.Cells[0].Value.ToString()));
                    if (i == "1")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Incentive Calculation", DG.CurrentRow.Cells[0].Value.ToString(),
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                        }
                    }
                    GeIncentiveList();
                }
            }
            if (e.ColumnIndex == 3)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }

            if (e.ColumnIndex == 5)
            {
                try
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.IncPoleci;
                    frmviewer.intNarration= Convert.ToInt16( DG.CurrentRow.Cells[0].Value.ToString());
                    frmviewer.strString2 = DG.CurrentRow.Cells[3].Value.ToString(); ;
                    frmviewer.strHeading = "Incentive Policy ";
                    frmviewer.Show();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
