
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Dutility;
using ExtraReports.EXTRA;
using System.Drawing.Drawing2D;

namespace ExtraReports.Projection.Forms
{
    public partial class frmMonthlyProjection : JA.Shared.UI.frmSmartFormStandard
    {

        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient();
        
        private ListBox lstDivision = new ListBox();
        public delegate void AddAllClick(List<ProjectionSet> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        public string mstrOldCode { get; set; }
        public long lngFormPriv;
        public int intStatus = 0;
        public int intDayInterBale = 0;
        public int mintOldStatus = 0;
        public string strStatusType = "";
        public string strFdate = "";
        public string strTdate = "";
        public string strProjectionKey = "";
        public string strMontNameYY = "";
        public string strProjectionMonthYY = "";
        public string strStrartMonhtYY = "";
        public string strEndMonhtYY = "";
        public string mstrOldProjectionKey { get; set; }
        public string strMontName = "";
        public string strProjectionMonth = "";
        public string strStrartMonht = "";
        public string strEndMonht = "";

        public string strmsg = "";
        public int intDateIntervale = 0;
        public int intday = 0;
        public int m_action { get; set; }
        private string strComID { get; set; }

        List<ProjectionSet> ooLedgerName;
        public frmMonthlyProjection()
        {
           
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region "User Define event"
            
            this.DG.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);
            this.txtMonthID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonthID_KeyPress);
            this.txtMonthID.GotFocus += new System.EventHandler(this.txtMonthID_GotFocus);
            this.txtMonthID.TextChanged += new System.EventHandler(this.txtMonthID_TextChanged);
            this.txtDivision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDivision_KeyPress);
            this.txtDivision.GotFocus += new System.EventHandler(this.txtDivision_GotFocus);
            this.txtDivision.KeyDown += new KeyEventHandler(txtDivision_KeyDown);
            this.txtDivision.TextChanged += new System.EventHandler(this.txtDivision_TextChanged);
            this.lstDivision.DoubleClick += new System.EventHandler(this.lstDivision_DoubleClick);
            this.txtSerach.TextChanged += new System.EventHandler(this.txtSerach_TextChanged);
            this.txtSerach.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerach_KeyPress);
            Utility.CreateListBox(lstDivision, pnlMain, txtDivision);
            #endregion
        }
        #region "User Define"
        private void txtSerach_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSerach.Text;
            if (searchValue == "")
            {
                DG.SelectionMode = DataGridViewSelectionMode.CellSelect;
                return;
            }


        }

        private void txtSerach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                string searchValue = txtSerach.Text;
                if (searchValue == "")
                {
                    DG.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    return;
                }
                DG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                try
                {
                    foreach (DataGridViewRow row in DG.Rows)
                    {
                        if (row.Cells[2].Value.ToString().Contains(searchValue))
                        {
                            row.Selected = true;
                            DG.FirstDisplayedScrollingRowIndex = DG.SelectedRows[0].Index;
                            break;
                        }
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

       
        private void LedgerAdd(string strDivision)
        {
            int introw = 0;
            DG.Rows.Clear();

            ooLedgerName = objExtra.mFillMonthlyProjectionLedger(strComID, strDivision,"",0).ToList();

            if (ooLedgerName.Count > 0)
            {
                foreach (ProjectionSet ogrp in ooLedgerName)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.strAMFM + Environment.NewLine;
                    DG[1, introw].Value = ogrp.strMpoName;
                    DG[2, introw].Value = ogrp.strMerzeName;
                   
                    DG.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    DG.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    DG.Rows[introw].Height = 43;
                    introw += 1;
                }
                
                DG.AllowUserToAddRows = false;
            }
        }
        private void txtDivision_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstDivision.Items.Count > 0)
                {
                        txtDivision.Text = lstDivision.Text;
                        strProjectionKey = txtMonthID.Text + txtDivision.Text.Trim();
                        if (ValidateFields() == false)
                        {
                            return;
                        }
                        lstDivision.Visible = false;
                        List<ProjectonMonthConfig> objZone = objExtra.getZoneFromDivsion(strComID, txtDivision.Text).ToList();
                        if (objZone.Count > 0)
                        {
                            lblTotalArea.Text = objZone[0].lngTotalArea.ToString();
                            lblTotalMpo.Text = objZone[0].lngTotalLedger.ToString();
                            uctxtZone.Text = objZone[0].strZone.ToString();
                        }
                        LedgerAdd(txtDivision.Text);
                        DG.Focus();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                DG.Focus();
            }


        }
        private void txtDivision_GotFocus(object sender, System.EventArgs e)
        {
            //lstDivision.ValueMember = "strGRName";
            //lstDivision.DisplayMember = "strGRName";
            //lstDivision.DataSource = objExtra.mGetLedgerGroupLoad(strComID, 2).ToList();
            lstDivision.Visible = true;
        }
        private void txtDivision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstDivision.SelectedItem != null)
                {
                    lstDivision.SelectedIndex = lstDivision.SelectedIndex - 1;
                    txtDivision.Text = lstDivision.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstDivision.Items.Count - 1 > lstDivision.SelectedIndex)
                {
                    lstDivision.SelectedIndex = lstDivision.SelectedIndex + 1;
                    txtDivision.Text = lstDivision.Text;
                }
            }
        }
        private void txtDivision_TextChanged(object sender, EventArgs e)
        {
            int x = txtMonthID.SelectionStart;
            txtMonthID.Text = Utility.gmakeProperCase(txtMonthID.Text).ToUpper();
            txtMonthID.SelectionStart = x;

        }
        private void lstDivision_DoubleClick(object sender, EventArgs e)
        {
            

            txtDivision.Text = lstDivision.Text;
            strProjectionKey = txtMonthID.Text + txtDivision.Text.Trim();
            if (ValidateFields() == false)
            {
                return;
            }
            List<ProjectonMonthConfig> objZone= objExtra.getZoneFromDivsion(strComID, txtDivision.Text).ToList();
            if (objZone.Count > 0)
            {
                lblTotalArea.Text = objZone[0].lngTotalArea.ToString();
                lblTotalMpo.Text = objZone[0].lngTotalLedger.ToString();
                uctxtZone.Text = objZone[0].strZone.ToString();
            }
            LedgerAdd(txtDivision.Text);
            lstDivision.Visible = false;
            DG.Focus();
        }
        private void txtMonthID_KeyPress(object sender, KeyPressEventArgs e)
        {
          

            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtMonthID.Text == "")
                {
                    txtMonthID.Focus();
                }
                else
                {
                    txtDivision.Focus();
                }
               
            }
        }
        private void txtMonthID_GotFocus(object sender, System.EventArgs e)
        {
            Monthload();
            if (m_action==1)
            {
                txtDivision.Enabled = true;
            }
        }
        private void txtMonthID_TextChanged(object sender, EventArgs e)
        {
            int x = txtMonthID.SelectionStart;
            txtMonthID.Text = Utility.gmakeProperCase(txtMonthID.Text).ToUpper();
            txtMonthID.SelectionStart = x;
    
        }
        #endregion
        #region "Display List"

        private void DisplayList(List<ProjectionSet> tests, object sender, EventArgs e)
        {
            txtMonthID.Text = "";
            lstDivision.Visible = false;
            int introw = 0;
            try
            {

                string strYn = "";

                m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                strYn = Utility.Right(tests[0].strProjectionKey, 1);
                uctxtOldKey.Text = tests[0].strProjectionKey;
                txtMonthID.Text = tests[0].strMonthID;
                txtDivision.Text = tests[0].strDivision;
                DG.Rows.Clear();
                DG.Columns.Clear();
                DGLoad();
                List<ProjectionSet> ooaccVou = objExtra.mFillDisplayLedgerName(strComID, tests[0].strProjectionKey,txtDivision.Text).ToList();
                if (ooaccVou.Count > 0)
                {
                    foreach (ProjectionSet oCom in ooaccVou)
                    {
                        DG.Rows.Add();
                        DG[0, introw].Value = oCom.strAMFM;
                        DG[1, introw].Value = oCom.strMpoName;
                        DG[2, introw].Value = oCom.strMerzeName;
                        introw += 1;
                    }
              



                    DG.AllowUserToAddRows = false;

                }

                List<ProjectionSet> ooaccVoub = objExtra.mFillDisplayMonthlyProjection(strComID, txtMonthID.Text, txtDivision.Text).ToList();
                if (ooaccVoub.Count > 0)
                {
                    foreach (ProjectionSet oCom in ooaccVoub)
                    {

                        DG[oCom.intCol, oCom.intRow].Value = oCom.dblToAmt;
                    }

                }

                lstDivision.Visible = false;
                ZoneLoad();
                DG.Focus();
            }
            catch (Exception ex)
            {

            }
        }
        private void ZoneLoad()
        {
            List<ProjectonMonthConfig> objZone = objExtra.getZoneFromDivsion(strComID, txtDivision.Text).ToList();
            if (DG.RowCount > 0)
            {
                if (objZone.Count > 0)
                {
                    lblTotalArea.Text = objZone[0].lngTotalArea.ToString();
                    lblTotalMpo.Text = objZone[0].lngTotalLedger.ToString();
                    uctxtZone.Text = objZone[0].strZone.ToString();
                }
            }
            //LedgerAdd(txtDivision.Text);
            lstDivision.Visible = false;
            DG.Focus();
        }
        #endregion
        #region "Clear"
        private void m_clear()
        {
            if (m_action == 1)
            {
                txtDivision.Text = "";
                txtDivision.Focus();
            }
        }
        #endregion
        #region "Validation"
        private bool ValidateFields()
        {
            string strDuplicate = "";
            {
                if (txtMonthID.Text.ToString() == "")
                {
                    MessageBox.Show("Code Cannot be Empty");
                    txtMonthID.Focus();
                    return false;
                }
            }

            {

                //if (Utility.gblnAccessControl)
                //{
                //    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                //    {
                //        MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return false;
                //    }
                //}

                if (m_action == 2)
                {

                    if (uctxtOldKey.Text.Trim() != strProjectionKey)
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "PRO_MONTHLY_PROJECTION_CHILD", "MONTHLY_PROJECTION_KEY", strProjectionKey);
                        if (strDuplicate != "")
                        {
                            txtDivision.Focus();
                            MessageBox.Show(strDuplicate);
                            return false; ;
                        }
                    }
                }
                else
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "PRO_MONTHLY_PROJECTION_CHILD", "MONTHLY_PROJECTION_KEY", strProjectionKey);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtDivision.Focus();
                        return false; ;
                    }
                }
            }

            return true;
        }
        #endregion
        #region "Load"
        private void frmProjectionSetup_Load(object sender, EventArgs e)
        {

            Monthload();
            lstDivision.ValueMember = "strGRName";
            lstDivision.DisplayMember = "strGRName";
            lstDivision.DataSource = objExtra.mGetLedgerGroupLoad(strComID, 2).ToList();
            DGLoad();
            txtDivision.Select();
        }
        private void DGLoad()
        {
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("AM/FM", "AM/FM", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Ledger Name1", "Ledger Name1", 280, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("MPO Name", "MPO Name", 155, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Total", "Total", 100, true, DataGridViewContentAlignment.TopLeft, true));
            List<ProjectionSet> oogrp = objExtra.mFillMonthlyProjection(strComID, txtMonthID.Text).ToList();
            if (oogrp.Count > 0)
            {
                foreach (ProjectionSet ogrp in oogrp)
                {
                    DG.Columns.Add(Utility.Create_Grid_Column(ogrp.strProjectionName, ogrp.strProjectionName, 75, true, DataGridViewContentAlignment.TopLeft, false));
                    
                }
            }
            DG.Columns[0].Frozen = true;
            DG.Columns[0].DefaultCellStyle.BackColor = Color.Honeydew;
            DG.Columns[2].Frozen = true;
            DG.Columns[2].DefaultCellStyle.BackColor = Color.Honeydew;
            DG.Columns[3].Frozen = true;
            DG.Columns[3].DefaultCellStyle.BackColor = Color.Bisque;
          
        }
        private void Monthload()
        {
            txtMonthID.ReadOnly = true;
            txtMonthID.Text = "";
            List<ProjectonMonthConfig> MonthLoad = objExtra.mFillMonthConfig(strComID, 1).ToList();
            if (MonthLoad.Count > 0)
            {
                foreach (ProjectonMonthConfig oo in MonthLoad)
                {
                    txtMonthID.Text = oo.strMonthID;
                }
            }
          
        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            strProjectionKey = txtMonthID.Text + txtDivision.Text.Trim();
            string strkey = "";
            double dblAmount = 0;
            int intDel = 1;
            if (ValidateFields() == false)
            {
                return;
            }

            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        strkey = txtMonthID.Text + "A";
                        for (int intcol = 3; intcol <= DG.Columns.Count - 1; intcol++)
                        {
                            string strHead = DG.Columns[intcol].HeaderText;
                            for (int i = 0; i < DG.Rows.Count; i++)
                            {
                                if (DG[intcol, i].Value != null)
                                {
                                    dblAmount = Convert.ToDouble(DG[intcol, i].Value.ToString());
                                }
                                else
                                {
                                    dblAmount = 0;
                                }
                                strmsg = objExtra.mInsertMonthlyProjection(strComID, strProjectionKey, txtMonthID.Text, txtDivision.Text, DG[0, i].Value.ToString(), DG[1, i].Value.ToString(), strHead, dblAmount, 0, intcol, i);
                            }
                        }
                        DG.Rows.Clear();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                       
                        for (int intcol = 3; intcol <= DG.Columns.Count - 1; intcol++)
                        {
                            string strHead = DG.Columns[intcol].HeaderText;
                            for (int i = 0; i < DG.Rows.Count; i++)
                            {
                                if (DG[intcol, i].Value != null)
                                {
                                    dblAmount = Convert.ToDouble(DG[intcol, i].Value.ToString());
                                }
                                else
                                {
                                    dblAmount = 0;
                                }
                                strmsg = objExtra.mInsertMonthlyProjection(strComID, strProjectionKey, txtMonthID.Text, txtDivision.Text, DG[0, i].Value.ToString(), DG[1, i].Value.ToString(), strHead, dblAmount, intDel, intcol, i);

                                intDel = intDel + 1;
                            }

                        }
                        DG.Rows.Clear();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            m_clear();
            frmMonthlyProjectionList objfrm = new frmMonthlyProjectionList();
            objfrm.onAddAllButtonClicked = new frmMonthlyProjectionList.AddAllClick(DisplayList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.m_action = 2;
            objfrm.strFormTitel = "Projection List";
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            txtMonthID.Focus();
        }
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                DG.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDivision.Text=="")
            {
                MessageBox.Show("Projection Name is Emtey");
                txtDivision.Focus();
                return;
            }

            if (GridChaek() == false)
            {
                return;
            }
        }
        #endregion
        #region "Method"
        private bool GridChaek()
        {
            string strDown = "";
            Boolean blngCheck = false;
            for (int j = 0; j < DG.RowCount; j++)
            {
                if (DG[1, j].Value != null)
                {
                    strDown = DG[1, j].Value.ToString();
                }
                if (txtDivision.Text == strDown.ToString())
                {
                    MessageBox.Show(" Projection already In List", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blngCheck = true;
                    txtDivision.Text = "";
                    txtDivision.Focus();
                    return false;
                }

            }
            return true;

        }
        #endregion
        #region "Celledit"
        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                double dblAmount = 0,dblTotal=0;
                for (int intCol = 4; intCol < DG.Columns.Count; intCol++)
                {
                    if (DG[intCol, e.RowIndex].Value !=null)
                    {
                        dblAmount = Utility.Val(DG[intCol, e.RowIndex].Value.ToString());
                    }
                    else
                    {
                        dblAmount = 0;
                    }

                    dblTotal = dblTotal + dblAmount;
                   
                }
                DG[3, e.RowIndex].Value = dblTotal;
              
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        private void DG_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void DG_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }








    }
}
