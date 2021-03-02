//using ExtraReports.Projection.Reports.RProjection.Viewer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Dutility;

using JA.Modulecontrolar.UI.Projection;
using System.Drawing.Drawing2D;
using JA.Modulecontrolar.EXTRA;




namespace JA.Modulecontrolar.UI.Projection.Forms
{
 
    public partial class frmMonthList : JA.Shared.UI.frmSmartFormStandard
    {
        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient();


        public delegate void AddAllClick(List<ProjectonMonthConfig> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }

        private ListBox lstLedger = new ListBox();
        private ListBox lstStatus = new ListBox();
        public string mstrOldCode { get; set; }
        public string strFormTitel { get; set; }
        
        public int intStatus = 0;
        public int mintOldStatus = 0;
        private string strStatusType = "";
        public int m_action { get; set; }
        private string strComID { get; set; }
        public frmMonthList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
           
        }

        private void frmMonthList_Load(object sender, EventArgs e)
        {
            //frmLabel.Text = strFormTitel;
            DG.AllowUserToAddRows = false;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("SerialNo", "SerialNo", 0, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Month ID", "Month ID", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("From Date", "From Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("To Date", "To Date", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Status", "Status", 80, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            GetMonthSetupList();  
        }
        private void GetMonthSetupList()
        {

            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<ProjectonMonthConfig> oogrp = objExtra.mFillMonthConfig(strComID, 3).ToList();
            if (oogrp.Count > 0)
            {
                foreach (ProjectonMonthConfig ogrp in oogrp)
                {


                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.intSerial;
                    DG[1, introw].Value = ogrp.strMonthID;
                    DG[2, introw].Value = ogrp.strFromDate;
                    DG[3, introw].Value = ogrp.strToDate;
                    if (ogrp.intStatus == 1)
                    {
                        DG[4, introw].Value = "Active";
                    }
                    if (ogrp.intStatus == 0)
                    {
                        DG[4, introw].Value = "Inactive";
                    }

                    DG[5, introw].Value = "Edit";
                    DG[6, introw].Value = "Delete";

                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }
        private List<ProjectonMonthConfig> GetSelectedItem()
        {

            List<ProjectonMonthConfig> items = new List<ProjectonMonthConfig>();
            ProjectonMonthConfig itm = new ProjectonMonthConfig();
            itm.intSerial = Convert.ToInt16(DG.CurrentRow.Cells[0].Value.ToString());
            itm.strMonthID = DG.CurrentRow.Cells[1].Value.ToString();
            itm.strFromDate = Convert.ToDateTime(DG.CurrentRow.Cells[2].Value).ToString("dd-MM-yyyy");
            itm.strToDate = Convert.ToDateTime(DG.CurrentRow.Cells[3].Value).ToString("dd-MM-yyyy");
            itm.strStatus = DG.CurrentRow.Cells[4].Value.ToString();
            items.Add(itm);
            return items;

        }

        private void DG_Click(object sender, EventArgs e)
        {

        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                //if (Utility.gblnAccessControl)
                //{
                //    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                //    {
                //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = objExtra.DeletetMonthConfig(strComID, Convert.ToInt16(DG.CurrentRow.Cells[0].Value.ToString()));

                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Projection Month Setup", "Projection Month Setup",
                                                            3, 0, (int)Utility.MODULE_TYPE.mtPURCHASE, "0001");
                    MessageBox.Show(i.ToString());
                    GetMonthSetupList();
                }
            }
            if (e.ColumnIndex == 5)
            {
                //if (Utility.gblnAccessControl)
                //{
                //    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                //    {
                //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
        }

    }
}
