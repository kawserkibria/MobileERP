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

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSampleClass : JA.Shared.UI.frmSmartFormStandard
    {

        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public long lngFormPriv { get; set; }
        private string mstrOldClass { get; set; }
        List<StockItem> oogrp;
        public int m_action { get; set; }
        public int intVtype { get; set; }
        private string strComID { get; set; }

        public frmSampleClass()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
           // this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);

            this.uclstGrdItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uclstGrdItem_KeyPress);
            this.uclstGrdItem.DoubleClick += new System.EventHandler(this.uclstGrdItem_DoubleClick);

            this.uclstGrdItem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.uclstGrdItem_CellFormatting);
            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.txtClassName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtClassName_KeyPress);
            this.txtClassName.TextChanged += new System.EventHandler(this.txtClassName_TextChanged);
           
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
        private void uclstGrdItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            uclstGrdItem.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void txtClassName_TextChanged(object sender, EventArgs e)
        {
            int x = txtClassName.SelectionStart;
            txtClassName.Text = Utility.gmakeProperCase(txtClassName.Text);
            txtClassName.SelectionStart = x;
        }
        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtItemName.Text == "")
                {
                    uctxtItemName.Text = "";
                    uclstGrdItem.Visible = false;
                    btnSave.Focus();
                    return;
                }


                if (uctxtItemName.Text != "")
                {
                    uclstGrdItem.Focus();
                    if (uclstGrdItem.Rows.Count > 0)
                    {
                        int i = 0;
                        uctxtItemName.Text = uclstGrdItem.Rows[i].Cells[0].Value.ToString();
                        uclstGrdItem.Visible = false;
                        uctxtQty.Focus();
                    }
                }
                else
                {
                    int i = 0;

                    uctxtItemName.Text = uclstGrdItem.Rows[i].Cells[0].Value.ToString();
                    uclstGrdItem.Visible = false;
                    uctxtQty.Focus();
                }


            }
        }

        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            uclstGrdItem.Visible = true;
            if (e.KeyCode == Keys.Up)
            {
                uclstGrdItem.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                uclstGrdItem.Focus();
            }

            uclstGrdItem.Top = uctxtItemName.Top + 25;
            uclstGrdItem.Left = uctxtItemName.Left;
            uclstGrdItem.Width = uctxtItemName.Width;
            uclstGrdItem.Height = 200;
            //ucdgList.Size = new Size(546, 222);
            uclstGrdItem.BringToFront();
            uclstGrdItem.AllowUserToAddRows = false;
            //uctxtItemName.Text = Utility.GetDgValue(ucdgList, uctxtItemName, 0);
            //ucdgList.Focus();
            return;

        }
        private void uclstGrdItem_DoubleClick(object sender, EventArgs e)
        {
            //DateTime firstDay = Convert.ToDateTime(DateTime.Parse(month + ", 1 " + year, CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
            //DateTime lastDay = Convert.ToDateTime(firstDay.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy"));
            //int LastDay = lastDay.Day;


            if (uclstGrdItem.SelectedRows.Count > 0)
            {
                uctxtItemName.Text = Utility.GetDgValue(uclstGrdItem, uctxtItemName, 0);
                uclstGrdItem.Visible = false;
                uctxtQty.Focus();
            }
        }
        private void uclstGrdItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtItemName.Text = Utility.GetDgValue(uclstGrdItem, uctxtItemName, 0);
                uclstGrdItem.Visible = false;
                uctxtQty.Focus();
            }
        }

        private void txtClassName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strDuplicate = "";
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 2)
                {
                    if (mstrOldClass != txtClassName.Text)
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_SAMPLE_CLASS_MASTER", "SAMPLE_CLASS", txtClassName.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            txtClassName.Text = "";
                            txtClassName.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_SAMPLE_CLASS_MASTER", "SAMPLE_CLASS", txtClassName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtClassName.Text = "";
                        txtClassName.Focus();
                        return;
                    }
                }

                uctxtItemName.Focus();

            }
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                if (uctxtItemName.Text == "")
                {
                    btnSave.Focus();
                    return;
                }
                if (uctxtItemName.Text != "")
                {
                    mAddStockItem(DG, uctxtItemName.Text, Utility.Val(uctxtQty.Text));
                    uctxtItemName.Text = "";
                    uctxtQty.Text = "";
                    uctxtItemName.Focus();
                }

            }
        }
        private void mAddStockItem(DataGridView dg, string strItemName, double dblQty)
        {
            int selRaw;
            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < dg.RowCount; j++)
            {
                if (dg[0, j].Value != null)
                {
                    strDown = dg[0, j].Value.ToString();
                }
                if (strItemName == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {

                dg.AllowUserToAddRows = true;
               

                selRaw = Convert.ToInt16(dg.RowCount.ToString());
                selRaw = selRaw - 1;
                dg.Rows.Add();
                dg[0, selRaw].Value = strItemName.ToString();
                dg[1, selRaw].Value = dblQty + " " + Utility.gGetBaseUOM(strComID, strItemName.ToString());
                
                dg.AllowUserToAddRows = false;
                
            }

        }

      
        private void DisplayFgQty(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {

                uctxtItemName.Text = tests[0].strItemName;


            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "All Item"
        private void mLoadAllItem()
        {
            int introw = 0;

            oogrp = invms.mloadAddStockItemFg(strComID, "").ToList();
            //oogrp = invms.gFillStockItemAll("").ToList();
            //var bil = (from tsfee in oogrp
            //           select new
            //           {
            //               tsfee.strItemName,
            //               tsfee.dblClsBalance
            //           }).ToList();

            ////uclstGrdItem.value
            //uclstGrdItem.DataSource = bil;
            //uclstGrdItem.Columns[1].Name = "Stock Item";
            //uclstGrdItem.Columns[2].Name = "Cls. Qty";

            if (oogrp.Count > 0)
            {
                foreach (StockItem ogrp in oogrp)
                {
                    uclstGrdItem.Rows.Add();
                    uclstGrdItem[0, introw].Value = ogrp.strItemName;
                    uclstGrdItem[1, introw].Value = ogrp.dblClsBalance + " " + ogrp.strUnit;

                    //if (introw % 2 == 0)
                    //{
                    //    uclstGrdItem.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    uclstGrdItem.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                uclstGrdItem.AllowUserToAddRows = false;
            }


        }
        #endregion
        private void frmSampleClass_Load(object sender, EventArgs e)
        {
            txtClassName.Select();
            this.DG.DefaultCellStyle.Font = new Font("verdana", 10);
            DG.AllowUserToAddRows = false;
            mLoadAllItem();
           
        }

        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "", strGrid = "", strDuplicate="";
            double dblQty = 0;
            if (txtClassName.Text =="")
            {
                MessageBox.Show("Cannot Empty");
                txtClassName.Focus();
                return;
            }
            for (int introw = 0; introw < DG.Rows.Count; introw++)
            {
                dblQty += dblQty +   Utility.Val(DG[1, introw].Value.ToString()) ;
            }
            if (dblQty < 0 || dblQty == 0)
            {
                MessageBox.Show("Item Cannot be Found or 0");
                uctxtItemName.Focus();
                return;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (m_action == 2)
            {
                if (mstrOldClass != txtClassName.Text)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_SAMPLE_CLASS_MASTER", "SAMPLE_CLASS", txtClassName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtClassName.Text = "";
                        txtClassName.Focus();
                        return;
                    }
                }
            }
            else
            {
                strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_SAMPLE_CLASS_MASTER", "SAMPLE_CLASS", txtClassName.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    txtClassName.Text = "";
                    txtClassName.Focus();
                    return;
                }
            }

            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        for (int introw = 0; introw < DG.Rows.Count; introw++)
                        {
                            string strUOM = Utility.gGetBaseUOM(strComID, DG[0, introw].Value.ToString());
                            strGrid += txtClassName.Text + "|" + DG[0, introw].Value.ToString() + "|" + DG[1, introw].Value.ToString() + "|" + strUOM + "~";
                        }
                        i = invms.mInsertSampleClass(strComID, txtClassName.Text, strGrid);
                        if (i != "1")
                        {
                            MessageBox.Show(i);
                        }
                        else
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Sample Class", txtClassName.Text,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            }
                            DG.Rows.Clear();
                            txtClassName.Text = "";
                            txtOldName.Text = "";
                            txtClassName.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

            if (m_action == 2)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Update?", "Upated Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        for (int introw = 0; introw < DG.Rows.Count; introw++)
                        {
                            string strUOM = Utility.gGetBaseUOM(strComID, DG[0, introw].Value.ToString());
                            strGrid += txtClassName.Text + "|" + DG[0, introw].Value.ToString() + "|" + DG[1, introw].Value.ToString() + "|" + strUOM + "~";
                        }
                        i = invms.mUpdateSampleClass(strComID, txtOldName.Text, txtClassName.Text, strGrid);
                        if (i != "1")
                        {

                            MessageBox.Show(i);
                        }
                        else
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Sample Class", txtClassName.Text,
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtSALES, "0001");
                            }
                            txtClassName.Text = "";
                            txtOldName.Text = "";
                            DG.Rows.Clear();
                            txtClassName.Focus();
                            m_action = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmSampleClassList objfrm = new frmSampleClassList();
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.onAddAllButtonClicked = new frmSampleClassList.AddAllClick(DisplayVoucherList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DG.Rows.RemoveAt(e.RowIndex);
            }

        }
        #endregion
        #region "Display"
        private void DisplayVoucherList(List<SampleClass> tests, object sender, EventArgs e)
        {
            try
            {
                int intrm = 0;
               
                txtClassName.Focus();
               
                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                DG.Rows.Clear();
                txtClassName.Text = tests[0].strClassName;
                txtOldName.Text = tests[0].strClassName;
                mstrOldClass = tests[0].strClassName;
                List<SampleClass> oRm = invms.mDisplaySampleClass(strComID, tests[0].strClassName).ToList();
                    {
                        if (oRm.Count > 0)
                        {
                                foreach (SampleClass ooRm in oRm)
                                {
                                    DG.Rows.Add();
                                    DG[0, intrm].Value = ooRm.strItemName;
                                    DG[1, intrm].Value = ooRm.dblQty  + " " + ooRm.strUOM;
                                  
                                    intrm += 1;
                                    DG.AllowUserToAddRows = false;
                                }
                        }
                    }

                }
              
        
              


          
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
        #endregion
        #region "Keyup"
        private void uctxtItemName_KeyUp(object sender, KeyEventArgs e)
         {

             try
             {

                 SearchListView(oogrp, uctxtItemName.Text);
             }
             catch (Exception ex)
             {

             }
         }
        #endregion
        #region "Search"
        private void SearchListView(IEnumerable<StockItem> tests, string searchString)
         {
             IEnumerable<StockItem> query;
             //if ((searchString.Length > 0))
             //{
             query = tests;

             //if (chkVoucheNo.Checked == true)
             //{
             if (searchString != "")
             {
                 query = tests.Where(x => x.strItemName.ToLower().Trim().Contains(searchString.ToLower().Trim()));
             }
             //}
             //else if (chkEntryby.Checked)
             //{
             //    query = (from test in tests
             //             where test.entryby.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
             //             select test);

             //}

             //else if (chkAmount.Checked)
             //{
             //    query = (from test in tests
             //             where test.dblNetDebitAmount.ToString().StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
             //             select test);
             //}
             uclstGrdItem.Rows.Clear();
             int i = 0;
             try
             {
                 foreach (StockItem tran in query)
                 {
                     uclstGrdItem.Rows.Add();
                     uclstGrdItem[0, i].Value = tran.strItemName;
                     uclstGrdItem[1, i].Value = tran.dblClsBalance + " " + tran.strUnit;
                     //if (i % 2 == 0)
                     //{
                     //    uclstGrdItem.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                     //}
                     //else
                     //{
                     //    uclstGrdItem.Rows[i].DefaultCellStyle.BackColor = Color.White;
                     //}
                     i += 1;
                 }


             }
             catch (Exception ex)
             {
                 ex.ToString();
             }
         }
        #endregion


    }
}
