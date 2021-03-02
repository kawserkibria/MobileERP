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


      /// <summary>
    /// ////////////////////////////////Data grid view Codes here //////////////////////////////////////
    /// </summary>

    

    public class StandardDataGridView : DataGridView
    {

        protected override void OnCreateControl()
        {
            this.AllowUserToOrderColumns = true;
            this.BackgroundColor = System.Drawing.Color.White;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.ColumnHeadersHeight = 60;
           // DataGridViewCellStyle style = this.ColumnHeadersDefaultCellStyle;
          
           
            //this.ColumnHeadersDefaultCellStyle=style;

            //DataGridViewCellStyle style =
        
            //style.BackColor = Color.Navy;


            //cell style fol column header
            DataGridViewCellStyle dgrdcellstl = new DataGridViewCellStyle();
            dgrdcellstl.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dgrdcellstl.BackColor = System.Drawing.Color.White;
             
           // dataGridViewCellStyle3.BackColor = 

            dgrdcellstl.Font = new System.Drawing.Font("Tahoma", 8, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgrdcellstl.BackColor = Color.LightGreen;
                //System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            dgrdcellstl.ForeColor = Color.Black;
            dgrdcellstl.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.EnableHeadersVisualStyles = true;
            
            
            this.ColumnHeadersDefaultCellStyle = dgrdcellstl;


            //cell style for default cell style

            DataGridViewCellStyle dfltCellstl = new DataGridViewCellStyle();
            dfltCellstl.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dfltCellstl.BackColor = System.Drawing.Color.White;
            dfltCellstl.Font = new System.Drawing.Font("Tahoma", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dfltCellstl.ForeColor = System.Drawing.Color.Black;
                //System.Drawing.SystemColors.ControlText;
            dfltCellstl.SelectionBackColor = System.Drawing.Color.Lavender;
                
                //System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dfltCellstl.SelectionForeColor = System.Drawing.Color.Crimson;

            this.DefaultCellStyle = dfltCellstl;

            //this.GridColor = System.Drawing.Color.Silver;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.RowHeadersVisible = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToAddRows = false;
            this.AllowUserToResizeRows = false;
            this.AllowDrop = false;
            this.MultiSelect = false;


            DataGridViewCellStyle rdcstyle = new DataGridViewCellStyle();
            rdcstyle.BackColor = System.Drawing.Color.White;
            //rdcstyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //rdcstyle.SelectionBackColor = System.Drawing.Color.PaleGreen;
            //rdcstyle.SelectionForeColor = System.Drawing.Color.Red;
            this.RowsDefaultCellStyle = rdcstyle;



            //this.dataGridView1.AllowUserToDeleteRows = false;

            //this.dataGridView1.AutoGenerateColumns = false;


           


            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            //dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            //dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            //dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.LightBlue;
            //dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            //this.dataGridView1.RowHeadersVisible = false;




            base.OnCreateControl();
        }
        //private void SetFontAndColors()
        //{
        //    this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 15);
        //    this.dataGridView1.DefaultCellStyle.ForeColor = Color.Blue;
        //    this.dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
        //    this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
        //    this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
        //}


        /// <summary>
        /// /////////for enter key press bugs 
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int col = this.CurrentCell.ColumnIndex;
                int row = this.CurrentCell.RowIndex;
                this.CurrentCell = this[col, row];
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int col = this.CurrentCell.ColumnIndex;
                int row = this.CurrentCell.RowIndex;
                this.CurrentCell = this[col, row];
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }

        /////////////end of enter key press //////////////////

    }
  
}
