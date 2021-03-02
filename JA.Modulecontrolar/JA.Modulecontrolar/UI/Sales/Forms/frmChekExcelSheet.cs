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
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Sales.Forms
{
    public partial class frmChekExcelSheet : JA.Shared.UI.frmJagoronFromSearch
    {
        public string stTextname { get; set; }
        public frmChekExcelSheet(string strName)
        {
            InitializeComponent();
            stTextname = strName;
        
        }

        private void frmChekExcelSheet_Load(object sender, EventArgs e)
        {
            textBox1.Text = stTextname;

        }
        





    }
}
