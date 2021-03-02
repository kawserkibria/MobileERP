using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MayhediControlLibrary
{
    public class StandardTextBoxColorful : TextBox
    {
        protected override void OnCreateControl()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            base.OnCreateControl();
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            base.OnGotFocus(e);
            this.BackColor = Color.LightYellow;
            //this.Font = new Font(this.Font, FontStyle.Bold);
            this.BeginInvoke(new MethodInvoker(SelectText));
        }

        private void SelectText()
        {
            this.SelectionStart = 0;
            this.SelectionLength = this.Text.Length;
        }
        protected override void OnLeave(EventArgs e)
        {

            base.OnLeave(e);
            this.BackColor = Color.White;
            //this.Font = new Font(this.Font, FontStyle.Regular);
        }


    }
}
