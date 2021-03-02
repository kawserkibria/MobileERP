using JA.Accounts.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JA.Accounts.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISWJAG" in both code and config file together.
    [ServiceContract]
    public interface ISWJAG
    {
        [OperationContract]
        Dictionary<string, string> mFillBranchAllNew(string strDeComID, bool vblngAccessControl, string vstrUserName);
        [OperationContract]
        List<AccountsLedger> GetCustomerLedger(string strDeComID);
        [OperationContract]
        string GetPFLegder(string strComId, string strLedgerName);
        [OperationContract]
        string GetHLLegder(string strComId, string strLedgerName);

        [OperationContract]
        List<AccountsLedger> mFillPFLedger(string strDeComID, long vlngGroup);
        
        [OperationContract]
        string mInsertPrivilegesNew(string strDeComID, string strUserName, int intPriModule, int lngAccess, string strstring, int intmode);
        [OperationContract]
        List<AccountsLedger> mLedgerSecurity(string strDeComID, string vstrRoot, string vstrUserName);
        [OperationContract]
        Dictionary<string, string> mFillSecurityGroup(string strDeComID);
        [OperationContract]
        List<AccountsLedger> gLoadLegderPrivilegesRight(string strDeComID, string strUserName);
        [OperationContract]
        string mSaveGraceMonthConfig(string strDeComID, string strMonthID, string vstrfromDate, string vstrtodate, string vstrGfromDate, string vstrGtodate, string vstrStatus);
        [OperationContract]
        string mUpdateGraceMonthConfig(string strDeComID, string stroldMonthID, string strMonthID, string vstrfromDate, string vstrtodate, string vstrGfromDate, string vstrGtodate, string vstrStatus);
        [OperationContract]
        List<AccountdGroup> mDisplayGraceMonthsetupList(string strDeComID, string strMonthId);
        [OperationContract]
        List<AccountdGroup> mGetGraceDateFromMonthID(string strDeComID, string strMonthId);
        [OperationContract]
        string mDeleteGraceMonthList(string strDeComID, string strMonthID);
        [OperationContract]
        List<AccountsLedger> mFillLedgerSelectionProjection(string strDeComID, long lngGroup, string strMode, string stString, string struserName);
        [OperationContract]
        List<AccBillwise> gFillPreRefNoNew2(string strDeComID, string vstrPartyName,
                        long vlngVType, string vstrDate, string vstrBranchID, string vstrGodown, string strvstrRefNo, int intstatus);
        [OperationContract]
        List<AccBillwise> gFillPreRefNoNew(string strDeComID, string vstrPartyName,
                        long vlngVType, string vstrDate, string vstrBranchID, string vstrGodown, string strvstrRefNo, int intstatus, string strTDate);
        [OperationContract]
        List<AccountsLedger> mDisplayDraftLedger(string strDeComID, string strMonthID, string strLedgerName);
        [OperationContract]
        List<AccountsLedger> mFillLedgerSelection(string strDeComID, long lngGroup, string strMode, string stString);
        [OperationContract]
        List<AccountdGroup> GetHondaLoanGroupList(string strDeComID, long mlngGroupAs, bool vblngAccessControl, string vstrUserName, int intMode);
        [OperationContract]
        List<AccountsLedger> mFillTransferList(string strDeComID);
        [OperationContract]
        string mDeleteTransfer(string strDeComID, string strFromTransfer);
        [OperationContract]
        string mSaveLoanTransfer(string strDeComID, string strFromTransfer, string strToTransfer, string strNarration);
        [OperationContract]
        List<AccountsLedger> mFillHLLedger(string strDeComID, long vlngGroup, int intStatus);
        [OperationContract]
        List<AccountsLedger> mGetInstallmentNo(string strDeComID, string strLegdername, string strInstallment);
        [OperationContract]
        string DeleteTemplate(string strDeComID, string mstrConfiglkey);
        [OperationContract]
        List<AccountsLedger> mFillLoanList(string strDeComID);
        [OperationContract]
        List<AccountsLedger> mDisplayLoanList(string strDeComID, string strTemplateName);
        [OperationContract]
        string mSaveLoanMaster(string strDeComID, string strOldTemplateName, string strTemplateName,
                                             double dblTotalAmount, long lngNoOfInstall, string strInstallmentName,
                                             double dblMonthly, int intDel);
        [OperationContract]
        double mFillDisplayManualBill(string strDeComID, string strmonth, string strMpo, string strLedger);
        [OperationContract]
        string DeleteManualMpoCmm(string strDeComID, string mstrConfiglkey);
        [OperationContract]
        List<AccountsLedger> mFillDisplayBill(string strDeComID, string strKey);
        [OperationContract]
        List<AccountsLedger> mFillManualBill(string strDeComID);
        [OperationContract]
        string mInsertMpoManual(string strDeComID, string strKey, string strMonthID, string strBranchID, string strLedgerName, string strHeadName, double dblAmount, int intDel, int intCols, int intRow);
        [OperationContract]
        List<AccountsVoucher> mFillLedgerListMpoPercen(string strDeComID, string strLedgerName, string strMPOName);
        [OperationContract]
        string mInsertMpoPercentage(string strDeComID, string strLedgerName, string strMPOName, double dblPercentage, double dblAmount, string strEffectiveDate, int intDel, int intStatus);
        [OperationContract]
        string mUpdateBankReconcilation(string strDeComID, string strRefKey, string strRefNo, string strBankDate, string strBankPer, double dblBankAmount);
        [OperationContract]
        List<AccountsVoucher> mDisplayBankReconcilation(string strDeComID, string strLedgerName, string strfDate, string strTDate);
        [OperationContract]
        List<AccountsLedger> mGetBankLedger(string strDeComID);
        [OperationContract]
        List<AccountsLedger> mFillLedgerStatus(string strDeComID, long vlngGroup, int intStatus);
        [OperationContract]
        List<AccountsLedger> mFillLedgerListTARGET(string strDeComID, string strBranchID);
        [OperationContract]
        string mUpdateOnLineApprove(string strDeComID, string strRefNo, int intstatus, string strUserName);
        [OperationContract]
        string mUpdateOnLineSecurty(string strDeComID, long lngslNo, string strUserId, string password, int intaccesslevel, string securityCode);
        [OperationContract]
        List<UserAccess> mFillOnlineSecurity(string strDeComID);
        [OperationContract]
        string UpdateReceiptVoucherCustomer(string strDeComID, string vstrDrcr, string vstrRefNumber, long vlngVoucherType, string vdteDate, string vstrMonthID, string vdteDueDate, string vstrLedgerName,
                                             string vstrReverseLedgerName, int intvoucherPosition, double vdblNetAmount, string strChecqNo, string strChekdate, string strDawnon,
                                             double vdblDebitAmount, double vdblCreditAmount, string vstrNarratirons, string vstrBranchID, string DgCostCenter, bool blngNumMethod,int intSP);
        [OperationContract]
        string SaveReceiptVoucherCustomer(string strDeComID, string vstrDrcr, string vstrRefNumber, long vlngVoucherType, string vdteDate, string vstrMonthID, string vdteDueDate, string vstrLedgerName,
                                            string vstrReverseLedgerName, int intvoucherPosition, double vdblNetAmount, string strChecqNo, string strChekdate, string strDawnon,
                                            double vdblDebitAmount, double vdblCreditAmount, string vstrNarratirons, string vstrBranchID, string DgCostCenter, bool blngNumMethod, int intSP);
        [OperationContract]
        List<AccountsVoucher> mGetChequeRefNo(string strDeComID, int mintVType, string mdteVFromDate, string mdteVToDate, int intSP);
        [OperationContract]
        List<AccBillwise> DisplaycommonInvoiceAddlessDateWise(string strDeComID, string strfDate, string strtDate, string strLedgerName, int intvtype);
        [OperationContract]
        string mSaveBudget(string strDeComID, string strKey, string strDG);
        [OperationContract]
        string mUpdateBudget(string strDeComID, string strOldKey, string strKey, string strDG);
        [OperationContract]
        List<AccountdGroup> mLoadBudgetList(string strDeComID);
        [OperationContract]
        List<AccountdGroup> mDisplayBudgetList(string strDeComID, string vstrBudget);
        [OperationContract]
        string mDeletBudgetList(string strDeComID, string strOldKey);
        [OperationContract]
        string mDeleteUserControl(string strDeComID, long lngslNo, string strUserName);
        [OperationContract]
        List<AccountdGroup> mFillGroupSales(string strDeComID, int mlngLedgerAs);
        [OperationContract]
        double mGetGroupClosing(string strDeComID, string strFdate, string strTDate, string vstrGroupName, string strBranchID);
        [OperationContract]
        List<AccountdGroup> mGetDateFromMonthID(string strDeComID, string strMonthId);
        //List<FixedAssets> mDisplayAssetListLedger(string strDeComID, string mstrLedgerName);
        [OperationContract]
        List<FixedAssets> mDisplayFixedAssestAccOpening(string strDeComID, string strOldLedgerName);
        [OperationContract]
        string gOpenComID(string strID);
        
        [OperationContract]
        string mChangePasswod(string strDeComID, string strUserName, string strNewPassword);
        [OperationContract]
        List<AccVoucherHeader> mFilVoucherPrintingShow(string strDeComID, int intVoucherTypeValue);
        [OperationContract]
        string mSaveVoucherPrinting(string strDeComID, string vstrVoucherHeader1, string vstrVoucherHeader2, string vstrVoucherHeader3, string vstrVoucherHeader4, string vstrVoucherHeader5, int intVoucherTypeValue, int intVoucherMinimize);
        [OperationContract]
        List<BackupPath> mGetBackupPath(string strDeComID);
        [OperationContract]
        List<AccountdGroup> GetDsmRsm_level4_userPrivilegesRight(string strDeComID, string strUserName);
        [OperationContract]
        List<AccountdGroup> GetDsmRsm_level4_userPrivileges(string strDeComID, string strUserName);
        [OperationContract]
        List<BranchConfig> mFillBranchUserPrivileges(string strDeComID, string strUserName);
        [OperationContract]
        List<BranchConfig> mFillBranchUserRight(string strDeComID, string strUser);
        [OperationContract]
        List<UserAccess> mDisplayPrivilegesMain(string strDeComID,string strLogInKey, int intPriModule);
        [OperationContract]
        List<UserAccess> mDisplayPrivilegesChild(string strDeComID, string strLogInKey);
        [OperationContract]
        string mInsertPrivileges(string strDeComID, string strUserName, int intPriModule, int lngAccess, string strstring, string strString1, string strSelection);
        [OperationContract]
        List<AccountdGroup> GetDsmRsm_level4(string strDeComID);
        [OperationContract]
        string mSaveFormConfig(string strDeComID,string strformKey, string strNormalName, int intModuletype, int intModeType, int intStatus);
        [OperationContract]
        string mUpdateFormConfig(string strDeComID,long lngslNo, string strformKey, string strNormalName, int intModuletype, int intModeType, int intStatus);
        [OperationContract]
        List<AccountdGroup> mDisplayFormList(string strDeComID,int intModule);

        [OperationContract]
        List<AccountdGroup> GetAccountsTreeviewCR(string strDeComID);
        [OperationContract]
        List<AccountsLedger> mDisplayLedgerPercen(string strDeComID,string strLedgerName);
        [OperationContract]
        string mSaveMonthConfig(string strDeComID,string strMonthID, string vstrfromDate, string vstrtodate, string vstrStatus);
        [OperationContract]
        string mUpdateMonthConfig(string strDeComID,string stroldMonthID, string strMonthID, string vstrfromDate, string vstrtodate, string vstrStatus);
        [OperationContract]
        List<AccountdGroup> mDisplayMonthsetupList(string strDeComID,string strMonthId);
        [OperationContract]
        string mDeleteMonthList(string strDeComID,string strMonthID);

        [OperationContract]
        List<AccountsVoucher> mGetRefNo(string strDeComID, int mintVType, string mdteVFromDate, string mdteVToDate, int intSP);
        [OperationContract]
        List<AccountdGroup> mDisplayMonthTarget(string strDeComID,string strFromDate, string strToDate,string strPartyname);
        [OperationContract]
        double mGetLedgerClosing(string strDeComID,string strFdate, string strTDate, string vstrLedgerName, string strBranchID);
        [OperationContract]
        double mGetLedgerOpening(string strDeComID,string strFdate, string strTDate, string vstrLedgerName, string strBranchID);
        [OperationContract]
        Dictionary<string, string> mfillBranchNew(string strDeComID,bool vblngAccessControl, string vstrUserName);
        [OperationContract]
        List<AccountsLedger> mLedgerAdditemMr(string strDeComID, string vstrRoot, int intstatus);
        [OperationContract]
        List<Teritorry> mFillTeritorrySI(string strDeComID,string strCode);
        [OperationContract]
        List<AccountdGroup> GetAccountsTreeviewDR(string strDeComID);
        [OperationContract]
        List<VectorCategory> mFillLedgerNameVector(string strDeComID);
        [OperationContract]
        void DoWork();
        [OperationContract]
        Dictionary<string, string> GetAccountsGroup(string strDeComID);
        [OperationContract]
        short InsertGroup(string strDeComID, string strGroupName, string strUnder, string strCashflowType, string strAccountType, string strMobileNo, string strConatctNo, int intPosition);
        [OperationContract]
        List<AccountdGroup> GetAccountsTreeview(string strDeComID);
        [OperationContract]
        List<AccountdGroup> GetGroupList(string strDeComID,long mlngGroupAs, bool vblngAccessControl, string vstrUserName);
        [OperationContract]
        short mUpdateGroup(string strDeComID, long mlngGroupSerial, string strGroupName, string strUnder, string strCashflowType, string strAccountType, string strMobileNo, string strConatctNo, int intPosition);
        [OperationContract]
        string DeleteGroup(string strDeComID,long mlngGroupSerial);
        [OperationContract]
        List<AccountsLedger> mFillCurrencyList(string strDeComID);
        [OperationContract]
        List<AccountdGroup> mFillGroup(string strDeComID,int mlngLedgerAs);
        [OperationContract]
        string mDisplayOpening(string strDeComID);
        [OperationContract]
        string mInsertCostCategory(string strDeComID,string strCostCategory);
        [OperationContract]
        string mUpdateCostCategory(string strDeComID,string stroldCostCategory, string strNewCostCategory);
        [OperationContract]
        List<VectorCategory> mFillVectorCategory(string strDeComID);
        [OperationContract]
        string DeleteCostCategory(string strDeComID,string strCostCategory);

        [OperationContract]
        string mInsertCostCenter(string strDeComID,string strCostCenter, string strCostCategory);
        [OperationContract]
        string mUpdateCostCenter(string strDeComID,string stroldCostCenter, string strCostCenter, string strCostCategory);
        [OperationContract]
        string DeleteCostCenter(string strDeComID,string stroldCostCenter);
        [OperationContract]
        List<VectorCategory> mFillCostCenter(string strDeComID);
        [OperationContract]
        List<VectorCategory> mFillVectorMaster(string strDeComID,string vstrVectorCategory);
        [OperationContract]
        List<BranchConfig> mFillBranch(string strDeComID,bool vblngAccessControl, string vstrUserName);
        [OperationContract]
        string mSaveLedger(string strDeComID,string vsstrLedgerName, string vstrParent, string vstrEMail, string vstrFax, string vstrAddress1,
                                     string vstrAddress2, string vstrcity, string vstrPostal, string vstrPhone, string vstrComments, string vstrCurrency,
                                     string strInvEffectStock, string strInactive, string strCostCenter, string strDrcr, double dblopnBalance,
                                     string strcostcenterGrid, string strBranchGrid,
                                     double dblFixedPurhaseAmount, string strEffectoveForm, long lngReducingBal,
                                     double dblAssetsLife, double dblDepRate, double dblAccDep, double dblWrittendownvalue,
                                     double dblSalvageValue, double lngAssetPercent, string strAssetsGrid, string strAssetsGridAccu, string strPFAmount);

        [OperationContract]
        List<AccountsLedger> mLedgerAdditem(string strDeComID, string vstrRoot, int intstatus);
        [OperationContract]
        List<AccountsLedger> mFillLedgerListNew(string strDeComID, int mintLedgerGroup, int intStatus, string strMySQL, int intlaodType);
        [OperationContract]
        List<AccountsLedger> mFillLedgerList(string strDeComID, int mintLedgerGroup);
        [OperationContract]
        List<AccountsLedger> mDisplayLedgerList(string strDeComID,long vlngLedgerSerial);
        [OperationContract]
        List<VectorCategory> mDisplayVectorCategory(string strDeComID,string strOldLedgerName);
        [OperationContract]
        List<BranchConfig> mDisplayBranchOpening(string strDeComID, string strOldLedgerName, string strBranchID);
        [OperationContract]
        List<FixedAssets> mDisplayFixedAssest(string strDeComID,string strOldLedgerName);
        [OperationContract]
        List<FixedAssets> mDisplayFixedAssestOpening(string strDeComID,string strOldLedgerName);
        [OperationContract]
        List<AccountsLedger> DisplayAccountsTemplate(string strDeComID, string vstrSalesSerial);
        [OperationContract]
        string mUpdateLedger(string strDeComID,string strOldLedger, long mlngLedgerSerial, string vsstrLedgerName, string vstrParent, string vstrEMail, string vstrFax, string vstrAddress1,
                                    string vstrAddress2, string vstrcity, string vstrPostal, string vstrPhone, string vstrComments, string vstrCurrency,
                                    string strInvEffectStock, string strInactive, string strCostCenter, string strDrcr, double dblopnBalance,
                                    string strcostcenterGrid, string strBranchGrid,
                                    double dblFixedPurhaseAmount, string strEffectoveForm, long lngReducingBal,
                                    double dblAssetsLife, double dblDepRate, double dblAccDep, double dblWrittendownvalue,
                                    double dblSalvageValue, double lngAssetPercent, string strAssetsGrid, string strAssetsGridAccu, string strPFAmount);

        [OperationContract]
        string DeleteLedger(string strDeComID,long mlngledgerSerial);
        [OperationContract]
        List<AccountsLedger> mFillLedger(string strDeComID, int vIntGroup, string vstrPrefix, string vstrPrefix1, string vstruserName);
        [OperationContract]
        string mInsertTempVector(string strDeComID,string strstring);
        [OperationContract]
        string SaveVoucher(string strDeComID,string strVoucherGrid, string vstrDrcr, string vstrRefNumber, long vlngVoucherType, string vdteDate, string vstrMonthID, string vdteDueDate, string vstrLedgerName,
                                                 string vstrReverseLedgerName, int intvoucherPosition, long lngCashFlow, string vstrVoyageNo, double vdblAmount, double vdblNetAmount,
                                                 double vdblAddAmount, double vdblLessAmount, double vdblDebitAmount, double vdblCreditAmount, double dblFCCurrencyDebit, double dblFCCurrencyCredit,
                                                 string mstrFCsymbol, double mdblCurrRate, long vlngAgstType, string vstrSingleNarration, string vstrNarrations, string vstrBranchID,
                                                 string DgCostCenter, string DGBillWise, bool blngNumMethod, long vlngIsMultiCurrency = 0,
                                                 string vstrChecuqNo = "", string vstrChequedate = "", string vstrDrawnon = "", string vstrAgnstRefNo = "", string vstrSalesRep = "", string vstrDelivery = "",
                                                 string vstrPayment = "", string vstrSupport = "", string vstrValidaty = "", string vstrOtherTerms = "", int SpJounal = 0,
                                                 string strDginvEffect = "", string strGrdTemPlate = "", string strGrdTemPlateJV = "", int intLoanTransfer = 0);
        [OperationContract]

        string UpdateVoucher(string strDeComID,string strVoucherGrid, string vstrDrcr, string vstrRefNumber, long vlngVoucherType, string vdteDate, string vstrMonthID, string vdteDueDate, string vstrLedgerName,
                                                 string vstrReverseLedgerName, int intvoucherPosition, long lngCashFlow, string vstrVoyageNo, double vdblAmount, double vdblNetAmount,
                                                 double vdblAddAmount, double vdblLessAmount, double vdblDebitAmount, double vdblCreditAmount, double dblFCCurrencyDebit, double dblFCCurrencyCredit,
                                                 string mstrFCsymbol, double mdblCurrRate, long vlngAgstType, string vstrSingleNarration, string vstrNarrations, string vstrBranchID,
                                                 string DgCostCenter, string DGBillWise, long vlngIsMultiCurrency = 0,
                                                 string vstrChecuqNo = "", string vstrChequedate = "", string vstrDrawnon = "", string vstrAgnstRefNo = "", string vstrSalesRep = "", string vstrDelivery = "",
                                                 string vstrPayment = "", string vstrSupport = "", string vstrValidaty = "", string vstrOtherTerms = "",
                                                 string strDginvEffect = "", string strGrdTemPlate = "", string strGrdTemPlateJV = "", int intLoanTransfer = 0);
        //[OperationContract]
        //List<AccountsVoucher> mOpenTable(string strDeComID, int mintVType, string strFind, string strExpression, string mdteVFromDate = "", string mdteVToDate = "", int intSPJ = 0, string strmySql = "");
        [OperationContract]
        List<AccountsVoucher> DisplayCompVoucherList(string strDeComID,string vstrVoucherRefNumber, long mlngVoucherAs);
        [OperationContract]
        List<AccountsVoucher> DisplayVoucherList(string strDeComID, string vstrVoucherRefNumber, long mlngVoucherAs, int intSP);
        [OperationContract]
        List<VectorCategory> DisplayVectorList(string strDeComID,string vstrVoucherRefNumber);
        [OperationContract]
        string mSaveBranchInfo(string strDeComID,string vstrBranchName, string vstrAddress1, string vstrAddress2, string vstrCountry, string vstrPhone,
                                    string vstrFax, string vstrEmail, string vstrComment, string vstrDefaultBranch, string vstInactive, string vstrGodown);

        [OperationContract]
        List<BranchConfig> mFillGetBranch(string strDeComID);
        [OperationContract]
        string mUpdateBranchInfo(string strDeComID,string vstrBranchID, string vstrBranchName, string vstrAddress1, string vstrAddress2, string vstrCountry, string vstrPhone,
                                       string vstrFax, string vstrEmail, string vstrComment, string vstrDefaultBranch, string vstInactive, string vstrGodown);
        [OperationContract]
        string mDeleteBranchInfo(string strDeComID,string vstrBranchID, string vstrLedgerName);
        [OperationContract]
        string mSaveFixedAssets(string strDeComID,string vsstrLedgerName,
                                double dblFixedPurhaseAmount, string strEffectoveForm, long lngReducingBal,
                                double dblAssetsLife, double dblDepRate, double dblAccDep, double dblWrittendownvalue,
                                double dblSalvageValue, double lngAssetPercent, string strAssetsGrid, string strDGAccBra);

        [OperationContract]
        List<FixedAssets> mAssetList(string strDeComID);
        [OperationContract]
        List<FixedAssets> mDisplayAssetList(string strDeComID,long mlngAssetSerial);
        [OperationContract]
        List<FixedAssets> mDisplayFixedBranchList(string strDeComID,string mstrLedgerName);
        [OperationContract]
        string mUpdateFixedAssets(string strDeComID,long mlngAssetSerial, string mstrOldLedger, string vsstrLedgerName,
                                      double dblFixedPurhaseAmount, string strEffectoveForm, long lngReducingBal,
                                      double dblAssetsLife, double dblDepRate, double dblAccDep, double dblWrittendownvalue,
                                      double dblSalvageValue, double lngAssetPercent, string strAssetsGrid, string strDGAccBra);
        [OperationContract]
        string mDeleteFixedAssets(string strDeComID,long mlngAssetSerial, string mstrOldLedger);
        [OperationContract]
        string mInsertAssetsAdjustment(string strDeComID,string vstrRefNo, string mstrPrimaryKey, string vstrDate, string vstrBranchName, string vstrLedgerName, double dblAmount);
        [OperationContract]
        List<FixedAssets> mGetFixedAssetsAdjustment(string strDeComID);
        [OperationContract]
        string mDeleteAssetsAdjustment(string strDeComID,string mstrPrimaryKey);
        [OperationContract]
        string mSaveCustomerLedger(string strDeComID,string vstrBranchID, string vsstrLedgerName, string vstrParent, string strPriceLevel, string strLedgerAddDate, string vstrEMail,
                                         string vstrFax, string vstrAddress1, string vstrAddress2, string vstrcity, string vstrCountry,
                                         string vstrContractPer, string vstrPostal, string vstrPhone, string vstrComments, string vstrCurrency,
                                         string strBillWise, string strInactive, string strCostCenter, string strDrcr, double dblopnBalance,
                                         string strcostcenterGrid, string strBranchGrid, string strBillwiseGrid,
                                         double dblCreditLimit, double dblCreditPeriod, string strFinancialForm, string strResignDate,
                                         int intCommission, string strTerritorycode, string strTerritoryName, string strClass, int intBkash, string strCloseDate, string strPFLedger, string strHLLedger);
        [OperationContract]
        List<AccBillwise> mLoadBillWise(string strDeComID,string strOldLedgerName);
        [OperationContract]
        string mUpDateCustomerLedger(string strDeComID,string mstrOldLedger, string vstrBranchID, long mlngLedgerSerial, string vsstrLedgerName, string vstrParent, string strPriceLevel,
                                             string strLedgerAddDate, string vstrEMail, string vstrFax, string vstrAddress1, string vstrAddress2, string vstrcity,
                                             string vstrCountry, string vstrContractPer, string vstrPostal, string vstrPhone, string vstrComments, string vstrCurrency,
                                             string strBillWise, string strInactive, string strCostCenter, string strDrcr, double dblopnBalance,
                                             string strcostcenterGrid, string strBranchGrid, string strBillwiseGrid,
                                             double dblCreditLimit,
                                             double dblCreditPeriod, string strFinancialForm, string strResignDate, int intCommission, string strTerritorycode,
                                             string strTerritoryName, string strClass, int intBkash, string strCloseDate, string strPFLedger, string strHLLedger);

        [OperationContract]
        List<AccBillwise> DisplayBillWise(string strDeComID,string vstrVoucherRefNumber);
        [OperationContract]
        List<AccBillwise> gFillPreRefNo(string strDeComID,string vstrPartyName,
                                long vlngVType, string vstrDate, string vstrBranchID, string vstrGodown, string strvstrRefNo, int intstatus);

        [OperationContract]
        List<AccBillwise> DisplayCommonInvoice(string strDeComID,string vstrVoucherRefNumber);
        [OperationContract]
        List<AccBillwise> DisplaycommonInvoiceOrder(string strDeComID,string vstrBillKey, int mlngVType);
        [OperationContract]
        List<AccBillwise> DisplaycommonInvoiceAddless(string strDeComID,string vstrSalesSerial);
        [OperationContract]
        List<AccBillwise> DisplaycommonInvoiceBill(string strDeComID,string vstrSalesSerial);
        [OperationContract]
        List<AccountsLedger> DisplaycommonInvoiceVoucher(string strDeComID,string vstrSalesSerial);
        [OperationContract]
        string mInsertUser(string strDeComID,string vstrLogInName, string vstrFullName, string vstrDepatrtment, string vstrDesignation,
                                             string vstrPassword, string vstrUserLevel, string vstrAccessLevel, string vstrComments, byte[] vImage);

        [OperationContract]
        List<UserAccess> mGetUserAccessData(string strDeComID,string strLogInName);
        [OperationContract]
        string mUpdateInsertUser(string strDeComID,string vstrmstrPk, string vstrLogInName, string vstrFullName, string vstrDepatrtment, string vstrDesignation,
                                              string vstrPassword, string vstrUserLevel, string vstrAccessLevel, string vstrComments, byte[] vImage);
        //[OperationContract]
        //byte[] GetImage(string strLogInName);

        //[OperationContract]
        //string sevetest(byte[] img);
        //[OperationContract]
        //byte[] ReadImage(long ID);
        [OperationContract]
        List<VoucherTypes> mLaodVoucherTypes(string strDeComID,long mlngmoduletype, long lngVtypeValue);
        [OperationContract]
        string mUpdteVoucherTypes(string strDeComID,long lngMtype, long mIntVoucherType, long lngNumericWidth, string vstrPrefix,
                                            string strNoMethod, string vstrSuffix, bool blngCheckVoucher, string vstrVoucherName, long lngStartNo,
                                            string strPrintYesOrNo, int intEffectBkash);

        [OperationContract]
        List<VoucherTypes> mGetConfig(string strDeComID,long vintVoucherType);
        [OperationContract]
        List<AccountsVoucher> DisplayQuotationVoucherList(string strDeComID,string vstrSalesSerial, long mlngVoucherAs);
        [OperationContract]
        List<AccBillwise> DisplayQuotationVoucherTranList(string strDeComID,string vstrSalesSerial, long mlngVoucherAs);
        [OperationContract]
        List<AccountsVoucher> mOpentableQuo(string strDeComID,int intVtype, string strFDate, string strTdate, string strRefNo);
        [OperationContract]
        List<AccountsLedger> GetSalesLedgerTree(string strDeComID);
        [OperationContract]
        List<AccountsLedger> GetSalesLedgerTreefromCustomer(string strDeComID,string strLedgerName);

        [OperationContract]
        List<AccountsLedger> mFillLedgerNew(string strDeComID,long vlngGroup);

        [OperationContract]
        List<Teritorry> mFillTeritorry(string strDeComID,string strCode);
        [OperationContract]
        string mUpdateTeritorry(string strDeComID,string strCode, string strName);
        [OperationContract]
        string DeletetTeritorry(string strDeComID,string strTeritorryCode);
        [OperationContract]
        string mInsertTeritorry(string strDeComID,string strCode, string strName);
        [OperationContract]
        List<AccBillwise> gFillPreSampleClass(string strDeComID);
        [OperationContract]
        List<UserAccess> mFillUsername(string strDeComID);

        [OperationContract]
        List<UserAccess> mFillExpenseList(string strDeComID);
        [OperationContract]
        string mInsertExpenseLedger(string strDeComID,string strConfiglKey, string strledgerName, string strEffectiveDate, long vlngVoucherType, string strGrid);
        [OperationContract]
        List<AccountsLedger> mDisplayLedgerlistt(string strDeComID,int mintLedgerGroup);
        [OperationContract]
        List<AccountsLedger> mDisplayLedgerConfig(string strDeComID,string masterKey);
        [OperationContract]
        List<AccountsLedger> mGetVoucherAmont(string strDeComID,string strFdate, string strTDate,string strCurrentYear, string strBranchId);
        [OperationContract]
        List<AccountsLedger> mGetVoucherTodaySalesAmont(string strDeComID,string strFdate, string strBranchId);
        [OperationContract]
        List<AccountsLedger> mGetVoucherDateRangeWiseSalesAmont(string strDeComID,string strFdate, string strTDate, string strBranchId);
        [OperationContract]
        List<AccountsLedger> mGetVoucherDateRangeWiseRecevedAmont(string strDeComID,string strFdate, string strTDate, string strBranchId);
        [OperationContract]
        string DeleteLedgerConfig(string strDeComID,string mstrConfiglkey);
    }
}
