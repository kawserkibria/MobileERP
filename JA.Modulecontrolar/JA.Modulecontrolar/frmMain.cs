using Dutility;
//using JA.Modulecontrolar.API;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.JINVMS;


using JA.Modulecontrolar.UI.DReport.Accms.ParameterForms;
using JA.Modulecontrolar.UI.DReport.Sales;
using JA.Modulecontrolar.UI.DReport.Sales.Viewer;

using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.UI.Master.Sales;
using JA.Modulecontrolar.UI.Projection.Forms;
using JA.Modulecontrolar.UI.Purchase.Forms;
using JA.Modulecontrolar.UI.Sales.Forms;
using JA.Modulecontrolar.UI.Security.Forms;
using JA.Modulecontrolar.UI.Tools.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JA.Modulecontrolar
{
   
    public partial class frmMain : Form
    {

        private Label theLabel;
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public int intCheckBackup = 0;
        //JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        //JRPT.ISWRPT jrpt = new JRPT.SWRPTClient();
        //JSAPUR.IWSalesPurchase jsalpur = new JSAPUR.WSalesPurchaseClient();
        public frmMain()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            mLoad(strComID);

          
        }
       
       
        public byte[] imgToByteArray(Image img)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                return mStream.ToArray();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //panel1.Visible = false;
            btnInventory.Focus();
        }
        public void mLoad(string strcomID)
        {
          
           // panel1.Width = this.Width;
           // string strRole = "", strDept = "", strDesi = "";

           //// Utility.creaateWrite(strComID);
           // //string strCaption = accms.gSelectCompanyName(strcomID);
          
           // if (Utility.gstrCompanyName == "")
           // {
           //     this.Text = "No Compnany Name Select.....";
           // }
           // else
           // {
           //     this.Text = Utility.gstrCompanyID + "-" + Utility.gstrCompanyName + " - " + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString(Utility.DEFAULT_DATE_FORMAT)
           //                     + " to " + Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString(Utility.DEFAULT_DATE_FORMAT);
           //     //this.Text = strCaption;
           // }

           // if (Utility.gblnAccessControl)
           // {
           //     if (Utility.gstrUserName == null)
           //     {
           //         return;
           //     }
           //     List<UserAccess> objacc = accms.mGetUserAccessData(strcomID, Utility.gstrUserName).ToList();
           //     if (objacc.Count > 0)
           //     {
           //         if (objacc[0].intAccessLevel == 1)
           //         {
           //             strRole = "Administrator";
           //         }
           //         else
           //         {
           //             strRole = "User";
           //         }
           //         if (objacc[0].Department != "")
           //         {
           //             strDept = objacc[0].Department;
           //         }
           //         else
           //         {
           //             strDept = "";
           //         }
           //         if (objacc[0].Designation != "")
           //         {
           //             strDesi = objacc[0].Designation;
           //         }
           //         else
           //         {
           //             strDesi = "";
           //         }
           //     }

           //     Utility.InitialiseMainForm(this, objacc[0].LogInName, strRole, strDesi, strDept, objacc[0].strIamge, userWidgetMetro1);


           // }
           // else
           // {
           //     userWidgetMetro1.Visible = false;
           // }
          
           
           // if (Utility.gblnAccessControl == false)
           // {
           //     userWidgetMetro1.Visible = false;
           // }
           

        }
       
        private void btnExit_Click(object sender, EventArgs e)
        {
            string stMessage = "", strDayName = "", strcomName = "", strFileName = "", strTarget = "", strTarget1 = "", strPath1 = "", strpath2 = "";
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            var strResponse = MessageBox.Show("Would you like to make a backup copy of your data", "Backup Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (strResponse == DialogResult.Yes)
            {
                List<BackupPath> objPath = accms.mGetBackupPath(strComID).ToList();
                if (objPath.Count > 0)
                {
                    strComID = objPath[0].strComID;
                    strcomName = objPath[0].strComName;
                    strDayName = DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("ddd").ToUpper();
                    //strFileName = strFileName + "_" + strDayName + "_JAG_" + strcomName + ".DAT";
                    strFileName = strcomName + "_" + strDayName + "_" + strComID + ".DAT";
                    //strTarget = objPath[0].strPath1 + strFileName;
                    strTarget = objPath[0].strPath1 + "\\" + strFileName;
                    if (strpath2 != " ")
                    {
                        //strTarget1 = objPath[0].strPath2 + strFileName;
                        strTarget1 = objPath[0].strPath2 + "\\" + strFileName;
                    }
                    else
                    {
                        strTarget1 = "";
                    }
                    stMessage = Utility.Backup(strComID, strTarget, strTarget1);
                }
            }
            if (strResponse != DialogResult.Cancel)
            {
                if (strResponse == DialogResult.Yes)
                {
                    MessageBox.Show(stMessage);
                }
                this.Dispose();
                Utility.Kill("DeepLaid");
            }
           
           
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnMaindPrivileges(strComID, Utility.gstrUserName, (int)Utility.MODULE_TYPE.mtACCOUNT))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //if (System.Windows.Forms.Application.OpenForms["frmAccountsMain"] as frmAccountsMain == null)
            //{
            //    frmAccountsMain objfrm = new frmAccountsMain();
            //    objfrm.ContextMenuStrip = new ContextMenuStrip(); 
            //    objfrm.MdiParent = this;
            //    objfrm.Show();

            //}
            //else
            //{
            //    frmAccountsMain objfrm = (frmAccountsMain)Application.OpenForms["frmAccountsMain"];
            //    objfrm.MdiParent = this;
            //    objfrm.Focus();
            //}
            
           
        }

        private void mnuEditCompany_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 52))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            
            Utility.GetCallType.intCallType = 2;
            frmCompanyInstallmentNew objfrm = new frmCompanyInstallmentNew();
            objfrm.MdiParent = this;
            objfrm.Show();
          
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnMaindPrivileges(strComID, Utility.gstrUserName, (int)Utility.MODULE_TYPE.mtSALES))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmSalesMenu"] as frmSalesMenu == null)
            //{
            //    frmSalesMenu objfrm = new frmSalesMenu();
            //    objfrm.ContextMenuStrip = new ContextMenuStrip(); 
            //    objfrm.Show();
            //    objfrm.MdiParent = this;
            //}
            //else
            //{
            //    frmSalesMenu objfrm = (frmSalesMenu)Application.OpenForms["frmSalesMenu"];
            //    objfrm.MdiParent = this;
            //    objfrm.Focus();
            //}
            
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnMaindPrivileges(strComID, Utility.gstrUserName, (int)Utility.MODULE_TYPE.mtPURCHASE))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmPurchaseMenu"] as frmPurchaseMenu == null)
            {
                frmPurchaseMenu objfrm = new frmPurchaseMenu();
                objfrm.ContextMenuStrip=new ContextMenuStrip() ; 
                objfrm.MdiParent = this;
                objfrm.Show();

            }
            else
            {
                frmPurchaseMenu objfrm = (frmPurchaseMenu)Application.OpenForms["frmPurchaseMenu"];
                objfrm.MdiParent = this;
                objfrm.Focus();
            }
           
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnMaindPrivileges(strComID, Utility.gstrUserName, (int)Utility.MODULE_TYPE.mtSTOCK))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (System.Windows.Forms.Application.OpenForms["frmMaster"] as frmMaster == null)
            {
                frmMaster objfrm = new frmMaster();
                objfrm.ContextMenuStrip = new ContextMenuStrip();
                objfrm.MdiParent = this;
                objfrm.Show();

            }
            else
            {
                frmMaster objfrm = (frmMaster)Application.OpenForms["frmMaster"];
                objfrm.MdiParent = this;
                objfrm.Focus();
            }
           
        }

        private void btnSecurty_Click(object sender, EventArgs e)
        {
            frmUserManagement objfrm = new frmUserManagement();
            objfrm.MdiParent = this;
            objfrm.Show();
           
        }

        private void mnuInstallCompany_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 51))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            Utility.GetCallType.intCallType = 1;
            frmCompanyInstallmentNew objfrm = new frmCompanyInstallmentNew();
            objfrm.MdiParent = this;
            objfrm.Show();
          
        }

        private void mnuSelectCompany_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 53))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            frmSelectCompany objfrm = new frmSelectCompany();
            objfrm.strType = "Select";
            objfrm.MdiParent = this;
            objfrm.Show();
            
        }

     

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            string strComID = (String)regKey.GetValue("CompanyID", "0001");
            mLoad(strComID);
        }

        private void btnAccounts_MouseHover(object sender, EventArgs e)
        {
            btnAccounts.BackColor = Color.Yellow;
        }

        private void btnAccounts_MouseLeave(object sender, EventArgs e)
        {
            btnAccounts.BackColor = Color.CornflowerBlue;
        }

        private void btnSales_MouseHover(object sender, EventArgs e)
        {
            btnSales.BackColor = Color.Yellow;
        }

        private void btnSales_Leave(object sender, EventArgs e)
        {
            btnSales.BackColor = Color.Yellow;
        }
        private void btnProjection_MouseHover(object sender, EventArgs e)
        {
            btnProjection.BackColor = Color.Yellow;
        }

        private void btnProjection_MouseLeave(object sender, EventArgs e)
        {
            btnProjection.BackColor = Color.CornflowerBlue;
        }
        private void btnPurchase_MouseHover(object sender, EventArgs e)
        {
            btnPurchase.BackColor = Color.Yellow;
        }

        private void btnPurchase_Leave(object sender, EventArgs e)
        {
            btnPurchase.BackColor = Color.CornflowerBlue;
        }

        private void btnInventory_MouseHover(object sender, EventArgs e)
        {
            btnInventory.BackColor = Color.Yellow;
        }

        private void btnInventory_MouseLeave(object sender, EventArgs e)
        {
            btnInventory.BackColor = Color.CornflowerBlue;
        }

        private void btnTools_MouseHover(object sender, EventArgs e)
        {
            btnTools.BackColor = Color.Yellow;
        }

       

        private void btnSecurty_MouseHover(object sender, EventArgs e)
        {
            btnSecurity.BackColor = Color.Yellow;
        }

        private void btnSecurty_MouseLeave(object sender, EventArgs e)
        {
            btnSecurity.BackColor = Color.CornflowerBlue;
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Yellow;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.CornflowerBlue;
        }

        private void btnSales_MouseLeave(object sender, EventArgs e)
        {
            btnSales.BackColor = Color.CornflowerBlue;
        }

        private void btnTools_MouseLeave(object sender, EventArgs e)
        {

            btnTools.BackColor = Color.CornflowerBlue;
      
        }

        private void btnPurchase_MouseLeave(object sender, EventArgs e)
        {
            btnPurchase.BackColor = Color.CornflowerBlue;
        }

        private void btnTools_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnMaindPrivileges(strComID, Utility.gstrUserName, (int)Utility.MODULE_TYPE.mtTOOLS))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip1.Show(ptLowerLeft);
            //contextMenuStrip1.Show();
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 154))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmUserManagement"] as frmUserManagement == null)
            {
                frmUserManagement objfrm = new frmUserManagement();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.ContextMenuStrip = new ContextMenuStrip(); 
                objfrm.MdiParent = this;
                objfrm.Show();

            }
            else
            {
                frmUserManagement objfrm = (frmUserManagement)Application.OpenForms["frmUserManagement"];
                objfrm.MdiParent = this;
                objfrm.Focus();
            }
        }

        private void userWidgetMetro1_btnLogout_Clicked(object sender, EventArgs e)
        {
            this.Dispose();
            frmLogIn objfrm = new frmLogIn();
            objfrm.ShowDialog();

        }

        private void mnuTrigger_Click(object sender, EventArgs e)
        {
            basTrigger.gCreateTrigger();
            MessageBox.Show("ok");
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            basViewSchemaStock.gCreateViewStock();
            MessageBox.Show("ok");
        }

        private void mnuOption_Click(object sender, EventArgs e)
        {
            frmOption objfrm = new frmOption();
            objfrm.MdiParent = this;
            objfrm.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CreateDefaultdata.mInsertFormContol();
        }

        private void mnuCalculator_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 145))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            System.Diagnostics.Process.Start("calc.exe");
           
        }



        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            string stMessage = "", strDayName = "", strcomName = "", strFileName = "", strTarget = "", strTarget1 = "", strPath1 = "", strpath2 = "";
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            if (intCheckBackup == 1)
            {
                return;
            }
            var strResponse = MessageBox.Show("Would you like to make a backup copy of your data", "Backup Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (strResponse == DialogResult.Yes)
            {
                List<BackupPath> objPath = accms.mGetBackupPath(strComID).ToList();
                if (objPath.Count > 0)
                {
                    strComID = objPath[0].strComID;
                    strcomName = objPath[0].strComName;
                    strDayName = DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("ddd").ToUpper();
                    //strFileName = strFileName + "_" + strDayName + "_JAG_" + strcomName + ".DAT";
                    strFileName = strcomName + "_" + strDayName + "_" + strComID + ".DAT";
                    strTarget = objPath[0].strPath1 + "\\" + strFileName;
                    if (strpath2 != " ")
                    {
                        //strTarget1 = objPath[0].strPath2 + strFileName;
                        strTarget1 = objPath[0].strPath2 + "\\" + strFileName;
                    }
                    else
                    {
                        strTarget1 = "";
                    }
                    stMessage = Utility.Backup(strComID, strTarget, strTarget1);
                }
            }

            if (strResponse != DialogResult.Cancel)
            {
                if (strResponse == DialogResult.Yes)
                {
                    MessageBox.Show(stMessage);
                }

                e.Cancel = false;
                this.Dispose();
                Utility.Kill("DeepLaid");
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void mnuBackUp_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 152))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmBackup"] as frmBackup == null)
            {
                frmBackup objfrm = new frmBackup();
                objfrm.Show();
                objfrm.MdiParent = this;
            }
            else
            {
                frmBackup objfrm = (frmBackup)Application.OpenForms["frmBackup"];
                objfrm.Focus();
            }
           
            
        }

        private void mnuDeleteCompany_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 142))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmSelectCompany"] as frmSelectCompany == null)
            {
                frmSelectCompany objfrm = new frmSelectCompany();
                objfrm.strType = "Delete";
                objfrm.MdiParent = this;
                objfrm.Show();

            }
            else
            {
                frmSelectCompany objfrm = (frmSelectCompany)Application.OpenForms["frmSelectCompany"];
                objfrm.Focus();
            }
           
          
        }

      

        private void mnuRestore_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 153))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            
            string strDatabse = "",strMsg="",strRestoreFile="";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "DAT (*.DAT)|*.DAT";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var strResponse = MessageBox.Show("Confirm restore, this will destroy current data and restore previous data", "Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    strRestoreFile=openFileDialog1.FileName;
                    strDatabse = openFileDialog1.FileName;
                    strDatabse = "SMART" + Utility.Left(Utility.Right(strDatabse, 8),4);
                    strMsg = Utility.Restore(strComID, strDatabse, strRestoreFile);
                    MessageBox.Show(strMsg);

                }
            }
        }

        private void mnuDecryptPass_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 155))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmDecryptPassword"] as frmDecryptPassword == null)
            {
                frmDecryptPassword objfrm = new frmDecryptPassword();
                objfrm.Show();
                objfrm.MdiParent = this;

            }
            else
            {
                frmDecryptPassword objfrm = (frmDecryptPassword)Application.OpenForms["frmDecryptPassword"];
                objfrm.Focus();
            }
            
            
        }

        private void mnuChangePassword_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 146))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            
            if (Utility.gblnAccessControl==false)
            {
                MessageBox.Show("No User Found! User Access Should be Yes");
                return;
            }
            
            //frmChangePassword objfrm = new frmChangePassword();
            //objfrm.MdiParent = this;
            //objfrm.Show();
            if (System.Windows.Forms.Application.OpenForms["frmUserManagement"] as frmUserManagement == null)
            {
                frmUserManagement objfrm = new frmUserManagement();
                objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                objfrm.strFormName = "Change PassWord";
                objfrm.Show();
                objfrm.MdiParent = this;

            }
            else
            {
                frmUserManagement objfrm = (frmUserManagement)Application.OpenForms["frmUserManagement"];
                objfrm.Focus();
            }
           
        }

        private void mnuSignatoryOption_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 147))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmAudit"] as frmAudit == null)
            {
                frmVoucherPrinting objfrm = new frmVoucherPrinting();
                objfrm.lngFormPriv = 147;
                objfrm.Show();
                objfrm.MdiParent = this;

            }
            else
            {
                frmAudit objfrm = (frmAudit)Application.OpenForms["frmAudit"];
                objfrm.Focus();

            }
           
            
        }

        private void mnuAudit_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 149))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmAudit"] as frmAudit == null)
            {
                frmAudit objfrm = new frmAudit();
                objfrm.Show();
                objfrm.MdiParent = this;

            }
            else
            {
                frmAudit objfrm = (frmAudit)Application.OpenForms["frmAudit"];
                objfrm.Focus();

            }
          
          
        }

        private void mnuERPStattistics_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 150))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmRptStatistics"] as frmRptStatistics == null)
            {
                frmRptStatistics objfrm = new frmRptStatistics();
                objfrm.strReportName = "ERP Statistics";
                objfrm.Show();
                objfrm.MdiParent = this;

            }
            else
            {
                frmRptStatistics objfrm = (frmRptStatistics)Application.OpenForms["frmRptStatistics"];
                objfrm.Focus();
               
            }
          
            
        }

        private void mnuSplitCompany_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 143))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmSplitCompany"] as frmSplitCompany == null)
            {
                frmSplitCompany objfrm = new frmSplitCompany();
                objfrm.Show(); ;
                objfrm.MdiParent = this;
            }
            else
            {
                frmSplitCompany objfrm = (frmSplitCompany)Application.OpenForms["frmSplitCompany"];
                objfrm.Focus();
            }
           
           
        }

        private void mnuCopyChartofAccounts_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 156))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmCopyChartOfAccounts"] as frmCopyChartOfAccounts == null)
            {
                frmCopyChartOfAccounts objfrm = new frmCopyChartOfAccounts();
                objfrm.Show();
                objfrm.MdiParent = this;
            }
            else
            {
                frmCopyChartOfAccounts objfrm = (frmCopyChartOfAccounts)Application.OpenForms["frmCopyChartOfAccounts"];
                objfrm.Focus();
            }
           
            
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmAboutDeeplaidERP"] as frmAboutDeeplaidERP == null)
            {
                frmAboutDeeplaidERP objfrm = new frmAboutDeeplaidERP();
                objfrm.Show();
                objfrm.MdiParent = this;

            }
            else
            {
                frmAboutDeeplaidERP objfrm = (frmAboutDeeplaidERP)Application.OpenForms["frmAboutDeeplaidERP"];
                objfrm.Focus();
            }
            
           
        }

        private void mnuTransactionLock_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 144))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
        }

        private void mnuRebuidQuery_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 151))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }

            basViewSchemaAccount.CreateLedgerGroupView();
            MessageBox.Show("Rebuild Ok...", "Rebuild Query", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuReValuation_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 148))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
        }

        //private void btnHRPayroll_Click(object sender, EventArgs e)
        //{

        //    //Kill("ExtraReports");
        //    //const string ex2 = @"\\Mayhedi\SetupExtra\ExtraReports.application";
        //    ////var ex2 = GetPath(File);
        //    //System.Diagnostics.Process.Start(ex2);
        //    ////MessageBox.Show("Under Construction...");
        //    if (Utility.gblnAccessControl)
        //    {
        //        if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 156))
        //        {
        //            MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //    }
        //    if (System.Windows.Forms.Application.OpenForms["frmCopyChartOfAccounts"] as frmCopyChartOfAccounts == null)
        //    {
        //        frmCopyChartOfAccounts objfrm = new frmCopyChartOfAccounts();
        //        objfrm.Show();
        //        objfrm.MdiParent = this;
        //    }
        //    else
        //    {
        //        frmCopyChartOfAccounts objfrm = (frmCopyChartOfAccounts)Application.OpenForms["frmCopyChartOfAccounts"];
        //        objfrm.Focus();
        //    }
           
        //}
        //public static bool Kill(string args)
        //{
        //    foreach (Process proc in Process.GetProcessesByName(args))
        //    {
                
        //        proc.Kill();
        //    }



        //    return false;


        //}

        private void btnPF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Construction...");
        }

        private void commissionGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 54))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmStockTree"] as frmStockTree == null)
            //{
            //    frmStockTree objfrm = new frmStockTree();
            //    objfrm.strName = "2";
            //    objfrm.Show();
            //    objfrm.MdiParent = this;


            //}
            //else
            //{
            //    frmStockTree objfrm = (frmStockTree)Application.OpenForms["frmStockTree"];
            //    objfrm.Focus();
            //}
           
        }

        private void stockGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 55))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmStockTree"] as frmStockTree == null)
            //{
            //    frmStockTree objfrm = new frmStockTree();
            //    objfrm.strName = "1";
            //    objfrm.Show();
            //    objfrm.MdiParent = this;


            //}
            //else
            //{
            //    frmStockTree objfrm = (frmStockTree)Application.OpenForms["frmStockTree"];
            //    objfrm.Focus();
               
            //}
          
        }

        private void packSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 56))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmStockTree"] as frmStockTree == null)
            //{
            //    frmStockTree objfrm = new frmStockTree();
            //    objfrm.strName = "3";
            //    objfrm.Show();
            //    objfrm.MdiParent = this;


            //}
            //else
            //{
            //    frmStockTree objfrm = (frmStockTree)Application.OpenForms["frmStockTree"];
            //    objfrm.Focus();
                
            //}
           
        }

        private void stockItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 61))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmStockTree"] as frmStockTree == null)
            //{
            //    frmStockTree objfrm = new frmStockTree();
            //    objfrm.strName = "1";
            //    objfrm.Show();
            //    objfrm.MdiParent = this;


            //}
            //else
            //{
            //    frmStockTree objfrm = (frmStockTree)Application.OpenForms["frmStockTree"];
            //    objfrm.Focus();
            //}
          
        }

        private void supplierGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 41))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmStockTree"] as frmStockTree == null)
            //{
            //    frmTreeView objfrm = new frmTreeView();
            //    objfrm.strType = "C";
            //    objfrm.Show();
            //    objfrm.MdiParent = this;

            //}
            //else
            //{
            //    frmTreeView objfrm = (frmTreeView)Application.OpenForms["frmTreeView"];
            //    objfrm.Focus();
                
            //}
          
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 42))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmTreeView"] as frmStockTree == null)
            //{
            //    frmTreeView objfrm = new frmTreeView();
            //    objfrm.strType = "C";
            //    objfrm.Show();
            //    objfrm.MdiParent = this;
            //}
            //else
            //{
            //    frmTreeView objfrm = (frmTreeView)Application.OpenForms["frmTreeView"];
            //    objfrm.Focus();
            //}
           
        }

        private void mPOGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 1))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmTreeView"] as frmTreeView == null)
            //{
            //    frmTreeView objfrm = new frmTreeView();
            //    objfrm.strType = "M";
            //    objfrm.Show();
            //    objfrm.MdiParent = this;
            //}
            //else
            //{
            //    frmTreeView objfrm = (frmTreeView)Application.OpenForms["frmTreeView"];
            //    objfrm.Focus();
            //}
           
        }

        private void mPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 2))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmTreeView"] as frmTreeView == null)
            //{
            //    frmTreeView objfrm = new frmTreeView();
            //    objfrm.strType = "M";
            //    objfrm.Show();
            //    objfrm.MdiParent = this;
            //}
            //else
            //{
            //    frmTreeView objfrm = (frmTreeView)Application.OpenForms["frmTreeView"];
            //    objfrm.Focus();
            //}
           
        }

        private void doctorCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 4))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmTreeView"] as frmTreeView == null)
            //{
            //    frmTreeView objfrm = new frmTreeView();
            //    objfrm.strType = "S";
            //    objfrm.Show();
            //    objfrm.MdiParent = this;
            //}
            //else
            //{
            //    frmTreeView objfrm = (frmTreeView)Application.OpenForms["frmTreeView"];
            //    objfrm.Focus();
            //}
           
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 95))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmTreeView"] as frmTreeView == null)
            //{
            //    frmTreeView objfrm = new frmTreeView();
            //    objfrm.strType = "";
            //    objfrm.Show();
            //    objfrm.MdiParent = this;
            //}
            //else
            //{
            //    frmTreeView objfrm = (frmTreeView)Application.OpenForms["frmTreeView"];
            //    objfrm.Focus();
            //}
            
        }

        private void accountsLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 96))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmTreeView"] as frmTreeView == null)
            //{
            //    frmTreeView objfrm = new frmTreeView();
            //    objfrm.Show();
            //    objfrm.MdiParent = this;
            //}
            //else
            //{
            //    frmTreeView objfrm = (frmTreeView)Application.OpenForms["frmTreeView"];
            //    objfrm.Focus();
            //}
           
        }

        private void costCategoryCostCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 97))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //if (System.Windows.Forms.Application.OpenForms["frmTreeView"] as frmTreeView == null)
            //{
            //    frmTreeView objfrm = new frmTreeView();
            //    objfrm.strType = "N";
            //    objfrm.Show();
            //    objfrm.MdiParent = this;
            //}
            //else
            //{
            //    frmTreeView objfrm = (frmTreeView)Application.OpenForms["frmTreeView"];
            //    objfrm.Focus();
               
            //}
           
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    btnExit.PerformClick();
                }
            }
            //if (e.KeyCode == Keys.I && e.Modifiers == Keys.Control)
            //{
            //    btnInventory.PerformClick();
            //}
            //else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            //{
            //    btnPurchase.PerformClick();
            //}
            //else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            //{
            //    btnSales.PerformClick();
            //}
            //else if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            //{
            //    btnAccounts.PerformClick();
            //}

            //else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
            //{
            //    btnSecurity.PerformClick();
            //}
        }

        private void mnuRebuildSerial_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmIndex"] as frmIndex == null)
            {
                frmIndex objfrm = new frmIndex();
                objfrm.strFormType = "S";
                objfrm.Show();
                objfrm.MdiParent = this;
            }
            else
            {
                frmIndex objfrm = (frmIndex)Application.OpenForms["frmIndex"];
                objfrm.Focus();
              
            }
        }

        private void mnuReindex_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmIndex"] as frmIndex == null)
            {
                frmIndex objfrm = new frmIndex();
                objfrm.strFormType = "I";
                objfrm.MdiParent = this;
                objfrm.Show();

                
            }
            else
            {
                frmIndex objfrm = (frmIndex)Application.OpenForms["frmIndex"];
                objfrm.Focus();
              
            }
        }

        private void mnuUpdateSIAccvoucher_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmScript"] as frmScript == null)
            {
                frmScript objfrm = new frmScript();
                objfrm.strFormType = "SI";
                objfrm.MdiParent = this;
                objfrm.Show();
            }
            else
            {
                frmScript objfrm = (frmScript)Application.OpenForms["frmScript"];
                objfrm.Focus();

            }
        }

        private void mnuUpdateAccVoucher_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmScript"] as frmScript == null)
            {
                frmScript objfrm = new frmScript();
                objfrm.strFormType = "AC";
                objfrm.MdiParent = this;
                objfrm.Show();
            }
            else
            {
                frmScript objfrm = (frmScript)Application.OpenForms["frmScript"];
                objfrm.Focus();

            }
        }

        private void mnuBkashMpoList_Click(object sender, EventArgs e)
        {
            frmReportViewer frmviewer = new frmReportViewer();
            frmviewer.selector = ViewerSelector.BKash;
            frmviewer.Show();

        }
        
        private void mnuExtraReports_Click(object sender, EventArgs e)
        {
            //        Project_B pb = new Project_B();
            //Process.Start(pb.returnPath() + \\"Project_B.exe");
        }

        private void mnuGroupOpening_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmScript"] as frmScript == null)
            {
                frmScript objfrm = new frmScript();
                objfrm.strFormType = "AG";
                objfrm.MdiParent = this;
                objfrm.Show();
            }
            else
            {
                frmScript objfrm = (frmScript)Application.OpenForms["frmScript"];
                objfrm.Focus();

            }
        }

       

        private void mnuProcedure_Click(object sender, EventArgs e)
        {
            basProcedure.gCreateAdavanceSP();
            MessageBox.Show("OK");
        }

        private void btnProjection_Click(object sender, EventArgs e)
        {
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnMaindPrivileges(strComID, Utility.gstrUserName, (int)Utility.MODULE_TYPE.mtProjection))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.gblnMaindPrivileges(strComID, Utility.gstrUserName, 10))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (System.Windows.Forms.Application.OpenForms["frmProMain"] as frmProMain == null)
            {
                frmProMain objfrm = new frmProMain();
                objfrm.Show();
                objfrm.MdiParent = this;
            }
            else
            {
                frmProMain objfrm = (frmProMain)Application.OpenForms["frmProMain"];
                objfrm.Focus();

            }
        }

        private void mnuUpdateAvgcost_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["frmUpdateAVG"] as frmUpdateAVG == null)
            {
                frmUpdateAVG objfrm = new frmUpdateAVG();
                objfrm.MdiParent = this;
                objfrm.Show();
            }
            else
            {
                frmUpdateAVG objfrm = (frmUpdateAVG)Application.OpenForms["frmUpdateAVG"];
                objfrm.Focus();

            }
        }

        private void treeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

       

     


     

       

       

       

      
       

    
     

      

      

        

    

      

       

       

       

       

        

       

        

        

    }
}
