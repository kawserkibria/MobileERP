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
    public partial class frmVoucherTypesList : JA.Shared.UI.frmSmartFormStandard
    {
        public long lngMtype { get; set; }
        public long lngFormPriv { get; set; }
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public frmVoucherTypesList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            timer1.Start();
        }

        #region "Load"
        private void frmVoucherTypesList_Load(object sender, EventArgs e)
        {
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "SL No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Name", "Name", 220, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Start", "Start", 80, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Width", "Width", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Prefix", "Prefix", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Suffix", "Suffix", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Total Voucher", "Total Voucher", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 70, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadVoucherTypesList();
        }
        #endregion
        #region "List"
        public void mLoadVoucherTypesList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<VoucherTypes> oogrp = accms.mLaodVoucherTypes(strComID, lngMtype, 0).ToList();
            if (oogrp.Count > 0)
            {

                foreach (VoucherTypes ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.voucherName;
                    DG[2, introw].Value = ogrp.StartingNo;
                    DG[3, introw].Value = ogrp.noWidth;
                    DG[4, introw].Value = ogrp.Prefix;
                    DG[5, introw].Value = ogrp.Suffix;
                    DG[6, introw].Value = ogrp.TotalVoucher;
                    DG[7, introw].Value = "Edit";
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
        private void DisplayVoucherList(List<VoucherTypes> tests, object sender, EventArgs e)
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<VoucherTypes> oogrp = accms.mLaodVoucherTypes(strComID, lngMtype, 0).ToList();
            if (oogrp.Count > 0)
            {

                foreach (VoucherTypes ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.voucherName;
                    DG[2, introw].Value = ogrp.StartingNo;
                    DG[3, introw].Value = ogrp.noWidth;
                    DG[4, introw].Value = ogrp.Prefix;
                    DG[5, introw].Value = ogrp.Suffix;
                    DG[6, introw].Value = ogrp.TotalVoucher;
                    DG[7, introw].Value = "Edit";
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

        #endregion
        #region "Click"
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                frmVoucherTypes objfrm = new frmVoucherTypes(Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString()), lngMtype);
                objfrm.onAddAllButtonClicked = new frmVoucherTypes.AddAllClick(DisplayVoucherList);
                objfrm.lngFormPriv = lngFormPriv;
                objfrm.MdiParent = MdiParent;
                objfrm.Show();
                objfrm.MdiParent = this.MdiParent;
            }

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            mLoadVoucherTypesList();
        }
        #endregion


    }
}
