using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Dutility;
using JA.Modulecontrolar.JRPT;
using JA.Modulecontrolar.UI.DReport.Accms.ReportUI;
using JA.Modulecontrolar.UI.DReport.Inventory.ReportUI;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.DReport.Accms.Viewer
{
    public partial class frmReportViewer : Form
    {
        JRPT.SWRPTClient orptCnn = new SWRPTClient();
        SPWOIS objWoIS = new SPWOIS();
        private string strComID { get; set; }
        private String reportTitle = "";
        private String secondParameter = "";
        private String reportHeading = "";
        public DateTime dteFdate { get; set; }
        public double dblClosingBalance { get; set; }
        public double dblClosingBalance1 { get; set; }
        public DateTime dteTdate { get; set; }
        public string  strFdate { get; set; }
        public bool blngDirectprint { get; set; }
        public string  strTdate { get; set; }

        public string strledgerName = "";
        public string strGroup = "";
        public string strSalesFdate { get; set; }
        public string strSalesTdate { get; set; }
        public string strString { get; set; }
        public string strString2 { get; set; }
        public string strString3 { get; set; }
        public string strSelction { get; set; }
        public string strBranchID { get; set; }
        public string strHeading { get; set; }
        public string mstrBranchName { get; set; }
        public string strPreviousFDate { get; set; }
        public string strPreviousTDate { get; set; }
        public int intVtype { get; set; }
        public int intTarget { get; set; }
        public int intNarration { get; set; }
        public int intSignatory { get; set; }
        public int intSummDetails { get; set; }
        public int intSalesColl { get; set; }
        public double dblAmount { get; set; }
        public string strSelf { get; set; }
        public int intSP { get; set; }
        public int intHor_ver { get; set; }
        public int intSuppress { get; set; }
        public int intValueSuppress { get; set; }
        public int intSalesCollection { get; set; }
        public int intTargetSuppress { get; set; }
        public string strPFdate { get; set; }
        public string strPTdate { get; set; }
        public string strPMonthID { get; set; }
        public ViewerSelector selector;
        public string ReportSecondParameter1 { get; set; }
        public String ReportTitle { set { reportTitle = value; } get { return reportTitle; } }
        public String ReportSecondParameter { set { secondParameter = value; } get { return secondParameter; } }
        public String ReportHeading { set { reportHeading = value; } get { return reportHeading; } }
        public frmReportViewer()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

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

        private void InitialiseLabels(ReportDocument rpt)
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
                    if (this.secondParameter.Length > 3)
                    {
                        ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter2"]).Text = this.ReportTitle + " From " + '-' + this.secondParameter;
                    }
                    else
                    {
                        ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter2"]).Text = this.ReportTitle;
                    }
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
        #region "Load"
        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            string strMonth = "", strBranchName = "", strGroupName = "", strPartyName = "";

            double dblPasesize = 0;
            string Header1 = "", Header2 = "", Header3 = "", Header4 = "", Header5 = "", Header6 = "", Header7 = "",
               Header8 = "", Header9 = "", Header10 = "", Header11 = "", Header12 = "", Header13 = "", Header14 = "", Header15 = "", Header16 = "", Header17 = "", Header18 = "", Header19 = "";

            ReportDocument rpt1;
            try
            {
                switch (selector)
                {
                    #region "Incentive "
                    case ViewerSelector.IncPoleci:
                        List<RoIncentive> opIncentiveR = orptCnn.mGetIncentive(strComID, intNarration, strString).ToList();
                        if (opIncentiveR.Count > 0)
                        {
                            rptIncentivePolicy rpt = new rptIncentivePolicy();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(opIncentiveR.ToList());
                            this.reportTitle = strHeading;
                            this.secondParameter = "55";
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }

                        break;
                    case ViewerSelector.IncMonthly:
                        List<RoIncentive> opIncentiveMonthly = orptCnn.mGetIncentiveMonthly(strComID, strFdate, strTdate, strString, strString2).ToList();
                        if (opIncentiveMonthly.Count > 0)
                        {

                            if (strString == "MPO")
                            {
                                rptIncentiveMonthlyMPO rpt = new rptIncentiveMonthlyMPO();
                                rpt1 = (ReportDocument)rpt;
                            }
                            else
                            {
                                rptIncentiveMontlyAH_DH rpt = new rptIncentiveMontlyAH_DH();
                                rpt1 = (ReportDocument)rpt;
                            }
                            rpt1.SetDataSource(opIncentiveMonthly.ToList());
                            this.reportTitle = strHeading;
                            this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "Incentive View"
                    case ViewerSelector.IncGenview:
                        List<RoIncentive> opIncentive = orptCnn.GetIncentiveList(strComID, strString, strString2, intSalesCollection).ToList();
                        if (opIncentive.Count > 0)
                        {
                            rptIncentiveView rpt = new rptIncentiveView();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(opIncentive.ToList());
                            this.reportTitle = strHeading;
                            this.secondParameter = "";
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");

                        }

                        break;
                    #endregion
                    #region "PF_HL Information_Details"
                    case ViewerSelector.PFHLDetails:
                        List<RoPaymentSummaryMonthly> oPFHLDetails = orptCnn.mGetHLPFMonthly(strComID, strBranchID, strFdate, strTdate, strString, intSP).ToList();
                        if (oPFHLDetails.Count > 0)
                        {
                            DateTime datevale = Convert.ToDateTime(DateTime.Today.ToString("dd-MM-yyyy"));
                            rptHL_PF_12Month rpt = new rptHL_PF_12Month();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(oPFHLDetails.ToList());
                            this.reportTitle = strHeading;
                            this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                            InitialiseLabels(rpt1);
                            rpt1.SetParameterValue("BranchName", strString2);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");

                        }

                        break;
                    #endregion
                    #region "Privileges"
                    case ViewerSelector.userPrevilegsMenu:
                        List<RAudit> oUserPrevilegsmenu = orptCnn.mgetUserPrivilage(strComID, strSelction).ToList();
                        if (oUserPrevilegsmenu.Count > 0)
                        {
                            rptUserPrevilegs_menu rptCashFlow = new rptUserPrevilegs_menu();
                            rpt1 = (ReportDocument)rptCashFlow;
                            rptCashFlow.SetDataSource(oUserPrevilegsmenu.ToList());
                            this.reportTitle = "User Previleges";
                            rpt1.SetParameterValue("Username", "User Name :" + strSelction);
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        break;
                    #endregion
                    #region "Closing_PF_HL Information"
                    case ViewerSelector.PFHLClosing:
                        List<RoPFHL> oPFHLClosing = orptCnn.mGetMpoClosingValue(strComID, strFdate, strBranchID, strString, intSP).ToList();
                        if (oPFHLClosing.Count > 0)
                        {
                            DateTime datevale = Convert.ToDateTime(DateTime.Today.ToString("dd-MM-yyyy"));
                            rptPF_HLClosing rpt = new rptPF_HLClosing();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(oPFHLClosing.ToList());
                            this.reportTitle = strHeading;
                            this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");

                        }

                        break;
                    #endregion
                    #region "PF_HL Information"
                    case ViewerSelector.PFHL:
                        List<RoPFHL> oPFHL = orptCnn.mGetPFHL(strComID, strFdate, strTdate, strBranchID, strString, intSP).ToList();
                        if (oPFHL.Count > 0)
                        {
                            DateTime datevale = Convert.ToDateTime(DateTime.Today.ToString("dd-MM-yyyy"));
                            rptPF_HL rpt = new rptPF_HL();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(oPFHL.ToList());
                            this.reportTitle = strHeading;
                            this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                            InitialiseLabels(rpt1);
                            rpt1.SetParameterValue("BranchName", strString2);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");

                        }

                        break;
                    #endregion
                    #region "PaymentSummary New"
                    case ViewerSelector.ExpenseSummMonthly:
                        List<RoPaymentSummaryMonthly> oPaymentSummaryMonthly = orptCnn.mGetPaymentSummaryMonthlyReportView(strComID).ToList();
                        if (oPaymentSummaryMonthly.Count > 0)
                        {
                            DateTime datevale = Convert.ToDateTime(DateTime.Today.ToString("dd-MM-yyyy"));
                            rptPaymentSummary12Month rpt = new rptPaymentSummary12Month();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(oPaymentSummaryMonthly.ToList());
                            this.reportTitle = "Payment Summary Monthly ";
                            InitialiseLabels(rpt1);
                            rpt1.SetParameterValue("stryear", strString);
                            crystalReportViewer1.ReportSource = rpt1;

                            ShowReport(rpt1, false, "");

                        }

                        break;
                    case ViewerSelector.ExpenseSummYearly:
                        List<RoPaymentSummaryearly> oPaymentSummaryyearly = orptCnn.mGetPaymentSummaryYearly(strComID, strString, 0).ToList();
                        if (oPaymentSummaryyearly.Count > 0)
                        {
                            DateTime datevale = Convert.ToDateTime(DateTime.Today.ToString("dd-MM-yyyy"));
                            rptPaymentSummaryYearly rpt = new rptPaymentSummaryYearly();
                            rpt1 = (ReportDocument)rpt;
                            this.reportTitle = "Payment Summary Yearly";
                            rpt1.SetDataSource(oPaymentSummaryyearly.ToList());
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");

                        }

                        break;

                    #endregion
                    #region "daily Collection New"
                    case ViewerSelector.DailyCollectionNew:
                        List<RoDayliCollection> odailyColeDetailsNew = orptCnn.mgetDailyCollectionN(strComID).ToList();
                        if (odailyColeDetailsNew.Count > 0)
                        {

                            rptDailyCollectionNew rpt = new rptDailyCollectionNew();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(odailyColeDetailsNew.ToList());
                            this.reportTitle = strHeading;
                            this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                            InitialiseLabels(rpt1);
                            //rpt1.SetParameterValue("strBranchName", "Branch:" + mstrBranchName);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");

                        }
                        break;
                    #endregion
                    #region "Commition"
                    case ViewerSelector.commitionN:
                        List<RStockInformation> commitionN2 = orptCnn.mGetCommitionN(strComID, strFdate, strTdate, strBranchID, strString).ToList();
                        if (commitionN2.Count > 0)
                        {

                            rptAcc_CommNN rpt = new rptAcc_CommNN();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(commitionN2.ToList());
                            this.reportTitle = strHeading;
                            this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            //rpt1.SetParameterValue("mstrBranchName", "Branch :" + mstrBranchName);
                            rpt1.SetParameterValue("dblPercent", dblAmount);
                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "LedgerConfig"
                    case ViewerSelector.LedgerConfig:
                        List<RAccountsGroup> objList = orptCnn.mFillLedgerListMpoPercen(strComID, strString).ToList();
                        if (strString == "Salary By Voucher")
                        {
                            rptLedgerCommissionSalary rptoLedgerConfig = new rptLedgerCommissionSalary();
                            rpt1 = (ReportDocument)rptoLedgerConfig;
                        }
                        else
                        {
                            rptLedgerCommission rptoLedgerConfig = new rptLedgerCommission();
                            rpt1 = (ReportDocument)rptoLedgerConfig;
                        }

                        rpt1.SetDataSource(objList.ToList());
                        this.reportTitle = "" + strString + "";
                        this.secondParameter = ".";
                        InitialiseLabels(rpt1);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "MPOCommManual"
                    case ViewerSelector.MpoCommManuallist:
                        List<RAccountsGroup> oMpoComm = orptCnn.mFillDisplayBill(strComID, strString).ToList();
                        rptMPOCommMenual rptMPOCommMenual = new rptMPOCommMenual();
                        rpt1 = (ReportDocument)rptMPOCommMenual;
                        rpt1.SetDataSource(oMpoComm.ToList());
                        this.reportTitle = "Draft MPO Commission(" + strString2 + ") ";
                        this.secondParameter = ".";
                        InitialiseLabels(rpt1);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "Honda Loan"
                    case ViewerSelector.HondaLoan:
                        double dblFineRecAmount = 0;
                        List<RHondaLoan> ohondaLoan = orptCnn.mGetHondaLoan(strComID, strBranchID, strledgerName, strGroup, strFdate, strTdate, intVtype, strString3, intValueSuppress).ToList();
                        if (ohondaLoan.Count > 0)
                        {
                            if (intVtype == 1)
                            {
                                rptHoandaLoan rpt = new rptHoandaLoan();
                                rpt1 = (ReportDocument)rpt;
                                rpt1.SetDataSource(ohondaLoan.ToList());
                                this.reportTitle = "Honda Loan Statement";
                                this.secondParameter = "As on" + ":" + Convert.ToDateTime(strTdate).ToString("dd-MM-yyy");
                                InitialiseLabels(rpt1);
                                rpt1.SetParameterValue("intSuppress", intSuppress);
                                rpt1.SetParameterValue("dtpSuppress", Convert.ToDateTime(strTdate).ToString("dd-MM-yyy"));
                                crystalReportViewer1.ReportSource = rpt1;
                                ShowReport(rpt1, false, "");
                            }
                            else
                            {
                                List<RHondaLoan> oFineAmount = orptCnn.mHondaLoanFineRecAmoun(strComID, strledgerName).ToList();

                                if (oFineAmount.Count > 0)
                                {
                                    foreach (RHondaLoan oo in oFineAmount)
                                    {
                                        dblFineRecAmount = oo.dblRecFineAmount;

                                    }
                                }
                                rptHoandaLoan_Indvidiul rpt = new rptHoandaLoan_Indvidiul();
                                rpt1 = (ReportDocument)rpt;
                                rpt1.SetDataSource(ohondaLoan.ToList());
                                this.reportTitle = "Honda Loan Payment Schedule";
                                this.secondParameter = Convert.ToDateTime(strTdate).ToString("dd-MM-yyy");
                                InitialiseLabels(rpt1);
                                rpt1.SetParameterValue("strLedgerName", strledgerName);
                                rpt1.SetParameterValue("dblFineRecAmount", dblFineRecAmount);
                                crystalReportViewer1.ReportSource = rpt1;
                                ShowReport(rpt1, false, "");
                            }

                        }
                        break;
                    #endregion
                    #region "SP"
                    case ViewerSelector.SP3:

                        int intloop = 0;

                        string[] words = strString.Split('|');
                        foreach (string ooObj in words)
                        {

                            if (ooObj != "")
                            {
                                if (intloop == 0)
                                {
                                    Header1 = ooObj.ToString().Replace("'", "");

                                }
                                if (intloop == 1)
                                {
                                    Header2 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 2)
                                {
                                    Header3 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 3)
                                {
                                    Header4 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 4)
                                {
                                    Header5 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 5)
                                {
                                    Header6 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 6)
                                {
                                    Header7 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 7)
                                {
                                    Header8 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 8)
                                {
                                    Header9 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 9)
                                {
                                    Header10 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 10)
                                {
                                    Header11 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 11)
                                {
                                    Header12 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 12)
                                {
                                    Header13 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 13)
                                {
                                    Header14 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 14)
                                {
                                    Header15 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 15)
                                {
                                    Header16 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 16)
                                {
                                    Header17 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 17)
                                {
                                    Header18 = ooObj.ToString().Replace("'", "");
                                }
                                if (intloop == 18)
                                {
                                    Header19 = ooObj.ToString().Replace("'", "");
                                }
                            }

                            intloop += 1;
                        }

                        List<RoMCommission> oSP2 = orptCnn.GetrptSPCommission3(strComID, strFdate, strTdate, strString).ToList();
                        rptSPCommission2 rptSPCommission2 = new rptSPCommission2();
                        rpt1 = (ReportDocument)rptSPCommission2;
                        rpt1.SetDataSource(oSP2.ToList());
                        this.reportTitle = "MPO Commission ";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetParameterValue("Header1", Header1);
                        rpt1.SetParameterValue("Header2", Header2);
                        rpt1.SetParameterValue("Header3", Header3);
                        rpt1.SetParameterValue("Header4", Header4);
                        rpt1.SetParameterValue("Header5", Header5);
                        rpt1.SetParameterValue("Header6", Header6);
                        rpt1.SetParameterValue("Header7", Header7);
                        rpt1.SetParameterValue("Header8", Header8);
                        rpt1.SetParameterValue("Header9", Header9);
                        rpt1.SetParameterValue("Header10", Header10);
                        rpt1.SetParameterValue("Header11", Header11);
                        rpt1.SetParameterValue("Header12", Header12);
                        rpt1.SetParameterValue("Header13", Header13);
                        rpt1.SetParameterValue("Header14", Header14);
                        rpt1.SetParameterValue("Header15", Header15);

                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;


                    case ViewerSelector.MpoCommissionSP:
                        List<RAudit> otheading22 = orptCnn.mGetHeader(strComID, intVtype).ToList();
                        if (otheading22.Count > 0)
                        {
                            foreach (RAudit oo in otheading22)
                            {
                                Header1 = oo.strHeader1;
                                Header2 = oo.strHeader2;
                                Header3 = oo.strHeader3;
                                Header4 = oo.strHeader4;
                                Header5 = oo.strHeader5;
                                dblPasesize = oo.dblPazeSize;

                            }
                        }
                        rptAccountsVoucherSP2 rptAccountsVoucherSP2 = new rptAccountsVoucherSP2();
                        rpt1 = (ReportDocument)rptAccountsVoucherSP2;

                        rpt1.SetDataSource(objWoIS.mGetMpoCommissionSP(strComID, intVtype, intSummDetails, strString, strBranchID, strFdate, strTdate, strPFdate, strPTdate,
                                                                            Utility.gstrUserName, strPMonthID, strPreviousFDate, strPreviousTDate).ToList());
                        this.reportTitle = strHeading;

                        this.secondParameter = "";
                        InitialiseLabels(rpt1);
                        crystalReportViewer1.ReportSource = rpt1;
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

                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region "Bank RP"
                    case ViewerSelector.BankRP:
                        if (intSummDetails == 0)
                        {
                            string strInsert = objWoIS.mInserRPBank(strComID, strFdate, strTdate, strBranchID);
                            if (strInsert != "")
                            {
                                List<RAccountsGroup> oreport = objWoIS.mGetBankwiseQuery(strComID, 0, "", "", strBranchID);
                                rptBankWiseRP rptBankWiseRP = new rptBankWiseRP();
                                rpt1 = (ReportDocument)rptBankWiseRP;
                                rpt1.SetDataSource(oreport.ToList());
                                this.reportTitle = "Bank Wise Receipt/Payment";
                                this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                                InitialiseLabels(rpt1);
                                crystalReportViewer1.ReportSource = rpt1;
                                ShowReport(rpt1, false, "");
                            }
                        }
                        else
                        {
                            double dblAmount = 0, dblHLAmount = 0, dblPFAmount = 0;
                            List<RAccountsGroup> oreport = objWoIS.mGetBankwiseQuery(strComID, 1, strFdate, strTdate, strBranchID);
                            foreach (RAccountsGroup objReport in oreport)
                            {
                                if (objReport.strLedgerName == "Bkash Non Active")
                                {
                                    dblAmount = dblAmount + objReport.dblAmount;
                                }
                                else if (objReport.strLedgerName == "Southeast Bank SNd A/C")
                                {
                                    dblAmount = dblAmount + objReport.dblAmount;
                                }
                                else if (objReport.strLedgerName == "Pubali Bank Limited (Herbal SND-1260)")
                                {
                                    dblAmount = dblAmount + objReport.dblAmount;
                                }
                                else if (objReport.strLedgerName == "SBL-SND (02213)")
                                {
                                    dblAmount = dblAmount + objReport.dblAmount;
                                }
                            }
                            List<RAccountsGroup> oreport1 = objWoIS.mGetBankwiseHLPF(strComID, 1, strFdate, strTdate, strBranchID);
                            foreach (RAccountsGroup objReport in oreport1)
                            {

                                if (objReport.strLedgerName == "Honda Loan")
                                {
                                    dblHLAmount = objReport.dblAmount;
                                    dblAmount = dblAmount + dblHLAmount;
                                }
                                else if (objReport.strLedgerName == "Provident Fund")
                                {
                                    dblPFAmount = objReport.dblAmount;
                                    dblAmount = dblAmount + dblPFAmount;
                                }
                            }

                            rptBankCollectionReceipt rptBankCollectionReceipt = new rptBankCollectionReceipt();
                            rpt1 = (ReportDocument)rptBankCollectionReceipt;
                            rpt1.SetDataSource(oreport.ToList());
                            this.reportTitle = "Collection Summary(" + strString + ")";
                            this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                            rpt1.SetParameterValue("dblHondaloan", dblHLAmount);
                            rpt1.SetParameterValue("dblPF", dblPFAmount);
                            rpt1.SetParameterValue("SalesValue", dblAmount);
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");

                        }

                        break;
                    #endregion
                    #region "Credit Limit"
                    case ViewerSelector.CreditLimit:

                        List<RCreditLimit> oCriditLimit = objWoIS.mGetCreditLimit(strComID, strBranchID, strFdate, strTdate, strString, strString2, strString3, strSelction, intVtype, Utility.gstrUserName, intSP).ToList();
                        if (oCriditLimit.Count > 0)
                        {
                            if (intSP >= 1)
                            {
                                rptCreditLimitOneM rptCreditLimit = new rptCreditLimitOneM();
                                rpt1 = (ReportDocument)rptCreditLimit;
                                rptCreditLimit.SetDataSource(oCriditLimit.ToList());
                            }
                            else
                            {
                                rptCreditLimit rptCreditLimit = new rptCreditLimit();
                                rpt1 = (ReportDocument)rptCreditLimit;
                                rptCreditLimit.SetDataSource(oCriditLimit.ToList());
                            }
                            this.reportTitle = "Credit Limit";
                            this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strSelf).ToString("dd-MM-yyyy");
                            rpt1.SetParameterValue("First_Month", Convert.ToDateTime(strFdate).ToString("MMMyy"));
                            rpt1.SetParameterValue("Second_Month", Convert.ToDateTime(strTdate).ToString("MMMyy"));
                            rpt1.SetParameterValue("Third_Month", Convert.ToDateTime(strString).ToString("MMMyy"));
                            rpt1.SetParameterValue("Fourth_Month", Convert.ToDateTime(strString2).ToString("MMMyy"));
                            rpt1.SetParameterValue("mstrBranchName", mstrBranchName);
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        break;
                    #endregion
                    #region "Privilegs"
                    case ViewerSelector.userPrevilegs:

                        List<RAudit> oUserPrevilegs = orptCnn.mgetUserPrivilage(strComID, strSelction).ToList();
                        if (oUserPrevilegs.Count > 0)
                        {
                            rptUserPrevilegs rptCashFlow = new rptUserPrevilegs();
                            rpt1 = (ReportDocument)rptCashFlow;
                            rptCashFlow.SetDataSource(oUserPrevilegs.ToList());
                            this.reportTitle = "User Previleges";
                            rpt1.SetParameterValue("Username", "User Name :" + strSelction);
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        break;
                    #endregion
                    #region "Budget"
                    case ViewerSelector.Budget:

                        List<RAccountsGroup> oBudget = orptCnn.mGetBudget(strComID, strString, strFdate, strTdate).ToList();
                        if (oBudget.Count > 0)
                        {
                            rptBudget rpt = new rptBudget();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(oBudget.ToList());
                            this.reportTitle = "Budget Report";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "Market Monitoring Sheet"
                    case ViewerSelector.MarketMonitoring:
                        if (intSP == 1)
                        {

                            string FFdate = Utility.FirstDayOfMonth(Convert.ToDateTime(strFdate)).ToString("dd-MM-yyyy");
                            string TTdate = Utility.LastDayOfMonth(Convert.ToDateTime(strTdate)).ToString("dd-MM-yyyy");
                            List<RFinalStatement> oMarketMonitorSP = objWoIS.mGetSalesCollSp(strComID, strFdate, strTdate,
                                                                                                       strBranchID, intNarration, strString, Utility.gstrUserName,
                                                                                                       intSummDetails, intTarget, intVtype, strString2, FFdate, TTdate).ToList();
                            if (oMarketMonitorSP.Count > 0)
                            {
                                rptSalesCollSpecial rpt = new rptSalesCollSpecial();
                                rpt1 = (ReportDocument)rpt;
                                rpt1.SetDataSource(oMarketMonitorSP.ToList());
                                this.reportTitle = "Special Monitor ";
                                this.secondParameter = strFdate + " to " + strTdate;
                                InitialiseLabels(rpt1);
                                rpt1.SetParameterValue("Dateee", Convert.ToDateTime(strTdate).ToString(("dd-MMM-yyyy")));
                                crystalReportViewer1.ReportSource = rpt1;
                                ShowReport(rpt1, false, "");
                            }
                        }
                        else
                        {

                            string FFdate = Utility.FirstDayOfMonth(Convert.ToDateTime(strFdate)).ToString("dd-MM-yyyy");
                            string TTdate = Utility.LastDayOfMonth(Convert.ToDateTime(strTdate)).ToString("dd-MM-yyyy");

                            DateTime df = Convert.ToDateTime(FFdate);
                            DateTime dT = Convert.ToDateTime(TTdate);

                            long intnoofdays = Utility.DateDiff(Utility.DateInterval.Day, df, dT) + 1;
                            long lonnDays = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(strFdate), Convert.ToDateTime(strTdate)) + 1;

                            List<RFinalStatement> oMarketMonitor = orptCnn.mGetMarketMonitoringSheet(strComID, strFdate, strTdate,
                                                                                                        strBranchID, intNarration, strString, Utility.gstrUserName,
                                                                                                        intSummDetails, intTarget, intVtype, strString2, Convert.ToInt32(intnoofdays),
                                                                                   Convert.ToInt32(lonnDays), FFdate, TTdate).ToList();
                            if (oMarketMonitor.Count > 0)
                            {
                                strMonth = Convert.ToDateTime(strTdate).ToString(("MMMM")) + "'" + Convert.ToDateTime(strTdate).ToString(("yyyy"));

                                if (intValueSuppress == 1)
                                {

                                    rptMarketMonitoringSheet rpt = new rptMarketMonitoringSheet();
                                    rpt1 = (ReportDocument)rpt;
                                }
                                else
                                {
                                    if (intVtype == 1)
                                    {

                                        rptMarketMonitoringSheet rpt = new rptMarketMonitoringSheet();
                                        rpt1 = (ReportDocument)rpt;

                                    }
                                    else if (intVtype == 2)
                                    {
                                        if (intValueSuppress == 1)
                                        {
                                            //rptMarketMonitoringSheetMPO rpt = new rptMarketMonitoringSheetMPO();
                                            rptMarketMonitoringSheet rpt = new rptMarketMonitoringSheet();
                                            rpt1 = (ReportDocument)rpt;
                                        }
                                        else
                                        {
                                            rptMarketMonitoringSheetMPO rpt = new rptMarketMonitoringSheetMPO();
                                            rpt1 = (ReportDocument)rpt;
                                        }
                                    }
                                    else if (intVtype == 3)
                                    {
                                        //rptMarketMonitoringSheetMPO rpt = new rptMarketMonitoringSheetMPO();
                                        rptMarketMonitoringSheet_Area rpt = new rptMarketMonitoringSheet_Area();
                                        rpt1 = (ReportDocument)rpt;
                                    }
                                    else if (intVtype == 4)
                                    {
                                        //rptMarketMonitoringSheetMPO rpt = new rptMarketMonitoringSheetMPO();
                                        rptMarketMonitoringSheetDivision rpt = new rptMarketMonitoringSheetDivision();
                                        rpt1 = (ReportDocument)rpt;
                                    }
                                    else if ((intVtype == 5))
                                    {
                                        //rptMarketMonitoringSheet_Zone rpt = new rptMarketMonitoringSheet_Zone();
                                        rptMarketMonitoringSheet_Zone rpt = new rptMarketMonitoringSheet_Zone();
                                        rpt1 = (ReportDocument)rpt;
                                    }
                                    else
                                    {
                                        rptMarketMonitoringSheet rpt = new rptMarketMonitoringSheet();
                                        rpt1 = (ReportDocument)rpt;
                                    }
                                }
                                rpt1.SetDataSource(oMarketMonitor.ToList());
                                this.reportTitle = "Market Monitoring Sheet ";
                                this.secondParameter = strFdate + " to " + strTdate;
                                InitialiseLabels(rpt1);
                                rpt1.SetParameterValue("Tdate1", FFdate);
                                rpt1.SetParameterValue("Tdate2", TTdate);
                                rpt1.SetParameterValue("Adate1", strFdate);
                                rpt1.SetParameterValue("Adate2", strTdate);
                                crystalReportViewer1.ReportSource = rpt1;
                                ShowReport(rpt1, false, "");
                            }
                        }
                        break;
                    #endregion
                    #region "Final Statement"
                    case ViewerSelector.FinalStatement:
                        if (intSummDetails == 1)
                        {
                            strGroupName = strString;
                        }
                        else if (intSummDetails == 2)
                        {
                            strPartyName = strString;
                        }
                        else
                        {
                            strPartyName = "";
                            strGroupName = "";
                        }
                        List<RFinalStatement> oFinalState = orptCnn.mGetFinalStattemnet(strComID, strFdate, strTdate, strBranchID, strGroupName, strPartyName,
                                                                                            intNarration, intSummDetails, dblClosingBalance, dblClosingBalance1, strSelction, Utility.gstrUserName).ToList();
                        if (oFinalState.Count > 0)
                        {
                            strMonth = "For the Month of " + Convert.ToDateTime(strFdate).ToString("MMMMyyyy");
                            strBranchName = Utility.gstrGetBranchName(strComID, strBranchID);
                            if (intSuppress == 0)
                            {
                                rptFinal_statement_report rpt = new rptFinal_statement_report();
                                rpt1 = (ReportDocument)rpt;
                            }
                            else
                            {
                                rptFinal_statement_report_Print rpt = new rptFinal_statement_report_Print();
                                rpt1 = (ReportDocument)rpt;
                            }
                            rpt1.SetDataSource(oFinalState.ToList());
                            if (dblClosingBalance > 0 && dblClosingBalance == 0)
                            {
                                this.reportTitle = "Final Statement (Closing Balance " + strSelction + " " + dblClosingBalance + ")";
                            }
                            else if (dblClosingBalance > 0 && dblClosingBalance > 0)
                            {
                                this.reportTitle = "Final Statement (Closing Balance " + strSelction + " " + dblClosingBalance1 + " to " + dblClosingBalance + ")";
                            }
                            else
                            {
                                if (intSuppress == 0)
                                {
                                    this.reportTitle = "Final Statement";
                                    this.secondParameter = strFdate + " to " + strTdate;
                                }
                                else
                                {
                                    this.reportTitle = "Final Statement";
                                    this.secondParameter = strFdate + " to " + strTdate;
                                    strMonth = this.ReportTitle + " From " + '-' + this.secondParameter;

                                }
                            }

                            this.ReportHeading = "Branch : " + strBranchName;
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            rpt1.SetParameterValue("date", strFdate + " to " + strTdate);
                            rpt1.SetParameterValue("MonthID", strMonth);
                            rpt1.SetParameterValue("intSummDetails", intSummDetails);
                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "Daily Collection"
                    case ViewerSelector.DailyCollection:
                        List<RAccountsGroup> odailyColeDetails = objWoIS.mGetDailyCollectionDetails(strComID, strFdate, strTdate, strBranchID, intSP, Utility.gstrUserName, strSelction, intSummDetails, "").ToList();
                        if (odailyColeDetails.Count > 0)
                        {
                            if (intSP == 1)
                            {
                                rptDailyCollection_Only_Aacounts rpt = new rptDailyCollection_Only_Aacounts();
                                rpt1 = (ReportDocument)rpt;
                                rpt1.SetDataSource(odailyColeDetails.ToList());
                                rpt.Subreports[0].SetDataSource(orptCnn.mGetDailyCollection(strComID, strFdate, strTdate, strBranchID, Utility.gstrUserName, "BN", intSalesColl, strFdate, intSummDetails).ToList());
                                rpt.Subreports[1].SetDataSource(orptCnn.mGetDailyCollection(strComID, strTdate, strTdate, strBranchID, Utility.gstrUserName, strSelction, intSalesColl, strFdate, intSummDetails).ToList());
                                this.reportTitle = strHeading;
                                this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                                InitialiseLabels(rpt1);
                                rpt1.SetParameterValue("strBranchName", "Branch:" + mstrBranchName);
                                crystalReportViewer1.ReportSource = rpt1;
                                ShowReport(rpt1, false, "");
                            }
                            else
                            {
                                rptDailyCollection rpt = new rptDailyCollection();
                                rpt1 = (ReportDocument)rpt;
                                rpt1.SetDataSource(odailyColeDetails.ToList());
                                rpt.Subreports[0].SetDataSource(orptCnn.mGetDailyCollection(strComID, strFdate, strTdate, strBranchID, Utility.gstrUserName, "BN", intSalesColl, strFdate, intSummDetails).ToList());
                                rpt.Subreports[1].SetDataSource(orptCnn.mGetDailyCollection(strComID, strTdate, strTdate, strBranchID, Utility.gstrUserName, strSelction, intSalesColl, strFdate, intSummDetails).ToList());
                                this.reportTitle = strHeading;
                                this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                                InitialiseLabels(rpt1);
                                rpt1.SetParameterValue("strBranchName", "Branch:" + mstrBranchName);
                                crystalReportViewer1.ReportSource = rpt1;
                                ShowReport(rpt1, false, "");
                            }
                        }

                        break;
                    #endregion
                    #region "ContractParty Bill"
                    case ViewerSelector.ContactPartyBill:
                        List<RAccountsGroup> ocontactPartyBill = orptCnn.mGetContractsPartBill(strComID, strFdate, strTdate, strBranchID, strString).ToList();
                        if (ocontactPartyBill.Count > 0)
                        {
                            rptContactPartyBill rpt = new rptContactPartyBill();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(ocontactPartyBill.ToList());
                            this.reportTitle = strHeading + "-" + Convert.ToDateTime(strFdate).ToString("yyyy");
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }

                        break;

                    case ViewerSelector.ContactPartyBill2:
                        List<RAccountsGroup> ocontactPartyBill2 = orptCnn.mGetContractsPartBill2(strComID, strFdate, strTdate, strBranchID, strString).ToList();
                        if (ocontactPartyBill2.Count > 0)
                        {

                            rptContactPartyBill2 rpt = new rptContactPartyBill2();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(ocontactPartyBill2.ToList());
                            this.reportTitle = strHeading + "-" + Convert.ToDateTime(strFdate).ToString("yyyy");
                            this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            rpt1.SetParameterValue("mstrBranchName", "Branch :" + mstrBranchName);
                            rpt1.SetParameterValue("intSP", intSP);
                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "Post Dated checque"

                    case ViewerSelector.PostDateCheque:
                        List<RAccountsGroup> rptPostDatedCheque = orptCnn.mGetPostDateCheque(strComID, strFdate, strTdate, strSelction, strString).ToList();
                        if (rptPostDatedCheque.Count > 0)
                        {
                            rptPost_Dated_Cheque rpt = new rptPost_Dated_Cheque();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(rptPostDatedCheque.ToList());
                            this.reportTitle = strHeading;
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "Balance Sheet"
                    case ViewerSelector.BalanceSheet:
                        double dblLia = 0, dblAssets = 0;
                        double dblClosing = objWoIS.gGetDebtorAmount(strComID, "Sundry Debetors", 3, 0, dteFdate.ToString("dd-MM-yyyy"), dteTdate.ToString("dd-MM-yyyy"));
                        //double dblClosing = objWoIS.gGetDebtorAmount(strComID, dteFdate.ToString("dd-MM-yyyy"), dteTdate.ToString("dd-MM-yyyy"),"");
                        int oStock = orptCnn.mGetBalanceSheet(strComID, dteFdate, dteTdate, intHor_ver, dblClosing);
                        if (oStock == 1)
                        {
                            List<RAccountsGroup> oliabilities = orptCnn.mGetBalanceSheetQuery(strComID, 1).ToList();
                            List<RAccountsGroup> oAssets = orptCnn.mGetBalanceSheetQuery(strComID, 2).ToList();
                            rptBalanceSheet rpt = new rptBalanceSheet();
                            rpt1 = (ReportDocument)rpt;
                            foreach (RAccountsGroup objLia in oliabilities)
                            {
                                dblLia = dblLia + objLia.dblAmount;
                            }
                            foreach (RAccountsGroup objAssets in oAssets)
                            {
                                dblAssets = dblAssets + (objAssets.dblAmount);
                            }
                            rpt.Subreports[0].SetDataSource(oliabilities);
                            rpt.Subreports[1].SetDataSource(oAssets);
                            this.reportTitle = "Balancesheet as at";
                            this.secondParameter = dteTdate.ToString("dd-MM-yyyy");
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            rpt1.SetParameterValue("LiaTotal", dblLia);
                            rpt1.SetParameterValue("AssetTotal", dblAssets);
                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "Profit Loss"
                    case ViewerSelector.ProfitLoss:
                        double dblProfit = 0, dblLoss = 0;
                        int oProfit = orptCnn.mGetProfitLoss(strComID, dteFdate, dteTdate, "", intHor_ver);
                        if (oProfit == 1)
                        {
                            if (intHor_ver == 1)
                            {
                                List<RAccountsGroup> ocProfit = orptCnn.mGetProfitLossQuerry(strComID, 4).ToList();
                                List<RAccountsGroup> oLoss = orptCnn.mGetProfitLossQuerry(strComID, 3).ToList();

                                rptProfitLoss rpt = new rptProfitLoss();
                                rpt1 = (ReportDocument)rpt;
                                foreach (RAccountsGroup objprofit in ocProfit)
                                {
                                    dblProfit = dblProfit + objprofit.dblAmount;
                                }
                                foreach (RAccountsGroup objLoss in oLoss)
                                {
                                    dblLoss = dblLoss + (objLoss.dblAmount);
                                }

                                rpt.Subreports[0].SetDataSource(ocProfit);
                                rpt.Subreports[1].SetDataSource(oLoss);
                                this.reportTitle = "Profit & Loss Accounts";
                                this.secondParameter = dteFdate.ToString("dd-MM-yyyy") + " to " + dteTdate.ToString("dd-MM-yyyy");
                                InitialiseLabels(rpt1);
                                crystalReportViewer1.ReportSource = rpt1;
                                rpt1.SetParameterValue("ProfitTotal", dblProfit);
                                rpt1.SetParameterValue("LossTotal", dblLoss);
                            }
                            else
                            {
                                rptProfitLoss_V rpt = new rptProfitLoss_V();
                                rpt1 = (ReportDocument)rpt;
                                List<RAccountsGroup> ocProfit = orptCnn.mGetProfitLossQuerry(strComID, 0).ToList();
                                this.reportTitle = "Profit & Loss Accounts";
                                this.secondParameter = dteFdate.ToString("dd-MM-yyyy") + " to " + dteTdate.ToString("dd-MM-yyyy");
                                InitialiseLabels(rpt1);
                                crystalReportViewer1.ReportSource = rpt1;
                            }
                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "Tral Balance"
                    case ViewerSelector.TrailBalance:

                        double dblDr = 0, dblCr = 0;
                        List<RAccountsGroup> oTBal = orptCnn.mGetTrailBalance(strComID, dteFdate, dteTdate, intNarration).ToList();
                        if (oTBal.Count > 0)
                        {
                            // 1 opn +tran +cls 2 opn +tra 3 +opn+cls tran +cls 4 5 opn 6 tra 7 cls
                            foreach (RAccountsGroup oo in oTBal)
                            {
                                dblDr = dblDr + oo.dblDr;
                                dblCr = dblCr + oo.dblCr;
                            }
                            if (intSummDetails == 1)
                            {
                                rptTrailBalance rpt = new rptTrailBalance();
                                rpt1 = (ReportDocument)rpt;
                            }
                            else if (intSummDetails == 2)
                            {
                                rptTrailBalance_opn_tran rpt = new rptTrailBalance_opn_tran();
                                rpt1 = (ReportDocument)rpt;
                            }
                            else if (intSummDetails == 3)
                            {
                                rptTrailBalance_opn_cls rpt = new rptTrailBalance_opn_cls();
                                rpt1 = (ReportDocument)rpt;
                            }
                            else if (intSummDetails == 4)
                            {
                                rptTrailBalance_tran_cls rpt = new rptTrailBalance_tran_cls();
                                rpt1 = (ReportDocument)rpt;
                            }
                            else if (intSummDetails == 5)
                            {
                                rptTrailBalanceOpn rpt = new rptTrailBalanceOpn();
                                rpt1 = (ReportDocument)rpt;
                            }
                            else if (intSummDetails == 6)
                            {
                                rptTrailBalanceTransaction rpt = new rptTrailBalanceTransaction();
                                rpt1 = (ReportDocument)rpt;
                            }
                            else if (intSummDetails == 7)
                            {
                                rptTrailBalance_cls rpt = new rptTrailBalance_cls();
                                rpt1 = (ReportDocument)rpt;
                            }
                            else
                            {
                                rptTrailBalance rpt = new rptTrailBalance();
                                rpt1 = (ReportDocument)rpt;
                            }
                            rpt1.SetDataSource(orptCnn.mGetTrailBalanceQuery(strComID).ToList());

                            if (intNarration == 0)
                            {
                                this.reportTitle = "Trail Balance(Group Wise)";
                            }
                            else
                            {
                                this.reportTitle = "Trail Balance(Ledger Wise)";
                            }
                            this.secondParameter = dteFdate.ToString("dd-MM-yyyy") + " to" + dteTdate.ToString("dd-MM-yyyy");
                            InitialiseLabels(rpt1);

                            crystalReportViewer1.ReportSource = rpt1;
                            rpt1.SetParameterValue("ONCODE", dblDr);
                            rpt1.SetParameterValue("CRCODE", dblCr);
                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "Accounts Voucher"
                    case ViewerSelector.AccountsVoucher:

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

                            if (intSummDetails == 1)
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
                                goto kk;
                            }
                            if (intSummDetails == 2)
                            {
                                rptAccountsVoucher rptAccountsVoucher = new rptAccountsVoucher();
                                rpt1 = (ReportDocument)rptAccountsVoucher;
                            }
                            else
                            {
                                rptAccountsVoucherSumm rptAccountsVoucherSumm = new rptAccountsVoucherSumm();
                                rpt1 = (ReportDocument)rptAccountsVoucherSumm;
                            }
                        kk:
                            rpt1.SetDataSource(orptCnn.mGetAccountsvoucher(strComID, strFdate, strTdate, intVtype, intSummDetails, strString, strBranchID, intSP).ToList());

                            if (strHeading != "")
                            {
                                this.reportTitle = strHeading;
                            }
                            else
                            {
                                this.reportTitle = "";
                            }



                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
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
                            //rpt1.SetParameterValue("strHeaderr5", Header5);
                            //rpt1.SetParameterValue("dblPasesize", dblPasesize);
                            ShowReport(rpt1, false, "");
                        }
                        break;
                    #endregion
                    #region "Doctors Receipt"
                    case ViewerSelector.DoctorsReceipt:

                        List<RAudit> otheadingD = orptCnn.mGetHeader(strComID, intVtype).ToList();
                        if (otheadingD.Count > 0)
                        {
                            foreach (RAudit oo in otheadingD)
                            {
                                Header1 = oo.strHeader1;
                                Header2 = oo.strHeader2;
                                Header3 = oo.strHeader3;
                                Header4 = oo.strHeader4;
                                Header5 = oo.strHeader5;
                                dblPasesize = oo.dblPazeSize;
                            }
                            List<RAccountsGroup> oAccDoctorvoucher = orptCnn.mGetAccountsDoctotorvoucher(strComID, strString).ToList();
                            if (oAccDoctorvoucher.Count > 0)
                            {
                                rptAccounts_Doctor_Voucher rpt = new rptAccounts_Doctor_Voucher();
                                rpt1 = (ReportDocument)rpt;
                                rpt1.SetDataSource(oAccDoctorvoucher.ToList());
                                this.reportTitle = "Receipt Voucher";
                                //this.secondParameter = strFdate + " to " + strTdate;
                                InitialiseLabels(rpt1);
                                rpt1.SetParameterValue("strHeaderr1", Header1);
                                rpt1.SetParameterValue("strHeaderr2", Header2);
                                rpt1.SetParameterValue("strHeaderr3", Header3);
                                rpt1.SetParameterValue("strHeaderr4", Header4);
                                crystalReportViewer1.ReportSource = rpt1;
                                ShowReport(rpt1, false, "");
                            }
                        }
                        break;
                    #endregion
                    #region "JVSP"
                    case ViewerSelector.JVSP:
                        List<RAudit> otheading1 = orptCnn.mGetHeader(strComID, intVtype).ToList();
                        if (otheading1.Count > 0)
                        {
                            foreach (RAudit oo in otheading1)
                            {
                                Header1 = oo.strHeader1;
                                Header2 = oo.strHeader2;
                                Header3 = oo.strHeader3;
                                Header4 = oo.strHeader4;
                                Header5 = oo.strHeader5;
                                dblPasesize = oo.dblPazeSize;

                            }
                        }
                        rptAccountsVoucherSP rptAccountsVoucherSP = new rptAccountsVoucherSP();
                        rpt1 = (ReportDocument)rptAccountsVoucherSP;

                        rpt1.SetDataSource(orptCnn.mGetAccountsvoucherSP(strComID, intVtype, intSummDetails, strString, strBranchID, strFdate, strTdate, strPMonthID).ToList());
                        this.reportTitle = strHeading;

                        this.secondParameter = "";
                        InitialiseLabels(rpt1);
                        crystalReportViewer1.ReportSource = rpt1;
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

                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region "Accounts voucher"
                    case ViewerSelector.AccountsVoucherMR:
                        rptAccountsVoucherMR rptAccountsVoucherMR = new rptAccountsVoucherMR();
                        rpt1 = (ReportDocument)rptAccountsVoucherMR;
                        if (strHeading != "")
                        {
                            this.reportTitle = strHeading;
                        }
                        else
                        {
                            this.reportTitle = "";
                        }
                        rpt1.SetDataSource(orptCnn.mGetMR(strComID, strString, intVtype).ToList());

                        if (strString == "")
                        {
                            this.secondParameter = strFdate + " to " + strTdate;
                        }
                        else
                        {
                            this.secondParameter = "";
                        }

                        InitialiseLabels(rpt1);
                        rpt1.SetParameterValue("strCompanyname", Utility.gstrCompanyName); ;
                        crystalReportViewer1.ReportSource = rpt1;


                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region "Ledger"
                    case ViewerSelector.Ledger:
                        string strBarnchName = "";
                        List<RAccountsGroup> oAccvou = objWoIS.RefreshLedger(strComID, strFdate, strTdate, strString, strBranchID, strSelction, intSalesColl).ToList();
                        if (oAccvou.Count > 0)
                        {
                            if (intSP > 0)
                            {
                                rptLedgerRunningBal rptLedger = new rptLedgerRunningBal();
                                rpt1 = (ReportDocument)rptLedger;
                                if (intSummDetails == 1)
                                {
                                    this.reportHeading = strHeading;

                                }
                                else
                                {
                                    this.reportHeading = strHeading;

                                }
                            }
                            else
                            {
                                if (intSummDetails == 1)
                                {
                                    rptLedger rptLedger = new rptLedger();
                                    rpt1 = (ReportDocument)rptLedger;
                                    this.reportHeading = strHeading;

                                }
                                else if (intSummDetails == 2)
                                {
                                    rptLedgerSumm rptLedger = new rptLedgerSumm();
                                    rpt1 = (ReportDocument)rptLedger;
                                    this.reportHeading = strHeading;

                                }

                                else
                                {
                                    rptLedgerMonthlySumm rptLedger = new rptLedgerMonthlySumm();
                                    rpt1 = (ReportDocument)rptLedger;
                                    this.reportHeading = strHeading;


                                }
                            }


                            rpt1.SetDataSource(oAccvou.ToList());

                            //this.reportTitle = strHeading;
                            if (strBranchID != "")
                            {
                                strBarnchName = Utility.gstrGetBranchName(strComID, strBranchID);
                                this.reportTitle = "Branch : " + strBarnchName;
                            }
                            else
                            {
                                this.reportTitle = strHeading;
                            }
                            this.secondParameter = strFdate + " to " + strTdate; ;
                            InitialiseLabels(rpt1);


                            crystalReportViewer1.ReportSource = rpt1;

                            rpt1.SetParameterValue("openingDr", oAccvou[0].dblOpeningDr);
                            rpt1.SetParameterValue("openingCr", oAccvou[0].dblOpeningCr);
                            rpt1.SetParameterValue("OpeningAndDebit", oAccvou[0].OpeningAndDebit);
                            rpt1.SetParameterValue("OpeningAndCredit", oAccvou[0].OpeningAndCredit);
                            rpt1.SetParameterValue("OpenDrPlusDebit", oAccvou[0].ClosingDr);
                            rpt1.SetParameterValue("OpenCrPlusCredit", oAccvou[0].ClosingCr);
                            if (intNarration == 1)
                            {
                                rpt1.SetParameterValue("intSuppress", 0);
                            }
                            else
                            {
                                rpt1.SetParameterValue("intSuppress", 1);
                            }
                            rpt1.SetParameterValue("intSignatory", intSignatory);

                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "DayBook"
                    case ViewerSelector.Daybook:

                        List<RAccountsGroup> oAccDaybook = orptCnn.mReportDayBookDetails(strComID, strFdate, strTdate, strSelction, strString, strBranchID).ToList();
                        if (oAccDaybook.Count > 0)
                        {
                            if (intSummDetails == 1)
                            {
                                rptDayBookSumm rptLedger = new rptDayBookSumm();
                                rpt1 = (ReportDocument)rptLedger;
                            }
                            else
                            {
                                rptDayBook rptLedger = new rptDayBook();
                                rpt1 = (ReportDocument)rptLedger;
                            }
                            rpt1.SetDataSource(oAccDaybook.ToList());
                            if (intSummDetails == 1)
                            {
                                this.reportTitle = "Day Book (Summarry)";
                            }
                            else
                            {
                                this.reportTitle = "Day Book (Details)";
                            }
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            if (intNarration == 1)
                            {
                                rpt1.SetParameterValue("intSuppress", 0);
                            }
                            else
                            {
                                rpt1.SetParameterValue("intSuppress", 1);
                            }
                            rpt1.SetParameterValue("intSignatory", intSignatory);
                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "Group"
                    case ViewerSelector.Group:
                        List<RAccountsGroup> oGrp = orptCnn.GroupSummaryReport(strComID, strFdate, strTdate, strSelction, strString, strBranchID, intSP).ToList();
                        if (oGrp.Count > 0)
                        {
                            //1 =opn + tran +clos
                            //2 opn +tran;3 opn + clos;4 tran + opn;5 tran + cls,6 =cls + opn,7 cls + tran, 8 =opn, 9 tran 10 cls;;
                            if (intSummDetails == 1)
                            {
                                rptGroupSumm rptGroupSumm = new rptGroupSumm();
                                rpt1 = (ReportDocument)rptGroupSumm;
                            }
                            else if (intSummDetails == 2)
                            {
                                rptGroupSummOpn_Tran rptGroupSumm = new rptGroupSummOpn_Tran();
                                rpt1 = (ReportDocument)rptGroupSumm;
                            }
                            else if (intSummDetails == 3)
                            {
                                rptGroupSumm_Opn_Cls rptGroupSumm = new rptGroupSumm_Opn_Cls();
                                rpt1 = (ReportDocument)rptGroupSumm;
                            }
                            else if (intSummDetails == 4)
                            {
                                rptGroupSumm_Tran_cls rptGroupSumm = new rptGroupSumm_Tran_cls();
                                rpt1 = (ReportDocument)rptGroupSumm;
                            }
                            else if (intSummDetails == 5)
                            {
                                rptGroupSumm_Tran_cls rptGroupSumm = new rptGroupSumm_Tran_cls();
                                rpt1 = (ReportDocument)rptGroupSumm;
                            }
                            else if (intSummDetails == 6)
                            {
                                rptGroupSumm_cls_opn rptGroupSumm = new rptGroupSumm_cls_opn();
                                rpt1 = (ReportDocument)rptGroupSumm;
                            }
                            else if (intSummDetails == 7)
                            {
                                rptGroupSumm_Cls_tran rptGroupSumm = new rptGroupSumm_Cls_tran();
                                rpt1 = (ReportDocument)rptGroupSumm;
                            }

                            else if (intSummDetails == 8)
                            {
                                rptGroupSummOpn rptGroupSumm = new rptGroupSummOpn();
                                rpt1 = (ReportDocument)rptGroupSumm;
                            }
                            else if (intSummDetails == 9)
                            {
                                rptGroupSummTran rptGroupSumm = new rptGroupSummTran();
                                rpt1 = (ReportDocument)rptGroupSumm;
                            }
                            else if (intSummDetails == 10)
                            {
                                rptGroupSummCls rptGroupSumm = new rptGroupSummCls();
                                rpt1 = (ReportDocument)rptGroupSumm;
                            }
                            else
                            {
                                rptGroupSumm rptGroupSumm = new rptGroupSumm();
                                rpt1 = (ReportDocument)rptGroupSumm;
                            }
                            rpt1.SetDataSource(oGrp.ToList());
                            this.reportTitle = strHeading;
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            rpt1.SetParameterValue("CLDR", oGrp[0].dblDr);
                            rpt1.SetParameterValue("CLCR", oGrp[0].dblCr);
                            //rpt1.SetParameterValue("suppress", intSP);
                            if (intSummDetails == 1)
                            {
                                rpt1.SetParameterValue("strString", strString);
                            }

                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "Receipt Payment"
                    case ViewerSelector.ReceiptPayment:
                        double dblReceipt = 0, dblPayment = 0;
                        int i = orptCnn.mReceiptPayment(strComID, dteFdate, dteTdate);
                        if (i > 0)
                        {
                            List<RAccountsGroup> orecipt = orptCnn.mReceiptPaymentQyery(strComID, 2).ToList();
                            List<RAccountsGroup> opayment = orptCnn.mReceiptPaymentQyery(strComID, 1).ToList();
                            rptReceipePayment rpt = new rptReceipePayment();
                            rpt1 = (ReportDocument)rpt;

                            foreach (RAccountsGroup objReceipt in orecipt)
                            {
                                dblReceipt = dblReceipt + objReceipt.dblAmount;
                            }
                            foreach (RAccountsGroup oboPayment in opayment)
                            {
                                dblPayment = dblPayment + (oboPayment.dblAmount);
                            }

                            rpt.Subreports[0].SetDataSource(orecipt);
                            rpt.Subreports[1].SetDataSource(opayment);

                            this.reportTitle = "Receipt & Payment";
                            this.secondParameter = dteFdate.ToString("dd-MM-yyyy") + " to " + dteTdate.ToString("dd-MM-yyyy");
                            InitialiseLabels(rpt1);


                            //rpt1.Subreports[1].Name.ToString();

                            crystalReportViewer1.ReportSource = rpt1;
                            rpt1.SetParameterValue("inttextsup", intSuppress);
                            rpt1.SetParameterValue("TotalReceipt", dblReceipt);
                            rpt1.SetParameterValue("TotalPayment", dblPayment);
                            rpt1.SetParameterValue("suppress", intSummDetails, rpt.Subreports[0].Name);
                            rpt1.SetParameterValue("suppress", intSummDetails, rpt.Subreports[1].Name);


                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "Cash Flow"
                    case ViewerSelector.CashFlow:

                        List<RAccountsGroup> oCashFlow = orptCnn.mCashFlow(strComID, strFdate, strTdate).ToList();
                        if (oCashFlow.Count > 0)
                        {

                            rptCashFlow rptCashFlow = new rptCashFlow();
                            rpt1 = (ReportDocument)rptCashFlow;
                            rptCashFlow.SetDataSource(oCashFlow.ToList());
                            this.reportTitle = "Cash Flow Statement";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            if (intSummDetails == 1)
                            {
                                rpt1.SetParameterValue("intSuppress", intSummDetails);
                            }
                            else
                            {
                                rpt1.SetParameterValue("intSuppress", intSummDetails);
                            }
                            rpt1.SetParameterValue("CBank", oCashFlow[0].dblBankOpn);
                            rpt1.SetParameterValue("CCash", oCashFlow[0].dblCashOpn);
                            rpt1.SetParameterValue("COD", oCashFlow[0].dblOdopn);
                            ShowReport(rpt1, false, "");
                        }
                        break;
                    #endregion
                    #region "Trading"
                    case ViewerSelector.Trading:
                        double dblPurchase = 0, dblSales = 0;

                        int oTrading = orptCnn.RefreshTradingNew(strComID, dteFdate, dteTdate, "", 4, intSummDetails);
                        if (oTrading == 1)
                        {
                            List<RAccountsGroup> opurchase = orptCnn.mTradingQuery(strComID, 3.50F).ToList();
                            List<RAccountsGroup> oSales = orptCnn.mTradingQuery(strComID, 5.0F).ToList();
                            if (intHor_ver == 1)
                            {
                                rptTrading rpt = new rptTrading();
                                rpt1 = (ReportDocument)rpt;
                                foreach (RAccountsGroup objopurchase in opurchase)
                                {
                                    dblPurchase = dblPurchase + (objopurchase.dblAmount);
                                }
                                foreach (RAccountsGroup oboSales in oSales)
                                {
                                    dblSales = dblSales + (oboSales.dblAmount);
                                }
                                rpt.Subreports[0].SetDataSource(opurchase);
                                rpt.Subreports[1].SetDataSource(oSales);
                                this.reportTitle = "Trading Account";
                                this.secondParameter = dteFdate.ToString("dd-MM-yyyy") + " to " + dteTdate.ToString("dd-MM-yyyy");
                                InitialiseLabels(rpt1);
                                crystalReportViewer1.ReportSource = rpt1;
                                rpt1.SetParameterValue("PurchaseTotal", dblPurchase);
                                rpt1.SetParameterValue("SalesTotal", dblSales);
                            }
                            else
                            {
                                List<RAccountsGroup> overtical = orptCnn.mTradingQueryVertical(strComID, 0).ToList();
                                rptTradingV rpt = new rptTradingV();
                                rpt1 = (ReportDocument)rpt;
                                rpt.SetDataSource(overtical.ToList());
                                this.reportTitle = "Trading Account";
                                this.secondParameter = dteFdate.ToString("dd-MM-yyyy") + " to " + dteTdate.ToString("dd-MM-yyyy");
                                InitialiseLabels(rpt1);
                                crystalReportViewer1.ReportSource = rpt1;
                                rpt1.SetParameterValue("GP", 0);
                            }



                            ShowReport(rpt1, false, "");
                        }
                        break;
                    #endregion
                    #region "Cost Center Ledger"
                    case ViewerSelector.CostCenterLedger:

                        List<RAccountsGroup> oCostCenterLedger = orptCnn.GetCostCenterLedger(strComID, strFdate, strTdate, strBranchID, strString).ToList();
                        if (oCostCenterLedger.Count > 0)
                        {
                            rptCostCenterLedger rpt = new rptCostCenterLedger();
                            rpt1 = (ReportDocument)rpt;
                            rpt.SetDataSource(oCostCenterLedger.ToList());
                            this.reportTitle = strHeading;
                            if (strBranchID == "")
                            {
                                this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");

                            }
                            InitialiseLabels(rpt1);
                            rpt1.SetParameterValue("CostCenterName", strString);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        break;
                    #endregion
                    #region "Cost Category"

                    case ViewerSelector.CostCategory:

                        List<RAccountsGroup> oCostCostCategory = objWoIS.GetCostCategoryReport(strComID, strFdate, strTdate, strBranchID, strString).ToList();
                        if (oCostCostCategory.Count > 0)
                        {
                            rptCostCategory rpt = new rptCostCategory();
                            rpt1 = (ReportDocument)rpt;
                            rpt.SetDataSource(oCostCostCategory.ToList());
                            this.reportTitle = strHeading;
                            if (strBranchID == "")
                            {
                                this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");

                            }
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        break;

                    case ViewerSelector.CostCenter:

                        List<RAccountsGroup> oCostCostcenter = orptCnn.GetCostCenterReport(strComID, strFdate, strTdate, strBranchID, strString, 0).ToList();
                        if (intSummDetails == 0)
                        {
                            rptCostCenter rpt = new rptCostCenter();
                            rpt1 = (ReportDocument)rpt;
                            rpt.SetDataSource(oCostCostcenter.ToList());
                        }
                        else
                        {
                            rptCostCenterSumm rpt = new rptCostCenterSumm();
                            rpt1 = (ReportDocument)rpt;
                            rpt.SetDataSource(oCostCostcenter.ToList());
                        }

                        this.reportTitle = strHeading;
                        this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                        InitialiseLabels(rpt1);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region "Manufacruring"
                    case ViewerSelector.Manufacturing:

                        double dblmanu = orptCnn.dblManufacturing(strComID, strFdate, strTdate, strBranchID);
                        if (dblmanu != 0)
                        {
                            rptManuFactureing rpt = new rptManuFactureing();
                            rpt1 = (ReportDocument)rpt;
                            rpt.Subreports[0].SetDataSource(orptCnn.mManufacturing(strComID, "1.5").ToList());
                            rpt.Subreports[1].SetDataSource(orptCnn.mManufacturing(strComID, "1").ToList());
                            rpt.Subreports[2].SetDataSource(orptCnn.mManufacturing(strComID, "2").ToList());
                            this.reportTitle = "Manufacturing A/C";
                            this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                            InitialiseLabels(rpt1);

                            crystalReportViewer1.ReportSource = rpt1;
                            rpt1.SetParameterValue("FactoryCost", dblmanu);
                            ShowReport(rpt1, false, "");
                        }
                        break;
                    #endregion
                    #region"cheque"
                    case ViewerSelector.Cheque:
                        List<RAccountsGroup> pcheque = orptCnn.getrptChequePayment(strComID, strFdate, strTdate, intSP).ToList();
                        rptAcc_Cheque_Payment_details rptAcc_Cheque_Payment_details = new rptAcc_Cheque_Payment_details();
                        rpt1 = (ReportDocument)rptAcc_Cheque_Payment_details;
                        rpt1.SetDataSource(pcheque.ToList());
                        this.reportTitle = "Cheque Payment for the Date of ";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "SP"
                    case ViewerSelector.SP:
                        List<RAccountsGroup> oSP = objWoIS.GetrptSPCommission(strComID, strFdate, strTdate).ToList();
                        rptSPCommission rptSPCommission = new rptSPCommission();
                        rpt1 = (ReportDocument)rptSPCommission;
                        rpt1.SetDataSource(oSP.ToList());
                        this.reportTitle = "MPO Commission ";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "TargetAchievement"
                    case ViewerSelector.TargetAchievement:
                        {
                            if (intSalesColl == 0)
                            {

                                List<RAccountsGroup> otarget = orptCnn.GetrptCollectionTargetAchieve(strComID, strBranchID, strSelction, strString, strFdate, strTdate, strSalesFdate, strSalesTdate,
                                                intSummDetails, intNarration, Utility.gstrUserName, intTarget).ToList();
                                if (intTargetSuppress == 0)
                                {
                                    if (intSP == 1)
                                    {
                                        rptSalesTarget_Coll_Incentive rptSalesTarget_Coll_Incentive = new rptSalesTarget_Coll_Incentive();
                                        rpt1 = (ReportDocument)rptSalesTarget_Coll_Incentive;
                                    }
                                    else if (intSP == 2)
                                    {
                                        rptSalesTarget_Coll_Incentive_Zone rptSalesTarget_Coll_Incentive = new rptSalesTarget_Coll_Incentive_Zone();
                                        rpt1 = (ReportDocument)rptSalesTarget_Coll_Incentive;
                                    }
                                    else if (intSP == 3)
                                    {
                                        rptSalesTarget_Coll_Incentive_Division rptSalesTarget_Coll_Incentive = new rptSalesTarget_Coll_Incentive_Division();
                                        rpt1 = (ReportDocument)rptSalesTarget_Coll_Incentive;
                                    }
                                    else if (intSP == 4)
                                    {
                                        rptSalesTarget_Coll_Incentive_Area rptSalesTarget_Coll_Incentive = new rptSalesTarget_Coll_Incentive_Area();
                                        rpt1 = (ReportDocument)rptSalesTarget_Coll_Incentive;
                                    }
                                    else
                                    {

                                        rptSalesTarget_Coll_Incentive rptSalesTarget_Coll_Incentive = new rptSalesTarget_Coll_Incentive();
                                        rpt1 = (ReportDocument)rptSalesTarget_Coll_Incentive;
                                    }
                                }
                                else
                                {
                                    if (intSP == 1)
                                    {
                                        rptSalesCollection rptSalesCollection = new rptSalesCollection();
                                        rpt1 = (ReportDocument)rptSalesCollection;
                                    }
                                    else if (intSP == 2)
                                    {
                                        rptSalesCollectionZone rptSalesCollection = new rptSalesCollectionZone();
                                        rpt1 = (ReportDocument)rptSalesCollection;

                                    }
                                    else if (intSP == 3)
                                    {
                                        rptSalesCollectionDivision rptSalesCollection = new rptSalesCollectionDivision();
                                        rpt1 = (ReportDocument)rptSalesCollection;

                                    }
                                    else if (intSP == 4)
                                    {
                                        rptSalesCollectionArea rptSalesCollection = new rptSalesCollectionArea();
                                        rpt1 = (ReportDocument)rptSalesCollection;
                                    }
                                    else
                                    {
                                        rptSalesCollection rptSalesCollection = new rptSalesCollection();
                                        rpt1 = (ReportDocument)rptSalesCollection;
                                    }
                                }
                                rpt1.SetDataSource(otarget.ToList());

                            }
                            else
                            {


                                List<RAccountsGroup> otarget = orptCnn.GetrptSalesCollection(strComID, strBranchID, strString, strFdate, strTdate, intSP,
                                                            intNarration, intSummDetails, Utility.gstrUserName).ToList();
                                if (intSP == 1)
                                {
                                    rptCollectionReceiptLedger rptCollectionReceiptLedgerWise = new rptCollectionReceiptLedger();
                                    rpt1 = (ReportDocument)rptCollectionReceiptLedgerWise;
                                }
                                else if (intSP == 2)
                                {
                                    rptCollectionReceiptLedgerZone rptCollectionReceiptLedgerZone = new rptCollectionReceiptLedgerZone();
                                    rpt1 = (ReportDocument)rptCollectionReceiptLedgerZone;
                                }
                                else if (intSP == 3)
                                {
                                    rptCollectionReceiptLedgerDivision rptCollectionReceiptLedgerDivision = new rptCollectionReceiptLedgerDivision();
                                    rpt1 = (ReportDocument)rptCollectionReceiptLedgerDivision;
                                }
                                else if (intSP == 4)
                                {
                                    rptCollectionReceiptLedgerArea rptCollectionReceiptLedgerArea = new rptCollectionReceiptLedgerArea();
                                    rpt1 = (ReportDocument)rptCollectionReceiptLedgerArea;
                                }
                                else if (intSP == 5)
                                {
                                    rptCollectionReceiptLedgerZone rptCollectionReceiptLedgerArea = new rptCollectionReceiptLedgerZone();
                                    rpt1 = (ReportDocument)rptCollectionReceiptLedgerArea;
                                }
                                else
                                {
                                    if (intSummDetails == 1)
                                    {
                                        if (strString != "")
                                        {
                                            if (strString.Substring(0, 1).ToUpper() == "D" || strString.Substring(0, 1).ToUpper() == "R")
                                            {
                                                rptCollectionReceiptLedgerDivision rptCollectionReceiptLedgerDivision = new rptCollectionReceiptLedgerDivision();
                                                rpt1 = (ReportDocument)rptCollectionReceiptLedgerDivision;
                                            }
                                            else if (strString.Contains("ZONE") == true)
                                            {
                                                rptCollectionReceiptLedgerZone rptCollectionReceiptLedgerZone = new rptCollectionReceiptLedgerZone();
                                                rpt1 = (ReportDocument)rptCollectionReceiptLedgerZone;
                                            }
                                            else
                                            {
                                                rptCollectionReceiptLedgerArea rptCollectionReceiptLedgerArea = new rptCollectionReceiptLedgerArea();
                                                rpt1 = (ReportDocument)rptCollectionReceiptLedgerArea;
                                            }
                                        }
                                        else
                                        {
                                            rptCollectionReceiptLedgerArea rptCollectionReceiptLedgerArea = new rptCollectionReceiptLedgerArea();
                                            rpt1 = (ReportDocument)rptCollectionReceiptLedgerArea;
                                        }
                                    }

                                    else
                                    {
                                        rptCollectionReceiptLedger rptCollectionReceiptLedgerWise = new rptCollectionReceiptLedger();
                                        rpt1 = (ReportDocument)rptCollectionReceiptLedgerWise;
                                    }
                                }
                                rpt1.SetDataSource(otarget.ToList());

                            }
                            if (intTargetSuppress == 0)
                            {
                                if (intSalesColl == 0)
                                {

                                    this.reportTitle = "Sales & Collection Achievement  ";
                                }
                                else
                                {
                                    this.reportTitle = "Sales & Collection Statement ";
                                }
                            }
                            else
                            {
                                this.reportTitle = "Sales & Collection Achievement  ";
                            }
                            if (strSalesFdate == "")
                            {
                                this.secondParameter = strFdate + " to " + strTdate;
                            }
                            else
                            {
                                this.secondParameter = "(Sales : " + strSalesFdate + " to" + strSalesTdate + ") (Collection" + strFdate + " to " + strTdate + ")";
                            }

                            InitialiseLabels(rpt1);
                            if ((intSP == 5) || (intSP == 2))
                            {
                                rpt1.SetParameterValue("intHeadName", intSP);
                            }
                            rpt1.SetParameterValue("suppress", intSuppress);
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        break;
                    #endregion
                    #region "Expense Summ"
                    case ViewerSelector.ExpenseSumm:
                        List<RAccountsGroup> oExpSumm = orptCnn.GetrptExpenseSummary(strComID, strFdate, strTdate, intSummDetails).ToList();
                        if (intSummDetails == 0)
                        {
                            rptExpenseSummary rptExpenseSummary = new rptExpenseSummary();
                            rpt1 = (ReportDocument)rptExpenseSummary;
                        }
                        else
                        {
                            rptExpenseSummaryDetails rptExpenseSummary = new rptExpenseSummaryDetails();
                            rpt1 = (ReportDocument)rptExpenseSummary;
                        }
                        rpt1.SetDataSource(oExpSumm.ToList());
                        this.reportTitle = "Payment Summary ";
                        this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                        InitialiseLabels(rpt1);
                        string strBackYear = "";
                        double dblBalanceBF = 0, dblBalanceBF1 = 0, dblCashReceived = 0, dblBanlReceived = 0, dblBanlReceivedFac = 0, dblOthersCashRv = 0, dblTotalHead = 0, dblTotalFac = 0;
                        if (intSummDetails == 0)
                        {
                            strBackYear = Convert.ToDateTime(strFdate).ToString("MMMM-yyyy");
                            dblBalanceBF = Utility.gGetdblLedgerClosingBalance(strComID, strFdate, strTdate, "Cash Of Head Office", "");
                            dblBalanceBF1 = Utility.gGetdblLedgerClosingBalance(strComID, strFdate, strTdate, "Cash In Hand Factory", "");
                        }
                        else
                        {
                            strBackYear = Convert.ToDateTime(strFdate).ToString("MMMM-yyyy");
                            dblBalanceBF = Utility.gGetdblLedgerClosingBalance(strComID, strFdate, strTdate, "Cash Of Head Office", "");
                            dblBalanceBF1 = Math.Abs(Utility.gGetdblLedgerClosingBalance(strComID, strFdate, strTdate, "Cash In Hand Factory", ""));
                        }

                        dblCashReceived = Utility.gdblCasReceivedfrommpo(strComID, "Cash Of Head Office", (int)Utility.VOUCHER_TYPE.vtRECEIPT_VOUCHER, strFdate, strTdate);
                        //dblBanlReceived = Utility.gdblExpneseBank(strComID, (int)Utility.GR_GROUP_TYPE.grBANKACCOUNTS, strFdate, strTdate);
                        dblBanlReceived = Utility.gdblCasReceivedfrommpo(strComID, "Cash Of Head Office", (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER, strFdate, strTdate);
                        dblBanlReceivedFac = Utility.gdblCasReceivedfrommpo(strComID, "Cash In Hand Factory", (int)Utility.VOUCHER_TYPE.vtCONTRA_VOUCHER, strFdate, strTdate);
                        dblOthersCashRv = Utility.gdblCasReceivedfromOthers(strComID, "Cash Of Head Office", (int)Utility.VOUCHER_TYPE.vtJOURNAL_VOUCHER, strFdate, strTdate);

                        if (intSummDetails == 1)
                        {
                            dblTotalHead = Utility.gdblDisplayTemp(strComID, "Cash Of Head Office");
                            dblTotalFac = Utility.gdblDisplayTemp(strComID, "Cash In Hand Factory");
                            rpt1.SetParameterValue("dblTotalHeadBalance", dblTotalHead);
                            rpt1.SetParameterValue("dblTotalFactoryBalance", dblTotalFac);
                        }

                        rpt1.SetParameterValue("HEAD1", "Cash Of Head Office Opening (" + strBackYear + ")");
                        rpt1.SetParameterValue("HEAD2", "Cash In Hand Factory Opening(" + strBackYear + ")");
                        rpt1.SetParameterValue("CashReceived", dblCashReceived);
                        rpt1.SetParameterValue("ChequeReceived", dblBanlReceived);
                        rpt1.SetParameterValue("ChequeReceivedFactory", dblBanlReceivedFac);
                        rpt1.SetParameterValue("BalanceBF", dblBalanceBF);
                        rpt1.SetParameterValue("BalanceBF1", dblBalanceBF1);
                        rpt1.SetParameterValue("PreMontYear", strBackYear);
                        rpt1.SetParameterValue("OthersRv", dblOthersCashRv);
                        rpt1.SetParameterValue("CurrentMonthYear", "(" + strFdate + " to " + strTdate + ")");

                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "Fixed Asset"
                    case ViewerSelector.FixedAsset:
                        List<RFixedAsset> oFixedAssets;
                        DateTime dtePrevidate = Convert.ToDateTime(Utility.gdteFinancialYearFrom);


                        if (strSelction == "R")
                        {
                            oFixedAssets = orptCnn.mUpdateReducingBalance(strComID, dteFdate, dteTdate).ToList();
                        }
                        else
                        {
                            oFixedAssets = orptCnn.mUpdateStraightLine(strComID, dteFdate, dteTdate, dtePrevidate).ToList();
                        }
                        if (strString == "G")
                        {
                            rptFixed_Asset_Group rptFixed_Asset_Group = new rptFixed_Asset_Group();
                            rpt1 = (ReportDocument)rptFixed_Asset_Group;
                        }
                        else
                        {
                            rptFixed_Asset_Ledger rptFixed_Asset_Group = new rptFixed_Asset_Ledger();
                            rpt1 = (ReportDocument)rptFixed_Asset_Group;
                        }
                        this.reportTitle = strHeading;
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        this.reportTitle = strHeading;
                        rpt1.SetDataSource(oFixedAssets.ToList());
                        rpt1.SetParameterValue("FdayYear", strFdate);
                        rpt1.SetParameterValue("LdayYear", strTdate);
                        crystalReportViewer1.ReportSource = rpt1;

                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region "Cheque Print"
                    case ViewerSelector.Chequeprint:
                        List<RAccountsGroup> oChequePrint = orptCnn.mGetChequePrint(strComID, intVtype, strString, strSelction).ToList();
                        if (oChequePrint.Count > 0)
                        {
                            DateTime datevale = Convert.ToDateTime(DateTime.Today.ToString("dd-MM-yyyy"));
                            if (intNarration == 1)
                            {
                                rptChequePrint_Horizontal rpt = new rptChequePrint_Horizontal();
                                rpt1 = (ReportDocument)rpt;
                                rpt1.SetDataSource(oChequePrint.ToList());
                                crystalReportViewer1.ReportSource = rpt1;
                                rpt1.SetParameterValue("Salef", strSelf);
                                rpt1.SetParameterValue("Amount", dblAmount);
                                rpt1.SetParameterValue("cDate", datevale);
                                ShowReport(rpt1, false, "");
                            }
                            else
                            {
                                rptChequePrint_Vertical rpt = new rptChequePrint_Vertical();
                                rpt1 = (ReportDocument)rpt;
                                rpt1.SetDataSource(oChequePrint.ToList());
                                crystalReportViewer1.ReportSource = rpt1;
                                rpt1.SetParameterValue("Salef", strSelf);
                                rpt1.SetParameterValue("Amount", dblAmount);
                                rpt1.SetParameterValue("cDate", datevale);
                                ShowReport(rpt1, false, "");
                            }
                        }

                        break;
                    #endregion
                    #region "Statistics"
                    case ViewerSelector.Statistics:
                        rptStatistics rptMpoListLedgerWAll1 = new rptStatistics();
                        rpt1 = (ReportDocument)rptMpoListLedgerWAll1;
                        this.reportTitle = "Statistics ";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orptCnn.mGetStatistics(strComID, strFdate, strTdate).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "Audit"
                    case ViewerSelector.Audit:
                        List<RAudit> oAudit = orptCnn.mGetAudit(strComID, strFdate, strTdate, intVtype, strString, intSP).ToList();
                        if (oAudit.Count > 0)
                        {
                            rptAudit rptAudit = new rptAudit();
                            rpt1 = (ReportDocument)rptAudit;
                            this.reportTitle = strHeading;
                            this.secondParameter = strFdate + " to " + strTdate;
                            rpt1.SetDataSource(oAudit.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            InitialiseLabels(rpt1);
                            rpt1.SetParameterValue("intSuppress", intNarration);
                            rpt1.SetParameterValue("strUserName", "User Name : " + strString);
                            ShowReport(rpt1, false, "");
                            break;
                        }
                        break;
                    #endregion
                    #region "Final StatementCustomer"
                    case ViewerSelector.FinalStatementCustomer:

                        List<RFinalStatement> oFinalStateCustomer = objWoIS.mGetFinalStattemnetCustomer(strComID, strFdate, strTdate, strBranchID, strSelction, strString, intNarration, strString2, strString3).ToList();
                        if (oFinalStateCustomer.Count > 0)
                        {
                            strMonth = "For the Month of " + Convert.ToDateTime(strFdate).ToString("MMMMyyyy");
                            strBranchName = Utility.gstrGetBranchName(strComID, strBranchID);
                            rptFinal_statement_report_Customer rpt = new rptFinal_statement_report_Customer();
                            rpt1 = (ReportDocument)rpt;
                            rpt1.SetDataSource(oFinalStateCustomer.ToList());
                            this.reportTitle = "Final Statement ";
                            this.secondParameter = strFdate + " to " + strTdate;
                            this.ReportHeading = "Branch : " + mstrBranchName;
                            InitialiseLabels(rpt1);
                            crystalReportViewer1.ReportSource = rpt1;
                            rpt1.SetParameterValue("date", strFdate + " to " + strTdate);
                            rpt1.SetParameterValue("MonthID", strMonth);
                            ShowReport(rpt1, false, "");
                        }

                        break;
                    #endregion
                    #region "Profit Loss Ledger"
                    case ViewerSelector.ProfitLossLedger:
                        int ivv = orptCnn.gintProfitLossLedger(strComID, dteFdate, dteTdate, strBranchID, (int)Utility.glngBusinessType, 0);
                        break;
                    #endregion

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
        #region "ShowReport"
        private void ShowReport(CrystalDecisions.CrystalReports.Engine.ReportDocument rpt, Boolean isDirectPrint, string strReportTitle = "")
        {
            if (isDirectPrint == true)
            {
                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                rpt.PrintToPrinter(1, false, 0, 0);
            }
            else
            {
                //InitialiseParameterLabels(rpt, strReportTitle);
                this.Show();
            }

        }
        #endregion

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }




    }
}
