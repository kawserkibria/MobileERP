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
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
using JA.Modulecontrolar.JSAPUR;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmAMOnlineCode : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstBranch = new ListBox();
        public int intmode = 0;
        public long lngFormPriv { get; set; }
        public string strSelection { get; set; }
        List<StockItem> oogrp;
        public int m_action { get; set; }
        private string strComID { get; set; }
        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        public frmAMOnlineCode()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
  
            this.DG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellClick);
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
           
        }

        #region "User Deifine"

        private void uclstGrdItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }
        private void mLoadLedgerGorup()
        {

       
            //if (rbtnArea.Checked  == true)
            //{
            //    intmode = 1;
            //}
            //else
            //{
            //    intmode = 2;
            //}
            //int introw = 0;
            //this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            //List<RSalesPurchase> oogrp = orpt.mGetMpoGroupLoadOnline(strComID, intmode, "").ToList();
            //if (oogrp.Count > 0)
            //{
            //    DG.Rows.Clear();
            //    if (oogrp.Count > 0)
            //    {
            //        DG.Rows.Clear();
            //        foreach (RSalesPurchase ogrp in oogrp)
            //        {
            //            DG.Rows.Add();
            //            DG[0, introw].Value = ogrp.strGroupAMFM;
            //            DG[1, introw].Value = ogrp.strArea;
            //            introw += 1;
            //        }
            //        DG.AllowUserToAddRows = false;
            //    }

            //}

        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                try
                {
                    DG.Rows.RemoveAt(e.RowIndex);
                }
                catch (Exception ex)
                {

                }
            }
        }
        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
        private void mDisplayBonusItemGroup(string vstrdate)
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
           
            List<SalesPriceLevel> oogrp = invms.mDisplayBonusItemGroup(strComID, vstrdate).ToList();
            if (oogrp.Count > 0)
            {
                DG.Rows.Clear();
                foreach (SalesPriceLevel ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strPrice.strItemName;
                    DG[1, introw].Value = ogrp.dblFromQty + " " + Utility.gGetBaseUOM(strComID, ogrp.strPrice.strItemName);
                    DG[2, introw].Value = ogrp.dblToQty + " " + Utility.gGetBaseUOM(strComID, ogrp.strPrice.strItemName);
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }
        private void mAdditem(int intempcode, string strEmpName, double intMobilenumber, string strAddress)
        { 
            int selRaw;

            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < DG.RowCount; j++)
            {
                if (DG[0, j].Value != null)
                {
                    strDown = DG[0, j].Value.ToString();
                }
                if (strEmpName == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {  

                DG.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DG.RowCount.ToString());
                selRaw = selRaw - 1;
                DG.Rows.Add();
                DG[0, selRaw].Value = intempcode;
                DG[1, selRaw].Value = strEmpName;
                DG[2, selRaw].Value = intMobilenumber;
                DG[3, selRaw].Value = strAddress;
                DG.AllowUserToAddRows = false;
            }

        }

        #endregion
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Keys.Escape == keyData)
            {
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }

            return false;
        }
        private void frmAMOnlineCode_Load(object sender, EventArgs e)
        {
            lstBranch.Visible = false;
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("Area Name", "Area Name",300, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Code", "Code", 100, true, DataGridViewContentAlignment.TopLeft, false));

            mLoadLedgerGorup();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strGrid = "";

            
            var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
            //    try
            //    {
            //        for (int i = 0; i < DG.Rows.Count;i ++ )
            //        {
            //            strGrid = strGrid + DG[0, i].Value + "|" + DG[1, i].Value + "~";
            //        }
            //            if (strGrid != "")
            //            {
            //                string strmsg = orpt.mInsertAreaCodeOnline(strComID, strGrid, intmode);
            //                if (strmsg == "1")
            //                {
            //                    if (Utility.gblnAccessControl)
            //                    {
            //                        string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "OnlineCode", "OnlineCode",
            //                                                                m_action, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
            //                    }
            //                    m_action = 1;
            //                    DG.Rows.Clear();
            //                }
            //                else
            //                {
            //                    MessageBox.Show(strmsg);
            //                }


            //            }

            //    }

            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }
        private void rbtnArea_Click(object sender, EventArgs e)
        {
            mLoadLedgerGorup();
     
        }

        private void rbtnDivision_Click(object sender, EventArgs e)
        {
            mLoadLedgerGorup();
        }

    }
}
