using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.Accms.Forms;
using Dutility;
using JA.Modulecontrolar.JINVMS;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmSalesTarget : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public int lngLedgeras { get; set; }
        public int m_action { get; set; }
        public int intVtype { get; set; }
        public frmSalesTarget()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
          
        }

    }
}
