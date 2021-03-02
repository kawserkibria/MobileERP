using MayhediExportExcelToTree;
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
using System.Threading;


namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmStockTree : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private const string mcGROUP_PREFIX = "G_";
        private const string mcLEDGER_PREFIX = "L_";
        public string strName { get; set; }
        private string strComID { get; set; }
        public frmStockTree()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string Chosen_File = "";


            SaveFileDialog optSave = new SaveFileDialog();
            optSave.ValidateNames = true;
            optSave.Title = "Browse Text Files";
            optSave.Filter = "xlsx (*.xlsx)|*.xlsx";
            optSave.FilterIndex = 2;
            optSave.RestoreDirectory = true;
            
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

            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
           


      
           
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var print = new TreeviewPrinting.PrintHelper();
                //print.PrintPreviewTree(this.treeviewprint, "Chart of Accounts of Ali Hospital");
                print.PrintTree(this.tvwGroup, "     Chart of Inventory");
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmStockTree_Load(object sender, EventArgs e)
        {
            string strGroup;
            if (strName == "1")
            {
                frmLabel.Text = "Chart of Inventory";
                System.Windows.Forms.TreeNode oNodex = null;
                tvwGroup.ImageList = imageList1;
                List<StockItem> oogrp = invms.mFillStockTreeGroupLevel(strComID).ToList();
                foreach (StockItem ogrp in oogrp)
                {
                    strGroup = ogrp.strItemGroup.ToString();
                    //oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.strItemGroup.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    //oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.strItemGroup.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    oNodex.ImageIndex = 0;
                    oNodex.SelectedImageIndex = 0;
                    //oNodex.EnsureVisible();
                    mAddItem(strGroup);
                }

                List<StockItem> ooGrplbl1 = invms.mFillStockTreeGroupLevel1(strComID).ToList();
                foreach (StockItem ogrp in ooGrplbl1)
                {
                    strGroup = ogrp.strItemGroup.ToString();
                    oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.strParentGroup.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    //oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.strItemGroup.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    oNodex.ImageIndex = 0;
                    oNodex.SelectedImageIndex = 0;
                    oNodex.EnsureVisible();
                    mAddItem(strGroup);
                }
            }
            else if (strName == "2")
            {
                frmLabel.Text = "Commission Group TreeView ";

                System.Windows.Forms.TreeNode oNodex = null;
                tvwGroup.ImageList = imageList1;
                List<StockGroup> oogrp = invms.mFillStockGroupconfigNew(strComID, "").ToList();
                

                
                foreach (StockGroup ogrp in oogrp)
                {
                    strGroup = ogrp.GrName.ToString();
                    //oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.strItemGroup.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    //oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.strItemGroup.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    oNodex.ImageIndex = 0;
                    oNodex.SelectedImageIndex = 0;
                    //oNodex.EnsureVisible();
                    mAddItem1(strGroup);
                }
            }

            else if (strName == "3")
            {
                frmLabel.Text = "Pack Size TreeView ";

                System.Windows.Forms.TreeNode oNodex = null;
                tvwGroup.ImageList = imageList1;
                List<StockGroup> oogrp = invms.mFillPackSizeNew(strComID, "").ToList();
                //List<StockItem> oogrp = invms.mFillStockTreeGroupLevel().ToList();
                foreach (StockGroup ogrp in oogrp)
                {
                    strGroup = ogrp.GrName.ToString();
                    //oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.strItemGroup.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    //oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.strItemGroup.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                    oNodex.ImageIndex = 0;
                    oNodex.SelectedImageIndex = 0;
                    //oNodex.EnsureVisible();
                    mAddItem3(strGroup);
                }
            }



        }

        private void mAddItem3(string vstrRoot)
        {
            //string strGroup;
            System.Windows.Forms.TreeNode oNodex = null;
            tvwGroup.ImageList = imageList1;
            List<StockGroup> ooItem = invms.mFillPackSizeNew(strComID, vstrRoot).ToList();
            foreach (StockGroup ogrp in ooItem)
            {

                oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + vstrRoot, true)[0].Nodes.Add(mcGROUP_PREFIX + ogrp.GroupName, ogrp.GroupName, "Leaf");
                //oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                //oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.strItemGroup.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                oNodex.ImageIndex = 1;
                oNodex.SelectedImageIndex = 1;
                //oNodex.EnsureVisible();
                //mAddItem(strGroup);
            }

        }


        private void mAddItem1(string vstrRoot)
        {
            //string strGroup;
            System.Windows.Forms.TreeNode oNodex = null;
            tvwGroup.ImageList = imageList1;
            List<StockGroup> ooItem = invms.mFillStockGroupconfigNew(strComID, vstrRoot).ToList();
            foreach (StockGroup ogrp in ooItem)
            {

                oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + vstrRoot, true)[0].Nodes.Add(mcGROUP_PREFIX + ogrp.GroupName, ogrp.GroupName, "Leaf");
                //oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                //oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.strItemGroup.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                oNodex.ImageIndex = 1;
                oNodex.SelectedImageIndex = 1;
                //oNodex.EnsureVisible();
                //mAddItem(strGroup);
            }

        }

        private void mAddItem(string vstrRoot)
        {
            //string strGroup;
            System.Windows.Forms.TreeNode oNodex = null;
            tvwGroup.ImageList = imageList1;
            List<StockItem> ooItem = invms.mloadAddStockItem(strComID, vstrRoot).ToList();
            foreach (StockItem ogrp in ooItem)
            {

                oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + vstrRoot, true)[0].Nodes.Add(mcGROUP_PREFIX + ogrp.strItemName, ogrp.strItemName, "Leaf");
                //oNodex = tvwGroup.Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                //oNodex = tvwGroup.Nodes.Find(mcGROUP_PREFIX + ogrp.strItemGroup.ToString(), true)[0].Nodes.Add(mcGROUP_PREFIX + strGroup, strGroup, "closed");
                oNodex.ImageIndex = 1;
                oNodex.SelectedImageIndex = 1;
                //oNodex.EnsureVisible();
                //mAddItem(strGroup);
            }

        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            this.tvwGroup.ExpandAll();
        }




    }
}
