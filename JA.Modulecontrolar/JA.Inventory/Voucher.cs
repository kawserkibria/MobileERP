using Dutility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Modulecontrolar
{
    public class Voucher
    {
        public static string gInsertInvStockReqisitionChild(
                                                          string vstrRefNo,
                                                          string vstrItemName,
                                                          double vdblQty,
                                                          double dblRate,
                                                          string vstrUom,
                                                          double vdblTotalAmount)
        {


            string strSQL = "";
            strSQL = "INSERT INTO INV_STOCK_REQUISITION_CHILD";
            strSQL = strSQL + "(REQUISITION_NO, STOCKITEM_NAME, ITEM_QTY, ITEM_RATE, UNIT, ITEM_AMOUNT";
            strSQL = strSQL + ") ";
            strSQL = strSQL + "VALUES(";
            strSQL = strSQL + "'" + vstrRefNo.Trim() + "',";
            strSQL = strSQL + "'" + vstrItemName + "',";//            'Item Name
            strSQL = strSQL + "'" + vdblQty + "',";//                'Qty
            strSQL = strSQL + "'" + dblRate + "',";//                'Rate
            strSQL = strSQL + "'" + vstrUom + "',";//              'Unit
            strSQL = strSQL + " " + vdblTotalAmount + "1";//         'Net Amount
            strSQL = strSQL + ")";
            return strSQL;

        }

        public static string gInsertStockRequisitionMaster(string VstrRefNo,
                                                        string VstrDate,
                                                        string vstrBranchID,
                                                        string VstrProcessName,
                                                        string VstrGodownName,
                                                        string VstrNarrations,
                                                        int Vintstatus,
                                                        double VdblNetQty,
                                                        double VdblNetAmount,
                                                        long VmlngVType
                                                       )
        {


            string strSQL;

            strSQL = "INSERT INTO INV_STOCK_REQUISITION_MASTER ";
            strSQL = strSQL + "(REQUISITION_NO, INVOICE_DATE, BRANCH_ID, PROCESS_NAME, GODOWNS_NAME, NARRATIONS, REQ_STATUS, NET_TOTAL, TOTLA_QTY, INV_VOUCHER_TYPE ";
            strSQL = strSQL + ") ";
            strSQL = strSQL + "VALUES (";
            strSQL = strSQL + "'" + VstrRefNo + "',";
            strSQL = strSQL + "" + Utility.cvtSQLDateString(VstrDate) + ",";
            if (vstrBranchID != "")
            {
                strSQL = strSQL + "'" + vstrBranchID + "',";
            }
            else
            {
                strSQL = strSQL + "'0001',";
            }
            strSQL = strSQL + "'" + VstrProcessName + "',";
            strSQL = strSQL + "'" + VstrGodownName + "',";
            if (VstrNarrations != "")
            {
                strSQL = strSQL + "'" + VstrNarrations + "',";
            }
            else
            {
                strSQL = strSQL + "'',";
            }
            if (Vintstatus != 0)
            {
                strSQL = strSQL + "" + Vintstatus + ",";
            }
            else
            {
                strSQL = strSQL + "0,";
            }
            strSQL = strSQL + "" + VdblNetAmount + ", ";
            strSQL = strSQL + "" + VdblNetQty + ", ";
            strSQL = strSQL + "" + VmlngVType + "";
            strSQL = strSQL + ")";
            return strSQL;
        }
        public static string gInsertCompanyVoucher(string vstrRefNumber,
                                                    long vlngVoucherType,
                                                    string vdteDate,
                                                    string vstrMonthID,
                                                    string vdteDueDate,
                                                    string vstrLedgerName,
                                                    double vdblAmount,
                                                    double vdblNetAmount,
                                                    double vdblAddAmount,
                                                    double vdblLessAmount,
                                                    long vlngAgstType,
                                                    string vstrNarrations,
                                                    string vstrBranchID,
                                                    long vlngIsMultiCurrency = 0,
                                                    string vstrAgnstRefNo = "",
                                                    string vstrSalesRep = "",
                                                    string vstrDelivery = "",
                                                    string vstrPayment = "",
                                                    string vstrSupport = "",
                                                    string vstrValidaty = "",
                                                    string vstrOtherTerms = "")
          {
                    string strSQL = "";


                    strSQL = "INSERT INTO ACC_COMPANY_VOUCHER";
                    strSQL = strSQL + "(BRANCH_ID,COMP_REF_NO,COMP_VOUCHER_MONTH_ID,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,COMP_VOUCHER_DUE_DATE,";
                    strSQL = strSQL + "LEDGER_NAME,COMP_VOUCHER_AMOUNT,COMP_VOUCHER_NET_AMOUNT,";
                    strSQL = strSQL + "COMP_VOUCHER_ADD_AMOUNT,COMP_VOUCHER_LESS_AMOUNT,";
                    strSQL = strSQL + "COMP_AGAINST_REF,COMP_VOUCHER_FC";
                    if (vstrNarrations != "")
                    {
                        strSQL = strSQL + ",COMP_VOUCHER_NARRATION ";
                    }
                    if (vstrAgnstRefNo != "")
                    {
                        strSQL = strSQL + ",AGNST_COMP_REF_NO,COMP_VOUCHER_IS_AUTO ";
                    }
                    if (vstrSalesRep != "")
                    {
                        strSQL = strSQL + ",SALES_REP ";
                    }
                    if (vstrDelivery != "")
                    {
                        strSQL = strSQL + ",COMP_DELIVERY ";
                    }
                    if (vstrPayment != "")
                    {
                        strSQL = strSQL + ",COMP_TERM_OF_PAYMENTS ";
                    }
                    if (vstrSupport != "")
                    {
                        strSQL = strSQL + ",COMP_SUPPORT ";
                    }
                    if (vstrValidaty != "")
                    {
                        strSQL = strSQL + ",COMP_VALIDITY_DATE ";
                    }
                    if (vstrOtherTerms != "")
                    {
                        strSQL = strSQL + ",COMP_OTHERS ";
                    }
                    strSQL = strSQL + ") ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'" + vstrBranchID + "',";
                    strSQL = strSQL + "'" + vstrRefNumber.Trim() + "',";
                    strSQL = strSQL + "'" + vstrMonthID + "',";
                    strSQL = strSQL + " " + vlngVoucherType + ",";
                    //strSQL = strSQL + "Convert (DateTime  ,'" + vdteDate + "', 103) ,";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(vdteDate) + ",";
                    //strSQL = strSQL + "Convert (DateTime  ,'" + vdteDate + "', 103) ,";
                    strSQL = strSQL + " " + Utility.cvtSQLDateString(vdteDate) + ",";
                    strSQL = strSQL + "'" + vstrLedgerName + "',";
                    strSQL = strSQL + " " + vdblAmount + ",";
                    strSQL = strSQL + " " + vdblNetAmount + ",";
                    strSQL = strSQL + " " + vdblAddAmount + ",";
                    strSQL = strSQL + " " + vdblLessAmount + ",";
                    strSQL = strSQL + " " + vlngAgstType + ",";
                    strSQL = strSQL + " " + vlngIsMultiCurrency + "";
                    if (vstrNarrations != "")
                    {
                        strSQL = strSQL + ",'" + vstrNarrations + "'";
                    }
                    if (vstrAgnstRefNo != "")
                    {
                        strSQL = strSQL + ",'" + vstrAgnstRefNo + "'";
                        strSQL = strSQL + ",1";
                    }
                    if (vstrSalesRep != "")
                    {
                        strSQL = strSQL + ",'" + vstrSalesRep + "' ";
                    }
                    if (vstrDelivery != "")
                    {
                        strSQL = strSQL + ",'" + vstrDelivery + "' ";
                    }
                    if (vstrPayment != "")
                    {
                        strSQL = strSQL + ",'" + vstrPayment + "' ";
                    }
                    if (vstrSupport != "")
                    {
                        strSQL = strSQL + ",'" + vstrSupport + "' ";
                    }
                    if (vstrValidaty != "")
                    {
                        //strSQL = strSQL + ",Convert (DateTime  ,'" + vstrValidaty + "', 103) ";
                        strSQL = strSQL + " " + Utility.cvtSQLDateString(vstrValidaty) + ",";
                    }
                    if (vstrOtherTerms != "")
                    {
                        strSQL = strSQL + ",'" + vstrOtherTerms + "' ";
                    }
                    strSQL = strSQL + ")";


                    return strSQL;

        }


        public string gInsertBillTranProcess(string vstrRefNoKey ,
                                  string vstrBranchID ,
                                  long  vlngLoop ,
                                  string vstrCompRefNo ,
                                  string vstrAgstCompRefNo ,
                                  long  vlngVType ,
                                  string vdteDate ,
                                  string vstrItemName ,
                                  string vstrGodownName ,
                                  double  vdblQty ,
                                  string vstrUom ,
                                  string vstrAgstRefNoKey ,
                                  double vdblDiscAmt ,
                                  double vdblNetAmt ,
                                  string vstrPer ="")
        {


                     string strSQL="";

                    strSQL = "INSERT INTO ACC_BILL_TRAN_PROCESS";
                    strSQL = strSQL + "(BRANCH_ID,BILL_TRAN_KEY,BILL_TRAN_POSITION,COMP_REF_NO,AGST_COMP_REF_NO,";
                    strSQL = strSQL + "COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
                    strSQL = strSQL + "STOCKITEM_NAME,GODOWNS_NAME,BILL_QUANTITY,BILL_UOM,BILL_PER,AGST_REF_NO_KEY,ADD_LESS_AMOUNT,BILL_NET_AMOUNT";
                    strSQL = strSQL + ") ";
                    strSQL = strSQL + "VALUES";
                    strSQL = strSQL + "( ";
                    strSQL = strSQL + "'" + vstrBranchID + "',";
                    strSQL = strSQL + "'" + vstrRefNoKey.Trim() + "'," + vlngLoop + ",";
                    strSQL = strSQL + "'" + vstrCompRefNo.Trim() + "','" + vstrAgstCompRefNo.Trim() + "',";
                    strSQL = strSQL + "" + vlngVType + ",";
                    strSQL = strSQL + "" + Utility.cvtSQLDateString(vdteDate) + ",";
                    strSQL = strSQL + "'" + vstrItemName + "','" + vstrGodownName + "',";
                    strSQL = strSQL + " " + vdblQty + ",'" + vstrUom + "','" + vstrPer + "',";
                    strSQL = strSQL + "'" + vstrAgstRefNoKey.Trim() + "',";
                    strSQL = strSQL + " " + vdblDiscAmt + ",";
                    strSQL = strSQL + " " + vdblNetAmt + "";
                    strSQL = strSQL + ")";
                    return strSQL;

        }
       
        public string gInsertBillTran(string vstrBillKey,
                                       string vstrRefNo,
                                       long vlngVType,
                                       string vstrDate,
                                       string vstrItemName,
                                       string vstrGodownName,
                                       double vdblQty,
                                       double vdblBonusQty,
                                       string vstrUom,
                                       double vdblrate,
                                       double vdblTotalAmount,
                                       string vstrAddLess,
                                       double vdblDiscount,
                                       double vdblDebitValue,
                                       string vstrDrCr,
                                       long vlngposition,
                                       string vstrBranchID,
                                       string vstrCurrrency = "",
                                       string vstrPer = "",
                                       string vstrSalesRep = "",
                                       string vstrAgnstRefNo = "",
                                       string vstrBatchNo = "",
                                       string vstrItemDesc = "", string strOrderRefNo = "", string vstrItemNameBangla = "")
        {


            string strSQL = "";

            strSQL = "INSERT INTO ACC_BILL_TRAN";
            strSQL = strSQL + "(BRANCH_ID,BILL_TRAN_KEY,COMP_REF_NO,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
            strSQL = strSQL + "STOCKITEM_NAME,GODOWNS_NAME,BILL_QUANTITY,BILL_QUANTITY_BONUS,";
            strSQL = strSQL + "BILL_UOM,BILL_PER,BILL_RATE,BILL_AMOUNT,";
            strSQL = strSQL + "BILL_ADD_LESS,BILL_ADD_LESS_AMOUNT ,";
            strSQL = strSQL + "BILL_NET_AMOUNT,BILL_TRAN_TOBY,";
            strSQL = strSQL + "BILL_TRAN_POSITION";
            if (vstrCurrrency != "")
            {
                strSQL = strSQL + ",VOUCHER_CURRENCY_SYMBOL ";
            }

            if (vstrAgnstRefNo != "")
            {
                strSQL = strSQL + ",AGNST_COMP_REF_NO ";
            }
            if (vstrBatchNo != "")
            {
                strSQL = strSQL + ",INV_LOG_NO ";
            }
            if (vstrItemDesc != "")
            {
                strSQL = strSQL + ",STOCKITEM_DESCRIPTION ";
            }
            if (strOrderRefNo != "")
            {
                strSQL = strSQL + ",ORDER_REF_NO";
            }
            if (vstrItemNameBangla != "")
            {
                strSQL = strSQL + ",ITEM_NAME_BANGLA";
            }

            strSQL = strSQL + ") ";
            strSQL = strSQL + "VALUES(";
            strSQL = strSQL + "'" + vstrBranchID + "',";
            strSQL = strSQL + "'" + vstrBillKey.Trim() + "',";
            strSQL = strSQL + "'" + vstrRefNo.Trim() + "'," + vlngVType + ",";
            strSQL = strSQL + " " + Utility.cvtSQLDateString(vstrDate) + ",";
            strSQL = strSQL + "'" + vstrItemName + "',";//            'Item Name
            strSQL = strSQL + "'" + vstrGodownName + "',";//        'Location
            strSQL = strSQL + "'" + vdblQty + "',";//                'Qty
            strSQL = strSQL + "'" + vdblBonusQty + "',";//           'BonusQty
            strSQL = strSQL + "'" + vstrUom + "',";//              'Unit
            strSQL = strSQL + "'" + vstrPer + "',";//                 'Unit
            strSQL = strSQL + " " + vdblrate + ",";//              'Rate
            strSQL = strSQL + " " + vdblTotalAmount + ",";//          'Total
            strSQL = strSQL + " '" + vstrAddLess + "',";//         'Add/Less
            strSQL = strSQL + " " + vdblDiscount + ",";//
            strSQL = strSQL + " " + vdblDebitValue + ",";//         'Net Amount
            strSQL = strSQL + "'" + vstrDrCr + "',";//
            strSQL = strSQL + "" + vlngposition + "";
            if (vstrCurrrency != "")
            {
                strSQL = strSQL + ",'" + vstrCurrrency + "'";
            }
            if (vstrAgnstRefNo != "")
            {
                strSQL = strSQL + ",'" + vstrAgnstRefNo + "'";
            }
            if (vstrBatchNo != "")
            {
                strSQL = strSQL + ",'" + vstrBatchNo + "'";
            }

            if (vstrItemDesc != "")
            {
                strSQL = strSQL + ",'" + vstrItemDesc + "'";
            }
            if (strOrderRefNo != "")
            {
                strSQL = strSQL + ",'" + strOrderRefNo + "'";
            }
            if (vstrItemNameBangla != "")
            {
                strSQL = strSQL + ",'" + vstrItemNameBangla.Replace("'", "''");
            }
            strSQL = strSQL + ")";
            return strSQL;

        }


        public string gInsertBillTranFC(string vstrBillKey ,
                                         string vstrRefNo ,
                                         long vlngVType ,
                                         string vdteDate ,
                                         string vstrItemName ,
                                         string vstrGodownName ,
                                         double vdblQty ,
                                         double vdblBonusQty ,
                                         string vstrUom ,
                                         double vdblrate ,
                                         double vdblTotalAmount,
                                         string vstrAddLess ,
                                         double vdblDiscount ,
                                         double vdblDebitValue ,
                                         string vstrDrCr ,
                                         double vdblCurrRate ,
                                         double vdblFCDebit ,
                                         string vstrBranchID ,
                                         string vstrCurrFormalName,
                                         long vlngposition =0, 
                                         string vstrPer ="",
                                         string vstrSalesRep="",
                                         string vstrBatchNo ="", string strOrderRefNo ="",string vstrItemNameBangla="")
        {


            string strSQL = "";

                strSQL = "INSERT INTO ACC_BILL_TRAN";
                strSQL = strSQL + "(BRANCH_ID,BILL_TRAN_KEY,COMP_REF_NO,COMP_VOUCHER_TYPE,COMP_VOUCHER_DATE,";
                strSQL = strSQL + "STOCKITEM_NAME,GODOWNS_NAME,BILL_QUANTITY,";
                strSQL = strSQL + "BILL_UOM,BILL_PER,BILL_RATE,BILL_AMOUNT,BILL_ADD_LESS,BILL_ADD_LESS_AMOUNT ,";
                strSQL = strSQL + "BILL_NET_AMOUNT,BILL_TRAN_TOBY,";
                strSQL = strSQL + "FC_CONVERSION_RATE,VOUCHER_FC_AMOUNT,VOUCHER_CURRENCY_SYMBOL ";
                if  (vlngposition !=0)
                {
                    strSQL = strSQL + ",BILL_TRAN_POSITION";
                }
    
                if  (vstrBatchNo !="")
                {
                    strSQL = strSQL + ",INV_LOG_NO ";
                }
                if  (strOrderRefNo !="")
                {
                    strSQL = strSQL + ",ORDER_REF_NO";
                }
                if  (vstrItemNameBangla !="")
                {
                    strSQL = strSQL + ",ITEM_NAME_BANGLA";
                }
                strSQL = strSQL + ") ";
                strSQL = strSQL + "VALUES(";
                strSQL = strSQL + "'" + vstrBranchID + "',";
                strSQL = strSQL + "'" + vstrBillKey.Trim() + "',";
                strSQL = strSQL + "'" + vstrRefNo.Trim() + "'," + vlngVType + ",";
                strSQL = strSQL + " " + Utility.cvtSQLDateString (vdteDate) + ",";
                strSQL = strSQL + "'" + vstrItemName.Trim() + "',"   ; // 'Item Name
                strSQL = strSQL + "'" + vstrGodownName.Trim() + "',"  ;// 'Location
                strSQL = strSQL + "'" + vdblQty + "',"     ;            //'Qty
                strSQL = strSQL + "'" + vstrUom + "',"   ;            //  'Unit
                strSQL = strSQL + "'" + vstrPer + "',"  ;           //    'Per
                strSQL = strSQL + " " + vdblrate + ","    ;          //   'Rate
                strSQL = strSQL + " " + vdblTotalAmount + ",";       //   'Total
                strSQL = strSQL + "'" + vstrAddLess + "',"  ;       //    'Add/Less
                strSQL = strSQL + " " + vdblDiscount + ",";
                strSQL = strSQL + " " + vdblDebitValue + "," ;    //      'Net Total
                strSQL = strSQL + "'" + vstrDrCr + "'";
                strSQL = strSQL + "," + vdblCurrRate + ", ";
                strSQL = strSQL + " " + vdblFCDebit + ",";
                strSQL = strSQL + "'" + vstrCurrFormalName + "' ";
                if  (vlngposition != 0)
                {
                    strSQL = strSQL + ", " + vlngposition + "";
                }
                if  (vstrBatchNo !="")
                {
                    strSQL = strSQL + ",'" + vstrBatchNo + "'";
                }
                if (strOrderRefNo !="")
                {
                    strSQL = strSQL + ",'" + strOrderRefNo + "'";
                }
                if (vstrItemNameBangla !="")
                {
                    strSQL = strSQL + ",'" + vstrItemNameBangla.Replace("'","''") + "'";
                }
                strSQL = strSQL + ")";
                return strSQL;

        }





    }
}
