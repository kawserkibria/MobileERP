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
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Inventory
{
    public partial class frmMeasurementUnit : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public int m_action { get; set; }
        public int mSingleEntry { get; set; }
        public long lngFormPriv { get; set; }
        public string strFormName { get; set; }
        public string strOldInit { get; set; }
        private string strComID { get; set; }
        public frmMeasurementUnit()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.uctxtSymbol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtSymbol_KeyPress);
            this.uctxtFormalName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtFormalName_KeyPress);
            this.uctxtNoofDecimalPlaces.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNoofDecimalPlaces_KeyPress);
            this.uctxtSymbol.TextChanged += new System.EventHandler(this.uctxtSymbol_TextChanged);
        }
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
        private void frmMeasurementUnit_Load(object sender, EventArgs e)
        {
            uctxtSymbol.Select();
            DG.Columns.Add(Utility.Create_Grid_Column("SL No", "Sl No", 300, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Symbol", "Symbol", 280, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Formal Name", "Formal Name", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Decimal Places", "Decimal Places", 200, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Edit", "Edit", "Edit", 60, true, DataGridViewContentAlignment.TopCenter, true));
            DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, true, DataGridViewContentAlignment.TopCenter, true));
            mLoadUnitList();
        }
        #region "User Define"
        private void uctxtSymbol_TextChanged(object sender, EventArgs e)
        {
            int x = uctxtSymbol.SelectionStart;
            uctxtSymbol.Text = Utility.gmakeProperCase(uctxtSymbol.Text);
            uctxtSymbol.SelectionStart = x;
        }
        private void uctxtSymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (m_action == 1)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_UNIT_MEASUREMENT", "UNIT_SYMBOL", uctxtSymbol.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtSymbol.Text = "";
                        uctxtSymbol.Focus();
                        return;
                    }
                }
                uctxtFormalName.Focus();

            }
        }
        private void uctxtFormalName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtNoofDecimalPlaces.Focus();

            }
        }
        private void uctxtNoofDecimalPlaces_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSave.Focus();

            }
        }
        #endregion
        #region "Unit List"
        private void mLoadUnitList()
        {
            int introw = 0;
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.Rows.Clear();
            List<MeasurementUnit> oogrp = invms.mLoadMeasurementUnit(strComID).ToList();
            if (oogrp.Count > 0)
            {
                foreach (MeasurementUnit ogrp in oogrp)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = ogrp.lngslNo;
                    DG[1, introw].Value = ogrp.strSymbol;
                    DG[2, introw].Value = ogrp.strFommalName;
                    DG[3, introw].Value = ogrp.noodDecimalPlace;

                    DG[4, introw].Value = "Edit";
                    DG[5, introw].Value = "Delete";
                    if (introw % 2 == 0)
                    {
                        DG.Rows[introw].DefaultCellStyle.BackColor = Color.Beige;
                    }
                    else
                    {
                        DG.Rows[introw].DefaultCellStyle.BackColor = Color.White;
                    }
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
            }
        }
        #endregion
        #region "Click"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "";
            long lngDecimal = 0;
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }
            if (uctxtSymbol.Text == "")
            {
                MessageBox.Show("Symbol Name Cannot be Empty");
                uctxtSymbol.Focus();
                return;
            }
            if (uctxtFormalName.Text == "")
            {
                MessageBox.Show("Formal Name Cannot be Empty");
                uctxtFormalName.Focus();
                return;
            }
            if (uctxtNoofDecimalPlaces.Text =="")
            {
                lngDecimal = 0;
            }
            else
            {
                lngDecimal = Convert.ToInt64(uctxtNoofDecimalPlaces.Text);
            }
            if (m_action == 1)
            {
                string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_UNIT_MEASUREMENT", "UNIT_SYMBOL", uctxtSymbol.Text);
                if (strDuplicate != "")
                {
                    MessageBox.Show(strDuplicate);
                    uctxtSymbol.Text = "";
                    uctxtSymbol.Focus();
                    return;
                }
                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mInsertUnitMeasurement(strComID, uctxtSymbol.Text.ToString().Replace("'", "''"), uctxtFormalName.Text.ToString().Replace("'", "''"), lngDecimal);
                        
                        if (i == "Inseretd...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, strFormName,
                                                                        1, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                            }
                            btnNew.PerformClick();
                            uctxtSymbol.Focus();
                            uctxtFormalName.Text = "";
                            uctxtSymbol.Text = "";
                            uctxtNoofDecimalPlaces.Text = "0";
                            mLoadUnitList();
                            if (mSingleEntry==1)
                            {
                                mSingleEntry = 0;
                                this.Dispose();
                            }
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
                if (strOldInit != uctxtSymbol.Text)
                {
                    string strDuplicate = Utility.mCheckDuplicateItem(strComID, "INV_UNIT_MEASUREMENT", "UNIT_SYMBOL", uctxtSymbol.Text);
                    if (strDuplicate != "")
                    {
                        MessageBox.Show(strDuplicate);
                        uctxtSymbol.Focus();
                        return;
                    }
                }
                var strResponseInsert = MessageBox.Show("Do You Want to Update?", "Update Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = invms.mUpdateMeasurementUnit(strComID, Convert.ToInt64(txtSlNo.Text), uctxtSymbol.Text.ToString().Replace("'", "''"), uctxtFormalName.Text.ToString().Replace("'", "''"), lngDecimal);

                        if (i == "Updated...")
                        {
                            if (Utility.gblnAccessControl)
                            {
                                string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, strFormName,
                                                                        2, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                            }
                            btnNew.PerformClick();
                            uctxtSymbol.Focus();
                            uctxtFormalName.Text = "";
                            uctxtSymbol.Text = "";
                            uctxtNoofDecimalPlaces.Text = "0";
                            mLoadUnitList();
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
        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DG.Rows.Count > 0)
            {
                txtSlNo.Text = "";
                uctxtFormalName.Text = "";
                uctxtSymbol.Text = "";
                uctxtNoofDecimalPlaces.Text = "0";
                m_action = 2;
                txtSlNo.Text = DG.CurrentRow.Cells[0].Value.ToString();

                strOldInit = DG.CurrentRow.Cells[1].Value.ToString();
                uctxtSymbol.Text = DG.CurrentRow.Cells[1].Value.ToString();
                uctxtFormalName.Text = DG.CurrentRow.Cells[2].Value.ToString();
                uctxtNoofDecimalPlaces.Text = DG.CurrentRow.Cells[3].Value.ToString();
                uctxtSymbol.Focus();
              
            }
        }
        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (Utility.gblnAccessControl)
                {
                    if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, 3))
                    {
                         MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        return;
                    }
                }
                var strResponse = MessageBox.Show("Do You Want to Delete?", "Delete Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponse == DialogResult.Yes)
                {
                    txtSlNo.Text = "";
                    uctxtFormalName.Text = "";
                    uctxtSymbol.Text = "";
                    uctxtNoofDecimalPlaces.Text = "0";
                    m_action = 1;
                    string i = invms.DeleteMeasurementUnit(strComID, DG.CurrentRow.Cells[0].Value.ToString(),
                                                            Convert.ToInt64(DG.CurrentRow.Cells[0].Value.ToString()));
                    if (i == "Delted...")
                    {
                        if (Utility.gblnAccessControl)
                        {
                            string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), strFormName, strFormName,
                                                                    3, 0, (int)Utility.MODULE_TYPE.mtSTOCK, "0001");
                        }
                    }
                    MessageBox.Show(i.ToString());
                    mLoadUnitList();
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            m_action = 1;
            txtSlNo.Text = "";
            uctxtFormalName.Text = "";
            uctxtSymbol.Text = "";
            uctxtNoofDecimalPlaces.Text = "0";
            uctxtSymbol.Focus();
        }

        #endregion



    }
}
