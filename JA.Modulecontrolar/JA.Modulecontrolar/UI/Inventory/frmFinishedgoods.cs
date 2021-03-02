using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JA.Modulecontrolar.JACCMS;
namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmFinishedgoods : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public int m_action { get; set; }
        public int intvType { get; set; }
        private ListBox lstBranchName = new ListBox();
        private ListBox lstLocation = new ListBox();
        private ListBox lstProcess = new ListBox();
        private ListBox lstBatch = new ListBox();
        public frmFinishedgoods()
        {
            InitializeComponent();

            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.uctxtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtInvoiceNo_KeyPress);
            this.uctxtInvoiceNo.GotFocus += new System.EventHandler(this.uctxtInvoiceNo_GotFocus);

            this.dteDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteDate_KeyPress);
            this.dteDate.GotFocus += new System.EventHandler(this.dteDate_GotFocus);

            this.uctxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtQty_KeyPress);
            this.uctxtQty.GotFocus += new System.EventHandler(this.uctxtQty_GotFocus);

            this.uctxtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtRate_KeyPress);
            this.uctxtRate.GotFocus += new System.EventHandler(this.uctxtRate_GotFocus);

            this.uctxtCosting.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCosting_KeyPress);
            this.uctxtCosting.GotFocus += new System.EventHandler(this.uctxtCosting_GotFocus);

            this.uctxtNarration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNarration_KeyPress);
            this.uctxtNarration.GotFocus += new System.EventHandler(this.uctxtNarration_GotFocus);

            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);

            this.uctxtBatch.KeyDown += new KeyEventHandler(uctxtBatch_KeyDown);
            this.uctxtBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBatch_KeyPress);
            this.uctxtBatch.TextChanged += new System.EventHandler(this.uctxtBatch_TextChanged);
            this.lstBatch.DoubleClick += new System.EventHandler(this.lstBatch_DoubleClick);
            this.uctxtBatch.GotFocus += new System.EventHandler(this.uctxtBatch_GotFocus);

            this.uctxtBranchName.KeyDown += new KeyEventHandler(uctxtBranchName_KeyDown);
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.TextChanged += new System.EventHandler(this.uctxtBranchName_TextChanged);
            this.lstBranchName.DoubleClick += new System.EventHandler(this.lstBranchName_DoubleClick);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);

            this.uctxtLocation.KeyDown += new KeyEventHandler(uctxtLocation_KeyDown);
            this.uctxtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLocation_KeyPress);
            this.uctxtLocation.TextChanged += new System.EventHandler(this.uctxtLocation_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.uctxtLocation.GotFocus += new System.EventHandler(this.uctxtLocation_GotFocus);

            this.uctxtProcessName.KeyDown += new KeyEventHandler(uctxtProcessName_KeyDown);
            this.uctxtProcessName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtProcessName_KeyPress);
            this.uctxtProcessName.TextChanged += new System.EventHandler(this.uctxtProcessName_TextChanged);
            this.lstProcess.DoubleClick += new System.EventHandler(this.lstProcess_DoubleClick);
            this.uctxtProcessName.GotFocus += new System.EventHandler(this.uctxtProcessName_GotFocus);

            Utility.CreateListBox(lstBranchName, pnlMain, uctxtBranchName);
            Utility.CreateListBox(lstLocation, pnlMain, uctxtLocation);
            Utility.CreateListBox(lstProcess, pnlMain, uctxtProcessName);
            Utility.CreateListBox(lstBatch, pnlMain, uctxtBatch);
        }

        #region "User Define"
        private void uctxtRate_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
        }
        private void uctxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                mAddStockItem(DG, uctxtItemName.Text, 1);
                uctxtItemName.Text = "*****Press F3*****";
                uctxtItemName.Focus();
            }
        }
        private void uctxtQty_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
        }
        private void uctxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtRate.Focus();

            }
        }
        private void uctxtCosting_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
        }
        private void uctxtCosting_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtItemName.Focus();

            }
        }
        private void mAddStockItem(DataGridView dg, string strItemName, double dblQty)
        {
            int selRaw;
            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < dg.RowCount; j++)
            {
                if (dg[0, j].Value != null)
                {
                    strDown = dg[0, j].Value.ToString();
                }
                if (strItemName == strDown.ToString())
                {
                    blngCheck = true;
                }

            }
            if (blngCheck == false)
            {

                dg.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(dg.RowCount.ToString());
                selRaw = selRaw - 1;
                dg.Rows.Add();
                dg[0, selRaw].Value = strItemName.ToString();
                dg[1, selRaw].Value = dblQty;
                dg[2, selRaw].Value = Utility.gGetBaseUOM(strItemName.ToString());
                //dg[3, selRaw].Value = Utility.gGetBaseUOM(strItemName.ToString());
                dg.AllowUserToAddRows = false;
                // calculateTotal();
            }

        }

        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (uctxtItemName.Text != "*****Press F3*****")
                {
                   
                    uctxtItemName.Focus();
                }
                else
                {
                    uctxtQty.Focus();
                }

            }
        }

        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                frmAllItem objfrm = new frmAllItem();
                objfrm.MdiParent = MdiParent;
                objfrm.mloadType = 1;
                objfrm.onAddAllButtonClicked = new frmAllItem.AddAllClick(DisplayFgQty);
                objfrm.ShowDialog();
            }

        }

        private void DisplayFgQty(List<StockItem> tests, object sender, EventArgs e)
        {
            try
            {

                uctxtItemName.Text = tests[0].strItemName;


            }
            catch (Exception ex)
            {

            }
        }
        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
        }
        private void uctxtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnSave.Focus();

            }
        }
        private void uctxtNarration_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
        }
        private void dteDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                uctxtBranchName.Focus();

            }
        }
        private void dteDate_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
        }
        private void uctxtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                
                dteDate.Focus();

            }
        }
        private void uctxtInvoiceNo_GotFocus(object sender, System.EventArgs e)
        {
            lstBatch.Visible = false;
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
        }

        private void uctxtBatch_TextChanged(object sender, EventArgs e)
        {
            lstBatch.SelectedIndex = lstBatch.FindString(uctxtLocation.Text);
        }

        private void lstBatch_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstBatch.Text;
            uctxtProcessName.Focus();
        }

        private void uctxtBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBatch.Items.Count > 0)
                {
                    uctxtBatch.Text = lstBatch.Text;
                }
                uctxtProcessName.Focus();

            }
        }
        private void uctxtBatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBatch.SelectedItem != null)
                {
                    lstBatch.SelectedIndex = lstBatch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBatch.Items.Count - 1 > lstBatch.SelectedIndex)
                {
                    lstBatch.SelectedIndex = lstLocation.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBatch_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstBatch.Visible = true;
            lstProcess.Visible = false;
            lstLocation.Visible = false;

            lstBatch.ValueMember = "Key";
            lstBatch.DisplayMember = "Value";
            lstBatch.DataSource = invms.mFillBatch().ToList();

            lstBatch.SelectedIndex = lstBatch.FindString(uctxtLocation.Text);
        }



        private void uctxtLocation_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            uctxtLocation.Text = lstLocation.Text;
            uctxtBatch.Focus();
        }

        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    uctxtLocation.Text = lstLocation.Text;
                }
                uctxtBatch.Focus();

            }
        }
        private void uctxtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLocation.SelectedItem != null)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLocation.Items.Count - 1 > lstLocation.SelectedIndex)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex + 1;
                }
            }

        }

        private void uctxtLocation_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = false;
            lstLocation.Visible = true;
            lstBatch.Visible = false;
            lstProcess.Visible = false;
            if (lstBranchName.SelectedValue.ToString() != "0")
            {
                lstLocation.ValueMember = "strLocation";
                lstLocation.DisplayMember = "strLocation";
                lstLocation.DataSource = invms.gLoadLocation(lstBranchName.SelectedValue.ToString()).ToList();
            }
            lstLocation.SelectedIndex = lstLocation.FindString(uctxtLocation.Text);
        }


        private void uctxtBranchName_TextChanged(object sender, EventArgs e)
        {
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }

        private void lstBranchName_DoubleClick(object sender, EventArgs e)
        {
            uctxtBranchName.Text = lstBranchName.Text;
            uctxtLocation.Focus();
        }

        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstBranchName.Items.Count > 0)
                {
                    uctxtBranchName.Text = lstBranchName.Text;
                }
                uctxtLocation.Focus();

            }
        }
        private void uctxtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstBranchName.SelectedItem != null)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstBranchName.Items.Count - 1 > lstBranchName.SelectedIndex)
                {
                    lstBranchName.SelectedIndex = lstBranchName.SelectedIndex + 1;
                }
            }

        }

        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {

            lstBranchName.Visible = true;
            lstLocation.Visible = false;
            lstProcess.Visible = false;
            lstBatch.Visible = false;
            lstBranchName.ValueMember = "BranchID";
            lstBranchName.DisplayMember = "BranchName";
            lstBranchName.DataSource = accms.mFillBranch().ToList();
            lstBranchName.SelectedIndex = lstBranchName.FindString(uctxtBranchName.Text);
        }
        private void uctxtProcessName_TextChanged(object sender, EventArgs e)
        {
            lstProcess.SelectedIndex = lstProcess.FindString(uctxtProcessName.Text);
        }

        private void lstProcess_DoubleClick(object sender, EventArgs e)
        {
            uctxtProcessName.Text = lstProcess.Text;
            //if (uctxtProcessName.Text != "")
            //{
            //    DisplayProcess(uctxtProcessName.Text);
            //}
            uctxtCosting.Focus();
        }

        private void uctxtProcessName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstProcess.Items.Count > 0)
                {
                    uctxtProcessName.Text = lstProcess.Text;
                }
                //if (uctxtProcessName.Text != "")
                //{
                //    DisplayProcess(uctxtProcessName.Text);
                //}
                uctxtCosting.Focus();

            }
        }
        private void uctxtProcessName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstProcess.SelectedItem != null)
                {
                    lstProcess.SelectedIndex = lstProcess.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstProcess.Items.Count - 1 > lstProcess.SelectedIndex)
                {
                    lstProcess.SelectedIndex = lstProcess.SelectedIndex + 1;
                }
            }

        }

        private void uctxtProcessName_GotFocus(object sender, System.EventArgs e)
        {
            lstBranchName.Visible = false;
            lstLocation.Visible = false;
            lstProcess.Visible = true;
            lstBatch.Visible = false;
            lstProcess.SelectedIndex = lstProcess.FindString(uctxtProcessName.Text);
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void frmFinishedgoods_Load(object sender, EventArgs e)
        {
            lstProcess.Visible = false;
            lstLocation.Visible = false;
            lstBranchName.Visible = false;
            
            lstBatch.Visible = false;
            
            this.DG.DefaultCellStyle.Font = new Font("verdana", 10);
            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 380, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Qty", "Qty", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Per", "Per", 60, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Rate", "Rate", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 100, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));

            lstProcess.ValueMember = "strProcessName";
            lstProcess.DisplayMember = "strProcessName";
            lstProcess.DataSource = invms.mLoadProcess("","").ToList();
        }











    }
}
