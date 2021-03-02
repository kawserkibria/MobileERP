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
using JA.Modulecontrolar.UI.Forms;
using JA.Modulecontrolar.UI.Accms.Forms;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmLedgerConfiguration : JA.Shared.UI.frmSmartFormStandard
    {
       
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public int m_action { get; set; }
        public long lngFormPriv { get; set; }
        private ListBox lstExpensLedger = new ListBox();
        private string strComID { get; set; }
        public frmLedgerConfiguration()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtLedgerNamee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLedgerNamee_KeyPress);
            this.uctxtLedgerNamee.GotFocus += new System.EventHandler(this.uctxtLedgerNamee_GotFocus);
            this.uctxtLedgerNamee.KeyDown += new KeyEventHandler(uctxtLedgerNamee_KeyDown);
            this.lstExpensLedger.DoubleClick += new System.EventHandler(this.lstExpensLedger_DoubleClick);
            this.uctxtLedgerNamee.TextChanged += new System.EventHandler(this.uctxtLedgerNamee_TextChanged);

            this.dtefromDate.GotFocus += new System.EventHandler(this.dtefromDate_GotFocus);
            this.dtefromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtefromDate_KeyPress);
            this.DG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DG_KeyDown);
            this.DG.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DG_EditingControlShowing);
            this.DG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DG_KeyPress);

            Utility.CreateListBoxHeight(lstExpensLedger, pnlMain, uctxtLedgerNamee,0,200);
        }

        #region "User Define Event"
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


        private void DG_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
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

        private void dtefromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
         
            if (e.KeyChar == (char)Keys.Return)
            {
           
                DG.Focus();
             
            }

        }
   
   

        private void dtefromDate_GotFocus(object sender, System.EventArgs e)
        {

            lstExpensLedger.Visible = false;

        }

        private void uctxtLedgerNamee_TextChanged(object sender, EventArgs e)
        {
            lstExpensLedger.SelectedIndex = lstExpensLedger.FindString(uctxtLedgerNamee.Text);
        }
        private void uctxtLedgerNamee_GotFocus(object sender, System.EventArgs e)
        {

            lstExpensLedger.Visible = true;
            

        }
        private void lstExpensLedger_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerNamee.Text = lstExpensLedger.Text;
            lstExpensLedger.Visible = false;
            dtefromDate.Focus();
        }


        private void uctxtLedgerNamee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstExpensLedger.Items.Count > 0)
                {
                    uctxtLedgerNamee.Text = lstExpensLedger.Text;

                    dtefromDate.Focus();
                    lstExpensLedger.Visible = false;
                }

                dtefromDate.Focus();
            }

        }
   
        private void uctxtLedgerNamee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstExpensLedger.SelectedItem != null)
                {
                    lstExpensLedger.SelectedIndex = lstExpensLedger.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstExpensLedger.Items.Count - 1 > lstExpensLedger.SelectedIndex)
                {
                    lstExpensLedger.SelectedIndex = lstExpensLedger.SelectedIndex + 1;
                }
            }

        }


#endregion
        #region "Display List"
        private void DisplayReqList(List<AccountsLedger> tests, object sender, EventArgs e)
        {
            try
            {
                foreach (AccountsLedger ts in tests)
                {
                    uctxtLedgerNamee.Text = ts.strLedgerName;
  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion
        private void frmLedgerConfiguration_Load(object sender, EventArgs e)
        {
            lstExpensLedger.ValueMember = "strLedgerName";
            lstExpensLedger.DisplayMember = "strLedgerName";
            lstExpensLedger.DataSource = accms.mFillLedgerList(strComID, 4).ToList();
            DGCloum();
   
        }

        private void DGCloum()
        {
                this.DG.DefaultCellStyle.Font = new Font("verdana", 10);
                DG.Columns.Add(Utility.Create_Grid_Column("From Amount", "From Amount", 250, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("To Amount", "To Amount", 250, true, DataGridViewContentAlignment.TopLeft, false));
                DG.Columns.Add(Utility.Create_Grid_Column("Get Comm.(%)", "Get Comm.(%)", 140, true, DataGridViewContentAlignment.TopLeft, false));
        }

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
         
            frmLedgerConfigurationList objfrm = new frmLedgerConfigurationList();
            objfrm.onAddAllButtonClicked = new frmLedgerConfigurationList.AddAllClick(DisplayList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
            dtefromDate.Focus();
            
        }

        #region "Display List"
        public void DisplayList(List<AccountsLedger> tests, object sender, EventArgs e)
        {

           
            try
            {
                int i = 0;
                string mstrConfiglkey = "";
                string strledgernamessss = "";

                m_action = 2;
                uctxtLedgerNamee.Enabled = false;
                StrConfigkey.Text  = tests[0].strConfigkey.ToString();
                uctxtLedgerNamee.Text = tests[0].strLedgerName.ToString();
                dtefromDate.Value = Convert.ToDateTime ( tests[0].strEfectDate.ToString());
                DG.Rows.Clear();
                List<AccountsLedger> ooconfig = accms.mDisplayLedgerConfig(strComID, tests[0].strConfigkey.ToString()).ToList();
                if (ooconfig.Count > 0)
                {
                    foreach (AccountsLedger oconfig in ooconfig)
                    {
                        DG.Rows.Add();
                        DG[0, i].Value = oconfig.dblFromAmt;
                        DG[1, i].Value = oconfig.dblToAmt;
                        DG[2, i].Value = oconfig.dblConfigPer;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveeupdate();
        }

        private void saveeupdate()
        {

            string strmsg = "", strkey = "", strDG = "";
            long strVoucherType = '4';

            if (uctxtLedgerNamee.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtLedgerNamee.Focus();
                return;
            }



            strkey = uctxtLedgerNamee.Text + dtefromDate.Value.ToString("ddMMyyyy");

            for (int i = 0; i < DG.Rows.Count - 1; i++)
            {
                strDG = strDG + Utility.gCheckNull(DG[0, i].Value.ToString()) + "," + Utility.gCheckNull(DG[1, i].Value.ToString()) + "," + Utility.gCheckNull(DG[2, i].Value.ToString()) + "~";
            }

            if (m_action == 1)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 1))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {

                        strmsg = accms.mInsertExpenseLedger(strComID, strkey, uctxtLedgerNamee.Text, dtefromDate.Text, strVoucherType, strDG);
                        if (strmsg == "Inseretd...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Ledger Configuration", uctxtLedgerNamee.Text,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                            } 
                            uctxtLedgerNamee.Text = "";
                            DG.Rows.Clear();
                            uctxtLedgerNamee.Focus();

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
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {

                        string i = accms.DeleteLedgerConfig(strComID, StrConfigkey.Text);
                        strmsg = accms.mInsertExpenseLedger(strComID, strkey, uctxtLedgerNamee.Text, dtefromDate.Text, strVoucherType, strDG);
                        if (strmsg == "Inseretd...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Ledger Configuration", uctxtLedgerNamee.Text,
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                            } 
                            uctxtLedgerNamee.Text = "";
                            DG.Rows.Clear();
                            StrConfigkey.Text = "";
                            uctxtLedgerNamee.Enabled = true;
                            //uctxtLedgerNamee.Focus();
                            //uctxtLedgerNamee.Select();
                            frmLedgerConfigurationList objfrm = new frmLedgerConfigurationList();
                            objfrm.onAddAllButtonClicked = new frmLedgerConfigurationList.AddAllClick(DisplayList);
                            objfrm.Show();
                            objfrm.MdiParent = this.MdiParent;
                            dtefromDate.Focus();
                        }
                        m_action = 1;
                       
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(strmsg);
                    }
                }
            }

        }

        private void DG_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    if (DG[e.ColumnIndex, e.RowIndex].Value == "")
            //    {
            //            btnSave.Focus();
            //    }
            //    return;
            //}
        }
    }
}