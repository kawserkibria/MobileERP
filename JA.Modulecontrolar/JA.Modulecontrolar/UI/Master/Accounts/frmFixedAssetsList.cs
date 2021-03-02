using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Win32;


namespace JA.Modulecontrolar.UI.Master.Accounts
{
    public partial class frmFixedAssetsList : JA.Shared.UI.frmJagoronFromSearch
    {

        JACCMS.SWJAGClient accms = new SWJAGClient();
        public delegate void AddAllClick(List<FixedAssets> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        private string strComID { get; set; }
        public frmFixedAssetsList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

        private void frmFixedAssetsList_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "SL No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 340, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Dep. Method", "Dep. Method", 180, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Purchase Amount", "Purchase Amount", 170, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 50, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadFixedAssetsList();
        }

        private void mLoadFixedAssetsList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<FixedAssets> oogrp = accms.mAssetList(strComID).ToList();
            if (oogrp.Count > 0)
            {

                foreach (FixedAssets ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSerialNo;
                    DG[1, introw].Value = ogrp.strLedgerName;
                    DG[2, introw].Value = ogrp.strDepMethod;
                    DG[3, introw].Value = ogrp.dblPurchaseAmount;
                    DG[4, introw].Value = "Edit";
                    DG[5, introw].Value = "Delete";
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

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string strresponse = "";
            if (e.ColumnIndex==4)
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

            if (e.ColumnIndex == 5)
            {
                try
                {
                    if (Utility.gblnAccessControl)
                    {
                        if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 3))
                        {
                             MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                            return;
                        }
                    }
                    var strResponseDel = MessageBox.Show("Do You Want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponseDel == DialogResult.Yes)
                    {
                        strresponse = accms.mDeleteFixedAssets(strComID, Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString()), DG.CurrentRow.Cells[1].Value.ToString());
                        mLoadFixedAssetsList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(strresponse.ToString());
                }
            }
        }

        private List<FixedAssets> GetSelectedItem()
        {
            List<FixedAssets> items = new List<FixedAssets>();
            FixedAssets itm = new FixedAssets();
            itm.lngSerialNo = Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString());

            items.Add(itm);
            return items;
        }

        private void frmFixedAssetsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

    }
}
