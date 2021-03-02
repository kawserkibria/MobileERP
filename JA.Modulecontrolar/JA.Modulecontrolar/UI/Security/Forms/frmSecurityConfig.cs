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
using JA.Modulecontrolar.UI.Forms;
using JA.Modulecontrolar.UI.Accms.Forms;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Security.Forms
{
    public partial class frmSecurityConfig : JA.Shared.UI.frmJagoronFromSearch
    {
      
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public int m_action { get; set; }
        public int mSingleEntry { get; set; }
        List<AccountdGroup> oform;
        private string strComID { get; set; }

        public frmSecurityConfig()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.cmoModuleConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cmoModuleConfig_KeyPress);
            this.cboModeType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboModeType_KeyPress);
            this.cboStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboStatus_KeyPress);
            this.uctxtFormKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFormKey_KeyPress);
            this.uctxtFormKey.TextChanged += new System.EventHandler(this.uctxtFormKey_TextChanged);
            this.uctxtformName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtformName_KeyPress);
            this.uctxtformName.TextChanged += new System.EventHandler(this.uctxtformName_TextChanged);
        }
     
        #region "User Define Event"
        private void uctxtformName_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtformName.SelectionStart;
            uctxtformName.Text = Utility.gmakeProperCase(uctxtformName.Text);
            uctxtformName.SelectionStart = x;
        }
        private void uctxtFormKey_TextChanged(object sender, EventArgs e)
        {
            //int x = uctxtFormKey.SelectionStart;
            //uctxtFormKey.Text = Utility.gmakeProperCase(uctxtFormKey.Text);
            //uctxtFormKey.SelectionStart = x;
        }
        private void cboModeType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                cboStatus.Focus();

            }
        }
        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtFormKey.Focus();

            }
        }
        private void uctxtFormKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtformName.Focus();

            }
        }
        private void uctxtformName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();

            }
        }
        private void cmoModuleConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                cboModeType.Focus();

            }
        }
        #endregion
        private void frmBranch_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;
          
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "SL No", 70, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Form Key", "Form Key", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Form Name", "Form Name", 230, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Module Name", "Module Name", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Mode Type", "Mode type", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Status", "Status", 100, true, DataGridViewContentAlignment.TopLeft, true));
            LoadDefaultValue();
            mClear();
        }

        private void LoadDefaultValue()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"Sales", (int)Utility.MODULE_TYPE.mtSALES },
              {"Purchase", (int)Utility.MODULE_TYPE.mtPURCHASE},
              {"Accounts", (int)Utility.MODULE_TYPE.mtACCOUNT},
              {"Inventory", (int)Utility.MODULE_TYPE.mtSTOCK},
               {"Projection", (int)Utility.MODULE_TYPE.mtProjection},
              {"Tools", (int)Utility.MODULE_TYPE.mtTOOLS}
            };

            cmoModuleConfig.DisplayMember = "Key";
            cmoModuleConfig.ValueMember = "Value";
            cmoModuleConfig.DataSource = new BindingSource(userCache, null);

            SortedDictionary<string, int> userCache1 = new SortedDictionary<string, int>
            {
              {"Master", 1},
              {"Transaction", 2},
              {"Reports", 3}
             
            };

            cboModeType.DisplayMember = "Key";
            cboModeType.ValueMember = "Value";
            cboModeType.DataSource = new BindingSource(userCache1, null);

            SortedDictionary<string, int> userCache2 = new SortedDictionary<string, int>
            {
              {"Active", 0},
              {"Inactive", 1}
              
             
            };

            cboStatus.DisplayMember = "Key";
            cboStatus.ValueMember = "Value";
            cboStatus.DataSource = new BindingSource(userCache2, null);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strResponse="";
            int intModuleConfig, intMode, intstaus;
            if (cboModeType.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                cboModeType.Focus();
                return;
            }
            if (cmoModuleConfig.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                cmoModuleConfig.Focus();
                return;
            }
            if (uctxtFormKey.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtFormKey.Focus();
                return;
            }
            if (uctxtformName.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtformName.Focus();
                return;
            }
            intModuleConfig = Convert.ToInt32(cmoModuleConfig.SelectedValue.ToString());
            intMode = Convert.ToInt32(cboModeType.SelectedValue.ToString());
            intstaus = Convert.ToInt32(cboStatus.SelectedValue.ToString());

            if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
            {
                var strResponseInsert = MessageBox.Show("Do You Want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        string strmsg = accms.mSaveFormConfig(strComID, uctxtFormKey.Text, uctxtformName.Text, intModuleConfig, intMode, intstaus);
                        //MessageBox.Show(strmsg);
                        if (mSingleEntry == 1)
                        {
                            mSingleEntry = 0;
                            this.Dispose();
                        }

                        mClear();

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
                        string strmsg = accms.mUpdateFormConfig(strComID, Convert.ToInt64(txtSlNo.Text), uctxtFormKey.Text, uctxtformName.Text, intModuleConfig, intMode, intstaus);
                       // MessageBox.Show(strmsg);
                        if (mSingleEntry == 1)
                        {
                            mSingleEntry = 0;
                            this.Dispose();
                        }
                        m_action = 1;
                        mClear();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
          



        }

        private void mClear()
        {
            txtSlNo.Text = "";
            uctxtFormKey.Text = "";
            uctxtformName.Text = "";
            m_action = 1;
            mLoadFormList();
            uctxtFormKey.Focus();
           
        }

        private void mLoadFormList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            oform = accms.mDisplayFormList(strComID, 0).ToList();
            if (oform.Count > 0)
            {

                foreach (AccountdGroup ogrp in oform)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.strKey;
                    DG[2, introw].Value = ogrp.strFormName;
                    if (ogrp.intModule==(int)Utility.MODULE_TYPE.mtSALES)
                    {
                    DG[3, introw].Value = "Sales";
                    }
                    else if (ogrp.intModule == (int)Utility.MODULE_TYPE.mtPURCHASE)
                    {
                        DG[3, introw].Value = "Purchase";
                    }
                    else if (ogrp.intModule == (int)Utility.MODULE_TYPE.mtSTOCK)
                    {
                        DG[3, introw].Value = "Inventory";
                    }
                    else if (ogrp.intModule == (int)Utility.MODULE_TYPE.mtACCOUNT)
                    {
                        DG[3, introw].Value = "Accounts";
                    }
                    else if (ogrp.intModule == (int)Utility.MODULE_TYPE.mtTOOLS)
                    {
                        DG[3, introw].Value = "Tools";
                    }
                    else if (ogrp.intModule == (int)Utility.MODULE_TYPE.mtProjection)
                    {
                        DG[3, introw].Value = "Projection";
                    }
                    if (ogrp.intMode == 1)
                    {
                        DG[4, introw].Value = "Master";
                    }
                    else if (ogrp.intMode == 2)
                    {
                        DG[4, introw].Value = "Transaction";
                    }
                    else if (ogrp.intMode == 3)
                    {
                        DG[4, introw].Value = "Reports";
                    }
                    if (ogrp.intStatus == 0)
                    {
                        DG[5, introw].Value = "Active";
                    }
                    else
                    {
                        DG[5, introw].Value = "Inactive";
                    }
                 
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
           

        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex==1)
            //{
            //    lblSearch.Text = "Form Key";
            //}
            //else if (e.ColumnIndex == 2)
            //{
            //    lblSearch.Text = "Form Name";
            //}
            //else if (e.ColumnIndex == 1)
            //{
            //    lblSearch.Text = "Module Name";
            //}
            //else if (e.ColumnIndex == 1)
            //{
            //    lblSearch.Text = "Stat";
            //}

            if (DG.Rows.Count > 0)
            {
                long lngSl = Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString());
                txtSlNo.Text = lngSl.ToString();

                uctxtFormKey.Text = DG.CurrentRow.Cells[1].Value.ToString();
                uctxtformName.Text = DG.CurrentRow.Cells[2].Value.ToString();
                cmoModuleConfig.Text = DG.CurrentRow.Cells[3].Value.ToString();
                cboModeType.Text = DG.CurrentRow.Cells[4].Value.ToString();
                cboStatus.Text = DG.CurrentRow.Cells[5].Value.ToString();
                m_action = 2;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            mClear();
        }

        private void uctxtSeacrh_KeyUp(object sender, KeyEventArgs e)
        {
            SearchListView(oform, uctxtSeacrh.Text);
        }

        private void SearchListView(IEnumerable<AccountdGroup> tests, string searchString)
        {
            IEnumerable<AccountdGroup> query;
            query = tests;

            if (searchString != "")
            {
                query = tests.Where(x => x.strFormName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
            }
            DG.Rows.Clear();
            int introw = 0;
            try
            {
                foreach (AccountdGroup ogrp in query)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngSlNo;
                    DG[1, introw].Value = ogrp.strKey;
                    DG[2, introw].Value = ogrp.strFormName;
                    if (ogrp.intModule == (int)Utility.MODULE_TYPE.mtSALES)
                    {
                        DG[3, introw].Value = "Sales";
                    }
                    else if (ogrp.intModule == (int)Utility.MODULE_TYPE.mtPURCHASE)
                    {
                        DG[3, introw].Value = "Purchase";
                    }
                    else if (ogrp.intModule == (int)Utility.MODULE_TYPE.mtSTOCK)
                    {
                        DG[3, introw].Value = "Inventory";
                    }
                    else if (ogrp.intModule == (int)Utility.MODULE_TYPE.mtACCOUNT)
                    {
                        DG[3, introw].Value = "Accounts";
                    }
                    else if (ogrp.intModule == (int)Utility.MODULE_TYPE.mtTOOLS)
                    {
                        DG[3, introw].Value = "Tools";
                    }
                    else if (ogrp.intModule == (int)Utility.MODULE_TYPE.mtProjection)
                    {
                        DG[3, introw].Value = "Projection";
                    }

                    if (ogrp.intMode == 1)
                    {
                        DG[4, introw].Value = "Master";
                    }
                    else if (ogrp.intMode == 2)
                    {
                        DG[4, introw].Value = "Transaction";
                    }
                    else if (ogrp.intMode == 3)
                    {
                        DG[4, introw].Value = "Reports";
                    }
                    if (ogrp.intStatus == 0)
                    {
                        DG[5, introw].Value = "Active";
                    }
                    else
                    {
                        DG[5, introw].Value = "Inactive";
                    }

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


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        


    }
}
