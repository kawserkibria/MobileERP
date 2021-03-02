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
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using JA.Modulecontrolar.UI.DReport.Accms;

namespace JA.Modulecontrolar.UI.Security.Forms
{
    public partial class UserAccCon : JA.Shared.UI.frmSmartFormStandard
    {
      
      

        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstUserName = new ListBox();
        public int m_action { get; set; }
        private string strComID { get; set; }




        public int intVtype { get; set; }
        public UserAccCon()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUserName_KeyPress);
            this.txtUserName.GotFocus += new System.EventHandler(this.txtUserName_GotFocus);
            this.txtUserName.KeyDown += new KeyEventHandler(txtUserName_KeyDown);
            this.lstUserName.DoubleClick += new System.EventHandler(this.lstUserName_DoubleClick);
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);

            
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.cboSales.SelectedIndexChanged += new System.EventHandler(this.cboSales_SelectedIndexChanged);
            this.SalesRB.Click += new System.EventHandler(this.SalesRB_Click);

            this.cboPurchase.SelectedIndexChanged += new System.EventHandler(this.cboPurchase_SelectedIndexChanged);
            this.Purchase.Click += new System.EventHandler(this.Purchase_Click);

            this.Inventory.Click += new System.EventHandler(this.Inventory_Click);
            this.cboInventory.SelectedIndexChanged += new System.EventHandler(this.cboInventory_SelectedIndexChanged);

            this.AccountRB.Click += new System.EventHandler(this.AccountRB_Click);
            this.cboAccounts.SelectedIndexChanged += new System.EventHandler(this.cboAccounts_SelectedIndexChanged);

            this.radProjection.Click += new System.EventHandler(this.radProjection_Click);
            this.cboProjection.SelectedIndexChanged += new System.EventHandler(this.cboProjection_SelectedIndexChanged);

            this.RBTools.Click += new System.EventHandler(this.RBTools_Click);
            this.cboTools.SelectedIndexChanged += new System.EventHandler(this.cboTools_SelectedIndexChanged);

            this.DGMaster.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGMaster_CellEndEdit);
            this.DGMaster.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGMaster_KeyDown);

            this.DGTransaction.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGTransaction_CellEndEdit);
            this.DGTransaction.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGTransaction_KeyDown);

            this.DGReports.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGReports_CellEndEdit);
            this.DGReports.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGReports_KeyDown);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.txtSerachRight.TextChanged += new System.EventHandler(this.txtSerachRight_TextChanged);

            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);

            cboSales.MouseWheel += new MouseEventHandler(cboSales_MouseWheel);
            cboPurchase.MouseWheel += new MouseEventHandler(cboPurchase_MouseWheel);
            cboInventory.MouseWheel += new MouseEventHandler(cboInventory_MouseWheel);
            cboAccounts.MouseWheel += new MouseEventHandler(cboAccounts_MouseWheel);
            cboTools.MouseWheel += new MouseEventHandler(cboTools_MouseWheel);
            Utility.CreateListBox(lstUserName, pnlMain, txtUserName);

        }
        private void cboProjection_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFlag = "", strLogInKey, strAccess = "";
            int intModule = (int)Utility.MODULE_TYPE.mtProjection;
            lblModuleName.Text = "Projection Module Security";
            if (cboProjection.Text == "No access")
            {
                strFlag = "N";
            }
            else if (cboSales.Text == "Full")
            {
                strFlag = "Y";
            }
            else
            {
                strFlag = "N";
            }
            strLogInKey = txtUserName.Text + intModule;
            List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
            if (oprimain.Count > 0)
            {
                if (oprimain[0].intAccessLevel == 1)
                {
                    strAccess = "Full";
                }
                else if (oprimain[0].intAccessLevel == 2)
                {
                    strAccess = "Partial";
                }
                else
                {
                    strAccess = "No access";
                }
            }
            if (cboProjection.Text != strAccess)
            {
                mChangeAllFlag(DGMaster, strFlag);
                mChangeAllFlag(DGTransaction, strFlag);
                mChangeAllFlag(DGReports, strFlag);

            }
        }
        private void radProjection_Click(object sender, EventArgs e)
        {
            string strFlag = "", strLogInKey;
            int intModule = (int)Utility.MODULE_TYPE.mtProjection;
            tabControl1.Visible = true;

            cboSales.Enabled = false;
            cboPurchase.Enabled = false;
            cboInventory.Enabled = false;
            cboAccounts.Enabled = true;
            cboTools.Enabled = false;
            cboProjection.Enabled = true;
            pnlSelection.Visible = false;

            lblModuleName.Text = "Projection Module Security";


            if (cboAccounts.Text == "No access")
            {
                strFlag = "N";
            }
            else if (cboAccounts.Text == "Full")
            {
                strFlag = "Y";
            }
            else
            {
                strFlag = "N";
            }
            mLoadFormList(intModule);
            strLogInKey = txtUserName.Text + intModule;
            List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
            if (oprimain.Count > 0)
            {
                mLoadFormList(intModule);
            }
            else
            {
                mChangeAllFlag(DGMaster, strFlag);
                mChangeAllFlag(DGTransaction, strFlag);
                mChangeAllFlag(DGReports, strFlag);

            }

        }
        void cboAccounts_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        void cboTools_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        void cboInventory_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        void cboPurchase_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        void cboSales_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        #region "Save"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "";
            int intmode=0,intcount=0;
            var strResponseInsert = MessageBox.Show("Do You  Want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                int intPriModule=0,lngAccess=0;
                if (SalesRB.Checked==true)
                {
                    intPriModule =(int)Utility.MODULE_TYPE.mtSALES ;
                    if (cboSales.Text =="Full")
                    {
                        lngAccess =1;
                    }
                    else if (cboSales.Text =="Partial")
                    {
                        lngAccess =2;
                    }
                    else
                    {
                        lngAccess=0;
                    }
                }
                else if (Purchase.Checked==true)
                {
                    intPriModule =(int)Utility.MODULE_TYPE.mtPURCHASE ;
                     if (cboPurchase.Text =="Full")
                    {
                        lngAccess =1;
                    }
                     else if (cboPurchase.Text == "Partial")
                    {
                        lngAccess =2;
                    }
                    else
                    {
                        lngAccess=0;
                    }
                }
                else if (Inventory.Checked==true)
                {
                    intPriModule =(int)Utility.MODULE_TYPE.mtSTOCK ;
                     if (cboInventory.Text =="Full")
                    {
                        lngAccess =1;
                    }
                     else if (cboInventory.Text == "Partial")
                    {
                        lngAccess =2;
                    }
                    else
                    {
                        lngAccess=0;
                    }
                }
                else if (AccountRB.Checked==true)
                {
                    intPriModule =(int)Utility.MODULE_TYPE.mtACCOUNT ;
                     if (cboAccounts.Text =="Full")
                    {
                        lngAccess =1;
                    }
                     else if (cboAccounts.Text == "Partial")
                    {
                        lngAccess =2;
                    }
                    else
                    {
                        lngAccess=0;
                    }
                }
                else if (RBTools.Checked == true)
                {
                    intPriModule = (int)Utility.MODULE_TYPE.mtTOOLS;
                    if (cboTools.Text == "Full")
                    {
                        lngAccess = 1;
                    }
                    else if (cboTools.Text == "Partial")
                    {
                        lngAccess = 2;
                    }
                    else
                    {
                        lngAccess = 0;
                    }
                }
                else if (radProjection.Checked == true)
                {
                    intPriModule = (int)Utility.MODULE_TYPE.mtProjection;
                    if (cboProjection.Text == "Full")
                    {
                        lngAccess = 1;
                    }
                    else if (cboProjection.Text == "Partial")
                    {
                        lngAccess = 2;
                    }
                    else
                    {
                        lngAccess = 0;
                    }
                }
                if (txtUserName.Text =="")
                {
                    MessageBox.Show("User Name Cannot be Empty");
                    txtUserName.Focus();
                    return;
                }
                string  strString = this.PopulatedAccess();
                string strString1 = this.PopulatedSection();
                string strSelection = "";
                if (RBBranch.Checked==true)
                {
                    strSelection = "B";
                }
                else if (RBLocation.Checked == true)
                {
                    strSelection = "L";
                }
                else if (RBmpo.Checked == true)
                {
                    strSelection = "M";
                }
                else if (RBStockG.Checked == true)
                {
                    strSelection = "S";
                }
                else if (radLedger.Checked == true)
                {
                    strSelection = "G";
                }
                try
                {
                    if (strSelection != "G")
                    {
                        i = accms.mInsertPrivileges(strComID, txtUserName.Text, intPriModule, lngAccess, strString, strString1, strSelection);
                    }
                    else
                    {
                        progressBar1.Value = 0;
                        intcount = Convert.ToInt32(lstRight.Items.Count);
                        progressBar1.Maximum = intcount;
                        if (intcount > 0)
                        {
                            for (int k = 0; k < intcount; k++)
                            {
                                strString = lstRight.Items[k].ToString().Trim();
                                i = accms.mInsertPrivilegesNew(strComID, txtUserName.Text, intPriModule, lngAccess, strString, intmode);
                                intmode += 1;
                                progressBar1.Value += 1;
                            }
                        }
                        else
                        {
                            i = accms.mInsertPrivilegesNew(strComID, txtUserName.Text, intPriModule, lngAccess, "", intmode);
                        }
                    }

                    if (i == "1")
                    {
                        tabControl1.SelectedIndex = 0;
                        //SalesRB.Checked = true;
                        //cboSales.Enabled = true;
                        //tabControl1.Visible = true;
                        //txtUserName.Text = "";
                        //pnlSelection.Visible = false;
                        
                        txtUserName.Focus();
                        MessageBox.Show("Saved...");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(e.ToString());
                }

            }



        }
        private string PopulatedSection()
        {
            string strString = "";
            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                strString = strString + lstRight.Items[i].ToString().Trim() + "~";
            }
            if (strString != "")
            {
                strString = Utility.Mid(strString, 0, strString.Length - 1);
            }
            return strString;
        }
        private string PopulatedAccess()
        {
            string strString = "";
            try
            {
                for (int introw = 0; introw < DGMaster.Rows.Count; introw++)
                {
                    UserAccess ooAcc = new UserAccess();
                    ooAcc.LogInName = txtUserName.Text;
                    ooAcc.strLogInKey = txtUserName.Text + DGMaster[0, introw].Value;
                    ooAcc.intAccessLevel = Convert.ToInt32(DGMaster[0, introw].Value);
                    if (DGMaster[3, introw].Value.ToString().ToUpper() == "YES")
                    {
                        ooAcc.intAdd = 1;
                    }
                    else
                    {
                        ooAcc.intAdd = 0;
                    }
                    if (DGMaster[4, introw].Value.ToString().ToUpper() == "YES")
                    {
                        ooAcc.intEdit = 1;
                    }
                    else
                    {
                        ooAcc.intEdit = 0;
                    }

                    if (DGMaster[5, introw].Value.ToString().ToUpper() == "YES")
                    {
                        ooAcc.intDelete = 1;
                    }
                    else
                    {
                        ooAcc.intDelete = 0;
                    }
                    strString += ooAcc.LogInName + "|" + ooAcc.strLogInKey + "|" + ooAcc.intAccessLevel + "|" + ooAcc.intAdd + "|" + ooAcc.intEdit + "|" + ooAcc.intDelete + "~";
                }
                for (int introw = 0; introw < DGTransaction.Rows.Count; introw++)
                {
                    UserAccess ooAcc = new UserAccess();
                    ooAcc.LogInName = txtUserName.Text;
                    ooAcc.strLogInKey = txtUserName.Text + DGTransaction[0, introw].Value;
                    ooAcc.intAccessLevel = Convert.ToInt32(DGTransaction[0, introw].Value);
                    if (DGTransaction[3, introw].Value.ToString().ToUpper() == "YES")
                    {
                        ooAcc.intAdd = 1;
                    }
                    else
                    {
                        ooAcc.intAdd = 0;
                    }
                    if (DGTransaction[4, introw].Value.ToString().ToUpper() == "YES")
                    {
                        ooAcc.intEdit = 1;
                    }
                    else
                    {
                        ooAcc.intEdit = 0;
                    }

                    if (DGTransaction[5, introw].Value.ToString().ToUpper() == "YES")
                    {
                        ooAcc.intDelete = 1;
                    }
                    else
                    {
                        ooAcc.intDelete = 0;
                    }
                    strString += ooAcc.LogInName + "|" + ooAcc.strLogInKey + "|" + ooAcc.intAccessLevel + "|" + ooAcc.intAdd + "|" + ooAcc.intEdit + "|" + ooAcc.intDelete + "~";
                }

                for (int introw = 0; introw < DGReports.Rows.Count; introw++)
                {
                    UserAccess ooAcc = new UserAccess();
                    ooAcc.LogInName = txtUserName.Text;
                    ooAcc.strLogInKey = txtUserName.Text + DGReports[0, introw].Value;
                    ooAcc.intAccessLevel = Convert.ToInt32(DGReports[0, introw].Value);
                    if (DGReports[2, introw].Value.ToString().ToUpper() == "YES")
                    {
                        ooAcc.intAdd = 1;
                        ooAcc.intEdit = 1;
                        ooAcc.intDelete = 1;
                    }
                    else
                    {
                        ooAcc.intAdd = 0;
                        ooAcc.intEdit = 0;
                        ooAcc.intDelete = 0;
                    }

                    strString += ooAcc.LogInName + "|" + ooAcc.strLogInKey + "|" + ooAcc.intAccessLevel + "|" + ooAcc.intAdd + "|" + ooAcc.intEdit + "|" + ooAcc.intDelete + "~";
                }



                return strString;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return ex.ToString();
            }
        }
        #endregion
        #region "User Define Event"

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstUserName.Items.Count > 0)
                {
                    txtUserName.Text = lstUserName.Text;
                    tabControl1.SelectedIndex = 0;
                    lstUserName.Visible = false;
                    SalesRB.Checked = true;
                    tabControl1.Visible = true;
                    pnlSelection.Visible = false;
                    cboSales.Enabled = true;
                    mLaodPrivilegesMain();
                    mLoadFormList((int)Utility.MODULE_TYPE.mtSALES);
                    if (DGMaster[2, 0].Value == null)
                    {
                        mChangeAllFlag(DGMaster, "N");
                        mChangeAllFlag(DGTransaction, "N");
                        mChangeAllFlag(DGReports, "N");
                    }
                    DGMaster.Focus();
                    
                    
                }

            }
        }
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            lstUserName.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                if (lstUserName.SelectedItem != null)
                {
                    lstUserName.SelectedIndex = lstUserName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstUserName.Items.Count - 1 > lstUserName.SelectedIndex)
                {
                    lstUserName.SelectedIndex = lstUserName.SelectedIndex + 1;
                }
            }


        }
        private void txtUserName_GotFocus(object sender, System.EventArgs e)
        {
            lstUserName.SelectedIndex = lstUserName.FindString(txtUserName.Text);
        }
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

            lstUserName.Visible = true;
            lstUserName.SelectedIndex = lstUserName.FindString(txtUserName.Text);
        }
        private void lstUserName_DoubleClick(object sender, EventArgs e)
        {
            txtUserName.Text = lstUserName.Text;
            lstUserName.Visible = false;
            SalesRB.Checked = true;
            tabControl1.Visible = true;
            pnlSelection.Visible = false;
            cboSales.Enabled = true;
            mLaodPrivilegesMain();
            mLoadFormList((int)Utility.MODULE_TYPE.mtSALES);
            if (DGMaster[2,0].Value  ==null)
            {
                mChangeAllFlag(DGMaster, "N");
                mChangeAllFlag(DGTransaction, "N");
                mChangeAllFlag(DGReports, "N");
            }
            DGMaster.Focus();
        }
        private void Purchase_Click(object sender, EventArgs e)
        {
            string strFlag = "", strLogInKey;
            int intModule = (int)Utility.MODULE_TYPE.mtPURCHASE;

            cboSales.Enabled = false;
            cboPurchase.Enabled = true;
            cboInventory.Enabled = false;
            cboAccounts.Enabled = false;
            cboTools.Enabled = false;
            cboProjection.Enabled = false;
            tabControl1.Visible = true;
            pnlSelection.Visible = false;
            lblModuleName.Text = "Purchase Module Security";
           
           
            if (cboSales.Text == "No access")
            {
                strFlag = "N";
            }
            else if (cboSales.Text == "Full")
            {
                strFlag = "Y";
            }
            else
            {
                strFlag = "N";
            }
            mLoadFormList(intModule);
            strLogInKey = txtUserName.Text + intModule;
            List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
            if (oprimain.Count > 0)
            {
                mLoadFormList(intModule);
            }
            else
            {
                mChangeAllFlag(DGMaster, strFlag);
                mChangeAllFlag(DGTransaction, strFlag);
                mChangeAllFlag(DGReports, strFlag);

            }
        }


        private void AccountRB_Click(object sender, EventArgs e)
        {
            string strFlag = "", strLogInKey;
            int intModule = (int)Utility.MODULE_TYPE.mtACCOUNT;
            tabControl1.Visible = true;
            cboProjection.Enabled = false;
            cboSales.Enabled = false;
            cboPurchase.Enabled = false;
            cboInventory.Enabled = false;
            cboAccounts.Enabled = true;
            cboTools.Enabled = false;

            pnlSelection.Visible = false;
          
            lblModuleName.Text = "Accounts Module Security";
          
            
            if (cboAccounts.Text == "No access")
            {
                strFlag = "N";
            }
            else if (cboAccounts.Text == "Full")
            {
                strFlag = "Y";
            }
            else
            {
                strFlag = "N";
            }
            mLoadFormList(intModule);
            strLogInKey = txtUserName.Text + intModule;
            List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
            if (oprimain.Count > 0)
            {
                mLoadFormList(intModule);
            }
            else
            {
                mChangeAllFlag(DGMaster, strFlag);
                mChangeAllFlag(DGTransaction, strFlag);
                mChangeAllFlag(DGReports, strFlag);

            }
          
        }
        private void RBTools_Click(object sender, EventArgs e)
        {
            string strFlag = "", strLogInKey;
            int intModule = (int)Utility.MODULE_TYPE.mtTOOLS;
            cboProjection.Enabled = false;
            cboSales.Enabled = false;
            cboPurchase.Enabled = false;
            cboInventory.Enabled = false;
            cboAccounts.Enabled = false;
            cboTools.Enabled = true;
            tabControl1.Visible = true;
            pnlSelection.Visible = false;
            lblModuleName.Text = "Tools Security";
           
          
            if (cboTools.Text == "No access")
            {
                strFlag = "N";
            }
            else if (cboTools.Text == "Full")
            {
                strFlag = "Y";
            }
            else
            {
                strFlag = "N";
            }
            mLoadFormList(intModule);
            strLogInKey = txtUserName.Text + intModule;
            List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
            if (oprimain.Count > 0)
            {
                mLoadFormList(intModule);
            }
            else
            {
                mChangeAllFlag(DGMaster, strFlag);
                mChangeAllFlag(DGTransaction, strFlag);
                mChangeAllFlag(DGReports, strFlag);

            }

        }
          

        private void Inventory_Click(object sender, EventArgs e)
        {
            string strFlag = "", strLogInKey;
            int intModule = (int)Utility.MODULE_TYPE.mtSTOCK;
            tabControl1.Visible = true;
            pnlSelection.Visible = false;
            lblModuleName.Text = "Inventory Module Security";
            cboProjection.Enabled = false;
            pnlSelection.Visible = false;
            cboSales.Enabled = false;
            cboPurchase.Enabled = false;
            cboInventory.Enabled = true;
            cboAccounts.Enabled = false;
            cboTools.Enabled = false;

            if (cboInventory.Text == "No access")
            {
                strFlag = "N";
            }
            else if (cboInventory.Text == "Full")
            {
                strFlag = "Y";
            }
            else
            {
                strFlag = "N";
            }
            mLoadFormList(intModule);
            strLogInKey = txtUserName.Text + intModule;
            List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
            if (oprimain.Count > 0)
            {
                mLoadFormList(intModule);
            }
            else
            {
                mChangeAllFlag(DGMaster, strFlag);
                mChangeAllFlag(DGTransaction, strFlag);
                mChangeAllFlag(DGReports, strFlag);

            }
          
        }

        private void SalesRB_Click(object sender, System.EventArgs e)
        {
            lblModuleName.Text = "Sales Module Security";
            string strFlag = "", strLogInKey;
            int intModule = (int)Utility.MODULE_TYPE.mtSALES;
            tabControl1.Visible = true;
            pnlSelection.Visible = false;
            cboProjection.Enabled = false;
            cboSales.Enabled = true;
            cboPurchase.Enabled = false;
            cboInventory.Enabled = false;
            cboAccounts.Enabled = false;
            cboTools.Enabled = false;
            
            if (cboSales.Text == "No access")
            {
                strFlag = "N";
            }
            else if (cboSales.Text == "Full")
            {
                strFlag = "Y";
            }
            else
            {
                strFlag = "N";
            }
            mLoadFormList(intModule);
            strLogInKey = txtUserName.Text + intModule;
            List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
            if (oprimain.Count > 0)
            {
                mLoadFormList(intModule);
            }
            else
            {
                mChangeAllFlag(DGMaster, strFlag);
                mChangeAllFlag(DGTransaction, strFlag);
                mChangeAllFlag(DGReports, strFlag);

            }

        }
        private void cboInventory_SelectedIndexChanged(object sender, EventArgs e)
        {

            string strFlag = "", strLogInKey, strAccess="";
            int intModule = (int)Utility.MODULE_TYPE.mtSTOCK;
           
            if (cboInventory.Text == "No access")
            {
                strFlag = "N";
            }
            else if (cboInventory.Text == "Full")
            {
                strFlag = "Y";
            }
            else
            {
                strFlag = "N";
            }
            strLogInKey = txtUserName.Text + intModule;
            List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
            if (oprimain.Count > 0)
            {
                if (oprimain[0].intAccessLevel == 1)
                {
                    strAccess = "Full";
                }
                else if (oprimain[0].intAccessLevel == 2)
                {
                    strAccess = "Partial";
                }
                else
                {
                    strAccess = "No access";
                }
            }
            if (cboInventory.Text != strAccess)
            {
                mChangeAllFlag(DGMaster, strFlag);
                mChangeAllFlag(DGTransaction, strFlag);
                mChangeAllFlag(DGReports, strFlag);

            }
        }
     
        private void cboTools_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFlag = "", strLogInKey, strAccess="";
            int intModule = (int)Utility.MODULE_TYPE.mtTOOLS;
            if (cboTools.Text == "No access")
            {
                strFlag = "N";
            }
            else if (cboTools.Text == "Full")
            {
                strFlag = "Y";
            }
            else
            {
                strFlag = "N";
            }
            strLogInKey = txtUserName.Text + intModule;
            List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
            if (oprimain.Count > 0)
            {
                if (oprimain[0].intAccessLevel == 1)
                {
                    strAccess = "Full";
                }
                else if (oprimain[0].intAccessLevel == 2)
                {
                    strAccess = "Partial";
                }
                else
                {
                    strAccess = "No access";
                }
            }
            if (cboTools.Text != strAccess)
            {
                mChangeAllFlag(DGMaster, strFlag);
                mChangeAllFlag(DGTransaction, strFlag);
                mChangeAllFlag(DGReports, strFlag);

            }
        }

        private void cboSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFlag = "", strLogInKey, strAccess="";
            int intModule = (int)Utility.MODULE_TYPE.mtSALES;
            lblModuleName.Text = "Sales Module Security";
            if (cboSales.Text == "No access")
            {
                strFlag = "N";
            }
            else if (cboSales.Text == "Full")
            {
                strFlag = "Y";
            }
            else
            {
                strFlag = "N";
            }
            strLogInKey = txtUserName.Text + intModule;
            List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
            if (oprimain.Count > 0)
            {
                if (oprimain[0].intAccessLevel == 1)
                {
                    strAccess = "Full";
                }
                else if (oprimain[0].intAccessLevel == 2)
                {
                    strAccess = "Partial";
                }
                else
                {
                    strAccess = "No access";
                }
            }
            if (cboSales.Text != strAccess)
            {
                mChangeAllFlag(DGMaster, strFlag);
                mChangeAllFlag(DGTransaction, strFlag);
                mChangeAllFlag(DGReports, strFlag);

            }
        }

        private void mChangeAllFlag(DataGridView dg, string strFlag)
        {
            for (int intRow = 0; intRow < dg.Rows.Count; intRow++)
            {
                for (int i = 2; i < dg.Columns.Count; i++)
                {
                    if (strFlag.ToUpper() == "Y")
                    {
                        dg[i, intRow].Value = "Yes";
                    }
                    else if (strFlag.ToUpper() == "N")
                    {
                        dg[i, intRow].Value = "No";
                    }
                }
            }
        }
        private void mChangeFlag(DataGridView dg, int intcolumn,int intRow, string strFlag)
        {
            for (int i = intcolumn; i < dg.Columns.Count; i++)
            {
                if (strFlag.ToUpper() == "Y")
                {
                    dg[i, intRow].Value = "Yes";
                }
                else if (strFlag.ToUpper() == "N")
                {
                    dg[i, intRow].Value = "No";
                }
                else
                {
                    MessageBox.Show("PleaseType 'Y' or 'N'.");
                    return;
                }
            }
        }
        private void DGMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = DGMaster.CurrentCell.ColumnIndex;
                int iRow = DGMaster.CurrentCell.RowIndex;
                if (iColumn == DGMaster.Columns.Count - 1)
                    btnSave.Focus();
                else
                    DGMaster.CurrentCell = DGMaster[iColumn + 1, iRow];


            }
        }
        private void DGMaster_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 2)
                {
                    mChangeFlag(DGMaster, e.ColumnIndex,e.RowIndex, DGMaster[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper());
                    
                }
                else if (e.ColumnIndex==5)
                {
                    if (DGMaster[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "Y")
                    {
                        DGMaster[e.ColumnIndex, e.RowIndex].Value = "Yes";
                        if (DGMaster.CurrentRow.Cells[0].Visible==false)
                        {
                            SendKeys.Send("{tab}");
                            SendKeys.Send("{tab}");
                        }
                        return;
                    }
                    else if (DGMaster[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "N")
                    {
                        DGMaster[e.ColumnIndex, e.RowIndex].Value = "No";
                        if (DGMaster.CurrentRow.Cells[0].ReadOnly)
                        {
                            SendKeys.Send("{tab}");
                            SendKeys.Send("{tab}");
                        }
                        return;
                    }
                    else
                    {
                        MessageBox.Show("PleaseType 'Y' or 'N'.");
                        if (DGMaster.CurrentRow.Cells[0].ReadOnly)
                        {
                            SendKeys.Send("{tab}");
                            SendKeys.Send("{tab}");
                        }
                        return;
                    }
                    
                }
                else
                {
                    if (DGMaster[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "Y")
                    {
                        DGMaster[e.ColumnIndex, e.RowIndex].Value = "Yes";
                        return;
                    }
                    else if (DGMaster[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "N")
                    {
                        DGMaster[e.ColumnIndex, e.RowIndex].Value = "No";
                        return;
                    }
                    else
                    {
                        MessageBox.Show("PleaseType 'Y' or 'N'.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }




        private void DGTransaction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = DGTransaction.CurrentCell.ColumnIndex;
                int iRow = DGTransaction.CurrentCell.RowIndex;
                if (iColumn == DGTransaction.Columns.Count - 1)
                    btnSave.Focus();
                else
                    DGTransaction.CurrentCell = DGTransaction[iColumn + 1, iRow];


            }
        }
        private void DGTransaction_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 2)
                {
                    mChangeFlag(DGTransaction, e.ColumnIndex, e.RowIndex, DGTransaction[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper());

                }
                else if (e.ColumnIndex == 5)
                {
                    if (DGTransaction[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "Y")
                    {
                        DGTransaction[e.ColumnIndex, e.RowIndex].Value = "Yes";
                        if (DGTransaction.CurrentRow.Cells[0].Visible == false)
                        {
                            SendKeys.Send("{tab}");
                            SendKeys.Send("{tab}");
                        }
                        return;
                    }
                    else if (DGTransaction[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "N")
                    {
                        DGTransaction[e.ColumnIndex, e.RowIndex].Value = "No";
                        if (DGTransaction.CurrentRow.Cells[0].ReadOnly)
                        {
                            SendKeys.Send("{tab}");
                            SendKeys.Send("{tab}");
                        }
                        return;
                    }
                    else
                    {
                        MessageBox.Show("PleaseType 'Y' or 'N'.");
                        if (DGTransaction.CurrentRow.Cells[0].ReadOnly)
                        {
                            SendKeys.Send("{tab}");
                            SendKeys.Send("{tab}");
                        }
                        return;
                    }

                }
                else
                {
                    if (DGTransaction[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "Y")
                    {
                        DGTransaction[e.ColumnIndex, e.RowIndex].Value = "Yes";
                        return;
                    }
                    else if (DGTransaction[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "N")
                    {
                        DGTransaction[e.ColumnIndex, e.RowIndex].Value = "No";
                        return;
                    }
                    else
                    {
                        MessageBox.Show("PleaseType 'Y' or 'N'.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void DGReports_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = DGReports.CurrentCell.ColumnIndex;
                int iRow = DGReports.CurrentCell.RowIndex;
                if (iColumn == DGReports.Columns.Count - 1)
                    btnSave.Focus();
                else
                    DGReports.CurrentCell = DGReports[iColumn + 1, iRow];


            }
        }
        private void DGReports_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 2)
                {
                    mChangeFlag(DGReports, e.ColumnIndex, e.RowIndex, DGReports[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper());

                }
                else if (e.ColumnIndex == 5)
                {
                    if (DGReports[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "Y")
                    {
                        DGReports[e.ColumnIndex, e.RowIndex].Value = "Yes";
                        if (DGReports.CurrentRow.Cells[0].Visible == false)
                        {
                            SendKeys.Send("{tab}");
                            SendKeys.Send("{tab}");
                        }
                        return;
                    }
                    else if (DGReports[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "N")
                    {
                        DGReports[e.ColumnIndex, e.RowIndex].Value = "No";
                        if (DGReports.CurrentRow.Cells[0].ReadOnly)
                        {
                            SendKeys.Send("{tab}");
                            SendKeys.Send("{tab}");
                        }
                        return;
                    }
                    else
                    {
                        MessageBox.Show("PleaseType 'Y' or 'N'.");
                        if (DGReports.CurrentRow.Cells[0].ReadOnly)
                        {
                            SendKeys.Send("{tab}");
                            SendKeys.Send("{tab}");
                        }
                        return;
                    }

                }
                else
                {
                    if (DGReports[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "Y")
                    {
                        DGReports[e.ColumnIndex, e.RowIndex].Value = "Yes";
                        return;
                    }
                    else if (DGReports[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "N")
                    {
                        DGReports[e.ColumnIndex, e.RowIndex].Value = "No";
                        return;
                    }
                    else
                    {
                        MessageBox.Show("PleaseType 'Y' or 'N'.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void cboPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFlag = "", strLogInKey, strAccess = "";
            int intModule = (int)Utility.MODULE_TYPE.mtPURCHASE;
            if (cboPurchase.Text == "No access")
            {
                strFlag = "N";
            }
            else if (cboPurchase.Text == "Full")
            {
                strFlag = "Y";
            }
            else
            {
                strFlag = "N";
            }
            strLogInKey = txtUserName.Text + intModule;
            List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
            if (oprimain.Count > 0)
            {
                if (oprimain[0].intAccessLevel == 1)
                {
                    strAccess = "Full";
                }
                else if (oprimain[0].intAccessLevel == 2)
                {
                    strAccess = "Partial";
                }
                else
                {
                    strAccess = "No access";
                }
            }
            if (cboPurchase.Text != strAccess)
            {
                mChangeAllFlag(DGMaster, strFlag);
                mChangeAllFlag(DGTransaction, strFlag);
                mChangeAllFlag(DGReports, strFlag);

            }

           
        }

        private void cboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFlag = "", strLogInKey, strAccess = "";
            int intModule = (int)Utility.MODULE_TYPE.mtACCOUNT;
            if (cboAccounts.Text == "No access")
            {
                strFlag = "N";
            }
            else if (cboAccounts.Text == "Full")
            {
                strFlag = "Y";
            }
            else
            {
                strFlag = "N";
            }
            strLogInKey = txtUserName.Text + intModule;
            List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
            if (oprimain.Count > 0)
            {
                if (oprimain[0].intAccessLevel == 1)
                {
                    strAccess = "Full";
                }
                else if (oprimain[0].intAccessLevel == 2)
                {
                    strAccess = "Partial";
                }
                else
                {
                    strAccess = "No access";
                }
            }
            if (cboAccounts.Text != strAccess)
            {
                mChangeAllFlag(DGMaster, strFlag);
                mChangeAllFlag(DGTransaction, strFlag);
                mChangeAllFlag(DGReports, strFlag);

            }


        }


        #endregion
        #region "Display Form"
        private void mLaodPrivilegesMain()
        {
            string strLogInKey = "";
            int  intModule=1;
            if (txtUserName.Text != "")
            {
                for (int iStart = 1; iStart <= 6; iStart++)
                {
                    if (iStart == 1)
                    {
                        intModule = (int)Utility.MODULE_TYPE.mtSALES;
                    }
                    else if (iStart == 2)
                    {
                        intModule = (int)Utility.MODULE_TYPE.mtPURCHASE;
                    }
                    else if (iStart == 3)
                    {
                        intModule = (int)Utility.MODULE_TYPE.mtSTOCK;
                    }
                    else if (iStart == 4)
                    {
                        intModule = (int)Utility.MODULE_TYPE.mtACCOUNT;
                    }
                    else if (iStart == 5)
                    {
                        intModule = (int)Utility.MODULE_TYPE.mtTOOLS;
                    }
                    else if (iStart == 6)
                    {
                        intModule = (int)Utility.MODULE_TYPE.mtProjection;
                    }
                    strLogInKey = txtUserName.Text + intModule;
                    List<UserAccess> oprimain = accms.mDisplayPrivilegesMain(strComID, strLogInKey, intModule).ToList();
                    if (oprimain.Count > 0)
                    {
                        if (intModule == (int)Utility.MODULE_TYPE.mtSALES)
                        {
                            if (oprimain[0].intAccessLevel == 1)
                            {
                                cboSales.Text = "Full";
                            }
                            else if (oprimain[0].intAccessLevel == 2)
                            {
                                cboSales.Text = "Partial";
                            }
                            else
                            {
                                cboSales.Text = "No access";
                            }
                        }
                        else if (intModule == (int)Utility.MODULE_TYPE.mtPURCHASE)
                        {
                            if (oprimain[0].intAccessLevel == 1)
                            {
                                cboPurchase.Text = "Full";
                            }
                            else if (oprimain[0].intAccessLevel == 2)
                            {
                                cboPurchase.Text = "Partial";
                            }
                            else
                            {
                                cboPurchase.Text = "No access";
                            }
                        }
                        else if (intModule == (int)Utility.MODULE_TYPE.mtSTOCK)
                        {
                            if (oprimain[0].intAccessLevel == 1)
                            {
                                cboInventory.Text = "Full";
                            }
                            else if (oprimain[0].intAccessLevel == 2)
                            {
                                cboInventory.Text = "Partial";
                            }
                            else
                            {
                                cboInventory.Text = "No access";
                            }
                        }
                        else if (intModule == (int)Utility.MODULE_TYPE.mtACCOUNT)
                        {
                            if (oprimain[0].intAccessLevel == 1)
                            {
                                cboAccounts.Text = "Full";
                            }
                            else if (oprimain[0].intAccessLevel == 2)
                            {
                                cboAccounts.Text = "Partial";
                            }
                            else
                            {
                                cboAccounts.Text = "No access";
                            }
                        }
                        else if (intModule == (int)Utility.MODULE_TYPE.mtTOOLS)
                        {
                            if (oprimain[0].intAccessLevel == 1)
                            {
                                cboTools.Text = "Full";
                            }
                            else if (oprimain[0].intAccessLevel == 2)
                            {
                                cboTools.Text = "Partial";
                            }
                            else
                            {
                                cboTools.Text = "No access";
                            }
                        }
                        else if (intModule == (int)Utility.MODULE_TYPE.mtProjection)
                        {
                            if (oprimain[0].intAccessLevel == 1)
                            {
                                cboProjection.Text = "Full";
                            }
                            else if (oprimain[0].intAccessLevel == 2)
                            {
                                cboProjection.Text = "Partial";
                            }
                            else
                            {
                                cboProjection.Text = "No access";
                            }
                        }
                    }
                }
            }

        }
        private void mLoadFormList(int intModule)
        {
            string strLogInKey="";
            int intMaster = 0, intTransaction = 0, intReports = 0;
            DGMaster.Rows.Clear();
            DGTransaction.Rows.Clear();
            DGReports.Rows.Clear();
            tabControl1.SelectTab(0);

            List<AccountdGroup> oform = accms.mDisplayFormList(strComID, intModule).ToList();
            if (oform.Count > 0)
            {
                foreach (AccountdGroup ogrp in oform)
                {
                    if (ogrp.intMode == 1)
                    {
                        DGMaster.Rows.Add();
                        DGMaster[0, intMaster].Value = ogrp.lngSlNo;
                        DGMaster[1, intMaster].Value = ogrp.strFormName;
                        if (txtUserName.Text != "")
                        {
                            strLogInKey = txtUserName.Text + ogrp.lngSlNo;
                            List<UserAccess> oUser = accms.mDisplayPrivilegesChild(strComID, strLogInKey).ToList();
                            if (oUser.Count > 0)
                            {
                                if (oUser[0].intAccessLevel == 3)
                                {
                                    DGMaster[2, intMaster].Value = "Yes";
                                }
                                else
                                {
                                    DGMaster[2, intMaster].Value = "No";
                                }
                                if (oUser[0].intAdd == 1)
                                {
                                    DGMaster[3, intMaster].Value = "Yes";
                                }
                                else
                                {
                                    DGMaster[3, intMaster].Value = "No";
                                }
                                if (oUser[0].intEdit == 1)
                                {
                                    DGMaster[4, intMaster].Value = "Yes";
                                }
                                else
                                {
                                    DGMaster[4, intMaster].Value = "No";
                                }
                                if (oUser[0].intDelete == 1)
                                {
                                    DGMaster[5, intMaster].Value = "Yes";
                                }
                                else
                                {
                                    DGMaster[5, intMaster].Value = "No";
                                }
                            }
                        }
                        intMaster += 1;
                    }

                    else if (ogrp.intMode == 2)
                    {
                        DGTransaction.Rows.Add();
                        DGTransaction[0, intTransaction].Value = ogrp.lngSlNo;
                        DGTransaction[1, intTransaction].Value = ogrp.strFormName;
                        if (txtUserName.Text != "")
                        {
                            strLogInKey = txtUserName.Text + ogrp.lngSlNo;
                            List<UserAccess> oUser = accms.mDisplayPrivilegesChild(strComID, strLogInKey).ToList();
                            if (oUser.Count > 0)
                            {


                                if (oUser[0].intAccessLevel == 3)
                                {
                                    DGTransaction[2, intTransaction].Value = "Yes";
                                }
                                else
                                {
                                    DGTransaction[2, intTransaction].Value = "No";
                                }
                                if (oUser[0].intAdd == 1)
                                {
                                    DGTransaction[3, intTransaction].Value = "Yes";
                                }
                                else
                                {
                                    DGTransaction[3, intTransaction].Value = "No";
                                }
                                if (oUser[0].intEdit == 1)
                                {
                                    DGTransaction[4, intTransaction].Value = "Yes";
                                }
                                else
                                {
                                    DGTransaction[4, intTransaction].Value = "No";
                                }
                                if (oUser[0].intDelete == 1)
                                {
                                    DGTransaction[5, intTransaction].Value = "Yes";
                                }
                                else
                                {
                                    DGTransaction[5, intTransaction].Value = "No";
                                }
                            }
                        }
                        intTransaction += 1;
                    }
                    else if (ogrp.intMode == 3)
                    {
                        DGReports.Rows.Add();
                        DGReports[0, intReports].Value = ogrp.lngSlNo;
                        DGReports[1, intReports].Value = ogrp.strFormName;
                        if (txtUserName.Text != "")
                        {
                            strLogInKey = txtUserName.Text + ogrp.lngSlNo;
                            List<UserAccess> oUser = accms.mDisplayPrivilegesChild(strComID, strLogInKey).ToList();
                            if (oUser.Count > 0)
                            {
                                if (oUser[0].intEdit == 1)
                                {
                                    DGReports[2, intReports].Value = "Yes";
                                }
                                else
                                {
                                    DGReports[2, intReports].Value = "No";
                                }
                            }

                        }
                        intReports += 1;
                    }

                }

            }
        }
        #endregion
        #region "Load"
        private void UserAccCon_Load(object sender, EventArgs e)
        {
            lblModuleName.Text = "";
            lblModuleName.Text = "Sales Module Security";
            
            lstUserName.Visible = false;
            lstUserName.DisplayMember = "LogInName";
            lstUserName.ValueMember = "LogInName";
            lstUserName.DataSource = accms.mFillUsername(strComID).ToList();

            DGMaster.AllowUserToAddRows = false;
            DGTransaction.AllowUserToAddRows = false;
            DGReports.AllowUserToAddRows = false;

            cboInventory.Text = "No Access";
            cboSales.Text = "No Access";
            cboPurchase.Text = "No Access";
            cboAccounts.Text = "No Access";
            cboTools.Text = "No Access";
            this.DGMaster.DefaultCellStyle.Font = new Font("verdana", 10);
            DGMaster.Columns.Add(Utility.Create_Grid_Column("SL No", "SL No", 60, false, DataGridViewContentAlignment.TopLeft, true));
            DGMaster.Columns.Add(Utility.Create_Grid_Column("User Menu", "User Menu", 324, true, DataGridViewContentAlignment.TopLeft, true));
            DGMaster.Columns.Add(Utility.Create_Grid_Column("Full", "Full", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DGMaster.Columns.Add(Utility.Create_Grid_Column("Add", "Add", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DGMaster.Columns.Add(Utility.Create_Grid_Column("Edit", "Edit", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DGMaster.Columns.Add(Utility.Create_Grid_Column("Delete", "Delete", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DGMaster.Columns[0].DefaultCellStyle.BackColor = Color.Bisque;
            DGMaster.Columns[1].DefaultCellStyle.BackColor = Color.Bisque;

            this.DGTransaction.DefaultCellStyle.Font = new Font("verdana", 10);
            DGTransaction.Columns.Add(Utility.Create_Grid_Column("SL No", "SL No", 60, false, DataGridViewContentAlignment.TopLeft, true));
            DGTransaction.Columns.Add(Utility.Create_Grid_Column("User Menu", "User Menu", 324, true, DataGridViewContentAlignment.TopLeft, true));
            DGTransaction.Columns.Add(Utility.Create_Grid_Column("Full", "Full", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DGTransaction.Columns.Add(Utility.Create_Grid_Column("Add", "Add", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DGTransaction.Columns.Add(Utility.Create_Grid_Column("Edit", "Edit", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DGTransaction.Columns.Add(Utility.Create_Grid_Column("Delete", "Delete", 100, true, DataGridViewContentAlignment.TopLeft, false));
            DGTransaction.Columns[0].DefaultCellStyle.BackColor = Color.Bisque;
            DGTransaction.Columns[1].DefaultCellStyle.BackColor = Color.Bisque;
            this.DGReports.DefaultCellStyle.Font = new Font("verdana", 10);
            DGReports.Columns.Add(Utility.Create_Grid_Column("SL No", "SL No", 60, false, DataGridViewContentAlignment.TopLeft, true));
            DGReports.Columns.Add(Utility.Create_Grid_Column("Report Name", "Report Name", 454, true, DataGridViewContentAlignment.TopLeft, true));
            DGReports.Columns.Add(Utility.Create_Grid_Column("Report Control", "Report Control", 230, true, DataGridViewContentAlignment.TopLeft, false));
            DGReports.Columns[1].DefaultCellStyle.BackColor = Color.Bisque;
            DGReports.Columns[0].DefaultCellStyle.BackColor = Color.Bisque;
            mLoadFormList((int)Utility.MODULE_TYPE.mtSALES);
            mChangeAllFlag(DGMaster, "N");
            mChangeAllFlag(DGTransaction, "N");
            mChangeAllFlag(DGReports, "N");
            txtUserName.Select();
            txtUserName.Focus();
        }
        #endregion

        private void RBBranch_Click(object sender, EventArgs e)
        {
            lblModuleName.Text = "Branch Security";

            cboSales.Enabled = false;
            cboPurchase.Enabled = false;
            cboInventory.Enabled = false;
            cboAccounts.Enabled = false;
            cboTools.Enabled = false;
            lblGroup.Visible = false;
            cboGroup.Visible = false;
            progressBar1.Value = 0;
            tabControl1.Visible = false;
            pnlSelection.Visible = true;
            mLoadBranch();
            mLoadBranchUserRight();
        }

        private void RBLocation_Click(object sender, EventArgs e)
        {
            lblModuleName.Text = "Location Security";
            cboSales.Enabled = false;
            cboPurchase.Enabled = false;
            cboInventory.Enabled = false;
            cboAccounts.Enabled = false;
            cboTools.Enabled = false;
            lblGroup.Visible = false;
            cboGroup.Visible = false;
            tabControl1.Visible = false;
            pnlSelection.Visible = true;
            progressBar1.Value = 0;
            mLoadLocation();
            mLoadLocationRight();
        }

        private void RBmpo_Click(object sender, EventArgs e)
        {
           
            lblModuleName.Text = "MPO Security";
            cboSales.Enabled = false;
            cboPurchase.Enabled = false;
            cboInventory.Enabled = false;
            cboAccounts.Enabled = false;
            cboTools.Enabled = false;
            lblGroup.Visible = false;
            cboGroup.Visible = false ;
            tabControl1.Visible = false;
            pnlSelection.Visible = true;
            progressBar1.Value = 0;
            mLoadMPOGroup();
            mLoadMPOGroupright();
        }

        private void RBStockG_Click(object sender, EventArgs e)
        {
            
            lblModuleName.Text = "Stock Group Security";
            cboSales.Enabled = false;
            cboPurchase.Enabled = false;
            cboInventory.Enabled = false;
            cboAccounts.Enabled = false;
            cboTools.Enabled = false;
            mLoadStockGroup();
            mLoadStockGroupRight();
            tabControl1.Visible = false;
            pnlSelection.Visible = true;
            progressBar1.Value = 0;
        }

        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
                if (lstLeft.Items.Count>0)
                lstLeft.SetSelected(0, true);
            }
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstLeft.Items.Count; i++)
            {
                string strItem = lstLeft.Items[i].ToString().TrimStart();
                lstRight.Items.Add(strItem);
            }

            lstLeft.Items.Clear();
        }

        private void btnLeftSingle_Click(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight.SelectedItem.ToString());
                lstRight.Items.Remove(lstRight.SelectedItem.ToString());
                if (lstRight.Items.Count > 0)
                lstRight.SetSelected(0, true);
            }
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                string strItem = lstRight.Items[i].ToString().TrimStart();
                lstLeft.Items.Add(strItem);
            }
            lstRight.Items.Clear();
       
        }

        private void RBLocation_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void mLoadStockGroup()
        {
            lstLeft.Items.Clear();

            List<StockItem> oogrp = invms.gLoadStockGroupLevel3Privileges(strComID, txtUserName.Text).ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemGroup);
                }
            }
        }
        private void mLoadStockGroupRight()
        {
            lstRight.Items.Clear();
            List<StockItem> oogrp = invms.gLoadStockGroupLevel3PrivilegesRight(strComID, txtUserName.Text).ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstRight.Items.Add(ostk.strItemGroup);
                }
            }
        }
        private void mLoadMPOGroupright()
        {
          
            lstRight.Items.Clear();
            List<AccountdGroup> oogrp = accms.GetDsmRsm_level4_userPrivilegesRight(strComID, txtUserName.Text).ToList();
            if (oogrp.Count > 0)
            {
                foreach (AccountdGroup ostk in oogrp)
                {
                    lstRight.Items.Add(ostk.GroupName);
                }
            }
        }
        private void mLoadMPOGroup()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<AccountdGroup> oogrp = accms.GetDsmRsm_level4_userPrivileges(strComID, txtUserName.Text).ToList();
            if (oogrp.Count > 0)
            {
                foreach (AccountdGroup ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.GroupName);
                }
            }
        }
       
        private void mLoadLocation()
        {
            lstLeft.Items.Clear();

            List<Location> oogrp = invms.mLoadLocationUserPrivileges(strComID, txtUserName.Text).ToList();
            if (oogrp.Count > 0)
            {
                foreach (Location ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strLocation);
                }
            }
        }
        private void mLoadLocationRight()
        {
            
            lstRight.Items.Clear();
            List<Location> oogrp = invms.mLoadLocationUserPrivilegesRight(strComID, txtUserName.Text).ToList();
            if (oogrp.Count > 0)
            {
                foreach (Location ostk in oogrp)
                {
                    lstRight.Items.Add(ostk.strLocation);
                }
            }
        }
        private void mLoadBranch()
        {
            lstLeft.Items.Clear();


            List<BranchConfig> oogrp = accms.mFillBranchUserPrivileges(strComID, txtUserName.Text).ToList();
            if (oogrp.Count > 0)
            {
                foreach (BranchConfig ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.BranchName);
                }
            }
        }
        private void mLoadBranchUserRight()
        {
            //lstLeft.Items.Clear();
            lstRight.Items.Clear();

            List<BranchConfig> oogrp = accms.mFillBranchUserRight(strComID,txtUserName.Text).ToList();
            if (oogrp.Count > 0)
            {
                foreach (BranchConfig ostk in oogrp)
                {
                    lstRight.Items.Add(ostk.BranchName);
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }
        private void txtSerachRight_TextChanged(object sender, EventArgs e)
        {
            lstRight.SelectedIndex = lstRight.FindString(txtSerachRight.Text);
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please Select User Name");
                return;
            }
            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.userPrevilegs;
            frmviewer.strSelction = txtUserName.Text;
            frmviewer.Show();
        }

        private void AccountRB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radLedger_Click(object sender, EventArgs e)
        {
            lblModuleName.Text = "Ledger Security";
            cboSales.Enabled = false;
            cboPurchase.Enabled = false;
            cboInventory.Enabled = false;
            cboAccounts.Enabled = false;
            cboTools.Enabled = false;
            lblGroup.Visible = true;
            cboGroup.Visible = true;
            cboGroup.ValueMember = "Key";
            cboGroup.DisplayMember = "Value";
            cboGroup.DataSource = new BindingSource(accms.mFillSecurityGroup(strComID), null);
            mLoadLedger(cboGroup.Text);
            mLoadLedgerRight();
            tabControl1.Visible = false;
            pnlSelection.Visible = true;
        }

        private void mLoadLedger(string vstrRoot)
        {
            lstLeft.Items.Clear();


            List<AccountsLedger> oaccLed = accms.mLedgerSecurity(strComID, vstrRoot,txtUserName.Text).ToList();
            if (oaccLed.Count > 0)
            {
                foreach (AccountsLedger ostk in oaccLed)
                {
                    lstLeft.Items.Add(ostk.strLedgerName.Trim());
                }
            }
        }

        private void mLoadLedgerRight()
        {
            lstRight.Items.Clear();
            List<AccountsLedger> oogrp = accms.gLoadLegderPrivilegesRight(strComID, txtUserName.Text).ToList();
            if (oogrp.Count > 0)
            {
                foreach (AccountsLedger ostk in oogrp)
                {
                    lstRight.Items.Add(ostk.strLedgerName.Trim());
                }
            }
        }

        private void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGroup.SelectedValue !=null)
            {
                mLoadLedger(cboGroup.SelectedValue.ToString());
            }
        }

        private void btnRightSingle_Click_1(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void radLedger_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnMenuWise_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please Select User Name");
                return;
            }
            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.userPrevilegsMenu;
            frmviewer.strSelction = txtUserName.Text;
            frmviewer.Show();
        }

       

       

       

     

      

       
    }

}
          

        
    

