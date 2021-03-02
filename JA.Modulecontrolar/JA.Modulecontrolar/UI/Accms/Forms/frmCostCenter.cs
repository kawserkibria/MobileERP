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
using JA.Modulecontrolar.UI.Forms;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmCostCenter : JA.Shared.UI.frmSmartFormStandard
    {
        public long lngFormPriv { get; set; }
        private string mstrOldCostCenter { get; set; }
        private ListBox lstCostCategory = new ListBox();
        private string strComID { get; set; }
        JACCMS.SWJAGClient accms = new SWJAGClient();

        public frmCostCenter()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtCostCategory.KeyDown += new KeyEventHandler(uctxtCostCategory_KeyDown);
            this.uctxtCostCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCostCategory_KeyPress);
            this.uctxtCostCategory.TextChanged += new System.EventHandler(this.uctxtCostCategory_TextChanged);
            this.lstCostCategory.DoubleClick += new System.EventHandler(this.lstCostCenter_DoubleClick);
            this.uctxtCostCategory.GotFocus += new System.EventHandler(this.uctxtCostCategory_GotFocus);
           
            this.uctxtCostCenter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCostCenter_KeyPress);
            this.uctxtCostCenter.GotFocus += new System.EventHandler(this.uctxtCostCenter_GotFocus);
            this.uctxtCostCenter.TextChanged += new System.EventHandler(this.uctxtCostCenter_TextChanged);
           
            Utility.CreateListBox(lstCostCategory, pnlMain, uctxtCostCategory);
            TabChange();
        }

        #region "User Define"
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

        private void uctxtCostCenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtCostCategory.Focus();
            }
        }
        private void uctxtCostCenter_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtCostCenter.SelectionStart;
            uctxtCostCenter.Text = Utility.gmakeProperCase(uctxtCostCenter.Text);
            uctxtCostCenter.SelectionStart = x;
        }
        private void uctxtCostCategory_TextChanged(object sender, EventArgs e)
        {
            lstCostCategory.SelectedIndex = lstCostCategory.FindString(uctxtCostCategory.Text);
        }

        private void lstCostCenter_DoubleClick(object sender, EventArgs e)
        {
            uctxtCostCategory.Text = lstCostCategory.Text;
            lstCostCategory.Visible = false;
            btnSave.Focus();
        }

        private void uctxtCostCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCostCategory.Items.Count > 0)
                {
                    uctxtCostCategory.Text = lstCostCategory.Text;
                }
                lstCostCategory.Visible = false;
                btnSave.Focus();

            }
        }
        private void uctxtCostCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCostCategory.SelectedItem != null)
                {
                    lstCostCategory.SelectedIndex = lstCostCategory.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCostCategory.Items.Count - 1 > lstCostCategory.SelectedIndex)
                {
                    lstCostCategory.SelectedIndex = lstCostCategory.SelectedIndex + 1;
                }
            }

        }

        private void uctxtCostCategory_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCategory.Visible = true;
            
        }
        private void uctxtCostCenter_GotFocus(object sender, System.EventArgs e)
        {
            lstCostCategory.Visible = false;

        }
        #endregion
        #region "Load"
        private void frmCostCenter_Load(object sender, EventArgs e)
        {
            lstCostCategory.Visible = false;
          

            lstCostCategory.DisplayMember = "strVectorcategory";
            lstCostCategory.ValueMember = "strVectorcategory";
            lstCostCategory.DataSource = accms.mFillVectorCategory(strComID).ToList();
            //mLoadCostCenter();

        }
        #endregion
        #region "Tab change
        private void TabChange()
        {
            uctxtCostCenter.Focus();
            uctxtCostCenter.AllToNextTab(uctxtCostCategory);
            uctxtCostCategory.AllToNextTab(btnSave);



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
            if (uctxtCostCenter.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtCostCenter.Focus();
                return;
            }
            if (uctxtOldCostCenter.Text == "")
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 1))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
               
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "VECTOR_MASTER", "VMASTER_NAME", uctxtCostCenter.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    uctxtCostCenter.Focus();
                    return;
                }

                var strResponseInsert = MessageBox.Show("Do You Want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        string strmsg = accms.mInsertCostCenter(strComID,uctxtCostCenter.Text, uctxtCostCategory.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Cost Center", uctxtCostCenter.Text,
                                                                    1, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                        } 
                        //mLoadCostCenter();
                        //uctxtCostCategory.Text = "";
                        uctxtOldCostCenter.Text = "";
                        uctxtCostCenter.Text = "";
                        uctxtCostCenter.Focus();
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
                if (uctxtOldCostCenter.Text != uctxtCostCenter.Text)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "VECTOR_MASTER", "VMASTER_NAME", uctxtCostCenter.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtCostCenter.Focus();
                        return;
                    }
                }


                var strResponseUpdate = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseUpdate == DialogResult.Yes)
                {
                    try
                    {
                        string strmsg = accms.mUpdateCostCenter(strComID, uctxtOldCostCenter.Text, uctxtCostCenter.Text, uctxtCostCategory.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Cost Center", uctxtCostCenter.Text,
                                                                    2, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                        }
                        uctxtCostCategory.Text = "";
                        uctxtOldCostCenter.Text = "";
                        uctxtCostCenter.Text = "";
                        uctxtCostCenter.Focus();
                        frmCostCenterList objfrm = new frmCostCenterList();
                        objfrm.onAddAllButtonClicked = new frmCostCenterList.AddAllClick(DisplayReqList);
                        objfrm.Show();
                        objfrm.MdiParent = this.MdiParent;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }


        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            frmCostCenterList objfrm = new frmCostCenterList();
            objfrm.onAddAllButtonClicked = new frmCostCenterList.AddAllClick(DisplayReqList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }
        private void DisplayReqList(List<VectorCategory> tests, object sender, EventArgs e)
        {
            try
            {
                uctxtOldCostCenter.Text = tests[0].strCostCenter;
                uctxtCostCategory.Text = tests[0].strVectorcategory;
                uctxtCostCenter.Text= tests[0].strCostCenter;
                uctxtCostCenter.Focus();
            }
            catch (Exception ex)
            {

            }
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 3)
            //{
            //    uctxtOldCostCenter.Text = DG.CurrentRow.Cells[1].Value.ToString();
            //    uctxtCostCenter.Text = DG.CurrentRow.Cells[1].Value.ToString();
            //    uctxtCostCategory.Text = DG.CurrentRow.Cells[2].Value.ToString();
            //    uctxtCostCenter.Focus();
            //}
            //if (e.ColumnIndex == 4)
            //{
            //    try
            //    {
            //        if (Utility.gblnAccessControl)
            //        {
            //            if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
            //            {
            //                 MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            //                return;
            //            }
            //        }
            //        var strResponseDel = MessageBox.Show("Do You Want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (strResponseDel == DialogResult.Yes)
            //        {
            //            string strresponse = accms.DeleteCostCenter(strComID, DG.CurrentRow.Cells[1].Value.ToString());
            //            if (Utility.gblnAccessControl)
            //            {
            //                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Cost Center", "Cost Center",
            //                                                        3, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
            //            } 
            //            MessageBox.Show(strresponse);
                      
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
        }
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmTreeView objfrm = new frmTreeView();
            objfrm.strType = "N";
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
       

      



    }
}
