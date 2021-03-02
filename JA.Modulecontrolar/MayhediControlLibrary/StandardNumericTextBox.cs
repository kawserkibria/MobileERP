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
    public class StandardNumericTextBox : StandardTextBox
    {
        public const int WM_Paste = 0x302;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_Paste)
            {
                return;
            }
            base.WndProc(ref m);

        }


        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && this.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }


        }
    }
}
