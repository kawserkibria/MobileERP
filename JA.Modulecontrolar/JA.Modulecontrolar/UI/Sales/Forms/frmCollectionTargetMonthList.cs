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



namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmCollectionTargetMonthList : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public delegate void AddAllClick(List<AccountdGroup> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public int m_action { get; set; }
        public long lngFormPriv { get; set; }
        public int intVtype { get; set; }
        private string strComID { get; set; }

        public frmCollectionTargetMonthList()
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
        private void GeMonthSetupList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<AccountdGroup> oogrp = accms.mDisplayGraceMonthsetupList(strComID, "").ToList();
            if (oogrp.Count > 0)
            {
                foreach (AccountdGroup ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strMonthID;
                    DG[1, introw].Value = ogrp.strFromdate;
                    DG[2, introw].Value = ogrp.strTodate;
                    DG[3, introw].Value = ogrp.strGFromDate;
                    DG[4, introw].Value = ogrp.strGTodate;
                    DG[5, introw].Value = ogrp.strStstus;
                    DG[6, introw].Value = "Edit";
                    DG[7, introw].Value = "Delete";
                    //if (introw % 2 == 0)
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }

        private void frmCollectionTargetMonthList_Load(object sender, EventArgs e)
        {
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("Month ID", "Month ID", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("From Date", "From Date", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("To Date","To Date", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Grace From Date", "Grace Date", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Grace To Date", "Grace To Date", 125, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Status", "Status", 100, true, DataGridViewContentAlignment.TopLeft, true));            
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));
            GeMonthSetupList();
        }
        private List<AccountdGroup> GetSelectedItem()
        {
            List<AccountdGroup> items = new List<AccountdGroup>();
            AccountdGroup itm = new AccountdGroup();
            itm.strMonthID = DG.CurrentRow.Cells[0].Value.ToString();
            itm.strFromdate = DG.CurrentRow.Cells[1].Value.ToString();
            itm.strTodate  = DG.CurrentRow.Cells[2].Value.ToString();
            itm.strGFromDate = DG.CurrentRow.Cells[3].Value.ToString();
            itm.strGTodate = DG.CurrentRow.Cells[4].Value.ToString();

            itm.strStstus = DG.CurrentRow.Cells[5].Value.ToString();
            items.Add(itm);
            return items;
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 3))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = accms.mDeleteGraceMonthList(strComID, DG.CurrentRow.Cells[0].Value.ToString());
                    if (i == "1")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Collection Month Setup", DG.CurrentRow.Cells[0].Value.ToString(),
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                        }
                    }
                    GeMonthSetupList();
                }
            }
            if (e.ColumnIndex == 6)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
        }
    }
}
