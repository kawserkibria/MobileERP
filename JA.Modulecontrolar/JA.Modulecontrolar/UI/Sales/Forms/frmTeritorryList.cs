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
using JA.Modulecontrolar.JINVMS;
using Microsoft.Win32;


namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmTeritorryList : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new JACCMS.SWJAGClient();
        public delegate void AddAllClick(List<Teritorry> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public int m_action { get; set; }
        public int intVtype { get; set; }
        private string strComID { get; set; }
        List<Teritorry> oogrp;
        public frmTeritorryList()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

           
            this.DG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DG_KeyPress);
        }
        private void DG_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 9)
            {
                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
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
        private void GetTeritorryList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            oogrp = accms.mFillTeritorry(strComID, "").ToList();
            if (oogrp.Count > 0)
            {
                foreach (Teritorry ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strTeritorrycode;
                    DG[1, introw].Value = ogrp.strTeritorryName;
                    DG[2, introw].Value = "Edit";
                    DG[3, introw].Value = "Delete";
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
                lblCount.Text = "Total Record :" + introw;
                DG.AllowUserToAddRows = false;
            }
        }

        private void frmListTransport_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
            uctxtSearch.Focus();
            uctxtSearch.Select();

            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("Teritorry Code", "Teritorry Code", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Teritorry Name", "Teritorry Name", 270, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            GetTeritorryList();
        }
        private List<Teritorry> GetSelectedItem()
        {
            List<Teritorry> items = new List<Teritorry>();
            Teritorry itm = new Teritorry();
            itm.strTeritorrycode = DG.CurrentRow.Cells[0].Value.ToString();
            itm.strTeritorryName = DG.CurrentRow.Cells[1].Value.ToString();
            items.Add(itm);
            return items;
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
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
                    string i = accms.DeletetTeritorry(strComID, DG.CurrentRow.Cells[0].Value.ToString());
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Teritorry", DG.CurrentRow.Cells[0].Value.ToString(),
                                                                3, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                    } 
                    MessageBox.Show(i.ToString());
                    GetTeritorryList();
                }
            }
            if (e.ColumnIndex == 2)
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

        private void uctxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                SearchListView(oogrp, uctxtSearch.Text);

            }
            catch (Exception ex)
            {

            }
        }

        private void SearchListView(IEnumerable<Teritorry> tests, string searchString = "")
        {
            IEnumerable<Teritorry> query;
            //if ((searchString.Length > 0))
            //{
            query = tests;

            //if (chkVoucheNo.Checked == true)
            //{
            if (searchString != "")
            {
                if (label1.Text == "Teritorry Code")
                {
                    query = tests.Where(x => x.strTeritorrycode.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                }
                else
                {
                    //query = tests.Where(x => x.strTeritorryName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
                    query = (from test in tests
                             where test.strTeritorryName.ToString().StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                             select test);
                }
                
            }
    
            DG.Rows.Clear();
            int introw = 0;
            try
            {
                foreach (Teritorry ogrp in query)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strTeritorrycode;
                    DG[1, introw].Value = ogrp.strTeritorryName;
                    DG[2, introw].Value = "Edit";
                    DG[3, introw].Value = "Delete";
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
                lblCount.Text = "Total Record :" + introw;
                DG.AllowUserToAddRows = false;
               


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==0)
            {
                label1.Text = "Teritorry Code";
            }
            else
            {
                label1.Text = "Teritorry Name";
            }
        }

        private void uctxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
         
            if (e.KeyCode == Keys.Up)
            {
                DG.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                DG.Focus();
            }

     
        }

        private void DG_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }
    }
}
