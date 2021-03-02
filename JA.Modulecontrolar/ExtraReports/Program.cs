using Dutility;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraReports
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string conDb;
            string ServerName;
            string strSQL;
            SqlDataReader dr;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            ServerName = Utility.gGetServerName();
            //conDb = "Data Source=" + ServerName + ";Initial Catalog= " + "SMART" + Utility.strDataBase + ";User ID=" + Utility. + " ;Password=" + Utility.gstrpassword + " ";
            conDb = "Data Source=" + ServerName + ";Initial Catalog=master;User ID=" + Utility.gstDatabaserUserName + " ;Password=" + Utility.gstDatabasePassword + " ";
            strSQL = "SELECT NAME FROM master.dbo.sysdatabases WHERE NAME like 'SMART%' ";
            using (SqlConnection gcnMain = new SqlConnection(conDb))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();
                SqlCommand cmd = new SqlCommand(strSQL, gcnMain);
                cmd.CommandText = strSQL;

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    try
                    {

                        RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
                        if (regKey == null)
                        {

                            string user = Environment.UserDomainName + "\\" + Environment.UserName;
                            RegistrySecurity rs = new RegistrySecurity();
                            rs.AddAccessRule(new RegistryAccessRule(user, RegistryRights.ReadKey | RegistryRights.WriteKey | RegistryRights.Delete, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow));//To allow permission
                            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
                            rk.SetValue("CompanyID", "0001");
                            Utility.gstrCompanyID = (String)rk.GetValue("CompanyID", "0001");
                            rk.Close();
                        }
                        else
                        {
                            Utility.gstrCompanyID = (String)regKey.GetValue("CompanyID", "0001");
                        }

                        // splash();
                        //Application.Run(new frmSplash());

                        Utility.gblnBranch = true;
                        Utility.gSelectCompanyName(Utility.gstrCompanyID, "NO");

                        if (Utility.gblnAccessControl)
                        {
                        //    Application.Run(new frmELogIn());
                        //}
                        //else
                        //{
                            Application.Run(new frmERMain());


                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());

                    }
                }
                else
                {
                    //RegistryKey regKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
                    //regKey.SetValue("gstrDataBaseName", string.Empty);
                    //regKey.SetValue("CompanyID", string.Empty);
                    //Utility.strDataBase = "master";
                    //Utility.GetCallType.intCallType = 1;
                    //Application.Run(new frmCompanyInstallmentNew());
                    //frmCompanyInstallmentNew frm1 = new frmCompanyInstallmentNew();
                    //frm1.Hide();
                    MessageBox.Show("No Compnay Found");
                }
            }

        }
    }
}
