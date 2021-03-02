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
    partial class StandardReadOnlyDateTextBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
    }
    public partial class StandardReadOnlyDateTextBox : MaskedTextBox
    {
        protected override void OnCreateControl()
        {
            int fontSize;
            fontSize = 11;
            base.OnCreateControl();
            this.Mask = "00/00/0000";
            this.PromptChar = '_';
            this.Culture = new System.Globalization.CultureInfo("en-GB");
            this.ValidatingType = typeof(System.DateTime);

            this.ReadOnly = true;
            this.ForeColor = Color.Yellow;
            this.BackColor = Color.LightCoral;
            this.Font = new Font("Verdana", 10, FontStyle.Bold);

            // this.Font = new Font(this.Font.Name, fontSize);
        }
    }
}
