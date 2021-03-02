using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

public class MayhediDataGridView : DataGridView
{

    protected override bool ProcessDialogKey(Keys keyData)
    {
        
        if (keyData == Keys.Enter)
        {
            int col = this.CurrentCell.ColumnIndex;
            int row = this.CurrentCell.RowIndex;
            if (row != this.NewRowIndex)
            {
                if (col == (this.Columns.Count - 1))
                {
                    col = -1;
                    row++;
                }

                this.CurrentCell = this[col + 1, row];
            }
           return true;
        }
        return base.ProcessDialogKey(keyData);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyData == Keys.Enter)
        {
            try
            {
                int col = this.CurrentCell.ColumnIndex;
                int row = this.CurrentCell.RowIndex;
                if (row != this.NewRowIndex)
                {
                    if (col == (this.Columns.Count - 1))
                    {
                        col = -1;
                        row++;
                    }
                    this.CurrentCell = this[col + 1, row];
                }
            }
            catch (Exception ex)
            {

            }

            e.Handled = true;
        }

        base.OnKeyDown(e);

    }
}



