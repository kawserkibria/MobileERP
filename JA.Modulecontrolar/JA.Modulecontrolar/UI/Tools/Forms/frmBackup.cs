using Dutility;
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
using System.IO;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.JINVMS;
using System.Threading;

namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmBackup : Form
    {
        private string strComID { get; set; }
        JACCMS.SWJAGClient accms = new SWJAGClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        List<BackupPath> objPath;
        public frmBackup()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            string stMessage="",strDayName = "", strcomName = "", strFileName = "", strTarget = "", strTarget1 = "", strPath1 = "", strpath2 = "",strTextBox="";
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            if (uctxtBackupPath1.Text =="")
            {
                MessageBox.Show("Backup Path Cannot be Empty");
                uctxtBackupPath1.Focus();
                return;
            }
            if (uctxtBackupPath2.Text ==" ")
            {
                strTextBox = "";
            }
            else
            {
                strTextBox = uctxtBackupPath2.Text;
            }
            string i = Utility.mUpdateBackupPath(strComID, uctxtBackupPath1.Text, strTextBox);
            var strResponse = MessageBox.Show("Would you like to make a backup copy of your data", "Button", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (strResponse == DialogResult.Yes)
            {
                if (i=="1")
                {
                    strPath1 = uctxtBackupPath1.Text;
                    if (uctxtBackupPath2.Text != "")
                    {
                        strpath2 = uctxtBackupPath2.Text;
                    }
                    if (chkAllCompany.Checked==false)
                    {
                        strComID = objPath[0].strComID;
                        strcomName = objPath[0].strComName;
                        strDayName = DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("ddd").ToUpper();
                        //strFileName = strFileName + "_" + strDayName + "_JAG_" + strcomName + ".DAT";
                        strFileName = strcomName + "_" + strDayName + "_" + strComID + ".DAT";
                        strTarget = strPath1 + "\\" + strFileName;
                        if (strpath2 != " ")
                        {
                            strTarget1 = strpath2 + "\\" + strFileName;
                        }
                        else
                        {
                            strTarget1 = "";
                        }
                        stMessage = Utility.Backup(strComID,strTarget, strTarget1);
                    }
                    else
                    {
                        List<DatabaseCompany> oodc = invms.mloadDatabaseCompnay(strComID).ToList();
                        if (oodc.Count > 0)
                        {
                            foreach (DatabaseCompany odc in oodc)
                            {
                                strComID = odc.strComID;
                                strcomName = odc.strComName;
                                strDayName = DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("ddd").ToUpper();
                                strFileName = strcomName + "_" + strDayName + "_" + strComID + ".DAT";
                                strTarget = strPath1 + "\\" + strFileName;
                                if (strpath2 != " ")
                                {
                                    strTarget1 = strpath2 + "\\" + strFileName;
                                }
                                else
                                {
                                    strTarget1 = "";
                                }

                                stMessage = Utility.Backup(strComID, strTarget, strTarget1);

                            }


                        }
                    }

                    
                    MessageBox.Show(stMessage);

                }

            }
            

        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            objPath = accms.mGetBackupPath(strComID).ToList();
            if (objPath.Count>0)
            {
                txtCompanyName.Text = objPath[0].strComName;
                uctxtBackupPath1.Text = objPath[0].strPath1;
                uctxtBackupPath2.Text = objPath[0].strPath2;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lvDetails_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(sender, e);
        }

        private void btnPath1_Click(object sender, EventArgs e)
        {
            //folderBrowserDialog1.ShowDialog();
            string selectedPath="";
            var t = new Thread((ThreadStart)(() =>            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
                fbd.ShowNewFolderButton = true;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                    return;

                selectedPath = fbd.SelectedPath;
                //string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                //uctxtBackupPath1.Text = fbd.SelectedPath.ToString();
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            //Console.WriteLine(selectedPath);
            if (selectedPath != "")
            {
                uctxtBackupPath1.Text = selectedPath;
            }
            

            //DialogResult result = folderBrowserDialog1.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
            //    uctxtBackupPath1.Text = folderBrowserDialog1.SelectedPath;

            //}
        }

        private void btnPath2_Click(object sender, EventArgs e)
        {
            string selectedPath="";
            var t = new Thread((ThreadStart)(() =>
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
                fbd.ShowNewFolderButton = true;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                    return;

                selectedPath = fbd.SelectedPath;
                //string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                //uctxtBackupPath2.Text = selectedPath;
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            if (selectedPath != "")
            {
                uctxtBackupPath2.Text = selectedPath;
            }
            
            //DialogResult result = folderBrowserDialog1.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
            //    uctxtBackupPath2.Text = folderBrowserDialog1.SelectedPath;

            //}
        }

        //private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        //{

        //}


    }
}
