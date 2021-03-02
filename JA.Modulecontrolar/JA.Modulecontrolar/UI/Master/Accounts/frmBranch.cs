using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Master.Accounts
{
    public partial class frmBranch : JA.Shared.UI.frmJagoronFromSearch
    {
        private ListBox lstStatus = new ListBox();
        private ListBox lstdefaultBranch = new ListBox();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public int m_action { get; set; }
        public int mSingleEntry { get; set; }
        public long lngFormPriv { get; set; }
        private string strComID { get; set; }
        public frmBranch()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #region"User Define In"
            this.uctxtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtBranchName_KeyPress);
            this.uctxtBranchName.GotFocus += new System.EventHandler(this.uctxtBranchName_GotFocus);

            this.uctxtAddress1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAddress1_KeyPress);
            this.uctxtAddress1.GotFocus += new System.EventHandler(this.uctxtAddress1_GotFocus);

            this.uctxtAddress2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAddress2_KeyPress);
            this.uctxtAddress2.GotFocus += new System.EventHandler(this.uctxtAddress2_GotFocus);

            this.uctxtCountry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtCountry_KeyPress);
            this.uctxtCountry.GotFocus += new System.EventHandler(this.uctxtCountry_GotFocus);

            this.uctxtTelephone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTelephone_KeyPress);
            this.uctxtTelephone.GotFocus += new System.EventHandler(this.uctxtTelephone_GotFocus);

            this.uctxtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFax_KeyPress);
            this.uctxtFax.GotFocus += new System.EventHandler(this.uctxtFax_GotFocus);

            this.uctxtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtLocation_KeyPress);
            this.uctxtLocation.GotFocus += new System.EventHandler(this.uctxtLocation_GotFocus);

            this.uctxtDeafaultBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtDeafaultBranch_KeyPress);
            this.uctxtDeafaultBranch.GotFocus += new System.EventHandler(this.uctxtDeafaultBranch_GotFocus);
            this.uctxtDeafaultBranch.TextChanged += new System.EventHandler(this.uctxtDeafaultBranch_TextChanged);
            this.uctxtDeafaultBranch.KeyDown += new KeyEventHandler(uctxtDeafaultBranch_KeyDown);
            this.lstdefaultBranch.DoubleClick += new System.EventHandler(this.lstdefaultBranch_DoubleClick);

            this.uctxtInactive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtInactive_KeyPress);
            this.uctxtInactive.KeyDown += new KeyEventHandler(uctxtInactive_KeyDown);
            this.uctxtInactive.TextChanged += new System.EventHandler(this.uctxtInactive_TextChanged);
            this.lstStatus.DoubleClick += new System.EventHandler(this.lstStatus_DoubleClick);
            this.uctxtInactive.GotFocus += new System.EventHandler(this.uctxtInactive_GotFocus);

            this.uctxtComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtComments_KeyPress);
            this.uctxtComments.GotFocus += new System.EventHandler(this.uctxtComments_GotFocus);
            Utility.CreateListBox(lstStatus, pnlMain, uctxtInactive);
            Utility.CreateListBox(lstdefaultBranch, pnlMain, uctxtDeafaultBranch);
            //TabChange();
            #endregion

        }
        #region "Tab Change"
        private void TabChange()
        {
            uctxtBranchName.Focus();
            uctxtBranchName.AllToNextTab(uctxtAddress1);
            uctxtAddress1.AllToNextTab(uctxtAddress2);
            uctxtAddress2.AllToNextTab(uctxtCountry);
            uctxtCountry.AllToNextTab(uctxtTelephone);
            uctxtTelephone.AllToNextTab(uctxtFax);
            uctxtFax.AllToNextTab(uctxtLocation);
            uctxtLocation.AllToNextTab(uctxtAddress1);
            uctxtAddress1.AllToNextTab(uctxtDeafaultBranch);
            uctxtDeafaultBranch.AllToNextTab(uctxtInactive);
            uctxtComments.AllToNextTab(btnSave);

        }
        #endregion
        #region "User Define Event"

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Keys.Escape == keyData)
            {
                //return base.ProcessCmdKey(ref msg, keyData);
                var strResponse = MessageBox.Show("                    Quit                    ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    this.Dispose();
                }
            }

            return false;
        }    
       
        private void lstdefaultBranch_DoubleClick(object sender, EventArgs e)
        {
            uctxtDeafaultBranch.Text = lstdefaultBranch.Text;
            uctxtInactive.Focus();
        }
        private void uctxtDeafaultBranch_TextChanged(object sender, EventArgs e)
        {
            lstdefaultBranch.SelectedIndex = lstdefaultBranch.FindString(uctxtDeafaultBranch.Text);
        }
        private void uctxtDeafaultBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstdefaultBranch.SelectedItem != null)
                {
                    lstdefaultBranch.SelectedIndex = lstdefaultBranch.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstdefaultBranch.Items.Count - 1 > lstdefaultBranch.SelectedIndex)
                {
                    lstdefaultBranch.SelectedIndex = lstdefaultBranch.SelectedIndex + 1;
                }
            }

        }
        private void uctxtInactive_GotFocus(object sender, System.EventArgs e)
        {
            lstStatus.Visible = true;
            lstdefaultBranch.Visible = false;
        }

        private void uctxtBranchName_GotFocus(object sender, System.EventArgs e)
        {
            lstStatus.Visible = false;
            lstdefaultBranch.Visible = false;
            uctxtDeafaultBranch.Text = "";

        }
        private void uctxtAddress1_GotFocus(object sender, System.EventArgs e)
        {
            lstStatus.Visible = false;
            lstdefaultBranch.Visible = false;
        }
        private void uctxtAddress2_GotFocus(object sender, System.EventArgs e)
        {
            lstStatus.Visible = false;
            lstdefaultBranch.Visible = false;
        }
        private void uctxtCountry_GotFocus(object sender, System.EventArgs e)
        {
            lstStatus.Visible = false;
            lstdefaultBranch.Visible = false;
        }
        private void uctxtTelephone_GotFocus(object sender, System.EventArgs e)
        {
            lstStatus.Visible = false;
            lstdefaultBranch.Visible = false;
        }
        private void uctxtFax_GotFocus(object sender, System.EventArgs e)
        {
            lstStatus.Visible = false;
            lstdefaultBranch.Visible = false;
        }
        private void uctxtLocation_GotFocus(object sender, System.EventArgs e)
        {
            lstStatus.Visible = false;
            lstdefaultBranch.Visible = false;
        }
        private void uctxtDeafaultBranch_GotFocus(object sender, System.EventArgs e)
        {
            lstStatus.Visible = false;
            lstdefaultBranch.Visible = true;
            lstdefaultBranch.SelectedIndex = lstdefaultBranch.FindString(uctxtDeafaultBranch.Text);
        }


        private void uctxtComments_GotFocus(object sender, System.EventArgs e)
        {
            lstStatus.Visible = false;
            
        }
        private void uctxtInactive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstStatus.SelectedItem != null)
                {
                    lstStatus.SelectedIndex = lstStatus.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstStatus.Items.Count - 1 > lstStatus.SelectedIndex)
                {
                    lstStatus.SelectedIndex = lstStatus.SelectedIndex + 1;
                }
            }

        }
        private void uctxtInactive_TextChanged(object sender, EventArgs e)
        {
            lstStatus.SelectedIndex = lstStatus.FindString(uctxtInactive.Text);
        }

        private void lstStatus_DoubleClick(object sender, EventArgs e)
        {
            uctxtInactive.Text = lstStatus.Text;
            uctxtComments.Focus();
        }

       

        private void uctxtComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();

            }
            if (e.KeyChar ==(char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtComments, uctxtInactive);
            }
        }
        private void uctxtInactive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstStatus.Items.Count > 0)
                {
                    uctxtInactive.Text = lstStatus.Text;
                }
                uctxtComments.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtInactive, uctxtDeafaultBranch);
            }
        }
        private void uctxtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtDeafaultBranch.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtLocation, uctxtFax);
            }
        }
        private void uctxtDeafaultBranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstdefaultBranch.Items.Count > 0)
                {
                    uctxtDeafaultBranch.Text = lstdefaultBranch.Text;
                }
                uctxtInactive.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtDeafaultBranch, uctxtLocation);
            }
        }
        private void uctxtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtLocation.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtFax, uctxtTelephone);
            }
        }
        private void uctxtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtFax.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtTelephone, uctxtCountry);
            }
        }
        private void uctxtCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtTelephone.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtCountry, uctxtAddress2);
            }
        }
        private void uctxtAddress2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtCountry.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtAddress2, uctxtAddress1);
            }
        }
        private void uctxtBranchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtLocation.Text = uctxtBranchName.Text;
                uctxtAddress1.Focus();

            }
        }

        private void uctxtAddress1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtAddress2.Focus();

            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtAddress1, uctxtBranchName);
            }
        }
        #endregion
        #region "Load"
        private void frmBranch_Load(object sender, EventArgs e)
        {
            lstStatus.Visible = false;
            lstdefaultBranch.Visible = false;
            DG.Columns.Add(Utility.Create_Grid_Column("ID", "ID", 70, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Branch Name", "Branch Name", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Address", "Address", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Address1", "Address1", 150, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Country", "Country", 150, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Phone", "Phone", 150, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Fax", "Fax", 150, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Comments", "Comments", 150, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Inactive", "Inactive", 60, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit.", "Edit", "Edit.", 40, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            LoadDefaultValue();
            mLoadBranch();
        }
        #endregion
        #region "Defaultvalue"
        private void LoadDefaultValue()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
              {"No", 1},
              {"Yes", 2}
            };

            lstStatus.DisplayMember = "Key";
            lstStatus.ValueMember = "Value";
            lstStatus.DataSource = new BindingSource(userCache, null);

            lstdefaultBranch.DisplayMember = "Key";
            lstdefaultBranch.ValueMember = "Value";
            lstdefaultBranch.DataSource = new BindingSource(userCache, null);

        }
        #endregion

        #region "Save"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strResponse="";
            if (uctxtBranchName.Text == "")
            {
                MessageBox.Show("Name Cannot be Empty");
                uctxtBranchName.Focus();
                return;
            }

            strResponse = Utility.gGetDefaultBranch(strComID, uctxtBranchName.Text);
            if (strResponse!="")
            {
                MessageBox.Show(strResponse);
                uctxtBranchName.Focus();
                return;
            }

            if (m_action == (int)Utility.ACTION_MODE_ENUM.ADD_MODE)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 1))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }

                var strResponseInsert = MessageBox.Show("Do You Want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        string strmsg = accms.mSaveBranchInfo(strComID,uctxtBranchName.Text, uctxtAddress1.Text, uctxtAddress2.Text, uctxtCountry.Text,
                                                                uctxtTelephone.Text, uctxtFax.Text, "", uctxtComments.Text, uctxtDeafaultBranch.Text,
                                                                uctxtInactive.Text, uctxtBranchName.Text);
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Branch Configuration", "Branch Configuration",
                                                                    1, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                        } 
                        MessageBox.Show(strmsg);
                        if (mSingleEntry==1)
                        {
                            mSingleEntry = 0;
                            this.Dispose();
                        }
                      
                        mLoadBranch();
                        mClear();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 2))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }

                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        string strmsg = accms.mUpdateBranchInfo(strComID,txtbranchId.Text, uctxtBranchName.Text, uctxtAddress1.Text, uctxtAddress2.Text, uctxtCountry.Text,
                                                                uctxtTelephone.Text, uctxtFax.Text, "", uctxtComments.Text, uctxtDeafaultBranch.Text,
                                                                uctxtInactive.Text, uctxtBranchName.Text);

                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Branch Configuration", "Branch Configuration",
                                                                    2, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                        } 
                        MessageBox.Show(strmsg);
                        mLoadBranch();
                        mClear();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }



        }
        #endregion
        #region "Clear"
        private void mClear()
        {
            txtbranchId.Text = "";
            uctxtBranchName.Text = "";
            uctxtAddress1.Text = "";
            uctxtAddress2.Text = "";
            uctxtCountry.Text = "";
            uctxtTelephone.Text = "";
            uctxtFax.Text = "";
            uctxtComments.Text = "";
            uctxtDeafaultBranch.Text = "";
            uctxtBranchName.Text = "";
            uctxtLocation.Text = "";
            m_action = (int)Utility.ACTION_MODE_ENUM.ADD_MODE;
            uctxtBranchName.Focus();
        }
        #endregion
        #region "Load Branch"
        private void mLoadBranch()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<BranchConfig> oogrp = accms.mFillGetBranch(strComID).ToList();
            if (oogrp.Count > 0)
            {

                foreach (BranchConfig ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.BranchID;
                    DG[1, introw].Value = ogrp.BranchName;
                    DG[2, introw].Value = ogrp.BranchAddress1 + ogrp.BranchAddress2;
                    DG[3, introw].Value = ogrp.BranchAddress2;
                    DG[4, introw].Value = ogrp.Country;
                    DG[5, introw].Value = ogrp.Phone;
                    DG[6, introw].Value = ogrp.Fax;
                    DG[7, introw].Value = ogrp.Comments; 
                    DG[8, introw].Value =ogrp.Status ;
                    DG[9, introw].Value = "Edit";
                    DG[10, introw].Value = "Delete";
                    //if (introw % 2 == 0)
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    //}
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }
        #endregion
        #region "Content Click"
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==9)
            {
                if (DG.Rows.Count >0)
                {
                    mClear();
                    m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;
                    txtbranchId.Text = DG.CurrentRow.Cells[0].Value.ToString();
                    uctxtBranchName.Text = DG.CurrentRow.Cells[1].Value.ToString();
                    if (DG.CurrentRow.Cells[2].Value != null)
                    {
                        uctxtAddress1.Text = DG.CurrentRow.Cells[2].Value.ToString();
                    }
                    else
                    {
                        uctxtAddress1.Text = "";
                    }
                    if (DG.CurrentRow.Cells[3].Value != null )
                    {
                        uctxtAddress2.Text = DG.CurrentRow.Cells[3].Value.ToString();
                    }
                    else
                    {
                        uctxtAddress2.Text = "";
                    }
                    if (DG.CurrentRow.Cells[4].Value != null)
                    {
                        uctxtCountry.Text = DG.CurrentRow.Cells[4].Value.ToString();
                    }
                    else
                    {
                        uctxtCountry.Text = "Bangladesh";
                    }
                    if (DG.CurrentRow.Cells[5].Value !=null)
                    {
                        uctxtTelephone.Text = DG.CurrentRow.Cells[5].Value.ToString();
                    }
                    else
                    {
                        uctxtTelephone.Text = "";
                    }
                    if (DG.CurrentRow.Cells[6].Value != null)
                    {
                        uctxtFax.Text = DG.CurrentRow.Cells[6].Value.ToString();
                    }
                    else
                    {
                        uctxtFax.Text = "";
                    }
                    if (DG.CurrentRow.Cells[7].Value != null)
                    {
                        uctxtComments.Text = DG.CurrentRow.Cells[7].Value.ToString();
                    }
                    else
                    {
                        uctxtComments.Text = "";
                    }
                    uctxtDeafaultBranch.Text = "No";
                    uctxtInactive.Text = DG.CurrentRow.Cells[8].Value.ToString();
                    uctxtBranchName.Focus();

                }
            }

            if (e.ColumnIndex==10)
            {
                string strmsg = "";
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID,Utility.gstrUserName, lngFormPriv, 3))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                var strResponseInsert = MessageBox.Show("Do You Want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        strmsg = accms.mDeleteBranchInfo(strComID, DG.CurrentRow.Cells[0].Value.ToString(), DG.CurrentRow.Cells[1].Value.ToString());
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Branch Configuration", "Branch Configuration",
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                        } 
                        MessageBox.Show(strmsg);
                        mLoadBranch();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(strmsg.ToString());
                    }
                }
            }

        }
        #endregion
        private void btnNew_Click(object sender, EventArgs e)
        {
            mClear();
        }

       


    }
}
