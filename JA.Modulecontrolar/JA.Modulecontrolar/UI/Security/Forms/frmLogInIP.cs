using Dutility;
using JA.Modulecontrolar.JACCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Microsoft.Win32;

namespace JA.Modulecontrolar.UI.Security.Forms
{
    public partial class frmLogInIP : JA.Shared.UI.frmJagoronFromSearch
    {
      
        JACCMS.SWJAGClient accms = new SWJAGClient();
        private string strComID { get; set; }
        public frmLogInIP()
        {
            InitializeComponent();
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SmartAccounts");
            strComID = (String)regKey.GetValue("CompanyID", "0001");

          
        }
     
        #region "User Define Event"
       
        #endregion
        private void frmLogInIP_Load(object sender, EventArgs e)
        {
            DG.AllowUserToAddRows = false;

            DG.Columns.Add(Utility.Create_Grid_Column("Session ID", "Session ID", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Host Name", "Host Name", 250, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("IP Address", "IP Address", 150, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Net Transport", "Net Transport", 160, true, DataGridViewContentAlignment.TopLeft, true));
            DG.Columns.Add(Utility.Create_Grid_Column("Connection Time", "Connection Time", 200, true, DataGridViewContentAlignment.TopLeft, true));
            GetIP();
         
        }
     
        private void  GetIP()
        {
            int introw=0;
            string strHostName = "";
            DG.Rows.Clear();
            List<Utility.TCPIP> ootcp = Utility.getTCPIP(strComID).ToList();
            if (ootcp.Count >0)
            {
                foreach(Utility.TCPIP oIP in ootcp)
                {
                    if (mcheckNode(oIP.strHostname)==false)
                    {
                        DG.Rows.Add();
                        DG[0, introw].Value = introw + 1;
                        DG[1, introw].Value = oIP.strHostname ;
                        DG[2, introw].Value = oIP.strIPAddress;
                        DG[3, introw].Value = oIP.strNetTrasport;
                        DG[4, introw].Value = oIP.strConnectTime;
                        introw += 1;
                        lblName.Text = "Total Activate User: " + introw;
                        strHostName = oIP.strHostname;
                    }
                }
            }
        }
        private bool mcheckNode(string strNode)
        {
            bool blngchek=false;
            for (int intow=0;intow < DG.Rows.Count ;intow++)
            {
                if (strNode == DG[1,intow].Value.ToString())
                {
                    blngchek=true;
                    return true;
                }
                //else
                //{
                //    blngchek=false;
                //    return false;
                //}
            }
            return blngchek;
        }
        private void btnReferesh_Click(object sender, EventArgs e)
        {
            GetIP();
        }

        


    }
}
