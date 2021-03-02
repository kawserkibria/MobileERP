using Dutility;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
using JA.Modulecontrolar.JINVMS;
using JA.Modulecontrolar.UI.DReport.Inventory.Viewer;
using JA.Modulecontrolar.UI.DReport.Inventory;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmOverheadValueInsert : JA.Shared.UI.frmJagoronFromSearch
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<AccBillwise> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;

        public delegate void AddAllClickFG(List<StockItem> items, object sender, EventArgs e);
        public AddAllClickFG onAddAllButtonClickedFG;

        List<AccBillwise> oogrp;
        List<StockItem> oostritem;
        public string strPartyname = "";
        public string strDate = "";
        public string strBranchID = "";
        public long lngVtype = 0;
        private string strComID { get; set; }
        public frmOverheadValueInsert()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

        }
 
        private void frmOverheadValueInsert_Load(object sender, EventArgs e)
        {
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strItemname = "";
            List<StockItem> oogrp = invms.gFillStockItemAllWithoutGodown(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "").ToList();
            if (oogrp.Count > 0)
            {
                foreach (StockItem ostk in oogrp)
                {
                    strItemname = ostk.strLocation;
                }
            }
        }
 




    }
}
