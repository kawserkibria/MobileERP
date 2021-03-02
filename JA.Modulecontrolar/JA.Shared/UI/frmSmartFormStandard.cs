
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace JA.Shared.UI
{
    public partial class frmSmartFormStandard : Form
    {
        public Boolean isEnterTabAllow { set; get; }
        public frmSmartFormStandard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnTopClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmSmartFormStandard_Load(object sender, EventArgs e)
        {
            isEnterTabAllow = true;
          //  initControlsRecursive(this.Controls);
        }

        //private void initControlsRecursive(Control.ControlCollection controlCollection)
        //{
        //    //if (Utility.CurrentPopupGrid.Length > 0)
        //    //{
        //      //  var aoControls = controlCollection.Find(Utility.CurrentPopupGrid, true);
        //        foreach (Control c in controlCollection)
        //        {
        //            //if (c.Name != aoControls.Name)
        //            //{
        //            c.MouseClick += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
        //            {
        //                Utility.HideMyGrid(this, Utility.PopupGrids);
        //            });

        //            //}
        //            initControlsRecursive(c.Controls);
        //        //}
        //    }
        //}

        private void frmSmartFormStandard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.isEnterTabAllow)
                {
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            if (e.Control == true && e.KeyCode == Keys.S)
            {
                btnSave.PerformClick();
            }
            if (isEnterTabAllow==false)
            {
                btnSave.PerformClick();
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm(this);
        }
        public static void ClearForm(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }

                if (c.HasChildren)
                {
                    ClearForm(c);
                }

                if (c is CheckBox)
                {

                    ((CheckBox)c).Checked = false;
                }

                if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
                if (c is ComboBox)
                {
                    if (((ComboBox)c).Items.Count > 0)
                        ((ComboBox)c).SelectedIndex = 0;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void frmSmartFormStandard_Click(object sender, EventArgs e)
        {
          //  Utility.HideMyGrid(this, Utility.PopupGrids);
        }
      
        private void frmSmartFormStandard_MouseClick(object sender, MouseEventArgs e)
        {
            //Utility.HideMyGrid(this, Utility.PopupGrids);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }




    }
}
