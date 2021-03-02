using CrystalDecisions.CrystalReports.Engine;
using Dutility;
using ExtraReports.EXTRA;
using ExtraReports.Projection.Reports.RProjection.ReportUI;
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

namespace ExtraReports.Projection.Reports.RProjection.Viewer
{
    public partial class frmReportViewer : Form
    {
        EXTRA.SWPRJClient objExtra = new EXTRA.SWPRJClient(); 
        private string strComID { get; set; }
        private String reportTitle = "";
        private String secondParameter = "";
        private String reportHeading = "";
        public ViewerSelector selector;
        public string strProjectionName { get; set; }
        public string strFdate = "";
        public string strTdate= "";
        public string strledgerName = "";
        public string strString1 = "", strString2="";
        public int intmode { get; set; }
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

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
             ReportDocument rpt1;
             try
             {
                 switch (selector)
                 {
                     case ViewerSelector.Performance:
                         //double dblFineRecAmount = 0;
                         List<Mprojection> objPerformance = objExtra.mQueryPerformance(strComID).ToList();
                         if (objPerformance.Count > 0)
                         {

                             rptPerformance rptPerformance = new rptPerformance();
                             rpt1 = (ReportDocument)rptPerformance;
                             rpt1.SetDataSource(objPerformance.ToList());
                             this.reportTitle = "Sales Performance";
                             this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyy");
                             InitialiseLabels(rpt1);
                         
                             crystalReportViewer1.ReportSource = rpt1;
                             ShowReport(rpt1, false, "");
                         }
                         break;

                     case ViewerSelector.ProjectionR:

                         List<PCollectionCopmarison> oProjection = objExtra.mGetProjectionStarEndDate(strComID, strString1, "").ToList();
                         if (oProjection.Count > 0)
                         {
                             foreach (PCollectionCopmarison oo in oProjection)
                             {
                                 strProjectionName = oo.strProjectionName;

                                 List<PCollectionCopmarison> oLedger = objExtra.mGetMontlyLadgerProjection(strComID, strString1, strledgerName).ToList();
                                 if (oLedger.Count > 0)
                                 {
                                     foreach (PCollectionCopmarison ooL in oLedger)
                                     {
                                         //string strledgerName = ooL.strLedgerName;
                                         List<PCollectionCopmarison> objPerfo = objExtra.mGetProjectionReport(strComID, strProjectionName, strString1, strString2, intmode, ooL.strLedgerName).ToList();
                                         intmode = intmode + 1;
                                     }
                                 }
                             }
                         }

                         List<PCollectionCopmarison> objProjection = objExtra.mGetCollectionComparision(strComID, "", "").ToList();
                         if (objProjection.Count > 0)
                         {

                             rptCollectionComparision rptCollectionComparision = new rptCollectionComparision();
                             rpt1 = (ReportDocument)rptCollectionComparision;
                             rpt1.SetDataSource(objProjection.ToList());
                             this.reportTitle = "Projection Report";
                             InitialiseLabels(rpt1);
                             rpt1.SetParameterValue("MonthYY", "Month :" + strString1);
                             crystalReportViewer1.ReportSource = rpt1;
                             ShowReport(rpt1, false, "");
                         }

                         break;





                     case ViewerSelector.CollectionComparision:
                         string strSdate = "";
                         string strEdate = "";

                         List<PCollectionCopmarison> otheading22 = objExtra.mGetProjectionStarEndDate(strComID, strString1, "").ToList();
                         if (otheading22.Count > 0)
                         {
                             foreach (PCollectionCopmarison oo in otheading22)
                             {

                                 strEdate = strString1;

                                 strProjectionName = oo.strProjectionName;

                                 List<PCollectionCopmarison> oLedger = objExtra.mGetMontlyLadger(strComID, strString1, strledgerName).ToList();
                                 if (oLedger.Count > 0)
                                 {
                                     foreach (PCollectionCopmarison ooL in oLedger)
                                     {
                                         //string strledgerName = ooL.strLedgerName;
                                         List<PCollectionCopmarison> objPerfo = objExtra.mGetCollectionComparisionReport(strComID, strProjectionName, strString1, strString2, intmode, ooL.strLedgerName).ToList();
                                         intmode = intmode + 1;
                                     }
                                 }
                             }
                         }

                         List<PCollectionCopmarison> objColl = objExtra.mGetCollectionComparision(strComID, strSdate, strEdate).ToList();
                         if (objColl.Count > 0)
                         {

                             rptCollectionComparision rptCollectionComparision = new rptCollectionComparision();
                             rpt1 = (ReportDocument)rptCollectionComparision;
                             rpt1.SetDataSource(objColl.ToList());
                             this.reportTitle = "Collection Comparison Report";
                             //this.secondParameter = Convert.ToDateTime(strFdate).ToString("dd-MM-yyy") + " to " + Convert.ToDateTime(strTdate).ToString("dd-MM-yyy");
                             InitialiseLabels(rpt1);
                             rpt1.SetParameterValue("MonthYY", "Month :" + strString1);
                             crystalReportViewer1.ReportSource = rpt1;
                             ShowReport(rpt1, false, "");
                         }

                         break;
                 }
                 
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
             }
        

        }
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

    }
}
