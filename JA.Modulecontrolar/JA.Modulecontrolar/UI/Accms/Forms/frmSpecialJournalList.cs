using JA.Modulecontrolar.UI.DReport.Accms.ParameterForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Dutility;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmSpecialJournalList : JA.Shared.UI.frmSmartFormStandard
    {
        public frmSpecialJournalList()
        {
            InitializeComponent();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmSpecialJournalList_Load(object sender, EventArgs e)
        {
            DG.Columns.Clear();
            this.DG.DefaultCellStyle.Font = new Font("verdana", 10);


            DG.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 145, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Trans.Date", "Trans.Date", 110, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name", "Ledger Name", 230, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Branch Name", "Branch Name", 120, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Net Amount", "Net Amount", 180, true, DataGridViewContentAlignment.TopLeft, false));
       
            //DG.Columns[0].ReadOnly = true;
            //DG.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
        }

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (DG[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper() == "Y")
                {
                    for (int i = e.ColumnIndex; i < DG.Columns.Count; i++)
                    {

                        DG[i, e.RowIndex].Value = "Yes";
                    }
                    return;

                }
            }




        }
    }
}