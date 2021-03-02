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
    public partial class StandardListViewDetails : ListView
    {
        protected override void OnCreateControl()
        {
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullRowSelect = true;
            this.GridLines = true;
            this.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.View = System.Windows.Forms.View.Details;
            base.OnCreateControl();
        }
    }
}
