//using ExtraReports.Projection.Reports.RProjection.Viewer;
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
 
    public partial class frmProjectionSetup : JA.Shared.UI.frmSmartFormStandard
    {

        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient();
        private ListBox lstLedger = new ListBox();
        private ListBox lstProjectionName = new ListBox();
        DateTime dteFDate, dteTDate;
        public delegate void AddAllClick(List<ProjectionSet> items, object sender, EventArgs e);
        public AddAllClick onAddAllButtonClicked;
        long lngDiff = 0;
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
        public string strMontName = "";
        public string strProjectionMonthYY = "";
        public string strStrartMonhtYY = "";
        public string strEndMonhtYY = "";
        public string mstrOldProjectionKey { get; set; }
        
        public string strProjectionMonth = "";
        public string strStrartMonht = "";
        public string strEndMonht = "";

        public string strmsg = "";
        public int intDateIntervale = 0;
        public int intday = 0;
        public int m_action { get; set; }
        private string strComID { get; set; }
        public frmProjectionSetup()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.txtMonthID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonthID_KeyPress);
            this.txtMonthID.GotFocus += new System.EventHandler(this.txtMonthID_GotFocus);
            this.txtMonthID.KeyDown += new KeyEventHandler(txtMonthID_KeyDown);
            this.txtMonthID.TextChanged += new System.EventHandler(this.txtMonthID_TextChanged);

            this.txtProjectionName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProjectionName_KeyPress);
            this.txtProjectionName.GotFocus += new System.EventHandler(this.txtProjectionName_GotFocus);
            this.txtProjectionName.KeyDown += new KeyEventHandler(txtProjectionName_KeyDown);
            this.txtProjectionName.TextChanged += new System.EventHandler(this.txtProjectionName_TextChanged);
            this.lstProjectionName.DoubleClick += new System.EventHandler(this.lstProjectionName_DoubleClick);
            Utility.CreateListBox(lstProjectionName, pnlMain, txtProjectionName);



            this.dtpProjectionDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpProjectionDate_KeyPress);
            this.dtpFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpFromDate_KeyPress);
            this.dtpTdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtpTdate_KeyPress);


    

         
        }
        private void dtpProjectionDate_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            string strPMonth = Convert.ToDateTime(dtpProjectionDate.Text).ToString("MMM").ToUpper();
            string strPYear = Convert.ToDateTime(dtpProjectionDate.Text).ToString("yy");

            if (e.KeyChar == (char)Keys.Return)
            {
                if (strMontName != strPMonth)
                {
                    MessageBox.Show("Month Not Same");
                }
                else if (strPYear != strMontNameYY)
                {
                    MessageBox.Show("Month Not Same");
                }
                else
                {
                    dtpFromDate.Focus();
                }


                
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                txtMonthID.Focus();
            }
        }
        private void dtpFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                string strSMonth = Convert.ToDateTime(dtpFromDate.Text).ToString("MMM").ToUpper();
                string strSYear = Convert.ToDateTime(dtpFromDate.Text).ToString("yy");

                if (e.KeyChar == (char)Keys.Return)
                {
                    if (strMontName != strSMonth)
                    {
                        MessageBox.Show("Month Not Same");
                    }
                    else if (strSYear != strMontNameYY)
                    {
                        MessageBox.Show("Month Not Same");
                    }
                    else
                    {
                        dtpTdate.Focus();
                    }


                }
            }


        }
        private void dtpTdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                string strEMonth = Convert.ToDateTime(dtpTdate.Text).ToString("MMM").ToUpper();
                string strEYear = Convert.ToDateTime(dtpTdate.Text).ToString("yy");
                if (e.KeyChar == (char)Keys.Return)
                {
                    if (strMontName != strEMonth)
                    {
                        MessageBox.Show("Projection Month Not Same");
                    }
                    else if (strEYear != strMontNameYY)
                    {
                        MessageBox.Show("Month Not Same");
                    }
                    else if (txtProjectionName.Text == "")
                    {
                        MessageBox.Show("Projection Name is Emtey");
                        txtProjectionName.Focus();
                        return;
                    }
                    else
                    {

                        if (GridChaek() == false)
                        {
                            return;
                        }
                        ProjectionAdd();
                    }


                }
            }

        }
        private void txtProjectionDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dtpFromDate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                //Utility.PriorSetFocusText(txtProjectionDate, txtMonthID);
            }

        }
        private void txtProjectionDate_GotFocus(object sender, System.EventArgs e)
        {

            if (m_action == 1)
            {
                //lstEmpCardNo.Visible = false;
                //txtFdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }

        }
        private void txtFdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                dtpTdate.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                //Utility.PriorSetFocusText(txtFdate, txtProjectionDate);
            }

        }
        private void txtFdate_GotFocus(object sender, System.EventArgs e)
        {

            if (m_action == 1)
            {
                //lstEmpCardNo.Visible = false;
                //txtFdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }

        }

 
     
        private void ProjectionAdd()
        {
            //strProjectionKey = txtMonthID.Text.Trim() + txtProjectionName.Text.Trim() +Convert.ToDateTime( dtpProjectionDate.Text).ToString("ddMMyyyy");
            strProjectionKey = txtMonthID.Text.Trim() + txtProjectionName.Text.Trim();
            if (txtMonthID.Text=="")
            {
                MessageBox.Show("Code Cannot be Empty");
                txtMonthID.Focus();
                return ;
            }

            int  selRaw = 0;

            if (ValidateFields() == false)
            {
                return;
            }
                DG.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DG.RowCount.ToString());
                selRaw = selRaw - 1;
                DG.Rows.Add();
                DG[0, selRaw].Value = strProjectionKey;
                DG[1, selRaw].Value = txtProjectionName.Text;
                DG[2, selRaw].Value = dtpProjectionDate.Text;
                DG[3, selRaw].Value = dtpFromDate.Text;
                DG[4, selRaw].Value = dtpTdate.Text;
                DG[5, selRaw].Value = "Delete";
                DG.AllowUserToAddRows = false;
                m_clear();
                txtProjectionName.Focus();
            
        }

        private void MonName()
        {
            strMontName = txtMonthID.Text.Substring(0, 3).ToUpper();
            strMontNameYY = txtMonthID.Text.Substring(3, 2).ToUpper();
        }
       
        private void txtMonthID_KeyPress(object sender, KeyPressEventArgs e)
        {
            MonName();

            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtMonthID.Text == "")
                {
                    txtMonthID.Focus();
                }
                else
                {
                    txtProjectionName.Focus();
                }
               
            }
        }
        private void txtMonthID_GotFocus(object sender, System.EventArgs e)
        {
            Monthload();
            if (m_action==1)
            {
                txtProjectionName.Enabled = true;
            }
            lstProjectionName.Visible = false;
        }
        private void txtProjectionName_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstProjectionName.Items.Count > 0)
                {
                    if (txtProjectionName.Text != "")
                    {
                        txtProjectionName.Text = lstProjectionName.Text;
                        lstProjectionName.Visible = false;
                        dtpProjectionDate.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                dtpProjectionDate.Focus();
            }
           
        }
        private void txtProjectionName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                if (lstProjectionName.SelectedItem != null)
                {
                    lstProjectionName.SelectedIndex = lstProjectionName.SelectedIndex - 1;
                    txtProjectionName.Text = lstProjectionName.Text;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstProjectionName.Items.Count - 1 > lstProjectionName.SelectedIndex)
                {
                    lstProjectionName.SelectedIndex = lstProjectionName.SelectedIndex + 1;
                    txtProjectionName.Text = lstProjectionName.Text;
                }
            }

        }
        private void txtProjectionName_TextChanged(object sender, EventArgs e)
        {
            lstProjectionName.SelectedIndex = lstProjectionName.FindString(txtProjectionName.Text);

        }
        private void lstProjectionName_DoubleClick(object sender, EventArgs e)
        {
            txtProjectionName.Text = lstProjectionName.Text;
            lstProjectionName.Visible = false;
            dtpProjectionDate.Focus();


        }
        private void txtProjectionName_GotFocus(object sender, System.EventArgs e)
        {
            lstProjectionName.Visible = true;
            Monthload();
            mloadProjectionName();

        }
        private void txtMonthID_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtMonthID_TextChanged(object sender, EventArgs e)
        {
            int x = txtMonthID.SelectionStart;
            txtMonthID.Text = Utility.gmakeProperCase(txtMonthID.Text).ToUpper();
            txtMonthID.SelectionStart = x;
    
        }
        private void txtMonthID_DoubleClick(object sender, EventArgs e)
        {
        
        }

        #region "Display List"
        private void DisplayList(List<ProjectionSet> tests, object sender, EventArgs e)
        {
            int selRaw = 0;
            try
            {

                DG.Rows.Clear();
                m_clear();
                txtMonthID.ReadOnly = true;
                mstrOldProjectionKey = tests[0].strProjectionKey.ToString();
                txtMonthID.Text = tests[0].strMonthID.ToString();
                txtProjectionName.Text = tests[0].strProjectionName.ToString();
                dtpProjectionDate.Text = tests[0].strProjectionDate.ToString();
                dtpFromDate.Text = tests[0].strStartDate.ToString();
                dtpTdate.Text = tests[0].strEndDate.ToString();
                DG.AllowUserToAddRows = true;
                selRaw = Convert.ToInt16(DG.RowCount.ToString());
                selRaw = selRaw - 1;
                DG.Rows.Add();
                DG[0, selRaw].Value = tests[0].strProjectionKey.ToString();
                DG[1, selRaw].Value = tests[0].strProjectionName.ToString();
                DG[2, selRaw].Value = tests[0].strProjectionDate.ToString();
                DG[3, selRaw].Value = tests[0].strStartDate.ToString();
                DG[4, selRaw].Value = tests[0].strEndDate.ToString();
                DG[5, selRaw].Value = "Delete";
                DG.AllowUserToAddRows = false;
                lstProjectionName.Visible = false;
                txtProjectionName.Enabled = false;
                dtpProjectionDate.Focus();
                m_action = 2;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        private void mloadProjectionName()
        {

            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
                {"01st", 1},
                {"02nd", 2},    
                {"03rd", 3},
                {"04th", 4},
                {"05th", 5},
                {"06th", 6},
                {"07th", 7},
                {"08th", 8},
                {"09th", 9},
                {"10th", 10},
                {"11th", 11},
                {"12th", 12},
                {"13th", 13},
                {"14th", 14},
                {"15th", 15},
            };

            lstProjectionName.DisplayMember = "Key";
            lstProjectionName.ValueMember = "Value";
            lstProjectionName.DataSource = new BindingSource(userCache, null);

        }


        private void m_clear()
        {
            if (m_action == 1)
            {
                txtProjectionName.Text = "";
                dtpProjectionDate.Text = "";
                dtpFromDate.Text = "";
                dtpTdate.Text = "";
                //m_action = 1;
                txtProjectionName.Focus();
            }
        }
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

                    if (mstrOldProjectionKey.Trim() != strProjectionKey)
                    {
                        strDuplicate = Utility.mCheckDuplicateItem(strComID, "PROJECTION_SETUP", "PROJECTION_KEY", strProjectionKey);
                        if (strDuplicate != "")
                        {
                            txtProjectionName.Focus();
                            MessageBox.Show(strDuplicate);
                            return false; ;
                        }
                    }
                }
                else
                {
                    strDuplicate = Utility.mCheckDuplicateItem(strComID, "PROJECTION_SETUP", "PROJECTION_KEY", strProjectionKey);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        txtProjectionName.Focus();
                        return false; ;
                    }
                }
            }

            return true;
        }
        #endregion
        private void Status()
        {


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string strGrid = "", i = "";
            if (ValidateFields() == false)
            {
                return;
            }
            //Status();
            if (m_action == 1)
            {
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {

                        for (int introw = 0; introw < DG.Rows.Count; introw++)
                        {

                            strGrid = strGrid + DG[0, introw].Value + "|" +
                                DG[1, introw].Value.ToString() + "|" +Convert.ToDateTime( DG[2, introw].Value).ToString("dd-MM-yyyy") + "|" +
                                               Convert.ToDateTime(DG[3, introw].Value).ToString("dd-MM-yyyy") + "|" +
                                               Convert.ToDateTime(DG[4, introw].Value).ToString("dd-MM-yyyy") + "~";
                                            
                        }

                        i = objExtra.mInsertProjectionSetup(strComID, txtMonthID.Text, strGrid);

                        if (i == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Month Setup", "Month Setup",
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtPURCHASE, "0001");
                            }
                            m_action = 1;
                            DG.Rows.Clear();
                            m_clear();

                        }
                        else
                        {
                            MessageBox.Show(i.ToString());
                        }
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
                        for (int introw = 0; introw < DG.Rows.Count; introw++)
                        {

                            strGrid = strGrid + DG[0, introw].Value + "|" +
                                DG[1, introw].Value.ToString() + "|" + Convert.ToDateTime(DG[2, introw].Value).ToString("dd-MM-yyyy") + "|" +
                                               Convert.ToDateTime(DG[3, introw].Value).ToString("dd-MM-yyyy") + "|" +
                                               Convert.ToDateTime(DG[4, introw].Value).ToString("dd-MM-yyyy") + "~";

                        }
                        i = objExtra.mUpdateProjectionSetup(strComID, txtMonthID.Text, strGrid,mstrOldProjectionKey);

                        if (i == "1")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Month Setup", "Month Setup",
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtPURCHASE, "0001");
                            }
                            DG.Rows.Clear();
                            m_action = 1;
                            m_clear();
                            btnNew.PerformClick();
                            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
                        }
                        else
                        {
                            MessageBox.Show(i.ToString());
                        }
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
            frmProjectionSetupList objfrm = new frmProjectionSetupList();
            objfrm.onAddAllButtonClicked = new frmProjectionSetupList.AddAllClick(DisplayList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.m_action = 2;
            objfrm.strFormTitel = "Projection List";
            objfrm.Show();
            objfrm.MdiParent = MdiParent;
            txtMonthID.Focus();
        }

        private void frmProjectionSetup_Load(object sender, EventArgs e)
        {
            lstProjectionName.Visible = false;
       

            DG.AllowUserToAddRows = false;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Columns.Add(Utility.Create_Grid_Column("ProjectionKey", "ProjectionKey", 80, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Projection Name", "Projection Name", 120, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Projection Date", "Projection Date", 210, true, DataGridViewContentAlignment.TopLeft, false));
            DG.Columns.Add(Utility.Create_Grid_Column("Start Date", "Start Date", 210, true, DataGridViewContentAlignment.TopLeft, false ));
            DG.Columns.Add(Utility.Create_Grid_Column("End Date", "End Date", 210, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            m_action =1;
            Monthload();
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
                    dteFDate = Convert.ToDateTime(oo.strFromDate);
                    dteTDate = Convert.ToDateTime(oo.strToDate);
                    lngDiff = Utility.DateDiff(Utility.DateInterval.Day, dteFDate, dteTDate) + 1;

                }
            }
        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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
            if (txtProjectionName.Text=="")
            {
                MessageBox.Show("Projection Name is Emtey");
                txtProjectionName.Focus();
                return;
            }

            if (GridChaek() == false)
            {
                return;
            }
            ProjectionAdd();
        }

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
                if (txtProjectionName.Text == strDown.ToString())
                {
                    MessageBox.Show(" Projection already In List", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blngCheck = true;
                    txtProjectionName.Text = "";
                    txtProjectionName.Focus();

                    return false;
                }

            }
            return true;

        }
  
    }
}
