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
    public class StandardComboBox : ComboBox
    {
        protected override void OnCreateControl()
        {
            this.ForeColor = Color.Blue;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.Font = new System.Drawing.Font("ArialMJ", 11.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
           
            base.OnCreateControl();

        }

    }

    public class StandardComboBoxSearch : ComboBox
    {
        protected override void OnCreateControl()
        {
            this.ForeColor = Color.Blue;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.Font = new System.Drawing.Font("ArialMJ", 11.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.DropDownStyle = ComboBoxStyle.DropDown;
            this.Sorted = true;

            base.OnCreateControl();

        }

        protected override void OnLeave(EventArgs e)
        {
            if (this.SelectedValue == null)
            {
                this.Text = "";
            }
            
            base.OnLeave(e);
        }
    }
}
