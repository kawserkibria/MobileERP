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
using Microsoft.Win32;



namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmSectionList : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<Section> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        private string strComID { get; set; }
        public frmSectionList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

        private void frmGroupConfigurationList_Load(object sender, EventArgs e)
        {
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "Sl No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Name", "Name", 600, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Show", "Show", "Show", 100, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 100, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadSectionList();
        }


        private void mLoadSectionList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<Section> oogrp = invms.mFillSection(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (Section ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.strSection;

                    DG[2, introw].Value = "Show";
                    DG[3, introw].Value = "Delete";
                    if (introw % 2 == 0)
                    {
                        DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    }
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = invms.mDeleteSection(strComID, DG.CurrentRow.Cells[1].Value.ToString());
                                                        
                    MessageBox.Show(i.ToString());
                    mLoadSectionList();
                }
            }
            if (e.ColumnIndex == 2)
            {
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
        }

        private List<Section> GetSelectedItem()
        {
            List<Section> items = new List<Section>();
            Section itm = new Section();
            itm.strSection = DG.CurrentRow.Cells[1].Value.ToString();
            items.Add(itm);
            return items;
        }
    }
}
