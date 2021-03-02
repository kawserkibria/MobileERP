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
    public partial class StandardTab : TabControl
    {
        protected override void OnCreateControl()
        {
            this.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedIndex = 0;
            base.OnCreateControl();
        }
    }
}