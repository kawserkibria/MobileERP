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
    public partial class StandardCheckBox : CheckBox
    {
        protected override void OnCreateControl()
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = Color.Black;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("ArialMJ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            base.OnCreateControl();
        }
    }
}
