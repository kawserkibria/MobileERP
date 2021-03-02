using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Dutility;
using JA.Modulecontrolar.JRPT;
using JA.Modulecontrolar.JSAPUR;
using JA.Modulecontrolar.UI.DReport.Inventory.ReportUI;
using JA.Modulecontrolar.UI.DReport.Sales.ReportUI;
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

namespace JA.Modulecontrolar.UI.DReport.Sales.Viewer
{
    public partial class frmReportViewer : Form
    {
        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        SPWOIS objWoIS = new SPWOIS();
        JRPT.SWRPTClient orptCnn = new SWRPTClient();
       
        public string strTdate { get; set; }
        public string strString { get; set; }
        public string strString7 { get; set; }
        public string strString2 { get; set; }
        public string strSelction { get; set; }
        public double dblAmount { get; set; }
        public string strBranchId { get; set; }
        public string strString3 { get; set; }
        public string strString4 { get; set; }
        
        private String reportTitle = "";
        public string reportTitle2 { get; set; }
        public String secondParameter = "";
        public String secondParameter1 = "";
        public String strSelction2 = "";
        public string strFdate { get; set; }
        public int intSuppress2 { get; set; }
        public int intStatus { get; set; }
        public int intMode { get; set; }
        private string strComID { get; set; }
        public int intStatusNew { get; set; }
        public int intCheckStatus { get; set; }

        public string strFPreviousdate = "";
        public string strTPreviousdate = "";
        public string strOldComID = "";
        
        public ViewerSelector selector;
        public int intSuppress { get; set; }
        public String ReportTitle { set { reportTitle = value; } get { return reportTitle; } }
        public String ReportSecondParameter { set { secondParameter = value; } get { return secondParameter; } }
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
            //((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyPhone"]).Text = Utility.gstrCompanyPhone;
            ((TextObject)rpt.ReportDefinition.ReportObjects["txtIT"]).Text = Utility.gstrMsg;
            //((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyWeb"]).Text = Utility.gstr;
            if (ReportTitle != null)
            {
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.ReportTitle;
            }

            if (reportTitle2 != null)
            {
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter2"]).Text = this.ReportTitle + '-' + this.secondParameter; ;
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyName2"]).Text = Utility.gstrCompanyName;
            }
            if (ReportSecondParameter != "")
            {
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter"]).Text = this.secondParameter;
            }
            else
            {
                rpt.ReportDefinition.ReportObjects["txtSecondParameter"].ObjectFormat.EnableSuppress = true;
            }
            if (secondParameter1 != "")
            {
                ((TextObject)rpt.ReportDefinition.ReportObjects["TxtBranchName"]).Text = this.secondParameter1;
            }
            if (intSuppress == 1)
            {
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtMponame"]).Text = this.strString;
            }
            if (strSelction2 != "")
            {
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtlegerGroup"]).Text = this.strSelction2;
            }
        }
        #region "Load"
        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            ReportDocument rpt1=new ReportDocument();
            try
            {
               
               
                switch (selector)
                {
                    case ViewerSelector.rptDailyCollectionRV:
                        rptDailyCollectionRV rpt = new rptDailyCollectionRV();
                        rpt1 = (ReportDocument)rpt;
                        rpt1.SetDataSource(objWoIS.mGetDailyCollectionDetails(strComID, strFdate, strTdate, strBranchId, intMode, Utility.gstrUserName, strSelction, intStatusNew, strSelction).ToList());
                        this.reportTitle = "Daily Collection";
                        this.secondParameter = Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                        InitialiseLabels(rpt1);
                        //rpt1.SetParameterValue("strBranchName", "Branch:" + strBranchId);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    #region "TC Wise Sales/Coll"
                    case ViewerSelector.TCSalesCollection:

                        rptTC_Sales_Coll rptTC_Sales_Coll = new rptTC_Sales_Coll();
                        rpt1 = (ReportDocument)rptTC_Sales_Coll;
                        this.reportTitle = "TC Wise Sales/Collection";
                        this.secondParameter = strFdate + " to " + strTdate;
                        rpt1.SetDataSource(objWoIS.GetrptTCWisweSalesCollection(strComID, strBranchId, "", strFdate, strTdate, 0, strString,Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        InitialiseLabels(rpt1);
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region CollectionStatement
                    case ViewerSelector.allMpoCollectionStatement:

                        rptCollectionStatementAll rptSalsStatement = new rptCollectionStatementAll();
                        rpt1 = (ReportDocument)rptSalsStatement;
                        if (dblAmount != 0)
                        {
                            this.reportTitle = "Collection Statement (Amount " + strString2 + " " + dblAmount + ")";
                        }
                        else
                        {
                            this.reportTitle = "Collection Statement. ";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orptCnn.mGetCollectionStatement(strComID, strFdate, strTdate, strBranchId, strString, intMode, Utility.gblnAccessControl,
                                                Utility.gstrUserName, dblAmount, strString2, strString3, intStatusNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        //rpt1.SetParameterValue("BranchName", secondParameter1);
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.CollectionStatementMPO:

                        rptCollectionStatement_All_MPO_Summ rptSalsStatementMpoo = new rptCollectionStatement_All_MPO_Summ();
                        rpt1 = (ReportDocument)rptSalsStatementMpoo;
                        if (dblAmount != 0)
                        {
                            this.reportTitle = "Collection Statement (MPO Wise)(Amount " + strString2 + " " + dblAmount + ")";
                        }
                        else
                        {
                            this.reportTitle = "Collection Statement (MPO Wise)";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orptCnn.mGetCollectionStatement(strComID, strFdate, strTdate, strBranchId, strString, intMode, Utility.gblnAccessControl,
                                            Utility.gstrUserName, dblAmount, strString2, strString3, intStatusNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        //rpt1.SetParameterValue("BranchName", secondParameter1);
                        ShowReport(rpt1, false, "");
                        //}
                        break;

                    case ViewerSelector.CollectionStatementFM:

                        rptCollectionStatement_All_FM_Summ rptSalsStatementFMM = new rptCollectionStatement_All_FM_Summ();
                        rpt1 = (ReportDocument)rptSalsStatementFMM;
                        if (dblAmount != 0)
                        {
                            this.reportTitle = "Collection Statement (AM/FM Wise)(Amount " + strString2 + " " + dblAmount + ")";
                        }
                        else
                        {
                            this.reportTitle = "Collection Statement (AM/FM Wise) ";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orptCnn.mGetCollectionStatement(strComID, strFdate, strTdate, strBranchId, strString, intMode,
                                            Utility.gblnAccessControl, Utility.gstrUserName, dblAmount, strString2, strString3, intStatusNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        //rpt1.SetParameterValue("BranchName", secondParameter1);
                        ShowReport(rpt1, false, "");
                        //}
                        break;

                    case ViewerSelector.CollectionStatementRSM:

                        rptCollectionStatement_All_DSM_Summ rptSalsStatementRsmm = new rptCollectionStatement_All_DSM_Summ();
                        rpt1 = (ReportDocument)rptSalsStatementRsmm;
                        if (dblAmount != 0)
                        {
                            this.reportTitle = "Collection Statement (DSM/RSM Wise)(Amount " + strString2 + " " + dblAmount + ")";
                        }
                        else
                        {
                            this.reportTitle = "Collection Statement (DSM/RSM Wise)";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orptCnn.mGetCollectionStatement(strComID, strFdate, strTdate, strBranchId, strString, intMode, Utility.gblnAccessControl,
                                                Utility.gstrUserName, dblAmount, strString2, strString3, intStatusNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        //rpt1.SetParameterValue("BranchName", secondParameter1);
                        ShowReport(rpt1, false, "");
                        //}
                        break;

                    case ViewerSelector.CollectionStatementZone:

                        rptCollectionStatement_All_Zone_Summ rptSalsStatementZone = new rptCollectionStatement_All_Zone_Summ();
                        rpt1 = (ReportDocument)rptSalsStatementZone;
                        if (dblAmount != 0)
                        {
                            this.reportTitle = "Collection Statement (Zone Wise)(Amount " + strString2 + " " + dblAmount + ")";
                        }
                        else
                        {
                            this.reportTitle = "Collection Statement (Zone Wise)";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orptCnn.mGetCollectionStatement(strComID, strFdate, strTdate, strBranchId, strString, intMode, Utility.gblnAccessControl,
                                            Utility.gstrUserName, dblAmount, strString2, strString3, intStatusNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        //rpt1.SetParameterValue("BranchName", secondParameter1);
                        ShowReport(rpt1, false, "");
                        //}
                        break;

                    case ViewerSelector.CollectionStatementIndividualF:
                        rptCollection_Statement_Ind_MPO rptSalesStateIndi = new rptCollection_Statement_Ind_MPO();
                        rpt1 = (ReportDocument)rptSalesStateIndi;
                        this.reportTitle = "Collection Statement Individual.";
                        this.secondParameter = strFdate + " to " + strTdate;
                        rpt1.SetDataSource(orptCnn.mGetCollectionStatementIndividual(strComID, strFdate, strTdate, strBranchId, strString).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        InitialiseLabels(rpt1);
                        //rpt1.SetParameterValue("BranchName", secondParameter1);
                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region "ProductWiseSalesStatementQty"
                    case ViewerSelector.MpoProductWiseSalesStatementQty:
                        if (intMode <= 4)
                        {
                            rptMpoProductWiseSalesSatementQty rptMpoProductWiseSalesSatementQty = new rptMpoProductWiseSalesSatementQty();
                            rpt1 = (ReportDocument)rptMpoProductWiseSalesSatementQty;
                            this.reportTitle = "Product Sales Analysis";
                            this.secondParameter = strFdate + " to " + strTdate;
                            rpt1.SetDataSource(objWoIS.mGetMpoProductSalesStatementQty(strComID, intMode, strString, strString2, strFdate, strTdate, 
                                                                                        strSelction2,Utility.gblnAccessControl,Utility.gstrUserName).ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            InitialiseLabels(rpt1);
                            ShowReport(rpt1, false, "");
                            break;
                        }

                        else
                        {
                            if (strSelction2 == "V")
                            {
                                rptMpoProductWiseSalesSatementAll_Vartical rptMpoProductWiseSalesSatementQty = new rptMpoProductWiseSalesSatementAll_Vartical();
                                rpt1 = (ReportDocument)rptMpoProductWiseSalesSatementQty;
                            }
                            else
                            {
                                rptMpoProductWiseSalesSatementAll rptMpoProductWiseSalesSatementQty = new rptMpoProductWiseSalesSatementAll();
                                rpt1 = (ReportDocument)rptMpoProductWiseSalesSatementQty;
                            }
                            this.reportTitle = "Product Sales Analysis";
                            this.secondParameter = strFdate + " to " + strTdate;
                            rpt1.SetDataSource(objWoIS.mGetMpoProductSalesStatementQty(strComID, intMode, strString, strString2, strFdate, strTdate, "", Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            InitialiseLabels(rpt1);
                            ShowReport(rpt1, false, "");
                            break;
                        }
                    #endregion
                    #region "Target"

                    case ViewerSelector.Target:
                        if (strSelction == "MC")
                        {
                            rptAllTarget Target = new rptAllTarget();
                            rpt1 = (ReportDocument)Target;
                        }

                        else if (strSelction == "ACTUAL")
                        {
                            rptAllSalesTarget3 Target = new rptAllSalesTarget3();
                            rpt1 = (ReportDocument)Target;
                        }
                        else if (strSelction == "CTN")
                        {
                            rptAllSalesTarget3 Target = new rptAllSalesTarget3();
                            rpt1 = (ReportDocument)Target;
                        }
                        else
                        {
                            rptAllTarget2 Target = new rptAllTarget2();
                            rpt1 = (ReportDocument)Target;
                        }
                        if (strSelction == "CT")
                        {
                            this.reportTitle = "Actual Collection Target";
                        }
                        else if (strSelction == "CTN")
                        {
                            this.reportTitle = "Revised Collection Target";
                        }
                        else if (strSelction == "TA")
                        {
                            this.reportTitle = "Actual Sales Target";
                        }
                        else if (strSelction == "ACTUAL")
                        {
                            this.reportTitle = "Revised Sales Target";
                        }
                        else
                        {
                            this.reportTitle = reportTitle2;
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orptCnn.mDisplayCreditLimitListAll(strComID, strString, strSelction,Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;


                    #endregion
                    #region Mpolist
                    case ViewerSelector.MpoList:
                        rptMpoList MpoList = new rptMpoList();
                        rpt1 = (ReportDocument)MpoList;
                        this.reportTitle = "Territory Code Based MPO List ";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        //rpt1.SetDataSource(orpt.mGetMpoListNew(strComID, strFdate, strTdate, strBranchId, strString, intMode).ToList());
                        rpt1.SetDataSource(objWoIS.mGetMpoListNew(strComID, strFdate, strTdate, strBranchId, strString, intMode, intStatus, "").ToList());
                        rpt1.Subreports[0].SetDataSource(objWoIS.mGetMpoListZone(strComID).ToList());

                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.rptMpoListLedgerWAll:
                        if (strSelction == "Route")
                        {
                            rptMpoList_LedgerRoute rptMpoListLedgerWAll1 = new rptMpoList_LedgerRoute();
                            rpt1 = (ReportDocument)rptMpoListLedgerWAll1;
                        }
                        else
                        {
                            rptMpoList_LedgerW_All rptMpoListLedgerWAll1 = new rptMpoList_LedgerW_All();
                            rpt1 = (ReportDocument)rptMpoListLedgerWAll1;
                        }

                        this.reportTitle = "Territory Code Based MPO List ";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        //rpt1.SetDataSource(orpt.mGetMpoListNew(strComID, strFdate, strTdate, strBranchId, strString, intMode).ToList());
                        if (intSuppress2 == 1)
                        {
                            rpt1.SetDataSource(objWoIS.mGetMpoListNew(strComID, strFdate, strTdate, strBranchId, strString, 10, intStatus, strSelction).ToList());
                        }
                        else
                        {
                            rpt1.SetDataSource(objWoIS.mGetMpoListNew(strComID, strFdate, strTdate, strBranchId, strString, 6, intStatus, "").ToList());
                        }
                        crystalReportViewer1.ReportSource = rpt1;
                        rpt1.SetParameterValue("intSuppres", intSuppress2);
                        ShowReport(rpt1, false, "");
                        break;

                    #endregion
                    #region SalesStatement
                    case ViewerSelector.allMpoSalesStatement:

                        rptSalsStatementAll rptSalsStatementAll = new rptSalsStatementAll();
                        rpt1 = (ReportDocument)rptSalsStatementAll;
                        if (dblAmount != 0)
                        {
                            this.reportTitle = "Sales Statement (Bill Amount " + strString2 + " " + dblAmount + ")";
                        }
                        else
                        {
                            this.reportTitle = "Sales Statement. ";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSalesStatement(strComID, strFdate, strTdate, strBranchId, strString, intMode, Utility.gblnAccessControl, 
                                                Utility.gstrUserName, dblAmount, strString2, strString3,intStatusNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.SalesStatementMPO:

                        rptSalsStatement_All_MPO_Summ rptSalsStatement_All_MPO_Summ = new rptSalsStatement_All_MPO_Summ();
                        rpt1 = (ReportDocument)rptSalsStatement_All_MPO_Summ;
                        if (dblAmount != 0)
                        {
                            this.reportTitle = "Sales Statement (MPO Wise)(Bill Amount " + strString2 + " " + dblAmount + ")";
                        }
                        else
                        {
                            this.reportTitle = "Sales Statement (MPO Wise)";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSalesStatement(strComID, strFdate, strTdate, strBranchId, strString, intMode, Utility.gblnAccessControl, 
                                            Utility.gstrUserName, dblAmount, strString2, strString3,intStatusNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        //}
                        break;

                    case ViewerSelector.SalesStatementFM:

                        rptSalsStatement_All_FM_Summ rptSalsStatement_All_FM_Summ = new rptSalsStatement_All_FM_Summ();
                        rpt1 = (ReportDocument)rptSalsStatement_All_FM_Summ;
                        if (dblAmount != 0)
                        {
                            this.reportTitle = "Sales Statement (AM/FM Wise)(Bill Amount " + strString2 + " " + dblAmount + ")";
                        }
                        else
                        {
                            this.reportTitle = "Sales Statement (AM/FM Wise) ";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSalesStatement(strComID, strFdate, strTdate, strBranchId, strString, intMode, 
                                            Utility.gblnAccessControl, Utility.gstrUserName, dblAmount, strString2, strString3,intStatusNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        //}
                        break;

                    case ViewerSelector.SalesStatementRSM:

                        rptSalsStatement_All_DSM_Summ rptSalsStatement_All_DSM_Summ = new rptSalsStatement_All_DSM_Summ();
                        rpt1 = (ReportDocument)rptSalsStatement_All_DSM_Summ;
                        if (dblAmount != 0)
                        {
                            this.reportTitle = "Sales Statement (DSM/RSM Wise)(Bill Amount " + strString2 + " " + dblAmount + ")";
                        }
                        else
                        {
                            this.reportTitle = "Sales Statement (DSM/RSM Wise)";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSalesStatement(strComID, strFdate, strTdate, strBranchId, strString, intMode, Utility.gblnAccessControl, 
                                                Utility.gstrUserName, dblAmount, strString2, strString3,intStatusNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        //}
                        break;

                    case ViewerSelector.SalesStatementZone:

                        rptSalsStatement_All_Zone_Summ rptSalsStatement_All_Zone_Summ = new rptSalsStatement_All_Zone_Summ();
                        rpt1 = (ReportDocument)rptSalsStatement_All_Zone_Summ;
                        if (dblAmount != 0)
                        {
                            this.reportTitle = "Sales Statement (Zone Wise)(Bill Amount " + strString2 + " " + dblAmount + ")";
                        }
                        else
                        {
                            this.reportTitle = "Sales Statement (Zone Wise)";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSalesStatement(strComID, strFdate, strTdate, strBranchId, strString, intMode, Utility.gblnAccessControl,
                                            Utility.gstrUserName, dblAmount, strString2, strString3,intStatusNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        //}
                        break;

                    case ViewerSelector.SalesStatementIndividualF:
                        rptSales_Statement_Ind_MPO rptSales_Statement_Ind_MPO = new rptSales_Statement_Ind_MPO();
                        rpt1 = (ReportDocument)rptSales_Statement_Ind_MPO;
                        this.reportTitle = "Sales Statement Individual.";
                        this.secondParameter = strFdate + " to " + strTdate;
                        rpt1.SetDataSource(orpt.mGetSalesStatementIndividual(strComID, strFdate, strTdate, strBranchId, strString).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        InitialiseLabels(rpt1);
                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region SalesPrice

                    case ViewerSelector.LevelWise:

                        rptLevel_Wise_Sales rptLevelWiseSales = new rptLevel_Wise_Sales();
                        rpt1 = (ReportDocument)rptLevelWiseSales;
                        this.reportTitle = "Sales Price List (Level Wise)";
                        this.secondParameter = strFdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mDisplayItemGroup(strComID, strString, strFdate, "", intMode).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        //}
                        break;

                    case ViewerSelector.ItemwiseSales:

                        rptItem_Wise_Sales ItemWiseSalesrpt = new rptItem_Wise_Sales();
                        rpt1 = (ReportDocument)ItemWiseSalesrpt;

                        this.reportTitle = "Sales Price List (Item Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mDisplayItemGroup(strComID, strString, strFdate, strTdate, intMode).ToList());
                        //rpt1.SetDataSource(orpt.mGetItemWiseSales(strFdate, strTdate, "", 0).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        //}
                        break;

                    case ViewerSelector.StockGroupSales:

                        rptStockG_Wise_Sales rptStockGWiseSales = new rptStockG_Wise_Sales();
                        rpt1 = (ReportDocument)rptStockGWiseSales;

                        this.reportTitle = "Sales Price List (Group Wise )";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mDisplayItemGroup(strComID, strString, strFdate, strTdate, intMode).ToList());
                        //rpt1.SetDataSource(orpt.mGetItemWiseSales(strFdate, strTdate, "", 0).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        //}
                        break;

                    #endregion
                    #region Product SalesInformaion
                    case ViewerSelector.ProductSalesAllFMSummary:
                        rptProductSales_All_FM_Summary rptProductSalesAllFMSummary = new rptProductSales_All_FM_Summary();
                        rpt1 = (ReportDocument)rptProductSalesAllFMSummary;
                        this.reportTitle = "Product Sales Statement(AM/FM Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWoIS.mGetStatisticalProductSalesSummary(strComID, strFdate, strTdate, strBranchId, intMode, Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.ProductSalesAllRSMSummary:
                        rptProductSales_All_RSM_Summary rptProductSales_All_RSM_Summary = new rptProductSales_All_RSM_Summary();
                        rpt1 = (ReportDocument)rptProductSales_All_RSM_Summary;
                        this.reportTitle = "Product Sales Statement(DSM/RSM Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWoIS.mGetStatisticalProductSalesSummary(strComID, strFdate, strTdate, strBranchId, intMode, Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.ProductSalesAllZONESummary:
                        rptProductSales_All_ZONE_Summary rptProductSales_All_ZONE_Summary = new rptProductSales_All_ZONE_Summary();
                        rpt1 = (ReportDocument)rptProductSales_All_ZONE_Summary;
                        this.reportTitle = "Product Sales Statement Summary (Zone Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWoIS.mGetStatisticalProductSalesSummary(strComID, strFdate, strTdate, strBranchId, intMode, Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.ProductSalesAllMPOSummary:
                        rptProductSales_All_MPO_Summary rptProductSales_All_MPO_Summary = new rptProductSales_All_MPO_Summary();
                        rpt1 = (ReportDocument)rptProductSales_All_MPO_Summary;
                        this.reportTitle = "Product Sales Statement Summary (MPO Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWoIS.mGetStatisticalProductSalesSummary(strComID, strFdate, strTdate, strBranchId, intMode, Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;


                    case ViewerSelector.ProductSalesIndividual:
                        List<RSalesPurchase> oGroup = objWoIS.mGetProductsales(strComID, strFdate, strTdate, strBranchId, strString, strString2, strSelction, intMode, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
                        {
                            if (oGroup.Count > 0)
                            {
                                rptProductSales_All_MPO StockInformation = new rptProductSales_All_MPO();
                                rpt1 = (ReportDocument)StockInformation;
                                this.reportTitle = "Product Sales Statement";
                                this.secondParameter = strFdate + " to " + strTdate;
                                InitialiseLabels(rpt1);
                                rpt1.SetDataSource(oGroup.ToList());
                                crystalReportViewer1.ReportSource = rpt1;
                                ShowReport(rpt1, false, "");
                            }
                            else
                            {
                                //lblName.Text = "Sorry!No Data Found...";
                            }

                            break;

                        }


                    case ViewerSelector.ProductSalesAll:
             
                        if (intMode == 5)
                        {
                            rptProductSales_All_MPO rptProductSalesAll2 = new rptProductSales_All_MPO();
                            rpt1 = (ReportDocument)rptProductSalesAll2;
                            this.reportTitle = "Product Sales Statement";
                        }
                        else
                        {
                            if (intSuppress == 2)
                            {
                                rptProductSales_All_Supp_MPO rptProductSales_All_Supp_MPO = new rptProductSales_All_Supp_MPO();
                                rpt1 = (ReportDocument)rptProductSales_All_Supp_MPO;
                                this.reportTitle = "Product Sales Statement";
                            }
                            else
                            {
                                rptProductSales_All_MPO rptSalesStatementMPO = new rptProductSales_All_MPO();
                                rpt1 = (ReportDocument)rptSalesStatementMPO;
                                this.reportTitle = "Product Sales Statement";
                            }

                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWoIS.mGetProductsales(strComID, strFdate, strTdate, strBranchId, strString, strString2, strSelction, intMode, Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        rpt1.SetParameterValue("userName", Utility.gstrUserName);
                        if (intSuppress != 2)
                        {
                            rpt1.SetParameterValue("refNo", strString7.Replace("'", ""));
                        }
                        //ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.ProductSalesAllFM:
                        rptProductSales_All_FM rptProductSalesAllFM = new rptProductSales_All_FM();
                        rpt1 = (ReportDocument)rptProductSalesAllFM;
                        this.reportTitle = "Product Sales Statement(AM/FM Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWoIS.mGetProductsales(strComID, strFdate, strTdate, strBranchId, strString, strString2, strSelction, intMode, Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.ProductSalesAllZone:
                        rptProductSales_All_Zone rptProductSalesAllZone = new rptProductSales_All_Zone();
                        rpt1 = (ReportDocument)rptProductSalesAllZone;
                        this.reportTitle = "Product Sales Statement(Zone Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWoIS.mGetProductsales(strComID, strFdate, strTdate, strBranchId, strString, strString2, strSelction, intMode, Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.ProductSalesAllRSM:
                        rptProductSales_All_RSM rptSalsStatementRSM = new rptProductSales_All_RSM();
                        rpt1 = (ReportDocument)rptSalsStatementRSM;
                        this.reportTitle = "Product Sales Statement(DSM/RSM Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWoIS.mGetProductsales(strComID, strFdate, strTdate, strBranchId, strString, strString2, strSelction, intMode, Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region DesignationCategory

                    case ViewerSelector.DesignationCategory:
                        {

                            if (intMode == 1)
                            {
                                rptDesignation_Category_ind rptDesignationCategoryind = new rptDesignation_Category_ind();
                                rpt1 = (ReportDocument)rptDesignationCategoryind;
                            }
                            else
                            {
                                rptDesignation_Category rptDesignationCategory = new rptDesignation_Category();
                                rpt1 = (ReportDocument)rptDesignationCategory;
                            }
                            this.reportTitle = "Sales Master Summary";
                            this.reportTitle2 = "None";
                            this.secondParameter = strFdate + " to " + strTdate;
                            rpt1.SetDataSource(objWoIS.mGetDesignationCategory(strComID, strFdate, strTdate, strBranchId, strString, intMode, Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                            InitialiseLabels(rpt1);
                            //rpt1.SetDataSource(oGroup.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");

                            break;
                        }
                    #endregion
                    #region Party Wise Sales Statement

                    case ViewerSelector.PartyWiseS:

                        rptPartyWiseProductSales_All rptPartyWiseProductSalesAll = new rptPartyWiseProductSales_All();
                        rpt1 = (ReportDocument)rptPartyWiseProductSalesAll;

                        this.reportTitle = "MPO Wise Product Sales Statement";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWoIS.mGetPartyWiseS(strComID, strFdate, strTdate, strString, strSelction, Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region "Product Wise Analysis"
                    case ViewerSelector.individualSample:
                        List<RStockInformation> ogrp = (orptCnn.mGetindividualSalpmle(strComID, strString).ToList());
                        rptVoucher_Sales_Chalan_Voucher_Det_SumN rptVoucher_Sales_Chalan_Voucher_Det_Sum = new rptVoucher_Sales_Chalan_Voucher_Det_SumN();
                        rpt1 = (ReportDocument)rptVoucher_Sales_Chalan_Voucher_Det_Sum;
                        this.reportTitle = "Sales Sample";
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(ogrp.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        //string strComNamae =(Utility.gSelectCompanyName);
                        string strCompanyName = Utility.gstrCompanyName;
                        rpt1.SetParameterValue("strCompanyName", strCompanyName);
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.PartyWiseProductWise2:
                        if (intMode == 3)
                        {
                            rptMpoW_ItemW_Details rptPartyWItemWDetails1 = new rptMpoW_ItemW_Details();
                            rpt1 = (ReportDocument)rptPartyWItemWDetails1;
                            //this.reportTitle = "MPO Wise Sales Invoice Analysis With Details";
                            if (strSelction == "16")
                            {
                                this.reportTitle = "MPO Wise Sales Invoice Analysis With Details";
                            }
                            if (strSelction == "15")
                            {
                                this.reportTitle = "MPO Wise Sales Chalan Analysis With Details";
                            }
                            if (strSelction == "13")
                            {
                                this.reportTitle = "MPO Wise Sales Return Analysis With Details";
                            }
                            if (strSelction == "32")
                            {
                                this.reportTitle = "Party Wise Purchase Invoice Analysis With Details";
                            }
                            if (strSelction == "33")
                            {
                                this.reportTitle = "Party Wise Purchase Return Analysis With Details";
                            }
                            this.secondParameter = strFdate + " to " + strTdate;
                            rpt1.SetDataSource(orpt.mGetPartyWiseProductsales2(strComID, strFdate, strTdate, strString, strString2, strSelction, strString3).ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            InitialiseLabels(rpt1);
                            rpt1.SetParameterValue("inSuppress", intSuppress);
                            ShowReport(rpt1, false, "");
                            break;
                        }

                        if (intMode == 2)
                        {
                            rptMpoW_ItemW_Summ rptPartyWItemWDetails1 = new rptMpoW_ItemW_Summ();
                            rpt1 = (ReportDocument)rptPartyWItemWDetails1;
                            //this.reportTitle = "MPO Wise Sales Invoice Analysis With Details";
                            if (strSelction == "16")
                            {
                                this.reportTitle = "MPO Wise Sales Invoice Analysis With Details";
                            }
                            if (strSelction == "15")
                            {
                                this.reportTitle = "MPO Wise Sales Chalan Analysis With Details";
                            }
                            if (strSelction == "13")
                            {
                                this.reportTitle = "MPO Wise Sales Return Analysis With Details";
                            }
                            if (strSelction == "32")
                            {
                                this.reportTitle = "Party Wise Purchase Invoice Analysis With Details";
                            }
                            if (strSelction == "33")
                            {
                                this.reportTitle = "Party Wise Purchase Return Analysis With Details";
                            }
                            this.secondParameter = strFdate + " to " + strTdate;
                            rpt1.SetDataSource(orpt.mGetPartyWiseProductsales2(strComID, strFdate, strTdate, strString, strString2, strSelction, strString3).ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            InitialiseLabels(rpt1);
                            rpt1.SetParameterValue("inSuppress", intSuppress);
                            ShowReport(rpt1, false, "");
                            break;
                        }

                        break;
                    case ViewerSelector.PartyWiseProductWise:
                        if (intMode == 2)
                        {
                            rptMpoW_ItemW_Summ rptMpoWItemWSumm = new rptMpoW_ItemW_Summ();
                            rpt1 = (ReportDocument)rptMpoWItemWSumm;
                            if (strSelction == "16")
                            {
                                this.reportTitle = "MPO Wise Sales Invoice Analysis Product Summary";
                            }
                            if (strSelction == "15")
                            {
                                this.reportTitle = "MPO Wise Sales Chalan Analysis Product Summary";
                            }
                            if (strSelction == "13")
                            {
                                this.reportTitle = "MPO Wise Sales Return Analysis Product Summary";
                            }
                            if (strSelction == "32")
                            {
                                this.reportTitle = "Party Wise Purchase Invoice Analysis Summary";
                            }
                            if (strSelction == "33")
                            {
                                this.reportTitle = "Party Wise Purchase Return Analysis Summary";
                            }
                            this.secondParameter = strFdate + " to " + strTdate;

                            rpt1.SetDataSource(objWoIS.mGetPartyWiseProductsales(strComID, strFdate, strTdate, strString, strString2, strSelction, strString3).ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            InitialiseLabels(rpt1);
                            rpt1.SetParameterValue("inSuppress", intSuppress);
                            rpt1.SetParameterValue("inSuppressProductTotal", intSuppress2);
                            ShowReport(rpt1, false, "");
                            break;
                        }

                        if (intMode == 3)
                        {
                            if (intSuppress == 8)
                            {
                                rptMpoW_ItemW_Details_PartySuppres rptPartyWItemWDetails1 = new rptMpoW_ItemW_Details_PartySuppres();
                                rpt1 = (ReportDocument)rptPartyWItemWDetails1;
                                //this.reportTitle = "MPO Wise Sales Invoice Analysis With Details";
                                if (strSelction == "16")
                                {
                                    this.reportTitle = "MPOwise Sales Invoice Analysis With Product Details";
                                }
                                if (strSelction == "15")
                                {
                                    this.reportTitle = "MPOwise Sales Chalan Analysis With Product Details";
                                }
                                if (strSelction == "13")
                                {
                                    this.reportTitle = "MPOwise Sales Return Analysis With Product Details";
                                }
                                if (strSelction == "32")
                                {
                                    this.reportTitle = "Party Wise Purchase Invoice Analysis With Details";
                                }
                                if (strSelction == "33")
                                {
                                    this.reportTitle = "Party Wise Purchase Return Analysis With Details";
                                }
                                this.secondParameter = strFdate + " to " + strTdate;
                                InitialiseLabels(rpt1);
                                rpt1.SetDataSource(objWoIS.mGetPartyWiseProductsales(strComID, strFdate, strTdate, strString, strString2, strSelction, strString3).ToList());
                                crystalReportViewer1.ReportSource = rpt1;

                                //rpt1.SetParameterValue("inSuppress", 8);
                                ShowReport(rpt1, false, "");
                                break;
                            }
                            if (intSuppress == 9)
                            {
                                rptMpoW_ItemW_Details_ProductSuppres rptPartyWItemWDetails1 = new rptMpoW_ItemW_Details_ProductSuppres();
                                rpt1 = (ReportDocument)rptPartyWItemWDetails1;
                                //this.reportTitle = "MPO Wise Sales Invoice Analysis With Details";
                                if (strSelction == "16")
                                {
                                    this.reportTitle = "MPOwise Sales Invoice Analysis With Product Details";
                                }
                                if (strSelction == "15")
                                {
                                    this.reportTitle = "MPOwise Sales Chalan Analysis With Product Details";
                                }
                                if (strSelction == "13")
                                {
                                    this.reportTitle = "MPOwise Sales Return Analysis With Product Details";
                                }
                                if (strSelction == "32")
                                {
                                    this.reportTitle = "Party Wise Purchase Invoice Analysis With Details";
                                }
                                if (strSelction == "33")
                                {
                                    this.reportTitle = "Party Wise Purchase Return Analysis With Details";
                                }
                                this.secondParameter = strFdate + " to " + strTdate;
                                rpt1.SetDataSource(objWoIS.mGetPartyWiseProductsales(strComID, strFdate, strTdate, strString, strString2, strSelction, strString3).ToList());
                                crystalReportViewer1.ReportSource = rpt1;
                                InitialiseLabels(rpt1);
                                //rpt1.SetParameterValue("inSuppress", 9);
                                ShowReport(rpt1, false, "");
                                break;
                            }
                            if (intSuppress == 10)
                            {
                                rptMpoW_ItemW_Details_AllSuppres rptMpoW_ItemW_Details_AllSuppres = new rptMpoW_ItemW_Details_AllSuppres();
                                rpt1 = (ReportDocument)rptMpoW_ItemW_Details_AllSuppres;
                                //this.reportTitle = "MPO Wise Sales Invoice Analysis With Details";
                                if (strSelction == "16")
                                {
                                    this.reportTitle = "MPOwise Sales Invoice Analysis With Product Details";
                                }
                                if (strSelction == "15")
                                {
                                    this.reportTitle = "MPOwise Sales Chalan Analysis With Product Details";
                                }
                                if (strSelction == "13")
                                {
                                    this.reportTitle = "MPOwise Sales Return Analysis With Product Details";
                                }
                                if (strSelction == "32")
                                {
                                    this.reportTitle = "Party Wise Purchase Invoice Analysis With Details";
                                }
                                if (strSelction == "33")
                                {
                                    this.reportTitle = "Party Wise Purchase Return Analysis With Details";
                                }
                                this.secondParameter = strFdate + " to " + strTdate;
                                rpt1.SetDataSource(objWoIS.mGetPartyWiseProductsales(strComID, strFdate, strTdate, strString, strString2, strSelction, strString3).ToList());
                                crystalReportViewer1.ReportSource = rpt1;
                                InitialiseLabels(rpt1);
                                //rpt1.SetParameterValue("inSuppress", intSuppress);
                                ShowReport(rpt1, false, "");
                                break;
                            }
                            else
                            {
                                //MessageBox.Show(strString.Length.ToString());
                                //MessageBox.Show(strString3.Length.ToString());
                                rptMpoW_ItemW_Details rptPartyWItemWDetails1 = new rptMpoW_ItemW_Details();
                                rpt1 = (ReportDocument)rptPartyWItemWDetails1;
                                //this.reportTitle = "MPO Wise Sales Invoice Analysis With Details";
                                if (strSelction == "16")
                                {
                                    this.reportTitle = "MPOwise Sales Invoice Analysis With Product Details";
                                }
                                if (strSelction == "15")
                                {
                                    this.reportTitle = "MPOwise Sales Chalan Analysis With Product Details";
                                }
                                if (strSelction == "13")
                                {
                                    this.reportTitle = "MPOwise Sales Return Analysis With Product Details";
                                }
                                if (strSelction == "32")
                                {
                                    this.reportTitle = "Party Wise Purchase Invoice Analysis With Details";
                                }
                                if (strSelction == "33")
                                {
                                    this.reportTitle = "Party Wise Purchase Return Analysis With Details";
                                }
                                this.secondParameter = strFdate + " to " + strTdate;
                                rpt1.SetDataSource(objWoIS.mGetPartyWiseProductsales(strComID, strFdate, strTdate, strString, strString2, strSelction, strString3).ToList());
                                crystalReportViewer1.ReportSource = rpt1;
                                InitialiseLabels(rpt1);
                                rpt1.SetParameterValue("inSuppress", intSuppress);
                                //rpt1.SetParameterValue("inSuppress2", intMode);
                                ShowReport(rpt1, false, "");
                                break;
                            }

                        }

                        if (intMode == 6)
                        {
                            rptItemW_MpoW_Details rptItemWMpoWDetails = new rptItemW_MpoW_Details();
                            rpt1 = (ReportDocument)rptItemWMpoWDetails;
                            //this.reportTitle = "Product Sales Analysis With MPO Details";
                            if (strSelction == "16")
                            {
                                this.reportTitle = "Productwise Sales Analysis With MPO Details";
                            }
                            if (strSelction == "15")
                            {
                                this.reportTitle = "Productwise Chalan Analysis With MPO Details";
                            }
                            if (strSelction == "13")
                            {
                                this.reportTitle = "Productwise Return Analysis With MPO Details";
                            }
                            if (strSelction == "32")
                            {
                                this.reportTitle = "Item Wise Return Analysis With Party Details";
                            }
                            if (strSelction == "33")
                            {
                                this.reportTitle = "Item Wise Invoice Analysis With Party Details";
                            }
                            this.secondParameter = strFdate + " to " + strTdate;
                            rpt1.SetDataSource(objWoIS.mGetPartyWiseProductsales(strComID, strFdate, strTdate, strString, strString2, strSelction, strString3).ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            InitialiseLabels(rpt1);
                            rpt1.SetParameterValue("inSuppress", intSuppress);
                            ShowReport(rpt1, false, "");
                            break;
                        }

                        if (intMode == 4)
                        {
                            rptItemW_MpoW_Summ rptItemWMpoWSumm = new rptItemW_MpoW_Summ();
                            rpt1 = (ReportDocument)rptItemWMpoWSumm;
                            //this.reportTitle = "Productwise Sales Analysis (Summary)";
                            if (strSelction == "16")
                            {
                                this.reportTitle = "Productwise Sales Analysis (Summary)";
                            }
                            if (strSelction == "15")
                            {
                                this.reportTitle = "Productwise Sales Chalan Analysis (Summary)";
                            }
                            if (strSelction == "13")
                            {
                                this.reportTitle = "Productwise Sales Return Analysis (Summary)";
                            }
                            if (strSelction == "32")
                            {
                                this.reportTitle = "Item Return Analysis (Summary)";
                            }
                            if (strSelction == "33")
                            {
                                this.reportTitle = "Item Purchase Analysis (Summary)";
                            }
                            this.secondParameter = strFdate + " to " + strTdate;
                            rpt1.SetDataSource(objWoIS.mGetPartyWiseProductsales(strComID, strFdate, strTdate, strString, strString2, strSelction, strString3).ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            InitialiseLabels(rpt1);
                            rpt1.SetParameterValue("inSuppress", intSuppress);
                            ShowReport(rpt1, false, "");
                            break;
                        }

                        if (intMode == 5)
                        {
                            rptMpoW_ItemW_Details rptMpoWItemWDetails = new rptMpoW_ItemW_Details();
                            rpt1 = (ReportDocument)rptMpoWItemWDetails;
                            //this.reportTitle = "MPO Wise Sales Invoice Analysis With Details";
                            if (strSelction == "16")
                            {
                                this.reportTitle = "MPOwise Sales Invoice Analysis With Details";
                            }
                            if (strSelction == "15")
                            {
                                this.reportTitle = "MPOwise Sales Chalan Analysis With Details";
                            }
                            if (strSelction == "13")
                            {
                                this.reportTitle = "MPOwise Sales Return Analysis With Details";
                            }
                            if (strSelction == "32")
                            {
                                this.reportTitle = "Party Wise Purchase Invoice Analysis With Details";
                            }
                            if (strSelction == "33")
                            {
                                this.reportTitle = "Party Wise Purchase Return Analysis With Details";
                            }
                            this.secondParameter = strFdate + " to " + strTdate;
                            rpt1.SetDataSource(orpt.mGetPartyWiseProductsales2(strComID, strFdate, strTdate, strString, strString2, strSelction, strString3).ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            InitialiseLabels(rpt1);
                            rpt1.SetParameterValue("inSuppress", intSuppress);
                            ShowReport(rpt1, false, "");
                            break;
                        }
                        break;

                    #endregion
                    #region Product Short Summary

                    case ViewerSelector.ProductShortSumm:

                        List<RProductSales> ooProductSales = orpt.mGetProductShortSummary(strComID, strFdate, strTdate).ToList();
                        if (ooProductSales.Count > 0)
                        {
                            rptProduct_Short_Summ rptProductShortSumm = new rptProduct_Short_Summ();
                            rpt1 = (ReportDocument)rptProductShortSumm;

                            this.reportTitle = "Short Report Summary";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(ooProductSales.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        break;
                    #endregion
                    #region Product Short Details
                    case ViewerSelector.ProductShortDetails:
                        if (intMode == 1)
                        {
                            rptProduct_Short_Details rptProductShortDetails = new rptProduct_Short_Details();
                            rpt1 = (ReportDocument)rptProductShortDetails;
                        }
                        else
                        {
                            rptProduct_Short_Details2 rptProductShortDetails = new rptProduct_Short_Details2();
                            rpt1 = (ReportDocument)rptProductShortDetails;
                        }

                        this.reportTitle = "Product Short Details";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetProductShortDetails(strComID, strFdate, strTdate, strString, intMode).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region SalesTarget Statement

                    case ViewerSelector.SalesTargetStatement:
                        rptSales_Tar_Statement rptSalesTarStatement = new rptSales_Tar_Statement();
                        rpt1 = (ReportDocument)rptSalesTarStatement;
                        this.reportTitle = "Sales Target Statement";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSalesTargetStatement(strComID, strFdate, strTdate, strBranchId, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region SalesStatementIndividual
                    case ViewerSelector.SalesStatementIndividual:
                        rptSales_Statement_Ind_MPO rptSalsStatementIndividual = new rptSales_Statement_Ind_MPO();
                        rpt1 = (ReportDocument)rptSalsStatementIndividual;
                        this.reportTitle = "Sales Statement";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSalesStatementIndividual(strComID, strFdate, strTdate, strBranchId, strString).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region SalesStatement Pack Size

                    case ViewerSelector.SalesStatementPackSize:

                        rptSalesStat_Pack_Size rptSalesStatPackSize = new rptSalesStat_Pack_Size();
                        rpt1 = (ReportDocument)rptSalesStatPackSize;

                        this.reportTitle = "Product Sales Statement(Pack Size)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWoIS.mGetSalesStatementPackSize(strComID, strFdate, strTdate, strString, intMode, Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region Target Sales Statement Yearly

                    case ViewerSelector.TargetSalesStatementYearly:

                        rptTarget_Sales_State_Yearly rptTargetSalesStateYearly = new rptTarget_Sales_State_Yearly();
                        rpt1 = (ReportDocument)rptTargetSalesStateYearly;

                        this.reportTitle = "Target Sales Statement Yearly";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetTargetSalesStatementYearly(strComID, strBranchId, strString).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region Sales Invoice

                    case ViewerSelector.SalesInvoice:

                        rptSales_Invoice rptSalesInvoice = new rptSales_Invoice();
                        rpt1 = (ReportDocument)rptSalesInvoice;

                        this.reportTitle = "Sales Target Statement";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        if (strString != "")
                        {
                            rpt1.SetDataSource(objWoIS.mGetSalesInvoice(strComID, strString).ToList());
                        }
                        else
                        {
                            rpt1.SetDataSource(objWoIS.mGetSalesInvoice(strComID, strString).ToList());
                        }
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");

                        break;
                    #endregion
                    #region Statistical Product Sales

                    case ViewerSelector.StatisticalProductSales:
                        rptstatistical_product_sales rptstatisticalproductsales = new rptstatistical_product_sales();
                        rpt1 = (ReportDocument)rptstatisticalproductsales;
                        this.reportTitle = "Statistical Product Sales";
                        this.secondParameter = strFdate + " to " + strTdate;
                        //this.secondParameter1 = secondParameter1;  
                        rpt1.SetDataSource(objWoIS.mGetStatisticalProductSales(strComID, strFdate, strTdate, strBranchId, strString, intMode, Utility.gblnAccessControl, Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        InitialiseLabels(rpt1);
                        rpt1.SetParameterValue("intSuppress", intSuppress);
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region SalesChalan
                    case ViewerSelector.SalesChalan:
                       
                        if (intMode == 0)
                        {
                            rptSales_Sample rptSalesChalan = new rptSales_Sample();
                            rpt1 = (ReportDocument)rptSalesChalan;
                            this.reportTitle = "Challan Delivery Report (Sample Class)";
                        }
                        else
                        {
                            rptSales_Chalan rptSalesChalan = new rptSales_Chalan();
                            rpt1 = (ReportDocument)rptSalesChalan;
                            this.reportTitle = "Challan Delivery Report";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        if (strString != "")
                        {
                            //rpt1.SetDataSource(orpt.mGetSalesChalan(strComID, strFdate, strTdate, strBranchId, strString, intMode).ToList());
                            rpt1.SetDataSource(objWoIS.mGetSalesChalan(strComID, strFdate, strTdate, strBranchId, strString, intMode).ToList());
                        }
                        else
                        {
                            rpt1.SetDataSource(objWoIS.mGetSalesChalan(strComID, strFdate, strTdate, strBranchId, strString, intMode).ToList());
                        }
                        crystalReportViewer1.ReportSource = rpt1;
                        rpt1.SetParameterValue("inmode", intMode);
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region ChalanPending
                    case ViewerSelector.ChalanPending:
                        rptChalanPending rptChalanPending = new rptChalanPending();
                        rpt1 = (ReportDocument)rptChalanPending;
                        this.reportTitle = "Challan Pending Report";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetChalanPending(strComID, strFdate, strTdate, strString, intMode).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        //}
                        break;
                    #endregion
                    #region ProductSalesAmpont
                    case ViewerSelector.ProductSalesAmountProduct:
                        rptPartySaleAmountProduct rptPartySaleAmountProduct = new rptPartySaleAmountProduct();
                        rpt1 = (ReportDocument)rptPartySaleAmountProduct;
                        this.reportTitle = "MPO Wise Sales Statement (Product) ";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWoIS.mGetPartyProductSalesAmount(strComID, strBranchId, strFdate, strTdate, strString, strString3, intMode, strString2).ToList());
                        rpt1.SetParameterValue("strBranchName", strString4);
                        rpt1.SetParameterValue("strMpoName", strString3);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    #endregion
                    #region PartySalesAmpont
                    case ViewerSelector.ProductSalesAmount:
                        rptPartySaleAmount rptPartySaleAmount = new rptPartySaleAmount();
                        rpt1 = (ReportDocument)rptPartySaleAmount;
                        this.reportTitle = "MPO Wise Sales Statement (Amount) ";
                        this.secondParameter = strFdate + " to " + strTdate;

                        rpt1.SetDataSource(objWoIS.mGetPartyAmount(strComID, strBranchId, strFdate, strTdate, strString, strSelction, intMode, strString2).ToList());
                        rpt1.SetParameterValue("strBranchName", strString4);
                        rpt1.SetParameterValue("strMpoName", strString3);
                        InitialiseLabels(rpt1);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region SpcialProduct
                    case ViewerSelector.SpcialProduct:
                        rptSpcial_Product_Pro_Wise rptSpcialProductProWise = new rptSpcial_Product_Pro_Wise();
                        rpt1 = (ReportDocument)rptSpcialProductProWise;
                        this.reportTitle = " Product Wise Target Report ";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSpcialProduct(strComID, strFdate, strTdate, strString4, strSelction, strString, strString2, intMode, intMode).ToList());
                        //public List<RProductSales> mGetSpcialProduct(string strDeComID, string strFdate, string strTdate, string strGroupName, string strPartyName, string strProductSelection, int intstatus,int intMode)
                        rpt1.SetParameterValue("strBranchName", strBranchId);
                        rpt1.SetParameterValue("strMpoName", strString3);
                        rpt1.SetParameterValue("strPreMonth", strString4);
                        rpt1.SetParameterValue("secondParameterV", secondParameter);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;


                    #endregion
                    #region SpcialProductPackSizeWise
                    case ViewerSelector.SpcialProductPackSizeWise:
                        rptSpcial_Product_MPO_Wise rptSpcial_Product_MPO_Wise = new rptSpcial_Product_MPO_Wise();
                        rpt1 = (ReportDocument)rptSpcial_Product_MPO_Wise;
                        if (intMode == 2)
                        {
                            this.reportTitle = " Pack Size Wise Sales (Special) ";
                        }
                        else
                        {
                            this.reportTitle = " Product Wise Sales (Special) ";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSpcialProductPackSiseWise(strComID, strFdate, strTdate, strString4, strSelction, strString, strString2, intMode, intMode).ToList());
                        rpt1.SetParameterValue("strBranchName", strBranchId);
                        rpt1.SetParameterValue("strMpoName", strString3);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;


                    #endregion
                    #region SpcialProduct12MonthSales
                    case ViewerSelector.mGetSpcialProduct12MonthSales:
                        DateTime dteMonthDate = Convert.ToDateTime(strFdate);
                        int intmonth = dteMonthDate.Month;
                        List<RProductSales> ooAccLedger = orpt.mGetSpcialProduct12MonthSales(strComID, strFdate, strTdate, intmonth, strSelction, strString, strString2, intMode, intMode).ToList();
                        rptSpcial_Product_Sales rptSpcial_Product_MPO_Wise1 = new rptSpcial_Product_Sales();
                        rpt1 = (ReportDocument)rptSpcial_Product_MPO_Wise1;
                        this.reportTitle = " Product Wise Sales Summary (Special)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(ooAccLedger.ToList());
                        rpt1.SetParameterValue("strBranchName", strBranchId);
                        rpt1.SetParameterValue("strMpoName", strString3);
                        rpt1.SetParameterValue("intMode", intMode);
                        int i;

                        DateTime dteFinancialDate = Convert.ToDateTime(Utility.gdteFinancialYearFrom);

                        //intTotalMonth = intmonth + 11;
                        for (i = 1; i <= 12; i++)
                        {
                            string strM1 = dteMonthDate.ToString("MMMyy");
                            rpt1.SetParameterValue("strM" + i, strM1);
                            dteMonthDate = dteMonthDate.AddMonths(1);
                            //intpvale += 1;
                        }
                        //rpt1.SetParameterValue("secondParameterV", secondParameter);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;


                    #endregion
                    #region "Bkash"
                    case ViewerSelector.BKash:
                        rptBKashList rptBKashList = new rptBKashList();
                        rpt1 = (ReportDocument)rptBKashList;
                        this.reportTitle = "Bkash Eligible MPO List";
                        //this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        //rpt1.SetDataSource(orpt.mGetMpoListNew(strComID, strFdate, strTdate, strBranchId, strString, intMode).ToList());
                        rpt1.SetDataSource(orpt.mGetBkash(strComID).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "12 Month Sales Qty"

                    case ViewerSelector.ProductSales12MonthQty:
                        if (intMode == 1)
                        {
                                rpt12MonthSalesQty_Zone rpt12MonthSalesQty = new rpt12MonthSalesQty_Zone();
                                rpt1 = (ReportDocument)rpt12MonthSalesQty;
                            
                        }
                        else if (intMode == 2)
                        {
                                rpt12MonthSalesQty_Division rpt12MonthSalesQty = new rpt12MonthSalesQty_Division();
                                rpt1 = (ReportDocument)rpt12MonthSalesQty;
                            
                        }
                        else if (intMode == 3)
                        {
                                rpt12MonthSalesQty_AM_FM rpt12MonthSalesQty = new rpt12MonthSalesQty_AM_FM();
                                rpt1 = (ReportDocument)rpt12MonthSalesQty;
                            
                        }
                        else if (intMode == 4)
                        {

                            rpt12MonthSalesQty_MPO rpt12MonthSalesQty = new rpt12MonthSalesQty_MPO();
                            rpt1 = (ReportDocument)rpt12MonthSalesQty;

                        }
                        else
                        {
                            rpt12MonthSalesQty_All rpt12MonthSalesQty = new rpt12MonthSalesQty_All();
                            rpt1 = (ReportDocument)rpt12MonthSalesQty;
                        }

                        this.reportTitle = "Yearly Product wise Sales ";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWoIS.mGetProductSalesStatement12MonthQty(strComID, intMode, strString, strString2, strFdate, strTdate, strString3, intStatus,Utility.gstrUserName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;

                        ShowReport(rpt1, false, "");
                        break;

                    #endregion
                    #region "Sales & Collection Performance"
                    case ViewerSelector.SalesCollectonperformance:
                        if (intSuppress2 == 1)
                        {
                            if (intMode == 5)
                            {
                                rptSales_Collection_Performance_NationalPerfor_All rptMposa = new rptSales_Collection_Performance_NationalPerfor_All();
                                rpt1 = (ReportDocument)rptMposa;
                            }
                            else
                            {
                                rptSales_Collection_Performance_NationalPerfor rptMposa = new rptSales_Collection_Performance_NationalPerfor();
                                rpt1 = (ReportDocument)rptMposa;
                            }
                        }
                        else
                        {
                            if (intMode == 1)
                            {
                                rptSales_Collection_Performance_Zone rptMposa = new rptSales_Collection_Performance_Zone();
                                rpt1 = (ReportDocument)rptMposa;
                            }
                            else if (intMode == 2)
                            {
                                rptSales_Collection_Performance_Division rptMposa = new rptSales_Collection_Performance_Division();
                                rpt1 = (ReportDocument)rptMposa;
                            }
                            else if (intMode == 3)
                            {
                                rptSales_Collection_Performance_Area rptMposa = new rptSales_Collection_Performance_Area();
                                rpt1 = (ReportDocument)rptMposa;
                            }
                            else if (intMode == 4)
                            {
                                rptSales_Collection_Performance_MPO rptMposa = new rptSales_Collection_Performance_MPO();
                                rpt1 = (ReportDocument)rptMposa;
                            }
                            else if (intMode == 5)
                            {
                                rptSales_Collection_Performance_All rptMposa = new rptSales_Collection_Performance_All();
                                rpt1 = (ReportDocument)rptMposa;
                            }
                            else
                            {
                                rptSales_Collection_Performance_All rptMposa = new rptSales_Collection_Performance_All();
                                rpt1 = (ReportDocument)rptMposa;
                            }
                        }
                        this.reportTitle = "Sales & Collection Performance";
                        this.secondParameter = strFdate + " to " + strTdate;

                        string FFdate = Utility.FirstDayOfMonth(Convert.ToDateTime(strFdate)).ToString("dd-MM-yyyy");
                        string TTdate = Utility.LastDayOfMonth(Convert.ToDateTime(strTdate)).ToString("dd-MM-yyyy");

                        DateTime df = Convert.ToDateTime(FFdate);
                        DateTime dT = Convert.ToDateTime(TTdate);

                        long intnoofdays = Utility.DateDiff(Utility.DateInterval.Day, df, dT) + 1;
                        long lonnDays = Utility.DateDiff(Utility.DateInterval.Day, Convert.ToDateTime(strFdate), Convert.ToDateTime(strTdate)) + 1;
                        rpt1.SetDataSource(orpt.mGetSalesCollectionPerformanceRep(strComID, strFdate, strTdate, strBranchId, strString2, intMode, intStatus,
                                                                               Utility.gstrUserName, Convert.ToDateTime(FFdate), Convert.ToDateTime(TTdate), Convert.ToInt32(intnoofdays),
                                                                               Convert.ToInt32(lonnDays), Utility.gstrUserName, intStatusNew,intCheckStatus).ToList());

                        crystalReportViewer1.ReportSource = rpt1;
                        InitialiseLabels(rpt1);

                        rpt1.SetParameterValue("SelectDate", strFdate + " to " + strTdate);
                        rpt1.SetParameterValue("StarOrEndDate", FFdate + " to " + TTdate);
                        ShowReport(rpt1, false, "");
                        break;

                    #endregion
                    #region "Sales Order"
                    case ViewerSelector.SalesOrder:
                        List<RSalesPurchase> objTotal;

                        objTotal = objWoIS.mGetVoucherSalesOrlder(strComID, strFdate, strTdate, strSelction2, strBranchId, intMode, intStatus).ToList();
                        if (intStatus == 1)
                        {
                            rptSales_Order_Details rptVoucher_Pur_Inv_All_Summ2 = new rptSales_Order_Details();
                            rpt1 = (ReportDocument)rptVoucher_Pur_Inv_All_Summ2;
                        }
                        else
                        {
                            rptSales_Order_Summ rptSales_Order_Summ = new rptSales_Order_Summ();
                            rpt1 = (ReportDocument)rptSales_Order_Summ;
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        if (intStatus == 1)
                        {
                            this.reportTitle = "Sales Order (Details)";
                        }
                        else
                        {
                            this.reportTitle = "Sales Order (Summary)";
                        }

                        rpt1.SetDataSource(objTotal.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        InitialiseLabels(rpt1);
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "CPSP Collection Performance"
                    case ViewerSelector.CPSPSalescollPer:

                        rptCPSPYealyCompare rptCPSPYealyCompare = new rptCPSPYealyCompare();
                        rpt1 = (ReportDocument)rptCPSPYealyCompare;

                        this.reportTitle = "CP/SP Yealy Collection Compare";
                        this.secondParameter = strFdate + " to " + strTdate;




                        rpt1.SetDataSource(orpt.mGetCPSPCollectionPerformanceRepYear(strComID, strOldComID, strFPreviousdate, strTPreviousdate, strFdate, strTdate, strBranchId, strString2, intMode, intStatus,
                                                                               Utility.gstrUserName).ToList());


                        crystalReportViewer1.ReportSource = rpt1;
                        InitialiseLabels(rpt1);

                        rpt1.SetParameterValue("SelectDate", strFdate + " to " + strTdate);
                        rpt1.SetParameterValue("StarOrEndDate", strFPreviousdate + " to " + strTPreviousdate);
                        ShowReport(rpt1, false, "");
                        break;

                    #endregion
                    #region "Pending order"
                    case ViewerSelector.Pendingorder:
                        rptPending_Order rptPendingOr = new rptPending_Order();
                        rpt1 = (ReportDocument)rptPendingOr;
                        if (intStatusNew == 2)
                        {
                            rpt1.SetDataSource(orpt.gFillPendingOrder(strComID, strBranchId, strFPreviousdate, intMode, strFdate, strTdate, 2).ToList());
                        }
                        else
                        {
                            rpt1.SetDataSource(orpt.gFillPendingOrder(strComID, strBranchId, strFPreviousdate, intMode, strFdate, strTdate, 1).ToList());
                        }
                        if (intStatusNew == 2)
                        {
                            this.reportTitle = "Pending order";
                        }
                        else
                        {
                            this.reportTitle = "ZH Not Approve (Order)";
                        }
                        this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyyy");
                        InitialiseLabels(rpt1);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
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
                this.Show();
               
            }

        }
        #endregion

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }



     

      

        




    }
}
