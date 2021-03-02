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


namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmBatchTree : JA.Shared.UI.frmJagoronFromSearch
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private const string mcGROUP_PREFIX = "G_";
        private const string mcLEDGER_PREFIX = "L_";
        public string strYear { get; set; }
        public int intConvertFg { get; set; }
        private string strComID { get; set; }
        public frmBatchTree()
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

            if (optSave.ShowDialog() == DialogResult.OK)
            {
                Chosen_File = optSave.FileName;
            }
            if (Chosen_File == String.Empty)
            {
                return;
            }
            Export.ExportToExcel(tvNode, Chosen_File);
            MessageBox.Show("Export Success");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var print = new TreeviewPrinting.PrintHelper();
                //print.PrintPreviewTree(this.treeviewprint, "Chart of Accounts of Ali Hospital");
                print.PrintTree(this.tvNode, "     Batch Tree View for the Year of  " + strYear + " ");
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmStockTree_Load(object sender, EventArgs e)
        {
            frmLabel.Text ="Batch Tree View for the Year of  " + strYear + " ";

            mLoadMonthTree(strYear);

        }

        private static string GetMonth(int intDay)
        {
            string Month = "";
            if (intDay == 1)
            {
                Month = "January";
            }
            else if (intDay == 2)
            {
                Month = "February";
            }
            else if (intDay == 3)
            {
                Month = "March";
            }
            else if (intDay == 4)
            {
                Month = "April";
            }
            else if (intDay == 5)
            {
                Month = "May";
            }
            else if (intDay == 6)
            {
                Month = "June";
            }
            else if (intDay == 7)
            {
                Month = "July";
            }
            else if (intDay == 8)
            {
                Month = "August";
            }
            else if (intDay == 9)
            {
                Month = "September";
            }
            else if (intDay == 10)
            {
                Month = "October";
            }
            else if (intDay == 11)
            {
                Month = "November";
            }
            else if (intDay == 12)
            {
                Month = "December";
            }
            return Month;
        }

        private void mLoadMonthTree(string pYear)
        {

            string strMonthType = "";
            string strDate = "";
            DateTime dteDate;
            System.Windows.Forms.TreeNode oNodex = null;
            int i = 0;
            //string strSelection;
            ////strSelection = tvNode.SelectedNode.Text;
            this.tvNode.Nodes.Clear();
            tvNode.ImageList = imageList1;
            for (int intNode = 1; intNode <= 12; intNode++)
            {
                string strMonthName = GetMonth(intNode);
                oNodex = tvNode.Nodes.Add(mcGROUP_PREFIX + strMonthName, strMonthName, "");
                oNodex.ImageIndex = 0;
                oNodex.Expand();
            }

            List<Batch> oogrp = invms.mDisPlaybatch(strComID, 0, pYear).ToList();
            foreach (Batch inv in oogrp)
            {

                int intMonth = Convert.ToDateTime(inv.strStartDate).Month;
                strMonthType = GetMonth(intMonth);
                if (strDate != inv.strStartDate)
                {
                    oNodex = tvNode.Nodes.Find(mcGROUP_PREFIX + strMonthType, true)[0].Nodes.Add(mcGROUP_PREFIX + inv.strStartDate, inv.strStartDate, "closed");
                    dteDate = Convert.ToDateTime(inv.strStartDate);
                    strDate = inv.strStartDate;
                    oNodex.ImageIndex = 0;
                }
                oNodex.Expand();
            }

            foreach (Batch inv in oogrp)
            {
                oNodex = tvNode.Nodes.Find(mcGROUP_PREFIX + inv.strStartDate, true)[0].Nodes.Add(mcGROUP_PREFIX + inv.strLogNo, inv.strLogNo, "closed");
                oNodex.ImageIndex = 1;
                oNodex.SelectedImageIndex = 1;
                oNodex.Expand();
            }





        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            this.tvNode.ExpandAll();
        }



    }
}
