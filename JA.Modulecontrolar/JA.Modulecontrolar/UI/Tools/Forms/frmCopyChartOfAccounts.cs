using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;
using JA.Modulecontrolar;
using Dutility;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;
using System.Linq;
using JA.Modulecontrolar.JACCMS;


namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmCopyChartOfAccounts : Form
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();

        private ListBox lstCopyChartOfAcc = new ListBox();
        private ListBox lstuserControl = new ListBox();
        private ListBox lstMultipleBranch = new ListBox();
        public int intCallType;
        private byte[] _imageData;
         private string mstrCurSymbol;
        private string mstrCurFormallName   ;
        private string mstrCurString        ;
        private long mlngCurDecimalPl      ;
        private string strComID { get; set; }
        public frmCopyChartOfAccounts()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtCompanyName.GotFocus += new System.EventHandler(this.txtCompanyName_GotFocus);
            this.txtAddress1.GotFocus += new System.EventHandler(this.txtAddress1_GotFocus);
            this.txtAddress2.GotFocus += new System.EventHandler(this.txtAddress2_GotFocus);
            this.txtCountry.GotFocus += new System.EventHandler(this.txtCountry_GotFocus);
            this.txtFax.GotFocus += new System.EventHandler(this.txtFax_GotFocus);
            this.txtPhone.GotFocus += new System.EventHandler(this.txtPhone_GotFocus);
            this.dtefinancialform.GotFocus += new System.EventHandler(this.dtefinancialform_GotFocus);
            this.dteFinanicalTo.GotFocus += new System.EventHandler(this.dteFinanicalTo_GotFocus);
            this.txtMultipleBranch.GotFocus += new System.EventHandler(this.txtMultipleBranch_GotFocus);
            this.txtUserControl.GotFocus += new System.EventHandler(this.txtUserControl_GotFocus);
            this.txtComments.GotFocus += new System.EventHandler(this.txtComments_GotFocus);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtPhone_KeyPress);
            this.txtUserControl.KeyDown += new KeyEventHandler(txtUserControl_KeyDown);
            this.txtUserControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUserControl_KeyPress);
            this.txtMultipleBranch.KeyDown += new KeyEventHandler(txtMultipleBranch_KeyDown);
            this.txtMultipleBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtMultipleBranch_KeyPress);
            this.txtBusinessType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBusinessType_KeyPress);
            this.lstMultipleBranch.DoubleClick += new System.EventHandler(this.lstMultipleBranch_DoubleClick);
            this.lstuserControl.DoubleClick += new System.EventHandler(this.lstuserControl_DoubleClick);
            this.txtMultipleBranch.TextChanged += new System.EventHandler(this.txtMultipleBranch_TextChanged);
            this.txtUserControl.TextChanged += new System.EventHandler(this.txtUserControl_TextChanged);
            this.uctxtAdministrator.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAdministrator_KeyPress);
            this.uctxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPassword_KeyPress);
            this.uctxtRetypePassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRetypePassword_KeyPress);
            this.txtCopyChartOfAccount.KeyDown += new KeyEventHandler(txtCopyChartOfAccount_KeyDown);
            this.txtCopyChartOfAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCopyChartOfAccount_KeyPress);
            this.txtCopyChartOfAccount.GotFocus += new System.EventHandler(this.txtCopyChartOfAccount_GotFocus);
            this.lstCopyChartOfAcc.DoubleClick += new System.EventHandler(this.lstCopyChartOfAcc_DoubleClick);
            //this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            this.btnAccessCancel.Click += new System.EventHandler(this.btnAccessCancel_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            Utility.CreateListBox(lstuserControl, panel1, txtUserControl);
            Utility.CreateListBox(lstMultipleBranch, panel1, txtMultipleBranch);
            Utility.CreateListBox(lstCopyChartOfAcc, panel1, txtMultipleBranch);
            TabChange();
        }


        #region "User Define Event"
        private void txtCopyChartOfAccount_GotFocus(object sender, System.EventArgs e)
        {
            lstuserControl.Visible = false;
            lstMultipleBranch.Visible = false;
            lstCopyChartOfAcc.Visible = true;
            lstCopyChartOfAcc.Top = 245;
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtCopyChartOfAccount.Focus();
            }
        }
        private void txtCopyChartOfAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCopyChartOfAcc.Items.Count > 0)
                {
                    txtCopyChartOfAccount.Text = lstCopyChartOfAcc.Text;
                }
                txtBusinessType.Focus();
                lstCopyChartOfAcc.Visible = false;
            }
        }
        private void txtCopyChartOfAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCopyChartOfAcc.SelectedItem != null)
                {
                    lstCopyChartOfAcc.SelectedIndex = lstCopyChartOfAcc.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCopyChartOfAcc.Items.Count - 1 > lstCopyChartOfAcc.SelectedIndex)
                {
                    lstCopyChartOfAcc.SelectedIndex = lstCopyChartOfAcc.SelectedIndex + 1;
                }
            }

        }
        private void btnAccessCancel_Click(object sender, EventArgs e)
        {
            panelAcessControl.Visible = false;
            txtUserControl.Focus();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (uctxtAdministrator.Text.Trim().Length == 0)
            {
                MessageBox.Show("Administrator must be entered");
                uctxtAdministrator.Focus();
                return;
            }
            if (uctxtPassword.Text.Trim().Length < 6)
            {
                MessageBox.Show("Password Length more than 6");
                uctxtPassword.Focus();
                return;
            }
            if (uctxtPassword.Text.Trim() != uctxtRetypePassword.Text.Trim())
            {
                MessageBox.Show("Mismatch Password");
                uctxtPassword.Focus();
                return;
            }


        }
        private void uctxtAdministrator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtPassword.Focus();

            }
        }
        private void uctxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtRetypePassword.Focus();

            }
        }
        private void uctxtRetypePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                panelAcessControl.Visible = false;
                txtComments.Focus();

            }
        }
        private void txtMultipleBranch_TextChanged(object sender, EventArgs e)
        {
            lstMultipleBranch.SelectedIndex = lstMultipleBranch.FindString(txtMultipleBranch.Text);
        }
        private void txtUserControl_TextChanged(object sender, EventArgs e)
        {
            lstuserControl.SelectedIndex = lstuserControl.FindString(txtUserControl.Text);
        }
        private void lstCopyChartOfAcc_DoubleClick(object sender, EventArgs e)
        {
            txtCopyChartOfAccount.Text = lstCopyChartOfAcc.Text;
            lstCopyChartOfAcc.Visible = false;
            txtBusinessType.Focus();
        }
        private void lstMultipleBranch_DoubleClick(object sender, EventArgs e)
        {
            txtMultipleBranch.Text = lstMultipleBranch.Text;
            txtUserControl.Focus();
        }

        private void lstuserControl_DoubleClick(object sender, EventArgs e)
        {
            txtUserControl.Text = lstuserControl.Text;
            if (txtUserControl.Text.ToUpper() == "YES")
            {
                panelAcessControl.Visible = true;

                panelAcessControl.Size = new Size(346, 220);
                panelAcessControl.Top = txtAddress2.Top + 10;
                panelAcessControl.Left = txtAddress2.Left + 5;
                uctxtAdministrator.Focus();
            }
            else
            {
                panelAcessControl.Visible = false;
                txtComments.Focus();
            }

        }

        private void txtBusinessType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dtefinancialform.Focus();

            }
        }

        private void txtMultipleBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstMultipleBranch.Items.Count > 0)
                {
                    txtMultipleBranch.Text = lstMultipleBranch.Text;
                }
                txtUserControl.Focus();
            }
        }

        private void txtMultipleBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstMultipleBranch.SelectedItem != null)
                {
                    lstMultipleBranch.SelectedIndex = lstMultipleBranch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstMultipleBranch.Items.Count - 1 > lstMultipleBranch.SelectedIndex)
                {
                    lstMultipleBranch.SelectedIndex = lstMultipleBranch.SelectedIndex + 1;
                }
            }

        }
        private void txtUserControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstuserControl.Items.Count > 0)
                {
                    txtUserControl.Text = lstuserControl.Text;
                }
                if (txtUserControl.Text.ToUpper() == "YES")
                {
                    panelAcessControl.Visible = true;

                    panelAcessControl.Size = new Size(346, 220);
                    panelAcessControl.Top = txtAddress2.Top + 10;
                    panelAcessControl.Left = txtAddress2.Left + 5;
                    uctxtAdministrator.Focus();
                }
                else
                {
                    panelAcessControl.Visible = false;
                    txtComments.Focus();
                }


            }
        }

        private void txtUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstuserControl.SelectedItem != null)
                {
                    lstuserControl.SelectedIndex = lstuserControl.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstuserControl.Items.Count - 1 > lstuserControl.SelectedIndex)
                {
                    lstuserControl.SelectedIndex = lstuserControl.SelectedIndex + 1;
                }
            }

        }

        private void txtMultipleBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstMultipleBranch.Visible = true;
            lstuserControl.Visible = false;
            lstMultipleBranch.SelectedIndex = lstMultipleBranch.FindString(txtMultipleBranch.Text);
        }
        protected void txtComments_GotFocus(object sender, EventArgs e)
        {
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
        }
        protected void txtUserControl_GotFocus(object sender, EventArgs e)
        {
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = true;
            lstuserControl.SelectedIndex = lstuserControl.FindString(txtUserControl.Text);
        }
        protected void dtefinancialform_GotFocus(object sender, EventArgs e)
        {
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
        }
        protected void dteFinanicalTo_GotFocus(object sender, EventArgs e)
        {
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
        }
        protected void txtPhone_GotFocus(object sender, EventArgs e)
        {
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
        }
        protected void txtFax_GotFocus(object sender, EventArgs e)
        {
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
        }

        protected void txtCountry_GotFocus(object sender, EventArgs e)
        {
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
        }

        protected void txtAddress2_GotFocus(object sender, EventArgs e)
        {
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
        }

        protected void txtAddress1_GotFocus(object sender, EventArgs e)
        {
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
        }

        protected void txtCompanyName_GotFocus(object sender, EventArgs e)
        {
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
        }
        #endregion
        #region Load
        private void mloadMultipleBranch()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"No", 1},
              {"Yes", 2},
            };

            lstMultipleBranch.DisplayMember = "Key";
            lstMultipleBranch.ValueMember = "Value";
            lstMultipleBranch.DataSource = new BindingSource(userCache, null);

        }
        private void mloadUserControl()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"No", 1},
              {"Yes", 2},
            };

            lstuserControl.DisplayMember = "Key";
            lstuserControl.ValueMember = "Value";
            lstuserControl.DataSource = new BindingSource(userCache, null);

        }
        #endregion
        #region "Tab change
        private void TabChange()
        {

            txtCompanyName.Focus();
            txtCompanyName.AllToNextTab(txtAddress1);
            txtAddress1.AllToNextTab(txtAddress2);
            txtAddress2.AllToNextTab(txtCountry);
            txtCountry.AllToNextTab(txtFax);
            txtFax.AllToNextTab(txtPhone);
            //txtPhone.AllToNextTab(txtCurrency);
            //txtCurrency.AllToNextTab(txtBusinessType);
            txtBusinessType.AllToNextTab(dtefinancialform);
            dtefinancialform.AllToNextTab(dteFinanicalTo);
            dteFinanicalTo.AllToNextTab(txtMultipleBranch);
            txtMultipleBranch.AllToNextTab(txtUserControl);
            txtUserControl.AllToNextTab(txtComments);
            txtComments.AllToNextTab(btnInstall);

        }
        #endregion
        private static string gCreatedatabase(string ServerName, string strCompanyID)
        {
            string conDb;
            string strdatabasename;
            string strSql;

            strdatabasename = "SMART" + strCompanyID;
            conDb = "Data Source=" + ServerName + " ;Initial Catalog= master;User ID=" + Utility.gstDatabaserUserName + " ;Password=" + Utility.gstDatabasePassword + " ";
            using (SqlConnection gcnmain = new SqlConnection(conDb))
            {
                strSql = "CREATE DATABASE " + strdatabasename;
                gcnmain.Open();
                SqlCommand cmd = new SqlCommand(strSql, gcnmain);
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
                return ServerName;
            }
        }

      

        private void mSaveCompanyInfo()
        {
            string strSQL;
            long lngAccessType;
            long lngBusinessType;
            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();


                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                lngBusinessType = Utility.glngGetBusinessType(txtBusinessType.Text);

                if (txtUserControl.Text.ToUpper() == "YES")
                {
                    lngAccessType = 0;
                }
                else
                {
                    lngAccessType = 1;
                }

                strSQL = "INSERT INTO ACC_COMPANY(COMPANY_ID,BRANCH_ID,COMPANY_NAME,COMPANY_INT_NAME,";
                if (txtAddress1.Text != null)
                {
                    strSQL = strSQL + "COMPANY_ADD1,";
                }
                if (txtAddress2.Text != null)
                {
                    strSQL = strSQL + "COMPANY_ADD2,";
                }
                if (txtCountry.Text != null)
                {
                    strSQL = strSQL + "COMPANY_COUNTRY ,";
                }
                if (txtPhone.Text != null)
                {
                    strSQL = strSQL + "COMPANY_PHONE , ";
                }
                if (txtFax.Text != null)
                {
                    strSQL = strSQL + "COMPANY_FAX , ";
                }
                if (txtBusinessType.Text != null)
                {
                    strSQL = strSQL + "COMPANY_BUSINESS_TYPE,";
                }

                strSQL = strSQL + "COMPANY_FINICIAL_YEAR_FROM , ";
                strSQL = strSQL + "COMPANY_FINICIAL_YEAR_TO, ";
                strSQL = strSQL + "COMPANY_BASE_CURRENCY_SYMBOL,COMPANY_ACCESS_CONTROL,";
                strSQL = strSQL + "BACKUP_TARGET, ";
                if (txtBranchId.Text != null)
                {
                    strSQL = strSQL + "COMPANY_BRANCH,IS_MULTIPLE_LOCATION,";
                }
                if (txtComments.Text != null)
                {
                    strSQL = strSQL + "COMPANY_COMMENTS";
                }
                strSQL = strSQL + ")";
                strSQL = strSQL + "VALUES (";
                strSQL = strSQL + "'" + txtCompanyID.Text.Trim() + "',";
                strSQL = strSQL + "'" + txtBranchId.Text.Trim() + "',";
                strSQL = strSQL + "'" + txtCompanyName.Text.Replace("'", "''") + "',";
                strSQL = strSQL + "'" + txtCompanyName.Text.Replace("'", "''") + "',";
                if (txtAddress1.Text != null)
                {
                    strSQL = strSQL + "'" + txtAddress1.Text.Replace("'", "''") + "',";
                }
                if (txtAddress2.Text != null)
                {
                    strSQL = strSQL + "'" + txtAddress2.Text.Replace("'", "''") + "',";
                }
                if (txtCountry.Text != null)
                {
                    strSQL = strSQL + "'" + txtCountry.Text.Replace("'", "''") + "',";
                }
                if (txtPhone.Text != null)
                {
                    strSQL = strSQL + "'" + txtPhone.Text + "',";
                }
                if (txtFax.Text != null)
                {
                    strSQL = strSQL + "'" + txtFax.Text + "',";
                }
                if (txtBusinessType.Text != null)
                {
                    strSQL = strSQL + " " + lngBusinessType + ",";
                }

                strSQL = strSQL + " " + Utility.cvtSQLDate(dtefinancialform.Value) + ",";
                strSQL = strSQL + " " + Utility.cvtSQLDate(dteFinanicalTo.Value) + " ,";
                strSQL = strSQL + "'BDT',";
                strSQL = strSQL + " " + lngAccessType + ",";
                strSQL = strSQL + "'D:\',";
                if (txtBranchId.Text != null)
                {
                    if (txtMultipleBranch.Text.ToUpper() == "YES")
                    {
                        strSQL = strSQL + "1,1,";
                    }
                    else
                    {
                        strSQL = strSQL + "0,0,";
                    }

                }
                if (txtComments.Text != null)
                {
                    strSQL = strSQL + "'" + txtComments.Text.Replace("'", "''") + "'";
                }

                strSQL = strSQL + ")";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                Utility.gstrCompanyName = txtCompanyName.Text.Replace("'", "''");
                Utility.gstrBranchID = txtBranchId.Text.Trim();
                Utility.gstrCompanyID = txtCompanyID.Text.Trim();
                strSQL = "INSERT INTO ACC_BRANCH(BRANCH_ID,BRANCH_NAME,BRANCH_INT_NAME,BRANCH_NAME_DEFAULT,BRANCH_TYPE) ";
                strSQL = strSQL + "VALUES(";
                strSQL = strSQL + "'" + txtBranchId.Text + "',";
                strSQL = strSQL + "'" + Utility.gstrCompanyName + "',";
                strSQL = strSQL + "'" + Utility.gstrCompanyName.Trim() + "',";
                strSQL = strSQL + "'" + Utility.gstrCompanyName.Trim() + "',";
                strSQL = strSQL + "1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                myTrans.Commit();
            }
        }




        private void frmCompanyInstallmentNew_Paint(object sender, PaintEventArgs e)
        {

            txtBranchId.Text = "0001";


        }



        private void changeRegionalSetting()
        {
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
            rkey.SetValue("sShortDate", "dd-MM-yyyy");
            rkey.Close();

        }

        private void frmCompanyInstallmentNew_Load(object sender, EventArgs e)
        {
            lstuserControl.Visible = false;
            lstMultipleBranch.Visible = false;
            lstCopyChartOfAcc.Visible = false;
            pbImage.Image = imagelst.Images[0];
            mloadMultipleBranch();
            mloadUserControl();
            lstCopyChartOfAcc.DisplayMember = "strComName";
            lstCopyChartOfAcc.ValueMember = "strComID";
            lstCopyChartOfAcc.DataSource = invms.mloadDatabaseCompnay(strComID).ToList();

            txtCompanyID.Text = Utility.gstrGetLastSerl();
            txtBranchId.Text = "0001";
            txtCompanyName.Text = "Company Name - " + txtCompanyID.Text;
            txtAddress1.Text = "Address1";
            txtAddress2.Text = "Address2";
            txtBusinessType.Text = "Manufacturing Company";
            txtCountry.Text = "Bangladesh";
            txtMultipleBranch.Text = "Yes";
            txtUserControl.Text = "No";
            if (DateTime.Now.Month >= 1 && DateTime.Now.Month <= 6)
            {
                dtefinancialform.Text = "01-01-" + DateTime.Now.Year;
                dteFinanicalTo.Text = "31-12-" + DateTime.Now.Year;
            }
            else
            {
                dtefinancialform.Text = "01-07-" + DateTime.Now.Year;
                dteFinanicalTo.Text = "30-06-" + DateTime.Now.Year;
            }


        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            string ServerName;
            string strCompanyID = "0001", strCompanyName = "";
            string strSQL;
            if (txtCompanyName.Text == "")
            {
                MessageBox.Show("Company Name Cannot be empty");
                txtCompanyName.Focus();
                return;
            }
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
            btnInstall.Enabled = true;
            SqlDataReader Dr;
            string conDb;
            changeRegionalSetting();
            if (lstCopyChartOfAcc.SelectedValue.ToString() =="")
            {
                MessageBox.Show("No Compnay Name Found", "Copy Chart Of Accounts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCopyChartOfAccount.Focus();
                return;
            }
            strCompanyID = "0001";
            Utility.strDataBase = "SMART" + strCompanyID;
            regKey.SetValue("gstrDataBaseName", Utility.strDataBase);
            regKey.SetValue("CompanyID", strCompanyID);

            ServerName = Utility.gGetServerName();
            conDb = "Data Source=" + ServerName + " ;Initial Catalog= master;User ID=" + Utility.gstDatabaserUserName + " ;Password=" + Utility.gstDatabasePassword + " ";
            strSQL = "SELECT NAME FROM master.dbo.sysdatabases WHERE NAME = '" + Utility.strDataBase + "' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strCompanyName = txtCompanyName.Text.Replace("'", "''");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnMain;
                cmd.CommandText = strSQL;
                Dr = cmd.ExecuteReader();
                if ((Dr.Read()) != true)
                {
                    Utility.gstrCompanyID = txtCompanyID.Text.Trim();
                    Utility.gstrBranchID = txtBranchId.Text.Trim();
                    Utility.gstrCompanyName = strCompanyName;
                    Utility.gdteFinancialYearFrom = Utility.DateFormat(dtefinancialform.Value);
                    Utility.gdteFinancialYearTo = Utility.DateFormat(dteFinanicalTo.Value);
                    Utility.gstrFinicialYearFrom = Utility.gstrDateToStr(dtefinancialform.Text);
                    Utility.gstrFinicialYearTo = Utility.gstrDateToStr(dteFinanicalTo.Text);
                    Utility.gstrBusinessType = txtBusinessType.Text;
                    mstrCurSymbol = "BDT";
                    mstrCurFormallName = "BDT";
                    //mstrCurString = txtCurrency.Text.Replace("'","''");
                    //mlngCurDecimalPl = Replace(uctxtCurrencyDecimal.Text, "'", "''")
                    //uctxtDefaultCurrency.Text = mstrCurSymbol
                    mstrCurString = "";
                    mlngCurDecimalPl = 0;
                    gCreatedatabase(ServerName, strCompanyID);
                    // Utility.creaateWrite(strCompanyID);
                    basTableSchemaAccount.gCreateAccounts(txtBusinessType.Text.ToString());
                    proBar.Value = proBar.Value + 10;
                    basTableSchemaStock.gCreateStock();
                    proBar.Value = proBar.Value + 20;
                    basTableSchemaReport.gCreateTableReport();
                    proBar.Value = proBar.Value + 20;
                    basViewSchemaAccount.gCreateViewAccount();
                    basViewSchemaStock.gCreateViewStock();
                    basProcedure.gCreateAdavanceSP();
                    basTrigger.gCreateTrigger();
                    CreateDefaultdata.gInsertBaseCurrency(mstrCurSymbol, mstrCurFormallName, mstrCurString, mlngCurDecimalPl);
                    mSaveCompanyInfo();
                    //CreateDefaultdata.gInsertDefaultData(true, "BDT", txtBusinessType.Text, txtBranchId.Text, txtCompanyName.Text);
                    MemoryStream ms = new MemoryStream();
                    pbImage.Image.Save(ms, ImageFormat.Jpeg);
                    _imageData = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(_imageData, 0, _imageData.Length);
                    CreateDefaultdata.gInsertAccessControl("Deeplaid", "Deeplaid", _imageData, txtBranchId.Text);
                    if (txtUserControl.Text.ToUpper() == "YES")
                    {
                        Utility.gblnAccessControl = true;
                        CreateDefaultdata.gInsertAccessControl(uctxtAdministrator.Text, uctxtPassword.Text, _imageData, txtBranchId.Text);
                    }
                    else
                    {
                        Utility.gblnAccessControl = false;
                    }
                    string strSourceDB = "";
                    strSourceDB = "SMART" + lstCopyChartOfAcc.SelectedValue.ToString();
                    Dr.Close();
                    gcnMain.Close();
                    string cnn = "";
                    SqlTransaction myTrans;
                    SqlCommand cmdInsert = new SqlCommand();
                    cnn = Utility.SQLConnstringComSwitch(strCompanyID);
                    using (SqlConnection gcnMainnew = new SqlConnection(cnn))
                    {
                        if (gcnMainnew.State == ConnectionState.Open)
                        {
                            gcnMainnew.Close();
                        }
                        gcnMainnew.Open();
                        myTrans = gcnMainnew.BeginTransaction();
                        cmdInsert.Connection = gcnMainnew;
                        cmdInsert.Transaction = myTrans;
                        //Accounts
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_VOUCHER_TYPE", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_DESTINATION", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_TERITORRY", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_MASTER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_COMMISSION_MASTER", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_COMMISSION_TRAN", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LEDGERGROUP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_GROUP_TO_LEDGER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableDataBranch(strCompanyID, strSourceDB, "ACC_BRANCH", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LEDGER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_LEDGER_TO_GROUP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                       
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "VECTOR_CATEGORY", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "VECTOR_MASTER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BRANCH_LEDGER_OPENING", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        //StockGroup
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_UNIT_MEASUREMENT", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKGROUP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKCATEGORY", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCK_MATERIAL_TYPE", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GROUP_TO_STOCKITEM", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM_TO_GROUP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM_LEVEL", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_GODOWNS", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_BRANCH_LEDGER_OPENING", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_STOCKITEM_CLOSING", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_PRICE_LEVEL", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_SALES_PRICE", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_EXPENSE_CONFIG_MASTER", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_EXPENSE_CONFIG_TRAN", 0);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_FIXED_ASSET_ACCUMULATED_DEPRECIATION", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_FIXED_ASSET_ADJUSTMENT_DEP", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "ACC_FIXED_ASSET_PURCHASE_AMOUNT", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_MENU_PROCESS_MAIN", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "INV_MANU_PROCESS", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = Utility.mInsertTableData(strCompanyID, strSourceDB, "USER_FORM_CONFIG", 1);
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();


                        strSQL = "UPDATE ACC_LEDGER SET LEDGER_OPENING_BALANCE=0,LEDGER_CLOSING_BALANCE=0,LEDGER_OPENING=0,";
                        strSQL = strSQL + "LEDGER_DEBIT=0,LEDGER_CREDIT=0,LEDGER_ON_ACCOUNT_VALUE=0";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "UPDATE ACC_LEDGERGROUP SET GR_OPENING_DEBIT=0,GR_OPENING_CREDIT=0,GR_DEBIT_TOTAL=0,";
                        strSQL = strSQL + "GR_CREDIT_TOTAL=0,GR_CLOSING_DEBIT=0,GR_CLOSING_CREDIT=0";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "UPDATE ACC_BRANCH_LEDGER_OPENING SET BRANCH_LEDGER_OPENING_BALANCE=0";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "UPDATE INV_STOCKITEM SET STOCKITEM_OPENING_BALANCE=0,STOCKITEM_OPENING_VALUE=0,STOCKITEM_OPENING_RATE=0,";
                        strSQL = strSQL + "STOCKITEM_CLOSING_BALANCE=0";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "UPDATE INV_STOCKITEM_CLOSING SET STOCKITEM_CLOSING_BALANCE=0,STOCKITEM_SALE_BALANCE=0";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "UPDATE ACC_VOUCHER_TYPE SET VOUCHER_TYPE_TOTAL_VOUCHER=0 ";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        proBar.Value = proBar.Value + 50;
                        cmdInsert.Transaction.Commit();
                        gcnMainnew.Close();
                        gcnMain.Close();
                        cmdInsert.Dispose();
                        cmd.Dispose();
                        Dr.Close();

                    }



                    this.Hide();
              


                }
            
               
                Dr.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ID = lstCopyChartOfAcc.SelectedValue.ToString();
            //string dd = Utility.mInsertTableData(strComID, "SMART0001", "ACC_LEDGER",1);
        }

       

       

      

       










    }
}