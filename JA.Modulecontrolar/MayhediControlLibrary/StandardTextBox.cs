using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace MayhediControlLibrary
{
    public class StandardTextBox : TextBox
    {
        protected override void OnCreateControl()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            base.OnCreateControl();
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            base.OnGotFocus(e);
            this.BackColor = Color.LightYellow;
            this.Font = new Font(this.Font, FontStyle.Bold);
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
            this.Font = new Font(this.Font, FontStyle.Regular);
        }


    }

}