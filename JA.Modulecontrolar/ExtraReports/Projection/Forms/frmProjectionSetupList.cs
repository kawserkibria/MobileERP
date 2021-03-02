
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
using ExtraReports.EXTRA;
using ExtraReports.Projection;
using System.Drawing.Drawing2D;


namespace ExtraReports.Projection.Forms
{
 
    public partial class frmProjectionSetupList : JA.Shared.UI.frmSmartFormStandard
    {
       
        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient();
        public delegate void AddAllClick(List<ProjectionSet> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }

        private ListBox lstLedger = new ListBox();
        private ListBox lstStatus = new ListBox();
        public string mstrOldCode { get; set; }
        public string strFormTitel { get; set; }
        
        public int intStatus = 0;
        public int mintOldStatus = 0;

        public int m_action { get; set; }
        private string strComID { get; set; }
        public frmProjectionSetupList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
           
        }


        private void GetProjectionSetupList()
        {

            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<ProjectionSet> oogrp = objExtra.mFillPojictionConfig(strComID, "").ToList();
            if (oogrp.Count > 0)
            {
                foreach (ProjectionSet ogrp in oogrp)
                {


                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strProjectionKey;
                    DG[1, introw].Value = ogrp.strMonthID;
                    DG[2, introw].Value = ogrp.strProjectionName;
                    DG[3, introw].Value = ogrp.strProjectionDate;
                    DG[4, introw].Value = ogrp.strStartDate;
                    DG[5, introw].Value = ogrp.strEndDate;
                    DG[6, introw].Value = "Edit";
                    DG[7, introw].Value = "Delete";

                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }
        private List<ProjectionSet> GetSelectedItem()
        {

            List<ProjectionSet> items = new List<ProjectionSet>();
            ProjectionSet itm = new ProjectionSet();
            //itm.intSerial = Convert.ToInt16(DG.CurrentRow.Cells[0].Value.ToString());
            itm.strProjectionKey = DG.CurrentRow.Cells[0].Value.ToString();
            itm.strMonthID = DG.CurrentRow.Cells[1].Value.ToString();
            itm.strProjectionName= DG.CurrentRow.Cells[2].Value.ToString();
            itm.strProjectionDate = Convert.ToDateTime(DG.CurrentRow.Cells[3].Value).ToString("dddd, MMMM d, yyyy");
            itm.strStartDate = Convert.ToDateTime(DG.CurrentRow.Cells[4].Value).ToString("dddd, MMMM d, yyyy");
            itm.strEndDate = Convert.ToDateTime(DG.CurrentRow.Cells[5].Value).ToString("dddd, MMMM d, yyyy");
            //itm.intfriday = Convert.ToInt16(DG.CurrentRow.Cells[4].Value.ToString());
            //itm.intHoliday = Convert.ToInt16(DG.CurrentRow.Cells[5].Value.ToString());
            //itm.strStatus = DG.CurrentRow.Cells[6].Value.ToString();
            items.Add(itm);
           
            return items;

        }

        private void DG_Click(object sender, EventArgs e)
        {

        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
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
                    string i = objExtra.DeletetProjectionSetUp(strComID, DG.CurrentRow.Cells[0].Value.ToString());

                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Month Setup", "Month Setup",
                                                            3, 0, (int)Utility.MODULE_TYPE.mtPURCHASE, "0001");
                    MessageBox.Show(i.ToString());
                    GetProjectionSetupList();
                }
            }
            if (e.ColumnIndex == 6)
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

        private void frmProjectionSetupList_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("ProjectionKey", "ProjectionKey", 0, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Month ID", "Month ID", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Projection Name", "Projection Name", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Projection Date", "Projection Date", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Start Date", "Start Date", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("End Date", "End Date", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            GetProjectionSetupList();  
        }

    }
}
