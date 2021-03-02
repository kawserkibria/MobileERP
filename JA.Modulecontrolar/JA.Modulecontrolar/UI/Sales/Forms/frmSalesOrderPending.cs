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
using JA.Modulecontrolar.UI.DReport.Purchase.Viewer;
using JA.Modulecontrolar.UI.DReport.Purchase;
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using JA.Modulecontrolar.UI.DReport.Accms;
using Microsoft.Win32;
using JA.Modulecontrolar.JINVMS;


namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSalesOrderPending : JA.Shared.UI.frmJagoronFromSearch
    {
        SPWOIS objWoIS = new SPWOIS();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public delegate void AddAllClick(List<AccountsVoucher> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public long lngFormPriv { get; set; }
        public int intModuleType { get; set; }
        public int intAreaStaus { get; set; }
        public string strFormName { get; set; }
        public int mintVType { get; set; }
        public int mintSp { get; set; }
        private bool mblnNumbMethod { get; set; }
        private int mintIsPrin { get; set; }
       
        public string strPreserveSQl { get; set; }
       
        private string strComID { get; set; }
        public frmSalesOrderPending()
        {
            InitializeComponent();
            #region "Registry"
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #endregion
           
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
        


        
       
        private void frmSalesOrderPending_Load(object sender, EventArgs e)
        {
          
            DG.AllowUserToAddRows = false;
           
            if (mintVType == (int)(Utility.VOUCHER_TYPE.vtSALES_ORDER))
            {
                frmLabel.Text = "Sales Order List";
            }


            this.DG.DefaultCellStyle.Font = new Font("verdana", 10F);


            DG.Columns.Add(Utility.Create_Grid_Column("SLNo", "SLNo", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Voucher key", "Voucher No", 200, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 170, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 90, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 270, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Branch Name", "Branch Name", 250, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Net Amount", "Net Amount", 118, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("App.", "App.", 40, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.CreateChkBxGrd("Check", "Check", 50, false, DataGridViewContentAlignment.TopLeft, false, false, "Check"));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit ", 45, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Return", "Return", "Return", 70, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("View", "View", "View", 60, false, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Sql", "Sql", 110, false, DataGridViewContentAlignment.TopLeft, true));
                        
          
            mFetchRecord("", "", "", "", intAreaStaus);
        }

        private void mFetchRecord(string strFindWhat, string strExpression, string strFdate, string strTdate, int intAreaStatus)
        {
            DG.Rows.Clear();

            List<AccountsVoucher> ooVlist;
            if (strPreserveSQl == null)
            {
                strPreserveSQl = "";
            }

            ooVlist = objWoIS.mOpenTablePenidngOrder(strComID, mintVType, strFindWhat, "", Utility.gstrUserName, "", "", mintSp, strPreserveSQl, intAreaStatus).ToList();


            if (ooVlist.Count() > 0)
            {
                int j = 0;
                foreach (AccountsVoucher ovoucher in ooVlist)
                {
                    DG.Rows.Add();
                    DG[1, j].Value = ovoucher.strVoucherNo;
                    DG[2, j].Value = Utility.Mid(ovoucher.strVoucherNo, 6, ovoucher.strVoucherNo.Length - 6);
                    DG[3, j].Value = Convert.ToDateTime(ovoucher.strTranDate).ToString("dd/MM/yyyy");
                    DG[4, j].Value = ovoucher.strMerzeName;
                    DG[5, j].Value = ovoucher.strBranchName;
                    DG[6, j].Value = ovoucher.dblAmount;
                   
                    DG[9, j].Value = "Edit";
                    DG[10, j].Value = "Return";
                    DG[11, j].Value = "View";
                    DG[12, j].Value = ovoucher.strPreserveSQL;
                    j += 1;

                }
                DG.AllowUserToAddRows = false;
                lblCount.Text = "Total Record: " + j;
            }

        }


        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
          
            if (e.ColumnIndex == 9)
            {

                if (onAddAllButtonClicked != null)
                    onAddAllButtonClicked(GetSelectedItem(), sender, e);
                this.Dispose();
            }
            if (e.ColumnIndex == 10)
            {
                var strResponse = MessageBox.Show("Do You  want to Return?", "Return Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    double dblAmnt = Convert.ToDouble(DG.CurrentRow.Cells[6].Value.ToString());
                    string i = Delete.gReturnRecordApps(strComID, DG.CurrentRow.Cells[1].Value.ToString());
                    if (i == "1")
                    {

                        MessageBox.Show("Return Successfully..");
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Order Pending List", DG.CurrentRow.Cells[1].Value.ToString(),
                                                                    3, dblAmnt, intModuleType, "0001");
                        }
                        DG.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        MessageBox.Show(i.ToString());
                    }
                   
                }

            }
            if (e.ColumnIndex == 11)
            {
                if (mintVType == (int)Utility.VOUCHER_TYPE.vtSALES_ORDER)
                {

                   
                    JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer frmviewer = new JA.Modulecontrolar.UI.DReport.Purchase.Viewer.frmReportViewer();
                    frmviewer.selector = JA.Modulecontrolar.UI.DReport.Purchase.ViewerSelector.VouchearVouNoListReport;
                    frmviewer.strString = "'" + DG.CurrentRow.Cells[1].Value.ToString() + "'";
                    frmviewer.strString2 = "Sales Order";
                    frmviewer.intSuppress = 1;
                    frmviewer.intMode = mintVType;
                    frmviewer.Show();
                }


            }


        }


        private List<AccountsVoucher> GetSelectedItem()
        {
            List<AccountsVoucher> items = new List<AccountsVoucher>();
            AccountsVoucher itm = new AccountsVoucher();
            itm.strAgnstRefNo = DG.CurrentRow.Cells[1].Value.ToString();
            itm.strOrderNo = DG.CurrentRow.Cells[2].Value.ToString();
            itm.strOrderDate = DG.CurrentRow.Cells[3].Value.ToString();
            itm.strMerzeName = DG.CurrentRow.Cells[4].Value.ToString();
            itm.strLedgerName = Utility.gGetLedgerNameFromMerze(strComID, DG.CurrentRow.Cells[4].Value.ToString());
           
            items.Add(itm);
            return items;
        }

        private void DG_DoubleClick(object sender, EventArgs e)
        {
            if (onAddAllButtonClicked != null)
                onAddAllButtonClicked(GetSelectedItem(), sender, e);
            this.Dispose();
        }

       

       

    
     
   
    
       
     
      

      

      

     


    }
}
