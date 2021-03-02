using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JA.Modulecontrolar
{
    public partial class frmSplash : Form
    {
      
        public frmSplash()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(5);
            if (progressBar1.Value == 100)
            {
                progressBar1.ForeColor = Color.Yellow;
                timer1.Stop();
                this.Dispose();
                
            }
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //GraphicsPath grPath = new GraphicsPath();
            //grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            //this.Region = new System.Drawing.Region(grPath);
            //base.OnPaint(e);
        }

      

       
    }

}
