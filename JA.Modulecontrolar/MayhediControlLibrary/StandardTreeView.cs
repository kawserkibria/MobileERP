using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayhediControlLibrary
{
    public partial class StandardTreeView : TreeView
    {
        protected override void OnCreateControl()
        {

            this.BackColor = System.Drawing.Color.LightYellow;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LineColor = System.Drawing.Color.Crimson;
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;

            base.OnCreateControl();
            
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            //this.SelectedNode.BackColor = System.Drawing.Color.Orange;
            base.OnNodeMouseClick(e);
        }


        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            TreeNodeStates state = e.State;
            Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Color fore = e.Node.ForeColor;
            if (fore == Color.Empty) fore = e.Node.TreeView.ForeColor;
            if (e.Node == e.Node.TreeView.SelectedNode)
            {
                fore = System.Drawing.Color.White;
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkOrange), e.Bounds);
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, fore, Color.Red);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, Color.Red, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
               // e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.GlyphOverhangPadding);
            }
            base.OnDrawNode(e);
        }
        //protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        //{
        //    SolidBrush orangeBrush = new SolidBrush(System.Drawing.Color.Orange);
        //    if (e.Node.IsSelected)
        //    {
        //        e.Graphics.FillRectangle(orangeBrush, e.Bounds); 
        //    }
        //    //    if (treeView1.Focused)
        //    //        e.Graphics.FillRectangle(greenBrush, e.Bounds);
        //    //    else
        //    //        e.Graphics.FillRectangle(redBrush, e.Bounds);
        //    //}
        //    //else
        //    //    e.Graphics.FillRectangle(Brushes.White, e.Bounds);


           
        //}
      

    }
}
