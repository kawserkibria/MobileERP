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
using JA.Modulecontrolar.JACCMS;


namespace JA.Modulecontrolar
{
    public partial class frmCompanyInstallmentNew : Form
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private ListBox lstCurrency = new ListBox();
        private ListBox lstuserControl = new ListBox();
        private ListBox lstBusinessType = new ListBox();
        private ListBox lstMultipleBranch = new ListBox();
        private string mstrCurSymbol;
        private string mstrCurFormallName   ;
        private string mstrCurString        ;
        private long mlngCurDecimalPl      ;
        public int intCallType;
        private byte[] _imageData;
        public frmCompanyInstallmentNew()
        {
            InitializeComponent();
           
            this.txtCompanyName.GotFocus += new System.EventHandler(this.txtCompanyName_GotFocus);
            this.txtAddress1.GotFocus += new System.EventHandler(this.txtAddress1_GotFocus);
            this.txtAddress2.GotFocus += new System.EventHandler(this.txtAddress2_GotFocus);
            this.txtCountry.GotFocus += new System.EventHandler(this.txtCountry_GotFocus);
            this.txtFax.GotFocus += new System.EventHandler(this.txtFax_GotFocus);
            this.txtPhone.GotFocus += new System.EventHandler(this.txtPhone_GotFocus);
            this.txtCurrency.GotFocus += new System.EventHandler(this.txtCurrency_GotFocus);
            this.txtBusinessType.GotFocus += new System.EventHandler(this.txtBusinessType_GotFocus);
            this.dtefinancialform.GotFocus += new System.EventHandler(this.dtefinancialform_GotFocus);
            this.dteFinanicalTo.GotFocus += new System.EventHandler(this.dteFinanicalTo_GotFocus);
            this.txtMultipleBranch.GotFocus += new System.EventHandler(this.txtMultipleBranch_GotFocus);
            this.txtUserControl.GotFocus += new System.EventHandler(this.txtUserControl_GotFocus);
            this.txtComments.GotFocus += new System.EventHandler(this.txtComments_GotFocus);

           

            this.txtCurrency.KeyDown += new KeyEventHandler(txtCurrency_KeyDown);
            this.txtCurrency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCurrency_KeyPress);

            this.txtUserControl.KeyDown += new KeyEventHandler(txtUserControl_KeyDown);
            this.txtUserControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUserControl_KeyPress);

            this.txtMultipleBranch.KeyDown += new KeyEventHandler(txtMultipleBranch_KeyDown);
            this.txtMultipleBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtMultipleBranch_KeyPress);

            this.txtBusinessType.KeyDown += new KeyEventHandler(txtBusinessType_KeyDown);
            this.txtBusinessType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBusinessType_KeyPress);

            this.lstCurrency.DoubleClick += new System.EventHandler(this.lstCurrency_DoubleClick);
            this.lstMultipleBranch.DoubleClick += new System.EventHandler(this.lstMultipleBranch_DoubleClick);
            this.lstuserControl.DoubleClick += new System.EventHandler(this.lstuserControl_DoubleClick);
            this.lstBusinessType.DoubleClick += new System.EventHandler(this.lstBusinessType_DoubleClick);

            this.txtCurrency.TextChanged += new System.EventHandler(this.txtCurrency_TextChanged);
            this.txtMultipleBranch.TextChanged += new System.EventHandler(this.txtMultipleBranch_TextChanged);
            this.txtUserControl.TextChanged += new System.EventHandler(this.txtUserControl_TextChanged);
            this.txtBusinessType.TextChanged += new System.EventHandler(this.txtBusinessType_TextChanged);

            this.uctxtAdministrator.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAdministrator_KeyPress);
            this.uctxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPassword_KeyPress);
            this.uctxtRetypePassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRetypePassword_KeyPress);

            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            this.btnAccessCancel.Click += new System.EventHandler(this.btnAccessCancel_Click);
            Utility.CreateListBox(lstCurrency, panel1, txtCurrency);
            Utility.CreateListBox(lstBusinessType, panel1, txtBusinessType);
            Utility.CreateListBox(lstuserControl, panel1, txtUserControl);
            Utility.CreateListBox(lstMultipleBranch, panel1, txtMultipleBranch);
            TabChange();
        }


        #region "User Define Event"
        private void btnAccessCancel_Click(object sender, EventArgs e)
        {
            panelAcessControl.Visible = false;
            txtUserControl.Focus();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if ( uctxtAdministrator.Text.Trim().Length == 0)
            {
                MessageBox.Show("Administrator must be entered");
                uctxtAdministrator.Focus();
                return ;
            }
            if ( uctxtPassword.Text.Trim().Length <6)
            {
                MessageBox.Show("Password Length more than 6");
                uctxtPassword.Focus();
                return ;
            }
            if ( uctxtPassword.Text.Trim() != uctxtRetypePassword.Text.Trim()  )
            {
                MessageBox.Show("Mismatch Password");
                uctxtPassword.Focus();
                return ;
            }
            panelAcessControl.Visible = false;
            txtComments.Focus();
       
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
                panelAcessControl.Visible = false;
                txtComments.Focus();

            }
        }
        private void txtBusinessType_TextChanged(object sender, EventArgs e)
        {
            lstBusinessType.SelectedIndex = lstBusinessType.FindString(txtBusinessType.Text);
        }
        private void txtMultipleBranch_TextChanged(object sender, EventArgs e)
        {
            lstMultipleBranch.SelectedIndex = lstMultipleBranch.FindString(txtMultipleBranch.Text);
        }
        private void txtUserControl_TextChanged(object sender, EventArgs e)
        {
            lstuserControl.SelectedIndex = lstuserControl.FindString(txtUserControl.Text);
        }
        private void txtCurrency_TextChanged(object sender, EventArgs e)
        {
            lstCurrency.SelectedIndex = lstCurrency.FindString(txtCurrency.Text);
        }

        private void lstBusinessType_DoubleClick(object sender, EventArgs e)
        {
            txtBusinessType.Text = lstBusinessType.Text;
            dtefinancialform.Focus();
        }
        private void lstCurrency_DoubleClick(object sender, EventArgs e)
        {
            txtCurrency.Text = lstCurrency.Text;
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
                string strName = Utility.gGetUSerAdmin(txtCompanyID.Text);
                {
                    uctxtAdministrator.Text = strName;
                    uctxtPassword.Text = Utility.gstrOldPassword;
                    uctxtRetypePassword.Text = Utility.gstrOldPassword;
                }
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
                if (lstBusinessType.Items.Count >0 )
                {
                    txtBusinessType.Text = lstBusinessType.Text;
                }
                dtefinancialform.Focus();

            }
        }

        private void txtBusinessType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBusinessType.SelectedItem != null)
                {
                    lstBusinessType.SelectedIndex = lstBusinessType.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBusinessType.Items.Count - 1 > lstBusinessType.SelectedIndex)
                {
                    lstBusinessType.SelectedIndex = lstBusinessType.SelectedIndex + 1;
                }
            }

        }

        private void txtMultipleBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstMultipleBranch.Items.Count >0)
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
            string strName="";
            if (e.KeyChar == (char)Keys.Return)
            {
                try
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
                        strName = Utility.gGetUSerAdmin(txtCompanyID.Text);
                        {
                            uctxtAdministrator.Text = strName;
                            uctxtPassword.Text = Utility.gstrOldPassword;
                            uctxtRetypePassword.Text = Utility.gstrOldPassword;
                        }

                        uctxtAdministrator.Focus();


                    }
                    else
                    {
                        panelAcessControl.Visible = false;
                        txtComments.Focus();
                    }
                }
                catch (Exception ex)
                {

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

        private void txtCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstCurrency.Items.Count>0)
                {
                    txtCurrency.Text = lstCurrency.Text;
                }
                txtBusinessType.Focus();

            }
        }
        private void txtCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstCurrency.SelectedItem != null)
                {
                    lstCurrency.SelectedIndex = lstCurrency.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstCurrency.Items.Count - 1 > lstCurrency.SelectedIndex)
                {
                    lstCurrency.SelectedIndex = lstCurrency.SelectedIndex + 1;
                }
            }

        }

        private void txtCurrency_GotFocus(object sender, System.EventArgs e)
        {
            lstCurrency.Visible = false;
            lstBusinessType.Visible = false;
            lstuserControl.Visible = false;
            lstMultipleBranch.Visible = false;
            lstCurrency.SelectedIndex = lstCurrency.FindString(txtCurrency.Text);
        }
        private void txtBusinessType_GotFocus(object sender, System.EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = true;
            lstBusinessType.SelectedIndex = lstBusinessType.FindString(txtBusinessType.Text);
        }
        private void txtMultipleBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = true;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            ////txtComments.Visible = false;
            lstMultipleBranch.SelectedIndex = lstMultipleBranch.FindString(txtMultipleBranch.Text);
        }
        protected void txtComments_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            ////txtComments.Visible = false;
        }
        protected void txtUserControl_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = true;
            lstBusinessType.Visible = false;
            //txtComments.Visible = false;
            lstuserControl.SelectedIndex = lstuserControl.FindString(txtUserControl.Text);
        }
        protected void dtefinancialform_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            //txtComments.Visible = false;
        }
        protected void dteFinanicalTo_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            //txtComments.Visible = false;
            //dtefinancialform.CustomFormat = "dd-MM-yyyy";
            //dtefinancialform.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //dteFinanicalTo.Value = dtefinancialform.Value.AddMonths(12);
            //dteFinanicalTo.CustomFormat = "dd-MM-yyyy";
            //dteFinanicalTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }
        protected void txtPhone_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            //txtComments.Visible = false;
        }
        protected void txtFax_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            //txtComments.Visible = false;
        }

        protected void txtCountry_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            //txtComments.Visible = false;
        }

        protected void txtAddress2_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            //txtComments.Visible = false;
        }

        protected void txtAddress1_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            //txtComments.Visible = false;
        }

        protected void txtCompanyName_GotFocus(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstMultipleBranch.Visible = false;
            lstuserControl.Visible = false;
            lstBusinessType.Visible = false;
            //txtComments.Visible = false;
        }
        #endregion
        #region Load
        private void mloadCurrecncy()
        {

            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"BDT", 1},
              {"$", 2},
              {"€", 3},
              {"£", 4},
              {"¥", 5},
              {"Rs", 6},
           
            };

            lstCurrency.DisplayMember = "Key";
            lstCurrency.ValueMember = "Value";
            lstCurrency.DataSource = new BindingSource(userCache, null);

        }
        private void mloadBusinessType()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"Trading Company", 1},
              {"Real Estate", 2},
              {"Educational Institution", 3},
              {"Manufacturing Company", 4},
              {"Non-Profit Company", 5},
              {"Hospital", 6},
              {"Hotel Management", 7},
              {"Co-Operative Society", 8},
            };


            lstBusinessType.DisplayMember = "Key";
            lstBusinessType.ValueMember = "Value";
            lstBusinessType.DataSource = new BindingSource(userCache, null);

        }
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
            txtPhone.AllToNextTab(txtCurrency);
            txtCurrency.AllToNextTab(txtBusinessType);
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
     
        private void btnInstall_Click(object sender, EventArgs e)
        {
            string ServerName;
            string strCompanyID="0001",strCompanyName="";
            string strSQL;
            if (txtCompanyName.Text =="")
            {
                MessageBox.Show("Company Name Cannot be empty");
                txtCompanyName.Focus();
                return;
            }
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
            btnInstall.Enabled = true;
            if (Utility.GetCallType.intCallType == 1 )
            {
                SqlDataReader Dr;
                string conDb;
                changeRegionalSetting();
               
                strCompanyID = txtCompanyID.Text.Trim();
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
                    strCompanyName = txtCompanyName.Text.Replace("'","''");
                    SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
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
                        mstrCurSymbol =txtCurrency.Text.Replace("'","''");
                        mstrCurFormallName =txtCurrency.Text.Replace("'","''");
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
                        proBar.Value = proBar.Value + 10;
                        basProcedure.gCreateAdavanceSP();
                        basTrigger.gCreateTrigger();
                        CreateDefaultdata.gInsertBaseCurrency(mstrCurSymbol, mstrCurFormallName, mstrCurString, mlngCurDecimalPl);
                        proBar.Value = proBar.Value + 10;
                        mSaveCompanyInfo();
                        CreateDefaultdata.gInsertDefaultData(true, txtCurrency.Text, txtBusinessType.Text, txtBranchId.Text, txtCompanyName.Text);
                        proBar.Value = proBar.Value + 10;
                        MemoryStream ms = new MemoryStream();
                        pbImage.Image.Save(ms, ImageFormat.Jpeg);
                        _imageData = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(_imageData, 0, _imageData.Length);

                        CreateDefaultdata.gInsertAccessControl("Deeplaid", "DeepLaid",_imageData, txtBranchId.Text);
                        proBar.Value = proBar.Value + 10;
                        if (txtUserControl.Text.ToUpper() == "YES")
                        {
                            Utility.gblnAccessControl = true;
                            CreateDefaultdata.gInsertAccessControl(uctxtAdministrator.Text, uctxtPassword.Text,_imageData, txtBranchId.Text);
                        }
                        else
                        {
                            Utility.gblnAccessControl = false ;
                        }
                        proBar.Value = proBar.Value + 10;
                       
                        this.Hide();
                        //Utility.gSelectCompanyName();
                        if (Utility.gblnAccessControl)
                        {
                            frmLogIn frm = new frmLogIn();
                            frm.ShowDialog();
                        }
                        else
                        {
                            if (System.Windows.Forms.Application.OpenForms["frmMain"] as frmMain == null)
                            {
                                frmMain objfrm = new frmMain();
                                objfrm.Refresh();
                                objfrm.intCheckBackup = 1;
                                objfrm.Show();
                                //this.Close();

                            }
                            else
                            {
                                ((frmMain)Application.OpenForms["frmMain"]).Text = Utility.gstrCompanyID + "-" + Utility.gstrCompanyName + " - " + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString(Utility.DEFAULT_DATE_FORMAT)
                                                                      + " to " + Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString(Utility.DEFAULT_DATE_FORMAT);
                                frmMain objfrm = (frmMain)Application.OpenForms["frmMain"];
                                objfrm.Focus();
                                objfrm.Refresh();
                                this.Close();
                            }
                        }
                        
                    }
                    else
                    {
                        
                        Utility.SQLConnstring();
                    }
                }

            }
            else
            {
                proBar.Value = proBar.Value + 10;
                btnInstall.Text = "Update";
                proBar.Value = proBar.Value + 70;
                mUpdate();
                proBar.Value = proBar.Value + 20;
                this.Close();
                if (Utility.gblnAccessControl)
                {
                    if (System.Windows.Forms.Application.OpenForms["frmMain"] as frmMain == null)
                    {
                        frmMain objfrmmain = new frmMain();
                        objfrmmain.intCheckBackup = 1;
                        objfrmmain.Close();

                    }
                    else
                    {
                        ((frmMain)Application.OpenForms["frmMain"]).Text = Utility.gstrCompanyID + "-" + Utility.gstrCompanyName + " - " + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString(Utility.DEFAULT_DATE_FORMAT)
                                                              + " to " + Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString(Utility.DEFAULT_DATE_FORMAT);
                        frmMain objfrm = (frmMain)Application.OpenForms["frmMain"];
                        objfrm.intCheckBackup = 1;
                        objfrm.Close();
                    }
                    frmLogIn frm = new frmLogIn();
                    frm.Show();
                   
                }
                else
                {
                    if (System.Windows.Forms.Application.OpenForms["frmMain"] as frmMain == null)
                    {
                        frmMain objfrmmain = new frmMain();
                        objfrmmain.mLoad(strCompanyID);
                        objfrmmain.Refresh();
                        this.Close();

                    }
                    else
                    {
                        ((frmMain)Application.OpenForms["frmMain"]).Text = Utility.gstrCompanyID + "-" + Utility.gstrCompanyName + " - " + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString(Utility.DEFAULT_DATE_FORMAT)
                                                              + " to " + Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString(Utility.DEFAULT_DATE_FORMAT);
                        frmMain objfrm = (frmMain)Application.OpenForms["frmMain"];
                        objfrm.mLoad(strCompanyID);
                        objfrm.Focus();
                        objfrm.Refresh();
                        this.Close();
                    }
                }
                this.Close();
               
            }
        }

        private void mUpdate()
        {
             string strSQL;
            long lngAccessType;
            long lngBusinessType,lngBranch;
            lngBusinessType = Utility.glngGetBusinessType(txtBusinessType.Text);
            if (txtUserControl.Text.ToUpper()=="YES")
            {
                lngAccessType=0;
            }
            else
            {
                lngAccessType=1;
            }
             if (txtMultipleBranch.Text.ToUpper()=="YES")
            {
                lngBranch=1;
            }
            else
            {
                lngBranch=0;
            }

            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstringComSwitch(txtCompanyID.Text)))
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
                strSQL = "UPDATE ACC_COMPANY ";
                strSQL = strSQL + "SET COMPANY_NAME = '" + txtCompanyName.Text.Trim().Replace("'","''") + "', ";
                strSQL = strSQL + "COMPANY_ADD1 = '" + txtAddress1.Text.Trim().Replace("'", "''") + "',";
                strSQL = strSQL + "COMPANY_ADD2 = '" + txtAddress2.Text.Trim().Replace("'", "''") + "',";
                strSQL = strSQL + "COMPANY_BASE_CURRENCY_SYMBOL = '" + txtCurrency.Text.Trim().Replace("'", "''") + "',";
                strSQL = strSQL + "COMPANY_FINICIAL_YEAR_FROM = " + Utility.cvtSQLDateString(dtefinancialform.Text) + ",";
                strSQL = strSQL + "COMPANY_FINICIAL_YEAR_TO = " + Utility.cvtSQLDateString(dteFinanicalTo.Text) + ",";
                strSQL = strSQL + "COMPANY_COUNTRY = '" + txtCountry.Text.Trim().Replace("'", "''") + "',";
                strSQL = strSQL + "COMPANY_PHONE = '" + txtPhone.Text.Trim().Replace("'", "''") + "',";
                strSQL = strSQL + "COMPANY_BUSINESS_TYPE = " + lngBusinessType + ",";
                //'    strSQL = strSQL + "COMPANY_MAINTAIN = " + lngMaintain + ","
                strSQL = strSQL + "COMPANY_BRANCH = " + lngBranch + ",";
                strSQL = strSQL + "COMPANY_COMMENTS = '" + txtComments.Text.Trim().Replace("'", "''") + "',";
                strSQL = strSQL + "COMPANY_ACCESS_CONTROL = " + lngAccessType + ",";
                strSQL = strSQL + "COMPANY_FAX = '" + txtFax.Text.Trim().Replace("'", "''") + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE ACC_BRANCH SET BRANCH_NAME= '" + txtCompanyName.Text.Trim().Replace("'", "''") + "' ";
                strSQL = strSQL + ",BRANCH_INT_NAME = '" + txtCompanyName.Text.Trim().Replace("'", "''") + "' ";
                strSQL = strSQL + ",BRANCH_NAME_DEFAULT = '" + txtCompanyName.Text.Trim().Replace("'", "''") + "' ";
                strSQL = strSQL + "WHERE BRANCH_ID = '" + txtBranchId.Text + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "UPDATE ACC_LEDGER SET LEDGER_NAME= '" + txtCompanyName.Text.Trim().Replace("'", "''") + "' ";
                strSQL = strSQL + ",LEDGER_NAME_MERZE = '" + txtCompanyName.Text.Trim().Replace("'", "''") + "' ";
                strSQL = strSQL + ",LEDGER_NAME_DEFAULT = '" + txtCompanyName.Text.Trim().Replace("'", "''") + "' ";
                strSQL = strSQL + "WHERE LEDGER_NAME = '" + uctxtOldCompName.Text.Trim().Replace("'", "''") + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();
                if (txtUserControl.Text.Trim().ToUpper() == "YES")
                {
                    MemoryStream ms = new MemoryStream();
                    pbImage.Image.Save(ms, ImageFormat.Jpeg);
                    _imageData = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(_imageData, 0, _imageData.Length);
                    if (Utility.gstrOldUserName !="")
                    {
                        if (Utility.gstrOldUserName != null)
                        {
                            strSQL = "DELETE FROM USER_PRIVILEGES_BRANCH ";
                            strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + Utility.gstrOldUserName.Trim().Replace("'", "''") + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            strSQL = "DELETE FROM USER_PRIVILEGES_LOCATION ";
                            strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + Utility.gstrOldUserName.Trim().Replace("'", "''") + "' ";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            strSQL = "UPDATE USER_CONFIG SET ";
                            strSQL = strSQL + "USER_LOGIN_NAME = '" + uctxtAdministrator.Text.Trim().Replace("'", "''") + "', ";
                            strSQL = strSQL + "USER_PASS = '" + Utility.Encrypt(uctxtPassword.Text, uctxtAdministrator.Text) + "' ";
                            strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + Utility.gstrOldUserName.Trim().Replace("'", "''") + "' "; ;
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                            CreateDefaultdata.gUpdatePrivilegesNew(Utility.gstrOldUserName, uctxtAdministrator.Text, "A");
                        }
                        else
                        {
                            CreateDefaultdata.gInsertPrivilegesNew(uctxtAdministrator.Text, "A");
                        }
                    }
                    else
                    {
                        CreateDefaultdata.gInsertPrivilegesNew(uctxtAdministrator.Text, "A");
                    }
                   
                }
                
                gcnMain.Close();
                Utility.gSelectCompanyName(txtCompanyID.Text.ToString(),txtUserControl.Text);
                ((frmMain)Application.OpenForms["frmMain"]).Text = Utility.gstrCompanyID + "-" + Utility.gstrCompanyName + " - " + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString(Utility.DEFAULT_DATE_FORMAT)
                                                                        + " to " + Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString(Utility.DEFAULT_DATE_FORMAT);
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
                strSQL = strSQL + "'" + txtCurrency.Text + "',";
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

            //string strCompanyID;
            //int intCompnyId;

            //changeRegionalSetting();
       

            //RegistryKey regKey = Registry.CurrentUser.CreateSubKey("SmartAccounts");

            ////dtefinancialform.CustomFormat = "dd-MM-yyyy";
            ////dtefinancialform.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            ////dteFinanicalTo.Value = dtefinancialform.Value.AddMonths(12);
            ////dteFinanicalTo.CustomFormat = "dd-MM-yyyy";
            ////dteFinanicalTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;


            //String gstrGetCompanyID = (String)regKey.GetValue("CompanyID");
            //if (gstrGetCompanyID != "")
            //{
            //    strCompanyID = gstrGetCompanyID;
            //    intCompnyId = int.Parse(strCompanyID) + 1;
            //    string xstring = Convert.ToString(intCompnyId);
            //    strCompanyID = Utility.gstrGetpading(xstring);

            //    //strCompanyID = xstring ;
            //}
            //else
            //{
            //    strCompanyID = "0001";
            //}
            //txtCompanyID.Text = strCompanyID.ToString();
            txtBranchId.Text = "0001";


        }

       
       
        private  void  changeRegionalSetting()
        {
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
            ///Set Values
            // rkey.SetValue("sTimeFormat", TimeFormat);
            rkey.SetValue("sShortDate", "dd-MM-yyyy");
            //rkey.SetValue("sCurrency", Currency);
            //Close the Registry
            rkey.Close();

        }

        private void frmCompanyInstallmentNew_Load(object sender, EventArgs e)
        {
            lstCurrency.Visible = false;
            lstBusinessType.Visible = false;
            lstuserControl.Visible = false;
            lstMultipleBranch.Visible = false;
            pbImage.Image = imagelst.Images[0];
            mloadCurrecncy();
            mloadMultipleBranch();
            mloadUserControl();
            mloadBusinessType();
            if (Utility.GetCallType.intCallType==2)
            {
                this.Text = "Company Edit";
                Utility.gSelectCompanyName(Utility.gstrCompanyID,txtUserControl.Text);
                //string ff = accms.gSelectCompanyName(Utility.gstrCompanyID);
                btnInstall.Text = "Update";
                txtCompanyID.Text = Utility.gstrCompanyID;
                txtBranchId.Text = Utility.gstrBranchID;
                txtCompanyName.Text = Utility.gstrCompanyName;
                uctxtOldCompName.Text = Utility.gstrCompanyName;
                txtAddress1.Text = Utility.gstrCompanyAddress1;
                txtAddress2.Text = Utility.gstrCompanyAddress2;
                txtCountry.Text = "Bangladesh";
                txtFax.Text = Utility.gstrFax;
                txtPhone.Text = Utility.gstrPhoneNo;
                txtCurrency.Text = "BDT";
                int i = (int)(Utility.glngBusinessType);
                txtBusinessType.Text = Utility.gstrGetBusinessType(i).ToString();
                dtefinancialform.Text =Utility.gdteFinancialYearFrom;
                dteFinanicalTo.Text = Utility.gdteFinancialYearTo;
              
                txtMultipleBranch.Text = "Yes";
                if (Utility.gblnAccessControl == true)
                {
                    txtUserControl.Text = "Yes";
                    uctxtAdministrator.Text = Utility.gstrOldUserName;
                    uctxtPassword.Text = Utility.gstrOldPassword;
                    uctxtRetypePassword.Text = Utility.gstrOldPassword;
                }
                else
                {
                    txtUserControl.Text = "No";
                }
                txtComments.Text = Utility.gstrComments;
            }
            else
            {
                txtCompanyID.Text = Utility.gstrGetLastSerl();
                txtBranchId.Text = "0001";
                //mblnAddCompany = True
                //mblnEditCompany = False
                txtCompanyName.Text = "Company Name - " + txtCompanyID.Text;
                txtAddress1.Text = "Address1";
                txtAddress2.Text = "Address2";
                txtBusinessType.Text = "Manufacturing Company";
                txtCountry.Text = "Bangladesh";
                txtMultipleBranch.Text = "Yes";
                txtUserControl.Text = "No";
                //if (DateTime.Now.Month >=1 && DateTime.Now.Month <=6)
                //{
                dtefinancialform.Text = "01-01-" + DateTime.Now.Year;
                dteFinanicalTo.Text = "31-12-" + DateTime.Now.Year;
                //}
                //else
                //{
                //    dtefinancialform.Text = "01-07-" + DateTime.Now.Year;
                //    dteFinanicalTo.Text = "30-06-" + DateTime.Now.Year;
                //}
       
       
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnInstall_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnApply_Click_1(object sender, EventArgs e)
        {

        }

       

       

      

       
    
       
    }
}