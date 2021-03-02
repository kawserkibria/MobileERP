using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.DReport.Inventory.Viewer;
using Microsoft.Win32;
using JA.Modulecontrolar.JACCMS;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmStockGroupMapping : JA.Shared.UI.frmJagoronFromSearch
    {

        private string strString3 = "";

        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JRPT.ISWRPT jrpt = new JRPT.SWRPTClient();
        private ListBox lstBranch = new ListBox();
        List<StockItem> oogrp;
        List<StockGroup> ooggrop;
        public string strType { get; set; }
        private string strComID { get; set; }
        private string strName = "";
        public frmStockGroupMapping()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            this.lstLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstLeft_KeyPress);



            ///Invoice Price
            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);

            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranchName);


        }
        #region "User Deifne Sales Price"

        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranch.Text;
            lstBranch.Visible = false;
            txtSearch.Focus();


        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranch.Text;
                }
                lstBranch.Visible = false;
                txtSearch.Focus();


            }
        }
        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranch.SelectedItem != null)
                {
                    lstBranch.SelectedIndex = lstBranch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranch.Items.Count - 1 > lstBranch.SelectedIndex)
                {
                    lstBranch.SelectedIndex = lstBranch.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = true;
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranchName.Text);

        }

        #endregion

        private void mLoadStockGroup()
        {


            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            List<StockItem> oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "N", "", "").ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemGroup);
                }
            }
        }



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstLeft.SelectedIndex = lstLeft.FindString(txtSearch.Text);
        }



        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnRightSingle.PerformClick();
                lstLeft.SetSelected(0, true);
                txtSearch.Text = "";
                txtSearch.Focus();
                // dteFromDate.Focus();

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

        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            btnRightSingle.PerformClick();
            lstLeft.SetSelected(0, true);
        }

        private void lstLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnRightSingle.PerformClick();
                lstLeft.SetSelected(0, true);
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }
        private void mLoad()
        {

            lstLeft.Items.Clear();
            lstRight.Items.Clear();
    
            mapingStockGroup();
        }
        private void mapingStockGroup()
        {
            ooggrop = invms.mLoadMappingStockGroup(strComID, strString3).ToList();
            if (ooggrop.Count > 0)
            {
                foreach (StockGroup ostk in ooggrop)
                {
                    lstRight.Items.Add(ostk.GroupName);
                }
            }
        }

      
        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
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

        private void frmStockGroupMapping_Load(object sender, EventArgs e)
        {
            Optoncheck();

            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
            mLoad();
            lstBranch.Visible = false;
            uctxtBranchName.Text = lstBranch.Text;
            txtSearch.Focus();
        }
        private void Optoncheck()
        {
            if (rbtnChemical.Checked == true)
            {
                strString3 = "Chemicals";
            }
            else if (rbtnHerbs.Checked == true)
            {
                strString3 = "Herbs";
            }
            else
            {
                strString3 = "Packing";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strmsg = "", strString = "", strString2 = "";
            int intType = 0;
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            Optoncheck();
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtBranchName.Focus();
                return;
            }
            if (lstRight.Items.Count == 0)
            {
                MessageBox.Show("Cannot be Empty");
            }

            string strbranchID = Utility.gstrGetBranchID(strComID, uctxtBranchName.Text);
            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                strString = strString + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "'|";
            }
            //if (lstRight.Items.Count == 0)
            //{
            //    strString = "'NONE'|";
            //}

            if (strString != "")
            {
                strString = Utility.Mid(strString, 0, strString.Length - 1);
            }


            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                strString2 = strString2 + "'" + lstRight.Items[i].ToString().Replace("'", "''") + "',";
            }
            if (lstRight.Items.Count == 0)
            {
                strString2 = "'NONE',";
            }

            if (strString != "")
            {
                strString2 = Utility.Mid(strString2, 0, strString2.Length - 1);
            }

            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                try
                {
                    strmsg = invms.mStockGroupMapping(strComID, strbranchID, strString3, strString, strString2);
                    if (Utility.gblnAccessControl)
                    {
                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "StockGroupMapping", "StockGroupMapping",
                                                                1, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(strmsg);
                }
            }



        }

        private void frmLabel_Click(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtnPacking_Click(object sender, EventArgs e)
        {
            Optoncheck();
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            mapingStockGroup();
            oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "K", "Indirect Raw Materials", "").ToList();

            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemGroup);
                }
            }
        }

        private void rbtnHerbs_Click(object sender, EventArgs e)
        {
            Optoncheck();
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            mapingStockGroup();
            oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "K", "Direct Raw Materials", "").ToList();

            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemGroup);
                }
            }
        }

        private void rbtnChemical_Click(object sender, EventArgs e)
        {
            Optoncheck();
            lstLeft.Items.Clear();
            lstRight.Items.Clear();
            mapingStockGroup();
            oogrp = invms.gLoadStockGroup(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "K", "Direct Raw Materials", "").ToList();

            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    lstLeft.Items.Add(ostk.strItemGroup);
                }
            }
        }

        private void rbtnChemical_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
