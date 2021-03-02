using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;
using JA.Modulecontrolar;
using Dutility;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;
using JA.Modulecontrolar.JACCMS;
using System.Reflection;
using System.Linq;
using JA.Modulecontrolar.JINVMS;
using JA.Modulecontrolar.UI.Sales.Forms;


namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmChallanAdjust : Form
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        string strComID { get; set; }
        public string strFormType { get; set; }
        private ListBox lstLocation = new ListBox();
        private ListBox lstItem = new ListBox();
        public frmChallanAdjust()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");


            this.dteFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteFromDate_KeyPress);
            this.dteFromDate.GotFocus += new System.EventHandler(this.dteFromDate_GotFocus);

            this.dteToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dteToDate_KeyPress);
            this.dteToDate.GotFocus += new System.EventHandler(this.dteToDate_GotFocus);


            this.txtLocationName.KeyDown += new KeyEventHandler(txtLocationName_KeyDown);
            this.txtLocationName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtLocationName_KeyPress);
            this.txtLocationName.TextChanged += new System.EventHandler(this.txtLocationName_TextChanged);
            this.lstLocation.DoubleClick += new System.EventHandler(this.lstLocation_DoubleClick);
            this.txtLocationName.GotFocus += new System.EventHandler(this.txtLocationName_GotFocus);


            this.uctxtItemName.KeyDown += new KeyEventHandler(uctxtItemName_KeyDown);
            this.uctxtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(uctxtItemName_KeyPress);
            this.uctxtItemName.TextChanged += new System.EventHandler(this.uctxtItemName_TextChanged);
            this.lstItem.DoubleClick += new System.EventHandler(this.lstItem_DoubleClick);
            this.uctxtItemName.GotFocus += new System.EventHandler(this.uctxtItemName_GotFocus);
            this.chkFG.Click += new System.EventHandler(this.chkFG_Click);

            Utility.CreateListBox(lstLocation, pnlMain, txtLocationName);
            Utility.CreateListBox(lstItem, pnlMain, uctxtItemName);


        }
    
        #region "User Deifne"
        private void dteFromDate_GotFocus(object sender, System.EventArgs e)
        {
            lstItem.Visible = false;
            lstLocation.Visible = false;

        }
        private void dteToDate_GotFocus(object sender, System.EventArgs e)
        {
            lstItem.Visible = false;
            lstLocation.Visible = false;

        }
        private void dteFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {

                dteToDate.Focus();

            }
        }

        private void dteToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                uctxtItemName.Focus();

            }
        }
        private void uctxtItemName_TextChanged(object sender, EventArgs e)
        {
            lstItem.SelectedIndex = lstItem.FindString(uctxtItemName.Text);
        }

        private void lstItem_DoubleClick(object sender, EventArgs e)
        {
            uctxtItemName.Text = lstItem.Text;
            btnShow.Focus();
            lstItem.Visible = false;
        }

        private void uctxtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstItem.Items.Count > 0)
                {
                    uctxtItemName.Text = lstItem.Text;
                }
                lstItem.Visible = false;
                btnShow.Focus();

            }
        }
        private void uctxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstItem.SelectedItem != null)
                {
                    lstItem.SelectedIndex = lstItem.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstItem.Items.Count - 1 > lstItem.SelectedIndex)
                {
                    lstItem.SelectedIndex = lstItem.SelectedIndex + 1;
                }
            }

        }
        private void mLoadLocation()
        {
            lstLocation.ValueMember = "strLocation";
            lstLocation.DisplayMember = "strLocation";
            lstLocation.DataSource = invms.mLoadLocation(strComID, Utility.gblnAccessControl, Utility.gstrUserName).ToList();
        }
        private void uctxtItemName_GotFocus(object sender, System.EventArgs e)
        {
            lstItem.Visible = true;
            lstLocation.Visible = false;

            lstItem.SelectedIndex = lstItem.FindString(uctxtItemName.Text);

        }
        private void txtLocationName_TextChanged(object sender, EventArgs e)
        {
            lstLocation.SelectedIndex = lstLocation.FindString(txtLocationName.Text);
        }

        private void lstLocation_DoubleClick(object sender, EventArgs e)
        {
            txtLocationName.Text = lstLocation.Text;
            dteFromDate.Focus();
        }

        private void txtLocationName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (lstLocation.Items.Count > 0)
                {
                    txtLocationName.Text = lstLocation.Text;
                }
                dteFromDate.Focus();

            }
        }
        private void txtLocationName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lstLocation.SelectedItem != null)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lstLocation.Items.Count - 1 > lstLocation.SelectedIndex)
                {
                    lstLocation.SelectedIndex = lstLocation.SelectedIndex + 1;
                }
            }

        }

        private void txtLocationName_GotFocus(object sender, System.EventArgs e)
        {
            lstLocation.Visible = true;
            lstItem.Visible = false;

            lstLocation.SelectedIndex = lstLocation.FindString(txtLocationName.Text);

        }

        #endregion

      
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
      
        private void btnOk_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            SqlCommand cmdupdate = new SqlCommand();
            string connstring = Utility.SQLConnstringComSwitch(strComID);

            try
            {
                using (SqlConnection gcnMain = new SqlConnection(connstring))
                {
                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }
                    gcnMain.Open();

                    cmdupdate.Connection = gcnMain;
                    progressBar1.Value = 0;
                    progressBar1.Maximum = DG.Rows.Count;
                    for (int introw = 1; introw < DG.Rows.Count; introw++)
                    {
                        strSQL = "UPDATE INV_TRAN SET ";
                        strSQL = strSQL + "INV_TRAN_QUANTITY=" + Utility.Val(DG[4, introw].Value.ToString()) *-1;
                        strSQL = strSQL + ",OUTWARD_QUANTITY=" + Utility.Val(DG[4, introw].Value.ToString()) *-1;
                        strSQL = strSQL + ",INV_TRAN_AMOUNT= INV_TRAN_RATE * " + Utility.Val(DG[4, introw].Value.ToString());
                        strSQL = strSQL + ",OUTWARD_SALES_AMOUNT=INV_TRAN_RATE *" + (Utility.Val(DG[4, introw].Value.ToString())) *-1;
                        strSQL = strSQL + ",OUTWARD_COST_AMOUNT=INV_TRAN_RATE * " + (Utility.Val(DG[4, introw].Value.ToString())) *-1;
                        strSQL = strSQL + "WHERE INV_TRAN_KEY='" + DG[1, introw].Value.ToString() + "' ";
                        strSQL = strSQL + "AND STOCKITEM_NAME='" + DG[3, introw].Value.ToString() + "' ";
                        strSQL = strSQL + "AND INV_REF_NO='" + DG[2, introw].Value.ToString() + "' ";
                        strSQL = strSQL + "AND INV_VOUCHER_TYPE=15 ";
                        cmdupdate.CommandText = strSQL;
                         cmdupdate.ExecuteNonQuery();
                        progressBar1.Value += 1;
                    }
                    MessageBox.Show("Update...");
                    DG.Rows.Clear();
                    txtLocationName.Focus();
                    cmdupdate.Dispose();
                    gcnMain.Close();


                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
        }

       
        private void frmUpdateAVG_Load(object sender, EventArgs e)
        {
            
            DG.AllowUserToAddRows = false;
            
            DG.Columns.Add(Utility.Create_Grid_Column("Date", "Date", 70, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Key", "Key", 200, false, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Voucher No", "Voucher No", 200, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Item Name", "Item Name", 230, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("QTY", "QTY", 150, true, DataGridViewContentAlignment.TopLeft, false));

            mLoadLocation();
            mLaodItem();
            txtLocationName.Focus();
            txtLocationName.Select();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }



       

        private void mLaodItem()
        {
            if (chkFG.Checked == false)
            {

                lstItem.ValueMember = "strItemName";
                lstItem.DisplayMember = "strItemName";
                //lstItem.DataSource = invms.gFillStockItemAllWithoutGodown(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "").ToList();
                lstItem.DataSource = invms.gFillStockItemAllWithoutGodown(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "N").ToList();
            }
            else
            {
                lstItem.ValueMember = "strItemName";
                lstItem.DisplayMember = "strItemName";
                lstItem.DataSource = invms.gFillStockItemAllWithoutGodown(strComID, Utility.gblnAccessControl, Utility.gstrUserName, "FST").ToList();
            }


        }


        private void chkFG_Click(object sender, EventArgs e)
        {
            mLaodItem();
            uctxtItemName.Focus();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            SqlCommand cmdupdate=new SqlCommand();
            string connstring = Utility.SQLConnstringComSwitch(strComID);

            try
            {
                using (SqlConnection gcnMain = new SqlConnection(connstring))
                {
                    if (gcnMain.State == ConnectionState.Open)
                    {
                        gcnMain.Close();
                    }
                    gcnMain.Open();

                    cmdupdate.Connection = gcnMain;
                    DG.Rows.Clear();
                    strSQL = "SELECT INV_DATE,INV_TRAN_KEY,INV_REF_NO ,STOCKITEM_NAME,INV_TRAN_QUANTITY FROM INV_TRAN WHERE INV_VOUCHER_TYPE =15  AND INV_REF_NO LIKE 'SC%'  ";
                    strSQL = strSQL + "AND STOCKITEM_NAME ='" + uctxtItemName.Text + "' ";
                    strSQL = strSQL + "AND GODOWNS_NAME ='" + txtLocationName.Text + "' ";
                    strSQL = strSQL + "AND INV_DATE BETWEEN " + Utility.cvtSQLDateString(dteFromDate.Text) + " ";
                    strSQL = strSQL + "AND  " + Utility.cvtSQLDateString(dteToDate.Text) + " ";
                    DataTable dt;
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(strSQL, gcnMain);
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        int introw = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            DG.Rows.Add();
                            DG[0, introw].Value = row["INV_DATE"].ToString();
                            DG[1, introw].Value = row["INV_TRAN_KEY"].ToString();
                            DG[2, introw].Value = row["INV_REF_NO"].ToString();
                            DG[3, introw].Value = row["STOCKITEM_NAME"].ToString();
                            DG[4, introw].Value = Math.Abs(Utility.Val(row["INV_TRAN_QUANTITY"].ToString()));

                            introw += 1;

                        }

                    }
                    calculateTotal();


                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }

        }


        #region "Calculatetotal
        private void calculateTotal()
        {
            double dblQty = 0;
            try
            {
                for (int i = 0; i < DG.Rows.Count; i++)
                {

                    dblQty = dblQty + Convert.ToDouble(DG.Rows[i].Cells[4].Value);

                }
                lblQty.Text = dblQty.ToString();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calculateTotal();
        }
       

       
  

        
        

       

      

       
    
       
    }
}