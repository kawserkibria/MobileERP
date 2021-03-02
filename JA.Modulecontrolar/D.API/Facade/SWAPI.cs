using D.API.Dal;
using D.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace D.API.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SWAPI" in both code and config file together.
    public class SWAPI : ISWAPI
    {
        public AppsVercifysumm mobileSMSVerify(string strDeComID, string strMobileNo, string strOTP, string strSIMSL)
        {
            return new APIDal().mobileSMSVerify(strDeComID, strMobileNo, strOTP, strSIMSL);
        }
        public string mobileSMSAPI(string strDeComID, string strMobileNo)
        {
            return new APIDal().mobileSMSAPI(strDeComID, strMobileNo);
        }
        public summaryNew DisplayApiChangeOrder(string strDeComID, string strTc)
        {
            return new APIDal().DisplayApiChangeOrder(strDeComID, strTc);
        }
        public List<MpoArea> mLoadMpoDivisionNew(string strDeComID, string strDivision)
        {
            return new APIDal().mLoadMpoDivisionNew(strDeComID, strDivision);
        }
        public List<notification> mGetAppsNotifucation(string strDeComID, string TC)
        {
            return new APIDal().mGetAppsNotifucation(strDeComID, TC);
        }
        public int mUpdateNotification(string strDeComID, string strDG)
        {
            return new APIDal().mUpdateNotification(strDeComID, strDG);
        }
        public string UpdateAPISalesOrder(string strDeComID, string strSummary)
        {
            return new APIDal().UpdateAPISalesOrder(strDeComID, strSummary);
        }
        public summaryNew DisplayApiOrder(string strDeComID, string strTc, int intAppSync)
        {
            return new APIDal().DisplayApiOrder(strDeComID, strTc, intAppSync);
        }
        public string SaveAPISalesOrder(string strDeComID, string strSummary, string strDetails)
        {
            return new APIDal().SaveAPISalesOrder(strDeComID, strSummary, strDetails);
        }
        public List<StockitemRate> mLoadItemRate(string strDeComID, string strItemName)
        {
            return new APIDal().mLoadItemRate(strDeComID, strItemName);
        }
        public List<Commissionslab> mLoadCommissionSlab(string strDeComID)
        {
            return new APIDal().mLoadCommissionSlab(strDeComID);
        }
        public string mGetOTPNo(string strDeComID, string strMobileNo, string strTokenNo)
        {
            return new APIDal().mGetOTPNo(strDeComID, strMobileNo, strTokenNo);
        }
        public string mGetActive(string strDeComID, string strName)
        {
            return new APIDal().mGetActive(strDeComID, strName);
        }
        public List<Stockgroup> mLoadStockGroup(string strDeComID)
        {
            return new APIDal().mLoadStockGroup(strDeComID);
        }
        public List<StockItem> mGetStockItemFromGroup(string strDeComID, string strGroupName, string strBranchID)
        {
            return new APIDal().mGetStockItemFromGroup(strDeComID, strGroupName, strBranchID);
        }
        public MPO gstrGetMpoAreaDevisionList(string strDeComID, string strUserID, string strPassWord)
        {
            return new APIDal().gstrGetMpoAreaDevisionList(strDeComID, strUserID, strPassWord);
        }
        public List<Customer> mLoadCustomerName(string strDeComID, string strTc)
        {
            return new APIDal().mLoadCustomerName(strDeComID, strTc);
        }
        public List<MpoArea> mLoadMpoArea(string strDeComID, string strDisvion)
        {
            return new APIDal().mLoadMpoArea(strDeComID, strDisvion);
        }
        public List<Division> mLoadMpoDivisoin(string strDeComID,string strArea)
        {
            return new APIDal().mLoadMpoDivisoin(strDeComID, strArea);
        }
    }
}
