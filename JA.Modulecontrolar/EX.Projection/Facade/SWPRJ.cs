using EX.Projection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EX.Projection.Dal;
namespace EX.Projection.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SWPRJ" in both code and config file together.
    public class SWPRJ : ISWPRJ
    {
        public List<ProjectionSet> mFillDisplayMonthlyProjectionchild(string strDeComID, string strMonthID, string strKey, string strLedgerName, string strProjection)
        {
            return new JProjection().mFillDisplayMonthlyProjectionchild(strDeComID, strMonthID, strKey, strLedgerName, strProjection);
        }
        public List<Mprojection> mGetDivisionFromZone(string strDeComID, string strZone, int intHalt)
        {
            return new JProjection().mGetDivisionFromZone(strDeComID, strZone,intHalt);
        }
        public string mDeletePerformanve(string strcomId)
        {
            return new JProjection().mDeletePerformanve(strcomId);
        }
        public List<ProjectionSet> mrptFillDisplayMonthlyProjection(string strDeComID, string strMonthID, string strDivision, int intmode)
        {
            return new JProjection().mrptFillDisplayMonthlyProjection(strDeComID, strMonthID, strDivision, intmode);
        }
        public List<ProjectionSet> mFillWeeklyProjectionReport(string strDeComID, string strMonthID, string strDivision, int intmode)
        {
            return new JProjection().mFillWeeklyProjectionReport(strDeComID, strMonthID, strDivision, intmode);
        }
        public List<ProjectionSet> mFillMonthlyProjectionValue(string strDeComID, string strMonthID, string strLedgerName, string strProjectionName)
        {
            return new JProjection().mFillMonthlyProjectionValue(strDeComID, strMonthID, strLedgerName, strProjectionName);
        }
        public List<ProjectionSet> mFillDisplayLedgerNameWeeklyReport(string strDeComID, string strKey, string strDivision, int Intmode, string vstrUserName, string strZone)
        {
            return new JProjection().mFillDisplayLedgerNameWeeklyReport(strDeComID, strKey, strDivision, Intmode, vstrUserName,strZone);
        }
        public List<ProjectionSet> mFillDisplayLedgerNameWeekly(string strDeComID, string strKey, string strDivision)
        {
            return new JProjection().mFillDisplayLedgerNameWeekly(strDeComID, strKey, strDivision);
        }
        public List<ProjectonMonthConfig> getZoneFromDivsion(string strDeComID, string strDivision)
        {
            return new JProjection().getZoneFromDivsion(strDeComID, strDivision);
        }
        public string mInsertMpoPerformance(string strDeComID, string strLedgerName, string strFdate, string strTdate, int intmode,int intSelection)
        {
            return new JProjection().mInsertMpoPerformance(strDeComID, strLedgerName, strFdate, strTdate, intmode, intSelection);
        }
        public List<Mprojection> mQueryPerformance(string strDeComID, int intMode)
        {
            return new JProjection().mQueryPerformance(strDeComID,intMode);
        }
        public List<Mprojection> mGetLedgerGroupLoad(string strDeComID, int intMode, string struserName)
        {
            return new JProjection().mGetLedgerGroupLoad(strDeComID, intMode, struserName);
        }

        public string mInsertMonthConfig(string strDeComID, string strMonthID, string strMonthFromDate, string strMonthToDate, int intStatus)
        {
            return new JProjection().mInsertMonthConfig(strDeComID, strMonthID, strMonthFromDate, strMonthToDate, intStatus);
        }
        public List<ProjectonMonthConfig> mFillMonthConfig(string strDeComID, int intStaus)
        {
            return new JProjection().mFillMonthConfig(strDeComID, intStaus);
        }
        public string DeletetMonthConfig(string strDeComID, int intSerialkey)
        {
            return new JProjection().DeletetMonthConfig(strDeComID, intSerialkey);
        }
        public string mUpdateMonthConfigpublic(string strDeComID, string strMonthID, string strFromDate, string strToDate, int intStatus, int intSerialKey)
        {
            return new JProjection().mUpdateMonthConfigpublic(strDeComID, strMonthID, strFromDate, strToDate, intStatus, intSerialKey);
        }
        public string mInsertProjectionSetup(string strDeComID, string strMonthID, string DgGrid)
        {
            return new JProjection().mInsertProjectionSetup(strDeComID, strMonthID, DgGrid);
        }
        public List<ProjectionSet> mFillPojictionConfig(string strDeComID, string strMonthID)
        {
            return new JProjection().mFillPojictionConfig(strDeComID, strMonthID);
        }
        public string DeletetProjectionSetUp(string strDeComID, string strProjectionkey)
        {
            return new JProjection().DeletetProjectionSetUp(strDeComID, strProjectionkey);
        }
        public string mUpdateProjectionSetup(string strDeComID, string strMonthID, string DgGrid, string strProjectionKey)
        {
            return new JProjection().mUpdateProjectionSetup(strDeComID, strMonthID, DgGrid, strProjectionKey);
        }
        public List<ProjectionSet> mFillMonthlyProjection(string strDeComID, string strProjectionMonth)
        {
            return new JProjection().mFillMonthlyProjection(strDeComID, strProjectionMonth);
        }
        public List<ProjectionSet> mFillMonthlyProjectionLedger(string strDeComID, string strLedgerGroup, string strMonthID, int intmode)
        {
            return new JProjection().mFillMonthlyProjectionLedger(strDeComID, strLedgerGroup, strMonthID, intmode);
        }
        public string mInsertMonthlyProjection(string strDeComID, string strKey, string strMonthID, string strDivision, string strBranchID, string strLedgerName, string strHeadName, double dblAmount, int intDel, int intCols, int intRow)
        {
            return new JProjection().mInsertMonthlyProjection(strDeComID, strKey, strMonthID, strDivision, strBranchID, strLedgerName, strHeadName, dblAmount, intDel, intCols, intRow);
        }
        public List<ProjectionSet> mFillMonthlyProjectionList(string strDeComID, string VstruserName)
        {
            return new JProjection().mFillMonthlyProjectionList(strDeComID,VstruserName);
        }
        public List<ProjectionSet> mFillDisplayMonthlyProjection(string strDeComID, string strMonthID, string strDivision, string strprojectionKey)
        {
            return new JProjection().mFillDisplayMonthlyProjection(strDeComID, strMonthID, strDivision,strprojectionKey);
        }
        public List<ProjectionSet> mFillDisplayLedgerName(string strDeComID, string strKey, string strDivision)
        {
            return new JProjection().mFillDisplayLedgerName(strDeComID, strKey, strDivision);
        }
        public string mDeleteMonthlyProjection(string strDeComID, string strMonthID, string strDivision)
        {
            return new JProjection().mDeleteMonthlyProjection(strDeComID, strMonthID, strDivision);
        }
        public string gCheckProjectionActive(string strDeComID, string strDate)
        {
            return new JProjection().gCheckProjectionActive(strDeComID, strDate);
        }


        public List<ProjectionSet> mFillWeeklyProjectionList(string strDeComID, string VstruserName)
        {
            return new JProjection().mFillWeeklyProjectionList(strDeComID, VstruserName);
        }
        public string mDeleteWeeklyProjection(string strDeComID, string strMonthID)
        {
            return new JProjection().mDeleteWeeklyProjection(strDeComID, strMonthID);
        }
        public List<ProjectionSet> mFillDisplayWeeklyProjection(string strDeComID, string strMonthID, string strDivision)
        {
            return new JProjection().mFillDisplayWeeklyProjection(strDeComID, strMonthID, strDivision);
        }
        public string mInsertWeeklyProjectionSet(string strDeComID, string strKey, string strMonthID, string strDivision, string strBranchID, string strLedgerName,
                                                string strHeadName, double dblAmount, double dblWrittenAmount, int intDel, int intCols, int intRow, string strCommProjectionName)
        {
            return new JProjection().mInsertWeeklyProjectionSet(strDeComID, strKey, strMonthID, strDivision, strBranchID,
                                                                strLedgerName, strHeadName, dblAmount, dblWrittenAmount, intDel, intCols, intRow,strCommProjectionName);
        }




        public List<PCollectionCopmarison> mGetMontlyLadgerProjection(string strDeComID, string strThisMonth, string strledger)
        {
            return new JProjection().mGetMontlyLadgerProjection(strDeComID, strThisMonth, strledger);
        }
        public List<PCollectionCopmarison> mGetMontlyLadger(string strDeComID, string strThisMonth, string strledger)
        {
            return new JProjection().mGetMontlyLadger(strDeComID, strThisMonth, strledger);
        }
        public List<PCollectionCopmarison> mGetCollectionComparision(string strDeComID, string strThisMonth, string strLastMont, string vstrUserName, int IntMode)
        {
            return new JProjection().mGetCollectionComparision(strDeComID, strThisMonth, strLastMont, vstrUserName, IntMode);
        }
        public List<PCollectionCopmarison> mGetProjectionStarEndDate(string strDeComID, string strThisMonth, string strLastMont,string strProIndividual)
        {
            return new JProjection().mGetProjectionStarEndDate(strDeComID, strThisMonth, strLastMont, strProIndividual);
        }
        public List<PCollectionCopmarison> mGetProjectionReport(string strDeComID, string strProjectionName, string strFromMonthID, string strEndMonthID,
                                                                int intmode, string strLedgerName, string strProjectionNamee)
        {
            return new JProjection().mGetProjectionReport(strDeComID, strProjectionName, strFromMonthID, strEndMonthID, intmode, strLedgerName, strProjectionNamee);
        }
        public List<PCollectionCopmarison> mGetCollectionComparisionReport(string strDeComID, string strProjectionName, string strFromMonthID, string strEndMonthID, int intmode, string strLedgerName, string strProjectionNamee)
        {
            return new JProjection().mGetCollectionComparisionReport(strDeComID, strProjectionName, strFromMonthID, strEndMonthID, intmode, strLedgerName, strProjectionNamee);
        }


    }
}
