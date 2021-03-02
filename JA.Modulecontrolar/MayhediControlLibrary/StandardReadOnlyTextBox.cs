using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MayhediControlLibrary
{
    partial class StandardReadOnlyTextBox
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
    public partial class StandardReadOnlyTextBox : TextBox
    {
        public StandardReadOnlyTextBox()
        {
            InitializeComponent();

        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ReadOnly = true;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new System.Drawing.Font("ArialMJ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabStop = false;
            //this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(138)))));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BackColor = System.Drawing.Color.Linen;                
                ///System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(184)))), ((int)(((byte)(133)))));

        }
        public StandardReadOnlyTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


    }
}
