using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AH.Shared.MODEL;
using AH.DUtility;
namespace AH.Shared.UI
{
    public partial class frmPayment : frmSmartFormStandard
    {
        public delegate void SaveButtonClick(OPDPayment payObj);
        public SaveButtonClick onSaveButtonClicked;
        private string department;
        private string reffDepartment;
        private string departmentUnit;
        private string reffDepartmentUnit;
        private decimal departmentAmount;
        private decimal reffDepartmentAmount;
        private decimal consultantAmount;
        private string purposeID;
        private string paymentType;
        private DateTime updateDate;
        private string discountBy;
        private Boolean isDueAllowed;
        private short DueStatus;
        public frmPayment()
        {
            InitializeComponent();
        }
        public frmPayment(short mode, string label, string patientNo, string patientName, string purposeID, string amount, string advancePaid, string vatAmount, string discountAmt, string discountBy, string department, string reffDepartment, string departmentUnit, string reffDepartmentUnit, decimal departmentAmount, decimal reffDepartmentAmount, DateTime updateDate, string paymentType, Boolean isDueAllowed)
        {
            InitialiseValues(mode, label, patientNo, patientName, purposeID, amount, advancePaid, vatAmount, discountAmt, discountBy, department, reffDepartment, departmentUnit, reffDepartmentUnit, departmentAmount, reffDepartmentAmount, updateDate, paymentType, 0, isDueAllowed);
        }
        public frmPayment(short mode, string label, string patientNo, string patientName, string purposeID, string amount, string advancePaid, string vatAmount, string discountAmt, string discountBy, string department, string reffDepartment, string departmentUnit, string reffDepartmentUnit, decimal departmentAmount, decimal reffDepartmentAmount, DateTime updateDate, string paymentType, decimal consultantAmount, Boolean isDueAllowed)
        {
            InitializeComponent();
            InitialiseValues(mode, label, patientNo, patientName, purposeID, amount, advancePaid, vatAmount, discountAmt, discountBy, department, reffDepartment, departmentUnit, reffDepartmentUnit, departmentAmount, reffDepartmentAmount, updateDate, paymentType, consultantAmount, isDueAllowed);
        }
        private void InitialiseValues(short mode, string label, string patientNo, string patientName, string purposeID, string amount, string advancePaid, string vatAmount, string discountAmt, string discountBy, string department, string reffDepartment, string departmentUnit, string reffDepartmentUnit, decimal departmentAmount, decimal reffDepartmentAmount, DateTime updateDate, string paymentType, decimal consultantAmount, Boolean isDueAllowed)
        {
            txtPateintNo.Text = patientNo;
            txtPatientName.Text = patientName;
            txtAmount.Text = amount;
            txtAdvancePaid.Text = advancePaid;
            txtVATPercentage.Text = vatAmount;
           
            //txtVATAmount.Text = vatAmount;
            txtDiscountAmount.Text = discountAmt;

            frmLabel.Text = label;
            this.department = department;
            this.reffDepartment = reffDepartment;
            this.departmentAmount = departmentAmount;
            this.reffDepartmentAmount = reffDepartmentAmount;
            this.departmentUnit = departmentUnit;
            this.reffDepartmentUnit = reffDepartmentUnit;
            this.consultantAmount = consultantAmount;
            this.purposeID = purposeID;
            this.updateDate = updateDate;
            this.paymentType = paymentType;
            this.discountBy = discountBy;
            this.isDueAllowed = isDueAllowed;
         
            txtVATAmount.Text = Math.Round((Utility.val(txtPayableAmount.Text) * Utility.val(txtVATPercentage.Text) / 100)).ToString();
            UpdateTotal(txtAmount.Text, txtAdvancePaid.Text, txtDiscountAmount.Text, txtVATAmount.Text);

        }

        private double GetTotal(string amount, string discount)
        {
            return (Utility.val(amount) - Utility.val(discount));
        }

        private double GetTotal(string amount, string discount, string vat)
        {
            return this.GetTotal(amount, discount) + Utility.val(vat);
        }

        private double GetTotal(string amount, string discount, string vat, string advance)
        {
            return this.GetTotal(amount, discount, vat) - Utility.val(advance);
        }

        private void txtDiscountPercentage_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountPercentage.Text != "")
            {
                txtDiscountAmount.Text = (Math.Round(Utility.val(txtAmount.Text) * Utility.val(txtDiscountPercentage.Text) / 100)).ToString();
            }
        }

        private void txtDiscountPercentage_Leave(object sender, EventArgs e)
        {
            if (txtDiscountPercentage.Text == "")
                txtDiscountPercentage.Text = "0";
        }

        private void txtNetPayableAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscountPercentage_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDiscountPercentage.Text != "" && Utility.val(txtDiscountPercentage.Text) > 100)
                txtDiscountPercentage.Text = "0";
        }

        private void txtVATPercentage_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtVATPercentage.Text != "" && Utility.val(txtVATPercentage.Text) > 100)
                txtVATPercentage.Text = "0";
        }



        private void UpdateTotal(string amount, string previousAdvance, string discount, string vat)
        {
            if (amount == "" || amount == ".") amount = "0";
            if (previousAdvance == "" || previousAdvance == ".") previousAdvance = "0";
            if (discount == "" || discount == ".") discount = "0";
            if (vat == "" || vat == ".") vat = "0";
            txtPayableAmount.Text = GetTotal(amount, discount).ToString("0.00");
            txtTotalPayableAmount.Text = GetTotal(amount, discount, vat).ToString("0.00");
            txtNetPayableAmount.Text = GetTotal(amount, discount, vat, previousAdvance).ToString("0.00");
            txtCashAmount.Text = Math.Round(decimal.Parse(txtNetPayableAmount.Text)).ToString();
            txtCashAmount.Text = txtCashAmount.Text;
            txtCash.Text = txtCashAmount.Text;
            txtCash_KeyUp(null,null);
            //txtChequeAmount.Text = txtNetPayableAmount.Text;
            //txtCreditAmount.Text = txtNetPayableAmount.Text;
            //txtDebitAmount.Text = txtNetPayableAmount.Text;

        }

        private void txtVATAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal(txtAmount.Text, txtAdvancePaid.Text, txtDiscountAmount.Text, txtVATAmount.Text);
        }

        private void txtDiscountAmount_TextChanged(object sender, EventArgs e)
        {
           
            if (Utility.val(txtDiscountAmount.Text) > Utility.val(txtAmount.Text))
            {
                txtDiscountAmount.Text = "0";
                return;
            }
            else
            {
               

                UpdateTotal(txtAmount.Text, txtAdvancePaid.Text, txtDiscountAmount.Text, txtVATAmount.Text);
            }
        }

        private void txtDiscountAmount_KeyUp(object sender, KeyEventArgs e)
        {
            // UpdateTotal(txtAmount.Text, txtAdvancePaid.Text, txtDiscountAmount.Text, txtVATAmount.Text);
        }

        private void txtVATAmount_KeyUp(object sender, KeyEventArgs e)
        {
            //UpdateTotal(txtAmount.Text, txtAdvancePaid.Text, txtDiscountAmount.Text, txtVATAmount.Text);
        }

        private void txtVATAmount_Leave(object sender, EventArgs e)
        {
            if (txtVATAmount.Text == "" || txtVATAmount.Text == ".")
                txtVATAmount.Text = "0";
        }

        private void txtDiscountAmount_Leave(object sender, EventArgs e)
        {
            //if (txtDiscountPercentage.Text != "" && txtDiscountPercentage.Text != "0")
            //txtDiscountPercentage.Text = Math.Ceiling(((Utility.val(txtDiscountAmount.Text)* 100) /Utility.val(txtAmount.Text))).ToString();
           
            if (txtDiscountAmount.Text == "" || txtDiscountAmount.Text == "." || (Utility.val(txtDiscountAmount.Text)>Utility.val(txtAmount.Text)))
                txtDiscountAmount.Text = "0";
        }

        private void txtVATPercentage_TextChanged(object sender, EventArgs e)
        {
            if (txtVATPercentage.Text != "")
            {
                txtVATAmount.Text = Math.Ceiling(Utility.val(txtPayableAmount.Text) * Utility.val(txtVATPercentage.Text) / 100).ToString();
                 

            }
        }


        // public event EventHandler OnSaveButtonClick;







        //public delegate void PassControl(object sender);

        //// Create instance (null)
        //public PassControl passControl;
        //public AGH.MODEL.Payment.Payment btnSave_Click(object sender, EventArgs e)
        //{

        //    //if (OnSaveButtonClick != null)
        //    //    OnSaveButtonClick(this, EventArgs.Empty);

        //     //AGH.MODEL.Payment.Payment payObj = this.PopulatePayment();
        //     //return payObj;
        //}

        private OPDPayment PopulatePayment()
        {
            OPDPayment payObj = new OPDPayment();

            payObj.HCN = txtPateintNo.Text;
            payObj.PurposeID = this.purposeID;
            payObj.Advance = decimal.Parse(txtAdvancePaid.Text);
            payObj.Amount = decimal.Parse(txtAmount.Text);
            payObj.VAT = decimal.Parse(txtVATAmount.Text);
            payObj.PreviousDue = decimal.Parse(txtPreviousDue.Text);
            payObj.Discount = decimal.Parse(txtDiscountAmount.Text);
            payObj.NetAmount = decimal.Parse(txtNetPayableAmount.Text);
            payObj.AmountGiven = Decimal.Parse(Convert.ToString(Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtChequeAmount.Text) + Utility.val(txtOthersAmount.Text)));

            //payObj.PaymentDate = DateTime.ParseExact(DateTime.Today, "dd/MM/yyyy", new System.Globalization.CultureInfo("en-GB"));

            payObj.Department = this.department;
            payObj.ReffDept = this.reffDepartment;
            payObj.DeptAmount = this.departmentAmount;
            payObj.ReffDeptAmount = this.reffDepartmentAmount;
            payObj.DepartmentUnit = this.departmentUnit;
            payObj.ReffDeptUnit = this.reffDepartmentUnit;
            payObj.PaymentType = this.paymentType;
            payObj.EntryDate = this.updateDate;
            payObj.ConsultantFee = this.consultantAmount;

            payObj.discountNote = txtDiscNote.Text;
            payObj.PaymentString = (txtCash.Text == "" ? "0" : txtCash.Text) + "~" +
                (txtCreditAmount.Text==""?"0":txtCreditAmount.Text) + "~" +
                       cboBNKNameCreditCard.SelectedValue+"~"+
                       cboCardTypeCredit.SelectedValue+"~"+
                       (txtLastDigitCreditCard.Text == "" ? "0" : txtLastDigitCreditCard.Text) + "~" +
                       (txtDebitAmount.Text==""?"0":txtDebitAmount.Text) + "~" +
                       cboBNKDebitCard.SelectedValue + "~" +
                       cboCardTypeDebit.SelectedValue + "~" +
                       (txtLastDigitDebitCard.Text == "" ? "0" : txtLastDigitDebitCard.Text) + "~" +
                       (txtChequeAmount.Text == "" ? "0" : txtChequeAmount.Text) + "~" + cboBankName.SelectedValue + "~" + (txtChequeNo.Text == "" ? "0" : txtChequeNo.Text) + "~" +
                       (txtOthersAmount.Text == "" ? "0" : txtOthersAmount.Text) + "~" +
                       (txtOthersRemarks.Text == "" ? " " : txtOthersRemarks.Text) + "~" +
                       (Utility.val(txtChange.Text) > 0 ? txtChange.Text.ToString() : "0" )+ "~" + // Added by Mayhedi for due check on 16_01_17
                       ";";


                  

            //this.updateDate.ToString("dd/MM/yyyy");
            //patObj.DOB = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", new System.Globalization.CultureInfo("en-GB"));
            //patObj.StaffID = (cboStaffID.Items.Count == 0) ? null : cboStaffID.SelectedValue.ToString();
            //patObj.CorporateID = (cboCorporateID.Items.Count == 0) ? null : cboCorporateID.SelectedValue.ToString();


            //patObj.EmergencyPersonRelation = cboEmergenPersonRelationship.SelectedValue.ToString();
            payObj.EntryBy = Utility.UserId;
            payObj.LocationID = Utility.LocationID;
            payObj.CompanyID = Utility.CompanyID;
            payObj.MachineID = Utility.MachineID;
            return payObj;


        }
        void btnSave_gotFocus(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.Crimson;
        }
        void btnSave_lostFocus(object sender, EventArgs e)
        { 
           btnSave.BackColor=System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(176)))), ((int)(((byte)(67)))));
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnSave.Enabled = false;
            if (txtCash.Text.Length == 0)
            {
                txtCash.Text = "0";
            }
            if (lblChange.Text == "Due")
            {
                if (txtOthersRemarks.Text == "")
                {
                    MessageBox.Show("Remarks/Due Reason Cannot be Empty");
                    this.Cursor = Cursors.Default;
                    btnSave.Enabled = true;
                    txtOthersRemarks.Enabled = true;
                    txtOthersRemarks.Focus();
                    return;
                }
            }

            if (this.isDueAllowed == false && ((Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtChequeAmount.Text) + Utility.val(txtOthersAmount.Text)) < Utility.val((txtCashAmount.Text))))
            {
                MessageBox.Show("Due is not Allowed here" + Utility.CrLf + "pls verify payment", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Cursor = Cursors.Default;
                btnSave.Enabled = true;
                return;
            }

            if (purposeID != "0006")
            {
                if (purposeID == "0002")//added 20_12_2016 for diagnostic 100% due
                {
                    if (this.isDueAllowed == true && ((Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtChequeAmount.Text) + Utility.val(txtOthersAmount.Text)) < (Utility.val(txtCashAmount.Text) * 0.50)))
                    {
                        MessageBox.Show("You Have to Pay Minimum 50 % of Total Amount", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Cursor = Cursors.Default;
                        btnSave.Enabled = true;
                        return;
                    }
                }
                if (purposeID == "0008")//added 20_12_2016 for diagnostic 100% due
                {
                    if (this.isDueAllowed == true && ((Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtChequeAmount.Text) + Utility.val(txtOthersAmount.Text)) < (Utility.val(txtCashAmount.Text) * 0.50)))
                    {
                        MessageBox.Show("You Have to Pay Minimum 50 % of Total Amount", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Cursor = Cursors.Default;
                        btnSave.Enabled = true;
                        return;
                    }
                }
                if (purposeID == "0011")//added 20_12_2016 for diagnostic 100% due
                {
                    if (this.isDueAllowed == true && ((Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtChequeAmount.Text) + Utility.val(txtOthersAmount.Text)) < (Utility.val(txtCashAmount.Text) * 0.50)))
                    {
                        MessageBox.Show("You Have to Pay Minimum 50 % of Total Amount", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Cursor = Cursors.Default;
                        btnSave.Enabled = true;
                        return;
                    }
                }
              

            }
            //////******Added Md. Mayhedi Hasan on 20_12_16
            //if (purposeID.Length >= 5)
            //{
            //    if (this.isDueAllowed == true)
            //    {
            //        //MessageBox.Show("You Have to Pay Minimum 100 % of Total Amount", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        //this.Cursor = Cursors.Default;
            //        btnSave.Enabled = true;
            //        return;

            //    }
            //}

            ////}
            //////******************************************




            if (txtDebitAmount.Text.Length > 0 || txtCreditAmount.Text.Length > 0 || txtChequeAmount.Text.Length>0)
                if (Utility.val(txtCash.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtChequeAmount.Text) + Utility.val(txtOthersAmount.Text) > Utility.val(txtCashAmount.Text))
                {
                    MessageBox.Show("Payment should not exceed the Payable Amount..pls check again", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cursor = Cursors.Default;
                    btnSave.Enabled = true;
                    return;
                }

            if (Utility.val(txtDebitAmount.Text) > 0) {
                if (cboBNKDebitCard.SelectedValue == "")
                {
                    MessageBox.Show("Please select a Bank name", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBNKDebitCard.Select();
                    this.Cursor = Cursors.Default;
                    btnSave.Enabled = true;
                    return;
                }

                if (cboCardTypeDebit.SelectedValue == "")
                {
                    MessageBox.Show("Please select a Card Type", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCardTypeDebit.Select();
                    this.Cursor = Cursors.Default;
                    btnSave.Enabled = true;
                    return;
                }

                if (txtLastDigitDebitCard.TextLength<3)
                {
                    MessageBox.Show("Please put last four digit of the Card", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLastDigitDebitCard.Select();
                    this.Cursor = Cursors.Default;
                    btnSave.Enabled = true;
                    return;
                }
            }






            if (Utility.val(txtCreditAmount.Text) > 0)
            {
                if (cboBNKNameCreditCard.SelectedValue == "")
                {
                    MessageBox.Show("Please select a Bank name", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBNKNameCreditCard.Select();
                    this.Cursor = Cursors.Default;
                    btnSave.Enabled = true;
                    return;
                }

                if (cboCardTypeCredit.SelectedValue == "")
                {
                    MessageBox.Show("Please select a Card Type", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCardTypeCredit.Select();
                    this.Cursor = Cursors.Default;
                    btnSave.Enabled = true;
                    return;
                }

                if (txtLastDigitCreditCard.TextLength < 3)
                {
                    MessageBox.Show("Please put last four digit of the Card", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLastDigitCreditCard.Select();
                    this.Cursor = Cursors.Default;
                    btnSave.Enabled = true;
                    return;
                }
            }
            if (Utility.val(txtChequeAmount.Text) > 0)
            {
                if (cboBankName.SelectedValue == "")
                {
                    MessageBox.Show("Please select a Bank name", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboBankName.Select();
                    this.Cursor = Cursors.Default;
                    btnSave.Enabled = true;
                    return;
                }

                if (txtChequeNo.Text == "")
                {
                    MessageBox.Show("Please Insert Cheque No", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChequeNo.Select();
                    this.Cursor = Cursors.Default;
                    btnSave.Enabled = true;
                    return;
                }
            }
            if (txtDiscountAmount.Text != "0" && txtDiscountAmount.Text != "")
            {
                if (txtDiscNote.Text == "")
                {
                    MessageBox.Show("Discount Note Required", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    btnSave.Enabled = true;
                    txtDiscNote.Select();
                    this.Cursor = Cursors.Default;
                    btnSave.Enabled = true;
                    return;
                }
              
            }
            if (Utility.val(txtOthersAmount.Text) > 0)
            {
                if (txtOthersRemarks.Text =="")
                {
                    MessageBox.Show("Remarks Required", Utility.MessageCaptionMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOthersRemarks.Select();
                    this.Cursor = Cursors.Default;
                    btnSave.Enabled = true;
                    return;
                }
            }


            Recalculate();
            if (onSaveButtonClicked != null)
                onSaveButtonClicked(this.PopulatePayment());
            this.Cursor = Cursors.Default;
            this.Dispose();
        }

        private void tbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbPayment.SelectedTab == tbPayment.TabPages[0])
            {
                this.paymentType = "0"; // cash
            }
            if (tbPayment.SelectedTab == tbPayment.TabPages[1])
            {
                this.paymentType = "1"; // cheque
            }
            if (tbPayment.SelectedTab == tbPayment.TabPages[2])
            {
                this.paymentType = "2"; // credit 
            }
            if (tbPayment.SelectedTab == tbPayment.TabPages[3])
            {
                this.paymentType = "3"; //debit 
            }
            if (tbPayment.SelectedTab == tbPayment.TabPages[4])
            {
                this.paymentType = "4";  //corporate
            }
        }

        private void btnN1_Click(object sender, EventArgs e)
        {
            AddToCash(sender);
        }

        private void AddToCash(object sender)
        {
            if (((Button)sender).Text == "." && ((Button)sender).Text.Length == 0)
                txtCash.Text = "0.00";
            else
            {
                txtCash.Text = txtCash.Text + ((Button)sender).Text;
            }
            txtCash_KeyUp(null, null);
            txtCash.Select();
        }

        private void AddToCash(object sender, string Type)
        {
            txtCash.Text = ((Button)sender).Text;
            txtCash_KeyUp(null, null);
            txtCash.Select();
        }

        private void btnN2_Click(object sender, EventArgs e)
        {
            AddToCash(sender);
        }

        private void btnN3_Click(object sender, EventArgs e)
        {
            AddToCash(sender);
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            AddToCash(sender);
        }

        private void btnN5_Click(object sender, EventArgs e)
        {
            AddToCash(sender);
        }

        private void btnN6_Click(object sender, EventArgs e)
        {
            AddToCash(sender);
        }

        private void btnN7_Click(object sender, EventArgs e)
        {
            AddToCash(sender);
        }

        private void btnN8_Click(object sender, EventArgs e)
        {
            AddToCash(sender);
        }

        private void btnN9_Click(object sender, EventArgs e)
        {
            AddToCash(sender);
        }

        private void btnN0_Click(object sender, EventArgs e)
        {
            AddToCash(sender);
        }

        private void btnNpoint_Click(object sender, EventArgs e)
        {
            AddToCash(sender);
        }

        private void btnN00_Click(object sender, EventArgs e)
        {
            AddToCash(sender);
        }

        private void btnN100_Click(object sender, EventArgs e)
        {
            AddToCash(sender, "D");
        }

        private void btn500_Click(object sender, EventArgs e)
        {
            AddToCash(sender, "D");
        }

        private void btn1000_Click(object sender, EventArgs e)
        {
            AddToCash(sender, "D");
        }

        private void btnN5000_Click(object sender, EventArgs e)
        {
            AddToCash(sender, "D");
        }

        private void btnN10000_Click(object sender, EventArgs e)
        {
            AddToCash(sender, "D");
        }

        private void btnN15000_Click(object sender, EventArgs e)
        {
            AddToCash(sender, "D");
        }

        private void btnBSpace_Click(object sender, EventArgs e)
        {
            if (txtCash.Text.Length > 0)
            {
                txtCash.Text = txtCash.Text.Substring(0, txtCash.Text.Length - 1);
            }
            txtCash_KeyUp(null, null);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCash.Text = "";
            txtCash_KeyUp(null,null);
            txtCash.Select();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            Recalculate();

        }

        private void txtCashAmount_TextChanged(object sender, EventArgs e)
        {

        }

        //private void txtCash_KeyUp(object sender, KeyEventArgs e)
        //{
        //    Recalculate();
        //}

        private void Recalculate()
        {

            //double nPoint = 0;

            //if (txtCash.Text == "." && txtCash.Text.Length <= 1)
            //{
            //    txtCash.Text = nPoint.ToString() + ".";
            //    txtCash.Select(txtCash.Text.Length, 0);
            //}
            //else
            //{
               // double nCash = txtCash.Text == "" ? 0 : double.Parse(txtCash.Text);
            double nChange = Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtChequeAmount.Text) + Utility.val(txtOthersAmount.Text));
                lblChange.Text = nChange > 0 ? "Due" : "Change";
                txtChange.Text = nChange.ToString("0.00");
            //}

        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && this.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            txtCash.Select();
            //txtCashAmount.Text = "34867";
            //purposeID = "0002";
            ///txtAmount.Text = "1200";
           //////txtVATAmount.Text = "10.1";
           //////txtVATPercentage.Text = "15";
            //txtPayableAmount.Text = "70";
            txtOthersRemarks.Enabled = true;
            if (purposeID == "0006" || purposeID == "0004" || purposeID == "0002" || purposeID == "0008" || purposeID == "0011" || purposeID == "0009" )
            {
                txtOthersAmount.Enabled = true;
                //txtOthersRemarks.Enabled = true;
            }
            else
            {
                txtOthersAmount.Enabled = false;
                //txtOthersRemarks.Enabled = false;
            }

            cboCardTypeCredit.DisplayMember = "Value";
            cboCardTypeCredit.ValueMember = "Key";
            cboCardTypeCredit.DataSource = new BindingSource(Utility.GetCardTypes(), null);

            cboCardTypeDebit.DisplayMember = "Value";
            cboCardTypeDebit.ValueMember = "Key";
            cboCardTypeDebit.DataSource = new BindingSource(Utility.GetCardTypes(), null);


            cboBNKDebitCard.DisplayMember="Value";
            cboBNKDebitCard.ValueMember="Key";
            cboBNKDebitCard.DataSource=new BindingSource(GetBankNames(),null);

            cboBNKNameCreditCard.DisplayMember = "Value";
            cboBNKNameCreditCard.ValueMember = "Key";
            cboBNKNameCreditCard.DataSource = new BindingSource(GetBankNames(), null);

            cboBankName.DisplayMember = "Value";
            cboBankName.ValueMember = "Key";
            cboBankName.DataSource = new BindingSource(GetBankNames(), null);

           btnSave.GotFocus += new EventHandler(btnSave_gotFocus);
           btnSave.LostFocus += new EventHandler(btnSave_lostFocus);
            
        }

        private Dictionary<string, string> GetBankNames()
        {
            Dictionary<string, string> bnk = new Dictionary<string, string>();
            bnk.Add("0001", "Brac Bank Ltd.");
            bnk.Add("0002", "Dutch-Bangla Bank Ltd.");
            bnk.Add("0003", "Standard Chartered Bank Ltd.");
            bnk.Add("0004", "Eastern Bank Ltd.");
            bnk.Add("0005", "AB Bank Limited.");
            bnk.Add("0006","Bank Asia Limited.");
            bnk.Add("0007","Bangladesh Commerce Bank Limited.");
            bnk.Add("0008","Dhaka Bank Limited.");
            bnk.Add("0009","Jamuna Bank Limited.");
            bnk.Add("0010","IFIC Bank Limited.");
            bnk.Add("0011","Mercantile Bank Limited.");
            bnk.Add("0012","Mutual Trust Bank Limited.");
            bnk.Add("0013","National Bank Limited.");
            bnk.Add("0014","Modhumoti Bank Limited.");  
            bnk.Add("0015","NCC Bank Limited."); 
            bnk.Add("0016","Prime Bank Limited."); 
            bnk.Add("0017","Trust Bank Bangladesh Limited."); 
            bnk.Add("0018","Islami Bank Bangladesh Limited."); 
            bnk.Add("0019","Al-Arafah Islami Bank Limited."); 
            bnk.Add("0020","Export Import Bank of Bangladesh Limited."); 
            bnk.Add("0021","Shahjalal islami Bank Limited."); 
            bnk.Add("0022","Social Islami Bank Limited.");
            bnk.Add("0023", "First Security Islami Bank Limited.");
            bnk.Add("0024", "The City Bank Limited.");
            bnk.Add("0025", "NRB Bank Limited.");
            bnk.Add("0026", "Pubali Bank Limited.");
            bnk.Add("0027", "One Bank Limited.");
            bnk.Add("0028", "The Premier Bank Limited.");
            bnk.Add("0029", "Uttara Bank Limited.");
            bnk.Add("0030", "Southeast Bank Limited.");
            bnk.Add("0031", "Standard Bank Limited.");
            bnk.Add("0032", "ICB Islamic Bank Limited.");
            bnk.Add("0033", "The Farmers Bank Limited.");
            bnk.Add("0034", "Premier Bank Ltd.");
            bnk.Add("0035", "United Commercial Bank Ltd.");
            bnk.Add("0036", "Lanka Bangla Finance Ltd.");
            

                //Midland Bank Limited




                //
                //NRB Commercial Bank Limited
                //NRB Global Bank Limited
                //One Bank Limited

                //
                //South Bangla Agriculture and Commerce Bank Limited (www.sbacbank.com)
                //Southeast Bank Limited
                //Standard Bank Limited
                //The City Bank Limited
                //The Farmers Bank Limited
                //The Premier Bank Limited

                //United Commercial Bank Limited
                //Uttara bangladesh Bank Limited
                //There are eight private Islamic Commercial Banks in Bangladesh:


                //Union Bank Limited
                //ICB Islamic Bank Limited


            return bnk;
        }

        private void txtDebitAmount_KeyUp(object sender, KeyEventArgs e)
        {
            txtChequeAmount.Text = "";
            txtOthersAmount.Text = "";
            Recalculate();
            if (txtDebitAmount.Text.Length > 0)
            {
                //EnableDisableCardPart('C', false, true);
                EnableDisableCardPart('D', true, true);
                //EnableDisableCardPart('K', false, true);
            }
            else
            {
                EnableDisableCardPart('C', true, true);
                EnableDisableCardPart('D', true, true);
                EnableDisableCardPart('K', true, true);

            }


            //if (txtDebitAmount.Text.Length > 0)
            //{
            //    EnableDisableCardPart('D', true,false);
            //}
            //else
            //{
            //    EnableDisableCardPart('D', false,false);

            //}
        }

        private void txtCreditAmount_KeyUp(object sender, KeyEventArgs e)
        {
            Recalculate();
            //if (txtCreditAmount.Text.Length > 0)
            //{
            //    EnableDisableCardPart('C', true,false);
            //}
            //else
            //{
            //    EnableDisableCardPart('C', false,false);

            //}
        }

        private void EnableDisableCardPart(Char mode, Boolean action,Boolean isStrict)
        {

            switch (mode)
            {
                case 'C':
                    if (action == false)
                    {
                        if (cboBNKNameCreditCard.Items.Count > 0)
                        {
                            cboBNKNameCreditCard.SelectedIndex = 0;
                        }
                        cboBNKNameCreditCard.Enabled = false;
                        txtLastDigitCreditCard.Enabled = false;
                        txtLastDigitCreditCard.Text = "";
                        txtCreditAmount.Text = "";
                        if (cboCardTypeCredit.Items.Count>0){
                            cboCardTypeCredit.SelectedIndex = 0;
                        }
                        cboCardTypeCredit.Enabled = false;
                        
                        if (isStrict)
                        {
                            txtCreditAmount.Enabled = false;
                           
                        }
                    }
                    else if (action == true)
                    {
                        cboBNKNameCreditCard.Enabled = true;
                        txtLastDigitCreditCard.Enabled = true;
                        txtCreditAmount.Enabled = true;
                        cboCardTypeCredit.Enabled = true;
                    }
                    break;
                case 'D':
                    if (action == false)
                    {
                        if (cboBNKDebitCard.Items.Count > 0) {
                            cboBNKDebitCard.SelectedIndex = 0;
                        }
                        
                        cboBNKDebitCard.Enabled = false;
                        txtLastDigitDebitCard.Enabled = false;
                        txtLastDigitDebitCard.Text = "";
                        txtDebitAmount.Text = "";
                        if (isStrict)
                        {
                            txtDebitAmount.Enabled = false;
                        }
                        if (cboCardTypeDebit.Items.Count > 0)
                        {
                            cboCardTypeDebit.SelectedIndex = 0;
                        }
                        cboCardTypeDebit.Enabled = false;
                    }
                    else if (action == true)
                    {
                        cboBNKDebitCard.Enabled = true;
                        txtLastDigitDebitCard.Enabled = true;
                        txtDebitAmount.Enabled = true;
                        cboCardTypeDebit.Enabled = true;
                    }
                    break;

                case 'K'://k for Checque
                    if (action == false)
                    {
                        if (cboBankName.Items.Count > 0)
                        {
                            cboBankName.SelectedIndex = 0;
                        }

                        cboBankName.Enabled = false;
                        txtChequeNo.Enabled = false;
                        txtChequeNo.Text = "";
                        txtChequeAmount.Text = "";
                        if (isStrict)
                        {
                            txtChequeAmount.Enabled = false;
                        }
                        if (cboBankName.Items.Count > 0)
                        {
                            cboBankName.SelectedIndex = 0;
                        }
                        cboBankName.Enabled = false;
                    }
                    else if (action == true)
                    {
                        //cboBankName.Enabled = true;
                        txtChequeAmount.Enabled = true;
                        txtChequeNo.Enabled = true;
                        cboBankName.Enabled = true;
                        cboBankName.Enabled = true;
                    }
                    break;

                case 'O':// for Others
                    if (action == false)
                    {
                        if (cboBankName.Items.Count > 0)
                        {
                            cboBankName.SelectedIndex = 0;
                        }

                        cboBankName.Enabled = false;
                        txtChequeNo.Enabled = false;
                        //txtChequeNo.Text = "";
                        //txtChequeAmount.Text = "";
                        txtOthersAmount.Text = "";
                        txtOthersRemarks.Enabled = false;

                        if (isStrict)
                        {
                            txtChequeAmount.Enabled = false;
                        }
                        if (cboBankName.Items.Count > 0)
                        {
                            cboBankName.SelectedIndex = 0;
                        }
                        cboBankName.Enabled = false;
                    }
                    else if (action == true)
                    {
                        //cboBankName.Enabled = true;
                        txtChequeAmount.Enabled = true;
                        txtChequeNo.Enabled = true;
                        cboBankName.Enabled = true;
                        cboBankName.Enabled = true;
                    }
                    break;

            }
        }

        private void txtDebitAmount_TextChanged(object sender, EventArgs e)
        {
            EnableDisableCardPart('D', true, false);
          
        }

        private void txtDebitAmount_Enter(object sender, EventArgs e)
        {
            this.isEnterTabAllow = true;
            txtDebitAmount.Text = (Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtChequeAmount.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtOthersAmount.Text))).ToString("0.00");
            Recalculate();
        }

        private void txtCreditAmount_Enter(object sender, EventArgs e)
        {

            txtCreditAmount.Text = (Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtDebitAmount.Text))).ToString("0.00");
            Recalculate();
        }

        private void txtDebitAmount_Leave(object sender, EventArgs e)
        {
            if (Utility.val(txtCashAmount.Text) < (Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtOthersAmount.Text)))
                txtDebitAmount.Text = (Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtOthersAmount.Text))).ToString("0.00");
            //txtDebitAmount.Text = (Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text))).ToString();
            Recalculate();
            //if (Utility.val(txtDebitAmount.Text) == 0)
            //{
            //    EnableDisableCardPart('D', false, true);
            //}

        }

        private void txtCreditAmount_Leave(object sender, EventArgs e)
        {
            if (Utility.val(txtCashAmount.Text) < (Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtDebitAmount.Text)))
            {
                txtCreditAmount.Text = (Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtDebitAmount.Text))).ToString("0.00");
               
            }
            Recalculate();
            //if (Utility.val(txtCreditAmount.Text) == 0)
            //{
            //    EnableDisableCardPart('C', false, true);
            //}
        }

        private void txtCash_KeyUp(object sender, KeyEventArgs e)
        {
            txtCreditAmount.Text = "";
            txtDebitAmount.Text = "";
            txtChequeAmount.Text = "";
            txtOthersAmount.Text = "";
            txtOthersRemarks.Text = "";
            if (Utility.val(txtCash.Text) >= Utility.val(txtCashAmount.Text))
            {
                EnableDisableCardPart('C', false, true);
                EnableDisableCardPart('D', false, true);
                EnableDisableCardPart('K', false, true);
            }
            else
            {
                EnableDisableCardPart('C', true, true);
                EnableDisableCardPart('D', true, true);
                EnableDisableCardPart('K', true, true);

            }
        }

        private void txtCreditAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCash_Leave(object sender, EventArgs e)
        {
            Recalculate();
            
            if (Utility.val(txtCash.Text) >= Utility.val(txtCashAmount.Text))
            {
                btnSave.Select();
            }
        }

        private void txtLastDigitCreditCard_Leave(object sender, EventArgs e)
        {
            btnSave.Select();
        }

        private void txtLastDigitDebitCard_Leave(object sender, EventArgs e)
        {

            if (Utility.val(txtCashAmount.Text)==Utility.val(txtCash.Text) + Utility.val(txtDebitAmount.Text))
            {
                btnSave.Select();
            }
        }

        private void btnExact_Click(object sender, EventArgs e)
        {
            txtCash.Text = txtCashAmount.Text;
            txtCash_KeyUp(null, null);
            txtCash.Select();
        }

        private void txtLastDigitDebitCard_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtLastDigitDebitCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void txtLastDigitCreditCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void cboBNKDebitCard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChequeAmount_TextChanged(object sender, EventArgs e)
        {
            //EnableDisableCardPart('K', true, false);
            
           
        }

        private void txtChequeAmount_Enter(object sender, EventArgs e)
        {
            this.isEnterTabAllow = true;
            txtChequeAmount.Text = (Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtOthersAmount.Text))).ToString("0.00");
            Recalculate();
        }

        private void txtChequeAmount_Leave(object sender, EventArgs e)
        {
            if (Utility.val(txtCashAmount.Text) < (Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtChequeAmount.Text) + Utility.val(txtOthersAmount.Text)))
                txtChequeAmount.Text = (Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtOthersAmount.Text))).ToString("0.00");
            //txtDebitAmount.Text = (Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text))).ToString();
            Recalculate();
            //if (Utility.val(txtDebitAmount.Text) == 0)
            //{
            //    EnableDisableCardPart('K', false, true);
            //}
        }

        private void txtChequeAmount_KeyUp(object sender, KeyEventArgs e)
        {
            //txtChequeAmount.Text = (Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtDebitAmount.Text))).ToString("0.00");
            txtOthersAmount.Text = "";

            Recalculate();
            if (txtChequeAmount.Text.Length > 0)
            {
                //EnableDisableCardPart('C', false, true);
                EnableDisableCardPart('K', true, true);
                //EnableDisableCardPart('K', false, true);
            }
            else
            {
                //cboBankName.Enabled = false;
                //txtChequeAmount.Enabled=false;
                EnableDisableCardPart('C', true, true);
                EnableDisableCardPart('D', true, true);
                EnableDisableCardPart('K', true, true);

            }

            //if (txtChequeAmount.Text.Length > 0)
            //{
            //    EnableDisableCardPart('K', true, false);
            //}
            //else
            //{
            //    EnableDisableCardPart('K', false, false);

            //}
        }

        private void txtOthersAmount_Enter(object sender, EventArgs e)
        {
           
            txtOthersAmount.Text = (Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtChequeAmount.Text))).ToString("0.00");
            Recalculate();
            this.isEnterTabAllow = true;
        }

        private void txtOthersAmount_KeyUp(object sender, KeyEventArgs e)
        {
            Recalculate();
            if (txtOthersAmount.Text.Length > 0)
            {
                //EnableDisableCardPart('C', false, true);
                EnableDisableCardPart('O', true, true);
                //EnableDisableCardPart('K', false, true);
            }
            else
            {
                EnableDisableCardPart('C', true, true);
                EnableDisableCardPart('D', true, true);
                EnableDisableCardPart('K', true, true);

            }
        }

        private void txtOthersAmount_Leave(object sender, EventArgs e)
        {
            if (Utility.val(txtCashAmount.Text) < (Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtOthersAmount.Text)))
                txtOthersAmount.Text = (Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtDebitAmount.Text) + Utility.val(txtCreditAmount.Text))).ToString("0.00");
            //txtDebitAmount.Text = (Utility.val(txtCashAmount.Text) - (Utility.val(txtCash.Text) + Utility.val(txtCreditAmount.Text))).ToString();
            Recalculate();
        }

        private void txtDiscNote_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        //static void AllToNextTab(this Control crl1, Control crl2)
        //{
        //    crl1.KeyDown += (sender, e) => ContrKeyDown(e, crl2);
        //}
        //static void ContrKeyDown(KeyEventArgs e, Control crl2)
        //{
        //    if (e.KeyCode != Keys.Enter) return;
        //    crl2.Focus();
        //}
        private void txtDiscNote_Enter(object sender, EventArgs e)
        {
            this.isEnterTabAllow = true;
            //SendKeys.Send("Tab");
        }

        private void txtCash_Enter(object sender, EventArgs e)
        {
            this.isEnterTabAllow = true;
        }

      

        private void cboBankName_Enter(object sender, EventArgs e)
        {
            this.isEnterTabAllow = true;
        }

        private void txtChequeNo_Enter(object sender, EventArgs e)
        {
            this.isEnterTabAllow = true;
        }

        private void cboBNKDebitCard_Enter(object sender, EventArgs e)
        {
            this.isEnterTabAllow = true;
        }

        private void cboCardTypeDebit_Enter(object sender, EventArgs e)
        {
            this.isEnterTabAllow = true;
        }

        private void txtLastDigitDebitCard_Enter(object sender, EventArgs e)
        {
            this.isEnterTabAllow = true;
        }

        private void txtOthersRemarks_Enter(object sender, EventArgs e)
        {
           
            this.isEnterTabAllow = true;
        }

        private void frmPayment_LocationChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscNote_Leave(object sender, EventArgs e)
        {
            
            btnSave.Select();
        }

        private void txtOthersAmount_TextChanged(object sender, EventArgs e)
        {

        }


     
    }
}
