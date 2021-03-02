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
    public partial class UserWidgetMetro : UserControl
    {
        public delegate void LogoutButtonClickHandler(object sender, EventArgs e);
        public event LogoutButtonClickHandler btnLogout_Clicked;
        public UserWidgetMetro()
        {
            InitializeComponent();
            lblLogInTime.Text = "Log in: "+System.DateTime.Now.ToString("dd/MM/yyyy hh:mm");
        }
        protected virtual void OnLogoutButtonClick(EventArgs e)
        {
            if (btnLogout_Clicked != null)
                btnLogout_Clicked(this, e);

        }

        private void pnlLogOut_Click(object sender, EventArgs e)
        {
            OnLogoutButtonClick(e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OnLogoutButtonClick(e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OnLogoutButtonClick(e);
        }
    }

}
