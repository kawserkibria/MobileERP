using Dutility;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.DReport.Accms.ParameterForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmAutoReplacement : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient(); SPWOIS objWois = new SPWOIS();
        private string strComID { get; set; }
        private ListBox lstLedgerName = new ListBox();
        private ListBox lstXLedgerName = new ListBox();
        public frmAutoReplacement()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

            this.uctxtLedgerName.KeyDown += new KeyEventHandler(uctxtLedgerName_KeyDown);
            this.uctxtLedgerName.TextChanged += new System.EventHandler(this.uctxtLedgerName_TextChanged);
            this.uctxtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtLedgerName_KeyPress);
            this.uctxtLedgerName.GotFocus += new System.EventHandler(this.uctxtLedgerName_GotFocus);
            this.lstLedgerName.DoubleClick += new System.EventHandler(this.lstLedgerName_DoubleClick);

            this.uctxtXMpoLedger.KeyDown += new KeyEventHandler(uctxtXMpoLedger_KeyDown);
            this.uctxtXMpoLedger.TextChanged += new System.EventHandler(this.uctxtXMpoLedger_TextChanged);
            this.uctxtXMpoLedger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uctxtXMpoLedger_KeyPress);
            this.uctxtXMpoLedger.GotFocus += new System.EventHandler(this.uctxtXMpoLedger_GotFocus);
            this.lstXLedgerName.DoubleClick += new System.EventHandler(this.lstXLedgerName_DoubleClick);


            Utility.CreateListBox(lstLedgerName, pnlMain, uctxtLedgerName);
            Utility.CreateListBox(lstXLedgerName, pnlMain, uctxtXMpoLedger);

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

        private void uctxtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLedgerName.SelectedItem != null)
                {
                    lstLedgerName.SelectedIndex = lstLedgerName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLedgerName.Items.Count - 1 > lstLedgerName.SelectedIndex)
                {
                    lstLedgerName.SelectedIndex = lstLedgerName.SelectedIndex + 1;
                }
            }


        }

        private void uctxtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerName.Items.Count > 0)
                {
                    uctxtLedgerName.Text = lstLedgerName.Text;
                }
                uctxtXMpoLedger.Focus();

            }
        }
        private void uctxtLedgerName_TextChanged(object sender, EventArgs e)
        {
            //int x = uctxtLedgerName.SelectionStart;
            //uctxtLedgerName.Text = Utility.gmakeProperCase(uctxtLedgerName.Text);
            //uctxtLedgerName.SelectionStart = x;
            lstLedgerName.SelectedIndex = lstLedgerName.FindString(uctxtLedgerName.Text);
        }
        private void uctxtLedgerName_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerName.Visible = true;
            lstXLedgerName.Visible = false;
        }
        private void lstLedgerName_DoubleClick(object sender, EventArgs e)
        {
            uctxtLedgerName.Text = lstLedgerName.Text;
            lstLedgerName.Visible = false;
            uctxtXMpoLedger.Focus();
        }

        private void uctxtXMpoLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstXLedgerName.SelectedItem != null)
                {
                    lstXLedgerName.SelectedIndex = lstXLedgerName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstXLedgerName.Items.Count - 1 > lstXLedgerName.SelectedIndex)
                {
                    lstXLedgerName.SelectedIndex = lstXLedgerName.SelectedIndex + 1;
                }
            }


        }

        private void uctxtXMpoLedger_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLedgerName.Items.Count > 0)
                {
                    uctxtXMpoLedger.Text = lstXLedgerName.Text;
                }
                lstXLedgerName.Visible = false;
                btnSave.Focus();

            }
        }
        private void uctxtXMpoLedger_TextChanged(object sender, EventArgs e)
        {
            //int x = uctxtXMpoLedger.SelectionStart;
            //uctxtXMpoLedger.Text = Utility.gmakeProperCase(uctxtXMpoLedger.Text);
            //uctxtXMpoLedger.SelectionStart = x;
            lstXLedgerName.SelectedIndex = lstXLedgerName.FindString(uctxtXMpoLedger.Text);
        }
        private void uctxtXMpoLedger_GotFocus(object sender, System.EventArgs e)
        {
            lstLedgerName.Visible = false;
            lstXLedgerName.Visible = true;
        }
        private void lstXLedgerName_DoubleClick(object sender, EventArgs e)
        {
            uctxtXMpoLedger.Text = lstXLedgerName.Text;
            lstXLedgerName.Visible = false;
            btnSave.Focus();
        }

        private void frmAutoReplacemenr_Load(object sender, EventArgs e)
        {
            lstXLedgerName.ValueMember = "strLedgerName";
            lstXLedgerName.DisplayMember = "strmerzeString";
            lstXLedgerName.DataSource = accms.mFillLedgerListNew(strComID, 202, 1, "", 1).ToList();

            lstLedgerName.ValueMember = "strLedgerName";
            lstLedgerName.DisplayMember = "strmerzeString";
            lstLedgerName.DataSource = accms.mFillLedgerListNew(strComID, 202, 0, "", 1).ToList();
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSQL, strXLedger, mstrOldLedger;
             var strResponseInsert = MessageBox.Show("Do You Want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (strResponseInsert == DialogResult.Yes)
             {
                 string connstring = Utility.SQLConnstringComSwitch(strComID);
                 using (SqlConnection gcnMain = new SqlConnection(connstring))
                 {
                     SqlDataReader dr;
                     if (gcnMain.State == ConnectionState.Open)
                     {
                         gcnMain.Close();
                     }
                     gcnMain.Open();
                     if (uctxtXMpoLedger.Text =="")
                     {
                         MessageBox.Show("Cannot be Empty");
                         uctxtXMpoLedger.Focus();
                         return;
                     }
                     if (uctxtLedgerName.Text == "")
                     {
                         MessageBox.Show("Cannot be Empty");
                         uctxtLedgerName.Focus();
                         return;
                     }
                     SqlTransaction myTrans;
                     myTrans = gcnMain.BeginTransaction();
                     SqlCommand cmdInsert = new SqlCommand();
                     cmdInsert.Connection = gcnMain;
                     cmdInsert.Transaction = myTrans;
                     mstrOldLedger  = lstLedgerName.SelectedValue.ToString().Replace("'", "''");
                     strXLedger = lstXLedgerName.SelectedValue.ToString().Replace("'", "''");


                     //strSQL = "UPDATE ACC_VOUCHER SET LEDGER_NAME='" + strXLedger + "' ";
                     //strSQL = strSQL + "WHERE LEDGER_NAME = '" + mstrOldLedger.Replace("'", "''") + "' ";
                     //strSQL = strSQL + "AND  AUTOJV=1 ";
                     //cmdInsert.CommandText = strSQL;
                     //cmdInsert.ExecuteNonQuery();

                     //strSQL = "UPDATE ACC_VOUCHER SET VOUCHER_REVERSE_LEDGER='" + strXLedger + "' ";
                     //strSQL = strSQL + "WHERE VOUCHER_REVERSE_LEDGER = '" + mstrOldLedger.Replace("'", "' '") + "' ";
                     //strSQL = strSQL + "AND  AUTOJV=1 ";
                     //cmdInsert.CommandText = strSQL;
                     //cmdInsert.ExecuteNonQuery();


                     //strSQL = "UPDATE ACC_VOUCHER SET REVERSE_LEDGER1='" + strXLedger + "' ";
                     //strSQL = strSQL + "WHERE REVERSE_LEDGER1 = '" + mstrOldLedger.Replace("'", "''") + "' ";
                     //strSQL = strSQL + "AND  AUTOJV=1 ";
                     //cmdInsert.CommandText = strSQL;
                     //cmdInsert.ExecuteNonQuery();

                     //strSQL = "UPDATE ACC_COMPANY_VOUCHER SET LEDGER_NAME='" + strXLedger + "' ";
                     //strSQL = strSQL + "WHERE LEDGER_NAME = '" + mstrOldLedger.Replace("'", "''") + "' ";
                     //strSQL = strSQL + "AND  AUTOJV=1 ";
                     //cmdInsert.CommandText = strSQL;
                     //cmdInsert.ExecuteNonQuery();
                     strSQL = "UPDATE ACC_VOUCHER SET REPLAMENT='" + strXLedger + "' ";
                     strSQL = strSQL + "WHERE REVERSE_LEDGER1 = '" + mstrOldLedger.Replace("'", "''") + "' ";
                     strSQL = strSQL + "AND  AUTOJV=1 ";
                     cmdInsert.CommandText = strSQL;
                     cmdInsert.ExecuteNonQuery();

                     strSQL = "UPDATE ACC_VOUCHER SET REPLAMENT='" + strXLedger + "' ";
                     strSQL = strSQL + "WHERE REVERSE_LEDGER1 IS NULL ";
                     strSQL = strSQL + "AND  AUTOJV=1 ";
                     cmdInsert.CommandText = strSQL;
                     cmdInsert.ExecuteNonQuery();

                     cmdInsert.Transaction.Commit();
                     MessageBox.Show("Update Successfully..");
                     uctxtLedgerName.Text = "";
                     uctxtXMpoLedger.Text = "";
                     uctxtLedgerName.Focus();

                 }
             }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            string strSQL, strXLedger, mstrOldLedger;
            var strResponseInsert = MessageBox.Show("Do You Want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (strResponseInsert == DialogResult.Yes)
            {
                string connstring = Utility.SQLConnstringComSwitch(strComID);
                using (SqlConnection gcnMain = new SqlConnection(connstring))
                {

                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }
                    gcnMain.Open();
                    if (uctxtXMpoLedger.Text == "")
                    {
                        MessageBox.Show("Cannot be Empty");
                        uctxtXMpoLedger.Focus();
                        return;
                    }
                    if (uctxtLedgerName.Text == "")
                    {
                        MessageBox.Show("Cannot be Empty");
                        uctxtLedgerName.Focus();
                        return;
                    }

                    SqlCommand cmdInsert = new SqlCommand();
                    cmdInsert.Connection = gcnMain;

                    mstrOldLedger = lstLedgerName.SelectedValue.ToString().Replace("'", "''");
                    strXLedger = lstXLedgerName.SelectedValue.ToString().Replace("'", "''");

                    strSQL = "UPDATE ACC_VOUCHER set REPLAMENT=REVERSE_LEDGER1 where REVERSE_LEDGER1 IS NOT NULL ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "UPDATE ACC_VOUCHER SET REVERSE_LEDGER1='" + mstrOldLedger + "' ";
                    strSQL = strSQL + "WHERE REVERSE_LEDGER1 = '" + strXLedger.Replace("'", "''") + "' ";
                    strSQL = strSQL + "AND  AUTOJV=1 ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    MessageBox.Show("Undo Successfully..");
                    uctxtLedgerName.Text = "";
                    uctxtXMpoLedger.Text = "";
                    uctxtLedgerName.Focus();

                }
            }
        }

        

     
    }
}
