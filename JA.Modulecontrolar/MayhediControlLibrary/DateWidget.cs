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
    public partial class DateWidget : UserControl
    {
        public DateWidget()
        {
            InitializeComponent();
            //lblDateNum.Left = lblDate.Left + lblDate.Width+5;
            //lblMonth.Left = lblDateNum.Left + lblDateNum.Width + 5;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           Initialise();
        }

        private void Initialise()
        {
            lblTime.Text = System.DateTime.Now.ToString("hh:mm");
            lblDate.Text = System.DateTime.Now.ToString("dddd, dd, MMMM");
            //lblDateNum.Text = System.DateTime.Now.ToString("dd, ");
            //lblMonth.Text = System.DateTime.Now.ToString("MMMM");
           
        }

        private void DateWidget_Load(object sender, EventArgs e)
        {
            Initialise();
        }
    }
}
