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
    public class StandardLabel : Label
    {
        protected override void OnCreateControl()
        {
            this.Font = new Font(this.Font, FontStyle.Bold);
            base.OnCreateControl();
        }
    }
}
