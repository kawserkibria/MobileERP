using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace MayhediControlLibrary
{
    public partial class StandardTextOnlyTextBox : StandardTextBox
    {

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
