using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AH.Shared.UI
{
    public partial class frmSmartFormReportStandard : Form
    {
        public frmSmartFormReportStandard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnTopClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmSmartFormReportStandard_Load(object sender, EventArgs e)
        {

        }

        private void frmSmartFormReportStandard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }

        }


    }
}
