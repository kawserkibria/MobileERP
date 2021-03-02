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
using Microsoft.Win32;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmDecryptPassword : Form
    {
       
        public frmDecryptPassword()
        {
            InitializeComponent();
        }
       
      

        private void frmDecryptPassword_Load(object sender, EventArgs e)
        {
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnShow_Click(object sender, EventArgs e)
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
                    strPassword = Utility.Decrypt(rsget["USER_PASS"].ToString(), rsget["USER_LOGIN_NAME"].ToString()).ToString();
                    uctxtPassword.Text = strPassword;
                }
                else
                {
                    MessageBox.Show("Login Name Not Correct");
                    uctxtLogIn.Focus();
                    uctxtPassword.Text = "";
                }

                rsget.Close();
                gcnMain.Dispose();
            }
        }

       



    }
}
