using D.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Web.Script.Services;

namespace D.API.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISWAPI" in both code and config file together.
    [ServiceContract]
    public interface ISWAPI
    {
        [OperationContract]
        AppsVercifysumm mobileSMSVerify(string strDeComID, string strMobileNo, string strOTP, string strSIMSL);
        [OperationContract]
        string mobileSMSAPI(string strDeComID, string strMobileNo);
        [OperationContract]
        summaryNew DisplayApiChangeOrder(string strDeComID, string strTc);
        [OperationContract]
        string mGetActive(string strDeComID, string strName);
        [OperationContract]
        List<MpoArea> mLoadMpoDivisionNew(string strDeComID, string strDivision);
        [OperationContract]
        int mUpdateNotification(string strDeComID, string strDG);
        [OperationContract]
        List<notification> mGetAppsNotifucation(string strDeComID,string TC);
        [OperationContract]
        string UpdateAPISalesOrder(string strDeComID, string strSummary);
        [OperationContract]
        summaryNew DisplayApiOrder(string strDeComID, string strTc,int intAppSync);
        [OperationContract]
        string SaveAPISalesOrder(string strDeComID, string strSummary, string strDetails);
        [OperationContract]
        string mGetOTPNo(string strDeComID, string strMobileNo, string strTokenNo);
        [OperationContract]
        List<Stockgroup> mLoadStockGroup(string strDeComID);
        [OperationContract]
        List<StockItem> mGetStockItemFromGroup(string strDeComID, string strGroupName, string strBranchID);
        [OperationContract]
        MPO gstrGetMpoAreaDevisionList(string strDeComID, string strUserID, string strPassWord);
        [OperationContract]
        List<Customer> mLoadCustomerName(string strDeComID, string strTc);
        [OperationContract]
        List<StockitemRate> mLoadItemRate(string strDeComID, string strItemName);
        [OperationContract]
        List<Commissionslab> mLoadCommissionSlab(string strDeComID);
        [OperationContract]
        List<MpoArea> mLoadMpoArea(string strDeComID, string strDisvion);
        [OperationContract]
        List<Division> mLoadMpoDivisoin(string strDeComID, string strArea);
    }
}
