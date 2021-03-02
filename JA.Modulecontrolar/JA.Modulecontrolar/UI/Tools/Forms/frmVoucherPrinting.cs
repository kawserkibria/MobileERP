using Dutility;
using JA.Modulecontrolar.JINVMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using JA.Modulecontrolar.UI.Inventory;
using JA.Modulecontrolar.JACCMS;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Tools.Forms
{
    public partial class frmVoucherPrinting : JA.Shared.UI.frmSmartFormStandard
    {
        JINVMS.IWSINVMS invms = new JINVMS.WSINVMSClient();
        JACCMS.SWJAGClient accms = new SWJAGClient();
        public long lngFormPriv { get; set; }
        List<StockItem> oogrp;
        public int m_action { get; set; }
        private string strComID { get; set; }
        public frmVoucherPrinting()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string i = "", strDuplicate = "";
            int VouchaerTpe = 0, minimize = 0;
            if (cboxPaperSize.Text == "")
            {
                MessageBox.Show("Paper Size Cannot be Empty");
                cboxPaperSize.Focus();
                return;
            }
            if (Utility.gblnAccessControl)
            {
                if (!Utility.glngGetPriviliges(strComID,  Utility.gstrUserName, lngFormPriv, m_action))
                {
                     MessageBox.Show("You have no Permission to Access","Privileges",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return;
                }
            }

            if (radPaymentVoucher.Checked == true)
            {
                VouchaerTpe = 2;
            }
            else if (radJournalVoucher.Checked == true)
            {
                VouchaerTpe = 3;
            }
            else if (radReceiptVoucher.Checked == true)
            {
                VouchaerTpe = 1;
            }

            else if (radContraVoucher.Checked == true)
            {
                VouchaerTpe = 4;
            }


            if (cboxPaperSize.Text == "Full")
            {
                minimize = 0;
            }
            else
            {
                minimize = 1;
            }

                var strResponseInsert = MessageBox.Show("Do You  want to Save?", "Save Button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (strResponseInsert == DialogResult.Yes)
                {
                    try
                    {
                        i = accms.mSaveVoucherPrinting(strComID, txtVoucherH1.Text, txtVoucherH2.Text, txtVoucherH3.Text, txtVoucherH4.Text, txtVoucherH5.Text, VouchaerTpe, minimize);

                        MessageBox.Show("Save Successfully.");
                        mClear();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }       
        }

        private void frmVoucherPrinting_Load(object sender, EventArgs e)
        {
            datashow();
        }
        private void mClear()
        {
            txtVoucherH1.Text = "";
            txtVoucherH2.Text = "";
            txtVoucherH3.Text = "";
            txtVoucherH4.Text = "";
            txtVoucherH5.Text = "";
            cboxPaperSize.Text = "";
            textBox1.Text = "";
        }
        private void datashow()
        {
            string i = "", strDuplicate = "";
            int VouchaerTpe = 0, minimize = 0;

            if (radPaymentVoucher.Checked == true)
            {
                VouchaerTpe = 2;
            }
            else if (radJournalVoucher.Checked == true)
            {
                VouchaerTpe = 3;
            }
            else if (radReceiptVoucher.Checked == true)
            {
                VouchaerTpe = 1;
            }

            else if (radContraVoucher.Checked == true)
            {
                VouchaerTpe = 4;
            }
            int introw = 0;
            m_action = (int)Utility.ACTION_MODE_ENUM.EDIT_MODE;

            string strTeritoryCode, strTeritorryname, strAddress;
            List<AccVoucherHeader> ooaccVou = accms.mFilVoucherPrintingShow(strComID, VouchaerTpe).ToList();

            if (ooaccVou.Count > 0)
            {
                foreach (AccVoucherHeader oCom in ooaccVou)
                {
                    txtVoucherH1.Text = oCom.strVoucherHeader1;
                    txtVoucherH2.Text = oCom.strVoucherHeader2;
                    txtVoucherH3.Text = oCom.strVoucherHeader3;
                    txtVoucherH4.Text = oCom.strVoucherHeader4;
                    txtVoucherH5.Text = oCom.strVoucherHeader5;

                    textBox1.Text = Convert.ToInt32(oCom.dblMinimize).ToString();
                    if (textBox1.Text == "0")
                    {
                        cboxPaperSize.Text = "Full";

                    }
                    else
                    {
                        cboxPaperSize.Text = "Half";
                    }
                }

            }
        }

        private void radReceiptVoucher_Click(object sender, EventArgs e)
        {
            mClear();
            datashow();
        }

        private void radJournalVoucher_Click(object sender, EventArgs e)
        {
            mClear();
            datashow();
        }

        private void radContraVoucher_Click(object sender, EventArgs e)
        {
            mClear();
            datashow();
        }

        private void radPaymentVoucher_Click(object sender, EventArgs e)
        {
            mClear();
            datashow();
        }
    }
}





