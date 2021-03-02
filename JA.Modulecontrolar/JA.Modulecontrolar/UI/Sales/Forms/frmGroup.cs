using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmGroup : JA.Shared.UI.frmSmartFormStandard
    {

        public int lngLedgeras { get; set; }
        public int m_action { get; set; }
        public int intVtype { get; set; }
        public frmGroup()
        {
            InitializeComponent();
        }
    }
}
