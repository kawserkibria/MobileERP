using CrystalDecisions.CrystalReports.Engine;
using Dutility;
using JA.Modulecontrolar.JRPT;
using JA.Modulecontrolar.UI.DReport.Inventory.ReportUI;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JA.Modulecontrolar.UI.DReport.Inventory.Viewer
{
    public partial class frmReportViewer : Form
    {
        JRPT.SWRPTClient orptCnn = new SWRPTClient();
        SPWOIS objWIS = new SPWOIS();
        private string strComID { get; set; }
        private String reportTitle = "";
        private String secondParameter = "";
        public string strGroup { get; set; }
        public string strString5 = "", strString6 = "", strString7 = "";
        public DateTime  dtetdate { get; set; }
        public string strFdate { get; set; }
        public string strTdate { get; set; }
        public string strString { get; set; }
        public string strStringNew { get; set; }
        public string strString2 { get; set; }
        public string strString3 { get; set; }
        public string strUserSecurity { get; set; }
     
        public string strSummDetails { get; set; }
        public string strFromLocation { get; set; }
        public string strToLocation { get; set; }
        public string strSelction { get; set; }
        public string str_S_F_Z { get; set; }
        public string strBranchID { get; set; }
        public int intSuppress { get; set; }
        public int intype { get; set; }
        public int intSorting { get; set; }
        public double dblQty { get; set; }
        public ViewerSelector selector;
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
            ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyName2"]).Text = Utility.gstrCompanyName;
            ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyAddress1"]).Text = Utility.gstrCompanyAddress1;
            ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyAddress2"]).Text = Utility.gstrCompanyAddress2;
            //((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyPhone"]).Text = Utility.gstrCompanyPhone;
            ((TextObject)rpt.ReportDefinition.ReportObjects["txtIT"]).Text = Utility.gstrMsg;
            //((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyWeb"]).Text = Utility.gstr;
            if (strString2 != null)
            {
                ((TextObject)rpt.ReportDefinition.ReportObjects["Textitemname"]).Text = this.strString2;
            }
            if (ReportTitle != "")
            {
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.ReportTitle;
            }
            if (ReportTitle != "")
            {
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter"]).Text = this.secondParameter;
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter2"]).Text = this.ReportTitle + " From  " + this.secondParameter;
            }
            else
            {
                rpt.ReportDefinition.ReportObjects["txtSecondParameter"].ObjectFormat.EnableSuppress = true;
            }

        }
        #region "Load"
        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            ReportDocument rpt1;
            try
            {

                switch (selector)
                {
                    #region "StockSummIPrice"
                    case ViewerSelector.StockIPrice:
                        List<RStockInformation> oStockI;
                        if (strSelction == "I")
                        {
                            //oStockI = objWIS.GetrptIpriceNew(strComID, strFdate, strTdate, strString, "I", intSuppress, strBranchID, strGroup).ToList();
                            oStockI = objWIS.GetrptIpriceNew(strComID, strFdate, strTdate, strString, strBranchID, strString).ToList();
                            rptStockInformation_Opn__Inw_Ootw_Cls_N StockSummI = new rptStockInformation_Opn__Inw_Ootw_Cls_N();
                            rpt1 = (ReportDocument)StockSummI;
                            this.reportTitle = "Stock Summarry Invoice Price";
                        }
                        else
                        {
                            oStockI = objWIS.mItemMasterForvalueN(strComID, strFdate, strTdate, strString, "O", intSuppress, strBranchID, strGroup).ToList();
                            rptStockInformation_Opn__Inw_Ootw_Cls StockSummI = new rptStockInformation_Opn__Inw_Ootw_Cls();
                            rpt1 = (ReportDocument)StockSummI;
                            this.reportTitle = "Stock Summarry Production Value";
                        }

                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oStockI.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "Commisssion"
                    case ViewerSelector.GroupCommissionWithSalesValue:

                        List<RStockInformation> oProductGroupCommWithS = orptCnn.mGetGroupCommissionWithSales(strComID, strFdate, strTdate, strString).ToList();
                        rptGroupCommissionWithValue rptGroupCommissionWithValue = new rptGroupCommissionWithValue();
                        rpt1 = (ReportDocument)rptGroupCommissionWithValue;
                        this.reportTitle = "Group Wise Commission";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oProductGroupCommWithS.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "StockSummSPrice"
                    case ViewerSelector.StockSummSPrice:

                        List<RStockInformation> oLStockSPrice = orptCnn.mgetStockSummarySPriceWise(strComID, strString, intype).ToList();
                        rptStockSumm_S_Price rptStockSumm_S_Price = new rptStockSumm_S_Price();
                        rpt1 = (ReportDocument)rptStockSumm_S_Price;
                        this.reportTitle = "Stock Status (Sales Price)";
                        this.secondParameter = "";
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oLStockSPrice.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "LocationQty"
                    case ViewerSelector.LocationWiseQty:
                        //rpt1.SetDataSource(orptCnn.mItemMaster(strFdate, strTdate, strString, strSelction, intSuppress).ToList());
                        List<RStockInformation> oLocation = objWIS.mGetLocationQty(strComID, strFdate, strTdate, strString, strSelction, intSuppress,strStringNew).ToList();
                        if (intSuppress == 2)
                        {
                            rptLocationWiseQty rptLocationWiseQty = new rptLocationWiseQty();
                            rpt1 = (ReportDocument)rptLocationWiseQty;
                            this.reportTitle = "Stock Summary (Location Wise)";
                        }
                        else
                        {
                            rptLocationWiseItemQty rptLocationWiseQty = new rptLocationWiseItemQty();
                            rpt1 = (ReportDocument)rptLocationWiseQty;
                            this.reportTitle = "Stock Summary (Item Wise)";
                        }

                        this.secondParameter = strFdate + " to " + strTdate ;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oLocation.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "NehetiveStock"
                    case ViewerSelector.NegetiveStock:
                        List<RStockInformation> oNegetive = orptCnn.mGetNegetiveStock(strComID).ToList();
                        rptNegetiveStock rptNegetiveStock = new rptNegetiveStock();
                        rpt1 = (ReportDocument)rptNegetiveStock;
                        this.reportTitle = "Negetive Stock Report";
                        this.secondParameter = "";
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oNegetive.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "BOM LIST"
                    case ViewerSelector.BOMList:
                        List<RStockInformation> oBomList = orptCnn.mGetBOMList(strComID, strString,strSelction).ToList();
                        if (strSelction == "W")
                        {
                            rptBOMListWithAlias rptBomList = new rptBOMListWithAlias();
                            rpt1 = (ReportDocument)rptBomList;
                            this.reportTitle = "With Alias Report";
                        }
                        else if (strSelction == "O")
                        {
                            rptBOMListWithoutAlias rptBomList = new rptBOMListWithoutAlias();
                            rpt1 = (ReportDocument)rptBomList;
                            this.reportTitle = "Without Alias Report";
                        }
                        else
                        {
                            rptBOMListOnlyAlias rptBomList = new rptBOMListOnlyAlias();
                            rpt1 = (ReportDocument)rptBomList;
                            this.reportTitle = "Only Alias Report";
                        }
                        this.secondParameter = strString;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oBomList.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "Slow Fast Moving"
                    case ViewerSelector.SlowFastMoving:
                        List<RStockInformation> oSlowFastMoving = objWIS.mGetSlowFastMoving(strComID, strFdate, strTdate, dtetdate, str_S_F_Z, strSelction, strString).ToList();
                        if (str_S_F_Z != "Z")
                        {
                            //rptZeroMoving
                            rptSlowFastMoving rptSlowFastMoving = new rptSlowFastMoving();
                            rpt1 = (ReportDocument)rptSlowFastMoving;
                            if (str_S_F_Z == "S")
                            {
                                this.reportTitle = "Slow Moving Item List";
                            }
                            else
                            {
                                this.reportTitle = "Fast Moving Item List";
                            }
                        }
                        else
                        {
                            rptZeroMoving rptSlowFastMoving = new rptZeroMoving();
                            rpt1 = (ReportDocument)rptSlowFastMoving;
                            this.reportTitle = "Zero Moving Item List";
                        }
                        this.secondParameter = " as On " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oSlowFastMoving.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "MFG ProcessReport"
                    case ViewerSelector.MFGProcessReport:
                        List<RStockInformation> oMFGProcess = orptCnn.mGetMFGProcessReport(strComID, strString, intype).ToList();
                        if (intype == 1)
                        {
                            rptMFGProcessReport rptMFGProcessReport = new rptMFGProcessReport();
                            rpt1 = (ReportDocument)rptMFGProcessReport;
                            this.secondParameter = "Process- ";
                            this.reportTitle = "MFG Process Report";
                            this.secondParameter = "Process Name : " + strString;
                        }
                        else
                        {

                            rptMFGProcessReportIndi rptMFGProcessReport = new rptMFGProcessReportIndi();
                            rpt1 = (ReportDocument)rptMFGProcessReport;
                            if (intSuppress == 1)
                            {
                                this.reportTitle = "FG to FG Process Report";
                            }
                            else
                            {
                                this.reportTitle = "MFG Process Report";
                            }

                            this.secondParameter = "Process Name : " + strString;

                        }



                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oMFGProcess.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "ProductTopSheetSalesPrice"
                    case ViewerSelector.ProductTopSheetSalesPrice:
                        //List<RStockInformation> oProductTopSheetSP = orptCnn.mGetProductTopSheetSalesPrice(strComID, strFdate, strTdate).ToList();
                        List<RStockInformation> oProductTopSheetSP = objWIS.mGetProductTopSheetSalesPrice(strComID, strFdate, strTdate).ToList();
                        rptProductTopSheetSalesPrice rptProductTopSheetSP = new rptProductTopSheetSalesPrice();
                        rpt1 = (ReportDocument)rptProductTopSheetSP;
                        this.reportTitle = "Finished Product Summary Statement Top Sheet(Sales Price)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oProductTopSheetSP.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "StockRegister"
                    case ViewerSelector.StockRegister:
                        List<RStockInformation> oStockRegister = orptCnn.mGetStockRegister(strComID, strFdate, strTdate, strFromLocation, strToLocation).ToList();
                        rptStockRegister rptStockRegister = new rptStockRegister();
                        rpt1 = (ReportDocument)rptStockRegister;
                        if (strFromLocation == "" && strToLocation == "")
                        {
                            this.reportTitle = "Stock Transfer Report (All)";
                        }
                        else
                        {
                            this.reportTitle = "Stock Transfer Report (Individual)";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oStockRegister.ToList());
                        crystalReportViewer1.ReportSource = rpt1;


                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "GroupCommission"
                    case ViewerSelector.GroupCommission:
                        List<RStockInformation> oProductGroupComm = orptCnn.mGetGroupCommission(strComID, strFdate, strTdate, strString).ToList();
                        rptGroupCommission rptGroupCommission = new rptGroupCommission();
                        rpt1 = (ReportDocument)rptGroupCommission;
                        this.reportTitle = "Group Wise Commission Setting";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oProductGroupComm.ToList());
                        rpt1.Subreports[0].SetDataSource(orptCnn.mGetGroupCommissionSubReport(strComID, strFdate, strTdate).ToList());
                        crystalReportViewer1.ReportSource = rpt1;


                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "ProductStatementCross"
                    case ViewerSelector.ProductStatment:
                        List<RStockInformation> oProductStaCross = orptCnn.mGetProductStatementCross(strComID, strFdate, strTdate, intype).ToList();
                        if (intype == 1)
                        {
                            rptProductStatementRawCross rptProductStatementRawCross = new rptProductStatementRawCross();
                            rpt1 = (ReportDocument)rptProductStatementRawCross;
                            this.reportTitle = "Product Statement (Raw materials)";
                        }
                        else
                        {
                            rptProductStatementProductionCross rptProductStatementRawCross = new rptProductStatementProductionCross();
                            rpt1 = (ReportDocument)rptProductStatementRawCross;
                            this.reportTitle = "Product Statement (Production)";
                        }

                        this.secondParameter = "For the Month of " + Convert.ToDateTime(strFdate).ToString("MMMMM-yyyy");
                        //strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oProductStaCross.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "ProductTopSheet"
                    case ViewerSelector.ProducTopSheet:
                        List<RStockInformation> oProductTopSheet = orptCnn.mGetProductTopSheet(strComID, strFdate, strTdate).ToList();
                        rptProductTopSheet rptProductTopSheet = new rptProductTopSheet();
                        rpt1 = (ReportDocument)rptProductTopSheet;
                        this.reportTitle = "Finished Product Summary Statement Top Sheet";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oProductTopSheet.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "Stock Statmenet/Pack Size"
                    case ViewerSelector.StockStatement:
                        int intPhy = 0;
                        if (strSelction == "S")
                        {
                            intPhy = 1;
                        }
                        else
                        {
                            intPhy = 0;
                        }
                        List<RStockInformation> oStocStatmenet = orptCnn.mGetProductStatement(strComID, strFdate, strTdate, strString, strBranchID, intype, intPhy,intSorting).ToList();
                        if (intype == 1)
                        {
                            if (strSelction == "S")
                            {
                                rptProductSummStockStatement rptStockStatment = new rptProductSummStockStatement();
                                rpt1 = (ReportDocument)rptStockStatment;
                                this.reportTitle = "Product Summarized Stock Statement for Factory";
                            }
                            else
                            {
                                rptProductSummStockStatementSumm rptStockStatment = new rptProductSummStockStatementSumm();
                                rpt1 = (ReportDocument)rptStockStatment;
                                this.reportTitle = "Product Summarized Stock Statement for Factory";
                            }
                        }
                        else
                        {
                            if (strSelction == "Su")
                            {

                                rptPackSizeWiseSumm2 rptPackSizeWiseSumm = new rptPackSizeWiseSumm2();
                                rpt1 = (ReportDocument)rptPackSizeWiseSumm;
                                if (intype==3)
                                {
                                    this.reportTitle = "Power Class Wise Summarized Stock Statement";
                                }
                                else
                                {
                                    this.reportTitle = "Pack Size Wise Summarized Stock Statement";
                                }
                            }
                            else
                            {
                                rptPackSizeWiseSumm rptPackSizeWiseSumm = new rptPackSizeWiseSumm();
                                rpt1 = (ReportDocument)rptPackSizeWiseSumm;
                                this.reportTitle = "Pack Size Wise Summarized Stock Statement";
                            }

                        }

                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oStocStatmenet.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        if (intype == 2)
                        {
                            rpt1.SetParameterValue("pack_power", "Pack Size");
                            if (strSelction == "Su")
                            {
                                rpt1.SetParameterValue("intSuppress", 1);
                            }
                            else
                            {
                                rpt1.SetParameterValue("intSuppress", 0);
                            }
                        }
                        else if (intype == 3)
                        {
                            rpt1.SetParameterValue("pack_power", "Power Class");
                            if (strSelction == "Su")
                            {
                                rpt1.SetParameterValue("intSuppress", 1);
                            }
                            else
                            {
                                rpt1.SetParameterValue("intSuppress", 0);
                            }
                        }
                        else if (intype == 1)
                        {
                            if (strSelction == "Su")
                            {
                                rpt1.SetParameterValue("intSuppress", 1);
                            }
                            else
                            {
                                rpt1.SetParameterValue("intSuppress", 0);
                            }
                        }
                        rpt1.SetParameterValue("userName", Utility.gstrUserName);
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "LocationConsumtion"
                    case ViewerSelector.LocationConsum:


                        List<RStockInformation> oStockCon = orptCnn.mGetLocationWiseConsumtion(strComID, strFdate, strTdate, strString).ToList();
                        if (intype == 1)
                        {
                            rptLocationConsumtion rptLocationConsumtion = new rptLocationConsumtion();
                            rpt1 = (ReportDocument)rptLocationConsumtion;
                            this.reportTitle = "Location Wise Consumption Details";
                        }
                        else
                        {
                            rptLocationConsumtionDetails rptLocationConsumtion = new rptLocationConsumtionDetails();
                            rpt1 = (ReportDocument)rptLocationConsumtion;
                            this.reportTitle = "Location Wise Consumption Summary";
                        }

                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oStockCon.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    //#region "StockSummIPrice"
                    //case ViewerSelector.StockIPrice:
                    //    List<RStockInformation> oStockI;
                    //    if (strSelction == "I")
                    //    {
                    //        oStockI = objWIS.mItemMasterForvalue(strComID, strFdate, strTdate, strString, "I", intSuppress, strBranchID, strGroup).ToList();
                    //        rptStockInformation_Opn__Inw_Ootw_Cls StockSummI = new rptStockInformation_Opn__Inw_Ootw_Cls();
                    //        rpt1 = (ReportDocument)StockSummI;
                    //        this.reportTitle = "Stock Summarry Sales Price";
                    //    }
                    //    else
                    //    {
                    //        oStockI = objWIS.mItemMasterForvalue(strComID, strFdate, strTdate, strString, "O", intSuppress, strBranchID, strGroup).ToList();
                    //        rptStockInformation_Opn__Inw_Ootw_Cls StockSummI = new rptStockInformation_Opn__Inw_Ootw_Cls();
                    //        rpt1 = (ReportDocument)StockSummI;
                    //        this.reportTitle = "Stock Summarry Production Value";
                    //    }

                    //    this.secondParameter = strFdate + " to " + strTdate;
                    //    InitialiseLabels(rpt1);
                    //    rpt1.SetDataSource(oStockI.ToList());
                    //    crystalReportViewer1.ReportSource = rpt1;
                    //    ShowReport(rpt1, false, "");
                    //    break;
                    //#endregion
                    #region "StockSummSalesPrice"
                    case ViewerSelector.StockLevel:
                        List<RStockInformation> oostock = orptCnn.mGetStockSummSalesPrice(strComID, strString, strSelction, intype).ToList();
                        rptStockStatusSalesPrice rptStockStatusSalesPrice = new rptStockStatusSalesPrice();
                        rpt1 = (ReportDocument)rptStockStatusSalesPrice;
                        this.reportTitle = "Stock Status(Sales Price)";
                        this.secondParameter = "";
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oostock.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "Stock Information Group Wise"
                    //****************************Stock**********************************
                    case ViewerSelector.GroupoptionWiseOpnInwOutwCls:
                        if (intype == 1)
                        {
                            List<RStockInformation> oGroupvs = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3,"").ToList();

                            if (oGroupvs.Count > 0)
                            {
                                rptStockInformationGroupValSupp StockInformation = new rptStockInformationGroupValSupp();
                                rpt1 = (ReportDocument)StockInformation;
                                this.reportTitle = "Stock Summary (Groupwise)";
                                this.secondParameter = strFdate + " to " + strTdate;
                                InitialiseLabels(rpt1);
                                rpt1.SetDataSource(oGroupvs.ToList());
                                crystalReportViewer1.ReportSource = rpt1;
                                ShowReport(rpt1, false, ""); ;
                            }
                            else
                            {
                                lblName.Text = "Sorry!No Data Found...";
                            }
                            break;
                        }
                        else
                        {
                            List<RStockInformation> oGroup = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3,"").ToList();

                            if (oGroup.Count > 0)
                            {
                                rptStockInformation_Opn__Inw_Ootw_Cls StockInformation = new rptStockInformation_Opn__Inw_Ootw_Cls();
                                rpt1 = (ReportDocument)StockInformation;
                                this.reportTitle = "Stock Summary (Groupwise)";
                                this.secondParameter = strFdate + " to " + strTdate;
                                InitialiseLabels(rpt1);
                                rpt1.SetDataSource(oGroup.ToList());
                                crystalReportViewer1.ReportSource = rpt1;
                                ShowReport(rpt1, false, ""); ;
                            }
                            else
                            {
                                lblName.Text = "Sorry!No Data Found...";
                            }
                            break;

                        }

                    case ViewerSelector.GroupoptionWiseOpn:
                        List<RStockInformation> oGrpOpn = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (oGrpOpn.Count > 0)
                        {
                            rptStockInformation_Opn rptStockInformationOPN = new rptStockInformation_Opn();
                            rpt1 = (ReportDocument)rptStockInformationOPN;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(oGrpOpn.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;

                    case ViewerSelector.GroupoptionWiseINW:
                        List<RStockInformation> oGrpIW = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (oGrpIW.Count > 0)
                        {
                            rptStockInformation_Inward rptStockInformationINW = new rptStockInformation_Inward();
                            rpt1 = (ReportDocument)rptStockInformationINW;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(oGrpIW.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;

                    case ViewerSelector.GroupoptionWiseOUTW:
                        List<RStockInformation> oGrpO = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (oGrpO.Count > 0)
                        {
                            rptStockInformation_Outw rptStockInformationOUTW = new rptStockInformation_Outw();
                            rpt1 = (ReportDocument)rptStockInformationOUTW;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(oGrpO.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;

                    case ViewerSelector.GroupoptionWiseClos:
                        List<RStockInformation> oCls = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (oCls.Count > 0)
                        {
                            rptStockInformation_Clos rptStockInformationClos = new rptStockInformation_Clos();
                            rpt1 = (ReportDocument)rptStockInformationClos;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(oCls.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;

                    case ViewerSelector.GroupoptionWiseOpnInw:
                        List<RStockInformation> opnClos = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (opnClos.Count > 0)
                        {
                            rptStockInformation_Opn__Inw rptstockinformationOpnInw = new rptStockInformation_Opn__Inw();
                            rpt1 = (ReportDocument)rptstockinformationOpnInw;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(opnClos.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;

                    case ViewerSelector.GroupoptionWiseOpnOutw:
                        List<RStockInformation> opnOut = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (opnOut.Count > 0)
                        {
                            rptStockInformation_Opn__Outw rptstockinformationOpnOutw = new rptStockInformation_Opn__Outw();
                            rpt1 = (ReportDocument)rptstockinformationOpnOutw;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(opnOut.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;
                    case ViewerSelector.GroupoptionWiseOpnCls:
                        List<RStockInformation> opnCls = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (opnCls.Count > 0)
                        {
                            rptStockInformation_Opn__Cls rptstockinformationOpnCls = new rptStockInformation_Opn__Cls();
                            rpt1 = (ReportDocument)rptstockinformationOpnCls;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(opnCls.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;

                    case ViewerSelector.GroupoptionWiseInwOotw:
                        List<RStockInformation> opnInwOut = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (opnInwOut.Count > 0)
                        {
                            rptStockInformation_Inw_Outw rptstockinformationInwOutw = new rptStockInformation_Inw_Outw();
                            rpt1 = (ReportDocument)rptstockinformationInwOutw;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(opnInwOut.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;

                    case ViewerSelector.GroupoptionWiseInwCls:
                        List<RStockInformation> opnInwCls = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (opnInwCls.Count > 0)
                        {
                            rptStockInformation_Inw_Cls rptstockinformationInwCls = new rptStockInformation_Inw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationInwCls;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(opnInwCls.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;
                    case ViewerSelector.GroupoptionWiseOutwCls:
                        List<RStockInformation> opnoutcls = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (opnoutcls.Count > 0)
                        {
                            rptStockInformation_Outw_Cls rptstockinformationOutwCls = new rptStockInformation_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationOutwCls;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(opnoutcls.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;

                    case ViewerSelector.GroupoptionWiseOpnInwOutw:
                        List<RStockInformation> opnInout = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (opnInout.Count > 0)
                        {
                            rptStockInformation_Opn__Inw_Ootw rptstockinformationOpnImwOutw = new rptStockInformation_Opn__Inw_Ootw();
                            rpt1 = (ReportDocument)rptstockinformationOpnImwOutw;

                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(opnInout.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;
                    case ViewerSelector.GroupoptionWiseOpnInwCls:
                        List<RStockInformation> opnIncls = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (opnIncls.Count > 0)
                        {
                            rptStockInformation_Opn__Inw_Cls rptstockinformationOpnImwCls = new rptStockInformation_Opn__Inw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationOpnImwCls;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(opnIncls.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;
                    case ViewerSelector.GroupoptionWiseOpnOutwCls:
                        List<RStockInformation> opnoutCls = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (opnoutCls.Count > 0)
                        {
                            rptStockInformation_Opn__Outw_Cls rptstockinformationOpnOutwCls = new rptStockInformation_Opn__Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationOpnOutwCls;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(opnoutCls.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;

                    case ViewerSelector.GroupoptionWiseInwOutwCls:
                        List<RStockInformation> opnInoutcls = objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList();
                        if (opnInoutcls.Count > 0)
                        {
                            rptStockInformation_Inw_Outw_Cls rptstockinformationInwOutwCls = new rptStockInformation_Inw_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationInwOutwCls;
                            this.reportTitle = "Stock Summary (Groupwise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(opnInoutcls.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                        }
                        else
                        {
                            lblName.Text = "Sorry!No Data Found...";
                        }
                        break;
                    //****************************Stock**********************************
                    #endregion
                    #region StockInformationItemwise

                    case ViewerSelector.StockinfoItemWiseCls:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Clos rptstockinformationLctWCls = new rptStockInformationLctW_Clos();
                            rpt1 = (ReportDocument)rptstockinformationLctWCls;
                        }
                        else
                        {
                            rptStockInformationItemW_Clos rptstockinformationItemWCls = new rptStockInformationItemW_Clos();
                            rpt1 = (ReportDocument)rptstockinformationItemWCls;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseInwCls:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Inw_Cls rptstockinformationItemWInwCls = new rptStockInformationLctW_Inw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationItemWInwCls;
                        }
                        else
                        {
                            rptStockInformationItemW_Inw_Cls rptstockinformationItemWInwCls = new rptStockInformationItemW_Inw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationItemWInwCls;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseInwOutw:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Inw_Outw rptstockinformationItemWInwOutw = new rptStockInformationLctW_Inw_Outw();
                            rpt1 = (ReportDocument)rptstockinformationItemWInwOutw;
                        }
                        else
                        {
                            rptStockInformationItemW_Inw_Outw rptstockinformationItemWInwOutw = new rptStockInformationItemW_Inw_Outw();
                            rpt1 = (ReportDocument)rptstockinformationItemWInwOutw;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseInwOutwCls:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Inw_Outw_Cls rptstockinformationItemWInwOutwCls = new rptStockInformationLctW_Inw_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationItemWInwOutwCls;
                        }
                        else
                        {
                            rptStockInformationItemW_Inw_Outw_Cls rptstockinformationItemWInwOutwCls = new rptStockInformationItemW_Inw_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationItemWInwOutwCls;
                        }
                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseInw:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Inward rptstockinformationItemWInw = new rptStockInformationLctW_Inward();
                            rpt1 = (ReportDocument)rptstockinformationItemWInw;
                        }
                        else
                        {
                            rptStockInformationItemW_Inward rptstockinformationItemWInw = new rptStockInformationItemW_Inward();
                            rpt1 = (ReportDocument)rptstockinformationItemWInw;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseOpnCls:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Opn__Cls rptstockinformationItemWOpnCls = new rptStockInformationLctW_Opn__Cls();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnCls;
                        }
                        else
                        {
                            rptStockInformationItemW_Opn__Cls rptstockinformationItemWOpnCls = new rptStockInformationItemW_Opn__Cls();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnCls;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseOpnInw:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Opn_Inw rptstockinformationItemWOpnInw = new rptStockInformationLctW_Opn_Inw();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnInw;
                        }
                        else
                        {
                            rptStockInformationItemW_Opn_Inw rptstockinformationItemWOpnInw = new rptStockInformationItemW_Opn_Inw();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnInw;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseOpnInwCls:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Opn_Inw_Cls rptstockinformationItemWOpnInwCls = new rptStockInformationLctW_Opn_Inw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnInwCls;
                        }
                        else
                        {
                            rptStockInformationItemW_Opn_Inw_Cls rptstockinformationItemWOpnInwCls = new rptStockInformationItemW_Opn_Inw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnInwCls;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseOpnInwOutw:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Opn_Inw_Ootw rptstockinformationItemWOpnInwOutw = new rptStockInformationLctW_Opn_Inw_Ootw();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnInwOutw;
                        }
                        else
                        {
                            rptStockInformationItemW_Opn_Inw_Ootw rptstockinformationItemWOpnInwOutw = new rptStockInformationItemW_Opn_Inw_Ootw();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnInwOutw;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseOpnInwOutwCls:
                        if (intype == 1)
                        {
                            rptStockInformationItemW_Val_Supp rptstockinformationItemWOpnInwOutwCls = new rptStockInformationItemW_Val_Supp();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnInwOutwCls;
                            this.reportTitle = "Stock Summary (ItemWise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                            break;
                        }
                        else
                        {
                            if (intype == 2)
                            {
                                rptStockInformationLctW_Opn_Inw_Ootw_Cls rptstockinformationItemWOpnInwOutwCls = new rptStockInformationLctW_Opn_Inw_Ootw_Cls();
                                rpt1 = (ReportDocument)rptstockinformationItemWOpnInwOutwCls;
                            }
                            else
                            {
                                rptStockInformationItemW_Opn_Inw_Ootw_Cls rptstockinformationItemWOpnInwOutwCls = new rptStockInformationItemW_Opn_Inw_Ootw_Cls();
                                rpt1 = (ReportDocument)rptstockinformationItemWOpnInwOutwCls;
                            }


                            this.reportTitle = "Stock Summary (ItemWise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                            break;
                        }

                    case ViewerSelector.StockinfoItemWiseOpnOutw:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Opn_Outw rptstockinformationItemWOpnOutw = new rptStockInformationLctW_Opn_Outw();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnOutw;
                        }
                        else
                        {
                            rptStockInformationItemW_Opn_Outw rptstockinformationItemWOpnOutw = new rptStockInformationItemW_Opn_Outw();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnOutw;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseOpnOutwCls:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Opn_Outw_Cls rptstockinformationItemWOpnOutwCls = new rptStockInformationLctW_Opn_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnOutwCls;
                        }
                        else
                        {
                            rptStockInformationItemW_Opn_Outw_Cls rptstockinformationItemWOpnOutwCls = new rptStockInformationItemW_Opn_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpnOutwCls;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseOpn:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Opn rptstockinformationItemWOpn = new rptStockInformationLctW_Opn();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpn;
                        }
                        else
                        {
                            rptStockInformationItemW_Opn rptstockinformationItemWOpn = new rptStockInformationItemW_Opn();
                            rpt1 = (ReportDocument)rptstockinformationItemWOpn;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseOutw:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Outw rptstockinformationItemWOutw = new rptStockInformationLctW_Outw();
                            rpt1 = (ReportDocument)rptstockinformationItemWOutw;
                        }
                        else
                        {
                            rptStockInformationItemW_Outw rptstockinformationItemWOutw = new rptStockInformationItemW_Outw();
                            rpt1 = (ReportDocument)rptstockinformationItemWOutw;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoItemWiseOutwCls:
                        if (intype == 2)
                        {
                            rptStockInformationLctW_Outw_Cls rptstockinformationItemWOutwCls = new rptStockInformationLctW_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationItemWOutwCls;
                        }
                        else
                        {
                            rptStockInformationItemW_Outw_Cls rptstockinformationItemWOutwCls = new rptStockInformationItemW_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationItemWOutwCls;
                        }

                        this.reportTitle = "Stock Summary (ItemWise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    #endregion
                    #region StockInformationCatWise
                    case ViewerSelector.StockinfoCatWiseCls:
                        rptStockInformationCatW_Clos rptstockinformationCatWCls = new rptStockInformationCatW_Clos();
                        rpt1 = (ReportDocument)rptstockinformationCatWCls;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.StockinfoCatWiseInwCls:
                        rptStockInformationCatW_Inw_Cls rptstockinformationCatWInwCls = new rptStockInformationCatW_Inw_Cls();
                        rpt1 = (ReportDocument)rptstockinformationCatWInwCls;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoCatWiseInwOutw:
                        rptStockInformationCatW_Inw_Outw rptstockinformationCatWInwOutw = new rptStockInformationCatW_Inw_Outw();
                        rpt1 = (ReportDocument)rptstockinformationCatWInwOutw;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoCatWiseInwOutwCls:
                        rptStockInformationCatW_Inw_Outw_Cls rptstockinformationCatWInwOutwCls = new rptStockInformationCatW_Inw_Outw_Cls();
                        rpt1 = (ReportDocument)rptstockinformationCatWInwOutwCls;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoCatWiseInw:
                        rptStockInformationCatW_Inward rptstockinformationCatWInw = new rptStockInformationCatW_Inward();
                        rpt1 = (ReportDocument)rptstockinformationCatWInw;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoCatWiseOpnCls:
                        rptStockInformationCatW_Opn__Cls rptstockinformationCatWOpnCls = new rptStockInformationCatW_Opn__Cls();
                        rpt1 = (ReportDocument)rptstockinformationCatWOpnCls;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoCatWiseOpnInw:

                        rptStockInformationCatW_Opn_Inw rptstockinformationCatWOpnInw = new rptStockInformationCatW_Opn_Inw();
                        rpt1 = (ReportDocument)rptstockinformationCatWOpnInw;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.StockinfoCatWiseOpnInwCls:
                        rptStockInformationCatW_Opn_Inw_Cls rptstockinformationCatWOpnInwCls = new rptStockInformationCatW_Opn_Inw_Cls();
                        rpt1 = (ReportDocument)rptstockinformationCatWOpnInwCls;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoCatWiseOpnInwOutw:
                        rptStockInformationCatW_Opn_Inw_Ootw rptstockinformationCatWOpnInwOutw = new rptStockInformationCatW_Opn_Inw_Ootw();
                        rpt1 = (ReportDocument)rptstockinformationCatWOpnInwOutw;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoCatWiseOpnInwOutwCls:
                        if (intype == 1)
                        {
                            rptStockInformationCatW_ValSup rptstockinformationCatWOpnInwOutwCls = new rptStockInformationCatW_ValSup();
                            rpt1 = (ReportDocument)rptstockinformationCatWOpnInwOutwCls;
                            this.reportTitle = "Stock Summary (Pack Size Wise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                            break;
                        }
                        else
                        {
                            rptStockInformationCatW_Opn_Inw_Ootw_Cls rptstockinformationCatWOpnInwOutwCls = new rptStockInformationCatW_Opn_Inw_Ootw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationCatWOpnInwOutwCls;
                            this.reportTitle = "Stock Summary (Pack Size Wise)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                            break;
                        }
                    case ViewerSelector.StockinfoCatWiseOpnOutw:
                        rptStockInformationCatW_Opn_Outw rptstockinformationCatWOpnOutw = new rptStockInformationCatW_Opn_Outw();
                        rpt1 = (ReportDocument)rptstockinformationCatWOpnOutw;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoCatWiseOpnOutwCls:
                        rptStockInformationCatW_Opn_Outw_Cls rptstockinformationCatWOpnOutwCls = new rptStockInformationCatW_Opn_Outw_Cls();
                        rpt1 = (ReportDocument)rptstockinformationCatWOpnOutwCls;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoCatWiseOpn:
                        rptStockInformationCatW_Opn rptstockinformationCatWOpn = new rptStockInformationCatW_Opn();
                        rpt1 = (ReportDocument)rptstockinformationCatWOpn;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoCatWiseOutw:
                        rptStockInformationCatW_Outw rptstockinformationCatWOutw = new rptStockInformationCatW_Outw();
                        rpt1 = (ReportDocument)rptstockinformationCatWOutw;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoCatWiseOutwCls:
                        rptStockInformationCatW_Outw_Cls rptstockinformationCatWOutwCls = new rptStockInformationCatW_Outw_Cls();
                        rpt1 = (ReportDocument)rptstockinformationCatWOutwCls;
                        this.reportTitle = "Stock Summary (Pack Size Wise)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, Utility.gstrUserName, strString3, "").ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region StockInformationLocationWise

                    case ViewerSelector.StockinfoLctWiseCls:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Clos rptstockinformationLctWCls = new rptStockInformationLocSumm_Clos();
                            rpt1 = (ReportDocument)rptstockinformationLctWCls;
                        }
                        else
                        {
                            rptStockInformationLctW_Clos rptstockinformationLctWCls = new rptStockInformationLctW_Clos();
                            rpt1 = (ReportDocument)rptstockinformationLctWCls;
                        }
                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3,strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoLctWiseInwCls:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Inw_Cls rptstockinformationLctWInwCls = new rptStockInformationLocSumm_Inw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWInwCls;
                        }
                        else
                        {
                            rptStockInformationLctW_Inw_Cls rptstockinformationLctWInwCls = new rptStockInformationLctW_Inw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWInwCls;
                        }

                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoLctWiseInwOutw:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Inw_Outw rptstockinformationLctWInwOutw = new rptStockInformationLocSumm_Inw_Outw();
                            rpt1 = (ReportDocument)rptstockinformationLctWInwOutw;
                        }
                        else
                        {
                            rptStockInformationLctW_Inw_Outw rptstockinformationLctWInwOutw = new rptStockInformationLctW_Inw_Outw();
                            rpt1 = (ReportDocument)rptstockinformationLctWInwOutw;
                        }
                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoLctWiseInwOutwCls:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Inw_Outw_Cls rptstockinformationLctWInwOutwCls = new rptStockInformationLocSumm_Inw_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWInwOutwCls;
                        }
                        else
                        {
                            rptStockInformationLctW_Inw_Outw_Cls rptstockinformationLctWInwOutwCls = new rptStockInformationLctW_Inw_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWInwOutwCls;
                        }
                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoLctWiseInw:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Inward rptstockinformationLctWInw = new rptStockInformationLocSumm_Inward();
                            rpt1 = (ReportDocument)rptstockinformationLctWInw;
                        }
                        else
                        {
                            rptStockInformationLctW_Inward rptstockinformationLctWInw = new rptStockInformationLctW_Inward();
                            rpt1 = (ReportDocument)rptstockinformationLctWInw;
                        }
                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate; ;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoLctWiseOpnCls:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Opn__Cls rptstockinformationLctWOpnCls = new rptStockInformationLocSumm_Opn__Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnCls;
                        }
                        else
                        {
                            rptStockInformationLctW_Opn__Cls rptstockinformationLctWOpnCls = new rptStockInformationLctW_Opn__Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnCls;
                        }
                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.StockinfoLctWiseOpnInw:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Opn_Inw rptstockinformationLctWOpnInw = new rptStockInformationLocSumm_Opn_Inw();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnInw;
                        }
                        else
                        {
                            rptStockInformationLctW_Opn_Inw rptstockinformationLctWOpnInw = new rptStockInformationLctW_Opn_Inw();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnInw;
                        }
                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoLctWiseOpnInwCls:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Opn_Inw_Cls rptstockinformationLctWOpnInwCls = new rptStockInformationLocSumm_Opn_Inw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnInwCls;
                        }
                        else
                        {
                            rptStockInformationLctW_Opn_Inw_Cls rptstockinformationLctWOpnInwCls = new rptStockInformationLctW_Opn_Inw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnInwCls;
                        }

                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoLctWiseOpnInwOutw:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Opn_Inw_Ootw rptstockinformationLctWOpnInwOutw = new rptStockInformationLocSumm_Opn_Inw_Ootw();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnInwOutw;
                        }
                        else
                        {
                            rptStockInformationLctW_Opn_Inw_Ootw rptstockinformationLctWOpnInwOutw = new rptStockInformationLctW_Opn_Inw_Ootw();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnInwOutw;
                        }
                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoLctWiseOpnInwOutwCls:
                        if (intype == 1)
                        {
                            rptStockInformationLctW_Val_Supp rptstockinformationLctWOpnInwOutwCls = new rptStockInformationLctW_Val_Supp();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnInwOutwCls;
                            this.reportTitle = "Stock Summary (ItemWise Location)";
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, 1, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                            break;
                        }
                        else if (intype == 2)
                        {
                            rptStockInformationLocSumm_Opn_Inw_Ootw_Cls rptstockinformationLctWOpnInwOutwCls = new rptStockInformationLocSumm_Opn_Inw_Ootw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnInwOutwCls;

                        }
                        else
                        {
                            rptStockInformationLctW_Opn_Inw_Ootw_Cls rptstockinformationLctWOpnInwOutwCls = new rptStockInformationLctW_Opn_Inw_Ootw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnInwOutwCls;
                        }
                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;


                    case ViewerSelector.StockinfoLctWiseOpnOutw:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Opn_Outw rptstockinformationLctWOpnOutw = new rptStockInformationLocSumm_Opn_Outw();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnOutw;
                        }
                        else
                        {
                            rptStockInformationLctW_Opn_Outw rptstockinformationLctWOpnOutw = new rptStockInformationLctW_Opn_Outw();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnOutw;
                        }
                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.StockinfoLctWiseOpnOutwCls:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Opn_Outw_Cls rptstockinformationLctWOpnOutwCls = new rptStockInformationLocSumm_Opn_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnOutwCls;
                        }
                        else
                        {
                            rptStockInformationLctW_Opn_Outw_Cls rptstockinformationLctWOpnOutwCls = new rptStockInformationLctW_Opn_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpnOutwCls;
                        }

                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.StockinfoLctWiseOpn:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Opn rptstockinformationLctWOpn = new rptStockInformationLocSumm_Opn();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpn;
                        }
                        else
                        {
                            rptStockInformationLctW_Opn rptstockinformationLctWOpn = new rptStockInformationLctW_Opn();
                            rpt1 = (ReportDocument)rptstockinformationLctWOpn;
                        }
                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.StockinfoLctWiseOutw:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Outw rptstockinformationLctWOutw = new rptStockInformationLocSumm_Outw();
                            rpt1 = (ReportDocument)rptstockinformationLctWOutw;
                        }
                        else
                        {
                            rptStockInformationLctW_Outw rptstockinformationLctWOutw = new rptStockInformationLctW_Outw();
                            rpt1 = (ReportDocument)rptstockinformationLctWOutw;
                        }
                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.StockinfoLctWiseOutwCls:
                        if (intype == 2)
                        {
                            rptStockInformationLocSumm_Outw_Cls rptstockinformationLctWOutwCls = new rptStockInformationLocSumm_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWOutwCls;
                        }
                        else
                        {
                            rptStockInformationLctW_Outw_Cls rptstockinformationLctWOutwCls = new rptStockInformationLctW_Outw_Cls();
                            rpt1 = (ReportDocument)rptstockinformationLctWOutwCls;
                        }
                        this.reportTitle = "Stock Summary (ItemWise Location)";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objWIS.mItemMaster(strComID, strFdate, strTdate, strString, strSelction, intSuppress, Utility.gblnAccessControl, strUserSecurity, strString3, strStringNew).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    #endregion
                    #region StoreLedger

                    case ViewerSelector.storeLedger:
                        rptStoreLedger rptStoreLedger = new rptStoreLedger();
                        rpt1 = (ReportDocument)rptStoreLedger;
                        this.reportTitle = "Store Ledger";
                        this.strString = strString;

                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orptCnn.mGetStoreLedger(strComID, strFdate, strTdate, strString2, strSelction).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;


                    case ViewerSelector.storeLedgerIndividual:
                        List<RStockInformation> oStoreLedgerIndi = orptCnn.mGetStoreLedger(strComID, strFdate, strTdate, strString2, strSelction).ToList();

                        rptStoreLedgerInd rptStoreLedgerIndivLctItemW = new rptStoreLedgerInd();
                        rpt1 = (ReportDocument)rptStoreLedgerIndivLctItemW;
                        this.reportTitle = "Store Ledger";
                        this.strString = "";
                        this.strString2 = "Location Nmae: " + strSelction + " & Item Name: " + strString2;
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oStoreLedgerIndi);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    #endregion
                    #region "Individual Voucher"
                    case ViewerSelector.intventoryVoucher:
                        List<RStockInformation> ogrp;
                        string strFromlocation = "";
                        if (strFdate != "")
                        {
                            ogrp = orptCnn.mGetInventortyVoucher(strComID, strFdate, strTdate, strSelction, strString, "", strSummDetails).ToList();
                        }
                        else
                        {
                            ogrp = orptCnn.mGetInventortyVoucher(strComID, strFdate, strTdate, strSelction, "", strString, strSummDetails).ToList();
                        }
                        if (strSummDetails == "Details")
                        {
                            if (strFdate == "")
                            {
                                rptInventoryVoucher rptInventoryVoucher = new rptInventoryVoucher();
                                rpt1 = (ReportDocument)rptInventoryVoucher;
                            }
                            else
                            {
                                rptInventoryVoucherAll rptInventoryVoucherAll = new rptInventoryVoucherAll();
                                rpt1 = (ReportDocument)rptInventoryVoucherAll;
                            }
                        }
                        else
                        {
                            rptInventoryVoucherAllSumm rptInventoryVoucherAll = new rptInventoryVoucherAllSumm();
                            rpt1 = (ReportDocument)rptInventoryVoucherAll;
                        }

                        if (strSelction == "D")
                        {
                            this.reportTitle = "Stock Damage";
                        }
                        else if (strSelction == "T")
                        {
                            if (strFdate == "")
                            {
                                rptInventoryVoucher_Stock_Transfer rptInventoryVoucherT = new rptInventoryVoucher_Stock_Transfer();
                                rpt1 = (ReportDocument)rptInventoryVoucherT;
                                this.reportTitle = "Stock Transfer";
                            }
                            else
                            {
                                rptInventoryVoucherAll rptInventoryVoucherAll = new rptInventoryVoucherAll();
                                rpt1 = (ReportDocument)rptInventoryVoucherAll;
                                this.reportTitle = "Stock Transfer All";
                            }
                        }
                        else if (strSelction == "P")
                        {
                            if (strFdate == "")
                            {
                                rptInventoryVoucher_Phy_stock rptInventoryVoucherPS = new rptInventoryVoucher_Phy_stock();
                                rpt1 = (ReportDocument)rptInventoryVoucherPS;
                                this.reportTitle = "Physical Stock Individual";
                            }
                            else
                            {
                                if (strSummDetails == "Details")
                                {
                                    rptInventoryVoucherAll rptInventoryVoucherAll = new rptInventoryVoucherAll();
                                    rpt1 = (ReportDocument)rptInventoryVoucherAll;
                                    this.reportTitle = "Physical Stock All";
                                }
                                else
                                {
                                    this.reportTitle = "Physical Stock (Summ)";
                                }
                            }
                        }
                        else if (strSelction == "C")
                        {
                            this.reportTitle = "Stock Consumption";
                        }
                        else if (strSelction == "F")
                        {
                            this.reportTitle = "Finished Goods";
                        }
                        else if (strSelction == "M")
                        {
                            if (strFdate == "")
                            {
                                foreach (RStockInformation ogp in ogrp)
                                {
                                    if (ogp.intVtype == 29)
                                    {
                                        strFromlocation = ogp.strLocationName;
                                    }
                                    else
                                    {
                                        strToLocation = ogp.strLocationName;
                                    }
                                }

                                rptInventoryVoucher_MV rptInventoryVoucherM = new rptInventoryVoucher_MV();
                                rpt1 = (ReportDocument)rptInventoryVoucherM;
                                this.reportTitle = "Manufacturing Report (Individual)";
                            }
                            else
                            {
                                if (strSummDetails == "Details")
                                {
                                    rptInventoryVoucherAll rptInventoryVoucherAll = new rptInventoryVoucherAll();
                                    rpt1 = (ReportDocument)rptInventoryVoucherAll;
                                    this.reportTitle = "Manufacturing Report (All)";
                                }
                                else
                                {
                                    this.reportTitle = "Manufacturing Report (Summary)";
                                }
                            }

                        }
                        else if (strSelction == "S")
                        {
                            this.reportTitle = "Sales Sample";
                        }
                        else if (strFdate == "")
                        {
                            this.reportTitle = "Individual Voucher Report";
                        }
                        if (strFdate != "")
                        {
                            if (strString != "")
                            {
                                this.secondParameter = strString + " (" + strFdate + " to " + strTdate + ")";
                            }
                            else
                            {
                                this.secondParameter = strFdate + " to " + strTdate;
                            }
                        }
                        else
                        {
                            this.secondParameter = "";
                        }
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(ogrp.ToList());
                        if (strSelction == "M" && strFdate == "")
                        {
                            rpt1.SetParameterValue("strFromLocation", strFromlocation);
                            rpt1.SetParameterValue("strToLocation", strToLocation);
                        }
                        crystalReportViewer1.ReportSource = rpt1;

                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "Profitability"

                    case ViewerSelector.profitability:
                        rptProfitability rptProfitabilityy = new rptProfitability();
                        rpt1 = (ReportDocument)rptProfitabilityy;
                        this.reportTitle = "Profitability Report";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        if (strString != "")
                        {
                            rpt1.SetDataSource(orptCnn.mGetProfitability(strComID, strFdate, strTdate, strString).ToList());
                        }
                        else
                        {
                            rpt1.SetDataSource(objWIS.mGetProfitability(strComID, strFdate, strTdate, strString).ToList());
                        }
                        crystalReportViewer1.ReportSource = rpt1;
                        if (strSelction == "Sales")
                        {
                            rpt1.SetParameterValue("Cost", 0);
                        }
                        else
                        {
                            rpt1.SetParameterValue("Cost", 1);
                        }
                        ShowReport(rpt1, false, "");
                        break;

                    #endregion
                    #region "Individual Sales Sample"
                    case ViewerSelector.individualSample:
                        ogrp = (orptCnn.mGetindividualSalpmle(strComID, strString).ToList());
                        rptVoucher_Sales_Chalan_Voucher_Det_SumN rptVoucher_Sales_Chalan_Voucher_Det_Sum = new rptVoucher_Sales_Chalan_Voucher_Det_SumN();
                        rpt1 = (ReportDocument)rptVoucher_Sales_Chalan_Voucher_Det_Sum;
                        this.reportTitle = "Sales Sample";
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(ogrp.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        string strCompanyName = Utility.gstrCompanyName;
                        rpt1.SetParameterValue("strCompanyName", strCompanyName);
                        ShowReport(rpt1, false, "");
                        break;

                    #endregion
                    #region "Production"
                    case ViewerSelector.Production:
                        List<RoProduction> obgProBatch= orptCnn.GetBatchWiseProductionInd(strComID, strString).ToList();
                        rptBatchWiseProductionInd rptBatchWiseProductionInd = new rptBatchWiseProductionInd();
                        rpt1 = (ReportDocument)rptBatchWiseProductionInd;
                        this.reportTitle = "Batch Wise Production";
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(obgProBatch.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    #endregion
                    #region "Monthly Production"
                    case ViewerSelector.PackingRawMaterialsStock:

                        List<RoPackingRawMaterialsStockinfo> objrptPackingRawMaterialsConjumption_ = orptCnn.mGetLocationQty2(strComID, strFdate, strTdate, strString5, strString6, 0, "").ToList();
                        rptPacking_RawMaterials_Conjumption_ rptPacking_RawMaterials_Conjumption_ = new rptPacking_RawMaterials_Conjumption_();
                        rpt1 = (ReportDocument)rptPacking_RawMaterials_Conjumption_;
                        this.reportTitle = "Monthly Production";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objrptPackingRawMaterialsConjumption_.ToList());
                        //rpt1.SetParameterValue("ClassPower", strString);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;


                    case ViewerSelector.Production_Convertion:

                        List<RoConsumption> objProduction_Convertion = orptCnn.mGetConversion(strComID, strFdate, strTdate, strString5, strString6, strString7, 0).ToList();
                        rptProduction_Convertion rptProduction_Convertion = new rptProduction_Convertion();
                        rpt1 = (ReportDocument)rptProduction_Convertion;
                        this.reportTitle = "Product Conversion";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(objProduction_Convertion.ToList());
                        //rpt1.SetParameterValue("ClassPower", strString);
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;


                    case ViewerSelector.MonthlyProduction_Class_Power:

                        List<RoMonthlyProduction> oMonthlyProduction_Class_Power = orptCnn.mGetMonthlyProductionClassPower(strComID, strFdate, strTdate, strString5, strString6, strString7, intype).ToList();
                        rptPMonthly_Production_Class_Power rptPMonthly_Production_Class_Power = new rptPMonthly_Production_Class_Power();
                        rpt1 = (ReportDocument)rptPMonthly_Production_Class_Power;
                        this.reportTitle = "Monthly Production";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oMonthlyProduction_Class_Power.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.MonthlyProduction:

                        List<RoMonthlyProduction> oMonthlyProduction = orptCnn.mGetMonthlyProduction(strComID, strFdate, strTdate, strString5, strString6, 0).ToList();
                        rptPMonthly_Production rptPMonthly_Production = new rptPMonthly_Production();
                        rpt1 = (ReportDocument)rptPMonthly_Production;
                        this.reportTitle = "Monthly Production";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oMonthlyProduction.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;


                    #endregion
                    #region "Stock In"
                    case ViewerSelector.StockIn:

                        List<RoStockRequisition> oLStockIn = orptCnn.mGetStockIn(strComID, strString).ToList();
                        rptStockIN rptoLStockIn = new rptStockIN();
                        rpt1 = (ReportDocument)rptoLStockIn;
                        this.reportTitle = "Stock In";
                        this.secondParameter = "";
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oLStockIn.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "Stock Out"
                    case ViewerSelector.StockOut:

                        List<RoStockRequisition> oLStockOut = orptCnn.mGetStockOut(strComID, strString).ToList();
                        rptStockOut rptoLStockOut = new rptStockOut();
                        rpt1 = (ReportDocument)rptoLStockOut;
                        this.reportTitle = "Stock Out";
                        this.secondParameter = "";
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oLStockOut.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;
                    #endregion
                    #region "Stock Reqoisition"
                    case ViewerSelector.StockRequisition:

                        List<RoStockRequisition> oLStockRequisition = orptCnn.mGetStockRequisition(strComID, strString).ToList();
                        rptStockReqisition rptoLStockRequisition = new rptStockReqisition();
                        rpt1 = (ReportDocument)rptoLStockRequisition;
                        this.reportTitle = "Stock Requisition";
                        this.secondParameter = "";
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(oLStockRequisition.ToList());
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
                //InitialiseParameterLabels(rpt, strReportTitle);
                this.Show();
            }

        }
        #endregion




    }
}
