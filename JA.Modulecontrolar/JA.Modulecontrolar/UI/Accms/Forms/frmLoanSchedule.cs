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
using JA.Modulecontrolar.UI.Forms;
using JA.Modulecontrolar.UI.Accms.Forms;
using Microsoft.Win32;


namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmLoanSchedule : JA.Shared.UI.frmSmartFormStandard
    {

        JACCMS.SWJAGClient accms = new SWJAGClient();
        public  int m_action { get; set; }
        public long lngFormPriv { get; set; }
        private string strComID { get; set; }
        public frmLoanSchedule()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
          
            this.uctxtTemplateName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTemplateName_KeyPress);
            this.uctxtTotalAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtTotalAmount_KeyPress);
            this.uctxtTotalAmount.TextChanged += new System.EventHandler(this.uctxtTotalAmount_TextChanged);
            this.uctxtNoOfIstallment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtNoOfIstallment_KeyPress);
            this.uctxtNoOfIstallment.TextChanged += new System.EventHandler(this.uctxtNoOfIstallment_TextChanged);
            this.uctxtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtAmount_KeyPress);

            this.DG.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DG_CellFormatting);
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
          
          
        }
        #region "USer Define"
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            double dblAmount = 0, dblMonthly = 0, dblMod = 0, dblAmount1=0;
            if (uctxtTotalAmount.Text =="")
            {
                return;
            }
            if (uctxtNoOfIstallment.Text == "" && uctxtAmount.Text =="")
            {
                return;
            }
            try
            {
                 long lngInstall;
                DG.Rows.Clear();
              
                if (uctxtAmount.Text == "")
                {
                    lngInstall = Convert.ToInt32(uctxtNoOfIstallment.Text);
                    dblAmount = Convert.ToDouble(uctxtTotalAmount.Text);
                    
                }
                else
                {
                    lngInstall = Convert.ToInt64(Convert.ToDouble(uctxtTotalAmount.Text) / Convert.ToDouble(uctxtAmount.Text));
                    dblAmount = Convert.ToDouble(uctxtTotalAmount.Text);
                    uctxtNoOfIstallment.Text = lngInstall.ToString();
                }
                dblMod = (dblAmount % lngInstall);
                if (uctxtAmount.Text == "")
                {
                    dblMonthly = Math.Round(dblAmount / lngInstall, 0);
                    uctxtAmount.Text = dblMonthly.ToString();
                }
                else
                {
                    dblMonthly = Convert.ToDouble(uctxtAmount.Text);
                }
                int intRow = 0, intRow1 = 1;
                for (intRow = 0; intRow < lngInstall; intRow++)
                {
                    DG.Rows.Add();
                    //DG[0, intRow].Value = Utility.NumberToWords(intRow);
                    DG[0, intRow].Value = intRow1.ToString().PadLeft(3, '0');
                    dblAmount1 = dblAmount1+ dblMonthly;
                    if (lngInstall == intRow1)
                    {
                        if (dblAmount1 > dblAmount)
                        {
                            DG[1, intRow].Value = dblMonthly -(dblAmount1 - dblAmount);
                        }
                        else
                        {
                            DG[1, intRow].Value = dblMonthly + dblMod;
                        }
                    }
                    else
                    {
                        DG[1, intRow].Value = dblMonthly;
                    }
                    intRow1 += 1;
                }
                DG.AllowUserToAddRows = false;
                calculateTotal();
                btnSave.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        #region "Calculatetotal
        public void calculateTotal()
        {
            int intloop = 0;
            double dblTotalAmount = 0;



            for (int i = 0; i < DG.Rows.Count; i++)
            {
                    dblTotalAmount = dblTotalAmount + Utility.Val(DG.Rows[i].Cells[1].Value.ToString());
            }


            lblNetTotal.Text = Math.Round(dblTotalAmount, 0).ToString();
            


        }
        #endregion
        private void uctxtNoOfIstallment_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtNoOfIstallment.Text) == false)
            {
                uctxtNoOfIstallment.Text = "";
            }
        }
        private void uctxtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            if (Utility.IsNumericNew(uctxtTotalAmount.Text) == false)
            {
                uctxtTotalAmount.Text = "";
            }
        }
        private void DG_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                e.SuppressKeyPress = true;
                int iColumn = DG.CurrentCell.ColumnIndex;
                int iRow = DG.CurrentCell.RowIndex;
                if (iColumn == DG.Columns.Count - 1)
                    btnSave.Focus();
                else
                    DG.CurrentCell = DG[iColumn + 1, iRow];


            }
        }
        private void uctxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                btnGenerate.PerformClick();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtNoOfIstallment, uctxtTotalAmount);
            }

        }
        private void uctxtNoOfIstallment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                
                uctxtAmount.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtNoOfIstallment, uctxtTotalAmount);
            }

        }
        private void DG_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DG.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Bisque;
            DG.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            DG.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("verdana", 9);
        }

        private void uctxtTemplateName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtTotalAmount.Focus();
            }
        }
        

       

        private void uctxtTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtNoOfIstallment.Focus();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                Utility.PriorSetFocusText(uctxtNoOfIstallment, uctxtTotalAmount);
            }
           
        }
       
        #endregion
       
        private void frmLoanScheduleList_Load(object sender, EventArgs e)
        {
            uctxtTemplateName.Select();
            uctxtTemplateName.Focus();
            DG.AllowUserToAddRows = false;
            DG.Columns.Add(Utility.Create_Grid_Column("No of Installment", "No of Installment", 250, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 150, true, DataGridViewContentAlignment.TopLeft, false));
            DG.AllowUserToAddRows = false;
        }

        private void DG_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strMaster = "";
            double dblTotalAmount = 0, dblMonthly = 0;
            if (uctxtTemplateName.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtTemplateName.Focus();
                return;
            }
            if (uctxtTotalAmount.Text == "")
            {
                MessageBox.Show("Cannot be Empty");
                uctxtTotalAmount.Focus();
                return;
            }
            string strDuplicate = Utility.mCheckDuplicateItem(strComID, "ACC_PAYMENT_SCHEDULE", "TEMPLATE_NAME", textBox1.Text);
            if(strDuplicate !="")
            {
                MessageBox.Show("Transaction Found, You Cannot Edit");
                return;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID, Utility.gstrUserName, lngFormPriv, m_action))
                {
                    MessageBox.Show("You have no Permission to Access", "Privileges", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            long lngInstall = Convert.ToInt32(uctxtNoOfIstallment.Text);
            dblTotalAmount = Convert.ToDouble(uctxtTotalAmount.Text);

            strMaster = accms.mSaveLoanMaster(strComID, textBox1.Text.ToString(), uctxtTemplateName.Text.ToString(), dblTotalAmount, lngInstall, "", Convert.ToDouble(uctxtAmount.Text), 1);
            if (strMaster == "1")
            {
                for (int i = 0; i < DG.Rows.Count; i++)
                {

                    if (DG[1, i].Value.ToString() != null)
                    {
                        dblMonthly = Utility.Val(DG[1, i].Value.ToString());
                    }
                    else
                    {
                        dblMonthly = 0;
                    }
                    strMaster = accms.mSaveLoanMaster(strComID, textBox1.Text.ToString(), uctxtTemplateName.Text.ToString(), dblTotalAmount, lngInstall, DG[0, i].Value.ToString(), dblMonthly, 2);
                }
                if (Utility.gblnAccessControl)
                {
                    string strAudit = Utility.gblnAuditTrail(Utility.gstrUserName, DateTime.Now.ToString("dd/MM/yyyy"), "Loan Template", uctxtTotalAmount.Text,
                                                            m_action , dblTotalAmount, (int)Utility.MODULE_TYPE.mtACCOUNT, "0001");
                }
                mClear();
            }
        }
       
        private void mClear()
        {
            uctxtTemplateName.Text = "";
            uctxtTotalAmount.Text = "";
            uctxtNoOfIstallment.Text = "";
            lblNetTotal.Text = "0";
            DG.Rows.Clear();
            m_action = 1;
            textBox1.Text = "";
            uctxtAmount.Text = "";
            uctxtTemplateName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mClear();
            frmLoanScheduleList objfrm = new frmLoanScheduleList();
            objfrm.onAddAllButtonClicked = new frmLoanScheduleList.AddAllClick(DisplayReqList);
            objfrm.lngFormPriv = lngFormPriv;
            objfrm.Show();
            objfrm.MdiParent = this.MdiParent;
        }
        private void DisplayReqList(List<AccountsLedger> tests, object sender, EventArgs e)
        {
            try
            {
                m_action = 2;
                //uctxtTemplateName.ReadOnly = true;
                //uctxtTotalAmount.ReadOnly = true;
                uctxtTemplateName.Select();
                uctxtTemplateName.Focus();
                List<AccountsLedger> ogrp = accms.mDisplayLoanList(strComID, tests[0].strLedgerName).ToList();
                {
                    textBox1.Text = tests[0].strLedgerName;
                    uctxtTotalAmount.Text = tests[0].dblToAmt.ToString();
                    uctxtNoOfIstallment.Text = tests[0].dblNoVoucher.ToString();
                    
                    uctxtTemplateName.Text = tests[0].strLedgerName;
                    if (ogrp.Count > 0)
                    {
                        int introw = 0;
                        foreach (AccountsLedger display in ogrp)
                        {
                            DG.Rows.Add();
                            if (introw == 0)
                            {
                                uctxtAmount.Text = display.dblToAmt.ToString();
                            }
                           
                            DG[0, introw].Value = display.strmerzeString;
                            DG[1, introw].Value = display.dblToAmt.ToString();
                            introw += 1;
                        }
                        DG.AllowUserToAddRows = false;
                    }
                    calculateTotal();
                }
            }
            catch (Exception ex)
            {

            }
        }

      
       

       
    }
}
