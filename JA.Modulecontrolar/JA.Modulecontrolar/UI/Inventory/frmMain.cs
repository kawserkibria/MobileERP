using Dutility;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;




namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmMain : JA.Shared.UI.frmJagoronFromSearch
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<AccBillwise> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;

     

        List<AccBillwise> oogrp;
        
        public string strPartyname = "";
        public string strDate = "";
        public string strBranchID = "";
        public long lngVtype = 0;
        private string strComID { get; set; }
        public frmMain()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

        }
        ModelTree obj = new ModelTree();
      
      
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 77))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            obj.ClassTree(e.Node.Name, this);


        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            treeView1.Select();
        }




    }
}
