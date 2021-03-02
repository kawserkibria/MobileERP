
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dutility
{
    public class CreateDefaultdata
    {
        public static void gInsertDefaultData(Boolean vblnNonIntregrated, string vstrCurrency, string vstrBusinessType, string vstrBranchID, string vstrCompanyName)
        {
            mInsertDefaultLedgerGroup(vblnNonIntregrated, vstrBusinessType);
            mInsertDefaultLedger(vstrCurrency, vstrBranchID, vstrCompanyName);
            if (vstrBusinessType == "Manufacturing Company")
            {
                gDefaultStockGroup();
            }
            mInsertLocations(vstrBranchID);
            mInsertVoucherType();
            mInsertFormContol();
        }
        private static string mInsertVoucherType()
        {

            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();
                string strSQL;

                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Payment',2, 0, '1', '6', 'PV#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Receipt 1
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Receipt', 1, 0, '1', '6', 'RV#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Journal 3
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Journal',3,  0, '1', '6', 'JV#','', 0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Contra 4
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Contra',4,  0, '1', '6', 'CV#','', 0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'    'Quotation 0
                //'    strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Quotation', 0, 1, '1', '6', 'QO#','', 0 )"
                //'    gcnMain.Execute strSQL
                //'Sales Sample 17
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Sales Sample', 17, 0, '1', '6', 'SQ#','', 0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                // 'Sales Order 12
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Sales Order', 12, 0, '1', '6', 'SO#','', 0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                // 'Delivery Order 14
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Delivery Order', 14, 0, '1', '6', 'DO#','', 0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Sales Challan 15
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Sales Challan', 15, 0, '1', '6', 'SC#','', 0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                // 'Sales Invoice 16
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Sales Invoice', 16, 0, '1', '6', 'SI#','', 0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'    'Sales Invoice Pos 18
                //'    strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Sales Invoice Pos', 18, 0, '1', '6', 'SP#','', 2 )"
                //'    gcnMain.Execute strSQL
                //'Sales Return 13
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Sales Return', 13, 0, '1', '6', 'SR#','', 0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Purchase Order 31
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Purchase Order', 31, 0, '1', '6', 'PO#','', 0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Purchase Receive 34
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Receive Inventory', 34, 0, '1', '6', 'PR#','', 0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Purchase Invoice 33
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Purchase Invoice', 33, 0, '1', '6', 'PI#','', 0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                // 'Purchase Return 32
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Purchase Return', 32, 0, '1', '6', 'PE#','', 0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Consumption 22
                //'    strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Consumption', 22, 1, '1', '6', 'IO#','', 0 )"
                //'    gcnMain.Execute strSQL
                //'    'Finished Goods 21
                //'    strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Finished Goods', 21, 1, '1', '6', 'II#','', 0 )"
                //'    gcnMain.Execute strSQL
                //'Stock Damage 24
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Stock Damage',24,  0, '1', '6', 'ID#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Physical Stock 25
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Physical Stock', 25, 0, '1', '6', 'IP#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Stock Transfer 23
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Stock Transfer', 23, 0, '1', '6', 'IT#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Stock Return 28
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Stock Return', 28, 0, '1', '6', 'ST#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Stock Requisition', 40, 1, '1', '6', 'RQ#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Stock Consumption', 26, 0, '1', '6', 'MC#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //''    'Stock MFG Consumption 26
                //''    strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Manufacturing Consumption', 26, 1, '1', '6', 'MC#','',  0 )"
                //''    gcnMain.Execute strSQL
                //''    'Stock MFG Finished Goods 27
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Finished Goods', 27, 0, '1', '6', 'MF#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                // 'STOCK MANUFACTURING VOUCHER 29
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('MFG Voucher', 29, 0, '1', '6', 'MV#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('MFG Production', 51, 0, '1', '6', 'MP#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Customer Receive', 41, 0, '1', '6', 'CR#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Delivery/Issue to Customer Slip', 42, 0, '1', '6', 'DS#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Replace/Return to Supplier', 43, 0, '1', '6', 'RC#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Receive from Supplier', 44, 0, '1', '6', 'RI#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_VOUCHER_TYPE(VOUCHER_TYPE_NAME,VOUCHER_TYPE_VALUE, VOUCHER_TYPE_NUMBERING_METHOD, VOUCHER_TYPE_BEGINING_NUMBER,VOUCHER_TYPE_NUMERIC_WIDTH,VOUCHER_TYPE_PREFIX,VOUCHER_TYPE_SUFFIX,VOUCHER_TYPE_PRINTAFTERSAVE ) VALUES ('Stok Transfer IN', 55, 0, '1', '6', 'TI#','',  0 )";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL="INSERT into ACC_INVOICE_CONFIG(SALES_INVOICE_ITEM_DESCRIPTION,SALES_DISCOUNT_ALLOWED,ALLOW_SEPARATE_PARTY_NAME,BLOCK_NEGATIVE_STOCK) ";
                strSQL = strSQL + "values(0,0,0,1) ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Transaction.Commit();
                return strSQL;

            }
        }
        private static string gDefaultStockGroup()
        {

            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();
                string strSQL;

                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "INSERT INTO INV_STOCKGROUP(STOCKGROUP_NAME,STOCKGROUP_PARENT,STOCKGROUP_ONE_DOWN,STOCKGROUP_PRIMARY,STOCKGROUP_LEVEL,STOCKGROUP_SEQUENCES,STOCKGROUP_PRIMARY_TYPE,STOCKGROUP_SECONDARY_TYPE, STOCKGROUP_DEFAULT,STOCKGROUP_NAME_DEFAULT) VALUES('Direct Raw Materials','Direct Raw Materials','Direct Raw Materials','Direct Raw Materials',1,990,1,1,1,'Direct Raw Materials')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO INV_GROUP_TO_STOCKITEM(STOCKGROUP_PARENT,STOCKGROUP_NAME) VALUES('Direct Raw Materials','Direct Raw Materials')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //'Indirect Raw Materials
                strSQL = "INSERT INTO INV_STOCKGROUP(STOCKGROUP_NAME,STOCKGROUP_PARENT,STOCKGROUP_ONE_DOWN,STOCKGROUP_PRIMARY,STOCKGROUP_LEVEL,STOCKGROUP_SEQUENCES,STOCKGROUP_PRIMARY_TYPE,STOCKGROUP_SECONDARY_TYPE,STOCKGROUP_DEFAULT,STOCKGROUP_NAME_DEFAULT) VALUES('" + "Indirect Raw Materials','Indirect Raw Materials','Indirect Raw Materials','Indirect Raw Materials',1,980,1,2,1,'Indirect Raw Materials')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO INV_GROUP_TO_STOCKITEM(STOCKGROUP_PARENT,STOCKGROUP_NAME) VALUES('Indirect Raw Materials','Indirect Raw Materials')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //'Work in Progress
                strSQL = "INSERT INTO INV_STOCKGROUP(STOCKGROUP_NAME,STOCKGROUP_PARENT,STOCKGROUP_ONE_DOWN,STOCKGROUP_PRIMARY,STOCKGROUP_LEVEL,STOCKGROUP_SEQUENCES,STOCKGROUP_PRIMARY_TYPE,STOCKGROUP_DEFAULT,STOCKGROUP_NAME_DEFAULT) VALUES('Work in Progress','" + "Work in Progress','Work in Progress','Work in Progress',1,900,2,1,'Work in Progress')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO INV_GROUP_TO_STOCKITEM(STOCKGROUP_PARENT,STOCKGROUP_NAME) VALUES('Work in Progress','Work in Progress')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //'Finished Goods
                strSQL = "INSERT INTO INV_STOCKGROUP(STOCKGROUP_NAME,STOCKGROUP_PARENT,STOCKGROUP_ONE_DOWN,STOCKGROUP_PRIMARY,STOCKGROUP_LEVEL,STOCKGROUP_SEQUENCES,STOCKGROUP_PRIMARY_TYPE,STOCKGROUP_DEFAULT,STOCKGROUP_NAME_DEFAULT) VALUES('Finished Goods','" + "Finished Goods','" + "Finished Goods','" + "Finished Goods',1,800,3,1,'" + "Finished Goods')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO INV_GROUP_TO_STOCKITEM(STOCKGROUP_PARENT,STOCKGROUP_NAME) VALUES('" + "Finished Goods','" + "Finished Goods')";
 
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Transaction.Commit();
                return strSQL;

            }
        }



        public static void gInsertAccessControl(string VstrUserName, 
                                string vstrPassword, byte[] vImage,string vstrBranchID ="")
        {
            mInsertUser(VstrUserName, vstrPassword, vImage);
            //gInsertPrivileges(VstrUserName, vstrBranchID);
            gInsertPrivilegesNew(VstrUserName, "A");
            
        }
        public class UserForm
        {
            public  long lngSLNo { get; set; }
        }
        public static void gInsertPrivilegesNew(string vstrUserName,string strAdminY_N)
        {
            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();
                string strSQL, strLogInKey = "";
                SqlDataReader dr;

                List<UserForm> ooform = new List<UserForm>();

                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;
                if (vstrUserName == "")
                {
                    return;
                }
                strSQL = "SELECT SL_NO FROM USER_FORM_CONFIG ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    UserForm oform = new UserForm();
                    oform.lngSLNo = Convert.ToInt64(dr["SL_NO"]);
                    ooform.Add(oform);
                }
                dr.Close();
                strSQL = "SELECT USER_LOGIN_NAME FROM USER_PRIVILEGES_MAIN where USER_LOGIN_NAME ='" + vstrUserName + "' ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                if (!dr.Read())
                {
                    dr.Close();
                    if (strAdminY_N == "A")
                    {

                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "1','" + vstrUserName + "',1,1)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "2','" + vstrUserName + "',2,1)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "3','" + vstrUserName + "',3,1)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "4','" + vstrUserName + "',4,1)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "9','" + vstrUserName + "',9,1)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "10','" + vstrUserName + "',10,1)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        foreach (UserForm ouser in ooform)
                        {
                            strLogInKey = vstrUserName + ouser.lngSLNo;
                            strSQL = "INSERT INTO USER_PRIVILEGES_CHILD(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_COMPONENT,PRI_ADD,PRI_EDIT,PRI_DELETE) VALUES('" + strLogInKey + "','" + vstrUserName + "'," + ouser.lngSLNo + ",1,1,1 )";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }

                    }
                    else
                    {
                        dr.Close();
                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "1','" + vstrUserName + "',1,0)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "2','" + vstrUserName + "',2,0)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "3','" + vstrUserName + "',3,0)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "4','" + vstrUserName + "',4,0)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "9','" + vstrUserName + "',9,0)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "10','" + vstrUserName + "',10,1)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        foreach (UserForm ouser in ooform)
                        {
                            strLogInKey = vstrUserName + ouser.lngSLNo;
                            strSQL = "INSERT INTO USER_PRIVILEGES_CHILD(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_COMPONENT,PRI_ADD,PRI_EDIT,PRI_DELETE) VALUES('" + strLogInKey + "','" + vstrUserName + "'," + ouser.lngSLNo + ",0,0,0 )";
                            cmdInsert.CommandText = strSQL;
                            cmdInsert.ExecuteNonQuery();
                        }
                    }

                }
                dr.Close();
                if (strAdminY_N == "A")
                {
                    strSQL = "INSERT INTO USER_PRIVILEGES_BRANCH(USER_LOGIN_KEY,USER_LOGIN_NAME,BRANCH_ID)";
                    strSQL = strSQL + " SELECT (BRANCH_ID + '" + vstrUserName.Trim().Replace("'", "''") + "'),'" + vstrUserName.Trim().Replace("'", "''") + "',BRANCH_ID FROM ACC_BRANCH ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO USER_PRIVILEGES_LOCATION(USER_LOGIN_NAME,GODOWNS_NAME) ";
                    strSQL = strSQL + "SELECT '" + vstrUserName.Trim().Replace("'", "''") + "',GODOWNS_NAME FROM INV_GODOWNS ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                cmdInsert.Transaction.Commit();
            }

        }
        public static void gUpdatePrivilegesNew(string vstrOldUserName, string vstrUserName, string strAdminY_N)
        {
            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();
                string strSQL, strLogInKey = "";
                SqlDataReader dr;

                List<UserForm> ooform = new List<UserForm>();

                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "SELECT SL_NO FROM USER_FORM_CONFIG ";
                cmdInsert.CommandText = strSQL;
                dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    UserForm oform = new UserForm();
                    oform.lngSLNo = Convert.ToInt64(dr["SL_NO"]);
                    ooform.Add(oform);
                }
                dr.Close();
                strSQL = "DELETE from USER_PRIVILEGES_CHILD ";
                strSQL = strSQL + " WHERE USER_LOGIN_NAME='" + vstrOldUserName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM USER_PRIVILEGES_BRANCH ";
                strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + vstrOldUserName.Trim().Replace("'", "''") + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE FROM USER_PRIVILEGES_LOCATION ";
                strSQL = strSQL + "WHERE USER_LOGIN_NAME = '" + vstrOldUserName.Trim().Replace("'", "''") + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "DELETE from USER_PRIVILEGES_MAIN ";
                strSQL = strSQL + " WHERE USER_LOGIN_NAME='" + vstrOldUserName + "' ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                if (strAdminY_N == "A")
                {
                    strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "1','" + vstrUserName + "',1,1)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "2','" + vstrUserName + "',2,1)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "3','" + vstrUserName + "',3,1)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "4','" + vstrUserName + "',4,1)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "9','" + vstrUserName + "',9,1)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "10','" + vstrUserName + "',10,1)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                else
                {
                    strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "1','" + vstrUserName + "',1,0)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "2','" + vstrUserName + "',2,0)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "3','" + vstrUserName + "',3,0)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "4','" + vstrUserName + "',4,0)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "9','" + vstrUserName + "',9,0)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO USER_PRIVILEGES_MAIN(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_MODULE,PRI_TYPE) VALUES('" + vstrUserName + "10','" + vstrUserName + "',10,0)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                
                foreach (UserForm ouser in ooform)
                {
                    strLogInKey = vstrUserName + ouser.lngSLNo;
                    if (strAdminY_N == "A")
                    {
                        strSQL = "INSERT INTO USER_PRIVILEGES_CHILD(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_COMPONENT,PRI_ADD,PRI_EDIT,PRI_DELETE) VALUES('" + strLogInKey + "','" + vstrUserName + "'," + ouser.lngSLNo + ",1,1,1 )";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    else
                    {
                        strSQL = "INSERT INTO USER_PRIVILEGES_CHILD(USER_LOGIN_KEY,USER_LOGIN_NAME,PRI_COMPONENT,PRI_ADD,PRI_EDIT,PRI_DELETE) VALUES('" + strLogInKey + "','" + vstrUserName + "'," + ouser.lngSLNo + ",0,0,0 )";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }

                    dr.Close();
                }
                if (strAdminY_N == "A")
                {
                    strSQL = "INSERT INTO USER_PRIVILEGES_BRANCH(USER_LOGIN_KEY,USER_LOGIN_NAME,BRANCH_ID)";
                    strSQL = strSQL + " SELECT (BRANCH_ID + '" + vstrUserName.Trim().Replace("'", "''") + "'),'" + vstrUserName.Trim().Replace("'", "''") + "',BRANCH_ID FROM ACC_BRANCH ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO USER_PRIVILEGES_LOCATION(USER_LOGIN_NAME,GODOWNS_NAME) ";
                    strSQL = strSQL + "SELECT '" + vstrUserName.Trim().Replace("'", "''") + "',GODOWNS_NAME FROM INV_GODOWNS ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                }
                dr.Close();
                cmdInsert.Transaction.Commit();
            }

        }
        public static void mInsertFormContol()
        {
            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();
                string strSQL;


                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                //--Sales Master
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnGroup','MPO Group',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnCustomer','Medical Representative',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnTeritorry','Teritorry',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesRep','Doctor/Customer',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnVoucherTypes','Voucher type',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnPriceLevel','Price level',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesPriceConfig','Sales Price Config.',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnGiftItem','Gift Item',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnBonus','Bonus',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnTransport','Transport',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnDestination','Destination',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSampleClass','Sample Class',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnTargetAchieve','Sales Target',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmCollectionCommitment','Collection Target',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnMonthlyCredit','Credit Limit',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnCollectionMonth','Collection Month',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnCollTarget','Collection Target',1,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //--Sales Transaction
                //strSQL = " INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmQuotation','Quotation',1,2)";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();
                //strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmSalesOrder','Sales Order',1,2)";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();
                //strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmReceiptVoucher','Receipt Voucher',1,2)";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();
                //strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmDeliveryOrder','Delivery Order',1,2)";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesInvoice','Sales Invoice',1,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesChallan','Sales Challan',1,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesReturn','Sales Return',1,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesSample','Sales Sample',1,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
              


                //--Sales reports
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnMpoList','Mpo List',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesPriceList','Sales price List',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProductWiseAnalysis','Product Wise Analysis',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesStattement','Sales Statement',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProductSalesStatment.','Product Sales State.',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnDesignationCategory.','Sales Statement Master',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnPartyWiseSalesStatement.','Pary Wise Sales State.',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProductShortStatement','Product Short Summ.',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProductShortDetails','Product Short(Details)',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnTargetSalesStatment','Sales Target Statement',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnTargetSalesStaYearly','Collection Target Statement',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnRptSalesInvoice','Sales invoice',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesStatIndividual','Sales Statement Indv.',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesStaPackSize','Sales State.(Pack Size).',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnStatistic','Statistical Product Sales',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesRegister','Sales Register',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnReturnRegister','Return Register',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnVoucherReports','Voucher Reports',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnCustomerList','Doctor/Customer List',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //--Purchase Master
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnGroups','Groups',2,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSupplier','Supplier',2,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnVoucherTypes','Voucher type',2,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //--Purchase Transaction
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnPurchaseInvoice','Purchase Invoice',2,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnPurchaseReturn','Purchase Return',2,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //--Purchase Reports
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSupplierslist','Supplier List',2,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = " INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnVoucherRPT','Voucher Reports',2,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmPayables','Payables',2,3)";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnPurchaseRegister','Purchase Register',2,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnReturnRegister','Return Register',2,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProductwiseAnalysis','Component Price List',2,3)";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();
                strSQL = " INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProductwiseAnalysis','Productwise Analysis',2,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //strSQL = " INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmBranchWiseReport','Branchwise Report',2,3)";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();
                //--Tools Master

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuInstallCompany','Create Company',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuEditCompany','Edit Company',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuSelectCompany','Select Company',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
               
                //Inventory Menu
                //***MASTER
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnGroupConfiguration','Commission Group',3,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnCustomer','Stock Group',3,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnCategory','Pack Size',3,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnCommissionConfig','Commission Config.',3,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnLocation','Location',3,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnMaterialType','Material Type',3,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnUnitMeasurement','Measurement Unit',3,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnStockItem','Stock Item',3,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnBatch','Batch Entry',3,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnVoucherTypes','Voucher Types',3,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProcessInformation','MFG Process',3,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnFgtoFg','FG to FG Process',3,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //***TRANSACTION
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnConsumption','Stock Consumption',3,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnFinishedGoods','Finished Goods',3,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnMFGVoucher','MFG Voucher',3,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnComversionFG','Conversion FG',3,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnStockDamage','Stock Damage',3,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnPhysicalStock','Physical Stock',3,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnStockTransfer','Stock Transfer',3,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //***REPORT
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnStockSummCPrice','Stock Sum. C Price',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnStockSummSPrice','Stock Sum. S Price',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnStockSummIPrice','Stock Sum. I Price',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnLocationSumm','Location Summary',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnStoreLedger','Store Ledger',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnVoucherReports','Vouchers Reports',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProfitability','Profitability',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnLocationWiseConsumtion','Location Wise Consumption',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnStockStatement','Stock Statement',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnStockStatementSumm','Stock Statement Summ.',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProductTopSheet','Product Top Sheet',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProductStatement','Product Statement',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnGroupCommission','Commission Group',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSlowFastMoving','Slow/Fast Moving',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnStockRegister','Stock Register',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnTopSheetSalesPrice','Top Sheet Sales Price',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProcessReport','Process report',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnStockSummPValue','Stock Summ. P.Value',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnBOmRegister','BOM Register',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnNetegivestock','Negative Stock',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnItemWiseLocationQty','Itemwise Location Qty.',3,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Accounts Menu

                //***MASTER
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnBranch','Branch',4,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnGroups','Group',4,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnLedger','Ledger',4,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnCostCategory','Cost Category',4,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnCostCenter','Cost Center',4,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnVoucherTypes','Voucher Types',4,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnFixedAssets','Fixed Assets',4,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnBudget','Budget',4,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnLedgerConfiguration','Ledger Configuration',4,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //***TRANSACTION
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnPayment','Payment',4,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnReceipt','Receipt',4,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnJournal','Journal',4,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnContra','Contra',4,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnMpoCommission','MPO Commission',4,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnInterestCharge','Interest Charge',4,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnDashBoard','Dash Board',4,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //***REPORT
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnAccountBooks','Account Books',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnVoucherReports','Voucher Reports',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnLedger','Ledger',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnDayBook','Day Book',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnCashBankBook','Cash & Bank Book',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnGroupSummary','Group Summary',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnTrailBalance','Trail Balance',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnReceiptPayment','Receipt & Payment',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnFinalAccounts','Final Accounts',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnCashFlow','Cash Flow',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnTrading','Trading',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProfitLoss','Profit & Loss',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnBalanceSheet','Balance Sheet',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnRptCostCenter','Cost Center Main',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnRptLedgerWise','Cost Center Ledger Wise',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnRptCostCategoryWise','Cost Category Wise',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnRptCostCenterWise','Cost Center Wise',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnManufacturing','Manufacturing',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnDailyCollection','Daily Collection',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnContractBill','Contract Party Bill',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnFinalStatement','Final Statement',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnMarketMonitoringSheet','Market Monitoring Sheet',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnExpenseSummary','Expense Summary',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnRptContarctPartBill1','Contract Party Bill-1',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnRptFixedAssets','Fixed Assets',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnRptPDC','Post Dated Cheque',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSPCommission','Special Commission',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesCollectionAchieve','Sales & Collection Achieve',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnChequePayment','Cheque Payment',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnChequePrint','Cheque Print',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //Sales Report
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnRptSalesChallan','Sales Challan',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnRptChallanPending','Sales Challan Pending',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //Tools
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuDeleteCompany','Delete Company',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuSplitCompany','Split Company',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuTransactionLock','Lock Transaction',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuCalculator','Calculator',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuChangePassword','Change Password',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuSignatoryOption','Signatory Option',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuReValuation','Stock Re-Valuation',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuAudit','User Activity Audit',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuERPStattistics','ERP Statistics',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuRebuidQuery','Rebuild Query',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuBackUp','Backup',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuRestore','Restore',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSecurity','Security',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuDecryptPass','Decrypt Password',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('mnuCopyChartofAccounts','Copy Chart of Accounts',9,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnBudgetVariance','Budget Variance',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesOrder','Sales Order',1,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnItemWiseTarget','Product Sales Target',1,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnReceiptDoctor','MPO Collection',4,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('radSalesOrderApproved','Sales Odrer Approved',1,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesStatementAmount','Sales Statement(Amount)',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesStatementProduct','Sales Statement(Product)',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnFinalStatement','Final Statement',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnSalesTarget','Sales Target',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProductSales','Product Sales',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProduct12Month','Product 12Month',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnCreditLimit','Credit Limit Report',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnMPOLedger','MPO Ledger',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProductSalesAnalysis',' Mpo Product Wise Sales Statement Qty',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnBankReconcilation','Bank Reconsilation',4,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnBankReceiptPayment','Bank Receipt Payment',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnLoanTemplate','Loan Template',4,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmRptHondLoan','Honda Loan Statement',4,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                //Projection Master
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmProjectionMonthSetup','Projection Month Setup',10,1)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                //Tran
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnProjection','Projection',10,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnMonthWiseProjection','Month Wise Projection',10,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnWeeklyProjection','Weekly Projection',10,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnPerformance','Performance',10,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnrptProjection','Projection Reports',10,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('btnrptCollectionComparision','Collection Comparision',10,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmrptProjectionQuickView','Projection Quick View',10,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmMPOHalt','MPO Halt',1,2)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmRptSalesCollectionPerformance','Sales/Collection Performance',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO USER_FORM_CONFIG(FORM_KEY,FORM_NAME,MODULE_TYPE,MODE_TYPE) VALUES('frmRptSalesOrder','Sales Order',1,3)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                cmdInsert.Transaction.Commit();



            }

        }
        public static void mInsertUser(string VstrUserName, string vstrPassword, byte[] vImage)
         {
             string strSQL="";
             using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
             {
                 if (gcnMain.State == System.Data.ConnectionState.Open)
                 {
                     gcnMain.Close();
                 }

                 gcnMain.Open();
                 vstrPassword = Utility.Encrypt(vstrPassword, VstrUserName);

                 SqlCommand cmdInsert = new SqlCommand();
                 SqlTransaction myTrans;
                 SqlDataReader dr;
                 myTrans = gcnMain.BeginTransaction();
                 cmdInsert.Connection = gcnMain;
                 cmdInsert.Transaction = myTrans;
                 if (VstrUserName != "")
                 {
                     strSQL = "SELECT USER_LOGIN_NAME FROM USER_CONFIG ";
                     strSQL = strSQL + " WHERE USER_LOGIN_NAME ='" + VstrUserName + "' ";
                     cmdInsert.CommandText = strSQL;
                     dr = cmdInsert.ExecuteReader();
                     if (!dr.Read())
                     {
                         dr.Close();
                         cmdInsert.CommandText = "InsertUserConfig";
                         cmdInsert.CommandType = CommandType.StoredProcedure;
                         cmdInsert.Parameters.Add("@loginName", SqlDbType.VarChar).Value = VstrUserName;
                         cmdInsert.Parameters.Add("@fullName", SqlDbType.VarChar).Value = VstrUserName;
                         cmdInsert.Parameters.Add("@pass", SqlDbType.VarChar).Value = vstrPassword;
                         cmdInsert.Parameters.Add("@intUserLevel", SqlDbType.Int).Value = 1;
                         cmdInsert.Parameters.Add("@userlevel", SqlDbType.Char).Value = 'A';
                         cmdInsert.Parameters.Add("@commmets", SqlDbType.VarChar).Value = "";
                         cmdInsert.Parameters.Add("@img", SqlDbType.Image).Value = vImage;
                         cmdInsert.Parameters.Add("@Department", SqlDbType.VarChar).Value = "Admin";
                         cmdInsert.Parameters.Add("@Designation", SqlDbType.VarChar).Value = "Admin-Default User";
                         cmdInsert.ExecuteNonQuery();
                     }
                     dr.Close();
                 }
                 cmdInsert.Transaction.Commit();
             }
           
         }

         public static void gInsertBaseCurrency(string strCurSymbol, string strCurName, string strCurString ="", long  lngDecimalPlaces =0)
         {
             using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
             {
                 if (gcnMain.State == System.Data.ConnectionState.Open)
                 {
                     gcnMain.Close();
                 }

                 gcnMain.Open();
                 string strSQL;
                 SqlCommand cmdInsert = new SqlCommand();
                 SqlTransaction myTrans;
                 myTrans = gcnMain.BeginTransaction();
                 cmdInsert.Connection = gcnMain;
                 cmdInsert.Transaction = myTrans;
                 strSQL = "INSERT INTO ACC_CURRENCY(CURRENCY_SYMBOL,CURRENCY_NAME) VALUES('BDT','Bangladeshi Taka')";
                 cmdInsert.CommandText = strSQL;
                 cmdInsert.ExecuteNonQuery();
                 strSQL = "INSERT INTO ACC_CURRENCY(CURRENCY_SYMBOL,CURRENCY_NAME) VALUES('$','US Dollar')";
                 cmdInsert.CommandText = strSQL;
                 cmdInsert.ExecuteNonQuery();
                 strSQL = "INSERT INTO ACC_CURRENCY(CURRENCY_SYMBOL,CURRENCY_NAME) VALUES('£','Pound Sterling')";
                 cmdInsert.CommandText = strSQL;
                 cmdInsert.ExecuteNonQuery();
                 strSQL = "INSERT INTO ACC_CURRENCY(CURRENCY_SYMBOL,CURRENCY_NAME) VALUES('¥','Yen')";
                 cmdInsert.CommandText = strSQL;
                 cmdInsert.ExecuteNonQuery();
                 strSQL = "INSERT INTO ACC_CURRENCY(CURRENCY_SYMBOL,CURRENCY_NAME) VALUES ('Rs.','Indian Rupee')";
                 cmdInsert.CommandText = strSQL;
                 cmdInsert.ExecuteNonQuery();
                 if (strCurString != "")
                 {
                     strSQL = "INSERT INTO ACC_CURRENCY(CURRENCY_SYMBOL,CURRENCY_NAME ";
                     strSQL = strSQL + ",CURRENCY_STRING ";
                     strSQL = strSQL + ",CURRENCY_DECIMAL ";
                     strSQL = strSQL + ")";
                     strSQL = strSQL + "VALUES ('" + strCurSymbol + "', '" + strCurName + "'";
                     strSQL = strSQL + ",'" + strCurString + "'";
                     strSQL = strSQL + ", '" + lngDecimalPlaces + "'";
                     strSQL = strSQL + ")";
                     cmdInsert.CommandText = strSQL;
                     cmdInsert.ExecuteNonQuery();
                 }

                 cmdInsert.Transaction.Commit();
                 //return strSQL;
             }

         }
    
        private static string mInsertLocations(string vstrBranchID)
        {

            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();
                string strSQL;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                //strSQL = "DELETE FROM J_INSTANCE ";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();
                //strSQL = "INSERT INTO J_INSTANCE(INSTANCE_NAME) VALUES('" + Utility.gstrInstanceName + "')";
                //cmdInsert.CommandText = strSQL;
                //cmdInsert.ExecuteNonQuery();
               

                strSQL = "INSERT INTO INV_GODOWNS(BRANCH_ID,GODOWNS_NAME,GODOWNS_PARENT_GROUP,GODOWNS_DEFAULT,GODOWNS_NAME_DEFAULT) VALUES('" + vstrBranchID + "','Main Location','Primary',1,'Main Location')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Transaction.Commit();
                return strSQL;
            }
        }

        private static string mInsertDefaultLedger(string vstrCurrency, string vstrBranchID, string vstrCompanyName)
        {

            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();
                string strSQL;
                string strBranchLedger;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                strSQL = "INSERT INTO ACC_LEDGER(LEDGER_NAME,LEDGER_PARENT_GROUP,";
                strSQL = strSQL + "LEDGER_PRIMARY_GROUP,LEDGER_ONE_DOWN,LEDGER_OPENING_BALANCE,";
                strSQL = strSQL + "LEDGER_GROUP,LEDGER_PRIMARY_TYPE,LEDGER_LEVEL,LEDGER_DEFAULT,LEDGER_CURRENCY_SYMBOL,LEDGER_NAME_DEFAULT,LEDGER_NAME_MERZE) VALUES('Cash','Cash in Hand','Current Assets', 'Cash in Hand',  0," + 101 + "," + 1 + ",3,1,'" + vstrCurrency + "','Cash','Cash')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('Cash in Hand','Cash')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('Current Assets','Cash')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('Assets','Cash')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO ACC_BRANCH_LEDGER_OPENING(BRANCH_LEDGER_KEY,BRANCH_ID,LEDGER_NAME) ";
                strSQL = strSQL + "VALUES ( 'Cash" + vstrBranchID + "','" + vstrBranchID + "',";
                strSQL = strSQL + "'Cash')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                //'Profit & Loss A/c
                strSQL = "INSERT INTO ACC_LEDGER(LEDGER_NAME,LEDGER_PARENT_GROUP,LEDGER_PRIMARY_GROUP,LEDGER_ONE_DOWN,LEDGER_OPENING_BALANCE,LEDGER_CLOSING_BALANCE,LEDGER_GROUP,LEDGER_LEVEL,LEDGER_PRIMARY_TYPE,LEDGER_DEFAULT,LEDGER_CURRENCY_SYMBOL,LEDGER_NAME_DEFAULT,LEDGER_NAME_MERZE) VALUES('Profit & Loss A/c','Profit & Loss Accounts','Profit & Loss Accounts', 'Profit & Loss A/c',  0, 0, " + 301 + ",  2,  2,1,'" + vstrCurrency + "','Profit & Loss A/c','Profit & Loss A/c')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('Profit & Loss Accounts','Profit & Loss A/c')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('Liabilities','Profit & Loss A/c')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO ACC_BRANCH_LEDGER_OPENING(BRANCH_LEDGER_KEY,BRANCH_ID,LEDGER_NAME) ";
                strSQL = strSQL + "VALUES ('Profit & Loss A/c" + vstrBranchID + "','" + vstrBranchID + "',";
                strSQL = strSQL + "'Profit & Loss A/c')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //'BRANCH LEDGER
                strBranchLedger = vstrCompanyName.Replace("'", "''");
                strSQL = "INSERT INTO ACC_LEDGER(LEDGER_NAME,LEDGER_PARENT_GROUP,LEDGER_PRIMARY_GROUP,";
                strSQL = strSQL + "LEDGER_ONE_DOWN,LEDGER_OPENING_BALANCE,LEDGER_CLOSING_BALANCE,LEDGER_GROUP,LEDGER_LEVEL,";
                strSQL = strSQL + "LEDGER_PRIMARY_TYPE,LEDGER_DEFAULT,LEDGER_CURRENCY_SYMBOL,LEDGER_NAME_DEFAULT,LEDGER_NAME_MERZE) ";
                strSQL = strSQL + "VALUES('" + strBranchLedger + "',";
                strSQL = strSQL + "'Branch/Divisions/Projects',";
                strSQL = strSQL + "'Branch/Divisions', 'Branch/Divisions/Projects'";
                strSQL = strSQL + ",0,0," + 217 + ",3,2,1,'" + vstrCurrency.Trim() + "', '" + strBranchLedger + "','"+ strBranchLedger+ "')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('Branch/Divisions/Projects','" + strBranchLedger + "')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('Branch/Divisions','" + strBranchLedger + "')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('Liabilities','" + strBranchLedger + "')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                strSQL = "INSERT INTO ACC_BRANCH_LEDGER_OPENING(BRANCH_LEDGER_KEY,BRANCH_ID,LEDGER_NAME) ";
                strSQL = strSQL + "VALUES ( '" + strBranchLedger +vstrBranchID + "','" + vstrBranchID + "',";
                strSQL = strSQL + "'" + strBranchLedger + "')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                cmdInsert.Transaction.Commit();
                return strSQL;

            }
        }
        private static string mInsertDefaultLedgerGroup(Boolean vblnNonIntegrated, string vstrBusinessType)
        {

            using (SqlConnection gcnMain = new SqlConnection(Utility.SQLConnstring()))
            {
                if (gcnMain.State == System.Data.ConnectionState.Open)
                {
                    gcnMain.Close();
                }

                gcnMain.Open();
                string strSQL;
                SqlCommand cmdInsert = new SqlCommand();
                SqlTransaction myTrans;
                myTrans = gcnMain.BeginTransaction();
                cmdInsert.Connection = gcnMain;
                cmdInsert.Transaction = myTrans;

                //'Fixed Assets
                strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,";
                strSQL = strSQL + "GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_DEFAULT_NAME,GR_CASH_FLOW_TYPE,GR_SEQUENCES) ";
                strSQL = strSQL + "VALUES('Fixed Assets','Assets','Fixed Assets','Fixed Assets',1, " + 206 + ",1,1,'Fixed Assets',2,900)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //'Current Assets
                strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,";
                strSQL = strSQL + "GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_DEFAULT_NAME,GR_CASH_FLOW_TYPE,GR_SEQUENCES) ";
                strSQL = strSQL + "VALUES('Current Assets','Assets',";
                strSQL = strSQL + "'Current Assets','Current Assets',1,0,1,1,'Current Assets',1,899)";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                //'Cash in Hand
                strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_DEFAULT_NAME) VALUES('Cash in Hand','Current Assets','Cash in Hand','Current Assets',2," + 101 + "," + 1 + ",1,'Cash in Hand') ";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Current Assets','Cash in Hand')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();


                //'Bank Accounts
                strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_DEFAULT_NAME) VALUES('Bank Accounts','Current Assets','Bank Accounts','Current Assets',2, " + 100 + "," + 1 + ",1,'Bank Accounts')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();
                strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Current Assets','Bank Accounts')";
                cmdInsert.CommandText = strSQL;
                cmdInsert.ExecuteNonQuery();

                //'Stock-in-hand
                if (vblnNonIntegrated)
                {
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_NAME,GR_DEFAULT_GROUP) VALUES('Stock-in-hand','Current Assets','Stock-in-hand','Current Assets',2," + 401 + ", 1,'Stock-in-hand',1)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Current Assets','Stock-in-hand')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (vstrBusinessType == "Manufacturing Company")
                    {
                        strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_NAME,GR_DEFAULT_GROUP,GR_MANUFAC_GROUP) VALUES('Direct Raw Materials','Stock-in-hand','Stock-in-hand','Current Assets',3," + 401 + ", 1,'Direct Raw Materials',1,1)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Current Assets','Stock-in-hand')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Stock-in-hand','Direct Raw Materials')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_NAME,GR_DEFAULT_GROUP,GR_MANUFAC_GROUP) VALUES('Indirect Raw Materials','Stock-in-hand','Stock-in-hand','Current Assets',3," + 401 + ", 1,'Indirect Raw Materials',1,2)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Stock-in-hand','Indirect Raw Materials')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();


                        strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_NAME,GR_DEFAULT_GROUP,GR_MANUFAC_GROUP) VALUES('Work in Progress','Stock-in-hand','Stock-in-hand','Current Assets',3," + 401 + ", 1,'Work in Progress',1,3)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Stock-in-hand','Work in Progress')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();


                        strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_NAME,GR_DEFAULT_GROUP,GR_MANUFAC_GROUP) VALUES('Finished Goods','Stock-in-hand','Stock-in-hand','Current Assets',3," + 401 + ", 1,'Finished Goods',1,4)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Stock-in-hand','Finished Goods')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }


                    if (vstrBusinessType == "Hospital")
                    {
                        //'Patient
                        strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME) VALUES('Patients','Current Assets','Patients','Current Assets',2, " + 202 + "," + 1 + ",1,1,'Patients')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Current Assets','Patients')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //'Out Patient
                        strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME) VALUES('Out Patients','Patients','Out Patients','Current Assets',3, " + 202 + "," + 1 + ",1,1,'Out Patients')"; ;
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Current Assets','Out Patients')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //'In Patient
                        strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME) VALUES('In Patients','Patients','In Patients','Current Assets',3, " + 202 + "," + 1 + ",1,1,'In Patients')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Current Assets','In Patients')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                    else
                    {
                    
                       // 'Sundry Debtors
                        strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME) VALUES('Sundry Debtors','Current Assets','Sundry Debtors','Current Assets',2, " + 202 + "," + 1 + ",1,1,'Sundry Debtors')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Current Assets','Sundry Debtors')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }


                    //'Liabilities
                    //'Paid up Capital
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,";
                    strSQL = strSQL + "GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_SEQUENCES,GR_DEFAULT_NAME) ";
                    strSQL = strSQL + "VALUES('Paid up Capital','Liabilities',";
                    strSQL = strSQL + "'Paid up Capital','Paid up Capital',1," + 205 + " ," + 2 + ",1,2,1000,'Paid up Capital')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'Current Liabilities
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,";
                    strSQL = strSQL + "GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_SEQUENCES,GR_DEFAULT_NAME) ";
                    strSQL = strSQL + "VALUES('Current Liabilities','";
                    strSQL = strSQL + "Liabilities',";//                      'GR_PARENT
                    strSQL = strSQL + "'Current Liabilities','";//            'GR_ONE_DOWN
                    strSQL = strSQL + "Current Liabilities',";//              'GR_PRIMARY
                    strSQL = strSQL + "1,";
                    strSQL = strSQL + "0," + 2 + ",1,1,998,'Current Liabilities')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'Sundry Creditors
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME) VALUES('Sundry Creditors','Current Liabilities','Sundry Creditors','Current Liabilities',2, " + 203 + "," + 2 + ",1,1,'Sundry Creditors')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Current Liabilities','Sundry Creditors')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'Loan Accounts
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,";
                    strSQL = strSQL + "GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_SEQUENCES, GR_DEFAULT_NAME) ";
                    strSQL = strSQL + "VALUES(";
                    strSQL = strSQL + "'Loan Accounts',";//                   'GR_NAME
                    strSQL = strSQL + "'Liabilities','";//                    'GR_PARENT
                    strSQL = strSQL + "Loan Accounts','";//
                    strSQL = strSQL + "Loan Accounts',1, ";
                    strSQL = strSQL + 205 + "," + 2 + ",1,1,999,'Loan Accounts')";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'Bank OD A/c
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_DEFAULT_NAME) VALUES('Bank OD A/c','Loan Accounts','Bank OD A/c','Loan Accounts',2, " + 100 + "," + 2 + ",1,'Bank OD A/c')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Loan Accounts','Bank OD A/c')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'Branch/Divisions
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,";
                    strSQL = strSQL + "GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_DEFAULT_NAME,GR_CASH_FLOW_TYPE) ";
                    strSQL = strSQL + "VALUES('Branch/Divisions',";         //'GR_NAME
                    strSQL = strSQL + "'Liabilities','";            //        'GR_PARENT
                    strSQL = strSQL + "Branch/Divisions','";
                    strSQL = strSQL + "Branch/Divisions',1, ";
                    strSQL = strSQL + 217 + "," + 2 + ",1,'Branch/Divisions',1)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();


                    //'Branch/Divisions/Projects
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,";
                    strSQL = strSQL + "GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_DEFAULT_NAME,GR_CASH_FLOW_TYPE) ";
                    strSQL = strSQL + "VALUES('Branch/Divisions/Projects',";//'GR_NAME
                    strSQL = strSQL + "'Branch/Divisions','";//               'GR_PARENT
                    strSQL = strSQL + "Branch/Divisions/Projects','";
                    strSQL = strSQL + "Branch/Divisions',2, ";
                    strSQL = strSQL + 217 + "," + 2 + ",1,'Branch/Divisions/Projects',1)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Branch/Divisions','Branch/Divisions/Projects')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //'Customer
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,";
                    strSQL = strSQL + "GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_DEFAULT_NAME,GR_CASH_FLOW_TYPE) ";
                    strSQL = strSQL + "VALUES('Customer',";//     'GR_NAME
                    strSQL = strSQL + "'Liabilities','";//                    'GR_PARENT
                    strSQL = strSQL + "Customer','";
                    strSQL = strSQL + "Customer',1,";
                    strSQL = strSQL + 204 + "," + 2 + ",1,'Customer',1)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'Profit & Loss Accounts
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,";
                    strSQL = strSQL + "GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_DEFAULT_NAME,GR_CASH_FLOW_TYPE) ";
                    strSQL = strSQL + "VALUES('Profit & Loss Accounts','Liabilities',";
                    strSQL = strSQL + "'Profit & Loss Accounts','Profit & Loss Accounts',1," + 301 + " ," + 2 + ",1,'Profit & Loss Accounts',1)";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'Sales Accounts
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME) VALUES('Sales Accounts','Income','Sales Accounts','Sales Accounts',1," + 211 + "," + 3 + ",1,1,'Sales Accounts')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'Other Income
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME) VALUES('Indirect Income','Income','Indirect Income','Indirect Income',1," + 215 + "," + 3 + ",1,1,'Indirect Income')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'Direct Expenses
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME) VALUES('Direct Expenses','Expenses','Direct Expenses','Direct Expenses',1," + 213 + "," + 4 + ",1,1,'Direct Expenses')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    //'Indirect Expenses
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME) VALUES('Indirect Expenses','Expenses','Indirect Expenses','Indirect Expenses',1, " + 205 + "," + 4 + ",1,1,'Indirect Expenses')";

                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    //Round Off
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_DEFAULT_NAME,GR_CASH_FLOW_TYPE) VALUES('Marketing,Selling & Distribution Expenses','Indirect Expenses','Marketing,Selling & Distribution Expenses','Indirect Expenses',2," + 205 + "," + 4 + ",1,'Marketing,Selling & Distribution Expenses',1) ";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Indirect Expenses','Marketing,Selling & Distribution Expenses')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    strSQL = "INSERT INTO ACC_LEDGER(LEDGER_NAME,LEDGER_PARENT_GROUP,";
                    strSQL = strSQL + "LEDGER_PRIMARY_GROUP,LEDGER_ONE_DOWN,LEDGER_OPENING_BALANCE,";
                    strSQL = strSQL + "LEDGER_GROUP,LEDGER_PRIMARY_TYPE,LEDGER_LEVEL,LEDGER_DEFAULT,LEDGER_CURRENCY_SYMBOL,LEDGER_NAME_DEFAULT,LEDGER_NAME_MERZE) VALUES('Round Off','Marketing,Selling & Distribution Expenses','Indirect Expenses', 'Marketing,Selling & Distribution Expenses',  0," + 205 + "," + 4 + ",3,1,'BDT','Round Off','Round Off' )";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();
                    strSQL = "INSERT INTO ACC_LEDGER_TO_GROUP(GR_NAME,LEDGER_NAME) VALUES('Marketing,Selling & Distribution Expenses','Round Off')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();



                    //'Purchase Accounts
                    strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME) VALUES('Purchase Accounts','Expenses','Purchase Accounts','Purchase Accounts',1," + 212 + "," + 4 + ",1,1,'Purchase Accounts')";
                    cmdInsert.CommandText = strSQL;
                    cmdInsert.ExecuteNonQuery();

                    if (vstrBusinessType == "Manufacturing Company")
                    {
                        // 'If vblnNonIntegrated Then
                        //'''Direct Raw Materials Purchase
                        strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME,GR_MANUFAC_GROUP) VALUES('Direct Raw Materials Purchase','Purchase Accounts','Direct Raw Materials Purchase','Purchase Accounts',2," + 212 + "," + 4 + ",1,1,'Direct Raw Materials Purchase',5)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Purchase Accounts','Direct Raw Materials Purchase')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //'Indirect Raw Materials Purchase
                        strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME,GR_MANUFAC_GROUP) VALUES('Indirect Raw Materials Purchase','Purchase Accounts','Indirect Raw Materials Purchase','Purchase Accounts',2," + 212 + "," + 4 + ",1,1,'Indirect Raw Materials Purchase',6)";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Purchase Accounts','Indirect Raw Materials Purchase')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();

                        //'Finished Goods Purchase
                        strSQL = "INSERT INTO ACC_LEDGERGROUP(GR_NAME,GR_PARENT,GR_ONE_DOWN,GR_PRIMARY,GR_LEVEL,GR_GROUP,GR_PRIMARY_TYPE,GR_DEFAULT_GROUP,GR_CASH_FLOW_TYPE,GR_DEFAULT_NAME) VALUES('Finished Goods Purchase','Purchase Accounts','Finished Goods Purchase','Purchase Accounts',2," + 216 + "," + 4 + ",1,1,'Finished Goods Purchase')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                        strSQL = "INSERT INTO ACC_GROUP_TO_LEDGER(GR_PARENT,GR_NAME) VALUES('Purchase Accounts','Finished Goods Purchase')";
                        cmdInsert.CommandText = strSQL;
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                cmdInsert.Transaction.Commit();
                return strSQL;

            }
        }



    }
}
