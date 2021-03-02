using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Dutility;
using JA.Modulecontrolar.JRPT;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.DReport.Accms.Viewer;
using Microsoft.Win32;
namespace JA.Modulecontrolar.UI.DReport.Accms.ParameterForms
{
    public partial class frmRptStatistics : JA.Shared.UI.frmSmartFormStandard
    {
        private ListBox lstUnder = new ListBox();
        SPWOIS objwois = new SPWOIS();
        JRPT.SWRPTClient orptCnn = new SWRPTClient();
        private string strComID { get; set; }
        public string strReportName { get; set; }
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        public frmRptStatistics()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            //this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            //this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);
            this.rbtYearly.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbtYearly_MouseClick);
            this.rbtMonthly.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbtMonthly_MouseClick);
            this.radDetails.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radDetails_MouseClick);
            this.radSumm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radSumm_MouseClick);

            this.btnRightSingle.Click += new System.EventHandler(this.btnRightSingle_Click);
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            this.btnLeftSingle.Click += new System.EventHandler(this.btnLeftSingle_Click);
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
 
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
        #region "User Deifne"
      
        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.Text.ToString());
                lstLeft.SelectedValue = lstLeft.Text;
                lstLeft.Items.Remove(lstLeft.Text.ToString());

                //lstLeft. = lstLeft.SortList;
            }

        }
        private void LoadDefaultValue()
        {
            SortedDictionary<string, int> userCache = new SortedDictionary<string, int>
            {
            {"January", 1},
            {"February", 2},
            {"March", 3},
            {"April",4},
            {"May", 5},
            {"June", 6},
            {"July", 7},
            {"August",8},
            {"September",9},
            {"October", 10},
            {"November", 11},
            {"December", 12}
            };

            lstLeft.DisplayMember = "Key";
            lstLeft.ValueMember = "Value";
            lstLeft.DataSource = new BindingSource(userCache, null);

        }
        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
               
                dteToDate.Focus();

            }
        }

        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnPrint.Focus();

            }
        }
        

        #endregion
        private void mLaodItem()
        {
            //lstItem.ValueMember = "strItemName";
            //lstItem.DisplayMember = "strItemName";
            //lstItem.DataSource = invms.gFillStockItem("", "", false).ToList();
         
        }

        private void radIndividual_Click(object sender, EventArgs e)
        {
           
            //txtLocationName.Enabled = true;
            //txtLocationName.Focus();
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            dteFromDate.Focus();
           
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            int intsumDet = 0, intSorting = 0, intwithoutFac = 0;
            string strString = "", strPayYearly = "";
            if (radDetails.Checked == true)
            {
                intsumDet = 1;
            }
            else if (radSumm.Checked == true)
            {
                intsumDet = 0;
            }
            else if (rbtMonthly.Checked == true)
            {
                intsumDet = 3;
            }
            else if (rbtYearly.Checked == true)
            {
                intsumDet = 2;
            }


            if (chkSorting.Checked == true)
            {
                intSorting = 1;
            }
            else
            {
                intSorting = 0;
            }
            if (strReportName == "Cash Flow")
            {

                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.CashFlow;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "Cash Flow";
                frmviewer.intSummDetails = intsumDet;

                frmviewer.Show();
            }
            else if (strReportName == "Manufacturing")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Manufacturing;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "Manufacturing";
                frmviewer.Show();
            }
            else if (strReportName == "Cheque Payment")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Cheque;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "Cheque";
                frmviewer.intSP = intSorting;
                frmviewer.Show();
            }
            else if (strReportName == "Special Commission")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                if (chkboxCoulamAutoGenaret.Checked == true)
                {
                    frmviewer.selector = ViewerSelector.SP;
                }
                else
                {
                    frmviewer.selector = ViewerSelector.SP2;
                }
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "SP";
                frmviewer.Show();
            }

            else if (strReportName == "Payment Summary")
            {
                if (chkboxWfactory.Checked == true)
                {
                    intwithoutFac = 1;
                }
                else
                {
                    intwithoutFac = 0;
                }

                if (rbtYearly.Checked == true)
                {
                    if (lstRight.Items.Count <= 0)
                    {
                        MessageBox.Show("Data Not Found.");
                        return;
                    }
                    {
                        if (lstRight.Items.Count > 2)
                        {
                            MessageBox.Show("You can Maximum two Company selected");
                            lstRight.Focus();
                            return;
                        }
                        if (lstRight.Items.Count > 0)
                        {
                            lstRight.Sorted = true;
                            for (int i = 0; i < lstRight.Items.Count; i++)
                            {
                                strString = lstRight.Items[i].ToString().Replace("'", "''");

                                strPayYearly = objwois.minsertPaymentSummaryYearly(strComID, strString, i, intwithoutFac);
                            }
                            if (strString != "")
                            {
                                strString = Utility.Mid(strString, 0, strString.Length - 1);
                            }
                        }

                    }
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.ExpenseSummYearly;
                    frmviewer.strSelction = "Payment Summary(Yearly)";
                    frmviewer.intSummDetails = intsumDet;
                    frmviewer.intHor_ver = intwithoutFac;
                    frmviewer.Show();
                }
                else if (rbtMonthly.Checked == true)
                {
                    string strString2="";

                    for (int i = 0; i < lstRight.Items.Count; i++)
                    {
                        strString2 = lstRight.Items[i].ToString().Replace("'", "''") ;

                        string sddd = orptCnn.mGetPaymentSummaryMonthly(strComID, comboBox1.Text, intwithoutFac, strString2, i);
                      
                    }
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.ExpenseSummMonthly;
                    frmviewer.strString = comboBox1.Text;
                    frmviewer.strTdate = dteToDate.Text;
                    frmviewer.strSelction = "Payment Summary(Monthly)";
                    frmviewer.intSummDetails = intsumDet;
                    frmviewer.intHor_ver = intwithoutFac;
                    frmviewer.strString3 = strString2;
                    frmviewer.Show();
                }
                else
                {
                    frmReportViewer frmviewer = new frmReportViewer();
                    frmviewer.selector = ViewerSelector.ExpenseSumm;
                    frmviewer.strFdate = dteFromDate.Text;
                    frmviewer.strTdate = dteToDate.Text;
                    frmviewer.strSelction = "Payment Summary";
                    frmviewer.intSummDetails = intsumDet;
                    frmviewer.Show();
                }


            }
            else if (strReportName == "ERP Statistics")
            {
                frmReportViewer frmviewer = new frmReportViewer();
                frmviewer.selector = ViewerSelector.Statistics;
                frmviewer.strFdate = dteFromDate.Text;
                frmviewer.strTdate = dteToDate.Text;
                frmviewer.strSelction = "ERP Statistics";
                frmviewer.Show();
            }

        }


     
        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        private void rbtYearly_MouseClick(object sender, MouseEventArgs e)
        {
            lstRight.Items.Clear();
            groupSelection.Enabled = true;
            label5.Visible = false;
            label1.Visible = false;
            dteFromDate.Visible = false;
            dteToDate.Visible = false;
            pnlYearMonth.Visible = false;
            groupSelection.Visible = true;
            chkboxWfactory.Visible = true;
            chkboxWfactory.Enabled = true;

        }

        private void rbtMonthly_MouseClick(object sender, MouseEventArgs e)
        {
            lstRight.Items.Clear();
            LoadDefaultValue();
            groupSelection.Enabled = true;
            label5.Visible = false;
            label1.Visible = false;
            dteFromDate.Visible = false;
            dteToDate.Visible = false;
            pnlYearMonth.Visible = true;
            groupSelection.Visible = true;
            chkboxWfactory.Visible = true;
            chkboxWfactory.Enabled = true;
            lstLeft.Enabled = true;

        }
        private void radDetails_MouseClick(object sender, MouseEventArgs e)
        {
            lstRight.Items.Clear();
            label5.Visible = true;
            label1.Visible = true;
            groupSelection.Visible = false;
            pnlYearMonth.Visible = false;
            groupSelection.Visible = false;
            dteFromDate.Visible = true;
            dteToDate.Visible = true;
            groupSelection.Enabled = false;
            chkboxWfactory.Enabled = false;
            chkboxWfactory.Checked = false;

        }

        private void radSumm_MouseClick(object sender, MouseEventArgs e)
        {
            lstRight.Items.Clear();
            label5.Visible = true;
            label1.Visible = true;
            groupSelection.Visible = false;
            pnlYearMonth.Visible = false;
            groupSelection.Visible = false;
            dteFromDate.Visible = true;
            dteToDate.Visible = true;
            groupSelection.Enabled = false;
            chkboxWfactory.Enabled = false;
            chkboxWfactory.Checked = false;
        }
        private void getCompanyName()
        {
            lstLeft.Items.Clear();
            int i = 0;
            List<DatabaseCompany> orptt = invms.mloadDatabaseCompnay(strComID).ToList();

            if (orptt.Count > 0)
            {
                foreach (DatabaseCompany ostk in orptt)
                {
                    lstLeft.Items.Add(ostk.strComName);
                }
            }
        }
        private void btnRightSingle_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count > 0)
            {
                lstRight.Items.Add(lstLeft.SelectedItem.ToString());
                lstLeft.Items.Remove(lstLeft.SelectedItem.ToString());
                lstLeft.SetSelected(0, true);

            }
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstLeft.Items.Count; i++)
            {

                string strItem = lstLeft.Items[i].ToString().TrimStart();
                lstRight.Items.Add(strItem);

            }
            lstLeft.Items.Clear();
        }

        private void btnLeftSingle_Click(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count > 0)
            {
                lstLeft.Items.Add(lstRight.SelectedItem.ToString());
                lstRight.Items.Remove(lstRight.SelectedItem.ToString());
            }
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRight.Items.Count; i++)
            {
                string strItem = lstRight.Items[i].ToString().TrimStart();
                lstLeft.Items.Add(strItem);
            }
            lstRight.Items.Clear();
        }
        private void frmRptStatistics_Load(object sender, EventArgs e)
        {
            chkboxWfactory.Checked = false;
            chkboxWfactory.Enabled = false;
            if (strReportName == "Cash Flow")
            {
                pnlSummDet.Visible = true;
                chkSorting.Visible = false;
                chkboxCoulamAutoGenaret.Visible = false;
                chkboxWfactory.Checked = false;
                chkboxWfactory.Enabled = false;
                pnlSummDet.Size = new Size(320, 45);
            }
            else if (strReportName == "Cheque Payment")
            {
                chkSorting.Visible = true;
                pnlSummDet.Visible = false;
                chkboxCoulamAutoGenaret.Visible = false;
                chkboxWfactory.Checked = false;
                chkboxWfactory.Enabled = false;
                pnlSummDet.Size = new Size(320, 45);
            }
            else if (strReportName == "Payment Summary")
            {
                chkSorting.Visible = false;
                pnlSummDet.Visible = true;
                chkboxCoulamAutoGenaret.Visible = false;
                chkboxWfactory.Checked = false;
                chkboxWfactory.Enabled = true;
                pnlSummDet.Size = new Size(525, 45);
                getCompanyName();
            }
               
            else
            {
                chkSorting.Visible = false;
                pnlSummDet.Visible = false;
                chkboxWfactory.Checked = false;
                chkboxWfactory.Enabled = false;
                chkboxCoulamAutoGenaret.Visible = true;
                //this.Size = new Size(475, 391);
            }

            frmLabel.Text = strReportName;
            dteToDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dteFromDate.Text = Utility.FirstDayOfMonth(dteToDate.Value).ToString("dd-MM-yyyy");
        }
      
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
