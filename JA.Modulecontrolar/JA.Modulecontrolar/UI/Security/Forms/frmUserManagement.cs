using Dutility;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace JA.Modulecontrolar.UI.Security.Forms
{
    public partial class frmUserManagement : JA.Shared.UI.frmSmartFormStandard
    {
        OpenFileDialog open1 = new OpenFileDialog();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        string _strImageName = "";
        private string strComID { get; set; }
        public string strFormName { get; set; }
        public int m_action {get;set;}
        private byte[] _imageData;
        byte[] img;
        public frmUserManagement()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtLogInName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLogInName_KeyPress);
            this.uctxtFullName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFullName_KeyPress);
            this.uctxtDepartment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDepartment_KeyPress);
            this.uctxtDesignation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDesignation_KeyPress);
            this.uctxtPasswoed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtPasswoed_KeyPress);
            this.txtOldPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtOldPassWord_KeyPress);

            this.cboAccessLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboAccessLevel_KeyPress);
            this.cboStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboStatus_KeyPress);
            this.uctxtcomments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtcomments_KeyPress);
        }

        #region "User Define"
        private void uctxtcomments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();

            }
        }
        private void cboStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtcomments.Focus();

            }
        }
        private void cboAccessLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                cboStatus.Focus();

            }
        }
        private void uctxtPasswoed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (cboAccessLevel.Enabled)
                {
                    cboAccessLevel.Focus();
                }
                else
                {
                    cboStatus.Focus();
                }

            }
        }
        private void txtOldPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtPasswoed.Focus();

            }
        }
        private void uctxtDesignation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (strFormName == "Change PassWord")
                {
                    txtOldPassWord.Focus();
                }
                else
                {
                    uctxtPasswoed.Focus();
                }

            }
        }
        private void uctxtDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtDesignation.Focus();

            }
        }
        private void uctxtLogInName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtFullName.Focus();

            }
        }
        private void uctxtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtDepartment.Focus();

            }
        }
        #endregion

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            open1.Multiselect = true;

            string selectedPath = "";
            var t = new Thread((ThreadStart)(() =>
            {
                DialogResult result1 = open1.ShowDialog(); ;
                open1.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                string ext1 = System.IO.Path.GetExtension(open1.FileName);
                if (result1 == DialogResult.Cancel)
                    return;

                selectedPath = ext1;

                //string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                //uctxtBackupPath1.Text = fbd.SelectedPath.ToString();
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            //DialogResult result1 = open1.ShowDialog();
            ////open1.Filter = "allfiles|*";
            //open1.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
            //string ext1 = System.IO.Path.GetExtension(open1.FileName);
            if (selectedPath !="")
            //{
                if (pbImage.Image == null || pbImage.Image != null)
                {
                    _strImageName = open1.FileName;
                    pbImage.Image = new Bitmap(open1.OpenFile());
                    pbImage.Image = Utility.ScaleImage(pbImage.Image, 220, 257);
                }
                return;
            //}
          
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string vstrPassword = "", strDuplicate="";
            if (uctxtLogInName.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtLogInName.Focus();
                return;
            }

            if (uctxtPasswoed.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtPasswoed.Focus();
                return;
            }
            if (uctxtPasswoed.Text.Length < 6)
            {
                MessageBox.Show("Lenght Should be More then 6");
                uctxtPasswoed.Focus();
                return;
            }
             if (strFormName =="Change PassWord")
             {
                 if (txtOldPassWord.Text == "")
                 {
                     MessageBox.Show("Old PassWord Cannot be Empty");
                     txtOldPassWord.Focus();
                     return;
                 }

                 string vstrOldPass = Utility.gstrGetOldPassWord(strComID, Utility.gstrUserName);
                 //vstrOldPass = Utility.Decrypt(strstring, Utility.gstrUserName);
                 //Utility.Decrypt(rsget["USER_PASS"].ToString(), rsget["USER_LOGIN_NAME"].ToString()).ToString();

                 if (vstrOldPass.Trim() != txtOldPassWord.Text.Trim())
                 {
                     MessageBox.Show("Old PassWord is Mismatch");
                     txtOldPassWord.Focus();
                     return;
                 }
           


             }


            //if (_strImageName != "")
            //{
                MemoryStream ms = new MemoryStream();
                pbImage.Image.Save(ms, ImageFormat.Jpeg);
                _imageData = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(_imageData, 0, _imageData.Length);
               // _imageData = pbImage.Image.ToByteArray();
            //}

                if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "USER_CONFIG", "USER_LOGIN_NAME", uctxtLogInName.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtLogInName.Text = "";
                        uctxtLogInName.Focus();
                        return;
                    }
                    vstrPassword = Utility.Encrypt(uctxtPasswoed.Text, uctxtLogInName.Text);
                    var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponseInsert == DialogResult.Yes)
                    {
                        try
                        {


                            string strmsg = accms.mInsertUser(strComID, Utility.gCheckNull(uctxtLogInName.Text), Utility.gCheckNull(uctxtFullName.Text), Utility.gCheckNull(uctxtDepartment.Text), Utility.gCheckNull(uctxtDesignation.Text),
                                                                vstrPassword, cboAccessLevel.Text, cboStatus.Text, Utility.gCheckNull(uctxtcomments.Text), _imageData);

                            CreateDefaultdata.gInsertPrivilegesNew(uctxtLogInName.Text, Utility.Left(cboAccessLevel.Text, 1));
                            MessageBox.Show(strmsg);
                            mcLear();
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                else
                {
                    if (txtOldUserName.Text != uctxtLogInName.Text)
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "USER_CONFIG", "USER_LOGIN_NAME", uctxtLogInName.Text);
                        if (strDuplicate != "")
                        {
                            MessageBox.Show(strDuplicate);
                            uctxtLogInName.Text = "";
                            uctxtLogInName.Focus();
                            return;
                        }
                    }
                    vstrPassword = uctxtPasswoed.Text;
                    //vstrPassword = Utility.Decrypt(uctxtPasswoed.Text, txtOldUserName.Text);
                    var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (strResponseInsert == DialogResult.Yes)
                    {
                        try
                        {
                            string strmsg = accms.mUpdateInsertUser(strComID, txtOldUserName.Text, Utility.gCheckNull(uctxtLogInName.Text), Utility.gCheckNull(uctxtFullName.Text), Utility.gCheckNull(uctxtDepartment.Text), Utility.gCheckNull(uctxtDesignation.Text),
                                                                vstrPassword, cboAccessLevel.Text, cboStatus.Text, Utility.gCheckNull(uctxtcomments.Text), _imageData);
                            if (Utility.Left(cboAccessLevel.Text, 1).ToUpper() == "A")
                            {
                                CreateDefaultdata.gUpdatePrivilegesNew(txtOldUserName.Text, uctxtLogInName.Text, Utility.Left(cboAccessLevel.Text, 1));
                            }
                            if (Utility.gblnAccessControl)
                            {
                                if (Utility.gstrUserName == txtOldUserName.Text)
                                {
                                    Utility.gstrUserName = uctxtLogInName.Text;
                                    if (System.Windows.Forms.Application.OpenForms["frmMain"] as frmMain == null)
                                    {
                                        frmMain objfrm = new frmMain();
                                        objfrm.mLoad(strComID);
                                        objfrm.Focus();

                                    }
                                    else
                                    {
                                        frmMain objfrm = (frmMain)Application.OpenForms["frmMain"];
                                        objfrm.mLoad(strComID);
                                        objfrm.Focus();
                                    }
                                }
                            }
                            MessageBox.Show(strmsg);
                            mcLear();

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }

        }

        private void mcLear()
        {
            uctxtLogInName.Text = "";
            uctxtFullName.Text = "";
            uctxtPasswoed.Text = "";
            uctxtDepartment.Text = "";
            uctxtDesignation.Text = "";
            uctxtcomments.Text = "";
            cboAccessLevel.Text = "User";
            cboStatus.Text = "Active";
            pbImage.Image = imagelst.Images[0];
            uctxtLogInName.Focus();
            txtOldPassWord.Text = "";
            m_action = 1;
            
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            mcLear();
            frmUserManagementList objfrm = new frmUserManagementList();
            objfrm.onAddAllButtonClicked = new frmUserManagementList.AddAllClick(DisplayReqList);
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            uctxtLogInName.Focus();
        }
        private void DisplayReqList(List<UserAccess> tests, object sender, EventArgs e)
        {
            try
            {
               
                List<UserAccess> objacc = accms.mGetUserAccessData(strComID, tests[0].LogInName).ToList();
                if (objacc.Count > 0)
                {
                    m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                    txtOldUserName.Text = tests[0].LogInName;
                    uctxtLogInName.Text = tests[0].LogInName;
                    uctxtFullName.Text = objacc[0].FullName;
                    uctxtDepartment.Text = objacc[0].Department;
                    uctxtDesignation.Text = objacc[0].Designation;
                    uctxtPasswoed.Text = Utility.Decrypt(objacc[0].strPassWord, tests[0].LogInName);
                   
                    if (objacc[0].intAccessLevel == 1)
                    {
                        cboAccessLevel.Text = "Administrator";
                    }
                    else if (objacc[0].intAccessLevel == 2)
                    {
                        cboAccessLevel.Text = "User";
                    }
                    if (objacc[0].strStatus == "A")
                    {
                        cboStatus.Text = "Active";
                    }
                    else
                    {
                        cboStatus.Text = "Suspend";
                    }
                    uctxtcomments.Text =objacc[0].commnets;
                    MemoryStream memStream = new MemoryStream(objacc[0].strIamge);
                    pbImage.Image = Image.FromStream(memStream);

                    //var data = objacc[0].strIamge;
                    //var stream = new MemoryStream(data);
                    //pbImage.Image = Image.FromStream(stream);


                    pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
                   
                   
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void DisplayReqList(string gstrUserName)
        {
            try
            {

                List<UserAccess> objacc = accms.mGetUserAccessData(strComID, gstrUserName).ToList();
                if (objacc.Count > 0)
                {
                    m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                    txtOldUserName.Text = gstrUserName;
                    uctxtLogInName.Text = gstrUserName;
                    uctxtFullName.Text = objacc[0].FullName;
                    uctxtDepartment.Text = objacc[0].Department;
                    uctxtDesignation.Text = objacc[0].Designation;
                    //uctxtPasswoed.Text = Utility.Decrypt(objacc[0].strPassWord, gstrUserName);

                    if (objacc[0].intAccessLevel == 1)
                    {
                        cboAccessLevel.Text = "Administrator";
                    }
                    else if (objacc[0].intAccessLevel == 2)
                    {
                        cboAccessLevel.Text = "User";
                    }
                    if (objacc[0].strStatus == "A")
                    {
                        cboStatus.Text = "Active";
                    }
                    else
                    {
                        cboStatus.Text = "Suspend";
                    }
                    uctxtcomments.Text = objacc[0].commnets;
                    MemoryStream memStream = new MemoryStream(objacc[0].strIamge);
                    pbImage.Image = Image.FromStream(memStream);

                    //var data = objacc[0].strIamge;
                    //var stream = new MemoryStream(data);
                    //pbImage.Image = Image.FromStream(stream);


                    pbImage.SizeMode = PictureBoxSizeMode.StretchImage;


                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            pbImage.Image = imagelst.Images[0];
            if (strFormName =="Change PassWord")
            {
                uctxtLogInName.ReadOnly = true ;
                txtOldPassWord.Enabled = true;
                btnEdit.Visible = false;
                btnNew.Visible = false;
                btnOnlineOrder.Visible = false;
                btnFormConfig.Visible = false;
                btnLogInCompouter.Visible = false;
                cboAccessLevel.Enabled = false;
                label3.Text = "New PassWord:";
                DisplayReqList(Utility.gstrUserName);
            }
            else
            {
                label3.Text = "     PassWord:";
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            UserAccCon objfrm = new UserAccCon();
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }

        private void btnFormConfig_Click(object sender, EventArgs e)
        {
            frmSecurityConfig objfrm = new frmSecurityConfig();
            objfrm.m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }

        private void btnLogInCompouter_Click(object sender, EventArgs e)
        {
            frmLogInIP objfrm = new frmLogInIP();
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }

        private void btnOnlineOrder_Click(object sender, EventArgs e)
        {
            frmOnlineOrderMapping objfrm = new frmOnlineOrderMapping();
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
        }

     

      


       






    }
}
