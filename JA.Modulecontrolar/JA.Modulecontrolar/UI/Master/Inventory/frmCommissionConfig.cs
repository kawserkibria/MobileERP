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
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmCommissionConfig : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstBranch = new ListBox();
        private ListBox lstGroupConfig = new ListBox();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public int m_action { get; set; }
        private string  strOldGroup {get;set;}
        public int mSingleEntry { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        private string strComID { get; set; }
        public frmCommissionConfig()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtBranch.KeyDown += new KeyEventHandler(uctxtBranch_KeyDown);
            this.uctxtBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranch_KeyPress);
            this.uctxtBranch.TextChanged += new System.EventHandler(this.uctxtBranch_TextChanged);
            this.lstBranch.DoubleClick += new System.EventHandler(this.lstBranch_DoubleClick);
            this.uctxtBranch.GotFocus += new System.EventHandler(this.uctxtBranch_GotFocus);

            this.uctxtGroupConfig.KeyDown += new KeyEventHandler(uctxtGroupConfig_KeyDown);
            this.uctxtGroupConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtGroupConfig_KeyPress);
            this.uctxtGroupConfig.TextChanged += new System.EventHandler(this.uctxtGroupConfig_TextChanged);
            this.lstGroupConfig.DoubleClick += new System.EventHandler(this.lstGroupConfig_DoubleClick);
            this.uctxtGroupConfig.GotFocus += new System.EventHandler(this.uctxtGroupConfig_GotFocus);

            this.dteEffectiveDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteEffectiveDate_KeyPress);
            this.dteEffectiveDate.GotFocus += new System.EventHandler(this.dteEffectiveDate_GotFocus);
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            this.DG.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DG_CellValidating);
            this.DG.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DG_EditingControlShowing);
            this.DG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DG_KeyDown);
            this.DG.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DG_CellFormatting);

            Utility.CreateListBox(lstBranch, pnlMain, uctxtBranch);
            Utility.CreateListBox(lstGroupConfig, pnlMain, uctxtGroupConfig);

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
        #region "Keydown"
        private void DG_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
            
                e.SuppressKeyPress = true;
                int iColumn = DG.CurrentCell.ColumnIndex;
                int iRow = DG.CurrentCell.RowIndex;
                if (iColumn == DG.Columns.Count - 1)
                    btnSave.Focus();
                else
                    DG.CurrentCell = DG[iColumn + 1, iRow];
            
                 
            }
        }
        #endregion
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
        #endregion
        #region "User Define"
        private void DG_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //DG.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
            //DG.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DG.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }
        private void DG_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (DG.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
             
            }
            if (DG.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (DG.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }
        }
        private void DG_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (e.ColumnIndex == 0) // 1 should be your column index
            //{
            //    int i;
            //    double dblFormAmnt = 0, dblToAmnt = 0;
            //    if (DG[1, e.RowIndex].Value != null)
            //    {
            //        dblFormAmnt = Convert.ToDouble(Utility.Val(DG[0, e.RowIndex].Value.ToString()));
            //    }
            //    if (DG[1, e.RowIndex].Value != null)
            //    {
            //        dblToAmnt = Convert.ToDouble(Utility.Val(DG[1, e.RowIndex].Value.ToString()));
            //    }
            //    if (dblFormAmnt > dblToAmnt)
            //    {
            //        MessageBox.Show("f");
            //    }
            //    if (dblToAmnt > dblFormAmnt)
            //    {
            //        MessageBox.Show("c");
            //    }


                
            //}
            //if (e.ColumnIndex == 1) // 1 should be your column index
            //{
            //    int i;

            //    if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
            //    {
            //        e.Cancel = true;
            //        MessageBox.Show("please enter numeric");
            //    }
            //    else
            //    {
            //        // the input is numeric 
            //    }
            //}
        } 
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DG.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void dteEffectiveDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
            lstGroupConfig.Visible = false;
        }
        private void dteEffectiveDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                DG.Focus();
            }
            if (e.KeyChar==(char)Keys.Back)
            {
                uctxtGroupConfig.Focus();
            }
        }
        private void uctxtGroupConfig_TextChanged(object sender, EventArgs e)
        {
            lstGroupConfig.SelectedIndex = lstGroupConfig.FindString(uctxtGroupConfig.Text);
        }

        private void lstGroupConfig_DoubleClick(object sender, EventArgs e)
        {
            uctxtGroupConfig.Text = lstGroupConfig.Text;
            dteEffectiveDate.Focus();
        }

        private void uctxtGroupConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstGroupConfig.Items.Count > 0)
                {
                    uctxtGroupConfig.Text = lstGroupConfig.Text;
                }
                dteEffectiveDate.Focus();
            }
            if (e.KeyChar==(char)Keys.Back)
            {
                PriorSetFocusText(uctxtBranch, sender, e);
            }
        }
        private void uctxtGroupConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstGroupConfig.SelectedItem != null)
                {
                    lstGroupConfig.SelectedIndex = lstGroupConfig.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstGroupConfig.Items.Count - 1 > lstGroupConfig.SelectedIndex)
                {
                    lstGroupConfig.SelectedIndex = lstGroupConfig.SelectedIndex + 1;
                }
            }

        }

        private void uctxtGroupConfig_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = false;
            lstGroupConfig.Visible = true;
            lstGroupConfig.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }


        private void uctxtBranch_TextChanged(object sender, EventArgs e)
        {
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
        }

        private void lstBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranch.Text = lstBranch.Text;
            uctxtGroupConfig.Focus();
        }

        private void uctxtBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranch.Items.Count > 0)
                {
                    uctxtBranch.Text = lstBranch.Text;
                }
                uctxtGroupConfig.Focus();

            }
        }
        private void uctxtBranch_KeyDown(object sender, KeyEventArgs e)
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

        private void uctxtBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstBranch.Visible = true;
            lstGroupConfig.Visible = false;
            lstBranch.SelectedIndex = lstBranch.FindString(uctxtBranch.Text);
            
        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strmsg = "", strkey = "", strbranchID = "", strDG = "", strDuplicate ="";
            int intStatus=0;
            if (uctxtBranch.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtBranch.Focus();
                return;
            }
            if (uctxtGroupConfig.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtGroupConfig.Focus();
                return;
            }
            if (radNormal.Checked==true)
            {
                intStatus=0;
            }
            else
            {
                intStatus=1;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }

            double dblFormAmnt = 0, dblExFormAmnt=0, dblToAmnt = 0;
            for (int i = 0; i < DG.Rows.Count - 1; i++)
            {
                if (i > 0)
                {
                    dblFormAmnt = dblFormAmnt + 1;
                    dblToAmnt = Convert.ToDouble(Utility.Val(DG[1, i].Value.ToString()));
                }
                if (i > 0)
                {
                    if (dblFormAmnt != dblExFormAmnt)
                    {
                        MessageBox.Show("Amount Mismatch ! Please Check Your From Amount " + dblExFormAmnt);
                        DG.Focus();
                        return;
                    }

                    if (dblToAmnt < dblFormAmnt)
                    {
                        MessageBox.Show("Amount Mismatch ! Please Check Your To Amount " + dblToAmnt);
                        DG.Focus();
                        return;
                    }

                }
                dblFormAmnt = Convert.ToDouble(Utility.Val(DG[1, i].Value.ToString()));
                if (DG[0, i + 1].Value != null)
                {
                    dblExFormAmnt = Convert.ToDouble(Utility.Val(DG[0, i + 1].Value.ToString()));
                }
            }


            strbranchID = Utility.gstrGetBranchID(strComID, uctxtBranch.Text);
            strkey=strbranchID +uctxtGroupConfig.Text +dteEffectiveDate.Value.ToString("ddMMyyyy")+intStatus;

            for (int i = 0; i < DG.Rows.Count-1;i++ )
            {
                strDG = strDG + Utility.gCheckNull(DG[0, i].Value.ToString())+ "," + Utility.gCheckNull(DG[1,i].Value.ToString()) + "," + Utility.gCheckNull(DG[2,i].Value.ToString()) + "~";
            }

                if (m_action == 1)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_GROUP_COMMISSION_MASTER", "GROUP_COMMISSION_KEY", strkey);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show("Cannot Insert Duplicate Effective Date");
                        uctxtGroupConfig.Focus();
                        return;
                    }
                    var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponseInsert == DialogResult.Yes)
                    {
                        try
                        {
                            strmsg = invms.mInsertCommission(strComID, strkey, strbranchID, uctxtGroupConfig.Text, dteEffectiveDate.Text, intStatus, strDG);
                            if (strmsg == "Inseretd...")
                            {
                                if (Utility.gblnAccessControl)
                                {
                                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, uctxtGroupConfig.Text,
                                                                            1, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                                } 
                                uctxtBranch.Text = "";
                                uctxtGroupConfig.Text = "";
                                DG.Rows.Clear();
                                uctxtBranch.Focus();
                                
                            }
                        }
                        catch (Exception EX)
                        {
                            MessageBox.Show(strmsg);
                        }
                    }
                }
                else
                {
                    if (strOldGroup != uctxtGroupConfig.Text)
                    {
                        {
                            strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_GROUP_COMMISSION_MASTER", "GROUP_COMMISSION_KEY", strkey);
                            if (strDuplicate != "")
                            {
                                MessageBox.Show(strDuplicate);
                                uctxtGroupConfig.Text = "";
                                uctxtGroupConfig.Focus();
                                return;
                            }
                        }
                    }
                    var strResponseInsert = MessageBox.Show("Do You  want to Update?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponseInsert == DialogResult.Yes)
                    {
                        try
                        {
                            strmsg = invms.mUpdateCommisssion(strComID, txtOldKey.Text, strkey, strbranchID, uctxtGroupConfig.Text, dteEffectiveDate.Text, intStatus, strDG);
                            if (strmsg == "Updated...") 
                            {
                                if (Utility.gblnAccessControl)
                                {
                                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, uctxtGroupConfig.Text,
                                                                            2, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                                } 
                                uctxtBranch.Text = "";
                                uctxtGroupConfig.Text = "";
                                uctxtGroupConfig.Enabled = true;
                                uctxtBranch.Enabled = true;
                                DG.Rows.Clear();
                                uctxtBranch.Focus();
                                m_action = 1;
                            }
                        }
                        catch (Exception EX)
                        {
                            MessageBox.Show(strmsg);
                        }
                    }
                }

        }
       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmCommissionConfigList objfrm = new frmCommissionConfigList();
            objfrm.onAddAllButtonClicked = new frmCommissionConfigList.AddAllClick(DisplayList);
            objfrm.MdiParent = MdiParent;
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
            dteEffectiveDate.Focus();
        }
        #endregion
        #region "Load"
        private void frmCommissionConfig_Load(object sender, EventArgs e)
        {
            lstGroupConfig.Visible = false;
            lstBranch.Visible = false;
            uctxtBranch.Select();

            lstBranch.ValueMember = "BranchID";
            lstBranch.DisplayMember = "BranchName";
            lstBranch.DataSource = accms.mFillBranch(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();

            lstGroupConfig.DisplayMember = "GroupName";
            lstGroupConfig.ValueMember = "GroupName";
            lstGroupConfig.DataSource = invms.mFillStockGroupconfig(strComID).ToList();

            DG.Columns.Add(Utility.Create_Grid_Column("Amount From", "Amount From", 230, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Amount To", "Amount To", 230, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("%", "%", 100, true, DataGridViewContentAlignment.TopLeft, false));
            //DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, false));
            

        }
        #endregion
        #region "Display List"
        private void DisplayList(List<CommissionConfig> tests, object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                uctxtBranch.Text = "";
                uctxtGroupConfig.Text = "";
                uctxtBranch.Enabled = false;
                uctxtGroupConfig.Enabled = false;
                m_action = 2;
                DG.Rows.Clear();
                txtOldKey.Text = tests[0].strCommissinKey.ToString();
                List<CommissionConfig> ooconfig = invms.mDisplayCommissionconfig(strComID, tests[0].strCommissinKey.ToString()).ToList();
                if (ooconfig.Count > 0)
                {
                    foreach (CommissionConfig oconfig in ooconfig)
                    {
                        DG.Rows.Add();
                        uctxtBranch.Text = Utility.gstrGetBranchName(strComID, oconfig.BranchID);
                        strOldGroup = oconfig.GroupconfigName;
                        uctxtGroupConfig.Text = oconfig.GroupconfigName;
                        dteEffectiveDate.Text = oconfig.strEffectiveDate;
                        if (oconfig.strStatus == "0")
                        {
                            radNormal.Checked = true;
                        }
                        else
                        {
                            radStaff.Checked = true;
                        }
                        DG[0, i].Value = oconfig.dblAmountFrom;
                        DG[1, i].Value = oconfig.dblAmountTo;
                        DG[2, i].Value = oconfig.strPercent;
                        i += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void DG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DG.Rows.RemoveAt(e.RowIndex);
            }
            catch (Exception ex)
            {

            }
        }

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
         
        }

       


    }
}
