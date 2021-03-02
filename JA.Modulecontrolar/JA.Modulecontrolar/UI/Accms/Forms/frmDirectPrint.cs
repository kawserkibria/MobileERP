using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dutility;
using CrystalDecisions.CrystalReports.Engine;
using JA.Modulecontrolar.JRPT;
using Microsoft.Win32;
using JA.Modulecontrolar.UI.DReport.Accms.ReportUI;
using System.Drawing.Printing;
using System.Threading;
namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmDirectPrint : Form
    {
        public string strString { get; set; }
        private String reportTitle = "";
        private String reportHeading = "";
        private String secondParameter = "";
        public String ReportTitle { set { reportTitle = value; } get { return reportTitle; } }
        public String ReportSecondParameter { set { secondParameter = value; } get { return secondParameter; } }
        public String ReportHeading { set { reportHeading = value; } get { return reportHeading; } }
        public string strComID { get; set; }
        public int mintVType { get; set; }
        JRPT.SWRPTClient orptCnn = new SWRPTClient();
        public frmDirectPrint()
        {
            #region "Registry"
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
            #endregion
            InitializeComponent();
        }

        private void frmDirectPrint_Load(object sender, EventArgs e)
        {
            if (strString != "")
            {
                int introw = 0;
                string[] words = strString.Split('~');
                foreach (string strRefNo in words)
                {
                    if (strRefNo != "")
                    {
                        try
                        {
                            DG.Rows.Add();
                            DG.Rows[introw].Cells[0].Value = strRefNo;
                            DG.Rows[introw].Cells[1].Value = Utility.Mid(strRefNo, 6, strRefNo.Length - 6);
                            DG.Rows[introw].Cells[2].Value = "Processing";
                            introw += 1;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                lblTotalPrint.Text = "Total Record :" + introw;
                DG.AllowUserToAddRows = false;
               
            }

        }
        private void InitialiseLabels(ReportDocument rpt)
        {
            try
            {

                ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyName"]).Text = Utility.gstrCompanyName;
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyAddress1"]).Text = Utility.gstrCompanyAddress1;
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyAddress2"]).Text = Utility.gstrCompanyAddress2;
                //((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyEmail"]).Text = Utility.gstrEmail;
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyName2"]).Text = Utility.gstrCompanyName;
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter2"]).Text = Utility.gstrCompanyAddress1;

                ((TextObject)rpt.ReportDefinition.ReportObjects["txtIT"]).Text = Utility.gstrMsg;
                //((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyWeb"]).Text = Utility.gstrWeb;
                if (ReportTitle != "")
                {
                    ((TextObject)rpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.ReportTitle;
                    if (ReportSecondParameter != "")
                    {
                        ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter2"]).Text = this.ReportTitle + " From " + '-' + this.secondParameter;
                    }
                }
                if (ReportSecondParameter != "")
                {
                    ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter"]).Text = this.secondParameter;
                }
                else
                {
                    rpt.ReportDefinition.ReportObjects["txtSecondParameter"].ObjectFormat.EnableSuppress = true;
                }
                if (ReportHeading != "")
                {
                    ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyPhone"]).Text = ReportHeading;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void mDirectPrint(int intVtype, string strString, string strBranchID, int intSP, string strHeading, int intNarration)
        {
            string Header1 = "", Header2 = "", Header3 = "", Header4 = "", Header5 = "";
            double dblPasesize = 0;
           

            ReportDocument rpt1;
            List<RAudit> otheading = orptCnn.mGetHeader(strComID, intVtype).ToList();
            if (otheading.Count > 0)
            {
                foreach (RAudit oo in otheading)
                {
                    Header1 = oo.strHeader1;
                    Header2 = oo.strHeader2;
                    Header3 = oo.strHeader3;
                    Header4 = oo.strHeader4;
                    Header5 = oo.strHeader5;
                    dblPasesize = oo.dblPazeSize;

                }

                if (intSP == 0)
                {
                    if (dblPasesize == 0)
                    {
                        rptAccountsVoucherN rptAccountsVoucher = new rptAccountsVoucherN();
                        rpt1 = (ReportDocument)rptAccountsVoucher;
                    }
                    else
                    {
                        rptAccountsVoucherNHalf rptAccountsVoucher = new rptAccountsVoucherNHalf();
                        rpt1 = (ReportDocument)rptAccountsVoucher;


                    }
                    rpt1.SetDataSource(orptCnn.mGetAccountsvoucher(strComID, "", "", intVtype, 0, strString, strBranchID, intSP).ToList());
                }
                else
                {
                    rptAccountsVoucherSP rptAccountsVoucherSumm = new rptAccountsVoucherSP();
                    rpt1 = (ReportDocument)rptAccountsVoucherSumm;
                    rpt1.SetDataSource(orptCnn.mGetAccountsvoucherSP(strComID, intVtype, 0, strString, strBranchID).ToList());
                }
                if (intSP == 0)
                {
                    rpt1.SetDataSource(orptCnn.mGetAccountsvoucher(strComID, "", "", intVtype, 0, strString, strBranchID, intSP).ToList());
                }
                else
                {
                    rpt1.SetDataSource(orptCnn.mGetAccountsvoucherSP(strComID, intVtype, 0, strString, strBranchID).ToList());
                }

                if (strHeading != "")
                {
                    this.reportTitle = strHeading;
                }
                else
                {
                    this.reportTitle = "";
                }

                InitialiseLabels(rpt1);

                if (intNarration == 1)
                {
                    rpt1.SetParameterValue("intSuppress", 0);
                }
                else
                {
                    rpt1.SetParameterValue("intSuppress", 1);
                }
                rpt1.SetParameterValue("strHeaderr1", Header1);
                rpt1.SetParameterValue("strHeaderr2", Header2);
                rpt1.SetParameterValue("strHeaderr3", Header3);
                rpt1.SetParameterValue("strHeaderr4", Header4);
                //crystalReportViewer1.ReportSource = rpt1;
                //crystalReportViewer1.d
                PrinterSettings settings = new PrinterSettings();
                string defaultPrinterName = settings.PrinterName;
                //MessageBox.Show("Start");=
                rpt1.PrintOptions.PrinterName = defaultPrinterName;
                rpt1.PrintToPrinter(1, true, 0, 0);
                rpt1.Dispose();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int intcount = 0;
                if (DG.Rows.Count > 0)
                {
                    for (int intow = 0; intow < DG.Rows.Count; intow++)
                    {
                        if (intow > 74)
                        {
                            MessageBox.Show("74 Records Print at a Time");
                            return;
                        }
                        mDirectPrint(mintVType, DG.Rows[intow].Cells[0].Value.ToString(), "", 0, "Payment Voucher", 1);
                        DG.Rows[intow].Cells[2].Value = "Print";
                        intcount += 1;
                        lblStartPrint.Text = "Printing Record :" + intow + "(" + DG.Rows[intow].Cells[0].Value.ToString() + ")";
                        //MessageBox.Show(DG.Rows[intow].Cells[0].Value.ToString());
                        
                    }
                    //this.Hide();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }









    }
}
