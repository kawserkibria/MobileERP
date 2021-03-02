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
using System.Reflection;


namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmAboutDeeplaidERP : Form
    {
        string strComID { get; set; }
 
      
        public frmAboutDeeplaidERP()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAboutDeeplaidERP_Load(object sender, EventArgs e)
        {
            string w_file = "JA.Modulecontrolar.exe";
            string w_directory = Directory.GetCurrentDirectory();
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            lblSoftwareVerson.Text = version.ToString();
            DateTime c3 = File.GetLastWriteTime(System.IO.Path.Combine(w_directory, w_file));
            lblSoftwarebuilddate.Text = c3.ToString("dd-MM-yyyy hh:mm:ss tt");
            SqlConnection con = new SqlConnection(Utility.SQLConnstringComSwitch(strComID));
            con.Open();
            lblDatabaseVerson.Text = con.ServerVersion;
            con.Close();
        }

       

       

      

       
    
       
    }
}