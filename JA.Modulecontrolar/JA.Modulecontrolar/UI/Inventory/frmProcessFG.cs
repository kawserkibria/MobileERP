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
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
using System.Data.SqlClient;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmProcessFG : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstLocation = new ListBox();
        private ListBox lstBranchName = new ListBox();
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int m_action { get; set; }
        public int intConvert { get; set; }
      
        private string mstrOldProcess { get; set; }
        private string strComID { get; set; }
        public frmProcessFG()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

           

            this.uctxtFGItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFGItem_KeyPress);
            this.uctxtFGItem.GotFocus += new System.EventHandler(this.uctxtFGItem_GotFocus);

            this.txtFGQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtFGQty_KeyPress);
            this.txtFGQty.GotFocus += new System.EventHandler(this.txtFGQty_GotFocus);


            this.uctxtProcessName.KeyDown += new KeyEventHandler(uctxtProcessName_KeyDown);
            this.uctxtProcessName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtProcessName_KeyPress);
            this.uctxtProcessName.TextChanged += new System.EventHandler(this.uctxtProcessName_TextChanged);
            this.uctxtProcessName.GotFocus += new System.EventHandler(this.uctxtProcessName_GotFocus);

            this.uctxtLocation.KeyDown += new KeyEventHandler(uctxtLocation_KeyDown);
            this.uctxtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLocation_KeyPress);
            this.uctxtLocation.TextChanged += new System.EventHandler(this.uctxtLocation_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.uctxtLocation.GotFocus += new System.EventHandler(this.uctxtLocation_GotFocus);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);

            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);

            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);

            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnRightSingle.PerformClick();
                lstLeft.SetSelected(0, true);
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLeft.SelectedItem != null)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLeft.Items.Count - 1 > lstLeft.SelectedIndex)
                {
                    lstLeft.SelectedIndex = lstLeft.SelectedIndex + 1;
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
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
        private void txtFGQty_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;

        }
        private void uctxtProcessName_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = false;

        }
        private void uctxtFGItem_GotFocus(object sender, System.EventArgs e)
        {
      
            lstBranchName.Visible = false;
            lstLocation.Visible = false;

        }
        private void txtFGQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtBranchName.Focus();
            }

        }
        private void uctxtFGItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

               txtFGQty.Focus();
            }

        }
        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            lstLocation.Visible = false;
            btnSave.Focus();
        }

        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                }
                lstLocation.Visible = false;
                btnSave.Focus();
            }
            
        }
        private void uctxtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLocation.SelectedItem != null)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLocation.Items.Count - 1 > lstLocation.SelectedIndex)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex + 1;
                }
            }

        }

        private void uctxtLocation_GotFocus(object sender, System.EventArgs e)
        {

           
            lstLocation.Visible = true;
            lstBranchName.Visible = false;
            if (lstBranchName.SelectedValue != null)
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                lstLocation.DataSource = invms.gLoadLocation(strComID, lstBranchName.SelectedValue.ToString(), Utility.gblnAccessControl, Utility.gstrUserName, 0).ToList();
            }
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
            //mLoadAllItem();
        }

        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranchName.Text;
            uctxtLocation.Focus();
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }
                uctxtLocation.Focus();
            }
           
        }
        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranchName.SelectedItem != null)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranchName.Items.Count - 1 > lstBranchName.SelectedIndex)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = true;
            lstLocation.Visible = false;
           

            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void uctxtProcessName_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtProcessName.SelectionStart;
            uctxtProcessName.Text = Utility.gmakeProperCase(uctxtProcessName.Text);
            uctxtProcessName.SelectionStart = x;
        }
       
      
        private void uctxtProcessName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 1)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_MENU_PROCESS_MAIN", "PROCESS_NAME", uctxtProcessName.Text);
                    if (strDuplicate != "")
                    {

                        MessageBox.Show(strDuplicate);
                        uctxtProcessName.Text = "";
                        uctxtProcessName.Focus();
                        return;

                    }
                }
                uctxtFGItem.Focus();
            }
        }
        private void uctxtProcessName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                //uctxtItemName.AppendText(Interaction.GetSetting(Application.ExecutablePath, "StockItem", "ItemName"));
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                uctxtProcessName.AppendText((String)rk.GetValue("ProcessName", ""));
                rk.Close();
            }

        }

        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                //lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
            }
        }

        private void btnLeftSingle_Click(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight.SelectedItem.ToString());
                lstRight.Items.Remove(lstRight.SelectedItem.ToString());
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

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                string strItem = lstRight.Items[i].ToString().TrimStart();
                lstLeft.Items.Add(strItem);
            }
            lstRight.Items.Clear();
        }


        #endregion

        private void frmProcessFG_Load(object sender, EventArgs e)
        {
            mLoad();
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            
        }
        private void mLoad()
        {
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<ManuProcess> oogrp = invms.mLoadProcess(strComID, "", "", 0, 0, Utility.gstrUserName).ToList();
            if (oogrp.Count > 0)
            {
                foreach (ManuProcess ogrp in oogrp)
                {
                    lstLeft.Items.Add(ogrp.strProcessName);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int intloop=1;
            string strProcessName = "", strFGProcessName="", strSQL = "", strUOM = "", strmsg = "",strBranchID="";
            string connstring = Utility.SQLConnstringComSwitch(strComID);
            SqlTransaction myTrans;
            SqlCommand cmdInsert=new SqlCommand();
            if (uctxtProcessName.Text =="")
            {
                MessageBox.Show("Process Name Cannot be empty");
                uctxtProcessName.Focus();
                return;
            }
            if (uctxtFGItem.Text == "")
            {
                MessageBox.Show("FG Item Cannot be empty");
                uctxtFGItem.Focus();
                return;
            }
            if (txtFGQty.Text =="0")
            {
                MessageBox.Show("Qty. Cannot be empty");
                txtFGQty.Focus();
                return;
            }
            //if (lstRight.Items.Count <1)
            //{
            //    MessageBox.Show("Process Cannot be found");
            //    txtFGQty.Focus();
            //    return;
            //}
            strFGProcessName = uctxtFGItem.Text;
            strUOM = Utility.gGetBaseUOM(strComID, uctxtFGItem.Text);
            strBranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            using (SqlConnection gcnMain = new SqlConnection(connstring))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                try
                {
                    gcnMain.Open();
                   
                    for (intloop = 0; intloop < lstRight.Items.Count; intloop++)
                    {
                        strProcessName = lstRight.Items[intloop].ToString();

                        cmdInsert.Connection = gcnMain;
                        myTrans = gcnMain.BeginTransaction();
                        cmdInsert.Transaction = myTrans;
                        if (intloop==0)
                        {
                            strSQL = "INSERT INTO INV_MENU_PROCESS_MAIN (PROCESS_NAME,TRANSFER_TYPE,BRANCH_ID) VALUES ('" + uctxtProcessName.Text.Replace("'", "''") + "'," + 1 + ",'" + strBranchID + "')";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            strSQL = "INSERT INTO INV_MANU_PROCESS(PROCESS_NAME,STOCKITEM_NAME,PROCESS_POSITION,PROCESS_QUANTITY,PROCESS_UNIT,INV_PER,PROCESS_TYPE,GODOWNS_NAME) ";
                            strSQL = strSQL + "VALUES(";
                            strSQL = strSQL + "'" + uctxtProcessName.Text.Replace("'", "''") + "' ";
                            strSQL = strSQL + ",'" + uctxtFGItem.Text.Replace("'", "''") + "' ";
                            strSQL = strSQL + ",1";
                            strSQL = strSQL + "," + Utility.Val(txtFGQty.Text) + " ";
                            strSQL = strSQL + ",'" + strUOM + "' ";
                            strSQL = strSQL + ",'" + strUOM + "' ";
                            strSQL = strSQL + ",2";
                            strSQL = strSQL + ",'" + uctxtLocation.Text.Replace("'", "''") + "' ";
                            strSQL = strSQL + ")";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                        strSQL = "INSERT INTO INV_MANU_PROCESS(PROCESS_NAME,STOCKITEM_NAME,PROCESS_POSITION,PROCESS_QUANTITY,PROCESS_UNIT,INV_PER,PROCESS_TYPE,GODOWNS_NAME) ";
                        strSQL = strSQL + "SELECT '" + uctxtProcessName.Text.Replace("'", "''") + "',STOCKITEM_NAME,PROCESS_POSITION,PROCESS_QUANTITY,PROCESS_UNIT,INV_PER,PROCESS_TYPE,'" + uctxtLocation.Text.Replace("'", "''") + "'";
                        strSQL = strSQL + "FROM INV_MANU_PROCESS  ";
                        strSQL = strSQL + "WHERE PROCESS_NAME ='" + strProcessName.Replace("'", "''") + "' ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                       

                        cmdInsert.Transaction.Commit();
                        strmsg = "1";
                        strProcessName = "";
                       

                    }
                    if (strmsg =="1")
                    {
                        uctxtFGItem.Text = "";
                        txtFGQty.Text = "";
                        uctxtBranchName.Text = "";
                        uctxtLocation.Text = "";
                        uctxtProcessName.Text = "";
                        lstRight.Items.Clear();
                        MessageBox.Show("Record Save Successfully...");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

       

        private void btnSerach1_Click(object sender, EventArgs e)
        {
            frmAllReferanceGroup objfrm = new frmAllReferanceGroup();
            objfrm.lngVtype = 9999;
            objfrm.onAddAllButtonClickedFG = new frmAllReferanceGroup.AddAllClickFG(DisplayVoucherListFG);
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }

        private void DisplayVoucherListFG(List<StockItem> tests, object sender, EventArgs e)
        {

            uctxtFGItem.Text = tests[0].strItemName;
            txtFGQty.Focus();


        }

        private void btnRightAll_Click_1(object sender, EventArgs e)
        {

        }

        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            btnRightSingle.PerformClick();
        }

        private void btnRightSingle_Click_1(object sender, EventArgs e)
        {

        }

        

       


       


      

     

      
    }
}
