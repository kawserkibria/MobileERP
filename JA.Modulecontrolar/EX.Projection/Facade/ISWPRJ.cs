using EX.Projection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EX.Projection.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISWPRJ" in both code and config file together.
    [ServiceContract]
    public interface ISWPRJ
    {
        [OperationContract]
        List<ProjectionSet> mFillDisplayMonthlyProjectionchild(string strDeComID, string strMonthID, string strKey, string strLedgerName, string strProjection);
        [OperationContract]
        List<Mprojection> mGetDivisionFromZone(string strDeComID, string strZone, int intHalt);
        [OperationContract]
        string mDeletePerformanve(string strcomId);
        [OperationContract]
        List<ProjectionSet> mrptFillDisplayMonthlyProjection(string strDeComID, string strMonthID, string strDivision, int intmode);
        [OperationContract]
        List<ProjectionSet> mFillWeeklyProjectionReport(string strDeComID, string strMonthID, string strDivision, int intmode);
        [OperationContract]
        List<ProjectionSet> mFillMonthlyProjectionValue(string strDeComID, string strMonthID, string strLedgerName, string strProjectionName);

        [OperationContract]
        List<ProjectionSet> mFillDisplayLedgerNameWeeklyReport(string strDeComID, string strKey, string strDivision, int Intmode, string vstrUserName, string strZone);
        [OperationContract]
        List<ProjectionSet> mFillWeeklyProjectionList(string strDeComID, string VstruserName);
        [OperationContract]
        string mDeleteWeeklyProjection(string strDeComID, string strMonthID);

        [OperationContract]
        List<ProjectionSet> mFillDisplayWeeklyProjection(string strDeComID, string strMonthID, string strDivision);

        [OperationContract]
        List<ProjectionSet> mFillDisplayLedgerNameWeekly(string strDeComID, string strKey, string strDivision);

        [OperationContract]
        string mInsertWeeklyProjectionSet(string strDeComID, string strKey, string strMonthID, string strDivision, string strBranchID, string strLedgerName, string strHeadName,
                     double dblAmount, double dblWrittenAmount, int intDel, int intCols, int intRow, string strCommProjectionName);

        [OperationContract]
        List<ProjectonMonthConfig> getZoneFromDivsion(string strDeComID, string strDivision);
        [OperationContract]
        string mInsertMpoPerformance(string strDeComID, string strLedgerName, string strFdate, string strTdate, int intmode, int intSelection);
        [OperationContract]
        List<Mprojection> mQueryPerformance(string strDeComID, int intMode);
        [OperationContract]
        List<Mprojection> mGetLedgerGroupLoad(string strDeComID, int intMode, string struserName);
        [OperationContract]
        string mInsertMonthConfig(string strDeComID, string strMonthID, string strMonthFromDate, string strMonthToDate, int intStatus);
        [OperationContract]
        List<ProjectonMonthConfig> mFillMonthConfig(string strDeComID, int intStaus);
        [OperationContract]
        string DeletetMonthConfig(string strDeComID, int intSerialkey);
        [OperationContract]
        string mUpdateMonthConfigpublic(string strDeComID, string strMonthID, string strFromDate, string strToDate, int intStatus, int intSerialKey);
        [OperationContract]
        string mInsertProjectionSetup(string strDeComID, string strMonthID, string DgGrid);
        [OperationContract]
        List<ProjectionSet> mFillPojictionConfig(string strDeComID, string strMonthID);
        [OperationContract]
        string DeletetProjectionSetUp(string strDeComID, string strProjectionkey);
        [OperationContract]
        string mUpdateProjectionSetup(string strDeComID, string strMonthID, string DgGrid, string strProjectionKey);
        [OperationContract]
        List<ProjectionSet> mFillMonthlyProjection(string strDeComID, string strProjectionMonth);
        [OperationContract]
        List<ProjectionSet> mFillMonthlyProjectionLedger(string strDeComID, string strLedgerGroup, string strMonthID, int intmode);
        [OperationContract]
        string mInsertMonthlyProjection(string strDeComID, string strKey, string strMonthID, string strDivision, string strBranchID, string strLedgerName, 
                                            string strHeadName, double dblAmount, int intDel, int intCols, int intRow);
        [OperationContract]
        List<ProjectionSet> mFillMonthlyProjectionList(string strDeComID, string VstruserName);
        [OperationContract]
        List<ProjectionSet> mFillDisplayMonthlyProjection(string strDeComID, string strMonthID, string strDivision, string strprojectionKey);
        [OperationContract]
        List<ProjectionSet> mFillDisplayLedgerName(string strDeComID, string strKey, string strDivision);
        [OperationContract]
        string mDeleteMonthlyProjection(string strDeComID, string strMonthID, string strDivision);
        [OperationContract]
        string gCheckProjectionActive(string strDeComID, string strDate);
         [OperationContract]
        List<PCollectionCopmarison> mGetMontlyLadgerProjection(string strDeComID, string strThisMonth, string strledger);
        [OperationContract]
        List<PCollectionCopmarison> mGetMontlyLadger(string strDeComID, string strThisMonth, string strledger);

        [OperationContract]
        List<PCollectionCopmarison> mGetCollectionComparision(string strDeComID, string strThisMonth, string strLastMont, string vstrUserName, int IntMode);

        [OperationContract]
        List<PCollectionCopmarison> mGetProjectionStarEndDate(string strDeComID, string strThisMonth, string strLastMont,string strProIndividual);

        [OperationContract]
        List<PCollectionCopmarison> mGetCollectionComparisionReport(string strDeComID, string strProjectionName, string strFromMonthID, string strEndMonthID, int intmode, string strLedgerName, string strProjectionNamee);
        [OperationContract]
        List<PCollectionCopmarison> mGetProjectionReport(string strDeComID, string strProjectionName, string strFromMonthID, string strEndMonthID, int intmode, string strLedgerName, string strProjectionNamee);

    }
}
