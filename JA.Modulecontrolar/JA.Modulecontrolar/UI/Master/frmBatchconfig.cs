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

namespace JA.Modulecontrolar.UI.Master
{
    public partial class frmBatchconfig : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        private const string mcGROUP_PREFIX = "G_";
        private const string mcLEDGER_PREFIX = "L_";
        private string mstrOldNo { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public int m_action { get; set; }
        public int mSingleEntry { get; set; }
        private ListBox lstPartyName = new ListBox();
        private string strComID { get; set; }
        public frmBatchconfig()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtBatchNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatchNo_KeyPress);
            this.uctxtBatchNo.GotFocus += new System.EventHandler(this.uctxtBatchNo_GotFocus);
            this.uctxtBatchNo.TextChanged += new System.EventHandler(this.uctxtBatchNo_TextChanged);

            this.uctxtBatchSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatchSize_KeyPress);
            this.uctxtBatchSize.GotFocus += new System.EventHandler(this.uctxtBatchSize_GotFocus);

            this.dteExpireDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteExpireDate_KeyPress);
            this.dteExpireDate.GotFocus += new System.EventHandler(this.dteExpireDate_GotFocus);

            this.mskManufactureDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(mskManufactureDate_KeyPress);
            this.mskManufactureDate.GotFocus += new System.EventHandler(this.mskManufactureDate_GotFocus);

            this.dteStartDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteStartDate_KeyPress);
            this.dteStartDate.GotFocus += new System.EventHandler(this.dteStartDate_GotFocus);

            this.dteEnddate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteEnddate_KeyPress);
            this.dteEnddate.GotFocus += new System.EventHandler(this.dteEnddate_GotFocus);

            this.cboStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboStatus_KeyPress);
            this.cboStatus.GotFocus += new System.EventHandler(this.cboStatus_GotFocus);

            this.uctxtComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtComments_KeyPress);

            this.uctxtPartyName.KeyDown += new KeyEventHandler(uctxtPartyName_KeyDown);
            this.uctxtPartyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPartyName_KeyPress);
            this.uctxtPartyName.TextChanged += new System.EventHandler(this.uctxtPartyName_TextChanged);
            this.lstPartyName.DoubleClick += new System.EventHandler(this.lstPartyName_DoubleClick);
            this.uctxtPartyName.GotFocus += new System.EventHandler(this.uctxtPartyName_GotFocus);

            Utility.CreateListBox(lstPartyName, pnlMain, uctxtPartyName);
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
        #region "PriorSetFocus"
        private void PriorSetFocusText(TextBox txtbox, object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Back)
            {
                if (txtbox.SelectionLength > 0)
                {
                    txtbox.SelectionLength = 0;

                    this.SelectNextControl((Control)sender, false, true, true, true);
                }
                else
                {
                    if ((e.KeyChar == (char)Keys.Back) & (((Control)sender).Text.Length == 0))
                    {

                        this.SelectNextControl((Control)sender, false, true, true, true);
                    }
                }
            }

        }
        private void PriorSetFocusCombo(ComboBox txtbox, object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                if (txtbox.SelectionLength > 0)
                {
                    txtbox.SelectionLength = 0;

                    this.SelectNextControl((Control)sender, false, true, true, true);
                }
                else
                {
                    if ((e.KeyChar == (char)Keys.Back) & (((Control)sender).Text.Length == 0))
                    {

                        this.SelectNextControl((Control)sender, false, true, true, true);
                    }
                }
            }
        }
        #endregion
        #region "User Define"
        private void uctxtBatchNo_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtBatchNo.SelectionStart;
            uctxtBatchNo.Text = Utility.gmakeProperCase(uctxtBatchNo.Text);
            uctxtBatchNo.SelectionStart = x;
        }
        private void dteExpireDate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
        }
        private void dteExpireDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteExpireDate.Text = Utility.ctrlDateFormat(dteExpireDate.Text);
                dteStartDate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBatchSize, sender, e);
            }
        }
        private void mskManufactureDate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
        }
        private void mskManufactureDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                mskManufactureDate.Text = Utility.ctrlDateFormat(mskManufactureDate.Text);
                dteExpireDate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBatchSize, sender, e);
            }
        }
        private void uctxtBatchSize_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
        }
        private void uctxtBatchSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                mskManufactureDate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtPartyName, sender, e);
            }
        }
        private void cboStatus_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
        }
        private void dteEnddate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
        }
        private void dteStartDate_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
        }
        private void uctxtBatchNo_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = false;
        }
        private void uctxtPartyName_GotFocus(object sender, System.EventArgs e)
        {
            lstPartyName.Visible = true;
            lstPartyName.SelectedIndex = lstPartyName.FindString(uctxtPartyName.Text);
        }
        private void uctxtPartyName_TextChanged(object sender, EventArgs e)
        {
            lstPartyName.SelectedIndex = lstPartyName.FindString(uctxtPartyName.Text);
        }

        private void lstPartyName_DoubleClick(object sender, EventArgs e)
        {
            uctxtPartyName.Text = lstPartyName.Text;
            uctxtBatchSize.Focus();
        }

        private void uctxtPartyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstPartyName.Items.Count > 0)
                {
                    uctxtPartyName.Text = lstPartyName.Text;
                }
                uctxtBatchSize.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusText(uctxtBatchNo, sender, e);
            }
        }
        private void uctxtPartyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstPartyName.SelectedItem != null)
                {
                    lstPartyName.SelectedIndex = lstPartyName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstPartyName.Items.Count - 1 > lstPartyName.SelectedIndex)
                {
                    lstPartyName.SelectedIndex = lstPartyName.SelectedIndex + 1;
                }
            }

        }

        private void uctxtComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();

            }
        }
        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                PriorSetFocusCombo(cboStatus, sender, e);
            }
        }
        private void dteEnddate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteEnddate.Text = Utility.ctrlDateFormat(dteEnddate.Text);
                cboStatus.Focus();
            }
          
        }
        private void dteStartDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dteStartDate.Text = Utility.ctrlDateFormat(dteStartDate.Text);
                dteEnddate.Focus();
            }
        }
        private void uctxtBatchNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtBatchSize.Focus();

            }
        }
        #endregion

        private void frmBatchconfig_Load(object sender, EventArgs e)
        {
            uctxtBatchNo.Focus();
            lstPartyName.Visible = false;

            dteStartDate.Text = Utility.ctrlDateFormat(DateTime.Now.ToShortDateString());
            dteEnddate.Text = Utility.ctrlDateFormat(DateTime.Now.ToShortDateString());
            mskManufactureDate.Text = Utility.ctrlDateFormat(DateTime.Now.ToShortDateString());
            dteExpireDate.Text = Utility.ctrlDateFormat(DateTime.Now.ToShortDateString());


            lstPartyName.DisplayMember = "value";
            lstPartyName.ValueMember = "Key";
            lstPartyName.DataSource = new BindingSource(invms.gFillSalesLedgerbatch(strComID,(long)Utility.GR_GROUP_TYPE.grCUSTOMER), null);

            cboYear.Text = DateTime.Now.ToString("yyyy");
          

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

       
        private void mClear()
        {
            uctxtBatchNo.Text = "";
            uctxtPartyName.Text = "";
            uctxtBatchSize.Text = "";
            mskManufactureDate.Text = "";
            cboStatus.Text = "Active";
            uctxtPartyName.Text = "";
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            cboYear.Text = DateTime.Now.ToString("yyyy");
          
            uctxtBatchNo.ReadOnly = false;
            uctxtBatchNo.Focus();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "",strExpireDate,strPartyName="",strMnanuDate="",strStartDate="",strEndDate="",strBatch="";
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            
            if (uctxtBatchNo.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtBatchNo.Focus();
                return;
            }
            if (cboStatus.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                cboStatus.Focus();
                return;
            }
            if (uctxtBatchSize.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtBatchSize.Focus();
                return;
            }
            if (dteExpireDate.Text == "")
            {
                strExpireDate = "";
            }
            else
            {
                strExpireDate = dteExpireDate.Text;
            }
            if (dteStartDate.Text == "")
            {
                strStartDate = "";
            }
            else
            {
                strStartDate = dteStartDate.Text;
            }

            if (dteEnddate.Text == "")
            {
                strEndDate = "";
            }
            else
            {
                strEndDate = dteEnddate.Text;
            }

            if (mskManufactureDate.Text == "")
            {
                strMnanuDate = "";
            }
            else
            {
                strMnanuDate = mskManufactureDate.Text;
            }

         
            strPartyName = "";
            strBatch = (uctxtBatch1.Text + uctxtBatchNo.Text).ToUpper();
           
            if (strBatch.Substring(3,1)=="")
            {
                MessageBox.Show("Cannot Save,Rate cannot be found");
                return;
            }
            
            if (m_action == 1)
            {
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_BATCH", "INV_LOG_NO", uctxtBatchNo.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    uctxtBatchNo.Text = "";
                    uctxtBatchNo.Focus();
                    return;
                }
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {

                        i = invms.mSavebatch(strComID, strBatch, strStartDate, strEndDate, strExpireDate,
                                            strPartyName, Utility.gCheckNull(cboStatus.Text),"",Utility.gCheckNull(uctxtBatchSize.Text),strMnanuDate);

                        if (i == "Inserted...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, strFormName,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                            }
                            mClear();
                        }
                        else
                        {
                            MessageBox.Show(i.ToString());
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
               
                    {
                        if (mstrOldNo != uctxtBatchNo.Text)
                        {
                            string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_BATCH", "INV_LOG_NO", uctxtBatchNo.Text);
                            if (strDuplicate != "")
                            {
                                MessageBox.Show(strDuplicate);
                                uctxtBatchNo.Text = mstrOldNo;
                                uctxtBatchNo.Focus();
                                return;
                            }
                        }

                    var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponseInsert == DialogResult.Yes)
                    {
                        try
                        {
                            i = invms.mSUpdatebatch(strComID, mstrOldNo, strBatch, dteStartDate.Text, dteEnddate.Text,
                                                    strExpireDate, strPartyName, Utility.gCheckNull(cboStatus.Text), "", Utility.gCheckNull(uctxtBatchSize.Text), strMnanuDate);

                            if (i == "Updated...")
                            {
                                if (Utility.gblnAccessControl)
                                {
                                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, strFormName,
                                                                            2, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                                }
                                mClear();

                            }
                            else
                            {
                                MessageBox.Show(i.ToString());
                            }
                        }


                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }



                }
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboYear.Text = DateTime.Now.ToString("yyyy");
            //mLoadMonthTree(DateTime.Now.ToString("yyyy"));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmBatchConfigList objfrm = new frmBatchConfigList();
            objfrm.onAddAllButtonClicked = new frmBatchConfigList.AddAllClick(DisplayVoucherList);
            objfrm.MdiParent = MdiParent;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }

        private void DisplayVoucherList(List<Batch> tests, object sender, EventArgs e)
        {
            try
            {
                mClear();
                m_action = 2;
                uctxtBatchNo.ReadOnly = true;
                txtSlNo.Text = tests[0].lngSlno.ToString();
                List<Batch> oogrp = invms.mDisPlaybatch(strComID, Convert.ToInt64(tests[0].lngSlno), "").ToList();
                if (oogrp.Count > 0)
                {
                    foreach (Batch ogrp in oogrp)
                    {
                        mstrOldNo = ogrp.strLogNo;
                        uctxtBatchNo.Text = ogrp.strLogNo;
                        dteStartDate.Text = ogrp.strStartDate;
                        dteEnddate.Text = ogrp.strEndDate;
                        dteExpireDate.Text = ogrp.strExpireDate;
                        uctxtBatchNo.Text = ogrp.strLogNo;
                        if (ogrp.strLedgerName != "")
                        {
                            uctxtPartyName.Text = ogrp.strLedgerName;
                        }
                        else
                        {
                            uctxtPartyName.Text = Utility.gcEND_OF_LIST;
                        }
                        cboStatus.Text = ogrp.strStatus;
                        uctxtBatchSize.Text = ogrp.lngLogSize.ToString();
                        mskManufactureDate.Text = ogrp.strManuDate;
                        m_action = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            //frmBatchTree objfrm = new frmBatchTree();
            //objfrm.strYear = cboYear.Text;
            //objfrm.intConvertFg = 0;
            //objfrm.Show();
            //objfrm.MdiParent = MdiParent;
        }

        private void btnSerach1_Click(object sender, EventArgs e)
        {
            //frmAllReferance objfrm = new frmAllReferance();
            //objfrm.lngVtype = 8888;
            //objfrm.onAddAllButtonClickedFG = new frmAllReferance.AddAllClickFG(DisplayVoucherListFG);
            //objfrm.Show();
            //objfrm.MdiParent = this.MdiParent;
            //uctxtBatchNo.Focus();
        }
        private void DisplayVoucherListFG(List<StockItem> tests, object sender, EventArgs e)
        {
           
                uctxtBatch1.Text = DateTime.Now.ToString("yy")+ "/" + tests[0].strItemName;
                uctxtBatchNo.Focus();
           

        }
    }
}
