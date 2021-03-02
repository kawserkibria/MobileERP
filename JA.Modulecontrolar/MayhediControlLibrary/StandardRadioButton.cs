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
    public class StandardRadioButton : RadioButton
    {
        protected override void OnCreateControl()
        {
            this.ForeColor = Color.Gray;
            this.Font = new System.Drawing.Font("Georgia", 11);

            base.OnCreateControl();

        }


        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (this.Enabled == true)
            {
                this.ForeColor = Color.Black;
                if (this.Checked == true)
                    this.ForeColor = Color.Blue;
            }
            else if (this.Enabled == false)
            {
                this.ForeColor = Color.Gray;
            }

        }
        protected override void OnCheckedChanged(EventArgs e)
        {
            if (this.Checked == true)
            {
                this.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                this.ForeColor = Color.Blue;
            }
            else if (this.Checked == false)
            {
                this.Font = new System.Drawing.Font(this.Font, FontStyle.Regular);
                this.ForeColor = Color.Black;
            }
            base.OnCheckedChanged(e);
        }

    }
}
