using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayhediControlLibrary
{
    public partial class MayhediLogInUserControl : UserControl
    {
        private string moduleName;
        private string password;
        private string userID;
       // private string userName;
        private string logInAs;
        private string mismatch;
        private string MistakeMsg = "Required field missing..";
        public delegate void LogInButtonClickHandler(object sender, EventArgs e);
        public event LogInButtonClickHandler btnLogIn_Clicked;
        public bool IsPrefilled { set; get; }

        public MayhediLogInUserControl()
        {
            InitializeComponent();
            InitialiseControls();
        }
        public void Reload()
        {
            this.txtUserID.Text = "";
            this.txtPassword.Text = "";
            txtUserID.Select();
        }

        public string ModuleName
        {
            set
            {
                moduleName = value;
                txtModuleName.Text = moduleName;
            }
            get { return moduleName; }
        }

        public List<string> ModuleNames
        {
            set;
            get;
        }
        public List<string> AuthenticatedObjects { set; get; }

        public string UserID
        {
            set { userID = value; txtUserID.Text = userID; }
            get { return userID; }
        }

        public string Password
        {
            set { password = value; txtPassword.Text = password; }
            get { return password; }
        }

        public string MismatchText
        {
            set { mismatch = value; }
            get { lblMismatch.Text = mismatch; return mismatch; }
        }
        //public string UserName
        //{
        //    set { userName = value;  = userID; }
        //    get { return userID; }
        //}

        public string LogInAs
        {

            set { logInAs = value; 
                //cboUserTypes.SelectedValue = logInAs;
            }
            get { return logInAs; }

        }


        private void InitialiseControls()
        {
            cboUserTypes.DisplayMember = "Value";
            cboUserTypes.ValueMember = "Key";
            Dictionary<string, string> uTypes = new Dictionary<string, string>();
            uTypes.Add("S", "Super Admin");
            uTypes.Add("A", "Admin");
            uTypes.Add("G", "General User");
            uTypes.Add("P", "Power User");
            uTypes.Add("D", "DBA");
            cboUserTypes.DataSource = new BindingSource(uTypes, null);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        protected virtual void OnLogInButtonClick(EventArgs e)
        {
            if (btnLogIn_Clicked != null)
                btnLogIn_Clicked(this, e);

        }

            

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }

        private void btnTpClose_Click(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text))
            {
                MessageBox.Show("User Id mandatory!!!", MistakeMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Valid Password Required!!", MistakeMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }
            this.userID = txtUserID.Text;
            this.password = txtPassword.Text;
             
            // dtv.DataSource = list.Select(data => new { data.TestSub.Room.RoomID, data.TestSub.Technologist.ID, data.TestSub.ReportGroup.ReportGroupID, data.TestSub.TestDepartment, data.TestSub.TestDepartmentTitle, data.TestGroup.GroupId, data.TestSub.TestSubTitle, data.TestSub.TestSubID, data.TestSub.Room.RoomTitle, data.Fee, data.DeptFee, data.DoctorFee, data.RefdFee, data.TestSub.TestMainID, data.TestSub.TestMainTitle, data.Discount }).ToList();
            //ModuleNames.AddRange(new string[] { "RegMIS", "IPDMIS", "OPDMIS", "DMSMIS", "HRMMIS", "DRSMIS", "PRMIS", "RPTMIS", "ACCMS" });
            //string s = "";
            //foreach (string m in ModuleNames)
            //{
            //    s += m + ",";
            //}
           
             //bool helper = new ApplicationUserBLL().IsAuthenticated(txtUserID.Text, txtPassword.Text, cboUserTypes.SelectedValue.ToString(), moduleName);
            //if (helper == true)
            //{
            //    authenticated = true;

            //}
            //else
            //{
            //    MessageBox.Show("Your Are not Authenticated");
            //    authenticated = false;
            //}

            OnLogInButtonClick(e);
        }

        private void AtiqsLogInUserControl_Load(object sender, EventArgs e)
        {
            txtUserID.Focus();
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Select();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               btnLogIn.Select();
            }
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }



    }
}