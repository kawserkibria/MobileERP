using Dutility;
using JA.Modulecontrolar.JACCMS;
using JA.Modulecontrolar.UI.DReport.Accms.ParameterForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JA.Modulecontrolar.UI.Accms.Forms
{
    public partial class frmIncentiveConfig : JA.Shared.UI.frmSmartFormStandard
    {
        JACCMS.SWJAGClient accms = new SWJAGClient();
        SPWOIS objWois = new SPWOIS();
        public long lngFormPriv { get; set; }
        private string strComID { get; set; }
        public string strType { get; set; }
        public frmIncentiveConfig()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");
        }
     
        private void btnSave_Click(object sender, EventArgs e)
        {
          
        }

        private void frmIncentiveConfig_Load(object sender, EventArgs e)
        {
            this.DG.DefaultCellStyle.Font = new Font("verdana", 9);
            DG.AllowUserToAddRows = false;
            if (strType == "MPO")
            {
                textBox1.Text = "Medical Promotion Office";
                DG.Columns.Add(Utility.Create_Grid_Column("Class Name", "Class Name", 400, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 165, true, DataGridViewContentAlignment.TopLeft, false));
                //DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, false, DataGridViewContentAlignment.TopCenter, true));
                GetInctiveMPO("MPO");
            }
            else if (strType == "AH")
            {
                textBox1.Text = "Area Head";
                DG.Columns.Add(Utility.Create_Grid_Column("Area Head", "Area Head", 400, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 150, true, DataGridViewContentAlignment.TopLeft, false));
                //DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, false, DataGridViewContentAlignment.TopCenter, true));
                GetInctiveAH("AH");
            }
            else if (strType == "DH")
            {
                textBox1.Text = "Divisional Head";
                DG.Columns.Add(Utility.Create_Grid_Column("Divisional Head", "Divisional Head", 400, true, DataGridViewContentAlignment.TopLeft, true));
                DG.Columns.Add(Utility.Create_Grid_Column("Amount", "Amount", 150, true, DataGridViewContentAlignment.TopLeft, false));
                //DG.Columns.Add(Utility.Create_Grid_Column_button("Delete", "Delete", "Delete", 60, false, DataGridViewContentAlignment.TopCenter, true));
                GetInctiveDH("DH");
            }
        }
        private void GetInctiveMPO(string strType)
        {
            int introw = 0;
            List<AccountsLedger> objClss = accms.GetCustomerLedgerClass(strComID).ToList();
            if (objClss.Count > 0)
            {
                foreach (AccountsLedger oobjClss in objClss)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = oobjClss.strClass;
                    DG[1, introw].Value = Utility.mGetIncetiveConfig(strComID, oobjClss.strClass,1).ToString();
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
                lblTotal.Text =  "Total MPO :" + DG.Rows.Count;
            }
        }
        private void GetInctiveAH(string strType)
        {
            int introw = 0;
            List<AccountsLedger> objClss = accms.GetCustomerLedgeNew(strComID, "", 2).ToList();
            if (objClss.Count > 0)
            {
                foreach (AccountsLedger oobjClss in objClss)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = oobjClss.strRepName;
                    DG[1, introw].Value = Utility.mGetIncetiveConfig(strComID, oobjClss.strRepName, 2).ToString();
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
                lblTotal.Text = "Total AH :" + DG.Rows.Count;
            }
        }
        private void GetInctiveDH(string strType)
        {
            int introw = 0;

            List<AccountsLedger> objClss = accms.GetCustomerLedgeNew(strComID, "", 3).ToList();
            if (objClss.Count > 0)
            {
                foreach (AccountsLedger oobjClss in objClss)
                {
                    DG.Rows.Add();
                    DG[0, introw].Value = oobjClss.strRepName;
                    DG[1, introw].Value = Utility.mGetIncetiveConfig(strComID, oobjClss.strRepName, 3).ToString();
                    introw += 1;
                }
                DG.AllowUserToAddRows = false;
                lblTotal.Text = "Total DH :" + DG.Rows.Count;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string strDG = "",strLedgerName="",strInsert="";
            double dblAmount = 0;
            int intMode=0;
            if (textBox1.Text == "Medical Promotion Office")
            {
                intMode = 1;
            }
            else if (textBox1.Text == "Area Head")
            {
                intMode = 2;
            }
            else
            {
                intMode = 3;
            }
             var strResponseInsert = MessageBox.Show("Do You Want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < DG.Rows.Count; i++)
                        {
                            if (DG[0, i].Value.ToString() != null)
                            {
                                strLedgerName = DG[0, i].Value.ToString();
                            }
                            else
                            {
                                strLedgerName = "";
                            }
                            if (DG[1, i].Value != null)
                            {
                                dblAmount = Utility.Val(DG[1, i].Value.ToString());
                            }
                            else
                            {
                                dblAmount = 0;
                            }


                            strDG = strDG + strLedgerName + "|" +
                                           dblAmount + "|" + intMode + "~"; //Amount

                           

                        }
                        strInsert = accms.mSsaveIncentiveConfig(strComID, strDG, intMode);
                        if (strInsert == "1")
                        {
                            MessageBox.Show("Save Successfully..");
                            this.Dispose();
                        }
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(EX.ToString());
                    }
            }
        }







    }
}
