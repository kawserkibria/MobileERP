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
using System.Security.AccessControl;
using ExtraReports.JINVMS;



namespace ExtraReports
{
    public partial class frmSelectCompany : Form
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        //JACCMS.SWJAGClient accms = new SWJAGClient();
        public string strType { get; set; }
        private string strComID { get; set; }
        public frmSelectCompany()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }
        private void FormatGrid()
        {
            lvDetails.CheckBoxes = false;
            lvDetails.Columns.Add("Id", 0, HorizontalAlignment.Center);
            lvDetails.Columns.Add("Name", 200, HorizontalAlignment.Left);
            lvDetails.Columns.Add("From Date", 150, HorizontalAlignment.Left);
            lvDetails.Columns.Add("To Date", 150, HorizontalAlignment.Left);
            lvDetails.Columns.Add("Status", 150, HorizontalAlignment.Left);
        }

        private void mLoadDetails()
        {
            lvDetails.Items.Clear();
            int i = 0;
            List<DatabaseCompany> oodc = invms.mloadDatabaseCompnay(strComID).ToList();
            if (oodc.Count > 0)
            {
                foreach (DatabaseCompany bo in oodc)
                {
                    ListViewItem itm = new ListViewItem(bo.strComID);
                    //itm.SubItems.Add(bo.strComID + "-" bo.strComName);
                    itm.SubItems.Add(bo.strComName);
                    itm.SubItems.Add(bo.strFDate);
                    itm.SubItems.Add(bo.strTDate);
                    if (bo.strComID == Utility.gstrCompanyID)
                    {
                        //itm.SubItems.Add("Running");
                        itm.SubItems.Add("Running", Color.Red, Color.Yellow, lvDetails.Font);
                        itm.SubItems[3].ForeColor = Color.Red;
                        itm.SubItems[3].BackColor = Color.Red;
                    }
                    else
                    {
                        //itm.SubItems.Add("Initial");
                        itm.SubItems.Add("Initial", Color.Black, Color.White, lvDetails.Font);
                    }
                   
                    lvDetails.Items.Add(itm);
                }
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string strCompanyID;
            try
            {
                if (strType == "Select")
                {
                    if (lvDetails.SelectedItems.Count > 0)
                    {
                        ListViewItem itm = lvDetails.SelectedItems[0];
                        strCompanyID = itm.SubItems[0].Text;

                        RegistryKey regKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
                        if (regKey != null)
                        {
                            //string user = Environment.UserDomainName + "\\" + Environment.UserName;
                            //RegistrySecurity rs = new RegistrySecurity();
                            //rs.AddAccessRule(new RegistryAccessRule(user, RegistryRights.ReadKey | RegistryRights.WriteKey | RegistryRights.Delete, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow));//To allow permission
                            //RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SmartAccounts");
                            regKey.SetValue("CompanyID", strCompanyID);
                            regKey.Close();
                        }

                        Utility.strDataBase = "SMART" + strCompanyID;
                        Utility.gSelectCompanyName(strCompanyID, "NO");
                        //string s = accms.gSelectCompanyName(strCompanyID);
                        if (Utility.gblnAccessControl == true)
                        {
                            if (System.Windows.Forms.Application.OpenForms["frmMain"] as frmERMain == null)
                            {
                                frmERMain objfrmmain = new frmERMain();
                                //objfrmmain.intCheckBackup = 1;
                                objfrmmain.Close();

                            }
                            else
                            {
                                ((frmERMain)Application.OpenForms["frmERMain"]).Text = Utility.gstrCompanyID + "-" + Utility.gstrCompanyName + " - " + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString(Utility.DEFAULT_DATE_FORMAT)
                                                                      + " to " + Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString(Utility.DEFAULT_DATE_FORMAT);
                                frmERMain objfrm = (frmERMain)Application.OpenForms["frmERMain"];
                                //objfrm.intCheckBackup = 1;
                                objfrm.Close();
                            }
                            this.Close();

                            //if (System.Windows.Forms.Application.OpenForms["frmLogIn"] as frmELogIn == null)
                            //{

                            //    frmELogIn objfrmlogin = new frmELogIn();
                            //    objfrmlogin.mload();
                            //    objfrmlogin.ShowDialog();
                               

                            //}
                            //else
                            //{
                            //    frmELogIn objfrmlogin = (frmELogIn)Application.OpenForms["frmELogIn"];
                            //    objfrmlogin.mload();
                            //    objfrmlogin.Show();
                            //    objfrmlogin.Focus();
                               
                            //}

                            //frmLogIn objfrmlogin = new frmLogIn();
                            //objfrmlogin.ShowDialog();

                        }
                        else
                        {
                            //this.Dispose();
                            //frmMain objfrm = new frmMain();
                            ////((frmMain)Application.OpenForms["frmMain"]).Text = s;
                            //objfrm.Refresh();

                            //((frmMain)Application.OpenForms["frmMain"]).Text = Utility.gstrCompanyID + "-" + Utility.gstrCompanyName + " - " + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString(Utility.DEFAULT_DATE_FORMAT)
                            //                                                + " to " + Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString(Utility.DEFAULT_DATE_FORMAT);

                            if (System.Windows.Forms.Application.OpenForms["frmERMain"] as frmERMain == null)
                            {
                                frmERMain objfrmmain = new frmERMain();
                                //objfrmmain.intCheckBackup = 1;
                                //objfrmmain.Show();

                            }
                            else
                            {
                                ((frmERMain)Application.OpenForms["frmERMain"]).Text = Utility.gstrCompanyID + "-" + Utility.gstrCompanyName + " - " + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString(Utility.DEFAULT_DATE_FORMAT)
                                                                      + " to " + Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString(Utility.DEFAULT_DATE_FORMAT);
                                frmERMain objfrm = (frmERMain)Application.OpenForms["frmERMain"];
                                //objfrm.intCheckBackup = 1;
                                objfrm.Focus();
                            }
                            this.Close();
                        }


                    }
                }

                else
                {
                    if (lvDetails.SelectedItems.Count > 0)
                    {
                        ListViewItem itm = lvDetails.SelectedItems[0];
                        strCompanyID = "SMART" + itm.SubItems[0].Text;
                        string strmsg = Utility.DeleteCompnay(itm.SubItems[0].Text, strCompanyID);
                        if (strmsg == "1")
                        {
                            //Utility.creaateWrite("0001");
                            Utility.Kill("DeepLaid");
                            this.Dispose();
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       

        private void frmSelectCompany_Load(object sender, EventArgs e)
        {
            if (strType =="Select")
            {
                btnOK.Text = "OK";
            }
            else
            {
                this.Text = "Delete Company";
                btnOK.Text = "Delete";
            }
            
            FormatGrid();
            mLoadDetails();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lvDetails_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(sender, e);
        }

        private void lvDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string mm = invms.mloadDatabaseCompnaytest();
            //MessageBox.Show(mm);
        }



    }
}
