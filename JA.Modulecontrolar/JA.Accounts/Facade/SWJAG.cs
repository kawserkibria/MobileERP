using JA.Accounts.Model;
using JA.Accounts.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace JA.Accounts.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SWJAG" in both code and config file together.
    public class SWJAG : ISWJAG
    {

        public List<AccountsLedger> GetCustomerLedger(string strDeComID)
        {
            return new JAccounts().GetCustomerLedger(strDeComID);
        }
        public string GetPFLegder(string strComId, string strLedgerName)
        {
            return new JAccounts().GetPFLegder(strComId, strLedgerName);
        }
        public string GetHLLegder(string strComId, string strLedgerName)
        {
            return new JAccounts().GetHLLegder(strComId, strLedgerName);
        }
        public List<AccountsLedger> mFillPFLedger(string strDeComID, long vlngGroup)
        {
            return new JAccounts().mFillPFLedger(strDeComID, vlngGroup);
        }
     
        public string mInsertPrivilegesNew(string strDeComID, string strUserName, int intPriModule, int lngAccess, string strstring, int intmode)
        {
            return new JAccounts().mInsertPrivilegesNew(strDeComID, strUserName, intPriModule, lngAccess, strstring, intmode);
        }
        public List<AccountsLedger> mLedgerSecurity(string strDeComID, string vstrRoot, string vstrUserName)
        {
            return new JAccounts().mLedgerSecurity(strDeComID, vstrRoot,vstrUserName);
        }
        public Dictionary<string, string> mFillSecurityGroup(string strDeComID)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("All", "All");
            foreach (AccountdGroup ogrp in new JAccounts().mFillSecurityGroup(strDeComID))
            {
                ooGrp.Add(ogrp.GroupName, ogrp.GroupName);
            }
            return ooGrp;
        }
        public Dictionary<string, string> mFillBranchAllNew(string strDeComID, bool vblngAccessControl, string vstrUserName)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("All", "All");
            foreach (BranchConfig ogrp in new JAccounts().mFillBranchAllNew(strDeComID, vblngAccessControl, vstrUserName))
            {
                ooGrp.Add(ogrp.BranchID, ogrp.BranchName);
            }
            return ooGrp;
        }
       
        public List<AccountsLedger> gLoadLegderPrivilegesRight(string strDeComID, string strUserName)
        {
            return new JAccounts().gLoadLegderPrivilegesRight(strDeComID, strUserName);
        }
        public string mSaveGraceMonthConfig(string strDeComID, string strMonthID, string vstrfromDate, string vstrtodate, string vstrGfromDate, string vstrGtodate, string vstrStatus)
        {
            return new JAccounts().mSaveGraceMonthConfig(strDeComID, strMonthID, vstrfromDate, vstrtodate, vstrGfromDate, vstrGtodate, vstrStatus);
        }
        public string mUpdateGraceMonthConfig(string strDeComID, string stroldMonthID, string strMonthID, string vstrfromDate, string vstrtodate, string vstrGfromDate, string vstrGtodate, string vstrStatus)
        {
            return new JAccounts().mUpdateGraceMonthConfig(strDeComID, stroldMonthID, strMonthID, vstrfromDate, vstrtodate, vstrGfromDate, vstrGtodate, vstrStatus);
        }
        public List<AccountdGroup> mDisplayGraceMonthsetupList(string strDeComID, string strMonthId)
        {
            return new JAccounts().mDisplayGraceMonthsetupList(strDeComID, strMonthId);
        }
        public List<AccountdGroup> mGetGraceDateFromMonthID(string strDeComID, string strMonthId)
        {
            return new JAccounts().mGetGraceDateFromMonthID(strDeComID, strMonthId);
        }
        public string mDeleteGraceMonthList(string strDeComID, string strMonthID)
        {
            return new JAccounts().mDeleteGraceMonthList(strDeComID, strMonthID);
        }
        public List<AccountsLedger> mFillLedgerSelectionProjection(string strDeComID, long lngGroup, string strMode, string stString, string struserName)
        {
            return new JAccounts().mFillLedgerSelectionProjection(strDeComID, lngGroup, strMode, stString, struserName);
        }

        public List<AccBillwise> gFillPreRefNoNew2(string strDeComID, string vstrPartyName,
                        long vlngVType, string vstrDate, string vstrBranchID, string vstrGodown, string strvstrRefNo, int intstatus)
        {
            return new JAccounts().gFillPreRefNoNew2(strDeComID, vstrPartyName,
                                                    vlngVType, vstrDate, vstrBranchID, vstrGodown, strvstrRefNo, intstatus);
        }
        public List<AccBillwise> gFillPreRefNoNew(string strDeComID, string vstrPartyName,
                        long vlngVType, string vstrDate, string vstrBranchID, string vstrGodown, string strvstrRefNo, int intstatus, string strTDate)
        {
            return new JAccounts().gFillPreRefNoNew(strDeComID, vstrPartyName,
                          vlngVType, vstrDate, vstrBranchID, vstrGodown, strvstrRefNo, intstatus, strTDate);
        }
        public List<AccountsLedger> mDisplayDraftLedger(string strDeComID, string strMonthID, string strLedgerName)
        {
            return new JAccounts().mDisplayDraftLedger(strDeComID, strMonthID, strLedgerName);
        }
        public List<AccountsLedger> mFillLedgerSelection(string strDeComID, long lngGroup, string strMode, string stString)
        {
            return new JAccounts().mFillLedgerSelection(strDeComID, lngGroup, strMode, stString);
        }
        public List<AccountdGroup> GetHondaLoanGroupList(string strDeComID, long mlngGroupAs, bool vblngAccessControl, string vstrUserName, int intMode)
        {
            return new JAccounts().GetHondaLoanGroupList(strDeComID, mlngGroupAs, vblngAccessControl, vstrUserName, intMode);
        }
        public List<AccountsLedger> mFillTransferList(string strDeComID)
        {
            return new JAccounts().mFillTransferList(strDeComID);
        }
        public string mDeleteTransfer(string strDeComID, string strFromTransfer)
        {
            return new JAccounts().mDeleteTransfer(strDeComID, strFromTransfer);
        }
        public string mSaveLoanTransfer(string strDeComID, string strFromTransfer, string strToTransfer, string strNarration)
        {
            return new JAccounts().mSaveLoanTransfer(strDeComID, strFromTransfer, strToTransfer, strNarration);
        }
        public List<AccountsLedger> mFillHLLedger(string strDeComID, long vlngGroup, int intStatus)
        {
            return new JAccounts().mFillHLLedger(strDeComID, vlngGroup, intStatus);
        }
        public List<AccountsLedger> mGetInstallmentNo(string strDeComID, string strLegdername, string strInstallment)
        {
            return new JAccounts().mGetInstallmentNo(strDeComID, strLegdername, strInstallment);
        }
        public string DeleteTemplate(string strDeComID, string mstrConfiglkey)
        {
            return new JAccounts().DeleteTemplate(strDeComID, mstrConfiglkey);
        }
        public List<AccountsLedger> mFillLoanList(string strDeComID)
        {

            return new JAccounts().mFillLoanList(strDeComID);
        }
        public List<AccountsLedger> mDisplayLoanList(string strDeComID, string strTemplateName)
        {
            return new JAccounts().mDisplayLoanList(strDeComID, strTemplateName);
        }
        public string mSaveLoanMaster(string strDeComID, string strOldTemplateName, string strTemplateName,
                                             double dblTotalAmount, long lngNoOfInstall, string strInstallmentName,
                                             double dblMonthly, int intDel)
        {
            return new JAccounts().mSaveLoanMaster(strDeComID, strOldTemplateName, strTemplateName, dblTotalAmount, lngNoOfInstall, strInstallmentName, dblMonthly, intDel);
        }
        public double mFillDisplayManualBill(string strDeComID, string strmonth, string strMpo, string strLedger)
        {
            return new JAccounts().mFillDisplayManualBill(strDeComID, strmonth, strMpo, strLedger);
        }
        public string DeleteManualMpoCmm(string strDeComID, string mstrConfiglkey)
        {
            return new JAccounts().DeleteManualMpoCmm(strDeComID, mstrConfiglkey);
        }
        public List<AccountsLedger> mFillDisplayBill(string strDeComID, string strKey)
        {
            return new JAccounts().mFillDisplayBill(strDeComID, strKey);
        }
        public List<AccountsLedger> mFillManualBill(string strDeComID)
        {
            return new JAccounts().mFillManualBill(strDeComID);
        }
        public string mInsertMpoManual(string strDeComID, string strKey, string strMonthID, string strBranchID, string strLedgerName, string strHeadName, double dblAmount, int intDel, int intCols, int intRow)
        {
            return new JAccounts().mInsertMpoManual(strDeComID, strKey, strMonthID, strBranchID, strLedgerName, strHeadName, dblAmount, intDel, intCols, intRow);
        }
        public List<AccountsVoucher> mFillLedgerListMpoPercen(string strDeComID, string strLedgerName, string strMPOName)
        {
            return new JAccounts().mFillLedgerListMpoPercen(strDeComID, strLedgerName, strMPOName);
        }
        public string mInsertMpoPercentage(string strDeComID, string strLedgerName, string strMPOName, double dblPercentage, double dblAmount, string strEffectiveDate, int intDel, int intStatus)
        {
            return new JAccounts().mInsertMpoPercentage(strDeComID, strLedgerName, strMPOName, dblPercentage, dblAmount, strEffectiveDate, intDel, intStatus);
        }
        public string mUpdateBankReconcilation(string strDeComID, string strRefKey, string strRefNo, string strBankDate, string strBankPer, double dblBankAmount)
        {
            return new JAccounts().mUpdateBankReconcilation(strDeComID, strRefKey, strRefNo, strBankDate, strBankPer, dblBankAmount);
        }
        public List<AccountsVoucher> mDisplayBankReconcilation(string strDeComID, string strLedgerName, string strfDate, string strTDate)
        {
            return new JAccounts().mDisplayBankReconcilation(strDeComID, strLedgerName, strfDate, strTDate);
        }
        public List<AccountsLedger> mGetBankLedger(string strDeComID)
        {
            return new JAccounts().mGetBankLedger(strDeComID);
        }
        public List<AccountsLedger> mFillLedgerStatus(string strDeComID, long vlngGroup, int intStatus)
        {
            return new JAccounts().mFillLedgerStatus(strDeComID, vlngGroup, intStatus);
        }
        public List<AccountsLedger> mFillLedgerListTARGET(string strDeComID, string strBranchID)
        {
            return new JAccounts().mFillLedgerListTARGET(strDeComID, strBranchID);
        }
        public string mUpdateOnLineApprove(string strDeComID, string strRefNo, int intstatus, string strUserName)
        {
            return new JAccounts().mUpdateOnLineApprove(strDeComID, strRefNo, intstatus, strUserName);
        }
        public string mUpdateOnLineSecurty(string strDeComID, long lngslNo, string strUserId, string password, int intaccesslevel, string securityCode)
        {
            return new JAccounts().mUpdateOnLineSecurty(strDeComID, lngslNo, strUserId, password, intaccesslevel,securityCode);
        }
        public List<UserAccess> mFillOnlineSecurity(string strDeComID)
        {
            return new JAccounts().mFillOnlineSecurity(strDeComID);
        }
        public string SaveReceiptVoucherCustomer(string strDeComID, string vstrDrcr, string vstrRefNumber, long vlngVoucherType, string vdteDate, string vstrMonthID, string vdteDueDate, string vstrLedgerName,
                                            string vstrReverseLedgerName, int intvoucherPosition, double vdblNetAmount, string strChecqNo, string strChekdate, string strDawnon,
                                            double vdblDebitAmount, double vdblCreditAmount, string vstrNarratirons, string vstrBranchID, string DgCostCenter, bool blngNumMethod, int intSP)
        {
            return new JAccounts().SaveReceiptVoucherCustomer(strDeComID, vstrDrcr, vstrRefNumber, vlngVoucherType, vdteDate, vstrMonthID, vdteDueDate, vstrLedgerName,
                                                vstrReverseLedgerName, intvoucherPosition, vdblNetAmount, strChecqNo, strChekdate, strDawnon,
                                                vdblDebitAmount, vdblCreditAmount, vstrNarratirons, vstrBranchID, DgCostCenter, blngNumMethod, intSP);
        }
        public string UpdateReceiptVoucherCustomer(string strDeComID, string vstrDrcr, string vstrRefNumber, long vlngVoucherType, string vdteDate, string vstrMonthID, string vdteDueDate, string vstrLedgerName,
                                           string vstrReverseLedgerName, int intvoucherPosition, double vdblNetAmount, string strChecqNo, string strChekdate, string strDawnon,
                                           double vdblDebitAmount, double vdblCreditAmount, string vstrNarratirons, string vstrBranchID, string DgCostCenter, bool blngNumMethod, int intSP)
        {
            return new JAccounts().UpdateReceiptVoucherCustomer(strDeComID, vstrDrcr, vstrRefNumber, vlngVoucherType, vdteDate, vstrMonthID, vdteDueDate, vstrLedgerName,
                                             vstrReverseLedgerName, intvoucherPosition, vdblNetAmount, strChecqNo, strChekdate, strDawnon,
                                             vdblDebitAmount, vdblCreditAmount, vstrNarratirons, vstrBranchID, DgCostCenter, blngNumMethod, intSP);
        }
        public List<AccountsVoucher> mGetChequeRefNo(string strDeComID, int mintVType, string mdteVFromDate, string mdteVToDate, int intSP)
        {
            return new JAccounts().mGetChequeRefNo(strDeComID, mintVType, mdteVFromDate, mdteVToDate, intSP);
        }
        public List<AccBillwise> DisplaycommonInvoiceAddlessDateWise(string strDeComID, string strfDate, string strtDate, string strLedgerName, int intvtype)
        {

            return new JAccounts().DisplaycommonInvoiceAddlessDateWise(strDeComID, strfDate, strtDate, strLedgerName, intvtype);
        }
        public string mSaveBudget(string strDeComID, string strKey, string strDG)
        {
            return new JAccounts().mSaveBudget(strDeComID, strKey, strDG);
        }
        public string mUpdateBudget(string strDeComID, string strOldKey, string strKey, string strDG)
        {
            return new JAccounts().mUpdateBudget(strDeComID, strOldKey, strKey, strDG);
        }
        public List<AccountdGroup> mLoadBudgetList(string strDeComID)
        {
            return new JAccounts().mLoadBudgetList(strDeComID);
        }
        public List<AccountdGroup> mDisplayBudgetList(string strDeComID, string vstrBudget)
        {
            return new JAccounts().mDisplayBudgetList(strDeComID, vstrBudget);
        }
        public string mDeletBudgetList(string strDeComID, string strOldKey)
        {
            return new JAccounts().mDeletBudgetList(strDeComID, strOldKey);
        }

        public string mDeleteUserControl(string strDeComID, long lngslNo, string strUserName)
        {
            return new JAccounts().mDeleteUserControl(strDeComID, lngslNo, strUserName);
        }
        public List<AccountdGroup> mFillGroupSales(string strDeComID, int mlngLedgerAs)
        {
            return new JAccounts().mFillGroupSales(strDeComID, mlngLedgerAs);
        }
        public double mGetGroupClosing(string strDeComID, string strFdate, string strTDate, string vstrGroupName, string strBranchID)
        {
            return new JAccounts().mGetGroupClosing(strDeComID, strFdate, strTDate, vstrGroupName, strBranchID);
        }
        public List<AccountdGroup> mGetDateFromMonthID(string strDeComID, string strMonthId)
        {
            return new JAccounts().mGetDateFromMonthID(strDeComID, strMonthId);
        }
        public List<FixedAssets> mDisplayFixedAssestAccOpening(string strDeComID, string strOldLedgerName)
        {
            return new JAccounts().mDisplayFixedAssestAccOpening(strDeComID, strOldLedgerName);
        }
        public string gOpenComID(string strID)
        {
            return new JAccounts().gOpenComID(strID);
        }
        public void DoWork()
        {
        }
        //public List<FixedAssets> mDisplayAssetListLedger(string strDeComID, string  mstrLedgerName)
        //{
        //    return new JAccounts().mDisplayAssetListLedger(strDeComID, mstrLedgerName);
        //}
        public string mChangePasswod(string strDeComID, string strUserName, string strNewPassword)
        {
            return new JAccounts().mChangePasswod(strDeComID, strUserName, strNewPassword);
        }
        public List<AccVoucherHeader> mFilVoucherPrintingShow(string strDeComID, int intVoucherTypeValue)
        {
            return new JAccounts().mFilVoucherPrintingShow(strDeComID, intVoucherTypeValue);
        }
        public string mSaveVoucherPrinting(string strDeComID, string vstrVoucherHeader1, string vstrVoucherHeader2, string vstrVoucherHeader3, string vstrVoucherHeader4, string vstrVoucherHeader5, int intVoucherTypeValue, int intVoucherMinimize)
        {
            return new JAccounts().mSaveVoucherPrinting(strDeComID, vstrVoucherHeader1, vstrVoucherHeader2, vstrVoucherHeader3, vstrVoucherHeader4, vstrVoucherHeader5, intVoucherTypeValue, intVoucherMinimize);
        }
        public List<BackupPath> mGetBackupPath(string strDeComID)
        {
            return new JAccounts().mGetBackupPath(strDeComID);
        }
        public List<AccountdGroup> GetDsmRsm_level4_userPrivilegesRight(string strDeComID, string strUserName)
        {
            return new JAccounts().GetDsmRsm_level4_userPrivilegesRight(strDeComID, strUserName);
        }
        public List<AccountdGroup> GetDsmRsm_level4_userPrivileges(string strDeComID, string strUserName)
        {
            return new JAccounts().GetDsmRsm_level4_userPrivileges(strDeComID, strUserName);
        }
        public List<BranchConfig> mFillBranchUserRight(string strDeComID, string strUser)
        {
            return new JAccounts().mFillBranchUserRight(strDeComID, strUser);
        }
        public List<BranchConfig> mFillBranchUserPrivileges(string strDeComID, string strUserName)
        {
            return new JAccounts().mFillBranchUserPrivileges(strDeComID, strUserName);
        }
        public List<UserAccess> mDisplayPrivilegesMain(string strDeComID, string strLogInKey, int intPriModule)
        {
            return new JAccounts().mDisplayPrivilegesMain(strDeComID, strLogInKey, intPriModule);
        }
        public List<UserAccess> mDisplayPrivilegesChild(string strDeComID, string strLogInKey)
        {
            return new JAccounts().mDisplayPrivilegesChild(strDeComID, strLogInKey);
        }
        public string mInsertPrivileges(string strDeComID, string strUserName, int intPriModule, int lngAccess, string strstring, string strString1, string strSelection)
        {
            return new JAccounts().mInsertPrivileges(strDeComID, strUserName, intPriModule, lngAccess, strstring, strString1, strSelection);
        }
        public List<AccountdGroup> GetDsmRsm_level4(string strDeComID)
        {
            return new JAccounts().GetDsmRsm_level4(strDeComID);
        }
        public string mSaveFormConfig(string strDeComID, string strformKey, string strNormalName, int intModuletype, int intModeType, int intStatus)
        {
            return new JAccounts().mSaveFormConfig(strDeComID, strformKey, strNormalName, intModuletype, intModeType, intStatus);
        }
        public string mUpdateFormConfig(string strDeComID, long lngslNo, string strformKey, string strNormalName, int intModuletype, int intModeType, int intStatus)
        {
            return new JAccounts().mUpdateFormConfig(strDeComID, lngslNo, strformKey, strNormalName, intModuletype, intModeType, intStatus);
        }

        public List<AccountdGroup> mDisplayFormList(string strDeComID, int intModule)
        {
            return new JAccounts().mDisplayFormList(strDeComID, intModule);
        }
        public List<AccountdGroup> GetAccountsTreeviewCR(string strDeComID)
        {
            return new JAccounts().GetAccountsTreeviewCR(strDeComID);
        }
        public List<AccountsLedger> mDisplayLedgerPercen(string strDeComID, string strLedgerName)
        {
            return new JAccounts().mDisplayLedgerPercen(strDeComID, strLedgerName);
        }
        public string mSaveMonthConfig(string strDeComID, string strMonthID, string vstrfromDate, string vstrtodate, string vstrStatus)
        {
            return new JAccounts().mSaveMonthConfig(strDeComID, strMonthID, vstrfromDate, vstrtodate, vstrStatus);
        }
        public string mUpdateMonthConfig(string strDeComID, string stroldMonthID, string strMonthID, string vstrfromDate, string vstrtodate, string vstrStatus)
        {
            return new JAccounts().mUpdateMonthConfig(strDeComID, stroldMonthID, strMonthID, vstrfromDate, vstrtodate, vstrStatus);
        }
        public List<AccountdGroup> mDisplayMonthsetupList(string strDeComID, string strMonthId)
        {
            return new JAccounts().mDisplayMonthsetupList(strDeComID, strMonthId);
        }
        public string mDeleteMonthList(string strDeComID, string strMonthID)
        {
            return new JAccounts().mDeleteMonthList(strDeComID, strMonthID);
        }
        public List<AccountsVoucher> mGetRefNo(string strDeComID, int mintVType, string mdteVFromDate, string mdteVToDate, int intSP)
        {
            return new JAccounts().mGetRefNo(strDeComID, mintVType, mdteVFromDate, mdteVToDate, intSP);
        }
        public List<AccountdGroup> mDisplayMonthTarget(string strDeComID, string strFromDate, string strToDate, string strPartyname)
        {
            return new JAccounts().mDisplayMonthTarget(strDeComID, strFromDate, strToDate, strPartyname);
        }
        public List<AccountsLedger> mLedgerAdditemMr(string strDeComID, string vstrRoot, int intstatus)
        {
            return new JAccounts().mLedgerAdditemMr(strDeComID, vstrRoot, intstatus);
        }
        public List<Teritorry> mFillTeritorrySI(string strDeComID, string strCode)
        {
            return new JAccounts().mFillTeritorrySI(strDeComID, strCode);
        }
        public List<AccountdGroup> GetAccountsTreeviewDR(string strDeComID)
        {
            return new JAccounts().GetAccountsTreeviewDR(strDeComID);
        }
        public List<VectorCategory> mFillLedgerNameVector(string strDeComID)
        {
            return new JAccounts().mFillLedgerNameVector(strDeComID);
        }

        public Dictionary<string, string> mfillBranchNew(string strDeComID, bool vblngAccessControl, string vstrUserName)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("All", "All");
            foreach (BranchConfig ogrp in new JAccounts().mFillBranch(strDeComID, vblngAccessControl, vstrUserName))
            {
                ooGrp.Add(ogrp.BranchID, ogrp.BranchName);
            }
            return ooGrp;
        }

        public Dictionary<string, string> GetAccountsGroup(string strDeComID)
        {
            Dictionary<string, string> ooGrp = new Dictionary<string, string>();
            ooGrp.Add("Primary", "Primary");
            foreach (AccountdGroup ogrp in new JAccounts().GetAccountsGroup(strDeComID))
            {
                ooGrp.Add(ogrp.GroupName, ogrp.GroupName);
            }
            return ooGrp;
        }

        public short InsertGroup(string strDeComID, string strGroupName, string strUnder, string strCashflowType, string strAccountType, string strMobileNo, string strConatctNo, int intPosition)
        {
            return new JAccounts().InsertGroup(strDeComID, strGroupName, strUnder, strCashflowType, strAccountType, strMobileNo, strConatctNo, intPosition);
        }
        public List<AccountdGroup> GetAccountsTreeview(string strDeComID)
        {
            return new JAccounts().GetAccountsTreeview(strDeComID);
        }
        public List<AccountdGroup> GetGroupList(string strDeComID, long mlngGroupAs, bool vblngAccessControl, string vstrUserName)
        {
            return new JAccounts().GetGroupList(strDeComID, mlngGroupAs, vblngAccessControl, vstrUserName);
        }
        public short mUpdateGroup(string strDeComID, long mlngGroupSerial, string strGroupName, string strUnder, string strCashflowType, string strAccountType, string strMobileNo, string strConatctNo, int intPosition)
        {
            return new JAccounts().mUpdateGroup(strDeComID, mlngGroupSerial, strGroupName, strUnder, strCashflowType, strAccountType, strMobileNo, strConatctNo, intPosition);
        }

        public string DeleteGroup(string strDeComID, long mlngGroupSerial)
        {
            return new JAccounts().DeleteGroup(strDeComID, mlngGroupSerial);
        }

        public List<AccountsLedger> mFillCurrencyList(string strDeComID)
        {
            return new JAccounts().mFillCurrencyList(strDeComID);
        }
        public List<AccountdGroup> mFillGroup(string strDeComID, int mlngLedgerAs)
        {
            return new JAccounts().mFillGroup(strDeComID, mlngLedgerAs);
        }
        public string mDisplayOpening(string strDeComID)
        {
            return new JAccounts().mDisplayOpening(strDeComID);
        }

        public string mInsertCostCategory(string strDeComID, string strCostCategory)
        {
            return new JAccounts().mInsertCostCategory(strDeComID, strCostCategory);
        }
        public string mUpdateCostCategory(string strDeComID, string stroldCostCategory, string strNewCostCategory)
        {
            return new JAccounts().mUpdateCostCategory(strDeComID, stroldCostCategory, strNewCostCategory);
        }
        public List<VectorCategory> mFillVectorCategory(string strDeComID)
        {
            return new JAccounts().mFillVectorCategory(strDeComID);
        }

        public string DeleteCostCategory(string strDeComID, string strCostCategory)
        {
            return new JAccounts().DeleteCostCategory(strDeComID, strCostCategory);
        }

        public string mInsertCostCenter(string strDeComID, string strCostCenter, string strCostCategory)
        {
            return new JAccounts().mInsertCostCenter(strDeComID, strCostCenter, strCostCategory);
        }

        public string mUpdateCostCenter(string strDeComID, string stroldCostCenter, string strCostCenter, string strCostCategory)
        {
            return new JAccounts().mUpdateCostCenter(strDeComID, stroldCostCenter, strCostCenter, strCostCategory);
        }
        public string DeleteCostCenter(string strDeComID, string stroldCostCenter)
        {
            return new JAccounts().DeleteCostCenter(strDeComID, stroldCostCenter);
        }

        public List<VectorCategory> mFillCostCenter(string strDeComID)
        {
            return new JAccounts().mFillCostCenter(strDeComID);
        }

        public List<VectorCategory> mFillVectorMaster(string strDeComID, string vstrVectorCategory)
        {
            return new JAccounts().mFillVectorMaster(strDeComID, vstrVectorCategory);
        }

        public List<BranchConfig> mFillBranch(string strDeComID, bool vblngAccessControl, string vstrUserName)
        {
            return new JAccounts().mFillBranch(strDeComID, vblngAccessControl, vstrUserName);
        }

        public string mSaveLedger(string strDeComID, string vsstrLedgerName, string vstrParent, string vstrEMail, string vstrFax, string vstrAddress1,
                                   string vstrAddress2, string vstrcity, string vstrPostal, string vstrPhone, string vstrComments, string vstrCurrency,
                                   string strInvEffectStock, string strInactive, string strCostCenter, string strDrcr, double dblopnBalance,
                                   string strcostcenterGrid, string strBranchGrid,
                                   double dblFixedPurhaseAmount, string strEffectoveForm, long lngReducingBal,
                                   double dblAssetsLife, double dblDepRate, double dblAccDep, double dblWrittendownvalue,
                                   double dblSalvageValue, double lngAssetPercent, string strAssetsGrid, string strAssetsGridAccu, string strPFAmount)
        {
            return new JAccounts().mSaveLedger(strDeComID, vsstrLedgerName, vstrParent, vstrEMail, vstrFax, vstrAddress1,
                                    vstrAddress2, vstrcity, vstrPostal, vstrPhone, vstrComments, vstrCurrency,
                                    strInvEffectStock, strInactive, strCostCenter, strDrcr, dblopnBalance,
                                    strcostcenterGrid, strBranchGrid,
                                    dblFixedPurhaseAmount, strEffectoveForm, lngReducingBal,
                                    dblAssetsLife, dblDepRate, dblAccDep, dblWrittendownvalue,
                                    dblSalvageValue, lngAssetPercent, strAssetsGrid, strAssetsGridAccu, strPFAmount);
        }


        public List<AccountsLedger> mLedgerAdditem(string strDeComID, string vstrRoot, int intstatus)
        {
            return new JAccounts().mLedgerAdditem(strDeComID, vstrRoot, intstatus);
        }
        public List<AccountsLedger> mFillLedgerListNew(string strDeComID, int mintLedgerGroup, int intStatus, string strMySQL, int intlaodType)
        {
            return new JAccounts().mFillLedgerListNew(strDeComID, mintLedgerGroup, intStatus, strMySQL, intlaodType);
        }
        public List<AccountsLedger> mFillLedgerList(string strDeComID, int mintLedgerGroup)
        {
            return new JAccounts().mFillLedgerList(strDeComID, mintLedgerGroup);
        }

        public List<AccountsLedger> mDisplayLedgerList(string strDeComID, long vlngLedgerSerial)
        {
            return new JAccounts().mDisplayLedgerList(strDeComID, vlngLedgerSerial);
        }
        public List<VectorCategory> mDisplayVectorCategory(string strDeComID, string strOldLedgerName)
        {
            return new JAccounts().mDisplayVectorCategory(strDeComID, strOldLedgerName);
        }

        public List<BranchConfig> mDisplayBranchOpening(string strDeComID, string strOldLedgerName,string strBranchID)
        {
            return new JAccounts().mDisplayBranchOpening(strDeComID, strOldLedgerName, strBranchID);
        }
        public List<FixedAssets> mDisplayFixedAssest(string strDeComID, string strOldLedgerName)
        {
            return new JAccounts().mDisplayFixedAssest(strDeComID, strOldLedgerName);
        }
        public List<FixedAssets> mDisplayFixedAssestOpening(string strDeComID, string strOldLedgerName)
        {
            return new JAccounts().mDisplayFixedAssestOpening(strDeComID, strOldLedgerName);
        }
        public string mUpdateLedger(string strDeComID, string strOldLedger, long mlngLedgerSerial, string vsstrLedgerName, string vstrParent, string vstrEMail, string vstrFax, string vstrAddress1,
                                    string vstrAddress2, string vstrcity, string vstrPostal, string vstrPhone, string vstrComments, string vstrCurrency,
                                    string strInvEffectStock, string strInactive, string strCostCenter, string strDrcr, double dblopnBalance,
                                    string strcostcenterGrid, string strBranchGrid,
                                    double dblFixedPurhaseAmount, string strEffectoveForm, long lngReducingBal,
                                    double dblAssetsLife, double dblDepRate, double dblAccDep, double dblWrittendownvalue,
                                    double dblSalvageValue, double lngAssetPercent, string strAssetsGrid, string strAssetsGridAccu, string strPFAmount)
        {

            return new JAccounts().mUpdateLedger(strDeComID, strOldLedger, mlngLedgerSerial, vsstrLedgerName, vstrParent, vstrEMail, vstrFax, vstrAddress1,
                                     vstrAddress2, vstrcity, vstrPostal, vstrPhone, vstrComments, vstrCurrency,
                                     strInvEffectStock, strInactive, strCostCenter, strDrcr, dblopnBalance,
                                     strcostcenterGrid, strBranchGrid,
                                     dblFixedPurhaseAmount, strEffectoveForm, lngReducingBal,
                                     dblAssetsLife, dblDepRate, dblAccDep, dblWrittendownvalue,
                                     dblSalvageValue, lngAssetPercent, strAssetsGrid, strAssetsGridAccu, strPFAmount);
        }

        public string DeleteLedger(string strDeComID, long mlngledgerSerial)
        {
            return new JAccounts().DeleteLedger(strDeComID, mlngledgerSerial);
        }
        public List<AccountsLedger> mFillLedger(string strDeComID, int vIntGroup, string vstrPrefix, string vstrPrefix1, string vstruserName)
        {
            return new JAccounts().mFillLedger(strDeComID, vIntGroup, vstrPrefix, vstrPrefix1, vstruserName);
        }
        public string mInsertTempVector(string strDeComID, string strstring)
        {
            return new JAccounts().mInsertTempVector(strDeComID, strstring);
        }
        public List<AccountsLedger> DisplayAccountsTemplate(string strDeComID, string vstrSalesSerial)
        {
            return new JAccounts().DisplayAccountsTemplate(strDeComID, vstrSalesSerial);
        }
        public string SaveVoucher(string strDeComID, string strVoucherGrid, string vstrDrcr, string vstrRefNumber, long vlngVoucherType, string vdteDate, string vstrMonthID, string vdteDueDate, string vstrLedgerName,
                                                 string vstrReverseLedgerName, int intvoucherPosition, long lngCashFlow, string vstrVoyageNo, double vdblAmount, double vdblNetAmount,
                                                 double vdblAddAmount, double vdblLessAmount, double vdblDebitAmount, double vdblCreditAmount, double dblFCCurrencyDebit, double dblFCCurrencyCredit,
                                                 string mstrFCsymbol, double mdblCurrRate, long vlngAgstType, string vstrSingleNarration, string vstrNarrations, string vstrBranchID,
                                                 string DgCostCenter, string DGBillWise, bool blngNumMethod, long vlngIsMultiCurrency = 0,
                                                 string vstrChecuqNo = "", string vstrChequedate = "", string vstrDrawnon = "", string vstrAgnstRefNo = "",
                                                 string vstrSalesRep = "", string vstrDelivery = "",
                                                 string vstrPayment = "", string vstrSupport = "", string vstrValidaty = "", string vstrOtherTerms = "", int SpJounal = 0,
                                                 string strDginvEffect = "", string strGrdTemPlate = "", string strGrdTemPlateJV = "", int intLoanTransfer = 0)
        {
            return new JAccounts().SaveVoucher(strDeComID, strVoucherGrid, vstrDrcr, vstrRefNumber, vlngVoucherType, vdteDate, vstrMonthID, vdteDueDate, vstrLedgerName,
                                                 vstrReverseLedgerName, intvoucherPosition, lngCashFlow, vstrVoyageNo, vdblAmount, vdblNetAmount,
                                                 vdblAddAmount, vdblLessAmount, vdblDebitAmount, vdblCreditAmount, dblFCCurrencyDebit, dblFCCurrencyCredit,
                                                 mstrFCsymbol, mdblCurrRate, vlngAgstType, vstrSingleNarration, vstrNarrations, vstrBranchID, DgCostCenter, DGBillWise, blngNumMethod, vlngIsMultiCurrency,
                                                 vstrChecuqNo, vstrChequedate, vstrDrawnon, vstrAgnstRefNo, vstrSalesRep, vstrDelivery,
                                                 vstrPayment, vstrSupport, vstrValidaty, vstrOtherTerms, SpJounal, strDginvEffect, strGrdTemPlate, strGrdTemPlateJV, intLoanTransfer);
        }

        public string UpdateVoucher(string strDeComID, string strVoucherGrid, string vstrDrcr, string vstrRefNumber, long vlngVoucherType, string vdteDate, string vstrMonthID, string vdteDueDate, string vstrLedgerName,
                                                 string vstrReverseLedgerName, int intvoucherPosition, long lngCashFlow, string vstrVoyageNo, double vdblAmount, double vdblNetAmount,
                                                 double vdblAddAmount, double vdblLessAmount, double vdblDebitAmount, double vdblCreditAmount, double dblFCCurrencyDebit, double dblFCCurrencyCredit,
                                                 string mstrFCsymbol, double mdblCurrRate, long vlngAgstType, string vstrSingleNarration, string vstrNarrations, string vstrBranchID,
                                                 string DgCostCenter, string DGBillWise, long vlngIsMultiCurrency = 0,
                                                 string vstrChecuqNo = "", string vstrChequedate = "", string vstrDrawnon = "", string vstrAgnstRefNo = "", string vstrSalesRep = "", string vstrDelivery = "",
                                                 string vstrPayment = "", string vstrSupport = "", string vstrValidaty = "", string vstrOtherTerms = "",
                                                 string strDginvEffect = "", string strGrdTemPlate = "", string strGrdTemPlateJV = "", int intLoanTransfer = 0)
        {
            return new JAccounts().UpdateVoucher(strDeComID, strVoucherGrid, vstrDrcr, vstrRefNumber, vlngVoucherType, vdteDate, vstrMonthID, vdteDueDate, vstrLedgerName,
                                                 vstrReverseLedgerName, intvoucherPosition, lngCashFlow, vstrVoyageNo, vdblAmount, vdblNetAmount,
                                                 vdblAddAmount, vdblLessAmount, vdblDebitAmount, vdblCreditAmount, dblFCCurrencyDebit, dblFCCurrencyCredit,
                                                 mstrFCsymbol, mdblCurrRate, vlngAgstType, vstrSingleNarration, vstrNarrations, vstrBranchID,
                                                 DgCostCenter, DGBillWise, vlngIsMultiCurrency,
                                                 vstrChecuqNo, vstrChequedate, vstrDrawnon, vstrAgnstRefNo, vstrSalesRep, vstrDelivery,
                                                 vstrPayment, vstrSupport, vstrValidaty, vstrOtherTerms, strDginvEffect, strGrdTemPlate, strGrdTemPlateJV, intLoanTransfer);
        }


        //public List<AccountsVoucher> mOpenTable(string strDeComID, int mintVType, string strFind, string strExpression, string mdteVFromDate = "", string mdteVToDate = "", int intSPJ = 0, string strmySql = "")
        //{
        //    return new JAccounts().mOpenTable(strDeComID, mintVType, strFind, strExpression, mdteVFromDate, mdteVToDate, intSPJ, strmySql);
        //}
        public List<AccountsVoucher> DisplayCompVoucherList(string strDeComID, string vstrVoucherRefNumber, long mlngVoucherAs)
        {
            return new JAccounts().DisplayCompVoucherList(strDeComID, vstrVoucherRefNumber, mlngVoucherAs);
        }
        public List<AccountsVoucher> DisplayVoucherList(string strDeComID, string vstrVoucherRefNumber, long mlngVoucherAs, int intSP)
        {
            return new JAccounts().DisplayVoucherList(strDeComID, vstrVoucherRefNumber, mlngVoucherAs, intSP);
        }

        public List<VectorCategory> DisplayVectorList(string strDeComID, string vstrVoucherRefNumber)
        {
            return new JAccounts().DisplayVectorList(strDeComID, vstrVoucherRefNumber);
        }
        public string mSaveBranchInfo(string vstrBranchName, string vstrAddress1, string vstrAddress2, string vstrCountry, string vstrPhone,
                                    string vstrFax, string vstrEmail, string vstrComment, string vstrDefaultBranch, string vstInactive, string vstrGodown, string strDeComID)
        {
            return new JAccounts().mSaveBranchInfo(vstrBranchName, vstrAddress1, vstrAddress2, vstrCountry, vstrPhone,
                                                        vstrFax, vstrEmail, vstrComment, vstrDefaultBranch, vstInactive, vstrGodown, strDeComID);
        }
        public string mUpdateBranchInfo(string vstrBranchID, string vstrBranchName, string vstrAddress1, string vstrAddress2, string vstrCountry, string vstrPhone,
                                      string vstrFax, string vstrEmail, string vstrComment, string vstrDefaultBranch, string vstInactive, string vstrGodown, string strDeComID)
        {
            return new JAccounts().mUpdateBranchInfo(vstrBranchID, vstrBranchName, vstrAddress1, vstrAddress2, vstrCountry, vstrPhone,
                                                      vstrFax, vstrEmail, vstrComment, vstrDefaultBranch, vstInactive, vstrGodown, strDeComID);
        }

        public List<BranchConfig> mFillGetBranch(string strDeComID)
        {
            return new JAccounts().mFillGetBranch(strDeComID);
        }
        public string mDeleteBranchInfo(string strDeComID, string vstrBranchID, string vstrLedgerName)
        {
            return new JAccounts().mDeleteBranchInfo(strDeComID, vstrBranchID, vstrLedgerName);
        }
        public string mSaveFixedAssets(string strDeComID, string vsstrLedgerName,
                                double dblFixedPurhaseAmount, string strEffectoveForm, long lngReducingBal,
                                double dblAssetsLife, double dblDepRate, double dblAccDep, double dblWrittendownvalue,
                                double dblSalvageValue, double lngAssetPercent, string strAssetsGrid, string strDGAccBra)
        {
            return new JAccounts().mSaveFixedAssets(strDeComID, vsstrLedgerName,
                                                    dblFixedPurhaseAmount, strEffectoveForm, lngReducingBal,
                                                    dblAssetsLife, dblDepRate, dblAccDep, dblWrittendownvalue,
                                                    dblSalvageValue, lngAssetPercent, strAssetsGrid, strDGAccBra);
        }

        public List<FixedAssets> mAssetList(string strDeComID)
        {
            return new JAccounts().mAssetList(strDeComID);
        }
        public List<FixedAssets> mDisplayAssetList(string strDeComID, long mlngAssetSerial)
        {
            return new JAccounts().mDisplayAssetList(strDeComID, mlngAssetSerial);
        }

        public List<FixedAssets> mDisplayFixedBranchList(string strDeComID, string mstrLedgerName)
        {
            return new JAccounts().mDisplayFixedBranchList(strDeComID, mstrLedgerName);
        }

        public string mUpdateFixedAssets(string strDeComID, long mlngAssetSerial, string mstrOldLedger, string vsstrLedgerName,
                                     double dblFixedPurhaseAmount, string strEffectoveForm, long lngReducingBal,
                                     double dblAssetsLife, double dblDepRate, double dblAccDep, double dblWrittendownvalue,
                                     double dblSalvageValue, double lngAssetPercent, string strAssetsGrid, string strDGAccBra)
        {
            return new JAccounts().mUpdateFixedAssets(strDeComID, mlngAssetSerial, mstrOldLedger, vsstrLedgerName,
                                                          dblFixedPurhaseAmount, strEffectoveForm, lngReducingBal,
                                                          dblAssetsLife, dblDepRate, dblAccDep, dblWrittendownvalue,
                                                          dblSalvageValue, lngAssetPercent, strAssetsGrid, strDGAccBra);
        }
        public string mDeleteFixedAssets(string strDeComID, long mlngAssetSerial, string mstrOldLedger)
        {
            return new JAccounts().mDeleteFixedAssets(strDeComID, mlngAssetSerial, mstrOldLedger);
        }

        public string mInsertAssetsAdjustment(string strDeComID, string vstrRefNo, string mstrPrimaryKey, string vstrDate, string vstrBranchName, string vstrLedgerName, double dblAmount)
        {
            return new JAccounts().mInsertAssetsAdjustment(strDeComID, vstrRefNo, mstrPrimaryKey, vstrDate, vstrBranchName, vstrLedgerName, dblAmount);
        }
        public List<FixedAssets> mGetFixedAssetsAdjustment(string strDeComID)
        {
            return new JAccounts().mGetFixedAssetsAdjustment(strDeComID);
        }
        public string mDeleteAssetsAdjustment(string strDeComID, string mstrPrimaryKey)
        {
            return new JAccounts().mDeleteAssetsAdjustment(strDeComID, mstrPrimaryKey);
        }

        //********************************Sales
        public string mSaveCustomerLedger(string strDeComID, string vstrBranchID, string vsstrLedgerName, string vstrParent, string strPriceLevel, string strLedgerAddDate, string vstrEMail,
                                         string vstrFax, string vstrAddress1, string vstrAddress2, string vstrcity, string vstrCountry,
                                         string vstrContractPer, string vstrPostal, string vstrPhone, string vstrComments, string vstrCurrency,
                                         string strBillWise, string strInactive, string strCostCenter, string strDrcr, double dblopnBalance,
                                         string strcostcenterGrid, string strBranchGrid, string strBillwiseGrid,
                                         double dblCreditLimit, double dblCreditPeriod, string strFinancialForm, string strResignDate,
                                         int intCommission, string strTerritorycode, string strTerritoryName, string strClass, int intBkash, string strCloseDate, string strPFLedger, string strHLLedger)
        {
            return new JSales().mSaveCustomerLedger(strDeComID, vstrBranchID, vsstrLedgerName, vstrParent, strPriceLevel, strLedgerAddDate, vstrEMail, vstrFax, vstrAddress1,
                                                    vstrAddress2, vstrcity, vstrCountry, vstrContractPer, vstrPostal, vstrPhone, vstrComments, vstrCurrency,
                                                    strBillWise, strInactive, strCostCenter, strDrcr, dblopnBalance,
                                                    strcostcenterGrid, strBranchGrid, strBillwiseGrid,
                                                    dblCreditLimit,
                                                    dblCreditPeriod, strFinancialForm, strResignDate, intCommission, strTerritorycode, strTerritoryName, strClass, intBkash, strCloseDate, strPFLedger, strHLLedger);
        }

        public List<AccBillwise> mLoadBillWise(string strDeComID, string strOldLedgerName)
        {
            return new JAccounts().mLoadBillWise(strDeComID, strOldLedgerName);
        }
        public string mUpDateCustomerLedger(string strDeComID, string mstrOldLedger, string vstrBranchID, long mlngLedgerSerial, string vsstrLedgerName, string vstrParent, string strPriceLevel,
                                            string strLedgerAddDate, string vstrEMail, string vstrFax, string vstrAddress1, string vstrAddress2, string vstrcity,
                                            string vstrCountry, string vstrContractPer, string vstrPostal, string vstrPhone, string vstrComments, string vstrCurrency,
                                            string strBillWise, string strInactive, string strCostCenter, string strDrcr, double dblopnBalance,
                                            string strcostcenterGrid, string strBranchGrid, string strBillwiseGrid,
                                            double dblCreditLimit,
                                            double dblCreditPeriod, string strFinancialForm, string strResignDate, int intCommission, string strTerritorycode,
                                            string strTerritoryName, string strClass, int intBkash, string strCloseDate, string strPFLedger, string strHLLedger)
        {
            return new JSales().mUpDateCustomerLedger(strDeComID, mstrOldLedger, vstrBranchID, mlngLedgerSerial, vsstrLedgerName, vstrParent, strPriceLevel, strLedgerAddDate, vstrEMail, vstrFax, vstrAddress1,
                                                    vstrAddress2, vstrcity, vstrCountry, vstrContractPer, vstrPostal, vstrPhone, vstrComments, vstrCurrency,
                                                    strBillWise, strInactive, strCostCenter, strDrcr, dblopnBalance,
                                                    strcostcenterGrid, strBranchGrid, strBillwiseGrid,
                                                    dblCreditLimit,
                                                    dblCreditPeriod, strFinancialForm, strResignDate, intCommission, strTerritorycode, 
                                                    strTerritoryName, strClass, intBkash, strCloseDate, strPFLedger, strHLLedger);
        }


        public List<AccBillwise> DisplayBillWise(string strDeComID, string vstrVoucherRefNumber)
        {
            return new JAccounts().DisplayBillWise(strDeComID, vstrVoucherRefNumber);
        }
        public List<AccBillwise> gFillPreRefNo(string strDeComID, string vstrPartyName,
                                  long vlngVType, string vstrDate, string vstrBranchID, string vstrGodown, string strvstrRefNo, int intstatus)
        {
            return new JAccounts().gFillPreRefNo(strDeComID, vstrPartyName, vlngVType, vstrDate, vstrBranchID, vstrGodown, strvstrRefNo, intstatus);
        }

        public List<AccBillwise> DisplayCommonInvoice(string strDeComID, string vstrVoucherRefNumber)
        {
            return new JAccounts().DisplayCommonInvoice(strDeComID, vstrVoucherRefNumber);
        }
        public List<AccBillwise> DisplaycommonInvoiceOrder(string strDeComID, string vstrBillKey, int mlngVType)
        {
            return new JAccounts().DisplaycommonInvoiceOrder(strDeComID, vstrBillKey, mlngVType);
        }

        public List<AccBillwise> DisplaycommonInvoiceAddless(string strDeComID, string vstrSalesSerial)
        {
            return new JAccounts().DisplaycommonInvoiceAddless(strDeComID, vstrSalesSerial);
        }
        public List<AccBillwise> DisplaycommonInvoiceBill(string strDeComID, string vstrSalesSerial)
        {
            return new JAccounts().DisplaycommonInvoiceBill(strDeComID, vstrSalesSerial);
        }

        public List<AccountsLedger> DisplaycommonInvoiceVoucher(string strDeComID, string vstrSalesSerial)
        {
            return new JAccounts().DisplaycommonInvoiceVoucher(strDeComID, vstrSalesSerial);
        }

        public string mInsertUser(string strDeComID, string vstrLogInName, string vstrFullName, string vstrDepatrtment, string vstrDesignation,
                                               string vstrPassword, string vstrUserLevel, string vstrAccessLevel, string vstrComments, byte[] vImage)
        {
            return new JAccounts().mInsertUser(strDeComID, vstrLogInName, vstrFullName, vstrDepatrtment, vstrDesignation,
                                              vstrPassword, vstrUserLevel, vstrAccessLevel, vstrComments, vImage);
        }

        public List<UserAccess> mGetUserAccessData(string strDeComID, string strLogInName)
        {
            return new JAccounts().mGetUserAccessData(strDeComID, strLogInName);
        }
        public string mUpdateInsertUser(string strDeComID, string vstrmstrPk, string vstrLogInName, string vstrFullName, string vstrDepatrtment, string vstrDesignation,
                                                string vstrPassword, string vstrUserLevel, string vstrAccessLevel, string vstrComments, byte[] vImage)
        {
            return new JAccounts().mUpdateInsertUser(strDeComID, vstrmstrPk, vstrLogInName, vstrFullName, vstrDepatrtment, vstrDesignation,
                                                 vstrPassword, vstrUserLevel, vstrAccessLevel, vstrComments, vImage);
        }

        //public byte[] GetImage(string strLogInName)
        //{
        //    return new JAccounts().GetImage(strLogInName);
        //}
        //public string sevetest(byte[] img)
        //{
        //    return new JAccounts().sevetest(img);
        //}
        //public byte[] ReadImage(long ID)
        //{
        //    return new JAccounts().ReadImage(ID);
        //}

        public List<VoucherTypes> mLaodVoucherTypes(string strDeComID, long mlngmoduletype, long lngVtypeValue)
        {
            return new JAccounts().mLaodVoucherTypes(strDeComID, mlngmoduletype, lngVtypeValue);
        }
        public string mUpdteVoucherTypes(string strDeComID, long lngMtype, long mIntVoucherType, long lngNumericWidth, string vstrPrefix,
                                           string strNoMethod, string vstrSuffix, bool blngCheckVoucher, string vstrVoucherName, long lngStartNo,
                                           string strPrintYesOrNo, int intEffectBkash)
        {
            return new JAccounts().mUpdteVoucherTypes(strDeComID, lngMtype, mIntVoucherType, lngNumericWidth, vstrPrefix,
                                           strNoMethod, vstrSuffix, blngCheckVoucher, vstrVoucherName, lngStartNo,
                                           strPrintYesOrNo, intEffectBkash);
        }

        public List<VoucherTypes> mGetConfig(string strDeComID, long vintVoucherType)
        {
            return new JAccounts().mGetConfig(strDeComID, vintVoucherType);

        }


        public List<AccountsVoucher> DisplayQuotationVoucherList(string strDeComID, string vstrSalesSerial, long mlngVoucherAs)
        {
            return new JAccounts().DisplayQuotationVoucherList(strDeComID, vstrSalesSerial, mlngVoucherAs);
        }


        public List<AccBillwise> DisplayQuotationVoucherTranList(string strDeComID, string vstrSalesSerial, long mlngVoucherAs)
        {
            return new JAccounts().DisplayQuotationVoucherTranList(strDeComID, vstrSalesSerial, mlngVoucherAs);
        }


        public List<AccountsVoucher> mOpentableQuo(string strDeComID, int intVtype, string strFDate, string strTdate, string strRefNo)
        {
            return new JAccounts().mOpentableQuo(strDeComID, intVtype, strFDate, strTdate, strRefNo);
        }

        public List<AccountsLedger> GetSalesLedgerTree(string strDeComID)
        {
            return new JAccounts().GetSalesLedgerTree(strDeComID);
        }

        public List<AccountsLedger> GetSalesLedgerTreefromCustomer(string strDeComID, string strLedgerName)
        {
            return new JAccounts().GetSalesLedgerTreefromCustomer(strDeComID, strLedgerName);
        }

        public List<AccountsLedger> mFillLedgerNew(string strDeComID, long vlngGroup)
        {
            return new JAccounts().mFillLedgerNew(strDeComID, vlngGroup);
        }
        public List<Teritorry> mFillTeritorry(string strDeComID, string strCode)
        {
            return new JAccounts().mFillTeritorry(strDeComID, strCode);
        }
        public string DeletetTeritorry(string strDeComID, string strTeritorryCode)
        {
            return new JAccounts().DeletetTeritorry(strDeComID, strTeritorryCode);
        }
        public string mUpdateTeritorry(string strDeComID, string strCode, string strName)
        {
            return new JAccounts().mUpdateTeritorry(strDeComID, strCode, strName);
        }
        public string mInsertTeritorry(string strDeComID, string strCode, string strName)
        {
            return new JAccounts().mInsertTeritorry(strDeComID, strCode, strName);
        }
        public List<AccBillwise> gFillPreSampleClass(string strDeComID)
        {
            return new JAccounts().gFillPreSampleClass(strDeComID);
        }

        public List<UserAccess> mFillUsername(string strDeComID)
        {
            return new JAccounts().mFillUsername(strDeComID);
        }
        public List<UserAccess> mFillExpenseList(string strDeComID)
        {
            return new JAccounts().mFillUsername(strDeComID);
        }


        public string mInsertExpenseLedger(string strDeComID, string strConfiglKey, string strledgerName, string strEffectiveDate, long vlngVoucherType, string strGrid)
        {
            return new JAccounts().mInsertExpenseLedger(strDeComID, strConfiglKey, strledgerName, strEffectiveDate, vlngVoucherType, strGrid);
        }
        public List<AccountsLedger> mDisplayLedgerlistt(string strDeComID, int mintLedgerGroup)
        {
            return new JAccounts().mDisplayLedgerlistt(strDeComID, mintLedgerGroup);
        }

        public List<AccountsLedger> mDisplayLedgerConfig(string strDeComID, string masterKey)
        {
            return new JAccounts().mDisplayLedgerConfig(strDeComID, masterKey);
        }
        public List<AccountsLedger> mGetVoucherAmont(string strDeComID, string strFdate, string strTDate, string strCurrentYear, string strBranchId)
        {
            return new JAccounts().mGetVoucherAmont(strDeComID, strFdate, strTDate, strCurrentYear, strBranchId);
        }
        public List<AccountsLedger> mGetVoucherTodaySalesAmont(string strDeComID, string strFdate, string strBranchId)
        {
            return new JAccounts().mGetVoucherTodaySalesAmont(strDeComID, strFdate, strBranchId);
        }
        public List<AccountsLedger> mGetVoucherDateRangeWiseSalesAmont(string strDeComID, string strFdate, string strTDate, string strBranchId)
        {
            return new JAccounts().mGetVoucherDateRangeWiseSalesAmont(strDeComID, strFdate, strTDate, strBranchId);
        }
        public List<AccountsLedger> mGetVoucherDateRangeWiseRecevedAmont(string strDeComID, string strFdate, string strTDate, string strBranchId)
        {
            return new JAccounts().mGetVoucherDateRangeWiseRecevedAmont(strDeComID, strFdate, strTDate, strBranchId);
        }
        public string DeleteLedgerConfig(string strDeComID, string mstrConfiglkey)
        {
            return new JAccounts().DeleteLedgerConfig(strDeComID, mstrConfiglkey);
        }
        public double mGetLedgerOpening(string strDeComID, string strFdate, string strTDate, string vstrLedgerName, string strBranchID)
        {
            return new JAccounts().mGetLedgerOpening(strDeComID, strFdate, strTDate, vstrLedgerName, strBranchID);
        }
        public double mGetLedgerClosing(string strDeComID, string strFdate, string strTDate, string vstrLedgerName, string strBranchID)
        {
            return new JAccounts().mGetLedgerClosing(strDeComID, strFdate, strTDate, vstrLedgerName, strBranchID);
        }

    }



}
