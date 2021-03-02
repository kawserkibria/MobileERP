using Dutility;
using JA.Modulecontrolar.UI.Tools.Forms;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JA.Modulecontrolar
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
            this.uctxtLogIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLogIn_KeyPress);
            this.uctxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPassword_KeyPress);
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
        }

       
        private void btnLogon_Click(object sender, EventArgs e)
        {
            string strSQL, strPassword = "";
            int intUserLebel = 0;
            SqlDataReader rsget;
            //uctxtPassword.Text = "Smart420";

            strSQL = "SELECT USER_LOGIN_SERIAL,USER_LOGIN_NAME,USER_PASS,USER_LEBEL,USER_STATUS FROM USER_CONFIG ";
            strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + uctxtLogIn.Text.Trim().Replace("'", "''") + "' ";

            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();

                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                rsget = cmd.ExecuteReader();
                if (rsget.Read())
                {
                    intUserLebel = Convert.ToInt32(rsget["USER_LEBEL"].ToString());
                    Utility.gstrUserName = rsget["USER_LOGIN_NAME"].ToString();
                    if (rsget["USER_STATUS"].ToString() == "S")
                    {
                        MessageBox.Show("Sorry, The User's has been suspended, Please contact with Administrator");
                        uctxtLogIn.Focus();
                        return;
                    }
                    strPassword = Utility.Decrypt(rsget["USER_PASS"].ToString(), rsget["USER_LOGIN_NAME"].ToString()).ToString();

                    if (uctxtPassword.Text.Trim() != strPassword.Trim())
                    {
                        MessageBox.Show("Login failed. Make sure user name and password are correct.");
                        uctxtPassword.Text = "";
                        uctxtPassword.Focus();
                        return;
                    }
                    rsget.Close();
                    gcnMain.Dispose();
                    uctxtPassword.Text = "";
                    Utility.gstrUserName = uctxtLogIn.Text.Trim().Replace("'", "''");
                    if (intUserLebel == 1)
                    {
                        Utility.gblnAdminPrv = true;
                    }
                    else if (intUserLebel == 2)
                    {
                        Utility.gblnAdminPrv = false;
                    }

                    this.Hide();
                    //Interaction.SaveSetting(Application.ExecutablePath, "sUser", "sName", uctxtLogIn.Text);
                    RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
                    rk.SetValue("sName", uctxtLogIn.Text);
                    rk.Close();
                    if (System.Windows.Forms.Application.OpenForms["frmMain"] as frmMain == null)
                    {
                        frmMain objfrm = new frmMain();
                        objfrm.Show();

                    }
                    else
                    {
                        ((frmMain)Application.OpenForms["frmMain"]).Text = Utility.gstrCompanyID + "-" + Utility.gstrCompanyName + " - " + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString(Utility.DEFAULT_DATE_FORMAT)
                                                                      + " to " + Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString(Utility.DEFAULT_DATE_FORMAT);

                        frmMain objfrm = (frmMain)Application.OpenForms["frmMain"];
                        objfrm.Focus();

                    }

                }
                else
                {
                    MessageBox.Show("Login failed. Make sure user name and password are correct.");
                    uctxtLogIn.Focus();
                    uctxtPassword.Text = "";
                    rsget.Close();
                    gcnMain.Dispose();
                    return;

                }
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void uctxtLogIn_KeyPress(object sender, KeyPressEventArgs e)
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

                btnLogon_Click(sender ,e);

            }
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            frmSelectCompany objfrm = new frmSelectCompany();
            objfrm.strType = "Select";
            objfrm.ShowDialog();
            //Utility.gSelectCompanyName();
            if (Utility.gblnAccessControl==false)
            {
                this.Hide();
                frmMain objfrmmain = new frmMain();
                objfrmmain.ShowDialog();
            }

           
        }

        private void customPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            mload();
        }
        public void mload()
        {
            uctxtLogIn.Select();
            //uctxtLogIn.Text = Interaction.GetSetting(Application.ExecutablePath, "sUser", "sName", "Admin");
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            uctxtLogIn.Text = (String)rk.GetValue("sName", "Admin");
            rk.Close();
            //lblComName.Text = "Company- " + Utility.gstrCompanyName;
        }
        private void btnLogon_Click_1(object sender, EventArgs e)
        {

        }

        private void frmLogIn_Paint(object sender, PaintEventArgs e)
        {
            //GraphicsPath grPath = new GraphicsPath();
            //grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            //this.Region = new System.Drawing.Region(grPath);
            //base.OnPaint(e);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {

        }


       
    }
}
