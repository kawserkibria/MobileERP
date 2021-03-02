using Dutility;
using ExtraReports.JACCMS;
using ExtraReports.Projection.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraReports
{
    public partial class frmERMain : Form
    {
        private string strComID { get; set; }
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public frmERMain()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmERMain_KeyDown);
            this.btnProjection.Click += new System.EventHandler(this.btnProjection_Click);
            mLoad(strComID);
        }
        private void frmERMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    btnExit.PerformClick();
                }
            }
         
        }
        private void frmERMain_Load(object sender, EventArgs e)
        {
             //Rectangle parentRect = control.Parent.ClientRectangle;
            panel1.Width = this.Width;
        }

        public void mLoad(string strcomID)
        {

           
            string strRole = "", strDept = "", strDesi = "";

            //Utility.creaateWrite(strComID);
            //string strCaption = accms.gSelectCompanyName(strcomID);

            if (Utility.gstrCompanyName == "")
            {
                this.Text = "No Compnany Name Select.....";
            }
            else
            {
                this.Text = Utility.gstrCompanyID + "-" + Utility.gstrCompanyName + " - " + Convert.ToDateTime(Utility.gdteFinancialYearFrom).ToString(Utility.DEFAULT_DATE_FORMAT)
                                + " to " + Convert.ToDateTime(Utility.gdteFinancialYearTo).ToString(Utility.DEFAULT_DATE_FORMAT);
                //this.Text = strCaption;
            }

            if (Utility.gblnAccessControl)
            {
                if (Utility.gstrUserName == null)
                {
                    userWidgetMetro1.Visible = false;
                    return;
                }
                List<UserAccess> objacc = accms.mGetUserAccessData(strcomID, Utility.gstrUserName).ToList();
                if (objacc.Count > 0)
                {
                    if (objacc[0].intAccessLevel == 1)
                    {
                        strRole = "Administrator";
                    }
                    else
                    {
                        strRole = "User";
                    }
                    if (objacc[0].Department != "")
                    {
                        strDept = objacc[0].Department;
                    }
                    else
                    {
                        strDept = "";
                    }
                    if (objacc[0].Designation != "")
                    {
                        strDesi = objacc[0].Designation;
                    }
                    else
                    {
                        strDesi = "";
                    }
                }

                Utility.InitialiseMainForm(this, objacc[0].LogInName, strRole, strDesi, strDept, objacc[0].strIamge, userWidgetMetro1);


            }
            else
            {
                userWidgetMetro1.Visible = false;
            }


            if (Utility.gblnAccessControl == false)
            {
                userWidgetMetro1.Visible = false;
            }


        }

        private void btnProjection_Click(object sender, EventArgs e)
        {
            //if (Utility.gblnAccessControl)
            //{
            //    if (!Utility.gblnChildPrivileges(strComID, Utility.gstrUserName, 94))
            //    {
            //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            if (System.Windows.Forms.Application.OpenForms["frmProMain"] as frmProMain == null)
            {
                frmProMain objfrm = new frmProMain();
                objfrm.MdiParent = this;
                objfrm.Show();
            }
            else
            {
                frmProMain objfrm = (frmProMain)Application.OpenForms["frmProMain"];
                objfrm.Focus();
              
            }
        }

       
        

        private void userWidgetMetro1_btnLogout_Clicked(object sender, EventArgs e)
        {
            this.Dispose();
            //frmELogIn objfrm = new frmELogIn();
            //objfrm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Utility.Kill("ExtraReports");
            this.Dispose();
        }
    }
}
