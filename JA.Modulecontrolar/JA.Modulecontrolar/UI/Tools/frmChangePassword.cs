using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmChangePassword : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public long lngFormPriv { get; set; }
        List<StockItem> oogrp;
        public int m_action { get; set; }
        public frmChangePassword()
        {
            InitializeComponent();

        }
    }


}

