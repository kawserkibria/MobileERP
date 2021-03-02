
using CrystalDecisions.CrystalReports.Engine;
using Dutility;
using JA.Modulecontrolar.JSAPUR;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.JRPT;
using JA.Modulecontrolar.UI.DReport.Purchase.ReportUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.DReport.Purchase.Viewer
{
    public partial class frmReportViewer : Form
    {
        JSAPUR.WSalesPurchaseClient orpt = new WSalesPurchaseClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWoIS = new SPWOIS();

        private String reportTitle = "";
        private String secondParameter = "";
        public string strString2 = "";
        public string strFdate { get; set; }
        public string strTdate { get; set; }
        public string strString { get; set; }
        public string strLedgerName { get; set; }
        public string strSelction { get; set; }
        public int intSuppress { get; set; }
        public int intMode { get; set; }
        public int intvType { get; set; }
        public string strStockItemName { get; set; }
        public string strBranchID = "";
        public string reportTitle2 { get; set; }
        public ViewerSelector selector;
        public String ReportTitle { set { reportTitle = value; } get { return reportTitle; } }
        public String ReportSecondParameter { set { secondParameter = value; } get { return secondParameter; } }
        private string strComID { get; set; }
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
            if (reportTitle2 != null)
            {
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter2"]).Text = this.ReportTitle + '-' + this.secondParameter; ;
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtCompanyName2"]).Text = Utility.gstrCompanyName;
            }
            if (ReportTitle != "")
            {
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.ReportTitle;
            }
            if (ReportSecondParameter != "")
            {
                ((TextObject)rpt.ReportDefinition.ReportObjects["txtSecondParameter"]).Text = this.secondParameter;
            }
            else
            {
                rpt.ReportDefinition.ReportObjects["txtSecondParameter"].ObjectFormat.EnableSuppress = true;
            }

        }
        #region "Load"
        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            double dblAdd = 0, dblLess = 0;
            ReportDocument rpt1;
            try
            {
                switch (selector)
                {

                    case ViewerSelector.customerInd2:

                        rptCustomer_Ledg_All2 rptCustomerifoLedg2 = new rptCustomer_Ledg_All2();
                        rpt1 = (ReportDocument)rptCustomerifoLedg2;
                        if (strString == "")
                        {

                            this.reportTitle = "Doctor/Customer List";
                        }
                        else
                        {
                            if (strStockItemName == "Ledwise")
                            {
                                this.reportTitle = "Doctor/Customer List";
                            }
                            else
                            {
                                this.reportTitle = "Doctor/Customer List( " + strString + ")";
                            }
                        }


                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSupplierList(strComID, strFdate, strTdate, strString, intMode, strString2, strBranchID).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        rpt1.SetParameterValue("InSupress", intSuppress);
                        //rpt1.SetParameterValue("LedgerName", strString);
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.VouchearVouNoListReport:
                        rptInvoice_view VouchearVouNoListReport = new rptInvoice_view();
                        rpt1 = (ReportDocument)VouchearVouNoListReport;


                        if (strFdate != "")
                        {
                            this.secondParameter = strFdate + " to " + strTdate;
                        }
                        else
                        {
                            this.secondParameter = "";
                        }
                        this.reportTitle = strString2;
                        rpt1.SetDataSource(orpt.mGetSalesInvoiceReportPriview(strComID, strString,strLedgerName).ToList());
                        //rpt1.Subreports[0].SetDataSource(orpt.mGetVoucherAddless(strComID, strLedgerName, strSelction).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        InitialiseLabels(rpt1);
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.customerInd1:
                        rptCustomer_Ledg_All_MobileNo rptCustomerifoLedgr = new rptCustomer_Ledg_All_MobileNo();
                        rpt1 = (ReportDocument)rptCustomerifoLedgr;
                        if (strString == "")
                        {

                            this.reportTitle = "Doctor/Customer List";
                        }
                        else
                        {
                            if (strStockItemName == "Ledwise")
                            {
                                this.reportTitle = "Doctor/Customer List";
                            }
                            else
                            {
                                this.reportTitle = "Doctor/Customer List( " + strString + ")";
                            }
                        }
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSupplierList(strComID, strFdate, strTdate, strString, intMode, strString2, strBranchID).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        rpt1.SetParameterValue("InSupress", intSuppress);
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.customerInd:

                        rptCustomer_Ledg_All rptCustomerifoLedg = new rptCustomer_Ledg_All();
                        rpt1 = (ReportDocument)rptCustomerifoLedg;
                        if (strString == "")
                        {

                            this.reportTitle = "Doctor/Customer List";
                        }
                        else
                        {
                            if (strStockItemName == "Ledwise")
                            {
                                this.reportTitle = "Doctor/Customer List";
                            }
                            else
                            {
                                this.reportTitle = "Doctor/Customer List( " + strString + ")";
                            }
                        }


                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSupplierList(strComID, strFdate, strTdate, strString, intMode, strString2, strBranchID).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        rpt1.SetParameterValue("InSupress", intSuppress);
                        //rpt1.SetParameterValue("LedgerName", strString);
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.customerlist:
                        rptCustomer_Group_All rptCustomerifoLedgg = new rptCustomer_Group_All();
                        rpt1 = (ReportDocument)rptCustomerifoLedgg;
                        this.reportTitle = "Doctor/Customer List";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSupplierList(strComID, strFdate, strTdate, strString, intMode, strString2, strBranchID).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        rpt1.SetParameterValue("intSuppress", intSuppress);
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.SupplieGroup:
                        rptSupplier_Group_All rptSupplierinfo = new rptSupplier_Group_All();
                        rpt1 = (ReportDocument)rptSupplierinfo;
                        this.secondParameter = strFdate + " to " + strTdate;
                        this.reportTitle = "Supplier List";
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSupplierList(strComID, strFdate, strTdate, strString, intMode, strString2, strBranchID).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.SupplieinfoInd:
                        rptSupplier_ind_All rptSupplierinfoLW = new rptSupplier_ind_All();
                        rpt1 = (ReportDocument)rptSupplierinfoLW;
                        this.reportTitle = "Supplier List";
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetSupplierList(strComID, strFdate, strTdate, strString, intMode, strString2, strBranchID).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        this.secondParameter = strFdate + " to " + strTdate;
                        ShowReport(rpt1, false, "");
                        break;
                    //'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    case ViewerSelector.Vouchear:
                        List<RSalesPurchase> objTotal;
                        if (strLedgerName != "")
                        {
                            objTotal = orpt.mGetVoucherReport(strComID, strFdate, strTdate, strLedgerName, "", intMode, strSelction).ToList();
                        }
                        else
                        {
                            objTotal = objWoIS.mGetVoucherReport(strComID, strFdate, strTdate, strLedgerName, "", intMode, strSelction).ToList();
                        }
                        if (strSelction == "Sum")
                        {
                            rptVoucher_Pur_Inv_All_Summ2 rptVoucher_Pur_Inv_All_Summ2 = new rptVoucher_Pur_Inv_All_Summ2();
                            rpt1 = (ReportDocument)rptVoucher_Pur_Inv_All_Summ2;
                            this.secondParameter = strFdate + " to " + strTdate;
                            this.reportTitle = strString2;

                            rpt1.SetDataSource(objTotal.ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            if (strLedgerName != null)
                            {
                                rpt1.SetParameterValue("strLedgerName", strLedgerName);
                            }
                            InitialiseLabels(rpt1);
                            ShowReport(rpt1, false, "");
                            break;

                        }
                        else
                        {
                            List<AccBillwise> obilladdless = accms.DisplaycommonInvoiceAddlessDateWise(strComID, strFdate, strTdate, "", intvType).ToList();
                            foreach (AccBillwise obili in obilladdless)
                            {
                                if (obili.dblCreditAmount < 0)
                                {
                                    dblAdd = dblAdd + obili.dblCreditAmount * -1;
                                }
                                else
                                {
                                    dblLess = dblLess + obili.dblCreditAmount;
                                }
                            }

                            rptVoucher_Pur_Inv_All_Det rptVoucherPurInvAllDet = new rptVoucher_Pur_Inv_All_Det();
                            rpt1 = (ReportDocument)rptVoucherPurInvAllDet;
                            this.secondParameter = strFdate + " to " + strTdate;
                            this.reportTitle = strString2;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(objTotal.ToList());

                            crystalReportViewer1.ReportSource = rpt1;
                            rpt1.SetParameterValue("intSuppress", intSuppress);
                            rpt1.SetParameterValue("ADD", dblAdd);
                            rpt1.SetParameterValue("LESS", dblLess);
                            ShowReport(rpt1, false, "");
                            break;
                        }

                    case ViewerSelector.VouchearInvoiceSingleSumm:

                        rptVoucher_Pur_Inv_All_Det rptVoucherPurInvAllDet2 = new rptVoucher_Pur_Inv_All_Det();
                        rpt1 = (ReportDocument)rptVoucherPurInvAllDet2;
                        this.secondParameter = strFdate + " to " + strTdate;
                        this.reportTitle = strString2;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetVoucherReport(strComID, strFdate, strTdate, strLedgerName, "", intMode, strSelction).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        rpt1.SetParameterValue("intSuppress", intSuppress);
                        rpt1.SetParameterValue("ADD", dblAdd);
                        rpt1.SetParameterValue("LESS", dblLess);
                        ShowReport(rpt1, false, "");
                        break;
                    case ViewerSelector.VouchearVouNo:

                        rptInvoice rptInvoice = new rptInvoice();
                        rpt1 = (ReportDocument)rptInvoice;


                        if (strFdate != "")
                        {
                            this.secondParameter = strFdate + " to " + strTdate;
                        }
                        else
                        {
                            this.secondParameter = "";
                        }
                        this.reportTitle = strString2;
                        rpt1.SetDataSource(orpt.mGetVoucherReportRefNo(strComID, strLedgerName, "", intMode).ToList());
                        rpt1.Subreports[0].SetDataSource(orpt.mGetVoucherAddless(strComID, strLedgerName, strSelction).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        InitialiseLabels(rpt1);
                        intSuppress = 0;
                        if (strString2 == "Purchase Invoice ")
                        {
                            intSuppress = 0;
                            rpt1.SetParameterValue("intSuppress", intSuppress);
                        }
                        else
                        {
                            rpt1.SetParameterValue("intSuppress", 1);
                        }
                        rpt1.SetParameterValue("ComName", Utility.gstrCompanyName);

                        ShowReport(rpt1, false, "");
                        break;


                    case ViewerSelector.VouchearS:
                        rptVoucher_Pur_Inv_All_Summ rptVoucherPurInvAllSumm = new rptVoucher_Pur_Inv_All_Summ();
                        rpt1 = (ReportDocument)rptVoucherPurInvAllSumm;
                        this.reportTitle = "Purchase Invoice(Summary).";
                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetVoucherReport(strComID, strFdate, strTdate, strLedgerName, strLedgerName, intMode, strSelction).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;



                    case ViewerSelector.Pricelist:
                        rptPrice_List rptPriceList = new rptPrice_List();
                        rpt1 = (ReportDocument)rptPriceList;
                        this.reportTitle = "Price List (Component).";
                        this.secondParameter = strFdate;
                        InitialiseLabels(rpt1);
                        rpt1.SetDataSource(orpt.mGetPricelistReport(strComID, strStockItemName).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.rptPurchesAll:

                        List<AccBillwise> obilladdless1 = accms.DisplaycommonInvoiceAddlessDateWise(strComID, strFdate, strTdate, strLedgerName, intvType).ToList();
                        foreach (AccBillwise obili in obilladdless1)
                        {
                            if (obili.dblCreditAmount < 0)
                            {
                                dblAdd = dblAdd + obili.dblCreditAmount * -1;
                            }
                            else
                            {
                                dblLess = dblLess + obili.dblCreditAmount;
                            }
                        }
                        if (strString2 != "16")
                        {
                            dblAdd = 0;
                            dblLess = 0;
                        }
                        rptPurches_All1 rptPurchesAll = new rptPurches_All1();
                        rpt1 = (ReportDocument)rptPurchesAll;
                        if (strString2 == "33")
                        {
                            this.reportTitle = "Purchase Register";
                        }
                        if (strString2 == "16")
                        {
                            this.reportTitle = "Sales Register";
                        }
                        if (strString2 == "32")
                        {
                            this.reportTitle = "Purchase Return Register";
                        }
                        if (strString2 == "13")
                        {
                            this.reportTitle = "Sales Return ";
                        }
                        if (strString2 == "15")
                        {
                            this.reportTitle = "Sales Return Register";
                        }
                        if (strString2 == "17")
                        {
                            this.reportTitle = "Sample Register";
                        }

                        this.secondParameter = strFdate + " to " + strTdate;
                        InitialiseLabels(rpt1);
                        if (strLedgerName != "")
                        {
                            rpt1.SetDataSource(objWoIS.mGetPurchaseRegisterReport(strComID, strFdate, strTdate, strLedgerName, strString2,strBranchID).ToList());
                        }
                        else
                        {
                            rpt1.SetDataSource(objWoIS.mGetPurchaseRegisterReport(strComID, strFdate, strTdate, strLedgerName, strString2, strBranchID).ToList());
                        }
                        rpt1.Subreports[0].SetDataSource(obilladdless1.ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        rpt1.SetParameterValue("Add", dblAdd);
                        rpt1.SetParameterValue("Less", dblLess);
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.rptPurchesSumm:
                        if (strString2 == "16" || strString2 == "33")
                        {
                            List<AccBillwise> obilladdlessSumm = accms.DisplaycommonInvoiceAddlessDateWise(strComID, strFdate, strTdate, "", intvType).ToList();
                            foreach (AccBillwise obili in obilladdlessSumm)
                            {
                                if (obili.dblCreditAmount < 0)
                                {
                                    dblAdd = dblAdd + obili.dblCreditAmount * -1;
                                }
                                else
                                {
                                    dblLess = dblLess + obili.dblCreditAmount;
                                }
                            }
                        }

                        rptPurches_Register_sum rptPurchesRegisterSum = new rptPurches_Register_sum();
                        rpt1 = (ReportDocument)rptPurchesRegisterSum;
                        if (strString2 == "33")
                        {
                            this.reportTitle = "Purchase Register";
                        }
                        if (strString2 == "16")
                        {
                            this.reportTitle = "Sales Register";
                        }
                        if (strString2 == "32")
                        {
                            this.reportTitle = "Purchase Return Register";
                        }
                        if (strString2 == "13")
                        {
                            this.reportTitle = "Sales Return ";
                        }
                        if (strString2 == "15")
                        {
                            this.reportTitle = "Sales Return Register";
                        }
                        if (strString2 == "17")
                        {
                            this.reportTitle = "Sample Register";
                        }
                        this.secondParameter = strFdate + " to " + strTdate;

                        rpt1.SetDataSource(objWoIS.mGetPurchaseRegisterReport(strComID, strFdate, strTdate, strLedgerName, strString2, strBranchID).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        rpt1.SetParameterValue("InSupress", intSuppress);
                        rpt1.SetParameterValue("Add", dblAdd);
                        rpt1.SetParameterValue("Less", dblLess);
                        InitialiseLabels(rpt1);
                        ShowReport(rpt1, false, "");
                        break;

                    case ViewerSelector.VoucherSalesChalan:
                        if (intMode == 0)
                        {
                            rptVoucher_Sales_Chalan_All_Details rptVoucherSalesChalanAllDetails = new rptVoucher_Sales_Chalan_All_Details();
                            rpt1 = (ReportDocument)rptVoucherSalesChalanAllDetails;
                            this.reportTitle = strString2;
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(objWoIS.mGetVoucherSalesChalan(strComID, intvType, strFdate, strTdate, strLedgerName, strString2, intMode).ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                            break;
                        }
                        if (intMode == 1)
                        {
                            rptVoucher_Sales_Chalan_Indvi_Details rptVoucherSalesChalanIndviDetails = new rptVoucher_Sales_Chalan_Indvi_Details();
                            rpt1 = (ReportDocument)rptVoucherSalesChalanIndviDetails;
                            this.reportTitle = strString2;
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(objWoIS.mGetVoucherSalesChalan(strComID, intvType, strFdate, strTdate, strLedgerName, strString2, intMode).ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                            break;
                        }
                        if (intMode == 2)
                        {
                            if (strSelction == "Sum")
                            {
                                rptVoucher_Pur_Inv_All_Summ2 rptVoucher_Pur_Inv_All_Summ2 = new rptVoucher_Pur_Inv_All_Summ2();
                                rpt1 = (ReportDocument)rptVoucher_Pur_Inv_All_Summ2;
                                this.secondParameter = strFdate + " to " + strTdate;
                                this.reportTitle = strString2;

                                rpt1.SetDataSource(orpt.mGetVoucherReport(strComID, strFdate, strTdate, strLedgerName, "", intvType, strSelction).ToList());
                                crystalReportViewer1.ReportSource = rpt1;
                                if (strLedgerName != null)
                                {
                                    rpt1.SetParameterValue("strLedgerName", strLedgerName);

                                }
                                InitialiseLabels(rpt1);
                                ShowReport(rpt1, false, "");
                                break;
                            }

                        }
                        if (intMode == 3)
                            if (strSelction == "Purchase")
                            {
                                rptVoucher_Sales_Chalan_Voucher_Det_Sum_Purch rptVoucherSalesChalanAllSumm = new rptVoucher_Sales_Chalan_Voucher_Det_Sum_Purch();
                                rpt1 = (ReportDocument)rptVoucherSalesChalanAllSumm;
                                this.reportTitle = strString2;
                                if (strFdate != "")
                                {
                                    this.secondParameter = strFdate + " to " + strTdate;
                                }
                                else
                                {
                                    this.secondParameter = "";
                                }
                                InitialiseLabels(rpt1);
                                rpt1.SetDataSource(objWoIS.mGetVoucherSalesChalan(strComID, intvType, strFdate, strTdate, strLedgerName, strString2, intMode).ToList());
                                crystalReportViewer1.ReportSource = rpt1;
                                ShowReport(rpt1, false, "");
                                break;
                            }
                            else
                            {
                                {
                                    rptVoucher_Sales_Chalan_Voucher_Det_Sum rptVoucherSalesChalanAllSumm = new rptVoucher_Sales_Chalan_Voucher_Det_Sum();
                                    rpt1 = (ReportDocument)rptVoucherSalesChalanAllSumm;
                                    this.reportTitle = strString2;
                                    if (strFdate != "")
                                    {
                                        this.secondParameter = strFdate + " to " + strTdate;
                                    }
                                    else
                                    {
                                        this.secondParameter = "";
                                    }
                                    string strAgnstRef = Utility.mGetAgstRefNo(strComID, strLedgerName.Replace("'", "''"));
                                    InitialiseLabels(rpt1);
                                    rpt1.SetDataSource(objWoIS.mGetVoucherSalesChalan(strComID, intvType, strFdate, strTdate, strLedgerName, strString2, intMode).ToList());
                                    crystalReportViewer1.ReportSource = rpt1;
                                    rpt1.SetParameterValue("AGNSR_REF_NO", strAgnstRef);
                                    rpt1.SetParameterValue("ComName", Utility.gstrCompanyName);
                                    ShowReport(rpt1, false, "");
                                    break;
                                }
                            }
                        if (intMode == 4)
                        {
                            rptVoucher_Sales_Chalan_Voucher_Det_Sum rptVoucherSalesChalanAllSumm = new rptVoucher_Sales_Chalan_Voucher_Det_Sum();
                            rpt1 = (ReportDocument)rptVoucherSalesChalanAllSumm;
                            this.reportTitle = strString2;
                            this.secondParameter = strFdate + " to " + strTdate;
                            InitialiseLabels(rpt1);
                            rpt1.SetDataSource(objWoIS.mGetVoucherSalesChalan(strComID, intvType, strFdate, strTdate, strLedgerName, strString2, intMode).ToList());
                            crystalReportViewer1.ReportSource = rpt1;
                            ShowReport(rpt1, false, "");
                            break;
                        }
                        break;
                    case ViewerSelector.VouchearVouNoReturn:

                        rptIReturnnvoice rptreturnInvoice = new rptIReturnnvoice();
                        rpt1 = (ReportDocument)rptreturnInvoice;
                        if (strFdate != "")
                        {
                            this.secondParameter = strFdate + " to " + strTdate;
                        }
                        else
                        {
                            this.secondParameter = "";
                        }
                        this.reportTitle = strString2;
                        rpt1.SetDataSource(orpt.mGetVoucherReportRefNo(strComID, strLedgerName, "", intMode).ToList());
                        rpt1.Subreports[0].SetDataSource(orpt.mGetVoucherAddless(strComID, strLedgerName, strSelction).ToList());
                        crystalReportViewer1.ReportSource = rpt1;
                        InitialiseLabels(rpt1);
                        intSuppress = 0;
                        rpt1.SetParameterValue("intSuppress", 0);
                        rpt1.SetParameterValue("ComName", Utility.gstrCompanyName);
                        ShowReport(rpt1, false, "");
                        break;

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.PrintReport();
        }




    }
}
