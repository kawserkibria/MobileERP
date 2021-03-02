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
    public partial class frmItemSearch : Form
    {

        public frmItemSearch()
        {
            InitializeComponent();
        }



        private void frmItemSearch_Load(object sender, EventArgs e)
        {
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string strSQL;
            SqlDataReader rsget;

          

            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnMain.State == ConnectionState.Open)
                {
                    gcnMain.Close();
                }
                gcnMain.Open();
                strSQL = "SELECT STOCKITEM_NAME FROM INV_STOCKITEM ";
                strSQL = strSQL + "WHERE STOCKITEM_ALIAS = '" + uctxtItemCode.Text.Trim().Replace("'", "''") + "' ";
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                rsget = cmd.ExecuteReader();
                if (rsget.Read())
                {
                    uctxtItemName.Text = rsget["STOCKITEM_NAME"].ToString();
                }
                else
                {
                    MessageBox.Show("Item Code Not Correct");
                    uctxtItemCode.Focus();
                    uctxtItemName.Text = "";
                }

                rsget.Close();
                gcnMain.Dispose();
            }
        }

       



    }
}
