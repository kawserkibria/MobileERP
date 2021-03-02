using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using JA.Modulecontrolar.UI.Forms;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    
    public partial class frmCostCategory : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public long lngFormPriv { get; set; }
        private string strComID { get; set; }
        public frmCostCategory()
        {
            InitializeComponent();

            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtCostCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCostCategory_KeyPress);
            this.uctxtCostCategory.TextChanged += new System.EventHandler(this.uctxtCostCategory_TextChanged);
            TabChange();

        }
        #region "User Define Event"
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

        private void uctxtCostCategory_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtCostCategory.SelectionStart;
            uctxtCostCategory.Text = Utility.gmakeProperCase(uctxtCostCategory.Text);
            uctxtCostCategory.SelectionStart = x;
        }
        private void uctxtCostCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

               btnSave.Focus();
            }
        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (uctxtCostCategory.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtCostCategory.Focus();
                return;
            }
            if (txtOldCategory.Text == "")
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 1))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "VECTOR_CATEGORY", "VECTOR_CATEGORY_NAME", uctxtCostCategory.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    //uctxtCostCategory.Text = "";
                    uctxtCostCategory.Focus();
                    txtOldCategory.Text = "";
                    return;
                }

                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        string strmsg = accms.mInsertCostCategory(strComID,uctxtCostCategory.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Cost Category", uctxtCostCategory.Text,
                                                                    1, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                        } 
                        mLoadCategoryList();
                        uctxtCostCategory.Text = "";
                        txtOldCategory.Text = "";
                        uctxtCostCategory.Focus();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                if (txtOldCategory.Text != uctxtCostCategory.Text)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "VECTOR_CATEGORY", "VECTOR_CATEGORY_NAME", uctxtCostCategory.Text);
                    if (strDuplicate != "")
                    {
                        uctxtCostCategory.Focus();
                        txtOldCategory.Text = "";
                        return;
                    }
                }



                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {

                        string strmsg = accms.mUpdateCostCategory(strComID,txtOldCategory.Text, uctxtCostCategory.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Cost Category", uctxtCostCategory.Text,
                                                                    2, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                        } 
                        mLoadCategoryList();
                        uctxtCostCategory.Text = "";
                        txtOldCategory.Text = "";
                        uctxtCostCategory.Focus();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }


        }
        private void mLoadCategoryList()
        {
            int introw = 0;
            DG.AllowUserToAddRows = false;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<VectorCategory> oogrp = accms.mFillVectorCategory(strComID).ToList();
            if (oogrp.Count > 0)
            {

                foreach (VectorCategory ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.strVectorcategory;
                    DG[2, introw].Value = ogrp.strVectorcategory;
                    DG[3, introw].Value = "Edit";
                    DG[4, introw].Value = "Delete";
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
            if (e.ColumnIndex == 3)
            {
                txtOldCategory.Text = DG.CurrentRow.Cells[1].Value.ToString();
                uctxtCostCategory.Text = DG.CurrentRow.Cells[1].Value.ToString();
                uctxtCostCategory.Focus();
            }
            if (e.ColumnIndex == 4)
            {
                try
                {
                    if (Utility.gblnAccessControl)
                    {
                        if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                        {
                             MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                            return;
                        }
                    }

                    var strResponseDel = MessageBox.Show("Do You Want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponseDel == DialogResult.Yes)
                    {
                        string strresponse = accms.DeleteCostCategory(strComID,DG.CurrentRow.Cells[1].Value.ToString());
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Cost Category", "Cost Category",
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                        } 
                        MessageBox.Show(strresponse);
                        mLoadCategoryList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {


            frmTreeView objfrm = new frmTreeView();
            objfrm.strType = "N";
            objfrm.Show();
            objfrm.MdiParent = MdiParent;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //btnSave.Enabled = true;
            //btnEdit.Enabled = false;
        }
        #endregion
        #region "Load"
        private void frmCostCategory_Load(object sender, EventArgs e)
        {
            this.DG.DefaultCellStyle.Font = new Font("verdana", 10F);
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "Sl No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("OldCategory", "OldCategory", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Cost Catgory", "Cost Catgory", 530, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 80, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 80, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadCategoryList();
        }
        #endregion
        #region "Tab change
        private void TabChange()
        {
            uctxtCostCategory.Focus();

            uctxtCostCategory.AllToNextTab(btnSave);
            



        }
        #endregion
       

     


    }
}
