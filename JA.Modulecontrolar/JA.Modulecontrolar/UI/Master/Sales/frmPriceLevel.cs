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


namespace JA.Modulecontrolar.UI.Master.Sales
{
    public partial class frmPriceLevel : JA.Shared.UI.frmSmartFormStandard
    {
         JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public int m_action{get;set;}
        public long lngFormPriv { get; set; }
        public string mstrOldLevelName {get;set;}
        private string strComID { get; set; }

        public frmPriceLevel()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtLevelName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLevelName_KeyPress);
            this.txtLevelName.TextChanged += new System.EventHandler(this.txtLevelName_TextChanged);
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
        #region "User Define"
        private void txtLevelName_TextChanged(object sender, EventArgs e)
        {
            int x = txtLevelName.SelectionStart;
            txtLevelName.Text = Utility.gmakeProperCase(txtLevelName.Text);
            txtLevelName.SelectionStart = x;
        }
       
        private void txtLevelName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strDuplicate = "";
            if (e.KeyChar == (char)Keys.Return)
            {

                if (mstrOldLevelName != txtLevelName.Text)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_PRICE_LEVEL", "PRICE_LEVEL_NAME", txtLevelName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtLevelName.Text = "";
                        txtLevelName.Focus();
                        return;
                    }
                }

                btnSave.Focus();

            }
        }
        #endregion
        #region "Load"
        private void frmPriceLevel_Load(object sender, EventArgs e)
        {
            txtLevelName.Select();
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "Sl No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Level Name", "Level Name", 350, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadPriceList();
           
        }
        #endregion
        private void mLoadPriceList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<SalesPriceLevel> oogrp = invms.mGetPriceLevel(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (SalesPriceLevel ogrp in oogrp)
                {
                    DG.Rows.Add();
                    //DG[0, introw].Value = ogrp.lngslNo;
                    DG[1, introw].Value = ogrp.strSalesPriceLevel;

                    DG[2, introw].Value = "Edit";
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

        #region "click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "",strDuplicate="";
            if (txtLevelName.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                txtLevelName.Focus();
                return;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (m_action == 2)
            {
                if (mstrOldLevelName != txtLevelName.Text)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_PRICE_LEVEL", "PRICE_LEVEL_NAME", txtLevelName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtLevelName.Text = "";
                        txtLevelName.Focus();
                        return;
                    }
                }
            }
            else
            {
                strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_PRICE_LEVEL", "PRICE_LEVEL_NAME", txtLevelName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    txtLevelName.Text = "";
                    txtLevelName.Focus();
                    return;
                }
            }

            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mSaveSalesPrice(strComID, txtLevelName.Text, m_action, mstrOldLevelName);

                        if (i == "Inseretd...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Price Level", txtLevelName.Text,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            } 
                            btnNew.PerformClick();
                            txtLevelName.Text ="";
                            txtLevelName.Focus();
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                            mLoadPriceList();
                        }
                        else
                        {
                            MessageBox.Show("Error!!!");
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mSaveSalesPrice(strComID, txtLevelName.Text, m_action, mstrOldLevelName);

                        if (i == "Updated...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Price Level",txtLevelName.Text,
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            } 
                            btnNew.PerformClick();
                            txtLevelName.Text ="";
                            txtLevelName.Focus();
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                            mLoadPriceList();
                        }
                        else
                        {
                            MessageBox.Show("Error!!!");
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==2)
            {
                m_action = 2;
                txtLevelName.Text =DG.CurrentRow.Cells[1].Value.ToString();
                mstrOldLevelName=DG.CurrentRow.Cells[1].Value.ToString();
            }

            if (e.ColumnIndex == 3)
            {
                var strResponse = MessageBox.Show("Do You  want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    string i = invms.mSaveSalesPrice(strComID, "", 3, DG.CurrentRow.Cells[1].Value.ToString());

                    if (i == "Deleted..")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Price Level", "Price Level",
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                        } 
                    }
                    MessageBox.Show(i.ToString());

                    mLoadPriceList();
                }
            }
        }
        #endregion












    }
}
