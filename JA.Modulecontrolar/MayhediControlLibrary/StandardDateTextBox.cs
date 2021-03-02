using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MayhediControlLibrary
{
    public class StandardDateTextBox : MaskedTextBox
    {
        string input1;     
        protected override void OnCreateControl()
        {
            int fontSize;
            fontSize = 11;
            base.OnCreateControl();
            this.Mask = "00/00/0000";
            this.PromptChar = '_';
            this.Culture = new System.Globalization.CultureInfo("en-GB");
            this.ValidatingType = typeof(System.DateTime);

            this.Font = new Font(this.Font.Name, fontSize);
           // Regex rgx = new Regex(@"(\\|-|\.)");
           // this.Text = rgx.Replace(this.Text, @"/");
            //this.Text = this.Text.Replace("-", @"/");
        }
        public string ReplaceAt(string str, int index, int length, string replace)
        {
            return str.Remove(index, Math.Min(length, str.Length - index))
                    .Insert(index, replace);
        }

        protected override void OnEnter(EventArgs e)
        {
            
            base.OnEnter(e);
            this.BackColor = Color.LightYellow;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.BeginInvoke(new MethodInvoker(SelectText));
        }
        protected override void OnLeave(EventArgs e)
        {
           // this.CorrectDateText(this);
            base.OnLeave(e);

            this.Font = new Font(this.Font, FontStyle.Regular);
            this.BackColor = Color.White;
            if (ValidateDate(this.Text) == false)
            {
                this.Text = "  /  /";
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Back) { }
            //else if (e.KeyCode == Keys.NumPad0) { }
            //else if (e.KeyCode == Keys.D0) { }
            //else if (e.KeyCode == Keys.Left) { }
            //else if (e.KeyCode == Keys.Right) { }
            //else
            //{
            //    Regex rgx = new Regex(@"(\\|-|\.)");
            //    string FormattedDate = rgx.Replace(this.Text, @"/");
            //    if (this.Text.Substring(0, 1).Length > 0)
            //        if (this.Text != "  /  /")
            //        {
            //            int input = int.Parse(this.Text.Substring(0, 1));
            //            // MessageBox.Show(input.ToString());
            //            if (input > 3 && input < 10)
            //            {
            //                this.Text = "0" + this.Text;
            //                this.SelectionStart = 3;
            //            }

            //            if (this.Text.Substring(1, 1).Trim().Length > 0 && this.SelectionStart == 2)
            //            {
            //                this.SelectionStart = 3;
            //            }

            //            // if (input > 0 && input < 10)
            //            input1 = this.Text.Substring(3, 1).Trim();
            //            // int cursorPosition = this.SelectionStart;
            //            //  MessageBox.Show(sub);

            //            if (input1 == "" && this.SelectionStart == 3)
            //            {
            //                this.SelectionStart = 3;
            //            }
            //            if (input1 != "" && this.SelectionStart == 4)
            //            {
            //                input1 = this.Text.Substring(3, 1).Trim();

            //                if (input1 != "")
            //                {

            //                    //string input3 = i(this.Text.Substring(3, 1).Trim());
            //                    int input2 = int.Parse(this.Text.Substring(3, 1).Trim());
            //                    if (input2 > 1 && input2 < 10)
            //                    {
            //                        string con = "0" + input2;
            //                        this.Text = ReplaceAt(this.Text, 3, 1, con);
            //                        this.SelectionStart = 6;
            //                        // this.Text=
            //                    }
            //                    else
            //                    {
            //                        this.Text = this.Text;
            //                    }
            //                    //this.SelectionStart = 6;
            //                }



            //            }

            //            //  input1 = ;







            //            if (this.Text.Substring(4, 1).Trim().Length > 0 && this.SelectionStart == 5)
            //            {
            //                this.SelectionStart = 6;
            //            }













            //            // int cursorPosition = this.SelectionStart;
            //            //  MessageBox.Show(sub);

            //            //if (input1 == "" && this.SelectionStart==3)
            //            //  {

            //            //if (this.Text.in)
            //            // {
            //            //this.SelectionStart == 3 &&
            //            //  this.SelectionStart = 3;
            //            //this.Text = ReplaceAt(this.Text,3,1,"0");
            //            //  MessageBox.Show(this.Text.ToString());
            //            // this.SelectionStart = 4;
            //            // }
            //        }
            //}
           base.OnKeyUp(e);
        }
        private Boolean ValidateDate(string dateString)
        {
            Boolean dateValidationResult = true;

            try
            {
                IFormatProvider culture = new System.Globalization.CultureInfo("en-GB", true);
                DateTime.ParseExact(dateString, "dd/MM/yyyy", culture);
            }
            catch (Exception)
            {
                dateValidationResult = false;

            }
            return dateValidationResult;
        }


        //bool IsValidDate(MaskedTextBox dateTextBox)
        //{
        //    // Remove delimiters from the text contained in the control. 
        //    string DateContents = dateTextBox.Text.Replace("/", "").Trim();

        //    // if no date was entered, we will be left with an empty string 
        //    // or whitespace.
        //    if (!string.IsNullOrEmpty(DateContents) && DateContents != "")
        //    {
        //        // Split the original date into components:
        //        string[] dateSoFar = dateTextBox.Text.Split('/');
        //        string month = dateSoFar[0].Trim(); ;
        //        string day = dateSoFar[1].Trim();
        //        string year = dateSoFar[2].Trim();

        //        // If the component values are of the proper length for mm/dd/yyyy formatting:
        //        if (month.Length == 2
        //            && day.Length == 2
        //            && year.Length == 4
        //            && (year.StartsWith("19") || year.StartsWith("20")))
        //        {
        //            // Check to see if the string resolves to a valid date:
        //            DateTime d;
        //            if (!DateTime.TryParse(dateTextBox.Text, out d))
        //            {
        //                // The string did NOT resolve to a valid date:
        //                return false;
        //            }
        //            else
        //                // The string resolved to a valid date:
        //                return true;
        //        }
        //        else
        //        {
        //            // The Components are not of the correct size, and automatic adjustment
        //            // is unsuccessful:
        //            return false;

        //        } // End if Components are correctly sized
        //    }
        //    else
        //        // The date string is empty or whitespace - no date is a valid return:
        //        return true;
        //} 







        private void SelectText()
        {

            if (this.Text == "  /  /")
            {
                this.SelectionStart = 0;
                this.SelectionLength = 0;
            }
            //else {
            //     this.SelectionStart = this.Text.Length;
            //    //this.SelectionLength = this.Text.Length;
            //}
            
        }

        void CorrectDateText(MaskedTextBox dateTextBox)
        {
            // Replace any odd date separators with the mm/dd/yyyy Standard:
            Regex rgx = new Regex(@"(\\|-|\.)");
            string FormattedDate = rgx.Replace(dateTextBox.Text, @"/");

            // Separate the date components as delimited by standard mm/dd/yyyy formatting:
            string[] dateComponents = FormattedDate.Split('/');
            string month = dateComponents[1].Trim(); ;
            string day = dateComponents[0].Trim();
            string year = dateComponents[2].Trim();

            // We require a two-digit month. If there is only one digit, add a leading zero:
            if (month.Length == 1)
            {
                month = "0" + month;
            }

            // We require a two-digit day. If there is only one digit, add a leading zero:

            if (day.Length == 1)
            {
                day = "0" + day;
            }

            // We require a four-digit year. If there are only two digits, add 
            // two digits denoting the current century as leading numerals:
            if (year.Length == 2)
            {
                year = "20" + year;
            }

            // Put the date back together again with proper delimiters, and 
            dateTextBox.Text = day + "/" + month + "/" + year;
        }

        //protected virtual void MaskedDateBox_PreviewKeyDown(object sender,
        //                                PreviewKeyDownEventArgs e)
        //{
        //    MaskedTextBox txt = (MaskedTextBox)sender;

        //    // Check for common date delimiting characters. When encountered, 
        //    // adjust the text entry for proper date formatting:
        //    if (e.KeyCode == Keys.Divide
        //        || e.KeyCode == Keys.Oem5
        //        || e.KeyCode == Keys.OemQuestion
        //        || e.KeyCode == Keys.OemPeriod
        //        || e.KeyValue == 190
        //        || e.KeyValue == 110)

        //        // If any of the above key values are encountered, apply a formatting 
        //        // check to the text entered so far, and make adjustments as needed. 
        //        this.CorrectDateText(txt);

        //}
    }
}
