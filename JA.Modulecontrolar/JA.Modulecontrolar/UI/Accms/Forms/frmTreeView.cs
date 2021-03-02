using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using MayhediExportExcelToTree;
using Microsoft.Win32;
using System.Threading;

namespace JA.Modulecontrolar.UI.Forms
{
    public partial class frmTreeView : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private const string mcGROUP_PREFIX = "G_";
        private const string mcLEDGER_PREFIX = "L_";
        public string strType = "";
        private string strComID { get; set; }
        public frmTreeView()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.radActive.Click += new System.EventHandler(this.radActive_Click);
            this.radInactive.Click += new System.EventHandler(this.radInactive_Click);
            this.radAll.Click += new System.EventHandler(this.radAll_Click);
        }
        //private void ExpandAll(TreeNode treeNode)
        //{
        //    foreach (TreeNode tn in treeNode.Nodes)
        //    {

        //        TreeNode firstNodeWithText = (from TreeNode node in tn.Nodes
        //                                      where node.Text.Contains("")
        //                                      select node).FirstOrDefault<TreeNode>();
        //        tvwGroup.SelectedNode = firstNodeWithText;
               
        //        ExpandAll(tn);
        //    }
        //}
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
        private void mloadTreeView(int intSttsus)
        {
            string strGroup;
            
            
            if (strType != "S" && strType != "M" && strType != "C" & strType != "N")
            {
                frmLabel.Text = "     Chart of Accounts";
                System.Windows.Forms.TreeNode oNodex = null;
                tvwGroup.ImageList = imageList1;
                oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + "Assets", "Assets", "closed");
                oNodex.Expand();
                oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + "Liabilities", "Liabilities", "closed");
                oNodex.Expand();
                oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + "Income", "Income", "closed");
                oNodex.Expand();
                oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + "Expenses", "Expenses", "closed");
                oNodex.Expand();
                List<AccountdGroup> oogrp = accms.GetAccountsTreeview(strComID).ToList();
                foreach (AccountdGroup ogrp in oogrp)
                {
                    strGroup = ogrp.GroupName.ToString();
                    oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.ParentName.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    oNodex.ImageIndex = 0;
                    oNodex.SelectedImageIndex = 0;
                    oNodex.Expand();
                    oNodex.EnsureVisible();
                    mAddItem(strGroup, intSttsus);
                }
            }
            else if (strType == "N")
            {
                frmLabel.Text = "Chart of Cost Center";
                System.Windows.Forms.TreeNode oNodex = null;
                tvwGroup.ImageList = imageList1;
                //oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + "Sundry Debtors", "Sundry Debtors", "closed");
                //oNodex.Expand();
                List<VectorCategory> oogrp = accms.mFillVectorCategory(strComID).ToList();
                foreach (VectorCategory ogrp in oogrp)
                {
                    strGroup = ogrp.strVectorcategory.ToString();
                    oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + strGroup, ogrp.strVectorcategory, "closed");
                    oNodex.ImageIndex = 0;
                    oNodex.SelectedImageIndex = 0;
                    oNodex.ExpandAll();
                    oNodex.EnsureVisible();
                    mAddItemCostCenter(strGroup);

                }

            }
            else if (strType == "M")
            {
                frmLabel.Text = "Chart of Medical Representative";
                System.Windows.Forms.TreeNode oNodex = null;
                tvwGroup.ImageList = imageList1;
                oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + "Sundry Debtors", "Sundry Debtors", "closed");
                oNodex.Expand();
                List<AccountdGroup> oogrp = accms.GetAccountsTreeviewDR(strComID).ToList();
                foreach (AccountdGroup ogrp in oogrp)
                {
                    strGroup = ogrp.GroupName.ToString();
                    oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.ParentName.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    //oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    oNodex.ImageIndex = 0;
                    oNodex.SelectedImageIndex = 0;
                    oNodex.ExpandAll();
                    oNodex.EnsureVisible();
                    mAddItemMR(strGroup, intSttsus);

                }

            }
            else if (strType == "C")
            {
                frmLabel.Text = "Chart of Sundry Creditors";
                System.Windows.Forms.TreeNode oNodex = null;
                tvwGroup.ImageList = imageList1;
                oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + "Sundry Creditors", "Sundry Creditors", "closed");
                oNodex.Expand();
                List<AccountdGroup> oogrp = accms.GetAccountsTreeviewCR(strComID).ToList();
                foreach (AccountdGroup ogrp in oogrp)
                {
                    strGroup = ogrp.GroupName.ToString();
                    oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.ParentName.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    //oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    oNodex.ImageIndex = 0;
                    oNodex.SelectedImageIndex = 0;
                    oNodex.ExpandAll();
                    oNodex.EnsureVisible();
                    mAddItem(strGroup, intSttsus);
                }
            }
            else
            {

                frmLabel.Text = "Doctor/Customer Treeview";
                System.Windows.Forms.TreeNode oNodex = null;
                tvwGroup.ImageList = imageList1;
                List<AccountsLedger> oogrp = accms.GetSalesLedgerTree(strComID).ToList();
                foreach (AccountsLedger ogrp in oogrp)
                {
                    strGroup = ogrp.strRepName.ToString();
                    oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + strGroup, ogrp.strParentGroup, "closed");
                    oNodex.ImageIndex = 0;
                    oNodex.SelectedImageIndex = 0;
                    oNodex.ExpandAll();
                    oNodex.EnsureVisible();
                    mAddItemSales(strGroup);
                }

            }

        }

        private void frmTreeView_Load(object sender, EventArgs e)
        {

            mloadTreeView(0);

        }
        void expAll(TreeNode node)
        {
            node.Expand();
            foreach (TreeNode i in node.Nodes)
            {
                expAll(i);
            }
        }
        private void mAddItemSales(string vstrRoot)
        {
            string strChild = "";
            System.Windows.Forms.TreeNode oNodex = null;
            List<AccountsLedger> oaccLed = accms.GetSalesLedgerTreefromCustomer(strComID, vstrRoot).ToList();
            foreach (AccountsLedger oLed in oaccLed)
            {
              
                strChild = oLed.strLedgerName;
                oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + vstrRoot, true)[0].Nodes.Add(mcLEDGER_PREFIX + strChild, strChild, "leaf");
                oNodex.ImageIndex = 1;
                oNodex.SelectedImageIndex = 1;
                oNodex.EnsureVisible();
                oNodex.ExpandAll();
                oNodex.Expand();
            }


        }
        private void mAddItemCostCenter(string vstrRoot)
        {
            string strChild = "";
            System.Windows.Forms.TreeNode oNodex = null;
            List<VectorCategory> oaccLed = accms.mFillVectorMaster(strComID, vstrRoot).ToList();
            foreach (VectorCategory oLed in oaccLed)
            {
                strChild = oLed.strCostCenter;
                oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + vstrRoot, true)[0].Nodes.Add(mcLEDGER_PREFIX + strChild, strChild, "leaf");
                oNodex.ImageIndex = 1;
                oNodex.SelectedImageIndex = 1;
                oNodex.ExpandAll();
            }


        }
        private void mAddItemMR(string vstrRoot,int intstatus)
        {
            string strChild = "";
            System.Windows.Forms.TreeNode oNodex = null;
            List<AccountsLedger> oaccLed = accms.mLedgerAdditemMr(strComID, vstrRoot, intstatus).ToList();
            foreach (AccountsLedger oLed in oaccLed)
            {
                strChild = oLed.strmerzeString;
                oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + vstrRoot, true)[0].Nodes.Add(mcLEDGER_PREFIX + strChild, strChild, "leaf");
                oNodex.ImageIndex = 1;
                oNodex.SelectedImageIndex = 1;
                oNodex.ExpandAll();
            }


        }
        private void mAddItem(string vstrRoot, int intststus)
        {
            string strChild = "";
        
            
            System.Windows.Forms.TreeNode oNodex = null;
            List<AccountsLedger> oaccLed = accms.mLedgerAdditem(strComID, vstrRoot, intststus).ToList();
            foreach (AccountsLedger oLed in oaccLed)
            {
                strChild = oLed.strLedgerName;
                oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + vstrRoot, true)[0].Nodes.Add(mcLEDGER_PREFIX + strChild, strChild, "leaf");
                oNodex.ImageIndex = 1;
                oNodex.SelectedImageIndex = 1;
            }
            

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var print = new TreeviewPrinting.PrintHelper();
                //print.PrintPreviewTree(this.treeviewprint, "Chart of Accounts of Ali Hospital");
                print.PrintTree(this.tvwGroup, "     Tree View");
            }

           
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string Chosen_File = "";
           

            SaveFileDialog optSave = new SaveFileDialog();
            optSave.ValidateNames = true;
            optSave.Title = "Browse Text Files";
            optSave.Filter = "xlsx (*.xlsx)|*.xlsx";
            optSave.FilterIndex = 2;
            optSave.RestoreDirectory = true;

            //string selectedPath;
            var t = new Thread((ThreadStart)(() =>
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
                fbd.ShowNewFolderButton = true;
                if (optSave.ShowDialog() == DialogResult.OK)
                {
                    Chosen_File = optSave.FileName;
                    Export.ExportToExcel(tvwGroup, Chosen_File);
                    MessageBox.Show("Export Success");
                }
                //if (Chosen_File == String.Empty)
                //{
                //    return;
                //}
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();



            //SaveFileDialog optSave = new SaveFileDialog();
            //optSave.ValidateNames = true;
            //optSave.Title = "Browse Text Files";
            //optSave.Filter = "xlsx (*.xlsx)|*.xlsx";
            //optSave.FilterIndex = 2;
            //optSave.RestoreDirectory = true;

            //if (optSave.ShowDialog() == DialogResult.OK)
            //{
            //    Chosen_File = optSave.FileName;
            //}
            //if (Chosen_File == String.Empty)
            //{
            //    return;
            //}
            //Export.ExportToExcel(tvwGroup, Chosen_File);
            //MessageBox.Show("Export Success");
        }

        private void uctxtSeacrh_KeyUp(object sender, KeyEventArgs e)
        {
            ////if (uctxtSeacrh.Text !="")
            ////{
            
            //FindByText();
            //}
        }
      


        private void FindByText()
        {
            TreeNodeCollection nodes = tvwGroup.Nodes;
            foreach (TreeNode n in nodes)
            {
                n.BackColor = Color.White;
                FindRecursive(n);
                
            }
           
        }

        private void FindRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                // if the text properties match, color the item
                //if (tn.Text == this.uctxtSeacrh.Text)
                //{
                //    tn.BackColor = Color.Yellow;
                //}
                //else
                //{
                //    tn.BackColor = Color.White;
                //}
                //IEnumerable<TreeNode> foundItems = from TreeNode node in tn.Nodes where node.Text.Contains(this.uctxtSeacrh.Text) select node;
                //if (foundItems.Count() > 0)
                //{
                //    tn.BackColor = Color.Yellow;
                //}
                //else
                //{
                //    tn.BackColor = Color.White;
                //}


                tn.ExpandAll();
                tn.Collapse(); 
              
                   

                FindRecursive(tn);
            }
        }

        private void uctxtSeacrh_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            this.tvwGroup.ExpandAll();
        }

        private void radActive_Click(object sender, EventArgs e)
        {
            int intSttsus = 0;
            if (radActive.Checked == true)
            {
                intSttsus = 0;
            }
            else
            {
                intSttsus = 1;
            }
            tvwGroup.Nodes.Clear();
            mloadTreeView(intSttsus);
        }

        private void radInactive_Click(object sender, EventArgs e)
        {
            int intSttsus = 0;
            if (radActive.Checked == true)
            {
                intSttsus = 0;
            }
            else
            {
                intSttsus = 1;
            }
            tvwGroup.Nodes.Clear();
            mloadTreeView(intSttsus);
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            int intSttsus = 0;
            if (radActive.Checked == true)
            {
                intSttsus = 0;
            }
            else
            {
                intSttsus = 1;
            }
            tvwGroup.Nodes.Clear();
            mloadTreeView(intSttsus);
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            int intSttsus = 0;
            intSttsus = 3;
            tvwGroup.Nodes.Clear();
            mloadTreeView(intSttsus);
        }

      

        

    }
}
